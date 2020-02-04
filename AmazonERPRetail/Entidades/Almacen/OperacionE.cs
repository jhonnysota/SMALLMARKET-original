using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class OperacionE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

        [DataMember]
		public Int32 idOperacion { get; set; }

		[DataMember]
		public Int32 tipAlmacen { get; set; }

		[DataMember]
        public Int32 tipMovimiento { get; set; }

		[DataMember]
		public String desOperacion { get; set; }

		[DataMember]
		public String desDetalle { get; set; }

		[DataMember]
		public Boolean indValorizar { get; set; }

		[DataMember]
		public Boolean indServicio { get; set; }

		[DataMember]
		public Boolean automatico { get; set; }

		[DataMember]
		public String codSunat { get; set; }

		[DataMember]
		public Boolean indOrdentrabajo { get; set; }

		[DataMember]
		public Boolean indTransferencia { get; set; }

		[DataMember]
		public Boolean indConsumo { get; set; }

		[DataMember]
		public Boolean indDocumentoAutomatico { get; set; }

		[DataMember]
		public Boolean indProveedor { get; set; }

		[DataMember]
		public Boolean indCliente { get; set; }

		[DataMember]
		public Boolean indEstadistico { get; set; }

		[DataMember]
		public Boolean indOrdenCompra { get; set; }

        [DataMember]
        public Boolean indConversion { get; set; }

        [DataMember]
        public Boolean indDevolucion { get; set; }

        [DataMember]
        public Boolean indCostoVenta { get; set; }        

        [DataMember]
        public Boolean indDocumento { get; set; }

        [DataMember]
        public Boolean indReferencia { get; set; }

        [DataMember]
		public String orden { get; set; }

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
        public String desAlmacen { get; set; }

        [DataMember]
        public String desMovimiento { get; set; }

        [DataMember]
        public String TipoAlmacen { get; set; }

        [DataMember]
        public String nomSunat { get; set; }

        [DataMember]
        public Int32 ContaReg { get; set; }

        [DataMember]
        public String NombreEmpresa { get; set; }

        [DataMember]
        public String desTipAlmacen { get; set; }

        [DataMember]
        public String desTipMovimiento { get; set; }

        [DataMember]
        public String desTemporal { get; set; }

    }   
}