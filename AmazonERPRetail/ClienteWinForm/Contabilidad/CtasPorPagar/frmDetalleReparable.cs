using System;
using System.Windows.Forms;

using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmDetalleReparable : Form
    {

        #region Constructores

        public frmDetalleReparable()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            LlenarCombos();
        }

        public frmDetalleReparable(String indReparable_, Int32 idConceptoRep_, String desReferenciaRep_)
            :this()
        {
            indReparable = indReparable_;
            idConceptoRep = idConceptoRep_;
            desReferenciaRep = desReferenciaRep_;
        } 

        #endregion

        #region Variables

        public String indReparable = String.Empty;
        public Int32 idConceptoRep = 0;
        public String desReferenciaRep = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Si es Reparable
            cboReparable.DataSource = Global.CargarTipoReparable();
            cboReparable.ValueMember = "id";
            cboReparable.DisplayMember = "Nombre";

            // Conceptos reparables
            cboConceptoReparable.DataSource = Global.CargarConceptosReparable();
            cboConceptoReparable.ValueMember = "id";
            cboConceptoReparable.DisplayMember = "Nombre";
        }

        void LlenarDatos()
        {
            cboReparable.SelectedValue = indReparable;
            cboReparable_SelectionChangeCommitted(new object(), new EventArgs());
            cboConceptoReparable.SelectedValue = idConceptoRep;
            txtRefRepa.Text = desReferenciaRep;
        }

        #endregion

        #region Eventos

        private void frmDetalleReparable_Load(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void cboReparable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboReparable.SelectedValue.ToString() == EnumReparable.R.ToString())
            {
                cboConceptoReparable.Enabled = true;
                txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                cboConceptoReparable.SelectedValue = Variables.Cero;
                cboConceptoReparable.Enabled = false;
                txtRefRepa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                indReparable = cboReparable.SelectedValue.ToString();
                idConceptoRep = Convert.ToInt32(cboConceptoReparable.SelectedValue);
                desReferenciaRep = txtRefRepa.Text.Trim();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
