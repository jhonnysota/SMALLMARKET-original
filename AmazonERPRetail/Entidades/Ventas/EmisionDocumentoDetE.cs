using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class EmisionDocumentoDetE
    {
        public EmisionDocumentoDetE()
        {
            nroOt = 0;
            nroOtItem = 0;
            PesoBrutoCad = String.Empty;
        }

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public DateTime fecEmision { get; set; }

        [DataMember]
        public String razonSocial { get; set; }

        [DataMember]
        public Int32? idAlmacen { get; set; }

        [DataMember]
        public Int32? idArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Int32? CantidadUnit { get; set; }

        [DataMember]
        public Decimal? CantidadFinal { get; set; }

        [DataMember]
        public Decimal PrecioConImpuesto { get; set; }

        [DataMember]
        public Decimal PrecioSinImpuesto { get; set; }

        [DataMember]
        public Decimal Dscto1 { get; set; }

        [DataMember]
        public Decimal Dscto2 { get; set; }

        [DataMember]
        public Decimal Dscto3 { get; set; }

        [DataMember]
        public Decimal? Comision { get; set; }

        [DataMember]
        public Decimal porDscto1 { get; set; }

        [DataMember]
        public Decimal porDscto2 { get; set; }

        [DataMember]
        public Decimal porDscto3 { get; set; }

        [DataMember]
        public Decimal? porComision { get; set; }

        [DataMember]
        public Decimal? CantidadAtendida { get; set; }

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
        public Int32? idUnidadMedida { get; set; }

        [DataMember]
        public String numOrdenProd { get; set; }

        [DataMember]
        public String TipoImpSelectivo { get; set; }

        [DataMember]
        public Decimal Stock { get; set; }

        [DataMember]
        public String TipoLista { get; set; }

        [DataMember]
        public String codLineaVenta { get; set; }

        [DataMember]
        public Decimal? Contiene { get; set; }

        [DataMember]
        public Decimal? Capacidad { get; set; }

        [DataMember]
        public Decimal? PesoUnitario { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public DateTime? fecDocumentoRef { get; set; }

        [DataMember]
        public Decimal? TotalRef { get; set; }

        [DataMember]
        public Int32? idCampana { get; set; }

        [DataMember]
        public Boolean indPercepcion { get; set; }

        [DataMember]
        public Decimal? MontoAfectoPerce { get; set; }

        [DataMember]
        public Decimal? MontoPercepcion { get; set; }

        [DataMember]
        public Int32? idListaPrecio { get; set; }

        [DataMember]
        public Int32? nroOt { get; set; }

        [DataMember]
        public Int32? nroOtItem { get; set; }

        [DataMember]
        public String PesoBrutoCad { get; set; }

        [DataMember]
        public bool indCalculo { get; set; }

        [DataMember]
        public Int32 DocumentoAlmacen { get; set; }

        [DataMember]
        public String tipArticulo { get; set; }

        [DataMember]
        public Boolean indDetraccion { get; set; }

        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Decimal TasaDetraccion { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Otros Campos
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public Decimal PesoNeto { get; set; }

        [DataMember]
        public Decimal PesoBruto { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String codBarra { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public String CantidadCad { get; set; }

        [DataMember]
        public String PrecioCad { get; set; }

        [DataMember]
        public String PrecioIncCad { get; set; }

        [DataMember]
        public String SubTotalCad { get; set; }

        [DataMember]
        public String porDcto1Cad { get; set; }

        [DataMember]
        public String TotalCad { get; set; }

        [DataMember]
        public String desUMedida { get; set; }

        [DataMember]
        public String desUMedidaCorta { get; set; }

        [DataMember]
        public Decimal CantFactura { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        [DataMember]
        public String desNomArtCompuesto { get; set; }

    }

    [DataContract]
    [Serializable]
    public class EmisionDocumentoDetDetalleE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public DateTime fecEmision { get; set; }

        [DataMember]
        public String razonSocial { get; set; }

        [DataMember]
        public Int32? idAlmacen { get; set; }

        [DataMember]
        public Int32? idArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Int32 CantidadUnit { get; set; }

        [DataMember]
        public Decimal CantidadFinal { get; set; }

        [DataMember]
        public Decimal PrecioConImpuesto { get; set; }

        [DataMember]
        public Decimal PrecioSinImpuesto { get; set; }

        [DataMember]
        public Decimal Dscto1 { get; set; }

        [DataMember]
        public Decimal Dscto2 { get; set; }

        [DataMember]
        public Decimal Dscto3 { get; set; }

        [DataMember]
        public Decimal? Comision { get; set; }

        [DataMember]
        public Decimal porDscto1 { get; set; }

        [DataMember]
        public Decimal porDscto2 { get; set; }

        [DataMember]
        public Decimal porDscto3 { get; set; }

        [DataMember]
        public Decimal? porComision { get; set; }

        [DataMember]
        public Decimal? CantidadAtendida { get; set; }

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
        public Int32? idTipoMedida { get; set; }

        [DataMember]
        public Int32? idUnidadMedida { get; set; }

        [DataMember]
        public String numOrdenProd { get; set; }

        [DataMember]
        public String TipoImpSelectivo { get; set; }

        [DataMember]
        public Decimal Stock { get; set; }

        [DataMember]
        public String TipoLista { get; set; }

        [DataMember]
        public String codLineaVenta { get; set; }

        [DataMember]
        public Decimal? Contiene { get; set; }

        [DataMember]
        public Decimal? Capacidad { get; set; }

        [DataMember]
        public Decimal? PesoUnitario { get; set; }

        [DataMember]
        public String idDocumentoRef { get; set; }

        [DataMember]
        public String serDocumentoRef { get; set; }

        [DataMember]
        public String numDocumentoRef { get; set; }

        [DataMember]
        public DateTime? fecDocumentoRef { get; set; }

        [DataMember]
        public Decimal? TotalRef { get; set; }

        [DataMember]
        public Int32? idCampana { get; set; }

        [DataMember]
        public Boolean indPercepcion { get; set; }

        [DataMember]
        public Decimal? MontoAfectoPerce { get; set; }

        [DataMember]
        public Decimal? MontoPercepcion { get; set; }

        [DataMember]
        public Int32? idListaPrecio { get; set; }

        [DataMember]
        public Int32? nroOt { get; set; }

        [DataMember]
        public Int32? nroOtItem { get; set; }

        [DataMember]
        public String PesoBrutoCad { get; set; }

        [DataMember]
        public bool indCalculo { get; set; }

        [DataMember]
        public Int32 DocumentoAlmacen { get; set; }

        [DataMember]
        public String tipArticulo { get; set; }

        [DataMember]
        public Boolean indDetraccion { get; set; }

        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Decimal TasaDetraccion { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        //Otros Campos
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public Decimal PesoNeto { get; set; }

        [DataMember]
        public Decimal PesoBruto { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String codBarra { get; set; }

        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public String CantidadCad { get; set; }

        [DataMember]
        public String PrecioCad { get; set; }

        [DataMember]
        public String PrecioIncCad { get; set; }

        [DataMember]
        public String SubTotalCad { get; set; }

        [DataMember]
        public String porDcto1Cad { get; set; }

        [DataMember]
        public String TotalCad { get; set; }

        [DataMember]
        public String desUMedida { get; set; }

        [DataMember]
        public Decimal CantFactura { get; set; }

        [DataMember]
        public String LoteProveedor { get; set; }

        [DataMember]
        public String desNomArtCompuesto { get; set; }

        [DataMember]
        public int codUniMedAlmacen { get; set; }

    }
}