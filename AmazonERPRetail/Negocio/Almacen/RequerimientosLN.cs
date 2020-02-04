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
    public class RequerimientosLN
    {

        public RequerimientosE GrabarRequerimiento(RequerimientosE Requerimiento, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    StockE oStock = null;
                    AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(Requerimiento.idEmpresa, Convert.ToInt32(Requerimiento.idAlmacen));

                    //Validando Stocks
                    if (oAlmacen == null)
                    {
                        throw new Exception("El almacén no existe revise por favor.");
                    }

                    if (OpcionGrabar == EnumOpcionGrabar.Insertar)
                    {
                        String numReque = new RequerimientosAD().CorrelativoRequerimiento(Requerimiento.idEmpresa, Requerimiento.idLocal, Requerimiento.AnioPeriodo, Requerimiento.idPuntoReq);
                        Requerimiento.numRequeri = numReque;
                        Requerimiento = new RequerimientosAD().InsertarRequerimientos(Requerimiento);

                        if (Requerimiento.ListaRequerimientosItems != null && Requerimiento.ListaRequerimientosItems.Count > 0)
                        {
                            foreach (RequerimientosItemE item in Requerimiento.ListaRequerimientosItems)
                            {
                                item.idRequerimiento = Requerimiento.idRequerimiento;
                                item.idEmpresa = Requerimiento.idEmpresa;
                                item.idLocal = Requerimiento.idLocal;

                                #region Revisando el stock

                                if (oAlmacen.VerificaStock)
                                {
                                    if (oAlmacen.VerificaLote)
                                    {
                                        oStock = new StockAD().ObtenerStockActualRequeri(item.idEmpresa, oAlmacen.idAlmacen, item.idTipoArticulo, item.idArticulo, Requerimiento.AnioPeriodo,
                                                                                        Requerimiento.MesPeriodo, true, item.Lote);
                                    }
                                    else
                                    {
                                        oStock = new StockAD().ObtenerStockActualRequeri(item.idEmpresa, oAlmacen.idAlmacen, item.idTipoArticulo, item.idArticulo, Requerimiento.AnioPeriodo,
                                                                                        Requerimiento.MesPeriodo, false, "");
                                    }

                                    if (oStock.EsComprometido)
                                    {
                                        if (oStock.canStock < item.cantRequerida)
                                        {
                                            throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                        }
                                    }
                                    else
                                    {
                                        if (oStock.canStock < item.cantRequerida)
                                        {
                                            throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                        }
                                    }
                                } 

                                #endregion

                                new RequerimientosItemAD().InsertarRequerimientosItem(item);
                            }
                        }
                    }
                    else
                    {
                        Requerimiento = new RequerimientosAD().ActualizarRequerimientos(Requerimiento);

                        if (Requerimiento.ListaRequerimientosItems != null && Requerimiento.ListaRequerimientosItems.Count > 0)
                        {
                            foreach (RequerimientosItemE item in Requerimiento.ListaRequerimientosItems)
                            {
                                item.idRequerimiento = Requerimiento.idRequerimiento;
                                item.idEmpresa = Requerimiento.idEmpresa;
                                item.idLocal = Requerimiento.idLocal;

                                #region Revisando el stock

                                if (oAlmacen.VerificaStock)
                                {
                                    if (oAlmacen.VerificaLote)
                                    {
                                        oStock = new StockAD().ObtenerStockActualRequeri(item.idEmpresa, oAlmacen.idAlmacen, item.idTipoArticulo, item.idArticulo, Requerimiento.AnioPeriodo,
                                                                                        Requerimiento.MesPeriodo, true, item.Lote);
                                    }
                                    else
                                    {
                                        oStock = new StockAD().ObtenerStockActualRequeri(item.idEmpresa, oAlmacen.idAlmacen, item.idTipoArticulo, item.idArticulo, Requerimiento.AnioPeriodo,
                                                                                        Requerimiento.MesPeriodo, false, "");
                                    }

                                    if (oStock.EsComprometido)
                                    {
                                        if (oStock.canStock + item.cantTemporal < item.cantRequerida)
                                        {
                                            throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                        }
                                    }
                                    else
                                    {
                                        if (oStock.canStock < item.cantRequerida)
                                        {
                                            throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                        }
                                    }
                                }

                                #endregion

                                switch (item.Opcion)
                                {
                                    case (Int32)EnumOpcionGrabar.Insertar:

                                        new RequerimientosItemAD().InsertarRequerimientosItem(item);
                                        break;
                                    case (Int32)EnumOpcionGrabar.Actualizar:

                                        new RequerimientosItemAD().ActualizarRequerimientosItem(item);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return Requerimiento;
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

        public RequerimientosE InsertarRequerimientos(RequerimientosE requerimientos)
        {
            try
            {
                return new RequerimientosAD().InsertarRequerimientos(requerimientos);
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

        public RequerimientosE ActualizarRequerimientos(RequerimientosE requerimientos)
        {
            try
            {
                return new RequerimientosAD().ActualizarRequerimientos(requerimientos);
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

        public int EliminarRequerimientos(Int32 idRequerimiento)
        {
            try
            {
                return new RequerimientosAD().EliminarRequerimientos(idRequerimiento);
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

        public List<RequerimientosE> ListarRequerimientos(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Int32 idAlmacen, String idCCostos, String indEstado)
        {
            try
            {
                return new RequerimientosAD().ListarRequerimientos(idEmpresa, idLocal, fecIni, fecFin, idAlmacen, idCCostos, indEstado);
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

        public RequerimientosE ObtenerRequerimientos(Int32 idRequerimiento)
        {
            try
            {
                return new RequerimientosAD().ObtenerRequerimientos(idRequerimiento);
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

        public RequerimientosE RecuperarRequerimiento(Int32 idRequerimiento)
        {
            try
            {
                RequerimientosE oRequerimiento = new RequerimientosAD().ObtenerRequerimientos(idRequerimiento);
                oRequerimiento.ListaRequerimientosItems = new RequerimientosItemAD().ListarRequerimientosItem(idRequerimiento);

                return oRequerimiento;
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
