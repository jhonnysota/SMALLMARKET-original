using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Maestros
{
    public partial class FrmLocal : FrmMantenimientoBase
    {

        #region Constructores

        public FrmLocal()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            LlenarCombos();
        }

        //Edición
        public FrmLocal(LocalE _Local, String _Departamento, String _Provincia, String _Distrito)
            : this()
        {
            local = _Local;
            Departamento = _Departamento;
            Provincia = _Provincia;
            Distrito = _Distrito;
        }

        //Nuevo
        public FrmLocal(Int32 idEmpresa_)
            : this()
        {
            idEmpresa = idEmpresa_;
        }

        #endregion

        #region Variables

        LocalE local = null;
        Dictionary<EnumParTabla, List<ParTabla>> listaParametro = null;
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        Int32 idEmpresa = Variables.Cero;
        String Departamento;
        String Provincia;
        String Distrito;
        Int32 Opcion = 0;

        #endregion

        #region Procedimientos Usuario

        void LlenarCombos()
        {
            List<EnumParTabla> ListaCondicion = new List<EnumParTabla>();
            ListaCondicion.Add(EnumParTabla.CondicionLocal);
            listaParametro = AgenteGenerales.Proxy.ListarParTablaPorListaGrupo(ListaCondicion);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboCondicion, listaParametro[EnumParTabla.CondicionLocal], "IdParTabla", "Nombre");
            cboCondicion.SelectedIndex = -1;

            List<UbigeoE> ListaDepartamento = AgenteMaestro.Proxy.ListarDepartamentos();
            UbigeoE CampoInicial = new UbigeoE() { Departamento = "[Escoger]" };
            ListaDepartamento.Add(CampoInicial);

            ComboHelper.LlenarCombos<UbigeoE>(cboDepartamento, ListaDepartamento, "Departamento", "Departamento");
            cboDepartamento.SelectedValue = "[Escoger]";
            cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
        }

        #endregion

        #region Procedimientos Heredados

        public override void Cancelar()
        {
            base.Cancelar();
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, false);

            if (((LocalE)bsLocal.Current).IdLocal == 0)
            {
                BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
            }

            pnlDetalle.Enabled = false;
            pnDireccion.Enabled = false;
            bFlag = false;
        }

        public override void Editar()
        {
            pnlDetalle.Enabled = true;
            pnDireccion.Enabled = true;
            //chkEstado.Enabled = true;
            bFlag = true;
            base.Editar();
        }

        public override void Grabar()
        {
            try
            {
                bsLocal.EndEdit();
                local.idUbigeo = cboDistrito.SelectedValue.ToString();

                if (cboCondicion.SelectedIndex == -1)
                {
                    local.idCondicion = 0;
                }
                else
                {
                    local.idCondicion = (int)cboCondicion.SelectedValue;
                }

                if (!ValidarGrabacion())
                {
                    return;
                }

                local.Siglas = txtSiglas.Text;

                if (local.IdLocal == 0)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        local.IdLocal = AgenteMaestro.Proxy.RecuperarMaxIdLocal(local.IdEmpresa);
                        local = AgenteMaestro.Proxy.InsertarLocal(local);

                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        LocalE mLocal = AgenteMaestro.Proxy.RecuperarLocalPorCodigo(((LocalE)bsLocal.Current).IdLocal, ((LocalE)bsLocal.Current).IdEmpresa);

                        if (mLocal != null)
                        {
                            local = AgenteMaestro.Proxy.ActualizarLocal(local);
                        }
                        else
                        {
                            local.IdLocal = AgenteMaestro.Proxy.RecuperarMaxIdLocal(local.IdEmpresa);
                            local = AgenteMaestro.Proxy.InsertarLocal(local);
                        }

                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Nuevo()
        {
            if (local == null)
            {
                local = new LocalE
                {
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    FechaModificacion = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    IdEmpresa = idEmpresa,
                    email = String.Empty,
                    idCondicion = 0
                };

                txtNombres.Focus();
                txtIdLocal.Enabled = false;

                bsLocal.DataSource = local;
                bsLocal.ResetBindings(false);

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                local.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                local.FechaModificacion = VariablesLocales.FechaHoy;

                if (!String.IsNullOrEmpty(Departamento))
                {
                    cboDepartamento.SelectedValue = Departamento;
                    cboDepartamento_SelectionChangeCommitted(new object(), new EventArgs());
                    cboProvincia.SelectedValue = Provincia;
                    cboProvincia_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboDistrito.SelectedValue = local.idUbigeo;
                }

                txtSiglas.Text = local.Siglas;
                txtNombres.Focus();
                bsLocal.DataSource = local;
                bsLocal.ResetBindings(false);

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        public override Boolean ValidarGrabacion()
        {
            String resultado = ValidarEntidad<LocalE>(local);

            if (local.IdEmpresa == 0) {
                resultado += " - " + "Debe seleccionar una empresa" + "\r\n";
            }

            if (!String.IsNullOrEmpty(resultado))
            {
                Global.MensajeComunicacion(resultado);
                return false;
            }
            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void FrmLocal_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<UbigeoE> ListaProvincias = AgenteMaestro.Proxy.ListarProvincias(cboDepartamento.SelectedValue.ToString());
                UbigeoE CampoInicial = new UbigeoE();
                CampoInicial.Provincia = "[Escoger]";
                ListaProvincias.Add(CampoInicial);
                ComboHelper.LlenarCombos<UbigeoE>(cboProvincia, ListaProvincias, "Provincia", "Provincia");

                cboProvincia.SelectedValue = "[Escoger]";
                cboProvincia_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<UbigeoE> ListaDistritos = AgenteMaestro.Proxy.ListarDistritos(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString());
                UbigeoE CampoInicial = new UbigeoE();
                CampoInicial.idUbigeo = "0";
                CampoInicial.Distrito = "[Escoger]";
                ListaDistritos.Add(CampoInicial);

                ComboHelper.LlenarCombos<UbigeoE>(cboDistrito, ListaDistritos, "idUbigeo", "Distrito");
                cboDistrito.SelectedValue = "0";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
