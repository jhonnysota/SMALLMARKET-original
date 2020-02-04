using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using Infraestructura.Extensores;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmMovBancos : FrmMantenimientoBase
    {

        #region Constructores

        public frmMovBancos()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetalle, false);
        }

        //Nuevo
        public frmMovBancos(List<BancosE> oListaBanco, List<ParTabla> oListaTipos)
            : this()
        {
            oListaBancos = oListaBanco;
            oListaTipoMov = oListaTipos;
        }

        //Edición
        public frmMovBancos(List<BancosE> oListaBanco, List<ParTabla> oListaTipos, Int32 idMovimiento, String Estado, Boolean Bloq)
            : this()
        {
            oMovimientoBanco = AgenteTesoreria.Proxy.ObtenerMovimientoBancos(idMovimiento);
            Text = "Movimiento de Bancos(" + oMovimientoBanco.codMovBanco + ")";
            oListaBancos = oListaBanco;
            oListaTipoMov = oListaTipos;
            EstadoReg = oMovimientoBanco.indEstado;
            Bloquear = Bloq;
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MovimientoBancosE oMovimientoBanco = null;
        List<BancosE> oListaBancos = null;
        List<ParTabla> oListaTipoMov = null;
        String EstadoReg = "CR"; //CR=Creado PR=Provisionado AN=Anulado
        String BuscarDatos = "S";
        Boolean Bloquear = false;
        Boolean GrabarDatosIngreso = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListaBancos
                                                                   where x.idPersona != 0
                                                                   orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");

            ComboHelper.RellenarCombos<ParTabla>(cboTipoMov, (from x in oListaTipoMov
                                                              where x.IdParTabla != 0
                                                              select x).ToList(), "IdParTabla", "Nombre");

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desAbreviatura", false);

            // Medios de Pago
            List<ParTabla> oListaMedioPago = AgenteGeneral.Proxy.ListarParTablaPorNemo("MEDPAG");
            ParTabla oInicio = new ParTabla { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            oListaMedioPago.Add(oInicio);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboMedioPago, (from x in oListaMedioPago orderby x.IdParTabla select x).ToList());

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = " " + Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);
        }

        void ObtenerCuentasBancarias(Int32 idBanco, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentaBancarias = AgenteMaestro.Proxy.BancosCuentasPorMoneda(idBanco, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idMoneda);
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentasBancarias, oListaCuentaBancarias, "numCuenta", "desCuentaBanco", false);

            if (oListaCuentaBancarias.Count > 1)
            {
                cboCuentasBancarias.Enabled = true;
            }
            else
            {
                cboCuentasBancarias.Enabled = false;
            }

            cboCuentasBancarias_SelectionChangeCommitted(new Object(), new EventArgs());
        }

        void DatosGrabacion()
        {
            oMovimientoBanco.codMovBanco = txtCodMov.Text.Trim();
            oMovimientoBanco.fecMovimiento = dtpFecMov.Value.Date;
            oMovimientoBanco.tipMovimiento = Convert.ToInt32(cboTipoMov.SelectedValue);
            oMovimientoBanco.idBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);
            oMovimientoBanco.idMoneda = cboMonedas.SelectedValue.ToString();
            oMovimientoBanco.ctaBancaria = cboCuentasBancarias.SelectedValue.ToString();
            oMovimientoBanco.tipCambio = Convert.ToDecimal(txtTica.Text);
            oMovimientoBanco.Glosa = txtGlosa.Text.Trim();
            oMovimientoBanco.numVerPlanCuentas = txtVersion.Text;
            oMovimientoBanco.codCuenta = txtCodCuenta.Text.Trim();
            oMovimientoBanco.idMedioPago = Convert.ToInt32(cboMedioPago.SelectedValue);

            if (((BancosCuentasE)cboCuentasBancarias.SelectedItem).SolicitaDoc == "S")
            {
                oMovimientoBanco.idDocumento = cboDocumento.SelectedValue.ToString();
                oMovimientoBanco.serDocumento = txtSerie.Text.Trim();
                oMovimientoBanco.numDocumento = txtNumDoc.Text.Trim();
                oMovimientoBanco.fecDocumento = dtpFecDocumento.Value.Date;
                oMovimientoBanco.fecVencimiento = dtpFecVencimiento.Checked ? dtpFecVencimiento.Value.Date : (DateTime?)null;
            }
            else
            {
                oMovimientoBanco.idDocumento = String.Empty;
                oMovimientoBanco.serDocumento = String.Empty;
                oMovimientoBanco.numDocumento = String.Empty;
                oMovimientoBanco.fecDocumento = (DateTime?)null;
                oMovimientoBanco.fecVencimiento = (DateTime?)null;
            }

            oMovimientoBanco.GiradoA = txtGirado.Text.Trim();
            oMovimientoBanco.TotalImporte = Convert.ToDecimal(lblTotalSoles.Text);
            oMovimientoBanco.TotalImporteDol = Convert.ToDecimal(lblTotalDolar.Text);

            if (Convert.ToInt32(cboTipoMov.SelectedValue) == 3 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
            {
                oMovimientoBanco.MontoTransS = Convert.ToDecimal(txtTransferenciaS.Text);
                oMovimientoBanco.MontoTransD = Convert.ToDecimal(txtTransferenciaD.Text);
            }
            else
            {
                oMovimientoBanco.MontoTransS = 0;
                oMovimientoBanco.MontoTransD = 0;
            }

            oMovimientoBanco.TicaAuto = chkTicaAuto.Checked;
            oMovimientoBanco.indDevolucion = chkDevolucion.Checked;

            if (String.IsNullOrWhiteSpace(txtCodMov.Text.Trim()))
            {
                oMovimientoBanco.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oMovimientoBanco.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, MovimientoBancosDetE oItem)
        {
            try
            {
                frmMovBancosDet oFrm = new frmMovBancosDet(oItem, cboMonedas.SelectedValue.ToString(), ((ParTabla)cboTipoMov.SelectedItem).Nombre, EstadoReg);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oMovDetalle != null)
                {
                    MovimientoBancosDetE ItemDet = oFrm.oMovDetalle;
                    oMovimientoBanco.oListaMovimientos[e.RowIndex] = ItemDet;
                    bsDetalle.DataSource = oMovimientoBanco.oListaMovimientos;
                    bsDetalle.ResetBindings(false);

                    base.AgregarDetalle();
                    Sumar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Sumar()
        {
            if (oMovimientoBanco.oListaMovimientos != null && oMovimientoBanco.oListaMovimientos.Count > 0)
            {
                Decimal TotalS = oMovimientoBanco.oListaMovimientos.Sum(x => x.Importe);
                Decimal TotalD = oMovimientoBanco.oListaMovimientos.Sum(x => x.ImporteDolar);
                lblTotalSoles.Text = TotalS.ToString("N2");
                lblTotalDolar.Text = TotalD.ToString("N2");
            }
            else
            {
                lblTotalSoles.Text = "0.00";
                lblTotalDolar.Text = "0.00";
            }
        }

        void Calcular()
        {
            try
            {
                if (Convert.ToInt32(cboTipoMov.SelectedValue) == 3 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
                {
                    Decimal Soles = 0;
                    Decimal Dolares = 0;
                    Decimal Tica = 0;

                    Decimal.TryParse(txtTransferenciaS.Text, out Soles);
                    Decimal.TryParse(txtTransferenciaD.Text, out Dolares);

                    if (chkTicaAuto.Checked)
                    {
                        Decimal.TryParse(txtTica.Text, out Tica);

                        if (Tica > 0)
                        {
                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                            {
                                Dolares = Soles / Tica;
                                txtTransferenciaD.Text = Dolares.ToString("N2");
                            }
                            else
                            {
                                Soles = Dolares * Tica;
                                txtTransferenciaS.Text = Soles.ToString("N2");
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
                else
                {
                    txtTransferenciaS.Text = "0.00";
                    txtTransferenciaD.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        void TipoCambio()
        {
            DateTime Fecha = dtpFecMov.Value;
            TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMonedas.SelectedValue.ToString(), Fecha.Date);

            if (Tica != null)
            {
                txtTica.Text = Tica.valVenta.ToString("N3");
            }
            else
            {
                txtTica.Text = "0.000";
            }
        }

        void RevisarMonedas()
        {
            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
            {
                txtTransferenciaS.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtTransferenciaD.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
            else
            {
                txtTransferenciaS.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtTransferenciaD.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        void DatosGrabacionIngreso()
        {
            oMovimientoBanco.idDocumento = cboDocumento.SelectedValue.ToString();
            oMovimientoBanco.serDocumento = txtSerie.Text.Trim();
            oMovimientoBanco.numDocumento = txtNumDoc.Text.Trim();
            oMovimientoBanco.fecDocumento = dtpFecDocumento.Value.Date;
            oMovimientoBanco.fecVencimiento = dtpFecVencimiento.Checked ? dtpFecVencimiento.Value.Date : (DateTime?)null;
            oMovimientoBanco.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oMovimientoBanco == null)
                {
                    oMovimientoBanco = new MovimientoBancosE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                    };

                    txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                    cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());
                    chkTicaAuto.Checked = true;
                }
                else
                {
                    BuscarDatos = "N";
                    cboTipoMov.Enabled = false;
                    dtpFecMov.ValueChanged -= dtpFecMov_ValueChanged;

                    txtCodMov.Text = oMovimientoBanco.codMovBanco;
                    dtpFecMov.Value = oMovimientoBanco.fecMovimiento.Date;
                    cboTipoMov.SelectedValue = Convert.ToInt32(oMovimientoBanco.tipMovimiento);
                    cboTipoMov_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboBancosEmpresa.SelectedValue = Convert.ToInt32(oMovimientoBanco.idBanco);
                    cboMonedas.SelectedValue = oMovimientoBanco.idMoneda.ToString();
                    cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboCuentasBancarias.SelectedValue = oMovimientoBanco.ctaBancaria.ToString();
                    chkTicaAuto.Checked = oMovimientoBanco.TicaAuto;
                    chkTicaAuto_CheckedChanged(null, null);
                    txtTica.Text = oMovimientoBanco.tipCambio.ToString("N3");
                    txtGlosa.Text = oMovimientoBanco.Glosa;
                    cboMedioPago.SelectedValue = oMovimientoBanco.idMedioPago;

                    if (((BancosCuentasE)cboCuentasBancarias.SelectedItem).SolicitaDoc == "S")
                    {
                        cboDocumento.SelectedValue = oMovimientoBanco.idDocumento.ToString();
                        txtSerie.Text = oMovimientoBanco.serDocumento;
                        txtNumDoc.Text = oMovimientoBanco.numDocumento;
                        dtpFecDocumento.Value = oMovimientoBanco.fecDocumento.Value.Date;

                        if (oMovimientoBanco.fecVencimiento != null)
                        {
                            dtpFecVencimiento.Value = oMovimientoBanco.fecVencimiento.Value.Date;
                        }
                    }
                    else
                    {
                        cboDocumento.SelectedValue = "0";
                        txtSerie.Text = String.Empty;
                        txtNumDoc.Text = String.Empty;
                    }

                    txtGirado.Text = oMovimientoBanco.GiradoA;
                    txtVersion.Text = oMovimientoBanco.numVerPlanCuentas;
                    txtCodCuenta.Text = oMovimientoBanco.codCuenta;
                    chkDevolucion.Checked = oMovimientoBanco.indDevolucion;

                    if (Convert.ToInt32(cboTipoMov.SelectedValue) == 3 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
                    {
                        txtTransferenciaS.Text = oMovimientoBanco.MontoTransS.ToString("N2");
                        txtTransferenciaD.Text = oMovimientoBanco.MontoTransD.ToString("N2");
                    }
                    else
                    {
                        txtTransferenciaS.Text = "0.00";
                        txtTransferenciaD.Text = "0.00";
                    }

                    txtUsuRegistra.Text = oMovimientoBanco.UsuarioRegistro;
                    txtFechaRegistro.Text = oMovimientoBanco.FechaRegistro.ToString();
                    txtUsuModifica.Text = oMovimientoBanco.UsuarioModificacion;
                    txtFechaModifica.Text = oMovimientoBanco.FechaModificacion.ToString();

                    dtpFecMov.ValueChanged += dtpFecMov_ValueChanged;
                    BuscarDatos = "S";
                }

                bsDetalle.DataSource = oMovimientoBanco.oListaMovimientos;
                bsDetalle.ResetBindings(false);

                Sumar();

                if (EstadoReg == "CR")
                {
                    if (!Bloquear)
                    {
                        base.Nuevo();
                        btPendientes.Enabled = true;
                        BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    }
                    else
                    {
                        EstadoReg = "BL";
                        GrabarDatosIngreso = true;
                        pnlPrincipales.Enabled = false;
                        btPendientes.Enabled = false;
                        chkDevolucion.Enabled = false;
                        BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                        BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                        Global.MensajeComunicacion("No podrá hacer modificaciones es un Ingreso por Transferencia que viene de otra empresa, a excepción de los datos del Documento.");
                    }
                }
                else
                {
                    if (EstadoReg == "PR")
                    {
                        Global.MensajeComunicacion("No podrá hacer modificaciones porque se encuentra provisionado.");
                    }
                    else
                    {
                        Global.MensajeComunicacion("No podrá hacer modificaciones porque se encuentra anulado.");
                    }
                    
                    pnlPrincipales.Enabled = false;
                    pnlDocumentos.Enabled = false;
                    btPendientes.Enabled = false;
                    chkDevolucion.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsDetalle.EndEdit();

                if (!GrabarDatosIngreso)
                {
                    DatosGrabacion();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(txtCodMov.Text.Trim()))
                    {
                        if (Global.MensajeConfirmacion("Desea grabar el registro.") == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.GrabarMovimientoBancos(oMovimientoBanco, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Desea actualizar el registro.") == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.GrabarMovimientoBancos(oMovimientoBanco, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }
                else
                {
                    DatosGrabacionIngreso();

                    if (Global.MensajeConfirmacion("Desea actualizar el registro.") == DialogResult.Yes)
                    {
                        AgenteTesoreria.Proxy.ActualizarMovimientoBancosDocIngresos(oMovimientoBanco);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                BancosE oBanco = null;
                Decimal Tica = 0;
                Decimal Soles = 0;
                Decimal Dolares = 0;

                if (cboBancosEmpresa.SelectedValue != null)
                {
                    oBanco = ((BancosE)cboBancosEmpresa.SelectedItem);
                }

                if (Convert.ToInt32(cboTipoMov.SelectedValue) == 3 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
                {
                    Tica = Convert.ToDecimal(txtTica.Text);
                    Soles = Convert.ToDecimal(txtTransferenciaS.Text);
                    Dolares = Convert.ToDecimal(txtTransferenciaD.Text);
                }

                frmMovBancosDet oFrm = new frmMovBancosDet(oBanco, cboMonedas.SelectedValue.ToString(), txtGlosa.Text.Trim(), dtpFecMov.Value, Tica, Soles, Dolares, ((ParTabla)cboTipoMov.SelectedItem).Nombre);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oMovDetalle != null)
                {
                    Int32 Item;
                    MovimientoBancosDetE oDetalle = new MovimientoBancosDetE();
                    oDetalle = oFrm.oMovDetalle;

                    if (oMovimientoBanco.oListaMovimientos.Count == Variables.Cero)
                    {
                        Item = Variables.ValorUno;
                    }
                    else
                    {
                        Item = Convert.ToInt32(oMovimientoBanco.oListaMovimientos.Max(mx => mx.Item)) + 1;
                    }

                    oDetalle.Item = Item;
                    oMovimientoBanco.oListaMovimientos.Add(oDetalle);
                    bsDetalle.DataSource = oMovimientoBanco.oListaMovimientos;
                    bsDetalle.ResetBindings(false);

                    base.AgregarDetalle();
                    Sumar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (oMovimientoBanco.oListaMovimientos != null && oMovimientoBanco.oListaMovimientos.Count > 0)
                {
                    oMovimientoBanco.oListaMovimientos.Remove((MovimientoBancosDetE)bsDetalle.Current);
                    bsDetalle.DataSource = oMovimientoBanco.oListaMovimientos;
                    bsDetalle.ResetBindings(false);

                    base.QuitarDetalle();
                    Sumar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (cboBancosEmpresa.SelectedValue == null)
            {
                Global.MensajeFault("Debe escoger un banco");
                return false;
            }

            if (cboCuentasBancarias.SelectedValue == null)
            {
                Global.MensajeFault("Debe escoger un número de cuenta");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtVersion.Text.Trim()) && String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()))
            {
                Global.MensajeFault("Falta configurar la cuenta en la cuenta bancaria escogida.");
                return false;
            }

            String Comprobante = Convert.ToInt32(cboTipoMov.SelectedValue) == 1 ? "04" : "05";
            ComprobantesFileE numFile = AgenteContabilidad.Proxy.ObtenerFilePorCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Comprobante,
                                                                                    cboMonedas.SelectedValue.ToString(), ((BancosCuentasE)cboCuentasBancarias.SelectedItem).numVerPlanCuentas,
                                                                                    ((BancosCuentasE)cboCuentasBancarias.SelectedItem).codCuenta);
            if (numFile == null)
            {
                Global.MensajeFault(String.Format("No hay cuenta configurada en los Files de ", (Comprobante == "04" ? "INGRESOS" : "EGRESOS")));
                return false;
            }

            if (txtTica.Text == "0.000")
            {
                Global.MensajeFault("Debe ingresar una fecha que tenga Tipo de Cambio.");
                return false;
            }

            if (((BancosCuentasE)cboCuentasBancarias.SelectedItem).SolicitaDoc == "S")
            {
                if (cboDocumento.SelectedValue.ToString() == "0")
                {
                    Global.MensajeFault("La cuenta asociada al banco, solicita tipo de documento.");
                    cboDocumento.Focus();
                    return false;
                }

                if (String.IsNullOrWhiteSpace(txtSerie.Text) && String.IsNullOrWhiteSpace(txtNumDoc.Text))
                {
                    Global.MensajeFault("La cuenta asociada al banco, solicita documento.");
                    txtSerie.Focus();
                    return false;
                }
            }

            if (Convert.ToInt32(cboMedioPago.SelectedValue) == 0)
            {
                Global.MensajeFault("Debe seleccionar un Medio de Pago.");
                cboMedioPago.Focus();
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmMovBancos_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            Nuevo();
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null && cboMonedas.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMonedas.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null && cboMonedas.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMonedas.SelectedValue.ToString());

                    if (chkTicaAuto.Checked)
                    {
                        RevisarMonedas();
                    }
                    else
                    {
                        txtTransferenciaS.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtTransferenciaD.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecMov_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTicaAuto.Checked)
                {
                    TipoCambio();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oMovimientoBanco.oListaMovimientos.Count > 0)
            {
                EditarDetalle(e, (MovimientoBancosDetE)bsDetalle.Current);
            }
        }

        private void cboCuentasBancarias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCuentasBancarias.SelectedValue != null)
            {
                txtVersion.Text = ((BancosCuentasE)cboCuentasBancarias.SelectedItem).numVerPlanCuentas;
                txtCodCuenta.Text = ((BancosCuentasE)cboCuentasBancarias.SelectedItem).codCuenta;

                if (((BancosCuentasE)cboCuentasBancarias.SelectedItem).SolicitaDoc == "S")
                {
                    pnlDocumentos.Enabled = true;
                }
                else
                {
                    pnlDocumentos.Enabled = false;
                    txtSerie.Text = String.Empty;
                    txtNumDoc.Text = String.Empty;
                    cboDocumento.SelectedValue = "0";
                }
            }
            else
            {
                txtVersion.Text = String.Empty;
                txtCodCuenta.Text = String.Empty;
                pnlDocumentos.Enabled = false;
                txtSerie.Text = String.Empty;
                txtNumDoc.Text = String.Empty;
                cboDocumento.SelectedValue = "0";
            }
        }

        private void cboTipoMov_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoMov.SelectedValue) == 3 || Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
            {
                txtGlosa.Width = 237;
                lblTransS.Visible = true;
                lblTransD.Visible = true;
                txtTransferenciaS.Visible = true;
                txtTransferenciaD.Visible = true;
            }
            else
            {
                txtGlosa.Width = 393;
                lblTransS.Visible = false;
                lblTransD.Visible = false;
                txtTransferenciaS.Visible = false;
                txtTransferenciaD.Visible = false;
            }
        }

        private void cboTipoMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboBancosEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMonedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboCuentasBancarias_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMedioPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtTransferenciaS_Leave(object sender, EventArgs e)
        {
            txtTransferenciaS.Text = Global.FormatoDecimal(txtTransferenciaS.Text);
        }

        private void txtTransferenciaD_Leave(object sender, EventArgs e)
        {
            txtTransferenciaD.Text = Global.FormatoDecimal(txtTransferenciaD.Text);
        }

        private void txtTransferenciaS_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtTransferenciaD_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void chkTicaAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTicaAuto.Checked)
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                RevisarMonedas();

                if (BuscarDatos == "S")
                {
                    TipoCambio();
                }
            }
            else
            {
                txtTica.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtTransferenciaS.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtTransferenciaD.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
        }

        private void bsDetalle_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsDetalle.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkDevolucion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDevolucion.Checked && Convert.ToInt32(cboTipoMov.SelectedValue) == 4)
            {
                btPendientes.Enabled = true;
            }
            else
            {
                btPendientes.Enabled = false;
            }
        }

        private void btPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTransferenciaS.Text == "0.00" || txtTransferenciaD.Text == "0.00")
                {
                    Global.MensajeComunicacion("Debe ingresar un monto antes de buscar los Préstamos Pendientes.");
                    return;
                }

                frmPendientesAuxiliares oFrm = new frmPendientesAuxiliares("P", false);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    List<CtaCteE> oListaCtaCte = new List<CtaCteE>(oFrm.oListaCtaCte);
                    oMovimientoBanco.oListaMovimientos = AgenteTesoreria.Proxy.MovBancosDetallePorDocumento(oListaCtaCte, VariablesLocales.SesionUsuario.Credencial, VariablesLocales.FechaHoy);

                    if (oMovimientoBanco.oListaMovimientos != null && oMovimientoBanco.oListaMovimientos.Count > 0)
                    {
                        foreach (MovimientoBancosDetE item in oMovimientoBanco.oListaMovimientos)
                        {
                            item.VieneApertura = false;
                            item.indExceso = false;

                            CtaCteE ctaCte = oListaCtaCte.Find
                            (
                                delegate (CtaCteE cc) { return cc.idDocumento == item.idDocumento && cc.numSerie == item.serDocumento && cc.numDocumento == item.numDocumento; }
                            );

                            if (ctaCte != null)
                            {
                                if (item.idMoneda == "01")
                                {
                                    item.Importe = ctaCte.Saldo;
                                    item.ImporteDolar = ctaCte.Saldo / ctaCte.TipoCambio;
                                }
                                else
                                {
                                    item.Importe = ctaCte.Saldo * ctaCte.TipoCambio;
                                    item.ImporteDolar = ctaCte.Saldo;
                                }

                                if (ctaCte.desGlosa.ToUpper().Contains("APERT"))
                                {
                                    item.VieneApertura = true;
                                }
                                else
                                {
                                    item.VieneApertura = false;
                                }
                            }
                        }

                        bsDetalle.DataSource = oMovimientoBanco.oListaMovimientos;
                    }
                    else
                    {
                        if (oMovimientoBanco.oListaMovimientos == null)
                        {
                            oMovimientoBanco.oListaMovimientos = new List<MovimientoBancosDetE>();
                        }

                        MovimientoBancosDetE oMovDet = null;
                        Int32 ItemMov = 1;

                        foreach (CtaCteE item in oListaCtaCte)
                        {
                            //if (item.desGlosa.ToUpper().Contains("APERT"))
                            //{
                                oMovDet = new MovimientoBancosDetE()
                                {
                                    Item = ItemMov,
                                    idConcepto = 0,
                                    idPersona = null,
                                    idCCostos = String.Empty,
                                    idDocumento = item.idDocumento,
                                    serDocumento = item.numSerie,
                                    numDocumento = item.numDocumento,
                                    fecDocumento = item.FechaDocumento,
                                    fecVencimiento = null,
                                    idMoneda = item.idMoneda,
                                    TicaAuto = true,
                                    tipCambio = item.TipoCambio,
                                    Glosa = item.desGlosa,
                                    indReparable = "N",
                                    idConceptoRep = 0,
                                    desReferenciaRep = String.Empty,
                                    tipPartidaPresu = String.Empty,
                                    codPartidaPresu = String.Empty,
                                    idMoviTrans = null,
                                    idEmpresaTrans = null,
                                    idBancoTrans = null,
                                    idMonedaTrans = null,
                                    ctaBancariaTrans = String.Empty,
                                    idCtaCteItem = null,
                                    VieneApertura = item.desGlosa.ToUpper().Contains("APERTU") ? true : false,
                                    indExceso = false,
                                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                    FechaRegistro = VariablesLocales.FechaHoy,
                                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                    FechaModificacion = VariablesLocales.FechaHoy
                                };

                                if (item.idMoneda == "01")
                                {
                                    oMovDet.Importe = item.Saldo;
                                    oMovDet.ImporteDolar = item.Saldo / item.TipoCambio;
                                }
                                else
                                {
                                    oMovDet.Importe = item.Saldo * item.TipoCambio;
                                    oMovDet.ImporteDolar = item.Saldo;
                                }

                                oMovimientoBanco.oListaMovimientos.Add(oMovDet);
                                ItemMov++;
                            //}
                        }

                        bsDetalle.DataSource = oMovimientoBanco.oListaMovimientos;
                    }

                    bsDetalle.ResetBindings(false);
                    oListaCtaCte = null;
                    base.AgregarDetalle();
                    Sumar();
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
