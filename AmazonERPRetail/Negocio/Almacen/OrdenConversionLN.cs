using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Almacen;
using Entidades.Generales;
using AccesoDatos.Almacen;
using AccesoDatos.Generales;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.Almacen
{
    public class OrdenConversionLN 
    {

        public OrdenConversionE GrabarConversion(OrdenConversionE OrdenConversion, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando la cabecera
                            new OrdenConversionAD().ActualizarOrdenConversion(OrdenConversion);

                            //Actualizando el detalle
                            if (OrdenConversion.ListaConverDetalle != null && OrdenConversion.ListaConverDetalle.Count > 0)
                            {
                                foreach (OrdenConversionDetalleE oitem in OrdenConversion.ListaConverDetalle)
                                {
                                    oitem.idOrdenConversion = OrdenConversion.idOrdenConversion;
                                    oitem.idEmpresa = OrdenConversion.idEmpresa;

                                    if (oitem.Opcion == 0)
                                    {
                                        oitem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                    }

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new OrdenConversionDetalleAD().InsertarOrdenConversionDetalle(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new OrdenConversionDetalleAD().ActualizarOrdenConversionDetalle(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            if (OrdenConversion.ListaConverSalida != null && OrdenConversion.ListaConverSalida.Count > 0)
                            {
                                foreach (OrdenConversionSalidaE oitem in OrdenConversion.ListaConverSalida)
                                {
                                    oitem.idOrdenConversion = OrdenConversion.idOrdenConversion;
                                    oitem.idEmpresa = OrdenConversion.idEmpresa;

                                    if (oitem.Opcion == 0)
                                    {
                                        oitem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                    }

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:
                                            new OrdenConversionSalidaAD().InsertarOrdenConversionSalida(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                            new OrdenConversionSalidaAD().ActualizarOrdenConversionSalida(oitem);
                                            break;
                                        case (Int32)EnumOpcionGrabar.Eliminar:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            //Eliminando si la lista de gastos tiene registros
                            if (OrdenConversion.ListaGastosEliminados != null && OrdenConversion.ListaGastosEliminados.Count > 0)
                            {
                                foreach (OrdenConversionGastosE item in OrdenConversion.ListaGastosEliminados)
                                {
                                    new OrdenConversionGastosAD().EliminarOrdenConversionGastos(item.idEmpresa, item.idOrdenConversion, item.item);
                                }
                            }

                            //Insertando los gastos
                            if (OrdenConversion.ListaGastos != null && OrdenConversion.ListaGastos.Count > 0)
                            {
                                foreach (OrdenConversionGastosE item in OrdenConversion.ListaGastos)
                                {
                                    item.idOrdenConversion = OrdenConversion.idOrdenConversion;

                                    if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        new OrdenConversionGastosAD().InsertarOrdenConversionGastos(item);
                                    }
                                    else
                                    {
                                        new OrdenConversionGastosAD().ActualizarOrdenConversionGastos(item);
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            OrdenConversion.Numero = new OrdenConversionAD().GenerarNroConversion(Convert.ToInt32(OrdenConversion.idEmpresa), OrdenConversion.FechaOperacion);

                            //Insertando la cabecera
                            OrdenConversion = new OrdenConversionAD().InsertarOrdenConversion(OrdenConversion);

                            //Insertando el detalle
                            if (OrdenConversion.ListaConverDetalle != null && OrdenConversion.ListaConverDetalle.Count > 0)
                            {
                                foreach (OrdenConversionDetalleE oitem in OrdenConversion.ListaConverDetalle)
                                {
                                    oitem.idOrdenConversion = OrdenConversion.idOrdenConversion;
                                    new OrdenConversionDetalleAD().InsertarOrdenConversionDetalle(oitem);
                                }
                            }

                            //Insertando el detalle
                            if (OrdenConversion.ListaConverSalida != null && OrdenConversion.ListaConverSalida.Count > 0)
                            {
                                foreach (OrdenConversionSalidaE oitem in OrdenConversion.ListaConverSalida)
                                {
                                    oitem.idEmpresa = OrdenConversion.idEmpresa;
                                    oitem.idOrdenConversion = OrdenConversion.idOrdenConversion;
                                    new OrdenConversionSalidaAD().InsertarOrdenConversionSalida(oitem);
                                }
                            }

                            //Insertando Gastos
                            if (OrdenConversion.ListaGastos != null && OrdenConversion.ListaGastos.Count > 0)
                            {
                                foreach (OrdenConversionGastosE item in OrdenConversion.ListaGastos)
                                {
                                    item.idEmpresa = OrdenConversion.idEmpresa;
                                    item.idOrdenConversion = OrdenConversion.idOrdenConversion;

                                    new OrdenConversionGastosAD().InsertarOrdenConversionGastos(item);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return OrdenConversion;
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

        public OrdenConversionE GeneraSalidaAlmacenPorConversion(OrdenConversionE ordenconversion, String Usuario)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 idMovimiento = Variables.Cero;
                    Int32 idOperacion = Variables.Cero;
                    MovimientoAlmacenE oMovimientoAlmacen = null;
                    MovimientoAlmacenItemE oItemMovimiento = null;
                    Int16 numItem = 1;
                    ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("EGR");

                    if (oTipoMovimiento != null)
                    {
                        idMovimiento = oTipoMovimiento.IdParTabla;
                    }
                    else
                    {
                        throw new Exception("No hay ningún tipo de movimiento para las salidas.");
                    }

                    //Agrupando el idAlmacen
                    var ListaAgrupada = ordenconversion.ListaConverSalida.GroupBy(x => x.idAlmacen).Select(p => p.First()).ToList();
                    Boolean EsCabecera = true;
                    TipoCambioE Tica = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, ordenconversion.Fecha.ToString("yyyyMMdd"));

                    if (Tica == null)
                    {
                        throw new Exception(String.Format("El dia {0} no tiene Tipo de Cambio.", ordenconversion.Fecha.Date));
                    }

                    foreach (var item in ListaAgrupada)
                    {
                        //Sacando una nueva lista por almacen
                        List<OrdenConversionSalidaE> oListaTmp = new List<OrdenConversionSalidaE>((from x in ordenconversion.ListaConverSalida
                                                                                                   where x.idAlmacen == item.idAlmacen select x).ToList());
                        numItem = 0;

                        foreach (OrdenConversionSalidaE itemSalida in oListaTmp)
                        {
                            //Obteniendo el almacén
                            AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(itemSalida.idEmpresa, Convert.ToInt32(itemSalida.idAlmacen));
                            //Obteniendo al lista de operaciones
                            List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), itemSalida.idEmpresa, idMovimiento);

                            OperacionE Operacion = oListaOperaciones.Find
                            (
                               delegate (OperacionE op) { return op.indConversion == true; }
                            );

                            if (Operacion == null)
                            {
                                throw new Exception("No existe Movimientos de Conversion.");
                            }
                            else
                            {
                                idOperacion = Operacion.idOperacion;
                            }

                            #region Cabecera del movimiento de almacen

                            if (EsCabecera)
                            {
                                oMovimientoAlmacen = new MovimientoAlmacenE()
                                {
                                    idEmpresa = ordenconversion.idEmpresa,
                                    tipMovimiento = idMovimiento,
                                    idAlmacen = Convert.ToInt32(itemSalida.idAlmacen),
                                    tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                                    idOperacion = idOperacion,
                                    //fecProceso = ordenconversion.Fecha, //Revisar
                                    //fecDocumento = ordenconversion.Fecha, //Revisar
                                    idDocumento = "OR",
                                    serDocumento = String.Empty,
                                    numDocumento = ordenconversion.Numero,
                                    idOrdenCompra = Variables.Cero,
                                    numRequisicion = String.Empty,
                                    idDocumentoRef = "OR",
                                    SerieDocumentoRef = String.Empty,
                                    NumeroDocumentoRef = ordenconversion.Numero,
                                    idPersona = Variables.Cero,
                                    idMoneda = Variables.Soles,
                                    indCambio = true,
                                    tipCambio = Tica.valVenta,
                                    impValorVenta = Variables.Cero,
                                    Impuesto = Variables.Cero,
                                    impTotal = Variables.Cero,
                                    indPorAsociar = false,
                                    idAlmacenOrigen = Variables.Cero,
                                    idAlmacenDestino = Variables.Cero,
                                    tipMovimientoAsociado = null,
                                    idDocumentoAlmacenAsociado = null,
                                    Glosa = "Salida por Conversion " + ordenconversion.Numero,
                                    UsuarioRegistro = Usuario
                                };

                                //Insertando el nuevo movimiento
                                oMovimientoAlmacen = new MovimientoAlmacenAD().InsertarMovimientoAlmacen(oMovimientoAlmacen);
                                EsCabecera = false;
                            }

                            #endregion

                            #region Detalle del movimiento de almacen

                            Decimal CostoS = 0;
                            Decimal CostoD = 0;

                            numItem++;

                            if (ordenconversion.idMoneda == Variables.Soles)
                            {
                                CostoS = itemSalida.ImpCostoUnitarioBase;
                                CostoD = CostoS / Tica.valVenta;
                            }
                            else
                            {
                                CostoD = itemSalida.ImpCostoUnitarioRefe;
                                CostoS = CostoD * Tica.valVenta;
                            }

                            String LoteIndusoft = "0000000";

                            if (itemSalida.Lote == "0" || String.IsNullOrWhiteSpace(itemSalida.Lote))
                            {
                                if (oAlmacen.VerificaLote)
                                {
                                    LoteIndusoft = new LoteAD().ObtenerMaxLoteAlmacen(ordenconversion.idEmpresa); 
                                }

                                itemSalida.Lote = LoteIndusoft;
                            }

                            oItemMovimiento = new MovimientoAlmacenItemE()
                            {
                                idEmpresa = oMovimientoAlmacen.idEmpresa,
                                tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                                idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                numItem = String.Format("{0:0000}", numItem),
                                idArticulo = Convert.ToInt32(itemSalida.idArticulo),
                                Lote = itemSalida.Lote,
                                idUbicacion = Variables.Cero,
                                Cantidad = Convert.ToDecimal(itemSalida.CantSolicitada),
                                ImpCostoUnitarioBase = CostoS,
                                ImpCostoUnitarioRefe = CostoD,
                                ImpTotalBase = CostoS * Convert.ToDecimal(itemSalida.CantSolicitada),
                                ImpTotalRefe = CostoD * Convert.ToDecimal(itemSalida.CantSolicitada),
                                indCalidad = false,
                                indConformidad = false,
                                idCCostos = String.Empty,
                                idCCostosUso = String.Empty,
                                idArticuloUso = Variables.Cero,
                                nroEnvases = Variables.Cero,
                                Valorizado = false,
                                nroParteProd = String.Empty,
                                idItemCompra = 0,
                                UsuarioRegistro = Usuario
                            };

                            new MovimientoAlmacenItemAD().InsertarMovimiento_Almacen_Item(oItemMovimiento);

                            #endregion

                            //Procesando el stock...
                            String AnioPeriodo = oMovimientoAlmacen.fecProceso.Substring(0, 4);//oMovimientoAlmacen.fecProceso.ToString("yyyy");
                            String MesPeriodo = oMovimientoAlmacen.fecProceso.Substring(4, 2);//oMovimientoAlmacen.fecProceso.ToString("MM");
                            Int32 Almacen = Convert.ToInt32(oAlmacen.idAlmacen);
                            Decimal CantMovimiento = oItemMovimiento.Cantidad;

                            new AlmacenArticuloLoteAD().ActualizarStockValorizado(ordenconversion.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, idOperacion, itemSalida.idArticulo,
                                                                                itemSalida.Lote, CantMovimiento, oItemMovimiento.ImpCostoUnitarioBase, oItemMovimiento.ImpCostoUnitarioRefe, "IN");

                            //Actualizando los datos de almacen en el item de conversión...
                            itemSalida.tipMovimiento = oMovimientoAlmacen.tipMovimiento;
                            itemSalida.idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen;

                            new OrdenConversionSalidaAD().ActualizarOrdenConversionSalidaMovAlmacen(itemSalida);
                        }

                        EsCabecera = true;
                    }

                    //Actualizando la Orden de Conversión
                    ordenconversion.indGenerada = true;
                    ordenconversion.nomTipoMov = oTipoMovimiento.Nombre;
                    ordenconversion = new OrdenConversionAD().ActualizarOrdenConversion(ordenconversion);

                    // Generando Cabecera de la Salida 
                    //oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), ordenconversion.idEmpresa, idMovimiento);

                    //numItem = 0;

                    //foreach (OrdenConversionSalidaE item in ordenconversion.ListaConverSalida)
                    //{

                    //    #region Detalle del movimiento de almacen

                    //    //Decimal CostoS = 0;
                    //    //Decimal CostoD = 0;

                    //    //numItem++;

                    //    //if (ordenconversion.idMoneda == Variables.Soles)
                    //    //{
                    //    //    CostoS = ordenconversion.CostoUnitario;
                    //    //    CostoD = CostoS / Tica.valVenta;
                    //    //}
                    //    //else
                    //    //{
                    //    //    CostoD = ordenconversion.CostoUnitario;
                    //    //    CostoS = CostoD * Tica.valVenta;
                    //    //}

                    //    //string LoteIndusoft = "0000000";

                    //    //if (item.Lote == "0" || String.IsNullOrWhiteSpace(item.Lote))
                    //    //{
                    //    //    LoteIndusoft = new LoteAD().ObtenerMaxLoteAlmacen(ordenconversion.idEmpresa);
                    //    //    item.Lote = LoteIndusoft;
                    //    //}

                    //    //oItemMovimiento = new MovimientoAlmacenItemE()
                    //    //{
                    //    //    idEmpresa = oMovimientoAlmacen.idEmpresa,
                    //    //    tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                    //    //    idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                    //    //    numItem = String.Format("{0:0000}", numItem),
                    //    //    idArticulo = Convert.ToInt32(item.idArticulo),
                    //    //    Lote = item.Lote,
                    //    //    idUbicacion = Variables.Cero,
                    //    //    Cantidad = Convert.ToDecimal(item.CantSolicitada),
                    //    //    ImpCostoUnitarioBase = CostoS,
                    //    //    ImpCostoUnitarioRefe = CostoD,
                    //    //    ImpTotalBase = CostoS * Convert.ToDecimal(ordenconversion.CantSolicitada),
                    //    //    ImpTotalRefe = CostoD * Convert.ToDecimal(ordenconversion.CantSolicitada),
                    //    //    indCalidad = false,
                    //    //    indConformidad = false,
                    //    //    idCCostos = String.Empty,
                    //    //    idCCostosUso = String.Empty,
                    //    //    idArticuloUso = Variables.Cero,
                    //    //    nroEnvases = Variables.Cero,
                    //    //    Valorizado = false,
                    //    //    nroParteProd = String.Empty,
                    //    //    idItemCompra = 0,
                    //    //    UsuarioRegistro = Usuario
                    //    //};

                    //    //new MovimientoAlmacenItemAD().InsertarMovimiento_Almacen_Item(oItemMovimiento);

                    //    #endregion

                    //    //Procesando el stock
                    //    //String AnioPeriodo = Convert.ToString(ordenconversion.Fecha.Year);
                    //    //String MesPeriodo = ordenconversion.Fecha.ToString("MM");
                    //    //Int32 Almacen = Convert.ToInt32(oAlmacen.idAlmacen);
                    //    //Decimal CantMovimiento = oItemMovimiento.Cantidad;
                    //    //////Procesando el stock...
                    //    ////String AnioPeriodo = oMovimientoAlmacen.fecProceso.ToString("yyyy");
                    //    ////String MesPeriodo = oMovimientoAlmacen.fecProceso.ToString("MM");
                    //    ////Int32 Almacen = Convert.ToInt32(oAlmacen.idAlmacen);
                    //    ////Decimal CantMovimiento = oItemMovimiento.Cantidad;

                    //    ////new AlmacenArticuloLoteAD().ActualizarStockValorizado(ordenconversion.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, idOperacion, item.idArticulo,
                    //    ////                                                    item.Lote, CantMovimiento, oItemMovimiento.ImpCostoUnitarioBase, oItemMovimiento.ImpCostoUnitarioRefe, "IN");

                    //}

                    //Actualizando la Orden de Conversión
                    //ordenconversion.indGenerada = true;
                    ////ordenconversion.tipMovimiento = oMovimientoAlmacen.tipMovimiento;
                    ////ordenconversion.idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen;
                    //ordenconversion.nomTipoMov = oTipoMovimiento.Nombre;


                    //OrdenConversionE oOrden = new OrdenConversionAD().ActualizarOrdenConversion(ordenconversion);

                    //Transaccion completada...
                    oTrans.Complete();
                }

                return ordenconversion;
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

        public OrdenConversionE GeneraIngresoAlmacenPorConversion(OrdenConversionE ordenconversion, String Usuario)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 idMovimiento = Variables.Cero;
                    Int32 idOperacion = Variables.Cero;
                    MovimientoAlmacenE oMovimientoAlmacen = null;
                    MovimientoAlmacenItemE oItemMovimiento = null;
                    Int16 numItem = 1;
                    ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("ING");
           
                    if (oTipoMovimiento != null)
                    {
                        idMovimiento = oTipoMovimiento.IdParTabla;
                    }
                    else
                    {
                        throw new Exception("No hay ningún tipo de movimiento para los ingresos.");
                    }

                    List<OperacionE> oListaOperaciones = null;

                    foreach (OrdenConversionDetalleE oitem in ordenconversion.ListaConverDetalle)
                    {
                        //Obteniendo el almacén...
                        AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(ordenconversion.idEmpresa, Convert.ToInt32(oitem.idAlmacen));
                        
                        //Obteniendo la lista de operaciones en el almacén...
                        oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), ordenconversion.idEmpresa, idMovimiento);

                        OperacionE Operacion = oListaOperaciones.Find
                        (
                            delegate (OperacionE op) { return op.indConversion == true; }
                        );

                        if (Operacion == null)
                        {
                            throw new Exception("No existe en el Maestro de Operaciones movimientos de Conversion.");
                        }
                        else
                        {
                            idOperacion = Operacion.idOperacion;
                        }

                        #region Cabecera del movimiento de almacén

                        TipoCambioE Tica = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, ordenconversion.Fecha.Date.ToString("yyyyMMdd"));

                        if (Tica == null)
                        {
                            throw new Exception(String.Format("El dia {0} no tiene Tipo de Cambio.", ordenconversion.Fecha.Date));
                        }

                        oMovimientoAlmacen = new MovimientoAlmacenE()
                        {
                            idEmpresa = ordenconversion.idEmpresa,
                            tipMovimiento = idMovimiento,
                            idAlmacen = Convert.ToInt32(oitem.idAlmacen),
                            tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                            idOperacion = idOperacion,
                            //fecProceso = oitem.Fecha.Value, //Revisar
                            idDocumento = "OR",
                            serDocumento = String.Empty,
                            numDocumento = ordenconversion.Numero,
                            //fecDocumento = oitem.Fecha.Value, //Revisar
                            idOrdenCompra = Variables.Cero,
                            numRequisicion = String.Empty,
                            idDocumentoRef = "OR",
                            SerieDocumentoRef = String.Empty,
                            NumeroDocumentoRef = ordenconversion.Numero,
                            idPersona = Variables.Cero,
                            idMoneda = Variables.Soles,
                            indCambio = true,
                            tipCambio = Tica.valVenta,
                            impValorVenta = Variables.Cero,
                            Impuesto = Variables.Cero,
                            impTotal = Variables.Cero,
                            indPorAsociar = false,
                            idAlmacenOrigen = Variables.Cero,
                            idAlmacenDestino = Variables.Cero,
                            tipMovimientoAsociado = null,
                            idDocumentoAlmacenAsociado = null,
                            
                            Glosa = "Ingreso por Conversión " + ordenconversion.Numero,
                            UsuarioRegistro = Usuario
                        };

                        oMovimientoAlmacen = new MovimientoAlmacenAD().InsertarMovimientoAlmacen(oMovimientoAlmacen);

                        #endregion

                        #region Detalle del movimiento de almacén

                        Decimal CostoS = 0;
                        Decimal CostoD = 0;

                        if (ordenconversion.idMoneda == Variables.Soles)
                        {
                            CostoS = ordenconversion.CostoUnitario;
                            CostoD = CostoS / Tica.valVenta;
                        }
                        else
                        {
                            CostoD = ordenconversion.CostoUnitario;
                            CostoS = CostoD * Tica.valVenta;
                        }

                        String LoteIndusoft = "0000000";

                        if (oitem.Lote == "0")
                        {
                            if (oAlmacen.VerificaLote)
                            {
                                LoteIndusoft = new LoteAD().ObtenerMaxLoteAlmacen(ordenconversion.idEmpresa); 
                            }

                            oitem.Lote = LoteIndusoft;
                        }

                        oItemMovimiento = new MovimientoAlmacenItemE()
                        {
                            idEmpresa = oMovimientoAlmacen.idEmpresa,
                            tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                            idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                            numItem = String.Format("{0:0000}", numItem),
                            idArticulo = Convert.ToInt32(oitem.idArticulo),
                            Lote = oitem.Lote,
                            idUbicacion = Variables.Cero,
                            Cantidad = Convert.ToDecimal(oitem.Cantidad),
                            ImpCostoUnitarioBase = CostoS,
                            ImpCostoUnitarioRefe = CostoD,
                            ImpTotalBase = CostoS * Convert.ToDecimal(oitem.Cantidad),
                            ImpTotalRefe = CostoD * Convert.ToDecimal(oitem.Cantidad),
                            indCalidad = false,
                            indConformidad = false,
                            idCCostos = String.Empty,
                            idCCostosUso = String.Empty,
                            idArticuloUso = Variables.Cero,
                            nroEnvases = Variables.Cero,
                            Valorizado = false,
                            nroParteProd = String.Empty,
                            idItemCompra = 0,
                            UsuarioRegistro = Usuario
                        };

                        new MovimientoAlmacenItemAD().InsertarMovimiento_Almacen_Item(oItemMovimiento); 

                        #endregion

                        //Actualizando la Orden de conversión...
                        oitem.indGenerada = true;
                        oitem.tipMovimiento = oMovimientoAlmacen.tipMovimiento;
                        oitem.idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen;

                        OrdenConversionDetalleE oOrdenDetalle = new OrdenConversionDetalleAD().ActualizarOrdenConversionDetalle(oitem);

                        //Procesando el stock...
                        //String AnioPeriodo = oMovimientoAlmacen.fecProceso.ToString("yyyy");
                        //String MesPeriodo = oMovimientoAlmacen.fecProceso.ToString("MM");
                        String AnioPeriodo = oMovimientoAlmacen.fecProceso.Substring(0, 4);//oMovimientoAlmacen.fecProceso.ToString("yyyy");
                        String MesPeriodo = oMovimientoAlmacen.fecProceso.Substring(4, 2);//oMovimientoAlmacen.fecProceso.ToString("MM");
                        Int32 Almacen = Convert.ToInt32(oAlmacen.idAlmacen);
                        Decimal CantMovimiento = oItemMovimiento.Cantidad;

                        new AlmacenArticuloLoteAD().ActualizarStockValorizado(ordenconversion.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, idOperacion, oitem.idArticulo,
                                                                            oitem.Lote, CantMovimiento, oItemMovimiento.ImpCostoUnitarioBase, oItemMovimiento.ImpCostoUnitarioRefe, "IN");
                    }

                    //Recuperar Orden de Conversion completa
                    ordenconversion.ListaConverDetalle = new OrdenConversionDetalleAD().ListarOrdenConversionDetalle(ordenconversion.idEmpresa, ordenconversion.idOrdenConversion);
                    //Transaccion completada...   
                    oTrans.Complete();

                    return ordenconversion;
                }
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

        public OrdenConversionE InsertarOrdenConversion(OrdenConversionE ordenconversion)
        {
            try
            {
                return new OrdenConversionAD().InsertarOrdenConversion(ordenconversion);
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

        public OrdenConversionE ActualizarOrdenConversion(OrdenConversionE ordenconversion)
        {
            try
            {
                return new OrdenConversionAD().ActualizarOrdenConversion(ordenconversion);
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

        public int EliminarOrdenConversion(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            try
            {
                return new OrdenConversionAD().EliminarOrdenConversion(idEmpresa, idOrdenConversion);
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

        public List<OrdenConversionE> ListarOrdenConversion(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin, Int32 idConcepto, Int32 idArticulo, String desArticulo, String tipFecha)
        {
            try
            {
                return new OrdenConversionAD().ListarOrdenConversion(idEmpresa, FechaIni, FechaFin, idConcepto, idArticulo, desArticulo, tipFecha);
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

        public OrdenConversionE ObtenerOrdenConversion(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            try
            {
                return new OrdenConversionAD().ObtenerOrdenConversion(idEmpresa, idOrdenConversion);
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

        public OrdenConversionE ObtenerOrdenConversionCompleta(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            try
            {
                OrdenConversionE OrdenConversion = new OrdenConversionAD().ObtenerOrdenConversion(idEmpresa, idOrdenConversion);
                OrdenConversion.ListaConverDetalle = new OrdenConversionDetalleAD().ListarOrdenConversionDetalle(idEmpresa, idOrdenConversion);
                OrdenConversion.ListaConverSalida = new OrdenConversionSalidaAD().ListarOrdenConversionSalida(idEmpresa, idOrdenConversion);
                OrdenConversion.ListaGastos = new OrdenConversionGastosAD().ListarOrdenConversionGastos(idOrdenConversion);

                return OrdenConversion;
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

        public String GenerarNroConversion(Int32 idEmpresa, DateTime Fecha)
        {
            try
            {
                return new OrdenConversionAD().GenerarNroConversion(idEmpresa, Fecha);
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

        public OrdenConversionE AnularSalAlmacenPorConversion(OrdenConversionE oOrdenConversion, String Usuario)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 resp = 0;
                    oOrdenConversion.ListaConverSalida = new OrdenConversionSalidaAD().ListarOrdenConversionSalida(oOrdenConversion.idEmpresa, oOrdenConversion.idOrdenConversion);

                    foreach (OrdenConversionSalidaE item in oOrdenConversion.ListaConverSalida)
                    {
                        resp = new MovimientoAlmacenAD().AnularMovimientoAlmacen(oOrdenConversion.idEmpresa, Convert.ToInt32(item.tipMovimiento), Convert.ToInt32(item.idDocumentoAlmacen), Usuario);
                        MovimientoAlmacenE oMovimientoSalida = new MovimientoAlmacenAD().ObtenerMovimientoAlmacen(oOrdenConversion.idEmpresa, Convert.ToInt32(item.tipMovimiento), Convert.ToInt32(item.idDocumentoAlmacen));

                        if (resp > 0)
                        {
                            oOrdenConversion.indGenerada = false;
                            oOrdenConversion.UsuarioModificacion = Usuario;

                            //Actualizando la Orden de Conversión
                            oOrdenConversion = new OrdenConversionAD().ActualizarOrdenConversion(oOrdenConversion);

                            //Para actualizar el stock en el almacén
                            Int32 idMovimiento = Variables.Cero;
                            ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("EGR");
                            Int32 idOperacion = Variables.Cero;

                            if (oTipoMovimiento != null)
                            {
                                idMovimiento = oTipoMovimiento.IdParTabla;
                            }
                            else
                            {
                                throw new Exception("No hay ningún tipo de movimiento para las salidas.");
                            }

                            //Obteniendo el almacén
                            AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(oOrdenConversion.idEmpresa, Convert.ToInt32(item.idAlmacen));

                            //Obteniendo la lista de operaciones
                            List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), oOrdenConversion.idEmpresa, idMovimiento);

                            OperacionE Operacion = oListaOperaciones.Find
                            (
                                delegate (OperacionE op) { return op.indConversion == true; }
                            );

                            if (Operacion == null)
                            {
                                throw new Exception("No existe Movimientos de Salida para la Conversión.");
                            }
                            else
                            {
                                idOperacion = Operacion.idOperacion;
                            }

                            //Procesando el stock
                            String AnioPeriodo = oOrdenConversion.Fecha.ToString("yyyy");
                            String MesPeriodo = oOrdenConversion.Fecha.ToString("MM");
                            Int32 Almacen = Convert.ToInt32(oMovimientoSalida.idAlmacen);
                            Decimal CantMovimiento = item.cantidad;

                            new AlmacenArticuloLoteAD().ActualizarStockValorizado(oOrdenConversion.idEmpresa, AnioPeriodo, MesPeriodo, Almacen, idOperacion, item.idArticulo,
                                                                                item.Lote, CantMovimiento, 0, 0, "AN");
                        }

                        //Actualizando los datos de almacen en el item de conversión...
                        item.tipMovimiento = null;
                        item.idDocumentoAlmacen = null;

                        new OrdenConversionSalidaAD().ActualizarOrdenConversionSalidaMovAlmacen(item);
                    }

                    //Transaccion completada...   
                    oTrans.Complete();

                    return oOrdenConversion; 
                }
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

        public OrdenConversionE AnularIngAlmacenPorConversion(OrdenConversionE DetalleConversion, string Usuario)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Variables para actualizar el stock en el almacén
                    Int32 idMovimiento = Variables.Cero;
                    ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("ING");
                    Int32 idOperacion = Variables.Cero;

                    foreach (OrdenConversionDetalleE item in DetalleConversion.ListaConverDetalle)
                    {
                        //Anulando el movimiento de almacén
                        new MovimientoAlmacenAD().AnularMovimientoAlmacen(item.idEmpresa, Convert.ToInt32(item.tipMovimiento), Convert.ToInt32(item.idDocumentoAlmacen), Usuario);

                        item.indGenerada = false;
                        item.tipMovimiento = (Nullable<int>)null;
                        item.idDocumentoAlmacen = (Nullable<int>)null;
                        item.nomTipoMov = string.Empty;
                        item.UsuarioModificacion = Usuario;

                        //Actualizando la conversión
                        new OrdenConversionDetalleAD().ActualizarOrdenConversionDetalle(item);

                        //Para actualizar el stock en el almacén
                        if (oTipoMovimiento != null)
                        {
                            idMovimiento = oTipoMovimiento.IdParTabla;
                        }
                        else
                        {
                            throw new Exception("No hay ningún tipo de movimiento para los Ingresos.");
                        }

                        //Obteniendo el almacén
                        AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));

                        //Obteniendo la lista de operaciones
                        List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), item.idEmpresa, idMovimiento);

                        OperacionE Operacion = oListaOperaciones.Find
                        (
                            delegate (OperacionE op) { return op.indConversion == true; }
                        );

                        if (Operacion == null)
                        {
                            throw new Exception("No existe Movimientos de Ingreso para la Conversion.");
                        }
                        else
                        {
                            idOperacion = Operacion.idOperacion;
                        }

                        //Procesando el stock
                        String AnioPeriodo = item.Fecha.Value.ToString("yyyy");
                        String MesPeriodo = item.Fecha.Value.ToString("MM");

                        new AlmacenArticuloLoteAD().ActualizarStockValorizado(item.idEmpresa, AnioPeriodo, MesPeriodo, Convert.ToInt32(item.idAlmacen), idOperacion, item.idArticulo,
                                                                            item.Lote, item.Cantidad, 0, 0, "AN");
                    };

                    //Transaccion completada...   
                    oTrans.Complete();

                    return DetalleConversion; 
                }
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

        public Int32 ActualizarCostosAlmacen(OrdenConversionE ordenconversion)
        {
            try
            {
                Int32 Resp = 0;
                //Decimal CostoS = 0;
                //Decimal CostoD = 0;
                //TipoCambioE Tica = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, ordenconversion.Fecha.Date);

                //if (Tica == null)
                //{
                //    throw new Exception(String.Format("El dia {0} no tiene Tipo de Cambio.", ordenconversion.Fecha.Date));
                //}

                //if (ordenconversion.idMoneda == Variables.Soles)
                //{
                //    CostoS = ordenconversion.CostoUnitario;
                //    CostoD = CostoS / Tica.valVenta;
                //}
                //else
                //{
                //    CostoD = ordenconversion.CostoUnitario;
                //    CostoS = CostoD * Tica.valVenta;
                //}

                //if (ordenconversion.indGenerada)
                //{
                //    MovimientoAlmacenItemE oItemMovimiento = new MovimientoAlmacenItemE()
                //    {
                //        idEmpresa = ordenconversion.idEmpresa,
                //        tipMovimiento = Convert.ToInt32(ordenconversion.tipMovimiento),
                //        idDocumentoAlmacen = Convert.ToInt32(ordenconversion.idDocumentoAlmacen),
                //        idArticulo = Convert.ToInt32(ordenconversion.idArticulo),
                //        ImpCostoUnitarioBase = CostoS,
                //        ImpCostoUnitarioRefe = CostoD,
                //        ImpTotalBase = CostoS * ordenconversion.CantSolicitada,
                //        ImpTotalRefe = CostoD * ordenconversion.CantSolicitada,
                //        UsuarioModificacion = ordenconversion.UsuarioModificacion
                //    };

                //    Resp = new MovimientoAlmacenItemAD().ActualizarCostosAlmacenItem(oItemMovimiento);
                //}

                //foreach (OrdenConversionDetalleE item in ordenconversion.ListaConverDetalle)
                //{
                //    if (item.indGenerada)
                //    {
                //        if (ordenconversion.idMoneda == Variables.Soles)
                //        {
                //            CostoS = item.CostoUnitario;
                //            CostoD = CostoS / Tica.valVenta;
                //        }
                //        else
                //        {
                //            CostoD = item.CostoUnitario;
                //            CostoS = CostoD * Tica.valVenta;
                //        }

                //        MovimientoAlmacenItemE oItemMovimiento = new MovimientoAlmacenItemE()
                //        {
                //            idEmpresa = ordenconversion.idEmpresa,
                //            tipMovimiento = Convert.ToInt32(ordenconversion.tipMovimiento),
                //            idDocumentoAlmacen = Convert.ToInt32(ordenconversion.idDocumentoAlmacen),
                //            idArticulo = Convert.ToInt32(ordenconversion.idArticulo),
                //            ImpCostoUnitarioBase = CostoS,
                //            ImpCostoUnitarioRefe = CostoD,
                //            ImpTotalBase = CostoS * ordenconversion.CantSolicitada,
                //            ImpTotalRefe = CostoD * ordenconversion.CantSolicitada,
                //            UsuarioModificacion = ordenconversion.UsuarioModificacion
                //        };

                //        Resp += new MovimientoAlmacenItemAD().ActualizarCostosAlmacenItem(oItemMovimiento);
                //    }
                //}

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

        public List<OrdenConversionE> ListarOrdenConversionProvision(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                return new OrdenConversionAD().ListarOrdenConversionProvision(idEmpresa, FechaIni, FechaFin);
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
