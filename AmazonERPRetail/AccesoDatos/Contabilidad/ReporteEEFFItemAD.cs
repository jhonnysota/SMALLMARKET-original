using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ReporteEEFFItemAD : DbConection
    {

        public ReporteEEFFItemE LlenarEntidad(IDataReader oReader)
        {
            ReporteEEFFItemE entidad = new ReporteEEFFItemE();
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(Convert.ToInt32( oReader["AnioPeriodo"]));

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='secItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.secItem = oReader["secItem"] == DBNull.Value ? String.Empty : Convert.ToString(Convert.ToInt32(oReader["secItem"]));
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desItem = oReader["desItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desItem"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoTabla = oReader["TipoTabla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoTabla"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCaracteristica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoCaracteristica = oReader["TipoCaracteristica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCaracteristica"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='saldo_sol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.saldo_sol = oReader["saldo_sol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["saldo_sol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='saldo_dol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.saldo_dol = oReader["saldo_dol"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["saldo_dol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fila'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fila = oReader["fila"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["fila"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='columna'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.columna = oReader["columna"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["columna"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sSaldoSoles = oReader["SaldoSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SaldoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sSaldoDolares = oReader["SaldoDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SaldoDolares"]);

            return entidad;        
        }

        public VoucherItemE LlenarEntidadVoucherItem(IDataReader oReader)
        {
            VoucherItemE entidad = new VoucherItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(Convert.ToInt32(oReader["AnioPeriodo"]));
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desPartidaPresu = oReader["desPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRecepcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fecRecepcion = oReader["fecRecepcion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecRecepcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDebe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.impDebe = oReader["impDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDebe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.impHaber = oReader["impHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.DesPersona = oReader["DesPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indSolicitaCentroCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indSolicitaCentroCosto = oReader["indSolicitaCentroCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indSolicitaCentroCosto"]);

            return entidad;
        }

        public List<ReporteEEFFItemE> ListarRptEEFFGananciasPerdidas(Int32 idEmpresa, String anio, String mesInicio, String mesFin, Int32 idEEFF, String idCCostos, String indAcumulado, String indCCostos, String NumPlaCta, String TipoReporte, Decimal TipoCambio, Int32 numNivel)
        {
            List<ReporteEEFFItemE> listaEntidad = new List<ReporteEEFFItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteEEFFGananciasPerdidas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                    oComando.Parameters.Add("@mesInicio", SqlDbType.Char, 2).Value = mesInicio;
                    oComando.Parameters.Add("@mesFin", SqlDbType.Char, 2).Value = mesFin;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 200).Value = idCCostos;
                    oComando.Parameters.Add("@indAcumulado", SqlDbType.Char, 1).Value = indAcumulado;
                    oComando.Parameters.Add("@indCCostos", SqlDbType.Char, 1).Value = indCCostos;
                    oComando.Parameters.Add("@NumPlaCta", SqlDbType.VarChar, 3).Value = NumPlaCta;
                    oComando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = TipoReporte;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = TipoCambio;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<VoucherItemE> ListarRptEEFFGananciasPerdidasDetalle(Int32 idEmpresa, Int32 idLocal, String anio, String mesInicio, String mesFin, Int32 idEEFF, Int32 idEEFFItem, String idCCostos, String idMoneda, String TipoReporte)
        {
            List<VoucherItemE> listaEntidad = new List<VoucherItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteEEFFGananciasPerdidasDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idLocal", idLocal);
                    oComando.Parameters.AddWithValue("@anio", anio);
                    oComando.Parameters.AddWithValue("@mesInicio", mesInicio);
                    oComando.Parameters.AddWithValue("@mesFin", mesFin);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);
                    oComando.Parameters.AddWithValue("@idEEFFItem", idEEFFItem);
                    oComando.Parameters.AddWithValue("@idCCostos", idCCostos);
                    oComando.Parameters.AddWithValue("@idMoneda", idMoneda);
                    oComando.Parameters.AddWithValue("@TipoReporte", TipoReporte);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidadVoucherItem(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ReporteEEFFItemE> ListarReporteEEFFGananciasPerdidasArchivo(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFitem)
        {
            List<ReporteEEFFItemE> listaEntidad = new List<ReporteEEFFItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteEEFFGananciasPerdidasArchivo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@idEEFF", idEEFF);
                    oComando.Parameters.AddWithValue("@idEEFFitem", idEEFFitem);

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ReporteEEFFItemE> ListarReporteEEFFGananciasPerdidasRatios(Int32 idEmpresa, String Anio, String MesInicio, String MesFin, Int32 idEEFF, String NumPlaCta, Boolean Calculo)
        {
            List<ReporteEEFFItemE> listaEntidad = new List<ReporteEEFFItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReporteEEFFGananciasPerdidasRatios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@MesInicio", SqlDbType.VarChar, 2).Value = MesInicio;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@NumPlaCta", SqlDbType.VarChar, 3).Value = NumPlaCta;
                    oComando.Parameters.Add("@Calculo", SqlDbType.Bit).Value = Calculo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }

    }
}