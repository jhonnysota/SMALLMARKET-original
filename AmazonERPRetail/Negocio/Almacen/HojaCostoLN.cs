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
    public class HojaCostoLN
    {

        public HojaCostoE GrabarHojaCosto(HojaCostoE ListaHojaCosto, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            #region Actualizar

                            //Actualizando la hoja de costo
                            new HojaCostoAD().ActualizarHojaCosto(ListaHojaCosto);

                            //Detalle de la hoja de costo
                            if (ListaHojaCosto.ListaHojaCostoItem != null)
                            {
                                new HojaCostoItemAD().EliminarHojaCostoItem(ListaHojaCosto.idEmpresa, ListaHojaCosto.idLocal, ListaHojaCosto.idHojaCosto);

                                foreach (HojaCostoItemE oitem in ListaHojaCosto.ListaHojaCostoItem)
                                {
                                    oitem.idHojaCosto = ListaHojaCosto.idHojaCosto;
                                    oitem.idLocal = ListaHojaCosto.idLocal;
                                    new HojaCostoItemAD().InsertarHojaCostoItem(oitem);
                                }
                            }

                            //Actualizando los gastos de importación
                            if (ListaHojaCosto.ListaGastosImportacion != null && ListaHojaCosto.ListaGastosImportacion.Count > 0)
                            {
                                foreach (GastosImportacionE oitem in ListaHojaCosto.ListaGastosImportacion)
                                {
                                    oitem.idHojaCosto = ListaHojaCosto.idHojaCosto;
                                    oitem.idLocal = ListaHojaCosto.idLocal;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new GastosImportacionAD().InsertarGastosImportacion(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new GastosImportacionAD().ActualizarGastosImportacion(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            new GastosImportacionAD().EliminarGastosImportacion(oitem.idEmpresa, oitem.idLocal, oitem.idHojaCosto, oitem.item);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case EnumOpcionGrabar.Insertar:

                            #region Insertar
                            
                            //Insertando hoja de costos
                            ListaHojaCosto = new HojaCostoAD().InsertarHojaCosto(ListaHojaCosto);

                            //Insertando detalle de la hoja de costo
                            if (ListaHojaCosto.ListaHojaCostoItem != null && ListaHojaCosto.ListaHojaCostoItem.Count > 0)
                            {
                                foreach (HojaCostoItemE oitem in ListaHojaCosto.ListaHojaCostoItem)
                                {
                                    oitem.idHojaCosto = ListaHojaCosto.idHojaCosto;
                                    oitem.idLocal = ListaHojaCosto.idLocal;
                                    new HojaCostoItemAD().InsertarHojaCostoItem(oitem);
                                }
                            }

                            if (ListaHojaCosto.ListaGastosImportacion != null && ListaHojaCosto.ListaGastosImportacion.Count > 0)
                            {
                                foreach (GastosImportacionE oitem in ListaHojaCosto.ListaGastosImportacion)
                                {
                                    oitem.idHojaCosto = ListaHojaCosto.idHojaCosto;
                                    oitem.idLocal = ListaHojaCosto.idLocal;
                                    new GastosImportacionAD().InsertarGastosImportacion(oitem);
                                }
                            }

                            #endregion

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return ListaHojaCosto;
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
            
        public HojaCostoE InsertarHojaCosto(HojaCostoE hojacosto)
        {
            try
            {
                return new HojaCostoAD().InsertarHojaCosto(hojacosto);
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

        public HojaCostoE ActualizarHojaCosto(HojaCostoE hojacosto)
        {
            try
            {
                return new HojaCostoAD().ActualizarHojaCosto(hojacosto);
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

        public int EliminarHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            try
            {
                return new HojaCostoAD().EliminarHojaCosto(idEmpresa, idLocal, idHojaCosto);
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

        public List<HojaCostoE> ListarHojaCosto(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                return new HojaCostoAD().ListarHojaCosto(idEmpresa, FechaIni, FechaFin);
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

        public List<HojaCostoE> ReporteHojaCosto(Int32 idEmpresa, string FechaInicio, string FechaFin, String DesProveedor, String codArticulo, String nomArticulo)
        {
            try
            {
                return new HojaCostoAD().ReporteHojaCosto(idEmpresa, FechaInicio, FechaFin, DesProveedor, codArticulo, nomArticulo);
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

        public HojaCostoE ObtenerHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            try
            {
                return new HojaCostoAD().ObtenerHojaCosto(idEmpresa, idLocal, idHojaCosto);
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

        public HojaCostoE RecuperarHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            try
            {
                HojaCostoE oHojaCostos = new HojaCostoAD().ObtenerHojaCosto(idEmpresa, idLocal, idHojaCosto);
                oHojaCostos.ListaHojaCostoItem = new HojaCostoItemAD().ListarHojaCostoItem(idEmpresa, idLocal, idHojaCosto);
                oHojaCostos.ListaGastosImportacion = new GastosImportacionAD().ListarGastosImportacion(idEmpresa, idLocal, idHojaCosto);

                return oHojaCostos;
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

        public int ActualizarEstadoHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 idOrdenCompra, String Estado, String UsuarioModificacion)
        {
            try
            {
                return new HojaCostoAD().ActualizarEstadoHojaCosto(idEmpresa, idLocal, idHojaCosto, idOrdenCompra, Estado, UsuarioModificacion);
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
