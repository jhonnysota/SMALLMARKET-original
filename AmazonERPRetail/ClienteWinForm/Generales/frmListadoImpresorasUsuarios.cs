using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Generales
{
    public partial class frmListadoImpresorasUsuarios : FrmMantenimientoBase
    {

        public frmListadoImpresorasUsuarios()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvControl, true);
            
        }

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresoraUsuario);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmImpresoraUsuario
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
            try
            {
                if (bsImpresorasUsuario.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresoraUsuario);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmImpresoraUsuario((UsuarioImpresorasE)bsImpresorasUsuario.Current)
                    {
                        MdiParent = this.MdiParent
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

        public override void Anular()
        {
            try
            {
                if (bsImpresorasUsuario.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        AgenteGenerales.Proxy.EliminarUsuarioImpresoras(((UsuarioImpresorasE)bsImpresorasUsuario.Current).idImpresora, Convert.ToInt32(((UsuarioImpresorasE)bsImpresorasUsuario.Current).idPersona));
                        Global.MensajeComunicacion(Mensajes.EliminacionExitosa);
                        Buscar();
                    }
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
                bsImpresorasUsuario.DataSource = AgenteGenerales.Proxy.ListarUsuarioImpresoras(VariablesLocales.SesionUsuario.IdPersona);
                bsImpresorasUsuario.ResetBindings(false);

                lblRegistros.Text = "Registros " + bsImpresorasUsuario.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmImpresoraUsuario oFrm = sender as frmImpresoraUsuario;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoImpresorasUsuarios_Load(object sender, EventArgs e)
        {
            Grid = true;

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
        }

        private void dgvControl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        } 

        #endregion

    }
}
