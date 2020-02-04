using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Excel

using OfficeOpenXml;

#endregion

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarRegistroVentas : FrmMantenimientoBase
    {

        public frmImportarRegistroVentas()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Variables
        
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        List<RegistroVentaGeneralE> oListaVentas = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String RutaVariosArchivos = String.Empty;
        String TipoProceso = String.Empty; 

        #endregion        

        #region Procedimientos de Usuario
        
        Boolean ImportarExcel(FileInfo oFi_)
        {
            Int32 LineaError = 0;
            Int32 FilaInicial = 0;
            Int32.TryParse(txtInicio.Text, out FilaInicial);
            Int32 Columna = 0;
            try
            {
                if (FilaInicial > 0)
                {
                    //Archivo
                    using (ExcelPackage oExcel = new ExcelPackage(oFi_))
                    {
                        //Entidad
                        RegistroVentaGeneralE oRegistro = null;
                        //Lista para los datos importados
                        oListaVentas = new List<RegistroVentaGeneralE>();

                        //Hoja Excel
                        using (ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1])
                        {
                            //Para el recorrido del excel
                            Int32 totFilas = oHoja.Dimension.End.Row;
                            int ContadorItem = 1;

                            //Recorriendo la hoja excel hasta el total de fila obtenido...
                            for (int f = FilaInicial; f <= totFilas; f++)
                            {
                                if (oHoja.Cells[f, 1].Value != null)
                                {
                                    if ((oHoja.Cells[f, 1].Value).ToString().Trim().Length > 0)
                                    {
                                        LineaError = f ;

                                        // Fila Nueva
                                        oRegistro = new RegistroVentaGeneralE();

                                        if (oHoja.Cells[2, 1].Value != null)
                                        {
                                            oRegistro.idEmpresa = Convert.ToInt32(oHoja.Cells[2, 1].Value);
                                        }
                                        else
                                        {
                                            throw new Exception("Debe colocar el código de la Empresa");
                                        }

                                        if (oHoja.Cells[5, 1].Value != null)
                                        {
                                            oRegistro.idLocal = Convert.ToInt32(oHoja.Cells[5, 1].Value);
                                        }
                                        else
                                        {
                                            throw new Exception("Debe colocar el código del Local.");
                                        }
                                        Columna = 1;
                                        oRegistro.idComprobante = String.Format("{0:00}", Convert.ToInt32(oHoja.Cells[f, 1].Value));
                                        Columna = 2;
                                        oRegistro.numFile = String.Format("{0:00}", Convert.ToInt32(oHoja.Cells[f, 2].Value));
                                        Columna = 3;
                                        oRegistro.numCorrelativo = String.Format("{0:000000000}", Convert.ToInt32(oHoja.Cells[f, 3].Value));


                                        Columna = 4;
                                        if (oHoja.Cells[f, 4].Value == null)
                                        {
                                            throw new Exception(String.Format("En la Fila {0} falta la Fecha de Operación", f.ToString()));
                                        }
                                        else
                                        {
                                            oRegistro.fecOperacion = Convert.ToDateTime(oHoja.Cells[f, 4].Value);
                                        }

                                        Columna = 5;

                                        if (oHoja.Cells[f, 5].Value == null)
                                        {
                                            throw new Exception(String.Format("En la Fila {0} falta la Fecha del Documento", f.ToString()));
                                        }
                                        else
                                        {
                                            oRegistro.fecDocumento = Convert.ToDateTime(oHoja.Cells[f, 5].Value);
                                        }

                                        Columna = 6;
                                        oRegistro.fecVencimiento = (oHoja.Cells[f, 6].Value != null ? Convert.ToDateTime(oHoja.Cells[f, 6].Value) : (DateTime?)null);
                                        Columna =7;
                                        oRegistro.idDocumento = oHoja.Cells[f, 7].Value.ToString().Trim();
                                        Columna = 8;
                                        oRegistro.SerieDocumento = (oHoja.Cells[f, 8].Value).ToString().Trim();
                                        Columna = 9;
                                        oRegistro.NumeroDocumento = (oHoja.Cells[f, 9].Value).ToString().Trim();

                                        Columna = 10;
                                        oRegistro.TipoDocIdentidad = (oHoja.Cells[f, 10].Value).ToString().Trim();
                                        Columna = 11;
                                        oRegistro.NumeroDocIdentidad = (oHoja.Cells[f, 11].Value).ToString().Trim();
                                        Columna = 12;
                                        oRegistro.RazonSocial = (oHoja.Cells[f, 12].Value).ToString().Trim();
                                        Columna = 13;
                                        oRegistro.Moneda = String.Format("{0:00}", Convert.ToInt32(oHoja.Cells[f, 13].Value));

                                        Columna = 14;
                                        oRegistro.BaseImponibleExportacion = Convert.ToDecimal((oHoja.Cells[f, 14].Value != null && oHoja.Cells[f, 14].Value.ToString().Length > 0 ? oHoja.Cells[f, 14].Value : 0));
                                        Columna = 15;
                                        oRegistro.BaseImponibleGravada = Convert.ToDecimal((oHoja.Cells[f, 15].Value != null && oHoja.Cells[f, 15].Value.ToString().Length > 0 ? oHoja.Cells[f, 15].Value : 0));
                                        Columna = 16;
                                        oRegistro.ImporteTotalExonerada = Convert.ToDecimal((oHoja.Cells[f, 16].Value != null && oHoja.Cells[f, 16].Value.ToString().Length > 0 ? oHoja.Cells[f, 16].Value : 0));
                                        Columna = 17;
                                        oRegistro.ImporteTotalInafecto = Convert.ToDecimal((oHoja.Cells[f, 17].Value != null && oHoja.Cells[f, 17].Value.ToString().Length > 0 ? oHoja.Cells[f, 17].Value : 0));
                                        Columna = 18;
                                        oRegistro.ISC = Convert.ToDecimal((oHoja.Cells[f, 18].Value != null && oHoja.Cells[f, 18].Value.ToString().Length > 0 ? oHoja.Cells[f, 18].Value : 0));
                                        Columna = 19;
                                        oRegistro.IGV = Convert.ToDecimal((oHoja.Cells[f, 19].Value != null && oHoja.Cells[f, 19].Value.ToString().Length > 0 ? oHoja.Cells[f, 19].Value : 0));
                                        Columna = 20;
                                        oRegistro.OtrosTributos = Convert.ToDecimal((oHoja.Cells[f, 20].Value != null && oHoja.Cells[f, 20].Value.ToString().Length > 0 ? oHoja.Cells[f, 20].Value : 0));
                                        Columna = 21;
                                        oRegistro.ImporteTotal = Convert.ToDecimal((oHoja.Cells[f, 21].Value != null && oHoja.Cells[f, 21].Value.ToString().Length > 0 ? oHoja.Cells[f, 21].Value : 0));
                                        Columna = 22;
                                        oRegistro.TipoCambio = Convert.ToDecimal((oHoja.Cells[f, 22] != null && oHoja.Cells[f, 22].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 22].Value : 0));
                                        Columna = 23;
                                        oRegistro.FechaRef = (oHoja.Cells[f, 23].Value == null || String.IsNullOrWhiteSpace(oHoja.Cells[f, 23].Value.ToString()) ? (DateTime?)null : Convert.ToDateTime(oHoja.Cells[f, 23].Value));
                                        Columna = 24;
                                        oRegistro.idDocumentoRef = (oHoja.Cells[f, 24].Value != null ? (oHoja.Cells[f, 24].Value).ToString().Trim() : "");
                                        Columna = 25;
                                        oRegistro.serDocumentoRef = (oHoja.Cells[f, 25].Value != null ? (oHoja.Cells[f, 25].Value).ToString().Trim() : "");
                                        Columna = 26;
                                        oRegistro.numDocumentoRef = (oHoja.Cells[f, 26].Value != null ? (oHoja.Cells[f, 26].Value).ToString().Trim() : "");

                                        Columna = 27;
                                        oRegistro.porIgv = (oHoja.Cells[f, 27].Value != null ? (Convert.ToDecimal((oHoja.Cells[f, 27].Value.ToString().Length > 0 ? oHoja.Cells[f, 27].Value : 0))) : 0);
                                        Columna = 28;
                                        oRegistro.Estado = (oHoja.Cells[f, 28].Value != null ? (oHoja.Cells[f, 28].Value).ToString().Trim() : "");

                                        Columna = 29;
                                        oRegistro.visaEgresos = Convert.ToDecimal((oHoja.Cells[f, 29].Value != null && oHoja.Cells[f, 29].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 29].Value : 0));
                                        Columna = 30;
                                        oRegistro.masterEgresos = Convert.ToDecimal((oHoja.Cells[f, 30].Value != null && oHoja.Cells[f, 30].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 30].Value : 0));
                                        Columna = 31;
                                        oRegistro.dinnersEgresos = Convert.ToDecimal((oHoja.Cells[f, 31].Value != null && oHoja.Cells[f, 31].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 31].Value : 0));
                                        Columna = 32;
                                        oRegistro.americaEgresos = Convert.ToDecimal((oHoja.Cells[f, 32].Value != null && oHoja.Cells[f, 32].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 32].Value : 0));
                                        Columna = 33;
                                        oRegistro.efectivoEgresos = Convert.ToDecimal((oHoja.Cells[f, 33].Value != null && oHoja.Cells[f, 33].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 33].Value : 0));
                                        Columna = 34;
                                        oRegistro.ncEgresos = Convert.ToDecimal((oHoja.Cells[f, 34].Value != null && oHoja.Cells[f, 34].Value.ToString().Trim().Length > 0 ? oHoja.Cells[f, 34].Value : 0));

                                        Columna = 35;
                                        oRegistro.idComprobanteEgresos = (oHoja.Cells[f, 35].Value != null ? (oHoja.Cells[f, 35].Value).ToString().Trim() : "");
                                        Columna = 36;
                                        oRegistro.numFileEgresos = (oHoja.Cells[f, 36].Value != null ? (oHoja.Cells[f, 36].Value).ToString().Trim() : "");
                                        Columna = 37;
                                        oRegistro.FechaEgresos = (oHoja.Cells[f, 37].Value != null && oHoja.Cells[f, 37].Value.ToString().Trim().Length > 9 ? Convert.ToDateTime(oHoja.Cells[f, 37].Value) : oRegistro.FechaEgresos);
                                        Columna = 38;
                                        oRegistro.NumeroDocumentoIngresos = (oHoja.Cells[f, 38].Value != null ? (oHoja.Cells[f, 38].Value).ToString().Trim() : "");
                                        Columna = 39;
                                        oRegistro.CuentaEgresos = (oHoja.Cells[f, 39].Value != null ? (oHoja.Cells[f, 39].Value).ToString().Trim() : "");
                                        Columna = 40;
                                        oRegistro.Cuenta70 = (oHoja.Cells[f, 40].Value != null ? (oHoja.Cells[f, 40].Value).ToString().Trim() : "");
                                        Columna = 41;
                                        oRegistro.CentroCostos = (oHoja.Cells[f, 41].Value != null ? (oHoja.Cells[f, 41].Value).ToString().Trim() : "");

                                        oRegistro.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                                        oRegistro.FechaRegistro = VariablesLocales.FechaHoy;
                                        oRegistro.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                                        oRegistro.FechaModificacion = VariablesLocales.FechaHoy;

                                        oListaVentas.Add(oRegistro);
                                        ContadorItem++;
                                    }
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error en la Fila: {0} Columna: {1} Motivo: {2}", LineaError.ToString(), Columna.ToString(), ex.Message));
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (TipoProceso == "P")
                {
                    AgenteContabilidad.Proxy.ProcesarVentaGeneralMasivo(oListaVentas);
                }

                if (TipoProceso == "V")
                {
                    Int32 Total = oListaVentas.Count;
                    Int32 Avance = 0;Int32 LoteVoucher;
                    String AnioPeriodo = oListaVentas[0].fecOperacion.ToString("yyyy");
                    String MesPeriodo = oListaVentas[0].fecOperacion.ToString("MM");
                    DateTime fecIni = oListaVentas.Min(x => x.fecOperacion);
                    DateTime fecFin = oListaVentas.Max(x => x.fecOperacion);
                 
                    if (Total > 0)
                    {
                        // Eliminar Asientos de Ventas Pasados Anteriormente

                        AgenteContabilidad.Proxy.EliminarVoucherPorPeriodoyFechas(oListaVentas[0].idEmpresa, oListaVentas[0].idLocal, AnioPeriodo, MesPeriodo, oListaVentas[0].idComprobante, oListaVentas[0].numFile, fecIni, fecFin);

                        // Generando Voucher Provision de Ventas               
                        Avance = 0;
                        LoteVoucher = 10;

                        List<List<RegistroVentaGeneralE>> oSubListaVentas = null;
                        oSubListaVentas = Split(oListaVentas, LoteVoucher);

                        foreach (List<RegistroVentaGeneralE> item in oSubListaVentas)
                        {
                            Avance = Avance + LoteVoucher;
                            lblAvance.Text = "Prov.Venta " + Avance.ToString() + " / " + Total.ToString();
                            AgenteContabilidad.Proxy.GenerarVoucherVentasGeneral(item);
                        }
                    }

                    // Generando Voucher de Cancelacion al Contado
                    List<RegistroVentaGeneralE> IngresosAgrupados =
                        (
                         from x in oListaVentas
                         where (x.Estado == "CONT")
                         group x by new { x.idEmpresa,x.idComprobanteEgresos, x.numFileEgresos, x.NumeroDocumentoIngresos, x.FechaEgresos, x.Moneda, x.TipoCambio, x.CuentaEgresos }
                         into g
                         select new RegistroVentaGeneralE()
                         {
                             idEmpresa = g.Key.idEmpresa,
                             idComprobanteEgresos = g.Key.idComprobanteEgresos,
                             numFileEgresos = g.Key.numFileEgresos,
                             idDocumento = "OT",
                             NumeroDocumentoIngresos = g.Key.NumeroDocumentoIngresos,
                             FechaEgresos = g.Key.FechaEgresos,
                             CuentaEgresos = g.Key.CuentaEgresos,
                             TipoCambio = g.Key.TipoCambio,
                             Moneda = g.Key.Moneda,
                             efectivoEgresos = g.Sum(x => x.efectivoEgresos)
                         }
                        ).ToList();

                    Total = IngresosAgrupados.Count;
                    Avance = 0;

                    if (Total > 0)
                    {
                        AgenteContabilidad.Proxy.EliminarVoucherPorPeriodoyFechas(oListaVentas[0].idEmpresa, oListaVentas[0].idLocal, AnioPeriodo, MesPeriodo, IngresosAgrupados[0].idComprobanteEgresos, IngresosAgrupados[0].numFileEgresos, fecIni, fecFin);

                        foreach (RegistroVentaGeneralE Cabecera in IngresosAgrupados)
                        {
                            Avance = Avance + 1;
                            lblAvance.Text = "Ingresos " + Avance.ToString() + " / " + Total.ToString();
                            AgenteContabilidad.Proxy.GenerarVoucherIngresosGeneral(oListaVentas, Cabecera);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            Cursor = Cursors.Arrow;
            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled)
            {

            }
            else
            {
                btProcesar.Enabled = false;
                Global.MensajeComunicacion("El proceso ha concluido...");
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
                Cursor = Cursors.Arrow;
                Marquee = String.Empty;

                Global.MensajeFault(ex.Message);
            }
        }
        
        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Tiene que seleccionar el archivo Excel.");
                    return;
                }

                FileInfo RutaArchivo = new FileInfo(txtRuta.Text);
                
                if (RutaArchivo.Exists)
                {
                    if (ImportarExcel(RutaArchivo))
                    {
                        Global.MensajeComunicacion("Importación Terminada...  " + oListaVentas.Count.ToString() + " registros");

                        if (oListaVentas.Count > 0)
                        {
                            btProcesar.Enabled = true;
                        }
                    }
                }
                else
                {
                    Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaArchivo));
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaVentas!= null)
                {
                    if (oListaVentas.Count > Variables.Cero)
                    {
                        TipoProceso = "P";
                        btActualizar.Enabled = false;
                        btProcesar.Enabled = false;
                        btExaminar.Enabled = false;
                        lblProcesando.Visible = true;
                        timer1.Enabled = true;
                        Cursor = Cursors.WaitCursor;
                        Marquee = "Procesando...";
                        pbProgress.Visible = true;
                        _bw.RunWorkerAsync();
                    }
                    else
                    {
                        Global.MensajeFault("La lista de registros se encuentra vacia...");
                    }
                }
                else
                {
                    Global.MensajeFault("La lista de registros se encuentra vacia...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
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

        public static List<List<RegistroVentaGeneralE>> Split(List<RegistroVentaGeneralE> oListaVentas, int maxSubItems)
        {
            return oListaVentas
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / maxSubItems)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        private void btGenerarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                                                 
                TipoProceso = "V";

                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                btExaminar.Enabled = false;
                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                Marquee = "Procesando Asientos.....";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAuxiliares_Click(object sender, EventArgs e)
        {
            try
            {
                //List<ErrorImportGeneralE> ListaPorMandar = new List<ErrorImportGeneralE>();

                //foreach (RegVentasDetXLSE item in oListaPrincipal)
                //{
                //    foreach (ErrorImportGeneralE itemErr in oListaError)
                //    {
                //        if ((itemErr.ValorCampo == item.Ruc) && itemErr.Mensaje.ToUpper().Contains("NO EXISTE"))
                //        {
                //            ErrorImportGeneralE errBuscar = ListaPorMandar.Find
                //            (
                //                delegate (ErrorImportGeneralE er) { return er.ValorCampo == item.Ruc; }
                //            );

                //            if (errBuscar == null)
                //            {
                //                itemErr.RazonSocial = item.RazonSocial;
                //                ListaPorMandar.Add(itemErr);
                //            }
                //        }
                //    }
                //}

                Int32 resp = AgenteContabilidad.Proxy.CrearClientes(null, VariablesLocales.SesionUsuario.Credencial, oListaVentas);

                if (resp > 0)
                {
                    Global.MensajeComunicacion("Se crearon los auxiliares correctamente.");
                    btAuxiliares.Visible = false;
                    //btIntegrar.Visible = true;
                    //btErrores.Enabled = false;
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
