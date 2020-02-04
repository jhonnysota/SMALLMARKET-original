using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class RegistroComprasE
    {
        [DataMember]
		public String Periodo { get; set; }

        [DataMember]
		public String Correlativo { get; set; }

        [DataMember]
		public String PrimerDigito { get; set; }

        [DataMember]
		public Int32 idLocal { get; set; }

        [DataMember]
		public DateTime? fecDocumento { get; set; }

        [DataMember]
		public DateTime? fecVencimiento { get; set; }

        [DataMember]
		public String tipDocumentoVenta { get; set; }

        [DataMember]
		public String depAduanera { get; set; }

        [DataMember]
		public String Anio { get; set; }

        [DataMember]
		public String serDocumento { get; set; }

        [DataMember]
		public String numDocumento { get; set; }

        [DataMember]
		public String tipDocPersona { get; set; }

        [DataMember]
		public String RUC { get; set; }

        [DataMember]
		public String RazonSocial { get; set; }

        [DataMember]
		public Decimal BaseGravado { get; set; }

        [DataMember]
		public Decimal IgvGrabado { get; set; }

        [DataMember]
		public Decimal BaseGravadoNoGravado { get; set; }

        [DataMember]
		public Decimal IgvGravadoNoGravado { get; set; }

        [DataMember]
		public Decimal BaseSinDerecho { get; set; }

        [DataMember]
		public Decimal IgvSinDerecho { get; set; }

        [DataMember]
		public Decimal BaseNoGravado { get; set; }

        [DataMember]
		public Decimal ISC { get; set; }

        [DataMember]
		public Decimal Otros { get; set; }

        [DataMember]
		public Decimal Total { get; set; }

        [DataMember]
		public String docDomiciliado { get; set; }

        [DataMember]
		public String flagDetraccion { get; set; }

        [DataMember]
		public String numDetraccion { get; set; }

        [DataMember]
		public DateTime? fecDetraccion { get; set; }

        [DataMember]
        public String codTasa { get; set; }

        [DataMember]
		public Decimal tipCambio { get; set; }

        [DataMember]
		public DateTime? fecDocumentoRef { get; set; }

        [DataMember]
		public String idDocumentoRef { get; set; }

        [DataMember]
		public String serDocumentoRef { get; set; }

        [DataMember]
		public String numDocumentoRef { get; set; }

        [DataMember]
		public Decimal VariacionIgv { get; set; }

        [DataMember]
		public String Moneda { get; set; }

        [DataMember]
		public String Dua { get; set; }

        [DataMember]
		public String PaisOrigen { get; set; }

        [DataMember]
        public String ApePat { get; set; }

        [DataMember]
        public String ApeMat { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String flagRetencion { get; set; }

        [DataMember]
		public String TipoRenta { get; set; }

        [DataMember]
		public String Rectificacion { get; set; }

        [DataMember]
        public DateTime? fecRectificacion { get; set; }

        //ext henry

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
		public String idDocumento { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String codColumnaCoven { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String desMes { get; set; }

        [DataMember]
        public String GlosaGeneral { get; set; }

        [DataMember]
        public String AnioDua { get; set; }

        [DataMember]
        public String tipoPersoneriaDaot { get; set; }

        /***************************************************************************************************************/
        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public Decimal OtrosConceptos { get; set; }

        [DataMember]
        public string tipDocCreditoFiscal { get; set; }

        [DataMember]
        public string nroDua { get; set; }

        [DataMember]
        public string IdentiBeneficiario { get; set; }

        [DataMember]
        public string RazonBeneficiario { get; set; }

        [DataMember]
        public string PaisBeneficiario { get; set; }

        [DataMember]
        public string VinculacionEconomica { get; set; }

        [DataMember]
        public decimal RentaBruta { get; set; }

        [DataMember]
        public decimal EnajenacionBienes { get; set; }

        [DataMember]
        public decimal RentaNeta { get; set; }

        [DataMember]
        public decimal TasaRetencion { get; set; }

        [DataMember]
        public decimal ImpuestoRetenido { get; set; }

        [DataMember]
        public string ConvenioDobImpo { get; set; }

        [DataMember]
        public string ExoneracionApli { get; set; }

        [DataMember]
        public string ModalidadServicio { get; set; }

        [DataMember]
        public string LeyImpuestoRenta { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string desFile { get; set; }

    }
}