using System;
using System.Data;
using System.Windows.Forms;

namespace Inzynierka
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void WczytajGrid()
        {
            dataGridViewOdbicia = RCPprogram.CreateInstance().Uzytkownik.PrzegladOdbic();
            dataGridViewOdbicia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Form2_Load(object sender, EventArgs e)
        {           
            this.Text = "RCPprogram - strona główna";
            dateTimePickerDataod.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataod.CustomFormat = "yyyy-MM-dd";

            dateTimePickerDatado.Format = DateTimePickerFormat.Custom;
            dateTimePickerDatado.CustomFormat = "yyyy-MM-dd";

            if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR)||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.SZEF)||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY)||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY))
            {
                buttonUzytkownicy.Visible = true;
            }
            else
            {
                buttonUzytkownicy.Visible = false;
            }
            if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.KADROWY))
            {
                buttonRaport.Visible = true;
                buttonKarty.Visible = true;
            }
            else
            {
                buttonRaport.Visible = false;
                buttonKarty.Visible = false;
            }

            if (RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.ADMINISTRATOR) ||
                RCPprogram.CreateInstance().Uzytkownik.CzyGrupa(Grupa.PERSONALNY))
            {
                buttonReczneOdbicia.Visible = true;
            }
            else
            {
                buttonReczneOdbicia.Visible = false;
            }
        }
        private void ButtonUzytkownicy_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.UZYTKOWNICY);
        }
        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(false);
        }
        private void buttonWnioski_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.WNIOSKI);
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            RCPprogram.CreateInstance().Wyloguj(true);
        }
        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            DataTable odswiezona = RCPprogram.CreateInstance().Uzytkownik.PrzegladOdbicData(dateTimePickerDataod.Value.AddDays(0).ToString("yyyy-MM-dd 00:00:01"), dateTimePickerDatado.Value.AddDays(0).ToString("yyyy-MM-dd 23:59:59"));   
            dataGridViewOdbicia.DataSource = odswiezona;
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            WczytajGrid();
            labelImie.Text = RCPprogram.CreateInstance().Uzytkownik.Imie +
             " " + RCPprogram.CreateInstance().Uzytkownik.Nazwisko;
            labelStanowisko.Text = RCPprogram.CreateInstance().Uzytkownik.Stanowisko;
            labelEmail.Text = RCPprogram.CreateInstance().Uzytkownik.Email;
        }
        private void buttonOdbicia_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Uzytkownik.ZapiszOdbicieTeraz();
        }
        private void buttonRaport_Click(object sender, EventArgs e)
        {
            Raporty r = new Raporty();
            r.ShowDialog();
            r.Dispose();
        }
        private void buttonReczneOdbicia_Click(object sender, EventArgs e)
        {
            Odbicia r = new Odbicia();
            r.ShowDialog();
            r.Dispose();
        }
        private void ButtonHarmonogram_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.HARMONOGRAM);
        }
        private void ButtonKarty_Click(object sender, EventArgs e)
        {
            RCPprogram.CreateInstance().Home(RCPprogram.ehome.KARTY);
        }
    }
}
