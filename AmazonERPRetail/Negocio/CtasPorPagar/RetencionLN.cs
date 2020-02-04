using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Ventas;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorPagar
{
    public class RetencionLN
    {

        public RetencionE GrabarRetencion(RetencionE Retencion, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            Retencion = new RetencionAD().InsertarRetencion(Retencion);
                            
                            if (Retencion.ListaRetencionItem != null && Retencion.ListaRetencionItem.Count > 0)
                            {
                                foreach (RetencionItemE item in Retencion.ListaRetencionItem)
                                {
                                    item.idEmpresa = Retencion.idEmpresa;
                                    item.idLocal = Retencion.idLocal;
                                    item.serieCompRete = Retencion.serieCompRete;
                                    item.numeroCompRete = Retencion.numeroCompRete;

                                    new RetencionItemAD().InsertarRetencionItem(item);
                                }
                            }

                            //Actualizando Correlativo del documento en numControlDet
                            new NumControlDetAD().ActualizarCorrelativoNumControlDetRet(Retencion.idEmpresa, Retencion.idLocal, "RT", Retencion.serieCompRete, Retencion.numeroCompRete);

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            Retencion = new RetencionAD().ActualizarRetencion(Retencion);

                            if (Retencion.ListaRetencionItem != null )
                            {
                                foreach (RetencionItemE item in Retencion.ListaRetencionItem)
                                {
                                    item.idEmpresa = Retencion.idEmpresa;
                                    item.idLocal = Retencion.idLocal;
                                    item.serieCompRete = Retencion.serieCompRete;
                                    item.numeroCompRete = Retencion.numeroCompRete;

                                    switch (item.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new RetencionItemAD().InsertarRetencionItem(item);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new RetencionItemAD().ActualizarRetencionItem(item);
                                            break;
                                        case (int)EnumOpcionGrabar.Eliminar:
                                            new RetencionItemAD().EliminarRetencionItem(item.idEmpresa, item.idLocal, item.serieCompRete, item.numeroCompRete, item.Item);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return Retencion;
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
        
        public List<RetencionE> ListarRetencion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona , DateTime fecIni , DateTime fecFin)
        {
            try
            {
                return new RetencionAD().ListarRetencion(idEmpresa, idLocal,idPersona,fecIni,fecFin);
            
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

        public RetencionE ObtenerRetencionCompleta(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            try
            {
                //Cabecera
                RetencionE numControl = new RetencionAD().ObtenerRetencion(idEmpresa, idLocal, serieCompRete,numeroCompRete);

                //Detalle
                numControl.ListaRetencionItem = new RetencionItemAD().ListarRetencionItem(idEmpresa, idLocal, serieCompRete, numeroCompRete);

                return numControl;
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

        public int EliminarRetencion(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            try
            {
                return new RetencionAD().EliminarRetencion(idEmpresa, idLocal, serieCompRete, numeroCompRete);
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

        public String ObtenerUltimoNroCorrelativoRetencion(Int32 idEmpresa, String serieCompRete)
        {
            try
            {
                return new RetencionAD().ObtenerUltimoNroCorrelativoRetencion(idEmpresa, serieCompRete);
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

        public List<RetencionE> ListarReporteRetenciones(Int32 idEmpresa, Int32 idLocal, String serieCompRete, String numeroCompRete)
        {
            try
            {
                return new RetencionAD().ListarReporteRetenciones(idEmpresa, idLocal, serieCompRete, numeroCompRete);
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
        
        public List<RetencionE> LibroRetencionLe(Int32 idEmpresa, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new RetencionAD().LibroRetencionLe(idEmpresa, fecIni, fecFin);
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
        
        public List<RetencionE> LibroRetenciones(Int32 idEmpresa, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new RetencionAD().LibroRetenciones(idEmpresa, fecIni, fecFin);
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

        public Int32 GeneraAsientoRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete)
        {
            try
            {
                return new RetencionAD().GeneraAsientoRetencion(idEmpresa, idLocal, serieCompRete, numeroCompRete);
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

        public Int32 EliminaAsientoRetencion(Int32 idEmpresa, Int32 @idLocal, String @serieCompRete, String @numeroCompRete)
        {
            try
            {
                return new RetencionAD().EliminaAsientoRetencion(idEmpresa, idLocal, serieCompRete, numeroCompRete);
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

        public int ProcesarMigrarRetencion(String Cod_empresa, String Anno_periodo, String Mes_periodo, Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new RetencionAD().ProcesarMigrarRetencion(Cod_empresa, Anno_periodo, Mes_periodo, idEmpresa, idLocal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
