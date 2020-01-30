using System;
using System.Data;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class Wnioski : Form
    {
        public Wnioski()
        {
            InitializeComponent();
        }

        private Wniosek cacheWniosek;
        private bool FlagaCzyZmieniono = false;
        private bool uprPrzeglad = false;
        private bool uprZatw = false;

        private void NowyWniosek()
        {
            cacheWniosek.Status = Status.SZKIC;
            cacheWniosek.Pracownik = RCPprogram.CreateInstance().Uzytkownik;
            if (cacheWniosek.TypWniosku == TypWniosku.DANE)
            {
                cacheWniosek.Imie = RCPprogram.CreateInstance().Uzytkownik.Imie;
                cacheWniosek.Nazwisko = RCPprogram.CreateInstance().Uzytkownik.Nazwisko;
                cacheWniosek.Opis = RCPprogram.CreateInstance().Uzytkownik.Email;
            }
        }
        public void NowyWniosekTyp(string typ)
        {
            switch (typ)
            {
                case "DANE":
                    cacheWniosek = new WniosekDane();
                    NowyWniosek();
                    break;
                case "URLOP":
                    cacheWniosek = new WniosekUrlop();
                    NowyWniosek();
                    break;
                case "NADGODZINY":
                    cacheWniosek = new WniosekNadgodziny();
                    NowyWniosek();
                    break;
                case "WOLNE":
                    cacheWniosek = new WniosekWolne();
                    NowyWniosek();
                    break;
                case "WYJSCIESLUZBOWE":
                    cacheWniosek = new WniosekWyjscie();
                    NowyWniosek();
                    break;
                case "NOWY":
                    cacheWniosek = new Wniosek();
                    NowyWniosek();
                    break;
                default:
                    break;
            }
        }
        private void ZaladujWniosekDoCache(DataGridViewRow row)
        {
            cacheWniosek.WypelnijWniosek((int)row.Cells[0].Value, (int)row.Cells[1].Value, (int)row.Cells[3].Value,
               (DateTime)row.Cells[2].Value, (DateTime)row.Cells[4].Value, (TypWniosku)row.Cells[5].Value, (Status)row.Cells[6].Value,
               (DateTime)row.Cells[7].Value, (DateTime)row.Cells[8].Value, row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), 
               row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString());
        }
        private void ZaladujGrid()
        {
            try
            {
                dataGridViewWnioski.Columns.Clear();
                Uzytkownik user;
                if (uprPrzeglad)
                {
                    string i = comboBoxUzytkownik.ValueMember;
                    DataRowView row = (DataRowView)comboBoxUzytkownik.SelectedItem;
                    int id = int.Parse(row.Row[i].ToString());
                    user = new Uzytkownik(id);
                }
                else
                {
                    user = RCPprogram.CreateInstance().Uzytkownik;
                }
                dataGridViewWnioski.DataSource = user.PrzegladWnioskow().DataSource;
                dataGridViewWnioski.Columns[2].Name = "Data sporządzenia";
                dataGridViewWnioski.Columns[2].DisplayIndex = 2;
                dataGridViewWnioski.Columns[0].Visible = false;
                dataGridViewWnioski.Columns[1].Visible = false;
                dataGridViewWnioski.Columns[3].Visible = false;
                dataGridViewWnioski.Columns[4].Visible = false;
                dataGridViewWnioski.Columns[7].Visible = false;
                dataGridViewWnioski.Columns[8].Visible = false;
                dataGridViewWnioski.Columns[9].Visible = false;
                dataGridViewWnioski.Columns[10].Visible = false;
                dataGridViewWnioski.Columns[11].Visible = false;
                dataGridViewWnioski.Columns[12].Visible = false;

                dataGridViewWnioski.Columns.Add("Typ", "Typ");
                int typ = dataGridViewWnioski.Columns["Typ"].Index;
                int typ_int = dataGridViewWnioski.Columns["typWniosku"].Index;
                foreach (DataGridViewRow row in this.dataGridViewWnioski.Rows)
                {
                    try
                    {
                        int value = Convert.ToInt32(row.Cells[typ_int].Value.ToString()); //int representation
                        row.Cells[typ].Value = (TypWniosku)value;
                    }
                    catch (NullReferenceException) { }
                }
                this.dataGridViewWnioski.Columns.Add("Status_c", "Status");
                int stat = dataGridViewWnioski.Columns["Status_c"].Index;
                int stat_int = dataGridViewWnioski.Columns["status"].Index;
                foreach (DataGridViewRow row in this.dataGridViewWnioski.Rows)
                {
                    try
                    {
                        int value = Convert.ToInt32(row.Cells[stat_int].Value.ToString()); //int representation
                        row.Cells[stat].Value = (Status)value;
                    }
                    catch (NullReferenceException) { }
                }
                this.dataGridViewWnioski.Columns[13].DisplayIndex = 0;
                this.dataGridViewWnioski.Columns[14].DisplayIndex = 1;
                this.dataGridViewWnioski.Columns[5].Visible = false;
                this.dataGridViewWnioski.Columns[6].Visible = false;

                this.dataGridViewWnioski.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(Exception ex)
            {
                string wiadomosc = "Inny błąd. Ładowanie grid się nie powiodło. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void FormWnioski_Load(object sender, EventArgs e)
        {
            dateTimePickerDataOd.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataDo.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataOd.CustomFormat = "d MMMM yyyy";
            dateTimePickerDataDo.CustomFormat = "d MMMM yyyy";

            if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF))
            {
                uprPrzeglad = true;
                uprZatw = false;
                labelUzytkownik.Visible = false;
                comboBoxUzytkownik.Visible = true;
                comboBoxUzytkownik.Text = RCPprogram.CreateInstance().Uzytkownik.Imie + " " +
                RCPprogram.CreateInstance().Uzytkownik.Nazwisko;
                try
                {
                    string komenda = "SELECT CONCAT(`Imie`,CONCAT(' ', `Nazwisko`)) As 'Nazwisko', `Id` FROM `uzytkownicy` WHERE `IdSzefa`=" +
                        RCPprogram.CreateInstance().Uzytkownik.ID;
                    DataTable dt = RCPprogram.CreateInstance().PobierzDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    DataRow row = dt.NewRow();
                    row["Nazwisko"] = RCPprogram.CreateInstance().Uzytkownik.Nazwisko+" "+ RCPprogram.CreateInstance().Uzytkownik.Imie; ;
                    row["Id"] = RCPprogram.CreateInstance().Uzytkownik.ID;
                    dt.Rows.InsertAt(row, 0);
                    comboBoxUzytkownik.DisplayMember = "Nazwisko";
                    comboBoxUzytkownik.ValueMember = "Id";
                    comboBoxUzytkownik.DataSource = dt;
                }
                catch(Exception ex)
                {
                    RCPprogram.CreateInstance().ZapiszLogBledu("Błąd na karcie Wnioski. Wiadomość: " + ex.Message);
                }
            }
            else
            {
                uprPrzeglad = false;
                uprZatw = false;
                comboBoxUzytkownik.Visible = false;
                labelUzytkownik.Visible = true;
                labelUzytkownik.Text = RCPprogram.CreateInstance().Uzytkownik.Imie+" "+ 
                RCPprogram.CreateInstance().Uzytkownik.Nazwisko;
            }

            ZaladujGrid();
            NowyWniosekTyp(TypWniosku.NOWY.ToString());
            WyswietlWniosek();
        }
        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.POLOG);
        }
        private void dataGridViewWnioski_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NowyWniosekTyp(((TypWniosku)dataGridViewWnioski.Rows[e.RowIndex].Cells[5].Value).ToString());
                ZaladujWniosekDoCache(dataGridViewWnioski.Rows[e.RowIndex]);
                WyswietlWniosek();
            }
            catch(Exception ex)
            {
                string wiadomosc = "Błąd na formularzu wnioski: ładowanie grid nie powiodło się. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void WyswietlWniosek()
        {
            //wyczyszczenie pól
            comboBoxTyp.Text = "";
            labelTypWniosku.Text = "";
            labelId.Text = "";
            labelDataWyst.Text = "";
            labelDataZatwierdzenia.Text = "";
            labelZatwierdzajacy.Text = "";
            dateTimePickerDataOd.Text = "";
            dateTimePickerDataDo.Text = "";
            textBoxOpisEdit.Text = "";
            textBoxOpisEdit.Enabled = false;
            textBoxImie.Text = "";
            textBoxNazwisko.Text = "";
            textBoxEmail.Text = "";
            textBoxImie.Enabled = true;
            textBoxNazwisko.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxOdpowiedz.Text = "";
            textBoxOdpowiedz.Enabled = false;

            labelStatus.Text = cacheWniosek.Status.ToString();
            if (cacheWniosek.Status == Status.SZKIC)
            {
                comboBoxTyp.Text = cacheWniosek.TypWniosku.ToString();
                comboBoxTyp.Show();
                labelTypWniosku.Hide();
                buttonWyslij.Show();
                buttonUsun.Hide();
                buttonZmien.Hide();
                buttonOdrzuc.Hide();
                buttonZatwierdz.Hide();
                textBoxOdpowiedz.Enabled = false;
                textBoxOpisEdit.Enabled = true;
            }
            else { 
                labelTypWniosku.Text = cacheWniosek.TypWniosku.ToString();
                comboBoxTyp.Hide();
                labelTypWniosku.Show();

                if (cacheWniosek.Status == Status.WYSLANY)
                {
                    buttonWyslij.Hide();
                    buttonUsun.Show();
                    buttonZmien.Show();
                    if (uprPrzeglad == true & uprZatw == true) { buttonOdrzuc.Show(); }
                    else { buttonOdrzuc.Hide(); }
                    if (uprPrzeglad == true & uprZatw == true) { buttonZatwierdz.Show(); }
                    else { buttonZatwierdz.Hide(); }
                    if (uprPrzeglad == true & uprZatw == true) { textBoxOdpowiedz.Enabled=true; }
                    else { textBoxOdpowiedz.Enabled = false; }
                    if (RCPprogram.CreateInstance().Uzytkownik.ID==cacheWniosek.Pracownik.ID) { textBoxOpisEdit.Enabled = true; }
                }
                if (cacheWniosek.Status == Status.ZATWIERDZONY)
                {
                    buttonWyslij.Hide();
                    buttonUsun.Show();
                    buttonZmien.Hide();
                    buttonOdrzuc.Hide();
                    buttonZatwierdz.Hide();
                    textBoxOdpowiedz.Enabled = false;
                }
                if (cacheWniosek.Status == Status.ODRZUCONY)
                {
                    buttonWyslij.Hide();
                    buttonUsun.Hide();
                    buttonZmien.Hide();
                    buttonOdrzuc.Hide();
                    buttonZatwierdz.Hide();
                    textBoxOdpowiedz.Enabled = false;
                }
            }
            
            labelId.Text = cacheWniosek.ID.ToString();
            labelDataWyst.Text = cacheWniosek.DataWystawienia.ToString("d", Toolbox.kultura);
            if (cacheWniosek.DataZatwierdzenia == DateTime.MinValue) { labelDataZatwierdzenia.Text = ""; }
            else { labelDataZatwierdzenia.Text = cacheWniosek.DataZatwierdzenia.Date.ToString("d", Toolbox.kultura); }
            try { labelZatwierdzajacy.Text = cacheWniosek.Zatwierdzajacy.Nazwisko; }
            catch { }
            textBoxOdpowiedz.Text = cacheWniosek.Odpowiedz;

            //nowy wniosek - ukrywamy panele
            if (cacheWniosek.TypWniosku == TypWniosku.NOWY)
            {
                panelCzasWolny.Hide();
                panelDane.Hide();
            }

            //panel CzasWolny: DataOd, DataDo, OpisEdit
            if (cacheWniosek.TypWniosku == TypWniosku.URLOP)
            {
                panelCzasWolny.Show();
                dateTimePickerDataOd.CustomFormat = "d MMMM yyyy";
                dateTimePickerDataDo.CustomFormat = "d MMMM yyyy";
                panelDane.Hide();
              
                try { dateTimePickerDataOd.Text = cacheWniosek.CzasOd.Date.ToString(); }
                catch {dateTimePickerDataOd.Text = ""; }
                try { dateTimePickerDataDo.Text = cacheWniosek.CzasDo.Date.ToString(); }
                catch { dateTimePickerDataDo.Text = "";}
                textBoxOpisEdit.Text = cacheWniosek.Opis;
            }
            if (cacheWniosek.TypWniosku == TypWniosku.NADGODZINY | 
                cacheWniosek.TypWniosku == TypWniosku.WOLNE |
                cacheWniosek.TypWniosku == TypWniosku.WYJSCIESLUZBOWE)
            {
                panelCzasWolny.Show();
                dateTimePickerDataOd.CustomFormat = "dd-MM-yyyy HH:mm";
                dateTimePickerDataDo.CustomFormat = "dd-MM-yyyy HH:mm";
                panelDane.Hide();
                if (cacheWniosek.CzasOd == DateTime.MinValue) { dateTimePickerDataOd.Text = ""; }
                else { dateTimePickerDataOd.Text = cacheWniosek.CzasOd.ToString("g", Toolbox.kultura); }
                if (cacheWniosek.CzasDo == DateTime.MinValue) { dateTimePickerDataDo.Text = ""; }
                else { dateTimePickerDataDo.Text = cacheWniosek.CzasDo.ToString("g", Toolbox.kultura); }
                textBoxOpisEdit.Text = cacheWniosek.Opis;
            }
            //panel Dane: CzasOd, Imie, Nazwisko, Email
            if (cacheWniosek.TypWniosku == TypWniosku.DANE)
            {
                panelDane.Show();
                panelCzasWolny.Hide();
                if (cacheWniosek.Status == Status.SZKIC) {
                    textBoxImie.Text = cacheWniosek.Imie;
                    textBoxNazwisko.Text = cacheWniosek.Nazwisko;
                    textBoxEmail.Text = cacheWniosek.Opis;
                }
                else
                {
                    textBoxImie.Text = cacheWniosek.Imie;
                    textBoxImie.Enabled = false;
                    textBoxNazwisko.Text = cacheWniosek.Nazwisko;
                    textBoxNazwisko.Enabled = false;
                    textBoxEmail.Text = cacheWniosek.Opis;
                    textBoxEmail.Enabled = false;
                }
            }
            //reset flagi i błędów
            labelError.Text = "";
            FlagaCzyZmieniono = false;
        }
        private void Wnioski_FormClosed(object sender, FormClosedEventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(true);
        }
        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(false);
        }
        private void buttonNowy_Click(object sender, EventArgs e)
        {
            if (FlagaCzyZmieniono)
            {
                string message = "Dane zmienione we wniosku nie zostaną zapisane. " +
                    "Czy chcesz kontynuować i utworzyć nowy wniosek?" +
                    "Kliknij <Nie> aby wrócić do poprzedniego wniosku.";
                string caption = "Ostrzeżenie";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    NowyWniosekTyp(TypWniosku.NOWY.ToString());
                    WyswietlWniosek();
                }
            }
            else
            {
                NowyWniosekTyp(TypWniosku.NOWY.ToString());
                WyswietlWniosek();
            }
        }
        private void comboBoxTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            NowyWniosekTyp(comboBoxTyp.Text);

            if (cacheWniosek.TypWniosku == TypWniosku.NOWY)
            {
                panelCzasWolny.Hide();
                panelDane.Hide();
            }

            if (cacheWniosek.TypWniosku == TypWniosku.URLOP |
                cacheWniosek.TypWniosku == TypWniosku.NADGODZINY |
                cacheWniosek.TypWniosku == TypWniosku.WOLNE |
                cacheWniosek.TypWniosku == TypWniosku.WYJSCIESLUZBOWE)
            {
                panelCzasWolny.Show();
                panelDane.Hide();
            }

            if (cacheWniosek.TypWniosku == TypWniosku.DANE)
            {
                panelCzasWolny.Hide();
                panelDane.Show();
            }
            WyswietlWniosek();
        }
        private void buttonWyslij_Click(object sender, EventArgs e)
        {
            //założenie - mamy nowy wniosek, bo przy innych statusach przycisk "Wyślij" się nie wyświetla.
            try
            {
                if (!(labelError.Text == "")) { throw new IncompleteException(); }
                if (cacheWniosek.TypWniosku == TypWniosku.NOWY)
                {
                    labelError.Text = "Wybierz typ wniosku i uzupełnij dane";
                }
                else
                {
                    Waliduj(cacheWniosek.TypWniosku, cacheWniosek.Status);
                int wskaznik = 0;
                try { wskaznik = dataGridViewWnioski.CurrentCell.RowIndex; }
                catch(NullReferenceException) { }
                    cacheWniosek.Wyslij();
                    ZaladujGrid();
                    WyswietlWniosek();
                    dataGridViewWnioski.Rows[wskaznik].Cells[2].Selected = true;
                    labelError.Text = "";
                }
            }
            catch (IncompleteException)
            {
                labelError.Text += " (!)Podaj wymagane dane ";
            }
            catch (FormatException fex)
            {
                string wiadomosc = "Nieprawidłowy format danych przy próbie wysłania wniosku " + cacheWniosek.ID + ". Wiadomość: " + fex.Message;
                labelError.Text += " Nieprawidłowy format danych: "+ fex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
            catch (MySql.Data.MySqlClient.MySqlException bx)
            {
                string wiadomosc = "Błąd bazy przy próbie wysłania wniosku " + cacheWniosek.ID + ". Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                labelError.Text = "Błąd połączenia z bazą danych. Wniosek nie został wysłany. ";
            }
            catch (Exception ex)
            {
                labelError.Text = "Inny błąd. Skontaktuj się z administratorem.";
                string wiadomosc = "Inny błąd przy próbie wysłania wniosku "+cacheWniosek.ID+". Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void Waliduj(TypWniosku typWniosku, Status status)
        {
            labelError.Text = "";
            switch (typWniosku)
            {
                case TypWniosku.DANE:
                    cacheWniosek.Imie = Toolbox.inputString(textBoxImie.Text, true, 30);
                    cacheWniosek.Nazwisko = Toolbox.inputString(textBoxNazwisko.Text, true, 30); 
                    string email = Toolbox.inputString(textBoxEmail.Text, true, 50);
                    if (!Toolbox.walidacjaEmail(email, false))
                    {
                        labelError.Text = "Nieprawidłowy adres e-mail. ";
                        throw new IncompleteException();
                    }
                    cacheWniosek.Opis = email;
                    break;
                case TypWniosku.URLOP:
                    cacheWniosek.CzasOd = dateTimePickerDataOd.Value;
                    cacheWniosek.CzasDo = dateTimePickerDataDo.Value;
                    cacheWniosek.Opis = Toolbox.inputString(textBoxOpisEdit.Text, true, 500); 
                    break;
                case TypWniosku.NADGODZINY:
                    cacheWniosek.CzasOd = dateTimePickerDataOd.Value;
                    cacheWniosek.CzasDo = dateTimePickerDataDo.Value;
                    cacheWniosek.Opis = Toolbox.inputString(textBoxOpisEdit.Text, true, 500);
                    break;
                case TypWniosku.WOLNE:
                    cacheWniosek.CzasOd = dateTimePickerDataOd.Value;
                    cacheWniosek.CzasDo = dateTimePickerDataDo.Value;
                    cacheWniosek.Opis = Toolbox.inputString(textBoxOpisEdit.Text, true, 500);
                    break;
                case TypWniosku.WYJSCIESLUZBOWE:
                    cacheWniosek.CzasOd = dateTimePickerDataOd.Value;
                    cacheWniosek.CzasDo = dateTimePickerDataDo.Value;
                    cacheWniosek.Opis = Toolbox.inputString(textBoxOpisEdit.Text, true, 500);
                    break;
                case TypWniosku.NOWY:
                    labelError.Text = "Wybierz typ wniosku i uzupełnij dane";
                    throw new Exception("Wybierz typ wniosku i uzupełnij dane");
                default:
                    labelError.Text = "Wybierz typ wniosku i uzupełnij dane";
                    throw new Exception("Wybierz typ wniosku i uzupełnij dane");
            }
            switch (status)
            {
                case Status.SZKIC:
                    break;
                case Status.WYSLANY:
                    cacheWniosek.Odpowiedz = Toolbox.inputString(textBoxOdpowiedz.Text, true, 500); 
                    break;
                case Status.ZATWIERDZONY:
                    cacheWniosek.Odpowiedz = textBoxOdpowiedz.Text + " (Usunięto wniosek "+DateTime.Now.ToString("dd.MM.yyyy") + ")";
                    break;
                case Status.ODRZUCONY:
                    break;
                default:
                    labelError.Text = "Nieznany status wniosku";
                    throw new Exception("Nieznany status wniosku");
            }
        }
        private void buttonZmien_Click(object sender, EventArgs e)
        {
            try
            {
                int wskaznik = dataGridViewWnioski.CurrentCell.RowIndex;
                Waliduj(cacheWniosek.TypWniosku, cacheWniosek.Status);
                cacheWniosek.ZapiszZmiany();
                ZaladujGrid();
                //WyswietlWniosek();
                dataGridViewWnioski.Rows[wskaznik].Cells[2].Selected = true;
            }
            catch (IncompleteException)
            {
                labelError.Text += "Podaj wymagane dane";
            }
            catch(Exception ex)
            {
                string wiadomosc = "Inny błąd przy próbie zmiany wniosku "+cacheWniosek.ID+". Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void buttonUsun_Click(object sender, EventArgs e)
        {
            if (cacheWniosek.Status == Status.WYSLANY)
            {
                //mogę usunąć swoje wnioski wysłane
                try
                {
                    cacheWniosek.Usun();
                    ZaladujGrid();
                    NowyWniosekTyp(TypWniosku.NOWY.ToString());
                    WyswietlWniosek();
                }
                catch (MySql.Data.MySqlClient.MySqlException bx)
                {
                    string wiadomosc = "Błąd bazy przy próbie usunięcia wniosku " + cacheWniosek.ID + ". Wiadomość: " + bx.Message;
                    RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                    labelError.Text += "Błąd połaczenia z bazą danych. Nie usunięto wniosku.";
                }
                catch (Exception ex)
                {
                    labelError.Text += "Inny błąd. Skontaktuj się z administratorem.";
                    string wiadomosc = "Inny błąd przy próbie usunięcia wniosku " + cacheWniosek.ID + ". Wiadomość: " + ex.Message;
                    RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                }
            }
            if (cacheWniosek.Status == Status.ZATWIERDZONY)
            {
                //zmiana statusu na odrzucony
                try
                {
                    DataGridViewCell wskaznik = dataGridViewWnioski.CurrentCell;
                    Waliduj(cacheWniosek.TypWniosku, cacheWniosek.Status);
                    cacheWniosek.Status = Status.ODRZUCONY;
                    cacheWniosek.ZapiszZmiany();
                    ZaladujGrid();
                    WyswietlWniosek();
                    dataGridViewWnioski.CurrentCell=wskaznik;
                }
                catch (MySql.Data.MySqlClient.MySqlException bx)
                {
                    cacheWniosek.Status = Status.ZATWIERDZONY;
                    string wiadomosc = "Błąd bazy przy próbie usunięcia wniosku zatwierdzonego " + cacheWniosek.ID + ". Wiadomość: " + bx.Message;
                    RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                    labelError.Text += "Błąd połaczenia z bazą. Nie zmieniono statusu.";
                }
                catch (Exception ex)
                {
                    cacheWniosek.Status = Status.ZATWIERDZONY;
                    labelError.Text += "Inny błąd. Skontaktuj się z administratorem.";
                    string wiadomosc = "Inny błąd przy próbie usunięcia wniosku zatwierdzonego " + cacheWniosek.ID + ". Wiadomość: " + ex.Message;
                    RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                }
            }
        }
        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                int wskaznik;
                try { wskaznik = dataGridViewWnioski.CurrentCell.RowIndex; } catch { wskaznik = dataGridViewWnioski.RowCount-2; }
                Waliduj(cacheWniosek.TypWniosku, cacheWniosek.Status);
                cacheWniosek.Zatwierdz();
                ZaladujGrid();
                //WyswietlWniosek();
                dataGridViewWnioski.Rows[wskaznik].Cells[2].Selected = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException bx)
            {
                string wiadomosc = "Błąd bazy przy próbie zatwierdzenia wniosku " + cacheWniosek.ID + ". Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                labelError.Text += "Błąd połaczenia z bazą danych. Nie zatwierdzono wniosku.";
            }
            catch (Exception ex)
            {
                labelError.Text += "Inny błąd. Skontaktuj się z administratorem.";
                string wiadomosc = "Inny błąd przy próbie zatwierdzenia wniosku " + cacheWniosek.ID + ". Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void buttonOdrzuc_Click(object sender, EventArgs e)
        {
            try
            {
                int wskaznik = dataGridViewWnioski.CurrentCell.RowIndex;
                Waliduj(cacheWniosek.TypWniosku, cacheWniosek.Status);
                cacheWniosek.Odrzuc();
                ZaladujGrid();
                //WyswietlWniosek();
                dataGridViewWnioski.Rows[wskaznik].Cells[2].Selected = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException bx)
            {
                string wiadomosc = "Błąd bazy przy próbie odrzucenia wniosku " + cacheWniosek.ID + ". Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                labelError.Text += "Błąd połaczenia z bazą danych. Nie odrzucono wniosku.";
            }
            catch (Exception ex)
            {
                labelError.Text += "Inny błąd. Skontaktuj się z administratorem.";
                string wiadomosc = "Inny błąd przy próbie odrzucenia wniosku " + cacheWniosek.ID + ". Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }
        private void comboBoxUzytkownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            string i = comboBoxUzytkownik.ValueMember;
            DataRowView row = (DataRowView)comboBoxUzytkownik.SelectedItem;
            int id = int.Parse(row.Row[i].ToString());
            if (id.Equals(RCPprogram.CreateInstance().Uzytkownik.ID))
            {
                uprZatw = false;
                ZaladujGrid();
            }
            else {
                uprZatw = true;
                ZaladujGrid();
            }
        }
        private void labelError_TextChanged(object sender, EventArgs e)
        {
            if (labelError.Text == "")
            {
                panelError.Visible = false;
            }
            else
            {
                panelError.Visible = true;
            }
        }
    }
}
