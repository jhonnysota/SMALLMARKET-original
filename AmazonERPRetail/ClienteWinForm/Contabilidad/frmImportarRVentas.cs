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

namespace ClienteWinForm.Contabilidad
{
    public partial class frmImportarRVentas : FrmMantenimientoBase
    {

        public frmImportarRVentas()
        {
            InitializeComponent();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<ImportacionRVentasE> oListaPrincipal = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        String TipoProceso = String.Empty; //I=Importación P=Procesar G=Generación
        Int32 Registros = Variables.Cero;
        Int32 respGeneracion = 0;

        #endregion

        #region Procedimientos de Usuario

        List <ImportacionRVentasE> LeerArchivo(String Ruta, String NombreArchivo)
        {
            List<ImportacionRVentasE> oListaDevuelve = new List<ImportacionRVentasE>();
            String Linea = String.Empty;
            String Importe = String.Empty;
            Int32 fila = 1;
            DateTime FechaActual = VariablesLocales.FechaHoy;
            String Usuario = VariablesLocales.SesionUsuario.Credencial;
            String numVoucher = String.Empty;
            String numFileItem = String.Empty;

            using (StreamReader osReader = new StreamReader(Ruta))
            {
                while ((Linea = osReader.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(Linea))
                    {
                        if (Linea.Length > 150)
                        {
                            String CuentaValidar;
                            CuentaValidar = Linea.Substring(15, 10).Trim();

                            if (CuentaValidar.Length == 6)
                            {

                                ImportacionRVentasE rventas = new ImportacionRVentasE
                                {
                                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                    idLocal = VariablesLocales.SesionLocal.IdLocal,
                                    idEstablecimiento = 0,

                                    T = Linea.Substring(0, 2),
                                    VOU = Linea.Substring(2, 5),
                                    Fecha = Convert.ToDateTime(Linea.Substring(7, 8)),
                                    Cuenta = Linea.Substring(15, 10).Trim(),

                                    Debe = Convert.ToDecimal(Linea.Substring(25, 12)),
                                    Haber = Convert.ToDecimal(Linea.Substring(37, 12)),
                                    Moneda = Linea.Substring(49, 1).Trim(),

                                    TC = Convert.ToDecimal(Linea.Substring(50, 10)),

                                    Doc = Linea.Substring(60, 2).Trim(),
                                    Numero = Linea.Substring(62, 13).Trim(),
                                    FechaD = Convert.ToDateTime(Linea.Substring(102, 8)),
                                    FechaV = String.IsNullOrWhiteSpace(Linea.Substring(110, 8).Trim()) ? (DateTime?)null : Convert.ToDateTime(Linea.Substring(110, 8)),
                                    Codigo = Linea.Substring(118, 15).Trim(),
                                    CC = Linea.Substring(133, 10).Trim(),
                                    FE = Linea.Substring(143, 4).Trim(),
                                    PRE = Linea.Substring(147, 10).Trim(),
                                    MPago = Linea.Substring(157, 3).Trim(),
                                    Glosa = Linea.Substring(160, 60).Trim(),

                                    RNumero = Linea.Substring(220, 40).Trim().Trim(),
                                    RTdoc = Linea.Substring(260, 2).Trim(),
                                    RFecha = String.IsNullOrWhiteSpace(Linea.Substring(262, 8).Trim()) ? (DateTime?)null : Convert.ToDateTime(Linea.Substring(262, 8)),
                                    SNumero = Linea.Substring(270, 40).Trim(),
                                    SFecha = String.IsNullOrWhiteSpace(Linea.Substring(310, 8).Trim()) ? (DateTime?)null : Convert.ToDateTime(Linea.Substring(310, 8)),
                                    TL = Linea.Substring(318, 1).Trim(),
                                    BaseImponible = String.IsNullOrWhiteSpace(Linea.Substring(319, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(319, 12)),
                                    BaseNoImponible = String.IsNullOrWhiteSpace(Linea.Substring(331, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(331, 12)),
                                    IgvB = String.IsNullOrWhiteSpace(Linea.Substring(343, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(343, 12)),
                                    BaseImponibleExportacion = String.IsNullOrWhiteSpace(Linea.Substring(355, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(355, 12)),
                                    IGV = String.IsNullOrWhiteSpace(Linea.Substring(367, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(367, 12)),
                                    IgvOtros = String.IsNullOrWhiteSpace(Linea.Substring(379, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(379, 12)),
                                    BaseImponilbleC = String.IsNullOrWhiteSpace(Linea.Substring(391, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(391, 12)),
                                    IgvC = String.IsNullOrWhiteSpace(Linea.Substring(403, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(403, 12)),
                                    ISC = String.IsNullOrWhiteSpace(Linea.Substring(415, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(415, 12)),
                                    RUC = Linea.Substring(427, 15).Trim(),

                                    Tipo = Linea.Substring(442, 1).Trim(),
                                    Rs = Linea.Substring(443, 60).Trim(),
                                    Ape1 = Linea.Substring(503, 20).Trim(),
                                    Ape2 = Linea.Substring(523, 20).Trim(),
                                    Nombre = Linea.Substring(543, 20).Trim(),
                                    TDoci = Linea.Substring(563, 1).Trim(),
                                    RNumdes = Linea.Substring(564, 1).Trim(),
                                    RCodTasa = Linea.Substring(565, 5).Trim(),
                                    RIndRet = Linea.Substring(570, 1).Trim(),
                                    RMonto = String.IsNullOrWhiteSpace(Linea.Substring(571, 12).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(571, 12)),
                                    RIgv = String.IsNullOrWhiteSpace(Linea.Substring(583, 1).Trim()) ? 0M : Convert.ToDecimal(Linea.Substring(583, 1)),

                                    NombreArchivo = NombreArchivo
                                };

                                //Para saber a que libro y file se van
                                if (rventas.T == "01") //Compras
                                {
                                    rventas.Libro = "03";

                                    if (rventas.VOU != numVoucher)
                                    {
                                        if (rventas.IGV > 0)
                                        {
                                            numFileItem = "01";
                                        }
                                        else
                                        {
                                            numFileItem = "02";
                                        }
                                    }

                                    rventas.numFile = numFileItem;

                                    if (rventas.Cuenta.Substring(0, 2) == "42")
                                    {
                                        if (rventas.Moneda == "S")
                                        {
                                            rventas.Cuenta = VariablesLocales.oConParametros.CompraS;
                                        }
                                        else
                                        {
                                            rventas.Cuenta = VariablesLocales.oConParametros.CompraD;
                                        }
                                    }
                                    else if (rventas.Cuenta.Substring(0, 2) == "40")
                                    {
                                        rventas.Cuenta = VariablesLocales.oListaImpuestos[0].codCuenta;
                                    }
                                }
                                else if (rventas.T == "02") //Ventas
                                {
                                    rventas.Libro = "02";

                                    if (rventas.IGV > 0)
                                    {
                                        rventas.numFile = "01";
                                    }
                                    else
                                    {
                                        rventas.numFile = "02";
                                    }
                                }
                                else
                                {

                                }

                                if (Convert.ToDecimal(rventas.Debe) > 0 || Convert.ToDecimal(rventas.Haber) > 0)
                                {
                                    if (rventas.VOU != numVoucher)
                                    {
                                        fila = 1;
                                    }
                                    else
                                    {
                                        fila++;
                                    }

                                    if (Convert.ToDecimal(rventas.Debe) > 0)
                                    {
                                        rventas.DebeHaber = "D";
                                    }

                                    if (Convert.ToDecimal(rventas.Haber) > 0)
                                    {
                                        rventas.DebeHaber = "H";
                                    }

                                    rventas.AnioPeriodo = Convert.ToDateTime(rventas.Fecha).ToString("yyyy");
                                    rventas.MesPeriodo = Convert.ToDateTime(rventas.Fecha).ToString("MM");
                                    rventas.Item = fila;

                                    oListaDevuelve.Add(rventas);
                                    numVoucher = rventas.VOU;
                                }
                                else
                                {
                                    if (rventas.Glosa.Trim() == "ANULADO")
                                    {
                                        if (rventas.VOU != numVoucher)
                                        {
                                            fila = 1;
                                        }
                                        else
                                        {
                                            fila++;
                                        }

                                        rventas.DebeHaber = "D";
                                        rventas.AnioPeriodo = Convert.ToDateTime(rventas.Fecha).ToString("yyyy");
                                        rventas.MesPeriodo = Convert.ToDateTime(rventas.Fecha).ToString("MM");
                                        rventas.Item = fila;

                                        oListaDevuelve.Add(rventas);
                                        numVoucher = rventas.VOU;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            return oListaDevuelve.ToList();
        }

        void ImportarVariosArchivos(String Ruta)
        {
            try
            {
                DirectoryInfo oDi = new DirectoryInfo(Ruta);

                foreach (FileInfo item in oDi.GetFiles())
                {
                    if (item.Extension.ToLower() == ".csv" || item.Extension.ToLower() == ".txt" || item.Extension.ToLower() == ".xlsx" || item.Extension.ToLower() == ".xls")
                    {
                        FileInfo oFiTmp = new FileInfo(item.FullName);
                        lbArchivos.Items.Add(oFiTmp.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                _bw.CancelAsync();
                throw new Exception(ex.Message);
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
                    int CountReg = 0;
                    List<ImportacionRVentasE> oListaTmp = new List<ImportacionRVentasE>();
                    var ListaPorBorrar = oListaPrincipal.GroupBy(x => new { x.idEmpresa, x.Libro }).Select(g => g.First()).ToList();
                    DateTime fecInicial = VariablesLocales.FechaHoy;//Convert.ToDateTime((from mn in oListaPrincipal
                                                                    //select (DateTime?)mn.Fecha).Min());

                    DateTime fecFinal = VariablesLocales.FechaHoy; //Convert.ToDateTime((from mx in oListaPrincipal
                                                                   //select (DateTime?)mx.Fecha).Max());

                    foreach (var item in ListaPorBorrar)
                    {
                        fecInicial = Convert.ToDateTime((from mn in oListaPrincipal
                                                         where mn.idEmpresa == item.idEmpresa
                                                         && mn.Libro == item.Libro
                                                         select (DateTime?)mn.Fecha).Min());

                        fecFinal = Convert.ToDateTime((from mx in oListaPrincipal
                                                       where mx.idEmpresa == item.idEmpresa
                                                       && mx.Libro == item.Libro
                                                       select (DateTime?)mx.Fecha).Max());

                        AgenteContabilidad.Proxy.EliminarRVENTAS(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, item.Libro, fecInicial, fecFinal);
                    }

                    String strTotal = oListaPrincipal.Count.ToString();

                    for (int i = 0; i < oListaPrincipal.Count; i++)
                    {
                        double ii = i % 100;

                        if (i != 0 && i % 100 == 0)
                        {
                            AgenteContabilidad.Proxy.ImportarRVentas(oListaTmp);
                            Registros += oListaTmp.Count;
                            oListaTmp = new List<ImportacionRVentasE>();
                            CountReg = i;
                        }

                        if (i < 100)
                        {
                            CountReg = i;
                        }

                        ImportacionRVentasE oItem = oListaPrincipal[i];
                        oListaTmp.Add(oItem);

                        lblProcesando.Text = "Total de Registros : " + (i + 1).ToString() + " de " + strTotal + ".";
                    }

                    if (CountReg < 100)
                    {
                        AgenteContabilidad.Proxy.ImportarRVentas(oListaTmp);
                        Registros += oListaTmp.Count;
                    }
                    else
                    {
                        oListaTmp = new List<ImportacionRVentasE>();

                        for (int i = CountReg; i < oListaPrincipal.Count; i++)
                        {
                            ImportacionRVentasE oItem = oListaPrincipal[i];
                            oListaTmp.Add(oItem);
                        }

                        AgenteContabilidad.Proxy.ImportarRVentas(oListaTmp);
                        Registros += oListaTmp.Count;
                    }
                }
                else if (TipoProceso == "G")
                {
                    DateTime fecInicial, fecFinal;
                    Boolean EliminarVouchers = true;

                    fecInicial = Convert.ToDateTime((from mn in oListaPrincipal
                                                     select (DateTime?)mn.Fecha).Min());

                    fecFinal = Convert.ToDateTime((from mx in oListaPrincipal
                                                   select (DateTime?)mx.Fecha).Max());

                    List<DateTime> Fechas = (from x in oListaPrincipal
                                             orderby x.Fecha
                                             group x by new { x.Fecha } into g
                                             select g.Key.Fecha
                                              ).ToList();

                    for (int i = 0; i < Fechas.Count; i++)
                    {
                       
                        List<ImportacionRVentasE> Listatmp = (from x in oListaPrincipal where x.Fecha == Fechas[i] select x).ToList();

                        respGeneracion = AgenteContabilidad.Proxy.GenerarVouchersRVentas(Listatmp, VariablesLocales.SesionUsuario.Credencial, EliminarVouchers, fecInicial, fecFinal);

                        EliminarVouchers = false;

                    }

     
                    
                    oListaPrincipal = null;
                }
            }
            catch (Exception ex)
            {
                btActualizar.Enabled = true;
                btProcesar.Enabled = true;
                btExaminar.Enabled = true;
                oListaPrincipal = null;
                respGeneracion = 0;

                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btExaminar.Enabled = true;
            btActualizar.Enabled = true;
            btProcesar.Enabled = true;
            btGenerarVoucher.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            letra = 0;
            timer1.Enabled = false;
            Cursor = System.Windows.Forms.Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (TipoProceso == "P")
                {
                    txtRuta.Text = String.Empty;

                    if (Registros == Variables.Cero)
                    {
                        Global.MensajeComunicacion("Falló la importación. Revise por favor...");
                    }
                    else
                    {
                        lbArchivos.Items.Clear();
                        Global.MensajeComunicacion("El proceso ha concluido...");
                    }
                }
                else if (TipoProceso == "G")
                {
                    if (respGeneracion > 0)
                    {
                        lbArchivos.Items.Clear();
                        Global.MensajeComunicacion("Asientos generados correctamente... !!!!");
                    }
                }
            }
        }

        #endregion

        #region Eventos

        private void frmImportarMarcacion_Load(object sender, EventArgs e)
        {
            Grid = false;
            CheckForIllegalCrossThreadCalls = false;
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.SeleccionarCarpeta();

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    oListaPrincipal = new List<ImportacionRVentasE>();
                    lbArchivos.Text = String.Empty;
                    lbArchivos.Items.Clear();

                    ImportarVariosArchivos(txtRuta.Text);
                }
            }
            catch (Exception ex)
            {
                TipoProceso = String.Empty;
                Global.MensajeError(ex.Message);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                }

                Boolean Error = false;

                if (String.IsNullOrEmpty(txtRuta.Text))
                {
                    Global.MensajeFault("Tiene que colocar la ruta del archivo");
                    return;
                }

                if (lbArchivos.Items.Count == Variables.Cero)
                {
                    Global.MensajeFault("No archivos en la lista.");
                    return;
                }

                if (Directory.Exists(txtRuta.Text))
                {
                    lblProcesando.Text = String.Empty;
                    lblProcesando.Visible = true;

                    oListaPrincipal = new List<ImportacionRVentasE>();

                    foreach (String item in lbArchivos.Items)
                    {
                        String RutaActual = txtRuta.Text + @"\";
                        RutaActual += item;

                        FileInfo RutaArchivo = new FileInfo(RutaActual);

                        if (RutaArchivo.Exists)
                        {
                            lblProcesando.Refresh();
                            lblProcesando.Text = "Procesando el archivo " + item;
                            lblProcesando.Refresh();

                            if (RutaArchivo.Extension.ToUpper().Contains("TXT"))
                            {
                                oListaPrincipal.AddRange(LeerArchivo(RutaActual, RutaArchivo.Name));
                            }
                        }
                        else
                        {
                            Global.MensajeFault(String.Format("El archivo no existe en la ruta especificada: {0}. \n\rRevise por favor", RutaArchivo));
                            Error = true;
                            break;
                        }
                    }
                }
                else
                {
                    Global.MensajeFault(String.Format("La carpeta no existe en la ruta especificada: {0}. \n\rRevise por favor", txtRuta.Text));
                }

                if (!Error)
                {
                    if (oListaPrincipal.Count > Variables.Cero)
                    {
                        btProcesar.Enabled = true;
                        btActualizar.Enabled = true;
                        btProcesar.Focus();
                        Global.MensajeComunicacion(String.Format("Proceso Terminado con {0} registros. Ahora presione el Botón Procesar", oListaPrincipal.Count.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                btProcesar.Enabled = false;
                Global.MensajeComunicacion(ex.Message);
            }
            finally
            {
                lblProcesando.Text = String.Empty;
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
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btGenerarVoucher.Enabled = false;
                    pbProgress.Visible = true;
                    lblProcesando.Visible = true;
                    Cursor = System.Windows.Forms.Cursors.WaitCursor;

                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeComunicacion("La lista de registros se encuentra vacia aún...");
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

        private void btGenerarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (oListaPrincipal != null && oListaPrincipal.Count > 0)
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }

                    TipoProceso = "G";
                    btExaminar.Enabled = false;
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btGenerarVoucher.Enabled = false;
                    pbProgress.Visible = true;
                    lblProcesando.Visible = true;
                    Marquee = "Generando los asientos para contabilidad...!!";
                    timer1.Enabled = true;
                    Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeAdvertencia("No hay registros para generar los asientos contables...");
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
