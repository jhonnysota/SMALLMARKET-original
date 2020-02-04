using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmCancelaciones : frmResponseBase
    {

        #region Constructores

        public frmCancelaciones()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvMedioPago, true);
            LlenarCombos();
        }

        public frmCancelaciones(EmisionDocumentoE oDocumento_, Int32 idTipoCondicion, Int32 idCondicion, List<EmisionDocumentoCancelacionE> oListaCancelacion_ = null)
            :this()
        {
            oDocumento = oDocumento_;

            if (oDocumento.indEstado == "E")
            {
                btInsertar.Enabled = false;
                btBorrar.Enabled = false;
            }

            if (oListaCancelacion_ != null && oListaCancelacion_.Count > 0)
            {
                ListaCancelaciones = oListaCancelacion_;
            }

            if (idTipoCondicion == 1 && idCondicion == 1)
            {
                chkCobranza.Checked = false;
                chkCobranza.Enabled = true;
            }
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public List<EmisionDocumentoCancelacionE> ListaCancelaciones = null;
        EmisionDocumentoE oDocumento = null;
        List<MonedasE> oListaMonedas = null;
        List<MedioPagoE> oListaMedioPago = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ////// Moneda ///////
            oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in oListaMonedas
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desAbreviatura", false);

            ////// Medio Pago ///////
            oListaMedioPago = AgenteVentas.Proxy.ListarMedioPago(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<MedioPagoE>(cboMedioPago, (from x in oListaMedioPago
                                                              orderby x.idMedioPago
                                                              select x).ToList(), "idMedioPago", "Nombre", false);
            

            if (oListaMedioPago == null || oListaMedioPago.Count == 0)
            {
                Global.MensajeComunicacion("Falta configurar los Medios de Pago");
            }

            ////// Documentos ///////
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoRec, (from x in ListaDocumentos
                                                                      orderby x.desDocumento
                                                                      select x).ToList(), "idDocumento", "desDocumento", false);

            ////// Bancos ///////
            List<BancosE> oListaBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<BancosE>(cboBancos, (from x in oListaBancos orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");
        }

        String DevolverMoneda(String idMoneda)
        {
            String Moneda = String.Empty;

            MonedasE oMoneda = oListaMonedas.Find
            (
                delegate (MonedasE m) { return m.idMoneda == idMoneda; }
            );

            if (oMoneda != null)
            {
                Moneda = oMoneda.desAbreviatura;
            }

            return Moneda;
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
        }

        void Calcular()
        {
            Decimal MontoRecibido = 0;
            Decimal.TryParse(txtMonto.Text, out decimal MontoDoc);
            Decimal.TryParse(txtTica.Text, out decimal Tica);

            if (txtMonedaDocu.Tag.ToString() != cboMonedas.SelectedValue.ToString())
            {
                if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                {
                    MontoRecibido = MontoDoc * Tica;
                }
                else
                {
                    MontoRecibido = MontoDoc / Tica;
                }
            }
            else
            {
                MontoRecibido = MontoDoc;
            }

            txtMontoRec.Text = MontoRecibido.ToString("N2");
        }

        void CalcularTiCa()
        {
            txtTica.TextChanged -= txtTica_TextChanged;

            Decimal.TryParse(txtMontoRec.Text, out Decimal MontoRecibido);
            Decimal.TryParse(txtMonto.Text, out Decimal MontoDoc);
            Decimal.TryParse(txtTica.Text, out Decimal TicaReal);
            Decimal Tica = 0M;

            if (txtMonedaDocu.Tag.ToString() != cboMonedas.SelectedValue.ToString())
            {
                if (txtMonedaDocu.Tag.ToString() == "02" && cboMonedas.SelectedValue.ToString() == "01")
                {
                    Tica = MontoRecibido / MontoDoc;
                }

                if (txtMonedaDocu.Tag.ToString() == "01" && cboMonedas.SelectedValue.ToString() == "02")
                {
                    Tica = MontoDoc / MontoRecibido;
                }
            }
            else
            {
                Tica = TicaReal;
            }

            txtTica.Text = Tica.ToString("N3");

            txtTica.TextChanged += txtTica_TextChanged;
        }

        void SumaTotales(List<EmisionDocumentoCancelacionE> oListaDetalle)
        {
            if (oListaDetalle != null && oListaDetalle.Count > Variables.Cero)
            {
                Decimal Total = Decimal.Round((from x in oListaDetalle select x.MontoAplicar).Sum(), 2);
                lblTotalCan.Text = Total.ToString("N2");
                foreach (EmisionDocumentoCancelacionE item in oListaDetalle)
                {
                    lblMonCan.Text = item.desMonedaDocu;
                }
            }
            else
            {
                lblMonCan.Text = "";
                lblTotalCan.Text = "0.00";
            }
        }

        #endregion

        #region Procedimientos de Usuario

        public override void Nuevo()
        {
            if (ListaCancelaciones == null)
            {
                txtTica.TextChanged -= txtTica_TextChanged;
                txtMonto.TextChanged -= txtMonto_TextChanged;
                txtMontoRec.TextChanged -= txtMontoRec_TextChanged;

                ListaCancelaciones = new List<EmisionDocumentoCancelacionE>();
                
                txtIdDocumento.Text = oDocumento.idDocumento;
                txtSerie.Text = oDocumento.numSerie;
                txtNumero.Text = oDocumento.numDocumento;
                txtFecha.Text = oDocumento.fecEmision.Substring(oDocumento.fecEmision.Length - 2, 2) + "/" + oDocumento.fecEmision.Substring(4, 2) + "/" + oDocumento.fecEmision.Substring(0, 4);

                cboMonedas.SelectedValue = oDocumento.idMoneda.ToString();
                txtTica.Text = oDocumento.tipCambio.ToString("N3");
                txtMonedaDocu.Tag = oDocumento.idMoneda;
                txtMonedaDocu.Text = DevolverMoneda(txtMonedaDocu.Tag.ToString());
                txtMonto.Text = oDocumento.totTotal.ToString("N2");
                cboDocumentoRec.SelectedValue = "DE";

                cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());

                txtTica.TextChanged += txtTica_TextChanged;
                txtMonto.TextChanged += txtMonto_TextChanged;
                txtMontoRec.TextChanged += txtMontoRec_TextChanged;
            }
            else
            {
                txtTica.TextChanged -= txtTica_TextChanged;
                txtMonto.TextChanged -= txtMonto_TextChanged;
                txtMontoRec.TextChanged -= txtMontoRec_TextChanged;

                txtIdDocumento.Text = oDocumento.idDocumento;
                txtSerie.Text = oDocumento.numSerie;
                txtNumero.Text = oDocumento.numDocumento;
                txtFecha.Text = oDocumento.fecEmision.Substring(oDocumento.fecEmision.Length - 2, 2) + "/" + oDocumento.fecEmision.Substring(4, 2) + "/" + oDocumento.fecEmision.Substring(0, 4); //oDocumento.fecEmision.ToString("dd/MM/yyyy");

                cboMonedas.SelectedValue = oDocumento.idMoneda.ToString();
                txtTica.Text = oDocumento.tipCambio.ToString("N3");
                txtMonedaDocu.Tag = oDocumento.idMoneda;
                txtMonedaDocu.Text = DevolverMoneda(txtMonedaDocu.Tag.ToString());
                txtMonto.Text = oDocumento.totTotal.ToString("N2");
                cboDocumentoRec.SelectedValue = "DE";

                cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());

                txtTica.TextChanged += txtTica_TextChanged;
                txtMonto.TextChanged += txtMonto_TextChanged;
                txtMontoRec.TextChanged += txtMontoRec_TextChanged;

                bsBase.DataSource = ListaCancelaciones;
                bsBase.ResetBindings(false);
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (ListaCancelaciones.Count == 0)
                {
                    Global.MensajeFault("Debe existir por lo menos una fila en el detalle.");
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtNumRec.Text.Trim()))
                {
                    Global.MensajeFault("El campo número de documento no debe estar vacío.");
                    return;
                }

                Decimal MontoTmp = Convert.ToDecimal(txtMontoRec.Text);

                if (MontoTmp.ToString("N2") == "0.00")
                {
                    Global.MensajeFault("Debe existir un Monto Recibido");
                    return;
                }

                MontoTmp = Convert.ToDecimal(txtMonto.Text);

                if (MontoTmp.ToString("N2") == "0.00")
                {
                    Global.MensajeFault("Debe existir un Monto ");
                    return;
                }

                MontoTmp = Convert.ToDecimal(txtTica.Text);

                if (MontoTmp.ToString("N3") == "0.000")
                {
                    Global.MensajeFault("Debe existir un Tipo De Cambio");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmCancelaciones_Load(object sender, EventArgs e)
        {
            Nuevo();
            SumaTotales(ListaCancelaciones);
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancos.SelectedValue != null && cboMonedas.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancos.SelectedValue), cboMonedas.SelectedValue.ToString());
                }

                Calcular();
            }
            catch (DivideByZeroException ex0)
            {
                Global.MensajeFault(ex0.Message);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboBancos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancos.SelectedValue != null && cboMonedas.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancos.SelectedValue), cboMonedas.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal Diferencia = 0;
                Decimal.TryParse(txtMonto.Text, out decimal Monto);
                Decimal.TryParse(txtMontoRec.Text, out decimal MontoRec);

                if (cboMedioPago.SelectedValue == null)
                {
                    Global.MensajeComunicacion("No existen Medios de Pago, debe ingresarlos.");
                    return;
                }

                if (MontoRec == 0)
                {
                    Global.MensajeComunicacion("El monto recibido no puede ser 0.00.");
                    return;
                }

                if (txtMonedaDocu.Tag.ToString() == cboMonedas.SelectedValue.ToString())
                {
                    if (MontoRec > Monto)
                    {
                        Global.MensajeComunicacion("El monto recibido no puede pasar el total del documento.");
                        return;
                    }

                    if (Monto > MontoRec)
                    {
                        Diferencia = Monto - MontoRec;
                    }
                }

                if (cboCuentasBancarias.SelectedValue == null)
                {
                    Global.MensajeComunicacion("Debe escoger un Banco con cuentas bancarias.");
                    return;
                }

                EmisionDocumentoCancelacionE oCancelacion = new EmisionDocumentoCancelacionE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    idDocumento = txtIdDocumento.Text,
                    numSerie = txtSerie.Text,
                    numDocumento = txtNumero.Text,
                    //Fecha = Convert.ToDateTime(txtFecha.Text), //Por revisar
                    idMonedaDocum = txtMonedaDocu.Tag.ToString(),
                    desMonedaDocu = txtMonedaDocu.Text,
                    tipCambio = Convert.ToDecimal(txtTica.Text),
                    idMedioPago = Convert.ToInt32(cboMedioPago.SelectedValue),
                    desMedioPago = ((MedioPagoE)cboMedioPago.SelectedItem).Nombre,
                    idDocumentoReci = cboDocumentoRec.SelectedValue.ToString(),
                    numSerieReci = txtSerieRec.Text.Trim(),
                    numDocumentoReci = txtNumRec.Text.Trim(),
                    idMonedaRecibida = cboMonedas.SelectedValue.ToString(),
                    desMonedaRec = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura,
                    MontoRecibido = Convert.ToDecimal(txtMontoRec.Text),
                    MontoAplicar = Convert.ToDecimal(txtMonto.Text),
                    Vuelto = Diferencia,
                    idBanco = Convert.ToInt32(cboBancos.SelectedValue),
                    desBanco = ((BancosE)cboBancos.SelectedItem).RazonSocial,
                    numCuentaBanco = cboCuentasBancarias.SelectedValue.ToString(),
                    fecAbono = dtpFecAbono.Value.ToString("yyyyMMdd"),
                    VariosCobros = chkCobranza.Checked,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                ListaCancelaciones.Add(oCancelacion);
                bsBase.DataSource = ListaCancelaciones;
                bsBase.ResetBindings(false);
                SumaTotales(ListaCancelaciones);

                if (ListaCancelaciones.Count > 0)
                {
                    btAceptar.Enabled = true;
                }
                else
                {
                    btAceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsBase.Current != null && bsBase.List.Count > 0)
                {
                    ListaCancelaciones.RemoveAt(bsBase.Position);
                    bsBase.DataSource = ListaCancelaciones;
                    bsBase.ResetBindings(false);
                    SumaTotales(ListaCancelaciones);
                }

                if (ListaCancelaciones.Count == 0)
                {
                    btAceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (DivideByZeroException ex0)
            {
                Global.MensajeFault(ex0.Message);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtTica_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (DivideByZeroException ex0)
            {
                Global.MensajeFault(ex0.Message);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            Global.FormatoDecimal(txtMonto.Text);
        }

        private void txtTica_Leave(object sender, EventArgs e)
        {
            Global.FormatoDecimal(txtTica.Text, 3);
        }

        private void txtMontoRec_Leave(object sender, EventArgs e)
        {
            Global.FormatoDecimal(txtMontoRec.Text);
        }

        private void txtMontoRec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTiCa();
            }
            catch (DivideByZeroException ex0)
            {
                Global.MensajeFault(ex0.Message);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
