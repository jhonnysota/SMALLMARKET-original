using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class kardexE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 tipMovimiento { get; set; }

		[DataMember]
		public Int32 idDocumentoAlmacen { get; set; }

		[DataMember]
		public Int32 idItem { get; set; }

		[DataMember]
		public String Num_Item { get; set; }

		[DataMember]
		public Int32? idAlmacen { get; set; }

		[DataMember]
		public Int32? tipAlmacen { get; set; }

		[DataMember]
		public Int32? idOperacion { get; set; }

		[DataMember]
		public DateTime? fecProceso { get; set; }

		[DataMember]
		public String idMoneda { get; set; }

		[DataMember]
		public Int32? idPersona { get; set; }

		[DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public String serDocumento { get; set; }

		[DataMember]
		public String numDocumento { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
		public Int32 idArticulo { get; set; }

		[DataMember]
		public String Lote { get; set; }

		[DataMember]
		public Int32? idUbicacion { get; set; }

		[DataMember]
		public String Cantidad { get; set; }

		[DataMember]
		public String ImpCostoUnitarioBase { get; set; }

		[DataMember]
		public String ImpCostoUnitarioRefe { get; set; }

		[DataMember]
		public String ImpTotalBase { get; set; }

		[DataMember]
		public String ImpTotalRefe { get; set; }

		[DataMember]
		public Boolean indCalidad { get; set; }

		[DataMember]
		public Boolean indConformidad { get; set; }

		[DataMember]
		public String idCCostos { get; set; }

		[DataMember]
		public String idCCostosUso { get; set; }

		[DataMember]
		public Int32? idArticuloUso { get; set; }

		[DataMember]
		public String nroEnvases { get; set; }

		[DataMember]
		public Boolean Valorizado { get; set; }

		[DataMember]
		public String nroParteProd { get; set; }

		[DataMember]
		public Int32? idItemCompra { get; set; }

		[DataMember]
		public String UsuarioRegistro { get; set; }

		[DataMember]
		public DateTime? FechaRegistro { get; set; }

		[DataMember]
		public String UsuarioModificacion { get; set; }

		[DataMember]
		public DateTime? FechaModificacion { get; set; }

		[DataMember]
		public String UsuarioAnula { get; set; }

		[DataMember]
		public DateTime? FechaAnula { get; set; }

        //Extensiones
        [DataMember]
        public DateTime Inicio { get; set; }

        [DataMember]
        public DateTime Fin { get; set; }

        [DataMember]
        public String DesArticulo { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        [DataMember]
        public String NombreOrigen { get; set; }

        [DataMember]
        public String NombreProcedencia { get; set; }

        [DataMember]
        public String Persona { get; set; }

        [DataMember]
        public String Batch { get; set; }

        [DataMember]
        public Decimal PorcentajeGerminacion { get; set; }

        [DataMember]
        public DateTime fecPrueba { get; set; }

        [DataMember]
        public Decimal PesoUnitario { get; set; }

        [DataMember]
        public String desAlmacen { get; set; }

        [DataMember]
        public String codCuentaDestino { get; set; }

        [DataMember]
        public String desCtaDestino { get; set; }

        [DataMember]
        public Decimal TotalSoles { get; set; }

        [DataMember]
        public Decimal TotalDolar { get; set; }

        [DataMember]
        public Int32 Orden { get; set; }

        [DataMember]
        public String desMovimiento { get; set; }     

        [DataMember]
        public String codSunatOpe { get; set; }

        [DataMember]
        public String desOperacion { get; set; }

        [DataMember]
        public String AlmacenOrigen { get; set; }

        [DataMember]
        public String NumItemOrg { get; set; }

        [DataMember]
        public Decimal ImpCostoPromUnitarioBaseOrg { get; set; }

        [DataMember]
        public Decimal Total { get; set; }

        [DataMember]
        public String AlmacenDestino { get; set; }

        [DataMember]
        public String NumItemDst { get; set; }

        [DataMember]
        public Decimal ImpCostoPromUnitarioBaseDst { get; set; }

        [DataMember]
        public Decimal TotalIngreso { get; set; }

        [DataMember]
        public Decimal Diferencia { get; set; }

        [DataMember]
        public String LoteOrg { get; set; }

        [DataMember]
        public String CantidadOrg { get; set; }

        [DataMember]
        public String LoteDst { get; set; }

        [DataMember]
        public String CantidadDst { get; set; }

        [DataMember]
        public String numDocMovAlmacen { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public Decimal KardexSoles { get; set; }

        [DataMember]
        public Decimal StockSoles { get; set; }

    }   
}