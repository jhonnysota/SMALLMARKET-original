using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmNotaDebitoUf : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmNotaDebitoUf()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetalle, true);
            LlenarAyuda();
        }

        //Edición
        public frmNotaDebitoUf(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero, List<NumControlDetE> ListaDetalle)
            : this()
        {
            DocumentoEmitido = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);
            Boolean Entro = false;

            if (DocumentoEmitido.EnviadoSunat)
            {
                Global.MensajeFault("Este documento ha sido enviado a sunat, no puede hacer modificaciones.");
                dgvDetalle.ClearSelection();
                BloquearPaneles(false);
                HabilitaBotones = false;
                Entro = true;
            }

            if (!Entro)
            {
                if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.E.ToString())
                {
                    Global.MensajeFault("Este documento ha sido Emitido, no puede hacer ninguna modificación.");
                    dgvDetalle.ClearSelection();
                    BloquearPaneles(false);
                    HabilitaBotones = false;
                    Entro = true;
                }
            }

            if (!Entro)
            {
                if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.B.ToString())
                {
                    Global.MensajeFault("Este documento ha sido Anulado, no puede hacer ninguna modificación.");
                    dgvDetalle.ClearSelection();
                    BloquearPaneles(false);
                    HabilitaBotones = false;
                }
            }
        }

        //Nuevo
        public frmNotaDebitoUf(List<NumControlDetE> ListaDetalle)
            : this()
        {
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        EmisionDocumentoE DocumentoEmitido = null;
        List<NumControlDetE> ListaDocumentosControl = null;

        Int16 Opcion;
        Int32 idControlTmp = 0;
        Boolean HabilitaBotones = true;
        Decimal totdsc1 = 0;
        Decimal totdsc2 = 0;
        Decimal totdsc3 = 0;
        Int32? CanalVenta = Variables.Cero;
        String CambioRef = Variables.NO;
        Boolean Bloqueo = true;

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Datos para saber si se trata de Guia, Factura o exportacion
            cboEsGuia.DataSource = Global.CargarEsGuia();
            cboEsGuia.ValueMember = "id";
            cboEsGuia.DisplayMember = "Nombre";

            //Llenando las monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, listaMonedas, "idMoneda", "desAbreviatura");

            //Llenando los documentos existentes...
            var oListaDocumentos = ListaDocumentosControl.GroupBy(x => x.idDocumento).Select(p => p.First()).ToList();
            oListaDocumentos.Add(new NumControlDetE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.LlenarCombos<NumControlDetE>(cboTipoDocumento, oListaDocumentos, "idDocumento", "desDocumento");

            List<DocumentosE> oListaDocumentosRef = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                          where x.indBaja == false
                                                                          && x.EsReferencia == true
                                                                          select x).ToList();

            oListaDocumentosRef.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione, EsReferencia = true });
            ComboHelper.RellenarCombos<DocumentosE>(cboReferencia, (from x in oListaDocumentosRef
                                                                    orderby x.desDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);

            if (VariablesLocales.oVenParametros.indAfectacionIgv) //Solo para el Fundo San Miguel
            {
                //Razón de exoneración del IGV
                //List<ParTabla> oListaExoneracion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPAFEIGV");
                //oListaExoneracion.Add(new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione });
                //ComboHelper.LlenarCombos<ParTabla>(cboExoneracion, (from x in oListaExoneracion orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");
                List<AfectacionIgvE> ListaAfectacion = AgenteMaestro.Proxy.ListarAfectacionIgvActivos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                ListaAfectacion.Add(new AfectacionIgvE() { idAfectacion = 0, desTemporal = Variables.Seleccione });
                ComboHelper.LlenarCombos<AfectacionIgvE>(cboExoneracion, (from x in ListaAfectacion orderby x.idAfectacion select x).ToList(), "idAfectacion", "desTemporal");
            }

            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");
        }

        void LlenarAyuda()
        {
            //Global.CrearToolTip(btBuscarCliente, "Buscar Cliente.");
            //Global.CrearToolTip(btBuscarDireccion, "Buscar otra direccion(Sucursal).");
            Global.CrearToolTip(btBuscarVendedor, "Buscar vendedor.");
            Global.CrearToolTip(btBuscarCondicion, "Buscar condiciones de venta.");
        }

        void ValoresPorDefecto(String Serie)
        {
            NumControlDetE Detalle = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idControlTmp,
                                    cboTipoDocumento.SelectedValue.ToString(), Serie);
            //NumControlDetE Detalle = (from x in VariablesLocales.ListaDetalleNumControl
            //                          where x.idEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
            //                          && x.idLocal == VariablesLocales.SesionLocal.IdLocal
            //                          && x.idControl == idControlTmp
            //                          && x.idDocumento == cboTipoDocumento.SelectedValue.ToString()
            //                          && x.Serie == Serie
            //                          select x).FirstOrDefault();

            if (Detalle != null)
            {
                cboMonedas.SelectedValue = Detalle.idMoneda;
                txtNumDocumento.MaxLength = Convert.ToInt32(Detalle.cantDigNumero);
                txtNumDocumento.Text = DevolverNumeroCorrelativo(Detalle.numCorrelativo, Convert.ToInt32(Detalle.cantDigNumero));

                if (Detalle.idCondicion != null && Detalle.idCondicion > Variables.Cero)
                {
                    txtIdCondicion.Text = Convert.ToInt32(Detalle.idCondicion).ToString("00");

                    CondicionE tmpCondicion = AgenteVentas.Proxy.ObtenerCondicion((Int32)EnumTipoCondicionVenta.NotaDebito, Convert.ToInt32(Detalle.idCondicion));
                    txtDesCondicion.Text = tmpCondicion.desCondicion;
                }
            }
        }

        void DatosGrabacion()
        {
            DocumentoEmitido.idDocumento = cboTipoDocumento.SelectedValue.ToString();
            DocumentoEmitido.numSerie = cboSeries.SelectedValue.ToString();
            DocumentoEmitido.numDocumento = txtNumDocumento.Text;
            DocumentoEmitido.TipoAsiento = "01";
            DocumentoEmitido.fecEmision = dtFecEmision.Value.ToString("yyyyMMdd");
            DocumentoEmitido.Anio = dtFecEmision.Value.ToString("yyyy");
            DocumentoEmitido.Mes = dtFecEmision.Value.ToString("MM");
            DocumentoEmitido.fecVencimiento = dtFecEmision.Value.ToString("yyyyMMdd");
            DocumentoEmitido.indRecepcion = false;
            DocumentoEmitido.fecRecepcion = (Nullable<DateTime>)null;
            DocumentoEmitido.Direccion = txtDireccion.Text;
            DocumentoEmitido.EsGuia = cboEsGuia.SelectedValue.ToString();

            if (!String.IsNullOrEmpty(txtIdCondicion.Text.Trim()))
            {
                DocumentoEmitido.idTipCondicion = (Int32)EnumTipoCondicionVenta.NotaDebito;
                DocumentoEmitido.idCondicion = Convert.ToInt32(txtIdCondicion.Text);
            }
            else
            {
                DocumentoEmitido.idTipCondicion = null;
                DocumentoEmitido.idCondicion = null;
            }

            DocumentoEmitido.idMoneda = cboMonedas.SelectedValue.ToString();
            DocumentoEmitido.tipCambio = Convert.ToDecimal(txtTica.Text);
            DocumentoEmitido.totMontoBruto = Convert.ToDecimal(lblTotal.Text);
            DocumentoEmitido.totsubTotal = Convert.ToDecimal(lblSubTotal.Text);
            DocumentoEmitido.totDscto1 = totdsc1;
            DocumentoEmitido.totDscto2 = totdsc2;
            DocumentoEmitido.totDscto3 = totdsc3;
            DocumentoEmitido.totIgv = Convert.ToDecimal(lblIgv.Text);
            DocumentoEmitido.totTotal = Convert.ToDecimal(lblTotal.Text);
            DocumentoEmitido.Glosa = txtGlosa.Text;

            if (VariablesLocales.oVenParametros.indZona)
            {
                DocumentoEmitido.idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
                DocumentoEmitido.idZona = cboZona.SelectedValue != null ? Convert.ToInt32(cboZona.SelectedValue) : (Int32?)null;
            }
            else
            {
                DocumentoEmitido.idEstablecimiento = null;
                DocumentoEmitido.idZona = null;
            }

            if (cboReferencia.SelectedValue.ToString() != Variables.Cero.ToString())
            {
                DocumentoEmitido.idDocumentoRef = cboReferencia.SelectedValue.ToString();
                DocumentoEmitido.serDocumentoRef = txtSerieRef.Text;
                DocumentoEmitido.numDocumentoRef = txtNumDocumentoRef.Text;
                DocumentoEmitido.fecDocumentoRef = dtpFecReferencia.Value.Date;
                DocumentoEmitido.TotalRef = Convert.ToDecimal(lblTotal.Text);

                if (!String.IsNullOrWhiteSpace(txtIdCondicionRef.Text))
                {
                    DocumentoEmitido.idTipCondicionRef = Convert.ToInt32(txtIdCondicionRef.Tag);
                    DocumentoEmitido.idCondicionRef = Convert.ToInt32(txtIdCondicionRef.Text);
                    DocumentoEmitido.desCondicionRef = txtDesCondicionRef.Text;
                }
                else
                {
                    DocumentoEmitido.idTipCondicionRef = null;
                    DocumentoEmitido.idCondicionRef = null;
                    DocumentoEmitido.desCondicionRef = txtDesCondicionRef.Text.Trim();
                }
            }

            DocumentoEmitido.totAfectoPerce = Variables.ValorCeroDecimal;
            DocumentoEmitido.totPercepcion = Variables.ValorCeroDecimal;
            DocumentoEmitido.indEstado = EnumEstadoDocumentos.C.ToString();

            //Datos Clientes
            DocumentoEmitido.idPersona = Convert.ToInt32(txtRuc.Tag);
            DocumentoEmitido.numRuc = txtRuc.Text;
            DocumentoEmitido.RazonSocial = txtRazonSocial.Text;
            DocumentoEmitido.idCanalVenta = CanalVenta;

            //Para saber si tiene asignado algun voucher
            if (!String.IsNullOrEmpty(DocumentoEmitido.numFile) && !String.IsNullOrEmpty(DocumentoEmitido.numVoucher))
            {
                DocumentoEmitido.indVoucher = false;
            }

            if (VariablesLocales.oVenParametros.indVendedor)
            {
                DocumentoEmitido.idVendedor = String.IsNullOrWhiteSpace(txtIdVendedor.Text) ? (int?)null : Convert.ToInt32(txtIdVendedor.Text);
            }
            else
            {
                DocumentoEmitido.idVendedor = null;
            }

            DocumentoEmitido.nroDocAsociado = Convert.ToInt32(txtNroAsociado.Tag);
            DocumentoEmitido.fecEnvioSunat = null;
            DocumentoEmitido.fecAnuladoSunat = null;

            if (VariablesLocales.oVenParametros.indAfectacionIgv) //Solo para el Fundo San Miguel
            {
                DocumentoEmitido.tipAfectoIgv = Convert.ToInt32(cboExoneracion.SelectedValue);
            }
            else
            {
                DocumentoEmitido.tipAfectoIgv = Variables.Cero;
            }

            DocumentoEmitido.EsAnticipo = false;
            DocumentoEmitido.indAnticipo = false;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                DocumentoEmitido.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlComprobante.Enabled = Flag;
            pnlCliente.Enabled = Flag;
            pnlDetalle.Enabled = Flag;
            pnlReferencia.Enabled = Flag;
            btAgregarNota.Enabled = Flag;
            txtGlosa.Enabled = Flag;
            btAgregarNota.Enabled = Flag;
            cboExoneracion.Enabled = Flag;
            Bloqueo = Flag;
            //pnlPedido.Enabled = Flag;
        }

        void BloquearPanelComprobante(Boolean Flag)
        {
            cboTipoDocumento.Enabled = Flag;
            cboSeries.Enabled = Flag;
            txtNumDocumento.Enabled = Flag;
        }

        void SumarTotal(List<EmisionDocumentoDetE> oListaDetalle)
        {
            if (oListaDetalle != null && oListaDetalle.Count > Variables.Cero)
            {
                Decimal SubTotal = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.subTotal).Sum(), 2);
                //Decimal ValorGravado = Decimal.Round((from x in oListaDetalle where x.flgIgv == true select x.subTotal).Sum(), 2);
                //Decimal ValorNoGravado = Decimal.Round((from x in oListaDetalle where x.flgIgv == false select x.subTotal).Sum(), 2);
                Decimal Igv = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Igv).Sum(), 2);
                Decimal Total = Decimal.Round((from x in oListaDetalle where x.indCalculo == true select x.Total).Sum(), 2);

                lblIgv.Text = Igv.ToString("N2");
                lblSubTotal.Text = SubTotal.ToString("N2");
                lblTotal.Text = Total.ToString("N2");
            }
        }

        String DevolverNumeroCorrelativo(String Correlativo, Int32 cantDigitos)
        {
            Int32 Numero = 0;
            String numFinal = String.Empty;

            if (String.IsNullOrEmpty(Correlativo))
            {
                Numero = Variables.Cero;
            }
            else
            {
                Numero = Convert.ToInt32(Correlativo);
            }

            Numero++;
            numFinal = Numero.ToString().PadLeft(cantDigitos, '0');
            return numFinal;
        }

        void EditarDetalle(DataGridViewCellEventArgs e, EmisionDocumentoDetE oItem)
        {
            if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).tipArticulo == "AN")/// Anticipos...
            {
                frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, oItem, "A");
                String sItem = oItem.Item;

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocumento != null)
                {
                    EmisionDocumentoDetE ItemDet = oFrm.oDetalleDocumento;
                    ItemDet.Item = sItem;
                    ItemDet.tipArticulo = "AN";

                    if (oFrm.EsCompleto)
                    {
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex] = ItemDet;
                    }
                    else
                    {
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].nomArticulo = ItemDet.nomArticulo;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Cantidad = ItemDet.Cantidad;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].CantidadFinal = ItemDet.Cantidad;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].flgIgv = ItemDet.flgIgv;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].PrecioSinImpuesto = ItemDet.PrecioSinImpuesto;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].PrecioConImpuesto = ItemDet.PrecioConImpuesto;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].subTotal = ItemDet.subTotal;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Igv = ItemDet.Igv;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Dscto1 = ItemDet.Dscto1;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Dscto2 = ItemDet.Dscto2;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Dscto3 = ItemDet.Dscto3;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Igv = ItemDet.Igv;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].porIgv = ItemDet.porIgv;
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Total = ItemDet.Total;
                    }

                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);

                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                }
            }
            else
            {
                if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).tipArticulo == "SE") /// Servicios...
                {
                    frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, oItem, "S");
                    String sItem = oItem.Item;

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocumento != null)
                    {
                        EmisionDocumentoDetE ItemDet = oFrm.oDetalleDocumento;
                        ItemDet.Item = sItem;
                        ItemDet.tipArticulo = "SE";

                        if (oFrm.EsCompleto)
                        {
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex] = ItemDet;
                        }
                        else
                        {
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].nomArticulo = ItemDet.nomArticulo;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Cantidad = ItemDet.Cantidad;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].CantidadFinal = ItemDet.Cantidad;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].flgIgv = ItemDet.flgIgv;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].PrecioSinImpuesto = ItemDet.PrecioSinImpuesto;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].PrecioConImpuesto = ItemDet.PrecioConImpuesto;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].subTotal = ItemDet.subTotal;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Igv = ItemDet.Igv;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Dscto1 = ItemDet.Dscto1;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Dscto2 = ItemDet.Dscto2;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Dscto3 = ItemDet.Dscto3;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Igv = ItemDet.Igv;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].porIgv = ItemDet.porIgv;
                            DocumentoEmitido.ListaItemsDocumento[e.RowIndex].Total = ItemDet.Total;
                        }

                        bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                        bsDetalleDocumento.ResetBindings(false);

                        SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                    }
                }
                else if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).tipArticulo == "AR") /// Articulos...
                {
                    List<EmisionDocumentoDetE> oListaTemp = null;

                    if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                    {
                        oListaTemp = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
                    }

                    frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value.Date, oItem, oListaTemp, Bloqueo);
                    String sItem = oItem.Item;

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocEmision != null)
                    {
                        EmisionDocumentoDetE ItemDet = oFrm.oDetalleDocEmision;
                        ItemDet.tipArticulo = "AR";
                        DocumentoEmitido.ListaItemsDocumento[e.RowIndex] = ItemDet;
                        bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                        bsDetalleDocumento.ResetBindings(false);

                        SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                    }
                }
            }
        }

        void BuscarDocumento()
        {
            try
            {
                String idDocumentoRef = cboReferencia.SelectedValue.ToString();
                String Validar = Variables.SI;

                if (String.IsNullOrEmpty(idDocumentoRef) || idDocumentoRef == Variables.Cero.ToString())
                {
                    Global.MensajeFault("Debe escoger un documento de referencia.");
                    return;
                }

                if (idDocumentoRef == EnumTipoDocumentoVenta.OC.ToString())
                {
                    Validar = Variables.NO;
                }

                if (Validar == Variables.SI)
                {
                    if (idDocumentoRef != EnumTipoDocumentoVenta.LT.ToString() && CambioRef == "S")
                    {
                        String SerieRef = txtSerieRef.Text;
                        String NumeroRef = txtNumDocumentoRef.Text;

                        if (SerieRef == "")
                        {
                            txtSerieRef.Focus();
                            Global.MensajeAdvertencia("Ingrese serie de referencia");
                            return;
                        }

                        if (NumeroRef == "")
                        {
                            txtNumDocumentoRef.Focus();
                            Global.MensajeAdvertencia("Ingrese numero de referencia");
                            return;
                        }

                        //Revisando si el documento ha sido referenciado en otro documento
                        EmisionDocumentoE DocumentoReferencia = null;

                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Solo para el Fundo San Miguel
                        {
                            DocumentoReferencia = null;
                        }
                        else
                        {
                            DocumentoReferencia = AgenteVentas.Proxy.RevisarEmisionDocumentoReferencias(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idDocumentoRef, SerieRef, NumeroRef, cboTipoDocumento.SelectedValue.ToString(), cboSeries.SelectedValue.ToString(), txtNumDocumento.Text);
                        }

                        if (DocumentoReferencia == null)
                        {
                            //Recuperando el documento completo si no existe referencia hacia el
                            DocumentoReferencia = AgenteVentas.Proxy.RecuperarDocumentoCompleto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idDocumentoRef, SerieRef, NumeroRef);

                            if (DocumentoReferencia != null)
                            {
                                if (DocumentoReferencia.indEstado == EnumEstadoDocumentos.B.ToString() || DocumentoReferencia.indEstado == EnumEstadoDocumentos.C.ToString())
                                {
                                    CambioRef = "N";
                                    Global.MensajeFault("Solo se pueden generar Notas de Crédito para documentos emitidos.");
                                    return;
                                }

                                dtpFecReferencia.Value = Convert.ToDateTime(DocumentoReferencia.fecEmision);
                                txtRuc.Tag = DocumentoReferencia.idPersona;
                                txtRuc.Text = DocumentoReferencia.numRuc;
                                txtRazonSocial.Text = DocumentoReferencia.RazonSocial;
                                txtDireccion.Text = DocumentoReferencia.Direccion;
                                cboMonedas.SelectedValue = DocumentoReferencia.idMoneda.ToString();
                                cboMonedas.Enabled = false;
                                CanalVenta = DocumentoReferencia.idCanalVenta;
                                txtIdCondicionRef.Tag = DocumentoReferencia.idTipCondicion;
                                txtIdCondicionRef.Text = DocumentoReferencia.idCondicion.Value.ToString("00");
                                txtDesCondicionRef.Text = DocumentoReferencia.desCondicion;
                                txtIdVendedor.Text = DocumentoReferencia.idVendedor == 0 ? String.Empty : DocumentoReferencia.idVendedor.ToString();
                                txtVendedor.Text = DocumentoReferencia.Vendedor;
                                cboEstablecimiento.SelectedValue = DocumentoReferencia.idEstablecimiento;
                                cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                                cboZona.SelectedValue = DocumentoReferencia.idZona;

                                if (VariablesLocales.oVenParametros.indAfectacionIgv) //Solo para el Fundo San Miguel
                                {
                                    if (DocumentoReferencia.tipAfectoIgv != null)
                                    {
                                        cboExoneracion.SelectedValue = Convert.ToInt32(DocumentoReferencia.tipAfectoIgv);
                                    } 
                                }

                                //Si tiene pedido
                                if (DocumentoReferencia.nroDocAsociado != 0)
                                {
                                    txtNroAsociado.Tag = DocumentoReferencia.nroDocAsociado;
                                    txtNroAsociado.Text = DocumentoReferencia.Pedido;
                                }
                                else
                                {
                                    txtNroAsociado.Tag = 0;
                                }

                                foreach (EmisionDocumentoDetE item in DocumentoReferencia.ListaItemsDocumento)
                                {
                                    if (item.flgIgv)
                                    {
                                        lblPorIgv.Text = "IGV " + item.porIgv.ToString() + "%";
                                    }
                                    else
                                    {
                                        lblPorIgv.Text = "IGV %";
                                    }

                                    //item.subTotal = item.Total;
                                    item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                    item.FechaRegistro = VariablesLocales.FechaHoy;
                                    item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                    item.FechaModificacion = VariablesLocales.FechaHoy;
                                }

                                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento = DocumentoReferencia.ListaItemsDocumento;
                                bsDetalleDocumento.ResetBindings(false);

                                SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                                CambioRef = "N";
                            }
                            else
                            {
                                CambioRef = "N";
                                Global.MensajeFault(String.Format("El documento {0} {1}-{2} ingresado no existe.", idDocumentoRef, SerieRef, NumeroRef));
                            }
                        }
                        else
                        {
                            CambioRef = "N";
                            if (VariablesLocales.SesionUsuario.Empresa.RUC != "20452630886") //Solo para el Fundo San Miguel
                            {
                                Global.MensajeFault(String.Format("Este documento {0} {1}-{2} ya ha sido referenciado en {3}", idDocumentoRef, SerieRef, NumeroRef, DocumentoReferencia.idDocumento + " " + DocumentoReferencia.numSerie + "-" + DocumentoReferencia.numDocumento));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CambioRef = "N";
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            if (DocumentoEmitido == null)
            {
                Opcion = (Int16)EnumOpcionGrabar.Insertar;

                DocumentoEmitido = new EmisionDocumentoE()
                {
                    ListaItemsDocumento = new List<EmisionDocumentoDetE>(),

                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                if (VariablesLocales.oVenParametros.indAfectacionIgv) //Solo para el Fundo San Miguel
                {
                    cboExoneracion.SelectedValue = Convert.ToInt32(VariablesLocales.oVenParametros.razonExoIgv);
                }

                txtNroAsociado.Tag = 0;
                txtRuc.Tag = 0;
                BloquearPanelComprobante(true);
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                dtFecEmision_ValueChanged(null, null);
                dtpFecReferencia_ValueChanged(null, null);

                Text = "Nota de Débito (Nuevo)";
            }
            else
            {
                txtSerieRef.TextChanged -= txtSerieRef_TextChanged;
                txtNumDocumentoRef.TextChanged -= txtNumDocumentoRef_TextChanged;

                Opcion = Convert.ToInt16(EnumOpcionGrabar.Actualizar);

                cboTipoDocumento.SelectedValue = DocumentoEmitido.idDocumento;
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                txtNumDocumento.Text = DocumentoEmitido.numDocumento;
                cboSeries.SelectedValue = DocumentoEmitido.numSerie.ToString();
                BloquearPanelComprobante(false);
                dtFecEmision.ValueChanged -= new EventHandler(dtFecEmision_ValueChanged);
                dtFecEmision.Value = Convert.ToDateTime(DocumentoEmitido.fecEmision);
                dtFecEmision.ValueChanged += new EventHandler(dtFecEmision_ValueChanged);
                cboReferencia.SelectedValue = DocumentoEmitido.idDocumentoRef;
                txtSerieRef.Text = DocumentoEmitido.serDocumentoRef;
                txtNumDocumentoRef.Text = DocumentoEmitido.numDocumentoRef;

                if (!String.IsNullOrEmpty(DocumentoEmitido.fecDocumentoRef.ToString()))
                {
                    dtpFecReferencia.Value = Convert.ToDateTime(DocumentoEmitido.fecDocumentoRef);
                }

                txtIdCondicionRef.Tag = DocumentoEmitido.idTipCondicion != 0 ? DocumentoEmitido.idTipCondicionRef : 0;
                txtIdCondicionRef.Text = DocumentoEmitido.idCondicionRef != 0 ? DocumentoEmitido.idCondicionRef.Value.ToString("00") : String.Empty;
                txtDesCondicionRef.Text = DocumentoEmitido.desCondicionRef;

                cboMonedas.SelectedValue = DocumentoEmitido.idMoneda;
                txtTica.Text = DocumentoEmitido.tipCambio.ToString();

                txtIdCondicion.Text = Convert.ToInt32(DocumentoEmitido.idCondicion).ToString("00");
                txtDesCondicion.Text = DocumentoEmitido.desCondicion;

                txtRuc.Tag = DocumentoEmitido.idPersona;
                txtRuc.Text = DocumentoEmitido.numRuc;
                txtRazonSocial.Text = DocumentoEmitido.RazonSocial;
                txtDireccion.Text = DocumentoEmitido.Direccion;
                txtIdVendedor.Text = DocumentoEmitido.idVendedor == 0 ? String.Empty : DocumentoEmitido.idVendedor.ToString();
                txtVendedor.Text = DocumentoEmitido.Vendedor;
                txtGlosa.Text = DocumentoEmitido.Glosa;
                cboEstablecimiento.SelectedValue = DocumentoEmitido.idEstablecimiento;
                cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                cboZona.SelectedValue = DocumentoEmitido.idZona;
                cboEsGuia.SelectedValue = DocumentoEmitido.EsGuia;

                //Si hay pedido
                if (DocumentoEmitido.nroDocAsociado != 0)
                {
                    txtNroAsociado.Tag = DocumentoEmitido.nroDocAsociado;
                    txtNroAsociado.Text = DocumentoEmitido.Pedido;
                }
                else
                {
                    txtNroAsociado.Tag = 0;
                }

                if (DocumentoEmitido.ListaItemsDocumento == null)
                {
                    DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                }

                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                bsDetalleDocumento.ResetBindings(false);
                SumarTotal(DocumentoEmitido.ListaItemsDocumento);

                if (VariablesLocales.oVenParametros.indAfectacionIgv) //Solo para el Fundo San Miguel
                {
                    if (DocumentoEmitido.tipAfectoIgv != null)
                    {
                        cboExoneracion.SelectedValue = Convert.ToInt32(DocumentoEmitido.tipAfectoIgv);
                    }
                }

                foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                {
                    if (item.flgIgv == true)
                    {
                        lblPorIgv.Text = "IGV " + item.porIgv.ToString() + "%";
                        break;
                    }
                }

                Text = "Nota de Débito (" + DocumentoEmitido.numSerie + "-" + DocumentoEmitido.numDocumento + ")";

                txtSerieRef.TextChanged += txtSerieRef_TextChanged;
                txtNumDocumentoRef.TextChanged += txtNumDocumentoRef_TextChanged;
            }

            if (HabilitaBotones)
            {
                base.Nuevo();
            }
            else
            {
                btArticulos.Enabled = false;
                btServicios.Enabled = false;
                btEliminarItem.Enabled = false;

                Bloqueo = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                bsDetalleDocumento.EndEdit();
                DatosGrabacion();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (Convert.ToDecimal(lblTotal.Text) == Variables.Cero)
                {
                    if (Global.MensajeConfirmacion("La Factura no tiene Total. Falta ingresar precios.\n\rDesea continuar") == DialogResult.No)
                    {
                        return;
                    }
                }

                if (Opcion == Convert.ToInt16(EnumOpcionGrabar.Insertar))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        DocumentoEmitido = AgenteVentas.Proxy.GrabarDocumentos(DocumentoEmitido, EnumOpcionGrabar.Insertar, null, Variables.SI.ToString());
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        DocumentoEmitido = AgenteVentas.Proxy.GrabarDocumentos(DocumentoEmitido, EnumOpcionGrabar.Actualizar, null, Variables.SI);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                VariablesLocales.ListaDetalleNumControl = AgenteVentas.Proxy.ListarNumControlDetPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            //frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, 1, String.Empty);

            //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocumento != null)
            //{
            //    Int32 Item = Variables.ValorUno;
            //    EmisionDocumentoDetE ItemDetalle = oFrm.oDetalleDocumento;

            //    if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
            //    {
            //        Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
            //    }

            //    ItemDetalle.Item = String.Format("{0:000}", Item);
            //    DocumentoEmitido.ListaItemsDocumento.Add(ItemDetalle);
            //    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
            //    bsDetalleDocumento.ResetBindings(false);

            //    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
            //}
        }

        public override void QuitarDetalle()
        {
            //if (bsDetalleDocumento.Current != null)
            //{
            //    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
            //    {
            //        base.QuitarDetalle();
            //        //Int32 numItem = Variables.ValorUno;
            //        //EmisionDocumentoDetE oItem = null;

            //        DocumentoEmitido.ListaItemsDocumento.RemoveAt(bsDetalleDocumento.Position);
            //        List<EmisionDocumentoDetE> ListaAuxiliar = new List<EmisionDocumentoDetE>();

            //        //foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
            //        //{
            //        //    //oItem = new EmisionDocumentoDetE();
            //        //    //oItem = item;
            //        //    item.Item = String.Format("{0:000}", numItem);
            //        //    numItem++;
            //        //    //ListaAuxiliar.Add(oItem);
            //        //}

            //        bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
            //        bsDetalleDocumento.ResetBindings(false);
            //        SumarTotal(DocumentoEmitido.ListaItemsDocumento);
            //    }
            //}
        }

        public override bool ValidarGrabacion()
        {
            if (DocumentoEmitido.ListaItemsDocumento.Count == 0)
            {
                MessageBox.Show("Ingrese Detalle de Factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                {
                    if (item.Cantidad <= Variables.Cero)
                    {
                        Global.MensajeFault(String.Format("La cantidad no puede ser 0. Revisar el articulo {0}", item.nomArticulo));
                        return false;
                    }
                }
            }

            if (VariablesLocales.oVenParametros.indZona)
            {
                if (cboEstablecimiento.SelectedValue == null || Convert.ToInt32(cboEstablecimiento.SelectedValue) == 0)
                {
                    Global.MensajeFault("Debe escoger una Zona.");
                    return false;
                }
                else
                {
                    if (cboZona.SelectedValue == null || Convert.ToInt32(cboZona.SelectedValue) == 0)
                    {
                        Global.MensajeFault("Debe escoger una Zona de Influencia.");
                        return false;
                    }
                }
            }

            if (String.IsNullOrEmpty(DocumentoEmitido.numRuc))
            {
                MessageBox.Show("Ingrese Información del Cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrEmpty(DocumentoEmitido.Glosa))
            {
                MessageBox.Show("Es obligatorio ingresar una observación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtGlosa.Focus();
                return false;
            }

            if (DocumentoEmitido.idDocumentoRef.ToString() == "0")
            {
                MessageBox.Show("Es obligatorio el tipo de documento de la referencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSerieRef.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(DocumentoEmitido.serDocumentoRef))
            {
                MessageBox.Show("Es obligatorio la serie de la referencia del documento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSerieRef.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(DocumentoEmitido.numDocumentoRef))
            {
                MessageBox.Show("Es obligatorio el Número de la referencia del documento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumDocumentoRef.Focus();
                return false;
            }

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Solo para el Fundo San Miguel
            {
                if (Convert.ToInt32(cboExoneracion.SelectedValue) == Variables.Cero)
                {
                    MessageBox.Show("Debe escoger un código de Razón de Exoneración de IGV.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboExoneracion.Focus();
                    return false;
                }
            }

            if (VariablesLocales.oVenParametros.indVendedor)
            {
                if (String.IsNullOrWhiteSpace(txtIdVendedor.Text))
                {
                    MessageBox.Show("Debe escoger un vendedor. Es obligatorio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimiento Heredados

        #region Eventos

        private void frmNotaDebitoUf_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            Nuevo();

            if (VariablesLocales.oVenParametros.indAfectacionIgv) //Solo para el Fundo San Miguel
            {
                cboExoneracion.Visible = true;
                label4.Visible = true;
            }

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        private void dtFecEmision_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime Fecha = dtFecEmision.Value.Date;
            //    TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMonedas.SelectedValue.ToString(), Fecha);

            //    if (Tica != null)
            //    {
            //        txtTica.Text = Tica.valVenta.ToString("N3");
            //    }
            //    else
            //    {
            //        txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
            //        dtFecEmision.Focus();
            //        Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeError(ex.Message);
            //}
        }

        private void dtpFecReferencia_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = dtpFecReferencia.Value.Date;
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMonedas.SelectedValue.ToString(), Fecha);

                if (Tica != null)
                {
                    txtTica.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtpFecReferencia.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<NumControlDetE> ListaDetalle = new List<NumControlDetE>(from x in VariablesLocales.ListaDetalleNumControl
                                                                         where x.idControl == ((NumControlDetE)cboTipoDocumento.SelectedItem).idControl
                                                                         && x.idDocumento == cboTipoDocumento.SelectedValue.ToString() orderby x.Orden
                                                                         select x).ToList(); 

            idControlTmp = ((NumControlDetE)cboTipoDocumento.SelectedItem).idControl;

            ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");
            cboSeries_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void cboSeries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                String Serie = Convert.ToString(cboSeries.SelectedValue);
                ValoresPorDefecto(Serie);
            }
        }

        private void btAgregarNota_Click(object sender, EventArgs e)
        {
            frmTextoLargo oFrm = new frmTextoLargo();

            if (!String.IsNullOrEmpty(txtGlosa.Text))
            {
                oFrm.Texto = txtGlosa.Text;
            }

            if (oFrm.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(oFrm.Texto))
            {
                txtGlosa.Text = oFrm.Texto;
            }
        }

        private void btBuscarComprobante_Click(object sender, EventArgs e)
        {
            if (cboReferencia.SelectedValue.ToString() == "0") { Global.MensajeComunicacion("Seleccione Tipo Documento"); return; }

            frmBuscarDocumento oFrm = new frmBuscarDocumento(cboReferencia.SelectedValue.ToString(), dtpFecReferencia.Text);

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                foreach (EmisionDocumentoE item in oFrm.oListaDocumentos)
                {
                    txtSerieRef.Text = item.numSerie;
                    txtNumDocumentoRef.Text = item.numDocumento;
                }

                BuscarDocumento();
            }
        }

        private void btBuscarCondicion_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCondicionVentas oFrm = new frmBuscarCondicionVentas(EnumTipoCondicionVenta.NotaDebito);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCondicion != null)
                {
                    Int32 idCondicion = oFrm.oCondicion.idCondicion;

                    DocumentoEmitido.idTipCondicion = oFrm.oCondicion.idTipCondicion;
                    DocumentoEmitido.idCondicion = idCondicion;
                    txtIdCondicion.Text = idCondicion.ToString("00");
                    txtDesCondicion.Text = oFrm.oCondicion.desCondicion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //dtFecEmision_ValueChanged(null, null);
            dtpFecReferencia_ValueChanged(null, null);
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            CanalVenta = oFrm.oPersona.idCanalVenta;
                        }
                        else
                        {
                            dgvDetalle.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        CanalVenta = oListaPersonas[0].idCanalVenta;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        CanalVenta = Variables.Cero;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            CanalVenta = oFrm.oPersona.idCanalVenta;
                        }
                        else
                        {
                            dgvDetalle.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        CanalVenta = oListaPersonas[0].idCanalVenta;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        CanalVenta = Variables.Cero;
                        txtRazonSocial.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DocumentoEmitido.ListaItemsDocumento != null && DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                {
                    if (bsDetalleDocumento.Current != null)
                    {
                        EditarDetalle(e, (EmisionDocumentoDetE)bsDetalleDocumento.Current);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtNumDocumentoRef_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (bFlag)
                {
                    if (cboReferencia.SelectedValue.ToString() != "0" && !String.IsNullOrEmpty(txtSerieRef.Text.Trim()) && !String.IsNullOrEmpty(txtNumDocumentoRef.Text.Trim()))
                    {
                        BuscarDocumento();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboReferencia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (bFlag)
                {
                    if (cboReferencia.SelectedValue.ToString() != "0" && !String.IsNullOrEmpty(txtSerieRef.Text.Trim()) && !String.IsNullOrEmpty(txtNumDocumentoRef.Text.Trim()))
                    {
                        BuscarDocumento();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtSerieRef_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (bFlag)
                {
                    if (cboReferencia.SelectedValue.ToString() != "0" && !String.IsNullOrEmpty(txtSerieRef.Text.Trim()) && !String.IsNullOrEmpty(txtNumDocumentoRef.Text.Trim()))
                    {
                        BuscarDocumento();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtSerieRef_TextChanged(object sender, EventArgs e)
        {
            CambioRef = "S";
        }

        private void txtNumDocumentoRef_TextChanged(object sender, EventArgs e)
        {
            CambioRef = "S";
        }

        private void cboEstablecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (VariablesLocales.oVenParametros.indZona)
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

        private void btArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                List<EmisionDocumentoDetE> oListaTemp = null;

                if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                {
                    oListaTemp = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
                }

                frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value.Date, oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocEmision != null)
                {
                    Int32 Item = Variables.ValorUno;
                    EmisionDocumentoDetE ItemDetalle = oFrm.oDetalleDocEmision;

                    if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                    {
                        Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
                    }

                    ItemDetalle.Item = String.Format("{0:000}", Item);
                    ItemDetalle.codLineaVenta = String.Empty;
                    ItemDetalle.tipArticulo = "AR";
                    DocumentoEmitido.ListaItemsDocumento.Add(ItemDetalle);
                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);

                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                    bFlag = true;
                    Modificacion = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btServicios_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, 1, "S"); //S = Servicios

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocumento != null)
                {
                    Int32 Item = Variables.ValorUno;
                    EmisionDocumentoDetE ItemDetalle = oFrm.oDetalleDocumento;

                    if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                    {
                        Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
                    }

                    ItemDetalle.Item = String.Format("{0:000}", Item);
                    ItemDetalle.codLineaVenta = String.Empty;
                    ItemDetalle.tipArticulo = "SE";
                    DocumentoEmitido.ListaItemsDocumento.Add(ItemDetalle);
                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);

                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                    bFlag = true;
                    Modificacion = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsDetalleDocumento.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        //Int32 numItem = Variables.ValorUno;
                        EmisionDocumentoDetE oItem = (EmisionDocumentoDetE)bsDetalleDocumento.Current;

                        if (oItem.tipArticulo != "AA")
                        {
                            DocumentoEmitido.ListaItemsDocumento.RemoveAt(bsDetalleDocumento.Position);

                            //foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                            //{
                            //    item.Item = String.Format("{0:000}", numItem);
                            //    numItem++;

                            //    if (item.Total < 0)
                            //    {
                            //        MontoAnticipo = 0;
                            //    }
                            //}

                            bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                            bsDetalleDocumento.ResetBindings(false);
                            SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                            bFlag = true;
                            Modificacion = true;
                        }
                        else
                        {
                            Global.MensajeComunicacion("Este item tiene que eliminarse desde el botón Quitar Anticipo");
                        }
                    }
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
                    txtIdVendedor.Text = oFrm.oVendedor.idPersona.ToString();
                    txtVendedor.Text = oFrm.oVendedor.RazonSocial;
                    //cboEstablecimiento.Focus();

                    //cboDivision.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idDivision);
                    cboEstablecimiento.Focus();
                    cboEstablecimiento.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idEstablecimiento);

                    if (cboEstablecimiento.SelectedValue != null)
                    {
                        cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboZona.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idZona);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtRuc.Tag) != 0)
                {
                    frmBuscarPedido oFrm = new frmBuscarPedido(Convert.ToInt32(txtRuc.Tag));

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPedido != null)
                    {
                        txtNroAsociado.Tag = oFrm.oPedido.idPedido;
                        txtNroAsociado.Text = oFrm.oPedido.codPedidoCad;

                        if (DocumentoEmitido.indEstado == "E")
                        {
                            if (Global.MensajeConfirmacion("Desea actualizar el Nro. Pedido...???") == DialogResult.Yes)
                            {
                                Int32 resp = AgenteVentas.Proxy.ActualizarNroDocAsociado(DocumentoEmitido.idEmpresa, DocumentoEmitido.idLocal, DocumentoEmitido.idDocumento, DocumentoEmitido.numSerie, DocumentoEmitido.numDocumento, oFrm.oPedido.idPedido, VariablesLocales.SesionUsuario.Credencial, false, dtFecEmision.Value.Date);

                                if (resp > 0)
                                {
                                    Global.MensajeComunicacion("Pedido actualizado");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Global.MensajeAdvertencia("Debe ingresar un cliente antes de buscar los pedidos.");
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
