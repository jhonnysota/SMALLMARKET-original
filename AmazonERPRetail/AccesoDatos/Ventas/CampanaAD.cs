using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CampanaAD : DbConection
    {

        public CampanaE LlenarEntidad(IDataReader oReader)
        {
            CampanaE campana = new CampanaE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.idCampana = oReader["idCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Inicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Inicio = oReader["Inicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Inicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Fin = oReader["Fin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Focus'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Focus = oReader["Focus"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Focus"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoPrecio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.EstadoPrecio = oReader["EstadoPrecio"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EstadoPrecio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoDirectoras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.EstadoDirectoras = oReader["EstadoDirectoras"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EstadoDirectoras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Titulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.Titulo = oReader["Titulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Titulo"]);

            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    campana.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MostrarPedWeb'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.MostrarPedWeb = oReader["MostrarPedWeb"] == DBNull.Value ? true : Convert.ToBoolean(oReader["MostrarPedWeb"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MostrarDevWeb'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.MostrarDevWeb = oReader["MostrarDevWeb"] == DBNull.Value ? true : Convert.ToBoolean(oReader["MostrarDevWeb"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsDiferido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.EsDiferido = oReader["EsDiferido"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EsDiferido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.idTipoCampana = oReader["idTipoCampana"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoCampana'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.EstadoCampana = oReader["Titulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoCampana"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoActivarArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.EstadoActivarArticulo = oReader["EstadoActivarArticulo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["EstadoActivarArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                campana.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);


            return campana;
        }

        public CampanaE InsertarCampana(CampanaE campana)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCampana", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = campana.idEmpresa;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = campana.Nombre;
                    oComando.Parameters.Add("@Inicio", SqlDbType.SmallDateTime).Value = campana.Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.SmallDateTime).Value = campana.Fin;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char,1).Value = campana.Estado;
                    oComando.Parameters.Add("@Focus", SqlDbType.Bit).Value = campana.Focus;
                    oComando.Parameters.Add("@EstadoPrecio", SqlDbType.Bit).Value = campana.EstadoPrecio;
                    oComando.Parameters.Add("@EstadoDirectoras", SqlDbType.Bit).Value = campana.EstadoDirectoras;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 2).Value = campana.Tipo;
                    oComando.Parameters.Add("@Titulo", SqlDbType.VarChar, 150).Value = campana.Titulo;
                    oComando.Parameters.Add("@MostrarPedWeb", SqlDbType.Bit).Value = campana.MostrarPedWeb;
                    oComando.Parameters.Add("@MostrarDevWeb", SqlDbType.Bit).Value = campana.MostrarDevWeb;
                    oComando.Parameters.Add("@EsDiferido", SqlDbType.Bit).Value = campana.EsDiferido;
                    oComando.Parameters.Add("@idTipoCampana", SqlDbType.Int).Value = campana.idTipoCampana;
                    oComando.Parameters.Add("@EstadoCampana", SqlDbType.VarChar, 1).Value = campana.EstadoCampana;
                    oComando.Parameters.Add("@EstadoActivarArticulo", SqlDbType.Bit).Value = campana.EstadoActivarArticulo;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = campana.UsuarioRegistro;


                    oConexion.Open();
                    campana.idCampana = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return campana;
        }

        public CampanaE ActualizarCampana(CampanaE campana)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCampana", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = campana.idCampana;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = campana.idEmpresa;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = campana.Nombre;
                    oComando.Parameters.Add("@Inicio", SqlDbType.SmallDateTime).Value = campana.Inicio;
                    oComando.Parameters.Add("@Fin", SqlDbType.SmallDateTime).Value = campana.Fin;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = campana.Estado;
                    oComando.Parameters.Add("@Focus", SqlDbType.Bit).Value = campana.Focus;
                    oComando.Parameters.Add("@EstadoPrecio", SqlDbType.Bit).Value = campana.EstadoPrecio;
                    oComando.Parameters.Add("@EstadoDirectoras", SqlDbType.Bit).Value = campana.EstadoDirectoras;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 2).Value = campana.Tipo;
                    oComando.Parameters.Add("@Titulo", SqlDbType.VarChar, 150).Value = campana.Titulo;
                    oComando.Parameters.Add("@MostrarPedWeb", SqlDbType.Bit).Value = campana.MostrarPedWeb;
                    oComando.Parameters.Add("@MostrarDevWeb", SqlDbType.Bit).Value = campana.MostrarDevWeb;
                    oComando.Parameters.Add("@EsDiferido", SqlDbType.Bit).Value = campana.EsDiferido;
                    oComando.Parameters.Add("@idTipoCampana", SqlDbType.Int).Value = campana.idTipoCampana;
                    oComando.Parameters.Add("@EstadoCampana", SqlDbType.VarChar, 1).Value = campana.EstadoCampana;
                    oComando.Parameters.Add("@EstadoActivarArticulo", SqlDbType.Bit).Value = campana.EstadoActivarArticulo;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = campana.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return campana;
        }

        public Int32 EliminarCampana(Int32 idCampana, Int32 idEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCampana", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = idCampana;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CampanaE> ListarCampana(Int32 idEmpresa)
        {
            List<CampanaE> listaEntidad = new List<CampanaE>();
            CampanaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCampana", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

                oConexion.Close();
            }

            return listaEntidad;
        }

        public CampanaE ObtenerCampana(Int32 idCampana, Int32 idEmpresa)
        {
            CampanaE campana = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCampana", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCampana", SqlDbType.Int).Value = idCampana;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                  
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            campana = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return campana;
        }
    }
}
