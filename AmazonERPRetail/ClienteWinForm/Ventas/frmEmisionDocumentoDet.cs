using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Ventas;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmEmisionDocumentoDet : FrmBusquedaBase
    {

        #region Constructores
        
        public frmEmisionDocumentoDet()
        {
            InitializeComponent();
            FormatoGrid(dgvArticulo);
        }

        public frmEmisionDocumentoDet(DateTime fecDocumento, EmisionDocumentoDetE emisionDocumento, String Tipo, String EsOt_ = "N")
            :this()
        {
            oDetalleDocumento = emisionDocumento;
            TipoDocumento = Tipo;
            EsOt = EsOt_;
            FechaDocumento = fecDocumento;
            RecuperarDetracciones();
        }

        public frmEmisionDocumentoDet(DateTime fecDocumento, Int32 iOperacion, String Tipo, String EsOt_ = "N")
            :this()
        {
            ValidaControl(iOperacion);
            TipoDocumento = Tipo;
            EsOt = EsOt_;
            FechaDocumento = fecDocumento;
            RecuperarDetracciones();
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        public EmisionDocumentoDetE oDetalleDocumento = null;
        public List<EmisionDocumentoDetE> listEmisionDocumento = null;
        public Boolean EsCompleto = false;
        String TipoDocumento = String.Empty;
        String EsOt = String.Empty;
        DateTime FechaDocumento;
        List<TasasDetraccionesDetalleE> oListaDetracciones = null;

        #endregion

        #region Procedimientos de Usuario

        void Calcular()
        {
            txtPrecVta.TextChanged -= txtPrecVta_TextChanged;

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

            Decimal.TryParse(txtPorcDsct1.Text, out Por1);
            Decimal.TryParse(txtPorcDsct2.Text, out Por2);
            Decimal.TryParse(txtPorcDsct3.Text, out Por3);

            txtDsct1.Text = (SubTotal * (Por1 / 100)).ToString("N2");
            Decimal.TryParse(txtDsct1.Text, out Dscto1);
            txtDsct2.Text = ((SubTotal - Dscto1) * (Por2 / 100)).ToString("N2");
            Decimal.TryParse(txtDsct2.Text, out Dscto2);
            txtDsct3.Text = ((SubTotal - Dscto1 - Dscto2) * (Por3 / 100)).ToString("N2");
            Decimal.TryParse(txtDsct3.Text, out Dscto3);

            #endregion

            txtValVenta.Text = (SubTotal - (Dscto1 + Dscto2 + Dscto3)).ToString("N2");
            Decimal.TryParse(txtValVenta.Text, out ValorVenta);

            //Impuesto Selectivo al Consumo
            Decimal.TryParse(txtPorcIsc.Text, out porIsc);
            txtIsc.Text = (ValorVenta * (porIsc / 100)).ToString("N2");
            Decimal.TryParse(txtIsc.Text, out Isc);

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorcIgv.Text, out porIgv);
            txtIgv.Text = ((ValorVenta + Isc) * (porIgv / 100)).ToString("N2");
            Decimal.TryParse(txtIgv.Text, out Igv);

            //Total General
            txtPrecVta.Text = (ValorVenta + Isc + Igv).ToString("N2");

            #endregion

            txtPrecVta.TextChanged += txtPrecVta_TextChanged;
        }

        void LlenarComboBox()
        {
            try
            {
                cboTipoArticulo.DataSource = null;
                List<ParTabla> ListaTipoUnidad = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
                ParTabla p = new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
                ListaTipoUnidad.Add(p);
                ComboHelper.RellenarCombos<ParTabla>(cboTipoArticulo, (from x in ListaTipoUnidad orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
                
                if (TipoDocumento == "S") //Servicios de ventas
                {
                    Int32 tipArt = Convert.ToInt32((from x in ListaTipoUnidad where x.NemoTecnico == "O10" select x.IdParTabla).First());
                    cboTipoArticulo.SelectedValue = tipArt;
                    cboTipoArticulo.Enabled = false;
                    cboTipoArticulo_SelectionChangeCommitted(new Object(), new EventArgs());
                    txtCantidad.Text = "1.00";
                    dgvArticulo.Focus();
                }
                else if (TipoDocumento == "A") //Anticipos
                {
                    Int32 tipArt = Convert.ToInt32((from x in ListaTipoUnidad where x.NemoTecnico == "O1" select x.IdParTabla).First());
                    cboTipoArticulo.SelectedValue = tipArt;
                    cboTipoArticulo.Enabled = false;
                    cboTipoArticulo_SelectionChangeCommitted(new Object(), new EventArgs());
                    txtDescripcion.Focus();
                    txtCantidad.Text = "1.00";
                }
                else
                {
                    cboTipoArticulo.SelectedValue = Variables.Cero;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        Boolean ValidarInformacion(EmisionDocumentoDetE emisionDocumenoDet)
        {
            if (emisionDocumenoDet.idArticulo != 0)
            {
                if (emisionDocumenoDet.Cantidad == 0)
                {
                    txtCantidad.Focus();
                    MessageBox.Show("Ingrese Cantidad de Producto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (emisionDocumenoDet.PrecioSinImpuesto == 0)
                {
                    txtPrecio.Focus();
                    MessageBox.Show("Ingrese Precio de Producto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }

        void RecuperaDatos()
        {
            try
            {
                if (oDetalleDocumento != null)
                {
                    txtIdArticulo.Text = oDetalleDocumento.idArticulo.ToString();
                    txtCodigo.Text = oDetalleDocumento.codArticulo;
                    txtDescripcion.Text = oDetalleDocumento.nomArticulo;
                    
                    txtPorcDsct1.TextChanged -= txtPorcDsct1_TextChanged;
                    txtPorcDsct2.TextChanged -= txtPorcDsct2_TextChanged;
                    txtPorcDsct3.TextChanged -= txtPorcDsct3_TextChanged;

                    txtPorcDsct1.Text = oDetalleDocumento.porDscto1.ToString("N2");
                    txtPorcDsct2.Text = oDetalleDocumento.porDscto2.ToString("N2");
                    txtPorcDsct3.Text = oDetalleDocumento.porDscto3.ToString("N2");

                    txtPorcDsct1.TextChanged += txtPorcDsct1_TextChanged;
                    txtPorcDsct2.TextChanged += txtPorcDsct2_TextChanged;
                    txtPorcDsct3.TextChanged += txtPorcDsct3_TextChanged;

                    txtCantidad.Text = Convert.ToDecimal(oDetalleDocumento.Cantidad).ToString("N2");
                    txtPrecio.Text = oDetalleDocumento.PrecioSinImpuesto.ToString("N5");

                    if (oDetalleDocumento.flgIgv)
                    {
                        chImpuesto.Checked = true;
                    }

                    txtPorcIsc.Text = oDetalleDocumento.porIsc.ToString("N2");
                    cboTipoArticulo.SelectedValue = oDetalleDocumento.idTipoArticulo;

                    chkDetra.Checked = oDetalleDocumento.indDetraccion;
                    txtTipDetra.Text = oDetalleDocumento.tipDetraccion;
                    txtTasa.Text = oDetalleDocumento.TasaDetraccion.ToString("N2");

                    foreach (DataGridViewRow row in dgvArticulo.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == txtCodigo.Text)
                        {
                            row.Selected = true;
                            dgvArticulo.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }

                    if (EsOt == "S")
                    {
                        dgvArticulo.Enabled = false;
                    }
                }
                else
                {
                    chImpuesto.Checked = VariablesLocales.oVenParametros.indIgv;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ValidaControl(Int32 iOperacion)
        {
            if (iOperacion == 1)//factura
            {
                txtPorcDsct1.Enabled = true;
                txtPorcDsct2.Enabled = true;
                txtPorcDsct3.Enabled = true;
                txtPorcIsc.Enabled = true;
            }

            if (iOperacion == 2) //BOLETA 
            {
                txtPorcIsc.Text = "25";
                txtPorcDsct1.Enabled = true;
                txtPorcDsct2.Enabled = true;
                txtPorcDsct3.Enabled = true;
                txtPorcIsc.Enabled = false;
            }

            if (iOperacion == 3) //NOTAS DE DEBITO
            {
                txtCodigo.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPorcDsct1.Enabled = true;
                txtPorcDsct2.Enabled = true;
                txtPorcDsct3.Enabled = true;
                pnlDetalle.Enabled = false;
            }

            if (iOperacion == 4) //NOTAS DE CREDITO
            {
                txtCodigo.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPorcDsct1.Enabled = false;
                txtPorcDsct2.Enabled = false;
                txtPorcDsct3.Enabled = false;
                pnlDetalle.Enabled = false;
            }

            if (iOperacion == 5) //NOTAS DE DEBITO INAFECTO
            {
                chImpuesto.Visible = false;
                txtCodigo.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPorcDsct1.Enabled = true;
                txtPorcDsct2.Enabled = true;
                txtPorcDsct3.Enabled = true;
                pnlDetalle.Enabled = false;
            }

            if (iOperacion == 6) //NOTAS DE CREDITO INAFECTO
            {
                chImpuesto.Visible = false;
                txtCodigo.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPorcDsct1.Enabled = false;
                txtPorcDsct2.Enabled = false;
                txtPorcDsct3.Enabled = false;
                pnlDetalle.Enabled = false;
            }
        }

        EmisionDocumentoDetE Datos()
        {
            Decimal PrecioConImpuesto = Variables.Cero;
            Decimal Precio = Variables.Cero;
            Decimal porIgv = Variables.Cero;

            if (chImpuesto.Checked)
            {
                Decimal.TryParse(txtPorcIgv.Text, out porIgv);
                Decimal.TryParse(txtPrecio.Text, out Precio);

                PrecioConImpuesto = (Precio * (porIgv / 100)) + Precio;
            }

            return oDetalleDocumento = new EmisionDocumentoDetE()
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                idAlmacen = 0,//Convert.ToInt32(cboAlmacen.SelectedValue);
                idArticulo = Convert.ToInt32(txtIdArticulo.Text),
                codArticulo = txtCodigo.Text,
                nomArticulo = txtDescripcion.Text,
                idTipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue),
                Cantidad = Convert.ToDecimal(txtCantidad.Text),
                CantidadFinal = Convert.ToDecimal(txtCantidad.Text),
                PrecioSinImpuesto = Convert.ToDecimal(txtPrecio.Text),
                PrecioConImpuesto = PrecioConImpuesto,
                subTotal = Convert.ToDecimal(txtSubTotal.Text),
                porDscto1 = Convert.ToDecimal(txtPorcDsct1.Text),
                Dscto1 = Convert.ToDecimal(txtDsct1.Text),
                porDscto2 = Convert.ToDecimal(txtPorcDsct2.Text),
                Dscto2 = Convert.ToDecimal(txtDsct2.Text),
                porDscto3 = Convert.ToDecimal(txtPorcDsct3.Text),
                Dscto3 = Convert.ToDecimal(txtDsct3.Text),
                porIsc = Convert.ToDecimal(txtPorcIsc.Text),
                porIgv = Convert.ToDecimal(txtPorcIgv.Text),
                Isc = Convert.ToDecimal(txtIsc.Text),
                Igv = Convert.ToDecimal(txtIgv.Text),
                Total = Convert.ToDecimal(txtPrecVta.Text),
                flgIgv = chImpuesto.Checked,
                codLineaVenta = ((ArticuloServE)bsBase.Current).codLineaVenta,
                indCalculo = chkCalculo.Checked,
                indDetraccion = ((ArticuloServE)bsBase.Current).indDetraccion,
                tipDetraccion = ((ArticuloServE)bsBase.Current).tipDetraccion,
                TasaDetraccion = Convert.ToDecimal(txtTasa.Text),
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                FechaRegistro = VariablesLocales.FechaHoy,
                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                FechaModificacion = VariablesLocales.FechaHoy
            };
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

            Decimal.TryParse(txtPrecVta.Text, out Total);
            Decimal.TryParse(txtCantidad.Text, out CantidadOrd);
            Decimal.TryParse(txtPrecio.Text, out PrecioUnitario);

            //Impuesto General a la Venta
            Decimal.TryParse(txtPorcIgv.Text, out porIgv);
            subTotal = Total / ((porIgv / 100) + 1);
            txtIgv.Text = (subTotal * (porIgv / 100)).ToString("N2");

            //Sub Total
            txtSubTotal.Text = subTotal.ToString("N2");
            txtValVenta.Text = subTotal.ToString("N2");

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

        void RecuperarDetracciones()
        {
            oListaDetracciones = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(FechaDocumento);
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            try
            {
                if (dgvArticulo.Rows.Count > Variables.Cero)
                {
                    EsCompleto = true;
                    Datos();
                }
                else
                {
                    Decimal PrecioConImpuesto = Variables.Cero;
                    Decimal Precio = Variables.Cero;
                    Decimal porIgv = Variables.Cero;

                    if (chImpuesto.Checked)
                    {
                        Decimal.TryParse(txtPorcIgv.Text, out porIgv);
                        Decimal.TryParse(txtPrecio.Text, out Precio);

                        PrecioConImpuesto = (Precio * (porIgv / 100)) + Precio;
                    }

                    EsCompleto = false;

                    oDetalleDocumento = new EmisionDocumentoDetE()
                    {
                        nomArticulo = txtDescripcion.Text,
                        Cantidad = Convert.ToDecimal(txtCantidad.Text),
                        CantidadFinal = Convert.ToDecimal(txtCantidad.Text),
                        PrecioSinImpuesto = Convert.ToDecimal(txtPrecio.Text),
                        PrecioConImpuesto = PrecioConImpuesto,
                        subTotal = Convert.ToDecimal(txtSubTotal.Text),
                        porDscto1 = Convert.ToDecimal(txtPorcDsct1.Text),
                        Dscto1 = Convert.ToDecimal(txtDsct1.Text),
                        porDscto2 = Convert.ToDecimal(txtPorcDsct2.Text),
                        Dscto2 = Convert.ToDecimal(txtDsct2.Text),
                        porDscto3 = Convert.ToDecimal(txtPorcDsct3.Text),
                        Dscto3 = Convert.ToDecimal(txtDsct3.Text),
                        porIsc = Convert.ToDecimal(txtPorcIsc.Text),
                        porIgv = Convert.ToDecimal(txtPorcIgv.Text),
                        Isc = Convert.ToDecimal(txtIsc.Text),
                        Igv = Convert.ToDecimal(txtIgv.Text),
                        Total = Convert.ToDecimal(txtPrecVta.Text),
                        flgIgv = chImpuesto.Checked,
                        codLineaVenta = String.Empty,
                        indCalculo = chkCalculo.Checked,
                        indDetraccion = chkDetra.Checked,
                        tipDetraccion = txtTipDetra.Text,
                        TasaDetraccion = Convert.ToDecimal(txtTasa.Text),
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy
                    };
                }
                
                base.Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmEmisionDocumentoDet_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            RecuperaDatos();

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886" && TipoDocumento != "S" && oDetalleDocumento != null) //Fundo San Miguel
            {
                pnlDetalle.Enabled = false;
            }

            if (EsOt == "S")
            {
                cboTipoArticulo.Enabled = false;
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

        private void txtPorcDsct1_TextChanged(object sender, EventArgs e)
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

        private void txtPorcDsct2_TextChanged(object sender, EventArgs e)
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

        private void txtPorcDsct3_TextChanged(object sender, EventArgs e)
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

        private void txtPorcIsc_TextChanged(object sender, EventArgs e)
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

        private void txtPorcIgv_TextChanged(object sender, EventArgs e)
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

        private void chImpuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (chImpuesto.Checked)
            {
                ImpuestosPeriodoE objImpuestoPeriodo = AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1);
                txtPorcIgv.Text = (objImpuestoPeriodo.Porcentaje).ToString();
            }
            else
            {
                txtPorcIgv.Text = "0.00";
            }
        }

        private void bsBase_CurrentChanged(object sender, EventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                txtIdArticulo.Text = ((ArticuloServE)bsBase.Current).idArticulo.ToString();
                txtCodigo.Text = ((ArticuloServE)bsBase.Current).codArticulo;
                txtDescripcion.Text = ((ArticuloServE)bsBase.Current).nomArticulo;
                chkDetra.Checked = ((ArticuloServE)bsBase.Current).indDetraccion;
                txtTipDetra.Text = ((ArticuloServE)bsBase.Current).tipDetraccion;

                if (chkDetra.Checked)
                {
                    TasasDetraccionesDetalleE oDetra = oListaDetracciones.Find
                    (
                        delegate (TasasDetraccionesDetalleE d) { return d.idTipoDetraccion == ((ArticuloServE)bsBase.Current).tipDetraccion; }
                    );

                    if (oDetra != null)
                    {
                        txtTasa.Text = oDetra.Porcentaje.ToString("N2");
                    }
                    else
                    {
                        txtTasa.Text = "0.00";
                    }
                }
                else
                {
                    txtTasa.Text = "0.00";
                }
            }
        }

        private void cboTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                bsBase.DataSource = AgenteMaestros.Proxy.ListarArticulosBusqueda(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboTipoArticulo.SelectedValue), "");
                bsBase.ResetBindings(false);
                dgvArticulo.Focus();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCantidad.Focus();
            }
        }

        private void cboTipoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dgvArticulo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvArticulo, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            txtCantidad.Text = Global.FormatoDecimal(txtCantidad.Text, 4);
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            txtPrecio.Text = Global.FormatoDecimal(txtPrecio.Text, 5);
        }

        private void txtPorcDsct1_Leave(object sender, EventArgs e)
        {
            txtPorcDsct1.Text = Global.FormatoDecimal(txtPorcDsct1.Text);
        }

        private void txtPorcDsct2_Leave(object sender, EventArgs e)
        {
            txtPorcDsct2.Text = Global.FormatoDecimal(txtPorcDsct2.Text);
        }

        private void txtPorcDsct3_Leave(object sender, EventArgs e)
        {
            txtPorcDsct3.Text = Global.FormatoDecimal(txtPorcDsct3.Text);
        }

        private void txtPorcIsc_Leave(object sender, EventArgs e)
        {
            txtPorcIsc.Text = Global.FormatoDecimal(txtPorcIsc.Text);
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

        private void txtPorcDsct1_Enter(object sender, EventArgs e)
        {
            txtPorcDsct1.SelectAll();
        }

        private void txtPorcDsct1_MouseClick(object sender, MouseEventArgs e)
        {
            txtPorcDsct1.SelectAll();
        }

        private void txtPorcDsct2_Enter(object sender, EventArgs e)
        {
            txtPorcDsct2.SelectAll();
        }

        private void txtPorcDsct2_MouseClick(object sender, MouseEventArgs e)
        {
            txtPorcDsct2.SelectAll();
        }

        private void txtPorcDsct3_Enter(object sender, EventArgs e)
        {
            txtPorcDsct3.SelectAll();
        }

        private void txtPorcDsct3_MouseClick(object sender, MouseEventArgs e)
        {
            txtPorcDsct3.SelectAll();
        }

        private void txtPorcIsc_Enter(object sender, EventArgs e)
        {
            txtIsc.SelectAll();
        }

        private void txtPorcIsc_MouseClick(object sender, MouseEventArgs e)
        {
            txtIsc.SelectAll();
        }

        private void dgvArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPrecVta_TextChanged(object sender, EventArgs e)
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

        private void txtPrecVta_Leave(object sender, EventArgs e)
        {
            //txtPrecio.TextChanged -= txtPrecio_TextChanged;

            txtPrecVta.Text = Global.FormatoDecimal(txtPrecVta.Text, 2);

            //txtPrecio.TextChanged += txtPrecio_TextChanged;
        }

        #endregion

    }
}
