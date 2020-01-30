namespace Inzynierka
{
    partial class Wnioski
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
            this.components = new System.ComponentModel.Container();
            this.labelUzytkownik = new System.Windows.Forms.Label();
            this.dataGridViewWnioski = new System.Windows.Forms.DataGridView();
            this.groupBoxRoboczy = new System.Windows.Forms.GroupBox();
            this.panelZatwierdz = new System.Windows.Forms.Panel();
            this.buttonZatwierdz = new System.Windows.Forms.Button();
            this.buttonOdrzuc = new System.Windows.Forms.Button();
            this.panelNowy = new System.Windows.Forms.Panel();
            this.buttonZmien = new System.Windows.Forms.Button();
            this.buttonWyslij = new System.Windows.Forms.Button();
            this.buttonNowy = new System.Windows.Forms.Button();
            this.textBoxOdpowiedz = new System.Windows.Forms.TextBox();
            this.labelTypWniosku = new System.Windows.Forms.Label();
            this.comboBoxTyp = new System.Windows.Forms.ComboBox();
            this.panelCzasWolny = new System.Windows.Forms.Panel();
            this.labelUzasadnienie = new System.Windows.Forms.Label();
            this.labelOpisDataDo = new System.Windows.Forms.Label();
            this.labelOpisDataOd = new System.Windows.Forms.Label();
            this.dateTimePickerDataOd = new System.Windows.Forms.DateTimePicker();
            this.textBoxOpisEdit = new System.Windows.Forms.TextBox();
            this.dateTimePickerDataDo = new System.Windows.Forms.DateTimePicker();
            this.panelDane = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.labelZatwierdzajacy = new System.Windows.Forms.Label();
            this.labelDataZatwierdzenia = new System.Windows.Forms.Label();
            this.labelOpisZatwierdzenie = new System.Windows.Forms.Label();
            this.labelOpisData = new System.Windows.Forms.Label();
            this.labelDataWyst = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.comboBoxUzytkownik = new System.Windows.Forms.ComboBox();
            this.panelError = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.wniosekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).BeginInit();
            this.groupBoxRoboczy.SuspendLayout();
            this.panelZatwierdz.SuspendLayout();
            this.panelNowy.SuspendLayout();
            this.panelCzasWolny.SuspendLayout();
            this.panelDane.SuspendLayout();
            this.panelError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wniosekBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUzytkownik
            // 
            this.labelUzytkownik.AutoSize = true;
            this.labelUzytkownik.Location = new System.Drawing.Point(23, 25);
            this.labelUzytkownik.Name = "labelUzytkownik";
            this.labelUzytkownik.Size = new System.Drawing.Size(144, 13);
            this.labelUzytkownik.TabIndex = 0;
            this.labelUzytkownik.Text = "Imie i Nazwisko Uzytkownika";
            // 
            // dataGridViewWnioski
            // 
            this.dataGridViewWnioski.AllowUserToAddRows = false;
            this.dataGridViewWnioski.AllowUserToDeleteRows = false;
            this.dataGridViewWnioski.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWnioski.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewWnioski.Location = new System.Drawing.Point(357, 39);
            this.dataGridViewWnioski.Name = "dataGridViewWnioski";
            this.dataGridViewWnioski.RowHeadersVisible = false;
            this.dataGridViewWnioski.Size = new System.Drawing.Size(334, 393);
            this.dataGridViewWnioski.TabIndex = 1;
            this.dataGridViewWnioski.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWnioski_CellContentClick);
            // 
            // groupBoxRoboczy
            // 
            this.groupBoxRoboczy.Controls.Add(this.panelZatwierdz);
            this.groupBoxRoboczy.Controls.Add(this.panelNowy);
            this.groupBoxRoboczy.Controls.Add(this.textBoxOdpowiedz);
            this.groupBoxRoboczy.Controls.Add(this.labelTypWniosku);
            this.groupBoxRoboczy.Controls.Add(this.comboBoxTyp);
            this.groupBoxRoboczy.Controls.Add(this.panelCzasWolny);
            this.groupBoxRoboczy.Controls.Add(this.panelDane);
            this.groupBoxRoboczy.Controls.Add(this.buttonUsun);
            this.groupBoxRoboczy.Controls.Add(this.labelZatwierdzajacy);
            this.groupBoxRoboczy.Controls.Add(this.labelDataZatwierdzenia);
            this.groupBoxRoboczy.Controls.Add(this.labelOpisZatwierdzenie);
            this.groupBoxRoboczy.Controls.Add(this.labelOpisData);
            this.groupBoxRoboczy.Controls.Add(this.labelDataWyst);
            this.groupBoxRoboczy.Controls.Add(this.labelId);
            this.groupBoxRoboczy.Controls.Add(this.labelStatus);
            this.groupBoxRoboczy.Location = new System.Drawing.Point(12, 54);
            this.groupBoxRoboczy.Name = "groupBoxRoboczy";
            this.groupBoxRoboczy.Size = new System.Drawing.Size(327, 378);
            this.groupBoxRoboczy.TabIndex = 2;
            this.groupBoxRoboczy.TabStop = false;
            this.groupBoxRoboczy.Text = "Wniosek";
            // 
            // panelZatwierdz
            // 
            this.panelZatwierdz.Controls.Add(this.buttonZatwierdz);
            this.panelZatwierdz.Controls.Add(this.buttonOdrzuc);
            this.panelZatwierdz.Location = new System.Drawing.Point(94, 344);
            this.panelZatwierdz.Name = "panelZatwierdz";
            this.panelZatwierdz.Size = new System.Drawing.Size(214, 23);
            this.panelZatwierdz.TabIndex = 6;
            // 
            // buttonZatwierdz
            // 
            this.buttonZatwierdz.Location = new System.Drawing.Point(28, 0);
            this.buttonZatwierdz.Name = "buttonZatwierdz";
            this.buttonZatwierdz.Size = new System.Drawing.Size(90, 23);
            this.buttonZatwierdz.TabIndex = 10;
            this.buttonZatwierdz.Text = "Zatwierdź";
            this.buttonZatwierdz.UseVisualStyleBackColor = true;
            this.buttonZatwierdz.Click += new System.EventHandler(this.buttonZatwierdz_Click);
            // 
            // buttonOdrzuc
            // 
            this.buttonOdrzuc.Location = new System.Drawing.Point(124, 0);
            this.buttonOdrzuc.Name = "buttonOdrzuc";
            this.buttonOdrzuc.Size = new System.Drawing.Size(90, 23);
            this.buttonOdrzuc.TabIndex = 11;
            this.buttonOdrzuc.Text = "Odrzuć";
            this.buttonOdrzuc.UseVisualStyleBackColor = true;
            this.buttonOdrzuc.Click += new System.EventHandler(this.buttonOdrzuc_Click);
            // 
            // panelNowy
            // 
            this.panelNowy.Controls.Add(this.buttonZmien);
            this.panelNowy.Controls.Add(this.buttonWyslij);
            this.panelNowy.Controls.Add(this.buttonNowy);
            this.panelNowy.Location = new System.Drawing.Point(42, 312);
            this.panelNowy.Name = "panelNowy";
            this.panelNowy.Size = new System.Drawing.Size(202, 31);
            this.panelNowy.TabIndex = 13;
            // 
            // buttonZmien
            // 
            this.buttonZmien.Location = new System.Drawing.Point(131, 3);
            this.buttonZmien.Name = "buttonZmien";
            this.buttonZmien.Size = new System.Drawing.Size(58, 23);
            this.buttonZmien.TabIndex = 7;
            this.buttonZmien.Text = "Zmień";
            this.buttonZmien.UseVisualStyleBackColor = true;
            this.buttonZmien.Click += new System.EventHandler(this.buttonZmien_Click);
            // 
            // buttonWyslij
            // 
            this.buttonWyslij.Location = new System.Drawing.Point(67, 3);
            this.buttonWyslij.Name = "buttonWyslij";
            this.buttonWyslij.Size = new System.Drawing.Size(58, 23);
            this.buttonWyslij.TabIndex = 7;
            this.buttonWyslij.Text = "Wyślij";
            this.buttonWyslij.UseVisualStyleBackColor = true;
            this.buttonWyslij.Click += new System.EventHandler(this.buttonWyslij_Click);
            // 
            // buttonNowy
            // 
            this.buttonNowy.Location = new System.Drawing.Point(3, 3);
            this.buttonNowy.Name = "buttonNowy";
            this.buttonNowy.Size = new System.Drawing.Size(58, 23);
            this.buttonNowy.TabIndex = 8;
            this.buttonNowy.Text = "Nowy";
            this.buttonNowy.UseVisualStyleBackColor = true;
            this.buttonNowy.Click += new System.EventHandler(this.buttonNowy_Click);
            // 
            // textBoxOdpowiedz
            // 
            this.textBoxOdpowiedz.Location = new System.Drawing.Point(6, 254);
            this.textBoxOdpowiedz.Multiline = true;
            this.textBoxOdpowiedz.Name = "textBoxOdpowiedz";
            this.textBoxOdpowiedz.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOdpowiedz.Size = new System.Drawing.Size(301, 45);
            this.textBoxOdpowiedz.TabIndex = 8;
            // 
            // labelTypWniosku
            // 
            this.labelTypWniosku.AutoSize = true;
            this.labelTypWniosku.Location = new System.Drawing.Point(10, 23);
            this.labelTypWniosku.Name = "labelTypWniosku";
            this.labelTypWniosku.Size = new System.Drawing.Size(67, 13);
            this.labelTypWniosku.TabIndex = 5;
            this.labelTypWniosku.Text = "Typ wniosku";
            // 
            // comboBoxTyp
            // 
            this.comboBoxTyp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTyp.FormattingEnabled = true;
            this.comboBoxTyp.Items.AddRange(new object[] {
            "NOWY",
            "DANE",
            "URLOP",
            "WOLNE",
            "NADGODZINY",
            "WYJSCIESLUZBOWE"});
            this.comboBoxTyp.Location = new System.Drawing.Point(7, 20);
            this.comboBoxTyp.Name = "comboBoxTyp";
            this.comboBoxTyp.Size = new System.Drawing.Size(192, 21);
            this.comboBoxTyp.TabIndex = 5;
            this.comboBoxTyp.SelectedIndexChanged += new System.EventHandler(this.comboBoxTyp_SelectedIndexChanged);
            // 
            // panelCzasWolny
            // 
            this.panelCzasWolny.Controls.Add(this.labelUzasadnienie);
            this.panelCzasWolny.Controls.Add(this.labelOpisDataDo);
            this.panelCzasWolny.Controls.Add(this.labelOpisDataOd);
            this.panelCzasWolny.Controls.Add(this.dateTimePickerDataOd);
            this.panelCzasWolny.Controls.Add(this.textBoxOpisEdit);
            this.panelCzasWolny.Controls.Add(this.dateTimePickerDataDo);
            this.panelCzasWolny.Location = new System.Drawing.Point(6, 74);
            this.panelCzasWolny.Name = "panelCzasWolny";
            this.panelCzasWolny.Size = new System.Drawing.Size(312, 143);
            this.panelCzasWolny.TabIndex = 5;
            // 
            // labelUzasadnienie
            // 
            this.labelUzasadnienie.AutoSize = true;
            this.labelUzasadnienie.Location = new System.Drawing.Point(5, 43);
            this.labelUzasadnienie.Name = "labelUzasadnienie";
            this.labelUzasadnienie.Size = new System.Drawing.Size(71, 13);
            this.labelUzasadnienie.TabIndex = 7;
            this.labelUzasadnienie.Text = "Uzasadnienie";
            // 
            // labelOpisDataDo
            // 
            this.labelOpisDataDo.AutoSize = true;
            this.labelOpisDataDo.Location = new System.Drawing.Point(161, 0);
            this.labelOpisDataDo.Name = "labelOpisDataDo";
            this.labelOpisDataDo.Size = new System.Drawing.Size(45, 13);
            this.labelOpisDataDo.TabIndex = 5;
            this.labelOpisDataDo.Text = "Czas do";
            // 
            // labelOpisDataOd
            // 
            this.labelOpisDataOd.AutoSize = true;
            this.labelOpisDataOd.Location = new System.Drawing.Point(5, 0);
            this.labelOpisDataOd.Name = "labelOpisDataOd";
            this.labelOpisDataOd.Size = new System.Drawing.Size(45, 13);
            this.labelOpisDataOd.TabIndex = 5;
            this.labelOpisDataOd.Text = "Czas od";
            // 
            // dateTimePickerDataOd
            // 
            this.dateTimePickerDataOd.Location = new System.Drawing.Point(2, 16);
            this.dateTimePickerDataOd.Name = "dateTimePickerDataOd";
            this.dateTimePickerDataOd.Size = new System.Drawing.Size(147, 20);
            this.dateTimePickerDataOd.TabIndex = 6;
            // 
            // textBoxOpisEdit
            // 
            this.textBoxOpisEdit.Location = new System.Drawing.Point(1, 59);
            this.textBoxOpisEdit.Multiline = true;
            this.textBoxOpisEdit.Name = "textBoxOpisEdit";
            this.textBoxOpisEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOpisEdit.Size = new System.Drawing.Size(301, 71);
            this.textBoxOpisEdit.TabIndex = 6;
            // 
            // dateTimePickerDataDo
            // 
            this.dateTimePickerDataDo.Location = new System.Drawing.Point(158, 16);
            this.dateTimePickerDataDo.Name = "dateTimePickerDataDo";
            this.dateTimePickerDataDo.Size = new System.Drawing.Size(144, 20);
            this.dateTimePickerDataDo.TabIndex = 6;
            // 
            // panelDane
            // 
            this.panelDane.Controls.Add(this.label4);
            this.panelDane.Controls.Add(this.label3);
            this.panelDane.Controls.Add(this.textBoxEmail);
            this.panelDane.Controls.Add(this.textBoxNazwisko);
            this.panelDane.Controls.Add(this.label1);
            this.panelDane.Controls.Add(this.textBoxImie);
            this.panelDane.Location = new System.Drawing.Point(6, 74);
            this.panelDane.Name = "panelDane";
            this.panelDane.Size = new System.Drawing.Size(312, 143);
            this.panelDane.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nazwisko";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(5, 104);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(294, 20);
            this.textBoxEmail.TabIndex = 8;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(5, 65);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(294, 20);
            this.textBoxNazwisko.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imię";
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(5, 26);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(294, 20);
            this.textBoxImie.TabIndex = 6;
            // 
            // buttonUsun
            // 
            this.buttonUsun.Location = new System.Drawing.Point(250, 315);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(58, 23);
            this.buttonUsun.TabIndex = 7;
            this.buttonUsun.Text = "Usuń";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // labelZatwierdzajacy
            // 
            this.labelZatwierdzajacy.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.labelZatwierdzajacy.AutoSize = true;
            this.labelZatwierdzajacy.Location = new System.Drawing.Point(166, 238);
            this.labelZatwierdzajacy.Name = "labelZatwierdzajacy";
            this.labelZatwierdzajacy.Size = new System.Drawing.Size(76, 13);
            this.labelZatwierdzajacy.TabIndex = 4;
            this.labelZatwierdzajacy.Text = "Kto zatwierdził";
            // 
            // labelDataZatwierdzenia
            // 
            this.labelDataZatwierdzenia.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.labelDataZatwierdzenia.AutoSize = true;
            this.labelDataZatwierdzenia.Location = new System.Drawing.Point(10, 238);
            this.labelDataZatwierdzenia.Name = "labelDataZatwierdzenia";
            this.labelDataZatwierdzenia.Size = new System.Drawing.Size(30, 13);
            this.labelDataZatwierdzenia.TabIndex = 4;
            this.labelDataZatwierdzenia.Text = "Data";
            // 
            // labelOpisZatwierdzenie
            // 
            this.labelOpisZatwierdzenie.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.labelOpisZatwierdzenie.AutoSize = true;
            this.labelOpisZatwierdzenie.Location = new System.Drawing.Point(10, 220);
            this.labelOpisZatwierdzenie.Name = "labelOpisZatwierdzenie";
            this.labelOpisZatwierdzenie.Size = new System.Drawing.Size(79, 13);
            this.labelOpisZatwierdzenie.TabIndex = 4;
            this.labelOpisZatwierdzenie.Text = "Zatwierdzenie: ";
            // 
            // labelOpisData
            // 
            this.labelOpisData.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.labelOpisData.AutoSize = true;
            this.labelOpisData.Location = new System.Drawing.Point(10, 54);
            this.labelOpisData.Name = "labelOpisData";
            this.labelOpisData.Size = new System.Drawing.Size(75, 13);
            this.labelOpisData.TabIndex = 4;
            this.labelOpisData.Text = "Sporządzono: ";
            // 
            // labelDataWyst
            // 
            this.labelDataWyst.AutoSize = true;
            this.labelDataWyst.Location = new System.Drawing.Point(91, 54);
            this.labelDataWyst.Name = "labelDataWyst";
            this.labelDataWyst.Size = new System.Drawing.Size(90, 13);
            this.labelDataWyst.TabIndex = 3;
            this.labelDataWyst.Text = "Data wystawienia";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(8, 330);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "Id";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(205, 23);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Status";
            // 
            // labelError
            // 
            this.labelError.AutoEllipsis = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(13, 25);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(311, 99);
            this.labelError.TabIndex = 9;
            this.labelError.Text = "Info";
            this.labelError.TextChanged += new System.EventHandler(this.labelError_TextChanged);
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.Location = new System.Drawing.Point(275, 10);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(75, 23);
            this.buttonPowrot.TabIndex = 3;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = true;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.Location = new System.Drawing.Point(616, 10);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(75, 23);
            this.buttonWyloguj.TabIndex = 4;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = true;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // comboBoxUzytkownik
            // 
            this.comboBoxUzytkownik.FormattingEnabled = true;
            this.comboBoxUzytkownik.Location = new System.Drawing.Point(18, 22);
            this.comboBoxUzytkownik.Name = "comboBoxUzytkownik";
            this.comboBoxUzytkownik.Size = new System.Drawing.Size(193, 21);
            this.comboBoxUzytkownik.TabIndex = 5;
            this.comboBoxUzytkownik.SelectedIndexChanged += new System.EventHandler(this.comboBoxUzytkownik_SelectedIndexChanged);
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.label2);
            this.panelError.Controls.Add(this.labelError);
            this.panelError.Location = new System.Drawing.Point(357, 308);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(334, 124);
            this.panelError.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Błąd:";
            // 
            // wniosekBindingSource
            // 
            this.wniosekBindingSource.DataSource = typeof(Inzynierka.Wniosek);
            // 
            // Wnioski
            // 
            this.AccessibleName = "FormWnioski";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 444);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.comboBoxUzytkownik);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.groupBoxRoboczy);
            this.Controls.Add(this.labelUzytkownik);
            this.Controls.Add(this.dataGridViewWnioski);
            this.Name = "Wnioski";
            this.Text = "Wnioski";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Wnioski_FormClosed);
            this.Load += new System.EventHandler(this.FormWnioski_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).EndInit();
            this.groupBoxRoboczy.ResumeLayout(false);
            this.groupBoxRoboczy.PerformLayout();
            this.panelZatwierdz.ResumeLayout(false);
            this.panelNowy.ResumeLayout(false);
            this.panelCzasWolny.ResumeLayout(false);
            this.panelCzasWolny.PerformLayout();
            this.panelDane.ResumeLayout(false);
            this.panelDane.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wniosekBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUzytkownik;
        private System.Windows.Forms.DataGridView dataGridViewWnioski;
        private System.Windows.Forms.GroupBox groupBoxRoboczy;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Button buttonZmien;
        private System.Windows.Forms.Button buttonWyslij;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataDo;
        private System.Windows.Forms.TextBox textBoxOpisEdit;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataOd;
        private System.Windows.Forms.Label labelOpisDataDo;
        private System.Windows.Forms.Label labelOpisDataOd;
        private System.Windows.Forms.Label labelZatwierdzajacy;
        private System.Windows.Forms.Label labelDataZatwierdzenia;
        private System.Windows.Forms.Label labelOpisZatwierdzenie;
        private System.Windows.Forms.Label labelOpisData;
        private System.Windows.Forms.Label labelDataWyst;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonPowrot;
        private System.Windows.Forms.Button buttonWyloguj;
        private System.Windows.Forms.Button buttonNowy;
        private System.Windows.Forms.Panel panelCzasWolny;
        private System.Windows.Forms.BindingSource wniosekBindingSource;
        private System.Windows.Forms.ComboBox comboBoxTyp;
        private System.Windows.Forms.Label labelTypWniosku;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelUzasadnienie;
        private System.Windows.Forms.TextBox textBoxOdpowiedz;
        private System.Windows.Forms.Button buttonOdrzuc;
        private System.Windows.Forms.Button buttonZatwierdz;
        private System.Windows.Forms.ComboBox comboBoxUzytkownik;
        private System.Windows.Forms.Panel panelDane;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.Panel panelZatwierdz;
        private System.Windows.Forms.Panel panelNowy;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label label2;
    }
}