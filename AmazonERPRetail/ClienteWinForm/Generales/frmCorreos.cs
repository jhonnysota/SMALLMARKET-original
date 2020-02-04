using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Generales
{
    public partial class frmCorreos : FrmMantenimientoBase
    {

        #region Constructores

        public frmCorreos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvCorreos, true);
        }

        public frmCorreos(ContactosCorreosGrupoE oGrupoCorreo_)
            :this()
        {
            oGrupoCorreo = AgenteGenerales.Proxy.ObtenerContactosCorreosGrupo(oGrupoCorreo_.idGrupo);
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGenerales { get { return new GeneralesServiceAgent(); } }
        ContactosCorreosGrupoE oGrupoCorreo = null;
        Int32 OpcionGrabar = 0;

        #endregion

        #region Procedimiento de Usuario

        void DatosGrabacion()
        {
            oGrupoCorreo.Descripcion = txtDescripcion.Text.Trim();
            oGrupoCorreo.GrupoDefecto = chkPorDefecto.Checked;

            if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
            {
                oGrupoCorreo.UsuarioRegistro = txtUsuarioReg.Text;
            }
            else
            {
                oGrupoCorreo.UsuarioModificacion = txtUsuarioMod.Text;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, ContactosCorreosE oItem)
        {
            try
            {
                frmCorreosDetalle oFrm = new frmCorreosDetalle(oItem);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCorreo != null)
                {
                    ContactosCorreosE ItemDet = oFrm.oCorreo;
                    oGrupoCorreo.ListaCorreos[e.RowIndex] = ItemDet;
                    bsCorreos.DataSource = oGrupoCorreo.ListaCorreos;
                    bsCorreos.ResetBindings(false);

                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oGrupoCorreo == null)
            {
                oGrupoCorreo = new ContactosCorreosGrupoE()
                {
                    idUsuario = VariablesLocales.SesionUsuario.IdPersona
                };

                txtRazonSocial.Text = VariablesLocales.SesionUsuario.NombreCompleto;
                txtUsuarioReg.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaReg.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaMod.Text = VariablesLocales.FechaHoy.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtRazonSocial.Text = oGrupoCorreo.RazonSocial;
                txtDescripcion.Text = oGrupoCorreo.Descripcion;
                chkPorDefecto.Checked = oGrupoCorreo.GrupoDefecto;

                txtUsuarioReg.Text = oGrupoCorreo.UsuarioRegistro;
                txtFechaReg.Text = oGrupoCorreo.FechaRegistro.ToString();
                txtUsuarioMod.Text = oGrupoCorreo.UsuarioModificacion;
                txtFechaMod.Text = oGrupoCorreo.FechaModificacion.ToString();

                OpcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsCorreos.DataSource = oGrupoCorreo.ListaCorreos;
            bsCorreos.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                DatosGrabacion();

                if (!ValidarGrabacion()) { return; }

                if (OpcionGrabar == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oGrupoCorreo = AgenteGenerales.Proxy.GrabarCorreoGrupo(oGrupoCorreo, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oGrupoCorreo = AgenteGenerales.Proxy.GrabarCorreoGrupo(oGrupoCorreo, EnumOpcionGrabar.Actualizar);
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
            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                if (chkPorDefecto.Checked)
                {
                    Int32 resp = AgenteGenerales.Proxy.RevisarCorreosGrupoPorDefecto(oGrupoCorreo.idGrupo, VariablesLocales.SesionUsuario.IdPersona);

                    if (resp > 0)
                    {
                        Global.MensajeAdvertencia("Ya existe un grupo por defecto, quite el check de Grupo por Defecto.");
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCorreos_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btCorreos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCorreos oFrm = new frmBuscarCorreos();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCorreo != null)
                {
                    ContactosCorreosE oCorreo = oFrm.oCorreo;
                    oCorreo.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                    oCorreo.UsuarioRegistro = oCorreo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oCorreo.FechaRegistro = oCorreo.FechaModificacion = VariablesLocales.FechaHoy;

                    oGrupoCorreo.ListaCorreos.Add(oCorreo);
                    bsCorreos.DataSource = oGrupoCorreo.ListaCorreos;
                    bsCorreos.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsCorreos_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsCorreos.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCorreos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                //Si se quiere aumentar el 0 adelante
                while ((numFila.Length < dgvCorreos.RowCount.ToString().Length))
                {
                    numFila = (" " + numFila);
                }

                Font oFont = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvCorreos.RowHeadersWidth < Convert.ToInt32(size.Width + 30))
                {
                    dgvCorreos.RowHeadersWidth = Convert.ToInt32(size.Width + 30);
                }

                Brush ob = SystemBrushes.ControlText;
                e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y
                                + ((e.RowBounds.Height - size.Height) / 2)));
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCorreosDetalle oFrm = new frmCorreosDetalle();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCorreo != null)
                {
                    ContactosCorreosE oCorreo = oFrm.oCorreo;
                    oGrupoCorreo.ListaCorreos.Add(oCorreo);
                    bsCorreos.DataSource = oGrupoCorreo.ListaCorreos;
                    bsCorreos.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.MensajeConfirmacion("Desea eliminar el registro") == DialogResult.Yes)
                {
                    if (oGrupoCorreo.ListaCorreosEliminados == null)
                    {
                        oGrupoCorreo.ListaCorreosEliminados = new List<ContactosCorreosE>();
                    }

                    //Añadiendo a la lista de eliminados
                    oGrupoCorreo.ListaCorreosEliminados.Add((ContactosCorreosE)bsCorreos.Current);
                    //Removiendo de la lista principal
                    oGrupoCorreo.ListaCorreos.Remove((ContactosCorreosE)bsCorreos.Current);
                    //Actualizando el grid
                    bsCorreos.DataSource = oGrupoCorreo.ListaCorreos;
                    bsCorreos.ResetBindings(false);

                    base.QuitarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvCorreos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalle(e, (ContactosCorreosE)bsCorreos.Current);
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
