using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class HojaCostoAlmacenAD : DbConection
    {
        
        public HojaCostoAlmacenE LlenarEntidad(IDataReader oReader)
        {
            HojaCostoAlmacenE hojacostoalmacen = new HojaCostoAlmacenE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.idDocumentoAlmacen = oReader["idDocumentoAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDocumentoAlmacen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				hojacostoalmacen.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  hojacostoalmacen;        
        }

        public HojaCostoAlmacenE InsertarHojaCostoAlmacen(HojaCostoAlmacenE hojacostoalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarHojaCostoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacostoalmacen.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacostoalmacen.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacostoalmacen.idHojaCosto;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = hojacostoalmacen.tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = hojacostoalmacen.idDocumentoAlmacen;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = hojacostoalmacen.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = hojacostoalmacen.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = hojacostoalmacen.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = hojacostoalmacen.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return hojacostoalmacen;
        }
        
        public HojaCostoAlmacenE ActualizarHojaCostoAlmacen(HojaCostoAlmacenE hojacostoalmacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarHojaCostoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = hojacostoalmacen.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = hojacostoalmacen.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = hojacostoalmacen.idHojaCosto;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = hojacostoalmacen.tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = hojacostoalmacen.idDocumentoAlmacen;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = hojacostoalmacen.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = hojacostoalmacen.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = hojacostoalmacen.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = hojacostoalmacen.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return hojacostoalmacen;
        }        

        public int EliminarHojaCostoAlmacen(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarHojaCostoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<HojaCostoAlmacenE> ListarHojaCostoAlmacen()
        {
           List<HojaCostoAlmacenE> listaEntidad = new List<HojaCostoAlmacenE>();
           HojaCostoAlmacenE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarHojaCostoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public HojaCostoAlmacenE ObtenerHojaCostoAlmacen(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {        
            HojaCostoAlmacenE hojacostoalmacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerHojaCostoAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;
					oComando.Parameters.Add("@idDocumentoAlmacen", SqlDbType.Int).Value = idDocumentoAlmacen;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            hojacostoalmacen = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return hojacostoalmacen;
        }
    }
}