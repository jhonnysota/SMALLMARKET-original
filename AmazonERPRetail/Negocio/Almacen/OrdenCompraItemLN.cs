using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;
using AccesoDatos.Maestros;

namespace Negocio.Almacen
{
    public class OrdenCompraItemLN
    {

        public OrdenCompraItemE InsertarOrdenCompraItem(OrdenCompraItemE ordencompraitem)
        {
            try
            {
                return new OrdenCompraItemAD().InsertarOrdenCompraItem(ordencompraitem);
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

        public OrdenCompraItemE ActualizarOrdenCompraItem(OrdenCompraItemE ordencompraitem)
        {
            try
            {
                return new OrdenCompraItemAD().ActualizarOrdenCompraItem(ordencompraitem);
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

        public Int32 EliminarOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                return new OrdenCompraItemAD().EliminarOrdenCompraItem(idEmpresa, idOrdenCompra);
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

        public List<OrdenCompraItemE> ListarOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                List<OrdenCompraItemE> ListaOcItems = new OrdenCompraItemAD().ListarOrdenCompraItem(idEmpresa, idOrdenCompra);

                foreach (OrdenCompraItemE item in ListaOcItems)
                {
                    item.ArticuloServ = new ArticuloServAD().ObtenerArticuloServ(item.idEmpresa, item.idArticuloServ);
                }

                return ListaOcItems;
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

        public OrdenCompraItemE ObtenerOrdenCompraItem(Int32 idEmpresa, Int32 idOrdenCompra, Int32 idItem)
        {
            try
            {
                return new OrdenCompraItemAD().ObtenerOrdenCompraItem(idEmpresa, idOrdenCompra, idItem);
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
