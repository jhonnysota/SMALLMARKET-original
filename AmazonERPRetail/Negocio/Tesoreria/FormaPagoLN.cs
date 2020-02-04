using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;
using Infraestructura.Enumerados;

namespace Negocio.Tesoreria
{
    public class FormaPagoLN 
    {

        public FormaPagoE GrabarFormaPago(FormaPagoE oFormaPago, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new FormaPagoAD().ActualizarFormaPago(oFormaPago);

                            if (oFormaPago.oListaFormaTipoEliminados != null)
                            {
                                foreach (FormaTipoPagoE item in oFormaPago.oListaFormaTipoEliminados)
                                {
                                    new FormaTipoPagoAD().EliminarFormaTipoPago(item.codTipoPago, item.idConcepto, item.codFormaPago); 
                                }
                            }

                            //Detalle de la lista de precios
                            if (oFormaPago.ListaTipoPago != null)
                            {
                                foreach (FormaTipoPagoE oitem in oFormaPago.ListaTipoPago)
                                {
                                    oitem.codFormaPago = oFormaPago.codFormaPago;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new FormaTipoPagoAD().InsertarFormaTipoPago(oitem);
                                            break;

                                        //case (Int32)EnumOpcionGrabar.Actualizar:
                                        //    new FormaTipoPagoAD().ActualizarFormaTipoPago(oitem);
                                        //    break;

                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando personas
                            oFormaPago = new FormaPagoAD().InsertarFormaPago(oFormaPago);
                            
                            //Detalle...
                            if (oFormaPago.ListaTipoPago != null)
                            {
                                foreach (FormaTipoPagoE oitem in oFormaPago.ListaTipoPago)
                                {
                                    oitem.codFormaPago = oFormaPago.codFormaPago;
                                    new FormaTipoPagoAD().InsertarFormaTipoPago(oitem);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return oFormaPago;
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

        public FormaPagoE InsertarFormaPago(FormaPagoE formapago)
        {
            try
            {
                return new FormaPagoAD().InsertarFormaPago(formapago);
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

        public FormaPagoE ActualizarFormaPago(FormaPagoE formapago)
        {
            try
            {
                return new FormaPagoAD().ActualizarFormaPago(formapago);
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

        public Int32 EliminarFormaPago( String codFormaPago)
        {
            try
            {
                return new FormaPagoAD().EliminarFormaPago( codFormaPago);
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

        public List<FormaPagoE> ListarFormaPago()
        {
            try
            {
                return new FormaPagoAD().ListarFormaPago();
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

        public FormaPagoE ObtenerFormaPago(String codFormaPago, Int32 idEmpresa, String ConDetalle = "S")
        {
            try
            {
                FormaPagoE FormaPago = new FormaPagoAD().ObtenerFormaPago(codFormaPago);

                if (ConDetalle == "S")
                {
                    FormaPago.ListaTipoPago = new FormaTipoPagoAD().ListarFormaTipoPago(codFormaPago, idEmpresa);
                }

                return FormaPago;
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

        public List<FormaPagoE> ListarFormaPagoPorTipo(String codTipoPago, Int32 idConcepto, Int32 idEmpresa)
        {
            try
            {
                return new FormaPagoAD().ListarFormaPagoPorTipo(codTipoPago, idConcepto, idEmpresa);
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
