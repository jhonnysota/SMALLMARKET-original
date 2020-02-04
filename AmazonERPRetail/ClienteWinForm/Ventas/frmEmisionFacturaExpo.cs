using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Generales;
//using Entidades.Produccion;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmEmisionFacturaExpo : FrmMantenimientoBase
    {

        #region Constructores

        public frmEmisionFacturaExpo()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvFacturaExpo, true);
            //LlenarCombos();
            LlenarAyuda();
            AnchoColumnas();
            FormatoGridGastos();
            AnchoColumnasGastos();    
        }

        public frmEmisionFacturaExpo(Int32 idEmpresa, Int32 idLocal, String idDocumento, String Serie, String Numero, List<NumControlDetE> ListaDetalle)
            :this()
        {
            DocumentoEmitido = AgenteVentas.Proxy.RecuperarDocumentoCompleto(idEmpresa, idLocal, idDocumento, Serie, Numero);
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);

            if (DocumentoEmitido.EnviadoSunat)
            {
                Global.MensajeFault("Este documento ha sido enviado a sunat, no puede hacer modificaciones.");
                dgvFacturaExpo.ClearSelection();
                BloquearPaneles(false);
                HabilitaBotones = false;
            }

            if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.B.ToString())
            {
                Global.MensajeFault("Este documento ha sido Anulado, no puede hacer ninguna modificación.");
                dgvFacturaExpo.ClearSelection();
                BloquearPaneles(false);
                HabilitaBotones = false;
            }

            if (DocumentoEmitido.indEstado == EnumEstadoDocumentos.E.ToString())
            {
                Global.MensajeFault("Este documento ha sido Emitido, no puede hacer ninguna modificación.");
                dgvFacturaExpo.ClearSelection();
                BloquearPaneles(false);
                HabilitaBotones = false;
            }
        }

        public frmEmisionFacturaExpo(List<NumControlDetE> ListaDetalle)
            :this()
        {
            ListaDocumentosControl = new List<NumControlDetE>(ListaDetalle);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        //ProduccionServiceAgent AgenteProduccion { get { return new ProduccionServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        EmisionDocumentoE DocumentoEmitido = null;
        //List<OrdenProduccionDetE> ListaOp = null;
        List<NumControlDetE> ListaDocumentosControl = null;

        Int16 Opcion;
        Int32 idControlTmp = 0;
        Boolean HabilitaBotones = true;

        #endregion

        #region Procedimientos de Usuario

        void NuevoRegistro()
        {
            if (DocumentoEmitido == null)
            {
                Opcion = (Int16)EnumOpcionGrabar.Insertar;

                DocumentoEmitido = new EmisionDocumentoE();
                DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();                
                DocumentoEmitido.ListaCanjeGuias = new List<CanjeGuiasE>();
                DocumentoEmitido.ListaGastosExportacion = new List<EmisionDocumentoExportaE>();

                DocumentoEmitido.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                DocumentoEmitido.idLocal = VariablesLocales.SesionLocal.IdLocal;
                DocumentoEmitido.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                DocumentoEmitido.FechaRegistro = VariablesLocales.FechaHoy;
                DocumentoEmitido.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                DocumentoEmitido.FechaModificacion = VariablesLocales.FechaHoy;
                
                pnlComprobante.Enabled = true;
                txtTica.Text = VariablesLocales.TipoCambioDelDia.valVenta.ToString();
                cboEsGuia.SelectedValue = EnumEsGuia.E.ToString();
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
            }
            else
            {
                Int32 idVendedor = 0;
                Int32 idSucursal = 0;

                Opcion = Convert.ToInt16(EnumOpcionGrabar.Actualizar);

                cboTipoDocumento.SelectedValue = DocumentoEmitido.idDocumento;
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                txtNumDocumento.Text = DocumentoEmitido.numDocumento;
                pnlComprobante.Enabled = false;
                dtFecEmision.Value = Convert.ToDateTime(DocumentoEmitido.fecEmision);
                cboEsGuia.SelectedValue = DocumentoEmitido.EsGuia;
                txtSerieRef.Text = DocumentoEmitido.serDocumentoRef;
                txtNumDocumentoRef.Text = DocumentoEmitido.numDocumentoRef;

                if (!String.IsNullOrEmpty(DocumentoEmitido.fecDocumentoRef.ToString()))
                {
                    dtpFecReferencia.Value = Convert.ToDateTime(DocumentoEmitido.fecDocumentoRef);
                }

                cboMonedas.SelectedValue = DocumentoEmitido.idMoneda;
                txtTica.Text = DocumentoEmitido.tipCambio.ToString();
                
                txtIdCondicion.Text = Convert.ToInt32(DocumentoEmitido.idCondicion).ToString("00");
                txtDesCondicion.Text = DocumentoEmitido.desCondicion;

                txtRuc.Text = DocumentoEmitido.numRuc;
                txtRazonSocial.Text = DocumentoEmitido.RazonSocial;
                txtDireccion.Text = DocumentoEmitido.Direccion;
                idVendedor = Convert.ToInt32(DocumentoEmitido.idVendedor);
                idSucursal = Convert.ToInt32(DocumentoEmitido.idSucursalCliente);
                txtIdSucursal.Text = idSucursal.ToString("00");
                txtIdVendedor.Text = idVendedor.ToString("00");

                cboTransporte.SelectedValue = DocumentoEmitido.idTipTransporte.ToString();
                txtNombrePuerto.Text = DocumentoEmitido.NombrePuerto;
                txtNroReserva.Text = DocumentoEmitido.numReserva;
                txtNroPartida.Text = DocumentoEmitido.numPartida;

                txtGlosa.Text = DocumentoEmitido.Glosa;

                if (DocumentoEmitido.ListaCanjeGuias != null && DocumentoEmitido.ListaCanjeGuias.Count > 0)
                {
                    foreach (CanjeGuiasE item in DocumentoEmitido.ListaCanjeGuias)
                    {
                        lbDocumentos.Items.Add(item.idDocumentoGuia + " - " + item.numSerieGuia + " - " + item.numDocumentoGuia);    
                    }

                    if (lbDocumentos.Items.Count > Variables.Cero)
                    {
                        btBorrar.Enabled = true;
                    }
                    else
                    {
                        btBorrar.Enabled = false;
                    }
                }

                if (DocumentoEmitido.ListaItemsDocumento == null)
                {
                    DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                }
            }

            //Detalle
            bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
            bsDetalleDocumento.ResetBindings(false);
            SumarTotales();

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

        void LlenarCombos()
        {
            //Datos para saber si se trata de Guia, Factura o exportacion
            cboEsGuia.DataSource = Global.CargarEsGuia();
            cboEsGuia.ValueMember = "id";
            cboEsGuia.DisplayMember = "Nombre";
            cboEsGuia.SelectedValue = EnumEsGuia.S.ToString();

            cboTransporte.DataSource = Global.CargarTipoTransporte();
            cboTransporte.ValueMember = "id";
            cboTransporte.DisplayMember = "Nombre";
            cboTransporte.SelectedValue = Variables.Cero.ToString();

            //Llenando las monedas
            List<MonedasE> listaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.LlenarCombos<MonedasE>(cboMonedas, listaMonedas, "idMoneda", "desAbreviatura");

            //Llenando los documentos existentes...
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);//AgenteMaestro.Proxy.ListarDocumentos();
            DocumentosE Fila = new DocumentosE();
            Fila.idDocumento = Variables.Cero.ToString();
            Fila.desDocumento = Variables.Seleccione;
            ListaDocumentos.Add(Fila);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentoRef, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento", false);
            cboDocumentoRef.SelectedValue = Variables.Cero.ToString();

            //Llenando el tipo de documento
            ComboHelper.LlenarCombos<NumControlDetE>(cboTipoDocumento, ListaDocumentosControl, "idDocumento", "desDocumento");
        }

        void LlenarAyuda()
        {
            Global.CrearToolTip(btNuevoCliente, "Agregar Nuevo Cliente.");
            Global.CrearToolTip(btBuscarCliente, "Buscar Cliente.");
            Global.CrearToolTip(btBuscarDireccion, "Buscar otra direccion(Sucursal).");
            Global.CrearToolTip(btBuscarVendedor, "Buscar vendedor.");
            Global.CrearToolTip(cboDocumentoRef, "Documentos de referencia.");
            Global.CrearToolTip(btBuscarCondicion, "Buscar condiciones de venta.");
            Global.CrearToolTip(btInsertar, "Ingresar Nro. de Guía");
            Global.CrearToolTip(btBorrar, "Quitar Nro. de Guía");
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
            DocumentoEmitido.fecRecepcion = (Nullable<DateTime>)null;
            DocumentoEmitido.Direccion = txtDireccion.Text.Trim();

            if (String.IsNullOrEmpty(DocumentoEmitido.idTipCondicion.ToString()))
            {
                DocumentoEmitido.idTipCondicion = (Int32)EnumTipoCondicionVenta.FacBol;
                DocumentoEmitido.idCondicion = Convert.ToInt32(txtIdCondicion.Text);
            }

            DocumentoEmitido.idMoneda = cboMonedas.SelectedValue.ToString();
            DocumentoEmitido.tipCambio = Convert.ToDecimal(txtTica.Text);
            DocumentoEmitido.totMontoBruto = Convert.ToDecimal(lblTotal.Text);            
            DocumentoEmitido.totsubTotal = Convert.ToDecimal(lblTotal.Text);
            DocumentoEmitido.totDscto1 = Variables.ValorCeroDecimal;
            DocumentoEmitido.totDscto2 = Variables.ValorCeroDecimal;
            DocumentoEmitido.totDscto3 = Variables.ValorCeroDecimal;
            DocumentoEmitido.totIsc = Variables.ValorCeroDecimal;
            DocumentoEmitido.totIgv = Variables.ValorCeroDecimal;
            DocumentoEmitido.totTotal = Convert.ToDecimal(lblTotal.Text);
            DocumentoEmitido.Glosa = txtGlosa.Text;

            if (cboDocumentoRef.SelectedValue.ToString() != Variables.Cero.ToString())
            {
                DocumentoEmitido.idDocumentoRef = cboDocumentoRef.SelectedValue.ToString();
                DocumentoEmitido.serDocumentoRef = txtSerieRef.Text;
                DocumentoEmitido.numDocumentoRef = txtNumDocumentoRef.Text;
                DocumentoEmitido.fecDocumentoRef = dtpFecReferencia.Checked == true ? dtpFecReferencia.Value.Date : (Nullable<DateTime>)null;
                DocumentoEmitido.TotalRef = Variables.ValorCeroDecimal;
            }           

            DocumentoEmitido.totAfectoPerce = Variables.ValorCeroDecimal;
            DocumentoEmitido.totPercepcion = Variables.ValorCeroDecimal;
            DocumentoEmitido.indEstado = EnumEstadoDocumentos.C.ToString();
            
            //Datos Clientes
            DocumentoEmitido.RazonSocial = txtRazonSocial.Text;
            DocumentoEmitido.numRuc = txtRuc.Text;
            DocumentoEmitido.idSucursalCliente = Convert.ToInt32(txtIdSucursal.Text);
            
            //Datos exportación
            DocumentoEmitido.idTipTransporte = cboTransporte.SelectedValue.ToString();
            DocumentoEmitido.NombrePuerto = txtNombrePuerto.Text;
            DocumentoEmitido.numReserva = txtNroReserva.Text;
            DocumentoEmitido.numPartida = txtNroPartida.Text;

            DocumentoEmitido.indVoucher = false;
            DocumentoEmitido.EsGuia = cboEsGuia.SelectedValue.ToString();
            
            DocumentoEmitido.idVendedor = Convert.ToInt32(txtIdVendedor.Text);

            if (DocumentoEmitido.nroDocAsociado == null)
            {
                DocumentoEmitido.nroDocAsociado = Variables.Cero;
            }

            DocumentoEmitido.fecEnvioSunat = (Nullable<DateTime>)null;
            DocumentoEmitido.fecAnuladoSunat = (Nullable<DateTime>)null;
        }

        void BloquearPaneles(Boolean Flag)
        {
            pnlComprobante.Enabled = Flag;
            pnlCliente.Enabled = Flag;
            pnlTraslado.Enabled = Flag;
            
            pnlConductor.Enabled = Flag;
            pnlDetalle.Enabled = Flag;
            txtGlosa.Enabled = Flag;
        }

        void AnchoColumnas()
        {
            dgvFacturaExpo.Columns[0].Width = 37; //Item
            dgvFacturaExpo.Columns[1].Width = 65; //Cod de Articulo
            dgvFacturaExpo.Columns[2].Width = 500; //Descripcion del Articulo
            dgvFacturaExpo.Columns[3].Width = 50; //Cantidad
            dgvFacturaExpo.Columns[4].Width = 60; //Precio
            dgvFacturaExpo.Columns[5].Width = 60; //Total
            dgvFacturaExpo.Columns[6].Width = 90; //usuario Registro
            dgvFacturaExpo.Columns[7].Width = 120; //Fecha Registro
            dgvFacturaExpo.Columns[8].Width = 90; //Usuario Modificacion
            dgvFacturaExpo.Columns[9].Width = 120; //Fecha Modificacion
        }

        void AnchoColumnasGastos()
        {
            dgvGastos.Columns[0].Width = 20; //Item
            dgvGastos.Columns[1].Width = 120; //Concepto
            dgvGastos.Columns[2].Width = 200; //Descripcion
            dgvGastos.Columns[3].Width = 50; //Importe
        }

        void SumarTotales()
        {
            if (DocumentoEmitido.ListaItemsDocumento != null && DocumentoEmitido.ListaItemsDocumento.Count > Variables.Cero)
            {
                Decimal Cantidad = Convert.ToDecimal((from x in DocumentoEmitido.ListaItemsDocumento select x.Cantidad).Sum());
                Decimal Precio = Convert.ToDecimal((from x in DocumentoEmitido.ListaItemsDocumento select x.PrecioSinImpuesto).Sum());
                Decimal Total = Convert.ToDecimal((from x in DocumentoEmitido.ListaItemsDocumento select x.Total).Sum());

                lblCantidad.Text = Cantidad.ToString("###,##0.00");
                lblPrecio.Text = Precio.ToString("###,##0.00");
                lblTotal.Text = Total.ToString("###,##0.00"); 
            }
            else
            {
                lblCantidad.Text = Variables.Cero.ToString("###,##0.00");
                lblPrecio.Text = Variables.Cero.ToString("###,##0.00");
                lblTotal.Text = Variables.Cero.ToString("###,##0.00"); 
            }
        }

        void FormatoGridGastos()
        {
            ////Para que la primera columan no aparesca
            dgvGastos.RowHeadersVisible = false;
            dgvGastos.ColumnHeadersVisible = false;
            //Inicializar propiedades básicas DataGridView.
            dgvGastos.BackgroundColor = Color.LightSteelBlue;
            dgvGastos.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            //oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            //oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            dgvGastos.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            //oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvGastos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            dgvGastos.RowsDefaultCellStyle.BackColor = Color.White;
            //if (MostrarColor)
            //{
            //    oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //}

            dgvGastos.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

            //Valores de propiedad, conjunto adecuado para la visualización.
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.AllowUserToOrderColumns = false;
            //dgvGastos.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dgvGastos.MultiSelect = false;

            //oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            //oDgv.ColumnHeadersHeight = AltoCabecera;

            //Formato para las filas
            DataGridViewRow lineas = dgvGastos.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 20;
            lineas.MinimumHeight = 10;

            dgvGastos.Refresh();
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
                    Int32 numDias;

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

        void LlenarDocumentosGrid()
        {
            DataGridViewComboBoxColumn cbo = dgvGastos.Columns["cboDgCboConcepto"] as DataGridViewComboBoxColumn;

            cbo.DataSource = Global.CargarGastosExportacion(); ;
            cbo.DisplayMember = "Nombre";
            cbo.ValueMember = "Id";
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                BloquearPaneles(true);
                Opcion = (Int16)EnumOpcionGrabar.Insertar;

                Global.LimpiarControlesPaneles(pnlComprobante);
                Global.LimpiarControlesPaneles(pnlCliente);
                Global.LimpiarControlesPaneles(pnlConductor);
                Global.LimpiarControlesPaneles(pnlTraslado);
                txtGlosa.Text = String.Empty;

                DocumentoEmitido = new EmisionDocumentoE();
                DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();

                DocumentoEmitido.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                DocumentoEmitido.idLocal = VariablesLocales.SesionLocal.IdLocal;
                cboTipoDocumento_SelectionChangeCommitted(new object(), new EventArgs());
                DocumentoEmitido.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                DocumentoEmitido.FechaRegistro = VariablesLocales.FechaHoy;
                DocumentoEmitido.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                DocumentoEmitido.FechaModificacion = VariablesLocales.FechaHoy;
                txtTica.Text = VariablesLocales.TipoCambioDelDia.valVenta.ToString();

                //Detalle
                bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                bsDetalleDocumento.ResetBindings(false);

                lbDocumentos.Items.Clear();

                cboDocumentoRef_SelectionChangeCommitted(new object(), new EventArgs());

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Editar()
        {
            BloquearPaneles(true);
            Opcion = (Int16)EnumOpcionGrabar.Actualizar;
            base.Editar();
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
                        DocumentoEmitido = AgenteVentas.Proxy.GrabarDocumentos(DocumentoEmitido, EnumOpcionGrabar.Insertar,  Variables.SI.ToString());
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        DocumentoEmitido = AgenteVentas.Proxy.GrabarDocumentos(DocumentoEmitido, EnumOpcionGrabar.Actualizar, Variables.SI);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                BloquearPaneles(false);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Cancelar()
        {
            Opcion = Variables.Cero;
            BloquearPaneles(false);
            base.Cancelar();
        }

        public override Boolean ValidarGrabacion()
        {
            return base.ValidarGrabacion();
        }

        public override void Cerrar()
        {
            base.Cerrar();
        }

        #endregion

        #region Eventos

        private void frmEmisionFacturaExpo_Load(object sender, EventArgs e)
        {
            Grid = false;
            LlenarCombos();
            NuevoRegistro();
            cboTipoAsiento.SelectedIndex = 0;
        }

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarClientes oFrm = new frmBuscarClientes();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCliente != null)
            {
                DocumentoEmitido.idPersona = oFrm.oCliente.idPersona;
                DocumentoEmitido.idCanalVenta = Convert.ToInt32(oFrm.oCliente.idCanalVenta);
                txtRuc.Text = DocumentoEmitido.numRuc = oFrm.oCliente.RUC;
                txtRazonSocial.Text = DocumentoEmitido.RazonSocial = oFrm.oCliente.RazonSocial;
                txtDireccion.Text = DocumentoEmitido.Direccion = oFrm.oCliente.DireccionCompleta;
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
                    Int32 numDias = Variables.Cero;

                    DocumentoEmitido.idTipCondicion = oFrm.oCondicion.idTipCondicion;
                    DocumentoEmitido.idCondicion = idCondicion;
                    txtIdCondicion.Text = idCondicion.ToString("00");
                    txtDesCondicion.Text = oFrm.oCondicion.desCondicion;

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

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarGuia oFrm = new frmBuscarGuia();
                Int32 Correlativo = 1;

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaDocumentos != null)
                {
                    foreach (EmisionDocumentoE item in oFrm.oListaDocumentos)
                    {
                        //List<OrdenProduccionDetE> ListaTmp = new List<OrdenProduccionDetE>();
                        //DateTime fecIni = Convert.ToDateTime("01/01/1900");
                        //DateTime fecFin = Convert.ToDateTime("31/12/2079");

                        //dtFecEmision.Value = item.fecEmision.Date;
                        //ListaOp = AgenteProduccion.Proxy.ListarAsignacionesPedidos(item.idEmpresa, item.idLocal, fecIni, fecFin, EnumEstadoDocumentos.F.ToString(), item.nroDocAsociado);
                        //ListaTmp = new List<OrdenProduccionDetE>(from x in ListaOp orderby x.idCategoria, x.idCalibre select x).ToList();

                        //if (ListaOp != null && ListaOp.Count > Variables.Cero)
                        //{
                        //    var agrupado = ListaTmp.GroupBy(x => new { x.idArticulo, x.OtroNombre, x.idCalibre, x.idCategoria, x.PesoNeto, x.PesoBruto }).Select(group =>
                        //                                        new { group.Key, unidxpallet = group.Sum(x => x.UnidxPallet) });

                        //    foreach (var op in agrupado)
                        //    {
                        //        EmisionDocumentoDetE oDetalle = new EmisionDocumentoDetE();

                        //        oDetalle.Item = Correlativo.ToString("000");
                        //        oDetalle.idArticulo = op.Key.idArticulo;
                        //        oDetalle.nomArticulo = op.Key.OtroNombre;
                        //        oDetalle.Cantidad = op.unidxpallet;
                        //        oDetalle.CantidadAtendida = op.unidxpallet;
                        //        oDetalle.PrecioSinImpuesto = Variables.ValorCeroDecimal;
                        //        oDetalle.Total = Variables.ValorCeroDecimal;
                        //        oDetalle.PesoNeto = Convert.ToDecimal(oDetalle.Cantidad) * op.Key.PesoNeto;
                        //        oDetalle.PesoBruto = Convert.ToDecimal(oDetalle.Cantidad) * op.Key.PesoBruto;

                        //        oDetalle.UsuarioRegistro = oDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        //        oDetalle.FechaRegistro = oDetalle.FechaModificacion = VariablesLocales.FechaHoy;

                        //        Correlativo++;
                        //        DocumentoEmitido.ListaItemsDocumento.Add(oDetalle);
                        //    }
                        //}

                        //PedidoCabE oPedido = AgenteVentas.Proxy.RecuperarPedidoPorId(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(item.nroDocAsociado));

                        //if (oPedido != null)
                        //{
                        //    cboMonedas.SelectedValue = oPedido.idMoneda;
                        //    ClienteE oCliente = new MaestrosServiceAgent().Proxy.RecuperarClientePorId(Convert.ToInt32(oPedido.idFacturar), VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                        //    DocumentoEmitido.idPersona = oCliente.idPersona;
                        //    DocumentoEmitido.nroDocAsociado = Convert.ToInt32(item.nroDocAsociado);
                        //    txtRuc.Text = oCliente.RUC;
                        //    txtRazonSocial.Text = oCliente.RazonSocial;
                        //    txtDireccion.Text = oCliente.DireccionCompleta;
                        //    txtNroReserva.Text = oPedido.Reserva;
                        //    txtNroPartida.Text = "0806100000";

                        //    if (!String.IsNullOrEmpty(oPedido.nroDocReferencia))
                        //    {
                        //        cboDocumentoRef.SelectedValue = "OT";
                        //        cboDocumentoRef_SelectionChangeCommitted(new Object(), new EventArgs());
                        //        txtNumDocumentoRef.Text = oPedido.nroDocReferencia;
                        //    }

                        //    String Incoterms = oPedido.desIncoterms;
                        //    StringBuilder Glosa = new StringBuilder();
                        //    Decimal Neto = Convert.ToDecimal((from x in DocumentoEmitido.ListaItemsDocumento select x.PesoNeto).Sum());
                        //    Decimal Bruto = Convert.ToDecimal((from x in DocumentoEmitido.ListaItemsDocumento select x.PesoBruto).Sum());

                        //    if (!String.IsNullOrEmpty(Incoterms))
                        //    {
                        //        Glosa.Append("INCOTERMS: ").Append(Incoterms).Append("\n\r");
                        //    }

                        //    Glosa.Append("CARGO NET WEIGHT / PESO NETO (KGS).:  ").Append(Neto.ToString("N2")).Append("\n\r");
                        //    Glosa.Append("CARGO GROSS WEIGHT / PESO BRUTO (KGS).:  ").Append(Bruto.ToString("N2")).Append("\n\r");
                        //    Glosa.Append("                          CONTENEDOR: ").Append(oPedido.Contenedor).Append("\n\r");

                        //    oCliente = new MaestrosServiceAgent().Proxy.RecuperarClientePorId(Convert.ToInt32(oPedido.idConsignatario), VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                        //    if (oCliente != null)
                        //    {
                        //        Glosa.Append("\n\r");
                        //        Glosa.Append("CONSIGNEE: ").Append(oCliente.RazonSocial).Append("\n\r");
                        //        Glosa.Append("\n\r");
                        //        Glosa.Append(oCliente.DireccionCompleta).Append("\n\r");
                        //    }

                        //    Glosa.Append("\n\r");
                        //    Glosa.Append("\n\r");
                        //    Glosa.Append("\n\r");
                        //    Glosa.Append("                          PARTIDA ARANCELARIA 0806100000").Append("\n\r");
                        //    Glosa.Append("ACOGIMIENTO A RESTITUCION DE DERECHOS ARANCELARIOS D.S NRO. 104-95-EF").Append("\n\r");
                        //    Glosa.Append("\n\r");
                        //    Glosa.Append("GLN/GGN: 4049928954084").Append("\n\r");
                        //    Glosa.Append("GLOBAL G.A.P.-CERTIFICADO").Append("\n\r");
                        //    txtGlosa.Text = Glosa.ToString();
                        //}

                        //lbDocumentos.Items.Add(item.idDocumento + " - " + item.numSerie + " - " + item.numDocumento);

                        ////Para llenar el Canje de Guias...
                        //CanjeGuiasE Guia = new CanjeGuiasE();
                        //Guia.idDocumentoGuia = item.idDocumento;
                        //Guia.numSerieGuia = item.numSerie;
                        //Guia.numDocumentoGuia = item.numDocumento;
                        //DocumentoEmitido.ListaCanjeGuias.Add(Guia);
                    }

                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    bsDetalleDocumento.ResetBindings(false);

                    SumarTotales();
                    if (lbDocumentos.Items.Count > Variables.Cero)
                    {
                        btBorrar.Enabled = true;
                    }
                    else
                    {
                        btBorrar.Enabled = false;
                    }

                    Modificacion = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbDocumentos.SelectedItem != null)
                {
                    String nroGguia = lbDocumentos.Text;
                    List<String> Lista = new List<String>(nroGguia.Split('-'));

                    //Quitando del ListBox...
                    lbDocumentos.Items.RemoveAt(lbDocumentos.SelectedIndex);

                    //Quitando de la lista de guias...
                    DocumentoEmitido.ListaCanjeGuias.RemoveAll(x => x.idDocumentoGuia == Lista[0].Trim() 
                                                                    && x.numSerieGuia == Lista[1].Trim() 
                                                                    && x.numDocumentoGuia == Lista[2].Trim());

                    DocumentoEmitido.ListaItemsDocumento = new List<EmisionDocumentoDetE>();
                    bsDetalleDocumento.DataSource = DocumentoEmitido.ListaItemsDocumento;
                    DocumentoEmitido.nroDocAsociado = Variables.Cero;

                    Modificacion = true;
                }
                else
                {
                    Global.MensajeFault("Debe escoger un item para poder quitarlo...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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
                    dtpFecReferencia.Enabled = true;
                    txtSerieRef.Focus();
                }
                else
                {
                    txtSerieRef.Text = String.Empty;
                    txtNumDocumentoRef.Text = String.Empty;
                    txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtNumDocumentoRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    dtpFecReferencia.Enabled = false;
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

        private void btInsertarGasto_Click(object sender, EventArgs e)
        {            
            EmisionDocumentoExportaE Gasto = new EmisionDocumentoExportaE();
            Int32 Item = 1;

            if (bsGastos.Count > 0)
            {
                Item = Convert.ToInt32(DocumentoEmitido.ListaGastosExportacion.Max(mx => mx.Item)) + 1;
            }

            LlenarDocumentosGrid();
            Gasto.Item = Item.ToString("00");
            Gasto.Concepto = "FL";
            DocumentoEmitido.ListaGastosExportacion.Add(Gasto);

            bsGastos.DataSource = DocumentoEmitido.ListaGastosExportacion;
            bsGastos.ResetBindings(false);

            //AnchoColumnasGastos();
        }

        private void cboTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<NumControlDetE> ListaDetalle = new List<NumControlDetE>();

            foreach (NumControlDetE item in ListaDocumentosControl)
            {
                if (cboTipoDocumento.SelectedValue.ToString() == item.idDocumento)
                {
                    ListaDetalle = AgenteVentas.Proxy.ListarSeriesNumControlDet(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, item.idControl, cboTipoDocumento.SelectedValue.ToString());
                    idControlTmp = item.idControl;
                    break;
                }
            }

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

        private void dgvFacturaExpo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgvFacturaExpo.Columns[1].DefaultCellStyle.Format = "000000";
            }
        }

        private void dgvFacturaExpo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //Decimal Precio = Convert.ToDecimal(dgvFacturaExpo.Rows[e.RowIndex].Cells[4].Value);

                //frmCambioPrecio oFrm = new frmCambioPrecio(Precio);

                //if (oFrm.ShowDialog() == DialogResult.OK)
                //{
                //    if (!oFrm.Todos)
                //    {
                //        ((EmisionDocumentoDetE)bsDetalleDocumento.Current).PrecioSinImpuesto = oFrm.PrecioFinal;
                //        ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Total = oFrm.PrecioFinal * ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Cantidad;
                //        ((EmisionDocumentoDetE)bsDetalleDocumento.Current).Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                //    }
                //    else
                //    {
                //        foreach (EmisionDocumentoDetE item in bsDetalleDocumento.List)
                //        {
                //            item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                //            item.PrecioSinImpuesto = oFrm.PrecioFinal;
                //            item.Total = oFrm.PrecioFinal * item.Cantidad;
                //        }
                //    }

                //    bsDetalleDocumento.ResetBindings(false);
                //    SumarTotales();
                //} 
            }
        }

        private void dtFecEmision_ValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = ((DateTimePicker)sender).Value;
            TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMonedas.SelectedValue.ToString(), Fecha.Date);

            if (Tica != null)
            {
                txtTica.Text = Tica.valVenta.ToString();
            }
            else
            {
                txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                dtFecEmision.Focus();
                Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                String idMoneda = ((ComboBox)sender).SelectedValue.ToString();
                TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(idMoneda, dtFecEmision.Value.Date);

                if (Tica != null)
                {
                    txtTica.Text = Tica.valVenta.ToString();
                }
                else
                {
                    txtTica.Text = Variables.ValorCeroDecimal.ToString("N3");
                    dtFecEmision.Focus();
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
