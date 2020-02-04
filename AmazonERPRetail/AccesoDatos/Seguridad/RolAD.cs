using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class RolAD : DbConection
    {

        public Rol LlenarEntidad(IDataReader oReader)
        {
            Rol rol = new Rol();
            DataView dvSchema = oReader.GetSchemaTable().DefaultView;

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdRol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.IdRol = oReader["IdRol"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdRol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.Nombre = oReader["Nombre"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.Descripcion = oReader["Descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rol.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? string.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            return rol;
        }

        public Rol InsertarRol(Rol rol)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    oComando.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
                    oComando.Parameters.AddWithValue("@UsuarioRegistro", rol.UsuarioRegistro);
                    oComando.Parameters.AddWithValue("@Estado", rol.Estado);                    

                    oConexion.Open();
                    rol.IdRol = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return rol;
        }

        public Rol ActualizarRol(Rol rol)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", rol.IdRol);
                    oComando.Parameters.AddWithValue("@Nombre", rol.Nombre);
                    oComando.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
                    oComando.Parameters.AddWithValue("@Estado", rol.Estado);
                    oComando.Parameters.AddWithValue("@UsuarioModificacion", rol.UsuarioModificacion);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return rol;
        }

        public Int32 BorrarRol(Int32 IdRol)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", IdRol);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<Rol> ListarRol(String cod, bool activo, bool inactivo)
        {
            List<Rol> listaEntidad = new List<Rol>();
            Rol entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@filtro", cod);
                    oComando.Parameters.AddWithValue("@Activo", activo);
                    oComando.Parameters.AddWithValue("@Inactivo", inactivo);
                    
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

        public Rol RecuperarRolPorCodigo(Int32 IdRol)
        {
            Rol rol = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", IdRol);
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            rol = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return rol;
        }

        public Rol CambiarEstadoRol(Int32 IdRol, bool estado)
        {
            Rol rol = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", IdRol);
                    oComando.Parameters.AddWithValue("@Estado", estado);
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            rol = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return rol;
        }

        public List<Rol> ListarRolPorUsuario(Int32 idPersona, Int32 idEmpresa)
        {
            List<Rol> listaEntidad = new List<Rol>();
            Rol entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRolUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idPersona", idPersona);
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);

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

    }

}