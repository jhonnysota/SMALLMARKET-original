using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class RequerimientosItemAD : DbConection
    {
        
        public RequerimientosItemE LlenarEntidad(IDataReader oReader)
        {
            RequerimientosItemE requerimientositem = new RequerimientosItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRequerimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.idRequerimiento = oReader["idRequerimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRequerimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientositem.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientositem.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUMedida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.idUMedida = oReader["idUMedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUMedida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantRequerida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.cantRequerida = oReader["cantRequerida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["cantRequerida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantAtendida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.cantAtendida = oReader["cantAtendida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["cantAtendida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstadoDet'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.indEstadoDet = oReader["indEstadoDet"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstadoDet"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Stock'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.Stock = oReader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Stock"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requerimientositem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientositem.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientositem.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantRequerida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requerimientositem.cantTemporal = oReader["cantRequerida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["cantRequerida"]);

            return  requerimientositem;        
        }

        public RequerimientosItemE InsertarRequerimientosItem(RequerimientosItemE requerimientositem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRequerimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = requerimientositem.idRequerimiento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = requerimientositem.Item;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requerimientositem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requerimientositem.idLocal;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = requerimientositem.idTipoArticulo;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = requerimientositem.idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = requerimientositem.Lote;
					oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = requerimientositem.idUMedida;
					oComando.Parameters.Add("@cantRequerida", SqlDbType.Decimal).Value = requerimientositem.cantRequerida;
					oComando.Parameters.Add("@cantAtendida", SqlDbType.Decimal).Value = requerimientositem.cantAtendida;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).Value = requerimientositem.Observacion;
					oComando.Parameters.Add("@indEstadoDet", SqlDbType.VarChar, 2).Value = requerimientositem.indEstadoDet;
					oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = requerimientositem.Stock;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requerimientositem.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requerimientositem;
        }
        
        public RequerimientosItemE ActualizarRequerimientosItem(RequerimientosItemE requerimientositem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRequerimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = requerimientositem.idRequerimiento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = requerimientositem.Item;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requerimientositem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requerimientositem.idLocal;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = requerimientositem.idTipoArticulo;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = requerimientositem.idArticulo;
                    oComando.Parameters.Add("@Lote", SqlDbType.VarChar, 20).Value = requerimientositem.Lote;
					oComando.Parameters.Add("@idUMedida", SqlDbType.Int).Value = requerimientositem.idUMedida;
					oComando.Parameters.Add("@cantRequerida", SqlDbType.Decimal).Value = requerimientositem.cantRequerida;
					oComando.Parameters.Add("@cantAtendida", SqlDbType.Decimal).Value = requerimientositem.cantAtendida;
					oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).Value = requerimientositem.Observacion;
					oComando.Parameters.Add("@indEstadoDet", SqlDbType.VarChar, 2).Value = requerimientositem.indEstadoDet;
					oComando.Parameters.Add("@Stock", SqlDbType.Decimal).Value = requerimientositem.Stock;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requerimientositem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requerimientositem;
        }        

        public int EliminarRequerimientosItem(Int32 idRequerimiento, Int32 Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRequerimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RequerimientosItemE> ListarRequerimientosItem(Int32 idRequerimiento)
        {
            List<RequerimientosItemE> listaEntidad = new List<RequerimientosItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequerimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;

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
        
        public RequerimientosItemE ObtenerRequerimientosItem(Int32 idRequerimiento, Int32 Item)
        {
            RequerimientosItemE requerimientositem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRequerimientosItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            requerimientositem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return requerimientositem;
        }

    }
}