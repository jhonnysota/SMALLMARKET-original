using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ConceptoGastoE
    {

        [DataMember]
        public Int32 idConcepto { get; set; } 
 
        [DataMember]
        public String codConcepto { get; set; }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public String desConcepto { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        #region Lista ConceptoGasto

        [DataMember]
        public String numVourcher { get; set; }

        [DataMember]
        public String nombre { get; set; }

        [DataMember]
        public String mesPeriodo { get; set; }

        [DataMember]
        public String anioPeriodo { get; set; }

        [DataMember]
        public Decimal debeSoles { get; set; }

        [DataMember]
        public Decimal haberSoles { get; set; }

        [DataMember]
        public Decimal debeDolares { get; set; }

        [DataMember]
        public Decimal haberDolares { get; set; }

        [DataMember]
        public Decimal TotalImporte { get; set; }

        [DataMember]
        public Decimal TotalTotales { get; set; }
        
        #endregion

    }
}
