using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class conCtaCte14AD : DbConection
    {

        public conCtaCteE14 LlenarEntidad(IDataReader oReader)
        {
            conCtaCteE14 ctacte = new conCtaCteE14();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecCancelacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecCancelacion = oReader["fecCancelacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecCancelacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extension
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CargoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.CargoSoles = oReader["CargoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CargoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoSoles = oReader["SaldoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CargoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.CargoDolares = oReader["CargoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CargoDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.SaldoDolares = oReader["SaldoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDolares"]);

            //adicionales Henry
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? "" : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? "" : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Item = oReader["Item"] == DBNull.Value ? "" : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.TipoDoc = oReader["TipoDoc"] == DBNull.Value ? "" : Convert.ToString(oReader["TipoDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ctacte.Estado = oReader["Estado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Estado"]);


            return ctacte;
        }

        public List<conCtaCteE14> ReporteConCtaCte14(Int32 idEmpresa, String numPlanCta, String ano, String cuenta_ini, String cuenta_fin, 
            Int32 idPersona, String mes_inicial, String mes_fin, String idmoneda, String historico, String tipo_reporte)
        {
            List<conCtaCteE14> oListaCtaCte14 = new List<conCtaCteE14>();
            conCtaCteE14 oCtaCte14 = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand ocomando = new SqlCommand("retail.usp_ReporteConCtaCte14", oConexion))
                {
                    ocomando.CommandType = CommandType.StoredProcedure;

                    ocomando.Parameters.AddWithValue("@idempresa", idEmpresa);
                    ocomando.Parameters.AddWithValue("@ver_placta", numPlanCta);
                    ocomando.Parameters.AddWithValue("ano", ano);
                    ocomando.Parameters.AddWithValue("cuenta_ini", cuenta_ini);
                    ocomando.Parameters.AddWithValue("@cuenta_fin", cuenta_fin);
                    ocomando.Parameters.AddWithValue("@idPersona", idPersona);
                    ocomando.Parameters.AddWithValue("@mes_inicial", mes_inicial);
                    ocomando.Parameters.AddWithValue("@mes_final", mes_fin);
                    ocomando.Parameters.AddWithValue("@idMoneda", idmoneda);
                    ocomando.Parameters.AddWithValue("@historico", historico);
                    ocomando.Parameters.AddWithValue("@tipo_reporte", tipo_reporte);

                    oConexion.Open();

                    using (SqlDataReader OrEADER = ocomando.ExecuteReader())
                    {
                        while (OrEADER.Read())
                        {
                            oCtaCte14 = LlenarEntidad(OrEADER);
                            oListaCtaCte14.Add(oCtaCte14);
                        }
                    }


                }
            }

            return oListaCtaCte14;
        }

    }
}
