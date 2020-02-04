using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using ClienteWinForm.Maestros.Busqueda;

namespace ClienteWinForm.Maestros
{
    public partial class frmCCostos : FrmMantenimientoBase
    {

        #region Constructor

        //Nuevo
        public frmCCostos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        //Edición
        public frmCCostos(Int32 idEmpresa, String idCCostos)
            : this()
        {
            oCCostos = AgenteMaestros.Proxy.ObtenerCCostos(idEmpresa, idCCostos);
        }
        
        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        CCostosE oCCostos = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboCCosto.DataSource = Global.CargarTipoCCosto();
            cboCCosto.ValueMember = "id";
            cboCCosto.DisplayMember = "Nombre";

            cboCCosto.SelectedIndex = 1;
        }

        void GuardarDatos()
        {
            oCCostos.idCCostosSup = txtIdCCosSup.Text.Trim();

            if (Convert.ToInt32(NUDNiv.Value) == 1)
            {
                oCCostos.idCCostos = txtIdCCos.Text.Trim();
            }
            else
            {
                oCCostos.idCCostos = txtIdCCosSup.Text.Trim() + txtIdCCos.Text.Trim();
            }

            oCCostos.tipoCCosto = Convert.ToString(cboCCosto.SelectedValue);
            oCCostos.desCCostos = txtDesCCos.Text;
            oCCostos.numNivel = Convert.ToInt32(NUDNiv.Value);
            oCCostos.indBaja = false;
            oCCostos.idSistema = 1;
            oCCostos.AbrevCCostos = txtAbrevCostos.Text;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oCCostos.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oCCostos.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BuscarGrupoOpcion()
        {
            FrmCCostosOpcionArbol frm = new FrmCCostosOpcionArbol();

            if (frm.ShowDialog() == DialogResult.OK && frm.Ccostos != null)
            {
                txtIdCCosSup.Text = frm.Ccostos.idCCostos;
                NUDNiv.Value = Convert.ToInt32(frm.Ccostos.numNivel);
                NUDNiv.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtIdCCos.Focus();
            }
            else
            {
                NUDNiv.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
            }
        } 

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oCCostos == null)
            {
                oCCostos = new CCostosE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idSistema = 1
                };

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtIdCCosSup.Text = oCCostos.idCCostosSup;
                txtAbrevCostos.Text = oCCostos.AbrevCCostos;

                if (Convert.ToInt32(oCCostos.numNivel) == 1)
                {
                    txtIdCCos.Text = oCCostos.idCCostos;
                }
                else
                {
                    Boolean Banderita = (oCCostos.idCCostos.IndexOf(oCCostos.idCCostosSup) >= 0);

                    if (Banderita)
                    {
                        txtIdCCos.Text = oCCostos.idCCostos.Substring(oCCostos.idCCostosSup.Length, oCCostos.idCCostos.Length - oCCostos.idCCostosSup.Length);
                    }
                    else
                    {
                        txtIdCCos.Text = oCCostos.idCCostos;
                    }
                }

                cboCCosto.SelectedValue = oCCostos.tipoCCosto;
                txtDesCCos.Text = oCCostos.desCCostos;
                NUDNiv.Value = Convert.ToInt32(oCCostos.numNivel);

                txtUsuRegistra.Text = oCCostos.UsuarioRegistro;
                txtRegistro.Text = oCCostos.FechaRegistro.ToString();
                txtUsuModifica.Text = oCCostos.UsuarioModificacion;
                txtModifica.Text = oCCostos.FechaModifica.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oCCostos != null)
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
                            oCCostos = AgenteMaestros.Proxy.InsertarCCostos(oCCostos);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oCCostos = AgenteMaestros.Proxy.ActualizarCCostos(oCCostos);
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
            String Respuesta = ValidarEntidad<CCostosE>(oCCostos);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos
        
        private void frmCCostos_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            BuscarGrupoOpcion();
        }

        #endregion

    }
}
