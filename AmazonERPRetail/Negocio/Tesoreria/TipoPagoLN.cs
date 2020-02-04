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
    public class TipoPagoLN
    {

        public TipoPagoE GrabarTipoPago(TipoPagoE tipopago, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        TipoPagoE TipoPagoTmp = new TipoPagoAD().InsertarTipoPago(tipopago);

                        if (tipopago.DetalleTipoPago != null)
                        {
                            foreach (TipoPagoDetE item in tipopago.DetalleTipoPago)
                            {
                                item.codTipoPago = TipoPagoTmp.codTipoPago;
                                new TipoPagoDetAD().InsertarTipoPagoDet(item);
                            } 
                        }
                    }
                    else
                    {
                        tipopago = new TipoPagoAD().ActualizarTipoPago(tipopago);
                        new TipoPagoDetAD().EliminarTipoPagoDet(tipopago.idEmpresa, tipopago.codTipoPago);

                        if (tipopago.DetalleTipoPago != null)
                        {
                            foreach (TipoPagoDetE item in tipopago.DetalleTipoPago)
                            {
                                item.codTipoPago = tipopago.codTipoPago;
                                new TipoPagoDetAD().InsertarTipoPagoDet(item);
                            } 
                        }
                    }

                    oTrans.Complete();
                }

                return tipopago;
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

        public TipoPagoE InsertarTipoPago(TipoPagoE tipopago)
        {
            try
            {
                return new TipoPagoAD().InsertarTipoPago(tipopago);
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

        public TipoPagoE ActualizarTipoPago(TipoPagoE tipopago)
        {
            try
            {
                return new TipoPagoAD().ActualizarTipoPago(tipopago);
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

        public Int32 EliminarTipoPago( String codTipoPago)
        {
            try
            {
                return new TipoPagoAD().EliminarTipoPago( codTipoPago);
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

        public Int32 AnularTipoPago(String codTipoPago, String UsuarioModificacion)
        {
            try
            {
                return new TipoPagoAD().AnularTipoPago(codTipoPago, UsuarioModificacion);
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

        public List<TipoPagoE> ListarTipoPago()
        {
            try
            {
                return new TipoPagoAD().ListarTipoPago();
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

        public TipoPagoE ObtenerTipoPago(String codTipoPago, Int32 idEmpresa, String ConDetalle = "S")
        {
            try
            {
                TipoPagoE oTipoPago = new TipoPagoAD().ObtenerTipoPago(codTipoPago);

                if (ConDetalle == "S")
                {
                    oTipoPago.DetalleTipoPago = new TipoPagoDetAD().ListarTipoPagoDet(idEmpresa, codTipoPago);
                }

                return oTipoPago;
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

        public List<TipoPagoE> ListarTipoPagoCombo(String indTipo, Int32 idEmpresa = 0)
        {
            try
            {
                List<TipoPagoE> oListaTipoPago = new TipoPagoAD().ListarTipoPagoCombo(indTipo);

                if (idEmpresa != 0)
                {
                    foreach (TipoPagoE item in oListaTipoPago)
                    {
                        item.DetalleTipoPago = new TipoPagoDetAD().ListarTipoPagoDet(idEmpresa, item.codTipoPago);
                    }
                }

                return oListaTipoPago;
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
