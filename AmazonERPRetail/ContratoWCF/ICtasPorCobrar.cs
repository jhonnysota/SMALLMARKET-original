using System;
using System.Collections.Generic;
using System.ServiceModel;

using Entidades.CtasPorCobrar;
using Infraestructura.Enumerados;

namespace ContratoWCF
{

    [ServiceContract]
    public interface ICtasPorCobrar
    {

        #region ICobranzas Members JOSE SALAZAR

        [OperationContract]
        CobranzasE GrabarCobranzas(CobranzasE oCobranza, EnumOpcionGrabar Opcion);

        [OperationContract]
        CobranzasE InsertarCobranzas(CobranzasE cobranzas);

        [OperationContract]
        CobranzasE ActualizarCobranzas(CobranzasE cobranzas);

        [OperationContract]
        Int32 EliminarCobranzas(CobranzasE cobranzas);

        [OperationContract]
        List<CobranzasE> ListarCobranzas(Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        CobranzasE ObtenerCobranzas(Int32 idPlanilla, String ConDetalle = "S");

        [OperationContract]
        String CerrarPlanillas(Int32 idPlanilla, Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String Usuario, String TipoPlanilla);

        [OperationContract]
        Int32 ActualizarEstadoCobranzas(Int32 idPlanilla, String numVoucher, Boolean EstadoDoc, String UsuarioModificacion);

        [OperationContract]
        Int32 AbrirPlanilla(CobranzasE oCobranza, Boolean Estado, String Usuario, String TipoPlanilla);

        [OperationContract]
        Int32 LimpiarCobranzasVoucher(Int32 idPlanilla, String UsuarioModificacion);

        [OperationContract]
        Boolean RevisarPlanillaCancelacion(List<CobranzasItemDetE> ListaLetrasCobranzas, Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla);

        [OperationContract]
        Boolean CombinarPlanillas(List<CobranzasE> ListaCobranzas, String Usuario);

        #endregion

        #region ICobranzasItem Members JOSE SALAZAR

        [OperationContract]
        CobranzasItemE InsertarCobranzasItem(CobranzasItemE cobranzasitem);

        [OperationContract]
        CobranzasItemE ActualizarCobranzasItem(CobranzasItemE cobranzasitem);

        [OperationContract]
        List<CobranzasItemE> ListarCobranzasItem(Int32 idPlanilla, Int32 idEmpresa);

        [OperationContract]
        int EliminarCobranzasItem(Int32 Recibo);

        [OperationContract]
        CobranzasItemE ObtenerCobranzasItem(Int32 Recibo);

        [OperationContract]
        List<CobranzasItemE> ListarCobranzasItemPorCuenta(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, DateTime fecIni, DateTime fecFin);

        [OperationContract]
        Int32 ActualizarCobranzasItemConciliado(Int32 idPlanilla, Int32 Recibo, Boolean indConciliado);

        [OperationContract]
        List<CobranzasItemE> ReporteCobranzasConciliados(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, DateTime fecIni, DateTime fecFin, Int32 TipoReporte); 

        #endregion

        #region ICobranzasItemDet Members JOSE SALAZAR

        [OperationContract]
        CobranzasItemDetE InsertarCobranzasItemDet(CobranzasItemDetE cobranzasitemdet);

        [OperationContract]
        CobranzasItemDetE ActualizarCobranzasItemDet(CobranzasItemDetE cobranzasitemdet);

        [OperationContract]
        int EliminarCobranzasItemDet(Int32 idPlanilla, Int32 Recibo, Int32 item);

        [OperationContract]
        List<CobranzasItemDetE> ListarCobranzasItemDet(Int32 idPlanilla, Int32 Recibo);

        [OperationContract]
        CobranzasItemDetE ObtenerCobranzasItemDet(Int32 idPlanilla, Int32 Recibo, Int32 item);

        [OperationContract]
        List<CobranzasItemDetE> ListarCobranzasItemDetPorLetra(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numLetra); //JOSE SALAZAR

        [OperationContract]
        List<CobranzasItemDetE> ListarCobranzasLetrasPorPlanilla(Int32 idPlanilla); //JOSE SALAZAR


        #endregion

        #region ITipoIngresos Members JOSE SALAZAR

        [OperationContract]
        TipoIngresosE GrabarTipoIngresos(TipoIngresosE tipoingresos, EnumOpcionGrabar Opcion); //JOSE SALAZAR

        [OperationContract]
        TipoIngresosE InsertarTipoIngresos(TipoIngresosE tipoingresos);

        [OperationContract]
        TipoIngresosE ActualizarTipoIngresos(TipoIngresosE tipoingresos);

        [OperationContract]
        int EliminarTipoIngresos(Int32 idEmpresa, String TipoCobro);

        [OperationContract]
        List<TipoIngresosE> ListarTipoIngresos(Int32 idEmpresa);

        [OperationContract]
        TipoIngresosE ObtenerTipoIngresos(Int32 idEmpresa, String TipoCobro, String ConDetalle = "N"); //JOSE SALAZAR

        [OperationContract]
        Int32 CopiarTipoIngresos(Int32 idEmpresaDe, Int32 idEmpresaA, String UsuarioRegistro); //JOSE SALAZAR

        [OperationContract]
        List<TipoIngresosE> ListarEmpresaTipIng(Int32 idEmpresa); //JOSE SALAZAR

        [OperationContract]
        List<TipoIngresosE> TipoIngresosCombos(Int32 idEmpresa); //JOSE SALAZAR

        #endregion

        #region ITipoIngresosDet Members JOSE SALAZAR

        [OperationContract]
        TipoIngresosDetE InsertarTipoIngresosDet(TipoIngresosDetE tipoingresosdet);

        [OperationContract]
        TipoIngresosDetE ActualizarTipoIngresosDet(TipoIngresosDetE tipoingresosdet);

        [OperationContract]
        int EliminarTipoIngresosDet(Int32 idEmpresa, String TipoCobro, Int32 TipoPlanilla);

        [OperationContract]
        List<TipoIngresosDetE> ListarTipoIngresosDet(Int32 idEmpresa, String TipoCobro);

        [OperationContract]
        TipoIngresosDetE ObtenerTipoIngresosDet(Int32 idEmpresa, String TipoCobro, Int32 TipoPlanilla);

        [OperationContract]
        TipoIngresosDetE ObtenerTipoIngresosDetPorPlanilla(Int32 idEmpresa, Int32 TipoPlanilla);


        #endregion

        #region ICobranzasConciliacion Members JOSE SALAZAR

        [OperationContract]
        CobranzasConciliacionE InsertarCobranzasConciliacion(CobranzasConciliacionE cobranzasconciliacion);

        [OperationContract]
        CobranzasConciliacionE ActualizarCobranzasConciliacion(CobranzasConciliacionE cobranzasconciliacion);

        [OperationContract]
        Int32 EliminarCobranzasConciliacion(Int32 idPersona, Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String codCuenta);

        [OperationContract]
        List<CobranzasConciliacionE> ListarCobranzasConciliacion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String codCuenta);

        [OperationContract]
        CobranzasConciliacionE ObtenerCobranzasConciliacion(Int32 numitem);

        #endregion

    }
}
