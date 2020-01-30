using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.Security;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class FormUzytkownicy : Form
    {
        private int wskazanyId;
        DataGridViewRow cacheRow;
        DataTable szef_tab;

        public FormUzytkownicy()
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_list_CellClick);
        }
        private void wczytajliste()
        {
            try
            {
                dataGridView1.Columns.Clear();
                string komenda = "";
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) ||
                    RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY)) {
                    komenda = "SELECT Id, Imie, Nazwisko, STANOWISKO, Email, Grupa, IdSzefa FROM uzytkownicy";
                }
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF)) {
                    komenda = "SELECT Id, Imie, Nazwisko, STANOWISKO, Email, Grupa, IdSzefa FROM uzytkownicy WHERE IdSzefa="+
                        RCPprogram.CreateInstance().Uzytkownik.ID;
                }

                dataGridView1.DataSource = RCPprogram.CreateInstance().PobierzDane(komenda, new MySqlParameter[0]);

                DataView custView = new DataView(szef_tab, "", "Id", DataViewRowState.CurrentRows);

                dataGridView1.Columns.Add("Uprawnienia", "Uprawnienia");
                int gr = dataGridView1.Columns["Grupa"].Index;
                int upr = dataGridView1.Columns["Uprawnienia"].Index;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        int value = int.Parse(row.Cells[gr].Value.ToString());
                        row.Cells[upr].Value = (Grupa)value;
                    }
                    catch (NullReferenceException) { }
                }
                dataGridView1.Columns.Add("Przelozony", "Przełożony");
                int szef = dataGridView1.Columns["IdSzefa"].Index;
                int przelozony = dataGridView1.Columns["Przelozony"].Index;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        string value = row.Cells[szef].Value.ToString();
                        string kwerenda = "Id=" + value;
                        int rowIndex = custView.Find(value);
                        if (rowIndex == -1)
                        { throw new NullReferenceException(); }
                        else
                        {
                            row.Cells[przelozony].Value = custView[rowIndex]["Nazwisko"].ToString();
                        }
                    }
                    catch (NullReferenceException) { }
                }
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].Width = 30;
            }
            catch (Exception ex)
            {
                string wiadomosc = "Błąd na formularzu użytkowników: ładowanie grid nie powiodło się. Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
            }
        }    
        private void dataGridView1_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                cacheRow = this.dataGridView1.Rows[e.RowIndex];

                textBoxImie.Text = cacheRow.Cells[1].Value.ToString();
                textBoxNazwisko.Text = cacheRow.Cells[2].Value.ToString();
                textBoxStanowisko.Text = cacheRow.Cells[3].Value.ToString();
                Grupa gr = (Grupa)Enum.Parse(typeof(Grupa), cacheRow.Cells[5].Value.ToString());
                comboBoxGrupy.Text = gr.ToString();
                textBoxEmail.Text = cacheRow.Cells[4].Value.ToString();
                if(cacheRow.Cells[8].Value==null)
                {
                    comboBoxSzef.Text = "";
                }
                else
                {
                    comboBoxSzef.Text = cacheRow.Cells[8].Value.ToString();
                }
               
                wskazanyId = int.Parse(cacheRow.Cells[0].Value.ToString());
                WczytajGridOdbicia();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            dateTimePickerDataod.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataod.CustomFormat = "yyyy-MM-dd";
            dateTimePickerDataod.Value = DateTime.Now.AddMonths(-1).Date;

            dateTimePickerDatado.Format = DateTimePickerFormat.Custom;
            dateTimePickerDatado.CustomFormat = "yyyy-MM-dd";
            dateTimePickerDatado.Value = DateTime.Now;

            try
            {
                string komendaa = "SELECT CONCAT(`Nazwisko`,CONCAT(' ', `Imie`)) As 'Nazwisko', `Id` FROM `uzytkownicy` " +
                                    "WHERE `Grupa`=8";
                szef_tab = RCPprogram.CreateInstance().PobierzDane(komendaa, new MySqlParameter[0]);
            }
            catch
            {
                szef_tab = new DataTable();
                DataColumn col = new DataColumn("Nazwisko");
                szef_tab.Columns.Add(col);
                col = new DataColumn("Id");
                szef_tab.Columns.Add(col);
            }
            
                if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY))
            {
                groupBoxEdycja.Visible = true;
                comboBoxGrupy.Items.Add(Grupa.ADMINISTRATOR.ToString());
                comboBoxGrupy.Items.Add(Grupa.PRACOWNIK.ToString());
                comboBoxGrupy.Items.Add(Grupa.SZEF.ToString());
                comboBoxGrupy.Items.Add(Grupa.PERSONALNY.ToString());
                comboBoxGrupy.Items.Add(Grupa.KADROWY.ToString());
                comboBoxGrupy.Items.Add(Grupa.ZABLOKOWANY.ToString());

                comboBoxSzef.DisplayMember = "Nazwisko";
                comboBoxSzef.ValueMember = "Id";
                comboBoxSzef.DataSource = szef_tab;
            }
            else
            {
                groupBoxEdycja.Visible = false;
            }

            if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY))
            {
                groupBoxDodawanie.Visible = true;
                comboBoxGrupaDodaj.Items.Add(Grupa.ADMINISTRATOR.ToString());
                comboBoxGrupaDodaj.Items.Add(Grupa.PRACOWNIK.ToString());
                comboBoxGrupaDodaj.Items.Add(Grupa.SZEF.ToString());
                comboBoxGrupaDodaj.Items.Add(Grupa.PERSONALNY.ToString());
                comboBoxGrupaDodaj.Items.Add(Grupa.KADROWY.ToString());

                comboBoxSzefDodaj.DisplayMember = "Nazwisko";
                comboBoxSzefDodaj.ValueMember = "Id";
                comboBoxSzefDodaj.DataSource = szef_tab.Copy();

                ToolTip toolTip1 = new ToolTip();
                toolTip1.SetToolTip(buttonDodajUzytkownika, "Jeśli dodasz użytkownika, hasło zostanie mu wysłane mailem.");
            }
            else
            {
                groupBoxDodawanie.Visible = false;
            }
            wczytajliste();
        }
        private void ButtonEdytuj_Click(object sender, EventArgs e)
        {
            string log = "Użytkownicy:Edycja [0] ";
            log += cacheinfo(cacheRow);
            try { 
                string email = Toolbox.inputString(textBoxEmail.Text, true, 80, "");
                bool walidacja = Toolbox.walidacjaEmail(email, false);
                if (walidacja == false)
                {
                    throw new FormatException("Błędny adres e-mail. ");
                }
                string imie = Toolbox.inputString(textBoxImie.Text, true, 80, "");
                string nazwisko = Toolbox.inputString(textBoxNazwisko.Text, true, 80, "");
                string stanowisko = Toolbox.inputString(textBoxStanowisko.Text, true, 80, "");

                Grupa gr = (Grupa)Enum.Parse(typeof(Grupa), comboBoxGrupy.Text);
                int grupa = (int)gr;
                DataRowView row = (DataRowView)comboBoxSzef.SelectedItem;
                string idszefa = row.Row["Id"].ToString();
                MySqlParameter[] param = new MySqlParameter[4];
                param[0] = new MySqlParameter("@imie", MySqlDbType.VarChar);
                param[0].Value = imie;
                param[1] = new MySqlParameter("@nazwisko", MySqlDbType.VarChar);
                param[1].Value = nazwisko;
                param[2] = new MySqlParameter("@email", MySqlDbType.VarChar);
                param[2].Value = email;
                param[3] = new MySqlParameter("@stanowisko", MySqlDbType.VarChar);
                param[3].Value = stanowisko;

                string komenda = "UPDATE uzytkownicy SET " +
                    "`Imie`=@imie, `Nazwisko`=@nazwisko, " +
                    "`STANOWISKO`=@stanowisko, `Grupa`='" + grupa + "', `Email`=@email" +
                    ", `IdSzefa`=" + idszefa + " where `Id`='" + wskazanyId + "'";
                RCPprogram.CreateInstance().ZaktualizujDane(komenda, param);
                log += "[1] ";
                log += cacheinfoEdytuj(); 
            }
            catch (FormatException ix)
            {
                string wiadomosc = ix.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show(wiadomosc);
            }
            catch (MySqlException ex)
            {
                string wiadomosc = "Błąd połączenia z bazą danych. Numer: " + ex.Number.ToString()
                    + " Wiadomość: " + ex.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show(wiadomosc);
            }
            catch (Exception g)
            {
                string wiadomosc = "Nieznany błąd przy próbie edycji użytkownika "+ wskazanyId + ". "
                    + " Wiadomość: " + g.Message;
                log += "[err] " + wiadomosc;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show(wiadomosc);
            }
            finally {
                RCPprogram.CreateInstance().ZapiszLog(log);
                wczytajliste();
                wyczyscPolaEdytuj(); 
            }
        }
        private void ButtonResetHasla_Click(object sender, EventArgs e)
        {
            string log = "Użytkownicy:Reset hasła [0] ";
            log += cacheinfo(cacheRow);
            try
            {
                string email = Toolbox.inputString(textBoxEmail.Text, true, 80, "");
                bool walidacja = Toolbox.walidacjaEmail(email, false);
                if (walidacja == false)
                {
                    throw new FormatException("Nieprawidłowy adres e-mail. ");
                }
                string password = Membership.GeneratePassword(12, 1);
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@email", MySqlDbType.VarChar);
                param[0].Value = email;
                RCPprogram.CreateInstance().ZaktualizujDane("UPDATE uzytkownicy set Haslo = SHA2('" + password + "',256) where Email=@email", param);

                wczytajliste();
                RCPprogram.CreateInstance().WyslijEmail(email, "Twoje nowe hasło do systemu to :" + password, "Nowe hasło RCP");
            }
            catch (FormatException ix)
            {
                string wiadomosc = ix.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show(wiadomosc);
            }
            catch (MySqlException ex)
            {
                string wiadomosc = "Błąd połączenia z bazą danych. Numer: "+ ex.Number.ToString()
                    +" Wiadomość: " + ex.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show(wiadomosc);
            }
            catch (System.Net.Mail.SmtpException f)
            {
                string wiadomosc = "Błąd połączenia ze skrzynką e-mail."
                    + " Wiadomość: " + f.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show(wiadomosc);
            }
            catch (Exception g)
            {
                string wiadomosc = "Nieznany błąd przy próbie resetu hasła użytkownika. "
                    + " Wiadomość: " + g.Message;
                log += "[err] " + wiadomosc;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show(wiadomosc);
            }
            finally
            {
                RCPprogram.CreateInstance().ZapiszLog(log);
            }
        }
        private void buttonUsun_Click(object sender, EventArgs e)
        {

            string id = RCPprogram.CreateInstance().PobierzElement(@"select id from uzytkownicy where Email='" + textBoxEmail.Text + "' ", new MySqlParameter[0]);
            if (id=="1")
            {
                MessageBox.Show("Nie można usunąć administratora");
            }
            else
            { 
            if (MessageBox.Show("Czy na pewno chcesz usunąć" + textBoxEmail.Text + " ?", "Usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string log = "Użytkownicy:Usuń [0] ";
                log += cacheinfo(cacheRow);
                bool sprawdzczyadmin = sprawdzczykontoglowne();
                if (sprawdzczyadmin == true)
                {
                    string wiadomosc = "Nie można usunąć głównego konta";
                    log += "[err] " + wiadomosc;
                    MessageBox.Show(wiadomosc);
                }
                else
                {
                    try
                    {
                        string email = Toolbox.inputString(textBoxEmail.Text, true, 80, "");
                        bool walidacja = Toolbox.walidacjaEmail(email, false);
                        if (walidacja == false)
                        {
                            throw new FormatException("Nieprawidłowy adres e-mail. ");
                        }
                        MySqlParameter[] param = new MySqlParameter[1];
                        param[0] = new MySqlParameter("@email", MySqlDbType.VarChar);
                        param[0].Value = email;
                        RCPprogram.CreateInstance().ZaktualizujDane("delete from uzytkownicy where Email = @email", param);
                        MessageBox.Show("Użytkownik" + email + "został usunięty");
                        wczytajliste();
                        wyczyscPolaEdytuj();
                    }
                    catch (FormatException ix)
                    {
                        string wiadomosc = ix.Message;
                        log += "[err] " + wiadomosc;
                        MessageBox.Show(wiadomosc);
                    }
                    catch (MySqlException ex)
                    {
                        string wiadomosc = "Błąd połączenia z bazą danych. Numer: " + ex.Number.ToString()
                            + " Wiadomość: " + ex.Message;
                        log += "[err] " + wiadomosc;
                        MessageBox.Show(wiadomosc);
                    }
                    catch (Exception g)
                    {
                        string wiadomosc = "Nieznany błąd przy próbie usunięcia użytkownika. "
                            + " Wiadomość: " + g.Message;
                        log += "[err] " + wiadomosc;
                        RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                        MessageBox.Show(wiadomosc);
                    }
                }
                RCPprogram.CreateInstance().ZapiszLog(log);
            }
            }
        }
        private bool sprawdzczykontoglowne()
        {
            DataTable dt = new DataTable();
            string email;
            try
            {
                email = Toolbox.inputString(textBoxEmail.Text, true, 80, "");
                bool walidacja = Toolbox.walidacjaEmail(email, false);
                if (walidacja == false)
                {
                    return false;
                }
            }
            catch { return false; }
            try
            {
                string komenda = "SELECT Id FROM uzytkownicy where Email = @email";
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter();
                param[0].Value = email;
                dt = RCPprogram.CreateInstance().PobierzDane(komenda, param);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException bx)
            {
                string wiadomosc = "Błąd bazy przy sprawdzaniu czy konto główne. "
                 + " Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                return false;
            }
            catch(Exception ex)
            {
                string wiadomosc = "Nieznany błąd przy sprawdzaniu czy konto główne. "
                                 + " Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                return false;
            }
        }
        private bool sprawdzczykontoistnieje()
        {
            DataTable dt = new DataTable();
            string email;
            try
            {
                email = Toolbox.inputString(textBoxEmailDodaj.Text, true, 80, "");
                bool walidacja = Toolbox.walidacjaEmail(email, false);
                if (walidacja == false)
                {
                    return false;
                }
            }
            catch { return false; }

            try
            {
                string komenda = "SELECT Id FROM uzytkownicy where Email = @email";
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter();
                param[0].Value = email;
                dt = RCPprogram.CreateInstance().PobierzDane(komenda, param);
                if (dt.Rows.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException bx)
            {
                string wiadomosc = "Błąd bazy przy sprawdzaniu czy konto istnieje. "
                 + " Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                return false;
            }
            catch (Exception ex)
            {
                string wiadomosc = "Nieznany błąd przy sprawdzaniu czy konto istnieje. "
                                 + " Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                return false;
            }
        }
        private void wyczyscPolaDodaj()
        {
            textBoxImieDodaj.Text = "";
            textBoxNazwiskoDodaj.Text = "";
            textBoxStanowiskoDodaj.Text = "";
            comboBoxGrupaDodaj.Text = "";
            textBoxEmailDodaj.Text = "";
            comboBoxSzefDodaj.Text = "";
        }
        private void wyczyscPolaEdytuj()
        {
            textBoxImie.Text = "";
            textBoxNazwisko.Text = "";
            textBoxStanowisko.Text = "";
            comboBoxGrupy.Text = "";
            textBoxEmail.Text = "";
            comboBoxSzef.Text = "";
        }
        private void FormUzytkownicy_FormClosed(object sender, FormClosedEventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(true);
        }
        private void buttonPowrot_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.POLOG);
        }
        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(false);
        }
        private void ButtonDodajUzytkownika_Click(object sender, EventArgs e)
        {
            if (sprawdzczykontoistnieje())
            {
                MessageBox.Show("Konto o takim adresie e-mail już istnieje. Podaj inny adres.");
                return;
            }
            string log = "Użytkownicy:Dodaj użytkownika [0] ";
            try
            {
                string email = Toolbox.inputString(textBoxEmailDodaj.Text, true, 80, "");
                bool walidacja = Toolbox.walidacjaEmail(email, false);
                if (walidacja == false)
                {
                    throw new FormatException("Błędny adres e-mail. ");
                }
                string imie = Toolbox.inputString(textBoxImieDodaj.Text, true, 80, "");
                string nazwisko = Toolbox.inputString(textBoxNazwiskoDodaj.Text, true, 80, "");
                string stanowisko = Toolbox.inputString(textBoxStanowiskoDodaj.Text, true, 80, "");
                string password = Membership.GeneratePassword(12, 1);
                Grupa gr = (Grupa)Enum.Parse(typeof(Grupa), comboBoxGrupaDodaj.Text);
                int grupa = (int)gr;
                DataRowView row = (DataRowView)comboBoxSzefDodaj.SelectedItem;
                string idszefa = row.Row["Id"].ToString();

                MySqlParameter[] param = new MySqlParameter[4];
                param[0] = new MySqlParameter("@imie", MySqlDbType.VarChar);
                param[0].Value = imie;
                param[1] = new MySqlParameter("@nazwisko", MySqlDbType.VarChar);
                param[1].Value = nazwisko;
                param[2] = new MySqlParameter("@email", MySqlDbType.VarChar);
                param[2].Value = email;
                param[3] = new MySqlParameter("@stanowisko", MySqlDbType.VarChar);
                param[3].Value = stanowisko;

                string komenda ="INSERT INTO `uzytkownicy` (`Id`, `Imie`, `Nazwisko`, `STANOWISKO`, `Grupa`, `Email`, `Haslo`, `IdSzefa`) VALUES" +
                 "('', @imie, @nazwisko, @stanowisko'," + grupa + " , @email, SHA2('" + password + "',256), " + idszefa + ")";
                RCPprogram.CreateInstance().DodajDane(komenda, param);
                log += "[1] "; 
                log += cacheinfoDodaj();
                RCPprogram.CreateInstance().WyslijEmail(email, "Twoje nowe hasło do systemu to :" + password, "Nowe hasło RCP");
                wyczyscPolaDodaj();
            }
            catch (FormatException ix)
            {
                string wiadomosc = ix.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show(wiadomosc);
            }
            catch (MySqlException ex)
            {
                string wiadomosc = "Błąd połączenia z bazą danych. Numer: " + ex.Number.ToString()
                    + " Wiadomość: " + ex.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show("Błąd połączenia z bazą danych.");
            }
            catch (System.Net.Mail.SmtpException f)
            {
                string wiadomosc = "Błąd połączenia ze skrzynką e-mail."
                    + " Wiadomość: " + f.Message;
                log += "[err] " + wiadomosc;
                MessageBox.Show("Błąd połączenia ze skrzynką e-mail.");
            }
            catch (Exception g)
            {
                string wiadomosc = "Nieznany błąd. "
                    + " Wiadomość: " + g.Message;
                log += "[err] " + wiadomosc;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show("Nieznany błąd. Skontaktuj się z administratorem.");
            }
            finally {
                RCPprogram.CreateInstance().ZapiszLog(log);
                wczytajliste();
            }
        }
        private void WczytajGridOdbicia()
        {
            dataGridViewOdbicia.Columns.Clear();
            try
            {
                Uzytkownik user = new Uzytkownik(wskazanyId);
                this.dataGridViewOdbicia.DataSource = user.PrzegladOdbicData(dateTimePickerDataod.Text, dateTimePickerDatado.Text);
                this.dataGridViewOdbicia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (MySqlException bx)
            {
                string wiadomosc = "Błąd bazy przy wczytywaniu grid z odbiciami. "
                            + " Wiadomość: " + bx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show("Błąd połaczenia z bazą danych. Nie można było wczytać odbić użytkownika.");
            }
            catch(Exception ex)
            {
                string wiadomosc = "Inny błąd przy wczytywaniu grid z odbiciami. "
                 + " Wiadomość: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu(wiadomosc);
                MessageBox.Show("Inny błąd. Nie można było wczytać odbić użytkownika. Skontaktuj się z administratorem.");
            }
        }
        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            WczytajGridOdbicia();
        }
        private string cacheinfo(DataGridViewRow dataRow)
        {
            string info = dataRow.Cells[0].Value.ToString();
            info += " ";
            info += dataRow.Cells[1].Value.ToString();
            info += " ";
            info += dataRow.Cells[2].Value.ToString();
            info += " ";
            info += dataRow.Cells[3].Value.ToString();
            info += " ";
            info += dataRow.Cells[5].Value.ToString();
            info += " ";
            info += dataRow.Cells[4].Value.ToString();
            info += " [Przełożony: ";
            info += dataRow.Cells[6].Value.ToString();
            info += "] ";
            return info;
        }
        private string cacheinfoEdytuj()
        {
            string info = wskazanyId.ToString();
            info += " ";
            info += textBoxImie.Text;
            info += " ";
            info += textBoxNazwisko.Text;
            info += " ";
            info += textBoxStanowisko.Text;
            info += " ";
            Grupa gr = (Grupa)Enum.Parse(typeof(Grupa), comboBoxGrupy.Text);
            int grupa = (int)gr;
            info += grupa.ToString();
            info += " ";
            info += textBoxEmail.Text;
            info += " [Przełożony: ";
            info += comboBoxSzef.Text;
            info += " ";
            info = Toolbox.inputString(info, true, 200, "");
            return info;
        }
        private string cacheinfoDodaj()
        {
            string info = textBoxImieDodaj.Text;
            info += " ";
            info += textBoxNazwiskoDodaj.Text;
            info += " ";
            info += textBoxStanowiskoDodaj.Text;
            info += " ";
            Grupa gr = (Grupa)Enum.Parse(typeof(Grupa), comboBoxGrupaDodaj.Text);
            int grupa = (int)gr;
            info += grupa.ToString();
            info += " ";
            info += textBoxEmailDodaj.Text;
            info += " ";
            info += comboBoxSzefDodaj.Text;
            info += " ";
            info = Toolbox.inputString(info, true, 200, "");
            return info;
        }
    }
}
