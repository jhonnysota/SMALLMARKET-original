using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class ProgramaPagoE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idProgramaPago { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public Int32 idPersona { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public String codFormaPago { get; set; }

        [DataMember]
        public Int32 idConcepto { get; set; }

        [DataMember]
		public String codTipoPago { get; set; }

		[DataMember]
		public Int32 idPersonaBanco { get; set; }

		[DataMember]
		public String idMonedaPago { get; set; }

		[DataMember]
		public String numCuenta { get; set; }

		[DataMember]
		public String numCheque { get; set; }

        [DataMember]
        public Int32? idBancoAuxliar { get; set; }

        [DataMember]
        public Int32? tipCtaAuxiliar { get; set; }

        [DataMember]
        public String idMonedaAuxiliar { get; set; }

        [DataMember]
        public String numCtaAuxiliar { get; set; }

        [DataMember]
		public String Grupo { get; set; }

		[DataMember]
		public String Glosa { get; set; }

		[DataMember]
		public DateTime? fecDocumento { get; set; }

		[DataMember]
		public Decimal? TipoCambio { get; set; }

		[DataMember]
		public DateTime? fecVencimiento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public String indDebeHaber { get; set; }

		[DataMember]
		public Decimal? Monto { get; set; }

		[DataMember]
		public String Aprobado { get; set; }

		[DataMember]
		public String Estado { get; set; }

		[DataMember]
		public Int32? idNumEgreso { get; set; }

		[DataMember]
		public String desBeneficiario { get; set; }

        [DataMember]
        public Decimal MontoOrigen { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String idDocumentoBanco { get; set; }

        [DataMember]
        public String SerieBanco { get; set; }

        [DataMember]
        public String NumeroBanco { get; set; }

        [DataMember]
        public Int32? idOrdenPago { get; set; }

        [DataMember]
        public Boolean indComision { get; set; }

        [DataMember]
        public Int32? idConceptoCom { get; set; }

        [DataMember]
        public Decimal MontoCom { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String tipPartidaPresu { get; set; }

        [DataMember]
        public String codPartidaPresu { get; set; }

        //Extensiones
        [DataMember]
        public String desPartida { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String nomBanco { get; set; }

        [DataMember]
        public Decimal AbonoSoles { get; set; }

        [DataMember]
        public Decimal CargoSoles { get; set; }

        [DataMember]
        public Decimal AbonoDolares { get; set; }

        [DataMember]
        public Decimal CargoDolares { get; set; }

        [DataMember]
        public Boolean FlagAprobacion { get; set; }

        [DataMember]
        public String NemoFormaPago { get; set; }

        [DataMember]
        public String desAprobacion { get; set; }

        [DataMember]
        public Boolean FlagEscoger { get; set; } //Para poder listar y escoger en el programa de pagos

        [DataMember]
        public String codOrdenPago { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public String NemoTipoPago { get; set; }

        [DataMember]
        public String VieneDeOp { get; set; }

    }   
}