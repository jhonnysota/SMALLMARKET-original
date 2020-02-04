using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class OpcionAD : DbConection
    {

        public Opcion LlenarEntidad(IDataReader oReader)
        {
            Opcion opcion = new Opcion();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdOpcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.IdOpcion = oReader["IdOpcion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdOpcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ubicacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Ubicacion = oReader["Ubicacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ubicacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAplicacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.TipoAplicacion = oReader["TipoAplicacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoAplicacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GrupoOpcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.GrupoOpcion = oReader["GrupoOpcion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["GrupoOpcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Orden = oReader["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioActualizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.UsuarioActualizacion = oReader["UsuarioActualizacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioActualizacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaActualizacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.FechaActualizacion = oReader["FechaActualizacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaActualizacion"]);
            
            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombreGrupo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.nombreGrupo = oReader["nombreGrupo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombreGrupo"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombreTipoAplicacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.nombreTipoAplicacion = oReader["nombreTipoAplicacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombreTipoAplicacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Total = oReader["Total"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Agregar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Agregar = oReader["Agregar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Agregar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Modificar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Modificar = oReader["Modificar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Modificar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Consultar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Consultar = oReader["Consultar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Consultar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Eliminar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opcion.Eliminar = oReader["Eliminar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Eliminar"]);

            return opcion;
        }

        public Opcion InsertarOpcion(Opcion opcion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOpcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = opcion.Nombre;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 100).Value = opcion.Descripcion;
                    oComando.Parameters.Add("@Ubicacion", SqlDbType.NVarChar, 100).Value = opcion.Ubicacion;
                    oComando.Parameters.Add("@TipoAplicacion", SqlDbType.Int).Value = opcion.TipoAplicacion;
                    oComando.Parameters.Add("@GrupoOpcion", SqlDbType.Int).Value = opcion.GrupoOpcion;
                    oComando.Parameters.Add("@Orden", SqlDbType.Int).Value = opcion.Orden;
                    oComando.Parameters.Add("@Observacion", SqlDbType.NVarChar, 2500).Value = opcion.Observacion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = opcion.UsuarioRegistro;
                    
                    oConexion.Open();
                    opcion.IdOpcion = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return opcion;
        }

        public Opcion ActualizarOpcion(Opcion opcion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOpcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = opcion.IdOpcion;
                    oComando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = opcion.Nombre;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 100).Value = opcion.Descripcion;
                    oComando.Parameters.Add("@Ubicacion", SqlDbType.NVarChar, 100).Value = opcion.Ubicacion;
                    oComando.Parameters.Add("@TipoAplicacion", SqlDbType.Int).Value = opcion.TipoAplicacion;
                    oComando.Parameters.Add("@GrupoOpcion", SqlDbType.Int).Value = opcion.GrupoOpcion;
                    oComando.Parameters.Add("@Orden", SqlDbType.Int).Value = opcion.Orden;
                    oComando.Parameters.Add("@Observacion", SqlDbType.NVarChar, 2500).Value = opcion.Observacion;
                    oComando.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar, 20).Value = opcion.UsuarioActualizacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return opcion;
        }

        public Int32 BorrarOpcion(Int32 IdOpcion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarOpcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = IdOpcion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<Opcion> ListarOpcion(String value)
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@filtro", value);
                    
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

        public List<Opcion> ListarOpcionRol(Int32 idRol)
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpcionRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;

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

        public Opcion RecuperarOpcionPorCodigo(Int32 IdOpcion)
        {
            Opcion opcion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOpcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdOpcion", IdOpcion);
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            opcion = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return opcion;
        }

        public List<Opcion> RecuperarOpcionPorUsuarioEmpresa(Int32 idEmpresa, Int32 idPersona)
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpcionPorUsuarioEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@IdUsuario", idPersona);
                    
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

        public List<Opcion> RecuperarOpcionTotal()
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpcionTotal", oConexion))
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

        public List<Opcion> ListarOpcionesParaRol(String Filtro)
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpcionesParaRol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Filtro", SqlDbType.VarChar, 100).Value = Filtro;

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

        public List<Opcion> ListarOpcionesPadre(Int32 idEmpresa, Int32 idUsuario)
        {
            List<Opcion> listaEntidad = new List<Opcion>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpcionesPadre", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

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
