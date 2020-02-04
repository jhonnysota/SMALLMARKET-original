using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Generales;
using AccesoDatos.Ventas;
using Entidades.Generales;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class DocumentosLN
    {

        public DocumentosE InsertarDocumentos(DocumentosE documentos)
        {
            try
            {
                return new DocumentosAD().InsertarDocumentos(documentos);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public DocumentosE ActualizarDocumentos(DocumentosE documentos)
        {
            try
            {
                return new DocumentosAD().ActualizarDocumentos(documentos);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public DocumentosE GrabarImpuestosDocumentos(DocumentosE documentos, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            documentos = new DocumentosAD().InsertarDocumentos(documentos);

                            if (documentos.ListaImpuestosDocumentos != null && documentos.ListaImpuestosDocumentos.Count > 0)
                            {
                                foreach (ImpuestosDocumentosE item in documentos.ListaImpuestosDocumentos)
                                {
                                    item.idDocumento = documentos.idDocumento;                                

                                    new ImpuestosDocumentosAD().InsertarImpuestosDocumentos(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            documentos = new DocumentosAD().ActualizarDocumentos(documentos);
                            Int32 resp = new ImpuestosDocumentosAD().EliminarImpuestosDocumentosPorIdCocumento(documentos.idDocumento);

                            if (documentos.ListaImpuestosDocumentos != null && documentos.ListaImpuestosDocumentos.Count > 0)
                            {
                                foreach (ImpuestosDocumentosE item in documentos.ListaImpuestosDocumentos)
                                {
                                    item.idDocumento = documentos.idDocumento;

                                            new ImpuestosDocumentosAD().InsertarImpuestosDocumentos(item);
                                           
                                }
                               
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return documentos;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public Int32 AnularActivarDocumento(String idDocumento, Boolean indBaja)
        {
            try
            {
                return new DocumentosAD().AnularActivarDocumento(idDocumento, indBaja);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break; 
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public DocumentosE ObtenerDocumentos(string idDocumento)
        {
            try
            {
                DocumentosE Documento = new DocumentosAD().ObtenerDocumentos(idDocumento);
                Documento.ListaImpuestosDocumentos = new ImpuestosDocumentosAD().ListarImpuestosPorIdDocumento(idDocumento);
                
                return Documento;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<DocumentosE> ListarDocumentosGeneral()
        {
            try
            {
                return new DocumentosAD().ListarDocumentosGeneral();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public List<DocumentosE> ListadoDeDocumentos(Boolean Activo, Boolean Inactivo)
        {
            try
            {
                return new DocumentosAD().ListadoDeDocumentos(Activo, Inactivo);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

    }
}
