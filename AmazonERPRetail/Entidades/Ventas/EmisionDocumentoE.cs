using Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class EmisionDocumentoE
    {
        public EmisionDocumentoE()
        {
            nroDocAsociado = 0;
            EnvioFE = false;
            indCancelacion = false;
            indAlmacen = false;
            AfectoRetencion = false;
            AfectoDetraccion = false;
            ListaItemsDocumento = new List<EmisionDocumentoDetE>();
            ListaCanjeGuias = new List<CanjeGuiasE>();
            ListaCancelaciones = new List<EmisionDocumentoCancelacionE>();
            ListaEmisionDocumentoCCostos = new List<EmisionDocumentoCCostosE>();
            ListaItemsDetallado = new List<EmisionDocumentoDetDetalleE>();
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
        public String Anio { get; set; }

        [DataMember]
        public String Mes { get; set; }

        [DataMember]
        public string fecEmision { get; set; }

        [DataMember]
        public string fecVencimiento { get; set; }

        [DataMember]
        public Boolean indRecepcion { get; set; }

        [DataMember]
        public DateTime? fecRecepcion { get; set; }

        [DataMember]
        public Int32? idTipCondicion { get; set; }

        [DataMember]
        public Int32? idCondicion { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal tipCambio { get; set; }

        [DataMember]
        public Decimal? totMontoBruto { get; set; }

        [DataMember]
        public Decimal totsubTotal { get; set; }

        [DataMember]
        public Decimal totDscto1 { get; set; }

        [DataMember]
        public Decimal? totDscto2 { get; set; }

        [DataMember]
        public Decimal? totDscto3 { get; set; }

        [DataMember]
        public Decimal? totIsc { get; set; }

        [DataMember]
        public Decimal? totIgv { get; set; }

        [DataMember]
        public Decimal totTotal { get; set; }

        [DataMember]
        public Decimal Redondeo { get; set; }

        [DataMember]
        public Decimal? porDscto { get; set; }

        [DataMember]
        public Decimal? DsctoGlobal { get; set; }

        [DataMember]
        public String Glosa { get; set; }

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
        public Int32? idTipCondicionRef { get; set; }

        [DataMember]
        public Int32? idCondicionRef { get; set; }

        [DataMember]
        public Decimal? totAfectoPerce { get; set; }

        [DataMember]
        public Decimal? totPercepcion { get; set; }

        [DataMember]
        public String indEstado { get; set; } //C=Creado E=Emitido B=Borrado F=Factura caso guias

        [DataMember]
        public Int32? idPersona { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String numRuc { get; set; }

        [DataMember]
        public Int32? idSucursalCliente { get; set; }

        [DataMember]
        public String Direccion { get; set; }

        [DataMember]
        public Int32? idTipTraslado { get; set; }

        [DataMember]
        public String OtroTipoTraslado { get; set; }

        [DataMember]
        public String TipoAsiento { get; set; }

        [DataMember]
        public Boolean indVoucher { get; set; }

        [DataMember]
        public String AnioPeriodo { get; set; }

        [DataMember]
        public String MesPeriodo { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String numVerPlanCuentas { get; set; }

        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public String EsGuia { get; set; }

        [DataMember]
        public DateTime? fecTraslado { get; set; }

        [DataMember]
        public String EmpresaPartida { get; set; }

        [DataMember]
        public String PuntoPartida { get; set; }

        [DataMember]
        public String PuntoLlegada { get; set; }

        [DataMember]
        public Int32? idAlmacenDestino { get; set; }

        [DataMember]
        public Int32? idEmpresaTransp { get; set; }

        [DataMember]
        public String RazonSocialTransp { get; set; }

        [DataMember]
        public String RucTransp { get; set; }

        [DataMember]
        public String DireccionTransp { get; set; }

        [DataMember]
        public Int32? idConductorTransp { get; set; }

        [DataMember]
        public String ConductorTransp { get; set; }

        [DataMember]
        public String LicenciaTransp { get; set; }

        [DataMember]
        public String desVehiculoTransp { get; set; }

        [DataMember]
        public String PlacaTransp { get; set; }

        [DataMember]
        public String MarcaTransp { get; set; }

        [DataMember]
        public String inscripTransp { get; set; }

        [DataMember]
        public String PlacaRemolqueTransp { get; set; }

        [DataMember]
        public String desExpTotal { get; set; }

        [DataMember]
        public String desExpValorVenta { get; set; }

        [DataMember]
        public Decimal? Flete { get; set; }

        [DataMember]
        public Decimal? PrecCpt { get; set; }

        [DataMember]
        public Decimal? seguro { get; set; }

        [DataMember]
        public Decimal? Embalaje { get; set; }

        [DataMember]
        public Decimal? Gastos { get; set; }

        [DataMember]
        public String idTipTransporte { get; set; }

        [DataMember]
        public String NombrePuerto { get; set; }

        [DataMember]
        public String numPartida { get; set; }

        [DataMember]
        public String numReserva { get; set; }

        [DataMember]
        public String DelNumero { get; set; }

        [DataMember]
        public String AlNumero { get; set; }

        [DataMember]
        public Int32? idVendedor { get; set; }

        [DataMember]
        public Int32? idCanalVenta { get; set; }

        [DataMember]
        public String TipoMercado { get; set; }

        [DataMember]
        public Boolean EnviadoSunat { get; set; }

        [DataMember]
        public DateTime? fecEnvioSunat { get; set; }

        [DataMember]
        public Int32? EstadoRegistro { get; set; }

        [DataMember]
        public String MensajeRegistro { get; set; }

        [DataMember]
        public Int32? idRegistro { get; set; }

        [DataMember]
        public Int32? EstadoSunat { get; set; }

        [DataMember]
        public String MensajeSunat { get; set; }

        [DataMember]
        public Boolean AnuladoSunat { get; set; }

        [DataMember]
        public DateTime? fecAnuladoSunat { get; set; }

        [DataMember]
        public String MensajeSunatAnulacion { get; set; }

        [DataMember]
        public String MotivoAnulacion { get; set; }

        [DataMember]
        public String EstadoBaja { get; set; }

        [DataMember]
        public Int32? nroDocAsociado { get; set; }

        [DataMember]
        public Int32 DocumentoAlmacen { get; set; }

        [DataMember]
        public String Invoice { get; set; }

        [DataMember]
        public String Periodo { get; set; }

        [DataMember]
        public String PO { get; set; }

        [DataMember]
        public Boolean AfectoDetraccion { get; set; }
    
        [DataMember]
        public String tipDetraccion { get; set; }

        [DataMember]
        public Decimal TasaDetraccion { get; set; }

        [DataMember]
        public Decimal MontoDetraccion { get; set; }

        [DataMember]
        public Int32? tipAfectoIgv { get; set; }

        [DataMember]
        public Boolean AfectoRetencion { get; set; }

        [DataMember]
        public Boolean EsAnticipo { get; set; }

        [DataMember]
        public Boolean indAnticipo { get; set; }

        [DataMember]
        public Boolean indCancelacion { get; set; }

        [DataMember]
        public Int32? idEstablecimiento { get; set; }

        [DataMember]
        public Int32? idZona { get; set; }

        [DataMember]
        public Int32? idDivision { get; set; }

        [DataMember]
        public Int32? idCtaCte { get; set; }

        [DataMember]
        public Int32? idCtaCteItem { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        [DataMember]
        public String UsuarioModificacion { get; set; }

        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        ////Extensiones
        // Detalle de la cabecera (Maestro Detalle)
        [DataMember]
        public List<EmisionDocumentoDetE> ListaItemsDocumento { get; set; }

        [DataMember]
        public List<EmisionDocumentoDetDetalleE> ListaItemsDetallado { get; set; }

        // Detalle de Facturas asociadas a guias...
        [DataMember]
        public List<CanjeGuiasE> ListaCanjeGuias { get; set; }

        // Detalle de Gastos para la Exportacón
        [DataMember]
        public List<EmisionDocumentoExportaE> ListaGastosExportacion { get; set; }

        [DataMember]
        public List<EmisionDocumentoCCostosE> ListaEmisionDocumentoCCostos { get; set; }

        // Detalle de los anticipos
        [DataMember]
        public List<AnticiposE> ListaAnticipos { get; set; }

        // Detalle de los anticipos por eliminar
        [DataMember]
        public List<AnticiposE> AnticiposEliminados { get; set; }

        //Detalle de las Cancelaciones
        [DataMember]
        public List<EmisionDocumentoCancelacionE> ListaCancelaciones { get; set; }

        [DataMember]
        public String desMoneda { get; set; }

        // Descripcion del tipo de traslado de la guia... 
        [DataMember]
        public String desTraslado { get; set; }

        // Descripcion de la condicion de venta
        [DataMember]
        public String desCondicion { get; set; }

        // Para agregar la columna checkbox al datagridview
        [DataMember]
        public Boolean Check { get; set; }

        //Para los pedidos
        [DataMember]
        public String desTipoCompra { get; set; }

        [DataMember]
        public String PesoNeto { get; set; }

        [DataMember]
        public String PesoBruto { get; set; }
        
        [DataMember]
        public String UrlPdf { get; set; }

        [DataMember]
        public String desTipAfectoIgv { get; set; }

        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String nomVendedor { get; set; }

        [DataMember]
        public Decimal Saldo { get; set; }

        [DataMember]
        public Boolean TrasladoAlmacen { get; set; }

        [DataMember]
        public Boolean EnvioFE { get; set; }

        [DataMember]
        public String Mov { get; set; }

        [DataMember]
        public String Guia { get; set; }

        [DataMember]
        public String Ruc { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

        [DataMember]
        public String nomArticulo { get; set; }

        [DataMember]
        public String nomUMedida { get; set; }

        [DataMember]
        public Decimal Cantidad { get; set; }

        [DataMember]
        public Decimal Soles { get; set; }

        [DataMember]
        public Decimal Dolares { get; set; }

        [DataMember]
        public DateTime? FechaPago { get; set; }

        [DataMember]
        public String numOperacion { get; set; }

        [DataMember]
        public String nomMes { get; set; }

        [DataMember]
        public String desCondicionRef { get; set; }

        [DataMember]
        public String desEstablecimiento { get; set; }

        [DataMember]
        public String desZonaTrabajo { get; set; }

        [DataMember]
        public String Pedido { get; set; }

        [DataMember]
        public Boolean EsAnticipoTmp { get; set; } //Para saber si el check de anticipo cambia o no

        [DataMember]
        public String desPais { get; set; }

        [DataMember]
        public String desDep { get; set; }

        [DataMember]
        public String desDis { get; set; }

        [DataMember]
        public String desPro { get; set; }

        [DataMember]
        public Int32 nroOt { get; set; }

        [DataMember]
        public Int32 nroOtItem { get; set; }

        #region Datos AutoDetracciones

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public Boolean indDetraArt { get; set; }

        [DataMember]
        public String tipDetraArt { get; set; }

        [DataMember]
        public String desDetraccion { get; set; }

        [DataMember]
        public Decimal porDetraArt { get; set; }

        [DataMember]
        public Decimal BaseDetraccion { get; set; }

        [DataMember]
        public String numCuentaDetraccion { get; set; }

        [DataMember]
        public Decimal MontoDetraccionSoles { get; set; }

        [DataMember]
        public String CorrelativoDetra { get; set; }

        [DataMember]
        public String NombreArchivo { get; set; }

        #endregion

        [DataMember]
        public Decimal TotalS { get; set; }

        [DataMember]
        public Decimal TotalD { get; set; }

        [DataMember]
        public String TipoOperacion { get; set; }

        [DataMember]
        public DateTime fecOrdenPago { get; set; } //Para la generación de la OP (Detracciones de ventas)

        [DataMember]
        public Int32 idOrdenPago { get; set; }

        [DataMember]
        public String codOrdenPago { get; set; }

        [DataMember]
        public String codDocumentoAlmacen { get; set; }

        [DataMember]
        public String nomUMedidaPres { get; set; }

        [DataMember]
        public String nomUMedidaEnv { get; set; }

        [DataMember]
        public Decimal Contenido { get; set; }

        [DataMember]
        public String EstadoFact { get; set; }

        [DataMember]
        public String idDocumentoFact { get; set; }

        [DataMember]
        public String numSerieFact { get; set; }

        [DataMember]
        public String numDocumentoFact { get; set; }

        [DataMember]
        public DateTime? fecEmisionFact { get; set; }

        [DataMember]
        public String codArticuloFact { get; set; }

        [DataMember]
        public Decimal CantidadFact { get; set; }

        [DataMember]
        public String nomMedidaEnvFact { get; set; }

        [DataMember]
        public String nomArticuloFact { get; set; }

        [DataMember]
        public Decimal ContenidoPres { get; set; }

        [DataMember]
        public String nomMedidaPresFact { get; set; }

        [DataMember]
        public String idMonedaFact { get; set; }

        [DataMember]
        public Decimal PrecioUnitDol { get; set; }

        [DataMember]
        public Decimal subTotalDol { get; set; }

        [DataMember]
        public Decimal IgvDol { get; set; }

        [DataMember]
        public Decimal PrecioUnitSol { get; set; }

        [DataMember]
        public Decimal subTotalSol { get; set; }

        [DataMember]
        public Decimal IgvSol { get; set; }

        [DataMember]
        public String Lote { get; set; }

        [DataMember]
        public String desDivision { get; set; }

        [DataMember]
        public Decimal ImporteCobrado { get; set; }

        [DataMember]
        public String numLetras { get; set; }

        [DataMember]
        public String VariedadCaracteristica { get; set; }

        [DataMember]
        public String EspecieCaracteristica { get; set; }

        [DataMember]
        public String TipoCaracteristica { get; set; }

        [DataMember]
        public Boolean indAlmacen { get; set; }

        [DataMember]
        public DateTime? fecDespacho { get; set; }

        [DataMember]
        public String numRucFact { get; set; }

        [DataMember]
        public String RazonSocialFact { get; set; }

        [DataMember]
        public String AnioPedido { get; set; }

        [DataMember]
        public String Referente { get; set; }

        [DataMember]
        public String Clase { get; set; }

        [DataMember]
        public String LoteAlmacen { get; set; }

        [DataMember]
        public String LoteProv { get; set; }

        [DataMember]
        public String Batch { get; set; }

        [DataMember]
        public String PaisOrigen { get; set; }

        [DataMember]
        public Decimal Germinacion { get; set; }

        [DataMember]
        public String CodPedido { get; set; }

    }
}