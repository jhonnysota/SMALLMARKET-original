using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlanCuentasAD : DbConection
    {

        public PlanCuentasE LlenarEntidad(IDataReader oReader)
        {
            PlanCuentasE plancuentas = new PlanCuentasE();
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaSunat = oReader["codCuentaSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipAjuste'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.tipAjuste = oReader["tipAjuste"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipAjuste"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indNaturalezaCta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indNaturalezaCta = oReader["indNaturalezaCta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indNaturalezaCta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaGastos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indCuentaGastos = oReader["indCuentaGastos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCuentaGastos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBalance'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indBalance = oReader["indBalance"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["indBalance"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indSolicitaAnexo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indSolicitaAnexo = oReader["indSolicitaAnexo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indSolicitaAnexo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indSolicitaCentroCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indSolicitaCentroCosto = oReader["indSolicitaCentroCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indSolicitaCentroCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAjuste_X_Cambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indAjuste_X_Cambio = oReader["indAjuste_X_Cambio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indAjuste_X_Cambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCambio_X_Compra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indCambio_X_Compra = oReader["indCambio_X_Compra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCambio_X_Compra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaSup'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaSup = oReader["codCuentaSup"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaSup"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaTransferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaTransferencia = oReader["codCuentaTransferencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaTransferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaGanancia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaGanancia = oReader["codCuentaGanancia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaGanancia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaPerdida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaPerdida = oReader["codCuentaPerdida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaPerdida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indSolicitaDcto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indSolicitaDcto = oReader["indSolicitaDcto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indSolicitaDcto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indCtaCte = oReader["indCtaCte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipTituloNodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.tipTituloNodo = oReader["tipTituloNodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipTituloNodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUltNodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indUltNodo = oReader["indUltNodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUltNodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaCierre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indCuentaCierre = oReader["indCuentaCierre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCuentaCierre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaCieDeb'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuentaCieDeb = oReader["codCuentaCieDeb"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaCieDeb"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaCoven'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codColumnaCoven = oReader["codColumnaCoven"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indNotaIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indNotaIngreso = oReader["indNotaIngreso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indNotaIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAnexoReferencial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indAnexoReferencial = oReader["indAnexoReferencial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indAnexoReferencial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCajaChica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indCajaChica = oReader["indCajaChica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCajaChica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoCajaChica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.tipoCajaChica = oReader["tipoCajaChica"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipoCajaChica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCtaIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indCtaIngreso = oReader["indCtaIngreso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCtaIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioAsignado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.UsuarioAsignado = oReader["UsuarioAsignado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioAsignado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.numFile = oReader["numFile"] == DBNull.Value ? "0" : Convert.ToString(oReader["numFile"]).Trim();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTasaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indTasaRenta = oReader["indTasaRenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTasaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTasaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idTasaRenta = oReader["idTasaRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTasaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReporteDs'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.indReporteDs = oReader["indReporteDs"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReporteDs"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Titulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Titulo = oReader["Titulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Titulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idAuxiliar = oReader["idAuxiliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Digitos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Digitos = oReader["Digitos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Digitos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desColumnaCoVen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desColumnaCoVen = oReader["desColumnaCoVen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desColumnaCoVen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBalance'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desBalance = oReader["desBalance"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBalance"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipAjuste'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desTipAjuste = oReader["desTipAjuste"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipAjuste"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Periodo = oReader["Periodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Periodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlan'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codPlan = oReader["codPlan"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlan"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPlan'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desPlan = oReader["desPlan"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPlan"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.TasaRenta = oReader["TasaRenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaTemp = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]) + "-" + Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaTemp = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]) + "-" + Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nemo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Nemo = oReader["Nemo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nemo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaSup'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaSup = oReader["desCuentaSup"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaSup"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaDestino = oReader["desCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaTransfe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaTransfe = oReader["desCuentaTransfe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaTransfe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaGanancia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaGanancia = oReader["desCuentaGanancia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaGanancia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaPerdida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaPerdida = oReader["desCuentaPerdida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaPerdida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaCieDeb'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.desCuentaCieDeb = oReader["desCuentaCieDeb"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaCieDeb"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCuentaSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.nomCuentaSunat = oReader["nomCuentaSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCuentaSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoInicialDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.SaldoInicialDebe = oReader["SaldoInicialDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoInicialDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoInicialHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.SaldoInicialHaber = oReader["SaldoInicialHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoInicialHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MovimientoDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.MovimientoDebe = oReader["MovimientoDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MovimientoDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MovimientoHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.MovimientoHaber = oReader["MovimientoHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MovimientoHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SumasMayorDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.SumasMayorDebe = oReader["SumasMayorDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SumasMayorDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SumasMayorHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.SumasMayorHaber = oReader["SumasMayorHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SumasMayorHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.SaldoHaber = oReader["SaldoHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.SaldoDebe = oReader["SaldoDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TransCancDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.TransCancDebe = oReader["TransCancDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TransCancDebe"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TransCancHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.TransCancHaber = oReader["TransCancHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TransCancHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BalanceActivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.BalanceActivo = oReader["BalanceActivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BalanceActivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BalancePasivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.BalancePasivo = oReader["BalancePasivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BalancePasivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RPNaturalezaPerdida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.RPNaturalezaPerdida = oReader["RPNaturalezaPerdida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RPNaturalezaPerdida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RPNaturalezaGanancia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.RPNaturalezaGanancia = oReader["RPNaturalezaGanancia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RPNaturalezaGanancia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Adiciones'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Adiciones = oReader["Adiciones"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Adiciones"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Deducciones'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Deducciones = oReader["Deducciones"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Deducciones"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Abrev'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Abrev = oReader["Abrev"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Abrev"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);


            return plancuentas;
        }

        public PlanCuentasE InsertarPlanCuentas(PlanCuentasE plancuentas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentas.idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentas.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plancuentas.codCuenta;
                    oComando.Parameters.Add("@tipAjuste", SqlDbType.Int).Value = plancuentas.tipAjuste;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = plancuentas.Descripcion;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = plancuentas.idMoneda;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = plancuentas.numNivel;
                    oComando.Parameters.Add("@indNaturalezaCta", SqlDbType.Char, 1).Value = plancuentas.indNaturalezaCta;
                    oComando.Parameters.Add("@indCuentaGastos", SqlDbType.Char, 1).Value = plancuentas.indCuentaGastos;
                    oComando.Parameters.Add("@indBalance", SqlDbType.Int).Value = plancuentas.indBalance;
                    oComando.Parameters.Add("@indSolicitaAnexo", SqlDbType.Char, 1).Value = plancuentas.indSolicitaAnexo;
                    oComando.Parameters.Add("@indSolicitaCentroCosto", SqlDbType.Char, 1).Value = plancuentas.indSolicitaCentroCosto;
                    oComando.Parameters.Add("@indAjuste_X_Cambio", SqlDbType.Char, 1).Value = plancuentas.indAjuste_X_Cambio;
                    oComando.Parameters.Add("@indCambio_X_Compra", SqlDbType.Char, 1).Value = plancuentas.indCambio_X_Compra;
                    oComando.Parameters.Add("@codCuentaSup", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaSup;
                    oComando.Parameters.Add("@codCuentaDestino", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaDestino;
                    oComando.Parameters.Add("@codCuentaTransferencia", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaTransferencia;
                    oComando.Parameters.Add("@codCuentaGanancia", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaGanancia;
                    oComando.Parameters.Add("@codCuentaPerdida", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaPerdida;
                    oComando.Parameters.Add("@indSolicitaDcto", SqlDbType.VarChar, 1).Value = plancuentas.indSolicitaDcto;
                    oComando.Parameters.Add("@indCtaCte", SqlDbType.VarChar, 1).Value = plancuentas.indCtaCte;
                    oComando.Parameters.Add("@tipTituloNodo", SqlDbType.VarChar, 2).Value = plancuentas.tipTituloNodo;
                    oComando.Parameters.Add("@indUltNodo", SqlDbType.Char, 1).Value = plancuentas.indUltNodo;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.Char, 2).Value = plancuentas.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = plancuentas.codPartidaPresu;
                    oComando.Parameters.Add("@indCuentaCierre", SqlDbType.VarChar, 1).Value = plancuentas.indCuentaCierre;
                    oComando.Parameters.Add("@codCuentaCieDeb", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaCieDeb;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = plancuentas.codColumnaCoven;
                    oComando.Parameters.Add("@indNotaIngreso", SqlDbType.Char, 1).Value = plancuentas.indNotaIngreso;
                    oComando.Parameters.Add("@indAnexoReferencial", SqlDbType.Char, 1).Value = plancuentas.indAnexoReferencial;
                    oComando.Parameters.Add("@indCajaChica", SqlDbType.Char, 1).Value = plancuentas.indCajaChica;
                    oComando.Parameters.Add("@tipoCajaChica", SqlDbType.Int).Value = plancuentas.tipoCajaChica;
                    oComando.Parameters.Add("@indCtaIngreso", SqlDbType.VarChar, 1).Value = plancuentas.indCtaIngreso;
                    oComando.Parameters.Add("@indTasaRenta", SqlDbType.Bit).Value = plancuentas.indTasaRenta;
                    oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = plancuentas.idTasaRenta;
                    oComando.Parameters.Add("@indReporteDs", SqlDbType.Bit).Value = plancuentas.indReporteDs;
                    oComando.Parameters.Add("@Titulo", SqlDbType.VarChar, 20).Value = plancuentas.Titulo;
                    oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = plancuentas.idAuxiliar;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = plancuentas.idCCostos;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = plancuentas.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentas;
        }

        public PlanCuentasE ActualizarPlanCuentas(PlanCuentasE plancuentas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentas.idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentas.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plancuentas.codCuenta;
                    oComando.Parameters.Add("@tipAjuste", SqlDbType.Int).Value = plancuentas.tipAjuste;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = plancuentas.Descripcion;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = plancuentas.idMoneda;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = plancuentas.numNivel;
                    oComando.Parameters.Add("@indNaturalezaCta", SqlDbType.Char, 1).Value = plancuentas.indNaturalezaCta;
                    oComando.Parameters.Add("@indCuentaGastos", SqlDbType.Char, 1).Value = plancuentas.indCuentaGastos;
                    oComando.Parameters.Add("@indBalance", SqlDbType.Int).Value = plancuentas.indBalance;
                    oComando.Parameters.Add("@indSolicitaAnexo", SqlDbType.Char, 1).Value = plancuentas.indSolicitaAnexo;
                    oComando.Parameters.Add("@indSolicitaCentroCosto", SqlDbType.Char, 1).Value = plancuentas.indSolicitaCentroCosto;
                    oComando.Parameters.Add("@indAjuste_X_Cambio", SqlDbType.Char, 1).Value = plancuentas.indAjuste_X_Cambio;
                    oComando.Parameters.Add("@indCambio_X_Compra", SqlDbType.Char, 1).Value = plancuentas.indCambio_X_Compra;
                    oComando.Parameters.Add("@codCuentaSup", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaSup;
                    oComando.Parameters.Add("@codCuentaDestino", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaDestino;
                    oComando.Parameters.Add("@codCuentaTransferencia", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaTransferencia;
                    oComando.Parameters.Add("@codCuentaGanancia", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaGanancia;
                    oComando.Parameters.Add("@codCuentaPerdida", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaPerdida;
					oComando.Parameters.Add("@indSolicitaDcto", SqlDbType.VarChar, 1).Value = plancuentas.indSolicitaDcto;
					oComando.Parameters.Add("@indCtaCte", SqlDbType.VarChar, 1).Value = plancuentas.indCtaCte;
					oComando.Parameters.Add("@tipTituloNodo", SqlDbType.VarChar, 2).Value = plancuentas.tipTituloNodo;
					oComando.Parameters.Add("@indUltNodo", SqlDbType.Char, 1).Value = plancuentas.indUltNodo;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.Char, 2).Value = plancuentas.tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = plancuentas.codPartidaPresu;
					oComando.Parameters.Add("@indCuentaCierre", SqlDbType.VarChar, 1).Value = plancuentas.indCuentaCierre;
					oComando.Parameters.Add("@codCuentaCieDeb", SqlDbType.VarChar, 20).Value = plancuentas.codCuentaCieDeb;
					oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = plancuentas.codColumnaCoven;
					oComando.Parameters.Add("@indNotaIngreso", SqlDbType.Char, 1).Value = plancuentas.indNotaIngreso;
					oComando.Parameters.Add("@indAnexoReferencial", SqlDbType.Char, 1).Value = plancuentas.indAnexoReferencial;
					oComando.Parameters.Add("@indCajaChica", SqlDbType.Char, 1).Value = plancuentas.indCajaChica;
					oComando.Parameters.Add("@tipoCajaChica", SqlDbType.Int).Value = plancuentas.tipoCajaChica;
					oComando.Parameters.Add("@indCtaIngreso", SqlDbType.VarChar, 1).Value = plancuentas.indCtaIngreso;
                    oComando.Parameters.Add("@indTasaRenta", SqlDbType.Bit).Value = plancuentas.indTasaRenta;
                    oComando.Parameters.Add("@idTasaRenta", SqlDbType.VarChar, 2).Value = plancuentas.idTasaRenta;
                    oComando.Parameters.Add("@indReporteDs", SqlDbType.Bit).Value = plancuentas.indReporteDs;
                    oComando.Parameters.Add("@Titulo", SqlDbType.VarChar, 20).Value = plancuentas.Titulo;
                    oComando.Parameters.Add("@idAuxiliar", SqlDbType.Int).Value = plancuentas.idAuxiliar;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = plancuentas.idCCostos;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = plancuentas.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentas;
        }

        public List<PlanCuentasE> ObtenerPlanCuentasPadre(Int32 idEmpresa, String VersionPlanCuentas)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();            

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCuentasPadre", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = VersionPlanCuentas;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            PlanCuentasE entidad = new PlanCuentasE();

                            entidad.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
                            entidad.numVerPlanCuentas = Convert.ToString(oReader["numVerPlanCuentas"]);
                            entidad.codCuenta = Convert.ToString(oReader["codCuenta"]);
                            entidad.Descripcion = Convert.ToString(oReader["Descripcion"]);
                            entidad.numNivel = Convert.ToInt32(oReader["numNivel"]);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<PlanCuentasE> ObtenerPlanCuentasSubCuentas(Int32 idEmpresa, String VersionPlanCuentas, Int32 Nivel, String Cuenta)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSubCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = VersionPlanCuentas;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = Nivel;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = Cuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            PlanCuentasE entidad = new PlanCuentasE();

                            entidad.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
                            entidad.numVerPlanCuentas = Convert.ToString(oReader["numVerPlanCuentas"]);
                            entidad.codCuenta = Convert.ToString(oReader["codCuenta"]);
                            entidad.Descripcion = Convert.ToString(oReader["Descripcion"]);
                            entidad.numNivel = Convert.ToInt32(oReader["numNivel"]);

                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public PlanCuentasE ObtenerPlanCuentasPorCodigo(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta)
        {
            PlanCuentasE EPlanCuentas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = VersionPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = Cuenta;

                    oConexion.Open();
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            EPlanCuentas = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return EPlanCuentas;
        }

        public List<PlanCuentasE> ObtenerPlanCuentasPorCtaSuperior(Int32 idEmpresa, String VersionPlanCuentas, String CuentaSuperior)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();
            PlanCuentasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasPorCtaSuperior", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = VersionPlanCuentas;
                    oComando.Parameters.Add("@codCuentaSup", SqlDbType.VarChar, 20).Value = CuentaSuperior;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public String ObtenerDescripcionCuenta(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta)
        {
            String Descripcion = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerDescripcionCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = VersionPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = Cuenta;

                    oConexion.Open();
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Descripcion = oReader["Descripcion"].ToString();
                        }
                    }
                }
            }

            return Descripcion;
        }

        public Int32 VerificaSubCuentas(Int32 idEmpresa, String numVerPlanCuentas, String codCuentaSup)
        {
            Int32 Filas = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_VerificaSubCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuentaSup", SqlDbType.VarChar, 20).Value = codCuentaSup;

                    oConexion.Open();
                    Filas = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return Filas;
        }

        public Int32 EliminarCuenta(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarSubCuentas(Int32 idEmpresa, String numVerPlanCuentas, String codCuentaSup)
        {
            Int32 Filas = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSubCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuentaSup", SqlDbType.VarChar, 20).Value = codCuentaSup;

                    oConexion.Open();
                    Filas = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return Filas;
        }

        public List<PlanCuentasE> ListarPlanCuentasPorParametro(Int32 idEmpresa, String numVerPlanCuentas, String Parametro, Int32 numNivel, Int32 Opcion)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();
            PlanCuentasE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanCuentasPorParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@Parametro", SqlDbType.VarChar, 50).Value = Parametro;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;
                    oComando.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plan = LlenarEntidad(oReader);                            
                            listaEntidad.Add(plan);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<PlanCuentasE> PlanContableExportacion(Int32 idEmpresa, String numVerPlanCuentas)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();
            PlanCuentasE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_PlanContableExportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plan = LlenarEntidad(oReader);
                            listaEntidad.Add(plan);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<PlanCuentasE> ObtenerReportePlanDeCuenta(Int32 idEmpresa, Int32 idLocal, String Anio, String MesIni, String MesFin, String idMoneda, String idCompIni, String idCompFin)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();
            PlanCuentasE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReportePlanCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = Anio;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.Char, 2).Value = MesFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar).Value = idMoneda;
                    oComando.Parameters.Add("@idComprobanteIni", SqlDbType.VarChar,2).Value = idCompIni;
                    oComando.Parameters.Add("@idComprobanteFin", SqlDbType.VarChar, 2).Value = idCompFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plan = LlenarEntidad(oReader);
                            listaEntidad.Add(plan);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<PlanCuentasE> CuentasRenta(Int32 idEmpresa, String numVerPlanCuentas)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();
            PlanCuentasE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CuentasRenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plan = LlenarEntidad(oReader);
                            listaEntidad.Add(plan);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<PlanCuentasE> ListarPlanCuentasPorNivel(Int32 idEmpresa, String VersionPlanCuentas, Int32 numNivel)
        {
            List<PlanCuentasE> ListaCuentas = new List<PlanCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanCuentasPorNivel", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.Char, 3).Value = VersionPlanCuentas;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaCuentas.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaCuentas;
        }

        public Int32 ActualizarCodigosBalancePC(Int32 idEmpresa, Int32 indBalance, String numVerPlanCuentas, String codCuenta)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCodigosBalancePC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@indBalance", SqlDbType.Int).Value = indBalance;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 2).Value = codCuenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PlanCuentasE> ListarCtaCuentaSunat(Int32 idEmpresa, String anioPeriodo, String MesPeriodo)
        {
            List<PlanCuentasE> ListaCuentas = new List<PlanCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCtaCuentaSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar, 4).Value = anioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar,2).Value = MesPeriodo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaCuentas.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaCuentas;
        }

        public PlanCuentasE ActualizarPlandeCuentasSunat(PlanCuentasE plancuentas_sunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAsignarCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentas_sunat.idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentas_sunat.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plancuentas_sunat.codCuenta;
                    oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = plancuentas_sunat.codCuentaSunat;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentas_sunat;
        }

        public List<PlanCuentasE> GenerarBalanceComprobacionSunat(Int32 idEmpresa, String anioPeriodo, String MesPeriodo)
        {
            List<PlanCuentasE> ListaCuentas = new List<PlanCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarBalanceComprobacionSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar, 4).Value = anioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaCuentas.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaCuentas;
        }

        public List<PlanCuentasE> PlanCuentasRepSimplificado(Int32 idEmpresa, String numVerPlanCuentas)
        {
            List<PlanCuentasE> listaEntidad = new List<PlanCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_PlanCuentasRepSimplificado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

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

    }
}