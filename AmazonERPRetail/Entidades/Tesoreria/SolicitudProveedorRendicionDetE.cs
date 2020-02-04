using Entidades.CtasPorPagar;
using System;
using System.Runtime.Serialization;

namespace Entidades.Tesoreria
{
    [DataContract]
    [Serializable]
    public partial class SolicitudProveedorRendicionDetE
    {

        public SolicitudProveedorRendicionDetE()
        {
            indProvBusqueda = false;
        }

        [DataMember]
		public Int32 idRendicion { get; set; }

		[DataMember]
		public Int32 Item { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

		[DataMember]
		public DateTime fecDocumento { get; set; }

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
		public Decimal tipCambio { get; set; }

		[DataMember]
		public Decimal SolesRecibidos { get; set; }

		[DataMember]
		public Decimal DolaresRecibidos { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public Int32? idAuxiliar { get; set; }

		[DataMember]
		public Int32? idConcepto { get; set; }

        [DataMember]
        public String indReparable { get; set; }

        [DataMember]
        public Int32 idConceptoRep { get; set; }

        [DataMember]
        public String desReferenciaRep { get; set; }

        [DataMember]
		public Boolean EsAutomatico { get; set; }

        [DataMember]
        public Int32? idProvision { get; set; }

        [DataMember]
        public Boolean indProvBusqueda { get; set; }

        [DataMember]
        public Boolean indLiquiImpor { get; set; }

        [DataMember]
        public Int32? idLiquiImpor { get; set; }

        [DataMember]
        public Int32? idCtaCteLiqui { get; set; }

        [DataMember]
        public Int32? idCtaCteItemLiqui { get; set; }

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
        public ProvisionesE oProvision { get; set; }

        [DataMember]
        public Int32 OpcionGrabarProv { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String codSolicitud { get; set; }

        [DataMember]
        public DateTime fecOperacion { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String RUC { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desMonedaRec { get; set; }

        [DataMember]
        public String codConcepto { get; set; }

        [DataMember]
        public String desConcepto { get; set; }

        [DataMember]
        public Decimal MontoDepositado { get; set; }

        [DataMember]
        public String ctaBanco { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public Decimal SaldoSol { get; set; }

    }   
}