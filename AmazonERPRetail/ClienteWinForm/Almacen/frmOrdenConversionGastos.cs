using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenConversionGastos : frmResponseBase
    {

        #region Constructores

        public frmOrdenConversionGastos()
        {
            InitializeComponent();

            LlenarCombos();
        }

        //Edición
        public frmOrdenConversionGastos(OrdenConversionGastosE orden)
            :this()
        {
            oGastoConversion = orden;
        } 

        #endregion

        #region Variables

        public OrdenConversionGastosE oGastoConversion = null;
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             where x.idMoneda == "01" || x.idMoneda == "02"
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda");
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral where x.indBaja == false select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   where (x.indDocumentoCompras == true || x.idDocumento == "0")
                                                                   && x.indBaja == false
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento");
        }

        void BuscarTiCa()
        {
            DateTime Fecha = dtpFecha.Value.Date;
            TipoCambioE Tica = VariablesLocales.RetornaTipoCambio("02", Fecha);

            if (Tica != null)
            {
                txtTipCambio.Text = Tica.valVenta.ToString("N3");
            }
            else
            {
                txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
            }
        }

        void CalcularMontos()
        {
            
            Decimal.TryParse(txtTipCambio.Text, out Decimal Tica);
            Decimal MontoTotal = 0;

            if (!String.IsNullOrWhiteSpace(txtMonto.Text))
            {
                if (cboMoneda.SelectedValue.ToString() == "01")
                {
                    Decimal.TryParse(txtMonto.Text, out Decimal Monto);

                    MontoTotal = Math.Round(Monto / Tica, 2);
                    txtMontoDolares.Text = MontoTotal.ToString("N2");
                }
                else
                {
                    Decimal.TryParse(txtMontoDolares.Text, out Decimal Monto);

                    MontoTotal = Math.Round(Monto * Tica, 2);
                    txtMonto.Text = txtMonto.Text;
                }
            }
        }

        void Datos()
        {
            oGastoConversion.Descripcion = txtDescipcion.Text.Trim();
            oGastoConversion.idPersona = Convert.ToInt32(txtRuc.Tag) != 0 ? Convert.ToInt32(txtRuc.Tag) : (Int32?)null;
            oGastoConversion.Ruc = txtRuc.Text;
            oGastoConversion.RazonSocial = txtRazonSocial.Text.Trim();
            oGastoConversion.Fecha = dtpFecha.Value.Date;
            oGastoConversion.idDocumento = cboDocumento.SelectedValue.ToString();
            oGastoConversion.serDocumento = txtSerie.Text;
            oGastoConversion.numDocumento = txtNumDoc.Text;
            oGastoConversion.TipoCambio = Convert.ToDecimal(txtTipCambio.Text);
            oGastoConversion.idMoneda = cboMoneda.SelectedValue.ToString();
            oGastoConversion.DesMoneda = ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
            oGastoConversion.Monto = Convert.ToDecimal(txtMonto.Text);
            oGastoConversion.MontoDolares = Convert.ToDecimal(txtMontoDolares.Text);
            oGastoConversion.DistribuirItem = chkItem.Checked;
            oGastoConversion.ItemADistribuir = txtItemADis.Text.Trim();

            if (oGastoConversion.Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oGastoConversion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oGastoConversion.FechaRegistro = VariablesLocales.FechaHoy;
                oGastoConversion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oGastoConversion.FechaModificacion = VariablesLocales.FechaHoy;
            }
            else
            {
                oGastoConversion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oGastoConversion.FechaModificacion = VariablesLocales.FechaHoy;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oGastoConversion == null)
            {
                oGastoConversion = new OrdenConversionGastosE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    Opcion = (Int32)EnumOpcionGrabar.Insertar
                };

                txtRuc.Tag = 0;
                txtUsuarioRegistro.Text = txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (oGastoConversion.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                {
                    oGastoConversion.Opcion = (Int32)EnumOpcionGrabar.Actualizar; 
                }

                txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                dtpFecha.ValueChanged -= new EventHandler(dtpFecha_ValueChanged);
                txtMonto.TextChanged -= new EventHandler(txtMonto_TextChanged);
                txtMontoDolares.TextChanged -= new EventHandler(txtMontoDolares_TextChanged);

                txtDescipcion.Text = oGastoConversion.Descripcion;
                txtRuc.Text = oGastoConversion.Ruc;
                txtRazonSocial.Text = oGastoConversion.RazonSocial;
                cboDocumento.SelectedValue = oGastoConversion.idDocumento;
                txtSerie.Text = oGastoConversion.serDocumento;
                txtNumDoc.Text = oGastoConversion.numDocumento;
                dtpFecha.Value = oGastoConversion.Fecha;
                cboMoneda.SelectedValue = oGastoConversion.idMoneda.ToString();
                txtTipCambio.Text = oGastoConversion.TipoCambio.ToString("N3");
                txtMonto.Text = oGastoConversion.Monto.ToString("N2");
                txtMontoDolares.Text = oGastoConversion.MontoDolares.ToString("N2");
                chkItem.Checked = oGastoConversion.DistribuirItem;
                chkItem_CheckedChanged(null, null);
                txtItemADis.Text = oGastoConversion.ItemADistribuir;

                txtUsuarioRegistro.Text = oGastoConversion.UsuarioRegistro;
                txtFechaRegistro.Text = oGastoConversion.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oGastoConversion.UsuarioModificacion;
                txtFechaModificacion.Text = oGastoConversion.FechaModificacion.ToString();

                txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                dtpFecha.ValueChanged += new EventHandler(dtpFecha_ValueChanged);
                txtMonto.TextChanged += new EventHandler(txtMonto_TextChanged);
                txtMontoDolares.TextChanged += new EventHandler(txtMontoDolares_TextChanged);
            }

            base.Nuevo();
        }

        public override bool ValidarGrabacion()
        {
            if (txtTipCambio.Text == "0.000" || String.IsNullOrWhiteSpace(txtTipCambio.Text))
            {
                Global.MensajeAdvertencia("Debe ingresar un fecha que tenga Tipo de Cambio.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void Aceptar()
        {
            Datos();

            if (ValidarGrabacion())
            {
                base.Aceptar();
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenConversionGastos_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                    txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
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
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("La razón social ingresada no existe");
                    }

                    txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                    txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                    txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
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
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                    txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarTiCa();

                if (txtTipCambio.Text == "0.000")
                {
                    dtpFecha.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItem.Checked)
            {
                txtItemADis.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtItemADis.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CalcularMontos();
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
                CalcularMontos();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMontoDolares_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularMontos();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtSerie.TextLength < txtSerie.MaxLength && Global.EsNumero(txtSerie.Text))
                    {
                        txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
                    }
                }
            }
        }

        private void txtNumDoc_Leave(object sender, EventArgs e)
        {
            if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtNumDoc.TextLength < txtNumDoc.MaxLength && Global.EsNumero(txtNumDoc.Text))
                    {
                        txtNumDoc.Text = txtNumDoc.Text.PadLeft(8, '0');
                    }
                }
            }
        } 

        #endregion

    }
}
