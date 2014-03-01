using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    public partial class Servis : IInfoZaUplate
    {
        public List<InfoZaUplateDetalji> infozauplate = new List<InfoZaUplateDetalji>();

        public List<InfoZaUplateDetalji> DetaljiUplatioca(string brindeksa)
        {
            for (int i = 0; i < 5; i++)
            {
                infozauplate.Add(new InfoZaUplateDetalji
                {
                    ime = "Pera",
                    prezime = "Peric",
                    adresa = "Lasla Krausa, 123",
                    indeks = "rt-21/11"
                });
            }
            return infozauplate.Where(p => p.indeks.Contains(brindeksa)).ToList();
        }
    }
}
