using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class DifCambioAD : DbConection
    {

        public DifCambioE LlenarEntidad(IDataReader oReader)
        {
            DifCambioE Diferencia = new DifCambioE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.CodCuenta = oReader["CodCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCambio_X_Compra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.indCambio_X_Compra = oReader["indCambio_X_Compra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCambio_X_Compra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Historico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.Historico = oReader["Historico"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Historico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ajuste'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.Ajuste = oReader["Ajuste"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Ajuste"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salActualSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.salActualSoles = oReader["salActualSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salActualSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='salAactualDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.salAactualDolares = oReader["salAactualDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["salAactualDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambioVt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.tipCambioVt = oReader["tipCambioVt"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambioVt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambioCp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.tipCambioCp = oReader["tipCambioCp"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambioCp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoAjuste'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.desTipoAjuste = oReader["desTipoAjuste"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoAjuste"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAbreviatura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.desAbreviatura = oReader["desAbreviatura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAbreviatura"]);

            

            return Diferencia;
        }

        public List<DifCambioE> ListarConsistenciaDif(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idMoneda, String numVerPlanCuentas, DateTime Fecha)
        {
            List<DifCambioE> Diferencia = new List<DifCambioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConsistenciaDifCambio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Diferencia.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return Diferencia;
        }

        public void ProcesoDiferenciaCambio(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, String UsuarioAsignado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesoDiferenciaCambio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@ano", SqlDbType.VarChar, 4).Value = ano;
                    oComando.Parameters.Add("@mes", SqlDbType.Char, 2).Value = mes;
                    oComando.Parameters.AddWithValue("@INcodCuenta", INcodCuenta);
                    oComando.Parameters.Add("@numPlanCuenta", SqlDbType.VarChar, 3).Value = numPlanCuenta;
                    oComando.Parameters.Add("@UsuarioAsignado", SqlDbType.VarChar, 20).Value = UsuarioAsignado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarDiferenciaCambio(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, String UsuarioAsignado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarDiferenciaCambio", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@ano", ano);
                    oComando.Parameters.AddWithValue("@mes", mes);
                    oComando.Parameters.AddWithValue("@INcodCuenta", INcodCuenta);
                    oComando.Parameters.AddWithValue("@numPlanCuenta", numPlanCuenta);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void ProcesoDiferenciaCambioSoles(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta , String SoloCancelados, String UsuarioAsignado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesoDiferenciaCambioSoles", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@ano", SqlDbType.VarChar, 4).Value = ano;
                    oComando.Parameters.Add("@mes", SqlDbType.Char, 2).Value = mes;
                    oComando.Parameters.AddWithValue("@INcodCuenta", INcodCuenta);
                    oComando.Parameters.Add("@numPlanCuenta", SqlDbType.VarChar, 3).Value = numPlanCuenta;
                    oComando.Parameters.Add("@SoloCancelados", SqlDbType.VarChar, 1).Value = SoloCancelados;
                    oComando.Parameters.Add("@UsuarioAsignado", SqlDbType.VarChar, 20).Value = UsuarioAsignado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarDiferenciaCambioSoles(Int32 idEmpresa, String ano, String mes, String INcodCuenta, String numPlanCuenta, String SoloCancelados, String UsuarioAsignado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarDiferenciaCambioSoles", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@ano", ano);
                    oComando.Parameters.AddWithValue("@mes", mes);
                    oComando.Parameters.AddWithValue("@INcodCuenta", INcodCuenta);
                    oComando.Parameters.AddWithValue("@numPlanCuenta", numPlanCuenta);
                    oComando.Parameters.AddWithValue("@SoloCancelados", SoloCancelados);
                    oComando.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

    }
}
