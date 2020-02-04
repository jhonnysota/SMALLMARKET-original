using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class SaldosMensualesAD : DbConection
    {

        public SaldosMensualesE LlenarEntidad(IDataReader oReader)
        {
            SaldosMensualesE saldosmensuales = new SaldosMensualesE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.numVerPlanCuenta = oReader["numVerPlanCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaIni'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.codCuentaIni = oReader["codCuentaIni"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaIni"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.codCuentaFin = oReader["codCuentaFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NivelCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.NivelCuenta = oReader["NivelCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["NivelCuenta"]);

            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesIni'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    saldosmensuales.MesIni = oReader["MesIni"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesIni"]);

            //oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesFin'";
            //if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
            //    saldosmensuales.MesFin = oReader["MesFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesFin"]);

            //Extensiones

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ANTERIOR_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.SAL_ANTERIOR_SOLES = oReader["SAL_ANTERIOR_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ANTERIOR_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ANTERIOR_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.SAL_ANTERIOR_DOLARES = oReader["SAL_ANTERIOR_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ANTERIOR_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_DEBE_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.TOT_DEBE_SOLES = oReader["TOT_DEBE_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_DEBE_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_DEBE_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.TOT_DEBE_DOLARES = oReader["TOT_DEBE_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_DEBE_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_HABER_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.TOT_HABER_SOLES = oReader["TOT_HABER_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_HABER_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_HABER_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.TOT_HABER_DOLARES = oReader["TOT_HABER_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_HABER_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ACTUAL_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.SAL_ACTUAL_SOLES = oReader["SAL_ACTUAL_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ACTUAL_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ACTUAL_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.SAL_ACTUAL_DOLARES = oReader["SAL_ACTUAL_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ACTUAL_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.desPeriodo = oReader["desPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DES_PERIODO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.DES_PERIODO = oReader["DES_PERIODO"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DES_PERIODO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                saldosmensuales.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
            


            return saldosmensuales;
        }

        public List<SaldosMensualesE> SaldosMensualesReporte(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, Int32 NivelCuenta)
        {
            List<SaldosMensualesE> smensuales = new List<SaldosMensualesE>();
            SaldosMensualesE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 10).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 10).Value = codCuentaFin;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@NivelCuenta", SqlDbType.Int).Value = NivelCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CC = LlenarEntidad(oReader);
                            smensuales.Add(CC);
                        }
                    }
                }
                oConexion.Close();
            }
            return smensuales;
        }

        public List<SaldosMensualesE> SaldosCuentaAuxiliar(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin,String idComprobante, Int32 NivelCuenta, String idMoneda)
        {
            List<SaldosMensualesE> smensuales = new List<SaldosMensualesE>();
            SaldosMensualesE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteSaldosCuentaAuxiliar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 10).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 10).Value = codCuentaFin;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@NivelCuenta", SqlDbType.Int).Value = NivelCuenta;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CC = LlenarEntidad(oReader);
                            smensuales.Add(CC);
                        }
                    }
                }
                oConexion.Close();
            }
            return smensuales;
        }


        public List<SaldosMensualesE> ReporteResumenMesesSaldos(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, Int32 NivelCuenta)
        {
            List<SaldosMensualesE> smensualessaldos = new List<SaldosMensualesE>();
            SaldosMensualesE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteResumenMesesSaldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 10).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 10).Value = codCuentaFin;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@NivelCuenta", SqlDbType.Int).Value = NivelCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CC = LlenarEntidad(oReader);
                            smensualessaldos.Add(CC);
                        }
                    }
                }
                oConexion.Close();
            }
            return smensualessaldos;
        }


    }
}
