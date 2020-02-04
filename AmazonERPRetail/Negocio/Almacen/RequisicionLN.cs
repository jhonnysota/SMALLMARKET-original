using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Almacen;
using AccesoDatos.Almacen;
using Infraestructura.Enumerados;

namespace Negocio.Almacen
{
    public class RequisicionLN 
    {

        public RequisicionE GrabarRequisicion(RequisicionE ListaRequisicion, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new RequisicionAD().ActualizarRequisicion(ListaRequisicion);

                            //Detalle de la lista de precios
                            if (ListaRequisicion.ListaRequisicionItem != null && ListaRequisicion.ListaRequisicionItem.Count > 0)
                            {
                                foreach (RequisicionItemE oitem in ListaRequisicion.ListaRequisicionItem)
                                {
                                    oitem.idRequisicion = ListaRequisicion.idRequisicion;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new RequisicionItemAD().InsertarRequisicionItem(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new RequisicionItemAD().ActualizarRequisicionItem(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            new RequisicionItemAD().EliminarRequisicionItem(oitem.idEmpresa, oitem.idRequisicion,oitem.idItem);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            if (ListaRequisicion.ListaRequisionProveedor != null && ListaRequisicion.ListaRequisionProveedor.Count > 0)
                            {
                                foreach (RequisicionProveedorE oitem in ListaRequisicion.ListaRequisionProveedor)
                                {
                                    oitem.idRequisicion = ListaRequisicion.idRequisicion;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new RequisicionProveedorAD().InsertarRequisicionProveedor(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new RequisicionProveedorAD().ActualizarRequisicionProveedor(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            new RequisicionProveedorAD().EliminarRequisicionProveedor(oitem.idEmpresa, oitem.idRequisicion, oitem.idPersona);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            Int32 nroRequisicion = new RequisicionAD().GenerarNroRequisicion(ListaRequisicion.idEmpresa, ListaRequisicion.idLocal, Convert.ToDateTime(ListaRequisicion.FechaSolicitud));
                            ListaRequisicion.numRequisicion = nroRequisicion.ToString();

                            //Insertando personas
                            ListaRequisicion = new RequisicionAD().InsertarRequisicion(ListaRequisicion);

                            //Lista de Precios...
                            if (ListaRequisicion.ListaRequisicionItem != null && ListaRequisicion.ListaRequisicionItem.Count > 0)
                            {
                                foreach (RequisicionItemE oitem in ListaRequisicion.ListaRequisicionItem)
                                {
                                    oitem.idRequisicion = ListaRequisicion.idRequisicion;
                                    new RequisicionItemAD().InsertarRequisicionItem(oitem);
                                }
                            }

                            if (ListaRequisicion.ListaRequisionProveedor != null && ListaRequisicion.ListaRequisionProveedor.Count > 0)
                            {
                                foreach (RequisicionProveedorE oitem in ListaRequisicion.ListaRequisionProveedor)
                                {
                                    oitem.idRequisicion = ListaRequisicion.idRequisicion;
                                    new RequisicionProveedorAD().InsertarRequisicionProveedor(oitem);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return ListaRequisicion;
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

        public RequisicionE InsertarRequisicion(RequisicionE requisicion)
        {
            try
            {
                return new RequisicionAD().InsertarRequisicion(requisicion);
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

        public RequisicionE ActualizarRequisicion(RequisicionE requisicion)
        {
            try
            {
                return new RequisicionAD().ActualizarRequisicion(requisicion);
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

        public int EliminarRequisicion(Int32 idEmpresa, Int32 idRequisicion)
        {
            try
            {
                return new RequisicionAD().EliminarRequisicion(idEmpresa, idRequisicion);
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

        public List<RequisicionE> ListarRequisicion(Int32 idEmpresa,Int32 idLocal, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new RequisicionAD().ListarRequisicion(idEmpresa, idLocal, fecIni, fecFin);
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

        public List<RequisicionE> ListarRequisicionAprobacion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin,String tipEstado)
        {
            try
            {
                return new RequisicionAD().ListarRequisicionAprobacion(idEmpresa, fecIni, fecFin, tipEstado);
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

        public RequisicionE ObtenerRequisicion(Int32 idEmpresa, Int32 idRequisicion)
        {
            try
            {
                return new RequisicionAD().ObtenerRequisicion(idEmpresa, idRequisicion);
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

        public RequisicionE ActivarRequisicion(RequisicionE requisicion)
        {
            try
            {
                return new RequisicionAD().ActivarRequisicion(requisicion);
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

        public List<RequisicionE> ListarRequisicionPendientes(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String Filtro)
        {
            try
            {
                return new RequisicionAD().ListarRequisicionPendientes(idEmpresa, fecIni, fecFin, Filtro);
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

        public Int32 GenerarNroRequisicion(Int32 idEmpresa, Int32 idLocal, DateTime FechaSolicitud)
        {
            try
            {
                return new RequisicionAD().GenerarNroRequisicion(idEmpresa, idLocal, FechaSolicitud);
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
