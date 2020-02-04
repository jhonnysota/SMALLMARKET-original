using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorPagar
{
    public class MovilidadLN
    {

        public MovilidadE GrabarMovilidad(MovilidadE Mov, EnumOpcionGrabar Opcion)
        {
            try
            {
                if (Opcion == EnumOpcionGrabar.Insertar)
                {
                    //Insertando el articulo
                    Mov = new MovilidadAD().InsertarMovilidad(Mov);

                    //Insertando detalle si hubiera
                    if (Mov.ListaMovilidadDet != null && Mov.ListaMovilidadDet.Count > 0)
                    {
                        foreach (MovilidadDetE oitem in Mov.ListaMovilidadDet)
                        {
                            oitem.idMovilidad = Mov.idMovilidad;
                            new MovilidadDetAD().InsertarMovilidadDet(oitem);
                        }
                    }    
                }
                else
                {
                    //Actualizando el articulo
                    new MovilidadAD().ActualizarMovilidad(Mov);

                    //Actualizando detalle si hubiera
                    if (Mov.ListaMovilidadEliminados != null)
                    {
                        foreach (MovilidadDetE oitem in Mov.ListaMovilidadEliminados)
                        {
                            new MovilidadDetAD().EliminarMovilidadDet(oitem.idEmpresa, oitem.idLocal, oitem.idMovilidad, oitem.idItem);
                        }
                    }

                    //Actualizando detalle si hubiera
                    if (Mov.ListaMovilidadDet != null)
                    {
                        foreach (MovilidadDetE oitem in Mov.ListaMovilidadDet)
                        {
                            oitem.idMovilidad = Mov.idMovilidad;

                            switch (oitem.Opcion)
                            {
                                case (Int32)EnumOpcionGrabar.Insertar:
                                    new MovilidadDetAD().InsertarMovilidadDet(oitem);
                                    break;
                                case (Int32)EnumOpcionGrabar.Actualizar:
                                    new MovilidadDetAD().ActualizarMovilidadDet(oitem);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                return Mov;
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

        public MovilidadE InsertarMovilidad(MovilidadE movilidad)
        {
            try
            {
                return new MovilidadAD().InsertarMovilidad(movilidad);
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

        public MovilidadE ActualizarMovilidad(MovilidadE movilidad)
        {
            try
            {
                return new MovilidadAD().ActualizarMovilidad(movilidad);
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

        public int EliminarMovilidad(Int32 idMovilidad)
        {
            try
            {
                return new MovilidadAD().EliminarMovilidad(idMovilidad);
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

        public List<MovilidadE> ListarMovilidad(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new MovilidadAD().ListarMovilidad(idEmpresa, idLocal);
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

        public MovilidadE ObtenerMovilidad(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad)
        {
            try
            {
                return new MovilidadAD().ObtenerMovilidad(idEmpresa, idLocal, idMovilidad);
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

        public MovilidadE ObtenerMovilidadCompleta(Int32 idEmpresa, Int32 idLocal, Int32 idMovilidad)
        {
            try
            {
                MovilidadE OrdenPago = new MovilidadAD().ObtenerMovilidad(idEmpresa, idLocal, idMovilidad);
                OrdenPago.ListaMovilidadDet = new MovilidadDetAD().ListarMovilidadDet(idEmpresa, idLocal, idMovilidad);

                return OrdenPago;
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

        public int ActualizarEstadoMovi(Int32 idMovilidad, Boolean indEstado, String UsuarioModificacion)
        {
            try
            {
                return new MovilidadAD().ActualizarEstadoMovi(idMovilidad, indEstado, UsuarioModificacion);
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

        public List<MovilidadE> ListarMovilidadPendientes(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new MovilidadAD().ListarMovilidadPendientes(idEmpresa, idLocal);
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
