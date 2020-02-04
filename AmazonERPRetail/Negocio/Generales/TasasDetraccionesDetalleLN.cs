using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Generales;

namespace Negocio.Generales
{
    public class TasasDetraccionesDetalleLN 
    {

        public TasasDetraccionesDetalleE InsertarTasasDetraccionesDetalle(TasasDetraccionesDetalleE tasasdetraccionesdetalle)
        {
            try
            {
                return new TasasDetraccionesDetalleAD().InsertarTasasDetraccionesDetalle(tasasdetraccionesdetalle);
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

        public TasasDetraccionesDetalleE ActualizarTasasDetraccionesDetalle(TasasDetraccionesDetalleE tasasdetraccionesdetalle)
        {
            try
            {
                return new TasasDetraccionesDetalleAD().ActualizarTasasDetraccionesDetalle(tasasdetraccionesdetalle);
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

        public int EliminarTasasDetraccionesDetalle(String idTipoDetraccion, Int32 item)
        {
            try
            {
                return new TasasDetraccionesDetalleAD().EliminarTasasDetraccionesDetalle(idTipoDetraccion, item);
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

        public List<TasasDetraccionesDetalleE> ListarTasasDetraccionesDetalle(String idTipoDetraccion)
        {
            try
            {
                return new TasasDetraccionesDetalleAD().ListarTasasDetraccionesDetalle(idTipoDetraccion);
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

        public TasasDetraccionesDetalleE ObtenerTasasDetraccionesDetalle(String idTipoDetraccion, Int32 item)
        {
            try
            {
                return new TasasDetraccionesDetalleAD().ObtenerTasasDetraccionesDetalle(idTipoDetraccion, item);
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

        public List<TasasDetraccionesDetalleE> ListarDetraccionesDetActivas(DateTime fecDetraccion, String idTipoDetraccion = "%")
        {
            try
            {
                return new TasasDetraccionesDetalleAD().ListarDetraccionesDetActivas(fecDetraccion, idTipoDetraccion);
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
