using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoPresupuestoVenta : FrmMantenimientoBase
    {

        public frmListadoPresupuestoVenta()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
            FormatoGrid(dgvRetencion, true);
            
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 5;

            cboAnio.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin);
            cboAnio.ValueMember = "AnioId";
            cboAnio.DisplayMember = "AnioDes";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPresupuestoVenta);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmPresupuestoVenta()
                {
                    MdiParent = this.MdiParent
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
                if (bsPresupuestoVenta.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPresupuestoVenta);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmPresupuestoVenta((PresupuestoVentaE)bsPresupuestoVenta.Current)
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
                if (bsPresupuestoVenta.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarPresupuestoVenta(((PresupuestoVentaE)bsPresupuestoVenta.Current).idEmpresa, (((PresupuestoVentaE)bsPresupuestoVenta.Current).AnioPresupuesto), ((PresupuestoVentaE)bsPresupuestoVenta.Current).idVendedor);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
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
                String anio = Convert.ToString(cboAnio.SelectedValue);

                bsPresupuestoVenta.DataSource = AgenteVentas.Proxy.ListarPresupuestoVenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, anio);
                bsPresupuestoVenta.ResetBindings(false);
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
            frmPresupuestoVenta oFrm = sender as frmPresupuestoVenta;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoPresupuestoVenta_Load(object sender, EventArgs e)
        {
            Grid = true;
            cboAnio.SelectedValue = Convert.ToInt32(Anio);
            Buscar();

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
        }

        private void dgvPresupuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void bsPresupuestoVenta_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (bsPresupuestoVenta.Count > 0)
                {
                    LblTitulo.Text = "Registros " + bsPresupuestoVenta.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
