using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OrdenConversionDetalleE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idOrdenConversion { get; set; }

		[DataMember]
		public Int32 item { get; set; }

		[DataMember]
		public DateTime? Fecha { get; set; }

		[DataMember]
		public Int32 idTipoArticulo { get; set; }

		[DataMember]
		public Int32 idAlmacen { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public String Lote { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal Equivalente { get; set; }

		[DataMember]
		public Boolean indGenerada { get; set; }

		[DataMember]
		public Int32? tipMovimiento { get; set; }

		[DataMember]
		public Int32? idDocumentoAlmacen { get; set; }

        [DataMember]
        public decimal PesoUnitario { get; set; }

        [DataMember]
        public Decimal TotalPeso { get; set; }

        [DataMember]
        public Decimal CostoUnitario { get; set; }

        [DataMember]
        public Decimal TotalCosto { get; set; }

        [DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

        //Extension
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String NombreArt { get; set; }

        [DataMember]
        public String nomAlmacen { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public String nomUMedidaPres { get; set; }

        [DataMember]
        public Decimal contenido { get; set; }

        [DataMember]
        public string nomTipoMov { get; set; }

        [DataMember]
        public string LoteAlmacen { get; set; }

        [DataMember]
        public String Persona { get; set; }

    }   
}