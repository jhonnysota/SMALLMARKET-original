using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ImportarComprasAD : DbConection
    {

        public int ImportarCompras(string codEmpresa, string codSucursal, string codLibro, DateTime fecDesde, DateTime fecHasta, int idEmpresa)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_importar_compras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@AS_COD_EMPRESA", SqlDbType.VarChar,4).Value = codEmpresa;
                    oComando.Parameters.Add("@AS_COD_SUCURSAL", SqlDbType.VarChar,3).Value = codSucursal;
                    oComando.Parameters.Add("@AS_LIBRO", SqlDbType.Char,2).Value = codLibro;
                    oComando.Parameters.Add("@FEC_DESDE", SqlDbType.DateTime).Value = fecDesde;
                    oComando.Parameters.Add("@FEC_HASTA", SqlDbType.DateTime).Value = fecHasta;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

    }
}