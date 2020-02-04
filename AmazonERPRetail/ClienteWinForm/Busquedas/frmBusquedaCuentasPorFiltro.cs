using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBusquedaCuentasPorFiltro : frmResponseBase
    {

        #region Constructores

        public frmBusquedaCuentasPorFiltro()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvCuentas, false);
        }

        public frmBusquedaCuentasPorFiltro(List<PlanCuentasE> ListaTemporal)
            : this()
        {
            oListaCuentas = ListaTemporal;
            bsBase.DataSource = oListaCuentas;
            bsBase.ResetBindings(false);

            lblTitPnlBase.Text = "Registros " + oListaCuentas.Count.ToString();
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContable { get { return new ContabilidadServiceAgent(); } }
        List<PlanCuentasE> oListaCuentas = null;
        public PlanCuentasE oCuenta = null;

        #endregion Variables

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            if (!String.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
            {
                bsBase.DataSource = (from x in oListaCuentas
                                     where x.codCuenta.ToUpper().Contains(txtCodCuenta.Text.ToUpper())
                                     select x).ToList();
            }
            else if (String.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
            {
                bsBase.DataSource = (from x in oListaCuentas
                                     where x.Descripcion.ToUpper().Contains(txtDesCuenta.Text.ToUpper())
                                     select x).ToList();
            }
            else
            {
                bsBase.DataSource = (from x in oListaCuentas
                                     where x.codCuenta.ToUpper().Contains(txtCodCuenta.Text.ToUpper()) &&
                                     x.Descripcion.ToUpper().Contains(txtDesCuenta.Text.ToUpper())
                                     select x).ToList();
            }

            lblTitPnlBase.Text = "Registros " + bsBase.List.Count.ToString();
        } 

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (bsBase.Count > Variables.Cero)
                {
                    oCuenta = (PlanCuentasE)bsBase.Current;
                    base.Aceptar();
                }
                else
                {
                    Global.MensajeFault("No hay datos. Cierre la ventana.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmBusquedaCuentasPorFiltro_Load(object sender, EventArgs e)
        {
            dgvCuentas.Focus();
        }

        private void dgvCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oListaCuentas != null && oListaCuentas.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaCuentas != null && oListaCuentas.Count > Variables.Cero)
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oListaCuentas != null && oListaCuentas.Count > Variables.Cero)
                {
                    BuscarFiltro();
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
