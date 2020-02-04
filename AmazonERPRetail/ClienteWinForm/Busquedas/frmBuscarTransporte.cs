using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Entidades.Ventas;
using Presentadora.AgenteServicio;
using Infraestructura.Enumerados;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarTransporte : FrmBusquedaBase
    {
        public frmBuscarTransporte()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvTransportes);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<TransporteE> oListaTransportes = null;
        public TransporteE oTransporte = null;

        #endregion

        #region Procedimientos de Usuario

        //void Filtrar()
        //{
        //    try
        //    {
        //        if (oListaTransportes != null && oListaTransportes.Count > Variables.ValorCero)
        //        {
        //            if (rbRazon.Checked)
        //            {
        //                bsBase.DataSource = (from x in oListaTransportes
        //                                     where x.RazonSocial.ToUpper().Contains(txtRazonSocial.Text.ToUpper())
        //                                     select x).ToList();
        //            }
        //            else
        //            {
        //                bsBase.DataSource = (from x in oListaTransportes
        //                                     where x.Ruc.ToUpper().Contains(txtRazonSocial.Text.ToUpper())
        //                                     select x).ToList();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.MensajeFault(ex.Message);
        //    }
        //}

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                bsBase.DataSource = oListaTransportes = AgenteVentas.Proxy.ListarTransporteBusqueda(txtRazonSocial.Text.Trim(), txtRuc.Text.Trim());

                //if (!String.IsNullOrEmpty(txtRazonSocial.Text))
                //{
                //    Filtrar();
                //} 

                dgvTransportes.AutoResizeColumns();
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
                oTransporte = (TransporteE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeFault("No existen datos presione Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarTransporte_Load(object sender, EventArgs e)
        {
            //Buscar();
        }

        private void dgvTransportes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvTransportes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvTransportes, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvTransportes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvTransportes.Columns[1].DefaultCellStyle.Format = "00";
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            //Filtrar();
        }

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar);
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar);
        }

        #endregion

    }
}
