using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class UbigeoE
    {

        [DataMember]
        public String idUbigeo { get; set; }

        [DataMember]
        public String Departamento { get; set; }

        [DataMember]
        public String Provincia { get; set; }

        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public Boolean indBaja { get; set; }

        [DataMember]
        public Int32 idPais { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; } 

        //Otros Campos
        [DataMember]
        public String NombrePais { get; set; }
        
    }
}
