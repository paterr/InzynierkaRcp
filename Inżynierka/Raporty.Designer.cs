namespace Inzynierka
{
    partial class Raporty
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxUzytkownik = new System.Windows.Forms.ComboBox();
            this.buttonPdf = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(21, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(193, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // comboBoxUzytkownik
            // 
            this.comboBoxUzytkownik.FormattingEnabled = true;
            this.comboBoxUzytkownik.Location = new System.Drawing.Point(21, 39);
            this.comboBoxUzytkownik.Name = "comboBoxUzytkownik";
            this.comboBoxUzytkownik.Size = new System.Drawing.Size(193, 21);
            this.comboBoxUzytkownik.TabIndex = 6;
            this.comboBoxUzytkownik.SelectedIndexChanged += new System.EventHandler(this.ComboBoxUzytkownik_SelectedIndexChanged);
            // 
            // buttonPdf
            // 
            this.buttonPdf.Location = new System.Drawing.Point(21, 114);
            this.buttonPdf.Name = "buttonPdf";
            this.buttonPdf.Size = new System.Drawing.Size(93, 23);
            this.buttonPdf.TabIndex = 7;
            this.buttonPdf.Text = "Twórz pdf";
            this.buttonPdf.UseVisualStyleBackColor = true;
            this.buttonPdf.Click += new System.EventHandler(this.ButtonPdf_Click);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(121, 114);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(93, 23);
            this.buttonZamknij.TabIndex = 9;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.ButtonZamknij_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wybierz użytkownika";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Wybierz okres sprawozdawczy";
            // 
            // Raporty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 159);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonZamknij);
            this.Controls.Add(this.buttonPdf);
            this.Controls.Add(this.comboBoxUzytkownik);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Raporty";
            this.ShowInTaskbar = false;
            this.Text = "Raporty";
            this.Load += new System.EventHandler(this.Raporty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxUzytkownik;
        private System.Windows.Forms.Button buttonPdf;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}