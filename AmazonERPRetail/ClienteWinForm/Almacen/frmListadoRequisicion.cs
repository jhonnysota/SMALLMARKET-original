using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoRequisicion : FrmMantenimientoBase
    {

        #region Constructor

        public frmListadoRequisicion()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvRequisiciones, true);
            LlenarCombos();
            
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<RequisicionE> ListaRequisiciones = null;
        String RutaGeneral = String.Empty;
        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///Locales////
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();//AgenteMaestros.Proxy.ListarLocalPorEmpresa(VariablesLocales.SesionLocal.IdEmpresa, true, false);
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);
        }

        void Impresion(RequisicionE RequisicionImp_)
        {
            try
            {
                if (RequisicionImp_ != null)
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
                        PdfPCell cell = null;

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

                            oPdfw.ViewerPreferences = PdfWriter.PageLayoutSinglePage | PdfWriter.HideToolbar | PdfWriter.HideMenubar;

                            if (docPdf.IsOpen())
                            {
                                docPdf.CloseDocument();
                            }

                            int Columnas = 5;

                            float[] ArrayColumnas = new float[] { 0.04f, 0.08f, 0.04f, 0.03f, 0.09f };
                            String[] ArrayTitulos = new String[] { "Codigo", "Descripcion", "Cantidad", "Precio Unitario", "Especificacion de Compra" };
                            String Titulo = "Orden de Trabajo Interno";
                            String SubTitulo = "Decreto Supremo No.004-2006-TR";
                            String SubPeriodo = String.Empty;

                            int WidthPercentage = 100;

                            oPdfw.PageEvent = new PaginaRequisicionImprimir
                            {
                                Columnas = Columnas,
                                ArrayColumnas = ArrayColumnas,
                                ArrayTitulos = ArrayTitulos,
                                Titulo = Titulo,
                                SubTitulo = SubTitulo,
                                SubPeriodo = SubPeriodo,
                                oReq = RequisicionImp_,
                                WidthPercentage = WidthPercentage
                            }; ;

                            docPdf.Open();

                            #region Formatos

                            PdfPTable TablaCabDetalle = new PdfPTable(Columnas)
                            {
                                WidthPercentage = WidthPercentage
                            };

                            TablaCabDetalle.SetWidths(ArrayColumnas);

                            for (int i = 0; i < RequisicionImp_.ListaRequisicionItem.Count; i++)
                            {
                                cell = new PdfPCell(new Paragraph(RequisicionImp_.ListaRequisicionItem[i].idArticulo.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(RequisicionImp_.ListaRequisicionItem[i].DesArticulo.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(RequisicionImp_.ListaRequisicionItem[i].CantidadOrdenada.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(RequisicionImp_.ListaRequisicionItem[i].MontoEstimado.Value.ToString("N2"), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                                TablaCabDetalle.AddCell(cell);

                                cell = new PdfPCell(new Paragraph(RequisicionImp_.ListaRequisicionItem[i].Especificacion.ToString(), FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                TablaCabDetalle.AddCell(cell);

                                TablaCabDetalle.CompleteRow();
                            }

                            cell = new PdfPCell(new Paragraph("Justificacion :", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph(RequisicionImp_.Justificacion, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = 5;
                            TablaCabDetalle.AddCell(cell);
                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph("Observacion :", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph(RequisicionImp_.Observacion, FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            cell.Colspan = 5;
                            TablaCabDetalle.AddCell(cell);
                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("_________________", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            cell.Colspan = 2;
                            TablaCabDetalle.AddCell(cell);
                            TablaCabDetalle.CompleteRow();

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                            TablaCabDetalle.AddCell(cell);

                            cell = new PdfPCell(new Paragraph("Revisado Por:", FontFactory.GetFont("Arial", 5f))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                            cell.Colspan = 2;
                            TablaCabDetalle.AddCell(cell);
                            TablaCabDetalle.CompleteRow();

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
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRequisicion);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmRequisicion(Convert.ToInt32(cboSucursal.SelectedValue))
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
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
                if (bsRequisicion.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRequisicion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        //si la instancia existe la pongo en primer plano
                        oFrm.BringToFront();
                        return;
                    }

                    RequisicionE ERequisicion = (RequisicionE)bsRequisicion.Current;

                    if (ERequisicion != null)
                    {
                        ERequisicion.ListaRequisicionItem = AgenteAlmacen.Proxy.ListarRequisicionItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ERequisicion.idRequisicion);
                        ERequisicion.ListaRequisionProveedor = AgenteAlmacen.Proxy.ListarRequisicionProveedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,ERequisicion.idRequisicion);

                        oFrm = new frmRequisicion(ERequisicion)
                        {
                            MdiParent = MdiParent
                        };

                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show();
                    }
                }
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
                Int32 Local = Convert.ToInt32(cboSucursal.SelectedValue);
                DateTime fecIni = dtpInicio.Value.Date;
                DateTime fecFin = dtpFinal.Value.Date;

                bsRequisicion.DataSource = ListaRequisiciones = AgenteAlmacen.Proxy.ListarRequisicion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Local, fecIni, fecFin);
                bsRequisicion.ResetBindings(false);

                lblRegistros.Text = "Registros " + bsRequisicion.Count.ToString();
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
                if (bsRequisicion.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteAlmacen.Proxy.EliminarRequisicion(((RequisicionE)bsRequisicion.Current).idEmpresa, ((RequisicionE)bsRequisicion.Current).idRequisicion);
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

        public override void Imprimir()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRequisicionImprimir);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }
                
                RequisicionE RequisicionImp = (RequisicionE)bsRequisicion.Current;

                if (RequisicionImp != null)
                {
                    RequisicionImp.ListaRequisicionItem = AgenteAlmacen.Proxy.ListarRequisicionItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RequisicionImp.idRequisicion);
                    RequisicionImp.ListaRequisionProveedor = AgenteAlmacen.Proxy.ListarRequisicionProveedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RequisicionImp.idRequisicion);

                    oFrm = new frmRequisicionImprimir(ListaRequisiciones, RequisicionImp)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.Show(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmRequisicion oFrm = sender as frmRequisicion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoRequisicion_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvRequisiciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void tsmiMandarCorreo_Click(object sender, EventArgs e)
        {
            if (bsRequisicion.Count > Variables.Cero)
            {
                try
                {
                    RequisicionE RequisicionImp = (RequisicionE)bsRequisicion.Current;

                    RequisicionImp.ListaRequisicionItem = AgenteAlmacen.Proxy.ListarRequisicionItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RequisicionImp.idRequisicion);
                    RequisicionImp.ListaRequisionProveedor = AgenteAlmacen.Proxy.ListarRequisicionProveedor(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, RequisicionImp.idRequisicion);

                    if (RequisicionImp != null)
                    {
                        Impresion(RequisicionImp);

                        frmEnvioCorreos oFrm = new frmEnvioCorreos(RequisicionImp, RutaGeneral);
                        oFrm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Global.MensajeFault(ex.Message);
                }
            }
            else
            {
                Global.MensajeComunicacion("Seleccione un Registro");
            }
        }

        #endregion

    }
}
