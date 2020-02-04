using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class TasasDetraccionesAD : DbConection
    {

        public TasasDetraccionesE LlenarEntidad(IDataReader oReader)
        {
            TasasDetraccionesE tasasdetracciones = new TasasDetraccionesE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.idTipoDetraccion = oReader["idTipoDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTipoDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseAfecta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.BaseAfecta = oReader["BaseAfecta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseAfecta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Excluido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.Excluido = oReader["Excluido"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Excluido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.idTipoOperacion = oReader["idTipoOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTipoOperacion"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetracciones.NombreTemp = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTipoDetraccion"]) + "-" + Convert.ToString(oReader["Nombre"]);

            return tasasdetracciones;
        }

        public TasasDetraccionesE InsertarTasasDetracciones(TasasDetraccionesE tasasdetracciones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTasasDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = tasasdetracciones.idTipoDetraccion;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = tasasdetracciones.Nombre;
                    oComando.Parameters.Add("@BaseAfecta", SqlDbType.Decimal).Value = tasasdetracciones.BaseAfecta;
                    oComando.Parameters.Add("@Excluido", SqlDbType.Bit).Value = tasasdetracciones.Excluido;
                    oComando.Parameters.Add("@idTipoOperacion", SqlDbType.VarChar, 10).Value = tasasdetracciones.idTipoOperacion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tasasdetracciones.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tasasdetracciones;
        }
        
        public TasasDetraccionesE ActualizarTasasDetracciones(TasasDetraccionesE tasasdetracciones)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTasasDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = tasasdetracciones.idTipoDetraccion;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = tasasdetracciones.Nombre;
                    oComando.Parameters.Add("@BaseAfecta", SqlDbType.Decimal).Value = tasasdetracciones.BaseAfecta;
                    oComando.Parameters.Add("@Excluido", SqlDbType.Bit).Value = tasasdetracciones.Excluido;
                    oComando.Parameters.Add("@idTipoOperacion", SqlDbType.VarChar, 10).Value = tasasdetracciones.idTipoOperacion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tasasdetracciones.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tasasdetracciones;
        }

        public Int32 EliminarTasasDetracciones(String idTipoDetraccion)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTasasDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = idTipoDetraccion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TasasDetraccionesE> ListarTasasDetracciones()
        {
            List<TasasDetraccionesE> listaEntidad = new List<TasasDetraccionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTasasDetracciones", oConexion))
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

        public TasasDetraccionesE ObtenerTasasDetracciones(String idTipoDetraccion)
        {
            TasasDetraccionesE tasasdetracciones = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTasasDetracciones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = idTipoDetraccion;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tasasdetracciones = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tasasdetracciones;
        }

        public List<TasasDetraccionesE> ListarDetraccionesCabActivas()
        {
            List<TasasDetraccionesE> listaEntidad = new List<TasasDetraccionesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDetraccionesCabActivas", oConexion))
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