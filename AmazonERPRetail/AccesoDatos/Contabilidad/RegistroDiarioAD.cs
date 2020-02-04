using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegistroDiarioAD : DbConection
    {

        public RegistroDiarioE LlenarEntidad(IDataReader oReader)
        {
            RegistroDiarioE oRegDiario = new RegistroDiarioE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idPersona = oReader["idPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desReferenciaRep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desReferenciaRep = oReader["desReferenciaRep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desReferenciaRep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.impSoles = oReader["impSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.impDolares = oReader["impDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Campo3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Campo3 = oReader["Campo3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Campo3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.codPlanCuenta = oReader["codPlanCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TD'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.TD = oReader["TD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TD"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DebeSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.DebeSoles = oReader["DebeSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DebeSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HaberSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.HaberSoles = oReader["HaberSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["HaberSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DebeDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.DebeDolares = oReader["DebeDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["DebeDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HaberDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.HaberDolares = oReader["HaberDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["HaberDolares"]);

            //Extensiones Libro Mayor
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.desPeriodo = oReader["desPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Fecha = oReader["fecOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["fecOperacion"]);

            //Revisando
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='c_des_cta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.c_des_cta = oReader["c_des_cta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["c_des_cta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='c_des_aux'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.c_des_aux = oReader["c_des_aux"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["c_des_aux"]);                     

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='c_cod_libro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.c_cod_libro = oReader["c_cod_libro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["c_cod_libro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Auxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Auxiliar = oReader["Auxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Auxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antAuxSolesDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antAuxSolesDebe = oReader["antAuxSolesDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antAuxSolesDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antAuxSolesHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antAuxSolesHaber = oReader["antAuxSolesHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antAuxSolesHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesDebe = oReader["antSolesDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesHaber = oReader["antSolesHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarDebe = oReader["antDolarDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarHaber = oReader["antDolarHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Nivel2 = oReader["Nivel2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cDesCta2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.cDesCta2 = oReader["cDesCta2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["cDesCta2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesDebe2 = oReader["antSolesDebe2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesHaber2 = oReader["antSolesHaber2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarDebe2 = oReader["antDolarDebe2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarHaber2 = oReader["antDolarHaber2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Nivel1 = oReader["Nivel1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cDesCta1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.cDesCta1 = oReader["cDesCta1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["cDesCta1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesDebe1 = oReader["antSolesDebe1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesHaber1 = oReader["antSolesHaber1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarDebe1 = oReader["antDolarDebe1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarHaber1 = oReader["antDolarHaber1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe0'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesDebe0 = oReader["antSolesDebe0"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe0"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber0'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesHaber0 = oReader["antSolesHaber0"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber0"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nivel3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.Nivel3 = oReader["Nivel3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nivel3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cDesCta3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.cDesCta3 = oReader["cDesCta3"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["cDesCta3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesDebe3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesDebe3 = oReader["antSolesDebe3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesDebe3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antSolesHaber3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antSolesHaber3 = oReader["antSolesHaber3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antSolesHaber3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarDebe3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarDebe3 = oReader["antDolarDebe3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarDebe3"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='antDolarHaber3'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegDiario.antDolarHaber3 = oReader["antDolarHaber3"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["antDolarHaber3"]);            

            return oRegDiario;
        }

        public List<RegistroDiarioE> RegistroDeDiarioPLE(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal, Int32 Pag, Int32 CantReg)
        {
            List<RegistroDiarioE> ListaDiario = new List<RegistroDiarioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeDiario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.Char, 2).Value = MesFin;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@NumVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@idComprobanteInicial", SqlDbType.VarChar, 2).Value = idComprobanteInicial;
                    oComando.Parameters.Add("@idComprobanteFinal", SqlDbType.VarChar, 2).Value = idComprobanteFinal;
                    oComando.Parameters.Add("@Pag", SqlDbType.Int).Value = Pag;
                    oComando.Parameters.Add("@CantReg", SqlDbType.Int).Value = CantReg;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDiario.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDiario;
        }

        public List<RegistroDiarioE> RegistroDeDiarioEXCEL(Int32 idEmpresa, Int32 idLocal, DateTime FechaIni, DateTime FechaFin, String NumVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal, String Automatico)
        {
            List<RegistroDiarioE> ListaCompras = new List<RegistroDiarioE>();
            RegistroDiarioE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeDiarioExcel", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FechaIni;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
                    oComando.Parameters.Add("@NumVerPlanCuenta", SqlDbType.VarChar, 3).Value = NumVerPlanCuenta;
                    oComando.Parameters.Add("@idComprobanteInicial", SqlDbType.VarChar, 2).Value = idComprobanteInicial;
                    oComando.Parameters.Add("@idComprobanteFinal", SqlDbType.VarChar, 2).Value = idComprobanteFinal;
                    oComando.Parameters.Add("@Automatico", SqlDbType.VarChar, 1).Value = Automatico;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

        public List<RegistroDiarioE> ObtenerDetallePorCenttroDeCostro(Int32 idEmpresa, Int32 idLocal, int anioPeriodo, DateTime fecIni, DateTime fecFin, String codCuentaIni, String codCuentaFin, Int32 numNivel)
        {
            List<RegistroDiarioE> ccostos = new List<RegistroDiarioE>();
            RegistroDiarioE CC;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteDetallePorCentroDeCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.Int).Value = anioPeriodo;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
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

        public List<RegistroDiarioE> ObtenerLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin, Int32 Pag, Int32 CantReg)
        {
            List<RegistroDiarioE> LibroMayor = new List<RegistroDiarioE>();
            RegistroDiarioE LB;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteLibroMayor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar,3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar).Value = anioPeriodo;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar,2).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 2).Value = fecFin;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 20).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 20).Value = codCuentaFin;
                    oComando.Parameters.Add("@Pag", SqlDbType.Int).Value = Pag;
                    oComando.Parameters.Add("@CantReg", SqlDbType.Int).Value = CantReg;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            LB = LlenarEntidad(oReader);
                            LibroMayor.Add(LB);
                        }
                    }
                }
            }

            return LibroMayor;
        }

        public List<RegistroDiarioE> RegistroDeDiarioSimplificado(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal)
        {
            List<RegistroDiarioE> Lista = new List<RegistroDiarioE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeDiarioSimplificado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.Char, 2).Value = MesFin;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@NumVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@idComprobanteInicial", SqlDbType.VarChar, 2).Value = idComprobanteInicial;
                    oComando.Parameters.Add("@idComprobanteFinal", SqlDbType.VarChar, 2).Value = idComprobanteFinal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Lista.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return Lista;
        }

        public Int32 CantidadRegistroDiario(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CantidadRegistroDiario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.Char, 2).Value = MesFin;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@NumVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@idComprobanteInicial", SqlDbType.VarChar, 2).Value = idComprobanteInicial;
                    oComando.Parameters.Add("@idComprobanteFinal", SqlDbType.VarChar, 2).Value = idComprobanteFinal;

                    oConexion.Open();
                    resp = Int32.Parse(oComando.ExecuteScalar().ToString());
                    
                }
            }

            return resp;
        }

        public Int32 CantidadRegistroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CantidadRegistroMayor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@anioPeriodo", SqlDbType.VarChar).Value = anioPeriodo;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 2).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 2).Value = fecFin;
                    oComando.Parameters.Add("@codCuentaIni", SqlDbType.VarChar, 20).Value = codCuentaIni;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 20).Value = codCuentaFin;

                    oConexion.Open();
                    resp = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return resp;
        }

    }
}
