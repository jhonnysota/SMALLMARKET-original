using System;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenCompraParamAD : DbConection
    {

        public OrdenCompraParametrosE LlenarEntidad(IDataReader oReader)
        {
            OrdenCompraParametrosE ordencompraparam = new OrdenCompraParametrosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraparam.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraparam.tipOrdenCompra = oReader["tipOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipSecuenciaFlujo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraparam.tipSecuenciaFlujo = oReader["tipSecuenciaFlujo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipSecuenciaFlujo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipModalCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraparam.tipModalCompra = oReader["tipModalCompra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipModalCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordencompraparam.idMoneda = oReader["idMoneda"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPartPresupuestal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordencompraparam.indPartPresupuestal = oReader["indPartPresupuestal"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPartPresupuestal"]);

            return  ordencompraparam;        
        }

        public OrdenCompraParametrosE InsertarOrdenCompraParam(OrdenCompraParametrosE ordencompraparam)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenCompraParam", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompraparam.idEmpresa;
					oComando.Parameters.Add("@tipOrdenCompra", SqlDbType.Int).Value = ordencompraparam.tipOrdenCompra;
					oComando.Parameters.Add("@tipSecuenciaFlujo", SqlDbType.Int).Value = ordencompraparam.tipSecuenciaFlujo;
					oComando.Parameters.Add("@tipModalCompra", SqlDbType.Int).Value = ordencompraparam.tipModalCompra;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Int).Value = ordencompraparam.idMoneda;
                    oComando.Parameters.Add("@indPartPresupuestal", SqlDbType.Bit).Value = ordencompraparam.indPartPresupuestal;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompraparam;
        }
        
        public OrdenCompraParametrosE ActualizarOrdenCompraParam(OrdenCompraParametrosE ordencompraparam)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenCompraParam", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordencompraparam.idEmpresa;
					oComando.Parameters.Add("@tipOrdenCompra", SqlDbType.Int).Value = ordencompraparam.tipOrdenCompra;
					oComando.Parameters.Add("@tipSecuenciaFlujo", SqlDbType.Int).Value = ordencompraparam.tipSecuenciaFlujo;
					oComando.Parameters.Add("@tipModalCompra", SqlDbType.Int).Value = ordencompraparam.tipModalCompra;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Int).Value = ordencompraparam.idMoneda;
                    oComando.Parameters.Add("@indPartPresupuestal", SqlDbType.Bit).Value = ordencompraparam.indPartPresupuestal;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordencompraparam;
        }        
        
        public OrdenCompraParametrosE ObtenerOrdenCompraParam(Int32 idEmpresa)
        {
            OrdenCompraParametrosE ordencompraparam = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenCompraParam", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordencompraparam = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordencompraparam;
        }

    }
}