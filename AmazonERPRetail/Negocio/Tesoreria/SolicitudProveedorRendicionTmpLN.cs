using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Entidades.Generales;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using AccesoDatos.Generales;
using Negocio.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.Tesoreria
{
    public class SolicitudProveedorRendicionTmpLN
    {

        public Int32 GrabarRendicion(List<SolicitudProveedorRendicionTmpE> oRendiciones)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 Corre = 1;
                    new SolicitudProveedorRendicionTmpAD().EliminarSolicitudProveedorRendicion(oRendiciones[0].idSolicitud);

                    foreach (SolicitudProveedorRendicionTmpE item in oRendiciones)
                    {
                        item.Item = Corre;
                        new SolicitudProveedorRendicionTmpAD().InsertarSolicitudProveedorRendicion(item);
                        Corre++;
                    }

                    oTrans.Complete();
                }

                return resp;
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

        public SolicitudProveedorRendicionTmpE InsertarSolicitudProveedorRendicion(SolicitudProveedorRendicionTmpE solicitudproveedorrendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionTmpAD().InsertarSolicitudProveedorRendicion(solicitudproveedorrendicion);
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

        public SolicitudProveedorRendicionTmpE ActualizarSolicitudProveedorRendicion(SolicitudProveedorRendicionTmpE solicitudproveedorrendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionTmpAD().ActualizarSolicitudProveedorRendicion(solicitudproveedorrendicion);
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

        public int EliminarSolicitudProveedorRendicion(Int32 idSolicitud)
        {
            try
            {
                return new SolicitudProveedorRendicionTmpAD().EliminarSolicitudProveedorRendicion(idSolicitud);
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

        public List<SolicitudProveedorRendicionTmpE> ListarSolicitudProveedorRendicion(Int32 idSolicitud)
        {
            try
            {
                return new SolicitudProveedorRendicionTmpAD().ListarSolicitudProveedorRendicion(idSolicitud);
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

        public SolicitudProveedorRendicionTmpE ObtenerSolicitudProveedorRendicion(Int32 idSolicitud, Int32 Item)
        {
            try
            {
                return new SolicitudProveedorRendicionTmpAD().ObtenerSolicitudProveedorRendicion(idSolicitud, Item);
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

        public List<SolicitudProveedorRendicionTmpE> RendicionImpresion(Int32 idSolicitud)
        {
            try
            {
                return new SolicitudProveedorRendicionTmpAD().RendicionImpresion(idSolicitud);
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
