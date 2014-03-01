using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informator.Presentation.Common
{
    public static class Navigacija
    {
        public static  Uri pgMain { get { return new Uri("/Presentation/Main/pgMain.xaml", UriKind.Relative); } }
        public static  Uri pgPredmeti { get { return new Uri("/Presentation/Predmeti/pgPredmeti.xaml", UriKind.Relative); } }
        public static  Uri pgInfo_za_uplate { get { return new Uri("/Presentation/Info_za_uplate/pgInfo_za_uplate.xaml", UriKind.Relative); } }
        public static  Uri pgKnjiga_utisaka { get { return new Uri("/Presentation/Knjiga_utisaka/pgKnjiga_utisaka.xaml", UriKind.Relative); } }
        public static  Uri Nastava_i_vezbe { get { return new Uri("/Presentation/Nastava_i_vezbe/pgNastava_i_vezbe.xaml", UriKind.Relative); } }
        public static  Uri pgRezultati_ispita { get { return new Uri("/Presentation/Rezultati_ispita/pgRezultati_ispita.xaml", UriKind.Relative); } }
        public static  Uri pgVesti { get { return new Uri("/Presentation/Vesti/pgVesti.xaml", UriKind.Relative); } }
        public static  Uri pgAdresar { get { return new Uri("/Presentation/Adresar/pgAdresar.xaml", UriKind.Relative); } }
        //public static  Uri pgTast { get { return new Uri("/Presentation/Common/TastaturaXAML.xaml", UriKind.Relative); } }
        
       
    }
}
