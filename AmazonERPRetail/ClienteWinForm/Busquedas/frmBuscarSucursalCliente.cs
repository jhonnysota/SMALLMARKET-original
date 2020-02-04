using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarSucursalCliente : frmResponseBase
    {

        #region Constructores

        public frmBuscarSucursalCliente()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvSucursales, false);
        }

        public frmBuscarSucursalCliente(List<PersonaDireccionE> oListaTemporal)
            : this()
        {
            bsBase.DataSource = oListaDirecciones = oListaTemporal;
            bsBase.ResetBindings(false);
            dgvSucursales.AutoResizeColumns();
        }
        #endregion Constructores

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<PersonaDireccionE> oListaDirecciones = null;
        public PersonaDireccionE oDireccion = null;

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                if (bsBase.Count > Variables.Cero)
                {
                    oDireccion = (PersonaDireccionE)bsBase.Current;
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

        private void frmBuscarSucursalCliente_Load(object sender, EventArgs e)
        {
            dgvSucursales.Focus();
        }

        private void dgvSucursales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oListaDirecciones != null && oListaDirecciones.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        #endregion Eventos

    }
}
