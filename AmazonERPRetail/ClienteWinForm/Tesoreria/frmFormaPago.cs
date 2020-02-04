using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using Entidades.Generales;
using Infraestructura.Winform;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmFormaPago : FrmMantenimientoBase
    {

        #region Constructores

        public frmFormaPago()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvFormaTipoPago, true);
            LlenarCombos();
        }

        public frmFormaPago(Int32 Registros)
            :this()
        {

        }

        public frmFormaPago(FormaPagoE oFormaPago_ = null)
            :this()
        {
            oFormaPago = AgenteTesoreria.Proxy.ObtenerFormaPago(oFormaPago_.codFormaPago, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            //formapag.ListaTipoPago = AgenteTesoreria.Proxy.ListarFormaTipoPago(((FormaPagoE)bsFormaPago.Current).codFormaPago);
            //oFormaPago = oFormaPago_;
            Text = "Forma de Pago (" + oFormaPago.codFormaPago + ")";
            //Items = Registros;
        }

        #endregion

        #region Variables
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        FormaPagoE oFormaPago = null;
        Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            oFormaPago.codFormaPago = txtCodigo.Text.Trim();
            oFormaPago.desFormaPago = txtDesFormaPago.Text;
            oFormaPago.MontoTope = Convert.ToDecimal(txtMonto.Text);
            oFormaPago.CodForma = txtNomCorto.Text.Trim();
            oFormaPago.indForma = Convert.ToString(cboIndicador.SelectedValue);
            oFormaPago.indDatosBancoAuxi = chkDatosAuxiliares.Checked;
            oFormaPago.codMedioPago = Convert.ToInt32(cboMedioPago.SelectedValue);
        }

        void LlenarCombos()
        {
            //FormaPago
            cboIndicador.DataSource = Global.CargarFormaPag();
            cboIndicador.ValueMember = "id";
            cboIndicador.DisplayMember = "Nombre";


            // Medios de Pago
            List<ParTabla> oListaMedioPago = new List<ParTabla>();
            oListaMedioPago = AgenteGeneral.Proxy.ListarParTablaPorNemo("MEDPAG");
            ParTabla oInicio = new ParTabla { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione };
            oListaMedioPago.Add(oInicio);
            ComboHelper.RellenarCombos<List<ParTabla>>(cboMedioPago, (from x in oListaMedioPago orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oFormaPago == null)
            {
                oFormaPago = new FormaPagoE();
                cboMedioPago.SelectedValue = Variables.Cero;
                txtUsuarioRegistro.Text = oFormaPago.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oFormaPago.FechaRegistro = VariablesLocales.FechaHoy;
                txtFechaRegistro.Text = oFormaPago.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oFormaPago.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oFormaPago.FechaModificacion = VariablesLocales.FechaHoy;
                txtFechaModificacion.Text = oFormaPago.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNomCorto.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                txtCodigo.Text = oFormaPago.codFormaPago;
                txtNomCorto.Text = oFormaPago.CodForma;
                txtDesFormaPago.Text = oFormaPago.desFormaPago;
                txtMonto.Text = oFormaPago.MontoTope.ToString("N2");
                cboIndicador.SelectedValue = oFormaPago.indForma;
                chkDatosAuxiliares.Checked = oFormaPago.indDatosBancoAuxi;
                if (oFormaPago.codMedioPago != null)
                {
                    cboMedioPago.SelectedValue = oFormaPago.codMedioPago;
                }
                else
                {
                    cboMedioPago.SelectedIndex = 0;
                }             
                txtUsuarioRegistro.Text = oFormaPago.UsuarioRegistro;
                txtFechaRegistro.Text = oFormaPago.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oFormaPago.UsuarioModificacion;
                txtFechaModificacion.Text = oFormaPago.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsFormaTipoPago.DataSource = oFormaPago.ListaTipoPago;
            bsFormaTipoPago.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                bsFormaTipoPago.EndEdit();
                GuardarDatos();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oFormaPago = AgenteTesoreria.Proxy.GrabarFormaPago(oFormaPago, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oFormaPago = AgenteTesoreria.Proxy.GrabarFormaPago(oFormaPago, EnumOpcionGrabar.Actualizar);
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

            String Respuesta = ValidarEntidad<FormaPagoE>(oFormaPago);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                List<FormaTipoPagoE> oListaTemp = (List<FormaTipoPagoE>)bsFormaTipoPago.List;
                frmFormaTipoPago oFrm = new frmFormaTipoPago(oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    FormaTipoPagoE oReqItem = oFrm.FormaTipoPagoItem;
                    oFormaPago.ListaTipoPago.Add(oReqItem);
                    bsFormaTipoPago.DataSource = oFormaPago.ListaTipoPago;
                    bsFormaTipoPago.ResetBindings(false);
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
                if (bsFormaTipoPago.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        if (oFormaPago.oListaFormaTipoEliminados == null)
                        {
                            oFormaPago.oListaFormaTipoEliminados = new List<FormaTipoPagoE>();
                        }

                        //Agregando a la lista de eliminados
                        oFormaPago.oListaFormaTipoEliminados.Add((FormaTipoPagoE)bsFormaTipoPago.Current);
                        //Removiendo de la lista principal(temporalmente)...
                        oFormaPago.ListaTipoPago.RemoveAt(bsFormaTipoPago.Position);
                        //Actualizando la lista...
                        bsFormaTipoPago.DataSource = oFormaPago.ListaTipoPago;
                        bsFormaTipoPago.ResetBindings(false);

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

        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, true);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, true);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvFormaTipoPago_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void dgvFormaTipoPago_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                Font oFont = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvFormaTipoPago.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                {
                    dgvFormaTipoPago.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                }

                Brush ob = Brushes.Navy;
                e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
