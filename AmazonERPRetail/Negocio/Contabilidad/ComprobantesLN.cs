using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class ComprobantesLN
    {
        public ComprobantesE GrabarTipoComprobante(ComprobantesE TipoComprobante, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {   
                    if (OpcionGrabar == EnumOpcionGrabar.Insertar)
                    {
                        TipoComprobante = new ComprobantesAD().InsertarComprobantes(TipoComprobante);

                        if (TipoComprobante.ListaComprobantesFiles != null)
                        {
                            foreach (ComprobantesFileE item in TipoComprobante.ListaComprobantesFiles)
                            {
                                item.idEmpresa = TipoComprobante.idEmpresa;
                                item.idComprobante = TipoComprobante.idComprobante;

                                new ComprobantesFileAD().InsertarComprobantesFile(item);
                            }
                        }
                    }
                    else
                    {
                        TipoComprobante = new ComprobantesAD().ActualizarComprobantes(TipoComprobante);

                        if (TipoComprobante.ListaComprobantesFiles != null)
                        {
                            foreach (ComprobantesFileE item in TipoComprobante.ListaComprobantesFiles)
                            {
                                item.idEmpresa = TipoComprobante.idEmpresa;
                                item.idComprobante = TipoComprobante.idComprobante;

                                switch (item.Opcion)
                                {
                                    case (Int32)EnumOpcionGrabar.Insertar:
                                        new ComprobantesFileAD().InsertarComprobantesFile(item);
                                        break;
                                    case (Int32)EnumOpcionGrabar.Actualizar:
                                        new ComprobantesFileAD().ActualizarComprobantesFile(item);
                                        break;
                                    case (Int32)EnumOpcionGrabar.Eliminar:
                                        new ComprobantesFileAD().EliminarComprobantesFile(item.idEmpresa, item.idComprobante, item.numFile);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return TipoComprobante;
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

        public ComprobantesE InsertarComprobantes(ComprobantesE comprobantese)
        {
            try
            {
                return new ComprobantesAD().InsertarComprobantes(comprobantese);
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

        public ComprobantesE ActualizarComprobantes(ComprobantesE comprobantese)
        {
            try
            {
                return new ComprobantesAD().ActualizarComprobantes(comprobantese);
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

        public String EliminarComprobantes(Int32 idEmpresa,String idComprobante)
        {
            try
            {
                return new ComprobantesAD().EliminarComprobantes(idEmpresa,idComprobante);
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

        public List<ComprobantesE> ListarComprobantes(Int32 idEmpresa)
        {
            try
            {
                return new ComprobantesAD().ListarComprobantes(idEmpresa);
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

        public ComprobantesE ObtenerTipoComprobante(Int32 idEmpresa, String idComprobante)
        {
            try
            {
                //Comprobantes (cabecera)
                ComprobantesE TipoComprobante = new ComprobantesAD().ObtenerComprobantePorId(idEmpresa, idComprobante);
                //Files (detalle)
                TipoComprobante.ListaComprobantesFiles = new ComprobantesFileAD().ObtenerFilesPorIdComprobante(idEmpresa, idComprobante);

                return TipoComprobante;
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

        public List<ComprobantesE> ListarComprobantesGeneral(Int32 idEmpresa)
        {
            try
            {
                //Comprobantes (cabecera)
                List<ComprobantesE> ListaComprobante = new ComprobantesAD().ListarComprobantes(idEmpresa);
                //Files (detalle)
                foreach (ComprobantesE item in ListaComprobante)
                {
                    item.ListaComprobantesFiles = new ComprobantesFileAD().ObtenerFilesPorIdComprobante(idEmpresa, item.idComprobante);
                }

                return ListaComprobante;
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
