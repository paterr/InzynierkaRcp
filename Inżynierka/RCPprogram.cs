using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka
{
    class RCPprogram
    {
        private static RCPprogram _RCPprogram;
        public static string conString = @"";
        public static string MailHost = @"";
        public static string MailPort = @"";
        public static string Mail = @"";
        public static string MailHaslo = @"";
        public static string nazwafirmy = @"";
        //public static string conString = @"Data Source=bazadanych.xaa.pl;port=3306;Initial Catalog=p549160_inzynierka;User Id=p549160_inzynier;password=Inżynier123;convert zero datetime=True";
        //public static string conString = @"Database=rcpdb;Data Source=localhost;port=3306;User Id=root;password='';convert zero datetime=True";
        private Form1 oknoLogowania;
        private Form oknoProgramu;
        private Wnioski oknoWnioski;
        private FormUzytkownicy oknoUzytkownicy;
        private Form2 oknoPoZalogowaniu;
        private Form3 oknoharmonogram;
        private Karty oknoKarty;
        private RCPprogram()
        {
            oknoLogowania = new Form1();
            Nowy();
        }
        private void Nowy()
        {
            oknoProgramu = oknoLogowania;
            if (Uzytkownik != null)
            {
                Uzytkownik.Dispose();
            }
            Uzytkownik = new Uzytkownik();
            if (oknoPoZalogowaniu != null)
            {
                oknoPoZalogowaniu.Dispose();
            }
            oknoPoZalogowaniu = new Form2();
            if (oknoWnioski != null)
            {
                oknoWnioski.Dispose();
            }
            oknoWnioski = new Wnioski();

            if (oknoharmonogram != null)
            {
                oknoharmonogram.Close();
                oknoharmonogram.Dispose();
            }
            oknoharmonogram = new Form3();

            if (oknoKarty != null)
            {
                oknoKarty.Close();
                oknoKarty.Dispose();
            }
            oknoKarty = new Karty();

            if (oknoUzytkownicy != null)
            {
                oknoUzytkownicy.Dispose();
            }
            oknoUzytkownicy = new FormUzytkownicy();
        }
        public static RCPprogram CreateInstance()
        {
            if (_RCPprogram == null)
            {
                _RCPprogram = new RCPprogram();
            }
            return _RCPprogram;
        }
        public Form1 Start()
        {
            return oknoLogowania;
        }
        public Uzytkownik Uzytkownik { get; set; }
        public enum ehome { LOG = 0, POLOG = 1, WNIOSKI = 2, UZYTKOWNICY = 3, HARMONOGRAM = 4, KARTY=5 }
        public void Home(ehome okno)
        {
            oknoProgramu.Hide();
            switch (okno)
            {
                case ehome.LOG:
                    oknoProgramu = oknoLogowania;
                    break;
                case ehome.POLOG:
                    oknoProgramu = oknoPoZalogowaniu;
                    break;
                case ehome.WNIOSKI:
                    oknoProgramu = oknoWnioski;
                    break;
                case ehome.UZYTKOWNICY:
                    oknoProgramu = oknoUzytkownicy;
                    break;
                case ehome.HARMONOGRAM:
                    oknoProgramu = oknoharmonogram;
                    break;
                case ehome.KARTY:
                    oknoProgramu = oknoKarty;
                    break;
                default:
                    throw new NotImplementedException();
            }
            oknoProgramu.Show();
        }
        public void Wyloguj(bool CzyZamknac)
        {
            if (CzyZamknac)
            {
                oknoLogowania.Close();
                oknoLogowania.Dispose();
            }
            else
            {
                Nowy();
                Home(ehome.LOG);
            }
        }

        public void polaczeniabazydanych()
        {
            string deszyfrowane = "";
            string sciezka = System.Reflection.Assembly.GetEntryAssembly().Location;
            string plik = System.AppDomain.CurrentDomain.FriendlyName;
            string szf = File.ReadAllText(sciezka.Replace(plik, "") + @"kod.ini");

            byte[] key = new byte[] { 2, 4, 34, 6, 36, 43, 36, 35, 22, 124, 124, 124, 14, 14, 4, 4 };
            byte[] salt = new byte[] { 2, 4, 54, 6, 36, 43, 36, 35, 22, 5, 5, 124, 14, 14, 4, 4 };

            deszyfrowane = DecryptString(szf, key, salt);

            string[] rozbite = deszyfrowane.Split(
                                new[] { Environment.NewLine },
                                StringSplitOptions.None
                                );

            conString = rozbite[0];

            string danemail = rozbite[1];
            string [] danemailowe = rozbite[1].Split(';');
            MailHost = danemailowe[0];
            MailPort = danemailowe[1];
            Mail = danemailowe[2];
            MailHaslo = danemailowe[3];

            nazwafirmy = rozbite[2];
        }

        //połączenia z bazą danych
        public DataTable PobierzDane(string komenda, MySqlParameter[] param)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (MySqlCommand cmd = new MySqlCommand(komenda, con))
                {
                    cmd.CommandType = CommandType.Text;
                    foreach (MySqlParameter par in param)
                    {
                        cmd.Parameters.Add(par);
                    }
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static string DecryptString(string input, byte[] key, byte[] IV)
        {
            using (RijndaelManaged RMCrypto = new RijndaelManaged())
            {
                string text;
                RMCrypto.Key = key;
                RMCrypto.IV = IV;
                var decryptor = RMCrypto.CreateDecryptor(RMCrypto.Key, RMCrypto.IV);
                var cipher = Convert.FromBase64String(input);
                var msDecrypt = new MemoryStream(cipher);
                var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    text = srDecrypt.ReadToEnd();
                }
                return text;
            }
        }
        public string PobierzElement(string komenda, MySqlParameter[] param)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (MySqlCommand cmd = new MySqlCommand(komenda, con))
                {
                    cmd.CommandType = CommandType.Text;
                    foreach (MySqlParameter par in param)
                    {
                        cmd.Parameters.Add(par);
                    }
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        return dt.Rows[0][0].ToString();
                    }
                }
            }
        }
        public void ZaktualizujDane(string komenda, MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(komenda, conn);
            cmd.CommandType = CommandType.Text;
            foreach (MySqlParameter par in param)
            {
                cmd.Parameters.Add(par);
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void WyslijEmail(string odbiorca, string tresc, string temat)
        {

            SmtpClient client = new SmtpClient();
            client.Port = Convert.ToInt32(MailPort);
            client.Host = MailHost;
            client.EnableSsl = false
                ;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Mail, MailHaslo);

            MailMessage mm = new MailMessage(Mail, odbiorca, temat, tresc);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

        //SmtpClient client = new SmtpClient();
        //client.Port = 587;
        //    client.Host = "mail.bazadanych.xaa.pl";
        //    client.EnableSsl = false
        //        ;
        //    client.Timeout = 10000;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new System.Net.NetworkCredential("rcp@bazadanych.xaa.pl", "Patrykjestsuper21");

        //    MailMessage mm = new MailMessage("rcp@bazadanych.xaa.pl", odbiorca, temat, tresc);
        //mm.BodyEncoding = UTF8Encoding.UTF8;
        //    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //    client.Send(mm);

        public void DodajDane(string komenda, MySqlParameter[] param)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand(komenda, conn);
                cmd.CommandType = CommandType.Text;
                foreach (MySqlParameter par in param)
                {
                    cmd.Parameters.Add(par);
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Duplicate entry"))
                {
                    MessageBox.Show("Ten dzień jest już ustawiony jako dzień wolny.");
                }
                else
                {
                    string wiadomosc = "Błąd wpisu dnia wolnego. Wiadomość: " + e.Message;
                    ZapiszLogBledu(wiadomosc);
                    MessageBox.Show("Wystąpił niekreślony błąd, skontaktuj się z administratorem lub spróbuj ponownie"
                        + e.ToString());
                }
            }
        }
        public void ZapiszLog(string info)
        {
            string log="";
            try
            {
                log = "[" + Uzytkownik.ID.ToString() + " " + Uzytkownik.Nazwisko + " " + Uzytkownik.Imie + "] ";
                log += info;
                if (log.Length > 600) { log = log.Substring(0, 600); }
                string komenda = "INSERT INTO `logi`(`log`) VALUES (@log)";
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@log", MySqlDbType.VarChar);
                param[0].Value = log;
                ZaktualizujDane(komenda, param);
            }
            catch(Exception ex)
            {
                string wiadomosc = "Błąd wpisu logu <"+log+"> do bazy. Wiadomość: "+ex.Message;
                ZapiszLogBledu(wiadomosc);
            }
        }
        internal void ZapiszLogBledu(string wiadomosc)
        {
            string log = "[" + DateTime.Now.ToString() + "] ";
            log += wiadomosc;
            string sciezka = Path.Combine(Directory.GetCurrentDirectory(), "RCPlog.txt");
            using (StreamWriter wr = new StreamWriter(sciezka, true))
            {
                wr.WriteLine(log);
            }
        }
        public int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }
    }
}
