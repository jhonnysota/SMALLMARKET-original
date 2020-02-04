using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class DocumentosAD : DbConection
    {

        public DocumentosE LlenarEntidad(IDataReader oReader)
        {
            DocumentosE documentos = new DocumentosE();
            documentos.idDocumento = Convert.ToString(oReader["idDocumento"]);  
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCorta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.desCorta = oReader["desCorta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCorta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.CodigoSunat = oReader["CodigoSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodigoSunat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.indBaja = oReader["indBaja"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.fecBaja = oReader["fecBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codMedioPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.codMedioPago = oReader["codMedioPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codMedioPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indFecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indFecVencimiento = oReader["indFecVencimiento"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indFecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indReferencia = oReader["indReferencia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsReferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.EsReferencia = oReader["EsReferencia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsReferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocumentoVentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indDocumentoVentas = oReader["indDocumentoVentas"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocumentoVentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indRecepcionDcmto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indRecepcionDcmto = oReader["indRecepcionDcmto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indRecepcionDcmto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAduanera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indAduanera = oReader["indAduanera"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAduanera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='depAduanera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.depAduanera = oReader["depAduanera"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["depAduanera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocumentoCompras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indDocumentoCompras = oReader["indDocumentoCompras"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocumentoCompras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocNoDom'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indDocNoDom = oReader["indDocNoDom"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocNoDom"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCreditoFiscal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indCreditoFiscal = oReader["indCreditoFiscal"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCreditoFiscal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTesoreria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indTesoreria = oReader["indTesoreria"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTesoreria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indViaticos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indViaticos = oReader["indViaticos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indViaticos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                documentos.indAlmacen = oReader["indAlmacen"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				documentos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);            

            return  documentos;        
        }

        public DocumentosE InsertarDocumentos(DocumentosE documentos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = documentos.idDocumento;
					oComando.Parameters.Add("@desDocumento", SqlDbType.VarChar, 50).Value = documentos.desDocumento;
					oComando.Parameters.Add("@desCorta", SqlDbType.VarChar, 10).Value = documentos.desCorta;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = documentos.indDebeHaber;
					oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 2).Value = documentos.CodigoSunat;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = documentos.codMedioPago;
                    oComando.Parameters.Add("@indFecVencimiento", SqlDbType.Bit).Value = documentos.indFecVencimiento;
                    oComando.Parameters.Add("@indReferencia", SqlDbType.Bit).Value = documentos.indReferencia;
                    oComando.Parameters.Add("@EsReferencia", SqlDbType.Bit).Value = documentos.EsReferencia;
                    oComando.Parameters.Add("@indDocumentoVentas", SqlDbType.Bit).Value = documentos.indDocumentoVentas;
                    oComando.Parameters.Add("@indRecepcionDcmto", SqlDbType.Bit).Value = documentos.indRecepcionDcmto;
                    oComando.Parameters.Add("@indAduanera", SqlDbType.Bit).Value = documentos.indAduanera;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = documentos.depAduanera;
                    oComando.Parameters.Add("@indDocumentoCompras", SqlDbType.Bit).Value = documentos.indDocumentoCompras;
                    oComando.Parameters.Add("@indDocNoDom", SqlDbType.Bit).Value = documentos.indDocNoDom;
                    oComando.Parameters.Add("@indCreditoFiscal", SqlDbType.Bit).Value = documentos.indCreditoFiscal;
                    oComando.Parameters.Add("@indTesoreria", SqlDbType.Bit).Value = documentos.indTesoreria;
                    oComando.Parameters.Add("@indViaticos", SqlDbType.Bit).Value = documentos.indViaticos;
                    oComando.Parameters.Add("@indAlmacen", SqlDbType.Bit).Value = documentos.indAlmacen;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = documentos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return documentos;        
        }
        
        public DocumentosE ActualizarDocumentos(DocumentosE documentos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = documentos.idDocumento;
					oComando.Parameters.Add("@desDocumento", SqlDbType.VarChar, 50).Value = documentos.desDocumento;
					oComando.Parameters.Add("@desCorta", SqlDbType.VarChar, 10).Value = documentos.desCorta;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = documentos.indDebeHaber;
					oComando.Parameters.Add("@CodigoSunat", SqlDbType.VarChar, 2).Value = documentos.CodigoSunat;
                    oComando.Parameters.Add("@codMedioPago", SqlDbType.Int).Value = documentos.codMedioPago;
                    oComando.Parameters.Add("@indFecVencimiento", SqlDbType.Bit).Value = documentos.indFecVencimiento;
                    oComando.Parameters.Add("@indReferencia", SqlDbType.Bit).Value = documentos.indReferencia;
                    oComando.Parameters.Add("@EsReferencia", SqlDbType.Bit).Value = documentos.EsReferencia;
                    oComando.Parameters.Add("@indDocumentoVentas", SqlDbType.Bit).Value = documentos.indDocumentoVentas;
                    oComando.Parameters.Add("@indRecepcionDcmto", SqlDbType.Bit).Value = documentos.indRecepcionDcmto;
                    oComando.Parameters.Add("@indAduanera", SqlDbType.Bit).Value = documentos.indAduanera;
                    oComando.Parameters.Add("@depAduanera", SqlDbType.Int).Value = documentos.depAduanera;
                    oComando.Parameters.Add("@indDocumentoCompras", SqlDbType.Bit).Value = documentos.indDocumentoCompras;
                    oComando.Parameters.Add("@indDocNoDom", SqlDbType.Bit).Value = documentos.indDocNoDom;
                    oComando.Parameters.Add("@indCreditoFiscal", SqlDbType.Bit).Value = documentos.indCreditoFiscal;
                    oComando.Parameters.Add("@indTesoreria", SqlDbType.Bit).Value = documentos.indTesoreria;
                    oComando.Parameters.Add("@indViaticos", SqlDbType.Bit).Value = documentos.indViaticos;
                    oComando.Parameters.Add("@indAlmacen", SqlDbType.Bit).Value = documentos.indAlmacen;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = documentos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return documentos;
        }

        public Int32 AnularActivarDocumento(String idDocumento, Boolean indBaja)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularActivarDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = indBaja;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }
        
        public DocumentosE ObtenerDocumentos(String idDocumento)
        {        
            DocumentosE documentos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            documentos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return documentos;        
        }

        public List<DocumentosE> ListarDocumentosGeneral()
        {
            List<DocumentosE> listaDocumentos = new List<DocumentosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDocumentosGeneral", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaDocumentos;
        }

        public List<DocumentosE> ListadoDeDocumentos(Boolean Activo, Boolean Inactivo)
        {
            List<DocumentosE> listaDocumentos = new List<DocumentosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListadoDeDocumentos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
                    oComando.Parameters.Add("@Inactivo", SqlDbType.Bit).Value = Inactivo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaDocumentos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaDocumentos;
        }

    }
}