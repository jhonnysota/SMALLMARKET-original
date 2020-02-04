using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Maestros;

namespace ClienteWinForm.Seguridad
{
    public partial class frmListadoUsuarios : FrmMantenimientoBase
    {

        public frmListadoUsuarios()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvUsuarios, true);
            LlenarCombo();            
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        SeguridadServiceAgent AgenteSeguridad { get { return new SeguridadServiceAgent(); } }
        List<Usuario> oListaUsuarios = null;
        Boolean Ordenar = false;

        #endregion

        #region Procedimientos

        private void LlenarCombo()
        {
            cboTipoPersona.DataSource = null;

            List<ParTabla> ListaTipoPersona = AgenteGeneral.Proxy.ListarParTablaPorGrupo(Convert.ToInt32(EnumParTabla.TipoPersona), string.Empty);
            ParTabla tipPer = new ParTabla();
            tipPer.IdParTabla = 0;
            tipPer.Nombre = Variables.Todos;
            ListaTipoPersona.Add(tipPer);

            ComboHelper.RellenarCombos<ParTabla>(cboTipoPersona, ListaTipoPersona, "IdParTabla", "Nombre", false);
            cboTipoPersona.SelectedValue = 0;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                FrmDlgPersona oFrm = new FrmDlgPersona();

                if (oFrm.ValidarIngresoVentana())
                {
                    oFrm.Enumerado = EnumTipoRolPersona.Usuario;
                    oFrm.OpcionVentana = 4;
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                if (bsUsuario.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmUsuario);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    Usuario usu = AgenteSeguridad.Proxy.RecuperarUsuarioPorCodigo(((Usuario)bsUsuario.Current).IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "S");


                    //sino existe la instancia se crea una nueva
                    oFrm = new FrmUsuario(usu, Convert.ToInt32(EnumOpcionGrabar.Actualizar));
                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
        
        public override void Buscar()
        {
            try
            {
                Int32? TipoPersona = (Convert.ToInt32(cboTipoPersona.SelectedValue) != 0) ? Convert.ToInt32(cboTipoPersona.SelectedValue) : (Nullable<int>)null;

                if (!chkIncluir.Checked)
                {
                    bsUsuario.DataSource = oListaUsuarios = AgenteSeguridad.Proxy.ListarUsuarioTodos(txtBuscar.Text, TipoPersona, false, false);
                }
                else
                {
                    bsUsuario.DataSource = oListaUsuarios = AgenteSeguridad.Proxy.ListarUsuarioTodos(txtBuscar.Text, TipoPersona, true, false);
                }

                txtBuscar.Focus();
                base.Buscar();
                BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            if (bsUsuario.Count == 0)
            {
                return;
            }

            if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
            {
                bsUsuario.DataSource = AgenteSeguridad.Proxy.CambiarEstadoUsuario(Convert.ToInt32(((Usuario)bsUsuario.Current).IdPersona), ((Usuario)bsUsuario.Current).Estado);
                Buscar();

                Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);                
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FrmUsuario oFrm = sender as FrmUsuario;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoUsuarios_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();    
            }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((bool)dgvUsuarios.Rows[e.RowIndex].Cells["Estado"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 150, 150);
                    /* 255, 102, 102 Rosado Oscuro
                     * 255, 210, 210 rosado
                     * 255,180,80 Naranja
                     * 252,222,150 Naranja Claro
                     * 196,196,225 Lila
                     * 252,242,214 Medio Crema
                     * 191,255,191 Verde Claro
                     * 185,194,73 Verde
                     * 27,193,228 Turqueza
                     * 185,185,255 lila oscuro
                     */
                }
            }
        }

        private void dgvUsuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaUsuarios != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Por Crededencial
                    if (e.ColumnIndex == dgvUsuarios.Columns["Credencial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaUsuarios = (from x in oListaUsuarios orderby x.Credencial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaUsuarios = (from x in oListaUsuarios orderby x.Credencial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Nombres
                    if (e.ColumnIndex == dgvUsuarios.Columns["NombreCompleto"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaUsuarios = (from x in oListaUsuarios orderby x.NombreCompleto ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaUsuarios = (from x in oListaUsuarios orderby x.NombreCompleto descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsUsuario.DataSource = oListaUsuarios;
            }
        }

        private void bsUsuario_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblReg.Text = "Registros " + bsUsuario.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
