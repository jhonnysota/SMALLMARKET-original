using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Generales
{
    public partial class frmTipoCambio : FrmMantenimientoBase
    {

        public frmTipoCambio()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvTipoCambio, true);
            LlenarCombos();
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        TipoCambioE ETica = null;
        int Opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            List<MonedasE> ListarMonedas = AgenteGeneral.Proxy.ListarMonedas();
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, ListarMonedas, "idMoneda", "desMoneda", false);
            cboMonedas.SelectedValue = "02";
        }

        private void BuscarTicaSunat()
        {
            frmTipoCambioSunat oFrm = new frmTipoCambioSunat(false)
            {
                Periodo = Global.PrimeraMayuscula(FechasHelper.NombreMes(DateTime.Now.Month)) + " - " + DateTime.Today.ToString("yyyy"),
                MesConsulta = DateTime.Now.Month,
                AnioConsulta = DateTime.Now.Year
            };

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.ETicCa != null)
            {
                txtCompra.Text = oFrm.ETicCa.valCompra.ToString("##0.000");
                txtVenta.Text = oFrm.ETicCa.valVenta.ToString("##0.000");
                dtpFecCambio.Value = Convert.ToDateTime(oFrm.ETicCa.fecCambio.Insert(6, "-").Insert(4, "-")); //oFrm.ETicCa.fecCambio;
            }
        }

        private void Datos()
        {
            ETica.fecCambio = dtpFecCambio.Value.ToString("yyyyMMdd");
            decimal.TryParse(txtCompra.Text, out decimal compra);
            decimal.TryParse(txtVenta.Text, out decimal venta);
            decimal.TryParse(txtCompraCaja.Text, out decimal compracaja);
            decimal.TryParse(txtVentaCaja.Text, out decimal ventacaja);
            ETica.valCompra = compra;
            ETica.valVenta = venta;
            ETica.valCompraCaja = compracaja;
            ETica.valVentaCaja = ventacaja;

            if (Opcion == (int)EnumOpcionGrabar.Insertar)
            {
                ETica.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                ETica.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                ETica = new TipoCambioE
                {
                    idMoneda = cboMonedas.SelectedValue.ToString()
                };

                dgvTipoCambio.Enabled = false;
                panel2.Enabled = true;
                btBuscar.Enabled = true;
                btSbs.Enabled = true;
                dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
                txtCompra.Text = "0.000";
                txtVenta.Text = "0.000";
                txtCompraCaja.Text = "0.000";
                txtVentaCaja.Text = "0.000";

                base.Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, true);
                BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);

                Opcion = (int)EnumOpcionGrabar.Insertar;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                bsTipoCambio.DataSource = AgenteGeneral.Proxy.ListarTipoCambioPorFechas(cboMonedas.SelectedValue.ToString(), dtpInicio.Value.ToString("yyyyMMdd"), dtpFin.Value.ToString("yyyyMMdd"));
                lblRegistros.Text = "Registros " + bsTipoCambio.Count.ToString();
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
                if (bFlag)
                {
                    Datos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (ETica.idCambio == 0)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            ETica = AgenteGeneral.Proxy.InsertarTipoCambio(ETica);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);

                            if (ETica.fecCambio.Insert(6, "-").Insert(4, "-") == VariablesLocales.FechaHoy.ToString("yyyy-MM-dd"))
                            {
                                VariablesLocales.TipoCambioDelDia = ETica;
                            }
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            ETica = AgenteGeneral.Proxy.ActualizarTipoCambio(ETica);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);

                            if (ETica.fecCambio.Insert(6, "-").Insert(4, "-") == VariablesLocales.FechaHoy.ToString("yyyy-MM-dd"))
                            {
                                VariablesLocales.TipoCambioDelDia = ETica;
                            }
                        }
                    }

                    bFlag = false;
                    dgvTipoCambio.Enabled = true;
                    panel2.Enabled = false;
                    Buscar();
                    btBuscar.Enabled = false;
                    btSbs.Enabled = false;
                    panel1.Focus();

                    base.Grabar();
                    BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (dgvTipoCambio.CurrentRow != null)
                {
                    ETica = (TipoCambioE)bsTipoCambio.Current;
                    dgvTipoCambio.Enabled = false;
                    panel2.Enabled = true;
                    btBuscar.Enabled = true;
                    btSbs.Enabled = true;

                    base.Editar();
                    BloquearOpcion(EnumOpcionMenuBarra.Cancelar, true);
                    BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);
                    Opcion = (int)EnumOpcionGrabar.Actualizar;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Cancelar()
        {
            dgvTipoCambio.Enabled = true;
            panel2.Enabled = false;
            btBuscar.Enabled = false;
            btSbs.Enabled = false;

            base.Cancelar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
        }

        public override bool ValidarGrabacion()
        {
            String resultado = ValidarEntidad<TipoCambioE>(ETica);

            if (!String.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmTipoCambio_Load(object sender, EventArgs e)
        {
            Grid = false;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarTicaSunat();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void bsTipoCambio_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsTipoCambio.Current != null)
                {
                    dtpFecCambio.Value = Convert.ToDateTime(((TipoCambioE)bsTipoCambio.Current).fecCambio);
                    txtCompra.Text = ((TipoCambioE)bsTipoCambio.Current).valCompra.ToString("##0.000");
                    txtVenta.Text = ((TipoCambioE)bsTipoCambio.Current).valVenta.ToString("##0.000");
                    txtCompraCaja.Text = ((TipoCambioE)bsTipoCambio.Current).valCompraCaja.ToString("##0.000");
                    txtVentaCaja.Text = ((TipoCambioE)bsTipoCambio.Current).valVentaCaja.ToString("##0.000");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvTipoCambio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (bsTipoCambio.Count > Variables.Cero)
            {
                bsTipoCambio.DataSource = null;
            }
        }

        private void txtCompraCaja_Enter(object sender, EventArgs e)
        {
            txtCompraCaja.SelectAll();
        }

        private void txtCompraCaja_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCompraCaja.Text.Trim()))
            {
                txtCompraCaja.Text = Convert.ToDecimal(txtCompraCaja.Text).ToString("##0.000");
            }
        }

        private void txtCompraCaja_MouseClick(object sender, MouseEventArgs e)
        {
            txtCompraCaja.SelectAll();
        }

        private void txtVentaCaja_Enter(object sender, EventArgs e)
        {
            txtVentaCaja.SelectAll();
        }

        private void txtVentaCaja_MouseClick(object sender, MouseEventArgs e)
        {
            txtVentaCaja.SelectAll();
        }

        private void txtVentaCaja_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtVentaCaja.Text.Trim()))
            {
                txtVentaCaja.Text = Convert.ToDecimal(txtVentaCaja.Text).ToString("##0.000");
            }
        }

        private void txtCompra_Enter(object sender, EventArgs e)
        {
            txtCompra.SelectAll();
        }

        private void txtCompra_MouseClick(object sender, MouseEventArgs e)
        {
            txtCompra.SelectAll();
        }

        private void txtCompra_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCompra.Text.Trim()))
            {
                txtCompra.Text = Convert.ToDecimal(txtCompra.Text).ToString("##0.000");
            }
        }

        private void txtVenta_Enter(object sender, EventArgs e)
        {
            txtVenta.SelectAll();
        }

        private void txtVenta_MouseClick(object sender, MouseEventArgs e)
        {
            txtVenta.SelectAll();
        }

        private void txtVenta_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtVenta.Text.Trim()))
            {
                txtVenta.Text = Convert.ToDecimal(txtVenta.Text).ToString("##0.000");
            }
        }

        #endregion

    }
}
