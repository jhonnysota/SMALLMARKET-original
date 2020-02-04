using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class InventarioBalance21AD : DbConection
    {
        
        public   InventarioBalanceCteE21 LlenarEntidad(IDataReader oReader)
        {
            InventarioBalanceCteE21 compras = new InventarioBalanceCteE21();

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

           
            return compras;



        }


        public List<InventarioBalanceCteE21> ReporteInventarioBalance21(int idEmpresa, Int32 idLocal, String ANO_PERIODO, String COD_PERIODO, String VERSION, String COD_CUENTA)
        {
            List<InventarioBalanceCteE21> listaEntidad = new List<InventarioBalanceCteE21>();
            InventarioBalanceCteE21 entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InventarioBalanceCtaSaldo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.AddWithValue("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.AddWithValue("@ANO_PERIODO", SqlDbType.VarChar).Value = ANO_PERIODO;
                    oComando.Parameters.AddWithValue("@COD_PERIODO", SqlDbType.VarChar).Value = COD_PERIODO;
                    oComando.Parameters.AddWithValue("@VERSION", SqlDbType.VarChar).Value = VERSION;
                    oComando.Parameters.AddWithValue("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CUENTA;

                    oConexion.Open();

                    using(SqlDataReader oReader = oComando.ExecuteReader())
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
