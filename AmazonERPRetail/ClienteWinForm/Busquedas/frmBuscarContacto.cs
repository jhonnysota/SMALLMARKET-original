using Entidades.Maestros;
using Infraestructura;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarContacto : FrmBusquedaBase
    {
        public frmBuscarContacto()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvContactos);
        }

        public frmBuscarContacto(Int32 Persona_)
            : this()
        {
            ID = Persona_;
        }


        #region Variables
        Int32 ID = 0;
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        public ProveedorContactoE oContactos = null;
        public List<ProveedorContactoE> oListaContactos = null;

        #endregion


        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListaContactos = AgenteMaestros.Proxy.ListarProveedorContacto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ID);
                bsBase.DataSource = oListaContactos;
                dgvContactos.AutoResizeColumns();

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    oContactos = (ProveedorContactoE)bsBase.Current;
                    base.Aceptar();
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos. Presione Cancelar");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion


        private void dgvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }

        private void frmBuscarContacto_Load(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
