using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class LiquidacionDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idLiquidacion { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public Int32 tipoDocumento { get; set; }

		[DataMember]
		public Int32? idProvision { get; set; }

		[DataMember]
		public Int32? idMovilidad { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime? FechaDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

        [DataMember]
        public Boolean indTicaAuto { get; set; }

        [DataMember]
		public Decimal TipoCambio { get; set; }

		[DataMember]
		public Decimal MontoLiquidar { get; set; }

		[DataMember]
		public String Glosa { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public Int32? idConcepto { get; set; }

        [DataMember]
        public String indReparable { get; set; }

        [DataMember]
        public Int32? idConceptoRep { get; set; }

        [DataMember]
        public String desReferenciaRep { get; set; }

        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
		public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        //Extensiones
        [DataMember]
        public String DesCCostos { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }
        
        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desTipoDocumento { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String TipoLiqui { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String Concepto { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public Decimal impSoles { get; set; }

        [DataMember]
        public Decimal impDolares { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public String desAuxiliar { get; set; }

        [DataMember]
        public String Voucher { get; set; }

        [DataMember]
        public String desEstado { get; set; }

        [DataMember]
        public ProvisionesE oProvision { get; set; }

        [DataMember]
        public MovilidadE oMovilidad { get; set; }

        [DataMember]
        public String codConcepto { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public Boolean ActualizarProvMov { get; set; }

        [DataMember]
        public Decimal VVentaSoles { get; set; }

        [DataMember]
        public Decimal IgvSoles { get; set; }

        [DataMember]
        public Decimal TotalSoles { get; set; }

        [DataMember]
        public Decimal VVentaDolar { get; set; }

        [DataMember]
        public Decimal IgvDolar { get; set; }

        [DataMember]
        public Decimal TotalDolar { get; set; }

    }   
}