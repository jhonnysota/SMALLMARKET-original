using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class InventarioBalanceAD : DbConection
    {

        public InventarioBalanceE LlenarEntidad(IDataReader oReader)
        {
            InventarioBalanceE compras = new InventarioBalanceE();


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Periodo = oReader["Periodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Periodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codigoBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.codigoBanco = oReader["codigoBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codigoBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='num_cuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.num_cuenta = oReader["num_cuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["num_cuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codigoMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.codigoMoneda = oReader["codigoMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codigoMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='debe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.debe = oReader["debe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["debe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='haber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.haber = oReader["haber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["haber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            return compras;
        }


        public List<InventarioBalanceE> ReporteInventarioBalance(Int32 idEmpresa, Int32 idLocal, String ANO_PERIODO, String COD_PERIODO, String VERSION, String COD_CUENTA)
        {
            List<InventarioBalanceE> listaEntidad = new List<InventarioBalanceE>();
            InventarioBalanceE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InventarioBalanceCtaSaldo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@ANO_PERIODO", SqlDbType.VarChar, 4).Value = ANO_PERIODO;
                    oComando.Parameters.Add("@COD_PERIODO", SqlDbType.VarChar, 2).Value = COD_PERIODO;
                    oComando.Parameters.Add("@VERSION", SqlDbType.VarChar, 3).Value = VERSION;
                    oComando.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar, 20).Value = COD_CUENTA;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

    }
}
