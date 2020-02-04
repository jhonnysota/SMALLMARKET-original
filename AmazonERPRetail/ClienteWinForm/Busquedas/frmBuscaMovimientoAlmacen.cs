using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscaMovimientoAlmacen : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscaMovimientoAlmacen()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvMovAlm);
        }

        /// <summary>
        /// Para las busquedas de los ingresos de almacen
        /// </summary>
        /// <param name="tipMovimiento_"></param>
        /// <param name="idAlmacen_"></param>
        public frmBuscaMovimientoAlmacen(Int32 tipMovimiento_, Int32 idAlmacen_)
            :this()
        {
            tipMovimiento = tipMovimiento_;
            idAlmacen = idAlmacen_;
        }

        /// <summary>
        /// Para la hoja de costo
        /// </summary>
        /// <param name="MovimientosAlmacen"></param>
        public frmBuscaMovimientoAlmacen(List<MovimientoAlmacenE> MovimientosAlmacen, String Tipo_)
            :this()
        {
            oListaMovimientos = MovimientosAlmacen;
            Tipo = Tipo_;
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public MovimientoAlmacenE eMovAlmacen = null;
        List<MovimientoAlmacenE> oListaMovimientos = null;
        Int32 tipMovimiento;
        Int32 idAlmacen;
        String Tipo = "B"; //B = Busquedas H = Hoja de Costo

        #endregion

        #region Procedimientos Heredados

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                eMovAlmacen = (MovimientoAlmacenE)bsBase.Current;
                base.Aceptar();
            }
        }

        protected override void Buscar()
        {
            try
            {
                if (Tipo == "B")
                {
                    bsBase.DataSource = AgenteAlmacen.Proxy.ListarMovEgresosPorAsociar(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipMovimiento, idAlmacen); 
                }
                else
                {
                    bsBase.DataSource = oListaMovimientos;
                    dgvMovAlm.Columns[1].Visible = false;
                }

                bsBase.ResetBindings(false);
                dgvMovAlm.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            base.Buscar();
        }

        #endregion

        #region Eventos

        private void frmBuscaMovimientoAlmacen_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvMovAlm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }   
        }

        private void dgvMovAlm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                EstiloCabeceras(dgvMovAlm, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        #endregion
       
    }
}
