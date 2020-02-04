using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ParametroAD : DbConection
    {
        
        public ParametroE LlenarEntidad(IDataReader oReader)
        {
            ParametroE parametro = new ParametroE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.IdEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdParametro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.IdParametro = oReader["IdParametro"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdParametro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorDecimal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.ValorDecimal = oReader["ValorDecimal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorDecimal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorCadena'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.ValorCadena = oReader["ValorCadena"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ValorCadena"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                parametro.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return parametro;
        }

        public ParametroE InsertarParametro(ParametroE parametro)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = parametro.IdEmpresa;
                    oComando.Parameters.Add("@IdParametro", SqlDbType.Int).Value = parametro.IdParametro;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = parametro.idUsuario;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = parametro.Nombre;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = parametro.Descripcion;
                    oComando.Parameters.Add("@ValorDecimal", SqlDbType.Decimal).Value = parametro.ValorDecimal;
                    oComando.Parameters.Add("@ValorCadena", SqlDbType.VarChar, 100).Value = parametro.ValorCadena;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = parametro.Estado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = parametro.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametro;
        }

        public ParametroE ActualizarParametro(ParametroE parametro)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = parametro.IdEmpresa;
                    oComando.Parameters.Add("@IdParametro", SqlDbType.Int).Value = parametro.IdParametro;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = parametro.idUsuario;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = parametro.Nombre;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = parametro.Descripcion;
                    oComando.Parameters.Add("@ValorDecimal", SqlDbType.Decimal).Value = parametro.ValorDecimal;
                    oComando.Parameters.Add("@ValorCadena", SqlDbType.VarChar, 100).Value = parametro.ValorCadena;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = parametro.Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = parametro.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return parametro;
        }

        public Int32 EliminarParametro(Int32 IdEmpresa, Int32 IdParametro, Int32 idUsuario)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    oComando.Parameters.Add("@IdParametro", SqlDbType.Int).Value = IdParametro;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ParametroE> ListarParametro()
        {
            List<ParametroE> listaEntidad = new List<ParametroE>();
            ParametroE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParametro", oConexion))
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

        public Int32 ActualizarEstadoParametro(int idEmpresa, int idParametro, bool estado, string usuarioModificacion, DateTime fechaModificacion)
        {
            Int32 RESPUESTA = 0;

            fechaModificacion = DateTime.Now;
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_ActualizarEstadoParametro", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    comando.Parameters.AddWithValue("@IdParametro", idParametro);
                    comando.Parameters.AddWithValue("@Estado", estado);
                    comando.Parameters.AddWithValue("@UsuarioModificacion", usuarioModificacion);
                    comando.Parameters.AddWithValue("@FechaModificacion", fechaModificacion);

                    conexion.Open();
                    RESPUESTA = comando.ExecuteNonQuery();

                    return RESPUESTA;
                }
            }
        }

        public ParametroE ObtenerParametro(Int32 IdEmpresa, Int32 IdParametro, Int32 idUsuario)
        {
            ParametroE parametro = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    oComando.Parameters.Add("@IdParametro", SqlDbType.Int).Value = IdParametro;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            parametro = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return parametro;
        }

        public Int32 RecuperarMaxParametroPorIdEmpresa(Int32 idEmpresa)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarIdParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);

                    oConexion.Open();
                    resp = int.Parse(oComando.ExecuteScalar().ToString()); //EJECUTANDO Y ME DEVUELVE LA CLAVE GENERADA
                }
            }

            return resp;
        }

        public List<ParametroE> ListarParametroPorUsuario(Int32 IdEmpresa, Int32 idUsuario)
        {
            List<ParametroE> listaEntidad = new List<ParametroE>();
            ParametroE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParametroPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

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
