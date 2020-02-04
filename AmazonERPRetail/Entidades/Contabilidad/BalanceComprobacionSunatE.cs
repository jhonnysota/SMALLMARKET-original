using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class BalanceComprobacionSunatE
    {
            
        [DataMember]





















        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

        [DataMember]
        public String Descripcion { get; set; }
        

    }   
}