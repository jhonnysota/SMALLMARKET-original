using Entidades.Contabilidad;
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
    public partial class frmBuscarCuentasSunat : FrmBusquedaBase
    {
        public frmBuscarCuentasSunat()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCuentasSunmat);
        }

        public frmBuscarCuentasSunat(List<PlanCuentasSunatE>  oplancuentasnew)
            :this()
        {
            oPlancuentasSunat = oplancuentasnew;
        }

        public frmBuscarCuentasSunat(String ListaCuentas)
           : this()
        {
            Cuentas = ListaCuentas;
        }


        #region Variables
        ContabilidadServiceAgent AgenteMaestros { get { return new ContabilidadServiceAgent(); } }
        public PlanCuentasSunatE oPlancuentasSunatEN = null;
        public List<PlanCuentasSunatE> oPlancuentasSunat = null;
        String Cuentas = String.Empty;

        #endregion


        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {

                String CodCuentasunat = txtRazonSocial.Text;
                String descripcion = txtNroDocumento.Text;

                if (oPlancuentasSunat != null)
                {
                    foreach (PlanCuentasSunatE item in oPlancuentasSunat)
                    {
                        CodCuentasunat = item.codCuentaSunat;
                        descripcion = item.Descripcion;
                    }
                }
                else if (Cuentas != String.Empty)
                {
                    CodCuentasunat = Cuentas;
                    descripcion = Cuentas;
                }

                

                oPlancuentasSunat = AgenteMaestros.Proxy.BuscarPlanCuentasSunat(CodCuentasunat, descripcion);              

                bsBase.DataSource = oPlancuentasSunat;
                dgvCuentasSunmat.AutoResizeColumns();
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
                    oPlancuentasSunatEN = (PlanCuentasSunatE)bsBase.Current;
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

        private void frmBuscarCuentasSunat_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvCuentasSunmat_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }
    }
}
