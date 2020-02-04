using System;
using System.Collections.Generic;
using System.ServiceModel;

using Infraestructura.Enumerados;
using Entidades.Almacen;

namespace ContratoWCF
{
    [ServiceContract]
    public interface IAlmacen
    {

        #region IAlmacen Members JOSE SALAZAR

        [OperationContract]
        AlmacenE InsertarAlmacen(AlmacenE almacen);

        [OperationContract]
        AlmacenE ActualizarAlmacen(AlmacenE almacen);

        [OperationContract]
        List<AlmacenE> ListarAlmacen(Int32 idEmpresa, String desAlmacen, Int32 tipAlmacen, Boolean Activo, Boolean Inactivo);

        [OperationContract]
        List<AlmacenE> ListarAlmacenPorUsuario(Int32 idEmpresa, Int32 idPersona);

        [OperationContract]
        List<AlmacenE> ListarAlmacenPorEmpresa(Int32 idEmpresa);

        [OperationContract]
        Int32 AnularAlmacen(Int32 idEmpresa, Int32 idAlmacen);

        [OperationContract]
        AlmacenE ObtenerAlmacen(Int32 idEmpresa, Int32 idAlmacen);

        [OperationContract]
        List<AlmacenE> ListarAlmacenPorClase(Int32 idEmpresa, Int32 Clase);

        [OperationContract]
        List<AlmacenE> ListarAlmacenCombo(Int32 idEmpresa, Int32 tipAlmacen);

        [OperationContract]
        Int32 VerificaMovAlmacen(Int32 idEmpresa, Int32 idAlmacen);

        [OperationContract]
        List<AlmacenE> ListarAlmacenPorDireccion(Int32 idEmpresa);

        [OperationContract]
        AlmacenE ObtenerSiglaLoteAlmacen(Int32 idEmpresa, Int32 idAlmacen);

        [OperationContract]
        Int32 InsertarAlmacenesMasivo(List<AlmacenE> ListaAlmacenes);

        #endregion

        #region IMovimiento_Almacen Members JOSE SALAZAR

        [OperationContract]
        MovimientoAlmacenE GuardarMovimientoAlmacen(MovimientoAlmacenE mov_almacen, EnumOpcionGrabar Opcion, OrdenCompraE OcCompleta = null);

        [OperationContract]
        Int32 EliminarMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen);

        [OperationContract]
        Int32 AnularMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, String UsuarioAnula);

        [OperationContract]
        List<MovimientoAlmacenE> ListarMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, string desde, string hasta, Int32 idconcepto, Boolean IncluirAnulados);

        [OperationContract]
        List<MovimientoAlmacenE> ListarMovimientoAlmacenPorArticulo(Int32 idEmpresa, Int32 idArticulo);

        [OperationContract]
        List<MovimientoAlmacenE> ListarMovEgresosPorAsociar(Int32 idEmpresa, Int32 tipMovimiento , Int32 idAlmacen);

        [OperationContract]
        MovimientoAlmacenE ObtenerMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen);

        [OperationContract]
        List<MovimientoAlmacenE> ObtenerMovAlmacenporID(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idAlmacen);

        [OperationContract]
        MovimientoAlmacenE ObtenerMovimientoAlmacenCompleto(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Boolean ConUnidadMed = false, String RevisarSalidas = "N");

        [OperationContract]
        List<MovimientoAlmacenE> ListarIngresosCompraPendiente(Int32 idEmpresa, String CodMoneda);

        [OperationContract]
        List<MovimientoAlmacenE> ListarMovimientosPorOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra, String ConDetalle = "N");

        [OperationContract]
        Boolean GenerarHojaCostos(MovimientoAlmacenE movAlmacenCab, Int32 idLocal, String Usuario);

        [OperationContract]
        MovimientoAlmacenE ActualizarMovimientoTrans(MovimientoAlmacenE movimientoalmacen);

        [OperationContract]
        List<MovimientoAlmacenE> GenerarAperturaAlmacen(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, string FechaIngreso, String Usuario);

        [OperationContract]
        void ProcesoGenerarSalidaAlmacen(Int32 idEmpresa, Int32 TipoArticulo, String idCCosto, string vd_desde, string vd_hasta);

        [OperationContract]
        List<MovimientoAlmacenE> MovimientoAlmacenPorTipArticulo(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, Int32 tipArticulo, Int32 idOperacion, string fecIni, string fecFin);

        #region Procedimientos para la importacion de movimientos XLS

        [OperationContract]
        List<MovimientoAlmacenXLSE> InsertarMovimientoAlmacenXLS(List<MovimientoAlmacenXLSE> oListaMovimientos);

        [OperationContract]
        Int32 EliminarMovimientoAlmacenXLS(Int32 idEmpresa, Int32 idUsuario);

        [OperationContract]
        Int32 ProcesarMovimientoAlmacenXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario);

        [OperationContract]
        Int32 IntegrarMovimientoAlmacenXLS(List<MovimientoAlmacenXLSE> ListaMovimientos, String Usuario);

        [OperationContract]
        List<kardexE> RevisarLotesKardexXLS(List<MovimientoAlmacenXLSE> ListaMovimientos);

        [OperationContract]
        Int32 EliminarLotesKardexXLS(List<kardexE> ListaMovimientos);

        #endregion

        #endregion

        #region IPeriodosAlm Members JOSE SALAZAR

        [OperationContract]
        List<PeriodosAlmE> GrabarPeriodosAlm(List<PeriodosAlmE> listaperiodo);

        [OperationContract]
        List<PeriodosAlmE> ListarPeriodosAlm(Int32 idEmpresa, String AnioPeriodo);

        [OperationContract]
        Int32 EliminarPeriodosAlm(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        PeriodosAlmE ObtenerPeriodoPorMesAlm(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        #endregion

        #region IMovimiento_Almacen_Item Members JOSE SALAZAR

        [OperationContract]
        MovimientoAlmacenItemE InsertarMovimiento_Almacen_Item(MovimientoAlmacenItemE item);

        [OperationContract]
        MovimientoAlmacenItemE ActualizarMovimiento_Almacen_Item(MovimientoAlmacenItemE item);

        [OperationContract]
        Int32 EliminarMovimiento_Almacen_Item(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem);

        [OperationContract]
        List<MovimientoAlmacenItemE> ListarMovimiento_Almacen_Item(Int32 idEmpresa, Int32 idDocumentoAlmacen);

        [OperationContract]
        MovimientoAlmacenItemE ObtenerMovimiento_Almacen_Item(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem);

        [OperationContract]
        MovimientoAlmacenItemE ObtenerMovimiento_Almacen_ItemLote(Int32 idEmpresa, Int32 idOrdenCompra, Int32 idItemCompra, String idDocumento, String serDocumento, String numDocumento);
        
        [OperationContract]
        MovimientoAlmacenItemE ActualizarLoteMovAlmacen(MovimientoAlmacenItemE item);

        //[OperationContract]
        //List<Movimiento_Almacen_ItemE> ListarIngresos_Compra_Pendiente(Int32 idEmpresa, String CodMoneda);

        #endregion  

        #region ICorrelativo Members JOSE SALAZAR

        [OperationContract]
        CorrelativoE InsertarCorrelativo(CorrelativoE correlativo);

        [OperationContract]
        CorrelativoE ActualizarCorrelativo(CorrelativoE correlativo);

        [OperationContract]
        Int32 EliminarCorrelativo(Int32 idEmpresa, Int32 idCorrelativo);

        [OperationContract]
        List<CorrelativoE> ListarCorrelativo();

        [OperationContract]
        CorrelativoE ObtenerCorrelativo(Int32 idEmpresa, Int32 idCorrelativo);

        #endregion  

        #region IOperacion Members JOSE SALAZAR

        [OperationContract]
        OperacionE InsertarOperacion(OperacionE operacion);

        [OperationContract]
        OperacionE ActualizarOperacion(OperacionE operacion);

        [OperationContract]
        Int32 EliminarOperacion(Int32 idEmpresa, Int32 idOperacion, Int32 tipAlmacen, Int32 idTipoDocumento);

        [OperationContract]
        List<OperacionE> ListarOperacion(Int32 idEmpresa);

        [OperationContract]
        List<OperacionE> ListarEmpresaOperacion(Int32 idEmpresa , Int32 TipAlmacen);

        [OperationContract]
        List<OperacionE> ListarOperacionPorTipoArticulo(Int32 tipAlmacen, Int32 idEmpresa, Int32 tipMovimiento);

        [OperationContract]
        List<OperacionE> ListarOperacionporTipoMovimiento(String pstr_filtro, Int32 idEmpresa, Int32 tipMovimiento);

        [OperationContract]
        OperacionE ObtenerOperacion(Int32 pi_idEmpresa, Int32 pi_idOperacion);

        [OperationContract]
        Int32 InsertarOperacionesMasiva(List<OperacionE> ListaOpe);

        #endregion        

        #region IOrdenCompra Members JOSE SALAZAR

        [OperationContract]
        OrdenCompraE GrabarOrdenDeCompra(OrdenCompraE OC, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        OrdenCompraE InsertarOrdenCompra(OrdenCompraE ordencompra);

        [OperationContract]
        OrdenCompraE ActualizarOrdenCompra(OrdenCompraE ordencompra);

        [OperationContract]
        Int32 EliminarOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        List<OrdenCompraE> ListarOrdenCompra(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, String desProveedor, String TipoOrdenCompra);

        [OperationContract]
        List<OrdenCompraE> ListarOrdenCompraActivos(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, String desProveedor, String tipEstado);
        
        [OperationContract]
        OrdenCompraE ActivarOrdenCompraActivos(OrdenCompraE ordencompra);

        [OperationContract]
        OrdenCompraE ObtenerOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        OrdenCompraE ObtenerOrdenDeCompraCompleto(Int32 idEmpresa, Int32 idOrdenCompra, String VieneAlmacen = "N");

        [OperationContract]
        List<OrdenCompraE> ListarOCPendientes(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Filtro, string Tipo = "N");

        [OperationContract]
        List<OrdenCompraE> ListarOrdenCompraPendientes(Int32 idEmpresa, Int32 tipo, Int32 idPersona);

        [OperationContract]
        List<OrdenCompraE> OrdenCompraPorNotaIngreso(Int32 idEmpresa, String numVerPlanCuentas, string fecIni, string fecFin);

        #endregion        

        #region IOrdenCompraItem Members JOSE SALAZAR

        [OperationContract]
        OrdenCompraItemE InsertarOrdenCompraItem(OrdenCompraItemE ordencompraitem);

        [OperationContract]
        OrdenCompraItemE ActualizarOrdenCompraItem(OrdenCompraItemE ordencompraitem);

        [OperationContract]
        Int32 EliminarOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        List<OrdenCompraItemE> ListarOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        OrdenCompraItemE ObtenerOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra, Int32 idItem);

        #endregion

        #region IStocks Members JOSE SALAZAR

        [OperationContract]
        List<StockE> ListarReporteStockMensual(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta);

        [OperationContract]
        List<StockE> ListarReporteStockMensualMuestra(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta);

        [OperationContract]
        List<StockE> ListarReporteStockMensualSL(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta);

        [OperationContract]
        List<StockE> ListarStockArticulo(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, Boolean conLote, string codArticulo, string desArticulo, String EsCotizacion);

        [OperationContract]
        List<StockE> ListarStockArticuloRequeri(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, Boolean conLote, string codArticulo, string desArticulo);

        [OperationContract]
        List<StockE> StockPorIdArticulo(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, Int32 idArticulo, String Anio, String Mes, Boolean conLote);

        #endregion

        #region Ikardex Members JOSE SALAZAR

        [OperationContract]
        kardexE Insertarkardex(kardexE kardex);

        [OperationContract]
        kardexE Actualizarkardex(kardexE kardex);

        [OperationContract]
        int Eliminarkardex(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem);

        [OperationContract]
        List<kardexE> Listarkardex(Int32 idEmpresa);

        [OperationContract]
        List<kardexE> Listarkardex2(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, Int32 idOperacion, DateTime Inicio, DateTime Fin);

        [OperationContract]
        kardexE Obtenerkardex(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem);

        [OperationContract] //JOSE SALAZAR
        List<kardexE> KardexVsSaldo(Int32 idEmpresa, String Anio, String Mes);

        [OperationContract] //JOSE SALAZAR
        List<kardexE> KardexPorTipArticulo(Int32 idEmpresa, String Anio, String MesInicio, String Mes, Int32 tipArticulo, Int32 idAlmacen);

        [OperationContract]
        List<kardexE> ListarTransferencia(Int32 idEmpresa, Int32 idTipoArticulo, string Inicio, string Fin);

        [OperationContract] 
        List<kardexE> KardexConsistencia(Int32 idEmpresa, String Anio, String MesInicio, String Mes, Int32 tipArticulo, Int32 idAlmacen);

        #endregion 

        #region ILote Members JOSE SALAZAR

        [OperationContract]
        LoteE InsertarLote(LoteE Lote);

        [OperationContract]
        LoteE ActualizarLote(LoteE Lote);

        [OperationContract]
        int EliminarLote(Int32 idEmpresa, String Lote);

        [OperationContract]
        List<LoteE> ListarLote();

        [OperationContract]
        LoteE ObtenerLote(Int32 idEmpresa, String Lote,Int32 idAlmacen);

        [OperationContract]
        LoteE ObtenerPorLote( String Lote, Int32 idAlmacen);

        [OperationContract]
        String ObtenerMaxLoteAlmacen(Int32 idEmpresa);

        [OperationContract]
        String ObtenerMaxLoteAlmacenInterno(Int32 idEmpresa);

        [OperationContract]
        LoteE BuscarLoteExistente(Int32 idEmpresa, String Lote);

        #endregion 

        #region IAlmacenArticuloLote Members JOSE SALAZAR

        [OperationContract]
        AlmacenArticuloLoteE InsertarAlmacenArticuloLote(AlmacenArticuloLoteE almacenarticulolote);

        [OperationContract]
        AlmacenArticuloLoteE ActualizarAlmacenArticuloLote(AlmacenArticuloLoteE almacenarticulolote);

        [OperationContract]
        int EliminarAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo, String Lote);

        [OperationContract]
        List<AlmacenArticuloLoteE> ListarAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo);

        [OperationContract]
        AlmacenArticuloLoteE ObtenerAlmacenArticuloLote(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen, Int32 idArticulo, String Lote);

        [OperationContract]
        List<AlmacenArticuloLoteE> ListarReporteStockSLPorTipoArticulo(Int32 idEmpresa, Int32 TipoArticulo, String Anio, String Mes, Int32 indCorte, string fechaHasta);

        [OperationContract] //JOSE SALAZAR
        List<AlmacenArticuloLoteE> AlmacenArticuloVsSaldos(Int32 idEmpresa, String Anio, String Mes);

        #endregion

        #region IKardexValorizado Members JOSE SALAZAR

        [OperationContract]
        List<KardexValorizadoE> ListarKardexValorizado(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin);

        [OperationContract]
        List<KardexValorizadoE> ListarKardexValorizadoFilt(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin, Int32 idArticulo, String idMoneda, Int32 idTipoArticulo);

        [OperationContract]
        List<KardexValorizadoE> ListarKardexValorizadoFiltPorLote(Int32 idEmpresa, Int32 idAlmacen, string Inicio, string Fin, Int32 idArticulo,String Lote, String LoteAlmacen, Int32 idTipoArticulo);

        #endregion

        #region IOrdenConversion Members JOSE SALAZAR

        [OperationContract]
        OrdenConversionE GrabarConversion(OrdenConversionE OrdenConversion, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        OrdenConversionE GeneraSalidaAlmacenPorConversion(OrdenConversionE ordenconversion, String Usuario);

        [OperationContract]
        OrdenConversionE GeneraIngresoAlmacenPorConversion(OrdenConversionE ordenconversion, String Usuario);

        [OperationContract]
        OrdenConversionE InsertarOrdenConversion(OrdenConversionE ordenconversion);

        [OperationContract]
        OrdenConversionE ActualizarOrdenConversion(OrdenConversionE ordenconversion);

        [OperationContract]
        int EliminarOrdenConversion(Int32 idEmpresa, Int32 idOrdenConversion);

        [OperationContract]
        List<OrdenConversionE> ListarOrdenConversion(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin, Int32 idConcepto, Int32 idArticulo, String desArticulo, String tipFecha);

        [OperationContract]
        OrdenConversionE ObtenerOrdenConversion(Int32 idEmpresa, Int32 idOrdenConversion);

        [OperationContract]
        OrdenConversionE ObtenerOrdenConversionCompleta(Int32 idEmpresa, Int32 idOrdenConversion);

        [OperationContract]
        String GenerarNroConversion(int idEmpresa, DateTime Fecha);

        [OperationContract]
        OrdenConversionE AnularSalAlmacenPorConversion(OrdenConversionE oOrdenConversion, String Usuario);

        [OperationContract]
        OrdenConversionE AnularIngAlmacenPorConversion(OrdenConversionE DetalleConversion, string Usuario);

        [OperationContract]
        Int32 ActualizarCostosAlmacen(OrdenConversionE ordenconversion);

        [OperationContract]
        List<OrdenConversionE> ListarOrdenConversionProvision(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin);

        #endregion   

        #region IOrdenConversionDetalle Members JOSE SALAZAR

        [OperationContract]
        OrdenConversionDetalleE InsertarOrdenConversionDetalle(OrdenConversionDetalleE ordenconversiondetalle);

        [OperationContract]
        OrdenConversionDetalleE ActualizarOrdenConversionDetalle(OrdenConversionDetalleE ordenconversiondetalle);

        [OperationContract]
        int EliminarOrdenConversionDetalle(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item);

        [OperationContract]
        List<OrdenConversionDetalleE> ListarOrdenConversionDetalle(Int32 idEmpresa, Int32 idOrdenConversion);

        [OperationContract]
        OrdenConversionDetalleE ObtenerOrdenConversionDetalle(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item);

        [OperationContract]
        OrdenConversionDetalleE ActualizarLoteOrdenConversion(OrdenConversionDetalleE item);

        #endregion

        #region IValorizacionAlamcen Members JOSE SALAZAR

        [OperationContract]
        int ValorizaciondeAlmacen(Int32 idEmpresa, Int32 idAlmacen, Int32 idArticulo, String AnioInicio, String MesInicio, String AnioFin, String MesFin, String ValConversion);

        [OperationContract]
        int PasarStock(Int32 idEmpresa, String AnioInicio, String MesInicio, String AnioFin, String MesFin);

        #endregion

        #region IHojaCosto Members JOSE SALAZAR

        [OperationContract]
        HojaCostoE GrabarHojaCosto(HojaCostoE ListaHojaCosto, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        HojaCostoE InsertarHojaCosto(HojaCostoE hojacosto);

        [OperationContract]
        HojaCostoE ActualizarHojaCosto(HojaCostoE hojacosto);

        [OperationContract]
        int EliminarHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        List<HojaCostoE> ListarHojaCosto(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin);

        [OperationContract]
        List<HojaCostoE> ReporteHojaCosto(Int32 idEmpresa, string FechaInicio, string FechaFin, String DesProveedor, String codArticulo, String nomArticulo);

        [OperationContract]
        HojaCostoE ObtenerHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        HojaCostoE RecuperarHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        int ActualizarEstadoHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra, String Estado, String UsuarioModificacion);

        #endregion

        #region IHojaCostoAlmacen Members JOSE SALAZAR

        [OperationContract]
        HojaCostoAlmacenE InsertarHojaCostoAlmacen(HojaCostoAlmacenE hojacostoalmacen);

        [OperationContract]
        HojaCostoAlmacenE ActualizarHojaCostoAlmacen(HojaCostoAlmacenE hojacostoalmacen);

        [OperationContract]
        int EliminarHojaCostoAlmacen(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 tipMovimiento, Int32 idDocumentoAlmacen);

        [OperationContract]
        List<HojaCostoAlmacenE> ListarHojaCostoAlmacen();

        [OperationContract]
        HojaCostoAlmacenE ObtenerHojaCostoAlmacen(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 tipMovimiento, Int32 idDocumentoAlmacen);

        #endregion

        #region IHojaCostoItem Members JOSE SALAZAR

        [OperationContract]
        HojaCostoItemE InsertarHojaCostoItem(HojaCostoItemE hojacostoitem);

        [OperationContract]
        HojaCostoItemE ActualizarHojaCostoItem(HojaCostoItemE hojacostoitem);

        [OperationContract]
        int EliminarHojaCostoItem(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        List<HojaCostoItemE> ListarHojaCostoItem(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        HojaCostoItemE ObtenerHojaCostoItem(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 item);

        #endregion

        #region IHojaCostoOC Members JOSE SALAZAR

        [OperationContract]
        HojaCostoOCE InsertarHojaCostoOC(HojaCostoOCE hojacostooc);

        [OperationContract]
        HojaCostoOCE ActualizarHojaCostoOC(HojaCostoOCE hojacostooc);

        [OperationContract]
        int EliminarHojaCostoOC(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra);

        [OperationContract]
        List<HojaCostoOCE> ListarHojaCostoOC(Int32 idEmpresa);

        [OperationContract]
        HojaCostoOCE ObtenerHojaCostoOC(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra);

        #endregion

        #region IGastosImportacion Members JOSE SALAZAR

        [OperationContract]
        GastosImportacionE InsertarGastosImportacion(GastosImportacionE gastosimportacion);

        [OperationContract]
        GastosImportacionE ActualizarGastosImportacion(GastosImportacionE gastosimportacion);

        [OperationContract]
        int EliminarGastosImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 item);

        [OperationContract]
        List<GastosImportacionE> ListarGastosImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        List<GastosImportacionE> ListarGastosImportacionPorHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto);

        [OperationContract]
        GastosImportacionE ObtenerGastosImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 item);

        #endregion

        #region IRequisicion Members JOSE SALAZAR

        [OperationContract]
        RequisicionE GrabarRequisicion(RequisicionE ListaRequisicion, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        RequisicionE InsertarRequisicion(RequisicionE requisicion);

        [OperationContract]
        RequisicionE ActualizarRequisicion(RequisicionE requisicion);

        [OperationContract]
        int EliminarRequisicion(Int32 idEmpresa, Int32 idRequisicion);

        [OperationContract]
        List<RequisicionE> ListarRequisicion(Int32 idEmpresa,Int32 idLocal, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        List<RequisicionE> ListarRequisicionAprobacion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String tipEstado);

        [OperationContract]
        RequisicionE ObtenerRequisicion(Int32 idEmpresa, Int32 idRequisicion);


        [OperationContract]
        RequisicionE ActivarRequisicion(RequisicionE requisicion);

        [OperationContract]
        List<RequisicionE> ListarRequisicionPendientes(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String Filtro);

        [OperationContract]
        Int32 GenerarNroRequisicion(Int32 idEmpresa, Int32 idLocal, DateTime FechaSolicitud);

        #endregion

        #region IRequisicionItem Members JOSE SALAZAR

        [OperationContract]
        RequisicionItemE InsertarRequisicionItem(RequisicionItemE requisicionitem);

        [OperationContract]
        RequisicionItemE ActualizarRequisicionItem(RequisicionItemE requisicionitem);

        [OperationContract]
        int EliminarRequisicionItem(Int32 idEmpresa, Int32 idRequisicion, Int32 idItem);

        [OperationContract]
        List<RequisicionItemE> ListarRequisicionItem(Int32 idEmpresa, Int32 idRequisicion);

        [OperationContract]
        RequisicionItemE ObtenerRequisicionItem(Int32 idEmpresa, Int32 idRequisicion, Int32 idItem);

        #endregion

        #region IRequisicionProveedor Members JOSE SALAZAR   

        [OperationContract]
        RequisicionProveedorE InsertarRequisicionProveedor(RequisicionProveedorE requisicionproveedor);

        [OperationContract]
        RequisicionProveedorE ActualizarRequisicionProveedor(RequisicionProveedorE requisicionproveedor);

        [OperationContract]
        int EliminarRequisicionProveedor(Int32 idEmpresa, Int32 idRequisicion, Int32 idPersona);

        [OperationContract]
        List<RequisicionProveedorE> ListarRequisicionProveedor(Int32 idEmpresa, Int32 idRequisicion);

        [OperationContract]
        RequisicionProveedorE ObtenerRequisicionProveedor(Int32 idEmpresa, Int32 idRequisicion, Int32 idPersona);

        #endregion

        #region IOrdenCompraParam Members JOSE SALAZAR

        [OperationContract]
        OrdenCompraParametrosE InsertarOrdenCompraParam(OrdenCompraParametrosE ordencompraparam);

        [OperationContract]
        OrdenCompraParametrosE ActualizarOrdenCompraParam(OrdenCompraParametrosE ordencompraparam);

        [OperationContract]
        OrdenCompraParametrosE ObtenerOrdenCompraParam(Int32 idEmpresa);

        #endregion

        #region IOrdenCompraDistri Members JOSE SALAZAR

        [OperationContract]
        OrdenCompraDistriE InsertarOrdenCompraDistri(OrdenCompraDistriE ordencompradistri);

        [OperationContract]
        OrdenCompraDistriE ActualizarOrdenCompraDistri(OrdenCompraDistriE ordencompradistri);

        [OperationContract]
        int EliminarOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        List<OrdenCompraDistriE> ListarOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        OrdenCompraDistriE ObtenerOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra, String idCCostos);

        #endregion

        #region IConceptosVarios Members JOSE SALAZAR

        [OperationContract]
        ConceptosVariosE InsertarConceptosVarios(ConceptosVariosE conceptosvarios);

        [OperationContract]
        ConceptosVariosE ActualizarConceptosVarios(ConceptosVariosE conceptosvarios);

        [OperationContract]
        int EliminarConceptosVarios(Int32 idConcepto);

        [OperationContract]
        List<ConceptosVariosE> ListarConceptosVarios(Int32 idEmpresa, Int32 Tipo);

        [OperationContract]
        ConceptosVariosE ObtenerConceptosVarios(Int32 idConcepto, Int32 idEmpresa);

        [OperationContract]
        List<ConceptosVariosE> ConceptosVariosBusqueda(Int32 Tipo, Int32 idEmpresa,String Descripcion, Boolean indConceptoLiqui);

        [OperationContract]
        ConceptosVariosE RecuperarConceptosVarios(Int32 idConcepto, Int32 idEmpresa, Boolean indConceptoLiqui);

        [OperationContract]
        List<ConceptosVariosE> ConceptosVariosTesoreria(Int32 Tipo, Int32 idEmpresa, String Descripcion);

        [OperationContract]
        List<ConceptosVariosE> ConceptosVariosCobranzas(Int32 idEmpresa);

        [OperationContract]
        List<ConceptosVariosE> ListarEmpresaConceptosVarios(Int32 idEmpresa);

        [OperationContract]
        Int32 CopiarConceptosVarios(Int32 idEmpresaDe, Int32 idEmpresaA, String UsuarioRegistro);

        [OperationContract]
        ConceptosVariosE RecuperarCuentasMovilidad(Int32 idEmpresa);

        [OperationContract]
        List<ConceptosVariosE> ConceptosVariosPlanillas(Int32 idEmpresa);

        [OperationContract]
        List<ConceptosVariosE> ConceptosVariosCompras(Int32 Tipo, Int32 idEmpresa, String Descripcion, Boolean indConceptoLiqui);

        #endregion

        #region IRequerimientos Members JOSE SALAZAR

        [OperationContract]
        RequerimientosE GrabarRequerimiento(RequerimientosE Requerimiento, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        RequerimientosE InsertarRequerimientos(RequerimientosE requerimientos);

        [OperationContract]
        RequerimientosE ActualizarRequerimientos(RequerimientosE requerimientos);

        [OperationContract]
        int EliminarRequerimientos(Int32 idRequerimiento);

        [OperationContract]
        List<RequerimientosE> ListarRequerimientos(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Int32 idAlmacen, String idCCostos, String indEstado);

        [OperationContract]
        RequerimientosE ObtenerRequerimientos(Int32 idRequerimiento);

        [OperationContract]
        RequerimientosE RecuperarRequerimiento(Int32 idRequerimiento);

        #endregion

        #region IRequerimientosItem Members JOSE SALAZAR

        [OperationContract]
        RequerimientosItemE InsertarRequerimientosItem(RequerimientosItemE requerimientositem);

        [OperationContract]
        RequerimientosItemE ActualizarRequerimientosItem(RequerimientosItemE requerimientositem);

        [OperationContract]
        int EliminarRequerimientosItem(Int32 idRequerimiento, Int32 Item);

        [OperationContract]
        List<RequerimientosItemE> ListarRequerimientosItem(Int32 idRequerimiento);

        [OperationContract]
        RequerimientosItemE ObtenerRequerimientosItem(Int32 idRequerimiento, Int32 Item);

        #endregion

        #region IRequerimientoPuntos Members JOSE SALAZAR

        [OperationContract]
        RequerimientoPuntosE InsertarRequerimientoPuntos(RequerimientoPuntosE requerimientopuntos);

        [OperationContract]
        RequerimientoPuntosE ActualizarRequerimientoPuntos(RequerimientoPuntosE requerimientopuntos);

        [OperationContract]
        int EliminarRequerimientoPuntos(Int32 idPuntoReq);

        [OperationContract]
        List<RequerimientoPuntosE> ListarRequerimientoPuntos(Int32 idEmpresa);

        [OperationContract]
        RequerimientoPuntosE ObtenerRequerimientoPuntos(Int32 idPuntoReq);

        #endregion

        #region IOrdenConversionSalida Members JOSE SALAZAR

        [OperationContract]
        OrdenConversionSalidaE InsertarOrdenConversionSalida(OrdenConversionSalidaE ordenconversionsalida);

        [OperationContract]
        OrdenConversionSalidaE ActualizarOrdenConversionSalida(OrdenConversionSalidaE ordenconversionsalida);

        [OperationContract]
        int EliminarOrdenConversionSalida(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item);

        [OperationContract]
        List<OrdenConversionSalidaE> ListarOrdenConversionSalida(Int32 idEmpresa, Int32 idOrdenConversion);

        [OperationContract]
        OrdenConversionSalidaE ObtenerOrdenConversionSalida(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item);

        #endregion

        #region IArticuloPrecio Members JOSE SALAZAR

        [OperationContract]
        ArticuloPrecioE InsertarArticuloPrecio(ArticuloPrecioE articuloprecio);

        [OperationContract]
        ArticuloPrecioE ActualizarArticuloPrecio(ArticuloPrecioE articuloprecio);

        [OperationContract]
        int EliminarArticuloPrecio(Int32 idEmpresa, Int32 idArticulo);

        [OperationContract]
        List<ArticuloPrecioE> ListarArticuloPrecio(Int32 idEmpresa);

        [OperationContract]
        ArticuloPrecioE ObtenerArticuloPrecio(Int32 idEmpresa, Int32 idArticulo);

        #endregion

        #region IkardexXLS Members JOSE SALAZAR

        [OperationContract]
        Int32 InsertarkardexXLS(List<kardexXLSE> oListaKardexXLS);

        //[OperationContract]
        //Int32 ErroresInsertarkardexXLS(List<kardexXLSE> oListaErrores);

        [OperationContract]
        Int32 IntegrarKardexXLS(List<kardexXLSE> oListaKardexXLS, String Usuario, String Plan);

        [OperationContract]
        Int32 EliminarKardexXLS(List<kardexXLSE> oListaPorEliminar);

        #endregion

        #region IOrdenConversionGastos Members JOSE SALAZAR

        [OperationContract]
        OrdenConversionGastosE InsertarOrdenConversionGastos(OrdenConversionGastosE ordenconversiongastos);

        [OperationContract]
        OrdenConversionGastosE ActualizarOrdenConversionGastos(OrdenConversionGastosE ordenconversiongastos);

        [OperationContract]
        int EliminarOrdenConversionGastos(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item);

        [OperationContract]
        List<OrdenConversionGastosE> ListarOrdenConversionGastos(Int32 idOrdenConversion);

        [OperationContract]
        OrdenConversionGastosE ObtenerOrdenConversionGastos(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item);

        [OperationContract]
        List<OrdenConversionGastosE> ListarGastosConversion(Int32 idEmpresa, Int32 idOrdenConversion);

        #endregion

    }
}
