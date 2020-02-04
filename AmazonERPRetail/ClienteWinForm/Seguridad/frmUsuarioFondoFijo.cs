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
    public partial class frmUsuarioFondoFijo : FrmMantenimientoBase
    {

        public frmUsuarioFondoFijo()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvUsuarios, false);
            FormatoGrid(dgvFondoFijo, false);
            LlenarCombos();
        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<Usuario> oListaUsuarios = null;
        Boolean Ordenar = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<Empresa> oListaEmpresa = AgenteMaestro.Proxy.ListarEmpresa("");
            ComboHelper.LlenarCombos<Empresa>(cboEmpresa, oListaEmpresa, "IdEmpresa", "RazonSocial");
            oListaEmpresa = null;
        }

        List<UsuarioFondoFijoE> LlenarTipoFondos(Int32 idEmpresa)
        {
            //List<UsuarioFondoFijoE> oLista = null;
            return new List<UsuarioFondoFijoE>(from x in oListaUsuarios[bsUsuarios.Position].ListaUsuarioFondoFijo
                                               where x.idEmpresa == idEmpresa
                                               select x).ToList();
        }

        void EditarDetalle(UsuarioFondoFijoE oTemp)
        {
            List<UsuarioFondoFijoE> oListaCobranzas = new List<UsuarioFondoFijoE>(oListaUsuarios[bsUsuarios.Position].ListaUsuarioFondoFijo);
            frmDetalleUsuarioFondoFijo oFrm = new frmDetalleUsuarioFondoFijo(oListaCobranzas, oTemp);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTipoFondo != null)
            {
                Buscar();
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                bsUsuarios.DataSource = oListaUsuarios = AgenteSeguridad.Proxy.ListarFondosFijosPorUsuario();
                bsUsuarios.ResetBindings(false);
                Ordenar = false;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            List<UsuarioFondoFijoE> oListaFondoFijo = new List<UsuarioFondoFijoE>(oListaUsuarios[bsUsuarios.Position].ListaUsuarioFondoFijo);
            frmDetalleUsuarioFondoFijo oFrm = new frmDetalleUsuarioFondoFijo(oListaFondoFijo, Convert.ToInt32(cboEmpresa.SelectedValue), ((Empresa)cboEmpresa.SelectedItem).RazonSocial,
                                                                            ((Usuario)bsUsuarios.Current).IdPersona, ((Usuario)bsUsuarios.Current).NombreCompleto);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTipoFondo != null)
            {
                UsuarioFondoFijoE oTipoFondo = Colecciones.CopiarEntidad(oFrm.oTipoFondo);

                if (oTipoFondo != null)
                {
                    oListaUsuarios[bsUsuarios.Position].ListaUsuarioFondoFijo.Add(oTipoFondo);
                    bsUsuarios.DataSource = oListaUsuarios;
                    bsUsuarios.ResetBindings(false);
                }
            }
        }

        public override void QuitarDetalle()
        {
            Int32 resp = AgenteSeguridad.Proxy.EliminarUsuarioFondoFijo(((UsuarioFondoFijoE)bsFondoFijo.Current).idEmpresa, ((UsuarioFondoFijoE)bsFondoFijo.Current).idPersona, ((UsuarioFondoFijoE)bsFondoFijo.Current).TipoFondo);

            if (resp > 0)
            {
                if (Global.MensajeConfirmacion("Eliminar la fila eligida.") == DialogResult.Yes)
                {
                    oListaUsuarios[bsUsuarios.Position].ListaUsuarioFondoFijo.Remove((UsuarioFondoFijoE)bsFondoFijo.Current);
                    bsUsuarios.DataSource = oListaUsuarios;
                    bsUsuarios.ResetBindings(false);

                    Global.MensajeComunicacion("Eliminación correcta");
                }
            }
        }

        #endregion

        #region Eventos

        private void frmUsuarioFondoFijo_Load(object sender, EventArgs e)
        {
            try
            {
                Buscar();
                BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                //cboEmpresa_SelectionChangeCommitted(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsUsuarios_CurrentChanged(object sender, EventArgs e)
        {
            bsFondoFijo.DataSource = LlenarTipoFondos(Convert.ToInt32(cboEmpresa.SelectedValue));
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

        private void dgvFondoFijo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsFondoFijo.Current != null && bsFondoFijo.List.Count > 0)
            {
                EditarDetalle((UsuarioFondoFijoE)bsFondoFijo.Current);
            }
        }

        private void dgvUsuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (oListaUsuarios != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (e.ColumnIndex == dgvUsuarios.Columns["NombreCompuesto"].Index)
                        {
                            if (Ordenar)
                            {
                                oListaUsuarios = (from x in oListaUsuarios orderby x.NombreCompuesto ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                oListaUsuarios = (from x in oListaUsuarios orderby x.NombreCompuesto descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        if (e.ColumnIndex == dgvUsuarios.Columns["NroDocumento"].Index)
                        {
                            if (Ordenar)
                            {
                                oListaUsuarios = (from x in oListaUsuarios orderby x.NroDocumento ascending select x).ToList();
                                Ordenar = false;
                            }
                            else
                            {
                                oListaUsuarios = (from x in oListaUsuarios orderby x.NroDocumento descending select x).ToList();
                                Ordenar = true;
                            }
                        }

                        bsUsuarios.DataSource = oListaUsuarios;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VariablesLocales.BuscarCadenaGrid(txtBusqueda.Text, "", dgvUsuarios);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
