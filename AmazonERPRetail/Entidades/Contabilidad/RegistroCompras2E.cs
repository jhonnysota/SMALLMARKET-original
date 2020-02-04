using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class RegistroCompras2E
    {
            
        [DataMember]
		public Int32 idRegCompras { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
        public DateTime fecOperacion { get; set; }

        [DataMember]
		public String AnioPeriodo { get; set; }

		[DataMember]
		public String MesPeriodo { get; set; }

		[DataMember]
		public String idComprobante { get; set; }

		[DataMember]
		public String numFile { get; set; }

		[DataMember]
		public String numVoucher { get; set; }

        [DataMember]
        public Boolean indVoucher { get; set; }

        [DataMember]
        public bool indHojaCosto { get; set; }

        [DataMember]
		public Int32? idHojaCosto { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public int? idPersona { get; set; }

        [DataMember]
        public int? idPersonaBen { get; set; }

        [DataMember]
		public String Periodo { get; set; }

		[DataMember]
		public String Correlativo { get; set; }

		[DataMember]
		public DateTime? fecEmisDocumento { get; set; }

		[DataMember]
		public DateTime? fecVencimiento { get; set; }

		[DataMember]
		public String tipDocumentoVenta { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public Decimal? ValorAdquisicion { get; set; }

		[DataMember]
		public Decimal? OtrosConceptos { get; set; }

		[DataMember]
		public Decimal? TotalAdquisiciones { get; set; }

		[DataMember]
		public String tipDocCreditoFiscal { get; set; }

		[DataMember]
		public String serCreditoFiscal { get; set; }

		[DataMember]
		public String AnioDua { get; set; }

		[DataMember]
		public String numCreditoFiscal { get; set; }

		[DataMember]
		public Decimal? MontoIgvRet { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

        [DataMember]
        public Boolean indTicaAuto { get; set; }

        [DataMember]
		public Decimal? tipCambio { get; set; }

		[DataMember]
		public String PaidResidencia { get; set; }

		[DataMember]
		public String tipDocPersona { get; set; }

		[DataMember]
		public Decimal? BaseGravado { get; set; }

		[DataMember]
		public Decimal? IgvGrabado { get; set; }

		[DataMember]
		public Decimal? BaseGravadoNoGravado { get; set; }

		[DataMember]
		public Decimal? IgvGravadoNoGravado { get; set; }

		[DataMember]
		public Decimal? BaseSinDerecho { get; set; }

		[DataMember]
		public Decimal? IgvSinDerecho { get; set; }

		[DataMember]
		public Decimal? BaseNoGravado { get; set; }

		[DataMember]
		public Decimal? ISC { get; set; }

		[DataMember]
		public DateTime? fecDocumentoRef { get; set; }

		[DataMember]
		public String idDocumentoRef { get; set; }

		[DataMember]
		public String serDocumentoRef { get; set; }

		[DataMember]
		public String numDocumentoRef { get; set; }

		[DataMember]
		public String numDetraccion { get; set; }

		[DataMember]
		public DateTime? fecDetraccion { get; set; }

		[DataMember]
		public Boolean flagRetencion { get; set; }

		[DataMember]
		public String ClasificacionBienServ { get; set; }

		[DataMember]
		public String PaisBeneficiario { get; set; }

		[DataMember]
		public String Vinculo { get; set; }

		[DataMember]
		public Decimal? RentaBruta { get; set; }

		[DataMember]
		public Decimal? EnajenacionBienes { get; set; }

		[DataMember]
		public Decimal? RentaNeta { get; set; }

		[DataMember]
		public Decimal? TasaRetencion { get; set; }

		[DataMember]
		public Decimal? ImpuestoRetenido { get; set; }

		[DataMember]
		public String ConvenioDobImpo { get; set; }

		[DataMember]
		public String ExoneracionApli { get; set; }

		[DataMember]
		public String TipoRenta { get; set; }

		[DataMember]
		public String ModalidadServicio { get; set; }

		[DataMember]
		public String LeyImpuestoRenta { get; set; }

		[DataMember]
		public String Estado { get; set; }

		[DataMember]
		public Int32 TipoCompra { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public String numIdentificacion { get; set; }

        [DataMember]
        public String numIdentiBenef { get; set; }

        [DataMember]
        public String RazonBeneficiario { get; set; }

    }   
}