using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class OrdenConversionGastosLN
    {

        public OrdenConversionGastosE InsertarOrdenConversionGastos(OrdenConversionGastosE ordenconversiongastos)
        {
            try
            {
                return new OrdenConversionGastosAD().InsertarOrdenConversionGastos(ordenconversiongastos);
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

        public OrdenConversionGastosE ActualizarOrdenConversionGastos(OrdenConversionGastosE ordenconversiongastos)
        {
            try
            {
                return new OrdenConversionGastosAD().ActualizarOrdenConversionGastos(ordenconversiongastos);
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

        public int EliminarOrdenConversionGastos(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {
            try
            {
                return new OrdenConversionGastosAD().EliminarOrdenConversionGastos(idEmpresa, idOrdenConversion, item);
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

        public List<OrdenConversionGastosE> ListarOrdenConversionGastos(Int32 idOrdenConversion)
        {
            try
            {
                return new OrdenConversionGastosAD().ListarOrdenConversionGastos(idOrdenConversion);
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

        public OrdenConversionGastosE ObtenerOrdenConversionGastos(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {
            try
            {
                return new OrdenConversionGastosAD().ObtenerOrdenConversionGastos(idEmpresa, idOrdenConversion, item);
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

        public List<OrdenConversionGastosE> ListarGastosConversion(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            try
            {
                return new OrdenConversionGastosAD().ListarGastosConversion(idEmpresa, idOrdenConversion);
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
