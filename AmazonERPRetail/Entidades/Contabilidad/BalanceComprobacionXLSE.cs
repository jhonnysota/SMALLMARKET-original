using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class BalanceComprobacionXLSE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idUsuario { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }

        [DataMember]
        public String NumeroCuenta { get; set; }

        [DataMember]
        public String DescripcionBalance { get; set; }

        [DataMember]
        public Decimal TotalInforme { get; set; }

        [DataMember]
        public Decimal TotalComparacion { get; set; }

        [DataMember]
        public Decimal DesviacionAbsoluta { get; set; }

        [DataMember]
        public String CtaIndusoft { get; set; }

        //[DataMember]
        //public DateTime Fecha { get; set; }

    }
}
