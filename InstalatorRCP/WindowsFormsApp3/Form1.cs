using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public static string conString = @"";
        public static string nazwafirmy = @"";
        public static string mail = @"";

        public Form1()
        {
            InitializeComponent();
            label6.Text = "";
            textBoxHaslo.PasswordChar = '*';
            textBoxMailHaslo.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            conString = @"Data Source=" + textBoxZrodloDanych.Text + @";port=" + textBoxPort.Text + ";Initial Catalog=" + textBoxKatalog.Text + ";User Id=" + textBoxUzytkownik.Text + @";password=" + textBoxHaslo.Text + @";convert zero datetime=True";

            mail = textBoxMailHost.Text + ";" + textBoxMailPort.Text + ";" + textBoxMail.Text + ";" + textBoxMailHaslo.Text;

            nazwafirmy = textBoxNazwaFirmy.Text;


            string laczone = conString + Environment.NewLine + mail + Environment.NewLine + nazwafirmy;


            byte[] key = new byte[] { 2, 4, 34, 6, 36, 43, 36, 35, 22, 124, 124, 124, 14, 14, 4, 4 };
            byte[] salt = new byte[] { 2, 4, 54, 6, 36, 43, 36, 35, 22, 5, 5, 124, 14, 14, 4, 4 };



            string szyfrowane = EncryptString(laczone, key, salt);
           string sciezka= System.Reflection.Assembly.GetEntryAssembly().Location;
           string plik = System.AppDomain.CurrentDomain.FriendlyName;
            File.WriteAllText(sciezka.Replace(plik,"") + @"kod.ini", szyfrowane);


            //192.168.88.71






        }

        public static string EncryptString(string input, byte[] key, byte[] IV)
        {
            using (RijndaelManaged RMCrypto = new RijndaelManaged())
            {
                RMCrypto.Key = key;
                RMCrypto.IV = IV;
                var encryptor = RMCrypto.CreateEncryptor(RMCrypto.Key, RMCrypto.IV);
                var msEncrypt = new MemoryStream();
                var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(input);
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
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


        private void ButtonZainstaluj_Click(object sender, EventArgs e)
        {

            conString = @"Data Source=" + textBoxZrodloDanych.Text + @";port=" + textBoxPort.Text + ";Initial Catalog=" + textBoxKatalog.Text + ";User Id=" + textBoxUzytkownik.Text + @";password=" + textBoxHaslo.Text + @";convert zero datetime=True";

            string komenda = @"




            CREATE TABLE `dniwolne` (
  `data` date NOT NULL,
  `nazwa` varchar(80) COLLATE utf8_polish_ci NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_polish_ci;




            CREATE TABLE `harmonogram` (
  `Nrpracownika` int(11) DEFAULT NULL,
  `Datastart` datetime DEFAULT NULL,
  `Datakoniec` datetime DEFAULT NULL,
  `komentarz` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE = MyISAM DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci;



            CREATE TABLE `karty` (
  `ID` int(10) UNSIGNED NOT NULL,
  `NrPracownika` int(11) NOT NULL,
  `NrKarty` bigint(12) NOT NULL,
  `status` int(11) NOT NULL,
  `dataOd` datetime NOT NULL,
  `dataDo` datetime NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_polish_ci;


            CREATE TABLE `logi` (
  `data` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `log` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE = MyISAM DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci;


            CREATE TABLE `odbicia` (
  `ID` int(10) UNSIGNED NOT NULL,
  `NrKarty` bigint(12) NOT NULL,
  `Czas` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_polish_ci;


            CREATE TABLE `uzytkownicy` (
  `Id` int(10) UNSIGNED NOT NULL,
  `Imie` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `Nazwisko` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `STANOWISKO` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `Grupa` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `Email` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `Haslo` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `IdSzefa` int(10) UNSIGNED NOT NULL
) ENGINE = MyISAM DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci;



            INSERT INTO `uzytkownicy` (`Id`, `Imie`, `Nazwisko`, `STANOWISKO`, `Grupa`, `Email`, `Haslo`, `IdSzefa`) VALUES
            (1, 'admin', 'admin', 'admin', '1', 'admin@admin.com', SHA2('admin', 256), 1);



CREATE TABLE `wnioski` (
  `Id` int(11) NOT NULL,
  `NrPracownika` int(11) NOT NULL,
  `NrZatw` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `dataZatw` datetime NOT NULL,
  `typWniosku` int(11) NOT NULL,
  `status` int(11) NOT NULL,
  `dataOd` datetime NOT NULL,
  `dataDo` datetime NOT NULL,
  `imie` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `nazwisko` varchar(30) COLLATE utf8_polish_ci NOT NULL,
  `notatka` text COLLATE utf8_polish_ci NOT NULL,
  `odpowiedz` text COLLATE utf8_polish_ci NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_polish_ci;

            ALTER TABLE `dniwolne`
  ADD PRIMARY KEY(`data`);



            ALTER TABLE `karty`
  ADD PRIMARY KEY(`ID`);

            ALTER TABLE `logi`
  ADD PRIMARY KEY(`data`);


            ALTER TABLE `odbicia`
  ADD PRIMARY KEY(`ID`);


            ALTER TABLE `uzytkownicy`
  ADD PRIMARY KEY(`Id`),
  ADD UNIQUE KEY `Email` (`Email`);


            ALTER TABLE `wnioski`
  ADD PRIMARY KEY(`Id`),
  ADD KEY `NrPracownika` (`NrPracownika`),
  ADD KEY `NrZatw` (`NrZatw`);


            ALTER TABLE `karty`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 1;


            ALTER TABLE `odbicia`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 1;


            ALTER TABLE `uzytkownicy`
  MODIFY `Id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 14;
            COMMIT;

            ";
            MySqlConnection conn = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(komenda, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                conString = @"Data Source=" + textBoxZrodloDanych.Text + @";port=" + textBoxPort.Text + ";Initial Catalog=" + textBoxKatalog.Text + ";User Id=" + textBoxUzytkownik.Text + @";password=" + textBoxHaslo.Text + @";convert zero datetime=True";

                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    string sql0 = "SELECT @@IDENTITY"; //any request for cheking
                    MySqlCommand cmd0 = new MySqlCommand(sql0, con);
                    con.Open();
                    cmd0.ExecuteScalar();

                    label6.Text = "Connection True"; // label 
                    con.Close();
                }
            }

            catch (Exception)
            {
                label6.Text = "Connection False";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

         



        }

        private void TextBoxNazwaFirmy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


