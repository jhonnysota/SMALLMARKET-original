using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class DisFactorAD : DbConection
    {

        public void ProcesoDistribucionFactor(int idEmpresa, int idLocal, DateTime FechaInicio, DateTime FechaFin, Decimal FactorDistribuidor, String Usuario)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_DistribucionFactor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idLocal", idLocal);
                    oComando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    oComando.Parameters.AddWithValue("@FechaFin", FechaFin);
                    oComando.Parameters.AddWithValue("@FactorDistribuidor", FactorDistribuidor);
                    oComando.Parameters.AddWithValue("@Usuario", Usuario);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }
        }

        public void ProcesoIngresoAlmacenFactor(int idEmpresa, int idLocal, DateTime FechaProceso, string Diario, string File, String Usuario)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_IngresoAlmacenFactor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idLocal", idLocal);
                    oComando.Parameters.AddWithValue("@FechaProceso", FechaProceso);
                    oComando.Parameters.AddWithValue("@Diario", Diario);
                    oComando.Parameters.AddWithValue("@File", File);
                    oComando.Parameters.AddWithValue("@Usuario", Usuario);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }
        }

    }
}
