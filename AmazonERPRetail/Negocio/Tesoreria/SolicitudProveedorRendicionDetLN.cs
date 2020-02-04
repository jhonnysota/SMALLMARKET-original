using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;

namespace Negocio.Tesoreria
{
    public class SolicitudProveedorRendicionDetLN
    {

        public SolicitudProveedorRendicionDetE InsertarSolicitudProveedorRendicionDet(SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet)
        {
            try
            {
                return new SolicitudProveedorRendicionDetAD().InsertarSolicitudProveedorRendicionDet(solicitudproveedorrendiciondet);
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

        public SolicitudProveedorRendicionDetE ActualizarSolicitudProveedorRendicionDet(SolicitudProveedorRendicionDetE solicitudproveedorrendiciondet)
        {
            try
            {
                return new SolicitudProveedorRendicionDetAD().ActualizarSolicitudProveedorRendicionDet(solicitudproveedorrendiciondet);
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

        public int EliminarSolicitudProveedorRendicionDet(Int32 idRendicion, Int32 Item)
        {
            try
            {
                return new SolicitudProveedorRendicionDetAD().EliminarSolicitudProveedorRendicionDet(idRendicion, Item);
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

        public List<SolicitudProveedorRendicionDetE> ListarSolicitudProveedorRendicionDet(Int32 idRendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionDetAD().ListarSolicitudProveedorRendicionDet(idRendicion);
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

        public SolicitudProveedorRendicionDetE ObtenerSolicitudProveedorRendicionDet(Int32 idRendicion, Int32 Item)
        {
            try
            {
                return new SolicitudProveedorRendicionDetAD().ObtenerSolicitudProveedorRendicionDet(idRendicion, Item);
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

        public List<SolicitudProveedorRendicionDetE> RendicionImpresion(Int32 idRendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionDetAD().RendicionImpresion(idRendicion);
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
