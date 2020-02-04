using System;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmPuntoVentasPrintPrevio : Form
    {

        public frmPuntoVentasPrintPrevio()
        {
            InitializeComponent();
        }

        public frmPuntoVentasPrintPrevio(string documento)
            : this()
        {
            TxtPrevio.Text = documento;
        }

        private void FrmPuntoVentasPrintPrevio_Load(object sender, EventArgs e)
        {

        }

        private void BtImprimir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
