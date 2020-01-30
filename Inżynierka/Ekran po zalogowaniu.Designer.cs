namespace Inzynierka
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonUzytkownicy = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.dataGridViewOdbicia = new System.Windows.Forms.DataGridView();
            this.labelOdbicia = new System.Windows.Forms.Label();
            this.buttonWnioski = new System.Windows.Forms.Button();
            this.dateTimePickerDataod = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatado = new System.Windows.Forms.DateTimePicker();
            this.labelDokiedy = new System.Windows.Forms.Label();
            this.labelOdkiedy = new System.Windows.Forms.Label();
            this.buttonOdswiez = new System.Windows.Forms.Button();
            this.labelImie = new System.Windows.Forms.Label();
            this.groupBoxDane = new System.Windows.Forms.GroupBox();
            this.labelStanowisko = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonRaport = new System.Windows.Forms.Button();
            this.buttonReczneOdbicia = new System.Windows.Forms.Button();
            this.buttonHarmonogram = new System.Windows.Forms.Button();
            this.buttonKarty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbicia)).BeginInit();
            this.groupBoxDane.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUzytkownicy
            // 
            this.buttonUzytkownicy.Location = new System.Drawing.Point(227, 99);
            this.buttonUzytkownicy.Name = "buttonUzytkownicy";
            this.buttonUzytkownicy.Size = new System.Drawing.Size(135, 35);
            this.buttonUzytkownicy.TabIndex = 0;
            this.buttonUzytkownicy.Text = "Użytkownicy";
            this.buttonUzytkownicy.UseVisualStyleBackColor = true;
            this.buttonUzytkownicy.Click += new System.EventHandler(this.ButtonUzytkownicy_Click);
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.Location = new System.Drawing.Point(137, 117);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(75, 23);
            this.buttonWyloguj.TabIndex = 2;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = true;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // dataGridViewOdbicia
            // 
            this.dataGridViewOdbicia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOdbicia.Location = new System.Drawing.Point(12, 212);
            this.dataGridViewOdbicia.Name = "dataGridViewOdbicia";
            this.dataGridViewOdbicia.Size = new System.Drawing.Size(491, 150);
            this.dataGridViewOdbicia.TabIndex = 3;
            // 
            // labelOdbicia
            // 
            this.labelOdbicia.AutoSize = true;
            this.labelOdbicia.Location = new System.Drawing.Point(18, 194);
            this.labelOdbicia.Name = "labelOdbicia";
            this.labelOdbicia.Size = new System.Drawing.Size(90, 13);
            this.labelOdbicia.TabIndex = 4;
            this.labelOdbicia.Text = "Wejścia / wyjścia";
            // 
            // buttonWnioski
            // 
            this.buttonWnioski.Location = new System.Drawing.Point(227, 58);
            this.buttonWnioski.Name = "buttonWnioski";
            this.buttonWnioski.Size = new System.Drawing.Size(135, 35);
            this.buttonWnioski.TabIndex = 5;
            this.buttonWnioski.Text = "Wnioski";
            this.buttonWnioski.UseVisualStyleBackColor = true;
            this.buttonWnioski.Click += new System.EventHandler(this.buttonWnioski_Click);
            // 
            // dateTimePickerDataod
            // 
            this.dateTimePickerDataod.Location = new System.Drawing.Point(12, 164);
            this.dateTimePickerDataod.Name = "dateTimePickerDataod";
            this.dateTimePickerDataod.Size = new System.Drawing.Size(190, 20);
            this.dateTimePickerDataod.TabIndex = 6;
            // 
            // dateTimePickerDatado
            // 
            this.dateTimePickerDatado.Location = new System.Drawing.Point(227, 164);
            this.dateTimePickerDatado.Name = "dateTimePickerDatado";
            this.dateTimePickerDatado.Size = new System.Drawing.Size(190, 20);
            this.dateTimePickerDatado.TabIndex = 7;
            // 
            // labelDokiedy
            // 
            this.labelDokiedy.AutoSize = true;
            this.labelDokiedy.Location = new System.Drawing.Point(233, 147);
            this.labelDokiedy.Name = "labelDokiedy";
            this.labelDokiedy.Size = new System.Drawing.Size(22, 13);
            this.labelDokiedy.TabIndex = 8;
            this.labelDokiedy.Text = "do:";
            // 
            // labelOdkiedy
            // 
            this.labelOdkiedy.AutoSize = true;
            this.labelOdkiedy.Location = new System.Drawing.Point(15, 146);
            this.labelOdkiedy.Name = "labelOdkiedy";
            this.labelOdkiedy.Size = new System.Drawing.Size(103, 13);
            this.labelOdkiedy.TabIndex = 9;
            this.labelOdkiedy.Text = "Sprawdź odbicia od:";
            // 
            // buttonOdswiez
            // 
            this.buttonOdswiez.Location = new System.Drawing.Point(428, 164);
            this.buttonOdswiez.Name = "buttonOdswiez";
            this.buttonOdswiez.Size = new System.Drawing.Size(75, 20);
            this.buttonOdswiez.TabIndex = 10;
            this.buttonOdswiez.Text = "Odśwież";
            this.buttonOdswiez.UseVisualStyleBackColor = true;
            this.buttonOdswiez.Click += new System.EventHandler(this.buttonOdswiez_Click);
            // 
            // labelImie
            // 
            this.labelImie.AutoSize = true;
            this.labelImie.Location = new System.Drawing.Point(6, 22);
            this.labelImie.Name = "labelImie";
            this.labelImie.Size = new System.Drawing.Size(78, 13);
            this.labelImie.TabIndex = 12;
            this.labelImie.Text = "Imię i nazwisko";
            // 
            // groupBoxDane
            // 
            this.groupBoxDane.Controls.Add(this.labelStanowisko);
            this.groupBoxDane.Controls.Add(this.labelEmail);
            this.groupBoxDane.Controls.Add(this.labelImie);
            this.groupBoxDane.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDane.Name = "groupBoxDane";
            this.groupBoxDane.Size = new System.Drawing.Size(200, 99);
            this.groupBoxDane.TabIndex = 13;
            this.groupBoxDane.TabStop = false;
            this.groupBoxDane.Text = "Dane";
            // 
            // labelStanowisko
            // 
            this.labelStanowisko.AutoSize = true;
            this.labelStanowisko.Location = new System.Drawing.Point(6, 47);
            this.labelStanowisko.Name = "labelStanowisko";
            this.labelStanowisko.Size = new System.Drawing.Size(62, 13);
            this.labelStanowisko.TabIndex = 14;
            this.labelStanowisko.Text = "Stanowisko";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(6, 72);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(64, 13);
            this.labelEmail.TabIndex = 13;
            this.labelEmail.Text = "Adres e-mail";
            // 
            // buttonRaport
            // 
            this.buttonRaport.Location = new System.Drawing.Point(368, 99);
            this.buttonRaport.Name = "buttonRaport";
            this.buttonRaport.Size = new System.Drawing.Size(135, 35);
            this.buttonRaport.TabIndex = 14;
            this.buttonRaport.Text = "Generuj raport";
            this.buttonRaport.UseVisualStyleBackColor = true;
            this.buttonRaport.Click += new System.EventHandler(this.buttonRaport_Click);
            // 
            // buttonReczneOdbicia
            // 
            this.buttonReczneOdbicia.Location = new System.Drawing.Point(368, 17);
            this.buttonReczneOdbicia.Name = "buttonReczneOdbicia";
            this.buttonReczneOdbicia.Size = new System.Drawing.Size(135, 35);
            this.buttonReczneOdbicia.TabIndex = 15;
            this.buttonReczneOdbicia.Text = "Rejestracja brakującego wejścia/wyjścia";
            this.buttonReczneOdbicia.UseVisualStyleBackColor = true;
            this.buttonReczneOdbicia.Click += new System.EventHandler(this.buttonReczneOdbicia_Click);
            // 
            // buttonHarmonogram
            // 
            this.buttonHarmonogram.Location = new System.Drawing.Point(368, 58);
            this.buttonHarmonogram.Name = "buttonHarmonogram";
            this.buttonHarmonogram.Size = new System.Drawing.Size(135, 35);
            this.buttonHarmonogram.TabIndex = 16;
            this.buttonHarmonogram.Text = "Harmonogram";
            this.buttonHarmonogram.UseVisualStyleBackColor = true;
            this.buttonHarmonogram.Click += new System.EventHandler(this.ButtonHarmonogram_Click);
            // 
            // buttonkarty
            // 
            this.buttonKarty.Location = new System.Drawing.Point(227, 17);
            this.buttonKarty.Name = "buttonkarty";
            this.buttonKarty.Size = new System.Drawing.Size(135, 35);
            this.buttonKarty.TabIndex = 17;
            this.buttonKarty.Text = "Karty";
            this.buttonKarty.UseVisualStyleBackColor = true;
            this.buttonKarty.Click += new System.EventHandler(this.ButtonKarty_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 375);
            this.Controls.Add(this.buttonKarty);
            this.Controls.Add(this.buttonHarmonogram);
            this.Controls.Add(this.buttonReczneOdbicia);
            this.Controls.Add(this.buttonRaport);
            this.Controls.Add(this.groupBoxDane);
            this.Controls.Add(this.buttonOdswiez);
            this.Controls.Add(this.labelOdkiedy);
            this.Controls.Add(this.labelDokiedy);
            this.Controls.Add(this.dateTimePickerDatado);
            this.Controls.Add(this.dateTimePickerDataod);
            this.Controls.Add(this.buttonWnioski);
            this.Controls.Add(this.labelOdbicia);
            this.Controls.Add(this.dataGridViewOdbicia);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.buttonUzytkownicy);
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "RCP Program";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbicia)).EndInit();
            this.groupBoxDane.ResumeLayout(false);
            this.groupBoxDane.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUzytkownicy;
        private System.Windows.Forms.Button buttonWyloguj;
        private System.Windows.Forms.DataGridView dataGridViewOdbicia;
        private System.Windows.Forms.Label labelOdbicia;
        private System.Windows.Forms.Button buttonWnioski;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataod;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatado;
        private System.Windows.Forms.Label labelDokiedy;
        private System.Windows.Forms.Label labelOdkiedy;
        private System.Windows.Forms.Button buttonOdswiez;
        private System.Windows.Forms.Label labelImie;
        private System.Windows.Forms.GroupBox groupBoxDane;
        private System.Windows.Forms.Label labelStanowisko;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonRaport;
        private System.Windows.Forms.Button buttonReczneOdbicia;
        private System.Windows.Forms.Button buttonHarmonogram;
        private System.Windows.Forms.Button buttonKarty;
    }
}