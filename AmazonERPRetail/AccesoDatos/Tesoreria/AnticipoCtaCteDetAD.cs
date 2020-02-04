using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class AnticipoCtaCteDetAD : DbConection
    {

        public AnticipoCtaCteDetE LlenarEntidad(IDataReader oReader)
        {
            AnticipoCtaCteDetE ctacte_det = new AnticipoCtaCteDetE();

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
                ctacte_det.FechaVencimiento = oReader["FechaVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaVencimiento"]);

            return ctacte_det;
        }

        public AnticipoCtaCteDetE InsertarAnticipoCtaCteDet(AnticipoCtaCteDetE ctacte_det)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAnticipoCtaCteDet", oConexion))
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

        public AnticipoCtaCteDetE ActualizarAnticipoCtaCteDet(AnticipoCtaCteDetE ctacte_det)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAnticipoCtaCteDet", oConexion))
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

        public Int32 EliminarAnticipoCtaCteDetalle(Int32 idEmpresa, Int32 idCtaCte)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticipoCtaCteDetalle", oConexion))
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

        public List<AnticipoCtaCteDetE> ListarAnticipoCtaCteDetAbonos(Int32 idEmpresa, Int32 idCtaCte)
        {
            List<AnticipoCtaCteDetE> listaEntidad = new List<AnticipoCtaCteDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAnticipoCtaCteDetAbonos", oConexion))
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

        public AnticipoCtaCteDetE ObtenerAnticipoCtaCteDet(Int32 idEmpresa, String numAnio, String numMes, Int32 IdPersona, String idDocumento, String NumSerie, String NumDocumento, String idDocumentoOrig, String NumSerieOrig, String NumDocOrig)
        {
            AnticipoCtaCteDetE ctacte_det = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAnticipoCtaCteDet", oConexion))
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

        public List<AnticipoCtaCteDetE> ListarAnticipoCtaCteDet(Int32 idEmpresa, Int32 idCtaCte)
        {
            List<AnticipoCtaCteDetE> listaEntidad = new List<AnticipoCtaCteDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAnticipoCtaCteDet", oConexion))
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

        public Int32 EliminarAnticipoCtaCteDetPorDocumento(Int32 idEmpresa, String idDocumentoMov, String SerieMov, String NumeroMov)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAnticipoCtaCteDetPorDocumento", oConexion))
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

        public AnticipoCtaCteDetE AnticipoCtaCteDetDetraccionAbono(Int32 idEmpresa, String idDocumentoMov, String SerieMov, String NumeroMov)
        {
            AnticipoCtaCteDetE ctacte_det = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnticipoCtaCteDetDetraccionAbono", oConexion))
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

    }
}
