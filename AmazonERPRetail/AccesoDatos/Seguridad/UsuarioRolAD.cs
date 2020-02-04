using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioRolAD : DbConection
    {

        public UsuarioRol LlenarEntidad(IDataReader oReader)
        {
            UsuarioRol usuariorol = new UsuarioRol();
            usuariorol.IdPersona = Convert.ToInt32(oReader["IdPersona"]);
            usuariorol.IdRol = Convert.ToInt32(oReader["IdRol"]);
            usuariorol.IdEmpresa = Convert.ToInt32(oReader["IdEmpresa"]);
            usuariorol.Estado = Convert.ToBoolean(oReader["Estado"]);
            usuariorol.FechaRegistro = Convert.ToDateTime(oReader["FechaRegistro"]);
            usuariorol.UsuarioRegistro = Convert.ToString(oReader["UsuarioRegistro"]);
            usuariorol.FechaActualizacion = Convert.ToDateTime(oReader["FechaActualizacion"]);
            usuariorol.UsuarioActualizacion = Convert.ToString(oReader["UsuarioActualizacion"]);

            return usuariorol;
        }

        public UsuarioRol InsertarUsuarioRol(UsuarioRol usuariorol)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", usuariorol.IdPersona);
                    oComando.Parameters.AddWithValue("@IdRol", usuariorol.IdRol);
                    oComando.Parameters.AddWithValue("@IdEmpresa", usuariorol.IdEmpresa);
                    oComando.Parameters.AddWithValue("@Estado", usuariorol.Estado);
                    oComando.Parameters.AddWithValue("@FechaRegistro", usuariorol.FechaRegistro);
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", usuariorol.UsuarioRegistro);
                    oComando.Parameters.AddWithValue("@FechaActualizacion", usuariorol.FechaActualizacion);
                    oComando.Parameters.AddWithValue("@UsuarioActualizacion", usuariorol.UsuarioActualizacion);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuariorol;
        }

        public UsuarioRol ActualizarUsuarioRol(UsuarioRol usuariorol)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", usuariorol.IdPersona);
                    oComando.Parameters.AddWithValue("@IdRol", usuariorol.IdRol);
                    oComando.Parameters.AddWithValue("@IdEmpresa", usuariorol.IdEmpresa);
                    oComando.Parameters.AddWithValue("@Estado", usuariorol.Estado);
                    oComando.Parameters.AddWithValue("@FechaRegistro", usuariorol.FechaRegistro);
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", usuariorol.UsuarioRegistro);
                    oComando.Parameters.AddWithValue("@FechaActualizacion", usuariorol.FechaActualizacion);
                    oComando.Parameters.AddWithValue("@UsuarioActualizacion", usuariorol.UsuarioActualizacion);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuariorol;
        }

        public Int32 BorrarUsuarioRol(Int32 IdEmpresa, Int32 IdPersona)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarUsuarioRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();

                }
            }

            return resp;
        }

        public List<UsuarioRol> ListarUsuarioRol()
        {
            List<UsuarioRol> listaEntidad = new List<UsuarioRol>();
            UsuarioRol entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioRol", oConexion))
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

        public UsuarioRol RecuperarUsuarioRolPorCodigo(Int32 IdPersona, Int32 IdRol, Int32 IdEmpresa)
        {
            UsuarioRol usuariorol = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;
                    oComando.Parameters.Add("@IdRol", SqlDbType.Int).Value = IdRol;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuariorol = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return usuariorol;
        }

    }
}