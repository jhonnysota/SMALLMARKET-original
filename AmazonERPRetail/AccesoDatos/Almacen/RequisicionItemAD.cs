using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class RequisicionItemAD : DbConection
    {
        
        public RequisicionItemE LlenarEntidad(IDataReader oReader)
        {
            RequisicionItemE requisicionitem = new RequisicionItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRequisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.idRequisicion = oReader["idRequisicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRequisicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadRequerida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicionitem.CantidadRequerida = oReader["CantidadRequerida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadRequerida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoEstimado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.MontoEstimado = oReader["MontoEstimado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoEstimado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Especificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.Especificacion = oReader["Especificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Especificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CantidadOrdenada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicionitem.CantidadOrdenada = oReader["CantidadOrdenada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CantidadOrdenada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicionitem.DesArticulo = oReader["DesArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicionitem.MontoTotal = oReader["MontoTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoTotal"]);

            return  requisicionitem;        
        }

        public RequisicionItemE InsertarRequisicionItem(RequisicionItemE requisicionitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRequisicionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicionitem.idEmpresa;
                    oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = requisicionitem.idRequisicion;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requisicionitem.idLocal;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = requisicionitem.idArticulo;
                    oComando.Parameters.Add("@CantidadOrdenada", SqlDbType.Decimal).Value = requisicionitem.CantidadOrdenada;
                    oComando.Parameters.Add("@CantidadRequerida", SqlDbType.Decimal).Value = requisicionitem.CantidadRequerida;
					oComando.Parameters.Add("@MontoEstimado", SqlDbType.Decimal).Value = requisicionitem.MontoEstimado;
					oComando.Parameters.Add("@Especificacion", SqlDbType.VarChar, 100).Value = requisicionitem.Especificacion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requisicionitem.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = requisicionitem.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requisicionitem.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = requisicionitem.FechaModificacion;
                    oComando.Parameters.Add("@MontoTotal", SqlDbType.Decimal).Value = requisicionitem.MontoTotal;

                    oConexion.Open();
                    requisicionitem.idItem = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return requisicionitem;
        }
        
        public RequisicionItemE ActualizarRequisicionItem(RequisicionItemE requisicionitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRequisicionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicionitem.idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = requisicionitem.idRequisicion;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = requisicionitem.idItem;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = requisicionitem.idLocal;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = requisicionitem.idArticulo;
                    oComando.Parameters.Add("@CantidadOrdenada", SqlDbType.Decimal).Value = requisicionitem.CantidadOrdenada;
                    oComando.Parameters.Add("@CantidadRequerida", SqlDbType.Decimal).Value = requisicionitem.CantidadRequerida;
					oComando.Parameters.Add("@MontoEstimado", SqlDbType.Decimal).Value = requisicionitem.MontoEstimado;
					oComando.Parameters.Add("@Especificacion", SqlDbType.VarChar, 100).Value = requisicionitem.Especificacion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requisicionitem.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = requisicionitem.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requisicionitem.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = requisicionitem.FechaModificacion;
                    oComando.Parameters.Add("@MontoTotal", SqlDbType.Decimal).Value = requisicionitem.MontoTotal;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requisicionitem;
        }        

        public int EliminarRequisicionItem(Int32 idEmpresa, Int32 idRequisicion, Int32 idItem)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRequisicionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RequisicionItemE> ListarRequisicionItem(Int32 idEmpresa, Int32 idRequisicion)
        {
           List<RequisicionItemE> listaEntidad = new List<RequisicionItemE>();
           RequisicionItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequisicionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;

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
        
        public RequisicionItemE ObtenerRequisicionItem(Int32 idEmpresa, Int32 idRequisicion, Int32 idItem)
        {        
            RequisicionItemE requisicionitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRequisicionItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            requisicionitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return requisicionitem;
        }

    }
}