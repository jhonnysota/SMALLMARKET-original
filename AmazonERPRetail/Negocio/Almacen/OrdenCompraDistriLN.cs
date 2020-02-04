using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;
using Infraestructura.Enumerados;

namespace Negocio.Almacen
{
    public class OrdenCompraDistriLN
    {

        public OrdenCompraDistriE InsertarOrdenCompraDistri(OrdenCompraDistriE ordencompradistri)
        {
            try
            {
                return new OrdenCompraDistriAD().InsertarOrdenCompraDistri(ordencompradistri);
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

        public OrdenCompraDistriE ActualizarOrdenCompraDistri(OrdenCompraDistriE ordencompradistri)
        {
            try
            {
                return new OrdenCompraDistriAD().ActualizarOrdenCompraDistri(ordencompradistri);
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

        public int EliminarOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                return new OrdenCompraDistriAD().EliminarOrdenCompraDistri(idEmpresa, idOrdenCompra);
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

        public List<OrdenCompraDistriE> ListarOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                return new OrdenCompraDistriAD().ListarOrdenCompraDistri(idEmpresa, idOrdenCompra);
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

        public OrdenCompraDistriE ObtenerOrdenCompraDistri(Int32 idEmpresa, Int32 idOrdenCompra, String idCCostos)
        {
            try
            {
                return new OrdenCompraDistriAD().ObtenerOrdenCompraDistri(idEmpresa, idOrdenCompra, idCCostos);
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
