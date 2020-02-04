using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class HojaCostoOCAD : DbConection
    {

        public HojaCostoOCE LlenarEntidad(IDataReader oReader)
        {
            HojaCostoOCE hojacostooc = new HojaCostoOCE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostooc.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  hojacostooc;        
        }

        public HojaCostoOCE InsertarHojaCostoOC(HojaCostoOCE hojacostooc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarHojaCostoOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacostooc.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacostooc.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacostooc.idHojaCosto;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = hojacostooc.idOrdenCompra;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = hojacostooc.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return hojacostooc;
        }
        
        public HojaCostoOCE ActualizarHojaCostoOC(HojaCostoOCE hojacostooc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarHojaCostoOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacostooc.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacostooc.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacostooc.idHojaCosto;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = hojacostooc.idOrdenCompra;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = hojacostooc.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return hojacostooc;
        }        

        public int EliminarHojaCostoOC(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarHojaCostoOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<HojaCostoOCE> ListarHojaCostoOC(Int32 idEmpresa)
        {
           List<HojaCostoOCE> listaEntidad = new List<HojaCostoOCE>();
           HojaCostoOCE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarHojaCostoOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
            }

            return listaEntidad;
        }
        
        public HojaCostoOCE ObtenerHojaCostoOC(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra)
        {        
            HojaCostoOCE hojacostooc = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerHojaCostoOC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            hojacostooc = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return hojacostooc;
        }

    }
}