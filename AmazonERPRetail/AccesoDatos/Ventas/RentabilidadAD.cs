using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class RentabilidadAD : DbConection
    {
        
        public RentabilidadE LlenarEntidad(IDataReader oReader)
        {
            RentabilidadE Rentabilidad = new RentabilidadE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.nomCategoria = oReader["nomCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUniProm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.PrecioUniProm = oReader["PrecioUniProm"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUniProm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.ValorVenta = oReader["ValorVenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ValorVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.TotalCosto = oReader["TotalCosto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Rentabilidad.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            return Rentabilidad;
        }

        public List<RentabilidadE> ListarReporteRentabilidadPorProducto(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda)
        {
            List<RentabilidadE> listaEntidad = new List<RentabilidadE>();
            RentabilidadE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteRentabilidadPorProducto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.VarChar, 8).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.VarChar, 8).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

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
