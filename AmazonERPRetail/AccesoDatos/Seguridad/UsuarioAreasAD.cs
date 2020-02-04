using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioAreasAD : DbConection
    {

        public UsuarioAreasE LlenarEntidad(IDataReader oReader)
        {
            UsuarioAreasE usuarioareas = new UsuarioAreasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.idArea = oReader["idArea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioareas.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioareas.descripcion = oReader["descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["descripcion"]);

            return  usuarioareas;        
        }

        public UsuarioAreasE InsertarUsuarioAreas(UsuarioAreasE usuarioareas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioAreas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioareas.idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioareas.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = usuarioareas.idLocal;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = usuarioareas.idArea;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuarioareas.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioareas;
        }
        
        public UsuarioAreasE ActualizarUsuarioAreas(UsuarioAreasE usuarioareas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioAreas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioareas.idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioareas.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = usuarioareas.idLocal;
                    oComando.Parameters.Add("@idArea", SqlDbType.Int).Value = usuarioareas.idArea;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = usuarioareas.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioareas;
        }        

        public int EliminarUsuarioAreas(Int32 idPersona)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioAreas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioAreasE> ListarUsuarioAreas()
        {
           List<UsuarioAreasE> listaEntidad = new List<UsuarioAreasE>();
           UsuarioAreasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioAreas", oConexion))
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
            }

            return listaEntidad;
        }

        public List<UsuarioAreasE> ListarUsuarioAreasPorEmpresa(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            List<UsuarioAreasE> listaEntidad = new List<UsuarioAreasE>();
            UsuarioAreasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioAreasPorEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
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

        public UsuarioAreasE ObtenerUsuarioAreas(Int32 idPersona)
        {        
            UsuarioAreasE usuarioareas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioAreas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioareas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuarioareas;
        }

    }
}