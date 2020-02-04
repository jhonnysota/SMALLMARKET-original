using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;

namespace ClienteWinForm.Almacen.Procesos
{
    public partial class frmRevisionLotesKardex : FrmMantenimientoBase
    {

        public frmRevisionLotesKardex(List<kardexE> ListaKardex)
        {
            InitializeComponent();

            FormatoGrid(dgvListado, true);
            bsKardex.DataSource = ListaKardex;
            bsKardex.ResetBindings(false);
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        #endregion

        #region Eventos

        private void frmRevisionLotesKardex_Load(object sender, EventArgs e)
        {

        }

        private void btEliminarLotes_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 Reg = 0;
                Int32 resp = 0;

                foreach (kardexE item in bsKardex.List)
                {
                    if (item.numDocMovAlmacen != "NO TIENE MOVIMIENTOS")
                    {
                        Reg++;
                    }
                }

                if (Reg > 0)
                {
                    if (Global.MensajeConfirmacion("Hay documentos que tienen movimientos, igualmente quiere eliminarlos...") == DialogResult.Yes)
                    {
                        resp = AgenteAlmacen.Proxy.EliminarLotesKardexXLS((List<kardexE>)bsKardex.List);
                    }
                }
                else
                {
                    resp = AgenteAlmacen.Proxy.EliminarLotesKardexXLS((List<kardexE>)bsKardex.List);
                }

                if (resp > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
