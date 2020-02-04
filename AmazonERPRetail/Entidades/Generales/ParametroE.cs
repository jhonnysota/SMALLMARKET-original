using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class ParametroE
    {
        
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public Int32 IdParametro { get; set; }

        [DataMember]
        public Int32 idUsuario { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public Decimal ValorDecimal { get; set; }

        [DataMember]
        public String ValorCadena { get; set; }

        [DataMember]
        public Boolean Estado { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public DateTime FechaModificacion { get; set; }

    }
}
