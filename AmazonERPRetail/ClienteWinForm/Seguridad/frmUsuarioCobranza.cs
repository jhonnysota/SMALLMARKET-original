using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Extensores;

namespace ClienteWinForm.Seguridad
{
    public partial class frmUsuarioCobranza : FrmMantenimientoBase
    {

        public frmUsuarioCobranza()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvUsuarios, false);
            FormatoGrid(dgvTipos, false);
            LlenarEmpresas();
        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<Usuario> oListaUsuarios = null;

        #endregion

        #region Procedimientos de Usuario

        void LlenarEmpresas()
        {
            List<Empresa> oListaEmpresa = AgenteMaestro.Proxy.ListarEmpresa("");
            ComboHelper.LlenarCombos<Empresa>(cboEmpresa, oListaEmpresa, "IdEmpresa", "RazonSocial");
            oListaEmpresa = null;
        }

        List<AsignarTipoCobranzaE> LlenarTipoCobranzas(Int32 idEmpresa , Int32 idLocal)
        {
            List<AsignarTipoCobranzaE> oLista = null;
            return oLista = new List<AsignarTipoCobranzaE>(from x in oListaUsuarios[bsUsuarios.Position].ListaTipoCobranzas
                                                           where x.idEmpresa == idEmpresa
                                                           && x.idLocal == idLocal
                                                           select x).ToList();
        }

        void EditarDetalle(AsignarTipoCobranzaE oTemp)
        {
            List<AsignarTipoCobranzaE> oListaCobranzas = new List<AsignarTipoCobranzaE>(oListaUsuarios[bsUsuarios.Position].ListaTipoCobranzas);
            frmDetalleUsuarioCobranza oFrm = new frmDetalleUsuarioCobranza(oListaCobranzas, oTemp);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTipoCobranza != null)
            {
                Buscar();
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void AgregarDetalle()
        {
            try
            {
                List<AsignarTipoCobranzaE> oListaCobranzas = new List<AsignarTipoCobranzaE>(oListaUsuarios[bsUsuarios.Position].ListaTipoCobranzas);
                frmDetalleUsuarioCobranza oFrm = new frmDetalleUsuarioCobranza(oListaCobranzas, Convert.ToInt32(cboEmpresa.SelectedValue), ((Empresa)cboEmpresa.SelectedItem).RazonSocial,
                                                                                Convert.ToInt32(cboLocal.SelectedValue), ((LocalE)cboLocal.SelectedItem).Nombre,
                                                                                ((Usuario)bsUsuarios.Current).IdPersona, ((Usuario)bsUsuarios.Current).NombreCompleto);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTipoCobranza != null)
                {
                    AsignarTipoCobranzaE oCobranza = Colecciones.CopiarEntidad(oFrm.oTipoCobranza);

                    if (oCobranza != null)
                    {
                        oListaUsuarios[bsUsuarios.Position].ListaTipoCobranzas.Add(oCobranza);
                        bsUsuarios.DataSource = oListaUsuarios;
                        bsUsuarios.ResetBindings(false); 
                    }
                } 
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            Int32 resp = AgenteSeguridad.Proxy.EliminarAsignarTipoCobranza(((AsignarTipoCobranzaE)bsTipoCobranzas.Current).idEmpresa, ((AsignarTipoCobranzaE)bsTipoCobranzas.Current).idLocal,
                                                                            ((AsignarTipoCobranzaE)bsTipoCobranzas.Current).idUsuario, ((AsignarTipoCobranzaE)bsTipoCobranzas.Current).idTipoPlanilla);
            if (resp > 0)
            {
                if (Global.MensajeConfirmacion("Eliminar la fila eligida.") == DialogResult.Yes)
                {
                    oListaUsuarios[bsUsuarios.Position].ListaTipoCobranzas.Remove((AsignarTipoCobranzaE)bsTipoCobranzas.Current);
                    bsUsuarios.DataSource = oListaUsuarios;
                    bsUsuarios.ResetBindings(false);

                    Global.MensajeComunicacion("Eliminación correcta"); 
                }
            }
        }

        public override void Buscar()
        {
            try
            {
                bsUsuarios.DataSource = oListaUsuarios = AgenteSeguridad.Proxy.ListarTipoCobranzaPorUsuario();
                bsUsuarios.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmUsuarioCobranza_Load(object sender, EventArgs e)
        {
            try
            {
                Buscar();
                BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                cboEmpresa_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvUsuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void cboEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<LocalE> oListaLocales = AgenteMaestro.Proxy.ListarLocal("", false, false, Convert.ToInt32(cboEmpresa.SelectedValue));
                ComboHelper.LlenarCombos<LocalE>(cboLocal, oListaLocales, "IdLocal", "Nombre");
                oListaLocales = null;
                cboLocal_SelectionChangeCommitted(new object(), new EventArgs());
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
                bsTipoCobranzas.DataSource = LlenarTipoCobranzas(Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboLocal.SelectedValue));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsUsuarios_CurrentChanged(object sender, EventArgs e)
        {
            bsTipoCobranzas.DataSource = LlenarTipoCobranzas(Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboLocal.SelectedValue));
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvTipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsTipoCobranzas.Current != null && bsTipoCobranzas.List.Count > 0)
            {
                EditarDetalle((AsignarTipoCobranzaE)bsTipoCobranzas.Current);
            }
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (bsTipoCobranzas)
                //{

                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        } 

        #endregion

    }
}
