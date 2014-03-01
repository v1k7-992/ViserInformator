using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    public partial class Servis : IRezultatiIspita
    {
        public List<RezultatiIsipita> filter(DateTime vreme) {

            return listaRezultata.Where(p => p.datum == vreme).ToList();
        }


        List<RezultatiIsipita> listaRezultata = new List<RezultatiIsipita>();

        public List<RezultatiIsipita> setRezultat()
        {
            //Skinuti for petlju kad se bude pustilo urad stavljena da bi imalo nesto da se prikaze
            for (int i = 0; i < 5; i++)
            {
                listaRezultata.Add(new RezultatiIsipita
                {
                    predmet = new Predmeti
                    {
                        naziv = "AOR" + i,
                        godina = 1,
                        semestar = 1,
                        studije = Studije.Nove_racunarske_tehnologije
                    },
                    nastavnik = new NastavnoOsoblje
                    {
                        ime = "Pera" + i,
                        prezime = "Peric",
                        zvanje = ZvanjeEnum.Doktor,
                        vrstaNastavnogOsoblja = VrstaEnum.Profesor.ToString(),
                        email = "HURRDURR@trtprt.com",
                        kabinet = "405"
                    },
                    datum = DateTime.Now,
                    pdf = new Uri("http://www.pierobon.org/iis/review1.htm.html#one")   
                });
            }
            return listaRezultata.OrderBy(p => p.datum).ToList();
        }

    }
}
