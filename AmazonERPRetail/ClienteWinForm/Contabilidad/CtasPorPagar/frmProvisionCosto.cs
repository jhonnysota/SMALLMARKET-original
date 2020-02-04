using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.CtasPorPagar;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmProvisionCosto : frmResponseBase
    {

        #region Constructores

        public frmProvisionCosto()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombo();
        }

        //Nuevo
        public frmProvisionCosto(DateTime Fecha, Int32 TipoColumna, string idMoneda_, Boolean indDistribuir = false)
            :this()
        {
            FechaTica = Fecha;
            colCoVen = TipoColumna;
            idMoneda = idMoneda_;
        }

        //Edición
        public frmProvisionCosto(Provisiones_PorCCostoE MiEntidad, string Estado)
            :this()
        {
            Detalle = MiEntidad; // AgenteCtasPorPagar.Proxy.ObtenerProvisiones_PorCCosto(idEmpresa, idLocal, IdProvision, Item);

            if (Estado == "PR")
            {
                pnlBase.Enabled = false;
                pnlAuditoria.Enabled = false;
                pnlMontos.Enabled = false;
                btAceptar.Enabled = false;
            }

            if (Detalle.indCCostos == Variables.SI)
            {
                txtIdCostos.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btn_Costo.Enabled = true;
            }
        }

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public Provisiones_PorCCostoE Detalle = null;
        public ArticuloServE oArticulo = null;
        string idMoneda = string.Empty;
        DateTime FechaTica;
        Int32 colCoVen = 0;
        String numVerPlanCuentas = String.Empty;
        List<AlmacenE> ListarTipoAlmacen = null;
        Int32 idTipoArticulo = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             where (x.idMoneda == Variables.Soles) ||
                                                                   (x.idMoneda == Variables.Dolares)
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
            // Columna de Compra
            List<ParTabla> ListarCoVen = new List<ParTabla>(VariablesLocales.oListaBasesImponibles); //AgenteGeneral.Proxy.ListarParTablaPorGrupo(276000, "");
            //ParTabla iniCoVen = new ParTabla() { IdParTabla = 0, Nombre = "[Escoger Columna]" };
            //ListarCoVen.Add(iniCoVen);
            ComboHelper.RellenarCombos<ParTabla>(cboCoVen, (from x in ListarCoVen orderby x.IdParTabla select x).ToList(), "idParTabla", "Nombre", false);
            cboCoVen.SelectedValue = 0;
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
                //Decimal SubTotal = 0;

                #endregion

                #region Parseando para evitar errores de escritura

                Decimal.TryParse(txtCantidad.Text, out Cantidad);
                Decimal.TryParse(txtPrecio.Text, out Precio);

                SubTotal = Precio * Cantidad;
                //Decimal.TryParse(txtSubTotal.Text, out SubTotal);

                //Impuesto General a la Venta
                Decimal.TryParse(txtPorIgv.Text, out porIgv);
                Igv = SubTotal * (porIgv / 100);
                //Decimal.TryParse(txtIgv.Text, out Igv);

                //Total General
                txtSubTotal.Text = SubTotal.ToString("N2");
                txtIgv.Text = Igv.ToString("N2");
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

        void CheckAlmacen()
        {
            if (chkIndAlmacen.Checked == true)
            {
                cboAlmacen.Enabled = true;
                txtNotaIngreso.Enabled = true;
                btnValidar.Enabled = true;
                ListarTipoAlmacen = AgenteAlmacen.Proxy.ListarAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", 0, false, false);
                ComboHelper.RellenarCombos<AlmacenE>(cboAlmacen, (from x in ListarTipoAlmacen orderby x.desAlmacen select x).ToList(), "idAlmacen", "desAlmacen", false);
            }
            else
            {
                cboAlmacen.Enabled = false;
                cboAlmacen.SelectedValue = 0;
                txtNotaIngreso.Enabled = false;
                txtNotaIngreso.Clear();
                btnValidar.Enabled = false;
            }
        }

        bool ValidarGrabacion(List<String> Lista)
        {
            List<MovimientoAlmacenE> Items = new List<MovimientoAlmacenE>(); ;

            String NumHallado = "N";
            String Numero = String.Empty;
            Int32 idalmacen = Convert.ToInt32(cboAlmacen.SelectedValue);

            foreach (String item in Lista)
            {
                Items = AgenteAlmacen.Proxy.ObtenerMovAlmacenporID(Detalle.idEmpresa, 305001, Convert.ToInt32(item), idalmacen);

                NumHallado = "N";

                foreach (MovimientoAlmacenE itemCosto in Items)
                {
                    Numero = item;

                    if (item == itemCosto.idDocumentoAlmacen.ToString())
                    {
                        NumHallado = "S";
                    }
                }

                if (NumHallado == "N")
                {
                    Global.MensajeComunicacion("El Item " + Numero + " no se encuentra como registro");
                    return false;
                }

                if (NumHallado == "S")
                {
                    Global.MensajeComunicacion("¡Items Encontrados!");
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (Detalle == null)
            {
                Detalle = new Provisiones_PorCCostoE()
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
                Detalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtPrecio.TextChanged -= txtPrecio_TextChanged;
                txtCantidad.TextChanged -= txtCantidad_TextChanged;
                txtPorIgv.TextChanged -= txtPorIgv_TextChanged;
                chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                //chkTica.CheckedChanged -= chkTica_CheckedChanged;
                txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;
                txtTotal.TextChanged -= txtTotal_TextChanged;          
                txtCodArticulo.Text = Detalle.Codigo;
                txtIdArticulo.Text = Detalle.idArticulo.ToString();
                txtDesArticulo.Text = Detalle.Descripcion;
                cboMoneda.SelectedValue = Detalle.idMoneda.ToString();
                txtTica.Text = Detalle.tipCambio.ToString("N3");
                //chkTica.Checked = oProvisionCompra.indCambio;
                chkIgv.Checked = Detalle.indIgv;
                txtCantidad.Text = Detalle.Cantidad.ToString("N2");
                txtPrecio.Text = Detalle.PrecioUnitario.ToString("N5");
                txtPorIgv.Text = Detalle.porIgv.ToString("N2");
                txtIgv.Text = Detalle.Igv.ToString("N2");
                txtSubTotal.Text = Detalle.subTotal.ToString("N2");
                numVerPlanCuentas = Detalle.numVerPlanCuentas;
                txtCodCuenta.Text = Detalle.codCuenta;
                txtDesCuenta.Text = Detalle.DesCuenta;
                chkIndAlmacen.Checked = Detalle.indCostoArticulo;
                //txtNotaIngreso.Text = Detalle.notasdeIngreso;
                txtNotaIngreso.Text = Detalle.notasdeIngreso;
                cboAlmacen.SelectedValue = Detalle.idAlmacen;

                if (Detalle.idMoneda == Variables.Soles)
                {
                    txtTotal.Text = Detalle.impSoles.ToString("N2");
                }
                else
                {
                    txtTotal.Text = Detalle.impDolares.ToString("N2");
                }

                txtIdCostos.Text = Detalle.idCCostos;
                txtDesCostos.Text = Detalle.DesCCosto;
                cboCoVen.SelectedValue = Convert.ToInt32(Detalle.codColumnaCoven);
                chkCalculos.Checked = Detalle.Calculo == "A" ? true : false;
                chkPorRecibir.Checked = Detalle.PorRecibir;
                chkHojaCosto.Checked = Detalle.FlagHC;

                txtUsuarioRegistro.Text = Detalle.UsuarioRegistro;
                txtFechaRegistro.Text = Detalle.FechaRegistro.ToString();
                txtUsuarioMod.Text = Detalle.UsuarioModificacion;
                txtFechaModifica.Text = Detalle.FechaModificacion.ToString();

                if (Detalle.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    Detalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                txtPrecio.TextChanged += txtPrecio_TextChanged;
                txtCantidad.TextChanged += txtCantidad_TextChanged;
                txtPorIgv.TextChanged += txtPorIgv_TextChanged;
                chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                //chkTica.CheckedChanged += chkTica_CheckedChanged;
                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
                txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                txtTotal.TextChanged += txtTotal_TextChanged;
            }

            bsBase.DataSource = Detalle;
            bsBase.ResetBindings(false);
            base.Nuevo();
        }

        public override void Aceptar()
        {
            if (Detalle != null)
            {
                if (String.IsNullOrWhiteSpace(txtIdArticulo.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar un articulo.");
                    return;
                }
                
                Detalle.Codigo = txtCodArticulo.Text;
                Detalle.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
                Detalle.Descripcion = txtDesArticulo.Text.Trim();
                Detalle.numVerPlanCuentas = numVerPlanCuentas;
                Detalle.codCuenta = txtCodCuenta.Text;
                Detalle.idMoneda = cboMoneda.SelectedValue.ToString();
                Detalle.desMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                Detalle.tipCambio = Convert.ToDecimal(txtTica.Text);
                Detalle.indCambio = true;
                Detalle.indIgv = chkIgv.Checked;
                Detalle.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                Detalle.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                Detalle.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                Detalle.Igv = Convert.ToDecimal(txtIgv.Text);
                Detalle.subTotal = Convert.ToDecimal(txtSubTotal.Text);

                Detalle.indCostoArticulo = chkIndAlmacen.Checked;
                Detalle.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);

                Decimal.TryParse(txtTotal.Text, out Decimal Importe);
                Decimal.TryParse(txtTica.Text, out Decimal tica);

                if (Detalle.idMoneda == Variables.Soles)
                {
                    Detalle.impSoles = Detalle.MontoCuenta = Importe;
                    Detalle.impDolares = Importe / tica;
                }
                else
                {
                    Detalle.impDolares = Detalle.MontoCuenta = Importe;
                    Detalle.impSoles = Importe * tica;
                }

                Detalle.idCCostos = txtIdCostos.Text.Trim();
                Detalle.DesCCosto = txtDesCostos.Text.Trim();

                if (String.IsNullOrEmpty(Detalle.desGlosa))
                {
                    Detalle.desGlosa = String.Empty;
                }

                Detalle.codColumnaCoven = Convert.ToInt32(cboCoVen.SelectedValue);
                Detalle.DesColumnaCoven = ((ParTabla)cboCoVen.SelectedItem).Nombre;
                Detalle.Tipo = "A";
                Detalle.Calculo = chkCalculos.Checked ? "A" : "M";

                Detalle.PorRecibir = chkPorRecibir.Checked;
                Detalle.notasdeIngreso = txtNotaIngreso.Text;
                Detalle.FlagHC = chkHojaCosto.Checked;

                String Linea = txtNotaIngreso.Text;

                if (Linea != "")
                {
                    List<String> oLista = new List<String>(Linea.Split(','));

                    if (!ValidarGrabacion(oLista))
                    {
                        return;
                    }
                }

                if (Convert.ToInt32(Detalle.codColumnaCoven) == 0)
                {
                    Global.MensajeComunicacion("Debe escoger un Tipo de Columna.");
                    cboCoVen.Focus();
                    return;
                }

                if (Detalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    Detalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    Detalle.FechaRegistro = VariablesLocales.FechaHoy;
                    Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    Detalle.FechaModificacion = VariablesLocales.FechaHoy;
                }
                else
                {
                    Detalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    Detalle.FechaModificacion = VariablesLocales.FechaHoy;
                }

                base.Aceptar();
            }
        }

        public override bool ValidarGrabacion()
        {
            String resp = ValidarEntidad<Provisiones_PorCCostoE>(Detalle);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmProvisionCosto_Load(object sender, EventArgs e)
        {
            try
            {
                CheckAlmacen();
                Nuevo();
                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btn_Costo_Click(object sender, EventArgs e)
        {
            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(1);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtIdCostos.Text = oFrm.CentroCosto.idCCostos;
                txtDesCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void cboCoVen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAIMP") //Base Imponible
                {
                    chkIgv.Enabled = chkIgv.Checked = true;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAINA") //Base Inafecta
                {
                    chkIgv.Checked = chkIgv.Enabled = false;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAGNO") //Base Gravada y No Gravada
                {
                    chkIgv.Enabled = chkIgv.Checked = true;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BASDE") //Base sin Derecho
                {
                    chkIgv.Checked = chkIgv.Enabled = true;
                }
                else if (((ParTabla)cboCoVen.SelectedItem).NemoTecnico == "BAEXP") //Base Exportación
                {
                    chkIgv.Checked = chkIgv.Enabled = false;
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

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIgv.Checked)
                {
                    decimal Porcentaje = VariablesLocales.oListaImpuestos[0].Porcentaje;//AgenteGeneral.Proxy.ObtenerImpuestosPeriodo(1, 1);
                    txtPorIgv.Text = Porcentaje.ToString();
                }
                else
                {
                    txtPorIgv.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtIdCostos_TextChanged(object sender, EventArgs e)
        {
            txtDesCostos.Text = string.Empty;
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = String.Empty;
            txtDesArticulo.Text = String.Empty;
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo oFrm = new frmBuscarArticulo(0, "E");

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged -= txtDesArticulo_TextChanged;

                oArticulo = Colecciones.CopiarEntidad<ArticuloServE>(oFrm.Articulo);

                txtIdArticulo.Text = oArticulo.idArticulo.ToString();
                txtDesArticulo.Text = oArticulo.nomArticulo;
                txtCodArticulo.Text = oArticulo.codArticulo;
                numVerPlanCuentas = oArticulo.numVerPlanCuentas;
                idTipoArticulo = oArticulo.idTipoArticulo;               

                txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
                txtDesArticulo.TextChanged += txtDesArticulo_TextChanged;
            }
            else
            {
                txtIdArticulo.Text = string.Empty;
                txtDesArticulo.Text = string.Empty;
                txtCodArticulo.Text = string.Empty;
                numVerPlanCuentas = string.Empty;
            }
        }

        private void txtDesArticulo_TextChanged(object sender, EventArgs e)
        {
            txtIdArticulo.Text = string.Empty;
            txtCodArticulo.Text = string.Empty;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularReves();
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

        private void chkIndAlmacen_CheckedChanged(object sender, EventArgs e)
        {
            CheckAlmacen();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            String Linea = txtNotaIngreso.Text;

            if (Linea != "")
            {
                List<String> oLista = new List<String>(Linea.Split(','));

                if (!ValidarGrabacion(oLista))
                {
                    return;
                }
            }
        }

        #endregion

    }
}
