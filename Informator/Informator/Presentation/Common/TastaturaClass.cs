using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Informator.Presentation.Common
{
    class TastaturaClass
    {

        public List<String> slova = new List<String>();

        public TastaturaClass() {

            //Prvi red
            slova.Add("0"); slova.Add("1"); slova.Add("2"); slova.Add("3"); slova.Add("4"); slova.Add("5");
            slova.Add("6"); slova.Add("7"); slova.Add("8"); slova.Add("9"); slova.Add("/"); slova.Add("←"); 
            
            //Drugi red 
            slova.Add("љ"); slova.Add("њ"); slova.Add("е"); slova.Add("р"); slova.Add("т"); slova.Add("з");
            slova.Add("у"); slova.Add("и"); slova.Add("о"); slova.Add("п"); slova.Add("ш"); slova.Add("ђ"); 
            
            // Treci red
             slova.Add("а"); slova.Add("с"); slova.Add("д"); slova.Add("ф"); slova.Add("г"); slova.Add("х");
             slova.Add("ј"); slova.Add("к"); slova.Add("л"); slova.Add("ч"); slova.Add("ћ"); slova.Add("ж");
            // Cetvrti red
             slova.Add("ѕ"); slova.Add("џ"); slova.Add("ц"); slova.Add("в"); slova.Add("б"); slova.Add("н"); slova.Add("м");  slova.Add("⏎");
             slova.Add("↑"); slova.Add("@"); slova.Add(" "); slova.Add("."); slova.Add(","); slova.Add("-"); 

        }


        public int duzina() {
            return slova.Count;
        }
        
    }
}
