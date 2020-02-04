using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmPeriodosControl : FrmMantenimientoBase
    {

        public frmPeriodosControl()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            FormatoGrid(dgvPeriodo, true);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<PeriodosE> listaperiodo = new List<PeriodosE>();

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                bsPeriodo.DataSource = AgenteContabilidad.Proxy.ListarPeriodos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo);

                lblRegistros.Text = "Periodos - " + bsPeriodo.Count.ToString() + " Registros";
                dgvPeriodo.AutoResizeColumns();
                BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
                dgvPeriodo.AutoResizeColumns();

                //base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (dgvPeriodo.IsCurrentCellDirty)
                {
                    dgvPeriodo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                if (!ValidarGrabacion()) { return; }

                listaperiodo = AgenteContabilidad.Proxy.ActualizarPeriodosLista((List<PeriodosE>)bsPeriodo.List);
                Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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
                if (bsPeriodo.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCierre);

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
                    oFrm = new frmCierre(((PeriodosE)bsPeriodo.Current))
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmPeriodo_Load(object sender, EventArgs e)
        {
            if (VariablesLocales.PeriodoContable == null)
            {
                Global.MensajeComunicacion("Registrar Periodo Contable en Maestros de Contabilidad - Cambiar Sucursal Periodo ");
                return;
            }
            else
            {
                base.Nuevo();

                Buscar();
            }

            Text = "Control De Cierres Periodo: " + VariablesLocales.PeriodoContable.AnioPeriodo + " - " + VariablesLocales.PeriodoContable.MesPeriodo;
        }    

        private void dgvPeriodo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bsPeriodo.EndEdit();

            if (e.RowIndex != -1)
            {
                if (((PeriodosE)bsPeriodo.Current).Opcion != (int)EnumOpcionGrabar.Insertar)
                {
                    ((PeriodosE)bsPeriodo.Current).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    ((PeriodosE)bsPeriodo.Current).FechaModificacion = VariablesLocales.FechaHoy;
                    ((PeriodosE)bsPeriodo.Current).Opcion = (int)EnumOpcionGrabar.Actualizar;
                }
            }
        }

        private void dgvPeriodo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvPeriodo.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
        }

        private void dgvPeriodo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        #endregion

    }
}
