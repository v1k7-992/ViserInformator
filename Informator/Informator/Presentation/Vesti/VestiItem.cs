using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informator.Presentation.Vesti
{
    /// <summary>
    /// Ovo je model Vesti stranice
    /// Sadrzi tekst vesti, ukljucujuci i datum vesti.
    /// </summary>
    /// 
    public enum TipVesti { ISTAKNUTO = 0, OPSTE = 1, STRUKOVNE = 2 }
    public class VestiItem
    {
        public DateTime datumPostavljanja{get; set;}
        public string tekstVesti { get; set; }
        public TipVesti tip { get; set; }
        public string naslovVesti { get; set; }
        public string predmet { get; set; }

        public VestiItem(string text, DateTime vreme, TipVesti tip)
        {
            //TODO: Kako izraditi tip vesti, kao string, xml podatak, ili bytestream
        }
        public VestiItem(){
            datumPostavljanja = DateTime.Now;
            tekstVesti = "Bla bla bla bla";
            tip = TipVesti.ISTAKNUTO;
            naslovVesti = "Some random shit";
            predmet = "NRT";
        }
        
    }
}
