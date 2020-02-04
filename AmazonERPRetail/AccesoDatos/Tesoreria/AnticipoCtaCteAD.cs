using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class AnticipoCtaCteAD : DbConection
    {

        public AnticipoCtaCteE LlenarEntidad(IDataReader oReader)
        {
            AnticipoCtaCteE ctacte = new AnticipoCtaCteE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoOrig'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.MontoOrig = oReader["MontoOrig"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoOrig"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaDocumento = oReader["FechaDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaVencimiento = oReader["FechaVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaCancelacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaCancelacion = oReader["FechaCancelacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaCancelacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnnoVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.AnnoVencimiento = oReader["AnnoVencimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnnoVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.MesVencimiento = oReader["MesVencimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SemanaVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SemanaVencimiento = oReader["SemanaVencimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SemanaVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsDetraCab'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.EsDetraCab = oReader["EsDetraCab"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsDetraCab"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idCtaCteOrigen = oReader["idCtaCteOrigen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoOperativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoOperativo = oReader["SaldoOperativo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoOperativo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoContable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoContable = oReader["SaldoContable"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoContable"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cargo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Cargo = oReader["Cargo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cargo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Abono'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Abono = oReader["Abono"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Abono"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saldo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Saldo = oReader["Saldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Saldo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.TipoAC = oReader["TipoAC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoAC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idDocumentoMov = oReader["idDocumentoMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SerieMov = oReader["SerieMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.NumeroMov = oReader["NumeroMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaMovimiento = oReader["FechaMovimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CargoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.CargoD = oReader["CargoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CargoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AbonoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.AbonoD = oReader["AbonoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AbonoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoD = oReader["SaldoD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaOperacion = oReader["FechaOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Apertura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Apertura = oReader["Apertura"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Apertura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Provision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Provision = oReader["Provision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Provision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Importacion = oReader["Importacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Compras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Compras = oReader["Compras"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Compras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Canje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Canje = oReader["Canje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Canje"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Pagos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Pagos = oReader["Pagos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Pagos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Compensa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Compensa = oReader["Compensa"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Compensa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Retencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Retencion = oReader["Retencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Retencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Detraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Detraccion = oReader["Detraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Detraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Otros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Otros = oReader["Otros"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Otros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Compras_Soles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Compras_Soles = oReader["Compras_Soles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Compras_Soles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImportePartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.ImportePartida = oReader["ImportePartida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImportePartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AgenteRetenedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.AgenteRetenedor = oReader["AgenteRetenedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AgenteRetenedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPagoDetra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.indPagoDetra = oReader["indPagoDetra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPagoDetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroUnico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.nroUnico = oReader["nroUnico"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroUnico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DiasMora'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.DiasMora = oReader["DiasMora"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["DiasMora"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDeposito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.tipDeposito = oReader["tipDeposito"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDeposito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.EstadoDoc = oReader["EstadoDoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Especie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Especie = oReader["Especie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Especie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DocReferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.DocReferencia = oReader["DocReferencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DocReferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estatus'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Estatus = oReader["Estatus"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estatus"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Banco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Banco = oReader["Banco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Banco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroUnico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.NroUnico = oReader["NroUnico"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroUnico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.DesPartida = oReader["DesPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvisionOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idProvisionOrigen = oReader["idProvisionOrigen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvisionOrigen"]);

            return ctacte;
        }

        public AnticipoCtaCteE InsertarAnticipoCtaCte(AnticipoCtaCteE ctacte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAnticipoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ctacte.idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ctacte.idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ctacte.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 10).Value = ctacte.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ctacte.numDocumento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = ctacte.idMoneda;
                    oComando.Parameters.Add("@MontoOrig", SqlDbType.Decimal).Value = ctacte.MontoOrig;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacte.TipoCambio;
                    oComando.Parameters.Add("@FechaDocumento", SqlDbType.Date).Value = ctacte.FechaDocumento;
                    oComando.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = ctacte.FechaVencimiento;
                    oComando.Parameters.Add("@FechaCancelacion", SqlDbType.Date).Value = ctacte.FechaCancelacion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte.codCuenta;
                    oComando.Parameters.Add("@AnnoVencimiento", SqlDbType.VarChar, 4).Value = ctacte.AnnoVencimiento;
                    oComando.Parameters.Add("@MesVencimiento", SqlDbType.VarChar, 2).Value = ctacte.MesVencimiento;
                    oComando.Parameters.Add("@SemanaVencimiento", SqlDbType.VarChar, 2).Value = ctacte.SemanaVencimiento;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = ctacte.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartida", SqlDbType.VarChar, 20).Value = ctacte.codPartidaPresu;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 500).Value = ctacte.desGlosa;
                    oComando.Parameters.Add("@FechaOperacion", SqlDbType.Date).Value = ctacte.FechaOperacion;
                    oComando.Parameters.Add("@EsDetraCab", SqlDbType.Bit).Value = ctacte.EsDetraCab;
                    oComando.Parameters.Add("@idCtaCteOrigen", SqlDbType.Int).Value = ctacte.idCtaCteOrigen;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = ctacte.idSistema;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ctacte.UsuarioRegistro;

                    oConexion.Open();
                    ctacte.idCtaCte = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ctacte;
        }

        public AnticipoCtaCteE ActualizarAnticipoCtaCte(AnticipoCtaCteE ctacte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAnticipoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ctacte.idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = ctacte.idCtaCte;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ctacte.idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ctacte.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 10).Value = ctacte.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ctacte.numDocumento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = ctacte.idMoneda;
                    oComando.Parameters.Add("@MontoOrig", SqlDbType.Decimal).Value = ctacte.MontoOrig;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacte.TipoCambio;
                    oComando.Parameters.Add("@FechaDocumento", SqlDbType.Date).Value = ctacte.FechaDocumento;
                    oComando.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = ctacte.FechaVencimiento;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte.codCuenta;
                    oComando.Parameters.Add("@AnnoVencimiento", SqlDbType.VarChar, 4).Value = ctacte.AnnoVencimiento;
                    oComando.Parameters.Add("@MesVencimiento", SqlDbType.VarChar, 2).Value = ctacte.MesVencimiento;
                    oComando.Parameters.Add("@SemanaVencimiento", SqlDbType.VarChar, 2).Value = ctacte.SemanaVencimiento;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = ctacte.tipPartidaPresu;
                    oComando.Parameters.Add("@codPartida", SqlDbType.VarChar, 20).Value = ctacte.codPartidaPresu;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 500).Value = ctacte.desGlosa;
                    oComando.Parameters.Add("@FechaOperacion", SqlDbType.Date).Value = ctacte.FechaOperacion;
                    oComando.Parameters.Add("@EsDetraCab", SqlDbType.Bit).Value = ctacte.EsDetraCab;
                    oComando.Parameters.Add("@idCtaCteOrigen", SqlDbType.Int).Value = ctacte.idCtaCteOrigen;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = ctacte.idSistema;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ctacte.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ctacte;
        }

        public Int32 EliminarAnticipoCtaCte(Int32 idEmpresa, Int32 idCtaCte)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticipoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<AnticipoCtaCteE> ListarAnticipoCtaCte()
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAnticipoCtaCte", oConexion))
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

        public AnticipoCtaCteE ObtenerAnticipoCtaCte(Int32 idEmpresa, Int32 idPersona, String idDocumento, String NumSerie, String NumDocumento, Boolean EsDetraCab)
        {
            AnticipoCtaCteE ctacte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 20).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;
                    oComando.Parameters.Add("@EsDetraCab", SqlDbType.Bit).Value = EsDetraCab;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte;
        }

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePorParametros(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCtePorParametros", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCteLetras(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCteLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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

        public AnticipoCtaCteE ObtenerAnticipoCtaCtePorDocumento(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento)
        {
            AnticipoCtaCteE ctacte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCtePorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 10).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte;
        }

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCteDetallado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCteDetallado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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

        public List<AnticipoCtaCteE> AnticipoCtaCteDetalladoVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnticipoCtaCteDetalladoVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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

        public List<AnticipoCtaCteE> ConsultaAnticipoCtaCteDet(Int32 idEmpresa, Int32 IdPersona, DateTime fecFiltro, String Opcion, Boolean EsDetraccion)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConsultaAnticipoCtaCteDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = IdPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@Opcion", SqlDbType.VarChar, 1).Value = Opcion;
                    oComando.Parameters.Add("@EsDetraccion", SqlDbType.Bit).Value = EsDetraccion;

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

        public List<AnticipoCtaCteE> ConsultaAnticipoCtaCteDetVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String Tipo)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConsultaAnticipoCtaCteDetVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 2).Value = Tipo;

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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePorCuenta(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCtePorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;

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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCteGeneral(Int32 idEmpresa, string filtro, DateTime fecFiltro)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCteGeneral", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@filtro", SqlDbType.VarChar, 100).Value = filtro;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;

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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePartida(Int32 idEmpresa, string filtro, DateTime fecFiltro)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCtePartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@filtro", SqlDbType.VarChar, 100).Value = filtro;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;

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

        public AnticipoCtaCteE ObtenerAnticipoCtaCtePorIdCteOrigen(Int32 idEmpresa, Int32 idCtaCteOrigen)
        {
            AnticipoCtaCteE ctacte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCtePorIdCteOrigen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCtaCteOrigen", SqlDbType.Int).Value = idCtaCteOrigen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte;
        }

        public Int32 EliminarAnticipoCtaCteMasivo(Int32 idEmpresa, Int32 idSistema, DateTime fecIni, DateTime fecFin)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticipoCtaCteMasivo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;
                    oComando.Parameters.Add("@fecIni", SqlDbType.DateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fecFin.Date;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarFecCancelacionAnticipoCtaCte(Int32 idEmpresa, Int32 idCtaCte, DateTime FechaCancelacion, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFecCancelacionAnticipoCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@FechaCancelacion", SqlDbType.Date).Value = FechaCancelacion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarAnticipoCtaCteConDetalle(Int32 idCtaCte)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticipoCtaCteConDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public AnticipoCtaCteE ObtenerAnticipoCtaCtePorId(Int32 idCtaCte)
        {
            AnticipoCtaCteE ctacte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCtePorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte;
        }

        public List<AnticipoCtaCteE> ReporteAnticipoCtaCteComparado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            List<AnticipoCtaCteE> listaEntidad = new List<AnticipoCtaCteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteAnticipoCtaCteComparado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecFiltro", SqlDbType.Date).Value = fecFiltro;

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
