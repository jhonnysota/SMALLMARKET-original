using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Almacen;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmDetalleConceptoProvision : frmResponseBase
    {

        #region Constructores

        public frmDetalleConceptoProvision()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        public frmDetalleConceptoProvision(Int32 Tipo, DateTime Fecha, String TipoArticulo_, Int32 TipoColumna, String idMoneda_, Boolean indDistribuir = false, String Bloq = "N", String TipoCuenta_ = "", Int32 EsAnticipo_ = 0)
            :this()
        {
            TipoConcepto = Tipo;
            FechaTica = Fecha;
            TipoArticulo = TipoArticulo_;
            BloquearCombo = Bloq;
            TipoCuenta = TipoCuenta_;
            EsAnticipo = EsAnticipo_;

            if (TipoArticulo == "S")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Servicios";
            }
            else if (TipoArticulo == "G")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Gastos";
            }
            else if (TipoArticulo == "C")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Activos";
            }
            else if (TipoArticulo == "N")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Anticipos";
            }
            else if (String.IsNullOrWhiteSpace(TipoArticulo))
            {
                lblTituloPrincipal.Text = "Detalle Compras - Gastos y Servicios";
            }

            colCoVen = TipoColumna;
            idMoneda = idMoneda_;

            if (indDistribuir)
            {
                btDistribuir.Visible = Distribucion = true;
            }
        }

        public frmDetalleConceptoProvision(Provisiones_PorCCostoE Provision, String Estado, Boolean indDistribuir = false, String Bloq = "N", String TipoCuenta_ = "")
            :this()
        {
            oProvisionCompra = Provision;
            BloquearCombo = Bloq;
            TipoCuenta = TipoCuenta_;

            if (indDistribuir)
            {
                btDistribuir.Visible = Distribucion = true;
            }

            if (Estado == "PR")
            {
                pnlBase.Enabled = false;
                pnlAuditoria.Enabled = false;
                pnlMontos.Enabled = false;
                btAceptar.Enabled = false;
            }

            TipoArticulo = oProvisionCompra.Tipo;

            if (oProvisionCompra.Tipo == "N")
            {
                EsAnticipo = 1;
            }

            if (oProvisionCompra.Tipo == "S")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Servicios";
            }
            else if (oProvisionCompra.Tipo == "G")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Gastos";
            }
            else if (oProvisionCompra.Tipo == "C")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Activos";
            }
            else if (oProvisionCompra.Tipo == "N")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Anticipos";
            }
            else if (oProvisionCompra.Tipo == "P")
            {
                lblTituloPrincipal.Text = "Detalle Compras - Aplicación de Anticipos";
            }
            else if (String.IsNullOrWhiteSpace(TipoArticulo))
            {
                lblTituloPrincipal.Text = "Detalle Compras - Gastos y Servicios";
            }
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public Provisiones_PorCCostoE oProvisionCompra = null;
        public List<Provisiones_PorCCostoE> oListaCompras = null;
        public ConceptosVariosE oConcepto = null;
        Int32 TipoConcepto = 0;
        String TipoArticulo = String.Empty;
        String idMoneda = String.Empty;
        DateTime FechaTica;
        Int32 colCoVen = 0;
        Boolean Distribucion = false;
        String BloquearCombo = "N";
        String TipoCuenta = String.Empty;
        Boolean BuscarDato = true;
        Int32 EsAnticipo = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             where (x.idMoneda == Variables.Soles) ||
                                                                   (x.idMoneda == Variables.Dolares)
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);

            //Columna de Compra
            List<ParTabla> ListarCoVen = new List<ParTabla>(VariablesLocales.oListaBasesImponibles);//AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPBA");
            ParTabla iniCoVen = new ParTabla() { IdParTabla = 0, Descripcion = "[Escoger Columna]" };
            ListarCoVen.Add(iniCoVen);
            ComboHelper.RellenarCombos<ParTabla>(cboCoVen, (from x in ListarCoVen orderby x.IdParTabla select x).ToList(), "IdParTabla", "Descripcion", false);
            cboCoVen.SelectedValue = 0;
        }

        void LlenarComboCuentas(ConceptosVariosE oConcepto)
        {
            List<ConceptosVariosE> ListarCuentas = new List<ConceptosVariosE>();
            ConceptosVariosE oCuenta = null;

            if (oConcepto.indCuentaAdm)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaAdm,
                    Descripcion = "ADMINISTRACION",
                    indCentroCosto = oConcepto.indCCAdm,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas
                };

                ListarCuentas.Add(oCuenta);
            }

            if (oConcepto.indCuentaVen)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaVen,
                    Descripcion = "VENTAS",
                    indCentroCosto = oConcepto.indCCVen,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas
                };

                ListarCuentas.Add(oCuenta);
            }

            if (oConcepto.indCuentaPro)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaPro,
                    Descripcion = "PRODUCCION",
                    indCentroCosto = oConcepto.indCCPro,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas
                };

                ListarCuentas.Add(oCuenta);
            }

            if (oConcepto.indCuentaFin)
            {
                oCuenta = new ConceptosVariosE()
                {
                    Cuentas = oConcepto.codCuentaFin,
                    Descripcion = "FINANZAS",
                    indCentroCosto = oConcepto.indCCFin,
                    numVerPlanCuentas = oConcepto.numVerPlanCuentas
                };

                ListarCuentas.Add(oCuenta);
            }

            // Llenando las cuentas
            ComboHelper.RellenarCombos<ConceptosVariosE>(cboCuentas, ListarCuentas, "Cuentas", "Descripcion", false);
        }

        void Calcular()
        {
            if (chkCalculos.Checked)
            {
                txtTotal.TextChanged -= txtTotal_TextChanged;

                #region Variables

                Decimal Cantidad = Variables.Cero;
                Decimal Precio = Variables.Cero;
                Decimal Igv = Variables.Cero;
                Decimal SubTotal = Variables.Cero;
                //Decimal ValorVenta = Variables.Cero;
                Decimal porIgv = Variables.Cero;

                #endregion

                #region Parseando para evitar errores de escritura

                Decimal.TryParse(txtCantidad.Text, out Cantidad);
                Decimal.TryParse(txtPrecio.Text, out Precio);

                txtSubTotal.Text = (Precio * Cantidad).ToString("N2");
                Decimal.TryParse(txtSubTotal.Text, out SubTotal);

                //Impuesto General a la Venta
                Decimal.TryParse(txtPorIgv.Text, out porIgv);
                txtIgv.Text = ((SubTotal) * (porIgv / 100)).ToString("N2");
                Decimal.TryParse(txtIgv.Text, out Igv);

                //Total General
                //txtValorVenta.Text = SubTotal.ToString("N2");
                //Decimal.TryParse(txtValorVenta.Text, out ValorVenta);
                txtTotal.Text = (SubTotal + Igv).ToString("N2");

                #endregion 

                txtTotal.TextChanged += txtTotal_TextChanged;
            }
        }

        void CalcularReves()
        {
            if (chkCalculos.Checked)
            {
                txtPrecio.TextChanged -= txtPrecio_TextChanged;
                txtCantidad.TextChanged -= txtCantidad_TextChanged;

                Decimal Total = Variables.ValorCeroDecimal;
                Decimal subTotal = Variables.ValorCeroDecimal;
                Decimal CantidadOrd = Variables.ValorCeroDecimal;
                Decimal PrecioUnitario = Variables.ValorCeroDecimal;
                Decimal porIgv = Variables.Cero;

                Decimal.TryParse(txtTotal.Text, out Total);
                Decimal.TryParse(txtCantidad.Text, out CantidadOrd);
                Decimal.TryParse(txtPrecio.Text, out PrecioUnitario);

                //Impuesto General a la Venta
                Decimal.TryParse(txtPorIgv.Text, out porIgv);
                subTotal = Total / ((porIgv / 100) + 1);
                txtIgv.Text = (subTotal * (porIgv / 100)).ToString("N2");

                //Sub Total
                txtSubTotal.Text = subTotal.ToString("N2");

                //Cantidad y Precio Unitario
                if (CantidadOrd > 0)
                {
                    PrecioUnitario = subTotal / CantidadOrd;
                    txtPrecio.Text = PrecioUnitario.ToString("N2");
                }
                else if (PrecioUnitario > 0)
                {
                    CantidadOrd = subTotal / PrecioUnitario;
                    txtCantidad.Text = CantidadOrd.ToString("N2");
                }

                txtPrecio.TextChanged += txtPrecio_TextChanged;
                txtCantidad.TextChanged += txtCantidad_TextChanged;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oProvisionCompra == null)
            {
                BuscarDato = false;

                oProvisionCompra = new Provisiones_PorCCostoE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas
                };

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;

                TipoCambioE Tica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, FechaTica.ToString("yyyyMMdd"));

                if (Tica != null)
                {
                    txtTica.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }

                cboCoVen.SelectedValue = Convert.ToInt32(colCoVen);
                cboCoVen_SelectionChangeCommitted(new Object(), new EventArgs());
                cboMoneda.SelectedValue = idMoneda.ToString();
                oProvisionCompra.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                BuscarDato = true;
            }
            else
            {
                txtPrecio.TextChanged -= txtPrecio_TextChanged;
                txtCantidad.TextChanged -= txtCantidad_TextChanged;
                txtPorIgv.TextChanged -= txtPorIgv_TextChanged;
                chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                chkTica.CheckedChanged -= chkTica_CheckedChanged;
                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
                txtTotal.TextChanged -= txtTotal_TextChanged;

                txtCodConcepto.Text = oProvisionCompra.Codigo;
                txtIdConcepto.Text = oProvisionCompra.idConcepto.ToString();
                txtDesConcepto.Text = oProvisionCompra.Descripcion;
                cboMoneda.SelectedValue = oProvisionCompra.idMoneda.ToString();
                txtTica.Text = oProvisionCompra.tipCambio.ToString("N3");
                chkTica.Checked = oProvisionCompra.indCambio;
                chkIgv.Checked = oProvisionCompra.indIgv;
                txtCantidad.Text = oProvisionCompra.Cantidad.ToString("N2");
                txtPrecio.Text = oProvisionCompra.PrecioUnitario.ToString("N5");
                txtPorIgv.Text = oProvisionCompra.porIgv.ToString("N2");
                txtIgv.Text = oProvisionCompra.Igv.ToString("N2");
                txtSubTotal.Text = oProvisionCompra.subTotal.ToString("N2");

                if (oProvisionCompra.idMoneda == Variables.Soles)
                {
                    txtTotal.Text = oProvisionCompra.impSoles.ToString("N2");
                }
                else
                {
                    txtTotal.Text = oProvisionCompra.impDolares.ToString("N2");
                }

                txtIdCostos.Text = oProvisionCompra.idCCostos;
                txtDesCostos.Text = oProvisionCompra.DesCCosto;
                cboCoVen.SelectedValue = Convert.ToInt32(oProvisionCompra.codColumnaCoven);
                //oProvisionCompra.Tipo = TipoArticulo;
                chkHojaCosto.Checked = oProvisionCompra.FlagHC;

                ConceptosVariosE oConcepto = null;

                if (VariablesLocales.EsLiquidacion == Variables.NO)
                {
                    oConcepto = AgenteAlmacen.Proxy.RecuperarConceptosVarios(oProvisionCompra.idConcepto.Value, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, false);
                }
                else
                {
                    oConcepto = AgenteAlmacen.Proxy.RecuperarConceptosVarios(oProvisionCompra.idConcepto.Value, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, true);
                }

                if (oConcepto != null)
                {
                    LlenarComboCuentas(oConcepto);
                    cboCuentas.SelectedValue = oProvisionCompra.codCuenta.ToString();
                    cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());
                }

                chkCalculos.Checked = oProvisionCompra.Calculo == "A" ? true : false;

                txtUsuarioRegistro.Text = oProvisionCompra.UsuarioRegistro;
                txtFechaRegistro.Text = oProvisionCompra.FechaRegistro.ToString();
                txtUsuarioMod.Text = oProvisionCompra.UsuarioModificacion;
                txtFechaModifica.Text = oProvisionCompra.FechaModificacion.ToString();

                if (oProvisionCompra.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oProvisionCompra.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtPrecio.TextChanged += txtPrecio_TextChanged;
                txtCantidad.TextChanged += txtCantidad_TextChanged;
                txtPorIgv.TextChanged += txtPorIgv_TextChanged;
                chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                chkTica.CheckedChanged += chkTica_CheckedChanged;
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                txtTotal.TextChanged += txtTotal_TextChanged;

                if (TipoArticulo == "P")
                {
                    txtCodConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    //txtDesConcepto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    btBuscarArticulo.Enabled = false;
                    cboCuentas.Enabled = false;
                    btCostos.Enabled = false;
                    cboMoneda.Enabled = false;
                    cboCoVen.Enabled = false;
                    txtCantidad.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtTotal.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    chkIgv.Enabled = false;
                    chkCalculos.Enabled = false;
                }
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (String.IsNullOrEmpty(txtIdConcepto.Text.Trim()))
                {
                    Global.MensajeComunicacion("Debe ingresar un concepto.");
                    txtCodConcepto.Focus();
                    return;
                }

                if (!Distribucion)
                {
                    if (cboCuentas.SelectedItem != null)
                    {
                        if (((ConceptosVariosE)cboCuentas.SelectedItem).indCentroCosto == Variables.SI)
                        {
                            if (String.IsNullOrEmpty(txtIdCostos.Text.Trim()))
                            {
                                Global.MensajeFault("Debe ingresar un centro de costo.");
                                return;
                            }
                        } 
                    }
                }

                if (oProvisionCompra != null)
                {
                    oProvisionCompra.Codigo = txtCodConcepto.Text;
                    oProvisionCompra.idConcepto = Convert.ToInt32(txtIdConcepto.Text);
                    oProvisionCompra.Descripcion = txtDesConcepto.Text.Trim();
                    oProvisionCompra.codCuenta = cboCuentas.SelectedValue != null ? cboCuentas.SelectedValue.ToString() : String.Empty;
                    oProvisionCompra.idMoneda = cboMoneda.SelectedValue.ToString();
                    oProvisionCompra.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                    oProvisionCompra.tipCambio = Convert.ToDecimal(txtTica.Text);
                    oProvisionCompra.indCambio = chkTica.Checked;
                    oProvisionCompra.indIgv = chkIgv.Checked;
                    oProvisionCompra.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    oProvisionCompra.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                    oProvisionCompra.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                    oProvisionCompra.Igv = Convert.ToDecimal(txtIgv.Text);
                    oProvisionCompra.subTotal = Convert.ToDecimal(txtSubTotal.Text);

                    Decimal.TryParse(txtTotal.Text, out Decimal Importe);
                    Decimal.TryParse(txtTica.Text, out Decimal tica);

                    if (oProvisionCompra.idMoneda == Variables.Soles)
                    {
                        oProvisionCompra.impSoles = oProvisionCompra.MontoCuenta = Importe;
                        oProvisionCompra.impDolares = Importe / tica;
                    }
                    else
                    {
                        oProvisionCompra.impDolares = oProvisionCompra.MontoCuenta = Importe;
                        oProvisionCompra.impSoles = Importe * tica;
                    }

                    oProvisionCompra.idCCostos = txtIdCostos.Text.Trim();
                    oProvisionCompra.DesCCosto = txtDesCostos.Text.Trim();

                    if (String.IsNullOrEmpty(oProvisionCompra.desGlosa))
                    {
                        oProvisionCompra.desGlosa = String.Empty;
                    }
                    
                    oProvisionCompra.codColumnaCoven = Convert.ToInt32(cboCoVen.SelectedValue);
                    oProvisionCompra.DesColumnaCoven = ((ParTabla)cboCoVen.SelectedItem).Nombre;
                    oProvisionCompra.Tipo = TipoArticulo;
                    oProvisionCompra.Calculo = chkCalculos.Checked ? "A" : "M";
                    oProvisionCompra.FlagHC = chkHojaCosto.Checked;

                    if (oProvisionCompra.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oProvisionCompra.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oProvisionCompra.FechaRegistro = VariablesLocales.FechaHoy;
                        oProvisionCompra.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oProvisionCompra.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oProvisionCompra.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oProvisionCompra.FechaModificacion = VariablesLocales.FechaHoy;
                    }

                    base.Aceptar();
                }
                else
                {
                    if (oListaCompras != null && oListaCompras.Count > 0)
                    {
                        base.Aceptar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos de Usuario

        private void lblListaTmp_DoubleClick(object sender, EventArgs e)
        {
            txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
            txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
            txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

            ListBox lb = (ListBox)sender;

            txtIdConcepto.Text = lb.SelectedValue.ToString();
            txtCodConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).codConcepto;
            txtDesConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).Descripcion;

            if (!String.IsNullOrWhiteSpace(((ConceptosVariosE)lb.SelectedItem).Nemo))
            {
                if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCSER") //Servicios
                {
                    TipoArticulo = "S";
                }
                else if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCGAS") //Gastos
                {
                    TipoArticulo = "G";
                }
                else if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCACT") //Activos
                {
                    TipoArticulo = "C";
                }
                else if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCVAR") //Varios
                {
                    TipoArticulo = "V";
                }
                else
                {
                    TipoArticulo = "A";
                }
            }

            LlenarComboCuentas((ConceptosVariosE)lb.SelectedItem);
            cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());

            if (cboCuentas.SelectedValue != null)
            {
                if (TipoCuenta == "TLVE") //Venta
                {
                    cboCuentas.SelectedIndex = 1;
                }

                if (TipoCuenta == "TLADM") //Administración
                {
                    cboCuentas.SelectedIndex = 0;
                }

                if (TipoCuenta == "TLPRO") //Producción
                {
                    cboCuentas.SelectedIndex = 2;
                }
            }

            oConcepto = Colecciones.CopiarEntidad<ConceptosVariosE>((ConceptosVariosE)lb.SelectedItem);
            lb.Visible = false;
            lb.Dispose();
            txtPrecio.Focus();

            txtIdCostos.TextChanged += txtIdCostos_TextChanged;
            txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
            txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
        }

        private void lblListaTmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
                txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                ListBox lb = (ListBox)sender;

                txtIdConcepto.Text = lb.SelectedValue.ToString();
                txtCodConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).codConcepto;
                txtDesConcepto.Text = ((ConceptosVariosE)lb.SelectedItem).Descripcion;

                if (!String.IsNullOrWhiteSpace(((ConceptosVariosE)lb.SelectedItem).Nemo))
                {
                    if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCSER") //Servicios
                    {
                        TipoArticulo = "S";
                    }
                    else if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCGAS") //Gastos
                    {
                        TipoArticulo = "G";
                    }
                    else if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCACT") //Activos
                    {
                        TipoArticulo = "C";
                    }
                    else if (((ConceptosVariosE)lb.SelectedItem).Nemo == "TCVAR") //Varios
                    {
                        TipoArticulo = "V";
                    }
                    else
                    {
                        TipoArticulo = "A";
                    }
                }

                LlenarComboCuentas((ConceptosVariosE)lb.SelectedItem);
                cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());

                if (cboCuentas.SelectedValue != null)
                {
                    if (TipoCuenta == "TLVE") //Venta
                    {
                        cboCuentas.SelectedIndex = 1;
                    }

                    if (TipoCuenta == "TLADM") //Administración
                    {
                        cboCuentas.SelectedIndex = 0;
                    }

                    if (TipoCuenta == "TLPRO") //Producción
                    {
                        cboCuentas.SelectedIndex = 2;
                    }
                }

                oConcepto = Colecciones.CopiarEntidad<ConceptosVariosE>((ConceptosVariosE)lb.SelectedItem);
                lb.Visible = false;
                lb.Dispose();
                txtPrecio.Focus();

                txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
            }
        }

        #endregion

        #region Eventos

        private void frmDetalleConceptoProvision_Load(object sender, EventArgs e)
        {
            try
            {
                Nuevo();

                if (BloquearCombo == Variables.SI)
                {
                    cboCuentas.Enabled = false;
                    cboCoVen.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarConceptosVarios oFrm = new frmBuscarConceptosVarios(TipoConcepto, EsAnticipo);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;
                    txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                    txtIdCostos.TextChanged -= txtIdCostos_TextChanged;

                    oConcepto = Colecciones.CopiarEntidad<ConceptosVariosE>(oFrm.oConcepto);
                    txtIdConcepto.Text = oConcepto.idConcepto.ToString();
                    txtCodConcepto.Text = oConcepto.codConcepto;
                    txtDesConcepto.Text = oConcepto.Descripcion;

                    if (!String.IsNullOrWhiteSpace(oConcepto.Nemo))
                    {
                        if (oConcepto.Nemo == "TCSER") //Servicios
                        {
                            TipoArticulo = "S";
                        }
                        else if (oConcepto.Nemo == "TCGAS") //Gastos
                        {
                            TipoArticulo = "G";

                            if (EsAnticipo == 1)
                            {
                                TipoArticulo = "N"; //Es anticipo
                            }
                        }
                        else if (oConcepto.Nemo == "TCACT") //Activos
                        {
                            TipoArticulo = "C";
                        }
                        else if (oConcepto.Nemo == "TCVAR") //Varios
                        {
                            TipoArticulo = "V";
                        }
                        else
                        {
                            TipoArticulo = "A";
                        }
                    }

                    LlenarComboCuentas(oConcepto);
                    cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (cboCuentas.SelectedValue != null)
                    {
                        if (TipoCuenta == "TLVE") //Venta
                        {
                            cboCuentas.SelectedIndex = 1;
                        }

                        if (TipoCuenta == "TLADM") //Administración
                        {
                            cboCuentas.SelectedIndex = 0;
                        }

                        if (TipoCuenta == "TLPRO") //Producción
                        {
                            cboCuentas.SelectedIndex = 2;
                        } 
                    }

                    txtPrecio.Focus();

                    txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                    txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                    txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void btCostos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(1);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
                {
                    txtIdCostos.Text = oFrm.CentroCosto.idCCostos;
                    txtDesCostos.Text = oFrm.CentroCosto.desCCostos;
                }
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

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                txtPrecio.Text = Global.FormatoDecimal(txtPrecio.Text, 5);
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                txtCantidad.Text = Global.FormatoDecimal(txtCantidad.Text);
            }
        }

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIgv.Checked)
                {
                    Decimal Porcentaje = VariablesLocales.oListaImpuestos[0].Porcentaje;
                    txtPorIgv.Text = Porcentaje.ToString();

                    if (BuscarDato)
                    {
                        ParTabla Base = VariablesLocales.oListaBasesImponibles.Find
                                    (
                                        delegate (ParTabla b) { return b.NemoTecnico == "BAIMP"; }
                                    );

                        if (Base != null)
                        {
                            cboCoVen.SelectedValue = Base.IdParTabla;
                        } 
                    }
                }
                else
                {
                    txtPorIgv.Text = "0.00";

                    ParTabla Base = VariablesLocales.oListaBasesImponibles.Find
                    (
                        delegate (ParTabla b) { return b.NemoTecnico == "BAINA"; }
                    );

                    if (Base != null)
                    {
                        cboCoVen.SelectedValue = Base.IdParTabla;
                    }
                }
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

        private void chkTica_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTica.Checked)
                {
                    txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }
                else
                {
                    txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtTica.Text = "0.000";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboCoVen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BuscarDato = false;

                if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAIMP") //Base Imponible
                {
                    chkIgv.Enabled = chkIgv.Checked = true;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAINA") //Base Inafecta
                {
                    chkIgv.Checked = chkIgv.Enabled = false;
                    //chkIgv.Enabled = false;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAGNO") //Base Gravada y No Gravada
                {
                    chkIgv.Enabled = chkIgv.Checked = true;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BASDE") //Base sin Derecho
                {
                    chkIgv.Checked = chkIgv.Enabled = true;
                    //chkIgv.Enabled = false;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAEXP") //Base Exportación
                {
                    chkIgv.Checked = chkIgv.Enabled = false;
                    //chkIgv.Enabled = false;
                }
                
                BuscarDato = true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtIdCostos_TextChanged(object sender, EventArgs e)
        {
            txtDesCostos.Text = String.Empty;
        }

        private void cboCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboCuentas.SelectedValue != null)
                {
                    if (((ConceptosVariosE)cboCuentas.SelectedItem).indCentroCosto == Variables.SI)
                    {
                        btCostos.Enabled = true;
                        txtIdCostos.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }
                    else
                    {
                        btCostos.Enabled = false;
                        txtIdCostos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCodConcepto_TextChanged(object sender, EventArgs e)
        {
            txtIdConcepto.Text = String.Empty;
            txtDesConcepto.Text = String.Empty;
            cboCuentas.DataSource = null;
        }

        private void btDistribuir_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTotal.Text) <= 0)
            {
                Global.MensajeComunicacion("El monto no puede ser 0.");
                return;
            }

            frmVoucherItemCCostos oFrm = new frmVoucherItemCCostos(Convert.ToDecimal(txtTotal.Text));

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oLista != null && oFrm.oLista.Count > 0)
            {
                List<VoucherItemCCostosE> oListaCostos = new List<VoucherItemCCostosE>(oFrm.oLista);
                Provisiones_PorCCostoE oItem = null;
                oListaCompras = new List<Provisiones_PorCCostoE>();
                Int32 numItem = 1;
                String TipoCosto = String.Empty;
                Decimal Cantidad = Convert.ToDecimal(txtCantidad.Text) / oListaCostos.Count;

                foreach (VoucherItemCCostosE itemCosto in oListaCostos)
                {
                    oItem = new Provisiones_PorCCostoE()
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal,
                        idItem = numItem,
                        Codigo = txtCodConcepto.Text,
                        idConcepto = Convert.ToInt32(txtIdConcepto.Text),
                        Descripcion = txtDesConcepto.Text.Trim(),
                        numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas
                    };

                    if (cboCuentas.SelectedValue != null)
                    {
                        if (itemCosto.TipoCC == "1")
                        {
                            cboCuentas.SelectedIndex = 0;
                            oItem.codCuenta = cboCuentas.SelectedValue.ToString();
                        }
                        else if (itemCosto.TipoCC == "2")
                        {
                            cboCuentas.SelectedIndex = 1;
                            oItem.codCuenta = cboCuentas.SelectedValue.ToString();
                        }
                        else
                        {
                            cboCuentas.SelectedIndex = 2;
                            oItem.codCuenta = cboCuentas.SelectedValue.ToString();
                        }
                    }

                    oItem.idMoneda = cboMoneda.SelectedValue.ToString();
                    oItem.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                    oItem.tipCambio = Convert.ToDecimal(txtTica.Text);
                    oItem.indCambio = chkTica.Checked;
                    oItem.indIgv = chkIgv.Checked;
                    oItem.Cantidad = Cantidad;
                    oItem.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);

                    if (chkIgv.Checked)
                    {
                        oItem.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                        oItem.Igv = itemCosto.ImportePorcentaje.Value - Convert.ToDecimal(itemCosto.ImportePorcentaje / ((oItem.porIgv / 100) + 1));
                    }
                    else
                    {
                        oItem.porIgv = 0;
                        oItem.Igv = 0;
                    }

                    oItem.subTotal = Convert.ToDecimal(itemCosto.ImportePorcentaje - oItem.Igv);

                    Decimal Importe = itemCosto.ImportePorcentaje.Value;
                    Decimal tica = Variables.Cero;
                    Decimal.TryParse(txtTica.Text, out tica);

                    if (oItem.idMoneda == Variables.Soles)
                    {
                        oItem.impSoles = oItem.MontoCuenta = Importe;
                        oItem.impDolares = Importe / tica;
                    }
                    else
                    {
                        oItem.impDolares = oItem.MontoCuenta = Importe;
                        oItem.impSoles = Importe * tica;
                    }

                    oItem.idCCostos = itemCosto.idCCostos;
                    oItem.DesCCosto = itemCosto.desCCostos;

                    if (String.IsNullOrEmpty(oItem.desGlosa))
                    {
                        oItem.desGlosa = String.Empty;
                    }

                    oItem.codColumnaCoven = Convert.ToInt32(cboCoVen.SelectedValue);
                    oItem.DesColumnaCoven = ((ParTabla)cboCoVen.SelectedItem).Nombre;
                    oItem.Tipo = TipoArticulo;
                    oItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                    oItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oItem.FechaRegistro = VariablesLocales.FechaHoy;
                    oItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oItem.FechaModificacion = VariablesLocales.FechaHoy;

                    numItem++;
                    oListaCompras.Add(oItem);
                }

                oProvisionCompra = null;
            }
        }

        private void chkCalculos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCalculos.Checked)
            {
                chkCalculos.Text = "Cálculos Automáticos";
                txtIgv.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtSubTotal.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                chkCalculos.Text = "Cálculos Manuales";
                txtIgv.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtSubTotal.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularReves();
        }

        private void txtDesConcepto_TextChanged(object sender, EventArgs e)
        {
            txtIdConcepto.Text = String.Empty;
            txtCodConcepto.Text = String.Empty;
            cboCuentas.DataSource = null;
        }

        private void txtDesConcepto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (TipoArticulo != "P") //Diferente a aplicación de anticipo...
                {
                    txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
                    txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                    if (String.IsNullOrWhiteSpace(txtCodConcepto.Text) && !String.IsNullOrWhiteSpace(txtDesConcepto.Text))
                    {
                        //List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosBusqueda(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtDesConcepto.Text.Trim(), true, 5);
                        List<ConceptosVariosE> oListaConceptos = null; //AgenteAlmacen.Proxy.ConceptosVariosCompras(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtDesConcepto.Text.Trim(), true);

                        if (VariablesLocales.EsLiquidacion == Variables.NO)
                        {
                            oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosCompras(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtDesConcepto.Text.Trim(), false);
                        }
                        else
                        {
                            oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosCompras(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtDesConcepto.Text.Trim(), true);
                        }

                        if (oListaConceptos.Count == 1)
                        {
                            oConcepto = Colecciones.CopiarEntidad(oListaConceptos[0]);

                            txtIdConcepto.Text = oConcepto.idConcepto.ToString();
                            txtCodConcepto.Text = oConcepto.codConcepto;
                            txtDesConcepto.Text = oConcepto.Descripcion;

                            if (!String.IsNullOrWhiteSpace(oConcepto.Nemo))
                            {
                                if (oListaConceptos[0].Nemo == "TCSER")
                                {
                                    TipoArticulo = "S";
                                }
                                else if (oListaConceptos[0].Nemo == "TCGAS")
                                {
                                    TipoArticulo = "G";

                                    if (EsAnticipo == 1)
                                    {
                                        TipoArticulo = "N"; //Es anticipo
                                    }
                                }
                                else if (oListaConceptos[0].Nemo == "TCACT")
                                {
                                    TipoArticulo = "C";
                                }
                                else if (oListaConceptos[0].Nemo == "TCVAR")
                                {
                                    TipoArticulo = "V";
                                }
                                else
                                {
                                    TipoArticulo = "A";
                                }
                            }

                            LlenarComboCuentas(oConcepto);
                            cboCuentas_SelectionChangeCommitted(new Object(), new EventArgs());

                            if (cboCuentas.SelectedValue != null)
                            {
                                if (TipoCuenta == "TLVE") //Venta
                                {
                                    cboCuentas.SelectedIndex = 1;
                                }

                                if (TipoCuenta == "TLADM") //Administración
                                {
                                    cboCuentas.SelectedIndex = 0;
                                }

                                if (TipoCuenta == "TLPRO") //Producción
                                {
                                    cboCuentas.SelectedIndex = 2;
                                }
                            }

                            txtPrecio.Focus();
                        }
                        else if (oListaConceptos.Count > 1)
                        {
                            ListBox lblListaTmp = new ListBox()
                            {
                                FormattingEnabled = true,
                                Location = new System.Drawing.Point(txtDesConcepto.Location.X, txtDesConcepto.Location.Y + txtDesConcepto.Height + 1),
                                Size = new System.Drawing.Size(464, 43),
                                TabIndex = 0
                            };

                            lblListaTmp.Focus();
                            pnlBase.Controls.Add(lblListaTmp);
                            lblListaTmp.BringToFront();

                            lblListaTmp.DataSource = oListaConceptos;
                            lblListaTmp.DisplayMember = "Descripcion";
                            lblListaTmp.ValueMember = "idConcepto";

                            lblListaTmp.Focus();
                            lblListaTmp.DoubleClick += new EventHandler(lblListaTmp_DoubleClick);
                            lblListaTmp.KeyDown += new KeyEventHandler(lblListaTmp_KeyDown);
                        }
                        else
                        {
                            Global.MensajeComunicacion("La descripción del concepto no existe. Vuelva a ingresarlo nuevamente.");
                            txtDesConcepto.Text = String.Empty;
                            cboCuentas.DataSource = null;
                            txtDesConcepto.Focus();
                        }
                    }

                    txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                    txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                    txtDesConcepto.TextChanged += txtDesConcepto_TextChanged; 
                }
            }
            catch (Exception ex)
            {
                txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
