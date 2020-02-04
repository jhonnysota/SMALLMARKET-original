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
    public partial class frmBuscarVehiculoTransporte : FrmBusquedaBase
    {
        public frmBuscarVehiculoTransporte(Int32 idTransporte_)
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvVehiculos);
            idTransporte = idTransporte_;
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<TransporteVehiculosE> oListaVehiculos = null;
        public TransporteVehiculosE oVehiculo = null;
        Int32 idTransporte;

        #endregion

        #region Procedimientos de Usuario

        void Filtrar()
        {
            try
            {
                if (oListaVehiculos != null && oListaVehiculos.Count > Variables.Cero)
                {
                    if (rbPlaca.Checked)
                    {
                        bsBase.DataSource = (from x in oListaVehiculos
                                             where x.numPlaca.ToUpper().Contains(txtVehiculo.Text.ToUpper())
                                             select x).ToList();
                    }
                    else
                    {
                        bsBase.DataSource = (from x in oListaVehiculos
                                             where x.Marca.ToUpper().Contains(txtVehiculo.Text.ToUpper())
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
                bsBase.DataSource = oListaVehiculos = AgenteVentas.Proxy.ListarTransporteVehiculos();

                if (!String.IsNullOrEmpty(txtVehiculo.Text))
                {
                    Filtrar();
                } 

                dgvVehiculos.AutoResizeColumns();
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
                oVehiculo = (TransporteVehiculosE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeFault("No hay datos, presione el Botón Cancelar.");
            }
        }

        #endregion

        #region Eventos
        
        private void frmBuscarVehiculoTransporte_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvVehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvVehiculos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvVehiculos, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvVehiculos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvVehiculos.Columns[0].DefaultCellStyle.Format = "00";
            }
        } 

        private void txtVehiculo_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar);
        }

        #endregion

    }
}
