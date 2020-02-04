using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBusquedaProveedor : FrmBusquedaBase
    {
        public frmBusquedaProveedor()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvProveedor);
            LlenarCombo();
        }

        #region Variables

        public MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public ProveedorE oProveedor = null;
        //Int32 Validacion = 0;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<ParTabla> ListarTipoProveedor = new GeneralesServiceAgent().Proxy.ListarParTablaPorGrupo((Int32)EnumParTabla.TipoProveedor, "");
            ParTabla tp = new ParTabla();
            tp.IdParTabla = Variables.Cero;
            tp.Nombre = "[Escoger Tipo Proveedor]";
            ListarTipoProveedor.Add(tp);
            ComboHelper.RellenarCombos<ParTabla>(cboTipoProveedor, (from x in ListarTipoProveedor orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
            cboTipoProveedor.SelectedValue = Variables.Cero;
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                String RazonSocial = txtRazonSocial.Text;
                String NroDocumento = txtNroDocumento.Text;
                Int32 TipoProveedor = Convert.ToInt32(cboTipoProveedor.SelectedValue);

                if (String.IsNullOrEmpty(RazonSocial.Trim()) && String.IsNullOrEmpty(NroDocumento.Trim()))
                {
                    Global.MensajeComunicacion("Debe ingresar al menos un parámetro de busqueda.");
                    return;
                }

                bsBase.DataSource = AgenteMaestro.Proxy.BuscarProveedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RazonSocial, NroDocumento, TipoProveedor);
                dgvProveedor.AutoResizeColumns();

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
                oProveedor = (ProveedorE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("Presione Cancelar.");
            }
        }

        //void ValidarB()
        //{
        //    if (txtRazonSocial.Text == "")
        //    {
        //        Global.MensajeComunicacion("Digite La Razon Social");
        //        Validacion = 1;
        //    }

        //    if (txtNroDocumento.Text == "")
        //    {
        //        Global.MensajeComunicacion("Digite un Numero de Documento");
        //        Validacion = 1;
        //    }
        //}

        #endregion

        #region Eventos

        private void FrmBusquedaProveedor_Load(object sender, EventArgs e)
        {
            dgvProveedor.AutoResizeColumns();
        }

        private void dgvProveedor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvProveedor, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        } 

        #endregion

    }
}
