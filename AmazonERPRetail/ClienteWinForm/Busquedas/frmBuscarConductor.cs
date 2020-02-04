using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Ventas;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarConductor : FrmBusquedaBase
    {
        public frmBuscarConductor(Int32 idTransporte_)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvConductores);
            idTransporte = idTransporte_;
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<TransporteConductoresE> oListaConductores = null;
        public TransporteConductoresE oConductores = null;
        Int32 idTransporte;

        #endregion

        #region Procedimientos de Usuario

        void Filtrar()
        {
            try
            {
                if (oListaConductores != null && oListaConductores.Count > Variables.Cero)
                {
                    if (rbNombres.Checked)
                    {
                        bsBase.DataSource = (from x in oListaConductores
                                             where x.Nombres.ToUpper().Contains(txtConductor.Text.ToUpper())
                                             select x).ToList();
                    }
                    else
                    {
                        bsBase.DataSource = (from x in oListaConductores
                                             where x.Licencia.ToUpper().Contains(txtConductor.Text.ToUpper())
                                             select x).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = oListaConductores = AgenteVentas.Proxy.ListarTransporteConductores();
                
                if (!String.IsNullOrEmpty(txtConductor.Text))
                {
                    Filtrar();
                }

                dgvConductores.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oConductores = (TransporteConductoresE)bsBase.Current;
            }

            base.Aceptar();
        }

        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region Eventos

        private void frmBuscarConductor_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvConductores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvConductores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvConductores.Columns[2].DefaultCellStyle.Format = "00";
        }

        private void dgvConductores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvConductores, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void txtConductor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filtrar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtConductor_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar);
        }

        #endregion

    }
}
