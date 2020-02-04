using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmTipoLineaCredito : FrmMantenimientoBase
    {

        #region Constructores

        public frmTipoLineaCredito()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        public frmTipoLineaCredito(Int32 idLinea)
            : this()
        {
            oLineaCredito = AgenteTesoreria.Proxy.ObtenerTipoLineaCredito(idLinea, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            Text = "Tipo Linea Crédito(N° " + oLineaCredito.idLinea +")";
        } 

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        TipoLineaCreditoE oLineaCredito = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                    where x.indBaja == false
                                                    select x).ToList();    
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");
        }

        void Registros()
        {
            oLineaCredito.Descripcion = txtDescripcion.Text.Trim();
            oLineaCredito.desCorta = txtDesCorta.Text.Trim();
            oLineaCredito.idDocumento = cboDocumento.SelectedValue.ToString();
            oLineaCredito.numVerPlanCuentas = txtVersionPlan.Text;
            oLineaCredito.codCuenta = txtCodCuenta.Text.Trim();
            oLineaCredito.desCuenta = txtDesCuenta.Text.Trim();
            oLineaCredito.idComprobante = cboLibro.SelectedValue == null ? "0" : cboLibro.SelectedValue.ToString();
            oLineaCredito.numFile = cboFile.SelectedValue == null ? "0" : cboFile.SelectedValue.ToString();

            if (String.IsNullOrWhiteSpace(txtIdLinea.Text.Trim()))
            {
                oLineaCredito.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oLineaCredito.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oLineaCredito == null)
            {
                oLineaCredito = new TipoLineaCreditoE();

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;

                txtIdLinea.Text = oLineaCredito.idLinea.ToString();
                txtDescripcion.Text = oLineaCredito.Descripcion;
                txtDesCorta.Text = oLineaCredito.desCorta;
                cboDocumento.SelectedValue = oLineaCredito.idDocumento.ToString();
                txtVersionPlan.Text = oLineaCredito.numVerPlanCuentas;
                txtCodCuenta.Text = oLineaCredito.codCuenta;
                txtDesCuenta.Text = oLineaCredito.desCuenta;
                cboLibro.SelectedValue = oLineaCredito.idComprobante.ToString();
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oLineaCredito.numFile.ToString();
                txtUsuRegistra.Text = oLineaCredito.UsuarioRegistro;
                txtRegistro.Text = oLineaCredito.FechaRegistro.ToString();
                txtUsuModifica.Text = oLineaCredito.UsuarioModificacion;
                txtModifica.Text = oLineaCredito.FechaModificacion.ToString();

                if (oLineaCredito.fecBaja != null)
                {
                    txtFecBaja.Text = oLineaCredito.fecBaja.ToString();
                }

                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
            }

            if (oLineaCredito.indEstado)
            {
                Height = 198;
                txtFecBaja.Visible = true;
                Global.MensajeComunicacion("No podrá hacer modificaciones.");
                pnlDatos.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                
            }
            else
            {
                base.Nuevo();
            }
        }

        public override void Grabar()
        {
            try
            {
                Registros();

                if (ValidarGrabacion())
                {
                    if (String.IsNullOrWhiteSpace(txtIdLinea.Text))
                    {
                        if (Global.MensajeConfirmacion("Se va a guardar el registro.") == DialogResult.Yes)
                        {
                            oLineaCredito = AgenteTesoreria.Proxy.InsertarTipoLineaCredito(oLineaCredito);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Se va a actualizar el registro.") == DialogResult.Yes)
                        {
                            oLineaCredito = AgenteTesoreria.Proxy.ActualizarTipoLineaCredito(oLineaCredito);
                        }
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe escoger una cuenta contable.");
                txtCodCuenta.Focus();
                return false;
            }

            if (cboLibro.SelectedValue.ToString() == "0")
            {
                Global.MensajeComunicacion("Debe escoger un libro contable.");
                cboLibro.Focus();
                return false;
            }

            if (cboFile.SelectedValue.ToString() == "0")
            {
                Global.MensajeComunicacion("Debe escoger un File.");
                cboFile.Focus();
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmTipoLineaCredito_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            txtDescripcion.Focus();
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFile.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = Variables.Cero.ToString();
                    }

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVersionPlan.Text = oFrm.oCuenta.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVersionPlan.Text = oListaCuentas[0].numVerPlanCuentas;
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtVersionPlan.Text = String.Empty;
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtVersionPlan.Text = String.Empty;
            txtDesCuenta.Text = String.Empty;
        }

        private void txtDesCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVersionPlan.Text = oFrm.oCuenta.numVerPlanCuentas;
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVersionPlan.Text = oListaCuentas[0].numVerPlanCuentas;
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtVersionPlan.Text = String.Empty;
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtVersionPlan.Text = String.Empty;
            txtCodCuenta.Text = String.Empty;
        } 

        #endregion

    }
}
