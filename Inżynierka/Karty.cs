using System;
using System.Data;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class Karty : Form
    {
        public int id_uzyt;
        public Karty()
        {
            InitializeComponent();
        }
        private void zaladujtabele()
        {
            try
            {
                DataTable karty;
                string komenda = @"select o.NrKarty , o.Czas from odbicia as o
                            where o.NrKarty not in (select NrKarty from karty)";
                karty = RCPprogram.CreateInstance().PobierzDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);

                dataGridView1.DataSource = karty;
                dataGridView1.RowHeadersVisible = false;
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataTable kartyprzypisane;
                komenda = @"select * from karty as k";
                kartyprzypisane = RCPprogram.CreateInstance().PobierzDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);

                dataGridView2.DataSource = kartyprzypisane;
                dataGridView2.RowHeadersVisible = false;
                this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (MySql.Data.MySqlClient.MySqlException fx) {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd bazy danych na formularzu karty. Wiadomość: " + fx.Message);
            }
            catch (Exception ex)
            {
                string wiadomosc = "Błąd na formularzu karty: ładowanie grid nie powiodło się. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void Karty_Load(object sender, EventArgs e)
        {
            this.Text = "RCPprogram - przypisz karty użytkownikom";
            dateTimePickerOD.Format = DateTimePickerFormat.Custom;
            dateTimePickerOD.CustomFormat = "yyyy-MM-dd";

            dateTimePickerDO.Format = DateTimePickerFormat.Custom;
            dateTimePickerDO.CustomFormat = "yyyy-MM-dd";
            dateTimePickerDO.Value = DateTime.Now.AddYears(1);

            zaladujtabele();

            try
            {
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY) |
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
            catch (MySql.Data.MySqlClient.MySqlException fx)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd bazy na formularzu karty. Wiadomość: " + fx.Message);
            }
            catch (Exception ex)
            {
                string wiadomosc = "Błąd na formularzu kart: ładowanie combobox nie powiodło się. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.POLOG);
        }
        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(false);
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow cacheRow;
                cacheRow = this.dataGridView1.Rows[e.RowIndex];

                string karta = cacheRow.Cells[0].Value.ToString();

                textBoxNrkarty.Text = karta;
            }
        }
        private void ButtonPrzypisz_Click(object sender, EventArgs e)
        {
            Uzytkownik user = null;
            try
            {
                string input = comboBoxUzytkownicy.ValueMember;
                DataRowView irow = (DataRowView)comboBoxUzytkownicy.SelectedItem;
                int user_id = int.Parse(irow.Row[input].ToString());
                user = new Uzytkownik(user_id);
                id_uzyt = user_id;

                //sprawdzenie czy użytkwonik ma inną kartę
                string sprawdzquery = "select Count(*) from karty where NrPracownika='" + id_uzyt.ToString() + "'";

                int iloscrek = Convert.ToInt32(RCPprogram.CreateInstance().PobierzElement(sprawdzquery, new MySql.Data.MySqlClient.MySqlParameter[0]));

                MessageBox.Show(iloscrek.ToString());
                if (iloscrek > 0)
                {
                    string nrstarejkarty = RCPprogram.CreateInstance().PobierzElement(@"select NrKarty from karty where NrPracownika='" + id_uzyt.ToString() + "'", new MySql.Data.MySqlClient.MySqlParameter[0]);
                    string nrnowejkarty = textBoxNrkarty.Text;
                    DialogResult dialogResult = MessageBox.Show("Ten użytkownik ma przypisaną kartę, czy chcesz mu ją zmienić? Odbicia zostaną wtedy przepisane na nową kartę.", "Zmiana karty", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        RCPprogram.CreateInstance().ZaktualizujDane("Update odbicia set NrKarty='" + nrnowejkarty + "' where NrKarty='" + nrstarejkarty + "'", new MySql.Data.MySqlClient.MySqlParameter[0]);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                string komenda = "INSERT INTO `karty`(`ID`, `NrPracownika`, `NrKarty`, `status`, `dataOd`, `dataDo`) VALUES ('','" + id_uzyt + "','" + textBoxNrkarty.Text + "','1','" + dateTimePickerOD.Value.ToString("yyyy-MM-dd") + "','" + dateTimePickerDO.Value.ToString("yyyy-MM-dd") + "')";
                RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);

                string komendausun = "delete from `karty` where NrKarty='" + textBoxNrkarty.Text + "' and Czas<='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                RCPprogram.CreateInstance().ZaktualizujDane(komendausun, new MySql.Data.MySqlClient.MySqlParameter[0]);
            }
            catch (MySql.Data.MySqlClient.MySqlException fx)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd bazy na karcie Karty. Wiadomość: " + fx.Message);
                MessageBox.Show("Błąd połaczenia z bazą danych.");
            }
            catch (Exception ex)
            {
                string wiadomosc = "Błąd na formularzu kart: przypisanie karty nie powiodło się. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show("Inny błąd. Przypisanie karty nie powiodło się. Skontaktuj się z administratorem.");
            }
            finally
            {
                user.Dispose();
            }
            zaladujtabele();
        }
        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow cacheRow;
                cacheRow = this.dataGridView2.Rows[e.RowIndex];

                string karta = cacheRow.Cells[2].Value.ToString();

                textBoxAnulujKarte.Text = karta;
            }
        }
        private void ButtonAnulujKarte_Click(object sender, EventArgs e)
        {
            try
            {
                string idpracownika = RCPprogram.CreateInstance().PobierzElement("select ID from karty where NrKarty='" + textBoxAnulujKarte.Text + "'", new MySql.Data.MySqlClient.MySqlParameter[0]);
                int kartazam = Convert.ToInt32(idpracownika) * 1111;
                RCPprogram.CreateInstance().ZaktualizujDane("Update odbicia set NrKarty='" + kartazam + "' where NrKarty='" + textBoxAnulujKarte.Text + "'", new MySql.Data.MySqlClient.MySqlParameter[0]);

                RCPprogram.CreateInstance().ZaktualizujDane("Update karty set NrKarty='" + kartazam + "' , status=0, dataDo='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where NrKarty='" + textBoxAnulujKarte.Text + "'", new MySql.Data.MySqlClient.MySqlParameter[0]);
            }
            catch (MySql.Data.MySqlClient.MySqlException fx)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd bazy na karcie Karty. Wiadomość: " + fx.Message);
                MessageBox.Show("Błąd połaczenia z bazą danych.");
            }
            catch (Exception ex)
            {
                string wiadomosc = "Błąd na formularzu kart: przypisanie karty nie powiodło się. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show("Inny błąd. Przypisanie karty nie powiodło się. Skontaktuj się z administratorem.");
            }
            zaladujtabele();
        }
        private void Karty_FormClosed(object sender, FormClosedEventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(true);
        }
    }
}

