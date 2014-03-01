using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    public partial class Servis : IKnjigaUtisaka
    {
        List<Knjiga_Utisaka> _utisci = new List<Knjiga_Utisaka>();

        public List<Knjiga_Utisaka> utisci()
        {

            for (int i = 0; i < 5; i++)
            {
                _utisci.Add(new Knjiga_Utisaka
                {
                    naslov = "naslov" + 1,
                    utisak = "utisak utisakutisakutisakutisakutisak" + i,
                    vreme_objave = new DateTime(2013, 3, 5)
                });
            }
            return _utisci;
        }

        List<Knjiga_Utisaka> postavi(string _naslov, string _ispovest)
        {
            _utisci.Add(new Knjiga_Utisaka
            {
                naslov = _naslov,
                utisak = _ispovest,
                vreme_objave = DateTime.Now
            });

            return _utisci;
        }


        List<Knjiga_Utisaka> IKnjigaUtisaka.postavi(string _naslov, string _ispovest)
        {
            throw new NotImplementedException();
        }
    }
}
