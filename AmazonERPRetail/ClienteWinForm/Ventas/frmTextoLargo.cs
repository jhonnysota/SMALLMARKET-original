using System;
using System.Windows.Forms;

using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class frmTextoLargo : Form
    {

        #region Constructores
        
        public frmTextoLargo()
        {
            InitializeComponent();
        }

        public frmTextoLargo(String Titulo)
            : this()
        {
            LblTitulo.Text = Titulo;

            if (Titulo == "Motivo de Baja")
            {
                rbTodos.Visible = true;
                rbUno.Visible = true;
            }
        } 

        #endregion

        #region Variables
        
        public String Texto = String.Empty;
        public String Tipo = String.Empty; 

        #endregion

        #region Overrides Form

        private const int CS_DROPSHADOW = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_IME_CHAR = 0x286;

            KeyEventArgs e = null;

            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);

                if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                {
                    frmTextoLargo_KeyDown(this, e);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        #endregion

        #region Eventos
        
        private void frmTextoLargo_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Texto))
            {
                txtTexto.Text = Texto;
            }

            Global.CrearToolTip(rbTodos, "Ingresar el mismo mensaje para todos los seleccionados.");
            Global.CrearToolTip(rbUno, "Ingresar mensaje uno por uno");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (LblTitulo.Text == "Motivo de Baja")
            {
                if (rbTodos.Checked)
                {
                    Tipo = "T";
                }
                else
                {
                    Tipo = "U";
                }

                if (String.IsNullOrEmpty(txtTexto.Text))
                {
                    Global.MensajeFault("Debe ingresar un motivo para la baja del documento. De lo contrario presione Cancelar");
                    return;
                }

                Texto = txtTexto.Text;
            }
            else
            {
                if (!String.IsNullOrEmpty(txtTexto.Text))
                {
                    Texto = txtTexto.Text;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Texto = String.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = txtTexto.Text.Length > 0;
        }

        private void frmTextoLargo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: //Aceptar
                    btnAceptar.PerformClick();
                    break;
                case Keys.F6: //Salir del formulario
                    btnCancelar.PerformClick();
                    break;
                default:
                    break;
            }
        } 

        #endregion

    }
}
