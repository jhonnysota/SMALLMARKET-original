using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class comisionE
    {
            
        [DataMember]








        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String ApeMaterno { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }

        [DataMember]
        public String NroDocumento { get; set; }
    }   
}