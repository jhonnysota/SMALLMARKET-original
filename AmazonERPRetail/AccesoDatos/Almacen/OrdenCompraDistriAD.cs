using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenCompraDistriAD : DbConection
    {

        public OrdenCompraDistriE LlenarEntidad(IDataReader oReader)
        {
            OrdenCompraDistriE ordencompradistri = new OrdenCompraDistriE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompradistri.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompradistri.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompradistri.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Porcentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompradistri.Porcentaje = oReader["Porcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Porcentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompradistri.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompradistri.tipoCCosto = oReader["tipoCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoCCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompradistri.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompradistri.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompradistri.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            return ordencompradistri;        
        }

        public OrdenCompraDistriE InsertarOrdenCompraDistri(OrdenCompraDistriE ordencompradistri)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenCompraDistri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompradistri.idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompradistri.idOrdenCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = ordencompradistri.idCCostos;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = ordencompradistri.Porcentaje;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordencompradistri.Monto;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompradistri;
        }
        
        public OrdenCompraDistriE ActualizarOrdenCompraDistri(OrdenCompraDistriE ordencompradistri)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenCompraDistri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompradistri.idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordencompradistri.idOrdenCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = ordencompradistri.idCCostos;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = ordencompradistri.Porcentaje;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordencompradistri.Monto;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompradistri;
        }        

        public int EliminarOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenCompraDistri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenCompraDistriE> ListarOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra)
        {
           List<OrdenCompraDistriE> listaEntidad = new List<OrdenCompraDistriE>();
           OrdenCompraDistriE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenCompraDistri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;

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
        
        public OrdenCompraDistriE ObtenerOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra, String idCCostos)
        {        
            OrdenCompraDistriE ordencompradistri = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenCompraDistri", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = idOrdenCompra;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = idCCostos;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordencompradistri = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordencompradistri;
        }

    }
}