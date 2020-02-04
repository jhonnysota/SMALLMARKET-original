using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class RolOpcionAD : DbConection
    {

        public RolOpcion LlenarEntidad(IDataReader oReader)
        {
            RolOpcion rolopcion = new RolOpcion();
            
			rolopcion.IdRol = Convert.ToInt32(oReader["IdRol"]);
			rolopcion.IdOpcion = Convert.ToInt32(oReader["IdOpcion"]);  			
			rolopcion.Acceso = Convert.ToBoolean(oReader["Acceso"]);  						

            return  rolopcion;
        }

        public RolOpcion InsertarRolOpcion(RolOpcion rolopcion)
        {
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRolOpcion", conexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", rolopcion.IdRol); 
			        oComando.Parameters.AddWithValue("@IdOpcion", rolopcion.IdOpcion); 
			        oComando.Parameters.AddWithValue("@Acceso", rolopcion.Acceso);

                    conexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return rolopcion;
        }
        
        public RolOpcion ActualizarRolOpcion(RolOpcion rolopcion)
        {
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRolOpcion", conexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", rolopcion.IdRol); 
			        oComando.Parameters.AddWithValue("@IdOpcion", rolopcion.IdOpcion); 
			        oComando.Parameters.AddWithValue("@Acceso", rolopcion.Acceso);

                    conexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return rolopcion;
        }

        public Int32 BorrarRolOpcion(Int32 IdRol)
        {
            Int32 resp = 0;
            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BorrarRolOpcion", conexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", IdRol);

                    conexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RolOpcion> ListarRolOpcion(Int32 IdRol)
        {
           List<RolOpcion> listaEntidad = new List<RolOpcion>();
           RolOpcion entidad = null;

            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRolOpcion", conexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", IdRol);

                    conexion.Open();

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

        public RolOpcion RecuperarRolOpcionPorCodigo(Int32 IdRol, Int32 IdOpcion, Int32 IdEmpresa)
        {
           RolOpcion rolopcion = null;

            using (SqlConnection conexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRolOpcion", conexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdRol", IdRol); 
			        oComando.Parameters.AddWithValue("@IdOpcion", IdOpcion); 
                    
                    conexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            rolopcion = LlenarEntidad(oReader);
                        }    
                    }
                }
            }

            return rolopcion;
        }

    }
}