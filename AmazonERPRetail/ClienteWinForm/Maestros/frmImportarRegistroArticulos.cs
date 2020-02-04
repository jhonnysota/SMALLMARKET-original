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
    public partial class frmImportarRegistroArticulos : FrmMantenimientoBase
    {
        public frmImportarRegistroArticulos()
        {
            InitializeComponent();
        }

        #region Variables
        
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        List<ArticuloServXLSE> oLista = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String RutaVariosArchivos = String.Empty;
        String TipoProceso = String.Empty;
        Int32 errores = 0;
        #endregion        

        #region Procedimientos de Usuario
        
        Boolean ImportarExcel(FileInfo oFi_)
        {
            int FilaInicial = 6;

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {
                    //Entidad
                    ArticuloServXLSE oRegistro = null;
                    oLista = new List<ArticuloServXLSE>();

                    
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
                                oRegistro = new ArticuloServXLSE();
                                oRegistro.Linea = f;
                                oRegistro.TipoArticulo         = (oHoja.Cells[f, 1].Value).ToString().Trim();
                                oRegistro.Categoria               = (oHoja.Cells[f, 2].Value).ToString().Trim();
                                oRegistro.CodigoArticulo        = (oHoja.Cells[f, 3].Value).ToString().Trim();
                                oRegistro.Nombre = (oHoja.Cells[f, 4].Value).ToString().Trim();
                                oRegistro.NombreLargo = (oHoja.Cells[f, 5].Value).ToString().Trim();
                                oRegistro.NombreCorto = (oHoja.Cells[f, 6].Value).ToString().Trim();
                                oRegistro.CodBarra = (oHoja.Cells[f, 7].Value).ToString().Trim();
                                oRegistro.TipoMedAlmacen = (oHoja.Cells[f, 8].Value).ToString().Trim();
                                oRegistro.UniMedAlmacen = (oHoja.Cells[f, 9].Value).ToString().Trim();
                                oRegistro.TipoMedEnv = (oHoja.Cells[f, 10].Value).ToString().Trim();
                                oRegistro.UniMedEnv = (oHoja.Cells[f, 11].Value).ToString().Trim();
                                oRegistro.TipoMedPres = (oHoja.Cells[f, 12].Value).ToString().Trim();
                                oRegistro.UniMedPres = (oHoja.Cells[f, 13].Value).ToString().Trim();


                                oRegistro.Contenido  = Convert.ToDecimal((oHoja.Cells[f, 14].Value !=null && oHoja.Cells[f, 14].Value.ToString().Length > 0 ? oHoja.Cells[f, 14].Value : "0"));
                                oRegistro.PesoUnitario      = Convert.ToDecimal((oHoja.Cells[f, 15].Value !=null && oHoja.Cells[f, 15].Value.ToString().Length > 0 ? oHoja.Cells[f, 15].Value : "0"));						

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
            errores = 0;
            AgenteMaestros.Proxy.ProcesarArticuloServXLS(oLista);
            errores = AgenteMaestros.Proxy.ErroresArticuloServXLSE();
            
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {        
            btExaminar.Enabled = true;
            btActualizar.Enabled = true;
            btProcesar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            letra = 0;
            timer1.Enabled = false;
            Cursor = System.Windows.Forms.Cursors.Arrow;
            _bw.CancelAsync();
            _bw.Dispose();

            btProcesar.Enabled = false;

            if (errores > 0)
            {
                bterrores.Enabled = true;
                btIntegrar.Enabled = false;
                Infraestructura.Global.MensajeComunicacion("El proceso ha concluido con Errores en..." + oLista.Count.ToString() + " registros  ... Ver Errores ");
            }
            else
            {
                bterrores.Enabled = false;
                btIntegrar.Enabled = true;
                Infraestructura.Global.MensajeComunicacion("El proceso ha concluido correctamente...");
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

                FileInfo RutaArchivo = new FileInfo(txtRuta.Text);

                if (RutaArchivo.Exists)
                {
                    if (ImportarExcel(RutaArchivo))
                    {
                        Infraestructura.Global.MensajeComunicacion("Importación Terminada...  " + oLista.Count.ToString() + " registros");

                        if(oLista.Count>0)
                            btProcesar.Enabled = true;
                    }
                }
                else
                {
                    Infraestructura.Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaArchivo));
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
                if (oLista!= null)
                {
                    if (oLista.Count > Variables.Cero)
                    {
                        TipoProceso = "P";
                        btActualizar.Enabled = false;
                        btProcesar.Enabled = false;
                        btExaminar.Enabled = false;
                        lblProcesando.Visible = true;
                        timer1.Enabled = true;
                        Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        Marquee = "Procesando...";
                        pbProgress.Visible = true;
                        _bw.RunWorkerAsync();
                    }
                    else
                    {
                        Infraestructura.Global.MensajeFault("La lista de registros se encuentra vacia aún...");
                    }
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
            //AgenteContabilidad.Proxy.IntegrarArticuloServXLS();
        }
    }
}
