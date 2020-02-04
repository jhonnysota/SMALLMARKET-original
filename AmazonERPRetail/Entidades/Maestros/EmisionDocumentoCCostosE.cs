using System;
using System.Runtime.Serialization;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public class EmisionDocumentoCCostosE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public Decimal? ImporteOriginal { get; set; }

        [DataMember]
        public Decimal? Porcentaje { get; set; }

        [DataMember]
        public Decimal? ImportePorcentaje { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String DesCCostos { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }



    }   
}