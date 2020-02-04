using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class CostosMovimientosItemAD : DbConection
    {
        
        public CostosMovimientosItemE LlenarEntidad(IDataReader oReader)
        {
            CostosMovimientosItemE costosmovimientositem = new CostosMovimientosItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idElemento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.idElemento = oReader["idElemento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idElemento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodClasificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.CodClasificacion = oReader["CodClasificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodClasificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                costosmovimientositem.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.Mes = oReader["Mes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.Monto = oReader["Monto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientositem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  costosmovimientositem;        
        }

        public CostosMovimientosItemE InsertarCostosMovimientosItem(CostosMovimientosItemE costosmovimientositem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCostosMovimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = costosmovimientositem.idEmpresa;
					oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = costosmovimientositem.idElemento;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = costosmovimientositem.CodClasificacion;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = costosmovimientositem.Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = costosmovimientositem.Mes;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = costosmovimientositem.Monto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = costosmovimientositem.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = costosmovimientositem.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = costosmovimientositem.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = costosmovimientositem.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return costosmovimientositem;
        }
        
        public CostosMovimientosItemE ActualizarCostosMovimientosItem(CostosMovimientosItemE costosmovimientositem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCostosMovimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = costosmovimientositem.idEmpresa;
					oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = costosmovimientositem.idElemento;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = costosmovimientositem.CodClasificacion;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = costosmovimientositem.Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = costosmovimientositem.Mes;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = costosmovimientositem.Monto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = costosmovimientositem.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = costosmovimientositem.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = costosmovimientositem.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = costosmovimientositem.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return costosmovimientositem;
        }        

        public int EliminarCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion, String Mes,String Anio)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCostosMovimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = idElemento;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;
					oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CostosMovimientosItemE> ListarCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion)
        {
           List<CostosMovimientosItemE> listaEntidad = new List<CostosMovimientosItemE>();
           CostosMovimientosItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCostosMovimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = idElemento;
                    oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;

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
        
        public CostosMovimientosItemE ObtenerCostosMovimientosItem(Int32 idEmpresa, Int32 idElemento, String CodClasificacion, String Mes, String Anio)
        {        
            CostosMovimientosItemE costosmovimientositem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCostosMovimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = idElemento;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;
					oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            costosmovimientositem = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return costosmovimientositem;
        }
    }
}