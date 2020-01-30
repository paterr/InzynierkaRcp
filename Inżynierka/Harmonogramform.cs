using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class Form3 : Form
    {
        public string id = "";
        public int ukryjpokaz = 2;
        public int monthss = 0;
        public Form3()
        {
            InitializeComponent();
            groupBoxDniWolne.Visible = false;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(DataGridView1_CellClick);
        }

        private void ButtonDzienWolny_Click(object sender, EventArgs e)
        {
            if (ukryjpokaz % 2 == 0)
            {
                groupBoxDniWolne.Visible = true;
                buttonDzienWolny.Text = "Dodaj harmonogram";
            }
            else
            {
                groupBoxDniWolne.Visible = false;
                buttonDzienWolny.Text = "Dodaj dzień wolny";
            }
            ukryjpokaz++;
        }

        public void wczytajharmonogram()
        {
            //nagłówek tabeli
            label3.Text = DateTime.Now.AddMonths(monthss).ToString("MMMM-yyyy");
            //ramy dla generowanego miesiąca
            int year = Convert.ToInt32(DateTime.Now.AddMonths(monthss).ToString("yyyy"));
            int month = Convert.ToInt32(DateTime.Now.AddMonths(monthss).ToString("MM"));

            //uzytkownik
            try
            {
                DataRowView row = (DataRowView)comboBoxUzytkownicyharmonogram.SelectedItem;
                id = row.Row["Id"].ToString();
            }
            catch { }

            //harmonogram
            Harmonogram harm = new Harmonogram(int.Parse(id), year, month);
            dataGridView1.DataSource = harm.Widokharmonogramu();

            //formatowanie
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                //zawijanie tekstu z datami
                if (dataGridView1.Rows[j].Cells[1].Value != null)
                {
                    dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    string jointab = dataGridView1.Rows[j].Cells[1].Value.ToString().Replace(";", Environment.NewLine);
                    dataGridView1.Rows[j].Cells[1].Value = jointab;
                }
                //kolorowanie wierszy
                if (dataGridView1.Rows[j].Cells[2].Value == null)
                {
                }
                else if (dataGridView1.Rows[j].Cells[2].Value.ToString() == "Urlop")
                {
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (dataGridView1.Rows[j].Cells[2].Value.ToString() == "W:OK")
                {
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (dataGridView1.Rows[j].Cells[2].Value.ToString() == "W:NOK")
                {
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (dataGridView1.Rows[j].Cells[2].Value.ToString() == "Nadgodziny")
                {
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (dataGridView1.Rows[j].Cells[2].Value.ToString().Contains("Dzień wolny"))
                {
                    dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Beige;
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //sumy godzin
            textBoxGodzinyharmonogram.Text = harm.godzinyharmonogram.ToString();
            textBoxGodzinyUrlopu.Text = harm.godzinyurlop.ToString();
            textBoxGodzinyOK.Text = harm.godzinyrzeczywiste.ToString();
            /*
            int godzinyurlop = 0;
            int godziny = 0;
            int godzinyok = 0;
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (dataGridView1.Rows[j].Cells[1].Value != null)

                {
                    string[] tabela1 = dataGridView1.Rows[j].Cells[1].Value.ToString().Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.None);

                    if (tabela1.Length > 1)
                    {
                        DateTime poczatek = Convert.ToDateTime(tabela1[0].ToString());
                        DateTime koniec = Convert.ToDateTime(tabela1[1].ToString());



                        TimeSpan difference = koniec - poczatek;
                        int hours = Math.Abs(difference.Hours);
                        godziny += hours;

                        if (dataGridView1.Rows[j].Cells[2].Value.ToString() == "Urlop")
                        {
                            godzinyurlop += hours;
                        }
                        else if (dataGridView1.Rows[j].Cells[2].Value.ToString() == "W:OK")
                        {
                            godzinyok += hours;
                        }

                    }
                }

            }
            textBoxGodzinyharmonogram.Text = godziny.ToString();
            textBoxGodzinyUrlopu.Text = godzinyurlop.ToString();
            textBoxGodzinyOK.Text = godzinyok.ToString();*/

            //liczymy godziny pracy i godziny urlopu
            //int godzinyurlop = 0;
            //int godziny = 0;
            //for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            //{
            //    string[] tabela1 = dataGridView1.Rows[j].Cells[1].Value.ToString().Split(
            //                            new[] { Environment.NewLine },
            //                            StringSplitOptions.None
            //                        );
            //    if (tabela1.Length > 1)
            //    {
            //        DateTime poczatek = Convert.ToDateTime(tabela1[0].ToString());
            //        DateTime koniec = Convert.ToDateTime(tabela1[1].ToString());

            //        TimeSpan difference = koniec - poczatek;
            //        int hours = difference.Hours;
            //        godziny += hours;

            //        if (dataGridView1.Rows[j].DefaultCellStyle.BackColor.ToString() == "Color [Orange]")
            //        {
            //            godzinyurlop += hours;
            //        }
            //    }
            //}
            //textBoxGodzinyharmonogram.Text = godziny.ToString();
            //textBoxGodzinyUrlopu.Text = godzinyurlop.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //zablokowanie pól nie do edycji przez użytkownika w zależności od uprawnień, kasowanie wartości
            buttonUstal.Enabled = false;
            labelZN1.Text = "";
            labelZN2.Text = "";
            labelZN3.Text = "";

            buttonKolor1.Enabled = false;
            buttonKolor2.Enabled = false;
            buttonKolor3.Enabled = false;
            buttonKolor4.Enabled = false;
            textBoxGodzinyharmonogram.Enabled = false;
            textBoxGodzinyUrlopu.Enabled = false;
            groupBoxDniWolne.Visible = false;

            if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY))
            {
                comboBoxUzytkownicyharmonogram.Visible = true;
                buttonDzienWolny.Visible = true;
                groupBoxZmiany.Visible = true;
            }
            else
            {
                comboBoxUzytkownicyharmonogram.Visible = false;
                buttonDzienWolny.Visible = false;
                groupBoxZmiany.Visible = false;
            }

            buttonKolor1.BackColor = Color.Green;
            buttonKolor2.BackColor = Color.Beige;
            buttonKolor3.BackColor = Color.Red;
            buttonKolor4.BackColor = Color.Orange;

            //uzupełnienie comboBox z użytkownikami
            try
            {
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY) |
                    RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) |
                    RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY))
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy`";
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    comboBoxUzytkownicyharmonogram.DisplayMember = "Nazwisko";
                    comboBoxUzytkownicyharmonogram.ValueMember = "Id";
                    comboBoxUzytkownicyharmonogram.DataSource = dt;
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
                else if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF))
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                        "WHERE `IdSzefa`=" + RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    comboBoxUzytkownicyharmonogram.DisplayMember = "Nazwisko";
                    comboBoxUzytkownicyharmonogram.ValueMember = "Id";
                    comboBoxUzytkownicyharmonogram.DataSource = dt;
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
                else
                {
                    string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                                     "WHERE `Id`=" + RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    comboBoxUzytkownicyharmonogram.DisplayMember = "Nazwisko";
                    comboBoxUzytkownicyharmonogram.ValueMember = "Id";
                    comboBoxUzytkownicyharmonogram.DataSource = dt;
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                RCPprogram.CreateInstance().ZapiszLogBledu("Błąd na karcie Harmonogram. Wiadomość: " + ex.Message);
                comboBoxUzytkownicyharmonogram.Text = RCPprogram.CreateInstance().Uzytkownik.Imie + " " + RCPprogram.CreateInstance().Uzytkownik.Nazwisko;
            }

            //id
            id = RCPprogram.CreateInstance().Uzytkownik.ID.ToString();

            wczytajharmonogram();
        }
        private void ButtonDodajDzienWolny_Click(object sender, EventArgs e)
        {
            try
            {
                string opis = Toolbox.inputString(textBoxOpisDniaWolnego.Text, true, 255, "");
                string komenda = @"Insert into dniwolne VALUES ('" + dateTimePickerDniWolne.Value.ToString("yyyy-MM-dd") + @"','" + opis + @"') ";
                RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
            }
            catch (FormatException ex)
            {
                string wiadomosc = "Nieprawidłowy opis dnia wolnego. " + ex.Message;
                MessageBox.Show(wiadomosc);
            }
            catch (Exception fx)
            {
                string wiadomosc = "Inny błąd przy wprowadzaniu dnia wolnego: " + fx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                wiadomosc = "Inny błąd. Skontaktuj się z administratorem";
                MessageBox.Show(wiadomosc);
            }
        }
        private void ButtonKolejny_Click(object sender, EventArgs e)
        {
            monthss++;
            wczytajharmonogram();
        }
        private void ButtonPoprzedni_Click(object sender, EventArgs e)
        {
            monthss--;
            wczytajharmonogram();
        }
        private void ButtonUstal_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)comboBoxUzytkownicyharmonogram.SelectedItem;
                id = row.Row["Id"].ToString();
           
                //sprawdzanie czy nie generujemy podwójnych harmonogramów
                string komenda = "select * from `harmonogram` where `Nrpracownika`='" + id + "' and `Datastart` BETWEEN " +
                    "'" + dateTimePicker1.Value.Date + "' and '" + dateTimePicker2.Value.Date + "'";
                DataTable dt = RCPprogram.CreateInstance().PobierzDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);

                if (dt.Rows.Count > 0)
                {
                    string message = "W podanym czasie jest już ustalony harmonogram, który zostanie usunięty. Czy chcesz kontynuować?";
                    string caption = "W podanym czasie jest już ustalony harmonogram.";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes)
                    {
                        //usunięcie poprzednich wpisów
                        string komendausun = "DELETE FROM `harmonogram` where `Nrpracownika`='" + id + "' and `Datastart` BETWEEN " +
                       "'" + dateTimePicker1.Value.Date + "' and '" + dateTimePicker2.Value.Date + "'";
                        RCPprogram.CreateInstance().ZaktualizujDane(komendausun, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    }
                    else { return; }
                }

                int zmiana = 1;
                for (DateTime date = dateTimePicker1.Value; date.Date <= dateTimePicker2.Value.Date; date = date.AddDays(1))
                {
                    if (date.ToString("dddd") == "niedziela" || date.ToString("dddd") == "sobota")
                    {
                        zmiana++;
                        if (zmiana == 4) { zmiana = 1; }
                    }
                    else
                    {
                        //string[] tablicauzyt = comboBoxUzytkownik.Text.Split(';');
                        string input = comboBoxUzytkownik.ValueMember;
                        DataRowView irow = (DataRowView)comboBoxUzytkownik.SelectedItem;
                        int user_id = int.Parse(irow.Row[input].ToString());
                        Uzytkownik user = new Uzytkownik(user_id);
                        if (zmiana == 1)
                        {
                            if (labelZN1.Text == "Zmiana nocna")
                            {
                                RCPprogram.CreateInstance().DodajDane(@"INSERT INTO `harmonogram`(`Nrpracownika`, `Datastart`, `Datakoniec`, `komentarz`) VALUES ('" + user_id + "','" + date.ToString("yyyy-MM-dd ") + maskedTextBox_Z11.Text + @"','" + date.AddDays(1).ToString("yyyy-MM-dd") + maskedTextBoxZ12.Text + @"','komentarz')", new MySql.Data.MySqlClient.MySqlParameter[0]);
                            }
                            else
                            {
                                RCPprogram.CreateInstance().DodajDane(@"INSERT INTO `harmonogram`(`Nrpracownika`, `Datastart`, `Datakoniec`, `komentarz`) VALUES ('" + user_id + "','" + date.ToString("yyyy-MM-dd ") + maskedTextBox_Z11.Text + @"','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ12.Text + @"','komentarz')", new MySql.Data.MySqlClient.MySqlParameter[0]);
                            }
                        }
                        else if (zmiana == 2)
                        {
                            if (labelZN2.Text == "Zmiana nocna")
                            {
                                RCPprogram.CreateInstance().DodajDane(@"INSERT INTO `harmonogram`(`Nrpracownika`, `Datastart`, `Datakoniec`, `komentarz`) VALUES ('" + user_id + "','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ21.Text + @"','" + date.AddDays(1).ToString("yyyy-MM-dd ") + maskedTextBoxZ22.Text + @"','komentarz')", new MySql.Data.MySqlClient.MySqlParameter[0]);
                            }
                            else
                            {
                                RCPprogram.CreateInstance().DodajDane(@"INSERT INTO `harmonogram`(`Nrpracownika`, `Datastart`, `Datakoniec`, `komentarz`) VALUES ('" + user_id + "','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ21.Text + @"','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ22.Text + @"','komentarz')", new MySql.Data.MySqlClient.MySqlParameter[0]);
                            }
                        }

                        else if (zmiana == 3)
                        {
                            if (labelZN3.Text == "Zmiana nocna")
                            {
                                RCPprogram.CreateInstance().DodajDane(@"INSERT INTO `harmonogram`(`Nrpracownika`, `Datastart`, `Datakoniec`, `komentarz`) VALUES ('" + user_id + "','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ31.Text + @"','" + date.AddDays(1).ToString("yyyy-MM-dd ") + maskedTextBoxZ32.Text + @"','komentarz')", new MySql.Data.MySqlClient.MySqlParameter[0]);
                            }
                            else
                            {
                                RCPprogram.CreateInstance().DodajDane(@"INSERT INTO `harmonogram`(`Nrpracownika`, `Datastart`, `Datakoniec`, `komentarz`) VALUES ('" + user_id + "','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ31.Text + @"','" + date.ToString("yyyy-MM-dd ") + maskedTextBoxZ32.Text + @"','komentarz')", new MySql.Data.MySqlClient.MySqlParameter[0]);
                            }
                        }
                    }
                }
                wczytajharmonogram();
            }
            catch(MySql.Data.MySqlClient.MySqlException bx) {
                string wiadomosc = "Błąd bazy danych przy ustalaniu harmonogramu. Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                wiadomosc = "Błąd bazy danych. Sprawdź połączenie lub skontaktuj się z administratorem.";
                MessageBox.Show(wiadomosc);
            }
            catch (Exception ex)
            {
                string wiadomosc = "Inny błąd przy ustalaniu harmonogramu. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                wiadomosc = "Inny błąd. Skontaktuj się z administratorem.";
                MessageBox.Show(wiadomosc);
            }
        }
        private void ButtonPowrot_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.POLOG);
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow cacheRow = this.dataGridView1.Rows[e.RowIndex];

                    string harmonogramwejwyj = cacheRow.Cells[1].Value.ToString();
                    string[] harmonogram = harmonogramwejwyj.Split(
                    new[] { Environment.NewLine },
                        StringSplitOptions.None
                        );
                    if (harmonogram[0].Length < 4)
                    {
                        //TODO: Po co to?
                    }
                    else
                    {
                        DateTime harwej = Convert.ToDateTime(harmonogram[0]);
                        DateTime harwyj = Convert.ToDateTime(harmonogram[1]);
                        DataTable odbiciawprzedziale = RCPprogram.CreateInstance().PobierzDane(@"select Czas from odbicia as o 
                            left join karty as k ON k.NrKarty=o.NrKarty where k.NrPracownika='" + id +
                            @"' and Czas between  '" + harwej.AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + harwyj.AddHours(5).ToString("yyyy-MM-dd HH:mm:ss") + "'", new MySql.Data.MySqlClient.MySqlParameter[0]);
                        dataGridViewOdbicianaDzien.DataSource = odbiciawprzedziale;
                    }
                }
            }
            catch { }
        }

        public void ustalanie()
        {
            if (maskedTextBox_Z11.Text.Length == 5 && maskedTextBoxZ12.Text.Length == 5 && maskedTextBoxZ21.Text.Length == 5
                && maskedTextBoxZ22.Text.Length == 5 && maskedTextBoxZ31.Text.Length == 5 && maskedTextBoxZ32.Text.Length == 5)
            {
                buttonUstal.Enabled = true;

                if (maskedTextBoxZ12.Text.Length == 5 && maskedTextBox_Z11.Text.Length == 5)
                {

                    DateTime GODZ1 = Convert.ToDateTime(maskedTextBoxZ12.Text);
                    DateTime GODZ2 = Convert.ToDateTime(maskedTextBox_Z11.Text);
                    if (GODZ1 < GODZ2)
                    {

                        labelZN1.Text = "Zmiana nocna";
                        labelZN1.ForeColor = Color.Red;
                    }
                }
                else
                {
                    labelZN1.Text = "";
                }

                if (maskedTextBoxZ21.Text.Length == 5 && maskedTextBoxZ22.Text.Length == 5)
                {
                    DateTime GODZ1 = Convert.ToDateTime(maskedTextBoxZ22.Text);
                    DateTime GODZ2 = Convert.ToDateTime(maskedTextBoxZ21.Text);
                    if (GODZ1 < GODZ2)
                    {
                        labelZN2.Text = "Zmiana nocna";
                        labelZN2.ForeColor = Color.Red;
                    }
                }
                else
                {
                    labelZN2.Text = "";
                }

                if (maskedTextBoxZ31.Text.Length == 5 && maskedTextBoxZ32.Text.Length == 5)
                {
                    DateTime GODZ1 = Convert.ToDateTime(maskedTextBoxZ32.Text);
                    DateTime GODZ2 = Convert.ToDateTime(maskedTextBoxZ31.Text);
                    if (GODZ1 < GODZ2)
                    {
                        labelZN3.Text = "Zmiana nocna";
                        labelZN3.ForeColor = Color.Red;
                    }
                }
                else
                {
                    labelZN3.Text = "";
                }
            }
            else
            {
                buttonUstal.Enabled = false;
            }
        }
        private void MaskedTextBox_Z11_TextChanged(object sender, EventArgs e)
        {
            ustalanie();
        }
        private void MaskedTextBoxZ12_TextChanged(object sender, EventArgs e)
        {
            ustalanie();
        }
        private void MaskedTextBoxZ21_TextChanged(object sender, EventArgs e)
        {
            ustalanie();
        }
        private void MaskedTextBoxZ22_TextChanged(object sender, EventArgs e)
        {
            ustalanie();
        }
        private void MaskedTextBoxZ31_TextChanged(object sender, EventArgs e)
        {
            ustalanie();
        }
        private void MaskedTextBoxZ32_TextChanged(object sender, EventArgs e)
        {
            ustalanie();
        }
        private void maskedTextBox_Z11_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Format";
                toolTip1.Show("Wprowadż godziny i minuty..", maskedTextBox_Z11, 5000);
                e.Cancel = true;
            }
        }
        private void maskedTextBoxZ12_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Format";
                toolTip1.Show("Wprowadż godziny i minuty..", maskedTextBoxZ12, 5000);
                e.Cancel = true;
            }
        }
        private void comboBoxUzytkownicyharmonogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            wczytajharmonogram();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(true);
        }
    }
}