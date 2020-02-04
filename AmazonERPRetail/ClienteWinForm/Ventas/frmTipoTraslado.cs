using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmTipoTraslado : FrmMantenimientoBase
    {

        #region Constructor

        public frmTipoTraslado()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public frmTipoTraslado(Int32 idTraslado)
            :this()
        {
            oTipoTraslado = AgenteVentas.Proxy.ObtenerTipoTraslado(idTraslado);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        TipoTrasladoE oTipoTraslado = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oTipoTraslado.idTraslado = Convert.ToInt32(txtIdTraslado.Text);
            oTipoTraslado.desTraslado = txtDes.Text;
            oTipoTraslado.codSunat = txtSunat.Text;
            oTipoTraslado.codFmtp = Convert.ToInt32(CODNiv.Value);

            oTipoTraslado.flagFact = chkFactura.Checked;
            oTipoTraslado.flagCtaCte = chkCuenta.Checked;
            oTipoTraslado.PonerCeroVenta = chkVen.Checked;
            oTipoTraslado.indAlmacen = chkAlm.Checked;
            oTipoTraslado.codSunatOpe = txtCodOperacion.Text.Trim();

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oTipoTraslado.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oTipoTraslado.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oTipoTraslado == null)
            {
                oTipoTraslado = new TipoTrasladoE();
                txtIdTraslado.Text = "0";
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdTraslado.Text = Convert.ToString(oTipoTraslado.idTraslado);
                txtDes.Text = oTipoTraslado.desTraslado;
                txtSunat.Text = oTipoTraslado.codSunat;
                CODNiv.Value = Convert.ToInt32(oTipoTraslado.codFmtp);
                chkFactura.Checked = oTipoTraslado.flagFact;
                chkCuenta.Checked = oTipoTraslado.flagCtaCte;
                chkVen.Checked = oTipoTraslado.PonerCeroVenta;
                chkAlm.Checked = oTipoTraslado.indAlmacen;
                txtCodOperacion.Text = oTipoTraslado.codSunatOpe;
                txtDesOperacion.Text = oTipoTraslado.desCodSunatOpe;
                chkEsta.Checked = oTipoTraslado.indEstado;

                txtUsuRegistra.Text = oTipoTraslado.UsuarioRegistro;
                txtRegistro.Text = oTipoTraslado.FechaRegistro.ToString();
                txtUsuModifica.Text = oTipoTraslado.UsuarioModificacion;
                txtModifica.Text = oTipoTraslado.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

                if (chkEsta.Checked)
                {
                    chkEsta.Text = "ACTIVO";
                }
                else
                {
                    chkEsta.Text = "ANULADO";
                }
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oTipoTraslado != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oTipoTraslado = AgenteVentas.Proxy.InsertarTipoTraslado(oTipoTraslado);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oTipoTraslado = AgenteVentas.Proxy.ActualizarTipoTraslado(oTipoTraslado);
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
            String Respuesta = ValidarEntidad<TipoTrasladoE>(oTipoTraslado);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmTipoTraslado_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCodigoSunat oFrm = new frmBuscarCodigoSunat();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOperacionSunat != null)
                {
                    txtCodOperacion.Text = oFrm.oOperacionSunat.EquivalenciaSunat;
                    txtDesOperacion.Text = oFrm.oOperacionSunat.Nombre;
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
