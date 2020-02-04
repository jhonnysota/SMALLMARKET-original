using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class Con_SaldosCostosAD : DbConection
    {

        public Con_SaldosCostosE LlenarEntidad(IDataReader oReader)
        {
            Con_SaldosCostosE Saldos = new Con_SaldosCostosE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ANTERIOR_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.SAL_ANTERIOR_SOLES = oReader["SAL_ANTERIOR_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ANTERIOR_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ANTERIOR_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.SAL_ANTERIOR_DOLARES = oReader["SAL_ANTERIOR_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ANTERIOR_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_DEBE_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.TOT_DEBE_SOLES = oReader["TOT_DEBE_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_DEBE_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_DEBE_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.TOT_DEBE_DOLARES = oReader["TOT_DEBE_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_DEBE_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_HABER_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.TOT_HABER_SOLES = oReader["TOT_HABER_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_HABER_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_HABER_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.TOT_HABER_DOLARES = oReader["TOT_HABER_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_HABER_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ACTUAL_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.SAL_ACTUAL_SOLES = oReader["SAL_ACTUAL_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ACTUAL_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ACTUAL_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.SAL_ACTUAL_DOLARES = oReader["SAL_ACTUAL_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ACTUAL_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IND_PROCESADO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.IND_PROCESADO = oReader["IND_PROCESADO"] == DBNull.Value ? true : Convert.ToBoolean(oReader["IND_PROCESADO"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indNaturalezaCta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.indNaturalezaCta = oReader["indNaturalezaCta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indNaturalezaCta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Saldos.desCosto = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            return Saldos;
        }

        public List<Con_SaldosCostosE> MayorizarCostos(Int32 idEmpresa, String as_anno)
        {
            List<Con_SaldosCostosE> ListaBalance = new List<Con_SaldosCostosE>();
            Con_SaldosCostosE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MayorizaCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@as_anno", SqlDbType.VarChar, 4).Value = as_anno;

                    oConexion.Open();
              
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaBalance.Add(Item);
                        }
                    }
                }
            }

            return ListaBalance;
        }

        public List<Con_SaldosCostosE> MayorizarCostosMes(Int32 idEmpresa, String Anio, String Mes, String Version)
        {
            List<Con_SaldosCostosE> ListaBalance = new List<Con_SaldosCostosE>();
            Con_SaldosCostosE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MayorizarCostosMes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@Version", SqlDbType.VarChar, 3).Value = Version;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaBalance.Add(Item);
                        }
                    }
                }
            }

            return ListaBalance;
        }


        public List<Con_SaldosCostosE> ObtenerResumenDetallePorCentrodeCosto(Int32 idEmpresa, Int32 idLocal, String anioPeriodo, String periodo, String periodoFin, String numVerPlanCuenta, String codCuentaIni, String codCuentaFin, Int32 numNivel)
        {
            List<Con_SaldosCostosE> ccostos = new List<Con_SaldosCostosE>();
            Con_SaldosCostosE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Reporte_Resumen_DetallePorCentrodeCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar).Value = anioPeriodo;
                    oComando.Parameters.Add("@periodo", SqlDbType.VarChar,2).Value = periodo;
                    oComando.Parameters.Add("@periodoFin", SqlDbType.VarChar,2).Value = periodoFin;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 20).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 20).Value = codCuentaFin;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            CC = LlenarEntidad(oReader);
                            ccostos.Add(CC);
                        }
                    }
                }
            }

            return ccostos;
        }

    }
}
