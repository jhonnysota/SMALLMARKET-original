using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class kardexXLSAD : DbConection
    {

        public Int32 InsertarkardexXLS(DataTable oDt)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarkardexXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    SqlParameter param = new SqlParameter("@Tabla", SqlDbType.Structured)
                    {
                        TypeName = "log_kardex_XLS",
                        Value = oDt
                    };

                    oComando.Parameters.Add(param);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        //public Int32 ProcesarVoucherXLS(Int32 idEmpresa, Int32 idLocal)
        //{
        //    Int32 resp = 0;

        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesarVoucherXLS", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;
        //            oComando.CommandTimeout = 0;
        //            oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
        //            oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
        //            oConexion.Open();
        //            resp = oComando.ExecuteNonQuery();
        //        }
        //    }

        //    return resp;
        //}

        //public Int32 IntegrarVoucherXLS()
        //{
        //    Int32 resp = 0;

        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_IntegrarArticulosXLS", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;
        //            oComando.CommandTimeout = 0;

        //            oConexion.Open();
        //            resp = oComando.ExecuteNonQuery();
        //        }
        //    }

        //    return resp;
        //}

        public Int32 EliminaKardexXLS(Int32 idEmpresa)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminaKardexXLS", oConexion))
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

    }
}
