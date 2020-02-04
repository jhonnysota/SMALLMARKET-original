using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;

#region Para Excel

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
//using Microsoft.Office.Interop.Excel;

#endregion

namespace ClienteWinForm.Maestros
{
    public partial class frmImportarRegistroVentasCompras : FrmMantenimientoBase
    {
        public frmImportarRegistroVentasCompras()
        {
            InitializeComponent();
        }

        #region Variables
        
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<ImportacionComprasXLSE> oLista = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String RutaVariosArchivos = String.Empty;
        String TipoProceso = String.Empty;
        Int32 errores = 0;
        #endregion        

        #region Procedimientos de Usuario
        
        Boolean ImportarExcel(String Ruta)
        {
            int FilaInicial = 10;
            Int32 FilaError = 0;
            //Int32 Columna = 0;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    ImportacionComprasXLSE oRegistro = null;
                    oLista = new List<ImportacionComprasXLSE>();

                    
                    int NumHoja = 1;
                    
                    //Excel
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[NumHoja];

                    //Para el recorrido del excel
                    Int32 totFilas = oHoja.Dimension.End.Row;
                  
                    //Infraestructura.Global.MensajeComunicacion(totFilas.ToString());
                    int ContadorItem = 1;

                    //Recorriendo la hoja excel hasta el total de fila obtenido...
                    for (int f = FilaInicial; f <= totFilas; f++)
                    {
                        
                        if (oHoja.Cells[f, 1].Value != null)
                        {
                            
                            if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                            {
                            
                                // FILA
                                oRegistro = new ImportacionComprasXLSE();
                                oRegistro.Linea = FilaError = f;
                                oRegistro.idEmpresa = Convert.ToInt32((oHoja.Cells[2, 1].Value));
                                oRegistro.idLocal = Convert.ToInt32((oHoja.Cells[5, 1].Value));               


                                if (oHoja.Cells[f, 1].Value != null)
                                {
                                    oRegistro.Diario = (oHoja.Cells[f, 1].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.Diario = null;
                                }


                                if (oHoja.Cells[f, 2].Value != null)
                                {
                                    oRegistro.numFile = (oHoja.Cells[f, 2].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.numFile = null;
                                }


                                if (oHoja.Cells[f, 3].Value != null)
                                {
                                    oRegistro.numCorrelativo = (oHoja.Cells[f, 3].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.numCorrelativo = null;
                                }

                                if (oHoja.Cells[f, 4].Value != null)
                                {
                                    oRegistro.fecOperacion = Convert.ToDateTime((oHoja.Cells[f, 4].Value));
                                }
                                else
                                {
                                    oRegistro.fecOperacion = null;
                                }


                                if (oHoja.Cells[f, 5].Value != null)
                                {
                                    oRegistro.fecEmision = Convert.ToDateTime(oHoja.Cells[f, 5].Value);
                                }
                                else
                                {
                                    oRegistro.fecEmision = null;
                                }


                                if (oHoja.Cells[f, 6].Value != null)
                                {
                                    oRegistro.fecVencimiento = Convert.ToDateTime(oHoja.Cells[f, 6].Value);
                                }
                                else
                                {
                                    oRegistro.fecVencimiento = null;
                                }


                                if (oHoja.Cells[f, 7].Value != null)
                                {
                                    oRegistro.idTipo = (oHoja.Cells[f, 7].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.idTipo = null;
                                }


                                if (oHoja.Cells[f, 8].Value != null)
                                {
                                    oRegistro.SerieDocumento = (oHoja.Cells[f, 8].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.SerieDocumento = null;
                                }


                                if (oHoja.Cells[f, 9].Value != null)
                                {
                                    oRegistro.NumeroDocumento = (oHoja.Cells[f, 9].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.NumeroDocumento = null;
                                }


                                if (oHoja.Cells[f, 10].Value != null)
                                {
                                    oRegistro.TipoDocIdentidad = (oHoja.Cells[f, 10].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.TipoDocIdentidad = null;
                                }


                                if (oHoja.Cells[f, 11].Value != null)
                                {
                                    oRegistro.NumeroDocIdentidad = (oHoja.Cells[f, 11].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.NumeroDocIdentidad = null;
                                }


                                if (oHoja.Cells[f, 12].Value != null)
                                {
                                    oRegistro.RazonSocial = (oHoja.Cells[f, 12].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.RazonSocial = null;
                                }

                                if (oHoja.Cells[f, 13].Value != null)
                                {
                                    oRegistro.Glosa = (oHoja.Cells[f, 13].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.Glosa = null;
                                }
               

                                if (oHoja.Cells[f, 14].Value != null)
                                {
                                    oRegistro.Moneda = (oHoja.Cells[f, 14].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.Moneda = null;
                                }

                                oRegistro.BaseImponibleExportacion = Convert.ToDecimal(oHoja.Cells[f, 15].Value);
                                oRegistro.BaseImponibleGravada = Convert.ToDecimal(oHoja.Cells[f, 16].Value);
                                oRegistro.ImporteTotalExonerada = Convert.ToDecimal(oHoja.Cells[f, 17].Value);
                                oRegistro.ImporteTotalInafecto = Convert.ToDecimal(oHoja.Cells[f, 18].Value);
                                oRegistro.ISC = Convert.ToDecimal(oHoja.Cells[f, 19].Value);
                                oRegistro.IGV = Convert.ToDecimal(oHoja.Cells[f, 20].Value);
                                oRegistro.OtrosCargos = Convert.ToDecimal(oHoja.Cells[f, 21].Value);
                                oRegistro.ImporteTotal = Convert.ToDecimal(oHoja.Cells[f, 22].Value);
                                oRegistro.TipoCambio = Convert.ToDecimal(oHoja.Cells[f, 23].Value);
                                if (oHoja.Cells[f, 24].Value != null && oHoja.Cells[f, 24].Value.ToString() != "" && oHoja.Cells[f, 24].Value.ToString() != " ")
                                {
                                    oRegistro.FechaRef = Convert.ToDateTime(oHoja.Cells[f, 24].Value);
                                }
                                else
                                {
                                    oRegistro.FechaRef = null;
                                }

                                if (oHoja.Cells[f, 25].Value != null && oHoja.Cells[f, 25].Value.ToString() != "" && oHoja.Cells[f, 25].Value.ToString() != " ")
                                {
                                    oRegistro.idDocumentoRef = (oHoja.Cells[f, 25].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.idDocumentoRef = null;
                                }

                                if (oHoja.Cells[f, 26].Value != null && oHoja.Cells[f, 26].Value.ToString() != "" && oHoja.Cells[f, 26].Value.ToString() != " ")
                                {
                                    oRegistro.serDocumentoRef = (oHoja.Cells[f, 26].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.serDocumentoRef = null;
                                }

                                if (oHoja.Cells[f, 27].Value != null && oHoja.Cells[f, 27].Value.ToString() != "" && oHoja.Cells[f, 27].Value.ToString() != " ")
                                {
                                    oRegistro.numDocumentoRef = (oHoja.Cells[f, 27].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.numDocumentoRef = null;
                                }

                                oRegistro.porIgv = Convert.ToDecimal(oHoja.Cells[f, 28].Value);
                  

                                if (oHoja.Cells[f, 29].Value != null)
                                {
                                    oRegistro.VTA = (oHoja.Cells[f, 29].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.VTA = null;
                                }

                                oRegistro.visaEgresos = Convert.ToDecimal(oHoja.Cells[f, 30].Value);
                                oRegistro.masterEgresos = Convert.ToDecimal(oHoja.Cells[f, 31].Value);
                                oRegistro.dinnersEgresos = Convert.ToDecimal(oHoja.Cells[f, 32].Value);
                                oRegistro.americaEgresos = Convert.ToDecimal(oHoja.Cells[f, 33].Value);
                                oRegistro.efectivoEgresos = Convert.ToDecimal(oHoja.Cells[f, 34].Value);
                                oRegistro.ncEgresos = Convert.ToDecimal(oHoja.Cells[f, 35].Value);


                                if (oHoja.Cells[f, 36].Value != null)
                                {
                                    oRegistro.DiarioEgresos = (oHoja.Cells[f, 36].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.DiarioEgresos = null;
                                }
                                if (oHoja.Cells[f, 37].Value != null)
                                {
                                    oRegistro.numFileEgresos = (oHoja.Cells[f, 37].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.numFileEgresos = null;
                                }

                      
                                if (oHoja.Cells[f, 38].Value != null)
                                {
                                    oRegistro.FechaEgresos = Convert.ToDateTime(oHoja.Cells[f, 38].Value);
                                }



                                if (oHoja.Cells[f, 39].Value != null)
                                {

                                    oRegistro.CuentaEgresos = (oHoja.Cells[f, 39].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.CuentaEgresos = null;
                                }


                                if (oHoja.Cells[f, 40].Value != null)
                                {
                                    oRegistro.CentroCostos = (oHoja.Cells[f, 40].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.CentroCostos = null;
                                }

       

                                if (oHoja.Cells[f, 41].Value != null)
                                {
                                    oRegistro.Cuenta1 = (oHoja.Cells[f, 41].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.Cuenta1 = null;
                                }

                                if (oHoja.Cells[f, 42].Value != null)
                                {
                                    oRegistro.Cuenta2 = (oHoja.Cells[f, 42].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.Cuenta2 = null;
                                }

                                if (oHoja.Cells[f, 43].Value != null)
                                {
                                    oRegistro.Cuenta3 = (oHoja.Cells[f, 43].Value).ToString().Trim();
                                }
                                else
                                {
                                    oRegistro.Cuenta3 = null;
                                }
                                oRegistro.FechaModificacion = VariablesLocales.FechaHoy;
                                oRegistro.FechaRegistro = VariablesLocales.FechaHoy;
                                oRegistro.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                oRegistro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;


                                oLista.Add(oRegistro);
                                ContadorItem++;
                                
                            }
                        }

                    }

                    //System.Data.DataTable oDt = Colecciones.ToDataTable<RegistroCompraNovaE>(oLista);

                    dgvListado.DataSource = oLista;


                    // ==========================
                    // END FOR 
                    // ==========================

                   
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Linea archivo : " +FilaInicial.ToString()+" - " + ex.Message);
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
                    var ListaTemporal = oLista.GroupBy(x => new { x.idEmpresa }).Select(g => g.First()).ToList();
                    //Borrando VoucherXLS por Local
                    //AgenteVentas.Proxy.EliminarPresupuestoDeVentasXLS(ListaTemporal.ToList());

                    //Empezando el ingreso a VoucherXLS
                    if (oLista.Count < 1000)
                    {
                        AgenteMaestros.Proxy.InsertarComprasXLS(oLista);
                    }
                    else
                    {
                        List<ImportacionComprasXLSE> oListaExcel = new List<ImportacionComprasXLSE>(oLista);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<ImportacionComprasXLSE> oListaTemporal = new List<ImportacionComprasXLSE>();

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

                            foreach (ImportacionComprasXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteMaestros.Proxy.InsertarComprasXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Obteniendo los errores si los hubiere...
                    //errores = AgenteMaestros.Proxy.ErroresArticuloServXLSE(ListaTemporal.ToList());

                    if (errores > 0)
                    {
                        throw new Exception(String.Format("El proceso tiene {0} errores. Revise el reporte de Errores.", errores.ToString()));
                    }

                    #endregion
                }
                else if (TipoProceso == "E")
                {
                    #region Importando desde Excel

                    ImportarExcel(RutaGeneral);

                    #endregion
                }
                else if (TipoProceso == "I")
                {
                    Int32 Reg = AgenteMaestros.Proxy.IntegrarImportacionCompras(oLista, VariablesLocales.SesionUsuario.Credencial);
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
                    bterrores.Enabled = true;
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
                    bterrores.Enabled = false;
                    btIntegrar.Enabled = true;

                    Infraestructura.Global.MensajeComunicacion("El proceso ha concluido correctamente...");
                }
                else if (TipoProceso == "E")
                {
                    btProcesar.Enabled = oLista.Count > 0;
                    Infraestructura.Global.MensajeComunicacion("Se ha importado la hoja excel correctamente...");
                }
                else
                {
                    btProcesar.Enabled = false;
                    bterrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    Infraestructura.Global.MensajeComunicacion("Se han ingresado El Presupuesto De Venta correctamente...");
                }
            }

        } 

        #endregion

        #region Eventos

        private void frmImportarVentasDiarias_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;

        }

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
                    //btCancelar.Enabled = true;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    bterrores.Enabled = false;
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

                if (oLista != null && oLista.Count > Variables.Cero)
                {
                    TipoProceso = "P";
                    btExaminar.Enabled = false;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    bterrores.Enabled = false;
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

        #endregion

        private void button1_Click(object sender, EventArgs e)
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

                oFrm = new frmErrores("ARTICULOS");
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Infraestructura.Global.MensajeError(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TipoProceso = "I";
                btExaminar.Enabled = false;
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
    }
}
