using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class StockLN
    {

        public List<StockE> ListarReporteStockMensual(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            try
            {
                return new StockAD().ListarReporteStockMensual(idEmpresa, idAlmacen, Anio, Mes, indCorte, fechaHasta);
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

        public List<StockE> ListarReporteStockMensualMuestra(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            try
            {
                return new StockAD().ListarReporteStockMensualMuestra(idEmpresa, idAlmacen, Anio, Mes, indCorte, fechaHasta);
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

        public List<StockE> ListarReporteStockMensualSL(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, Int32 indCorte, string fechaHasta)
        {
            try
            {
                return new StockAD().ListarReporteStockMensualSL(idEmpresa, idAlmacen, Anio, Mes, indCorte, fechaHasta);
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

        public List<StockE> ListarStockArticulo(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, Boolean conLote, string codArticulo, string desArticulo, String EsCotizacion)
        {
            try
            {
                return new StockAD().ListarStockArticulo(idEmpresa, idAlmacen, idTipoArticulo, Anio, Mes, conLote, codArticulo, desArticulo, EsCotizacion);
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

        public List<StockE> ListarStockArticuloRequeri(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, String Anio, String Mes, Boolean conLote, string codArticulo, string desArticulo)
        {
            try
            {
                return new StockAD().ListarStockArticuloRequeri(idEmpresa, idAlmacen, idTipoArticulo, Anio, Mes, conLote, codArticulo, desArticulo);
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

        public List<StockE> StockPorIdArticulo(Int32 idEmpresa, Int32 idAlmacen, Int32 idTipoArticulo, Int32 idArticulo, String Anio, String Mes, Boolean conLote)
        {
            try
            {
                return new StockAD().StockPorIdArticulo(idEmpresa, idAlmacen, idTipoArticulo, idArticulo, Anio, Mes, conLote);
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
