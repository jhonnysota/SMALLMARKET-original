using System;
using System.Runtime.Serialization;
using Entidades.Maestros;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class PedidoDetE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

		[DataMember]
		public Int32 idPedido { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public Int32 idArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

		[DataMember]
		public Int32 idTipoPrecio { get; set; }

		[DataMember]
		public Decimal Cantidad { get; set; }

		[DataMember]
        public Decimal PrecioUnitario { get; set; }

        [DataMember]
        public Decimal PrecioConImpuesto { get; set; }
        
        [DataMember]
        public Decimal Dscto1 { get; set; }
        
        [DataMember]
        public Decimal Dscto2 { get; set; }
        
        [DataMember]
        public Decimal Dscto3 { get; set; }
        
        [DataMember]
        public Decimal porDscto1 { get; set; }

        [DataMember]
		public Decimal porDscto2 { get; set; }
        
        [DataMember]
        public Decimal porDscto3 { get; set; }
        
        [DataMember]
        public Boolean flgIgv { get; set; }
        
        [DataMember]
        public Decimal Isc { get; set; }
        
        [DataMember]
        public Decimal Igv { get; set; }
        
        [DataMember]
        public Decimal subTotal { get; set; }
        
        [DataMember]
        public Decimal Total { get; set; }
        
        [DataMember]
        public Decimal porIsc { get; set; }
        
        [DataMember]
        public Decimal porIgv { get; set; }

        [DataMember]
        public Int32? idMarca { get; set; }

        [DataMember]
        public Int32? idUMedida { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public Decimal Stock { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public String nroOt { get; set; }

        [DataMember]
        public bool indCalculo { get; set; }

        [DataMember]
        public String TipoImpSelectivo { get; set; }

        [DataMember]
        public Decimal Capacidad { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public Boolean indDetraccion { get; set; }

        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Decimal TasaDetraccion { get; set; }

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
        public ArticuloServE oArticulo { get; set; }
        [DataMember]
        public String desArticulo { get; set; }
        [DataMember]
        public Int32 Opcion { get; set; }
        [DataMember]
        public String codArticulo { get; set; }
        [DataMember]
        public String desUnidadMed { get; set; }
        [DataMember]
        public int codTipoMedAlmacen { get; set; }
        [DataMember]
        public int codUniMedAlmacen { get; set; }
        [DataMember]
        public String desUniAlmacen { get; set; }
        [DataMember]
        public int idTipoMedEnvase { get; set; }
        [DataMember]
        public int idUniMedEnvase { get; set; }
        [DataMember]
        public String desUniEnvase { get; set; }
        [DataMember]
        public String LoteProveedor { get; set; }
        [DataMember]
        public String desArticuloCompuesto { get; set; }
        [DataMember]
        public String LoteAlmacen { get; set; }
        [DataMember]
        public String SiglaEmpresa { get; set; }
        [DataMember]
        public Decimal PesoUnitario { get; set; }
        [DataMember]
        public String CodBarras { get; set; }
        [DataMember]
        public string DesAlmacen { get; set; }
        [DataMember]
        public Decimal PrecioUnitarioTmp { get; set; }
        [DataMember]
        public Decimal DsctoTmp { get; set; }
        [DataMember]
        public Decimal PrecioConDscto { get; set; }
        [DataMember]
        public decimal StockDetalle { get; set; }

    }
}