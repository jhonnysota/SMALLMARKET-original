using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class RegistroVentasE
    {
         
        [DataMember]
		public Int32 idRegistro { get; set; }

		[DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String Anio { get; set; }

		[DataMember]
		public String Mes { get; set; }

		[DataMember]
		public DateTime? fecDocumento { get; set; }

		[DataMember]
		public String tipDocVenta { get; set; }

		[DataMember]
		public String Serie { get; set; }

		[DataMember]
		public String Numero { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String tipDocPersona { get; set; }

		[DataMember]
		public String numDocPersona { get; set; }

		[DataMember]
		public String RazonSocial { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

		[DataMember]
		public Decimal BaseExportacion { get; set; }

		[DataMember]
		public Decimal BaseInafecta { get; set; }

		[DataMember]
		public Decimal BaseImponible { get; set; }

		[DataMember]
		public Decimal Igv { get; set; }

		[DataMember]
		public Decimal Total { get; set; }

		[DataMember]
		public Decimal Tica { get; set; }

		[DataMember]
		public String tipDocVentaRef { get; set; }

		[DataMember]
		public String SerieRef { get; set; }

		[DataMember]
		public String NumeroRef { get; set; }

		[DataMember]
		public DateTime? FechaRef { get; set; }

		[DataMember]
		public Decimal? Percepcion { get; set; }

		[DataMember]
		public Boolean csIgv { get; set; }

		[DataMember]
		public String Correlativo { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extensiones...
        [DataMember]
        public String Periodo { get; set; }

        [DataMember]
        public String PrimerDigito { get; set; }

        [DataMember]
        public Decimal dctoBaseImponible { get; set; }

        [DataMember]
        public Decimal dsctoIgv { get; set; }

        [DataMember]
        public Decimal BaseExonerada { get; set; }

        [DataMember]
        public Decimal Isc { get; set; }

        [DataMember]
        public Decimal BaseImponibleIvap { get; set; }

        [DataMember]
        public Decimal Ivap { get; set; }

        [DataMember]
        public Decimal OtrosTributos { get; set; }

        [DataMember]
        public String Inconsistencia { get; set; }

        [DataMember]
        public String Identificacion { get; set; }

        [DataMember]
        public String idMedioPago { get; set; }

        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public DateTime? fecVencimiento { get; set; }

        [DataMember]
        public String Voucher { get; set; }

        [DataMember]
        public String VTA { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public DateTime? FecOperacion { get; set; }

        [DataMember]
        public String NumFile { get; set; }

        [DataMember]
        public String Diario { get; set; }

        [DataMember]
        public String tipoPersoneriaDaot { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String ApePat { get; set; }

        [DataMember]
        public String ApeMat { get; set; }

    }   
}