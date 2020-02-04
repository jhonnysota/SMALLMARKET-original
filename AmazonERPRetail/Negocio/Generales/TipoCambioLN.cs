using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Generales;
using AccesoDatos.Generales;

namespace Negocio.Generales
{
    public class TipoCambioLN //: BaseLN
    {
        public TipoCambioE InsertarTipoCambio(TipoCambioE tipocambio)
        {
            try
            {
                return new TipoCambioAD().InsertarTipoCambio(tipocambio);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();
                    
                switch (err.Number)
                {
                    case 3621:
                        mensaje.Append("El tipo de cambio para esta fecha ya ha sido ingresada. \n");
                        mensaje.Append("Cambie de fecha y vuelva a grabar.");
                        break;
                    case 2627:
                        mensaje.Append("El tipo de cambio para esta fecha ya ha sido ingresada. \n");
                        mensaje.Append("Cambie de fecha y vuelva a grabar.");
                        break;
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

        public TipoCambioE ActualizarTipoCambio(TipoCambioE tipocambio)
        {
            try
            {
                return new TipoCambioAD().ActualizarTipoCambio(tipocambio);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    case 3621:
                        mensaje.Append("El tipo de cambio para esta fecha ya ha sido ingresada. \n");
                        mensaje.Append("Cambie de fecha y vuelva a grabar.");
                        break;
                    case 2627:
                        mensaje.Append("El tipo de cambio para esta fecha ya ha sido ingresada. \n");
                        mensaje.Append("Cambie de fecha y vuelva a grabar.");
                        break;
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

        public List<TipoCambioE> ListarTipoCambioPorFechas(String idMoneda, string fecIni, string fecFin)
        {
            try
            {
                return new TipoCambioAD().ListarTipoCambioPorFechas(idMoneda, fecIni, fecFin);
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

        public TipoCambioE ObtenerTipoCambioPorDia(String idMoneda, string fecCambio)
        {
            try
            {
                return new TipoCambioAD().ObtenerTipoCambioPorDia(idMoneda, fecCambio);
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

        public void GrabarTipoCambioPorDia(TipoCambioE tipocambio)
        {
            try
            {
                TipoCambioE oTicaTemp = new TipoCambioAD().ObtenerTipoCambioPorDia(tipocambio.idMoneda, tipocambio.fecCambio);

                if (oTicaTemp == null)
                {
                    new TipoCambioAD().InsertarTipoCambio(tipocambio);
                }
                else
                {
                    oTicaTemp.fecCambio = Convert.ToDateTime(oTicaTemp.fecCambio).ToString("yyyyMMdd");
                    oTicaTemp.valVenta = tipocambio.valVenta;
                    oTicaTemp.valCompra = tipocambio.valCompra;
                    oTicaTemp.UsuarioModificacion = tipocambio.UsuarioRegistro;

                    new TipoCambioAD().ActualizarTipoCambio(oTicaTemp);
                }                
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

        public void GrabarTipoCambioMasivo(List<TipoCambioE> oListaTipoCambio)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    TipoCambioE oTicaTemp = null;

                    foreach (TipoCambioE item in oListaTipoCambio)
                    {
                        oTicaTemp = new TipoCambioAD().ObtenerTipoCambioPorDia(item.idMoneda, item.fecCambio);

                        if (oTicaTemp == null)
                        {
                            new TipoCambioAD().InsertarTipoCambio(item);
                        }
                        else
                        {
                            oTicaTemp.fecCambio = Convert.ToDateTime(oTicaTemp.fecCambio).ToString("yyyyMMdd");
                            oTicaTemp.valVenta = item.valVenta;
                            oTicaTemp.valCompra = item.valCompra;
                            oTicaTemp.UsuarioModificacion = item.UsuarioRegistro;

                            new TipoCambioAD().ActualizarTipoCambio(oTicaTemp);
                        }
                    }

                    oTrans.Complete();
                }
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
