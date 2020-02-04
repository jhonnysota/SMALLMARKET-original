using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CartaProductoDetE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }
            
        [DataMember]		public Int32 idCarta { get; set; }
		[DataMember]		public Int32 idArticulo { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public String codCategoria { get; set; }
		[DataMember]		public String idMoneda { get; set; }
		[DataMember]		public Decimal ValorVenta { get; set; }
		[DataMember]		public String TipoIsc { get; set; }
		[DataMember]		public Decimal PorIsc { get; set; }
		[DataMember]		public Decimal isc { get; set; }
		[DataMember]		public Decimal PorIgv { get; set; }
		[DataMember]		public Decimal Igv { get; set; }
		[DataMember]		public Decimal dl25830 { get; set; }
		[DataMember]		public Decimal PrecioVenta { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? fechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? fechaModificacion { get; set; }
	   
        //Extensiones

        [DataMember]
        public String DesArticulo { get; set; }

        [DataMember]
        public String DesTipoArticulo { get; set; }

        [DataMember]
        public String desCategoria { get; set; }

    }   
}