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
    public interface IAdresar
    {
        /// <summary>
        /// Servisna operacija vraća list celokupnog nastavnog osoblja
        /// </summary>
        /// <returns>List<NastavnoOsoblje></returns>
        [OperationContract]
        List<NastavnoOsoblje> ListaNastavnogOsoblja();

        /// <summary>
        /// Servisna operacija vraća list nastavnog osoblja filtriranu po zadatom kriterijumu
        /// </summary>
        /// <param name="kriterijumZaPretragu">Kriterijum za pretragu nastavnog osoblja</param>
        /// <returns>List<NastavnoOsoblje></returns>
        [OperationContract]
        List<NastavnoOsoblje> PretragaNastavnogOsoblja(string kriterijumZaPretragu);
    }

    [DataContract]
    public class NastavnoOsoblje
    {
        [DataMember]
        public string ime { get; set; }
        [DataMember]
        public string prezime { get; set; }
        [DataMember]
        public ZvanjeEnum zvanje { get; set; }
        [DataMember]
        public string vrstaNastavnogOsoblja { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string kabinet { get; set; }
    }

    [DataContract(Name = "Vrsta")]
    public enum VrstaEnum
    { 
        [EnumMember]
        Saradnik_u_nastavi,
        [EnumMember]
        Saradnik_u_laboratoriji,
        [EnumMember]
        Laborant,
        [EnumMember]
        Profesor,
        [EnumMember]
        Predavac,
        [EnumMember]
        Spoljni_saradnik,
        [EnumMember]
        Asistent,
        [EnumMember]
        Ostali
    }
    [DataContract(Name = "Zvanje")]
    public enum ZvanjeEnum
    { 
        [EnumMember]
        Doktor,
        [EnumMember]
        Magistar,
        [EnumMember]
        Master,
        [EnumMember]
        Inzenjer
    }
}
