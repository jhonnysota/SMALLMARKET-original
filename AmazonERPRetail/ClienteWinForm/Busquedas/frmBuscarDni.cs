using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ConsultasOnline;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarDni : FrmMantenimientoBase
    {
        public frmBuscarDni()
        {
            InitializeComponent();

            try
            {
                CargarImagen();
                txtNumero.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Variables

        public Reniec Informacion;
        public string DNI = string.Empty;
        bool NumIngresado = false;
        StringBuilder cad = new StringBuilder();
        StringBuilder Dni = new StringBuilder();

        #endregion

        #region Procedimientos de Usuario

        void CargarImagen()
        {
            try
            {
                if (Informacion == null)
                {
                    Informacion = new Reniec();
                }

                pbCapcha.Image = Informacion.ObtenerCapcha;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        void CargarResultado()
        {
            try
            {
                switch (Informacion.ObtenerResultado)
                {
                    case Reniec.Resultado.Ok:
                        
                        cad.Append(Informacion.Nombres.Replace("�", "Ñ"));
                        cad.Append(" ");
                        cad.Append(Informacion.ApePaterno.Replace("�", "Ñ"));
                        cad.Append(" ");
                        cad.Append(Informacion.ApeMaterno.Replace("�", "Ñ"));

                        lblDatos.Text = cad.ToString();
                        if (!string.IsNullOrEmpty(Informacion.Verificacion))
                        {
                            lblVerificacion.Text = Informacion.Verificacion;    
                        }
                        
                        btAceptar.Focus();
                        
                        break;
                    case Reniec.Resultado.NoResul:
                        lblError.Text = "No existe DNI ingresado.";
                        txtNumero.SelectAll();
                        txtNumero.Focus();
                        txtNumero.Text = string.Empty;
                        lblDatos.Text = string.Empty;
                        break;
                    case Reniec.Resultado.ErrorCapcha:
                        lblError.Text = "Ingrese la imagen correctamente.";
                        txtCapcha.SelectAll();
                        txtCapcha.Focus();
                        lblDatos.Text = string.Empty;
                        break;
                    case Reniec.Resultado.Error:
                        lblError.Text = "Error Desconocido.";
                        txtNumero.SelectAll();
                        txtNumero.Focus();
                        lblDatos.Text = string.Empty;
                        break;
                    default:
                        break;
                }

                cad = new StringBuilder();
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        void pAceptar()
        {
            if (Informacion != null)
            {
                DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        void pCancelar()
        {
            DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        string Digitos(string num)
        {
            if (Dni.Length <= 8)
            {
                Dni.Append(num);
            }

            return Dni.ToString();
        }

        void numAleatorios()
        {
            //Inicializamos la clase Random
            Random r = new Random();

            //Creamos un array que va a tener 10 elementos
            int[] numeros = new int[10];
            //El numero que se va a buscar en el array
            int numEncontrado = 0;
            //Para saber cuantas veces se ha encontrado el numero buscado
            int contador = 0;
            //Para el contador de 0
            int ceros = 0;

            //Recorremos el array y vamos asignando a cada
            //posición un número aleatorio
            for (int i = 0; i < 10; i++)
            {
                numeros[i] = r.Next(10);
                numEncontrado = numeros[i];

                for (int b = 0; b < numeros.Count(); b++)
                {
                    if (Convert.ToInt32(numeros[b]) == numEncontrado)
                    {
                        contador++;

                        if (numEncontrado != 0)
                        {
                            if (contador == 2)
                            {
                                i--;
                                break;
                            }
                        }
                        else
                        {
                            ceros++;
                            if (ceros == 1)
                            {
                                break;
                            }
                            else
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }

                contador = 0;
            }

            //Asignando a la propiedad de labels el valor del array
            num1.Text = numeros[0].ToString();
            lblNum2.Text = numeros[1].ToString();
            lblNum3.Text = numeros[2].ToString();
            lblNum4.Text = numeros[3].ToString();
            lblNum5.Text = numeros[4].ToString();
            lblNum6.Text = numeros[5].ToString();
            lblNum7.Text = numeros[6].ToString();
            lblNum8.Text = numeros[7].ToString();
            lblNum9.Text = numeros[8].ToString();
            lblNum0.Text = numeros[9].ToString();
        }

        #endregion

        #region Procedimiento Heredado

        public override void Buscar()
        {
            DNI = txtNumero.Text;

            try
            {


                if (DNI.Length != 8)
                {
                    lblError.Text = "Ingrese Dni Válido";
                    txtNumero.SelectAll();
                    txtNumero.Focus();
                    txtNumero.Text = string.Empty;
                    return;
                }

                Informacion.ObtenerInformacion(DNI, txtCapcha.Text);
                CargarResultado();
                CargarImagen();
                numAleatorios();

            }
                catch(Exception ex)
             {
                Global.MensajeError(ex.Message);        
             }
        }

        #endregion

        #region Eventos

        private void frmBuscarDni_Load(object sender, EventArgs e)
        {
            Global.CrearToolTip(pbCapcha, "Imagen Captcha.");
            Global.CrearToolTip(btAceptar, "Puede presionar F5.");
            Global.CrearToolTip(btCancelar, "Puede presionar F6.");
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
        }

        private void txtCapcha_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
        }

        private void frmBuscarDni_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    Buscar();
                    break;
                case Keys.F5:
                    pAceptar();
                    break;
                case Keys.F6:
                    pCancelar();
                    break;
                case Keys.Escape:
                    pCancelar();
                    break;
                default:
                    break;
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            pAceptar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pCancelar();
        }

        private void num1_MouseMove(object sender, MouseEventArgs e)
        {
            num1.ForeColor = Color.Orange;
        }

        private void num1_MouseLeave(object sender, EventArgs e)
        {
            num1.ForeColor = Color.Navy;
        }

        private void lblNum2_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum2.ForeColor = Color.Orange;
        }

        private void lblNum2_MouseLeave(object sender, EventArgs e)
        {
            lblNum2.ForeColor = Color.Navy;
        }

        private void lblNum3_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum3.ForeColor = Color.Orange;
        }

        private void lblNum3_MouseLeave(object sender, EventArgs e)
        {
            lblNum3.ForeColor = Color.Navy;
        }

        private void lblNum4_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum4.ForeColor = Color.Orange;
        }

        private void lblNum4_MouseLeave(object sender, EventArgs e)
        {
            lblNum4.ForeColor = Color.Navy;
        }

        private void lblNum5_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum5.ForeColor = Color.Orange;
        }

        private void lblNum5_MouseLeave(object sender, EventArgs e)
        {
            lblNum5.ForeColor = Color.Navy;
        }

        private void lblNum6_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum6.ForeColor = Color.Orange;
        }

        private void lblNum6_MouseLeave(object sender, EventArgs e)
        {
            lblNum6.ForeColor = Color.Navy;
        }

        private void lblNum7_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum7.ForeColor = Color.Orange;
        }

        private void lblNum7_MouseLeave(object sender, EventArgs e)
        {
            lblNum7.ForeColor = Color.Navy;
        }

        private void lblNum8_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum8.ForeColor = Color.Orange;
        }

        private void lblNum8_MouseLeave(object sender, EventArgs e)
        {
            lblNum8.ForeColor = Color.Navy;
        }

        private void lblNum9_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum9.ForeColor = Color.Orange;
        }

        private void lblNum9_MouseLeave(object sender, EventArgs e)
        {
            lblNum9.ForeColor = Color.Navy;
        }

        private void lblNum0_MouseMove(object sender, MouseEventArgs e)
        {
            lblNum0.ForeColor = Color.Orange;
        }

        private void lblNum0_MouseLeave(object sender, EventArgs e)
        {
            lblNum0.ForeColor = Color.Navy;
        }

        private void lklLimpiar_MouseMove(object sender, MouseEventArgs e)
        {
            lklLimpiar.LinkColor = Color.Orange;
        }

        private void lklLimpiar_MouseLeave(object sender, EventArgs e)
        {
            lklLimpiar.LinkColor = Color.Navy;
        }

        private void lblConsultar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void lklLimpiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dni = new StringBuilder();
            txtNumero.Text = string.Empty;
        }

        private void num1_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(num1.Text);
        }        

        private void lblNum2_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum2.Text);
        }

        private void lblNum3_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum3.Text);
        }

        private void lblNum4_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum4.Text);
        }

        private void lblNum5_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum5.Text);
        }

        private void lblNum6_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum6.Text);
        }

        private void lblNum7_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum7.Text);
        }

        private void lblNum8_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum8.Text);
        }

        private void lblNum9_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum9.Text);
        }

        private void lblNum0_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Digitos(lblNum0.Text);
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            NumIngresado = false;

            if (e.KeyCode > Keys.D0 || e.KeyCode < Keys.D9)
            {
                NumIngresado = true;
            }

            if (e.KeyCode > Keys.NumPad0 || e.KeyCode < Keys.NumPad9)
            {
                NumIngresado = true;
            }

            if (e.KeyCode == Keys.Back)
            {
                NumIngresado = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumIngresado == true)
            {
                e.Handled = true;
            }

            if ((e.KeyChar) == Convert.ToChar(Keys.Enter))
            {
                txtCapcha.Focus();
            }
        }

        private void lblLimpiar_Click(object sender, EventArgs e)
        {
            CargarImagen();
            txtNumero.Text = string.Empty;
            txtCapcha.Text = string.Empty;
            lblDatos.Text = string.Empty;
            txtCapcha.SelectAll();
            txtCapcha.Focus();
            numAleatorios();
            //cad = new StringBuilder();
            Dni = new StringBuilder();
        }

        #endregion

    }
}
