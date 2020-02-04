using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorCobrar;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

using OfficeOpenXml;
//using OfficeOpenXml.Style;

namespace ClienteWinForm.CtasPorCobrar
{
    public partial class frmConciliacionCobranzas : FrmMantenimientoBase
    {

        public frmConciliacionCobranzas()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvCobranzas, true);
            FormatoGrid(dgvImportados, true);
            LlenarCombos();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        CtasPorCobrarServiceAgent AgenteCobranzas { get { return new CtasPorCobrarServiceAgent(); } }
        List<CobranzasItemE> ListaCobranzasPrincipal = null;
        List<CobranzasConciliacionE> ListaConciliacionPrincipal = null;
        List<CobranzasConciliacionE> ConciliacionCobranzas = null;
        String Tipo = String.Empty;
        Int32 LineaError = 0;
        Int32 Registros = 0;
        Int32 letra = 0;
        String Marquee = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        //Boolean SinConciliar = false;
        Int32 Numero = 1;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Bancos
            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListarBancos.Add(new BancosE() { idPersona = Variables.Cero, RazonSocial = Variables.Seleccione });
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");

            //Monedas
            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");

            oListaMonedas = null;
            oListarBancos = null;
        }

        void LlenarCuentasBancarias(Int32 idBanco, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasPorBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idBanco, idMoneda);
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentas, (from x in oListaCuentas orderby x.idPersona select x).ToList(), "codCuenta", "NumCuenta");

            if (cboCuentas.SelectedValue != null)
            {
                txtCodCuenta.Text = cboCuentas.SelectedValue.ToString();
                ObtenerCuentaContable(txtCodCuenta.Text.Trim());
                //BancosCuentasE Obancotmp = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodCuenta.Text);
                //txtNomCuenta.Text = Obancotmp.DescripcionCuenta;
            }
            else
            {
                txtCodCuenta.Text = "";
                txtNomCuenta.Text = "";
            }

            oListaCuentas = null;
        }

        void ImportarExcel(String Ruta)
        {
            FileInfo oFi_ = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(oFi_))
            {
                //Entidad
                CobranzasConciliacionE oCobranzasConci = null;
                //Excel
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                //Para el recorrido del excel
                Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;
                //Detectando Banco para recuperar persona
                String codCuenta = oHoja.Cells[3, 4].Value.ToString();
                BancosCuentasE BancoPersona = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(Convert.ToInt32(oHoja.Cells[2, 1].Value), codCuenta);

                //Recorriendo la hoja excel hasta el total de fila obtenido...
                for (int f = 6; f <= totFilasExcel; f++)
                {
                    if (oHoja.Cells[f, 1].Value != null)
                    {
                        LineaError = f;
                        oCobranzasConci = new CobranzasConciliacionE()
                        {
                            idPersona = BancoPersona.idPersona,
                            idEmpresa = Convert.ToInt32(oHoja.Cells[2, 1].Value),
                            RazonSocial = BancoPersona.RazonSocial,
                            Fecha = Convert.ToDateTime(oHoja.Cells[f, 1].Value),
                            Glosa = oHoja.Cells[f, 2].Value.ToString(),
                            Monto = Convert.ToDecimal(oHoja.Cells[f, 3].Value),
                            Operacion = oHoja.Cells[f, 4].Value.ToString().Trim(),
                            codCuenta = codCuenta,
                        };

                        if (oCobranzasConci.Monto > 0)
                        {
                            ConciliacionCobranzas.Add(oCobranzasConci);
                        }
                    }
                }

                ListaConciliacionPrincipal = new List<CobranzasConciliacionE>(ConciliacionCobranzas);
            }
        }

        void ObtenerCuentaContable(String Cuenta)
        {
            BancosCuentasE oBancoTmp = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodCuenta.Text);
            txtNomCuenta.Text = oBancoTmp.DescripcionCuenta;
        }

        void SumarMontos()
        {
            if (ListaCobranzasPrincipal.Count > 0)
            {
                Decimal TotalCobranzas = (from x in ListaCobranzasPrincipal select x.Monto).Sum();
                txtMontoTotal.Text = TotalCobranzas.ToString("N2");
            }
            else
            {
                txtMontoTotal.Text = "0.00";
            }
            if (ListaConciliacionPrincipal.Count > 0)
            {
                Decimal Total = (from x in ListaConciliacionPrincipal select x.Monto).Sum();
                txtMontoImportados.Text = Total.ToString("N2");
            }
            else
            {
                txtMontoImportados.Text = "0.00";
            }
        }

        void BuscarNumeracion()
        {
            if (ListaCobranzasPrincipal.Count > 0 && ListaConciliacionPrincipal.Count > 0)
            {
                String NumeroV = String.Empty;
                String NumeroC = String.Empty;
                Boolean Encontro = true;
                //Int32 Numero = 1;

                foreach (CobranzasItemE item in ListaCobranzasPrincipal)
                {
                    if (item.indConciliado)
                    {
                        NumeroV = item.numCheque.Trim().PadLeft(10, '0');
                        NumeroV = Global.Derecha(NumeroV, 10);
                        Encontro = false;

                        // Validar Con Numero de Documento 
                        foreach (CobranzasConciliacionE itemConc in ListaConciliacionPrincipal)
                        {
                            NumeroC = itemConc.Operacion.Trim().PadLeft(10, '0');
                            NumeroC = Global.Derecha(NumeroC, 10);

                            if (itemConc.Fecha.Date == item.fecCobranza.Value.Date && itemConc.Monto == item.Monto && NumeroV == NumeroC)
                            {
                                //Conciliación
                                itemConc.numItemConci = Numero;

                                //Cobranzas Item
                                item.numItemConci = Numero;
                                Encontro = true;

                                break;
                            }
                        }

                        // Validar Si no Encuentra por Fecha y Monto
                        if (!Encontro)
                        {
                            foreach (CobranzasConciliacionE itemConc in ListaConciliacionPrincipal)
                            {
                                if (itemConc.Fecha.Date == item.fecCobranza.Value.Date && itemConc.Monto == item.Monto)
                                {
                                    //Conciliación
                                    itemConc.numItemConci = Numero;

                                    //Cobranzas Item
                                    item.numItemConci = Numero;
                                    Encontro = true;

                                    break;
                                }
                            }
                        }

                        Numero++; 
                    }
                }

                bsCobranzas.DataSource = ListaCobranzasPrincipal;
                bsCobranzas.ResetBindings(false);

                bsConciliacion.DataSource = ListaConciliacionPrincipal;
                bsConciliacion.ResetBindings(false);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtCodCuenta.Text))
                {
                    Global.MensajeAdvertencia("Debe escoger una banco antes de hacer la búsqueda.");
                    return;
                }

                Numero = 1;
                bsCobranzas.DataSource = ListaCobranzasPrincipal = AgenteCobranzas.Proxy.ListarCobranzasItemPorCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtCodCuenta.Text, dtpInicial.Value.Date, dtpFinal.Value.Date);
                bsCobranzas.ResetBindings(false);

                bsConciliacion.DataSource = ListaConciliacionPrincipal = AgenteCobranzas.Proxy.ListarCobranzasConciliacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpInicial.Value.Date, dtpFinal.Value.Date, txtCodCuenta.Text.Trim());
                bsConciliacion.ResetBindings(false);

                //if (ListaConciliacionPrincipal != null && ListaConciliacionPrincipal.Count > 0)
                //{
                //    bsConciliacion.DataSource = ListaConciliacionPrincipal;
                //    bsConciliacion.ResetBindings(false);
                //}
                //else
                //{
                //    bsConciliacion.DataSource = ListaConciliacionPrincipal = AgenteCobranzas.Proxy.ListarCobranzasConciliacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpInicial.Value.Date, dtpFinal.Value.Date, txtCodCuenta.Text.Trim());
                //    bsConciliacion.ResetBindings(false);
                //}

                if (ListaCobranzasPrincipal.Count > 0)
                {
                    btConciliado.Enabled = true;
                    btLimpiar.Enabled = true;
                }

                BuscarNumeracion();
                SumarMontos();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            foreach (CobranzasConciliacionE item in ConciliacionCobranzas)
            {
                if (txtCodCuenta.Text.Trim() != item.codCuenta.Trim())
                {
                    Registros = 0;
                    Global.MensajeComunicacion("La Cuenta Contable no coincide con la cuenta de la hoja excel.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        public override void Imprimir()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()))
                {
                    List<CobranzasItemE> ListaReporte = AgenteCobranzas.Proxy.ReporteCobranzasConciliados(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtCodCuenta.Text, dtpInicial.Value.Date, dtpFinal.Value.Date, 2);

                    if (ListaReporte != null && ListaReporte.Count > 0)
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

                        oFrm = new frmImpresionBase(ListaReporte, "Conciliación de Cobranzas")
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Tipo == "I")
                {
                    ImportarExcel(txtRuta.Text);
                }
                else if (Tipo == "P")
                {
                    if (!ValidarGrabacion()) { return; }

                    if (ConciliacionCobranzas.Count > Variables.Cero)
                    {
                        Int32 TotalReg = ConciliacionCobranzas.Count;
                        Int32 cantReg = TotalReg / 10;
                        Int32 Residuo = TotalReg % 10;
                        DateTime fecInicial = Convert.ToDateTime((from mx in ConciliacionCobranzas
                                                                  select (DateTime?)mx.Fecha).Min());
                        DateTime fecFinal = Convert.ToDateTime((from mx in ConciliacionCobranzas
                                                                select (DateTime?)mx.Fecha).Max());

                        dtpInicial.Value = fecInicial;
                        dtpFinal.Value = fecFinal;
                        AgenteCobranzas.Proxy.EliminarCobranzasConciliacion(ConciliacionCobranzas[0].idPersona, ConciliacionCobranzas[0].idEmpresa, fecInicial, fecFinal, ConciliacionCobranzas[0].codCuenta);

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<CobranzasConciliacionE> oListaTemporal = new List<CobranzasConciliacionE>();

                            if (Residuo == ConciliacionCobranzas.Count)
                            {
                                for (int i = 0; i < Residuo; i++)
                                {
                                    oListaTemporal.Add(ConciliacionCobranzas[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantReg; i++)
                                {
                                    oListaTemporal.Add(ConciliacionCobranzas[i]);
                                }
                            }

                            foreach (CobranzasConciliacionE item in oListaTemporal)
                            {
                                ConciliacionCobranzas.Remove(item);
                            }

                            foreach (CobranzasConciliacionE item in oListaTemporal)
                            {
                                AgenteCobranzas.Proxy.InsertarCobranzasConciliacion(item);
                                Registros++;
                            }

                            oListaTemporal = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ConciliacionCobranzas = null;
                ListaConciliacionPrincipal = null;
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            Cursor = Cursors.Arrow;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            btExaminar.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                btActualizar.Enabled = true;
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (Tipo == "I")
                {
                    if (ConciliacionCobranzas != null)
                    {
                        btProcesar.Enabled = true;
                        btActualizar.Enabled = false;

                        Global.MensajeComunicacion(String.Format("Se importaron {0} registros", ConciliacionCobranzas.Count));
                    }
                    else
                    {
                        btActualizar.Enabled = true;
                        lblProcesando.Text = String.Format("Ha ocurrido un error en la Hoja Excel en la linea {0}. Revise por favor.", LineaError);
                    }
                }
                else if (Tipo == "P")
                {
                    if (Registros > Variables.Cero)
                    {
                        btProcesar.Enabled = false;
                        txtRuta.Text = String.Empty;
                        timer1.Enabled = false;
                        letra = Variables.Cero;
                        bsConciliacion.DataSource = ListaConciliacionPrincipal;
                        bsConciliacion.ResetBindings(false);

                        foreach (CobranzasItemE item in ListaCobranzasPrincipal)
                        {
                            item.indConciliado = false;
                            item.numItemConci = null;
                            item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                        }

                        bsCobranzas.DataSource = ListaCobranzasPrincipal;
                        bsCobranzas.ResetBindings(false);

                        Global.MensajeComunicacion("Los registros se ingresaron correctamente");
                    }
                    else
                    {
                        btProcesar.Enabled = true;
                        txtRuta.Text = String.Empty;
                        timer1.Enabled = false;
                        letra = Variables.Cero;
                    }
                }
            }
        }

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //frmConciliacionBancariaManual oFrm = sender as frmConciliacionBancariaManual;

            //if (oFrm.DialogResult == DialogResult.Cancel)
            //{
            //    Buscar();
            //}
        }

        #endregion

        #region Eventos

        private void frmConciliacionCobranzas_Load(object sender, EventArgs e)
        {
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            Grid = false;
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    ConciliacionCobranzas = new List<CobranzasConciliacionE>();
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btExaminar.Enabled = false;
                    lblProcesando.Visible = true;
                    Cursor = Cursors.WaitCursor;
                    pbProgress.Visible = true;
                    lblProcesando.Text = "Preparando el archivo excel para su importación...";
                    Tipo = "I";

                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeFault("Tiene que buscar un archivo");
                }
            }
            catch (Exception ex)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }

                Global.MensajeError(ex.Message);
            }
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMoneda.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCuentas.SelectedValue != null)
            {
                txtCodCuenta.Text = cboCuentas.SelectedValue.ToString();
                ObtenerCuentaContable(txtCodCuenta.Text.Trim());
            }
            else
            {
                txtCodCuenta.Text = "";
                txtNomCuenta.Text = "";
            }

            Buscar();
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Archivos Excel (.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    btActualizar.Enabled = true;
                }
                else
                {
                    btActualizar.Enabled = false;
                }

                //SinConciliar = true;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            letra += 1;

            if (letra == Marquee.Length)
            {
                lblProcesando.Text = String.Empty;
                letra = 0;
            }
            else
            {
                lblProcesando.Text += Marquee.Substring(letra - 1, 1);
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboBancosEmpresa.SelectedValue) == 0)
                {
                    Global.MensajeAdvertencia("Debe escoger un Banco antes de empezar con la importación");
                    cboBancosEmpresa.Focus();
                    return;
                }

                lblProcesando.Text = String.Empty;
                Marquee = "Ingresando la información a la Base de Datos...";
                Cursor = Cursors.WaitCursor;
                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                btExaminar.Enabled = false;
                timer1.Enabled = true;
                lblProcesando.Visible = true;
                pbProgress.Visible = true;
                Tipo = "P";

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }

                Global.MensajeError(ex.Message);
            }
        }

        private void bsCobranzas_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (ListaCobranzasPrincipal != null)
                {
                    lblRegistros.Text = "Registros " + ListaCobranzasPrincipal.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsConciliacion_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (ListaConciliacionPrincipal != null)
                {
                    lbRegistrosC.Text = "Registros Importados " + ListaConciliacionPrincipal.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            foreach (CobranzasItemE item in ListaCobranzasPrincipal)
            {
                item.indConciliado = false;
                item.numItemConci = null;
                item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsCobranzas.DataSource = ListaCobranzasPrincipal;
            bsCobranzas.ResetBindings(false);

            foreach (CobranzasConciliacionE item in ListaConciliacionPrincipal)
            {
                item.numItemConci = null;
            }

            bsConciliacion.DataSource = ListaConciliacionPrincipal;
            bsConciliacion.ResetBindings(false);
            //SinConciliar = true;
            Numero = 1;
        }

        private void btConciliado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaConciliacionPrincipal == null)
                {
                    ListaConciliacionPrincipal = AgenteCobranzas.Proxy.ListarCobranzasConciliacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpInicial.Value.Date, dtpFinal.Value.Date, txtCodCuenta.Text.Trim());
                }

                if (ListaCobranzasPrincipal.Count > 0 && ListaConciliacionPrincipal.Count > 0)
                {
                    String NumeroV = String.Empty;
                    String NumeroC = String.Empty;
                    Boolean Encontro = true;
                    //Int32 Numero = 1;

                    foreach (CobranzasItemE item in ListaCobranzasPrincipal)
                    {
                        if (!item.indConciliado)
                        {
                            NumeroV = item.numCheque.Trim().PadLeft(10, '0');
                            NumeroV = Global.Derecha(NumeroV, 10);
                            Encontro = false;

                            // Validar Con Numero de Documento 
                            foreach (CobranzasConciliacionE itemConc in ListaConciliacionPrincipal)
                            {
                                if (itemConc.numItemConci == null)
                                {
                                    NumeroC = itemConc.Operacion.Trim().PadLeft(10, '0');
                                    NumeroC = Global.Derecha(NumeroC, 10);

                                    if (itemConc.Fecha.Date == item.fecCobranza.Value.Date && itemConc.Monto == item.Monto && NumeroV == NumeroC)
                                    {
                                        //Conciliación
                                        itemConc.idPlanilla = item.idPlanilla;
                                        itemConc.Recibo = item.Recibo;
                                        itemConc.numItemConci = Numero;

                                        //Cobranzas Item
                                        item.indConciliado = true;
                                        item.numItemConci = Numero;
                                        Encontro = true;

                                        AgenteCobranzas.Proxy.ActualizarCobranzasConciliacion(itemConc);
                                        AgenteCobranzas.Proxy.ActualizarCobranzasItemConciliado(item.idPlanilla, item.Recibo, item.indConciliado);

                                        Numero++;
                                        break;
                                    }
                                }
                            }

                            // Validar Si no Encuentra por Fecha y Monto
                            if (!Encontro)
                            {
                                foreach (CobranzasConciliacionE itemConc in ListaConciliacionPrincipal)
                                {
                                    if (itemConc.numItemConci == null)
                                    {
                                        if (itemConc.Fecha.Date == item.fecCobranza.Value.Date && itemConc.Monto == item.Monto)
                                        {
                                            //Conciliación
                                            itemConc.idPlanilla = item.idPlanilla;
                                            itemConc.Recibo = item.Recibo;
                                            itemConc.numItemConci = Numero;

                                            //Cobranzas Item
                                            item.indConciliado = true;
                                            item.numItemConci = Numero;
                                            Encontro = true;

                                            AgenteCobranzas.Proxy.ActualizarCobranzasConciliacion(itemConc);
                                            AgenteCobranzas.Proxy.ActualizarCobranzasItemConciliado(item.idPlanilla, item.Recibo, item.indConciliado);

                                            Numero++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    bsCobranzas.DataSource = ListaCobranzasPrincipal;
                    bsCobranzas.ResetBindings(false);

                    bsConciliacion.DataSource = ListaConciliacionPrincipal;
                    bsConciliacion.ResetBindings(false);
                    Global.MensajeComunicacion("Proceso terminado...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvImportados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //    if (ListaConciliacionPrincipal != null && ListaConciliacionPrincipal.Count > 0)
            //    {
            //        if (e.Value != null)
            //        {
            //            if (dgvImportados.Columns["numItemConci2"].Name == "numItemConci2")
            //            {
            //                Int32? num = (Int32)dgvImportados.Rows[e.RowIndex].Cells["numItemConci2"].Value;

            //                if (num != null)
            //                {
            //                    e.CellStyle.BackColor = Valores.ColorAnulado;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void dgvCobranzas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCobranzas.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvCobranzas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvCobranzas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvCobranzas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvCobranzas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bsCobranzas.EndEdit();

                if (e.RowIndex != -1 && dgvCobranzas.Columns[e.ColumnIndex].Name == "indConciliado")
                {
                    DataGridViewCell cellConciliado = dgvCobranzas.Rows[e.RowIndex].Cells["indConciliado"];

                    if (cellConciliado != null)
                    {
                        ((CobranzasItemE)bsCobranzas.Current).Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                        ((CobranzasItemE)bsCobranzas.Current).indConciliado = Convert.ToBoolean(cellConciliado.Value);
                    }
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
