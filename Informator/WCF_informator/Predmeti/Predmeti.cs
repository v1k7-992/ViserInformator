using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    public partial class Servis : IPredmeti
    {
        List<Predmeti> Predmeti = new List<Predmeti>();

        public List<Predmeti> ListaPredmeta()
        {
            for (int i = 0; i < 5; i++)
            {
                Predmeti.Add(new Predmeti
                {
                    naziv = "AOR" + i,
                    godina = 1,
                    semestar = 1,
                    studije = Studije.Nove_racunarske_tehnologije,
                    dalijemaster = false
                });
            }
            return Predmeti.OrderBy(p => p.naziv).ToList();
        }
        public List<Predmeti> PretragaPredmeta(string kriterijumzapretragu)
        {
            return Predmeti.Where(p => p.naziv.StartsWith(kriterijumzapretragu)).ToList();
        }
    }
}
