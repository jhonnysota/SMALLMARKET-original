using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioSeriesAD : DbConection
    {

        public UsuarioSeriesE LlenarEntidad(IDataReader oReader)
        {
            UsuarioSeriesE usuarioseries = new UsuarioSeriesE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioseries.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioseries.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            return  usuarioseries;        
        }

        public UsuarioSeriesE InsertarUsuarioSeries(UsuarioSeriesE usuarioseries)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioSeries", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioseries.idEmpresa;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioseries.idUsuario;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = usuarioseries.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = usuarioseries.numSerie;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuarioseries.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioseries;
        }
        
        public UsuarioSeriesE ActualizarUsuarioSeries(UsuarioSeriesE usuarioseries)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioSeries", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioseries.idEmpresa;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioseries.idUsuario;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = usuarioseries.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = usuarioseries.numSerie;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = usuarioseries.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioseries;
        }        

        public int EliminarUsuarioSeries(Int32 idEmpresa, Int32 idUsuario)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioSeries", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioSeriesE> ListarUsuarioSeries(Int32 idEmpresa, Int32 idUsuario)
        {
            List<UsuarioSeriesE> listaEntidad = new List<UsuarioSeriesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioSeries", oConexion))
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
        
        public UsuarioSeriesE ObtenerUsuarioSeries(Int32 idEmpresa, Int32 idUsuario, String idDocumento, String numSerie)
        {        
            UsuarioSeriesE usuarioseries = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioSeries", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioseries = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuarioseries;
        }

        public List<UsuarioSeriesE> ListarUsuarioSeriesPtoVta(Int32 idEmpresa, Int32 idUsuario)
        {
            List<UsuarioSeriesE> listaEntidad = new List<UsuarioSeriesE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioSeriesPtoVta", oConexion))
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