using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorCobrar;
using Infraestructura;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmListadoTipoIngresos : FrmMantenimientoBase
    {

        public frmListadoTipoIngresos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvIngresos, true);
            
        }

        #region Variables

        CtasPorCobrarServiceAgent AgenteCtasCobrar { get { return new CtasPorCobrarServiceAgent(); } }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoIngresos);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmTipoIngresos
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoIngresos);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                TipoIngresosE ingresos = (TipoIngresosE)bsTipoIngresos.Current;

                oFrm = new frmTipoIngresos(ingresos)
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

        public override void Anular()
        {
            try
            {
                if (bsTipoIngresos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                    {
                        AgenteCtasCobrar.Proxy.EliminarTipoIngresos(((TipoIngresosE)bsTipoIngresos.Current).idEmpresa, ((TipoIngresosE)bsTipoIngresos.Current).TipoCobro);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                        base.Anular();
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
                List<TipoIngresosE> ListaTipoCIngresos = AgenteCtasCobrar.Proxy.ListarTipoIngresos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsTipoIngresos.DataSource = ListaTipoCIngresos;
                bsTipoIngresos.ResetBindings(false);

                btCopiar.Enabled = (ListaTipoCIngresos.Count == 0);
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
            frmTipoIngresos oFrm = sender as frmTipoIngresos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmListadoTipoIngresos_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvIngresos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TipoIngresosE> oListaEmpresas = AgenteCtasCobrar.Proxy.ListarEmpresaTipIng(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oListaEmpresas.Count > 0)
                {
                    frmBuscarEmpresas oFrm = new frmBuscarEmpresas(oListaEmpresas);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oEmpresaTipoIngreso != null)
                    {
                        Int32 resp = AgenteCtasCobrar.Proxy.CopiarTipoIngresos(oFrm.oEmpresaTipoIngreso.idEmpresa, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion(String.Format("Se ingresaron los Tipos de Cobranza de {0}", oFrm.oEmpresaTipoIngreso.NombreEmpresa));
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("No existen datos en otras empresas.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsTipoIngresos_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsTipoIngresos.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
