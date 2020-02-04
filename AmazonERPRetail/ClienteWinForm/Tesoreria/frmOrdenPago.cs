using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmOrdenPago : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmOrdenPago()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvOrdenPagoDet, true, false, 28);
            LlenarCombos();
        }
        
        //Edición
        public frmOrdenPago(Int32 idOrdenPago)
            : this()
        {
            oOrdenPago = AgenteTesoreria.Proxy.ObtenerOrdenPagoCompleto(idOrdenPago);

            if (oOrdenPago == null)
            {
                Global.MensajeComunicacion("Esta OP ya no existe.");
                pnlPrincipales.Enabled = false;
                pnlOtros.Enabled = false;
                btAgregarOtros.Enabled = false;
                btAgregarPendiente.Enabled = false;
                return;
            }

            Text = "Orden Pago (" + oOrdenPago.codOrdenPago + ")";

            if (oOrdenPago.indPP > 0)
            {
                BloqPorPP = "S";
            }
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        OrdenPagoE oOrdenPago = null;
        Int32 opcion;
        String RazonSocial = String.Empty;
        String HacerOrden = Variables.SI;
        List<TipoPagoE> ListaTipoPago = null;
        String BloqPorPP = "N";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ListaTipoPago = AgenteTesoreria.Proxy.ListarTipoPagoCombo("E", VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ListaTipoPago.Add(new TipoPagoE() { codTipoPago = Variables.Cero.ToString(), desTipoPago = Variables.Seleccione });
            ComboHelper.RellenarCombos<TipoPagoE>(cboTipoPago, (from x in ListaTipoPago orderby x.codTipoPago select x).ToList(), "codTipoPago", "desTipoPago");

            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            oListaMonedas.Add(new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Seleccione });
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desMoneda");
        }

        void GuardarDatos()
        {
            oOrdenPago.codTipoPago = Convert.ToString(cboTipoPago.SelectedValue);
            oOrdenPago.idConcepto = Convert.ToInt32(cboConceptos.SelectedValue);
            oOrdenPago.codFormaPago = Convert.ToString(cboFormaPago.SelectedValue);
            oOrdenPago.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oOrdenPago.Fecha = dtpFecha.Value.Date;
            oOrdenPago.idPersonaBeneficiario = String.IsNullOrWhiteSpace(txtidBeneficiario.Text) ? (Int32?)null : Convert.ToInt32(txtidBeneficiario.Text);

            if (((TipoPagoE)cboTipoPago.SelectedItem).indDetalle)
            {
                oOrdenPago.Monto = Convert.ToDecimal(lblTotalSoles.Text);
                oOrdenPago.MontoDolar = Convert.ToDecimal(lblTotalDolares.Text);
            }
            else
            {
                TipoCambioE oTica = AgenteGeneral.Proxy.ObtenerTipoCambioPorDia("02", oOrdenPago.Fecha.ToString("yyyyMMdd"));

                if (oTica != null)
                {
                    if (oOrdenPago.idMoneda == "01")
                    {
                        oOrdenPago.Monto = Convert.ToDecimal(txtMonto.Text);
                        oOrdenPago.MontoDolar = Convert.ToDecimal(txtMonto.Text) / oTica.valVenta;
                    }
                    else
                    {
                        oOrdenPago.MontoDolar = Convert.ToDecimal(txtMonto.Text);
                        oOrdenPago.Monto = Convert.ToDecimal(txtMonto.Text) / oTica.valVenta;
                    }
                }
                else
                {
                    oOrdenPago.MontoDolar = 0;
                }
            }

            //oOrdenPago.Monto = Convert.ToDecimal(txtMonto.Text);
            oOrdenPago.Glosa = txtGlosa.Text;
            oOrdenPago.idPersona = String.IsNullOrWhiteSpace(txtIdProveedor.Text) ? (int?)null : Convert.ToInt32(txtIdProveedor.Text);

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oOrdenPago.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oOrdenPago.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, OrdenPagoDetE oPagoDet)
        {
            try
            {
                if (bsOrdenPagoDet.Count > 0)
                {
                    Int32 idPersonaAuxi = 0;
                    String Bloqueo = "N";

                    if (!String.IsNullOrWhiteSpace(txtidBeneficiario.Text.Trim()))
                    {
                        idPersonaAuxi = Convert.ToInt32(txtidBeneficiario.Text.Trim());
                    }

                    if (oOrdenPago.indEstado == "C" || oOrdenPago.indEstado == "A" || BloqPorPP == "S")
                    {
                        Bloqueo = "S";
                    }
                    else
                    {
                        if (((OrdenPagoDetE)bsOrdenPagoDet.Current).indAuto)
                        {
                            if (((TipoPagoE)cboTipoPago.SelectedItem).indDetalle && ((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                            {
                                if (((OrdenPagoDetE)bsOrdenPagoDet.Current).codTipoPago == cboTipoPago.SelectedValue.ToString() &&
                                    ((OrdenPagoDetE)bsOrdenPagoDet.Current).idConcepto == Convert.ToInt32(cboConceptos.SelectedValue) &&
                                    ((OrdenPagoDetE)bsOrdenPagoDet.Current).codFormaPago == cboFormaPago.SelectedValue.ToString())
                                {
                                    Bloqueo = "S";

                                    if (((OrdenPagoDetE)bsOrdenPagoDet.Current).idBanco == null || ((OrdenPagoDetE)bsOrdenPagoDet.Current).idBanco == 0)
                                    {
                                        Bloqueo = "N";
                                    }

                                    if (((OrdenPagoDetE)bsOrdenPagoDet.Current).tipCuenta == null || ((OrdenPagoDetE)bsOrdenPagoDet.Current).tipCuenta == 0)
                                    {
                                        Bloqueo = "N";
                                    }

                                    if (String.IsNullOrWhiteSpace(((OrdenPagoDetE)bsOrdenPagoDet.Current).idMonedaBanco))
                                    {
                                        Bloqueo = "N";
                                    }

                                    if (String.IsNullOrWhiteSpace(((OrdenPagoDetE)bsOrdenPagoDet.Current).numCtaBancaria))
                                    {
                                        Bloqueo = "N";
                                    }
                                }
                                else
                                {
                                    Bloqueo = "S";
                                }
                            }
                            else
                            {
                                Bloqueo = "S";
                            }
                        }
                    }

                    frmOrdenPagoDetalle oFrm = new frmOrdenPagoDetalle(oPagoDet, ListaTipoPago, oOrdenPago.VieneDe, idPersonaAuxi, Bloqueo, dtpFecha.Value);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oOrdenPago.ListaOrdenPago[e.RowIndex] = oFrm.OrdenPagoItem;
                        bsOrdenPagoDet.DataSource = oOrdenPago.ListaOrdenPago;
                        bsOrdenPagoDet.ResetBindings(false);
                    }

                    Sumar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void Sumar()
        {
            if (oOrdenPago.ListaOrdenPago != null && oOrdenPago.ListaOrdenPago.Count > 0)
            {
                Decimal totSoles = 0;
                Decimal totDolares = 0;

                foreach (OrdenPagoDetE item in oOrdenPago.ListaOrdenPago)
                {
                    if (item.idMoneda == Variables.Soles)
                    {
                        if (item.MontoSecu == 0)
                        {
                            item.MontoSecu = item.Monto / item.tipCambio;
                        }

                        totSoles += item.Monto;
                        totDolares += item.MontoSecu;
                    }
                    else
                    {
                        if (item.MontoSecu == 0)
                        {
                            item.MontoSecu = item.Monto * item.tipCambio;
                        }

                        totSoles += item.MontoSecu;
                        totDolares += item.Monto;
                    }
                }

                lblTotalSoles.Text = totSoles.ToString("N2");
                lblTotalDolares.Text = totDolares.ToString("N2");
                //txtMonto.Text = oOrdenPago.ListaOrdenPago.Sum(x => x.Monto).ToString("N2");
                //lblTotalSoles.Text = oOrdenPago.ListaOrdenPago.Sum(x => x.Monto).ToString("N2");
                //lblTotalDolares.Text = oOrdenPago.ListaOrdenPago.Sum(x => x.MontoSecu).ToString("N2");

                //if (lblTotalDolares.Text == "0.00")
                //{
                //    foreach (OrdenPagoDetE item in oOrdenPago.ListaOrdenPago)
                //    {
                //        if (item.idMoneda == Variables.Dolares)
                //        {
                //            //oItemPago.Monto = item.Saldo * item.TipoCambio;
                //            item.MontoSecu = item.Monto;
                //        }
                //        else
                //        {
                //            //oItemPago.Monto = item.Saldo;
                //            item.MontoSecu = item.Monto / item.tipCambio;
                //        }
                //    }

                //    lblTotalDolares.Text = oOrdenPago.ListaOrdenPago.Sum(x => x.MontoSecu).ToString("N2");
                //}
            }
            else
            {
                txtMonto.Text = "0.00";
                lblTotalSoles.Text = "0.00";
                lblTotalDolares.Text = "0.00";
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oOrdenPago == null)
            {
                oOrdenPago = new OrdenPagoE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    VieneDe = "M"
                };

                cboTipoPago.SelectedValue = "0";
                cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                txtRucBeneficiario.TextChanged -= txtRucBeneficiario_TextChanged;

                txtCodOrden.Text = oOrdenPago.codOrdenPago;
                dtpFecha.Value = oOrdenPago.Fecha;
                cboTipoPago.SelectedValue = String.IsNullOrWhiteSpace(oOrdenPago.codTipoPago) ? "0" : oOrdenPago.codTipoPago;
                cboTipoPago_SelectionChangeCommitted(new Object(), new EventArgs());
                cboConceptos.SelectedValue = Convert.ToInt32(oOrdenPago.idConcepto);
                cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFormaPago.SelectedValue = String.IsNullOrWhiteSpace(oOrdenPago.codFormaPago) ? "0" : oOrdenPago.codFormaPago;

                txtIdProveedor.Text = oOrdenPago.idPersona != 0 ? oOrdenPago.idPersona.ToString() : String.Empty;
                txtRuc.Text = oOrdenPago.RUC;
                txtRazonSocial.Text = oOrdenPago.RazonSocial;
                txtidBeneficiario.Text = oOrdenPago.idPersonaBeneficiario != 0 ? oOrdenPago.idPersonaBeneficiario.ToString() : String.Empty;
                txtRucBeneficiario.Text = oOrdenPago.RucBen;
                txtdesBeneficiario.Text = oOrdenPago.NombreBen;
                cboMoneda.SelectedValue = oOrdenPago.idMoneda;

                if (((TipoPagoE)cboTipoPago.SelectedItem).indDetalle)
                {
                    lblTotalSoles.Text = oOrdenPago.Monto.ToString("N2");
                    lblTotalDolares.Text = oOrdenPago.MontoDolar.ToString("N2");
                }
                else
                {
                    txtMonto.Text = oOrdenPago.Monto.ToString("N2");
                }

                txtGlosa.Text = oOrdenPago.Glosa;

                txtUsuRegistra.Text = oOrdenPago.UsuarioRegistro;
                txtRegistro.Text = oOrdenPago.FechaRegistro.ToString();
                txtUsuModifica.Text = oOrdenPago.UsuarioModificacion;
                txtModifica.Text = oOrdenPago.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                txtRucBeneficiario.TextChanged += txtRucBeneficiario_TextChanged;

                Sumar();
            }

            bsOrdenPagoDet.DataSource = oOrdenPago.ListaOrdenPago;
            bsOrdenPagoDet.ResetBindings(false);

            if (oOrdenPago.VieneDe == "M") //Si es M=Manual
            {
                if (oOrdenPago.indEstado == "C") //OP Cancelada o Cerrada
                {
                    Global.MensajeComunicacion(String.Format("La Orden de Pago {0} ya ha sido cancelado, no podrá hacer modificaciones.", oOrdenPago.codOrdenPago));
                    pnlPrincipales.Enabled = false;
                    pnlOtros.Enabled = false;
                    btAgregarOtros.Enabled = false;
                    btAgregarPendiente.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else if (oOrdenPago.indEstado == "A") //OP Anulada
                {
                    Global.MensajeComunicacion(String.Format("La Orden de Pago {0} ha sido anulada, no podrá hacer modificaciones.", oOrdenPago.codOrdenPago));
                    pnlPrincipales.Enabled = false;
                    pnlOtros.Enabled = false;
                    btAgregarOtros.Enabled = false;
                    btAgregarPendiente.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                }
                else
                {
                    if (BloqPorPP == "S")
                    {
                        Global.MensajeComunicacion(String.Format("La Orden de Pago {0} se encuentra en el Programa de Pagos, no podrá hacer modificaciones.", oOrdenPago.codOrdenPago));
                        pnlPrincipales.Enabled = false;
                        pnlOtros.Enabled = false;
                        btAgregarOtros.Enabled = false;
                        btAgregarPendiente.Enabled = false;
                        BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    }
                    else
                    {
                        base.Nuevo();
                        btAgregarOtros.Enabled = false;
                        btAgregarPendiente.Enabled = false;
                        BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                        bFlag = true;
                    }
                }
            }
            else
            {
                pnlPrincipales.Enabled = false;
                pnlOtros.Enabled = false;
                btAgregarOtros.Enabled = false;
                btAgregarPendiente.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                if (oOrdenPago.indEstado == "C") //OP Cancelada o Cerrada
                {
                    Global.MensajeComunicacion(String.Format("La Orden de Pago {0} ya ha sido cancelado, no podrá hacer modificaciones.", oOrdenPago.codOrdenPago));
                }
                else
                {
                    Global.MensajeComunicacion(String.Format("La Orden de Pago {0} es automática, no podrá hacer modificaciones.", oOrdenPago.codOrdenPago));
                }
            }
        }

        public override void Grabar()
        {
            try
            {
                if (oOrdenPago != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (HacerOrden == Variables.SI)
                    {
                        if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                            {
                                oOrdenPago = AgenteTesoreria.Proxy.GrabarOrdenPago(oOrdenPago, EnumOpcionGrabar.Insertar);
                                Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                            }
                        }
                        else
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                            {
                                oOrdenPago = AgenteTesoreria.Proxy.GrabarOrdenPago(oOrdenPago, EnumOpcionGrabar.Actualizar);
                                Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                            }
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
            String Respuesta = ValidarEntidad<OrdenPagoE>(oOrdenPago);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (((TipoPagoE)cboTipoPago.SelectedItem).indDetalle)//.codTipo != "CPRO" && ((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "DETR") //Cancelación a proveedores y Detracciones Masivas
            {
                foreach (OrdenPagoDetE item in oOrdenPago.ListaOrdenPago)
                {
                    if (!String.IsNullOrWhiteSpace(item.idMoneda) && !String.IsNullOrWhiteSpace(item.idMonedaBanco))
                    {
                        if (item.idMoneda != item.idMonedaBanco)
                        {
                            Global.MensajeComunicacion("Las monedas deben coincidir en el detalle antes de grabar.");
                            return false;
                        }
                    }
                }
            }

            if (((TipoPagoE)cboTipoPago.SelectedItem).indDetalle && ((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
            {
                if (oOrdenPago.ListaOrdenPago != null && oOrdenPago.ListaOrdenPago.Count > 0)
                {
                    foreach (OrdenPagoDetE item in oOrdenPago.ListaOrdenPago)
                    {
                        if (item.codTipoPago == cboTipoPago.SelectedValue.ToString() && item.idConcepto == Convert.ToInt32(cboConceptos.SelectedValue) && item.codFormaPago == cboFormaPago.SelectedValue.ToString())
                        {
                            if (item.idBanco == null || item.idBanco == 0)
                            {
                                Global.MensajeComunicacion("Faltan el banco del proveedor, debe actualizar los datos.");
                                return false;
                            }

                            if (item.tipCuenta == null || item.tipCuenta == 0)
                            {
                                Global.MensajeComunicacion("Faltan el Tipo de Cuenta Bancaria del proveedor, debe actualizar los datos.");
                                return false;
                            }

                            if (String.IsNullOrWhiteSpace(item.idMonedaBanco))
                            {
                                Global.MensajeComunicacion("Faltan la moneda Bancaria del proveedor, debe actualizar los datos.");
                                return false;
                            }

                            if (String.IsNullOrWhiteSpace(item.numCtaBancaria))
                            {
                                Global.MensajeComunicacion("Faltan la Cuenta Bancaria del proveedor, debe actualizar los datos.");
                                return false;
                            }
                        }
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (cboFormaPago.SelectedValue == null || cboFormaPago.SelectedValue.ToString() == "0")
                {
                    Global.MensajeComunicacion("Debe escoger una forma de pago antes de ingresar el detalle.");
                    return;
                }

                if (oOrdenPago.ListaOrdenPago == null)
                {
                    oOrdenPago.ListaOrdenPago = new List<OrdenPagoDetE>();
                }

                frmOrdenPagoDetalle oFrm = new frmOrdenPagoDetalle(ListaTipoPago, oOrdenPago.VieneDe, cboTipoPago.SelectedValue.ToString(), Convert.ToInt32(cboConceptos.SelectedValue), cboFormaPago.SelectedValue.ToString(), dtpFecha.Value);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    oFrm.OrdenPagoItem.indAuto = false;
                    oOrdenPago.ListaOrdenPago.Add(oFrm.OrdenPagoItem);
                    bsOrdenPagoDet.DataSource = oOrdenPago.ListaOrdenPago;
                    bsOrdenPagoDet.ResetBindings(false);
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (bsOrdenPagoDet.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oOrdenPago.ListaOrdenPago.RemoveAt(bsOrdenPagoDet.Position);
                        bsOrdenPagoDet.DataSource = oOrdenPago.ListaOrdenPago;
                        bsOrdenPagoDet.ResetBindings(false);

                        base.QuitarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenPago_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoPago.SelectedValue != null)
                {
                    List<TipoPagoDetE> oLista = new List<TipoPagoDetE>(((TipoPagoE)cboTipoPago.SelectedItem).DetalleTipoPago);
                    oLista.Add(new TipoPagoDetE() { idConcepto = Variables.Cero, desConcepto = Variables.Seleccione });
                    ComboHelper.RellenarCombos<TipoPagoDetE>(cboConceptos, (from x in oLista orderby x.idConcepto select x).ToList(), "idConcepto", "desConcepto", false);

                    if (cboTipoPago.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboConceptos.Enabled = false;
                    }
                    else
                    {
                        cboConceptos.Enabled = true;
                    }

                    cboConceptos_SelectionChangeCommitted(new Object(), new EventArgs());

                    if (((TipoPagoE)cboTipoPago.SelectedItem).indDetalle) //Cancelación a proveedores o Detracciones
                    {
                        Size = new Size(897, 447);
                        btAgregarOtros.Visible = true;
                        btAgregarPendiente.Visible = true;
                        pnlOtros.Enabled = ((TipoPagoE)cboTipoPago.SelectedItem).HabilitarDatos;

                        if (!((TipoPagoE)cboTipoPago.SelectedItem).HabilitarDatos)
                        {
                            txtIdProveedor.Text = String.Empty;
                            txtRuc.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;
                            txtidBeneficiario.Text = String.Empty;
                            txtRucBeneficiario.Text = String.Empty;
                            txtdesBeneficiario.Text = String.Empty;
                            cboMoneda.SelectedValue = "0";
                            txtGlosa.Text = String.Empty;
                            txtMonto.Text = "0.00";
                        }
                    }
                    else
                    {
                        Size = new Size(897, 238);
                        btAgregarOtros.Visible = false;
                        btAgregarPendiente.Visible = false;
                        pnlOtros.Enabled = ((TipoPagoE)cboTipoPago.SelectedItem).HabilitarDatos;
                        //Limpiando el grid en caso no lleve detalle.
                        bsOrdenPagoDet.DataSource = null;
                        bsOrdenPagoDet.ResetBindings(false);

                        if (!((TipoPagoE)cboTipoPago.SelectedItem).HabilitarDatos)
                        {
                            txtIdProveedor.Text = String.Empty;
                            txtRuc.Text = String.Empty;
                            txtRazonSocial.Text = String.Empty;
                            txtidBeneficiario.Text = String.Empty;
                            txtRucBeneficiario.Text = String.Empty;
                            txtdesBeneficiario.Text = String.Empty;
                            cboMoneda.SelectedValue = "0";
                            txtGlosa.Text = String.Empty;
                            txtMonto.Text = "0.00";
                        }
                    }
                }
                else
                {
                    cboConceptos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBeneficiario_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona(cboTipoPago.SelectedValue.ToString());
            HacerOrden = Variables.SI;

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtRucBeneficiario.TextChanged -= txtRucBeneficiario_TextChanged;

                txtidBeneficiario.Text = Convert.ToString(oFrm.oPersona.idPersonaResponsable);
                txtRucBeneficiario.Text = oFrm.oPersona.nroDocResponsable;
                txtdesBeneficiario.Text = oFrm.oPersona.desResponsable;

                if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "CPRO")//Si es diferente a Cancelación a proveedores
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                    txtRuc.Text = oFrm.oPersona.RUC;
                    txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                    FondoFijoE oFondoFijo = AgenteTesoreria.Proxy.ObtenerFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(txtIdProveedor.Text));

                    if (oFondoFijo != null)
                    {
                        cboMoneda.SelectedValue = oFondoFijo.idMoneda.ToString();
                        txtMonto.Text = oFondoFijo.MontoAutorizado.ToString("N2");

                        //if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "PAAF")
                        //{
                        //    OrdenPagoE oOrden = AgenteTesoreria.Proxy.OpAbiertosPorIdPersona(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(txtIdProveedor.Text));

                        //    if (oOrden != null)
                        //    {
                        //        HacerOrden = Variables.NO;
                        //        Global.MensajeFault("Este auxiliar ya tiene una O.P. pendiente, no puede genera otra a menos que liquide la anterior.");
                        //    } 
                        //}
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }

                txtRucBeneficiario.TextChanged += txtRucBeneficiario_TextChanged;
            }
        }

        private void dgvOrdenPagoDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EditarDetalle(e, ((OrdenPagoDetE)bsOrdenPagoDet.Current));
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdProveedor.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtRucBeneficiario.TextChanged -= txtRucBeneficiario_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            txtidBeneficiario.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucBeneficiario.Text = oFrm.oPersona.RUC;
                            txtdesBeneficiario.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        txtidBeneficiario.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRucBeneficiario.Text = oListaPersonas[0].RUC;
                        txtdesBeneficiario.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;

                        Global.MensajeFault("La Razón Social ingresada no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    txtRucBeneficiario.TextChanged += txtRucBeneficiario_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                txtRucBeneficiario.TextChanged += txtRucBeneficiario_TextChanged;

                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    txtRucBeneficiario.TextChanged -= txtRucBeneficiario_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdProveedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            txtidBeneficiario.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucBeneficiario.Text = oFrm.oPersona.RUC;
                            txtdesBeneficiario.Text = oFrm.oPersona.RazonSocial;
                            //if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo != "CPRO")//Cancelación a proveedores
                            //{
                            //    FondoFijoE FondoTMP = AgenteTesoreria.Proxy.ObtenerFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona);

                            //    if (FondoTMP != null)
                            //    {
                            //        txtidBeneficiario.Text = Convert.ToString(FondoTMP.idPersonaResponsable);
                            //        txtdesBeneficiario.Text = FondoTMP.desResponsable;
                            //        txtMonto.Text = Convert.ToString(FondoTMP.MontoAutorizado);
                            //        cboMoneda.SelectedValue = FondoTMP.idMoneda;
                            //    }
                            //    else
                            //    {
                            //        Global.MensajeAdvertencia("Esta persona no contiene un Fondo Fijo");
                            //    } 
                            //}
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdProveedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        txtidBeneficiario.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRucBeneficiario.Text = oListaPersonas[0].RUC;
                        txtdesBeneficiario.Text = oListaPersonas[0].RazonSocial;

                        //FondoFijoE FondoTMP = AgenteTesoreria.Proxy.ObtenerFondoFijo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona);

                        //if (FondoTMP != null)
                        //{
                        //    txtidBeneficiario.Text = Convert.ToString(FondoTMP.idPersonaResponsable);
                        //    txtdesBeneficiario.Text = FondoTMP.desResponsable;
                        //    txtMonto.Text = Convert.ToString(FondoTMP.MontoAutorizado);
                        //    cboMoneda.SelectedValue = FondoTMP.idMoneda;
                        //}
                        //else
                        //{
                        //    Global.MensajeAdvertencia("Esta persona no contiene un Fondo Fijo");
                        //}
                    }
                    else
                    {
                        txtIdProveedor.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    txtRucBeneficiario.TextChanged += txtRucBeneficiario_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            txtMonto.SeleccinarTodo();
        }

        private void txtMonto_MouseClick(object sender, MouseEventArgs e)
        {
            txtMonto.SeleccinarTodo();
        }

        private void btAgregarOtros_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDetalle();
                Sumar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAgregarPendiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboFormaPago.SelectedValue == null || cboFormaPago.SelectedValue.ToString() == "0")
                {
                    Global.MensajeComunicacion("Debe escoger una forma de pago antes de ingresar el detalle.");
                    return;
                }

                Boolean EsDetra = false;

                if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "DETR") //Detracciones Masivas
                {
                    EsDetra = true;
                }

                frmPendientesAuxiliares oFrm = null;

                if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "RCTA") //Rendicion de cuentas
                {
                    oFrm = new frmPendientesAuxiliares("RCTA", EsDetra);
                }
                else
                {
                    oFrm = new frmPendientesAuxiliares(EsDetra);
                }

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    OrdenPagoDetE oItemPago = null;
                    List<CtaCteE> oListaCtaCteTemp = new List<CtaCteE>(oFrm.oListaCtaCte);
                    List<CtaCteE> oListaEliminacion = new List<CtaCteE>();
                    DateTime Fecha = dtpFecha.Value.Date;

                    if (bsOrdenPagoDet.List.Count > Variables.Cero)
                    {
                        foreach (CtaCteE item1 in oListaCtaCteTemp)
                        {
                            foreach (OrdenPagoDetE item2 in bsOrdenPagoDet.List)
                            {
                                if (item1.idDocumento == item2.idDocumento && item1.numSerie == item2.serDocumento && item1.numDocumento == item2.numDocumento)
                                {
                                    Global.MensajeFault(String.Format("Este documento {0} {1}-{2} ya ha sido ingresado, intente ingresar otro o elimine el registro anterior para ingresarlo nuevamente.", item1.idDocumento, item1.numSerie, item1.numDocumento));
                                    oListaEliminacion.Add(item1);
                                }
                            }
                        }

                        if (oListaEliminacion.Count > Variables.Cero)
                        {
                            foreach (CtaCteE item in oListaEliminacion)
                            {
                                oListaCtaCteTemp.Remove(item);
                            }
                        }
                    }

                    oListaEliminacion = AgenteTesoreria.Proxy.BuscarDocExistenteOp(VariablesLocales.SesionLocal.IdLocal, oOrdenPago.idOrdenPago, oListaCtaCteTemp);

                    if (oListaEliminacion != null && oListaEliminacion.Count > 0)
                    {
                        StringBuilder Cadena = new StringBuilder();

                        foreach (CtaCteE item in oListaEliminacion)
                        {
                            Cadena.Append(item.idDocumento).Append(" ").Append(item.numSerie).Append(" ").Append(item.numDocumento).Append(" en la O.P. ").Append(item.codOrdenPago).Append("\r\n");
                        }

                        Global.MensajeComunicacion(String.Format("Los documentos ya han sido registrados:{0}{1}", "\r\n", Cadena.ToString()));
                        Cadena.Clear();

                        foreach (CtaCteE item in oListaEliminacion)
                        {
                            oListaCtaCteTemp.Remove(item);
                        }
                    }

                    if (oListaCtaCteTemp.Count > Variables.Cero)
                    {
                        if (oOrdenPago.ListaOrdenPago == null)
                        {
                            oOrdenPago.ListaOrdenPago = new List<OrdenPagoDetE>();
                        }

                        ProveedorCuentaE oCtaBancariaProv = null;

                        foreach (CtaCteE item in oListaCtaCteTemp)
                        {
                            oItemPago = new OrdenPagoDetE()
                            {
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                idLocal = VariablesLocales.SesionLocal.IdLocal,
                                codTipoPago = cboTipoPago.SelectedValue.ToString(),
                                idConcepto = Convert.ToInt32(cboConceptos.SelectedValue),
                                codFormaPago = cboFormaPago.SelectedValue.ToString(),
                                Fecha = item.FechaDocumento,
                                idProveedor = Convert.ToInt32(item.idPersona),
                                RucProv = item.RUC,
                                desProveedor = item.RazonSocial,
                                idDocumento = item.idDocumento,
                                serDocumento = item.numSerie,
                                numDocumento = item.numDocumento,

                                idMoneda = item.idMoneda,
                                desMoneda = item.desMoneda,
                                Monto = item.Saldo,
                                TipPartidaPresu = item.tipPartidaPresu,
                                idMonedaPago = item.idMoneda,
                                MontoPago = item.Saldo,
                                CodPartidaPresu = item.codPartidaPresu,
                                DesPartida = item.desPartidaPresu
                            };

                            if (item.idMoneda == Variables.Dolares)
                            {
                                oItemPago.MontoSecu = item.Saldo * item.TipoCambio;
                            }
                            else
                            {
                                oItemPago.MontoSecu = item.Saldo / item.TipoCambio;
                            }

                            //if (((TipoPagoE)cboTipoPago.SelectedItem).codTipo == "DETR") //Detracciones Masivas
                            //{
                            //    //oItemPago.idMoneda = (from x in VariablesLocales.ListaMonedas where x.idMoneda == Variables.Soles select x.idMoneda).FirstOrDefault();
                            //    //oItemPago.desMoneda = (from x in VariablesLocales.ListaMonedas where x.idMoneda == Variables.Soles select x.desAbreviatura).FirstOrDefault();

                            //    if (item.idMoneda == Variables.Dolares)
                            //    {
                            //        oItemPago.Monto = item.Saldo * item.TipoCambio;
                            //        oItemPago.MontoSecu = item.Saldo;
                            //    }
                            //    else
                            //    {
                            //        oItemPago.Monto = item.Saldo;
                            //        oItemPago.MontoSecu = item.Saldo / item.TipoCambio;
                            //    }

                            //    //oItemPago.desMoneda = item.desMoneda;
                            //    //oItemPago.Monto = item.Saldo;
                            //}
                            //else
                            //{
                            //    oItemPago.idMoneda = item.idMoneda;
                            //    oItemPago.desMoneda = item.desMoneda;
                            //    oItemPago.Monto = item.Saldo;
                            //}

                            oItemPago.Concepto = item.desGlosa;
                            oItemPago.Descripcion = String.Empty;
                            oItemPago.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                            oItemPago.codCuenta = item.codCuenta;

                            if (((FormaPagoE)cboFormaPago.SelectedItem).indDatosBancoAuxi)
                            {
                                oCtaBancariaProv = AgenteMaestros.Proxy.ObtenerProvCtaDefecto(item.idPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, item.idMoneda);

                                if (oCtaBancariaProv != null)
                                {
                                    oItemPago.idBanco = oCtaBancariaProv.idPersonaBanco;
                                    oItemPago.tipCuenta = oCtaBancariaProv.tipCuenta;
                                    oItemPago.idMonedaBanco = oCtaBancariaProv.idMoneda;
                                    oItemPago.desMonedaBanco = oCtaBancariaProv.desMoneda;
                                    oItemPago.numCtaBancaria = oCtaBancariaProv.CuentaPorDefecto == "C" ? oCtaBancariaProv.numCuenta : oCtaBancariaProv.numInterbancaria;
                                }
                                else
                                {
                                    oItemPago.idBanco = null;
                                    oItemPago.tipCuenta = null;
                                    oItemPago.idMonedaBanco = String.Empty;
                                    oItemPago.numCtaBancaria = String.Empty;
                                }
                            }
                            else
                            {
                                oItemPago.idBanco = null;
                                oItemPago.tipCuenta = null;
                                oItemPago.idMonedaBanco = String.Empty;
                                oItemPago.numCtaBancaria = String.Empty;
                            }

                            oItemPago.indPago = false;
                            oItemPago.indAuto = true;
                            oItemPago.UsuarioRegistro = oItemPago.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oItemPago.FechaRegistro = oItemPago.FechaModificacion = VariablesLocales.FechaHoy;

                            oOrdenPago.ListaOrdenPago.Add(oItemPago);
                        }

                        bsOrdenPagoDet.DataSource = oOrdenPago.ListaOrdenPago;
                        bsOrdenPagoDet.ResetBindings(false);
                    }
                }

                Sumar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRucBeneficiario_TextChanged(object sender, EventArgs e)
        {
            txtidBeneficiario.Text = String.Empty;
            txtdesBeneficiario.Text = string.Empty;
        }

        private void dgvOrdenPagoDet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                Font oFont = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvOrdenPagoDet.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                {
                    dgvOrdenPagoDet.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                }

                Brush ob = Brushes.Navy;
                e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboConceptos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoPago.SelectedValue != null && cboConceptos != null)
                {
                    List<FormaPagoE> ListaFormaPago = AgenteTesoreria.Proxy.ListarFormaPagoPorTipo(cboTipoPago.SelectedValue.ToString(), Convert.ToInt32(cboConceptos.SelectedValue), VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                    ComboHelper.RellenarCombos<FormaPagoE>(cboFormaPago, (from x in ListaFormaPago orderby x.codFormaPago select x).ToList(), "codFormaPago", "desFormaPago");

                    if (ListaFormaPago.Count == 0)
                    {
                        cboFormaPago.Enabled = false;
                    }
                    else
                    {
                        cboFormaPago.Enabled = true;
                    }
                }
                else
                {
                    cboFormaPago.Enabled = false;
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
