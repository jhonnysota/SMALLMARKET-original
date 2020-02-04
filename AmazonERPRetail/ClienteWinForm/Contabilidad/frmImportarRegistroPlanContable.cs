using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Excel

using OfficeOpenXml;
using System.Windows.Forms;
using ClienteWinForm.Contabilidad.Reportes;
using Entidades.Generales;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarRegistroPlanContable : FrmMantenimientoBase
    {

        public frmImportarRegistroPlanContable()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables
        
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<PlanContableXLSE> oListaPrincipal = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty;
        Int32 errores = 0;

        #endregion        

        #region Procedimientos de Usuario
        
        Boolean ImportarExcel(String Ruta)
        {
            int Inicio = 7;
            Int32 FilaError = 0;
            Int32 Columna = 0;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    List<ParTabla> oListaTipoAjuste = AgenteGeneral.Proxy.ListarParTablaPorNemo("AJDIF");
                    List<ParTabla> oListaTipoBalance = AgenteGeneral.Proxy.ListarParTablaPorNemo("BALANCONT");
                    List<ParTabla> oListaTipoCompraVenta = AgenteGeneral.Proxy.ListarParTablaPorNemo("COTIP_COVE");
                    
                    PlanContableXLSE oRegistro = null;
                    oListaPrincipal = new List<PlanContableXLSE>();
                    
                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];

                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.Rows;
                    int ContadorItem = 1;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = Inicio; f <= totFilas; f++)
                    {
                        if (oHoja.Cells[f, 1].Value != null)
                        {
                            if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                            {
                                // FILA
                                oRegistro = new PlanContableXLSE();
                                oRegistro.Linea = FilaError = f;
                                oRegistro.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

                                Columna = 1;
                                if (oHoja.Cells[f, 1].Value != null)
                                {
                                    oRegistro.Cuenta = Convert.ToString(oHoja.Cells[f, 1].Value);
                                }

                                Columna = 2;
                                if (oHoja.Cells[f, 2].Value != null)
                                {
                                    oRegistro.Descripcion = Convert.ToString(oHoja.Cells[f, 2].Value);

                                    if (oRegistro.Descripcion.Length > 200)
                                    {
                                        throw new Exception("El campo Descripcion no debe superar los 200 dígitos.");
                                    }
                                }
                                
                                Columna = 3;
                                if (oHoja.Cells[f, 3].Value != null)
                                {
                                    oRegistro.Nivel = Convert.ToInt32(oHoja.Cells[f, 3].Value);

                                    if (oRegistro.Nivel < 0)
                                    {
                                        throw new Exception("El Campo Num Nivel Solo Maneja Niveles del 1 Al 9");
                                    }
                                    else if(oRegistro.Nivel > 10)
                                    {
                                        throw new Exception("El Campo Num Nivel Solo Maneja Niveles del 1 Al 9");
                                    }
                                }


                                //Monedas
                                Columna = 4;
                                if (oHoja.Cells[f, 4].Value != null)
                                {
                                    oRegistro.Mon = (oHoja.Cells[f, 4].Value).ToString().Trim();

                                    if (!String.IsNullOrWhiteSpace(oRegistro.Mon))
                                    {
                                        MonedasE oMoneda = VariablesLocales.ListaMonedas.Find
                                        (
                                            delegate (MonedasE cc) { return cc.desAbreviatura.Substring(0, 2) == oRegistro.Mon.Substring(0, 2); }
                                        );

                                        if (oMoneda != null)
                                        {
                                            oRegistro.Mon = oMoneda.idMoneda;
                                        }
                                    }
                                }

                                //DEBEHABER
                                Columna = 5;
                                if (oHoja.Cells[f, 5].Value != null)
                                {
                                    oRegistro.DH = (oHoja.Cells[f, 5].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.DH.Length > 1)
                                    {
                                        throw new Exception("El campo DH Solo Se Puede LLenar con D(Debe) y H(Haber)");
                                    }
                                }

                                Columna = 6;
                                if (oHoja.Cells[f, 6].Value != null)
                                {
                                    oRegistro.AjusCambio = (oHoja.Cells[f, 6].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.AjusCambio.Length != 1 )
                                    {
                                        throw new Exception("El campo Ajuste Cambio solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                Columna = 7;
                                if (oHoja.Cells[f, 7].Value != null)
                                {

                                    if (!String.IsNullOrWhiteSpace((oHoja.Cells[f, 7].Value).ToString().Trim()))
                                    {
                                        ParTabla oAjuste = oListaTipoAjuste.Find
                                        (
                                            delegate (ParTabla cc) { return cc.Nombre == (oHoja.Cells[f, 7].Value).ToString().Trim(); }
                                        );

                                        if (oAjuste != null)
                                        {
                                            oRegistro.TipoAjus = oAjuste.IdParTabla;
                                        }
                                    }
                                    else
                                    {
                                        oRegistro.TipoAjus = 0;
                                    }
                                }

                                Columna = 8;
                                if (oHoja.Cells[f, 8].Value != null)
                                {
                                    oRegistro.CtaGanan = (oHoja.Cells[f, 8].Value).ToString().Trim();

                                    if (oRegistro.CtaGanan.Length > 20)
                                    {
                                        throw new Exception("El campo Cuenta Ganancia no debe exceder los 20 digitos.");
                                    }
                                }

                                Columna = 9;
                                if (oHoja.Cells[f, 9].Value != null)
                                {
                                    oRegistro.CtaPerd = (oHoja.Cells[f, 9].Value).ToString().Trim();

                                    if (oRegistro.CtaPerd.Length > 20)
                                    {
                                        throw new Exception("El campo Cuenta Perdida no debe exceder los 20 digitos.");
                                    }
                                }

                                Columna = 10;
                                if (oHoja.Cells[f, 10].Value != null)
                                {
                                    oRegistro.CambioCom = (oHoja.Cells[f, 10].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.CambioCom == "NO" || oRegistro.CambioCom == "nO" || oRegistro.CambioCom == "no" || oRegistro.CambioCom == "No")
                                    {
                                        oRegistro.CambioCom = "A";
                                    }

                                    if ( oRegistro.CambioCom.Length != 1)
                                    {
                                        throw new Exception("El campo Cambio Compra solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                Columna = 11;
                                if (oHoja.Cells[f, 11].Value != null)
                                {
                                    oRegistro.IndGasto = (oHoja.Cells[f, 11].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.IndGasto.Length != 1)
                                    {
                                        throw new Exception("El campo Indica Gastos solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                Columna = 12;
                                if (oHoja.Cells[f, 12].Value != null)
                                {
                                    oRegistro.CtaDest = (oHoja.Cells[f, 12].Value).ToString().Trim();

                                    if (oRegistro.CtaDest.Length > 20)
                                    {
                                        throw new Exception("El campo Cta.Destino no debe exceder los 20 dígitos.");
                                    }
                                }
                                else
                                {
                                    oRegistro.CtaDest = "";
                                }

                                Columna = 13;
                                if (oHoja.Cells[f, 13].Value != null)
                                {
                                    oRegistro.CtaTransf = (oHoja.Cells[f, 13].Value).ToString().Trim();

                                    if (oRegistro.CtaTransf.Length > 20)
                                    {
                                        throw new Exception("El campo Cta.Transferencia no debe exceder los 20 dígitos.");
                                    }
                                }
                                else
                                {
                                    oRegistro.CtaTransf = "";
                                }

                                Columna = 14;
                                if (oHoja.Cells[f, 14].Value != null)
                                {
                                    oRegistro.IndCierre = oHoja.Cells[f, 14].Value.ToString().Trim().Substring(0,1);

                                    if (oRegistro.IndCierre.Length != 1)
                                    {
                                            throw new Exception("El campo Indica Cierre solo Permite La Respuesta SI ó NO.");     
                                      
                                    }
                                }

                                Columna = 15;
                                if (oHoja.Cells[f, 15].Value != null)
                                {
                                    oRegistro.CtaCierre = Convert.ToString(oHoja.Cells[f, 15].Value);

                                    if (oRegistro.CtaCierre.Length > 20)
                                    {
                                        throw new Exception("El campo Cta.Cierre no debe exceder los 20 dígitos.");
                                    }
                                }

                                Columna = 16;
                                if (oHoja.Cells[f, 16].Value != null)
                                {
                                    oRegistro.CtaCte = (oHoja.Cells[f, 16].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.CtaCte.Length != 1)
                                    {
                                        throw new Exception("El campo Indica Cierre solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                Columna = 17;
                                if (oHoja.Cells[f, 17].Value != null)
                                {
                                    oRegistro.ConAux = (oHoja.Cells[f, 17].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.ConAux.Length != 1)
                                    {
                                        throw new Exception("El campo Indica Cierre solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                Columna = 18;
                                if (oHoja.Cells[f, 18].Value != null)
                                {
                                    oRegistro.ConDoc = (oHoja.Cells[f, 18].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.ConDoc.Length != 1)
                                    {
                                        throw new Exception("El campo ConDocumento no debe exceder los 2 dígitos.");
                                    }
                                }

                                Columna = 19;
                                if (oHoja.Cells[f, 19].Value != null)
                                {
                                    oRegistro.ConCC = (oHoja.Cells[f, 19].Value).ToString().Trim().Substring(0,1);

                                    if (oRegistro.ConCC.Length != 1)
                                    {
                                        throw new Exception("El campo Indica Centro De Costos solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                Columna = 20;
                                if (oHoja.Cells[f, 20].Value != null)
                                {
                                    if (!String.IsNullOrWhiteSpace((oHoja.Cells[f, 20].Value).ToString().Trim()))
                                    {
                                        ParTabla oBalance = oListaTipoBalance.Find
                                        (
                                            delegate (ParTabla cc) { return cc.Nombre == (oHoja.Cells[f, 20].Value).ToString().Trim(); }
                                        );

                                        if (oBalance != null)
                                        {
                                            oRegistro.Balance = oBalance.IdParTabla;
                                        }
                                    }
                                    else
                                    {
                                        oRegistro.Balance = 0;
                                    }
                                }

                                Columna = 21;
                                if (oHoja.Cells[f, 21].Value != null)
                                {
                                    if (!String.IsNullOrWhiteSpace((oHoja.Cells[f, 21].Value).ToString().Trim()))
                                    {
                                        ParTabla oColCV = oListaTipoCompraVenta.Find
                                        (
                                            delegate (ParTabla cc) { return cc.Nombre == (oHoja.Cells[f, 21].Value).ToString().Trim(); }
                                        );

                                        if (oColCV != null)
                                        {
                                            oRegistro.ColCV = oColCV.IdParTabla;
                                        }
                                    }
                                    else
                                    {
                                        oRegistro.ColCV = 0;
                                    }
                                }

                                Columna = 22;
                                if (oHoja.Cells[f, 22].Value != null)
                                {
                                    oRegistro.UltNodo = (oHoja.Cells[f, 22].Value).ToString().Trim().Substring(0,1);
                                    if (oRegistro.UltNodo.Length != 1)
                                    {
                                        throw new Exception("El campo Indica Ultimo Nodo solo Permite La Respuesta SI ó NO.");
                                    }
                                }

                                oListaPrincipal.Add(oRegistro);
                                ContadorItem++;
                            }
                        }
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", FilaError.ToString(), Columna.ToString(), ex.Message));
            }
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
                if (TipoProceso == "P")
                {
                    #region Procesando la Información

                    errores = 0;
                    Int32 TotalReg = Variables.Cero; //Total registros en la lista Principal
                    Int32 TotalTemp = Variables.Cero; //Total registros para poder ir descontando cuantos van quedandos
                    Int32 cantReg = Variables.Cero; //Para saber cuantos registros se van a ir quitando
                    Int32 Residuo = Variables.Cero; //Para saber si sobra registros en caso el total sea impar

                    //Lista Temporal para borrar y traer los errores si los hubiere...
                    var ListaTemporal = oListaPrincipal.GroupBy(x => new { x.idEmpresa }).Select(g => g.First()).ToList();
                    //Borrando VoucherXLS por Local
                    AgenteContabilidad.Proxy.EliminarPlanContableXLS(ListaTemporal.ToList());

                    //Empezando el ingreso a VoucherXLS
                    if (oListaPrincipal.Count < 1000)
                    {
                        AgenteContabilidad.Proxy.InsertarPlanContableXLS(oListaPrincipal);
                    }
                    else
                    {
                        List<PlanContableXLSE> oListaExcel = new List<PlanContableXLSE>(oListaPrincipal);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<PlanContableXLSE> oListaTemporal = new List<PlanContableXLSE>();

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

                            foreach (PlanContableXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteContabilidad.Proxy.InsertarPlanContableXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Obteniendo los errores si los hubiere...
                    errores = AgenteContabilidad.Proxy.ErroresPlanContableXLS(ListaTemporal.ToList());

                    if (errores > 0)
                    {
                        throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                    } 

                    #endregion
                }
                else if(TipoProceso == "E")
                {
                    #region Importando desde Excel

                    ImportarExcel(RutaGeneral); 

                    #endregion
                }
                else if (TipoProceso == "I")
                {
                    Int32 Reg = AgenteContabilidad.Proxy.IntegrarPlanCuentasXLS(oListaPrincipal, VariablesLocales.SesionUsuario.Credencial,VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
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
                Infraestructura.Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));

                if (errores > 0)
                {
                    btErrores.Enabled = true;
                }

                btProcesar.Enabled = false;
                btIntegrar.Enabled = false;
            }
            else if (e.Cancelled == true)
            {
                Infraestructura.Global.MensajeComunicacion("La operación ha sido cancelada.");
            }

            else
            {
                if (TipoProceso == "P")
                {
                    btProcesar.Enabled = true;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = true;

                    Infraestructura.Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                }
                else if(TipoProceso == "E")
                {
                    btProcesar.Enabled = oListaPrincipal.Count > 0;
                    Infraestructura.Global.MensajeComunicacion("Se ha importado la hoja excel correctamente...");
                }
                else
                {
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    Infraestructura.Global.MensajeComunicacion("Se han ingresado El Plan Contable correctamente...");
                }
            }
        }

        #endregion

        #region Eventos

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {                
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Todos los Archivos Excel |*.xlsx;*.xls");
            }
            catch (Exception ex)
            {
                btExaminar.Enabled = true;
                TipoProceso = String.Empty;
                lblProcesando.Visible = false;
                timer1.Enabled = false;
                Cursor = System.Windows.Forms.Cursors.Arrow;
                Marquee = String.Empty;
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }
        
        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Infraestructura.Global.MensajeFault("Tiene que seleccionar el archivo de Registro");
                    return;
                }

                RutaGeneral = txtRuta.Text.Trim();

                if (File.Exists(RutaGeneral))
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }

                    TipoProceso = "E";
                    btExaminar.Enabled = false;
                    btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;

                    lblProcesando.Visible = true;
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    Marquee = "Cargando Hoja Excel...";
                    pbProgress.Visible = true;
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Infraestructura.Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaGeneral));
                }
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
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
                Infraestructura.Global.MensajeError(ex.Message);
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
        }

        private void btIntegrar_Click(object sender, EventArgs e)
        {
            try
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
                Marquee = "Insertando El Plan Contable...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
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
                Form oFrm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmErrores);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmErrores("PLANCONTABLE");
                oFrm.MdiParent = MdiParent;
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

        #endregion

    }
}
