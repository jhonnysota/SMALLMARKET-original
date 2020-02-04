using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarClientes : FrmBusquedaBase
    {
        public frmBuscarClientes()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvClientes);
            LlenarCombo();
        }

        #region Variables

        public MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public ClienteE oCliente = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListarTipoCliente = new GeneralesServiceAgent().Proxy.ListarParTablaPorGrupo((Int32)EnumParTabla.TipoCliente, "");
            ParTabla tp = new ParTabla();
            tp.IdParTabla = Variables.Cero;
            tp.Nombre = "[Escoger Tipo Cliente]";
            ListarTipoCliente.Add(tp);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoCliente, (from x in ListarTipoCliente orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            cboTipoCliente.SelectedValue = Variables.Cero;
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String RazonSocial = txtRazonSocial.Text;
                String NroDocumento = txtNroDocumento.Text;
                Int32 TipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue);

                bsBase.DataSource = AgenteMaestro.Proxy.BuscarClientes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RazonSocial, NroDocumento, TipoCliente);
                dgvClientes.AutoResizeColumns();

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                oCliente = (ClienteE)bsBase.Current;
            }

            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void frmBuscarClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.AutoResizeColumns();
        }

        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == - 1)
            {
                EstiloCabeceras(dgvClientes, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();    
            }            
        }

        #endregion

    }
}
