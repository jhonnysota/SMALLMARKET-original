using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Maestros
{
    public partial class frmArticuloEstruc : FrmMantenimientoBase
    {

        #region Constructores

        public frmArticuloEstruc()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        //Edición
        public frmArticuloEstruc(ArticuloEstrucE Articulo)
            : this()
        {
            oArticuloEstruc = Articulo;
        }

        //Nuevo
        public frmArticuloEstruc(Int32 TipoArticulo2)
            : this()
        {
            TipoDeProducto = TipoArticulo2;
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }       
        ArticuloEstrucE oArticuloEstruc = null;
        ArticuloEstrucE oArticuloEstrucAnte = null;
        Int32 TipoDeProducto = 0;
        Int32 Opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboIndNivel.DataSource = Global.CargarSN();
            cboIndNivel.ValueMember = "id";
            cboIndNivel.DisplayMember = "Nombre";

            List<ParTabla> oListaTipoArticulo = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            oListaTipoArticulo.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });

            ComboHelper.RellenarCombos<ParTabla>(cboArt, (from x in oListaTipoArticulo orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);
        }

        void GuardarDatos()
        {
            //oArticuloEstruc.idTipoArticulo = Convert.ToInt32(cboArt.SelectedValue.ToString());
            //oArticuloEstruc.numNivel = Convert.ToInt32(NumNivel.Value);
            //oArticuloEstruc.desNivel = txtDes.Text;
            //oArticuloEstruc.numLongitud = Convert.ToInt32(txtLong.Text);
            //oArticuloEstruc.indUltimoNivel = cboIndNivel.SelectedValue.ToString();

            oArticuloEstruc = new ArticuloEstrucE() 
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                idTipoArticulo = Convert.ToInt32(cboArt.SelectedValue.ToString()),
                numNivel = Convert.ToInt32(NumNivel.Value),
                desNivel = txtDes.Text,
                numLongitud = Convert.ToInt32(txtLong.Text),
                indUltimoNivel = cboIndNivel.SelectedValue.ToString(),
                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
            };
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oArticuloEstruc == null)
            {
                oArticuloEstruc = new ArticuloEstrucE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    fechaRegistro = VariablesLocales.FechaHoy,
                    fechaModificacion = VariablesLocales.FechaHoy
                };

                cboArt.SelectedValue = TipoDeProducto;
                txtUsuRegistra.Text = oArticuloEstruc.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = oArticuloEstruc.fechaRegistro.ToString();
                txtUsuModifica.Text = oArticuloEstruc.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = oArticuloEstruc.fechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboArt.SelectedValue = Convert.ToInt32(oArticuloEstruc.idTipoArticulo.ToString());

                NumNivel.Value = Convert.ToInt32(oArticuloEstruc.numNivel);
                txtDes.Text = oArticuloEstruc.desNivel;
                txtLong.Text = Convert.ToString(oArticuloEstruc.numLongitud);
                cboIndNivel.SelectedValue = oArticuloEstruc.indUltimoNivel.ToString();

                txtUsuRegistra.Text = oArticuloEstruc.UsuarioRegistro;
                txtFechaRegistro.Text = oArticuloEstruc.fechaRegistro.ToString();
                txtUsuModifica.Text = oArticuloEstruc.UsuarioModificacion;
                txtModifica.Text = oArticuloEstruc.fechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                oArticuloEstrucAnte = oArticuloEstruc;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oArticuloEstruc != null)
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
                            oArticuloEstruc = AgenteMaestros.Proxy.GrabarArticuloEstruc(oArticuloEstruc, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oArticuloEstruc = AgenteMaestros.Proxy.GrabarArticuloEstruc(oArticuloEstruc, EnumOpcionGrabar.Actualizar, oArticuloEstrucAnte);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
      
        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ArticuloEstrucE>(oArticuloEstruc);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmArticuloEstruc_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        } 

        #endregion

    }
}
