using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class RequisicionProveedorAD : DbConection
    {

        public RequisicionProveedorE LlenarEntidad(IDataReader oReader)
        {
            RequisicionProveedorE requisicionproveedor = new RequisicionProveedorE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRequisicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.idRequisicion = oReader["idRequisicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRequisicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				requisicionproveedor.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicionproveedor.DesPersona = oReader["DesPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPersona"]);

            return  requisicionproveedor;        
        }

        public RequisicionProveedorE InsertarRequisicionProveedor(RequisicionProveedorE requisicionproveedor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRequisicionProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicionproveedor.idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = requisicionproveedor.idRequisicion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = requisicionproveedor.idPersona;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = requisicionproveedor.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = requisicionproveedor.FechaRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requisicionproveedor;
        }
        
        public RequisicionProveedorE ActualizarRequisicionProveedor(RequisicionProveedorE requisicionproveedor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRequisicionProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = requisicionproveedor.idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = requisicionproveedor.idRequisicion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = requisicionproveedor.idPersona;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = requisicionproveedor.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return requisicionproveedor;
        }        

        public int EliminarRequisicionProveedor(Int32 idEmpresa, Int32 idRequisicion, Int32 idPersona)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRequisicionProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RequisicionProveedorE> ListarRequisicionProveedor(Int32 idEmpresa, Int32 idRequisicion)
        {
            List<RequisicionProveedorE> listaEntidad = new List<RequisicionProveedorE>();
            RequisicionProveedorE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRequisicionProveedor", oConexion))
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
        
        public RequisicionProveedorE ObtenerRequisicionProveedor(Int32 idEmpresa, Int32 idRequisicion, Int32 idPersona)
        {        
            RequisicionProveedorE requisicionproveedor = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRequisicionProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRequisicion", SqlDbType.Int).Value = idRequisicion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            requisicionproveedor = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return requisicionproveedor;
        }

    }
}