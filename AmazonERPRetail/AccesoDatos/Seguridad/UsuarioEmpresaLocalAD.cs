using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioEmpresaLocalAD : DbConection
    {

        public UsuarioEmpresaLocal LlenarEntidad(IDataReader oReader)
        {
            UsuarioEmpresaLocal usuarioempresalocal = new UsuarioEmpresaLocal();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.IdPersona = oReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.IdEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.IdLocal = oReader["IdLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ?String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioActualizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.UsuarioActualizacion = oReader["UsuarioActualizacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioActualizacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaActualizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.FechaActualizacion = oReader["FechaActualizacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaActualizacion"]);

            //Extension
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.NombreEmpresa = oReader["NombreEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreUsuario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioempresalocal.NombreUsuario = oReader["NombreUsuario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreUsuario"]);

            return  usuarioempresalocal;
        }

        public UsuarioEmpresaLocal InsertarUsuarioEmpresaLocal(UsuarioEmpresaLocal usuarioempresalocal)
        {
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_InsertarUsuarioEmpresaLocal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", usuarioempresalocal.IdPersona); 
			        comando.Parameters.AddWithValue("@IdEmpresa", usuarioempresalocal.IdEmpresa); 
			        comando.Parameters.AddWithValue("@IdLocal", usuarioempresalocal.IdLocal); 
			        comando.Parameters.AddWithValue("@UsuarioRegistro", usuarioempresalocal.UsuarioRegistro); 

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }

            return usuarioempresalocal;
        }

        public Int32 BorrarUsuarioEmpresaLocalPorIdPersona(Int32 IdPersona)
        {
            Int32 resp = 0;
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_BorrarUsuarioEmpresaLocal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdPersona", IdPersona);
  
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioEmpresaLocal> ListarUsuarioEmpresaLocal()
        {
            List<UsuarioEmpresaLocal> listaEntidad = new List<UsuarioEmpresaLocal>();

            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_ListarUsuarioEmpresaLocal", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(reader));
                        }    
                    }
                }
            }

            return listaEntidad;
        }
        
        public List<UsuarioEmpresaLocal> RecuperarUsuarioEmpresaLocalPorEmpresa(Int32 idEmpresa)
        {
            List<UsuarioEmpresaLocal> listaEntidad = new List<UsuarioEmpresaLocal>();

            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_RecuperarUsuarioEmpresaLocalPorEmpresa", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
			        comando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(reader));
                        }    
                    }
                }
            }

            return listaEntidad;
        }

        public List<UsuarioEmpresaLocal> ListarUsuarioEmpresaLocalPorUsuario(Int32 idPersona, Int32 idEmpresa) 
        {
            List<UsuarioEmpresaLocal> vListaUsuarioEmpresaLocal = new List<UsuarioEmpresaLocal>();
            UsuarioEmpresaLocal vUsuarioEmpresaLocal = null;

            using (SqlConnection oConexion= ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UsuarioEmpresaLocal_RecuperarPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdUsuario", idPersona);
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);

                    oConexion.Open();

                    using (SqlDataReader reader = oComando.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            vUsuarioEmpresaLocal = LlenarEntidad(reader);
                            vUsuarioEmpresaLocal.NombreLocal = reader["NombreLocal"].ToString();
                            vListaUsuarioEmpresaLocal.Add(vUsuarioEmpresaLocal);                        
                        }
                    }
                }
            }

            return vListaUsuarioEmpresaLocal;
        }

        public Int32 BorrarUsuarioLocalEmpresa(Int32 idPersona, Int32 idEmpresa) 
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarUsuarioLocalEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", idPersona);
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;        
        }
   
    }
}