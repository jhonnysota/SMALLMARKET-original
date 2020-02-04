using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloKitAD : DbConection
    {

        public ArticuloKitE LlenarEntidad(IDataReader oReader)
        {
            ArticuloKitE articulokit = new ArticuloKitE();
            

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulokit.CodArticulo = oReader["CodArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articulokit.NombreArticulo = oReader["NomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomArticulo"]);

            return  articulokit;        
        }

        public ArticuloKitE InsertarArticuloKit(ArticuloKitE articulokit)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulokit.idEmpresa;
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulokit;
        }
        
        public ArticuloKitE ActualizarArticuloKit(ArticuloKitE articulokit)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articulokit.idEmpresa;
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articulokit;
        }        

        public int EliminarArticuloKit(Int32 idEmpresa, Int32 idArticulo, Int32 idArticuloComponente)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloKitE> ListarArticuloKit(Int32 idArticulo)
        {
            List<ArticuloKitE> listaEntidad = new List<ArticuloKitE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

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
        
        public ArticuloKitE ObtenerArticuloKit(Int32 idEmpresa, Int32 idArticulo, Int32 idArticuloComponente)
        {        
            ArticuloKitE articulokit = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloKit", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articulokit = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articulokit;
        }

    }
}