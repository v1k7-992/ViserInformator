using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_informator
{
    [ServiceContract]
    public interface IVesti
    {
        /// <summary>
        /// Dodaje vest u listu vesti
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        List<Vesti> ListaVesti();

        [OperationContract]
        List<Vesti> PretragaVesti(Boolean kriterijumZaPretragu);

        //[OperationContract]
        //List<Vesti> PretragaVesti(Boolean kriterijumZaPretragu,int broj);

        //[OperationContract]
        //List<Vesti> PretragaVesti(int broj);
    }

    [DataContract]
    public class Vesti
    {
        [DataMember]
        public Boolean vaznost { get; set; }
        [DataMember]
        public Predmeti predmet { get; set; }
        [DataMember]
        public string naslov { get; set; }
        [DataMember]
        public string vest_detalji { get; set; }
        [DataMember]
        public DateTime datum { get; set; }

    }

  
    
}
