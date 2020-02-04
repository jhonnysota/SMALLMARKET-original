using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Ventas.OT
{
    public partial class frmListadoOrdenTrabajoServicio : FrmMantenimientoBase
    {

        #region Contructor

        public frmListadoOrdenTrabajoServicio()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            FormatoGrid(dgvOrdenTrabajoServicio, true);
            LlenarCombos();
        }

        #endregion

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<OrdenTrabajoServicioE> ListaOrdenTrabajoServ = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        String RutaPdf = String.Empty;
        List<Area> ListaAreas = new List<Area>();
        List<Area> aretmp = new List<Area>();
        #endregion

        #region Procedimiento De Usuario

       void LlenarCombos()
        {
          
            ListaAreas = VariablesLocales.SesionUsuario.UsuarioAreas;
            aretmp = (from x in ListaAreas where x.idArea == 0 select x).ToList();
            if (aretmp.Count == 0)
            {
                Area oArea = new Area() { idArea = 0, descripcion = Variables.Todos };
                ListaAreas.Add(oArea);
            }          
            ComboHelper.RellenarCombos<Area>(cboAreas, (from x in ListaAreas orderby x.idArea select x).ToList(), "idArea", "descripcion", false);
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
              Int32 Area = Convert.ToInt32(cboAreas.SelectedValue);

               if (Area == 0)
                {
                    Global.MensajeFault("Debe Seleccionar una Area para Crear una OT");
                    return;
                }

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenTrabajoServicio);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmOrdenTrabajoServicio(Area);
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Buscar()
        {
            try
            {
                ListaOrdenTrabajoServ = null;
                Int32 Area = Convert.ToInt32(cboAreas.SelectedValue);

                bsOrdenTrabajoServicio.DataSource = ListaOrdenTrabajoServ = AgenteVentas.Proxy.ListarOrdenTrabajoServicio(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionArea.idLocal, Area);
                bsOrdenTrabajoServicio.ResetBindings(false);
                
                lblTitulo.Text = "Registros " + bsOrdenTrabajoServicio.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);

            }
        }

        public override void Editar()
        {
            try
            {
                if (bsOrdenTrabajoServicio.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenTrabajoServicio);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmOrdenTrabajoServicio(((OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current).idEmpresa, ((OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current).idLocal, ((OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current).idOT);
                    oFrm.MdiParent = MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                if (bsOrdenTrabajoServicio.List.Count > Variables.Cero)
                {

                    OrdenTrabajoServicioE EOrdenTrabajoServ = (OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current;

                    EOrdenTrabajoServ.ListaItemsOrdenTrabajo = AgenteVentas.Proxy.ListarOrdenTrabajoServicioItem(EOrdenTrabajoServ.idEmpresa, EOrdenTrabajoServ.idLocal, EOrdenTrabajoServ.idOT);

                    if (EOrdenTrabajoServ != null)
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

                        oFrm = new frmImpresionBase(EOrdenTrabajoServ, "Vista Previa de Bonificaciones");
                        oFrm.MdiParent = MdiParent;
                        oFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                OrdenTrabajoServicioE EOrdenTrabajoServ = (OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current;

                EOrdenTrabajoServ.ListaItemsOrdenTrabajo = AgenteVentas.Proxy.ListarOrdenTrabajoServicioItem(EOrdenTrabajoServ.idEmpresa, EOrdenTrabajoServ.idLocal, EOrdenTrabajoServ.idOT);

                if (EOrdenTrabajoServ == null || EOrdenTrabajoServ.ListaItemsOrdenTrabajo.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Orden Trabajo ", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Cursor = Cursors.WaitCursor;

                    _bw.RunWorkerAsync();
                }
                else
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                if (bsOrdenTrabajoServicio.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarOrdenTrabajoServicio(((OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current).idEmpresa, ((OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current).idLocal, ((OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current).idOT);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        base.Anular();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void CrearPdf(OrdenTrabajoServicioE oOrdenTrabajoServ)
        {
            String ConDetalle = Variables.NO;
            Document DocumentoPdf = null;

            if (oOrdenTrabajoServ.ListaItemsOrdenTrabajo.Count > 0)
            {
                ConDetalle = Variables.SI;
            }

            DocumentoPdf = new Document((ConDetalle == "S" ? PageSize.A4.Rotate() : PageSize.A4), 15f, 15f, 15f, 15f);

            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = "Orden de Trabajo " + Aleatorio.ToString();
            String Extension = ".pdf";
            String TituloCabecera = String.Empty;
            String FechaActual = VariablesLocales.FechaHoy.ToString("dd/MM/yyyy");
            String HoraActual = VariablesLocales.FechaHoy.ToString("hh:mm:ss tt");

            RutaPdf = @"C:\AmazonErp\ArchivosTemporales\";

            //Creando el directorio sino existe...
            if (!Directory.Exists(RutaPdf))
            {
                Directory.CreateDirectory(RutaPdf);
            }

            DocumentoPdf.AddAuthor("AMAZONTIC SAC");
            DocumentoPdf.AddCreator("AMAZONTIC SAC");
            DocumentoPdf.AddCreationDate();
            DocumentoPdf.AddTitle("Ventas");
            DocumentoPdf.AddSubject("Ordenes de Trabajo");

            if (!String.IsNullOrEmpty(RutaPdf.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaPdf += NombreReporte + Extension;

                if (File.Exists(RutaPdf))
                {
                    File.Delete(RutaPdf);
                }

                using (FileStream fsNuevoArchivo = new FileStream(RutaPdf, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    String TituloGeneral = String.Empty;

                    TituloGeneral = " ORDEN DE TRABAJO ";

                    BaseColor ColorFondo = new BaseColor(169, 208, 142); //Gris Claro
                    PdfWriter oPdfw = PdfWriter.GetInstance(DocumentoPdf, fsNuevoArchivo);
                    PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, DocumentoPdf.PageSize.Height, 1.00f);

                    oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                    oPdfw.ViewerPreferences = PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                    if (DocumentoPdf.IsOpen())
                    {
                        DocumentoPdf.CloseDocument();
                    }

                    DocumentoPdf.Open();

                    PdfContentByte cb = oPdfw.DirectContent;

                    //eje x, eje y, ancho, alto y radio(curvas)
                    if (ConDetalle == Variables.NO)
                    {
                        cb.RoundRectangle(12f, 748f, 570f, 41f, 10f);
                    }
                    else
                    {
                        cb.RoundRectangle(12f, 500f, 815f, 41f, 10f);
                    }

                    cb.SetLineWidth(0.5f);
                    cb.Stroke();

                    PdfPTable tableEncabezado = new PdfPTable(2);
                    tableEncabezado.WidthPercentage = 100;
                    tableEncabezado.SetWidths(new float[] { 0.9f, 0.13f });

                    #region Encabezado

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Pag. " + oPdfw.PageNumber, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow();

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Fecha: " + FechaActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow();

                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Dirección: " + VariablesLocales.SesionUsuario.Empresa.Direccion, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "N", "N", 1.2f, 1.2f));
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda("Hora: " + HoraActual, null, "N", null, FontFactory.GetFont("Arial", 6.25f, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY), -1, -1, "S2", "N", 1.2f, 1.2f));
                    tableEncabezado.CompleteRow();

                    //Filas en blanco
                    tableEncabezado.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 9.25f), -1, -1, "S4"));
                    tableEncabezado.CompleteRow();

                    DocumentoPdf.Add(tableEncabezado);

                    #endregion Encabezado

                    #region Titulos Principales

                    PdfPTable tableTitulos = new PdfPTable(4);
                    tableTitulos.WidthPercentage = 100;
                    tableTitulos.SetWidths(new float[] { 0.05f, 0.05f, 0.05f, 0.05f });

                    PdfPCell CeldaImagen = null;

                    if (File.Exists(RutaImagen))
                    {
                        CeldaImagen = new PdfPCell(ReaderHelper.ImagenCell(RutaImagen, 120f, 1, "N", 0, 8f));
                    }
                    else
                    {
                        CeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1));
                    }

                    tableTitulos.AddCell(CeldaImagen);
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(TituloGeneral, null, "S", null, FontFactory.GetFont("Arial", 13f, iTextSharp.text.Font.BOLD), 5, 1, "S2", "N", 14f, 14f, "N", "N"));
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda("Fecha Emisión:\n" + oOrdenTrabajoServ.FechaEmision.ToString("d"), null, "N", null, FontFactory.GetFont("Arial", 8.25f), 5, 1, "N", "N", 8f, 8f));
                    tableTitulos.CompleteRow();

                    //Lineas en Blanco
                    tableTitulos.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S4"));
                    tableTitulos.CompleteRow();

                    DocumentoPdf.Add(tableTitulos);



                    #endregion Titulos Principales

                    PdfPTable tableSub = new PdfPTable(6);
                    tableSub.WidthPercentage = 97;
                    tableSub.SetWidths(new float[] { 0.1f, 0.01f, 0.4f, 0.1f, 0.01f, 0.15f });

                    #region Subtitulos

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Proveedor", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("RUC", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Area", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.desArea, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Fecha Emisión", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda((oOrdenTrabajoServ.FechaEmision != null ? oOrdenTrabajoServ.FechaEmision.ToString("d") : " "), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Dirección", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.Direccion.ToString(), null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda("Estado", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.Estado, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda("Observaciones", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(": ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 0));
                    tableSub.AddCell(ReaderHelper.NuevaCelda(oOrdenTrabajoServ.Observacion, null, "N", null, FontFactory.GetFont("Arial", 7.25f), 5, 0, "S4"));
                    tableSub.CompleteRow();

                    tableSub.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 1, "S6"));
                    tableSub.CompleteRow();

                    DocumentoPdf.Add(tableSub); //Añadiendo la tabla al documento PDF

                    #endregion

                    PdfPTable TableDeta = new PdfPTable(12);
                    TableDeta.WidthPercentage = 100;
                    TableDeta.SetWidths(new float[] { 0.05f, 0.1f, 0.15f, 0.15f, 0.15f, 0.05f, 0.05f, 0.1f, 0.05f, 0.05f, 0.05f, 0.05f });

                    #region Detalle

                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Item", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Codigo", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Servicio", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Centro de Costos", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Descripción", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Fec. Entrega", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Cantidad", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Moneda", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Precio Unit. ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Valor Venta", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("IGV", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));
                    TableDeta.AddCell(ReaderHelper.NuevaCelda("Importe Total ", ColorFondo, "S", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), 5, 1, "N", "N", 4f, 4f));

                    TableDeta.CompleteRow();



                    foreach (OrdenTrabajoServicioItemE item in oOrdenTrabajoServ.ListaItemsOrdenTrabajo)
                    {
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Item, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.codArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desArticulo, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.desCostos, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Descripcion, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda((item.FechaEntrega != null ? item.FechaEntrega.Value.ToString("d") : " "), null, "S", null, FontFactory.GetFont("Arial", 6.25f)));


                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Cantidad.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Moneda, null, "S", null, FontFactory.GetFont("Arial", 6.25f)));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.PrecioUnitario.ToString("N6"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.ValorVenta.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Igv.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.AddCell(ReaderHelper.NuevaCelda(item.Total.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 6.25f), -1, 2));
                        TableDeta.CompleteRow();

                    }

                    //////Filas en blanco
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 3.25f), 5, 2, "S7"));
                    //TableDeta.CompleteRow();

                    ////****************************************************** Totales ******************************************************//
                    ////IGV
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda("I.G.V. " + VariablesLocales.oListaImpuestos[0].Porcentaje.ToString("N2"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(TotalIGV.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    //TableDeta.CompleteRow();

                    ////Total
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 6.25f), 5, 2, "S4"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda("TOTAL " + OrdenCompra.desMoneda, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD), -1, 2, "S2"));
                    //TableDeta.AddCell(ReaderHelper.NuevaCelda(OrdenCompra.impTotal.ToString("N2"), null, "S", null, FontFactory.GetFont("Arial", 7.25f), -1, 2));
                    //TableDeta.CompleteRow();

                    DocumentoPdf.Add(TableDeta); //Añadiendo la tabla al documento PDF

                    #endregion

                    //#endregion

                    // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                    PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                    //Establecer la acción abierta para nuestro objeto escritor
                    oPdfw.SetOpenAction(action);

                    //Liberando memoria
                    oPdfw.Flush();
                    DocumentoPdf.Close();
                }
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmOrdenTrabajoServicio oFrm = sender as frmOrdenTrabajoServicio;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            //ExportarExcel(RutaGeneral);
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Eventos

        private void frmListadoOrdenTrabajoServicio_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
            Buscar();
        }

        private void dgvOrdenTrabajoServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void chkAreas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAreas.Checked)
            {
                cboAreas.Enabled = false;
                cboAreas.SelectedValue = 0;
                Buscar();
            }
            else
            {
                cboAreas.Enabled = true;
                Buscar();
            }
        }

        private void cboAreas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        private void mandarPorCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                OrdenTrabajoServicioE EOrdenTrabajoServ = (OrdenTrabajoServicioE)bsOrdenTrabajoServicio.Current;

                EOrdenTrabajoServ.ListaItemsOrdenTrabajo = AgenteVentas.Proxy.ListarOrdenTrabajoServicioItem(EOrdenTrabajoServ.idEmpresa, EOrdenTrabajoServ.idLocal, EOrdenTrabajoServ.idOT);

                if (EOrdenTrabajoServ != null)
                {
                    CrearPdf(EOrdenTrabajoServ);
                    frmEnvioCorreos oFrm = new frmEnvioCorreos(EOrdenTrabajoServ, RutaPdf);
                    oFrm.ShowDialog();
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
