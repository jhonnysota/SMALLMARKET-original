using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
   public class UsuarioEmpresaLocalPerfilAD : DbConection
    {
        
        #region MÉTODOS PRIVADOS

        private UsuarioEmpresaLocalPerfil LlenarEntidad(IDataReader oReader)
        {
            UsuarioEmpresaLocalPerfil vUsuarioEmpresaLocalPerfil = new UsuarioEmpresaLocalPerfil();

            if (!Convert.IsDBNull(oReader["IdPersona"])) vUsuarioEmpresaLocalPerfil.IdPersona = Int32.Parse(oReader["IdPersona"].ToString());
            if (!Convert.IsDBNull(oReader["IdEmpresa"])) vUsuarioEmpresaLocalPerfil.IdEmpresa = Int32.Parse(oReader["IdEmpresa"].ToString());
            if (!Convert.IsDBNull(oReader["IdLocal"])) vUsuarioEmpresaLocalPerfil.IdLocal = Int32.Parse(oReader["IdLocal"].ToString());
            if (!Convert.IsDBNull(oReader["IdPerfil"])) vUsuarioEmpresaLocalPerfil.IdPerfil = Int32.Parse(oReader["IdPerfil"].ToString());

            return vUsuarioEmpresaLocalPerfil;
        }

        #endregion       

        #region MÉTODOS PÚBLICOS

        public List<UsuarioEmpresaLocalPerfil> ListaUsuarioEmpresaLocalPerfilPorUsuario(Int32 idPersona, Int32 idEmpresa, Int32 idLocal) 
        {
            List<UsuarioEmpresaLocalPerfil> vLista = new List<UsuarioEmpresaLocalPerfil>();
            UsuarioEmpresaLocalPerfil entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UsuarioEmpresaLocalPerfil_RecuperarPorUsuario",oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", idPersona);
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@IdLocal", idLocal);
            
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read()) 
                        {
                            entidad = LlenarEntidad(oReader);
                            vLista.Add(entidad);
                        }
                    }
                }
            }

            return vLista;
        }

        public UsuarioEmpresaLocalPerfil InsertarUsuarioEmpresaLocalPerfil(UsuarioEmpresaLocalPerfil vUsuarioEmpresaLocalPerfil) 
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UsuarioEmpresaLocalPerfil_Insertar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", vUsuarioEmpresaLocalPerfil.IdPersona);
                    oComando.Parameters.AddWithValue("@IdEmpresa", vUsuarioEmpresaLocalPerfil.IdEmpresa);
                    oComando.Parameters.AddWithValue("@IdLocal", vUsuarioEmpresaLocalPerfil.IdLocal);
                    oComando.Parameters.AddWithValue("@IdPerfil", vUsuarioEmpresaLocalPerfil.IdPerfil);
            
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return vUsuarioEmpresaLocalPerfil;
        }

        public Int32 BorrarUsuarioEmpresaLocalPerfil(Int32 idPersona, Int32 idEmpresa) 
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UsuarioEmpresaLocalPerfil_Eliminar",oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", idPersona);
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
            
                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public UsuarioEmpresaLocalPerfil RecuperarUsuarioEmpresaLocalPerfil(Int32 idEmpresa, Int32 idLocal, Int32 idPerfil) 
        {
            UsuarioEmpresaLocalPerfil vUsuarioEmpresaLocalPerfil = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_UsuarioEmpresaLocalPerfil_RecuperarPersona",oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@IdLocal", idLocal);
                    oComando.Parameters.AddWithValue("@IdPerfil", idPerfil);
            
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read()) 
                        {
                            vUsuarioEmpresaLocalPerfil = LlenarEntidad(oReader);
                            vUsuarioEmpresaLocalPerfil.NombreCompletoPersona = oReader["NombreCompletoPersona"].ToString();
                        }
                    }
                }
            }

            return vUsuarioEmpresaLocalPerfil;
        }

        public List<UsuarioEmpresaLocalPerfil> ListaUsuarioEmpresaLocalPerfilPorIdPersona(Int32 idPersona)
        {
            List<UsuarioEmpresaLocalPerfil> vLista = new List<UsuarioEmpresaLocalPerfil>();
            UsuarioEmpresaLocalPerfil entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListaUsuarioEmpresaLocalPerfilPorIdPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", idPersona);
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            vLista.Add(entidad);
                        }
                    }
                }
            }

            return vLista;
        }

        public Int32 BorrarUsuarioEmpresaLocalPerfilPorIdPersona(Int32 idPersona )
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarUsuarioEmpresaLocalPerfilPorIdPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", idPersona); 

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioEmpresaLocalPerfil> ListarUsuarioEmpresaLocalPerfil(Int32 IdEmpresa, Int32 IdLocal)
        {
            List<UsuarioEmpresaLocalPerfil> vLista = new List<UsuarioEmpresaLocalPerfil>();
            UsuarioEmpresaLocalPerfil entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioEmpresaLocalPerfil", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    oComando.Parameters.AddWithValue("@IdLocal", IdLocal);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
							entidad.NombreCompletoPersona = oReader["NombreCompletoPersona"].ToString();
							entidad.NombrePerfil = oReader["NombrePerfil"].ToString();
                            vLista.Add(entidad);
                        }
                    }
                }
            }

            return vLista;
        }

        public List<UsuarioEmpresaLocalPerfil> Listar_UsuarioEmpresaLocalPerfil(Int32 IdEmpresa, Int32 IdLocal, Int32 IdPerfil, String Parametro, bool ValidaPerfil, bool Estado)
        {
            List<UsuarioEmpresaLocalPerfil> vLista = new List<UsuarioEmpresaLocalPerfil>();
            UsuarioEmpresaLocalPerfil entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BusquedaUsuarioEmpresaLocalPerfil", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    oComando.Parameters.AddWithValue("@IdLocal", IdLocal);
                    oComando.Parameters.AddWithValue("@IdPerfil", IdPerfil);
                    oComando.Parameters.AddWithValue("@Parametro", Parametro);
                    oComando.Parameters.AddWithValue("@ValidaPerfil", ValidaPerfil);
                    oComando.Parameters.AddWithValue("@Estado", Estado);
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            entidad.NombreCompletoPersona = oReader["NombreCompletoPersona"].ToString();
                            entidad.NombrePerfil = oReader["NombrePerfil"].ToString();
                            entidad.Estado = Convert.ToBoolean( oReader["Estado"].ToString());
                            entidad.MontoPar = Convert.ToDecimal(oReader["MontoPar"].ToString());
                            entidad.MontoPorcentaje = Convert.ToDecimal(oReader["MontoPorcentaje"].ToString());
                            vLista.Add(entidad);
                        }
                    }
                }
            }

            return vLista;
        }

        #endregion
    }
}
