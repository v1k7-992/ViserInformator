using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    public partial class Servis : INastavaIvezbe
    {
        List<Nastava_I_Vezbe> nastava_i_vezbe = new List<Nastava_I_Vezbe>();


        public List<Nastava_I_Vezbe> raspored_nastave(DateTime zadato_vreme) { 
         
                        
            for(int i = 0; i < 5; i++){
                nastava_i_vezbe.Add(new Nastava_I_Vezbe
                {
                    naziv = "nastava" + i,
                    izbor = Izbor.Nastava,
                    vreme_pocetka = new DateTime(2013, 2, 1, i, i, i),
                    vreme_zavrsetka = new DateTime(2013, 2, 1, i + 1, i + 1, i + 1),
                    datum = new DateTime(2013, i, i)
                });
            }
            return nastava_i_vezbe;
        }

        public List<Nastava_I_Vezbe> raspored_vezbi(DateTime zadato_vreme) {

            for (int i = 0; i < 5; i++)
            {
                nastava_i_vezbe.Add(new Nastava_I_Vezbe
                {
                    naziv = "nastava" + i,
                    izbor = Izbor.Vezbe,
                    vreme_pocetka = new DateTime(2013, 2, 1, i, i, i),
                    vreme_zavrsetka = new DateTime(2013, 2, 1, i + 1, i + 1, i + 1),
                    datum = new DateTime(2013, i, i)
                });
            }
            return nastava_i_vezbe;

        }


        public List<Nastava_I_Vezbe> u_toku(DateTime zadato_vreme)
        {
            for (int i = 0; i < 5; i++)
            {
                nastava_i_vezbe.Add(new Nastava_I_Vezbe
                {
                    naziv = "nastava" + i,
                    izbor = Izbor.Vezbe,
                    vreme_pocetka = new DateTime(2013, 2, 1, i, i, i),
                    vreme_zavrsetka = new DateTime(2013, 2, 1, i + 1, i + 1, i + 1),
                    datum = new DateTime(2013, i, i)
                });
            }

            return nastava_i_vezbe.Where(p => p.datum == zadato_vreme).ToList();
        }
    }
}
