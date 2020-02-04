using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class LiquidacionImportacionDetE
    {
            
        [DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public Int32 idLiquidacion { get; set; }

		[DataMember]
		public Int32? idProvision { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime FechaDocumento { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal MontoDoc { get; set; }

		[DataMember]
		public String idMonedaRec { get; set; }

		[DataMember]
		public Decimal MontoRec { get; set; }

		[DataMember]
		public Boolean indTicaAuto { get; set; }

		[DataMember]
		public Decimal TipoCambio { get; set; }

		[DataMember]
		public Decimal SolesRec { get; set; }

		[DataMember]
		public Decimal DolaresRec { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String indReparable { get; set; }

		[DataMember]
		public Int32? idConceptoRep { get; set; }

		[DataMember]
		public String desReferenciaRep { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

        [DataMember]
        public Int32? idConcepto { get; set; }

        [DataMember]
		public Boolean EsAutomatico { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime FechaModificacion { get; set; }
        
        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desMonedaRec { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String codConcepto { get; set; }

        [DataMember]
        public String desConcepto { get; set; }

    }   
}