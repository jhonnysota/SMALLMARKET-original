using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PublicidadAD : DbConection
    {

        public PublicidadE LlenarEntidad(IDataReader oReader)
        {
            PublicidadE compras = new PublicidadE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.TipoCuenta = oReader["TipoCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Fecha = oReader["Fecha"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Documento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Documento = oReader["Documento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Documento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Dolar = oReader["Dolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Dolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Soles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                compras.Soles = oReader["Soles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Soles"]);
            

            return compras;
        }






        public List<PublicidadE> ListarReportePublicidad(Int32 idEmpresa, DateTime fecha)
        {
            List<PublicidadE> listaEntidad = new List<PublicidadE>();
            PublicidadE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReportePublicidadPendiente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;



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

                oConexion.Close();
            }

            return listaEntidad;
        }
    }
}
