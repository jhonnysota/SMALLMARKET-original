using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class CtaCte_DetAD : DbConection
    {

        public CtaCte_DetE LlenarEntidad(IDataReader oReader)
        {
            CtaCte_DetE ctacte_det = new CtaCte_DetE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.idDocumentoMov = oReader["idDocumentoMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.SerieMov = oReader["SerieMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.NumeroMov = oReader["NumeroMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.FechaMovimiento = oReader["FechaMovimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.MontoMov = oReader["MontoMov"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipAccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.TipAccion = oReader["TipAccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipAccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.EsDetraccion = oReader["EsDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cargo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.Cargo = oReader["Cargo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cargo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Abono'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.Abono = oReader["Abono"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Abono"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte_det.FechaVencimiento = oReader["FechaVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaVencimiento"]);

            return  ctacte_det;
        }

        public CtaCte_DetE InsertarMaeCtaCteDet(CtaCte_DetE ctacte_det)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMaeCtaCteDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ctacte_det.idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = ctacte_det.idCtaCte;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = ctacte_det.idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 4).Value = ctacte_det.SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = ctacte_det.NumeroMov;
                    oComando.Parameters.Add("@FechaMovimiento", SqlDbType.DateTime).Value = ctacte_det.FechaMovimiento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = ctacte_det.idMoneda;
                    oComando.Parameters.Add("@MontoMov", SqlDbType.Decimal).Value = ctacte_det.MontoMov;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacte_det.TipoCambio;
                    oComando.Parameters.Add("@TipAccion", SqlDbType.Char, 1).Value = ctacte_det.TipAccion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte_det.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte_det.codCuenta;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = ctacte_det.desGlosa;
                    oComando.Parameters.Add("@EsDetraccion", SqlDbType.Bit).Value = ctacte_det.EsDetraccion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ctacte_det.UsuarioRegistro;

                    oConexion.Open();
                    ctacte_det.idCtaCteItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ctacte_det;
        }
        
        public CtaCte_DetE ActualizarMaeCtaCteDet(CtaCte_DetE ctacte_det)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMaeCtaCteDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ctacte_det.idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = ctacte_det.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = ctacte_det.idCtaCteItem;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = ctacte_det.idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 4).Value = ctacte_det.SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = ctacte_det.NumeroMov;
                    oComando.Parameters.Add("@FechaMovimiento", SqlDbType.DateTime).Value = ctacte_det.FechaMovimiento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = ctacte_det.idMoneda;
                    oComando.Parameters.Add("@MontoMov", SqlDbType.Decimal).Value = ctacte_det.MontoMov;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacte_det.TipoCambio;
                    oComando.Parameters.Add("@TipAccion", SqlDbType.Char, 1).Value = ctacte_det.TipAccion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte_det.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte_det.codCuenta;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = ctacte_det.desGlosa;
                    oComando.Parameters.Add("@EsDetraccion", SqlDbType.Bit).Value = ctacte_det.EsDetraccion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ctacte_det.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ctacte_det;
        }        

        public Int32 EliminarMaeCtaCteDetalle(Int32 idEmpresa, Int32 idCtaCte)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMaeCtaCteDetalle", oConexion))
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

        //Lista de Abono de CtaCte por idCtaCte
        public List<CtaCte_DetE> ListarMaeCtaCteDetAbonos(Int32 idEmpresa, Int32 idCtaCte, Boolean EsDetraccion = false)
        {
            List<CtaCte_DetE> listaEntidad = new List<CtaCte_DetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMaeCtaCteDetAbonos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
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

        public CtaCte_DetE ObtenerMaeCtaCteDet(Int32 idEmpresa, String numAnio, String numMes, Int32 IdPersona, String idDocumento, String NumSerie, String NumDocumento, String idDocumentoOrig, String NumSerieOrig, String NumDocOrig)
        {        
            CtaCte_DetE ctacte_det = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMaeCtaCteDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numAnio", SqlDbType.VarChar, 4).Value = numAnio;
					oComando.Parameters.Add("@numMes", SqlDbType.VarChar, 2).Value = numMes;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = IdPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 10).Value = NumSerie;
					oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;
					oComando.Parameters.Add("@idDocumentoOrig", SqlDbType.VarChar, 2).Value = idDocumentoOrig;
					oComando.Parameters.Add("@NumSerieOrig", SqlDbType.VarChar, 4).Value = NumSerieOrig;
					oComando.Parameters.Add("@NumDocOrig", SqlDbType.VarChar, 20).Value = NumDocOrig;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte_det = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte_det;
        }

        public List<CtaCte_DetE> ListarMaeCtaCteDet(Int32 idEmpresa, Int32 idCtaCte)
        {
            List<CtaCte_DetE> listaEntidad = new List<CtaCte_DetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMaeCtaCteDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

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

        //Procedimiento para eliminar la CtaCte Detalle por documento si es que abono y no es detracción
        public Int32 EliminarCtaCteDetPorDocumento(Int32 idEmpresa, String idDocumentoMov, String SerieMov, String NumeroMov)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCtaCteDetPorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 20).Value = SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = NumeroMov;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public CtaCte_DetE CtaCteDetDetraccionAbono(Int32 idEmpresa, String idDocumentoMov, String SerieMov, String NumeroMov)
        {
            CtaCte_DetE ctacte_det = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CtaCteDetDetraccionAbono", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 20).Value = SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = NumeroMov;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            ctacte_det = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte_det;
        }

        public Int32 EliminarMaeCtaCteDetallePorIdItem(Int32 idCtaCteItem)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMaeCtaCteDetallePorIdItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarMaeCtaCteDetPorIdItem(CtaCte_DetE ctacte_det)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMaeCtaCteDetPorIdItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = ctacte_det.idCtaCteItem;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = ctacte_det.idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 4).Value = ctacte_det.SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = ctacte_det.NumeroMov;
                    oComando.Parameters.Add("@FechaMovimiento", SqlDbType.DateTime).Value = ctacte_det.FechaMovimiento.Date;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = ctacte_det.idMoneda;
                    oComando.Parameters.Add("@MontoMov", SqlDbType.Decimal).Value = ctacte_det.MontoMov;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ctacte_det.TipoCambio;
                    oComando.Parameters.Add("@TipAccion", SqlDbType.Char, 1).Value = ctacte_det.TipAccion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = ctacte_det.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = ctacte_det.codCuenta;
                    oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = ctacte_det.desGlosa;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ctacte_det.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 RegenerarCtaCte(Int32 idEmpresa, Int32 idPersona, String idDocumentoMov, String SerieMov, String NumeroMov)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegenerarCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 20).Value = SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = NumeroMov;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 GenerarCtaCtePorVoucherItem(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarCtaCtePorVoucherItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public CtaCte_DetE ObtenerMaeCtaCteDetPorId(Int32 idCtaCteItem)
        {
            CtaCte_DetE ctacte_det = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMaeCtaCteDetPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = idCtaCteItem;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ctacte_det = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ctacte_det;
        }

        //Abonos
        public Int32 EliminarCtaCteDetPorIdPorDocumento(Int32 idEmpresa, Int32 idCtaCte, String idDocumentoMov, String SerieMov, String NumeroMov)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCtaCteDetPorIdPorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;
                    oComando.Parameters.Add("@idDocumentoMov", SqlDbType.VarChar, 2).Value = idDocumentoMov;
                    oComando.Parameters.Add("@SerieMov", SqlDbType.VarChar, 20).Value = SerieMov;
                    oComando.Parameters.Add("@NumeroMov", SqlDbType.VarChar, 20).Value = NumeroMov;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}