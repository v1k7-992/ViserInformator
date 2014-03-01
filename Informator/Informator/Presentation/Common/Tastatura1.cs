using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Informator.Presentation.Common
{
    /*
     * Brojevi: 0 - 9 (10)
       Slova: 30
       Ostali: / , - , @ (4)
       Dodatno: Space, Enter, BackSpace, ToUpper (4);
       Total: 48 karaktera
     * 
     * --- 12 kar po 3 reda
     * --- 0 - 9 / Backspace
     * --- A 0 - 12
     * --- A 13 - 24
     * --- A toUpper 25 - 31 + 4 (., - ,Space, Backspace)
     */
    public class aTastatura
    {
        List<String> slova = new List<String>();
        public aTastatura() {
            //Prvi red
            slova.Add("0"); slova.Add("1"); slova.Add("2"); slova.Add("3"); slova.Add("4"); slova.Add("5");
            slova.Add("6"); slova.Add("7"); slova.Add("8"); slova.Add("9"); slova.Add("/"); slova.Add("←");
            //Drugi red 
            slova.Add("а"); slova.Add("б"); slova.Add("в"); slova.Add("г"); slova.Add("д"); slova.Add("ђ");
            slova.Add("е"); slova.Add("ж"); slova.Add("з"); slova.Add("и"); slova.Add("ј"); slova.Add("к");
            // Treci red
            slova.Add("л"); slova.Add("љ"); slova.Add("м"); slova.Add("н"); slova.Add("њ"); slova.Add("о");
            slova.Add("п"); slova.Add("р"); slova.Add("с"); slova.Add("т"); slova.Add("ћ"); slova.Add("у"); 
            // Cetvrti red
            slova.Add("ф"); slova.Add("х"); slova.Add("ц"); slova.Add("ч"); slova.Add("џ"); slova.Add("ш"); 
            slova.Add("↑"); slova.Add(" "); slova.Add("@"); slova.Add("."); slova.Add("-"); slova.Add("⏎");



         

        }
        public void dodajDugmad(Grid grid) {
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 12; j++)
                    i=0;

        }

        public int duzinaListe() {
            return slova.Count;
        }

        public String dohvatiDugme(int i) {
            //return slova.ElementAt(i);
            return slova.ElementAt(i);
        }

        private void klikDirke(object sender, EventArgs e) {
            if (sender is Button) {
                Button pritisnut = (Button)sender;
                if (pritisnut.Content.Equals("Размак")) ;
                else if (pritisnut.Content.Equals("OK")) ;
                else if (pritisnut.Content.Equals("")) ;
            }
        }
    }
}
