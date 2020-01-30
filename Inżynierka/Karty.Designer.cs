namespace Inzynierka
{
    partial class Karty
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxUzytkownicy = new System.Windows.Forms.ComboBox();
            this.buttonPowrot = new System.Windows.Forms.Button();
            this.textBoxNrkarty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPrzypisz = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDO = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOD = new System.Windows.Forms.DateTimePicker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxAnulujKarte = new System.Windows.Forms.TextBox();
            this.buttonAnulujKarte = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(242, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(550, 173);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // comboBoxUzytkownicy
            // 
            this.comboBoxUzytkownicy.FormattingEnabled = true;
            this.comboBoxUzytkownicy.Location = new System.Drawing.Point(115, 51);
            this.comboBoxUzytkownicy.Name = "comboBoxUzytkownicy";
            this.comboBoxUzytkownicy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUzytkownicy.TabIndex = 1;
            // 
            // buttonPowrot
            // 
            this.buttonPowrot.Location = new System.Drawing.Point(689, 481);
            this.buttonPowrot.Name = "buttonPowrot";
            this.buttonPowrot.Size = new System.Drawing.Size(84, 23);
            this.buttonPowrot.TabIndex = 2;
            this.buttonPowrot.Text = "Powrót";
            this.buttonPowrot.UseVisualStyleBackColor = true;
            this.buttonPowrot.Click += new System.EventHandler(this.buttonPowrot_Click);
            // 
            // textBoxNrkarty
            // 
            this.textBoxNrkarty.Location = new System.Drawing.Point(9, 51);
            this.textBoxNrkarty.Name = "textBoxNrkarty";
            this.textBoxNrkarty.Size = new System.Drawing.Size(100, 20);
            this.textBoxNrkarty.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nr. Karty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Użytkownicy:";
            // 
            // buttonPrzypisz
            // 
            this.buttonPrzypisz.Location = new System.Drawing.Point(242, 186);
            this.buttonPrzypisz.Name = "buttonPrzypisz";
            this.buttonPrzypisz.Size = new System.Drawing.Size(75, 23);
            this.buttonPrzypisz.TabIndex = 7;
            this.buttonPrzypisz.Text = "Przypisz";
            this.buttonPrzypisz.UseVisualStyleBackColor = true;
            this.buttonPrzypisz.Click += new System.EventHandler(this.ButtonPrzypisz_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePickerDO);
            this.groupBox1.Controls.Add(this.dateTimePickerOD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonPrzypisz);
            this.groupBox1.Controls.Add(this.comboBoxUzytkownicy);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNrkarty);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 215);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Przypisz kartę do użytkownika";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "OD:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "DO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data ważności:";
            // 
            // dateTimePickerDO
            // 
            this.dateTimePickerDO.Location = new System.Drawing.Point(15, 163);
            this.dateTimePickerDO.Name = "dateTimePickerDO";
            this.dateTimePickerDO.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDO.TabIndex = 9;
            // 
            // dateTimePickerOD
            // 
            this.dateTimePickerOD.Location = new System.Drawing.Point(15, 121);
            this.dateTimePickerOD.Name = "dateTimePickerOD";
            this.dateTimePickerOD.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerOD.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(522, 195);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxAnulujKarte);
            this.groupBox2.Controls.Add(this.buttonAnulujKarte);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(21, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(802, 224);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Karty Przypisane";
            // 
            // textBoxAnulujKarte
            // 
            this.textBoxAnulujKarte.Location = new System.Drawing.Point(587, 85);
            this.textBoxAnulujKarte.Name = "textBoxAnulujKarte";
            this.textBoxAnulujKarte.ReadOnly = true;
            this.textBoxAnulujKarte.Size = new System.Drawing.Size(112, 20);
            this.textBoxAnulujKarte.TabIndex = 11;
            // 
            // buttonAnulujKarte
            // 
            this.buttonAnulujKarte.Location = new System.Drawing.Point(601, 111);
            this.buttonAnulujKarte.Name = "buttonAnulujKarte";
            this.buttonAnulujKarte.Size = new System.Drawing.Size(75, 23);
            this.buttonAnulujKarte.TabIndex = 10;
            this.buttonAnulujKarte.Text = "Anuluj kartę";
            this.buttonAnulujKarte.UseVisualStyleBackColor = true;
            this.buttonAnulujKarte.Click += new System.EventHandler(this.ButtonAnulujKarte_Click);
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.Location = new System.Drawing.Point(608, 481);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(75, 23);
            this.buttonWyloguj.TabIndex = 11;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = true;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // Karty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 516);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPowrot);
            this.Name = "Karty";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Karty_FormClosed);
            this.Load += new System.EventHandler(this.Karty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxUzytkownicy;
        private System.Windows.Forms.Button buttonPowrot;
        private System.Windows.Forms.TextBox textBoxNrkarty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPrzypisz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerDO;
        private System.Windows.Forms.DateTimePicker dateTimePickerOD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAnulujKarte;
        private System.Windows.Forms.Button buttonAnulujKarte;
        private System.Windows.Forms.Button buttonWyloguj;
    }
}