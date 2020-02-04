using System;
using System.Collections.Generic;
using System.ServiceModel;

using Entidades.Contabilidad;
using Infraestructura.Enumerados;
using Entidades.Generales;

namespace ContratoWCF
{
    [ServiceContract]
    public interface IContabilidad
    {

        #region IPlanCuenta Members JOSE SALAZAR

        [OperationContract]
        PlanCuentasE InsertarPlanCuentas(PlanCuentasE plancuenta);

        [OperationContract]
        PlanCuentasE ActualizarPlanCuentas(PlanCuentasE plancuenta);

        [OperationContract]
        List<PlanCuentasE> ObtenerPlanCuentasPadre(Int32 idEmpresa, String VersionPlanCuentas);

        [OperationContract]
        List<PlanCuentasE> ObtenerPlanCuentasSubCuentas(Int32 idEmpresa, String VersionPlanCuentas, Int32 Nivel, String Cuenta);

        [OperationContract]
        PlanCuentasE ObtenerPlanCuentasPorCodigo(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta, String ConTasa = "N");

        [OperationContract]
        List<PlanCuentasE> ObtenerPlanCuentasPorCtaSuperior(Int32 idEmpresa, String VersionPlanCuentas, String CuentaSuperior);

        [OperationContract]
        String ObtenerDescripcionCuenta(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta);

        [OperationContract]
        Int32 EliminarCuenta(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta);

        [OperationContract]
        Int32 VerificaSubCuentas(Int32 idEmpresa, String VersionPlanCuentas, String CuentaSup);

        [OperationContract]
        Int32 EliminarSubCuentas(Int32 idEmpresa, String VersionPlanCuentas, String CuentaSup);

        [OperationContract]
        List<PlanCuentasE> ListarPlanCuentasPorParametro(Int32 idEmpresa, String numVerPlanCuentas, String Parametro, Int32 numNivel, Int32 Opcion);

        [OperationContract]
        List<PlanCuentasE> PlanContableExportacion(Int32 idEmpresa, String numVerPlanCuentas);

        [OperationContract]
        List<PlanCuentasE> ObtenerReportePlanDeCuenta(Int32 idEmpresa, Int32 idLocal, String Anio, String MesIni, String MesFin, String idMoneda, String idCompIni, String idCompFin);

        [OperationContract]
        List<PlanCuentasE> CuentasRenta(Int32 idEmpresa, String numVerPlanCuentas);

        [OperationContract]
        List<PlanCuentasE> ListarCtaCuentaSunat(Int32 idEmpresa, String anioPeriodo, String MesPeriodo);

        [OperationContract]
        PlanCuentasE ActualizarPlandeCuentasSunat(PlanCuentasE plancuentas_sunat);

        [OperationContract]
        List<PlanCuentasE> GenerarBalanceComprobacionSunat(Int32 idEmpresa, String anioPeriodo, String MesPeriodo);

        [OperationContract]
        List<PlanCuentasE> PlanCuentasRepSimplificado(Int32 idEmpresa, String numVerPlanCuentas);

        #endregion

        #region IPeriodos Members JOSE SALAZAR

        [OperationContract]
        PeriodosE InsertarPeriodos(PeriodosE periodos);

        [OperationContract]
        PeriodosE ActualizarPeriodos(PeriodosE periodos);

        [OperationContract]
        List<PeriodosE> ActualizarPeriodosLista(List<PeriodosE> listaperiodos);

        [OperationContract]
        List<PeriodosE> ListarPeriodos(Int32 idEmpresa, String AnioPeriodo);

        [OperationContract]
        Int32 EliminarPeriodos(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        PeriodosE ObtenerPeriodoPorMes(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        Int32 AperturaAnioContable(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String UsuarioRegistro);

        #endregion

        #region IVoucher Members JOSE SALAZAR

        [OperationContract]
        VoucherE GrabarVouchers(VoucherE voucher, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        VoucherE InsertarVoucher(VoucherE voucher);

        [OperationContract]
        VoucherE ActualizarVoucher(VoucherE voucher);

        [OperationContract]
        List<VoucherE> ListarVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile);

        [OperationContract]
        List<VoucherE> ListarVoucherNumVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile, String numVoucher);

        [OperationContract]
        Int32 EliminarVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile);

        [OperationContract]
        Int32 EliminarVoucherPorPeriodoyFechas(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        void AnularVoucher(VoucherE voucher, String UsuarioAnula, String Tipo);

        [OperationContract]
        VoucherE ObtenerVoucherPorCodigo(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, String ConDetalle = "S");

        [OperationContract]
        VoucherE GenerarVoucherCancelacionCompra(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, VoucherItemE oCancela);

        [OperationContract]
        VoucherE GenerarVoucherCopia(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, VoucherItemE oCancela);

        [OperationContract]
        Int32 TransferirVentasVoucher(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Usuario);

        [OperationContract]
        Int32 EliminarVoucherMasivo(List<VoucherE> oListaVouchers, String Usuario, String indEliminar = "S");

        //[OperationContract]
        //Int32 EliminarVoucherMasivoRapido(List<VoucherE> oListaVouchers, String Usuario);

        #endregion

        #region IVoucherItem Members JOSE SALAZAR

        [OperationContract]
        List<VoucherItemE> GrabarVoucherItem(List<VoucherItemE> ListaVoucherItem);

        [OperationContract]
        VoucherItemE InsertarVoucherItem(VoucherItemE voucheritem);

        [OperationContract]
        VoucherItemE ActualizarVoucherItem(VoucherItemE voucheritem);

        [OperationContract]
        VoucherItemE ActualizarVoucherConciliado(VoucherItemE voucheritem);

        [OperationContract]
        List<VoucherItemE> ObtenerVoucherItemPorCodigo(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile);

        [OperationContract]
        VoucherItemE RecuperarVoucherItemPorLinea(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem);

        [OperationContract]
        List<VoucherItemE> VoucherDetalle(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile);

        [OperationContract]
        List<VoucherItemE> ReporteMovimientoBanco(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin);

        [OperationContract]
        List<VoucherItemE> VoucherDetalleEgreso(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile);

        [OperationContract]
        List<VoucherItemE> ReporteVoucherItemConceptoGasto(Int32 idEmpresa, String idMoneda, String AnioPeriodo, String MesPeriodoIni, String MesPeriodoFin);

        [OperationContract]
        List<VoucherItemE> ListarVoucherItemConceptoGasto(Int32 idEmpresa, String idMoneda, String AnioPeriodo, String MesPeriodo, String idConceptoGasto, String idCampana);

        [OperationContract]
        List<VoucherItemE> ReporteVoucherItemMovimientoEFectivo(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin);

        [OperationContract]
        List<VoucherItemE> ReporteVoucherItemMovimientoCtaCte(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin);

        [OperationContract]
        List<VoucherItemE> ListaVoucherItemActivacion(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String MesPeriodoFin);

        [OperationContract]
        List<VoucherItemE> ListarVoucherItemPorCuenta(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta);

        [OperationContract] //JOSE SALAZAR
        List<VoucherItemE> ListaVoucherItemPorDcmtoCtaCte(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuenta, Int32 idPersona, String idDocumento, String Serie, String Numero);

        [OperationContract]
        List<VoucherItemE> RegistroDeDiarioTxt(Int32 idEmpresa, Int32 idLocal, DateTime FechaIni, DateTime FechaFin, String NumVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal);

        [OperationContract] //JOSE SALAZAR
        List<VoucherItemE> RepVoucherItemMovimientoCtaCteOpe(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin);

        [OperationContract]
        List<VoucherItemE> RepVoucherItemMovimientoEFectivoOpe(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin);

        [OperationContract] //JOSE SALAZAR
        List<VoucherItemE> BuscarVoucherPorCtaContableTipo(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String codCuenta, String Tipo);

        [OperationContract] //JOSE SALAZAR
        Int32 ActualizarVoucherItemAuxiCcDoc(List<VoucherItemE> ListaVoucherItem, String Tipo);

        #endregion

        #region IPublicidad Members JOSE SALAZAR

        [OperationContract]
        List<PublicidadE> ListarReportePublicidad(Int32 idEmpresa, DateTime fecha);

        #endregion

        #region ISaldosMensuales Members JOSE SALAZAR

        [OperationContract]
        List<SaldosMensualesE> SaldosMensualesReporte(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, Int32 NivelCuenta);

        [OperationContract]
        List<SaldosMensualesE> SaldosCuentaAuxiliar(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, String idComprobante, Int32 NivelCuenta, String idMoneda);

        [OperationContract]
        List<SaldosMensualesE> ReporteResumenMesesSaldos(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, Int32 NivelCuenta);
        #endregion

        #region IComprobantes y Files Members JOSE SALAZAR

        //Comprobantes
        [OperationContract]
        ComprobantesE GrabarTipoComprobante(ComprobantesE TipoComprobante, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        ComprobantesE InsertarComprobantes(ComprobantesE comprobantese);

        [OperationContract]
        ComprobantesE ActualizarComprobantes(ComprobantesE comprobantese);

        [OperationContract]
        String EliminarComprobantes(Int32 idEmpresa, String idComprobante);

        [OperationContract]
        List<ComprobantesE> ListarComprobantes(Int32 idEmpresa);

        [OperationContract]
        ComprobantesE ObtenerTipoComprobante(Int32 idEmpresa, String idComprobante);

        [OperationContract]
        List<ComprobantesE> ListarComprobantesGeneral(Int32 idEmpresa);

        //Files
        [OperationContract]
        ComprobantesFileE InsertarComprobantesFile(ComprobantesFileE comprobantesfilee);

        [OperationContract]
        ComprobantesFileE ActualizarComprobantesFile(ComprobantesFileE comprobantesfilee);

        [OperationContract]
        List<ComprobantesFileE> ListarComprobantesFile(Int32 idEmpresa);

        [OperationContract]
        List<ComprobantesFileE> ObtenerFilesPorIdComprobante(Int32 idEmpresa, String idComprobante);

        [OperationContract]
        ComprobantesFileE ObtenerFilePorCuenta(Int32 idEmpresa, String idComprobante, String idMoneda, String numVerPlanCuentas, String codCuenta);

        #endregion 

        #region IPlanCuentasVersion Members JOSE SALAZAR

        [OperationContract]
        PlanCuentasVersionE GrabarPlanCuentasVersion(PlanCuentasVersionE PlanCuenta, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        List<PlanCuentasVersionE> ListarPlanCuentasVersion(Int32 idEmpresa);

        [OperationContract]
        PlanCuentasVersionE ObtenerPlanCuentasVersionCompleto(Int32 idEmpresa, String numVerPlanCuentas);

        [OperationContract]
        PlanCuentasVersionE VersionPlanCuentasActual(Int32 idEmpresa);

        #endregion

        #region IPlanCuentasEstruc Members JOSE SALAZAR

        [OperationContract]
        PlanCuentasEstrucE InsertarPlanCuentasEstruc(PlanCuentasEstrucE plancuentasestruc);

        [OperationContract]
        PlanCuentasEstrucE ActualizarPlanCuentasEstruc(PlanCuentasEstrucE plancuentasestruc);

        [OperationContract]
        List<PlanCuentasEstrucE> ListarPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas);

        [OperationContract]
        Int32 EliminarPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas, Int32 numNivelEstruc);

        [OperationContract]
        PlanCuentasEstrucE ObtenerPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas, Int32 numNivelEstruc);

        #endregion

        #region IConceptoGasto Members JOSE SALAZAR

        [OperationContract]
        ConceptoGastoE InsertarConceptoGasto(ConceptoGastoE concepto);

        [OperationContract]
        ConceptoGastoE ActualizarConceptoGasto(ConceptoGastoE concepto);

        [OperationContract]
        Int32 EliminarConceptoGasto(Int32 idConcepto, Int32 idEmpresa);

        [OperationContract]
        List<ConceptoGastoE> ListarConceptoGasto(Int32 idEmpresa);

        [OperationContract]
        ConceptoGastoE ObtenerConceptoGasto(Int32 idConcepto, Int32 idEmpresa);

        //[OperationContract]
        //List<UMedidaE> ListarUMedidaPorTipo(Int32 idTipoMedida);

        [OperationContract]
        List<ConceptoGastoE> ListarReporteConceptoGasto(Int32 idEmpresa, String idMoneda, String anio, String mesInicio, String mesFinal);

        #endregion    

        #region ICtaCte Members JOSE SALAZAR

        [OperationContract]
        conCtaCteE InsertarConCtaCte(conCtaCteE ctacte);

        [OperationContract]
        conCtaCteE ActualizarConCtaCte(conCtaCteE ctacte);

        [OperationContract]
        Int32 EliminarConCtaCte(Int32 idCtaCte);

        [OperationContract]
        List<conCtaCteE> ListarConCtaCte();

        [OperationContract]
        conCtaCteE ObtenerConCtaCte(Int32 idCtaCte);

        [OperationContract]
        List<conCtaCteE> ResumenConCtaCtePorParametros(Int32 idEmpresa, String codCuenta, Int32 idPersona, DateTime Fecha, String Estado);


        [OperationContract]
        List<conCtaCteE> ReporteConCtaCtePendientes(
            Int32 idEmpresa, String numPlanCta, String ano, String cuenta_ini, String cuenta_fin,
            Int32 idPersona, String mes_inicial, String mes_fin, String idmoneda, String historico, String tipo_reporte);

        [OperationContract]
        List<conCtaCteE> ReporteInventarioBalanceCtaCte(Int32 idEmpresa, String Anio, String Mes, Int32 Tipo);

        #endregion 

        #region ICtaCteItem Members JOSE SALAZAR

        [OperationContract]
        conCtaCteItemE InsertarConCtaCteItem(conCtaCteItemE ctacteitem);

        [OperationContract]
        conCtaCteItemE ActualizarConCtaCteItem(conCtaCteItemE ctacteitem);

        [OperationContract]
        void EliminarConCtaCteItem(Int32 idCtaCte, Int32 idCtaCteItem);

        [OperationContract]
        List<conCtaCteItemE> ListarConCtaCteItemPorCodigo(Int32 idCtaCte);

        [OperationContract]
        conCtaCteItemE ObtenerConCtaCteItem(Int32 idCtaCte, Int32 idCtaCteItem);

        [OperationContract]
        List<conCtaCteItemE> ListarConCtaCtePendientes(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, Int32 idPersona, DateTime fecFiltro);

        #endregion

        #region IReporteEEFFItem JOSE SALAZAR

        [OperationContract]
        List<ReporteEEFFItemE> ListarRptEEFFGananciasPerdidas(Int32 idEmpresa, String anio, String mesInicio, String mesFin, Int32 idEEFF, String idCCostos, String indAcumulado, String indCCostos, String NumPlaCta, String TipoReporte, Decimal TipoCambio, Int32 numNivel, Boolean MostrarTodo);

        [OperationContract]
        List<VoucherItemE> ListarRptEEFFGananciasPerdidasDetalle(Int32 idEmpresa, Int32 idLocal, String anio, String mesInicio, String mesFin, Int32 idEEFF, Int32 idEEFFItem, String idCCostos, String idMoneda, String TipoReporte);

        [OperationContract]
        List<ReporteEEFFItemE> ListarReporteEEFFGananciasPerdidasArchivo(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFitem);

        [OperationContract] //JOSE SALAZAR
        List<ReporteEEFFItemE> ListarReporteEEFFGananciasPerdidasRatios(Int32 idEmpresa, Int32 Anio, String MesInicio, String MesFin, String NumPlaCta, Boolean Calculo);

        #endregion 

        #region IBalanceComprobacion Members JOSE SALAZAR

        [OperationContract]
        List<BalanceComprobacionE> ListarBalanceComprobacionAcumulado(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Version, String idMoneda, Int32 Nivel, String Formato);

        [OperationContract]
        List<BalanceComprobacionE> ListarBalanceComprobacionCCostoAcumulado(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Version, String idMoneda, String CCosto, String Formato, Int32 numNivel);

        #endregion 

        #region IDifCambio Members JOSE SALAZAR

        [OperationContract]
        List<DifCambioE> ListarConsistenciaDif(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idMoneda, String numVerPlanCuentas, DateTime Fecha);

        [OperationContract]
        void ProcesoDiferenciaCambio(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, string UsuarioAsignado);

        [OperationContract]
        void EliminarDiferenciaCambio(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, string UsuarioAsignado);

        [OperationContract]
        void ProcesoDiferenciaCambioSoles(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, string SoloCancelados, string UsuarioAsignado);

        [OperationContract]
        void EliminarDiferenciaCambioSoles(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, string SoloCancelados, string UsuarioAsignado);

        #endregion

        #region IDisFactor Members JOSE SALAZAR

        [OperationContract]
        void ProcesoDistribucionFactor(int idEmpresa, int idLocal, DateTime FechaInicio, DateTime FechaFin, Decimal FactorDistribuidor, string Usuario);

        [OperationContract]
        void ProcesoIngresoAlmacenFactor(int idEmpresa, int idLocal, DateTime FechaProceso, string Diario, string File, string Usuario);


        #endregion 

        #region IReparablesBoletas Members JOSE SALAZAR

        [OperationContract]
        List<ReparablesE> ListarReparablesBoletas(Int32 idEmpresa, Int32 idLocal, String AnioProceso, String MesInicio, String MesFin, String Tipo);

        #endregion 

        #region Con_Saldos Members JOSE SALAZAR

        [OperationContract]
        List<Con_SaldosE> MayorizarMayor(Int32 idEmpresa, Int32 idLocal, String vi_mes_inicio, String vi_ano_inicio, String vi_mes_proceso, String vi_ano_proceso, String vi_ver_placta);

        [OperationContract]
        Con_SaldosE Obtenercon_saldos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta);

        [OperationContract] //JOSE SALAZAR
        List<Con_SaldosE> SaldoContableApertura(Int32 idEmpresa, String Anio, String Mes);

        #endregion

        #region Con_SaldosCostos Member JOSE SALAZAR

        [OperationContract]
        List<Con_SaldosCostosE> MayorizarCostos(Int32 idEmpresa, String as_anno, String vi_ver_placta);

        [OperationContract]
        List<Con_SaldosCostosE> ObtenerResumenDetallePorCentrodeCosto(Int32 idEmpresa, Int32 idLocal, String anioPeriodo, String periodo, String periodoFin, String numVerPlanCuenta, String codCuentaIni, String codCuentaFin, Int32 numNivel);

        #endregion 

        #region IComprasVarias JOSE SALAZAR

        [OperationContract]
        ComprasVariasE InsertarComprasVarias(ComprasVariasE comprobantese);

        [OperationContract]
        ComprasVariasE ActualizarComprasVarias(ComprasVariasE comprobantese, Boolean Revisar = false);

        [OperationContract]
        List<ComprasVariasE> ListarComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        ComprasVariasE ObtenerComprasVariasPorId(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante);

        [OperationContract]
        Int32 EliminarComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante);

        [OperationContract]
        List<ComprasVariasE> ListarReporteComprasVariasPorGrabacion(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String flagGravado);

        #endregion

        #region IDatosAuditoria JOSE SALAZAR

        [OperationContract]
        List<DatosAuditoriaE> ListarReporteDatosAuditoria(Int32 idEmpresa, DateTime fecIni, DateTime fecFin);

        #endregion

        #region IEEFF JOSE SALAZAR

        [OperationContract]
        EEFFE GuardarEEFF(EEFFE entidad);

        [OperationContract]
        EEFFE InsertarEEFF(EEFFE entidad);

        [OperationContract]
        EEFFE ActualizarEEFF(EEFFE entidad);

        [OperationContract]
        Int32 EliminarDetalleEEFF(Int32 idEmpresa, Int32 idEEFF);

        [OperationContract]
        List<EEFFE> ListarEEFF(Int32 idEmpresa, Int32 idEEFF, String desSeccion, Boolean VerReporte);

        [OperationContract]
        List<EEFFE> ListarEEFFParaPres(Int32 idEmpresa);

        [OperationContract]
        EEFFE ObtenerEEFFCompleto(Int32 idEmpresa, Int32 idEEFF);

        [OperationContract]
        List<EEFFE> ListarBalanceGeneral(Int32 idEmpresa, String TipoSeccion, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        List<EEFFE> ListarBalanceGeneralResumen(Int32 idEmpresa, String VerPlanCuenta, Int32 TipoSeccion, String AnioPeriodo, String MesPeriodo);

        #endregion

        #region IEEFFItem JOSE SALAZAR

        [OperationContract]
        EEFFItemE InsertarEEFFItem(EEFFItemE entidad);

        [OperationContract]
        EEFFItemE ActualizarEEFFItem(EEFFItemE entidad);
        
        [OperationContract]
        EEFFItemE ObtenerEEFFItem(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem);

        [OperationContract]
        List<EEFFItemE> ListarEEFFItem(Int32 idEmpresa, Int32 idEEFF);

        [OperationContract]
        List<EEFFItemE> ListarConEEFFItemParPres(Int32 idEmpresa, Int32 idEEFF);
        

        #endregion

        #region IEEFFItemCta Members JOSE SALAZAR

        [OperationContract]
        Int32 MaxIdConEEFFItemCta(Int32 idEmpresa, int idEEFF, int idEEFFItem);

        [OperationContract]
        EEFFItemCtaE InsertarEEFFItemCta(EEFFItemCtaE eeffitemcta);

        [OperationContract]
        EEFFItemCtaE ActualizarEEFFItemCta(EEFFItemCtaE eeffitemcta);

        [OperationContract]
        Int32 EliminarEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemCta);

        [OperationContract]
        List<EEFFItemCtaE> ListarEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idLocal, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        EEFFItemCtaE ObtenerEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemCta);

        [OperationContract]
        List<EEFFItemCtaE> EEFFCtasNoAsignadas(Int32 idEmpresa, Int32 idEEFF, String AnioPeriodo, String MesPeriodo);

        #endregion

        #region IEEFFItemFor  Members JOSE SALAZAR

        [OperationContract]
        EEFFItemForE InsertarEEFFItemFor(EEFFItemForE eeffitemfor);

        [OperationContract]
        EEFFItemForE ActualizarEEFFItemFor(EEFFItemForE eeffitemfor);

        [OperationContract]
        Int32 EliminarEEFFItemFor(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemFor);

        [OperationContract]
        List<EEFFItemForE> ListarEEFFItemFor(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem);

        [OperationContract]
        EEFFItemForE ObtenerEEFFItemFor(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemFor);

        #endregion

        #region IEEFFItemXls Members JOSE SALAZAR

        [OperationContract]
        EEFFItemXlsE InsertarEEFFItemXls(EEFFItemXlsE eeffitemxls);

        [OperationContract]
        EEFFItemXlsE ActualizarEEFFItemXls(EEFFItemXlsE eeffitemxls);

        [OperationContract]
        Int32 EliminarEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemXls);

        [OperationContract]
        List<EEFFItemXlsE> ListarEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem);

        [OperationContract]
        EEFFItemXlsE ObtenerEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemXls);

        #endregion        

        #region IRegistroVentas Members JOSE SALAZAR

        [OperationContract]
        RegistroVentasE ActualizarRegistroVentas(RegistroVentasE registroventas);

        [OperationContract]
        Int32 EliminarRegistroVentas(Int32 idRegistro);

        [OperationContract]
        List<RegistroVentasE> ListarRegistroVentas();

        [OperationContract]
        RegistroVentasE ObtenerRegistroVentas(Int32 idRegistro);

        [OperationContract]
        Int32 InsertarRegistroVentasPorVolumen(List<RegistroVentasE> oListaVentas, DateTime fecInicial, DateTime fecFinal, Boolean Eliminar);

        [OperationContract]
        List<RegistroVentasE> RegistroDeVentasLe(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda);

        [OperationContract]
        List<RegistroVentasE> RegistroDeVentasDaot(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda);

        #endregion

        #region IRegistroCompras JOSE SALAZAR

        [OperationContract]
        List<RegistroComprasE> RegistroDeComprasLe(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda, String indComprasVarias);

        [OperationContract]
        List<RegistroComprasE> RegistroDeComprasLeNoDom(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda);

        [OperationContract]
        List<RegistroComprasE> ReporteDetalleComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda);

        [OperationContract]
        List<RegistroComprasE> ReporteResumenComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda);

        [OperationContract]
        List<RegistroComprasE> ReporteNaturalezaComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda);

        [OperationContract]
        List<RegistroComprasE> ReporteCuentaComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda);


        #endregion

        #region IRegistro Diario JOSE SALAZAR

        [OperationContract]
        List<RegistroDiarioE> RegistroDeDiarioPLE(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal);

        [OperationContract]
        List<RegistroDiarioE> RegistroDeDiarioEXCEL(Int32 idEmpresa, Int32 idLocal, DateTime FechaIni, DateTime FechaFin, String NumVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal, String Automatico);

        [OperationContract]
        List<RegistroDiarioE> ObtenerDetallePorCenttroDeCostro(Int32 idEmpresa, Int32 idLocal, Int32 anioPeriodo, DateTime fecIni, DateTime fecFin, String codCuentaIni, String codCuentaFin,Int32 numNivel);
        
        [OperationContract]
        List<RegistroDiarioE> ObtenerLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin, Int32 Pag, Int32 CantReg);

        [OperationContract]
        List<RegistroDiarioE> RegistroDeDiarioSimplificado(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal);

        [OperationContract]
        Int32 CantidadRegistroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin);

        #endregion

        #region IParametrosConta JOSE SALAZAR

        [OperationContract]
        ParametrosContaE InsertarParametrosConta(ParametrosContaE parametrosconta);

        [OperationContract]
        ParametrosContaE ActualizarParametrosConta(ParametrosContaE parametrosconta);

        [OperationContract]
        Int32 EliminarParametrosConta(Int32 idEmpresa);

        [OperationContract]
        List<ParametrosContaE> ListarParametrosConta();

        [OperationContract]
        List<ParametrosContaE> ListarParametroContaNivel(Int32 idEmpresa);

        [OperationContract]
        ParametrosContaE ObtenerParametrosConta(Int32 idEmpresa);

        #endregion

        #region IPlanCuentaDifCambioUsuario JOSE SALAZAR

        [OperationContract]
        Int32 GuardaPlanCuentasDifCambioUsuario(List<PlanCuentasDifCambioUsuarioE> oLista);

        [OperationContract]
        List<PlanCuentasDifCambioUsuarioE> ListarPlanCuentasDifCambioUsuario(Int32 idEmpresa, String numVerPlanCuentas, String UsuarioAsignado);

        [OperationContract]
        List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuario(Int32 idEmpresa, String numVerPlanCuentas, String UsuarioAsignado);

        [OperationContract]
        List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuarioDolar(Int32 idEmpresa, String numVerPlanCuentas, String UsuarioAsignado);


        [OperationContract]
        List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuarioSoles(Int32 idEmpresa, String numVerPlanCuentas, String UsuarioAsignado);

        #endregion 

        #region ICierreCuenta Members JOSE SALAZAR

        [OperationContract]
        void ProcesoCierreCuentaPreLiminar(Int32 idEmpresa, Int32 idLocal, DateTime fecCierre);

        [OperationContract]
        void ProcesoCierreCuentaResultado(int idEmpresa, int idLocal, string Version, string AnioCierre, DateTime fecCierre, int Nivel, Decimal tcCie, string idMoneda, string idDiario, string idFile);

        [OperationContract]
        void EliminaCierreBalance(int idEmpresa, int idLocal, string AnioCierre, string idDiario, string idFile);

        [OperationContract]
        void ProcesoCierreCuentaBalance(int idEmpresa, int idLocal, string Version, string AnioCierre, string MesApertura, string AnioApertura, DateTime fecCierre, DateTime fecApertura, int Nivel, Decimal tcCie, Decimal tcApe, string idMoneda, string CtaCie, string CtaApe, string idDiario, string idFile);

        #endregion 

        #region IRegistro de Ventas JOSE SALAZAR

        [OperationContract]
        Int32 ProcesarVentaGeneralMasivo(List<RegistroVentaGeneralE> oLista);

        [OperationContract]
        Boolean GenerarVoucherVentasGeneral(List<RegistroVentaGeneralE> oListaVentas); //JOSE SALAZAR

        [OperationContract]
        Boolean GenerarVoucherIngresosGeneral(List<RegistroVentaGeneralE> oListaVentas, RegistroVentaGeneralE Cabecera); // Cvg

        [OperationContract]
        int CrearClientes(List<ErrorImportGeneralE> ListaClientesErrores, String Usuario, List<RegistroVentaGeneralE> oListaVentas = null);//JOSE SALAZAR

        #endregion

        #region IErrorImportaciones JOSE SALAZAR

        [OperationContract]
        List<ErrorImportacionE> ListarErrorImportacion(Int32 idEmpresa,String Archivo);


        #endregion 

        #region IConsistenciaVoucher JOSE SALAZAR

        [OperationContract]
        List<ConsistenciaVoucherE> ConsistenciaVoucher(Int32 idEmpresa, String ano_ini, String ano_fin, String mes_ini, String mes_fin);

        [OperationContract]
        List<ConsistenciaVoucherE> ConsistenciaVoucherDiferencia(Int32 idEmpresa, String ano, String mes);

        #endregion

        #region Irecibohonorarios JOSE SALAZAR

        [OperationContract]
        ReciboHonorariosE GrabarReciboHonorarios(ReciboHonorariosE ListaReciboHonorarios, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        ReciboHonorariosE InsertarReciboHonorarios(ReciboHonorariosE recibohonorarios);

        [OperationContract]
        ReciboHonorariosE ActualizarReciboHonorarios(ReciboHonorariosE recibohonorarios);

        [OperationContract]
        int EliminarReciboHonorarios(Int32 idEmpresa , Int32 idLocal, Int32 idReciboHonorarios);

        [OperationContract]
        List<ReciboHonorariosE> ListarReciboHonorarios(Int32 idEmpresa,Int32 idLocal, String Anio, String mes, String RazonSocial, String Tipo);

        [OperationContract]
        ReciboHonorariosE ObtenerReciboHonorarios(Int32 idEmpresa,Int32 idLocal, Int32 idReciboHonorarios, String ConDetalle = "S");

        #endregion

        #region IrecibohonorariosDet JOSE SALAZAR

        [OperationContract]
        ReciboHonorariosDetE InsertarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet);

        [OperationContract]
        ReciboHonorariosDetE ActualizarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet);

        [OperationContract]
        int EliminarReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, Int32 idReciboHonorariosDet);

        [OperationContract]
        List<ReciboHonorariosDetE> ListarReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios);

        [OperationContract]
        ReciboHonorariosDetE ObtenerReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, Int32 idReciboHonorariosDet);

        [OperationContract]
        ReciboHonorariosDetE CerrarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet);

        [OperationContract]
        Int32 GeneraAsientoReciboHonorariosDet(ReciboHonorariosE recibohonorarios, String Usuario);

        #endregion        

        #region IVoucherItemCCostos JOSE SALAZAR

        [OperationContract]
        VoucherItemCCostosE InsertarVoucherItemCCostos(VoucherItemCCostosE voucheritemccostos);

        [OperationContract]
        VoucherItemCCostosE ActualizarVoucherItemCCostos(VoucherItemCCostosE voucheritemccostos);

        [OperationContract]
        int EliminarVoucherItemCCostos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem, String idCCostos);

        [OperationContract]
        List<VoucherItemCCostosE> ListarVoucherItemCCostos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem);

        [OperationContract]
        VoucherItemCCostosE ObtenerVoucherItemCCostos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem, String idCCostos);

        #endregion  

        #region ICuentaCCosto JOSE SALAZAR

        [OperationContract]
        CuentaCCostoE InsertarCuentaCCosto(CuentaCCostoE cuentaccosto);

        [OperationContract]
        CuentaCCostoE ActualizarCuentaCCosto(CuentaCCostoE cuentaccosto);

        [OperationContract]
        Int32 EliminarCuentaCCosto(Int32 idEmpresa, Int32 idCuentaC);

        [OperationContract]
        List<CuentaCCostoE> ListarCuentaCCosto(Int32 idEmpresa);

        [OperationContract]
        CuentaCCostoE ObtenerCuentaCCosto(Int32 idEmpresa, Int32 idCuentaC);

        #endregion

        #region IPlantillaAsiento JOSE SALAZAR

        [OperationContract]
        PlantillaAsientoE InsertarPlantillaAsiento(PlantillaAsientoE plantillaasiento);

        [OperationContract]
        PlantillaAsientoE ActualizarPlantillaAsiento(PlantillaAsientoE plantillaasiento);

        [OperationContract]
        Int32 EliminarPlantillaAsiento(Int32 idPlantilla);

        [OperationContract]
        List<PlantillaAsientoE> ListarPlantillaAsiento(Int32 idEmpresa);

        [OperationContract]
        PlantillaAsientoE ObtenerPlantillaAsiento(Int32 idPlantilla, Int32 idEmpresa);

        [OperationContract]
        PlantillaAsientoE RecuperarPlantillaAsiento(Int32 idPlantilla, Int32 idEmpresa);

        [OperationContract]
        String GenerarAsientoContable(PlantillaAsientoE oPlantilla);

        #endregion

        #region IPlantillaAsientoDet JOSE SALAZAR

        [OperationContract]
        PlantillaAsientoDetE InsertarPlantillaAsientoDet(PlantillaAsientoDetE plantillaasientodet);

        [OperationContract]
        PlantillaAsientoDetE ActualizarPlantillaAsientoDet(PlantillaAsientoDetE plantillaasientodet);

        [OperationContract]
        Int32 EliminarPlantillaAsientoDet(Int32 idPlantilla, Int32 idEmpresa, Int32 Item);

        [OperationContract]
        List<PlantillaAsientoDetE> ListarPlantillaAsientoDet(Int32 idPlantilla, Int32 idEmpresa);

        [OperationContract]
        PlantillaAsientoDetE ObtenerPlantillaAsientoDet(Int32 idPlantilla, Int32 idEmpresa, Int32 Item);

        #endregion

        #region IRegistroLibroMayor JOSE SALAZAR

        [OperationContract]
        List<RegistroLibroMayorE> RegistroLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String codCuentaIni, String codCuentaFin);

        #endregion

        #region ICuentasMigracion JOSE SALAZAR

        [OperationContract]
        CuentasMigracionE InsertarCuentasMigracion(CuentasMigracionE CuentasMigracion, CuentasMigracionE CuentasMigracionAnt = null);

        [OperationContract]
        Int32 EliminarCuentasMigracion(CuentasMigracionE CuentasMigracion);

        [OperationContract]
        List<CuentasMigracionE> ListarCuentasMigracion(Int32 idEmpresa);

        [OperationContract]
        List<CuentasMigracionE> ListarCuentasConcar(Int32 idEmpresa, String cuentadestino, String nombredestino);

        [OperationContract]
        Int32 MigrarConcarSQL(String empresa, String ejer, Int32 idEmpresa);

        #endregion

        #region Ilibroconcar Members JOSE SALAZAR

        [OperationContract]
        LibroConcarE Insertarlibroconcar(LibroConcarE libroconcar);

        [OperationContract]
        LibroConcarE Actualizarlibroconcar(LibroConcarE libroconcar);

        [OperationContract]
        int Eliminarlibroconcar(Int32 idEmpresa, String csubdia);

        [OperationContract]
        List<LibroConcarE> Listarlibroconcar(Int32 idEmpresa);

        [OperationContract]
        LibroConcarE Obtenerlibroconcar(Int32 idEmpresa, String csubdia);

        #endregion

        #region IEmpresaConcar Members JOSE SALAZAR

        [OperationContract]
        EmpresaConcarE InsertarEmpresaConcar(EmpresaConcarE EmpresaConcar);

        [OperationContract]
        EmpresaConcarE ActualizarEmpresaConcar(EmpresaConcarE EmpresaConcar);

        [OperationContract]
        int EliminarEmpresaConcar(Int32 idEmpresa);

        [OperationContract]
        List<EmpresaConcarE> ListarEmpresaConcar();

        [OperationContract]
        EmpresaConcarE ObtenerEmpresaConcar(Int32 idEmpresa);

        #endregion

        #region IPresupuesto Members JOSE SALAZAR

        [OperationContract]
        PresupuestoE InsertarPresupuesto(PresupuestoE Presupuesto);

        [OperationContract]
        PresupuestoE ActualizarPresupuesto(PresupuestoE Presupuesto);

        [OperationContract]
        int EliminarPresupuesto(Int32 idEmpresa, Int32 idPresupuesto);

        [OperationContract]
        PresupuestoE GrabarPresupuesto(PresupuestoE Presupuesto, EnumOpcionGrabar OpcionGrabacion);

        [OperationContract]
        List<PresupuestoE> ListarPresupuesto(Int32 idEmpresa);

        [OperationContract]
        PresupuestoE ObtenerPresupuestoCompleto(Int32 idEmpresa, Int32 idPresupuesto);

        [OperationContract]
        PresupuestoE ObtenerPresupuesto(Int32 idEmpresa, Int32 idPresupuesto);

        #endregion

        #region IPresupuestoDet Members JOSE SALAZAR

        [OperationContract]
        PresupuestoDetE InsertarPresupuestoDet(PresupuestoDetE PresupuestoDet);

        [OperationContract]
        PresupuestoDetE ActualizarPresupuestoDet(PresupuestoDetE PresupuestoDet);

        [OperationContract]
        int EliminarPresupuestoDet(Int32 idEmpresa, Int32 idPresupuesto, Int32 idPresupuestoItem);

        [OperationContract]
        List<PresupuestoDetE> ListarPresupuestoDet(Int32 idEmpresa, Int32 idPresupuesto);

        [OperationContract]
        PresupuestoDetE ObtenerPresupuestoDet(Int32 idEmpresa, Int32 idPresupuesto, Int32 idPresupuestoItem);


        [OperationContract]
        PresupuestoDetE ObtenerPresupuestosDetPorMes(Int32 idEmpresa, String Anio, String Mes);

        #endregion

        #region IInventarioBalance JOSE SALAZAR

        [OperationContract]
        List<InventarioBalanceE> ReporteInventarioBalance(Int32 idEmpresa, Int32 idLocal, String ANO_PERIODO, String COD_PERIODO, String VERSION, String COD_CUENTA);

        #endregion

        #region ITasaIRenta Members JOSE SALAZAR

        [OperationContract]
        TasaIRentaE InsertarTasaIRenta(TasaIRentaE tasairenta);

        [OperationContract]
        TasaIRentaE ActualizarTasaIRenta(TasaIRentaE tasairenta);

        [OperationContract]
        int EliminarTasaIRenta(String idTasaIRenta);

        [OperationContract]
        List<TasaIRentaE> ListarTasaIRenta();

        [OperationContract]
        TasaIRentaE ObtenerTasaIRenta(String idTasaIRenta);

        #endregion

        #region IRegistroCompras Members JOSE SALAZAR

        [OperationContract]
        RegistroCompras2E InsertarRegistroCompras(RegistroCompras2E registrocompras);

        [OperationContract]
        RegistroCompras2E ActualizarRegistroCompras(RegistroCompras2E registrocompras);

        [OperationContract]
        RegistroCompras2E InsertarRegistroComprasNoDom(RegistroCompras2E registrocompras);

        [OperationContract]
        RegistroCompras2E ActualizarRegistroComprasNoDom(RegistroCompras2E registrocompras);

        [OperationContract]
        int EliminarRegistroCompras(Int32 idRegCompras);

        [OperationContract]
        List<RegistroCompras2E> ListarRegistroCompras(int idEmpresa, int idLocal, Int32 TipoCompra, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        RegistroCompras2E ObtenerRegistroCompras(Int32 idRegCompras);

        [OperationContract]
        RegistroCompras2E GenerarAsientoCompras(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String Usuario);

        #endregion

        #region IComprasFile Members JOSE SALAZAR

        [OperationContract]
        ComprasFileE InsertarComprasFile(ComprasFileE comprasfile);

        [OperationContract]
        ComprasFileE ActualizarComprasFile(ComprasFileE comprasfile);

        [OperationContract]
        int EliminarComprasFile(Int32 idCompraFile);

        [OperationContract]
        List<ComprasFileE> ListarComprasFile(Int32 idEmpresa, String MostrarFile = "N");

        [OperationContract]
        ComprasFileE ObtenerComprasFile(Int32 idCompraFile);

        [OperationContract]
        List<ComprasFileE> ComprasFileEmpresas();

        [OperationContract]
        List<ComprasFileE> InsertComprasFileOtraEmpresa(Int32 idEmpresa, Int32 idEmpresaNuevo);

        [OperationContract]
        List<ComprasFileE> ListarComprasDiarios(Int32 idEmpresa);

        #endregion

        #region IRegistro Voucher JOSE SALAZAR

        [OperationContract]
        Int32 InsertarVoucherXLS(List<VoucherXLSE> oLista);

        [OperationContract]
        Int32 ErroresVoucherXLS(List<VoucherXLSE> oListaErrores);

        [OperationContract]
        Int32 IntegrarVoucherXLS(Int32 idEmpresa, Int32 idLocal, String Usuario, List<VoucherXLSE> oListaVoucher, Boolean EliminarVouchers,String Borrar);

        [OperationContract]
        Int32 EliminarVoucherXLS(List<VoucherXLSE> oListaPorEliminar);

        #endregion

        #region IRegistro BalanceComprobacionXLS JOSE SALAZAR

        [OperationContract]
        Int32 InsertarBalanceComprobacionXLS(List<BalanceComprobacionXLSE> oLista);

        [OperationContract]
        Int32 IntegrarBalanceComprobacionXLS(List<BalanceComprobacionXLSE> oListaBalance, Int32 idLocal, DateTime Fecha, String VercionPC, Int32 NivelPC, String Usuario);

        [OperationContract] //JOSE SALAZAR
        Int32 ProcesarBalanceXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String numVerPlanCuentas);

        [OperationContract] //JOSE SALAZAR
        Int32 EliminarBalanceComprobacionXLS(Int32 idEmpresa, Int32 idUsuario);

        #endregion

        #region IPlanContableXLS Members JOSE SALAZAR

        [OperationContract]
        Int32 InsertarPlanContableXLS(List<PlanContableXLSE> oListaPlanContable);

        [OperationContract]
        Int32 ErroresPlanContableXLS(List<PlanContableXLSE> oListaErrores);

        [OperationContract]
        Int32 IntegrarPlanCuentasXLS(List<PlanContableXLSE> oListaPlanContable, String Usuario, String Plan);

        [OperationContract]
        Int32 EliminarPlanContableXLS(List<PlanContableXLSE> oListaPorEliminar);

        #endregion

        #region IPlanCuentasSunat Members JOSE SALAZAR

        [OperationContract]
        PlanCuentasSunatE InsertarPlanCuentasSunat(PlanCuentasSunatE plancuentassunat);

        [OperationContract]
        PlanCuentasSunatE ActualizarPlanCuentasSunat(PlanCuentasSunatE plancuentassunat);

        [OperationContract]
        int EliminarPlanCuentasSunat(String codCuentaSunat);

        [OperationContract]
        List<PlanCuentasSunatE> ListarPlanCuentasSunat();

        [OperationContract]
        PlanCuentasSunatE ObtenerPlanCuentasSunat(String codCuentaSunat);

        [OperationContract]
        List<PlanCuentasSunatE> BuscarPlanCuentasSunat(String codCuentaSunat, String Descripcion);

        #endregion

        #region IBalanceComprobacionSunat Members JOSE SALAZAR

        [OperationContract]
        BalanceComprobacionSunatE InsertarBalanceComprobacionSunat(BalanceComprobacionSunatE balancecomprobacionsunat);

        [OperationContract]
        BalanceComprobacionSunatE ActualizarBalanceComprobacionSunat(BalanceComprobacionSunatE balancecomprobacionsunat);

        [OperationContract]
        int EliminarBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuentaSunat);

        [OperationContract]
        List<BalanceComprobacionSunatE> ListarBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        BalanceComprobacionSunatE ObtenerBalanceComprobacionSunat(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuentaSunat);

        #endregion

        #region ICuentaTasaRenta Members JOSE SALAZAR

        [OperationContract]
        CuentaTasaRentaE InsertarCuentaTasaRenta(CuentaTasaRentaE cuentatasarenta);

        [OperationContract]
        int EliminarCuentaTasaRenta(Int32 idEmpresa, String codCuenta, String numVerPlanCuentas);

        [OperationContract]
        List<CuentaTasaRentaE> ListarCuentaTasaRenta(Int32 idEmpresa, String codCuenta, String numVerPlanCuentas);

        [OperationContract]
        CuentaTasaRentaE ObtenerCuentaTasaRenta(Int32 idEmpresa, String codCuenta, String numVerPlanCuentas, String idTasaRenta);

        #endregion

        #region IActivacion JOSE SALAZAR

        [OperationContract]
        ActivacionE GrabarActivacion(ActivacionE activacion, EnumOpcionGrabar OpcionGrabar);

        [OperationContract]
        ActivacionE InsertarActivacion(ActivacionE activacion);

        [OperationContract]
        ActivacionE ActualizarActivacion(ActivacionE activacion);

        [OperationContract]
        List<ActivacionE> ListarActivacion(Int32 idEmpresa);

        [OperationContract]
        ActivacionE RecuperarActivacionCompleta(Int32 idActivacion, Int32 idEmpresa);

        [OperationContract]
        ActivacionE GenerarVoucherCapitalizacion(Int32 idActivacion, Int32 idEmpresa, Int32 idLocal, String Usuario);

        #endregion

        #region IActivacionDet JOSE SALAZAR

        [OperationContract]
        ActivacionDetE InsertarActivacionDet(ActivacionDetE activaciondet);

        [OperationContract]
        ActivacionDetE ActualizarActivacionDet(ActivacionDetE activaciondet);

        [OperationContract]
        List<ActivacionDetE> ListarActivacionDet(Int32 idActivacion, Int32 idEmpresa);

        #endregion

        #region IRegistroVentasDet Members  JOSE SALAZAR

        [OperationContract]
        RegistroVentasDetE InsertarRegistroVentasDet(RegistroVentasDetE registroventasdet);

        [OperationContract]
        RegistroVentasDetE ActualizarRegistroVentasDet(RegistroVentasDetE registroventasdet);

        [OperationContract]
        int EliminarRegistroVentasDet(Int32 idEmpresa, Int32 idLocal, String idCCostos, String Sistema, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        List<RegistroVentasDetE> ListarRegistroVentasDet(Int32 idEmpresa, Int32 idLocal, String idCCostos, String Sistema, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        RegistroVentasDetE ObtenerRegistroVentasDet();

        #endregion

        #region IRegVentasDetXLS Members JOSE SALAZAR

        [OperationContract]
        Int32 InsertarRegVentasDetXLS(List<RegVentasDetXLSE> RegistroVentas);

        [OperationContract]
        Int32 ErroresRegVentasDetXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario);

        [OperationContract]
        Int32 EliminarRegVentasDetXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario);

        [OperationContract]
        Int32 IntegrarVentasDetXLS(List<RegVentasDetXLSE> ListaRegVentas, String Sistema, String Usuario);

        [OperationContract]
        void GenerarVoucherVentasDet(Int32 idEmpresa, Int32 idLocal, String idCCostos, String Sistema, DateTime fecIni, DateTime fecFin, String Usuario, Int32? ClienteVarios);

        #endregion

        #region IErrorImportGeneral Members JOSE SALAZAR

        [OperationContract]
        ErrorImportGeneralE InsertarErrorImportGeneral(ErrorImportGeneralE errorimportgeneral);

        [OperationContract]
        int EliminarErrorImportGeneral(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Archivo);

        [OperationContract]
        List<ErrorImportGeneralE> ListarErrorImportGeneral(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Archivo);

        [OperationContract]
        int CrearAuxiliares(List<ErrorImportGeneralE> ListaClientesErrores, String Usuario);

        #endregion

        #region IFlujoDeCaja Members JOSE SALAZAR

        [OperationContract]
        List<FlujoDeCajaE> ReporteFlujoCaja(Int32 idEmpresa, Int32 idLocal, String MesAnoIni, String MesAnoFin);

        [OperationContract]
        List<FlujoDeCajaE> ReporteFlujoCajaDetalle(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Movimiento, String Partida);

        #endregion

        #region ICierreAlmacen Members JOSE SALAZAR

        [OperationContract]
        CierreAlmacenE InsertarCierreAlmacen(CierreAlmacenE cierrealmacen);

        [OperationContract]
        CierreAlmacenE ActualizarCierreAlmacen(CierreAlmacenE cierrealmacen);

        [OperationContract]
        int EliminarCierreAlmacen(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen);

        [OperationContract]
        List<CierreAlmacenE> ListarCierreAlmacen(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        CierreAlmacenE ObtenerCierreAlmacen(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idAlmacen);

        #endregion

        #region ICierreSistema Members JOSE SALAZAR

        [OperationContract]
        CierreSistemaE InsertarCierreSistema(CierreSistemaE cierresistema);

        [OperationContract]
        CierreSistemaE ActualizarCierreSistema(CierreSistemaE cierresistema);

        [OperationContract]
        int EliminarCierreSistema(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idSistema);

        [OperationContract]
        List<CierreSistemaE> ListarCierreSistema(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo);

        [OperationContract]
        CierreSistemaE ObtenerCierreSistema(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, Int32 idSistema);

        #endregion

        #region ICostoVenta Members JOSE SALAZAR

        [OperationContract]
        List<CostoVentaE> ReporteCostoVentas(Int32 idEmpresa, int tipAlmacen, String tipoOperacion, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        Int32 GenerarAsientoCostoVentas(Int32 idEmpresa, Int32 idLocal, int tipAlmacen, String tipoOperacion, String RucEmpresa, DateTime fecIni, DateTime fecFin, String Usuario);

        #endregion

        #region IEEFFItemHistorico Members JOSE SALAZAR

        [OperationContract] 
        EEFFItemHistoricoE InsertarEEFFItemHistorico(EEFFItemHistoricoE eeffitemhistorico);

        [OperationContract]
        EEFFItemHistoricoE ActualizarEEFFItemHistorico(EEFFItemHistoricoE eeffitemhistorico);

        [OperationContract]
        int EliminarEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, String AnioPeriodo);

        [OperationContract]
        List<EEFFItemHistoricoE> ListarEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, String AnioPeriodo);

        [OperationContract]
        EEFFItemHistoricoE ObtenerEEFFItemHistorico(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, String AnioPeriodo);

        #endregion

        #region IConciliadoDcmtoPendiente Members JOSE SALAZAR

        [OperationContract]
        List<ConciliadoDcmtoPendienteE> ReporteConciliadoBancos(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuenta);

        [OperationContract]
        List<ConciliadoDcmtoPendienteE> ListarConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta);

        [OperationContract]
        ConciliadoDcmtoPendienteE ActualizarConciliado(ConciliadoDcmtoPendienteE conciliadodcmtopendiente);

        [OperationContract]
        int EliminarConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, Int32 idPersona, String idDocumento, String serDocumento, String numDocumento);

        [OperationContract]
        List<ConciliadoDcmtoPendienteE> GrabarConciliado(List<ConciliadoDcmtoPendienteE> ListaConciliado);

        [OperationContract]
        ConciliadoDcmtoPendienteE ObtenerConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, Int32 idPersona, String idDocumento, String serDocumento, String numDocumento);

        [OperationContract]
        void ProcesoCierreConciliacion(Int32 idEmpresa, Int32 idLocal, String ano_periodo, String cod_periodo);

        [OperationContract]
        List<ConciliadoDcmtoPendienteE> ConciliacionPreliminar(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, String idMoneda); //JOSE SALAZAR

        #endregion

        #region ISaldoSegunBanco Members JOSE SALAZAR

        [OperationContract]
        SaldoSegunBancoE InsertarSaldoSegunBanco(SaldoSegunBancoE saldosegunbanco);

        [OperationContract]
        SaldoSegunBancoE ActualizarSaldoSegunBanco(SaldoSegunBancoE saldosegunbanco);

        [OperationContract]
        int EliminarSaldoSegunBanco(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta);

        [OperationContract]
        List<SaldoSegunBancoE> ListarSaldoSegunBanco();

        [OperationContract]
        SaldoSegunBancoE ObtenerSaldoSegunBanco(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta);

        #endregion

        #region IEEFFRatios Members JOSE SALAZAR

        [OperationContract]
        EEFFRatiosE InsertarEEFFRatios(EEFFRatiosE eeffratios);

        [OperationContract]
        EEFFRatiosE ActualizarEEFFRatios(EEFFRatiosE eeffratios);

        [OperationContract]
        int EliminarEEFFRatios(Int32 idEmpresa, Int32 idItem);

        [OperationContract]
        List<EEFFRatiosE> ListarEEFFRatios(Int32 idEmpresa);

        [OperationContract]
        EEFFRatiosE ObtenerEEFFRatios(Int32 idEmpresa, Int32 idItem);

        #endregion

        #region IBancosConciliar Members JOSE SALAZAR

        [OperationContract]
        BancosConciliarE InsertarBancosConciliar(BancosConciliarE bancosconciliar);

        [OperationContract]
        BancosConciliarE ActualizarBancosConciliar(BancosConciliarE bancosconciliar);

        [OperationContract]
        int EliminarBancosConciliar(Int32 idPersona, Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin, String CodCuenta);

        [OperationContract]
        List<BancosConciliarE> ListarBancosConciliar(Int32 idPersona, Int32 idEmpresa, Int32 AnioPeriodo, Int32 MesPeriodo, String CodCuenta); //JOSE SALAZAR

        #endregion

        #region IRVENTAS Members JOSE SALAZAR

        [OperationContract]
        ImportacionRVentasE InsertarRVENTAS(ImportacionRVentasE rventas);

        [OperationContract]
        ImportacionRVentasE ActualizarRVENTAS(ImportacionRVentasE rventas);

        [OperationContract]
        int EliminarRVENTAS(Int32 idEmpresa, String Libro, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        List<ImportacionRVentasE> ListarRVENTAS();

        [OperationContract]
        ImportacionRVentasE ObtenerRVENTAS();

        [OperationContract]
        int ImportarRVentas(List<ImportacionRVentasE> oMarcacion);

        [OperationContract]
        int GenerarVouchersRVentas(List<ImportacionRVentasE> oListaImportacion, String Usuario, Boolean EliminarVouchers, DateTime fecInicial, DateTime fecFinal);

        #endregion   

    }
}
