using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using Infraestructura.Winform;

namespace Negocio.Contabilidad
{
    public class ComprasVariasLN
    {

        public ComprasVariasE InsertarComprasVarias(ComprasVariasE compras)
        {
            try
            {
                ComprasVariasE oDocumentoRevisado = new ComprasVariasAD().RevisarDocComprasVarias(compras.idEmpresa, compras.idLocal, compras.tipDocumento, compras.serDocumento, 
                                                                                                    compras.numDocumento, compras.idProveedor);
                //Provocando un error si en caso se haya ingresado el documento...
                if (oDocumentoRevisado != null)
                {
                    String Mes = Global.PrimeraMayuscula(FechasHelper.NombreMes(Convert.ToInt32(oDocumentoRevisado.MesPeriodo)));
                    throw new Exception(String.Format("El documento {0} {1}-{2} ya ha sido ingresado en el mes de {3}", compras.tipDocumento, compras.serDocumento, compras.numDocumento, Mes));
                }

                return new ComprasVariasAD().InsertarComprasVarias(compras);
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

        public ComprasVariasE ActualizarComprasVarias(ComprasVariasE compras, Boolean Revisar = false)
        {
            try
            {
                if (Revisar)
                {
                    ComprasVariasE oDocumentoRevisado = new ComprasVariasAD().RevisarDocComprasVarias(compras.idEmpresa, compras.idLocal, compras.tipDocumento, compras.serDocumento,
                                                                                                    compras.numDocumento, compras.idProveedor);
                    //Provocando un error si en caso se haya ingresado el documento...
                    if (oDocumentoRevisado != null)
                    {
                        String Mes = Global.PrimeraMayuscula(FechasHelper.NombreMes(Convert.ToInt32(oDocumentoRevisado.MesPeriodo)));
                        throw new Exception(String.Format("El documento {0} {1}-{2} ya ha sido ingresado en el mes de {3}", compras.tipDocumento, compras.serDocumento, compras.numDocumento, Mes));
                    }
                }

                return new ComprasVariasAD().ActualizarComprasVarias(compras);
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

        public List<ComprasVariasE> ListarComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo)
        {
            try
            {
                return new ComprasVariasAD().ListarComprasVarias(idEmpresa, idLocal, AnioPeriodo, MesPeriodo);
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

        public ComprasVariasE ObtenerComprasVariasPorId(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante)
        {
            try
            {
                return new ComprasVariasAD().ObtenerComprasVariasPorId(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, idComprobante);
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

        public int EliminarComprasVarias(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, Int32 idComprobante)
        {
            try
            {
                return new ComprasVariasAD().EliminarComprasVarias(idEmpresa, idLocal,AnioPeriodo, MesPeriodo, idComprobante);
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

        public List<ComprasVariasE> ListarReporteComprasVariasPorGrabacion(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String flagGravado)
        {
            try
            {
                return new ComprasVariasAD().ListarReporteComprasVariasPorGrabacion(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, flagGravado);
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
