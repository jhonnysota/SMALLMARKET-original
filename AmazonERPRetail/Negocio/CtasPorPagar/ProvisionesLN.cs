using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.CtasPorPagar;
using Entidades.Almacen;
using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Contabilidad;
using AccesoDatos.Almacen;
using AccesoDatos.Tesoreria;
using AccesoDatos.Generales;
using AccesoDatos.Maestros;
using Negocio.Almacen;
using Negocio.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorPagar
{
    public class ProvisionesLN
    {

        public List<ProvisionesE> ListarPartidaPresuAgrupadoPorProvisiones(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                return new ProvisionesAD().ListarPartidaPresuAgrupadoPorProvisiones(idEmpresa, fecha_desde, fecha_hasta);
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

        public List<ProvisionesE> ListarProvisionesPorPartidaPresu(Int32 idEmpresa, String codPartidaPresu, String mes, String ano)
        {
            try
            {
                return new ProvisionesAD().ListarProvisionesPorPartidaPresu(idEmpresa, codPartidaPresu, mes, ano);
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

        public List<ProvisionesE> ListarProvisionesPorPeriodo(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                return new ProvisionesAD().ListarProvisionesPorPeriodo(idEmpresa, fecha_desde, fecha_hasta);
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

        public List<ProvisionesE> ListarPartidaPresuAgrupadoPorPagos(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                return new ProvisionesAD().ListarPartidaPresuAgrupadoPorPagos(idEmpresa, fecha_desde, fecha_hasta);
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

        public List<ProvisionesE> ListarPagosPorPartidaPresu(Int32 idEmpresa, String codPartidaPresu, String mes, String ano)
        {
            try
            {
                return new ProvisionesAD().ListarPagosPorPartidaPresu(idEmpresa, codPartidaPresu, mes, ano);
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

        public List<ProvisionesE> ListarPagosPorPeriodo(Int32 idEmpresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                return new ProvisionesAD().ListarPagosPorPeriodo(idEmpresa, fecha_desde, fecha_hasta);
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

        public ProvisionesE GrabarProvision(ProvisionesE ProvisionCompleto, EnumOpcionGrabar OpcionGrabacion, Boolean ActualizarDetalle = true)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    ProvisionesE ProvisionRevision = null;
                    Int32 corItem = Variables.Cero;
                    List<OrdenCompraItemE> oListaOcDetalle = null;

                    // Validar Orden Compra
                    bool ValOC;

                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            Int32 numItem = 1;

                            #region Provision

                            if (ProvisionCompleto.idComprobante == Variables.RegistroCompra)
                            {
                                ProvisionRevision = new ProvisionesAD().RevisarDocProvisiones(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, ProvisionCompleto.idDocumento,
                                                                                                                    ProvisionCompleto.NumSerie, ProvisionCompleto.NumDocumento,
                                                                                                                    Convert.ToInt32(ProvisionCompleto.idPersona), ProvisionCompleto.idProvision);
                                if (ProvisionRevision != null)
                                {
                                    throw new Exception(String.Format("El documento {0}-{1} {2} ya ha sido registrado el {3}",
                                                        ProvisionRevision.idDocumento, ProvisionRevision.NumSerie, ProvisionRevision.NumDocumento,
                                                        ProvisionRevision.FechaProvision.ToString("d")));
                                }
                            }

                            ProvisionCompleto = new ProvisionesAD().InsertarProvisiones(ProvisionCompleto);

                            //Revisando para ver si hay O.C.
                            if (ProvisionCompleto.idOrdenCompra != null && ProvisionCompleto.idOrdenCompra > 0)
                            {
                                oListaOcDetalle = new OrdenCompraItemAD().ListarOrdenCompraItem(ProvisionCompleto.idEmpresa, Convert.ToInt32(ProvisionCompleto.idOrdenCompra));
                            }

                            if (ProvisionCompleto.ListaPorCCosto != null && ProvisionCompleto.ListaPorCCosto.Count > 0)
                            {
                                foreach (Provisiones_PorCCostoE item in ProvisionCompleto.ListaPorCCosto)
                                {
                                    item.idEmpresa = ProvisionCompleto.idEmpresa;
                                    item.idLocal = ProvisionCompleto.idLocal;
                                    item.idProvision = ProvisionCompleto.idProvision;
                                    item.idMoneda = ProvisionCompleto.CodMonedaProvision;

                                    // si se ha seleccionado una OC se respeta el item.
                                    if (ProvisionCompleto.idOrdenCompra == 0)
                                    {
                                        item.idItem = numItem;
                                    }

                                    new Provisiones_PorCCostoAD().InsertarProvisiones_PorCCosto(item);

                                    //Actualizar el Estado de Por Recibir.
                                    if (!item.PorRecibir && item.idProvisionRecibida != null)
                                    {
                                      new Provisiones_PorCCostoAD().ActualizarPorRecibir_PorCCosto(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, Convert.ToInt32(ProvisionCompleto.idProvision), Convert.ToInt32(ProvisionCompleto.idProvisionRev), Convert.ToInt32(item.idProvisionRecibida), ProvisionCompleto.UsuarioRegistro);
                                    }

                                    numItem++;

                                    ValOC = false;

                                    // Si es Nota de Credito y es Devolucion Validar
                                    if ((ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97") && ProvisionCompleto.indAfectacionAlmacen == 1 && oListaOcDetalle != null && oListaOcDetalle.Count > 0)
                                    {
                                        ValOC = true;
                                    }

                                    if ((ProvisionCompleto.idDocumento != "CR" && ProvisionCompleto.idDocumento != "97") && oListaOcDetalle != null && oListaOcDetalle.Count > 0)
                                    {
                                        ValOC = true;
                                    }

                                    // Si la Reversion de una Provision de Compra en el Mes Anterior
                                    if (ProvisionCompleto.indReversion == false && ProvisionCompleto.idProvisionRev != null )
                                    {
                                       if (ProvisionCompleto.idProvisionRev > 0)
                                        {
                                            ValOC = false;
                                        }
                                    }

                                    ////Si hay Detalle O.C. ingresa...
                                    if (ValOC)
                                    {
                                        Decimal CantMovimiento = item.Cantidad;

                                        foreach (OrdenCompraItemE itemOc in oListaOcDetalle)
                                        {
                                            if (itemOc.idEmpresa == item.idEmpresa && itemOc.idOrdenCompra == ProvisionCompleto.idOrdenCompra && itemOc.idArticuloServ == Convert.ToInt32(item.idArticulo) && Convert.ToInt32(itemOc.idItem)  == item.idItem )
                                            {
                                                // Validacion
                                                if (ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97")
                                                {
                                                    if (CantMovimiento > itemOc.canProvisionada)
                                                    {
                                                        throw new Exception("La cantidad Devuelta no puede ser mayor a la cantidad Provisionada.");
                                                    }
                                                    else if (CantMovimiento < itemOc.canProvisionada)
                                                    {
                                                        itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AP.ToString();
                                                    }
                                                    else
                                                    {
                                                        itemOc.tipEstadoProvision = EnumEstadoAtencionOC.PN.ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    if (CantMovimiento > (itemOc.CanOrdenada - itemOc.canProvisionada))
                                                    {
                                                        throw new Exception("La cantidad ingresada no puede ser mayor a la cantidad de la OC.");
                                                    }
                                                    else if (CantMovimiento < (itemOc.CanOrdenada - itemOc.canProvisionada))
                                                    {
                                                        itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AP.ToString();
                                                    }
                                                    else
                                                    {
                                                        itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AT.ToString();
                                                    }
                                                }

                                                if (ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97")
                                                {
                                                    itemOc.canProvisionada = CantMovimiento - itemOc.canProvisionada;
                                                }
                                                else
                                                {
                                                    itemOc.canProvisionada = CantMovimiento + itemOc.canProvisionada;
                                                }

                                                new OrdenCompraItemAD().ActualizarCantProvOc(itemOc);
                                            }
                                        }
                                    }
                                }
                            }

                            //Actualizando la Hoja de Costo
                            if (ProvisionCompleto.idHojaCosto != null && ProvisionCompleto.idDocumento == "DU")
                            {
                                HojaCostoE HojaDua = new HojaCostoE()
                                {
                                    idEmpresa = ProvisionCompleto.idEmpresa,
                                    idLocal = ProvisionCompleto.idLocal,
                                    idHojaCosto = Convert.ToInt32(ProvisionCompleto.idHojaCosto),
                                    DUA = String.IsNullOrWhiteSpace(ProvisionCompleto.NumSerie) ? ProvisionCompleto.NumDocumento : ProvisionCompleto.NumSerie + "-" + ProvisionCompleto.NumDocumento,
                                    fecDua = ProvisionCompleto.FechaDocumento,
                                    UsuarioModificacion = ProvisionCompleto.UsuarioRegistro
                                };

                                new HojaCostoAD().ActualizarHojaCostoDua(HojaDua);
                            }

                            //Actualizar el Estado de Reversión si hay Nro.
                            if (!ProvisionCompleto.indReversion && ProvisionCompleto.idProvisionRev != null)
                            {
                                new ProvisionesAD().ActualizarNumReversion(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, Convert.ToInt32(ProvisionCompleto.idProvision), Convert.ToInt32(ProvisionCompleto.idProvisionRev), ProvisionCompleto.UsuarioRegistro);
                            }

                            #endregion

                            #region Movimiento de Almacén

                            if (ProvisionCompleto.indAfectacionAlmacen == 2 && ProvisionCompleto.idOrdenCompra != 0)
                            {
                                MovimientoAlmacenE oMovimientoAlmacen = null;
                                MovimientoAlmacenItemE oItemMovimiento = null;
                                ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("EGR");
                                List<OperacionE> oListaOperaciones = null;
                                OrdenCompraE oOrdenCompra = new OrdenCompraAD().ObtenerOrdenCompra(ProvisionCompleto.idEmpresa, ProvisionCompleto.idOrdenCompra.Value);
                                oOrdenCompra.ListaOrdenesCompras = new OrdenCompraItemAD().ListarOrdenCompraItem(oOrdenCompra.idEmpresa, oOrdenCompra.idOrdenCompra);
                                //Obteniendo el almacén...
                                AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(oOrdenCompra.idEmpresa, Convert.ToInt32(oOrdenCompra.idAlmacenEntrega));

                                if (oTipoMovimiento == null)
                                {
                                    throw new Exception("No existe Tipos de Movimientos para los Ingresos.");
                                }

                                #region Cabecera

                                //Obteniendo la lista de operaciones...
                                oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), ProvisionCompleto.idEmpresa, oTipoMovimiento.IdParTabla);

                                OperacionE Operacion = oListaOperaciones.Find
                                (
                                    delegate (OperacionE op) { return op.indServicio == true && op.desOperacion.Contains("DESCUENTO"); }
                                );

                                if (Operacion == null)
                                {
                                    throw new Exception("No existe Tipos de Operacion.");
                                }

                                oMovimientoAlmacen = new MovimientoAlmacenE()
                                {
                                    idEmpresa = ProvisionCompleto.idEmpresa,
                                    tipMovimiento = oTipoMovimiento.IdParTabla,
                                    idAlmacen = Convert.ToInt32(oAlmacen.idAlmacen),
                                    tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                                    idOperacion = Operacion.idOperacion,
                                    //fecProceso = ProvisionCompleto.FechaProvision, //Revisar
                                    //fecDocumento = ProvisionCompleto.FechaProvision, //Revisar
                                    idDocumento = ProvisionCompleto.idDocumento,
                                    serDocumento = ProvisionCompleto.NumSerie,
                                    numDocumento = ProvisionCompleto.NumDocumento,
                                    idDocumentoRef = ProvisionCompleto.idDocumentoRef,
                                    SerieDocumentoRef = ProvisionCompleto.numSerieRef,
                                    NumeroDocumentoRef = ProvisionCompleto.numDocumentoRef,
                                    idOrdenCompra = oOrdenCompra.idOrdenCompra,
                                    numRequisicion = String.Empty,
                                    idPersona = Convert.ToInt32(ProvisionCompleto.idPersona),
                                    idMoneda = ProvisionCompleto.CodMonedaProvision,
                                    indCambio = true,
                                    tipCambio = Convert.ToDecimal(ProvisionCompleto.TipCambio),
                                    impValorVenta = Convert.ToDecimal(ProvisionCompleto.CodMonedaProvision == "01" ? ProvisionCompleto.impImponBase : ProvisionCompleto.impImponSecun),
                                    Impuesto = Convert.ToDecimal(ProvisionCompleto.CodMonedaProvision == "01" ? ProvisionCompleto.impImpuestoBase : ProvisionCompleto.impImpuestoSecun),
                                    impTotal = Convert.ToDecimal(ProvisionCompleto.CodMonedaProvision == "01" ? ProvisionCompleto.impTotalBase : ProvisionCompleto.impTotalSecun),
                                    indPorAsociar = false,
                                    idAlmacenDestino = 0,
                                    tipMovimientoAsociado = null,
                                    idDocumentoAlmacenAsociado = null,
                                    
                                    Glosa = ProvisionCompleto.DesProvision,
                                    UsuarioRegistro = ProvisionCompleto.UsuarioRegistro
                                };

                                #endregion

                                #region Detalle

                                foreach (Provisiones_PorCCostoE itemDetalle in ProvisionCompleto.ListaPorCCosto)
                                {
                                    MovimientoAlmacenItemE oLote = new MovimientoAlmacenItemAD().ObtenerMovimiento_Almacen_ItemLote(ProvisionCompleto.idEmpresa, ProvisionCompleto.idOrdenCompra.Value, itemDetalle.idItem, ProvisionCompleto.idDocumentoRef, ProvisionCompleto.numSerieRef, ProvisionCompleto.numDocumentoRef);
                                    String nLote = String.Empty;

                                    if (oLote == null)
                                    {
                                        nLote = "0000000";
                                    }
                                    else
                                    {
                                        nLote = oLote.Lote;
                                    }

                                    Decimal ValorBase = 0, ValorRefe = 0;

                                    if (ProvisionCompleto.CodMonedaProvision == "01")
                                    {
                                        ValorBase = itemDetalle.subTotal;
                                        ValorRefe = itemDetalle.subTotal / itemDetalle.tipCambio;
                                    }
                                    else
                                    {
                                        ValorBase = itemDetalle.subTotal * itemDetalle.tipCambio;
                                        ValorRefe = itemDetalle.subTotal;
                                    }

                                    oItemMovimiento = new MovimientoAlmacenItemE()
                                    {
                                        idEmpresa = oMovimientoAlmacen.idEmpresa,
                                        tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                                        idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                        numItem = String.Format("{0:0000}", numItem),
                                        idArticulo = Convert.ToInt32(itemDetalle.idArticulo),
                                        Lote = nLote,
                                        idUbicacion = 0,
                                        Cantidad = 0,

                                        ImpCostoUnitarioBase = ValorBase,
                                        ImpCostoUnitarioRefe = ValorRefe,
                                        ImpTotalBase = ValorBase,
                                        ImpTotalRefe = ValorRefe,

                                        indCalidad = false,
                                        indConformidad = false,
                                        idCCostos = String.Empty,
                                        idCCostosUso = String.Empty,
                                        idArticuloUso = Variables.Cero,
                                        nroEnvases = Variables.Cero,
                                        Valorizado = false,
                                        nroParteProd = String.Empty,
                                        idItemCompra = itemDetalle.idItem,
                                        UsuarioRegistro = ProvisionCompleto.UsuarioRegistro
                                    };

                                    oMovimientoAlmacen.ListaAlmacenItem.Add(oItemMovimiento);
                                    numItem++;
                                }

                                #endregion

                                //Guardando el movimiento de salida en el almacen...
                                oMovimientoAlmacen = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Insertar);

                                //Actualizando datos de almacén en la provisión
                                new ProvisionesAD().ActualizarProvDatosAlmacen(ProvisionCompleto.idProvision, oAlmacen.idAlmacen, Operacion.idOperacion, oAlmacen.tipAlmacen.Value, oMovimientoAlmacen.tipMovimiento, oMovimientoAlmacen.idDocumentoAlmacen, ProvisionCompleto.UsuarioRegistro);
                            }

                            #endregion

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            #region Provision

                            if (ProvisionCompleto.idComprobante == Variables.RegistroCompra && ProvisionCompleto.idProvisionRev == null)
                            {
                                ProvisionRevision = new ProvisionesAD().RevisarDocProvisiones(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, ProvisionCompleto.idDocumento, ProvisionCompleto.NumSerie,
                                                                                            ProvisionCompleto.NumDocumento, Convert.ToInt32(ProvisionCompleto.idPersona), ProvisionCompleto.idProvision);
                                if (ProvisionRevision != null)
                                {
                                    throw new Exception(String.Format("El documento {0}-{1} {2} ya ha sido registrado el {3}", ProvisionRevision.idDocumento, ProvisionRevision.NumSerie, ProvisionRevision.NumDocumento,
                                                        ProvisionRevision.FechaProvision.ToString("d")));
                                }
                            }

                            //Actualizando la cabecera de la provisión
                            ProvisionCompleto = new ProvisionesAD().ActualizarProvisiones(ProvisionCompleto);

                            if (ActualizarDetalle) //Si es Verdadero ingresa para Actualizar el detalle
                            {
                                if (ProvisionCompleto.ListaPorCCosto != null)
                                {
                                    //Revisando para ver si hay O.C.
                                    if (ProvisionCompleto.idOrdenCompra != null && ProvisionCompleto.idOrdenCompra > 0)
                                    {
                                        oListaOcDetalle = new OrdenCompraItemAD().ListarOrdenCompraItem(ProvisionCompleto.idEmpresa, Convert.ToInt32(ProvisionCompleto.idOrdenCompra));
                                    }

                                    corItem = Variables.ValorUno;
                                    new Provisiones_PorCCostoAD().EliminarProvisiones_PorCCosto(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, ProvisionCompleto.idProvision);

                                    ValOC = false;

                                    // Si es Nota de Credito y es Devolucion Validar
                                    if ((ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97") && ProvisionCompleto.indAfectacionAlmacen == 1 && oListaOcDetalle != null && oListaOcDetalle.Count > 0)
                                    {
                                        ValOC = true;
                                    }

                                    if ((ProvisionCompleto.idDocumento != "CR" && ProvisionCompleto.idDocumento != "97") && oListaOcDetalle != null && oListaOcDetalle.Count > 0)
                                    {
                                        ValOC = true;
                                    }

                                    // Si la Reversion de una Provision de Compra en el Mes Anterior
                                    if (ProvisionCompleto.indReversion == false && ProvisionCompleto.idProvisionRev != null)
                                    {
                                        if (ProvisionCompleto.idProvisionRev > 0)
                                        {
                                            ValOC = false;
                                        }
                                    }

                                    if (ProvisionCompleto.ItemsEliminados != null && ProvisionCompleto.ItemsEliminados.Count > 0 && ProvisionCompleto.idOrdenCompra > 0)
                                    {
                                        if (ValOC)
                                        {
                                            foreach (Provisiones_PorCCostoE item in ProvisionCompleto.ItemsEliminados)
                                            {
                                                Decimal CantMovimiento = item.Cantidad;

                                                foreach (OrdenCompraItemE itemOc in oListaOcDetalle)
                                                {
                                                    if (itemOc.idEmpresa == item.idEmpresa && itemOc.idOrdenCompra == ProvisionCompleto.idOrdenCompra && itemOc.idArticuloServ == Convert.ToInt32(item.idArticulo) && Convert.ToInt32(itemOc.idItem) == item.idItem)
                                                    {
                                                        if (ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97")
                                                        {
                                                            itemOc.canProvisionada = itemOc.canProvisionada + CantMovimiento;
                                                        }
                                                        else
                                                        {
                                                            itemOc.canProvisionada = itemOc.canProvisionada - CantMovimiento;
                                                        }

                                                        if (CantMovimiento > (itemOc.CanOrdenada - itemOc.canProvisionada))
                                                        {
                                                            throw new Exception("La cantidad ingresada no puede ser mayor a la cantidad de la OC.");
                                                        }

                                                        if (CantMovimiento < (itemOc.CanOrdenada - itemOc.canProvisionada))
                                                        {
                                                            itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AP.ToString();
                                                        }
                                                        else
                                                        {
                                                            itemOc.tipEstadoProvision = EnumEstadoAtencionOC.PN.ToString();
                                                        }

                                                        new OrdenCompraItemAD().ActualizarCantProvOc(itemOc);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    foreach (Provisiones_PorCCostoE item in ProvisionCompleto.ListaPorCCosto)
                                    {
                                        item.idEmpresa = ProvisionCompleto.idEmpresa;
                                        item.idLocal = ProvisionCompleto.idLocal;
                                        item.idProvision = ProvisionCompleto.idProvision;
                                        item.idMoneda = ProvisionCompleto.CodMonedaProvision;
                                        // si se ha seleccionado una OC se respeta el item.
                                        if (ProvisionCompleto.idOrdenCompra == 0)
                                        {
                                            item.idItem = corItem;
                                        }
                                       
                                        new Provisiones_PorCCostoAD().InsertarProvisiones_PorCCosto(item);
                                        corItem++;

                                        if (ValOC)
                                        {
                                            //Si hay Detalle O.C. ingresa...
                                            if (item.Cantidad != item.CantidadTmp)
                                            {
                                                if (oListaOcDetalle != null && oListaOcDetalle.Count > 0)
                                                {
                                                    Decimal CantMovimiento = item.Cantidad;

                                                    foreach (OrdenCompraItemE itemOc in oListaOcDetalle)
                                                    {
                                                        if (itemOc.idEmpresa == item.idEmpresa && itemOc.idOrdenCompra == ProvisionCompleto.idOrdenCompra && itemOc.idArticuloServ == Convert.ToInt32(item.idArticulo) && Convert.ToInt32(itemOc.idItem) == item.idItem)
                                                        {
                                                            if (ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97")
                                                            {
                                                                itemOc.canProvisionada = itemOc.canProvisionada + item.CantidadTmp;
                                                            }
                                                            else
                                                            {
                                                                itemOc.canProvisionada = itemOc.canProvisionada - item.CantidadTmp;
                                                            }

                                                            if (CantMovimiento > (itemOc.CanOrdenada - itemOc.canProvisionada))
                                                            {
                                                                throw new Exception("La cantidad ingresada no puede ser mayor a la cantidad de la OC.");
                                                            }
                                                            else if (CantMovimiento < (itemOc.CanOrdenada - itemOc.canProvisionada))
                                                            {
                                                                itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AP.ToString();
                                                            }
                                                            else
                                                            {
                                                                itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AT.ToString();
                                                            }

                                                            if (ProvisionCompleto.idDocumento == "CR" || ProvisionCompleto.idDocumento == "97")
                                                            {
                                                                itemOc.canProvisionada = itemOc.canProvisionada - CantMovimiento;
                                                            }
                                                            else
                                                            {
                                                                itemOc.canProvisionada = itemOc.canProvisionada + CantMovimiento;
                                                            }

                                                            new OrdenCompraItemAD().ActualizarCantProvOc(itemOc);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (ProvisionCompleto.idHojaCosto != null && ProvisionCompleto.idDocumento == "DU")
                                {
                                    HojaCostoE HojaDua = new HojaCostoE()
                                    {
                                        idEmpresa = ProvisionCompleto.idEmpresa,
                                        idLocal = ProvisionCompleto.idLocal,
                                        idHojaCosto = Convert.ToInt32(ProvisionCompleto.idHojaCosto),
                                        DUA = String.IsNullOrWhiteSpace(ProvisionCompleto.NumSerie) ? ProvisionCompleto.NumDocumento : ProvisionCompleto.NumSerie + "-" + ProvisionCompleto.NumDocumento,
                                        fecDua = ProvisionCompleto.FechaDocumento,
                                        UsuarioModificacion = ProvisionCompleto.UsuarioRegistro
                                    };

                                    new HojaCostoAD().ActualizarHojaCostoDua(HojaDua);
                                }

                                //Actualizar el Nro de Reversión
                                if (!ProvisionCompleto.indReversion && ProvisionCompleto.idProvisionRev != null)
                                {
                                    if (ProvisionCompleto.idProvisionRev != ProvisionCompleto.idProvisionRevTmp)
                                    {
                                        Int32? idProvi = (Int32?)null;
                                        //Actualizando el anterior si en caso haya cambiado el nro de reversión por otro...
                                        new ProvisionesAD().ActualizarNumReversion(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, idProvi, Convert.ToInt32(ProvisionCompleto.idProvisionRevTmp), ProvisionCompleto.UsuarioRegistro);
                                        //Actualizando la reversión actual
                                        new ProvisionesAD().ActualizarNumReversion(ProvisionCompleto.idEmpresa, ProvisionCompleto.idLocal, Convert.ToInt32(ProvisionCompleto.idProvision), Convert.ToInt32(ProvisionCompleto.idProvisionRev), ProvisionCompleto.UsuarioRegistro);
                                    }
                                }
                            }

                            #endregion

                            #region Rendiciones

                            if (!ProvisionCompleto.EsLiquidacion && !ProvisionCompleto.EsRendicion && ProvisionCompleto.EstadoProvision == "RE")
                            {
                                SolicitudProveedorRendicionDetE oRendicionDet = new SolicitudProveedorRendicionDetAD().RendicionDetPorProvision(ProvisionCompleto.idProvision);

                                if (oRendicionDet != null)
                                {
                                    //Cabecera
                                    SolicitudProveedorRendicionE oRendicion = new SolicitudProveedorRendicionAD().ObtenerSolicitudProveedorRendicion(oRendicionDet.idRendicion);
                                    //Detalle
                                    oRendicion.oListaRendiciones = new SolicitudProveedorRendicionDetAD().ListarSolicitudProveedorRendicionDet(oRendicion.idRendicion);

                                    foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                                    {
                                        if (item.idProvision == ProvisionCompleto.idProvision)
                                        {
                                            item.idDocumento = ProvisionCompleto.idDocumento;
                                            item.numSerie = ProvisionCompleto.NumSerie;
                                            item.numDocumento = ProvisionCompleto.NumDocumento;
                                            item.fecDocumento = ProvisionCompleto.FechaDocumento.Date;
                                            item.idMoneda = ProvisionCompleto.CodMonedaProvision;
                                            item.desMoneda = ProvisionCompleto.desMoneda;
                                            item.MontoDoc = ProvisionCompleto.ImpMonedaOrigen;
                                            item.idMonedaRec = ProvisionCompleto.CodMonedaProvision;
                                            item.desMonedaRec = ProvisionCompleto.desMoneda;
                                            item.MontoRec = ProvisionCompleto.ImpMonedaOrigen;
                                            item.indTicaAuto = true;
                                            item.tipCambio = ProvisionCompleto.TipCambio;

                                            if (item.idMonedaRec == "01")
                                            {
                                                item.SolesRecibidos = item.MontoRec;
                                                item.DolaresRecibidos = item.MontoRec / item.tipCambio;
                                            }
                                            else
                                            {
                                                item.DolaresRecibidos = item.MontoRec;
                                                item.SolesRecibidos = item.MontoRec * item.tipCambio;
                                            }

                                            item.codCuenta = ProvisionCompleto.codCuenta;
                                            item.idAuxiliar = ProvisionCompleto.idPersona;
                                            item.idConcepto = null;
                                            item.indReparable = ProvisionCompleto.indReparable;
                                            item.idConceptoRep = ProvisionCompleto.idConceptoRep;
                                            item.desReferenciaRep = ProvisionCompleto.desReferenciaRep;
                                            item.EsAutomatico = true;
                                            item.idProvision = ProvisionCompleto.idProvision;
                                            item.indProvBusqueda = true;
                                            item.UsuarioModificacion = ProvisionCompleto.UsuarioModificacion;

                                            item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                        }
                                    }

                                    oRendicion.UsuarioModificacion = ProvisionCompleto.UsuarioModificacion;
                                    new SolicitudProveedorRendicionLN().GrabarRendicion(oRendicion, EnumOpcionGrabar.Actualizar);
                                }
                            }

                            #endregion

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return ProvisionCompleto;
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

        public ProvisionesE InsertarProvisiones(ProvisionesE provisiones)
        {
            try
            {
                return new ProvisionesAD().InsertarProvisiones(provisiones);
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

        public ProvisionesE ActualizarProvisiones(ProvisionesE provisiones)
        {
            try
            {
                return new ProvisionesAD().ActualizarProvisiones(provisiones);
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

        public ProvisionesE ActualizarProvisionesDetraccion(ProvisionesE provisiones)
        {
            try
            {
                return new ProvisionesAD().ActualizarProvisionesDetraccion(provisiones);
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

        public Int32 EliminarProvisiones(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    ProvisionesE oProvision = new ProvisionesAD().RecuperarProvisionesPorId(idEmpresa, idLocal, idProvision);

                    if (oProvision.AfectaOc)
                    {
                        #region Eliminando el movimiento de la Orden de compra

                        bool ValOC;

                        ValOC = false;

                        if (oProvision.idOrdenCompra > 0)
                        {
                            oProvision.ListaPorCCosto = new Provisiones_PorCCostoAD().RecuperarProvisiones_PorCCostoPorId(idEmpresa, idLocal, idProvision);
                            List<OrdenCompraItemE> oLista = new OrdenCompraItemAD().ListarOrdenCompraItem(idEmpresa, Convert.ToInt32(oProvision.idOrdenCompra));

                            if (oLista != null && oLista.Count > 0)
                            {
                                // Si es Nota de Credito y es Devolucion Validar
                                if ((oProvision.idDocumento == "CR" || oProvision.idDocumento == "97") && oProvision.indAfectacionAlmacen == 1 && oLista != null && oLista.Count > 0)
                                {
                                    ValOC = true;
                                }

                                if ((oProvision.idDocumento != "CR" && oProvision.idDocumento != "97") && oLista != null && oLista.Count > 0)
                                {
                                    ValOC = true;
                                }

                                foreach (Provisiones_PorCCostoE item in oProvision.ListaPorCCosto)
                                {
                                    Decimal Cantidad = item.Cantidad;

                                    ////Si hay Detalle O.C. ingresa...
                                    if (ValOC)
                                    {
                                        foreach (OrdenCompraItemE itemOc in oLista)
                                        {
                                            if (itemOc.idEmpresa == item.idEmpresa && itemOc.idOrdenCompra == oProvision.idOrdenCompra && itemOc.idArticuloServ == Convert.ToInt32(item.idArticulo) && Convert.ToInt32(itemOc.idItem) == item.idItem)
                                            {
                                                if (oProvision.idDocumento == "CR" || oProvision.idDocumento == "97")
                                                {
                                                    itemOc.canProvisionada = itemOc.canProvisionada + Cantidad;
                                                }
                                                else
                                                {
                                                    itemOc.canProvisionada = itemOc.canProvisionada - Cantidad;
                                                }

                                                if (itemOc.canProvisionada == 0)
                                                {
                                                    itemOc.tipEstadoProvision = EnumEstadoAtencionOC.PN.ToString();
                                                }
                                                else
                                                {
                                                    itemOc.tipEstadoProvision = EnumEstadoAtencionOC.AP.ToString();
                                                }

                                                new OrdenCompraItemAD().ActualizarCantProvOc(itemOc);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Eliminando el movimiento de almacén

                        if (oProvision.idDocumentoAlmacen != null && oProvision.idDocumentoAlmacen != 0)
                        {
                            // Eliminando el detalle
                            new MovimientoAlmacenItemAD().EliminarMovimiento_Almacen_ItemTodos(idEmpresa, oProvision.tipMovimientoAlmacen.Value, oProvision.idDocumentoAlmacen.Value);
                            // Eliminando la cabecera
                            new MovimientoAlmacenAD().EliminarMovimientoAlmacen(idEmpresa, oProvision.tipMovimientoAlmacen.Value, oProvision.idDocumentoAlmacen.Value);
                        }

                        #endregion 
                    }

                    //Eliminando la provisión
                    resp = new ProvisionesAD().EliminarProvisiones(idEmpresa, idLocal, idProvision);

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

        public List<ProvisionesE> ListarProvisiones(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String RazonSocial, String Estado, String idComprobante, String numFile, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new ProvisionesAD().ListarProvisiones(idEmpresa, idLocal, fecIni, fecFin, RazonSocial, Estado, idComprobante, numFile, idDocumento, NumSerie, NumDocumento);
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

        public List<ProvisionesE> ListarProvisionesNC(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String RazonSocial, String Estado, String idComprobante, String numFile, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new ProvisionesAD().ListarProvisionesNC(idEmpresa, idLocal, fecIni, fecFin, RazonSocial, Estado, idComprobante, numFile, idDocumento, NumSerie, NumDocumento);
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

        public ProvisionesE ObtenerProvisionPorOC(Int32 idEmpresa, Int32 idOrdenCompra)
        {
            try
            {
                return new ProvisionesAD().ObtenerProvisionPorOC(idEmpresa, idOrdenCompra);
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

        public ProvisionesE ObtenerProvisionPorReferencia(Int32 idEmpresa, Int32 idPersona, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new ProvisionesAD().ObtenerProvisionPorReferencia(idEmpresa,idPersona,idDocumento,NumSerie,NumDocumento);
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

        public ProvisionesE RecuperarProvisionesPorId(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Boolean PorRecibir = false, String ConDetalle = "S")
        {
            try
            {
                //Cabecera
                ProvisionesE oProvisiones = new ProvisionesAD().RecuperarProvisionesPorId(idEmpresa, idLocal, idProvision);

                if (oProvisiones != null)
                {
                    if (ConDetalle == "S")
                    {
                        ////Detalle por c.costo.
                        if (!PorRecibir)
                        {
                            oProvisiones.ListaPorCCosto = new Provisiones_PorCCostoAD().RecuperarProvisiones_PorCCostoPorId(idEmpresa, idLocal, idProvision);
                        }
                        else
                        {
                            oProvisiones.ListaPorCCosto = new Provisiones_PorCCostoAD().RecuperarProvisiones_PorCCostoPorIdPorRecibir(idEmpresa, idLocal, idProvision);
                        }
                    }
                }

                return oProvisiones;
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

        public ProvisionesE GenerarAsientoProvisiones(ProvisionesE oProvision, String Usuario, String Tipo = "N")
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 idEmpresa = oProvision.idEmpresa;
                    Int32 idLocal = oProvision.idLocal;
                    Int32 idProvision = oProvision.idProvision;

                    #region Rendiciones

                    if (!oProvision.EsLiquidacion && !oProvision.EsRendicion && oProvision.EstadoProvision == "RE")
                    {
                        SolicitudProveedorRendicionDetE oRendicion = new SolicitudProveedorRendicionDetAD().RendicionDetPorProvision(oProvision.idProvision);

                        if (oRendicion != null)
                        {
                            throw new Exception(String.Format("No se puede generar el asiento de la Provisión {0}, porque se encuentra en una Rendición", oProvision.idProvision.ToString()));
                        }
                    }

                    #endregion

                    List<Provisiones_PorCCostoE> oListaProvisiones = new Provisiones_PorCCostoAD().RecuperarProvisiones_PorCCostoPorId(idEmpresa, idLocal, idProvision);

                    if (oListaProvisiones.Count > 0)
                    {
                        ParTabla oIngreso = new ParTablaAD().ParTablaPorNemo("ING");
                        MovimientoAlmacenE oMovAlmacenNuevo = new MovimientoAlmacenE();
                        Decimal MontoDistribuir = 0;
                        List<OperacionE> oListaOperaciones = null;
                        Int32 idOperacion = 0;
                        Boolean GrabarMov = false;

                        foreach (Provisiones_PorCCostoE itemProv in oListaProvisiones)
                        {
                            if (itemProv.indCostoArticulo)
                            {
                                //Formando la lista con los códigos de las notas de ingreso.
                                List<String> oLista = new List<String>(itemProv.notasdeIngreso.Split(','));
                                MontoDistribuir = itemProv.subTotal; //Monto para la distribución

                                if (oLista.Count > 0)
                                {
                                    foreach (String itemCad in oLista)
                                    {
                                        //Buscando los movimientos del almacén
                                        MovimientoAlmacenE oMovimiento = new MovimientoAlmacenLN().ObtenerMovimientoAlmacenCompleto(idEmpresa, oIngreso.IdParTabla, Convert.ToInt32(itemCad));

                                        if (oMovimiento != null)
                                        {
                                            //Agregando a la nueva lista el detalle de los movimientos encontrados...
                                            foreach (MovimientoAlmacenItemE Det in oMovimiento.ListaAlmacenItem)
                                            {
                                                oMovAlmacenNuevo.ListaAlmacenItem.Add(Det);
                                            }
                                        }
                                    }

                                    //Actualizando los costos en el nuevo detalle
                                    Int32 numItem = 1;

                                    foreach (MovimientoAlmacenItemE Det in oMovAlmacenNuevo.ListaAlmacenItem)
                                    {
                                        Det.Cantidad = 0;

                                        if (oProvision.CodMonedaProvision == Variables.Soles)
                                        {
                                            Det.ImpCostoUnitarioBase = MontoDistribuir / oMovAlmacenNuevo.ListaAlmacenItem.Count;
                                            Det.ImpCostoUnitarioRefe = (MontoDistribuir / oMovAlmacenNuevo.ListaAlmacenItem.Count) / oProvision.TipCambio;
                                        }
                                        else
                                        {
                                            Det.ImpCostoUnitarioBase = MontoDistribuir / oMovAlmacenNuevo.ListaAlmacenItem.Count;
                                            Det.ImpCostoUnitarioRefe = (MontoDistribuir / oMovAlmacenNuevo.ListaAlmacenItem.Count) * oProvision.TipCambio;
                                        }

                                        Det.ImpTotalBase = 0;
                                        Det.ImpTotalRefe = 0;
                                        Det.UsuarioRegistro = Usuario;
                                        Det.numItem = String.Format("{0:0000}", numItem);
                                        Det.idItem = 0;
                                        numItem++;
                                    }
                                }

                                GrabarMov = true;
                            }
                            else
                            {
                                GrabarMov = false;
                            }

                            if (GrabarMov) //Si es verdadero entra
                            {
                                //Formando la cabecera...
                                AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(idEmpresa, itemProv.idAlmacen);
                                oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), idEmpresa, oIngreso.IdParTabla);

                                OperacionE Operacion = oListaOperaciones.Find
                                (
                                    delegate (OperacionE op) { return op.indServicio == true; }
                                );

                                if (Operacion == null)
                                {
                                    throw new Exception("No existe Tipo de Operacion para el Ajuste al Costo.");
                                }
                                else
                                {
                                    idOperacion = Operacion.idOperacion;
                                }

                                oMovAlmacenNuevo.idEmpresa = idEmpresa;
                                oMovAlmacenNuevo.tipMovimiento = oIngreso.IdParTabla;
                                oMovAlmacenNuevo.idAlmacen = Convert.ToInt32(oAlmacen.idAlmacen);
                                oMovAlmacenNuevo.tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen);
                                oMovAlmacenNuevo.idOperacion = idOperacion;
                                //oMovAlmacenNuevo.fecProceso = oProvision.FechaProvision; //Revisar
                                oMovAlmacenNuevo.indFactura = true;
                                //oMovAlmacenNuevo.fecDocumento = oProvision.FechaProvision; //Revisar
                                oMovAlmacenNuevo.idDocumento = oProvision.idDocumento;
                                oMovAlmacenNuevo.serDocumento = oProvision.NumSerie;
                                oMovAlmacenNuevo.numDocumento = oProvision.NumDocumento;
                                oMovAlmacenNuevo.idDocumentoRef = String.Empty;
                                oMovAlmacenNuevo.SerieDocumentoRef = String.Empty;
                                oMovAlmacenNuevo.NumeroDocumentoRef = String.Empty;
                                oMovAlmacenNuevo.idOrdenCompra = Variables.Cero;
                                oMovAlmacenNuevo.numRequisicion = String.Empty;
                                oMovAlmacenNuevo.idPersona = Convert.ToInt32(oProvision.idPersona);
                                oMovAlmacenNuevo.idMoneda = oProvision.CodMonedaProvision;
                                oMovAlmacenNuevo.indCambio = true;
                                oMovAlmacenNuevo.tipCambio = Convert.ToDecimal(oProvision.TipCambio);
                                oMovAlmacenNuevo.impValorVenta = 0;// Convert.ToDecimal(oProvision.imp);
                                oMovAlmacenNuevo.Impuesto = 0;//Convert.ToDecimal(DocumentoTmp.totIgv);
                                oMovAlmacenNuevo.impTotal = 0;//Convert.ToDecimal(DocumentoTmp.totTotal);
                                oMovAlmacenNuevo.indPorAsociar = false;
                                oMovAlmacenNuevo.idAlmacenDestino = 0;
                                oMovAlmacenNuevo.tipMovimientoAsociado = null;
                                oMovAlmacenNuevo.idDocumentoAlmacenAsociado = null;
                                oMovAlmacenNuevo.Glosa = String.Empty;
                                oMovAlmacenNuevo.UsuarioRegistro = Usuario;

                                new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovAlmacenNuevo, EnumOpcionGrabar.Insertar);
                            }
                        }
                    }

                    //Generando el asiento contable, recuperando los datos que se van a necesitar para la Cta.Cte.
                    oProvision = new ProvisionesAD().GenerarAsientoProvisiones(idEmpresa, idLocal, idProvision, Usuario, Tipo);
                    ////Recuperar la provisión
                    //oProvision = new ProvisionesLN().RecuperarProvisionesPorId(idEmpresa, idLocal, idProvision); esta por demás
                    
                    //Si es mayor a 0 insertar la cta.cte.
                    if (oProvision.ImpMonedaOrigen > 0)
                    {
                        InsertaCtaCteProvision(oProvision, Usuario);
                    }

                    oTrans.Complete();
                }

                return oProvision;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    case 547:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("id Provision: " + oProvision.idProvision.ToString() +"\n");
                        mensaje.Append("N° Documento: " + oProvision.idDocumento+" "+oProvision.NumSerie+"-"+oProvision.NumDocumento);
                        break;
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

        public Int32 EliminarVoucherProvision(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, String Usuario, String Estado)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Eliminando el asiento contable...
                    resp = new VoucherAD().EliminarVoucher(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);

                    #region Eliminando el movimiento en laCtaCte

                    EliminarCtaCteProvision(idEmpresa, idLocal, idProvision, Usuario);

                    #endregion Eliminando el movimiento en laCtaCte

                    resp = new ProvisionesAD().CambiarEstadoProvision(idEmpresa, idLocal, idProvision, Estado, Usuario);

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

        public Int32 EliminarVoucherProvisionMasivo(List<ProvisionesE> oListaProvisiones, String Usuario)
        {
            try
            {
                Int32 Resp = 0;
                Int32 RegiVouchers = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (ProvisionesE item in oListaProvisiones)
                    {
                        //Eliminando el asiento contable...
                        RegiVouchers = new VoucherAD().EliminarVoucher(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);

                        //Eliminando de la Cta.Cte.
                        EliminarCtaCteProvision(item.idEmpresa, item.idLocal, item.idProvision, Usuario);

                        //Volviendo a su estado donde corresponda...
                        if (item.EsLiquidacion) //Si se trata de una liquidación
                        {
                            new ProvisionesAD().CambiarEstadoProvision(item.idEmpresa, item.idLocal, item.idProvision, "LI", Usuario);
                        }
                        else if (item.EsRendicion) //Si se trata de una rendición
                        {
                            new ProvisionesAD().CambiarEstadoProvision(item.idEmpresa, item.idLocal, item.idProvision, "RD", Usuario);
                        }
                        else //Si no a registrado...
                        {
                            new ProvisionesAD().CambiarEstadoProvision(item.idEmpresa, item.idLocal, item.idProvision, "RE", Usuario);
                        }
                        
                        Resp++;
                    }

                    oTrans.Complete();
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

        public Int32 GenerarVoucherProvisionMasivo(List<ProvisionesE> oListaProvisiones, String Usuario, String Tipo = "N")
        {
            try
            {
                Int32 Resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (ProvisionesE item in oListaProvisiones)
                    {
                        new ProvisionesLN().GenerarAsientoProvisiones(item, Usuario, Tipo);
                        Resp++;
                    }

                    oTrans.Complete();
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

        public Int32 LimpiezaNrosVouchers(List<ProvisionesE> oListaProvisiones, String Usuario)
        {
            try
            {
                Int32 Resp = 0;

                foreach (ProvisionesE item in oListaProvisiones)
                {
                    new ProvisionesAD().LimpiarVoucherProvision(item.idEmpresa, item.idLocal, item.idProvision, item.numVoucher, Usuario);
                    Resp++;
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

        public List<ProvisionesE> ProvisionesPorRevertir(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new ProvisionesAD().ProvisionesPorRevertir(idEmpresa, idLocal);
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

        public List<ProvisionesE> ProvisionesPorRecibir(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new ProvisionesAD().ProvisionesPorRecibir(idEmpresa, idLocal);
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

        public Int32 ActualizarNumReversion(Int32 idEmpresa, Int32 idLocal, Int32? idProvision, Int32 idProvisionRev, String UsuarioModificacion)
        {
            try
            {
                return new ProvisionesAD().ActualizarNumReversion(idEmpresa, idLocal, idProvision, idProvisionRev, UsuarioModificacion);
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

        public ProvisionesE ObtenerProvisionPorNumReve(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            try
            {
                return new ProvisionesAD().ObtenerProvisionPorNumReve(idEmpresa, idLocal, idProvision);
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

        public List<ProvisionesE> ListarProvisionesCtaCte(Int32 idEmpresa, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new ProvisionesAD().ListarProvisionesCtaCte(idEmpresa, fecIni, fecFin);
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

        public List<ProvisionesE> ListarProvisionesDetraccion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String RazonSocial, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new ProvisionesAD().ListarProvisionesDetraccion(idEmpresa, fecIni, fecFin, RazonSocial, idDocumento, NumSerie, NumDocumento);
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

        public Int32 GenerarOpProvisionesDetracciones(List<ProvisionesE> oListaProvisionesDetra, Int32 idEmpresa, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //// Obteniendo Tipo de Pago DETRACCION
                    TipoPagoE oTipoPago = new TipoPagoAD().ObtenerTipoPagoPorTipo("DETR");

                    if (oTipoPago == null)
                    {
                        throw new Exception("No se ha configurado ningún Tipo de Pago para Detracciones Masivas.");
                    }

                    //// Obteniendo el concepto de acuerdo al Tipo de Pago DETRACCION
                    List<TipoPagoDetE> DetallePago = new TipoPagoDetAD().ListarTipoPagoDet(idEmpresa, oTipoPago.codTipoPago);

                    TipoPagoDetE oTipoPagoDet = DetallePago.Find
                    (
                        delegate (TipoPagoDetE t) { return t.desConcepto.ToUpper().Contains("DETRACCION"); }
                    );

                    if (oTipoPagoDet == null)
                    {
                        throw new Exception("No se ha configurado ningún concepto para el Detracciones Masivas.");
                    }

                    //Verificando si existe la Forma de Pago 009 - Cargo Cta Bancaria
                    FormaPagoE oFormaPago = new FormaPagoAD().ObtenerFormaPago("009");

                    if (oFormaPago == null)
                    {
                        throw new Exception("No existe forma de pago con el código 009.");
                    }

                    #region Cabecera de la OP

                    OrdenPagoE OrdenPago = new OrdenPagoE()
                    {
                        idEmpresa = idEmpresa,
                        idLocal = oListaProvisionesDetra[0].idLocal,
                        codOrdenPago = String.Empty,
                        codTipoPago = oTipoPago.codTipoPago,
                        idConcepto = Convert.ToInt32(oTipoPagoDet.idConcepto),
                        codFormaPago = "009",
                        Fecha = oListaProvisionesDetra[0].fecOrdenPago.Date,
                        idPersona = null,
                        idPersonaBeneficiario = null,
                        idMoneda = "0",
                        Monto = 0,
                        Glosa = String.Empty,
                        VieneDe = "D", //Declaración de Detracciones
                        UsuarioRegistro = Usuario
                    };

                    #endregion

                    #region Detalle de la OP

                    Int32? idBanco = null;
                    Int32? tipCuentaBanco = null;
                    String idMonedaBanco = String.Empty;
                    String numCuentaBancaria = String.Empty;

                    foreach (ProvisionesE item in oListaProvisionesDetra)
                    {
                        OrdenPagoDetE PagoDetalle = null;

                        if (String.IsNullOrWhiteSpace(item.NumVerPlanCuentas) || String.IsNullOrWhiteSpace(item.codCuenta))
                        {
                            throw new Exception("Falta la cuenta contable de Compras.");
                        }

                        if (oFormaPago.indDatosBancoAuxi)
                        {
                            ProveedorCuentaE oProveedorCuenta = new ProveedorCuentaAD().ObtenerProvCtaDefecto(Convert.ToInt32(item.idPersona), idEmpresa, item.CodMonedaProvision);

                            if (oProveedorCuenta == null)
                            {
                                throw new Exception(String.Format("El proveedor no tiene cuentas bancarias para la moneda {0}. No podrá generar la O.P.", (item.CodMonedaProvision == "01" ? "Soles" : "Dólares")));
                            }

                            idBanco = oProveedorCuenta.idPersonaBanco;
                            tipCuentaBanco = oProveedorCuenta.tipCuenta;
                            idMonedaBanco = oProveedorCuenta.idMoneda;
                            numCuentaBancaria = !String.IsNullOrWhiteSpace(oProveedorCuenta.numCuenta.Trim()) ? oProveedorCuenta.numCuenta.Trim() : oProveedorCuenta.numInterbancaria.Trim();
                        }
                        else
                        {
                            idBanco = null;
                            tipCuentaBanco = null;
                            idMonedaBanco = String.Empty;
                            numCuentaBancaria = String.Empty;
                        }

                        PagoDetalle = new OrdenPagoDetE()
                        {
                            codTipoPago = oTipoPago.codTipoPago,
                            idConcepto = Convert.ToInt32(oTipoPagoDet.idConcepto),
                            codFormaPago = "009",
                            Fecha = item.FechaDocumento,
                            idProveedor = Convert.ToInt32(item.idPersona),
                            idDocumento = item.idDocumento,
                            serDocumento = item.NumSerie,
                            numDocumento = item.NumDocumento,
                            idMoneda = item.CodMonedaProvision,
                            Monto = item.MontoDetraccion,
                            idMonedaPago = "01",
                            MontoPago = item.Redondeo,
                            TipPartidaPresu = item.tipPartidaPresu,
                            CodPartidaPresu = item.CodPartidaPresu,
                            Concepto = String.Empty,
                            Descripcion = String.Empty,
                            numVerPlanCuentas = item.NumVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            idBanco = idBanco,
                            tipCuenta = tipCuentaBanco,
                            idMonedaBanco = idMonedaBanco,
                            numCtaBancaria = numCuentaBancaria,
                            indPago = false,
                            indAuto = true,
                            UsuarioRegistro = Usuario
                        };

                        OrdenPago.ListaOrdenPago.Add(PagoDetalle);

                        resp++;
                    } 

                    #endregion

                    ////Grabando la nueva Orden de Pago
                    OrdenPago = new OrdenPagoLN().GrabarOrdenPago(OrdenPago, EnumOpcionGrabar.Insertar);

                    #region Control de Detracciones

                    List<ControlDetraccionesE> oControlDetra = new List<ControlDetraccionesE>();

                    foreach (OrdenPagoDetE item in OrdenPago.ListaOrdenPago)
                    {
                        ControlDetraccionesE oDetra = new ControlDetraccionesE()
                        {
                            idEmpresa = idEmpresa,
                            idSistema = 5, //Compras
                            idOrdenPago = OrdenPago.idOrdenPago,
                            idPersona = item.idProveedor,
                            idDocumento = item.idDocumento,
                            numSerie = item.serDocumento,
                            numDocumento = item.numDocumento,
                            NombreArchivo = String.Empty,
                            UsuarioRegistro = Usuario
                        };

                        new ControlDetraccionesAD().InsertarControlDetracciones(oDetra);
                    }

                    #endregion

                    //Completando la transacción
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

        public List<ProvisionesE> ProvisionesPorEstado(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Estado)
        {
            try
            {
                return new ProvisionesAD().ProvisionesPorEstado(idEmpresa, idLocal, fecIni, fecFin, Estado);
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

        #region Procedimientos Privados

        private void InsertaCtaCteProvision(ProvisionesE oProvision, String Usuario)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 idCtaCte = 0;
                    Int32 idCtaCteItem = 0;
                    Int32 idCtaCteDetra = 0;

                    if (!oProvision.indReversion && oProvision.EsAnticipo == 0)
                    {
                        CtaCteE oCtaCteRevision = new CtaCteAD().ObtenerMaeCtaCte(oProvision.idEmpresa, Convert.ToInt32(oProvision.idPersona), oProvision.idDocumento, oProvision.NumSerie, oProvision.NumDocumento, false);

                        if (oCtaCteRevision == null)
                        {
                            #region Cabecera

                            CtaCteE oCtaCte = new CtaCteE
                            {
                                idEmpresa = oProvision.idEmpresa,
                                idPersona = Convert.ToInt32(oProvision.idPersona),
                                idDocumento = oProvision.idDocumento,
                                numSerie = oProvision.NumSerie,
                                numDocumento = oProvision.NumDocumento,
                                idMoneda = oProvision.CodMonedaProvision,
                                MontoOrig = Convert.ToDecimal(oProvision.ImpMonedaOrigen),
                                TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                FechaDocumento = Convert.ToDateTime(oProvision.FechaDocumento),
                                FechaVencimiento = Convert.ToDateTime(oProvision.FechaVencimiento),
                                FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                codCuenta = oProvision.codCuenta,
                                AnnoVencimiento = String.Empty,
                                MesVencimiento = String.Empty,
                                SemanaVencimiento = String.Empty,
                                tipPartidaPresu = oProvision.tipPartidaPresu,
                                codPartidaPresu = oProvision.CodPartidaPresu,
                                desGlosa = oProvision.DesProvision,
                                FechaOperacion = Convert.ToDateTime(oProvision.FechaProvision),
                                EsDetraCab = false,
                                idCtaCteOrigen = 0,
                                idSistema = 5,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                            //Obteniendo el id de la ctacte original...
                            idCtaCte = oCtaCte.idCtaCte;

                            #endregion

                            #region Detalle

                            #region Cargo

                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                            {
                                idEmpresa = oProvision.idEmpresa,
                                idCtaCte = idCtaCte,
                                idDocumentoMov = oProvision.idDocumento,
                                SerieMov = oProvision.NumSerie,
                                NumeroMov = oProvision.NumDocumento,
                                FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                idMoneda = oProvision.CodMonedaProvision,
                                MontoMov = Convert.ToDecimal(oProvision.ImpMonedaOrigen),
                                TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                TipAccion = EnumEstadoDocumentos.C.ToString(),
                                numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                codCuenta = oProvision.codCuenta,
                                desGlosa = oProvision.DesProvision,
                                EsDetraccion = false,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                            //Recuperando el Id del item de la ctacte original...
                            idCtaCteItem = oCtaCteDet.idCtaCteItem;

                            #endregion

                            //Si se trata de una liquidación
                            if (oProvision.EsLiquidacion)
                            {
                                Decimal MontoAbono = oProvision.ImpMonedaOrigen;

                                if (oProvision.indPagoDetra)
                                {
                                    MontoAbono = oProvision.ImpMonedaOrigen - oProvision.MontoDetraccion;
                                }

                                #region Abono

                                oCtaCteDet = new CtaCte_DetE
                                {
                                    idEmpresa = oProvision.idEmpresa,
                                    idCtaCte = idCtaCte,
                                    idDocumentoMov = oProvision.idDocumento,
                                    SerieMov = oProvision.NumSerie,
                                    NumeroMov = oProvision.NumDocumento,
                                    FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                    idMoneda = oProvision.CodMonedaProvision,
                                    MontoMov = MontoAbono,
                                    TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                    TipAccion = EnumEstadoDocumentos.A.ToString(),
                                    numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                    codCuenta = oProvision.codCuenta,
                                    desGlosa = oProvision.DesProvision,
                                    EsDetraccion = false,
                                    UsuarioRegistro = Usuario
                                };

                                oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                #endregion

                                //Actualizacion la fecha de cancelación
                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, oProvision.FechaProvision, Usuario); 
                            }

                            #endregion

                            //Actualizando el idCtaCte a la Provisión
                            new ProvisionesAD().ActualizarIdCtaCteProvision(oProvision.idProvision, idCtaCte, idCtaCteItem, Usuario);

                            //Si la empresa paga la detracción
                            if (oProvision.indPagoDetra)
                            {
                                #region Linea de detracción que entra como abono al documento original

                                oCtaCteDet = new CtaCte_DetE
                                {
                                    idEmpresa = oProvision.idEmpresa,
                                    idCtaCte = idCtaCte, //Id de la CtaCte Original
                                    idDocumentoMov = oProvision.idDocumento,
                                    SerieMov = oProvision.NumSerie,
                                    NumeroMov = oProvision.NumDocumento,
                                    FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                    idMoneda = oProvision.CodMonedaProvision,
                                    MontoMov = Convert.ToDecimal(oProvision.MontoDetraccion),
                                    TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                    TipAccion = EnumEstadoDocumentos.A.ToString(),
                                    numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                    codCuenta = oProvision.codCuenta,
                                    desGlosa = oProvision.DesProvision,
                                    EsDetraccion = true,
                                    UsuarioRegistro = Usuario
                                };

                                new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                #endregion

                                #region Cuentas para la detracción

                                ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(oProvision.idEmpresa);
                                String CuentaDetra = String.Empty;

                                if (oParametroConta.indDetraccion)
                                {
                                    if (oProvision.CodMonedaProvision == Variables.Soles)
                                    {
                                        CuentaDetra = oParametroConta.ctaDetraccion;
                                    }
                                    else
                                    {
                                        CuentaDetra = oParametroConta.ctaDetraccionDol;
                                    }

                                    if (String.IsNullOrWhiteSpace(CuentaDetra))
                                    {
                                        throw new Exception("No existe ninguna cuenta para la Detracción en los Parámetros Contables.");
                                    }
                                }
                                else
                                {
                                    CuentaDetra = oProvision.codCuenta;
                                }

                                #endregion

                                #region Cabecera Detraccion

                                oCtaCte = new CtaCteE
                                {
                                    idEmpresa = oProvision.idEmpresa,
                                    idPersona = Convert.ToInt32(oProvision.idPersona),
                                    idDocumento = oProvision.idDocumento,
                                    numSerie = oProvision.NumSerie,
                                    numDocumento = oProvision.NumDocumento,
                                    idMoneda = oProvision.CodMonedaProvision,
                                    MontoOrig = Convert.ToDecimal(oProvision.MontoDetraccion),
                                    TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                    FechaDocumento = Convert.ToDateTime(oProvision.FechaDocumento),
                                    FechaVencimiento = Convert.ToDateTime(oProvision.FechaVencimiento),
                                    FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                    numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                    codCuenta = CuentaDetra,
                                    AnnoVencimiento = String.Empty,
                                    MesVencimiento = String.Empty,
                                    SemanaVencimiento = String.Empty,
                                    tipPartidaPresu = oProvision.tipPartidaPresu,
                                    codPartidaPresu = oProvision.CodPartidaPresu,
                                    desGlosa = oProvision.DesProvision,
                                    FechaOperacion = Convert.ToDateTime(oProvision.FechaProvision),
                                    EsDetraCab = true,
                                    idCtaCteOrigen = idCtaCte, //Id. del Documento Original.
                                    idSistema = 5,
                                    UsuarioRegistro = Usuario
                                };

                                oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                //Obteniendo el nuevo id de la ctacte de la detracción...
                                idCtaCteDetra = oCtaCte.idCtaCte;

                                #endregion

                                #region Detalle de la detracción

                                #region Cargo

                                oCtaCteDet = new CtaCte_DetE
                                {
                                    idEmpresa = oProvision.idEmpresa,
                                    idCtaCte = idCtaCteDetra,
                                    idDocumentoMov = oProvision.idDocumento,
                                    SerieMov = oProvision.NumSerie,
                                    NumeroMov = oProvision.NumDocumento,
                                    FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                    idMoneda = oProvision.CodMonedaProvision,
                                    MontoMov = Convert.ToDecimal(oProvision.MontoDetraccion),
                                    TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                    TipAccion = EnumEstadoDocumentos.C.ToString(),
                                    numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                    codCuenta = CuentaDetra,
                                    desGlosa = oProvision.DesProvision,
                                    EsDetraccion = true,
                                    UsuarioRegistro = Usuario
                                };

                                oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet); 

                                #endregion

                                if (oProvision.EsLiquidacion)
                                {
                                    #region Abono

                                    oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = oProvision.idEmpresa,
                                        idCtaCte = idCtaCteDetra,
                                        idDocumentoMov = oProvision.idDocumento,
                                        SerieMov = oProvision.NumSerie,
                                        NumeroMov = oProvision.NumDocumento,
                                        FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                        idMoneda = oProvision.CodMonedaProvision,
                                        MontoMov = Convert.ToDecimal(oProvision.MontoDetraccion),
                                        TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                        TipAccion = EnumEstadoDocumentos.A.ToString(),
                                        numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                        codCuenta = CuentaDetra,
                                        desGlosa = oProvision.DesProvision,
                                        EsDetraccion = true,
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                    //Actualizando la fecha de cancelación
                                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, oProvision.FechaProvision, Usuario); 

                                    #endregion
                                }

                                #endregion
                            }
                        }
                    }

                    if (!oProvision.indReversion && oProvision.EsAnticipo == 1)
                    {
                        #region Cabecera

                        AnticipoCtaCteE oCtaCte = new AnticipoCtaCteE
                        {
                            idEmpresa = oProvision.idEmpresa,
                            idPersona = Convert.ToInt32(oProvision.idPersona),
                            idDocumento = oProvision.idDocumento,
                            numSerie = oProvision.NumSerie,
                            numDocumento = oProvision.NumDocumento,
                            idMoneda = oProvision.CodMonedaProvision,
                            MontoOrig = Convert.ToDecimal(oProvision.ImpMonedaOrigen),
                            TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                            FechaDocumento = Convert.ToDateTime(oProvision.FechaDocumento),
                            FechaVencimiento = Convert.ToDateTime(oProvision.FechaVencimiento),
                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                            numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                            codCuenta = oProvision.ListaPorCCosto[0].codCuenta,
                            AnnoVencimiento = String.Empty,
                            MesVencimiento = String.Empty,
                            SemanaVencimiento = String.Empty,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            desGlosa = oProvision.DesProvision,
                            FechaOperacion = Convert.ToDateTime(oProvision.FechaProvision),
                            EsDetraCab = false,
                            idCtaCteOrigen = 0,
                            idSistema = 5,
                            UsuarioRegistro = Usuario
                        };

                        oCtaCte = new AnticipoCtaCteAD().InsertarAnticipoCtaCte(oCtaCte);

                        //Obteniendo el id de la ctacte...
                        idCtaCte = oCtaCte.idCtaCte;

                        #endregion

                        #region Detalle

                        AnticipoCtaCteDetE oCtaCteDet = new AnticipoCtaCteDetE
                        {
                            idEmpresa = oProvision.idEmpresa,
                            idCtaCte = idCtaCte,
                            idDocumentoMov = oProvision.idDocumento,
                            SerieMov = oProvision.NumSerie,
                            NumeroMov = oProvision.NumDocumento,
                            FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                            idMoneda = oProvision.CodMonedaProvision,
                            MontoMov = Convert.ToDecimal(oProvision.ImpMonedaOrigen),
                            TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                            numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                            codCuenta = oProvision.ListaPorCCosto[0].codCuenta,
                            desGlosa = oProvision.DesProvision,
                            EsDetraccion = false,
                            UsuarioRegistro = Usuario
                        };

                        oCtaCteDet = new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);

                        //Recuperando el item
                        idCtaCteItem = oCtaCteDet.idCtaCteItem;

                        #endregion

                        //Actualizando el idCtaCte a la Provisión
                        new ProvisionesAD().ActualizarIdCtaCteProvision(oProvision.idProvision, idCtaCte, idCtaCteItem, Usuario);

                        //Si la empresa paga la detracción
                        if (oProvision.indPagoDetra)
                        {
                            #region Linea de detracción que entra como abono al documento original

                            oCtaCteDet = new AnticipoCtaCteDetE
                            {
                                idEmpresa = oProvision.idEmpresa,
                                idCtaCte = idCtaCte,
                                idDocumentoMov = oProvision.idDocumento,
                                SerieMov = oProvision.NumSerie,
                                NumeroMov = oProvision.NumDocumento,
                                FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                idMoneda = oProvision.CodMonedaProvision,
                                MontoMov = Convert.ToDecimal(oProvision.MontoDetraccion),
                                TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                TipAccion = EnumEstadoDocumentos.A.ToString(),
                                numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                codCuenta = oProvision.codCuenta,
                                desGlosa = oProvision.DesProvision,
                                EsDetraccion = true,
                                UsuarioRegistro = Usuario
                            };

                            new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);

                            #endregion

                            #region Cuenta de la detracción

                            ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(oProvision.idEmpresa);
                            String CuentaDetra = String.Empty;

                            if (oParametroConta.indDetraccion)
                            {
                                if (oProvision.CodMonedaProvision == Variables.Soles)
                                {
                                    CuentaDetra = oParametroConta.ctaDetraccion;
                                }
                                else
                                {
                                    CuentaDetra = oParametroConta.ctaDetraccionDol;
                                }

                                if (String.IsNullOrWhiteSpace(CuentaDetra))
                                {
                                    throw new Exception("No existe ninguna cuenta para la Detracción en los Parámetros Contables.");
                                }
                            }
                            else
                            {
                                CuentaDetra = oProvision.codCuenta;
                            }

                            #endregion

                            #region Cabecera Detraccion

                            oCtaCte = new AnticipoCtaCteE
                            {
                                idEmpresa = oProvision.idEmpresa,
                                idPersona = Convert.ToInt32(oProvision.idPersona),
                                idDocumento = oProvision.idDocumento,
                                numSerie = oProvision.NumSerie,
                                numDocumento = oProvision.NumDocumento,
                                idMoneda = oProvision.CodMonedaProvision,
                                MontoOrig = Convert.ToDecimal(oProvision.MontoDetraccion),
                                TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                FechaDocumento = Convert.ToDateTime(oProvision.FechaDocumento),
                                FechaVencimiento = Convert.ToDateTime(oProvision.FechaVencimiento),
                                FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                codCuenta = CuentaDetra,
                                AnnoVencimiento = String.Empty,
                                MesVencimiento = String.Empty,
                                SemanaVencimiento = String.Empty,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                desGlosa = oProvision.DesProvision,
                                FechaOperacion = Convert.ToDateTime(oProvision.FechaProvision),
                                EsDetraCab = true,
                                idCtaCteOrigen = idCtaCte,
                                idSistema = 5,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCte = new AnticipoCtaCteAD().InsertarAnticipoCtaCte(oCtaCte);

                            //Obteniendo el id de la ctacte...
                            idCtaCteDetra = oCtaCte.idCtaCte;

                            #endregion

                            #region Detalle de la detracción

                            oCtaCteDet = new AnticipoCtaCteDetE //Cargo
                            {
                                idEmpresa = oProvision.idEmpresa,
                                idCtaCte = idCtaCteDetra,
                                idDocumentoMov = oProvision.idDocumento,
                                SerieMov = oProvision.NumSerie,
                                NumeroMov = oProvision.NumDocumento,
                                FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                idMoneda = oProvision.CodMonedaProvision,
                                MontoMov = Convert.ToDecimal(oProvision.MontoDetraccion),
                                TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                TipAccion = EnumEstadoDocumentos.C.ToString(),
                                numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                codCuenta = CuentaDetra,
                                desGlosa = oProvision.DesProvision,
                                EsDetraccion = true,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCteDet = new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);

                            #endregion
                        }
                    }

                    if (!oProvision.indReversion && oProvision.EsAnticipo == 2)
                    {
                        oProvision.ListaPorCCosto = new Provisiones_PorCCostoAD().RecuperarProvisiones_PorCCostoPorId(oProvision.idEmpresa, oProvision.idLocal, oProvision.idProvision);

                        foreach (Provisiones_PorCCostoE item in oProvision.ListaPorCCosto)
                        {
                            if (item.Tipo == "P") //G=Gasto S=Servicio A=Articulo C=Activo N=Anticipo P=Aplicacion de Anticipo
                            {
                                #region Insertar el abono

                                //Verificando si hay abonos
                                List<AnticipoCtaCteDetE> ListaTemp = new AnticipoCtaCteDetAD().ListarAnticipoCtaCteDetAbonos(oProvision.idEmpresa, Convert.ToInt32(item.idCtaCteAnticipo));
                                AnticipoCtaCteDetE oCtaCteDet = null;

                                //Sino hay nada de abonos lo inserta como nuevo
                                if (ListaTemp == null && ListaTemp.Count == 0)
                                {
                                    //Linea de detracción que entra como abono al documento original
                                    oCtaCteDet = new AnticipoCtaCteDetE
                                    {
                                        idEmpresa = oProvision.idEmpresa,
                                        idCtaCte = Convert.ToInt32(item.idCtaCteAnticipo),
                                        idDocumentoMov = oProvision.idDocumento,
                                        SerieMov = oProvision.NumSerie,
                                        NumeroMov = oProvision.NumDocumento,
                                        FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                        idMoneda = oProvision.CodMonedaProvision,
                                        MontoMov = Convert.ToDecimal(oProvision.CodMonedaProvision == "01" ? item.impSoles : item.impDolares),
                                        TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                        TipAccion = EnumEstadoDocumentos.A.ToString(),
                                        numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                        codCuenta = oProvision.codCuenta,
                                        desGlosa = oProvision.DesProvision,
                                        EsDetraccion = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);
                                }
                                else //Caso contrario si hay abonos
                                {
                                    //Verificar si el documento ya ha sido ingresado
                                    AnticipoCtaCteDetE DetTmp = ListaTemp.Find
                                    (
                                        delegate (AnticipoCtaCteDetE op)
                                        {
                                            return op.idDocumentoMov == oProvision.idDocumento
                                                     && op.SerieMov == oProvision.NumSerie
                                                     && op.NumeroMov == oProvision.NumDocumento;
                                        }
                                    );

                                    //Sino existe lo inserta
                                    if (DetTmp == null)
                                    {
                                        //Linea de detracción que entra como abono al documento original
                                        oCtaCteDet = new AnticipoCtaCteDetE
                                        {
                                            idEmpresa = oProvision.idEmpresa,
                                            idCtaCte = Convert.ToInt32(item.idCtaCteAnticipo),
                                            idDocumentoMov = oProvision.idDocumento,
                                            SerieMov = oProvision.NumSerie,
                                            NumeroMov = oProvision.NumDocumento,
                                            FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                            idMoneda = oProvision.CodMonedaProvision,
                                            MontoMov = Convert.ToDecimal(oProvision.CodMonedaProvision == "01" ? item.impSoles : item.impDolares),
                                            TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                            TipAccion = EnumEstadoDocumentos.A.ToString(),
                                            numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                            codCuenta = oProvision.codCuenta,
                                            desGlosa = oProvision.DesProvision,
                                            EsDetraccion = false,
                                            UsuarioRegistro = Usuario
                                        };

                                        new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);
                                    }
                                    else //Caso contrario lo actualiza
                                    {
                                        oCtaCteDet = new AnticipoCtaCteDetE
                                        {
                                            idEmpresa = oProvision.idEmpresa,
                                            idCtaCte = Convert.ToInt32(item.idCtaCteAnticipo),
                                            idDocumentoMov = oProvision.idDocumento,
                                            SerieMov = oProvision.NumSerie,
                                            NumeroMov = oProvision.NumDocumento,
                                            FechaMovimiento = Convert.ToDateTime(oProvision.FechaProvision),
                                            idMoneda = oProvision.CodMonedaProvision,
                                            MontoMov = Convert.ToDecimal(oProvision.CodMonedaProvision == "01" ? item.impSoles : item.impDolares),
                                            TipoCambio = Convert.ToDecimal(oProvision.TipCambio),
                                            TipAccion = EnumEstadoDocumentos.A.ToString(),
                                            numVerPlanCuentas = oProvision.NumVerPlanCuentas,
                                            codCuenta = oProvision.codCuenta,
                                            desGlosa = oProvision.DesProvision,
                                            EsDetraccion = false,
                                            UsuarioModificacion = Usuario
                                        };

                                        new AnticipoCtaCteDetAD().ActualizarAnticipoCtaCteDet(oCtaCteDet);
                                    }
                                }

                                #endregion

                                #region Verificando Saldo de la CtaCte.

                                List<AnticipoCtaCteDetE> oListaCtaCteDet = new AnticipoCtaCteDetAD().ListarAnticipoCtaCteDet(oProvision.idEmpresa, Convert.ToInt32(item.idCtaCteAnticipo));

                                Decimal Saldo = 0;

                                foreach (AnticipoCtaCteDetE itemDet in oListaCtaCteDet)
                                {
                                    if (itemDet.TipAccion == "C")
                                    {
                                        Saldo = Saldo + Convert.ToDecimal(itemDet.MontoMov);
                                    }
                                    else
                                    {
                                        Saldo = Saldo - Convert.ToDecimal(itemDet.MontoMov);
                                    }
                                }

                                // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                                if (Saldo == 0)
                                {
                                    //oCtaCteCabecera.FechaCancelacion = documento.fecProceso;
                                    new AnticipoCtaCteAD().ActualizarFecCancelacionAnticipoCtaCte(oProvision.idEmpresa, Convert.ToInt32(item.idCtaCteAnticipo), oProvision.FechaProvision, oProvision.UsuarioModificacion);
                                }

                                #endregion
                            }
                        }
                    }

                    oTrans.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EliminarCtaCteProvision(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, String Usuario)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    ProvisionesE oProvision = new ProvisionesAD().RecuperarProvisionesPorId(idEmpresa, idLocal, idProvision);

                    if (oProvision != null)
                    {
                        if (oProvision.EsAnticipo == 0) //No es anticipo
                        {
                            CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorId(oProvision.idCtaCte.Value);
                            CtaCteE oCtaCteDetra = null;
                            
                            if (oCtaCte != null)
                            {
                                if (!oProvision.EsLiquidacion)
                                {
                                    //Para saber si el documento ya tiene abonos
                                    List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                    if (oListaCtaCte.Count > 0)
                                    {
                                        throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene movimientos, elimine los movimientos antes de anular la factura.", oProvision.idDocumento, oProvision.NumSerie, oProvision.NumDocumento));
                                    }
                                    else
                                    {
                                        //Eliminando toda la CtaCte del documento
                                        new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCte.idCtaCte);

                                        //Actualizando el idCtaCte a la Provisión
                                        new ProvisionesAD().ActualizarIdCtaCteProvision(oProvision.idProvision, null, null, Usuario);
                                    }

                                    //Eliminando la CtaCte de la detracción...
                                    //Buscando si existe detracción
                                    oCtaCteDetra = new CtaCteAD().ObtenerCtaCtePorIdCteOrigen(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                    if (oCtaCteDetra != null)
                                    {
                                        oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCteDetra.idEmpresa, oCtaCteDetra.idCtaCte, true);

                                        if (oListaCtaCte.Count > 0)
                                        {
                                            throw new Exception(String.Format("El documento {0} {1}-{2} de la detracción en la Cta. Cte. ya tiene movimientos, elimine los movimientos antes de anular el documento.", oProvision.idDocumento, oProvision.NumSerie, oProvision.NumDocumento));
                                        }
                                        else
                                        {
                                            //Eliminando toda la CtaCte del documento
                                            new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCteDetra.idCtaCte);
                                        }
                                    } 
                                }
                                else
                                {
                                    //Eliminando toda la CtaCte del documento
                                    new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCte.idCtaCte);

                                    //Actualizando el idCtaCte a la Provisión
                                    new ProvisionesAD().ActualizarIdCtaCteProvision(oProvision.idProvision, null, null, Usuario);

                                    //Eliminando la CtaCte de la detracción...
                                    //Buscando si existe detracción
                                    oCtaCteDetra = new CtaCteAD().ObtenerCtaCtePorIdCteOrigen(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                    if (oCtaCteDetra != null)
                                    {
                                        //Eliminando toda la CtaCte del documento
                                        new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCteDetra.idCtaCte);
                                    }
                                }
                            }
                        }
                        else if (oProvision.EsAnticipo == 1) //Es Anticipo
                        {
                            AnticipoCtaCteE oCtaCte = new AnticipoCtaCteAD().ObtenerAnticipoCtaCtePorId(oProvision.idCtaCte.Value);
                            AnticipoCtaCteE oCtaCteDetra = null;

                            //Para saber si el documento ya tiene abonos
                            if (oCtaCte != null)
                            {
                                List<AnticipoCtaCteDetE> oListaCtaCte = new AnticipoCtaCteDetAD().ListarAnticipoCtaCteDetAbonos(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                if (oListaCtaCte.Count > 0)
                                {
                                    throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene movimientos, elimine los movimientos antes de anular la factura.", oProvision.idDocumento, oProvision.NumSerie, oProvision.NumDocumento));
                                }
                                else
                                {
                                    //Eliminando toda la CtaCte del documento
                                    new AnticipoCtaCteAD().EliminarAnticipoCtaCteConDetalle(oCtaCte.idCtaCte);
                                    ////// Eliminando el detalle
                                    //new AnticipoCtaCteDetAD().EliminarAnticipoCtaCteDetalle(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                                    ////// Eliminando la cabecera
                                    //new AnticipoCtaCteAD().EliminarAnticipoCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                    //Actualizando el idCtaCte a la Provisión
                                    new ProvisionesAD().ActualizarIdCtaCteProvision(oProvision.idProvision, null, null, Usuario);
                                }

                                //Eliminando la CtaCte de la detracción...
                                //Buscando si existe detracción
                                oCtaCteDetra = new AnticipoCtaCteAD().ObtenerAnticipoCtaCtePorIdCteOrigen(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                if (oCtaCteDetra != null)
                                {
                                    oListaCtaCte = new AnticipoCtaCteDetAD().ListarAnticipoCtaCteDetAbonos(oCtaCteDetra.idEmpresa, oCtaCteDetra.idCtaCte);

                                    if (oListaCtaCte.Count > 0)
                                    {
                                        throw new Exception(String.Format("El documento {0} {1}-{2} de la detracción en la Cta. Cte. ya tiene movimientos, elimine los movimientos antes de anular la factura.", oProvision.idDocumento, oProvision.NumSerie, oProvision.NumDocumento));
                                    }
                                    else
                                    {
                                        //Eliminando toda la CtaCte del documento
                                        new AnticipoCtaCteAD().EliminarAnticipoCtaCteConDetalle(oCtaCteDetra.idCtaCte);
                                        //// Eliminando el detalle
                                        //new AnticipoCtaCteDetAD().EliminarAnticipoCtaCteDetalle(oCtaCteDetra.idEmpresa, oCtaCteDetra.idCtaCte);
                                        //// Eliminando la cabecera
                                        //new AnticipoCtaCteAD().EliminarAnticipoCtaCte(oCtaCteDetra.idEmpresa, oCtaCteDetra.idCtaCte);
                                    }
                                }
                            }
                        }
                        else if (oProvision.EsAnticipo == 2) //Aplicación de anticipo...
                        {
                            oProvision.ListaPorCCosto = new Provisiones_PorCCostoAD().RecuperarProvisiones_PorCCostoPorId(idEmpresa, idLocal, idProvision);

                            foreach (Provisiones_PorCCostoE item in oProvision.ListaPorCCosto)
                            {
                                if (item.Tipo == "P")
                                {
                                    //Eliminando el abono
                                    new AnticipoCtaCteDetAD().EliminarAnticipoCtaCteDetPorDocumento(oProvision.idEmpresa, oProvision.idDocumento, oProvision.NumSerie, oProvision.NumDocumento);

                                    #region Verificando Saldo de la CtaCte.

                                    List<AnticipoCtaCteDetE> oListaCtaCteDet = new AnticipoCtaCteDetAD().ListarAnticipoCtaCteDet(oProvision.idEmpresa, Convert.ToInt32(item.idCtaCteAnticipo));

                                    Decimal Saldo = 0;

                                    foreach (AnticipoCtaCteDetE itemDet in oListaCtaCteDet)
                                    {
                                        if (itemDet.TipAccion == "C")
                                        {
                                            Saldo = Saldo + Convert.ToDecimal(itemDet.MontoMov);
                                        }
                                        else
                                        {
                                            Saldo = Saldo - Convert.ToDecimal(itemDet.MontoMov);
                                        }
                                    }

                                    // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                                    if (Saldo != 0)
                                    {
                                        new AnticipoCtaCteAD().ActualizarFecCancelacionAnticipoCtaCte(oProvision.idEmpresa, Convert.ToInt32(item.idCtaCteAnticipo), Convert.ToDateTime("31-12-2100"), oProvision.UsuarioModificacion);
                                    }

                                    #endregion

                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        #endregion

    }
}
