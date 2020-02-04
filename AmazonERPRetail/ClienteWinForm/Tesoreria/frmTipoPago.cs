using System;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmTipoPago : FrmMantenimientoBase
    {

        #region Constructor

        public frmTipoPago()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();

            FormatoGrid(dgvConceptos, true);
        }

        public frmTipoPago(String codTipoPago)
            :this()
        {
            oTipoPago = AgenteTesoreria.Proxy.ObtenerTipoPago(codTipoPago, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            Text = "Tipo Pago (" + oTipoPago.codTipoPago + ")";
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        TipoPagoE oTipoPago = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario
        
        void LlenarCombos()
        {
            cboIndTipo.DataSource = Global.CargarIE();
            cboIndTipo.ValueMember = "id";
            cboIndTipo.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oTipoPago.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            oTipoPago.indTipo = Convert.ToString(cboIndTipo.SelectedValue);
            oTipoPago.codTipoPago = txtCodTipoPago.Text;
            oTipoPago.desTipoPago = txtDes.Text;
            oTipoPago.codTipo = txtCodTip.Text;
            oTipoPago.indDetalle = chkIndicaDet.Checked;
            oTipoPago.HabilitarDatos = chkHabilitaDatos.Checked;
            oTipoPago.indSolProv = chkSolProv.Checked;

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oTipoPago.UsuarioRegistro = txtUsuRegistra.Text;
            }
            else
            {
                oTipoPago.UsuarioModificacion = txtUsuModifica.Text;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oTipoPago == null)
            {
                oTipoPago = new TipoPagoE();

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodTipoPago.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtCodTip.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                cboIndTipo.SelectedValue = Convert.ToString(oTipoPago.indTipo);

                txtCodTipoPago.Text = oTipoPago.codTipoPago;
                txtDes.Text = oTipoPago.desTipoPago;
                txtCodTip.Text = oTipoPago.codTipo;
                chkIndicaDet.Checked = oTipoPago.indDetalle;
                chkHabilitaDatos.Checked = oTipoPago.HabilitarDatos;
                chkSolProv.Checked = oTipoPago.indSolProv;

                txtUsuRegistra.Text = oTipoPago.UsuarioRegistro;
                txtRegistro.Text = oTipoPago.FechaRegistro.ToString();
                txtUsuModifica.Text = oTipoPago.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oTipoPago.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oTipoPago.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsTipoPago.DataSource = oTipoPago.DetalleTipoPago;
            bsTipoPago.ResetBindings(false);

            if (oTipoPago.indEstado)
            {
                Global.MensajeFault("El tipo de pago se encuentra anulado.");
                pnlDatos.Enabled = false;
            }
            else
            {
                base.Nuevo();
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oTipoPago != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oTipoPago = AgenteTesoreria.Proxy.GrabarTipoPago(oTipoPago, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oTipoPago = AgenteTesoreria.Proxy.GrabarTipoPago(oTipoPago, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
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
            String Respuesta = ValidarEntidad<TipoPagoE>(oTipoPago);

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
                ParTabla oTipoConcepto = new GeneralesServiceAgent().Proxy.ParTablaPorNemo("TCVAR");

                /*
                    1	Contabilidad
                    2	Ventas
                    3	Activo Fijo
                    4	Almacen
                    5	Compras
                    6	Tesoreria
                    7	Cobranzas
                    8	Planillas
                    9	Ctas por pagar
                 */

                frmBuscarConceptosTesoreria oFrm = new frmBuscarConceptosTesoreria(oTipoConcepto.IdParTabla);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    TipoPagoDetE oPagoDetalle = new TipoPagoDetE()
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        //codTipoPago
                        idConcepto = oFrm.oConcepto.idConcepto,
                        codConcepto = oFrm.oConcepto.codConcepto,
                        desConcepto = oFrm.oConcepto.Descripcion,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy
                    };

                    oTipoPago.DetalleTipoPago.Add(oPagoDetalle);
                    bsTipoPago.DataSource = oTipoPago.DetalleTipoPago;
                    bsTipoPago.ResetBindings(false);

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
                if (oTipoPago.DetalleTipoPago != null && oTipoPago.DetalleTipoPago.Count > 0)
                {
                    oTipoPago.DetalleTipoPago.Remove((TipoPagoDetE)bsTipoPago.Current);
                    bsTipoPago.DataSource = oTipoPago.DetalleTipoPago;
                    bsTipoPago.ResetBindings(false);

                    base.QuitarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmTipoPago_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void dgvConceptos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                Font oFont = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvConceptos.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                {
                    dgvConceptos.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
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
