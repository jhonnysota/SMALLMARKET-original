using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmCotizacion : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmCotizacion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvDetalle, true);
            LlenarCombo();
            Global.CrearToolTip(btSunat, "Consultas a Sunat.");
        }

        //Edición
        public frmCotizacion(Int32 idEmpresa_, Int32 idLocal_, Int32 idPedido_)
            : this()
        {
            oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(idEmpresa_, idLocal_, idPedido_);

            if (oPedido.Estado == EnumEstadoDocumentos.C.ToString())
            {
                Global.MensajeComunicacion("El Pedido se encuentra cerrado.\n\rNo podra hacer modificaciones.");

                pnlPrincipales.Enabled = false;
                pnlDetalle.Enabled = false;
                btNuevoItem.Enabled = false;
                btEliminarItem.Enabled = false;
            }
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        PedidoCabE oPedido = null;
        Int32 Opcion = Variables.Cero;
        Decimal totdsc1 = 0;
        Decimal totdsc2 = 0;
        Decimal totdsc3 = 0;
        Boolean indCarteraClientes = false;

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            MonedasE CampoInicial = new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Escoger };
            ListaMoneda.Add(CampoInicial);

            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) ||
                                                                    (x.idMoneda == Variables.Dolares) ||
                                                                    (x.idMoneda == Variables.Cero.ToString())
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda", false);

            List<ParTabla> oLista = new List<ParTabla>
            {
                new ParTabla() { IdParTabla = 0, Nombre = "NACIONAL" },
                new ParTabla() { IdParTabla = 1, Nombre = "EXPORTACION" }
            };
            ComboHelper.LlenarCombos<ParTabla>(cboTipo, oLista, "IdParTabla", "Nombre");

            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");

            //Formas de Pago
            List<ParTabla> oListaFormaPago = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPFORPAG");
            oListaFormaPago.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboFormaPago, (from x in oListaFormaPago orderby x.IdParTabla select x).ToList());

            //Tipo de Comprobante
            List<ParTabla> oListaComprobantes = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPCOMPAGO");
            oListaComprobantes.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboTipoComprobante, (from x in oListaComprobantes orderby x.IdParTabla select x).ToList());

            ListaMoneda = null;
            oLista = null;
            oListaEstablecimientos = null;
            oListaFormaPago = null;
            oListaComprobantes = null;
        }

        void DatosGrabacion()
        {
            oPedido.FecPedido = dtFecEmision.Value.ToString("yyyyMMdd");

            if (String.IsNullOrEmpty(txtRucReferente.Text.Trim()) && String.IsNullOrEmpty(txtRazonReferente.Text.Trim()))
            {
                oPedido.idNotificar = null;
                oPedido.idFacturar = Convert.ToInt32(txtIdCliente.Text);
            }
            else
            {
                oPedido.idNotificar = Convert.ToInt32(txtIdReferente.Text);
                oPedido.idFacturar = Convert.ToInt32(txtIdCliente.Text);
            }

            oPedido.Indicaciones = txtIndicaciones.Text;
            oPedido.idMoneda = cboMonedas.SelectedValue.ToString();
            oPedido.Observacion = txtObservacion.Text.Trim();
            oPedido.Observacion = oPedido.Observacion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oPedido.idFormaPago = Convert.ToInt32(cboFormaPago.SelectedValue);
            oPedido.idTipCondicion = String.IsNullOrEmpty(txtIdCondicion.Text.Trim()) ? 0 : (Int32)EnumTipoCondicionVenta.FacBol;
            oPedido.idCondicion = String.IsNullOrEmpty(txtIdCondicion.Text.Trim()) ? 0 : Convert.ToInt32(txtIdCondicion.Text);
            oPedido.idVendedor = String.IsNullOrEmpty(txtIdVendedor.Text.Trim()) ? 0 : Convert.ToInt32(txtIdVendedor.Text.Trim());
            oPedido.idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
            oPedido.idZona = Convert.ToInt32(cboZona.SelectedValue);
            oPedido.Tipo = Convert.ToInt32(cboTipo.SelectedValue) == 0 ? false : true;
            oPedido.totsubTotal = Convert.ToDecimal(lblSubTotal.Text);
            oPedido.totDscto1 = totdsc1;
            oPedido.totDscto2 = totdsc2;
            oPedido.totDscto3 = totdsc3;
            oPedido.totIsc = Convert.ToDecimal(lblIsc.Text);
            oPedido.totIgv = Convert.ToDecimal(lblIgv.Text);
            oPedido.totTotal = Convert.ToDecimal(lblTotal.Text);
            oPedido.idSucursalCliente = String.IsNullOrEmpty(txtIdSucursal.Text.Trim()) ? 0 : Convert.ToInt32(txtIdSucursal.Text.Trim());
            oPedido.PuntoLlegada = txtPuntoLlegada.Text;
            oPedido.PuntoPartida = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;
            oPedido.TipoDoc = Convert.ToInt32(cboTipoComprobante.SelectedValue);
            oPedido.idTransporte = String.IsNullOrEmpty(txtIdTransporte.Text.Trim()) ? 0 : Convert.ToInt32(txtIdTransporte.Text.Trim());
            oPedido.indCotPed = "C";

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oPedido.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oPedido.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, PedidoDetE oItem)
        {
            try
            {
                List<PedidoDetE> oListaTemp = null;

                if (oPedido.ListaPedidoDet.Count > Variables.Cero)
                {
                    oListaTemp = new List<PedidoDetE>(oPedido.ListaPedidoDet);
                }

                frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value, oItem, oListaTemp, "C");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalle != null)
                {
                    PedidoDetE ItemDet = oFrm.oDetalle;
                    oPedido.ListaPedidoDet[e.RowIndex] = ItemDet;
                    bsCotizacion.DataSource = oPedido.ListaPedidoDet;
                    bsCotizacion.ResetBindings(false);
                    dgvDetalle.AutoResizeColumns();
                    SumarTotal(oPedido.ListaPedidoDet);
                }

                base.AgregarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void SumarTotal(List<PedidoDetE> oListaDetalle)
        {
            if (oListaDetalle != null && oListaDetalle.Count > Variables.Cero)
            {
                Decimal SubTotal = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.subTotal).Sum(), 2);
                Decimal ValorGravado = Decimal.Round((from x in oListaDetalle where x.flgIgv == true && x.indCalculo == true select x.subTotal).Sum(), 2);
                Decimal ValorNoGravado = Decimal.Round((from x in oListaDetalle where x.flgIgv == false && x.indCalculo == true select x.subTotal).Sum(), 2);
                Decimal Igv = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Igv).Sum(), 2);
                Decimal Isc = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Isc).Sum(), 2);
                totdsc1 = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Dscto1).Sum(), 2);
                totdsc2 = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Dscto2).Sum(), 2);
                totdsc3 = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Dscto3).Sum(), 2);
                Decimal Dsctos = totdsc1 + totdsc2 + totdsc3;
                Decimal Total = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Total).Sum(), 2);

                lblGravado.Text = ValorGravado.ToString("N2");
                lblNoGravado.Text = ValorNoGravado.ToString("N2");
                lblIsc.Text = Isc.ToString("N2");
                lblIgv.Text = Igv.ToString("N2");
                lblDsct.Text = Dsctos.ToString("N2");
                lblSubTotal.Text = SubTotal.ToString("N2");
                lblTotal.Text = Total.ToString("N2");
            }
            else
            {
                lblGravado.Text = "0.00";
                lblNoGravado.Text = "0.00";
                lblIsc.Text = "0.00";
                lblIgv.Text = "0.00";
                lblDsct.Text = "0.00";
                lblSubTotal.Text = "0.00";
                lblTotal.Text = "0.00";
            }
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Cli)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Cliente. Desea agregarlo ?") == DialogResult.Yes)
                {
                    ClienteE oCliente = new ClienteE()
                    {
                        idPersona = oListaPersonasTmp[0].IdPersona,
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        SiglaComercial = oListaPersonasTmp[0].RazonSocial,
                        TipoCliente = 0,
                        fecInscripcion = (Nullable<DateTime>)null,
                        fecInicioEmpresa = (Nullable<DateTime>)null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catCliente = 0,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestro.Proxy.InsertarCliente(oCliente);
                }
            }
        }

        void VerificarVendedor(Int32 IdPersona)
        {
            //List<VendedoresE> oListaVendedor = oListaVendedor = AgenteMaestro.Proxy.BusquedaVendedores(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            //foreach (VendedoresE item in oListaVendedor)
            //{
            //    if (IdPersona == item.idPersona)
            //    {
            //        txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
            //        txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;

            //        txtIdVendedor.Text = item.idPersona.ToString();
            //        txtNombresVendedor.Text = item.RazonSocial;
            //        txtNroDocumentoVen.Text = item.NroDocumento;
            //        indCarteraClientes = item.ManejaCartera;

            //        if (item.indSupervisor)
            //        {
            //            txtNombresVendedor.Enabled = true;
            //            txtNroDocumentoVen.Enabled = true;
            //            btBuscarVendedor.Enabled = true;
            //        }

            //        txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
            //        txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
            //        break;
            //    }
            //}

            //oListaVendedor = null;

            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                txtIdVendedor.Text = string.Empty;
                txtNroDocumentoVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                indCarteraClientes = false;
            }
            else
            {
                VendedoresE oVendedor = AgenteMaestro.Proxy.RecuperarVendedorPorId(VariablesLocales.SesionUsuario.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                if (oVendedor != null)
                {
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;

                    txtIdVendedor.Text = oVendedor.idPersona.ToString();
                    txtNombresVendedor.Text = oVendedor.RazonSocial;
                    txtNroDocumentoVen.Text = oVendedor.NroDocumento;
                    indCarteraClientes = oVendedor.ManejaCartera;

                    if (oVendedor.indSupervisor)
                    {
                        txtNroDocumentoVen.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtNombresVendedor.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    }

                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                }
                else
                {
                    txtIdVendedor.Text = string.Empty;
                }

                oVendedor = null;
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPedido == null)
            {
                oPedido = new PedidoCabE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                txtCodPedido.Text = String.Empty;

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecModifica.Text = VariablesLocales.FechaHoy.ToString();

                if (VariablesLocales.oVenParametros != null && VariablesLocales.oVenParametros.monPedido != null)
                {
                    cboMonedas.SelectedValue = VariablesLocales.oVenParametros.monPedido;
                }
                else
                {
                    cboMonedas.SelectedValue = Variables.Cero;
                }

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                txtCodPedido.Text = oPedido.codPedidoCad;
                dtFecEmision.Value = Convert.ToDateTime(oPedido.FecPedido);
                cboTipo.SelectedValue = Convert.ToInt32(oPedido.Tipo);
                cboMonedas.SelectedValue = oPedido.idMoneda.ToString();

                //if (oPedido.idConsignatario == 0)
                //{
                //    txtIdCliente.Text = oPedido.idFacturar.ToString();
                //    txtRucCLiente.Text = oPedido.RucCliente;
                //    txtRazonCliente.Text = oPedido.desFacturar;
                //    txtDireccion.Text = oPedido.DireccionCompleta;

                //    txtIdAsociado.Text = oPedido.idConsignatario.ToString();
                //    txtIdReferente.Text = oPedido.idNotificar.ToString();
                //    txtRucReferente.Text = oPedido.RucNotificador;
                //    txtRazonReferente.Text = oPedido.desNotificador;
                //}
                //else
                //{
                //    txtIdCliente.Text = oPedido.idNotificar.ToString();
                //    txtRucCLiente.Text = oPedido.RucNotificador;
                //    txtRazonCliente.Text = oPedido.desNotificador;

                //    txtIdAsociado.Text = oPedido.idConsignatario.ToString();
                //    txtIdReferente.Text = oPedido.idFacturar.ToString();
                //    txtRucReferente.Text = oPedido.RucCliente;
                //    txtRazonReferente.Text = oPedido.desFacturar;
                //    txtDireccion.Text = oPedido.dirConsignatario;
                //}

                txtIdVendedor.Text = oPedido.idVendedor.ToString();
                txtNroDocumentoVen.Text = oPedido.numDocVendedor;
                txtNombresVendedor.Text = oPedido.Vendedor;
                cboEstablecimiento.SelectedValue = Convert.ToInt32(oPedido.idEstablecimiento);
                cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                cboZona.SelectedValue = Convert.ToInt32(oPedido.idZona);
                txtIndicaciones.Text = oPedido.Indicaciones;
                txtObservacion.Text = oPedido.Observacion;
                txtIdCondicion.Text = oPedido.idCondicion.ToString();
                txtDesCondicion.Text = oPedido.desCondicion;
                cboFormaPago.SelectedValue = Convert.ToInt32(oPedido.idFormaPago);
                cboTipoComprobante.SelectedValue = Convert.ToInt32(oPedido.TipoDoc);
                txtIdTransporte.Text = oPedido.idTransporte.ToString();
                txtRazonTransporte.Text = oPedido.RazonSocialTransporte;
                txtIdSucursal.Text = oPedido.idSucursalCliente == 0 ? String.Empty : oPedido.idSucursalCliente.ToString();
                txtPuntoLlegada.Text = oPedido.PuntoLlegada;

                txtNumFactura.Text = oPedido.nroFactura;

                txtUsuRegistra.Text = oPedido.UsuarioRegistro;
                txtFecRegistro.Text = oPedido.fechaRegistro.ToString();
                txtUsuModifica.Text = oPedido.UsuarioModificacion;
                txtFecModifica.Text = oPedido.fechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                SumarTotal(oPedido.ListaPedidoDet);

                txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
            }

            bsCotizacion.DataSource = oPedido.ListaPedidoDet;
            bsCotizacion.ResetBindings(false);
            dgvDetalle.AutoResizeColumns();

            if (oPedido.Estado != EnumEstadoDocumentos.C.ToString())
            {
                base.Nuevo();
            }
            else
            {
                btNuevoItem.Enabled = false;
                btEliminarItem.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsCotizacion.EndEdit();
                
                if (ValidarGrabacion())
                {
                 DatosGrabacion();

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion("Desea grabar la cotización") == DialogResult.Yes)
                        {
                            oPedido = AgenteVentas.Proxy.GrabarPedidosNacionales(oPedido, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(String.Format("Se va actualizar la siguiente Cotización {0}", txtCodPedido.Text)) == DialogResult.Yes)
                        {
                            oPedido = AgenteVentas.Proxy.GrabarPedidosNacionales(oPedido, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
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

        public override void AgregarDetalle()
        {
            try
            {
                List<PedidoDetE> oListaTemp = null;

                if (oPedido.ListaPedidoDet.Count > Variables.Cero)
                {
                    oListaTemp = new List<PedidoDetE>(oPedido.ListaPedidoDet);
                }
                int moneda = cboMonedas.SelectedIndex;
                frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(moneda,dtFecEmision.Value, oListaTemp, "C");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalle != null)
                {
                    PedidoDetE ItemDet = oFrm.oDetalle;
                    Int32 Item;

                    if (oPedido.ListaPedidoDet.Count == Variables.Cero)
                    {
                        Item = Variables.ValorUno;
                    }
                    else
                    {
                        Item = Convert.ToInt32(oPedido.ListaPedidoDet.Max(mx => mx.idItem)) + 1;
                    }
                    //Item = Convert.ToInt32(oPedido.ListaPedidoDet.Max(mx => mx.idItem)) + 1;
                    ItemDet.idItem = Item;
                    oPedido.ListaPedidoDet.Add(ItemDet);
                    bsCotizacion.DataSource = oPedido.ListaPedidoDet;
                    bsCotizacion.ResetBindings(false);

                    SumarTotal(oPedido.ListaPedidoDet);
                    dgvDetalle.AutoResizeColumns();
                }

                base.AgregarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            oPedido.ListaPedidoDet.Remove((PedidoDetE)bsCotizacion.Current);
            bsCotizacion.DataSource = oPedido.ListaPedidoDet;
            bsCotizacion.ResetBindings(false);

            SumarTotal(oPedido.ListaPedidoDet);
            base.QuitarDetalle();
        }

        public override bool ValidarGrabacion()
        {
            if (cboMonedas.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                cboMonedas.Focus();
                Global.MensajeFault("Debe escoger el Tipo de Moneda.");
                return false;
            }

            if (String.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
            {
                txtRucCLiente.Focus();
                Global.MensajeFault("Debe agregar la razón social del cliente.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217")
                {
                    cboEstablecimiento.Enabled = false;
                }

                if (String.IsNullOrWhiteSpace(txtIdVendedor.Text) && String.IsNullOrWhiteSpace(txtNroDocumentoVen.Text.Trim()) && String.IsNullOrWhiteSpace(txtNombresVendedor.Text.Trim()))
                {
                    VerificarVendedor(VariablesLocales.SesionUsuario.IdPersona);
                }

                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtIdCliente.Text.Trim()))
                {
                    Global.MensajeFault("Tiene que escoger un cliente antes de buscar otra dirección");
                    return;
                }

                List<PersonaDireccionE> oListaDirecciones = AgenteMaestro.Proxy.ListarPersonaDireccion(Convert.ToInt32(txtIdCliente.Text.Trim()));
                frmBuscarSucursalCliente oFrm = new frmBuscarSucursalCliente(oListaDirecciones);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDireccion != null)
                {
                    txtIdSucursal.Text = oFrm.oDireccion.IdDireccion.ToString();
                    txtPuntoLlegada.Text = oFrm.oDireccion.DireccionCompleta;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRucCLiente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRucCLiente.Text.Trim()) && String.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
                {
                    List<Persona> oListaPersonas = null;

                    if (String.IsNullOrEmpty(txtRucReferente.Text.Trim()) && String.IsNullOrEmpty(txtRazonReferente.Text.Trim()))
                    {
                        if (!indCarteraClientes)
                        {
                            oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text);
                        }
                        else
                        {
                            oListaPersonas = AgenteMaestro.Proxy.ListarCarteraClientesPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text, Convert.ToInt32(txtIdVendedor.Text));
                        }
                    }
                    else
                    {
                        List<ClienteAsociadosE> oListaAsociado = AgenteMaestro.Proxy.ListarClienteAsociados(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(txtIdReferente.Text.Trim()));

                        if (oListaAsociado.Count > Variables.Cero)
                        {
                            oListaPersonas = new List<Persona>();
                            Persona oCliente = null;
                            String Nemo = String.Empty;
                            List<ParTabla> oListaCanales = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPMER");
                            Int32 CanalVenta = (from x in oListaCanales
                                                where x.NemoTecnico == "MERNAC"
                                                select x.IdParTabla).SingleOrDefault(); //Nacional

                            foreach (ClienteAsociadosE item in oListaAsociado)
                            {
                                if (item.RUC.Length == Variables.NroCaracteresRUC)
                                {
                                    if (item.RUC.Substring(0, 1) == "2")
                                    {
                                        Nemo = "PERJU";
                                    }
                                    else
                                    {
                                        Nemo = "PERCR";
                                    }
                                }
                                else if (item.RUC.Length == Variables.NroCaracteresDNI)
                                {
                                    Nemo = "PERSR";
                                }
                                else
                                {
                                    Nemo = "OTR";
                                    CanalVenta = (from x in oListaCanales
                                                  where x.NemoTecnico == "MEREXT"
                                                  select x.IdParTabla).SingleOrDefault(); //Exportación
                                }

                                oCliente = new Persona()
                                {
                                    IdPersona = item.idPersona,
                                    RazonSocial = item.RazonSocial,
                                    RUC = item.RUC,
                                    DireccionCompleta = item.Direccion,
                                    Cli = true,
                                    Pro = false,
                                    Tra = false,
                                    Ban = false,
                                    idCanalVenta = CanalVenta,
                                    NemoTipPer = Nemo,
                                    idAsociado = item.IdAsociado
                                };

                                oListaPersonas.Add(oCliente);
                            }
                        }
                    }

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAsociado.Text = oFrm.oPersona.idAsociado.ToString();
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;

                            if (oFrm.oPersona.NemoTipPer == "PERJU" || oFrm.oPersona.NemoTipPer == "PERCR")
                            {
                                cboTipoComprobante.SelectedIndex = 1;
                            }
                            else if (oFrm.oPersona.NemoTipPer == "PERSR")
                            {
                                cboTipoComprobante.SelectedIndex = 2;
                            }
                            else
                            {
                                cboTipoComprobante.SelectedIndex = 0;
                            }

                            txtPuntoLlegada.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtIdAsociado.Text = oListaPersonas[0].idAsociado.ToString();
                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;

                        if (oListaPersonas[0].NemoTipPer == "PERJU" || oListaPersonas[0].NemoTipPer == "PERCR")
                        {
                            cboTipoComprobante.SelectedIndex = 1;
                        }
                        else if (oListaPersonas[0].NemoTipPer == "PERSR")
                        {
                            cboTipoComprobante.SelectedIndex = 2;
                        }
                        else
                        {
                            cboTipoComprobante.SelectedIndex = 0;
                        }

                        txtPuntoLlegada.Focus();
                    }
                    else
                    {
                        if (!indCarteraClientes)
                        {
                            Global.MensajeFault("El Ruc ingresado no existe. Si se trata de una Persona Jurídica puede buscarlo en Sunat.");
                        }
                        else
                        {
                            Global.MensajeFault("El Ruc ingresado no existe en la Cartera de Clientes del vendedor. Si se trata de una Persona Jurídica puede buscarlo en Sunat.");
                        }

                        txtIdAsociado.Text = String.Empty;
                        txtIdCliente.Text = String.Empty;
                        txtRucCLiente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtRucCLiente.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonCliente.Text.Trim()) && String.IsNullOrEmpty(txtRucCLiente.Text.Trim()))
                {
                    List<Persona> oListaPersonas = null;

                    if (String.IsNullOrEmpty(txtRucReferente.Text.Trim()) && String.IsNullOrEmpty(txtRazonReferente.Text.Trim()))
                    {
                        if (!indCarteraClientes)
                        {
                            oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text);
                        }
                        else
                        {
                            oListaPersonas = AgenteMaestro.Proxy.ListarCarteraClientesPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text, Convert.ToInt32(txtIdVendedor.Text));
                        }
                    }
                    else
                    {
                        List<ClienteAsociadosE> oListaAsociado = AgenteMaestro.Proxy.ListarClienteAsociados(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(txtIdReferente.Text.Trim()));

                        if (oListaAsociado.Count > Variables.Cero)
                        {
                            oListaPersonas = new List<Persona>();
                            Persona oCliente = null;
                            String Nemo = String.Empty;
                            List<ParTabla> oListaCanales = new GeneralesServiceAgent().Proxy.ListarParTablaPorNemo("TIPMER");
                            Int32 CanalVenta = (from x in oListaCanales
                                                where x.NemoTecnico == "MERNAC"
                                                select x.IdParTabla).SingleOrDefault(); //Nacional

                            foreach (ClienteAsociadosE item in oListaAsociado)
                            {
                                if (item.RUC.Length == Variables.NroCaracteresRUC)
                                {
                                    if (item.RUC.Substring(0, 1) == "2")
                                    {
                                        Nemo = "PERJU";
                                    }
                                    else
                                    {
                                        Nemo = "PERCR";
                                    }
                                }
                                else if (item.RUC.Length == Variables.NroCaracteresDNI)
                                {
                                    Nemo = "PERSR";
                                }
                                else
                                {
                                    Nemo = "OTR";
                                    CanalVenta = (from x in oListaCanales
                                                  where x.NemoTecnico == "MEREXT"
                                                  select x.IdParTabla).SingleOrDefault(); //Exportación
                                }

                                oCliente = new Persona()
                                {
                                    IdPersona = item.idPersona,
                                    RazonSocial = item.RazonSocial,
                                    RUC = item.RUC,
                                    DireccionCompleta = item.Direccion,
                                    Cli = true,
                                    Pro = false,
                                    Tra = false,
                                    Ban = false,
                                    idCanalVenta = CanalVenta,
                                    NemoTipPer = Nemo,
                                    idAsociado = item.IdAsociado
                                };

                                oListaPersonas.Add(oCliente);
                            }
                        }
                    }

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAsociado.Text = oFrm.oPersona.idAsociado.ToString();
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;

                            if (oFrm.oPersona.NemoTipPer == "PERJU" || oFrm.oPersona.NemoTipPer == "PERCR")
                            {
                                cboTipoComprobante.SelectedIndex = 1;
                            }
                            else if (oFrm.oPersona.NemoTipPer == "PERSR")
                            {
                                cboTipoComprobante.SelectedIndex = 2;
                            }
                            else
                            {
                                cboTipoComprobante.SelectedIndex = 0;
                            }

                            txtPuntoLlegada.Focus();
                        }
                        else
                        {
                            dgvDetalle.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtIdAsociado.Text = oListaPersonas[0].idAsociado.ToString();
                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;

                        if (oListaPersonas[0].NemoTipPer == "PERJU" || oListaPersonas[0].NemoTipPer == "PERCR")
                        {
                            cboTipoComprobante.SelectedIndex = 1;
                        }
                        else if (oListaPersonas[0].NemoTipPer == "PERSR")
                        {
                            cboTipoComprobante.SelectedIndex = 2;
                        }
                        else
                        {
                            cboTipoComprobante.SelectedIndex = 0;
                        }

                        txtPuntoLlegada.Focus();
                    }
                    else
                    {
                        if (!indCarteraClientes)
                        {
                            Global.MensajeFault("La Razón Social ingresada no existe");
                        }
                        else
                        {
                            Global.MensajeFault("La Razón Social ingresada no existe en la Cartera de Clientes de este vendedor.");
                        }

                        txtIdAsociado.Text = String.Empty;
                        txtIdCliente.Text = String.Empty;
                        txtRucCLiente.Text = String.Empty;
                        txtRazonCliente.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtRazonCliente.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRucReferente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRucReferente.Text.Trim()) && String.IsNullOrEmpty(txtRazonReferente.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("CL", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtRucReferente.Text.Trim(), true);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Refe");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucReferente.Text = oFrm.oPersona.RUC;
                            txtIdReferente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonReferente.Text = oFrm.oPersona.RazonSocial;

                            txtRucCLiente.Focus();
                        }
                        else
                        {
                            txtRazonReferente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRucReferente.Text = oListaPersonas[0].RUC;
                        txtIdReferente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonReferente.Text = oListaPersonas[0].RazonSocial;

                        txtRucCLiente.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdReferente.Text = String.Empty;
                        txtRucReferente.Text = String.Empty;
                        txtRazonReferente.Text = String.Empty;
                        txtRucReferente.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonReferente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonReferente.Text.Trim()) && String.IsNullOrEmpty(txtRucReferente.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("CL", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtRazonReferente.Text.Trim(), "", true);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Refe");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAsociado.Text = oFrm.oPersona.idAsociado.ToString();
                            txtRucReferente.Text = oFrm.oPersona.RUC;
                            txtIdReferente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonReferente.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonReferente.Text = String.Empty;
                            txtRazonReferente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAsociado.Text = oListaPersonas[0].idAsociado.ToString();
                        txtRucReferente.Text = oListaPersonas[0].RUC;
                        txtIdReferente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonReferente.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtIdAsociado.Text = String.Empty;
                        txtIdReferente.Text = String.Empty;
                        txtRucReferente.Text = String.Empty;
                        txtRazonReferente.Text = String.Empty;
                        txtRucReferente.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtNroDocumentoVen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()) && String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "", txtNroDocumentoVen.Text.Trim());

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            indCarteraClientes = oFrm.oPersona.ManejaCartera;
                            cboEstablecimiento.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        indCarteraClientes = oListaPersonas[0].ManejaCartera;
                        cboEstablecimiento.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El Nro. de Documento ingresado no existe");
                        txtIdVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        indCarteraClientes = false;
                        txtNroDocumentoVen.Focus();
                        return;
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtNombresVendedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombresVendedor.Text.Trim()) && String.IsNullOrEmpty(txtNroDocumentoVen.Text.Trim()))
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtNombresVendedor.Text.Trim(), "");

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Vendedor");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();
                            indCarteraClientes = oFrm.oPersona.ManejaCartera;

                            if (String.IsNullOrEmpty(oFrm.oPersona.RazonSocial.Trim()))
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.ApePaterno + " " + oFrm.oPersona.ApeMaterno + " " + oFrm.oPersona.Nombres;
                            }
                            else
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                        else
                        {
                            txtRazonReferente.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();
                        indCarteraClientes = oListaPersonas[0].ManejaCartera;

                        if (String.IsNullOrEmpty(oListaPersonas[0].RazonSocial.Trim()))
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].ApePaterno + " " + oListaPersonas[0].ApeMaterno + " " + oListaPersonas[0].Nombres;
                        }
                        else
                        {
                            txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtIdVendedor.Text = String.Empty;
                        txtNroDocumentoVen.Text = String.Empty;
                        txtNombresVendedor.Text = String.Empty;
                        indCarteraClientes = false;
                        txtNroDocumentoVen.Focus();
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRucCLiente_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRucCLiente.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRazonCliente.Text = String.Empty;
                txtDireccion.Text = String.Empty;
            }
        }

        private void txtRazonCliente_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRucCLiente.Text = String.Empty;
                txtDireccion.Text = String.Empty;
            }
        }

        private void txtRucReferente_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRucReferente.Text.Trim()))
            {
                txtIdAsociado.Text = String.Empty;
                txtIdReferente.Text = String.Empty;
                txtRazonReferente.Text = String.Empty;
            }
        }

        private void txtRazonReferente_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonReferente.Text.Trim()))
            {
                txtIdAsociado.Text = String.Empty;
                txtIdReferente.Text = String.Empty;
                txtRucReferente.Text = String.Empty;
            }
        }

        private void txtNroDocumentoVen_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = String.Empty;
            txtNombresVendedor.Text = String.Empty;
        }

        private void txtNombresVendedor_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = String.Empty;
            txtNroDocumentoVen.Text = String.Empty;
        }

        private void txtRazonCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtRazonReferente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtNombresVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboEstablecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<ZonaTrabajoE> oListaZonas = AgenteVentas.Proxy.ListarZonasPorIdEstablecimiento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, Convert.ToInt32(cboEstablecimiento.SelectedValue));
                ComboHelper.LlenarCombos<ZonaTrabajoE>(cboZona, oListaZonas, "idZona", "Descripcion");

                if (oListaZonas.Count > Variables.Cero && oListaZonas != null)
                {
                    //int idZona = (oListaZonas.Where(x => x.Principal == true).Select(s => s.idZona).Single());
                    ZonaTrabajoE oZona = (oListaZonas.Where(x => x.Principal == true).SingleOrDefault());

                    if (oZona != null)
                    {
                        cboZona.SelectedValue = oZona.idZona;
                    }

                    cboZona.Enabled = true;
                }
                else
                {
                    cboZona.DataSource = null;
                    cboZona.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btNuevoItem_Click(object sender, EventArgs e)
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

        private void cboEstablecimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboZona_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtFecEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboMonedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalle(e, (PedidoDetE)bsCotizacion.Current);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarCondicion_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCondicionVentas oFrm = new frmBuscarCondicionVentas(EnumTipoCondicionVenta.FacBol);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCondicion != null)
                {
                    txtIdTipCondicion.Text = oFrm.oCondicion.idTipCondicion.ToString();
                    txtIdCondicion.Text = oFrm.oCondicion.idCondicion.ToString("00");
                    txtDesCondicion.Text = oFrm.oCondicion.desCondicion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboTipoComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void btBuscarTransporte_Click(object sender, EventArgs e)
        {
            frmBuscarTransporte oFrm = new frmBuscarTransporte();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTransporte != null)
            {
                txtIdTransporte.Text = oFrm.oTransporte.idTransporte.ToString();
                txtRazonTransporte.Text = oFrm.oTransporte.RazonSocial;
            }
        }

        private void txtIdCondicion_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdCondicion.Text.Trim()))
            {
                txtIdCondicion.Text = String.Empty;
                txtDesCondicion.Text = String.Empty;
            }
        }

        private void txtRazonTransporte_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonTransporte.Text.Trim()))
            {
                txtIdTransporte.Text = String.Empty;
            }
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            frmBuscarRucBasico oFrm = new frmBuscarRucBasico(txtRucCLiente.Text, indCarteraClientes, Convert.ToInt32(txtIdVendedor.Text));

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Informacion != null)
            {
                txtRucCLiente.Text = oFrm.Ruc;
                txtRazonCliente.Text = oFrm.RazonSocial;
                txtDireccion.Text = oFrm.Direccion;

                if (oFrm.oPersona != null)
                {
                    ClienteE oCliente = null;

                    oCliente = AgenteMaestro.Proxy.RecuperarClientePorId(oFrm.oPersona.IdPersona, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                    if (oCliente == null)
                    {
                        oCliente = new ClienteE()
                        {
                            idPersona = oFrm.oPersona.IdPersona,
                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                            SiglaComercial = oFrm.oPersona.RazonSocial,
                            TipoCliente = 0,
                            fecInscripcion = (Nullable<DateTime>)null,
                            fecInicioEmpresa = (Nullable<DateTime>)null,
                            tipConstitucion = 0,
                            tipRegimen = 0,
                            catCliente = 0,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                        };

                        AgenteMaestro.Proxy.InsertarCliente(oCliente);
                    }


                    txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();

                    if (indCarteraClientes)
                    {
                        if (Global.MensajeConfirmacion("Desea agregar al cliente a su cartera de clientes.") == DialogResult.Yes)
                        {
                            VendedoresCarteraE oClienteCartera = new VendedoresCarteraE()
                            {
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                idVendedor = Convert.ToInt32(txtIdVendedor.Text),
                                idCliente = Convert.ToInt32(txtIdCliente.Text),
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                            };

                            AgenteMaestro.Proxy.InsertarVendedoresCartera(oClienteCartera);
                        }
                    }
                }

                txtPuntoLlegada.Focus();
            }
        }

        private void btEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oPedido.ListaPedidoDet != null && oPedido.ListaPedidoDet.Count > 0)
                {
                    QuitarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarVendedor oFrm = new frmBuscarVendedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVendedor != null)
                {
                    txtNroDocumentoVen.TextChanged -= txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged -= txtNombresVendedor_TextChanged;

                    txtNroDocumentoVen.Text = oFrm.oVendedor.NroDocumento;
                    txtIdVendedor.Text = oFrm.oVendedor.idPersona.ToString();
                    indCarteraClientes = oFrm.oVendedor.ManejaCartera;

                    if (String.IsNullOrEmpty(oFrm.oVendedor.RazonSocial.Trim()))
                    {
                        txtNombresVendedor.Text = oFrm.oVendedor.ApePaterno + " " + oFrm.oVendedor.ApeMaterno + " " + oFrm.oVendedor.Nombres;
                    }
                    else
                    {
                        txtNombresVendedor.Text = oFrm.oVendedor.RazonSocial;
                    }

                    cboEstablecimiento.Focus();

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
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
