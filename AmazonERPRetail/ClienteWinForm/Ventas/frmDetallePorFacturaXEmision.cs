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
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmDetallePorFacturaXEmision : frmResponseBase
    {

        #region Constructores

        public frmDetallePorFacturaXEmision()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            Global.CrearToolTip(btBuscarArticulo, "Buscar Articulos.");
        }

        //Constructor para que no haya duplicados en el detalle de los Pedidos
        public frmDetallePorFacturaXEmision(DateTime Fecha_, List<EmisionDocumentoDetE> conta, NumControlDetE numControl, List<EmisionDocumentoDetE> oLista = null)
            :this()
        {
            FechaPedido = Fecha_;
            Contador = conta.Count;

            if (oLista != null && oLista.Count > Variables.Cero)
            {
                oListaValidacion = oLista;
            }

            //Valores por defecto
            if (numControl != null)
            {
                if (numControl.idAlmacen != 0)
                {
                    cboAlmacen.SelectedValue = numControl.idAlmacen;
                }

                if (numControl.ListaPrecio != 0)
                {
                    cboListaPrecio.SelectedValue = numControl.ListaPrecio;
                }
            }
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public List<EmisionDocumentoDetE> oListaReal = new List<EmisionDocumentoDetE>();
        List<EmisionDocumentoDetE> oListaEmiDetalle = null;
        Int32 Contador = 0;
        List<EmisionDocumentoDetE> oListaValidacion = null;
        DateTime FechaPedido;

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

                oPrecio = null;
            }
            else
            {
                oListaPrecio = new List<ListaPrecioE>
                {
                    new ListaPrecioE() { idListaPrecio = Variables.Cero, Nombre = Variables.Escoger }
                };

                ComboHelper.LlenarCombos<ListaPrecioE>(cboListaPrecio, oListaPrecio, "idListaPrecio", "Nombre");
                cboListaPrecio.Enabled = false;
            }

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
            Decimal Por1 = Variables.Cero;
            Decimal Dscto1 = Variables.Cero;
            Decimal Por2 = Variables.Cero;
            Decimal Dscto2 = Variables.Cero;
            Decimal Por3 = Variables.Cero;
            Decimal Dscto3 = Variables.Cero;
            Decimal SubTotal = Variables.Cero;
            Decimal ValorVenta = Variables.Cero;
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

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorIgv.Text, out porIgv);
            txtIgv.Text = (ValorVenta * (porIgv / 100)).ToString("N2");
            Decimal.TryParse(txtIgv.Text, out Igv);

            //Total General
            txtPrecioVenta.Text = (ValorVenta + Igv).ToString("N2");

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
                txtPorIgv.TextChanged += txtPorIgv_TextChanged;
                chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                txtPrecioVenta.TextChanged += txtPrecioVenta_TextChanged;
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

        void CrearControles(List<ArticuloServE> ListaArticulos)
        {
            Label LabelNuevo = null;
            ControlesWinForm.SuperTextBox TextNuevo = null;
            Int32 numItem = 1;
            Int32 Cant = ListaArticulos.Count;
            Int32 xPosTalla = 93;
            Int32 yPosTalla = 26;
            Int32 xPosStock = 93;
            Int32 yPosStock = 49;
            Int32 xPosPedido = 93;
            Int32 yPosPedido = 72;
            Int32 IndexText = 30;

            pnlTallas.SuspendLayout();

            foreach (ArticuloServE item in ListaArticulos)
            {
                #region Labels Tallas

                LabelNuevo = new Label
                {
                    BackColor = System.Drawing.Color.DarkBlue,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0),
                    ForeColor = System.Drawing.Color.White,
                    Name = "lblTalla" + numItem.ToString(),
                    Size = new System.Drawing.Size(48, 21),
                    TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                    Text = item.Lote,
                    Location = new System.Drawing.Point(xPosTalla, yPosTalla)
                };

                //Agregando al panel el nuevo label
                pnlTallas.Controls.Add(LabelNuevo);

                //Agregando al eje x el ancho del nuevo label
                if (Cant == 7)
                {
                    xPosTalla += (LabelNuevo.Width + 50);
                }
                else if (Cant == 8)
                {
                    xPosTalla += (LabelNuevo.Width + 30);
                }
                else if (Cant == 9)
                {
                    xPosTalla += (LabelNuevo.Width + 20);
                }
                else if (Cant == 10)
                {
                    xPosTalla += (LabelNuevo.Width + 10);
                }
                else
                {
                    xPosTalla += (LabelNuevo.Width + 70);
                } 

                #endregion

                #region Labels Stock

                LabelNuevo = new Label
                {
                    BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    ForeColor = System.Drawing.Color.White,
                    Name = "lblStock" + numItem.ToString(),
                    Size = new System.Drawing.Size(48, 21),
                    TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                    Text = item.Stock.ToString(),
                    Location = new System.Drawing.Point(xPosStock, yPosStock)
                };

                //Agregando al panel el nuevo label
                pnlTallas.Controls.Add(LabelNuevo);

                //Agregando al eje x el ancho del nuevo label
                if (Cant == 7)
                {
                    xPosStock += (LabelNuevo.Width + 50);
                }
                else if (Cant == 8)
                {
                    xPosStock += (LabelNuevo.Width + 30);
                }
                else if (Cant == 9)
                {
                    xPosStock += (LabelNuevo.Width + 20);
                }
                else if (Cant == 10)
                {
                    xPosStock += (LabelNuevo.Width + 10);
                }
                else
                {
                    xPosStock += (LabelNuevo.Width + 70);
                }

                #endregion

                #region TextBox

                TextNuevo = new ControlesWinForm.SuperTextBox
                {
                    Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto,
                    ColorTextoVacio = System.Drawing.Color.Gray,
                    TextAlign = HorizontalAlignment.Right,
                    TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros,
                    TextoVacio = "<Descripcion>",
                    TabStop = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Name = "txtPedidoX" + numItem.ToString(),
                    Size = new System.Drawing.Size(48, 21),
                    Text = "0",
                    TabIndex = IndexText,
                    Location = new System.Drawing.Point(xPosPedido, yPosPedido)
                };

                //Agregando el evento...
                TextNuevo.TextChanged += new EventHandler(txtPedidoX_TextChanged);
                //Agregando al panel el nuevo textbox
                pnlTallas.Controls.Add(TextNuevo);

                //Agregando al eje x el ancho del nuevo textbox
                if (Cant == 7)
                {
                    xPosPedido += (TextNuevo.Width + 50);
                }
                else if (Cant == 8)
                {
                    xPosPedido += (TextNuevo.Width + 30);
                }
                else if (Cant == 9)
                {
                    xPosPedido += (TextNuevo.Width + 20);
                }
                else if (Cant == 10)
                {
                    xPosPedido += (TextNuevo.Width + 10);
                }
                else
                {
                    xPosPedido += (TextNuevo.Width + 70);
                } 

                #endregion

                numItem++;
                IndexText++;
            }

            pnlTallas.ResumeLayout();
            pnlTallas.Refresh();
        }

        void RemoverControles()
        {
            Int32 CantReg = oListaEmiDetalle.Count;
            pnlTallas.SuspendLayout();

            for (int i = 1; i <= CantReg; i++)
            {
                #region Labels

                Label ctrlLabel = (Label)VariablesLocales.ObjDinamico(pnlTallas, "lblTalla" + i.ToString());

                if (ctrlLabel != null)
                {
                    if (pnlTallas.Controls.Contains(ctrlLabel))
                    {
                        pnlTallas.Controls.Remove(ctrlLabel);
                        ctrlLabel.Dispose();
                    }
                }

                ctrlLabel = (Label)VariablesLocales.ObjDinamico(pnlTallas, "lblStock" + i.ToString());

                if (ctrlLabel != null)
                {
                    if (pnlTallas.Controls.Contains(ctrlLabel))
                    {
                        pnlTallas.Controls.Remove(ctrlLabel);
                        ctrlLabel.Dispose();
                    }
                }

                #endregion

                #region TextBox

                ControlesWinForm.SuperTextBox ctrlTexBox = (ControlesWinForm.SuperTextBox)VariablesLocales.ObjDinamico(pnlTallas, "txtPedidoX" + i.ToString());

                if (ctrlTexBox != null)
                {
                    if (pnlTallas.Controls.Contains(ctrlTexBox))
                    {
                        ctrlTexBox.TextChanged += new EventHandler(txtPedidoX_TextChanged);
                        pnlTallas.Controls.Remove(ctrlTexBox);
                        ctrlTexBox.Dispose();
                    }
                } 

                #endregion
            }

            pnlTallas.ResumeLayout();
            pnlTallas.Refresh();
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            oListaEmiDetalle = new List<EmisionDocumentoDetE>();
            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    Decimal.TryParse(txtCantidad.Text, out Decimal Cantidad);
                    Decimal.TryParse(txtPrecio.Text, out Decimal PrecioSinImpuesto);
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

                    ControlesWinForm.SuperTextBox txtDinamico = null;
                    Label lblDinamico = null;
                    Decimal cantPedida = 0;
                    Int32 NumItem = 1;

                    foreach (EmisionDocumentoDetE item in oListaEmiDetalle)
                    {
                        txtDinamico = (ControlesWinForm.SuperTextBox)VariablesLocales.ObjDinamico(pnlTallas, "txtPedidoX" + NumItem.ToString());
                        Decimal.TryParse(txtDinamico.Text, out cantPedida);

                        if (cantPedida > 0)
                        {
                            if (cantPedida <= item.Stock)
                            {
                                lblDinamico = (Label)VariablesLocales.ObjDinamico(pnlTallas, "lblTalla" + NumItem.ToString());

                                if (lblDinamico.Text == item.Lote)
                                {
                                    item.Cantidad = Convert.ToDecimal(txtDinamico.Text);
                                    item.CantidadFinal = Convert.ToDecimal(txtDinamico.Text);
                                    item.PrecioConImpuesto = PrecioConImpuesto;

                                    ValorVenta = PrecioSinImpuesto * item.Cantidad;
                                    item.subTotal = ValorVenta;

                                    Igv = (ValorVenta) * (porIgv / 100);
                                    item.Igv = Igv;
                                    item.Total = (ValorVenta + Igv);

                                    oListaReal.Add(item);
                                }
                            } 
                        }

                        NumItem++;
                    }

                    txtDinamico = null;
                    lblDinamico = null;

                    if (oListaReal != null && oListaReal.Count > 0)
                    {
                        base.Aceptar();
                    }
                    else
                    {
                        Global.MensajeComunicacion("No tiene ningún producto, presiones cancelar.");
                    }
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

            if (oListaValidacion != null && oListaValidacion.Count > Variables.Cero)
            {
                List<EmisionDocumentoDetE> oListaTemp = null;
                
                foreach (EmisionDocumentoDetE item in oListaValidacion)
                {
                    oListaTemp = new List<EmisionDocumentoDetE>((from x in oListaEmiDetalle
                                                                 where x.idArticulo == item.idArticulo
                                                                 && x.codArticulo == item.codArticulo
                                                                 && x.Lote == item.Lote
                                                                 && x.indCalculo == chkCalculo.Checked
                                                                 select x).ToList());
                    if (oListaTemp.Count > 0)
                    {
                        Global.MensajeFault("El articulo ya se encuentra añadido en la lista, cambie de código o modifique el articulo correspondiente.");
                        oListaTemp = null;
                        btBuscarArticulo.Focus();
                        return false;
                    }
                }

                oListaTemp = null;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos de Usuario

        private void txtPedidoX_TextChanged(object sender, EventArgs e)
        {
            Int32 CantReg = oListaEmiDetalle.Count;
            Int32 totped = 0;

            for (int i = 1; i <= CantReg; i++)
            {
                ControlesWinForm.SuperTextBox txtDinamico = (ControlesWinForm.SuperTextBox)VariablesLocales.ObjDinamico(pnlTallas, "txtPedidoX" + i.ToString());

                if (txtDinamico != null)
                {
                    Int32.TryParse(txtDinamico.Text, out Int32 canti);
                    totped += canti;
                }
            }

            txtCantidad.Text = totped.ToString();
        }

        #endregion

        #region Eventos

        private void frmDetallePedidoNacional_Load(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
                txtCodArticulo.Focus();

                //if (idAlmacenTmp != 0) //Para la solicitud de factura
                //{
                //    cboAlmacen.SelectedValue = idAlmacenTmp;
                //    pnlBase.Enabled = false;
                //}
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
                            //Removiendo los controles dinámicos
                            RemoverControles();

                            foreach (ArticuloServE item in ListaArticulosDet)
                            {
                                EmisionDocumentoDetE oDetalleTmp = new EmisionDocumentoDetE
                                {
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue),
                                    idArticulo = item.idArticulo,
                                    codArticulo = item.codArticulo,
                                    nomArticulo = item.nomArticulo,
                                    Lote = item.Lote,
                                    Cantidad = 1,
                                    CantidadFinal = 1,
                                    PrecioSinImpuesto = item.PrecioBruto,
                                    Dscto1 = item.MontoDscto1,
                                    Dscto2 = item.MontoDscto2,
                                    Dscto3 = item.MontoDscto3,
                                    Comision = 0,
                                    porDscto1 = item.PorDscto1,
                                    porDscto2 = item.PorDscto2,
                                    porDscto3 = item.PorDscto3,
                                    porComision = 0,
                                    CantidadAtendida = 0,
                                    flgIgv = item.flgigv,
                                    Isc = item.isc,
                                    Igv = item.igv,
                                    subTotal = item.PrecioValorVenta,
                                    Total = item.PrecioVenta,
                                    porIsc = item.porisc,
                                    porIgv = item.porigv,
                                    idUnidadMedida = item.codUniMedAlmacen,
                                    TipoImpSelectivo = item.TipoImpSelectivo,
                                    Stock = item.Stock,
                                    TipoLista = null,
                                    codLineaVenta = null,
                                    Contiene = item.Contenido,
                                    Capacidad = item.Capacidad,
                                    PesoUnitario = 0,
                                    idDocumentoRef = null,
                                    serDocumentoRef = null,
                                    numDocumentoRef = null,
                                    fecDocumentoRef = null,
                                    TotalRef = 0,
                                    idCampana = null,
                                    indPercepcion = false,
                                    MontoAfectoPerce = null,
                                    MontoPercepcion = null,
                                    idListaPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue),
                                    nroOt = null,
                                    PesoBrutoCad = String.Empty,
                                    indCalculo = chkCalculo.Checked,
                                    tipArticulo = "AR",
                                    indDetraccion = false,
                                    tipDetraccion = String.Empty,
                                    TasaDetraccion = 0,
                                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                    FechaRegistro = VariablesLocales.FechaHoy,
                                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                    FechaModificacion = VariablesLocales.FechaHoy
                                };

                                oListaEmiDetalle.Add(oDetalleTmp);
                            }

                            //Creando dinamicamente los labels y los textbox
                            CrearControles(ListaArticulosDet);

                            txtIdArticulo.Text = oFrmBuscarArtiLista.Articulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrmBuscarArtiLista.Articulo.codArticulo;
                            txtDesArticulo.Text = oFrmBuscarArtiLista.Articulo.nomArticulo;

                            ////De la lista de precio
                            txtPrecio.Text = oFrmBuscarArtiLista.Articulo.PrecioBruto.ToString("N6");
                            txtPor1.Text = oFrmBuscarArtiLista.Articulo.PorDscto1.ToString("N2");
                            txtPor2.Text = oFrmBuscarArtiLista.Articulo.PorDscto2.ToString("N2");
                            txtPor3.Text = oFrmBuscarArtiLista.Articulo.PorDscto3.ToString("N2");
                            chkIgv.Checked = oFrmBuscarArtiLista.Articulo.flgigv;

                            if (chkIgv.Checked)
                            {
                                txtPorIgv.Text = oFrmBuscarArtiLista.Articulo.porigv.ToString("N2");
                                txtIgv.Text = oFrmBuscarArtiLista.Articulo.igv.ToString("N2");
                            }
                            else
                            {
                                txtPorIgv.Text = "0.00";
                                txtIgv.Text = "0.00";
                            }
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
                            //Removiendo los controles dinámicos
                            RemoverControles();

                            foreach (ArticuloServE item in ListaArticulosDet)
                            {
                                EmisionDocumentoDetE oDetalleTmp = new EmisionDocumentoDetE
                                {
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue),
                                    idArticulo = item.idArticulo,
                                    codArticulo = item.codArticulo,
                                    nomArticulo = item.nomArticulo,
                                    Lote = item.Lote,
                                    Cantidad = 1,
                                    CantidadFinal = 1,
                                    PrecioSinImpuesto = item.PrecioBruto,
                                    Dscto1 = item.MontoDscto1,
                                    Dscto2 = item.MontoDscto2,
                                    Dscto3 = item.MontoDscto3,
                                    Comision = 0,
                                    porDscto1 = item.PorDscto1,
                                    porDscto2 = item.PorDscto2,
                                    porDscto3 = item.PorDscto3,
                                    porComision = 0,
                                    CantidadAtendida = 0,
                                    flgIgv = item.flgigv,
                                    Isc = item.isc,
                                    Igv = item.igv,
                                    subTotal = item.PrecioValorVenta,
                                    Total = item.PrecioVenta,
                                    porIsc = item.porisc,
                                    porIgv = item.porigv,
                                    idUnidadMedida = item.codUniMedAlmacen,
                                    TipoImpSelectivo = item.TipoImpSelectivo,
                                    Stock = item.Stock,
                                    TipoLista = null,
                                    codLineaVenta = null,
                                    Contiene = item.Contenido,
                                    Capacidad = item.Capacidad,
                                    PesoUnitario = 0,
                                    idDocumentoRef = null,
                                    serDocumentoRef = null,
                                    numDocumentoRef = null,
                                    fecDocumentoRef = null,
                                    TotalRef = 0,
                                    idCampana = null,
                                    indPercepcion = false,
                                    MontoAfectoPerce = null,
                                    MontoPercepcion = null,
                                    idListaPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue),
                                    nroOt = null,
                                    PesoBrutoCad = String.Empty,
                                    indCalculo = chkCalculo.Checked,
                                    tipArticulo = "AR",
                                    indDetraccion = false,
                                    tipDetraccion = String.Empty,
                                    TasaDetraccion = 0,
                                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                    FechaRegistro = VariablesLocales.FechaHoy,
                                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                    FechaModificacion = VariablesLocales.FechaHoy
                                };

                                oListaEmiDetalle.Add(oDetalleTmp);
                            }

                            //Creando dinamicamente los labels y los textbox
                            CrearControles(ListaArticulosDet);

                            txtIdArticulo.Text = oFrmBuscarArtiLista.Articulo.idArticulo.ToString();
                            txtCodArticulo.Text = oFrmBuscarArtiLista.Articulo.codArticulo;
                            txtDesArticulo.Text = oFrmBuscarArtiLista.Articulo.nomArticulo;

                            ////De la lista de precio
                            txtPrecio.Text = oFrmBuscarArtiLista.Articulo.PrecioBruto.ToString("N6");
                            txtPor1.Text = oFrmBuscarArtiLista.Articulo.PorDscto1.ToString("N2");
                            txtPor2.Text = oFrmBuscarArtiLista.Articulo.PorDscto2.ToString("N2");
                            txtPor3.Text = oFrmBuscarArtiLista.Articulo.PorDscto3.ToString("N2");
                            chkIgv.Checked = oFrmBuscarArtiLista.Articulo.flgigv;

                            if (chkIgv.Checked)
                            {
                                txtPorIgv.Text = oFrmBuscarArtiLista.Articulo.porigv.ToString("N2");
                                txtIgv.Text = oFrmBuscarArtiLista.Articulo.igv.ToString("N2");
                            }
                            else
                            {
                                txtPorIgv.Text = "0.00";
                                txtIgv.Text = "0.00";
                            }
                        }
                    }
                    else
                    {
                        frmBuscarArticuloPedido oFrmPedido = new frmBuscarArticuloPedido(oAlmacen, "stock", FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), "N");

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
                //cboImpSelectivo.SelectedValue = "N";
                //PonerIsc();
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
            //try
            //{
            //    if (!String.IsNullOrEmpty(txtCodArticulo.Text.Trim()) && String.IsNullOrEmpty(txtDesArticulo.Text.Trim()))
            //    {
            //        txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
            //        txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

            //        if (((AlmacenE)cboAlmacen.SelectedItem).VerificaStock)
            //        {
            //            if (VariablesLocales.oVenParametros != null)
            //            {
            //                if (!VariablesLocales.oVenParametros.indListaPrecio)
            //                {
            //                    #region Con Stock

            //                    List<StockE> oListaStock = null;

            //                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //                    {
            //                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
            //                                                                                txtCodArticulo.Text.Trim(), "", "N");
            //                    }
            //                    else
            //                    {
            //                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
            //                                                                                txtCodArticulo.Text.Trim(), "", "N");
            //                    }

            //                    if (oListaStock.Count > 1)
            //                    {
            //                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

            //                        if (oFrm.ShowDialog() == DialogResult.OK)
            //                        {
            //                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
            //                            //txtLote.Text = oFrm.oArticulo.Lote;
            //                            //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
            //                            //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

            //                            if (oFrm.oArticulo.indDetraccion)
            //                            {
            //                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                    }
            //                    else if (oListaStock.Count == 1)
            //                    {
            //                        txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
            //                        txtCodArticulo.Text = oListaStock[0].codArticulo;
            //                        txtDesArticulo.Text = oListaStock[0].desArticulo;
            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
            //                        //txtLote.Text = oListaStock[0].Lote;
            //                        //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
            //                        //txtStock.Text = oListaStock[0].canStock.ToString("N4");

            //                        chkDetra.Checked = oListaStock[0].indDetraccion;
            //                        txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                        if (oListaStock[0].indDetraccion)
            //                        {
            //                            chkDetra.Checked = oListaStock[0].indDetraccion;
            //                            txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
            //                        txtIdArticulo.Text = string.Empty;
            //                        txtCodArticulo.Text = string.Empty;
            //                        txtDesArticulo.Text = string.Empty;
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";
            //                        txtCodArticulo.Focus();
            //                    }

            //                    #endregion
            //                }
            //                else
            //                {
            //                    if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                    {
            //                        #region Con Lista de Precios

            //                        QuitarEventos("S");
            //                        List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                                            txtCodArticulo.Text.Trim(), "", Convert.ToInt32(cboListaPrecio.SelectedValue));
            //                        if (oListaArticulos.Count > 1)
            //                        {
            //                            frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

            //                            if (oFrm.ShowDialog() == DialogResult.OK)
            //                            {
            //                                txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                                txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                                txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                                //txtLote.Text = "0000000";
            //                                //txtStock.Text = "0.0000";
            //                                //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
            //                                //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                                //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

            //                                //De la lista de precio
            //                                txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
            //                                txtCantidad.Text = "1.00";
            //                                txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                                txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                                cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
            //                                txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
            //                                txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
            //                                txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
            //                                txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
            //                                txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
            //                                txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
            //                                txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
            //                                chkIgv.Checked = oFrm.oArticulo.flgigv;

            //                                if (chkIgv.Checked)
            //                                {
            //                                    txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
            //                                    txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtPorIgv.Text = "0.00";
            //                                    txtIgv.Text = "0.00";
            //                                }

            //                                if (oFrm.oArticulo.indDetraccion)
            //                                {
            //                                    chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                    txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                    if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                    {
            //                                        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                    }
            //                                    else
            //                                    {
            //                                        txtTasa.Text = "0.00";
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    chkDetra.Checked = false;
            //                                    txtTipDetra.Text = String.Empty;
            //                                    txtTasa.Text = "0.00";
            //                                }

            //                                PonerIsc();
            //                            }
            //                        }
            //                        else if (oListaArticulos.Count == 1)
            //                        {
            //                            txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
            //                            txtCodArticulo.Text = oListaArticulos[0].codArticulo;
            //                            txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";
            //                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

            //                            //De la lista de precio
            //                            txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
            //                            txtCantidad.Text = "1.00";
            //                            txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                            txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                            cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
            //                            txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
            //                            txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
            //                            txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
            //                            txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
            //                            txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
            //                            txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
            //                            txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
            //                            chkIgv.Checked = oListaArticulos[0].flgigv;

            //                            if (chkIgv.Checked)
            //                            {
            //                                txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
            //                                txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtPorIgv.Text = "0.00";
            //                                txtIgv.Text = "0.00";
            //                            }

            //                            if (oListaArticulos[0].indDetraccion)
            //                            {
            //                                chkDetra.Checked = oListaArticulos[0].indDetraccion;
            //                                txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }

            //                            PonerIsc();
            //                        }
            //                        else
            //                        {
            //                            Global.MensajeFault("El código ingresado no existe en la Lista de precio escogida, vuelva a probar por favor.");
            //                            txtIdArticulo.Text = string.Empty;
            //                            txtCodArticulo.Text = string.Empty;
            //                            txtDesArticulo.Text = string.Empty;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                            PonerIsc();

            //                            txtCodArticulo.Focus();
            //                        }

            //                        QuitarEventos("N");

            //                        #endregion 
            //                    }
            //                    else
            //                    {
            //                        #region Con Stock

            //                        List<StockE> oListaStock = null;

            //                        if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //                        {
            //                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                    Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                    FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
            //                                                                                    txtCodArticulo.Text.Trim(), "", "N");
            //                        }
            //                        else
            //                        {
            //                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                    Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                    FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
            //                                                                                    txtCodArticulo.Text.Trim(), "", "N");
            //                        }

            //                        if (oListaStock.Count > 1)
            //                        {
            //                            frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

            //                            if (oFrm.ShowDialog() == DialogResult.OK)
            //                            {
            //                                txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                                txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                                txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                                //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
            //                                //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                                //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
            //                                //txtLote.Text = oFrm.oArticulo.Lote;
            //                                //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
            //                                //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

            //                                if (oFrm.oArticulo.indDetraccion)
            //                                {
            //                                    chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                    txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                    if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                    {
            //                                        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                    }
            //                                    else
            //                                    {
            //                                        txtTasa.Text = "0.00";
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    chkDetra.Checked = false;
            //                                    txtTipDetra.Text = String.Empty;
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                        }
            //                        else if (oListaStock.Count == 1)
            //                        {
            //                            txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
            //                            txtCodArticulo.Text = oListaStock[0].codArticulo;
            //                            txtDesArticulo.Text = oListaStock[0].desArticulo;
            //                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
            //                            //txtLote.Text = oListaStock[0].Lote;
            //                            //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
            //                            //txtStock.Text = oListaStock[0].canStock.ToString("N4");

            //                            if (oListaStock[0].indDetraccion)
            //                            {
            //                                chkDetra.Checked = oListaStock[0].indDetraccion;
            //                                txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
            //                            txtIdArticulo.Text = string.Empty;
            //                            txtCodArticulo.Text = string.Empty;
            //                            txtDesArticulo.Text = string.Empty;
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                            txtCodArticulo.Focus();
            //                        }

            //                        #endregion
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                #region Con Stock

            //                List<StockE> oListaStock = null;

            //                if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //                {
            //                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
            //                                                                            txtCodArticulo.Text.Trim(), "", "N");
            //                }
            //                else
            //                {
            //                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
            //                                                                            txtCodArticulo.Text.Trim(), "", "N");
            //                }

            //                if (oListaStock.Count > 1)
            //                {
            //                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

            //                    if (oFrm.ShowDialog() == DialogResult.OK)
            //                    {
            //                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
            //                        //txtLote.Text = oFrm.oArticulo.Lote;
            //                        //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
            //                        //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

            //                        if (oFrm.oArticulo.indDetraccion)
            //                        {
            //                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                }
            //                else if (oListaStock.Count == 1)
            //                {
            //                    txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
            //                    txtCodArticulo.Text = oListaStock[0].codArticulo;
            //                    txtDesArticulo.Text = oListaStock[0].desArticulo;
            //                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
            //                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
            //                    //txtLote.Text = oListaStock[0].Lote;
            //                    //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
            //                    //txtStock.Text = oListaStock[0].canStock.ToString("N4");

            //                    if (oListaStock[0].indDetraccion)
            //                    {
            //                        chkDetra.Checked = oListaStock[0].indDetraccion;
            //                        txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

            //                        if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                        {
            //                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                        }
            //                        else
            //                        {
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";
            //                    }
            //                }
            //                else
            //                {
            //                    Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
            //                    txtIdArticulo.Text = string.Empty;
            //                    txtCodArticulo.Text = string.Empty;
            //                    txtDesArticulo.Text = string.Empty;
            //                    chkDetra.Checked = false;
            //                    txtTipDetra.Text = String.Empty;
            //                    txtTasa.Text = "0.00";

            //                    txtCodArticulo.Focus();
            //                }

            //                #endregion
            //            }
            //        }
            //        else
            //        {
            //            #region Sin Stock

            //            if (VariablesLocales.oVenParametros != null)
            //            {
            //                if (!VariablesLocales.oVenParametros.indListaPrecio)
            //                {
            //                    #region Sin Lista de Precios

            //                    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                                        txtCodArticulo.Text.Trim(), "");
            //                    if (oListaArticulos.Count > 1)
            //                    {
            //                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

            //                        if (oFrm.ShowDialog() == DialogResult.OK)
            //                        {
            //                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";

            //                            //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

            //                            if (oFrm.oArticulo.indDetraccion)
            //                            {
            //                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                    }
            //                    else if (oListaArticulos.Count == 1)
            //                    {
            //                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
            //                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
            //                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.0000";

            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

            //                        if (oListaArticulos[0].indDetraccion)
            //                        {
            //                            chkDetra.Checked = oListaArticulos[0].indDetraccion;
            //                            txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        Global.MensajeFault("El código ingresado no existe, vuelva a probar por favor.");
            //                        txtIdArticulo.Text = string.Empty;
            //                        txtCodArticulo.Text = string.Empty;
            //                        txtDesArticulo.Text = string.Empty;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.0000";
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";

            //                        txtCodArticulo.Focus();
            //                    }

            //                    #endregion  
            //                }
            //                else
            //                {
            //                    #region Con Lista de Precios

            //                    QuitarEventos("S");
            //                    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                                        txtCodArticulo.Text.Trim(), "", Convert.ToInt32(cboListaPrecio.SelectedValue));
            //                    if (oListaArticulos.Count > 1)
            //                    {
            //                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

            //                        if (oFrm.ShowDialog() == DialogResult.OK)
            //                        {
            //                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";
            //                            //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

            //                            //De la lista de precio
            //                            txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
            //                            txtCantidad.Text = "1.00";
            //                            txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                            txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                            cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
            //                            txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
            //                            txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
            //                            txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
            //                            txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
            //                            txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
            //                            txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
            //                            txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
            //                            chkIgv.Checked = oFrm.oArticulo.flgigv;

            //                            if (chkIgv.Checked)
            //                            {
            //                                txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
            //                                txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtPorIgv.Text = "0.00";
            //                                txtIgv.Text = "0.00";
            //                            }

            //                            if (oFrm.oArticulo.indDetraccion)
            //                            {
            //                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }

            //                            PonerIsc();
            //                        }
            //                    }
            //                    else if (oListaArticulos.Count == 1)
            //                    {
            //                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
            //                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
            //                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.0000";
            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

            //                        //De la lista de precio
            //                        txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
            //                        txtCantidad.Text = "1.00";
            //                        txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                        txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                        cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
            //                        txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
            //                        txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
            //                        txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
            //                        txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
            //                        txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
            //                        txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
            //                        txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
            //                        chkIgv.Checked = oListaArticulos[0].flgigv;

            //                        if (chkIgv.Checked)
            //                        {
            //                            txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
            //                            txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
            //                        }
            //                        else
            //                        {
            //                            txtPorIgv.Text = "0.00";
            //                            txtIgv.Text = "0.00";
            //                        }

            //                        if (oListaArticulos[0].indDetraccion)
            //                        {
            //                            chkDetra.Checked = oListaArticulos[0].indDetraccion;
            //                            txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }

            //                        PonerIsc();
            //                    }
            //                    else
            //                    {
            //                        Global.MensajeFault("El código ingresado no existe en la Lista de precio escogida, vuelva a probar por favor.");
            //                        txtIdArticulo.Text = string.Empty;
            //                        txtCodArticulo.Text = string.Empty;
            //                        txtDesArticulo.Text = string.Empty;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.0000";
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";
            //                        PonerIsc();

            //                        txtCodArticulo.Focus();
            //                    }

            //                    QuitarEventos("N");

            //                    #endregion
            //                }
            //            }

            //            #endregion
            //        }

            //        txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
            //        txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    QuitarEventos("N");
            //    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
            //    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void txtDesArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(txtDesArticulo.Text.Trim()) && string.IsNullOrEmpty(txtCodArticulo.Text.Trim()))
            //    {
            //        txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
            //        txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

            //        if (((AlmacenE)cboAlmacen.SelectedItem).VerificaStock)
            //        {
            //            if (VariablesLocales.oVenParametros != null)
            //            {
            //                if (!VariablesLocales.oVenParametros.indListaPrecio)
            //                {
            //                    #region Con Stock

            //                    List<StockE> oListaStock = null;

            //                    if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //                    {
            //                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
            //                                                                                "", txtDesArticulo.Text.Trim(), "N");
            //                    }
            //                    else
            //                    {
            //                        oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
            //                                                                                "", txtDesArticulo.Text.Trim(), "N");
            //                    }

            //                    if (oListaStock.Count > 1)
            //                    {
            //                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

            //                        if (oFrm.ShowDialog() == DialogResult.OK)
            //                        {
            //                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
            //                            //txtLote.Text = oFrm.oArticulo.Lote;
            //                            //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
            //                            //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

            //                            if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                            {
            //                                cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

            //                                if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
            //                                {
            //                                    txtPrecio.Focus();
            //                                }
            //                                else
            //                                {
            //                                    txtCantidad.Focus();
            //                                }
            //                            }
            //                            else
            //                            {
            //                                txtPrecio.Focus();
            //                            }

            //                            if (oFrm.oArticulo.indDetraccion)
            //                            {
            //                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                    }
            //                    else if (oListaStock.Count == 1)
            //                    {
            //                        txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
            //                        txtCodArticulo.Text = oListaStock[0].codArticulo;
            //                        txtDesArticulo.Text = oListaStock[0].desArticulo;
            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
            //                        //txtLote.Text = oListaStock[0].Lote;
            //                        //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
            //                        //txtStock.Text = oListaStock[0].canStock.ToString("N2");

            //                        if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                        {
            //                            cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

            //                            if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
            //                            {
            //                                txtPrecio.Focus();
            //                            }
            //                            else
            //                            {
            //                                txtCantidad.Focus();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            txtPrecio.Focus();
            //                        }

            //                        if (oListaStock[0].indDetraccion)
            //                        {
            //                            chkDetra.Checked = oListaStock[0].indDetraccion;
            //                            txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
            //                        txtIdArticulo.Text = string.Empty;
            //                        txtCodArticulo.Text = string.Empty;
            //                        txtDesArticulo.Text = string.Empty;
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";
            //                        txtDesArticulo.Focus();
            //                    }

            //                    #endregion
            //                }
            //                else
            //                {
            //                    if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                    {
            //                        #region Con Lista de Precios

            //                        QuitarEventos("S");
            //                        List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                                            "", txtDesArticulo.Text.Trim(), Convert.ToInt32(cboListaPrecio.SelectedValue));
            //                        if (oListaArticulos.Count > 1)
            //                        {
            //                            frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

            //                            if (oFrm.ShowDialog() == DialogResult.OK)
            //                            {
            //                                txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                                txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                                txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                                //txtLote.Text = "0000000";
            //                                //txtStock.Text = "0.0000";
            //                                //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
            //                                //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                                //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

            //                                //De la lista de precio
            //                                txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
            //                                txtCantidad.Text = "1.00";
            //                                txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                                txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                                //cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
            //                                //txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
            //                                //txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
            //                                txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
            //                                txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
            //                                txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
            //                                txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
            //                                txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
            //                                chkIgv.Checked = oFrm.oArticulo.flgigv;

            //                                if (chkIgv.Checked)
            //                                {
            //                                    txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
            //                                    txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtPorIgv.Text = "0.00";
            //                                    txtIgv.Text = "0.00";
            //                                }

            //                                PonerIsc();

            //                                if (oFrm.oArticulo.indDetraccion)
            //                                {
            //                                    chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                    txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                    if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                    {
            //                                        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                    }
            //                                    else
            //                                    {
            //                                        txtTasa.Text = "0.00";
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    chkDetra.Checked = false;
            //                                    txtTipDetra.Text = String.Empty;
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                        }
            //                        else if (oListaArticulos.Count == 1)
            //                        {
            //                            txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
            //                            txtCodArticulo.Text = oListaArticulos[0].codArticulo;
            //                            txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";
            //                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

            //                            //De la lista de precio
            //                            txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
            //                            txtCantidad.Text = "1.00";
            //                            txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                            txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                            cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
            //                            txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
            //                            txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
            //                            txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
            //                            txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
            //                            txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
            //                            txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
            //                            txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
            //                            chkIgv.Checked = oListaArticulos[0].flgigv;

            //                            if (chkIgv.Checked)
            //                            {
            //                                txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
            //                                txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtPorIgv.Text = "0.00";
            //                                txtIgv.Text = "0.00";
            //                            }

            //                            PonerIsc();

            //                            if (oListaArticulos[0].indDetraccion)
            //                            {
            //                                chkDetra.Checked = oListaArticulos[0].indDetraccion;
            //                                txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            Global.MensajeFault("La descripción ingresada no existe en la Lista de Precio, vuelva a probar por favor.");
            //                            txtIdArticulo.Text = string.Empty;
            //                            txtCodArticulo.Text = string.Empty;
            //                            txtDesArticulo.Text = string.Empty;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";

            //                            PonerIsc();

            //                            txtCodArticulo.Focus();
            //                        }

            //                        QuitarEventos("N");

            //                        #endregion 
            //                    }
            //                    else
            //                    {
            //                        #region Con Stock

            //                        List<StockE> oListaStock = null;

            //                        if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //                        {
            //                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                    Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                    FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
            //                                                                                    "", txtDesArticulo.Text.Trim(), "N");
            //                        }
            //                        else
            //                        {
            //                            oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                    Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                                    Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                    FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
            //                                                                                    "", txtDesArticulo.Text.Trim(), "N");
            //                        }

            //                        if (oListaStock.Count > 1)
            //                        {
            //                            frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

            //                            if (oFrm.ShowDialog() == DialogResult.OK)
            //                            {
            //                                txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                                txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                                txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                                //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
            //                                //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                                //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
            //                                //txtLote.Text = oFrm.oArticulo.Lote;
            //                                //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
            //                                //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

            //                                if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                                {
            //                                    cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

            //                                    if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
            //                                    {
            //                                        txtPrecio.Focus();
            //                                    }
            //                                    else
            //                                    {
            //                                        txtCantidad.Focus();
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    txtPrecio.Focus();
            //                                }

            //                                if (oFrm.oArticulo.indDetraccion)
            //                                {
            //                                    chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                    txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                    List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                    if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                    {
            //                                        txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                    }
            //                                    else
            //                                    {
            //                                        txtTasa.Text = "0.00";
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    chkDetra.Checked = false;
            //                                    txtTipDetra.Text = String.Empty;
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                        }
            //                        else if (oListaStock.Count == 1)
            //                        {
            //                            txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
            //                            txtCodArticulo.Text = oListaStock[0].codArticulo;
            //                            txtDesArticulo.Text = oListaStock[0].desArticulo;
            //                            //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
            //                            //txtLote.Text = oListaStock[0].Lote;
            //                            //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
            //                            //txtStock.Text = oListaStock[0].canStock.ToString("N2");

            //                            if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                            {
            //                                cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

            //                                if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
            //                                {
            //                                    txtPrecio.Focus();
            //                                }
            //                                else
            //                                {
            //                                    txtCantidad.Focus();
            //                                }
            //                            }
            //                            else
            //                            {
            //                                txtPrecio.Focus();
            //                            }

            //                            if (oListaStock[0].indDetraccion)
            //                            {
            //                                chkDetra.Checked = oListaStock[0].indDetraccion;
            //                                txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
            //                            txtIdArticulo.Text = string.Empty;
            //                            txtCodArticulo.Text = string.Empty;
            //                            txtDesArticulo.Text = string.Empty;
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                            txtDesArticulo.Focus();
            //                        }

            //                        #endregion
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                #region Con Stock

            //                List<StockE> oListaStock = null;

            //                if (((AlmacenE)cboAlmacen.SelectedItem).VerificaLote)
            //                {
            //                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), true,
            //                                                                            "", txtDesArticulo.Text.Trim(), "N");
            //                }
            //                else
            //                {
            //                    oListaStock = AgenteAlmacen.Proxy.ListarStockArticulo(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                            Convert.ToInt32(cboAlmacen.SelectedValue),
            //                                                                            Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                            FechaPedido.ToString("yyyy"), FechaPedido.ToString("MM"), false,
            //                                                                            "", txtDesArticulo.Text.Trim(), "N");
            //                }

            //                if (oListaStock.Count > 1)
            //                {
            //                    frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(((AlmacenE)cboAlmacen.SelectedItem).VerificaLote, oListaStock, null);

            //                    if (oFrm.ShowDialog() == DialogResult.OK)
            //                    {
            //                        txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                        txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                        txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oFrm.oArticulo.codUniMedAlmacen);
            //                        //txtLote.Text = oFrm.oArticulo.Lote;
            //                        //txtLoteProveedor.Text = oFrm.oArticulo.LoteProveedor;
            //                        //txtStock.Text = oFrm.oArticulo.Stock.ToString("N4");

            //                        if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                        {
            //                            cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

            //                            if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
            //                            {
            //                                txtPrecio.Focus();
            //                            }
            //                            else
            //                            {
            //                                txtCantidad.Focus();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            txtPrecio.Focus();
            //                        }

            //                        if (oFrm.oArticulo.indDetraccion)
            //                        {
            //                            chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                            txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                }
            //                else if (oListaStock.Count == 1)
            //                {
            //                    txtIdArticulo.Text = oListaStock[0].idArticulo.ToString();
            //                    txtCodArticulo.Text = oListaStock[0].codArticulo;
            //                    txtDesArticulo.Text = oListaStock[0].desArticulo;
            //                    //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaStock[0].codTipoMedAlmacen);
            //                    //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                    //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaStock[0].codUniMedAlmacen);
            //                    //txtLote.Text = oListaStock[0].Lote;
            //                    //txtLoteProveedor.Text = oListaStock[0].LoteProveedor;
            //                    //txtStock.Text = oListaStock[0].canStock.ToString("N4");

            //                    if (Convert.ToInt32(cboListaPrecio.SelectedValue) != 0)
            //                    {
            //                        cboListaPrecio_SelectionChangeCommitted(new object(), new EventArgs());

            //                        if (Convert.ToDecimal(txtPrecio.Text).ToString("N2") == "0.00")
            //                        {
            //                            txtPrecio.Focus();
            //                        }
            //                        else
            //                        {
            //                            txtCantidad.Focus();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        txtPrecio.Focus();
            //                    }

            //                    if (oListaStock[0].indDetraccion)
            //                    {
            //                        chkDetra.Checked = oListaStock[0].indDetraccion;
            //                        txtTipDetra.Text = oListaStock[0].tipDetraccion;

            //                        List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaStock[0].tipDetraccion);

            //                        if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                        {
            //                            txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                        }
            //                        else
            //                        {
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";
            //                    }
            //                }
            //                else
            //                {
            //                    Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
            //                    txtIdArticulo.Text = string.Empty;
            //                    txtCodArticulo.Text = string.Empty;
            //                    txtDesArticulo.Text = string.Empty;
            //                    chkDetra.Checked = false;
            //                    txtTipDetra.Text = String.Empty;
            //                    txtTasa.Text = "0.00";
            //                    txtDesArticulo.Focus();
            //                }

            //                #endregion
            //            }
            //        }
            //        else
            //        {
            //            #region Sin Stock

            //            if (VariablesLocales.oVenParametros != null)
            //            {
            //                if (!VariablesLocales.oVenParametros.indListaPrecio)
            //                {
            //                    #region Sin Lista de Precios

            //                    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ListarArticulosPorFiltro(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                                        "", txtDesArticulo.Text.Trim());
            //                    if (oListaArticulos.Count > 1)
            //                    {
            //                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos);

            //                        if (oFrm.ShowDialog() == DialogResult.OK)
            //                        {
            //                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.0000";

            //                            //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

            //                            if (oFrm.oArticulo.indDetraccion)
            //                            {
            //                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                    }
            //                    else if (oListaArticulos.Count == 1)
            //                    {
            //                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
            //                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
            //                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.0000";

            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

            //                        if (oListaArticulos[0].indDetraccion)
            //                        {
            //                            chkDetra.Checked = oListaArticulos[0].indDetraccion;
            //                            txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        Global.MensajeFault("La descripción ingresada no existe, vuelva a probar por favor.");
            //                        txtIdArticulo.Text = string.Empty;
            //                        txtCodArticulo.Text = string.Empty;
            //                        txtDesArticulo.Text = string.Empty;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.0000";
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";

            //                        txtCodArticulo.Focus();
            //                    }

            //                    #endregion  
            //                }
            //                else
            //                {
            //                    #region Con Lista de Precios

            //                    QuitarEventos("S");
            //                    List<ArticuloServE> oListaArticulos = AgenteMaestro.Proxy.ArticulosPorListaPrecio(VariablesLocales.SesionLocal.IdEmpresa,
            //                                                                                                        Convert.ToInt32(((AlmacenE)cboAlmacen.SelectedItem).tipAlmacen),
            //                                                                                                        "", txtDesArticulo.Text.Trim(), Convert.ToInt32(cboListaPrecio.SelectedValue));
            //                    if (oListaArticulos.Count > 1)
            //                    {
            //                        frmBusquedaArticulosPorFiltro oFrm = new frmBusquedaArticulosPorFiltro(false, null, oListaArticulos, "S");

            //                        if (oFrm.ShowDialog() == DialogResult.OK)
            //                        {
            //                            txtIdArticulo.Text = oFrm.oArticulo.idArticulo.ToString();
            //                            txtCodArticulo.Text = oFrm.oArticulo.codArticulo;
            //                            txtDesArticulo.Text = oFrm.oArticulo.nomArticulo;
            //                            //txtLote.Text = "0000000";
            //                            //txtStock.Text = "0.00";
            //                            //cboTipoUnidad.SelectedValue = oFrm.oArticulo.codTipoMedAlmacen;
            //                            //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                            //cboUnidadMedida.SelectedValue = oFrm.oArticulo.codUniMedAlmacen;

            //                            //De la lista de precio
            //                            txtPrecio.Text = oFrm.oArticulo.PrecioBruto.ToString("N5");
            //                            txtCantidad.Text = "1.00";
            //                            txtPor1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                            txtDscto1.Text = oFrm.oArticulo.PorDscto1.ToString("N2");
            //                            cboImpSelectivo.SelectedValue = oFrm.oArticulo.TipoImpSelectivo.ToString();
            //                            txtPorIsc.Text = oFrm.oArticulo.porisc.ToString("N2");
            //                            txtIsc.Text = oFrm.oArticulo.isc.ToString("N2");
            //                            txtSubTotal.Text = oFrm.oArticulo.PrecioBruto.ToString("N2");
            //                            txtValorVenta.Text = oFrm.oArticulo.PrecioValorVenta.ToString("N2");
            //                            txtPrecioVenta.Text = oFrm.oArticulo.PrecioVenta.ToString("N2");
            //                            txtCapacidad.Text = oFrm.oArticulo.Capacidad.ToString("N2");
            //                            txtContenido.Text = oFrm.oArticulo.Contenido.ToString("N2");
            //                            chkIgv.Checked = oFrm.oArticulo.flgigv;

            //                            if (chkIgv.Checked)
            //                            {
            //                                txtPorIgv.Text = oFrm.oArticulo.porigv.ToString("N2");
            //                                txtIgv.Text = oFrm.oArticulo.igv.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtPorIgv.Text = "0.00";
            //                                txtIgv.Text = "0.00";
            //                            }

            //                            PonerIsc();

            //                            if (oFrm.oArticulo.indDetraccion)
            //                            {
            //                                chkDetra.Checked = oFrm.oArticulo.indDetraccion;
            //                                txtTipDetra.Text = oFrm.oArticulo.tipDetraccion;

            //                                List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oFrm.oArticulo.tipDetraccion);

            //                                if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                                {
            //                                    txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                                }
            //                                else
            //                                {
            //                                    txtTasa.Text = "0.00";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                chkDetra.Checked = false;
            //                                txtTipDetra.Text = String.Empty;
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                    }
            //                    else if (oListaArticulos.Count == 1)
            //                    {
            //                        txtIdArticulo.Text = oListaArticulos[0].idArticulo.ToString();
            //                        txtCodArticulo.Text = oListaArticulos[0].codArticulo;
            //                        txtDesArticulo.Text = oListaArticulos[0].nomArticulo;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.00";
            //                        //cboTipoUnidad.SelectedValue = Convert.ToInt32(oListaArticulos[0].codTipoMedAlmacen);
            //                        //cboTipoUnidad_SelectionChangeCommitted(new Object(), new EventArgs());
            //                        //cboUnidadMedida.SelectedValue = Convert.ToInt32(oListaArticulos[0].codUniMedAlmacen);

            //                        //De la lista de precio
            //                        txtPrecio.Text = oListaArticulos[0].PrecioBruto.ToString("N5");
            //                        txtCantidad.Text = "1.00";
            //                        txtPor1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                        txtDscto1.Text = oListaArticulos[0].PorDscto1.ToString("N2");
            //                        cboImpSelectivo.SelectedValue = oListaArticulos[0].TipoImpSelectivo.ToString();
            //                        txtPorIsc.Text = oListaArticulos[0].porisc.ToString("N2");
            //                        txtIsc.Text = oListaArticulos[0].isc.ToString("N2");
            //                        txtSubTotal.Text = oListaArticulos[0].PrecioBruto.ToString("N2");
            //                        txtValorVenta.Text = oListaArticulos[0].PrecioValorVenta.ToString("N2");
            //                        txtPrecioVenta.Text = oListaArticulos[0].PrecioVenta.ToString("N2");
            //                        txtCapacidad.Text = oListaArticulos[0].Capacidad.ToString("N2");
            //                        txtContenido.Text = oListaArticulos[0].Contenido.ToString("N2");
            //                        chkIgv.Checked = oListaArticulos[0].flgigv;

            //                        if (chkIgv.Checked)
            //                        {
            //                            txtPorIgv.Text = oListaArticulos[0].porigv.ToString("N2");
            //                            txtIgv.Text = oListaArticulos[0].igv.ToString("N2");
            //                        }
            //                        else
            //                        {
            //                            txtPorIgv.Text = "0.00";
            //                            txtIgv.Text = "0.00";
            //                        }

            //                        PonerIsc();

            //                        if (oListaArticulos[0].indDetraccion)
            //                        {
            //                            chkDetra.Checked = oListaArticulos[0].indDetraccion;
            //                            txtTipDetra.Text = oListaArticulos[0].tipDetraccion;

            //                            List<TasasDetraccionesDetalleE> DetraccionDet = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaPedido, oListaArticulos[0].tipDetraccion);

            //                            if (DetraccionDet != null && DetraccionDet.Count > 0)
            //                            {
            //                                txtTasa.Text = DetraccionDet[0].Porcentaje.ToString("N2");
            //                            }
            //                            else
            //                            {
            //                                txtTasa.Text = "0.00";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            chkDetra.Checked = false;
            //                            txtTipDetra.Text = String.Empty;
            //                            txtTasa.Text = "0.00";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        Global.MensajeFault("La descripción ingresada no existe en la Lista de Precio, vuelva a probar por favor.");
            //                        txtIdArticulo.Text = string.Empty;
            //                        txtCodArticulo.Text = string.Empty;
            //                        txtDesArticulo.Text = string.Empty;
            //                        //txtLote.Text = "0000000";
            //                        //txtStock.Text = "0.00";
            //                        chkDetra.Checked = false;
            //                        txtTipDetra.Text = String.Empty;
            //                        txtTasa.Text = "0.00";
            //                        PonerIsc();

            //                        txtCodArticulo.Focus();
            //                    }

            //                    QuitarEventos("N");

            //                    #endregion
            //                }
            //            }

            //            #endregion
            //        }

            //        txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
            //        txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
            //    txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            //    QuitarEventos("N");
            //    Global.MensajeFault(ex.Message);
            //}
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

        #endregion Eventos

    }
}
