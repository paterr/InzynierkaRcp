namespace Inzynierka
{
    partial class FormUzytkownicy
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
            this.buttonEdytuj = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelImie = new System.Windows.Forms.Label();
            this.labelNazwisko = new System.Windows.Forms.Label();
            this.labelStanowisko = new System.Windows.Forms.Label();
            this.labelGrupa = new System.Windows.Forms.Label();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxStanowisko = new System.Windows.Forms.TextBox();
            this.comboBoxGrupy = new System.Windows.Forms.ComboBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.groupBoxEdycja = new System.Windows.Forms.GroupBox();
            this.labelSzef = new System.Windows.Forms.Label();
            this.comboBoxSzef = new System.Windows.Forms.ComboBox();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.buttonResetHasla = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.groupBoxDodawanie = new System.Windows.Forms.GroupBox();
            this.labelSzefDodaj = new System.Windows.Forms.Label();
            this.comboBoxSzefDodaj = new System.Windows.Forms.ComboBox();
            this.buttonDodajUzytkownika = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStanowiskoDodaj = new System.Windows.Forms.TextBox();
            this.comboBoxGrupaDodaj = new System.Windows.Forms.ComboBox();
            this.textBoxEmailDodaj = new System.Windows.Forms.TextBox();
            this.textBoxNazwiskoDodaj = new System.Windows.Forms.TextBox();
            this.textBoxImieDodaj = new System.Windows.Forms.TextBox();
            this.dataGridViewOdbicia = new System.Windows.Forms.DataGridView();
            this.groupBoxOdbicia = new System.Windows.Forms.GroupBox();
            this.buttonOdswiez = new System.Windows.Forms.Button();
            this.labelOdkiedy = new System.Windows.Forms.Label();
            this.labelDokiedy = new System.Windows.Forms.Label();
            this.dateTimePickerDatado = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataod = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxEdycja.SuspendLayout();
            this.groupBoxDodawanie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbicia)).BeginInit();
            this.groupBoxOdbicia.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEdytuj
            // 
            this.buttonEdytuj.Location = new System.Drawing.Point(19, 185);
            this.buttonEdytuj.Name = "buttonEdytuj";
            this.buttonEdytuj.Size = new System.Drawing.Size(76, 49);
            this.buttonEdytuj.TabIndex = 0;
            this.buttonEdytuj.Text = "Edytuj użytkownika";
            this.buttonEdytuj.UseVisualStyleBackColor = true;
            this.buttonEdytuj.Click += new System.EventHandler(this.ButtonEdytuj_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(704, 100);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_list_CellClick);
            // 
            // labelImie
            // 
            this.labelImie.AutoSize = true;
            this.labelImie.Location = new System.Drawing.Point(66, 24);
            this.labelImie.Name = "labelImie";
            this.labelImie.Size = new System.Drawing.Size(29, 13);
            this.labelImie.TabIndex = 2;
            this.labelImie.Text = "Imię:";
            // 
            // labelNazwisko
            // 
            this.labelNazwisko.AutoSize = true;
            this.labelNazwisko.Location = new System.Drawing.Point(39, 49);
            this.labelNazwisko.Name = "labelNazwisko";
            this.labelNazwisko.Size = new System.Drawing.Size(56, 13);
            this.labelNazwisko.TabIndex = 3;
            this.labelNazwisko.Text = "Nazwisko:";
            // 
            // labelStanowisko
            // 
            this.labelStanowisko.AutoSize = true;
            this.labelStanowisko.Location = new System.Drawing.Point(30, 75);
            this.labelStanowisko.Name = "labelStanowisko";
            this.labelStanowisko.Size = new System.Drawing.Size(65, 13);
            this.labelStanowisko.TabIndex = 4;
            this.labelStanowisko.Text = "Stanowisko:";
            // 
            // labelGrupa
            // 
            this.labelGrupa.AutoSize = true;
            this.labelGrupa.Location = new System.Drawing.Point(56, 101);
            this.labelGrupa.Name = "labelGrupa";
            this.labelGrupa.Size = new System.Drawing.Size(39, 13);
            this.labelGrupa.TabIndex = 5;
            this.labelGrupa.Text = "Grupa:";
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(101, 20);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(121, 20);
            this.textBoxImie.TabIndex = 6;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(101, 46);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(121, 20);
            this.textBoxNazwisko.TabIndex = 7;
            // 
            // textBoxStanowisko
            // 
            this.textBoxStanowisko.Location = new System.Drawing.Point(101, 72);
            this.textBoxStanowisko.Name = "textBoxStanowisko";
            this.textBoxStanowisko.Size = new System.Drawing.Size(121, 20);
            this.textBoxStanowisko.TabIndex = 8;
            // 
            // comboBoxGrupy
            // 
            this.comboBoxGrupy.FormattingEnabled = true;
            this.comboBoxGrupy.Location = new System.Drawing.Point(101, 98);
            this.comboBoxGrupy.Name = "comboBoxGrupy";
            this.comboBoxGrupy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGrupy.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(101, 125);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(121, 20);
            this.textBoxEmail.TabIndex = 10;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(60, 128);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "Email:";
            // 
            // groupBoxEdycja
            // 
            this.groupBoxEdycja.Controls.Add(this.labelSzef);
            this.groupBoxEdycja.Controls.Add(this.comboBoxSzef);
            this.groupBoxEdycja.Controls.Add(this.buttonUsun);
            this.groupBoxEdycja.Controls.Add(this.buttonResetHasla);
            this.groupBoxEdycja.Controls.Add(this.textBoxImie);
            this.groupBoxEdycja.Controls.Add(this.labelEmail);
            this.groupBoxEdycja.Controls.Add(this.labelImie);
            this.groupBoxEdycja.Controls.Add(this.textBoxEmail);
            this.groupBoxEdycja.Controls.Add(this.labelNazwisko);
            this.groupBoxEdycja.Controls.Add(this.labelGrupa);
            this.groupBoxEdycja.Controls.Add(this.buttonEdytuj);
            this.groupBoxEdycja.Controls.Add(this.comboBoxGrupy);
            this.groupBoxEdycja.Controls.Add(this.labelStanowisko);
            this.groupBoxEdycja.Controls.Add(this.textBoxStanowisko);
            this.groupBoxEdycja.Controls.Add(this.textBoxNazwisko);
            this.groupBoxEdycja.Location = new System.Drawing.Point(244, 124);
            this.groupBoxEdycja.Name = "groupBoxEdycja";
            this.groupBoxEdycja.Size = new System.Drawing.Size(282, 244);
            this.groupBoxEdycja.TabIndex = 12;
            this.groupBoxEdycja.TabStop = false;
            this.groupBoxEdycja.Text = "Edycja:";
            // 
            // labelSzef
            // 
            this.labelSzef.AutoSize = true;
            this.labelSzef.Location = new System.Drawing.Point(32, 154);
            this.labelSzef.Name = "labelSzef";
            this.labelSzef.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSzef.Size = new System.Drawing.Size(63, 13);
            this.labelSzef.TabIndex = 14;
            this.labelSzef.Text = "Przełożony:";
            // 
            // comboBoxSzef
            // 
            this.comboBoxSzef.FormattingEnabled = true;
            this.comboBoxSzef.Location = new System.Drawing.Point(101, 151);
            this.comboBoxSzef.Name = "comboBoxSzef";
            this.comboBoxSzef.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSzef.TabIndex = 15;
            // 
            // buttonUsun
            // 
            this.buttonUsun.Location = new System.Drawing.Point(101, 185);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(76, 49);
            this.buttonUsun.TabIndex = 13;
            this.buttonUsun.Text = "Usuń użytkownika";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // buttonResetHasla
            // 
            this.buttonResetHasla.Location = new System.Drawing.Point(183, 185);
            this.buttonResetHasla.Name = "buttonResetHasla";
            this.buttonResetHasla.Size = new System.Drawing.Size(76, 49);
            this.buttonResetHasla.TabIndex = 12;
            this.buttonResetHasla.Text = "Zresetuj hasło";
            this.buttonResetHasla.UseVisualStyleBackColor = true;
            this.buttonResetHasla.Click += new System.EventHandler(this.ButtonResetHasla_Click);
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.Location = new System.Drawing.Point(722, 89);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(75, 23);
            this.buttonWyloguj.TabIndex = 13;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = true;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.Location = new System.Drawing.Point(722, 59);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(75, 24);
            this.buttonPowrot.TabIndex = 14;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = true;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // groupBoxDodawanie
            // 
            this.groupBoxDodawanie.Controls.Add(this.labelSzefDodaj);
            this.groupBoxDodawanie.Controls.Add(this.comboBoxSzefDodaj);
            this.groupBoxDodawanie.Controls.Add(this.buttonDodajUzytkownika);
            this.groupBoxDodawanie.Controls.Add(this.label5);
            this.groupBoxDodawanie.Controls.Add(this.label4);
            this.groupBoxDodawanie.Controls.Add(this.label3);
            this.groupBoxDodawanie.Controls.Add(this.label2);
            this.groupBoxDodawanie.Controls.Add(this.label1);
            this.groupBoxDodawanie.Controls.Add(this.textBoxStanowiskoDodaj);
            this.groupBoxDodawanie.Controls.Add(this.comboBoxGrupaDodaj);
            this.groupBoxDodawanie.Controls.Add(this.textBoxEmailDodaj);
            this.groupBoxDodawanie.Controls.Add(this.textBoxNazwiskoDodaj);
            this.groupBoxDodawanie.Controls.Add(this.textBoxImieDodaj);
            this.groupBoxDodawanie.Location = new System.Drawing.Point(12, 124);
            this.groupBoxDodawanie.Name = "groupBoxDodawanie";
            this.groupBoxDodawanie.Size = new System.Drawing.Size(226, 244);
            this.groupBoxDodawanie.TabIndex = 15;
            this.groupBoxDodawanie.TabStop = false;
            this.groupBoxDodawanie.Text = "Dodawanie:";
            // 
            // labelSzefDodaj
            // 
            this.labelSzefDodaj.AutoSize = true;
            this.labelSzefDodaj.Location = new System.Drawing.Point(15, 154);
            this.labelSzefDodaj.Name = "labelSzefDodaj";
            this.labelSzefDodaj.Size = new System.Drawing.Size(63, 13);
            this.labelSzefDodaj.TabIndex = 12;
            this.labelSzefDodaj.Text = "Przełożony:";
            // 
            // comboBoxSzefDodaj
            // 
            this.comboBoxSzefDodaj.FormattingEnabled = true;
            this.comboBoxSzefDodaj.Location = new System.Drawing.Point(84, 151);
            this.comboBoxSzefDodaj.Name = "comboBoxSzefDodaj";
            this.comboBoxSzefDodaj.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSzefDodaj.TabIndex = 11;
            // 
            // buttonDodajUzytkownika
            // 
            this.buttonDodajUzytkownika.Location = new System.Drawing.Point(129, 185);
            this.buttonDodajUzytkownika.Name = "buttonDodajUzytkownika";
            this.buttonDodajUzytkownika.Size = new System.Drawing.Size(76, 49);
            this.buttonDodajUzytkownika.TabIndex = 10;
            this.buttonDodajUzytkownika.Text = "Dodaj użytkownika";
            this.buttonDodajUzytkownika.UseVisualStyleBackColor = true;
            this.buttonDodajUzytkownika.Click += new System.EventHandler(this.ButtonDodajUzytkownika_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stanowisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Grupa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imię:";
            // 
            // textBoxStanowiskoDodaj
            // 
            this.textBoxStanowiskoDodaj.Location = new System.Drawing.Point(84, 72);
            this.textBoxStanowiskoDodaj.Name = "textBoxStanowiskoDodaj";
            this.textBoxStanowiskoDodaj.Size = new System.Drawing.Size(121, 20);
            this.textBoxStanowiskoDodaj.TabIndex = 3;
            // 
            // comboBoxGrupaDodaj
            // 
            this.comboBoxGrupaDodaj.FormattingEnabled = true;
            this.comboBoxGrupaDodaj.Location = new System.Drawing.Point(84, 98);
            this.comboBoxGrupaDodaj.Name = "comboBoxGrupaDodaj";
            this.comboBoxGrupaDodaj.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGrupaDodaj.TabIndex = 4;
            // 
            // textBoxEmailDodaj
            // 
            this.textBoxEmailDodaj.Location = new System.Drawing.Point(84, 125);
            this.textBoxEmailDodaj.Name = "textBoxEmailDodaj";
            this.textBoxEmailDodaj.Size = new System.Drawing.Size(121, 20);
            this.textBoxEmailDodaj.TabIndex = 2;
            // 
            // textBoxNazwiskoDodaj
            // 
            this.textBoxNazwiskoDodaj.Location = new System.Drawing.Point(84, 46);
            this.textBoxNazwiskoDodaj.Name = "textBoxNazwiskoDodaj";
            this.textBoxNazwiskoDodaj.Size = new System.Drawing.Size(121, 20);
            this.textBoxNazwiskoDodaj.TabIndex = 1;
            // 
            // textBoxImieDodaj
            // 
            this.textBoxImieDodaj.Location = new System.Drawing.Point(84, 20);
            this.textBoxImieDodaj.Name = "textBoxImieDodaj";
            this.textBoxImieDodaj.Size = new System.Drawing.Size(121, 20);
            this.textBoxImieDodaj.TabIndex = 0;
            // 
            // dataGridViewOdbicia
            // 
            this.dataGridViewOdbicia.AllowUserToAddRows = false;
            this.dataGridViewOdbicia.AllowUserToDeleteRows = false;
            this.dataGridViewOdbicia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOdbicia.Location = new System.Drawing.Point(9, 65);
            this.dataGridViewOdbicia.Name = "dataGridViewOdbicia";
            this.dataGridViewOdbicia.RowHeadersVisible = false;
            this.dataGridViewOdbicia.Size = new System.Drawing.Size(246, 169);
            this.dataGridViewOdbicia.TabIndex = 16;
            // 
            // groupBoxOdbicia
            // 
            this.groupBoxOdbicia.Controls.Add(this.buttonOdswiez);
            this.groupBoxOdbicia.Controls.Add(this.labelOdkiedy);
            this.groupBoxOdbicia.Controls.Add(this.labelDokiedy);
            this.groupBoxOdbicia.Controls.Add(this.dateTimePickerDatado);
            this.groupBoxOdbicia.Controls.Add(this.dateTimePickerDataod);
            this.groupBoxOdbicia.Controls.Add(this.dataGridViewOdbicia);
            this.groupBoxOdbicia.Location = new System.Drawing.Point(532, 124);
            this.groupBoxOdbicia.Name = "groupBoxOdbicia";
            this.groupBoxOdbicia.Size = new System.Drawing.Size(265, 244);
            this.groupBoxOdbicia.TabIndex = 17;
            this.groupBoxOdbicia.TabStop = false;
            this.groupBoxOdbicia.Text = "Odbicia";
            // 
            // buttonOdswiez
            // 
            this.buttonOdswiez.Location = new System.Drawing.Point(180, 11);
            this.buttonOdswiez.Name = "buttonOdswiez";
            this.buttonOdswiez.Size = new System.Drawing.Size(75, 23);
            this.buttonOdswiez.TabIndex = 21;
            this.buttonOdswiez.Text = "Odśwież";
            this.buttonOdswiez.UseVisualStyleBackColor = true;
            this.buttonOdswiez.Click += new System.EventHandler(this.buttonOdswiez_Click);
            // 
            // labelOdkiedy
            // 
            this.labelOdkiedy.AutoSize = true;
            this.labelOdkiedy.Location = new System.Drawing.Point(6, 16);
            this.labelOdkiedy.Name = "labelOdkiedy";
            this.labelOdkiedy.Size = new System.Drawing.Size(103, 13);
            this.labelOdkiedy.TabIndex = 20;
            this.labelOdkiedy.Text = "Sprawdź odbicia od:";
            // 
            // labelDokiedy
            // 
            this.labelDokiedy.AutoSize = true;
            this.labelDokiedy.Location = new System.Drawing.Point(132, 16);
            this.labelDokiedy.Name = "labelDokiedy";
            this.labelDokiedy.Size = new System.Drawing.Size(22, 13);
            this.labelDokiedy.TabIndex = 19;
            this.labelDokiedy.Text = "do:";
            // 
            // dateTimePickerDatado
            // 
            this.dateTimePickerDatado.Location = new System.Drawing.Point(135, 36);
            this.dateTimePickerDatado.Name = "dateTimePickerDatado";
            this.dateTimePickerDatado.Size = new System.Drawing.Size(120, 20);
            this.dateTimePickerDatado.TabIndex = 18;
            // 
            // dateTimePickerDataod
            // 
            this.dateTimePickerDataod.Location = new System.Drawing.Point(9, 36);
            this.dateTimePickerDataod.Name = "dateTimePickerDataod";
            this.dateTimePickerDataod.Size = new System.Drawing.Size(120, 20);
            this.dateTimePickerDataod.TabIndex = 17;
            // 
            // FormUzytkownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 377);
            this.Controls.Add(this.groupBoxOdbicia);
            this.Controls.Add(this.groupBoxDodawanie);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.groupBoxEdycja);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormUzytkownicy";
            this.Text = "Użytkownicy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUzytkownicy_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxEdycja.ResumeLayout(false);
            this.groupBoxEdycja.PerformLayout();
            this.groupBoxDodawanie.ResumeLayout(false);
            this.groupBoxDodawanie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbicia)).EndInit();
            this.groupBoxOdbicia.ResumeLayout(false);
            this.groupBoxOdbicia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEdytuj;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelImie;
        private System.Windows.Forms.Label labelNazwisko;
        private System.Windows.Forms.Label labelStanowisko;
        private System.Windows.Forms.Label labelGrupa;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxStanowisko;
        private System.Windows.Forms.ComboBox comboBoxGrupy;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.GroupBox groupBoxEdycja;
        private System.Windows.Forms.Button buttonResetHasla;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Button buttonWyloguj;
        private System.Windows.Forms.Button buttonPowrot;
        private System.Windows.Forms.GroupBox groupBoxDodawanie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGrupaDodaj;
        private System.Windows.Forms.TextBox textBoxStanowiskoDodaj;
        private System.Windows.Forms.TextBox textBoxEmailDodaj;
        private System.Windows.Forms.TextBox textBoxNazwiskoDodaj;
        private System.Windows.Forms.TextBox textBoxImieDodaj;
        private System.Windows.Forms.Button buttonDodajUzytkownika;
        private System.Windows.Forms.DataGridView dataGridViewOdbicia;
        private System.Windows.Forms.GroupBox groupBoxOdbicia;
        private System.Windows.Forms.Button buttonOdswiez;
        private System.Windows.Forms.Label labelOdkiedy;
        private System.Windows.Forms.Label labelDokiedy;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatado;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataod;
        private System.Windows.Forms.Label labelSzef;
        private System.Windows.Forms.ComboBox comboBoxSzef;
        private System.Windows.Forms.Label labelSzefDodaj;
        private System.Windows.Forms.ComboBox comboBoxSzefDodaj;
    }
}