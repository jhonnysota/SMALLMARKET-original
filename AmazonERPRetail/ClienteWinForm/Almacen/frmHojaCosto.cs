using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using Entidades.CtasPorPagar;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Ventas;
using ClienteWinForm.Contabilidad.Reportes;

namespace ClienteWinForm.Almacen
{
    public partial class frmHojaCosto : FrmMantenimientoBase
    {

        #region Constructor

        //Nuevo
        public frmHojaCosto()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvItemHojaCosto, false);
            FormatoGrid(dgvImportacion, false);
            LlenarCombos();
        }
        
        //Edición
        public frmHojaCosto(HojaCostoE oHojaTmp)
            : this()
        {
            oHojaCosto = oHojaTmp;
            Text = "Hoja de Costo (Trans.: " + oHojaTmp.idHojaCosto.ToString() + " - Carp. " + oHojaTmp.NumCarperta + ")";
        }

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar {  get { return new CtasPorPagarServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }

        HojaCostoE oHojaCosto = null;
        List<HojaCostoItemE> oListaEliminados = null;
        List<GastosImportacionE> oListaEliminados2 = null;
        Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void SumarTotales()
        {
            try
            {
                if (oHojaCosto != null && oHojaCosto.ListaGastosImportacion != null)
                {
                    if (oHojaCosto.ListaGastosImportacion.Count() > 0)
                    {
                        Decimal totalGasto = Decimal.Round((from x in oHojaCosto.ListaGastosImportacion select x.MontoDolares).Sum(), 2);
                        Decimal totalGastoMN = Decimal.Round((from x in oHojaCosto.ListaGastosImportacion select x.MontoSoles).Sum(), 2);
                        txtTotalGasto.Text = Decimal.Round(totalGasto, 2).ToString("N2");
                        txtTotalGastoMN.Text = Decimal.Round(totalGastoMN, 2).ToString("N2");
                    }
                }

                if (oHojaCosto != null && oHojaCosto.ListaHojaCostoItem != null)
                {
                    if (oHojaCosto.ListaHojaCostoItem.Count > 0)
                    {
                        Decimal totalFob = Decimal.Round((from x in oHojaCosto.ListaHojaCostoItem select x.ValorFob).Sum(), 2);
                        Decimal totalOG = Decimal.Round((from x in oHojaCosto.ListaHojaCostoItem select x.Flete + x.Seguro + x.OtrosCostos).Sum(), 2);
                        Decimal totalMe = Decimal.Round((from x in oHojaCosto.ListaHojaCostoItem select x.ValorTotalDolares).Sum(), 2);
                        Decimal totalCostoLogistico = Decimal.Round((from x in oHojaCosto.ListaHojaCostoItem select x.GstoOtros).Sum(), 2);
                        Decimal totalCostoLogisticoMN = Decimal.Round((from x in oHojaCosto.ListaHojaCostoItem select x.GstoOtrosMN).Sum(), 2);
                        Decimal totalAlmacen = Decimal.Round((from x in oHojaCosto.ListaHojaCostoItem select x.CostoTotalME).Sum(), 2);

                        txtImpTotal.Text = Decimal.Round(totalFob, 2).ToString("N2");
                        txtOtrosCostos.Text = Decimal.Round(totalOG, 2).ToString("N2");
                        txtTotalMe.Text = Decimal.Round(totalMe, 2).ToString("N2");
                        txtTotalMN.Text = Decimal.Round(totalMe * oHojaCosto.TipoCambio.Value, 2).ToString("N2");
                        txtCostoLogistico.Text = Decimal.Round(totalCostoLogistico, 2).ToString("N2");
                        txtCostoLogisticoMN.Text = Decimal.Round(totalCostoLogisticoMN, 2).ToString("N2");
                        txtCostoTotalAlmacen.Text = Decimal.Round(totalAlmacen, 2).ToString("N2");
                        txtCostoTotalAlmacenMN.Text = Decimal.Round((totalMe * oHojaCosto.TipoCambio.Value) + totalCostoLogisticoMN, 2).ToString("N2"); 
                    }  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void GuardarDatos()
        {
            oHojaCosto.Fecha = dtpFecha.Value.Date;
            oHojaCosto.NumCarperta = txtCarpeta.Text;
            oHojaCosto.idOrdenCompra = String.IsNullOrWhiteSpace(txtIdOrdenCompra.Text) ? 0 : Convert.ToInt32(txtIdOrdenCompra.Text);
            oHojaCosto.numOrdenCompra = txtNumeroOC.Text;
            oHojaCosto.idPersona = String.IsNullOrEmpty(txtidProveedor.Text) ? (int?)null : Convert.ToInt32(txtidProveedor.Text);
            oHojaCosto.tipFormaPago = Convert.ToInt32(txtidCredito.Text);
            oHojaCosto.Descripcion = txtDescripcion.Text;
            oHojaCosto.Estado = Convert.ToString(chkEstado.Checked);
            oHojaCosto.idDocumentoFact = cboDocumentos.SelectedValue.ToString();
            oHojaCosto.FactComercial = txtInvoice.Text;
            oHojaCosto.fecFacturaComer = dtpFecInvoice.Checked ? dtpFecInvoice.Value.Date : (DateTime?)null;
            oHojaCosto.DUA = txtDua.Text;
            oHojaCosto.fecDua = dtpFecDua.Checked ? dtpFecDua.Value.Date : (DateTime?)null;
            oHojaCosto.AgAduana = "";
            oHojaCosto.Transporte = Convert.ToString(cboTransporte.SelectedValue);
            oHojaCosto.CiadeSeguros = "";
            oHojaCosto.idMoneda = Convert.ToString(cboMoneda.SelectedValue);
            oHojaCosto.TipoCambio = Convert.ToDecimal(txtTipCambio.Text);
            oHojaCosto.NroBultos = 1;
            oHojaCosto.FechaLlegadaPuerto = dtpLlegPuerto.Checked ? dtpLlegPuerto.Value : (DateTime?)null;
            oHojaCosto.FechaLlegadaAduana = dtpLlegAduana.Checked ? dtpLlegAduana.Value : (DateTime?)null;
            oHojaCosto.FechaLlegadaAlmacen = dtpLlegAlmacen.Checked ? dtpLlegAlmacen.Value : (DateTime?)null;
            oHojaCosto.Calculo = Convert.ToString(cboCalculo.SelectedValue);
            oHojaCosto.Grupo = txtidGrupo.Text;
            oHojaCosto.TotalFlete = Convert.ToDecimal(txtFlete.Text);
            oHojaCosto.TotalSeguro = Convert.ToDecimal(txtSeguro.Text);
            oHojaCosto.TotalAdvalorem = Convert.ToDecimal(txtValorem.Text);
            oHojaCosto.TotalGstoComision = Convert.ToDecimal(txtGastoComision.Text);
            oHojaCosto.TotalGstoBancario = Convert.ToDecimal(txtBancario.Text);
            oHojaCosto.TotalGstoOtros = Convert.ToDecimal(txtOtros.Text);
            oHojaCosto.FechaCierreCosto = VariablesLocales.FechaHoy;

            //Voucher Registro de compras(la provisión)
            oHojaCosto.AnioPeriodo = txtAnio.Text.Trim();
            oHojaCosto.MesPeriodo =  txtMes.Text.Trim();
            oHojaCosto.NumVoucher = txtVoucher.Text.Trim();
            oHojaCosto.idComprobante = txtComp.Text.Trim();
            oHojaCosto.NumFile = txtFile.Text.Trim();

            //Voucher de la Hoja de Costo
            oHojaCosto.AnioPeriodoCosto = String.Empty;
            oHojaCosto.MesPeriodoCosto = String.Empty;
            oHojaCosto.NumVoucherCosto = String.Empty;
            oHojaCosto.idComprobanteCosto = String.Empty;
            oHojaCosto.NumFileCosto = String.Empty;

            oHojaCosto.Embarque = String.Empty;
            oHojaCosto.Secuencia = String.Empty;
            oHojaCosto.Peso = 0;
            oHojaCosto.Prorrateo = "R";
            oHojaCosto.PorcAdvalorem = 42;
            oHojaCosto.PorcIgvCif = 1;
            oHojaCosto.PorcIgvAduana = 1;
            oHojaCosto.FlagControl = true;
            oHojaCosto.TotalCantidad = 1;
            oHojaCosto.TotalPeso = 1;
            oHojaCosto.TotalVolumen = 1;
            oHojaCosto.TotalFob = 1;
            oHojaCosto.TotalSgs = 1;
            oHojaCosto.TotalValorCifME = 1;
            oHojaCosto.TotalValorCifMN = 1;
            oHojaCosto.TotalCostoImportacion = 1;
            oHojaCosto.TotalGstoAduana = 1;
            oHojaCosto.Transferido = true;

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oHojaCosto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oHojaCosto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void LlenarCombos()
        {
            // Moneda
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in ListaMoneda
                                                             orderby x.idMoneda
                                                             select x).ToList(), "idMoneda", "desMoneda", false);
            // Tipo de Transporte
            cboTransporte.DataSource = Global.CargarTipoTransporte();
            cboTransporte.ValueMember = "id";
            cboTransporte.DisplayMember = "Nombre";
            cboTransporte.SelectedValue = Variables.Cero.ToString();

            // Tipo de Calculo
            cboCalculo.DataSource = Global.CargarTipoCalculo();
            cboCalculo.ValueMember = "id";
            cboCalculo.DisplayMember = "Nombre";
            cboCalculo.SelectedValue = Variables.Cero.ToString();

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = ">>>", indDocumentoCompras = true, indBaja = false };
            ListaDocumentos.Add(Fila);
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumentos, (from x in ListaDocumentos
                                                                    where x.indDocumentoCompras == true
                                                                    && x.indBaja == false
                                                                    orderby x.idDocumento
                                                                    select x).ToList(), "idDocumento", "desDocumento", false);
        }

        void EditarDetalle(DataGridViewCellEventArgs e, HojaCostoItemE oHojaItem)
        {
            try
            {
                if (bsHojaCostoItem.Count > 0)
                {
                    frmHojaCostoItem oFrm = new frmHojaCostoItem(oHojaItem);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oHojaCosto.ListaHojaCostoItem[e.RowIndex] = oFrm.HojacostoItem;
                        bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
                        bsHojaCostoItem.ResetBindings(false);
                        SumarTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, GastosImportacionE oGastosItem)
        {
            try
            {
                if (bsGastosImportacion.Count > 0)
                {
                    frnGastosImportacionItem oFrm = new frnGastosImportacionItem(oGastosItem, oHojaCosto.ListaHojaCostoItem);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        oHojaCosto.ListaGastosImportacion[e.RowIndex] = oFrm.GastosImportacionItem;
                        bsGastosImportacion.DataSource = oHojaCosto.ListaGastosImportacion;
                        bsGastosImportacion.ResetBindings(false);
                        SumarTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void Mon()
        {
            try
            {
                if (!dtpFecInvoice.Checked)
                {
                    txtTipCambio.Text = "0.000";
                }
                else
                {
                    DateTime Fecha = dtpFecInvoice.Value.Date;
                    TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

                    if (Tica != null)
                    {
                        txtTipCambio.Text = Tica.valVenta.ToString("N3");
                    }
                    else
                    {
                        txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                        dtpFecInvoice.Focus();
                        Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oHojaCosto == null)
            {
                oHojaCosto = new HojaCostoE();
                cboCalculo.SelectedValue = "F";
                oHojaCosto.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oHojaCosto.idLocal = VariablesLocales.SesionLocal.IdLocal;
                dtpFecha.Value = VariablesLocales.FechaHoy.Date;

                txtUsuarioRegistro.Text = oHojaCosto.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = oHojaCosto.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oHojaCosto.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = oHojaCosto.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                dtpFecInvoice.ValueChanged -= dtpFecInvoice_ValueChanged;

                txtIdHojaCosto.Text = Convert.ToString(oHojaCosto.idHojaCosto);
                txtGrupo.Text = oHojaCosto.DesGrupo;
                dtpFecha.Value = oHojaCosto.Fecha;
                txtCarpeta.Text = oHojaCosto.NumCarperta;
                txtIdOrdenCompra.Text = oHojaCosto.idOrdenCompra.ToString();
                txtNumeroOC.Text = oHojaCosto.numOrdenCompra;
                txtAnio.Text = oHojaCosto.AnioPeriodo;
                txtMes.Text = oHojaCosto.MesPeriodo;
                txtidProveedor.Text = oHojaCosto.idPersona.ToString();
                txtProveedor.Text = oHojaCosto.DesPersona;
                txtidCredito.Text = Convert.ToString(oHojaCosto.tipFormaPago);
                txtCredito.Text = oHojaCosto.DesFormaPago;
                txtDescripcion.Text = oHojaCosto.Descripcion;

                if (oHojaCosto.Estado == "T")
                {
                    chkEstado.Checked = true;
                    chkEstado.Text = "Estado Hoja de Costo (Cerrado)";
                }
                else
                {
                    chkEstado.Checked = false;
                    chkEstado.Text = "Estado Hoja de Costo (Abierto)";
                }

                if (oHojaCosto.Estado == "T")
                {
                    txtCarpeta.Enabled = false;
                    dtpFecha.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btOrdenCompra.Enabled = false;
                    btProveedor.Enabled = false;
                    btCredito.Enabled = false;
                    cboDocumentos.Enabled = false;
                    txtInvoice.Enabled = false;
                    txtDua.Enabled = false;
                    dtpFecDua.Enabled = false;
                    cboMoneda.Enabled = false;
                    dtpLlegPuerto.Enabled = false;
                    dtpLlegAduana.Enabled = false;
                    dtpLlegAlmacen.Enabled = false;
                    cboTransporte.Enabled = false;
                    btProvOC.Enabled = false;
                    cboCalculo.Enabled = false;
                    btItemsOC.Enabled = false;
                    btCalCarpeta.Enabled = false;
                    btCerrarImpor.Enabled = false;
                    btActKardex.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    btObtenerGastos.Enabled = false;
                    btGrupo.Enabled = false;
                    chkEstado.Enabled = false;
                    dtpFecInvoice.Enabled = false;
                }

                cboDocumentos.SelectedValue = String.IsNullOrWhiteSpace(oHojaCosto.idDocumentoFact) ? "0" : oHojaCosto.idDocumentoFact;
                txtInvoice.Text = oHojaCosto.FactComercial;

                if (oHojaCosto.fecFacturaComer != null)
                {
                    dtpFecInvoice.Value = Convert.ToDateTime(oHojaCosto.fecFacturaComer);
                }

                txtDua.Text = oHojaCosto.DUA;

                if (oHojaCosto.fecDua != null)
                {
                    dtpFecDua.Value = Convert.ToDateTime(oHojaCosto.fecDua);
                }

                cboTransporte.SelectedValue = oHojaCosto.Transporte;
                txtVoucher.Text = oHojaCosto.NumVoucher;
                txtComp.Text = oHojaCosto.idComprobante;
                txtFile.Text = oHojaCosto.NumFile;
                txtAnio.Text = oHojaCosto.AnioPeriodo;
                txtMes.Text = oHojaCosto.MesPeriodo;
                cboMoneda.SelectedValue = oHojaCosto.idMoneda;
                txtTipCambio.Text = Convert.ToString(oHojaCosto.TipoCambio);

                if (oHojaCosto.FechaLlegadaPuerto != null)
                {
                    dtpLlegPuerto.Value = Convert.ToDateTime(oHojaCosto.FechaLlegadaPuerto);
                }

                if (oHojaCosto.FechaLlegadaAduana != null)
                {
                    dtpLlegAduana.Value = Convert.ToDateTime(oHojaCosto.FechaLlegadaAduana);
                }

                if (oHojaCosto.FechaLlegadaAlmacen != null)
                {
                    dtpLlegAlmacen.Value = Convert.ToDateTime(oHojaCosto.FechaLlegadaAlmacen);
                }

                cboCalculo.SelectedValue = oHojaCosto.Calculo;
                txtidGrupo.Text = oHojaCosto.Grupo;
                txtFlete.Text = Convert.ToString(oHojaCosto.TotalFlete);
                txtSeguro.Text = Convert.ToString(oHojaCosto.TotalSeguro);
                txtValorem.Text = Convert.ToString(oHojaCosto.TotalAdvalorem);
                txtGastoComision.Text = Convert.ToString(oHojaCosto.TotalGstoComision);
                txtBancario.Text = Convert.ToString(oHojaCosto.TotalGstoBancario);
                txtOtros.Text = Convert.ToString(oHojaCosto.TotalGstoOtros);

                txtUsuarioRegistro.Text = oHojaCosto.UsuarioRegistro;
                txtFechaRegistro.Text = oHojaCosto.FechaRegistro.ToString();
                txtUsuarioModificacion.Text = oHojaCosto.UsuarioModificacion;
                txtFechaModificacion.Text = oHojaCosto.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                dtpFecInvoice.ValueChanged += dtpFecInvoice_ValueChanged;

                if (dtpFecInvoice.Checked)
                 {
                   dtpFecInvoice.Checked = false;
                   dtpFecInvoice.Checked = true;
                 }

                SumarTotales();
            }

            bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
            bsHojaCostoItem.ResetBindings(false);

            bsGastosImportacion.DataSource = oHojaCosto.ListaGastosImportacion;
            bsGastosImportacion.ResetBindings(false);

            base.Nuevo();
            btItemsOC.Enabled = false;
            btGastosOC.Enabled = false;
            btCalCarpeta.Enabled = false;
            btActKardex.Enabled = false;
            btCerrarImpor.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            btObtenerGastos.Enabled = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            try
            {
                if (oHojaCosto != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oHojaCosto = AgenteAlmacen.Proxy.GrabarHojaCosto(oHojaCosto, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            if (oListaEliminados2 != null && oListaEliminados2.Count > Variables.Cero)
                            {
                                foreach (GastosImportacionE item in oListaEliminados2)
                                {
                                    oHojaCosto.ListaGastosImportacion.Add(item);
                                }
                            }

                            oHojaCosto = AgenteAlmacen.Proxy.GrabarHojaCosto(oHojaCosto, EnumOpcionGrabar.Actualizar);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                            oListaEliminados = null;
                            oListaEliminados2 = null;
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
            String Respuesta = ValidarEntidad<HojaCostoE>(oHojaCosto);

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
                List<HojaCostoItemE> oListaTemp = new List<HojaCostoItemE>(oHojaCosto.ListaHojaCostoItem);

                frmHojaCostoItem oFrm = new frmHojaCostoItem(oListaTemp);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    HojaCostoItemE oPrecioItem = oFrm.HojacostoItem;
                    oHojaCosto.ListaHojaCostoItem.Add(oPrecioItem);
                    bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
                    bsHojaCostoItem.ResetBindings(false);
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
                if (bsHojaCostoItem.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        base.QuitarDetalle();

                        if (oListaEliminados == null)
                        {
                            oListaEliminados = new List<HojaCostoItemE>();
                        }

                        oListaEliminados.Add((HojaCostoItemE)bsHojaCostoItem.Current);

                        foreach (HojaCostoItemE item in oListaEliminados)
                        {
                            item.Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                        }

                        oHojaCosto.ListaHojaCostoItem.RemoveAt(bsHojaCostoItem.Position);
                        bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
                        bsHojaCostoItem.ResetBindings(false);
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

        private void frmHojaCosto_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            Mon();

            if (oHojaCosto.Estado == "T")
            {
                BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            }
        }

        private void dgvCaracteristicas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oHojaCosto.Estado == "F")
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalle(e, ((HojaCostoItemE)bsHojaCostoItem.Current));
                }
            }
        }       

        private void btProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaProveedor oFrm = new frmBusquedaProveedor();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProveedor != null)
                {
                    txtidProveedor.Text = oFrm.oProveedor.IdPersona.ToString();
                    txtProveedor.Text = oFrm.oProveedor.RazonSocial;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarOrdenCompra oFrm = new frmBuscarOrdenCompra("N");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOC != null)
                {
                    txtNumeroOC.Text = oFrm.oOC.numOrdenCompra.ToString();
                    txtIdOrdenCompra.Text = oFrm.oOC.idOrdenCompra.ToString();
                    cboMoneda.SelectedValue = oFrm.oOC.idMoneda;
                    txtidProveedor.Text = oFrm.oOC.idProveedor.ToString();
                    txtProveedor.Text = oFrm.oOC.RazonSocial;
                    txtidCredito.Text = oFrm.oOC.tipFormaPago.ToString();
                    txtCredito.Text = oFrm.oOC.desFormaPago;

                    if (!String.IsNullOrWhiteSpace(oFrm.oOC.Observacion))
                    {
                        txtDescripcion.Text = oFrm.oOC.Observacion;
                    }
                    
                    cboDocumentos.SelectedValue = oFrm.oOC.idDocumento;
                    txtInvoice.Text = String.IsNullOrWhiteSpace(oFrm.oOC.numSerie.Trim()) ? oFrm.oOC.numDocumento : oFrm.oOC.numSerie + "-" + oFrm.oOC.numDocumento;

                    if (oFrm.oOC.fecDocumento != null)
                    {
                        dtpFecInvoice.Value = Convert.ToDateTime(oFrm.oOC.fecDocumento);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCredito_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCondicionCompra oFrm = new frmBuscarCondicionCompra();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCondicionCompra != null)
                {
                    txtidCredito.Text = oFrm.oCondicionCompra.IdParTabla.ToString();
                    txtCredito.Text = oFrm.oCondicionCompra.Nombre;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarDetracciones oFrm = new frmBuscarDetracciones();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.eDetra != null)
                {
                    txtidGrupo.Text = oFrm.eDetra.idTipoDetraccion.ToString();
                    txtGrupo.Text = oFrm.eDetra.Nombre;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frnGastosImportacionItem oFrm = new frnGastosImportacionItem(oHojaCosto.ListaHojaCostoItem);

                if (oFrm.ShowDialog() == DialogResult.OK)
                {
                    GastosImportacionE oGastosItem = oFrm.GastosImportacionItem;
                    oHojaCosto.ListaGastosImportacion.Add(oGastosItem);
                    bsGastosImportacion.DataSource = oHojaCosto.ListaGastosImportacion;
                    bsGastosImportacion.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsGastosImportacion.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        base.QuitarDetalle();

                        if (oListaEliminados2 == null)
                        {
                            oListaEliminados2 = new List<GastosImportacionE>();
                        }

                        oListaEliminados2.Add((GastosImportacionE)bsGastosImportacion.Current);

                        foreach (GastosImportacionE item in oListaEliminados2)
                        {
                            item.Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                        }

                        oHojaCosto.ListaGastosImportacion.RemoveAt(bsGastosImportacion.Position);
                        bsGastosImportacion.DataSource = oHojaCosto.ListaGastosImportacion;
                        bsGastosImportacion.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvImportacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oHojaCosto.Estado == "F")
            {
                if (e.RowIndex != -1)
                {
                    EditarDetalle(e, ((GastosImportacionE)bsGastosImportacion.Current));
                }
            }
        }

        private void dgvItemHojaCosto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "Peso")
                {
                    e.CellStyle.BackColor = Color.Bisque;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "Flete")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "Seguro")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "OtrosCostos")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "CostoUnitarioME" || dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "CostoTotalME") 
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "CostoUnitarioMN" || dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "CostoTotalMN")
                {
                    e.CellStyle.BackColor = Color.GreenYellow;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "ValorTotalDolares")
                {
                    e.CellStyle.BackColor = Color.Bisque;
                }

                if (dgvItemHojaCosto.Columns[e.ColumnIndex].Name == "GstoOtros")
                {
                    e.CellStyle.BackColor = Color.Bisque;
                }
            }
        }

        private void dgvImportacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvImportacion.Columns[e.ColumnIndex].Name == "montoDolares")
                {
                    e.CellStyle.BackColor = Color.Bisque;
                }

                if (dgvImportacion.Columns[e.ColumnIndex].Name == "MontoSoles")
                {
                    e.CellStyle.BackColor = Color.Bisque;
                }
            }
        }

        private void btItemsOC_Click(object sender, EventArgs e)
        {
            try
            {
                Int32.TryParse(txtIdOrdenCompra.Text, out Int32 idOrden);
                frmBuscarOrdenCompraItem oFrm = new frmBuscarOrdenCompraItem(idOrden);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oOCItem != null)
                {
                    List<OrdenCompraItemE> oHojaItem = oFrm.oOCItem;
                    oHojaCosto.ListaHojaCostoItem = new List<HojaCostoItemE>();

                    foreach (OrdenCompraItemE item in oHojaItem)
                    {
                        HojaCostoItemE oNuevo = new HojaCostoItemE();
                        oNuevo.idEmpresa = item.idEmpresa;
                        oNuevo.nNivel = 0;

                        if (item.ArticuloServ.Nemo == "O5")
                        {
                            oNuevo.Nivel = "S";
                        }
                        else
                        {
                            oNuevo.Nivel = "D";
                        }

                        oNuevo.Nivelinv = "A";
                        oNuevo.Cantidad = item.CanOrdenada;
                        oNuevo.NomArticulo = item.desArticulo;
                        oNuevo.Descripcion = item.desLarga;
                        oNuevo.idArticulo = item.idArticuloServ;
                        oNuevo.idItemOC = item.idItem;

                        //oNuevo.item = item.idItem;
                        oNuevo.item = 0;
                        oNuevo.idHojaCosto = 0;
                        oNuevo.FobUnitario = item.impPrecioUnitario;
                        oNuevo.ValorFob = item.impVentaItem;
                        oNuevo.PrecioVenta = item.impVentaItem;
                        oNuevo.TCambio = Convert.ToDecimal(1);

                        oNuevo.ValorTotalDolares = Convert.ToDecimal(oNuevo.ValorFob / oNuevo.TCambio);

                        oNuevo.CostoTotalME = Convert.ToDecimal(0.00);
                        oNuevo.CostoTotalMN = Convert.ToDecimal(0.00);

                        oNuevo.PesoUnitario = item.PesoAlmacen / item.CanOrdenada;
                        oNuevo.Peso = item.PesoAlmacen;

                        oNuevo.idTipoUmedida = item.ArticuloServ.codTipoMedPresentacion;
                        oNuevo.idUmedida = item.ArticuloServ.codUniMedPresentacion;
                        oNuevo.desUmedida = item.ArticuloServ.nomUMedidaPres;
                        oNuevo.AdValorem = Convert.ToDecimal(0.00);
                        oNuevo.CostoUnitarioME = Convert.ToDecimal(0.00);
                        oNuevo.CostoUnitarioMN = Convert.ToDecimal(0.00);
                        oNuevo.FactorVenta = Convert.ToDecimal(0.00);

                        oNuevo.OtrosCostos = Convert.ToDecimal(0.00);
                        oNuevo.GstoAduana = Convert.ToDecimal(0.00);

                        oNuevo.GstoBancario = Convert.ToDecimal(0.00);
                        oNuevo.GstoComision = Convert.ToDecimal(0.00);

                        oNuevo.GstoOtros = Convert.ToDecimal(0.00);
                        oNuevo.GstoSeguro = Convert.ToDecimal(0.00);

                        oNuevo.Utilidad = Convert.ToDecimal(0.00);
                        oNuevo.ValorCif = Convert.ToDecimal(0.00);

                        oNuevo.ValorPeso = Convert.ToDecimal(0.00);
                        oNuevo.ValorVolumen = Convert.ToDecimal(0.00);

                        oNuevo.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        oNuevo.FechaRegistro = VariablesLocales.FechaHoy;
                        oNuevo.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        oNuevo.FechaModificacion = VariablesLocales.FechaHoy;
                        oNuevo.PartidaArancelaria = "";
                        oNuevo.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                        oHojaCosto.ListaHojaCostoItem.Add(oNuevo);
                    }
                   
                    bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
                    bsHojaCostoItem.ResetBindings(false);

                    SumarTotales();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCalCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                String TipoCalc = Convert.ToString(cboCalculo.SelectedValue);
                Decimal totalFob = Decimal.Round(Convert.ToDecimal(txtImpTotal.Text),2);
                Decimal totalGasto = Decimal.Round(Convert.ToDecimal(txtTotalGasto.Text),2);
                //Decimal TotalFyG = totalFob + totalGasto;
                Decimal totalGastoMN = Decimal.Round(Convert.ToDecimal(txtTotalGastoMN.Text), 2);
                Decimal TotalFyGMN = Decimal.Round(totalFob * oHojaCosto.TipoCambio.Value,2) + totalGastoMN;

                // Hallar Otros Costos en el Detalle
                Decimal totalFlete = 0;
                Decimal totalSeguro = 0;
                Decimal totalOtrosCostos = 0;
                Decimal totalCosto = 0;
                Decimal totalPeso = 0;
                Decimal totalCosto2 = 0;
                Decimal totalPeso2 = 0;

                // Obetener el Total del Valor Fob y el Peso
                foreach (HojaCostoItemE item in oHojaCosto.ListaHojaCostoItem)
                {
                    if (item.Nivel == "D")
                    {
                        totalCosto = totalCosto + Decimal.Round(Convert.ToDecimal(item.ValorFob), 2);
                        totalPeso = totalPeso + Decimal.Round(Convert.ToDecimal(item.Peso), 5);
                    }

                     item.GstoOtros = 0;
                     item.GstoOtrosMN = 0;
                }

                // Distribuir los gastos generales
                totalGastoMN = 0;
                totalGasto = 0;

                foreach (GastosImportacionE item in oHojaCosto.ListaGastosImportacion)
                {
                    if (item.DistribuirItem == 0)
                    {
                        totalGasto += item.MontoDolares;
                        totalGastoMN += item.MontoSoles;
                    }
                }

                totalFlete = (from x in oHojaCosto.ListaHojaCostoItem
                              where x.NomArticulo.ToUpper().Contains("FLETE") 
                              && x.Nivel == "S"
                              select x.ValorFob).Sum();

                totalSeguro = (from x in oHojaCosto.ListaHojaCostoItem
                               where x.NomArticulo.ToUpper().Contains("SEGURO")
                               && x.Nivel == "S"
                               select x.ValorFob).Sum();

                totalOtrosCostos = (from x in oHojaCosto.ListaHojaCostoItem
                                    where x.NomArticulo.ToUpper().Contains("OTROS COSTO")
                                    && x.Nivel == "S"
                                    select x.ValorFob).Sum();

                // Cargandos Otros costos Directo a los articulos 
                // Verificando si los articulos tienen un gasto directo.
                Decimal dtotalGasto = 0;
                Decimal dtotalGastoMN = 0;

                foreach (GastosImportacionE itemGastos in oHojaCosto.ListaGastosImportacion)
                {
                    if (itemGastos.DistribuirItem != 0)
                    {
                        // Distribuir los gastos generales
                        dtotalGasto = itemGastos.MontoDolares;
                        dtotalGastoMN = itemGastos.MontoSoles;

                        String Linea = itemGastos.ItemADistribuir;

                        if (Linea != "")
                        {
                            List<String> oLista = new List<String>(Linea.Split(','));
                            totalCosto2 = 0;
                            totalPeso2 = 0;

                            foreach (String item in oLista)
                            {
                                // Obtener el Total del Valor Fob y el Peso
                                foreach (HojaCostoItemE item2 in oHojaCosto.ListaHojaCostoItem)
                                {
                                    if (Convert.ToInt32(item) == item2.idItemOC)
                                    {
                                        if (item2.Nivel == "D")
                                        {
                                            totalCosto2 = totalCosto2 + Decimal.Round(Convert.ToDecimal(item2.ValorFob), 2);
                                            totalPeso2 = totalPeso2 + Decimal.Round(Convert.ToDecimal(item2.Peso), 5);
                                        }
                                    }
                                }
                            }

                            foreach (String item in oLista)
                            {
                                // Distribuir el Total del Valor Fob y el Peso
                                foreach (HojaCostoItemE item2 in oHojaCosto.ListaHojaCostoItem)
                                {
                                    if (Convert.ToInt32(item) == item2.idItemOC)
                                    {
                                        if (item2.Nivel == "D")
                                        {
                                            if (TipoCalc == "P")
                                            {
                                                item2.GstoOtros += Decimal.Round(Convert.ToDecimal(item2.Peso / totalPeso2) * dtotalGasto, 3);
                                                item2.GstoOtrosMN += Decimal.Round(Convert.ToDecimal(item2.Peso / totalPeso2) * dtotalGastoMN, 3);
                                            }
                                            else
                                            {
                                                item2.GstoOtros += Decimal.Round(Convert.ToDecimal(item2.ValorFob / totalCosto2) * dtotalGasto, 3);
                                                item2.GstoOtrosMN += Decimal.Round(Convert.ToDecimal(item2.ValorFob / totalCosto2) * dtotalGastoMN, 3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Distribuior Otos Costos y Otros Gastos en el Detalle
                foreach (HojaCostoItemE item in oHojaCosto.ListaHojaCostoItem)
                {
                    if (item.Nivel == "D")
                    {
                        if (TipoCalc == "P")
                        {
                            item.Flete = Decimal.Round(Convert.ToDecimal(item.Peso / totalPeso) * totalFlete, 5);
                            item.Seguro = Decimal.Round(Convert.ToDecimal(item.Peso / totalPeso) * totalSeguro, 5);
                            item.OtrosCostos = Decimal.Round(Convert.ToDecimal(item.Peso / totalPeso) * totalOtrosCostos, 5);

                            item.GstoOtros += Decimal.Round(Convert.ToDecimal(item.Peso / totalPeso) * totalGasto, 3);
                            item.GstoOtrosMN += Decimal.Round(Convert.ToDecimal(item.Peso / totalPeso) * totalGastoMN, 3);
                        }
                        else
                        {
                            item.Flete = Decimal.Round(Convert.ToDecimal(item.ValorFob / totalCosto) * totalFlete, 5);
                            item.Seguro = Decimal.Round(Convert.ToDecimal(item.ValorFob / totalCosto) * totalSeguro, 5);
                            item.OtrosCostos = Decimal.Round(Convert.ToDecimal(item.ValorFob / totalCosto) * totalOtrosCostos, 5);

                            item.GstoOtros += Decimal.Round(Convert.ToDecimal(item.ValorFob / totalCosto) * totalGasto, 3);
                            item.GstoOtrosMN += Decimal.Round(Convert.ToDecimal(item.ValorFob / totalCosto) * totalGastoMN, 3);
                        }

                        if (item.TCambio != 0)
                        {
                            item.ValorTotalDolares = Convert.ToDecimal((item.ValorFob + item.Flete + item.Seguro + item.OtrosCostos) / item.TCambio);
                        }
                        else
                        {
                            item.ValorTotalDolares = Convert.ToDecimal(item.ValorFob + item.Flete + item.Seguro + item.OtrosCostos);
                        }

                        item.CostoTotalME = Decimal.Round(Convert.ToDecimal(item.ValorTotalDolares + item.GstoOtros), 2);
                        item.CostoTotalMN = Decimal.Round(Convert.ToDecimal(item.ValorTotalDolares * oHojaCosto.TipoCambio.Value) + item.GstoOtrosMN, 2);

                        item.CostoUnitarioME = Decimal.Round(item.CostoTotalME / item.Cantidad, 6);
                        item.CostoUnitarioMN = Decimal.Round(item.CostoTotalMN / item.Cantidad, 6);
                    }
                    else
                    {
                        item.ValorTotalDolares = 0;
                        item.CostoTotalME = 0;
                        item.CostoUnitarioME = 0;
                    }

                    if (item.item != 0)
                    {
                        item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }
                }

                SumarTotales();
                bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
                bsHojaCostoItem.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btProvOC_Click(object sender, EventArgs e)
        {
            try
            {
                ProvisionesE ProvOC = AgenteCtasPorPagar.Proxy.ObtenerProvisionPorOC(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(oHojaCosto.idOrdenCompra));

                if (ProvOC != null)
                {
                    txtVoucher.Text = ProvOC.numVoucher;
                    txtComp.Text = ProvOC.idComprobante;
                    txtFile.Text = ProvOC.numFile;
                    txtAnio.Text = ProvOC.AnioPeriodo;
                    txtMes.Text = ProvOC.MesPeriodo; 
                }
                else
                {
                    Global.MensajeFault("Esta Orden de Compra aún no ha sido provisionada");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btVerAsiento_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                VoucherE VoucherRep = new VoucherE
                {
                    AnioPeriodo = txtAnio.Text,
                    numVoucher = txtVoucher.Text,
                    idComprobante = txtComp.Text,
                    numFile = txtFile.Text,
                    MesPeriodo = txtMes.Text,
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = oHojaCosto.idLocal
                };

                oFrm = new frmImpresionVoucher("N", VoucherRep)
                {
                    MdiParent = MdiParent
                };

                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btActKardex_Click(object sender, EventArgs e)
        {
            try
            {
                List<MovimientoAlmacenE> oListaMovimientos = AgenteAlmacen.Proxy.ListarMovimientosPorOrdenCompra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(txtIdOrdenCompra.Text), "S");
                oListaMovimientos = (from x in oListaMovimientos
                                     where x.idDocumento != "CR"
                                     select x ).ToList();

                if (oListaMovimientos != null && oListaMovimientos.Count > 0)
                {
                    foreach (MovimientoAlmacenE itemCab in oListaMovimientos)
                    {
                        foreach (MovimientoAlmacenItemE item in itemCab.ListaAlmacenItem)
                        {
                            foreach (HojaCostoItemE itemCosto in oHojaCosto.ListaHojaCostoItem)
                            {
                                if (item.idItemCompra != 0)
                                {
                                    if (Convert.ToInt32(item.idItemCompra) == itemCosto.idItemOC)
                                    {
                                        item.ImpCostoUnitarioBase = itemCosto.CostoUnitarioMN;
                                        item.ImpCostoUnitarioRefe = itemCosto.CostoUnitarioME;
                                        item.ImpTotalBase = Math.Round(item.Cantidad * item.ImpCostoUnitarioBase, 2);
                                        item.ImpTotalRefe = Math.Round(item.Cantidad * item.ImpCostoUnitarioRefe, 2);

                                        AgenteAlmacen.Proxy.ActualizarMovimiento_Almacen_Item(item);
                                    }
                                }
                            }
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btObtenerGastos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdHojaCosto.Text.Trim()))
                {
                    int NroHoja = Convert.ToInt32(txtIdHojaCosto.Text);
                    List<GastosImportacionE> oGastosImportacion = AgenteAlmacen.Proxy.ListarGastosImportacionPorHojaCosto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, NroHoja);

                    if (oGastosImportacion.Count() > 0 && oGastosImportacion != null)
                    {
                        foreach (GastosImportacionE item in oHojaCosto.ListaGastosImportacion)
                        {
                            item.Opcion = (Int32)EnumOpcionGrabar.Eliminar;
                        }

                        foreach (GastosImportacionE item in oGastosImportacion)
                        {
                            item.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                            item.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            item.FechaRegistro = VariablesLocales.FechaHoy;
                            item.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            item.FechaModificacion = VariablesLocales.FechaHoy;
                            item.ItemADistribuir = "";
                            oHojaCosto.ListaGastosImportacion.Add(item);
                        }

                        bsGastosImportacion.DataSource = oGastosImportacion;
                        bsGastosImportacion.ResetBindings(false);
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btMovAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                List<MovimientoAlmacenE> oListaMovimientos = AgenteAlmacen.Proxy.ListarMovimientosPorOrdenCompra(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(txtIdOrdenCompra.Text), "S");

                if (oListaMovimientos != null)
                {
                    if (oListaMovimientos.Count == 1)
                    {
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionBase);

                        if (oFrm != null)
                        {
                            if (oFrm.WindowState == FormWindowState.Minimized)
                            {
                                oFrm.WindowState = FormWindowState.Normal;
                            }

                            oFrm.BringToFront();
                            return;
                        }

                        oFrm = new frmImpresionBase(oListaMovimientos[0], "Movimientos de Almacen por O.C.")
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                    else
                    {
                        frmBuscaMovimientoAlmacen oFrm = new frmBuscaMovimientoAlmacen(oListaMovimientos, "H");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.eMovAlmacen != null)
                        {
                            Form oFrm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionBase);

                            if (oFrm2 != null)
                            {
                                if (oFrm2.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm2.WindowState = FormWindowState.Normal;
                                }

                                oFrm2.BringToFront();
                                return;
                            }

                            //oFrm2.WindowState = FormWindowState.Maximized;
                            oFrm2 = new frmImpresionBase(oFrm.eMovAlmacen, "Movimientos de Almacen por O.C.")
                            {
                                MdiParent = MdiParent
                            };

                            oFrm2.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dtpFecInvoice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!dtpFecInvoice.Checked)
                {
                    txtTipCambio.Text = "0.000";
                }
                else
                {
                 DateTime Fecha = dtpFecInvoice.Value.Date;
                 TipoCambioE Tica = VariablesLocales.RetornaTipoCambio(cboMoneda.SelectedValue.ToString(), Fecha);

                  if (Tica != null)
                   {
                       txtTipCambio.Text = Tica.valVenta.ToString("N3");
                   }
                   else
                   {
                       txtTipCambio.Text = Variables.ValorCeroDecimal.ToString("N3");
                       dtpFecInvoice.Focus();
                       Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                   }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btGastosOC_Click(object sender, EventArgs e)
        {
            #region Llenando los items de gastos de la oc

            try
            {
                //Ordenes de Compra
                Int32.TryParse(txtIdOrdenCompra.Text, out Int32 idOrden);
                OrdenCompraE ordCompra = AgenteAlmacen.Proxy.ObtenerOrdenDeCompraCompleto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idOrden, "N");

                if (ordCompra != null && ordCompra.ListaOrdenesCompras != null && ordCompra.ListaOrdenesCompras.Count > 0)
                {
                    foreach (OrdenCompraItemE item in ordCompra.ListaOrdenesCompras)
                    {
                        if (item.Nemo == "O5")
                        {
                            HojaCostoItemE oDetalle = new HojaCostoItemE()
                            {
                                idEmpresa = item.idEmpresa,
                                idLocal = 1,
                                idItemOC = item.idItem,
                                nNivel = 0,
                                Nivel = "S",
                                Nivelinv = "A",
                                PartidaArancelaria = string.Empty,
                                idArticulo = item.idArticuloServ,
                                NomArticulo = item.desArticulo,
                                Descripcion = item.desArticulo,
                                Cantidad = item.CanOrdenada,
                                PesoUnitario = 0,
                                Peso = 0,
                                idTipoUmedida = 0,
                                idUmedida = 0,
                                desUmedida = item.nomUMedida,

                                FobUnitario = item.impPrecioUnitario,
                                ValorFob = item.impVentaItem,
                                ValorPeso = 0,
                                ValorCif = 0,
                                //item.OtrosCargos = 0;
                                OtrosCostos = 0,
                                TCambio = 1,
                                ValorTotalDolares = 0,
                                AdValorem = 0,
                                GstoAduana = 0,
                                GstoComision = 0,
                                GstoSeguro = 0,
                                GstoBancario = 0,
                                GstoOtros = 0,
                                CostoTotalMN = 0,
                                CostoUnitarioMN = 0,
                                CostoTotalME = 0,
                                CostoUnitarioME = 0,
                                FactorVenta = 0,
                                PrecioVenta = item.impVentaItem,
                                Utilidad = 0,
                                UsuarioRegistro = ""
                            };

                            item.OtrosCargos = 0;
                            oHojaCosto.ListaHojaCostoItem.Add(oDetalle);
                        }

                        bsHojaCostoItem.DataSource = oHojaCosto.ListaHojaCostoItem;
                        bsHojaCostoItem.ResetBindings(false);

                        SumarTotales();
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

            #endregion
        }

        #endregion

    }
}
