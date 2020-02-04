using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class UMedidaE
    {

        [DataMember]
        public Int32 idUMedida { get; set; }
        [DataMember]
        public String NomUMedida { get; set; }
        [DataMember]
        public String NomUMedidaCorto { get; set; }
        [DataMember]
        public Decimal CantConversion { get; set; }
        [DataMember]
        public Decimal Contenido { get; set; }
        [DataMember]
        public String codSunat { get; set; }
        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public String UsuarioModificacion { get; set; }
        [DataMember]
        public DateTime? FechaModificacion { get; set; }
        [DataMember]
        public String UnidadMedida { get; set; }        

    }   
}