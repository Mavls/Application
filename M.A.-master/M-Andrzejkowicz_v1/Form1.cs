using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;

namespace M_Andrzejkowicz_v1
{
    public partial class Form1 : Form
    {
        //======================================Z M I E N N E  G L O B A L N E====================================//
        string ipAddress;                                                       // Zmienna która będzie trzymać Twoj numer IP
        List<List<string>> TablicaRzeczy = new List<List<string>>();            //Tablica tablic (dwuwymiarowa tablica) trzymająca dane z netstat -ano czyli LISTENINGI i podsłuchy
        String WatchStatus = "LISTENING";                                       //Tutaj ustawiasz czy program ma alarmować przy wykryciu innego statusu niż LISTEINING 
        String DefaultGetaway = "";                                             // Zmienna która będzie trzymać Twój Default Getaway
        Process Process = new System.Diagnostics.Process();                     // Proces cmd którym będziemy zadawać pytania 
        String PASSWORD=""; // HASŁO DO SIECI WIFI                              //Zmienna na Twoje hasło WIFI
        String SSID = ""; // SSID WIFI                                          //Zmienna na nazwę Twojej sieci WIFI
        String SZYFROWANIE = ""; //SZYFROWANIE                                  //Zmienna na typ szyfrowania 
        PasswordStrength SprawdzaczSilyHasla = new PasswordStrength();          //Tworzymy obiekt klasy PasswordStrength który obsłuzy nam sprawdzanie mocy hasła itd
        int IloscPodlaczonychUrzadzen = 0;                                      //Zmienna sprawdzająca czy są jakieś nowe IP w arp -a. na jej podstawie wyzwala się alarm
        int iloscThreadow = 0;                                                  //Ilość wykonujących się wątków
        int punktacja = 0;                                                      // Punktacja mocy hasła wifi                                 
        List<string> OdpowiedzMultiThreadu = new List<string>();                //Lista do której pakują się wszystkie odpowiedzi z wątków pingujących podsieć
        //THREADY
        Thread th1; //Thready odpowiedzialne za pingowanie
        Thread th2; //Thread odpowiedzialny za uruchamianie threadów odpowiedzialnych za pingowanie
        //====================================== U R U C H O M I E N I E  FORM1====================//
        public Form1()
        {
            InitializeComponent();
            ipAddress = NetworkGateway();
            SkanujPodsiec();
            myTimer.Tick += new EventHandler(TimerEventProcessor); //Inicjalizujemy sobie zegarek który będzie cykał co 5 sekund i wywoływał okreslone metody
            myTimer.Interval = 5000;
            myTimer.Start();
            Process.Start();
            CmdQueryAdmin("arp -d");
            log_textbox.AppendText("\r\n\r\n Witaj! Przed rozpoczęciem monitoringu robię wstępne zapytanie arp -a \r\n");
            log_textbox.AppendText(DateTime.Now + "\r\n");
            log_textbox.AppendText(CmdQuery("arp"," -a"));
            log_textbox.AppendText("\r\n\r\n ----------------------------------------------------------------------------------- \r\n");
            UruchomPingowaniePodsieci();
            notifyIcon1.Visible = true;
        }
        //====================================== E V E N T Y  T I M E R A =========================//
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            String PingOutput = (CmdQuery("ping ", DefaultGetaway + " -n 1"));
            if (PingOutput.IndexOf("unreachable") >= 0)
            {
                Console.WriteLine("ALARM! NIE UDAŁO SIE SPINGOWAC!");
                IntervalPingTextbox.Text = "Pingowanie " + DefaultGetaway + "ZJEBAWSZY! ALARM! \r\n " + DateTime.Now;
                log_textbox.AppendText("Pingowanie " + DefaultGetaway + "ZJEBAWSZY! ALARM! " + DateTime.Now + "\r\n");
                IntervalPingTextbox.BackColor = Color.Red;
            }
            else
            {
                Console.WriteLine("Pingowanie Default Gatewaya w porządku :3");
                IntervalPingTextbox.Text = "Pingowanie "+DefaultGetaway+" OK \r\n " + DateTime.Now;
                IntervalPingTextbox.BackColor = Color.Green;
            }
            //Thready
            if(iloscThreadow>=255)
            {
                Console.WriteLine("Siec została spingowana pomyślnie. stan arp -a to:");
                log_textbox.AppendText("\r\n\r\n Siec została spingowana pomyślnie. stan arp -a \r\n");
                log_textbox.AppendText(DateTime.Now + "\r\n");
                string[] arpa = SprawdzArpA();
                foreach (string a in arpa)
                {
                    Console.WriteLine(a + "\r\n");
                    log_textbox.AppendText(a + "\r\n");
                }
                iloscThreadow = 0;
                string arp = CmdQuery("arp", " -a");
                if(IloscPodlaczonychUrzadzen != arp.Length)
                {
                    IloscPodlaczonychUrzadzen = arp.Length;
                    if(powiadomienia.Checked)
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Uwaga","Ilość podłączonych urządzeń uległa zmianie!", ToolTipIcon.Info);
                        log_textbox.AppendText("\r\n Uwaga! Ilość podłączonych urządzeń uległa zmianie! " + DateTime.Now + "\r\n");
                    }                   
                }
                OdpowiedzMultiThreadu.Clear();
                UruchomPingowaniePodsieci();
            }
            LISTA.Items.Clear();
            skanuj_button_Click(ipAddress);
            SprawdzPodsluchy();
            SkanujPodsiec();
        }
        //====================================== Z A P Y T A N I A  D O  C M D =========================//
        private string CmdQuery(string FileName, string Arguments = "")
        {



            Process.StartInfo.FileName = FileName;
            Process.StartInfo.Arguments = Arguments;
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.CreateNoWindow = true;
            
            Process.Start();
            string output = "";

            output = Process.StandardOutput.ReadToEnd();
                while (output.IndexOf("  ") > 0)
                {
                    output = output.Replace("  ", " ");
                }
            
            return output;
        }
        private void CmdQueryAdmin(string Argument)
        {
            var proc1 = new ProcessStartInfo();
            string anyCommand;
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + Argument;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
            Console.WriteLine("Wykonano zadanie admin CmdQueryAdmin: "+ Argument);
        }
        string ZnajdzLinijke(string input, string StartString)
        {
            String output = "";

            if (input.IndexOf(StartString) >= 0)
            {
                output = input.Remove(0, input.IndexOf(StartString));

                output = output.Remove(output.IndexOf("\n"), output.Length - output.IndexOf("\n"));

                output = output.Replace("\n", "");
                output = output.Replace("\r", "");
                output = output.Replace(" ", "");
            }
            else
            {
                log_textbox.AppendText("Nie odnaleziono " + input);
            }



            return output;
        }
        //====================================== N E T W O R K I N G =========================//
        static string NetworkGateway()
        {
            string ip = null;

            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                    {
                        if (ip == null)
                            ip = d.Address.ToString();
                    }
                }
            }
            Console.WriteLine("wypisuje ip");
            Console.WriteLine(ip);
            return ip;
        }
        private void SprawdzPodsluchy()
        {
            //Przejedz znow przez tablice i sprawdz czy ktos nas podsłuchuje
            int index = 0;
            foreach (List<string> y in TablicaRzeczy)
            {
                if (y[7] != "0" || y[8] != "0" || y[9] != "0" || y[10] != "0")
                {
                    if (y[11] == WatchStatus)
                    {
                        Console.WriteLine("PODSŁUCH! na pozycji: " + index);
                        log_textbox.AppendText("\r\n Wykryto podsłuch ! \r\n");
                        LISTA.Items[index].BackColor = Color.Red;
                        notifyIcon1.Icon = SystemIcons.Application;
                        if(powiadomienia.Checked)
                        {
                            notifyIcon1.BalloonTipText = "Wykryto podsłuch!";
                            notifyIcon1.ShowBalloonTip(10);
                        }
                        
                        return;
                    }
                    Console.WriteLine("MAMY NIEZEROWE FOREIGNY!");
                }
                index++;
            }
        }
        private void SkanujPodsiec()
        {
            Console.WriteLine(CmdQuery("ipconfig"));
            String[] TabelaIpConfig = CmdQuery("ipconfig").Split('\n');
            Console.WriteLine();
            for(int i=0; i<TabelaIpConfig.Length; i++) // szukaj IP
            {
                if(TabelaIpConfig[i].IndexOf("Default Gateway") >=0) // Jesli w linijce znajduje sie IPv4
                {
                    TabelaIpConfig[i] = TabelaIpConfig[i].Remove(0, TabelaIpConfig[i].IndexOf(':')+1).Trim();
                    Console.WriteLine("wypisuje!");
                    DefaultGetaway = TabelaIpConfig[i];
                    Console.WriteLine(DefaultGetaway);
                }

            }
        }
        private string[] SprawdzArpA()
        {
            string query = CmdQuery("arp", " -a");
            String[] Output;
            query = query.Replace("\r\n", "|");
            query = query.Replace("\n", "|");
            Char[] delimiter = { '|'};
            Output = query.Split(delimiter);
            return Output;
        }
        private void SprawdzNazweWifi()
        {
            SSID = CmdQuery("Netsh", " WLAN show interfaces");
            SSID = ZnajdzLinijke(SSID, "SSID");
            SSID = SSID.Replace("SSID:", "");
            Console.WriteLine(SSID);
            NazwaWifi.Text = SSID;
        }
        private void SprawdzSzyfrowanieWifi()
        {
            SZYFROWANIE = CmdQuery("Netsh", " WLAN show interfaces");
            SZYFROWANIE = ZnajdzLinijke(SZYFROWANIE, "Authentication");
            SZYFROWANIE = SZYFROWANIE.Replace("Authentication:", "");
            Console.WriteLine(SZYFROWANIE);
            szyfrowanie.Text = SZYFROWANIE;
        }
        private void SprawdzHasłoWifi()
        {
            PASSWORD = CmdQuery("netsh", " wlan show profile name="+SSID+" key=clear");
            PASSWORD = ZnajdzLinijke(PASSWORD, "Key Content");
            PASSWORD = PASSWORD.Replace("KeyContent:", "");
            Console.WriteLine(PASSWORD);
            HasloWifi.Text = PASSWORD;
            twojehaslo.Visible = true;
        }
        private void SprawdzMocHasłaWifi()
        {
            punktacja = 0;
            foreach(char a in PASSWORD)
            {
                if(Char.IsNumber(a))
                {
                    punktacja += 10;
                }
                else if(Char.IsLower(a))
                {
                    punktacja += 26;
                }
                else if (Char.IsUpper(a))
                {
                    punktacja += 26;
                }
                else if (!Char.IsLetterOrDigit(a))
                {
                    punktacja += 33;
                }
                else
                {
                    punktacja += 66;
                }
            }

            if(punktacja<220)
            {
                log_textbox.AppendText("\r\n HASŁO WIFI JEST SŁABE! Jego siła wynosi: " + punktacja + "\r\n");
                HasloWifi.BackColor = Color.DarkRed;
            }
            else if(punktacja>220 && punktacja<260)
            {
                log_textbox.AppendText("\r\n HASŁO WIFI JEST ŚREDNIEJ MOCY! Jego siła wynosi: " + punktacja + "\r\n");
                HasloWifi.BackColor = Color.DarkOrange;
            }
            else if(punktacja>=260)
            {
                log_textbox.AppendText("\r\n HASŁO WIFI JEST MOCNE! Jego siła wynosi: " + punktacja + "\r\n");

            }
        }
        private void SprawdzanieSilyHasla()
        {
            log_textbox.AppendText("\r\n ======================================\r\n"+SprawdzaczSilyHasla.CheckStrength(SSID, PASSWORD)+"\r\n ======================================\r\n");
        }
        //======================================E V E N T Y  U I====================================//
        private void button5_Click(object sender, EventArgs e)
        {
            string[] arp = SprawdzArpA();
            foreach(string a in arp)
            {
                Console.WriteLine(a);
                log_textbox.AppendText(a + "\r\n");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            CmdQueryAdmin("arp -d -a");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SprawdzNazweWifi();
            SprawdzHasłoWifi();
            SprawdzSzyfrowanieWifi();
            SprawdzanieSilyHasla();
            SprawdzMocHasłaWifi();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "Aplikacja działa w tle";
                notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            WatchStatus = "LISTENING";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            WatchStatus = "ESTABLISHED";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            WatchStatus = "CLOSE_WAIT";
        }
        private void skanuj_button_Click(string ipAddress)
        {
            string strOutput = CmdQuery("netstat", "-ano");


            Boolean dodajWiersz = true;
            List<string> Wiersz = new List<string>();
            Wiersz.Clear();
            TablicaRzeczy.Clear();
            dodajWiersz = true;

            Char[] delimiter = { ' ', '.', ':' };
            String[] substrings = strOutput.Split(delimiter);

            for (int i = 0; i < substrings.Length; i++)
            {
                if (substrings[i].IndexOf("\r\n") > 0)
                {
                    substrings[i] = substrings[i].Replace("\r\n\r\n", "|");
                    substrings[i] = substrings[i].Replace("\r\n", "|");
                }
                else
                {
                    substrings[i] = substrings[i].Replace("\r\n\r\n", "");
                    substrings[i] = substrings[i].Replace("\r\n", "");
                }

            }



            foreach (var substring in substrings)
            {
                // SPRAWDZANIE CZY W JAKIMŚ WIERSZU SĄ JAKIEŚ RZECZY!
                Wiersz.Add(substring.Replace("|", ""));
                if (substring.IndexOf("[") >= 0 || substring.IndexOf("*") >= 0 || substring.IndexOf("Active") >= 0 || substring.IndexOf("Proto") >= 0)
                {
                    dodajWiersz = false;
                }
                if (substring.IndexOf("|") >= 0)
                {
                    if (dodajWiersz)
                    {
                        TablicaRzeczy.Add(new List<string>(Wiersz));
                    }
                    Wiersz.Clear();
                    dodajWiersz = true;
                }
            }
            Console.WriteLine("ITERUJEMY!");
            //Iterujemy poprzez listę list
            int index = 0;
            foreach (List<string> y in TablicaRzeczy)
            {
                ListViewItem lvi = new ListViewItem(index.ToString());
                index++;
                foreach (string x in y)
                {
                    Console.Write("" + x + "");
                    lvi.SubItems.Add(x);
                }
                LISTA.Items.Add(lvi);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HasloWifi.UseSystemPasswordChar = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            HasloWifi.UseSystemPasswordChar = true;
        }
        // URUCHAMIANIE MULTITHREADOWEGO PINGOWANIA
        private void button1_Click(object sender, EventArgs e)
        {
            UruchomPingowaniePodsieci();
        }
        private void UruchomPingowaniePodsieci()
        {
            th2 = new Thread(() => UruchamiePingowaniaPodsieciThread());
            th2.Start();
        }
        private void UruchamiePingowaniaPodsieciThread()
        {
            for (int i = 0; i < 255; i++)
            {
                th1 = new Thread(() => ThreadTest(i));
                Thread.Sleep(45);
                th1.Start();
            }
        }
        public void ThreadTest(int i)
        {
            try
            {
                String Query = (CmdQuery("ping", " 192.168.0." + i + " -n 1"));
                OdpowiedzMultiThreadu.Add(Query);
                Console.WriteLine(Query);
                Console.WriteLine("Wątek nr " + i + " zakonczył dzialanie!");
                iloscThreadow += 1;
                Console.WriteLine("ilosc threadow: " + iloscThreadow);
                Console.WriteLine("length : " + OdpowiedzMultiThreadu.Count);
            }
            catch
            {
            }
        }
    }
}
