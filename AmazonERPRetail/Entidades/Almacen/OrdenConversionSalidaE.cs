using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OrdenConversionSalidaE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idOrdenConversion { get; set; }

		[DataMember]
		public Int32 item { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public String Lote { get; set; }

		[DataMember]
		public Decimal? Stock { get; set; }

		[DataMember]
		public Decimal CantSolicitada { get; set; }

		[DataMember]
		public Decimal PesoUnitario { get; set; }

		[DataMember]
		public Decimal TotalPeso { get; set; }

		[DataMember]
		public Decimal ImpCostoUnitarioBase { get; set; }

		[DataMember]
		public Decimal ImpCostoUnitarioRefe { get; set; }

		[DataMember]
		public Decimal ImpTotalBase { get; set; }

		[DataMember]
		public Decimal ImpTotalRefe { get; set; }

        [DataMember]
        public Int32? tipMovimiento { get; set; }

        [DataMember]
        public Int32? idDocumentoAlmacen { get; set; }

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
        public String NombreArt { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String LoteAlmacen { get; set; }

        [DataMember]
        public String nomAlmacen { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public String nomUMedidaPres { get; set; }

        [DataMember]
        public Decimal CostoUnitario { get; set; }

        [DataMember]
        public Decimal TotalCosto { get; set; }

        [DataMember]
        public Decimal contenido { get; set; }

        [DataMember]
        public Decimal cantidad { get; set; }

        [DataMember]
        public String desTipMovimiento { get; set; }

    }   
}