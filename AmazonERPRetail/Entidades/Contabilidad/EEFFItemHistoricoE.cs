using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class EEFFItemHistoricoE
    {
            
        [DataMember]










        //extensiones

        [DataMember]
        public String secItem { get; set; }

        [DataMember]
        public String desItem { get; set; }

        [DataMember]
        public String TipoTabla { get; set; }



    }   
}