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
    public interface INastavaIvezbe
    {
        [OperationContract]
        List<Nastava_I_Vezbe> raspored_nastave(DateTime zadato_vreme);

        [OperationContract]
        List<Nastava_I_Vezbe> raspored_vezbi(DateTime zadato_vreme);

        [OperationContract]
        List<Nastava_I_Vezbe> u_toku(DateTime zadato_vreme);   
    }

    [DataContract]
    public class Nastava_I_Vezbe
    {
        [DataMember]
        public string naziv { get; set; }
        [DataMember]
        public Izbor izbor { get; set; }
        [DataMember]
        public DateTime vreme_pocetka { get; set; }
        [DataMember]
        public DateTime vreme_zavrsetka { get; set; }
        [DataMember]
        public DateTime datum { get; set; }
        
    }


    [DataContract(Name = "Vrsta")]
    public enum Izbor
    {
        [EnumMember]
        Nastava,
        [EnumMember]
        Vezbe
    }
}
