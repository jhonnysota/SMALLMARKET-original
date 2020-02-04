using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlanCuentasEstrucAD : DbConection
    {
        
        public PlanCuentasEstrucE LlenarEntidad(IDataReader oReader)
        {
            PlanCuentasEstrucE plancuentasestruc = new PlanCuentasEstrucE();
            plancuentasestruc.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);  
			plancuentasestruc.numVerPlanCuentas = Convert.ToString(oReader["numVerPlanCuentas"]);  
			plancuentasestruc.numNivelEstruc = Convert.ToInt32(oReader["numNivelEstruc"]);  
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLongiEstruc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.numLongiEstruc = oReader["numLongiEstruc"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numLongiEstruc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indFteFinanciamiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.indFteFinanciamiento = oReader["indFteFinanciamiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indFteFinanciamiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.indMoneda = oReader["indMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasestruc.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  plancuentasestruc;        
        }

        public PlanCuentasEstrucE InsertarPlanCuentasEstruc(PlanCuentasEstrucE plancuentasestruc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanCuentasEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentasestruc.idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentasestruc.numVerPlanCuentas;
					oComando.Parameters.Add("@numNivelEstruc", SqlDbType.Int).Value = plancuentasestruc.numNivelEstruc;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = plancuentasestruc.Descripcion;
					oComando.Parameters.Add("@numLongiEstruc", SqlDbType.Int).Value = plancuentasestruc.numLongiEstruc;
					oComando.Parameters.Add("@indFteFinanciamiento", SqlDbType.Char, 1).Value = plancuentasestruc.indFteFinanciamiento;
					oComando.Parameters.Add("@indMoneda", SqlDbType.Char, 1).Value = plancuentasestruc.indMoneda;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = plancuentasestruc.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentasestruc;        
        }
        
        public PlanCuentasEstrucE ActualizarPlanCuentasEstruc(PlanCuentasEstrucE plancuentasestruc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanCuentasEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentasestruc.idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentasestruc.numVerPlanCuentas;
					oComando.Parameters.Add("@numNivelEstruc", SqlDbType.Int).Value = plancuentasestruc.numNivelEstruc;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = plancuentasestruc.Descripcion;
					oComando.Parameters.Add("@numLongiEstruc", SqlDbType.Int).Value = plancuentasestruc.numLongiEstruc;
					oComando.Parameters.Add("@indFteFinanciamiento", SqlDbType.Char, 1).Value = plancuentasestruc.indFteFinanciamiento;
					oComando.Parameters.Add("@indMoneda", SqlDbType.Char, 1).Value = plancuentasestruc.indMoneda;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = plancuentasestruc.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentasestruc;
        }        

        public Int32 EliminarPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas, Int32 numNivelEstruc)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlanCuentasEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
					oComando.Parameters.Add("@numNivelEstruc", SqlDbType.Int).Value = numNivelEstruc;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PlanCuentasEstrucE> ListarPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas)
        {
           List<PlanCuentasEstrucE> listaEntidad = new List<PlanCuentasEstrucE>();
           PlanCuentasEstrucE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanCuentasEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
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

        public PlanCuentasEstrucE ObtenerPlanCuentasEstruc(Int32 idEmpresa, String numVerPlanCuentas, Int32 numNivelEstruc)
        {        
            PlanCuentasEstrucE plancuentasestruc = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@numNivelEstruc", SqlDbType.Int).Value = numNivelEstruc;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plancuentasestruc = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return plancuentasestruc;        
        }
    }
}