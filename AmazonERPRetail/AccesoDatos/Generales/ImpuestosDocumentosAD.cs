using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ImpuestosDocumentosAD : DbConection
    {
     
        public ImpuestosDocumentosE LlenarEntidad(IDataReader oReader)
        {
            ImpuestosDocumentosE impuestosdocumentos = new ImpuestosDocumentosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosdocumentos.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosdocumentos.idImpuesto = oReader["idImpuesto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpuesto"]);
			
            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impuestosdocumentos.desImpuesto = oReader["desImpuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAbreviatura'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impuestosdocumentos.desAbreviatura = oReader["desAbreviatura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAbreviatura"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impuestosdocumentos.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            return  impuestosdocumentos;        
        }

        public ImpuestosDocumentosE InsertarImpuestosDocumentos(ImpuestosDocumentosE impuestosdocumentos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarImpuestosDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = impuestosdocumentos.idDocumento;
					oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = impuestosdocumentos.idImpuesto;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impuestosdocumentos;
        }

        public ImpuestosDocumentosE ActualizarImpuestosDocumentos(ImpuestosDocumentosE impuestosdocumentos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarImpuestosDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = impuestosdocumentos.idDocumento;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = impuestosdocumentos.idImpuesto;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impuestosdocumentos;
        }

        public Int32 EliminarImpuestosDocumentos(String idDocumento, Int32 idImpuesto)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpuestosDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImpuestosDocumentosE> ListarImpuestosDocumentos()
        {
           List<ImpuestosDocumentosE> listaEntidad = new List<ImpuestosDocumentosE>();
           ImpuestosDocumentosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpuestosDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public ImpuestosDocumentosE ObtenerImpuestosDocumentos(String idDocumento, Int32 idImpuesto)
        {        
            ImpuestosDocumentosE impuestosdocumentos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpuestosDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impuestosdocumentos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impuestosdocumentos;
        }

        public List<ImpuestosDocumentosE> ListarImpuestosPorIdDocumento(String idDocumento)
        {
            List<ImpuestosDocumentosE> listaEntidad = new List<ImpuestosDocumentosE>();
            ImpuestosDocumentosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpuestosPorIdDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

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

        public Int32 EliminarImpuestosDocumentosPorIdCocumento(String idDocumento)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpuestosDocumentosPorIdCocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}