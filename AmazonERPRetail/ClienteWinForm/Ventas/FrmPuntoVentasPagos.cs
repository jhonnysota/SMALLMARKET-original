using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Ventas;
using Entidades.Almacen;
using Infraestructura.Winform;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Ventas
{
    public partial class FrmPuntoVentasPagos : Form
    {

        #region Constructores

        public FrmPuntoVentasPagos()
        {
            InitializeComponent();
            Formato(DgvDetalle);
            LlenarCombos();
            Global.CrearToolTip(BtAgregar, "Presionar Tecla INS");
            Global.CrearToolTip(BtQuitar, "Presionar Tecla SUPR");
            Global.CrearToolTip(BtAceptar, "Presionar Tecla F5");
            Global.CrearToolTip(BtCancelar, "Presionar Tecla ESC");
        }

        public FrmPuntoVentasPagos(PedidoCabE docPedido, decimal tica, SalesPointE sales)
            : this()
        {
            Pedido = docPedido;
            LblTica.Text = tica.ToString();
            ptoVenta = sales;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        private string ValorText { get; set; }
        private readonly PedidoCabE Pedido;
        private readonly SalesPointE ptoVenta = null;
        public EmisionDocumentoE Documento;

        #endregion

        #region Procedimientos de Usuario

        private void Nuevo()
        {
            if (Pedido != null)
            {
                LblDesMoneda.Tag = Pedido.idMoneda.ToString();
                LblDesMoneda.Text = Pedido.desMoneda;
                LblTotal.Text = Pedido.totTotal.ToString("###,##0.00");
                LblRedondeo.Text = "Redondeo " + Pedido.Redondeo.ToString("###,##0.00");
            }

            Documento = CrearDocumento();
            CboMoneda_SelectionChangeCommitted(new object(), new EventArgs());
            Eventos();
        }

        private void Agregar()
        {
            int item = 1;
            decimal MontoRec = 0;
            decimal MontoApli = 0;

            if (TxtSoles.Text == "0.00" || TxtDolares.Text == "0.00")
            {
                Global.MensajeComunicacion("Debe ingresar un monto antes de agregar la Cancelación.");
                return;
            }

            //Monto Recibido
            if (CboMoneda.SelectedValue.ToString() == "01")
            {
                decimal.TryParse(TxtSoles.Text, out MontoRec);
            }
            else
            {
                decimal.TryParse(TxtDolares.Text, out MontoRec);
            }

            //Monto Aplicado
            if (CboMoneda.SelectedValue.ToString() == LblDesMoneda.Tag.ToString())
            {
                MontoApli = MontoRec;
            }
            else if (CboMoneda.SelectedValue.ToString() == Variables.Soles)
            {
                decimal.TryParse(TxtDolares.Text, out MontoApli);
            }
            else if (CboMoneda.SelectedValue.ToString() == Variables.Dolares)
            {
                decimal.TryParse(TxtSoles.Text, out MontoApli);
            }

            if (Documento.ListaCancelaciones == null)
            {
                Documento.ListaCancelaciones = new List<EmisionDocumentoCancelacionE>();
            }

            //Nro Item
            if (Documento.ListaCancelaciones.Count > 0)
            {
                item = Convert.ToInt32(Documento.ListaCancelaciones.Max(x => x.Item) + 1);
            }

            EmisionDocumentoCancelacionE Cancelacion = new EmisionDocumentoCancelacionE()
            {
                idEmpresa = Pedido.idEmpresa,
                idLocal = Pedido.idLocal,
                idDocumento = Documento.idDocumento,
                numSerie = Documento.numSerie,
                numDocumento = Documento.numDocumento,
                Fecha = Documento.fecEmision,
                idMonedaDocum = Documento.idMoneda,
                desMonedaDocu = Documento.desMoneda,
                Item = item,
                idMedioPago = Convert.ToInt32(CboMedioPago.SelectedValue),
                desMedioPago = ((MedioPagoE)CboMedioPago.SelectedItem).Nombre,
                idDocumentoReci = String.Empty,
                numSerieReci = String.Empty,
                numDocumentoReci = String.Empty,
                idMonedaRecibida = CboMoneda.SelectedValue.ToString(),
                desMonedaRec = ((MonedasE)CboMoneda.SelectedItem).desAbreviatura,
                MontoRecibido = MontoRec,
                tipCambio = Documento.tipCambio,
                MontoAplicar = MontoApli,
                IndTarjCredito = ((MedioPagoE)CboMedioPago.SelectedItem).indCredito,
                idBanco = null,
                numCuentaBanco = string.Empty,
                fecAbono = null,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            Documento.ListaCancelaciones.Add(Cancelacion);
            BsDetalle.DataSource = Documento.ListaCancelaciones;
            BsDetalle.ResetBindings(false);
            BsDetalle.MoveLast();
            DgvDetalle.CurrentRow.Selected = true;

            SumarTotal();
        }

        private void Quitar()
        {
            if (Documento.ListaCancelaciones != null && Documento.ListaCancelaciones.Count > 0)
            {
                Documento.ListaCancelaciones.Remove((EmisionDocumentoCancelacionE)BsDetalle.Current);
                BsDetalle.DataSource = Documento.ListaCancelaciones;
                BsDetalle.ResetBindings(false);
                SumarTotal();

                if (CboMoneda.SelectedValue.ToString() == "01")
                {
                    TxtSoles.Focus();
                }
                else
                {
                    TxtDolares.Focus();
                }
            }
        }

        private void Aceptar()
        {
            if (Documento != null)
            {
                if (LblVuelto.Text != "0.00")
                {
                    foreach (EmisionDocumentoCancelacionE item in Documento.ListaCancelaciones)
                    {
                        if (!item.IndTarjCredito)
                        {
                            item.Vuelto = Convert.ToDecimal(LblVuelto.Text); 
                        }
                        else
                        {
                            item.Vuelto = 0M;
                        }
                    }
                }

                if (Documento.ListaCancelaciones.Count == 0)
                {
                    Global.MensajeAdvertencia("No hay cobranzas pendientes. Inserte al menos una cancelación.");
                    return;
                }

                decimal TotalTotal = Documento.ListaCancelaciones.Sum(x => x.MontoAplicar);
                decimal.TryParse(LblTotal.Text, out decimal TotalDocu);
                decimal.TryParse(LblVuelto.Text, out decimal Vuelto);

                if (TotalDocu != (TotalTotal - Vuelto))
                {
                    Global.MensajeAdvertencia("No puede emitir el documento porque el total del documento no coincide con el total de la cobranza.");
                    return;
                }

                Documento = AgenteVentas.Proxy.GrabarTicket(Documento, EnumOpcionGrabar.Insertar);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void LlenarCombos()
        {
            //Llenando las monedas
            List<MonedasE> listaMonedas = new List<MonedasE>((from x in VariablesLocales.ListaMonedas
                                                              where x.idMoneda == "01" || x.idMoneda == "02"
                                                              select x).ToList());
            ComboHelper.LlenarCombos<MonedasE>(CboMoneda, listaMonedas, "idMoneda", "desMoneda");

            //Llenar medios de pago
            List<MedioPagoE> oListaMedioPago = AgenteVentas.Proxy.ListarMedioPagoPtoVta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (oListaMedioPago == null || oListaMedioPago.Count == 0)
            {
                BtAgregar.Enabled = false;
                BtQuitar.Enabled = false;
                BtAceptar.Enabled = false;
                BtCancelar.Enabled = false;

                Global.MensajeComunicacion("Falta configurar los Medios de Pago");
            }

            ComboHelper.LlenarCombos<MedioPagoE>(CboMedioPago, oListaMedioPago, "idMedioPago", "Nombre");
        }

        private void Eventos()
        {
            TxtSoles.TextChanged += new EventHandler(TxtMonto_TextChanged);
            TxtDolares.TextChanged += new EventHandler(TxtMonto_TextChanged);
        }

        private void Formato(DataGridView oDgv)
        {
            oDgv.SuspendLayout();
            //Barra de titulos
            oDgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.Black,
                WrapMode = DataGridViewTriState.True
            };

            //La primera columna
            oDgv.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F),
                ForeColor = Color.Black
            };

            //Sin Borde
            oDgv.BorderStyle = BorderStyle.None;
            //Color de fondo
            oDgv.BackgroundColor = Color.Azure;
            //Deshabilitando el ajuste de columnas de la cabecera y la primera columna
            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //Alto de la fila de titulos
            oDgv.ColumnHeadersHeight = 30;
            //Ancho de la primera columna
            oDgv.RowHeadersWidth = 20;
            //Deshabilitando el ajuste de columnas y filas en el detalle
            oDgv.AllowUserToResizeColumns = false;
            oDgv.AllowUserToResizeRows = false;
            //Color de lineas y tipo de bordes
            oDgv.GridColor = Color.Black;
            //oDgv.BorderStyle = BorderStyle.Fixed3D;
            //Tipo de bordes en la cabecera
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //Seleccion multuiple
            oDgv.MultiSelect = false;
            //Quitando los bordes en el detalle
            oDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //Tipo de selección de las celdas
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tipo de letra del detalle
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //Alternando colores en las filas
            //oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            //oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //Color al seleccionar
            oDgv.DefaultCellStyle.SelectionForeColor = Color.White;
            oDgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 28;
            lineas.MinimumHeight = 10;

            //Formato por columnas
            oDgv.Columns["desMedioPago"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            oDgv.Columns["MontoRecibido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            oDgv.Refresh();

            oDgv.ResumeLayout();
        }

        private EmisionDocumentoE CrearDocumento()
        {
            string tipo;
            string serie;
            ParTabla parCanalVenta = null;
            string FechaPedido = Pedido.FecPedido;

            if (Pedido.RucCliente.Length == 11 && (Pedido.RucCliente.Substring(0, 1) == "2" || Pedido.RucCliente.Substring(0, 1) == "1"))
            {
                tipo = ptoVenta.IdFactura;
                serie = ptoVenta.SerieFactura;

                parCanalVenta = AgenteGeneral.Proxy.ParTablaPorNemo("MERNAC");
            }
            else
            {
                tipo = ptoVenta.IdBoleta;
                serie = ptoVenta.SerieBoleta;

                if (Pedido.RucCliente.Length == 8)
                {
                    parCanalVenta = AgenteGeneral.Proxy.ParTablaPorNemo("MERNAC");
                }
                else
                {
                    parCanalVenta = AgenteGeneral.Proxy.ParTablaPorNemo("MEREXT");
                }
            }

            if (FechaPedido.IndexOf("-") > 0 || FechaPedido.IndexOf("/") > 0)
            {
                FechaPedido = Convert.ToDateTime(Pedido.FecPedido).ToString("yyyyMMdd");//.Insert(6, "-").Insert(4, "-")).ToString();
            }

            #region Cabecera

            EmisionDocumentoE DocumentoEmitido = new EmisionDocumentoE
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                idLocal = VariablesLocales.SesionLocal.IdLocal,
                idDocumento = tipo,
                numSerie = serie,
                EsGuia = "F",
                numDocumento = ObtenerCorrelativo(),
                Anio = FechaPedido.Substring(0, 4),
                Mes = FechaPedido.Substring(4, 2),
                fecEmision = FechaPedido,
                fecVencimiento = FechaPedido,
                indRecepcion = false,
                fecRecepcion = null,
                idTipCondicion = (int)EnumTipoCondicionVenta.FacBol,
                idCondicion = Variables.ValorUno,
                idMoneda = Pedido.idMoneda,
                desMoneda = Pedido.desMoneda,
                tipCambio = Convert.ToDecimal(LblTica.Text),
                totMontoBruto = Pedido.totsubTotal,
                totsubTotal = Pedido.totsubTotal,
                totDscto1 = Pedido.totDscto1,
                totDscto2 = Pedido.totDscto2,
                totDscto3 = Pedido.totDscto3,
                totIsc = Pedido.totIsc,
                totIgv = Pedido.totIgv,
                totTotal = Pedido.totTotal,
                Redondeo = Pedido.Redondeo,
                Glosa = String.Empty,

                idTipTransporte = String.Empty,
                NombrePuerto = String.Empty,
                numReserva = String.Empty,
                numPartida = String.Empty,
                Invoice = String.Empty,
                Periodo = String.Empty,
                PO = String.Empty,
                AfectoDetraccion = false,
                totAfectoPerce = Variables.ValorCeroDecimal,
                totPercepcion = Variables.ValorCeroDecimal,
                TipoAsiento = string.Empty,
                idVendedor = VariablesLocales.SesionUsuario.IdPersona,
                nomVendedor = VariablesLocales.SesionUsuario.NombreCorto,
                indEstado = EnumEstadoDocumentos.E.ToString(),

                //Datos Clientes
                idPersona = Pedido.idFacturar,
                numRuc = Pedido.RucCliente,
                RazonSocial = Pedido.RazonSocial,
                Direccion = Pedido.DireccionCompleta,
                idSucursalCliente = 0,

                idCanalVenta = parCanalVenta != null ? parCanalVenta.IdParTabla : 0,
                indVoucher = false,
                nroDocAsociado = Pedido.idPedido,
                tipAfectoIgv = Variables.Cero,
                porDscto = Variables.ValorCeroDecimal,
                DsctoGlobal = Variables.ValorCeroDecimal,
                EsAnticipo = false,
                indAnticipo = false,
                EnvioFE = false,
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };

            #endregion

            foreach (PedidoDetE item in Pedido.ListaPedidoDet)
            {
                #region Items Resumido

                EmisionDocumentoDetE detalle = new EmisionDocumentoDetE
                {
                    Item = String.Format("{0:000}", item.idItem),
                    idAlmacen = item.idAlmacen,
                    codArticulo = item.codArticulo,
                    idArticulo = item.idArticulo,
                    nomArticulo = item.nomArticulo,
                    Lote = item.Lote,
                    Cantidad = item.Cantidad,
                    CantidadUnit = 0,
                    CantidadFinal = item.Cantidad,
                    CantidadAtendida = item.Cantidad,
                    PrecioSinImpuesto = item.PrecioUnitario,
                    PrecioConImpuesto = item.PrecioConImpuesto,
                    porDscto1 = item.porDscto1,
                    Dscto1 = item.Dscto1,
                    porDscto2 = item.porDscto2,
                    Dscto2 = item.Dscto2,
                    porDscto3 = item.porDscto3,
                    Dscto3 = item.Dscto3,
                    Comision = 0,
                    porComision = 0,
                    flgIgv = item.flgIgv,
                    Isc = item.Isc,
                    Igv = item.Igv,
                    subTotal = item.subTotal,
                    Total = Convert.ToDecimal(item.Total),
                    porIsc = item.porIsc,
                    porIgv = item.porIgv,
                    idUnidadMedida = item.idUMedida,
                    idListaPrecio = item.idTipoPrecio,
                    numOrdenProd = string.Empty,
                    TipoImpSelectivo = item.TipoImpSelectivo,
                    Stock = item.Stock,
                    TipoLista = string.Empty,
                    codLineaVenta = string.Empty,
                    Contiene = item.Contenido,
                    Capacidad = item.Capacidad,
                    PesoUnitario = item.PesoUnitario,
                    idDocumentoRef = string.Empty,
                    serDocumentoRef = string.Empty,
                    numDocumentoRef = string.Empty,
                    fecDocumentoRef = null,
                    TotalRef = 0,
                    idCampana = null,
                    indPercepcion = false,
                    MontoPercepcion = 0,
                    nroOt = null,
                    nroOtItem = null,
                    PesoBrutoCad = string.Empty,
                    indCalculo = item.indCalculo,
                    DocumentoAlmacen = 0,
                    tipArticulo = "AR",
                    indDetraccion = item.indDetraccion,
                    tipDetraccion = item.tipDetraccion,
                    TasaDetraccion = item.TasaDetraccion,
                    idTipoArticulo = item.idTipoArticulo,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                };

                DocumentoEmitido.ListaItemsDocumento.Add(detalle);

                #endregion

                #region Items Detallado
                
                //Listando los lotes disponibles...
                List<AlmacenArticuloLoteE> ListaAlmacenArticulo = AgenteAlmacen.Proxy.ListarAlmacenArticuloLote(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, DocumentoEmitido.Anio, DocumentoEmitido.Mes, item.idAlmacen, item.idArticulo);
                decimal CantidadUmedDet = item.Cantidad;
                EmisionDocumentoDetDetalleE detDetalle = null;

                //Si la U.M. es diferente a la U.M. de almacenamiento del maestro de Articulos
                if (item.idUMedida != item.codUniMedAlmacen)
                {
                    CantidadUmedDet = item.Cantidad / item.Contenido;
                }

                if (ListaAlmacenArticulo != null && ListaAlmacenArticulo.Count > 0)
                {
                    foreach (var itemLote in ListaAlmacenArticulo)
                    {
                        detDetalle = new EmisionDocumentoDetDetalleE()
                        {
                            Item = string.Empty,
                            idAlmacen = item.idAlmacen,
                            codArticulo = item.codArticulo,
                            idArticulo = item.idArticulo,
                            nomArticulo = item.nomArticulo,
                            Lote = itemLote.Lote,
                            Cantidad = item.Cantidad,
                            CantidadUnit = 0,
                            CantidadFinal = 0,//item.Cantidad,
                            CantidadAtendida = 0,//item.Cantidad,
                            PrecioSinImpuesto = item.PrecioUnitario,
                            PrecioConImpuesto = item.PrecioConImpuesto,
                            porDscto1 = item.porDscto1,
                            Dscto1 = item.Dscto1,
                            porDscto2 = item.porDscto2,
                            Dscto2 = item.Dscto2,
                            porDscto3 = item.porDscto3,
                            Dscto3 = item.Dscto3,
                            Comision = 0,
                            porComision = 0,
                            flgIgv = item.flgIgv,
                            Isc = item.Isc,
                            //subTotal = item.Cantidad * item.PrecioUnitario, //item.subTotal,
                            //Igv = item.flgIgv == true ? (item.Cantidad * item.PrecioUnitario) * (item.porIgv / 100) : 0M,
                            //Total = Convert.ToDecimal(item.Total),
                            porIsc = item.porIsc,
                            porIgv = item.porIgv,
                            idUnidadMedida = item.idUMedida,
                            idListaPrecio = item.idTipoPrecio,
                            numOrdenProd = string.Empty,
                            TipoImpSelectivo = item.TipoImpSelectivo,
                            Stock = itemLote.canStock,
                            TipoLista = string.Empty,
                            codLineaVenta = string.Empty,
                            Contiene = item.Contenido,
                            Capacidad = item.Capacidad,
                            PesoUnitario = item.PesoUnitario,
                            idDocumentoRef = string.Empty,
                            serDocumentoRef = string.Empty,
                            numDocumentoRef = string.Empty,
                            fecDocumentoRef = null,
                            TotalRef = 0,
                            idCampana = null,
                            indPercepcion = false,
                            MontoPercepcion = 0,
                            nroOt = null,
                            nroOtItem = null,
                            PesoBrutoCad = string.Empty,
                            indCalculo = item.indCalculo,
                            DocumentoAlmacen = 0,
                            tipArticulo = "AR",
                            indDetraccion = item.indDetraccion,
                            tipDetraccion = item.tipDetraccion,
                            TasaDetraccion = item.TasaDetraccion,
                            idTipoArticulo = item.idTipoArticulo,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            codUniMedAlmacen = item.codUniMedAlmacen
                        };

                        //Si la cantidad del Lote es mayor a la cantidad del documento
                        if (itemLote.canStock >= CantidadUmedDet)
                        {
                            //Actualiza la cantidad del documento con la cantidad del lote
                            detDetalle.Cantidad = item.idUMedida != item.codUniMedAlmacen ? decimal.Round(CantidadUmedDet * item.Contenido, 2) : Decimal.Round(CantidadUmedDet, 2);
                            detDetalle.CantidadFinal = Decimal.Round(CantidadUmedDet, 4);

                            detDetalle.subTotal = detDetalle.Cantidad * detDetalle.PrecioSinImpuesto;
                            detDetalle.Igv = detDetalle.flgIgv == true ? (detDetalle.Cantidad * detDetalle.PrecioSinImpuesto) * (detDetalle.porIgv / 100) : 0M;
                            detDetalle.Total = detDetalle.subTotal + detDetalle.Igv;

                            DocumentoEmitido.ListaItemsDetallado.Add(detDetalle);
                            break;
                        }
                        else
                        {
                            //Actualiza la cantidad del documento con la cantidad del lote
                            detDetalle.Cantidad = item.idUMedida != item.codUniMedAlmacen ? decimal.Round(itemLote.canStock * item.Contenido, 2) : itemLote.canStock;
                            detDetalle.CantidadFinal = itemLote.canStock;

                            detDetalle.subTotal = detDetalle.Cantidad * detDetalle.PrecioSinImpuesto;
                            detDetalle.Igv = detDetalle.flgIgv == true ? (detDetalle.Cantidad * detDetalle.PrecioSinImpuesto) * (detDetalle.porIgv / 100) : 0M;
                            detDetalle.Total = detDetalle.subTotal + detDetalle.Igv;

                            //Actualiza la variable para la siguiente comparación de cantidades
                            CantidadUmedDet -= itemLote.canStock;
                            DocumentoEmitido.ListaItemsDetallado.Add(detDetalle);
                        }
                    }
                }
                else
                {
                    detDetalle = new EmisionDocumentoDetDetalleE()
                    {
                        Item = string.Empty,
                        idAlmacen = item.idAlmacen,
                        idArticulo = item.idArticulo,
                        codArticulo = item.codArticulo,
                        nomArticulo = item.nomArticulo,
                        Lote = string.Empty,
                        Cantidad = item.Cantidad,
                        CantidadUnit = 0,
                        CantidadFinal = item.Cantidad,
                        CantidadAtendida = 0,
                        PrecioSinImpuesto = Convert.ToDecimal(item.PrecioUnitario),
                        PrecioConImpuesto = item.PrecioConImpuesto,
                        porDscto1 = Convert.ToDecimal(item.porDscto1),
                        Dscto1 = Convert.ToDecimal(item.Dscto1),
                        porDscto2 = Convert.ToDecimal(item.porDscto2),
                        Dscto2 = Convert.ToDecimal(item.Dscto2),
                        porDscto3 = Convert.ToDecimal(item.porDscto3),
                        Dscto3 = Convert.ToDecimal(item.Dscto3),
                        Comision = 0,
                        porComision = 0,
                        flgIgv = item.flgIgv,
                        Isc = item.Isc,
                        Igv = item.Igv,
                        subTotal = item.subTotal,
                        Total = Convert.ToDecimal(item.Total),
                        porIsc = item.porIsc,
                        porIgv = item.porIgv,
                        idUnidadMedida = item.idUMedida,
                        idListaPrecio = item.idTipoPrecio,
                        numOrdenProd = string.Empty,
                        TipoImpSelectivo = item.TipoImpSelectivo,
                        Stock = 0,
                        TipoLista = string.Empty,
                        codLineaVenta = string.Empty,
                        Contiene = item.Contenido,
                        Capacidad = item.Capacidad,
                        PesoUnitario = item.PesoUnitario,
                        idDocumentoRef = string.Empty,
                        serDocumentoRef = string.Empty,
                        numDocumentoRef = string.Empty,
                        fecDocumentoRef = null,
                        TotalRef = 0,
                        idCampana = null,
                        indPercepcion = false,
                        MontoPercepcion = 0,
                        nroOt = null,
                        nroOtItem = null,
                        PesoBrutoCad = string.Empty,
                        indCalculo = item.indCalculo,
                        DocumentoAlmacen = 0,
                        tipArticulo = "AR",
                        indDetraccion = item.indDetraccion,
                        tipDetraccion = item.tipDetraccion,
                        TasaDetraccion = item.TasaDetraccion,
                        idTipoArticulo = item.idTipoArticulo,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    DocumentoEmitido.ListaItemsDetallado.Add(detDetalle);
                }

                #endregion

                decimal cantArticulo = decimal.Round((from x in DocumentoEmitido.ListaItemsDetallado
                                                      where x.idArticulo == item.idArticulo
                                                      select x.Cantidad).Sum(), 2);

                if (cantArticulo < item.Cantidad)
                {
                    throw new Exception(string.Format("El articulo {0} no tiene suficiente stock. Corrija la cantidad o escoja otro producto.", item.nomArticulo));
                }
            }

            return DocumentoEmitido;
        }

        private string ObtenerCorrelativo()
        {
            string ValorDevuelto = string.Empty;
            string tipo;
            string serie;

            if (Pedido.RucCliente.Length == 11 && (Pedido.RucCliente.Substring(0, 1) == "2" || Pedido.RucCliente.Substring(0, 1) == "1"))
            {
                tipo = ptoVenta.IdFactura;
                serie = ptoVenta.SerieFactura;          
            }
            else
            {
                tipo = ptoVenta.IdBoleta;
                serie = ptoVenta.SerieBoleta;
            }

            NumControlDetE Detalle = AgenteVentas.Proxy.NumControlDetTipoDocSerie(Pedido.idEmpresa, Pedido.idLocal, tipo, serie);

            if (Detalle != null)
            {
                ValorDevuelto = DevolverNumeroCorrelativo(Detalle.numCorrelativo, Convert.ToInt32(Detalle.cantDigNumero));
            }

            return ValorDevuelto;
        }

        private string DevolverNumeroCorrelativo(string Correlativo, Int32 cantDigitos)
        {
            int Numero;

            if (string.IsNullOrWhiteSpace(Correlativo))
            {
                Numero = Variables.Cero;
            }
            else
            {
                Numero = Convert.ToInt32(Correlativo);
            }

            Numero++;

            return Numero.ToString().PadLeft(cantDigitos, '0');
        }

        private void CalcularMontoTica()
        {
            decimal.TryParse(LblTica.Text, out decimal tica);

            if (CboMoneda.SelectedValue.ToString() == "01")
            {
                decimal.TryParse(TxtSoles.Text, out decimal soles);
                TxtDolares.Text = (soles / tica).ToString("N2");
            }
            else
            {
                decimal.TryParse(TxtDolares.Text, out decimal dolares);
                TxtSoles.Text = (dolares * tica).ToString("N2");
            }
        }

        private void SumarTotal()
        {
            TxtSoles.TextChanged -= new EventHandler(TxtMonto_TextChanged);
            TxtDolares.TextChanged -= new EventHandler(TxtMonto_TextChanged);

            if (Documento.ListaCancelaciones.Count > 0)
            {
                Decimal TotalTotal = Documento.ListaCancelaciones.Sum(x => x.MontoAplicar);
                Decimal TotalEfectivo = Documento.ListaCancelaciones.Where(e => e.IndTarjCredito == false).Sum(e => e.MontoAplicar);
                Decimal TotalTarjetas = Documento.ListaCancelaciones.Where(t => t.IndTarjCredito == true).Sum(t => t.MontoAplicar);
                Decimal.TryParse(LblTotal.Text, out decimal TotalDocu);
                decimal.TryParse(LblRedondeo.Text, out decimal Redondeo);
                        
                if (TotalEfectivo > 0 && TotalTarjetas == 0)
                {
                    if (TotalTotal > TotalDocu)
                    {
                        LblVuelto.Text = Convert.ToDecimal(TotalTotal - TotalDocu).ToString("N2");
                        TxtSoles.Text = "0.00";
                        TxtDolares.Text = "0.00";
                    }
                    else if (TotalTotal < TotalDocu)
                    {
                        LblVuelto.Text = "0.00";

                        if (CboMoneda.SelectedValue.ToString() == "01")
                        {
                            TxtSoles.Text = Convert.ToDecimal(TotalDocu - TotalTotal).ToString("N2");
                        }
                        else
                        {
                            TxtDolares.Text = Convert.ToDecimal(TotalDocu - TotalTotal).ToString("N2");
                        }
                        
                        CalcularMontoTica();
                    }
                    else
                    {
                        LblVuelto.Text = "0.00";
                        TxtSoles.Text = "0.00";
                        TxtDolares.Text = "0.00";
                    }
                }
                else if (TotalEfectivo == 0 && TotalTarjetas > 0)
                {
                    LblVuelto.Text = "0.00";

                    if (TotalTotal <= TotalDocu)
                    {
                        if (CboMoneda.SelectedValue.ToString() == "01")
                        {
                            TxtSoles.Text = Convert.ToDecimal(TotalDocu - TotalTotal).ToString("N2");
                        }
                        else
                        {
                            TxtDolares.Text = Convert.ToDecimal(TotalDocu - TotalTotal).ToString("N2");
                        }

                        CalcularMontoTica();
                    }
                    else
                    {
                        TxtSoles.Text = "0.00";
                        TxtDolares.Text = "0.00";
                    }
                }
                else if (TotalEfectivo > 0 && TotalTarjetas > 0)
                {
                    if (TotalTotal < TotalDocu)
                    {
                        if (CboMoneda.SelectedValue.ToString() == "01")
                        {
                            TxtSoles.Text = Convert.ToDecimal(TotalDocu - TotalTotal).ToString("N2");
                        }
                        else
                        {
                            TxtDolares.Text = Convert.ToDecimal(TotalDocu - TotalTotal).ToString("N2");
                        }

                        CalcularMontoTica();
                    }
                    else if (TotalTotal > TotalDocu)
                    {
                        LblVuelto.Text = Convert.ToDecimal(TotalEfectivo - (TotalDocu - TotalTarjetas)).ToString("N2");
                        Decimal.TryParse(LblVuelto.Text, out decimal Vuelto);

                        if ((TotalTotal - Vuelto) == TotalDocu)
                        {
                            TxtSoles.Text = "0.00";
                            TxtDolares.Text = "0.00";
                        }
                        else
                        {
                            if (CboMoneda.SelectedValue.ToString() == "01")
                            {
                                TxtSoles.Text = Convert.ToDecimal(TotalDocu - (TotalTotal - Vuelto)).ToString("N2");
                            }
                            else
                            {
                                TxtDolares.Text = Convert.ToDecimal(TotalDocu - (TotalTotal - Vuelto)).ToString("N2");
                            }

                            CalcularMontoTica();
                        }
                    }
                    else if (TotalTotal == TotalDocu)
                    {
                        LblVuelto.Text = "0.00";
                        TxtSoles.Text = "0.00";
                        TxtDolares.Text = "0.00";
                    }
                }
            }
            else
            {
                LblVuelto.Text = "0.00";
                TxtSoles.Text = "0.00";
                TxtDolares.Text = "0.00";
                LblRedondeo.Text = "Redondeo 0.00";
            }

            TxtSoles.TextChanged += new EventHandler(TxtMonto_TextChanged);
            TxtDolares.TextChanged += new EventHandler(TxtMonto_TextChanged);
        } 

        #endregion

        #region Eventos de Usuario

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //var textBox = (TextBox)sender;
                //// Comprueba si el valor del TextBox se ajusta a un valor válido
                //if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, @"^(?:\d+\.?\d{0,2})?$"))
                //{
                //    // Si es válido se almacena el valor actual en la variable privada
                //    ValorText = textBox.Text;
                //}
                //else
                //{
                //    // Si no es válido se recupera el valor de la variable privada con el valor anterior
                //    // Calcula el nº de caracteres después del cursor para dejar el cursor en la misma posición
                //    var charsAfterCursor = textBox.Text.Length - textBox.SelectionStart - textBox.SelectionLength;
                //    // Recupera el valor anterior
                //    textBox.Text = ValorText;
                //    // Posiciona el cursor en la misma posición
                //    textBox.SelectionStart = Math.Max(0, textBox.Text.Length - charsAfterCursor);
                //    return;
                //}

                //int longitud = ((TextBox)sender).Text.Trim().Length;
                //if (((TextBox)sender).Text.Trim().Equals("."))
                //{
                //    ((TextBox)sender).Text = "0.";
                //}

                CalcularMontoTica();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void FrmPuntoVentasPagos_Load(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
                TxtSoles.Focus();
            }
            catch (Exception ex)
            {
                BtAceptar.Enabled = false;
                PnlMedioPagos.Enabled = false;
                Global.MensajeFault(ex.Message);
            }
        }

        private void CboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboMoneda.SelectedValue.ToString() == Variables.Soles)
                {
                    TxtSoles.Enabled = true;
                    TxtSoles.BackColor = Color.White;
                    TxtDolares.Enabled = false;
                    TxtDolares.BackColor = SystemColors.InactiveCaption;
                    TxtSoles.Focus();
                }
                else
                {
                    TxtDolares.Enabled = true;
                    TxtDolares.BackColor = Color.White;
                    TxtSoles.Enabled = false;
                    TxtSoles.BackColor = SystemColors.InactiveCaption;
                    TxtDolares.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documento != null)
                {
                    Agregar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                Quitar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void FrmPuntoVentasPagos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Dispose();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    Aceptar();
                }
                else if (e.KeyCode == Keys.Insert)
                {
                    Agregar();
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    Quitar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TxtSoles_Leave(object sender, EventArgs e)
        {
            TxtSoles.Text = Global.FormatoDecimal(TxtSoles.Text);
        }

        private void TxtDolares_Leave(object sender, EventArgs e)
        {
            TxtDolares.Text = Global.FormatoDecimal(TxtDolares.Text);
        }

        private void TxtSoles_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, BtAgregar);
        }

        private void TxtDolares_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, BtAgregar);
        }

        private void CboMedioPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void CboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void CboMedioPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboMedioPago.SelectedValue != null)
                {
                    if (((MedioPagoE)CboMedioPago.SelectedItem).indCredito)
                    {
                        LblTotal.Text = (Convert.ToDecimal(LblTotal.Text) + Pedido.Redondeo).ToString("###,###,##0.00");
                    }
                    else
                    {
                        LblTotal.Text = Pedido.totTotal.ToString("###,###,##0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
