using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Entidades.Almacen;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using AccesoDatos.Ventas;
using AccesoDatos.Maestros;
using AccesoDatos.Generales;
using AccesoDatos.Contabilidad;
using AccesoDatos.Tesoreria;
using AccesoDatos.Almacen;
using AccesoDatos.CtasPorCobrar;
using Negocio.Almacen;
using Negocio.CtasPorCobrar;
using Negocio.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace Negocio.Maestros
{
    public class EmisionDocumentoLN
    {

        //EL ruc es del Fundo San Miguel es por el tema del Pedido
        public EmisionDocumentoE GrabarDocumentos(EmisionDocumentoE documento, EnumOpcionGrabar OpcionGrabar, String indCierreTotal = "N", String RucEmpresa = "")
        {
            try
            {
                using (TransactionScope oTran = new TransactionScope())
                {
                    venParametrosE oParametroVenta = new venParametrosAD().ObtenerVenParametros(documento.idEmpresa);

                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Insertar:

                            #region Insertar

                            #region Cliente cuando es nuevo y no esta en la BD

                            if (documento.idPersona == 0)
                            {
                                Int32 tipPersona = Variables.Cero;
                                Int32 tipDocPersona = Variables.Cero;
                                Int32 Pais = Variables.Cero;
                                ParTabla oParTabla = null;

                                if (documento.idDocumento == "FV")
                                {
                                    #region Facturas

                                    //Tipo de Persona
                                    oParTabla = new ParTablaAD().ParTablaPorNemo("PERJU");

                                    if (oParTabla != null)
                                    {
                                        tipPersona = oParTabla.IdParTabla;
                                    }
                                    else
                                    {
                                        throw new Exception("No esta configurado el Tipo de Persona Jurídico en Parámetros Generales");
                                    }

                                    //Tipo de documento de identidad
                                    oParTabla = new ParTablaAD().ParTablaPorNemo("PERRUC");

                                    if (oParTabla != null)
                                    {
                                        tipDocPersona = oParTabla.IdParTabla;
                                    }
                                    else
                                    {
                                        throw new Exception("No esta configurado el Tipo de Documento(RUC) en Parámetros Generales");
                                    }

                                    Pais = 90;

                                    #endregion
                                }
                                else if (documento.idDocumento == "BV")
                                {
                                    #region Boletas

                                    if (documento.numRuc.Trim().Length == Variables.NroCaracteresDNI)
                                    {
                                        #region DNI

                                        //Tipo de Persona
                                        oParTabla = new ParTablaAD().ParTablaPorNemo("PERSR");

                                        if (oParTabla != null)
                                        {
                                            tipPersona = oParTabla.IdParTabla;
                                        }
                                        else
                                        {
                                            throw new Exception("No esta configurado el Tipo de Persona Natural en Parámetros Generales");
                                        }

                                        //Tipo de documento de identidad
                                        oParTabla = new ParTablaAD().ParTablaPorNemo("PERDNI");

                                        if (oParTabla != null)
                                        {
                                            tipDocPersona = oParTabla.IdParTabla;
                                        }
                                        else
                                        {
                                            throw new Exception("No esta configurado el Tipo de Documento(DNI) en Parámetros Generales");
                                        }

                                        Pais = 90;

                                        #endregion
                                    }
                                    else
                                    {
                                        #region Otros

                                        oParTabla = new ParTablaAD().ParTablaPorNemo("OTR");

                                        if (oParTabla != null)
                                        {
                                            tipPersona = oParTabla.IdParTabla;
                                        }
                                        else
                                        {
                                            throw new Exception("No esta configurado el Tipo de Persona Otros en Parámetros Generales");
                                        }

                                        //Tipo de documento de identidad
                                        oParTabla = new ParTablaAD().ParTablaPorNemo("PEROTR");

                                        if (oParTabla != null)
                                        {
                                            tipDocPersona = oParTabla.IdParTabla;
                                        }
                                        else
                                        {
                                            throw new Exception("No esta configurado el Tipo de Documento(Otros) en Parámetros Generales");
                                        }

                                        Pais = 0;

                                        #endregion
                                    }

                                    #endregion
                                }
                                else
                                {
                                    throw new Exception("Documento no autorizado para el Punto de Venta.");
                                }

                                //Insertando la Persona
                                Persona oPersona = new Persona()
                                {
                                    TipoPersona = tipPersona,
                                    RazonSocial = documento.RazonSocial,
                                    RUC = documento.numRuc,
                                    ApePaterno = String.Empty,
                                    ApeMaterno = String.Empty,
                                    Nombres = String.Empty,
                                    TipoDocumento = tipDocPersona,
                                    NroDocumento = documento.numRuc,
                                    Telefonos = String.Empty,
                                    Fax = String.Empty,
                                    Correo = String.Empty,
                                    Web = String.Empty,
                                    DireccionCompleta = documento.Direccion,
                                    idPais = Pais, //Peru
                                    idUbigeo = String.Empty,
                                    PrincipalContribuyente = false,
                                    AgenteRetenedor = false,
                                    idCanalVenta = documento.idCanalVenta,
                                    UsuarioRegistro = documento.UsuarioRegistro
                                };

                                oPersona = new PersonaAD().InsertarPersona(oPersona);
                                documento.idPersona = oPersona.IdPersona; //Actualizando el IdPersona cuando son nuevos clientes...

                                //Tipo de Cliente
                                oParTabla = new ParTablaAD().ParTablaPorNemo("TIPCLINOR");

                                if (oParTabla != null)
                                {
                                    //Insertando el Cliente
                                    ClienteE oCliente = new ClienteE()
                                    {
                                        idPersona = oPersona.IdPersona,
                                        idEmpresa = documento.idEmpresa,
                                        SiglaComercial = documento.RazonSocial,
                                        TipoCliente = oParTabla.IdParTabla,
                                        fecInscripcion = null,
                                        fecInicioEmpresa = null,
                                        tipConstitucion = null,
                                        tipRegimen = null,
                                        catCliente = null,
                                        indEstado = false,
                                        fecBaja = null,
                                        UsuarioRegistro = documento.UsuarioRegistro
                                    };

                                    new ClienteAD().InsertarCliente(oCliente);
                                }
                                else
                                {
                                    throw new Exception("No esta configurado el Tipo de Cliente(Normal) en Parámetros Generales");
                                }
                            } 

                            #endregion

                            //Insertando el nuevo documento...
                            documento = new EmisionDocumentoAD().InsertarEmisionDocumento(documento);

                            #region Detalle de la cabecera
		                    
                            if (documento.ListaItemsDocumento != null && documento.ListaItemsDocumento.Count > 0)
                            {
                                foreach (EmisionDocumentoDetE item in documento.ListaItemsDocumento)
                                {
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumento = documento.idDocumento;
                                    item.numSerie = documento.numSerie;
                                    item.numDocumento = documento.numDocumento;

                                    new EmisionDocumentoDetAD().InsertarEmisionDocumentoDet(item);

                                    //if (!String.IsNullOrEmpty(item.numOrdenProd))
                                    //{
                                    //    new OrdenProduccionDetAD().ActualizarEstadoOP(item.idEmpresa, item.idLocal, Convert.ToInt32(item.numOrdenProd), Convert.ToInt32(item.Lote),
                                    //                                                    item.idDocumento, item.numSerie, item.numDocumento);
                                    //}

                                    //if (Ordenes != null && Ordenes.Count != 0)
                                    //{
                                    //    foreach (OrdenProduccionDetE orden in Ordenes)
                                    //    {
                                    //        //Articulo = orden.desPresentacion.Trim();//orden.desArticulo;

                                    //        if (documento.idDocumento == EnumTipoDocumentoVenta.GV.ToString())//item.nomArticulo.Trim().Substring(0, Articulo.Length) == Articulo)
                                    //        {
                                    //            new OrdenProduccionDetAD().ActualizarGuiaVentaOP(orden.idEmpresa, orden.idLocal, orden.idProduccion, orden.idIItem, item.idDocumento,
                                    //                                                                item.numSerie, item.numDocumento, item.Item, EnumEstadoDocumentos.G.ToString());
                                    //        }
                                    //    }
                                    //}
                                }
                            }

                            #endregion

                            #region Listado de guias asociadas a una factura
                            
                            if (documento.ListaCanjeGuias != null && documento.ListaCanjeGuias.Count > 0)
                            {
                                foreach (CanjeGuiasE item in documento.ListaCanjeGuias)
                                {
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumentoFact = documento.idDocumento;
                                    item.numSerieFact = documento.numSerie;
                                    item.numDocumentoFact = documento.numDocumento;

                                    new CanjeGuiasAD().InsertarCanjeGuias(item);

                                    //if (RucEmpresa == "20452630886")//Fundo San Miguel
                                    //{
                                        //Actualizando el estado de las guias a Facturadas
                                        //new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString());
                                    //}
                                } 
                            }
	                        
                            #endregion

                            #region Listado gastos para una exportación

		                    if (documento.ListaGastosExportacion != null && documento.ListaGastosExportacion.Count > 0)
                            {
                                foreach (EmisionDocumentoExportaE item in documento.ListaGastosExportacion)
	                            {
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumento = documento.idDocumento;
                                    item.numSerie = documento.numSerie;
                                    item.numDocumento = documento.numDocumento;

                                    new EmisionDocumentoExportaAD().InsertarEmisionDocumentoExporta(item);
	                            }
                            } 

	                        #endregion

                            //Actualizando Correlativo del documento en numControlDet
                            new NumControlDetAD().ActualizarCorrelativoNumControlDet(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                            #region Actualizando el Nro de Guia en el pedido

		                    //if (documento.idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                      //      {
                      //          if (RucEmpresa == "20452630886")//Fundo San Miguel
                      //          {
                      //              oPedido = new PedidoCabAD().ObtenerPedidoCab(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado));
                      //          }
                      //          else
                      //          {
                      //              oPedido = new PedidoCabAD().RecuperarPedidoCabNacional(documento.idEmpresa, documento.idLocal, Convert.ToInt32(documento.nroDocAsociado));
                      //          }

                      //          if (oPedido != null)
                      //          {
                      //              oPedido.NroGuia = documento.numSerie + '-' + documento.numDocumento;
                      //              oPedido.UsuarioModificacion = documento.UsuarioModificacion;

                      //              if (String.IsNullOrEmpty(oPedido.nroFactura))
                      //              {
                      //                  oPedido.nroFactura = String.Empty;
                      //              }

                      //              if (String.IsNullOrEmpty(oPedido.nroBl))
                      //              {
                      //                  oPedido.nroBl = String.Empty;
                      //              }

                      //              if (String.IsNullOrEmpty(oPedido.nroDam))
                      //              {
                      //                  oPedido.nroDam = String.Empty;
                      //              }

                      //              if (oPedido.fecFactura == null)
                      //              {
                      //                  oPedido.fecFactura = (Nullable<DateTime>)null;
                      //              }

                      //              if (RucEmpresa == "20452630886")//Fundo San Miguel
                      //              {
                      //                  new PedidoCabAD().ActualizarDocumentosPedExp(oPedido);
                      //              }
                      //              else
                      //              {
                      //                  new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                      //              }
                      //          }
                      //      } 

                        	#endregion

                            #region Actualizando el Nro de Factura en el Pedido

		                    if (documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString() && documento.EsGuia == "E")
                            {
                                //if (RucEmpresa == "20452630886")//Fundo San Miguel
                                //{
                                //    oPedido = new PedidoCabAD().ObtenerPedidoCab(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado));
                                //}
                                //else
                                //{
                                //    oPedido = new PedidoCabAD().RecuperarPedidoCabNacional(documento.idEmpresa, documento.idLocal, Convert.ToInt32(documento.nroDocAsociado));
                                //}

                                //if (oPedido != null)
                                //{
                                //    oPedido.fecFactura = documento.fecEmision;
                                //    oPedido.nroFactura = documento.numSerie + '-' + documento.numDocumento;
                                //    oPedido.UsuarioModificacion = documento.UsuarioModificacion;

                                //    if (RucEmpresa == "20452630886")//Fundo San Miguel
                                //    {
                                //        new PedidoCabAD().ActualizarDocumentosPedExp(oPedido);
                                //    }
                                //    else
                                //    {
                                //        new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                                //    }
                                //}
                            }
 
	                        #endregion

                            #region Cierre Total de los Pedidos y OP

		                    //if (documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString() && documento.EsGuia == "E" && indCierreTotal == Variables.SI)
                      //      {
                      //          Int32 idPedido = Variables.Cero;

                      //          if (Ordenes != null && Ordenes.Count > Variables.Cero)
                      //          {
                      //              idPedido = Ordenes[0].idPedido;
                      //          }

                      //          if (idPedido != Variables.Cero)
                      //          {
                      //              //Cerrando el pedido...
                      //              new PedidoCabAD().CerrarPedido(documento.idEmpresa, idPedido, EnumEstadoDocumentos.C.ToString());
                      //              //Cerrando la produccion...
                      //              new OrdenProduccionDetAD().CerrarProduccion(documento.idEmpresa, documento.idLocal, idPedido, EnumEstadoDocumentos.C.ToString());
                      //              //Cerrando las transferencias...
                      //              new TransferenciaPalletAD().CerrarTransferencia(documento.idEmpresa, documento.idLocal, idPedido, EnumEstadoDocumentos.C.ToString()); 
                      //          }
                      //      } 

	                        #endregion

                            #region Reversion cuando es NC

                            //if ((documento.idDocumento == EnumTipoDocumentoVenta.NC.ToString() || documento.idDocumento == EnumTipoDocumentoVenta.NP.ToString()) 
                            //    && documento.idDocumentoRef == EnumTipoDocumentoVenta.FV.ToString())
                            //{
                            //    //Recuperando el documento (Canje de Guias)
                            //    List<CanjeGuiasE> oListaCanjes = new CanjeGuiasAD().ObtenerCanjeGuias(documento.idEmpresa, documento.idLocal, documento.idDocumentoRef, documento.serDocumentoRef, documento.numDocumentoRef);

                            //    if (oListaCanjes.Count > Variables.ValorCero)
                            //    {
                            //        //Recuperando las guias asociadas a la factura de exportación...
                            //        foreach (CanjeGuiasE item in oListaCanjes)
                            //        {
                            //            EmisionDocumentoE oGuiaVenta = new EmisionDocumentoAD().RecuperarEmisionDocumento(documento.idEmpresa, documento.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);
                                        
                            //            if (oGuiaVenta != null)
                            //            {
                            //                if (oGuiaVenta.nroDocAsociado != Variables.ValorCero)
                            //                {
                            //                    //Abrir el pedido...
                            //                    new PedidoCabAD().CerrarPedido(documento.idEmpresa, Convert.ToInt32(oGuiaVenta.nroDocAsociado), EnumEstadoDocumentos.P.ToString());
                            //                    //Abrir la produccion...
                            //                    new OrdenProduccionDetAD().CerrarProduccion(oGuiaVenta.idEmpresa, oGuiaVenta.idLocal, Convert.ToInt32(oGuiaVenta.nroDocAsociado), EnumEstadoDocumentos.F.ToString());
                            //                    //Abrir las transferencias...
                            //                    new TransferenciaPalletAD().CerrarTransferencia(oGuiaVenta.idEmpresa, oGuiaVenta.idLocal, Convert.ToInt32(oGuiaVenta.nroDocAsociado), EnumEstadoDocumentos.P.ToString()); 
                            //                }
                            //            }

                            //            new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.E.ToString());
                            //        }
                            //    }
                            //} 

	                        #endregion

                            #region Generando Voucher Automático

                            if (oParametroVenta != null && oParametroVenta.GeneraAsiento)
                            {
                                new VoucherAD().GeneraAsientoVenta(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, documento.UsuarioRegistro);
                            }

                            #endregion Generando Voucher Automático

                            #region Anticipos

                            //Si se trata de una Factura de Anticipo
                            if (documento.EsAnticipo)
                            {
                                AnticiposE oAnticipo = new AnticiposE()
                                {
                                    idEmpresa = documento.idEmpresa,
                                    idLocal = documento.idLocal,
                                    idDocAnticipo = documento.idDocumento,
                                    numSerieAnticipo = documento.numSerie,
                                    numDocAnticipo = documento.numDocumento,
                                    idPersona = Convert.ToInt32(documento.idPersona),
                                    idMoneda = documento.idMoneda,
                                    idArticulo = documento.ListaItemsDocumento.Count > 0 ? documento.ListaItemsDocumento[0].idArticulo : (Int32?)null,
                                    idDocFactura = String.Empty,
                                    numSerieFactura = String.Empty,
                                    numDocFactura = String.Empty,
                                    SubTotalAnticipo = Convert.ToDecimal(documento.totsubTotal),
                                    IgvAnticipo = Convert.ToDecimal(documento.totIgv),
                                    TotalAnticipo = Convert.ToDecimal(documento.totTotal),
                                    SubTotalSaldo = Convert.ToDecimal(documento.totsubTotal),
                                    IgvSaldo = Convert.ToDecimal(documento.totIgv),
                                    TotalSaldo = documento.totTotal,
                                    Aplicado = false,
                                    Tipo = "C"
                                };

                                new AnticiposAD().InsertarAnticipos(oAnticipo);
                            }

                            //Si se trata de una aplicación de anticipo
                            if (documento.indAnticipo)
                            {
                                if (documento.ListaAnticipos != null)
                                {
                                    foreach (AnticiposE item in documento.ListaAnticipos)
                                    {
                                        item.Tipo = "D";
                                        new AnticiposAD().InsertarAnticipos(item);
                                    }
                                }
                            }

                            #endregion

                            #region Distribución Centro Costos

                            if (documento.idDocumento == EnumTipoDocumentoVenta.FE.ToString() || documento.idDocumento == EnumTipoDocumentoVenta.FS.ToString() ||
                                documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString())// || documento.idDocumento == "BV")
                            {
                                if (documento.ListaEmisionDocumentoCCostos != null)
                                {
                                    foreach (EmisionDocumentoCCostosE item in documento.ListaEmisionDocumentoCCostos)
                                    {
                                        item.idEmpresa = documento.idEmpresa;
                                        item.idLocal = documento.idLocal;
                                        item.idDocumento = documento.idDocumento;
                                        item.numSerie = documento.numSerie;
                                        item.numDocumento = documento.numDocumento;

                                        new EmisionDocumentoCCostosAD().InsertarEmisionDocumentoCCostos(item);
                                    }
                                }
                            } 
                            
                            #endregion

                            #region Cancelacion - Planilla de Cobranzas

                            if (documento.indCancelacion)
                            {
                                if (documento.ListaCancelaciones != null)
                                {
                                    Int32 numItem = 1;

                                    foreach (EmisionDocumentoCancelacionE item in documento.ListaCancelaciones)
                                    {
                                        item.Item = numItem;
                                        new EmisionDocumentoCancelacionAD().InsertarEmisionDocumentoCancelacion(item);
                                        numItem++;
                                    }
                                }
                            } 
                            
                            #endregion

                            #endregion Insertar

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            #region Actualizar

                            Int32 resp = Variables.Cero;
                            EmisionDocumentoE docTemp = new EmisionDocumentoAD().ObtenerEmisionDocumento(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                            //Actualizar la Cabecera...
                            documento = new EmisionDocumentoAD().ActualizarEmisionDocumento(documento);

                            #region Actualizando el detalle

                            if (documento.ListaItemsDocumento != null)
                            {
                                resp = new EmisionDocumentoDetAD().EliminarEmisionDocumentoDet(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                                foreach (EmisionDocumentoDetE item in documento.ListaItemsDocumento)
                                {
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumento = documento.idDocumento;
                                    item.numSerie = documento.numSerie;
                                    item.numDocumento = documento.numDocumento;
                                    
                                    //Insertar
                                    new EmisionDocumentoDetAD().InsertarEmisionDocumentoDet(item);
                                }
                            }
	                        
                            #endregion

                            #region Actualizando el Nro de Guia en el pedido

                            //if (documento.idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                            //{
                            //    if (RucEmpresa == "20452630886")//Fundo San Miguel
                            //    {
                            //        oPedido = new PedidoCabAD().ObtenerPedidoCab(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado));
                            //    }
                            //    else
                            //    {
                            //        oPedido = new PedidoCabAD().RecuperarPedidoCabNacional(documento.idEmpresa, documento.idLocal, Convert.ToInt32(documento.nroDocAsociado));
                            //    }

                            //    if (oPedido != null)
                            //    {
                            //        oPedido.NroGuia = documento.numSerie + '-' + documento.numDocumento;
                            //        oPedido.UsuarioModificacion = documento.UsuarioModificacion;

                            //        if (String.IsNullOrEmpty(oPedido.nroFactura))
                            //        {
                            //            oPedido.nroFactura = String.Empty;
                            //        }

                            //        if (String.IsNullOrEmpty(oPedido.nroBl))
                            //        {
                            //            oPedido.nroBl = String.Empty;
                            //        }

                            //        if (String.IsNullOrEmpty(oPedido.nroDam))
                            //        {
                            //            oPedido.nroDam = String.Empty;
                            //        }

                            //        if (oPedido.fecFactura == null)
                            //        {
                            //            oPedido.fecFactura = (Nullable<DateTime>)null;
                            //        }

                            //        if (RucEmpresa == "20452630886")//Fundo San Miguel
                            //        {
                            //            new PedidoCabAD().ActualizarDocumentosPedExp(oPedido);
                            //        }
                            //        else
                            //        {
                            //            new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                            //        }
                            //    }
                            //} 

	                        #endregion

                            if (documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString() && documento.EsGuia == "E")
                            {
                                #region Recuperando documento antes de actualizar para soltar los documentos amarrados a el...

                                //if (docTemp != null)
                                //{
                                //    //Abrir el pedido...
                                //    new PedidoCabAD().CerrarPedido(docTemp.idEmpresa, Convert.ToInt32(docTemp.nroDocAsociado), EnumEstadoDocumentos.P.ToString());
                                //    //Abrir la produccion...
                                //    new OrdenProduccionDetAD().CerrarProduccion(docTemp.idEmpresa, docTemp.idLocal, Convert.ToInt32(docTemp.nroDocAsociado), EnumEstadoDocumentos.F.ToString());
                                //    //Abrir las transferencias...
                                //    new TransferenciaPalletAD().CerrarTransferencia(docTemp.idEmpresa, docTemp.idLocal, Convert.ToInt32(docTemp.nroDocAsociado), EnumEstadoDocumentos.P.ToString());     
                                //}

                                //Canje de Guias
                                List<CanjeGuiasE> ListaGuias = new CanjeGuiasAD().ObtenerCanjeGuias(docTemp.idEmpresa, docTemp.idLocal, docTemp.idDocumento, docTemp.numSerie, docTemp.numDocumento);

                                if (ListaGuias.Count > Variables.Cero)
                                {
                                    foreach (CanjeGuiasE item in ListaGuias)
                                    {
                                        new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.E.ToString());   
                                    }
                                }

                                #endregion

                                #region Actualizando el Nro y la fecha de la Factura en el Pedido

                                //if (RucEmpresa == "20452630886")//Fundo San Miguel
                                //{
                                //    oPedido = new PedidoCabAD().ObtenerPedidoCab(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado));
                                //}
                                //else
                                //{
                                //    oPedido = new PedidoCabAD().RecuperarPedidoCabNacional(documento.idEmpresa, documento.idLocal, Convert.ToInt32(documento.nroDocAsociado));
                                //} 

                                //if (oPedido != null)
                                //{
                                //    oPedido.fecFactura = documento.fecEmision;
                                //    oPedido.nroFactura = documento.numSerie + '-' + documento.numDocumento;
                                //    oPedido.UsuarioModificacion = documento.UsuarioModificacion;

                                //    if (RucEmpresa == "20452630886")//Fundo San Miguel
                                //    {
                                //        new PedidoCabAD().ActualizarDocumentosPedExp(oPedido);
                                //    }
                                //    else
                                //    {
                                //        new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                                //    }
                                //}  

                                #endregion

                                #region Actualizando Listado de guias asociadas a una factura de exportacion...

                                if (documento.ListaCanjeGuias != null && documento.ListaCanjeGuias.Count > 0)
                                {
                                    resp = new CanjeGuiasAD().EliminarCanjeGuiasPorFactura(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                                    foreach (CanjeGuiasE item in documento.ListaCanjeGuias)
                                    {
                                        item.idEmpresa = documento.idEmpresa;
                                        item.idLocal = documento.idLocal;
                                        item.idDocumentoFact = documento.idDocumento;
                                        item.numSerieFact = documento.numSerie;
                                        item.numDocumentoFact = documento.numDocumento;

                                        new CanjeGuiasAD().InsertarCanjeGuias(item);

                                        if (RucEmpresa == "20452630886")//Fundo San Miguel
                                        {
                                            //Actualizando el estado de las guias a Facturadas
                                            new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString()); 
                                        }
                                    }
                                } 

                                #endregion

                                #region Cierre Total de los Pedidos y OP

                                if (documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString() && documento.EsGuia == "E" && indCierreTotal == Variables.SI)
                                {
                                    //if (documento.nroDocAsociado != Variables.Cero)
                                    //{
                                    //    //Cerrando el pedido...
                                    //    new PedidoCabAD().CerrarPedido(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado), EnumEstadoDocumentos.C.ToString());
                                    //    //Cerrando la produccion...
                                    //    new OrdenProduccionDetAD().CerrarProduccion(documento.idEmpresa, documento.idLocal, Convert.ToInt32(documento.nroDocAsociado), EnumEstadoDocumentos.C.ToString());
                                    //    //Cerrando las transferencias...
                                    //    new TransferenciaPalletAD().CerrarTransferencia(documento.idEmpresa, documento.idLocal, Convert.ToInt32(documento.nroDocAsociado), EnumEstadoDocumentos.C.ToString());
                                    //}
                                }

                                #endregion
                            }

                            if (documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString() && documento.EsGuia == "F")
                            {
                                #region Actualizando Listado de guias asociadas a una factura de Naciona...

                                if (documento.ListaCanjeGuias != null && documento.ListaCanjeGuias.Count > 0)
                                {
                                    resp = new CanjeGuiasAD().EliminarCanjeGuiasPorFactura(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                                    foreach (CanjeGuiasE item in documento.ListaCanjeGuias)
                                    {
                                        item.idEmpresa = documento.idEmpresa;
                                        item.idLocal = documento.idLocal;
                                        item.idDocumentoFact = documento.idDocumento;
                                        item.numSerieFact = documento.numSerie;
                                        item.numDocumentoFact = documento.numDocumento;

                                        new CanjeGuiasAD().InsertarCanjeGuias(item);

                                        if (RucEmpresa == "20452630886")//Fundo San Miguel
                                        {
                                            //Actualizando el estado de las guias a Facturadas
                                            new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString());
                                        }
                                    }
                                }

                                #endregion
                            }

                            #region Generando Voucher Automático

                            //if (documento.indVoucher)
                            //{
                            //    if (oParametroVenta != null && oParametroVenta.GeneraAsiento)
                            //    {

                            //        new VoucherAD().GeneraAsientoVenta(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, documento.UsuarioRegistro);
                            //    }    
                            //}

                            #endregion Generando Voucher Automático

                            #region Anticipos

                            //Si se trata de una Factura de Anticipo
                            if (documento.EsAnticipo)
                            {
                                new AnticiposAD().EliminarAnticipos(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, Convert.ToInt32(documento.idPersona));

                                AnticiposE oAnticipo = new AnticiposE()
                                {
                                    idEmpresa = documento.idEmpresa,
                                    idLocal = documento.idLocal,
                                    idDocAnticipo = documento.idDocumento,
                                    numSerieAnticipo = documento.numSerie,
                                    numDocAnticipo = documento.numDocumento,
                                    idPersona = Convert.ToInt32(documento.idPersona),
                                    idMoneda = documento.idMoneda,
                                    idArticulo = documento.ListaItemsDocumento.Count > 0 ? documento.ListaItemsDocumento[0].idArticulo : (Int32?)null,
                                    idDocFactura = String.Empty,
                                    numSerieFactura = String.Empty,
                                    numDocFactura = String.Empty,
                                    SubTotalAnticipo = Convert.ToDecimal(documento.totsubTotal),
                                    IgvAnticipo = Convert.ToDecimal(documento.totIgv),
                                    TotalAnticipo = Convert.ToDecimal(documento.totTotal),
                                    SubTotalSaldo = Convert.ToDecimal(documento.totsubTotal),
                                    IgvSaldo = Convert.ToDecimal(documento.totIgv),
                                    TotalSaldo = documento.totTotal,
                                    Aplicado = false,
                                    Tipo = "C"
                                };

                                new AnticiposAD().InsertarAnticipos(oAnticipo);
                            }
                            else
                            {
                                if (documento.EsAnticipo != documento.EsAnticipoTmp)
                                {
                                    new AnticiposAD().EliminarAnticipos(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, Convert.ToInt32(documento.idPersona));
                                }
                            }

                            //Si se trata de una aplicación de anticipo
                            //Eliminando los anticipos en la Lista de Anticipos Eliminados...
                            if (documento.AnticiposEliminados != null)
                            {
                                foreach (AnticiposE item in documento.AnticiposEliminados)
                                {
                                    new AnticiposAD().EliminarAnticiposDet(item.idEmpresa, item.idLocal, item.idDocAnticipo, item.numSerieAnticipo, item.numDocAnticipo, item.idPersona, item.idDocFactura, item.numSerieFactura, item.numDocFactura);
                                }
                            }

                            if (documento.indAnticipo)
                            {
                                if (documento.ListaAnticipos != null)
                                {
                                    foreach (AnticiposE item in documento.ListaAnticipos)
                                    {
                                        item.Tipo = "D";

                                        if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                        {
                                            new AnticiposAD().InsertarAnticipos(item);
                                        }
                                        else
                                        {
                                            new AnticiposAD().ActualizarAnticipos(item);
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region Distribución Centro Costos

                            if (documento.idDocumento == EnumTipoDocumentoVenta.FE.ToString() || documento.idDocumento == EnumTipoDocumentoVenta.FS.ToString() ||
                                documento.idDocumento == EnumTipoDocumentoVenta.FV.ToString())// || documento.idDocumento == "BV")
                            {
                                if (documento.ListaEmisionDocumentoCCostos != null)
                                {
                                    new EmisionDocumentoCCostosAD().EliminarEmisionDocumentoCCostos(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                                    foreach (EmisionDocumentoCCostosE item in documento.ListaEmisionDocumentoCCostos)
                                    {
                                        if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                        {
                                            item.idEmpresa = documento.idEmpresa;
                                            item.idLocal = documento.idLocal;
                                            item.idDocumento = documento.idDocumento;
                                            item.numSerie = documento.numSerie;
                                            item.numDocumento = documento.numDocumento;

                                            new EmisionDocumentoCCostosAD().InsertarEmisionDocumentoCCostos(item);
                                        }

                                        if (item.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                                        {
                                            new EmisionDocumentoCCostosAD().ActualizarEmisionDocumentoCCostos(item);
                                        }
                                    }
                                } 
                            }

                            #endregion

                            #region Cancelacion - Planilla de Cobranzas

                            new EmisionDocumentoCancelacionAD().EliminarEmisionDocumentoCancelacion(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                            if (documento.indCancelacion)
                            {
                                if (documento.ListaCancelaciones != null)
                                {
                                    Int32 numItem = 1;

                                    foreach (EmisionDocumentoCancelacionE item in documento.ListaCancelaciones)
                                    {
                                        item.Item = numItem;
                                        new EmisionDocumentoCancelacionAD().InsertarEmisionDocumentoCancelacion(item);
                                        numItem++;
                                    }
                                }
                            }

                            #endregion

                            #endregion

                            break;
                        default:
                            break;
                    }

                    oTran.Complete();
                }

                return documento;
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

        public EmisionDocumentoE RecuperarDocumentoCompleto(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                //Cabecera
                EmisionDocumentoE Documento = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                if (Documento == null)
                {
                    throw new Exception(String.Format("El documento {0} ingresado no existe.", idDocumento + " " + numSerie + "-" + numDocumento));
                }
               
                    //Detalle
                    Documento.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
            

                if (idDocumento == EnumTipoDocumentoVenta.FE.ToString() || idDocumento == EnumTipoDocumentoVenta.FS.ToString() || idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString())
                {
                    //Canje de Guias
                    Documento.ListaCanjeGuias = new CanjeGuiasAD().ObtenerCanjeGuias(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                    //Gastos de exportación
                    if (Documento.EsGuia == EnumEsGuia.E.ToString())
                    {
                        Documento.ListaGastosExportacion = new EmisionDocumentoExportaAD().ObtenerEmisionDocumentoExporta(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                    }

                    if (Documento.indAnticipo)
                    {
                        Documento.ListaAnticipos = new AnticiposAD().AnticiposPorFactura(idEmpresa, idLocal, Documento.idPersona.Value, idDocumento, numSerie, numDocumento);
                    }

                    Documento.ListaEmisionDocumentoCCostos = new EmisionDocumentoCCostosAD().ListarEmisionDocumentoCCostos(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                    if (Documento.indCancelacion)
                    {
                        Documento.ListaCancelaciones = new EmisionDocumentoCancelacionAD().ObtenerEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                    }
                }

                if (idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                {
                    Documento.ListaCanjeGuias = new CanjeGuiasAD().ObtenerCanjeGuiasPorGuia(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                }

                return Documento;
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

        public List<EmisionDocumentoE> RecuperarEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String FecIni, String FecFin, String RazonSocial)
        {
            try
            {
                return new EmisionDocumentoAD().RecuperarEmisionDocumento(idEmpresa, idLocal, FecIni, FecFin, RazonSocial);
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

        public EmisionDocumentoE ActualizarEmisionDocumentoVendedor(EmisionDocumentoE emisiondocumento)
        {
            try
            {
                return new EmisionDocumentoAD().ActualizarEmisionDocumentoVendedor(emisiondocumento);
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

        public EmisionDocumentoE ObtenerEmisionDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public List<EmisionDocumentoE> ListarDocumentosVentas(Int32 idEmpresa, Int32 idLocal, String idDocumento, Int32 idPersona, String Serie, string fecIni, string fecFin)
        {
            try
            {
                return new EmisionDocumentoAD().ListarDocumentosVentas(idEmpresa, idLocal, idDocumento, idPersona, Serie, fecIni, fecFin);
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

        public List<EmisionDocumentoE> ListarDocumentosEmitidos(Int32 idEmpresa, Int32 idLocal, String idDocumento)
        {
            try
            {
                List< EmisionDocumentoE> oListaDocumentos = new EmisionDocumentoAD().ListarDocumentosEmitidos(idEmpresa, idLocal, idDocumento);

                if (idDocumento == "GV")
                {
                    oListaDocumentos = (from x in oListaDocumentos where x.TrasladoAlmacen == false select x).ToList();
                }

                return oListaDocumentos;
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

        public List<EmisionDocumentoE> ListarDocumentosEmitidosFecha(Int32 idEmpresa, Int32 idLocal, String idDocumento, String fecha)
        {
            try
            {
                return new EmisionDocumentoAD().ListarDocumentosEmitidosFecha(idEmpresa, idLocal, idDocumento, fecha);
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

        public List<EmisionDocumentoE> ListarDocEmitidosFechaPorSerie(Int32 idEmpresa, Int32 idLocal, String idDocumento, String fecha, String Serie)
        {
            try
            {
                return new EmisionDocumentoAD().ListarDocEmitidosFechaPorSerie(idEmpresa, idLocal, idDocumento, fecha, Serie);
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

        public void CambiarEstadoDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String indEstado, String Usuario, String ConCtaCte = "S", String conCobranza = "S")
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Empresa oEmpresa = new EmpresaAD().RecuperarEmpresaPorID(idEmpresa);

                    EmisionDocumentoE DocumentoTmp = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                    Int32 idCtaCteVentas = 0;

                    if (DocumentoTmp != null)
                    {
                        if (DocumentoTmp.indEstado == EnumEstadoDocumentos.C.ToString())
                        {
                            #region Exportación

                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() && DocumentoTmp.EsGuia == EnumEsGuia.E.ToString() && DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                            {
                                ////Abrir el pedido...
                                //new PedidoCabAD().CerrarPedido(DocumentoTmp.idEmpresa, Convert.ToInt32(DocumentoTmp.nroDocAsociado), EnumEstadoDocumentos.P.ToString());
                                ////Abrir la produccion...
                                //new OrdenProduccionDetAD().CerrarProduccion(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, Convert.ToInt32(DocumentoTmp.nroDocAsociado), EnumEstadoDocumentos.F.ToString());
                                ////Abrir las transferencias...
                                //new TransferenciaPalletAD().CerrarTransferencia(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, Convert.ToInt32(DocumentoTmp.nroDocAsociado), EnumEstadoDocumentos.P.ToString());

                                DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                //Canje de Guias

                                List<CanjeGuiasE> ListaGuias = new CanjeGuiasAD().ObtenerCanjeGuias(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                                if (ListaGuias != null && ListaGuias.Count > Variables.Cero)
                                {
                                    foreach (CanjeGuiasE item in ListaGuias)
                                    {
                                        new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString());
                                    }
                                }
                            }

                            #endregion
                        }

                        #region Si en caso el documento sea anulado...

                        if (indEstado == EnumEstadoDocumentos.B.ToString())
                        {
                            DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                            #region Facturas y Boletas

                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString())
                            {
                                //Canje de Guias por Nro de Factura
                                List<CanjeGuiasE> ListaGuias = new CanjeGuiasAD().ObtenerCanjeGuias(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                                if (ListaGuias != null && ListaGuias.Count > Variables.Cero)
                                {
                                    //Volviendo las guias a su estado de Emitido
                                    foreach (CanjeGuiasE item in ListaGuias)
                                    {
                                        new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.E.ToString());
                                        new CanjeGuiasAD().EliminarCanjeGuiasPorFactura(item.idEmpresa, item.idLocal, item.idDocumentoFact, item.numSerieFact, item.numDocumentoFact);
                                    }
                                }

                                #region Anticipos

                                if (DocumentoTmp.indAnticipo)
                                {
                                    DocumentoTmp.ListaAnticipos = new AnticiposAD().AnticiposPorFactura(idEmpresa, idLocal, DocumentoTmp.idPersona.Value, idDocumento, numSerie, numDocumento);

                                    //Eliminando los anticipos si hubiese...
                                    if (DocumentoTmp.ListaAnticipos != null)
                                    {
                                        foreach (AnticiposE item in DocumentoTmp.ListaAnticipos)
                                        {
                                            new AnticiposAD().EliminarAnticiposDet(item.idEmpresa, item.idLocal, item.idDocAnticipo, item.numSerieAnticipo, item.numDocAnticipo, item.idPersona, item.idDocFactura, item.numSerieFactura, item.numDocFactura);
                                        }
                                    }
                                }

                                if (DocumentoTmp.EsAnticipo)
                                {
                                    DocumentoTmp.ListaAnticipos = new AnticiposAD().AnticiposPorDocAnticipo(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                    //Eliminando los anticipos si hubiese...
                                    if (DocumentoTmp.ListaAnticipos != null)
                                    {
                                        if (DocumentoTmp.ListaAnticipos.Count > 1)
                                        {
                                            throw new Exception("No se puede anular el Anticipo porque ya tiene aplicaciones. Anule primero las aplicaciones y luego el Anticipo.");
                                        }

                                        new AnticiposAD().EliminarAnticipos(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, DocumentoTmp.idPersona.Value);
                                    }
                                }

                                #endregion

                                //Eliminando las cancelaciones
                                #region Cancelaciones - Cobranzas

                                if (DocumentoTmp.indCancelacion)
                                {
                                    #region Cobranzas

                                    //Listando las cancelaciones por el número del documento
                                    DocumentoTmp.ListaCancelaciones = new EmisionDocumentoCancelacionAD().ObtenerEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                    if (DocumentoTmp.ListaCancelaciones.Count > 0)
                                    {
                                        CobranzasE oCobranza = null;
                                        List<CobranzasItemDetE> ListaDetalle = null;
                                        String Mensaje = String.Empty;

                                        foreach (EmisionDocumentoCancelacionE item in DocumentoTmp.ListaCancelaciones)
                                        {
                                            //Si no tiene idPlanilla lo busca por documento
                                            if (item.idPlanilla == null || item.idPlanilla == 0)
                                            {
                                                CobranzasItemDetE ItemDetCobranza = new CobranzasItemDetAD().CobranzasItemDetPorDocumento(idEmpresa, idDocumento, numSerie, numDocumento);

                                                if (ItemDetCobranza != null)
                                                {
                                                    oCobranza = new CobranzasAD().ObtenerCobranzas(ItemDetCobranza.idPlanilla);
                                                    Mensaje = String.Format("La planilla de cobranza {0} con este documento {1} {2}-{3}, se encuentra Cerrada, tiena que volver Abrir la planilla antes de anular el documento.", oCobranza.codPlanilla, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                                                    if (oCobranza.EstadoDoc)
                                                    {
                                                        throw new Exception(Mensaje);
                                                    }
                                                    else
                                                    {
                                                        ListaDetalle = (item.VariosCobros == true ? new CobranzasItemDetAD().CobranzasItemDetPorPlanillaDifDoc(ItemDetCobranza.idPlanilla, idDocumento, numSerie, numDocumento) : new List<CobranzasItemDetE>());

                                                        if (ListaDetalle.Count == 0)
                                                        {
                                                            new CobranzasAD().EliminarCobranzas(ItemDetCobranza.idPlanilla);
                                                        }
                                                        else
                                                        {
                                                            StringBuilder Cad = new StringBuilder();

                                                            foreach (CobranzasItemDetE Fila in ListaDetalle)
                                                            {
                                                                Cad.Append(Fila.idDocumento).Append(" ").Append(Fila.numSerie).Append(Fila.numDocumento).Append("\n\r");
                                                            }

                                                            throw new Exception(String.Format("La planilla de cobranza {0} tiene otros documentos asociados {1}. Revise", oCobranza.codPlanilla, Cad.ToString()));
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                oCobranza = new CobranzasAD().ObtenerCobranzas(item.idPlanilla.Value);

                                                if (oCobranza != null)
                                                {
                                                    Mensaje = String.Format("La planilla de cobranza {0} con este documento {1} {2}-{3}, se encuentra Cerrada, tiena que volver Abrir la planilla antes de anular el documento.", oCobranza.codPlanilla, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                                                    if (oCobranza.EstadoDoc)
                                                    {
                                                        throw new Exception(Mensaje);
                                                    }
                                                    else
                                                    {
                                                        ListaDetalle = (item.VariosCobros == true ? new CobranzasItemDetAD().CobranzasItemDetPorPlanillaDifDoc(oCobranza.idPlanilla, idDocumento, numSerie, numDocumento) : new List<CobranzasItemDetE>());

                                                        if (ListaDetalle.Count == 0)
                                                        {
                                                            new CobranzasAD().EliminarCobranzas(oCobranza.idPlanilla);
                                                        }
                                                        else
                                                        {
                                                            StringBuilder Cad = new StringBuilder();

                                                            foreach (CobranzasItemDetE Fila in ListaDetalle)
                                                            {
                                                                Cad.Append(Fila.idDocumento).Append(" ").Append(Fila.numSerie).Append(Fila.numDocumento).Append("\n\r");
                                                            }

                                                            throw new Exception(String.Format("La planilla de cobranza {0} tiene otros documentos asociados {1}. Revise", oCobranza.codPlanilla, Cad.ToString()));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    #endregion

                                    //Eliminando la Cancelación
                                    new EmisionDocumentoCancelacionAD().EliminarEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                                }

                                #endregion

                                #region CtaCte

                                if ((DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() ||
                                    DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.ND.ToString()))
                                {
                                    //Verificando si existen abonos en la ctacte
                                    List<CtaCte_DetE> oListaAbonos = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(DocumentoTmp.idEmpresa, DocumentoTmp.idCtaCte.Value);

                                    if (oListaAbonos.Count > 0)
                                    {
                                        throw new Exception("El documento no puede ser anulado porque ya se encuentra Cancelado(Cta.Cte.). Tiene que eliminar el Abono, luego Anular el documento.");
                                    }

                                    //Eliminando la cta.cte
                                    new CtaCteAD().EliminarMaeCtaCteConDetalle(DocumentoTmp.idCtaCte.Value);
                                    //// Eliminando el detalle - Cargo
                                    //new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(DocumentoTmp.idCtaCteItem);
                                    //// Eliminando la cabecera
                                    //new CtaCteAD().EliminarMaeCtaCte(DocumentoTmp.idEmpresa, DocumentoTmp.idCtaCte);

                                    //Actualizando los campos de CtaCte en la tabla
                                    DocumentoTmp.idCtaCte = null;
                                    DocumentoTmp.idCtaCteItem = null;

                                    new EmisionDocumentoAD().ActualizarEmisDocuCtaCte(DocumentoTmp);
                                }

                                #endregion
                            }

                            #endregion

                            #region Guias... Factura Guia... Boleta Guia

                            if ((DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.GV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() ||
                                 DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() || DocumentoTmp.idDocumento == "ST") && DocumentoTmp.EsGuia == EnumEsGuia.G.ToString() || DocumentoTmp.idDocumento ==EnumTipoDocumentoVenta.NC.ToString())
                            {
                                //Canje de Guias por Nro de Guia
                                List<CanjeGuiasE> ListaFacturasGuias = new CanjeGuiasAD().ObtenerCanjeGuiasPorGuia(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                                if (ListaFacturasGuias != null && ListaFacturasGuias.Count > Variables.Cero)
                                {
                                    foreach (CanjeGuiasE item in ListaFacturasGuias)
                                    {
                                        EmisionDocumentoE oDocumento = new EmisionDocumentoAD().ObtenerEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumentoFact, item.numSerieFact, item.numDocumentoFact);

                                        //Preguntando si la factura esta anulada primero antes de soltar el pedido
                                        if (oDocumento.indEstado != EnumEstadoDocumentos.B.ToString())
                                        {
                                            throw new Exception(String.Format("La factura {0}-{1} debe ser anulada antes de anular la guia correspondiente.", item.numSerieFact, item.numDocumentoFact));
                                        }
                                    }
                                }

                                //Liberando las OT
                                if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.GV.ToString() || DocumentoTmp.idDocumento == "ST")
                                {
                                    foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                                    {
                                        if (Convert.ToInt32(item.nroOt) > 0 && Convert.ToInt32(item.nroOtItem) > 0)
                                        {
                                            new OrdenTrabajoServicioItemAD().CambiarEstadoDocumentoOT(idEmpresa, idLocal, Convert.ToInt32(item.nroOt), Convert.ToInt32(item.nroOtItem), EnumEstadoDocumentos.P.ToString());
                                        }
                                    }
                                }

                                //Anulando el movimiento en Almacen...
                                Int32 idMovimiento = Variables.Cero;
                                ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("EGR");

                                foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                                {
                                    if (item.DocumentoAlmacen > 0)
                                    {
                                        if (oTipoMovimiento != null)
                                        {
                                            idMovimiento = oTipoMovimiento.IdParTabla;
                                        }
                                        else
                                        {
                                            throw new Exception("No existe Tipos de Movimientos para los Egresos.");
                                        }

                                        new MovimientoAlmacenAD().AnularMovimientoAlmacen(idEmpresa, idMovimiento, Convert.ToInt32(item.DocumentoAlmacen), Usuario);
                                    }
                                }
                            }
                            else if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                            {


                                /////DEVOLUCION

                                if (DocumentoTmp.desCondicion.ToUpper().Contains("DEVOLUCIÓN") || DocumentoTmp.desCondicion.ToUpper().Contains("DEVOLUCION") || DocumentoTmp.desCondicion.ToUpper().Contains("Anulación de la operación"))
                                {
                                    //Anulando el movimiento en ingreso al Almacen...
                                    Int32 idMovimiento = Variables.Cero;
                                    ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("ING");

                                    foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                                    {
                                        if (item.DocumentoAlmacen > 0)
                                        {
                                            if (oTipoMovimiento != null)
                                            {
                                                idMovimiento = oTipoMovimiento.IdParTabla;
                                            }
                                            else
                                            {
                                                throw new Exception("No existe Tipos de Movimientos para los Egresos.");
                                            }

                                            new MovimientoAlmacenAD().AnularMovimientoAlmacen(idEmpresa, idMovimiento, Convert.ToInt32(item.DocumentoAlmacen), Usuario);
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region Pedido

                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.GV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() ||
                                 DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() || DocumentoTmp.idDocumento == "ST")
                            {
                                //Soltando el pedido
                                if (DocumentoTmp.nroDocAsociado != null && DocumentoTmp.nroDocAsociado > 0 && !DocumentoTmp.EsAnticipo)
                                {
                                    PedidoCabE pedido = new PedidoCabAD().RecuperarPedidoCabNacional(idEmpresa, idLocal, Convert.ToInt32(DocumentoTmp.nroDocAsociado));

                                    if (pedido != null)
                                    {
                                        PedidoCabE oPedido = null;
                                        String Factura = pedido.nroFactura.Trim();
                                        String Guia = pedido.NroGuia.Trim();

                                        if (!String.IsNullOrWhiteSpace(Factura))
                                        {
                                            oPedido = new PedidoCabE()
                                            {
                                                idEmpresa = DocumentoTmp.idEmpresa,
                                                idLocal = DocumentoTmp.idLocal,
                                                idPedido = pedido.idPedido,
                                                NroGuia = pedido.NroGuia,
                                                nroFactura = String.Empty,
                                                FecFactura = null,
                                                UsuarioModificacion = Usuario
                                            };

                                            new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                                            Factura = String.Empty;
                                        }

                                        if (!String.IsNullOrWhiteSpace(Guia))
                                        {
                                            oPedido = new PedidoCabE()
                                            {
                                                idEmpresa = DocumentoTmp.idEmpresa,
                                                idLocal = DocumentoTmp.idLocal,
                                                idPedido = pedido.idPedido,
                                                NroGuia = String.Empty,
                                                nroFactura = pedido.nroFactura,
                                                FecFactura = pedido.FecFactura,
                                                UsuarioModificacion = Usuario,

                                            };

                                            new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                                            Guia = String.Empty;
                                        }

                                        if (String.IsNullOrWhiteSpace(Factura) && String.IsNullOrWhiteSpace(Guia))
                                        {
                                            new PedidoCabAD().CerrarPedido(DocumentoTmp.idEmpresa, Convert.ToInt32(DocumentoTmp.nroDocAsociado), EnumEstadoDocumentos.P.ToString());
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region Eliminando el movimiento en laCtaCte

                            if ((DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() ||
                                DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() ||
                                DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString() ||
                                DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.ND.ToString()) && indEstado == EnumEstadoDocumentos.B.ToString())
                            {
                                CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCte(DocumentoTmp.idEmpresa, Convert.ToInt32(DocumentoTmp.idPersona), DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento, false);

                                if (oCtaCte != null)
                                {
                                    List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                                    if (oListaCtaCte.Count > 0)
                                    {
                                        throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene movimientos, elimine los movimientos antes de anular la factura.", DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento));
                                    }
                                    else
                                    {
                                        //Eliminando la cta.cte
                                        new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCte.idCtaCte);
                                        //// Eliminando el detalle
                                        //new CtaCte_DetAD().EliminarMaeCtaCteDetalle(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                                        //// Eliminando la cabecera
                                        //new CtaCteAD().EliminarMaeCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                                    }
                                }
                            }

                            #endregion Eliminando el movimiento en laCtaCte

                        
                        }

                        #endregion

                        #region Si en caso el documento sea emitido

                        if (indEstado == EnumEstadoDocumentos.E.ToString())
                        {
                            #region Cambiando el estado de las guias a facturado...

                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString())
                            {
                                //Canje de Guias por Nro de Factura - Obteniendo todas las guias
                                List<CanjeGuiasE> ListaCanjeGuias = new CanjeGuiasAD().ObtenerCanjeGuias(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);
                                DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                if (ListaCanjeGuias != null && ListaCanjeGuias.Count > Variables.Cero)
                                {
                                    //Listando el detalle de la factura
                                    DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                                    Boolean Emitir = false;

                                    //Recorriendo el listado del canje de guias
                                    foreach (CanjeGuiasE item in ListaCanjeGuias)
                                    {
                                        //Listando la guia
                                        EmisionDocumentoE oDocumentoGuias = new EmisionDocumentoAD().ObtenerEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);
                                        oDocumentoGuias.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);

                                        if (oDocumentoGuias.indEstado == EnumEstadoDocumentos.E.ToString())
                                        {
                                            if (oDocumentoGuias.ListaItemsDocumento.Count > 0)
                                            {
                                                //Recorriendo los items de la guia para comparar cantidades
                                                foreach (EmisionDocumentoDetE itemGuia in oDocumentoGuias.ListaItemsDocumento)
                                                {
                                                    EmisionDocumentoDetE DocFacBol = DocumentoTmp.ListaItemsDocumento.Find
                                                    (
                                                        delegate (EmisionDocumentoDetE ed)
                                                        {
                                                            return ed.idDocumentoRef == itemGuia.idDocumento
                                                               && ed.serDocumentoRef == itemGuia.numSerie
                                                               && ed.numDocumentoRef == itemGuia.numDocumento
                                                               && ed.idArticulo == itemGuia.idArticulo
                                                               && ed.Lote == itemGuia.Lote;
                                                        }
                                                    );

                                                    if (DocFacBol != null)
                                                    {
                                                        if (DocFacBol.Cantidad == itemGuia.Cantidad)
                                                        {
                                                            Emitir = true;
                                                        }
                                                        else
                                                        {
                                                            Emitir = false;
                                                        }
                                                    }
                                                }

                                                if (Emitir)
                                                {
                                                    new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString());
                                                }
                                            }
                                        }
                                        //else if (oDocumentoGuias.indEstado == EnumEstadoDocumentos.F.ToString())
                                        //{

                                        //}
                                        //else
                                        //{
                                        //    throw new Exception(String.Format("La Guia {0}-{1} debe estar emitida antes de emitir la Factura.", item.numSerieGuia, item.numDocumentoGuia));
                                        //}
                                    }

                                    //foreach (CanjeGuiasE item in ListaFacturas)
                                    //{
                                    //    CantidadItemsFact += new EmisionDocumentoDetAD().ObtenerCantidadDetalle(item.idEmpresa, item.idLocal, item.idDocumentoFact, item.numSerieFact, item.numDocumentoFact);

                                    //    if (CantidadItemsGuia == 0)
                                    //    {
                                    //        CantidadItemsGuia += new EmisionDocumentoDetAD().ObtenerCantidadDetalle(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);
                                    //    }
                                    //}

                                    //Cambiando el estado de las Guias de emitido a Facturado.
                                    //foreach (CanjeGuiasE item in ListaGuias)
                                    //{
                                    //    EmisionDocumentoE oDocumentoGuias = new EmisionDocumentoAD().ObtenerEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);

                                    //    //La guia tiene que estar emitida antes de pasar a Facturado.
                                    //    if (oDocumentoGuias.indEstado == EnumEstadoDocumentos.E.ToString())
                                    //    {
                                    //        if (CantidadItemsFact == CantidadItemsGuia)
                                    //        {
                                    //             new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString());
                                    //        }
                                    //    }
                                    //    else if (oDocumentoGuias.indEstado == EnumEstadoDocumentos.F.ToString())
                                    //    {

                                    //    }
                                    //    else
                                    //    {
                                    //        throw new Exception(String.Format("La Guia {0}-{1} debe estar emitida antes de emitir la Factura.", item.numSerieGuia, item.numDocumentoGuia));
                                    //    }
                                    //}
                                }
                            }

                            #endregion

                            if (oEmpresa.RUC != "20452630886") // Fundo San Miguel
                            {
                                #region Cerrando el Pedido
                               


                                if (DocumentoTmp.nroDocAsociado != null && DocumentoTmp.nroDocAsociado > 0 && !DocumentoTmp.EsAnticipo)
                                {
                                    

                                    DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa,idLocal,idDocumento, numSerie, numDocumento);
                                    if (idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString() || idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                                    {
                                        PedidoCabE pedido = new PedidoCabAD().RecuperarPedidoCabNacional(idEmpresa, idLocal, Convert.ToInt32(DocumentoTmp.nroDocAsociado));

                                        if (pedido != null)
                                        {
                                            PedidoCabE oPedido = null;
                                            String Factura = pedido.nroFactura.Trim();
                                            String Guia = pedido.NroGuia.Trim();

                                            //Factura...
                                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString())
                                            {
                                                if (String.IsNullOrWhiteSpace(Factura))
                                                {
                                                    oPedido = new PedidoCabE()
                                                    {
                                                        idEmpresa = DocumentoTmp.idEmpresa,
                                                        idLocal = DocumentoTmp.idLocal,
                                                        idPedido = pedido.idPedido,
                                                        NroGuia = pedido.NroGuia.Trim(),
                                                        nroFactura = DocumentoTmp.numSerie + "-" + DocumentoTmp.numDocumento,
                                                        FecFactura = DocumentoTmp.fecEmision,
                                                        UsuarioModificacion = Usuario
                                                    };

                                                    new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                                                }
                                            }

                                            //Guia
                                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                                            {
                                                if (String.IsNullOrWhiteSpace(Guia))
                                                {
                                                    oPedido = new PedidoCabE()
                                                    {
                                                        idEmpresa = DocumentoTmp.idEmpresa,
                                                        idLocal = DocumentoTmp.idLocal,
                                                        idPedido = pedido.idPedido,
                                                        NroGuia = DocumentoTmp.numSerie + "-" + DocumentoTmp.numDocumento,
                                                        nroFactura = pedido.nroFactura,
                                                        FecFactura = pedido.FecFactura,
                                                        UsuarioModificacion = Usuario
                                                    };

                                                    new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                                                }
                                            }


                                            if (!String.IsNullOrWhiteSpace(Factura) && !String.IsNullOrWhiteSpace(Guia))
                                            {
                                                if (pedido.Estado == "P")//Solamente si esta en estado Pedido pasa a facturado
                                                {
                                                    new PedidoCabAD().CerrarPedido(DocumentoTmp.idEmpresa, Convert.ToInt32(DocumentoTmp.nroDocAsociado), EnumEstadoDocumentos.F.ToString());
                                                }
                                            }
                                        }
                                    }
                                }

                                #endregion

                                #region CtaCte
                                /*
                                if (ConCtaCte == "S")
                                {
                                    if (idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString() || idDocumento == EnumTipoDocumentoVenta.NC.ToString() || idDocumento == EnumTipoDocumentoVenta.ND.ToString())
                                    {
                                        //Agregado el 22-02-2019, para que todo lo que sea transferencia no ingrese a la Cta.Cte.
                                        CondicionE oCondicion = new CondicionAD().ObtenerCondicion(Convert.ToInt32(DocumentoTmp.idTipCondicion), Convert.ToInt32(DocumentoTmp.idCondicion));

                                        if (!oCondicion.tGratuita)
                                        {
                                            ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                                            ClienteE Auxiliar = new ClienteAD().RecuperarClientePorId(DocumentoTmp.idPersona.Value, DocumentoTmp.idEmpresa);
                                            String Cuenta = String.Empty;

                                            #region Cuenta Contable

                                            //if (!Auxiliar.indVinculada)
                                            //{
                                            //    if (DocumentoTmp.idMoneda == Variables.Soles)
                                            //    {
                                            //        Cuenta = oParametroConta.VentaS;
                                            //    }
                                            //    else
                                            //    {
                                            //        Cuenta = oParametroConta.VentaD;
                                            //    }

                                            //    if (String.IsNullOrWhiteSpace(Cuenta))
                                            //    {
                                            //        throw new Exception("Falta configurar las cuentas para ventas en Parámetros Contables.");
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    if (DocumentoTmp.idMoneda == Variables.Soles)
                                            //    {
                                            //        Cuenta = oParametroConta.ctaVinculadaSol;
                                            //    }
                                            //    else
                                            //    {
                                            //        Cuenta = oParametroConta.ctaVinculadaDol;
                                            //    }

                                            //    if (String.IsNullOrWhiteSpace(Cuenta))
                                            //    {
                                            //        throw new Exception("Falta configurar las cuentas para ventas vinculadas en Parámetros Contables.");
                                            //    }
                                            //} 

                                            #endregion

                                            #region Cabecera

                                            //CtaCteE oCtaCte = new CtaCteE
                                            //{
                                            //    idEmpresa = DocumentoTmp.idEmpresa,
                                            //    idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                                            //    idDocumento = DocumentoTmp.idDocumento,
                                            //    numSerie = DocumentoTmp.numSerie,
                                            //    numDocumento = DocumentoTmp.numDocumento,
                                            //    idMoneda = DocumentoTmp.idMoneda,
                                            //    MontoOrig = Convert.ToDecimal(DocumentoTmp.totTotal),
                                            //    TipoCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                            //    FechaDocumento = Convert.ToDateTime(DocumentoTmp.fecEmision),
                                            //    FechaVencimiento = Convert.ToDateTime(DocumentoTmp.fecVencimiento),
                                            //    FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                            //    numVerPlanCuentas = oParametroConta.numVerPlanCuentas,
                                            //    codCuenta = Cuenta,
                                            //    AnnoVencimiento = String.Empty,
                                            //    MesVencimiento = String.Empty,
                                            //    SemanaVencimiento = String.Empty,
                                            //    tipPartidaPresu = String.Empty,
                                            //    codPartidaPresu = String.Empty,
                                            //    desGlosa = DocumentoTmp.Glosa,
                                            //    FechaOperacion = Convert.ToDateTime(DocumentoTmp.fecEmision),
                                            //    EsDetraCab = false,
                                            //    idCtaCteOrigen = 0,
                                            //    idSistema = 2, //Ventas
                                            //    UsuarioRegistro = Usuario
                                            //};

                                            //oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);
                                            //idCtaCteVentas = oCtaCte.idCtaCte;

                                            #endregion

                                            //#region Detalle

                                            //CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                            //{
                                            //    idEmpresa = DocumentoTmp.idEmpresa,
                                            //    idCtaCte = idCtaCteVentas,
                                            //    idDocumentoMov = DocumentoTmp.idDocumento,
                                            //    SerieMov = DocumentoTmp.numSerie,
                                            //    NumeroMov = DocumentoTmp.numDocumento,
                                            //    FechaMovimiento = Convert.ToDateTime(DocumentoTmp.fecEmision),
                                            //    idMoneda = DocumentoTmp.idMoneda,
                                            //    MontoMov = Convert.ToDecimal(DocumentoTmp.totTotal),
                                            //    TipoCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                            //    TipAccion = EnumEstadoDocumentos.C.ToString(),
                                            //    numVerPlanCuentas = oParametroConta.numVerPlanCuentas,
                                            //    codCuenta = Cuenta,
                                            //    desGlosa = DocumentoTmp.Glosa,
                                            //    EsDetraccion = false,
                                            //    UsuarioRegistro = Usuario
                                            //};

                                            //new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                            //#endregion

                                            //DocumentoTmp.idCtaCte = idCtaCteVentas;
                                            //DocumentoTmp.idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                            //new EmisionDocumentoAD().ActualizarEmisDocuCtaCte(DocumentoTmp);
                                        }
                                    }
                                }
                                */
                                #endregion CtaCte

                                #region Movimientos de Almacen

                                if ((DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.GV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString()
                                || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString()) && DocumentoTmp.EsGuia == EnumEsGuia.G.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                                {
                                    if (DocumentoTmp.ListaItemsDocumento == null || DocumentoTmp.ListaItemsDocumento.Count == 0)
                                    {
                                        DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                                    }


                                    if (DocumentoTmp.idTipTraslado.Value > 0)
                                    {
                                        TipoTrasladoE oTipoTraslado = new TipoTrasladoAD().ObtenerTipoTraslado(DocumentoTmp.idTipTraslado.Value);

                                        if (oTipoTraslado == null)
                                        {
                                            throw new Exception("Documento no tiene definido Tipo de Traslado.");
                                        }

                                        if (oTipoTraslado.idTraslado != 14) //oTipoTraslado Otros.
                                        {
                                            if (oTipoTraslado.codSunatOpe == null || oTipoTraslado.codSunatOpe == "")
                                            {
                                                throw new Exception("El tipo de Traslado no tiene Codigo de Sunat Valido");
                                            }

                                            #region Verificación del stock

                                            String Mes = Convert.ToDateTime(DocumentoTmp.fecEmision).ToString("MM"); //Revisar
                                            String Anio = Convert.ToDateTime(DocumentoTmp.fecEmision).ToString("yyyy"); //Revisar
                                            StockE oStock = null;

                                            foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                                            {
                                                if (String.IsNullOrEmpty(item.Lote.Trim()))
                                                {
                                                    item.Lote = "0000000";
                                                }

                                                if (item.idAlmacen == null || item.idAlmacen == 0)
                                                {
                                                    goto Salir;
                                                }

                                                AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));

                                                if (oAlmacen != null)
                                                {
                                                    if (oAlmacen.VerificaStock)
                                                    {
                                                        if (oAlmacen.VerificaLote)
                                                        {
                                                            oStock = new StockAD().ObtenerStockActual(item.idEmpresa, Convert.ToInt32(item.idAlmacen), item.idTipoArticulo, Convert.ToInt32(item.idArticulo), Anio, Mes, (item.Lote != "0000000" ? true : false), item.Lote);

                                                            if (oStock == null)
                                                            {
                                                                throw new Exception(String.Format("El stock del articulo con código {0} y Lote {1} No Existe !!!.", item.codArticulo, item.Lote));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            oStock = new StockAD().ObtenerStockActual(item.idEmpresa, Convert.ToInt32(item.idAlmacen), item.idTipoArticulo, Convert.ToInt32(item.idArticulo), Anio, Mes, (item.Lote != "0000000" ? true : false), "");
                                                        }

                                                        if (oStock.EsComprometido)
                                                        {
                                                            if (oStock.canStock < item.Cantidad)// + item.Cantidad < item.Cantidad)
                                                            {
                                                                throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (oStock.canStock < item.Cantidad)
                                                            {
                                                                throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            #endregion

                                            Int16 indCabecera = 1;
                                            Int32 idTipMovSalida = Variables.Cero;
                                            //Int32 idTipMovIngreso = Variables.Cero;
                                            Int32 idOperacion = Variables.Cero;
                                            MovimientoAlmacenE oMovimientoAlmacen = null;
                                            MovimientoAlmacenItemE oItemMovimiento = null;
                                            Int16 numItem = 1;
                                            Int32 idAlmacen = Convert.ToInt32(DocumentoTmp.ListaItemsDocumento[0].idAlmacen);
                                            List<ParTabla> oListaTipoMovimiento = new ParTablaAD().ListarParTablaPorNemo("TIPMOVALM");
                                            Boolean PorAsociar = false;

                                            if (oListaTipoMovimiento != null && oListaTipoMovimiento.Count > 0)
                                            {
                                                idTipMovSalida = (from x in oListaTipoMovimiento
                                                                  where x.NemoTecnico == "EGR"
                                                                  select x.IdParTabla).SingleOrDefault();
                                            }
                                            else
                                            {
                                                throw new Exception("No existe Tipos de Movimientos para los Egresos.");
                                            }

                                            List<OperacionE> oListaOperaciones = null;

                                            //Agrupando por almacen para saber si todo va a un almacen o varios....
                                            var ListarDocumentosDetTmp = DocumentoTmp.ListaItemsDocumento.GroupBy(x => x.idAlmacen).Select(p => p.First()).ToList();
                                            List<CanjeGuiasE> CanjeGuia = new CanjeGuiasAD().ObtenerCanjeGuiasPorGuia(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                                            if (ListarDocumentosDetTmp.Count == 1)
                                            {
                                                #region Cuando es solo un Item

                                                foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                                                {
                                                    #region Cabecera

                                                    if (indCabecera == 1)
                                                    {
                                                        //Obteniendo el almacén...
                                                        AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));

                                                        Int32 AlmacenDestino = Variables.Cero;

                                                        CondicionE oCondicion = new CondicionAD().ObtenerCondicion(Convert.ToInt32(DocumentoTmp.idTipCondicion), Convert.ToInt32(DocumentoTmp.idCondicion));

                                                        if (oCondicion != null)
                                                        {
                                                            if (DocumentoTmp.idTipTraslado == 6)
                                                            {
                                                                PorAsociar = true;
                                                                AlmacenDestino = Convert.ToInt32(DocumentoTmp.idAlmacenDestino);

                                                                if (AlmacenDestino == Variables.Cero)
                                                                {
                                                                    throw new Exception("No se puede emitir el documento, porque se trata de un traslado entre sucursales y hace falta el destino.");
                                                                }
                                                            }
                                                        }

                                                        //Obteniendo la lista de operaciones...
                                                        oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), DocumentoTmp.idEmpresa, idTipMovSalida);

                                                        //OperacionE Operacion = oListaOperaciones.Find
                                                        //(
                                                        //    delegate (OperacionE op) { return (DocumentoTmp.idTipTraslado != 6 ? op.desOperacion == "VENTAS" : op.indTransferencia == true); }
                                                        //);

                                                        OperacionE Operacion = oListaOperaciones.Find
                                                        (
                                                            delegate (OperacionE op) { return (oTipoTraslado.codSunatOpe == op.codSunat); }
                                                        );


                                                        if (Operacion == null)
                                                        {
                                                            throw new Exception("No existe Tipos de Operacion.");
                                                        }
                                                        else
                                                        {
                                                            idOperacion = Operacion.idOperacion;
                                                        }

                                                        oMovimientoAlmacen = new MovimientoAlmacenE()
                                                        {
                                                            idEmpresa = DocumentoTmp.idEmpresa,
                                                            tipMovimiento = idTipMovSalida,
                                                            idAlmacen = Convert.ToInt32(item.idAlmacen),
                                                            tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                                                            idOperacion = idOperacion,
                                                            fecProceso = Convert.ToDateTime(DocumentoTmp.fecEmision).ToString("yyyyMMdd"), //Revisar
                                                            fecDocumento = Convert.ToDateTime(DocumentoTmp.fecEmision).ToString("yyyyMMdd"), //Revisar
                                                            idDocumento = DocumentoTmp.idDocumento,
                                                            serDocumento = DocumentoTmp.numSerie,
                                                            numDocumento = DocumentoTmp.numDocumento,
                                                            idDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].idDocumentoFact : String.Empty,
                                                            SerieDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].numSerieFact : string.Empty,
                                                            NumeroDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].numDocumentoFact : string.Empty,
                                                            idOrdenCompra = Variables.Cero,
                                                            numRequisicion = String.Empty,
                                                            idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                                                            idMoneda = DocumentoTmp.idMoneda,
                                                            indCambio = true,
                                                            tipCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                                            impValorVenta = Convert.ToDecimal(DocumentoTmp.totsubTotal),
                                                            Impuesto = Convert.ToDecimal(DocumentoTmp.totIgv),
                                                            impTotal = Convert.ToDecimal(DocumentoTmp.totTotal),
                                                            indPorAsociar = PorAsociar,
                                                            idAlmacenDestino = AlmacenDestino,
                                                            tipMovimientoAsociado = null,
                                                            idDocumentoAlmacenAsociado = null,

                                                            Glosa = DocumentoTmp.Glosa,
                                                            UsuarioRegistro = Usuario
                                                        };
                                                    }

                                                    #endregion

                                                    #region Detalle

                                                    if (String.IsNullOrEmpty(item.Lote.Trim()))
                                                    {
                                                        item.Lote = "0000000";
                                                    }

                                                    oItemMovimiento = new MovimientoAlmacenItemE()
                                                    {
                                                        idEmpresa = oMovimientoAlmacen.idEmpresa,
                                                        tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                                                        idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                                        numItem = String.Format("{0:0000}", numItem),
                                                        idArticulo = Convert.ToInt32(item.idArticulo),
                                                        Lote = item.Lote,
                                                        idUbicacion = Variables.Cero,
                                                        Cantidad = Convert.ToDecimal(item.Cantidad),
                                                        ImpCostoUnitarioBase = Variables.Cero,
                                                        ImpCostoUnitarioRefe = Variables.Cero,
                                                        ImpTotalBase = Variables.Cero,
                                                        ImpTotalRefe = Variables.Cero,
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

                                                    oMovimientoAlmacen.ListaAlmacenItem.Add(oItemMovimiento);

                                                    indCabecera++;
                                                    numItem++;

                                                    #endregion
                                                }

                                                oMovimientoAlmacen = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Insertar);

                                                //Se quito porque cuando se graba el movimiento ya hace el ingreso(13-09-18)
                                                //Si se trata de una transferencia...
                                                //if (PorAsociar)
                                                //{
                                                //    if (oListaTipoMovimiento != null && oListaTipoMovimiento.Count > 0)
                                                //    {
                                                //        idTipMovIngreso = (from x in oListaTipoMovimiento
                                                //                           where x.NemoTecnico == "ING"
                                                //                           select x.IdParTabla).SingleOrDefault();
                                                //    }
                                                //    else
                                                //    {
                                                //        throw new Exception("No existe Tipos de Movimientos para los Ingresos.");
                                                //    }

                                                //    GenerarIngresoTransferencia(oMovimientoAlmacen, idTipMovIngreso, Usuario);
                                                //}

                                                //Actualizando el Nro. de documento de almacen...
                                                foreach (EmisionDocumentoDetE itemTemp in DocumentoTmp.ListaItemsDocumento)
                                                {
                                                    new EmisionDocumentoDetAD().UpdateVenEmiDetDocAlmacen(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, itemTemp.Item,
                                                                                                            Convert.ToInt32(itemTemp.idAlmacen), oMovimientoAlmacen.idDocumentoAlmacen, Usuario);
                                                }

                                                #endregion
                                            }
                                            else
                                            {
                                                #region Cuando son varios elementos

                                                Decimal SubTotal = 0;
                                                Decimal ImpuestoIgv = 0;
                                                Decimal Total = 0;
                                                Int32 AlmacenDestino = Variables.Cero;

                                                foreach (var item in ListarDocumentosDetTmp)
                                                {
                                                    List<EmisionDocumentoDetE> oListaTmpDetalle = new List<EmisionDocumentoDetE>((from x in DocumentoTmp.ListaItemsDocumento
                                                                                                                                  where x.idAlmacen == item.idAlmacen
                                                                                                                                  select x).ToList());
                                                    if (oListaTmpDetalle.Count > 0)
                                                    {
                                                        SubTotal = oListaTmpDetalle.Sum(x => x.subTotal);
                                                        ImpuestoIgv = oListaTmpDetalle.Sum(x => x.Igv);
                                                        Total = oListaTmpDetalle.Sum(x => x.Total);

                                                        #region Cabecera

                                                        AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));
                                                        CondicionE oCondicion = new CondicionAD().ObtenerCondicion(Convert.ToInt32(DocumentoTmp.idTipCondicion), Convert.ToInt32(DocumentoTmp.idCondicion));

                                                        if (oCondicion != null)
                                                        {
                                                            if (DocumentoTmp.idTipTraslado == 6)
                                                            {
                                                                PorAsociar = true;
                                                                AlmacenDestino = Convert.ToInt32(DocumentoTmp.idAlmacenDestino);

                                                                if (AlmacenDestino == Variables.Cero)
                                                                {
                                                                    throw new Exception("No se puede emitir el documento, porque se trata de un traslado entre sucursales y hace falta el destino.");
                                                                }
                                                            }
                                                        }

                                                        oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), DocumentoTmp.idEmpresa, idTipMovSalida);

                                                        //OperacionE Operacion = oListaOperaciones.Find
                                                        //(
                                                        //    delegate (OperacionE op) { return op.desOperacion == "VENTAS"; }
                                                        //);

                                                        OperacionE Operacion = oListaOperaciones.Find
                                                        (
                                                            delegate (OperacionE op) { return (oTipoTraslado.codSunatOpe == op.codSunat); }
                                                        );

                                                        if (Operacion == null)
                                                        {
                                                            throw new Exception("No existe Tipos de Operacion.");
                                                        }
                                                        else
                                                        {
                                                            idOperacion = Operacion.idOperacion;
                                                        }

                                                        oMovimientoAlmacen = new MovimientoAlmacenE()
                                                        {
                                                            idEmpresa = DocumentoTmp.idEmpresa,
                                                            tipMovimiento = idTipMovSalida,
                                                            idAlmacen = Convert.ToInt32(item.idAlmacen),
                                                            tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                                                            idOperacion = idOperacion,
                                                            //fecProceso = DocumentoTmp.fecEmision, //Revisar
                                                            //fecDocumento = DocumentoTmp.fecEmision, //Revisar
                                                            idDocumento = DocumentoTmp.idDocumento,
                                                            serDocumento = DocumentoTmp.numSerie,
                                                            numDocumento = DocumentoTmp.numDocumento,
                                                            idDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].idDocumentoFact : String.Empty,
                                                            SerieDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].numSerieFact : string.Empty,
                                                            NumeroDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].numDocumentoFact : string.Empty,
                                                            idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                                                            idMoneda = DocumentoTmp.idMoneda,
                                                            indCambio = true,
                                                            tipCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                                            impValorVenta = SubTotal,
                                                            Impuesto = ImpuestoIgv,
                                                            impTotal = Total,
                                                            indPorAsociar = PorAsociar,
                                                            idAlmacenDestino = AlmacenDestino,
                                                            tipMovimientoAsociado = null,
                                                            idDocumentoAlmacenAsociado = null,

                                                            Glosa = DocumentoTmp.Glosa,
                                                            UsuarioRegistro = Usuario
                                                        };

                                                        #endregion

                                                        #region Detalle

                                                        foreach (EmisionDocumentoDetE itemDetalle in oListaTmpDetalle)
                                                        {
                                                            if (String.IsNullOrEmpty(itemDetalle.Lote.Trim()))
                                                            {
                                                                itemDetalle.Lote = "0000000";
                                                            }

                                                            oItemMovimiento = new MovimientoAlmacenItemE()
                                                            {
                                                                idEmpresa = oMovimientoAlmacen.idEmpresa,
                                                                tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                                                                idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                                                numItem = String.Format("{0:0000}", numItem),
                                                                idArticulo = Convert.ToInt32(itemDetalle.idArticulo),
                                                                Lote = itemDetalle.Lote,
                                                                idUbicacion = Variables.Cero,
                                                                Cantidad = Convert.ToDecimal(itemDetalle.Cantidad),
                                                                ImpCostoUnitarioBase = Variables.Cero,
                                                                ImpCostoUnitarioRefe = Variables.Cero,
                                                                ImpTotalBase = Variables.Cero,
                                                                ImpTotalRefe = Variables.Cero,
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

                                                            oMovimientoAlmacen.ListaAlmacenItem.Add(oItemMovimiento);
                                                            numItem++;
                                                        }

                                                        #endregion

                                                        //Guardando el movimiento de salida en el almacen...
                                                        oMovimientoAlmacen = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Insertar);

                                                        //Se quito porque cuando se graba el movimiento ya hace el ingreso(13-09-18)
                                                        //Si se trata de una transferencia...
                                                        //if (PorAsociar)
                                                        //{
                                                        //    if (oListaTipoMovimiento != null && oListaTipoMovimiento.Count > 0)
                                                        //    {
                                                        //        idTipMovIngreso = (from x in oListaTipoMovimiento
                                                        //                           where x.NemoTecnico == "ING"
                                                        //                           select x.IdParTabla).SingleOrDefault();
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        throw new Exception("No existe Tipos de Movimientos para los Ingresos.");
                                                        //    }

                                                        //    GenerarIngresoTransferencia(oMovimientoAlmacen, idTipMovIngreso, Usuario);
                                                        //}

                                                        //Actualizando el Nro. de documento de almacen...
                                                        foreach (EmisionDocumentoDetE itemTemp in oListaTmpDetalle)
                                                        {
                                                            new EmisionDocumentoDetAD().UpdateVenEmiDetDocAlmacen(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, itemTemp.Item,
                                                                                                                    Convert.ToInt32(itemTemp.idAlmacen), oMovimientoAlmacen.idDocumentoAlmacen, Usuario);
                                                        }
                                                    }
                                                }

                                                #endregion
                                            }
                                        }
                                    }

                                    //goto Finish;
                                }
                             
                                if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                                {
                                    if (DocumentoTmp.desCondicion.ToUpper().Contains("DEVOLUCIÓN") || DocumentoTmp.desCondicion.ToUpper().Contains("DEVOLUCION") || DocumentoTmp.desCondicion.ToUpper().Contains("anulación de la operación") || DocumentoTmp.desCondicion.ToUpper().Contains("anulación de la operación") || DocumentoTmp.idCondicion == 1)
                                    {
                                        Boolean indDevo = false;
                                        String idDocDevo = "00";
                                        String serDocDevo = "";
                                        String numDocDevo = "";
                                        MovimientoAlmacenE oMovimiento = null;
                                        oMovimiento = new MovimientoAlmacenAD().MovimientoAlmacenPorReferencia(DocumentoTmp.idEmpresa, DocumentoTmp.idDocumentoRef, DocumentoTmp.serDocumentoRef, DocumentoTmp.numDocumentoRef);

                                        if (oMovimiento == null || DocumentoTmp.desCondicion.ToUpper().Contains("anulación de la operación"))
                                        {
                                            List<CanjeGuiasE> oCanje = new CanjeGuiasAD().ObtenerCanjeGuias(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumentoRef, DocumentoTmp.serDocumentoRef, DocumentoTmp.numDocumentoRef);

                                            if (oCanje != null)
                                            {
                                                if (oCanje.Count() > 0)
                                                {
                                                    oMovimiento = new MovimientoAlmacenAD().MovimientoAlmacenPorReferencia(oCanje[0].idEmpresa, oCanje[0].idDocumentoGuia, oCanje[0].numSerieGuia, oCanje[0].numDocumentoGuia);
                                                    indDevo = true;
                                                    idDocDevo = oCanje[0].idDocumentoGuia;
                                                    serDocDevo = oCanje[0].numSerieGuia;
                                                    numDocDevo = oCanje[0].numDocumentoGuia;
                                                }
                                            }
                                        }


                                        else
                                        {
                                            indDevo = true;
                                            idDocDevo = DocumentoTmp.idDocumentoRef;
                                            serDocDevo = DocumentoTmp.serDocumentoRef;
                                            numDocDevo = DocumentoTmp.numDocumentoRef;
                                        }

                                        if (oMovimiento != null)
                                        {
                                            oMovimiento.ListaAlmacenItem = new MovimientoAlmacenItemAD().ListarMovimiento_Almacen_Item(idEmpresa, oMovimiento.idDocumentoAlmacen).OrderBy(x => x.idItem).ToList();
                                            DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                            if (DocumentoTmp.ListaItemsDocumento.Count() > 0)
                                            {
                                                Int32 idAlmacen = Convert.ToInt32(DocumentoTmp.ListaItemsDocumento[0].idAlmacen);
                                                AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(idEmpresa, Convert.ToInt32(idAlmacen));

                                                Int32 idTipMovIngreso = Variables.Cero;
                                                Int32 idOperacion = 11;
                                                List<ParTabla> oListaTipoMovimiento = new ParTablaAD().ListarParTablaPorNemo("TIPMOVALM");

                                                if (oListaTipoMovimiento != null && oListaTipoMovimiento.Count > 0)
                                                {
                                                    idTipMovIngreso = (from x in oListaTipoMovimiento
                                                                       where x.NemoTecnico == "ING"
                                                                       select x.IdParTabla).SingleOrDefault();
                                                }
                                                else
                                                {
                                                    throw new Exception("No existe Tipos de Operaciones para Movimiento.");
                                                }

                                                List<OperacionE> oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), DocumentoTmp.idEmpresa, idTipMovIngreso);
                                                OperacionE Operacion = oListaOperaciones.Find
                                                (
                                                    delegate (OperacionE op) { return op.desOperacion.ToUpper().Contains("anulación de la operación"); }
                                                );

                                                if (Operacion == null)
                                                {
                                                    Operacion = oListaOperaciones.Find
                                                    (
                                                        delegate (OperacionE op) { return op.desOperacion.ToUpper().Contains("anulación de la operación"); }
                                                    );

                                                    if (Operacion == null)
                                                    {
                                                        throw new Exception("No existe Tipos de Operacion.");
                                                    }
                                                    else
                                                    {
                                                        idOperacion = Operacion.idOperacion;
                                                    }
                                                }
                                                else
                                                {
                                                    idOperacion = Operacion.idOperacion;
                                                }

                                                oMovimiento.tipMovimiento = idTipMovIngreso;
                                                oMovimiento.idOperacion = idOperacion;
                                                oMovimiento.idDocumento = DocumentoTmp.idDocumento;
                                                oMovimiento.indFactura = true;
                                                oMovimiento.serDocumento = DocumentoTmp.numSerie;
                                                oMovimiento.numDocumento = DocumentoTmp.numDocumento;
                                                oMovimiento.UsuarioRegistro = Usuario;

                                                oMovimiento.idDocumentoRef = DocumentoTmp.idDocumentoRef;
                                                oMovimiento.SerieDocumentoRef = DocumentoTmp.serDocumentoRef;
                                                oMovimiento.NumeroDocumentoRef = DocumentoTmp.numDocumentoRef;

                                                oMovimiento.indDocDevolucion = indDevo;
                                                oMovimiento.idDocumentoDevolucion = idDocDevo;
                                                oMovimiento.serDocumentoDevolucion = serDocDevo;
                                                oMovimiento.numDocumentoDevolucion = numDocDevo;

                                                Int32 it = 0;

                                                foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                                                {
                                                    if (it == 0)
                                                    {
                                                        oMovimiento.idAlmacen = Convert.ToInt32(item.idAlmacen);
                                                    }

                                                    MovimientoAlmacenItemE oitem = new MovimientoAlmacenItemE();
                                                    it++;

                                                    oitem.numItem = String.Format("{0:0000}", it);

                                                    oitem.idItem = 0;
                                                    oitem.idArticulo = Convert.ToInt32(item.idArticulo);
                                                    oitem.Lote = item.Lote;
                                                    oitem.Cantidad = Convert.ToDecimal(item.Cantidad);

                                                    oitem.idUbicacion = 0;

                                                    oitem.ImpCostoUnitarioBase = 0;
                                                    oitem.ImpCostoUnitarioRefe = 0;
                                                    oitem.ImpTotalBase = 0;
                                                    oitem.ImpTotalRefe = 0;
                                                    oitem.indCalidad = false;
                                                    oitem.indConformidad = false;
                                                    oitem.idCCostos = "";
                                                    oitem.idCCostosUso = "";
                                                    oitem.idArticuloUso = 0;
                                                    oitem.nroEnvases = 0;
                                                    oitem.Valorizado = false;
                                                    oitem.nroParteProd = "";
                                                    oitem.idItemCompra = 0;

                                                    oitem.tipMovimiento = idTipMovIngreso;
                                                    oitem.UsuarioRegistro = Usuario;

                                                    oMovimiento.ListaAlmacenItem.Add(oitem);
                                                }

                                                oMovimiento = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimiento, EnumOpcionGrabar.Insertar);

                                                
                                                //Actualizando el Nro. de documento de almacen...
                                                foreach (EmisionDocumentoDetE itemTemp in DocumentoTmp.ListaItemsDocumento)
                                                {
                                                    new EmisionDocumentoDetAD().UpdateVenEmiDetDocAlmacen(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, itemTemp.Item,
                                                                                                            Convert.ToInt32(itemTemp.idAlmacen), oMovimiento.idDocumentoAlmacen, Usuario);
                                                }
                                            }
                                        }
                                    }
                                }

                                #endregion Movimientos de Almacen

                                #region Cancelacion - Planilla de Cobranzas

                                if (conCobranza == "S")
                                {
                                    if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                                    {
                                        //cancelacion

                                        if (DocumentoTmp.indCancelacion)
                                        {
                                            //Modificado el proceso de cancelaciones el dia 22-02-2019
                                            DocumentoTmp.ListaCancelaciones = new EmisionDocumentoCancelacionAD().ObtenerEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                            if (DocumentoTmp.ListaCancelaciones.Count > 0)
                                            {
                                                //Tipo de planilla
                                                ParTabla oTipoCobro = new ParTablaAD().ParTablaPorNemo("PLAEFE");
                                                //Obteniendo los parámetros contables
                                                ParametrosContaE oParametroCuenta = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                                                //Obteniendo el diario y el file
                                                EmisionDocumentoCancelacionE oFileDiario = new EmisionDocumentoCancelacionAD().ObtenerDiarioFileCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                                                //Quitado el 22-02-2019
                                                //if (!DocumentoTmp.EsAnticipo)
                                                //{
                                                //    oTipoCobro = new ParTablaAD().ParTablaPorNemo("PLAEFE");
                                                //}
                                                //else
                                                //{
                                                //    oTipoCobro = new ParTablaAD().ParTablaPorNemo("PLAANT");
                                                //}

                                                //Validación si en caso sea nulo
                                                if (oFileDiario == null)
                                                {
                                                    throw new Exception("No esta configurado las cuentas en el Maestro de Bancos o en el Maestro de los Diarios.");
                                                }

                                                // ObtenerEmisionDocumentoDet


                                                //Recorriendo la lista de cancelaciones
                                                foreach (EmisionDocumentoCancelacionE item in DocumentoTmp.ListaCancelaciones)
                                                {
                                                    if (!item.VariosCobros) //Si es verdadero ingresa pero por otro proceso...
                                                    {
                                                        //CABECERA
                                                        CobranzasE oCobranza = new CobranzasE()
                                                        {
                                                            TipoPlanilla = oTipoCobro.IdParTabla,
                                                            idEmpresa = item.idEmpresa,
                                                            idLocal = item.idLocal,
                                                            Fecha = Convert.ToDateTime(item.fecAbono),
                                                            MontoSoles = 0,
                                                            MontoDolares = 0,
                                                            Observaciones = DocumentoTmp.Glosa,
                                                            idComprobante = oFileDiario.idComprobante,
                                                            numFile = oFileDiario.numFile,
                                                            AnioPeriodo = DocumentoTmp.fecEmision, //Revisar
                                                            MesPeriodo = DocumentoTmp.fecEmision, //Revisar
                                                            numVoucher = String.Empty,
                                                            UsuarioRegistro = Usuario
                                                        };

                                                        //DETALLE
                                                        CobranzasItemE oCobranzaItem = new CobranzasItemE()
                                                        {
                                                            Fecha = Convert.ToDateTime(item.fecAbono),
                                                            idMoneda = item.idMonedaRecibida,
                                                            Monto = item.MontoRecibido,
                                                            TipoCobro = "D",
                                                            Descripcion = String.Empty,
                                                            tipCambioReci = item.tipCambio,
                                                            fecVencimiento = null,
                                                            //fecCobranza = item.fecAbono, //Por revisar
                                                            idDocumento = item.idDocumentoReci,
                                                            numSerie = item.numSerieReci,
                                                            numCheque = item.numDocumentoReci,
                                                            Comision = 0,
                                                            Interes = 0,
                                                            numVerPlanCuentas = oFileDiario.numVerPlanCuentas,
                                                            codCuenta = oFileDiario.codCuenta,
                                                            codCuentaProvision = String.Empty,
                                                            idConceptoGasto = null,
                                                            idConceptoInteres = null,
                                                            idBanco = item.idBanco,
                                                            indPresupuesto = false,
                                                            tipPartidaPresu = String.Empty,
                                                            idPartidaPresu = String.Empty,
                                                            cheDifCancelando = false,
                                                            UsuarioRegistro = Usuario
                                                        };

                                                        //Agregando el detalle a la cabecera
                                                        oCobranza.oListaCobranzas.Add(oCobranzaItem);

                                                        #region Actualizando los totales en la cabecera...

                                                        Decimal Soles = 0;
                                                        Decimal Dolares = 0;

                                                        foreach (CobranzasItemE itemImp in oCobranza.oListaCobranzas)
                                                        {
                                                            if (itemImp.idMoneda == Variables.Soles)
                                                            {
                                                                Soles += itemImp.Monto;
                                                                Dolares += itemImp.Monto / itemImp.tipCambioReci;
                                                            }
                                                            else
                                                            {
                                                                Soles += itemImp.Monto * itemImp.tipCambioReci;
                                                                Dolares += itemImp.Monto;
                                                            }
                                                        }

                                                        oCobranza.MontoSoles = Soles;
                                                        oCobranza.MontoDolares = Dolares;

                                                        #endregion

                                                        String Cuenta12 = String.Empty;

                                                        if (DocumentoTmp.idMoneda == Variables.Soles)
                                                        {
                                                            Cuenta12 = oParametroCuenta.VentaS;
                                                        }
                                                        else
                                                        {
                                                            Cuenta12 = oParametroCuenta.VentaD;
                                                        }

                                                        //DETALLE ITEM
                                                        CobranzasItemDetE oCobranzaItemDet = new CobranzasItemDetE()
                                                        {
                                                            idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                                                            idDocumento = item.idDocumento,
                                                            numSerie = item.numSerie,
                                                            numDocumento = item.numDocumento,
                                                            //fecEmision = item.Fecha, //Revisar
                                                            idMoneda = item.idMonedaDocum,
                                                            Monto = item.MontoAplicar,
                                                            idMonedaReci = item.idMonedaRecibida,
                                                            MontoReci = item.MontoRecibido,
                                                            tipCambioReci = DocumentoTmp.tipCambio,
                                                            numVerPlanCuentas = oFileDiario.numVerPlanCuentas,
                                                            codCuenta = Cuenta12,
                                                            //fecVencimiento = item.Fecha, //Revisar
                                                            idCtaCte = idCtaCteVentas == 0 ? (Int32?)null : idCtaCteVentas,
                                                            UsuarioRegistro = Usuario
                                                        };

                                                        //Agregando al detalle el item
                                                        oCobranza.oListaCobranzas[0].oListaCobranzasItemDet.Add(oCobranzaItemDet);

                                                        //Grabando la Cobranza
                                                        oCobranza = new CobranzasLN().GrabarCobranzas(oCobranza, EnumOpcionGrabar.Insertar);
                                                        //Actualizando el campo que indica que la cobranzas viene del módulo de facturación
                                                        new CobranzasAD().ActualizarVieneFact(oCobranza.idPlanilla);
                                                        //Cerrando la cobranza
                                                        new CobranzasLN().CerrarPlanillas(oCobranza.idPlanilla, idEmpresa, idLocal, oParametroCuenta.numVerPlanCuentas, Usuario, oTipoCobro.NemoTecnico);
                                                        //Actualizar el ID de la planilla en la table de ven_EmisionDocumentoCancelaciones
                                                        item.idPlanilla = oCobranza.idPlanilla;
                                                        new EmisionDocumentoCancelacionAD().ActualizarEmisDocuCancelacionPlanilla(item);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                #endregion
                            }

                            #region Soltar OT

                            MovimientoAlmacenE oEmisionDoc = null;

                            if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                            {
                                if (DocumentoTmp.idTipCondicion == 2 && DocumentoTmp.idCondicion == 1)
                                {
                                    List<CanjeGuiasE> oListaGuiasCanje = new CanjeGuiasAD().ObtenerCanjeGuias(idEmpresa, idLocal, DocumentoTmp.idDocumentoRef, DocumentoTmp.serDocumentoRef, DocumentoTmp.numDocumentoRef);

                                    if (oListaGuiasCanje != null && oListaGuiasCanje.Count > 0)
                                    {
                                        foreach (CanjeGuiasE itemCanje in oListaGuiasCanje)
                                        {
                                            List<EmisionDocumentoDetE> oGuiaDocumentos = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, itemCanje.idDocumentoGuia, itemCanje.numSerieGuia, itemCanje.numDocumentoGuia);

                                          
                                         
                                            if (oGuiaDocumentos != null && oGuiaDocumentos.Count > 0)
                                            {
                                                foreach (EmisionDocumentoDetE itemGuia in oGuiaDocumentos)
                                                {
                                                    new EmisionDocumentoAD().CambiarEstadoDocumento(idEmpresa, idLocal, itemCanje.idDocumentoGuia, itemCanje.numSerieGuia, itemCanje.numDocumentoGuia, EnumEstadoDocumentos.E.ToString());
                                                    new OrdenTrabajoServicioItemAD().CambiarEstadoDocumentoOT(idEmpresa, idLocal, Convert.ToInt32(itemGuia.nroOt), Convert.ToInt32(itemGuia.nroOtItem), EnumEstadoDocumentos.P.ToString());
                                                
                                                
                                                
                                                }
                                            }
                                        }
                                    }

                                }
                            }

                            #endregion
                        }

                        #endregion
                    }

                Salir:
                    goto Finish;

                Finish:
                    //Revisando el documento si ya ha sido emitido
                    if (indEstado == EnumEstadoDocumentos.E.ToString() && DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.GV.ToString() && DocumentoTmp.EsGuia == EnumEsGuia.G.ToString())
                    {
                        EmisionDocumentoE oDocuBusqueda = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                        if (oDocuBusqueda.indEstado == EnumEstadoDocumentos.E.ToString())
                        {
                            throw new Exception("Este documento ya se encuentra emitido, actualice la ventana por favor. (Puede presionar F1.)");
                        }
                    }

                    if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString())
                    {
                        Int16 indCabecera = 1;
                        Int32 idTipMovSalida = Variables.Cero;
                        //Int32 idTipMovIngreso = Variables.Cero;
                        Int32 idOperacion = Variables.Cero;
                        MovimientoAlmacenE oMovimientoAlmacen = null;
                        MovimientoAlmacenItemE oItemMovimiento = null;
                        Int16 numItem = 1;
                        Int32 idAlmacen = Convert.ToInt32(DocumentoTmp.ListaItemsDocumento[0].idAlmacen);
                        List<ParTabla> oListaTipoMovimiento = new ParTablaAD().ListarParTablaPorNemo("TIPMOVALM");
                        Boolean PorAsociar = false;

                        if (oListaTipoMovimiento != null && oListaTipoMovimiento.Count > 0)
                        {
                            idTipMovSalida = (from x in oListaTipoMovimiento
                                              where x.NemoTecnico == "ING"
                                              select x.IdParTabla).SingleOrDefault();
                        }
                        else
                        {
                            throw new Exception("No existe Tipos de Movimientos para los Egresos.");
                        }

                        List<OperacionE> oListaOperaciones = null;

                        //Agrupando por almacen para saber si todo va a un almacen o varios....
                        var ListarDocumentosDetTmp = DocumentoTmp.ListaItemsDocumento.GroupBy(x => x.idAlmacen).Select(p => p.First()).ToList();
                        List<CanjeGuiasE> CanjeGuia = new CanjeGuiasAD().ObtenerCanjeGuiasPorGuia(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                        if (ListarDocumentosDetTmp.Count == 1)
                        {
                            #region Cuando es solo un Item

                            foreach (EmisionDocumentoDetE item in DocumentoTmp.ListaItemsDocumento)
                            {
                                #region Cabecera

                                if (indCabecera == 1)
                                {
                                    //Obteniendo el almacén...
                                    AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));

                                    Int32 AlmacenDestino = Variables.Cero;

                                    CondicionE oCondicion = new CondicionAD().ObtenerCondicion(Convert.ToInt32(DocumentoTmp.idTipCondicion), Convert.ToInt32(DocumentoTmp.idCondicion));

                                    if (oCondicion != null)
                                    {
                                        if (DocumentoTmp.idTipTraslado == 6)
                                        {
                                            PorAsociar = true;
                                            AlmacenDestino = Convert.ToInt32(DocumentoTmp.idAlmacenDestino);

                                            if (AlmacenDestino == Variables.Cero)
                                            {
                                                throw new Exception("No se puede emitir el documento, porque se trata de un traslado entre sucursales y hace falta el destino.");
                                            }
                                        }
                                    }

                                    //Obteniendo la lista de operaciones...
                                    oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), DocumentoTmp.idEmpresa, idTipMovSalida);

                                    //oListaPedidoNac =new PedidoDet().ObtenerPedido

                                    oMovimientoAlmacen = new MovimientoAlmacenE()
                                    {
                                        idEmpresa = DocumentoTmp.idEmpresa,
                                        tipMovimiento = idTipMovSalida,
                                        idAlmacen = Convert.ToInt32(item.idAlmacen),
                                        tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                                        idOperacion = idOperacion,
                                        fecProceso = Convert.ToDateTime(DocumentoTmp.fecEmision).ToString("yyyyMMdd"), //Revisar
                                        fecDocumento = Convert.ToDateTime(DocumentoTmp.fecEmision).ToString("yyyyMMdd"), //Revisar
                                        idDocumento = DocumentoTmp.idDocumento,
                                        serDocumento = DocumentoTmp.numSerie,
                                        numDocumento = DocumentoTmp.numDocumento,
                                        idDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].idDocumentoFact : String.Empty,
                                        SerieDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].numSerieFact : string.Empty,
                                        NumeroDocumentoRef = CanjeGuia != null && CanjeGuia.Count > 0 ? CanjeGuia[0].numDocumentoFact : string.Empty,
                                        idOrdenCompra = Variables.Cero,
                                        numRequisicion = String.Empty,
                                        idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                                        idMoneda = DocumentoTmp.idMoneda,
                                        indCambio = true,
                                        tipCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                        impValorVenta = Convert.ToDecimal(DocumentoTmp.totsubTotal),
                                        Impuesto = Convert.ToDecimal(DocumentoTmp.totIgv),
                                        impTotal = Convert.ToDecimal(DocumentoTmp.totTotal),
                                        indPorAsociar = PorAsociar,
                                        idAlmacenDestino = AlmacenDestino,
                                        tipMovimientoAsociado = null,
                                        idDocumentoAlmacenAsociado = null,

                                        Glosa = DocumentoTmp.Glosa,
                                        UsuarioRegistro = Usuario
                                    };

                                }
                           
                                #endregion

                                #region Detalle

                                if (String.IsNullOrEmpty(item.Lote.Trim()))
                                {
                                    item.Lote = "0000000";
                                }
                                oItemMovimiento = new MovimientoAlmacenItemE()

                                {
                                    idEmpresa = oMovimientoAlmacen.idEmpresa,
                                    tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                                    idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                    numItem = String.Format("{0:0000}", numItem),
                                    idArticulo = Convert.ToInt32(item.idArticulo),
                                    Lote = item.Lote,
                                    idUbicacion = Variables.Cero,
                                    Cantidad = Convert.ToDecimal(item.Cantidad)+DocumentoTmp.Cantidad,
                                    ImpCostoUnitarioBase = Variables.Cero,
                                    ImpCostoUnitarioRefe = Variables.Cero,
                                    ImpTotalBase = Variables.Cero,
                                    ImpTotalRefe = Variables.Cero,
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


                                oMovimientoAlmacen.ListaAlmacenItem.Add(oItemMovimiento);
                                
                                
                                indCabecera++;
                                numItem++;

                                #endregion
                            }
                            oMovimientoAlmacen = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Insertar);
                        }
                        #endregion
                    }


                    new EmisionDocumentoAD().CambiarEstadoDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, indEstado);

                    //Transaccion completada...
                    oTrans.Complete();
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
        
        public EmisionDocumentoE RevisarEmisionDocumentoReferencias(Int32 idEmpresa, Int32 idLocal, String idDocumentoRef, String serDocumentoRef, String numDocumentoRef, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoAD().RevisarEmisionDocumentoReferencias(idEmpresa, idLocal, idDocumentoRef, serDocumentoRef, numDocumentoRef, idDocumento, numSerie, numDocumento);
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



        public void ActualizarStock(Int32 idEmpresa, /*Int32 idLocal,*/ Int32? item, decimal cantidad)
        {

            try
            {
                new EmisionDocumentoAD().ActualizarStock(idEmpresa,/*idLocal,*/item,cantidad);
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


        public Int32 ActualizarEstadoSunat(List<EmisionDocumentoE> oListaPorRevisar)
        {
            Int32 resp = Variables.Cero;
            Int32 reg = Variables.Cero;
            //EmisionDocumentoE oItemDevuelto = null;

            try
            {
                if (oListaPorRevisar.Count > Variables.Cero)
                {
                    foreach (EmisionDocumentoE item in oListaPorRevisar)
	                {
                        //oItemDevuelto = new EmisionDocumentoAD().RecuperarEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);

                        //if (oItemDevuelto != null)
                        //{
                        //    if (item.idEmpresa == oItemDevuelto.idEmpresa && item.idLocal == oItemDevuelto.idLocal && item.idDocumento == oItemDevuelto.idDocumento 
                        //        && item.numSerie == oItemDevuelto.numSerie && oItemDevuelto.numDocumento == item.numDocumento)
                        //    {
                        //        oItemDevuelto.EstadoSunat = item.EstadoSunat;
                        //        oItemDevuelto.MensajeSunat = item.MensajeSunat;
                        //        oItemDevuelto.UsuarioModificacion = item.UsuarioModificacion;

                        reg = new EmisionDocumentoAD().ActualizarDocumentosSunat(item);
                        resp += reg;
                        //    }
                        //}
	                }
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

        public Int32 ActualizarDocumentosSunat(EmisionDocumentoE oDocumentoSunat)
        {
            try
            {
                return new EmisionDocumentoAD().ActualizarDocumentosSunat(oDocumentoSunat);
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

        public Int32 DarBajaDocumentosVentasSunat(List<EmisionDocumentoE> oListaBaja, String RucEmisor = "", String Tipo = "", Int32 numFila = 0)
        {
            Int32 resp = Variables.Cero;
            Int32 reg = Variables.Cero;

            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (oListaBaja.Count > Variables.Cero)
                    {
                        numFila = 1;
 
                        foreach (EmisionDocumentoE item in oListaBaja)
                        {
                            if (Tipo == "CB" && numFila == 1) //Cabecera - Detalle
                            {
                                reg = new EmisionDocumentoAD().DarBajaDocumentosVentasSunat(item, "C", numFila, RucEmisor);
                            }

                            reg = new EmisionDocumentoAD().DarBajaDocumentosVentasSunat(item, "D", numFila, RucEmisor);  
                            new VoucherAD().AnularVoucher(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile, item.UsuarioModificacion, "A");
                            
                            resp += reg;
                            numFila++;
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

        public Int32 DarBajaDocumentosVentasSunat(List<EmisionDocumentoE> oListaBaja, Int32 idEmpresa, Int32 idLocal, String UsuarioModificacion, String Fecha)
        {
            try
            {
                Int32 Resp = 0;

                using (TransactionScope oTran = new TransactionScope())
                {
                    //Actualizando datos para la baja a los documento escogidos...
                    foreach (EmisionDocumentoE item in oListaBaja)
                    {
                        new EmisionDocumentoAD().ActualizarEstadoBaja(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento, item.MotivoAnulacion, item.UsuarioModificacion);
                    }

                    //Dando de baja a los documentos
                    Resp = new EmisionDocumentoAD().DarBajaDocumentosVentasSunat(idEmpresa, idLocal, UsuarioModificacion, Fecha);

                    //Terminando la transacción
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

        public Int32 InsertarFacturaElectronica(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String numLetra, String EsGuia, Int32 idPersona)
        {
            try
            {
                return new EmisionDocumentoAD().InsertarFacturaElectronica(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, numLetra, EsGuia, idPersona);
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

        public Int32 RecuperarEstadoSunat(List<EmisionDocumentoE> oListaDocumentos)
        {
            try
            {
                Int32 Reg = Variables.Cero;

                foreach (EmisionDocumentoE item in oListaDocumentos)
                {
                    new EmisionDocumentoAD().RecuperarEstadoSunat(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);
                    Reg++;
                }

                return Reg;
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

        public Int32 ResumenBoletas(Int32 idEmpresa, String Fecha, String Serie, String numDesde, String numHasta)
        {
            try
            {
                return new EmisionDocumentoAD().ResumenBoletas(idEmpresa, Fecha, Serie, numDesde, numHasta);
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

        public Int32 EliminarEmisDocuCompleto(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                #region Eliminando el movimiento en la CtaCte

                if ((idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString() ||
                    idDocumento == EnumTipoDocumentoVenta.NC.ToString() || idDocumento == EnumTipoDocumentoVenta.ND.ToString()))
                {
                    EmisionDocumentoE oDocumento = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                    if (oDocumento != null && oDocumento.indEstado == EnumEstadoDocumentos.B.ToString())
                    {
                        CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCte(idEmpresa, Convert.ToInt32(oDocumento.idPersona), idDocumento, numSerie, numDocumento, false);

                        if (oCtaCte != null)
                        {
                            List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                            if (oListaCtaCte.Count > 0)
                            {
                                throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine los movimientos antes de eliminar la factura.", idDocumento, numSerie, numDocumento));
                            }
                            else
                            {
                                // Eliminando el detalle
                                new CtaCte_DetAD().EliminarMaeCtaCteDetalle(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                                // Eliminando la cabecera
                                new CtaCteAD().EliminarMaeCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                            }
                        }
                    }
                }

                #endregion Eliminando el movimiento en la CtaCte

                return new EmisionDocumentoAD().EliminarEmisDocuCompleto(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public String FacturaElectronicaUrlPdf(String TipoDocumentoEmisor, String RucEmisor, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoAD().FacturaElectronicaUrlPdf(TipoDocumentoEmisor, RucEmisor, idDocumento, numSerie, numDocumento);
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

        public List<EmisionDocumentoE> ListarAnticipos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            try
            {
                List<EmisionDocumentoE> oListaAnticipos = new EmisionDocumentoAD().ListarAnticipos(idEmpresa, idLocal, idPersona);
                oListaAnticipos = (from x in oListaAnticipos where x.Saldo != 0 select x).ToList();

                return oListaAnticipos;
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

        public EmisionDocumentoE RecuperarGuiaCompleta(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                //Cabecera
                EmisionDocumentoE Documento = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                if (Documento == null)
                {
                    throw new Exception(String.Format("El documento {0} ingresado no existe.", idDocumento + " " + numSerie + "-" + numDocumento));
                }

                //Detalle
                Documento.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                foreach (EmisionDocumentoDetE item in Documento.ListaItemsDocumento)
                {
                    item.Cantidad -= item.CantFactura;

                    if (item.CantFactura > 0)
                    {
                        item.subTotal = Convert.ToDecimal(item.Cantidad) * item.PrecioSinImpuesto;
                        item.Igv = item.flgIgv == true ? item.subTotal * (item.porIgv / 100) : 0;
                        item.Total = item.subTotal + item.Igv;
                    }

                    item.CantidadFinal = item.Cantidad;
                }

                return Documento;
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

        public List<EmisionDocumentoE> ListarDocumentosCanje(List<EmisionDocumentoE> oListaDocumentos)
        {
            try
            {
                List<EmisionDocumentoE> oListRecuperada = new List<EmisionDocumentoE>();

                foreach (EmisionDocumentoE item in oListaDocumentos)
                {
                    //Cabecera
                    EmisionDocumentoE Documento = new EmisionDocumentoAD().ObtenerEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);

                    if (Documento == null)
                    {
                        throw new Exception(String.Format("El documento {0} ingresado no existe.", item.idDocumento + " " + item.numSerie + "-" + item.numDocumento));
                    }

                    //Detalle
                    Documento.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);
                    oListRecuperada.Add(Documento);
                }

                return oListRecuperada;
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

        public EmisionDocumentoE GrabarTicket(EmisionDocumentoE documento, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTran = new TransactionScope())
                {
                    venParametrosE oParametroVenta = new venParametrosAD().ObtenerVenParametros(documento.idEmpresa);

                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Insertar:

                            #region Insertar

                            #region Cliente cuando es nuevo y no esta en la BD

                            if (documento.idPersona == 0)
                            {
                                //Int32 tipPersona = Variables.Cero;
                                //Int32 tipDocPersona = Variables.Cero;
                                //Int32 Pais = Variables.Cero;
                                //ParTabla oParTabla = null;

                                //if (documento.idDocumento == "FV")
                                //{
                                //    #region Facturas

                                //    //Tipo de Persona
                                //    oParTabla = new ParTablaAD().ParTablaPorNemo("PERJU");

                                //    if (oParTabla != null)
                                //    {
                                //        tipPersona = oParTabla.IdParTabla;
                                //    }
                                //    else
                                //    {
                                //        throw new Exception("No esta configurado el Tipo de Persona Jurídico en Parámetros Generales");
                                //    }

                                //    //Tipo de documento de identidad
                                //    oParTabla = new ParTablaAD().ParTablaPorNemo("PERRUC");

                                //    if (oParTabla != null)
                                //    {
                                //        tipDocPersona = oParTabla.IdParTabla;
                                //    }
                                //    else
                                //    {
                                //        throw new Exception("No esta configurado el Tipo de Documento(RUC) en Parámetros Generales");
                                //    }

                                //    Pais = 90;

                                //    #endregion
                                //}
                                //else if (documento.idDocumento == "BV")
                                //{
                                //    #region Boletas

                                //    if (documento.numRuc.Trim().Length == Variables.NroCaracteresDNI)
                                //    {
                                //        #region DNI

                                //        //Tipo de Persona
                                //        oParTabla = new ParTablaAD().ParTablaPorNemo("PERSR");

                                //        if (oParTabla != null)
                                //        {
                                //            tipPersona = oParTabla.IdParTabla;
                                //        }
                                //        else
                                //        {
                                //            throw new Exception("No esta configurado el Tipo de Persona Natural en Parámetros Generales");
                                //        }

                                //        //Tipo de documento de identidad
                                //        oParTabla = new ParTablaAD().ParTablaPorNemo("PERDNI");

                                //        if (oParTabla != null)
                                //        {
                                //            tipDocPersona = oParTabla.IdParTabla;
                                //        }
                                //        else
                                //        {
                                //            throw new Exception("No esta configurado el Tipo de Documento(DNI) en Parámetros Generales");
                                //        }

                                //        Pais = 90;

                                //        #endregion
                                //    }
                                //    else
                                //    {
                                //        #region Otros

                                //        oParTabla = new ParTablaAD().ParTablaPorNemo("OTR");

                                //        if (oParTabla != null)
                                //        {
                                //            tipPersona = oParTabla.IdParTabla;
                                //        }
                                //        else
                                //        {
                                //            throw new Exception("No esta configurado el Tipo de Persona Otros en Parámetros Generales");
                                //        }

                                //        //Tipo de documento de identidad
                                //        oParTabla = new ParTablaAD().ParTablaPorNemo("PEROTR");

                                //        if (oParTabla != null)
                                //        {
                                //            tipDocPersona = oParTabla.IdParTabla;
                                //        }
                                //        else
                                //        {
                                //            throw new Exception("No esta configurado el Tipo de Documento(Otros) en Parámetros Generales");
                                //        }

                                //        Pais = 0;

                                //        #endregion
                                //    }

                                //    #endregion
                                //}
                                //else
                                //{
                                //    throw new Exception("Documento no autorizado para el Punto de Venta.");
                                //}

                                ////Insertando la Persona
                                //Persona oPersona = new Persona()
                                //{
                                //    TipoPersona = tipPersona,
                                //    RazonSocial = documento.RazonSocial,
                                //    RUC = documento.numRuc,
                                //    ApePaterno = String.Empty,
                                //    ApeMaterno = String.Empty,
                                //    Nombres = String.Empty,
                                //    TipoDocumento = tipDocPersona,
                                //    NroDocumento = documento.numRuc,
                                //    Telefonos = String.Empty,
                                //    Fax = String.Empty,
                                //    Correo = String.Empty,
                                //    Web = String.Empty,
                                //    DireccionCompleta = documento.Direccion,
                                //    idPais = Pais, //Peru
                                //    idUbigeo = String.Empty,
                                //    PrincipalContribuyente = false,
                                //    AgenteRetenedor = false,
                                //    idCanalVenta = documento.idCanalVenta,
                                //    UsuarioRegistro = documento.UsuarioRegistro
                                //};

                                //oPersona = new PersonaAD().InsertarPersona(oPersona);
                                //documento.idPersona = oPersona.IdPersona; //Actualizando el IdPersona cuando son nuevos clientes...

                                ////Tipo de Cliente
                                //oParTabla = new ParTablaAD().ParTablaPorNemo("TIPCLINOR");

                                //if (oParTabla != null)
                                //{
                                //    //Insertando el Cliente
                                //    ClienteE oCliente = new ClienteE()
                                //    {
                                //        idPersona = oPersona.IdPersona,
                                //        idEmpresa = documento.idEmpresa,
                                //        SiglaComercial = documento.RazonSocial,
                                //        TipoCliente = oParTabla.IdParTabla,
                                //        fecInscripcion = null,
                                //        fecInicioEmpresa = null,
                                //        tipConstitucion = null,
                                //        tipRegimen = null,
                                //        catCliente = null,
                                //        indEstado = false,
                                //        fecBaja = null,
                                //        UsuarioRegistro = documento.UsuarioRegistro
                                //    };

                                //    new ClienteAD().InsertarCliente(oCliente);
                                //}
                                //else
                                //{
                                //    throw new Exception("No esta configurado el Tipo de Cliente(Normal) en Parámetros Generales");
                                //}
                            }

                            #endregion

                            //Insertando el nuevo documento...
                            documento = new EmisionDocumentoAD().InsertarEmisionDocumento(documento);

                            #region Items Resumido

                            if (documento.ListaItemsDocumento != null && documento.ListaItemsDocumento.Count > 0)
                            {
                                foreach (EmisionDocumentoDetE item in documento.ListaItemsDocumento)
                                {
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumento = documento.idDocumento;
                                    item.numSerie = documento.numSerie;
                                    item.numDocumento = documento.numDocumento;

                                    new EmisionDocumentoDetAD().InsertarEmisionDocumentoDet(item);

                                    UMedidaE desCorta = new UMedidaAD().ObtenerUMedida(item.idUnidadMedida.Value);

                                    if (desCorta != null)
                                    {
                                        item.desUMedidaCorta = desCorta.NomUMedidaCorto;
                                    }
                                }
                            }

                            #endregion

                            #region Items Detallado

                            if (documento.ListaItemsDetallado != null && documento.ListaItemsDetallado.Count > 0)
                            {
                                int Correlativo = 1;

                                foreach (EmisionDocumentoDetDetalleE item in documento.ListaItemsDetallado)
                                {
                                    item.Item = string.Format("{0:000}", Correlativo);
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumento = documento.idDocumento;
                                    item.numSerie = documento.numSerie;
                                    item.numDocumento = documento.numDocumento;

                                    new EmisionDocumentoDetAD().InsertarEmisionDocumentoDetallado(item);
                                    Correlativo++;
                                }
                            }

                            #endregion

                            #region Cancelaciones con medio de pago

                            if (documento.ListaCancelaciones != null && documento.ListaCancelaciones.Count > 0)
                            {
                                foreach (EmisionDocumentoCancelacionE item in documento.ListaCancelaciones)
                                {
                                    new EmisionDocumentoCancelacionAD().InsertarEmisionDocumentoCancelacion(item);
                                }
                            }

                            #endregion

                            //Actualizando Correlativo del documento en numControlDet
                            new NumControlDetAD().ActualizarCorrelativoNumControlDet(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                            #region Generando Voucher Automático

                            if (oParametroVenta != null && oParametroVenta.GeneraAsiento)
                            {
                                new VoucherAD().GeneraAsientoVenta(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, documento.UsuarioRegistro);
                            }

                            #endregion Generando Voucher Automático

                            #region Factura Electrónica

                            //if (documento.EnvioFE)
                            //{
                            //    String numLetras = NumeroLetras.enLetras(documento.totTotal.ToString());

                            //    new EmisionDocumentoAD().InsertarFacturaElectronica(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, numLetras, documento.EsGuia, documento.idPersona.Value);
                            //}

                            #endregion

                            //Cerrando el Pedido
                            new PedidoCabAD().CerrarPedido(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado), "F"); //cambiar el pedido a facturado

                            //Actualizando los datos de la factura en el Pedido
                            PedidoCabE pedido = new PedidoCabE()
                            {
                                idEmpresa = documento.idEmpresa,
                                idLocal = documento.idLocal,
                                idPedido = Convert.ToInt32(documento.nroDocAsociado),
                                NroGuia = string.Empty,
                                nroFactura = documento.numSerie + "-" + documento.numDocumento,
                                FecFactura = documento.fecEmision,
                                UsuarioModificacion = documento.UsuarioRegistro
                            };

                            new PedidoCabAD().ActualizarDocumentosPed(pedido);

                            #region Verificación del stock

                            string Mes = documento.fecEmision.Substring(4, 2);
                            string Anio = documento.fecEmision.Substring(0, 4);
                            StockE oStock = null;

                            foreach (EmisionDocumentoDetDetalleE item in documento.ListaItemsDetallado)
                            {
                                if (String.IsNullOrEmpty(item.Lote.Trim()))
                                {
                                    item.Lote = "0000000";
                                }

                                if (item.idAlmacen > 0)
                                {
                                    AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));

                                    if (oAlmacen != null)
                                    {
                                        if (oAlmacen.VerificaStock)
                                        {
                                            if (oAlmacen.VerificaLote)
                                            {
                                                oStock = new StockAD().ObtenerStockActual(item.idEmpresa, Convert.ToInt32(item.idAlmacen), item.idTipoArticulo, Convert.ToInt32(item.idArticulo), Anio, Mes, true, item.Lote);
                                            }
                                            else
                                            {
                                                oStock = new StockAD().ObtenerStockActual(item.idEmpresa, Convert.ToInt32(item.idAlmacen), item.idTipoArticulo, Convert.ToInt32(item.idArticulo), Anio, Mes, false, "");
                                            }

                                            if (oStock == null)
                                            {
                                                throw new Exception(String.Format("El stock del articulo con código {0} y Lote {1} No Existe !!!.", item.codArticulo, item.Lote));
                                            }

                                            if (oStock.EsComprometido)
                                            {
                                                if (oStock.canStock < item.CantidadFinal)// + item.Cantidad < item.Cantidad)
                                                {
                                                    throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                                }
                                            }
                                            else
                                            {
                                                if (oStock.canStock < item.CantidadFinal)
                                                {
                                                    throw new Exception(String.Format("El stock del articulo con código {0} se ha actualizado, no tiene suficiente stock.", item.codArticulo));
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion

                            Int32 idTipMovSalida = Variables.Cero;
                            Int32 idOperacion = Variables.Cero;
                            MovimientoAlmacenE oMovimientoAlmacen = null;
                            MovimientoAlmacenItemE oItemMovimiento = null;
                            Int16 numItem = 1;
                            ParTabla parEgreso = new ParTablaAD().ParTablaPorNemo("EGR");

                            if (parEgreso == null)
                            {
                                throw new Exception("No existe Tipos de Movimientos para los Egresos.");
                            }
                            else
                            {
                                idTipMovSalida = parEgreso.IdParTabla;
                            }

                            List<OperacionE> oListaOperaciones = null;
                            //Agrupando por almacen para saber si todo va a un almacen o varios....
                            var ListarDocumentosDetTmp = documento.ListaItemsDetallado.GroupBy(x => x.idAlmacen).Select(p => p.First()).ToList();

                            #region Movimiento Almacen

                            Decimal SubTotal = 0;
                            Decimal ImpuestoIgv = 0;
                            Decimal Total = 0;

                            foreach (var item in ListarDocumentosDetTmp)
                            {
                                if (item.idAlmacen > 0)
                                {
                                    List<EmisionDocumentoDetDetalleE> oListaTmpDetallePorAlmacen = new List<EmisionDocumentoDetDetalleE>((from x in documento.ListaItemsDetallado
                                                                                                                                          where x.idAlmacen == item.idAlmacen
                                                                                                                                          select x).ToList());
                                    if (oListaTmpDetallePorAlmacen.Count > 0)
                                    {
                                        SubTotal = oListaTmpDetallePorAlmacen.Sum(x => x.subTotal);
                                        ImpuestoIgv = oListaTmpDetallePorAlmacen.Sum(x => x.Igv);
                                        Total = oListaTmpDetallePorAlmacen.Sum(x => x.Total);

                                        #region Cabecera

                                        AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));
                                        oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), documento.idEmpresa, idTipMovSalida);

                                        OperacionE Operacion = oListaOperaciones.Find
                                        (
                                            delegate (OperacionE op) { return op.codSunat == "01"; }
                                        );

                                        if (Operacion == null)
                                        {
                                            throw new Exception("No existe Tipos de Operacion.");
                                        }
                                        else
                                        {
                                            idOperacion = Operacion.idOperacion;
                                        }

                                        oMovimientoAlmacen = new MovimientoAlmacenE()
                                        {
                                            idEmpresa = documento.idEmpresa,
                                            tipMovimiento = idTipMovSalida,
                                            idAlmacen = Convert.ToInt32(item.idAlmacen),
                                            tipAlmacen = Convert.ToInt32(oAlmacen.tipAlmacen),
                                            idOperacion = idOperacion,
                                            fecProceso = documento.fecEmision,
                                            fecDocumento = documento.fecEmision,
                                            idDocumento = documento.idDocumento,
                                            serDocumento = documento.numSerie,
                                            numDocumento = documento.numDocumento,
                                            idDocumentoRef = string.Empty,
                                            SerieDocumentoRef = string.Empty,
                                            NumeroDocumentoRef = string.Empty,
                                            idPersona = Convert.ToInt32(documento.idPersona),
                                            idMoneda = documento.idMoneda,
                                            indCambio = true,
                                            tipCambio = Convert.ToDecimal(documento.tipCambio),
                                            impValorVenta = SubTotal,
                                            Impuesto = ImpuestoIgv,
                                            impTotal = Total,
                                            indPorAsociar = false,
                                            idAlmacenDestino = 0,
                                            tipMovimientoAsociado = null,
                                            idDocumentoAlmacenAsociado = null,
                                            numRequisicion = string.Empty,
                                            Glosa = documento.Glosa,
                                            indAutomatico = true,
                                            UsuarioRegistro = documento.UsuarioRegistro
                                        };

                                        #endregion

                                        #region Detalle

                                        //decimal cantidad = 0;

                                        foreach (EmisionDocumentoDetDetalleE itemDetalle in oListaTmpDetallePorAlmacen)
                                        {
                                            if (String.IsNullOrEmpty(itemDetalle.Lote.Trim()))
                                            {
                                                itemDetalle.Lote = "0000000";
                                            }

                                            //ArticuloServE articulo = new ArticuloServAD().ObtenerArticuloServ(documento.idEmpresa, itemDetalle.idArticulo.Value);
                                            //cantidad = itemDetalle.Cantidad;

                                            //if (articulo != null)
                                            //{
                                            //    if (itemDetalle.idUnidadMedida != articulo.codUniMedAlmacen)
                                            //    {
                                            //        cantidad = itemDetalle.Cantidad / (articulo.Contenido > 0 ? articulo.Contenido : 1);
                                            //    }
                                            //}

                                            oItemMovimiento = new MovimientoAlmacenItemE()
                                            {
                                                idEmpresa = oMovimientoAlmacen.idEmpresa,
                                                tipMovimiento = oMovimientoAlmacen.tipMovimiento,
                                                idDocumentoAlmacen = oMovimientoAlmacen.idDocumentoAlmacen,
                                                numItem = String.Format("{0:0000}", numItem),
                                                idArticulo = Convert.ToInt32(itemDetalle.idArticulo),
                                                Lote = itemDetalle.Lote,
                                                idUbicacion = Variables.Cero,
                                                Cantidad = itemDetalle.CantidadFinal, //cantidad,
                                                ImpCostoUnitarioBase = Variables.Cero,
                                                ImpCostoUnitarioRefe = Variables.Cero,
                                                ImpTotalBase = Variables.Cero,
                                                ImpTotalRefe = Variables.Cero,
                                                indCalidad = false,
                                                indConformidad = false,
                                                idCCostos = String.Empty,
                                                idCCostosUso = String.Empty,
                                                idArticuloUso = Variables.Cero,
                                                nroEnvases = Variables.Cero,
                                                Valorizado = false,
                                                nroParteProd = String.Empty,
                                                idItemCompra = 0,
                                                UsuarioRegistro = documento.UsuarioRegistro
                                            };

                                            oMovimientoAlmacen.ListaAlmacenItem.Add(oItemMovimiento);
                                            numItem++;
                                        }

                                        #endregion

                                        //Guardando el movimiento de salida en el almacen...
                                        oMovimientoAlmacen = new MovimientoAlmacenLN().GuardarMovimientoAlmacen(oMovimientoAlmacen, EnumOpcionGrabar.Insertar);
                                        //Actualizando el Nro. de documento de almacen...
                                        foreach (EmisionDocumentoDetDetalleE itemTemp in oListaTmpDetallePorAlmacen)
                                        {
                                            new EmisionDocumentoDetAD().UpdateVenEmiDetalladoDocAlmacen(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, itemTemp.Item,
                                                                                                    Convert.ToInt32(itemTemp.idAlmacen), oMovimientoAlmacen.idDocumentoAlmacen, documento.UsuarioRegistro);
                                        }
                                    } 
                                }
                            }

                            #endregion

                            #endregion Insertar

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            #region Actualizar

                            Int32 resp = Variables.Cero;
                            //EmisionDocumentoE docTemp = new EmisionDocumentoAD().ObtenerEmisionDocumento(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                            //Actualizar la Cabecera...
                            documento = new EmisionDocumentoAD().ActualizarEmisionDocumento(documento);

                            #region Actualizando el detalle

                            if (documento.ListaItemsDocumento.Count > Variables.Cero && documento.ListaItemsDocumento != null)
                            {
                                resp = new EmisionDocumentoDetAD().EliminarEmisionDocumentoDet(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento);

                                foreach (EmisionDocumentoDetE item in documento.ListaItemsDocumento)
                                {
                                    item.idEmpresa = documento.idEmpresa;
                                    item.idLocal = documento.idLocal;
                                    item.idDocumento = documento.idDocumento;
                                    item.numSerie = documento.numSerie;
                                    item.numDocumento = documento.numDocumento;

                                    //Insertar
                                    new EmisionDocumentoDetAD().InsertarEmisionDocumentoDet(item);
                                }
                            }

                            #endregion

                            #region Generando Voucher Automático

                            //if (documento.indVoucher)
                            //{
                            //    if (oParametroVenta != null && oParametroVenta.GeneraAsiento)
                            //    {

                            //        new VoucherAD().GeneraAsientoVenta(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, documento.UsuarioRegistro);
                            //    }    
                            //}

                            #endregion Generando Voucher Automático

                            #endregion

                            break;
                        default:
                            break;
                    }

                    oTran.Complete();
                }

                return documento;
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

        public bool AnularTicket(EmisionDocumentoE documento, string EliminarPedido, string Usuario)
        {
            try
            {
                using (TransactionScope oTran = new TransactionScope())
                {
                    #region Movimientos de Almacén

                    //Revisando si existe el Tipo de movimiento de salida
                    int idMovimientoSal = 0;
                    ParTabla oTipoMovimiento = new ParTablaAD().ParTablaPorNemo("EGR");

                    if (oTipoMovimiento != null)
                    {
                        idMovimientoSal = oTipoMovimiento.IdParTabla;
                    }
                    else
                    {
                        throw new Exception("No existe Tipo de Movimiento para los Egresos.");
                    }

                    //Agrupando por almacen para saber si todo va a un almacen o varios....
                    var ListarDocumentosDetTmp = documento.ListaItemsDetallado.GroupBy(x => x.idAlmacen).Select(p => p.First()).ToList();
                    List<OperacionE> oListaOperaciones = null;
                    int idOpe = 0;

                    foreach (var item in ListarDocumentosDetTmp)
                    {
                        List<EmisionDocumentoDetDetalleE> oListaTmpDetallePorAlmacen = new List<EmisionDocumentoDetDetalleE>((from x in documento.ListaItemsDetallado
                                                                                                                              where x.idAlmacen == item.idAlmacen
                                                                                                                              select x).ToList());
                        if (oListaTmpDetallePorAlmacen.Count > 0)
                        {
                            AlmacenE oAlmacen = new AlmacenAD().ObtenerAlmacen(item.idEmpresa, Convert.ToInt32(item.idAlmacen));
                            oListaOperaciones = new OperacionAD().ListarOperacionPorTipoArticulo(Convert.ToInt32(oAlmacen.tipAlmacen), documento.idEmpresa, idMovimientoSal);

                            OperacionE Operacion = oListaOperaciones.Find
                            (
                                delegate (OperacionE op) { return op.codSunat == "01"; } //Código de Sunat de Ventas
                            );

                            if (Operacion == null)
                            {
                                throw new Exception("No existe Tipos de Operación para la salida de articulos.");
                            }
                            else
                            {
                                idOpe = Operacion.idOperacion;
                            }

                            foreach (EmisionDocumentoDetDetalleE itemDetalle in oListaTmpDetallePorAlmacen)
                            {
                                //Anulando el documento
                                new MovimientoAlmacenAD().AnularMovimientoAlmacen(documento.idEmpresa, idMovimientoSal, Convert.ToInt32(itemDetalle.DocumentoAlmacen), Usuario);

                                //Actualizando el stock en almacen
                                string AnioPeriodo = Convert.ToDateTime(documento.fecEmision).ToString("yyyy"); //Año del movimiento
                                string MesPeriodo = Convert.ToDateTime(documento.fecEmision).ToString("MM"); //Mes del movimiento
                                int idAlmacen = Convert.ToInt32(itemDetalle.idAlmacen);                    //Código de almacén
                                decimal CantMovimiento = itemDetalle.CantidadFinal;                      //Cantidad final

                                //Actualizar Stock
                                new AlmacenArticuloLoteAD().ActualizarStockValorizado(documento.idEmpresa, AnioPeriodo, MesPeriodo, idAlmacen, idOpe, itemDetalle.idArticulo.Value, itemDetalle.Lote, CantMovimiento, 0M, 0M, "AN");
                            }
                        }
                    }

                    #endregion

                    #region Pedido

                    if (documento.nroDocAsociado == null)
                    {
                        documento.nroDocAsociado = 0;
                    }

                    if (documento.nroDocAsociado > 0)
                    {
                        if (EliminarPedido == "S")
                        {
                            new PedidoCabAD().EliminarTodoPedido(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado), documento.idLocal);
                        }
                        else
                        {
                            ////Actualizando los datos de factura en el Pedido
                            //new PedidoCabAD().ActualizarDocumentosPed(new PedidoCabE()
                            //{
                            //    idEmpresa = documento.idEmpresa,
                            //    idLocal = documento.idLocal,
                            //    idPedido = Convert.ToInt32(documento.nroDocAsociado),
                            //    NroGuia = string.Empty,
                            //    nroFactura = string.Empty,
                            //    FecFactura = null,
                            //    UsuarioModificacion = Usuario
                            //});

                            //Poner el Pedido al estado A
                            new PedidoCabAD().CerrarPedido(documento.idEmpresa, Convert.ToInt32(documento.nroDocAsociado), "A"); //Anulado
                        }
                    }

                    #endregion

                    //Anulando el documento de venta... Factura... Boleta...
                    new EmisionDocumentoAD().CambiarEstadoDocumento(documento.idEmpresa, documento.idLocal, documento.idDocumento, documento.numSerie, documento.numDocumento, "B");

                    //Transacción completa!!
                    oTran.Complete();
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

        public List<EmisionDocumentoE> ListaDocVentasParaSunat(String Tipo, Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, bool EnviadoSunat, bool AnuladoSunat)
        {
            try
            {
                List<EmisionDocumentoE> ListaDevuelta = null;

                if (Tipo == "RESU")
                {
                    ListaDevuelta = new EmisionDocumentoAD().ListaDocVentasParaSunat(idEmpresa, idLocal, "BV", fecIni, fecFin, EnviadoSunat, AnuladoSunat);
                }
                else
                {
                    ListaDevuelta = new List<EmisionDocumentoE>();
                    List<EmisionDocumentoE> ListaAnulados = new EmisionDocumentoAD().ListaDocVentasParaSunat(idEmpresa, idLocal, "BV", fecIni, fecFin, EnviadoSunat, AnuladoSunat);
                    ListaDevuelta.AddRange(ListaAnulados);
                    ListaAnulados = new EmisionDocumentoAD().ListaDocVentasParaSunat(idEmpresa, idLocal, "FV", fecIni, fecFin, EnviadoSunat, AnuladoSunat);
                    ListaDevuelta.AddRange(ListaAnulados);
                }

                return ListaDevuelta;
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

        public List<EmisionDocumentoE> ListarReporteVentasDetallada(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente, Int32 idEstablecimiento, Int16 Reporte)
        {
            try
            {
                List<EmisionDocumentoE> ListarReporteDevuelta = null;
                List<EmisionDocumentoE> ListaTmp = null; 
                EmisionDocumentoE itemDscto = null;
                Int32 numItem = 0;
                Decimal Igv = 0;
                Decimal Total = 0;

                if (Reporte == 1)
                {
                    ListarReporteDevuelta = new EmisionDocumentoAD().ListarReporteVentasDetallada(idEmpresa, idLocal, fecIni, fecFin, idVendedor, idCliente, idEstablecimiento);
                }
                else
                {
                    ListarReporteDevuelta = new EmisionDocumentoAD().ListarReporteVentasDetallada2(idEmpresa, idLocal, fecIni, fecFin, idVendedor, idCliente, idEstablecimiento);
                }

                ListaTmp = new List<EmisionDocumentoE>(ListarReporteDevuelta);

                foreach (EmisionDocumentoE item in ListaTmp)
                {
                    if (item.porDscto > 0 && item.Item == "001")
                    {
                        itemDscto = Colecciones.CopiarEntidad<EmisionDocumentoE>(item);
                        itemDscto.nomArticulo = item.Glosa;
                        itemDscto.Cantidad = 1M;
                        numItem = Convert.ToInt32((from x in ListarReporteDevuelta
                                                   where x.idDocumento == item.idDocumento
                                                   && x.numSerie == item.numSerie
                                                   && x.numDocumento == item.numDocumento
                                                   && x.Ruc == item.Ruc
                                                   select x.Item).Max());
                        numItem += 1;
                        itemDscto.Item = String.Format("{0:000}", numItem);

                        if (itemDscto.idMoneda == "01")
                        {
                            itemDscto.subTotalSol = item.DsctoGlobal.Value * -1;

                            if (numItem > 2)
                            {
                                Igv = Convert.ToDecimal((from x in ListarReporteDevuelta
                                                         where x.idDocumento == item.idDocumento
                                                         && x.numSerie == item.numSerie
                                                         && x.numDocumento == item.numDocumento
                                                         && x.Ruc == item.Ruc
                                                         select x.IgvSol).Sum());

                                Total = Convert.ToDecimal((from x in ListarReporteDevuelta
                                                           where x.idDocumento == item.idDocumento
                                                           && x.numSerie == item.numSerie
                                                           && x.numDocumento == item.numDocumento
                                                           && x.Ruc == item.Ruc
                                                           select x.TotalS).Sum());
                            }
                            else
                            {
                                Igv = itemDscto.IgvSol;
                                Total = itemDscto.TotalS;
                            }

                            if (Igv > 0)
                            {
                                itemDscto.IgvSol = Igv * (item.porDscto.Value / 100);
                            }
                            else
                            {
                                itemDscto.IgvSol = 0M;
                            }

                            itemDscto.TotalS = (Total * (item.porDscto.Value / 100)) * -1;
                        }
                        else
                        {
                            itemDscto.subTotalDol = item.DsctoGlobal.Value * -1;

                            if (numItem > 2)
                            {
                                Igv = Convert.ToDecimal((from x in ListarReporteDevuelta
                                                         where x.idDocumento == item.idDocumento
                                                         && x.numSerie == item.numSerie
                                                         && x.numDocumento == item.numDocumento
                                                         && x.Ruc == item.Ruc
                                                         select x.IgvDol).Sum());

                                Total = Convert.ToDecimal((from x in ListarReporteDevuelta
                                                           where x.idDocumento == item.idDocumento
                                                           && x.numSerie == item.numSerie
                                                           && x.numDocumento == item.numDocumento
                                                           && x.Ruc == item.Ruc
                                                           select x.TotalD).Sum());
                            }
                            else
                            {
                                Igv = itemDscto.IgvDol;
                                Total = itemDscto.TotalD;
                            }

                            if (Igv > 0)
                            {
                                itemDscto.IgvDol = (Igv * (item.porDscto.Value / 100)) * -1;
                            }
                            else
                            {
                                itemDscto.IgvDol = 0M;
                            }

                            itemDscto.TotalD = (Total * (item.porDscto.Value / 100)) * -1;
                        }

                        ListarReporteDevuelta.Add(itemDscto);
                    }
                }

                return (from x in ListarReporteDevuelta orderby x.idDocumento, x.numSerie, x.numDocumento, x.Item select x).ToList(); ;
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

        public List<EmisionDocumentoE> ListarReporteVentasDetalladaOT(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, Int32 idVendedor, Int32 idCliente)
        {
            try
            {
                return new EmisionDocumentoAD().ListarReporteVentasDetalladaOT(idEmpresa, idLocal, fecIni, fecFin, idVendedor, idCliente);
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

        public List<EmisionDocumentoE> ReporteMensualVentasResumida(Int32 idEmpresa, Int32 idLocal, String Anio, String MesIni, String MesFin, String idMoneda, Int32 idPersona)
        {
            try
            {
                return new EmisionDocumentoAD().ReporteMensualVentasResumida(idEmpresa, idLocal, Anio, MesIni, MesFin, idMoneda, idPersona);
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

        public Int32 EliminarVoucherEmiDoc(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero, String Usuario)
        {
            try
            {
                return new EmisionDocumentoAD().EliminarVoucherEmiDoc(idEmpresa, idLocal, TipoDocu, Serie, Numero, Usuario);
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

        public EmisionDocumentoE GenerarVoucherEmiDoc(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero, String Usuario)
        {
            try
            {
                return new EmisionDocumentoAD().GenerarVoucherEmiDoc(idEmpresa,idLocal, TipoDocu, Serie, Numero, Usuario);
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

        public Int32 IngresarDocCtaCte(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String Usuario)
        {
            try
            {
                int resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    EmisionDocumentoE DocumentoTmp = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                    if (DocumentoTmp != null)
                    {
                        #region CtaCte

                        if (DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() ||
                            DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString() || DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.ND.ToString())
                        {
                            ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                            String Cuenta = String.Empty;

                            if (DocumentoTmp.idMoneda == Variables.Soles)
                            {
                                Cuenta = oParametroConta.VentaS;
                            }
                            else
                            {
                                Cuenta = oParametroConta.VentaD;
                            }

                            if (String.IsNullOrWhiteSpace(Cuenta))
                            {
                                throw new Exception("Falta configurar las cuentas para ventas en Parámetros Contables.");
                            }

                            #region Cabecera

                            CtaCteE oCtaCte = new CtaCteE
                            {
                                idEmpresa = DocumentoTmp.idEmpresa,
                                idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                                idDocumento = DocumentoTmp.idDocumento,
                                numSerie = DocumentoTmp.numSerie,
                                numDocumento = DocumentoTmp.numDocumento,
                                idMoneda = DocumentoTmp.idMoneda,
                                MontoOrig = Convert.ToDecimal(DocumentoTmp.totTotal),
                                TipoCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                FechaDocumento = Convert.ToDateTime(DocumentoTmp.fecEmision),
                                FechaVencimiento = Convert.ToDateTime(DocumentoTmp.fecVencimiento),
                                FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                numVerPlanCuentas = oParametroConta.numVerPlanCuentas,
                                codCuenta = Cuenta,
                                AnnoVencimiento = String.Empty,
                                MesVencimiento = String.Empty,
                                SemanaVencimiento = String.Empty,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                desGlosa = DocumentoTmp.Glosa,
                                FechaOperacion = Convert.ToDateTime(DocumentoTmp.fecEmision),
                                EsDetraCab = false,
                                idCtaCteOrigen = 0,
                                idSistema = 2,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                            #endregion

                            #region Detalle

                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                            {
                                idEmpresa = DocumentoTmp.idEmpresa,
                                idCtaCte = oCtaCte.idCtaCte,
                                idDocumentoMov = DocumentoTmp.idDocumento,
                                SerieMov = DocumentoTmp.numSerie,
                                NumeroMov = DocumentoTmp.numDocumento,
                                FechaMovimiento = Convert.ToDateTime(DocumentoTmp.fecEmision),
                                idMoneda = DocumentoTmp.idMoneda,
                                MontoMov = Convert.ToDecimal(DocumentoTmp.totTotal),
                                TipoCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                                TipAccion = EnumEstadoDocumentos.C.ToString(),
                                numVerPlanCuentas = oParametroConta.numVerPlanCuentas,
                                codCuenta = Cuenta,
                                desGlosa = DocumentoTmp.Glosa,
                                EsDetraccion = false,
                                UsuarioRegistro = Usuario
                            };

                            new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                            #endregion
                        }

                        #endregion CtaCte
                    }

                    resp = 1;

                    //Transaccion completada...
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

        public List<EmisionDocumentoE> ComparativoVentasMulti(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda, Int32 TipoRep, Int32 TipoPresentacion)
        {
            try
            {
                return new EmisionDocumentoAD().ComparativoVentasMulti(idEmpresa, idLocal, fecIni, fecFin, idMoneda, TipoRep, TipoPresentacion);
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

        public List<EmisionDocumentoE> ComparativoVentasVsPresupuesto(Int32 idEmpresa, Int32 idLocal, string fecIni, string fecFin, String idMoneda, Int32 TipoRep, Int32 TipoPresentacion)
        {
            try
            {
                return new EmisionDocumentoAD().ComparativoVentasVsPresupuesto(idEmpresa, idLocal, fecIni, fecFin, idMoneda, TipoRep, TipoPresentacion);
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

        public Int32 EliminarAnticipoAnulados(EmisionDocumentoE oDocAnulado)
        {
            try
            {
                Int32 resp = 0;

                List<AnticiposE> ListaAnticipos = new AnticiposAD().AnticiposPorDocAnticipo(oDocAnulado.idEmpresa, oDocAnulado.idLocal, oDocAnulado.idDocumento, oDocAnulado.numSerie, oDocAnulado.numDocumento);

                //Eliminando los anticipos si hubiese...
                if (ListaAnticipos != null)
                {
                    if (ListaAnticipos.Count > 1)
                    {
                        throw new Exception("No se puede anular el Anticipo porque ya tiene aplicaciones. Anule primero las aplicaciones y luego el Anticipo.");
                    }

                    resp = new AnticiposAD().EliminarAnticipos(oDocAnulado.idEmpresa, oDocAnulado.idLocal, oDocAnulado.idDocumento, oDocAnulado.numSerie, oDocAnulado.numDocumento, oDocAnulado.idPersona.Value);
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

        public List<EmisionDocumentoE> ListarDetraccionCabEmisDocu(Int32 idEmpresa)
        {
            try
            {
                return new EmisionDocumentoAD().ListarDetraccionCabEmisDocu(idEmpresa);
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

        public Int32 ActualizarDetraccionDetEmisDocu(List<EmisionDocumentoE> oListaDocumentos)
        {
            try
            {
                Int32 resp = 0;
                EmisionDocumentoDetE oDetalle = null;

                using (TransactionScope oTran = new TransactionScope())
                {
                    foreach (EmisionDocumentoE item in oListaDocumentos)
                    {
                        oDetalle = new EmisionDocumentoDetE()
                        {
                            idEmpresa = item.idEmpresa,
                            idLocal = item.idLocal,
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            Item = item.Item,
                            tipDetraccion = item.tipDetraArt,
                            TasaDetraccion = item.porDetraArt,
                            UsuarioModificacion = item.UsuarioModificacion
                        };

                        new EmisionDocumentoDetAD().ActualizarDetraccionDetEmisDocu(oDetalle);

                        resp++;
                    }

                    oTran.Complete();
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

        public Int32 ActualizarDetraccionCabEmisDocu(List<EmisionDocumentoE> oListaDocumentos)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTran = new TransactionScope())
                {
                    foreach (EmisionDocumentoE item in oListaDocumentos)
                    {
                        //oDetalle = new EmisionDocumentoDetE()
                        //{
                        //    idEmpresa = item.idEmpresa,
                        //    idLocal = item.idLocal,
                        //    idDocumento = item.idDocumento,
                        //    numSerie = item.numSerie,
                        //    numDocumento = item.numDocumento,
                        //    Item = item.Item,
                        //    tipDetraccion = item.tipDetraArt,
                        //    TasaDetraccion = item.porDetraArt,
                        //    UsuarioModificacion = item.UsuarioModificacion
                        //};

                        new EmisionDocumentoAD().ActualizarDetraccionCabEmisDocu(item);

                        resp++;
                    }

                    oTran.Complete();
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

        public List<EmisionDocumentoE> ListarVentasAutoDetracciones(Int32 idEmpresa, string fecIni, string fecFin)
        {
            try
            {
                return new EmisionDocumentoAD().ListarVentasAutoDetracciones(idEmpresa, fecIni, fecFin);
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

        public Int32 GenerarOpVentasDetracciones(List<EmisionDocumentoE> oListaVentasDetra, Int32 idEmpresa, String Usuario)
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
                        delegate (TipoPagoDetE t) { return t.desConcepto.ToUpper().Contains("AUTO"); }
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
                        idLocal = oListaVentasDetra[0].idLocal,
                        codOrdenPago = String.Empty,
                        codTipoPago = oTipoPago.codTipoPago,
                        idConcepto = Convert.ToInt32(oTipoPagoDet.idConcepto),
                        codFormaPago = "009",
                        Fecha = oListaVentasDetra[0].fecOrdenPago.Date,
                        idPersona = null,
                        idPersonaBeneficiario = null,
                        idMoneda = "0",
                        Monto = 0,
                        Glosa = String.Empty,
                        VieneDe = "A", //Autodetracciones
                        UsuarioRegistro = Usuario
                    };

                    #endregion

                    #region Detalle de la OP

                    Int32? idBanco = null;
                    Int32? tipCuentaBanco = null;
                    String idMonedaBanco = String.Empty;
                    String numCuentaBancaria = String.Empty;

                    foreach (EmisionDocumentoE item in oListaVentasDetra)
                    {
                        OrdenPagoDetE PagoDetalle = null;

                        if (String.IsNullOrWhiteSpace(item.numVerPlanCuentas) || String.IsNullOrWhiteSpace(item.codCuenta))
                        {
                            throw new Exception("Falta la cuenta contable de AutoDetracción.");
                        }

                        if (oFormaPago.indDatosBancoAuxi)
                        {
                            BancosCuentasE oBancoCuenta = new BancosCuentasAD().ObtenerBancosPorNroCuenta(idEmpresa, item.numCuentaDetraccion);

                            if (oBancoCuenta == null)
                            {
                                throw new Exception(String.Format("No existen datos bancarios con el N° de cuenta {0}. No podrá generar la O.P.", item.numCuentaDetraccion));
                            }

                            idBanco = oBancoCuenta.idPersona;
                            tipCuentaBanco = oBancoCuenta.tipCuenta;
                            idMonedaBanco = oBancoCuenta.idMoneda;
                            numCuentaBancaria = item.numCuentaDetraccion;
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
                            //Fecha = item.fecEmision, //revisar
                            idProveedor = Convert.ToInt32(item.idPersona),
                            idDocumento = item.idDocumento,
                            serDocumento = item.numSerie,
                            numDocumento = item.numDocumento,
                            idMoneda = item.idMoneda,
                            Monto = item.MontoDetraccion,
                            idMonedaPago = "01",
                            MontoPago = item.Redondeo,
                            TipPartidaPresu = String.Empty,
                            CodPartidaPresu = String.Empty,
                            Concepto = String.Empty,
                            Descripcion = String.Empty,
                            numVerPlanCuentas = item.numVerPlanCuentas,
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
                            idSistema = 2, //Ventas
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

        public List<EmisionDocumentoE> ControlGuiasVenta(Int32 idEmpresa, Int32 idLocal, String idDocumento, string fecIni, string fecFin)
        {
            try
            {
                return new EmisionDocumentoAD().ControlGuiasVenta(idEmpresa, idLocal, idDocumento, fecIni, fecFin);
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

        public EmisionDocumentoE GenerarFacturaCopia(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numDocumento,String numSerie, EmisionDocumentoE EmiDoc)
        {
            try
            {
                // Cabecera
                EmisionDocumentoE Documento = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                if (Documento == null)
                {
                    throw new Exception(String.Format("El documento {0} ingresado no existe.", idDocumento + " " + numSerie + "-" + numDocumento));
                }
                //fechaemisiontipcambio
                //Detalle
                Documento.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                EmisionDocumentoE oDocumentoCopiar = new EmisionDocumentoE();

                oDocumentoCopiar = Documento;
                oDocumentoCopiar.numSerie = EmiDoc.numSerie;
                oDocumentoCopiar.fecEmision = Convert.ToDateTime(EmiDoc.fecEmision).ToString("yyyyMMdd");
                oDocumentoCopiar.tipCambio = EmiDoc.tipCambio;
                oDocumentoCopiar.numDocumento = EmiDoc.numDocumento;
                oDocumentoCopiar.indEstado = "C";

                new EmisionDocumentoLN().GrabarDocumentos(oDocumentoCopiar, EnumOpcionGrabar.Insertar);


                return Documento;
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

        public Int32 ActualizaTCVentas(Int32 idEmpresa, string Desde, string Hasta)
        {
            try
            {
                return new EmisionDocumentoAD().ActualizaTCVentas(idEmpresa, Desde, Hasta);
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

        public EmisionDocumentoE ObtenerVendedorCondicion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoAD().ObtenerVendedorCondicion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public Int32 ActualizarNroDocAsociado(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, Int32 nroDocAsociado, String Usuario, Boolean EsAnticipo, DateTime? fecFactura = null)
        {
            try
            {
                Int32 resp = 0;

                #region Cerrando el Pedido

                if (nroDocAsociado > 0)
                {
                    if (idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString() || idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                    {
                        PedidoCabE pedido = new PedidoCabAD().RecuperarPedidoCabNacional(idEmpresa, idLocal, nroDocAsociado);
                        PedidoCabE oPedido = null;
                        String Factura = pedido.nroFactura.Trim();
                        String Guia = pedido.NroGuia.Trim();

                        //Factura...
                        if (idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString())
                        {
                            if (String.IsNullOrWhiteSpace(Factura))
                            {
                                Factura = numSerie + "-" + numDocumento;

                                oPedido = new PedidoCabE()
                                {
                                    idEmpresa = idEmpresa,
                                    idLocal = idLocal,
                                    idPedido = pedido.idPedido,
                                    NroGuia = pedido.NroGuia.Trim(),
                                    nroFactura = Factura,
                                    FecFactura = Convert.ToDateTime(fecFactura).ToString("yyyyMMdd"),
                                    UsuarioModificacion = Usuario
                                };

                                new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                            }
                        }

                        //Guia
                        if (idDocumento == EnumTipoDocumentoVenta.GV.ToString())
                        {
                            if (String.IsNullOrWhiteSpace(Guia))
                            {
                                Guia = numSerie + "-" + numDocumento;

                                oPedido = new PedidoCabE()
                                {
                                    idEmpresa = idEmpresa,
                                    idLocal = idLocal,
                                    idPedido = pedido.idPedido,
                                    NroGuia = Guia,
                                    nroFactura = pedido.nroFactura.Trim(),
                                    FecFactura = pedido.FecFactura,
                                    UsuarioModificacion = Usuario
                                };

                                new PedidoCabAD().ActualizarDocumentosPed(oPedido);
                            }
                        }

                        if (!EsAnticipo)
                        {
                            if (!String.IsNullOrWhiteSpace(Factura) && !String.IsNullOrWhiteSpace(Guia))
                            {
                                if (pedido.Estado != "C")
                                {
                                    new PedidoCabAD().CerrarPedido(idEmpresa, nroDocAsociado, EnumEstadoDocumentos.C.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (idDocumento == EnumTipoDocumentoVenta.FV.ToString() || idDocumento == EnumTipoDocumentoVenta.BV.ToString())
                            {
                                if (pedido.Estado != "C")
                                {
                                    new PedidoCabAD().CerrarPedido(idEmpresa, nroDocAsociado, EnumEstadoDocumentos.C.ToString());
                                }
                            }
                        } 
                    }
                }

                #endregion

                resp = new EmisionDocumentoAD().ActualizarNroDocAsociado(idEmpresa, idLocal, idDocumento, numSerie, numDocumento, nroDocAsociado);

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

        #region Procedimientos Privados

        private Int32 GenerarIngresoTransferencia(MovimientoAlmacenE oMovimientoSalida, int idTipMovIngreso, string Usuario)
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
                        throw new Exception("No existe Tipos de Operacion.");
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

        public Boolean PruebaGuias(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    EmisionDocumentoE DocumentoTmp = new EmisionDocumentoAD().ObtenerEmisionDocumento(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                    //Canje de Guias por Nro de Factura - Obteniendo todas las guias
                    List<CanjeGuiasE> ListaCanjeGuias = new CanjeGuiasAD().ObtenerCanjeGuias(DocumentoTmp.idEmpresa, DocumentoTmp.idLocal, DocumentoTmp.idDocumento, DocumentoTmp.numSerie, DocumentoTmp.numDocumento);

                    if (ListaCanjeGuias != null && ListaCanjeGuias.Count > Variables.Cero)
                    {
                        //Listando el detalle de la factura
                        DocumentoTmp.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
                        Boolean Emitir = false;

                        //Recorriendo el listado del canje de guias
                        foreach (CanjeGuiasE item in ListaCanjeGuias)
                        {
                            //Listando la guia
                            EmisionDocumentoE oDocumentoGuias = new EmisionDocumentoAD().ObtenerEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);
                            oDocumentoGuias.ListaItemsDocumento = new EmisionDocumentoDetAD().ObtenerEmisionDocumentoDet(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia);

                            if (oDocumentoGuias.indEstado == EnumEstadoDocumentos.E.ToString())
                            {
                                if (oDocumentoGuias.ListaItemsDocumento.Count > 0)
                                {
                                    //Recorriendo los items de la guia para comparar cantidades
                                    foreach (EmisionDocumentoDetE itemGuia in oDocumentoGuias.ListaItemsDocumento)
                                    {
                                        EmisionDocumentoDetE DocFacBol = DocumentoTmp.ListaItemsDocumento.Find
                                        (
                                            delegate (EmisionDocumentoDetE ed)
                                            {
                                                return ed.idDocumentoRef == itemGuia.idDocumento
                                                   && ed.serDocumentoRef == itemGuia.numSerie
                                                   && ed.numDocumentoRef == itemGuia.numDocumento
                                                   && ed.idArticulo == itemGuia.idArticulo
                                                   && ed.Lote == itemGuia.Lote;
                                            }
                                        );

                                        if (DocFacBol != null)
                                        {
                                            if (DocFacBol.Cantidad == itemGuia.Cantidad)
                                            {
                                                Emitir = true;
                                            }
                                            else
                                            {
                                                Emitir = false;
                                            }
                                        }
                                    }

                                    if (Emitir)
                                    {
                                        new EmisionDocumentoAD().CambiarEstadoDocumento(item.idEmpresa, item.idLocal, item.idDocumentoGuia, item.numSerieGuia, item.numDocumentoGuia, EnumEstadoDocumentos.F.ToString());
                                    }
                                }
                            }
                            else if (oDocumentoGuias.indEstado == EnumEstadoDocumentos.F.ToString())
                            {

                            }
                            else
                            {
                                throw new Exception(String.Format("La Guia {0}-{1} debe estar emitida antes de emitir la Factura.", item.numSerieGuia, item.numDocumentoGuia));
                            }
                        }
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

        public EmisionDocumentoE ActualizarFecDespacho(EmisionDocumentoE emisiondocumento)
        {
            try
            {
                return new EmisionDocumentoAD().ActualizarFecDespacho(emisiondocumento);
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
