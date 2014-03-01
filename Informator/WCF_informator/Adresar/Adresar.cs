using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace WCF_informator
{
    
    public partial class Servis : IAdresar
    {   
        List<NastavnoOsoblje> nastavnoOsoblje = new List<NastavnoOsoblje>();

        public List<NastavnoOsoblje> ListaNastavnogOsoblja()
        {
            
            for (int i = 0; i < 5; i++)
            {
                nastavnoOsoblje.Add(new NastavnoOsoblje
                {
                    ime = "Pera"+i,
                    prezime = "Peric",
                    zvanje = ZvanjeEnum.Doktor,
                    vrstaNastavnogOsoblja = VrstaEnum.Profesor.ToString(),
                    email = "HURRDURR@trtprt.com",
                    kabinet = "405"
                });
            }
            return nastavnoOsoblje.OrderBy(p => p.ime).ToList();
        }
        public List<NastavnoOsoblje> PretragaNastavnogOsoblja(string kriterijumZaPretragu)
        {
            for (int i = 0; i < 5; i++)
            {
                nastavnoOsoblje.Add(new NastavnoOsoblje
                {
                    ime = "Pera" + i,
                    prezime = "Peric",
                    zvanje = ZvanjeEnum.Doktor,
                    vrstaNastavnogOsoblja = VrstaEnum.Profesor.ToString(),
                    email = "HURRDURR@trtprt.com",
                    kabinet = "405"
                });
            }

            return nastavnoOsoblje.Where(p => p.ime.StartsWith(kriterijumZaPretragu)
                || p.prezime.StartsWith(kriterijumZaPretragu)).ToList();
        }
    }
}
