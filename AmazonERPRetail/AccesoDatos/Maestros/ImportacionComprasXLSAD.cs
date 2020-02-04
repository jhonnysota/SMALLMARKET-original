using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ImportacionComprasXLSAD : DbConection
    {

        public Int32 InsertarComprasXLS(DataTable oDt)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLibroImportacionComprasXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    SqlParameter param = new SqlParameter("@Tabla", SqlDbType.Structured);
                    param.TypeName = "ImportacionCompras";
                    param.Value = oDt;

                    oComando.Parameters.Add(param);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ProcesarLibroImportacionComprasXLS()
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesarLibroImportacionVentasXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 IntegrarLibroImportacionComprasXLS()
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_IntegrarLibroImportacionVentasXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}
