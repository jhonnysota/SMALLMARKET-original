using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Seguridad
{
    public partial class frmUsuarioAreas : FrmMantenimientoBase
    {
        #region Constructores

        public frmUsuarioAreas()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvUsuarios, true);
            LlenarEmpresas();
            cboEmpresa_SelectionChangeCommitted(new Object(), new EventArgs());
        }

        #endregion

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<Usuario> oListaUsuario = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarEmpresas()
        {
            List<Empresa> oListaEmpresa = AgenteMaestros.Proxy.ListarEmpresa("");
            Empresa oEmpresa = new Empresa() { IdEmpresa = 0, NombreComercial = Variables.Escoger };
            ComboHelper.LlenarCombos<Empresa>(cboEmpresa, oListaEmpresa, "IdEmpresa", "RazonSocial");
        }

        void LlenarLocales(Int32 idEmpresa)
        {
            List<LocalE> oListaLocales = AgenteMaestros.Proxy.ListarLocal("", false, false, idEmpresa);
            LocalE oLocal = new LocalE() { IdLocal = 0, Nombre = Variables.Escoger };
            ComboHelper.LlenarCombos<LocalE>(cboLocal, oListaLocales, "IdLocal", "Nombre");
        }

        void LlenarAreas(Int32 idEmpresa, Int32 idLocal)
        {
            List<Area> oListaAreas = AgenteMaestros.Proxy.ListarTodasAreas(idEmpresa,idLocal);
            Area oLocal = new Area() { idArea = 0, descripcion = Variables.Escoger };
            ComboHelper.LlenarCombos<Area>(cboAreas, oListaAreas, "IdArea", "descripcion");
        }

        private bool ValidarArea(UsuarioAreasE oArea)
        {
            bool existe = false;

            foreach (UsuarioAreasE item in oListaUsuario[bsUsuarios.Position].ListaUsuarioAreas)
            {
                if (item.idEmpresa == oArea.idEmpresa && item.idLocal == oArea.idLocal && item.idArea == oArea.idArea)
                {
                    existe = true;
                    break;
                }
            }

            return existe;
        }

        #endregion

        #region Procedimientos de Usuario

        public override void Grabar()
        {
            if (bsUsuarios.Position >= 0)
            {
                bsUsuarios.EndEdit();
                bsUsuariosAreas.EndEdit();

                if (Global.MensajeConfirmacion("Desea grabar el Area") == DialogResult.Yes)
                {
                    Usuario oUsuario = AgenteSeguridad.Proxy.GrabarUsuarioArea(oListaUsuario[bsUsuarios.Position]);

                    if (oUsuario != null)
                    {
                        Global.MensajeComunicacion("Se grabó el area correctamente.");
                        dgvUsuarios.Enabled = true;
                        //base.Grabar();
                    }
                }
                else
                {
                    dgvUsuarios.Enabled = true;
                }
            }

            
        }

        public override void Buscar()
        {
            try
            {
                Int32 idEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue);
                Int32 idLocal = Convert.ToInt32(cboLocal.SelectedValue);

                bsUsuarios.DataSource = oListaUsuario = AgenteSeguridad.Proxy.ListarUsuarioPorEmpresayArea(idEmpresa,idLocal, "", "");
                bsUsuarios.ResetBindings(false);
                lblRegistrosUsuario.Text = "Usuarios " + oListaUsuario.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmUsuarioAreas_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
        }

        private void cboEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LlenarLocales(Convert.ToInt32(cboEmpresa.SelectedValue));
                Buscar();
                cboLocal_SelectionChangeCommitted(new Object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LlenarAreas(Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboLocal.SelectedValue));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvUsuarios.Enabled = false;

                if (Convert.ToInt32(cboEmpresa.SelectedValue) == 0)
                {
                    Global.MensajeFault("Debe escoger una Empresa.");
                    cboEmpresa.Focus();
                    return;
                }

                if (Convert.ToInt32(cboLocal.SelectedValue) == 0)
                {
                    Global.MensajeFault("Debe escoger un Local.");
                    cboLocal.Focus();
                    return;
                }

                UsuarioAreasE oUsuarioArea = new UsuarioAreasE()
                {
                    idPersona = oListaUsuario[bsUsuarios.Position].IdPersona,
                    idEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue),
                    idLocal = Convert.ToInt32(cboLocal.SelectedValue),
                    idArea = Convert.ToInt32(cboAreas.SelectedValue),
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                if (ValidarArea(oUsuarioArea))
                {
                    Global.MensajeComunicacion("Esta area ya esta ingresada, escoja otra.");
                    cboAreas.Focus();
                    return;
                }

                oListaUsuario[bsUsuarios.Position].ListaUsuarioAreas.Add(oUsuarioArea);
                bsUsuariosAreas.DataSource = oListaUsuario[bsUsuarios.Position].ListaUsuarioAreas;
                bsUsuariosAreas.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsUsuarios.Position > 0)
                {
                    if (bsUsuariosAreas.Position > 0)
                    {
                        oListaUsuario[bsUsuarios.Position].ListaUsuarioAreas.RemoveAt(bsUsuariosAreas.Position);
                        bsUsuariosAreas.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsUsuarios_CurrentChanged(object sender, EventArgs e)
        {

            bsUsuariosAreas.DataSource = oListaUsuario[bsUsuarios.Position].ListaUsuarioAreas;
            bsUsuariosAreas.ResetBindings(false);
            lblAreasUsuario.Text = "Areas " + oListaUsuario.Count;

        }

        #endregion
    }
}
