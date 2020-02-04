using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CanjeGuiasAD : DbConection
    {
        
        public CanjeGuiasE LlenarEntidad(IDataReader oReader)
        {
            CanjeGuiasE canjeguias = new CanjeGuiasE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.idDocumentoFact = oReader["idDocumentoFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.numSerieFact = oReader["numSerieFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.numDocumentoFact = oReader["numDocumentoFact"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoGuia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.idDocumentoGuia = oReader["idDocumentoGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoGuia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieGuia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.numSerieGuia = oReader["numSerieGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieGuia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoGuia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjeguias.numDocumentoGuia = oReader["numDocumentoGuia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoGuia"]);

            //Extensiones

            return canjeguias;
        }

        public CanjeGuiasE InsertarCanjeGuias(CanjeGuiasE canjeguias)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCanjeGuias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = canjeguias.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = canjeguias.idLocal;
                    oComando.Parameters.Add("@idDocumentoFact", SqlDbType.VarChar, 2).Value = canjeguias.idDocumentoFact;
                    oComando.Parameters.Add("@numSerieFact", SqlDbType.VarChar, 20).Value = canjeguias.numSerieFact;
                    oComando.Parameters.Add("@numDocumentoFact", SqlDbType.VarChar, 20).Value = canjeguias.numDocumentoFact;
                    oComando.Parameters.Add("@idDocumentoGuia", SqlDbType.VarChar, 2).Value = canjeguias.idDocumentoGuia;
                    oComando.Parameters.Add("@numSerieGuia", SqlDbType.VarChar, 20).Value = canjeguias.numSerieGuia;
                    oComando.Parameters.Add("@numDocumentoGuia", SqlDbType.VarChar, 20).Value = canjeguias.numDocumentoGuia;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return canjeguias;
        }

        public Int32 EliminarCanjeGuias(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact, String idDocumentoGuia, String numSerieGuia, String numDocumentoGuia)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCanjeGuias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumentoFact", SqlDbType.VarChar, 2).Value = idDocumentoFact;
                    oComando.Parameters.Add("@numSerieFact", SqlDbType.VarChar, 20).Value = numSerieFact;
                    oComando.Parameters.Add("@numDocumentoFact", SqlDbType.VarChar, 20).Value = numDocumentoFact;
                    oComando.Parameters.Add("@idDocumentoGuia", SqlDbType.VarChar, 2).Value = idDocumentoGuia;
                    oComando.Parameters.Add("@numSerieGuia", SqlDbType.VarChar, 20).Value = numSerieGuia;
                    oComando.Parameters.Add("@numDocumentoGuia", SqlDbType.VarChar, 20).Value = numDocumentoGuia;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CanjeGuiasE> ObtenerCanjeGuias(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact)
        {
            List<CanjeGuiasE> ListaGuias = new List<CanjeGuiasE>();
            CanjeGuiasE canjeguias = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCanjeGuias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumentoFact", SqlDbType.VarChar, 2).Value = idDocumentoFact;
                    oComando.Parameters.Add("@numSerieFact", SqlDbType.VarChar, 20).Value = numSerieFact;
                    oComando.Parameters.Add("@numDocumentoFact", SqlDbType.VarChar, 20).Value = numDocumentoFact;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            canjeguias = LlenarEntidad(oReader);
                            ListaGuias.Add(canjeguias);
                        }
                    }
                }
            }

            return ListaGuias;
        }

        public Int32 EliminarCanjeGuiasPorFactura(Int32 idEmpresa, Int32 idLocal, String idDocumentoFact, String numSerieFact, String numDocumentoFact)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCanjeGuiasPorFactura", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumentoFact", SqlDbType.VarChar, 2).Value = idDocumentoFact;
                    oComando.Parameters.Add("@numSerieFact", SqlDbType.VarChar, 20).Value = numSerieFact;
                    oComando.Parameters.Add("@numDocumentoFact", SqlDbType.VarChar, 20).Value = numDocumentoFact;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CanjeGuiasE> ObtenerCanjeGuiasPorGuia(Int32 idEmpresa, Int32 idLocal, String idDocumentoGuia, String numSerieGuia, String numDocumentoGuia)
        {
            List<CanjeGuiasE> ListaGuias = new List<CanjeGuiasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCanjeGuiasPorGuia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumentoGuia", SqlDbType.VarChar, 2).Value = idDocumentoGuia;
                    oComando.Parameters.Add("@numSerieGuia", SqlDbType.VarChar, 20).Value = numSerieGuia;
                    oComando.Parameters.Add("@numDocumentoGuia", SqlDbType.VarChar, 20).Value = numDocumentoGuia;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaGuias.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaGuias;
        }

    }
}