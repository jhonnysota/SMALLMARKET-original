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
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmSolicitudTrabajo : FrmMantenimientoBase
    {

        #region Constructores

        public frmSolicitudTrabajo()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvGuias, true);
            LlenarAyuda();
            AnchoColumnas();
        }

        public frmSolicitudTrabajo(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero, List<NumControlDetE> ListaDetalle)
            :this()
        {
            DocumentoEmitido = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);
            Boolean Entro = false;

            if (DocumentoEmitido.EnviadoSunat)
            {
                Global.MensajeFault("Este documento ha sido enviado a sunat, no puede hacer modificaciones.");
                dgvGuias.ClearSelection();
                BloquearPaneles(false);
                HabilitaBotones = false;
                Entro = true;
            }

            if (!Entro)
            {
                if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.E.ToString())
                {
                    Global.MensajeFault("Este documento ha sido Emitido, no puede hacer ninguna modificación.");
                    dgvGuias.ClearSelection();
                    BloquearPaneles(false);
                    HabilitaBotones = false;
                    Entro = true;
                }
            }

            if (!Entro)
            {
                if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.F.ToString())
                {
                    Global.MensajeFault("Esta guia ya ha sido facturada, no puede hacer ninguna modificación.");
                    dgvGuias.ClearSelection();
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
                    dgvGuias.ClearSelection();
                    BloquearPaneles(false);
                    HabilitaBotones = false;
                }
            }
        }

        public frmSolicitudTrabajo(List<NumControlDetE> ListaDetalle)
            :this()
        {
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);
        }

        #endregion Constructores

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        EmisionDocumentoE DocumentoEmitido = null;
        List<NumControlDetE> ListaDocumentosControl = null;
        ParTabla oTipoMedida = null;

        Int16 Opcion;
        Int32 idControlTmp = 0;
        Boolean HabilitaBotones = true;
        Decimal totdsc1 = 0;
        Decimal totdsc2 = 0;
        Decimal totdsc3 = 0;
        Int32? CanalVenta = Variables.Cero;
        Boolean indAlmacen = false;
        Boolean Bloqueo = true;
        Int32 idTipArticuloTmp = 0;

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
            var oListaDocumento = ListaDocumentosControl.GroupBy(x => x.idDocumento).Select(p => p.First()).ToList();

            //Llenando el tipo de documento
            ComboHelper.LlenarCombos<NumControlDetE>(cboTipoDocumento, oListaDocumento, "idDocumento", "desDocumento");

            //Llenando los documentos existentes...
            List<DocumentosE> oListaRef = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);//AgenteMaestro.Proxy.ListarDocumentos();
            oListaRef.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoRef, (from x in oListaRef orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);
            cboDocumentoRef.SelectedValue = Variables.Cero.ToString();

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Solo para el Fundo San Miguel
            {
                //Razón de exoneración del IGV
                List<ParTabla> oListaExoneracion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPAFEIGV");
                oListaExoneracion.Add(new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione });
            }
        }

        void LlenarAyuda()
        {
            Global.CrearToolTip(btNuevoCliente, "Agregar Nuevo Cliente.");
            Global.CrearToolTip(btBuscarVendedor, "Buscar vendedor.");
            Global.CrearToolTip(btBuscarTipoTraslado, "Buscar los motivos de traslado.");
            Global.CrearToolTip(btBuscarOtraDireccion, "Buscar otro almacén, otra sucursal o dirección.");
        }

        void AnchoColumnas()
        {
            dgvGuias.Columns[0].Width = 37; //Item
            dgvGuias.Columns[1].Width = 80; //Cod de Articulo
            dgvGuias.Columns[2].Width = 360; //Descripcion del Articulo
            dgvGuias.Columns[3].Width = 60; //Cantidad
            dgvGuias.Columns[4].Width = 60; //Peso
            dgvGuias.Columns[5].Width = 60; //Precio
            dgvGuias.Columns[6].Width = 70; //Subtotal
            dgvGuias.Columns[7].Width = 50; //Dscto 1
            dgvGuias.Columns[8].Width = 50; //Dscto 2
            dgvGuias.Columns[9].Width = 50; //Dscto 3
            dgvGuias.Columns[10].Width = 50; //Isc
            dgvGuias.Columns[11].Width = 50; //Igv
            dgvGuias.Columns[12].Width = 65; //Total
            dgvGuias.Columns[13].Width = 90; //Usuario Registro
            dgvGuias.Columns[14].Width = 130; //Fecha Registro
            dgvGuias.Columns[15].Width = 90; //Usuario Modificación
            dgvGuias.Columns[16].Width = 130; //Fecha Modificación
        }

        void ValoresPorDefecto(String Serie)
        {
            NumControlDetE Detalle = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                        VariablesLocales.SesionLocal.IdLocal, idControlTmp, cboTipoDocumento.SelectedValue.ToString(), Serie);

            if (Detalle != null)
            {
                cboMonedas.SelectedValue = Detalle.idMoneda;
                txtNumDocumento.MaxLength = Convert.ToInt32(Detalle.cantDigNumero);
                txtNumDocumento.Text = DevolverNumeroCorrelativo(Detalle.numCorrelativo, Convert.ToInt32(Detalle.cantDigNumero));
                txtIdTipoTraslado.Text = Detalle.idTipTraslado == 0 ? String.Empty : Convert.ToInt32(Detalle.idTipTraslado).ToString("00");
                txtDesTraslado.Text = Detalle.idTipTraslado == 0 ? String.Empty : Detalle.desTipoTraslado;
                txtPuntoLlegada.Text = Detalle.PuntoLlegada;
                cboEsGuia.SelectedValue = Detalle.EsGuia;

                if (Detalle.idTransporte != null && Detalle.idTransporte > 0)
                {
                    TransporteE trans = AgenteVentas.Proxy.ObtenerTransporte(Convert.ToInt32(Detalle.idTransporte));

                    if (trans != null)
                    {
                        txtIdTransportista.Text = Detalle.idTransporte.ToString();
                        txtRucTransporte.Text = trans.Ruc;
                        txtRazonSocialTransporte.Text = trans.RazonSocial;
                        txtDireccionTransporte.Text = trans.Direccion;
                    }
                }
                else
                {
                    txtIdTransportista.Text = String.Empty;
                    txtRucTransporte.Text = String.Empty;
                    txtRazonSocialTransporte.Text = String.Empty;
                    txtDireccionTransporte.Text = String.Empty;
                    DocumentoEmitido.idEmpresaTransp = Variables.Cero;
                }

                if (Detalle.idCondicion != null && Detalle.idCondicion > Variables.Cero)
                {
                    txtIdCondicion.Text = Convert.ToInt32(Detalle.idCondicion).ToString();
                    CondicionE tmpCondicion = AgenteVentas.Proxy.ObtenerCondicion((Int32)EnumTipoCondicionVenta.FacBol, Convert.ToInt32(Detalle.idCondicion));
                    txtDesCondicion.Text = tmpCondicion.desCondicion;
                }
            }
        }

        void DatosGrabacion()
        {
            DocumentoEmitido.idDocumento = cboTipoDocumento.SelectedValue.ToString();
            DocumentoEmitido.numSerie = cboSeries.SelectedValue.ToString();
            DocumentoEmitido.numDocumento = txtNumDocumento.Text;
            DocumentoEmitido.TipoAsiento = "";
            DocumentoEmitido.fecEmision = dtFecEmision.Value.ToString("yyyyMMdd");
            DocumentoEmitido.Anio = dtFecEmision.Value.ToString("yyyy");
            DocumentoEmitido.Mes = dtFecEmision.Value.ToString("MM");
            DocumentoEmitido.fecVencimiento = null;
            DocumentoEmitido.indEstado = EnumEstadoDocumentos.C.ToString();
            DocumentoEmitido.EsGuia = cboEsGuia.SelectedValue.ToString();

            DocumentoEmitido.idTipCondicion = (Int32)EnumTipoCondicionVenta.FacBol;
            DocumentoEmitido.idCondicion = Convert.ToInt32(txtIdCondicion.Text);

            DocumentoEmitido.idVendedor = String.IsNullOrEmpty(txtIdVendedor.Text.Trim()) ? 0 : Convert.ToInt32(txtIdVendedor.Text);
            DocumentoEmitido.AfectoDetraccion = false;
            DocumentoEmitido.Glosa = txtGlosa.Text;

            //Recepción Documento
            DocumentoEmitido.indRecepcion = false;
            DocumentoEmitido.fecRecepcion = (Nullable<DateTime>)null;

            //Tipo Condición
            if (String.IsNullOrEmpty(txtIdCondicion.Text.Trim()))
            {
                DocumentoEmitido.idTipCondicion = (Nullable<int>)null;
                DocumentoEmitido.idCondicion = (Nullable<int>)null;
            }
            else
            {
                DocumentoEmitido.idTipCondicion = (Int32)EnumTipoCondicionVenta.FacBol;
                DocumentoEmitido.idCondicion = Convert.ToInt32(txtIdCondicion.Text);
            }

            //Montos - Moneda
            DocumentoEmitido.idMoneda = cboMonedas.SelectedValue.ToString();
            DocumentoEmitido.tipCambio = Convert.ToDecimal(txtTica.Text);
            DocumentoEmitido.totMontoBruto = Variables.ValorCeroDecimal;
            DocumentoEmitido.totsubTotal = Convert.ToDecimal(lblSubTotal.Text);
            DocumentoEmitido.totDscto1 = totdsc1;
            DocumentoEmitido.totDscto2 = totdsc2;
            DocumentoEmitido.totDscto3 = totdsc3;
            DocumentoEmitido.totIsc = Convert.ToDecimal(lblIsc.Text);
            DocumentoEmitido.totIgv = Convert.ToDecimal(lblIgv.Text);
            DocumentoEmitido.totTotal = Convert.ToDecimal(lblTotal.Text);

            //Otros Campos que no son necesarios para la guia
            DocumentoEmitido.idTipTransporte = String.Empty;
            DocumentoEmitido.NombrePuerto = String.Empty;
            DocumentoEmitido.numReserva = String.Empty;
            DocumentoEmitido.numPartida = String.Empty;
            DocumentoEmitido.Invoice = String.Empty;
            DocumentoEmitido.Periodo = String.Empty;
            DocumentoEmitido.PO = String.Empty;
            DocumentoEmitido.totAfectoPerce = Variables.ValorCeroDecimal;
            DocumentoEmitido.totPercepcion = Variables.ValorCeroDecimal;

            //Datos Clientes
            DocumentoEmitido.idPersona = String.IsNullOrEmpty(txtIdCliente.Text.Trim()) ? (Nullable<Int32>)null : Convert.ToInt32(txtIdCliente.Text);
            DocumentoEmitido.numRuc = txtRuc.Text;
            DocumentoEmitido.RazonSocial = Global.DejarSoloUnEspacio(txtRazonSocial.Text.Trim().Replace(@"\r\n", "").Replace(@"\n", "").Replace(@"\r", "").Replace(Environment.NewLine, ""));
            DocumentoEmitido.Direccion = Global.DejarSoloUnEspacio(txtDireccion.Text.Trim().Replace(@"\r\n", "").Replace(@"\n", "").Replace(@"\r", "").Replace(Environment.NewLine, ""));
            DocumentoEmitido.idCanalVenta = CanalVenta;

            //Indicador si tiene voucher
            DocumentoEmitido.indVoucher = false;

            //Datos de traslado
            DocumentoEmitido.idTipTraslado = Convert.ToInt32(txtIdTipoTraslado.Text);
            DocumentoEmitido.OtroTipoTraslado = txtOtroTipoTraslado.Text;

            DocumentoEmitido.fecTraslado = dtFecTraslado.Value.Date;
            DocumentoEmitido.EmpresaPartida = txtEmpresaPartida.Text;
            DocumentoEmitido.PuntoPartida = txtPuntoPartida.Text;
            DocumentoEmitido.PuntoLlegada = txtPuntoLlegada.Text;

            //Motivo de Traslados - Transferencias...
            if (DocumentoEmitido.idTipTraslado == 6 || DocumentoEmitido.idTipTraslado == 7)
            {
                DocumentoEmitido.idAlmacenDestino = String.IsNullOrEmpty(txtIdSucursal.Text) ? 0 : Convert.ToInt32(txtIdSucursal.Text.Trim());
                DocumentoEmitido.idSucursalCliente = Variables.Cero;
            }
            else //el resto de tipos de transferencias
            {
                DocumentoEmitido.idSucursalCliente = String.IsNullOrEmpty(txtIdSucursal.Text) ? 0 : Convert.ToInt32(txtIdSucursal.Text.Trim());
                DocumentoEmitido.idAlmacenDestino = Variables.Cero;
            }

            //Documento de referencia
            DocumentoEmitido.idDocumentoRef = cboDocumentoRef.SelectedValue.ToString() == "0" ? string.Empty : cboDocumentoRef.SelectedValue.ToString();
            DocumentoEmitido.serDocumentoRef = txtIdOt.Text.Trim();
            DocumentoEmitido.numDocumentoRef = txtNumOt.Text.Trim();
            DocumentoEmitido.fecDocumentoRef = (DateTime?)null;

            //Datos del Transportista
            DocumentoEmitido.idEmpresaTransp = String.IsNullOrEmpty(txtIdTransportista.Text.Trim()) ? 0 : Convert.ToInt32(txtIdTransportista.Text.Trim());
            DocumentoEmitido.RazonSocialTransp = txtRazonSocialTransporte.Text;
            DocumentoEmitido.RucTransp = txtRucTransporte.Text;
            DocumentoEmitido.DireccionTransp = txtDireccionTransporte.Text;
            DocumentoEmitido.idConductorTransp = String.IsNullOrEmpty(txtIdConductor.Text.Trim()) ? 0 : Convert.ToInt32(txtIdConductor.Text.Trim());
            DocumentoEmitido.ConductorTransp = txtNombreConductor.Text;
            DocumentoEmitido.LicenciaTransp = txtLicencia.Text;
            DocumentoEmitido.desVehiculoTransp = txtDesVehiculo.Text;
            DocumentoEmitido.PlacaTransp = txtPlaca.Text;
            DocumentoEmitido.MarcaTransp = txtMarca.Text;
            DocumentoEmitido.inscripTransp = txtInscripcion.Text;
            DocumentoEmitido.PlacaRemolqueTransp = txtPlacaRemolque.Text;
            DocumentoEmitido.tipAfectoIgv = Variables.Cero;

            //Dscto Global
            if (chkPorcentaje.Checked)
            {
                DocumentoEmitido.porDscto = Convert.ToDecimal(lblPorcentaje.Text);
                DocumentoEmitido.DsctoGlobal = Convert.ToDecimal(lblDsctoGlobal.Text);
            }
            else
            {
                DocumentoEmitido.porDscto = Variables.Cero;
                DocumentoEmitido.DsctoGlobal = Variables.Cero;
            }

            DocumentoEmitido.EsAnticipo = false;
            DocumentoEmitido.indAnticipo = false;

            if (Opcion == (Int16)EnumOpcionGrabar.Insertar)
            {
                DocumentoEmitido.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                DocumentoEmitido.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlComprobante.Enabled = Flag;
            pnlCliente.Enabled = Flag;
            pnlTraslado.Enabled = Flag;
            pnlTransportista.Enabled = Flag;
            pnlConductor.Enabled = Flag;
            txtGlosa.Enabled = Flag;
            btAgregarNota.Enabled = Flag;
            btOrdenProduccion.Enabled = Flag;
            Bloqueo = Flag;
        }

        void BloquearPanelComprobante(Boolean Flag)
        {
            //cboTipoDocumento.Enabled = Flag;
            //cboEsGuia.Enabled = Flag;
            cboSeries.Enabled = Flag;
            txtNumDocumento.Enabled = Flag;
        }

        void SumarTotal(List<EmisionDocumentoDetE> oListaDetalle)
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
                Decimal monDscto = Variables.ValorCeroDecimal;

                if (chkPorcentaje.Checked)
                {
                    Decimal? porIgv = oListaDetalle[0].porIgv;
                    Decimal.TryParse(lblDsctoGlobal.Text, out monDscto);
                    SubTotal -= monDscto;

                    if (Igv > Variables.Cero)
                    {
                        ValorGravado -= monDscto;
                        Igv = SubTotal * (Convert.ToDecimal(porIgv) / 100);
                    }
                    else
                    {
                        ValorNoGravado -= monDscto;
                    }

                    Total = SubTotal + Igv;
                }

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
            //List<EmisionDocumentoDetE> oListaTemp = null;

            //if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
            //{
            //    oListaTemp = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
            //}

            //frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value.Date, oItem, oListaTemp, Bloqueo, idAlmacenTmp);
            //String sItem = oItem.Item;

            //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocEmision != null)
            //{
            //    EmisionDocumentoDetE ItemDet = oFrm.oDetalleDocEmision;
            //    DocumentoEmitido.ListaItemsDocumento[e.RowIndex] = ItemDet;
            //    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
            //    bsDetalleDocumento.ResetBindings(false);

            //    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
            //}

            try
            {
                if (RevisarAlmacen())
                {
                    oItem.idTipoArticulo = idTipArticuloTmp;
                    frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, oItem, "S", "S"); //Servicio
                    String sItem = oItem.Item;
                    Int32 Ot = Convert.ToInt32(oItem.nroOt); Int32 OtItem = Convert.ToInt32(oItem.nroOtItem);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocumento != null)
                    {
                        EmisionDocumentoDetE ItemDet = oFrm.oDetalleDocumento;
                        ItemDet.Item = sItem;
                        ItemDet.tipArticulo = "SE";
                        ItemDet.idUnidadMedida = 59;
                        ItemDet.nroOt = Ot;
                        ItemDet.nroOtItem = OtItem;
                        ItemDet.Lote = "0000000";

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
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        void ValidarAuxiliar(List<Persona> oListaPersonasTmp)
        {
            if (!oListaPersonasTmp[0].Cli)
            {
                if (Global.MensajeConfirmacion("Este auxiliar no esta ingresado como Cliente. Desea agregarlo ?") == DialogResult.Yes)
                {
                    //Int32 CanalVenta = Variables.Cero; // 0 = Nacional 1 = Exportación

                    //if (oListaPersonasTmp[0].NemoTipPer == enumTipoAuxiliar.OTR.ToString())
                    //{
                    //    CanalVenta = 1;
                    //}

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
                        //idCanalVenta = CanalVenta,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestro.Proxy.InsertarCliente(oCliente);
                }
            }
        }

        Boolean RevisarAlmacen()
        {
            ParTabla oTipoAlmacen = AgenteGeneral.Proxy.ParTablaPorNemo("O10");

            if (oTipoAlmacen != null)
            {
                //List<AlmacenE> oListaAlmacenes = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, oTipoAlmacen.IdParTabla);

                //if (oListaAlmacenes.Count == 0)
                //{
                //    Global.MensajeComunicacion("No se ha creado en Parámetros Generales almacenes de servicio.");
                //    return false;
                //}
                //else
                //{
                //    AlmacenE oAlmacen = (from x in oListaAlmacenes
                //                         where x.desAlmacen.ToUpper().Contains("SERVICIO")
                //                         select x).FirstOrDefault();

                //    if (oAlmacen == null)
                //    {
                //        Global.MensajeComunicacion("No existe ningún Almacén de Servicios.");
                //        return false;
                //    }
                //    else
                //    {
                //        idAlmacenTmp = oAlmacen.idAlmacen;
                //    }
                //}
                idTipArticuloTmp = oTipoAlmacen.IdParTabla;
            }

            return true;
        }

        #endregion Procedimientos de Usuario

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            if (DocumentoEmitido == null)
            {
                Opcion = (Int16)EnumOpcionGrabar.Insertar;

                DocumentoEmitido = new EmisionDocumentoE();

                DocumentoEmitido.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                DocumentoEmitido.idLocal = VariablesLocales.SesionLocal.IdLocal;
                cboTipoDocumento.SelectedValue = "ST";

                BloquearPanelComprobante(true);
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                dtFecEmision_ValueChanged(null, null);
                txtEmpresaPartida.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                txtPuntoPartida.Text = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                Text = "Solicitud de Factura (Nuevo)";
            }
            else
            {
                Opcion = Convert.ToInt16(EnumOpcionGrabar.Actualizar);
                dtFecEmision.ValueChanged -= new EventHandler(dtFecEmision_ValueChanged);
                txtIdCliente.TextChanged -= txtIdCliente_TextChanged;
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                txtRucTransporte.TextChanged -= txtRucTransporte_TextChanged;
                txtRazonSocialTransporte.TextChanged -= txtRazonSocialTransporte_TextChanged;
                txtVendedor.TextChanged -= txtVendedor_TextChanged;

                cboTipoDocumento.SelectedValue = DocumentoEmitido.idDocumento;
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                cboSeries.SelectedValue = DocumentoEmitido.numSerie.ToString();
                txtNumDocumento.Text = DocumentoEmitido.numDocumento;
                BloquearPanelComprobante(false);
                dtFecEmision.Value = Convert.ToDateTime(DocumentoEmitido.fecEmision);
                cboEsGuia.SelectedValue = DocumentoEmitido.EsGuia;
                cboMonedas.SelectedValue = DocumentoEmitido.idMoneda;
                txtTica.Text = DocumentoEmitido.tipCambio.ToString();
                txtIdCondicion.Text = Convert.ToInt32(DocumentoEmitido.idCondicion).ToString();
                txtDesCondicion.Text = DocumentoEmitido.desCondicion;
                txtIdCliente.Text = DocumentoEmitido.idPersona == 0 ? String.Empty : DocumentoEmitido.idPersona.ToString();
                txtRuc.Text = DocumentoEmitido.numRuc;
                txtRazonSocial.Text = DocumentoEmitido.RazonSocial;
                txtDireccion.Text = DocumentoEmitido.Direccion;
                txtIdVendedor.Text = DocumentoEmitido.idVendedor == 0 ? String.Empty : DocumentoEmitido.idVendedor.ToString();
                txtVendedor.Text = DocumentoEmitido.Vendedor;

                //Documento de referencia
                if (!string.IsNullOrEmpty(DocumentoEmitido.idDocumentoRef.Trim()))
                {
                    cboDocumentoRef.SelectedValue = DocumentoEmitido.idDocumentoRef.ToString();
                    txtIdOt.Text = DocumentoEmitido.serDocumentoRef;
                    txtNumOt.Text = DocumentoEmitido.numDocumentoRef;
                }

                //Motivo de Traslado
                txtIdTipoTraslado.Text = DocumentoEmitido.idTipTraslado == 0 ? String.Empty : Convert.ToInt32(DocumentoEmitido.idTipTraslado).ToString("00");
                txtDesTraslado.Text = DocumentoEmitido.desTraslado;
                txtOtroTipoTraslado.Text = DocumentoEmitido.OtroTipoTraslado;

                //Tipo de Traslados - Transferencias...
                if (DocumentoEmitido.idTipTraslado == 6 || DocumentoEmitido.idTipTraslado == 7)
                {
                    txtIdSucursal.Text = DocumentoEmitido.idSucursalCliente == 0 ? String.Empty : DocumentoEmitido.idSucursalCliente.ToString();
                }
                else //el resto de tipos de transferencias
                {
                    txtIdSucursal.Text = DocumentoEmitido.idAlmacenDestino == 0 ? String.Empty : DocumentoEmitido.idAlmacenDestino.ToString();
                }

                dtFecTraslado.Value = Convert.ToDateTime(DocumentoEmitido.fecTraslado);
                txtEmpresaPartida.Text = String.IsNullOrEmpty(DocumentoEmitido.EmpresaPartida) ? VariablesLocales.SesionUsuario.Empresa.RazonSocial : DocumentoEmitido.EmpresaPartida;
                txtPuntoPartida.Text = DocumentoEmitido.PuntoPartida;
                txtPuntoLlegada.Text = DocumentoEmitido.PuntoLlegada;

                //Transportista
                txtIdTransportista.Text = DocumentoEmitido.idEmpresaTransp == 0 ? String.Empty : DocumentoEmitido.idEmpresaTransp.ToString();
                txtRucTransporte.Text = DocumentoEmitido.RucTransp;
                txtRazonSocialTransporte.Text = DocumentoEmitido.RazonSocialTransp;
                txtDireccionTransporte.Text = DocumentoEmitido.DireccionTransp;

                //Conductor
                txtIdConductor.Text = DocumentoEmitido.idConductorTransp.ToString();
                txtNombreConductor.Text = DocumentoEmitido.ConductorTransp;
                txtLicencia.Text = DocumentoEmitido.LicenciaTransp;
                txtDesVehiculo.Text = DocumentoEmitido.desVehiculoTransp;
                txtPlaca.Text = DocumentoEmitido.PlacaTransp;
                txtInscripcion.Text = DocumentoEmitido.inscripTransp;
                txtMarca.Text = DocumentoEmitido.MarcaTransp;
                txtPlacaRemolque.Text = DocumentoEmitido.PlacaRemolqueTransp;
                txtGlosa.Text = DocumentoEmitido.Glosa;

                CanalVenta = DocumentoEmitido.idCanalVenta;
                SumarTotal(DocumentoEmitido.ListaItemsDocumento);

                Text = "Solicitud de Factura (" + DocumentoEmitido.numSerie + "-" + DocumentoEmitido.numDocumento + ")";

                dtFecEmision.ValueChanged += new EventHandler(dtFecEmision_ValueChanged);
                txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                txtRucTransporte.TextChanged += txtRucTransporte_TextChanged;
                txtRazonSocialTransporte.TextChanged += txtRazonSocialTransporte_TextChanged;
                txtVendedor.TextChanged += txtVendedor_TextChanged;
            }

            bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
            bsDetalleDocumento.ResetBindings(false);

            cboDocumentoRef_SelectionChangeCommitted(new object(), new EventArgs());

            if (HabilitaBotones)
            {
                base.Nuevo();
            }
            else
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
        }

        public override void Grabar()
        {
            try
            {
                dgvGuias.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            if (RevisarAlmacen())
            {
                try
                {
                    frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, 1, "S", "S"); //S = Servicios

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
                        base.AgregarDetalle();
                    }
                }
                catch (Exception ex)
                {
                    Global.MensajeFault(ex.Message);
                }
                //List<EmisionDocumentoDetE> oListaTemp = null;

                //if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                //{
                //    oListaTemp = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
                //}

                //frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value.Date, oListaTemp, idAlmacenTmp);

                //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocEmision != null)
                //{
                //    Int32 Item = Variables.ValorUno;
                //    EmisionDocumentoDetE ItemDetalle = oFrm.oDetalleDocEmision;

                //    if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                //    {
                //        Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
                //    }

                //    ItemDetalle.Item = String.Format("{0:000}", Item);
                //    ItemDetalle.codLineaVenta = String.Empty;
                //    ItemDetalle.tipArticulo = "SE";
                //    DocumentoEmitido.ListaItemsDocumento.Add(ItemDetalle);
                //    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                //    bsDetalleDocumento.ResetBindings(false);

                //    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                //} 
            }
        }

        public override void QuitarDetalle()
        {
            if (bsDetalleDocumento.Current != null)
            {
                if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                {
                    base.QuitarDetalle();
                    Int32 numItem = Variables.ValorUno;

                    DocumentoEmitido.ListaItemsDocumento.RemoveAt(bsDetalleDocumento.Position);
                    List<EmisionDocumentoDetE> ListaAuxiliar = new List<EmisionDocumentoDetE>();

                    foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                    {
                        item.Item = String.Format("{0:000}", numItem);
                        numItem++;
                    }

                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);
                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                }
            }
        }

        public override Boolean ValidarGrabacion()
        {
            if (String.IsNullOrEmpty(DocumentoEmitido.numRuc))
            {
                MessageBox.Show("Ingrese Información del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtTica.Text == "0.000")
            {
                MessageBox.Show("Debe ingresar el tipo de cambio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimiento Heredados

        #region Eventos

        private void frmSolicitudTrabajo_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            Nuevo();

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvGuias.Columns["nroOt"].Visible = false;
                dgvGuias.Columns["nroOtItem"].Visible = false;
            }
        }

        private void dtFecEmision_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = dtFecEmision.Value.Date;
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMonedas.SelectedValue.ToString(), Fecha);

                if (Tica != null)
                {
                    txtTica.Text = Tica.valVenta.ToString("N3");
                }
                else
                {
                    txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtFecEmision.Focus();
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
                                                                         && x.idDocumento == cboTipoDocumento.SelectedValue.ToString()
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
                cboEsGuia_SelectionChangeCommitted(new Object(), new EventArgs());
            }
        }

        private void cboEsGuia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cboEsGuia.SelectedValue.ToString() == EnumEsGuia.E.ToString())
            //{
            //    cboExoneracion.SelectedValue = 307016;
            //    cboExoneracion.Enabled = false;
            //}
            //else if (cboEsGuia.SelectedValue.ToString() == EnumEsGuia.F.ToString())
            //{
            //    cboExoneracion.SelectedValue = 307001;
            //    cboExoneracion.Enabled = true;
            //}
            //else
            //{
            //    cboExoneracion.SelectedValue = 307001;
            //    cboExoneracion.Enabled = true;
            //}
        }

        private void cboDocumentoRef_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumentoRef.SelectedValue.ToString() != Variables.Cero.ToString())
                {
                    txtIdOt.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNumOt.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    //dtpFecReferencia.Enabled = true;
                    txtIdOt.Focus();
                }
                else
                {
                    txtIdOt.Text = String.Empty;
                    txtNumOt.Text = String.Empty;
                    txtIdOt.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNumOt.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    //dtpFecReferencia.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdCliente.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtIdCliente.TextChanged -= txtIdCliente_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdCliente.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            txtPuntoLlegada.Text = oFrm.oPersona.DireccionCompleta;
                            txtCanalVenta.Text = oFrm.oPersona.idCanalVenta.ToString();
                        }
                        else
                        {
                            txtRuc.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        txtPuntoLlegada.Text = oListaPersonas[0].DireccionCompleta;
                        txtCanalVenta.Text = oListaPersonas[0].idCanalVenta.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("El ID del Auxiliar ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtPuntoLlegada.Text = String.Empty;
                        txtCanalVenta.Text = String.Empty;
                        txtIdCliente.Focus();
                    }

                    txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtIdCliente.Text.Trim()))
                {
                    txtIdCliente.TextChanged -= txtIdCliente_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            txtPuntoLlegada.Text = oFrm.oPersona.DireccionCompleta;
                            txtCanalVenta.Text = oFrm.oPersona.idCanalVenta.ToString();
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        txtPuntoLlegada.Text = oListaPersonas[0].DireccionCompleta;
                        txtCanalVenta.Text = oListaPersonas[0].idCanalVenta.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtPuntoLlegada.Text = String.Empty;
                        txtCanalVenta.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
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
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtIdCliente.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtIdCliente.TextChanged -= txtIdCliente_TextChanged;
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            txtPuntoLlegada.Text = oFrm.oPersona.DireccionCompleta;
                            txtCanalVenta.Text = oFrm.oPersona.idCanalVenta.ToString();
                        }
                        else
                        {
                            dgvGuias.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        txtPuntoLlegada.Text = oListaPersonas[0].DireccionCompleta;
                        txtCanalVenta.Text = oListaPersonas[0].idCanalVenta.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtPuntoLlegada.Text = String.Empty;
                        txtCanalVenta.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }

                    txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvGuias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btBuscarTipoTraslado_Click(object sender, EventArgs e)
        {
            frmBuscarTipoCondicionTraslado oFrm = new frmBuscarTipoCondicionTraslado();

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                txtIdTipoTraslado.Text = oFrm.oTraslado.idTraslado.ToString();
                txtDesTraslado.Text = oFrm.oTraslado.desTraslado;
                indAlmacen = oFrm.oTraslado.indAlmacen;

                if (txtIdTipoTraslado.Text == "14")
                {
                    txtOtroTipoTraslado.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                    txtOtroTipoTraslado.Focus();
                }
                else
                {
                    txtOtroTipoTraslado.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");

                    if (txtIdTipoTraslado.Text == "6" || txtIdTipoTraslado.Text == "7")
                    {
                        lblAlmacen.Text = "Almacen";
                    }
                    else
                    {
                        lblAlmacen.Text = "Llegada";
                    }
                }
            }
        }

        private void txtOtroTipoTraslado_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdTipoTraslado.Text == "14")
            {
                if (String.IsNullOrEmpty(txtOtroTipoTraslado.Text.Trim()))
                {
                    Global.MensajeFault("Es obligatorio colocar la descripción de Otro Tipo de Traslado.");
                    txtOtroTipoTraslado.Focus();
                    return;
                }
            }
        }

        private void txtIdTipoTraslado_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdTipoTraslado.Text.Trim()))
            {
                txtDesTraslado.Text = String.Empty;
                txtOtroTipoTraslado.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                lblAlmacen.Text = "Llegada";
            }
        }

        private void btBuscarOtraDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtIdTipoTraslado.Text == "6" || txtIdTipoTraslado.Text == "7") && indAlmacen)
                {
                    frmBuscarAlmacenes oFrm = new frmBuscarAlmacenes();

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oAlmacen != null)
                    {
                        txtIdSucursal.Text = oFrm.oAlmacen.idAlmacen.ToString();
                        txtPuntoLlegada.Text = oFrm.oAlmacen.Direccion;
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(txtIdCliente.Text.Trim()))
                    {
                        Global.MensajeFault("Debe escoger primero al cliente.");
                        return;
                    }

                    List<PersonaDireccionE> oListaDirecciones = AgenteMaestro.Proxy.ListarPersonaDireccion(Convert.ToInt32(txtIdCliente.Text.Trim()));

                    if (oListaDirecciones.Count <= Variables.Cero)
                    {
                        Global.MensajeFault("Este cliente no cuenta con otras sucursales.");
                        return;
                    }

                    frmBuscarSucursalCliente oFrm = new frmBuscarSucursalCliente(oListaDirecciones);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDireccion != null)
                    {
                        txtIdSucursal.Text = oFrm.oDireccion.IdDireccion.ToString();
                        txtPuntoLlegada.Text = oFrm.oDireccion.DireccionCompleta;
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
                    txtVendedor.TextChanged -= txtVendedor_TextChanged;
                    txtIdVendedor.Text = oFrm.oVendedor.idPersona.ToString();
                    txtVendedor.Text = oFrm.oVendedor.RazonSocial;
                    txtVendedor.TextChanged += txtVendedor_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarTransporte_Click(object sender, EventArgs e)
        {
            frmBuscarTransporte oFrm = new frmBuscarTransporte();

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                txtRucTransporte.TextChanged -= txtRucTransporte_TextChanged;
                txtRazonSocialTransporte.TextChanged -= txtRazonSocialTransporte_TextChanged;

                txtIdTransportista.Text = oFrm.oTransporte.idTransporte.ToString();
                txtRucTransporte.Text = oFrm.oTransporte.Ruc;
                txtRazonSocialTransporte.Text = oFrm.oTransporte.RazonSocial;
                txtDireccionTransporte.Text = oFrm.oTransporte.Direccion;

                txtRucTransporte.TextChanged += txtRucTransporte_TextChanged;
                txtRazonSocialTransporte.TextChanged += txtRazonSocialTransporte_TextChanged;
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = String.Empty;
            txtRuc.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
            txtRuc.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
            txtIdCliente.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void txtRucTransporte_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRucTransporte.Text.Trim()))
            {
                txtRazonSocialTransporte.Text = String.Empty;
                txtDireccionTransporte.Text = String.Empty;
            }
        }

        private void txtRazonSocialTransporte_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonSocialTransporte.Text.Trim()))
            {
                txtRucTransporte.Text = String.Empty;
                txtDireccionTransporte.Text = String.Empty;
            }
        }

        private void btBuscarConductor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdTransportista.Text.Trim()))
            {
                Global.MensajeFault("Tiene que escoger una empresa de transporte.");
                btBuscarTransporte.Focus();
                return;
            }

            frmBuscarConductor oFrm = new frmBuscarConductor(Convert.ToInt32(txtIdTransportista.Text.Trim()));

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                txtIdConductor.Text = oFrm.oConductores.idConductor.ToString();
                txtNombreConductor.Text = oFrm.oConductores.Nombres;
                txtLicencia.Text = oFrm.oConductores.Licencia;
            }
        }

        private void btBuscarVehiculo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdTransportista.Text.Trim()))
            {
                Global.MensajeFault("Tiene que escoger una empresa de transporte.");
                btBuscarTransporte.Focus();
                return;
            }

            frmBuscarVehiculoTransporte oFrm = new frmBuscarVehiculoTransporte(Convert.ToInt32(txtIdTransportista.Text.Trim()));

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                txtDesVehiculo.Text = oFrm.oVehiculo.desVehicular;
                txtPlaca.Text = oFrm.oVehiculo.numPlaca;
                txtInscripcion.Text = oFrm.oVehiculo.numInscripcion;
                txtMarca.Text = oFrm.oVehiculo.Marca;
            }
        }

        private void chkPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoEmitido.ListaItemsDocumento.Count <= Variables.Cero)
                {
                    Global.MensajeFault("Tiene que tener al menos una linea para poder aplicar Dscto Global.");
                    chkPorcentaje.Checked = false;
                    return;
                }

                if (chkPorcentaje.Checked)
                {
                    frmCambioPrecio oFrm = new frmCambioPrecio(lblTotal.Text, lblPorcentaje.Text, lblDsctoGlobal.Text);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        Decimal MontoFinal = oFrm.Monto;
                        Decimal Porcentaje = oFrm.Porcentaje;

                        lblDsctoGlobal.Text = MontoFinal.ToString("N2");
                        lblPorcentaje.Text = Porcentaje.ToString("N2");
                    }
                    else
                    {
                        chkPorcentaje.Checked = false;
                        lblDsctoGlobal.Text = "0.00";
                        lblPorcentaje.Text = "0.00";
                    }
                }
                else
                {
                    chkPorcentaje.Checked = false;
                    lblDsctoGlobal.Text = "0.00";
                    lblPorcentaje.Text = "0.00";
                }

                SumarTotal(DocumentoEmitido.ListaItemsDocumento);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtVendedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtVendedor.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.BusquedaPersonaPorTipo("VE", VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtVendedor.Text.Trim(), "");

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Vendedor");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdVendedor.Text = oFrm.oPersona.IdPersona.ToString();
                            txtVendedor.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtIdTipoTraslado.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdVendedor.Text = oListaPersonas[0].IdPersona.ToString();
                        txtVendedor.Text = oListaPersonas[0].RazonSocial;

                        txtIdTipoTraslado.Focus();
                    }
                    else
                    {
                        Global.MensajeFault("El nombre ingresado no existe.");
                        txtIdVendedor.Text = String.Empty;
                        txtVendedor.Text = String.Empty;
                        txtVendedor.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBuscarCondicion_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCondicionVentas oFrm = new frmBuscarCondicionVentas(EnumTipoCondicionVenta.FacBol);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCondicion != null)
                {
                    Int32 idCondicion = oFrm.oCondicion.idCondicion;
                    
                    txtIdCondicion.Text = idCondicion.ToString("00");
                    txtDesCondicion.Text = oFrm.oCondicion.desCondicion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtVendedor_TextChanged(object sender, EventArgs e)
        {
            txtIdVendedor.Text = string.Empty;
        }

        private void btOrdenTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                if (RevisarAlmacen())
                {
                    if (txtRuc.Text == "")
                    {
                        frmBuscarOtServicios oFrm = new frmBuscarOtServicios();

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTrabajoServicio != null)
                        {
                            txtIdCliente.TextChanged -= txtIdCliente_TextChanged;
                            txtRuc.TextChanged -= txtRuc_TextChanged;
                            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                            //cboDocumentoRef.SelectedValue = "OT";
                            //txtIdOt.Text = oFrm.oTrabajoServicio.idOT.ToString();
                            //txtNumOt.Text = oFrm.oTrabajoServicio.numeroOT;
                            txtIdCliente.Text = oFrm.oTrabajoServicio.idPersona.ToString();
                            txtRuc.Text = oFrm.oTrabajoServicio.RUC;
                            txtRazonSocial.Text = oFrm.oTrabajoServicio.RazonSocial;
                            txtDireccion.Text = oFrm.oTrabajoServicio.Direccion;

                            txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                            txtRuc.TextChanged += txtRuc_TextChanged;
                            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                            List<OrdenTrabajoServicioItemE> oLista = AgenteVentas.Proxy.ListarOrdenTrabajoServicioItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                        VariablesLocales.SesionLocal.IdLocal,
                                                                                                                        oFrm.oTrabajoServicio.idOT);
                            if (oLista.Count > 0)
                            {
                                EmisionDocumentoDetE oDetalle = null;
                                Int32 Item = Variables.ValorUno;
                                Decimal PrecioConImpuesto = 0;
                                Decimal Igv = VariablesLocales.oListaImpuestos[0].Porcentaje;
                                oTipoMedida = AgenteGeneral.Proxy.ParTablaPorNemo("UNI");
                                Int32 idTipoMedidaTmp = 0;

                                if (oTipoMedida != null)
                                {
                                    idTipoMedidaTmp = oTipoMedida.IdParTabla;
                                }

                                if (DocumentoEmitido.ListaItemsDocumento != null && DocumentoEmitido.ListaItemsDocumento.Count() > 0)
                                {
                                    Item = DocumentoEmitido.ListaItemsDocumento.Count() + 1;
                                }
                                else
                                {
                                    Item = Variables.ValorUno;
                                }

                                foreach (OrdenTrabajoServicioItemE item in oLista)
                                {
                                    PrecioConImpuesto = (item.PrecioUnitario * Igv) + item.PrecioUnitario;

                                    oDetalle = new EmisionDocumentoDetE()
                                    {
                                        idEmpresa = item.idEmpresa,
                                        idLocal = item.idLocal,
                                        idDocumento = cboTipoDocumento.SelectedValue.ToString(),
                                        numSerie = cboSeries.SelectedValue.ToString(),
                                        numDocumento = txtNumDocumento.Text,
                                        Item = String.Format("{0:000}", Item),
                                        idAlmacen = 0,
                                        idArticulo = item.idArticulo,
                                        codArticulo = item.codArticulo,
                                        nomArticulo = item.Descripcion,
                                        Lote = "0000000",
                                        Cantidad = item.Cantidad,
                                        CantidadFinal = item.Cantidad,
                                        PrecioConImpuesto = PrecioConImpuesto,
                                        PrecioSinImpuesto = item.PrecioUnitario,
                                        Dscto1 = 0,
                                        Dscto2 = 0,
                                        Dscto3 = 0,
                                        porDscto1 = 0,
                                        porDscto2 = 0,
                                        porDscto3 = 0,
                                        flgIgv = item.flgIgv,
                                        Isc = 0,
                                        Igv = item.Igv,
                                        subTotal = item.ValorVenta,
                                        Total = item.Total,
                                        porIsc = 0,
                                        porIgv = item.porIgv,
                                        idUnidadMedida = 59, //Unidades/Servicio
                                        Contiene = 0,
                                        PesoUnitario = 0,
                                        Stock = 0,
                                        idListaPrecio = null,
                                        nroOt = oFrm.oTrabajoServicio.idOT,
                                        nroOtItem = item.idItem,
                                        PesoBrutoCad = "0",
                                        indCalculo = true,
                                        tipArticulo = "SE",
                                        TipoImpSelectivo = String.Empty,
                                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                        FechaRegistro = VariablesLocales.FechaHoy,
                                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                        FechaModificacion = VariablesLocales.FechaHoy
                                    };

                                    DocumentoEmitido.ListaItemsDocumento.Add(oDetalle);

                                    Item++;
                                }

                                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                                bsDetalleDocumento.ResetBindings(false);

                                SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                            }
                        }
                    }
                    else
                    {
                        Int32.TryParse(txtIdCliente.Text, out Int32 Persona);
                        frmBuscarOtServicios oFrm = new frmBuscarOtServicios(Persona);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oTrabajoServicio != null)
                        {
                            txtIdCliente.TextChanged -= txtIdCliente_TextChanged;
                            txtRuc.TextChanged -= txtRuc_TextChanged;
                            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                            //cboDocumentoRef.SelectedValue = "OT";
                            //txtIdOt.Text = oFrm.oTrabajoServicio.idOT.ToString();
                            //txtNumOt.Text = oFrm.oTrabajoServicio.numeroOT;
                            txtIdCliente.Text = oFrm.oTrabajoServicio.idPersona.ToString();
                            txtRuc.Text = oFrm.oTrabajoServicio.RUC;
                            txtRazonSocial.Text = oFrm.oTrabajoServicio.RazonSocial;
                            txtDireccion.Text = oFrm.oTrabajoServicio.Direccion;

                            txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                            txtRuc.TextChanged += txtRuc_TextChanged;
                            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;

                            List<OrdenTrabajoServicioItemE> oLista = AgenteVentas.Proxy.ListarOrdenTrabajoServicioItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                        VariablesLocales.SesionLocal.IdLocal,
                                                                                                                        oFrm.oTrabajoServicio.idOT);
                            if (oLista.Count > 0)
                            {
                                EmisionDocumentoDetE oDetalle = null;
                                Int32 Item = Variables.ValorUno;
                                Decimal PrecioConImpuesto = 0;
                                Decimal Igv = VariablesLocales.oListaImpuestos[0].Porcentaje;
                                oTipoMedida = AgenteGeneral.Proxy.ParTablaPorNemo("UNI");
                                Int32 idTipoMedidaTmp = 0;

                                if (oTipoMedida != null)
                                {
                                    idTipoMedidaTmp = oTipoMedida.IdParTabla;
                                }

                                if (DocumentoEmitido.ListaItemsDocumento != null && DocumentoEmitido.ListaItemsDocumento.Count() > 0)
                                {
                                    Item = DocumentoEmitido.ListaItemsDocumento.Count() + 1;
                                }
                                else
                                {
                                    Item = Variables.ValorUno;
                                }

                                foreach (OrdenTrabajoServicioItemE item in oLista)
                                {
                                    PrecioConImpuesto = (item.PrecioUnitario * Igv) + item.PrecioUnitario;

                                    oDetalle = new EmisionDocumentoDetE()
                                    {
                                        idEmpresa = item.idEmpresa,
                                        idLocal = item.idLocal,
                                        idDocumento = cboTipoDocumento.SelectedValue.ToString(),
                                        numSerie = cboSeries.SelectedValue.ToString(),
                                        numDocumento = txtNumDocumento.Text,
                                        Item = String.Format("{0:000}", Item),
                                        idAlmacen = 0,
                                        idArticulo = item.idArticulo,
                                        codArticulo = item.codArticulo,
                                        nomArticulo = item.Descripcion,
                                        Lote = "0000000",
                                        Cantidad = item.Cantidad,
                                        CantidadFinal = item.Cantidad,
                                        PrecioConImpuesto = PrecioConImpuesto,
                                        PrecioSinImpuesto = item.PrecioUnitario,
                                        Dscto1 = 0,
                                        Dscto2 = 0,
                                        Dscto3 = 0,
                                        porDscto1 = 0,
                                        porDscto2 = 0,
                                        porDscto3 = 0,
                                        flgIgv = item.flgIgv,
                                        Isc = 0,
                                        Igv = item.Igv,
                                        subTotal = item.ValorVenta,
                                        Total = item.Total,
                                        porIsc = 0,
                                        porIgv = item.porIgv,
                                        idUnidadMedida = 59, //Unidades/Servicio
                                        Contiene = 0,
                                        PesoUnitario = 0,
                                        Stock = 0,
                                        idListaPrecio = null,
                                        nroOt = oFrm.oTrabajoServicio.idOT,
                                        nroOtItem = item.idItem,
                                        PesoBrutoCad = "0",
                                        indCalculo = true,
                                        tipArticulo = "SE",
                                        TipoImpSelectivo = String.Empty,
                                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                        FechaRegistro = VariablesLocales.FechaHoy,
                                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                        FechaModificacion = VariablesLocales.FechaHoy
                                    };

                                    DocumentoEmitido.ListaItemsDocumento.Add(oDetalle);

                                    Item++;
                                }

                                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                                bsDetalleDocumento.ResetBindings(false);

                                SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtIdCliente.TextChanged += txtIdCliente_TextChanged;
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}
