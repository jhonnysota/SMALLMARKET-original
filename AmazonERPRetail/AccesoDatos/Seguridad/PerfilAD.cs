using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class PerfilAD : DbConection
    {
        
        #region MÉTODOS PRIVADOS

        private Perfil LlenarEntidad(IDataReader oReader)
        {
            Perfil vPerfil = new Perfil();

            vPerfil.IdPerfil = Convert.ToInt32(oReader["IdPerfil"]);
            vPerfil.NombrePerfil = oReader["NombrePerfil"].ToString();

            if (!Convert.IsDBNull(oReader["FechaRegistro"]))
            {
                vPerfil.FechaRegistro = Convert.ToDateTime(oReader["FechaRegistro"]);
            }

            if (!Convert.IsDBNull(oReader["UsuarioRegistro"]))
            {
                vPerfil.UsuarioRegistro = Convert.ToString(oReader["UsuarioRegistro"]);
            }

            if (!Convert.IsDBNull(oReader["FechaActualizacion"]))
            {
                vPerfil.FechaActualizacion = Convert.ToDateTime(oReader["FechaActualizacion"]);
            }

            if (!Convert.IsDBNull(oReader["UsuarioActualizacion"]))
            {
                vPerfil.UsuarioActualizacion = Convert.ToString(oReader["UsuarioActualizacion"]);
            }

            return vPerfil;
        }

        #endregion

        #region MÉTODOS PUBLICOS

        public List<Perfil> ListarPerfil(String parametro) 
        {
            List<Perfil> vListaPerfil = new List<Perfil>();
            Perfil vPerfil = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPerfil", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@parametro", parametro);
                 
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read()) 
                        {
                            vPerfil = LlenarEntidad(oReader);
                            vListaPerfil.Add(vPerfil);
                        }
                    }
                }
            }

            return vListaPerfil;
        }

		public Perfil InsertarPerfil(Perfil perfil)
		{
		    perfil.FechaRegistro = DateTime.Now ;
		    perfil.FechaActualizacion = DateTime.Now;

			using (SqlConnection oConexion = ConexionSql())
			{
				using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPerfil",oConexion))
				{
					oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.AddWithValue("@NombrePerfil",perfil.NombrePerfil);
					oComando.Parameters.AddWithValue("@FechaRegistro",perfil.FechaRegistro);
					oComando.Parameters.AddWithValue("@UsuarioRegistro",perfil.UsuarioRegistro);
					oComando.Parameters.AddWithValue("@FechaActualizacion",perfil.FechaActualizacion);
					oComando.Parameters.AddWithValue("@UsuarioActualizacion",perfil.UsuarioActualizacion);
				
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
				}
			}

			return perfil;
		}

		public Perfil ActualizarPerfil(Perfil perfil)
		{
			using (SqlConnection oConexion = ConexionSql())
			{
				using(SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPerfil",oConexion))
				{
					oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPerfil", perfil.IdPerfil);
					oComando.Parameters.AddWithValue("@NombrePerfil",perfil.NombrePerfil);
					oComando.Parameters.AddWithValue("@FechaRegistro",perfil.FechaRegistro);
					oComando.Parameters.AddWithValue("@UsuarioRegistro",perfil.UsuarioRegistro);
					oComando.Parameters.AddWithValue("@FechaActualizacion",perfil.FechaActualizacion);
					oComando.Parameters.AddWithValue("@UsuarioActualizacion",perfil.UsuarioActualizacion);
					
                    oConexion.Open();
					oComando.ExecuteNonQuery();
				}
			}

			return perfil;
		}
				
		public Int32 EliminarPerfil(Int32 IdPerfil)
	    {
			Int32 resp = 0;
			using (SqlConnection oConexion = ConexionSql())
			{
				using (SqlCommand oComando = new SqlCommand("retail.usp_AnularPerfil", oConexion))
				{
				    oComando.CommandType = CommandType.StoredProcedure;
				    oComando.Parameters.AddWithValue("@IdPerfil", IdPerfil);
				    
                    oConexion.Open();
				    resp = oComando.ExecuteNonQuery();
				}
            }

            return resp;
        }

        #endregion

    }
}
