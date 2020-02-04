using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class ArticuloPrecioAD : DbConection
    {

        public ArticuloPrecioE LlenarEntidad(IDataReader oReader)
        {
            ArticuloPrecioE articuloprecio = new ArticuloPrecioE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Precio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.Precio = oReader["Precio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Precio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				articuloprecio.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloprecio.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloprecio.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAbreviatura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                articuloprecio.desAbreviatura = oReader["desAbreviatura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAbreviatura"]);            

            return  articuloprecio;        
        }

        public ArticuloPrecioE InsertarArticuloPrecio(ArticuloPrecioE articuloprecio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarArticuloPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloprecio.idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articuloprecio.idArticulo;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = articuloprecio.idMoneda;
					oComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = articuloprecio.Precio;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = articuloprecio.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloprecio;
        }
        
        public ArticuloPrecioE ActualizarArticuloPrecio(ArticuloPrecioE articuloprecio)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarArticuloPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = articuloprecio.idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = articuloprecio.idArticulo;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = articuloprecio.idMoneda;
					oComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = articuloprecio.Precio;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = articuloprecio.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return articuloprecio;
        }        

        public int EliminarArticuloPrecio(Int32 idEmpresa, Int32 idArticulo)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarArticuloPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ArticuloPrecioE> ListarArticuloPrecio(Int32 idEmpresa)
        {
            List<ArticuloPrecioE> listaEntidad = new List<ArticuloPrecioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarArticuloPrecio", oConexion))
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
        
        public ArticuloPrecioE ObtenerArticuloPrecio(Int32 idEmpresa, Int32 idArticulo)
        {        
            ArticuloPrecioE articuloprecio = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerArticuloPrecio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articuloprecio = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return articuloprecio;
        }

    }
}