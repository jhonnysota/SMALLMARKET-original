using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

#region Para Pdf

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Negocio;
using ClienteWinForm;

#endregion

namespace ClienteWinForm.Contabilidad.Reportes
{
    public partial class frmReportePlanCuenta : FrmMantenimientoBase
    {

        public frmReportePlanCuenta()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);
            Global.CrearToolTip(btPle, "Generar Plan Contable Libro Diario para el PLE");
            Global.CrearToolTip(btPleSimplificado, "Generar Plan Contable Libro Diario Simplificado para el PLE");
            LlenarCombos();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }

        List<PlanCuentasE> OListaPlanDeCuenta = null;

        String RutaGeneral = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();

            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);

            if (listaLocales.Count <= 2)
            {
                cboSucursales.SelectedValue = 1;
            }

            //Tipo de comprobantes
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioInicial, AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioFinal, AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa), "idComprobante", "desComprobanteComp");

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where (x.idMoneda == Variables.Soles) || (x.idMoneda == Variables.Dolares)
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desMoneda");
            cboMonedas.SelectedValue = Variables.Soles;

            //Periodos
            cboPeriodoIni.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodoIni.ValueMember = "MesId";
            cboPeriodoIni.DisplayMember = "MesDes";
            cboPeriodoIni.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            cboPeriodoFin.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodoFin.ValueMember = "MesId";
            cboPeriodoFin.DisplayMember = "MesDes";
            cboPeriodoFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;
        }

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = String.Empty;
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;

            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            if (cboPeriodoIni.SelectedValue.ToString() == cboPeriodoFin.SelectedValue.ToString())
            {
                NombreReporte = @"\Registro del Plan de Cuentas " + cboPeriodoIni.Text + " " + Aleatorio.ToString();
                TituloCabecera = cboPeriodoIni.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
            }
            else
            {
                NombreReporte = @"\Registro del Plan de Cuentas " + cboPeriodoIni.Text + " al " + cboPeriodoFin.Text + " " + Aleatorio.ToString();
                TituloCabecera = cboPeriodoIni.Text.ToUpper().ToUpper() + " A " + cboPeriodoFin.Text.ToUpper() + " " + VariablesLocales.PeriodoContable.AnioPeriodo;
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                String TituloGeneral = String.Empty;
                String SubTitulo = String.Empty;

                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar|PdfWriter.HideMenubar;

                    if (docPdf.IsOpen())
                    {
                        docPdf.CloseDocument();
                    }

                    PaginaInicialRegistroPlanCuenta ev = new PaginaInicialRegistroPlanCuenta();
                    ev.Periodos = TituloCabecera;
                    ev.Moneda = cboMonedas.SelectedValue.ToString();
                    oPdfw.PageEvent = ev;

                    docPdf.Open();

                    #region Detalle

                    PdfPTable TablaCabDetalle = new PdfPTable(3);
                    TablaCabDetalle.WidthPercentage = 90;
                    TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.27f, 0.15f });

                    foreach (PlanCuentasE item in OListaPlanDeCuenta)
                    {
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.Periodo, null, "N", null, FontFactory.GetFont("Arial", 6f), 1, 1, "N", "N", 1.3f, 1.3f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.desCuenta, null, "N", null, FontFactory.GetFont("Arial", 6f), 1, 0, "N", "N", 1.3f, 1.3f));
                        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda(item.codPlan + " " + item.desPlan, null, "N", null, FontFactory.GetFont("Arial", 6f), 1, 0, "N", "N", 1.3f, 1.3f));

                        TablaCabDetalle.CompleteRow();
                    }

                    docPdf.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

                    #endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    docPdf.Close();
                }
            }
        }

        void ListaReporte()
        {
            try
            {
                String MesIni = cboPeriodoIni.SelectedValue.ToString();
                String MesFin = cboPeriodoFin.SelectedValue.ToString();
                String idMoneda = cboMonedas.SelectedValue.ToString();
                Int32 idLocal = Convert.ToInt32(cboSucursales.SelectedValue);
                String idComprobanteIni = cboDiarioInicial.SelectedValue.ToString();
                String idComprobanteFin = cboDiarioFinal.SelectedValue.ToString();

                if (Convert.ToInt32(idComprobanteFin) < Convert.ToInt32(idComprobanteIni))
                {
                    idComprobanteIni = cboDiarioFinal.SelectedValue.ToString();
                    idComprobanteFin = cboDiarioInicial.SelectedValue.ToString();
                }

                //Obteniendo los datos de la BD
                OListaPlanDeCuenta = AgenteContabilidad.Proxy.ObtenerReportePlanDeCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idLocal, VariablesLocales.PeriodoContable.AnioPeriodo, MesIni, MesFin, idMoneda, idComprobanteIni, idComprobanteFin);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            lblProcesando.Text = "Obteniendo el Plan de Cuentas...";
            ListaReporte();
            lblProcesando.Text = "Procesando el Reporte...";
            //Generando el PDF
            ConvertirApdf();
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;
            btPle.Enabled = true;
            btPleSimplificado.Enabled = true;

            _bw.CancelAsync();
            _bw.Dispose();

            //Mostrando el reporte en un web browser
            if (!String.IsNullOrEmpty(RutaGeneral))
            {
                wbNavegador.Navigate(RutaGeneral);
                RutaGeneral = String.Empty;
            }
        }

        #endregion

        #region Eventos

        private void frmReportePlanCuenta_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            //Habilitando los eventos para trabajar en segundo plano...
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            this.Location = new Point(0, 0);
            this.Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (this.ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (this.ClientSize.Height - pbProgress.Height) / 3;
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (this.ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (this.ClientSize.Height - lblProcesando.Height) / 2;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboPeriodoFin.SelectedValue) < Convert.ToInt32(cboPeriodoIni.SelectedValue))
                {
                    Global.MensajeFault("El Perido Final no puede ser menor al Periodo de Inicio");
                    return;
                }

                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                btPle.Enabled = false;
                btPleSimplificado.Enabled = false;

                Global.QuitarReferenciaWebBrowser(wbNavegador);
                this.Text = "Reporte Plan de Cuenta Por Sucursal: " + cboSucursales.Text.ToString();
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                btPle.Enabled = true;
                btPleSimplificado.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void btPle_Click(object sender, EventArgs e)
        {
            #region Variables Carga Archivo

            StringBuilder Cadena = new StringBuilder();
            String NombreArchivo = String.Empty;
            String MesIni = cboPeriodoIni.SelectedValue.ToString();
            String MesFin = cboPeriodoFin.SelectedValue.ToString();
            String anioReal = VariablesLocales.PeriodoContable.AnioPeriodo;
            String RutaArchivoTexto = String.Empty;

            #endregion

            try
            {
                if (MesIni != MesFin)
                {
                    Global.MensajeFault("Los periodos tienes que ser el mismo.");
                    return;
                }

                if (MesFin == "13")
                {
                    MesFin = "12";
                }

                NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anioReal + MesFin + "00050300001111";
                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        foreach (PlanCuentasE item in OListaPlanDeCuenta)
                        {
                            Cadena.Append(item.Periodo).Append("|").Append(item.codCuenta).Append("|").Append(item.desCuenta).Append("|");
                            Cadena.Append(item.codPlan).Append("|-|||1|");

                            oSw.WriteLine(Cadena.ToString());
                            Cadena.Clear();
                        }

                        RutaArchivoTexto = String.Empty;
                    }
                }

                Global.MensajeComunicacion("Se generó el archivo correctamente.");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btPleSimplificado_Click(object sender, EventArgs e)
        {
            #region Variables Carga Archivo

            StringBuilder Cadena = new StringBuilder();
            String NombreArchivo = String.Empty;
            String MesIni = cboPeriodoIni.SelectedValue.ToString();
            String MesFin = cboPeriodoFin.SelectedValue.ToString();
            String anioReal = VariablesLocales.PeriodoContable.AnioPeriodo;
            String RutaArchivoTexto = String.Empty;

            #endregion

            try
            {
                if (MesIni != MesFin)
                {
                    Global.MensajeFault("Los periodos tienes que ser el mismo.");
                    return;
                }

                if (MesFin == "13")
                {
                    MesFin = "12";
                }

                NombreArchivo = "LE" + VariablesLocales.SesionUsuario.Empresa.RUC + anioReal + MesFin + "00050400001111";
                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", NombreArchivo, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        foreach (PlanCuentasE item in OListaPlanDeCuenta)
                        {
                            Cadena.Append(item.Periodo).Append("|").Append(item.codCuenta).Append("|").Append(item.desCuenta).Append("|");
                            Cadena.Append(item.codPlan).Append("|-|||1|");

                            oSw.WriteLine(Cadena.ToString());
                            Cadena.Clear();
                        }

                        RutaArchivoTexto = String.Empty;
                    }
                }

                Global.MensajeComunicacion("Se generó el archivo correctamente.");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        #endregion Eventos
    }
}

internal class PaginaInicialRegistroPlanCuenta : PdfPageEventHelper
{
    public String Periodos { get; set; }
    public String Moneda { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);

        iTextSharp.text.BaseColor colCabDetalle = iTextSharp.text.BaseColor.LIGHT_GRAY;
        String TituloGeneral = String.Empty;
        String SubTitulo = String.Empty;
        String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
        String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

        TituloGeneral = "DETALLE DEL PLAN DE CUENTAS UTILIZADO";

        if (Moneda == Variables.Soles)
        {
            SubTitulo = "SOLES";
        }
        else
        {
            SubTitulo = "DOLARES";
        }

        //Cabecera del Reporte
        PdfPTable table = new PdfPTable(2);

        table.WidthPercentage = 90;
        table.SetWidths(new float[] { 0.9f, 0.13f });
        table.HorizontalAlignment = Element.ALIGN_LEFT;

        #region Titulos Principales

        table.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "N", null, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL)));
        table.CompleteRow(); //Fila completada
        
        table.AddCell(ReaderHelper.NuevaCelda(SubTitulo, null, "N", null, FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.BOLD), 1, 1));
        table.AddCell(ReaderHelper.NuevaCelda("Hora:   " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL)));
        table.CompleteRow(); //Fila completada

        //Fila en blanco
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f)));
        table.AddCell(ReaderHelper.NuevaCelda("Pag.    " + writer.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.NORMAL)));
        table.CompleteRow(); //Fila completada

        #endregion

        #region Subtitulos

        table.AddCell(ReaderHelper.NuevaCelda("PERIODO:              " + Periodos, null, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), -1, -1, "S2", "N", 1.5f, 1.5f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RUC:                       " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), -1, -1, "S2", "N", 1.5f, 1.5f));
        table.CompleteRow(); //Fila completada

        table.AddCell(ReaderHelper.NuevaCelda("RAZON SOCIAL:   " + VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK), -1, -1, "S2", "N", 1.5f, 1.5f));
        table.CompleteRow(); //Fila completada

        //Espacio en blanco
        table.SpacingAfter = 10f;

        table.CompleteRow(); //Fila completada

        #endregion

        document.Add(table); //Añadiendo la tabla al documento PDF

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(3);
        TablaCabDetalle.WidthPercentage = 90;
        TablaCabDetalle.SetWidths(new float[] { 0.05f, 0.27f, 0.15f });

        #region Primera Linea

        //Columna 1
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PERIODO", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5f, 5f));

        //Columna 2
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("DESCRIPCION DE LA CUENTA", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5f, 5f));
      
        //Columna 3
        TablaCabDetalle.AddCell(ReaderHelper.NuevaCelda("PLAN CONTABLE", colCabDetalle, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 1, 1, "N", "N", 5f, 5f));
       
        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }
}