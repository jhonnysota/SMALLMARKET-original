using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmGenerarCheque : Form
    {
        public frmGenerarCheque()
        {
            InitializeComponent();

            //LlenarCombo();
            dtpFecGiro.Value = DateTime.Now.Date;
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        TipoCambioE oTica = null;

        //public String ValorSN = String.Empty;
        public DateTime Fecha;

        #endregion

        #region Procedimientos de Usuario

        //void LlenarCombo()
        //{
        //    cboSiNo.DataSource = Global.CargarSN();
        //    cboSiNo.ValueMember = "id";
        //    cboSiNo.DisplayMember = "Nombre";
        //}

        #endregion

        #region Eventos
        
        private void frmGenerarCheque_Load(object sender, EventArgs e)
        {

        }

        private void dtpFecGiro_ValueChanged(object sender, EventArgs e)
        {
            Fecha = ((DateTimePicker)sender).Value.Date;//.AddDays(-1);
            oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia(Variables.Dolares, Fecha.ToString("yyyyMMdd"));

            if (oTica == null)
            {
                Global.MensajeComunicacion("No existe tipo de cambio, seleccione otra fecha...");
            }
            else
            {
                txtTica.Text = oTica.valVenta.ToString("N3");
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            //ValorSN = cboSiNo.SelectedValue.ToString();
            Fecha = dtpFecGiro.Value.Date;
            DialogResult = DialogResult.OK;
        } 

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}
