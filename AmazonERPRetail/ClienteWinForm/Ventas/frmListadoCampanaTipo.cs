using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoCampanaTipo : FrmMantenimientoBase
    {

        public frmListadoCampanaTipo()
        {
            InitializeComponent();
            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<CampanaTipoE> ListaCampanaTipo = null;

        #endregion

        #region ProcedimientosUsuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 30; //ID
            dgvDocumentos.Columns[1].Width = 200; //DESCRIPCION
            dgvDocumentos.Columns[2].Width = 90; //USUARIO REG
            dgvDocumentos.Columns[3].Width = 126; //TFECHA REG
            dgvDocumentos.Columns[4].Width = 90; //USUARIO MOD
            dgvDocumentos.Columns[5].Width = 126; //FECHA MOD
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCampanaTipo);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmCampanaTipo();
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();

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
                ListaCampanaTipo = AgenteVentas.Proxy.ListarCampanaTipoPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsCampanaTipo.DataSource = ListaCampanaTipo;
                bsCampanaTipo.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = bsCampanaTipo.Count.ToString() + " Registros";
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
                if (bsCampanaTipo.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCampanaTipo);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    oFrm = new frmCampanaTipo(((CampanaTipoE)bsCampanaTipo.Current).idTipoCampana, ((CampanaTipoE)bsCampanaTipo.Current).idEmpresa);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsCampanaTipo.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarCampanaTipo(((CampanaTipoE)bsCampanaTipo.Current).idTipoCampana,((CampanaTipoE)bsCampanaTipo.Current).idEmpresa);
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

        #endregion

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmCampanaTipo oFrm = sender as frmCampanaTipo;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoCampanaTipo_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoCampanaTipo_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        } 

        #endregion
    }
}
