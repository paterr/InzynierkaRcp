using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;

namespace Inzynierka
{
    class Harmonogram
    {
        private readonly Uzytkownik uzytkownik;
        public int Rok { get; private set; }
        private string error = "";
        private DateTime poczatekM;
        private DateTime koniecM;
        public DataTable miesiacTabela;
        public int godzinyurlop;
        public int godzinyharmonogram;
        public int godzinyrzeczywiste;
        public string Error { get { return error; } set { error = Toolbox.inputString(value, true, 500); } }

        public Harmonogram(Uzytkownik uzytkownik, int rok, int miesiac)
        {
            this.uzytkownik = uzytkownik;
            GenerujMiesiac(rok, miesiac);
        }
        public Harmonogram(int uzytkownikId, int rok, int miesiac)
        {
            uzytkownik = new Uzytkownik(uzytkownikId);
            GenerujMiesiac(rok, miesiac);
        }
        public Harmonogram()
        {
            uzytkownik = RCPprogram.CreateInstance().Uzytkownik;
            GenerujMiesiac(DateTime.Now.Year, DateTime.Now.Month);
        }
        private void GenerujMiesiac(int rok, int miesiac)
        {
            Rok = rok;
            poczatekM = new DateTime(rok, miesiac, 1);
            koniecM = poczatekM.AddMonths(1).AddDays(-1);

            //tabela z datami            
            miesiacTabela = new DataTable();
            miesiacTabela.Columns.AddRange(new DataColumn[] { new DataColumn("DATA"), new DataColumn("Godziny"), new DataColumn("Komentarz") });
            for (DateTime date = poczatekM; date.Date <= koniecM.Date; date = date.AddDays(1))
            {
                miesiacTabela.Rows.Add(date.ToString("yyyy-MM-dd"), "", "");
            }
            //tabela z bazy harmonogram
            HarmonogramdlaPracownika();
            OdbiciadlaPracownika();
            Dzienwolny();
            Urlop();
            Nadgodziny();
            GodzinySumy();
        }
        private void Dzienwolny()
        {
            DataTable dniwolne = RCPprogram.CreateInstance().PobierzDane(@"select * from dniwolne where month(data)='" + poczatekM.ToString("MM") + @"'", new MySqlParameter[0]);
            for (int j = 0; j < miesiacTabela.Rows.Count; j++)
            {
                DateTime tabela1 = DateTime.Parse(miesiacTabela.Rows[j][0].ToString());
                for (int jj = 0; jj < dniwolne.Rows.Count; jj++)
                {
                    DateTime tabela2 = DateTime.Parse(dniwolne.Rows[jj][0].ToString());
                    if (tabela2.Date == tabela1.Date)
                    {
                        miesiacTabela.Rows[jj][2] = "Dzień wolny: " + dniwolne.Rows[jj][1].ToString();
                    }
                }
            }
        }
        private void Nadgodziny()
        {
            DataTable nadgodziny = RCPprogram.CreateInstance().PobierzDane("select dataOd, dataDo from wnioski where NrPracownika='" + uzytkownik.ID + "'  and typWniosku='4'  and status='3' and month(dataOd) in ('" + poczatekM.AddMonths(-1).ToString("MM") + "','" + poczatekM.ToString("MM") + "')"
              + " and month(dataDo) in ('" + DateTime.Now.ToString("MM") + "','" + DateTime.Now.AddMonths(+1).ToString("MM") + "') " +
               "and  year(dataOd) in ('" + poczatekM.AddMonths(-1).ToString("yyyy") + "','" + koniecM.ToString("yyyy") + "')"
              + "and  year(dataDo) in ('" + koniecM.ToString("yyyy") + "','" + koniecM.AddMonths(+1).ToString("yyyy") + "')", new MySql.Data.MySqlClient.MySqlParameter[0]);
            for (int k = 0; k < nadgodziny.Rows.Count; k++)
            {
                DateTime poczatek = Convert.ToDateTime(nadgodziny.Rows[k][0].ToString());
                DateTime koniec = Convert.ToDateTime(nadgodziny.Rows[k][1].ToString());

                for (DateTime date = poczatek; date.Date <= koniec.Date; date = date.AddDays(1))
                {
                    for (int j = 0; j < miesiacTabela.Rows.Count - 1; j++)
                    {
                        if (date.Date == DateTime.Parse(miesiacTabela.Rows[j][0].ToString()).Date)
                        {
                            miesiacTabela.Rows[j][2] = "Nadgodziny";
                            break;
                        }
                    }
                }
            }
        }
        private void Urlop()
        {
            string komenda2 = "select dataOd, dataDo from wnioski where NrPracownika='" + uzytkownik.ID + "'  and typWniosku='2' and   status='2' and month(dataOd) in ('" + poczatekM.AddMonths(-1).ToString("MM") + "','" + poczatekM.ToString("MM") + "')"
              + " and month(dataDo) in ('" + DateTime.Now.ToString("MM") + "','" + DateTime.Now.AddMonths(+1).ToString("MM") + "') " +
               "and  year(dataOd) in ('" + poczatekM.AddMonths(-1).ToString("yyyy") + "','" + koniecM.ToString("yyyy") + "')"
              + "and  year(dataDo) in ('" + koniecM.ToString("yyyy") + "','" + koniecM.AddMonths(+1).ToString("yyyy") + "')";

            DataTable wolne = RCPprogram.CreateInstance().PobierzDane(komenda2, new MySqlParameter[0]);
            for (int k = 0; k < wolne.Rows.Count; k++)
            {
                DateTime poczatek = Convert.ToDateTime(wolne.Rows[k][0].ToString());
                DateTime koniec = Convert.ToDateTime(wolne.Rows[k][1].ToString());

                for (DateTime date = poczatek; date.Date <= koniec.Date; date = date.AddDays(1))
                {
                    for (int j = 0; j < miesiacTabela.Rows.Count - 1; j++)
                    {
                        if (date.Date == DateTime.Parse(miesiacTabela.Rows[j][0].ToString()).Date)
                        {
                            if (miesiacTabela.Rows[j][1].ToString().Length < 2)
                            {
                                break;
                            }
                            else
                            {
                                miesiacTabela.Rows[j][2] = "Urlop";
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void OdbiciadlaPracownika()
        {
            DataTable odbiciaa = RCPprogram.CreateInstance().PobierzDane(@"select o.ID,o.NrKarty, o.Czas from odbicia as o
            left join karty as k ON k.NrKarty=o.NrKarty where k.NrPracownika='" + uzytkownik.ID + @"' and month(Czas)='" + poczatekM.ToString("MM") + @"'", new MySqlParameter[0]);
            Thread.Sleep(100);
            for (int j = 0; j < miesiacTabela.Rows.Count - 1; j++)
            {
                string[] tabela1 = miesiacTabela.Rows[j][1].ToString().Split(';');
                if (tabela1.Length > 1)
                {
                    DateTime dataharmonogramwejscia = Convert.ToDateTime(tabela1[0]);
                    DateTime dataharmonogramwyjscia = Convert.ToDateTime(tabela1[1]);

                    for (int jj = 0; jj < odbiciaa.Rows.Count; jj++)
                    {
                        DateTime wejsciereal = Convert.ToDateTime(odbiciaa.Rows[jj][2].ToString());
                        if (miesiacTabela.Rows[j][2].ToString() == "W:OK")
                        {
                            continue;
                        }
                        else
                        {
                            if (dataharmonogramwejscia.Day == wejsciereal.Day)
                            {
                                if (dataharmonogramwejscia.AddMinutes(-29) < wejsciereal && wejsciereal < dataharmonogramwejscia.AddMinutes(5))
                                {
                                    miesiacTabela.Rows[j][2] = "W:NOK";
                                    DataTable odbiciedzien = RCPprogram.CreateInstance().PobierzDane(@"select o.ID,o.NrKarty, o.Czas from odbicia  as o
                                 left join karty as k ON k.NrKarty=o.NrKarty where k.NrPracownika='" + uzytkownik.ID + @"' and month(Czas)='" + poczatekM.ToString("MM") + @"' and day(Czas)='" + dataharmonogramwejscia.Day + @"'", new MySql.Data.MySqlClient.MySqlParameter[0]);
                                    for (int blabla = 0; blabla < odbiciedzien.Rows.Count; blabla++)
                                    {
                                        DateTime wyjsciereal = Convert.ToDateTime(odbiciedzien.Rows[blabla][2].ToString());
                                        int k = 0;
                                        if (dataharmonogramwyjscia.AddMinutes(-5) < wyjsciereal && wyjsciereal < dataharmonogramwyjscia.AddMinutes(30))
                                        {
                                            k++;
                                        }

                                        if (k == 1)
                                        {
                                            miesiacTabela.Rows[j][2] = "W:OK";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    miesiacTabela.Rows[j][2] = "W:NOK";
                                }
                            }
                        }
                    }
                }
            }
        }
        private void HarmonogramdlaPracownika()
        {
            string komenda = "select Datastart, Datakoniec, Komentarz from harmonogram where Nrpracownika='" + uzytkownik.ID + "' and" +
              " month(Datastart)='" + poczatekM.ToString("MM") + "'";

            DataTable harmonogramdlapracownika = RCPprogram.CreateInstance().PobierzDane(komenda, new MySqlParameter[0]);

            for (int j = 0; j < miesiacTabela.Rows.Count; j++)
            {
                DateTime tabela1 = DateTime.Parse(miesiacTabela.Rows[j][0].ToString());

                for (int jj = 0; jj < harmonogramdlapracownika.Rows.Count; jj++)
                {
                    DateTime tabela2 = DateTime.Parse(harmonogramdlapracownika.Rows[jj][1].ToString());

                    if (tabela2.Date == tabela1.Date)
                    {
                        if (Convert.ToDateTime(harmonogramdlapracownika.Rows[jj][0].ToString()).Hour < Convert.ToDateTime(harmonogramdlapracownika.Rows[jj][1].ToString()).Hour)
                        {
                            miesiacTabela.Rows[j][1] = harmonogramdlapracownika.Rows[jj][0].ToString() + ";" + harmonogramdlapracownika.Rows[jj][1].ToString();
                            miesiacTabela.Rows[j][2] = "Zmiana dzienna";
                        }
                        else
                        {
                            miesiacTabela.Rows[j][1] = harmonogramdlapracownika.Rows[jj][0].ToString() + ";" + harmonogramdlapracownika.Rows[jj][1].ToString();
                            miesiacTabela.Rows[j][2] = "Zmiana nocna";
                        }
                        break;
                    }
                }
            }
        }
        private void GodzinySumy()
        {
            for (int j = 0; j < miesiacTabela.Rows.Count; j++)
            {
                if (miesiacTabela.Rows[j][1] != null)
                {
                    string[] tabela1 = miesiacTabela.Rows[j][1].ToString().Split(';');
                    if (tabela1.Length > 1)
                    {
                        DateTime poczatek = Convert.ToDateTime(tabela1[0].ToString());
                        DateTime koniec = Convert.ToDateTime(tabela1[1].ToString());

                        TimeSpan difference = koniec - poczatek;
                        int hours = Math.Abs(difference.Hours);
                        godzinyharmonogram += hours;

                        if (miesiacTabela.Rows[j][2].ToString() == "Urlop")
                        {
                            godzinyurlop += hours;
                        }
                        else if (miesiacTabela.Rows[j][2].ToString() == "W:OK")
                        {
                            godzinyrzeczywiste += hours;
                        }
                    }
                }
            }
        }

        public DataTable Widokharmonogramu()
        {
            return miesiacTabela;
        }
    }
}
