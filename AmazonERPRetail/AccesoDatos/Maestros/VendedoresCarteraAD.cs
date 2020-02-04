using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class VendedoresCarteraAD : DbConection
    {
        
        public VendedoresCarteraE LlenarEntidad(IDataReader oReader)
        {
            VendedoresCarteraE vendedorescartera = new VendedoresCarteraE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCliente'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.idCliente = oReader["idCliente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCliente"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				vendedorescartera.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedorescartera.desVendedor = oReader["desVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCliente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedorescartera.desCliente = oReader["desCliente"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCliente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                vendedorescartera.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            return  vendedorescartera;        
        }

        public VendedoresCarteraE InsertarVendedoresCartera(VendedoresCarteraE vendedorescartera)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVendedoresCartera", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = vendedorescartera.idEmpresa;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = vendedorescartera.idVendedor;
					oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = vendedorescartera.idCliente;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = vendedorescartera.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return vendedorescartera;
        }
        
        public VendedoresCarteraE ActualizarVendedoresCartera(VendedoresCarteraE vendedorescartera)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVendedoresCartera", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = vendedorescartera.idEmpresa;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = vendedorescartera.idVendedor;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = vendedorescartera.idCliente;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = vendedorescartera.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return vendedorescartera;
        }        

        public int EliminarVendedoresCartera(Int32 idEmpresa, Int32 idVendedor, Int32 idCliente)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVendedoresCartera", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
					oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<VendedoresCarteraE> ListarVendedoresCartera(Int32 idEmpresa, Int32 idVendedor)
        {
           List<VendedoresCarteraE> listaEntidad = new List<VendedoresCarteraE>();
           VendedoresCarteraE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVendedoresCartera", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

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
        
        public VendedoresCarteraE ObtenerVendedoresCartera(Int32 idEmpresa, Int32 idVendedor, Int32 idCliente)
        {        
            VendedoresCarteraE vendedorescartera = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVendedoresCartera", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
					oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            vendedorescartera = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return vendedorescartera;
        }

        public VendedoresCarteraE ObtenerCarteraPorIdCliente(Int32 idEmpresa, Int32 idCliente)
        {
            VendedoresCarteraE vendedorescartera = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCarteraPorIdCliente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            vendedorescartera = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return vendedorescartera;
        }

    }
}