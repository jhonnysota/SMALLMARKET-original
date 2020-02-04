using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioAccionAD : DbConection
    {

        public UsuarioAccionE LlenarEntidad(IDataReader oReader)
        {
            UsuarioAccionE usuarioaccion = new UsuarioAccionE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.idAccion = oReader["idAccion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOpcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.idOpcion = oReader["idOpcion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOpcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreOpcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.NombreOpcion = oReader["NombreOpcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreOpcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreGrupo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.NombreGrupo = oReader["NombreGrupo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreGrupo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreUsuario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.NombreUsuario = oReader["NombreUsuario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreUsuario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.NombreEmpresa = oReader["NombreEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.Orden = oReader["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GrupoOpcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.GrupoOpcion = oReader["GrupoOpcion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["GrupoOpcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ControlTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.ControlTotal = oReader["ControlTotal"] == DBNull.Value ? true : Convert.ToBoolean(oReader["ControlTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CR'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.CR = oReader["CR"] == DBNull.Value ? false : Convert.ToBoolean(oReader["CR"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RE'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.RE = oReader["RE"] == DBNull.Value ? false : Convert.ToBoolean(oReader["RE"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UP'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.UP = oReader["UP"] == DBNull.Value ? false : Convert.ToBoolean(oReader["UP"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DE'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.DE = oReader["DE"] == DBNull.Value ? false : Convert.ToBoolean(oReader["DE"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TomarOpcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.TomarOpcion = oReader["TomarOpcion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["TomarOpcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ItemsAccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioaccion.ItemsAccion = oReader["ItemsAccion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ItemsAccion"]);

            return  usuarioaccion;        
        }

        public UsuarioAccionE InsertarUsuarioAccion(UsuarioAccionE usuarioaccion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioAccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioaccion.idPersona; 
			        oComando.Parameters.Add("@idAccion", SqlDbType.Int).Value = usuarioaccion.idAccion; 
			        oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioaccion.idEmpresa;
                    oComando.Parameters.Add("@idOpcion", SqlDbType.Int).Value = usuarioaccion.idOpcion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = usuarioaccion.UsuarioRegistro; 

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioaccion;
        }

        public Int32 BorrarUsuarioAccion(Int32 idPersona, Int32 idEmpresa, Int32 idOpcion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarUsuarioAccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOpcion", SqlDbType.Int).Value = idOpcion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioAccionE> ListarUsuarioAccion(Int32 idPersona, Int32 idEmpresa)
        {
            List<UsuarioAccionE> listaEntidad = new List<UsuarioAccionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioAccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public List<UsuarioAccionE> ObtenerUsuarioAccion(Int32 idPersona, Int32 idEmpresa, Int32 idOpcion)
        {
            List<UsuarioAccionE> listaEntidad = new List<UsuarioAccionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioAccion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOpcion", SqlDbType.Int).Value = idOpcion;

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