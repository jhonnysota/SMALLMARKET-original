﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Maestros.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Maestros   
{
    public partial class frmListadoDocumentos : FrmMantenimientoBase
    {

        public frmListadoDocumentos()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            
            FormatoGrid(dgvDocumentos, true);
            AnchoColumnas();    
             
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<DocumentosE> ListaDocumentos = null;

        Boolean OrdenarColumnas01 = false;
        Boolean OrdenarColumnas02 = false;

        #endregion
       
        #region ProcedimientosUsuario

        void AnchoColumnas()
        {
            dgvDocumentos.Columns[0].Width = 32;
            dgvDocumentos.Columns[1].Width = 200;
            dgvDocumentos.Columns[2].Width = 70;
            dgvDocumentos.Columns[3].Width = 25;
            dgvDocumentos.Columns[4].Width = 90;
            dgvDocumentos.Columns[5].Width = 120;
            dgvDocumentos.Columns[6].Width = 90;
            dgvDocumentos.Columns[7].Width = 120; 
        }

        void BuscarFiltro()
        {
            if (!chkIndBaja.Checked)
            {
                bsDocumentos.DataSource = (from x in ListaDocumentos
                                           where x.desDocumento.ToUpper().Contains(txtDocumento.Text.ToUpper())
                                           && x.indBaja == false
                                           select x).ToList(); 
            }
            else
            {
                bsDocumentos.DataSource = (from x in ListaDocumentos
                                           where x.desDocumento.ToUpper().Contains(txtDocumento.Text.ToUpper())
                                           select x).ToList(); 
            }

            lblTitulo.Text = "Registros " + bsDocumentos.Count.ToString();
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDocumentos);

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

                //sino existe la instancia se crea una nueva
                oFrm = new frmDocumentos
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
                if (bsDocumentos.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDocumentos);

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

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmDocumentos(((DocumentosE)bsDocumentos.Current).idDocumento)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
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
                ListaDocumentos = AgenteMaestro.Proxy.ListadoDeDocumentos(false, (chkIndBaja.Checked ? true : false));

                if (ListaDocumentos.Count > Variables.Cero)
                {
                    bsDocumentos.DataSource = ListaDocumentos;

                    if (!String.IsNullOrEmpty(txtDocumento.Text))
                    {
                        BuscarFiltro();
                    } 
                }
                
                base.Buscar();
                lblTitulo.Text = "Registros " + bsDocumentos.Count.ToString();
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
                if (bsDocumentos.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteMaestro.Proxy.AnularActivarDocumento(((DocumentosE)bsDocumentos.Current).idDocumento, true);
                        ((DocumentosE)bsDocumentos.Current).indBaja = true;
                        VariablesLocales.ListarDocumentoGeneral = (List<DocumentosE>)bsDocumentos.List;
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
                if (bsDocumentos.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteDocumentos);

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
                    List<DocumentosE> ListadDoc = new List<DocumentosE>();

                    ListadDoc = ListaDocumentos;
                    //sino existe la instancia se crea una nueva
                    oFrm = new frmReporteDocumentos(ListadDoc);
                    oFrm.MdiParent = this.MdiParent;
                    //oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Exportar()
        {
            try
            {
                if (ListaDocumentos.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Documentos", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Documentos");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 8;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(232, 113, 40));
                                }

                                oHoja.Cells["A2"].Value = " Documentos ";

                                using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(236, 149, 33));
                                }

                                #endregion

                                #region Cabeceras del Detalle

                                // PRIMERA
                                oHoja.Cells[InicioLinea, 1].Value = " Tipo Doc. ";
                                oHoja.Cells[InicioLinea, 2].Value = " Nombres ";
                                oHoja.Cells[InicioLinea, 3].Value = " Cod. Sunat ";
                                oHoja.Cells[InicioLinea, 4].Value = " I.B. ";
                                oHoja.Cells[InicioLinea, 5].Value = " Usuario Reg. ";
                                oHoja.Cells[InicioLinea, 6].Value = " Fecha Reg. ";
                                oHoja.Cells[InicioLinea, 7].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 8].Value = " Fecha Mod. ";



                                for (int i = 1; i <= 8; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                }

                                // Auto Filtro
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;



                                //Aumentando una Fila mas continuar con el detalle
                                InicioLinea++;

                                foreach (DocumentosE item in ListaDocumentos)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.idDocumento;
                                    oHoja.Cells[InicioLinea, 2].Value = item.desDocumento;
                                    oHoja.Cells[InicioLinea, 3].Value = item.CodigoSunat;
                                    oHoja.Cells[InicioLinea, 4].Value = item.indBaja;
                                    oHoja.Cells[InicioLinea, 5].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 6].Value = item.FechaRegistro.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 7].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 8].Value = item.FechaModificacion.Value.ToString("d");
                                    oHoja.Cells[InicioLinea, 1, InicioLinea,8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    InicioLinea++;
                                }

                                #endregion

                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells.AutoFitColumns(0);

                                //Insertando Encabezado
                                //oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                                //Pie de Pagina(Derecho) "Número de paginas y el total"
                                oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                //Pie de Pagina(centro)
                                oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                                //Otras Propiedades
                                //oHoja.Workbook.Properties.Title = TituloGeneral;
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Modulo de Ventas";
                                //oHoja.Workbook.Properties.Comments = NombrePestaña;

                                // Establecer algunos valores de las propiedades extendidas
                                oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                                //Propiedades para imprimir
                                oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                                oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                                //Guardando el excel
                                oExcel.Save();
                            }
                        }
                    }
                }
                else
                {
                    Global.MensajeFault("No hay datos para la exportación...");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmDocumentos oFrm = sender as frmDocumentos;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion
        
        #region Eventos

        private void frmListadoDocumentos_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvDocumentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvDocumentos.Rows[e.RowIndex].Cells["indBaja"].Value)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        private void dgvDocumentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ListaDocumentos != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // COLUMNA
                    if (e.ColumnIndex == dgvDocumentos.Columns["idDocumentoDataGridViewTextBoxColumn"].Index)
                    {
                        if (OrdenarColumnas01)
                        {
                            bsDocumentos.DataSource = (from x in ListaDocumentos orderby x.idDocumento ascending select x).ToList();
                            OrdenarColumnas01 = false;
                        }
                        else
                        {
                            bsDocumentos.DataSource = (from x in ListaDocumentos orderby x.idDocumento descending select x).ToList();
                            OrdenarColumnas01 = true;
                        }
                    }
                    // COLUMNA
                    if (e.ColumnIndex == dgvDocumentos.Columns["desDocumento"].Index)
                    {
                        if (OrdenarColumnas02)
                        {
                            bsDocumentos.DataSource = (from x in ListaDocumentos orderby x.desDocumento ascending select x).ToList();
                            OrdenarColumnas02 = false;
                        }
                        else
                        {
                            bsDocumentos.DataSource = (from x in ListaDocumentos orderby x.desDocumento descending select x).ToList();
                            OrdenarColumnas02 = true;
                        }
                    }
                }
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (ListaDocumentos != null && ListaDocumentos.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        private void chkIndBaja_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

    }
}
