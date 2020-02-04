using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlanCuentaDifCambioUsuarioAD : DbConection
    {
        
        public PlanCuentasDifCambioUsuarioE LlenarEntidad(IDataReader oReader)
        {
            PlanCuentasDifCambioUsuarioE plancuentas = new PlanCuentasDifCambioUsuarioE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

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

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioAsignado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.UsuarioAsignado = oReader["UsuarioAsignado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioAsignado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.numFile = oReader["numFile"] == DBNull.Value ? "0" : Convert.ToString(oReader["numFile"]).Trim();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentas.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            

            return plancuentas;
        }

        public int InsertarPlanCuentasDifCambioUsuario(PlanCuentasDifCambioUsuarioE oEntidad)
        {
            int result=-1;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanCuentasDifCambioUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.AddWithValue("@IdEmpresa", oEntidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", oEntidad.numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@codCuenta", oEntidad.codCuenta);
                    oComando.Parameters.AddWithValue("@numFile", oEntidad.numFile);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", oEntidad.UsuarioAsignado);
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", oEntidad.UsuarioRegistro);

                    oConexion.Open();
                    result = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return result;
        }

        public int ActualizarPlanCuentasDifCambioUsuario(PlanCuentasDifCambioUsuarioE oEntidad)
        {
            int result = -1;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanCuentasDifCambioUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.AddWithValue("@IdEmpresa", oEntidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", oEntidad.numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@codCuenta", oEntidad.codCuenta);
                    oComando.Parameters.AddWithValue("@numFile", oEntidad.numFile);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", oEntidad.UsuarioAsignado);
                    oComando.Parameters.AddWithValue("@UsuarioModificacion", oEntidad.UsuarioRegistro);

                    oConexion.Open();
                    result = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return result;
        }

        public List<PlanCuentasDifCambioUsuarioE> ListarPlanCuentasDifCambioUsuario(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            List<PlanCuentasDifCambioUsuarioE> listaEntidad = new List<PlanCuentasDifCambioUsuarioE>();
            PlanCuentasDifCambioUsuarioE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanCuentasDifCambioUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado);

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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuario(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            List<PlanCuentasDifCambioUsuarioE> listaEntidad = new List<PlanCuentasDifCambioUsuarioE>();
            PlanCuentasDifCambioUsuarioE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasDifCambioUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado);

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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuarioDolar(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            List<PlanCuentasDifCambioUsuarioE> listaEntidad = new List<PlanCuentasDifCambioUsuarioE>();
            PlanCuentasDifCambioUsuarioE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasDifCambioUsuarioDolar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado);

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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public List<PlanCuentasDifCambioUsuarioE> ObtenerPlanCuentasDifCambioUsuarioSoles(int idEmpresa, string numVerPlanCuentas, string UsuarioAsignado)
        {
            List<PlanCuentasDifCambioUsuarioE> listaEntidad = new List<PlanCuentasDifCambioUsuarioE>();
            PlanCuentasDifCambioUsuarioE plan = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasDifCambioUsuarioSoles", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado);

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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public int EliminarPlanCuentasDifCambioUsuario(PlanCuentasDifCambioUsuarioE oEntidad)
        {
            int result = -1;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlanCuentasDifCambioUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.AddWithValue("@IdEmpresa", oEntidad.idEmpresa);
                    oComando.Parameters.AddWithValue("@numVerPlanCuentas", oEntidad.numVerPlanCuentas);
                    oComando.Parameters.AddWithValue("@codCuenta", oEntidad.codCuenta);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", oEntidad.UsuarioAsignado);

                    oConexion.Open();
                    result = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return result;
        }
        
    }
}