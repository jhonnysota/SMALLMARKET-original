using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoBancos : FrmMantenimientoBase
    {

        public frmListadoBancos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvBancos, true);
            AnchoColumnas();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<BancosE> ListaBancos = null;

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvBancos.Columns[0].Width = 50;
            dgvBancos.Columns[1].Width = 100;
            dgvBancos.Columns[2].Width = 300;
            dgvBancos.Columns[3].Width = 90;
            dgvBancos.Columns[4].Width = 120;
            dgvBancos.Columns[5].Width = 90;
            dgvBancos.Columns[6].Width = 120;
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

                FrmDlgPersona oFrm = new FrmDlgPersona();

                if (oFrm.ValidarIngresoVentana())
                {
                    oFrm.Enumerado = EnumTipoRolPersona.Bancos;
                    oFrm.OpcionVentana = (Int32)EnumTipoRolPersona.Bancos;
                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
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
                if (bsBancos.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBancos);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    BancosE oBanco = AgenteMaestros.Proxy.RecuperarBancoPorId(((BancosE)bsBancos.Current).idPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmBancos(oBanco, Convert.ToInt32(EnumOpcionGrabar.Actualizar))
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
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
                bsBancos.DataSource = ListaBancos = AgenteMaestros.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsBancos.ResetBindings(false);
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
                if (bsBancos.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        AgenteMaestros.Proxy.EliminarBancos(((BancosE)bsBancos.Current).idPersona, ((BancosE)bsBancos.Current).idEmpresa);
                        ListaBancos.RemoveAt(bsBancos.Position);
                        bsBancos.DataSource = ListaBancos;
                        bsBancos.ResetBindings(false);
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
            frmBancos oFrm = sender as frmBancos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoBancos_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvBancos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void bsBancos_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblTitulo.Text = "Registros " + bsBancos.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeComunicacion(ex.Message);
            }
        }

        #endregion

    }
}
