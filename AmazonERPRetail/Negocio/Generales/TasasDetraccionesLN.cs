using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Generales;
using AccesoDatos.Generales;
using Infraestructura.Enumerados;

namespace Negocio.Generales
{
    public class TasasDetraccionesLN
    {

        public TasasDetraccionesE InsertarTasasDetracciones(TasasDetraccionesE tasasdetracciones)
        {
            try
            {
                return new TasasDetraccionesAD().InsertarTasasDetracciones(tasasdetracciones);
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

        public TasasDetraccionesE ActualizarTasasDetracciones(TasasDetraccionesE tasasdetracciones)
        {
            try
            {
                return new TasasDetraccionesAD().ActualizarTasasDetracciones(tasasdetracciones);
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

        public Int32 EliminarTasasDetracciones(String idTipoDetraccion)
        {
            try
            {
                return new TasasDetraccionesAD().EliminarTasasDetracciones(idTipoDetraccion);
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

        public List<TasasDetraccionesE> ListarTasasDetracciones()
        {
            try
            {
                return new TasasDetraccionesAD().ListarTasasDetracciones();
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

        public TasasDetraccionesE ObtenerTasasDetracciones(String idTipoDetraccion)
        {
            try
            {
                return new TasasDetraccionesAD().ObtenerTasasDetracciones(idTipoDetraccion);
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

        public List<TasasDetraccionesE> ListarDetraccionesCabActivas()
        {
            try
            {
                return new TasasDetraccionesAD().ListarDetraccionesCabActivas();
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

        public TasasDetraccionesE GrabarTasasDetracciones(TasasDetraccionesE tasasdetra, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            tasasdetra = new TasasDetraccionesAD().InsertarTasasDetracciones(tasasdetra);

                            if (tasasdetra.listaDetraccionesDetalle != null && tasasdetra.listaDetraccionesDetalle.Count > 0)
                            {
                                foreach (TasasDetraccionesDetalleE item in tasasdetra.listaDetraccionesDetalle)
                                {
                                    item.idTipoDetraccion = tasasdetra.idTipoDetraccion;
                                    new TasasDetraccionesDetalleAD().InsertarTasasDetraccionesDetalle(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            tasasdetra = new TasasDetraccionesAD().ActualizarTasasDetracciones(tasasdetra);


                            if (tasasdetra.ListaDetalleEliminados != null)
                            {
                                foreach (TasasDetraccionesDetalleE oitem in tasasdetra.ListaDetalleEliminados)
                                {
                                    new TasasDetraccionesDetalleAD().EliminarTasasDetraccionesDetalle(oitem.idTipoDetraccion, oitem.item);
                                }
                            }

                            if (tasasdetra.listaDetraccionesDetalle != null && tasasdetra.listaDetraccionesDetalle.Count > 0)
                            {                                
                                foreach (TasasDetraccionesDetalleE item in tasasdetra.listaDetraccionesDetalle)
                                {

                                    item.idTipoDetraccion = tasasdetra.idTipoDetraccion;

                                    switch (item.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new TasasDetraccionesDetalleAD().InsertarTasasDetraccionesDetalle(item);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new TasasDetraccionesDetalleAD().ActualizarTasasDetraccionesDetalle(item);
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

                return tasasdetra;
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

        public TasasDetraccionesE ObtenerTasasDetraccionesCompleto(String idTipoDetraccion)
        {
            try
            {
                //Cabecera
                TasasDetraccionesE Tasasdetracciones = new TasasDetraccionesAD().ObtenerTasasDetracciones(idTipoDetraccion);

                //Detalle
                Tasasdetracciones.listaDetraccionesDetalle = new TasasDetraccionesDetalleAD().ListarTasasDetraccionesDetalle(idTipoDetraccion);

                return Tasasdetracciones;
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
