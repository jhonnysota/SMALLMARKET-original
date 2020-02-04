using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBusquedaEmpresaConcar : FrmBusquedaBase
    {

        #region Constructor

        public frmBusquedaEmpresaConcar()
        {
            Global.AjustarResolucion(this);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            this.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgEmp);
        }
        
        #endregion

        #region Variables

        public EmpresaConcarE empresa = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            bsBase.DataSource = new ContabilidadServiceAgent().Proxy.ListarEmpresaConcar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                empresa = (EmpresaConcarE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeFault("No existen datos. Presione cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void dgEmp_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgEmp, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsBase.Count > Variables.Cero)
            {
                Aceptar();
            }
        }
        
        #endregion

    }
}
