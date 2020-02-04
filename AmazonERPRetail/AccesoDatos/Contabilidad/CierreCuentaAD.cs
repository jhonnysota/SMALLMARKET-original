using System;
using System.Data;
using System.Data.SqlClient;

using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CierreCuentaAD : DbConection
    {
        
        public void ProcesoCierreCuentaPreLiminar(int idEmpresa, int idLocal,DateTime fecCierre)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesoCierreCuentaPreLiminar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 300;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecCierre", SqlDbType.SmallDateTime).Value = fecCierre;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }


        public void ProcesoCierreCuentaResultado(int idEmpresa, int idLocal, string Version, string AnioCierre, DateTime fecCierre,int Nivel, Decimal tcCie, string idMoneda, string idDiario, string idFile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraCierreCtaResultado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.Add("@AS_COD_EMPRESA", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AS_COD_SUCURSAL", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AS_VER_CUENTAS", SqlDbType.Char, 3).Value = Version;
                    oComando.Parameters.Add("@AS_ANO_PROCESO_CIE", SqlDbType.Char, 4).Value = AnioCierre;
                    oComando.Parameters.Add("@AD_FEC_PROCESO_CIE", SqlDbType.SmallDateTime).Value = fecCierre;
                    oComando.Parameters.Add("@AN_NIVEL_CUENTA", SqlDbType.Int).Value = Nivel;
                    oComando.Parameters.Add("@AN_TPO_CAMBIO_CIE", SqlDbType.Decimal).Value = tcCie;
                    oComando.Parameters.Add("@AS_COD_MONEDA", SqlDbType.Char, 2).Value = idMoneda;
                    oComando.Parameters.Add("@AS_COD_DIARIO", SqlDbType.Char, 2).Value = idDiario;
                    oComando.Parameters.Add("@AS_NUM_FILE", SqlDbType.Char, 2).Value = idFile;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void EliminaCierreBalance(int idEmpresa, int idLocal, string AnioCierre, string idDiario, string idFile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminaCierreBalance", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.Add("@AS_COD_EMPRESA", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AS_COD_SUCURSAL", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AS_ANO_PROCESO_CIE", SqlDbType.Char, 4).Value = AnioCierre;
                    oComando.Parameters.Add("@AS_COD_DIARIO", SqlDbType.Char, 2).Value = idDiario;
                    oComando.Parameters.Add("@AS_NUM_FILE", SqlDbType.Char, 2).Value = idFile;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void ProcesoCierreCuentaBalance(int idEmpresa, int idLocal, string Version, string AnioCierre, string MesApertura, string AnioApertura, DateTime fecCierre, DateTime fecApertura, int Nivel, Decimal tcCie, Decimal tcApe, string idMoneda, string CtaCie, string CtaApe, string idDiario, string idFile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraCierreBalance", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.Add("@AS_COD_EMPRESA", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AS_COD_SUCURSAL", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AS_VER_CUENTAS", SqlDbType.Char, 3).Value = Version;
                    oComando.Parameters.Add("@AS_ANO_PROCESO_CIE", SqlDbType.Char, 4).Value = AnioCierre;
                    oComando.Parameters.Add("@AS_MES_PROCESO_APE", SqlDbType.Char, 2).Value = MesApertura;
                    oComando.Parameters.Add("@AS_ANO_PROCESO_APE", SqlDbType.Char, 4).Value = AnioApertura;
                    oComando.Parameters.Add("@AD_FEC_PROCESO_CIE", SqlDbType.SmallDateTime).Value = fecCierre;
                    oComando.Parameters.Add("@AD_FEC_PROCESO_APE", SqlDbType.SmallDateTime).Value = fecApertura;
                    oComando.Parameters.Add("@AN_NIVEL_CUENTA", SqlDbType.Int).Value = Nivel;
                    oComando.Parameters.Add("@AN_TPO_CAMBIO_CIE", SqlDbType.Decimal).Value = tcCie;
                    oComando.Parameters.Add("@AN_TPO_CAMBIO_APE", SqlDbType.Decimal).Value = tcApe;
                    oComando.Parameters.Add("@AS_COD_MONEDA", SqlDbType.Char, 2).Value = idMoneda;
                    oComando.Parameters.Add("@AS_CTA_EJERCICIO", SqlDbType.Char, 20).Value = CtaCie;
                    oComando.Parameters.Add("@AS_CTA_ACUMULADO", SqlDbType.Char, 20).Value = CtaApe;
                    oComando.Parameters.Add("@AS_COD_DIARIO", SqlDbType.Char, 2).Value = idDiario;
                    oComando.Parameters.Add("@AS_NUM_FILE", SqlDbType.Char, 2).Value = idFile;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void GeneraAperturaContable(int idEmpresa, int idLocal, string Version, string MesApertura, string AnioApertura, string MesCierre, string AnioCierre, DateTime fecApertura, Decimal tcApe, string idMoneda, string idDiarioCierre, string idFileCierre, string idDiario, string idFile, string CtaResultado, string CtaAcumulada, decimal MontoResultadoSoles, decimal MontoResultadoDolar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraAperturaContable", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.Add("@AS_COD_EMPRESA", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AS_COD_SUCURSAL", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AS_VER_CUENTAS", SqlDbType.Char, 3).Value = Version;                   
                    oComando.Parameters.Add("@AS_MES_PROCESO", SqlDbType.Char, 2).Value = MesApertura; 
                    oComando.Parameters.Add("@AS_ANO_PROCESO", SqlDbType.Char, 4).Value = AnioApertura;
                    oComando.Parameters.Add("@AS_MES_PROCESO_CIE", SqlDbType.Char, 2).Value = MesCierre;
                    oComando.Parameters.Add("@AS_ANO_PROCESO_CIE", SqlDbType.Char, 4).Value = AnioCierre;
                    oComando.Parameters.Add("@AD_FEC_PROCESO", SqlDbType.SmallDateTime).Value = fecApertura;
                    oComando.Parameters.Add("@AN_TPO_CAMBIO", SqlDbType.Decimal).Value = tcApe;    // tipo de Cambio de Apertura
                    oComando.Parameters.Add("@AS_COD_MONEDA", SqlDbType.Char, 2).Value = idMoneda; // Moneda
                    oComando.Parameters.Add("@AS_COD_CIERRE", SqlDbType.Char, 2).Value = idDiarioCierre; // Diario de Cierre
                    oComando.Parameters.Add("@AS_FIL_CIERRE", SqlDbType.Char, 2).Value = idFileCierre;   // File de Cierre
                    oComando.Parameters.Add("@AS_COD_DIARIO", SqlDbType.Char, 2).Value = idDiario; // Diario de Apertura
                    oComando.Parameters.Add("@AS_COD_FILE", SqlDbType.Char, 2).Value = idFile;     // File de Apertura
                    oComando.Parameters.Add("@AS_CTA_RESULTADO", SqlDbType.Char, 20).Value = CtaResultado;
                    oComando.Parameters.Add("@AS_CTA_ACUMULADO", SqlDbType.Char, 20).Value = CtaAcumulada;
                    oComando.Parameters.Add("@AN_IMP_RESUL_BASE", SqlDbType.Decimal, 2).Value = MontoResultadoSoles;
                    oComando.Parameters.Add("@AN_IMP_RESUL_REFE", SqlDbType.Decimal, 2).Value = MontoResultadoDolar;


                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

    }
}
