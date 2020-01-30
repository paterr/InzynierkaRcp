using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class Odbicia : Form
    {
        public Odbicia()
        {
            InitializeComponent();
        }
        public string id = "";
        private DateTime cache;
        private Harmonogram harm;
        private void Odbicia_Load(object sender, EventArgs e)
        {
            monthCalendar1.MaxDate = DateTime.Now;
            monthCalendar1.SetDate(DateTime.Now);
            numericUpDownH.Value = (decimal)DateTime.Now.Hour;
            numericUpDownM.Value = (decimal)DateTime.Now.Minute;
            Aktualizuj();
            harm = new Harmonogram(RCPprogram.CreateInstance().Uzytkownik, cache.Year, cache.Month);

            try
            {
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY) |
                    RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) |
                    RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY))
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy`";
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    comboBoxUzytkownicy.DisplayMember = "Nazwisko";
                    comboBoxUzytkownicy.ValueMember = "Id";
                    comboBoxUzytkownicy.DataSource = dt;
                }
                else if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF))
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                        "WHERE `IdSzefa`=" + RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    comboBoxUzytkownicy.DisplayMember = "Nazwisko";
                    comboBoxUzytkownicy.ValueMember = "Id";
                    comboBoxUzytkownicy.DataSource = dt;
                }
                else
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                                     "WHERE `Id`=" + RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    comboBoxUzytkownicy.DisplayMember = "Nazwisko";
                    comboBoxUzytkownicy.ValueMember = "Id";
                    comboBoxUzytkownicy.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd na karcie Harmonogram. Wiadomość: " + ex.Message);
                comboBoxUzytkownicy.Text = RCPprogram.CreateInstance().Uzytkownik.Imie + " " + RCPprogram.CreateInstance().Uzytkownik.Nazwisko;
            }

            //id
            id = RCPprogram.CreateInstance().Uzytkownik.ID.ToString();
        }
        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonWejscie_Click(object sender, EventArgs e)
        {
            labelError.Text = "";
            panelError.Visible = false;
            try
            {
                DateTime odbicie = DateTime.Parse(label4.Text);
                string i = comboBoxUzytkownicy.ValueMember;
                DataRowView row = (DataRowView)comboBoxUzytkownicy.SelectedItem;
                id = row.Row[i].ToString();
                string nrkarty;
                string komenda0 = "SELECT `NrKarty` FROM `karty` WHERE `NrPracownika`='" + id
                    + "' AND `DataDo`>='" + odbicie + "'";
                try
                {
                    nrkarty = RCPprogram.CreateInstance().PobierzElement(komenda0, new MySql.Data.MySqlClient.MySqlParameter[0]);
                }
                catch (IndexOutOfRangeException) { throw new IndexOutOfRangeException("Pracownik nie ma przypisanej karty. Nie można zarejestrować odbicia."); }
                string komenda = "INSERT INTO odbicia (ID, NrKarty, Czas) VALUES ('', " +
                nrkarty + ", '" + odbicie.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                RCPprogram.CreateInstance().ZaktualizujDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                string wiadomosc = "Dziękuję, dane zapisano.\n" + odbicie.ToString("g", Toolbox.kultura);
                MessageBox.Show(wiadomosc);
            }
            catch (Exception ex)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd na karcie Odbicia. Wiadomość: " + ex.Message);
                labelError.Text = ex.Message;
                panelError.Visible = true;
            }
        }     
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Aktualizuj();
        }
        private void Aktualizuj()
        {
            TimeSpan span = new TimeSpan((int)numericUpDownH.Value, (int)numericUpDownM.Value, 0);
            cache = monthCalendar1.SelectionRange.Start.Add(span);
            label4.Text = cache.ToString();
            panelError.Visible = false;
            labelError.Text = "";
        }
        private void numericUpDownH_ValueChanged(object sender, EventArgs e)
        {
            Aktualizuj();
        }
        private void numericUpDownM_ValueChanged(object sender, EventArgs e)
        {
            Aktualizuj();
        }
    }
}
