using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PresupuestoDeVentasXLSAD : DbConection
    {

        public Int32 InsertarPresupuestoDeVentasXLS(DataTable oDt)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPresupuestoDeVentasXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    SqlParameter param = new SqlParameter("@Tabla", SqlDbType.Structured)
                    {
                        TypeName = "PresupuestoDeVentasXLS",
                        Value = oDt
                    };
                    oComando.Parameters.Add(param);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ProcesarPresupuestoDeVentasXLS(Int32 idEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesarPresupuestoDeVentasXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarPresupuestoDeVentasXLS(Int32 idEmpresa, String Anio , Int32 idVendedor)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPresupuestoDeVentasXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}
