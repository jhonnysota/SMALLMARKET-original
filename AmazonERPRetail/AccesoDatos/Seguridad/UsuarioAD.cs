using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioAD : DbConection
    {

        public Usuario LlenarEntidad(IDataReader oReader)
        {
            Usuario usuario = new Usuario();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.IdPersona = oReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Credencial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.Credencial = oReader["Credencial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Credencial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.NombreCorto = oReader["NombreCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Reset'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.Reset = oReader["Reset"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Reset"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.NombreCompleto = oReader["NombreCompleto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCompleto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.Correo = oReader["Correo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Credencial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuario.NombreCompuesto = oReader["Credencial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Credencial"]) + " - " + usuario.NombreCompleto;

            return usuario;
        }

        public Usuario InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Credencial", SqlDbType.NVarChar, 50).Value = usuario.Credencial;
                    oComando.Parameters.Add("@NombreCorto", SqlDbType.VarChar, 20).Value = usuario.NombreCorto;
                    oComando.Parameters.Add("@Clave", SqlDbType.VarBinary, 256).Value = usuario.Clave;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = usuario.IdPersona;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = usuario.Estado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuario.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuario;
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = usuario.IdPersona;
                    oComando.Parameters.Add("@Credencial", SqlDbType.NVarChar, 50).Value = usuario.Credencial;
                    oComando.Parameters.Add("@NombreCorto", SqlDbType.VarChar, 20).Value = usuario.NombreCorto;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = usuario.Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = usuario.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuario;
        }

        public Int32 BorrarUsuario(Int32 IdPersona)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", IdPersona);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<Usuario> ListarUsuario(String filtro, Boolean activo, Boolean inactivo)
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = filtro;
                    oComando.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                    oComando.Parameters.Add("@inactivo", SqlDbType.Bit).Value = inactivo;

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

        public List<Usuario> ListarUsuarioTodos(String filtro, Int32? tipoPersona, Boolean activo, Boolean inactivo)
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioTodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = filtro;
                    oComando.Parameters.Add("@TipoPersona", SqlDbType.Int).Value = tipoPersona;
                    oComando.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                    oComando.Parameters.Add("@inactivo", SqlDbType.Bit).Value = inactivo;
        
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

        public Usuario RecuperarUsuarioPorCodigo(Int32 IdPersona, Int32 idEmpresa)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarUsuarioPorID", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuario = LlenarEntidad(oReader);
                        }    
                    }
                }
            }

            return usuario;
        }

        public Usuario CambiarEstadoUsuario(Int32 IdPersona, Boolean estado)
        {
            Usuario usuario = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdUsuario", IdPersona);
                    oComando.Parameters.AddWithValue("@Estado", estado);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuario = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuario;

        }

        public Usuario ValidarUsuario(String Credencial, Byte[]Clave)
        {
            Usuario usuario = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ValidarUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Login", Credencial);
                    oComando.Parameters.AddWithValue("@ClaveAConsultar", Clave);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuario = LlenarEntidad(oReader);
                            usuario.Clave = (Byte[])oReader["Clave"];
                        }    
                    }
                }
            }

            return usuario;
        }

        public Boolean ModificarClave(String Credencial, Byte[] Clave, Boolean reset)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ModificarClaveUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Credencial", Credencial);
                    oComando.Parameters.AddWithValue("@ClaveNueva", Clave);
                    oComando.Parameters.AddWithValue("@Reset", reset);
                    
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public Usuario RecuperarUsuarioAcccion(String Credencial, Byte[] Clave, Int32 IdEmpresa, Int32 IdAccion)
        {
            Usuario usuario = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarUsuarioAcccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Login", Credencial);
                    oComando.Parameters.AddWithValue("@Clave", Clave);
                    oComando.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    oComando.Parameters.AddWithValue("@IdAccion", IdAccion);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuario = LlenarEntidad(oReader);
                        }    
                    }
                }
            }

            return usuario;
        }

        public List<Usuario> ListarUsuarioPorEmpresa(Int32 IdEmpresa, Int32 IdLocal, String filtro, String activo)
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioPorEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    oComando.Parameters.AddWithValue("@IdLocal", IdLocal);
                    oComando.Parameters.AddWithValue("@filtro", filtro);
                    oComando.Parameters.AddWithValue("@activo", activo);
                    
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

        public List<Usuario> ListarUsuarioEmpresa(Int32 IdEmpresa, String filtro, String activo)
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    oComando.Parameters.AddWithValue("@filtro", filtro);
                    oComando.Parameters.AddWithValue("@activo", activo);

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

        public List<Usuario> ListarUsuariosCorreos()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuariosCorreos", oConexion))
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

        public Byte[] ObtenerClaveUsuario(Int32 idPersona)
        {
            Byte[] Clave = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerClaveUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Clave = (Byte[])(oReader["Clave"]);
                        }
                    }
                }
            }

            return Clave;
        }

        public List<Usuario> ListarUsuariosActivos()
        {
            List<Usuario> listaEntidad = new List<Usuario>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuariosActivos", oConexion))
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

    }
}