using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class LiquidacionSaldosE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public String codOrdenPago { get; set; }

        [DataMember]
        public Int32? idLiquidacion { get; set; }

        [DataMember]
		public Decimal SaldoAnterior { get; set; }

		[DataMember]
		public Decimal Abono { get; set; }

		[DataMember]
		public Decimal Liquidacion { get; set; }

		[DataMember]
		public String indEstado { get; set; }
        
    }   
}