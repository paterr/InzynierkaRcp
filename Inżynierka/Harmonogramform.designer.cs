namespace Inzynierka
{
    partial class Form3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDzienWolny = new System.Windows.Forms.Button();
            this.groupBoxDniWolne = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOpisDniaWolnego = new System.Windows.Forms.TextBox();
            this.buttonDodajDzienWolny = new System.Windows.Forms.Button();
            this.dateTimePickerDniWolne = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonKolejny = new System.Windows.Forms.Button();
            this.buttonPoprzedni = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxZmiany = new System.Windows.Forms.GroupBox();
            this.labelZN3 = new System.Windows.Forms.Label();
            this.labelZN2 = new System.Windows.Forms.Label();
            this.labelZN1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.maskedTextBoxZ32 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxZ12 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxZ22 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxZ31 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxZ21 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Z11 = new System.Windows.Forms.MaskedTextBox();
            this.buttonUstal = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxUzytkownik = new System.Windows.Forms.ComboBox();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.dataGridViewOdbicianaDzien = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxUzytkownicyharmonogram = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonKolor1 = new System.Windows.Forms.Button();
            this.buttonKolor2 = new System.Windows.Forms.Button();
            this.buttonKolor3 = new System.Windows.Forms.Button();
            this.buttonKolor4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxGodzinyharmonogram = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxGodzinyUrlopu = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxGodzinyOK = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxDniWolne.SuspendLayout();
            this.groupBoxZmiany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbicianaDzien)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(286, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(484, 518);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // buttonDzienWolny
            // 
            this.buttonDzienWolny.Location = new System.Drawing.Point(22, 280);
            this.buttonDzienWolny.Name = "buttonDzienWolny";
            this.buttonDzienWolny.Size = new System.Drawing.Size(183, 32);
            this.buttonDzienWolny.TabIndex = 1;
            this.buttonDzienWolny.Text = "Dodaj dzień wolny";
            this.buttonDzienWolny.UseVisualStyleBackColor = true;
            this.buttonDzienWolny.Click += new System.EventHandler(this.ButtonDzienWolny_Click);
            // 
            // groupBoxDniWolne
            // 
            this.groupBoxDniWolne.Controls.Add(this.label2);
            this.groupBoxDniWolne.Controls.Add(this.label1);
            this.groupBoxDniWolne.Controls.Add(this.textBoxOpisDniaWolnego);
            this.groupBoxDniWolne.Controls.Add(this.buttonDodajDzienWolny);
            this.groupBoxDniWolne.Controls.Add(this.dateTimePickerDniWolne);
            this.groupBoxDniWolne.Location = new System.Drawing.Point(0, 43);
            this.groupBoxDniWolne.Name = "groupBoxDniWolne";
            this.groupBoxDniWolne.Size = new System.Drawing.Size(240, 198);
            this.groupBoxDniWolne.TabIndex = 2;
            this.groupBoxDniWolne.TabStop = false;
            this.groupBoxDniWolne.Text = "Ustal dzień wolny:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opis:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dzień wolny:";
            // 
            // textBoxOpisDniaWolnego
            // 
            this.textBoxOpisDniaWolnego.Location = new System.Drawing.Point(9, 127);
            this.textBoxOpisDniaWolnego.Name = "textBoxOpisDniaWolnego";
            this.textBoxOpisDniaWolnego.Size = new System.Drawing.Size(197, 20);
            this.textBoxOpisDniaWolnego.TabIndex = 2;
            // 
            // buttonDodajDzienWolny
            // 
            this.buttonDodajDzienWolny.Location = new System.Drawing.Point(131, 165);
            this.buttonDodajDzienWolny.Name = "buttonDodajDzienWolny";
            this.buttonDodajDzienWolny.Size = new System.Drawing.Size(75, 23);
            this.buttonDodajDzienWolny.TabIndex = 1;
            this.buttonDodajDzienWolny.Text = "Dodaj";
            this.buttonDodajDzienWolny.UseVisualStyleBackColor = true;
            this.buttonDodajDzienWolny.Click += new System.EventHandler(this.ButtonDodajDzienWolny_Click);
            // 
            // dateTimePickerDniWolne
            // 
            this.dateTimePickerDniWolne.Location = new System.Drawing.Point(9, 66);
            this.dateTimePickerDniWolne.Name = "dateTimePickerDniWolne";
            this.dateTimePickerDniWolne.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerDniWolne.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // buttonKolejny
            // 
            this.buttonKolejny.Location = new System.Drawing.Point(493, 11);
            this.buttonKolejny.Name = "buttonKolejny";
            this.buttonKolejny.Size = new System.Drawing.Size(67, 23);
            this.buttonKolejny.TabIndex = 4;
            this.buttonKolejny.Text = "kolejny miesiąc";
            this.buttonKolejny.UseVisualStyleBackColor = true;
            this.buttonKolejny.Click += new System.EventHandler(this.ButtonKolejny_Click);
            // 
            // buttonPoprzedni
            // 
            this.buttonPoprzedni.Location = new System.Drawing.Point(286, 11);
            this.buttonPoprzedni.Name = "buttonPoprzedni";
            this.buttonPoprzedni.Size = new System.Drawing.Size(67, 23);
            this.buttonPoprzedni.TabIndex = 5;
            this.buttonPoprzedni.Text = "poprzedni";
            this.buttonPoprzedni.UseVisualStyleBackColor = true;
            this.buttonPoprzedni.Click += new System.EventHandler(this.ButtonPoprzedni_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DNI OK";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(658, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "DNI WOLNE";
            // 
            // groupBoxZmiany
            // 
            this.groupBoxZmiany.Controls.Add(this.labelZN3);
            this.groupBoxZmiany.Controls.Add(this.labelZN2);
            this.groupBoxZmiany.Controls.Add(this.groupBoxDniWolne);
            this.groupBoxZmiany.Controls.Add(this.labelZN1);
            this.groupBoxZmiany.Controls.Add(this.label16);
            this.groupBoxZmiany.Controls.Add(this.label15);
            this.groupBoxZmiany.Controls.Add(this.maskedTextBoxZ32);
            this.groupBoxZmiany.Controls.Add(this.maskedTextBoxZ12);
            this.groupBoxZmiany.Controls.Add(this.maskedTextBoxZ22);
            this.groupBoxZmiany.Controls.Add(this.maskedTextBoxZ31);
            this.groupBoxZmiany.Controls.Add(this.maskedTextBoxZ21);
            this.groupBoxZmiany.Controls.Add(this.maskedTextBox_Z11);
            this.groupBoxZmiany.Controls.Add(this.buttonUstal);
            this.groupBoxZmiany.Controls.Add(this.dateTimePicker2);
            this.groupBoxZmiany.Controls.Add(this.dateTimePicker1);
            this.groupBoxZmiany.Controls.Add(this.label9);
            this.groupBoxZmiany.Controls.Add(this.label8);
            this.groupBoxZmiany.Controls.Add(this.label7);
            this.groupBoxZmiany.Controls.Add(this.label6);
            this.groupBoxZmiany.Controls.Add(this.comboBoxUzytkownik);
            this.groupBoxZmiany.Location = new System.Drawing.Point(22, 318);
            this.groupBoxZmiany.Name = "groupBoxZmiany";
            this.groupBoxZmiany.Size = new System.Drawing.Size(240, 241);
            this.groupBoxZmiany.TabIndex = 8;
            this.groupBoxZmiany.TabStop = false;
            this.groupBoxZmiany.Text = "Ustal harmonogram dla:";
            // 
            // labelZN3
            // 
            this.labelZN3.AutoSize = true;
            this.labelZN3.Location = new System.Drawing.Point(165, 119);
            this.labelZN3.Name = "labelZN3";
            this.labelZN3.Size = new System.Drawing.Size(41, 13);
            this.labelZN3.TabIndex = 24;
            this.labelZN3.Text = "label19";
            // 
            // labelZN2
            // 
            this.labelZN2.AutoSize = true;
            this.labelZN2.Location = new System.Drawing.Point(165, 88);
            this.labelZN2.Name = "labelZN2";
            this.labelZN2.Size = new System.Drawing.Size(41, 13);
            this.labelZN2.TabIndex = 23;
            this.labelZN2.Text = "label18";
            // 
            // labelZN1
            // 
            this.labelZN1.AutoSize = true;
            this.labelZN1.Location = new System.Drawing.Point(165, 62);
            this.labelZN1.Name = "labelZN1";
            this.labelZN1.Size = new System.Drawing.Size(41, 13);
            this.labelZN1.TabIndex = 22;
            this.labelZN1.Text = "label17";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(118, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "do:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(67, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "od:";
            // 
            // maskedTextBoxZ32
            // 
            this.maskedTextBoxZ32.Location = new System.Drawing.Point(121, 112);
            this.maskedTextBoxZ32.Mask = "00:00";
            this.maskedTextBoxZ32.Name = "maskedTextBoxZ32";
            this.maskedTextBoxZ32.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxZ32.TabIndex = 19;
            this.maskedTextBoxZ32.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxZ32.TextChanged += new System.EventHandler(this.MaskedTextBoxZ32_TextChanged);
            // 
            // maskedTextBoxZ12
            // 
            this.maskedTextBoxZ12.Location = new System.Drawing.Point(121, 59);
            this.maskedTextBoxZ12.Mask = "00:00";
            this.maskedTextBoxZ12.Name = "maskedTextBoxZ12";
            this.maskedTextBoxZ12.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxZ12.TabIndex = 18;
            this.maskedTextBoxZ12.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxZ12.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.maskedTextBoxZ12_TypeValidationCompleted);
            this.maskedTextBoxZ12.TextChanged += new System.EventHandler(this.MaskedTextBoxZ12_TextChanged);
            // 
            // maskedTextBoxZ22
            // 
            this.maskedTextBoxZ22.Location = new System.Drawing.Point(121, 85);
            this.maskedTextBoxZ22.Mask = "00:00";
            this.maskedTextBoxZ22.Name = "maskedTextBoxZ22";
            this.maskedTextBoxZ22.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxZ22.TabIndex = 17;
            this.maskedTextBoxZ22.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxZ22.TextChanged += new System.EventHandler(this.MaskedTextBoxZ22_TextChanged);
            // 
            // maskedTextBoxZ31
            // 
            this.maskedTextBoxZ31.Location = new System.Drawing.Point(70, 112);
            this.maskedTextBoxZ31.Mask = "00:00";
            this.maskedTextBoxZ31.Name = "maskedTextBoxZ31";
            this.maskedTextBoxZ31.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxZ31.TabIndex = 16;
            this.maskedTextBoxZ31.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxZ31.TextChanged += new System.EventHandler(this.MaskedTextBoxZ31_TextChanged);
            // 
            // maskedTextBoxZ21
            // 
            this.maskedTextBoxZ21.Location = new System.Drawing.Point(70, 85);
            this.maskedTextBoxZ21.Mask = "00:00";
            this.maskedTextBoxZ21.Name = "maskedTextBoxZ21";
            this.maskedTextBoxZ21.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBoxZ21.TabIndex = 15;
            this.maskedTextBoxZ21.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxZ21.TextChanged += new System.EventHandler(this.MaskedTextBoxZ21_TextChanged);
            // 
            // maskedTextBox_Z11
            // 
            this.maskedTextBox_Z11.Location = new System.Drawing.Point(70, 59);
            this.maskedTextBox_Z11.Mask = "00:00";
            this.maskedTextBox_Z11.Name = "maskedTextBox_Z11";
            this.maskedTextBox_Z11.Size = new System.Drawing.Size(37, 20);
            this.maskedTextBox_Z11.TabIndex = 14;
            this.maskedTextBox_Z11.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_Z11.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.maskedTextBox_Z11_TypeValidationCompleted);
            this.maskedTextBox_Z11.TextChanged += new System.EventHandler(this.MaskedTextBox_Z11_TextChanged);
            // 
            // buttonUstal
            // 
            this.buttonUstal.Location = new System.Drawing.Point(168, 212);
            this.buttonUstal.Name = "buttonUstal";
            this.buttonUstal.Size = new System.Drawing.Size(47, 23);
            this.buttonUstal.TabIndex = 13;
            this.buttonUstal.Text = "Ustal";
            this.buttonUstal.UseVisualStyleBackColor = true;
            this.buttonUstal.Click += new System.EventHandler(this.ButtonUstal_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(6, 186);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 147);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "do";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Zmiana 3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Zmiana 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Zmiana 1:";
            // 
            // comboBoxUzytkownik
            // 
            this.comboBoxUzytkownik.FormattingEnabled = true;
            this.comboBoxUzytkownik.Location = new System.Drawing.Point(9, 19);
            this.comboBoxUzytkownik.Name = "comboBoxUzytkownik";
            this.comboBoxUzytkownik.Size = new System.Drawing.Size(197, 21);
            this.comboBoxUzytkownik.TabIndex = 6;
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.Location = new System.Drawing.Point(190, 11);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(75, 23);
            this.buttonPowrot.TabIndex = 9;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = true;
            this.buttonPowrot.Click += new System.EventHandler(this.ButtonPowrot_Click);
            // 
            // dataGridViewOdbicianaDzien
            // 
            this.dataGridViewOdbicianaDzien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOdbicianaDzien.Location = new System.Drawing.Point(22, 170);
            this.dataGridViewOdbicianaDzien.Name = "dataGridViewOdbicianaDzien";
            this.dataGridViewOdbicianaDzien.Size = new System.Drawing.Size(240, 92);
            this.dataGridViewOdbicianaDzien.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Wybrany dzien:";
            // 
            // comboBoxUzytkownicyharmonogram
            // 
            this.comboBoxUzytkownicyharmonogram.FormattingEnabled = true;
            this.comboBoxUzytkownicyharmonogram.Location = new System.Drawing.Point(22, 41);
            this.comboBoxUzytkownicyharmonogram.Name = "comboBoxUzytkownicyharmonogram";
            this.comboBoxUzytkownicyharmonogram.Size = new System.Drawing.Size(240, 21);
            this.comboBoxUzytkownicyharmonogram.TabIndex = 12;
            this.comboBoxUzytkownicyharmonogram.SelectedIndexChanged += new System.EventHandler(this.comboBoxUzytkownicyharmonogram_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(566, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Dni Nok";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(658, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Dni Urlopu";
            // 
            // buttonKolor1
            // 
            this.buttonKolor1.Location = new System.Drawing.Point(618, 4);
            this.buttonKolor1.Name = "buttonKolor1";
            this.buttonKolor1.Size = new System.Drawing.Size(34, 17);
            this.buttonKolor1.TabIndex = 15;
            this.buttonKolor1.UseVisualStyleBackColor = true;
            // 
            // buttonKolor2
            // 
            this.buttonKolor2.Location = new System.Drawing.Point(733, 4);
            this.buttonKolor2.Name = "buttonKolor2";
            this.buttonKolor2.Size = new System.Drawing.Size(37, 17);
            this.buttonKolor2.TabIndex = 16;
            this.buttonKolor2.UseVisualStyleBackColor = true;
            // 
            // buttonKolor3
            // 
            this.buttonKolor3.Location = new System.Drawing.Point(618, 23);
            this.buttonKolor3.Name = "buttonKolor3";
            this.buttonKolor3.Size = new System.Drawing.Size(34, 17);
            this.buttonKolor3.TabIndex = 17;
            this.buttonKolor3.UseVisualStyleBackColor = true;
            // 
            // buttonKolor4
            // 
            this.buttonKolor4.Location = new System.Drawing.Point(733, 23);
            this.buttonKolor4.Name = "buttonKolor4";
            this.buttonKolor4.Size = new System.Drawing.Size(37, 17);
            this.buttonKolor4.TabIndex = 18;
            this.buttonKolor4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Ilość godzin zgodnie z harmonogramem";
            // 
            // textBoxGodzinyharmonogram
            // 
            this.textBoxGodzinyharmonogram.Enabled = false;
            this.textBoxGodzinyharmonogram.Location = new System.Drawing.Point(22, 81);
            this.textBoxGodzinyharmonogram.Name = "textBoxGodzinyharmonogram";
            this.textBoxGodzinyharmonogram.Size = new System.Drawing.Size(89, 20);
            this.textBoxGodzinyharmonogram.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Ilość godzin urlopu";
            // 
            // textBoxGodzinyUrlopu
            // 
            this.textBoxGodzinyUrlopu.Enabled = false;
            this.textBoxGodzinyUrlopu.Location = new System.Drawing.Point(22, 120);
            this.textBoxGodzinyUrlopu.Name = "textBoxGodzinyUrlopu";
            this.textBoxGodzinyUrlopu.Size = new System.Drawing.Size(89, 20);
            this.textBoxGodzinyUrlopu.TabIndex = 22;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(120, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Ilość godzin przepracowanych";
            // 
            // textBoxGodzinyOK
            // 
            this.textBoxGodzinyOK.Location = new System.Drawing.Point(122, 120);
            this.textBoxGodzinyOK.Name = "textBoxGodzinyOK";
            this.textBoxGodzinyOK.Size = new System.Drawing.Size(143, 20);
            this.textBoxGodzinyOK.TabIndex = 24;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(799, 575);
            this.Controls.Add(this.textBoxGodzinyOK);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBoxGodzinyUrlopu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxGodzinyharmonogram);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonKolor4);
            this.Controls.Add(this.buttonKolor3);
            this.Controls.Add(this.buttonKolor2);
            this.Controls.Add(this.buttonKolor1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxUzytkownicyharmonogram);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewOdbicianaDzien);
            this.Controls.Add(this.buttonPowrot);
            this.Controls.Add(this.groupBoxZmiany);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonPoprzedni);
            this.Controls.Add(this.buttonKolejny);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDzienWolny);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "Harmonogram";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxDniWolne.ResumeLayout(false);
            this.groupBoxDniWolne.PerformLayout();
            this.groupBoxZmiany.ResumeLayout(false);
            this.groupBoxZmiany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdbicianaDzien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDzienWolny;
        private System.Windows.Forms.GroupBox groupBoxDniWolne;
        private System.Windows.Forms.Button buttonDodajDzienWolny;
        private System.Windows.Forms.DateTimePicker dateTimePickerDniWolne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOpisDniaWolnego;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonKolejny;
        private System.Windows.Forms.Button buttonPoprzedni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxZmiany;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxUzytkownik;
        private System.Windows.Forms.Button buttonUstal;
        private System.Windows.Forms.Button buttonPowrot;
        private System.Windows.Forms.DataGridView dataGridViewOdbicianaDzien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxUzytkownicyharmonogram;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonKolor1;
        private System.Windows.Forms.Button buttonKolor2;
        private System.Windows.Forms.Button buttonKolor3;
        private System.Windows.Forms.Button buttonKolor4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxGodzinyharmonogram;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxGodzinyUrlopu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxZ32;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxZ12;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxZ22;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxZ31;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxZ21;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Z11;
        private System.Windows.Forms.Label labelZN3;
        private System.Windows.Forms.Label labelZN2;
        private System.Windows.Forms.Label labelZN1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxGodzinyOK;
    }
}