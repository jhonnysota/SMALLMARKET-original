using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;
using InputKey;

namespace ClienteWinForm.Ventas
{
    public partial class frmBoletaUf : FrmMantenimientoBase
    {

        #region Constructores

		public frmBoletaUf()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetalle, true);
            LlenarAyuda();
            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                dgvDetalle.Columns["Lote"].HeaderText = "Talla";
            }
        }

        //Edición
        public frmBoletaUf(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero, List<NumControlDetE> ListaDetalle)
            : this()
        {
            DocumentoEmitido = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);
            Boolean Entro = false;

            if (DocumentoEmitido.EnviadoSunat)
            {
                Global.MensajeFault("Este documento ha sido enviado a sunat, no puede hacer modificaciones.");
                dgvDetalle.ClearSelection();
                BloquearControles(false);
                HabilitaBotones = false;
                Entro = true;
            }

            if (!Entro)
            {
                if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.E.ToString())
                {
                    Global.MensajeFault("Este documento ha sido Emitido, no puede hacer ninguna modificación.");
                    dgvDetalle.ClearSelection();
                    BloquearControles(false);
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
                    BloquearControles(false);
                    HabilitaBotones = false;
                } 
            }
        }

        //Nuevo
        public frmBoletaUf(List<NumControlDetE> ListaDetalle)
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
        Decimal MontoAnticipo = 0;
        int numDias = 0;
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
            var oListaDocumento = ListaDocumentosControl.GroupBy(x => x.idDocumento).Select(p => p.First()).ToList();
            oListaDocumento.Add(new NumControlDetE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });

            //Llenando el tipo de documento
            ComboHelper.LlenarCombos<NumControlDetE>(cboTipoDocumento, oListaDocumento, "idDocumento", "desDocumento");

            //Llenando los documentos existentes...
            List<DocumentosE> oListaRef = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral)
            {
                new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione }
            };

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoRef, (from x in oListaRef orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);
            cboDocumentoRef.SelectedValue = Variables.Cero.ToString();

            if (VariablesLocales.oVenParametros.indAfectacionIgv) // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
            {
                //Razón de exoneración del IGV
                //List<ParTabla> oListaExoneracion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPAFEIGV");
                //oListaExoneracion.Add(new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione });
                //ComboHelper.LlenarCombos<ParTabla>(cboExoneracion, (from x in oListaExoneracion orderby x.IdParTabla select x).ToList(), "IdParTabla", "desTemporal");
                List<AfectacionIgvE> ListaAfectacion = AgenteMaestro.Proxy.ListarAfectacionIgvActivos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                ListaAfectacion.Add(new AfectacionIgvE() { idAfectacion = 0, desTemporal = Variables.Seleccione });
                ComboHelper.LlenarCombos<AfectacionIgvE>(cboExoneracion, (from x in ListaAfectacion orderby x.idAfectacion select x).ToList(), "idAfectacion", "desTemporal");
            }

            //Establecimientos
            List<EstablecimientosE> oListaEstablecimientos = AgenteMaestro.Proxy.ListarEstablecimientos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
            oListaEstablecimientos.Add(new EstablecimientosE() { idEstablecimiento = Variables.Cero, Descripcion = Variables.Seleccione });
            ComboHelper.LlenarCombos<EstablecimientosE>(cboEstablecimiento, (from x in oListaEstablecimientos orderby x.idEstablecimiento select x).ToList(), "idEstablecimiento", "Descripcion");

            //Divisiones
            List<ParTabla> oListaDivisiones = AgenteGeneral.Proxy.ListarParTablaPorNemo("DIVI");
            oListaDivisiones.Add(new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione });
            ComboHelper.LlenarCombos<ParTabla>(cboDivision, (from x in oListaDivisiones orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            oListaDivisiones = null;
            oListaEstablecimientos = null;
        }

        void LlenarAyuda()
        {
            Global.CrearToolTip(btBuscarCliente, "Buscar Cliente.");
            Global.CrearToolTip(btBuscarDireccion, "Buscar otra direccion(Sucursal).");
            Global.CrearToolTip(btBuscarVendedor, "Buscar vendedor.");
            Global.CrearToolTip(btBuscarCondicion, "Buscar condiciones de venta.");
            Global.CrearToolTip(btSunat, "Consultas a Sunat.");
            Global.CrearToolTip(btDocumentos, "Ver documentos relacionados.");
        }

        void ValoresPorDefecto(String Serie)
        {
            NumControlDetE Detalle = AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idControlTmp,
                                    cboTipoDocumento.SelectedValue.ToString(), Serie);

            if (Detalle != null)
            {
                cboMonedas.SelectedValue = Detalle.idMoneda;
                txtNumDocumento.MaxLength = Convert.ToInt32(Detalle.cantDigNumero);
                txtNumDocumento.Text = DevolverNumeroCorrelativo(Detalle.numCorrelativo, Convert.ToInt32(Detalle.cantDigNumero));

                cboEsGuia.SelectedValue = Detalle.EsGuia;

                if (Detalle.idCondicion != null && Detalle.idCondicion > Variables.Cero)
                {
                    txtIdCondicion.Text = Convert.ToInt32(Detalle.idCondicion).ToString("00");

                    CondicionE tmpCondicion = AgenteVentas.Proxy.ObtenerCondicion((Int32)EnumTipoDocNumControl.Facturas, Convert.ToInt32(Detalle.idCondicion));
                    txtDesCondicion.Text = tmpCondicion.desCondicion;

                    numDias = AgenteVentas.Proxy.ObtenerDiasVencimiento(Convert.ToInt32(tmpCondicion.idTipCondicion), tmpCondicion.idCondicion);

                    if (numDias != Variables.Cero)
                    {
                        dtpFecVencimiento.Value = DateTime.Today.Date.AddDays(numDias);
                    }
                    else
                    {
                        dtpFecVencimiento.Value = DateTime.Today.Date;
                    }
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
            DocumentoEmitido.fecVencimiento = dtpFecVencimiento.Value.ToString("yyyyMMdd");
            DocumentoEmitido.indRecepcion = false;
            DocumentoEmitido.fecRecepcion = null;
            DocumentoEmitido.Direccion = Global.DejarSoloUnEspacio(txtDireccion.Text.Trim().Replace(@"\r\n", "").Replace(@"\n", "").Replace(@"\r", "").Replace(Environment.NewLine, ""));
            DocumentoEmitido.idVendedor = String.IsNullOrEmpty(txtIdVendedor.Text.Trim()) ? 0 : Convert.ToInt32(txtIdVendedor.Text);
            DocumentoEmitido.EsGuia = cboEsGuia.SelectedValue.ToString();

            //Tipo Condición
            if (String.IsNullOrEmpty(txtIdCondicion.Text.Trim()))
            {
                DocumentoEmitido.idTipCondicion = null;
                DocumentoEmitido.idCondicion = null;
            }
            else
            {
                DocumentoEmitido.idTipCondicion = (Int32)EnumTipoCondicionVenta.FacBol;
                DocumentoEmitido.idCondicion = Convert.ToInt32(txtIdCondicion.Text);
            }            

            DocumentoEmitido.idMoneda = cboMonedas.SelectedValue.ToString();
            DocumentoEmitido.tipCambio = Convert.ToDecimal(txtTica.Text);
            DocumentoEmitido.totMontoBruto = Convert.ToDecimal(lblTotal.Text);
            DocumentoEmitido.totsubTotal = Convert.ToDecimal(lblSubTotal.Text);
            DocumentoEmitido.totDscto1 = totdsc1;
            DocumentoEmitido.totDscto2 = totdsc2;
            DocumentoEmitido.totDscto3 = totdsc3;
            DocumentoEmitido.totIsc = Convert.ToDecimal(lblIsc.Text);
            DocumentoEmitido.totIgv = Convert.ToDecimal(lblIgv.Text);
            DocumentoEmitido.totTotal = Convert.ToDecimal(lblTotal.Text);
            DocumentoEmitido.idTipTransporte = String.Empty;

            if (VariablesLocales.oVenParametros.indZona)
            {
                DocumentoEmitido.idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
                DocumentoEmitido.idZona = cboZona.SelectedValue != null ? Convert.ToInt32(cboZona.SelectedValue) : (Int32?)null;
                DocumentoEmitido.idDivision = Convert.ToInt32(cboDivision.SelectedValue);
            }
            else
            {
                DocumentoEmitido.idEstablecimiento = null;
                DocumentoEmitido.idZona = null;
                DocumentoEmitido.idDivision = null;
            }

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Solo Aldeasa...
            {
                DocumentoEmitido.Invoice = txtInvoice.Text.Trim();
                DocumentoEmitido.Periodo = txtPeriodo.Text.Trim();
                DocumentoEmitido.PO = txtPo.Text.Trim();

                DocumentoEmitido.NombrePuerto = String.Empty;
                DocumentoEmitido.numReserva = String.Empty;
                DocumentoEmitido.numPartida = String.Empty;
            }
            else
            {
                DocumentoEmitido.Invoice = String.Empty;
                DocumentoEmitido.Periodo = String.Empty;
                DocumentoEmitido.PO = String.Empty;

                DocumentoEmitido.NombrePuerto = txtInvoice.Text.Trim();
                DocumentoEmitido.numReserva = txtPeriodo.Text.Trim();
                DocumentoEmitido.numPartida = txtPo.Text.Trim();
            }

            DocumentoEmitido.AfectoDetraccion = Convert.ToBoolean(chkDetraccion.Checked);
            DocumentoEmitido.Glosa = txtGlosa.Text;

            DocumentoEmitido.totAfectoPerce = Variables.ValorCeroDecimal;
            DocumentoEmitido.totPercepcion = Variables.ValorCeroDecimal;
            DocumentoEmitido.indEstado = EnumEstadoDocumentos.C.ToString();

            //Datos Clientes
            DocumentoEmitido.idPersona = Convert.ToInt32(txtRuc.Tag) == 0 ? (Nullable<Int32>)null : Convert.ToInt32(txtRuc.Tag);
            DocumentoEmitido.numRuc = txtRuc.Text;
            DocumentoEmitido.RazonSocial = Global.DejarSoloUnEspacio(txtRazonSocial.Text.Trim().Replace(@"\r\n", "").Replace(@"\n", "").Replace(@"\r", "").Replace(Environment.NewLine, ""));
            DocumentoEmitido.idSucursalCliente = String.IsNullOrEmpty(txtIdSucursal.Text.Trim()) ? 0 : Convert.ToInt32(txtIdSucursal.Text);
            DocumentoEmitido.idCanalVenta = CanalVenta;
            DocumentoEmitido.AfectoRetencion = chkRetencion.Checked;

            //Documento de referencia
            DocumentoEmitido.idDocumentoRef = cboDocumentoRef.SelectedValue.ToString() == "0" ? String.Empty : cboDocumentoRef.SelectedValue.ToString();
            DocumentoEmitido.serDocumentoRef = txtSerieRef.Text.Trim();
            DocumentoEmitido.numDocumentoRef = txtNumDocumentoRef.Text.Trim();

            //Para saber si tiene asignado algun voucher
            if (!String.IsNullOrEmpty(DocumentoEmitido.numFile) && !String.IsNullOrEmpty(DocumentoEmitido.numVoucher))
            {
                DocumentoEmitido.indVoucher = false;
            }

            DocumentoEmitido.nroDocAsociado = Convert.ToInt32(txtNroAsociado.Tag);
            DocumentoEmitido.fecEnvioSunat = null;
            DocumentoEmitido.fecAnuladoSunat = null;

            if (VariablesLocales.oVenParametros.indAfectacionIgv) // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
            {
                DocumentoEmitido.tipAfectoIgv = Convert.ToInt32(cboExoneracion.SelectedValue);
            }
            else
            {
                DocumentoEmitido.tipAfectoIgv = Variables.Cero;
            }

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

            DocumentoEmitido.EsAnticipo = chkAnticipo.Checked;

            if (lblAnticipos.Items.Count > 0)
            {
                DocumentoEmitido.indAnticipo = true;
            }
            else
            {
                DocumentoEmitido.indAnticipo = false;
            }

            DocumentoEmitido.AfectoDetraccion = chkDetraccion.Checked;

            if (chkDetraccion.Checked)
            {
                DocumentoEmitido.tipDetraccion = cboTipoDetraccion.SelectedValue.ToString();
                DocumentoEmitido.TasaDetraccion = Convert.ToDecimal(txtTasaDetra.Text);
                DocumentoEmitido.MontoDetraccion = Convert.ToDecimal(txtMontoDetraS.Text);
            }
            else
            {
                DocumentoEmitido.tipDetraccion = String.Empty;
                DocumentoEmitido.TasaDetraccion = 0M;
                DocumentoEmitido.MontoDetraccion = 0M;
            }

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
              ///  DocumentoEmitido.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            }
        }

        void BloquearControles(Boolean Flag)
        {
            pnlComprobante.Enabled = Flag;
            pnlCliente.Enabled = Flag;
            pnlVendedor.Enabled = Flag; //Vendedor
            txtGlosa.Enabled = Flag;
            chkDetraccion.Enabled = Flag;
            cboTipoDetraccion.Enabled = Flag;
            txtInvoice.Enabled = Flag;
            txtPeriodo.Enabled = Flag;
            txtPo.Enabled = Flag;
            cboExoneracion.Enabled = Flag;
            btAgregarNota.Enabled = Flag;
            btInsertar.Enabled = Flag;
            chkPorcentaje.Enabled = Flag;
            chkAnticipo.Enabled = Flag;
            btInsertar.Enabled = Flag;
            btBorrar.Enabled = Flag;
            btAnticipo.Enabled = Flag;
            btEliminarItem.Enabled = Flag;
            Bloqueo = Flag;
            tsmiBonificacion.Enabled = Flag;
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
                Boolean CalcAutomatico = false;

                if (chkDetraccion.Checked)
                {
                    CalcAutomatico = (from x in oListaDetalle where x.indDetraccion select x.indDetraccion).FirstOrDefault();

                    if (CalcAutomatico)
                    {
                        txtTipoCalculo.Text = "A";
                    }
                    else
                    {
                        txtTipoCalculo.Text = "M";
                    }
                }

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

                EmisionDocumentoDetE oAplicacionAnticipo = oListaDetalle.Find
                (
                    delegate (EmisionDocumentoDetE aa) { return aa.tipArticulo == "AA"; }
                );

                if (oAplicacionAnticipo != null)
                {
                    Int32 Posicion = oListaDetalle.FindIndex(n => n.tipArticulo == "AA");

                    if (Math.Abs(SubTotal) < 0.03M)
                    {
                        bsDetalleDocumento.Position = Posicion - 1;

                        if (SubTotal > 0)
                        {
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).subTotal -= Math.Abs(SubTotal);
                        }
                        else
                        {
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).subTotal += Math.Abs(SubTotal);
                        }

                        SubTotal = 0;
                        ValorGravado = 0;
                    }

                    if (Math.Abs(Igv) < 0.03M)
                    {
                        bsDetalleDocumento.Position = Posicion - 1;

                        if (Igv > 0)
                        {
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Igv -= Math.Abs(Igv);
                        }
                        else
                        {
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Igv += Math.Abs(Igv);
                        }

                        Igv = 0;
                    }

                    if (Math.Abs(Total) < 0.03M)
                    {
                        bsDetalleDocumento.Position = Posicion - 1;

                        if (Total > 0)
                        {
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Total -= Math.Abs(Total);
                        }
                        else
                        {
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Total += Math.Abs(Total);
                        }

                        Total = 0;
                    }

                    bsDetalleDocumento.ResetBindings(false);
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
            int Numero;
            if (String.IsNullOrEmpty(Correlativo))
            {
                Numero = Variables.Cero;
            }
            else
            {
                Numero = Convert.ToInt32(Correlativo);
            }

            Numero++;
            return Numero.ToString().PadLeft(cantDigitos, '0');
        }

        void EditarDetalle(DataGridViewCellEventArgs e, EmisionDocumentoDetE oItem)
        {
            if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).tipArticulo == "AN") /// Anticipos
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
                if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).tipArticulo == "SE") //// Servicios
                {
                    frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, oItem, "S");
                    String Item = oItem.Item;

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDetalleDocumento != null)
                    {
                        EmisionDocumentoDetE ItemDet = oFrm.oDetalleDocumento;
                        ItemDet.Item = Item;
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
                else if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).tipArticulo == "AR") //// Articulos
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
                        CalcularDetraccion(DocumentoEmitido.ListaItemsDocumento);
                    }
                } 
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
                        fecInscripcion = null,
                        fecInicioEmpresa = null,
                        tipConstitucion = 0,
                        tipRegimen = 0,
                        catCliente = 0,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                    };

                    AgenteMaestro.Proxy.InsertarCliente(oCliente);
                }
            }
        }

        void LlenarComboDetraccion(DateTime Fecha)
        {
            // Tipo de Detraccion //revisar
            //List<TasasDetraccionesDetalleE> ListaTipoDetraccion = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(Fecha);

            //if (ListaTipoDetraccion.Count > 0)
            //{
            //    ListaTipoDetraccion.Add(new TasasDetraccionesDetalleE() { idTipoDetraccion = Variables.Cero.ToString(), Nombre = "<<Escoger Tasa>>" });
            //    ComboHelper.RellenarCombos<TasasDetraccionesDetalleE>(cboTipoDetraccion, (from x in ListaTipoDetraccion orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "Nombre", false);
            //}
            //else
            //{
            //    Global.MensajeFault("No existe ningún Tipo de Detracción para la fecha escogida.");
            //    cboTipoDetraccion.DataSource = null;
            //    chkDetraccion.Checked = false;
            //    chkDetraccion.Enabled = true;
            //}
        }

        void CalcularDetraccion(List<EmisionDocumentoDetE> oListaDetalle)
        {
            if (oListaDetalle != null && oListaDetalle.Count > 0)
            {
                Decimal? TasaDetraccion = (from x in oListaDetalle where x.indDetraccion == true select (Decimal?)x.TasaDetraccion).Max();
                EmisionDocumentoDetE det = oListaDetalle.Find
                (
                    delegate (EmisionDocumentoDetE d) { return d.indDetraccion == true && d.TasaDetraccion == TasaDetraccion; }
                );

                if (det != null)
                {
                    chkDetraccion.Checked = true;
                    cboTipoDetraccion.SelectedValue = det.tipDetraccion.ToString();

                    if (cboTipoDetraccion.SelectedValue != null)
                    {
                        TasasDetraccionesDetalleE oDetraccion = (TasasDetraccionesDetalleE)cboTipoDetraccion.SelectedItem;
                        Decimal.TryParse(lblTotal.Text, out Decimal Monto);

                        if (cboMonedas.SelectedValue.ToString() != "01")
                        {
                            Decimal.TryParse(txtTica.Text, out Decimal tica);
                            Monto = Monto * tica;
                        }

                        if (oDetraccion != null)
                        {
                            if (Monto > oDetraccion.BaseAfecta || oDetraccion.BaseAfecta == 0)
                            {
                                txtTasaDetra.Text = oDetraccion.Porcentaje.ToString("N2");
                                Decimal.TryParse(lblTotal.Text, out Decimal Importe);

                                txtMontoDetraS.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * Importe, 2).ToString("N2");
                                txtTipoCalculo.Text = "A";
                                //chkDetraccion.Enabled = false;
                                //cboTipoDetraccion.Enabled = false;
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

        void CalcularDetraccionManual(List<EmisionDocumentoDetE> oListaDetalle)
        {
            if (cboTipoDetraccion.SelectedValue != null)
            {
                TasasDetraccionesDetalleE oDetraccion = (TasasDetraccionesDetalleE)cboTipoDetraccion.SelectedItem;
                Decimal.TryParse(lblTotal.Text, out Decimal Monto);

                if (cboMonedas.SelectedValue.ToString() != "01")
                {
                    Decimal.TryParse(txtTica.Text, out Decimal tica);
                    Monto = Monto * tica;
                }

                if (oDetraccion != null)
                {
                    if (Monto > oDetraccion.BaseAfecta || oDetraccion.BaseAfecta == 0)
                    {
                        txtTasaDetra.Text = oDetraccion.Porcentaje.ToString("N2");
                        Decimal.TryParse(lblTotal.Text, out Decimal Importe);

                        txtMontoDetraS.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * Importe, 2).ToString("N2");
                        txtTipoCalculo.Text = "M";
                    }
                    else
                    {
                        txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                        txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                    }
                }
                else
                {
                    txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtMontoDetraS.Text = Variables.ValorCeroDecimal.ToString("N2");
                }
            }
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            if (DocumentoEmitido == null)
            {
                Opcion = (Int16)EnumOpcionGrabar.Insertar;

                DocumentoEmitido = new EmisionDocumentoE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                    UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                    FechaRegistro = VariablesLocales.FechaHoy,
                    UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                    FechaModificacion = VariablesLocales.FechaHoy
                };

                if (VariablesLocales.oVenParametros.indAfectacionIgv) // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
                {
                    cboExoneracion.SelectedValue = Convert.ToInt32(VariablesLocales.oVenParametros.razonExoIgv);
                }

                txtRuc.Tag = 0;
                txtNroAsociado.Tag = 0;
                cboDocumentoRef.SelectedValue = "OC";
                BloquearPanelComprobante(true);
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                dtFecEmision_ValueChanged(null, null);

                Text = "Boleta (Nuevo)";
                lblCaptionDetra.Text = "Monto " + ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;
            }
            else
            {
                Opcion = Convert.ToInt16(EnumOpcionGrabar.Actualizar);
                dtFecEmision.ValueChanged -= new EventHandler(dtFecEmision_ValueChanged);
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                cboTipoDocumento.SelectedValue = DocumentoEmitido.idDocumento;
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                cboEsGuia.SelectedValue = DocumentoEmitido.EsGuia;
                txtNumDocumento.Text = DocumentoEmitido.numDocumento;
                cboSeries.SelectedValue = DocumentoEmitido.numSerie.ToString();
                BloquearPanelComprobante(false);

                dtFecEmision.Value = Convert.ToDateTime(DocumentoEmitido.fecEmision);
                LlenarComboDetraccion(Convert.ToDateTime(DocumentoEmitido.fecEmision));

                txtInvoice.Text = DocumentoEmitido.Invoice.Trim();
                txtPeriodo.Text = DocumentoEmitido.Periodo.Trim();
                txtPo.Text = DocumentoEmitido.PO.Trim();

                chkDetraccion.Checked = DocumentoEmitido.AfectoDetraccion;
                cboMonedas.SelectedValue = DocumentoEmitido.idMoneda;
                txtTica.Text = DocumentoEmitido.tipCambio.ToString();
                txtIdCondicion.Text = Convert.ToInt32(DocumentoEmitido.idCondicion).ToString();
                txtDesCondicion.Text = DocumentoEmitido.desCondicion;
                dtpFecVencimiento.Value = String.IsNullOrWhiteSpace(DocumentoEmitido.fecVencimiento) == false ? Convert.ToDateTime(DocumentoEmitido.fecVencimiento) : DateTime.Now.Date;
                txtRuc.Tag = DocumentoEmitido.idPersona;
                txtRuc.Text = DocumentoEmitido.numRuc;
                txtRazonSocial.Text = DocumentoEmitido.RazonSocial;
                txtDireccion.Text = DocumentoEmitido.Direccion;
                chkRetencion.Checked = DocumentoEmitido.AfectoRetencion;
                txtIdSucursal.Text = DocumentoEmitido.idSucursalCliente == 0 ? String.Empty : DocumentoEmitido.idSucursalCliente.ToString();
                txtIdVendedor.Text = DocumentoEmitido.idVendedor == 0 ? String.Empty : DocumentoEmitido.idVendedor.ToString();
                txtVendedor.Text = DocumentoEmitido.Vendedor;
                txtGlosa.Text = DocumentoEmitido.Glosa;
                cboDivision.SelectedValue = Convert.ToInt32(DocumentoEmitido.idDivision);
                cboEstablecimiento.SelectedValue = DocumentoEmitido.idEstablecimiento;
                cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                cboZona.SelectedValue = DocumentoEmitido.idZona;

                if (DocumentoEmitido.nroDocAsociado != 0)
                {
                    txtNroAsociado.Tag = DocumentoEmitido.nroDocAsociado;
                    txtNroAsociado.Text = DocumentoEmitido.Pedido;
                }
                else
                {
                    txtNroAsociado.Tag = 0;
                }

                //Documento de referencia
                if (!String.IsNullOrEmpty(DocumentoEmitido.idDocumentoRef.Trim()))
                {
                    cboDocumentoRef.SelectedValue = DocumentoEmitido.idDocumentoRef.ToString();
                    txtSerieRef.Text = DocumentoEmitido.serDocumentoRef;
                    txtNumDocumentoRef.Text = DocumentoEmitido.numDocumentoRef;
                }

                if (DocumentoEmitido.ListaItemsDocumento == null)
                {
                    DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                }

                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                bsDetalleDocumento.ResetBindings(false);

                if (DocumentoEmitido.DsctoGlobal > Variables.Cero && DocumentoEmitido.porDscto > Variables.Cero)
                {
                    chkPorcentaje.CheckedChanged -= chkPorcentaje_CheckedChanged;
                    chkPorcentaje.Checked = true;
                    lblPorcentaje.Text = DocumentoEmitido.porDscto.Value.ToString("N2");
                    lblDsctoGlobal.Text = DocumentoEmitido.DsctoGlobal.Value.ToString("N2");
                    chkPorcentaje.CheckedChanged += chkPorcentaje_CheckedChanged;
                }
                else
                {
                    lblPorcentaje.Text = "0.00";
                    lblDsctoGlobal.Text = "0.00";
                }

                CanalVenta = DocumentoEmitido.idCanalVenta;

                if (VariablesLocales.oVenParametros.indAfectacionIgv) // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
                {
                    if (DocumentoEmitido.tipAfectoIgv != null)
                    {
                        cboExoneracion.SelectedValue = Convert.ToInt32(DocumentoEmitido.tipAfectoIgv);
                    }
                }

                chkAnticipo.Checked = DocumentoEmitido.EsAnticipo;
                chkAnticipo_CheckedChanged(null, null);

                //Llenando si hay anticipos
                if (DocumentoEmitido.indAnticipo)
                {
                    foreach (AnticiposE item in DocumentoEmitido.ListaAnticipos)
                    {
                        lblAnticipos.Items.Add(item.idDocAnticipo + "-" + item.numSerieAnticipo + "-" + item.numDocAnticipo);
                    }
                }

                SumarTotal(DocumentoEmitido.ListaItemsDocumento);

                chkDetraccion.Checked = DocumentoEmitido.AfectoDetraccion;

                if (DocumentoEmitido.AfectoDetraccion)
                {
                    cboTipoDetraccion.SelectedValue = DocumentoEmitido.tipDetraccion.ToString();
                    txtTasaDetra.Text = DocumentoEmitido.TasaDetraccion.ToString("N2");
                    txtMontoDetraS.Text = DocumentoEmitido.MontoDetraccion.ToString("N2");
                }

                Text = "Boleta (" + DocumentoEmitido.numSerie + "-" + DocumentoEmitido.numDocumento + ")";

                if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.E.ToString() || DocumentoEmitido.indEstado == EnumEstadoDocumentos.B.ToString())
                {
                    btAnticipo.Enabled = false;
                    btQuitarAnticipo.Enabled = false;
                    btAnticipos.Enabled = false;
                    btArticulos.Enabled = false;
                    btServicios.Enabled = false;
                }

                dtFecEmision.ValueChanged += new EventHandler(dtFecEmision_ValueChanged);
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }

            cboDocumentoRef_SelectionChangeCommitted(new object(), new EventArgs());

            if (HabilitaBotones)
            {
                base.Nuevo();

                if (DocumentoEmitido.ListaCancelaciones != null)
                {
                    btQuitarCancelacion.Enabled = DocumentoEmitido.ListaCancelaciones.Count > 0;
                }
            }
            else
            {
                btArticulos.Enabled = false;
                btServicios.Enabled = false;
                btAnticipos.Enabled = false;
                btEliminarItem.Enabled = false;
                btAnticipo.Enabled = false;
                btQuitarAnticipo.Enabled = false;
                btPagos.Enabled = false;
                btQuitarCancelacion.Enabled = false;
                btInsertar.Enabled = false;
                btBorrar.Enabled = false;

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
                    if (Global.MensajeConfirmacion("La Boleta no tiene Total. Falta ingresar precios.\n\rDesea continuar") == DialogResult.No)
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

        public override bool ValidarGrabacion()
        {
            if (DocumentoEmitido.ListaItemsDocumento.Count == 0)
            {
                MessageBox.Show("Ingrese Detalle de Boleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            Persona oPersona = AgenteMaestro.Proxy.RecuperarPersonaPorID(Convert.ToInt32(txtRuc.Tag));

            if (oPersona != null)
            {
                if (oPersona.TipoPersona == 0)
                {
                    Global.MensajeFault("El cliente no tiene definido el tipo de personeria.");
                    return false;
                }

                ParTabla oTipoDePersoneria = AgenteGeneral.Proxy.RecuperarParTablaPorId(oPersona.TipoPersona);

                if (oTipoDePersoneria.ValorCadena == "JR" || oTipoDePersoneria.ValorCadena == "NT")
                {
                    Global.MensajeFault("El cliente tiene Ruc deberia hacerle una Factura.");
                    return true;
                }

            }
            else
            {
                Global.MensajeFault("El cliente no existe.");
                return false;
            }

            if (txtTica.Text != "0.000")
            {
                MessageBox.Show("Debe ingresar el tipo de cambio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //if (VariablesLocales.oVenParametros.indZona)
            //{
            //    if (cboEstablecimiento.SelectedValue == null || Convert.ToInt32(cboEstablecimiento.SelectedValue) == 0)
            //    {
            //        Global.MensajeFault("Debe escoger una Zona.");
            //        return false;
            //    }

            //    if (cboZona.SelectedValue == null || Convert.ToInt32(cboZona.SelectedValue) == 0)
            //    {
            //        Global.MensajeFault("Debe escoger una Zona de Influencia.");
            //        return false;
            //    }

            //    if (cboDivision.SelectedValue == null || Convert.ToInt32(cboDivision.SelectedValue) == 0)
            //    {
            //        Global.MensajeFault("Debe escoger una División.");
            //        return false;
            //    }
           // }

            Decimal Total = Variables.Cero;
            Decimal.TryParse(lblTotal.Text, out Total);

            if (Total >= VariablesLocales.oVenParametros.MontoBoleta)
            {
                if (Convert.ToInt32(txtRuc.Tag) == 0 && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    Global.MensajeFault(String.Format("Cuando el monto supera {0}, es obliglatorio colocar los datos del cliente.", VariablesLocales.oVenParametros.MontoBoleta));
                    return false;
                }
            }

            if (!String.IsNullOrWhiteSpace(txtIdCondicion.Text.Trim()))
            {
                CondicionE oCondicion = AgenteVentas.Proxy.ObtenerCondicion(Convert.ToInt32(EnumTipoCondicionVenta.FacBol), Convert.ToInt32(txtIdCondicion.Text.Trim()));

                if (oCondicion.indCreditoCobranza && Convert.ToDecimal(lblTotal.Text) > 0)
                {
                    if (!DocumentoEmitido.indCancelacion)
                    {
                        Global.MensajeFault("Falta ingresar la cancelación del documento.");
                        return false;
                    }
                }
            }

            if (chkAnticipo.Checked)
            {
                foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                {
                    if (item.tipArticulo != "AN")
                    {
                        Global.MensajeFault(String.Format("Se trata de una Boleta de anticipo no puede colocar otro tipo de items."));
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimiento Heredados

        #region Eventos

        private void frmBoletaUf_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            Nuevo();

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                btNuevoNumControl.Visible = true;
            }

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20251352292") //Aldeasa
            {
                txtInvoice.Visible = true;
                txtPeriodo.Visible = true;
                txtPo.Visible = true;
                chkDetraccion.Visible = true;
                btPagos.Visible = false;
                cboEsGuia.Enabled = false;
            }
            else //El resto de empresas
            {
                txtInvoice.Visible = false;
                txtPeriodo.Visible = false;
                txtPo.Visible = false;
            }

            if (VariablesLocales.oVenParametros.indAfectacionIgv) // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
            {
                label9.Visible = true;
                cboExoneracion.Visible = true;
            }
            else
            {
                label9.Visible = false;
                cboExoneracion.Visible = false;
            }

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Solo para el Fundo San Miguel
            {
                cboEsGuia.Enabled = false;
            }

            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);

            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
            {
                dgvDetalle.Columns["nroOt"].Visible = false;
                dgvDetalle.Columns["nroOtItem"].Visible = false;
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

                dtpFecVencimiento.Value = DateTime.Today.Date.AddDays(numDias);
                LlenarComboDetraccion(dtFecEmision.Value.Date);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //List<NumControlDetE> ListaDetalle = AgenteVentas.Proxy.ListarSeriesNumControlDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal,
            //                    ((NumControlDetE)cboTipoDocumento.SelectedItem).idControl, cboTipoDocumento.SelectedValue.ToString());
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

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarClientes oFrm = new frmBuscarClientes();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCliente != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    txtRuc.Tag = oFrm.oCliente.idPersona;
                    txtRuc.Text = oFrm.oCliente.RUC;
                    txtRazonSocial.Text = oFrm.oCliente.RazonSocial;
                    txtDireccion.Text = oFrm.oCliente.DireccionCompleta;
                    CanalVenta = Convert.ToInt32(oFrm.oCliente.idCanalVenta);
                    chkRetencion.Checked = oFrm.oCliente.AgenteRetenedor;

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
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
                    Int32 idCondicion = oFrm.oCondicion.idCondicion;

                    DocumentoEmitido.idTipCondicion = oFrm.oCondicion.idTipCondicion;
                    DocumentoEmitido.idCondicion = idCondicion;
                    txtIdCondicion.Text = idCondicion.ToString("00");
                    txtDesCondicion.Text = oFrm.oCondicion.desCondicion;

                    if (VariablesLocales.oVenParametros.indAfectacionIgv) // Obligatorio usado en Fundo san miguel y Empresas con Bizlinks
                    {
                        //if (DocumentoEmitido.idCondicion == 74)
                        //{
                        //    cboExoneracion.SelectedValue = 307004;
                        //}
                        //else
                        //{
                        //    cboExoneracion.SelectedValue = 307001;
                        //}
                    }

                    numDias = AgenteVentas.Proxy.ObtenerDiasVencimiento(Convert.ToInt32(DocumentoEmitido.idTipCondicion), idCondicion);

                    if (numDias != Variables.Cero)
                    {
                        dtpFecVencimiento.Value = DateTime.Today.Date.AddDays(numDias);
                    }
                    else
                    {
                        dtpFecVencimiento.Value = DateTime.Today.Date;
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

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtFecEmision_ValueChanged(null, null);
            lblCaptionDetra.Text = "Monto " + ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            chkRetencion.Checked = false;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            chkRetencion.Checked = false;
        }

        private void chkPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoEmitido.ListaItemsDocumento.Count <= Variables.Cero)
                {
                    chkPorcentaje.Checked = false;
                    Global.MensajeFault("Tiene que tener al menos una linea para poder aplicar Dscto Global.");
                    return;
                }

                if (chkPorcentaje.Checked)
                {
                    frmCambioPrecio oFrm = new frmCambioPrecio(lblSubTotal.Text, lblPorcentaje.Text, lblDsctoGlobal.Text);

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

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            CanalVenta = oFrm.oPersona.idCanalVenta;
                            chkRetencion.Checked = oFrm.oPersona.AgenteRetenedor;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        CanalVenta = oListaPersonas[0].idCanalVenta;
                        chkRetencion.Checked = oListaPersonas[0].AgenteRetenedor;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        CanalVenta = Variables.Cero;
                        chkRetencion.Checked = false;
                        txtRuc.Focus();
                        return;
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
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtDireccion.Text = oFrm.oPersona.DireccionCompleta;
                            CanalVenta = oFrm.oPersona.idCanalVenta;
                            chkRetencion.Checked = oFrm.oPersona.AgenteRetenedor;
                        }
                        else
                        {
                            dgvDetalle.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        ValidarAuxiliar(oListaPersonas);

                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        CanalVenta = oListaPersonas[0].idCanalVenta;
                        chkRetencion.Checked = oListaPersonas[0].AgenteRetenedor;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        CanalVenta = Variables.Cero;
                        chkRetencion.Checked = false;
                        txtRazonSocial.Focus();
                        return;
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

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarGuia oFrm = new frmBuscarGuia();
                Int32 Correlativo = 1;
                DocumentoEmitido.ListaCanjeGuias = new List<CanjeGuiasE>();
                DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaDocumentos != null)
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    EmisionDocumentoDetE oDetalle = null;

                    foreach (EmisionDocumentoE itemCab in oFrm.oListaDocumentos)
                    {
                        cboDocumentoRef.SelectedValue = String.IsNullOrWhiteSpace(itemCab.idDocumentoRef) ? "0" : itemCab.idDocumentoRef;
                        cboDocumentoRef_SelectionChangeCommitted(new Object(), new EventArgs());
                        txtSerieRef.Text = itemCab.serDocumentoRef;
                        txtNumDocumentoRef.Text = itemCab.numDocumentoRef;

                        txtRuc.Tag = itemCab.idPersona;
                        txtRuc.Text = itemCab.numRuc;
                        txtRazonSocial.Text = itemCab.RazonSocial;
                        txtDireccion.Text = itemCab.Direccion;
                        txtIdVendedor.Text = itemCab.idVendedor.ToString();
                        txtVendedor.Text = itemCab.nomVendedor;
                        txtGlosa.Text = itemCab.Glosa;
                        cboDivision.SelectedValue = itemCab.idDivision;
                        cboEstablecimiento.SelectedValue = itemCab.idEstablecimiento;
                        cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboZona.SelectedValue = itemCab.idZona;
                        txtIdCondicion.Text = itemCab.idCondicion.ToString();
                        txtDesCondicion.Text = itemCab.desCondicion;
                        cboMonedas.SelectedValue = itemCab.idMoneda;

                        numDias = AgenteVentas.Proxy.ObtenerDiasVencimiento(Convert.ToInt32(itemCab.idTipCondicion), itemCab.idCondicion.Value);

                        if (numDias != Variables.Cero)
                        {
                            dtpFecVencimiento.Value = DateTime.Today.Date.AddDays(numDias);
                        }
                        else
                        {
                            dtpFecVencimiento.Value = DateTime.Today.Date;
                        }

                        foreach (EmisionDocumentoDetE ItemDet in itemCab.ListaItemsDocumento)
                        {
                            oDetalle = new EmisionDocumentoDetE();
                            oDetalle = ItemDet;

                            oDetalle.Item = Correlativo.ToString("000");
                            //oDetalle.tipArticulo = "AR";
                            oDetalle.UsuarioRegistro = oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oDetalle.FechaRegistro = oDetalle.FechaModificacion = VariablesLocales.FechaHoy;

                            oDetalle.idDocumentoRef = itemCab.idDocumento;
                            oDetalle.serDocumentoRef = itemCab.numSerie;
                            oDetalle.numDocumentoRef = itemCab.numDocumento;

                            Correlativo++;
                            DocumentoEmitido.ListaItemsDocumento.Add(oDetalle);
                        }

                        //Para llenar el Canje de Guias...
                        CanjeGuiasE Guia = new CanjeGuiasE
                        {
                            idDocumentoGuia = itemCab.idDocumento,
                            numSerieGuia = itemCab.numSerie,
                            numDocumentoGuia = itemCab.numDocumento
                        };

                        DocumentoEmitido.ListaCanjeGuias.Add(Guia);
                    }

                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);
                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                    CalcularDetraccion(DocumentoEmitido.ListaItemsDocumento);
                    Modificacion = true;

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

        private void btBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoEmitido.ListaCanjeGuias != null && DocumentoEmitido.ListaCanjeGuias.Count > Variables.Cero)
                {
                    //Quitando de la lista de guias...
                    DocumentoEmitido.ListaCanjeGuias = new List<CanjeGuiasE>();

                    DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    DocumentoEmitido.nroDocAsociado = Variables.Cero;

                    Modificacion = true;
                }
                else
                {
                    Global.MensajeFault("No hay Documentos relacionados...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btSunat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                Global.MensajeFault("Debe ingresar el numero de RUC.");
                return;
            }

            frmBuscarRucBasico oFrm = new frmBuscarRucBasico(txtRuc.Text, false);
            oFrm.ShowDialog();
        }

        private void btAnticipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtRuc.Tag) == 0 && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    Global.MensajeComunicacion("Debe escoger un cliente.");
                    txtRuc.Focus();
                    return;
                }

                if (DocumentoEmitido.ListaItemsDocumento.Count == Variables.Cero)
                {
                    Global.MensajeComunicacion("Antes de aplicar el anticipo, debe hacer el ingreso de un item.");
                    return;
                }

                frmBusquedaAnticipos oFrm = new frmBusquedaAnticipos(Convert.ToInt32(txtRuc.Tag), txtRazonSocial.Text.Trim());

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oAnticipo != null)
                {
                    String Descripcion = String.Empty;
                    Int32 Item = DocumentoEmitido.ListaItemsDocumento.Max(mx => Convert.ToInt32(mx.Item)) + 1;
                    AnticiposE oAnticipo = oFrm.oAnticipo;

                    MontoAnticipo = oAnticipo.TotalSaldo;
                    Descripcion = String.Format("Aplicación Boleta Anticipada {0}-{1}-{2}", oAnticipo.idDocAnticipo, oAnticipo.numSerieAnticipo, oAnticipo.numDocAnticipo);

                    EmisionDocumentoDetE oDetalleDocumento = new EmisionDocumentoDetE()
                    {
                        Item = String.Format("{0:000}", Item),
                        idAlmacen = 0,
                        idArticulo = oFrm.oAnticipo.idArticulo,
                        codArticulo = oFrm.oAnticipo.codArticulo,
                        nomArticulo = Descripcion,
                        Cantidad = 1M,
                        CantidadFinal = 1M,
                        PrecioSinImpuesto = oFrm.oAnticipo.IgvAnticipo > 0 ? Convert.ToDecimal(oFrm.oAnticipo.TotalAnticipo - Convert.ToDecimal(oFrm.oAnticipo.IgvAnticipo)) : Convert.ToDecimal(oFrm.oAnticipo.SubTotalAnticipo),
                        PrecioConImpuesto = oFrm.oAnticipo.IgvAnticipo > 0 ? Convert.ToDecimal(oFrm.oAnticipo.SubTotalAnticipo + Convert.ToDecimal(oFrm.oAnticipo.IgvAnticipo)) : Convert.ToDecimal(oFrm.oAnticipo.SubTotalAnticipo),
                        subTotal = Convert.ToDecimal(oFrm.oAnticipo.SubTotalAnticipo) * (-1),
                        porDscto1 = 0M,
                        Dscto1 = 0M,
                        porDscto2 = 0M,
                        Dscto2 = 0M,
                        porDscto3 = 0M,
                        Dscto3 = 0M,
                        porIsc = 0M,
                        porIgv = Convert.ToDecimal(oFrm.oAnticipo.IgvSaldo) > 0 ? VariablesLocales.oListaImpuestos[0].Porcentaje : 0M,
                        Isc = 0M,
                        Igv = Convert.ToDecimal(oFrm.oAnticipo.IgvAnticipo) * (-1),
                        Total = Convert.ToDecimal(oFrm.oAnticipo.TotalAnticipo) * (-1),
                        flgIgv = Convert.ToDecimal(oFrm.oAnticipo.IgvSaldo) > 0 ? true : false,
                        indCalculo = true,
                        codLineaVenta = String.Empty,
                        tipArticulo = "AA", //Aplicacióon del anticipo
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy
                    };

                    DocumentoEmitido.ListaItemsDocumento.Add(oDetalleDocumento);
                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);
                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);

                    base.AgregarDetalle();

                    //Para el anticipo...
                    oAnticipo.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oAnticipo.idLocal = VariablesLocales.SesionLocal.IdLocal;
                    oAnticipo.idDocAnticipo = oFrm.oAnticipo.idDocAnticipo;
                    oAnticipo.numSerieAnticipo = oFrm.oAnticipo.numSerieAnticipo;
                    oAnticipo.numDocAnticipo = oFrm.oAnticipo.numDocAnticipo;
                    oAnticipo.idPersona = oFrm.oAnticipo.idPersona;
                    oAnticipo.idDocFactura = cboTipoDocumento.SelectedValue.ToString();
                    oAnticipo.numSerieFactura = cboSeries.SelectedValue.ToString();
                    oAnticipo.numDocFactura = txtNumDocumento.Text;
                    oAnticipo.idMoneda = oFrm.oAnticipo.idMoneda;
                    oAnticipo.idArticulo = oFrm.oAnticipo.idArticulo;
                    oAnticipo.SubTotalAnticipo = oFrm.oAnticipo.SubTotalAnticipo;
                    oAnticipo.IgvAnticipo = oFrm.oAnticipo.IgvAnticipo;
                    oAnticipo.TotalAnticipo = oFrm.oAnticipo.TotalAnticipo;
                    oAnticipo.SubTotalSaldo = oFrm.oAnticipo.SubTotalSaldo;
                    oAnticipo.IgvSaldo = oFrm.oAnticipo.IgvSaldo;
                    oAnticipo.TotalSaldo = oFrm.oAnticipo.TotalSaldo;
                    oAnticipo.Aplicado = true;
                    oAnticipo.Tipo = "D";
                    oAnticipo.Opcion = (Int32)EnumOpcionGrabar.Insertar;

                    if (DocumentoEmitido.ListaAnticipos == null)
                    {
                        DocumentoEmitido.ListaAnticipos = new List<AnticiposE>();
                    }

                    DocumentoEmitido.ListaAnticipos.Add(oAnticipo);
                    lblAnticipos.Items.Add(oAnticipo.idDocAnticipo + "-" + oAnticipo.numSerieAnticipo + "-" + oAnticipo.numDocAnticipo);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkAnticipo_CheckedChanged(object sender, EventArgs e)
        {
            btAnticipos.Enabled = chkAnticipo.Checked;
            btAnticipo.Enabled = !chkAnticipo.Checked;

            if (!chkAnticipo.Checked)
            {
                List<EmisionDocumentoDetE> oListaDetalle = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);

                foreach (EmisionDocumentoDetE item in oListaDetalle)
                {
                    if (item.tipArticulo == "AN")
                    {
                        DocumentoEmitido.ListaItemsDocumento.Remove(item);
                    }
                }

                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                bsDetalleDocumento.ResetBindings(false);
            }
        }

        private void btBuscarDireccion_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtRuc.Tag) == 0)
            {
                List<PersonaDireccionE> oListaDirecciones = AgenteMaestro.Proxy.ListarPersonaDireccion(Convert.ToInt32(txtRuc.Tag));
                frmBuscarSucursalCliente oFrm = new frmBuscarSucursalCliente(oListaDirecciones);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDireccion != null)
                {
                    txtIdSucursal.Text = oFrm.oDireccion.IdDireccion.ToString();
                    txtDireccion.Text = oFrm.oDireccion.DireccionCompleta;
                } 
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
                    cboDivision.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idDivision);
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

        private void btDocumentos_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoEmitido.ListaCanjeGuias != null && DocumentoEmitido.ListaCanjeGuias.Count > 0)
                {
                    frmDocRelacionados oFrm = new frmDocRelacionados(DocumentoEmitido.ListaCanjeGuias);
                    oFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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
                    CalcularDetraccion(DocumentoEmitido.ListaItemsDocumento);
                    //Se cambio para que los botones de Agregar y eliminar fila se mantengan bloqueados, solo se sustrajo las variables globales
                    //base.AgregarDetalle();
                    bFlag = true;
                    Modificacion = true;
                    /*****************/
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
                    CalcularDetraccion(DocumentoEmitido.ListaItemsDocumento);
                    //Se cambio para que los botones de Agregar y eliminar fila se mantengan bloqueados, solo se sustrajo las variables globales
                    //base.AgregarDetalle();
                    bFlag = true;
                    Modificacion = true;
                    /*****************/
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAnticipos_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAnticipo.Checked)
                {
                    frmEmisionDocumentoDet oFrm = new frmEmisionDocumentoDet(dtFecEmision.Value.Date, 1, "A"); //A = Anticipo

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
                        ItemDetalle.tipArticulo = "AN";
                        DocumentoEmitido.ListaItemsDocumento.Add(ItemDetalle);
                        bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                        bsDetalleDocumento.ResetBindings(false);

                        SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                        //Se cambio para que los botones de Agregar y eliminar fila se mantengan bloqueados, solo se sustrajo las variables globales
                        //base.AgregarDetalle();
                        bFlag = true;
                        Modificacion = true;
                        /*****************/
                    }
                    else
                    {
                        chkAnticipo.Checked = false;
                    }
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
                        Int32 numItem = Variables.ValorUno;
                        EmisionDocumentoDetE oItem = (EmisionDocumentoDetE)bsDetalleDocumento.Current;

                        if (oItem.tipArticulo != "AA")
                        {
                            DocumentoEmitido.ListaItemsDocumento.RemoveAt(bsDetalleDocumento.Position);

                            foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                            {
                                item.Item = String.Format("{0:000}", numItem);
                                numItem++;

                                if (item.Total < 0)
                                {
                                    MontoAnticipo = 0;
                                }
                            }

                            bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                            bsDetalleDocumento.ResetBindings(false);
                            SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                            CalcularDetraccion(DocumentoEmitido.ListaItemsDocumento);

                            //Se cambio para que los botones de Agregar y eliminar fila se mantengan bloqueados, solo se sustrajo las variables globales
                            //base.QuitarDetalle();
                            bFlag = true;
                            Modificacion = true;
                            /*****************/
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

        private void btQuitarAnticipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAnticipos.SelectedItem != null)
                {
                    String Documento = lblAnticipos.SelectedItem.ToString();
                    List<EmisionDocumentoDetE> oListaDocumento = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
                    List<AnticiposE> oListaAnticipos = new List<AnticiposE>(DocumentoEmitido.ListaAnticipos);

                    foreach (EmisionDocumentoDetE item in oListaDocumento)
                    {
                        if (item.tipArticulo == "AA" && item.nomArticulo.Contains(Documento))
                        {
                            DocumentoEmitido.ListaItemsDocumento.Remove(item);
                        }
                    }

                    if (DocumentoEmitido.AnticiposEliminados == null)
                    {
                        DocumentoEmitido.AnticiposEliminados = new List<AnticiposE>();
                    }

                    foreach (AnticiposE item in oListaAnticipos)
                    {
                        if (item.idDocAnticipo + "-" + item.numSerieAnticipo + "-" + item.numDocAnticipo == Documento)
                        {
                            DocumentoEmitido.ListaAnticipos.Remove(item);

                            //Agregando un item para la eliminación del anticipo
                            item.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                            item.idLocal = VariablesLocales.SesionLocal.IdLocal;
                            item.idPersona = Convert.ToInt32(txtRuc.Tag);
                            item.idDocFactura = cboTipoDocumento.SelectedValue.ToString();
                            item.numSerieFactura = cboSeries.SelectedValue.ToString();
                            item.numDocFactura = txtNumDocumento.Text.Trim();

                            DocumentoEmitido.AnticiposEliminados.Add(item);
                        }
                    }

                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);
                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);

                    //Limpiando la lista...
                    lblAnticipos.Items.Clear();

                    foreach (AnticiposE item in DocumentoEmitido.ListaAnticipos)
                    {
                        item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                        lblAnticipos.Items.Add(item.idDocAnticipo + "-" + item.numSerieAnticipo + "-" + item.numDocAnticipo);
                    }

                    //Se cambio para que los botones de Agregar y eliminar fila se mantengan bloqueados, solo se sustrajo las variables globales
                    //base.QuitarDetalle();
                    bFlag = true;
                    Modificacion = true;
                    /*****************/
                }
                else
                {
                    Global.MensajeComunicacion("Debe escoger un item.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btPagos_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocumentoEmitido.ListaItemsDocumento.Count == 0)
                {
                    Global.MensajeComunicacion("Debe ingresar Items antes de generar la cancelación.");
                    return;
                }

                EmisionDocumentoE oDocumento = new EmisionDocumentoE()
                {
                    idDocumento = cboTipoDocumento.SelectedValue.ToString(),
                    numSerie = cboSeries.SelectedValue.ToString(),
                    numDocumento = txtNumDocumento.Text,
                    fecEmision = dtFecEmision.Value.ToString("yyyyMMdd"),
                    idMoneda = cboMonedas.SelectedValue.ToString(),
                    totTotal = Convert.ToDecimal(lblTotal.Text),
                    tipCambio = Convert.ToDecimal(txtTica.Text),
                    indEstado = DocumentoEmitido.indEstado
                };

                frmCancelaciones oFrm = new frmCancelaciones(oDocumento, (Int32)EnumTipoCondicionVenta.FacBol, Convert.ToInt32(txtIdCondicion.Text), DocumentoEmitido.ListaCancelaciones);

                if (DocumentoEmitido.indEstado == "E")
                {
                    oFrm.ShowDialog();
                }
                else
                {
                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.ListaCancelaciones != null && oFrm.ListaCancelaciones.Count > 0)
                    {
                        btQuitarCancelacion.Enabled = true;
                        DocumentoEmitido.indCancelacion = true;
                        DocumentoEmitido.ListaCancelaciones = new List<EmisionDocumentoCancelacionE>(oFrm.ListaCancelaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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

        private void tsmiBonificacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsDetalleDocumento.Current != null)
                {
                    EmisionDocumentoDetE oItemBonificacion = Colecciones.CopiarEntidad<EmisionDocumentoDetE>((EmisionDocumentoDetE)bsDetalleDocumento.Current);

                    if (oItemBonificacion != null)
                    {
                        String Cantidad = InputDialog.mostrar("Ingrese la cantidad para la bonificación", "Bonificación", 1);

                        if (!String.IsNullOrEmpty(Cantidad.Trim()))
                        {
                            //Actualizando datos de la linea real
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Cantidad = ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Cantidad - Convert.ToDecimal(Cantidad);

                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).CantidadUnit = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).CantidadFinal = Convert.ToDecimal(((EmisionDocumentoDetE)bsDetalleDocumento.Current).Cantidad);
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Dscto1 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Dscto2 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Dscto3 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Comision = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).porDscto1 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).porDscto2 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).porDscto3 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).porComision = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).CantidadAtendida = Convert.ToDecimal(((EmisionDocumentoDetE)bsDetalleDocumento.Current).Cantidad);
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).porDscto3 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).porDscto3 = 0;
                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).subTotal = ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Cantidad * ((EmisionDocumentoDetE)bsDetalleDocumento.Current).PrecioSinImpuesto;

                            if (((EmisionDocumentoDetE)bsDetalleDocumento.Current).flgIgv)
                            {
                                ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Igv = ((EmisionDocumentoDetE)bsDetalleDocumento.Current).subTotal * (((EmisionDocumentoDetE)bsDetalleDocumento.Current).porIgv / 100);
                            }
                            else
                            {
                                ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Igv = 0;
                            }

                            ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Total = ((EmisionDocumentoDetE)bsDetalleDocumento.Current).subTotal + ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Igv;

                            //Actualizando Datos del Item de Bonificación
                            int Item = Convert.ToInt32(((List<EmisionDocumentoDetE>)bsDetalleDocumento.List).Max(x => x.Item)) + 1;

                            oItemBonificacion.Item = String.Format("{0:000}", Item);
                            oItemBonificacion.Cantidad = Convert.ToDecimal(Cantidad);
                            oItemBonificacion.CantidadUnit = 0;
                            oItemBonificacion.CantidadFinal = Convert.ToDecimal(Cantidad);
                            oItemBonificacion.Dscto1 = 0;
                            oItemBonificacion.Dscto2 = 0;
                            oItemBonificacion.Dscto3 = 0;
                            oItemBonificacion.Comision = 0;
                            oItemBonificacion.porDscto1 = 0;
                            oItemBonificacion.porDscto2 = 0;
                            oItemBonificacion.porDscto3 = 0;
                            oItemBonificacion.porComision = 0;
                            oItemBonificacion.CantidadAtendida = Convert.ToDecimal(Cantidad);
                            oItemBonificacion.porDscto3 = 0;
                            oItemBonificacion.porDscto3 = 0;
                            oItemBonificacion.subTotal = oItemBonificacion.Cantidad * oItemBonificacion.PrecioSinImpuesto;

                            if (oItemBonificacion.flgIgv)
                            {
                                oItemBonificacion.Igv = oItemBonificacion.subTotal * (oItemBonificacion.porIgv / 100);
                            }
                            else
                            {
                                oItemBonificacion.Igv = 0;
                            }

                            oItemBonificacion.Total = oItemBonificacion.subTotal + oItemBonificacion.Igv;
                            oItemBonificacion.indCalculo = false;

                            bsDetalleDocumento.Add(oItemBonificacion);
                            bsDetalleDocumento.ResetBindings(false);

                            SumarTotal((List<EmisionDocumentoDetE>)bsDetalleDocumento.List);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDocumentoRef_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumentoRef.SelectedValue.ToString() != Variables.Cero.ToString())
                {
                    txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNumDocumentoRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtSerieRef.Focus();
                }
                else
                {
                    txtSerieRef.Text = String.Empty;
                    txtNumDocumentoRef.Text = String.Empty;
                    txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNumDocumentoRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }

                if (cboDocumentoRef.SelectedValue.ToString() == "OC")
                {
                    txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoDetraccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcularDetraccionManual(DocumentoEmitido.ListaItemsDocumento);
        }
        
        private void btNuevoNumControl_Click(object sender, EventArgs e)
        {
            try
            {
                List<EmisionDocumentoDetE> oListaTemp = null;

                if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                {
                    oListaTemp = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
                }

                frmDetallePorFacturaXEmision oFrm = new frmDetallePorFacturaXEmision(dtFecEmision.Value, DocumentoEmitido.ListaItemsDocumento, (NumControlDetE)cboSeries.SelectedItem, oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaReal != null && oFrm.oListaReal.Count > 0)
                {
                    Int32 Item = 0;

                    if (DocumentoEmitido.ListaItemsDocumento.Count == Variables.Cero)
                    {
                        Item = Variables.ValorUno;
                    }
                    else
                    {
                        Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
                    }

                    foreach (EmisionDocumentoDetE item in oFrm.oListaReal)
                    {
                        item.Item = String.Format("{0:000}", Item);
                        DocumentoEmitido.ListaItemsDocumento.Add(item);
                        Item++;
                    }

                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);

                    SumarTotal(DocumentoEmitido.ListaItemsDocumento);
                    dgvDetalle.AutoResizeColumns();

                    base.AgregarDetalle();
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
                                Int32 resp = AgenteVentas.Proxy.ActualizarNroDocAsociado(DocumentoEmitido.idEmpresa, DocumentoEmitido.idLocal, DocumentoEmitido.idDocumento, DocumentoEmitido.numSerie, DocumentoEmitido.numDocumento, oFrm.oPedido.idPedido, VariablesLocales.SesionUsuario.Credencial, chkAnticipo.Checked, dtFecEmision.Value.Date);

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

        private void btQuitarCancelacion_Click(object sender, EventArgs e)
        {
            DocumentoEmitido.indCancelacion = false;
            DocumentoEmitido.ListaCancelaciones = null;
            btQuitarCancelacion.Enabled = false;
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrWhiteSpace(txtCodBarras.Text))
                    {
                        Int32 Item = Variables.ValorUno;
                        ArticuloServE articulo = AgenteMaestro.Proxy.ObtenerArticuloPorCodBarra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodBarras.Text.Trim());
                        EmisionDocumentoDetE ItemDetalle = null;

                        if (articulo != null)
                        {
                            if (DocumentoEmitido.ListaItemsDocumento == null)
                            {
                                DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                            }

                            if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                            {
                                Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
                            }

                            if (VariablesLocales.oVenParametros != null)
                            {
                                if (VariablesLocales.oVenParametros.indListaPrecio)
                                {
                                    Int32 idListaPrecio = Convert.ToInt32(((NumControlDetE)cboTipoDocumento.SelectedItem).ListaPrecio);
                                    ListaPrecioItemE ListaPrecioItem = AgenteVentas.Proxy.ObtenerListaPrecioItemArticulo(VariablesLocales.SesionLocal.IdEmpresa, idListaPrecio, articulo.idArticulo);
                                    String CodArt = txtCodBarras.Text.Substring(0, txtCodBarras.TextLength - 2);
                                    Decimal Talla = Convert.ToDecimal(txtCodBarras.Text.Substring(txtCodBarras.TextLength - 2, 2));


                                    if (ListaPrecioItem != null)
                                    {
                                        ItemDetalle = new EmisionDocumentoDetE()
                                        {
                                            idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                            idLocal = VariablesLocales.SesionLocal.IdLocal,
                                            idDocumento = cboTipoDocumento.SelectedValue.ToString(),
                                            numSerie = cboSeries.SelectedValue.ToString(),
                                            numDocumento = txtNumDocumento.Text.Trim(),
                                            Item = String.Format("{0:000}", Item),
                                            idAlmacen = Convert.ToInt32(((NumControlDetE)cboTipoDocumento.SelectedItem).idAlmacen),
                                            idArticulo = articulo.idArticulo,
                                            nomArticulo = articulo.nomArticulo,
                                            codArticulo = CodArt,
                                            Lote = Talla.ToString("N2"),
                                            Cantidad = 1,
                                            CantidadUnit = 1,
                                            CantidadFinal = 1,
                                            PrecioConImpuesto = ListaPrecioItem.PrecioVenta,
                                            PrecioSinImpuesto = ListaPrecioItem.PrecioBruto,
                                            Dscto1 = ListaPrecioItem.MontoDscto1,
                                            Dscto2 = ListaPrecioItem.MontoDscto2,
                                            Dscto3 = ListaPrecioItem.MontoDscto3,
                                            Comision = 0,
                                            porDscto1 = ListaPrecioItem.PorDscto1,
                                            porDscto2 = ListaPrecioItem.PorDscto2,
                                            porDscto3 = ListaPrecioItem.PorDscto3,
                                            porComision = 0,
                                            CantidadAtendida = 1,
                                            flgIgv = ListaPrecioItem.flgigv,
                                            Isc = ListaPrecioItem.isc,
                                            Igv = ListaPrecioItem.igv,
                                            subTotal = ListaPrecioItem.PrecioValorVenta,
                                            Total = ListaPrecioItem.PrecioVenta,
                                            porIsc = ListaPrecioItem.porisc,
                                            porIgv = ListaPrecioItem.porigv,
                                            idUnidadMedida = articulo.codUniMedAlmacen,
                                            numOrdenProd = null,
                                            TipoImpSelectivo = "N",
                                            Stock = 0,
                                            TipoLista = String.Empty,
                                            codLineaVenta = String.Empty,
                                            Contiene = 0,
                                            Capacidad = 0,
                                            PesoUnitario = 0,
                                            idDocumentoRef = String.Empty,
                                            serDocumentoRef = String.Empty,
                                            numDocumentoRef = String.Empty,
                                            fecDocumentoRef = null,
                                            TotalRef = null,
                                            idCampana = null,
                                            indPercepcion = false,
                                            idListaPrecio = idListaPrecio,
                                            PesoBrutoCad = String.Empty,
                                            indCalculo = true,
                                            tipArticulo = "AR",
                                            indDetraccion = articulo.indDetraccion,
                                            tipDetraccion = articulo.tipDetraccion,
                                            TasaDetraccion = 0,
                                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial
                                        };

                                        DocumentoEmitido.ListaItemsDocumento.Add(ItemDetalle);
                                        bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                                        bsDetalleDocumento.ResetBindings(false);
                                    }
                                    else
                                    {
                                        Global.MensajeAdvertencia("El articulo no existe en la Lista de Precio que esta asociada al N° de Serie");
                                    }
                                }
                                else
                                {

                                }
                            } 
                        }
                        else
                        {
                            Global.MensajeAdvertencia("El código de barras escaneado no existe en el maestro de articulos.");
                        }
                    }
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
