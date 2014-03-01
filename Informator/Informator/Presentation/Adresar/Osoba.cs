using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informator.Presentation.Adresar
{
    public class Osoba
    {
        public string imeprezime;
        public string zvanje;
        public string[] predmeti;
        public string konsultacije;
        public int kabinet;
        public string mail;

        public Osoba() {
            TextBox t1 = new TextBox();
            
            imeprezime = "Ime i prezime";
            zvanje = "Profesor";
            kabinet = 112;
            mail = "MileKitic@viser.edu.rs";
        }
    }
}
