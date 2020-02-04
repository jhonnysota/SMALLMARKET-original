using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public class MovimientoAlmacenE
    {

        public MovimientoAlmacenE()
        {
            ListaAlmacenItem = new List<MovimientoAlmacenItemE>();
        }

        [DataMember]
		public Int32 idEmpresa { get; set; }
		[DataMember]
		public Int32 tipMovimiento { get; set; }
		[DataMember]
		public Int32 idDocumentoAlmacen { get; set; }
		[DataMember]
		public Int32 idAlmacen { get; set; }
		[DataMember]
		public Int32 tipAlmacen { get; set; }
		[DataMember]
        public Int32 idOperacion { get; set; }
		[DataMember]
        public string fecProceso { get; set; }
        [DataMember]
        public bool indFactura { get; set; }
		[DataMember]
		public String idDocumento { get; set; }
		[DataMember]
		public String serDocumento { get; set; }
        [DataMember]
        public String numDocumento { get; set; }
        [DataMember]
        public string fecDocumento { get; set; }
        [DataMember]
        public bool indDocDevolucion { get; set; }
        [DataMember]
        public String idDocumentoDevolucion { get; set; }
        [DataMember]
        public String serDocumentoDevolucion { get; set; }
        [DataMember]
        public String numDocumentoDevolucion { get; set; }
        [DataMember]
        public Int32? idOrdenCompra { get; set; }
        [DataMember]
        public String numRequisicion { get; set; }
		[DataMember]
		public String idDocumentoRef { get; set; }
		[DataMember]
		public String SerieDocumentoRef { get; set; }
		[DataMember]
		public String NumeroDocumentoRef { get; set; }
		[DataMember]
		public Int32? idPersona { get; set; }
		[DataMember]
		public String idMoneda { get; set; }
		[DataMember]
		public Boolean indCambio { get; set; }
		[DataMember]
		public Decimal tipCambio { get; set; }
		[DataMember]
		public Decimal impValorVenta { get; set; }
        [DataMember]
        public bool indImpuesto { get; set; }
        [DataMember]
        public decimal porIgv { get; set; }
        [DataMember]
		public Decimal Impuesto { get; set; }
		[DataMember]
		public Decimal impTotal { get; set; }
        [DataMember]
        public Boolean indPorAsociar { get; set; }
		[DataMember]
		public Int32? idAlmacenOrigen { get; set; }
        [DataMember]
        public Int32 idAlmacenDestino { get; set; }
        [DataMember]
        public Int32? tipMovimientoAsociado { get; set; }
        [DataMember]
        public Int32? idDocumentoAlmacenAsociado { get; set; }
        [DataMember]
        public String numCorrelativo { get; set; }
        [DataMember]
        public String Glosa { get; set; }
        [DataMember]
        public bool indAutomatico { get; set; }
        [DataMember]
        public String indEstado { get; set; }
        [DataMember]
        public String UsuarioAnula { get; set; }
        [DataMember]
        public DateTime? FechaAnula { get; set; }
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
        public List<MovimientoAlmacenItemE> ListaAlmacenItem { get; set; }
        [DataMember]
        public List<MovimientoAlmacenItemE> ListaAlmacenItemEliminado { get; set; }
        [DataMember]
        public List<MovimientoAlmacenE> ListaMovimientoSalidas { get; set; }
        [DataMember]
        public String desMovimiento { get; set; }
        [DataMember]
        public String desOperacion { get; set; }
        [DataMember]
        public String desAlmacen { get; set; }
        [DataMember]
        public String desMoneda { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String ruc { get; set; }
        [DataMember]
        public String Documento { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String Guia { get; set; }
        [DataMember]
        public String numOrdenCompra { get; set; }
        [DataMember]
        public Decimal Cantidad { get; set; }
        [DataMember]
        public String Correlativo { get; set; }
        [DataMember]
        public Boolean indTransferencia { get; set; }
        [DataMember]
        public String NombreCompleto { get; set; }
        [DataMember]
        public String Lote { get; set; }
        [DataMember]
        public Boolean VerificaLote { get; set; }
        [DataMember]
        public String codCuentaDestino { get; set; }
        [DataMember]
        public String desCtaDestino { get; set; }
        [DataMember]
        public String numItem { get; set; }
        [DataMember]
        public String codArticulo { get; set; }
        [DataMember]
        public String nomArticulo { get; set; }
        [DataMember]
        public Decimal CostoMovS { get; set; }
        [DataMember]
        public Decimal CostoMovD { get; set; }
        [DataMember]
        public Decimal CostoTotalMovS { get; set; }
        [DataMember]
        public Decimal CostoTotalMovD { get; set; }
        [DataMember]
        public Decimal CostoKarS { get; set; }
        [DataMember]
        public Decimal CostoKarD { get; set; }
        [DataMember]
        public Decimal CostoTotalKarS { get; set; }
        [DataMember]
        public Decimal CostoTotalKarD { get; set; }
        [DataMember]
        public String idMonedaPrecio { get; set; }
        [DataMember]
        public String desMonedaPrecio { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Boolean VaEnRojo { get; set; }

    }

    [DataContract]
    [Serializable]
    public class MovimientoAlmacenXLSE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 Linea { get; set; }

        [DataMember]
        public Int32 idUsuario { get; set; }

        [DataMember]
        public Int32 tipMovimiento { get; set; }

        [DataMember]
        public Int32 idAlmacen { get; set; }

        [DataMember]
        public Int32 tipAlmacen { get; set; }

        [DataMember]
        public Int32 idArticulo { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public Int32 idOperacion { get; set; }

        [DataMember]
        public DateTime fecProceso { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String serDocumento { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime? fecDocumento { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String SerieDocumentoRef { get; set; }

        [DataMember]
        public String NumeroDocumentoRef { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal CostoUnitBase { get; set; }

        [DataMember]
        public Decimal CostoUnitRefe { get; set; }

        [DataMember]
        public Decimal CostoTotBase { get; set; }

        [DataMember]
        public Decimal CostoTotRefe { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public String LoteProv { get; set; }

        [DataMember]
        public Int32 idPaisOrigen { get; set; }

        [DataMember]
        public String PaisOrigen { get; set; }

        [DataMember]
        public Int32 idPaisDestino { get; set; }

        [DataMember]
        public String PaisDestino { get; set; }

        [DataMember]
        public String batch { get; set; }

        [DataMember]
        public Decimal Germinacion { get; set; }

        [DataMember]
        public DateTime? FechaPrueba { get; set; }

    }

}