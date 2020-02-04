using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class BalanceComprobacionAD : DbConection
    {

        public BalanceComprobacionE LlenarEntidad(IDataReader oReader)
        {
            BalanceComprobacionE BalanceComprobacion = new BalanceComprobacionE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.CodCostos = oReader["CodCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.DesCostos = oReader["DesCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.CodCuenta = oReader["CodCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.DesCuenta = oReader["DesCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MayorDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.MayorDebe = oReader["MayorDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MayorDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MayorHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.MayorHaber = oReader["MayorHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MayorHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoActualDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.SaldoActualDebe = oReader["SaldoActualDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoActualDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoActualHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.SaldoActualHaber = oReader["SaldoActualHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoActualHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='InvenActivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.InvenActivo = oReader["InvenActivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["InvenActivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='InvenPasivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.InvenPasivo = oReader["InvenPasivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["InvenPasivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorFuncionPerdida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.PorFuncionPerdida = oReader["PorFuncionPerdida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorFuncionPerdida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorFuncionGanancia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.PorFuncionGanancia = oReader["PorFuncionGanancia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorFuncionGanancia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorNaturalezaPerdida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.PorNaturalezaPerdida = oReader["PorNaturalezaPerdida"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorNaturalezaPerdida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorNaturalezaGanancia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                BalanceComprobacion.PorNaturalezaGanancia = oReader["PorNaturalezaGanancia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorNaturalezaGanancia"]);

            return BalanceComprobacion;
        }

        public List<BalanceComprobacionE> ListarBalanceComprobacionAcumulado(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Version, String idMoneda, Int32 Nivel, String Formato)
        {
            List<BalanceComprobacionE> ListaBalance = new List<BalanceComprobacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BalanceComprobacionAcumulado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@Version", SqlDbType.VarChar, 3).Value = Version;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@Nivel", SqlDbType.Int).Value = Nivel;
                    oComando.Parameters.Add("@Formato", SqlDbType.VarChar, 1).Value = Formato;

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
        
        public List<BalanceComprobacionE> ListarBalanceComprobacionCCostoAcumulado(Int32 idEmpresa, Int32 idLocal, String Anio, String Mes, String Version, String idMoneda, String CCosto, String Formato, Int32 numNivel)
        {
            List<BalanceComprobacionE> ListaBalance = new List<BalanceComprobacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_balancecomprobacionCCostoAcumulado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@Version", SqlDbType.VarChar, 3).Value = Version;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@CCosto", SqlDbType.VarChar, 10).Value = CCosto;
                    oComando.Parameters.Add("@Formato", SqlDbType.VarChar, 1).Value = Formato;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

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
