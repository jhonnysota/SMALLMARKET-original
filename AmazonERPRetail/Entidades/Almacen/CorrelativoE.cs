using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class CorrelativoE
    {
            
        [DataMember]


        [DataMember]
        public Int32 idTipo { get; set; }







      
        public String formato { get; set; }
        public String desTipo { get; set; }
    }   
}