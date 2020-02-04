using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.CtasPorCobrar
{
    [DataContract]
    [Serializable]
    public partial class CobranzasItemE
    {

        public CobranzasItemE()
        {
            oListaCobranzasItemDet = new List<CobranzasItemDetE>();
        }

        [DataMember]
        public Int32 Recibo { get; set; }

        [DataMember]
		public Int32 idPlanilla { get; set; }

		[DataMember]
		public DateTime Fecha { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Monto { get; set; }

		[DataMember]
		public String TipoCobro { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public Decimal tipCambioReci { get; set; }

		[DataMember]
		public DateTime? fecVencimiento { get; set; }

		[DataMember]
		public DateTime? fecCobranza { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String numSerie { get; set; }

		[DataMember]
		public String numCheque { get; set; }

		[DataMember]
		public Decimal Comision { get; set; }

		[DataMember]
		public Decimal Interes { get; set; }

		[DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String codCuentaProvision { get; set; }

		[DataMember]
		public Int32? idConceptoGasto { get; set; }

		[DataMember]
		public Int32? idConceptoInteres { get; set; }

		[DataMember]
		public Int32? idBanco { get; set; }

		[DataMember]
		public Boolean indPresupuesto { get; set; }

		[DataMember]
		public String tipPartidaPresu { get; set; }

		[DataMember]
		public String idPartidaPresu { get; set; }

		[DataMember]
		public Boolean cheDifCancelando { get; set; }

        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
        public Boolean indConciliado { get; set; }

        [DataMember]
        public String Estado { get; set; } //C=Creado A=Anulado

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
        public List<CobranzasItemDetE> oListaCobranzasItemDet { get; set; }

        [DataMember]
        public List<CobranzasItemDetE> oListaDetalleEliminado { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desBanco { get; set; }

        [DataMember]
        public String RucBanco { get; set; }

        [DataMember]
        public String desCtaDetino { get; set; }

        [DataMember]
        public String desCtaProvision { get; set; }

        [DataMember]
        public String desCtaGastos { get; set; }

        [DataMember]
        public String desCtaInteres { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String desAuxiliar { get; set; }

        [DataMember]
        public String RucAuxiliar { get; set; }

        [DataMember]
        public String desTipoCobranza { get; set; }

        [DataMember]
        public String desLocal { get; set; }

        [DataMember]
        public Int32? numItemConci { get; set; } //Para la conciliación

        [DataMember]
        public String RazonSocialEmpresa { get; set; }

        [DataMember]
        public String CuentaBancaria { get; set; }

        [DataMember]
        public String codPlanilla { get; set; }

        [DataMember]
        public String Operacion { get; set; }

        [DataMember]
        public DateTime? FechaConciliacion { get; set; }

        [DataMember]
        public Decimal MontoConciliacion { get; set; }

        [DataMember]
        public Int32 numRegistros { get; set; }

        [DataMember]
        public Int32 numClientes { get; set; }

        [DataMember]
        public String tipDocumento { get; set; }

        [DataMember]
        public String Documento { get; set; }

        [DataMember]
        public String Referencia { get; set; }

        [DataMember]
        public Decimal Saldo { get; set; }

        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String CondicionPago { get; set; }

        [DataMember]
        public String GlosaBanco { get; set; }

        [DataMember]
        public Int32 Orden { get; set; }

    }   
}