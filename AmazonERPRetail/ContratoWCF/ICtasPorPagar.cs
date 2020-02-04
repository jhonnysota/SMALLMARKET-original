using System;
using System.Collections.Generic;
using System.ServiceModel;
using Entidades.Contabilidad;
using Entidades.CtasPorPagar;
using Infraestructura.Enumerados;

namespace ContratoWCF
{
    [ServiceContract]
    public interface ICtasPorPagar
    {

        #region IPlantilla_Concepto Members JOSE SALAZAR

        [OperationContract]
        Plantilla_ConceptoE GrabarPlantilla(Plantilla_ConceptoE PlantillaCompleta, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        Plantilla_ConceptoE InsertarPlantilla_Concepto(Plantilla_ConceptoE plantilla_concepto);

        [OperationContract]
        Plantilla_ConceptoE ActualizarPlantilla_Concepto(Plantilla_ConceptoE plantilla_concepto);

        [OperationContract]
        Int32 EliminarPlantilla_Concepto(Int32 idEmpresa, Int32 idPlantilla);

        [OperationContract]
        List<Plantilla_ConceptoE> ListarPlantilla_Concepto(Int32 idEmpresa);

        [OperationContract]
        Plantilla_ConceptoE ObtenerPlantilla_Concepto(Int32 idEmpresa, Int32 idPlantilla);

        [OperationContract]
        Plantilla_ConceptoE RecuperarPlantilla_ConceptoPorId(Int32 idEmpresa, Int32 idPlantilla);


        #endregion    

        #region IPlantilla_Concepto_item Members JOSE SALAZAR

        [OperationContract]
        Plantilla_Concepto_itemE InsertarPlantilla_Concepto_item(Plantilla_Concepto_itemE plantilla_concepto_item);

        [OperationContract]
        Plantilla_Concepto_itemE ActualizarPlantilla_Concepto_item(Plantilla_Concepto_itemE plantilla_concepto_item);

        [OperationContract]
        Int32 EliminarPlantilla_Concepto_item(Int32 idEmpresa, Int32 idPlantilla);

        [OperationContract]
        List<Plantilla_Concepto_itemE> ListarPlantilla_Concepto_item();

        [OperationContract]
        Plantilla_Concepto_itemE ObtenerPlantilla_Concepto_item(Int32 idEmpresa, Int32 idPlantilla, Int32 idItem);

        #endregion   

        #region IProvisiones Members JOSE SALAZAR

        [OperationContract]
        ProvisionesE GrabarProvision(ProvisionesE ProvisionCompleto, EnumOpcionGrabar OpcionGrabacion, Boolean ActualizarDetalle = true);

        [OperationContract]
        ProvisionesE ActualizarProvisionesDetraccion(ProvisionesE provisiones);

        [OperationContract]
        Int32 EliminarProvisiones(Int32 idEmpresa, Int32 idLocal, Int32 idProvision);

        [OperationContract]
        List<ProvisionesE> ListarProvisiones(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String RazonSocial, String Estado, String idComprobante, String numFile, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        List<ProvisionesE> ListarProvisionesNC(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String RazonSocial, String Estado, String idComprobante, String numFile, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        ProvisionesE ObtenerProvisionPorOC(Int32 idEmpresa, Int32 idOrdenCompra);

        [OperationContract]
        ProvisionesE ObtenerProvisionPorReferencia(Int32 idEmpresa, Int32 idPersona, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        ProvisionesE RecuperarProvisionesPorId(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Boolean PorRecibir = false, String ConDetalle = "S");

        [OperationContract]
        ProvisionesE GenerarAsientoProvisiones(ProvisionesE oProvision, String Usuario, String Tipo = "N");

        [OperationContract]
        List<ProvisionesE> ListarPartidaPresuAgrupadoPorProvisiones(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta);

        [OperationContract]
        List<ProvisionesE> ListarProvisionesPorPartidaPresu(Int32 idEmpresa, String codPartidaPresu, String mes, String ano);

        [OperationContract]
        List<ProvisionesE> ListarProvisionesPorPeriodo(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta);

        [OperationContract]
        Int32 EliminarVoucherProvision(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, String Usuario, String Estado);

        [OperationContract]
        Int32 EliminarVoucherProvisionMasivo(List<ProvisionesE> oListaProvisiones, String Usuario);

        [OperationContract]
        Int32 GenerarVoucherProvisionMasivo(List<ProvisionesE> oListaProvisiones, String Usuario, String Tipo = "N");

        [OperationContract]
        Int32 LimpiezaNrosVouchers(List<ProvisionesE> oListaProvisiones, String Usuario);

        [OperationContract]
        List<ProvisionesE> ProvisionesPorRevertir(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        List<ProvisionesE> ProvisionesPorRecibir(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        Int32 ActualizarNumReversion(Int32 idEmpresa, Int32 idLocal, Int32? idProvision, Int32 idProvisionRev, String UsuarioModificacion);

        [OperationContract]
        ProvisionesE ObtenerProvisionPorNumReve(Int32 idEmpresa, Int32 idLocal, Int32 idProvision);

        [OperationContract]
        List<ProvisionesE> ListarProvisionesCtaCte(Int32 idEmpresa, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        List<ProvisionesE> ListarProvisionesDetraccion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String RazonSocial, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        Int32 GenerarOpProvisionesDetracciones(List<ProvisionesE> oListaProvisionesDetra, Int32 idEmpresa, String Usuario);

        [OperationContract]
        List<ProvisionesE> ProvisionesPorEstado(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Estado);

        #endregion

        #region IProvisiones_PorCCosto Members JOSE SALAZAR

        [OperationContract]
        Provisiones_PorCCostoE InsertarProvisiones_PorCCosto(Provisiones_PorCCostoE provisiones_porccosto);

        [OperationContract]
        Provisiones_PorCCostoE ActualizarProvisiones_PorCCosto(Provisiones_PorCCostoE provisiones_porccosto);

        [OperationContract]
        Int32 EliminarProvisiones_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32 idProvision);

        [OperationContract]
        List<Provisiones_PorCCostoE> ListarProvisiones_PorCCosto();

        [OperationContract]
        Provisiones_PorCCostoE ObtenerProvisiones_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Int32 idItem);

        #endregion        

        #region IProvisiones_PorPartida Members JOSE SALAZAR

        [OperationContract]
        Provisiones_PorPartidaE InsertarProvisiones_PorPartida(Provisiones_PorPartidaE provisiones_porpartida);

        [OperationContract]
        Provisiones_PorPartidaE ActualizarProvisiones_PorPartida(Provisiones_PorPartidaE provisiones_porpartida);

        [OperationContract]
        Int32 EliminarProvisiones_PorPartida(Int32 idEmpresa, Int32 idLocal, Int32 idProvision);

        [OperationContract]
        List<Provisiones_PorPartidaE> ListarProvisiones_PorPartida();

        [OperationContract]
        Provisiones_PorPartidaE ObtenerProvisiones_PorPartida(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Int32 idItem);

        #endregion  

        #region IPagos Members JOSE SALAZAR
        
        [OperationContract]
        List<ProvisionesE> ListarPartidaPresuAgrupadoPorPagos(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta);

        [OperationContract]
        List<ProvisionesE> ListarPagosPorPartidaPresu(Int32 idEmpresa, String codPartidaPresu, String mes, String ano);

        [OperationContract]
        List<ProvisionesE> ListarPagosPorPeriodo(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta);

        #endregion   

        #region ICanje Members JOSE SALAZAR

        [OperationContract]
        CanjeE GrabarCanje(CanjeE oCanje, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        CanjeE InsertarCanje(CanjeE canje);

        [OperationContract]
        CanjeE ActualizarCanje(CanjeE canje);

        [OperationContract]
        Int32 EliminarCanje(Int32 idEmpresa, Int32 idLocal, Int32 idCanje);

        [OperationContract]
        List<CanjeE> ListarCanje(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        CanjeE ObtenerCanje(Int32 idCanje);

        [OperationContract]
        CanjeE ObtenerCanjeCompleto(Int32 idCanje, Boolean ListarDoc = true, Boolean ListarLetras = true);

        [OperationContract]
        Int32 CambiarEstadoCanje(Int32 idCanje, String Estado, String Usuario);

        [OperationContract]
        VoucherE CerrarCanje(CanjeE oCanje, ParametrosContaE oConParametros, String Usuario);

        [OperationContract]
        Int32 AbrirCanje(Int32 idCanje, String Usuario);

        [OperationContract]
        Int32 ActualizarCanjeConta(CanjeE canje);

        #endregion

        #region ICanjeDctoItem Members JOSE SALAZAR

        [OperationContract]
        CanjeDctoItemE InsertarCanjeDctoItem(CanjeDctoItemE canjedctoitem);

        [OperationContract]
        CanjeDctoItemE ActualizarCanjeDctoItem(CanjeDctoItemE canjedctoitem);

        [OperationContract]
        List<CanjeDctoItemE> ListarCanjeDctoItem(Int32 idCanje);

        [OperationContract]
        CanjeDctoItemE ObtenerCanjeDctoItem(Int32 idEmpresa, Int32 idLocal, Int32 idCanje, Int32 idItemDcmto);

        #endregion

        #region ILetrasItem Members JOSE SALAZAR

        [OperationContract]
        LetrasItemE InsertarLetrasItem(LetrasItemE letrasitem);

        [OperationContract]
        LetrasItemE ActualizarLetrasItem(LetrasItemE letrasitem);

        [OperationContract]
        List<LetrasItemE> ListarLetrasItem(Int32 idCanje);

        [OperationContract]
        LetrasItemE ObtenerLetrasItem(Int32 idEmpresa, Int32 idLocal, Int32 idCanje, Int32 idItemLetra);

        #endregion  

        #region IRetencion Members JOSE SALAZAR

        [OperationContract]
        RetencionE GrabarRetencion(RetencionE Retencion, EnumOpcionGrabar OpcionGrabacion);
        
        [OperationContract]
        List<RetencionE> ListarRetencion(Int32 idEmpresa, Int32 idLocal,Int32 idPersona , DateTime fecIni , DateTime fecFin);

        [OperationContract]
        RetencionE ObtenerRetencionCompleta(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete);

        [OperationContract] 
        String ObtenerUltimoNroCorrelativoRetencion(Int32 idEmpresa, String serieCompRete);

        [OperationContract]
        Int32 EliminarRetencion(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete);

        [OperationContract]
        List<RetencionE> ListarReporteRetenciones(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete);

        [OperationContract]
        Int32 GeneraAsientoRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete);

        [OperationContract]
        Int32 EliminaAsientoRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete);

        [OperationContract]
        Int32 ProcesarMigrarRetencion(String Cod_empresa, String Anno_periodo, String Mes_periodo, Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        List<RetencionE> LibroRetencionLe(Int32 idEmpresa, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        List<RetencionE> LibroRetenciones(Int32 idEmpresa, DateTime fecIni, DateTime fecFin);

        #endregion    

        #region IRetencionItem Members JOSE SALAZAR

        [OperationContract]
        RetencionItemE InsertarRetencionItem(RetencionItemE RetencionItem);

        [OperationContract]
        RetencionItemE ActualizarRetencionItem(RetencionItemE RetencionItem);

        [OperationContract]
        Int32 EliminarRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete, String Item);

        [OperationContract]
        List<RetencionItemE> ListarRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete);

        [OperationContract]
        RetencionItemE ObtenerRetencionItem(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete, String Item);


        #endregion

        #region INumControlCompra Members JOSE SALAZAR

        [OperationContract]
        NumControlCompraE GrabarNumControlCompra(NumControlCompraE numControl, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        NumControlCompraE InsertarNumControlCompra(NumControlCompraE numcontrolcompra);

        [OperationContract]
        NumControlCompraE ActualizarNumControlCompra(NumControlCompraE numcontrolcompra);

        [OperationContract]
        Int32 EliminarNumControlCompra(Int32 idEmpresa, Int32 idLocal, Int32 idControl);

        [OperationContract]
        List<NumControlCompraE> ListarNumControlCompra(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        NumControlCompraE ObtenerNumControlCompra(Int32 idEmpresa, Int32 idLocal, Int32 idControl);

        #endregion

        #region INumControlCompraDet Members JOSE SALAZAR

        [OperationContract]
        NumControlCompraDetE InsertarNumControlCompraDet(NumControlCompraDetE numcontrolcompradet);

        [OperationContract]
        NumControlCompraDetE ActualizarNumControlCompraDet(NumControlCompraDetE numcontrolcompradet);

        [OperationContract]
        Int32 EliminarNumControlCompraDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item);

        [OperationContract]
        List<NumControlCompraDetE> ListarNumControlCompraDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl);

        [OperationContract]
        NumControlCompraDetE ObtenerNumControlCompraDet(Int32 idEmpresa, Int32 idLocal, Int32 idControl, Int32 item);

        [OperationContract]
        List<NumControlCompraDetE> ListarNumControlDocSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento);

        [OperationContract]
        NumControlCompraDetE ObtenerNumControlPorSerie(Int32 idEmpresa, Int32 idLocal, Int32 item);

        [OperationContract]
        NumControlCompraDetE ObtenerNumControlPorSerieDoc(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie);

        #endregion

        #region ILiquidacion Members JOSE SALAZAR

        [OperationContract]
        LiquidacionE GrabarLiquidacion(LiquidacionE oLiquidacion, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        LiquidacionE InsertarLiquidacion(LiquidacionE liquidacion);

        [OperationContract]
        LiquidacionE ActualizarLiquidacion(LiquidacionE liquidacion);

        [OperationContract]
        Int32 EliminarLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion);

        [OperationContract]
        List<LiquidacionE> ListarLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin, Boolean Estado1, Boolean Estado2, String TipoFondo, Boolean BuscarDcmto, String idDocumento, String NumSerie, String NumDocumento);

        [OperationContract]
        LiquidacionE ObtenerLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion);

        [OperationContract]
        LiquidacionE ObtenerLiquidacionCompleta(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion);

        [OperationContract]
        void CerrarLiquidacion(LiquidacionE oLiquidacion, String Usuario, String TipoFondo, String Tipo);

        [OperationContract]
        Int32 LimpiarVoucherLiquidacion(Int32 idLiquidacion, String UsuarioModificacion);

        [OperationContract]
        Boolean AbrirLiquidacion(LiquidacionE oLiquidacion, String Usuario);

        #endregion

        #region ILiquidacionDet Members

        [OperationContract]
        LiquidacionDetE InsertarLiquidacionDet(LiquidacionDetE liquidaciondet);

        [OperationContract]
        LiquidacionDetE ActualizarLiquidacionDet(LiquidacionDetE liquidaciondet);

        [OperationContract]
        Int32 EliminarLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, Int32 idItem);

        [OperationContract]
        List<LiquidacionDetE> ListarLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion);

        [OperationContract]
        LiquidacionDetE ObtenerLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, Int32 idItem);

        [OperationContract]
        List<LiquidacionDetE> LiquidacionRendicionCaja(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Tipo);

        [OperationContract]
        LiquidacionDetE LiquidacionDetPorDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento);

        [OperationContract]
        LiquidacionDetE ObtenerLiquidacionDetPorIdProvision(Int32 idProvision);

        #endregion

        #region IMovilidad Members JOSE SALAZAR

        [OperationContract]
        MovilidadE GrabarMovilidad(MovilidadE Mov, EnumOpcionGrabar Opcion);

        [OperationContract]
        MovilidadE InsertarMovilidad(MovilidadE movilidad);

        [OperationContract]
        MovilidadE ActualizarMovilidad(MovilidadE movilidad);

        [OperationContract]
        Int32 EliminarMovilidad(Int32 idMovilidad);

        [OperationContract]
        List<MovilidadE> ListarMovilidad(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        MovilidadE ObtenerMovilidad(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad);

        [OperationContract]
        MovilidadE ObtenerMovilidadCompleta(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad);

        [OperationContract]
        List<MovilidadE> ListarMovilidadPendientes(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        Int32 ActualizarEstadoMovi(Int32 idMovilidad, Boolean indEstado, String UsuarioModificacion);

        #endregion

        #region IMovilidadDet Members JOSE SALAZAR

        [OperationContract]
        MovilidadDetE InsertarMovilidadDet(MovilidadDetE movilidaddet);

        [OperationContract]
        MovilidadDetE ActualizarMovilidadDet(MovilidadDetE movilidaddet);

        [OperationContract]
        Int32 EliminarMovilidadDet(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad, Int32 idItem);

        [OperationContract]
        List<MovilidadDetE> ListarMovilidadDet(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad);

        [OperationContract]
        MovilidadDetE ObtenerMovilidadDet(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad, Int32 idItem);

        [OperationContract] //JOSE SALAZAR
        List<MovilidadDetE> MovilidadDetReporte(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin);

        #endregion

        #region ILiquidacionSaldos Members JOSE SALAZAR

        [OperationContract]
        LiquidacionSaldosE InsertarLiquidacionSaldos(LiquidacionSaldosE liquidacionsaldos);

        [OperationContract]
        LiquidacionSaldosE ActualizarLiquidacionSaldos(LiquidacionSaldosE liquidacionsaldos);

        [OperationContract]
        Int32 EliminarLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String codOrdenPago);

        [OperationContract]
        List<LiquidacionSaldosE> ListarLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal);

        [OperationContract]
        LiquidacionSaldosE ObtenerLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona);

        [OperationContract]
        LiquidacionSaldosE ObtenerSaldosPorIdLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, Int32 idLiquidacion);

        #endregion

        #region ILiquidacionImportacion Members JOSE SALAZAR

        [OperationContract]
        LiquidacionImportacionE GrabarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion, EnumOpcionGrabar opcionGrabar);

        [OperationContract]
        LiquidacionImportacionE InsertarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion);

        [OperationContract]
        LiquidacionImportacionE ActualizarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion);

        [OperationContract]
        int EliminarLiquidacionImportacion(Int32 idLiquidacion);

        [OperationContract]
        List<LiquidacionImportacionE> ListarLiquidacionImportacion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Boolean Estado1, Boolean Estado2, Boolean Detallado);

        [OperationContract]
        LiquidacionImportacionE ObtenerLiquidacionImportacion(Int32 idLiquidacion, String ConDetalle = "S");

        [OperationContract]
        Int32 CerrarLiquidacionImportacion(LiquidacionImportacionE oLiquidacion, String Usuario);

        [OperationContract]
        Boolean AbrirLiquidacionImportacion(LiquidacionImportacionE oLiquidacion, String Usuario);

        [OperationContract]
        Int32 LimpiarVoucherLiquiImportacion(Int32 idLiquidacion, String UsuarioModificacion);

        #endregion

        #region ILiquidacionImportacionDet Members JOSE SALAZAR

        [OperationContract]
        LiquidacionImportacionDetE InsertarLiquidacionImportacionDet(LiquidacionImportacionDetE liquidacionimportaciondet);

        [OperationContract]
        LiquidacionImportacionDetE ActualizarLiquidacionImportacionDet(LiquidacionImportacionDetE liquidacionimportaciondet);

        [OperationContract]
        Int32 EliminarLiquidacionImportacionDet(Int32 idItem);

        [OperationContract]
        List<LiquidacionImportacionDetE> ListarLiquidacionImportacionDet(Int32 idLiquidacion);

        [OperationContract]
        LiquidacionImportacionDetE ObtenerLiquidacionImportacionDet(Int32 idItem);

        #endregion

    }
}
