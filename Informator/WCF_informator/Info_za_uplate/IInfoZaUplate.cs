using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    [ServiceContract]
    public interface IInfoZaUplate
    {
        [OperationContract]
        List<InfoZaUplateDetalji> DetaljiUplatioca(string brindeksa);
    }
    [DataContract]
    public class InfoZaUplateDetalji
    {
        [DataMember]
        public string ime { get; set; }
        [DataMember]
        public string prezime { get; set; }
        [DataMember]
        public string adresa { get; set; }
        [DataMember]
        public string indeks { get; set; }
    }
}
