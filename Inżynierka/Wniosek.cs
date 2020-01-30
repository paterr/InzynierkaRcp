using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inzynierka
{
    public class Wniosek
    {
        protected int Id = 0;
        protected Uzytkownik pracownik = null;
        protected Uzytkownik zatwierdzajacy = null;
        protected DateTime dataWystawienia;
        protected DateTime dataZatwierdzenia;
        protected TypWniosku typWniosku = 0;
        protected Status status = 0;

        public int ID { get { return Id; } }
        public Uzytkownik Pracownik { get { return pracownik; } set { pracownik = value; } }
        public Uzytkownik Zatwierdzajacy { get { return zatwierdzajacy; } set { zatwierdzajacy = value; } }
        public DateTime DataWystawienia { get { return dataWystawienia; } }
        public DateTime DataZatwierdzenia { get { return dataZatwierdzenia; } }
        public TypWniosku TypWniosku { get { return typWniosku; } }
        public Status Status { get { return status; } set { status = value; } }
        public DateTime CzasOd { get; set; }
        public DateTime CzasDo { get; set; }
        public string Opis { get; set; }
        public string Odpowiedz { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Wniosek()
        {
            dataWystawienia = DateTime.Now;
            dataZatwierdzenia = DateTime.MinValue;
            CzasOd = DateTime.MinValue;
            CzasDo = DateTime.MinValue;
        }
        public Wniosek(int id, int idPracownika, int idZatwierdzajacego, DateTime dataWyst, DateTime dataZatw,
            TypWniosku typ, Status status) : this()
        {
            Id = id;
            pracownik = new Uzytkownik(idPracownika);
            zatwierdzajacy = new Uzytkownik(idZatwierdzajacego);
            dataWystawienia = dataWyst;
            dataZatwierdzenia = dataZatw;
            typWniosku = typ;
            this.status = status;
        }
        public Wniosek(int id, int idPracownika, int idZatwierdzajacego, DateTime dataWyst, DateTime dataZatw,
            TypWniosku typ, Status status, DateTime CzasOd, DateTime CzasDo, string Opis, string Odpowiedz,
            string Imie, string Nazwisko) : this(id, idPracownika, idZatwierdzajacego, dataWyst, dataZatw,
            typ, status)
        {
            this.CzasOd = CzasOd;
            this.CzasDo = CzasDo;
            this.Opis = Opis;
            this.Odpowiedz = Odpowiedz;
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
        }
        public void WypelnijWniosek(int id, int idPracownika, int idZatwierdzajacego, DateTime dataWyst, DateTime dataZatw,
        TypWniosku typ, Status status, DateTime CzasOd, DateTime CzasDo, string Opis, string Odpowiedz,
        string Imie, string Nazwisko)
        {
            Id = id;
            pracownik = new Uzytkownik(idPracownika);
            zatwierdzajacy = new Uzytkownik(idZatwierdzajacego);
            dataWystawienia = dataWyst;
            dataZatwierdzenia = dataZatw;
            typWniosku = typ;
            this.status = status;
            this.CzasOd = CzasOd;
            this.CzasDo = CzasDo;
            this.Opis = Opis;
            this.Odpowiedz = Odpowiedz;
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
        }
        private void Zarejestruj()
        {
            try
            {
                string komenda = "SELECT max(Id) FROM wnioski";
                string input = RCPprogram.CreateInstance().PobierzElement(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
               
                 Id = int.Parse(input) + 1; 
                   
             
              
                DodajDoBazy();
            }
            catch
            {
                Id = 0;
                throw new Exception("Nieudane zarejestrowanie");
            }
        }
        private void DodajDoBazy()
        {
            int idPracownika =(pracownik== null) ? 0 : pracownik.ID;
            int idZatwierdzajacego = (zatwierdzajacy==null) ? 0 : zatwierdzajacy.ID;

            string komenda = "INSERT INTO `wnioski` (`Id`, `NrPracownika`, `NrZatw`, `data`, `dataZatw`, `typWniosku`, `status`) " +
                "VALUES ('" + Id + "', '" + idPracownika + "', '" + idZatwierdzajacego + "', '" + dataWystawienia + "', '" + dataZatwierdzenia + "', '" + (int)typWniosku + "', '" + (int)status + "');";
              try { RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]); }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Błąd testowy DodajDOBazy()");
            }
        }
        public virtual void PobierzZBazyPoId()
        {
            string komenda = "SELECT Id, NrPracownika, NrZatw, data, dataZatw, typWniosku, status, " +
                "dataOd, dataDo, notatka, odpowiedz, imie, nazwisko " +
                "FROM Wnioski Where id=" + Id;
            try
            {
                DataTable tabela = RCPprogram.CreateInstance().PobierzDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                if (tabela.Rows.Count != 1) { throw new Exception("Pobrano z bazy więcej wierszy niż jeden"); }
                DataRow czytnik = tabela.Rows[0];
                Id = int.Parse(czytnik[0].ToString());
                dataWystawienia = (DateTime)czytnik[3];
                dataZatwierdzenia = (DateTime)czytnik[4];
                typWniosku = (TypWniosku)int.Parse(czytnik[5].ToString());
                status = (Status)int.Parse(czytnik[6].ToString());
                pracownik = new Uzytkownik(int.Parse(czytnik[1].ToString()));
                zatwierdzajacy = new Uzytkownik(int.Parse(czytnik[2].ToString()));
                CzasOd = (DateTime)czytnik[7];
                CzasOd = (DateTime)czytnik[8];
                Opis = czytnik[9].ToString();
                Odpowiedz = czytnik[10].ToString();
                Imie = czytnik[11].ToString();
                Nazwisko = czytnik[12].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public virtual void ZapiszZmiany()
        {
            int idPracownika = (pracownik == null) ? 0 : pracownik.ID;
            int idZatwierdzajacego = (zatwierdzajacy == null) ? 0 : zatwierdzajacy.ID;

            string komenda = "UPDATE `wnioski` SET `NrPracownika`='" + idPracownika + "', " +
                "`NrZatw`='" + idZatwierdzajacego + "', `data`='" + dataWystawienia + "', " +
                "`dataZatw`='" + dataZatwierdzenia + "', `typWniosku`='" + (int)typWniosku + "', " +
                "`status`='" + (int)status + "', `dataOd`='"+CzasOd.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                "`dataDo`='" + CzasDo.ToString("yyyy-MM-dd HH:mm:ss") + "', `notatka`='" + Opis + "', " +
                "`odpowiedz`='" + Odpowiedz + "', `imie`='" + Imie + "', `nazwisko`= '" + Nazwisko + "' " +
                "WHERE Id=" + Id + ";";
           /*try {*/ RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]); //}
           // catch (Exception)
            //{
             //   throw new UnauthorizedAccessException("Błąd testowy ZapiszDoBazy()");
           // }
        }
        public virtual void Wyslij()
        {
            try
            {           
                if (Id == 0) { Zarejestruj();}  
                status = Status.WYSLANY;              
                ZapiszZmiany();
                MessageBox.Show("Wysłano z Wyślij()");
                //mail
                string tresc = "W programie RCP czeka na zatwierdzenie nowy wniosek ";
                tresc += TypWniosku.ToString();
                tresc += " wysłany przez pracownika:\n\n";
                tresc += Pracownik.Imie + " " + Pracownik.Nazwisko + "\n\n";
                tresc += "Zaloguj się do programu aby sprawdzić szczegóły.";
                string adresat = new Uzytkownik(Pracownik.IdSzefa).Email;
                RCPprogram.CreateInstance().WyslijEmail(adresat, tresc, "RCPprogram: Nowy wniosek do zatwierdzenia");
            }
            catch
            {
                status = Status.SZKIC;
                MessageBox.Show("Problem z połączeniem z bazą danych. Z Wyślij()");
            }
        }
        public virtual void Zatwierdz()
        {
            try
            {
                if (status == Status.WYSLANY)
                {
                    status = Status.ZATWIERDZONY;
                    DateTime teraz = DateTime.Now;

                    string komenda = "UPDATE `wnioski` SET `status`='" + (int)status + "', " +
                    "`dataZatw`='" + teraz.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                    "`NrZatw`='" + RCPprogram.CreateInstance().Uzytkownik.ID + "', " +
                    "`odpowiedz`='" + Odpowiedz + "' " +
                        "WHERE Id=" + Id + ";";
                    RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                }
                MessageBox.Show("Zatwierdzono z Zatwierdź()");
                //mail
                string tresc = "W programie RCP przełożony zatwierdził wniosek ";
                tresc += TypWniosku.ToString();
                tresc += " wysłany ";
                tresc += DataWystawienia.ToString("yyyy-MM-dd") + "\n\n";
                tresc += "Zaloguj się do programu aby sprawdzić szczegóły.";
                string adresat = Pracownik.Email;
                RCPprogram.CreateInstance().WyslijEmail(adresat, tresc, "RCPprogram: Twój wniosek został zatwierdzony");
            }
            catch
            {
                status = Status.WYSLANY;
                MessageBox.Show("Problem z połączeniem z bazą danych albo inny. Z Zatwierdź()");
            }
        }
        public virtual void Odrzuc()
        {
            try
            {
                if (status == Status.WYSLANY)
                {
                    status = Status.ODRZUCONY;
                    DateTime teraz = DateTime.Now;

                    string komenda = "UPDATE `wnioski` SET `status`='" + (int)status + "', " +
                    "`dataZatw`='" + teraz.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                    "`NrZatw`='" + RCPprogram.CreateInstance().Uzytkownik.ID + "', " +
                    "`odpowiedz`='" + Odpowiedz + "' " +
                        "WHERE Id=" + Id + ";";
                    RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                }
                MessageBox.Show("Odrzucono z Odrzuć()");
                //mail
                string tresc = "W programie RCP przełożony odrzucił wniosek ";
                tresc += TypWniosku.ToString();
                tresc += " wysłany ";
                tresc += DataWystawienia.ToString("yyyy-MM-dd") + "\n\n";
                tresc += "Zaloguj się do programu aby sprawdzić szczegóły.";
                string adresat = Pracownik.Email;
                RCPprogram.CreateInstance().WyslijEmail(adresat, tresc, "RCPprogram: Twój wniosek został odrzucony");
            }
            catch
            {
                status = Status.WYSLANY;
                MessageBox.Show("Problem z połączeniem z bazą danych albo inny. z Odrzuć()");
            }
        }
        public virtual void Usun()
        {
            string komenda = "Delete FROM `wnioski` Where `id`=" + Id;
            RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
        }
    }
    public enum TypWniosku
    {
        NOWY = 0,
        DANE = 1,
        URLOP = 2,
        WOLNE = 3,
        NADGODZINY = 4,
        WYJSCIESLUZBOWE = 5
    }
    public enum Status
    {
        SZKIC = 0,
        WYSLANY = 1,
        ZATWIERDZONY = 2,
        ODRZUCONY = 3
    }
    class WniosekDane : Wniosek
    {
        public WniosekDane() : base() { typWniosku = TypWniosku.DANE; }
        public override void PobierzZBazyPoId()
        {
            base.PobierzZBazyPoId();
            //weryfikuj email
        }
        public override void Zatwierdz() {
            try
            {
                if (status == Status.WYSLANY)
                {
                    status = Status.ZATWIERDZONY;
                    DateTime teraz = DateTime.Now;
                    //log
                    string log = "Zatwierdzony wniosek zmiana danych [0] ";
                    log +="Pierwotne: "+Pracownik.ID+" "+Pracownik.Imie+" "+Pracownik.Nazwisko+ " "+Pracownik.Email+" ";
                    log +="[1] ";
                    log += "IdWniosku: "+Id+" "+Imie +" "+ Nazwisko+" "+ Opis +" ["+ Odpowiedz+"] ";
                    RCPprogram.CreateInstance().ZapiszLog(log);
                    //zatwierdzenie wniosku
                    string komenda = "UPDATE `wnioski` SET `status`='" + (int)status + "', " +
                                    "`dataZatw`='" + teraz.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                    "`NrZatw`='" + RCPprogram.CreateInstance().Uzytkownik.ID + "', " +
                                    "`odpowiedz`='" + Odpowiedz + "' " +
                                        "WHERE Id=" + Id + ";";
                    RCPprogram.CreateInstance().DodajDane(komenda, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    //zmiana danych
                    string komenda2 = "UPDATE `uzytkownicy` SET `Imie`='" + Imie + "', " +
                                    "`Nazwisko`='" + Nazwisko + "', " +
                                    "`Email`='" + Opis + "' " +
                                        "WHERE Id=" + Pracownik.ID + ";";
                    RCPprogram.CreateInstance().DodajDane(komenda2, new MySql.Data.MySqlClient.MySqlParameter[0]);
                    int id = Pracownik.ID;
                    Pracownik = new Uzytkownik(id);
                }
                MessageBox.Show("Zatwierdzono z Zatwierdź Dane()");
                //mail
                string tresc = "W programie RCP przełożony zatwierdził wniosek ";
                tresc += TypWniosku.ToString();
                tresc += " wysłany ";
                tresc += DataWystawienia.ToString("yyyy-MM-dd") + "\n\n";
                tresc += "Zaloguj się do programu aby sprawdzić szczegóły.";
                string adresat = Pracownik.Email;
                RCPprogram.CreateInstance().WyslijEmail(adresat, tresc, "RCPprogram: Twój wniosek został zatwierdzony");
            }
            catch
            {
                status = Status.WYSLANY;
                MessageBox.Show("Problem z połączeniem z bazą danych albo inny. Z Zatwierdź Dane()");
            }
        }
    }
    class WniosekUrlop : Wniosek
    {
        public WniosekUrlop() : base() { typWniosku = TypWniosku.URLOP; }
    }
    class WniosekWolne : Wniosek
    {
        public WniosekWolne() : base() { typWniosku = TypWniosku.WOLNE; }
    }
    class WniosekNadgodziny : Wniosek
    {
        public WniosekNadgodziny() : base() { typWniosku = TypWniosku.NADGODZINY; }
    }
    class WniosekWyjscie : Wniosek
    {
        public WniosekWyjscie() : base() { typWniosku = TypWniosku.WYJSCIESLUZBOWE; }
    }
}
