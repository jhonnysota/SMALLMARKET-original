//using Negocio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Winform;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
using ClienteWinForm;
using Entidades.Maestros;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Maestros.Reportes
{
    public partial class frmImpresionTrabajador : FrmMantenimientoBase
    {
        public frmImpresionTrabajador()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //Nuevo ubicación del reporte y nuevo tamaño de acuerdo al tamaño del menu
            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
        }



        public frmImpresionTrabajador(TrabajadorE oTrab_)
            : this()
        {
            oTrab = oTrab_;
        }

        String RutaGeneral;
        TrabajadorE oTrab;
        String RutaTemp = String.Empty;
        EmpresaImagenesE oEmpresaImagen = null;
        EmpresaImagenesE oEmpresaImagen2 = null;
        String RutaImagen = @"C:\AmazonErp\Logo\";
        String RutaImagen2 = @"C:\AmazonErp\Logo\";
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }

        private void frmRequisicionImprimir_Load(object sender, EventArgs e)
        {
            try
            {
                if (oTrab != null)
                {
                    Document docPdf = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    String NombreReporte = @"\" + "_" + VariablesLocales.FechaHoy.Year.ToString() + "_" + VariablesLocales.FechaHoy.Month.ToString() + "_" + VariablesLocales.FechaHoy.Day.ToString() + "_" + VariablesLocales.FechaHoy.Hour.ToString() + "_" + VariablesLocales.FechaHoy.Minute.ToString();
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
                        String TituloGeneral = String.Empty;
                        //String SubTitulo = String.Empty;
                        PdfPCell cell = null;

                        //Para la creacion del archivo pdf
                        RutaGeneral += NombreReporte + Extension;

                        if (File.Exists(RutaGeneral))
                        {
                            File.Delete(RutaGeneral);
                        }

                        FileStream fsNuevoArchivo = new FileStream(RutaGeneral, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        PdfWriter oPdfw = PdfWriter.GetInstance(docPdf, fsNuevoArchivo);
                        PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, docPdf.PageSize.Height, 1.00f);

                        oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
                        oPdfw.ViewerPreferences = PdfWriter.HideToolbar;
                        oPdfw.ViewerPreferences = PdfWriter.HideMenubar;

                        if (docPdf.IsOpen())
                        {
                            docPdf.CloseDocument();
                        }

                        oEmpresaImagen = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                        oEmpresaImagen2 = AgenteMaestros.Proxy.ObtenerEmpresaSinImagenes(1, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                        if (!Directory.Exists(RutaImagen))
                        {
                            Directory.CreateDirectory(RutaImagen);
                        }

                        if (oEmpresaImagen != null)
                        {
                            RutaImagen += oEmpresaImagen.Nombre + oEmpresaImagen.Extension;
                            RutaImagen2 += oEmpresaImagen2.Nombre + oEmpresaImagen2.Extension;
                            if (!File.Exists(RutaImagen))
                            {
                                oEmpresaImagen = AgenteMaestros.Proxy.ObtenerEmpresaConImagenes(2, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                if (oEmpresaImagen.Imagen != null)
                                {
                                    Global.EscribirImagenEnFile(oEmpresaImagen.Imagen, RutaImagen);
                                }
                                else
                                {
                                    RutaImagen = String.Empty;
                                }
                            }

                            if (!File.Exists(RutaImagen2))
                            {
                                oEmpresaImagen2 = AgenteMaestros.Proxy.ObtenerEmpresaConImagenes(1, VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

                                if (oEmpresaImagen2.Imagen != null)
                                {
                                    Global.EscribirImagenEnFile(oEmpresaImagen2.Imagen, RutaImagen2);
                                }
                                else
                                {
                                    RutaImagen2 = String.Empty;
                                }
                            }
                        }







                        docPdf.Open();




                        #region Formatos

                        int size = 8;
                        int WidthPercentage = 100;
                        int Columnas = 7;
                        PdfPTable table = new PdfPTable(Columnas);

                        table.WidthPercentage = WidthPercentage;
                        table.SetWidths(new float[] { 0.1f, 0.35f,0.05f, 0.25f, 0.05f, 0.15f, 0.1f });
                        table.HorizontalAlignment = Element.ALIGN_CENTER;

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();

                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        cell = CellPdf(" ", size, false, "", "");
                        table.AddCell(cell);
                        table.CompleteRow();


                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda("FICHA SOCIAL", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD),1,1));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda("Fecha de Ingreso", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD),1,1));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.CompleteRow();

                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        //table.AddCell(ReaderHelper.NuevaCelda(oTrab.Estado.FechaIngreso.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD),1 ,1));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.CompleteRow();

                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.CompleteRow();

                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda("Empresa", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f),1,1));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.CompleteRow();

                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.ImagenCell(RutaImagen, 80, Element.ALIGN_CENTER, Variables.SI, 1));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        if (oTrab.RutaImagen == null)
                        {
                            table.AddCell(ReaderHelper.NuevaCelda(" ", null,"S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        }
                        else
                        {
                            table.AddCell(ReaderHelper.ImagenCell(oTrab.RutaImagen, 80, Element.ALIGN_CENTER, Variables.SI, 1));
                        }
        
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(VariablesLocales.SesionUsuario.Empresa.RazonSocial, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD),1,1));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.CompleteRow();

                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda("1.- DATOS DEL COLABORADOR", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table.CompleteRow();

                        docPdf.Add(table);

                        Columnas = 5;
                        PdfPTable table2 = new PdfPTable(Columnas);

                        table2.WidthPercentage = WidthPercentage;
                        table2.SetWidths(new float[] { 0.1f, 0.25f, 0.25f, 0.3f, 0.1f });
                        table2.HorizontalAlignment = Element.ALIGN_CENTER;

                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.AddCell(ReaderHelper.NuevaCelda("Apellido Paterno", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table2.AddCell(ReaderHelper.NuevaCelda("Apellido Materno", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table2.AddCell(ReaderHelper.NuevaCelda("Nombres", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.CompleteRow();

                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.AddCell(ReaderHelper.NuevaCelda(oTrab.ApePaterno, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table2.AddCell(ReaderHelper.NuevaCelda(oTrab.ApeMaterno, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table2.AddCell(ReaderHelper.NuevaCelda(oTrab.Nombres, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.CompleteRow();

                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table2.CompleteRow();

                        docPdf.Add(table2);

                        Columnas = 7;
                        PdfPTable table3 = new PdfPTable(Columnas);

                        table3.WidthPercentage = WidthPercentage;
                        table3.SetWidths(new float[] { 0.1f, 0.15f, 0.15f, 0.15f, 0.15f, 0.2f, 0.1f });
                        table3.HorizontalAlignment = Element.ALIGN_CENTER;

                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda("DNI", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda("Fecha de Nacimiento", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda("Sexo", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda("Estado Civil", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda("Celular/Telefono", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.CompleteRow();

                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(oTrab.NroDocumento, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda(oTrab.FechaNacimiento.ToString("d"), null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda(oTrab.Genero, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        //table3.AddCell(ReaderHelper.NuevaCelda(oTrab.Estado.EstadoCivil.ToString(), null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f, iTextSharp.text.Font.BOLD), 1, 1));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.CompleteRow();

                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table3.CompleteRow();

                        docPdf.Add(table3);

                        Columnas = 5;
                        PdfPTable table4 = new PdfPTable(Columnas);

                        table4.WidthPercentage = WidthPercentage;
                        table4.SetWidths(new float[] { 0.1f, 0.4f,0.25f,0.15f, 0.1f });
                        table4.HorizontalAlignment = Element.ALIGN_CENTER;

                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.AddCell(ReaderHelper.NuevaCelda("Correo Electrónico", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table4.AddCell(ReaderHelper.NuevaCelda("Tipo de vehículo en el que se moviliza", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table4.AddCell(ReaderHelper.NuevaCelda("N° Licencia de Conducir", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.CompleteRow();

                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table4.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table4.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.CompleteRow();

                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table4.CompleteRow();

                        docPdf.Add(table4);


                        Columnas = 7;
                        PdfPTable table5 = new PdfPTable(Columnas);

                        table5.WidthPercentage = WidthPercentage;
                        table5.SetWidths(new float[] { 0.1f, 0.15f, 0.1f, 0.2f,0.2f,0.15f, 0.1f });
                        table5.HorizontalAlignment = Element.ALIGN_CENTER;

                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda("Grupo Sanguíneo", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda("Estatura", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda("Medida Superior", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda("Medida Inferior", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda("Talla de Calzado", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.CompleteRow();

                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.CompleteRow();

                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table5.CompleteRow();

                        docPdf.Add(table5);


                        Columnas = 6;
                        PdfPTable table6 = new PdfPTable(Columnas);

                        table6.WidthPercentage = WidthPercentage;
                        table6.SetWidths(new float[] { 0.1f, 0.15f, 0.25f, 0.25f, 0.15f, 0.1f });
                        table6.HorizontalAlignment = Element.ALIGN_CENTER;

                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda("¿Esta Afiliado a la AFP?", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda("Nombre de la AFP / ONP", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda("Tipo de Comisión", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda("CUSSP", BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.CompleteRow();

                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        //table6.AddCell(ReaderHelper.NuevaCelda(oTrab.Estado.Cuspp, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.CompleteRow();

                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table6.CompleteRow();

                        docPdf.Add(table6);

                        Columnas = 3;
                        PdfPTable table7 = new PdfPTable(Columnas);

                        table7.WidthPercentage = WidthPercentage;
                        table7.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
                        table7.HorizontalAlignment = Element.ALIGN_CENTER;

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda("Dirección según DNI", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        docPdf.Add(table7);


                        Columnas = 5;
                        PdfPTable table8 = new PdfPTable(Columnas);

                        table8.WidthPercentage = WidthPercentage;
                        table8.SetWidths(new float[] { 0.1f, 0.3f,0.2f,0.3f, 0.1f });
                        table8.HorizontalAlignment = Element.ALIGN_CENTER;

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda("Distrito", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda("Provincia", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda("Departamento", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        docPdf.Add(table8);


                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda("Dirección Actual", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda("Referencia de como llegar al domicilio actual", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda("Dibujar Plano de Ubicación Domiciliaria Actual", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();

                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table7.CompleteRow();


                        docPdf.Add(table7);


                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda("Grado de Instrucción", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda("Especialidad", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda("Grado Obtenido", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda("2.- Datos Laborales", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();


                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda("Cargo", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda("Área", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda("Sede Productiva", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();


                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda("Experiencia Laboral", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table8.CompleteRow();

                        docPdf.Add(table8);


                        Columnas = 8;
                        PdfPTable table9 = new PdfPTable(Columnas);

                        table9.WidthPercentage = WidthPercentage;
                        table9.SetWidths(new float[] { 0.1f, 0.2f,0.2f,0.1f,0.05f,0.05f,0.2f, 0.1f });
                        table9.HorizontalAlignment = Element.ALIGN_CENTER;

                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda("Empresa", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda("Cargo", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda("Área", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda("Desde", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda("Hasta", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda("Motivo Cese", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.CompleteRow();

                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.CompleteRow();

                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.CompleteRow();

                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda("3.- DATOS DE LOS FAMILIARES", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table9.CompleteRow();

                        docPdf.Add(table9);

                        Columnas = 7;
                        PdfPTable table10 = new PdfPTable(Columnas);

                        table10.WidthPercentage = WidthPercentage;
                        table10.SetWidths(new float[] { 0.1f, 0.25f, 0.1f, 0.05f, 0.2f,0.2f, 0.1f });
                        table10.HorizontalAlignment = Element.ALIGN_CENTER;

                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda("Apellidos y Nombres", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda("Parentesco", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda("Edad", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda("Grado de Instrucción", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda("Ocupación", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.CompleteRow();

                        //FOREACH

                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.CompleteRow();


                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.CompleteRow();

                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda("En caso de emergencia comunicarse con:", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table10.CompleteRow();


                        docPdf.Add(table10);


                        Columnas = 5;
                        PdfPTable table11 = new PdfPTable(Columnas);

                        table11.WidthPercentage = WidthPercentage;
                        table11.SetWidths(new float[] { 0.1f, 0.35f, 0.1f, 0.35f, 0.1f });
                        table11.HorizontalAlignment = Element.ALIGN_CENTER;

                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda("Apellidos y Nombres", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table11.AddCell(ReaderHelper.NuevaCelda("Celular/Teléfono", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table11.AddCell(ReaderHelper.NuevaCelda("Dirección", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.CompleteRow();

                        //foreach

                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table11.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table11.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.CompleteRow();

                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.CompleteRow();

                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda("4.- DATOS DE LA VIVINEDA", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table11.CompleteRow();

                        docPdf.Add(table11);

                        Columnas = 3;
                        PdfPTable table12 = new PdfPTable(Columnas);

                        table12.WidthPercentage = WidthPercentage;
                        table12.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
                        table12.HorizontalAlignment = Element.ALIGN_CENTER;

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("Responder las siguientes preguntas", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(oTrab.Persona.Telefonos, null, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("5.SALUD", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("¿Ud. padece de alguna enfermedad/alergia que implique ser conocida para recibir atención médica oprtuna?   SI( ) NO( )", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("Detallar:", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("Otros:", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("¿Es Ud. Alérgico a la picadura de algún insecto?                                                           SI( ) NO( )", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("Detallar:", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("Otros:", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("¿Si Ud. es del sexo masculino, responda a la siguiente pregunta:¿Su esposa/conviviente se encuentra gestando? SI( ) NO( )", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("¿Cuántos meses?:", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();

                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda("6.-ACTIVIDADES,ARTISTICAS,RECREATIVAS Y DEPORTIVAS", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table12.CompleteRow();



                        docPdf.Add(table12);



                        Columnas = 5;
                        PdfPTable table13 = new PdfPTable(Columnas);

                        table13.WidthPercentage = WidthPercentage;
                        table13.SetWidths(new float[] { 0.1f, 0.27f,0.26f,0.27f, 0.1f });
                        table13.HorizontalAlignment = Element.ALIGN_CENTER;


                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda("Artisticas", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table13.AddCell(ReaderHelper.NuevaCelda("Recreativas", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table13.AddCell(ReaderHelper.NuevaCelda("Deportivas", iTextSharp.text.BaseColor.GREEN, "S", null, FontFactory.GetFont("Arial", 5f), 1, 1));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.CompleteRow();

                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 5f)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.CompleteRow();

                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.CompleteRow();

                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table13.CompleteRow();



                        docPdf.Add(table13);


                        Columnas = 3;
                        PdfPTable table14 = new PdfPTable(Columnas);

                        table14.WidthPercentage = WidthPercentage;
                        table14.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
                        table14.HorizontalAlignment = Element.ALIGN_CENTER;

                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda("Declaro bajo juramento que todos los datos consignados del presente formulario son veraces, autorizando a la ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.CompleteRow();


                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda("Empresa en la que laboro a efectuar las verificaciones que juzgue necesarias y asumiendo la responsabilidad en caso ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.CompleteRow();

                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda("sean falsos.Así mismo, me comprometo a presentar los documentos que me soliciten. ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.CompleteRow();

                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table14.CompleteRow();

                        docPdf.Add(table14);

                        Columnas = 7;
                        PdfPTable table15 = new PdfPTable(Columnas);

                        table15.WidthPercentage = WidthPercentage;
                        table15.SetWidths(new float[] { 0.1f,0.05f ,0.25f,0.2f,0.25f,0.05f, 0.1f });
                        table15.HorizontalAlignment = Element.ALIGN_CENTER;

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD),-1,-1,"N","N",2,2,"S","N"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "N", "S", "S"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "N", "S", "S"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "N", "S", "S"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "N", "S", "S"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "S","N","N"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "S", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), -1, -1, "N", "N", 2, 2, "N", "S"));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda("Firma del Colaborador", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 1, 1));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda("Huella Digital", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD), 1, 1));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.AddCell(ReaderHelper.NuevaCelda(" ", null, "N", null, FontFactory.GetFont("Arial", 7f, iTextSharp.text.Font.BOLD)));
                        table15.CompleteRow();

                        docPdf.Add(table15);
                        #endregion

                        // crear una nueva acción para enviar el documento a nuestro nuevo destino.
                        PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, oPdfw);

                        //establecer la acción abierta para nuestro objeto escritor
                        oPdfw.SetOpenAction(action);

                        //Liberando memoria
                        oPdfw.Flush();
                        docPdf.Close();
                        fsNuevoArchivo.Close();

                        if (!String.IsNullOrEmpty(RutaGeneral))
                        {
                            wbNavegador.Navigate(RutaGeneral);
                            RutaGeneral = String.Empty;
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }



        }

        PdfPCell CellPdf(string titulo, int size, Boolean border, string align, string bold)
        {
            if (!border)
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { Border = 0, HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
            else
                return new PdfPCell(new Paragraph(titulo, FontFactory.GetFont("Arial", size, (bold == "bold" ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL),
                                    iTextSharp.text.BaseColor.BLACK)))
                { HorizontalAlignment = (align == "c" ? Element.ALIGN_CENTER : (align == "r" ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT)), VerticalAlignment = Element.ALIGN_MIDDLE };
        }
    }
}

