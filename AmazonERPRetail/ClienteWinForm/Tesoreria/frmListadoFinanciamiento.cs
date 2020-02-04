using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Extensores;
using Entidades.Maestros;
using Infraestructura.Winform;
using Infraestructura.Recursos;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListadoFinanciamiento : FrmMantenimientoBase
    {

        public frmListadoFinanciamiento()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvFinanciamiento, true);
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        List<BancosE> oListarBancos = null;
        List<TipoLineaCreditoE> oListaLineaCred = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            BancosE banIni = new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Todos };
            oListarBancos.Add(banIni);
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

            oListaLineaCred = AgenteTesoreria.Proxy.ListarTipoLineaCredito(false);
            TipoLineaCreditoE LineaIni = new TipoLineaCreditoE() { idLinea = 0, Descripcion = Variables.Todos };
            oListaLineaCred.Add(LineaIni);
            ComboHelper.RellenarCombos<TipoLineaCreditoE>(cboLineaCredito, (from x in oListaLineaCred orderby x.idLinea select x).ToList(), "idLinea", "Descripcion");

            banIni = null;
            LineaIni = null;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFinanciamiento);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmFinanciamiento(oListarBancos, oListaLineaCred)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (!ValidarIngresoVentana())
                {
                    return;
                }

                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFinanciamiento);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    //si la instancia existe la pongo en primer plano
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmFinanciamiento(((FinanciamientoE)bsFinanciamiento.Current).idFinanciamiento, oListarBancos, oListaLineaCred)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                bsFinanciamiento.DataSource = AgenteTesoreria.Proxy.ListarFinanciamiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboBancosEmpresa.SelectedValue), Convert.ToInt32(cboLineaCredito.SelectedValue), chkIncluir.Checked);
                bsFinanciamiento.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsFinanciamiento.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        FinanciamientoE oFinanzas = Colecciones.CopiarEntidad<FinanciamientoE>((FinanciamientoE)bsFinanciamiento.Current);
                        oFinanzas.Fecha = VariablesLocales.FechaHoy.Date;
                        oFinanzas.Importe = 0;

                        AgenteTesoreria.Proxy.AnularFinanciamiento(((FinanciamientoE)bsFinanciamiento.Current).idLinea);

                        if (Global.MensajeConfirmacion("Desea crear una copia del Financiamiento dado de Baja") == DialogResult.Yes)
                        {
                            oFinanzas = AgenteTesoreria.Proxy.InsertarFinanciamiento(oFinanzas);
                            //bsFinanciamiento.Add(oFinanzas);
                        }

                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarIngresoVentana()
        {
            if (oListarBancos == null || oListarBancos.Count == 1)
            {
                Global.MensajeFault("Antes de crear, debe tener Entidades Bancarias.");
                return false;
            }

            if (oListaLineaCred == null || oListaLineaCred.Count == 1)
            {
                Global.MensajeFault("Antes de crear, debe tener Tipos de Linea de Crédito.");
                return false;
            }

            return base.ValidarIngresoVentana();
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmFinanciamiento oFrm = sender as frmFinanciamiento;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoFinanciamiento_Load(object sender, EventArgs e)
        {
            Grid = true;
            LlenarCombos();
            base.Grabar();
        }

        private void dgvFinanciamiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Editar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvFinanciamiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvFinanciamiento.Rows[e.RowIndex].Cells["indEstado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        private void chkIncluir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncluir.Checked)
            {
                dgvFinanciamiento.Columns[6].Visible = true;
                dgvFinanciamiento.Columns[7].Visible = true;
            }
            else
            {
                dgvFinanciamiento.Columns[6].Visible = false;
                dgvFinanciamiento.Columns[7].Visible = false;
            }

            Buscar();
        }

        private void bsFinanciamiento_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsFinanciamiento.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
