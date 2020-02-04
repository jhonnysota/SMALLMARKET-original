using System;
using System.Collections.Generic;
using System.ServiceModel;

using Entidades.Tesoreria;
using Entidades.Ventas;
using Entidades.CtasPorPagar;
using Infraestructura.Enumerados;

namespace ContratoWCF
{
    [ServiceContract]
    public interface ITesoreria
    {

        #region ICtaCte Members JOSE SALAZAR

        [OperationContract]
        CtaCteE InsertarMaeCtaCte(CtaCteE ctacte);

        [OperationContract]
        CtaCteE ActualizarMaeCtaCte(CtaCteE ctacte);

        [OperationContract]
        List<CtaCteE> ListarMaeCtaCte();

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCtePorParametros(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCteResumen(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCteDetallado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<CtaCteE> MaeCtaCteDetalladoVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema, Boolean Historico);

        [OperationContract]
        List<CtaCteE> ConsultaMaeCtaCteDet(Int32 idEmpresa, Int32 IdPersona, DateTime fecFiltro, String Opcion, Boolean EsDetraccion);

        [OperationContract]
        List<CtaCteE> ConsultaMaeCtaCteDetVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String Tipo);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCtePorCuenta(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCteGeneral(Int32 idEmpresa, string filtro, DateTime fecFiltro);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCteDetalladoPorId(Int32 idEmpresa, Int32 idCtaCte, DateTime fecFiltro);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCtePartida(Int32 idEmpresa, string filtro, DateTime fecFiltro);

        [OperationContract]
        Int32 EliminarCtaCteMasivo(Int32 idEmpresa, Int32 idSistema, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        Int32 TransferirCtaCte(List<ProvisionesE> oListaCompras, List<EmisionDocumentoE> oListaVentas, Int32 idSistema, String Usuario);

        [OperationContract]
        CtaCteE ObtenerMaeCtaCtePorDocumento(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        List<CtaCteE> ObtenerMaeCtaCteLetras(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<CtaCteE> ListarReporteCtaCteComparado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String TipoBuscar);

        [OperationContract]
        List<CtaCteE> CtaCteDetalladoVentas2(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<CtaCteE> ObtenerCtaCtePorEstadosLetras(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        List<CtaCteE> ConsultaCtaCteRRHH(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro);

        [OperationContract]
        List<CtaCteE> ConsultaMaeCtaCteLiquidacion(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro);

        #endregion

        #region ICtaCte_Det Members JOSE SALAZAR

        [OperationContract]
        CtaCte_DetE InsertarMaeCtaCteDet(CtaCte_DetE ctacte_det);

        [OperationContract]
        CtaCte_DetE ActualizarMaeCtaCteDet(CtaCte_DetE ctacte_det);

        [OperationContract]
        CtaCte_DetE ObtenerMaeCtaCteDet(Int32 idEmpresa, String numAnio, String numMes, Int32 IdPersona, String idDocumento, String NumSerie, String NumDocumento, String idDocumentoOrig, String NumSerieOrig, String NumDocOrig);

        [OperationContract]
        List<CtaCte_DetE> ListarMaeCtaCteDet(Int32 idEmpresa, Int32 idCtaCte);

        [OperationContract]
        Int32 EliminarMaeCtaCteDetallePorIdItem(Int32 idCtaCteItem);

        [OperationContract]
        Int32 ActualizarMaeCtaCteDetPorIdItem(CtaCte_DetE ctacte_det);

        [OperationContract]
        Int32 RegenerarCtaCte(Int32 idEmpresa, Int32 idPersona, String idDocumentoMov, String SerieMov, String NumeroMov);

        [OperationContract]
        Int32 GenerarCtaCtePorVoucherItem(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem);

        #endregion

        #region ITipoPago Members JOSE SALAZAR

        [OperationContract]
        TipoPagoE GrabarTipoPago(TipoPagoE tipopago, EnumOpcionGrabar Opcion);

        [OperationContract]
        TipoPagoE InsertarTipoPago(TipoPagoE tipopago);

        [OperationContract]
        TipoPagoE ActualizarTipoPago(TipoPagoE tipopago);

        [OperationContract]
        Int32 EliminarTipoPago( String codTipoPago);

        [OperationContract]
        List<TipoPagoE> ListarTipoPago();

        [OperationContract]
        TipoPagoE ObtenerTipoPago(String codTipoPago, Int32 idEmpresa, String ConDetalle = "S");

        [OperationContract]
        List<TipoPagoE> ListarTipoPagoCombo(String indTipo, Int32 idEmpresa = 0);

        #endregion 

        #region IProgramaPago Members JOSE SALAZAR

        [OperationContract]
        void GrabarListaPagos(List<ProgramaPagoE> Lista, List<OrdenPagoE> oListaOP = null, String Usuario = "");

        [OperationContract]
        ProgramaPagoE InsertarProgramaPago(ProgramaPagoE programapago);

        [OperationContract]
        ProgramaPagoE ActualizarProgramaPago(ProgramaPagoE programapago);

        [OperationContract]
        Int32 EliminarProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago, String Usuario);

        [OperationContract]
        Int32 EliminarProgramaPagoMasivo(List<ProgramaPagoE> oListaProgramaPago, String Usuario);

        [OperationContract]
        Int32 AnularTipoPago(String codTipoPago, String UsuarioModificacion);

        [OperationContract]
        List<ProgramaPagoE> ListarProgramaPagos(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Estado, String codFormaPago, Int32 idPersonaBanco, Int32 idPersona);

        [OperationContract]
        ProgramaPagoE ObtenerProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago);

        [OperationContract]
        Int32 MaxGrupoProgramaPagos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime Fecha);

        [OperationContract]
        List<ProgramaPagoE> ListarPagosParaAprobacion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Aprobado);

        [OperationContract]
        void ActualizarProgramaPagoAprobacion(List<ProgramaPagoE> oListaAprobacion);

        [OperationContract]
        void GenerarCheque(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago, DateTime Fecha, Int32 idPersona, String idDocumento, String Usuario, String Estado, String Grupo, String UsuarioActual);

        [OperationContract]
        String GenerarVoucherTesTransferencia(List<ProgramaPagoE> oListaPP, String Usuario, String Estado, String Grupo);

        [OperationContract]
        String CancelarPagos(List<ProgramaPagoE> oListaPP, String UsuarioModificacion);

        [OperationContract]
        Int32 LimpiarVoucherPP(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Grupo, Int32 idNumEgreso, String UsuarioModificacion);

        #endregion        

        #region IFormaPagoCompFile Members JOSE SALAZAR

        [OperationContract]
        FormaPagoCompFileE InsertarFormaPagoCompFile(FormaPagoCompFileE formapagocompfile);

        [OperationContract]
        FormaPagoCompFileE ActualizarFormaPagoCompFile(FormaPagoCompFileE formapagocompfile);

        [OperationContract]
        Int32 EliminarFormaPagoCompFile(Int32 idEmpresa, String codFormaPago, String idMoneda);

        [OperationContract]
        List<FormaPagoCompFileE> ListarFormaPagoCompFile();

        [OperationContract]
        FormaPagoCompFileE ObtenerFormaPagoCompFile(Int32 idEmpresa, String codFormaPago, String idMoneda);

        #endregion

        #region IFormaPago Members JOSE SALAZAR

        [OperationContract]
        FormaPagoE GrabarFormaPago(FormaPagoE oFormaPago, EnumOpcionGrabar Opcion);

        [OperationContract]
        FormaPagoE InsertarFormaPago(FormaPagoE formapago);

        [OperationContract]
        FormaPagoE ActualizarFormaPago(FormaPagoE formapago);

        [OperationContract]
        Int32 EliminarFormaPago(String codFormaPago);

        [OperationContract]
        List<FormaPagoE> ListarFormaPago();

        [OperationContract]
        FormaPagoE ObtenerFormaPago(String codFormaPago, Int32 idEmpresa, String ConDetalle = "S");

        [OperationContract]
        List<FormaPagoE> ListarFormaPagoPorTipo(String codTipoPago, Int32 idConcepto, Int32 idEmpresa);

        #endregion        

        #region IFormaTipoPago Members JOSE SALAZAR

        [OperationContract]
        FormaTipoPagoE InsertarFormaTipoPago(FormaTipoPagoE formatipopago);

        [OperationContract]
        FormaTipoPagoE ActualizarFormaTipoPago(FormaTipoPagoE formatipopago);

        [OperationContract]
        Int32 EliminarFormaTipoPago(String codTipoPago, Int32 idConcepto, String codFormaPago);

        [OperationContract]
        List<FormaTipoPagoE> ListarFormaTipoPago(String codFormaPago, Int32 idEmpresa);

        [OperationContract]
        FormaTipoPagoE ObtenerFormaTipoPago( String codFormaPago, String codTipoPago);

        #endregion        

        #region IEgreso Members JOSE SALAZAR

        [OperationContract]
        EgresoE InsertarEgreso(EgresoE egreso);

        [OperationContract]
        EgresoE ActualizarEgreso(EgresoE egreso);

        [OperationContract]
        Int32 EliminarEgreso(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso);

        [OperationContract]
        List<EgresoE> ListarEgreso();

        [OperationContract]
        EgresoE ObtenerEgreso(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso);

        [OperationContract]
        List<EgresoE> ListarEgresosProgramaPago(Int32 idEmpresa, Int32 Banco, DateTime Desde, DateTime Hasta);

        #endregion

        #region IEgresoItem Members JOSE SALAZAR

        [OperationContract]
        EgresoItemE InsertarEgresoItem(EgresoItemE egresoitem);

        [OperationContract]
        EgresoItemE ActualizarEgresoItem(EgresoItemE egresoitem);

        [OperationContract]
        Int32 EliminarEgresoItem(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso, Int32 NumItem);

        [OperationContract]
        List<EgresoItemE> ListarEgresoItem();

        [OperationContract]
        EgresoItemE ObtenerEgresoItem(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso, Int32 NumItem);

        #endregion

        #region IAperturaCtaCte Members JOSE SALAZAR

        [OperationContract]
        AperturaCtaCteE InsertarAperturaCtaCte(AperturaCtaCteE aperturactacte);

        [OperationContract]
        AperturaCtaCteE ActualizarAperturaCtaCte(AperturaCtaCteE aperturactacte);

        [OperationContract]
        int EliminarAperturaCtaCte(Int32 idEmpresa, Int32 idRegistro);

        [OperationContract]
        List<AperturaCtaCteE> ListarAperturaCtaCte(Int32 idEmpresa);

        [OperationContract]
        AperturaCtaCteE ObtenerAperturaCtaCte(Int32 idEmpresa, Int32 idRegistro);

        #endregion

        #region IFondoFijo Members JOSE SALAZAR

        [OperationContract]
        FondoFijoE GrabarFondo(FondoFijoE Fondo, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        FondoFijoE InsertarFondoFijo(FondoFijoE fondofijo);

        [OperationContract]
        FondoFijoE ActualizarFondoFijo(FondoFijoE fondofijo);

        [OperationContract]
        int EliminarFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona);

        [OperationContract]
        List<FondoFijoE> ListarFondoFijo(Int32 idEmpresa, Int32 idLocal, String TipoFondo);

        [OperationContract]
        FondoFijoE ObtenerFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona);

        [OperationContract]
        List<FondoFijoE> FondoFijoCuentas(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, Int32 idBanco = 0);

        [OperationContract]
        Int32 FondoFijoPorTipoFondoResp(Int32 idEmpresa, Int32 idLocal, String TipoFondo, Int32 idPersonaResponsable);

        [OperationContract]
        List<FondoFijoE> ListarFondoFijoPorResponsable(Int32 idEmpresa, Int32 idLocal, Int32 idPersonaResponsable);

        #endregion

        #region IOrdenPago Members JOSE SALAZAR

        [OperationContract]
        OrdenPagoE GrabarOrdenPago(OrdenPagoE OP, EnumOpcionGrabar Opcion);

        [OperationContract]
        OrdenPagoE InsertarOrdenPago(OrdenPagoE ordenpago);

        [OperationContract]
        OrdenPagoE ActualizarOrdenPago(OrdenPagoE ordenpago);

        [OperationContract]
        int EliminarOrdenPago(Int32 idOrdenPago);

        [OperationContract]
        int CambiarEstadoOP(Int32 idOrdenPago, String indEstado, String UsuarioModificacion);

        [OperationContract]
        List<OrdenPagoE> ListarOrdenPago(Int32 idEmpresa, Int32 idLocal, String codOrdenPago, DateTime fecIni, DateTime fecFin, String indEstado);

        [OperationContract]
        List<OrdenPagoE> ListarOrdenPagoPorIdPersona(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        OrdenPagoE ObtenerOrdenPago(Int32 idOrdenPago);

        [OperationContract]
        OrdenPagoE ObtenerOrdenPagoCompleto(Int32 idOrdenPago, String Impresion = "N");

        [OperationContract]
        OrdenPagoE OpAbiertosPorIdPersona(Int32 idEmpresa, Int32 idLocal, Int32 idPersona);

        [OperationContract]
        Int32 ObtenerOpProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenPago);

        #endregion

        #region IOrdenPagoDet Members JOSE SALAZAR

        [OperationContract]
        OrdenPagoDetE InsertarOrdenPagoDet(OrdenPagoDetE ordenpagodet);

        [OperationContract]
        OrdenPagoDetE ActualizarOrdenPagoDet(OrdenPagoDetE ordenpagodet);

        [OperationContract]
        int EliminarOrdenPagoDet(Int32 idOrdenPago);

        [OperationContract]
        List<OrdenPagoDetE> ListarOrdenPagoDet(Int32 idOrdenPago);

        [OperationContract]
        OrdenPagoDetE ObtenerOrdenPagoDet(Int32 idOrdenPago, Int32 idOrdenPagoItem);

        [OperationContract] //JOSE SALAZAR
        List<CtaCteE> BuscarDocExistenteOp(Int32 idLocal, Int32 idOrdenPago, List<CtaCteE> ListaConsulta);

        [OperationContract] //JOSE SALAZAR
        OrdenPagoDetE ObtenerOrdenPagoDetPorDocumento(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, String idDocumento, String serDocumento, String numDocumento);

        #endregion

        #region ITipoLineaCredito Members JOSE SALAZAR

        [OperationContract]
        TipoLineaCreditoE InsertarTipoLineaCredito(TipoLineaCreditoE tipolineacredito);

        [OperationContract]
        TipoLineaCreditoE ActualizarTipoLineaCredito(TipoLineaCreditoE tipolineacredito);

        [OperationContract]
        int AnularTipoLineaCredito(Int32 idLinea);

        [OperationContract]
        List<TipoLineaCreditoE> ListarTipoLineaCredito(Boolean indEstado);

        [OperationContract]
        TipoLineaCreditoE ObtenerTipoLineaCredito(Int32 idLinea, Int32 idEmpresa);

        #endregion

        #region IFinanciamiento Members JOSE SALAZAR

        [OperationContract]
        FinanciamientoE InsertarFinanciamiento(FinanciamientoE financiamiento);

        [OperationContract]
        FinanciamientoE ActualizarFinanciamiento(FinanciamientoE financiamiento);

        [OperationContract]
        int AnularFinanciamiento(Int32 idFinanciamiento);

        [OperationContract]
        List<FinanciamientoE> ListarFinanciamiento(Int32 idEmpresa, Int32 idBanco, Int32 idLinea, Boolean indEstado);

        [OperationContract]
        FinanciamientoE ObtenerFinanciamiento(Int32 idFinanciamiento);

        [OperationContract]
        List<FinanciamientoE> ListarBancosFinanciamiento(Int32 idEmpresa);

        [OperationContract]
        List<FinanciamientoE> ListarBancosFinanPorLinea(Int32 idEmpresa, Int32 idLinea);

        #endregion

        #region IMovimientoFinanciamiento Members JOSE SALAZAR

        [OperationContract]
        MovimientoFinanciamientoE GrabarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento, EnumOpcionGrabar Opcion);

        [OperationContract]
        MovimientoFinanciamientoE InsertarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento);

        [OperationContract]
        MovimientoFinanciamientoE ActualizarMovimientoFinanciamiento(MovimientoFinanciamientoE movimientofinanciamiento);

        [OperationContract]
        int EliminarMovimientoFinanciamiento(Int32 idMovimiento);

        [OperationContract]
        List<MovimientoFinanciamientoE> ListarMovimientoFinanciamiento(Int32 idEmpresa, Int32 idLinea, Int32 idBanco, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        MovimientoFinanciamientoE ObtenerMovimientoFinanciamiento(Int32 idMovimiento);

        [OperationContract]
        List<MovimientoFinanciamientoE> ListarMovFinCuentasBan(Int32 idPersona, Int32 idEmpresa, String idMoneda);

        [OperationContract]
        MovimientoFinanciamientoE ObtenerMovFinanciamientoCompleto(Int32 idMovimiento);

        #endregion

        #region IMovimientoFinanciamientoDet Members JOSE SALAZAR

        [OperationContract]
        MovimientoFinanciamientoDetE InsertarMovimientoFinanciamientoDet(MovimientoFinanciamientoDetE movimientofinanciamientodet);

        [OperationContract]
        MovimientoFinanciamientoDetE ActualizarMovimientoFinanciamientoDet(MovimientoFinanciamientoDetE movimientofinanciamientodet);

        [OperationContract]
        int EliminarMovimientoFinanciamientoDet(Int32 idMovimiento, Int32 Item);

        [OperationContract]
        List<MovimientoFinanciamientoDetE> ListarMovimientoFinanciamientoDet(Int32 idMovimiento);

        [OperationContract]
        MovimientoFinanciamientoDetE ObtenerMovimientoFinanciamientoDet(Int32 idMovimiento, Int32 Item);

        #endregion

        #region IMovimientoBancos Members JOSE SALAZAR

        [OperationContract]
        MovimientoBancosE GrabarMovimientoBancos(MovimientoBancosE MovimientoBan, EnumOpcionGrabar Opcion);

        [OperationContract]
        MovimientoBancosE InsertarMovimientoBancos(MovimientoBancosE movimientobancos);

        [OperationContract]
        MovimientoBancosE ActualizarMovimientoBancos(MovimientoBancosE movimientobancos);

        [OperationContract]
        int EliminarMovimientoBancos(Int32 idMovBanco);

        [OperationContract]
        List<MovimientoBancosE> ListarMovimientoBancos(Int32 idEmpresa, Int32 idBanco, Int32 tipMovimiento, DateTime fecIni, DateTime fecFin, String indEstado, Boolean indDevolucion);

        [OperationContract]
        MovimientoBancosE ObtenerMovimientoBancos(Int32 idMovBanco, Boolean ConDetalle = true);

        [OperationContract]
        MovimientoBancosE ActualizarMovBancosConta(MovimientoBancosE movimientobancos);

        [OperationContract]
        String GenerarProvisionMovBancos(MovimientoBancosE movimientobancos, Int32 idLocal, String Usuario);

        [OperationContract]
        Int32 CambiarEstadoMovBancos(MovimientoBancosE MovBanco, String Estado, String Usuario);

        [OperationContract]
        Int32 EliminarVoucherMovBancos(MovimientoBancosE movBanco, Int32 idLocal, String Usuario);

        [OperationContract]
        String ProvisionesMasivasMovBancos(List<MovimientoBancosE> ListaMovimientos, Int32 idLocal, String Usuario);

        [OperationContract]
        Int32 EliminarVoucherMasivoMovBancos(List<MovimientoBancosE> ListaMovBanco, Int32 idLocal, String Usuario);

        [OperationContract]
        Int32 ActualizarMovBancosCtaCte(MovimientoBancosE oMovimientoBanco, String Usuario);

        [OperationContract]
        MovimientoBancosE ActualizarMovimientoBancosDocIngresos(MovimientoBancosE movimientobancos);

        #endregion

        #region IMovimientoBancosDet Members JOSE SALAZAR

        [OperationContract]
        MovimientoBancosDetE InsertarMovimientoBancosDet(MovimientoBancosDetE movimientobancosdet);

        [OperationContract]
        MovimientoBancosDetE ActualizarMovimientoBancosDet(MovimientoBancosDetE movimientobancosdet);

        [OperationContract]
        int EliminarMovimientoBancosDet(Int32 idMovBanco, Int32 Item);

        [OperationContract]
        int EliminarMovBancosDetPorId(Int32 idMovBanco);

        [OperationContract]
        List<MovimientoBancosDetE> ListarMovimientoBancosDet(Int32 idMovBanco, Int32 idEmpresa);

        [OperationContract]
        MovimientoBancosDetE ObtenerMovimientoBancosDet(Int32 idMovBanco, Int32 Item);

        [OperationContract]
        List<MovimientoBancosDetE> MovBancosDetallePorDocumento(List<CtaCteE> ListaCtaCte, String Usuario, DateTime Fecha);

        #endregion

        #region ISolicitudProveedor Members JOSE SALAZAR

        [OperationContract]
        SolicitudProveedorE GrabarSolicitudProveedor(SolicitudProveedorE solicitudproveedor, EnumOpcionGrabar Opcion);

        [OperationContract]
        SolicitudProveedorE InsertarSolicitudProveedor(SolicitudProveedorE solicitudproveedor);

        [OperationContract]
        SolicitudProveedorE ActualizarSolicitudProveedor(SolicitudProveedorE solicitudproveedor);

        [OperationContract]
        List<SolicitudProveedorE> ListarSolicitudProveedor(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, String indEstado);

        [OperationContract]
        int EliminarSolicitudProveedor(SolicitudProveedorE solicitudproveedor);

        [OperationContract]
        SolicitudProveedorE ObtenerSolicitudProveedor(Int32 idSolicitud);

        [OperationContract]
        SolicitudProveedorE RecuperarSolicitudProveedor(Int32 idSolicitud);

        [OperationContract]
        SolicitudProveedorE SolicitudProvImpresion(Int32 idSolicitud);

        [OperationContract]
        String GenerarOrdenPago(Int32 idSolicitud, String Usuario);

        [OperationContract]
        String AbrirSolicitudProveedor(SolicitudProveedorE solicitudproveedor, String UsuarioModificacion);

        [OperationContract]
        List<SolicitudProveedorE> SolicitudProveedorPendientes(Int32 idEmpresa, Int32 idLocal, String RazonSocial);

        #endregion

        #region ISolicitudProveedorDet Members JOSE SALAZAR

        [OperationContract]
        SolicitudProveedorDetE InsertarSolicitudProveedorDet(SolicitudProveedorDetE solicitudproveedordet);

        [OperationContract]
        SolicitudProveedorDetE ActualizarSolicitudProveedorDet(SolicitudProveedorDetE solicitudproveedordet);

        [OperationContract]
        int EliminarSolicitudProveedorDet(Int32 idSolicitud, Int32 Item);

        [OperationContract]
        List<SolicitudProveedorDetE> ListarSolicitudProveedorDet(Int32 idSolicitud);

        [OperationContract]
        SolicitudProveedorDetE ObtenerSolicitudProveedorDet(Int32 idSolicitud, Int32 Item);

        #endregion

        #region ISolicitudProveedorRendicion Members JOSE SALAZAR

        [OperationContract]
        SolicitudProveedorRendicionE GrabarRendicion(SolicitudProveedorRendicionE oRendicion, EnumOpcionGrabar Opcion);

        [OperationContract]
        SolicitudProveedorRendicionE InsertarSolicitudProveedorRendicion(SolicitudProveedorRendicionE solicitudproveedorrendicion);

        [OperationContract]
        SolicitudProveedorRendicionE ActualizarSolicitudProveedorRendicion(SolicitudProveedorRendicionE solicitudproveedorrendicion);

        [OperationContract]
        int EliminarSolicitudProveedorRendicion(Int32 idRendicion);

        [OperationContract]
        List<SolicitudProveedorRendicionE> ListarSolicitudProveedorRendicion(Int32 idEmpresa, Int32 idAuxiliar, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        SolicitudProveedorRendicionE ObtenerSolicitudProveedorRendicion(Int32 idRendicion);

        [OperationContract]
        SolicitudProveedorRendicionE RecuperarSolicitudProveedorRendicion(Int32 idRendicion);

        [OperationContract]
        String GenerarAsientoRendicion(Int32 idRendicion, String Usuario);

        [OperationContract]
        int EliminarAsientoRendicion(SolicitudProveedorRendicionE oRendicion, String Usuario);

        [OperationContract]
        Int32 ActualizarRendicionConta(SolicitudProveedorRendicionE solicitudproveedorrendicion);

        [OperationContract]
        int ActualizarTotales(List<SolicitudProveedorRendicionE> oRendiciones);

        [OperationContract]
        Int32 ActualizarRendicionContaDepo(SolicitudProveedorRendicionE solicitudproveedorrendicion);

        #endregion

        #region ISolicitudProveedorRendicionDet Members JOSE SALAZAR

        [OperationContract]
        SolicitudProveedorRendicionDetE InsertarSolicitudProveedorRendicionDet(SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet);

        [OperationContract]
        SolicitudProveedorRendicionDetE ActualizarSolicitudProveedorRendicionDet(SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet);

        [OperationContract]
        int EliminarSolicitudProveedorRendicionDet(Int32 idRendicion, Int32 Item);

        [OperationContract]
        List<SolicitudProveedorRendicionDetE> ListarSolicitudProveedorRendicionDet(Int32 idRendicion);

        [OperationContract]
        SolicitudProveedorRendicionDetE ObtenerSolicitudProveedorRendicionDet(Int32 idRendicion, Int32 Item);

        [OperationContract]
        List<SolicitudProveedorRendicionDetE> RendicionImpresion(Int32 idRendicion);

        #endregion

        #region ITipoPagoDet Members JOSE SALAZAR

        [OperationContract]
        TipoPagoDetE InsertarTipoPagoDet(TipoPagoDetE tipopagodet);

        [OperationContract]
        TipoPagoDetE ActualizarTipoPagoDet(TipoPagoDetE tipopagodet);

        [OperationContract]
        int EliminarTipoPagoDet(Int32 idEmpresa, String codTipoPago);

        [OperationContract]
        List<TipoPagoDetE> ListarTipoPagoDet(Int32 idEmpresa, String codTipoPago);

        [OperationContract]
        TipoPagoDetE ObtenerTipoPagoDet(Int32 idEmpresa, String codTipoPago, Int32 idConcepto);

        [OperationContract]
        List<TipoPagoDetE> ListarTipoPagoDetIndSolProv(Int32 idEmpresa);

        [OperationContract]
        TipoPagoDetE TipoPagoDetPorConcepto(Int32 idEmpresa, Int32 idConcepto);

        #endregion

        #region ITesParametros Members JOSE SALAZAR

        [OperationContract]
        tesParametrosE InsertarTesParametros(tesParametrosE parametros);

        [OperationContract]
        tesParametrosE ActualizarTesParametros(tesParametrosE parametros);

        [OperationContract]
        int EliminarTesParametros(Int32 idEmpresa);

        [OperationContract]
        List<tesParametrosE> ListarTesParametros();

        [OperationContract]
        tesParametrosE ObtenerTesParametros(Int32 idEmpresa);

        #endregion

        #region IAnticipoCtaCte Members JOSE SALAZAR

        [OperationContract]
        AnticipoCtaCteE InsertarAnticipoCtaCte(AnticipoCtaCteE ctacte);

        [OperationContract]
        AnticipoCtaCteE ActualizarAnticipoCtaCte(AnticipoCtaCteE ctacte);

        [OperationContract]
        List<AnticipoCtaCteE> ListarAnticipoCtaCte();

        [OperationContract]
        List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePorParametros(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<AnticipoCtaCteE> ObtenerAnticipoCtaCteDetallado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<AnticipoCtaCteE> AnticipoCtaCteDetalladoVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<AnticipoCtaCteE> ConsultaAnticipoCtaCteDet(Int32 idEmpresa, Int32 IdPersona, DateTime fecFiltro, String Opcion, Boolean EsDetraccion);

        [OperationContract]
        List<AnticipoCtaCteE> ConsultaAnticipoCtaCteDetVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String Tipo);

        [OperationContract]
        List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePorCuenta(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro);

        [OperationContract]
        List<AnticipoCtaCteE> ObtenerAnticipoCtaCteGeneral(Int32 idEmpresa, string filtro, DateTime fecFiltro);

        [OperationContract]
        List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePartida(Int32 idEmpresa, string filtro, DateTime fecFiltro);

        [OperationContract]
        Int32 EliminarAnticipoCtaCteMasivo(Int32 idEmpresa, Int32 idSistema, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        Int32 TransferirAnticipoCtaCte(List<ProvisionesE> oListaCompras, List<EmisionDocumentoE> oListaVentas, Int32 idSistema, String Usuario);

        [OperationContract]
        AnticipoCtaCteE ObtenerAnticipoCtaCtePorDocumento(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        List<AnticipoCtaCteE> ObtenerAnticipoCtaCteLetras(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema);

        [OperationContract]
        List<AnticipoCtaCteE> ReporteAnticipoCtaCteComparado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro);

        #endregion

        #region IAnticipoCtaCte_Det Members JOSE SALAZAR

        [OperationContract]
        AnticipoCtaCteDetE InsertarAnticipoCtaCteDet(AnticipoCtaCteDetE ctacte_det);

        [OperationContract]
        AnticipoCtaCteDetE ActualizarAnticipoCtaCteDet(AnticipoCtaCteDetE ctacte_det);

        [OperationContract]
        AnticipoCtaCteDetE ObtenerAnticipoCtaCteDet(Int32 idEmpresa, String numAnio, String numMes, Int32 IdPersona, String idDocumento, String NumSerie, String NumDocumento, String idDocumentoOrig, String NumSerieOrig, String NumDocOrig);

        #endregion

    }
}
