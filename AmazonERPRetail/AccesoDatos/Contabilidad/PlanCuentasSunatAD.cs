using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlanCuentasSunatAD : DbConection
    {
        
        public PlanCuentasSunatE LlenarEntidad(IDataReader oReader)
        {
            PlanCuentasSunatE plancuentassunat = new PlanCuentasSunatE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentassunat.codCuentaSunat = oReader["codCuentaSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaSunat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentassunat.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentassunat.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentassunat.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentassunat.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentassunat.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  plancuentassunat;        
        }

        public PlanCuentasSunatE InsertarPlanCuentasSunat(PlanCuentasSunatE plancuentassunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = plancuentassunat.codCuentaSunat;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = plancuentassunat.Descripcion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = plancuentassunat.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return plancuentassunat;
        }
        
        public PlanCuentasSunatE ActualizarPlanCuentasSunat(PlanCuentasSunatE plancuentassunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = plancuentassunat.codCuentaSunat;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = plancuentassunat.Descripcion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = plancuentassunat.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return plancuentassunat;
        }        

        public int EliminarPlanCuentasSunat(String codCuentaSunat)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlanCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = codCuentaSunat;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<PlanCuentasSunatE> ListarPlanCuentasSunat()
        {
           List<PlanCuentasSunatE> listaEntidad = new List<PlanCuentasSunatE>();
           PlanCuentasSunatE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public PlanCuentasSunatE ObtenerPlanCuentasSunat(String codCuentaSunat)
        {        
            PlanCuentasSunatE plancuentassunat = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@codCuentaSunat", SqlDbType.VarChar, 20).Value = codCuentaSunat;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plancuentassunat = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return plancuentassunat;
        }

        public List<PlanCuentasSunatE> BuscarPlanCuentasSunat(String codCuentaSunat, String Descripcion)
        {
            List<PlanCuentasSunatE> listaEntidad = new List<PlanCuentasSunatE>();
            PlanCuentasSunatE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BuscarPlanCuentasSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@codCuentaSunat", SqlDbType.NVarChar, 25).Value = codCuentaSunat;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 100).Value = Descripcion;

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

                oConexion.Close();
            }

            return listaEntidad;
        }


    }
}