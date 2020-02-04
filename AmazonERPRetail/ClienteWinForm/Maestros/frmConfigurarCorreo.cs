using Infraestructura;
using System;
using System.Windows.Forms;

namespace ClienteWinForm.Maestros
{
    public partial class frmConfigurarCorreo : Form
    {
        public frmConfigurarCorreo(String Correo_, String Clave_, Int32 Puerto_, String Servidor_, Boolean Ssl_)
        {
            InitializeComponent();

            txtCorreo.Text = Correo_;
            txtClave.Text = Clave_;
            txtPuerto.Text = Puerto_.ToString();
            txtServidor.Text = Servidor_;
            chkSsl.Checked = Ssl_;
        }

        #region Variables

        public String Correo = String.Empty;
        public String Clave = String.Empty;
        public Int32 Puerto = Variables.Cero;
        public String Servidor = String.Empty;
        public Boolean HabilitaSsl = false;

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
                    frmConfigurarCorreo_KeyDown(this, e);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        #endregion

        #region Variables Internas

        Int32 Movimiento;
        Int32 valX;
        Int32 valY;

        #endregion

        #region Eventos 

        private void frmConfigurarCorreo_Load(object sender, EventArgs e)
        {

        }

        private void frmConfigurarCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: //Aceptar
                    btnAceptar.PerformClick();
                    break;
                case Keys.Escape: //Salir del formulario
                    btnCancelar.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Correo = txtCorreo.Text;
            Clave = txtClave.Text;
            Puerto = Convert.ToInt32(txtPuerto.Text);
            Servidor = txtServidor.Text;
            HabilitaSsl = chkSsl.Checked;

            if (!String.IsNullOrEmpty(Puerto.ToString().Trim()))
            {
                if (Puerto == Variables.Cero)
                {
                    Global.MensajeFault("El Nro de Puerto no puede ser 0.");    
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close(); 
                }                
            }
            else
            {
                Global.MensajeFault("Tiene que ingresar el Nro de Puerto.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void labelDegradado2_MouseDown(object sender, MouseEventArgs e)
        {
            Movimiento = 1;
            valX = e.X;
            valY = e.Y;
        }

        private void labelDegradado2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movimiento == 1)
            {
                this.SetDesktopLocation(MousePosition.X - valX, MousePosition.Y - valY);
            }
        }

        private void labelDegradado2_MouseUp(object sender, MouseEventArgs e)
        {
            Movimiento = 0;
        }

        private void chkVer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVer.Checked)
            {
                txtClave.PasswordChar = '\0';
            }
            else
            {
                txtClave.PasswordChar = '*';
            }
        }

        #endregion

    }
}
