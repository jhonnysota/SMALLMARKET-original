using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Almacen;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmMovBancosDet : frmResponseBase
    {

        #region Constructores

        public frmMovBancosDet()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        //Nuevo
        public frmMovBancosDet(BancosE oBanco_, String idMoneda, String Glosita, DateTime Fecha, Decimal Tica_, Decimal Soles_, Decimal Dolares_, String Tipo)
            :this()
        {
            oBanco = oBanco_;
            cboMoneda.SelectedValue = idMoneda;
            txtGlosa.Text = Glosita;
            FechaCab = Fecha;
            Tica = Tica_;
            Soles = Soles_;
            Dolares = Dolares_;

            lblTituloPrincipal.Text = "Detalle de Movimiento de Banco(" + Tipo + ")";

            if (Tipo.ToUpper().Contains("VINC") || Tipo.ToUpper().Contains("CTAS."))
            {
                if (Tipo.ToUpper().Contains("CTAS."))
                {
                    TipoMov = "C"; //Entre cuentas
                    cboEmpresas.Enabled = false;
                }

                if (Tipo.ToUpper().Contains("VINC")) //Entre vinculadas...
                {
                    TipoMov = "V";
                    cboEmpresas.Enabled = true;
                }
            }
        }

        //Edición
        public frmMovBancosDet(MovimientoBancosDetE oDetalle, String idMoneda, String Tipo, String Estado)
            :this()
        {
            oMovDetalle = oDetalle;
            lblTituloPrincipal.Text = "Detalle de Movimiento de Banco(" + Tipo + ")";
            EstadoDet = Estado;

            if (Tipo.ToUpper().Contains("VINC") || Tipo.ToUpper().Contains("CTAS."))
            {
                if (Tipo.ToUpper().Contains("CTAS."))
                {
                    TipoMov = "C"; //Entre cuentas
                    cboEmpresas.Enabled = false;
                }

                if (Tipo.ToUpper().Contains("VINC")) //Entre vinculadas...
                {
                    TipoMov = "V";
                    cboEmpresas.Enabled = true;
                }
            }
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        BancosE oBanco = null;
        public MovimientoBancosDetE oMovDetalle = null;
        DateTime FechaCab;
        Decimal Tica = 0;
        Decimal Soles = 0;
        Decimal Dolares = 0;
        String EstadoDet = "CR";
        String TipoMov = "N";
        String BuscarCombo = "S";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosTesoreria(0, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "");
            ComboHelper.LlenarCombos<ConceptosVariosE>(cboConceptos, (from x in oListaConceptos orderby x.idConcepto select x).ToList(), "idConcepto", "Descripcion");

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      && x.indTesoreria == true
                                                                      select x).ToList();

            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desAbreviatura", false);
            // Si es Reparable
            cboReparable.DataSource = Global.CargarTipoReparable();
            cboReparable.ValueMember = "id";
            cboReparable.DisplayMember = "Nombre";

            // Conceptos reparables
            cboConceptoReparable.DataSource = Global.CargarConceptosReparable();
            cboConceptoReparable.ValueMember = "id";
            cboConceptoReparable.DisplayMember = "Nombre";

            oListaConceptos = null;
            ListaDocumentos = null;
            ListaMoneda = null;
        }

        void Datos()
        {
            oMovDetalle.idConcepto = Convert.ToInt32(cboConceptos.SelectedValue);

            if (((ConceptosVariosE)cboConceptos.SelectedItem).indAuxiliar == "S")
            {
                oMovDetalle.idPersona = Convert.ToInt32(txtIdBanco.Text);
                oMovDetalle.RUC = txtRuc.Text;
                oMovDetalle.desBanco = txtRazonSocial.Text; 
            }
            else
            {
                oMovDetalle.idPersona = null;
                oMovDetalle.RUC = String.Empty;
                oMovDetalle.desBanco = String.Empty;
            }

            if (((ConceptosVariosE)cboConceptos.SelectedItem).indCentroCosto == "S")
            {
                oMovDetalle.idCCostos = txtCCostos.Text;
                oMovDetalle.desCCostos = txtDesCCostos.Text; 
            }
            else
            {
                oMovDetalle.idCCostos = String.Empty;
                oMovDetalle.desCCostos = String.Empty;
            }

            oMovDetalle.idDocumento = cboDocumento.SelectedValue.ToString();
            oMovDetalle.serDocumento = txtSerie.Text;
            oMovDetalle.numDocumento = txtNumDoc.Text;
            oMovDetalle.fecDocumento = dtpFecDocumento.Value.Date;

            if (dtpFecVencimiento.Checked)
            {
                oMovDetalle.fecVencimiento = dtpFecVencimiento.Value.Date;
            }
            else
            {
                oMovDetalle.fecVencimiento = (DateTime?)null;
            }

            oMovDetalle.tipPartidaPresu = txtTipPartida.Text;
            oMovDetalle.codPartidaPresu = txtPartida.Text;
            oMovDetalle.desPartidaPresu = txtDesPartida.Text;
            oMovDetalle.idMoneda = cboMoneda.SelectedValue.ToString();
            oMovDetalle.Importe = Convert.ToDecimal(txtSoles.Text);
            oMovDetalle.ImporteDolar = Convert.ToDecimal(txtDolares.Text);
            oMovDetalle.TicaAuto = chkTicaAuto.Checked;
            oMovDetalle.tipCambio = Convert.ToDecimal(txtTica.Text);
            oMovDetalle.Glosa = txtGlosa.Text.Trim();
            oMovDetalle.indReparable = cboReparable.SelectedValue.ToString();
            oMovDetalle.idConceptoRep = Convert.ToInt32(cboConceptoReparable.SelectedValue);
            oMovDetalle.desReferenciaRep = txtRefRepa.Text.Trim();
            oMovDetalle.indExceso = chkExceso.Checked;

            if (TipoMov == "V" || TipoMov == "C")
            {
                if (((ConceptosVariosE)cboConceptos.SelectedItem).indTransferencia)
                {
                    oMovDetalle.idEmpresaTrans = Convert.ToInt32(cboEmpresas.SelectedValue);
                    oMovDetalle.idBancoTrans = Convert.ToInt32(cboBancosEmpresa.SelectedValue);
                    oMovDetalle.idMonedaTrans = cboMonedaEmpresa.SelectedValue.ToString();
                    oMovDetalle.ctaBancariaTrans = cboCuentasBancarias.SelectedValue.ToString();
                    oMovDetalle.numVerPlanCuentasTrans = ((BancosCuentasE)cboCuentasBancarias.SelectedItem).numVerPlanCuentas;
                    oMovDetalle.codCuentaTrans = ((BancosCuentasE)cboCuentasBancarias.SelectedItem).codCuenta; 
                }
                else
                {
                    oMovDetalle.idEmpresaTrans = null;
                    oMovDetalle.idBancoTrans = null;
                    oMovDetalle.idMonedaTrans = String.Empty;
                    oMovDetalle.ctaBancariaTrans = String.Empty;
                    oMovDetalle.numVerPlanCuentasTrans = String.Empty;
                    oMovDetalle.codCuentaTrans = String.Empty;
                }
            }
            else
            {
                oMovDetalle.idEmpresaTrans = null;
                oMovDetalle.idBancoTrans = null;
                oMovDetalle.idMonedaTrans = String.Empty;
                oMovDetalle.ctaBancariaTrans = String.Empty;
                oMovDetalle.numVerPlanCuentasTrans = String.Empty;
                oMovDetalle.codCuentaTrans = String.Empty;
            }

            if (oMovDetalle.idMovBanco == 0)
            {
                oMovDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oMovDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                oMovDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oMovDetalle.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oMovDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oMovDetalle.FechaModificacion = VariablesLocales.FechaHoy;
            }
        }

        void BloquearCajas()
        {
            if (chkTicaAuto.Checked)
            {
                if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                {
                    txtSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }
                else
                {
                    txtSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
            }
            else
            {
                txtSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        void Montos()
        {
            txtDolares.TextChanged -= txtDolares_TextChanged;
            txtSoles.TextChanged -= txtSoles_TextChanged;

            try
            {
                Decimal Soles = Variables.ValorCeroDecimal;
                Decimal Dolares = Variables.ValorCeroDecimal;
                Decimal Tica = Variables.ValorCeroDecimal;

                Decimal.TryParse(txtSoles.Text, out Soles);
                Decimal.TryParse(txtDolares.Text, out Dolares);
                Decimal.TryParse(txtTica.Text, out Tica);

                if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                {
                    if (Soles > 0 && Tica > 0)
                    {
                        txtDolares.Text = Decimal.Round((Soles / Tica), 2).ToString("N2");
                    }
                }
                else
                {
                    if (Dolares > 0 && Tica > 0)
                    {
                        txtSoles.Text = Decimal.Round((Dolares * Tica), 2).ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

            txtDolares.TextChanged += txtDolares_TextChanged;
            txtSoles.TextChanged += txtSoles_TextChanged;
        }

        void ObtenerCuentasBancarias(Int32 idBanco, Int32 idEmpresa, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentaBancarias = AgenteMaestro.Proxy.BancosCuentasPorMoneda(idBanco, idEmpresa, idMoneda);
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentasBancarias, oListaCuentaBancarias, "numCuenta", "desCuentaBanco", false);

            if (oListaCuentaBancarias.Count > 1)
            {
                cboCuentasBancarias.Enabled = true;
            }
            else
            {
                cboCuentasBancarias.Enabled = false;
            }
        }

        void LlenarCombosTransferencia()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedaEmpresa, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desAbreviatura", false);
            // Empresas
            List<Empresa> oListaEmpresa = new List<Empresa>(VariablesLocales.SesionUsuario.UsuarioEmpresas);

            if (TipoMov == "V") //Si es transferencia entre vinculada quita la empresa actual...
            {
                oListaEmpresa = (from x in oListaEmpresa where x.IdEmpresa != VariablesLocales.SesionUsuario.Empresa.IdEmpresa select x).ToList();
            }

            ComboHelper.LlenarCombos<Empresa>(cboEmpresas, (from x in oListaEmpresa orderby x.IdEmpresa select x).ToList(), "IdEmpresa", "NombreComercial");

            if (TipoMov == "C")
            {
                cboEmpresas.SelectedValue = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            }

            oListaEmpresa = null;
            ListaMoneda = null;
        }

        void CalcularTiCa()
        {
            try
            {
                Decimal Soles = 0;
                Decimal Dolares = 0;
                Decimal Tica = 0;

                Decimal.TryParse(txtSoles.Text, out Soles);
                Decimal.TryParse(txtDolares.Text, out Dolares);

                if (chkTicaAuto.Checked)
                {
                    Decimal.TryParse(txtTica.Text, out Tica);

                    if (Tica > 0)
                    {
                        if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                        {
                            Dolares = Soles / Tica;
                            txtDolares.Text = Dolares.ToString("N2");
                        }
                        else
                        {
                            Soles = Dolares * Tica;
                            txtSoles.Text = Soles.ToString("N2");
                        }
                    }
                }
                else
                {
                    if (Soles > 0 && Dolares > 0)
                    {
                        if (Soles > Dolares)
                        {
                            Tica = Soles / Dolares;
                        }
                        else
                        {
                            Tica = Dolares / Soles;
                        }

                        txtTica.Text = Tica.ToString("N3");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            txtPartida.TextChanged -= txtPartida_TextChanged;
            txtDolares.TextChanged -= txtDolares_TextChanged;
            txtSoles.TextChanged -= txtSoles_TextChanged;
            dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;

            try
            {
                if (oMovDetalle == null)
                {
                    oMovDetalle = new MovimientoBancosDetE
                    {
                        VieneApertura = false
                    };

                    txtIdBanco.Text = oBanco.idPersona.ToString();
                    txtRuc.Text = oBanco.RUC;
                    txtRazonSocial.Text = oBanco.RazonSocial;
                    dtpFecDocumento.Value = FechaCab.Date;
                    txtTica.Text = Tica.ToString("N3");
                    txtSoles.Text = Soles.ToString("N2");
                    txtDolares.Text = Dolares.ToString("N2");

                    txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                    cboConceptos_SelectionChangeCommitted(new object(), new EventArgs());
                    cboMoneda_SelectionChangeCommitted(new object(), new EventArgs());

                    if (((ConceptosVariosE)cboConceptos.SelectedItem).indTransferencia)
                    {
                        pnlTransferencia.Enabled = true;
                        LlenarCombosTransferencia();

                        if (TipoMov == "C" || TipoMov == "V") //Entre Cuentas - Vinculadas
                        {
                            cboEmpresas.SelectedValue = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                            cboEmpresas_SelectionChangeCommitted(new Object(), new EventArgs());
                            cboMonedaEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());

                            if (TipoMov == "V")
                            {
                                cboDocumento.Enabled = false;
                                cboDocumento.SelectedValue = "PR";
                                txtSerie.Text = "PR";
                            }
                        }
                    }
                }
                else
                {
                    BuscarCombo = "N";

                    if (Convert.ToInt32(oMovDetalle.idConcepto) == 0)
                    {
                        cboConceptos.SelectedIndex = 0;
                    }
                    else
                    {
                        cboConceptos.SelectedValue = Convert.ToInt32(oMovDetalle.idConcepto);
                    }

                    cboConceptos_SelectionChangeCommitted(new object(), new EventArgs());

                    if (((ConceptosVariosE)cboConceptos.SelectedItem).indAuxiliar == "S")
                    {
                        txtIdBanco.Text = oMovDetalle.idPersona.ToString();
                        txtRuc.Text = oMovDetalle.RUC;
                        txtRazonSocial.Text = oMovDetalle.desBanco;
                    }
                    else
                    {
                        txtIdBanco.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                    }

                    if (((ConceptosVariosE)cboConceptos.SelectedItem).indCentroCosto == "S")
                    {
                        txtCCostos.Text = oMovDetalle.idCCostos;
                        txtDesCCostos.Text = oMovDetalle.desCCostos;
                    }
                    else
                    {
                        txtCCostos.Text = String.Empty;
                        txtDesCCostos.Text = String.Empty;
                    }

                    cboDocumento.SelectedValue = oMovDetalle.idDocumento.ToString();
                    txtSerie.Text = oMovDetalle.serDocumento;
                    txtNumDoc.Text = oMovDetalle.numDocumento;
                    dtpFecDocumento.Value = oMovDetalle.fecDocumento.Date;

                    if (oMovDetalle.fecVencimiento != null)
                    {
                        dtpFecVencimiento.Value = oMovDetalle.fecVencimiento.Value.Date;
                    }

                    txtTipPartida.Text = oMovDetalle.tipPartidaPresu;
                    txtPartida.Text = oMovDetalle.codPartidaPresu;
                    txtDesPartida.Text = oMovDetalle.desPartidaPresu;

                    txtSoles.Text = oMovDetalle.Importe.ToString("N2");
                    txtDolares.Text = oMovDetalle.ImporteDolar.ToString("N2");
                    chkTicaAuto.Checked = oMovDetalle.TicaAuto;
                    txtTica.Text = oMovDetalle.tipCambio.ToString("N3");
                    txtGlosa.Text = oMovDetalle.Glosa;

                    cboReparable.SelectedValue = oMovDetalle.indReparable.ToString();
                    cboReparable_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboConceptoReparable.SelectedValue = Convert.ToInt32(oMovDetalle.idConceptoRep);
                    txtRefRepa.Text = oMovDetalle.desReferenciaRep;
                    chkExceso.Checked = oMovDetalle.indExceso;

                    cboMoneda.SelectedValue = !String.IsNullOrWhiteSpace(oMovDetalle.idMoneda) ? oMovDetalle.idMoneda.ToString() : Variables.Soles;
                    cboMoneda_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (((ConceptosVariosE)cboConceptos.SelectedItem).indTransferencia)
                    {
                        pnlTransferencia.Enabled = true;
                        LlenarCombosTransferencia();

                        if (oMovDetalle.idEmpresaTrans != null)
                        {
                            cboEmpresas.SelectedValue = oMovDetalle.idEmpresaTrans;
                            cboEmpresas_SelectionChangeCommitted(new Object(), new EventArgs());
                            cboBancosEmpresa.SelectedValue = Convert.ToInt32(oMovDetalle.idBancoTrans);
                            cboBancosEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());
                            cboMonedaEmpresa.SelectedValue = oMovDetalle.idMonedaTrans.ToString();
                            cboMonedaEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());
                            cboCuentasBancarias.SelectedValue = oMovDetalle.ctaBancariaTrans.ToString();
                        }

                        if (TipoMov == "V")
                        {
                            cboDocumento.Enabled = false;
                        }
                    }
                    else
                    {
                        pnlTransferencia.Enabled = false;
                        cboEmpresas.DataSource = null;
                        cboBancosEmpresa.DataSource = null;
                        cboMonedaEmpresa.DataSource = null;
                        cboCuentasBancarias.DataSource = null;
                    }

                    if (oMovDetalle.VieneApertura)
                    {
                        txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                        txtNumDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    }

                    txtUsuRegistro.Text = oMovDetalle.UsuarioRegistro;
                    txtFechaRegistro.Text = oMovDetalle.FechaRegistro.ToString();
                    txtUsuModificacion.Text = oMovDetalle.UsuarioModificacion;
                    txtFechaModificacion.Text = oMovDetalle.FechaModificacion.ToString();

                    BuscarCombo = "S";
                }

                if (EstadoDet == "PR" || EstadoDet == "AN" || EstadoDet == "BL")
                {
                    pnlBase.Enabled = false;
                    pnlDocumentos.Enabled = false;
                    pnlPartida.Enabled = false;
                    pnlImportes.Enabled = false;
                    txtGlosa.Enabled = false;
                    pnlReparable.Enabled = false;
                    pnlTransferencia.Enabled = false;
                    btAceptar.Enabled = false;
                    chkExceso.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }

            txtRuc.TextChanged += txtRuc_TextChanged;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            txtPartida.TextChanged += txtPartida_TextChanged;
            txtDolares.TextChanged += txtDolares_TextChanged;
            txtSoles.TextChanged += txtSoles_TextChanged;
            dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
        }

        public override void Aceptar()
        {
            if (oMovDetalle != null)
            {
                Datos();

                if (!ValidarGrabacion())
                {
                    return;
                }
                
                base.Aceptar();
            }
        }

        public override bool ValidarGrabacion()
        {
            if (cboConceptos.SelectedValue == null)
            {
                Global.MensajeFault("Debe escoger un concepto.");
                return false;
            }

            if (((ConceptosVariosE)cboConceptos.SelectedItem).indAuxiliar == "S")
            {
                if (String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    Global.MensajeFault("La cuenta asociada al concepto, necesita un auxiliar.");
                    txtSerie.Focus();
                    return false; 
                }

                if (String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    Global.MensajeFault("La cuenta asociada al concepto, necesita un auxiliar.");
                    txtSerie.Focus();
                    return false;
                }
            }

            if (((ConceptosVariosE)cboConceptos.SelectedItem).indCentroCosto == "S")
            {
                if (String.IsNullOrWhiteSpace(txtCCostos.Text.Trim()))
                {
                    Global.MensajeFault("La cuenta asociada al concepto, necesita un centro de costo.");
                    txtSerie.Focus();
                    return false;
                }
            }

            if (TipoMov == "V" || TipoMov == "C")
            {
                if (((ConceptosVariosE)cboConceptos.SelectedItem).indTransferencia)
                {
                    if (Convert.ToInt32(cboEmpresas.SelectedValue) == 0)
                    {
                        Global.MensajeFault("Tiene que escoger una empresa.");
                        cboEmpresas.Focus();
                        return false;
                    }

                    if (String.IsNullOrWhiteSpace(((BancosCuentasE)cboCuentasBancarias.SelectedItem).numVerPlanCuentas))
                    {
                        Global.MensajeFault("La Cta. Bancaria no posee Cuenta Contable asociada. Vaya al maestro de Bancos.");
                        cboEmpresas.Focus();
                    }

                    if (String.IsNullOrWhiteSpace(((BancosCuentasE)cboCuentasBancarias.SelectedItem).codCuenta))
                    {
                        Global.MensajeFault("La Cta. Bancaria no posee Cuenta Contable asociada. Vaya al maestro de Bancos.");
                        cboEmpresas.Focus();
                    } 
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmMovBancosDet_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {
            Int32 Nivel = 1;

            if (VariablesLocales.oConParametros != null)
            {
                if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                {
                    Nivel = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                }
            }

            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCCostos.Text = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void cboReparable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboReparable.SelectedValue != null)
                {
                    if (cboReparable.SelectedValue.ToString() == EnumReparable.R.ToString())
                    {
                        cboConceptoReparable.Enabled = true;
                        txtRefRepa.Enabled = true;
                        txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }
                    else
                    {
                        cboConceptoReparable.SelectedValue = Variables.Cero;
                        cboConceptoReparable.Enabled = false;
                        txtRefRepa.Enabled = false;
                        txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = null;

                    if (TipoMov == "N")
                    {
                        oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);
                    }
                    else
                    {
                        if (cboEmpresas.SelectedValue != null)
                        {
                            oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("BA", Convert.ToInt32(cboEmpresas.SelectedValue), "", txtRuc.Text.Trim());
                        }
                        else
                        {
                            oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);
                        }
                    }

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdBanco.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            if (txtCCostos.Enabled)
                            {
                                txtCCostos.Focus();
                            }
                            else
                            {
                                if (pnlDocumentos.Enabled)
                                {
                                    cboDocumento.Focus();
                                }
                            }
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdBanco.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        if (txtCCostos.Enabled)
                        {
                            txtCCostos.Focus();
                        }
                        else
                        {
                            if (pnlDocumentos.Enabled)
                            {
                                cboDocumento.Focus();
                            }
                        }
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("EL Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdBanco.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = null;

                    if (TipoMov == "N")
                    {
                        oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);
                    }
                    else
                    {
                        if (cboEmpresas.SelectedValue != null)
                        {
                            oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("BA", Convert.ToInt32(cboEmpresas.SelectedValue), txtRazonSocial.Text.Trim(), "");
                        }
                        else
                        {
                            oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);
                        }
                    }

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdBanco.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            if (txtCCostos.Enabled)
                            {
                                txtCCostos.Focus();
                            }
                            else
                            {
                                if (pnlDocumentos.Enabled)
                                {
                                    cboDocumento.Focus();
                                }
                            }
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdBanco.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        if (txtCCostos.Enabled)
                        {
                            txtCCostos.Focus();
                        }
                        else
                        {
                            if (pnlDocumentos.Enabled)
                            {
                                cboDocumento.Focus();
                            }
                        }
                    }
                    else
                    {
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("EL Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
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
            txtIdBanco.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void dtpFecDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMedioPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboReparable_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboConceptoReparable_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void btBuscaPartida_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarPartida oFrm = new frmBuscarPartida();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
                {
                    txtPartida.TextChanged -= txtPartida_TextChanged;

                    txtTipPartida.Text = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                    txtPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                    txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;

                    txtPartida.TextChanged += txtPartida_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPartida_TextChanged(object sender, EventArgs e)
        {
            txtDesPartida.Text = String.Empty;
            txtTipPartida.Text = String.Empty;
            txtDesPartida.Text = String.Empty;
        }

        private void cboConceptos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboConceptos.SelectedValue != null)
                {
                    if (((ConceptosVariosE)cboConceptos.SelectedItem).indAuxiliar == "S")
                    {
                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }
                    else
                    {
                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                        txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    }

                    if (((ConceptosVariosE)cboConceptos.SelectedItem).indCentroCosto == "S")
                    {
                        txtCCostos.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        btCentroC.Enabled = true;
                    }
                    else
                    {
                        txtCCostos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                        txtDesCCostos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                        btCentroC.Enabled = false;
                    }

                    if (BuscarCombo == "S")
                    {
                        if (((ConceptosVariosE)cboConceptos.SelectedItem).indTransferencia)
                        {
                            if (TipoMov == "C" || TipoMov == "V") //Entre Cuentas - Vinculadas
                            {
                                pnlTransferencia.Enabled = true;
                                LlenarCombosTransferencia();

                                cboEmpresas_SelectionChangeCommitted(new Object(), new EventArgs());
                                cboMonedaEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());

                                if (TipoMov == "V")
                                {
                                    cboDocumento.Enabled = false;
                                    cboDocumento.SelectedValue = "PR";
                                    txtSerie.Text = "PR";
                                }
                            }
                        }
                        else
                        {
                            pnlTransferencia.Enabled = false;
                            cboEmpresas.DataSource = null;
                            cboBancosEmpresa.DataSource = null;
                            cboMonedaEmpresa.DataSource = null;
                            cboCuentasBancarias.DataSource = null;
                            cboDocumento.Enabled = true;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkTicaAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTicaAuto.Checked)
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }

            BloquearCajas();
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BloquearCajas();
            CalcularTiCa();
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTicaAuto.Checked)
                {
                    DateTime Fecha = dtpFecDocumento.Value.Date;
                    TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

                    if (Tica != null)
                    {
                        txtTica.Text = Tica.valVenta.ToString("N3");
                    }
                    else
                    {
                        txtTica.Text = "0.000";
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtTica_Leave(object sender, EventArgs e)
        {
            txtTica.Text = Global.FormatoDecimal(txtTica.Text, 3);
        }

        private void txtSoles_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTiCa();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDolares_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTiCa();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtSoles_Leave(object sender, EventArgs e)
        {
            txtSoles.Text = Global.FormatoDecimal(txtSoles.Text);
        }

        private void txtDolares_Leave(object sender, EventArgs e)
        {
            txtDolares.Text = Global.FormatoDecimal(txtDolares.Text);
        }

        private void cboEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboEmpresas.SelectedValue != null)
                {
                    List<BancosE> oListaBancos = AgenteMaestro.Proxy.ListarBancos(Convert.ToInt32(cboEmpresas.SelectedValue));
                    ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListaBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

                    if (BuscarCombo == "S")
                    {
                        if (cboEmpresas.SelectedValue != null && cboBancosEmpresa.SelectedValue != null)
                        {
                            ObtenerCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), Convert.ToInt32(cboEmpresas.SelectedValue), cboMonedaEmpresa.SelectedValue.ToString());
                        }
                    }

                    if (oListaBancos.Count == 0)
                    {
                        cboBancosEmpresa.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (BuscarCombo == "S")
                {
                    if (cboBancosEmpresa.SelectedValue != null && cboMonedaEmpresa.SelectedValue != null)
                    {
                        ObtenerCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), Convert.ToInt32(cboEmpresas.SelectedValue), cboMonedaEmpresa.SelectedValue.ToString());
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMonedaEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null && cboMonedaEmpresa.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), Convert.ToInt32(cboEmpresas.SelectedValue), cboMonedaEmpresa.SelectedValue.ToString());
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
