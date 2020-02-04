using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class Con_SaldosAD : DbConection
    {

        public Con_SaldosE LlenarEntidad(IDataReader oReader)
        {
            Con_SaldosE Mayorizacion = new Con_SaldosE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ANTERIOR_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.SAL_ANTERIOR_SOLES = oReader["SAL_ANTERIOR_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ANTERIOR_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ANTERIOR_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.SAL_ANTERIOR_DOLARES = oReader["SAL_ANTERIOR_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ANTERIOR_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_DEBE_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.TOT_DEBE_SOLES = oReader["TOT_DEBE_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_DEBE_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_DEBE_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.TOT_DEBE_DOLARES = oReader["TOT_DEBE_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_DEBE_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_HABER_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.TOT_HABER_SOLES = oReader["TOT_HABER_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_HABER_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TOT_HABER_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.TOT_HABER_DOLARES = oReader["TOT_HABER_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TOT_HABER_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ACTUAL_SOLES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.SAL_ACTUAL_SOLES = oReader["SAL_ACTUAL_SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ACTUAL_SOLES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SAL_ACTUAL_DOLARES'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.SAL_ACTUAL_DOLARES = oReader["SAL_ACTUAL_DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SAL_ACTUAL_DOLARES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IND_PROCESADO'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.IND_PROCESADO = oReader["IND_PROCESADO"] == DBNull.Value ? true : Convert.ToBoolean(oReader["IND_PROCESADO"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Mayorizacion.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            return Mayorizacion;
        }

        public List<Con_SaldosE> MayorizarMayor(Int32 idEmpresa, Int32 idLocal, String vi_mes_inicio, String vi_ano_inicio, String vi_mes_proceso, String vi_ano_proceso, String vi_ver_placta)
         {
             List<Con_SaldosE> ListaBalance = new List<Con_SaldosE>();
             Con_SaldosE Item = null;

             using (SqlConnection oConexion = ConexionSql())
             {
                 using (SqlCommand oComando = new SqlCommand("retail.usp_MayorizaMayor", oConexion))
                 {
                     oComando.CommandType = CommandType.StoredProcedure;
                     oComando.CommandTimeout = 0;
                     oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                     oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                     oComando.Parameters.Add("@vi_mes_inicio", SqlDbType.VarChar, 2).Value = vi_mes_inicio;
                     oComando.Parameters.Add("@vi_ano_inicio", SqlDbType.VarChar, 4).Value = vi_ano_inicio;
                     oComando.Parameters.Add("@vi_mes_proceso", SqlDbType.VarChar, 2).Value = vi_mes_proceso;
                     oComando.Parameters.Add("@vi_ano_proceso", SqlDbType.VarChar, 4).Value = vi_ano_proceso;
                     oComando.Parameters.Add("@vi_ver_placta", SqlDbType.VarChar, 3).Value = vi_ver_placta;

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

        public List<Con_SaldosE> MayorizarCuentaMes(Int32 idEmpresa, String Anio, String Mes, String Version)
        {
            List<Con_SaldosE> ListaBalance = new List<Con_SaldosE>();
            Con_SaldosE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MayorizarCuentaMes", oConexion))
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

        public List<Con_SaldosE> MayorizarCuentaMesCero(Int32 idEmpresa, String Anio, String Mes, String Version)
        {
            List<Con_SaldosE> ListaBalance = new List<Con_SaldosE>();
            Con_SaldosE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MayorizarCuentaMesCero", oConexion))
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

        public Con_SaldosE Obtenercon_saldos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            Con_SaldosE saldos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Obtenercon_saldos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            saldos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return saldos;
        }

        public List<Con_SaldosE> SaldoContableApertura(Int32 idEmpresa, String Anio, String Mes)
        {
            List<Con_SaldosE> ListaBalance = new List<Con_SaldosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_SaldoContableApertura", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaBalance.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaBalance;
        }

    }
}
