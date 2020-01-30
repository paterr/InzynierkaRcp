namespace WindowsFormsApp3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxZrodloDanych = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxKatalog = new System.Windows.Forms.TextBox();
            this.textBoxUzytkownik = new System.Windows.Forms.TextBox();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonZainstaluj = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMailHost = new System.Windows.Forms.TextBox();
            this.textBoxMailPort = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxMailHaslo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxNazwaFirmy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Źródło danych:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Katalog:";
            // 
            // textBoxZrodloDanych
            // 
            this.textBoxZrodloDanych.Location = new System.Drawing.Point(385, 15);
            this.textBoxZrodloDanych.Name = "textBoxZrodloDanych";
            this.textBoxZrodloDanych.Size = new System.Drawing.Size(142, 20);
            this.textBoxZrodloDanych.TabIndex = 6;
            this.textBoxZrodloDanych.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(385, 46);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(142, 20);
            this.textBoxPort.TabIndex = 7;
            // 
            // textBoxKatalog
            // 
            this.textBoxKatalog.Location = new System.Drawing.Point(385, 75);
            this.textBoxKatalog.Name = "textBoxKatalog";
            this.textBoxKatalog.Size = new System.Drawing.Size(142, 20);
            this.textBoxKatalog.TabIndex = 8;
            // 
            // textBoxUzytkownik
            // 
            this.textBoxUzytkownik.Location = new System.Drawing.Point(385, 102);
            this.textBoxUzytkownik.Name = "textBoxUzytkownik";
            this.textBoxUzytkownik.Size = new System.Drawing.Size(142, 20);
            this.textBoxUzytkownik.TabIndex = 9;
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Location = new System.Drawing.Point(385, 139);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.Size = new System.Drawing.Size(142, 20);
            this.textBoxHaslo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Użytkownik:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hasło:";
            // 
            // buttonZainstaluj
            // 
            this.buttonZainstaluj.Location = new System.Drawing.Point(385, 191);
            this.buttonZainstaluj.Name = "buttonZainstaluj";
            this.buttonZainstaluj.Size = new System.Drawing.Size(112, 36);
            this.buttonZainstaluj.TabIndex = 13;
            this.buttonZainstaluj.Text = "Zainstaluj bazę";
            this.buttonZainstaluj.UseVisualStyleBackColor = true;
            this.buttonZainstaluj.Click += new System.EventHandler(this.ButtonZainstaluj_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 67);
            this.button2.TabIndex = 14;
            this.button2.Text = "Testuj połączenie z bazą danych";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(753, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "label6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Zapisz plik .ini";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Host Maila";
            // 
            // textBoxMailHost
            // 
            this.textBoxMailHost.Location = new System.Drawing.Point(116, 177);
            this.textBoxMailHost.Name = "textBoxMailHost";
            this.textBoxMailHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxMailHost.TabIndex = 17;
            // 
            // textBoxMailPort
            // 
            this.textBoxMailPort.Location = new System.Drawing.Point(116, 220);
            this.textBoxMailPort.Name = "textBoxMailPort";
            this.textBoxMailPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxMailPort.TabIndex = 18;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(116, 257);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(100, 20);
            this.textBoxMail.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Host:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Port:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(81, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Mail:";
            // 
            // textBoxMailHaslo
            // 
            this.textBoxMailHaslo.Location = new System.Drawing.Point(116, 284);
            this.textBoxMailHaslo.Name = "textBoxMailHaslo";
            this.textBoxMailHaslo.Size = new System.Drawing.Size(100, 20);
            this.textBoxMailHaslo.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Hasło:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Nazwa firmy:";
            // 
            // textBoxNazwaFirmy
            // 
            this.textBoxNazwaFirmy.Location = new System.Drawing.Point(101, 60);
            this.textBoxNazwaFirmy.Name = "textBoxNazwaFirmy";
            this.textBoxNazwaFirmy.Size = new System.Drawing.Size(100, 20);
            this.textBoxNazwaFirmy.TabIndex = 26;
            this.textBoxNazwaFirmy.TextChanged += new System.EventHandler(this.TextBoxNazwaFirmy_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxNazwaFirmy);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxMailHaslo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxMailPort);
            this.Controls.Add(this.textBoxMailHost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonZainstaluj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHaslo);
            this.Controls.Add(this.textBoxUzytkownik);
            this.Controls.Add(this.textBoxKatalog);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxZrodloDanych);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "InstalatorRCP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxZrodloDanych;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxKatalog;
        private System.Windows.Forms.TextBox textBoxUzytkownik;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonZainstaluj;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMailHost;
        private System.Windows.Forms.TextBox textBoxMailPort;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxMailHaslo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxNazwaFirmy;
    }
}

