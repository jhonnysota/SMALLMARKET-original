using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class UsuarioPreferenciasAD : DbConection
    {
        
        public UsuarioPreferenciasE LlenarEntidad(IDataReader oReader)
        {
            UsuarioPreferenciasE usuariopreferencias = new UsuarioPreferenciasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPreferencias'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.idPreferencias = oReader["idPreferencias"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPreferencias"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreFormulario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.NombreFormulario = oReader["NombreFormulario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreFormulario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Campo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.Campo = oReader["Campo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Campo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Valor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.Valor = oReader["Valor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Valor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuariopreferencias.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			

            return  usuariopreferencias;        
        }

        public UsuarioPreferenciasE InsertarUsuarioPreferencias(UsuarioPreferenciasE usuariopreferencias)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioPreferencias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuariopreferencias.idEmpresa;
					oComando.Parameters.Add("@NombreFormulario", SqlDbType.VarChar, 160).Value = usuariopreferencias.NombreFormulario;
					oComando.Parameters.Add("@Campo", SqlDbType.VarChar, 80).Value = usuariopreferencias.Campo;
					oComando.Parameters.Add("@Valor", SqlDbType.VarChar, 80).Value = usuariopreferencias.Valor;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuariopreferencias.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = usuariopreferencias.FechaRegistro;

                    oConexion.Open();
                    usuariopreferencias.idPreferencias = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return usuariopreferencias;
        }
        
        public UsuarioPreferenciasE ActualizarUsuarioPreferencias(UsuarioPreferenciasE usuariopreferencias)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioPreferencias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = usuariopreferencias.idEmpresa;
					oComando.Parameters.Add("@idPreferencias", SqlDbType.Int).Value = usuariopreferencias.idPreferencias;
					oComando.Parameters.Add("@NombreFormulario", SqlDbType.VarChar, 160).Value = usuariopreferencias.NombreFormulario;
					oComando.Parameters.Add("@Campo", SqlDbType.VarChar, 80).Value = usuariopreferencias.Campo;
					oComando.Parameters.Add("@Valor", SqlDbType.VarChar, 80).Value = usuariopreferencias.Valor;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuariopreferencias.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = usuariopreferencias.FechaRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuariopreferencias;
        }        

        public Int32 EliminarUsuarioPreferencias(Int32 idEmpresa, Int32 idPreferencias)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioPreferencias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPreferencias", SqlDbType.Int).Value = idPreferencias;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioPreferenciasE> ListarUsuarioPreferencias(Int32 idEmpresa, String NombreFormulario)
        {
           List<UsuarioPreferenciasE> listaEntidad = new List<UsuarioPreferenciasE>();
           UsuarioPreferenciasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioPreferencias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@NombreFormulario", SqlDbType.VarChar, 160).Value = NombreFormulario;
                    
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
        
        public UsuarioPreferenciasE ObtenerUsuarioPreferencias(Int32 idEmpresa, Int32 idPreferencias)
        {        
            UsuarioPreferenciasE usuariopreferencias = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioPreferencias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPreferencias", SqlDbType.Int).Value = idPreferencias;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuariopreferencias = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuariopreferencias;
        }

    }
}