using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class OrdenTrabajoServicioItemE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idOT { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public String Item { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String Descripcion { get; set; }

		[DataMember]
		public DateTime? FechaEntrega { get; set; }

		[DataMember]
		public Int32 idTipoArticuloProducto { get; set; }

		[DataMember]
		public Int32 idArticuloProducto { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

		[DataMember]
		public Decimal PrecioUnitario { get; set; }

		[DataMember]
		public Decimal ValorVenta { get; set; }

        [DataMember]
        public Boolean flgIgv { get; set; }

        [DataMember]
        public Decimal porIgv { get; set; }

        [DataMember]
		public Decimal Igv { get; set; }

		[DataMember]
		public Decimal Total { get; set; }

		[DataMember]
		public String Estado { get; set; }

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
        public Int32 Opcion { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String desArticulo { get; set; }

        [DataMember]
        public String desCostos { get; set; }

        [DataMember]
        public String codArticulo2 { get; set; }

        [DataMember]
        public String desArticulo2 { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public String desArea { get; set; }

        [DataMember]
        public String numeroOT { get; set; }

        [DataMember]
        public DateTime? FechaEmision { get; set; }

        [DataMember]
        public String desCCostos { get; set; }

        [DataMember]
        public String ruc { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Decimal igv { get; set; }

        [DataMember]
        public String SolicitudFactura { get; set; }

        [DataMember]
        public String Factura { get; set; }

        [DataMember]
        public String Cotizacion { get; set; }




    }   
}