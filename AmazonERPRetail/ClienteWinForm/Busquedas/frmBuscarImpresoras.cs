using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarImpresoras : Form
    {
        public frmBuscarImpresoras()
        {
            InitializeComponent();
        }

        public String NombreImpresora = String.Empty;

        void CargarImpresoras()
        {
            try
            {
                foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                {
                    lblImpresoras.Items.Add(strPrinter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void frmBuscarImpresoras_Load(object sender, EventArgs e)
        {
            CargarImpresoras();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void lblImpresoras_DoubleClick(object sender, EventArgs e)
        {
            NombreImpresora = lblImpresoras.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
