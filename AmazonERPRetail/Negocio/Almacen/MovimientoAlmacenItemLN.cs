using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Almacen;

namespace Negocio.Almacen
{
    public class MovimientoAlmacenItemLN
    {
        public MovimientoAlmacenItemE InsertarMovimiento_Almacen_Item(MovimientoAlmacenItemE item)
        {
            try
            {
                return new MovimientoAlmacenItemAD().InsertarMovimiento_Almacen_Item(item);
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

        public MovimientoAlmacenItemE ActualizarMovimiento_Almacen_Item(MovimientoAlmacenItemE item)
        {
            try
            {
                return new MovimientoAlmacenItemAD().ActualizarMovimiento_Almacen_Item(item);
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

        public int EliminarMovimiento_Almacen_Item(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem)
        {
            try
            {
                return new MovimientoAlmacenItemAD().EliminarMovimiento_Almacen_Item(idEmpresa, tipMovimiento, idDocumentoAlmacen, idItem);
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

        public List<MovimientoAlmacenItemE> ListarMovimiento_Almacen_Item(int idEmpresa, int idDocumentoAlmacen)
        {
            try
            {
                return new MovimientoAlmacenItemAD().ListarMovimiento_Almacen_Item(idEmpresa, idDocumentoAlmacen);
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

        public MovimientoAlmacenItemE ObtenerMovimiento_Almacen_Item(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idItem)
        {
            try
            {
                return new MovimientoAlmacenItemAD().ObtenerMovimiento_Almacen_Item(idEmpresa, tipMovimiento, idDocumentoAlmacen, idItem);
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

        public MovimientoAlmacenItemE ObtenerMovimiento_Almacen_ItemLote(Int32 idEmpresa, Int32 idOrdenCompra, Int32 idItemCompra, String idDocumento, String serDocumento, String numDocumento)
        {
            try
            {
                return new MovimientoAlmacenItemAD().ObtenerMovimiento_Almacen_ItemLote(idEmpresa, idOrdenCompra, idItemCompra, idDocumento, serDocumento, numDocumento);
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

        public MovimientoAlmacenItemE ActualizarLoteMovAlmacen(MovimientoAlmacenItemE item)
        {
            try
            {
                LoteE oLote = new LoteAD().BuscarLoteExistente(item.idEmpresa, item.Lote);

                if (oLote == null)
                {
                    throw new Exception("Este Lote no existe.");
                }

                return new MovimientoAlmacenItemAD().ActualizarLoteMovAlmacen(item);
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

        //public List<Movimiento_AlmacenE> ListarIngresos_Compra_Pendiente(int idEmpresa, String CodMoneda)
        //{
        //    try
        //    {
        //        return new Movimiento_AlmacenAD().ListarIngresos_Compra_Pendiente(idEmpresa, CodMoneda);
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

    }
}
