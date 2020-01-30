using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace Inzynierka
{
    public partial class Raporty : Form
    {
        public string id = "";
        public Raporty()
        {
            InitializeComponent();
        }
        private void Raporty_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

            //zakres
            try
            {
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY) |
                    RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY))
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy`";
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySqlParameter[0]);
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
                else if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF))
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                        "WHERE `IdSzefa`=" + RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySqlParameter[0]);
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
                else
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                                     "WHERE `Id`=" + RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySqlParameter[0]);
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd na karcie Raporty. Wiadomość: " + ex.Message);
            }
        }
        private void ComboBoxUzytkownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            string i = comboBoxUzytkownik.ValueMember;
            DataRowView row = (DataRowView)comboBoxUzytkownik.SelectedItem;
            id = row.Row[i].ToString();
        }
        private void ButtonPdf_Click(object sender, EventArgs e)
        {
            //dane wejściowe
            DateTime dataOd = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1, 0, 0, 0);
            Uzytkownik user = new Uzytkownik(int.Parse(id));
            Harmonogram harm = new Harmonogram(user, dataOd.Year, dataOd.Month);

            //pytanie o ścieżkę
            string folderName;
            using (FolderBrowserDialog selectFolder = new FolderBrowserDialog())
            {
                selectFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                selectFolder.ShowNewFolderButton = true;
                DialogResult result = selectFolder.ShowDialog();
                folderName = selectFolder.SelectedPath;

                if (result == DialogResult.OK)
                {
                    try
                    {
                        string dest = folderName + "/RCPrap_" + user.Nazwisko + "_" + user.Imie[0] + "_" + dataOd.ToString("MMMyy") + ".pdf";

                        //Initialize PDF writer
                        PdfWriter writer = new PdfWriter(dest);
                        //Initialize PDF document
                        PdfDocument pdf = new PdfDocument(writer);
                        // Initialize document
                        Document document = new Document(pdf);

                        //czcionki
                        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN, "cp1250", true);
                        PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD, "cp1250", true);

                        DataTable dt = harm.Widokharmonogramu();

                        //Dodaj paragraf do dokumentu
                        document.Add(new Paragraph("RCPprogram - raport miesięczny").SetFont(font).SetFontSize(22));
                        document.Add(new Paragraph("").SetFont(font));
                        Table naglowek = new Table(UnitValue.CreatePercentArray(new float[] { 3, 7 }))
                                    .UseAllAvailableWidth();
                        iText.Layout.Borders.SolidBorder linie = new iText.Layout.Borders.SolidBorder(DeviceRgb.WHITE, 0, 0);
                        naglowek.SetBorder(linie);
                        naglowek.AddCell(new Cell().Add(new Paragraph("Użytkownik:").SetFont(font)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph(comboBoxUzytkownik.Text.ToString(Toolbox.kultura)).SetFont(bold)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph("Okres sprawozdawczy:").SetFont(font)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph(dateTimePicker1.Value.ToString("MMMM yyyy", Toolbox.kultura)).SetFont(bold)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph("Liczba godzin harmonogramowych:").SetFont(font)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph(harm.godzinyharmonogram.ToString()).SetFont(bold)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph("Liczba godzin przepracowanych:").SetFont(font)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph(harm.godzinyrzeczywiste.ToString()).SetFont(bold)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph("Liczba godzin urlopu:").SetFont(font)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph(harm.godzinyurlop.ToString()).SetFont(bold)).SetBorder(linie));
                        naglowek.AddCell(new Cell().Add(new Paragraph("").SetFont(font)).SetBorder(linie));
                        document.Add(naglowek);

                        //tabela
                        Table table = new Table(UnitValue.CreatePercentArray(new float[] { 10, 6, 6 }))
                                    .UseAllAvailableWidth();
                        string data = "Data";
                        string harmonogram = "Harmonogram";
                        string komentarz = "Komentarz";
                        table.AddHeaderCell(new Cell().Add(new Paragraph(data).SetFont(bold)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph(harmonogram).SetFont(bold)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph(komentarz).SetFont(bold)));

                        int len = dt.Rows.Count;
                        for (int i = 0; i < len; i++)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                table.AddCell(new Cell().Add(new Paragraph(dt.Rows[i][0].ToString()).SetFont(font)));
                                table.AddCell(new Cell().Add(new Paragraph(dt.Rows[i][1].ToString().Replace(";", Environment.NewLine)).SetFont(font)));
                                table.AddCell(new Cell().Add(new Paragraph(dt.Rows[i][2].ToString()).SetFont(font)));
                            }
                        }
                        document.Add(table);

                        //Close document
                        document.Close();
                    }
                    catch (Exception ex)
                    {
                        RCPprogram.CreateInstance().ZapiszLogBledu("Błąd na karcie Raporty. Błędna ścieżka. Wiadomość: " + ex.Message);
                        MessageBox.Show("Ścieżka zapisu jest błędna lub zablokowana.");
                    }
                }
                else
                {
                    MessageBox.Show("Nie wybrano właściwej ścieżki do zapisu raportu.");
                }
            }
        }
        private void ButtonZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
