using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmVoucher : FrmMantenimientoBase
    {

        #region Constructores
        
        public frmVoucher()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            InitializeComponent();            
            FormatoGrid(dgvMovimientosVouchers, false);
            AnchoColumnas();
            LlenarCombos();

            oParametrosConta = VariablesLocales.oConParametros;
        }

        //Nuevo
        public frmVoucher(Int32 il, String M, String L, String N)
            :this()
        {
            idLocal = il;
            Mes = M;
            Libro = L;
            numFile = N;
            Periodo = "Periodo - Año >> " + Mes + " - " + VariablesLocales.PeriodoContable.AnioPeriodo;

            oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo, Mes);

            if (oPeriodoContable.indCierre)
            {
                Global.MensajeComunicacion("El mes se encuentra cerrado. No puede agregar mas registros.");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }
        }

        //Estado de Pérdidas y Ganancias
        public frmVoucher(Int32 idEmpresa_, Int32 idLocal_, String AnioPeriodo_, String MesPeriodo_, String numVoucher_, String idComprobante_, String numFile_, String OFF_)
           : this()
        {
            idLocal = idLocal_;
            Mes = MesPeriodo_;
            Libro = idComprobante_;
            numFile = numFile_;
            OFF = OFF_;
            oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(idEmpresa_, idLocal_, AnioPeriodo_, MesPeriodo_, numVoucher_, idComprobante_, numFile_);
            oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(idEmpresa_, AnioPeriodo_, MesPeriodo_);

            if (oPeriodoContable.indCierre)
            {
                Global.MensajeComunicacion("El mes se encuentra cerrado. No podra hacer modificaciones.");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }

            if (oVoucher.indEstado == "A")
            {
                Global.MensajeComunicacion("El voucher se encuentra anulado no podra hacer modificaciones.");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }

            ComprobantesE com = (from x in VariablesLocales.oListaComprobantes
                                 where x.idComprobante == oVoucher.idComprobante
                                 select x).FirstOrDefault();
            ComprobantesFileE file = (from x in com.ListaComprobantesFiles
                                      where x.numFile == oVoucher.numFile
                                      select x).FirstOrDefault();
            if (file.flagAutomatico)
            {
                Global.MensajeComunicacion("El File es Automático, modifique el voucher desde el Módulo que lo Generó...!!!");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }
            else
            {
                if (oVoucher.EsAutomatico)
                {
                    Global.MensajeComunicacion("Este voucher se generó desde otro módulo, modifíquelo en el módulo correspondiente...!!");
                    indBloqueo = Variables.SI;
                    BloquearControles(false);
                }
            }
        }

        //Edición
        public frmVoucher(Int32 idEmpresa_, Int32 idLocal_, String AnioPeriodo_, String MesPeriodo_, String numVoucher_, String idComprobante_, String numFile_)
            : this()
        {
            idLocal = idLocal_;
            Mes = MesPeriodo_;
            Libro = idComprobante_;
            numFile = numFile_;

            oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(idEmpresa_, idLocal_, AnioPeriodo_, MesPeriodo_, numVoucher_, idComprobante_, numFile_);
            oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(idEmpresa_, AnioPeriodo_, MesPeriodo_);

            if (oPeriodoContable.indCierre)
            {
                Global.MensajeComunicacion("El mes se encuentra cerrado. No podra hacer modificaciones.");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }

            if (oVoucher.indEstado == "A")
            {
                Global.MensajeComunicacion("El voucher se encuentra anulado no podra hacer modificaciones.");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }

            ComprobantesE com = (from x in VariablesLocales.oListaComprobantes
                                 where x.idComprobante == oVoucher.idComprobante
                                 select x).FirstOrDefault();
            ComprobantesFileE file = (from x in com.ListaComprobantesFiles
                                      where x.numFile == oVoucher.numFile
                                      select x).FirstOrDefault();
            if (file.flagAutomatico)
            {
                Global.MensajeComunicacion("El File es Automático, modifique el voucher desde el Módulo que lo Generó...!!!");
                indBloqueo = Variables.SI;
                BloquearControles(false);
            }
            else
            {
                if (oVoucher.EsAutomatico)
                {
                    if (oVoucher.sistema == "1")//Si es de contabilidad
                    {
                        Global.MensajeComunicacion("Este voucher se generó desde otra ventana de Contabilidad, modifíquelo donde corresponde...!!");
                    }
                    else
                    {
                        Global.MensajeComunicacion("Este voucher se generó desde otro módulo, modifíquelo en el módulo correspondiente...!!");
                    }

                    indBloqueo = Variables.SI;
                    BloquearControles(false);
                }
            }
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        public VoucherE oVoucher = null;
        public Int32 Opcion = Variables.Cero;
        String OFF = String.Empty;
        String TipoPartida;
        VoucherItemE oVoucherItem = null;
        PeriodosE oPeriodoContable = null;
        PlanCuentasE oPlanCuentasGenerado = null;
        ParametrosContaE oParametrosConta;
 
        List<PlanCuentasE> oListaPlanCuentasGenerado = null;
        List<DocumentosE> ListaDocumentos;

        String Periodo;
        Int32 idLocal;
        String Mes;
        String Libro;
        String numFile;
        Int32 numItem;
        Int32 idPersona = 0;
        String RazonSocial = String.Empty;
        String numDocumentoCab = String.Empty;
        Decimal ValorIgv = Variables.Cero;
        String CuentaIgv = String.Empty;
        Boolean tmpError = false;
        Boolean Totales = false;
        String ErrorSalto = String.Empty;
        String indCtaGasto = String.Empty;
        String indBloqueo = Variables.NO;
        String CCostoCuenta = String.Empty;

        String Marque = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int32 letra = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Diarios
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes); //AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), Descripcion = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "Descripcion", false);

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMonedas.DataSource = (from x in ListaMoneda
                                     where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares) || (x.idMoneda == Variables.Cero.ToString())
                                     orderby x.idMoneda
                                     select x).ToList();
            cboMonedas.ValueMember = "idMoneda";
            cboMonedas.DisplayMember = "desMoneda";

            // Documentos
            ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                    where x.indBaja == false select x).ToList();//AgenteMaestro.Proxy.ListarDocumentos();            
            DocumentosE Fila = new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione };
            ListaDocumentos.Add(Fila);

            //Detracciones
            //List<TasasDetraccionesE> ListarDetracciones = AgenteGeneral.Proxy.ListarTasasDetraccionesActivas();
            //TasasDetraccionesE FilaNueva = new TasasDetraccionesE() { idTipoDetraccion = Variables.Cero.ToString(), NombreTemp = "<<Seleccionar Detracción>>" };
            //ListarDetracciones.Add(FilaNueva);
            //ComboHelper.LlenarCombos<TasasDetraccionesE>(cboTipoDetraccion, (from x in ListarDetracciones orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "NombreTemp");
        }

        void LlenarComboDetraccion(DateTime Fecha)
        {
            // Tipo de Detraccion
            List<TasasDetraccionesDetalleE> ListaTipoDetraccion = AgenteGeneral.Proxy.ListarDetraccionesDetActivas(Fecha);

            if (ListaTipoDetraccion.Count > 0)
            {
                ListaTipoDetraccion.Add(new TasasDetraccionesDetalleE() { idTipoDetraccion = Variables.Cero.ToString(), NombreTemp = "<<Seleccionar Detracción>>" });
                ComboHelper.RellenarCombos<TasasDetraccionesDetalleE>(cboTipoDetraccion, (from x in ListaTipoDetraccion orderby x.idTipoDetraccion select x).ToList(), "idTipoDetraccion", "NombreTemp", false);
            }
            else
            {
                Global.MensajeFault("No existe ningún Tipo de Detracción para la fecha escogida.");
                cboTipoDetraccion.DataSource = null;
            }
        }

        void BloquearCabecera()
        {
            dtpFecOperacion.Enabled = true;
            dtpFecDocumento.Enabled = true;
            cboLibro.Enabled = false;
            cboFile.Enabled = false;
            cboMonedas.Enabled = false;
            txtNumVoucher.Enabled = false;
            chkIndCosto.Enabled = false;
            btCosto.Enabled = false;
            txtGlosaGeneral.Enabled = true;
        }

        void NuevoItem()
        {
            oVoucherItem = new VoucherItemE()
            {
                idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                AnioPeriodo = VariablesLocales.PeriodoContable.AnioPeriodo,
                MesPeriodo = Mes,

                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                FechaRegistro = VariablesLocales.FechaHoy,
                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                FechaModificacion = VariablesLocales.FechaHoy
            };

            oListaPlanCuentasGenerado = new List<PlanCuentasE>();
        }

        void SumarTotales()
        {
            try
            {
                if (oVoucher != null && oVoucher.ListaVouchers != null)
                {
                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);
                    Decimal impDifSoles = 0, impDifDolares = 0;

                    impDifSoles = totDebeSoles - totHaberSoles;
                    impDifDolares = totDebeDolares - totHaberDolares;

                    //Debe o Haber
                    txtDebeSoles.Text = Decimal.Round(totDebeSoles, 2).ToString("N2");
                    txtHaberSoles.Text = Decimal.Round(totHaberSoles, 2).ToString("N2");
                    txtDebeDolares.Text = Decimal.Round(totDebeDolares, 2).ToString("N2");
                    txtHaberDolares.Text = Decimal.Round(totHaberDolares, 2).ToString("N2");

                    //Diferencias
                    txtDiferenciaDolares.Text = Decimal.Round(impDifDolares, 2).ToString("N2");
                    txtDiferenciaSoles.Text = Decimal.Round(impDifSoles, 2).ToString("N2");

                    if (impDifSoles != Variables.ValorCeroDecimal)
                    {
                        txtDiferenciaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Descuadrado);
                        txtDebeSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Descuadrado);
                        txtHaberSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Descuadrado);
                    }
                    else
                    {
                        txtDiferenciaSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Positivo);
                        txtDebeSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Positivo);
                        txtHaberSoles.CambiaColorFondo(EnumTipoEdicionCuadros.Positivo);
                    }

                    if (impDifDolares != Variables.ValorCeroDecimal)
                    {
                        txtDiferenciaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Descuadrado);
                        txtDebeDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Descuadrado);
                        txtHaberDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Descuadrado);
                    }
                    else
                    {
                        txtDiferenciaDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Positivo);
                        txtDebeDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Positivo);
                        txtHaberDolares.CambiaColorFondo(EnumTipoEdicionCuadros.Positivo);
                    }
                }
                else
                {
                    txtDiferenciaSoles.Text = "0.00";
                    txtDebeSoles.Text = "0.00";
                    txtHaberSoles.Text = "0.00";
                    txtDiferenciaDolares.Text = "0.00";
                    txtDebeDolares.Text = "0.00";
                    txtHaberDolares.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void AnchoColumnas()
        {
            dgvMovimientosVouchers.Columns[0].Width = 40; //Item
            dgvMovimientosVouchers.Columns[1].Width = 30; //Versión Plan Cuentas
            dgvMovimientosVouchers.Columns[2].Width = 50; //Cuenta
            dgvMovimientosVouchers.Columns[3].Width = 135; //Descripción de la cuenta
            dgvMovimientosVouchers.Columns[4].Width = 40; //Id Persona
            dgvMovimientosVouchers.Columns[5].Width = 135; //Razón Social
            dgvMovimientosVouchers.Columns[6].Width = 30; //Tipo Documento
            dgvMovimientosVouchers.Columns[7].Width = 40; //Serie Documento
            dgvMovimientosVouchers.Columns[8].Width = 73; //Número Documento
            dgvMovimientosVouchers.Columns[9].Width = 73; //Fecha Documento
            dgvMovimientosVouchers.Columns[10].Width = 50; //Centro de Costos
            dgvMovimientosVouchers.Columns[11].Width = 30; //D/H
            dgvMovimientosVouchers.Columns[12].Width = 75; //Monto en Soles
            dgvMovimientosVouchers.Columns[13].Width = 75; //Monto en Dolares
            dgvMovimientosVouchers.Columns[14].Width = 40; //Tipo de Cambio
            dgvMovimientosVouchers.Columns[15].Width = 30; //Tipo de Partida Presupuestal
            dgvMovimientosVouchers.Columns[16].Width = 70; //Codigo de Partida Presupuestal

            dgvMovimientosVouchers.Columns[17].Width = 50; //Nombre de la Base 

            dgvMovimientosVouchers.Columns[18].Width = 30; //Tipo de Documento Referencia
            dgvMovimientosVouchers.Columns[19].Width = 40; //Serie de Documento Referencia
            dgvMovimientosVouchers.Columns[20].Width = 73; //Numero de Documento Referencia
            dgvMovimientosVouchers.Columns[21].Width = 73; //Fecha de Referencia

            dgvMovimientosVouchers.Columns[22].Width = 58; //Indica Detraccion
            dgvMovimientosVouchers.Columns[23].Width = 58; //Indica Tipo de Cambio
            dgvMovimientosVouchers.Columns[24].Width = 58; //Indica Reparable
            dgvMovimientosVouchers.Columns[25].Width = 58; //Indica Automatica

            dgvMovimientosVouchers.Columns[26].Width = 90;  //Usuario Registro
            dgvMovimientosVouchers.Columns[27].Width = 120; //Fecha Registro
            dgvMovimientosVouchers.Columns[28].Width = 90;  //Usuario Modificación
            dgvMovimientosVouchers.Columns[29].Width = 120; //Fecha Modificación
        }

        void DatosCabecera()
        {
            try
            {
                if (String.IsNullOrEmpty(txtNumVoucher.Text.Trim()))
                {
                    oVoucher.numVoucher = Variables.Cero.ToString();
                }

                oVoucher.idComprobante = cboLibro.SelectedValue.ToString();
                oVoucher.numFile = cboFile.SelectedValue.ToString();
                oVoucher.fecTransferencia = (Nullable<DateTime>)null;
                oVoucher.numItems = oVoucher.ListaVouchers.Count;
                oVoucher.idMoneda = cboMonedas.SelectedValue.ToString();
                oVoucher.desMoneda = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;
                oVoucher.fecOperacion = dtpFecOperacion.Value.Date;
                oVoucher.fecDocumento = dtpFecDocumento.Value.Date;
                oVoucher.EsAutomatico = false;

                if (Totales)
                {
                    Decimal impDebeSoles = Variables.Cero;
                    Decimal impHaberSoles = Variables.Cero;
                    Decimal impDebeDolares = Variables.Cero;
                    Decimal impHaberDolares = Variables.Cero;

                    // Recupera los valores del texto del debe y haber
                    Decimal.TryParse(txtDebeSoles.Text, out impDebeSoles);
                    Decimal.TryParse(txtHaberSoles.Text, out impHaberSoles);
                    Decimal.TryParse(txtDebeDolares.Text, out impDebeDolares);
                    Decimal.TryParse(txtHaberDolares.Text, out impHaberDolares);

                    // Asigna los valores a la cabecera
                    oVoucher.impDebeSoles = Convert.ToDecimal(impDebeSoles);
                    oVoucher.impHaberSoles = Convert.ToDecimal(impHaberSoles);
                    oVoucher.impDebeDolares = Convert.ToDecimal(impDebeDolares);
                    oVoucher.impHaberDolares = Convert.ToDecimal(impHaberDolares);
                }
                else
                {
                    oVoucher.impDebeSoles = Variables.ValorCeroDecimal;
                    oVoucher.impHaberSoles = Variables.ValorCeroDecimal;
                    oVoucher.impDebeDolares = Variables.ValorCeroDecimal;
                    oVoucher.impHaberDolares = Variables.ValorCeroDecimal;
                }

                oVoucher.GlosaGeneral = txtGlosaGeneral.Text;
                oVoucher.tipCambio = Convert.ToDecimal(txtTipoCambio.Text);
                oVoucher.RazonSocial = RazonSocial;

                if (chkIndCosto.Checked)
                {
                    oVoucher.indHojaCosto = Variables.SI;
                    oVoucher.numHojaCosto = txtNumHojaCosto.Text;
                    oVoucher.numOrdenCompra = txtNumOc.Text;
                }
                else
                {
                    oVoucher.indHojaCosto = Variables.NO;
                    oVoucher.numHojaCosto = String.Empty;
                    oVoucher.numOrdenCompra = String.Empty;
                }

                if (String.IsNullOrEmpty(oVoucher.sistema))
                {
                    oVoucher.sistema = "1";//1 = Contabilidad
                }
                else
                {
                    oVoucher.sistema = oVoucher.sistema;
                }

                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oVoucher.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                }
                else
                {
                    oVoucher.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void BloquearControles(Boolean Flag)
        {
            pnlCabecera.Enabled = Flag;
            pnlMovimientos.Enabled = Flag;
            //pnlDetalle.Enabled = Flag;
            btNuevoItem.Enabled = Flag;            
            btEliminarItem.Enabled = Flag;
            //btAjusteBase.Enabled = Flag;
            //btDiferencia.Enabled = Flag;
            //btQuitarCuentas.Enabled = Flag;
            pnlAjustes.Enabled = Flag;
        }

        Boolean ValidarCabecera()
        {
            if (String.IsNullOrEmpty(txtTipoCambio.Text) || txtTipoCambio.Text == Variables.Cero.ToString("N3"))
            {
                Global.MensajeComunicacion("No se ha ingresado el Tipo de Cambio del dia.");
                return false;
            }

            if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeComunicacion("Debe escoger un Libro.");
                return false;
            }

            if (cboFile.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeComunicacion("Debe escoger un File.");
                return false;
            }

            if (dtpFecOperacion.Value.ToString("yyyy") != VariablesLocales.PeriodoContable.AnioPeriodo)
            {
                Global.MensajeComunicacion("Año de operación incorrecto...");
                return false;
            }

            if (oVoucher.MesPeriodo != dtpFecOperacion.Value.ToString("MM") && oVoucher.MesPeriodo != "13" && oVoucher.MesPeriodo != "00")
            {
                Global.MensajeComunicacion("Mes de operación incorrecto...");
                return false;
            }

            if (String.IsNullOrEmpty(txtGlosaGeneral.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar la Glosa General...");
                tbVouchers.SelectedTab = tpRegistro;
                txtGlosaGeneral.Focus();
                return false;
            }

            return true;
        }

        Boolean ValidarGeneracion()
        {
            if (!ValidarCabecera())
            {
                return false;
            }

            if (String.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar una Cuenta por Pagar.");
                txtCuenta.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDesCuentaIG.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar una Cuenta Ingreso / Gasto.");
                txtCuenta.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDesCuentaIG.Text))
            {
                Global.MensajeComunicacion("Debe ingresar una cuenta de Ingresos/Gastos correcta.");
                txtCuentaIG.Focus();
                return false;
            }

            if (cboDocumento.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeComunicacion("Debe escoger un tipo de documento.");
                return false;
            }

            if (String.IsNullOrEmpty(txtBaseAfecta.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar monto afecto.");
                txtBaseAfecta.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtBaseInafecta.Text.Trim()))
            {
                txtBaseInafecta.Text = Variables.Cero.ToString();
            }
            
            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuenta.Text.Trim());

            if (oPlanCuentasGenerado != null)
            {
                if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoConceptosCompraVentas.TotalGeneral)
                {
                    Global.MensajeFault("La cuenta seleccionada no pertenece a la columna de Totales definida en el Plan Contable");
                    return false;
                }
            }

            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuentaIG.Text.Trim());

            if (oPlanCuentasGenerado != null)
            {
                if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoConceptosCompraVentas.BaseImponible)
                {
                    Global.MensajeFault("La cuenta seleccionada no pertenece a la columna de Bases Imponibles definida en el Plan Contable");
                    return false;
                }
            }

            if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
            {
                if (cboReferencia.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    Global.MensajeFault("El documento escogido esta obligado a tener un documento de referencia.");
                    return false;
                }

                if (String.IsNullOrEmpty(txtSerieRef.Text) && String.IsNullOrEmpty(txtNumDocRef.Text))
                {
                    Global.MensajeFault("El documento de referencia tiene que tener un N° de documento de referencia.");
                    return false;
                }

                if (!dtpFechaRef.Checked)
                {
                    Global.MensajeFault("El documento de referencia tiene que tener una fecha.");
                    return false;
                }
            }

            if (VariablesLocales.oListaCuentaCC != null && VariablesLocales.oListaCuentaCC.Count > Variables.Cero)
            {
                if (!String.IsNullOrEmpty(CCostoCuenta.Trim()))
                {
                    if ( CCostoCuenta.Substring(1,4) != txtCCostos.Text.Trim().Substring(1,4))
                    {
                        Global.MensajeFault("La Cuenta 94 trabaja con el Centro de Costo 1003. Cambielo y vuelva a generar.");
                        return false;
                    }  
                }
            }

            if (ChkDetraccion.Checked)
            {
                if (string.IsNullOrEmpty(txtNumDetra.Text.Trim()))
                {
                    Global.MensajeFault("El check de detracción esta habilitado tiene que colocar un número.");
                    txtNumDetra.Focus();
                    return false;
                }

                if (cboTipoDetraccion.SelectedValue.ToString() == "0")
                {
                    Global.MensajeFault("El check de detracción debe escoger el tipo de detracción.");
                    txtNumDetra.Focus();
                    return false;
                }
            }

            return true;
        }

        void HabilitaTextBoxMovimientos(String Tipo)
        {
            if (oPlanCuentasGenerado != null)
            {
                if (Tipo != "IG")
                {
                    if (oPlanCuentasGenerado.indSolicitaAnexo == Variables.SI)
                    {
                        Extensores.CambiaColorFondo(txtRazonSocial, EnumTipoEdicionCuadros.Desbloquear);
                        Extensores.CambiaColorFondo(txtRuc, EnumTipoEdicionCuadros.Desbloquear);
                        btRuc.Enabled = true;
                    }
                    else
                    {
                        Extensores.CambiaColorFondo(txtRazonSocial, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                        Extensores.CambiaColorFondo(txtRuc, EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                        btRuc.Enabled = false;
                    }

                    if (oPlanCuentasGenerado.indSolicitaDcto == Variables.SI)
                    {
                        Extensores.CambiaColorFondo(cboDocumento, EnumTipoEdicionCuadros.Desbloquear);
                        Extensores.CambiaColorFondo(txtSerie, EnumTipoEdicionCuadros.Desbloquear);
                        Extensores.CambiaColorFondo(txtNumDoc, EnumTipoEdicionCuadros.Desbloquear);
                        Extensores.CambiaColorFondo(dtpFecDocumento, EnumTipoEdicionCuadros.Desbloquear);
                    }
                    else
                    {
                        Extensores.CambiaColorFondo(cboDocumento, EnumTipoEdicionCuadros.Bloquear);
                        Extensores.CambiaColorFondo(txtSerie, EnumTipoEdicionCuadros.Bloquear);
                        Extensores.CambiaColorFondo(txtNumDoc, EnumTipoEdicionCuadros.Bloquear);
                        Extensores.CambiaColorFondo(dtpFecDocumento, EnumTipoEdicionCuadros.Bloquear);
                    }
                }
                else
                {
                    if (oPlanCuentasGenerado.indSolicitaCentroCosto == Variables.SI)
                    {
                        Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Desbloquear);
                        btCentroC.Enabled = true;
                    }
                    else
                    {
                        Extensores.CambiaColorFondo(txtCCostos, EnumTipoEdicionCuadros.Bloquear);
                        btCentroC.Enabled = false;
                    }
                } 
            }
        }

        void CuentasPorDefecto()
        {
            if (cboLibro.SelectedValue.ToString() == Variables.RegistroCompra)
            {
                if (cboMonedas.SelectedValue.ToString() == Variables.Dolares)
                {
                    txtCuenta.Text = oParametrosConta.CompraD;
                }
                else if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                {
                    txtCuenta.Text = oParametrosConta.CompraS;
                }
            }
            else if (cboLibro.SelectedValue.ToString() == Variables.RegistroVenta)
            {
                if (cboMonedas.SelectedValue.ToString() == Variables.Dolares)
                {
                    txtCuenta.Text = oParametrosConta.VentaD;
                }
                else if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                {
                    txtCuenta.Text = oParametrosConta.VentaS;
                }
            }
            else
            {
                txtCuenta.Text = String.Empty;
                txtDesCuenta.Text = String.Empty;
                txtCuentaIG.Text = String.Empty;
                txtDesCuentaIG.Text = String.Empty;
            }

            //Comprobando si la cuenta existe...
            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuenta.Text.Trim());

            if (oPlanCuentasGenerado != null)
            {
                txtDesCuenta.Text = oPlanCuentasGenerado.Descripcion;
                HabilitaTextBoxMovimientos("CN");
            }
            else
            {
                txtCuenta.Text = String.Empty;
                txtDesCuenta.Text = String.Empty;
                txtCuentaIG.Text = String.Empty;
                txtDesCuentaIG.Text = String.Empty;
            } 
        }

        VoucherItemE CuentaAutomatica(VoucherItemE VoucherItem_, String Cuenta)
        {
            VoucherItemE oItemVoucherAutomatico = new VoucherItemE();
            PlanCuentasE oCuenta = VariablesLocales.ObtenerPlanCuenta(Cuenta);
            Int32 Item = Convert.ToInt32(oVoucher.ListaVouchers.Max(mx => mx.numItem)) + 1;

            if (oCuenta != null)
            {
                oItemVoucherAutomatico.numItem = String.Format("{0:00000}", Item);
                oItemVoucherAutomatico.idComprobante = cboLibro.SelectedValue.ToString();
                oItemVoucherAutomatico.numFile = cboFile.SelectedValue.ToString();

                #region Si la cuenta pide Razon Social

                if (oCuenta.indSolicitaAnexo == Variables.SI)
                {
                    if (String.IsNullOrEmpty(VoucherItem_.RazonSocial))
                    {
                        oItemVoucherAutomatico.idPersona = (Nullable<Int32>)null;
                        oItemVoucherAutomatico.RazonSocial = String.Empty; 
                    }
                    else
                    {
                        oItemVoucherAutomatico.idPersona = VoucherItem_.idPersona;
                        oItemVoucherAutomatico.RazonSocial = VoucherItem_.RazonSocial;
                    }
                }
                else
                {
                    oItemVoucherAutomatico.idPersona = (Nullable<Int32>)null;
                    oItemVoucherAutomatico.RazonSocial = String.Empty;
                }

                #endregion

                oItemVoucherAutomatico.idMoneda = VoucherItem_.idMoneda;
                oItemVoucherAutomatico.tipCambio = VoucherItem_.tipCambio;
                oItemVoucherAutomatico.indCambio = Variables.SI;

                String idCCostoTmp = VoucherItem_.idCCostos;

                #region Si solicita Centro de Costo

                if (oCuenta.indSolicitaCentroCosto == Variables.SI)
                {
                    if (!String.IsNullOrEmpty(idCCostoTmp))
                    {
                        oItemVoucherAutomatico.idCCostos = idCCostoTmp;
                    }
                    else
                    {
                        Global.MensajeComunicacion("La cuenta " + oCuenta.codCuenta + " necesita un Centro de Costo.");
                    }
                }
                else
                {
                    oItemVoucherAutomatico.idCCostos = String.Empty;
                }

                #endregion

                oItemVoucherAutomatico.numVerPlanCuentas = oCuenta.numVerPlanCuentas;
                oItemVoucherAutomatico.codCuenta = oCuenta.codCuenta;
                oItemVoucherAutomatico.desCuenta = oCuenta.Descripcion;

                #region Si solicita Documento

                if (oCuenta.indSolicitaDcto == Variables.SI)
                {
                    oItemVoucherAutomatico.idDocumento = VoucherItem_.idDocumento;
                    oItemVoucherAutomatico.serDocumento = VoucherItem_.serDocumento;
                    oItemVoucherAutomatico.numDocumento = VoucherItem_.numDocumento;
                    oItemVoucherAutomatico.fecDocumento = VoucherItem_.fecDocumento;
                    oItemVoucherAutomatico.fecVencimiento = VoucherItem_.fecVencimiento;
                    oItemVoucherAutomatico.fecRecepcion = VoucherItem_.fecRecepcion;

                    if (String.IsNullOrEmpty(VoucherItem_.serDocumento))
                    {
                        oItemVoucherAutomatico.numDocumentoPresu = VoucherItem_.idDocumento + " " + VoucherItem_.numDocumento; ;    
                    }
                    else
                    {
                        oItemVoucherAutomatico.numDocumentoPresu = VoucherItem_.idDocumento + " " + VoucherItem_.serDocumento + "-" + VoucherItem_.numDocumento; ;
                    }                    

                    //if (VoucherItem_.idDocumento == "NC" || VoucherItem_.idDocumento == "ND")
                    //{
                        oItemVoucherAutomatico.idDocumentoRef = VoucherItem_.idDocumentoRef;
                        oItemVoucherAutomatico.serDocumentoRef = VoucherItem_.serDocumentoRef;
                        oItemVoucherAutomatico.numDocumentoRef = VoucherItem_.numDocumentoRef;
                        oItemVoucherAutomatico.fecDocumentoRef = VoucherItem_.fecDocumentoRef;
                    //}
                }
                else
                {
                    oItemVoucherAutomatico.idDocumento = String.Empty;
                    oItemVoucherAutomatico.serDocumento = String.Empty;
                    oItemVoucherAutomatico.numDocumento = String.Empty;
                    oItemVoucherAutomatico.fecDocumento = (Nullable<DateTime>)null;
                    oItemVoucherAutomatico.fecVencimiento = (Nullable<DateTime>)null;
                    oItemVoucherAutomatico.fecRecepcion = (Nullable<DateTime>)null;

                    oItemVoucherAutomatico.idDocumentoRef = String.Empty;
                    oItemVoucherAutomatico.serDocumentoRef = String.Empty;
                    oItemVoucherAutomatico.numDocumentoRef = String.Empty;
                    oItemVoucherAutomatico.fecDocumentoRef = (Nullable<DateTime>)null;
                    oItemVoucherAutomatico.numDocumentoPresu = String.Empty;
                }

                #endregion

                oItemVoucherAutomatico.desGlosa = VoucherItem_.desGlosa;

                #region Montos

                oItemVoucherAutomatico.impSoles = VoucherItem_.impSoles;
                oItemVoucherAutomatico.impDolares = VoucherItem_.impDolares;

                #endregion

                #region Naturaleza de la cuenta

                if (oCuenta.codCuenta == VoucherItem_.codCuentaDestino)
                {
                    oItemVoucherAutomatico.indDebeHaber = VoucherItem_.indDebeHaber;
                }

                if (oCuenta.codCuenta == VoucherItem_.codCuentaTransferencia)
                {
                    if(VoucherItem_.indDebeHaber == Variables.Debe)
                    {
                        oItemVoucherAutomatico.indDebeHaber = Variables.Haber;
                    }
                    else
                    {
                        oItemVoucherAutomatico.indDebeHaber = Variables.Debe;
                    }
                }

                #endregion

                oItemVoucherAutomatico.indAutomatica = Variables.SI;
                oItemVoucherAutomatico.CorrelativoAjuste = String.Empty;
                oItemVoucherAutomatico.codFteFin = String.Empty;
                oItemVoucherAutomatico.codProgramaCred = String.Empty;

                oItemVoucherAutomatico.codColumnaCoven = null;
                oItemVoucherAutomatico.NombreColumna = String.Empty;

                #region Detraccion

                oItemVoucherAutomatico.flagDetraccion = Variables.NO;
                oItemVoucherAutomatico.numDetraccion = String.Empty;
                oItemVoucherAutomatico.fecDetraccion = (Nullable<DateTime>)null;
                oItemVoucherAutomatico.tipDetraccion = String.Empty;
                oItemVoucherAutomatico.MontoDetraccion = Variables.ValorCeroDecimal;
                oItemVoucherAutomatico.TasaDetraccion = Variables.ValorCeroDecimal;               

                #endregion

                oItemVoucherAutomatico.depAduanera = null;
                oItemVoucherAutomatico.nroDua = String.Empty;
                oItemVoucherAutomatico.AnioDua = String.Empty;
                oItemVoucherAutomatico.idAlmacen = String.Empty;
                oItemVoucherAutomatico.tipMovimientoAlmacen = String.Empty;
                oItemVoucherAutomatico.numDocumentoAlmacen = String.Empty;
                oItemVoucherAutomatico.numItemAlmacen = String.Empty;
                oItemVoucherAutomatico.CajaSucursal = String.Empty;
                oItemVoucherAutomatico.indCompra = String.Empty;
                oItemVoucherAutomatico.indConciliado = "N";
                oItemVoucherAutomatico.indMovimientoAnterior = String.Empty;

                #region Partida Presupuestal
                
                if (!String.IsNullOrEmpty(oCuenta.tipPartidaPresu))
                {
                    oItemVoucherAutomatico.tipPartidaPresu = oCuenta.tipPartidaPresu;
                    oItemVoucherAutomatico.codPartidaPresu = oCuenta.codPartidaPresu;
                }
                else
                {
                    oItemVoucherAutomatico.tipPartidaPresu = String.Empty;
                    oItemVoucherAutomatico.codPartidaPresu = String.Empty;
                } 

                #endregion

                oItemVoucherAutomatico.idConceptoGasto = (Nullable<Int32>)null;
                oItemVoucherAutomatico.idCampana = (Nullable<Int32>)null;
                oItemVoucherAutomatico.codMedioPago = Variables.Cero;
                oItemVoucherAutomatico.indReparable = Variables.NO;
                oItemVoucherAutomatico.idConceptoRep = (Nullable<Int32>)null;
                oItemVoucherAutomatico.desReferenciaRep = String.Empty;

                #region Para la CtaCte

                oItemVoucherAutomatico.idAccion = EnumAccionCtaCte.Z.ToString();
                oItemVoucherAutomatico.idCtaCte = (Nullable<Int32>)null;
                oItemVoucherAutomatico.idCtaCteItem = (Nullable<Int32>)null;
                oItemVoucherAutomatico.indCtaCte = Variables.NO;

                #endregion

                oItemVoucherAutomatico.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                oItemVoucherAutomatico.FechaRegistro = VariablesLocales.FechaHoy;
                oItemVoucherAutomatico.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                oItemVoucherAutomatico.FechaModificacion = VariablesLocales.FechaHoy;
            }            

            return oItemVoucherAutomatico;
        }

        VoucherItemE ItemDetraccion(VoucherItemE VoucherItem_, String indDH, String Cuenta, String Detra)
        {
            Int32 Item = Convert.ToInt32(oVoucher.ListaVouchers.Max(mx => mx.numItem)) + 1;
            PlanCuentasE oCuenta = VariablesLocales.ObtenerPlanCuenta(Cuenta);
            VoucherItemE oItemVoucherDetra = new VoucherItemE()
            {
                numItem = String.Format("{0:00000}", Item),
                idComprobante = cboLibro.SelectedValue.ToString(),
                numFile = cboFile.SelectedValue.ToString()
            };

            #region Si la cuenta pide Razon Social

            if (oCuenta.indSolicitaAnexo == Variables.SI)
            {
                if (String.IsNullOrEmpty(VoucherItem_.RazonSocial))
                {
                    oItemVoucherDetra.idPersona = (Nullable<Int32>)null;
                    oItemVoucherDetra.RazonSocial = String.Empty;
                }
                else
                {
                    oItemVoucherDetra.idPersona = VoucherItem_.idPersona;
                    oItemVoucherDetra.RazonSocial = VoucherItem_.RazonSocial;
                }
            }
            else
            {
                oItemVoucherDetra.idPersona = (Nullable<Int32>)null;
                oItemVoucherDetra.RazonSocial = String.Empty;
            }

            #endregion

            oItemVoucherDetra.idMoneda = VoucherItem_.idMoneda;
            oItemVoucherDetra.tipCambio = VoucherItem_.tipCambio;
            oItemVoucherDetra.indCambio = Variables.SI;

            oItemVoucherDetra.idCCostos = String.Empty;

            oItemVoucherDetra.numVerPlanCuentas = VoucherItem_.numVerPlanCuentas;
            oItemVoucherDetra.codCuenta = Cuenta;
            oItemVoucherDetra.desCuenta = VoucherItem_.desCuenta;

            #region Si solicita Documento

            if (oCuenta.indSolicitaDcto == Variables.SI)
            {
                if (Detra == Variables.NO)
                {
                    oItemVoucherDetra.idDocumento = VoucherItem_.idDocumento;
                    oItemVoucherDetra.serDocumento = VoucherItem_.serDocumento;
                    oItemVoucherDetra.numDocumento = VoucherItem_.numDocumento;
                    oItemVoucherDetra.fecDocumento = VoucherItem_.fecDocumento;
                    oItemVoucherDetra.fecVencimiento = VoucherItem_.fecVencimiento;
                    oItemVoucherDetra.fecRecepcion = VoucherItem_.fecRecepcion;

                    if (String.IsNullOrEmpty(VoucherItem_.serDocumento))
                    {
                        oItemVoucherDetra.numDocumentoPresu = VoucherItem_.idDocumento + " " + VoucherItem_.numDocumento; ;
                    }
                    else
                    {
                        oItemVoucherDetra.numDocumentoPresu = VoucherItem_.idDocumento + " " + VoucherItem_.serDocumento + "-" + VoucherItem_.numDocumento; ;
                    } 
                }
                else
                {
                    oItemVoucherDetra.idDocumento = "CD";
                    oItemVoucherDetra.serDocumento = String.Empty;
                    oItemVoucherDetra.numDocumento = VoucherItem_.numDetraccion;
                    oItemVoucherDetra.fecDocumento = VoucherItem_.fecDetraccion;
                    oItemVoucherDetra.fecVencimiento = null;
                    oItemVoucherDetra.fecRecepcion = null;

                    oItemVoucherDetra.numDocumentoPresu = VoucherItem_.idDocumento + " " + VoucherItem_.numDocumento; ;
                }

                oItemVoucherDetra.idDocumentoRef = VoucherItem_.idDocumentoRef;
                oItemVoucherDetra.serDocumentoRef = VoucherItem_.serDocumentoRef;
                oItemVoucherDetra.numDocumentoRef = VoucherItem_.numDocumentoRef;
                oItemVoucherDetra.fecDocumentoRef = VoucherItem_.fecDocumentoRef;
            }
            else
            {
                oItemVoucherDetra.idDocumento = String.Empty;
                oItemVoucherDetra.serDocumento = String.Empty;
                oItemVoucherDetra.numDocumento = String.Empty;
                oItemVoucherDetra.fecDocumento = null;
                oItemVoucherDetra.fecVencimiento = null;
                oItemVoucherDetra.fecRecepcion = null;

                oItemVoucherDetra.idDocumentoRef = String.Empty;
                oItemVoucherDetra.serDocumentoRef = String.Empty;
                oItemVoucherDetra.numDocumentoRef = String.Empty;
                oItemVoucherDetra.fecDocumentoRef = null;

                oItemVoucherDetra.numDocumentoPresu = String.Empty;
            }

            #endregion
            
            oItemVoucherDetra.desGlosa = VoucherItem_.desGlosa;

            if (VoucherItem_.idMoneda == Variables.Soles)
            {
                oItemVoucherDetra.impSoles = Convert.ToDecimal(Math.Round(Convert.ToDecimal(VoucherItem_.MontoDetraccion), MidpointRounding.AwayFromZero));
                oItemVoucherDetra.impDolares = Convert.ToDecimal(oItemVoucherDetra.impSoles / VoucherItem_.tipCambio);
            }
            else
            {
                oItemVoucherDetra.impDolares = Convert.ToDecimal(Convert.ToDecimal(VoucherItem_.MontoDetraccion));
                oItemVoucherDetra.impSoles   = Convert.ToDecimal(Math.Round(Convert.ToDecimal(oItemVoucherDetra.impDolares * VoucherItem_.tipCambio), MidpointRounding.AwayFromZero));
            }

            oItemVoucherDetra.indDebeHaber = indDH;
            oItemVoucherDetra.indAutomatica = Variables.SI;
            oItemVoucherDetra.CorrelativoAjuste = String.Empty;
            oItemVoucherDetra.codFteFin = String.Empty;
            oItemVoucherDetra.codProgramaCred = String.Empty;
            oItemVoucherDetra.codColumnaCoven = null;
            oItemVoucherDetra.NombreColumna = String.Empty;
            oItemVoucherDetra.flagDetraccion = Variables.NO;
            oItemVoucherDetra.numDetraccion = String.Empty;
            oItemVoucherDetra.fecDetraccion = (Nullable<DateTime>)null;
            oItemVoucherDetra.tipDetraccion = String.Empty;
            oItemVoucherDetra.MontoDetraccion = Variables.ValorCeroDecimal;
            oItemVoucherDetra.TasaDetraccion = Variables.ValorCeroDecimal;
            oItemVoucherDetra.depAduanera = null;
            oItemVoucherDetra.nroDua = String.Empty;
            oItemVoucherDetra.AnioDua = String.Empty;
            oItemVoucherDetra.idAlmacen = String.Empty;
            oItemVoucherDetra.tipMovimientoAlmacen = String.Empty;
            oItemVoucherDetra.numDocumentoAlmacen = String.Empty;
            oItemVoucherDetra.numItemAlmacen = String.Empty;
            oItemVoucherDetra.CajaSucursal = String.Empty;
            oItemVoucherDetra.indCompra = String.Empty;
            oItemVoucherDetra.indConciliado = "N";
            oItemVoucherDetra.indMovimientoAnterior = String.Empty;
            oItemVoucherDetra.tipPartidaPresu = String.Empty;
            oItemVoucherDetra.codPartidaPresu = String.Empty;
            oItemVoucherDetra.idConceptoGasto = (Nullable<Int32>)null;
            oItemVoucherDetra.idCampana = (Nullable<Int32>)null;
            oItemVoucherDetra.codMedioPago = Variables.Cero;
            oItemVoucherDetra.indReparable = Variables.NO;
            oItemVoucherDetra.idConceptoRep = (Nullable<Int32>)null;
            oItemVoucherDetra.desReferenciaRep = String.Empty;
            oItemVoucherDetra.idAccion = EnumAccionCtaCte.Z.ToString();
            oItemVoucherDetra.idCtaCte = (Nullable<Int32>)null;
            oItemVoucherDetra.idCtaCteItem = (Nullable<Int32>)null;
            oItemVoucherDetra.indCtaCte = Variables.NO;
            oItemVoucherDetra.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            oItemVoucherDetra.FechaRegistro = VariablesLocales.FechaHoy;
            oItemVoucherDetra.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            oItemVoucherDetra.FechaModificacion = VariablesLocales.FechaHoy;

            return oItemVoucherDetra;
        }

        void EditarDetalle(DataGridViewCellEventArgs e, VoucherItemE oItem)
        {
            DatosCabecera();
            String Item = oVoucher.ListaVouchers[e.RowIndex].numItem;
            frmDetalleVoucher oFrm = new frmDetalleVoucher(oVoucher, oItem, null, indBloqueo);

            #region Pasando totales
            
            oFrm.txtDiferenciaSoles.Text = this.txtDiferenciaSoles.Text;
            oFrm.txtDiferenciaDolares.Text = this.txtDiferenciaDolares.Text;
            oFrm.txtDebeSoles.Text = this.txtDebeSoles.Text;
            oFrm.txtDebeDolares.Text = this.txtDebeDolares.Text;
            oFrm.txtHaberSoles.Text = this.txtHaberSoles.Text;
            oFrm.txtHaberDolares.Text = this.txtHaberDolares.Text; 

            #endregion

            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.oVoucherDet != null)
                {
                    VoucherItemE VoucherModificado = oFrm.oVoucherDet;
                    VoucherModificado.numItem = Item;
                    oVoucher.ListaVouchers[e.RowIndex] = VoucherModificado;
                    EliminarAutomaticos();
                    SumarTotales();
                    bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                    bsListaVouchers.ResetBindings(false);
                }
                else
                {
                    if (oFrm.oListaVouchers.Count > Variables.Cero)
                    {
                        Int32 Correlativo = Variables.Cero;
                        List<VoucherItemE> oListaTemporal = new List<VoucherItemE>(oFrm.oListaVouchers);
                        EliminarAutomaticos();
                        oVoucher.ListaVouchers.RemoveAt(e.RowIndex);

                        foreach (VoucherItemE item in oListaTemporal)
                        {
                            if (oVoucher.ListaVouchers.Count == Variables.Cero)
                            {
                                Correlativo = Variables.ValorUno;
                            }
                            else
                            {
                                Correlativo = Convert.ToInt32(oVoucher.ListaVouchers.Max(mx => mx.numItem)) + 1;
                            }

                            item.numItem = String.Format("{0:00000}", Correlativo);
                            oVoucher.ListaVouchers.Add(item);
                        }

                        bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                        bsListaVouchers.ResetBindings(false);
                        SumarTotales();
                    }
                }

                base.AgregarDetalle();
            }
        }

        void RevisarLibro(String TipoComprobante)
        {
            if (Convert.ToInt32(TipoComprobante) != (Int32)enumLibro.RegistroCompras)
            {
                btDiferencia.Enabled = true; 
            }
            else
            {
                btDiferencia.Enabled = false;
            }

            if (Convert.ToInt32(TipoComprobante) == (Int32)enumLibro.RegistroCompras || Convert.ToInt32(TipoComprobante) == (Int32)enumLibro.RegistroVentas)
            {
                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    pnlMovimientos.Enabled = true;
                }
                else
                {
                    pnlMovimientos.Enabled = false;
                }
            }
            else
            {
                pnlMovimientos.Enabled = false;
            }
        }

        void AjusteDiferenciaCambio(String Moneda, Decimal Diferencia)
        {
            String Naturaleza = String.Empty;
            Boolean Ajustar = false;
            String CuentaGanancia = String.Empty;
            String CuentaPerdida = String.Empty;
            String CuentaDif = String.Empty;
            String ccGastos = String.Empty;

            #region Parametros de las cuentas por defecto

            CuentaGanancia = oParametrosConta.Ganancia;
            CuentaPerdida = oParametrosConta.Perdida;
            ccGastos = oParametrosConta.Costo;

            #endregion

            if (!String.IsNullOrEmpty(CuentaPerdida) && !String.IsNullOrEmpty(CuentaGanancia))
            {
                #region Verificar la diferencia

                if (Diferencia < Variables.Cero)
                {
                    CuentaDif = CuentaPerdida;
                    Naturaleza = Variables.Debe;
                    Ajustar = true;
                }
                else if (Diferencia > Variables.Cero)
                {
                    CuentaDif = CuentaGanancia;
                    Naturaleza = Variables.Haber;
                    Ajustar = true;
                } 

                #endregion

                if (Ajustar)
                {
                    Decimal MontoDiferencia = Math.Abs(Diferencia);

                    PlanCuentasE ctaTemporal = VariablesLocales.ObtenerPlanCuenta(CuentaDif);
                    VoucherItemE viTemporal = new VoucherItemE();

                    if (ctaTemporal != null)
                    {
                        Int32 Item = Convert.ToInt32(oVoucher.ListaVouchers.Max(mx => mx.numItem)) + 1;
                        viTemporal.idComprobante = cboLibro.SelectedValue.ToString();
                        viTemporal.numFile = cboFile.SelectedValue.ToString();
                        viTemporal.numItem = String.Format("{0:00000}", Item);

                        #region Si la cuenta pide Razon Social

                        if (ctaTemporal.indSolicitaAnexo == Variables.SI)
                        {
                            viTemporal.idPersona = Variables.Cero;
                            viTemporal.RazonSocial = String.Empty;
                        }
                        else
                        {
                            viTemporal.idPersona = (Nullable<Int32>)null;
                            viTemporal.RazonSocial = String.Empty;
                        }

                        #endregion

                        #region Tipo de Cambio
                        
                        viTemporal.idMoneda = cboMonedas.SelectedValue.ToString();
                        viTemporal.tipCambio = Convert.ToDecimal(txtTipoCambio.Text);
                        viTemporal.indCambio = Variables.NO; 

                        #endregion

                        #region Si solicita Centro de Costo

                        if (ctaTemporal.indSolicitaCentroCosto == Variables.SI)
                        {
                            viTemporal.idCCostos = ccGastos;
                        }
                        else
                        {
                            viTemporal.idCCostos = String.Empty;
                        }

                        #endregion

                        #region Cuentas

                        viTemporal.numVerPlanCuentas = ctaTemporal.numVerPlanCuentas;
                        viTemporal.codCuenta = ctaTemporal.codCuenta;
                        viTemporal.desCuenta = ctaTemporal.Descripcion;

                        if (ctaTemporal.indCuentaGastos == Variables.SI)
                        {
                            viTemporal.codCuentaDestino = ctaTemporal.codCuentaDestino;
                            viTemporal.codCuentaTransferencia = ctaTemporal.codCuentaTransferencia;
                            viTemporal.indCuentaGastos = Variables.SI;
                        }

                        #endregion

                        #region Documentos

                        viTemporal.idDocumento = String.Empty;
                        viTemporal.serDocumento = String.Empty;
                        viTemporal.numDocumento = String.Empty;
                        viTemporal.fecDocumento = (Nullable<DateTime>)null;
                        viTemporal.fecVencimiento = (Nullable<DateTime>)null;
                        viTemporal.fecRecepcion = (Nullable<DateTime>)null;

                        viTemporal.idDocumentoRef = String.Empty;
                        viTemporal.serDocumentoRef = String.Empty;
                        viTemporal.numDocumentoRef = String.Empty;
                        viTemporal.fecDocumentoRef = (Nullable<DateTime>)null;

                        #endregion

                        viTemporal.desGlosa = txtGlosaGeneral.Text;

                        #region Montos

                        if (Moneda == "S")
                        {
                            viTemporal.impSoles = Math.Abs(Diferencia);
                            viTemporal.impDolares = Variables.ValorCeroDecimal;
                        }
                        else
                        {
                            viTemporal.impSoles = Variables.ValorCeroDecimal;
                            viTemporal.impDolares = Math.Abs(Diferencia);
                        }

                        #endregion

                        #region Naturaleza de la cuenta

                        viTemporal.indDebeHaber = Naturaleza;

                        #endregion

                        viTemporal.indAutomatica = Variables.NO;
                        viTemporal.CorrelativoAjuste = String.Empty;
                        viTemporal.codFteFin = String.Empty;
                        viTemporal.codProgramaCred = String.Empty;
                        
                        #region Compra Venta

                        viTemporal.codColumnaCoven = Variables.Cero;
                        viTemporal.NombreColumna = String.Empty; 
                        
                        #endregion

                        #region Detraccion

                        viTemporal.flagDetraccion = Variables.NO;
                        viTemporal.numDetraccion = String.Empty;
                        viTemporal.fecDetraccion = (Nullable<DateTime>)null;
                        viTemporal.tipDetraccion = String.Empty;
                        viTemporal.MontoDetraccion = Variables.ValorCeroDecimal;
                        viTemporal.TasaDetraccion = Variables.ValorCeroDecimal;

                        #endregion

                        viTemporal.depAduanera = null;
                        viTemporal.nroDua = String.Empty;
                        viTemporal.AnioDua = String.Empty;
                        viTemporal.idAlmacen = String.Empty;
                        viTemporal.tipMovimientoAlmacen = String.Empty;
                        viTemporal.numDocumentoAlmacen = String.Empty;
                        viTemporal.numItemAlmacen = String.Empty;
                        viTemporal.CajaSucursal = String.Empty;
                        viTemporal.indCompra = String.Empty;
                        viTemporal.indConciliado = "N";
                        viTemporal.indMovimientoAnterior = String.Empty;

                        #region Partida Presupuestal
                        
                        if (!String.IsNullOrEmpty(ctaTemporal.tipPartidaPresu))
                        {
                            viTemporal.tipPartidaPresu = ctaTemporal.tipPartidaPresu;
                            viTemporal.codPartidaPresu = ctaTemporal.codPartidaPresu;
                        }
                        else
                        {
                            viTemporal.tipPartidaPresu = String.Empty;
                            viTemporal.codPartidaPresu = String.Empty;
                        } 

                        #endregion

                        viTemporal.numDocumentoPresu = String.Empty;
                        viTemporal.idConceptoGasto = (Nullable<Int32>)null;
                        viTemporal.idCampana = (Nullable<Int32>)null;
                        viTemporal.codMedioPago = Variables.Cero;
                        viTemporal.indReparable = Variables.NO;
                        viTemporal.idConceptoRep = (Nullable<Int32>)null;
                        viTemporal.desReferenciaRep = String.Empty;

                        viTemporal.idAccion = EnumAccionCtaCte.Z.ToString();
                        viTemporal.idCtaCte = (Nullable<Int32>)null;
                        viTemporal.idCtaCteItem = (Nullable<Int32>)null;

                        viTemporal.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        viTemporal.FechaRegistro = VariablesLocales.FechaHoy;
                        viTemporal.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        viTemporal.FechaModificacion = VariablesLocales.FechaHoy;

                        oVoucher.ListaVouchers.Add(viTemporal);
                        bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                        bsListaVouchers.ResetBindings(false);
                    }
                }
            }
        }

        void CalculaDatosCabecera()
        {
            if (oVoucher.ListaVouchers.Count > Variables.Cero)
            {
                foreach (VoucherItemE item in oVoucher.ListaVouchers)
                {
                    if ((oVoucher.idComprobante == "04" || oVoucher.idComprobante == "05" || oVoucher.idComprobante == "21"))
                    {
                        if (Global.Izquierda(item.codCuenta, 3) == "104" || Global.Izquierda(item.codCuenta, 3) == "103" || Global.Izquierda(item.codCuenta, 3) == "102")
                        {
                            //if (!String.IsNullOrEmpty(item.idDocumento))
                            //{
                            //    idDocumento = item.idDocumento;
                            //}

                            //if (!String.IsNullOrEmpty(item.serDocumento))
                            //{
                            //    Serie = item.serDocumento;
                            //}

                            //if (!String.IsNullOrEmpty(item.numDocumento))
                            //{
                            //    Numero = item.numDocumento;
                            //}

                            if (!String.IsNullOrEmpty(item.serDocumento))
                            {
                                oVoucher.numDocumentoPresu = item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento;
                            }
                            else
                            {
                                oVoucher.numDocumentoPresu = item.idDocumento + " " + item.numDocumento;
                            }
                            //if (oVoucher.numDocumentoPresu == idDocumento + " " + Serie + "-" + Numero)
                            //{

                                if (oVoucher.idMoneda == Variables.Soles)
                                {
                                    oVoucher.impMonOrigDeb = item.impSoles;
                                    oVoucher.impMonOrigHab = item.impSoles;
                                }
                                else
                                {
                                    oVoucher.impMonOrigDeb = item.impDolares;
                                    oVoucher.impMonOrigHab = item.impDolares;
                                }

                            //}
                        } 
                    }

                    if (oVoucher.idComprobante == Variables.RegistroVenta || oVoucher.idComprobante == Variables.RegistroCompra)
                    {
                        if (item.codColumnaCoven == (Int32)EnumTipoTotal.Total)
                        {
                            if (!String.IsNullOrEmpty(item.serDocumento))
                            {
                                oVoucher.numDocumentoPresu = item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento;
                            }
                            else
                            {
                                oVoucher.numDocumentoPresu = item.idDocumento + " " + item.numDocumento;
                            }

                            if (oVoucher.idMoneda == Variables.Soles)
                            {
                                oVoucher.impMonOrigDeb = item.impSoles;
                                oVoucher.impMonOrigHab = item.impSoles;
                            }
                            else
                            {
                                oVoucher.impMonOrigDeb = item.impDolares;
                                oVoucher.impMonOrigHab = item.impDolares;
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(item.serDocumento))
                        {
                            oVoucher.numDocumentoPresu = item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento;
                        }
                        else
                        {
                            oVoucher.numDocumentoPresu = item.idDocumento + " " + item.numDocumento;
                        }
                    }
                }
            }

            // Para la Referencia en la Cabecera del Voucher Nombre de idPersona del Item
            if (String.IsNullOrEmpty(oVoucher.RazonSocial))
            {
                oVoucher.RazonSocial = RazonSocial;
            }

            // Para la Referencia en la Cabecera del voucher Numero y tipo de documento del item
            oVoucher.numDocumentoPresu = numDocumentoCab;
            if (String.IsNullOrEmpty(oVoucher.numDocumentoPresu))
            {
                oVoucher.numDocumentoPresu = "";
            }

            // Asignando datos para grabar en la cabecera
            oVoucher.numItems = oVoucher.ListaVouchers.Count;

            Decimal impDebeSoles = Variables.Cero;
            Decimal impHaberSoles = Variables.Cero;
            Decimal impDebeDolares = Variables.Cero;
            Decimal impHaberDolares = Variables.Cero;

            // Recupera los valores del texto del debe y haber
            Decimal.TryParse(txtDebeSoles.Text, out impDebeSoles);
            Decimal.TryParse(txtHaberSoles.Text, out impHaberSoles);
            Decimal.TryParse(txtDebeDolares.Text, out impDebeDolares);
            Decimal.TryParse(txtHaberDolares.Text, out impHaberDolares);

            // Asigna los valores a la cabecera
            oVoucher.impDebeSoles = Convert.ToDecimal(impDebeSoles);
            oVoucher.impHaberSoles = Convert.ToDecimal(impHaberSoles);
            oVoucher.impDebeDolares = Convert.ToDecimal(impDebeDolares);
            oVoucher.impHaberDolares = Convert.ToDecimal(impHaberDolares); 

            //oVoucher.impDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
            //oVoucher.impHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);

        }

        void EliminarAutomaticos()
        {
            if (oVoucher.ListaVouchers.Count > Variables.Cero)
            {
                List<VoucherItemE> ListaAuxiliar = new List<VoucherItemE>(oVoucher.ListaVouchers);

                foreach (VoucherItemE item in ListaAuxiliar)
                {
                    if (item.indAutomatica.Substring(0, 1) == Variables.SI)
                    {
                        oVoucher.ListaVouchers.Remove(item);
                        Modificacion = true;
                    }
                }

                bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                bsListaVouchers.ResetBindings(false);

                bFlag = true;             
            }
        }

        void ValidarCuentaCC(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCuentaIG.Text))
                {
                    if (VariablesLocales.oListaCuentaCC != null && VariablesLocales.oListaCuentaCC.Count > Variables.Cero)
                    {
                        String Cuenta = String.Empty;

                        foreach (CuentaCCostoE item in VariablesLocales.oListaCuentaCC)
                        {
                            Cuenta = item.codCuenta;

                            if (Global.Izquierda(txtCuentaIG.Text.Trim(), Convert.ToInt32(item.numDigitos)) == Cuenta)
                            {
                                txtCCostos.Text = CCostoCuenta = item.idCCosto.Trim();
                                break;
                            }
                        }

                        txtCCostos_Leave(new Object(), new EventArgs());
                        txtRuc.Focus();
                    }
                    else
                    {
                        txtCCostos.Text = String.Empty;
                        txtDesCCostos.Text = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void LimpiarGeneracion()
        {
            txtCuentaIG.TextChanged -= txtCuentaIG_TextChanged;
            txtRuc.TextChanged -= txtRuc_TextChanged;

            txtCuentaIG.Text = String.Empty;
            txtRuc.Text = String.Empty;
            txtCCostos.Text = String.Empty;
            cboDocumento.SelectedValue = Variables.Cero.ToString();
            cboReferencia.Text = String.Empty;
            txtSerie.Text = String.Empty;
            txtNumDoc.Text = String.Empty;
            txtSerieRef.Text = String.Empty;
            txtNumDocRef.Text = String.Empty;
            txtCodPartida.Text = String.Empty;
            txtDesPartida.Text = String.Empty;

            ChkDetraccion.Checked = false;
            txtNumDetra.Text = String.Empty;
            dtpFecDetraccion.Value = VariablesLocales.FechaHoy;
            cboTipoDetraccion.SelectedValue = Variables.Cero.ToString();
            txtTasaDetra.Text = String.Empty;
            txtMontoDetraccion.Text = String.Empty;

            RazonSocial = String.Empty;

            txtCuentaIG.TextChanged += txtCuentaIG_TextChanged;
            txtRuc.TextChanged += txtRuc_TextChanged;
        }

        void ImportarExcel(string Ruta)
        {
            String MensajeFila = String.Empty;
            String MensajeColu = String.Empty;

            try
            {
                FileInfo oFi_ = new FileInfo(Ruta);

                //if (oFi_.Extension.ToUpper() == ".XLS")
                //{
                //    oFi_ = Global.CambiarExtensionExcel(oFi_);
                //}

                //Excel...
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Obteniendo Datos de la Primera Hoja
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                    String Diario;
                    String File;
                    String Periodo, Moneda, Glosa, Numero;
                    DateTime FechaOperacion, FechaDocumento; //,FechaVencimiento;

                    Periodo = oHoja.Cells[1, 4].Value.ToString();
                    Diario = oHoja.Cells[2, 4].Value.ToString();
                    FechaOperacion = Convert.ToDateTime(oHoja.Cells[3, 4].Value.ToString());
                    FechaDocumento = Convert.ToDateTime(oHoja.Cells[4, 4].Value.ToString());
                   
                    Moneda = oHoja.Cells[5, 4].Value.ToString();
                    File = oHoja.Cells[6, 4].Value.ToString();
                    Glosa = oHoja.Cells[7, 4].Value.ToString();
                    Numero = oHoja.Cells[7, 4].Value.ToString();

                    txtGlosaGeneral.Text = Glosa;
                    cboMonedas.SelectedValue = Moneda;
                    dtpFecOperacion.Text = FechaOperacion.ToString();
                    dtpFecDocumento.Text = FechaDocumento.ToString();

                    List<VoucherItemE> oListadoItem;
                    oListadoItem = new List<VoucherItemE>();

                    PlanCuentasE ctaTemporal = new PlanCuentasE();

                    Int32 filIni = 11;
                    Int32 UltimaFila = filIni;
                    Int32 Contador = 0;

                    for (int f = filIni; f <= UltimaFila; f++)
                    {
                        MensajeFila = "Fila " + f.ToString();

                        VoucherItemE oItem = new VoucherItemE()
                        {
                            codCuenta = oHoja.Cells[f, 2].Value.ToString()
                        };

                        ctaTemporal = VariablesLocales.ObtenerPlanCuenta(oItem.codCuenta);

                        if (ctaTemporal != null)
                        {
                            Contador++;
                            oItem.numItem = String.Format("{0:00000}", Contador);
                            txtItemxls.Text = oItem.numItem;
                            oItem.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                            oItem.desCuenta = ctaTemporal.Descripcion;
                            oItem.idDocumentoRef = "";
                            oItem.serDocumentoRef = "";
                            oItem.numDocumentoRef = "";
                            oItem.idCCostos = "";
                            oItem.CorrelativoAjuste = "";
                            oItem.codFteFin = "";
                            oItem.codProgramaCred = "";
                            oItem.indMovimientoAnterior = "";
                            oItem.tipPartidaPresu = "";
                            oItem.codPartidaPresu = "";
                            oItem.numDocumentoPresu = "";
                            oItem.codColumnaCoven = 0;
                            oItem.depAduanera = 0;
                            oItem.nroDua = "";
                            oItem.AnioDua = "";
                            oItem.numDetraccion = "";
                            oItem.tipDetraccion = "";
                            oItem.TasaDetraccion = 0;
                            oItem.MontoDetraccion = 0;
                            oItem.desReferenciaRep = "";
                            oItem.idAlmacen = "";
                            oItem.tipMovimientoAlmacen = "";
                            oItem.numDocumentoAlmacen = "";
                            oItem.numItemAlmacen = "";
                            oItem.CajaSucursal = "";
                            oItem.indCompra = "";
                            oItem.indConciliado = "N";
                            oItem.codMedioPago = 0;
                            oItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oItem.FechaRegistro = VariablesLocales.FechaHoy;
                            oItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oItem.FechaModificacion = VariablesLocales.FechaHoy;

                            if (ctaTemporal.indSolicitaAnexo == "S")
                            {
                                oItem.Ruc = oHoja.Cells[f, 5].Value.ToString();
                                List<Persona> oListaPersonas;
                                oListaPersonas =  AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", oItem.Ruc);

                                if (oListaPersonas.Count() > 0)
                                {
                                    oItem.idPersona = oListaPersonas[0].IdPersona;
                                    oItem.idPersonaCad = oListaPersonas[0].IdPersona.ToString();
                                    oItem.RazonSocial = oListaPersonas[0].RazonSocial;
                                }
                                else
                                {
                                    Global.MensajeFault("El Ruc " + oItem.Ruc + " No Existe " + ". Revisar en:\n\r" + MensajeFila);
                                    return;
                                }
                            }
                            else
                            {
                                oItem.Ruc = null;
                                oItem.idPersona = null;
                                oItem.RazonSocial = "";
                            }

                            if (ctaTemporal.indSolicitaCentroCosto == "S")
                            {
                                oItem.idCCostos = oHoja.Cells[f, 6].Value.ToString();
                            }

                            if (ctaTemporal.indSolicitaDcto == "S")
                            {
                                oItem.idDocumento = oHoja.Cells[f, 7].Value.ToString();
                                List<DocumentosE> oListaDcto;
                                oListaDcto = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral where (x.idDocumento == oItem.idDocumento) && (x.indBaja == false) select x).ToList();

                                if (oListaDcto.Count() > 0)
                                {
                                    oItem.serDocumento = oHoja.Cells[f, 8].Value.ToString();
                                    oItem.numDocumento = oHoja.Cells[f, 9].Value.ToString();
                                    oItem.fecDocumento = Convert.ToDateTime(oHoja.Cells[f, 10].Value.ToString());

                                    if (oListaDcto[0].indFecVencimiento)
                                    {
                                        oItem.fecVencimiento = Convert.ToDateTime(oHoja.Cells[f, 20].Value.ToString());
                                    }
                                    else
                                    {
                                        oItem.fecVencimiento = oItem.fecDocumento;
                                    }

                                    if (oListaDcto[0].indReferencia)
                                    {
                                        oItem.idDocumentoRef = oHoja.Cells[f, 15].Value.ToString();
                                        List<DocumentosE> oListaDctoRef;
                                        oListaDctoRef = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral where (x.idDocumento == oItem.idDocumentoRef) && (x.indBaja == false) select x).ToList();

                                        if (oListaDctoRef.Count() > 0)
                                        {
                                            oItem.serDocumentoRef = oHoja.Cells[f, 16].Value.ToString();
                                            oItem.numDocumentoRef = oHoja.Cells[f, 17].Value.ToString();
                                        }
                                        else
                                        {
                                            Global.MensajeFault("El tipo Documento referencia " + oItem.idDocumentoRef + " No Existe " + ". Revisar en:\n\r" + MensajeFila);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    Global.MensajeFault("El tipo Documento " + oItem.idDocumento + " No Existe " + ". Revisar en:\n\r" + MensajeFila);
                                    return;
                                }
                            }
                            else
                            {
                                oItem.idDocumento = "";
                                oItem.serDocumento = "";
                                oItem.numDocumento = "";
                                oItem.fecDocumento = null;
                            }

                            oItem.indDebeHaber = oHoja.Cells[f, 12].Value.ToString();
                            oItem.impSoles = Convert.ToDecimal(oHoja.Cells[f, 13].Value.ToString());
                            oItem.impDolares = Convert.ToDecimal(oHoja.Cells[f, 14].Value.ToString());
                            oItem.indAutomatica = "N";
                            oItem.indCambio = "N";
                            oItem.GlosaGeneral = oHoja.Cells[f, 18].Value.ToString();
                            oItem.desGlosa = "";
                            oItem.indReparable = oHoja.Cells[f, 19].Value.ToString();
                            oItem.flagDetraccion = "N";
                            oItem.idMoneda = cboMonedas.SelectedValue.ToString();
                            oItem.tipCambio = Convert.ToDecimal(txtTipoCambio.Text);
                            oItem.PlanCuenta = ctaTemporal;
                            oItem.idCampana = 0;
                            oItem.idConceptoGasto = 0;
                            oItem.codMedioPago = Variables.Cero;

                            oListadoItem.Add(oItem);
                        }
                        else
                        {
                            Global.MensajeFault("La Cuenta " + oItem.codCuenta + " No Existe " + ". Revisar en:\n\r" + MensajeFila);
                            return;
                        }

                        if (oHoja.Cells[f + 1, 2].Value != null)
                        {
                            UltimaFila++;
                        }
                        else
                        {
                            UltimaFila = 0;
                            oVoucher.ListaVouchers = oListadoItem;

                            bsListaVouchers.DataSource = oListadoItem;
                            bsListaVouchers.ResetBindings(false);
                            SumarTotales();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ". Revisar en:\n\r" + MensajeFila);
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oVoucher == null)
            {
                Opcion = (Int32)EnumOpcionGrabar.Insertar;

                oVoucher = new VoucherE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = idLocal,
                    AnioPeriodo = VariablesLocales.PeriodoContable.AnioPeriodo,
                    MesPeriodo = Mes,
                    numVoucher = txtNumVoucher.Text = Variables.Cero.ToString()
                };

                lblPeriodo.Text = Periodo;
                cboLibro.SelectedValue = Libro;
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = numFile;
                cboFile_SelectionChangeCommitted(new Object(), new EventArgs());
                txtTipoCambio.Text = Variables.ValorCeroDecimal.ToString("N3");

                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                //oVoucher.FechaRegistro = VariablesLocales.FechaHoy;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                //oVoucher.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                oVoucher.desFile = ((ComprobantesFileE)cboFile.SelectedItem).Descripcion;
                oVoucher.desMoneda = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;

                Text = "Ingreso de Comprobante";

                if (Convert.ToInt32(Mes) < Convert.ToInt32(VariablesLocales.PeriodoContable.MesPeriodo))
                {
                    if (Convert.ToInt32(Mes) == 0)
                    {
                        dtpFecOperacion.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/01/" + VariablesLocales.PeriodoContable.AnioPeriodo));
                        dtpFecDocumento.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/01/" + VariablesLocales.PeriodoContable.AnioPeriodo));
                    }
                    else if (Convert.ToInt32(Mes) == 13)
                    {
                        dtpFecOperacion.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("31/12/" + Convert.ToString(Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo) - 1)));
                        dtpFecDocumento.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("31/12/" + Convert.ToString(Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo) - 1)));
                    }
                    else
                    {
                        dtpFecOperacion.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + Mes + "/" + VariablesLocales.PeriodoContable.AnioPeriodo));
                        dtpFecDocumento.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + Mes + "/" + VariablesLocales.PeriodoContable.AnioPeriodo));
                    }
                }
                else
                {
                    Int32 AnioActual = Convert.ToInt32(VariablesLocales.FechaHoy.Date.ToString("yyyy"));

                   if (Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo) == AnioActual)
                    {
                        dtpFecDocumento.Value = VariablesLocales.FechaHoy.Date;
                        dtpFecOperacion.Value = VariablesLocales.FechaHoy.Date;
                    }
                   else
                    {
                        if (Convert.ToInt32(Mes) == 13)
                        {
                            dtpFecOperacion.Value = Convert.ToDateTime("31/12/" + Convert.ToString(Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo)));
                            dtpFecDocumento.Value = Convert.ToDateTime("31/12/" + Convert.ToString(Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo)));
                        }
                        else
                        {
                            dtpFecOperacion.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + Mes + "/" + VariablesLocales.PeriodoContable.AnioPeriodo));
                            dtpFecDocumento.Value = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + Mes + "/" + VariablesLocales.PeriodoContable.AnioPeriodo));
                        }
                    }
                }

                tbVouchers.Focus();
                pnlCabecera.Focus();
                txtGlosaGeneral.Focus();

                // Validar la cuenta en funcion a la Moneda
                CuentasPorDefecto();
            }
            else
            {
                Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                lblPeriodo.Text = "Periodo - Año >> " + oVoucher.MesPeriodo + " - " + oVoucher.AnioPeriodo;
                cboLibro.SelectedValue = oVoucher.idComprobante;
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFile.SelectedValue = oVoucher.numFile;
                txtCuo.Text = oVoucher.AnioPeriodo.Substring(2, 2) + oVoucher.MesPeriodo + '0' + oVoucher.idLocal.ToString() + oVoucher.idComprobante + oVoucher.numFile;
                txtNumVoucher.Text = oVoucher.numVoucher;
                cboMonedas.SelectedValue = oVoucher.idMoneda.ToString();
                dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                dtpFecOperacion.Value = Convert.ToDateTime(oVoucher.fecOperacion);
                dtpFecDocumento.Value = Convert.ToDateTime(oVoucher.fecDocumento);
                txtTipoCambio.Text = oVoucher.tipCambio.ToString();
                dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;
                txtGlosaGeneral.Text = oVoucher.GlosaGeneral;

                txtUsuRegistra.Text = oVoucher.UsuarioRegistro;
                txtRegistro.Text = oVoucher.FechaRegistro.ToString();
                txtUsuModifica.Text = oVoucher.UsuarioModificacion;
                //oVoucher.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oVoucher.FechaModificacion.ToString();

                Extensores.CambiaColorFondo(cboLibro, EnumTipoEdicionCuadros.Bloquear);
                Extensores.CambiaColorFondo(cboMonedas, EnumTipoEdicionCuadros.Bloquear);
                txtNumVoucher.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);

                BloquearCabecera();
                SumarTotales();

                Text = "Comprobante: " + oVoucher.idComprobante + "-" + oVoucher.numFile + "-" + oVoucher.numVoucher + " Periodo: " + Global.PrimeraMayuscula(FechasHelper.NombreMes(Convert.ToInt32(oVoucher.MesPeriodo)));
            }

            bsVoucher.DataSource = oVoucher;
            bsListaVouchers.DataSource = oVoucher.ListaVouchers;
            bsVoucher.ResetBindings(false);
            bsListaVouchers.ResetBindings(false);
            oVoucherItem = new VoucherItemE();

            RevisarLibro(cboLibro.SelectedValue.ToString());

            if (indBloqueo == "S")
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            else
            {
                base.Nuevo();

                if (OFF == "DESACTIVADO")
                {
                    dtpFecOperacion.Enabled = false;
                    dtpFecDocumento.Enabled = false;
                    BloquearOpcion(EnumOpcionMenuBarra.Grabar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Cancelar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
                    BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Editar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Exportar, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Imprimir, false);
                    BloquearOpcion(EnumOpcionMenuBarra.Anular, false);
                    btAjusteBase.Enabled = false;
                    btDiferencia.Enabled = false;
                    btQuitarCuentas.Enabled = false;
                    btNuevoItem.Enabled = false;
                    btEliminarItem.Enabled = false;
                    txtGlosaGeneral.Enabled = false;
                }
            }
        }

        public override void Grabar()
        {
            try
            {
                Totales = true;
                DatosCabecera();

                if (oVoucher != null)
                {
                    if (oVoucher.ListaVouchers == null || oVoucher.ListaVouchers.Count == Variables.Cero)
                    {
                        Global.MensajeComunicacion("Debe ingresar items. De lo contrario Cancele o cierre el formulario...");
                        tbVouchers.SelectedTab = tpMovimiento;
                        return;
                    }

                    if (Convert.ToDecimal(txtDiferenciaSoles.Text) != Variables.Cero || Convert.ToDecimal(txtDiferenciaDolares.Text) != Variables.Cero)
                    {
                        oVoucher.indEstado = Variables.VoucherDescuadrado;
                        if (Global.MensajeConfirmacion("El voucher se encuentra descuadrado...\n\r ¿ Desea continuar con la grabación ?") == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        oVoucher.indEstado = Variables.VoucherCuadrado;
                    }

                    #region Revisando si hay detracción

                    String CuentaDetraccion = String.Empty;

                    if (oParametrosConta != null)
                    {
                        if (oParametrosConta.indDetraccion)
                        {
                            foreach (VoucherItemE item in oVoucher.ListaVouchers)
                            {
                                if (item.flagDetraccion.Substring(0, 1) == Variables.SI)
                                {
                                    if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                                    {
                                        CuentaDetraccion = oParametrosConta.ctaDetraccion;

                                        if (String.IsNullOrWhiteSpace(CuentaDetraccion))
                                        {
                                            Global.MensajeComunicacion("Falta configurar la Cuenta de Detración Soles en Parametros de Contabilidad.");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        CuentaDetraccion = oParametrosConta.ctaDetraccionDol;

                                        if (String.IsNullOrWhiteSpace(oParametrosConta.ctaDetraccionDol))
                                        {
                                            Global.MensajeComunicacion("Falta configurar la Cuenta de Detración Dólares en Parametros de Contabilidad.");
                                            return;
                                        }
                                    }

                                    break;  
                                }
                            }
                        }
                    }

                    #endregion

                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        // Si no es igual a Cero colocar el numero Ingresado
                        if (Convert.ToInt32(txtNumVoucher.Text.Trim()) != Variables.Cero)
                        {
                            oVoucher.numVoucher = txtNumVoucher.Text.Trim().PadLeft(9, '0');
                        }
                        
                        if (VariablesLocales.SesionUsuario.Empresa.RUC != "20251352292") //Sale mensaje si es diferente a Aldeasa
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.No) { return; } 
                        }

                        List<VoucherItemE> ListaAuxiliar = new List<VoucherItemE>(oVoucher.ListaVouchers);

                        foreach (VoucherItemE item in ListaAuxiliar)
                        {
                            if (item.indAutomatica == Variables.SI)
                            {
                                oVoucher.ListaVouchers.Remove(item);
                            }

                            if (!String.IsNullOrEmpty(item.RazonSocial))
                            {
                                RazonSocial = item.RazonSocial;
                            }
                        }

                        //Detracciones
                        if (!oParametrosConta.indDiarioDetra && oParametrosConta.indDetraccion)
                        {
                            foreach (VoucherItemE item in oVoucher.ListaVouchers)
                            {
                                if (item.flagDetraccion.Substring(0, 1) == Variables.SI)
                                {
                                    oVoucher.ListaVouchers.Add(ItemDetraccion(item, Variables.Debe, item.codCuenta, "N"));
                                    oVoucher.ListaVouchers.Add(ItemDetraccion(item, Variables.Haber, CuentaDetraccion, "S"));
                                    break;
                                }
                            } 
                        }

                        foreach (VoucherItemE item in ListaAuxiliar)
                        {
                            if (item.indCuentaGastos == Variables.SI)
                            {
                                if (item.codCuentaDestino != null && item.codCuentaTransferencia != null)
                                {
                                    VoucherItemE tmpItem = null;

                                    tmpItem = CuentaAutomatica(item, item.codCuentaDestino);
                                    oVoucher.ListaVouchers.Add(tmpItem);
                                    tmpItem = CuentaAutomatica(item, item.codCuentaTransferencia);
                                    oVoucher.ListaVouchers.Add(tmpItem);
                                }
                            }

                            // Cuando existen varias razones sociales se pone VARIOS
                            if (!String.IsNullOrEmpty(item.RazonSocial))
                            {
                                if (item.RazonSocial != RazonSocial)
                                {
                                    RazonSocial = "VARIOS";
                                } 
                            }

                            if ((!String.IsNullOrEmpty(item.idDocumento))  &&
                                (!String.IsNullOrEmpty(item.serDocumento)) &&
                                (!String.IsNullOrEmpty(item.numDocumento)))
                            {
                                numDocumentoCab = item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento; 
                            }
                        }

                        CalculaDatosCabecera();
                        SumarTotales();

                        if (Convert.ToDecimal(txtDiferenciaSoles.Text) == Variables.Cero || Convert.ToDecimal(txtDiferenciaDolares.Text) == Variables.Cero)
                        {
                            oVoucher.indEstado = Variables.VoucherCuadrado;
                        }

                        if (oVoucher.ListaVouchers.Count > 50)
                        {
                            Global.MensajeAdvertencia("Por la cantidad de Items que tiene el voucher, tiene que mayorizar manualmente.");
                        }

                        oVoucher = AgenteContabilidad.Proxy.GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                        if (VariablesLocales.SesionUsuario.Empresa.RUC != "20251352292") //Sale mensaje si es diferente a Aldeasa
                        {
                            String Cuo = oVoucher.AnioPeriodo.Substring(2, 2) + oVoucher.MesPeriodo + '0' + oVoucher.idLocal.ToString() + oVoucher.idComprobante + oVoucher.numFile;
                            Global.MensajeComunicacion(String.Format("Se generó el Voucher {0}-{1}", Cuo, oVoucher.numVoucher));
                        }
                    }
                    else
                    {
                        if (VariablesLocales.SesionUsuario.Empresa.RUC != "20251352292") //Sale mensaje si es diferente a Aldeasa
                        {
                            if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.No) { return; }
                        }
                       
                        List<VoucherItemE> ListaAuxiliar = new List<VoucherItemE>(oVoucher.ListaVouchers);

                        foreach (VoucherItemE item in ListaAuxiliar)
                        {
                            if (item.indAutomatica.Substring(0, 1) == Variables.SI)
                            {
                                oVoucher.ListaVouchers.Remove(item);
                            }

                            if (!String.IsNullOrEmpty(item.RazonSocial))
                            {
                                RazonSocial = item.RazonSocial;
                            }
                        }

                        //Detracciones
                        if (!oParametrosConta.indDiarioDetra && oParametrosConta.indDetraccion)
                        {
                            foreach (VoucherItemE item in oVoucher.ListaVouchers)
                            {
                                if (item.flagDetraccion.Substring(0, 1) == Variables.SI)
                                {
                                    oVoucher.ListaVouchers.Add(ItemDetraccion(item, Variables.Debe, item.codCuenta, "N"));
                                    oVoucher.ListaVouchers.Add(ItemDetraccion(item, Variables.Haber, CuentaDetraccion, "S"));
                                    break;
                                }
                            }
                        }

                        foreach (VoucherItemE item in ListaAuxiliar)
                        {
                            if (item.indCuentaGastos == Variables.SI)
                            {
                                if (item.codCuentaDestino != null && item.codCuentaTransferencia != null)
                                {
                                    VoucherItemE tmpItem = null;// CuentaAutomatica(item);

                                    tmpItem = CuentaAutomatica(item, item.codCuentaDestino);
                                    oVoucher.ListaVouchers.Add(tmpItem);
                                    tmpItem = CuentaAutomatica(item, item.codCuentaTransferencia);
                                    oVoucher.ListaVouchers.Add(tmpItem);
                                }
                            }

                            // Cuando existen varias razones sociales se pone VARIOS
                            if (!String.IsNullOrEmpty(item.RazonSocial))
                            {
                                if (item.RazonSocial != RazonSocial)
                                {
                                    RazonSocial = "VARIOS";
                                }
                            }

                            if ((!String.IsNullOrEmpty(item.idDocumento)) && (!String.IsNullOrEmpty(item.serDocumento)) && (!String.IsNullOrEmpty(item.numDocumento)))
                            {
                                numDocumentoCab = item.idDocumento + " " + item.serDocumento + "-" + item.numDocumento;
                            }
                        }

                        CalculaDatosCabecera();
                        SumarTotales();

                        if (Convert.ToDecimal(txtDiferenciaSoles.Text) == Variables.Cero || Convert.ToDecimal(txtDiferenciaDolares.Text) == Variables.Cero)
                        {
                            oVoucher.indEstado = Variables.VoucherCuadrado;
                        }

                        if (oVoucher.ListaVouchers.Count > 50)
                        {
                            Global.MensajeAdvertencia("Por la cantidad de Items que tiene el voucher, tiene que mayorizar manualmente.");
                        }

                        oVoucher = AgenteContabilidad.Proxy.GrabarVouchers(oVoucher, EnumOpcionGrabar.Actualizar);

                        if (VariablesLocales.SesionUsuario.Empresa.RUC != "20251352292") //Sale mensaje si es diferente a Aldeasa
                        {
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();

                if (VariablesLocales.SesionUsuario.Empresa.RUC == "20502647009" || //AgroGenesis
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20523020561" || //Huerto Genesis
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20517933318" || //Vivero Genesis
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20552695217" || //Jeritec
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20552186681" || //A Y V SEEDS CO. S.A.C.
                    VariablesLocales.SesionUsuario.Empresa.RUC == "20552690410")   //POWER SEEDS S.A.C
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        oVoucher = null;
                        tbVouchers.SelectedTab = tpRegistro;
                        btGenerar.Enabled = true;
                        dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;
                        dtpFecDocumento.Value = Convert.ToDateTime("01/01/2000");
                        dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;

                        txtMontoSinDerecho.Text = "0.00";
                        txtBaseAfecta.Text = "0.00";
                        txtBaseInafecta.Text = "0.00";
                        txtIsc.Text = "0.00";
                        txtIgv.Text = "0.00";
                        txtTotal.Text = "0.00";
                        txtGlosaGeneral.Text = string.Empty;

                        Nuevo();                        
                        SumarTotales();
                        LimpiarGeneracion();
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                bsListaVouchers.ResetBindings(false);
                Global.MensajeError(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                if (tbVouchers.SelectedTab == tpMovimiento)
                {
                    DatosCabecera();
                    Int32 Item;
                    VoucherItemE vItem = null;
                    VoucherItemE tmpItem = null;

                    if (oVoucher.ListaVouchers.Count > 1)
                    {
                        tmpItem = new VoucherItemE();
                        bsListaVouchers.MoveLast();
                        tmpItem = ((VoucherItemE)bsListaVouchers[bsListaVouchers.Position - 1]);
                    }
                    else
                    {
                        tmpItem = new VoucherItemE();
                        tmpItem = ((VoucherItemE)bsListaVouchers.Current);
                    }

                    frmDetalleVoucher oFrm = null;

                    if (!((ComprobantesFileE)cboFile.SelectedItem).LLevaCuenta)
                    {
                        oFrm = new frmDetalleVoucher(oVoucher, vItem, tmpItem, indBloqueo);
                    }
                    else
                    {
                        if (oVoucher.ListaVouchers.Count > 0)
                        {
                            oFrm = new frmDetalleVoucher(oVoucher, vItem, tmpItem, indBloqueo);
                        }
                        else
                        {
                            oFrm = new frmDetalleVoucher(oVoucher, vItem, tmpItem, indBloqueo, Convert.ToBoolean(((ComprobantesFileE)cboFile.SelectedItem).LLevaCuenta), ((ComprobantesFileE)cboFile.SelectedItem).codCuenta);
                        }
                    }
                    
                    #region Pasando totales

                    oFrm.txtDiferenciaSoles.Text = txtDiferenciaSoles.Text;
                    oFrm.txtDiferenciaDolares.Text = txtDiferenciaDolares.Text;
                    oFrm.txtDebeSoles.Text = txtDebeSoles.Text;
                    oFrm.txtDebeDolares.Text = txtDebeDolares.Text;
                    oFrm.txtHaberSoles.Text = txtHaberSoles.Text;
                    oFrm.txtHaberDolares.Text = txtHaberDolares.Text;

                    #endregion

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        if (oFrm.oVoucherDet != null)
                        {
                            base.AgregarDetalle();
                            vItem = oFrm.oVoucherDet;

                            if (oVoucher.ListaVouchers.Count == Variables.Cero)
                            {
                                Item = Variables.ValorUno;
                            }
                            else
                            {
                                Item = Convert.ToInt32(oVoucher.ListaVouchers.Max(mx => mx.numItem)) + 1;
                            }

                            vItem.numItem = String.Format("{0:00000}", Item);

                            oVoucher.ListaVouchers.Add(vItem);
                            bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                            bsListaVouchers.ResetBindings(false);
                            EliminarAutomaticos();
                            SumarTotales();

                            AgregarDetalle();
                        }
                        else
                        {
                            if (oFrm.oListaVouchers.Count > Variables.Cero)
                            {
                                List<VoucherItemE> oListaTemporal = oFrm.oListaVouchers;

                                foreach (VoucherItemE item in oListaTemporal)
                                {
                                    if (oVoucher.ListaVouchers.Count == Variables.Cero)
                                    {
                                        Item = Variables.ValorUno;
                                    }
                                    else
                                    {
                                        Item = Convert.ToInt32(oVoucher.ListaVouchers.Max(mx => mx.numItem)) + 1;
                                    }

                                    item.numItem = String.Format("{0:00000}", Item);
                                    oVoucher.ListaVouchers.Add(item);
                                }

                                bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                                bsListaVouchers.ResetBindings(false);
                                EliminarAutomaticos();
                                SumarTotales();
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

        public override void QuitarDetalle()
        {
            if (tbVouchers.SelectedTab == tpMovimiento)
            {
                if (bsListaVouchers.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        base.QuitarDetalle();
                        Int32 numItem = Variables.ValorUno;
                        VoucherItemE oVitem = null;

                        oVoucher.ListaVouchers.RemoveAt(bsListaVouchers.Position);
                        List<VoucherItemE> ListaAuxiliar = new List<VoucherItemE>();

                        foreach (VoucherItemE item in oVoucher.ListaVouchers)
                        {
                            oVitem = new VoucherItemE();
                            oVitem = item;
                            item.numItem = String.Format("{0:00000}", numItem);
                            numItem++;
                            ListaAuxiliar.Add(oVitem);
                        }

                        bsListaVouchers.DataSource = ListaAuxiliar;
                        bsListaVouchers.ResetBindings(false);
                        EliminarAutomaticos();
                        SumarTotales();
                    }
                }
            }
        }

        #endregion Procedimientos Heredados

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ImportarExcel(txtRuta.Text.Trim());
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            timer.Enabled = false;
            txtRuta.Text = string.Empty;

            _bw.CancelAsync();
            _bw.Dispose();

            Global.MensajeComunicacion("Importación Exitosa.");
            btObtenerDatos.Enabled = false;
            tbVouchers.SelectedTab = tpMovimiento;
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();

                Global.CrearToolTip(btGenerar, "Generar movimiento.(Pulse F12)");
                Global.CrearToolTip(btCosto, "Buscar Hoja de Costo.");
                Global.CrearToolTip(btRuc, "Buscar Ruc.");
                Global.CrearToolTip(btCentroC, "Buscar Centro de Costos.");
                Global.CrearToolTip(btAjusteBase, "Ajuste Automatico en Cuenta Base");
                Global.CrearToolTip(btDiferencia, "Diferencia de Cambio en Cancelaciones");
                Global.CrearToolTip(btQuitarCuentas, "Eliminar Asientos Automaticos");

                txtCuenta.MaxLength = (Int32)VariablesLocales.VersionPlanCuentasActual.Longitud;
                txtCuentaIG.MaxLength = (Int32)VariablesLocales.VersionPlanCuentasActual.Longitud;

                //Habilitando los eventos para trabajar en segundo plano...
                CheckForIllegalCrossThreadCalls = false;
                _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
                _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
                _bw.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void ChkDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDetraccion.Checked)
            {
                pnlDatosDetraccion.Enabled = true;
                txtNumDetra.Focus();
            }
            else
            {
                pnlDatosDetraccion.Enabled = false;
            }
        }

        private void chkIndCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndCosto.Checked)
            {
                btCosto.Enabled = true;
            }
            else
            {
                btCosto.Enabled = false;
            }
        }       

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles); //AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), Descripcion = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "Descripcion", false);
                    ListaFiles = null;

                    #region Documentos
                    
                    if (cboLibro.SelectedValue.ToString() == Variables.RegistroCompra)
                    {
                        ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                               where x.indDocumentoCompras == true || x.idDocumento == "0"
                                                                               orderby x.desDocumento
                                                                               select x).ToList(), "idDocumento", "desDocumento", false);
                        //Referencia
                        ComboHelper.RellenarCombos<DocumentosE>(cboReferencia, (from x in ListaDocumentos
                                                                                where x.indDocumentoCompras == true && x.EsReferencia == true || x.idDocumento == "0"
                                                                                orderby x.desDocumento
                                                                                select x).ToList(), "idDocumento", "desDocumento", false);
                    }
                    else
                    {
                        ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos
                                                                               where x.indDocumentoVentas == true || x.idDocumento == "0"
                                                                               orderby x.desDocumento
                                                                               select x).ToList(), "idDocumento", "desDocumento", false);
                        //Referencia
                        ComboHelper.RellenarCombos<DocumentosE>(cboReferencia, (from x in ListaDocumentos
                                                                                where x.indDocumentoVentas == true && x.EsReferencia == true || x.idDocumento == "0"
                                                                                orderby x.desDocumento
                                                                                select x).ToList(), "idDocumento", "desDocumento", false);
                    }

                    #endregion            

                    if (!oPeriodoContable.indCierre)
                    {
                        RevisarLibro(cboLibro.SelectedValue.ToString());
                    }

                    NuevoItem();
                    CuentasPorDefecto();
                    oPlanCuentasGenerado = null;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMonedas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMonedas.SelectedValue != null)
            {
                CuentasPorDefecto();
                oPlanCuentasGenerado = null;

                if (ChkDetraccion.Checked)
                {
                    cboTipoDetraccion_SelectionChangeCommitted(new Object(), new EventArgs());
                }

                if (oVoucher != null)
                {
                    oVoucher.desMoneda = ((MonedasE)cboMonedas.SelectedItem).desAbreviatura;    
                }                
            }
        }

        private void cboFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboMonedas.SelectedValue = ((ComprobantesFileE)cboFile.SelectedItem).idMoneda;
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGeneracion())
                {
                    return;
                }

                Totales = true;
                List<VoucherItemE> tmpListaVoucherItems = new List<VoucherItemE>();
                PlanCuentasE tmpCuentaGasto = new PlanCuentasE();

                if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Soles)
                {
                    oVoucherItem.impSoles = Convert.ToDecimal(txtBaseAfecta.Text);
                    oVoucherItem.impDolares = Variables.ValorCeroDecimal;
                }
                else if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Dolares)
                {
                    oVoucherItem.impDolares = Convert.ToDecimal(txtBaseAfecta.Text);
                    oVoucherItem.impSoles = Variables.ValorCeroDecimal;
                }

                oListaPlanCuentasGenerado = new List<PlanCuentasE>();
                
                #region Cuenta Pago

                oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuenta.Text);
                
                if (oPlanCuentasGenerado.indAutomatico == null)
                {
                    oPlanCuentasGenerado.indAutomatico = Variables.NO;
                }
                
                oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);
                oPlanCuentasGenerado = null;

                #endregion

                #region IGV

                if (!String.IsNullOrEmpty(txtIgv.Text) && txtIgv.Text != Variables.Cero.ToString("N2"))
                {
                    oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(CuentaIgv);

                    if (oPlanCuentasGenerado != null)
                    {
                        if (oPlanCuentasGenerado.indAutomatico == null)
                        {
                            oPlanCuentasGenerado.indAutomatico = Variables.NO;
                        }

                        oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);
                        oPlanCuentasGenerado = null; 
                    }
                    else
                    {
                        Global.MensajeFault(String.Format("La cuenta {0} de Igv, no esta configurada en la tabla de Impuestos.", CuentaIgv));
                        return;
                    }
                }

                #endregion

                #region Cuenta por Pagar

                if (!String.IsNullOrEmpty(txtBaseAfecta.Text.Trim()) && Convert.ToDecimal(txtBaseAfecta.Text) > Variables.Cero)
                {
                    tmpCuentaGasto = VariablesLocales.ObtenerPlanCuenta(txtCuentaIG.Text);
                    oPlanCuentasGenerado = new PlanCuentasE();
                    oPlanCuentasGenerado = tmpCuentaGasto;

                    if (oPlanCuentasGenerado.indAutomatico == null)
                    {
                        oPlanCuentasGenerado.indAutomatico = Variables.NO;
                    }

                    oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);
                }

                #endregion

                #region Generar Cuenta si hay Base Inafecta

                if (!String.IsNullOrEmpty(txtBaseInafecta.Text.Trim()) && Convert.ToDecimal(txtBaseInafecta.Text) > Variables.Cero)
                {
                    tmpCuentaGasto = VariablesLocales.ObtenerPlanCuenta(txtCuentaIG.Text);
                    oPlanCuentasGenerado = new PlanCuentasE();
                    oPlanCuentasGenerado = tmpCuentaGasto;
                    oPlanCuentasGenerado.Afecto = true;

                    if (oPlanCuentasGenerado.indAutomatico == null)
                    {
                        oPlanCuentasGenerado.indAutomatico = Variables.NO;
                    }

                    oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);

                    if (tmpCuentaGasto.indCuentaGastos == Variables.SI)
                    {
                        if (!String.IsNullOrEmpty(tmpCuentaGasto.codCuentaDestino) && !String.IsNullOrEmpty(tmpCuentaGasto.codCuentaTransferencia))
                        {
                            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(tmpCuentaGasto.codCuentaDestino);
                            oPlanCuentasGenerado.indAutomatico = Variables.SI;
                            oPlanCuentasGenerado.Afecto = true;
                            oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);

                            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(tmpCuentaGasto.codCuentaTransferencia);
                            oPlanCuentasGenerado.indAutomatico = Variables.SI;
                            oPlanCuentasGenerado.Afecto = true;
                            oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);

                            oPlanCuentasGenerado = null;
                        }
                    }
                } 

                #endregion

                #region Cuenta Gasto

                if (tmpCuentaGasto.indCuentaGastos == Variables.SI)
                {
                    if (!String.IsNullOrEmpty(txtBaseAfecta.Text.Trim()) && Convert.ToDecimal(txtBaseAfecta.Text) > Variables.Cero)
                    {
                        if (!String.IsNullOrEmpty(tmpCuentaGasto.codCuentaDestino) && !String.IsNullOrEmpty(tmpCuentaGasto.codCuentaTransferencia))
                        {
                            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(tmpCuentaGasto.codCuentaDestino);
                            oPlanCuentasGenerado.indAutomatico = Variables.SI;
                            oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);

                            oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(tmpCuentaGasto.codCuentaTransferencia);
                            oPlanCuentasGenerado.indAutomatico = Variables.SI;
                            oListaPlanCuentasGenerado.Add(oPlanCuentasGenerado);

                            oPlanCuentasGenerado = null;
                        }
                    }
                } 

                #endregion

                VoucherItemE tmpVoucherItem = null;
                numItem = 1;

                foreach (PlanCuentasE item in oListaPlanCuentasGenerado)
                {
                    tmpVoucherItem = new VoucherItemE()
                    {
                        numItem = String.Format("{0:00000}", numItem),
                        indCuentaGastos = item.indCuentaGastos,
                        idComprobante = cboLibro.SelectedValue.ToString(),
                        numFile = cboFile.SelectedValue.ToString()
                    };

                    #region Si la cuenta pide Razon Social

                    if (item.indSolicitaAnexo == Variables.SI)
                    {
                        if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && idPersona == Variables.Cero)
                        {
                            Global.MensajeComunicacion("La cuenta " + item.codCuenta + " necesita Auxiliar.");
                            txtRuc.Focus();
                            tmpError = true;
                            break;
                        }
                        else
                        {
                            tmpVoucherItem.idPersonaCad = idPersona.ToString();
                            tmpVoucherItem.idPersona = idPersona;
                            tmpVoucherItem.RazonSocial = txtRazonSocial.Text;
                        }
                    }
                    else
                    {
                        tmpVoucherItem.idPersonaCad = String.Empty;
                        tmpVoucherItem.idPersona = (Nullable<Int32>)null;
                        tmpVoucherItem.RazonSocial = String.Empty;
                    }

                    #endregion

                    tmpVoucherItem.idMoneda = cboMonedas.SelectedValue.ToString();
                    tmpVoucherItem.tipCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    tmpVoucherItem.indCambio = Variables.SI;

                    #region Si solicita Centro de Costo

                    if (item.indSolicitaCentroCosto == Variables.SI)
                    {
                        if (!String.IsNullOrEmpty(txtDesCCostos.Text.Trim()))
                        {
                            tmpVoucherItem.idCCostos = txtCCostos.Text;
                        }
                        else
                        {
                            Global.MensajeComunicacion("La cuenta " + item.codCuenta + " necesita un Centro de Costo.");
                            txtCCostos.Focus();
                            tmpError = true;
                            break;
                        }
                    }
                    else
                    {
                        tmpVoucherItem.idCCostos = String.Empty;
                    }

                    #endregion

                    tmpVoucherItem.numVerPlanCuentas = item.numVerPlanCuentas;
                    tmpVoucherItem.codCuenta = item.codCuenta;
                    tmpVoucherItem.desCuenta = item.Descripcion;

                    #region Si solicita Documento

                    if (item.indSolicitaDcto == Variables.SI)
                    {
                        if (cboDocumento.SelectedValue.ToString() == Variables.Cero.ToString())
                        {
                            Global.MensajeComunicacion("La cuenta " + item.codCuenta + " necesita un tipo de documento.");
                            cboDocumento.Focus();
                            tmpError = true;
                            break;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(txtSerie.Text.Trim()) && String.IsNullOrEmpty(txtNumDoc.Text.Trim()))
                            {
                                Global.MensajeComunicacion("La cuenta " + item.codCuenta + " necesita número de documento.");
                                txtSerie.Focus();
                                tmpError = true;
                                break;
                            }
                            else
                            {
                                tmpVoucherItem.idDocumento = cboDocumento.SelectedValue.ToString();
                                tmpVoucherItem.serDocumento = txtSerie.Text.Trim();
                                tmpVoucherItem.numDocumento = txtNumDoc.Text.Trim();
                                tmpVoucherItem.fecDocumento = dtpFecDocumento.Value.Date;
                                tmpVoucherItem.fecVencimiento = dtpFecDocumento.Value.Date;
                                tmpVoucherItem.fecRecepcion = dtpFecDocumento.Value.Date;

                                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                                {
                                    tmpVoucherItem.numDocumentoPresu = tmpVoucherItem.serDocumento + "-" + tmpVoucherItem.numDocumento;
                                }
                                else
                                {
                                    tmpVoucherItem.numDocumentoPresu = tmpVoucherItem.numDocumento;
                                }

                                if (cboReferencia.Enabled)
                                {
                                    if (cboReferencia.SelectedValue.ToString() == Variables.Cero.ToString())
                                    {
                                        Global.MensajeComunicacion("La NC / ND necesita una referencia.");
                                        cboReferencia.Focus();
                                        tmpError = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (String.IsNullOrEmpty(txtSerieRef.Text.Trim()) && String.IsNullOrEmpty(txtNumDocRef.Text.Trim()))
                                        {
                                            Global.MensajeComunicacion("La cuenta necesita número de documento.");
                                            txtSerieRef.Focus();
                                            tmpError = true;
                                            break;
                                        }
                                        else
                                        {
                                            tmpVoucherItem.idDocumentoRef = cboReferencia.SelectedValue.ToString();
                                            tmpVoucherItem.serDocumentoRef = txtSerieRef.Text;
                                            tmpVoucherItem.numDocumentoRef = txtNumDocRef.Text;
                                            tmpVoucherItem.fecDocumentoRef = dtpFechaRef.Value.Date;

                                            if (txtTicaRef.Text == "0.000")
                                            {
                                                Global.MensajeFault("La fecha de la referencia no tiene Tipo de Cambio.");
                                                tmpError = true;
                                                break;
                                            }
                                            else
                                            {
                                                tmpVoucherItem.tipCambio = Convert.ToDecimal(txtTicaRef.Text);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    tmpVoucherItem.idDocumentoRef = String.Empty;
                                    tmpVoucherItem.serDocumentoRef = String.Empty;
                                    tmpVoucherItem.numDocumentoRef = String.Empty;
                                    tmpVoucherItem.fecDocumentoRef = (Nullable<DateTime>)null;
                                }
                            }

                            tmpVoucherItem.depAduanera = ((DocumentosE)cboDocumento.SelectedItem).depAduanera;
                        }
                    }
                    else
                    {
                        tmpVoucherItem.idDocumento = String.Empty;
                        tmpVoucherItem.serDocumento = String.Empty;
                        tmpVoucherItem.numDocumento = String.Empty;
                        tmpVoucherItem.fecDocumento = (Nullable<DateTime>)null;
                        tmpVoucherItem.fecVencimiento = (Nullable<DateTime>)null;
                        tmpVoucherItem.fecRecepcion = (Nullable<DateTime>)null;

                        tmpVoucherItem.idDocumentoRef = String.Empty;
                        tmpVoucherItem.serDocumentoRef = String.Empty;
                        tmpVoucherItem.numDocumentoRef = String.Empty;
                        tmpVoucherItem.fecDocumentoRef = (Nullable<DateTime>)null;

                        tmpVoucherItem.numDocumentoPresu = String.Empty;
                        tmpVoucherItem.depAduanera = null;
                    }

                    #endregion

                    if (((DocumentosE)cboDocumento.SelectedItem).indDocNoDom)
                    {
                        tmpVoucherItem.AnioDua = dtpFecDocumento.Value.Year.ToString();
                        tmpVoucherItem.nroDua = string.Empty;
                    }
                    else
                    {
                        tmpVoucherItem.AnioDua = string.Empty;
                        tmpVoucherItem.nroDua = string.Empty;
                    }
                    
                    tmpVoucherItem.desGlosa = txtGlosaGeneral.Text;

                    #region Importe de las cuentas

                    Decimal Total = Variables.Cero;
                    Decimal BaseAfecta = Variables.Cero;
                    Decimal BaseInafecta = Variables.Cero;
                    Decimal.TryParse(txtTotal.Text, out Total);
                    Decimal.TryParse(txtBaseAfecta.Text, out BaseAfecta);
                    Decimal.TryParse(txtBaseInafecta.Text, out BaseInafecta);

                    if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Soles)
                    {
                        if (item.codCuenta == txtCuenta.Text.Trim())
                        {
                            if (Total == Variables.Cero)
                            {
                                if (cboLibro.SelectedValue.ToString() != Variables.RegistroVenta)
                                {
                                    Global.MensajeFault("Debe ingresar un monto.");
                                    tmpError = true;
                                    break;
                                }
                            }

                            tmpVoucherItem.impSoles = Total;
                            tmpVoucherItem.impDolares = Decimal.Round(Total / tmpVoucherItem.tipCambio, 2);

                            if (oVoucher.impMonOrigHab == null || oVoucher.impMonOrigHab == Variables.Cero)
                            {
                                if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Soles)
                                {
                                    oVoucher.impMonOrigHab = Total;
                                }
                                else
                                {
                                    oVoucher.impMonOrigHab = Decimal.Round(Total / tmpVoucherItem.tipCambio, 2);
                                }
                            }
                        }
                        else if (item.codCuenta == txtCuentaIG.Text.Trim() && item.Afecto == false)
                        {
                            tmpVoucherItem.impSoles = BaseAfecta;
                            tmpVoucherItem.impDolares = Decimal.Round(BaseAfecta / tmpVoucherItem.tipCambio, 2);

                            if (oVoucher.impMonOrigDeb == null || oVoucher.impMonOrigDeb == Variables.Cero)
                            {
                                if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Soles)
                                {
                                    oVoucher.impMonOrigDeb = BaseAfecta;
                                }
                                else
                                {
                                    oVoucher.impMonOrigDeb = Decimal.Round(BaseAfecta / tmpVoucherItem.tipCambio, 2);
                                }
                            }
                        }
                        else if (item.codCuenta == txtCuentaIG.Text.Trim() && item.Afecto == true)
                        {
                            tmpVoucherItem.impSoles = BaseInafecta;
                            tmpVoucherItem.impDolares = Decimal.Round(BaseInafecta / tmpVoucherItem.tipCambio, 2);
                        }
                        else if (item.codCuenta == CuentaIgv)
                        {
                            tmpVoucherItem.impSoles = Convert.ToDecimal(txtIgv.Text);
                            tmpVoucherItem.impDolares = Decimal.Round(Convert.ToDecimal(txtIgv.Text) / tmpVoucherItem.tipCambio, 2);
                        }
                        else if (item.Afecto == false)
                        {
                            tmpVoucherItem.impSoles = BaseAfecta;
                            tmpVoucherItem.impDolares = Decimal.Round(BaseAfecta / tmpVoucherItem.tipCambio, 2);
                        }
                        else if (item.Afecto == true)
                        {
                            tmpVoucherItem.impSoles = BaseInafecta;
                            tmpVoucherItem.impDolares = Decimal.Round(BaseInafecta / tmpVoucherItem.tipCambio, 2);
                        }
                    }
                    else if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Dolares)
                    {
                        if (item.codCuenta == txtCuenta.Text.Trim())
                        {
                            tmpVoucherItem.impDolares = Total;
                            tmpVoucherItem.impSoles = Decimal.Round(Total * tmpVoucherItem.tipCambio, 2);

                            if (oVoucher.impMonOrigHab == null || oVoucher.impMonOrigHab == Variables.Cero)
                            {
                                if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Soles)
                                {
                                    oVoucher.impMonOrigHab = Total;
                                }
                                else
                                {
                                    oVoucher.impMonOrigHab = Decimal.Round(Total * tmpVoucherItem.tipCambio, 2);
                                }
                            }
                        }
                        else if (item.codCuenta == txtCuentaIG.Text.Trim() && item.Afecto == false)
                        {
                            tmpVoucherItem.impDolares = BaseAfecta;
                            tmpVoucherItem.impSoles = Decimal.Round(BaseAfecta * tmpVoucherItem.tipCambio, 2);

                            if (oVoucher.impMonOrigDeb == null || oVoucher.impMonOrigDeb == Variables.Cero)
                            {
                                if (Convert.ToInt32(cboMonedas.SelectedValue) == (Int32)EnumTipoMoneda.Soles)
                                {
                                    oVoucher.impMonOrigDeb = BaseAfecta;
                                }
                                else
                                {
                                    oVoucher.impMonOrigDeb = Decimal.Round(BaseAfecta * tmpVoucherItem.tipCambio, 2);
                                }
                            }
                        }
                        else if (item.codCuenta == txtCuentaIG.Text.Trim() && item.Afecto == true)
                        {
                            tmpVoucherItem.impDolares = BaseInafecta;
                            tmpVoucherItem.impSoles = Decimal.Round(BaseInafecta * tmpVoucherItem.tipCambio, 2);
                        }
                        else if (item.codCuenta == CuentaIgv)
                        {
                            tmpVoucherItem.impDolares = Convert.ToDecimal(txtIgv.Text);
                            tmpVoucherItem.impSoles = Decimal.Round(Convert.ToDecimal(txtIgv.Text) * tmpVoucherItem.tipCambio, 2);
                        }
                        else if (item.Afecto == false)
                        {
                            tmpVoucherItem.impDolares = BaseAfecta;
                            tmpVoucherItem.impSoles = Decimal.Round(BaseAfecta * tmpVoucherItem.tipCambio, 2);
                        }
                        else if (item.Afecto == true)
                        {
                            tmpVoucherItem.impDolares = BaseInafecta;
                            tmpVoucherItem.impSoles = Decimal.Round(BaseInafecta * tmpVoucherItem.tipCambio, 2);
                        }
                    } 

                    #endregion

                    #region Columna CoVen

                    if (item.codColumnaCoven == null || item.codColumnaCoven == 0)
                    {
                        Global.MensajeError("La cuenta " + item.codCuenta + " no tiene definido el campo Compra / Venta");
                    }

                    if (item.codCuenta == txtCuenta.Text.Trim())
                    {
                        tmpVoucherItem.codColumnaCoven = (Int32)EnumTipoTotal.Total;
                        tmpVoucherItem.NombreColumna = "TOTAL";

                        if (!String.IsNullOrEmpty(txtSerie.Text))
                        {
                            tmpVoucherItem.numDocumentoPresu = txtSerie.Text + "-" + txtNumDoc.Text;
                        }
                        else
                        {
                            tmpVoucherItem.numDocumentoPresu = txtNumDoc.Text;
                        }
                    }
                    else if (item.codCuenta == txtCuentaIG.Text.Trim() && item.Afecto == false)
                    {
                        tmpVoucherItem.codColumnaCoven = (Int32)EnumTipoBaseImponibles.BaseImponible;
                        tmpVoucherItem.NombreColumna = "BASE";
                    }
                    else if (item.codCuenta == CuentaIgv)
                    {
                        tmpVoucherItem.codColumnaCoven = (Int32)EnumTipoIgv.ImpuestoGeneralVentas;
                        tmpVoucherItem.NombreColumna = "IGV";
                    }
                    else if (item.codCuenta == txtCuentaIG.Text.Trim() && item.Afecto == true)
                    {
                        tmpVoucherItem.codColumnaCoven = (Int32)EnumTipoBaseImponibles.BaseImponibleInafecta;
                        tmpVoucherItem.NombreColumna = "BASE I";
                    }

                    //// Verificar si Existe en Compras File para Asignar Columna de Compra y Venta
                    //if (item.codCuenta == txtCuentaIG.Text.Trim() || item.codCuenta == CuentaIgv)
                    //{
                    //    foreach (ComprasFileE item1 in oListarComprasFile)
                    //    {
                    //        if (item.codCuenta == txtCuentaIG.Text.Trim())
                    //        {
                    //            if (item1.idComprobante == tmpVoucherItem.idComprobante && item1.numFile == tmpVoucherItem.numFile)
                    //            {
                    //                tmpVoucherItem.codColumnaCoven = item1.codColumnaCoven;
                    //                tmpVoucherItem.NombreColumna = item1.nomColumnaCoven;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if (item1.idComprobante == tmpVoucherItem.idComprobante && item1.numFile == tmpVoucherItem.numFile && item1.indColumnaIgv)
                    //            {
                    //                tmpVoucherItem.codColumnaCoven = item1.codColumnaIgv;
                    //                tmpVoucherItem.NombreColumna = item1.nomColumnaIgv;
                    //            }
                    //        }
                    //    }      
                    //}

                    #endregion Columna CoVen

                    #region Naturaleza de la Cuenta

                    // obtiene Configuracion del Debe Haber de la tabla de Documentos
                    List<DocumentosE> oDocumento = ListaDocumentos.Where(x => x.idDocumento == cboDocumento.SelectedValue.ToString()).ToList();

                    if (item.codCuenta == CuentaIgv)
                    {
                        //if (tmpVoucherItem.idComprobante == Variables.ValorLibroRegistroCompra)
                        //{
                        //    tmpVoucherItem.indDebeHaber = Variables.ValorDebe;
                        //}
                        //else
                        //{
                        //    tmpVoucherItem.indDebeHaber = Variables.ValorHaber;
                        //}

                        if (oDocumento[0].indDebeHaber == Variables.Debe)
                        {
                            tmpVoucherItem.indDebeHaber = Variables.Haber;
                        }
                        else
                        {
                            tmpVoucherItem.indDebeHaber = Variables.Debe;
                        }
                    }
                    else
                    {
                        //if (VoucherItem_.indDebeHaber == Variables.ValorDebe)
                        //{
                        //    if (oCuenta.codCuenta == VoucherItem_.codCuentaDestino)
                        //    {
                        //        oItemVoucher.indDebeHaber = oCuenta.indNaturalezaCta;
                        //    }

                        //    if (oCuenta.codCuenta == VoucherItem_.codCuentaTransferencia)
                        //    {
                        //        oItemVoucher.indDebeHaber = Variables.ValorHaber;
                        //    }
                        //}
                        if (item.indAutomatico == Variables.SI)
                        {
                            if (tmpCuentaGasto.indCuentaGastos == Variables.SI)
                            {
                                if (item.codCuenta == tmpCuentaGasto.codCuentaTransferencia)
                                {
                                    //tmpVoucherItem.indDebeHaber = Variables.ValorHaber;//item.indNaturalezaCta;
                                    tmpVoucherItem.indDebeHaber = oDocumento[0].indDebeHaber;
                                }

                                if (item.codCuenta == tmpCuentaGasto.codCuentaDestino)
                                {
                                    //tmpVoucherItem.indDebeHaber = tmpCuentaGasto.indNaturalezaCta;
                                    if (oDocumento[0].indDebeHaber == Variables.Debe)
                                    {
                                        tmpVoucherItem.indDebeHaber = Variables.Haber;
                                    }
                                    else
                                    {
                                        tmpVoucherItem.indDebeHaber = Variables.Debe;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (oDocumento[0].indDebeHaber == Variables.Debe)
                            {
                                if (tmpVoucherItem.NombreColumna.Contains("TOTAL"))
                                {
                                    tmpVoucherItem.indDebeHaber = Variables.Debe; //item.indNaturalezaCta;
                                }
                                else
                                {
                                    tmpVoucherItem.indDebeHaber = Variables.Haber;
                                }
                            }
                            else
                            {
                                if (tmpVoucherItem.NombreColumna.Contains("TOTAL"))
                                {
                                    tmpVoucherItem.indDebeHaber = Variables.Haber; //item.indNaturalezaCta;
                                }
                                else
                                {
                                    tmpVoucherItem.indDebeHaber = Variables.Debe;
                                }
                            }
                        }
                    }

                    #endregion Naturaleza de la Cuenta

                    tmpVoucherItem.indAutomatica = item.indAutomatico;
                    tmpVoucherItem.CorrelativoAjuste = String.Empty;
                    tmpVoucherItem.codFteFin = String.Empty;
                    tmpVoucherItem.codProgramaCred = String.Empty;
                    tmpVoucherItem.numDocumentoPresu = String.Empty;                   

                    #region Verficando si hay detraccion

                    if (ChkDetraccion.Checked)
                    {
                        if (item.codCuenta == txtCuenta.Text.Trim())
                        {
                            tmpVoucherItem.flagDetraccion = Variables.SI;
                            tmpVoucherItem.numDetraccion = txtNumDetra.Text;
                            tmpVoucherItem.fecDetraccion = dtpFecDetraccion.Value.Date;
                            tmpVoucherItem.tipDetraccion = cboTipoDetraccion.SelectedValue.ToString();
                            tmpVoucherItem.TasaDetraccion = Convert.ToDecimal(txtTasaDetra.Text);
                            tmpVoucherItem.MontoDetraccion = Convert.ToDecimal(txtMontoDetraccion.Text);
                            tmpVoucherItem.indPagoDetra = chkIndPagoDetra.Checked;

                            if (String.IsNullOrEmpty(txtTasaDetra.Text.Trim()))
                            {
                                Global.MensajeComunicacion("Debe ingresar el monto de la detracción.");
                                tmpError = true;
                                break;
                            }
                            else
                            {
                                tmpVoucherItem.TasaDetraccion = Convert.ToDecimal(txtTasaDetra.Text);
                            }
                            
                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                            {
                                tmpVoucherItem.MontoDetraEntero = Math.Round(Convert.ToDecimal(tmpVoucherItem.MontoDetraccion), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                tmpVoucherItem.MontoDetraEntero = Math.Round(Convert.ToDecimal(tmpVoucherItem.MontoDetraccion) * Convert.ToDecimal(txtTipoCambio.Text), MidpointRounding.AwayFromZero);
                            }
                        }
                        else
                        {
                            tmpVoucherItem.flagDetraccion = Variables.NO;
                            tmpVoucherItem.numDetraccion = String.Empty;
                            tmpVoucherItem.fecDetraccion = (Nullable<DateTime>)null;
                            tmpVoucherItem.tipDetraccion = String.Empty;
                            tmpVoucherItem.MontoDetraccion = Variables.ValorCeroDecimal;
                            tmpVoucherItem.TasaDetraccion = Variables.ValorCeroDecimal;
                            tmpVoucherItem.indPagoDetra = true;
                        }
                    }
                    else
                    {
                        tmpVoucherItem.flagDetraccion = Variables.NO;
                        tmpVoucherItem.numDetraccion = String.Empty;
                        tmpVoucherItem.fecDetraccion = (Nullable<DateTime>)null;
                        tmpVoucherItem.tipDetraccion = String.Empty;
                        tmpVoucherItem.MontoDetraccion = Variables.ValorCeroDecimal;
                        tmpVoucherItem.TasaDetraccion = Variables.ValorCeroDecimal;
                        tmpVoucherItem.indPagoDetra = true;
                    } 

                    #endregion

                    tmpVoucherItem.nroDua = String.Empty;
                    tmpVoucherItem.idAlmacen = String.Empty;
                    tmpVoucherItem.tipMovimientoAlmacen = String.Empty;
                    tmpVoucherItem.numDocumentoAlmacen = String.Empty;
                    tmpVoucherItem.numItemAlmacen = String.Empty;
                    tmpVoucherItem.CajaSucursal = String.Empty;
                    tmpVoucherItem.indCompra = String.Empty;
                    tmpVoucherItem.indConciliado = "N";
                    tmpVoucherItem.indMovimientoAnterior = String.Empty;
                    tmpVoucherItem.codCuentaDestino = item.codCuentaDestino;
                    tmpVoucherItem.codCuentaTransferencia = item.codCuentaTransferencia;

                    #region Partida Presupuestal
                    
                    if (tmpVoucherItem.NombreColumna == "TOTAL" && !String.IsNullOrEmpty(item.tipPartidaPresu))
                    {
                        tmpVoucherItem.tipPartidaPresu = item.tipPartidaPresu;
                        tmpVoucherItem.codPartidaPresu = item.codPartidaPresu;
                    }
                    else
                    {
                        tmpVoucherItem.tipPartidaPresu = String.Empty;
                        tmpVoucherItem.codPartidaPresu = String.Empty;
                    }

                    if (tmpVoucherItem.NombreColumna == "TOTAL" && !String.IsNullOrEmpty(TipoPartida))
                    {
                        tmpVoucherItem.tipPartidaPresu = TipoPartida;
                        tmpVoucherItem.codPartidaPresu = txtCodPartida.Text;
                    }

                    #endregion Partida Presupuestal

                    if (tmpVoucherItem.indCuentaGastos == Variables.SI)
                    {
                        tmpVoucherItem.idConceptoGasto = String.IsNullOrEmpty(txtIdConcepto.Text) ? (Nullable<Int32>)null : Convert.ToInt32(txtIdConcepto.Text);
                        tmpVoucherItem.desConcepto = txtDesConcepto.Text;
                        tmpVoucherItem.idCampana = String.IsNullOrEmpty(txtIdCampana.Text) ? (Nullable<Int32>)null : Convert.ToInt32(txtIdCampana.Text);
                        tmpVoucherItem.desCampana = txtDesCampana.Text;
                    }
                    else
                    {
                        tmpVoucherItem.idConceptoGasto = (Nullable<Int32>)null;
                        tmpVoucherItem.idCampana = (Nullable<Int32>)null;
                    }

                    tmpVoucherItem.codMedioPago = Variables.Cero;
                    tmpVoucherItem.indReparable = Variables.NO;
                    tmpVoucherItem.idConceptoRep = (Nullable<Int32>)null;
                    tmpVoucherItem.desReferenciaRep = String.Empty;

                    #region Para la CtaCte

                    if (tmpVoucherItem.idComprobante == Variables.RegistroVenta || tmpVoucherItem.idComprobante == Variables.RegistroCompra)
                    {
                        if (item.indCtaCte == Variables.SI)
                        {
                            tmpVoucherItem.idAccion = EnumAccionCtaCte.A.ToString();
                            tmpVoucherItem.indCtaCte = Variables.SI;
                        }
                        else
                        {
                            tmpVoucherItem.idAccion = EnumAccionCtaCte.Z.ToString();
                            tmpVoucherItem.indCtaCte = Variables.NO;
                        }

                        tmpVoucherItem.idCtaCte = (Nullable<Int32>)null;
                        tmpVoucherItem.idCtaCteItem = (Nullable<Int32>)null;
                    }
                    else if (Convert.ToInt32(tmpVoucherItem.idComprobante) == (Int32)enumLibro.CajaIngreso || Convert.ToInt32(tmpVoucherItem.idComprobante) == (Int32)enumLibro.CajaEgreso)
                    {
                        if (item.indCtaCte == Variables.SI)
                        {
                            tmpVoucherItem.idAccion = EnumAccionCtaCte.M.ToString();
                            tmpVoucherItem.indCtaCte = Variables.SI;
                        }
                        else
                        {
                            tmpVoucherItem.idAccion = EnumAccionCtaCte.Z.ToString();
                            tmpVoucherItem.indCtaCte = Variables.NO;
                        }

                        tmpVoucherItem.idCtaCte = (Nullable<Int32>)null;
                        tmpVoucherItem.idCtaCteItem = (Nullable<Int32>)null;
                    }
                    else
                    {
                        tmpVoucherItem.idAccion = EnumAccionCtaCte.Z.ToString();
                        tmpVoucherItem.idCtaCte = (Nullable<Int32>)null;
                        tmpVoucherItem.idCtaCteItem = (Nullable<Int32>)null;
                    }

                    #endregion

                    tmpVoucherItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    tmpVoucherItem.FechaRegistro = VariablesLocales.FechaHoy;
                    tmpVoucherItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    tmpVoucherItem.FechaModificacion = VariablesLocales.FechaHoy;

                    tmpListaVoucherItems.Add(tmpVoucherItem);

                    numItem++;
                    tmpError = false;
                }

                if (!tmpError)
                {
                    String Entro = "N";

                    if (ChkDetraccion.Checked)
                    {
                        List<VoucherItemE> oListaTemp = new List<VoucherItemE>();
                        String CuentaDetraccion = String.Empty;

                        foreach (VoucherItemE item in tmpListaVoucherItems)
                        {
                            oVoucher.ListaVouchers.Add(item);

                            if (item.flagDetraccion == Variables.SI)
                            {
                                if (oParametrosConta != null)
                                {
                                    if (!oParametrosConta.indDiarioDetra)
                                    {
                                        if (oParametrosConta.indDetraccion)
                                        {
                                            if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                                            {
                                                CuentaDetraccion = oParametrosConta.ctaDetraccion;

                                                if (String.IsNullOrWhiteSpace(CuentaDetraccion))
                                                {
                                                    Global.MensajeComunicacion("Falta configurar la Cuenta de Detración Soles en Parametros de Contabilidad.");
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                CuentaDetraccion = oParametrosConta.ctaDetraccionDol;

                                                if (String.IsNullOrWhiteSpace(oParametrosConta.ctaDetraccionDol))
                                                {
                                                    Global.MensajeComunicacion("Falta configurar la Cuenta de Detración Dólares en Parametros de Contabilidad.");
                                                    return;
                                                }
                                            }
                                            oListaTemp.Add(ItemDetraccion(item, Variables.Debe, item.codCuenta, "N"));
                                            oListaTemp.Add(ItemDetraccion(item, Variables.Haber, CuentaDetraccion, "S"));
                                        }                                     
                                    }
                                }
                            }

                            if (item.indAutomatica == "S")
                            {
                                if (Entro == "N")
                                {
                                    oVoucher.ListaVouchers.Remove(item);

                                    foreach (VoucherItemE itemD in oListaTemp)
                                    {
                                        oVoucher.ListaVouchers.Add(itemD);
                                    }

                                    oVoucher.ListaVouchers.Add(item);
                                    Entro = "S";
                                }
                            }
                        }

                        //Reenumerando los items
                        numItem = 1;

                        foreach (VoucherItemE item in oVoucher.ListaVouchers)
                        {
                            item.numItem = String.Format("{0:00000}", numItem);
                            numItem++;
                        }
                    }
                    else
                    {
                        oVoucher.ListaVouchers = tmpListaVoucherItems;
                    }

                    bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                    bsListaVouchers.ResetBindings(false);
                    tbVouchers.SelectedTab = tpMovimiento;
                    SumarTotales();
                    btGenerar.Enabled = false;
                    LimpiarGeneracion();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCuenta_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCuenta.TextLength > 0)
                {
                    oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuenta.Text.Trim());

                    if (oPlanCuentasGenerado != null)
                    {
                        txtDesCuenta.Text = oPlanCuentasGenerado.Descripcion;
                        HabilitaTextBoxMovimientos("CN");

                        if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoConceptosCompraVentas.TotalGeneral)
                        {
                            Global.MensajeFault("La cuenta seleccionada no pertenece a la columna de Totales definida en el Plan Contable");
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("La cuenta ingresada no existe, vuelva a digitar.");
                        txtDesCuenta.Text = String.Empty;
                        btCuenta.PerformClick();
                    }

                    oPlanCuentasGenerado = null;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oPlanCuentasGenerado = oVoucherItem.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(oFrm.Cuentas.codCuenta);
                    oVoucherItem.codCuenta = txtCuenta.Text = oVoucherItem.PlanCuenta.codCuenta;
                    txtDesCuenta.Text = oVoucherItem.PlanCuenta.Descripcion;
                    HabilitaTextBoxMovimientos("CN");

                    if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoTotal.Total)
                    {
                        Global.MensajeFault("La cuenta seleccionado no pertenece al Tipo Cuenta Total");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCuentaIG_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oPlanCuentasGenerado = oVoucherItem.PlanCuenta = VariablesLocales.ObtenerPlanCuenta(oFrm.Cuentas.codCuenta);

                    oVoucherItem.codCuenta = txtCuentaIG.Text = oVoucherItem.PlanCuenta.codCuenta;
                    TipoPartida = oVoucherItem.PlanCuenta.tipPartidaPresu;
                    txtCodPartida.Text = oVoucherItem.PlanCuenta.codPartidaPresu;
                    txtDesPartida.Text = oVoucherItem.PlanCuenta.desPartidaPresu;
                    txtDesCuentaIG.Text = oVoucherItem.PlanCuenta.Descripcion;
                    indCtaGasto = oVoucherItem.PlanCuenta.indCuentaGastos;
                    HabilitaTextBoxMovimientos("IG");
                    ValidarCuentaCC(sender, e);

                    if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoConceptosCompraVentas.BaseImponible)
                    {
                        Global.MensajeFault("La cuenta seleccionada no pertenece a la columna de Bases Imponibles definida en el Plan Contable");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btRuc_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                idPersona = oFrm.oPersona.IdPersona;
                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = RazonSocial = oFrm.oPersona.RazonSocial;
                txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
            }
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {
            Int32 Nivel = 1;

            if (oParametrosConta != null)
            {
                if (oParametrosConta.numNivelCCosto > 0)
                {
                    Nivel = Convert.ToInt32(oParametrosConta.numNivelCCosto);
                }
            }

            FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
            {
                txtCCostos.Text = oVoucherItem.idCCostos = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void btCosto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarHojaDeCostoOC oFrm = new frmBuscarHojaDeCostoOC();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oHojaCosto != null)
                {
                    chkIndCosto.Checked = true;
                    txtNumHojaCosto.Text = oFrm.oHojaCosto.idHojaCosto.ToString();
                }
                else
                {
                    chkIndCosto.Checked = false;
                    txtNumHojaCosto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (cboDocumento.SelectedValue.ToString() == "FV" || cboDocumento.SelectedValue.ToString() == "BV" || cboDocumento.SelectedValue.ToString() == "NC" || cboDocumento.SelectedValue.ToString() == "ND")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtSerie.TextLength < txtSerie.MaxLength && Global.EsNumero(txtSerie.Text))
                    {
                        txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
                    }
                }
            }
            else if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtSerie.TextLength < txtSerie.MaxLength && Global.EsNumero(txtSerie.Text))
                    {
                        txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
                    }
                }
            }
        }

        private void txtNumDoc_Leave(object sender, EventArgs e)
        {
            if (cboDocumento.SelectedValue.ToString() == "FV" || cboDocumento.SelectedValue.ToString() == "BV" || cboDocumento.SelectedValue.ToString() == "NC" || cboDocumento.SelectedValue.ToString() == "ND")
            {
                if (!String.IsNullOrEmpty(txtNumDoc.Text.Trim()))
                {
                    if (txtNumDoc.TextLength < txtNumDoc.MaxLength && Global.EsNumero(txtNumDoc.Text))
                    {
                        txtNumDoc.Text = txtNumDoc.Text.PadLeft(8, '0');
                    }
                }
            }
            else if (cboDocumento.SelectedValue.ToString() == "FC" || cboDocumento.SelectedValue.ToString() == "BR" || cboDocumento.SelectedValue.ToString() == "CR" || cboDocumento.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerie.Text.Trim()))
                {
                    if (txtNumDoc.TextLength < txtNumDoc.MaxLength && Global.EsNumero(txtNumDoc.Text))
                    {
                        txtNumDoc.Text = txtNumDoc.Text.PadLeft(8, '0');
                    }
                }
            }
        }

        private void txtSerieRef_Leave(object sender, EventArgs e)
        {
            if (cboReferencia.SelectedValue.ToString() == "FV" || cboReferencia.SelectedValue.ToString() == "NC" || cboReferencia.SelectedValue.ToString() == "ND")
            {
                if (!String.IsNullOrEmpty(txtSerieRef.Text.Trim()))
                {
                    if (txtSerieRef.TextLength < txtSerieRef.MaxLength && Global.EsNumero(txtSerieRef.Text))
                    {
                        txtSerieRef.Text = txtSerieRef.Text.PadLeft(4, '0');
                    }
                } 
            }
            else if (cboReferencia.SelectedValue.ToString() == "FC" || cboReferencia.SelectedValue.ToString() == "BR" || cboReferencia.SelectedValue.ToString() == "CR" || cboReferencia.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtSerieRef.Text.Trim()))
                {
                    if (txtSerieRef.TextLength < txtSerieRef.MaxLength && Global.EsNumero(txtSerieRef.Text))
                    {
                        txtSerieRef.Text = txtSerieRef.Text.PadLeft(4, '0');
                    }
                }
            }
        }

        private void txtNumDocRef_Leave(object sender, EventArgs e)
        {
            if (cboReferencia.SelectedValue.ToString() == "FV" || cboReferencia.SelectedValue.ToString() == "NC" || cboReferencia.SelectedValue.ToString() == "ND")
            {
                if (!String.IsNullOrEmpty(txtNumDoc.Text.Trim()))
                {
                    if (txtNumDocRef.TextLength < txtNumDocRef.MaxLength && Global.EsNumero(txtNumDocRef.Text))
                    {
                        txtNumDocRef.Text = txtNumDocRef.Text.PadLeft(8, '0');
                    }
                } 
            }
            else if (cboReferencia.SelectedValue.ToString() == "FC" || cboReferencia.SelectedValue.ToString() == "BR" || cboReferencia.SelectedValue.ToString() == "CR" || cboReferencia.SelectedValue.ToString() == "DR")
            {
                if (!String.IsNullOrEmpty(txtNumDocRef.Text.Trim()))
                {
                    if (txtNumDocRef.TextLength < txtNumDocRef.MaxLength && Global.EsNumero(txtNumDocRef.Text))
                    {
                        txtNumDocRef.Text = txtNumDocRef.Text.PadLeft(8, '0');
                    }
                }
            }
        }

        private void dgvMovimientosVouchers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (OFF != "DESACTIVADO")
                {
                    if (tbVouchers.SelectedTab == tpMovimiento)
                    {
                        if (e.RowIndex != -1)
                        {
                            if (((VoucherItemE)bsListaVouchers.Current).indAutomatica.Substring(0, 1) == Variables.NO)
                            {
                                EditarDetalle(e, (VoucherItemE)bsListaVouchers.Current);
                            }
                            else
                            {
                                Global.MensajeComunicacion("Se trata de una cuenta automática, no podra hacer ninguna modificación.");
                            }
                        }
                    }
                }
                else
                {
                  
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tbVouchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbVouchers.SelectedTab == tpMovimiento)
            {
                if (!ValidarCabecera())
                {
                    tbVouchers.SelectedTab = tpRegistro;
                }
                else
                {
                    if (((ComprobantesFileE)cboFile.SelectedItem).LLevaCuenta)
                    {
                        if (oVoucher.ListaVouchers.Count() == 0)
                        {
                            AgregarDetalle();
                        }
                    }
                }
            }
        }

        private void txtBaseAfecta_TextChanged(object sender, EventArgs e)
        {            
            // Base
            Decimal.TryParse(txtBaseAfecta.Text, out Decimal MontoAfecto);
            // Igv
            Decimal Igv = Decimal.Round(MontoAfecto * ValorIgv, 2);
            txtIgv.Text = Igv.ToString("N2");
            Decimal.TryParse(txtIgv.Text, out decimal MontoIgv);
            //Monto Inafecto
            Decimal.TryParse(txtBaseInafecta.Text, out decimal MontoInafecto);
            txtTotal.Text = Decimal.Round((MontoIgv + MontoInafecto + MontoAfecto), 2).ToString("###,##0.00");

            if (cboTipoDetraccion.SelectedValue != null)
            {
                if (ChkDetraccion.Checked && cboTipoDetraccion.SelectedValue.ToString() != Variables.Cero.ToString())
                {
                    cboTipoDetraccion_SelectionChangeCommitted(new Object(), new EventArgs());
                } 
            }
        }

        private void txtBaseInafecta_TextChanged(object sender, EventArgs e)
        {
            //Base
            Decimal.TryParse(txtBaseAfecta.Text, out decimal MontoAfecto);
            //Igv
            Decimal Igv = Decimal.Round(MontoAfecto * ValorIgv, 2);
            txtIgv.Text = Igv.ToString("N2");
            Decimal.TryParse(txtIgv.Text, out decimal montoigv);
            //Monto Inafecto
            Decimal.TryParse(txtBaseInafecta.Text, out decimal montoInafecto);
            txtTotal.Text = Decimal.Round((montoigv + montoInafecto + MontoAfecto), 2).ToString("###,##0.00");

            if (cboTipoDetraccion.SelectedValue != null)
            {
                if (ChkDetraccion.Checked && cboTipoDetraccion.SelectedValue.ToString() != Variables.Cero.ToString())
                {
                    cboTipoDetraccion_SelectionChangeCommitted(new Object(), new EventArgs());
                } 
            }
        }

        private void txtBaseAfecta_Enter(object sender, EventArgs e)
        {
            txtBaseAfecta.SeleccinarTodo();
        }

        private void txtBaseAfecta_MouseClick(object sender, MouseEventArgs e)
        {
            txtBaseAfecta.SeleccinarTodo();
        }

        private void txtMontoSinDerecho_Enter(object sender, EventArgs e)
        {
            txtMontoSinDerecho.SeleccinarTodo();
        }

        private void txtMontoSinDerecho_MouseClick(object sender, MouseEventArgs e)
        {
            txtMontoSinDerecho.SeleccinarTodo();
        }

        private void txtBaseInafecta_Enter(object sender, EventArgs e)
        {
            txtBaseInafecta.SeleccinarTodo();
        }

        private void txtBaseInafecta_MouseClick(object sender, MouseEventArgs e)
        {
            txtBaseInafecta.SeleccinarTodo();
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (String.IsNullOrEmpty(ErrorSalto))
            {
                e.Handled = true;
                Global.Pasar(e);
                ComboHelper.AutoCompletar(cboDocumento, e, false);
            }
        }

        private void cboReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            ComboHelper.AutoCompletar(cboReferencia, e, false);
        }

        private void cboTipoDetraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = ((DateTimePicker)sender).Value;
                Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, cboMonedas.SelectedValue.ToString(), Libro);

                if (Monto == 0)
                {
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }

                txtTipoCambio.Text = Monto.ToString("N3");
                LlenarComboDetraccion(dtpFecDocumento.Value.Date);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboTipoDetraccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtTotal.Text != Variables.Cero.ToString("N2"))
            {
                TasasDetraccionesDetalleE oDetraccion = ((TasasDetraccionesDetalleE)cboTipoDetraccion.SelectedItem);

                if (oDetraccion != null)
                {
                    txtTasaDetra.Text = oDetraccion.Porcentaje.ToString("N2");
                    Decimal Importe = Variables.ValorCeroDecimal;

                    if (cboMonedas.SelectedValue.ToString() == Variables.Soles)
                    {
                        Decimal.TryParse(txtTotal.Text, out Importe);
                        txtMontoDetraccion.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * Importe, 2).ToString("N2");
                    }
                    else
                    {
                        Decimal.TryParse(txtTotal.Text, out Importe);
                        txtMontoDetraccion.Text = Decimal.Round((oDetraccion.Porcentaje / 100) * Importe, 2).ToString("N2");
                    }
                }
                else
                {
                    txtTasaDetra.Text = Variables.ValorCeroDecimal.ToString("N2");
                    txtMontoDetraccion.Text = Variables.ValorCeroDecimal.ToString("N2");
                }
            }
            else
	        {
                Global.MensajeComunicacion("Debe ingresar el monto total primero.");
                cboTipoDetraccion.SelectedValue = Variables.Cero.ToString();
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
                Global.MensajeError(ex.Message);
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
                Global.MensajeError(ex.Message);
            }
        }

        private void btQuitarCuentas_Click(object sender, EventArgs e)
        {
            try
            {
              EliminarAutomaticos();
              SumarTotales();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btDiferencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (oVoucher.ListaVouchers.Count > Variables.Cero)
                {
                    Decimal DiferenciaSoles = Convert.ToDecimal(txtDiferenciaSoles.Text);
                    Decimal DiferenciaDolares = Convert.ToDecimal(txtDiferenciaDolares.Text);

                    if (DiferenciaSoles == Variables.Cero && DiferenciaDolares == Variables.Cero)
                    {
                        return;
                    }

                    if (DiferenciaSoles != Variables.Cero)
                    {
                        AjusteDiferenciaCambio("S", DiferenciaSoles);
                    }
                    else if (DiferenciaDolares != Variables.Cero)
                    {
                        AjusteDiferenciaCambio("D", DiferenciaDolares);
                    }

                    SumarTotales();
                    bFlag = true;
                    Modificacion = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btAjusteBase_Click(object sender, EventArgs e)
        {
            if (oVoucher.ListaVouchers.Count > Variables.Cero)
            {
                Decimal DiferenciaSoles = Convert.ToDecimal(txtDiferenciaSoles.Text);
                Decimal DiferenciaDolares = Convert.ToDecimal(txtDiferenciaDolares.Text);

                foreach (VoucherItemE item in oVoucher.ListaVouchers)
                {
                    if (item.indAutomatica.Substring(0, 1) == Variables.NO)
                    {
                        if (item.NombreColumna.Contains("BASE"))// && Base == Variables.Cero)
                        {
                            //Base = Variables.ValorUno;
                            if (Math.Abs(DiferenciaSoles) > 0.3M || Math.Abs(DiferenciaDolares) > 0.3M)
                            {
                                Global.MensajeFault("El ajuste permitido es 0.3 como máximo.");
                                return;
                            }

                            if (DiferenciaSoles != Variables.Cero)
                            {
                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    item.impSoles -= DiferenciaSoles;
                                }
                                else
                                {
                                    item.impSoles += DiferenciaSoles;
                                }
                            }
                            else
                            {
                                if (item.indDebeHaber == Variables.Debe)
                                {
                                    item.impDolares -= DiferenciaDolares;
                                }
                                else
                                {
                                    item.impDolares += DiferenciaDolares;
                                }
                            }

                            item.indCambio = Variables.NO;

                            //Saliendo del bucle en la primera incidencia...
                            break;
                        } 
                    }
                }

                SumarTotales();
                bsListaVouchers.DataSource = oVoucher.ListaVouchers;
                bsListaVouchers.ResetBindings(false);
                bFlag = true;
                Modificacion = true; 
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRuc.Text.Trim()) || String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtRuc.Text.Trim()))
                    {
                        List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                        if (oListaPersonas.Count > Variables.ValorUno)
                        {
                            frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                            {
                                txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                                txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                                idPersona = oFrm.oPersona.IdPersona;
                                txtRuc.Text = oFrm.oPersona.RUC;
                                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                                txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                                txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                                ValidarCuentaCC(sender, e);

                                if (txtCCostos.Enabled)
                                {
                                    txtCCostos.Focus();
                                }
                                else
                                {
                                    cboDocumento.Focus();
                                }
                            }
                            else
                            {
                                txtRazonSocial.Focus();
                            }
                        }
                        else if (oListaPersonas.Count == 1)
                        {
                            txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                            idPersona = oListaPersonas[0].IdPersona;
                            txtRuc.Text = oListaPersonas[0].RUC;
                            txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                            txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                            ValidarCuentaCC(sender, e);

                            if (txtCCostos.Enabled)
                            {
                                txtCCostos.Focus();
                            }
                            else
                            {
                                cboDocumento.Focus();
                            }
                        }
                        else
                        {
                            txtRazonSocial.Text = String.Empty;
                            Global.MensajeFault("EL Ruc ingresado no existe");
                            btRuc.PerformClick();
                        }
                    }
                    else
                    {
                        txtRazonSocial.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCCostos_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCCostos.Text.Trim()))
                {
                    CCostosE oCCosto = AgenteMaestro.Proxy.ObtenerCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCCostos.Text.Trim());

                    if (oCCosto != null)
                    {
                        txtCCostos.Text = oCCosto.idCCostos;
                        txtDesCCostos.Text = oCCosto.desCCostos;
                    }
                    else
                    {
                        txtDesCCostos.Text = String.Empty;
                        Global.MensajeFault("EL código ingresado no existe");
                        btCentroC.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void frmVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                btGenerar.PerformClick();
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            idPersona = 0;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtCCostos_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCCostos.Text.Trim()))
            {
                txtDesCCostos.Text = String.Empty;
            }
        }

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();
            
            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                TipoPartida = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                txtCodPartida.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                txtDesPartida.Text = oFrm.oPartidaPresupuestal.desPartidaPresu;
            }
        }

        private void txtNumDetra_Leave(object sender, EventArgs e)
        {
            dtpFecDetraccion.Focus();
        }

        private void dtpFecDetraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void cboDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumento.SelectedValue.ToString() != Variables.Cero.ToString())
                {
                    if (((DocumentosE)cboDocumento.SelectedItem).indReferencia)
                    {
                        cboReferencia.Enabled = true;
                        cboReferencia.SelectedValue = Variables.Cero.ToString();
                        txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                        txtNumDocRef.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, Variables.SI);
                        dtpFechaRef.Enabled = true;
                        dtpFechaRef.Checked = true;

                        dtpFechaRef_ValueChanged(new object(), new EventArgs());
                    }
                    else
                    {
                        cboReferencia.Enabled = false;
                        cboReferencia.SelectedValue = Variables.Cero.ToString();
                        txtSerieRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                        txtNumDocRef.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                        dtpFechaRef.Enabled = false;
                        dtpFechaRef.Checked = false;
                    }
                }

                List<ImpuestosDocumentosE> oListaImpuestoDocumento = AgenteGeneral.Proxy.ListarImpuestosPorIdDocumento(((ComboBox)sender).SelectedValue.ToString());

                if (oListaImpuestoDocumento != null && oListaImpuestoDocumento.Count > Variables.Cero)
                {
                    ImpuestosDocumentosE oImpuestoTmp = (from x in oListaImpuestoDocumento
                                                         where x.idImpuesto == 1
                                                         select x).SingleOrDefault();
                    if (oImpuestoTmp != null)
                    {
                        ImpuestosPeriodoE oImpuestosPeriodo = AgenteGeneral.Proxy.ObtenerPorcentajeImpuesto(oImpuestoTmp.idImpuesto, dtpFecOperacion.Value.Date);

                        if (oImpuestosPeriodo != null)
                        {
                            lblIgv.Text = oImpuestosPeriodo.Porcentaje.ToString() + " %";
                            ValorIgv = Convert.ToDecimal(oImpuestosPeriodo.Porcentaje) / 100;
                            CuentaIgv = oImpuestosPeriodo.codCuenta;

                            ErrorSalto = String.Empty;
                            txtBaseAfecta_TextChanged(new Object(), new EventArgs());
                        }
                        else
                        {
                            Global.MensajeFault("Este documento tiene un impuesto asignado, pero el periodo de vigencia esta vencido.\n\rModifiquelo y vuelva a intentarlo.");
                            ErrorSalto = "1";
                            return;
                        }
                    }
                    else
                    {
                        Global.MensajeFault("No existe ningun impuesto asignado al documento.");
                    }
                }
                else
                {
                    lblIgv.Text = String.Empty;
                    ValorIgv = Variables.Cero;
                    CuentaIgv = String.Empty;

                    txtBaseAfecta_TextChanged(new Object(), new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboReferencia_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboReferencia.Text))
            {
                cboReferencia.SelectedValue = Variables.Cero.ToString();
            }
        }

        private void cboDocumento_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboDocumento.Text))
            {
                cboDocumento.SelectedValue = Variables.Cero.ToString();
            }
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRuc.Text.Trim()) || String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                            idPersona = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                            txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                            txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                            ValidarCuentaCC(sender, e);

                            if (txtCCostos.Enabled)
                            {
                                txtCCostos.Focus();
                            }
                            else
                            {
                                cboDocumento.Focus();
                            }

                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.TextChanged -= new EventHandler(txtRuc_TextChanged);
                        txtRazonSocial.TextChanged -= new EventHandler(txtRazonSocial_TextChanged);
                        idPersona = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                        txtRuc.TextChanged += new EventHandler(txtRuc_TextChanged);
                        txtRazonSocial.TextChanged += new EventHandler(txtRazonSocial_TextChanged);
                        ValidarCuentaCC(sender, e);

                        if (txtCCostos.Enabled)
                        {
                            txtCCostos.Focus();
                        }
                        else
                        {
                            cboDocumento.Focus();
                        }
                    }
                    else
                    {
                        txtRazonSocial.Text = String.Empty;
                        Global.MensajeFault("La Razón Social ingresada no existe.");
                        btRuc.PerformClick();
                    }
                }
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            //if (txtCuenta.TextLength == 0 )
            //{
                txtDesCuenta.Text = String.Empty;
                HabilitaTextBoxMovimientos("CN");
            //}
        }

        private void txtCuentaIG_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaIG.Text = String.Empty;
            indCtaGasto = String.Empty;
            CCostoCuenta = String.Empty;
            HabilitaTextBoxMovimientos("IG");
        }

        private void dtpFecVencimientoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboReferencia.Enabled)
                {
                    cboReferencia.Focus();
                }
                else
                {
                    txtBaseAfecta.Focus();
                }
            }
        }

        private void txtBaseAfecta_Leave(object sender, EventArgs e)
        {
            txtBaseAfecta.Text = Global.FormatoDecimal(txtBaseAfecta.Text);
        }

        private void txtMontoSinDerecho_Leave(object sender, EventArgs e)
        {
            txtMontoSinDerecho.Text = Global.FormatoDecimal(txtMontoSinDerecho.Text);
        }

        private void txtBaseInafecta_Leave(object sender, EventArgs e)
        {
            txtBaseInafecta.Text = Global.FormatoDecimal(txtBaseInafecta.Text);
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            idPersona = 0;
            txtRuc.Text = String.Empty;
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!txtCCostos.Enabled)
                {
                    cboDocumento.Focus();
                }
                else
                {
                    txtCCostos.Focus();
                }
            }
        }

        private void btBuscarProyecto_Click(object sender, EventArgs e)
        {
            if (indCtaGasto == Variables.SI)
            {
                frmBuscarCampanas oFrm = new frmBuscarCampanas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCampana != null)
                {
                    txtIdCampana.Text = oFrm.oCampana.idCampana.ToString();
                    txtDesCampana.Text = oFrm.oCampana.Nombre;
                }
            }
            else
            {
                Global.MensajeComunicacion("Tiene que ingresar una cuenta de gasto!!!");
            }
        }

        private void btBuscarGasto_Click(object sender, EventArgs e)
        {
            if (indCtaGasto == Variables.SI)
            {
                frmBuscarConceptosGasto oFrm = new frmBuscarConceptosGasto();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    txtIdConcepto.Text = oFrm.oConcepto.idConcepto.ToString();
                    txtDesConcepto.Text = oFrm.oConcepto.desConcepto;
                }
            }
            else
            {
                Global.MensajeComunicacion("Tiene que ingresar una cuenta de gasto!!!");
            }
        }

        private void txtCuentaIG_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCuentaIG.Text.Trim()) || String.IsNullOrEmpty(txtDesCuentaIG.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtCuentaIG.Text.Trim()))
                    {
                        oPlanCuentasGenerado = VariablesLocales.ObtenerPlanCuenta(txtCuentaIG.Text.Trim());

                        if (oPlanCuentasGenerado != null)
                        {
                            txtDesCuentaIG.Text = oPlanCuentasGenerado.Descripcion;
                            indCtaGasto = oPlanCuentasGenerado.indCuentaGastos;
                            HabilitaTextBoxMovimientos("IG");
                            ValidarCuentaCC(sender, e);

                            if (!String.IsNullOrEmpty(oPlanCuentasGenerado.codPartidaPresu))
                            {
                                TipoPartida = oPlanCuentasGenerado.tipPartidaPresu;
                                txtCodPartida.Text = oPlanCuentasGenerado.codPartidaPresu;
                                txtDesPartida.Text = oPlanCuentasGenerado.desPartidaPresu;
                            }

                            if (oPlanCuentasGenerado.codColumnaCoven != (Int32)EnumTipoConceptosCompraVentas.BaseImponible)
                            {
                                Global.MensajeFault("La cuenta seleccionada no pertenece a la columna de Bases Imponibles definida en el Plan Contable");
                            }
                        }
                        else
                        {
                            Global.MensajeComunicacion("La cuenta ingresada no existe, vuelva a digitar.");
                            txtDesCuentaIG.Text = String.Empty;
                            btCuentaIG.PerformClick();
                        }

                        oPlanCuentasGenerado = null; 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboReferencia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboReferencia.SelectedValue.ToString() != Variables.Cero.ToString())
            {
                NumControlDetE oControlDoc = VariablesLocales.ListaDetalleNumControl.Find
                (
                    delegate (NumControlDetE nc) { return nc.idDocumento == cboReferencia.SelectedValue.ToString(); }
                );

                if (oControlDoc != null)
                {
                    txtSerieRef.MaxLength = Convert.ToInt32(oControlDoc.cantDigSerie);
                    txtNumDocRef.MaxLength = Convert.ToInt32(oControlDoc.cantDigNumero);

                    if (!String.IsNullOrEmpty(txtSerieRef.Text.Trim()))
                    {
                        if (txtSerieRef.TextLength > txtSerieRef.MaxLength)
                        {
                            txtSerieRef.Text = txtSerieRef.Text.Substring(0, txtSerieRef.MaxLength);
                        }
                    }
                    
                    if (!String.IsNullOrEmpty(txtNumDocRef.Text.Trim()))
                    {
                        if (txtNumDocRef.TextLength > txtNumDocRef.MaxLength)
                        {
                            txtNumDocRef.Text = txtNumDocRef.Text.Substring(0, txtNumDocRef.MaxLength);
                        }
                    }
                }
                else
                {
                    txtSerieRef.MaxLength = 20;
                    txtNumDocRef.MaxLength = 20;
                } 
            }
            else
            {
                txtSerieRef.MaxLength = 20;
                txtNumDocRef.MaxLength = 20;
            }
        }

        private void btBuscarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Excel", "Libro de Excel (*.xlsx)|*.xlsx|Libro de Excel 97-2003 (*.xls)|*.xls|Archivos XML|*.xml");
                btObtenerDatos.Enabled = !String.IsNullOrEmpty(txtRuta.Text);

                //if (!String.IsNullOrEmpty(txtRuta.Text))
                //{
                //    btObtenerDatos.Enabled = true;
                //}
                //else
                //{
                //    btObtenerDatos.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btObtenerDatos_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Debe buscar el archivo antes de importar.");
                    btBuscarArchivo.Focus();
                    return;
                }

                #endregion Validaciones

                //FileInfo oFi = new FileInfo(txtRuta.Text);

                //if (!oFi.Exists)
                //{
                //    Global.MensajeFault("Compruebe si existe el archivo.");
                //    return;
                //}

                lblProcesando.Visible = true;
                timer.Enabled = true;
                Marque = "Importando Voucher...";
                pbProgress.Visible = true;
                Cursor = Cursors.WaitCursor;

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                letra += 1;

                if (letra == Marque.Length)
                {
                    lblProcesando.Text = String.Empty;
                    letra = 0;
                }
                else
                {
                    lblProcesando.Text += Marque.Substring(letra - 1, 1);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvMovimientosVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvMovimientosVouchers.Rows[e.RowIndex].Cells["indAutomatica"].Value != null)
                {
                    if (Convert.ToString(dgvMovimientosVouchers.Rows[e.RowIndex].Cells["indAutomatica"].Value).Substring(0, 1) == Variables.SI)
                    {
                        if (e.Value != null)
                        {
                            e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(2, 35, 174);
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }   
        }

        private void dtpFechaRef_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaRef.Enabled && dtpFechaRef.Checked)
            {
                DateTime Fecha = dtpFechaRef.Value;
                Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, cboMonedas.SelectedValue.ToString(), Libro);

                if (Monto == 0)
                {
                    Global.MensajeFault("La fecha de la referencia no tiene Tipo de Cambio, escoja otra fecha.");
                }

                txtTicaRef.Text = Monto.ToString("N3");
            }
        }

        #endregion Eventos

    }
}
