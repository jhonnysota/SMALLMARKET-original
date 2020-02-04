using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public partial class Provisiones_PorCCostoE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idProvision { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

        [DataMember]
        public Int32? idArticulo { get; set; }

        [DataMember]
        public Int32? idConcepto { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
		public String numVerPlanCuentas { get; set; }

		[DataMember]
		public String codCuenta { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal tipCambio { get; set; }

		[DataMember]
		public Boolean indCambio { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal PrecioUnitario { get; set; }

        [DataMember]
        public Boolean indIgv { get; set; }

        [DataMember]
        public Decimal Igv { get; set; }

        [DataMember]
        public Decimal porIgv { get; set; }

        [DataMember]
        public Decimal subTotal { get; set; }

        [DataMember]
		public Decimal impSoles { get; set; }

		[DataMember]
		public Decimal impDolares { get; set; }

		[DataMember]
		public Decimal MontoCuenta { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String desGlosa { get; set; }

		[DataMember]
		public Int32 codColumnaCoven { get; set; }

        [DataMember]
        public String Tipo { get; set; } //G=Gasto S=Servicio A=Articulo C=Activo V=Varios N=Anticipo P=Aplicacion de Anticipo

        [DataMember]
        public String Calculo { get; set; } //A=Automático M=Manual

        [DataMember]
        public Boolean PorRecibir { get; set; }

        [DataMember]
        public Int32? idProvisionRecibida { get; set; }

        [DataMember]
        public Boolean indCostoArticulo { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public String notasdeIngreso { get; set; }

        [DataMember]
        public Boolean EsActivoFijo { get; set; }

        [DataMember]
        public Int32? idActivoFijo { get; set; }

        [DataMember]
        public Boolean FlagHC { get; set; }

        [DataMember]
        public Int32? idCtaCteAnticipo { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Adicionales
        [DataMember]
        public String DesCuenta { get; set; }

        [DataMember]
        public String DesCCosto { get; set; }

        [DataMember]
        public String DesColumnaCoven { get; set; }

        [DataMember]
        public int Opcion { get; set; }

        [DataMember]
        public String Codigo { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        [DataMember]
        public String Eliminar { get; set; } //Botón

        [DataMember]
        public String Modificar { get; set; } //Botón

        [DataMember]
        public String indCCostos { get; set; }

        [DataMember]
        public Decimal CantidadTmp { get; set; }

    }
}