using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas
{
    public partial class frmEmisionGuiasUf : FrmMantenimientoBase
    {

        #region Constructores

		public frmEmisionGuiasUf()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvGuias, true);
            LlenarAyuda();

            if (VariablesLocales.SesionUsuario.Empresa.indCalzado)
            {
                dgvGuias.Columns["Lote"].HeaderText = "Talla";
                btNuevoNumControl.Visible = true;
            }
        }

        //Edición
        public frmEmisionGuiasUf(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero, List<NumControlDetE> ListaDetalle)
            : this()
        {
            DocumentoEmitido = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            //DocumentoEmitido.ListaItemsDocumento = AgenteVentas.Proxy.ObtenerEmisionDocumentoDet2(idEmpresa, idLocal, idDocumento, Serie, Numero);
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

        //Nuevo
        public frmEmisionGuiasUf(List<NumControlDetE> ListaDetalle)
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
        String RutaGeneral = String.Empty;
        Int16 Opcion;
        //Int32 idControlTmp = 0;
        Boolean HabilitaBotones = true;
        Decimal totdsc1 = 0;
        Decimal totdsc2 = 0;
        Decimal totdsc3 = 0;
        Int32? CanalVenta = Variables.Cero;
        //Boolean indAlmacen = false;
        Boolean Bloqueo = true;
        Int32 AlmacenTmp = 0;

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
            List<DocumentosE> oListaRef = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral)
            {
                new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione }
            };

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoRef, (from x in oListaRef orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);
            cboDocumentoRef.SelectedValue = Variables.Cero.ToString();

            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20452630886") //Solo para el Fundo San Miguel
            {
                //Razón de exoneración del IGV
                List<ParTabla> oListaExoneracion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPAFEIGV");
                ParTabla oItem = new ParTabla() { IdParTabla = Variables.Cero, desTemporal = Variables.Seleccione };
                oListaExoneracion.Add(oItem);
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
            Global.CrearToolTip(btNuevoCliente, "Agregar Nuevo Cliente.");
            Global.CrearToolTip(btBuscarVendedor, "Buscar vendedor.");
            Global.CrearToolTip(btBuscarTipoTraslado, "Buscar los motivos de traslado.");
            Global.CrearToolTip(btBuscarOtraDireccion, "Buscar otro almacén, otra sucursal o dirección.");
        }

        void ValoresPorDefecto()
        {
            NumControlDetE Detalle = (NumControlDetE)cboSeries.SelectedItem;//AgenteVentas.Proxy.ObtenerNumControlDetPorIdDocumento(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 
                                        //VariablesLocales.SesionLocal.IdLocal, idControlTmp, cboTipoDocumento.SelectedValue.ToString(), Serie);
            if (Detalle != null)
            {
                cboMonedas.SelectedValue = Detalle.idMoneda;
                txtNumDocumento.MaxLength = Convert.ToInt32(Detalle.cantDigNumero);
                txtNumDocumento.Text = DevolverNumeroCorrelativo(Detalle.numCorrelativo, Convert.ToInt32(Detalle.cantDigNumero));
                txtIdTipoTraslado.Text = Detalle.idTipTraslado == 0 ? String.Empty : Convert.ToInt32(Detalle.idTipTraslado).ToString("00");
                //txtEmpresaPartida.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                //txtPuntoPartida.Text = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta; //Detalle.PuntoPartida;
                txtDesTraslado.Text = Detalle.idTipTraslado == 0 ? String.Empty : Detalle.desTipoTraslado;
                txtPuntoLlegada.Text = Detalle.PuntoLlegada;
                cboEsGuia.SelectedValue = Detalle.EsGuia;

                if (Detalle.idAlmacen != null)
                {
                    AlmacenTmp = Detalle.idAlmacen.Value;
                }

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
            //DocumentoEmitido.AfectoDetraccion = false;
            DocumentoEmitido.Glosa = txtGlosa.Text;

            //Recepción Documento
            DocumentoEmitido.indRecepcion = false;
            DocumentoEmitido.fecRecepcion = (Nullable<DateTime>)null;

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
            DocumentoEmitido.idPersona = Convert.ToInt32(txtRuc.Tag) == 0 ? (int?)null : Convert.ToInt32(txtRuc.Tag);
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
            DocumentoEmitido.serDocumentoRef = txtSerieRef.Text.Trim();
            DocumentoEmitido.numDocumentoRef = txtNumDocumentoRef.Text.Trim();
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

            DocumentoEmitido.nroDocAsociado = Convert.ToInt32(txtNroAsociado.Tag);
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
            pnlVendedor.Enabled = Flag;
            pnlConductor.Enabled = Flag;
            txtGlosa.Enabled = Flag;
            btAgregarNota.Enabled = Flag;
            btOrdenProduccion.Enabled = Flag;
            Bloqueo = Flag;
        }

        void BloquearPanelComprobante(Boolean Flag)
        {
            cboTipoDocumento.Enabled = Flag;
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
                //dgvGuias
                DocumentoEmitido.ListaItemsDocumento[e.RowIndex] = ItemDet;
                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                bsDetalleDocumento.ResetBindings(false);

                SumarTotal(DocumentoEmitido.ListaItemsDocumento);
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

        #endregion Procedimientos de Usuario

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            if (DocumentoEmitido == null)
            {
                Opcion = (Int16)EnumOpcionGrabar.Insertar;

                DocumentoEmitido = new EmisionDocumentoE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                txtRuc.Tag = 0;
                txtNroAsociado.Tag = 0;
                BloquearPanelComprobante(true);
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                dtFecEmision_ValueChanged(null, null);
                txtEmpresaPartida.Text = VariablesLocales.SesionUsuario.Empresa.RazonSocial;
                txtPuntoPartida.Text = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                Text = "Guia (Nuevo)";
            }
            else
            {
                Opcion = Convert.ToInt16(EnumOpcionGrabar.Actualizar);
                dtFecEmision.ValueChanged -= new EventHandler(dtFecEmision_ValueChanged);
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
                txtRuc.Tag = DocumentoEmitido.idPersona;
                txtRuc.Text = DocumentoEmitido.numRuc;
                txtRazonSocial.Text = DocumentoEmitido.RazonSocial;
                txtDireccion.Text = DocumentoEmitido.Direccion;
                txtIdVendedor.Text = DocumentoEmitido.idVendedor == 0 ? String.Empty : DocumentoEmitido.idVendedor.ToString();
                txtVendedor.Text = DocumentoEmitido.Vendedor;

                //Documento de referencia
                if (!String.IsNullOrEmpty(DocumentoEmitido.idDocumentoRef.Trim()))
                {
                    cboDocumentoRef.SelectedValue = DocumentoEmitido.idDocumentoRef.ToString();
                    txtSerieRef.Text = DocumentoEmitido.serDocumentoRef;
                    txtNumDocumentoRef.Text = DocumentoEmitido.numDocumentoRef;
                }

                //Motivo de Traslado
                txtIdTipoTraslado.Text = DocumentoEmitido.idTipTraslado == 0 ? String.Empty : Convert.ToInt32(DocumentoEmitido.idTipTraslado).ToString();
                txtDesTraslado.Text = DocumentoEmitido.desTraslado;
                txtOtroTipoTraslado.Text = DocumentoEmitido.OtroTipoTraslado;

                //Tipo de Traslados - Transferencias...
                if (DocumentoEmitido.idTipTraslado == 6 || DocumentoEmitido.idTipTraslado == 7)
                {
                    txtIdSucursal.Text = DocumentoEmitido.idAlmacenDestino == 0 ? String.Empty : DocumentoEmitido.idAlmacenDestino.ToString();
                    lblAlmacen.Text = "Almacen";
                }
                else //el resto de tipos de transferencias
                {
                    txtIdSucursal.Text = DocumentoEmitido.idSucursalCliente == 0 ? String.Empty : DocumentoEmitido.idSucursalCliente.ToString();
                    lblAlmacen.Text = "Llegada";
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

                CanalVenta = DocumentoEmitido.idCanalVenta;
                SumarTotal(DocumentoEmitido.ListaItemsDocumento);

                Text = "Guia (" + DocumentoEmitido.numSerie + "-" + DocumentoEmitido.numDocumento + ")";

                dtFecEmision.ValueChanged += new EventHandler(dtFecEmision_ValueChanged);
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
                Bloqueo = false;
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
            List<EmisionDocumentoDetE> oListaTemp = null;
            
            if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
            {
                oListaTemp = new List<EmisionDocumentoDetE>(DocumentoEmitido.ListaItemsDocumento);
            }

            frmDetallePedidoNacional oFrm = new frmDetallePedidoNacional(dtFecEmision.Value.Date, oListaTemp, AlmacenTmp);

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

        void InsertarExcel(String Ruta)
        {
            FileInfo oFi_ = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(oFi_))
            {
                //Entidad
                EmisionDocumentoDetE ItemDetalle = null;
                Int32 Item = Variables.ValorUno;
                //Excel
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                //Para el recorrido del excel
                Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;
                String Mensaje = String.Empty;

                //Recorriendo la hoja excel hasta el total de fila obtenido...
                for (int f = 2; f <= totFilasExcel; f++)
                {
                    if (oHoja.Cells[f, 1].Value.ToString() != String.Empty)
                    {
                        ArticuloServE articulo = AgenteMaestro.Proxy.ObtenerArticuloPorCodBarra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, (oHoja.Cells[f, 1].Value).ToString());

                        if (DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
                        {
                            Item = Convert.ToInt32(DocumentoEmitido.ListaItemsDocumento.Max(mx => mx.Item)) + 1;
                        }

                        if (articulo != null)
                        {

                            Int32 idListaPrecio = Convert.ToInt32(((NumControlDetE)cboTipoDocumento.SelectedItem).ListaPrecio);
                            ListaPrecioItemE ListaPrecioItem = AgenteVentas.Proxy.ObtenerListaPrecioItemArticulo(VariablesLocales.SesionLocal.IdEmpresa, idListaPrecio, articulo.idArticulo);
                            Decimal Talla = Convert.ToDecimal(oHoja.Cells[f, 1].Value.ToString().Substring(8,2));

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
                                    codArticulo = articulo.codArticulo,
                                    Lote = Talla.ToString("N2"),
                                    Cantidad = Convert.ToInt32(oHoja.Cells[f, 2].Value),
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
                            }
                            else
                            {
                                Mensaje = (oHoja.Cells[f, 1].Value).ToString().Substring(8, 2);
                                Global.MensajeComunicacion("Codigo Serie " + Mensaje + " No Encontrado Vuelva a Cargar El Excel");
                                btExaminar.Enabled = true;
                                btAgregar.Enabled = false;
                                break;
                            }
                        }
                        else
                        {
                            Mensaje = (oHoja.Cells[f, 1].Value).ToString().Substring(0, 8);
                            Global.MensajeComunicacion("Codigo " + Mensaje + " No Encontrado Vuelva a Cargar El Excel");
                            btExaminar.Enabled = true;
                            btAgregar.Enabled = false;
                            break;
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion(" Codigo Barra No Existente Vuelva a Cargar El Excel");
                        btExaminar.Enabled = true;
                        btAgregar.Enabled = false;
                        break;
                    }
                }
                if (Mensaje == String.Empty)
                {
                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);
                }
            }
        }

        void ExportarExcel(String Ruta)
        {

            String NombrePestaña = String.Empty;
            NombrePestaña = " REPORTE DETALLE GUIA DE EMISION ";

            if (File.Exists(Ruta)) File.Delete(Ruta);
            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 1;

                    #region Cabeceras del Detalle

                    oHoja.Cells[InicioLinea, 1].Value = " Código Barra";
                    oHoja.Cells[InicioLinea, 2].Value = " Cantidad ";
                    oHoja.Cells[InicioLinea, 3].Value = " Costo Unit. ";

                    for (int i = 1; i <= 3; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;


                    #endregion

                    Decimal IMPCOSTO = 0;

                    foreach (EmisionDocumentoDetE item in DocumentoEmitido.ListaItemsDocumento)
                    {
                        oHoja.Cells[InicioLinea, 1].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 1].Value = item.codArticulo.ToString() + item.Lote.Substring(0, 2);
                        oHoja.Cells[InicioLinea, 2].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 2].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 3].Style.Font.SetFromFont(new System.Drawing.Font("Arial", 8, FontStyle.Regular));
                        oHoja.Cells[InicioLinea, 3].Value = IMPCOSTO;

                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;
                    }

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + "Formato De Salida";
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = "Formato De Salida";
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();
                }
            }
        }

        #endregion Procedimiento Heredados

        #region Eventos

        private void frmEmisionGuiasUf_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            Nuevo();
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

            //idControlTmp = ((NumControlDetE)cboTipoDocumento.SelectedItem).idControl;
            ComboHelper.LlenarCombos<NumControlDetE>(cboSeries, ListaDetalle, "Serie", "Serie");
            cboSeries_SelectionChangeCommitted(new object(), new EventArgs());
        }

        private void cboSeries_SelectionChangeCommitted(object sender, EventArgs e)
        {
             if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                //String Serie = Convert.ToString(cboSeries.SelectedValue);
                ValoresPorDefecto();
                //cboEsGuia_SelectionChangeCommitted(new Object(), new EventArgs());
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
                    txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNumDocumentoRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    //dtpFecReferencia.Enabled = true;
                    txtSerieRef.Focus();
                }
                else
                {
                    txtSerieRef.Text = String.Empty;
                    txtNumDocumentoRef.Text = String.Empty;
                    txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNumDocumentoRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
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
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
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

                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        txtPuntoLlegada.Text = oListaPersonas[0].DireccionCompleta;
                        txtCanalVenta.Text = oListaPersonas[0].idCanalVenta.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtPuntoLlegada.Text = String.Empty;
                        txtCanalVenta.Text = String.Empty;
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

                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtDireccion.Text = oListaPersonas[0].DireccionCompleta;
                        txtPuntoLlegada.Text = oListaPersonas[0].DireccionCompleta;
                        txtCanalVenta.Text = oListaPersonas[0].idCanalVenta.ToString();
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtDireccion.Text = String.Empty;
                        txtPuntoLlegada.Text = String.Empty;
                        txtCanalVenta.Text = String.Empty;
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
                DocumentoEmitido.indAlmacen = oFrm.oTraslado.indAlmacen;

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
                        txtIdSucursal.Text = String.Empty;
                        txtPuntoLlegada.Text = String.Empty;
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
                if ((txtIdTipoTraslado.Text == "6" || txtIdTipoTraslado.Text == "7") && DocumentoEmitido.indAlmacen)
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
                    if (Convert.ToInt32(txtRuc.Tag) == 0)
                    {
                        Global.MensajeFault("Debe escoger primero al cliente.");
                        return;
                    }

                    List<PersonaDireccionE> oListaDirecciones = AgenteMaestro.Proxy.ListarPersonaDireccion(Convert.ToInt32(txtRuc.Tag));

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

                    cboDivision.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idDivision);
                    cboEstablecimiento.Focus();
                    cboEstablecimiento.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idEstablecimiento);

                    if (cboEstablecimiento.SelectedValue != null)
                    {
                        cboEstablecimiento_SelectionChangeCommitted(new Object(), new EventArgs());
                        cboZona.SelectedValue = Convert.ToInt32(oFrm.oVendedor.idZona);
                    }

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
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Text = String.Empty;
            txtRuc.Tag = 0;
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

                    txtIdCondicion.Text = idCondicion.ToString();
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

        private void btBuscarDireccionEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarDireccion oFrm = new frmBuscarDireccion();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oDir != null)
                {
                    txtPuntoPartida.Text = oFrm.oDir.Direccion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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
                    dgvGuias.AutoResizeColumns();

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

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Archivos Excel (.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    btExaminar.Enabled = false;
                    btAgregar.Enabled = true;
                }
                else
                {
                    btExaminar.Enabled = true;
                    btAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            InsertarExcel(txtRuta.Text);
            btExaminar.Enabled = true;
            btAgregar.Enabled = false;
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsDetalleDocumento == null || bsDetalleDocumento.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "FormatoSalida", "Archivos Excel (*.xlsx)|*.xlsx");

                ExportarExcel(RutaGeneral);


            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Eventos

    }
}
