using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;

namespace Negocio.Tesoreria
{
    public class OrdenPagoDetLN 
    {

        public OrdenPagoDetE InsertarOrdenPagoDet(OrdenPagoDetE ordenpagodet)
        {
            try
            {
                return new OrdenPagoDetAD().InsertarOrdenPagoDet(ordenpagodet);
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

        public OrdenPagoDetE ActualizarOrdenPagoDet(OrdenPagoDetE ordenpagodet)
        {
            try
            {
                return new OrdenPagoDetAD().ActualizarOrdenPagoDet(ordenpagodet);
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

        public int EliminarOrdenPagoDet(Int32 idOrdenPago)
        {
            try
            {
                return new OrdenPagoDetAD().EliminarOrdenPagoDet(idOrdenPago);
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

        public List<OrdenPagoDetE> ListarOrdenPagoDet(Int32 idOrdenPago)
        {
            try
            {
                return new OrdenPagoDetAD().ListarOrdenPagoDet(idOrdenPago);
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

        public OrdenPagoDetE ObtenerOrdenPagoDet(Int32 idOrdenPago, Int32 idOrdenPagoItem)
        {
            try
            {
                return new OrdenPagoDetAD().ObtenerOrdenPagoDet(idOrdenPago, idOrdenPagoItem);
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

        public List<CtaCteE> BuscarDocExistenteOp(Int32 idLocal, Int32 idOrdenPago, List<CtaCteE> ListaConsulta)
        {
            try
            {
                List<CtaCteE> oListaDevuelta = new List<CtaCteE>();

                foreach (CtaCteE item in ListaConsulta)
                {
                    OrdenPagoDetE oItem = new OrdenPagoDetAD().BuscarDocExistenteOp(item.idEmpresa, idLocal, idOrdenPago, item.idPersona, item.idDocumento, item.numSerie, item.numDocumento);

                    if (oItem != null)
                    {
                        item.codOrdenPago = oItem.codOrdenPago;
                        oListaDevuelta.Add(item);
                    }
                }

                return oListaDevuelta;
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

        public OrdenPagoDetE ObtenerOrdenPagoDetPorDocumento(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, String idDocumento, String serDocumento, String numDocumento)
        {
            try
            {
                return new OrdenPagoDetAD().ObtenerOrdenPagoDetPorDocumento(idEmpresa, idLocal, idProveedor, idDocumento, serDocumento, numDocumento);
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
