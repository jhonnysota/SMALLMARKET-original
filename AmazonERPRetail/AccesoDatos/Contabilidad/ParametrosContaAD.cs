using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ParametrosContaAD : DbConection
    {

        public ParametrosContaE LlenarEntidad(IDataReader oReader)
        {
            ParametrosContaE parametrosconta = new ParametrosContaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlagClave'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.FlagClave = oReader["FlagClave"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlagClave"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VentaS'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.VentaS = oReader["VentaS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VentaS"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VentaD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.VentaD = oReader["VentaD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VentaD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CompraD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.CompraD = oReader["CompraD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CompraD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CompraS'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.CompraS = oReader["CompraS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CompraS"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Perdida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.Perdida = oReader["Perdida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Perdida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ganancia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.Ganancia = oReader["Ganancia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ganancia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Costo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.Costo = oReader["Costo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Costo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indFlag104'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.indFlag104 = oReader["indFlag104"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indFlag104"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indFechaVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.indFechaVoucher = oReader["indFechaVoucher"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indFechaVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ctaDetraccion = oReader["ctaDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaDetraccionDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ctaDetraccionDol = oReader["ctaDetraccionDol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaDetraccionDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDiarioDetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.indDiarioDetra = oReader["indDiarioDetra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDiarioDetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.DiarioDetraccion = oReader["DiarioDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				parametrosconta.FileDetraccion = oReader["FileDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HonorarioCtaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.HonorarioCtaSoles = oReader["HonorarioCtaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["HonorarioCtaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HonorarioCtaDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.HonorarioCtaDolar = oReader["HonorarioCtaDolar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["HonorarioCtaDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioHonorario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioHonorario = oReader["DiarioHonorario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioHonorario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileHonorario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileHonorario = oReader["FileHonorario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileHonorario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuadrar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.indCuadrar = oReader["indCuadrar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuadrar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAnulado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.idAnulado = oReader["idAnulado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAnulado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ctaRenta = oReader["ctaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnticipoS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.AnticipoS = oReader["AnticipoS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnticipoS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnticipoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.AnticipoD = oReader["AnticipoD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnticipoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Transferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.Transferencia = oReader["Transferencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Transferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioLetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioLetra = oReader["DiarioLetra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioLetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileLetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileLetra = oReader["FileLetra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileLetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCtaLetraS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.codCtaLetraS = oReader["codCtaLetraS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCtaLetraS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCtaLetraD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.codCtaLetraD = oReader["codCtaLetraD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCtaLetraD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCtaLetraRespS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.codCtaLetraRespS = oReader["codCtaLetraRespS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCtaLetraRespS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCtaLetraRespD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.codCtaLetraRespD = oReader["codCtaLetraRespD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCtaLetraRespD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioCierre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioCierre = oReader["DiarioCierre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioCierre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileCierreResultado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileCierreResultado = oReader["FileCierreResultado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileCierreResultado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileCierreBalance'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileCierreBalance = oReader["FileCierreBalance"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileCierreBalance"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioRendicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioRendicion = oReader["DiarioRendicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioRendicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileRendicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileRendicion = oReader["FileRendicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileRendicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioLiquiOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioLiquiOtros = oReader["DiarioLiquiOtros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioLiquiOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileLiquiOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileLiquiOtros = oReader["FileLiquiOtros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileLiquiOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MostrarFechaPrint'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.MostrarFechaPrint = oReader["MostrarFechaPrint"] == DBNull.Value ? true : Convert.ToBoolean(oReader["MostrarFechaPrint"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ReporteConci'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ReporteConci = oReader["ReporteConci"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ReporteConci"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaVinculadaSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ctaVinculadaSol = oReader["ctaVinculadaSol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaVinculadaSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaVinculadaDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ctaVinculadaDol = oReader["ctaVinculadaDol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaVinculadaDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEliminarVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.indEliminarVoucher = oReader["indEliminarVoucher"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEliminarVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAuxiliarVarios'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.idAuxiliarVarios = oReader["idAuxiliarVarios"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAuxiliarVarios"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCtaLiquiSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.codCtaLiquiSol = oReader["codCtaLiquiSol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCtaLiquiSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCtaLiquiDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.codCtaLiquiDol = oReader["codCtaLiquiDol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCtaLiquiDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioLiqui = oReader["DiarioLiqui"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FileLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FileLiqui = oReader["FileLiqui"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FileLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioIngresos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioIngresos = oReader["DiarioIngresos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioIngresos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiarioEgresos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.DiarioEgresos = oReader["DiarioEgresos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DiarioEgresos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivelCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.numNivelCCosto = oReader["numNivelCCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivelCCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVentaS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desVentaS = oReader["desVentaS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVentaS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVentaD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desVentaD = oReader["desVentaD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVentaD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCompraD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCompraD = oReader["desCompraD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCompraD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCompraS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCompraS = oReader["desCompraS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCompraS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPerdida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desPerdida = oReader["desPerdida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPerdida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGanancia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desGanancia = oReader["desGanancia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGanancia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaDetraccion = oReader["desCtaDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDetraccionDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaDetraccionDol = oReader["desCtaDetraccionDol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDetraccionDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaHonorarioSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaHonorarioSoles = oReader["desCtaHonorarioSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaHonorarioSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaHonorarioDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaHonorarioDolar = oReader["desCtaHonorarioDolar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaHonorarioDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaRenta = oReader["desCtaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAnticipoS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desAnticipoS = oReader["desAnticipoS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAnticipoS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAnticipoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desAnticipoD = oReader["desAnticipoD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAnticipoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTransferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desTransferencia = oReader["desTransferencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTransferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaLetraS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaLetraS = oReader["desCtaLetraS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaLetraS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaLetraD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaLetraD = oReader["desCtaLetraD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaLetraD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaLetraRespS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaLetraRespS = oReader["desCtaLetraRespS"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaLetraRespS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaLetraRespD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaLetraRespD = oReader["desCtaLetraRespD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaLetraRespD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorReporteConci'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.ValorReporteConci = oReader["ValorReporteConci"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ValorReporteConci"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaVinculadaSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaVinculadaSol = oReader["desCtaVinculadaSol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaVinculadaSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaVinculadaDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaVinculadaDol = oReader["desCtaVinculadaDol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaVinculadaDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAnulado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desAnulado = oReader["desAnulado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAnulado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVarios'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desVarios = oReader["desVarios"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVarios"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaLiquiSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaLiquiSol = oReader["desCtaLiquiSol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaLiquiSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaLiquiDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametrosconta.desCtaLiquiDol = oReader["desCtaLiquiDol"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaLiquiDol"]);

            return  parametrosconta;        
        }

        public ParametrosContaE InsertarParametrosConta(ParametrosContaE parametrosconta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarParametrosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametrosconta.idEmpresa;
					oComando.Parameters.Add("@FlagClave", SqlDbType.Bit).Value = parametrosconta.FlagClave;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = parametrosconta.numVerPlanCuentas;
					oComando.Parameters.Add("@VentaS", SqlDbType.VarChar, 9).Value = parametrosconta.VentaS;
					oComando.Parameters.Add("@VentaD", SqlDbType.VarChar, 9).Value = parametrosconta.VentaD;
					oComando.Parameters.Add("@CompraD", SqlDbType.VarChar, 9).Value = parametrosconta.CompraD;
					oComando.Parameters.Add("@CompraS", SqlDbType.VarChar, 9).Value = parametrosconta.CompraS;
					oComando.Parameters.Add("@Perdida", SqlDbType.VarChar, 9).Value = parametrosconta.Perdida;
					oComando.Parameters.Add("@Ganancia", SqlDbType.VarChar, 9).Value = parametrosconta.Ganancia;
                    oComando.Parameters.Add("@numNivelCCosto", SqlDbType.Int).Value = parametrosconta.numNivelCCosto;
                    oComando.Parameters.Add("@Costo", SqlDbType.VarChar, 9).Value = parametrosconta.Costo;
					oComando.Parameters.Add("@indFlag104", SqlDbType.Bit).Value = parametrosconta.indFlag104;
					oComando.Parameters.Add("@indFechaVoucher", SqlDbType.Bit).Value = parametrosconta.indFechaVoucher;
					oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = parametrosconta.indDetraccion;
                    oComando.Parameters.Add("@ctaDetraccion", SqlDbType.VarChar, 20).Value = parametrosconta.ctaDetraccion;
                    oComando.Parameters.Add("@ctaDetraccionDol", SqlDbType.VarChar, 20).Value = parametrosconta.ctaDetraccionDol;
                    oComando.Parameters.Add("@indDiarioDetra", SqlDbType.Bit).Value = parametrosconta.indDiarioDetra;
                    oComando.Parameters.Add("@DiarioDetraccion", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioDetraccion;
					oComando.Parameters.Add("@FileDetraccion", SqlDbType.VarChar, 2).Value = parametrosconta.FileDetraccion;
                    oComando.Parameters.Add("@HonorarioCtaSoles", SqlDbType.VarChar, 20).Value = parametrosconta.HonorarioCtaSoles;
                    oComando.Parameters.Add("@HonorarioCtaDolar", SqlDbType.VarChar, 20).Value = parametrosconta.HonorarioCtaDolar;
                    oComando.Parameters.Add("@DiarioHonorario", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioHonorario;
                    oComando.Parameters.Add("@FileHonorario", SqlDbType.VarChar, 2).Value = parametrosconta.FileHonorario;
                    oComando.Parameters.Add("@indCuadrar", SqlDbType.Bit).Value = parametrosconta.indCuadrar;
                    oComando.Parameters.Add("@idAnulado", SqlDbType.Int).Value = parametrosconta.idAnulado;
                    oComando.Parameters.Add("@desAnulado", SqlDbType.VarChar, 20).Value = parametrosconta.desAnulado;
                    oComando.Parameters.Add("@ctaRenta", SqlDbType.VarChar, 20).Value = parametrosconta.ctaRenta;
                    oComando.Parameters.Add("@AnticipoS", SqlDbType.VarChar, 20).Value = parametrosconta.AnticipoS;
                    oComando.Parameters.Add("@AnticipoD", SqlDbType.VarChar, 20).Value = parametrosconta.AnticipoD;
                    oComando.Parameters.Add("@Transferencia", SqlDbType.VarChar, 20).Value = parametrosconta.Transferencia;
                    oComando.Parameters.Add("@DiarioLetra", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioLetra;
                    oComando.Parameters.Add("@FileLetra", SqlDbType.VarChar, 2).Value = parametrosconta.FileLetra;
                    oComando.Parameters.Add("@codCtaLetraS", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraS;
                    oComando.Parameters.Add("@codCtaLetraD", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraD;
                    oComando.Parameters.Add("@codCtaLetraRespS", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraRespS;
                    oComando.Parameters.Add("@codCtaLetraRespD", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraRespD;
                    oComando.Parameters.Add("@DiarioCierre", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioCierre;
                    oComando.Parameters.Add("@FileCierreResultado", SqlDbType.VarChar, 2).Value = parametrosconta.FileCierreResultado;
                    oComando.Parameters.Add("@FileCierreBalance", SqlDbType.VarChar, 2).Value = parametrosconta.FileCierreBalance;
                    oComando.Parameters.Add("@DiarioRendicion", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioRendicion;
                    oComando.Parameters.Add("@FileRendicion", SqlDbType.VarChar, 2).Value = parametrosconta.FileRendicion;
                    oComando.Parameters.Add("@DiarioLiquiOtros", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioLiquiOtros;
                    oComando.Parameters.Add("@FileLiquiOtros", SqlDbType.VarChar, 2).Value = parametrosconta.FileLiquiOtros;
                    oComando.Parameters.Add("@MostrarFechaPrint", SqlDbType.Bit).Value = parametrosconta.MostrarFechaPrint;
                    oComando.Parameters.Add("@ReporteConci", SqlDbType.Int).Value = parametrosconta.ReporteConci;
                    oComando.Parameters.Add("@ctaVinculadaSol", SqlDbType.VarChar, 20).Value = parametrosconta.ctaVinculadaSol;
                    oComando.Parameters.Add("@ctaVinculadaDol", SqlDbType.VarChar, 20).Value = parametrosconta.ctaVinculadaDol;
                    oComando.Parameters.Add("@indEliminarVoucher", SqlDbType.Bit).Value = parametrosconta.indEliminarVoucher;
                    oComando.Parameters.Add("@idAuxiliarVarios", SqlDbType.Int).Value = parametrosconta.idAuxiliarVarios;
                    oComando.Parameters.Add("@codCtaLiquiSol", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLiquiSol;
                    oComando.Parameters.Add("@codCtaLiquiDol", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLiquiDol;
                    oComando.Parameters.Add("@DiarioLiqui", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioLiqui;
                    oComando.Parameters.Add("@FileLiqui", SqlDbType.VarChar, 2).Value = parametrosconta.FileLiqui;
                    oComando.Parameters.Add("@DiarioIngresos", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioIngresos;
                    oComando.Parameters.Add("@DiarioEgresos", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioEgresos;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = parametrosconta.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametrosconta;
        }
        
        public ParametrosContaE ActualizarParametrosConta(ParametrosContaE parametrosconta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarParametrosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametrosconta.idEmpresa;
                    oComando.Parameters.Add("@FlagClave", SqlDbType.Bit).Value = parametrosconta.FlagClave;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = parametrosconta.numVerPlanCuentas;
                    oComando.Parameters.Add("@VentaS", SqlDbType.VarChar, 9).Value = parametrosconta.VentaS;
                    oComando.Parameters.Add("@VentaD", SqlDbType.VarChar, 9).Value = parametrosconta.VentaD;
                    oComando.Parameters.Add("@CompraD", SqlDbType.VarChar, 9).Value = parametrosconta.CompraD;
                    oComando.Parameters.Add("@CompraS", SqlDbType.VarChar, 9).Value = parametrosconta.CompraS;
                    oComando.Parameters.Add("@Perdida", SqlDbType.VarChar, 9).Value = parametrosconta.Perdida;
                    oComando.Parameters.Add("@Ganancia", SqlDbType.VarChar, 9).Value = parametrosconta.Ganancia;
                    oComando.Parameters.Add("@numNivelCCosto", SqlDbType.Int).Value = parametrosconta.numNivelCCosto;
                    oComando.Parameters.Add("@Costo", SqlDbType.VarChar, 9).Value = parametrosconta.Costo;
                    oComando.Parameters.Add("@indFlag104", SqlDbType.Bit).Value = parametrosconta.indFlag104;
                    oComando.Parameters.Add("@indFechaVoucher", SqlDbType.Bit).Value = parametrosconta.indFechaVoucher;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = parametrosconta.indDetraccion;
                    oComando.Parameters.Add("@indDiarioDetra", SqlDbType.Bit).Value = parametrosconta.indDiarioDetra;
                    oComando.Parameters.Add("@ctaDetraccion", SqlDbType.VarChar, 20).Value = parametrosconta.ctaDetraccion;
                    oComando.Parameters.Add("@ctaDetraccionDol", SqlDbType.VarChar, 20).Value = parametrosconta.ctaDetraccionDol;
                    oComando.Parameters.Add("@DiarioDetraccion", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioDetraccion;
                    oComando.Parameters.Add("@FileDetraccion", SqlDbType.VarChar, 2).Value = parametrosconta.FileDetraccion;
                    oComando.Parameters.Add("@HonorarioCtaSoles", SqlDbType.VarChar, 20).Value = parametrosconta.HonorarioCtaSoles;
                    oComando.Parameters.Add("@HonorarioCtaDolar", SqlDbType.VarChar, 20).Value = parametrosconta.HonorarioCtaDolar;
                    oComando.Parameters.Add("@DiarioHonorario", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioHonorario;
                    oComando.Parameters.Add("@FileHonorario", SqlDbType.VarChar, 2).Value = parametrosconta.FileHonorario;
                    oComando.Parameters.Add("@indCuadrar", SqlDbType.Bit).Value = parametrosconta.indCuadrar;
                    oComando.Parameters.Add("@idAnulado", SqlDbType.Int).Value = parametrosconta.idAnulado;
                    oComando.Parameters.Add("@desAnulado", SqlDbType.VarChar, 20).Value = parametrosconta.desAnulado;
                    oComando.Parameters.Add("@ctaRenta", SqlDbType.VarChar, 20).Value = parametrosconta.ctaRenta;
                    oComando.Parameters.Add("@AnticipoS", SqlDbType.VarChar, 20).Value = parametrosconta.AnticipoS;
                    oComando.Parameters.Add("@AnticipoD", SqlDbType.VarChar, 20).Value = parametrosconta.AnticipoD;
                    oComando.Parameters.Add("@Transferencia", SqlDbType.VarChar, 20).Value = parametrosconta.Transferencia;
                    oComando.Parameters.Add("@DiarioLetra", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioLetra;
                    oComando.Parameters.Add("@FileLetra", SqlDbType.VarChar, 2).Value = parametrosconta.FileLetra;
                    oComando.Parameters.Add("@codCtaLetraS", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraS;
                    oComando.Parameters.Add("@codCtaLetraD", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraD;
                    oComando.Parameters.Add("@codCtaLetraRespS", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraRespS;
                    oComando.Parameters.Add("@codCtaLetraRespD", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLetraRespD;
                    oComando.Parameters.Add("@DiarioCierre", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioCierre;
                    oComando.Parameters.Add("@FileCierreResultado", SqlDbType.VarChar, 2).Value = parametrosconta.FileCierreResultado;
                    oComando.Parameters.Add("@FileCierreBalance", SqlDbType.VarChar, 2).Value = parametrosconta.FileCierreBalance;
                    oComando.Parameters.Add("@DiarioRendicion", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioRendicion;
                    oComando.Parameters.Add("@FileRendicion", SqlDbType.VarChar, 2).Value = parametrosconta.FileRendicion;
                    oComando.Parameters.Add("@DiarioLiquiOtros", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioLiquiOtros;
                    oComando.Parameters.Add("@FileLiquiOtros", SqlDbType.VarChar, 2).Value = parametrosconta.FileLiquiOtros;
                    oComando.Parameters.Add("@MostrarFechaPrint", SqlDbType.Bit).Value = parametrosconta.MostrarFechaPrint;
                    oComando.Parameters.Add("@ReporteConci", SqlDbType.Int).Value = parametrosconta.ReporteConci;
                    oComando.Parameters.Add("@ctaVinculadaSol", SqlDbType.VarChar, 20).Value = parametrosconta.ctaVinculadaSol;
                    oComando.Parameters.Add("@ctaVinculadaDol", SqlDbType.VarChar, 20).Value = parametrosconta.ctaVinculadaDol;
                    oComando.Parameters.Add("@indEliminarVoucher", SqlDbType.Bit).Value = parametrosconta.indEliminarVoucher;
                    oComando.Parameters.Add("@idAuxiliarVarios", SqlDbType.Int).Value = parametrosconta.idAuxiliarVarios;
                    oComando.Parameters.Add("@codCtaLiquiSol", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLiquiSol;
                    oComando.Parameters.Add("@codCtaLiquiDol", SqlDbType.VarChar, 20).Value = parametrosconta.codCtaLiquiDol;
                    oComando.Parameters.Add("@DiarioLiqui", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioLiqui;
                    oComando.Parameters.Add("@FileLiqui", SqlDbType.VarChar, 2).Value = parametrosconta.FileLiqui;
                    oComando.Parameters.Add("@DiarioIngresos", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioIngresos;
                    oComando.Parameters.Add("@DiarioEgresos", SqlDbType.VarChar, 2).Value = parametrosconta.DiarioEgresos;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = parametrosconta.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametrosconta;
        }        

        public Int32 EliminarParametrosConta(Int32 idEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarParametrosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ParametrosContaE> ListarParametrosConta()
        {
            List<ParametrosContaE> listaEntidad = new List<ParametrosContaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParametrosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ParametrosContaE> ListarParametroContaNivel(Int32 idEmpresa)
        {
            List<ParametrosContaE> listaEntidad = new List<ParametrosContaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParametroContaNivel", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public ParametrosContaE ObtenerParametrosConta(Int32 idEmpresa)
        {        
            ParametrosContaE parametrosconta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerParametrosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            parametrosconta = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return parametrosconta;
        }

    }
}