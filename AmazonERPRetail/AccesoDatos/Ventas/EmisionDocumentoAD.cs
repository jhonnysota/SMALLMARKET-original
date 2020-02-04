using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class EmisionDocumentoAD : DbConection
    {

        public EmisionDocumentoE LlenarEntidad(IDataReader oReader)
        {
            EmisionDocumentoE emisiondocumento = new EmisionDocumentoE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Mes = oReader["Mes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecEmision = oReader["fecEmision"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indRecepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indRecepcion = oReader["indRecepcion"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indRecepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRecepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecRecepcion = oReader["fecRecepcion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecRecepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totMontoBruto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totMontoBruto = oReader["totMontoBruto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totMontoBruto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totsubTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totsubTotal = oReader["totsubTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totsubTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDscto1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totDscto1 = oReader["totDscto1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDscto1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDscto2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totDscto2 = oReader["totDscto2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDscto2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDscto3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totDscto3 = oReader["totDscto3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDscto3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totIsc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totIsc = oReader["totIsc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totIsc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totIgv = oReader["totIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totTotal = oReader["totTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Redondeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Redondeo = oReader["Redondeo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Redondeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DsctoGlobal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.DsctoGlobal = oReader["DsctoGlobal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DsctoGlobal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDscto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.porDscto = oReader["porDscto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDscto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TotalRef = oReader["TotalRef"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicionRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idTipCondicionRef = oReader["idTipCondicionRef"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicionRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicionRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idCondicionRef = oReader["idCondicionRef"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicionRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totAfectoPerce'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totAfectoPerce = oReader["totAfectoPerce"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totAfectoPerce"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totPercepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.totPercepcion = oReader["totPercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totPercepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRuc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numRuc = oReader["numRuc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRuc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSucursalCliente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idSucursalCliente = oReader["idSucursalCliente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSucursalCliente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipTraslado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idTipTraslado = oReader["idTipTraslado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipTraslado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OtroTipoTraslado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.OtroTipoTraslado = oReader["OtroTipoTraslado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["OtroTipoTraslado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAsiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TipoAsiento = oReader["TipoAsiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoAsiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indVoucher = oReader["indVoucher"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsGuia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EsGuia = oReader["EsGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EsGuia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecTraslado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecTraslado = oReader["fecTraslado"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecTraslado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EmpresaPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EmpresaPartida = oReader["EmpresaPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EmpresaPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PuntoPartida = oReader["PuntoPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuntoLlegada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PuntoLlegada = oReader["PuntoLlegada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PuntoLlegada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacenDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idAlmacenDestino = oReader["idAlmacenDestino"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacenDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresaTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idEmpresaTransp = oReader["idEmpresaTransp"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresaTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.RazonSocialTransp = oReader["RazonSocialTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.RucTransp = oReader["RucTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.DireccionTransp = oReader["DireccionTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConductorTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idConductorTransp = oReader["idConductorTransp"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConductorTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ConductorTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.ConductorTransp = oReader["ConductorTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ConductorTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LicenciaTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.LicenciaTransp = oReader["LicenciaTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LicenciaTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVehiculoTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desVehiculoTransp = oReader["desVehiculoTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVehiculoTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PlacaTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PlacaTransp = oReader["PlacaTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PlacaTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MarcaTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MarcaTransp = oReader["MarcaTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MarcaTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='inscripTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.inscripTransp = oReader["inscripTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["inscripTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PlacaRemolqueTransp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PlacaRemolqueTransp = oReader["PlacaRemolqueTransp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PlacaRemolqueTransp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desExpTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desExpTotal = oReader["desExpTotal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desExpTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desExpValorVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desExpValorVenta = oReader["desExpValorVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desExpValorVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Flete'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Flete = oReader["Flete"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Flete"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecCpt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PrecCpt = oReader["PrecCpt"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecCpt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='seguro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.seguro = oReader["seguro"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["seguro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Embalaje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Embalaje = oReader["Embalaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Embalaje"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Gastos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Gastos = oReader["Gastos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Gastos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipTransporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idTipTransporte = oReader["idTipTransporte"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTipTransporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombrePuerto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.NombrePuerto = oReader["NombrePuerto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombrePuerto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numPartida = oReader["numPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numReserva'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numReserva = oReader["numReserva"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numReserva"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DelNumero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.DelNumero = oReader["DelNumero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DelNumero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AlNumero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.AlNumero = oReader["AlNumero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AlNumero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanalVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idCanalVenta = oReader["idCanalVenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanalVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoMercado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TipoMercado = oReader["TipoMercado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoMercado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EnviadoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EnviadoSunat = oReader["EnviadoSunat"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EnviadoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEnvioSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecEnvioSunat = oReader["fecEnvioSunat"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecEnvioSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EstadoRegistro = oReader["EstadoRegistro"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["EstadoRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MensajeRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MensajeRegistro = oReader["MensajeRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MensajeRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idRegistro = oReader["idRegistro"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EstadoSunat = oReader["EstadoSunat"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["EstadoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MensajeSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MensajeSunat = oReader["MensajeSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MensajeSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnuladoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.AnuladoSunat = oReader["AnuladoSunat"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AnuladoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAnuladoSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecAnuladoSunat = oReader["fecAnuladoSunat"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecAnuladoSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MensajeSunatAnulacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MensajeSunatAnulacion = oReader["MensajeSunatAnulacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MensajeSunatAnulacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MotivoAnulacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MotivoAnulacion = oReader["MotivoAnulacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MotivoAnulacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EstadoBaja = oReader["EstadoBaja"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroDocAsociado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nroDocAsociado = oReader["nroDocAsociado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroDocAsociado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nroOt = oReader["nroOt"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroOt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroOtItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nroOtItem = oReader["nroOtItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["nroOtItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPais'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desPais = oReader["desPais"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPais"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desDep = oReader["desDep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDis'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desDis = oReader["desDis"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDis"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desPro = oReader["desPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Invoice'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Invoice = oReader["Invoice"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Invoice"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Periodo = oReader["Periodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Periodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PO = oReader["PO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AfectoDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.AfectoDetraccion = oReader["AfectoDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AfectoDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.tipDetraccion = oReader["tipDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TasaDetraccion = oReader["TasaDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MontoDetraccion = oReader["MontoDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipAfectoIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.tipAfectoIgv = oReader["tipAfectoIgv"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipAfectoIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AfectoRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.AfectoRetencion = oReader["AfectoRetencion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AfectoRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAnticipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EsAnticipo = oReader["EsAnticipo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAnticipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAnticipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indAnticipo = oReader["indAnticipo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAnticipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCancelacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indCancelacion = oReader["indCancelacion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCancelacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idZona = oReader["idZona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idZona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDivision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idDivision = oReader["idDivision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDivision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDespacho'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecDespacho = oReader["fecDespacho"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDespacho"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            // Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTraslado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desTraslado = oReader["desTraslado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTraslado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desCondicion = oReader["desCondicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCondicion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UrlPdf'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.UrlPdf = oReader["UrlPdf"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UrlPdf"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipAfectoIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desTipAfectoIgv = oReader["desTipAfectoIgv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipAfectoIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Vendedor = oReader["Vendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Vendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomVendedor = oReader["nomVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saldo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Saldo = oReader["Saldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Saldo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TrasladoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TrasladoAlmacen = oReader["TrasladoAlmacen"] == DBNull.Value ? false : Convert.ToBoolean(oReader["TrasladoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Mov = oReader["Mov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Guia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Guia = oReader["Guia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Guia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomUMedida = oReader["nomUMedida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Soles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Soles = oReader["Soles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Soles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Dolares = oReader["Dolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.FechaPago = oReader["FechaPago"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numOperacion = oReader["numOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomMes = oReader["nomMes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomMes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCondicionRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desCondicionRef = oReader["desCondicionRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCondicionRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desEstablecimiento = oReader["desEstablecimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desZonaTrabajo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desZonaTrabajo = oReader["desZonaTrabajo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desZonaTrabajo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Pedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Pedido = oReader["Pedido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Pedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAnticipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EsAnticipoTmp = oReader["EsAnticipo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAnticipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Item = oReader["Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraArt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indDetraArt = oReader["indDetraArt"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraArt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDetraArt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.tipDetraArt = oReader["tipDetraArt"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDetraArt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desDetraccion = oReader["desDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porDetraArt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.porDetraArt = oReader["porDetraArt"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porDetraArt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.BaseDetraccion = oReader["BaseDetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuentaDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numCuentaDetraccion = oReader["numCuentaDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuentaDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDetraccionSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.MontoDetraccionSoles = oReader["MontoDetraccionSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDetraccionSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TotalS = oReader["TotalS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TotalD = oReader["TotalD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TipoOperacion = oReader["TipoOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreArchivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.NombreArchivo = oReader["NombreArchivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreArchivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codDocumentoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.codDocumentoAlmacen = oReader["codDocumentoAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codDocumentoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EstadoFact = oReader["EstadoFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idDocumentoFact = oReader["idDocumentoFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numSerieFact = oReader["numSerieFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numDocumentoFact = oReader["numDocumentoFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmisionFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecEmisionFact = oReader["fecEmisionFact"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecEmisionFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticuloFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.codArticuloFact = oReader["codArticuloFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticuloFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.CantidadFact = oReader["CantidadFact"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomMedidaEnvFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomMedidaEnvFact = oReader["nomMedidaEnvFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomMedidaEnvFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticuloFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomArticuloFact = oReader["nomArticuloFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticuloFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ContenidoPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.ContenidoPres = oReader["ContenidoPres"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ContenidoPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomMedidaPresFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.nomMedidaPresFact = oReader["nomMedidaPresFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomMedidaPresFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idMonedaFact = oReader["idMonedaFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUnitDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PrecioUnitDol = oReader["PrecioUnitDol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUnitDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotalDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.subTotalDol = oReader["subTotalDol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["subTotalDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.IgvDol = oReader["IgvDol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUnitSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PrecioUnitSol = oReader["PrecioUnitSol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUnitSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotalSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.subTotalSol = oReader["subTotalSol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["subTotalSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.IgvSol = oReader["IgvSol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PesoBruto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PesoBruto = oReader["PesoBruto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PesoBruto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDivision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desDivision = oReader["desDivision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDivision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImporteCobrado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.ImporteCobrado = oReader["ImporteCobrado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImporteCobrado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLetras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numLetras = oReader["numLetras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numLetras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VariedadCaracteristica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.VariedadCaracteristica = oReader["VariedadCaracteristica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VariedadCaracteristica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EspecieCaracteristica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.EspecieCaracteristica = oReader["EspecieCaracteristica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EspecieCaracteristica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCaracteristica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TipoCaracteristica = oReader["TipoCaracteristica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCaracteristica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRucFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numRucFact = oReader["numRucFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numRucFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.RazonSocialFact = oReader["RazonSocialFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.indAlmacen = oReader["indAlmacen"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.AnioPedido = oReader["AnioPedido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPedido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Referente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Referente = oReader["Referente"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Referente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Clase = oReader["Clase"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Clase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.LoteAlmacen = oReader["LoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LoteProv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.LoteProv = oReader["LoteProv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LoteProv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Batch'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Batch = oReader["Batch"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Batch"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PaisOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.PaisOrigen = oReader["PaisOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PaisOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Germinacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Germinacion = oReader["Germinacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Germinacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPedido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.CodPedido = oReader["CodPedido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPedido"]);

            return emisiondocumento;
        }

        public EmisionDocumentoE InsertarEmisionDocumento(EmisionDocumentoE emisiondocumento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmisionDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumento.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumento.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumento.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumento;
                    oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = emisiondocumento.Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.Char, 2).Value = emisiondocumento.Mes;
                    oComando.Parameters.Add("@fecEmision", SqlDbType.VarChar, 8).Value = emisiondocumento.fecEmision;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.VarChar, 8).Value = emisiondocumento.fecVencimiento;
                    oComando.Parameters.Add("@indRecepcion", SqlDbType.Bit).Value = emisiondocumento.indRecepcion;
                    oComando.Parameters.Add("@fecRecepcion", SqlDbType.SmallDateTime).Value = emisiondocumento.fecRecepcion;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = emisiondocumento.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = emisiondocumento.idCondicion;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = emisiondocumento.idMoneda;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = emisiondocumento.tipCambio;
                    oComando.Parameters.Add("@totMontoBruto", SqlDbType.Decimal).Value = emisiondocumento.totMontoBruto;
                    oComando.Parameters.Add("@totsubTotal", SqlDbType.Decimal).Value = emisiondocumento.totsubTotal;
                    oComando.Parameters.Add("@totDscto1", SqlDbType.Decimal).Value = emisiondocumento.totDscto1;
                    oComando.Parameters.Add("@totDscto2", SqlDbType.Decimal).Value = emisiondocumento.totDscto2;
                    oComando.Parameters.Add("@totDscto3", SqlDbType.Decimal).Value = emisiondocumento.totDscto3;
                    oComando.Parameters.Add("@totIsc", SqlDbType.Decimal).Value = emisiondocumento.totIsc;
                    oComando.Parameters.Add("@totIgv", SqlDbType.Decimal).Value = emisiondocumento.totIgv;
                    oComando.Parameters.Add("@totTotal", SqlDbType.Decimal).Value = emisiondocumento.totTotal;
                    oComando.Parameters.Add("@Redondeo", SqlDbType.Decimal).Value = emisiondocumento.Redondeo;
                    oComando.Parameters.Add("@porDscto", SqlDbType.Decimal).Value = emisiondocumento.porDscto;
                    oComando.Parameters.Add("@DsctoGlobal", SqlDbType.Decimal).Value = emisiondocumento.DsctoGlobal;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 1000).Value = emisiondocumento.Glosa;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumento.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumentoRef;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = emisiondocumento.fecDocumentoRef;
                    oComando.Parameters.Add("@TotalRef", SqlDbType.Decimal).Value = emisiondocumento.TotalRef;
                    oComando.Parameters.Add("@idTipCondicionRef", SqlDbType.Int).Value = emisiondocumento.idTipCondicionRef;
                    oComando.Parameters.Add("@idCondicionRef", SqlDbType.Int).Value = emisiondocumento.idCondicionRef;
                    oComando.Parameters.Add("@totAfectoPerce", SqlDbType.Decimal).Value = emisiondocumento.totAfectoPerce;
                    oComando.Parameters.Add("@totPercepcion", SqlDbType.Decimal).Value = emisiondocumento.totPercepcion;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = emisiondocumento.indEstado;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = emisiondocumento.idPersona;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 400).Value = emisiondocumento.RazonSocial;
                    oComando.Parameters.Add("@numRuc", SqlDbType.VarChar, 25).Value = emisiondocumento.numRuc;
                    oComando.Parameters.Add("@idSucursalCliente", SqlDbType.Int).Value = emisiondocumento.idSucursalCliente;
                    oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 400).Value = emisiondocumento.Direccion;
                    oComando.Parameters.Add("@idTipTraslado", SqlDbType.Int).Value = emisiondocumento.idTipTraslado;
                    oComando.Parameters.Add("@OtroTipoTraslado", SqlDbType.VarChar, 50).Value = emisiondocumento.OtroTipoTraslado;
                    oComando.Parameters.Add("@TipoAsiento", SqlDbType.Char, 2).Value = emisiondocumento.TipoAsiento;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = emisiondocumento.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = emisiondocumento.codCuenta;
                    oComando.Parameters.Add("@EsGuia", SqlDbType.Char, 1).Value = emisiondocumento.EsGuia;
                    oComando.Parameters.Add("@fecTraslado", SqlDbType.SmallDateTime).Value = emisiondocumento.fecTraslado;
                    oComando.Parameters.Add("@EmpresaPartida", SqlDbType.VarChar, 400).Value = emisiondocumento.EmpresaPartida;
                    oComando.Parameters.Add("@PuntoPartida", SqlDbType.VarChar, 400).Value = emisiondocumento.PuntoPartida;
                    oComando.Parameters.Add("@PuntoLlegada", SqlDbType.VarChar, 400).Value = emisiondocumento.PuntoLlegada;
                    oComando.Parameters.Add("@idAlmacenDestino", SqlDbType.Int).Value = emisiondocumento.idAlmacenDestino;
                    oComando.Parameters.Add("@idEmpresaTransp", SqlDbType.Int).Value = emisiondocumento.idEmpresaTransp;
                    oComando.Parameters.Add("@RazonSocialTransp", SqlDbType.VarChar, 200).Value = emisiondocumento.RazonSocialTransp;
                    oComando.Parameters.Add("@RucTransp", SqlDbType.VarChar, 11).Value = emisiondocumento.RucTransp;
                    oComando.Parameters.Add("@DireccionTransp", SqlDbType.VarChar, 400).Value = emisiondocumento.DireccionTransp;
                    oComando.Parameters.Add("@idConductorTransp", SqlDbType.Int).Value = emisiondocumento.idConductorTransp;
                    oComando.Parameters.Add("@ConductorTransp", SqlDbType.VarChar, 100).Value = emisiondocumento.ConductorTransp;
                    oComando.Parameters.Add("@LicenciaTransp", SqlDbType.VarChar, 15).Value = emisiondocumento.LicenciaTransp;
                    oComando.Parameters.Add("@desVehiculoTransp", SqlDbType.VarChar, 50).Value = emisiondocumento.desVehiculoTransp;
                    oComando.Parameters.Add("@PlacaTransp", SqlDbType.VarChar, 20).Value = emisiondocumento.PlacaTransp;
                    oComando.Parameters.Add("@MarcaTransp", SqlDbType.VarChar, 50).Value = emisiondocumento.MarcaTransp;
                    oComando.Parameters.Add("@inscripTransp", SqlDbType.VarChar, 50).Value = emisiondocumento.inscripTransp;
                    oComando.Parameters.Add("@PlacaRemolqueTransp", SqlDbType.VarChar, 20).Value = emisiondocumento.PlacaRemolqueTransp;
                    oComando.Parameters.Add("@desExpTotal", SqlDbType.VarChar, 30).Value = emisiondocumento.desExpTotal;
                    oComando.Parameters.Add("@desExpValorVenta", SqlDbType.VarChar, 30).Value = emisiondocumento.desExpValorVenta;
                    oComando.Parameters.Add("@Flete", SqlDbType.Decimal).Value = emisiondocumento.Flete;
                    oComando.Parameters.Add("@PrecCpt", SqlDbType.Decimal).Value = emisiondocumento.PrecCpt;
                    oComando.Parameters.Add("@seguro", SqlDbType.Decimal).Value = emisiondocumento.seguro;
                    oComando.Parameters.Add("@Embalaje", SqlDbType.Decimal).Value = emisiondocumento.Embalaje;
                    oComando.Parameters.Add("@Gastos", SqlDbType.Decimal).Value = emisiondocumento.Gastos;
                    oComando.Parameters.Add("@idTipTransporte", SqlDbType.Char, 1).Value = emisiondocumento.idTipTransporte;
                    oComando.Parameters.Add("@NombrePuerto", SqlDbType.VarChar, 50).Value = emisiondocumento.NombrePuerto;
                    oComando.Parameters.Add("@numPartida", SqlDbType.VarChar, 50).Value = emisiondocumento.numPartida;
                    oComando.Parameters.Add("@numReserva", SqlDbType.VarChar, 50).Value = emisiondocumento.numReserva;
                    oComando.Parameters.Add("@DelNumero", SqlDbType.VarChar, 10).Value = emisiondocumento.DelNumero;
                    oComando.Parameters.Add("@AlNumero", SqlDbType.VarChar, 10).Value = emisiondocumento.AlNumero;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = emisiondocumento.idVendedor;
                    oComando.Parameters.Add("@idCanalVenta", SqlDbType.Int).Value = emisiondocumento.idCanalVenta;
                    oComando.Parameters.Add("@TipoMercado", SqlDbType.Char, 1).Value = emisiondocumento.TipoMercado;
                    oComando.Parameters.Add("@nroDocAsociado", SqlDbType.Int).Value = emisiondocumento.nroDocAsociado;
                    oComando.Parameters.Add("@Invoice", SqlDbType.VarChar, 50).Value = emisiondocumento.Invoice;
                    oComando.Parameters.Add("@Periodo", SqlDbType.VarChar, 50).Value = emisiondocumento.Periodo;
                    oComando.Parameters.Add("@PO", SqlDbType.VarChar, 50).Value = emisiondocumento.PO;
                    oComando.Parameters.Add("@AfectoDetraccion", SqlDbType.Bit).Value = emisiondocumento.AfectoDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumento.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumento.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = emisiondocumento.MontoDetraccion;
                    oComando.Parameters.Add("@tipAfectoIgv", SqlDbType.Int).Value = emisiondocumento.tipAfectoIgv;
                    oComando.Parameters.Add("@AfectoRetencion", SqlDbType.Bit).Value = emisiondocumento.AfectoRetencion;
                    oComando.Parameters.Add("@EsAnticipo", SqlDbType.Bit).Value = emisiondocumento.EsAnticipo;
                    oComando.Parameters.Add("@indAnticipo", SqlDbType.Bit).Value = emisiondocumento.indAnticipo;
                    oComando.Parameters.Add("@indCancelacion", SqlDbType.Bit).Value = emisiondocumento.indCancelacion;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = emisiondocumento.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = emisiondocumento.idZona;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value = emisiondocumento.idDivision;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = emisiondocumento.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumento;
        }

        public EmisionDocumentoE ActualizarEmisionDocumento(EmisionDocumentoE emisiondocumento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumento.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumento.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumento.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumento;
                    oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = emisiondocumento.Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.Char, 2).Value = emisiondocumento.Mes;
                    oComando.Parameters.Add("@fecEmision", SqlDbType.VarChar, 8).Value = emisiondocumento.fecEmision;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.VarChar, 8).Value = emisiondocumento.fecVencimiento;
                    oComando.Parameters.Add("@indRecepcion", SqlDbType.Bit).Value = emisiondocumento.indRecepcion;
                    oComando.Parameters.Add("@fecRecepcion", SqlDbType.SmallDateTime).Value = emisiondocumento.fecRecepcion;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = emisiondocumento.idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = emisiondocumento.idCondicion;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = emisiondocumento.idMoneda;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = emisiondocumento.tipCambio;
                    oComando.Parameters.Add("@totMontoBruto", SqlDbType.Decimal).Value = emisiondocumento.totMontoBruto;
                    oComando.Parameters.Add("@totsubTotal", SqlDbType.Decimal).Value = emisiondocumento.totsubTotal;
                    oComando.Parameters.Add("@totDscto1", SqlDbType.Decimal).Value = emisiondocumento.totDscto1;
                    oComando.Parameters.Add("@totDscto2", SqlDbType.Decimal).Value = emisiondocumento.totDscto2;
                    oComando.Parameters.Add("@totDscto3", SqlDbType.Decimal).Value = emisiondocumento.totDscto3;
                    oComando.Parameters.Add("@totIsc", SqlDbType.Decimal).Value = emisiondocumento.totIsc;
                    oComando.Parameters.Add("@totIgv", SqlDbType.Decimal).Value = emisiondocumento.totIgv;
                    oComando.Parameters.Add("@totTotal", SqlDbType.Decimal).Value = emisiondocumento.totTotal;
                    oComando.Parameters.Add("@Redondeo", SqlDbType.Decimal).Value = emisiondocumento.Redondeo;
                    oComando.Parameters.Add("@porDscto", SqlDbType.Decimal).Value = emisiondocumento.porDscto;
                    oComando.Parameters.Add("@DsctoGlobal", SqlDbType.Decimal).Value = emisiondocumento.DsctoGlobal;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 1000).Value = emisiondocumento.Glosa;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumento.serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumentoRef;
                    oComando.Parameters.Add("@fecDocumentoRef", SqlDbType.SmallDateTime).Value = emisiondocumento.fecDocumentoRef;
                    oComando.Parameters.Add("@TotalRef", SqlDbType.Decimal).Value = emisiondocumento.TotalRef;
                    oComando.Parameters.Add("@idTipCondicionRef", SqlDbType.Int).Value = emisiondocumento.idTipCondicionRef;
                    oComando.Parameters.Add("@idCondicionRef", SqlDbType.Int).Value = emisiondocumento.idCondicionRef;
                    oComando.Parameters.Add("@totAfectoPerce", SqlDbType.Decimal).Value = emisiondocumento.totAfectoPerce;
                    oComando.Parameters.Add("@totPercepcion", SqlDbType.Decimal).Value = emisiondocumento.totPercepcion;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = emisiondocumento.indEstado;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = emisiondocumento.idPersona;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 400).Value = emisiondocumento.RazonSocial;
                    oComando.Parameters.Add("@numRuc", SqlDbType.VarChar, 25).Value = emisiondocumento.numRuc;
                    oComando.Parameters.Add("@idSucursalCliente", SqlDbType.Int).Value = emisiondocumento.idSucursalCliente;
                    oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 400).Value = emisiondocumento.Direccion;
                    oComando.Parameters.Add("@idTipTraslado", SqlDbType.Int).Value = emisiondocumento.idTipTraslado;
                    oComando.Parameters.Add("@OtroTipoTraslado", SqlDbType.VarChar, 50).Value = emisiondocumento.OtroTipoTraslado;
                    oComando.Parameters.Add("@TipoAsiento", SqlDbType.Char, 2).Value = emisiondocumento.TipoAsiento;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = emisiondocumento.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = emisiondocumento.codCuenta;
                    oComando.Parameters.Add("@EsGuia", SqlDbType.Char, 1).Value = emisiondocumento.EsGuia;
                    oComando.Parameters.Add("@fecTraslado", SqlDbType.SmallDateTime).Value = emisiondocumento.fecTraslado;
                    oComando.Parameters.Add("@EmpresaPartida", SqlDbType.VarChar, 400).Value = emisiondocumento.EmpresaPartida;
                    oComando.Parameters.Add("@PuntoPartida", SqlDbType.VarChar, 400).Value = emisiondocumento.PuntoPartida;
                    oComando.Parameters.Add("@PuntoLlegada", SqlDbType.VarChar, 400).Value = emisiondocumento.PuntoLlegada;
                    oComando.Parameters.Add("@idAlmacenDestino", SqlDbType.Int).Value = emisiondocumento.idAlmacenDestino;
                    oComando.Parameters.Add("@idEmpresaTransp", SqlDbType.Int).Value = emisiondocumento.idEmpresaTransp;
                    oComando.Parameters.Add("@RazonSocialTransp", SqlDbType.VarChar, 200).Value = emisiondocumento.RazonSocialTransp;
                    oComando.Parameters.Add("@RucTransp", SqlDbType.VarChar, 11).Value = emisiondocumento.RucTransp;
                    oComando.Parameters.Add("@DireccionTransp", SqlDbType.VarChar, 400).Value = emisiondocumento.DireccionTransp;
                    oComando.Parameters.Add("@idConductorTransp", SqlDbType.Int).Value = emisiondocumento.idConductorTransp;
                    oComando.Parameters.Add("@ConductorTransp", SqlDbType.VarChar, 100).Value = emisiondocumento.ConductorTransp;
                    oComando.Parameters.Add("@LicenciaTransp", SqlDbType.VarChar, 15).Value = emisiondocumento.LicenciaTransp;
                    oComando.Parameters.Add("@desVehiculoTransp", SqlDbType.VarChar, 50).Value = emisiondocumento.desVehiculoTransp;
                    oComando.Parameters.Add("@PlacaTransp", SqlDbType.VarChar, 20).Value = emisiondocumento.PlacaTransp;
                    oComando.Parameters.Add("@MarcaTransp", SqlDbType.VarChar, 50).Value = emisiondocumento.MarcaTransp;
                    oComando.Parameters.Add("@inscripTransp", SqlDbType.VarChar, 50).Value = emisiondocumento.inscripTransp;
                    oComando.Parameters.Add("@PlacaRemolqueTransp", SqlDbType.VarChar, 20).Value = emisiondocumento.PlacaRemolqueTransp;
                    oComando.Parameters.Add("@desExpTotal", SqlDbType.VarChar, 30).Value = emisiondocumento.desExpTotal;
                    oComando.Parameters.Add("@desExpValorVenta", SqlDbType.VarChar, 30).Value = emisiondocumento.desExpValorVenta;
                    oComando.Parameters.Add("@Flete", SqlDbType.Decimal).Value = emisiondocumento.Flete;
                    oComando.Parameters.Add("@PrecCpt", SqlDbType.Decimal).Value = emisiondocumento.PrecCpt;
                    oComando.Parameters.Add("@seguro", SqlDbType.Decimal).Value = emisiondocumento.seguro;
                    oComando.Parameters.Add("@Embalaje", SqlDbType.Decimal).Value = emisiondocumento.Embalaje;
                    oComando.Parameters.Add("@Gastos", SqlDbType.Decimal).Value = emisiondocumento.Gastos;
                    oComando.Parameters.Add("@idTipTransporte", SqlDbType.Char, 1).Value = emisiondocumento.idTipTransporte;
                    oComando.Parameters.Add("@NombrePuerto", SqlDbType.VarChar, 50).Value = emisiondocumento.NombrePuerto;
                    oComando.Parameters.Add("@numPartida", SqlDbType.VarChar, 50).Value = emisiondocumento.numPartida;
                    oComando.Parameters.Add("@numReserva", SqlDbType.VarChar, 50).Value = emisiondocumento.numReserva;
                    oComando.Parameters.Add("@DelNumero", SqlDbType.VarChar, 10).Value = emisiondocumento.DelNumero;
                    oComando.Parameters.Add("@AlNumero", SqlDbType.VarChar, 10).Value = emisiondocumento.AlNumero;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = emisiondocumento.idVendedor;
                    oComando.Parameters.Add("@idCanalVenta", SqlDbType.Int).Value = emisiondocumento.idCanalVenta;
                    oComando.Parameters.Add("@TipoMercado", SqlDbType.Char, 1).Value = emisiondocumento.TipoMercado;
                    oComando.Parameters.Add("@nroDocAsociado", SqlDbType.Int).Value = emisiondocumento.nroDocAsociado;
                    oComando.Parameters.Add("@Invoice", SqlDbType.VarChar, 50).Value = emisiondocumento.Invoice;
                    oComando.Parameters.Add("@Periodo", SqlDbType.VarChar, 50).Value = emisiondocumento.Periodo;
                    oComando.Parameters.Add("@PO", SqlDbType.VarChar, 50).Value = emisiondocumento.PO;
                    oComando.Parameters.Add("@AfectoDetraccion", SqlDbType.Bit).Value = emisiondocumento.AfectoDetraccion;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumento.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumento.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = emisiondocumento.MontoDetraccion;
                    oComando.Parameters.Add("@tipAfectoIgv", SqlDbType.Int).Value = emisiondocumento.tipAfectoIgv;
                    oComando.Parameters.Add("@AfectoRetencion", SqlDbType.Bit).Value = emisiondocumento.AfectoRetencion;
                    oComando.Parameters.Add("@EsAnticipo", SqlDbType.Bit).Value = emisiondocumento.EsAnticipo;
                    oComando.Parameters.Add("@indAnticipo", SqlDbType.Bit).Value = emisiondocumento.indAnticipo;
                    oComando.Parameters.Add("@indCancelacion", SqlDbType.Bit).Value = emisiondocumento.indCancelacion;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = emisiondocumento.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = emisiondocumento.idZona;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value = emisiondocumento.idDivision;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumento.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumento;
        }

        public EmisionDocumentoE ActualizarEmisionDocumentoVendedor(EmisionDocumentoE emisiondocumento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumentoVendedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumento.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumento.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumento.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumento;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = emisiondocumento.idVendedor;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = emisiondocumento.idEstablecimiento;
                    oComando.Parameters.Add("@idZona", SqlDbType.Int).Value = emisiondocumento.idZona;
                    oComando.Parameters.Add("@idDivision", SqlDbType.Int).Value = emisiondocumento.idDivision;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumento;
        }

        public EmisionDocumentoE ObtenerEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {        
            EmisionDocumentoE emisiondocumento = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            emisiondocumento = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return emisiondocumento;        
        }

        public List<EmisionDocumentoE> ListarDocumentosVentas(Int32 idEmpresa, Int32 idLocal, String idDocumento, Int32 idPersona, String Serie, string fecIni, string fecFin)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDocumentosVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ListarDocumentosEmitidos(Int32 idEmpresa, Int32 idLocal, String idDocumento)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDocumentosEmitidos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ListarDocumentosEmitidosFecha(Int32 idEmpresa, Int32 idLocal, String idDocumento, String fecha)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDocumentosEmitidosFecha", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@fechRegistro", SqlDbType.VarChar, 8).Value = fecha;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ListarDocEmitidosFechaPorSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento, String fecha, String Serie)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDocEmitidosFechaPorSerie", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@fechRegistro", SqlDbType.VarChar, 8).Value = fecha;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public void CambiarEstadoDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String indEstado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char).Value = indEstado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<EmisionDocumentoE> RecuperarEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String FecIni, String FecFin, String RazonSocial)
        {
            List<EmisionDocumentoE> Lista = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarEmisionDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@FecIni", SqlDbType.VarChar, 8).Value = FecIni;
                    oComando.Parameters.Add("@FecFin", SqlDbType.VarChar, 8).Value = FecFin;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 20).Value = RazonSocial;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Lista.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return Lista;
        }

        public EmisionDocumentoE RevisarEmisionDocumentoReferencias(Int32 idEmpresa, Int32 idLocal, String idDocumentoRef, String serDocumentoRef, String numDocumentoRef, String idDocumento, String numSerie, String numDocumento)
        {
            EmisionDocumentoE emisiondocumento = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RevisarEmisionDocumentoReferencias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = idDocumentoRef;
                    oComando.Parameters.Add("@serDocumentoRef", SqlDbType.VarChar, 20).Value = serDocumentoRef;
                    oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = numDocumentoRef;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            emisiondocumento = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return emisiondocumento;
        }

        #region Sunat

        public Int32 ActualizarDocumentosSunat(EmisionDocumentoE oDocumentoSunat)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDocumentosSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = oDocumentoSunat.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = oDocumentoSunat.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = oDocumentoSunat.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = oDocumentoSunat.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = oDocumentoSunat.numDocumento;
                    oComando.Parameters.Add("@EnviadoSunat", SqlDbType.Bit).Value = oDocumentoSunat.EnviadoSunat;
                    oComando.Parameters.Add("@fecEnvioSunat", SqlDbType.SmallDateTime).Value = oDocumentoSunat.fecEnvioSunat;
                    oComando.Parameters.Add("@EstadoRegistro", SqlDbType.Int).Value = oDocumentoSunat.EstadoRegistro;
                    oComando.Parameters.Add("@MensajeRegistro", SqlDbType.VarChar, 100).Value = oDocumentoSunat.MensajeRegistro;
                    oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = oDocumentoSunat.idRegistro;
                    oComando.Parameters.Add("@EstadoSunat", SqlDbType.Int).Value = oDocumentoSunat.EstadoSunat;
                    oComando.Parameters.Add("@MensajeSunat", SqlDbType.VarChar, 100).Value = oDocumentoSunat.MensajeSunat;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = oDocumentoSunat.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 DarBajaDocumentosVentasSunat(EmisionDocumentoE oDocumentoAnulado, String Tipo, Int32 numFila, String RucEmisor)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_DarBajaDocumentosVentasSunatCB", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = oDocumentoAnulado.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = oDocumentoAnulado.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = oDocumentoAnulado.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = oDocumentoAnulado.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = oDocumentoAnulado.numDocumento;
                    oComando.Parameters.Add("@Motivo", SqlDbType.VarChar, 150).Value = oDocumentoAnulado.MotivoAnulacion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = oDocumentoAnulado.UsuarioModificacion;
                    oComando.Parameters.Add("@fecEmision", SqlDbType.VarChar, 10).Value = oDocumentoAnulado.fecEmision;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = Tipo;
                    oComando.Parameters.Add("@numFila", SqlDbType.Int).Value = numFila;
                    oComando.Parameters.Add("@RucEmisor", SqlDbType.VarChar, 11).Value = RucEmisor;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 DarBajaDocumentosVentasSunat(Int32 idEmpresa, Int32 idLocal, String UsuarioModificacion, String Fecha)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_DarBajaDocumentosVentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;
                    oComando.Parameters.Add("@Fecha", SqlDbType.VarChar, 10).Value = Fecha;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 InsertarFacturaElectronica(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String numLetra, String EsGuia, Int32 idPersona)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFacturaElectronica", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 10).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 10).Value = numDocumento;
                    oComando.Parameters.Add("@numLetras", SqlDbType.VarChar, 100).Value = numLetra;
                    oComando.Parameters.Add("@EsGuia", SqlDbType.Char, 1).Value = EsGuia;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 InsertarFacturaElectronica(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String numLetra)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFacturaElectronica", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@numLetras", SqlDbType.VarChar, 100).Value = numLetra;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 RecuperarEstadoSunat(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarEstadoSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 10).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 10).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ResumenBoletas(Int32 idEmpresa, String Fecha, String Serie, String numDesde, String numHasta)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ResumenBoletas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Fecha", SqlDbType.VarChar, 10).Value = Fecha;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 10).Value = Serie;
                    oComando.Parameters.Add("@numDesde", SqlDbType.VarChar, 20).Value = numDesde;
                    oComando.Parameters.Add("@numHasta", SqlDbType.VarChar, 20).Value = numHasta;
                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarEstadoBaja(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String MotivoAnulacion, String UsuarioModificacion)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoBaja", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@MotivoAnulacion", SqlDbType.VarChar, 100).Value = MotivoAnulacion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        //Solamente para el Fundo San Miguel
        public String FacturaElectronicaUrlPdf(String TipoDocumentoEmisor, String RucEmisor, String idDocumento, String numSerie, String numDocumento)
        {
            EmisionDocumentoE emisiondocumento = null;
            String Url = String.Empty;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_FacturaElectronicaUrlPdf", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@TipoDocumentoEmisor", SqlDbType.VarChar, 2).Value = TipoDocumentoEmisor;
                    oComando.Parameters.Add("@RucEmisor", SqlDbType.VarChar, 20).Value = RucEmisor;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            emisiondocumento = LlenarEntidad(oReader);

                            if (!String.IsNullOrEmpty(emisiondocumento.UrlPdf))
                            {
                                Url = emisiondocumento.UrlPdf;
                            }
                        }
                    }
                }
            }

            return Url;
        }

        #endregion

        public void ActualizarStock(Int32 idEmpresa,/* Int32 idLocal,*/  Int32? Item, decimal cantidad)
        {

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarStock", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    //oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = Item;
                    oComando.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

         
        }



        //public Int32 ActualizarDocAlmacen(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, Int32 DocumentoAlmacen)
        //{
        //    Int32 Resp = 0;

        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDocAlmacen", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;
        //            oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
        //            oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
        //            oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
        //            oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
        //            oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
        //            oComando.Parameters.Add("@DocumentoAlmacen", SqlDbType.Int).Value = DocumentoAlmacen;

        //            oConexion.Open();
        //            Resp = oComando.ExecuteNonQuery();
        //        }
        //    }

        //    return Resp;
        //}

        public Int32 EliminarEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmisionDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarEmisDocuCompleto(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmisDocuCompleto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EmisionDocumentoE> ListarAnticipos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAnticipos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona ", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ListaDocVentasParaSunat(Int32 idEmpresa, Int32 idLocal, String idDocumento, string fecIni, string fecFin, bool EnviadoSunat, bool AnuladoSunat)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListaDocVentasParaSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    //oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@EnviadoSunat", SqlDbType.Bit).Value = EnviadoSunat;
                    oComando.Parameters.Add("@AnuladoSunat", SqlDbType.Bit).Value = AnuladoSunat;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ListarReporteVentasDetallada(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente, Int32 idEstablecimiento)
        {
            List<EmisionDocumentoE> listaEntidad = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroVentasDetallada", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;

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

        public List<EmisionDocumentoE> ListarReporteVentasDetallada2(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente, Int32 idEstablecimiento)
        {
            List<EmisionDocumentoE> listaEntidad = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroVentasDetallada2", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;

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

        public List<EmisionDocumentoE> ListarReporteVentasDetalladaOT(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente)
        {
            List<EmisionDocumentoE> listaEntidad = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroVentasDetalladaOT", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

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

        public List<EmisionDocumentoE> ReporteMensualVentasResumida(Int32 idEmpresa, Int32 idLocal, String Anio, String MesIni, String MesFin, String idMoneda, Int32 idPersona)
        {
            List<EmisionDocumentoE> listaEntidad = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteMensualVentasResumida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = Anio;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.Char, 2).Value = MesFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = idMoneda;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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

        public Int32 EliminarVoucherEmiDoc(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero , String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminaAsientoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoDocu", SqlDbType.VarChar, 2).Value = TipoDocu;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = Numero;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public EmisionDocumentoE GenerarVoucherEmiDoc(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero, String Usuario) 
        {
            EmisionDocumentoE emision = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraAsientoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoDocu", SqlDbType.VarChar, 2).Value = TipoDocu;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = Numero;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            emision = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return emision;
        }

        public List<EmisionDocumentoE> ComparativoVentasMulti(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda, Int32 TipoRep, Int32 TipoPresentacion)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ComparativoVentasMulti", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@TipoRep", SqlDbType.SmallInt).Value = TipoRep;
                    oComando.Parameters.Add("@TipoPresentacion", SqlDbType.Int).Value = TipoPresentacion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ComparativoVentasVsPresupuesto(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda, Int32 TipoRep, Int32 TipoPresentacion)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ComparativoVentasVsPresupuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@TipoRep", SqlDbType.SmallInt).Value = TipoRep;
                    oComando.Parameters.Add("@TipoPresentacion", SqlDbType.Int).Value = TipoPresentacion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ListarDetraccionCabEmisDocu(Int32 idEmpresa)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDetraccionCabEmisDocu", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public EmisionDocumentoE ActualizarDetraccionCabEmisDocu(EmisionDocumentoE emisiondocumento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDetraccionCabEmisDocu", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumento.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumento.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumento.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumento;
                    oComando.Parameters.Add("@tipDetraccion", SqlDbType.VarChar, 3).Value = emisiondocumento.tipDetraccion;
                    oComando.Parameters.Add("@TasaDetraccion", SqlDbType.Decimal).Value = emisiondocumento.TasaDetraccion;
                    oComando.Parameters.Add("@MontoDetraccion", SqlDbType.Decimal).Value = emisiondocumento.MontoDetraccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumento.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumento;
        }

        public List<EmisionDocumentoE> ListarVentasAutoDetracciones(Int32 idEmpresa, string fecIni, string fecFin)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVentasAutoDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public List<EmisionDocumentoE> ControlGuiasVenta(Int32 idEmpresa, Int32 idLocal, String idDocumento, string fecIni, string fecFin)
        {
            List<EmisionDocumentoE> ListaDocumentos = new List<EmisionDocumentoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ControlGuiasVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

        public Int32 ActualizaTCVentas(Int32 idEmpresa, string Desde, string Hasta)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizaTCVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Desde", SqlDbType.VarChar, 8).Value = Desde;
                    oComando.Parameters.Add("@Hasta", SqlDbType.VarChar, 8).Value = Hasta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public EmisionDocumentoE ActualizarEmisDocuCtaCte(EmisionDocumentoE emisiondocumento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisDocuCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumento.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumento.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumento.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumento;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = emisiondocumento.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = emisiondocumento.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumento.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumento;
        }

        public EmisionDocumentoE ObtenerVendedorCondicion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            EmisionDocumentoE emisiondocumento = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVendedorCondicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            emisiondocumento = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return emisiondocumento;
        }

        public Int32 ActualizarNroDocAsociado(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, Int32 nroDocAsociado)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarNroDocAsociado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@nroDocAsociado", SqlDbType.Int).Value = nroDocAsociado;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public EmisionDocumentoE ActualizarFecDespacho(EmisionDocumentoE emisiondocumento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFecDespacho", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumento.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumento.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumento.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumento.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumento.numDocumento;
                    oComando.Parameters.Add("@fecDespacho", SqlDbType.SmallDateTime).Value = emisiondocumento.fecDespacho;


                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumento;
        }

    }
}