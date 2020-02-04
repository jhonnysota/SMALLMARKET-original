using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Almacen.Reportes
{
    public partial class frmListadoArticuloServReporteDetalle : FrmMantenimientoBase
    {

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<MovimientoAlmacenE> oListaMovimientos = new List<MovimientoAlmacenE>();
        int idArticulo = 0;

        #endregion
                

        #region Constructor

        public frmListadoArticuloServReporteDetalle(int idArticulo_)
            :this()
        {
            idArticulo = idArticulo_;
        }

        private void frmEntradaAlmacenes_Load(object sender, EventArgs e)
        {
            try
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                Grid = true;
                                
                int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                if (idArticulo > 0)
                {
                    oListaMovimientos = AgenteAlmacen.Proxy.ListarMovimientoAlmacenPorArticulo(idEmpresa, idArticulo);
                }


                bsMovimientoAlmacen.DataSource = (from x in oListaMovimientos orderby x.idDocumentoAlmacen  select x).ToList();
                bsMovimientoAlmacen.ResetBindings(false);

                if (oListaMovimientos.Count > 0)
                {
                    lblregistros.Text = "Movimientos - " + bsMovimientoAlmacen.Count.ToString() + " Registros";
                }
                else
                {
                    lblregistros.Text = "0 Registros";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public frmListadoArticuloServReporteDetalle()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            FormatoGrid(dgvRegistrosEntrada, true, false, 30);
        } 

        #endregion

        private void dgvRegistrosEntrada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

    }   
}
