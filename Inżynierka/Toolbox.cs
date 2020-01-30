using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Inzynierka
{
    public static class Toolbox
    {
        public static string BRAK_DANYCH = "Brak danych";
        public static CultureInfo kultura = new CultureInfo("pl-PL", true);

        public static int inputInteger(int inputInteger, int min, int max)
        {
            int result = inputInteger;
            if (result < min || result > max)
            {
                result = 0;
            }
            return result;
        }
        public static string inputString(string inputText, bool canEmpty, int length, string defaultText = "Brak danych")
        {
            if (string.IsNullOrEmpty(inputText))
            {
                if (canEmpty) { inputText = ""; }
                else { inputText = defaultText; }
            }
            if (inputText.Length > length) { throw new FormatException("Wpisany tekst jest za długi."); }
            if (inputText.Contains("AUX")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("/*")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("--")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("xp_")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains(";")) { throw new FormatException("Tekst zawiera niedozwolony znak."); }
            if (inputText.Contains("CLOCK$")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM1")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM2")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM3")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM4")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM5")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM6")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM7")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("COM8")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("CONFIG$")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT1")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT2")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT3")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT4")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT5")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT6")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT7")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("LPT8")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("NUL")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            if (inputText.Contains("PRN")) { throw new FormatException("Tekst zawiera niedozwolony ciąg."); }
            inputText.Replace("'", "''");
            inputText.Replace("\"", "\"\"");
            inputText.Replace("\\", "\\\\");
            if (inputText.Length > length) { throw new FormatException("Wpisany tekst jest za długi."); }

            return inputText;
        }
        public static bool walidacjaEmail(string adresEmail, bool canEmpty)
        {
            if (string.IsNullOrEmpty(adresEmail) && canEmpty) return true;
            else if (string.IsNullOrEmpty(adresEmail)) return false;
            else
            {
                int counter = 0;
                int dlugosc = adresEmail.Length;

                for (int i = 0; i < dlugosc; i++)
                {
                    if (adresEmail[i].Equals('@')) { counter++; }
                }
                if (counter != 1) { return false; }

                char[] znakiSpecjalne = new char[] { '!', ' ', '#', '$', '%', '^', '&', '*', '(', ')', '+', '=' };

                foreach (char znakAdr in adresEmail)
                {
                    foreach (char znakSp in znakiSpecjalne)
                    {
                        if (znakAdr == znakSp)
                        {
                            return false;
                        }
                    }
                }

                Regex rgx = new Regex(@"^[0-9a-zA-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*(?<=[0-9a-z])@[0-9a-zA-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*[0-9a-zA-z]$");

                if (!rgx.IsMatch(adresEmail))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
