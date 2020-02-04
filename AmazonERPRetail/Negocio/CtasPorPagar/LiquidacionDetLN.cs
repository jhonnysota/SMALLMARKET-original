using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;

namespace Negocio.CtasPorPagar
{
    public class LiquidacionDetLN
    {

        public LiquidacionDetE InsertarLiquidacionDet(LiquidacionDetE liquidaciondet)
        {
            try
            {
                return new LiquidacionDetAD().InsertarLiquidacionDet(liquidaciondet);
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

        public LiquidacionDetE ActualizarLiquidacionDet(LiquidacionDetE liquidaciondet)
        {
            try
            {
                return new LiquidacionDetAD().ActualizarLiquidacionDet(liquidaciondet);
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

        public int EliminarLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, Int32 idItem)
        {
            try
            {
                return new LiquidacionDetAD().EliminarLiquidacionDet(idEmpresa, idLocal, idLiquidacion, idItem);
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

        public List<LiquidacionDetE> ListarLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {
            try
            {
                return new LiquidacionDetAD().ListarLiquidacionDet(idEmpresa, idLocal, idLiquidacion);
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

        public LiquidacionDetE ObtenerLiquidacionDet(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, Int32 idItem)
        {
            try
            {
                return new LiquidacionDetAD().ObtenerLiquidacionDet(idEmpresa, idLocal, idLiquidacion, idItem);
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

        public List<LiquidacionDetE> LiquidacionRendicionCaja(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Tipo)
        {
            try
            {
                List<LiquidacionDetE> ListaLiquidacion = new LiquidacionDetAD().LiquidacionRendicionCaja(idEmpresa, idLocal, fecIni, fecFin, Tipo);
                List<LiquidacionDetE> ListaLiquidacionFinal = new List<LiquidacionDetE>();

                if (ListaLiquidacion != null && ListaLiquidacion.Count > 0)
                {
                    Int32 idLiquidacion = ListaLiquidacion[0].idLiquidacion;
                    Decimal impTotSoles = 0;
                    Decimal impTotDolares = 0;

                    foreach (LiquidacionDetE item in ListaLiquidacion)
                    {
                        if (item.idLiquidacion == idLiquidacion)
                        {
                            ListaLiquidacionFinal.Add(item);
                            impTotSoles += item.impSoles;
                            impTotDolares += item.impDolares;
                        }
                        else
                        {
                            LiquidacionDetE oDetalle = new LiquidacionDetE()
                            {
                                idLiquidacion = item.idLiquidacion,
                                Fecha = item.Fecha,
                                desAuxiliar = String.Empty,
                                Voucher = String.Empty,
                                FechaDocumento = (DateTime?)null,
                                idDocumento = String.Empty,
                                numSerie = String.Empty,
                                numDocumento = String.Empty,
                                TipoLiqui = String.Empty,
                                RazonSocial = "X",
                                Concepto = String.Empty,
                                Descripcion = String.Empty,
                                TipoCambio = 0,
                                impSoles = impTotSoles,
                                impDolares = impTotDolares
                            };

                            ListaLiquidacionFinal.Add(oDetalle);
                            ListaLiquidacionFinal.Add(item);
                            impTotSoles = 0;
                            impTotDolares = 0;
                            impTotSoles += item.impSoles;
                            impTotDolares += item.impDolares;
                        }

                        idLiquidacion = item.idLiquidacion;
                    }
                }

                return ListaLiquidacionFinal;
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

        public LiquidacionDetE LiquidacionDetPorDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new LiquidacionDetAD().LiquidacionDetPorDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public LiquidacionDetE ObtenerLiquidacionDetPorIdProvision(Int32 idProvision)
        {
            try
            {
                return new LiquidacionDetAD().ObtenerLiquidacionDetPorIdProvision(idProvision);
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
