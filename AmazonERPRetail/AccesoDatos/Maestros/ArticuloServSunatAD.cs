using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ArticuloServSunatAD : DbConection
    {

        public ArticuloServSunatE LlenarEntidad(IDataReader oReader)
        {
            ArticuloServSunatE articuloservsunat = new ArticuloServSunatE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.CodigoSunat = oReader["CodigoSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodigoSunat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloservsunat.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  articuloservsunat;        
        }

        public ArticuloServSunatE InsertarArticuloServSunat(ArticuloServSunatE articuloservsunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloServSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloservsunat.idEmpresa;
					oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 10).Value = articuloservsunat.CodigoSunat;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = articuloservsunat.Descripcion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = articuloservsunat.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloservsunat;
        }
        
        public ArticuloServSunatE ActualizarArticuloServSunat(ArticuloServSunatE articuloservsunat)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloServSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloservsunat.idEmpresa;
					oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 10).Value = articuloservsunat.CodigoSunat;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = articuloservsunat.Descripcion;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = articuloservsunat.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloservsunat;
        }        

        public int EliminarArticuloServSunat(Int32 idEmpresa, String CodigoSunat)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloServSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 10).Value = CodigoSunat;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloServSunatE> ListarArticuloServSunat(Int32 idEmpresa)
        {
            List<ArticuloServSunatE> listaEntidad = new List<ArticuloServSunatE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloServSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public ArticuloServSunatE ObtenerArticuloServSunat(Int32 idEmpresa, String CodigoSunat)
        {        
            ArticuloServSunatE articuloservsunat = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloServSunat", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 10).Value = CodigoSunat;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloservsunat = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloservsunat;
        }

    }
}