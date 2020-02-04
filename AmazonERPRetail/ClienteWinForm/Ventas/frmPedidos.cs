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
    public partial class frmPedidos : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmPedidos()
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
        public frmPedidos(Int32 idEmpresa_, Int32 idLocal_, Int32 idPedido_)
            : this()
        {
            oPedido = AgenteVentas.Proxy.RecuperarPedidoNacional(idEmpresa_, idLocal_, idPedido_);
           
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
         public PedidoCabE oPedido = null;
        PedidoDetE detallePe = null;
        Int32 Opcion = Variables.Cero;
        Decimal totdsc1 = 0;
        Decimal totdsc2 = 0;
        Decimal totdsc3 = 0;
        Boolean indCarteraClientes = false;


        #endregion Variables

        #region Procedimientos de Usuario

        private void LlenarCombo()
        {
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas)
            {
                new MonedasE() { idMoneda = Variables.Cero.ToString(), desMoneda = Variables.Escoger }
            };

            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) ||
                                                                    (x.idMoneda == Variables.Dolares) ||
                                                                    (x.idMoneda == Variables.Cero.ToString())
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda", false);
            cboMonedas.SelectedIndex = 1;

            //Tipo de Comprobante
            List<ParTabla> oListaComprobantes = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPCOMPAGO");
            oListaComprobantes.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboTipoComprobante, (from x in oListaComprobantes orderby x.IdParTabla select x).ToList());


            //Lista de Precios
            List<ListaPrecioE> oListaPrecio = null;

            if (VariablesLocales.oVenParametros != null && VariablesLocales.oVenParametros.indListaPrecio)
            {
                oListaPrecio = AgenteVentas.Proxy.ListarPrecioPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, false);
                oListaPrecio.Add(new ListaPrecioE() { idListaPrecio = Variables.Cero, Nombre = Variables.Escoger });
                ComboHelper.LlenarCombos<ListaPrecioE>(cboListaPrecio, (from x in oListaPrecio
                                                                        orderby x.idListaPrecio
                                                                        select x).ToList(), "idListaPrecio", "Nombre");

                ListaPrecioE oPrecio = oPrecio = oListaPrecio.Find
                (
                    delegate (ListaPrecioE pre) { return pre.Principal == true; }
                );

                if (oPrecio != null)
                {
                    cboListaPrecio.SelectedValue = oPrecio.idListaPrecio;
                }
                else
                {
                    cboListaPrecio.SelectedValue = 0;
                }

                oPrecio = null;
            }
            else
            {
                oListaPrecio = new List<ListaPrecioE>
                {
                    new ListaPrecioE() { idListaPrecio = Variables.Cero, Nombre = Variables.Escoger }
                };

                ComboHelper.LlenarCombos<ListaPrecioE>(cboListaPrecio, oListaPrecio, "idListaPrecio", "Nombre");
                cboListaPrecio.Enabled = false;
            }

            oListaPrecio = null;
            ListaMoneda = null;
            oListaComprobantes = null;
        }
  

        private void DatosGrabacion()
        {
            oPedido.FecCotizacion = dtFecEmision.Value.ToString("yyyyMMdd");
            oPedido.idNotificar = null;
            oPedido.idFacturar = String.IsNullOrWhiteSpace(txtRucCLiente.Tag.ToString()) ? (int?)null : Convert.ToInt32(txtRucCLiente.Tag.ToString());
            oPedido.Indicaciones = string.Empty;
            oPedido.idMoneda = cboMonedas.SelectedValue.ToString();
            oPedido.Observacion = TxtObservacion.Text.Trim();
            oPedido.Observacion = oPedido.Observacion.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "");
            oPedido.idFormaPago = null;
            oPedido.idTipCondicion = String.IsNullOrEmpty(txtIdCondicion.Text.Trim()) ? (int?)null : (int)EnumTipoCondicionVenta.FacBol;
            oPedido.idCondicion = String.IsNullOrEmpty(txtIdCondicion.Text.Trim()) ? (int?)null : Convert.ToInt32(txtIdCondicion.Text);
            oPedido.idVendedor = Convert.ToInt32(txtNroDocumentoVen.Tag) == 0 ? (int?)null : Convert.ToInt32(txtNroDocumentoVen.Tag);
            oPedido.idEstablecimiento = null;
            oPedido.idZona = null;
            oPedido.idDivision = null;
            oPedido.Tipo = false; //Nacional o Exportación
            oPedido.totsubTotal = Convert.ToDecimal(lblSubTotal.Text);
            oPedido.totDscto1 = totdsc1;
            oPedido.totDscto2 = totdsc2;
            oPedido.totDscto3 = totdsc3;
            oPedido.totIsc = Convert.ToDecimal(lblIsc.Text);
            oPedido.totIgv = Convert.ToDecimal(lblIgv.Text);
            oPedido.totTotal = Convert.ToDecimal(lblTotal.Text);
            oPedido.idSucursalCliente = String.IsNullOrEmpty(txtPuntoLlegada.Tag.ToString()) ? (int?)null : Convert.ToInt32(txtPuntoLlegada.Tag);
            oPedido.PuntoLlegada = txtPuntoLlegada.Text.Trim();
            oPedido.PuntoPartida = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;
            oPedido.TipoDoc = Convert.ToInt32(cboTipoComprobante.SelectedValue);
            oPedido.idTransporte = null;
            oPedido.indCotPed = "V";
            oPedido.FecEntrega = DtpFecEntrega.Value.ToString("yyyyMMdd");
            //oPedido.ListaPedidoDet.Add(cbo);
          


            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oPedido.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oPedido.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        private void EditarDetalle(DataGridViewCellEventArgs e, PedidoDetE oItem)
        {
            try
            {
                List<PedidoDetE> oListaTemp = null;

                if (oPedido.ListaPedidoDet.Count > Variables.Cero)
                {
                    oListaTemp = new List<PedidoDetE>(oPedido.ListaPedidoDet);
                }


                
                frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value, oItem, oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalle != null)
                {
                    PedidoDetE ItemDet = oFrm.oDetalle;
                    oPedido.ListaPedidoDet[e.RowIndex] = ItemDet;
                    bsPedido.DataSource = oPedido.ListaPedidoDet;
                    bsPedido.ResetBindings(false);
                    dgvDetalle.AutoResizeColumns();
                    SumarTotal(oPedido.ListaPedidoDet);

                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SumarTotal(List<PedidoDetE> oListaDetalle)
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
                lblTotal.Text = Convert.ToString(Convert.ToDecimal(Total.ToString("N2")));
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

        private void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
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

        private void VerificarVendedor()
        {
            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
            {
                txtNroDocumentoVen.Tag = 0;
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

                    txtNroDocumentoVen.Tag = Convert.ToInt32(oVendedor.idPersona);
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
                    txtNroDocumentoVen.Tag = 0;
                }

                oVendedor = null;
            }
        }

        private void CalcularDetraccion(List<PedidoDetE> oListaDetalle)
        {
            if (oListaDetalle != null && oListaDetalle.Count > 0)
            {
                Decimal? TasaDetraccion = (from x in oListaDetalle where x.indDetraccion == true select (Decimal?)x.TasaDetraccion).Max();
                PedidoDetE det = oListaDetalle.Find
                (
                    delegate (PedidoDetE d) { return d.indDetraccion == true && d.TasaDetraccion == TasaDetraccion; }
                );

                if (det != null)
                {
                    chkDetraccion.Checked = true;
                    cboTipoDetraccion.SelectedValue = det.tipDetraccion.ToString();

                    if (cboTipoDetraccion.SelectedValue != null)
                    {
                        TasasDetraccionesDetalleE oDetraccion = (TasasDetraccionesDetalleE)cboTipoDetraccion.SelectedItem;
                        Decimal.TryParse(lblTotal.Text, out Decimal Monto);

                        //if (cboMonedas.SelectedValue.ToString() != "01")
                        //{
                        //    Decimal.TryParse(txtTica.Text, out Decimal tica);
                        //    Monto *= tica;
                        //}

                        if (oDetraccion != null)
                        {
                            if (Monto > oDetraccion.BaseAfecta || oDetraccion.BaseAfecta == 0)
                            {
                                txtTasaDetra.Text = oDetraccion.Porcentaje.ToString("N2");
                                Decimal.TryParse(lblTotal.Text, out Decimal Importe);

                                txtMontoDetraS.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * Importe, 2).ToString("N2");
                                txtTipoCalculo.Text = "A";
                                chkDetraccion.Enabled = false;
                                cboTipoDetraccion.Enabled = false;
                            }
                            else
                            {
                                chkDetraccion.Checked = false;
                                cboTipoDetraccion.SelectedValue = "0";
                                txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                                txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                            }
                        }
                        else
                        {
                            chkDetraccion.Checked = false;
                            cboTipoDetraccion.SelectedValue = "0";
                            txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                            txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                        }
                    }
                }
                else
                {
                    chkDetraccion.Checked = false;
                    cboTipoDetraccion.SelectedValue = "0";
                    txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                }
            }
        }

        private void LlenarComboDetraccion(DateTime Fecha)
        {
            // Tipo de Detraccion
            List<TasasDetraccionesDetalleE> ListaTipoDetraccion = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(Fecha);

            if (ListaTipoDetraccion.Count > 0)
            {
                ListaTipoDetraccion.Add(new TasasDetraccionesDetalleE() { idTipoDetraccion = Variables.Cero.ToString(), Nombre = "<<Escoger Tasa>>" });
                ComboHelper.RellenarCombos<TasasDetraccionesDetalleE>(cboTipoDetraccion, (from x in ListaTipoDetraccion orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "Nombre", false);
            }
            else
            {
                Global.MensajeFault("No existe ningún Tipo de Detracción para la fecha escogida.");
                cboTipoDetraccion.DataSource = null;
                chkDetraccion.Checked = false;
                chkDetraccion.Enabled = true;
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oPedido == null)
            {
                oPedido = new PedidoCabE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    Estado = "C"
                };

                txtCodPedido.Text = String.Empty;
                txtRucCLiente.Tag = string.Empty;
                txtPuntoLlegada.Tag = 0;
                txtNroDocumentoVen.Tag = 0;
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
                dtFecEmision.Value = Convert.ToDateTime(oPedido.FecCotizacion);

                if (oPedido.Estado != EnumEstadoDocumentos.P.ToString() && oPedido.Estado != EnumEstadoDocumentos.F.ToString())
                {
                    LlenarComboDetraccion(Convert.ToDateTime(oPedido.FecCotizacion));
                }

                TxtEstado.Text = oPedido.DesEstado;
                cboMonedas.SelectedValue = oPedido.idMoneda.ToString();
                DtpFecEntrega.Value = Convert.ToDateTime(oPedido.FecEntrega);
                txtRucCLiente.Tag = oPedido.idFacturar;
                txtRucCLiente.Text = oPedido.RucCliente;
                txtRazonCliente.Text = oPedido.desFacturar;
                txtDireccion.Text = oPedido.DireccionCompleta;
                txtNroDocumentoVen.Tag = oPedido.idVendedor;
                txtNroDocumentoVen.Text = oPedido.numDocVendedor;
                txtNombresVendedor.Text = oPedido.Vendedor;
                TxtObservacion.Text = oPedido.Observacion.Trim();
                txtIdCondicion.Text = oPedido.idCondicion.ToString();
                txtDesCondicion.Text = oPedido.desCondicion;
                cboTipoComprobante.SelectedValue = Convert.ToInt32(oPedido.TipoDoc);
                txtPuntoLlegada.Tag = oPedido.idSucursalCliente;
                txtPuntoLlegada.Text = oPedido.PuntoLlegada;
                txtNumFactura.Text = oPedido.nroFactura;
                txtNumGuia.Text = oPedido.NroGuia;
                txtUsuRegistra.Text = oPedido.UsuarioRegistro;
                txtFecRegistro.Text = oPedido.fechaRegistro.ToString();
                txtUsuModifica.Text = oPedido.UsuarioModificacion;
                txtFecModifica.Text = oPedido.fechaModificacion.ToString();
                TxtEstado.Text = oPedido.DesEstado;
                cboListaPrecio.SelectedValue = oPedido.idTipoPre;




                //chkDetraccion.Checked = oPedido.;

                //if (oPedido.AfectoDetraccion)
                //{
                //    cboTipoDetraccion.SelectedValue = oPedido.tipDetraccion.ToString();
                //    txtTasaDetra.Text = oPedido.TasaDetraccion.ToString("N2");
                //    txtMontoDetraS.Text = oPedido.MontoDetraccion.ToString("N2");
                //}

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                SumarTotal(oPedido.ListaPedidoDet);

                txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
            }
          



            bsPedido.DataSource = oPedido.ListaPedidoDet;
            bsPedido.ResetBindings(false);
            dgvDetalle.AutoResizeColumns();

            if (oPedido.Estado != EnumEstadoDocumentos.C.ToString())//Diferente a cotizado
            {
                if (oPedido.Estado == EnumEstadoDocumentos.P.ToString())
                {
                    Global.MensajeComunicacion("El registro se encuentra como Pedido.\n\rNo podra hacer modificaciones.");
                }

                if (oPedido.Estado == EnumEstadoDocumentos.F.ToString())
                {
                    Global.MensajeComunicacion("El registro se encuentra Facturado.\n\rNo podra hacer modificaciones.");
                }

                pnlPrincipales.Enabled = false;
                pnlDetalle.Enabled = false;
                btNuevoItem.Enabled = false;
                btEliminarItem.Enabled = false;

                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                
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
                bsPedido.EndEdit();
                DatosGrabacion();

                if (ValidarGrabacion())
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion("Desea grabar el Pedido") == DialogResult.Yes)
                        {
                            
                            oPedido = AgenteVentas.Proxy.GrabarPedidosNacionales(oPedido, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(String.Format("Se va actualizar el siguiente Pedido {0}", txtCodPedido.Text)) == DialogResult.Yes)
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
                int moneda = cboListaPrecio.SelectedIndex;
                

                frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(moneda,dtFecEmision.Value, oListaTemp);

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
                        Item = Convert.ToInt32(oPedido.ListaPedidoDet.Max(mx => mx.idItem)+1) ;
                    }

                    //Item = Convert.ToInt32(oPedido.ListaPedidoDet.Max(mx => mx.idItem)) + 1;


                    int cbo =ItemDet.idTipoPrecio=Convert.ToInt32(cboListaPrecio.SelectedIndex);
                    ItemDet.idItem = Item;
                    ItemDet.idTipoPrecio = cbo;
                    
                    
                    oPedido.ListaPedidoDet.Add(ItemDet);
                    bsPedido.DataSource = oPedido.ListaPedidoDet;
                    bsPedido.ResetBindings(false);
                    
                    SumarTotal(oPedido.ListaPedidoDet);
                    CalcularDetraccion(oPedido.ListaPedidoDet);
                    dgvDetalle.AutoResizeColumns();

                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            oPedido.ListaPedidoDet.Remove((PedidoDetE)bsPedido.Current);
            bsPedido.DataSource = oPedido.ListaPedidoDet;
            bsPedido.ResetBindings(false);

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

            if (VariablesLocales.oVenParametros.indVendedor)
            {
                if (Convert.ToInt32(txtNroDocumentoVen.Tag) == 0)
                {
                    txtNombresVendedor.Focus();
                    Global.MensajeFault("Debe escoger un vendedor.");
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(txtRucCLiente.Tag.ToString().Trim()))
            {
                txtRucCLiente.Focus();
                Global.MensajeFault("Debe agregar un cliente.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtDireccion.Text.Trim()))
            {
                Global.MensajeFault("El cliente no tiene direccón.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtPuntoLlegada.Text.Trim()))
            {
                txtPuntoLlegada.Focus();
                Global.MensajeFault("Al cliente le falta Dirección de entrega.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(TxtObservacion.Text.Trim()))
            {
                TxtObservacion.Focus();
                Global.MensajeFault("Falta colocar una observación.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtIdCondicion.Text.Trim()))
            {
                TxtObservacion.Focus();
                Global.MensajeFault("Falta colocar una condición de Venta.");
                return false;
            }

            if (cboTipoComprobante.SelectedValue == null || Convert.ToInt32(cboTipoComprobante.SelectedValue) == 0)
            {
                TxtObservacion.Focus();
                Global.MensajeFault("Debe escoger un tipo de comprobante.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                if (Convert.ToInt32(txtNroDocumentoVen.Tag) == 0 && string.IsNullOrWhiteSpace(txtNroDocumentoVen.Text.Trim()) && string.IsNullOrWhiteSpace(txtNombresVendedor.Text.Trim()))
                {
                    VerificarVendedor(); 
                }

                BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBusquedaPersona oFrm = new FrmBusquedaPersona("Clientes");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                {
                    txtRucCLiente.Tag = oFrm.oPersona.IdPersona;
                    txtRucCLiente.Text = oFrm.oPersona.RUC;
                    txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                    txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                    cboMonedas.SelectedValue= Convert.ToString(oFrm.oPersona.idMoneda);
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

                    if (!indCarteraClientes)
                    {
                        oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text);
                    }
                    else
                    {
                        oListaPersonas = AgenteMaestro.Proxy.ListarCarteraClientesPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRucCLiente.Text, Convert.ToInt32(txtNroDocumentoVen.Tag));
                    }

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucCLiente.Tag = oFrm.oPersona.IdPersona;
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
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);
                        txtRucCLiente.Tag = oListaPersonas[0].IdPersona;
                        txtRucCLiente.Text = oListaPersonas[0].RUC;
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

                        txtRucCLiente.Tag = 0;
                        txtRucCLiente.Text = string.Empty;
                        txtRazonCliente.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
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

                    if (!indCarteraClientes)
                    {
                        oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text);
                    }
                    else
                    {
                        oListaPersonas = AgenteMaestro.Proxy.ListarCarteraClientesPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonCliente.Text, Convert.ToInt32(txtNroDocumentoVen.Tag));
                    }

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRucCLiente.Tag = oFrm.oPersona.IdPersona;
                            txtRucCLiente.Text = oFrm.oPersona.RUC;
                            txtRazonCliente.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            txtPuntoLlegada.Text = oFrm.oPersona.DireccionCompleta;
                            //cboMonedas.SelectedValue = oFrm.oPersona.idMoneda;

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

                        
                        
                        
                        txtRucCLiente.Text = oListaPersonas[0].RUC;
                        txtRucCLiente.Tag = oListaPersonas[0].IdPersona;
                        txtRazonCliente.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        txtPuntoLlegada.Text = oListaPersonas[0].DireccionCompleta;
                        //cboMonedas.SelectedValue = oListaPersonas[0].idMoneda;

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
                        
                        txtRucCLiente.Tag = 0;
                        txtRucCLiente.Text = string.Empty;
                        txtRazonCliente.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtRazonCliente.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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

                    txtNroDocumentoVen.Tag = Convert.ToInt32(oFrm.oVendedor.idPersona);
                    txtNroDocumentoVen.Text = oFrm.oVendedor.NroDocumento;
                    indCarteraClientes = oFrm.oVendedor.ManejaCartera;

                    if (String.IsNullOrEmpty(oFrm.oVendedor.RazonSocial.Trim()))
                    {
                        txtNombresVendedor.Text = oFrm.oVendedor.ApePaterno + " " + oFrm.oVendedor.ApeMaterno + " " + oFrm.oVendedor.Nombres;
                    }
                    else
                    {
                        txtNombresVendedor.Text = oFrm.oVendedor.RazonSocial;
                    }

                    txtNroDocumentoVen.TextChanged += txtNroDocumentoVen_TextChanged;
                    txtNombresVendedor.TextChanged += txtNombresVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
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
                            txtNroDocumentoVen.Tag = Convert.ToInt32(oFrm.oPersona.IdPersona);
                            txtNroDocumentoVen.Text = oFrm.oPersona.RUC;
                            indCarteraClientes = oFrm.oPersona.ManejaCartera;

                            if (string.IsNullOrEmpty(oFrm.oPersona.RazonSocial.Trim()))
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.ApePaterno + " " + oFrm.oPersona.ApeMaterno + " " + oFrm.oPersona.Nombres;
                            }
                            else
                            {
                                txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            }
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtNroDocumentoVen.Tag = Convert.ToInt32(oListaPersonas[0].IdPersona);
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
                        txtNroDocumentoVen.Tag = 0;
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
                            txtNroDocumentoVen.Tag = Convert.ToInt32(oFrm.oPersona.IdPersona);
                            txtNombresVendedor.Text = oFrm.oPersona.RazonSocial;
                            indCarteraClientes = oFrm.oPersona.ManejaCartera;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtNroDocumentoVen.Text = oListaPersonas[0].RUC;
                        txtNroDocumentoVen.Tag = Convert.ToInt32(oListaPersonas[0].IdPersona);
                        txtNombresVendedor.Text = oListaPersonas[0].RazonSocial;
                        indCarteraClientes = oListaPersonas[0].ManejaCartera;
                    }
                    else
                    {
                        Global.MensajeFault("El Nro. de Documento ingresado no existe");
                        txtNroDocumentoVen.Tag = 0;
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
                txtRucCLiente.Tag = 0;
                txtRazonCliente.Text = String.Empty;
                txtDireccion.Text = String.Empty;
            }
        }

        private void txtRazonCliente_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonCliente.Text.Trim()))
            {
                txtRucCLiente.Tag = 0;
                txtRucCLiente.Text = String.Empty;
                txtDireccion.Text = String.Empty;
            }
        }

        private void txtNroDocumentoVen_TextChanged(object sender, EventArgs e)
        {
            txtNroDocumentoVen.Tag = 0;
            txtNombresVendedor.Text = String.Empty;
        }

        private void txtNombresVendedor_TextChanged(object sender, EventArgs e)
        {
            txtNroDocumentoVen.Tag = 0;
            txtNroDocumentoVen.Text = String.Empty;
        }

        private void txtRazonCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void txtNombresVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
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

        private void dtFecEmision_KeyPress(object sender, KeyPressEventArgs e)
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
                    EditarDetalle(e, (PedidoDetE)bsPedido.Current);
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
                    //txtIdTipCondicion.Text = oFrm.oCondicion.idTipCondicion.ToString();
                    txtIdCondicion.Text = oFrm.oCondicion.idCondicion.ToString("00");
                    txtDesCondicion.Text = oFrm.oCondicion.desCondicion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void btBuscarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtRucCLiente.Tag) == 0)
                {
                    Global.MensajeFault("Tiene que escoger un cliente antes de buscar otra dirección");
                    return;
                }

                List<PersonaDireccionE> oListaDirecciones = AgenteMaestro.Proxy.ListarPersonaDireccion(Convert.ToInt32(txtRucCLiente.Tag));
                frmBuscarSucursalCliente oFrm = new frmBuscarSucursalCliente(oListaDirecciones);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDireccion != null)
                {
                    txtPuntoLlegada.Tag = oFrm.oDireccion.IdDireccion;
                    txtPuntoLlegada.Text = oFrm.oDireccion.DireccionCompleta;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
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

        private void btSunat_Click(object sender, EventArgs e)
        {
            frmBuscarRucBasico oFrm = new frmBuscarRucBasico(txtRucCLiente.Text, indCarteraClientes, Convert.ToInt32(txtNroDocumentoVen.Tag));

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
                            fecInscripcion = null,
                            fecInicioEmpresa = null,
                            tipConstitucion = 0,
                            tipRegimen = 0,
                            catCliente = 0,
                            idMoneda = "01",
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial

                        };

                        AgenteMaestro.Proxy.InsertarCliente(oCliente);
                    }


                    txtRucCLiente.Tag = oFrm.oPersona.IdPersona;

                    if (indCarteraClientes)
                    {
                        if (Global.MensajeConfirmacion("Desea agregar al cliente a su cartera de clientes.") == DialogResult.Yes)
                        {
                            VendedoresCarteraE oClienteCartera = new VendedoresCarteraE()
                            {
                                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                idVendedor = Convert.ToInt32(txtNroDocumentoVen.Tag),
                                idCliente = Convert.ToInt32(txtRucCLiente.Tag),
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

        #endregion Eventos


    }
}
