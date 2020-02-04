using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmListadoCanje : FrmMantenimientoBase
    {

        public frmListadoCanje()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCanje, false);
            
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<CanjeE> oListaCanje = null;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = MdiChildren.FirstOrDefault(x => x is frmCanje);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmCanje()
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            if (bsCanje.Current != null)
            {
                Form oFrm = MdiChildren.FirstOrDefault(x => x is frmCanje);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                CanjeE ECanje = (CanjeE)bsCanje.Current;

                if (ECanje != null)
                {
                    oFrm = new frmCanje(ECanje)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                } 
            }
        }

        public override void Buscar()
        {
            try
            {
                Int32.TryParse(txtIdAuxiliar.Text, out Int32 idPersona);

                if (rbUnCliente.Checked)
                {
                    if (idPersona == 0)
                    {
                        Global.MensajeFault("Debe ingresar un auxiliar");
                        return;
                    }
                }

                bsCanje.DataSource = oListaCanje = AgenteCtasPorPagar.Proxy.ListarCanje(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            Int32 resp = Variables.Cero;

            try
            {
                if (bsCanje.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(String.Format("Desea anular el siguiente canje {0}", ((CanjeE)bsCanje.Current).numCanje)) == DialogResult.Yes)
                    {
                        resp = AgenteCtasPorPagar.Proxy.CambiarEstadoCanje(((CanjeE)bsCanje.Current).idCanje, "AN", VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Global.MensajeComunicacion("Registro anulado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion 

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCanje oFrm = sender as frmCanje;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos 

        private void frmListadoCanje_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvCanje_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void bsCanje_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblTitulo.Text = "Registros " + bsCanje.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbTodosCLientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodosCLientes.Checked)
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.Focus();
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
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
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAuxiliar.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void tsmiCerrarCanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCanje.Current != null)
                {
                    if (((CanjeE)bsCanje.Current).Estado == "RE")
                    {
                        CanjeE oCanje = AgenteCtasPorPagar.Proxy.ObtenerCanjeCompleto(((CanjeE)bsCanje.Current).idCanje);

                        if (oCanje != null)
                        {
                            VoucherE oVoucher = AgenteCtasPorPagar.Proxy.CerrarCanje(oCanje, VariablesLocales.oConParametros, VariablesLocales.SesionUsuario.Credencial);

                            if (oVoucher != null)
                            {
                                if (String.IsNullOrWhiteSpace(oCanje.idComprobante) && String.IsNullOrWhiteSpace(oCanje.numFile) && String.IsNullOrWhiteSpace(oCanje.numVoucher))
                                {
                                    Global.MensajeComunicacion(String.Format("Se generó el voucher {0} {1}-{2}", oVoucher.idComprobante, oVoucher.numFile, oVoucher.numVoucher));
                                }
                                else
                                {
                                    Global.MensajeComunicacion(String.Format("Se actualizó el voucher {0} {1}-{2}", oVoucher.idComprobante, oVoucher.numFile, oVoucher.numVoucher));
                                }

                                Buscar();
                            }
                        } 
                    }
                    else if (((CanjeE)bsCanje.Current).Estado == "AN")
                    {
                        Global.MensajeAdvertencia("Canje se encuentra Anulado.");
                    }
                    else if (((CanjeE)bsCanje.Current).Estado == "AC")
                    {
                        Global.MensajeAdvertencia("Canje se encuentra Aceptado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimeVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if ((CanjeE)bsCanje.Current != null)
                {
                    if (((CanjeE)bsCanje.Current).Estado == "AC")
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        VoucherE VoucherRep = new VoucherE
                        {
                            AnioPeriodo = ((CanjeE)bsCanje.Current).AnioPeriodo,
                            numVoucher = ((CanjeE)bsCanje.Current).numVoucher,
                            idComprobante = ((CanjeE)bsCanje.Current).idComprobante,
                            numFile = ((CanjeE)bsCanje.Current).numFile,
                            MesPeriodo = ((CanjeE)bsCanje.Current).MesPeriodo,
                            idEmpresa = ((CanjeE)bsCanje.Current).idEmpresa,
                            idLocal = ((CanjeE)bsCanje.Current).idLocal
                        };

                        oFrm = new frmImpresionVoucher("N", VoucherRep)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                    else
                    {
                        Global.MensajeAdvertencia("Solo puede ver el asiento contable en los Canjes Aceptados");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCanje_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Si se encuentra anulado
                if ((String)dgvCanje.Rows[e.RowIndex].Cells["Estado"].Value == "AN")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }

                //Si se encuentra anulado
                if ((String)dgvCanje.Rows[e.RowIndex].Cells["Estado"].Value == "AC")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiAbrirCanje_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCanje.Current != null)
                {
                    if (((CanjeE)bsCanje.Current).Estado == "AC")
                    {
                        Int32 resp = AgenteCtasPorPagar.Proxy.AbrirCanje(((CanjeE)bsCanje.Current).idCanje, VariablesLocales.SesionUsuario.Credencial);

                        if (resp == 1)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Canje Abierto...");
                        }
                    }
                    else if (((CanjeE)bsCanje.Current).Estado == "AN")
                    {
                        Global.MensajeAdvertencia("Canje se encuentra Anulado.");
                    }
                    else if (((CanjeE)bsCanje.Current).Estado == "RE")
                    {
                        Global.MensajeAdvertencia("El Canje se encuentra Abierto.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsCanje.Current != null)
                {
                    if (((CanjeE)bsCanje.Current).Estado == "RE")//Registrado
                    {
                        CanjeE oCanje = Colecciones.CopiarEntidad<CanjeE>(((CanjeE)bsCanje.Current));
                        oCanje.idComprobante = String.Empty;
                        oCanje.numFile = String.Empty;
                        oCanje.numVoucher = String.Empty;
                        oCanje.AnioPeriodo = String.Empty;
                        oCanje.MesPeriodo = String.Empty;
                        oCanje.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;

                        Int32 resp = AgenteCtasPorPagar.Proxy.ActualizarCanjeConta(oCanje);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Datos contable borrados.");
                        }
                    }
                    else if (((CanjeE)bsCanje.Current).Estado == "AN")//Anulado
                    {
                        Global.MensajeAdvertencia("Canje Anulado.");
                    }
                    else if (((CanjeE)bsCanje.Current).Estado == "AC")//Aceptado
                    {
                        Global.MensajeAdvertencia("Canje Aceptado.");
                    }
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
