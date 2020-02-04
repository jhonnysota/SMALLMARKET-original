using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarRequerimiento : FrmBusquedaBase
    {

        public frmBuscarRequerimiento()
        {
            InitializeComponent();
            FormatoGrid(dgvListado);
        }

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<MovimientoAlmacenE> oLista;
        public OperacionE oEntidad;

        protected override void Buscar()
        {
            int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            int idLocal =  VariablesLocales.SesionLocal.IdLocal;
            string desProveedor = txtFiltro.Text;

            if (txtFiltro.Text.Trim().Length == 0 || oLista == null || oLista.Count == 0)
            {
                oLista = AgenteAlmacen.Proxy.ListarMovimientoAlmacen(idEmpresa, 2211, 0, txtDesde.Value.ToString("yyyyMMdd"), txtHasta.Value.ToString("yyyyMMdd"), 0, false);
            }

            if (txtFiltro.Text.Trim().Length > 0 && oLista != null && oLista.Count > 0)
            {
                oLista = oLista.Where(x => x.RazonSocial.ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()) ).ToList();
            }

            bsMovimientoAlmacen.DataSource = oLista;
            bsMovimientoAlmacen.ResetBindings(false);
        }

        protected override void Aceptar()
        {
            if (bsMovimientoAlmacen.Count > 0)
            {
                oEntidad = (OperacionE)bsMovimientoAlmacen.Current;
            }

            base.Aceptar();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmBuscarRequerimiento_Load(object sender, EventArgs e)
        {
            txtDesde.Value = Convert.ToDateTime("01" + "/" + VariablesLocales.FechaHoy.Month.ToString("00") + "/" + VariablesLocales.FechaHoy.Year.ToString("00"));
            Buscar();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            Buscar();
        }

    }
}
