using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class ListaPrecioItemE
    {

        public ListaPrecioItemE()
        {
            Opcion = 0;
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }
		[DataMember]
		public Int32 idListaPrecio { get; set; }
		[DataMember]
		public Int32 item { get; set; }
		[DataMember]
		public Int32 idTipoArticulo { get; set; }
		[DataMember]
		public Int32 idArticulo { get; set; }
		[DataMember]
		public Decimal PrecioBruto { get; set; }
		[DataMember]
		public Decimal PorDscto1 { get; set; }
        [DataMember]
		public Decimal PorDscto2 { get; set; }
		[DataMember]
		public Decimal PorDscto3 { get; set; }
		[DataMember]
		public Decimal MontoDscto1 { get; set; }
		[DataMember]
		public Decimal MontoDscto2 { get; set; }
		[DataMember]
		public Decimal MontoDscto3 { get; set; }
		[DataMember]
		public Decimal PrecioValorVenta { get; set; }
		[DataMember]
		public Boolean flgisc { get; set; }
		[DataMember]
		public String TipoImpSelectivo { get; set; }
		[DataMember]
		public Decimal porisc { get; set; }
		[DataMember]
		public Decimal isc { get; set; }
		[DataMember]
		public Boolean flgigv { get; set; }
		[DataMember]
		public Decimal porigv { get; set; }
		[DataMember]
		public Decimal igv { get; set; }
		[DataMember]
		public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal Capacidad { get; set; }
        [DataMember]
        public Decimal Contenido { get; set; }
        [DataMember]
        public Decimal PrecioVentaConte { get; set; }
        [DataMember]
        public Decimal PrecioBrutoConte { get; set; }
        [DataMember]
        public int IdUMedida { get; set; }
        [DataMember]
        public int IdUMedidaD { get; set; }
        [DataMember]
        public decimal PrecioD { get; set; }
        [DataMember]
        public decimal PorDsctoD { get; set; }
        [DataMember]
        public decimal MontoDsctoD { get; set; }
        [DataMember]
        public decimal PrecioValorVentaD { get; set; }
        [DataMember]
        public bool FlgIgvD { get; set; }
        [DataMember]
        public decimal PorIgvD { get; set; }
        [DataMember]
        public decimal IgvD { get; set; }
        [DataMember]
        public decimal PrecioVentaD { get; set; }
        [DataMember]
        public Boolean Estado { get; set; }
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
        public String desTipoArticulo { get; set; }
        [DataMember]
        public String desArticulo { get; set; }
        [DataMember]
        public String desTipoImpSelectivo { get; set; }
        [DataMember]
        public String nomUMedida { get; set; }
        [DataMember]
        public String nomUMedidaEnv { get; set; }
        [DataMember]
        public Decimal ContenidoPres { get; set; }
        [DataMember]
        public String nomUMedidaPres { get; set; }
        [DataMember]
        public String nomTipoUMedida { get; set; }
        [DataMember]
        public String nomTipoUMedidaEnv { get; set; }

    }   
}