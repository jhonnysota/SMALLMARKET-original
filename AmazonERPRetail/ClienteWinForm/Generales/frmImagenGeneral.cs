using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Generales
{
    public partial class frmImagenGeneral : Form
    {

        #region Constructores

        public frmImagenGeneral()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Size = new Size(VariablesLocales.AnchoMdi - 35, VariablesLocales.AltoMdi - 100);

            pbImagen.Width = VariablesLocales.AnchoMdi - 75;
            pbImagen.Height = VariablesLocales.AltoMdi - 100;

        }

        public frmImagenGeneral(OrdenTrabajoServicioE Ots)
            : this()
        {
            oTrabajoServicio = Ots;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public OrdenTrabajoServicioE oTrabajoServicio = null;

        int Movimiento;
        int valX;
        int valY;
        
        String RutaImagen = string.Empty;
        String RutaBorrarImagenLocal = string.Empty;

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
                    frmImagenGeneral_KeyDown(this, e);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        #endregion

        #region Procedimientos de Usuario

        void ObtenerImagen()
        {
            try
            {
                if (oTrabajoServicio.ConImagen)
                {
                    String RutaImagenServer = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\";
                    String RutaLocal = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\";
                    string Archivo = oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;

                    if (!Directory.Exists(RutaLocal))
                    {
                        Directory.CreateDirectory(RutaLocal);
                    }

                    if (!File.Exists(RutaLocal + Archivo))
                    {
                        Byte[] ImagenDevuelta = AgenteVentas.Proxy.ObtenerImagenOt(RutaImagenServer + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension);

                        if (ImagenDevuelta != null)
                        {
                            Global.EscribirImagenEnFile(ImagenDevuelta, RutaLocal + Archivo);
                            pbImagen.Image = Global.ObtenerByteImagen(ImagenDevuelta);
                        }
                    }
                    else
                    {
                        pbImagen.Image = Image.FromFile(RutaLocal + Archivo);
                    }

                    pbImagen.SizeMode = PictureBoxSizeMode.AutoSize;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmImagenGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                Global.CrearToolTip(btBuscarImagen, "Buscar Imagenes");
                Global.CrearToolTip(btQuitarImagen, "Quitar Imagen");

                ObtenerImagen();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Movimiento = 1;
            valX = e.X;
            valY = e.Y;
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            Movimiento = 0;
        }

        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movimiento == 1)
            {
                SetDesktopLocation(MousePosition.X - valX, MousePosition.Y - valY);
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oTrabajoServicio != null)
                {
                    pbImagen.Image = null;
                    pbImagen.Dispose();
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            oTrabajoServicio.CambioImagen = false;
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void btBuscarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                RutaImagen = CuadrosDialogo.BuscarArchivo("Buscar Imagenes", "Archivos JPG (*.jpg)|*.jpg|Archivos PNG (*.png)|*.png");

                if (!String.IsNullOrWhiteSpace(RutaImagen))
                {
                    btAceptar.Enabled = true;
                    //Validando para actualizar la imagen...
                    oTrabajoServicio.CambioImagen = true;
                    oTrabajoServicio.RutaImagenServer = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\" + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;
                    oTrabajoServicio.RutaBorrarImagenLocal = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\" + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;
                    //if (String.IsNullOrWhiteSpace(oTrabajoServicio.NombreImagen.Trim()))
                    //{
                    //    oTrabajoServicio.CambioImagen = false;
                    //}
                    //else
                    //{
                    //    oTrabajoServicio.CambioImagen = true;
                    //    oTrabajoServicio.RutaImagenServer = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\" + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;
                    //    RutaBorrarImagenLocal = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\" + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;
                    //}

                    pbImagen.Image = Image.FromFile(RutaImagen);

                    if (pbImagen.Image != null)
                    {
                        pbImagen.SizeMode = PictureBoxSizeMode.AutoSize;

                        string nombreGuid = Guid.NewGuid().ToString();
                        oTrabajoServicio.NombreReal = Path.GetFileNameWithoutExtension(RutaImagen);
                        oTrabajoServicio.NombreImagen = nombreGuid;
                        oTrabajoServicio.Extension = Path.GetExtension(RutaImagen);
                        oTrabajoServicio.RutaDirectorioServer = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\";
                        oTrabajoServicio.Imagen = Global.ObtenerImagenBytes(pbImagen.Image);
                        oTrabajoServicio.ConImagen = true;
                    }
                }
                else
                {
                    oTrabajoServicio.CambioImagen = false;
                    btAceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btQuitarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (pbImagen.Image != null)
                {
                    btAceptar.Enabled = true;
                    btBuscarImagen.Enabled = false;
                    oTrabajoServicio.ConImagen = false;
                    oTrabajoServicio.RutaImagenServer = ConfigurationManager.AppSettings["LocalImagenes"] + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\" + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;
                    pbImagen.Image = null;
                    pbImagen.SizeMode = PictureBoxSizeMode.Normal;

                    oTrabajoServicio.RutaBorrarImagenLocal = @"C:\AmazonErp\Imagenes\" + VariablesLocales.SesionUsuario.Empresa.RUC + @"\OT Servicios\" + oTrabajoServicio.NombreImagen + oTrabajoServicio.Extension;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void frmImagenGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: //Aceptar
                        btAceptar.PerformClick();
                        break;
                    case Keys.Escape: //Salir del formulario
                        btCancelar.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            oTrabajoServicio.CambioImagen = false;
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void frmImagenGeneral_Resize(object sender, EventArgs e)
        {
            ////Int32 w = this.Scale.ScaleControl;
            //btAceptar.Left = (Width - btAceptar.Width);
            //btAceptar.Top = (Height - btAceptar.Height);

            //btAceptar.Location()
        } 

        #endregion

    }
}
