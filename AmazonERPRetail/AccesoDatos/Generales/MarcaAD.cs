using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class MarcaAD : DbConection
    {

        public Marca LlenarEntidadMarca(IDataReader oReader)
        {
            Marca entidad = new Marca();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMarca'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idMarca = oReader["idMarca"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMarca"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idSistema = oReader["idSistema"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.nombre = oReader["nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombreCorto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.nombreCorto = oReader["nombreCorto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombreCorto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            return entidad;
        }

        public Marca InsertarMarca(Marca marca)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarMarca", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = marca.idSistema;
                    oComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = marca.nombre;
                    oComando.Parameters.Add("@nombreCorto", SqlDbType.VarChar, 50).Value = marca.nombreCorto;
                    //Auditoria
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = marca.UsuarioRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = marca.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return marca;        
        }
        
        public Marca ActualizarMarca(Marca marca)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarMarca", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMarca", SqlDbType.Int).Value = marca.idMarca;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = marca.idSistema;
                    oComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = marca.nombre;
                    oComando.Parameters.Add("@nombreCorto", SqlDbType.VarChar, 50).Value = marca.nombreCorto;
                    
                    //Auditoria
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = marca.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return marca;
        }        

        public void BorrarMarca(int idMarca, int codSistema)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarMarca", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idMarca", SqlDbType.Int).Value = idMarca;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = codSistema;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public List<Marca> ListarMarca(int codSistema)
        {
            List<Marca> listaEntidad = new List<Marca>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_ListarMarcas", oConexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@idSistema", SqlDbType.Int).Value = codSistema;

                    oConexion.Open();

                    using (SqlDataReader oReader = comando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidadMarca(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<Marca> ListarMarcaBusqueda()
        {
            List<Marca> listaEntidad = new List<Marca>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand comando = new SqlCommand("retail.usp_ListarMarcasBusqueda", oConexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();

                    using (SqlDataReader oReader = comando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidadMarca(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<Marca> BuscarMarcaPorDescripcion(int codSistema, string nombre)
        {
            List<Marca> listaEntidad = new List<Marca>();            

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarMarcaPorDescripcion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = codSistema;
                    oComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Marca marcas = new Marca();
                            marcas.idMarca = Convert.ToInt32(oReader["idMarca"]);
                            marcas.idSistema = Convert.ToInt32(oReader["idSistema"]);
                            marcas.nombre = Convert.ToString(oReader["nombre"]);

                            listaEntidad.Add(marcas);
                        }
                    }
                }
            }

            return listaEntidad;        
        }

        public Int32 ObtenerIdmarcas(String nombre)
        {
            Marca marcas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerIdmarcas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            marcas = LlenarEntidadMarca(oReader);
                        }
                    }
                }
            }

            return Convert.ToInt32(marcas.idMarca);
        }

    }
}