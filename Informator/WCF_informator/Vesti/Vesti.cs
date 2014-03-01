using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_informator
{
    public partial class Servis : IVesti
    {

        List<Vesti> listaVesti = new List<Vesti>();

        /// <summary>
        /// Popunjava listu vesti
        /// </summary>
        /// <returns></returns>
        public List<Vesti> ListaVesti()
        {
                   
            //Skinuti for petlju kad se bude pustilo urad stavljena da bi imalo nesto da se prikaze
            for (int i = 0; i < 5; i++)
            {
                listaVesti.Add(new Vesti
                {
                    vaznost=true,
                    predmet = new Predmeti
                    {
                        naziv = "AOR" + i,
                        godina = 1,
                        semestar = 1,
                        studije = Studije.Nove_racunarske_tehnologije
                    },
                                 
                    naslov = "kolokvium"+i,

                    vest_detalji = "Oet kol iasdad asfd",
                
                    datum = DateTime.Today
                });
            }
            return listaVesti.OrderBy(p => p.predmet).ToList();
        }

        /// <summary>
        /// Vraca sve vesti za osnovne ili spec studije
        /// </summary>
        /// <param name="kriterijumZaPretragu"></param>
        /// <returns></returns>
        public List<Vesti> PretragaVesti(Boolean kriterijumZaPretragu)
        {      
            return listaVesti.Where(p => p.predmet.dalijemaster.Equals(kriterijumZaPretragu)).ToList();
        }

        /// <summary>
        /// Vraca zadati broj najnovih vesti za osnovne ili spec studije
        /// </summary>
        /// <param name="kriterijumZaPretragu"></param>
        /// <param name="broj"></param>
        /// <returns></returns>
        public List<Vesti> PretragaVestiOiliSpec(Boolean osnovne_spec, int broj)
        {
            return listaVesti.Where(p => p.predmet.dalijemaster.Equals(osnovne_spec)).OrderBy(p => p.datum).Take(broj).ToList();
        }

        /// <summary>
        /// Vraca zadati broj vaznih vesti
        /// </summary>
        /// <param name="Broj"></param>
        /// <returns></returns>
        public List<Vesti> PretragaVestiVazno(int broj)
        {
            return listaVesti.OrderBy(p => p.datum).Take(broj).ToList();
        }

        /// <summary>
        /// Vraca sve vesti
        /// </summary>
        /// <returns></returns>
        public List<Vesti> PretragaVesti()
        {
            return listaVesti;
        }
    }
}
