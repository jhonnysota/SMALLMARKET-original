using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlanCuentasVersionAD : DbConection
    {
        
        public PlanCuentasVersionE LlenarEntidad(IDataReader oReader)
        {
            PlanCuentasVersionE plancuentasversion = new PlanCuentasVersionE();
            plancuentasversion.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);  
			plancuentasversion.numVerPlanCuentas = Convert.ToString(oReader["numVerPlanCuentas"]);  
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.fecInicio = oReader["fecInicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecInicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.fecFinal = oReader["fecFinal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UltimoNivel'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentasversion.UltimoNivel = oReader["UltimoNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["UltimoNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVigente'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.indVigente = oReader["indVigente"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indVigente"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plancuentasversion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Longitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plancuentasversion.Longitud = oReader["Longitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Longitud"]);

            return  plancuentasversion;        
        }

        public PlanCuentasVersionE InsertarPlanCuentasVersion(PlanCuentasVersionE plancuentasversion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanCuentasVersion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentasversion.idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentasversion.numVerPlanCuentas;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = plancuentasversion.Descripcion;
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = plancuentasversion.fecInicio;
					oComando.Parameters.Add("@fecFinal", SqlDbType.SmallDateTime).Value = plancuentasversion.fecFinal;
					oComando.Parameters.Add("@indVigente", SqlDbType.Char, 1).Value = plancuentasversion.indVigente;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = plancuentasversion.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentasversion;        
        }
        
        public PlanCuentasVersionE ActualizarPlanCuentasVersion(PlanCuentasVersionE plancuentasversion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanCuentasVersion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plancuentasversion.idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plancuentasversion.numVerPlanCuentas;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = plancuentasversion.Descripcion;
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = plancuentasversion.fecInicio;
					oComando.Parameters.Add("@fecFinal", SqlDbType.SmallDateTime).Value = plancuentasversion.fecFinal;
					oComando.Parameters.Add("@indVigente", SqlDbType.Char, 1).Value = plancuentasversion.indVigente;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = plancuentasversion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plancuentasversion;
        }        

        public List<PlanCuentasVersionE> ListarPlanCuentasVersion(Int32 idEmpresa)
        {
           List<PlanCuentasVersionE> listaEntidad = new List<PlanCuentasVersionE>();
           PlanCuentasVersionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanCuentasVersion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public PlanCuentasVersionE ObtenerPlanCuentasVersion(Int32 idEmpresa, String numVerPlanCuentas)
        {        
            PlanCuentasVersionE plancuentasversion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanCuentasVersion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plancuentasversion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return plancuentasversion;        
        }

        public PlanCuentasVersionE VersionPlanCuentasActual(Int32 idEmpresa)
        {
            PlanCuentasVersionE plancuentasversion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVersionPlanCuentasActual", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plancuentasversion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return plancuentasversion;
        }

    }
}