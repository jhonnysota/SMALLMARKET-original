using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoPeriodos : FrmMantenimientoBase
    {

        public frmListadoPeriodos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            
            FormatoGrid(dgvPeriodos, true);
            
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPeriodos);

                if (oFrm != null)
                {
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

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPeriodos()
                {
                    MdiParent = MdiParent
                };

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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPeriodos);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                PeriodosE periodoTmp = (PeriodosE)bsPeriodo.Current;

                oFrm = new frmPeriodos(periodoTmp)
                {
                    MdiParent = MdiParent
                };

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
                bsPeriodo.DataSource = AgenteContabilidad.Proxy.ListarPeriodos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo); 
                
                lblRegistros.Text = "Periodos - " + bsPeriodo.Count.ToString() + " Registros";
                dgvPeriodos.AutoResizeColumns();
                BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
                dgvPeriodos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPeriodos_Load(object sender, EventArgs e)
        {
            if (VariablesLocales.PeriodoContable == null)
            {
                Global.MensajeComunicacion(" Registrar Periodo Contable en Maestros de Contabilidad - Cambiar Sucursal Periodo ");
                return;
            }
            else
            {
                base.Grabar();
                Grid = true;
                Buscar();
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        private void dgvPeriodos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        } 

        #endregion

    }
}
