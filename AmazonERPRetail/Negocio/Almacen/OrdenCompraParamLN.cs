using System;
using System.Text;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class OrdenCompraParamLN 
    {

        public OrdenCompraParametrosE InsertarOrdenCompraParam(OrdenCompraParametrosE ordencompraparam)
        {
            try
            {
                return new OrdenCompraParamAD().InsertarOrdenCompraParam(ordencompraparam);
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

        public OrdenCompraParametrosE ActualizarOrdenCompraParam(OrdenCompraParametrosE ordencompraparam)
        {
            try
            {
                return new OrdenCompraParamAD().ActualizarOrdenCompraParam(ordencompraparam);
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

        public OrdenCompraParametrosE ObtenerOrdenCompraParam(Int32 idEmpresa)
        {
            try
            {
                return new OrdenCompraParamAD().ObtenerOrdenCompraParam(idEmpresa);
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
