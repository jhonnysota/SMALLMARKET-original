using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Almacen
{
    public partial class frmArticuloPrecio : FrmMantenimientoBase
    {

        #region Constructor

        public frmArticuloPrecio()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        //Edición
        public frmArticuloPrecio(ArticuloPrecioE oArtPretmp)
            : this()
        {
            oArtPre = oArtPretmp;
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        ArticuloPrecioE oArtPre = null;
        Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oArtPre.idArticulo = Convert.ToInt32(txtIdArticulo.Text);
            oArtPre.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oArtPre.Precio = Convert.ToDecimal(txtPrecio.Text);
        }

        void LlenarCombos()
        {
            //////Moneda///////
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oArtPre == null)
            {
                oArtPre = new ArticuloPrecioE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                txtUsuarioRegistro.Text = oArtPre.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = oArtPre.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oArtPre.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = oArtPre.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                //txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtIdArticulo.Text = oArtPre.idArticulo.ToString();
                txtCodArticulo.Text = oArtPre.codArticulo;
                txtPrecio.Text = oArtPre.Precio.ToString();
                cboMoneda.SelectedValue = oArtPre.idMoneda;
                txtDesArt.Text = oArtPre.nomArticulo;

                txtUsuarioRegistro.Text = oArtPre.UsuarioRegistro;
                txtFechaRegistro.Text = oArtPre.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oArtPre.UsuarioModificacion;
                txtFechaModificacion.Text = oArtPre.FechaModificacion.ToString();

                //txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oArtPre != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oArtPre = AgenteAlmacen.Proxy.InsertarArticuloPrecio(oArtPre);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oArtPre = AgenteAlmacen.Proxy.ActualizarArticuloPrecio(oArtPre);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ArticuloPrecioE>(oArtPre);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmArticuloPrecio_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmBuscarArticulo oFrm = new frmBuscarArticulo(0, "E");

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
            {
                //txtCodArticulo.TextChanged -= txtCodArticulo_TextChanged;
                txtIdArticulo.Text = oFrm.Articulo.idArticulo.ToString();
                txtCodArticulo.Text = oFrm.Articulo.codArticulo;
                txtDesArt.Text = oFrm.Articulo.nomArticulo;
                //txtCodArticulo.TextChanged += txtCodArticulo_TextChanged;
            }
            else
            {
                txtIdArticulo.Text = string.Empty;
                txtCodArticulo.Text = string.Empty;
                txtDesArt.Text = string.Empty;
            }
        }

        private void txtCodArticulo_TextChanged(object sender, EventArgs e)
        {
            //txtIdArticulo.Text = String.Empty;
        }

        #endregion

    }
}
