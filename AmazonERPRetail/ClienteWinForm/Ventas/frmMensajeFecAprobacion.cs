using System;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmMensajeFecAprobacion : Form
    {
        public frmMensajeFecAprobacion()
        {
            InitializeComponent();
        }

        #region Variables

        String Presiono = String.Empty;
        public DateTime? FechaAprobacion = null; 

        #endregion

        #region Eventos

        private void frmMensajeFecAprobacion_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = VariablesLocales.FechaHoy.ToString("d");
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            lblGlosa.Visible = true;
            dtpFecAprobacion.Visible = true;
            Presiono = "N";
        }

        private void btSi_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Presiono))
            {
                FechaAprobacion = Convert.ToDateTime(lblFechaActual.Text);
            }

            if (Presiono == "N")
            {
                FechaAprobacion = dtpFecAprobacion.Value.Date;
            }

            if (MessageBox.Show(String.Format("La Fecha de Aprobación {0} repercutirá al generar la Cta.Cte. y el Asiento Contable. Desea continuar...", FechaAprobacion.Value.ToString("d")), "Aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void frmMensajeFecAprobacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            //FechaAprobacion = null;
        } 

        #endregion
    }
}
