using ClienteWinForm.Contabilidad.Reportes;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using OfficeOpenXml;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Ventas
{
    public partial class frmImportarPresupuestoDeVentas : FrmMantenimientoBase
    {
        public frmImportarPresupuestoDeVentas()
        {
            Infraestructura.Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        String RutaGeneral = String.Empty;
        List<PresupuestoDeVentasXLSE> oListaPrincipal = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty;
        Int32 errores = 0;

        #endregion

        #region Procedimientos de Usuario

        Boolean ImportarExcel(String Ruta)
        {
            int Inicio = 6;
            Int32 FilaError = 0;
            Int32 Columna = 0;
            FileInfo oFi_ = new FileInfo(Ruta);

            try
            {
                using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                {

                    PresupuestoDeVentasXLSE oRegistro = null;
                    oListaPrincipal = new List<PresupuestoDeVentasXLSE>();

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
                                oRegistro = new PresupuestoDeVentasXLSE();
                                oRegistro.Linea = FilaError = f;
                                oRegistro.idEmpresa = Convert.ToInt32(oHoja.Cells[2, 1].Value);

                                if (oRegistro.idEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa)
                                {
                                    oRegistro.Anio = Convert.ToString(oHoja.Cells[3, 2].Value);
                                    oRegistro.idTipoArticulo = "333001";
                                    oRegistro.Moneda = "02";


                                    Columna = 1;
                                    if (oHoja.Cells[f, 1].Value != null)
                                    {
                                        oRegistro.NroDocumento = Convert.ToString(oHoja.Cells[f, 1].Value);
                                    }

                                    Columna = 2;
                                    if (oHoja.Cells[f, 2].Value != null)
                                    {
                                        Persona Pers = AgenteMaestros.Proxy.ObtenerPersonaPorNroRuc(oRegistro.NroDocumento);

                                        oRegistro.idVendedor = Pers.IdPersona;
                                    }

                                    Columna = 3;
                                    if (oHoja.Cells[f, 3].Value != null)
                                    {
                                        oRegistro.Zona = Convert.ToString(oHoja.Cells[f, 3].Value);
                                    }
                                    Columna = 4;
                                    if (oHoja.Cells[f, 4].Value != null)
                                    {
                                        oRegistro.Articulo = (oHoja.Cells[f, 4].Value).ToString().Trim();


                                    }

                                    Columna = 5;
                                    for (int i = 1; i <= 12; i++)
                                    {
                                        oRegistro.Linea = FilaError = f;
                                        oRegistro.idEmpresa = Convert.ToInt32(oHoja.Cells[2, 1].Value);
                                        oRegistro.Anio = Convert.ToString(oHoja.Cells[3, 2].Value);
                                        oRegistro.idTipoArticulo = "333001";
                                        oRegistro.Moneda = "02";
                                        oRegistro.NroDocumento = Convert.ToString(oHoja.Cells[f, 1].Value);
                                        Persona Pers = AgenteMaestros.Proxy.ObtenerPersonaPorNroRuc(oRegistro.NroDocumento);
                                        oRegistro.idVendedor = Pers.IdPersona;
                                        oRegistro.Zona = Convert.ToString(oHoja.Cells[f, 3].Value);
                                        oRegistro.Articulo = (oHoja.Cells[f, 4].Value).ToString().Trim();

                                        Columna++;
                                        if (oHoja.Cells[f, Columna].Value != null)
                                        {
                                            oRegistro.Cantidad = Convert.ToDecimal(oHoja.Cells[f, Columna].Value);
                                        }

                                        Columna++;
                                        if (oHoja.Cells[f, Columna].Value != null)
                                        {
                                            oRegistro.Precio = Convert.ToDecimal(oHoja.Cells[f, Columna].Value);
                                        }

                                        oRegistro.Mes = "0" + i;

                                        if (i > 9)
                                        {
                                            oRegistro.Mes = i.ToString();
                                        }

                                        oListaPrincipal.Add(oRegistro);

                                        oRegistro = new PresupuestoDeVentasXLSE();
                                    }


                                    ContadorItem++;
                                }
                                else
                                {
                                    throw new Exception(String.Format("La Empresa Local No Coincide Con Su Excel"));
                                }
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
                    AgenteVentas.Proxy.EliminarPresupuestoDeVentasXLS(ListaTemporal.ToList());

                    //Empezando el ingreso a VoucherXLS
                    if (oListaPrincipal.Count < 1000)
                    {
                        AgenteVentas.Proxy.InsertarPresupuestoDeVentasXLS(oListaPrincipal);
                    }
                    else
                    {
                        List<PresupuestoDeVentasXLSE> oListaExcel = new List<PresupuestoDeVentasXLSE>(oListaPrincipal);
                        TotalReg = TotalTemp = oListaExcel.Count;
                        cantReg = TotalReg / 10;
                        Residuo = TotalReg % 10;

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<PresupuestoDeVentasXLSE> oListaTemporal = new List<PresupuestoDeVentasXLSE>();

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

                            foreach (PresupuestoDeVentasXLSE itemTemp in oListaTemporal)
                            {
                                oListaExcel.Remove(itemTemp);
                            }

                            if (oListaTemporal.Count > Variables.Cero)
                            {
                                Minimo = Convert.ToInt32(oListaTemporal.Min(x => x.Linea));
                                Maximo = Convert.ToInt32(oListaTemporal.Max(x => x.Linea));
                                MensajeErr = String.Format("Revisar en el rango de lineas de {0} al {1}.", Minimo.ToString(), Maximo.ToString());

                                AgenteVentas.Proxy.InsertarPresupuestoDeVentasXLS(oListaTemporal);

                                TotalTemp -= oListaTemporal.Count();
                                oListaTemporal = null;
                                lblRegistros.Text = "Total Reg. " + TotalReg.ToString() + " Faltan " + TotalTemp.ToString();
                            }
                        }

                        oListaExcel = null;
                    }

                    //Obteniendo los errores si los hubiere...
                    errores = AgenteVentas.Proxy.ErroresPresupuestoDeVentasXLS(ListaTemporal.ToList());

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
                    Int32 Reg = AgenteVentas.Proxy.IntegrarPresupuestoDeVentasXLS(oListaPrincipal, VariablesLocales.SesionUsuario.Credencial);
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
                else if (TipoProceso == "E")
                {
                    btProcesar.Enabled = oListaPrincipal.Count > 0;
                    Infraestructura.Global.MensajeComunicacion("Se ha importado la hoja excel correctamente...");
                }
                else
                {
                    btProcesar.Enabled = false;
                    btErrores.Enabled = false;
                    btIntegrar.Enabled = false;
                    Infraestructura.Global.MensajeComunicacion("Se han ingresado El Presupuesto De Venta correctamente...");
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

        private void frmImportarPresupuestoDeVentas_Load(object sender, EventArgs e)
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

                oFrm = new frmErrores("PRESUPUESTO");
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
