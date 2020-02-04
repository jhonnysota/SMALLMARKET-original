using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmSolicitudProv : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmSolicitudProv()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvDetalle, true);
            LlenarCombos();
        }

        //Edición
        public frmSolicitudProv(Int32 idSolicitud)
            : this()
        {
            oSolicitud = AgenteTesoreria.Proxy.RecuperarSolicitudProveedor(idSolicitud);
            Text = "Solicitud de Proveedor (" + oSolicitud.codSolicitud + ")";
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        SolicitudProveedorE oSolicitud = null;
        String Bloqueo = "N";

        #endregion

        #region Procedmientos de Usuario

        void LlenarCombos()
        {
            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMoneda, oListaMonedas, "idMoneda", "desAbreviatura");

            List<TipoPagoDetE> oListaDetalle = AgenteTesoreria.Proxy.ListarTipoPagoDetIndSolProv(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.LlenarCombos<TipoPagoDetE>(cboConceptos, oListaDetalle, "idConcepto", "desConcepto");

            oListaMonedas = null;
        }

        void Datos()
        {
            oSolicitud.codSolicitud = txtCodSolicitud.Text;
            oSolicitud.Fecha = dtpFecha.Value.Date;
            oSolicitud.idProveedor = Convert.ToInt32(txtRuc.Tag);
            oSolicitud.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oSolicitud.impTotal = Convert.ToDecimal(txtMonto.Text);
            oSolicitud.Descripcion = Global.DejarSoloUnEspacio(txtGlosa.Text.Trim());
            oSolicitud.Pedido = txtNroPedido.Text.Trim();
            oSolicitud.idOrdenPago = String.IsNullOrWhiteSpace(txtOp.Text.Trim()) ? (Int32?)null : Convert.ToInt32(txtOp.Tag);
            oSolicitud.idConcepto = Convert.ToInt32(cboConceptos.SelectedValue);

            if (String.IsNullOrWhiteSpace(txtCodSolicitud.Text.Trim()))
            {
                oSolicitud.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oSolicitud.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, SolicitudProveedorDetE oDetalle)
        {
            try
            {
                if (bsDetalle.Count > 0)
                {
                    frmDetalleSolicitudProv oFrm = new frmDetalleSolicitudProv(oDetalle, Bloqueo);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oSolicitud.oListaSolicitudes[e.RowIndex] = oFrm.oSolDetalle;
                        bsDetalle.DataSource = oSolicitud.oListaSolicitudes;
                        bsDetalle.ResetBindings(false);
                        base.AgregarDetalle();
                        Sumar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void Sumar()
        {
            if (oSolicitud.oListaSolicitudes != null && oSolicitud.oListaSolicitudes.Count > 0)
            {
                txtMonto.Text = oSolicitud.oListaSolicitudes.Sum(x => x.Importe).ToString("N2");
            }
            else
            {
                txtMonto.Text = "0.00";
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oSolicitud == null)
            {
                oSolicitud = new SolicitudProveedorE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    indEstado = "P"
                };

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecModifica.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                txtCodSolicitud.Text = oSolicitud.codSolicitud;
                dtpFecha.Value = oSolicitud.Fecha.Date;
                cboMoneda.SelectedValue = oSolicitud.idMoneda.ToString();
                txtMonto.Text = oSolicitud.impTotal.ToString("N2");
                txtRuc.Tag = oSolicitud.idProveedor;
                txtRuc.Text = oSolicitud.RUC;
                txtRazonSocial.Text = oSolicitud.RazonSocial;
                txtGlosa.Text = oSolicitud.Descripcion;
                txtNroPedido.Text = oSolicitud.Pedido;
                txtOp.Tag = oSolicitud.idOrdenPago;
                txtOp.Text = oSolicitud.codOrdenPago.Trim();
                cboConceptos.SelectedValue = Convert.ToInt32(oSolicitud.idConcepto);

                txtUsuRegistra.Text = oSolicitud.UsuarioRegistro;
                txtFecRegistro.Text = oSolicitud.FechaRegistro.ToString();
                txtUsuModifica.Text = oSolicitud.UsuarioModificacion;
                txtFecModifica.Text = oSolicitud.FechaModificacion.ToString();

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }

            bsDetalle.DataSource = oSolicitud.oListaSolicitudes;
            bsDetalle.ResetBindings(false);

            //C=Cancelado A=Aprobado P=Pendiente
            if (oSolicitud.indEstado == "C")
            {
                Bloqueo = "S";
                pnlPrincipales.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                Global.MensajeComunicacion("La solicitud se encuentra Cerrada, no podrá realizar modificaciones.");
            }
            else if (oSolicitud.indEstado == "A")
            {
                Bloqueo = "S";
                pnlPrincipales.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                Global.MensajeComunicacion("La solicitud se encuentra Aprobada, no podrá realizar modificaciones.");
            }
            else //(oSolicitud.indEstado == "P")
            {
                base.Nuevo();
                bFlag = true;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsDetalle.EndEdit();
                Datos();

                if (ValidarGrabacion())
                {
                    if (String.IsNullOrWhiteSpace(txtCodSolicitud.Text.Trim()))
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.GrabarSolicitudProveedor(oSolicitud, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        } 
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.GrabarSolicitudProveedor(oSolicitud, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (String.IsNullOrWhiteSpace(txtRuc.Tag.ToString()))
            {
                Global.MensajeFault("Debe ingresar un proveedor.");
                return false;
            }

            if (cboConceptos.SelectedValue == null)
            {
                Global.MensajeFault("Debe escoger un concepto.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmDetalleSolicitudProv oFrm = new frmDetalleSolicitudProv();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oSolDetalle != null)
                {
                    oSolicitud.oListaSolicitudes.Add(oFrm.oSolDetalle);
                    bsDetalle.DataSource = oSolicitud.oListaSolicitudes;
                    bsDetalle.ResetBindings(false);
                    base.AgregarDetalle();

                    Sumar();
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
                if (Global.MensajeConfirmacion("Desea eliminar la fila") == DialogResult.Yes)
                {
                    if (oSolicitud.oSolicitudesDel == null)
                    {
                        oSolicitud.oSolicitudesDel = new List<SolicitudProveedorDetE>();
                    }

                    //Lista de Eliminados
                    oSolicitud.oSolicitudesDel.Add((SolicitudProveedorDetE)bsDetalle.Current);
                    //Actualizando la lista
                    oSolicitud.oListaSolicitudes.Remove((SolicitudProveedorDetE)bsDetalle.Current);
                    bsDetalle.DataSource = oSolicitud.oListaSolicitudes;
                    bsDetalle.ResetBindings(false);

                    base.QuitarDetalle();
                    Sumar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmSolicitudProv_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void dgvDetalle_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                Font oFont = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvDetalle.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                {
                    dgvDetalle.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                }

                Brush ob = Brushes.Navy;
                e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
            txtRuc.TextChanged -= txtRuc_TextChanged;
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            dgvDetalle.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsDetalle.Current != null)
                {
                    EditarDetalle(e, (SolicitudProveedorDetE)bsDetalle.Current);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsDetalle_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = String.Format("Registros {0}", bsDetalle.Count.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
