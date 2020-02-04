using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegistroLibroMayorAD : DbConection
    {

        public RegistroLibroMayorE LlenarEntidad(IDataReader oReader)
        {
            RegistroLibroMayorE oRegMayor = new RegistroLibroMayorE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desPeriodo = oReader["desPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.Fecha = oReader["Fecha"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.impSoles = oReader["impSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.impDolares = oReader["impDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesDebe = oReader["antSolesDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesHaber = oReader["antSolesHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarDebe = oReader["antDolarDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarHaber = oReader["antDolarHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.Nivel2 = oReader["Nivel2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desCuenta2 = oReader["desCuenta2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesDebe2 = oReader["antSolesDebe2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesHaber2 = oReader["antSolesHaber2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarDebe2 = oReader["antDolarDebe2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarHaber2 = oReader["antDolarHaber2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.Nivel1 = oReader["Nivel1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desCuenta1 = oReader["desCuenta1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesDebe1 = oReader["antSolesDebe1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesHaber1 = oReader["antSolesHaber1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarDebe1 = oReader["antDolarDebe1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarHaber1 = oReader["antDolarHaber1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe0'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesDebe0 = oReader["antSolesDebe0"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe0"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber0'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antSolesHaber0 = oReader["antSolesHaber0"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber0"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe0'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarDebe0 = oReader["antDolarDebe0"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe0"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber0'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.antDolarHaber0 = oReader["antDolarHaber0"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber0"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Campo3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.Campo3 = oReader["Campo3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Campo3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.codPlanCuenta = oReader["codPlanCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.desCostos = oReader["desCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.TD = oReader["TD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegMayor.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            return oRegMayor;
        }

        public List<RegistroLibroMayorE> RegistroLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String codCuentaIni, String codCuentaFin)
        {
            List<RegistroLibroMayorE> oListaLibroMayor = new List<RegistroLibroMayorE>();
            RegistroLibroMayorE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroLibroMayorGeneral", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.Char, 2).Value = MesFin;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 20).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 20).Value = codCuentaFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            oListaLibroMayor.Add(Item);
                        }
                    }
                }
            }

            return oListaLibroMayor;
        }

    }
}
