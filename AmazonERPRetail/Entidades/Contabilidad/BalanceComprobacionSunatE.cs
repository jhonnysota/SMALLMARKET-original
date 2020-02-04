using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class BalanceComprobacionSunatE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public String AnioPeriodo { get; set; }
		[DataMember]		public String MesPeriodo { get; set; }
		[DataMember]		public String codCuentaSunat { get; set; }
		[DataMember]		public Decimal SaldoInicialDebe { get; set; }
		[DataMember]		public Decimal SaldoInicialHaber { get; set; }
		[DataMember]		public Decimal MovimientoDebe { get; set; }
		[DataMember]		public Decimal MovimientoHaber { get; set; }
		[DataMember]		public Decimal SumasMayorDebe { get; set; }
		[DataMember]		public Decimal SumasMayorHaber { get; set; }
		[DataMember]		public Decimal SaldoDebe { get; set; }
		[DataMember]		public Decimal SaldoHaber { get; set; }
		[DataMember]		public Decimal TransCancDebe { get; set; }
		[DataMember]		public Decimal TransCancHaber { get; set; }
		[DataMember]		public Decimal BalanceActivo { get; set; }
		[DataMember]		public Decimal BalancePasivo { get; set; }
		[DataMember]		public Decimal RPNaturalezaPerdida { get; set; }
		[DataMember]		public Decimal RPNaturalezaGanancia { get; set; }
		[DataMember]		public Decimal Adiciones { get; set; }
		[DataMember]		public Decimal Deducciones { get; set; }
		[DataMember]		public String Estado { get; set; }

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