using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Maestros.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmListadoMovilidad : FrmMantenimientoBase
    {

        public frmListadoMovilidad()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvMovilidad, true);
            
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtaPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        List<MovilidadE> ListaMovilidad = null;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String RutaGeneral = String.Empty;
        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovilidad);

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
                oFrm = new frmMovilidad()
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

        public override void Buscar()
        {
            try
            {
                bsMovilidad.DataSource = ListaMovilidad = AgenteCtaPorPagar.Proxy.ListarMovilidad(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                bsMovilidad.ResetBindings(false);

                base.Buscar();
                lblTitulo.Text = String.Format("Registros {0}", ListaMovilidad.Count.ToString());
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
                if (bsMovilidad.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMovilidad);

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
                    oFrm = new frmMovilidad(((MovilidadE)bsMovilidad.Current).idEmpresa, ((MovilidadE)bsMovilidad.Current).idLocal, ((MovilidadE)bsMovilidad.Current).idMovilidad)
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

        public override void Anular()
        {
            try
            {
                if (bsMovilidad.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteCtaPorPagar.Proxy.EliminarMovilidad(((MovilidadE)bsMovilidad.Current).idMovilidad);
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
                if (bsMovilidad.Count > 0)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteMovilidadesDetalle);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    MovilidadE MoviImp = AgenteCtaPorPagar.Proxy.ObtenerMovilidadCompleta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, ((MovilidadE)bsMovilidad.Current).idMovilidad);

                    oFrm = new frmReporteMovilidadesDetalle(MoviImp)
                    {
                        MdiParent = this.MdiParent
                    };

                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #region FormatoExcel

        public override void Exportar()
        {
            try
            {
                MovilidadE MoviImp = AgenteCtaPorPagar.Proxy.ObtenerMovilidadCompleta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, ((MovilidadE)bsMovilidad.Current).idMovilidad);

                if (MoviImp.ListaMovilidadDet == null || MoviImp.ListaMovilidadDet.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento(" Guardar en ", " Movilidades ", "Archivos Excel (*.xlsx)|*.xlsx");
                ExportarExcel(RutaGeneral, MoviImp);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        void ExportarExcel(String Ruta, MovilidadE MoviImp)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "PLANILLA DE MOVILIDAD";
            NombrePestaña = " MOVILIDAD CAB/DETALLE";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

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
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(105, 171, 169));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(64, 166, 212));
                    }

                    #endregion

                    oHoja.Cells[InicioLinea, 1].Value = " RUC :";
                    oHoja.Cells[InicioLinea, 2].Value = MoviImp.RUC;
                    oHoja.Cells[InicioLinea, 3].Value = " Razon Social :";
                    oHoja.Cells[InicioLinea, 4].Value = MoviImp.RazonSocial;

                    InicioLinea++;

                    oHoja.Cells[InicioLinea, 1].Value = " Fecha :";
                    oHoja.Cells[InicioLinea, 2].Value = MoviImp.Fecha;
                    oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                    oHoja.Cells[InicioLinea, 3].Value = " Serie :";
                    oHoja.Cells[InicioLinea, 4].Value = MoviImp.Serie;
                    oHoja.Cells[InicioLinea, 5].Value = " Numero :";
                    oHoja.Cells[InicioLinea, 6].Value = MoviImp.Numero;

                    InicioLinea++;
                    InicioLinea++;

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = " Nro.";
                    oHoja.Cells[InicioLinea, 2].Value = " Fecha";
                    oHoja.Cells[InicioLinea, 3].Value = " Empleado";
                    oHoja.Cells[InicioLinea, 4].Value = " DNI";
                    oHoja.Cells[InicioLinea, 5].Value = " Area ";
                    oHoja.Cells[InicioLinea, 6].Value = " Desplazamiento ";
                    oHoja.Cells[InicioLinea, 7].Value = " Descripción  ";
                    oHoja.Cells[InicioLinea, 8].Value = " Monto ";

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

                    #endregion

                    #region Formato Excel

                    Int32 ItemCorre = 1;
                    Decimal totSoles = 0;

                    foreach (MovilidadDetE item in MoviImp.ListaMovilidadDet)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = ItemCorre.ToString("00");
                        oHoja.Cells[InicioLinea, 2].Value = item.Fecha;
                        oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 4].Value = item.RUC;
                        oHoja.Cells[InicioLinea, 5].Value = item.desCCostos;
                        oHoja.Cells[InicioLinea, 6].Value = item.Desplazamiento;
                        oHoja.Cells[InicioLinea, 7].Value = item.MotivoDestino;
                        oHoja.Cells[InicioLinea, 8].Value = item.Monto;

                        oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                        ItemCorre++;
                        totSoles += item.Monto;
                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea, 7].Value = "Totales(S /.)";
                    oHoja.Cells[InicioLinea, 8].Value = totSoles;
                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";
                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                    //Guardando el excel
                    oExcel.Save();
                    Global.MensajeComunicacion("Exportacion Guardada");

                    #endregion

                }
            }
        }

        #endregion

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmMovilidad oFrm = sender as frmMovilidad;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoMovilidad_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);

        }

        private void dgvMovilidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvMovilidad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvMovilidad.Rows[e.RowIndex].Cells["indEstado"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorCerrado;
                    }
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
