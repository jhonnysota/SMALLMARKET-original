using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class RegistroVentasReporteAD : DbConection
    {
        
        public RegistroVentasReporteE LlenarEntidad(IDataReader oReader)
        {
            RegistroVentasReporteE emisiondocumento = new RegistroVentasReporteE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.NomMes = oReader["NomMes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomMes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Mov = oReader["Mov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.DesDocumento = oReader["DesDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecEmision = oReader["fecEmision"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseAfecta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.BaseAfecta = oReader["BaseAfecta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseAfecta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseInafecta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.BaseInafecta = oReader["BaseInafecta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseInafecta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseExportacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.BaseExportacion = oReader["BaseExportacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseExportacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dctoBaseImponible'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.dctoBaseImponible = oReader["dctoBaseImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["dctoBaseImponible"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Isc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Isc = oReader["Isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Isc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalME'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumento.TotalME = oReader["TotalME"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalME"]);

            return emisiondocumento;
        }

        public List<RegistroVentasReporteE> ReporteRegistroVentas(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Int32 idVendedor, Int32 idCliente, String idMoneda)
        {
            List<RegistroVentasReporteE> ListaDocumentos = new List<RegistroVentasReporteE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oComando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar,2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaDocumentos;
        }

    }
}
