using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;

namespace ClienteWinForm.Contabilidad
{
    public partial class FrmListadoEmpresaConcar : FrmMantenimientoBase
    {
        #region Constructor

        public FrmListadoEmpresaConcar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvEmpConcar, true);
            
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent Agentecontabilidad { get { return new ContabilidadServiceAgent(); } }
        List<EmpresaConcarE> ListaEmpresaConcar = null;

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEmpresaConcar);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new FrmEmpresaConcar();
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
                ListaEmpresaConcar = Agentecontabilidad.Proxy.ListarEmpresaConcar();
                bsEmpConcar.DataSource = ListaEmpresaConcar;
                bsEmpConcar.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = "Registros " + bsEmpConcar.Count.ToString();
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
                if (bsEmpConcar.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEmpresaConcar);

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

                    //sino existe la instancia se crea una nueva
                    oFrm = new FrmEmpresaConcar(((EmpresaConcarE)bsEmpConcar.Current).idEmpresa);
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
                if (bsEmpConcar.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        Agentecontabilidad.Proxy.EliminarEmpresaConcar(((EmpresaConcarE)bsEmpConcar.Current).idEmpresa);
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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmEmpresaConcar oFrm = sender as FrmEmpresaConcar;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void FrmListadoEmpresaConcar_Activated(object sender, EventArgs e)
        {
            base.Grabar();
        }

        private void FrmListadoEmpresaConcar_Load(object sender, EventArgs e)
        {
            Grid = true;
        }

        private void dgvEmpConcar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion

    }
}
