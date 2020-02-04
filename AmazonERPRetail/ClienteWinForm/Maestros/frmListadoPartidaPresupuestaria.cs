using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Maestros;
using Infraestructura;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Maestros
{
    public partial class frmListadoPartidaPresupuestaria : FrmMantenimientoBase
    {

        public frmListadoPartidaPresupuestaria()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dvgPartidas, true);
            
        }

        #region Variables

        public MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPartidaPresupuestaria);

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
                oFrm = new frmPartidaPresupuestaria();
                oFrm.MdiParent = this.MdiParent;
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
                if (bsPartidas.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPartidaPresupuestaria);

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
                    oFrm = new frmPartidaPresupuestaria((PartidaPresupuestariaE)bsPartidas.Current);
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

        public override void Buscar()
        {
            try
            {
                String Tipo = String.Empty;
                String Descripcion = txtDescripcion.Text;

                if (rbRe.Checked)
                {
                    Tipo = "RE";
                }

                if (rbGa.Checked)
                {
                    Tipo = "GA";
                }
                
                bsPartidas.DataSource = AgenteMaestro.Proxy.ListarPartidaPresupuestariaPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Tipo, Descripcion, Variables.Cero);
                dvgPartidas.AutoResizeColumns();
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
                if (bsPartidas.List.Count > Variables.Cero)
                {
                    if (((PartidaPresupuestariaE)bsPartidas.Current).numNivel == 1)
                    {
                        if (Global.MensajeConfirmacion("Ha escogido un Item de Primer Nivel, se eliminará todo su detalle. Desea continuar ?") == DialogResult.Yes)
                        {
                            Int32 resp = AgenteMaestro.Proxy.EliminarPartidaPresupuestariaTodo(((PartidaPresupuestariaE)bsPartidas.Current).idEmpresa, ((PartidaPresupuestariaE)bsPartidas.Current).tipPartidaPresu, ((PartidaPresupuestariaE)bsPartidas.Current).codPartidaPresu);

                            if (resp > Variables.Cero)
                            {
                                Global.MensajeComunicacion("Se ha eliminado completamente la partida.");
                                Buscar();
                            }
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Desea eliminar la fila escogida?") == DialogResult.Yes)
                        {
                            Int32 resp = AgenteMaestro.Proxy.EliminarPartidaPresupuestaria(((PartidaPresupuestariaE)bsPartidas.Current).idEmpresa, ((PartidaPresupuestariaE)bsPartidas.Current).tipPartidaPresu, ((PartidaPresupuestariaE)bsPartidas.Current).codPartidaPresu);

                            if (resp > Variables.Cero)
                            {
                                Global.MensajeComunicacion("Se ha eliminado fila.");
                                Buscar();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmPartidaPresupuestaria oFrm = sender as frmPartidaPresupuestaria;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPartidaPresupuestaria_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dvgPartidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsPartidas.Count > Variables.Cero)
            {
                Editar();
            }
        } 

        #endregion

    }
}
