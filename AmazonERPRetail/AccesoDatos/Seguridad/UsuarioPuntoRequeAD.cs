using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioPuntoRequeAD : DbConection
    {

        public UsuarioPuntoRequeE LlenarEntidad(IDataReader oReader)
        {
            UsuarioPuntoRequeE usuariopuntoreque = new UsuarioPuntoRequeE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopuntoreque.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPuntoReq'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopuntoreque.idPuntoReq = oReader["idPuntoReq"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPuntoReq"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopuntoreque.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopuntoreque.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopuntoreque.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopuntoreque.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPuntoReq'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuariopuntoreque.desPuntoReq = oReader["desPuntoReq"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPuntoReq"]);

            return  usuariopuntoreque;        
        }

        public UsuarioPuntoRequeE InsertarUsuarioPuntoReque(UsuarioPuntoRequeE usuariopuntoreque)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioPuntoReque", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuariopuntoreque.idUsuario;
					oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = usuariopuntoreque.idPuntoReq;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuariopuntoreque.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuariopuntoreque;
        }
        
        public UsuarioPuntoRequeE ActualizarUsuarioPuntoReque(UsuarioPuntoRequeE usuariopuntoreque)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioPuntoReque", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuariopuntoreque.idUsuario;
					oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = usuariopuntoreque.idPuntoReq;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = usuariopuntoreque.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuariopuntoreque;
        }        

        public int EliminarUsuarioPuntoReque(Int32 idUsuario)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioPuntoReque", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioPuntoRequeE> ListarUsuarioPuntoReque(Int32 idUsuario)
        {
           List<UsuarioPuntoRequeE> listaEntidad = new List<UsuarioPuntoRequeE>();
           UsuarioPuntoRequeE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioPuntoReque", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public UsuarioPuntoRequeE ObtenerUsuarioPuntoReque(Int32 idUsuario, Int32 idPuntoReq)
        {        
            UsuarioPuntoRequeE usuariopuntoreque = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioPuntoReque", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					oComando.Parameters.Add("@idPuntoReq", SqlDbType.Int).Value = idPuntoReq;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuariopuntoreque = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return usuariopuntoreque;
        }

    }
}