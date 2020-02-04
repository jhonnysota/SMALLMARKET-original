using System;
using System.Collections.Generic;
using System.ServiceModel;

using Infraestructura.Enumerados;
using Entidades.Ventas;
using Entidades.Maestros;

namespace ContratoWCF
{
    [ServiceContract]
    public interface IVentas
    {

        #region IMedioPago Members JOSE SALAZAR

        [OperationContract]
        MedioPagoE InsertarMedioPago(MedioPagoE pago);

        [OperationContract]
        MedioPagoE ActualizarMedioPago(MedioPagoE pago);

        [OperationContract]
        int EliminarMedioPago(Int32 idMedioPago, Int32 idEmpresa);

        [OperationContract]
        List<MedioPagoE> ListarMedioPago(Int32 idEmpresa);

        [OperationContract]
        MedioPagoE ObtenerMedioPago(Int32 idMedioPago, Int32 idEmpresa);

        [OperationContract]
        int AnularMedioPago(Int32 idMedioPago);

        [OperationContract]
        List<MedioPagoE> ListarMedioPagoPtoVta(Int32 idEmpresa);

        #endregion    

        #region ICampanaTipo Members JOSE SALAZAR

        [OperationContract]
        CampanaTipoE InsertarCampanaTipo(CampanaTipoE campanatipo);

        [OperationContract]
        CampanaTipoE ActualizarCampanaTipo(CampanaTipoE campanatipo);

        [OperationContract]
        int EliminarCampanaTipo(Int32 idTipoCampana,Int32 idEmpresa);

        [OperationContract]
        List<CampanaTipoE> ListarCampanaTipo();

        [OperationContract]
        List<CampanaTipoE> ListarCampanaTipoPorEmpresa(Int32 idEmpresa);

        [OperationContract]
        CampanaTipoE ObtenerCampanaTipo(Int32 idTipoCampana, Int32 idEmpresa);

        #endregion    

        #region ICampana Members JOSE SALAZAR

        [OperationContract]
        CampanaE InsertarCampana(CampanaE campana);

        [OperationContract]
        CampanaE ActualizarCampana(CampanaE campana);

        [OperationContract]
        int EliminarCampana(Int32 idCampana, Int32 idEmpresa);

        [OperationContract]
        List<CampanaE> ListarCampana(Int32 idEmpresa);

        [OperationContract]
        CampanaE ObtenerCampana(Int32 idCampana, Int32 idEmpresa);

        #endregion

        #region IEinvoiceHeader JOSE SALAZAR

        [OperationContract]
        EinvoiceHeaderE ObtenerEinvoiceHeader(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        Int32 EliminarEinvoiceHeader(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        #endregion

        #region IEmisionDocumento JOSE SALAZAR

        [OperationContract]
        EmisionDocumentoE GrabarDocumentos(EmisionDocumentoE documento, EnumOpcionGrabar OpcionGrabar, String indCierreTotal = "N", String RucEmpresa = "");

        [OperationContract]
        EmisionDocumentoE RecuperarDocumentoCompleto(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        EmisionDocumentoE ActualizarEmisionDocumentoVendedor(EmisionDocumentoE emisiondocumento);

        [OperationContract]
        List<EmisionDocumentoE> ListarDocumentosVentas(Int32 idEmpresa, Int32 idLocal, String idDocumento, Int32 idPersona, String Serie, string fecIni, string fecFin);

        [OperationContract]
        List<EmisionDocumentoE> ListarDocumentosEmitidos(Int32 idEmpresa, Int32 idLocal, String idDocumento);

        [OperationContract]
        List<EmisionDocumentoE> ListarDocumentosEmitidosFecha(Int32 idEmpresa, Int32 idLocal, String idDocumento, String fecha);

        [OperationContract]
        List<EmisionDocumentoE> ListarDocEmitidosFechaPorSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento, String fecha, String Serie);

        [OperationContract]
        void CambiarEstadoDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String indEstado, String Usuario, String ConCtaCte = "S", String conCobranza = "S");

        [OperationContract]
        List<EmisionDocumentoE> RecuperarEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String FecIni, String FecFin, String RazonSocial);

        [OperationContract]
        EmisionDocumentoE RevisarEmisionDocumentoReferencias(Int32 idEmpresa, Int32 idLocal, String idDocumentoRef, String serDocumentoRef, String numDocumentoRef, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        Int32 ActualizarEstadoSunat(List<EmisionDocumentoE> oListaPorRevisar);

        [OperationContract]
        Int32 ActualizarDocumentosSunat(EmisionDocumentoE oDocumentoSunat);

        [OperationContract]
        Int32 DarBajaDocumentosVentasSunat(List<EmisionDocumentoE> oListaBaja, String RucEmisor = "", String Tipo = "", Int32 numFila = 0);

        [OperationContract]
        Int32 DarBajaDocumentosVentasSunat2(List<EmisionDocumentoE> oListaBaja, Int32 idEmpresa, Int32 idLocal, String UsuarioModificacion, String Fecha);

        [OperationContract]
        Int32 InsertarFacturaElectronica(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String numLetra, String EsGuia, Int32 idPersona);

        [OperationContract]
        Int32 RecuperarEstadoSunat(List<EmisionDocumentoE> oListaDocumentos);

        [OperationContract]
        Int32 ResumenBoletas(Int32 idEmpresa,String Fecha, String Serie, String numDesde, String numHasta);

        [OperationContract]
        EmisionDocumentoE ObtenerEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        Int32 EliminarEmisDocuCompleto(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        String FacturaElectronicaUrlPdf(String TipoDocumentoEmisor, String RucEmisor, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        EmisionDocumentoE RecuperarGuiaCompleta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        List<EmisionDocumentoE> ListarDocumentosCanje(List<EmisionDocumentoE> oListaDocumentos);

        [OperationContract]
        EmisionDocumentoE GrabarTicket(EmisionDocumentoE documento, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        bool AnularTicket(EmisionDocumentoE documento, string EliminarPedido, string Usuario);

        [OperationContract]
        List<EmisionDocumentoE> ListaDocVentasParaSunat(String Tipo, Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, bool EnviadoSunat, bool AnuladoSunat);

        [OperationContract]
        List<EmisionDocumentoE> ListarReporteVentasDetallada(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente, Int32 idEstablecimiento, Int16 Reporte);

        [OperationContract]
        List<EmisionDocumentoE> ReporteMensualVentasResumida(Int32 idEmpresa, Int32 idLocal, String Anio, String MesIni, String MesFin, String idMoneda, Int32 idPersona);

        [OperationContract]
        Int32 EliminarVoucherEmiDoc(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero, String Usuario);

        [OperationContract]
        EmisionDocumentoE GenerarVoucherEmiDoc(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero, String Usuario);

        [OperationContract]
        Int32 IngresarDocCtaCte(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Usuario);

        [OperationContract]
        List<EmisionDocumentoE> ComparativoVentasMulti(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda, Int32 TipoRep ,Int32 TipoPresentacion);

        [OperationContract]
        List<EmisionDocumentoE> ComparativoVentasVsPresupuesto(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda, Int32 TipoRep, Int32 TipoPresentacion);

        [OperationContract]
        Int32 EliminarAnticipoAnulados(EmisionDocumentoE oDocAnulado);

        [OperationContract]
        List<EmisionDocumentoE> ListarDetraccionCabEmisDocu(Int32 idEmpresa);

        [OperationContract]
        Int32 ActualizarDetraccionDetEmisDocu(List<EmisionDocumentoE> oListaDocumentos);

        [OperationContract]
        Int32 ActualizarDetraccionCabEmisDocu(List<EmisionDocumentoE> oListaDocumentos);

        [OperationContract]
        List<EmisionDocumentoE> ListarVentasAutoDetracciones(Int32 idEmpresa, string fecIni, string fecFin);

        [OperationContract]
        Int32 GenerarOpVentasDetracciones(List<EmisionDocumentoE> oListaVentasDetra, Int32 idEmpresa, String Usuario);

        [OperationContract]
        List<EmisionDocumentoE> ControlGuiasVenta(Int32 idEmpresa, Int32 idLocal, String idDocumento, string fecIni, string fecFin);

        [OperationContract]
        List<EmisionDocumentoE> ListarReporteVentasDetalladaOT(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente);

        [OperationContract]
        EmisionDocumentoE GenerarFacturaCopia(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numDocumento, String numSerie, EmisionDocumentoE EmiDoc);

        [OperationContract]
        Int32 ActualizaTCVentas(Int32 idEmpresa, string Desde, string Hasta);

        [OperationContract]
        EmisionDocumentoE ObtenerVendedorCondicion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        Int32 ActualizarNroDocAsociado(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, Int32 nroDocAsociado, String Usuario, Boolean EsAnticipo, DateTime? fecFactura = null);

        [OperationContract]
        Boolean PruebaGuias(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        EmisionDocumentoE ActualizarFecDespacho(EmisionDocumentoE emisiondocumento);

        #endregion

        #region IEmisionDocumentoDet JOSE SALAZAR

        [OperationContract]
        EmisionDocumentoDetE InsertarEmisionDocumentoDet(EmisionDocumentoDetE emisiondocumentodet);

        [OperationContract]
        EmisionDocumentoDetE ActualizarEmisionDocumentoDet(EmisionDocumentoDetE emisiondocumentodet);

        [OperationContract]
        List<EmisionDocumentoDetE> ObtenerEmisionDocumentoDet(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);
       
        [OperationContract]
        List<EmisionDocumentoDetE> ObtenerEmisionDocumentoDet2(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        List<EmisionDocumentoDetE> ReporteGuiaPorFacturar(Int32 idEmpresa, Int32 idLocal, DateTime Desde, DateTime Hasta);

        [OperationContract]
        Int32 EliminarEmisionDocumentoDet(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        EmisionDocumentoDetE ObtenerEmisionDocumentoDetItem(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item);

        [OperationContract]
        List<EmisionDocumentoDetDetalleE> ObtenerEmisionDocumentoDetallado(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        #endregion

        #region IEmisionDocumentoExporta JOSE SALAZAR

        [OperationContract]
        EmisionDocumentoExportaE InsertarEmisionDocumentoExporta(EmisionDocumentoExportaE emisiondocumentoexporta);

        //[OperationContract]
        //EmisionDocumentoExportaE ActualizarEmisionDocumentoExporta(EmisionDocumentoExportaE emisiondocumentoexporta);

        //[OperationContract]
        //List<EmisionDocumentoExportaE> ListarEmisionDocumentoExporta();

        [OperationContract]
        Int32 EliminarEmisionDocumentoExporta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item);

        //[OperationContract]
        //List<EmisionDocumentoExportaE> ObtenerEmisionDocumentoExporta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        #endregion

        #region ICanjeGuias JOSE SALAZAR

        [OperationContract]
        CanjeGuiasE InsertarCanjeGuias(CanjeGuiasE canjeguias);

        //[OperationContract]
        //CanjeGuiasE ActualizarCanjeGuias(CanjeGuiasE canjeguias);

        //[OperationContract]
        //List<CanjeGuiasE> ListarCanjeGuias();

        [OperationContract]
        Int32 EliminarCanjeGuias(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact, String idDocumentoGuia, String numSerieGuia, String numDocumentoGuia);

        [OperationContract]
        List<CanjeGuiasE> ObtenerCanjeGuias(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact);

        #endregion

        #region ITipoTraslado Members JOSE SALAZAR

        [OperationContract]
        TipoTrasladoE InsertarTipoTraslado(TipoTrasladoE tipotraslado);

        [OperationContract]
        TipoTrasladoE ActualizarTipoTraslado(TipoTrasladoE tipotraslado);

        [OperationContract]
        List<TipoTrasladoE> ListarTipoTraslado();

        [OperationContract]
        Int32 AnularTipoTraslado(Int32 idTraslado);

        [OperationContract]
        TipoTrasladoE ObtenerTipoTraslado(Int32 idTraslado);

        #endregion

        #region ITransporte JOSE SALAZAR

        [OperationContract]
        TransporteE GrabarTransporte(TransporteE transporte, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        TransporteE ObtenerTransporteCompleto(Int32 idTransporte);

        [OperationContract]
        List<TransporteE> ListarTransporte(String RazonSocial, String Ruc, Boolean Activo, Boolean Inactivo);

        [OperationContract]
        Int32 AnularTransporte(Int32 idTransporte);

        [OperationContract]
        TransporteE ObtenerTransporte(Int32 idTransporte);

        [OperationContract]
        void AnulacionCompleta(Int32 idTransporte);

        [OperationContract]
        List<TransporteE> ListarTransporteBusqueda(String RazonSocial, String Ruc);

        #endregion

        #region ITransporteConductores JOSE SALAZAR

        [OperationContract]
        Int32 AnularTransporteConductores(Int32 idTransporte, Int32 idConductor);

        [OperationContract]
        TransporteConductoresE ObtenerTransporteConductores(Int32 idTransporte, Int32 idConductor);

        [OperationContract]
        List<TransporteConductoresE> ListarTransporteConductores();

        #endregion

        #region ITransporteVehiculos JOSE SALAZAR

        [OperationContract]
        Int32 AnularTransporteVehiculos(Int32 idTransporte, Int32 idVehiculo);

        [OperationContract]
        TransporteVehiculosE ObtenerTransporteVehiculos(Int32 idTransporte, Int32 idVehiculo);

        [OperationContract]
        List<TransporteVehiculosE> ListarTransporteVehiculos();

        #endregion

        #region ICondicionTipo JOSE SALAZAR

        [OperationContract]
        CondicionTipoE GrabarCondicionTipo(CondicionTipoE CondicionTipo, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        List<CondicionTipoE> ListarCondicionTipo();

        [OperationContract]
        CondicionTipoE ObtenerCondicionTipoCompleto(Int32 idTipCondicion);

        #endregion

        #region ICondicion JOSE SALAZAR

        [OperationContract]
        CondicionE InsertarCondicion(CondicionE condicion);

        [OperationContract]
        CondicionE ActualizarCondicion(CondicionE condicion);

        [OperationContract]
        List<CondicionE> ListarCondicionPorTipo(Int32 idTipCondicion);

        [OperationContract]
        Int32 EliminarCondicion(Int32 idTipCondicion);

        //[OperationContract]
        //List<CondicionE> ListarCondicion();

        [OperationContract]
        CondicionE ObtenerCondicion(Int32 idTipCondicion, Int32 idCondicion);

        #endregion

        #region ICondicionDias JOSE SALAZAR

        [OperationContract]
        CondicionDiasE InsertarCondicionDias(CondicionDiasE condiciondias);

        [OperationContract]
        CondicionDiasE ActualizarCondicionDias(CondicionDiasE condiciondias);

        [OperationContract]
        Int32 ObtenerDiasVencimiento(Int32 idTipCondicion, Int32 idCondicion);

        [OperationContract]
        List<CondicionDiasE> ListarCondicionDias(Int32 idTipCondicion, Int32 idCondicion);
        
        #endregion

        #region IPedidoCab Members JOSE SALAZAR

        [OperationContract] //JOSE SALAZAR
        PedidoCabE GrabarPedidosNacionales(PedidoCabE PedidoNacional, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]//JOSE SALAZAR
        List<PedidoCabE> ListarPedidoNacional(int idEmpresa, int idLocal, string codPedidoCad, string fecInicial, string fecFinal, string RazonSocial, string Tipo, int idVendedor, string Estado);

        [OperationContract]//JOSE SALAZAR
        PedidoCabE RecuperarPedidoNacional(Int32 idEmpresa, Int32 idLocal, Int32 idPedido);

        [OperationContract] //JOSE SALAZAR
        String ObtenerUltimoNroPedido(Int32 idEmpresa, Int32 idLocal, String indCotPed);

        [OperationContract] //JOSE SALAZAR
        Int32 CrearDocumentos(PedidoCabE oPedido, String idDocumento, String Serie, String tipDoc, String idDocGuia, String SerieGuia, String UsuarioRegistro);

        [OperationContract] //JOSE SALAZAR
        Boolean CopiarPedido(Int32 idEmpresa, Int32 idLocal, Int32 idPedido, String indCotPed, String Usuario, DateTime Fecha);

        [OperationContract] // JOSE SALAZAR
        String GenerarPedidoOrdenCompra(Int32 idEmpresa, Int32 idLocal, Int32 idPedido, String Usuario);

        [OperationContract] //JOSE SALAZAR
        Int32 EliminarTodoPedido(Int32 idEmpresa, Int32 idPedido, Int32 idLocal, String LiberaCotizacion = "N", Int32 idCotizacion = 0);

        [OperationContract] //JOSE SALAZAR
        PedidoCabE ActualizarDocumentosPed(PedidoCabE pedidocab);

        [OperationContract] //JOSE SALAZAR
        Int32 CrearPedido(Int32 idEmpresa, Int32 idLocal, Int32 idCotizacion, String Usuario);

        [OperationContract] //JOSE SALAZAR
        Int32 ActualizarEnvio(Int32 idPedido, Boolean CorreoEnviado);

        [OperationContract] //JOSE SALAZAR
        List<PedidoCabE> ListarPedidosPorCliente(Int32 idEmpresa, Int32 idLocal, Int32 idCliente);

        [OperationContract]
        List<ImpresionBarrasDetDetE> InsertarImpresionBarrasPedido(Int32 idEmpresa, Int32 idLocal, Int32 idPedido, String Usuario);

        [OperationContract]
        String GenerarNroPedido(Int32 IdEmpresa, string FecPedido);

        [OperationContract]
        PedidoCabE GrabarPedidoPtoVta(PedidoCabE pedido);

        [OperationContract]
        List<PedidoCabE> ListarPedidosPtoVta(Int32 idEmpresa, Int32 idLocal, String RazonSocial);

        [OperationContract]
        PedidoCabE RecuperarPedidoPtoVta(Int32 idPedido);

        [OperationContract]
        Int32 ConvertirCotiPed(Int32 idPedido);

        #endregion

        #region IPedidoDet Members JOSE SALAZAR

        [OperationContract]
        PedidoDetE InsertarPedidoDet(PedidoDetE pedidodet);

        [OperationContract]
        PedidoDetE ActualizarPedidoDet(PedidoDetE pedidodet);

        #endregion        

        #region INumControl Members JOSE SALAZAR

        [OperationContract]
        NumControlE GrabarNumControl(NumControlE numControl, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        NumControlE ObtenerNumControlCompleto(Int32 idEmpresa, Int32 idLocal, Int32 idControl);

        [OperationContract]
        List<NumControlE> ListarNumControl(Int32 idEmpresa, Int32 idLocal);        

        #endregion

        #region INumControlDet Members JOSE SALAZAR

        [OperationContract]
        NumControlDetE ObtenerNumControlDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item); //String idDocumento, String Serie);

        [OperationContract]
        List<NumControlDetE> ListarNumControlDetPorGrupo(Int32 idEmpresa, Int32 idLocal, String Grupo);

        [OperationContract]
        List<NumControlDetE> ListarSeriesNumControlDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, String idDocumento);

        [OperationContract]
        NumControlDetE ObtenerNumControlDetPorIdDocumento(Int32 idEmpresa, Int32 idLocal, Int32 idControl, String idDocumento, String Serie);

        [OperationContract]
        List<NumControlDetE> ListarNumControlDetPorEmpresa(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        NumControlDetE NumControlDetTipoDocSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie);

        #endregion

        #region ILinea Members JOSE SALAZAR

        [OperationContract]
        LineaE InsertarLinea(LineaE linea);

        [OperationContract]
        LineaE ActualizarLinea(LineaE linea);

        [OperationContract]
        int EliminarLinea(Int32 idEmpresa, String idLinea);

        [OperationContract]
        List<LineaE> ListarLinea(Int32 idEmpresa);

        [OperationContract]
        LineaE ObtenerLinea(Int32 idEmpresa, String idLinea);

        #endregion

        #region ICategoriaVendedor JOSE SALAZAR

        [OperationContract]
        CategoriaVendedorE InsertarCategoriaVendedor(CategoriaVendedorE categoria);

        [OperationContract]
        CategoriaVendedorE ActualizarCategoriaVendedor(CategoriaVendedorE categoria);

        [OperationContract]
        int EliminarCategoriaVendedor(Int32 idEmpresa, Int32 idCategoria);

        [OperationContract]
        List<CategoriaVendedorE> ListarCategoriaVendedor(string paramBusquedad);

        [OperationContract]
        CategoriaVendedorE ObtenerCategoriaVendedor(Int32 idEmpresa, int idCategoria, string codCategoria);

        [OperationContract]
        int GrabarCategoriaVendedor(CategoriaVendedorE categoria);

        #endregion     
  
        #region ICategoriaVendedorLinea JOSE SALAZAR

        [OperationContract]
        CategoriaVendedorLineaE InsertarCategoriaVendedorLinea(CategoriaVendedorLineaE categorialinea);

        [OperationContract]
        CategoriaVendedorLineaE ActualizarCategoriaVendedorLinea(CategoriaVendedorLineaE categorialinea);

        [OperationContract]
        int EliminarCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria, string idLinea);

        [OperationContract]
        List<CategoriaVendedorLineaE> ListarCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria);

        [OperationContract]
        CategoriaVendedorLineaE ObtenerCategoriaVendedorLinea(Int32 idEmpresa, Int32 idCategoria, Int32 idLinea);

        #endregion      

        #region IPeriodoComision JOSE SALAZAR

        [OperationContract]
        PeriodoComisionE InsertarPeriodoComision(PeriodoComisionE periodocomision);

        [OperationContract]
        PeriodoComisionE ActualizarPeriodoComision(PeriodoComisionE periodocomision);

        [OperationContract]
        int EliminarPeriodoComision(Int32 idEmpresa, Int32 idPeriodo);

        [OperationContract]
        List<PeriodoComisionE> ListarPeriodoComision(Int32 idEmpresa);

        [OperationContract]
        PeriodoComisionE ObtenerPeriodoComision(Int32 idEmpresa, Int32 idPeriodo);

        #endregion

        #region ICalculoComisiones JOSE SALAZAR

        [OperationContract]
        List<ComisionesCalE> CalculoComision(Int32 idEmpresa, Int32 idPeriodo, DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<ComisionesCalE> PagarComision(Int32 idEmpresa, Int32 idPeriodoInicio, Int32 idPeriodoFinal, DateTime FechaProceso);

        [OperationContract]
        ComisionesCalE ObtenerPeriodoComisioncal(Int32 idEmpresa, Int32 idPeriodo);

        [OperationContract]
        List<ComisionesCalE> ListarComisionCal(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor);

        [OperationContract]
        List<ComisionesCalE> ListarComisionPag(Int32 idEmpresa, Int32 idVendedor, DateTime FechaProceso);

        [OperationContract]
        List<ComisionesCalE> ListarComisionPendientePeriodo(Int32 idEmpresa, Int32 idPeriodoPago, String Estado, Int32 idVendedor);

        #endregion
        
        #region IComisionesConfiguracion JOSE SALAZAR

        [OperationContract]
        ComisionesConfiguracionE InsertarComisionesConfiguracion(ComisionesConfiguracionE comisionesconfiguracion);

        [OperationContract]
        ComisionesConfiguracionE ActualizarComisionesConfiguracion(ComisionesConfiguracionE comisionesconfiguracion);

        [OperationContract]
        int EliminarComisionesConfiguracion(Int32 idEmpresa, Int32 idComision);

        [OperationContract]
        List<ComisionesConfiguracionE> ListarComisionesConfiguracion(Int32 idEmpresa, Int32 idComision, String TipoReporte);

        [OperationContract]
        List<ComisionesConfiguracionE> ListarComisionesConfiguracionPeriodo(Int32 idEmpresa, Int32 idPeriodo, String Busqueda);

        [OperationContract]
        ComisionesConfiguracionE ObtenerComisionesConfiguracion(Int32 idEmpresa, Int32 idComision);
        
        [OperationContract]
        void GuardarComisiones(ComisionesConfiguracionE oEntidad);

        #endregion     

        #region Icomision Members JOSE SALAZAR

        [OperationContract]
        comisionE Insertarcomision(comisionE comision);

        [OperationContract]
        comisionE Actualizarcomision(comisionE comision);

        [OperationContract]
        int Eliminarcomision(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor);

        [OperationContract]
        List<comisionE> Listarcomision();

        [OperationContract]
        comisionE Obtenercomision(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor);

        [OperationContract]
        List<comisionE> ResumenComisiones(Int32 idEmpresa, Int32 idPeriodo);

        #endregion 

        #region IvenParametros Members JOSE SALAZAR

        [OperationContract]
        venParametrosE InsertarVenParametros(venParametrosE parametros);

        [OperationContract]
        venParametrosE ActualizarVenParametros(venParametrosE parametros);

        [OperationContract]
        List<venParametrosE> ListarVenParametros();

        [OperationContract]
        venParametrosE ObtenerVenParametros(Int32 idEmpresa);

        #endregion

        #region IZonaTrabajo JOSE SALAZAR

        [OperationContract]
        ZonaTrabajoE InsertarZonaTrabajo(ZonaTrabajoE zonatrabajo);

        [OperationContract]
        ZonaTrabajoE ActualizarZonaTrabajo(ZonaTrabajoE zonatrabajo);

        [OperationContract]
        Int32 EliminarZonaTrabajo(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, Int32 idZona);

        //[OperationContract]
        //List<ZonaTrabajoE> ListarZonaTrabajo(Int32 idEmpresa, Int32 idLocal, Int32 idVendedor);

        [OperationContract]
        ZonaTrabajoE ObtenerZonaTrabajo(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento, Int32 idZona);

        [OperationContract]
        List<ZonaTrabajoE> ListarZonasPorIdEstablecimiento(Int32 idEmpresa, Int32 idLocal, Int32 idEstablecimiento);

        #endregion

        #region IListaPrecio Members JOSE SALAZAR

        [OperationContract]
        ListaPrecioE GrabarListaPrecio(ListaPrecioE listaprecio, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        ListaPrecioE InsertarListaPrecio(ListaPrecioE listaprecio);

        [OperationContract]
        ListaPrecioE ActualizarListaPrecio(ListaPrecioE listaprecio);

        [OperationContract]
        Int32 EliminarListaPrecio(Int32 idEmpresa, Int32 idListaPrecio);

        [OperationContract]
        List<ListaPrecioE> ListarListaPrecio(Int32 idEmpresa);

        [OperationContract]
        ListaPrecioE ObtenerListaPrecio(Int32 idEmpresa, Int32 idListaPrecio);

        [OperationContract]
        List<ListaPrecioE> ListarPrecioPorTipo(Int32 idEmpresa, Boolean ParaTicket);

        [OperationContract] //JOSE SALAZAR
        List<ListaPrecioE> ListarPrecioConItems(Int32 idEmpresa);

        [OperationContract] //JOSE SALAZAR
        ListaPrecioE RecuperarListaPrecio(Int32 idEmpresa, Int32 idListaPrecio);

        #endregion

        #region IListaPrecioItem Members JOSE SALAZAR

        [OperationContract]
        ListaPrecioItemE InsertarListaPrecioItem(ListaPrecioItemE listaprecioitem);

        [OperationContract]
        ListaPrecioItemE ActualizarListaPrecioItem(ListaPrecioItemE listaprecioitem);

        [OperationContract]
        Int32 EliminarListaPrecioItem(Int32 idEmpresa, Int32 idListaPrecio, Int32 item);

        [OperationContract]
        List<ListaPrecioItemE> ListarListaPrecioItem(Int32 idEmpresa, Int32 idListaPrecio);

        [OperationContract]
        ListaPrecioItemE ObtenerListaPrecioItem(Int32 idEmpresa, Int32 idListaPrecio, Int32 item);

        [OperationContract]
        ListaPrecioItemE ObtenerListaPrecioItemArticulo(Int32 idEmpresa, Int32 idListaPrecio, Int32 idArticulo);

        [OperationContract]  //JOSE SALAZAR
        Int32 RevisarPrecioItem(Int32 idEmpresa, Int32 idLocal, Int32 idTipoArticulo, Int32 idArticulo, Int32 idListaPrecio);

        #endregion

        #region ILetrasCanje Members JOSE SALAZAR

        [OperationContract]
        LetrasCanjeE InsertarLetrasCanje(LetrasCanjeE letrascanje);

        [OperationContract]
        LetrasCanjeE ActualizarLetrasCanje(LetrasCanjeE letrascanje);

        //[OperationContract]
        //int EliminarLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        List<LetrasCanjeE> ListarLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        LetrasCanjeE ObtenerLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        LetrasCanjeE LetrasCanjePorDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, string numDocumento);

        [OperationContract]
        Int32 ActualizarLetrasCanjeConta(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String idComprobante, String numFile, String Anio, String Mes, String Voucher, String Usuario);

        #endregion

        #region ILetras Members JOSE SALAZAR

        [OperationContract]
        LetrasE InsertarLetras(LetrasE letras);

        [OperationContract]
        LetrasE ActualizarLetras(LetrasE letras);

        [OperationContract]
        List<LetrasE> ListarLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, Int32 idPersona, String Estado, String TipoFecha, DateTime fecIni, DateTime fecFinal);

        [OperationContract]
        LetrasE ObtenerLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, String ConFacturas = "N");

        [OperationContract]
        List<LetrasE> ListarLetrasPorCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        List<UbigeoE> ListarPlazas();

        [OperationContract]
        Int32 ActualizarEstadoDeLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32? idCtaCte, Int32? idCtaCteItem, String Estado, String UsuarioModificacion);

        #endregion

        #region ILetrasCanjeUnion Members JOSE SALAZAR

        [OperationContract]
        bool GrabarLetrasCanje(LetrasCanjeUnionE oLetraCanjeUnion, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        LetrasCanjeUnionE InsertarLetrasCanjeUnion(LetrasCanjeUnionE letrascanjeunion);

        [OperationContract]
        LetrasCanjeUnionE ActualizarLetrasCanjeUnion(LetrasCanjeUnionE letrascanjeunion);

        [OperationContract]
        int EliminarLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        List<LetrasCanjeUnionE> ListarLetrasCanjeUnion();

        [OperationContract]
        LetrasCanjeUnionE ObtenerLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        int AprobarLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, DateTime fecAprobacion, String Usuario);

        [OperationContract]
        String GenerarProvisionLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, Int32 idPersona, String RazonSocial, String Usuario, String Corregir = "N");

        [OperationContract]
        int DesaprobarLetras(LetrasE oLetra, String Usuario);

        [OperationContract]
        List<LetrasCanjeUnionE> ReporteCanjeLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        List<LetrasCanjeUnionE> ReporteCanjeLetraPorEstado(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Estado);

        [OperationContract]
        Int32 ActualizarLetraDocCtaCte(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje);

        [OperationContract]
        String CorregirLetraTicaCteCte(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Usuario);

        #endregion

        #region ILetrasEstado Members JOSE SALAZAR

        [OperationContract]
        LetrasEstadoE InsertarLetrasEstado(LetrasEstadoE letrasestado);

        [OperationContract]
        LetrasEstadoE ActualizarLetrasEstado(LetrasEstadoE letrasestado);

        //[OperationContract]
        //int EliminarLetrasEstado(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32 item);

        [OperationContract]
        List<LetrasEstadoE> ListarLetrasEstado();

        [OperationContract]
        LetrasEstadoE ObtenerLetrasEstado(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32 item);

        [OperationContract]
        List<LetrasEstadoE> ListarEstadosLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre);

        #endregion

        #region ICreditoConcepto JOSE SALAZAR

        [OperationContract]
        CreditoConceptoE InsertarCreditoConcepto(CreditoConceptoE creditoconcepto);

        [OperationContract]
        CreditoConceptoE ActualizarCreditoConcepto(CreditoConceptoE creditoconcepto);

        [OperationContract]
        int EliminarCreditoConcepto(Int32 idConcepto);

        [OperationContract]
        List<CreditoConceptoE> ListarCreditoConcepto();

        [OperationContract]
        CreditoConceptoE ObtenerCreditoConcepto(Int32 idConcepto);

        #endregion

        #region ILineaCredito JOSE SALAZAR

        [OperationContract]
        LineaCreditoE InsertarLineaCredito(LineaCreditoE lineacredito);

        [OperationContract]
        LineaCreditoE ActualizarLineaCredito(LineaCreditoE lineacredito);

        [OperationContract]
        int EliminarLineaCredito(Int32 idPersona, Int32 idEmpresa, Int32 item);

        [OperationContract]
        List<LineaCreditoE> ListarLineaCredito();

        [OperationContract]
        LineaCreditoE ObtenerLineaCredito(Int32 idPersona, Int32 idEmpresa, Int32 item);

        #endregion

        #region IcomisionPago Members JOSE SALAZAR

        [OperationContract]
        comisionPagoE InsertarcomisionPago(comisionPagoE comisionpago);

        [OperationContract]
        comisionPagoE ActualizarcomisionPago(comisionPagoE comisionpago);

        [OperationContract]
        int EliminarcomisionPago(Int32 idEmpresa, Int32 idCalculo);

        [OperationContract]
        List<comisionPagoE> ListarcomisionPago();

        [OperationContract]
        comisionPagoE ObtenercomisionPago(Int32 idEmpresa, Int32 idCalculo);

        #endregion

        #region IAnticipos Members JOSE SALAZAR

        [OperationContract]
        AnticiposE InsertarAnticipos(AnticiposE anticipos);

        [OperationContract]
        AnticiposE ActualizarAnticipos(AnticiposE anticipos);

        [OperationContract]
        int EliminarAnticipos(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona);

        [OperationContract]
        List<AnticiposE> ListarAnticipos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona);

        [OperationContract]
        List<AnticiposE> ReporteAnticipos(Int32 idEmpresa, DateTime Desde, DateTime Hasta, String idMoneda, Int32 idPersona, Boolean PorAplicar, Boolean Aplicado);

        [OperationContract]
        AnticiposE ObtenerAnticipos(Int32 idEmpresa, Int32 idLocal, String idDocAnticipo, String numSerieAnticipo, String numDocAnticipo, Int32 idPersona);

        #endregion

        #region IEmisionDocumentoCancelacion Members JOSE SALAZAR

        [OperationContract]
        int EliminarEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        List<EmisionDocumentoCancelacionE> ListarEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumentoReci, String numSerieReci, String numDocumentoReci, string fecIni, string fecFin);

        [OperationContract]
        List<EmisionDocumentoCancelacionE> ObtenerEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        int GenerarCobranzas(List<EmisionDocumentoCancelacionE> oListaCancelaciones, String Usuario);

        [OperationContract]
        List<EmisionDocumentoCancelacionE> ReporteConsolidadoCaja(Int32 idEmpresa, Int32 idLocal, string fecha);

        #endregion

        #region IListaCancPuntoDeVenta Members JOSE SALAZAR

        [OperationContract]
        List<CancPuntoDeVentaE> ListarCancPuntoDeVenta(Int32 idEmpresa, DateTime Fecha, String PuntoVenta);

        #endregion

        #region IOrdenTrabajoServicio Members JOSE SALAZAR

        [OperationContract]
        OrdenTrabajoServicioE GrabarOrdenTrabajoServicio(OrdenTrabajoServicioE OrdenTrabajoServicio, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        OrdenTrabajoServicioE InsertarOrdenTrabajoServicio(OrdenTrabajoServicioE ordentrabajoservicio);

        [OperationContract]
        OrdenTrabajoServicioE ActualizarOrdenTrabajoServicio(OrdenTrabajoServicioE ordentrabajoservicio);

        [OperationContract]
        int EliminarOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idOT);

        [OperationContract]
        List<OrdenTrabajoServicioE> ListarOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idArea);

        [OperationContract]
        List<OrdenTrabajoServicioE> ListarOrdenTrabajoServicioPorFilt(Int32 idEmpresa, Int32 idLocal, Int32 idArea);

        [OperationContract]
        OrdenTrabajoServicioE ObtenerOrdenTrabajoServicio(Int32 idEmpresa, Int32 idLocal, Int32 idOT);

        [OperationContract]
        OrdenTrabajoServicioE ObtenerOrdenTrabServCompleto(Int32 idEmpresa, Int32 idLocal, Int32 idOT);

        [OperationContract]
        List<OrdenTrabajoServicioE> ListarOTServicioPendientes(Int32 idEmpresa, Int32 idLocal,Int32 Personatmp);

        [OperationContract]
        Int32 ObtenerNroOT(Int32 idEmpresa, Int32 idLocal, Int32 idArea);

        [OperationContract]
        Byte[] ObtenerImagenOt(String Ruta);

        #endregion

        #region IOrdenTrabajoServicioItem Members JOSE SALAZAR

        [OperationContract]
        List<OrdenTrabajoServicioItemE> ListarReporteOTPorEstado(Int32 idEmpresa, String Estado, Int32 idPersona, Int32 idArea, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        OrdenTrabajoServicioItemE InsertarOrdenTrabajoServicioItem(OrdenTrabajoServicioItemE ordentrabajoservicioitem);

        [OperationContract]
        OrdenTrabajoServicioItemE ActualizarOrdenTrabajoServicioItem(OrdenTrabajoServicioItemE ordentrabajoservicioitem);

        [OperationContract]
        int EliminarOrdenTrabajoServicioItem(Int32 idEmpresa, Int32 idLocal, Int32 idOT, Int32 idItem);

        [OperationContract]
        List<OrdenTrabajoServicioItemE> ListarOrdenTrabajoServicioItem(Int32 idEmpresa, Int32 idLocal, Int32 idOT);

        [OperationContract]
        List<OrdenTrabajoServicioItemE> ListarOrdenTrabajoServicioItemTodo();

        [OperationContract]
        OrdenTrabajoServicioItemE ObtenerOrdenTrabajoServicioItem(Int32 idEmpresa, Int32 idLocal, Int32 idOT, Int32 idItem);

        [OperationContract]
        void CambiarEstadoDocumentoOT(Int32 idEmpresa, Int32 idLocal, Int32 idOT, Int32 idItem, String Estado);

        #endregion

        #region IPlanillaBancos Members JOSE SALAZAR

        [OperationContract]
        PlanillaBancosE GrabarPlanillaBancos(PlanillaBancosE planillabancos, EnumOpcionGrabar Opcion);

        [OperationContract]
        PlanillaBancosE InsertarPlanillaBancos(PlanillaBancosE planillabancos);

        [OperationContract]
        PlanillaBancosE ActualizarPlanillaBancos(PlanillaBancosE planillabancos);

        [OperationContract]
        int EliminarPlanillaBancos(Int32 idPlanillaBanco);

        [OperationContract]
        List<PlanillaBancosE> ListarPlanillaBancos(Int32 idEmpresa, Int32 idLocal, Int32 idBanco, String Producto, String tipFecha, DateTime fecIni, DateTime fecFin, String Tipo);

        [OperationContract]
        PlanillaBancosE ObtenerPlanillaBancos(Int32 idPlanillaBanco);

        [OperationContract]
        PlanillaBancosE ObtenerPlanillaBancosCompleto(Int32 idPlanillaBanco);

        [OperationContract]
        String GenerarAsientoLetrasDiferidas(Int32 idPlanillaBanco, Int32 idEmpresa, Int32 idLocal, String Usuario);

        [OperationContract]
        String GenerarAsientoReclasificacion(Int32 idPlanillaBanco, Int32 idEmpresa, Int32 idLocal, String Usuario);

        [OperationContract]
        int AnularPlanillaBancos(Int32 idPlanillaBanco, String numVoucher, String numVoucherRec, String Usuario, String Estado, Boolean Generar, String Tipo);

        [OperationContract]
        Int32 EliminarAsientoLetras(PlanillaBancosE oPlanilla, String Usuario, String Estado, Boolean Generar, String Tipo);

        [OperationContract]
        List<PlanillaBancosE> ListarPlaBanLetrasEndosadas(Int32 idPersonaEndoso);

        [OperationContract]
        String RevisarLetrasCobranzas(PlanillaBancosE oPlanilla);

        #endregion

        #region IPlanillaBancosDet Members JOSE SALAZAR

        [OperationContract]
        PlanillaBancosDetE InsertarPlanillaBancosDet(PlanillaBancosDetE planillabancosdet);

        [OperationContract]
        PlanillaBancosDetE ActualizarPlanillaBancosDet(PlanillaBancosDetE planillabancosdet);

        [OperationContract]
        int EliminarPlanillaBancosDet(Int32 idPlanillaBanco);

        [OperationContract]
        List<PlanillaBancosDetE> ListarPlanillaBancosDet(Int32 idPlanillaBanco);

        [OperationContract]
        PlanillaBancosDetE ObtenerPlanillaBancosDet(Int32 idPlanillaBanco, String Letra);

        #endregion

        #region ILetrasEstadoLibroFile Members  JOSE SALAZAR

        [OperationContract]
        LetrasEstadoLibroFileE InsertarLetrasEstadoLibroFile(LetrasEstadoLibroFileE letrasestadolibrofile);

        [OperationContract]
        LetrasEstadoLibroFileE ActualizarLetrasEstadoLibroFile(LetrasEstadoLibroFileE letrasestadolibrofile);

        [OperationContract]
        int EliminarLetrasEstadoLibroFile(String Estado);

        [OperationContract]
        List<LetrasEstadoLibroFileE> ListarLetrasEstadoLibroFile(Int32 idEmpresa);

        [OperationContract]
        LetrasEstadoLibroFileE ObtenerLetrasEstadoLibroFile(String Estado, Int32 idEmpresa);

        #endregion

        #region IPresupuestoVenta Members JOSE SALAZAR

        [OperationContract]
        PresupuestoVentaE GrabarPresupuestoVenta(PresupuestoVentaE PresupuestsoVenta, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        PresupuestoVentaE InsertarPresupuestoVenta(PresupuestoVentaE presupuestoventa);

        [OperationContract]
        PresupuestoVentaE ActualizarPresupuestoVenta(PresupuestoVentaE presupuestoventa);

        [OperationContract]
        int EliminarPresupuestoVenta(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor);

        [OperationContract]
        List<PresupuestoVentaE> ListarPresupuestoVenta(Int32 idEmpresa, String AnioPresupuesto);

        [OperationContract]
        PresupuestoVentaE ObtenerPresupuestoVenta(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor);

        [OperationContract]
        PresupuestoVentaE ObtenerPresupuestoVentaCompleto(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor);

        #endregion

        #region IPresupuestoVentaDet Members JOSE SALAZAR

        [OperationContract]
        PresupuestoVentaDetE InsertarPresupuestoVentaDet(PresupuestoVentaDetE presupuestoventadet);

        [OperationContract]
        PresupuestoVentaDetE ActualizarPresupuestoVentaDet(PresupuestoVentaDetE presupuestoventadet);

        [OperationContract]
        int EliminarPresupuestoVentaDet(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor, Int32 idEstablecimiento, Int32 idArticulo, String Mes);

        [OperationContract]
        List<PresupuestoVentaDetE> ListarPresupuestoVentaDet(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor);

        [OperationContract]
        PresupuestoVentaDetE ObtenerPresupuestoVentaDet(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor, Int32 idEstablecimiento, Int32 idArticulo, String Mes);

        #endregion

        #region IPresupuestoDeVentasXLS Members JOSE SALAZAR

        [OperationContract]
        Int32 InsertarPresupuestoDeVentasXLS(List<PresupuestoDeVentasXLSE> oListaPresupuestoDeVentas);

        [OperationContract]
        Int32 ErroresPresupuestoDeVentasXLS(List<PresupuestoDeVentasXLSE> oListaErrores);

        [OperationContract]
        Int32 IntegrarPresupuestoDeVentasXLS(List<PresupuestoDeVentasXLSE> oListaPresupuestoDeVentas, String Usuario);

        [OperationContract]
        Int32 EliminarPresupuestoDeVentasXLS(List<PresupuestoDeVentasXLSE> oListaPorEliminar);


        #endregion

        #region IRentabilidad Members JOSE SALAZAR

        [OperationContract]
        List<RentabilidadE> ListarReporteRentabilidadPorProducto(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda);

        #endregion

        #region IRegistroVentasReportes Members JOSE SALAZAR

        [OperationContract]
        List<RegistroVentasReporteE> ReporteRegistroVentas(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Int32 idVendedor, Int32 idCliente, String idMoneda);

        #endregion

        #region ISalesPoint Members JOSE SALAZAR

        [OperationContract]
        SalesPointE InsertarSalesPoint(SalesPointE salespoint);

        [OperationContract]
        SalesPointE ActualizarSalesPoint(SalesPointE salespoint);

        [OperationContract]
        int EliminarSalesPoint(Int32 IdSalesPoint);

        [OperationContract]
        List<SalesPointE> ListarSalesPoint();

        [OperationContract]
        SalesPointE ObtenerSalesPoint(Int32 IdSalesPoint);

        [OperationContract]
        SalesPointE CargarSalesPoint(string Host);

        #endregion

    }
}
