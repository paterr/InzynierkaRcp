using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka
{
    public class Uzytkownik : IDisposable
    {
        public int ID { get; private set; }
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Stanowisko { get; private set; }
        public string Email { get; private set; }
        public Grupa Grupa { get; private set; }
        public int IdSzefa { get; private set; }
        public string LogError { get; private set; }

        public Uzytkownik()
        {
            Kasuj();
        }
        public Uzytkownik(int id):this()
        {
            PobierzZBazyPoId(id);
        }
        private void PobierzZBazyPoId(int id)
        {
            try
            {
                string komenda = "SELECT Id, Imie, Nazwisko, STANOWISKO, Grupa, Email FROM uzytkownicy where Id='" + id + "'";
                DataTable tabela = RCPprogram.CreateInstance().PobierzDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                DataRow czytnik = tabela.Rows[0];
                this.ID = int.Parse(czytnik[0].ToString());
                this.Imie = czytnik[1].ToString();
                this.Nazwisko = czytnik[2].ToString();
                this.Stanowisko = czytnik[3].ToString();
                this.Email = czytnik[5].ToString();
                int i = int.Parse(czytnik[4].ToString());
                this.Grupa = (Grupa)i;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }
        public bool PobierzZBazy(string email, string haslo)
        {
            LogError = "";
            try
            {
                bool istnieje = SprawdzCzyKontoIstnieje(email, haslo);

                if (istnieje == false)
                {
                    LogError += "W bazie nie ma konta o tym adresie. ";
                    //MessageBox.Show("Takie konto nie istnieje");
                }
                if (!WeryfikujHaslo(email, haslo))
                {
                    LogError += "Niepoprawne hasło. ";
                    //MessageBox.Show("Niepoprawne hasło");
                }
                if (LogError != "") { return false; }
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@email", MySqlDbType.VarChar);
                param[0].Value = email;
                string komenda = "SELECT Id, Imie, Nazwisko, STANOWISKO, Grupa, Email, IdSzefa FROM uzytkownicy where Email=@email";
                DataTable tabela = RCPprogram.CreateInstance().PobierzDane(komenda, param);
                DataRow czytnik = tabela.Rows[0];
                ID = int.Parse(czytnik[0].ToString());
                Imie = czytnik[1].ToString();
                Nazwisko = czytnik[2].ToString();
                Stanowisko = czytnik[3].ToString();
                Email = czytnik[5].ToString();
                int i = int.Parse(czytnik[4].ToString());
                Grupa = (Grupa)i;
                IdSzefa = int.Parse(czytnik[6].ToString());

                LogError = "";
                return true;
            }
            catch (Exception e)
            {
                LogError = "Inny błąd: "+e.Message;
                //MessageBox.Show(e.Message);
                return false;
            }
        }
        internal void ZapiszOdbicieTeraz()
        {
            DateTime odbicie = DateTime.Now;
            ZapiszOdbicie(odbicie);
        }
        internal void ZapiszOdbicie(DateTime odbicie)
        {
            LogError = "";
            Harmonogram harmonogram = new Harmonogram(this, odbicie.Year, odbicie.Month);
            try
            {
                bool weryfikacjaodbicia = true;
                if (weryfikacjaodbicia){ }//if (harmonogram.WeryfikacjaOdbicia(odbicie)){ }
                else
                {
                    string wiadomosc = "Wykryto niezgodność w harmonogramie.\n" +
                        "Skontaktuj się z przełożonym lub działem personalnym.\n\n";
                    wiadomosc += harmonogram.Error;
                    MessageBox.Show(wiadomosc);
                } 
            }
            catch
            {
                MessageBox.Show("Przepraszamy, błąd połączenia z bazą danych.\nSkontaktuj się z administratorem.");
            }
        }
        private bool SprawdzCzyKontoIstnieje(string email, string haslo)
        {
            string komenda = "SELECT count(*) FROM uzytkownicy where Email=@email";
            MySqlParameter[] param = new MySqlParameter[1];
            param[0] = new MySqlParameter("@email", MySqlDbType.VarChar);
            param[0].Value = email;
            try
            {
                if (RCPprogram.CreateInstance().PobierzElement(komenda, param) != "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Błąd połączenia z bazą");
                return false;
            }
        }
        public bool WeryfikujHaslo(string email, string haslo)
        {
            string komenda = "SELECT Haslo FROM uzytkownicy where Email='" + email + "'";
            try
            {
                string password = RCPprogram.CreateInstance().PobierzElement(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);

                // byte array representation of that string
                byte[] encodedPassword = new UTF8Encoding().GetBytes(haslo);
                // need MD5 to calculate the hash
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("SHA256")).ComputeHash(encodedPassword);
                // string representation (similar to UNIX format)
                string encoded = BitConverter.ToString(hash)
                   // without dashes
                   .Replace("-", string.Empty)
                   // make lowercase
                   .ToLower();
                if (password == encoded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public void Zaloguj()
        {
            RCPprogram.CreateInstance().Start().Hide();
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.POLOG);
        }
        private void Kasuj()
        {
            this.ID = 0;
            this.Imie = "";
            this.Nazwisko = "";
            this.Stanowisko = "";
            this.Email = "";
            this.Grupa = Grupa.NOGROUP;
            this.IdSzefa = 0;
            //okna = new List<Form>();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Aby wykryć nadmiarowe wywołania

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: wyczyść stan zarządzany (obiekty zarządzane).
                }

                // TODO: Zwolnić niezarządzane zasoby (niezarządzane obiekty) i przesłonić poniższy finalizator.
                // TODO: ustaw wartość null dla dużych pól.

                disposedValue = true;
            }
        }

        // TODO: Przesłonić finalizator tylko w sytuacji, gdy powyższa metoda Dispose(bool disposing) zawiera kod służący do zwalniania niezarządzanych zasobów.
        // ~Uzytkownik()
        // {
        //   // Nie zmieniaj tego kodu. Umieść kod czyszczący w powyższej metodzie Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Ten kod został dodany w celu prawidłowego zaimplementowania wzorca rozporządzającego.
        public void Dispose()
        {
            // Nie zmieniaj tego kodu. Umieść kod czyszczący w powyższej metodzie Dispose(bool disposing).
            Dispose(true);
            // TODO: Usunąć komentarz z poniższego wiersza, jeśli finalizator został przesłonięty powyżej.
            // GC.SuppressFinalize(this);
        }
        #endregion
        public DataGridView PrzegladOdbic() {
            string komenda = "SELECT Czas, o.NrKarty as 'Numer karty RFID' FROM odbicia o " +
                "left join karty as k ON k.NrKarty=o.Nrkarty " +
                "WHERE k.NrPracownika="+ID;

            DataGridView widok = new DataGridView();
            widok.DataSource = RCPprogram.CreateInstance().PobierzDane(komenda, new MySqlParameter[0]);
          
            return widok;
        }
        public DataGridView PrzegladWnioskow()
        {
            string komenda = "SELECT Id, NrPracownika, data, nrZatw, dataZatw, typWniosku, status, dataOd, dataDo, " +
                    "imie, nazwisko, notatka, odpowiedz "+
                    "FROM wnioski WHERE NrPracownika=" + ID;
                DataGridView widok = new DataGridView();
                widok.DataSource = RCPprogram.CreateInstance().PobierzDane(komenda, new MySqlParameter[0]);
                return widok; 
        }
        public DataTable PrzegladOdbicData(string dt1, string dt2)
        {
            string komenda = "SELECT Czas, o.NrKarty as 'Numer karty RFID' FROM odbicia o " +
                "left join karty as k ON k.NrKarty=o.Nrkarty " +
                "WHERE k.NrPracownika=" + ID + " and Czas between '" + dt1.ToString() + "' and '" + dt2.ToString() + @"'";
            DataTable dt = RCPprogram.CreateInstance().PobierzDane(komenda, new MySqlParameter[0]);

           
            return dt;
            
        }

        public bool CzyGrupa(Grupa grupa)
        {
            bool wynik = false;
            wynik = (this.Grupa & grupa) == grupa;
            return wynik;
        }
    }
    [Flags]
    public enum Grupa
    {
        NOGROUP = 0,
        ADMINISTRATOR = 1,
        PRACOWNIK = 2,
        PERSONALNY = 4,
        SZEF = 8,
        KADROWY = 16,
        ZABLOKOWANY = 32
    }
}
