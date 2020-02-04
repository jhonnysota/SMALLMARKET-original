using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCuentasMigraciones : FrmBusquedaBase
    {
        public frmBuscarCuentasMigraciones(CuentasMigracionE oCuentaTemporal)
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCuentas);
            Nivel();
            oCuentaMigracion = oCuentaTemporal;

            if (oCuentaMigracion != null)
            {
                lblCuenta.Text = "Cuenta Destino    " + oCuentaMigracion.cuentadestino;
                lblDesCuenta.Text = oCuentaMigracion.nombredestino;
                lblCtaOrigen.Text = "Cuenta Origen      " + oCuentaMigracion.cuentaorigen;
                lblNombreOrigen.Text = oCuentaMigracion.nombreorigen;
                lblCodCosto.Text = "Centro de Costos " + oCuentaMigracion.ccosto;
                lblNombreCostos.Text = oCuentaMigracion.nombreccosto;

                if (!String.IsNullOrEmpty(oCuentaMigracion.codCuenta))
                {
                    oCuentaMigracionAnterior = oCuentaTemporal;
                    oCuentaMigracionAnterior.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                }
            }
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        CuentasMigracionE oCuentaMigracion = null;
        CuentasMigracionE oCuentaMigracionAnterior = null;

        #endregion

        #region Procedimientos de Usuario

        void Nivel()
        {
            try
            {
                nudNivel.Value = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
                nudNivel.Minimum = 1;
                nudNivel.Maximum = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        CuentasMigracionE GrabarDatos()
        {
            CuentasMigracionE oCuenta = new CuentasMigracionE()
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                tipo = oCuentaMigracion.tipo.Trim(),
                cuentadestino = oCuentaMigracion.cuentadestino.Trim(),
                cuentaorigen = oCuentaMigracion.cuentaorigen.Trim(),
                ccosto = oCuentaMigracion.ccosto.Trim(),
                numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                codCuenta = ((PlanCuentasE)bsBase.Current).codCuenta,
                desCuenta = ((PlanCuentasE)bsBase.Current).Descripcion
            };

            return oCuenta;
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                Int32 Opcion = Variables.ValorUno;
                String Cuenta = txtFiltro.Text;

                if (rbPorCuenta.Checked)
                {
                    if (String.IsNullOrEmpty(Cuenta.Trim()))
                    {
                        Global.MensajeFault("Debe ingresar el indicio de la cuenta (10, 101, 1011...)");
                        return;
                    }
                }

                if (rbPorDescripcion.Checked)
                {
                    Opcion = 2;
                }

                bsBase.DataSource = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtFiltro.Text, Convert.ToInt32(nudNivel.Value), Opcion);
                dgvCuentas.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

            base.Buscar();
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    AgenteContabilidad.Proxy.InsertarCuentasMigracion(GrabarDatos(), oCuentaMigracionAnterior);
                    base.Aceptar();
                }
                else
                {
                    Global.MensajeComunicacion("Presione Cancelar...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmBuscarCuentasMigraciones_Load(object sender, EventArgs e)
        {
            dgvCuentas.AutoResizeColumns();
        }

        private void dgvCuentas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvCuentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvCuentas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion Eventos

    }
}
