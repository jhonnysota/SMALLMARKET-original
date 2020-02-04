using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ErrorImportacionAD : DbConection
    {

        public ErrorImportacionE LlenarEntidad(IDataReader oReader)
        {
            ErrorImportacionE requisicion = new ErrorImportacionE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Archivo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.Archivo = oReader["Archivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Archivo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Linea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.Linea = oReader["Linea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Linea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCampo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.NombreCampo = oReader["NombreCampo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCampo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorCampo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.ValorCampo = oReader["ValorCampo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ValorCampo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mensaje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                requisicion.Mensaje = oReader["Mensaje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mensaje"]);

            return requisicion;
        }

        public List<ErrorImportacionE> ListarErrorImportacion(Int32 idEmpresa, String Archivo)
        {
            List<ErrorImportacionE> listaEntidad = new List<ErrorImportacionE>();
            ErrorImportacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarErrores", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Archivo", SqlDbType.VarChar, 20).Value = Archivo;

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
