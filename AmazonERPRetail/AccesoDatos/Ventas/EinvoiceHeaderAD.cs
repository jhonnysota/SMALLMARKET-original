using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class EinvoiceHeaderAD : DbConection
    {
        
        public EinvoiceHeaderE LlenarEntidad(IDataReader oReader)
        {
            EinvoiceHeaderE EinvoiceHeader = new EinvoiceHeaderE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numeroDocumentoAdquiriente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EinvoiceHeader.numeroDocumentoAdquiriente = oReader["numeroDocumentoAdquiriente"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numeroDocumentoAdquiriente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serienumero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EinvoiceHeader.serieNumero = oReader["serienumero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serienumero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EinvoiceHeader.tipoDocumento= oReader["tipoDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EinvoiceHeader.estado = oReader["estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["estado"]);

            return EinvoiceHeader;

        }

        public EinvoiceHeaderE ObtenerEinvoiceHeader(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            EinvoiceHeaderE EinvoiceHeader = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEinvoiceHeader", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            EinvoiceHeader = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return EinvoiceHeader;
        }

        public Int32 EliminarEinvoiceHeader(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEinvoiceHeader", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}
