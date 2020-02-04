using Entidades.Contabilidad;
using Infraestructura.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReporteConceptoGastoDetalle : FrmMantenimientoBase
    {
        public frmReporteConceptoGastoDetalle()
        {
            InitializeComponent();
            FormatoGrid(dgvPivot, true);
        }

        private void frmReporteConceptoGastoDetalle_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        public frmReporteConceptoGastoDetalle(List<VoucherItemE> oListaDetalle, string desItem)
            : this()
        {
            decimal impDebe = oListaDetalle.Sum(x => x.impDebe);
            decimal impHaber = oListaDetalle.Sum(x => x.impHaber);

            VoucherItemE oSubTotales = new VoucherItemE { impDebe = impDebe, impHaber = impHaber };
            oListaDetalle.Add(oSubTotales);

            VoucherItemE oTotales = new VoucherItemE {numDocumento="SALDO :", impDebe = (impDebe > impHaber ? impDebe - impHaber : 0), impHaber = (impHaber > impDebe ? impHaber-impDebe   : 0) };
            oListaDetalle.Add(oTotales);

            bsVoucherItem.DataSource = oListaDetalle;
            bsVoucherItem.ResetBindings(false);

            lblregistros.Text = desItem + " - " + (oListaDetalle.Count-2).ToString() + " registros";
        }

        private void dgvPivot_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= bsVoucherItem.Count - 2)
            {
                dgvPivot.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = e.CellStyle.BackColor = Color.Bisque;
            }
        }

    }
}
