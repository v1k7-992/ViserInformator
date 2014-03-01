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
    public interface IPredmeti
    {
        /// <summary>
        /// Vraca listu svih predmeta
        /// </summary>
        /// <returns> List </returns>
        [OperationContract]
        List<Predmeti> ListaPredmeta();
        /// <summary>
        /// Vraca listu predmeta filtriranu po kriterijumu za pretragu tipa string
        /// </summary>
        /// <param name="kriterijumzapretragu"></param>
        /// <returns> List </returns>
        [OperationContract]
        List<Predmeti> PretragaPredmeta(string kriterijumzapretragu);
    }

    [DataContract]
    public class Predmeti
    {
        [DataMember]
        public string naziv { get; set; }
        [DataMember]
        public int godina { get; set; }
        [DataMember]
        public int semestar { get; set; }
        [DataMember]
        public Studije studije { get; set; }
        [DataMember]
        public List<int> NastavnoOsoblje_IDs { get; set; }
        [DataMember]
        public Boolean dalijemaster = false;
    }

    [DataContract(Name = "Studije")]
    public enum Studije
    {
        [EnumMember]
        Audio_i_video_tehnologije,
        [EnumMember]
        Automatika_i_sistemi_upravljanja_vozila,
        [EnumMember]
        Elektronika_i_telekomunikacije,
        [EnumMember]
        Nove_energetske_tehnologije,
        [EnumMember]
        Elektronsko_poslovanje,
        [EnumMember]
        Nove_racunarske_tehnologije,
        [EnumMember]
        Nove_racunarske_tehnologije_na_daljinu,
        [EnumMember]
        Racunarska_tehnika,
        [EnumMember]
        Spec_nove_racunarske_tehnologije,
        [EnumMember]
        Spec_elektronika_i_telekomunikacije,
        [EnumMember]
        Spec_multimedijalne_tehnologije_i_digitalna_telivizija,
        [EnumMember]
        Spec_nove_energetske_tehnologije,
        [EnumMember]
        Spec_sigurnost_informaciono_komunikacionih_sistema,
        [EnumMember]
        Spec_mehatronika
    }  
}
