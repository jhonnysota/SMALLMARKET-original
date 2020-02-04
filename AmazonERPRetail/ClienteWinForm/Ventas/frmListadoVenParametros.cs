using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Text;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoVenParametros : FrmMantenimientoBase
    {

        public frmListadoVenParametros()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombo();
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        venParametrosE oParamVentas = null;
        Int32 opcion;
        InstalledFontCollection Fuentes = new InstalledFontCollection();
        InstalledFontCollection FuentesLetras = new InstalledFontCollection();

        #endregion

        #region Procedimientos de Usuario

        private void GuardarDatos()
        {
            oParamVentas.GeneraAsiento = chkAsientoGen.Checked;
            oParamVentas.indFacElec = chkFactEle.Checked;

            if (chkFactEle.Checked)
            {
                if (dtpFecFact.Checked)
                {
                    oParamVentas.FechaFacElec = dtpFecFact.Value;
                }
            }
            else
            {
                oParamVentas.FechaFacElec = null;
            }

            oParamVentas.MontoBoleta = Convert.ToDecimal(txtMonto.Text);
            oParamVentas.Comprometido = chkStock.Checked;
            oParamVentas.digArticulo = Convert.ToInt32(txtDigArt.Text);
            oParamVentas.Glosa = string.Empty;
            oParamVentas.ClienteVarios = String.IsNullOrEmpty(txtIdVarios.Text.Trim()) ? (int?)null : Convert.ToInt32(txtIdVarios.Text.Trim());
            oParamVentas.EnvioFactEle = chkEnviarFe.Checked;
            oParamVentas.indListaPrecio = chkListaPrecio.Checked;
            oParamVentas.monPedido = cboMonedas.SelectedValue.ToString();
            oParamVentas.CorreoCobranza = txtCorreo.Text.Trim();
            oParamVentas.indIgv = chkIgv.Checked;
            oParamVentas.LetraImpresion = txtLetraPrint.Text.Trim();
            oParamVentas.SizeLetra = Convert.ToInt32(txtTamañoLetra.Text);
            oParamVentas.indZona = chkIndZona.Checked;
            oParamVentas.indAfectacionIgv = chkindAfectacionIgv.Checked;
            oParamVentas.TipoFacturacion = cboTipoFacturacion.SelectedValue.ToString();
            oParamVentas.FontPrintLetra = txtFuenteLetra.Text.Trim();
            oParamVentas.SizeFontLetra = Convert.ToInt32(txtSizeFontLetra.Text);
            oParamVentas.indNomArtCompuesto = chkNombreCompuesto.Checked;
            oParamVentas.FontPrintBarras = txtFontBarras.Text.Trim();
            oParamVentas.digBarras = Convert.ToInt32(txtDigitosBarras.Text);

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                if (!String.IsNullOrWhiteSpace(txtNombreArticuloBarras.Text.Trim()))
                {
                    oParamVentas.nomArticuloCal = txtNombreArticuloBarras.Text.Trim();
                }
                else
                {
                    oParamVentas.nomArticuloCal = String.Empty;
                }
            }
            else
            {
                oParamVentas.nomArticuloCal = String.Empty;
            }

            oParamVentas.indVendedor = chkVendedor.Checked;
            oParamVentas.razonExoIgv = Convert.ToInt32(cboExoneracion.SelectedValue);
            oParamVentas.indBanco = chkBanco.Checked;
            oParamVentas.idUbl = Convert.ToInt32(cboidUbl.SelectedValue);
        }

        private void LlenarCombo()
        {
            //Datos para saber si se trata de Nota de Credito de Exportacion o Nacional
            cboTipoFacturacion.DataSource = Global.CargarTipoFacturacion();
            cboTipoFacturacion.ValueMember = "id";
            cboTipoFacturacion.DisplayMember = "Nombre";

            cboidUbl.DataSource = Global.CargarUbl();
            cboidUbl.ValueMember = "id";
            cboidUbl.DisplayMember = "Nombre";

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            MonedasE CampoInicial = new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Escoger };
            ListaMoneda.Add(CampoInicial);

            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) ||
                                                                    (x.idMoneda == Variables.Dolares) ||
                                                                    (x.idMoneda == Variables.Cero.ToString())
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda", false);

            cboFuentes.DataSource = Fuentes.Families;
            cboFuentes.DisplayMember = "Name";
            cboFuentes.ValueMember = "Name";

            cboFuentesLetra.DataSource = FuentesLetras.Families;
            cboFuentesLetra.DisplayMember = "Name";
            cboFuentesLetra.ValueMember = "Name";

            cboFuentesBarras.DataSource = FuentesLetras.Families;
            cboFuentesBarras.DisplayMember = "Name";
            cboFuentesBarras.ValueMember = "Name";

            //Razón de exoneración del IGV
            List<AfectacionIgvE> oListaExoneracion = AgenteMaestro.Proxy.ListarAfectacionIgv(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListaExoneracion.Add(new AfectacionIgvE() { idAfectacion = Variables.Cero, DesAfectacion = Variables.Seleccione });
            ComboHelper.LlenarCombos<AfectacionIgvE>(cboExoneracion, (from x in oListaExoneracion orderby x.idAfectacion select x).ToList(), "idAfectacion", "DesAfectacion");
        }

        private void NombreArticuloBarras()
        {
            String Nombre = txtNombreArticuloBarras.Text.Trim();

            if (chkMarca.Checked)
            {
                if (!String.IsNullOrWhiteSpace(Nombre))
                {
                    if (Nombre.IndexOf("Marca+") == -1)
                    {
                        Nombre = Nombre.Replace("Marca+", "");
                        Nombre += "Marca+"; 
                    }
                }
                else
                {
                    Nombre = "Marca+";
                }
            }
            else
            {
                Nombre = Nombre.Replace("Marca+", "");
            }

            if (chkModelo.Checked)
            {
                if (!String.IsNullOrWhiteSpace(Nombre))
                {
                    if (Nombre.IndexOf("Modelo+") == -1)
                    {
                        Nombre = Nombre.Replace("Modelo+", "");
                        Nombre += "Modelo+"; 
                    }
                }
                else
                {
                    Nombre = "Modelo+";
                }
            }
            else
            {
                Nombre = Nombre.Replace("Modelo+", "");
            }

            if (chkMaterial.Checked)
            {
                if (!String.IsNullOrWhiteSpace(Nombre))
                {
                    if (Nombre.IndexOf("Material+") == -1)
                    {
                        Nombre = Nombre.Replace("Material+", "");
                        Nombre += "Material+"; 
                    }
                }
                else
                {
                    Nombre = "Material+";
                }
            }
            else
            {
                Nombre = Nombre.Replace("Material+", "");
            }

            if (chkColor.Checked)
            {
                if (!String.IsNullOrWhiteSpace(Nombre))
                {
                    if (Nombre.IndexOf("Color+") == -1)
                    {
                        Nombre = Nombre.Replace("Color+", "");
                        Nombre += "Color+"; 
                    }
                }
                else
                {
                    Nombre = "Color+";
                }
            }
            else
            {
                Nombre = Nombre.Replace("Color+", "");
            }

            if (chkTaco.Checked)
            {
                if (!String.IsNullOrWhiteSpace(Nombre))
                {
                    if (Nombre.IndexOf("Taco+") == -1)
                    {
                        Nombre = Nombre.Replace("Taco+", "");
                        Nombre += "Taco+";
                    }
                }
                else
                {
                    Nombre = "Taco+";
                }
            }
            else
            {
                Nombre = Nombre.Replace("Taco+", "");
            }

            txtNombreArticuloBarras.Text = Nombre.Trim();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oParamVentas == null)
                {
                    oParamVentas = new venParametrosE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                    };

                    opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    chkAsientoGen.Checked = oParamVentas.GeneraAsiento;
                    chkFactEle.Checked = oParamVentas.indFacElec;

                    if (chkFactEle.Checked)
                    {
                        dtpFecFact.Enabled = true;
                        dtpFecFact.Value = oParamVentas.FechaFacElec.Value;
                    }
                    else
                    {
                        dtpFecFact.Enabled = false;
                        dtpFecFact.Checked = false;
                    }

                    txtMonto.Text = oParamVentas.MontoBoleta.ToString("N2");
                    chkStock.Checked = oParamVentas.Comprometido;
                    txtDigArt.Text = Convert.ToString(oParamVentas.digArticulo);
                    //txtGlosa.Text = oParamVentas.Glosa;
                    txtIdVarios.Text = oParamVentas.ClienteVarios != 0 ? oParamVentas.ClienteVarios.ToString() : String.Empty;
                    txtRuc.Text = oParamVentas.RUC;
                    txtRazonSocial.Text = oParamVentas.RazonSocial;
                    chkEnviarFe.Checked = oParamVentas.EnvioFactEle;
                    chkListaPrecio.Checked = oParamVentas.indListaPrecio;
                    cboMonedas.SelectedValue = oParamVentas.monPedido != null ? oParamVentas.monPedido : Variables.Cero.ToString();
                    txtCorreo.Text = oParamVentas.CorreoCobranza;
                    chkIgv.Checked = oParamVentas.indIgv;
                    txtLetraPrint.Text = oParamVentas.LetraImpresion;
                    cboFuentes.SelectedValue = String.IsNullOrWhiteSpace(oParamVentas.LetraImpresion) ? "Lucida Console" : oParamVentas.LetraImpresion;
                    txtTamañoLetra.Text = oParamVentas.SizeLetra.ToString();
                    chkIndZona.Checked = oParamVentas.indZona;
                    chkindAfectacionIgv.Checked = oParamVentas.indAfectacionIgv;
                    cboTipoFacturacion.SelectedValue = oParamVentas.TipoFacturacion;
                    txtFuenteLetra.Text = oParamVentas.FontPrintLetra.Trim();
                    txtSizeFontLetra.Text = oParamVentas.SizeFontLetra.ToString();
                    chkNombreCompuesto.Checked = oParamVentas.indNomArtCompuesto;
                    txtFontBarras.Text = oParamVentas.FontPrintBarras;
                    txtDigitosBarras.Text = oParamVentas.digBarras.ToString();
                    txtNombreArticuloBarras.Text = oParamVentas.nomArticuloCal;
                    chkVendedor.Checked = oParamVentas.indVendedor;
                    cboExoneracion.SelectedValue = Convert.ToInt32(oParamVentas.razonExoIgv);
                    chkBanco.Checked = oParamVentas.indBanco;
                    cboidUbl.SelectedValue = oParamVentas.idUbl;
                    CboCorrelativo.SelectedValue = Convert.ToInt32(oParamVentas.TipoPed);
                    TxtSerie.Text = oParamVentas.SeriePed;
                    TxtCorrelativo.Text = oParamVentas.CorrelativoPed.ToString();
                    TxtFormato.Text = oParamVentas.FormatoPed;

                    opcion = (Int32)EnumOpcionGrabar.Actualizar;

                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oParamVentas != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            VariablesLocales.oVenParametros = oParamVentas = AgenteVentas.Proxy.InsertarVenParametros(oParamVentas);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            VariablesLocales.oVenParametros = oParamVentas = AgenteVentas.Proxy.ActualizarVenParametros(oParamVentas);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    
                    base.Grabar();
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<venParametrosE>(oParamVentas);
            String Nemo = ((ParTabla)CboCorrelativo.SelectedItem).NemoTecnico;

            if (!String.IsNullOrWhiteSpace(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (!String.IsNullOrWhiteSpace(TxtSerie.Text) && !TxtFormato.Text.Contains("SER"))
            {
                Global.MensajeComunicacion("El formato tiene que tener las siglas SER en el formato.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(TxtSerie.Text) && TxtFormato.Text.Contains("SER"))
            {
                Global.MensajeComunicacion("El formato no tiene que tener las siglas SER en el formato.");
                return false;
            }

            if (Nemo == "CORRSI" && (TxtFormato.Text.Contains("Y") || TxtFormato.Text.Contains("M")))
            {
                Global.MensajeComunicacion("El formato no tiene que tener Año y Mes.");
                return false;
            }

            if (Nemo == "CORRAM")
            {
                if (!TxtFormato.Text.Contains("Y"))
                {
                    Global.MensajeComunicacion("El formato tiene que tener Año.");
                    return false;
                }
                else
                {
                    string AnioRev = TxtFormato.Text.Replace("SER", "").Replace("M", "").Replace("0", "").Replace("-", "");

                    if (AnioRev.Length != 2 && AnioRev.Length != 4)
                    {
                        Global.MensajeComunicacion("El formato del Año no es el correcto.");
                        return false;
                    }
                }
            }

            if (Nemo == "CORRAN")
            {
                if (!TxtFormato.Text.Contains("Y"))
                {
                    Global.MensajeComunicacion("El formato tiene que tener Año.");
                    return false;
                }
                else
                {
                    string AnioRev = TxtFormato.Text.Replace("SER", "").Replace("M", "").Replace("0", "").Replace("-", "");

                    if (AnioRev.Length != 2 && AnioRev.Length != 4)
                    {
                        Global.MensajeComunicacion("El formato del Año no es el correcto.");
                        return false;
                    }
                }

                if (TxtFormato.Text.Contains("MM"))
                {
                    Global.MensajeComunicacion("El formato no tiene que tener Mes.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmListadoVenParametros_Load(object sender, EventArgs e)
        {
            Grid = false;
            oParamVentas = Colecciones.CopiarEntidad<venParametrosE>(VariablesLocales.oVenParametros);
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
        }

        private void chkFactEle_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecFact.Enabled = chkFactEle.Checked;
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && string.IsNullOrEmpty(txtIdVarios.Text.Trim()) && string.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdVarios.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdVarios.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtIdVarios.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }

                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdVarios.Text = String.Empty;
            txtRuc.Text = string.Empty;
        }

        private void lblFuentes_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //FontFamily family = Fuentes.Families[e.Index];
                //FontStyle style = FontStyle.Regular;

                //if (!family.IsStyleAvailable(style))
                //{
                //    style = FontStyle.Bold;
                //}

                //if (!family.IsStyleAvailable(style))
                //{
                //    style = FontStyle.Italic;
                //}

                //Font fnt = new Font(family, 10, style);
                //Brush brush;

                //if (e.State == DrawItemState.Selected)
                //{
                //    brush = new SolidBrush(Color.White);
                //}
                //else
                //{
                //    brush = new SolidBrush(lblFuentes.ForeColor);
                //}

                //e.DrawBackground();
                ////e.Graphics.DrawString(family.GetName(0), fnt, brush, e.Bounds.Location);
                //e.Graphics.DrawString(family.GetName(0), fnt, brush, e.Bounds.Left + 2, e.Bounds.Top + 2);

                ////e.DrawBackground();
                ////String Texto = lblFuentes.Items[e.Index].ToString();
                ////Font Fuente = new Font(Texto, e.Font.Size);

                ////e.Graphics.DrawString(Texto, Fuente, new SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2);
                //e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboFuentes_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                FontFamily family = Fuentes.Families[e.Index];
                FontStyle style = FontStyle.Regular;

                if (!family.IsStyleAvailable(style))
                {
                    style = FontStyle.Bold;
                }

                if (!family.IsStyleAvailable(style))
                {
                    style = FontStyle.Italic;
                }

                Font fnt = new Font(family, 10, style);

                e.DrawBackground();
                e.Graphics.DrawString(family.GetName(0), fnt, new SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2);

                e.DrawFocusRectangle();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cboFuentes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtLetraPrint.Text = cboFuentes.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboFuentesLetra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtFuenteLetra.Text = cboFuentesLetra.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboFuentesLetra_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                FontFamily family = FuentesLetras.Families[e.Index];
                FontStyle style = FontStyle.Regular;

                if (!family.IsStyleAvailable(style))
                {
                    style = FontStyle.Bold;
                }

                if (!family.IsStyleAvailable(style))
                {
                    style = FontStyle.Italic;
                }

                Font fnt = new Font(family, 9, style);

                e.DrawBackground();
                e.Graphics.DrawString(family.GetName(0), fnt, new SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2);

                e.DrawFocusRectangle();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkMarca_CheckedChanged(object sender, EventArgs e)
        {
            NombreArticuloBarras();
        }

        private void chkModelo_CheckedChanged(object sender, EventArgs e)
        {
            NombreArticuloBarras();
        }

        private void chkMaterial_CheckedChanged(object sender, EventArgs e)
        {
            NombreArticuloBarras();
        }

        private void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            NombreArticuloBarras();
        }

        private void cboFuentesBarras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtFontBarras.Text = cboFuentesBarras.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboFuentesBarras_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                FontFamily family = FuentesLetras.Families[e.Index];
                FontStyle style = FontStyle.Regular;

                if (!family.IsStyleAvailable(style))
                {
                    style = FontStyle.Bold;
                }

                if (!family.IsStyleAvailable(style))
                {
                    style = FontStyle.Italic;
                }

                Font fnt = new Font(family, 9, style);

                e.DrawBackground();
                e.Graphics.DrawString(family.GetName(0), fnt, new SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2);

                e.DrawFocusRectangle();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkTaco_CheckedChanged(object sender, EventArgs e)
        {
            NombreArticuloBarras();
        }

        #endregion

    }
}
