using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class MovimientoBancosAD : DbConection
    {

        public MovimientoBancosE LlenarEntidad(IDataReader oReader)
        {
            MovimientoBancosE movimientobancos = new MovimientoBancosE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMovBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idMovBanco = oReader["idMovBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMovBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMovBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.codMovBanco = oReader["codMovBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codMovBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaBancaria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.ctaBancaria = oReader["ctaBancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaBancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.fecMovimiento = oReader["fecMovimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TicaAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.TicaAuto = oReader["TicaAuto"] == DBNull.Value ? true : Convert.ToBoolean(oReader["TicaAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GiradoA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.GiradoA = oReader["GiradoA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GiradoA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalImporte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.TotalImporte = oReader["TotalImporte"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalImporte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalImporteDol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.TotalImporteDol = oReader["TotalImporteDol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalImporteDol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idMedioPago = oReader["idMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoTransS'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.MontoTransS = oReader["MontoTransS"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoTransS"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoTransD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.MontoTransD = oReader["MontoTransD"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoTransD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDevolucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.indDevolucion = oReader["indDevolucion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDevolucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.desTipoMovimiento = oReader["desTipoMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoviTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idMoviTrans = oReader["idMoviTrans"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMoviTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMoviTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.codMoviTrans = oReader["codMoviTrans"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codMoviTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresaTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.idEmpresaTrans = oReader["idEmpresaTrans"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresaTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EmpresaTrans'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.EmpresaTrans = oReader["EmpresaTrans"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EmpresaTrans"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                movimientobancos.RucEmpresa = oReader["RucEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucEmpresa"]);

            return movimientobancos;
        }

        public MovimientoBancosE InsertarMovimientoBancos(MovimientoBancosE movimientobancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMovimientoBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codMovBanco", SqlDbType.VarChar, 10).Value = movimientobancos.codMovBanco;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = movimientobancos.tipMovimiento;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientobancos.idEmpresa;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = movimientobancos.idBanco;
                    oComando.Parameters.Add("@ctaBancaria", SqlDbType.VarChar, 20).Value = movimientobancos.ctaBancaria;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientobancos.idMoneda;
                    oComando.Parameters.Add("@fecMovimiento", SqlDbType.SmallDateTime).Value = movimientobancos.fecMovimiento.Date;
                    oComando.Parameters.Add("@TicaAuto", SqlDbType.Bit).Value = movimientobancos.TicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = movimientobancos.tipCambio;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = movimientobancos.Glosa;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientobancos.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientobancos.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientobancos.numDocumento;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = movimientobancos.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientobancos.fecVencimiento;
                    oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = movimientobancos.idMedioPago;
                    oComando.Parameters.Add("@totImporteSol", SqlDbType.Decimal).Value = movimientobancos.TotalImporte;
                    oComando.Parameters.Add("@totImporteDol", SqlDbType.Decimal).Value = movimientobancos.TotalImporteDol;
                    oComando.Parameters.Add("@GiradoA", SqlDbType.VarChar, 100).Value = movimientobancos.GiradoA;
                    oComando.Parameters.Add("@MontoTransS", SqlDbType.Decimal).Value = movimientobancos.MontoTransS;
                    oComando.Parameters.Add("@MontoTransD", SqlDbType.Decimal).Value = movimientobancos.MontoTransD;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = movimientobancos.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = movimientobancos.codCuenta;
                    oComando.Parameters.Add("@indDevolucion", SqlDbType.Bit).Value = movimientobancos.indDevolucion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = movimientobancos.UsuarioRegistro;

                    oConexion.Open();
                    movimientobancos.idMovBanco = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return movimientobancos;
        }

        public MovimientoBancosE ActualizarMovimientoBancos(MovimientoBancosE movimientobancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = movimientobancos.idMovBanco;
                    oComando.Parameters.Add("@codMovBanco", SqlDbType.VarChar, 10).Value = movimientobancos.codMovBanco;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = movimientobancos.tipMovimiento;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = movimientobancos.idEmpresa;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = movimientobancos.idBanco;
                    oComando.Parameters.Add("@ctaBancaria", SqlDbType.VarChar, 20).Value = movimientobancos.ctaBancaria;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = movimientobancos.idMoneda;
                    oComando.Parameters.Add("@fecMovimiento", SqlDbType.SmallDateTime).Value = movimientobancos.fecMovimiento.Date;
                    oComando.Parameters.Add("@TicaAuto", SqlDbType.Bit).Value = movimientobancos.TicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = movimientobancos.tipCambio;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = movimientobancos.Glosa;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientobancos.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientobancos.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientobancos.numDocumento;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = movimientobancos.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientobancos.fecVencimiento;
                    oComando.Parameters.Add("@idMedioPago", SqlDbType.Int).Value = movimientobancos.idMedioPago;
                    oComando.Parameters.Add("@totImporteSol", SqlDbType.Decimal).Value = movimientobancos.TotalImporte;
                    oComando.Parameters.Add("@totImporteDol", SqlDbType.Decimal).Value = movimientobancos.TotalImporteDol;
                    oComando.Parameters.Add("@GiradoA", SqlDbType.VarChar, 100).Value = movimientobancos.GiradoA;
                    oComando.Parameters.Add("@MontoTransS", SqlDbType.Decimal).Value = movimientobancos.MontoTransS;
                    oComando.Parameters.Add("@MontoTransD", SqlDbType.Decimal).Value = movimientobancos.MontoTransD;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = movimientobancos.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = movimientobancos.codCuenta;
                    oComando.Parameters.Add("@indDevolucion", SqlDbType.Bit).Value = movimientobancos.indDevolucion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientobancos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientobancos;
        }

        public Int32 EliminarMovimientoBancos(Int32 idMovBanco)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMovimientoBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<MovimientoBancosE> ListarMovimientoBancos(Int32 idEmpresa, Int32 idBanco, Int32 tipMovimiento, DateTime fecIni, DateTime fecFin, String indEstado, Boolean indDevolucion)
        {
            List<MovimientoBancosE> listaEntidad = new List<MovimientoBancosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMovimientoBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 2).Value = indEstado;
                    oComando.Parameters.Add("@indDevolucion", SqlDbType.Bit).Value = indDevolucion;

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

        public MovimientoBancosE ObtenerMovimientoBancos(Int32 idMovBanco)
        {
            MovimientoBancosE movimientobancos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMovimientoBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            movimientobancos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return movimientobancos;
        }

        public String GenerarNumMovBancos(Int32 idEmpresa, Int32 tipMovimiento)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumMovBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = oReader["codMovBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codMovBanco"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public MovimientoBancosE ActualizarMovBancosConta(MovimientoBancosE movimientobancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovBancosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = movimientobancos.idMovBanco;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = movimientobancos.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = movimientobancos.MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = movimientobancos.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = movimientobancos.numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = movimientobancos.numVoucher;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientobancos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientobancos;
        }

        public String GenerarProvisionMovBancos(Int32 idMovBanco, Int32 idEmpresa, Int32 idLocal, String Usuario)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarProvisionMovBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = (oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"])) + " " +
                                    (oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"])) + " " +
                                    (oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]));
                        }
                    }
                }
            }

            return Codigo;
        }

        public Int32 CambiarEstadoMovBancos(Int32 idMovBanco, String Estado, String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoMovBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = idMovBanco;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 2).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public MovimientoBancosE ActualizarMovimientoBancosDocIngresos(MovimientoBancosE movimientobancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMovimientoBancosDocIngresos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMovBanco", SqlDbType.Int).Value = movimientobancos.idMovBanco;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = movimientobancos.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = movimientobancos.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = movimientobancos.numDocumento;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = movimientobancos.fecDocumento;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = movimientobancos.fecVencimiento;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = movimientobancos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return movimientobancos;
        }

    }
}