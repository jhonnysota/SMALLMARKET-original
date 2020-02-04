using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Almacen;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmDetallePedidoNacionalXtalla : frmResponseBase
    {

        #region Constructores

        public frmDetallePedidoNacionalXtalla()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            Global.CrearToolTip(btBuscarArticulo, "Buscar Articulos.");
        }

        //Constructor para los Pedidos
        //public frmDetallePedidoNacionalXtalla(DateTime Fecha_, PedidoDetE oLinea, List<PedidoDetE> oLista, String indCotiPedi = "P")
        //    :this()
        //{
        //    FechaPedido = Fecha_;
        //    oDetalle = oLinea;

        //    if (oLista != null && oLista.Count > Variables.Cero)
        //    {
        //        oListaDetalle = oLista;
        //    }

        //    Tipo = indCotiPedi;

        //    if (Tipo == "C")
        //    {
        //        EsCoti = "S";
        //    }
        //}

        //Constructor para que no haya duplicados en el detalle de los Pedidos
        public frmDetallePedidoNacionalXtalla(DateTime Fecha_, List<PedidoDetE> conta, List<PedidoDetE> oLista = null, String indCotiPedi = "P")
            : this()
        {
            FechaPedido = Fecha_;
            Contador = conta.Count;
            oListaDetallePedidosInicio = conta;
            if (oLista != null && oLista.Count > Variables.Cero)
            {
                oListaDetalle = oLista;
            }

            Tipo = indCotiPedi;

            if (Tipo == "C")
            {
                EsCoti = "S";
            }
        }

        //Constructor para los documentos de ventas
        //public frmDetallePedidoNacionalXtalla(DateTime Fecha_, EmisionDocumentoDetE oLinea, List<EmisionDocumentoDetE> oItems, Boolean Bloqueo = true, Int32 idAlmacen = 0)
        //    :this()
        //{
        //    FechaPedido = Fecha_;

        //    if (oItems != null && oItems.Count > Variables.Cero)
        //    {
        //        oListaEmisionDocumentos = oItems;
        //    }

        //    oDetalleDocEmision = oLinea;
        //    Tipo = "G";

        //    if (!Bloqueo)
        //    {
        //        pnlBase.Enabled = Bloqueo;
        //        pnlComprobante.Enabled = Bloqueo;
        //        pnlAuditoria.Enabled = Bloqueo;
        //        btAceptar.Enabled = Bloqueo;
        //    }

        //    idAlmacenTmp = idAlmacen;
        //}

        //Constructor para que no haya duplicados en el detalle de los documentos de Ventas
        //public frmDetallePedidoNacionalXtalla(DateTime Fecha_, List<EmisionDocumentoDetE> oItems = null, Int32 idAlmacen = 0)
        //    :this()
        //{
        //    FechaPedido = Fecha_;

        //    if (oItems != null && oItems.Count > Variables.Cero)
        //    {
        //        oListaEmisionDocumentos = oItems;
        //    }

        //    Tipo = "G";

        //    idAlmacenTmp = idAlmacen;
        //}

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        public PedidoDetE oDetalle = null;
        public EmisionDocumentoDetE oDetalleDocEmision = null;
        public List<PedidoDetE> oListaDetallePedidosGeneral = new List<PedidoDetE>();
        List<PedidoDetE> oListaDetallePedidos = new List<PedidoDetE>();
        List<PedidoDetE> oListaDetallePedidosInicio = new List<PedidoDetE>();
        Int32 Contador = 0;
        List<PedidoDetE> oListaDetalle = null;
        //List<EmisionDocumentoDetE> oListaEmisionDocumentos = null;
        DateTime FechaPedido;
        String Tipo = String.Empty; // P = Pedido G = Guias
        String EsCoti = "N"; //Para saber si se trata de una cotización o no
        Int32 idAlmacenTmp = 0; //Variable cuando viene de la solicitud de factura

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Almacenes
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");

            List<ListaPrecioE> oListaPrecio = null;

            if (VariablesLocales.oVenParametros != null && VariablesLocales.oVenParametros.indListaPrecio)
            {
                ListaPrecioE oPrecio = null;
                oListaPrecio = AgenteVentas.Proxy.ListarPrecioPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, false);
                oListaPrecio.Add(new ListaPrecioE() { idListaPrecio = Variables.Cero, Nombre = Variables.Escoger });
                ComboHelper.LlenarCombos<ListaPrecioE>(cboListaPrecio, (from x in oListaPrecio
                                                                        orderby x.idListaPrecio
                                                                        select x).ToList(), "idListaPrecio", "Nombre");

                oPrecio = oListaPrecio.Find
                (
                    delegate (ListaPrecioE pre) { return pre.Principal == true; }
                );

                if (oPrecio != null)
                {
                    cboListaPrecio.SelectedValue = oPrecio.idListaPrecio;
                }
                else
                {
                    cboListaPrecio.SelectedValue = 0;
                }

                oPrecio = null;
            }
            else
            {
                oListaPrecio = new List<ListaPrecioE>();
                oListaPrecio.Add(new ListaPrecioE() { idListaPrecio = Variables.Cero, Nombre = Variables.Escoger });
                ComboHelper.LlenarCombos<ListaPrecioE>(cboListaPrecio, oListaPrecio, "idListaPrecio", "Nombre");
                cboListaPrecio.Enabled = false;
            }

            cboImpSelectivo.DataSource = Global.CargarSelectivo();
            cboImpSelectivo.ValueMember = "id";
            cboImpSelectivo.DisplayMember = "Nombre";

            oListaPrecio = null;
            oListaAlmacen = null;
        }

        void Calcular()
        {
            txtPrecioVenta.TextChanged -= txtPrecioVenta_TextChanged;

            #region Variables

            Decimal Cantidad = Variables.Cero;
            Decimal Precio = Variables.Cero;
            Decimal Igv = Variables.Cero;
            Decimal Isc = Variables.Cero;
            Decimal Por1 = Variables.Cero;
            Decimal Dscto1 = Variables.Cero;
            Decimal Por2 = Variables.Cero;
            Decimal Dscto2 = Variables.Cero;
            Decimal Por3 = Variables.Cero;
            Decimal Dscto3 = Variables.Cero;
            Decimal SubTotal = Variables.Cero;
            Decimal ValorVenta = Variables.Cero;
            Decimal porIsc = Variables.Cero;
            Decimal porIgv = Variables.Cero;

            #endregion

            #region Parseando para evitar errores de escritura

            Decimal.TryParse(txtCantidad.Text, out Cantidad);
            Decimal.TryParse(txtPrecio.Text, out Precio);

            txtSubTotal.Text = (Precio * Cantidad).ToString("N2");
            Decimal.TryParse(txtSubTotal.Text, out SubTotal);

            #region Descuentos

            Decimal.TryParse(txtPor1.Text, out Por1);
            Decimal.TryParse(txtPor2.Text, out Por2);
            Decimal.TryParse(txtPor3.Text, out Por3);

            txtDscto1.Text = (SubTotal * (Por1 / 100)).ToString("N2");
            Decimal.TryParse(txtDscto1.Text, out Dscto1);
            txtDscto2.Text = ((SubTotal - Dscto1) * (Por2 / 100)).ToString("N2");
            Decimal.TryParse(txtDscto2.Text, out Dscto2);
            txtDscto3.Text = ((SubTotal - Dscto1 - Dscto2) * (Por3 / 100)).ToString("N2");
            Decimal.TryParse(txtDscto3.Text, out Dscto3);

            #endregion

            txtValorVenta.Text = (SubTotal - (Dscto1 + Dscto2 + Dscto3)).ToString("N2");
            Decimal.TryParse(txtValorVenta.Text, out ValorVenta);

            //Impuesto Selectivo al Consumo
            Decimal.TryParse(txtPorIsc.Text, out porIsc);

            if (cboImpSelectivo.SelectedValue.ToString() == "L")
            {
                Decimal cantLitros = Convert.ToDecimal(txtCapacidad.Text);
                Decimal Conte = Convert.ToDecimal(txtContenido.Text);

                Decimal Factor = (Cantidad * Conte) * cantLitros;
                txtIsc.Text = Convert.ToDecimal(Factor * porIsc).ToString("N2");
            }
            else if(cboImpSelectivo.SelectedValue.ToString() == "P")
            {
                txtIsc.Text = (ValorVenta * (porIsc / 100)).ToString("N2");
            }
            else
            {
                txtIsc.Text = "0.00";
            }

            Decimal.TryParse(txtIsc.Text, out Isc);

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorIgv.Text, out porIgv);
            txtIgv.Text = ((ValorVenta + Isc) * (porIgv / 100)).ToString("N2");
            Decimal.TryParse(txtIgv.Text, out Igv);

            //Total General
            txtPrecioVenta.Text = (ValorVenta + Isc + Igv).ToString("N2");

            #endregion

            txtPrecioVenta.TextChanged += txtPrecioVenta_TextChanged;
        }

        void QuitarEventos(String SN)
        {
            if (SN == "S")
            {
                txtPrecio.TextChanged -= txtPrecio_TextChanged;
                txtCantidad.TextChanged -= txtCantidad_TextChanged;
                txtPor1.TextChanged -= txtPor1_TextChanged;
                txtPor2.TextChanged -= txtPor2_TextChanged;
                txtPor3.TextChanged -= txtPor3_TextChanged;
                txtPorIsc.TextChanged -= txtPorIsc_TextChanged;
                txtPorIgv.TextChanged -= txtPorIgv_TextChanged;
                chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                txtPrecioVenta.TextChanged -= txtPrecioVenta_TextChanged;
            }
            else
            {
                txtPrecio.TextChanged += txtPrecio_TextChanged;
                txtCantidad.TextChanged += txtCantidad_TextChanged;
                txtPor1.TextChanged += txtPor1_TextChanged;
                txtPor2.TextChanged += txtPor2_TextChanged;
                txtPor3.TextChanged += txtPor3_TextChanged;
                txtPorIsc.TextChanged += txtPorIsc_TextChanged;
                txtPorIgv.TextChanged += txtPorIgv_TextChanged;
                chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                txtPrecioVenta.TextChanged += txtPrecioVenta_TextChanged;
            }
        }

        void AceptarDetalle(Decimal Cant, Decimal PrecioSin, Decimal PrecioCon, Decimal Stock_)
        {
            if (Tipo == "P" || Tipo == "C") //////////////////////////// PEDIDOS y COTIZACIONES /////////////////////////////////
            {
                oDetalle.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                oDetalle.codArticulo = txtCodArticulo.Text.Trim();
                oDetalle.idTipoPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue);
                oDetalle.nomArticulo = txtDesArticulo.Text.Trim();
                oDetalle.Cantidad = Cant;
                oDetalle.PrecioUnitario = PrecioSin;
                oDetalle.PrecioConImpuesto = PrecioCon;
                oDetalle.subTotal = Convert.ToDecimal(txtValorVenta.Text);
                oDetalle.porDscto1 = Convert.ToDecimal(txtPor1.Text);
                oDetalle.Dscto1 = Convert.ToDecimal(txtDscto1.Text);
                oDetalle.porDscto2 = Convert.ToDecimal(txtPor2.Text);
                oDetalle.Dscto2 = Convert.ToDecimal(txtDscto2.Text);
                oDetalle.porDscto3 = Convert.ToDecimal(txtPor3.Text);
                oDetalle.Dscto3 = Convert.ToDecimal(txtDscto3.Text);
                oDetalle.porIsc = Convert.ToDecimal(txtPorIsc.Text);
                oDetalle.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                oDetalle.Isc = Convert.ToDecimal(txtIsc.Text);
                oDetalle.Igv = Convert.ToDecimal(txtIgv.Text);
                oDetalle.Total = Convert.ToDecimal(txtPrecioVenta.Text);
                oDetalle.flgIgv = chkIgv.Checked;
                //oDetalle.idTipoMedida = Convert.ToInt32(cboTipoUnidad.SelectedValue);
                //oDetalle.idUMedida = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                oDetalle.idTipoArticulo = Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen);
                oDetalle.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                oDetalle.Stock = Stock_;
                //oDetalle.Lote = txtLote.Text.Trim();
                //oDetalle.LoteProveedor = txtLoteProveedor.Text.Trim();
                //oDetalle.nroOt = txtOt.Text;
                oDetalle.indCalculo = chkCalculo.Checked;
                oDetalle.TipoImpSelectivo = cboImpSelectivo.SelectedValue.ToString();
                oDetalle.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
                oDetalle.Contenido = Convert.ToDecimal(txtContenido.Text);
                oDetalle.indDetraccion = chkDetra.Checked;
                oDetalle.tipDetraccion = txtTipDetra.Text;
                oDetalle.TasaDetraccion = Convert.ToDecimal(txtTasa.Text);

                if (oDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                    oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                }
            }
            else if (Tipo == "G") ////////////////////// DOCUMENTOS DE VENTAS /////////////////////////////
            {
                oDetalleDocEmision.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                oDetalleDocEmision.codArticulo = txtCodArticulo.Text.Trim();
                oDetalleDocEmision.nomArticulo = txtDesArticulo.Text.Trim();
                oDetalleDocEmision.Cantidad = Cant;
                oDetalleDocEmision.PrecioConImpuesto = PrecioCon;
                oDetalleDocEmision.PrecioSinImpuesto = PrecioSin;
                oDetalleDocEmision.subTotal = Convert.ToDecimal(txtValorVenta.Text);
                oDetalleDocEmision.porDscto1 = Convert.ToDecimal(txtPor1.Text);
                oDetalleDocEmision.Dscto1 = Convert.ToDecimal(txtDscto1.Text);
                oDetalleDocEmision.porDscto2 = Convert.ToDecimal(txtPor2.Text);
                oDetalleDocEmision.Dscto2 = Convert.ToDecimal(txtDscto2.Text);
                oDetalleDocEmision.porDscto3 = Convert.ToDecimal(txtPor3.Text);
                oDetalleDocEmision.Dscto3 = Convert.ToDecimal(txtDscto3.Text);
                oDetalleDocEmision.porIsc = Convert.ToDecimal(txtPorIsc.Text);
                oDetalleDocEmision.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                oDetalleDocEmision.Isc = Convert.ToDecimal(txtIsc.Text);
                oDetalleDocEmision.Igv = Convert.ToDecimal(txtIgv.Text);
                oDetalleDocEmision.Total = Convert.ToDecimal(txtPrecioVenta.Text);
                oDetalleDocEmision.flgIgv = chkIgv.Checked;
                //oDetalleDocEmision.idTipoMedida = Convert.ToInt32(cboTipoUnidad.SelectedValue);
                //oDetalleDocEmision.idUnidadMedida = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                oDetalleDocEmision.idTipoArticulo = Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen);
                oDetalleDocEmision.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                oDetalleDocEmision.Stock = Stock_;
                //oDetalleDocEmision.LoteProveedor = txtLoteProveedor.Text.Trim();
                //oDetalleDocEmision.Lote = txtLote.Text.Trim();
                oDetalleDocEmision.idListaPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue);
                oDetalleDocEmision.nroOt = null;
                oDetalleDocEmision.indCalculo = chkCalculo.Checked;
                oDetalleDocEmision.TipoImpSelectivo = cboImpSelectivo.SelectedValue.ToString();
                oDetalleDocEmision.indDetraccion = chkDetra.Checked;
                oDetalleDocEmision.tipDetraccion = txtTipDetra.Text;
                oDetalleDocEmision.TasaDetraccion = Convert.ToDecimal(txtTasa.Text);

                if (oDetalleDocEmision.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oDetalleDocEmision.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oDetalleDocEmision.FechaRegistro = VariablesLocales.FechaHoy;
                    oDetalleDocEmision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalleDocEmision.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    oDetalleDocEmision.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oDetalleDocEmision.FechaModificacion = VariablesLocales.FechaHoy;
                }
            }
        }

        void PonerIsc()
        {
            if (cboImpSelectivo.SelectedValue.ToString() == "P")
            {
                lblTitIsc.Text = "X %";
                txtPorIsc.Text = "25.00";
            }
            else if (cboImpSelectivo.SelectedValue.ToString() == "L")
            {
                lblTitIsc.Text = "X Lt.";
                txtPorIsc.Text = "1.50";
            }
            else if (cboImpSelectivo.SelectedValue.ToString() == "N")
            {
                lblTitIsc.Text = "";
                txtPorIsc.Text = "0.00";
            }
        }

        void CalcularReves()
        {
            txtPrecio.TextChanged -= txtPrecio_TextChanged;
            txtCantidad.TextChanged -= txtCantidad_TextChanged;

            Decimal Total = Variables.ValorCeroDecimal;
            Decimal subTotal = Variables.ValorCeroDecimal;
            Decimal CantidadOrd = Variables.ValorCeroDecimal;
            Decimal PrecioUnitario = Variables.ValorCeroDecimal;
            Decimal porIgv = Variables.Cero;

            Decimal.TryParse(txtPrecioVenta.Text, out Total);
            Decimal.TryParse(txtCantidad.Text, out CantidadOrd);
            Decimal.TryParse(txtPrecio.Text, out PrecioUnitario);

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorIgv.Text, out porIgv);
            subTotal = Total / ((porIgv / 100) + 1);
            txtIgv.Text = (subTotal * (porIgv / 100)).ToString("N2");

            //Sub Total
            txtSubTotal.Text = subTotal.ToString("N2");
            txtValorVenta.Text = subTotal.ToString("N2");

            //Cantidad y Precio Unitario
            if (CantidadOrd > 0)
            {
                PrecioUnitario = subTotal / CantidadOrd;
                txtPrecio.Text = PrecioUnitario.ToString("N5");
            }
            else if (PrecioUnitario > 0)
            {
                CantidadOrd = subTotal / PrecioUnitario;
                txtCantidad.Text = CantidadOrd.ToString("N4");
            }

            txtPrecio.TextChanged += txtPrecio_TextChanged;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Tipo == "P" || Tipo == "C") ////////////////////////// PEDIDOS y COTIZACIONES /////////////////////////////////
            {
                if (oDetalle == null)
                {
                    oDetalle = new PedidoDetE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal,
                        Opcion = (Int32)EnumOpcionGrabar.Insertar
                    };

                    cboImpSelectivo.SelectedValue = "N";
                    chkIgv.Checked = VariablesLocales.oVenParametros.indIgv;

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();
                }
                else
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                    QuitarEventos("S");

                    cboAlmacen.SelectedValue = Convert.ToInt32(oDetalle.idAlmacen);
                    txtIdArticulo.Text = oDetalle.idArticulo.ToString();
                    txtCodArticulo.Text = oDetalle.codArticulo;
                    txtDesArticulo.Text = oDetalle.nomArticulo;
                    txtCapacidad.Text = oDetalle.Capacidad.ToString("N3");
                    txtContenido.Text = oDetalle.Contenido.ToString("N3");
                    //txtLote.Text = oDetalle.Lote;
                    cboListaPrecio.SelectedValue = Convert.ToInt32(oDetalle.idTipoPrecio);
                    txtPrecio.Text = oDetalle.PrecioUnitario.ToString("N5");
                    txtCantidad.Text = oDetalle.Cantidad.ToString("N4");
                    chkCalculo.Checked = oDetalle.indCalculo;
                    txtPor1.Text = oDetalle.porDscto1.ToString("N2");
                    txtDscto1.Text = Convert.ToDecimal(oDetalle.Dscto1).ToString("N2");
                    txtPor2.Text = oDetalle.porDscto2.ToString("N2");
                    txtDscto2.Text = Convert.ToDecimal(oDetalle.Dscto2).ToString("N2");
                    txtPor3.Text = oDetalle.porDscto3.ToString("N2");
                    txtDscto3.Text = Convert.ToDecimal(oDetalle.Dscto3).ToString("N2");
                    cboImpSelectivo.SelectedValue = String.IsNullOrWhiteSpace(oDetalle.TipoImpSelectivo.Trim()) ? "N" : oDetalle.TipoImpSelectivo.ToString();
                    txtPorIsc.Text = oDetalle.porIsc.ToString("N2");
                    txtIsc.Text = oDetalle.Isc.ToString("N2");
                    txtSubTotal.Text = Convert.ToDecimal(oDetalle.PrecioUnitario * oDetalle.Cantidad).ToString("N2");
                    txtValorVenta.Text = oDetalle.subTotal.ToString("N2");
                    txtPrecioVenta.Text = oDetalle.Total.ToString("N2");

                    if (oDetalle.flgIgv)
                    {
                        chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                        chkIgv.Checked = oDetalle.flgIgv;
                        txtPorIgv.Text = oDetalle.porIgv.ToString("N2");
                        txtIgv.Text = oDetalle.Igv.ToString("N2");
                        chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                    }
                    else
                    {
                        txtPorIgv.Text = "0.00";
                        txtIgv.Text = "0.00";
                    }

                    chkDetra.Checked = oDetalle.indDetraccion;
                    txtTipDetra.Text = oDetalle.tipDetraccion;
                    txtTasa.Text = oDetalle.TasaDetraccion.ToString();

                    txtUsuarioRegistro.Text = oDetalle.UsuarioRegistro;
                    txtFechaRegistro.Text = oDetalle.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oDetalle.UsuarioModificacion;
                    txtFechaModifica.Text = oDetalle.FechaModificacion.ToString();

                    oDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                    QuitarEventos("N");
                    PonerIsc();
                }
            }
            else //////////////////////////////// DOCUMENTO DE EMISION //////////////////////////////////////
            {
                #region Documentos de Emision

                if (oDetalleDocEmision == null)
                {
                    oDetalleDocEmision = new EmisionDocumentoDetE();
                    oDetalleDocEmision.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oDetalleDocEmision.idLocal = VariablesLocales.SesionLocal.IdLocal;

                    //cboTipoUnidad.SelectedValue = Variables.Cero;
                    //cboTipoUnidad_SelectionChangeCommitted(new object(), new EventArgs());
                    cboImpSelectivo.SelectedValue = "N";
                    chkIgv.Checked = VariablesLocales.oVenParametros.indIgv;

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                    oDetalleDocEmision.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    txtCodArticulo.Text = oDetalleDocEmision.codArticulo;
                    txtIdArticulo.Text = oDetalleDocEmision.idArticulo.ToString();
                    txtDesArticulo.Text = oDetalleDocEmision.nomArticulo;

                    //Quitando los eventos
                    txtCantidad.TextChanged -= txtCantidad_TextChanged;
                    txtPrecio.TextChanged -= txtPrecio_TextChanged;
                    txtPor1.TextChanged -= txtPor1_TextChanged;
                    txtPor2.TextChanged -= txtPor2_TextChanged;
                    txtPor3.TextChanged -= txtPor3_TextChanged;

                    txtPor1.Text = oDetalleDocEmision.porDscto1.ToString("N2");
                    txtPor2.Text = oDetalleDocEmision.porDscto2.ToString("N2");
                    txtPor3.Text = oDetalleDocEmision.porDscto3.ToString("N2");

                    //Agregando nuevamente los eventos
                    txtCantidad.TextChanged += txtCantidad_TextChanged;
                    txtPrecio.TextChanged += txtPrecio_TextChanged;
                    txtPor1.TextChanged += txtPor1_TextChanged;
                    txtPor2.TextChanged += txtPor2_TextChanged;
                    txtPor3.TextChanged += txtPor3_TextChanged;
                    cboImpSelectivo.SelectedValue = String.IsNullOrWhiteSpace(oDetalleDocEmision.TipoImpSelectivo.Trim()) ? "N" : oDetalleDocEmision.TipoImpSelectivo.ToString();
                    txtCantidad.Text = Convert.ToDecimal(oDetalleDocEmision.Cantidad).ToString("N4");
                    txtPrecio.Text = oDetalleDocEmision.PrecioSinImpuesto.ToString("N5");

                    //if (oDetalleDocEmision.flgIgv)
                    //{
                    //    chkIgv.Checked = true;
                    //}

                    if (oDetalleDocEmision.flgIgv)
                    {
                        chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                        chkIgv.Checked = oDetalleDocEmision.flgIgv;
                        txtPorIgv.Text = oDetalleDocEmision.porIgv.ToString("N2");
                        txtIgv.Text = oDetalleDocEmision.Igv.ToString("N2");
                        chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                    }
                    else
                    {
                        txtPorIgv.Text = "0.00";
                        txtIgv.Text = "0.00";
                    }

                    txtPorIsc.Text = oDetalleDocEmision.porIsc.ToString("N2");
                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oDetalleDocEmision.idTipoMedida);
                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oDetalleDocEmision.idUnidadMedida);
                    cboAlmacen.SelectedValue = Convert.ToInt32(oDetalleDocEmision.idAlmacen);
                    //txtStock.Text = oDetalleDocEmision.Stock.ToString("N4");
                    //txtLote.Text = oDetalleDocEmision.Lote;
                    //txtLoteProveedor.Text = oDetalleDocEmision.LoteProveedor;
                    //txtOt.Text = oDetalleDocEmision.nroOt.ToString();
                    chkCalculo.Checked = oDetalleDocEmision.indCalculo;

                    chkDetra.Checked = oDetalleDocEmision.indDetraccion;
                    txtTipDetra.Text = oDetalleDocEmision.tipDetraccion;
                    txtTasa.Text = oDetalleDocEmision.TasaDetraccion.ToString();

                    txtUsuarioRegistro.Text = oDetalleDocEmision.UsuarioRegistro;
                    txtFechaRegistro.Text = oDetalleDocEmision.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oDetalleDocEmision.UsuarioModificacion;
                    txtFechaModifica.Text = oDetalleDocEmision.FechaModificacion.ToString();

                    oDetalleDocEmision.Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                } 

                #endregion
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    Decimal Cantidad = Variables.ValorCeroDecimal;
                    Decimal PrecioSinImpuesto = Variables.ValorCeroDecimal;
                    Decimal Stock = Variables.ValorCeroDecimal;
                    Decimal.TryParse(txtCantidad.Text, out Cantidad);
                    Decimal.TryParse(txtPrecio.Text, out PrecioSinImpuesto);
                    //Decimal.TryParse(txtStock.Text, out Stock);
                    Decimal PrecioConImpuesto = Variables.Cero;
                    Decimal porIgv = Variables.Cero;
                    Decimal ValorVenta = Variables.Cero;
                    Decimal Igv = Variables.Cero;

                    if (chkIgv.Checked)
                    {
                        Decimal.TryParse(txtPorIgv.Text, out porIgv);
                        PrecioConImpuesto = (PrecioSinImpuesto * (porIgv / 100)) + PrecioSinImpuesto;
                    }
                    else
                    {
                        PrecioConImpuesto = PrecioSinImpuesto;
                    }

                    if (oDetalle != null)
                    {
                        AceptarDetalle(Cantidad, PrecioSinImpuesto, PrecioConImpuesto, Stock);
                    }

                    if (oDetalleDocEmision != null)
                    {
                        AceptarDetalle(Cantidad, PrecioSinImpuesto, PrecioConImpuesto, Stock);
                    }

                    for (int i = 0; i < oListaDetallePedidos.Count; i++)
                    {                     
                        if (i == 0)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido1.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);
                           

                            if (txtPedido1.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 1)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido2.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido2.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 2)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido3.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido3.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 3)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido4.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido4.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 4)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido5.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido5.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 5)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido6.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido6.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 6)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido7.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido7.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }
                        }
                        else if (i == 7)
                        {
                            oListaDetallePedidos[i].Cantidad = Convert.ToDecimal(txtPedido8.Text);
                            oListaDetallePedidos[i].PrecioConImpuesto = PrecioConImpuesto;
                            oListaDetallePedidos[i].PrecioUnitario = PrecioSinImpuesto;
                            ValorVenta = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            oListaDetallePedidos[i].subTotal = PrecioSinImpuesto * oListaDetallePedidos[i].Cantidad;
                            Igv = (ValorVenta) * (porIgv / 100);
                            oListaDetallePedidos[i].Igv = Igv;
                            oListaDetallePedidos[i].Total = (ValorVenta + Igv);

                            if (txtPedido8.Text != "0")
                            {
                                Contador++;
                                oListaDetallePedidos[i].idItem = Contador;
                                oListaDetallePedidos[i].UsuarioRegistro = txtUsuarioRegistro.Text;
                                oListaDetallePedidos[i].FechaRegistro = VariablesLocales.FechaHoy;
                                oListaDetallePedidos[i].UsuarioModificacion = txtUsuarioMod.Text;
                                oListaDetallePedidos[i].FechaModificacion = VariablesLocales.FechaHoy;
                            }                        
                        }
                    }


                    foreach (PedidoDetE item in oListaDetallePedidos)
                    {
                        if (item.Cantidad != 0)
                        {
                            oListaDetallePedidosGeneral.Add(item);
                        }                       
                    }                                           

                    base.Aceptar(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
            {
                Global.MensajeComunicacion("Debe escoger un almacen.");
                cboAlmacen.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe escoger un articulo.");
                btBuscarArticulo.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtCantidad.Text.Trim()) || txtCantidad.Text == "0.00")
            {
                Global.MensajeComunicacion("Debe colocar la cantidad.");
                txtCantidad.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtPrecio.Text.Trim()) || txtPrecio.Text == "0.00" || txtPrecio.Text == "0.00000")
            {
                Global.MensajeComunicacion("Debe la colocar el precio.");
                txtPrecio.Focus();
                return false;
            }

            if (chkIgv.Checked && (String.IsNullOrEmpty(txtIgv.Text.Trim()) || txtIgv.Text == "0.00"))
            {
                Global.MensajeComunicacion("Error Deberia Calcular el Igv.");
                chkIgv.Focus();
                return false;
            }

            if (!chkIgv.Checked && txtIgv.Text != "0.00")
            {
                Global.MensajeComunicacion("Error No Deberia Calcular el Igv.");
                chkIgv.Focus();
                return false;
            }

            //if (((AlmacenE)cboAlmacen.SelectedItem).VerificaStock)
            //{
            //    if (Tipo == "P" || Tipo == "C")
            //    {
            //        if (oListaDetalle != null && oListaDetalle.Count > Variables.Cero)
            //        {
            //            List<PedidoDetE> oListaTemp = new List<PedidoDetE>((from x in oListaDetalle
            //                                                                where x.idArticulo == Convert.ToInt32(txtIdArticulo.Text.Trim())
            //                                                                && x.codArticulo == txtCodArticulo.Text.Trim()
            //                                                                && x.Lote == txtLote.Text.Trim()
            //                                                                && x.indCalculo == chkCalculo.Checked
            //                                                                select x).ToList());
            //            if (oDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            //            {
            //                if (oListaTemp.Count > 0)
            //                {
            //                    Global.MensajeFault("El articulo ya se encuentra añadido en la lista, cambie de código o modifique el articulo correspondiente.");
            //                    oListaTemp = null;
            //                    btBuscarArticulo.Focus();
            //                    return false;
            //                }
            //            }
            //        }
            //    }
            //    else if (Tipo == "G")
            //    {
            //        if (oListaEmisionDocumentos != null && oListaEmisionDocumentos.Count > Variables.Cero)
            //        {
            //            List<EmisionDocumentoDetE> oListaTemp = new List<EmisionDocumentoDetE>((from x in oListaEmisionDocumentos
            //                                                                                    where x.idArticulo == Convert.ToInt32(txtIdArticulo.Text.Trim())
            //                                                                                    && x.codArticulo == txtCodArticulo.Text.Trim()
            //                                                                                    && x.Lote == txtLote.Text.Trim()
            //                                                                                    && x.indCalculo == chkCalculo.Checked
            //                                                                                    select x).ToList());
            //            if (oDetalleDocEmision.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            //            {
            //                if (oListaTemp.Count > Variables.Cero)
            //                {
            //                    Global.MensajeFault("El articulo ya se encuentra añadido en la lista, cambie de código o modifique el articulo correspondiente.");
            //                    oListaTemp = null;
            //                    btBuscarArticulo.Focus();
            //                    return false;
            //                }
            //            }
            //        }
            //    }

            //    if (Tipo != "C" && Convert.ToInt32(cboListaPrecio.SelectedValue) == 0)
            //    {
            //        Decimal Stock = Variables.Cero;
            //        Decimal Cantidad = Variables.Cero;
            //        Decimal.TryParse(txtStock.Text, out Stock);
            //        Decimal.TryParse(txtCantidad.Text, out Cantidad);

            //        if (Cantidad > Stock)
            //        {
            //            Global.MensajeComunicacion("No hay stock suficiente. Escoja otro producto.");
            //            txtCantidad.Focus();
            //            return false;
            //        }
            //    }
            //}

            //if (EsCoti == "N")
            //{
            //    if (!VariablesLocales.SesionUsuario.Empresa.indCalzado)
            //    {
            //        if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //        {
            //            LoteE oLote = AgenteAlmacen.Proxy.BuscarLoteExistente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtLote.Text.Trim());

            //            if (oLote == null)
            //            {
            //                Global.MensajeComunicacion("El articulo que ha escogido, su NRO. DE LOTE NO EXISTE.");
            //                return false;
            //            }
            //        }  
            //    }
            //}

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmDetallePedidoNacional_Load(object sender, EventArgs e)
        {
            try
            {
                if (Tipo == "P")
                {
                    lblTituloPrincipal.Text = "Linea Pedido";
                }
                else if (Tipo == "C")
                {
                    lblTituloPrincipal.Text = "Linea de Cotización";
                }
                else if (Tipo == "G")
                {
                    lblTituloPrincipal.Text = "Linea Documento de Venta";
                }

                Nuevo();
                txtCodArticulo.Focus();

                if (idAlmacenTmp != 0) //Para la solicitud de factura
                {
                    cboAlmacen.SelectedValue = idAlmacenTmp;
                    pnlBase.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
                {
                    Global.MensajeComunicacion("Primero tiene que escoger un almacén.");
                    return;
                }

                if (VariablesLocales.oVenParametros == null)
                {
                    Global.MensajeComunicacion("Falta configurar los Parámetros de Ventas");
                    return;
                }

                AlmacenE oAlmacen = (AlmacenE)cboAlmacen.SelectedItem;
                String TipoConsulta = String.Empty;
                frmBuscarArticulo oFrm = null;

                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                QuitarEventos("S");

                if (!oAlmacen.VerificaStock)
                {
                    TipoConsulta = "";

                    if (VariablesLocales.oVenParametros.indListaPrecio && Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                    {
                        frmBuscarArticulosListaPrecio oFrmBuscarArtiLista = new frmBuscarArticulosListaPrecio(oAlmacen, "ConListaPrecio", Convert.ToInt32(cboListaPrecio.SelectedValue), FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"));

                        if (oFrmBuscarArtiLista.ShowDialog() == DialogResult.OK && oFrmBuscarArtiLista.Articulo != null)
                        {
                            List<ArticuloServE> ListaArticulosDet = AgenteMaestro.Proxy.ArticulosPorArticuloCodArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oAlmacen.idAlmacen, FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), oFrmBuscarArtiLista.Articulo.idArticulo, oFrmBuscarArtiLista.Articulo.codArticulo);
                            oListaDetallePedidos = new List<PedidoDetE>();

                            foreach (ArticuloServE item in ListaArticulosDet)
                            {
                                PedidoDetE oDetalleTmp = new PedidoDetE
                                {
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idArticulo = item.idArticulo,
                                    codArticulo = item.codArticulo,
                                    nomArticulo = item.nomArticulo,
                                    idTipoArticulo = item.idTipoArticulo,
                                    Capacidad = item.Capacidad,
                                    Stock = item.Stock,
                                    Lote = item.Lote,
                                    TipoImpSelectivo = item.TipoImpSelectivo,
                                    flgIgv = item.flgigv,
                                    porIgv = item.porigv,
                                    Igv = item.igv,
                                    idUMedida = item.codUniMedAlmacen,
                                    Contenido = item.Contenido,
                                    nroOt = "",
                                    idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue),
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                };
                                oDetalleTmp.idLocal = VariablesLocales.SesionLocal.IdLocal;

                                oListaDetallePedidos.Add(oDetalleTmp);
                            }

                            for (int i = 0; i < oListaDetallePedidos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    txtTalla1.Text = ListaArticulosDet[i].Lote;
                                    txtStock1.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido1.Enabled = true;
                                    txtPedido1.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 1)
                                {
                                    txtTalla2.Text = ListaArticulosDet[i].Lote;
                                    txtStock2.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido2.Enabled = true;
                                    txtPedido2.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 2)
                                {
                                    txtTalla3.Text = ListaArticulosDet[i].Lote;
                                    txtStock3.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido3.Enabled = true;
                                    txtPedido3.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 3)
                                {
                                    txtTalla4.Text = ListaArticulosDet[i].Lote;
                                    txtStock4.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido4.Enabled = true;
                                    txtPedido4.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 4)
                                {
                                    txtTalla5.Text = ListaArticulosDet[i].Lote;
                                    txtStock5.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido5.Enabled = true;
                                    txtPedido5.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 5)
                                {
                                    txtTalla6.Text = ListaArticulosDet[i].Lote;
                                    txtStock6.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido6.Enabled = true;
                                    txtPedido6.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 6)
                                {
                                    txtTalla7.Text = ListaArticulosDet[i].Lote;
                                    txtStock7.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido7.Enabled = true;
                                    txtPedido7.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 7)
                                {
                                    txtTalla8.Text = ListaArticulosDet[i].Lote;
                                    txtStock8.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido8.Enabled = true;
                                    txtPedido8.BackColor = System.Drawing.Color.White;
                                }
                            }
                            txtIdArticulo.Text = oFrmBuscarArtiLista.Articulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrmBuscarArtiLista.Articulo.codArticulo;
                            txtDesArticulo.Text = oFrmBuscarArtiLista.Articulo.nomArticulo;

                            ////De la lista de precio
                            txtPrecio.Text = oFrmBuscarArtiLista.Articulo.PrecioBruto.ToString("N6");
                            //txtCantidad.Text = "1.00";
                            //txtPor1.Text = oFrmBuscarArtiLista.Articulo.PorDscto1.ToString("N2");
                            //txtDscto1.Text = oFrmBuscarArtiLista.Articulo.PorDscto1.ToString("N2");
                            //cboImpSelectivo.SelectedValue = oFrmBuscarArtiLista.Articulo.TipoImpSelectivo.ToString();
                            //txtPorIsc.Text = oFrmBuscarArtiLista.Articulo.porisc.ToString("N2");
                            //txtIsc.Text = oFrmBuscarArtiLista.Articulo.isc.ToString("N2");
                            //txtSubTotal.Text = oFrmBuscarArtiLista.Articulo.PrecioBruto.ToString("N2");
                            //txtValorVenta.Text = oFrmBuscarArtiLista.Articulo.PrecioValorVenta.ToString("N2");
                            //txtPrecioVenta.Text = oFrmBuscarArtiLista.Articulo.PrecioVenta.ToString("N2");
                            //txtCapacidad.Text = oFrmBuscarArtiLista.Articulo.Capacidad.ToString("N2");
                            //txtContenido.Text = oFrmBuscarArtiLista.Articulo.Contenido.ToString("N2");
                            //chkIgv.Checked = oFrmBuscarArtiLista.Articulo.flgigv;

                            //if (chkIgv.Checked)
                            //{
                            //    txtPorIgv.Text = oFrmBuscarArtiLista.Articulo.porigv.ToString("N2");
                            //    txtIgv.Text = oFrmBuscarArtiLista.Articulo.igv.ToString("N2");
                            //}
                            //else
                            //{
                            //    txtPorIgv.Text = "0.00";
                            //    txtIgv.Text = "0.00";
                            //}

                            //if (oFrm.Articulo.indDetraccion)
                            //{
                            //    chkDetra.Checked = oFrm.Articulo.indDetraccion;
                            //    txtTipDetra.Text = oFrm.Articulo.tipDetraccion;

                            //    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.Articulo.tipDetraccion);

                            //    if (DetraccionDet != null && DetraccionDet.Count > 0)
                            //    {
                            //        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                            //    }
                            //    else
                            //    {
                            //        txtTasa.Text = "0.00";
                            //    }
                            //}
                            //else
                            //{
                            //    chkDetra.Checked = false;
                            //    txtTipDetra.Text = String.Empty;
                            //    txtTasa.Text = "0.00";
                            //}

                            //PonerIsc();
                        }
                    }
                    else
                    {
                        oFrm = new frmBuscarArticulo(oAlmacen, TipoConsulta, Convert.ToInt32(cboListaPrecio.SelectedValue));

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
                        {
                            txtCodArticulo.Text = oFrm.Articulo.codArticulo;
                            txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                            txtDesArticulo.Text = oFrm.Articulo.nomArticulo;

                            if (oFrm.Articulo.indDetraccion)
                            {
                                chkDetra.Checked = oFrm.Articulo.indDetraccion;
                                txtTipDetra.Text = oFrm.Articulo.tipDetraccion;

                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.Articulo.tipDetraccion);

                                if (DetraccionDet != null && DetraccionDet.Count > 0)
                                {
                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                }
                                else
                                {
                                    txtTasa.Text = "0.00";
                                }
                            }
                            else
                            {
                                chkDetra.Checked = false;
                                txtTipDetra.Text = String.Empty;
                                txtTasa.Text = "0.00";
                            }
                        }
                    }
                }
                else
                {
                    if (VariablesLocales.oVenParametros.indListaPrecio && Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                    {
                        //Antes estaba con ConListaPrecio, se cambio por ConListaPrecioStock
                        frmBuscarArticulosListaPrecio oFrmBuscarArtiLista = new frmBuscarArticulosListaPrecio(oAlmacen, "ConListaPrecioStock", Convert.ToInt32(cboListaPrecio.SelectedValue), FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"));

                        if (oFrmBuscarArtiLista.ShowDialog() == DialogResult.OK && oFrmBuscarArtiLista.Articulo != null)
                        {
                            List<ArticuloServE> ListaArticulosDet = AgenteMaestro.Proxy.ArticulosPorArticuloCodArticulo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oAlmacen.idAlmacen, FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), oFrmBuscarArtiLista.Articulo.idArticulo, oFrmBuscarArtiLista.Articulo.codArticulo);
                            oListaDetallePedidos = new List<PedidoDetE>();

                            foreach (ArticuloServE item in ListaArticulosDet)
                            {
                                PedidoDetE oDetalleTmp = new PedidoDetE
                                {
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idArticulo = item.idArticulo,
                                    codArticulo = item.codArticulo,
                                    nomArticulo = item.nomArticulo,
                                    idTipoArticulo = item.idTipoArticulo,
                                    Capacidad = item.Capacidad,
                                    Stock = item.Stock,
                                    Lote = item.Lote,
                                    TipoImpSelectivo = item.TipoImpSelectivo,
                                    flgIgv = item.flgigv,
                                    porIgv = item.porigv,
                                    Igv = item.igv,
                                    idUMedida = item.codUniMedAlmacen,
                                    Contenido = item.Contenido,
                                    idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue),
                                    indCalculo = chkCalculo.Checked,
                                    idTipoPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue),
                                    nroOt = String.Empty
                                };

                                oListaDetallePedidos.Add(oDetalleTmp);
                            }

                            for (int i = 0; i < oListaDetallePedidos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    txtTalla1.Text = ListaArticulosDet[i].Lote;
                                    txtStock1.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido1.Enabled = true;
                                    txtPedido1.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 1)
                                {
                                    txtTalla2.Text = ListaArticulosDet[i].Lote;
                                    txtStock2.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido2.Enabled = true;
                                    txtPedido2.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 2)
                                {
                                    txtTalla3.Text = ListaArticulosDet[i].Lote;
                                    txtStock3.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido3.Enabled = true;
                                    txtPedido3.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 3)
                                {
                                    txtTalla4.Text = ListaArticulosDet[i].Lote;
                                    txtStock4.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido4.Enabled = true;
                                    txtPedido4.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 4)
                                {
                                    txtTalla5.Text = ListaArticulosDet[i].Lote;
                                    txtStock5.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido5.Enabled = true;
                                    txtPedido5.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 5)
                                {
                                    txtTalla6.Text = ListaArticulosDet[i].Lote;
                                    txtStock6.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido6.Enabled = true;
                                    txtPedido6.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 6)
                                {
                                    txtTalla7.Text = ListaArticulosDet[i].Lote;
                                    txtStock7.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido7.Enabled = true;
                                    txtPedido7.BackColor = System.Drawing.Color.White;
                                }
                                else if (i == 7)
                                {
                                    txtTalla8.Text = ListaArticulosDet[i].Lote;
                                    txtStock8.Text = ListaArticulosDet[i].Stock.ToString();
                                    txtPedido8.Enabled = true;
                                    txtPedido8.BackColor = System.Drawing.Color.White;
                                }
                            }

                            txtIdArticulo.Text = oFrmBuscarArtiLista.Articulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrmBuscarArtiLista.Articulo.codArticulo;
                            txtDesArticulo.Text = oFrmBuscarArtiLista.Articulo.nomArticulo;

                            ////De la lista de precio
                            txtPrecio.Text = oFrmBuscarArtiLista.Articulo.PrecioBruto.ToString("N6");
                        }
                    }
                    else
                    {
                        String CotiPed = String.Empty;

                        if (Tipo == "C") //Si esta cotización
                        {
                            CotiPed = "S";
                        }
                        else
                        {
                            CotiPed = "N";
                        }

                        frmBuscarArticuloPedido oFrmPedido = null;

                        if (oAlmacen.VerificaStock)
                        {
                            oFrmPedido = new frmBuscarArticuloPedido(oAlmacen, "stock", FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), CotiPed);
                        }
                        else
                        {
                            oFrmPedido = new frmBuscarArticuloPedido(oAlmacen, "arti", FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), CotiPed);
                        }

                        if (oFrmPedido.ShowDialog() == DialogResult.OK && oFrmPedido.Articulo != null)
                        {
                            txtIdArticulo.Text = oFrmPedido.Articulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrmPedido.Articulo.codArticulo;
                            txtDesArticulo.Text = oFrmPedido.Articulo.nomArticulo;

                            if (oFrmPedido.Articulo.indDetraccion)
                            {
                                chkDetra.Checked = oFrmPedido.Articulo.indDetraccion;
                                txtTipDetra.Text = oFrmPedido.Articulo.tipDetraccion;

                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrmPedido.Articulo.tipDetraccion);

                                if (DetraccionDet != null && DetraccionDet.Count > 0)
                                {
                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                }
                                else
                                {
                                    txtTasa.Text = "0.00";
                                }
                            }
                            else
                            {
                                chkDetra.Checked = false;
                                txtTipDetra.Text = String.Empty;
                                txtTasa.Text = "0.00";
                            }

                            txtPrecio.Focus();
                        }
                    }
                }

                QuitarEventos("N");
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }
            catch (Exception ex)
            {
                QuitarEventos("N");
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                txtCantidad.Text = Global.FormatoDecimal(txtCantidad.Text, 4);
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                txtPrecio.Text = Global.FormatoDecimal(txtPrecio.Text, 5);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgv.Checked)
            {
                ImpuestosPeriodoE objImpuestoPeriodo = VariablesLocales.oListaImpuestos[0];//AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1);
                txtPorIgv.Text = (objImpuestoPeriodo.Porcentaje).ToString();
            }
            else
            {
                txtPorIgv.Text = "0.00";
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void txtCantidad_MouseClick(object sender, MouseEventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            txtPrecio.SelectAll();
        }

        private void txtPrecio_MouseClick(object sender, MouseEventArgs e)
        {
            txtPrecio.SelectAll();
        }

        private void txtPor1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }  
        }

        private void txtPor1_Enter(object sender, EventArgs e)
        {
            txtPor1.SelectAll();
        }

        private void txtPor1_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPor1.Text.Trim()))
            {
                txtPor1.Text = Global.FormatoDecimal(txtPor1.Text);
            }
        }

        private void txtPor1_MouseClick(object sender, MouseEventArgs e)
        {
            txtPor1.SelectAll();
        }

        private void txtPor2_Enter(object sender, EventArgs e)
        {
            txtPor2.SelectAll();
        }

        private void txtPor2_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPor2.Text.Trim()))
            {
                txtPor2.Text = Global.FormatoDecimal(txtPor2.Text);
            }
        }

        private void txtPor2_MouseClick(object sender, MouseEventArgs e)
        {
            txtPor2.SelectAll();
        }

        private void txtPor2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPor3_Enter(object sender, EventArgs e)
        {
            txtPor3.SelectAll();
        }

        private void txtPor3_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPor3.Text.Trim()))
            {
                txtPor3.Text = Global.FormatoDecimal(txtPor3.Text);
            }
        }

        private void txtPor3_MouseClick(object sender, MouseEventArgs e)
        {
            txtPor3.SelectAll();
        }

        private void txtPor3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPorIsc_Enter(object sender, EventArgs e)
        {
            txtPorIsc.SelectAll();
        }

        private void txtPorIsc_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPorIsc.Text.Trim()))
            {
                txtPorIsc.Text = Global.FormatoDecimal(txtPorIsc.Text);
            }
        }

        private void txtPorIsc_MouseClick(object sender, MouseEventArgs e)
        {
            txtPorIsc.SelectAll();
        }

        private void txtPorIsc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtPorIgv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboListaPrecio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtIdArticulo.Text = String.Empty;
                txtCodArticulo.Text = String.Empty;
                txtCapacidad.Text = "0.00";
                txtContenido.Text = "0.00";
                txtDesArticulo.Text = String.Empty;
                txtPrecio.Text = "0.00000";
                txtCantidad.Text = "0";
                chkCalculo.Checked = true;
                cboImpSelectivo.SelectedValue = "N";
                PonerIsc();
                txtCodArticulo.Focus();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = String.Empty;
            txtDesArticulo.Text = String.Empty;
            //txtLote.Text = string.Empty;
            //txtLoteProveedor.Text = string.Empty;
            //cboUnidadMedida.SelectedValue = Variables.Cero;
            //cboTipoUnidad.SelectedValue = Variables.Cero;
            //txtStock.Text = "0.0000";
            chkDetra.Checked = false;
            txtTipDetra.Text = String.Empty;
            txtTasa.Text = "0.00";
        }

        private void txtCodArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && string.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaStock)
                    {
                        if (VariablesLocales.oVenParametros != null)
                        {
                            if (!VariablesLocales.oVenParametros.indListaPrecio && Tipo != "C")
                            {
                                #region Con Stock

                                List<StockE> oListaStock = null;

                                if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                                {
                                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
                                                                                            txtCodArticulo.Text.Trim(), "", EsCoti);
                                }
                                else
                                {
                                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
                                                                                            txtCodArticulo.Text.Trim(), "", EsCoti);
                                }

                                if (oListaStock.Count > 1)
                                {
                                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

                                    if (oFrm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                        //txtLote.Text = oFrm.oArticulo.Lote;
                                        //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
                                        //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

                                        if (oFrm.oArticulo.indDetraccion)
                                        {
                                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                }
                                else if (oListaStock.Count == 1)
                                {
                                    txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                                    txtCodArticulo.Text = oListaStock[0].codArticulo;
                                    txtDesArticulo.Text = oListaStock[0].desArticulo;
                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                                    //txtLote.Text = oListaStock[0].Lote;
                                    //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
                                    //txtStock.Text = oListaStock[0].canStock.ToString("N4");

                                    chkDetra.Checked = oListaStock[0].indDetraccion;
                                    txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                    if (oListaStock[0].indDetraccion)
                                    {
                                        chkDetra.Checked = oListaStock[0].indDetraccion;
                                        txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                                    txtIdArticulo.Text = string.Empty;
                                    txtCodArticulo.Text = string.Empty;
                                    txtDesArticulo.Text = string.Empty;
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";
                                    txtCodArticulo.Focus();
                                }

                                #endregion
                            }
                            else
                            {
                                if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                {
                                    #region Con Lista de Precios

                                    QuitarEventos("S");
                                    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                                        txtCodArticulo.Text.Trim(), "", Convert.ToInt32(cboListaPrecio.SelectedValue));
                                    if (oListaArticulos.Count > 1)
                                    {
                                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

                                        if (oFrm.ShowDialog() == DialogResult.OK)
                                        {
                                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                            //txtLote.Text = "0000000";
                                            //txtStock.Text = "0.0000";
                                            //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                            //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

                                            //De la lista de precio
                                            txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
                                            txtCantidad.Text = "1.00";
                                            txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                            txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                            cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
                                            txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
                                            txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
                                            txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
                                            txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
                                            txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
                                            txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
                                            txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
                                            chkIgv.Checked = oFrm.oArticulo.flgigv;

                                            if (chkIgv.Checked)
                                            {
                                                txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
                                                txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
                                            }
                                            else
                                            {
                                                txtPorIgv.Text = "0.00";
                                                txtIgv.Text = "0.00";
                                            }

                                            if (oFrm.oArticulo.indDetraccion)
                                            {
                                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                                if (DetraccionDet != null && DetraccionDet.Count > 0)
                                                {
                                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                                }
                                                else
                                                {
                                                    txtTasa.Text = "0.00";
                                                }
                                            }
                                            else
                                            {
                                                chkDetra.Checked = false;
                                                txtTipDetra.Text = String.Empty;
                                                txtTasa.Text = "0.00";
                                            }

                                            PonerIsc();
                                        }
                                    }
                                    else if (oListaArticulos.Count == 1)
                                    {
                                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";
                                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

                                        //De la lista de precio
                                        txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
                                        txtCantidad.Text = "1.00";
                                        txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                        txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                        cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
                                        txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
                                        txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
                                        txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
                                        txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
                                        txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
                                        txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
                                        txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
                                        chkIgv.Checked = oListaArticulos[0].flgigv;

                                        if (chkIgv.Checked)
                                        {
                                            txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
                                            txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
                                        }
                                        else
                                        {
                                            txtPorIgv.Text = "0.00";
                                            txtIgv.Text = "0.00";
                                        }

                                        if (oListaArticulos[0].indDetraccion)
                                        {
                                            chkDetra.Checked = oListaArticulos[0].indDetraccion;
                                            txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }

                                        PonerIsc();
                                    }
                                    else
                                    {
                                        Global.MensajeFault("El código ingresado no existe en la Lista de precio escogida, vuelva a probar por favor.");
                                        txtIdArticulo.Text = string.Empty;
                                        txtCodArticulo.Text = string.Empty;
                                        txtDesArticulo.Text = string.Empty;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                        PonerIsc();

                                        txtCodArticulo.Focus();
                                    }

                                    QuitarEventos("N");

                                    #endregion 
                                }
                                else
                                {
                                    #region Con Stock

                                    List<StockE> oListaStock = null;

                                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                                    {
                                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
                                                                                                txtCodArticulo.Text.Trim(), "", EsCoti);
                                    }
                                    else
                                    {
                                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
                                                                                                txtCodArticulo.Text.Trim(), "", EsCoti);
                                    }

                                    if (oListaStock.Count > 1)
                                    {
                                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

                                        if (oFrm.ShowDialog() == DialogResult.OK)
                                        {
                                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
                                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                            //txtLote.Text = oFrm.oArticulo.Lote;
                                            //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
                                            //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

                                            if (oFrm.oArticulo.indDetraccion)
                                            {
                                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                                if (DetraccionDet != null && DetraccionDet.Count > 0)
                                                {
                                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                                }
                                                else
                                                {
                                                    txtTasa.Text = "0.00";
                                                }
                                            }
                                            else
                                            {
                                                chkDetra.Checked = false;
                                                txtTipDetra.Text = String.Empty;
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                    }
                                    else if (oListaStock.Count == 1)
                                    {
                                        txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                                        txtCodArticulo.Text = oListaStock[0].codArticulo;
                                        txtDesArticulo.Text = oListaStock[0].desArticulo;
                                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                                        //txtLote.Text = oListaStock[0].Lote;
                                        //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
                                        //txtStock.Text = oListaStock[0].canStock.ToString("N4");

                                        if (oListaStock[0].indDetraccion)
                                        {
                                            chkDetra.Checked = oListaStock[0].indDetraccion;
                                            txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                                        txtIdArticulo.Text = string.Empty;
                                        txtCodArticulo.Text = string.Empty;
                                        txtDesArticulo.Text = string.Empty;
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                        txtCodArticulo.Focus();
                                    }

                                    #endregion
                                }
                            }
                        }
                        else
                        {
                            #region Con Stock

                            List<StockE> oListaStock = null;

                            if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                            {
                                oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                        Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                        FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
                                                                                        txtCodArticulo.Text.Trim(), "", EsCoti);
                            }
                            else
                            {
                                oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                        Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                        FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
                                                                                        txtCodArticulo.Text.Trim(), "", EsCoti);
                            }

                            if (oListaStock.Count > 1)
                            {
                                frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

                                if (oFrm.ShowDialog() == DialogResult.OK)
                                {
                                    txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                    txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                    txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                    //txtLote.Text = oFrm.oArticulo.Lote;
                                    //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
                                    //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

                                    if (oFrm.oArticulo.indDetraccion)
                                    {
                                        chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                        txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                            }
                            else if (oListaStock.Count == 1)
                            {
                                txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                                txtCodArticulo.Text = oListaStock[0].codArticulo;
                                txtDesArticulo.Text = oListaStock[0].desArticulo;
                                //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
                                //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                                //txtLote.Text = oListaStock[0].Lote;
                                //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
                                //txtStock.Text = oListaStock[0].canStock.ToString("N4");

                                if (oListaStock[0].indDetraccion)
                                {
                                    chkDetra.Checked = oListaStock[0].indDetraccion;
                                    txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

                                    if (DetraccionDet != null && DetraccionDet.Count > 0)
                                    {
                                        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                    }
                                    else
                                    {
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";
                                }
                            }
                            else
                            {
                                Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                                txtIdArticulo.Text = string.Empty;
                                txtCodArticulo.Text = string.Empty;
                                txtDesArticulo.Text = string.Empty;
                                chkDetra.Checked = false;
                                txtTipDetra.Text = String.Empty;
                                txtTasa.Text = "0.00";

                                txtCodArticulo.Focus();
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        #region Sin Stock

                        if (VariablesLocales.oVenParametros != null)
                        {
                            if (!VariablesLocales.oVenParametros.indListaPrecio)
                            {
                                #region Sin Lista de Precios

                                List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                                    txtCodArticulo.Text.Trim(), "");
                                if (oListaArticulos.Count > 1)
                                {
                                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                                    if (oFrm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";

                                        //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

                                        if (oFrm.oArticulo.indDetraccion)
                                        {
                                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                }
                                else if (oListaArticulos.Count == 1)
                                {
                                    txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                                    txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                                    txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.0000";

                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

                                    if (oListaArticulos[0].indDetraccion)
                                    {
                                        chkDetra.Checked = oListaArticulos[0].indDetraccion;
                                        txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
                                    txtIdArticulo.Text = string.Empty;
                                    txtCodArticulo.Text = string.Empty;
                                    txtDesArticulo.Text = string.Empty;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.0000";
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";

                                    txtCodArticulo.Focus();
                                }

                                #endregion  
                            }
                            else
                            {
                                #region Con Lista de Precios

                                QuitarEventos("S");
                                List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                                    txtCodArticulo.Text.Trim(), "", Convert.ToInt32(cboListaPrecio.SelectedValue));
                                if (oListaArticulos.Count > 1)
                                {
                                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

                                    if (oFrm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";
                                        //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

                                        //De la lista de precio
                                        txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
                                        txtCantidad.Text = "1.00";
                                        txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                        txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                        cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
                                        txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
                                        txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
                                        txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
                                        txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
                                        txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
                                        txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
                                        txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
                                        chkIgv.Checked = oFrm.oArticulo.flgigv;

                                        if (chkIgv.Checked)
                                        {
                                            txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
                                            txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
                                        }
                                        else
                                        {
                                            txtPorIgv.Text = "0.00";
                                            txtIgv.Text = "0.00";
                                        }

                                        if (oFrm.oArticulo.indDetraccion)
                                        {
                                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }

                                        PonerIsc();
                                    }
                                }
                                else if (oListaArticulos.Count == 1)
                                {
                                    txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                                    txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                                    txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.0000";
                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

                                    //De la lista de precio
                                    txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
                                    txtCantidad.Text = "1.00";
                                    txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                    txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                    cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
                                    txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
                                    txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
                                    txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
                                    txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
                                    txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
                                    txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
                                    txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
                                    chkIgv.Checked = oListaArticulos[0].flgigv;

                                    if (chkIgv.Checked)
                                    {
                                        txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
                                        txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
                                    }
                                    else
                                    {
                                        txtPorIgv.Text = "0.00";
                                        txtIgv.Text = "0.00";
                                    }

                                    if (oListaArticulos[0].indDetraccion)
                                    {
                                        chkDetra.Checked = oListaArticulos[0].indDetraccion;
                                        txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }

                                    PonerIsc();
                                }
                                else
                                {
                                    Global.MensajeFault("El código ingresado no existe en la Lista de precio escogida, vuelva a probar por favor.");
                                    txtIdArticulo.Text = string.Empty;
                                    txtCodArticulo.Text = string.Empty;
                                    txtDesArticulo.Text = string.Empty;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.0000";
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";
                                    PonerIsc();

                                    txtCodArticulo.Focus();
                                }

                                QuitarEventos("N");

                                #endregion
                            }
                        }

                        #endregion
                    }

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                QuitarEventos("N");
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDesArticulo.Text.Trim()) && string.IsNullOrEmpty(txtCodArticulo.Text.Trim()))
                {
                    txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaStock)
                    {
                        if (VariablesLocales.oVenParametros != null)
                        {
                            if (!VariablesLocales.oVenParametros.indListaPrecio && Tipo != "C")
                            {
                                #region Con Stock

                                List<StockE> oListaStock = null;

                                if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                                {
                                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
                                                                                            "", txtDesArticulo.Text.Trim(), EsCoti);
                                }
                                else
                                {
                                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
                                                                                            "", txtDesArticulo.Text.Trim(), EsCoti);
                                }

                                if (oListaStock.Count > 1)
                                {
                                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

                                    if (oFrm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                        //txtLote.Text = oFrm.oArticulo.Lote;
                                        //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
                                        //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

                                        if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                        {
                                            cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

                                            if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
                                            {
                                                txtPrecio.Focus();
                                            }
                                            else
                                            {
                                                txtCantidad.Focus();
                                            }
                                        }
                                        else
                                        {
                                            txtPrecio.Focus();
                                        }

                                        if (oFrm.oArticulo.indDetraccion)
                                        {
                                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                }
                                else if (oListaStock.Count == 1)
                                {
                                    txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                                    txtCodArticulo.Text = oListaStock[0].codArticulo;
                                    txtDesArticulo.Text = oListaStock[0].desArticulo;
                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                                    //txtLote.Text = oListaStock[0].Lote;
                                    //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
                                    //txtStock.Text = oListaStock[0].canStock.ToString("N2");

                                    if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                    {
                                        cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

                                        if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
                                        {
                                            txtPrecio.Focus();
                                        }
                                        else
                                        {
                                            txtCantidad.Focus();
                                        }
                                    }
                                    else
                                    {
                                        txtPrecio.Focus();
                                    }

                                    if (oListaStock[0].indDetraccion)
                                    {
                                        chkDetra.Checked = oListaStock[0].indDetraccion;
                                        txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                                    txtIdArticulo.Text = string.Empty;
                                    txtCodArticulo.Text = string.Empty;
                                    txtDesArticulo.Text = string.Empty;
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";
                                    txtDesArticulo.Focus();
                                }

                                #endregion
                            }
                            else
                            {
                                if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                {
                                    #region Con Lista de Precios

                                    QuitarEventos("S");
                                    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                                        "", txtDesArticulo.Text.Trim(), Convert.ToInt32(cboListaPrecio.SelectedValue));
                                    if (oListaArticulos.Count > 1)
                                    {
                                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

                                        if (oFrm.ShowDialog() == DialogResult.OK)
                                        {
                                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                            //txtLote.Text = "0000000";
                                            //txtStock.Text = "0.0000";
                                            //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                            //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

                                            //De la lista de precio
                                            txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
                                            txtCantidad.Text = "1.00";
                                            txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                            txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                            cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
                                            txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
                                            txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
                                            txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
                                            txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
                                            txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
                                            txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
                                            txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
                                            chkIgv.Checked = oFrm.oArticulo.flgigv;

                                            if (chkIgv.Checked)
                                            {
                                                txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
                                                txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
                                            }
                                            else
                                            {
                                                txtPorIgv.Text = "0.00";
                                                txtIgv.Text = "0.00";
                                            }

                                            PonerIsc();

                                            if (oFrm.oArticulo.indDetraccion)
                                            {
                                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                                if (DetraccionDet != null && DetraccionDet.Count > 0)
                                                {
                                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                                }
                                                else
                                                {
                                                    txtTasa.Text = "0.00";
                                                }
                                            }
                                            else
                                            {
                                                chkDetra.Checked = false;
                                                txtTipDetra.Text = String.Empty;
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                    }
                                    else if (oListaArticulos.Count == 1)
                                    {
                                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";
                                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

                                        //De la lista de precio
                                        txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
                                        txtCantidad.Text = "1.00";
                                        txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                        txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                        cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
                                        txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
                                        txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
                                        txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
                                        txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
                                        txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
                                        txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
                                        txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
                                        chkIgv.Checked = oListaArticulos[0].flgigv;

                                        if (chkIgv.Checked)
                                        {
                                            txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
                                            txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
                                        }
                                        else
                                        {
                                            txtPorIgv.Text = "0.00";
                                            txtIgv.Text = "0.00";
                                        }

                                        PonerIsc();

                                        if (oListaArticulos[0].indDetraccion)
                                        {
                                            chkDetra.Checked = oListaArticulos[0].indDetraccion;
                                            txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        Global.MensajeFault("La descripción ingresada no existe en la Lista de Precio, vuelva a probar por favor.");
                                        txtIdArticulo.Text = string.Empty;
                                        txtCodArticulo.Text = string.Empty;
                                        txtDesArticulo.Text = string.Empty;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";

                                        PonerIsc();

                                        txtCodArticulo.Focus();
                                    }

                                    QuitarEventos("N");

                                    #endregion 
                                }
                                else
                                {
                                    #region Con Stock

                                    List<StockE> oListaStock = null;

                                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                                    {
                                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
                                                                                                "", txtDesArticulo.Text.Trim(), EsCoti);
                                    }
                                    else
                                    {
                                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
                                                                                                "", txtDesArticulo.Text.Trim(), EsCoti);
                                    }

                                    if (oListaStock.Count > 1)
                                    {
                                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

                                        if (oFrm.ShowDialog() == DialogResult.OK)
                                        {
                                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
                                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                            //txtLote.Text = oFrm.oArticulo.Lote;
                                            //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
                                            //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

                                            if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                            {
                                                cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

                                                if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
                                                {
                                                    txtPrecio.Focus();
                                                }
                                                else
                                                {
                                                    txtCantidad.Focus();
                                                }
                                            }
                                            else
                                            {
                                                txtPrecio.Focus();
                                            }

                                            if (oFrm.oArticulo.indDetraccion)
                                            {
                                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                                if (DetraccionDet != null && DetraccionDet.Count > 0)
                                                {
                                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                                }
                                                else
                                                {
                                                    txtTasa.Text = "0.00";
                                                }
                                            }
                                            else
                                            {
                                                chkDetra.Checked = false;
                                                txtTipDetra.Text = String.Empty;
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                    }
                                    else if (oListaStock.Count == 1)
                                    {
                                        txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                                        txtCodArticulo.Text = oListaStock[0].codArticulo;
                                        txtDesArticulo.Text = oListaStock[0].desArticulo;
                                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                                        //txtLote.Text = oListaStock[0].Lote;
                                        //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
                                        //txtStock.Text = oListaStock[0].canStock.ToString("N2");

                                        if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                        {
                                            cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

                                            if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
                                            {
                                                txtPrecio.Focus();
                                            }
                                            else
                                            {
                                                txtCantidad.Focus();
                                            }
                                        }
                                        else
                                        {
                                            txtPrecio.Focus();
                                        }

                                        if (oListaStock[0].indDetraccion)
                                        {
                                            chkDetra.Checked = oListaStock[0].indDetraccion;
                                            txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                                        txtIdArticulo.Text = string.Empty;
                                        txtCodArticulo.Text = string.Empty;
                                        txtDesArticulo.Text = string.Empty;
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                        txtDesArticulo.Focus();
                                    }

                                    #endregion
                                }
                            }
                        }
                        else
                        {
                            #region Con Stock

                            List<StockE> oListaStock = null;

                            if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
                            {
                                oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                        Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                        FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
                                                                                        "", txtDesArticulo.Text.Trim(), EsCoti);
                            }
                            else
                            {
                                oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                        Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                        FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
                                                                                        "", txtDesArticulo.Text.Trim(), EsCoti);
                            }

                            if (oListaStock.Count > 1)
                            {
                                frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

                                if (oFrm.ShowDialog() == DialogResult.OK)
                                {
                                    txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                    txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                    txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
                                    //txtLote.Text = oFrm.oArticulo.Lote;
                                    //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
                                    //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

                                    if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                    {
                                        cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

                                        if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
                                        {
                                            txtPrecio.Focus();
                                        }
                                        else
                                        {
                                            txtCantidad.Focus();
                                        }
                                    }
                                    else
                                    {
                                        txtPrecio.Focus();
                                    }

                                    if (oFrm.oArticulo.indDetraccion)
                                    {
                                        chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                        txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                            }
                            else if (oListaStock.Count == 1)
                            {
                                txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
                                txtCodArticulo.Text = oListaStock[0].codArticulo;
                                txtDesArticulo.Text = oListaStock[0].desArticulo;
                                //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
                                //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
                                //txtLote.Text = oListaStock[0].Lote;
                                //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
                                //txtStock.Text = oListaStock[0].canStock.ToString("N4");

                                if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
                                {
                                    cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

                                    if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
                                    {
                                        txtPrecio.Focus();
                                    }
                                    else
                                    {
                                        txtCantidad.Focus();
                                    }
                                }
                                else
                                {
                                    txtPrecio.Focus();
                                }

                                if (oListaStock[0].indDetraccion)
                                {
                                    chkDetra.Checked = oListaStock[0].indDetraccion;
                                    txtTipDetra.Text = oListaStock[0].tipDetraccion;

                                    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

                                    if (DetraccionDet != null && DetraccionDet.Count > 0)
                                    {
                                        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                    }
                                    else
                                    {
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";
                                }
                            }
                            else
                            {
                                Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                                txtIdArticulo.Text = string.Empty;
                                txtCodArticulo.Text = string.Empty;
                                txtDesArticulo.Text = string.Empty;
                                chkDetra.Checked = false;
                                txtTipDetra.Text = String.Empty;
                                txtTasa.Text = "0.00";
                                txtDesArticulo.Focus();
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        #region Sin Stock

                        if (VariablesLocales.oVenParametros != null)
                        {
                            if (!VariablesLocales.oVenParametros.indListaPrecio)
                            {
                                #region Sin Lista de Precios

                                List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                                    "", txtDesArticulo.Text.Trim());
                                if (oListaArticulos.Count > 1)
                                {
                                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

                                    if (oFrm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.0000";

                                        //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

                                        if (oFrm.oArticulo.indDetraccion)
                                        {
                                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                }
                                else if (oListaArticulos.Count == 1)
                                {
                                    txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                                    txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                                    txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.0000";

                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

                                    if (oListaArticulos[0].indDetraccion)
                                    {
                                        chkDetra.Checked = oListaArticulos[0].indDetraccion;
                                        txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
                                    txtIdArticulo.Text = string.Empty;
                                    txtCodArticulo.Text = string.Empty;
                                    txtDesArticulo.Text = string.Empty;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.0000";
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";

                                    txtCodArticulo.Focus();
                                }

                                #endregion  
                            }
                            else
                            {
                                #region Con Lista de Precios

                                QuitarEventos("S");
                                List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
                                                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
                                                                                                                    "", txtDesArticulo.Text.Trim(), Convert.ToInt32(cboListaPrecio.SelectedValue));
                                if (oListaArticulos.Count > 1)
                                {
                                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

                                    if (oFrm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
                                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
                                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
                                        //txtLote.Text = "0000000";
                                        //txtStock.Text = "0.00";
                                        //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
                                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                        //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

                                        //De la lista de precio
                                        txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
                                        txtCantidad.Text = "1.00";
                                        txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                        txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
                                        cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
                                        txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
                                        txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
                                        txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
                                        txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
                                        txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
                                        txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
                                        txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
                                        chkIgv.Checked = oFrm.oArticulo.flgigv;

                                        if (chkIgv.Checked)
                                        {
                                            txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
                                            txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
                                        }
                                        else
                                        {
                                            txtPorIgv.Text = "0.00";
                                            txtIgv.Text = "0.00";
                                        }

                                        PonerIsc();

                                        if (oFrm.oArticulo.indDetraccion)
                                        {
                                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
                                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

                                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

                                            if (DetraccionDet != null && DetraccionDet.Count > 0)
                                            {
                                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                            }
                                            else
                                            {
                                                txtTasa.Text = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            chkDetra.Checked = false;
                                            txtTipDetra.Text = String.Empty;
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                }
                                else if (oListaArticulos.Count == 1)
                                {
                                    txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
                                    txtCodArticulo.Text = oListaArticulos[0].codArticulo;
                                    txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.00";
                                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
                                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
                                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

                                    //De la lista de precio
                                    txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
                                    txtCantidad.Text = "1.00";
                                    txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                    txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
                                    cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
                                    txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
                                    txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
                                    txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
                                    txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
                                    txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
                                    txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
                                    txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
                                    chkIgv.Checked = oListaArticulos[0].flgigv;

                                    if (chkIgv.Checked)
                                    {
                                        txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
                                        txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
                                    }
                                    else
                                    {
                                        txtPorIgv.Text = "0.00";
                                        txtIgv.Text = "0.00";
                                    }

                                    PonerIsc();

                                    if (oListaArticulos[0].indDetraccion)
                                    {
                                        chkDetra.Checked = oListaArticulos[0].indDetraccion;
                                        txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

                                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

                                        if (DetraccionDet != null && DetraccionDet.Count > 0)
                                        {
                                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
                                        }
                                        else
                                        {
                                            txtTasa.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        chkDetra.Checked = false;
                                        txtTipDetra.Text = String.Empty;
                                        txtTasa.Text = "0.00";
                                    }
                                }
                                else
                                {
                                    Global.MensajeFault("La descripción ingresada no existe en la Lista de Precio, vuelva a probar por favor.");
                                    txtIdArticulo.Text = string.Empty;
                                    txtCodArticulo.Text = string.Empty;
                                    txtDesArticulo.Text = string.Empty;
                                    //txtLote.Text = "0000000";
                                    //txtStock.Text = "0.00";
                                    chkDetra.Checked = false;
                                    txtTipDetra.Text = String.Empty;
                                    txtTasa.Text = "0.00";
                                    PonerIsc();

                                    txtCodArticulo.Focus();
                                }

                                QuitarEventos("N");

                                #endregion
                            }
                        }

                        #endregion
                    }

                    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                QuitarEventos("N");
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            if (txtDesArticulo.TextLength == 0)
            {
                txtIdArticulo.Text = String.Empty;
                txtCodArticulo.Text = String.Empty;
                //txtLote.Text = string.Empty;
                //txtLoteProveedor.Text = string.Empty;
                //cboUnidadMedida.SelectedValue = Variables.Cero;
                //cboTipoUnidad.SelectedValue = Variables.Cero;
                //txtStock.Text = "0.0000";
                chkDetra.Checked = false;
                txtTipDetra.Text = String.Empty;
                txtTasa.Text = "0.00";
            }
        }

        private void cboImpSelectivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PonerIsc();
                Calcular();
                //if (cboImpSelectivo.SelectedValue.ToString() == "P")
                //{
                //    lblTitIsc.Text = "X %";
                //    txtPorIsc.Text = "25.00";
                //    Calcular();
                //}
                //else if (cboImpSelectivo.SelectedValue.ToString() == "L")
                //{
                //    lblTitIsc.Text = "X Lt.";
                //    txtPorIsc.Text = "1.50";
                //    Calcular();
                //}
                //else if (cboImpSelectivo.SelectedValue.ToString() == "N")
                //{
                //    lblTitIsc.Text = "";
                //    txtPorIsc.Text = "0.00";
                //    Calcular();
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularReves();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrecioVenta.Text.Trim()))
            {
                txtPrecioVenta.Text = Global.FormatoDecimal(txtPrecioVenta.Text);
            }
        }

        private void txtPedido1_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido3.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido8.Text) + Convert.ToInt32(txtPedido1.Text);
            txtCantidad.Text = totped.ToString();
        }

        private void txtPedido2_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido3.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido8.Text);
            txtCantidad.Text = totped.ToString();
 
        }

        private void txtPedido3_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text) + Convert.ToInt32(txtPedido3.Text)  + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido8.Text);
            txtCantidad.Text = totped.ToString();
        }

        private void txtPedido4_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text)+ Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido3.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido8.Text);
            txtCantidad.Text = totped.ToString();
        }

        private void txtPedido5_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido3.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido8.Text);
            txtCantidad.Text = totped.ToString();
        }

        private void txtPedido6_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido3.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido8.Text);
            txtCantidad.Text = totped.ToString();
        }

        private void txtPedido7_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido3.Text) + Convert.ToInt32(txtPedido8.Text);
            txtCantidad.Text = totped.ToString();
        }

        private void txtPedido8_TextChanged(object sender, EventArgs e)
        {
            Int32 totped = Convert.ToInt32(txtPedido1.Text) + Convert.ToInt32(txtPedido8.Text) + Convert.ToInt32(txtPedido2.Text) + Convert.ToInt32(txtPedido4.Text) + Convert.ToInt32(txtPedido5.Text) + Convert.ToInt32(txtPedido6.Text) + Convert.ToInt32(txtPedido7.Text) + Convert.ToInt32(txtPedido3.Text);
            txtCantidad.Text = totped.ToString();
        }


        #endregion Eventos

    }
}
