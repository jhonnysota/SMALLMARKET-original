using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Tesoreria;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Ventas
{
    public partial class frmPlanillaBancos : FrmMantenimientoBase
    {

        #region Constructores

        public frmPlanillaBancos()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvDetalle, true);
        }

        //Nuevo
        public frmPlanillaBancos(List<BancosE> oListaBancos_)
            : this()
        {
            oListaBancos = oListaBancos_;
        }

        //Edición
        public frmPlanillaBancos(Int32 idPlanillaBancos, List<BancosE> oListaBancos_)
            : this()
        {
            oPlanillaBanco = AgentaVentas.Proxy.ObtenerPlanillaBancosCompleto(idPlanillaBancos);
            oListaBancos = oListaBancos_;
            indEstado = oPlanillaBanco.Estado;

            Text = "Planilla de Letras (" + oPlanillaBanco.Numero + ")";
        }

        #endregion

        #region Variables

        VentasServiceAgent AgentaVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        PlanillaBancosE oPlanillaBanco = null;
        List<BancosE> oListaBancos = null;
        LetrasEstadoLibroFileE oDiarioFile = null;
        String indEstado = "P";
        Boolean BuscarDato = true;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ListaTipoComprobante.Add(new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos });
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibroRecla, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);

            //Bancos
            ComboHelper.RellenarCombos<BancosE>(cboBancos, (from x in oListaBancos
                                                            where x.idPersona != 0
                                                            orderby x.idPersona
                                                            select x).ToList(), "idPersona", "RazonSocial");
            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desAbreviatura", false);

            List<ConceptosVariosE> oListaConceptos = AgenteAlmacen.Proxy.ConceptosVariosCobranzas(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListaConceptos.Add(new ConceptosVariosE() { idConcepto = 0, Descripcion = Variables.Escoger });
            ComboHelper.LlenarCombos<ConceptosVariosE>(cboConceptoGasto, (from x in oListaConceptos orderby x.idConcepto select x).ToList(), "idConcepto", "Descripcion");
            ComboHelper.LlenarCombos<ConceptosVariosE>(cboConceptoInteres, (from x in oListaConceptos orderby x.idConcepto select x).ToList(), "idConcepto", "Descripcion");

            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false
                                                                      select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                   orderby x.desDocumento
                                                                   select x).ToList(), "idDocumento", "desDocumento", false);
            oListaConceptos = null;
            ListaDocumentos = null;
            ListaTipoComprobante = null;
            ListaMoneda = null;
        }

        void ObtenerCuentasBancarias(Int32 idBanco, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentaBancarias = AgenteMaestro.Proxy.BancosCuentasPorMoneda(idBanco, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idMoneda);
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentasBancarias, oListaCuentaBancarias, "numCuenta", "desCuentaBanco", false);

            if (oListaCuentaBancarias.Count > 1)
            {
                cboCuentasBancarias.Enabled = true;
            }
            else
            {
                cboCuentasBancarias.Enabled = false;
            }
        }

        void Datos()
        {
            oPlanillaBanco.Numero = txtNumero.Text.Trim();
            oPlanillaBanco.idBanco = Convert.ToInt32(cboBancos.SelectedValue);
            oPlanillaBanco.numCuenta = cboCuentasBancarias.SelectedValue.ToString();
            oPlanillaBanco.idMoneda = cboMonedas.SelectedValue.ToString();
            oPlanillaBanco.Fecha = dtpFecha.Value.Date;

            if (rbDescuento.Checked)
            {
                oPlanillaBanco.Producto = "D";
            }

            if (rbCobranza.Checked)
            {
                oPlanillaBanco.Producto = "L";
            }

            if (rbGarantia.Checked)
            {
                oPlanillaBanco.Producto = "G";
            }

            oPlanillaBanco.flagProtesto = false;
 
            oPlanillaBanco.fecAbono = (DateTime?)null;
            oPlanillaBanco.AnioPeriodo = dtpFecha.Value.ToString("yyyy");
            oPlanillaBanco.MesPeriodo = dtpFecha.Value.ToString("MM");
           

            oPlanillaBanco.MontoAbono = Convert.ToDecimal(txtMontoAbono.Text);
            oPlanillaBanco.idComprobante = cboLibro.SelectedValue.ToString();
            oPlanillaBanco.numFile = cboFile.SelectedValue.ToString();
            oPlanillaBanco.tipPlanilla = "L";
            oPlanillaBanco.idConceptoGasto = Convert.ToInt32(cboConceptoGasto.SelectedValue) == 0 ? (Int32?)null : Convert.ToInt32(cboConceptoGasto.SelectedValue);
            oPlanillaBanco.idConceptoInteres = Convert.ToInt32(cboConceptoInteres.SelectedValue) == 0 ? (Int32?)null : Convert.ToInt32(cboConceptoInteres.SelectedValue);
            oPlanillaBanco.Comision = Convert.ToDecimal(txtGastos.Text);
            oPlanillaBanco.Interes = Convert.ToDecimal(txtInteres.Text);
            oPlanillaBanco.idComprobanteRec = cboLibroRecla.SelectedValue.ToString();
            oPlanillaBanco.numFileRec = cboFileRecla.SelectedValue.ToString();
            oPlanillaBanco.idDocumento = cboDocumento.SelectedValue.ToString();
            oPlanillaBanco.numDocumento = txtNumDocumento.Text.Trim();
            oPlanillaBanco.indEndosar = chkIndEndose.Checked;

            if (oPlanillaBanco.indEndosar)
            {
                oPlanillaBanco.idPersonaEndoso = Convert.ToInt32(txtRuc.Tag);
            }
            else
            {
                oPlanillaBanco.idPersonaEndoso = null;
            }

            if (String.IsNullOrWhiteSpace(txtNumero.Text.Trim()))
            {
                oPlanillaBanco.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oPlanillaBanco.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void Sumar()
        {
            if (oPlanillaBanco.oListaPlanillaBancos != null && oPlanillaBanco.oListaPlanillaBancos.Count > 0)
            {
                Decimal Total = oPlanillaBanco.oListaPlanillaBancos.Sum(x => x.Monto);
                lblTotal.Text = Total.ToString("N2");
            }
            else
            {
                lblTotal.Text = "0.00";
            }
        }

        void ObtenerDiarioFile(String Producto)
        {
            oDiarioFile = AgentaVentas.Proxy.ObtenerLetrasEstadoLibroFile(Producto, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (oDiarioFile != null)
            {
                cboLibroRecla.SelectedValue = oDiarioFile.idComprobante.ToString();
                cboLibroRecla_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFileRecla.SelectedValue = oDiarioFile.numFile;

                if (Producto == "D" && (String.IsNullOrWhiteSpace(oDiarioFile.CuentaSoles) || String.IsNullOrWhiteSpace(oDiarioFile.CuentaDolares)))
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras en Descuento, en Cobranzas/Maestros/Estados de Letras.");
                }
                else if (Producto == "L" && (String.IsNullOrWhiteSpace(oDiarioFile.CuentaSoles) || String.IsNullOrWhiteSpace(oDiarioFile.CuentaDolares)))
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras en Cobranza Libre, en Cobranzas/Maestros/Estados de Letras.");
                }
                else if (Producto == "G" && (String.IsNullOrWhiteSpace(oDiarioFile.CuentaSoles) || String.IsNullOrWhiteSpace(oDiarioFile.CuentaDolares)))
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras en Garantia, en Cobranzas/Maestros/Estados de Letras.");
                }
                else if (Producto == "P" && (String.IsNullOrWhiteSpace(oDiarioFile.CuentaSoles) || String.IsNullOrWhiteSpace(oDiarioFile.CuentaDolares)))
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras Protestadas, en Cobranzas/Maestros/Estados de Letras.");
                }
            }
            else
            {
                if (Producto == "D")
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras en Descuento, en Cobranzas/Maestros/Estados de Letras.");
                }
                else if (Producto == "L")
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras en Cobranza Libre, en Cobranzas/Maestros/Estados de Letras.");
                }
                else if (Producto == "G")
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras en Garantia, en Cobranzas/Maestros/Estados de Letras.");
                }
                else if (Producto == "P")
                {
                    Global.MensajeComunicacion("Falta configurar las cuentas contables para Letras Protestadas, en Cobranzas/Maestros/Estados de Letras.");
                }
            }
        }

        void Opciones()
        {
            chkIndEndose.CheckedChanged -= chkIndEndose_CheckedChanged;

            if (rbCobranza.Checked)
            {
                if (BuscarDato)
                {
                    ObtenerDiarioFile("L");
                    cboLibro.SelectedValue = "0";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs()); 
                }

                txtMontoAbono.Text = "0.00";
                txtGastos.Text = "0.00";
                txtInteres.Text = "0.00";
                cboConceptoGasto.SelectedValue = 0;
                cboConceptoInteres.SelectedValue = 0;
                cboConceptoGasto.Enabled = false;
                cboConceptoInteres.Enabled = false;
                dtpFecAbono.Checked = false;
                dtpFecAbono.Enabled = false;
                txtMontoAbono.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtGastos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                cboBancos.Enabled = true;
                cboMonedas.Enabled = true;
                cboCuentasBancarias.Enabled = true;
                cboDocumento.Enabled = true;
                chkIndEndose.Checked = false;
                chkIndEndose.Enabled = false;

                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else if (rbDescuento.Checked)
            {
                if (BuscarDato)
                {
                    ObtenerDiarioFile("D");
                    cboLibro.SelectedValue = "04";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs()); 
                }

                txtMontoAbono.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                cboConceptoGasto.Enabled = true;
                cboConceptoInteres.Enabled = true;
                chkIndEndose.Enabled = true;

                if (chkIndEndose.Checked)
                {
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboBancos.Enabled = false;
                    cboMonedas.Enabled = false;
                    cboCuentasBancarias.Enabled = false;
                    cboDocumento.Enabled = false;
                    dtpFecAbono.Checked = false;
                    dtpFecAbono.Enabled = false;

                    cboLibro.SelectedValue = "0";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                    txtMontoAbono.Text = "0.00";
                    txtGastos.Text = "0.00";
                    txtInteres.Text = "0.00";
                    cboConceptoGasto.SelectedValue = 0;
                    cboConceptoInteres.SelectedValue = 0;
                    cboConceptoGasto.Enabled = false;
                    cboConceptoInteres.Enabled = false;
                    txtMontoAbono.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtGastos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    cboDocumento.SelectedValue = "0";
                    txtNumDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                }
                else
                {
                    txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    pnlPrincipales.Enabled = true;
                    txtNumDocumento.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    cboBancos.Enabled = true;
                    cboMonedas.Enabled = true;
                    cboCuentasBancarias.Enabled = true;
                    cboDocumento.Enabled = true;
                    dtpFecAbono.Enabled = true;
                }
            }
            else if (rbGarantia.Checked)
            {
                if (BuscarDato)
                {
                    ObtenerDiarioFile("G");
                    cboLibro.SelectedValue = "0";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs()); 
                }

                txtMontoAbono.Text = "0.00";
                txtGastos.Text = "0.00";
                txtInteres.Text = "0.00";
                cboConceptoGasto.SelectedValue = 0;
                cboConceptoInteres.SelectedValue = 0;
                cboConceptoGasto.Enabled = false;
                cboConceptoInteres.Enabled = false;
                txtMontoAbono.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtGastos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                cboBancos.Enabled = true;
                cboMonedas.Enabled = true;
                cboCuentasBancarias.Enabled = true;
                cboDocumento.Enabled = true;
                chkIndEndose.Checked = false;
                chkIndEndose.Enabled = false;
                dtpFecAbono.Enabled = true;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else if (rbProtestada.Checked)
            {
                if (BuscarDato)
                {
                    ObtenerDiarioFile("P");
                    cboLibro.SelectedValue = "0";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                }

                txtMontoAbono.Text = "0.00";
                txtGastos.Text = "0.00";
                txtInteres.Text = "0.00";
                cboConceptoGasto.SelectedValue = 0;
                cboConceptoInteres.SelectedValue = 0;
                cboConceptoGasto.Enabled = false;
                cboConceptoInteres.Enabled = false;
                txtMontoAbono.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtGastos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                
                cboBancos.Enabled = true;
                cboMonedas.Enabled = true;
                cboCuentasBancarias.Enabled = true;
                cboDocumento.Enabled = true;
                chkIndEndose.Checked = false;
                chkIndEndose.Enabled = false;
                dtpFecAbono.Enabled = true;
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }

            btEnCartera.Enabled = !rbProtestada.Checked;
            btLetras.Enabled = rbProtestada.Checked;
            chkIndEndose.CheckedChanged += chkIndEndose_CheckedChanged;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oPlanillaBanco == null)
                {
                    oPlanillaBanco = new PlanillaBancosE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        idLocal = VariablesLocales.SesionLocal.IdLocal
                    };

                    ObtenerDiarioFile("D");
                    cboLibro.SelectedValue = "04";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());

                    txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                    cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());
                }
                else
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    chkIndEndose.CheckedChanged -= chkIndEndose_CheckedChanged;

                    BuscarDato = false;

                    txtNumero.Text = oPlanillaBanco.Numero.Trim();
                    cboBancos.SelectedValue = Convert.ToInt32(oPlanillaBanco.idBanco);
                    cboMonedas.SelectedValue = oPlanillaBanco.idMoneda.ToString();
                    cboMonedas_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboCuentasBancarias.SelectedValue = oPlanillaBanco.numCuenta.ToString();
                    dtpFecha.Value = oPlanillaBanco.Fecha.Date;

                    if (oPlanillaBanco.Producto == "D") //En Descuento
                    {
                        rbDescuento.Checked = true;
                    }

                    if (oPlanillaBanco.Producto == "L") //En Cobranza Libre
                    {
                        rbCobranza.Checked = true;
                    }

                    if (oPlanillaBanco.Producto == "G") //En Garantia
                    {
                        rbGarantia.Checked = true;
                    }

                    if (oPlanillaBanco.Producto == "P") //En Protesto
                    {
                        rbProtestada.Checked = true;
                    }

                    if (oPlanillaBanco.fecAbono != null)
                    {
                        dtpFecAbono.Value = Convert.ToDateTime(oPlanillaBanco.fecAbono);
                    }
                    else
                    {
                        dtpFecAbono.Checked = false;
                    }

                    txtMontoAbono.Text = oPlanillaBanco.MontoAbono.ToString("N2");
                    cboLibro.SelectedValue = oPlanillaBanco.idComprobante.ToString();
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboFile.SelectedValue = oPlanillaBanco.numFile.ToString();
                    cboConceptoGasto.SelectedValue = Convert.ToInt32(oPlanillaBanco.idConceptoGasto);
                    cboConceptoGasto_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboConceptoInteres.SelectedValue = Convert.ToInt32(oPlanillaBanco.idConceptoInteres);
                    cboConceptoInteres_SelectionChangeCommitted(new Object(), new EventArgs());
                    txtInteres.Text = oPlanillaBanco.Interes.ToString("N2");
                    txtGastos.Text = oPlanillaBanco.Comision.ToString("N2");
                    cboLibroRecla.SelectedValue = oPlanillaBanco.idComprobanteRec.ToString();
                    cboLibroRecla_SelectionChangeCommitted(new Object(), new EventArgs());
                    cboFileRecla.SelectedValue = oPlanillaBanco.numFileRec.ToString();

                    if (oPlanillaBanco.Generado)
                    {
                        txtVoucherIngreso.Text = oPlanillaBanco.idComprobante + " " + oPlanillaBanco.numFile + " " + oPlanillaBanco.numVoucher;
                    }

                    if (oPlanillaBanco.GeneradoRec)
                    {
                        txtVoucherRecla.Text = oPlanillaBanco.idComprobanteRec + " " + oPlanillaBanco.numFileRec + " " + oPlanillaBanco.numVoucherRec;
                    }

                    cboDocumento.SelectedValue = String.IsNullOrWhiteSpace(oPlanillaBanco.idDocumento) ? "0" : oPlanillaBanco.idDocumento;
                    txtNumDocumento.Text = oPlanillaBanco.numDocumento;
                    chkIndEndose.Checked = oPlanillaBanco.indEndosar;
                    chkIndEndose_CheckedChanged(null, null);

                    if (chkIndEndose.Checked)
                    {
                        cboBancos.Enabled = false;
                        cboMonedas.Enabled = false;
                        cboCuentasBancarias.Enabled = false;
                        cboDocumento.Enabled = false;
                        dtpFecAbono.Enabled = false;
                        txtMontoAbono.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                        txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                        txtRuc.Tag = Convert.ToInt32(oPlanillaBanco.idPersonaEndoso);
                        txtRuc.Text = oPlanillaBanco.RucEndoso;
                        txtRazonSocial.Text = oPlanillaBanco.RazonSocialEndoso;
                    }

                    txtUsuRegistra.Text = oPlanillaBanco.UsuarioRegistro;
                    txtFechaRegistro.Text = oPlanillaBanco.FechaRegistro.ToString();
                    txtUsuModifica.Text = oPlanillaBanco.UsuarioModificacion;
                    txtFechaModifica.Text = oPlanillaBanco.FechaModificacion.ToString();

                    BuscarDato = true;
                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                    chkIndEndose.CheckedChanged += chkIndEndose_CheckedChanged;
                }

                bsDetalle.DataSource = oPlanillaBanco.oListaPlanillaBancos;
                bsDetalle.ResetBindings(false);
                Sumar();

                //En Proceso = P  Anulado = A  Cerrado = C
                if (indEstado == "C")
                {
                    base.Nuevo();
                }
                else
                {
                    BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
                    pnlPrincipales.Enabled = false;
                    pnlProducto.Enabled = false;
                    pnlAsiento.Enabled = false;
                    btEnCartera.Enabled = false;
                    btLetras.Enabled = false;
                    btEliminarItem.Enabled = false;

                    if (indEstado == "A")
                    {
                        Global.MensajeComunicacion("La Planilla se encuentra ANULADA no podrá hacer modificaciones.");
                    }

                    if (indEstado == "C")
                    {
                        Global.MensajeComunicacion("La Planilla se encuentra CERRADA no podrá hacer modificaciones.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bsDetalle.EndEdit();
                Datos();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtNumero.Text.Trim()))
                {
                    if (Global.MensajeConfirmacion("Desea grabar el registro.") == DialogResult.Yes)
                    {
                        AgentaVentas.Proxy.GrabarPlanillaBancos(oPlanillaBanco, EnumOpcionGrabar.Insertar);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion("Desea actualizar el registro.") == DialogResult.Yes)
                    {
                        AgentaVentas.Proxy.GrabarPlanillaBancos(oPlanillaBanco, EnumOpcionGrabar.Actualizar);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
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
                frmPendientesAuxiliarVentas oFrm = new frmPendientesAuxiliarVentas("PL");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    Decimal MontoSaldo = 0;
                    String nomDocumento = string.Empty;

                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        MontoSaldo = item.Saldo;

                        PlanillaBancosDetE oDetalle = new PlanillaBancosDetE()
                        {
                            Letra = item.numDocumento,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            Fecha = item.FechaDocumento,
                            fecVenc = Convert.ToDateTime(item.FechaVencimiento),
                            idMoneda = item.idMoneda,
                            desMoneda = item.desMoneda,
                            Monto = item.Saldo,
                            idPersona = Convert.ToInt32(item.idPersona),
                            RazonSocial = item.RazonSocial,
                            Plaza = "15",
                            nroUnico = String.Empty,
                            idCtaCte12 = item.idCtaCte,
                            idCtaCteItem12 = item.idCtaCteItem,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy
                        };

                        oPlanillaBanco.oListaPlanillaBancos.Add(oDetalle);
                    }

                    bsDetalle.DataSource = oPlanillaBanco.oListaPlanillaBancos;
                    bsDetalle.ResetBindings(false);
                    Sumar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (oPlanillaBanco.oListaPlanillaBancos != null && oPlanillaBanco.oListaPlanillaBancos.Count > 0)
                {
                    oPlanillaBanco.oListaPlanillaBancos.Remove((PlanillaBancosDetE)bsDetalle.Current);
                    bsDetalle.DataSource = oPlanillaBanco.oListaPlanillaBancos;
                    bsDetalle.ResetBindings(false);

                    base.QuitarDetalle();
                    Sumar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (rbDescuento.Checked && !rbDescuento.Checked)
            {
                Decimal.TryParse(txtMontoAbono.Text, out decimal Abono);
                Decimal.TryParse(txtGastos.Text, out decimal Gasto);
                Decimal.TryParse(txtInteres.Text, out decimal Interes);
                Decimal.TryParse(lblTotal.Text, out decimal TotalDetalle);

                if ((Abono + Gasto + Interes) != TotalDetalle)
                {
                    Global.MensajeComunicacion("El Abono + el Gasto debe coincidir con el Total del detalles.");
                    return false;
                }

                if (Convert.ToDecimal(txtGastos.Text) > 0)
                {
                    if (String.IsNullOrWhiteSpace(((ConceptosVariosE)cboConceptoGasto.SelectedItem).codCuentaAdm))
                    {
                        Global.MensajeFault("El concepto de Gasto/Comisión escogido, no tiene configurado ninguna cuenta contable.");
                        return false;
                    }
                }

                if (Convert.ToDecimal(txtInteres.Text) > 0)
                {
                    if (String.IsNullOrWhiteSpace(((ConceptosVariosE)cboConceptoInteres.SelectedItem).codCuentaAdm))
                    {
                        Global.MensajeFault("El concepto de Interés escogido, no tiene configurado ninguna cuenta contable.");
                        return false;
                    }
                }

                foreach (PlanillaBancosDetE item in oPlanillaBanco.oListaPlanillaBancos)
                {
                    if (cboMonedas.SelectedValue.ToString() != item.idMoneda)
                    {
                        Global.MensajeComunicacion("Todas las letras tienen que tener la misma moneda que el banco.");
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmPlanillaBancos_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombos();
                Nuevo();

                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles)
                    {
                        new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                    };
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFile.Enabled = false;
                    }
                    else
                    {
                        cboFile.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFile.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = Variables.Cero.ToString();
                    }

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboLibroRecla_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibroRecla.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibroRecla.SelectedItem).ListaComprobantesFiles)
                    {
                        new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                    };
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileRecla, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboLibroRecla.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFileRecla.Enabled = false;
                    }
                    else
                    {
                        cboFileRecla.Enabled = true;
                    }

                    if (ListaFiles.Count == 2)
                    {
                        cboFileRecla.SelectedValue = ListaFiles[0].numFile;
                    }
                    else
                    {
                        cboFileRecla.SelectedValue = Variables.Cero.ToString();
                    }

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboBancos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancos.SelectedValue != null && cboMonedas.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancos.SelectedValue), cboMonedas.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancos.SelectedValue != null && cboMonedas.SelectedValue != null)
                {
                    ObtenerCuentasBancarias(Convert.ToInt32(cboBancos.SelectedValue), cboMonedas.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbCobranza_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCobranza.Checked)
                {
                    Opciones();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsDetalle_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                LblDetalle.Text = "Registros " + bsDetalle.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbDescuento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbDescuento.Checked)
                {
                    Opciones(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbGarantia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbGarantia.Checked)
                {
                    Opciones(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboConceptoGasto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboConceptoGasto.SelectedValue) != 0)
                {
                    txtGastos.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtGastos.Focus();
                }
                else
                {
                    txtGastos.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtGastos.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboConceptoInteres_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboConceptoInteres.SelectedValue) != 0)
                {
                    txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtInteres.Focus();
                }
                else
                {
                    txtInteres.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtInteres.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void chkIndEndose_CheckedChanged(object sender, EventArgs e)
        {
            Opciones();
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("El Ruc ingresado no existe");
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
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;

                        Global.MensajeFault("La Razón Social ingresada no existe");
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 1)
                {
                    e.CellStyle.BackColor = Color.Silver;
                }
                else
                {
                    e.CellStyle.SelectionBackColor = Color.White;
                    e.CellStyle.SelectionForeColor = SystemColors.MenuHighlight;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbProtestada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbProtestada.Checked)
                {
                    Opciones();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEnCartera_Click(object sender, EventArgs e)
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

        private void btLetras_Click(object sender, EventArgs e)
        {
            try
            {
                frmPendientesAuxiliarVentas oFrm = new frmPendientesAuxiliarVentas("PP");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    Decimal MontoSaldo = 0;
                    String nomDocumento = string.Empty;

                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        MontoSaldo = item.Saldo;

                        PlanillaBancosDetE oDetalle = new PlanillaBancosDetE()
                        {
                            Letra = item.numDocumento,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            Fecha = item.FechaDocumento,
                            fecVenc = Convert.ToDateTime(item.FechaVencimiento),
                            idMoneda = item.idMoneda,
                            desMoneda = item.desMoneda,
                            Monto = item.Saldo,
                            idPersona = Convert.ToInt32(item.idPersona),
                            RazonSocial = item.RazonSocial,
                            Plaza = "15",
                            nroUnico = String.Empty,
                            idCtaCte12 = item.idCtaCte,
                            idCtaCteItem12 = item.idCtaCteItem,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy
                        };

                        oPlanillaBanco.oListaPlanillaBancos.Add(oDetalle);
                    }

                    bsDetalle.DataSource = oPlanillaBanco.oListaPlanillaBancos;
                    bsDetalle.ResetBindings(false);
                    Sumar();
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
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
