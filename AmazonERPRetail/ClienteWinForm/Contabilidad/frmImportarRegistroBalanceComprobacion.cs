using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;

#region Para Excel

using OfficeOpenXml;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarRegistroBalanceComprobacion : FrmMantenimientoBase
    {

        public frmImportarRegistroBalanceComprobacion()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables
        
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<BalanceComprobacionXLSE> oListaPrincipal = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty;
        Int32 errores = 0;
        //Int32 Registros = 0;

        List<CuentasEquivalentes> ListaEquivalencias = null;

        #endregion        

        #region Procedimientos de Usuario
        
        String ImportarExcel(String Ruta)
        {
            int Inicio = 1;
            Int32 FilaError = 0;
            Int32 Columna = 0;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    BalanceComprobacionXLSE oRegistro = null;
                    oListaPrincipal = new List<BalanceComprobacionXLSE>();
                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.Rows;
                    //Para la cadena de devuelta
                    StringBuilder Cadena = new StringBuilder();
                    ////Fecha para que ayude hacer el asiento contable
                    //DateTime? Fecha = null;

                    //if (oHoja.Cells[Inicio, 5].Value != null)
                    //{
                    //    if (String.IsNullOrWhiteSpace(oHoja.Cells[Inicio, 5].Value.ToString()))
                    //    {
                    //        Global.MensajeAdvertencia("No se ha colocado el nombre del mes en la Fila 1 Columna 5");
                    //        return "Mes";
                    //    }
                    //    else
                    //    {
                    //        String NombreMes = oHoja.Cells[Inicio, 5].Value.ToString();
                    //        String NumeroMes = FechasHelper.NumeroMes(NombreMes);

                    //        if (String.IsNullOrWhiteSpace(NumeroMes))
                    //        {
                    //            Global.MensajeAdvertencia(String.Format("El nombre del mes {0} no existe", NombreMes));
                    //        }
                    //        else
                    //        {
                    //            String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
                    //            Fecha = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + NumeroMes + "/" + Anio));
                    //        }
                    //    }
                    //}

                    //Aumentando para la lectura
                    Inicio += 2;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = Inicio; f <= totFilas; f++)
                    {
                        if (oHoja.Cells[f, 1].Value != null && oHoja.Cells[f, 5].Value != null)
                        {
                            Decimal.TryParse(oHoja.Cells[f, 5].Value.ToString(), out Decimal MontoCol5);

                            if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0 && MontoCol5 != 0)
                            {
                                //Fila
                                oRegistro = new BalanceComprobacionXLSE
                                {
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                    idUsuario = VariablesLocales.SesionUsuario.IdPersona,
                                    Linea = FilaError = f
                                };

                                Columna = 1;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    oRegistro.NumeroCuenta = Convert.ToString(oHoja.Cells[f, Columna].Value).Trim();
                                }

                                Columna = 2;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    oRegistro.DescripcionBalance = Convert.ToString(oHoja.Cells[f, Columna].Value).Trim();
                                }

                                Columna = 3;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    oRegistro.TotalInforme = Convert.ToDecimal(oHoja.Cells[f, Columna].Value);
                                }

                                Columna = 4;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    oRegistro.TotalComparacion = Convert.ToDecimal(oHoja.Cells[f, Columna].Value);
                                }

                                Columna = 5;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    oRegistro.DesviacionAbsoluta = Convert.ToDecimal(oHoja.Cells[f, Columna].Value);
                                }

                                if (chkCuentaEquivalente.Checked)
                                {
                                    oRegistro.CtaIndusoft = BuscarCuentaEquivalente(oRegistro.NumeroCuenta);

                                    if (String.IsNullOrWhiteSpace(oRegistro.CtaIndusoft))
                                    {
                                        Cadena.Append(oRegistro.NumeroCuenta).Append("\n\r");
                                    }
                                }
                                else
                                {
                                    oRegistro.CtaIndusoft = oRegistro.NumeroCuenta;
                                }

                                oListaPrincipal.Add(oRegistro);
                            }
                        }
                    }
                    
                    return Cadena.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en el Excel del Balance en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Columna.ToString(), ex.Message));
            }
        }

        List<CuentasEquivalentes> ImportarCuentas(String Ruta)
        {
            Int32 FilaError = 0;
            Int32 Columna = 0;

            try
            {
                int Inicio = 2;
                FileInfo oFi_ = new FileInfo(Ruta);
                List<CuentasEquivalentes> ListaCuentas = new List<CuentasEquivalentes>();

                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad nueva
                    CuentasEquivalentes RegistroNuevo = null;
                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.Rows;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = Inicio; f <= totFilas; f++)
                    {
                        if (oHoja.Cells[f, 2].Value != null && oHoja.Cells[f, 5].Value != null)
                        {
                            if ((oHoja.Cells[f, 2].Value).ToString().Trim().Length > 0 && (oHoja.Cells[f, 5].Value).ToString().Trim().Length > 0)
                            {
                                //Inicializando la entidad
                                RegistroNuevo = new CuentasEquivalentes();

                                Columna = 1;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    RegistroNuevo.Item = Convert.ToInt32(oHoja.Cells[f, Columna].Value);
                                }

                                Columna = 2;
                                RegistroNuevo.CtaEmpresa = Convert.ToString(oHoja.Cells[f, Columna].Value).Trim();

                                Columna = 3;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    RegistroNuevo.desCtEempresa = Convert.ToString(oHoja.Cells[f, Columna].Value).Trim();
                                }

                                Columna = 5;
                                RegistroNuevo.CtaIndusoft = Convert.ToString(oHoja.Cells[f, Columna].Value).Trim();

                                Columna = 6;
                                if (oHoja.Cells[f, Columna].Value != null)
                                {
                                    RegistroNuevo.desCtaIndusoft = Convert.ToString(oHoja.Cells[f, Columna].Value).Trim();
                                }

                                ListaCuentas.Add(RegistroNuevo);
                            }
                        }
                    }
                }

                return ListaCuentas;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en el Excel de Cuentas Equivalentes la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Columna.ToString(), ex.Message));
            }
        }

        String BuscarCuentaEquivalente(String CuentaSearch)
        {
            String Cuenta = String.Empty;

            CuentasEquivalentes oCuentaEqui = ListaEquivalencias.Find
            (
                delegate (CuentasEquivalentes ce) { return ce.CtaEmpresa == CuentaSearch; }
            );

            if (oCuentaEqui != null)
            {
                Cuenta = oCuentaEqui.CtaIndusoft;
            }

            return Cuenta;
        }

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Int32 Minimo = 0; //Para saber la linea mínima
            Int32 Maximo = 0; //Para saber la linea máxima
            String MensajeErr = String.Empty;

            try
            {
                if (TipoProceso == "P") //Procesar
                {
                    #region Procesando la Información

                    errores = 0;
                    Int32 TotalReg = Variables.Cero; //Total registros en la lista Principal
                    Int32 TotalTemp = Variables.Cero; //Total registros para poder ir descontando cuantos van quedandos
                    Int32 cantReg = Variables.Cero; //Para saber cuantos registros se van a ir quitando
                    Int32 Residuo = Variables.Cero; //Para saber si sobra registros en caso el total sea impar

                    //Borrando los registros de con_BalanceComprobacionXLS por idEmpresa e idUsuario
                    AgenteContabilidad.Proxy.EliminarBalanceComprobacionXLS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.IdPersona);

                    //Empezando el ingreso a con_BalanceComprobacionXLS
                    if (oListaPrincipal.Count < 1000)
                    {
                        AgenteContabilidad.Proxy.InsertarBalanceComprobacionXLS(oListaPrincipal);
                    }
                    else
                    {
                        List<BalanceComprobacionXLSE> oListaExcel = new List<BalanceComprobacionXLSE>(oListaPrincipal);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<BalanceComprobacionXLSE> oListaTemporal = new List<BalanceComprobacionXLSE>();

                            if (Residuo == oListaExcel.Count)
                            {
                                for (int i = 0; i < Residuo; i++)
                                {
                                    oListaTemporal.Add(oListaExcel[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantReg; i++)
                                {
                                    oListaTemporal.Add(oListaExcel[i]);
                                }
                            }

                            foreach (BalanceComprobacionXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteContabilidad.Proxy.InsertarBalanceComprobacionXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Procesando para ver si existen inconsistencias
                    errores = AgenteContabilidad.Proxy.ProcesarBalanceXLS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0, VariablesLocales.SesionUsuario.IdPersona, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);

                    if (errores > 0)
                    {
                        throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                    } 

                    #endregion
                }
                else if (TipoProceso == "I") //Integrar
                {
                    Int32 Reg = AgenteContabilidad.Proxy.IntegrarBalanceComprobacionXLS(oListaPrincipal, VariablesLocales.SesionLocal.IdLocal, dtpFecha.Value.Date, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), VariablesLocales.SesionUsuario.Credencial);
                }

                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                //e.Result = "ok"; 1 - Otro manera de manejar el error... Pasarle ok si todo esta OK
            }
            catch (Exception ex)
            {
                //e.Result = ex.Message; 2 - Asignarle el mensaje de error... Pasarle al result el mensaje de error...
                throw new Exception(MensajeErr + ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btExaminar.Enabled = true;
            btActualizar.Enabled = true;
            btCancelar.Enabled = false;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            lblRegistros.Visible = false;
            lblRegistros.Text = String.Empty;
            Marquee = String.Empty;
            letra = 0;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                if (errores > 0)
                {
                    btErrores.Enabled = true;
                }

                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
            }
            else if (e.Cancelled)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (TipoProceso == "P")
                {
                    btProcesar.Enabled = true;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = true;

                    Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                }
                else
                {
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    Global.MensajeComunicacion("Se ha ingresado el voucher correctamente...");
                }
            }
        }

        #endregion

        #region Eventos

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {                
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }
        
        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkCuentaEquivalente.Checked)
                {
                    if (String.IsNullOrWhiteSpace(txtRutaCuentas.Text))
                    {
                        Global.MensajeFault("Tiene que seleccionar el archivo para las cuentas equivalentes");
                        return;
                    }

                    ListaEquivalencias = ImportarCuentas(txtRutaCuentas.Text.Trim());

                    if (ListaEquivalencias.Count == 0)
                    {
                        Global.MensajeFault("No hay ninguna cuenta equivalente, revise por favor....");
                        return;
                    }
                }
                else
                {
                    ListaEquivalencias = null;
                }

                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Tiene que seleccionar el archivo de Registro");
                    return;
                }

                RutaGeneral = txtRuta.Text.Trim();

                if (File.Exists(RutaGeneral))
                {
                    String Mensaje = ImportarExcel(RutaGeneral);

                    if (String.IsNullOrWhiteSpace(Mensaje))
                    {
                        if (Mensaje != "Mes")
                        {
                            btProcesar.Enabled = oListaPrincipal.Count > 0;
                            Global.MensajeComunicacion("Se ha importado la hoja excel correctamente..."); 
                        }
                    }
                    else
                    {
                        Global.MensajeAdvertencia("Las cuentas no tienen equivalencia:\n\r" + Mensaje);
                    }
                }
                else
                {
                    Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaGeneral));
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                }

                if (oListaPrincipal != null && oListaPrincipal.Count > Variables.Cero)
                {
                    TipoProceso = "P";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    
                    lblProcesando.Visible = true;
                    lblRegistros.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Procesando Información...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Infraestructura.Global.MensajeFault("La lista de registros se encuentra vacia aún...");
                }
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

        private void frmImportarRegistroVoucher_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;

            String RutaCuentas = @"C:\AmazonErp\Plantillas\Cuentas Equivalentes";

            //Revisar si el directorio existe
            if (!Directory.Exists(RutaCuentas))
            {
                Directory.CreateDirectory(RutaCuentas);
            }

            //Agregando el nombre del archivo
            RutaCuentas += @"\Equivalencia.xlsx";

            //Revisando si existe el archivo
            if (File.Exists(RutaCuentas))
            {
                txtRutaCuentas.Text = RutaCuentas;
            }
        }

        private void btIntegrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.MensajeConfirmacion(String.Format("Se va a generar el Asiento Contable con fecha {0}, desea continuar?", dtpFecha.Value.ToString("dd/MM/yyyy"))) == DialogResult.Yes)
                {
                    TipoProceso = "I";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btIntegrar.Enabled = false;
                    lblProcesando.Visible = true;
                    lblRegistros.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Generando el Voucher Contable...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync(); 
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeFault(ex.Message);
            }
        }

        private void btErrores_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmErrores);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmErrores("Balance")
                {
                    MdiParent = MdiParent
                };

                oFrm.Show();
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _bw.CancelAsync();
        }

        private void chkCuentaEquivalente_CheckedChanged(object sender, EventArgs e)
        {
            btBuscarEquivalente.Enabled = chkCuentaEquivalente.Checked;
        }

        private void btBuscarEquivalente_Click(object sender, EventArgs e)
        {
            try
            {
                String RutaActual = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx");
                String RutaDestino = @"C:\AmazonErp\Plantillas\Cuentas Equivalentes\Equivalencia.xlsx";
                File.Copy(RutaActual, RutaDestino, true);
                txtRutaCuentas.Text = RutaDestino;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }

    class CuentasEquivalentes
    {
        public Int32 Item { get; set; }
        public String CtaEmpresa { get; set; }
        public String desCtEempresa { get; set; }
        public String CtaIndusoft { get; set; }
        public String desCtaIndusoft { get; set; }
    }

}
