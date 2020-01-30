namespace Inzynierka
{
    partial class Odbicia
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
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.buttonWejscie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownH = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownM = new System.Windows.Forms.NumericUpDown();
            this.panelError = new System.Windows.Forms.Panel();
            this.labelError = new System.Windows.Forms.Label();
            this.comboBoxUzytkownicy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownM)).BeginInit();
            this.panelError.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonZamknij.Location = new System.Drawing.Point(248, 216);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(87, 23);
            this.buttonZamknij.TabIndex = 10;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.buttonZamknij_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.AnnuallyBoldedDates = new System.DateTime[] {
        new System.DateTime(2020, 1, 1, 0, 0, 0, 0),
        new System.DateTime(2020, 1, 6, 0, 0, 0, 0),
        new System.DateTime(2020, 5, 1, 0, 0, 0, 0),
        new System.DateTime(2020, 5, 3, 0, 0, 0, 0),
        new System.DateTime(2020, 8, 15, 0, 0, 0, 0),
        new System.DateTime(2020, 11, 1, 0, 0, 0, 0),
        new System.DateTime(2020, 11, 11, 0, 0, 0, 0),
        new System.DateTime(2020, 12, 25, 0, 0, 0, 0),
        new System.DateTime(2020, 12, 26, 0, 0, 0, 0)};
            this.monthCalendar1.Location = new System.Drawing.Point(24, 18);
            this.monthCalendar1.MaxDate = new System.DateTime(2020, 1, 5, 13, 36, 50, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 11;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // buttonWejscie
            // 
            this.buttonWejscie.Location = new System.Drawing.Point(128, 215);
            this.buttonWejscie.Name = "buttonWejscie";
            this.buttonWejscie.Size = new System.Drawing.Size(112, 23);
            this.buttonWejscie.TabIndex = 12;
            this.buttonWejscie.Text = "Dodaj odbicie";
            this.buttonWejscie.UseVisualStyleBackColor = true;
            this.buttonWejscie.Click += new System.EventHandler(this.buttonWejscie_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(24, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 58);
            this.label1.TabIndex = 14;
            this.label1.Text = "Dane rejestrowane za pomocą tej funkcji są dodatkowo zapisywane w bazie danych z " +
    "datą wykonania tej operacji.\r\nNie można wykonać tych poleceń dla dat przyszłych." +
    "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            // 
            // numericUpDownH
            // 
            this.numericUpDownH.Location = new System.Drawing.Point(24, 189);
            this.numericUpDownH.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDownH.Name = "numericUpDownH";
            this.numericUpDownH.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownH.TabIndex = 19;
            this.numericUpDownH.ValueChanged += new System.EventHandler(this.numericUpDownH_ValueChanged);
            // 
            // numericUpDownM
            // 
            this.numericUpDownM.Location = new System.Drawing.Point(89, 189);
            this.numericUpDownM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownM.Name = "numericUpDownM";
            this.numericUpDownM.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownM.TabIndex = 20;
            this.numericUpDownM.ValueChanged += new System.EventHandler(this.numericUpDownM_ValueChanged);
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.labelError);
            this.panelError.Location = new System.Drawing.Point(1, 245);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(334, 71);
            this.panelError.TabIndex = 21;
            // 
            // labelError
            // 
            this.labelError.AutoEllipsis = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(23, 8);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(291, 63);
            this.labelError.TabIndex = 9;
            this.labelError.Text = "Info";
            // 
            // comboBoxUzytkownicy
            // 
            this.comboBoxUzytkownicy.FormattingEnabled = true;
            this.comboBoxUzytkownicy.Location = new System.Drawing.Point(1, 215);
            this.comboBoxUzytkownicy.Name = "comboBoxUzytkownicy";
            this.comboBoxUzytkownicy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUzytkownicy.TabIndex = 22;
            // 
            // Odbicia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonZamknij;
            this.ClientSize = new System.Drawing.Size(338, 315);
            this.Controls.Add(this.comboBoxUzytkownicy);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.numericUpDownM);
            this.Controls.Add(this.numericUpDownH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWejscie);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.buttonZamknij);
            this.MinimumSize = new System.Drawing.Size(354, 354);
            this.Name = "Odbicia";
            this.ShowInTaskbar = false;
            this.Text = "Odbicia";
            this.Load += new System.EventHandler(this.Odbicia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownM)).EndInit();
            this.panelError.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button buttonWejscie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownH;
        private System.Windows.Forms.NumericUpDown numericUpDownM;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ComboBox comboBoxUzytkownicy;
    }
}