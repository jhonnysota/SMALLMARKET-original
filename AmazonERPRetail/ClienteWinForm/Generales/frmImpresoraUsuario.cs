using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Generales
{
    public partial class frmImpresoraUsuario : FrmMantenimientoBase
    {

        #region Constructores

        public frmImpresoraUsuario()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvEtiquetas, true);
        }

        public frmImpresoraUsuario(UsuarioImpresorasE ImpresonaUsuario_)
            :this()
        {
            ImpresoraUsuario = AgenteGenerales.Proxy.ObtenerUsuarioImpresoras(ImpresonaUsuario_.idImpresora, Convert.ToInt32(ImpresonaUsuario_.idPersona), "S");
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        UsuarioImpresorasE ImpresoraUsuario = null;

        #endregion

        #region Procedimiento de Usuario

        void DatosGrabacion()
        {
            ImpresoraUsuario.idPersona = VariablesLocales.SesionUsuario.IdPersona;
            ImpresoraUsuario.Descripcion = txtDescripcion.Text;
            ImpresoraUsuario.PorDefecto = chkPorDefecto.Checked;
            ImpresoraUsuario.EsMatricial = chkMatricial.Checked;
            ImpresoraUsuario.ParaTicket = chkticket.Checked;
            ImpresoraUsuario.ParaBarras = chkBarras.Checked;

            if (String.IsNullOrEmpty(txtItem.Text.Trim()))
            {
                ImpresoraUsuario.UsuarioRegistro = txtUsuarioReg.Text;
            }
            else
            {
                ImpresoraUsuario.UsuarioModificacion = txtUsuarioMod.Text;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (ImpresoraUsuario == null)
            {
                ImpresoraUsuario = new UsuarioImpresorasE();
                
                txtUsuarioReg.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaReg.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaMod.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtItem.Text = Convert.ToString(ImpresoraUsuario.Correlativo);
                txtDescripcion.Text = ImpresoraUsuario.Descripcion;
                chkPorDefecto.Checked = ImpresoraUsuario.PorDefecto;
                chkMatricial.Checked = ImpresoraUsuario.EsMatricial;
                chkticket.Checked = ImpresoraUsuario.ParaTicket;
                chkBarras.Checked = ImpresoraUsuario.ParaBarras;

                txtUsuarioReg.Text = ImpresoraUsuario.UsuarioRegistro;
                txtFechaReg.Text = ImpresoraUsuario.FechaRegistro.ToString();
                txtUsuarioMod.Text = ImpresoraUsuario.UsuarioModificacion;
                txtFechaMod.Text = ImpresoraUsuario.FechaModificacion.ToString();
            }

            bsDetalle.DataSource = ImpresoraUsuario.ListaCodBarras;
            bsDetalle.ResetBindings(false);
            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                DatosGrabacion();

                if (!ValidarGrabacion()) { return; }

                if (string.IsNullOrEmpty(txtItem.Text.Trim()))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        ImpresoraUsuario = AgenteGenerales.Proxy.GrabarUsuarioImpresoras(ImpresoraUsuario, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        ImpresoraUsuario = AgenteGenerales.Proxy.GrabarUsuarioImpresoras(ImpresoraUsuario, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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
            String resp = ValidarEntidad<UsuarioImpresorasE>(ImpresoraUsuario);

            if (!String.IsNullOrEmpty(resp))
            {
                Global.MensajeComunicacion(resp);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmImpresoraUsuarioDetalle oFrm = new frmImpresoraUsuarioDetalle();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalle != null)
                {
                    UsuarioImpresorasDetE oDetalle = oFrm.oDetalle;
                    Int32 numItem = 1;

                    if (ImpresoraUsuario.ListaCodBarras.Count > 0)
                    {
                        numItem = ImpresoraUsuario.ListaCodBarras.Max(x => x.Item) + 1;
                    }

                    oDetalle.Item = numItem;
                    ImpresoraUsuario.ListaCodBarras.Add(oDetalle);
                    bsDetalle.DataSource = ImpresoraUsuario.ListaCodBarras;
                    bsDetalle.ResetBindings(false);

                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (ImpresoraUsuario.ListaCodBarras.Count > 0)
                {
                    if (Global.MensajeConfirmacion("Eliminar la fila?") == DialogResult.Yes)
                    {
                        if (((UsuarioImpresorasDetE)bsDetalle.Current).Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            ImpresoraUsuario.ListaCodBarras.Remove((UsuarioImpresorasDetE)bsDetalle.Current);
                        }
                        else
                        {
                            if (ImpresoraUsuario.ListaBarrasEliminados == null)
                            {
                                ImpresoraUsuario.ListaBarrasEliminados = new List<UsuarioImpresorasDetE>();
                            }

                            ImpresoraUsuario.ListaBarrasEliminados.Add((UsuarioImpresorasDetE)bsDetalle.Current);
                            ImpresoraUsuario.ListaCodBarras.RemoveAt(bsDetalle.Position);
                        }

                        bsDetalle.DataSource = ImpresoraUsuario.ListaCodBarras;
                        bsDetalle.ResetBindings(false);
                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmImpresoraUsuario_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btBuscarImpresora_Click(object sender, EventArgs e)
        {
            frmBuscarImpresoras oFrm = new frmBuscarImpresoras();

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                txtDescripcion.Text = oFrm.NombreImpresora;
            }
        }

        private void chkBarras_CheckedChanged(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, chkBarras.Checked);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, chkBarras.Checked);
            dgvEtiquetas.Enabled = chkBarras.Checked;
        }

        #endregion

    }
}
