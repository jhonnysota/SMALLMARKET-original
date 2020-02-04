using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioAlmacenAD : DbConection
    {
        
        public UsuarioAlmacenE LlenarEntidad(IDataReader oReader)
        {
            UsuarioAlmacenE usuarioalmacen = new UsuarioAlmacenE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioalmacen.DesAlmacen = oReader["DesAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesAlmacen"]);

            return  usuarioalmacen;        
        }

        public UsuarioAlmacenE InsertarUsuarioAlmacen(UsuarioAlmacenE usuarioalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioalmacen.idPersona;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = usuarioalmacen.idAlmacen;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioalmacen.idEmpresa;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = usuarioalmacen.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return usuarioalmacen;
        }
        
        public UsuarioAlmacenE ActualizarUsuarioAlmacen(UsuarioAlmacenE usuarioalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioalmacen.idPersona;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = usuarioalmacen.idAlmacen;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuarioalmacen.idEmpresa;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = usuarioalmacen.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return usuarioalmacen;
        }        

        public int EliminarUsuarioAlmacen(Int32 idPersona, Int32 idAlmacen, Int32 idEmpresa)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<UsuarioAlmacenE> ListarUsuarioAlmacen(Int32 idPersona, Int32 idEmpresa)
        {
           List<UsuarioAlmacenE> listaEntidad = new List<UsuarioAlmacenE>();
           UsuarioAlmacenE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
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
        
        public UsuarioAlmacenE ObtenerUsuarioAlmacen(Int32 idPersona, Int32 idAlmacen, Int32 idEmpresa)
        {        
            UsuarioAlmacenE usuarioalmacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioalmacen = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return usuarioalmacen;
        }
    }
}