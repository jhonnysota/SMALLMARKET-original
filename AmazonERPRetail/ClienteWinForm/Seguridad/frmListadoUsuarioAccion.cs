using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Seguridad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Seguridad
{
    public partial class frmListadoUsuarioAccion : FrmMantenimientoBase
    {

        public frmListadoUsuarioAccion()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvListadoUsuarioAcciones, false);
        }

        #region Variables

        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        List<UsuarioAccionE> ListaPrincipal = null;
        List<UsuarioAccionE> ListaFaltantes = null;

        #endregion

        #region Procedimientos

        void LlenarEmpresas()
        {
            //Empresas
            List<Empresa> oListaEmpresa = AgenteMaestros.Proxy.ListarEmpresa("");
            oListaEmpresa.Add(new Empresa() { IdEmpresa = 0, RazonSocial = Variables.Escoger });
            ComboHelper.LlenarCombos<Empresa>(cboEmpresas, oListaEmpresa.OrderBy(x => x.IdEmpresa).ToList(), "IdEmpresa", "RazonSocial");

            oListaEmpresa = null;
        }

        void LlenarUsuarios()
        {
            //Usuarios
            List<UsuarioEmpresaLocal> oListaUsuarios = AgenteSeguridad.Proxy.RecuperarUsuarioEmpresaLocalPorEmpresa(Convert.ToInt32(cboEmpresas.SelectedValue));
            ComboHelper.LlenarCombos<UsuarioEmpresaLocal>(cboUsuarios, oListaUsuarios, "IdPersona", "NombreUsuario");

            if (oListaUsuarios.Count > 1)
            {
                cboUsuarios.Enabled = true;
            }
            else
            {
                cboUsuarios.Enabled = false;
            }

            oListaUsuarios = null;
        }

        void LlenaOpciones(List<UsuarioAccionE> ListaTmp, UsuarioAccionE ItemOpcion)
        {
            if ((from x in ListaTmp where x.GrupoOpcion == ItemOpcion.idOpcion select x).Count() > 0)
            {
                foreach (UsuarioAccionE item in (from x in ListaTmp where x.GrupoOpcion == ItemOpcion.idOpcion orderby x.Orden select x).ToList())
                {
                    ListaPrincipal.Add(item);
                    LlenaOpciones(ListaTmp, item);
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Editar()
        {
            UsuarioAccionE current = (UsuarioAccionE)bsUsuarioAccion.Current;

            if (current != null)
            {
                if (current.TomarOpcion)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUsuarioAccion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new FrmUsuarioAccion((UsuarioAccionE)bsUsuarioAccion.Current, (Empresa)cboEmpresas.SelectedItem, (UsuarioEmpresaLocal)cboUsuarios.SelectedItem)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
                else
                {
                    Global.MensajeAdvertencia("Solo puede colocar Opciones de Mantenimiento a las opciones finales");
                }
            }
        }

        public override void Buscar()
        {
            try
            {
                if (cboEmpresas.SelectedValue != null && cboUsuarios.SelectedValue != null)
                {
                    ListaPrincipal = new List<UsuarioAccionE>();
                    List<UsuarioAccionE> ListaOpciones = AgenteSeguridad.Proxy.ListarUsuarioAccion(Convert.ToInt32(cboUsuarios.SelectedValue), Convert.ToInt32(cboEmpresas.SelectedValue));

                    if (ListaOpciones.Count > 0)
                    {
                        foreach (UsuarioAccionE itemGrupo in (from x in ListaOpciones where x.GrupoOpcion == 0 orderby x.Orden select x).ToList())
                        {
                            ListaPrincipal.Add(itemGrupo);
                            LlenaOpciones(ListaOpciones, itemGrupo);
                        }
                    }

                    bsUsuarioAccion.DataSource = ListaPrincipal;
                    bsUsuarioAccion.ResetBindings(false);

                    if (ListaPrincipal.Count > 0)
                    {
                        ListaFaltantes = new List<UsuarioAccionE>(ListaPrincipal.Where(x => x.ItemFaltante == true));
                        btFaltantes.Enabled = ListaFaltantes.Count > 0;
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene escoger una empresa y un usuario.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmUsuarioAccion oFrm = sender as FrmUsuarioAccion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoUsuarioAccion_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
            LlenarEmpresas();
        }

        private void cboEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboEmpresas.SelectedValue != null)
                {
                    LlenarUsuarios();
                    cboUsuarios_SelectionChangeCommitted(new Object(), new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListadoUsuarioAcciones_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsUsuarioAccion_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsUsuarioAccion.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListadoUsuarioAcciones_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((int)dgvListadoUsuarioAcciones.Rows[e.RowIndex].Cells["GrupoOpcion"].Value == 0 && (Boolean)dgvListadoUsuarioAcciones.Rows[e.RowIndex].Cells["TomarOpcion"].Value == false)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 230, 153);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(38, 38, 38);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255);
                        e.CellStyle.Font = new Font(dgvListadoUsuarioAcciones.DefaultCellStyle.Font, FontStyle.Bold);
                    }
                }

                if ((int)dgvListadoUsuarioAcciones.Rows[e.RowIndex].Cells["GrupoOpcion"].Value != 0 && (Boolean)dgvListadoUsuarioAcciones.Rows[e.RowIndex].Cells["TomarOpcion"].Value == false)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 242, 204);
                        //e.CellStyle.SelectionBackColor = Color.FromArgb(38, 38, 38);
                        //e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255);
                        //e.CellStyle.Font = new Font(dgvListadoUsuarioAcciones.DefaultCellStyle.Font, FontStyle.Italic);
                        e.CellStyle.Font = new Font(dgvListadoUsuarioAcciones.DefaultCellStyle.Font, FontStyle.Regular);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btFaltantes_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (UsuarioAccionE item in ListaFaltantes)
                {
                    item.idAccion = 1; //Control Total por defecto
                    item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }

                if (ListaFaltantes.Count > 0)
                {
                    if (Global.MensajeConfirmacion("Se van a grabar los Items faltantes, continuar??") == DialogResult.Yes)
                    {
                        String resp = AgenteSeguridad.Proxy.GrabarUsuarioAccion(ListaFaltantes, EnumOpcionGrabar.Insertar);
                        ListaFaltantes = null;
                        Buscar();
                        Global.MensajeComunicacion(resp);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
