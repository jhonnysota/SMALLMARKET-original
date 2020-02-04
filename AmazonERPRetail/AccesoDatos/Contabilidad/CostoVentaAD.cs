using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class CostoVentaAD : DbConection
    {

        public CostoVentaE LlenarEntidad(IDataReader oReader)
        {
            CostoVentaE oCosto = new CostoVentaE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.nomCategoria = oReader["nomCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaConsumo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.codCuentaConsumo = oReader["codCuentaConsumo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaConsumo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoPromUnitarioBase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.impCostoPromUnitarioBase = oReader["impCostoPromUnitarioBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoPromUnitarioBase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.totCosto = oReader["totCosto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.desTipMovimiento = oReader["desTipMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMovAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.codMovAlmacen = oReader["codMovAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codMovAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.fecProceso = oReader["fecProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecProceso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Lote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.Lote = oReader["Lote"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Lote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.desAlmacen = oReader["desAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCostoPromUnitarioRefe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.impCostoPromUnitarioRefe = oReader["impCostoPromUnitarioRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCostoPromUnitarioRefe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totCostoRefe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oCosto.totCostoRefe = oReader["totCostoRefe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totCostoRefe"]);

            return oCosto;
        }

        public List<CostoVentaE> ReporteCostoVentas(Int32 idEmpresa, int tipAlmacen, String tipoOperacion, DateTime fecIni, DateTime fecFin)
        {
            List<CostoVentaE> oLista = new List<CostoVentaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteCostoVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;
                    oComando.Parameters.Add("@tipoOperacion", SqlDbType.VarChar, 1).Value = tipoOperacion;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oLista.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oLista;
        }

        public Int32 GenerarAsientoCostoVentas(Int32 idEmpresa, Int32 idLocal, int tipAlmacen, String tipoOperacion, String RucEmpresa, DateTime fecIni, DateTime fecFin, String Usuario)
        {
            Int32 resp;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarAsientoCostoVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;
                    oComando.Parameters.Add("@tipoOperacion", SqlDbType.VarChar, 1).Value = tipoOperacion;
                    oComando.Parameters.Add("@RucEmpresa", SqlDbType.VarChar, 20).Value = RucEmpresa;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}
