using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmMovFinanciamiento : FrmMantenimientoBase
    {

        #region Constructores

        public frmMovFinanciamiento()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        //Nuevo
        public frmMovFinanciamiento(List<TipoLineaCreditoE> oListLineas_, List<MovimientoFinanciamientoE> oListaMov)
            : this()
        {
            oListaLineas = oListLineas_;
            oListaMovTmp = oListaMov;
        }

        //Edicion
        public frmMovFinanciamiento(Int32 idMovimiento, List<TipoLineaCreditoE> oListLineas_, List<MovimientoFinanciamientoE> oListaMov)
            : this()
        {
            oMovFinanciamiento = AgenteTesoreria.Proxy.ObtenerMovFinanciamientoCompleto(idMovimiento);
            oListaLineas = oListLineas_;

            Text = "Movimiento Financiero(" + oMovFinanciamiento.codMovimiento + ")";
            oListaMovTmp = oListaMov;

            oListaMovTmp.Remove(oListaMov.Where(x => x.idMovimiento == idMovimiento).SingleOrDefault());
        }
        
        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MovimientoFinanciamientoE oMovFinanciamiento = null;
        List<MovimientoFinanciamientoE> oListaMovTmp = null; //Para saber si pasa el crédito asignado...
        List<TipoLineaCreditoE> oListaLineas = null;
        List<FinanciamientoE> oListaFinanciamiento = null;
        String BuscarCombos = "S";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            oListaLineas = AgenteTesoreria.Proxy.ListarTipoLineaCredito(false);
            TipoLineaCreditoE LineaIni = new TipoLineaCreditoE() { idLinea = 0, desCorta = "<Selec.>" };
            oListaLineas.Add(LineaIni);
            ComboHelper.RellenarCombos<TipoLineaCreditoE>(cboLineaCredito, (from x in oListaLineas orderby x.idLinea select x).ToList(), "idLinea", "desCorta");

            List<ParTabla> oListaPeriodicidad = AgenteGeneral.Proxy.ListarParTablaPorNemo("PERIO");
            ComboHelper.RellenarCombos<ParTabla>(cboPeriodicidad, (from x in oListaPeriodicidad orderby x.IdParTabla select x).ToList());
        }

        void Registros()
        {
            oMovFinanciamiento.codMovimiento = txtCodMov.Text.Trim();
            oMovFinanciamiento.idFinanciamiento = Convert.ToInt32(txtIdFinanciamiento.Text);
            oMovFinanciamiento.idLinea = Convert.ToInt32(cboLineaCredito.SelectedValue);
            oMovFinanciamiento.fecEmision = dtpFecha.Value.Date;
            oMovFinanciamiento.fecVencimiento = dtpVencimiento.Value.Date;
            oMovFinanciamiento.nroCuenta = cboCuentasBancarias.SelectedValue.ToString();
            oMovFinanciamiento.idMoneda = cboMonedas.SelectedValue.ToString();
            oMovFinanciamiento.impSolicitado = Convert.ToDecimal(txtImporSol.Text);
            oMovFinanciamiento.nroDocumento = txtNumDocumento.Text.Trim();
            oMovFinanciamiento.ComisionDesem = Convert.ToDecimal(txtComision.Text);
            oMovFinanciamiento.ComisionVar = Convert.ToDecimal(txtComisionVarios.Text);
            oMovFinanciamiento.Periodicidad = Convert.ToInt32(cboPeriodicidad.SelectedValue);
            oMovFinanciamiento.Portes = Convert.ToDecimal(txtPortes.Text);
            oMovFinanciamiento.segDesgravamen = Convert.ToDecimal(txtDesgravamen.Text);
            oMovFinanciamiento.porTea = Convert.ToDecimal(txtTea.Text);
            oMovFinanciamiento.Plazo = Convert.ToInt32(txtPlazo.Text);
            oMovFinanciamiento.nroCuotas = Convert.ToInt32(txtCuotas.Text);
            oMovFinanciamiento.impDesembolso = Convert.ToDecimal(txtImporDesem.Text);
            oMovFinanciamiento.CuotaPago = Convert.ToDecimal(txtCuotaPago.Text);
            oMovFinanciamiento.MontoCredito = Convert.ToDecimal(txtImporteCred.Text);

            if (String.IsNullOrWhiteSpace(oMovFinanciamiento.codMovimiento))
            {
                oMovFinanciamiento.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oMovFinanciamiento.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void ListarFinanciamiento(Int32 idEmpresa, Int32 idBanco, Int32 idLinea)
        {
            oListaFinanciamiento = AgenteTesoreria.Proxy.ListarFinanciamiento(idEmpresa, idBanco, idLinea, false);
        }

        FinanciamientoE ObtenerFinanciamiento(Int32 idEmpresa, Int32 idBanco, Int32 idLinea, String idMoneda)
        {
            FinanciamientoE oFinanza = null;

            if (oListaFinanciamiento.Count > 0)
            {
                oFinanza = oListaFinanciamiento.Find
                (
                    delegate (FinanciamientoE x)
                    {
                        return x.idEmpresa == idEmpresa && x.idBanco == idBanco && x.idLinea == idLinea && x.idMoneda == idMoneda;
                    }
                );
            }

            return oFinanza;
        }

        List<MovimientoFinanciamientoE> ListarCtasBancarias(Int32 idBanco, Int32 idEmpresa, String idMoneda)
        {
            return AgenteTesoreria.Proxy.ListarMovFinCuentasBan(idBanco, idEmpresa, idMoneda);
        }

        void ImporteDesembolsado()
        {
            Decimal ImporteSol = 0;
            Decimal Comision1 = 0;
            Decimal Comision2 = 0;
            Decimal Portes = 0;
            Decimal Desembolsado = 0;

            Decimal.TryParse(txtImporSol.Text, out ImporteSol);
            Decimal.TryParse(txtComision.Text, out Comision1);
            Decimal.TryParse(txtComisionVarios.Text, out Comision2);
            Decimal.TryParse(txtPortes.Text, out Portes);

            Desembolsado = ImporteSol - Comision1 -Comision2 - Portes;
            txtImporDesem.Text = Desembolsado.ToString("N2");
        }

        void CuotaPago()
        {
            Decimal ImporteSol = 0;
            Decimal Tea = 0;
            Decimal Plazo = 0;
            Decimal Cuota = 0;

            Decimal.TryParse(txtImporSol.Text, out ImporteSol);
            Decimal.TryParse(txtTea.Text, out Tea);
            Decimal.TryParse(txtPlazo.Text, out Plazo);

            Cuota = ImporteSol * Convert.ToDecimal((Math.Pow(Convert.ToDouble(1 + (Tea / 100)), Convert.ToDouble(Plazo / 360))));
            txtCuotaPago.Text = Cuota.ToString("N2");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oMovFinanciamiento == null)
                {
                    oMovFinanciamiento = new MovimientoFinanciamientoE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                    };

                    txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();
                }
                else
                {
                    txtImporSol.TextChanged -= txtImporSol_TextChanged;
                    txtComision.TextChanged -= txtComision_TextChanged;
                    txtPortes.TextChanged -= txtPortes_TextChanged;
                    txtComisionVarios.TextChanged -= txtComisionVarios_TextChanged;
                    txtTea.TextChanged -= txtTea_TextChanged;
                    txtPlazo.TextChanged -= txtPlazo_TextChanged;
                    BuscarCombos = "N";

                    txtIdFinanciamiento.Text = oMovFinanciamiento.idFinanciamiento.ToString();
                    cboLineaCredito.SelectedValue = Convert.ToInt32(oMovFinanciamiento.idLinea);
                    cboLineaCredito_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboBancosEmpresa.SelectedValue = Convert.ToInt32(oMovFinanciamiento.idBanco);
                    cboBancosEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboMonedas.SelectedValue = oMovFinanciamiento.idMoneda.ToString();
                    cboMonedas_SelectionChangeCommitted(new object(), new EventArgs());
                    cboCuentasBancarias.SelectedValue = oMovFinanciamiento.nroCuenta.ToString();
                    txtNumDocumento.Text = oMovFinanciamiento.nroDocumento;
                    txtCodMov.Text = oMovFinanciamiento.codMovimiento;
                    dtpFecha.Value = oMovFinanciamiento.fecEmision;
                    dtpVencimiento.Value = Convert.ToDateTime(oMovFinanciamiento.fecVencimiento);
                    txtImporSol.Text = oMovFinanciamiento.impSolicitado.ToString("N2");
                    txtComision.Text = oMovFinanciamiento.ComisionDesem.ToString("N2");
                    txtComisionVarios.Text = oMovFinanciamiento.ComisionVar.ToString("N2");
                    cboPeriodicidad.SelectedValue = Convert.ToInt32(oMovFinanciamiento.Periodicidad);
                    txtPortes.Text = oMovFinanciamiento.Portes.ToString("N2");
                    txtDesgravamen.Text = oMovFinanciamiento.segDesgravamen.ToString("N2");
                    txtTea.Text = oMovFinanciamiento.porTea.ToString("N2");
                    txtPlazo.Text = oMovFinanciamiento.Plazo.ToString();
                    txtCuotas.Text = oMovFinanciamiento.nroCuotas.ToString();
                    txtImporDesem.Text = oMovFinanciamiento.impDesembolso.ToString("N2");
                    txtCuotaPago.Text = oMovFinanciamiento.CuotaPago.ToString("N2");
                    txtImporteCred.Text = oMovFinanciamiento.MontoCredito.ToString("N2");

                    txtUsuRegistra.Text = oMovFinanciamiento.UsuarioRegistro;
                    txtUsuModifica.Text = oMovFinanciamiento.UsuarioModificacion;
                    txtFechaRegistro.Text = oMovFinanciamiento.FechaRegistro.ToString();
                    txtFechaModifica.Text = oMovFinanciamiento.FechaModificacion.ToString();

                    BuscarCombos = "S";
                    txtImporSol.TextChanged += txtImporSol_TextChanged;
                    txtComision.TextChanged -= txtComision_TextChanged;
                    txtPortes.TextChanged += txtPortes_TextChanged;
                    txtComisionVarios.TextChanged += txtComisionVarios_TextChanged;
                    txtTea.TextChanged += txtTea_TextChanged;
                    txtPlazo.TextChanged += txtPlazo_TextChanged;
                }

                base.Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
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
                Registros();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtCodMov.Text.Trim()))
                {
                    if (Global.MensajeConfirmacion("Desea grabar el movimiento...?") == DialogResult.Yes)
                    {
                        oMovFinanciamiento = AgenteTesoreria.Proxy.GrabarMovimientoFinanciamiento(oMovFinanciamiento, EnumOpcionGrabar.Insertar);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion("Desea actualizar el movimiento...?") == DialogResult.Yes)
                    {
                        oMovFinanciamiento = AgenteTesoreria.Proxy.GrabarMovimientoFinanciamiento(oMovFinanciamiento, EnumOpcionGrabar.Actualizar);
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

        public override bool ValidarGrabacion()
        {
            if (Convert.ToInt32(cboLineaCredito.SelectedValue) == 0)
            {
                Global.MensajeComunicacion("Debe escoger un Tipo de Linea de Crédito.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtNumDocumento.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe colocar un Nro. de documento");
                txtNumDocumento.Focus();
                return false;
            }

            if (cboBancosEmpresa.SelectedValue == null)
            {
                Global.MensajeComunicacion("Debe escoger una Entidad Bancaria.");
                return false;
            }

            if (cboMonedas.SelectedValue == null)
            {
                Global.MensajeComunicacion("Debe escoger un tipo de moneda.");
                return false;
            }

            if (cboCuentasBancarias.SelectedValue == null)
            {
                Global.MensajeComunicacion("Debe escoger un Nro. de Cuenta Bancaria.");
                return false;
            }

            if (oListaMovTmp != null && oListaMovTmp.Count > 0)
            {
                Decimal ImporteCredito = Convert.ToDecimal(txtImporteCred.Text);
                Decimal ImporteSol = Convert.ToDecimal(txtImporSol.Text);

                var agrupado = oListaMovTmp.GroupBy(x => new { x.idFinanciamiento }).Select(group =>
                                                                    new { group.Key, MontoTotal = group.Sum(x => x.impSolicitado) });

                foreach (var item in agrupado.ToList())
                {
                    if (item.Key.idFinanciamiento == Convert.ToInt32(txtIdFinanciamiento.Text))
                    {
                        if ((item.MontoTotal + ImporteSol) > ImporteCredito)
                        {
                            Global.MensajeFault("Ha sobrepasado el limite del crédito.");
                            return false;
                        }
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmMovFinanciamiento_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                lblFin.Visible = true;
                txtIdFinanciamiento.Visible = true;
            }
        }

        private void btCronograma_Click(object sender, EventArgs e)
        {
            try
            {
                frmMovFinanciamientoDet oFrm = null;

                if (oMovFinanciamiento.oListaMovimientos.Count == 0)
                {
                    MovimientoFinanciamientoDetE oMovimientoDet = new MovimientoFinanciamientoDetE();
                    oMovimientoDet.DeudaCapital = Convert.ToDecimal(txtImporSol.Text);
                    oMovimientoDet.Tea = Convert.ToDecimal(txtTea.Text);
                    oMovimientoDet.Tem = Convert.ToDecimal((Math.Pow(Convert.ToDouble(1 + (oMovimientoDet.Tea / 100)), Convert.ToDouble(1M / 12M)) - 1) * 100);
                    oMovimientoDet.Cuotas = Convert.ToInt32(txtCuotas.Text);
                    oMovimientoDet.AumentoDias = ((ParTabla)cboPeriodicidad.SelectedItem).ValorEntero;
                    oMovimientoDet.fecVenc = dtpFecha.Value.Date.AddDays(((ParTabla)cboPeriodicidad.SelectedItem).ValorEntero);
                    oMovimientoDet.Comision = Convert.ToDecimal(txtComisionVarios.Text);

                    TimeSpan diff = oMovimientoDet.fecVenc.Date - dtpFecha.Value.Date;
                    oMovimientoDet.DiasCuota = diff.Days;

                    oFrm = new frmMovFinanciamientoDet(oMovimientoDet); 
                }
                else
                {
                    oFrm = new frmMovFinanciamientoDet(oMovFinanciamiento.oListaMovimientos);
                }

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaMovimientos.Count > 0)
                {
                    oMovFinanciamiento.oListaMovimientos = new List<MovimientoFinanciamientoDetE>(oFrm.oListaMovimientos);
                    txtCuotaPago.Text = oMovFinanciamiento.oListaMovimientos[0].ValorCuota.ToString("N2");
                    dtpVencimiento.Value = Convert.ToDateTime((from x in oMovFinanciamiento.oListaMovimientos
                                            select (DateTime?)x.fecVenc).Max());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLineaCredito_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtImporSol_Leave(object sender, EventArgs e)
        {
            txtImporSol.Text = Global.FormatoDecimal(txtImporSol.Text);
        }

        private void txtComision_Leave(object sender, EventArgs e)
        {
            txtComision.Text = Global.FormatoDecimal(txtComision.Text);
        }

        private void txtPortes_Leave(object sender, EventArgs e)
        {
            txtPortes.Text = Global.FormatoDecimal(txtPortes.Text);
        }

        private void txtDesgravamen_Leave(object sender, EventArgs e)
        {
            txtDesgravamen.Text = Global.FormatoDecimal(txtDesgravamen.Text);
        }

        private void txtImporDesem_Leave(object sender, EventArgs e)
        {
            txtImporDesem.Text = Global.FormatoDecimal(txtImporDesem.Text);
        }

        private void txtCuotaPago_Leave(object sender, EventArgs e)
        {
            txtCuotaPago.Text = Global.FormatoDecimal(txtCuotaPago.Text);
        }

        private void dtpVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboLineaCredito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<FinanciamientoE> oListaBancos = AgenteTesoreria.Proxy.ListarBancosFinanPorLinea(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboLineaCredito.SelectedValue));
                ComboHelper.RellenarCombos<FinanciamientoE>(cboBancosEmpresa, (from x in oListaBancos orderby x.idBanco select x).ToList(), "idBanco", "desBanco");

                if (oListaBancos.Count > 0)
                {
                    cboBancosEmpresa.Enabled = true;
                }
                else
                {
                    cboBancosEmpresa.DataSource = null;
                    cboBancosEmpresa.Enabled = false;
                }

                oListaBancos = null;

                if (BuscarCombos == "S")
                {
                    cboBancosEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());
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
                if (cboBancosEmpresa.SelectedValue != null)
                {
                    ListarFinanciamiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboBancosEmpresa.SelectedValue), Convert.ToInt32(cboLineaCredito.SelectedValue));

                    if (oListaFinanciamiento.Count > 0)
                    {
                        cboMonedas.Enabled = true;
                        ComboHelper.RellenarCombos<FinanciamientoE>(cboMonedas, (from x in oListaFinanciamiento orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");
                    }
                    else
                    {
                        cboMonedas.DataSource = null;
                        cboMonedas.Enabled = false;
                    }
                }
                else
                {
                    cboMonedas.DataSource = null;
                    cboMonedas.Enabled = false;
                }

                if (BuscarCombos == "S")
                {
                    cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());
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
                if (cboMonedas.SelectedValue != null)
                {
                    if (BuscarCombos == "S")
                    {
                        FinanciamientoE oFinanza = ObtenerFinanciamiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboBancosEmpresa.SelectedValue),
                                                                                    Convert.ToInt32(cboLineaCredito.SelectedValue), cboMonedas.SelectedValue.ToString());

                        if (oFinanza != null)
                        {
                            txtIdFinanciamiento.Text = oFinanza.idFinanciamiento.ToString();
                            txtTea.Text = oFinanza.Tea.ToString("N2");
                            txtPlazo.Text = oFinanza.Plazo.ToString();
                            txtImporteCred.Text = oFinanza.Importe.ToString("N2");

                            oFinanza = null;
                        }
                    }

                    if (cboBancosEmpresa.SelectedValue != null)
                    {
                        List<MovimientoFinanciamientoE> oListaCuentas = ListarCtasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue),
                                                                                            VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                            cboMonedas.SelectedValue.ToString());
                        if (oListaCuentas.Count > 0)
                        {
                            cboCuentasBancarias.Enabled = true;
                            ComboHelper.RellenarCombos<MovimientoFinanciamientoE>(cboCuentasBancarias, oListaCuentas, "nroCuenta", "desCtaBanco");
                        }
                        else
                        {
                            cboCuentasBancarias.Enabled = false;
                            cboCuentasBancarias.DataSource = null;
                        }

                        oListaCuentas = null;
                    }
                }
                else
                {
                    txtIdFinanciamiento.Text = "0";
                    txtTea.Text = "0.00";
                    txtPlazo.Text = "0";
                    cboCuentasBancarias.Enabled = false;
                    cboCuentasBancarias.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtComisionVarios_Leave(object sender, EventArgs e)
        {
            txtComisionVarios.Text = Global.FormatoDecimal(txtComisionVarios.Text);
        }

        private void txtCuotas_TextChanged(object sender, EventArgs e)
        {
            Int32 Cuotas = 0;
            Int32.TryParse(txtCuotas.Text, out Cuotas);
            btCronograma.Enabled = Cuotas > 1;
        }

        private void txtImporSol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImporteDesembolsado();
                CuotaPago();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtComision_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImporteDesembolsado();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPortes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImporteDesembolsado();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtComisionVarios_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImporteDesembolsado();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtTea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CuotaPago();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPlazo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CuotaPago();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboPeriodicidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtTea_Leave(object sender, EventArgs e)
        {
            txtTea.Text = Global.FormatoDecimal(txtTea.Text);
        }

        #endregion

    }
}
