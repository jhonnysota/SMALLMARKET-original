using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class LocalAD : DbConection
    {

        public LocalE LlenarEntidad(IDataReader oReader)
        {
            LocalE local = new LocalE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.IdEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.IdLocal = oReader["IdLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsPrincipal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.EsPrincipal = oReader["EsPrincipal"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EsPrincipal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.EsAlmacen = oReader["EsAlmacen"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EsAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsTienda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.EsTienda = oReader["EsTienda"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EsTienda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.NombreCorto = oReader["NombreCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefonos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.Telefonos = oReader["Telefonos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefonos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='email'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.email = oReader["email"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["email"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbigeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.idUbigeo = oReader["idUbigeo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idUbigeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Siglas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.Siglas = oReader["Siglas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Siglas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                local.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return local;
        }

        public LocalE InsertarLocal(LocalE local)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLocal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = local.IdEmpresa;
                    oComando.Parameters.Add("@IdLocal", SqlDbType.Int).Value = local.IdLocal;
                    oComando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = local.Nombre;
                    oComando.Parameters.Add("@EsPrincipal", SqlDbType.Bit).Value = local.EsPrincipal;
                    oComando.Parameters.Add("@EsAlmacen", SqlDbType.Bit).Value = local.EsAlmacen;
                    oComando.Parameters.Add("@EsTienda", SqlDbType.Bit).Value = local.EsTienda;
                    oComando.Parameters.Add("@NombreCorto", SqlDbType.NVarChar, 100).Value = local.NombreCorto;
                    oComando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 100).Value = local.Direccion;
                    oComando.Parameters.Add("@Telefonos", SqlDbType.VarChar, 50).Value = local.Telefonos;
                    oComando.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = local.email;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = local.idCondicion;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = local.idUbigeo;
                    oComando.Parameters.Add("@Siglas", SqlDbType.VarChar, 3).Value = local.Siglas;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = local.Estado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = local.UsuarioRegistro;

                    oConexion.Open();
                    local.IdLocal = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return local;
        }

        public LocalE ActualizarLocal(LocalE local)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLocal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = local.IdEmpresa;
                    oComando.Parameters.Add("@IdLocal", SqlDbType.Int).Value = local.IdLocal;
                    oComando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = local.Nombre;
                    oComando.Parameters.Add("@EsPrincipal", SqlDbType.Bit).Value = local.EsPrincipal;
                    oComando.Parameters.Add("@EsAlmacen", SqlDbType.Bit).Value = local.EsAlmacen;
                    oComando.Parameters.Add("@EsTienda", SqlDbType.Bit).Value = local.EsTienda;
                    oComando.Parameters.Add("@NombreCorto", SqlDbType.NVarChar, 100).Value = local.NombreCorto;
                    oComando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 100).Value = local.Direccion;
                    oComando.Parameters.Add("@Telefonos", SqlDbType.VarChar, 50).Value = local.Telefonos;
                    oComando.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = local.email;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = local.idCondicion;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = local.idUbigeo;
                    oComando.Parameters.Add("@Siglas", SqlDbType.VarChar, 3).Value = local.Siglas;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = local.Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = local.UsuarioModificacion;
                    
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
            return local;
        }

        public LocalE RecuperarLocalPorCodigo(Int32 IdLocal, Int32 IdEmpresa)
        {
            LocalE local = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLocal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdLocal", SqlDbType.Int).Value = IdLocal;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            local = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return local;
        }

        public List<LocalE> ListarLocal(String value, Boolean activo, Boolean inactivo, Int32 idEmpresa)
        {
            List<LocalE> listaEntidad = new List<LocalE>();
            LocalE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLocal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@filtro", SqlDbType.VarChar, 100).Value = value;
                    oComando.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                    oComando.Parameters.Add("@inactivo", SqlDbType.Bit).Value = inactivo;
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

        public List<LocalE> ListarLocalTodos(String parametro, Boolean activo, Boolean inactivo)
        {
            List<LocalE> listaEntidad = new List<LocalE>();
            LocalE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLocalTodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@filtro", parametro);
                    oComando.Parameters.AddWithValue("@activo", activo);
                    oComando.Parameters.AddWithValue("@inactivo", inactivo);
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            entidad.NombreEmpresa = oReader["NombreComercial"].ToString();
                            entidad.IdEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
                            entidad.IdLocal = Convert.ToInt32(oReader["IdLocal"]);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public Int32 RecuperarMaxIdLocal(Int32 IdEmpresa)
        {
            Int32 MaxID = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerMaxIdLocal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;

                    oConexion.Open();
                    MaxID = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return MaxID;
        }

        public List<LocalE> ListarLocalPorEmpresa(Int32 idEmpresa, Boolean incluirLogico)
        {
            List<LocalE> listaEntidad = new List<LocalE>();
            LocalE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLocalPorEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@incluirLogico", incluirLogico);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            entidad.IdLocal = Convert.ToInt32(oReader["idLocal"]);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<LocalE> ListarLocalPorUsuario(Int32 Idpersona)
        {
            List<LocalE> listaEntidad = new List<LocalE>();
            LocalE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLocalPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", Idpersona);

                    oConexion.Open();

                    using (SqlDataReader reader = oComando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                            entidad.IdEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            entidad.IdLocal = Convert.ToInt32(reader["idLocal"]);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        /**********************************************************************************************************************************************************************************************/

        public Int32 BorrarLocal(Int32 IdLocal, Int32 IdEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarLocal", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdLocal", SqlDbType.Int).Value = IdLocal;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }        

    }
}