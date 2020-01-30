using System;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxHaslo.PasswordChar = '*';
            textBoxHaslo.MaxLength = 20;
        }

        private void ButtonZaloguj_Click(object sender, EventArgs e)
        {
            labelError.Text = "";
            Uzytkownik logowany = RCPprogram.CreateInstance().Uzytkownik;
            //walidacja email
            string email = Toolbox.inputString(textBoxEmail.Text, true, 80, "");
            try
            {
                bool walidacja = Toolbox.walidacjaEmail(email, false);
                if (walidacja == false)
                { 
                    labelError.Text = "Email jest błędny. ";
                    RCPprogram.CreateInstance().ZapiszLogBledu("Nieprawidłowe logowanie. Podano błędny email: "+email);
                    return;
                }
                bool wynik = logowany.PobierzZBazy(email, textBoxHaslo.Text);
                if (wynik & !logowany.CzyGrupa(Grupa.ZABLOKOWANY)) { logowany.Zaloguj(); labelError.Text = ""; }
                else
                {
                    if (!wynik)
                    {
                        labelError.Text += logowany.LogError;
                        RCPprogram.CreateInstance().ZapiszLogBledu("Błąd bazy przy logowaniu: " + logowany.LogError);
                    }
                    else if (logowany.CzyGrupa(Grupa.ZABLOKOWANY))
                    {
                        labelError.Text += "Użytkownik jest zablokowany. ";
                        RCPprogram.CreateInstance().ZapiszLogBledu("Błąd bazy logowaniu. Użytkownik jest zablokowany. Email: " + email);
                    }
                    else
                    {
                        labelError.Text += "Inny błąd. Nie zalogowano. ";
                        RCPprogram.CreateInstance().ZapiszLogBledu("Inny błąd przy logowaniu. Email: " + email);
                    }
                }
            }
            catch (FormatException ex)
            {
                labelError.Text = "Nieprawidłowe dane wejściowe: " + ex.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu("Nieprawidłowe logowanie. Nieprawidłowe dane wejściowe: " + ex.Message);
            }
            catch (Exception fx)
            {
                labelError.Text = "Inny błąd: " + fx.Message;
                RCPprogram.CreateInstance().ZapiszLogBledu("Inny błąd: " + fx.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelError.Text = "";

            try
            {
                RCPprogram.CreateInstance().polaczeniabazydanych();
            }
            catch (Exception er)
            {
                MessageBox.Show("Brak lub błędny plik kod.ini w folderze z aplikacją.");
            }
            //textBoxEmail.Text = "patproproj@gmail.com";
            //textBoxHaslo.Text = "YXbdu6+-:^*1";
            //textBoxEmail.Text = "abspaters997@gmail.com";
            //textBoxHaslo.Text = "";
            textBoxEmail.Text = "agnieszka.anna.wolak@gmail.com";
            textBoxHaslo.Text = ")B#LXuimZc%f";
            //textBoxEmail.Text = "danio421@vp.pl";
            //textBoxHaslo.Text = "rSKMe}K5&Jox";
        }
    }
}
