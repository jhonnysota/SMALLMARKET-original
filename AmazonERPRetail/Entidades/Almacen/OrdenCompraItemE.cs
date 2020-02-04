using Entidades.Maestros;
using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OrdenCompraItemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idOrdenCompra { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public String numItem { get; set; }

		[DataMember]
		public Int32 idArticuloServ { get; set; }

		[DataMember]
		public String Lote { get; set; }

		[DataMember]
		public DateTime? FechaEntrega { get; set; }

		[DataMember]
		public Decimal CanOrdenada { get; set; }

		[DataMember]
		public Decimal CanIngresada { get; set; }

        [DataMember]
        public Decimal canProvisionada { get; set; }

        [DataMember]
		public Decimal impPrecioUnitario { get; set; }

        [DataMember]
        public Decimal impVentaItem { get; set; }

		[DataMember]
		public Decimal porDescuento { get; set; }

        [DataMember]
        public Decimal impDscto { get; set; }

        [DataMember]
		public Decimal porIsc { get; set; }

		[DataMember]
		public Decimal impIsc { get; set; }

        [DataMember]
        public Boolean indIgv { get; set; }

        [DataMember]
		public Decimal porIgv { get; set; }

		[DataMember]
		public Decimal impIgv { get; set; }

		[DataMember]
		public Decimal impTotalItem { get; set; }

		[DataMember]
		public String desLarga { get; set; }

		[DataMember]
		public Int32? idUMedidaCompra { get; set; }

		[DataMember]
		public String desArticulo { get; set; }

		[DataMember]
		public String PartidaArancelaria { get; set; }

		[DataMember]
		public DateTime? FechaRecepcionFinal { get; set; }

		[DataMember]
		public String tipEstadoAtencion { get; set; } //PN=Pendiente AP=Atención Parcial AT=Atendido Total

        [DataMember]
        public String tipEstadoProvision { get; set; } //PN=Pendiente AP=Atención Parcial AT=Atendido Total

        [DataMember]
        public Boolean indPasoProv { get; set; } //

        [DataMember]
		public Decimal? impPrecioUltimaCompra { get; set; }

		[DataMember]
		public String numItemRequerimiento { get; set; }

		[DataMember]
		public String nroParteProduccion { get; set; }

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
        public ArticuloServE ArticuloServ { get; set; }

        [DataMember]
        public string codArticulo { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String Nemo { get; set; }

        [DataMember]
        public String codCategoria { get; set; }

        [DataMember]
        public String codCategoriaAsoc { get; set; }

        [DataMember]
        public Decimal Flete { get; set; }

        [DataMember]
        public Decimal Seguro { get; set; }

        [DataMember]
        public Decimal OtrosCargos { get; set; }

        [DataMember]
        public Decimal CostoTotal { get; set; }

        [DataMember]
        public Decimal PrecioCosto { get; set; }

        [DataMember]
        public Boolean CalculoCosto { get; set; }

        [DataMember]
        public String indCCostos { get; set; }

        [DataMember]
        public String nomUMedida { get; set; }

        [DataMember]
        public String nomUMedidaPres { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public Decimal PesoAlmacen { get; set; }

    }   
}