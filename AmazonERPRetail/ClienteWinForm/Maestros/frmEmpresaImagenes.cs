using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Maestros
{
    public partial class frmEmpresaImagenes : frmResponseBase
    {

        #region Constructores
        
        public frmEmpresaImagenes()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmEmpresaImagenes(EmpresaImagenesE oEmpresaTempE, String Ruta)
            :this()
        {
            RutaImagen = Ruta;

            if (File.Exists(Ruta))
            {
                oEmpresaImagen = oEmpresaTempE;
                pbImagen.Image = Image.FromFile(Ruta);
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                oEmpresaImagen = AgenteMaestro.Proxy.ObtenerEmpresaConImagenes(oEmpresaTempE.idImagen, oEmpresaTempE.idEmpresa.Value);

                if (oEmpresaImagen.Imagen != null)
                {
                    pbImagen.Image = Global.ObtenerByteImagen(oEmpresaImagen.Imagen);
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, Ruta);
                }
            }
        } 

        #endregion

        #region Variables

        public EmpresaImagenesE oEmpresaImagen = null;
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        Boolean Actualizar = false;
        Int32 Opcion = Variables.Cero;
        String RutaImagen = String.Empty;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oEmpresaImagen == null)
            {
                oEmpresaImagen = new EmpresaImagenesE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                };

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNombre.Text = Convert.ToString(oEmpresaImagen.Nombre);
                txtExtension.Text = Convert.ToString(oEmpresaImagen.Extension);
                
                txtUsuarioRegistro.Text = oEmpresaImagen.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(oEmpresaImagen.FechaRegistro);
                txtUsuarioModificacion.Text = oEmpresaImagen.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(oEmpresaImagen.FechaModificacion);

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Aceptar()
        {
            try
            {
                if (String.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    Global.MensajeComunicacion("Debe ingresar el nombre de la imagen.");
                    return;
                }

                if (oEmpresaImagen != null)
                {
                    oEmpresaImagen.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oEmpresaImagen.Nombre = txtNombre.Text;
                    oEmpresaImagen.Extension = txtExtension.Text;
                    
                    if (Actualizar)
                    {
                        if (pbImagen.Image != null)
                        {
                            oEmpresaImagen.Imagen = Global.ObtenerImagenBytes(pbImagen.Image);
                        }
                        else
                        {
                            oEmpresaImagen.Imagen = null;
                        }
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oEmpresaImagen.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oEmpresaImagen.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oEmpresaImagen.FechaRegistro = VariablesLocales.FechaHoy;
                        oEmpresaImagen.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oEmpresaImagen.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        oEmpresaImagen.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                        oEmpresaImagen.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oEmpresaImagen.FechaModificacion = Convert.ToDateTime(txtFechaModificacion.Text);
                    }

                    base.Aceptar();
                }
                else
                {
                    Global.MensajeFault("No hay nada que actualizar. Presione Cancelar");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmEmpresaImagenes_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdBuscarImagen = new OpenFileDialog())
            {
                ofdBuscarImagen.Filter = "Archivos de Imagen(*.png)|*.png";
                ofdBuscarImagen.Title = "Buscar Imagenes";

                if (ofdBuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    Actualizar = true;
                    pbImagen.Image = Image.FromFile(ofdBuscarImagen.FileName);
                    
                    if (String.IsNullOrEmpty(txtNombre.Text.Trim()))
                    {
                        txtNombre.Text = Path.GetFileNameWithoutExtension(ofdBuscarImagen.FileName);
                    }
                    
                    txtExtension.Text = Path.GetExtension(ofdBuscarImagen.SafeFileName);
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btQuitarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (pbImagen.Image != null)
                {
                    Actualizar = true;
                    pbImagen.Image.Dispose();
                    pbImagen.Image = null;

                    if (oEmpresaImagen != null && !String.IsNullOrEmpty(oEmpresaImagen.Nombre))
                    {
                        if (!String.IsNullOrEmpty(RutaImagen))
                        {
                            if (File.Exists(RutaImagen))
                            {
                                //File.Delete(RutaImagen);
                                Global.EliminarTemporal(RutaImagen);
                            }
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
