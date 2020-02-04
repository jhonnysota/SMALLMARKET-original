using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Almacen
{
    public partial class frmPeriodosControlAlm : FrmMantenimientoBase
    {

        public frmPeriodosControlAlm()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            FormatoGrid(dgvPeriodo, true);
            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<PeriodosAlmE> listaperiodo = new List<PeriodosAlmE>();

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            string AnioActual = VariablesLocales.FechaHoy.ToString("yyyy");

            //Cargando Años
            int AnioFin = Convert.ToInt32(AnioActual);
            int AnioInicio = AnioFin - 5;
            cboAnios.DataSource = FechasHelper.CargarAnios(AnioInicio, AnioFin + 3);
            cboAnios.ValueMember = "AnioId";
            cboAnios.DisplayMember = "AnioDes";

            cboAnios.SelectedValue = AnioActual;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                bsPeriodo.DataSource = listaperiodo = AgenteAlmacen.Proxy.ListarPeriodosAlm(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, cboAnios.SelectedValue.ToString());
                dgvPeriodo.AutoResizeColumns();

                BtGenerar.Enabled = listaperiodo.Count == 0;
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

                listaperiodo = AgenteAlmacen.Proxy.GrabarPeriodosAlm(listaperiodo);
                Buscar();
                Global.MensajeComunicacion("Registros Guardados...");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos
        
        private void dgvPeriodo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bsPeriodo.EndEdit();
            if (e.RowIndex != -1)
            {
                if (((PeriodosAlmE)bsPeriodo.Current).Opcion != (int)EnumOpcionGrabar.Insertar)
                {
                    ((PeriodosAlmE)bsPeriodo.Current).UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    ((PeriodosAlmE)bsPeriodo.Current).FechaModificacion = VariablesLocales.FechaHoy;
                    ((PeriodosAlmE)bsPeriodo.Current).Opcion = (int)EnumOpcionGrabar.Actualizar;
                }
            }
        }

        private void frmPeriodoControlAlm_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void dgvPeriodo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    dgvPeriodo.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            //}
        }

        private void bsPeriodo_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsPeriodo.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtGenerar_Click(object sender, EventArgs e)
        {
            if (bsPeriodo.Count == Variables.Cero)
            {
                try
                {
                    bsPeriodo.EndEdit();
                    listaperiodo = new List<PeriodosAlmE>();

                    for (int i = 1; i < 13; i++)
                    {
                        PeriodosAlmE FileNuevo = new PeriodosAlmE
                        {
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            AnioPeriodo = cboAnios.SelectedValue.ToString(),
                            MesPeriodo = string.Format("{0:00}", i),
                            desPeriodo = FechasHelper.NombreMes(i).ToUpper(),
                            fecInicio = cboAnios.SelectedValue.ToString() + string.Format("{0:00}", i) + "01",
                            fecFinal = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + string.Format("{0:00}", i) + "/" + cboAnios.SelectedValue.ToString())).ToString("yyyyMMdd"),
                            indCierre = false,
                            indApertura = true,
                            indReapertura = false,
                            TCCompra = 0M,
                            TCVenta = 0M,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy,
                            Opcion = (int)EnumOpcionGrabar.Insertar
                        };

                        listaperiodo.Add(FileNuevo);
                    }

                    bsPeriodo.DataSource = listaperiodo;
                    bsPeriodo.ResetBindings(false);
                    bsPeriodo.MoveLast();
                }
                catch (Exception ex)
                {
                    Global.MensajeError(ex.Message);
                }
            }
            else
            {
                Global.MensajeConfirmacion("Periodo Ya Vigente");
            }
        }

        private void cboAnios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvPeriodo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPeriodo.CurrentCell is DataGridViewCheckBoxCell && dgvPeriodo.Columns[4].Name == "indCierre")
            {
                dgvPeriodo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        } 

        #endregion

    }
}
