using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoLibroConcar : FrmMantenimientoBase
    {
        
        public frmListadoLibroConcar()
        {
            InitializeComponent();
            FormatoGrid(dgvConcar, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<LibroConcarE> ListaLibroConcar = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLibroConcar);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmLibroConcar();
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
                ListaLibroConcar = AgenteContabilidad.Proxy.Listarlibroconcar(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                bsLibroConcar.DataSource = ListaLibroConcar;
                bsLibroConcar.ResetBindings(false);

                base.Buscar();
                lblRegistros.Text = "Libro Concar [ " + bsLibroConcar.Count.ToString() + " Registros ]";
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
                if (bsLibroConcar.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmConcepto);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }


                    oFrm = new frmLibroConcar(((LibroConcarE)bsLibroConcar.Current).idEmpresa, ((LibroConcarE)bsLibroConcar.Current).csubdia);
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
                if (bsLibroConcar.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteContabilidad.Proxy.Eliminarlibroconcar(((LibroConcarE)bsLibroConcar.Current).idEmpresa, (((LibroConcarE)bsLibroConcar.Current).csubdia));
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
            frmLibroConcar oFrm = sender as frmLibroConcar;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoLibroConcar_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvConcar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void frmListadoLibroConcar_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }
        
        #endregion
    }
}
