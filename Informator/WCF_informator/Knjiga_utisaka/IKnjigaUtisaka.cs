using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCF_informator
{
    [ServiceContract]
    public interface IKnjigaUtisaka
    {
        [OperationContract]
        List<Knjiga_Utisaka> utisci();

        [OperationContract]
        List<Knjiga_Utisaka> postavi(string _naslov, string _ispovest);

    }

    [DataContract]
    public class Knjiga_Utisaka {

        [DataMember]
        public string naslov { get; set; }
        [DataMember]
        public string utisak { get; set; }
        [DataMember]
        public DateTime vreme_objave { get; set; }
    }
}
