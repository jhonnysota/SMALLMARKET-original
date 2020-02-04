using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class EmisionDocumentoExportaAD : DbConection
    {
        
        public EmisionDocumentoExportaE LlenarEntidad(IDataReader oReader)
        {
            EmisionDocumentoExportaE emisiondocumentoexporta = new EmisionDocumentoExportaE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.Item = oReader["Item"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Concepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.Concepto = oReader["Concepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Concepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                emisiondocumentoexporta.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);


            return emisiondocumentoexporta;
        }

        public EmisionDocumentoExportaE InsertarEmisionDocumentoExporta(EmisionDocumentoExportaE emisiondocumentoexporta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmisionDocumentoExporta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentoexporta.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentoexporta.idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentoexporta.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentoexporta.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentoexporta.numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentoexporta.Item;
                    oComando.Parameters.Add("@Concepto", SqlDbType.Char, 2).Value = emisiondocumentoexporta.Concepto;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = emisiondocumentoexporta.Descripcion;
                    oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = emisiondocumentoexporta.Importe;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentoexporta;
        }

        //public EmisionDocumentoExportaE ActualizarEmisionDocumentoExporta(EmisionDocumentoExportaE emisiondocumentoexporta)
        //{
        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumentoExporta", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;

        //            oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentoexporta.idEmpresa;
        //            oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentoexporta.idLocal;
        //            oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentoexporta.idDocumento;
        //            oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentoexporta.numSerie;
        //            oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentoexporta.numDocumento;
        //            oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = emisiondocumentoexporta.Item;
        //            oComando.Parameters.Add("@Concepto", SqlDbType.Char, 2).Value = emisiondocumentoexporta.Concepto;
        //            oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = emisiondocumentoexporta.Descripcion;
        //            oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = emisiondocumentoexporta.Importe;

        //            oConexion.Open();
        //            oComando.ExecuteNonQuery();
        //            oConexion.Close();
        //        }
        //    }

        //    return emisiondocumentoexporta;
        //}

        public int EliminarEmisionDocumentoExporta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmisionDocumentoExporta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@Item", SqlDbType.VarChar, 3).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        //public List<EmisionDocumentoExportaE> ListarEmisionDocumentoExporta()
        //{
        //    List<EmisionDocumentoExportaE> listaEntidad = new List<EmisionDocumentoExportaE>();
        //    EmisionDocumentoExportaE entidad = null;

        //    using (SqlConnection oConexion = ConexionSql())
        //    {
        //        using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmisionDocumentoExporta", oConexion))
        //        {
        //            oComando.CommandType = CommandType.StoredProcedure;
        //            oConexion.Open();

        //            using (SqlDataReader oReader = oComando.ExecuteReader())
        //            {
        //                while (oReader.Read())
        //                {
        //                    entidad = LlenarEntidad(oReader);
        //                    listaEntidad.Add(entidad);
        //                }
        //            }
        //        }

        //        oConexion.Close();
        //    }

        //    return listaEntidad;
        //}

        public List<EmisionDocumentoExportaE> ObtenerEmisionDocumentoExporta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            List<EmisionDocumentoExportaE> ListaGastos = new List<EmisionDocumentoExportaE>();
            EmisionDocumentoExportaE emisiondocumentoexporta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoExporta", oConexion))
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
                            emisiondocumentoexporta = LlenarEntidad(oReader);
                            ListaGastos.Add(emisiondocumentoexporta);
                        }
                    }
                }
            }

            return ListaGastos;
        }

    }
}