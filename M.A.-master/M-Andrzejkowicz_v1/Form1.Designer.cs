namespace M_Andrzejkowicz_v1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.log_textbox = new System.Windows.Forms.TextBox();
            this.log_label = new System.Windows.Forms.Label();
            this.LISTA = new System.Windows.Forms.ListView();
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Proto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.IntervalPingTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.NazwaWifi = new System.Windows.Forms.TextBox();
            this.HasloWifi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.twojehaslo = new System.Windows.Forms.Label();
            this.szyfrowanie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.powiadomienia = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // log_textbox
            // 
            this.log_textbox.BackColor = System.Drawing.SystemColors.MenuText;
            this.log_textbox.ForeColor = System.Drawing.SystemColors.Window;
            this.log_textbox.Location = new System.Drawing.Point(180, 27);
            this.log_textbox.Multiline = true;
            this.log_textbox.Name = "log_textbox";
            this.log_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_textbox.Size = new System.Drawing.Size(491, 600);
            this.log_textbox.TabIndex = 0;
            // 
            // log_label
            // 
            this.log_label.AutoSize = true;
            this.log_label.Location = new System.Drawing.Point(397, 3);
            this.log_label.Name = "log_label";
            this.log_label.Size = new System.Drawing.Size(29, 13);
            this.log_label.TabIndex = 1;
            this.log_label.Text = "LOG";
            // 
            // LISTA
            // 
            this.LISTA.BackColor = System.Drawing.SystemColors.MenuText;
            this.LISTA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Index,
            this.Proto,
            this.L0,
            this.L1,
            this.L2,
            this.L3,
            this.L_port,
            this.F0,
            this.F1,
            this.F2,
            this.F3,
            this.F_port,
            this.State,
            this.PID});
            this.LISTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LISTA.ForeColor = System.Drawing.SystemColors.Window;
            this.LISTA.FullRowSelect = true;
            this.LISTA.GridLines = true;
            this.LISTA.Location = new System.Drawing.Point(677, 27);
            this.LISTA.Name = "LISTA";
            this.LISTA.Size = new System.Drawing.Size(733, 600);
            this.LISTA.TabIndex = 2;
            this.LISTA.UseCompatibleStateImageBehavior = false;
            this.LISTA.View = System.Windows.Forms.View.Details;
            // 
            // Index
            // 
            this.Index.Text = "Index";
            this.Index.Width = 38;
            // 
            // Proto
            // 
            this.Proto.Text = "Proto";
            // 
            // L0
            // 
            this.L0.Text = "L0";
            this.L0.Width = 32;
            // 
            // L1
            // 
            this.L1.Text = "L1";
            this.L1.Width = 34;
            // 
            // L2
            // 
            this.L2.Text = "L2";
            this.L2.Width = 31;
            // 
            // L3
            // 
            this.L3.Text = "L3";
            this.L3.Width = 34;
            // 
            // L_port
            // 
            this.L_port.Text = "L_port";
            this.L_port.Width = 70;
            // 
            // F0
            // 
            this.F0.Text = "F0";
            this.F0.Width = 30;
            // 
            // F1
            // 
            this.F1.Text = "F1";
            this.F1.Width = 29;
            // 
            // F2
            // 
            this.F2.Text = "F2";
            this.F2.Width = 34;
            // 
            // F3
            // 
            this.F3.Text = "F3";
            this.F3.Width = 33;
            // 
            // F_port
            // 
            this.F_port.Text = "F_port";
            this.F_port.Width = 53;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 138;
            // 
            // PID
            // 
            this.PID.Text = "PID";
            this.PID.Width = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(836, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1023, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Foreign Address";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Okresowe pingowanie\r\n   Default Gateway";
            // 
            // IntervalPingTextbox
            // 
            this.IntervalPingTextbox.Location = new System.Drawing.Point(12, 58);
            this.IntervalPingTextbox.Multiline = true;
            this.IntervalPingTextbox.Name = "IntervalPingTextbox";
            this.IntervalPingTextbox.ReadOnly = true;
            this.IntervalPingTextbox.Size = new System.Drawing.Size(155, 48);
            this.IntervalPingTextbox.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Wyświetl dane wifi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NazwaWifi
            // 
            this.NazwaWifi.Location = new System.Drawing.Point(12, 175);
            this.NazwaWifi.Name = "NazwaWifi";
            this.NazwaWifi.ReadOnly = true;
            this.NazwaWifi.Size = new System.Drawing.Size(155, 20);
            this.NazwaWifi.TabIndex = 23;
            // 
            // HasloWifi
            // 
            this.HasloWifi.Location = new System.Drawing.Point(12, 214);
            this.HasloWifi.Name = "HasloWifi";
            this.HasloWifi.ReadOnly = true;
            this.HasloWifi.Size = new System.Drawing.Size(155, 20);
            this.HasloWifi.TabIndex = 24;
            this.HasloWifi.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Nazwa sieci";
            // 
            // twojehaslo
            // 
            this.twojehaslo.AutoSize = true;
            this.twojehaslo.Location = new System.Drawing.Point(69, 198);
            this.twojehaslo.Name = "twojehaslo";
            this.twojehaslo.Size = new System.Drawing.Size(34, 13);
            this.twojehaslo.TabIndex = 26;
            this.twojehaslo.Text = "Haslo";
            this.twojehaslo.Visible = false;
            // 
            // szyfrowanie
            // 
            this.szyfrowanie.Location = new System.Drawing.Point(12, 297);
            this.szyfrowanie.Name = "szyfrowanie";
            this.szyfrowanie.ReadOnly = true;
            this.szyfrowanie.Size = new System.Drawing.Size(155, 20);
            this.szyfrowanie.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "szyfrowanie";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Pokaż";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 30;
            this.button4.Text = "Ukryj";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // powiadomienia
            // 
            this.powiadomienia.AutoSize = true;
            this.powiadomienia.Checked = true;
            this.powiadomienia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.powiadomienia.Location = new System.Drawing.Point(12, 350);
            this.powiadomienia.Name = "powiadomienia";
            this.powiadomienia.Size = new System.Drawing.Size(149, 17);
            this.powiadomienia.TabIndex = 31;
            this.powiadomienia.Text = "Wyświetlaj powiadomienia";
            this.powiadomienia.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::M_Andrzejkowicz_v1.Properties.Resources.key_background2;
            this.pictureBox1.Location = new System.Drawing.Point(28, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1422, 638);
            this.Controls.Add(this.log_textbox);
            this.Controls.Add(this.powiadomienia);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.szyfrowanie);
            this.Controls.Add(this.twojehaslo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.HasloWifi);
            this.Controls.Add(this.NazwaWifi);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.IntervalPingTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LISTA);
            this.Controls.Add(this.log_label);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tester";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox log_textbox;
        private System.Windows.Forms.Label log_label;
        private System.Windows.Forms.ListView LISTA;
        private System.Windows.Forms.ColumnHeader Proto;
        private System.Windows.Forms.ColumnHeader L0;
        private System.Windows.Forms.ColumnHeader L1;
        private System.Windows.Forms.ColumnHeader L2;
        private System.Windows.Forms.ColumnHeader L3;
        private System.Windows.Forms.ColumnHeader L_port;
        private System.Windows.Forms.ColumnHeader F0;
        private System.Windows.Forms.ColumnHeader F1;
        private System.Windows.Forms.ColumnHeader F2;
        private System.Windows.Forms.ColumnHeader F3;
        private System.Windows.Forms.ColumnHeader F_port;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader PID;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IntervalPingTextbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox NazwaWifi;
        private System.Windows.Forms.TextBox HasloWifi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label twojehaslo;
        private System.Windows.Forms.TextBox szyfrowanie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox powiadomienia;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

