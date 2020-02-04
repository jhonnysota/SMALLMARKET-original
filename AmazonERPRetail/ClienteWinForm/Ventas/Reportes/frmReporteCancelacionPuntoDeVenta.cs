using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using ClienteWinForm;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Ventas.Reportes
{
    public partial class frmReporteCancelacionPuntoDeVenta : FrmMantenimientoBase
    {

        public frmReporteCancelacionPuntoDeVenta()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            ImagenRuta();
        }

        #region Variables

        //MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        VentasServiceAgent AgenteVenta { get { return new VentasServiceAgent(); } }
        List<CancPuntoDeVentaE> oPuntoDeVenta = null;
        String RutaGeneral;
        String RutaImagen = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        string tipo = "buscar";

        #endregion

        #region Procedimientos de Usuario

        void ConvertirApdf()
        {
            Document docPdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
            Guid Aleatorio = Guid.NewGuid();
            String NombreReporte = @"\Reporte de Ventas Diarias " + Aleatorio.ToString();
            String Extension = ".pdf";
            RutaGeneral = @"C:\AmazonErp\ArchivosTemporales";

            //Creando el directorio si existe...
            if (!Directory.Exists(RutaGeneral))
            {
                Directory.CreateDirectory(RutaGeneral);
            }

            docPdf.AddCreationDate();
            docPdf.AddAuthor("AMAZONTIC SAC");
            docPdf.AddCreator("AMAZONTIC SAC");

            if (!String.IsNullOrEmpty(RutaGeneral.Trim()))
            {
                //Para la creacion del archivo pdf
                RutaGeneral += NombreReporte + Extension;

                if (File.Exists(RutaGeneral))
                {
                    File.Delete(RutaGeneral);
                }

                FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                if (docPdf.IsOpen())
                {
                    docPdf.CloseDocument();
                }

                oPdfw.PageEvent = new PaginaInicialPuntoDeVenta
                {
                    Imagen = RutaImagen,
                    Fecha = dtpFecha.Value
                };

                docPdf.Open();

                #region Detalle

                PdfPTable TablaCabDetalle = new PdfPTable(15);
                TablaCabDetalle.WidthPercentage = 100;
                TablaCabDetalle.SetWidths(new float[] { 0.08f, 0.35f, 0.15f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f });
                Decimal TotalSoles = 0, TotalDolares= 0, TotalEfectivoSoles = 0,TotalEfectivoDolares = 0,TotalVisaSoles = 0,TotalVisaDolares = 0,TotalMastercardSoles = 0,TotalMastercardDolares = 0,TotalDinersSoles = 0,TotalDinersDolares = 0,TotalAmericanExpressSoles = 0,TotalAmericanExpressDolares = 0;
                List<CancPuntoDeVentaE> OpuntodeventaAgrupado = new List<CancPuntoDeVentaE>();

                for (int i = 0; i < oPuntoDeVenta.Count; i++)
                {
                    if (oPuntoDeVenta.Count> i+1)
                    {
                        if (oPuntoDeVenta[i].numDocumento == oPuntoDeVenta[i+1].numDocumento)
                        {
                            if (oPuntoDeVenta[i].MontoRecibido != oPuntoDeVenta[i+1].MontoRecibido)
                            {
                                if (oPuntoDeVenta[i].idMonedaRecibida == "01")
                                {
                                    if (oPuntoDeVenta[i].idMedioPago == 1)
                                    {
                                        oPuntoDeVenta[i].efecsoles += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 2)
                                    {
                                        oPuntoDeVenta[i].visasoles += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 3)
                                    {
                                        oPuntoDeVenta[i].mastersoles += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 4)
                                    {
                                        oPuntoDeVenta[i].dinersoles += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 5)
                                    {
                                        oPuntoDeVenta[i].americansoles += oPuntoDeVenta[i].MontoRecibido;
                                    }
                                }

                                if (oPuntoDeVenta[i].idMonedaRecibida == "02")
                                {
                                    if (oPuntoDeVenta[i].idMedioPago == 1)
                                    {
                                        oPuntoDeVenta[i].efecdolares += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 2)
                                    {
                                        oPuntoDeVenta[i].visadolares += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 3)
                                    {
                                        oPuntoDeVenta[i].masterdolares += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 4)
                                    {
                                        oPuntoDeVenta[i].dinerdolares += oPuntoDeVenta[i].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i].idMedioPago == 5)
                                    {
                                        oPuntoDeVenta[i].americandolares += oPuntoDeVenta[i].MontoRecibido;
                                    }
                                }

                                if (oPuntoDeVenta[i + 1].idMonedaRecibida == "01")
                                {
                                    if (oPuntoDeVenta[i + 1].idMedioPago == 1)
                                    {
                                        oPuntoDeVenta[i].efecsoles += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 2)
                                    {
                                        oPuntoDeVenta[i].visasoles += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 3)
                                    {
                                        oPuntoDeVenta[i].mastersoles += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 4)
                                    {
                                        oPuntoDeVenta[i].dinersoles += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 5)
                                    {
                                        oPuntoDeVenta[i].americansoles += oPuntoDeVenta[i+1].MontoRecibido;
                                    }
                                }

                                if (oPuntoDeVenta[i+1].idMonedaRecibida == "02")
                                {
                                    if (oPuntoDeVenta[i + 1].idMedioPago == 1)
                                    {
                                        oPuntoDeVenta[i].efecdolares += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 2)
                                    {
                                        oPuntoDeVenta[i].visadolares += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 3)
                                    {
                                        oPuntoDeVenta[i].masterdolares += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 4)
                                    {
                                        oPuntoDeVenta[i].dinerdolares += oPuntoDeVenta[i+1].MontoRecibido;
                                    }

                                    if (oPuntoDeVenta[i + 1].idMedioPago == 5)
                                    {
                                        oPuntoDeVenta[i].americandolares += oPuntoDeVenta[i+1].MontoRecibido;
                                    }
                                }

                                OpuntodeventaAgrupado.Add(oPuntoDeVenta[i]);
                                i++;
                            }
                        }
                        else
                        {
                            if (oPuntoDeVenta[i].idMonedaRecibida == "01")
                            {
                                if (oPuntoDeVenta[i].idMedioPago == 1)
                                {
                                    oPuntoDeVenta[i].efecsoles = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 2)
                                {
                                    oPuntoDeVenta[i].visasoles = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 3)
                                {
                                    oPuntoDeVenta[i].mastersoles = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 4)
                                {
                                    oPuntoDeVenta[i].dinersoles = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 5)
                                {
                                    oPuntoDeVenta[i].americansoles = oPuntoDeVenta[i].MontoRecibido;
                                }
                            }

                            if (oPuntoDeVenta[i].idMonedaRecibida == "02")
                            {
                                if (oPuntoDeVenta[i].idMedioPago == 1)
                                {
                                    oPuntoDeVenta[i].efecdolares = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 2)
                                {
                                    oPuntoDeVenta[i].visadolares = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 3)
                                {
                                    oPuntoDeVenta[i].masterdolares = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 4)
                                {
                                    oPuntoDeVenta[i].dinerdolares = oPuntoDeVenta[i].MontoRecibido;
                                }

                                if (oPuntoDeVenta[i].idMedioPago == 5)
                                {
                                    oPuntoDeVenta[i].americandolares = oPuntoDeVenta[i].MontoRecibido;
                                }
                            }

                            OpuntodeventaAgrupado.Add(oPuntoDeVenta[i]);
                        }
                    }
                    else
                    {
                        if (oPuntoDeVenta[i].idMonedaRecibida == "01")
                        {
                            if (oPuntoDeVenta[i].idMedioPago == 1)
                            {
                                oPuntoDeVenta[i].efecsoles = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 2)
                            {
                                oPuntoDeVenta[i].visasoles = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 3)
                            {
                                oPuntoDeVenta[i].mastersoles = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 4)
                            {
                                oPuntoDeVenta[i].dinersoles = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 5)
                            {
                                oPuntoDeVenta[i].americansoles = oPuntoDeVenta[i].MontoRecibido;
                            }
                        }

                        if (oPuntoDeVenta[i].idMonedaRecibida == "02")
                        {
                            if (oPuntoDeVenta[i].idMedioPago == 1)
                            {
                                oPuntoDeVenta[i].efecdolares = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 2)
                            {
                                oPuntoDeVenta[i].visadolares = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 3)
                            {
                                oPuntoDeVenta[i].masterdolares = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 4)
                            {
                                oPuntoDeVenta[i].dinerdolares = oPuntoDeVenta[i].MontoRecibido;
                            }

                            if (oPuntoDeVenta[i].idMedioPago == 5)
                            {
                                oPuntoDeVenta[i].americandolares = oPuntoDeVenta[i].MontoRecibido;
                            }
                        }

                        OpuntodeventaAgrupado.Add(oPuntoDeVenta[i]);
                    }            
                }

                PdfPCell cell;

                foreach (CancPuntoDeVentaE item in OpuntodeventaAgrupado)
                {
                    cell = new PdfPCell(new Paragraph(item.idPersona.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.RazonSocial, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.idDocumento + " " + item.numSerie + " " + item.numDocumento, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    TablaCabDetalle.AddCell(cell);

                    if (item.idMoneda == "01")
                    {
                        cell = new PdfPCell(new Paragraph(item.totTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        TotalSoles += item.totTotal;
                    }

                    if (item.idMoneda == "02")
                    {
                        cell = new PdfPCell(new Paragraph("0.00", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);

                        cell = new PdfPCell(new Paragraph(item.totTotal.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                        TablaCabDetalle.AddCell(cell);
                        TotalDolares += item.totTotal;
                    }

                    cell = new PdfPCell(new Paragraph(item.efecsoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.efecdolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.visasoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.visadolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.mastersoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.masterdolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.dinersoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.dinerdolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.americansoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    cell = new PdfPCell(new Paragraph(item.americandolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                    TablaCabDetalle.AddCell(cell);

                    TotalEfectivoSoles += item.efecsoles;
                    TotalEfectivoDolares += item.efecdolares;
                    TotalVisaSoles += item.visasoles;
                    TotalVisaDolares += item.visadolares;
                    TotalMastercardSoles += item.mastersoles;
                    TotalMastercardDolares += item.masterdolares;
                    TotalDinersSoles += item.dinersoles;
                    TotalDinersDolares += item.dinerdolares;
                    TotalAmericanExpressSoles += item.americansoles;
                    TotalAmericanExpressDolares += item.americandolares;

                    TablaCabDetalle.CompleteRow();
                }

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Totales : ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEfectivoSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalEfectivoDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalVisaSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(TotalVisaDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalMastercardSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalMastercardDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(TotalDinersSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalDinersDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalAmericanExpressSoles.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(TotalAmericanExpressDolares.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle.AddCell(cell);

                TablaCabDetalle.CompleteRow();

                docPdf.Add(TablaCabDetalle);

                PdfPTable TablaCabDetalle2 = new PdfPTable(8);
                TablaCabDetalle2.WidthPercentage = 100;
                TablaCabDetalle2.SetWidths(new float[] { 0.05f, 0.05f, 0.15f, 0.05f, 0.05f, 0.15f, 0.05f, 0.05f });

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("____________________", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER};
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("____________________", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                TablaCabDetalle2.CompleteRow();

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("ELABORADO", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);
                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("CAJERO", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                TablaCabDetalle2.AddCell(cell);

                TablaCabDetalle2.CompleteRow();

                docPdf.Add(TablaCabDetalle2);

                #endregion

                // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                //establecer la acción abierta para nuestro objeto escritor
                oPdfw.SetOpenAction(action);

                //Liberando memoria
                oPdfw.Flush();
                docPdf.Close();
                fsNuevoArchivo.Close();
            }
        }

        void ImagenRuta()
        {
            RutaImagen = VariablesLocales.ObtenerLogo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        void ExportarExcel(String Ruta)
        {

            //String TituloGeneral = String.Empty;
            //String NombrePestaña = String.Empty;
            //String nombreMes = cboMes.Text;



            //TituloGeneral = " Ajuste Diferencia De Cambio " + " Al Año " + Anio + " Del Mes " + nombreMes;
            //NombrePestaña = " Ajuste Diferencia De Cambio ";

            //if (File.Exists(Ruta)) File.Delete(Ruta);
            //FileInfo newFile = new FileInfo(Ruta);

            //using (ExcelPackage oExcel = new ExcelPackage(newFile))
            //{
            //    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

            //    if (oHoja != null)
            //    {
            //        Int32 InicioLinea = 4;
            //        Int32 TotColumnas = 10;

            //        #region Titulos Principales

            //        // Creando Encabezado;
            //        oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

            //        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
            //            Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
            //            Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
            //        }

            //        oHoja.Cells["A2"].Value = TituloGeneral;

            //        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
            //        {
            //            Rango.Merge = true;
            //            Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
            //            Rango.Style.Font.Color.SetColor(Color.Black);
            //            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            //            Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
            //        }

            //        #endregion

            //        #region Cabeceras del Detalle

            //        // PRIMERA
            //        oHoja.Cells[InicioLinea, 1].Value = " CUENTA ";
            //        oHoja.Cells[InicioLinea, 2].Value = " DESCRIPCION ";
            //        oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

            //        oHoja.Cells[InicioLinea, 3].Value = " HISTORICO S/. ";
            //        oHoja.Cells[InicioLinea, 4].Value = " AJUSTE S/. ";
            //        oHoja.Cells[InicioLinea, 5].Value = " SALDO S/. ";
            //        oHoja.Cells[InicioLinea, 6].Value = " SALDO US $ ";
            //        oHoja.Cells[InicioLinea, 7].Value = " DIFERENCIA ";
            //        oHoja.Cells[InicioLinea, 8].Value = " TC.VENTA ";
            //        oHoja.Cells[InicioLinea, 9].Value = " TC.COMPRA ";

            //        oHoja.Cells[InicioLinea, 10].Value = " TIPO AJUSTE ";
            //        oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;



            //        for (int i = 1; i <= 10; i++)
            //        {
            //            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
            //            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
            //            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
            //        }




            //        //Aumentando una Fila mas continuar con el detalle
            //        InicioLinea++;


            //        #endregion

            //        Decimal Dif, MontoSoles;
            //        String TipodeCambio;

            //        foreach (DifCambioE item in oDiferencia)
            //        {

            //            if (item.indCambio_X_Compra == "S")
            //            {
            //                MontoSoles = item.salActualSoles / oPeriodo.TCCompra;
            //                TipodeCambio = "Compra";
            //            }
            //            else
            //            {
            //                MontoSoles = item.salActualSoles / oPeriodo.TCVenta;
            //                TipodeCambio = "Venta";
            //            }

            //            Dif = item.salAactualDolares - MontoSoles;

            //            oHoja.Cells[InicioLinea, 1].Value = item.CodCuenta;
            //            oHoja.Cells[InicioLinea, 2].Value = item.Descripcion;
            //            oHoja.Cells[InicioLinea, 3].Value = item.Historico;
            //            oHoja.Cells[InicioLinea, 4].Value = item.Ajuste;
            //            oHoja.Cells[InicioLinea, 5].Value = item.salActualSoles;
            //            oHoja.Cells[InicioLinea, 6].Value = item.salAactualDolares;
            //            oHoja.Cells[InicioLinea, 7].Value = Dif;
            //            oHoja.Cells[InicioLinea, 8].Value = item.tipCambioVt;
            //            oHoja.Cells[InicioLinea, 9].Value = item.tipCambioCp;
            //            oHoja.Cells[InicioLinea, 10].Value = TipodeCambio + "" + item.desTipoAjuste;




            //            // FORMAT 


            //            oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "###,###,##0.00";

            //            oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "###,###,##0.00";

            //            oHoja.Cells[InicioLinea, 5].Style.Numberformat.Format = "###,###,##0.00";

            //            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";

            //            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";

            //            oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.000";

            //            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.000";

            //            oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";




            //            InicioLinea++;
            //        }






            //        //FIN SUMATORIA //


            //        //Linea
            //        Int32 totFilas = InicioLinea;
            //        oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

            //        //Suma
            //        InicioLinea++;

            //        //Ajustando el ancho de las columnas automaticamente
            //        oHoja.Cells.AutoFitColumns(0);

            //        //Insertando Encabezado
            //        oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
            //        //Pie de Pagina(Derecho) "Número de paginas y el total"
            //        oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            //        //Pie de Pagina(centro)
            //        oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

            //        //Otras Propiedades
            //        oHoja.Workbook.Properties.Title = TituloGeneral;
            //        oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
            //        oHoja.Workbook.Properties.Subject = "Reportes";
            //        //oHoja.Workbook.Properties.Keywords = "";
            //        oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
            //        oHoja.Workbook.Properties.Comments = NombrePestaña;

            //        // Establecer algunos valores de las propiedades extendidas
            //        oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

            //        //Propiedades para imprimir
            //        oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
            //        oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

            //        //Guardando el excel
            //        oExcel.Save();
            //    }
            //}
        }

        #endregion

        #region Procedimientos Heredados

        public override void Exportar()
        {
            try
            {
                //if (oDiferencia == null || oDiferencia.Count == Variables.Cero)
                //{
                //    Global.MensajeFault("No hay datos para exportar a Excel.");
                //    return;
                //}

                //String NombreLocal = cboSucursal.Text;
                //if (NombreLocal == "<<TODOS>>")
                //    NombreLocal = "-TODOS-";
                //else
                //    NombreLocal = "-" + cboSucursal.Text;

                //String Mes = cboMes.Text;

                //RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Ajuste Diferencia De Cambio" + NombreLocal + "-" + Mes, "Archivos Excel (*.xlsx)|*.xlsx");

                //if (!String.IsNullOrEmpty(RutaGeneral))
                //{
                //    tipo = "exportar";
                //    lblProcesando.Visible = true;
                //    btBuscar.Enabled = true;
                //    Marque = "Importando los registros a Excel...";
                //    pbProgress.Visible = true;
                //    Cursor = Cursors.WaitCursor;

                //    _bw.RunWorkerAsync();
                //}
                //else
                //{
                //    if (_bw.IsBusy)
                //    {
                //        _bw.CancelAsync();
                //    }
                //}
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
            if (tipo == "buscar")
            {
                DateTime Fecha = Convert.ToDateTime(dtpFecha.Value.Date);
                //Obteniendo los datos de la BD
                lblProcesando.Text = "Obteniendo el registro de ventas diarias...";
                oPuntoDeVenta = AgenteVenta.Proxy.ListarCancPuntoDeVenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Fecha, "01");

                lblProcesando.Text = "Armando el Reporte...";
                //Generando el PDF
                ConvertirApdf();
            }
            else
            {
                ExportarExcel(RutaGeneral);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btBuscar.Enabled = true;

            //Mostrando el reporte en un web browser
            if (tipo == "buscar")
            {
                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    wbNavegador.Navigate(RutaGeneral);
                    RutaGeneral = String.Empty;
                }
            }
            else
            {
                Global.MensajeComunicacion("Reporte de Ventas Diarias Exportado...");
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        #endregion

        #region Eventos

        private void frmReporteCancelacionPuntoDeVenta_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);

            //Ubicación del progressbar dentro del panel
            pbProgress.Left = (ClientSize.Width - pbProgress.Size.Width) / 2;
            pbProgress.Top = (ClientSize.Height - pbProgress.Height) / 3;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tipo = "buscar";
                pbProgress.Visible = true;
                lblProcesando.Visible = true;
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btBuscar.Enabled = false;
                Global.QuitarReferenciaWebBrowser(wbNavegador);
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                btBuscar.Enabled = true;
                Global.MensajeError(ex.Message);
            }
        }

        private void frmReporteCancelacionPuntoDeVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _bw.Dispose();
            }
        }

        private void lblProcesando_SizeChanged(object sender, EventArgs e)
        {
            lblProcesando.Left = (ClientSize.Width - lblProcesando.Size.Width) / 2;
            lblProcesando.Top = (ClientSize.Height - lblProcesando.Height) / 2;
        }

        #endregion

    }
}

#region Inicio Pdf

class PaginaInicialPuntoDeVenta : PdfPageEventHelper
{
    public String Imagen { get; set; }
    public DateTime Fecha { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        PdfPCell cell = null;
        PdfPTable table = new PdfPTable(3);

        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 0.2f, 0.7f, 0.35f });

        PdfPCell NuevaCeldaImagen;

        #region Titulos Principales

        if (!String.IsNullOrWhiteSpace(Imagen))
        {
            NuevaCeldaImagen = ReaderHelper.ImagenCell(Imagen, 85, 4, Variables.NO, 0); //Imagen de Ventura
            NuevaCeldaImagen.Rowspan = 3;
        }
        else
        {
            NuevaCeldaImagen = (ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 11.25f), 1, 1));
        }

        table.AddCell(NuevaCeldaImagen);

        table.AddCell(ReaderHelper.NuevaCelda("PLANILLA DE COBRANZA", null, "N", null, FontFactory.GetFont("Arial", 15.25f, iTextSharp.text.Font.BOLD)));
        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        table.AddCell(ReaderHelper.NuevaCelda("COMPROBANTE DE RETENCION", null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        table.CompleteRow();

        table.AddCell(ReaderHelper.NuevaCelda("R.U.C. N° " + VariablesLocales.SesionUsuario.Empresa.RUC, null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        table.AddCell(ReaderHelper.NuevaCelda("DE LA FECHA :" + Fecha.ToString("dd/mm/yyyy"), null, "N", null, FontFactory.GetFont("Arial", 7.25f, iTextSharp.text.Font.BOLD)));
        table.CompleteRow();

        document.Add(table);

        #endregion

        #region Cabecera del Detalle

        PdfPTable TablaCabDetalle = new PdfPTable(15);
        TablaCabDetalle.WidthPercentage = 100;
        TablaCabDetalle.SetWidths(new float[] { 0.08f, 0.35f, 0.15f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f, 0.09f });

        #region Primera Linea

        cell = new PdfPCell(new Paragraph("Num. Persona", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Cliente", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 3;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Efectivo", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Visa", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Mastercard", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Diners", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("American Express", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        cell.Colspan = 2;
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        #region Segunda Linea

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Documento", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Soles", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        cell = new PdfPCell(new Paragraph("Dolares", FontFactory.GetFont("Arial", 6f))) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        TablaCabDetalle.AddCell(cell);

        TablaCabDetalle.CompleteRow();

        #endregion

        document.Add(TablaCabDetalle); //Añadiendo la tabla al documento PDF

        #endregion

    }
}

#endregion

