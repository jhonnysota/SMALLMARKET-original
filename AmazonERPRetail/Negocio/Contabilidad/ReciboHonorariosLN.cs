using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using AccesoDatos.Almacen;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class ReciboHonorariosLN 
    {

        public ReciboHonorariosE GrabarReciboHonorarios(ReciboHonorariosE ListaReciboHonorarios, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando 
                            new ReciboHonorariosAD().ActualizarReciboHonorarios(ListaReciboHonorarios);

                            //Detalle 
                            if (ListaReciboHonorarios.oListaRecibos != null && ListaReciboHonorarios.oListaRecibos.Count > 0)
                            {
                                foreach (ReciboHonorariosDetE oitem in ListaReciboHonorarios.oListaRecibos)
                                {
                                    oitem.idReciboHonorarios = ListaReciboHonorarios.idReciboHonorarios;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:

                                            new ReciboHonorariosDetAD().InsertarReciboHonorariosDet(oitem);

                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:

                                            new ReciboHonorariosDetAD().ActualizarReciboHonorariosDet(oitem);

                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:

                                            new ReciboHonorariosDetAD().EliminarReciboHonorariosDet(oitem.idEmpresa, oitem.idLocal, oitem.idReciboHonorarios, oitem.idReciboHonorariosDet);

                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando 
                            ListaReciboHonorarios = new ReciboHonorariosAD().InsertarReciboHonorarios(ListaReciboHonorarios);

                            //Lista 
                            if (ListaReciboHonorarios.oListaRecibos != null && ListaReciboHonorarios.oListaRecibos.Count > 0)
                            {
                                foreach (ReciboHonorariosDetE oitem in ListaReciboHonorarios.oListaRecibos)
                                {
                                    oitem.idReciboHonorarios = ListaReciboHonorarios.idReciboHonorarios;
                                    new ReciboHonorariosDetAD().InsertarReciboHonorariosDet(oitem);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return ListaReciboHonorarios;
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

        public ReciboHonorariosE InsertarReciboHonorarios(ReciboHonorariosE recibohonorarios)
        {
            try
            {
                return new ReciboHonorariosAD().InsertarReciboHonorarios(recibohonorarios);
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

        public ReciboHonorariosE ActualizarReciboHonorarios(ReciboHonorariosE recibohonorarios)
        {
            try
            {
                return new ReciboHonorariosAD().ActualizarReciboHonorarios(recibohonorarios);
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

        public int EliminarReciboHonorarios(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios)
        {
            try
            {
                return new ReciboHonorariosAD().EliminarReciboHonorarios(idEmpresa, idLocal, idReciboHonorarios);
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

        public List<ReciboHonorariosE> ListarReciboHonorarios(Int32 idEmpresa, Int32 idLocal, String Anio, String mes, String RazonSocial, String Tipo)
        {
            try
            {
                return new ReciboHonorariosAD().ListarReciboHonorarios(idEmpresa, idLocal, Anio, mes, RazonSocial, Tipo);
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

        public ReciboHonorariosE ObtenerReciboHonorarios(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, String ConDetalle = "S")
        {
            try
            {
                ReciboHonorariosE Rh = new ReciboHonorariosAD().ObtenerReciboHonorarios(idEmpresa, idLocal, idReciboHonorarios);

                if (Rh != null && ConDetalle == "S")
                {
                    Rh.oListaRecibos = new ReciboHonorariosDetAD().ListarReciboHonorariosDet(idEmpresa, idLocal, idReciboHonorarios);

                    if (Rh.oListaRecibos.Count > 0)
                    {
                        foreach (ReciboHonorariosDetE item in Rh.oListaRecibos)
                        {
                            if (item.idConcepto.Value > 0)
                            {
                                item.oConcepto = new ConceptosVariosAD().RecuperarConceptosVarios(item.idConcepto.Value, idEmpresa, false); 
                            }
                        }
                    }
                }

                return Rh;
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
