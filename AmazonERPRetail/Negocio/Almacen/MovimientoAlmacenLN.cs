using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using System.Linq;


using Entidades.Almacen;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Contabilidad;
using AccesoDatos.Almacen;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Generales;
using AccesoDatos.Maestros;
using AccesoDatos.Contabilidad;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace Negocio.Almacen
{
    public class MovimientoAlmacenLN
    {

        //El idLocal es para poder actualizar el lote en los documentos de ventas (SALIDAS DE ALMACEN)...
        //CambiarCodLote sirve para los movimientos XLS, por defecto esta en S, si esta e N significa que va a tomar el codigo del lote con el que viene desde excel
        public MovimientoAlmacenE GuardarMovimientoAlmacen(MovimientoAlmacenE mov_almacen, EnumOpcionGrabar OpcionGrabar, OrdenCompraE OcCompleta = null, String CambiarCodLote = "S")
        {
            try
            {
                String LoteIndusoft = "0000000";

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (OpcionGrabar == EnumOpcionGrabar.Insertar)
                    {
                        mov_almacen.idDocumentoAlmacen = new MovimientoAlmacenAD().InsertarMovimientoAlmacen(mov_almacen).idDocumentoAlmacen;

                        if (mov_almacen.ListaAlmacenItem != null && mov_almacen.ListaAlmacenItem.Count > 0)
                        {
                            foreach (MovimientoAlmacenItemE itemFrm in mov_almacen.ListaAlmacenItem)
                            {
                                if (itemFrm.idItem == 0)
                                {
                                    itemFrm.idEmpresa = mov_almacen.idEmpresa;
                                    itemFrm.tipMovimiento = mov_almacen.tipMovimiento;
                                    itemFrm.idDocumentoAlmacen = mov_almacen.idDocumentoAlmacen;

                                    if (itemFrm.Lote == "0")
                                    {
                                        LoteIndusoft = new LoteAD().ObtenerMaxLoteAlmacen(itemFrm.idEmpresa);
                                        itemFrm.Lote = LoteIndusoft;
                                    }

                                    new MovimientoAlmacenItemAD().InsertarMovimiento_Almacen_Item(itemFrm);

                                    #region Insertando el lote

                                    if (itemFrm.oLoteEntidad != null)
                                    {
                                        if (CambiarCodLote == "S")
                                        {
                                            itemFrm.oLoteEntidad.Lote = LoteIndusoft;
                                        }
                                        
                                        itemFrm.oLoteEntidad.tipMovimiento = mov_almacen.tipMovimiento;
                                        itemFrm.oLoteEntidad.idDocumentoAlmacen = mov_almacen.idDocumentoAlmacen;

                                        new LoteAD().InsertarLote(itemFrm.oLoteEntidad);
                                    }
                                    else
                                    {
                                        LoteE oLote = new LoteAD().ObtenerLote(itemFrm.idEmpresa, itemFrm.Lote,mov_almacen.idAlmacen);

                                        if (oLote != null)
                                        {
                                            new LoteAD().ActualizarDocAlmacenLote(itemFrm.idEmpresa, itemFrm.Lote, itemFrm.UsuarioRegistro);
                                        }
                                    }
                             

                                    #endregion

                                    String AnioPeriodo = mov_almacen.fecProceso.Substring(0, 4);//Convert.ToString(mov_almacen.fecProceso.Year);
                                    String MesPeriodo = mov_almacen.fecProceso.Substring(4, 2);//mov_almacen.fecProceso.ToString("MM");
                                    Int32 Almacen = Convert.ToInt32(mov_almacen.idAlmacen);
                                    Decimal CantMovimiento = itemFrm.Cantidad;

                                    new AlmacenArticuloLoteAD().ActualizarStockValorizado(itemFrm.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, mov_almacen.idOperacion, itemFrm.idArticulo, itemFrm.Lote, CantMovimiento, itemFrm.ImpCostoUnitarioBase, itemFrm.ImpCostoUnitarioRefe, "IN");

                                    #region Orden de compra
                               
                                    if (OcCompleta != null)
                                    {
                                        if (OcCompleta.ListaOrdenesCompras != null && OcCompleta.ListaOrdenesCompras.Count > 0)
                                        {
                                            foreach (OrdenCompraItemE itemOc in OcCompleta.ListaOrdenesCompras)
                                            {
                                                if (itemOc.idEmpresa == itemFrm.idEmpresa && itemOc.idOrdenCompra == mov_almacen.idOrdenCompra && itemOc.idItem == Convert.ToInt32(itemFrm.idItemCompra))
                                                {
                                                    if (CantMovimiento > ((itemOc.indPasoProv == true ? itemOc.canProvisionada : itemOc.CanOrdenada) - itemOc.CanIngresada))
                                                    {
                                                        throw new Exception("La cantidad ingresada no puede ser mayor a la cantidad de la OC.");
                                                    }
                                                    else if (CantMovimiento < ((itemOc.indPasoProv == true ? itemOc.canProvisionada : itemOc.CanOrdenada) - itemOc.CanIngresada))
                                                    {
                                                        itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.AP.ToString();
                                                    }
                                                    else
                                                    {
                                                        itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.AT.ToString();
                                                    }

                                                    itemOc.CanIngresada = CantMovimiento + itemOc.CanIngresada;
                                                    new OrdenCompraItemAD().ActualizarCantIngOc(itemOc);
                                                }
                                            }
                                        }
                                    } 

                                    #endregion
                                }
                            }

                            //Si se trata de una transferencia...
                            if (mov_almacen.indPorAsociar)
                            {
                                ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("ING");

                                if (oTipoMovimiento == null)
                                {
                                    throw new Exception("No existe Tipos de Movimientos para los Ingresos.");
                                }

                                GenerarIngresoTransferencia(mov_almacen, oTipoMovimiento.IdParTabla, mov_almacen.UsuarioRegistro);
                            }
                        }
                    }
                    else
                    {
                        // Traer Movimiento Anterior para Actualizar.
                        MovimientoAlmacenE oMovAlmacenAntes = ObtenerMovimientoAlmacenCompleto(mov_almacen.idEmpresa, mov_almacen.tipMovimiento, mov_almacen.idDocumentoAlmacen);
                        String AnioPeriodoAntes = oMovAlmacenAntes.fecProceso.IndexOf("-") > 0 || oMovAlmacenAntes.fecProceso.IndexOf("/") > 0 ? Convert.ToDateTime(oMovAlmacenAntes.fecProceso).ToString("yyyy") : oMovAlmacenAntes.fecProceso.Substring(0, 4);//Convert.ToString(oMovAlmacenAntes.fecProceso.Year);
                        String MesPeriodoAntes = oMovAlmacenAntes.fecProceso.IndexOf("-") > 0 || oMovAlmacenAntes.fecProceso.IndexOf("/") > 0 ? Convert.ToDateTime(oMovAlmacenAntes.fecProceso).ToString("MM") : oMovAlmacenAntes.fecProceso.Substring(4, 2);//oMovAlmacenAntes.fecProceso.ToString("MM");
                        Int32 AlmacenAntes = Convert.ToInt32(oMovAlmacenAntes.idAlmacen);

                        // Movimiento Actual
                        String AnioPeriodo = mov_almacen.fecProceso.IndexOf("-") > 0 || mov_almacen.fecProceso.IndexOf("/") > 0 ? Convert.ToDateTime(mov_almacen.fecProceso).ToString("yyyy") : mov_almacen.fecProceso.Substring(0, 4); //mov_almacen.fecProceso.Substring(0, 4);//Convert.ToString(mov_almacen.fecProceso.Year);
                        String MesPeriodo = mov_almacen.fecProceso.IndexOf("-") > 0 || mov_almacen.fecProceso.IndexOf("/") > 0 ? Convert.ToDateTime(mov_almacen.fecProceso).ToString("MM") : mov_almacen.fecProceso.Substring(4, 2);//mov_almacen.fecProceso.Substring(4, 2);//mov_almacen.fecProceso.ToString("MM");
                        Int32 Almacen = Convert.ToInt32(mov_almacen.idAlmacen);

                        new MovimientoAlmacenAD().ActualizarMovimientoAlmacen(mov_almacen);

                        // Eliminando Item
                        foreach (MovimientoAlmacenItemE itemSql in mov_almacen.ListaAlmacenItemEliminado)
                        {
                            // Eliminar Item del Almacen
                            new MovimientoAlmacenItemAD().EliminarMovimiento_Almacen_Item(itemSql.idEmpresa, itemSql.tipMovimiento, itemSql.idDocumentoAlmacen, itemSql.idItem);
                            // Verifica que no haya movimiento en ese lote y lo Elimina
                            new LoteAD().EliminarLote(itemSql.idEmpresa, itemSql.Lote);
                            //Quitando el Stock Eliminado.
                            MovimientoAlmacenItemE oItemAntes = (from x in oMovAlmacenAntes.ListaAlmacenItem
                                                                 where x.idEmpresa == itemSql.idEmpresa
                                                                 && x.tipMovimiento == itemSql.tipMovimiento
                                                                 && x.idDocumentoAlmacen == itemSql.idDocumentoAlmacen
                                                                 && x.idItem == itemSql.idItem
                                                                 select x).FirstOrDefault();
                            if (oItemAntes != null)
                            {
                                new AlmacenArticuloLoteAD().ActualizarStockValorizado(oItemAntes.idEmpresa, AnioPeriodoAntes, MesPeriodoAntes, AlmacenAntes, oMovAlmacenAntes.idOperacion, oItemAntes.idArticulo, oItemAntes.Lote, oItemAntes.Cantidad, oItemAntes.ImpCostoUnitarioBase, oItemAntes.ImpCostoUnitarioRefe, "AN");
                            }
                        }

                        OperacionE oOperacion = new OperacionAD().ObtenerOperacion(mov_almacen.idEmpresa, mov_almacen.idOperacion);
                        Boolean ActualizarLote = false;

                        if (oOperacion.automatico && oOperacion.desOperacion.ToUpper().Contains("VENTAS"))
                        {
                            ActualizarLote = true;
                        }

                        // Actualizando Item
                        List<MovimientoAlmacenItemE> oListaItem = mov_almacen.ListaAlmacenItem;
                        String Tipo = String.Empty;

                        if (mov_almacen.ListaAlmacenItem != null)
                        {
                            foreach (MovimientoAlmacenItemE itemFrm in oListaItem)
                            {
                                //Crear un nuevo lote
                                if (itemFrm.Lote == "0")
                                {
                                    LoteIndusoft = new LoteAD().ObtenerMaxLoteAlmacen(itemFrm.idEmpresa);
                                    itemFrm.Lote = LoteIndusoft;
                                }

                                //Si es nuevo el Item
                                if (itemFrm.idItem == 0)
                                {
                                    itemFrm.idDocumentoAlmacen = mov_almacen.idDocumentoAlmacen;
                                    itemFrm.tipMovimiento = mov_almacen.tipMovimiento;
                                    new MovimientoAlmacenItemAD().InsertarMovimiento_Almacen_Item(itemFrm);

                                    if (itemFrm.oLoteEntidad != null)
                                    {
                                        itemFrm.oLoteEntidad.Lote = itemFrm.Lote;
                                        itemFrm.oLoteEntidad.tipMovimiento = mov_almacen.tipMovimiento;
                                        itemFrm.oLoteEntidad.idDocumentoAlmacen = mov_almacen.idDocumentoAlmacen;
                                        itemFrm.oLoteEntidad.UsuarioModificacion = mov_almacen.UsuarioModificacion;

                                        if (itemFrm.oLoteEntidad.Opcion == (int)EnumOpcionGrabar.Insertar)
                                        {
                                            new LoteAD().InsertarLote(itemFrm.oLoteEntidad);
                                        }
                                        else
                                        {
                                            new LoteAD().ActualizarLote(itemFrm.oLoteEntidad);
                                        }
                                    }

                                    Tipo = "IN";
                                    new AlmacenArticuloLoteAD().ActualizarStockValorizado(itemFrm.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, mov_almacen.idOperacion, itemFrm.idArticulo, itemFrm.Lote, itemFrm.Cantidad, itemFrm.ImpCostoUnitarioBase, itemFrm.ImpCostoUnitarioRefe, Tipo);
                                }
                                //Si es una Modificacion al Item
                                else
                                {
                                    itemFrm.idDocumentoAlmacen = mov_almacen.idDocumentoAlmacen;
                                    itemFrm.tipMovimiento = mov_almacen.tipMovimiento;

                                    if (ActualizarLote)
                                    {
                                        itemFrm.Revisar = true;
                                    }

                                    new MovimientoAlmacenItemAD().ActualizarMovimiento_Almacen_Item(itemFrm);

                                    if (itemFrm.oLoteEntidad != null)
                                    {
                                        if (itemFrm.Lote != "0000000" && mov_almacen.tipMovimiento != 305002)
                                        {
                                            itemFrm.oLoteEntidad.Lote = itemFrm.Lote;
                                            itemFrm.oLoteEntidad.tipMovimiento = mov_almacen.tipMovimiento;
                                            itemFrm.oLoteEntidad.idDocumentoAlmacen = mov_almacen.idDocumentoAlmacen;
                                            itemFrm.oLoteEntidad.UsuarioModificacion = mov_almacen.UsuarioModificacion;

                                            if (itemFrm.oLoteEntidad.Opcion == (int)EnumOpcionGrabar.Insertar)
                                            {
                                                new LoteAD().InsertarLote(itemFrm.oLoteEntidad);
                                            }
                                            else
                                            {
                                                new LoteAD().ActualizarLote(itemFrm.oLoteEntidad);
                                            }
                                        }
                                    }

                                    // Quitando el Stock Eliminado.
                                    MovimientoAlmacenItemE oItemAntes = (from x in oMovAlmacenAntes.ListaAlmacenItem
                                                                         where x.idEmpresa == itemFrm.idEmpresa &&
                                                                               x.tipMovimiento == itemFrm.tipMovimiento &&
                                                                               x.idDocumentoAlmacen == itemFrm.idDocumentoAlmacen &&
                                                                               x.idItem == itemFrm.idItem
                                                                         select x).FirstOrDefault();
                                    if (oItemAntes != null)
                                    {
                                        new AlmacenArticuloLoteAD().ActualizarStockValorizado(oItemAntes.idEmpresa, AnioPeriodoAntes, MesPeriodoAntes, AlmacenAntes, oMovAlmacenAntes.idOperacion, oItemAntes.idArticulo, oItemAntes.Lote, oItemAntes.Cantidad, oItemAntes.ImpCostoUnitarioBase, oItemAntes.ImpCostoUnitarioRefe, "AN");
                                    }

                                    // Actualizando el Stock Nuevo.
                                    Tipo = "AC";
                                    new AlmacenArticuloLoteAD().ActualizarStockValorizado(itemFrm.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, mov_almacen.idOperacion, itemFrm.idArticulo, itemFrm.Lote, itemFrm.Cantidad, itemFrm.ImpCostoUnitarioBase, itemFrm.ImpCostoUnitarioRefe, Tipo);
                                }                                
                            }
                        }

                        //Si hay Orden de Compra
                        if (OcCompleta != null)
                        {
                            Decimal CantMovAlmacen = 0;
                            Boolean Encontro = false;

                            if (OcCompleta.ListaOrdenesCompras != null && OcCompleta.ListaOrdenesCompras.Count > 0)
                            {
                                foreach (OrdenCompraItemE itemOc in OcCompleta.ListaOrdenesCompras)
                                {
                                    Encontro = false;

                                    foreach (MovimientoAlmacenItemE itemMov in oListaItem)
                                    {
                                        CantMovAlmacen = itemMov.Cantidad;

                                        if (itemOc.idEmpresa == itemMov.idEmpresa && itemOc.idOrdenCompra == mov_almacen.idOrdenCompra && itemOc.idItem == Convert.ToInt32(itemMov.idItemCompra))
                                        {
                                            if (CantMovAlmacen != itemOc.CanIngresada)
                                            {
                                                if (CantMovAlmacen > itemOc.CanIngresada)
                                                {
                                                    throw new Exception("La cantidad ingresada no puede ser mayor a la cantidad de la OC.");
                                                }
                                                else if (CantMovAlmacen < itemOc.CanIngresada)
                                                {
                                                    itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.AP.ToString();
                                                }
                                                else
                                                {
                                                    itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.AT.ToString();
                                                }

                                                itemOc.CanIngresada = CantMovAlmacen;
                                                new OrdenCompraItemAD().ActualizarCantIngOc(itemOc); 
                                            }

                                            Encontro = true;
                                            break;
                                        }
                                    }

                                    if (!Encontro)
                                    {
                                        itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.PN.ToString();
                                        itemOc.CanIngresada = 0;
                                        new OrdenCompraItemAD().ActualizarCantIngOc(itemOc);
                                    }
                                }
                            }
                        }

                        //Si se trata de una transferencia...
                        if (mov_almacen.indPorAsociar)
                        {
                            ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("ING");

                            if (oTipoMovimiento == null)
                            {
                                throw new Exception("No existe Tipos de Movimientos para los Ingresos.");
                            }

                            if (mov_almacen.idDocumentoAlmacenAsociado > 0)
                            {
                                AnularMovimientoAlmacen(mov_almacen.idEmpresa, oTipoMovimiento.IdParTabla, mov_almacen.idDocumentoAlmacenAsociado.Value, mov_almacen.UsuarioModificacion);
                            }

                            GenerarIngresoTransferencia(mov_almacen, oTipoMovimiento.IdParTabla, mov_almacen.UsuarioRegistro);
                        }
                    }

                    oTrans.Complete();
                }

                return mov_almacen;
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

        public MovimientoAlmacenE InsertarMovimientoAlmacen(MovimientoAlmacenE movimiento_almacen)
        {
            try
            {
                return new MovimientoAlmacenAD().InsertarMovimientoAlmacen(movimiento_almacen);
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

        public MovimientoAlmacenE ActualizarMovimientoAlmacen(MovimientoAlmacenE movimiento_almacen)
        {
            try
            {
                return new MovimientoAlmacenAD().ActualizarMovimientoAlmacen(movimiento_almacen);
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

        public Int32 EliminarMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            try
            {
                int Resultado;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Resultado = new MovimientoAlmacenAD().EliminarMovimientoAlmacen(idEmpresa, tipMovimiento, idDocumentoAlmacen);
                    oTrans.Complete();
                }

                return Resultado;
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

        public Int32 AnularMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, String UsuarioAnula)
        {
            try
            {
                int resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    resp = new MovimientoAlmacenAD().AnularMovimientoAlmacen(idEmpresa, tipMovimiento, idDocumentoAlmacen, UsuarioAnula);

                    //Devolviendo las cantidades a la Orden de Compra
                    MovimientoAlmacenE MovimientoAlmacen = new MovimientoAlmacenAD().ObtenerMovimientoAlmacen(idEmpresa, tipMovimiento, idDocumentoAlmacen);
                    MovimientoAlmacen.ListaAlmacenItem = new MovimientoAlmacenItemAD().ListarMovimiento_Almacen_Item(idEmpresa, idDocumentoAlmacen).OrderBy(x => x.idItem).ToList();

                    if (MovimientoAlmacen != null)
                    {
                        if (MovimientoAlmacen.idOrdenCompra != null && MovimientoAlmacen.idOrdenCompra != 0)
                        {
                            OrdenCompraE OrdenCompra = new OrdenCompraAD().ObtenerOrdenCompra(idEmpresa, Convert.ToInt32(MovimientoAlmacen.idOrdenCompra));
                            OrdenCompra.ListaOrdenesCompras = new OrdenCompraItemAD().ListarOrdenCompraItem(idEmpresa, Convert.ToInt32(MovimientoAlmacen.idOrdenCompra));
                            String AnioPeriodo = String.Empty;
                            String MesPeriodo = String.Empty;
                            Int32 Almacen = 0;
                            Decimal CantMovimiento = 0;

                            foreach (MovimientoAlmacenItemE itemAlmacen in MovimientoAlmacen.ListaAlmacenItem)
                            {
                                CantMovimiento = itemAlmacen.Cantidad;

                                foreach (OrdenCompraItemE itemOc in OrdenCompra.ListaOrdenesCompras)
                                {
                                    if (itemOc.idEmpresa == itemAlmacen.idEmpresa && itemOc.idOrdenCompra == MovimientoAlmacen.idOrdenCompra && itemOc.idItem == Convert.ToInt32(itemAlmacen.idItemCompra))
                                    {
                                        itemOc.CanIngresada -= CantMovimiento;

                                        if (itemOc.CanIngresada == 0)
                                        {
                                            itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.PN.ToString(); //Item Pendiente
                                        }
                                        else if (itemOc.CanIngresada > 0)
                                        {
                                            itemOc.tipEstadoAtencion = EnumEstadoAtencionOC.AP.ToString(); //Item Atendido Parcialmente
                                        }

                                        new OrdenCompraItemAD().ActualizarCantIngOc(itemOc);
                                    }
                                }

                                AnioPeriodo = MovimientoAlmacen.fecProceso.Substring(0, 4);//Convert.ToString(MovimientoAlmacen.fecProceso.Year);
                                MesPeriodo = MovimientoAlmacen.fecProceso.Substring(4, 2);//MovimientoAlmacen.fecProceso.ToString("MM");
                                Almacen = Convert.ToInt32(MovimientoAlmacen.idAlmacen);

                                new AlmacenArticuloLoteAD().ActualizarStockValorizado(itemAlmacen.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, MovimientoAlmacen.idOperacion, itemAlmacen.idArticulo, itemAlmacen.Lote, CantMovimiento, itemAlmacen.ImpCostoUnitarioBase, itemAlmacen.ImpCostoUnitarioRefe, "AN");
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return resp;
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

        public List<MovimientoAlmacenE> ListarMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, string desde, string hasta, Int32 idconcepto, Boolean IncluirAnulados)
        {
            try
            {
                return new MovimientoAlmacenAD().ListarMovimientoAlmacen(idEmpresa, tipMovimiento, idAlmacen, desde, hasta, idconcepto, IncluirAnulados);
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

        public void ProcesoGenerarSalidaAlmacen(Int32 idEmpresa, Int32 TipoArticulo, String idCCosto, string vd_desde, string vd_hasta)
        {
            try
            {
                new MovimientoAlmacenAD().ProcesoGenerarSalidaAlmacen(idEmpresa, TipoArticulo, idCCosto, vd_desde, vd_hasta);
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

        public List<MovimientoAlmacenE> ListarMovimientoAlmacenPorArticulo(Int32 idEmpresa, Int32 idArticulo)
        {
            try
            {
                return new MovimientoAlmacenAD().ListarMovimientoAlmacenPorArticulo(idEmpresa, idArticulo);
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

        public List<MovimientoAlmacenE> ListarMovEgresosPorAsociar(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen)
        {
            try
            {
                return new MovimientoAlmacenAD().ListarMovEgresosPorAsociar(idEmpresa, tipMovimiento, idAlmacen);
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

        public MovimientoAlmacenE ObtenerMovimientoAlmacen(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen)
        {
            try
            {
                return new MovimientoAlmacenAD().ObtenerMovimientoAlmacen(idEmpresa, tipMovimiento, idDocumentoAlmacen);
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

        public List<MovimientoAlmacenE> ObtenerMovAlmacenporID(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Int32 idAlmacen)
        {
            try
            {
                return new MovimientoAlmacenAD().ObtenerMovAlmacenporID(idEmpresa, tipMovimiento, idDocumentoAlmacen, idAlmacen);
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

        public MovimientoAlmacenE ObtenerMovimientoAlmacenCompleto(Int32 idEmpresa, Int32 tipMovimiento, Int32 idDocumentoAlmacen, Boolean ConUnidadMed = false, String RevisarSalidas = "N")
        {
            try
            {
                MovimientoAlmacenE MovimientoAlmacen = new MovimientoAlmacenAD().ObtenerMovimientoAlmacen(idEmpresa, tipMovimiento, idDocumentoAlmacen);

                if (MovimientoAlmacen != null)
                {
                    MovimientoAlmacen.ListaAlmacenItem = new MovimientoAlmacenItemAD().ListarMovimiento_Almacen_Item(idEmpresa, idDocumentoAlmacen).OrderBy(x => x.idItem).ToList();

                    for (int i = 0; i < MovimientoAlmacen.ListaAlmacenItem.Count; i++)
                    {
                        MovimientoAlmacen.ListaAlmacenItem[i].oLoteEntidad = new LoteAD().ObtenerLote(idEmpresa, MovimientoAlmacen.ListaAlmacenItem[i].Lote, MovimientoAlmacen.idAlmacen);

                        if (MovimientoAlmacen.ListaAlmacenItem[i].oLoteEntidad == null)
                        {
                            MovimientoAlmacen.ListaAlmacenItem[i].oLoteEntidad = new LoteE();
                        }

                        MovimientoAlmacen.ListaAlmacenItem[i].numItem = (i + 1).ToString("0000");

                        if (ConUnidadMed)
                        {
                            MovimientoAlmacen.ListaAlmacenItem[i].oArticulo = new ArticuloServAD().UnidMedidasArticulos(MovimientoAlmacen.ListaAlmacenItem[i].idEmpresa, MovimientoAlmacen.ListaAlmacenItem[i].idArticulo);
                        }

                        if (RevisarSalidas == "S" && tipMovimiento == 305001 && MovimientoAlmacen.VerificaLote) //Solo si es ingreso y el almacén con su campo Verifica Lote es Verdadero
                        {
                            if (MovimientoAlmacen.ListaMovimientoSalidas == null)
                            {
                                MovimientoAlmacen.ListaMovimientoSalidas = new List<MovimientoAlmacenE>();
                            }

                            MovimientoAlmacen.ListaMovimientoSalidas.AddRange(new MovimientoAlmacenAD().ListarMovimientoSalidasAlmacen(idEmpresa, MovimientoAlmacen.ListaAlmacenItem[i].idArticulo, MovimientoAlmacen.ListaAlmacenItem[i].Lote));
                        }
                    }
                }

                return MovimientoAlmacen;
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
 
        public List<MovimientoAlmacenE> ListarIngresosCompraPendiente(Int32 idEmpresa, String CodMoneda)
        {
            try
            {
                return new MovimientoAlmacenAD(). ListarIngresosCompraPendiente(idEmpresa,CodMoneda);
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

        public List<MovimientoAlmacenE> ListarMovimientosPorOrdenCompra(Int32 idEmpresa, Int32 idOrdenCompra, String ConDetalle = "N")
        {
            try
            {
                List<MovimientoAlmacenE> oListaRetorno = new MovimientoAlmacenAD().ListarMovimientosPorOrdenCompra(idEmpresa, idOrdenCompra);

                if (ConDetalle == "S")
                {
                    foreach (MovimientoAlmacenE item in oListaRetorno)
                    {
                        item.ListaAlmacenItem = new MovimientoAlmacenItemAD().ListarMovimiento_Almacen_Item(idEmpresa, item.idDocumentoAlmacen).OrderBy(x => x.idItem).ToList();
                    }
                }

                return oListaRetorno;
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

        public Boolean GenerarHojaCostos(MovimientoAlmacenE movAlmacenCab, Int32 idLocal, String Usuario)
        {
            try
            {
                //Obteniendo los Movimiento del Almacén
                MovimientoAlmacenE oMovimientoAlmacen = new MovimientoAlmacenAD().ObtenerMovimientoAlmacen(movAlmacenCab.idEmpresa, movAlmacenCab.tipMovimiento, movAlmacenCab.idDocumentoAlmacen);
                oMovimientoAlmacen.ListaAlmacenItem = new MovimientoAlmacenItemAD().ListarMovimiento_Almacen_Item(movAlmacenCab.idEmpresa, movAlmacenCab.idDocumentoAlmacen).OrderBy(x => x.idItem).ToList();
                //Ordenes de Compra
                OrdenCompraE ordCompra = new OrdenCompraAD().ObtenerOrdenCompra(oMovimientoAlmacen.idEmpresa, Convert.ToInt32(oMovimientoAlmacen.idOrdenCompra));

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (ordCompra == null)
                    {
                        throw new Exception("No se puede generar ninguna Hoja de Costo porque no tiene ninguna O.C. asociada");
                    }

                    ordCompra.ListaOrdenesCompras = new OrdenCompraItemAD().ListarOrdenCompraItem(ordCompra.idEmpresa, ordCompra.idOrdenCompra);
                    //Para saber si la hoja de Costo ya ha sido generada en un movimiento anterior...
                    HojaCostoE oHojaCosto = new HojaCostoAD().ObtenerHojaCostoPorOC(ordCompra.idEmpresa, ordCompra.idLocal, ordCompra.idOrdenCompra);

                    if (oHojaCosto == null)
                    {
                        //Iniciando la variable
                        oHojaCosto = new HojaCostoE();

                        #region Insertar

                        foreach (OrdenCompraItemE item in ordCompra.ListaOrdenesCompras)
                        {
                            item.ArticuloServ = new ArticuloServAD().ObtenerArticuloServ(item.idEmpresa, item.idArticuloServ);
                        }

                        #region Cabecera

                        //Obteniendo la Provisión de la O.C.
                        ProvisionesE provCompra = new ProvisionesAD().ObtenerProvisionPorOC(oMovimientoAlmacen.idEmpresa, ordCompra.idOrdenCompra);
                        //Tipo condición de compra
                        ParTabla oCondicionCompra = new ParTablaAD().ParTablaPorNemo("CC49");

                        oHojaCosto.idEmpresa = oMovimientoAlmacen.idEmpresa;
                        oHojaCosto.idLocal = idLocal;
                        //oHojaCosto.Fecha = oMovimientoAlmacen.fecProceso.Date; //Revisar
                        oHojaCosto.idOrdenCompra = oMovimientoAlmacen.idOrdenCompra.Value;
                        oHojaCosto.numOrdenCompra = oMovimientoAlmacen.numOrdenCompra;
                        oHojaCosto.Descripcion = ordCompra.Observacion;
                        oHojaCosto.Estado = "F";
                        //oHojaCosto.FechaCierreCosto = oMovimientoAlmacen.fecProceso.Date; //Revisar

                        //Contable
                        if (provCompra != null)
                        {
                            if (provCompra.EstadoProvision == "PR")
                            {
                                oHojaCosto.AnioPeriodo = provCompra.AnioPeriodo;
                                oHojaCosto.MesPeriodo = provCompra.MesPeriodo;
                                oHojaCosto.idComprobante = provCompra.idComprobante;
                                oHojaCosto.NumFile = provCompra.numFile;
                                oHojaCosto.NumVoucher = provCompra.numVoucher;
                            }
                            else
                            {
                                oHojaCosto.AnioPeriodo = String.Empty;
                                oHojaCosto.MesPeriodo = String.Empty;
                                oHojaCosto.idComprobante = String.Empty;
                                oHojaCosto.NumFile = String.Empty;
                                oHojaCosto.NumVoucher = String.Empty;
                            }
                        }
                        else
                        {
                            oHojaCosto.AnioPeriodo = String.Empty;
                            oHojaCosto.MesPeriodo = String.Empty;
                            oHojaCosto.idComprobante = String.Empty;
                            oHojaCosto.NumFile = String.Empty;
                            oHojaCosto.NumVoucher = String.Empty;
                        }

                        //De la Hoja de Costo
                        oHojaCosto.AnioPeriodoCosto = String.Empty;
                        oHojaCosto.MesPeriodoCosto = String.Empty;
                        oHojaCosto.idComprobanteCosto = String.Empty;
                        oHojaCosto.NumFileCosto = String.Empty;
                        oHojaCosto.NumVoucherCosto = String.Empty;

                        oHojaCosto.NumCarperta = String.Empty;
                        oHojaCosto.idPersona = oMovimientoAlmacen.idPersona != null ? oMovimientoAlmacen.idPersona : null;
                        oHojaCosto.tipFormaPago = oCondicionCompra.IdParTabla;
                        oHojaCosto.idDocumentoFact = oMovimientoAlmacen.idDocumento;
                        //oHojaCosto.fecFacturaComer = oMovimientoAlmacen.fecDocumento; //Revisar
                        oHojaCosto.FactComercial = String.IsNullOrWhiteSpace(oMovimientoAlmacen.serDocumento) ? oMovimientoAlmacen.numDocumento : oMovimientoAlmacen.serDocumento + "-" + oMovimientoAlmacen.numDocumento;
                        oHojaCosto.DUA = String.Empty;
                        oHojaCosto.fecDua = (DateTime?)null;
                        oHojaCosto.AgAduana = String.Empty;
                        oHojaCosto.Transporte = "0";
                        oHojaCosto.FechaLlegadaPuerto = null;
                        oHojaCosto.NroBultos = 0;
                        oHojaCosto.CiadeSeguros = String.Empty;
                        oHojaCosto.idMoneda = ordCompra.idMoneda;
                        oHojaCosto.TipoCambio = oMovimientoAlmacen.tipCambio;
                        oHojaCosto.Embarque = String.Empty;
                        oHojaCosto.FechaLlegadaAduana = null;
                        oHojaCosto.FechaLlegadaAlmacen = null;
                        oHojaCosto.Secuencia = String.Empty;
                        oHojaCosto.Peso = 0;
                        oHojaCosto.Calculo = "F";
                        oHojaCosto.Prorrateo = "R";
                        oHojaCosto.PorcAdvalorem = 0;
                        oHojaCosto.PorcIgvCif = 0;
                        oHojaCosto.PorcIgvAduana = 0;
                        oHojaCosto.Grupo = String.Empty;
                        oHojaCosto.FlagControl = false;
                        oHojaCosto.TotalCantidad = 0;
                        oHojaCosto.TotalPeso = 0;
                        oHojaCosto.TotalVolumen = 0;
                        oHojaCosto.TotalFob = 0;
                        oHojaCosto.TotalFlete = 0;
                        oHojaCosto.TotalSeguro = 0;
                        oHojaCosto.TotalSgs = 0;
                        oHojaCosto.TotalValorCifME = 0;
                        oHojaCosto.TotalValorCifMN = 0;
                        oHojaCosto.TotalAdvalorem = 0;
                        oHojaCosto.TotalGstoAduana = 0;
                        oHojaCosto.TotalGstoComision = 0;
                        oHojaCosto.TotalGstoBancario = 0;
                        oHojaCosto.TotalGstoOtros = 0;
                        oHojaCosto.TotalCostoImportacion = 0;
                        oHojaCosto.Transferido = false;
                        oHojaCosto.UsuarioRegistro = Usuario;

                        #endregion

                        List<OrdenCompraItemE> oListaOtros = new List<OrdenCompraItemE>(from x in ordCompra.ListaOrdenesCompras where x.Nemo == "O10" select x).ToList();
                        ordCompra.ListaOrdenesCompras = new List<OrdenCompraItemE>(ordCompra.ListaOrdenesCompras.Except(oListaOtros).ToList());
                        //Decimal TotalInvoice = ordCompra.ListaOrdenesCompras.Sum(x => x.impTotalItem);
                        //Decimal TotalCargos = oListaOtros.Sum(x => x.impTotalItem);
                        var tmp = ordCompra.ListaOrdenesCompras.GroupBy(x => x.codCategoria).Select(y => new { codCategoria = y.Key, Total = y.Sum(x => x.impTotalItem) });
                        var tmpOtros = oListaOtros.GroupBy(x => x.codCategoriaAsoc).Select(y => new { codCategoriaAsoc = y.Key, Total = y.Sum(x => x.impTotalItem) });

                        //Variable para el detalle...
                        HojaCostoItemE oDetalle = null;

                        #region Llenando los Items Normales

                        foreach (MovimientoAlmacenItemE itemMovimiento in oMovimientoAlmacen.ListaAlmacenItem)
                        {
                            foreach (OrdenCompraItemE item in ordCompra.ListaOrdenesCompras)
                            {
                                if (itemMovimiento.idItemCompra == item.idItem)
                                {
                                    oDetalle = new HojaCostoItemE
                                    {
                                        idEmpresa = item.idEmpresa,
                                        idLocal = idLocal,
                                        idItemOC = item.idItem,
                                        nNivel = 0,
                                        Nivel = "D",
                                        Nivelinv = "A",
                                        PartidaArancelaria = String.Empty,
                                        idArticulo = item.idArticuloServ,
                                        Descripcion = String.Empty,
                                        Cantidad = item.CanOrdenada,
                                        PesoUnitario = itemMovimiento.PesoUnitario / item.CanOrdenada,
                                        Peso = itemMovimiento.PesoUnitario,
                                        idTipoUmedida = item.ArticuloServ.codTipoMedPresentacion,
                                        idUmedida = item.ArticuloServ.codUniMedPresentacion,
                                        FobUnitario = item.impPrecioUnitario,
                                        ValorFob = item.impVentaItem,
                                        ValorPeso = 0,
                                        ValorCif = 0
                                    };

                                    Decimal TotalCargoCategoria = 0;
                                    Decimal TotalInvoiceCategoria = 0;

                                    // Cargar los otros Cargos
                                    foreach (var itemOtros in tmpOtros)
                                    {
                                        if (itemOtros.codCategoriaAsoc == item.codCategoria)
                                        {
                                            TotalCargoCategoria = itemOtros.Total;
                                        }
                                    }

                                    // Cargar los otros Cargos
                                    foreach (var itemInvoice in tmp)
                                    {
                                        if (itemInvoice.codCategoria == item.codCategoria)
                                        {
                                            TotalInvoiceCategoria = itemInvoice.Total;
                                        }
                                    }

                                    if (TotalInvoiceCategoria > 0)
                                     {
                                      item.OtrosCargos = Decimal.Round((item.impTotalItem * TotalCargoCategoria) / TotalInvoiceCategoria, 2);
                                     }
                                    else
                                     {
                                        item.OtrosCargos = Decimal.Round(0,2);
                                     }

                                    oDetalle.OtrosCostos = item.OtrosCargos;
                                    oDetalle.TCambio = 1;
                                    oDetalle.ValorTotalDolares = item.impTotalItem + item.OtrosCargos;
                                    oDetalle.AdValorem = 0;
                                    oDetalle.GstoAduana = 0;
                                    oDetalle.GstoComision = 0;
                                    oDetalle.GstoSeguro = 0;
                                    oDetalle.GstoBancario = 0;
                                    oDetalle.GstoOtros = 0;
                                    oDetalle.CostoTotalMN = 0;
                                    oDetalle.CostoUnitarioMN = 0;
                                    oDetalle.CostoTotalME = item.impTotalItem + item.OtrosCargos;
                                    oDetalle.CostoUnitarioME = oDetalle.CostoTotalME / (item.CanOrdenada);
                                    oDetalle.FactorVenta = 0;
                                    oDetalle.PrecioVenta = item.impVentaItem;
                                    oDetalle.Utilidad = 0;
                                    oDetalle.UsuarioRegistro = Usuario;

                                    oHojaCosto.ListaHojaCostoItem.Add(oDetalle);
                                }
                            }
                        }

                        #endregion

                        #region Llenando los items de gastos

                        foreach (OrdenCompraItemE item in oListaOtros)
                        {
                            oDetalle = new HojaCostoItemE
                            {
                                idEmpresa = item.idEmpresa,
                                idLocal = idLocal,
                                idItemOC = item.idItem,
                                nNivel = 0,
                                Nivel = "S",
                                Nivelinv = "A",
                                PartidaArancelaria = String.Empty,
                                idArticulo = item.idArticuloServ,
                                Descripcion = String.Empty,
                                Cantidad = item.CanOrdenada,
                                PesoUnitario = 0,
                                Peso = 0,
                                idTipoUmedida = 0,
                                idUmedida = 0,

                                FobUnitario = item.impPrecioUnitario,
                                ValorFob = item.impVentaItem,
                                ValorPeso = 0,
                                ValorCif = 0
                            };
                            item.OtrosCargos = 0;
                            oDetalle.OtrosCostos = 0;
                            oDetalle.TCambio = 1;
                            oDetalle.ValorTotalDolares = 0;
                            oDetalle.AdValorem = 0;
                            oDetalle.GstoAduana = 0;
                            oDetalle.GstoComision = 0;
                            oDetalle.GstoSeguro = 0;
                            oDetalle.GstoBancario = 0;
                            oDetalle.GstoOtros = 0;
                            oDetalle.CostoTotalMN = 0;
                            oDetalle.CostoUnitarioMN = 0;
                            oDetalle.CostoTotalME = 0;
                            oDetalle.CostoUnitarioME = 0;
                            oDetalle.FactorVenta = 0;
                            oDetalle.PrecioVenta = item.impVentaItem;
                            oDetalle.Utilidad = 0;
                            oDetalle.UsuarioRegistro = Usuario;

                            oHojaCosto.ListaHojaCostoItem.Add(oDetalle);
                        }

                        #endregion

                        //Ordenando
                        oHojaCosto.ListaHojaCostoItem = (from x in oHojaCosto.ListaHojaCostoItem orderby x.idItemOC select x).ToList();
                        //Insertando la cabecera
                        oHojaCosto = new HojaCostoAD().InsertarHojaCosto(oHojaCosto);

                        //Insertando el detalle
                        foreach (HojaCostoItemE item in oHojaCosto.ListaHojaCostoItem)
                        {
                            item.idHojaCosto = oHojaCosto.idHojaCosto;
                            new HojaCostoItemAD().InsertarHojaCostoItem(item);
                        } 

                        #endregion
                    }
                    else
                    {
                        #region Actualizar

                        //Obteniendo el detalle de la hoja de costo para revisar si existen los articulos
                        List<HojaCostoItemE> oDetalleHojaCosto = new HojaCostoItemAD().ListarHojaCostoItem(oHojaCosto.idEmpresa, oHojaCosto.idLocal, oHojaCosto.idHojaCosto);
                        //oHojaCosto.ListaHojaCostoItem = new HojaCostoItemAD().ListarHojaCostoItem(oHojaCosto.idEmpresa, oHojaCosto.idLocal, oHojaCosto.idHojaCosto);

                        foreach (OrdenCompraItemE item in ordCompra.ListaOrdenesCompras)
                        {
                            item.ArticuloServ = new ArticuloServAD().ObtenerArticuloServ(item.idEmpresa, item.idArticuloServ);
                        }

                        List<OrdenCompraItemE> oListaOtros = new List<OrdenCompraItemE>(from x in ordCompra.ListaOrdenesCompras where x.Nemo == "O10" select x).ToList();
                        ordCompra.ListaOrdenesCompras = new List<OrdenCompraItemE>(ordCompra.ListaOrdenesCompras.Except(oListaOtros).ToList());
                        var tmp = ordCompra.ListaOrdenesCompras.GroupBy(x => x.codCategoria).Select(y => new { codCategoria = y.Key, Total = y.Sum(x => x.impTotalItem) });
                        var tmpOtros = oListaOtros.GroupBy(x => x.codCategoriaAsoc).Select(y => new { codCategoriaAsoc = y.Key, Total = y.Sum(x => x.impTotalItem) });

                        ////Variable para el detalle...
                        HojaCostoItemE oDetalle = null;

                        #region Llenando el detalle

                        foreach (MovimientoAlmacenItemE itemMovimiento in oMovimientoAlmacen.ListaAlmacenItem)
                        {
                            foreach (OrdenCompraItemE item in ordCompra.ListaOrdenesCompras)
                            {
                                if (itemMovimiento.idItemCompra == item.idItem)
                                {
                                    oDetalle = new HojaCostoItemE
                                    {
                                        idEmpresa = item.idEmpresa,
                                        idLocal = idLocal,
                                        idItemOC = item.idItem,
                                        nNivel = 0,
                                        Nivel = "D",
                                        Nivelinv = "A",
                                        PartidaArancelaria = String.Empty,
                                        idArticulo = item.idArticuloServ,
                                        Descripcion = String.Empty,
                                        Cantidad = item.CanOrdenada,
                                        PesoUnitario = itemMovimiento.PesoUnitario / item.CanOrdenada,
                                        Peso = itemMovimiento.PesoUnitario,
                                        idTipoUmedida = item.ArticuloServ.codTipoMedPresentacion,
                                        idUmedida = item.ArticuloServ.codUniMedPresentacion,
                                        FobUnitario = item.impPrecioUnitario,
                                        ValorFob = item.impVentaItem,
                                        ValorPeso = 0,
                                        ValorCif = 0
                                    };

                                    Decimal TotalCargoCategoria = 0;
                                    Decimal TotalInvoiceCategoria = 0;

                                    // Cargar los otros Cargos
                                    foreach (var itemOtros in tmpOtros)
                                    {
                                        if (itemOtros.codCategoriaAsoc == item.codCategoria)
                                        {
                                            TotalCargoCategoria = itemOtros.Total;
                                        }
                                    }

                                    // Cargar los otros Cargos
                                    foreach (var itemInvoice in tmp)
                                    {
                                        if (itemInvoice.codCategoria == item.codCategoria)
                                        {
                                            TotalInvoiceCategoria = itemInvoice.Total;
                                        }
                                    }

                                    if (TotalInvoiceCategoria != 0)
                                    {
                                        item.OtrosCargos = Decimal.Round((item.impTotalItem * TotalCargoCategoria) / TotalInvoiceCategoria, 2);
                                    }
                                    else
                                    {
                                        item.OtrosCargos = 0;
                                    }

                                    oDetalle.OtrosCostos = item.OtrosCargos;
                                    oDetalle.TCambio = 1;
                                    oDetalle.ValorTotalDolares = item.impTotalItem + item.OtrosCargos;
                                    oDetalle.AdValorem = 0;
                                    oDetalle.GstoAduana = 0;
                                    oDetalle.GstoComision = 0;
                                    oDetalle.GstoSeguro = 0;
                                    oDetalle.GstoBancario = 0;
                                    oDetalle.GstoOtros = 0;
                                    oDetalle.CostoTotalMN = 0;
                                    oDetalle.CostoUnitarioMN = 0;
                                    oDetalle.CostoTotalME = item.impTotalItem + item.OtrosCargos;
                                    oDetalle.CostoUnitarioME = oDetalle.CostoTotalME / (item.CanOrdenada);
                                    oDetalle.FactorVenta = 0;
                                    oDetalle.PrecioVenta = item.impVentaItem;
                                    oDetalle.Utilidad = 0;

                                    //Si encuentra es nuevo sino actualizar
                                    HojaCostoItemE ItemTemp = oDetalleHojaCosto.Find
                                    (
                                        delegate (HojaCostoItemE p) { return p.idItemOC == item.idItem; }
                                    );

                                    if (ItemTemp == null)
                                    {
                                        oDetalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                                        oDetalle.UsuarioRegistro = Usuario;
                                    }
                                    else
                                    {
                                        oDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                        oDetalle.item = ItemTemp.item;
                                        oDetalle.UsuarioModificacion = Usuario;
                                    }

                                    oHojaCosto.ListaHojaCostoItem.Add(oDetalle);
                                }
                            }
                        }

                        #endregion

                        #region Insertando o actualizando el detalle

                        foreach (HojaCostoItemE item in oHojaCosto.ListaHojaCostoItem)
                        {
                            item.idHojaCosto = oHojaCosto.idHojaCosto;

                            switch (item.Opcion)
                            {
                                case (Int32)EnumOpcionGrabar.Insertar:

                                    new HojaCostoItemAD().InsertarHojaCostoItem(item);
                                    break;
                                case (Int32)EnumOpcionGrabar.Actualizar:

                                    new HojaCostoItemAD().ActualizarHojaCostoItem(item);
                                    break;
                                default:
                                    break;
                            }
                        }

                        #endregion 

                        #endregion Actualizar
                    }

                    oTrans.Complete();
                }

                return true;
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

        public MovimientoAlmacenE ActualizarMovimientoTrans(MovimientoAlmacenE movimientoalmacen)
        {
            try
            {
                return new MovimientoAlmacenAD().ActualizarMovimientoTrans(movimientoalmacen);
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

        public List<MovimientoAlmacenE> GenerarAperturaAlmacen(Int32 idEmpresa, Int32 idAlmacen, String Anio, String Mes, string FechaIngreso, String Usuario)
        {
            try
            {
                List<MovimientoAlmacenE> oMovimiento = null;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    oMovimiento = new MovimientoAlmacenAD().GenerarAperturaAlmacen(idEmpresa, idAlmacen, Anio, Mes, FechaIngreso,Usuario);
                    oTrans.Complete();
                }

                return oMovimiento;
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

        public List<MovimientoAlmacenE> MovimientoAlmacenPorTipArticulo(Int32 idEmpresa, Int32 tipMovimiento, Int32 idAlmacen, Int32 tipArticulo, Int32 idOperacion, string fecIni, string fecFin)
        {
            try
            {
                List<MovimientoAlmacenE> oListaMovimientos = new MovimientoAlmacenAD().MovimientoAlmacenPorTipArticulo(idEmpresa, tipMovimiento, idAlmacen, tipArticulo, idOperacion, fecIni, fecFin);

                foreach (MovimientoAlmacenE item in oListaMovimientos)
                {
                    item.CostoTotalMovS = Decimal.Round(item.CostoMovS * item.Cantidad, 6, MidpointRounding.AwayFromZero);
                    item.CostoTotalMovD = Decimal.Round(item.CostoMovD * item.Cantidad, 6, MidpointRounding.AwayFromZero);
                    item.CostoTotalKarS = Decimal.Round(item.CostoKarS * item.Cantidad, 6, MidpointRounding.AwayFromZero);
                    item.CostoTotalKarD = Decimal.Round(item.CostoKarD * item.Cantidad, 6, MidpointRounding.AwayFromZero);

                    if (item.Precio > 0)
                    {
                        Decimal Costo = 0;
                        Decimal Venta = item.Precio;
                        Decimal Porcentaje = 0;

                        if (item.idMonedaPrecio == "01")
                        {
                            Costo = item.CostoKarS;
                        }
                        else
                        {
                            Costo = item.CostoKarD;
                        }

                        Porcentaje = (Venta / Costo) * 100M;

                        if (Porcentaje >= 70M && Porcentaje <= 130M)
                        {
                            item.VaEnRojo = false;
                        }
                        else
                        {
                            item.VaEnRojo = true;
                        }
                    }
                    else
                    {
                        item.VaEnRojo = false;
                    }
                }

                return oListaMovimientos;
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

        #region Procedimientos para la importacion de movimientos XLS

        public List<MovimientoAlmacenXLSE> InsertarMovimientoAlmacenXLS(List<MovimientoAlmacenXLSE> oListaMovimientos)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    String codArti = String.Empty;
                    ArticuloServE articulo = null;
                    PaisesE paises = null;

                    foreach (MovimientoAlmacenXLSE item in oListaMovimientos)
                    {
                        #region Articulos

                        if (codArti != item.codArticulo)
                        {
                            articulo = new ArticuloServAD().ObtenerArticuloPorCodArticulo(item.idEmpresa, item.codArticulo);
                        }

                        if (articulo != null)
                        {
                            item.idArticulo = articulo.idArticulo;
                        }
                        else
                        {
                            item.idArticulo = 0;
                        }

                        #endregion

                        #region Paises

                        if (!String.IsNullOrWhiteSpace(item.PaisOrigen))
                        {
                            paises = new PaisesAD().ObtenerPaisesPorNombre(item.PaisOrigen.ToUpper());

                            if (paises != null)
                            {
                                item.idPaisOrigen = paises.idPais;
                            }
                            else
                            {
                                item.idPaisOrigen = 0;
                            }
                        }
                        else
                        {
                            item.idPaisOrigen = 0;
                        }

                        if (!String.IsNullOrWhiteSpace(item.PaisDestino))
                        {
                            paises = new PaisesAD().ObtenerPaisesPorNombre(item.PaisDestino.ToUpper());

                            if (paises != null)
                            {
                                item.idPaisDestino = paises.idPais;
                            }
                            else
                            {
                                item.idPaisDestino = 0;
                            }
                        }
                        else
                        {
                            item.idPaisDestino = 0;
                        }

                        #endregion
                    }

                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<MovimientoAlmacenXLSE>(oListaMovimientos))
                    {
                        new MovimientoAlmacenAD().InsertarMovimientoAlmacenXLS(oDt);
                    }

                    oTrans.Complete();
                }

                return oListaMovimientos;
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

        public Int32 EliminarMovimientoAlmacenXLS(Int32 idEmpresa, Int32 idUsuario)
        {
            try
            {
                return new MovimientoAlmacenAD().EliminarMovimientoAlmacenXLS(idEmpresa, idUsuario);
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

        public Int32 ProcesarMovimientoAlmacenXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            try
            {
                Int32 resp = 0;
                //Procesando la información par saber si hay inconsistencias
                resp = new MovimientoAlmacenAD().ProcesarMovimientoAlmacenXLS(idEmpresa, idLocal, idUsuario);

                if (resp > 0)
                {
                    List<ErrorImportGeneralE> ListaErrores = new ErrorImportGeneralAD().ListarErrorImportGeneral(idEmpresa, 0, idUsuario, "MovimientosXLS");
                    resp = ListaErrores.Count;
                }

                return resp;
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

        public Int32 IntegrarMovimientoAlmacenXLS(List<MovimientoAlmacenXLSE> ListaMovimientos, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    #region Eliminando el registro...

                    var ListaPorBorrar = ListaMovimientos.GroupBy(x => new { x.idEmpresa, x.tipMovimiento, x.idAlmacen, x.tipAlmacen, x.idOperacion, x.fecProceso }).Select(g => g.First()).ToList();

                    foreach (MovimientoAlmacenXLSE item in ListaPorBorrar)
                    {
                        new MovimientoAlmacenAD().AnularMovAlmacenPorParametros(item.idEmpresa, item.tipMovimiento, item.idAlmacen, item.tipAlmacen, item.idOperacion, item.fecProceso.Date, Usuario);
                    }

                    #endregion

                    //Agrupando para ver cuantos movimiento existen
                    var ListaAgrupada = ListaMovimientos.GroupBy(x => new { x.idEmpresa, x.tipMovimiento, x.idAlmacen, x.tipAlmacen } ).Select(p => p.First()).ToList();
                    List<MovimientoAlmacenE> MovReal = new List<MovimientoAlmacenE>();

                    foreach (var item in ListaAgrupada)
                    {
                        Boolean Cab = true;
                        Int32 Corre = 1;
                        MovimientoAlmacenE movimiento = new MovimientoAlmacenE();
                        List<MovimientoAlmacenXLSE> Listita = (from x in ListaMovimientos
                                                               where x.idEmpresa == item.idEmpresa
                                                               && x.tipMovimiento == item.tipMovimiento
                                                               && x.idAlmacen == item.idAlmacen
                                                               && x.tipAlmacen == item.tipAlmacen
                                                               select x).ToList();
                        //Armando el movimiento
                        foreach (MovimientoAlmacenXLSE itemR in Listita)
                        {
                            //Cabecera
                            if (Cab)
                            {
                                movimiento = new MovimientoAlmacenE()
                                {
                                    idEmpresa = itemR.idEmpresa,
                                    tipMovimiento = itemR.tipMovimiento,
                                    idAlmacen = itemR.idAlmacen,
                                    tipAlmacen = itemR.tipAlmacen,
                                    idOperacion = itemR.idOperacion,
                                    //fecProceso = itemR.fecProceso, //Revisar
                                    indFactura = String.IsNullOrWhiteSpace(itemR.idDocumento) == true ? false : true,
                                    idDocumento = itemR.idDocumento,
                                    serDocumento = itemR.serDocumento,
                                    numDocumento = itemR.numDocumento,
                                    //fecDocumento = itemR.fecDocumento, //Revisar
                                    indDocDevolucion = false,
                                    idDocumentoDevolucion = String.Empty,
                                    serDocumentoDevolucion = String.Empty,
                                    numDocumentoDevolucion = String.Empty,
                                    idOrdenCompra = null,
                                    numRequisicion = String.Empty,
                                    idDocumentoRef = itemR.idDocumentoRef,
                                    SerieDocumentoRef = itemR.SerieDocumentoRef,
                                    NumeroDocumentoRef = itemR.NumeroDocumentoRef,
                                    idPersona = null,
                                    idMoneda = itemR.idMoneda,
                                    indCambio = true,
                                    tipCambio = itemR.tipCambio,
                                    UsuarioRegistro = Usuario
                                };

                                Cab = false;
                            }

                            //Detalle
                            MovimientoAlmacenItemE ItemDetalle = new MovimientoAlmacenItemE()
                            {
                                idEmpresa = itemR.idEmpresa,
                                tipMovimiento = itemR.tipMovimiento,
                                numItem = String.Format("{0:0000}", Corre),
                                idArticulo = itemR.idArticulo,
                                Lote = itemR.Lote,
                                idUbicacion = 0,
                                Cantidad = itemR.Cantidad,

                                indCalidad = false,
                                indConformidad = false,
                                idCCostos = String.Empty,
                                idCCostosUso = String.Empty,
                                idArticuloUso = 0,
                                nroEnvases = 0,
                                Valorizado = true,
                                nroParteProd = String.Empty,
                                idItemCompra = null,
                                UsuarioAnula = String.Empty,
                                FechaAnula = null,
                                UsuarioRegistro = Usuario
                            };

                            if (itemR.idMoneda == "01")
                            {
                                ItemDetalle.ImpCostoUnitarioBase = itemR.CostoUnitBase;
                                ItemDetalle.ImpTotalBase = itemR.CostoTotBase;
                                ItemDetalle.ImpCostoUnitarioRefe = Decimal.Round(itemR.CostoUnitBase / itemR.tipCambio, 2);
                                ItemDetalle.ImpTotalRefe = Decimal.Round(itemR.CostoTotBase / itemR.tipCambio, 2);
                            }
                            else
                            {
                                ItemDetalle.ImpCostoUnitarioBase = itemR.CostoUnitRefe;
                                ItemDetalle.ImpTotalBase = itemR.CostoTotRefe;
                                ItemDetalle.ImpCostoUnitarioRefe = Decimal.Round(itemR.CostoUnitRefe * itemR.tipCambio, 2);
                                ItemDetalle.ImpTotalRefe = Decimal.Round(itemR.CostoTotRefe / itemR.tipCambio, 2);
                            }

                            //Agregando el Lote
                            ItemDetalle.oLoteEntidad = new LoteE()
                            {
                                idEmpresa = itemR.idEmpresa,
                                tipMovimiento = itemR.tipMovimiento,
                                indfecProceso = false,
                                fecProceso = itemR.fecProceso,
                                indPersona = false,
                                idPersona = 0,
                                Lote = itemR.Lote,
                                LoteProveedor = itemR.LoteProv,
                                idPaisOrigen = itemR.idPaisOrigen,
                                idPaisProcedencia = itemR.idPaisDestino,
                                Batch = itemR.batch,
                                PorcentajeGerminacion = itemR.Germinacion,
                                fecPrueba = itemR.FechaPrueba,
                                PesoUnitario = 0,
                                nomComercial = String.Empty,
                                codColor = 0,
                                HibOp = String.Empty,
                                Otros = String.Empty,
                                CaCm = String.Empty,
                                Patron = String.Empty,
                                Observacion = String.Empty,
                                EntregadoPor = String.Empty,
                                LoteAlmacen = String.Empty,
                                UsuarioRegistro = Usuario
                            };

                            //Agregando el detalle a la cabecera
                            movimiento.ListaAlmacenItem.Add(ItemDetalle);
                            Corre++;
                        }

                        //Añadiendo a la lista nueva de movimientos...
                        MovReal.Add(movimiento);
                    }

                    //Para saber cuantos movimientos se van a insertar
                    resp = MovReal.Count;

                    //Grabando los movimientos al almacén y al kardex...
                    foreach (MovimientoAlmacenE item in MovReal)
                    {
                        GuardarMovimientoAlmacen(item, EnumOpcionGrabar.Insertar, null, "N");
                    }

                    oTrans.Complete();
                }

                return resp;
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

        public List<kardexE> RevisarLotesKardexXLS(List<MovimientoAlmacenXLSE> ListaMovimientos)
        {
            try
            {
                List<kardexE> ListaKardex = new List<kardexE>();

                foreach (MovimientoAlmacenXLSE item in ListaMovimientos)
                {
                    //Revisando si existe el Lote
                    LoteE oLote = new LoteAD().BuscarLoteExistente(item.idEmpresa, item.Lote);

                    if (oLote != null)
                    {
                        //Listando los movimientos del kardex
                        List<kardexE> oListaKardex = new kardexAD().ListarKardexPorLote(item.idEmpresa, item.Lote);

                        if (oListaKardex.Count > 0)
                        {
                            ListaKardex.AddRange(oListaKardex);
                        }
                        else
                        {
                            ListaKardex.Add(new kardexE() { Lote = item.Lote, numDocMovAlmacen = "NO TIENE MOVIMIENTOS", desAlmacen = String.Empty });
                        }
                    }
                }

                return ListaKardex;
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

        public Int32 EliminarLotesKardexXLS(List<kardexE> ListaMovimientos)
        {
            try
            {
                Int32 resp = 0;

                foreach (kardexE item in ListaMovimientos)
                {
                    resp += new LoteAD().EliminarLotesKardexXLS(item.idEmpresa, item.Lote);
                }

                return resp;
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

        #endregion

        #region Procedimientos Privados

        private Int32 GenerarIngresoTransferencia(MovimientoAlmacenE oMovimientoSalida, int idTipMovIngreso, String Usuario)
        {
            try
            {
                int Resp = 0;

                using (TransactionScope oTran = new TransactionScope())
                {
                    MovimientoAlmacenE oMovimientoIngreso = Colecciones.CopiarEntidad<MovimientoAlmacenE>(oMovimientoSalida);
                    oMovimientoIngreso.ListaAlmacenItem = new List<MovimientoAlmacenItemE>(oMovimientoSalida.ListaAlmacenItem);

                    List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(oMovimientoSalida.tipAlmacen, oMovimientoSalida.idEmpresa, idTipMovIngreso);
                    Int32 idOperacionIng = 0;

                    OperacionE Operacion = oListaOperaciones.Find
                    (
                        delegate (OperacionE op) { return op.indTransferencia == true; }
                    );

                    if (Operacion == null)
                    {
                        throw new Exception("No existe Operacion que indique transferencia en Maestro de Operaciones.");
                    }
                    else
                    {
                        idOperacionIng = Operacion.idOperacion;
                    }

                    oMovimientoIngreso.idDocumentoAlmacen = 0;
                    oMovimientoIngreso.tipMovimiento = idTipMovIngreso;
                    oMovimientoIngreso.idOperacion = idOperacionIng;
                    oMovimientoIngreso.idAlmacen = oMovimientoSalida.idAlmacenDestino;
                    oMovimientoIngreso.indPorAsociar = false;
                    oMovimientoIngreso.idAlmacenOrigen = oMovimientoSalida.idAlmacenDestino;
                    oMovimientoIngreso.idAlmacenDestino = Convert.ToInt32(oMovimientoSalida.idAlmacen);
                    oMovimientoIngreso.tipMovimientoAsociado = oMovimientoSalida.tipMovimiento;
                    oMovimientoIngreso.idDocumentoAlmacenAsociado = oMovimientoSalida.idDocumentoAlmacen;

                    //Insertando el movimiento de ingreso
                    foreach (MovimientoAlmacenItemE item in oMovimientoIngreso.ListaAlmacenItem)
                    {
                        item.idItem = 0;
                        item.Lote = item.Lote;
                    }

                    oMovimientoIngreso = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimientoIngreso, EnumOpcionGrabar.Insertar);

                    //Actualizando el movimiento de salida... solo la cabecera...
                    oMovimientoSalida.indPorAsociar = false;
                    oMovimientoSalida.idAlmacenOrigen = oMovimientoIngreso.idAlmacenDestino;
                    oMovimientoSalida.tipMovimientoAsociado = oMovimientoIngreso.tipMovimiento;
                    oMovimientoSalida.idDocumentoAlmacenAsociado = oMovimientoIngreso.idDocumentoAlmacen;
                    oMovimientoSalida.UsuarioModificacion = Usuario;

                    //Actualizando la salida
                    new MovimientoAlmacenAD().ActualizarMovimientoTrans(oMovimientoSalida);

                    oTran.Complete();
                }

                return Resp;
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

        #endregion

    }
}
