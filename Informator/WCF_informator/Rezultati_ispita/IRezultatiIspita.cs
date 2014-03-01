using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_informator
{
    [ServiceContract]
    public interface IRezultatiIspita
    {
        [OperationContract]
        List<RezultatiIsipita> filter(DateTime vreme);

        [OperationContract]
        List<RezultatiIsipita> setRezultat();
    }

    [DataContract]
    public class RezultatiIsipita
    {
        [DataMember]
        public Predmeti predmet { get; set; }
        [DataMember]
        public DateTime datum { get; set; }
        [DataMember]
        public NastavnoOsoblje nastavnik { get; set; }
        [DataMember]
        public Uri pdf { get; set; }

    }

}
