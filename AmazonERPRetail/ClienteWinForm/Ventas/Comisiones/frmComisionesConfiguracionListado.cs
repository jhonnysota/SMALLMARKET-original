using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using ClienteWinForm.Ventas.Reportes;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas.Comisiones
{
    public partial class frmComisionesConfiguracionListado : FrmMantenimientoBase
    {
        #region Constructor

        public frmComisionesConfiguracionListado()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, true);
            LlenarCombos();
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<ComisionesConfiguracionE> oListaVendedor;

        ComisionesConfiguracionE oEntidad;
        List<ComisionesConfiguracionE> oListaLineaGeneral = new List<ComisionesConfiguracionE>();
        List<ComisionesConfiguracionE> oListaTarifarioGeneral = new List<ComisionesConfiguracionE>();
        int idCategoriaSeleccionada;

        int idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //////Periodo/////////
            List<PeriodoComisionE> ListaComision = AgenteVentas.Proxy.ListarPeriodoComision(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos<PeriodoComisionE>(cboPeriodo, (from x in ListaComision orderby x.Anio descending ,x.Mes descending select x).ToList(), "idPeriodo", "Nombre", false);
        }

        #endregion

        #region Procedimientos Heredado

        public override void Buscar()
        {
            try
            {
                Int32 idPeriodo = Convert.ToInt32(cboPeriodo.SelectedValue);

                oListaVendedor = AgenteVentas.Proxy.ListarComisionesConfiguracionPeriodo(idEmpresa, idPeriodo, "");

                bsComisionesConfiguracion.DataSource = oListaVendedor;
                bsComisionesConfiguracion.ResetBindings(false);
                base.Buscar();
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComisionesConfiguracion);

                if (bsComisionesConfiguracion.Count > Variables.Cero)
                {
                    if (oFrm != null)
                    {
                        oFrm.BringToFront();
                        return;
                    }

                    ComisionesConfiguracionE oSeleccionado = (ComisionesConfiguracionE)bsComisionesConfiguracion.Current;

                    oFrm = new frmComisionesConfiguracion(oSeleccionado);
                    oFrm.MdiParent = this.MdiParent;
                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            //base.Editar();
        }

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComisionesConfiguracion);

                
                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmComisionesConfiguracion(new ComisionesConfiguracionE() { idEmpresa=idEmpresa,idComision=0});
                oFrm.MdiParent = this.MdiParent;
                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();

                
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
            //base.Editar();
        }

        public override void Anular()
        {
            try
            {
                if (bsComisionesConfiguracion.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarComisionesConfiguracion(((ComisionesConfiguracionE)bsComisionesConfiguracion.Current).idEmpresa,((ComisionesConfiguracionE)bsComisionesConfiguracion.Current).idComision);
                        Buscar();
                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                        //base.Anular();
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
                if (bsComisionesConfiguracion.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComisionesConfiguracionImprimir);

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
                    oFrm = new frmComisionesConfiguracionImprimir(((ComisionesConfiguracionE)bsComisionesConfiguracion.Current));
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
                oEntidad = ((ComisionesConfiguracionE)bsComisionesConfiguracion.Current);
                
                oEntidad.oListaCategoria = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "categoria");
                oListaLineaGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "linea");
                oListaTarifarioGeneral = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "tarifario");
                oEntidad.oListaCriterio = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "criterio");
                oEntidad.oListaVendedor = AgenteVentas.Proxy.ListarComisionesConfiguracion(oEntidad.idEmpresa, oEntidad.idComision, "vendedor");

                if (oEntidad.oListaCategoria != null && oEntidad.oListaCategoria.Count > 0)
                    idCategoriaSeleccionada = oEntidad.oListaCategoria[0].idCategoria;
                else
                    idCategoriaSeleccionada = 0;

                oEntidad.oListaLinea = oListaLineaGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();

                oEntidad.oListaTarifario = oListaTarifarioGeneral.Where(x => x.idCategoria == idCategoriaSeleccionada).ToList();



                if (oEntidad.oListaCategoria.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "ComisionesConfiguracion.", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("ComisionesConfig.Listado");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 17;

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

                                oHoja.Cells["A2"].Value = " Comisiones Configuracion " ;

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
                                oHoja.Cells[InicioLinea, 1].Value = " DATOS GENERALES ";
                                oHoja.Cells[InicioLinea, 2].Value = " VENDEDORES ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 3])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    Rango.Style.Font.Bold = true;
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                                }
                                oHoja.Cells[InicioLinea, 3].Value = " ";

                                oHoja.Cells[InicioLinea, 4].Value = " CATEGORIAS  ";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, InicioLinea, 5])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    Rango.Style.Font.Bold = true;
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                                }

                                oHoja.Cells[InicioLinea, 5].Value = " ";

                                

                                oHoja.Cells[InicioLinea, 6].Value = " CRITERIO SUBJETIVO ";

                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea, 8])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    Rango.Style.Font.Bold = true;
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

                                }

                                oHoja.Cells[InicioLinea, 7].Value = "  ";
                                
                                oHoja.Cells[InicioLinea, 8].Value = "  ";

                                oHoja.Cells[InicioLinea, 9].Value = " LINEAS POR CATEGORIA ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea, 12])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    Rango.Style.Font.Bold = true;
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                }

                                oHoja.Cells[InicioLinea, 10].Value = " ";
                                oHoja.Cells[InicioLinea, 11].Value = " ";                              
                                oHoja.Cells[InicioLinea, 12].Value = " ";


                                oHoja.Cells[InicioLinea, 13].Value = " TARIFARIO ";
                                using (ExcelRange Rango = oHoja.Cells[InicioLinea, 13, InicioLinea, 17])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    Rango.Style.Font.Bold = true;
                                    Rango.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                }
                                oHoja.Cells[InicioLinea, 14].Value = " ";
                                oHoja.Cells[InicioLinea, 15].Value = " ";
                                oHoja.Cells[InicioLinea, 16].Value = " ";
                                oHoja.Cells[InicioLinea, 17].Value = " ";


                                for (int i = 1; i <= 17; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                }




                                //Aumentando una Fila mas continuar con el detalle
                                InicioLinea++;

                                //Segunda
                                oHoja.Cells[InicioLinea, 1].Value = " Nombre Zona ";
                                oHoja.Cells[InicioLinea, 2].Value = " Codigo ";
                                oHoja.Cells[InicioLinea, 3].Value = " Vendedor ";
                                oHoja.Cells[InicioLinea, 4].Value = " Codigo ";
                                oHoja.Cells[InicioLinea, 5].Value = " Categoria ";
                                oHoja.Cells[InicioLinea, 6].Value = " Codigo ";
                                oHoja.Cells[InicioLinea, 7].Value = " Elemento Subjetivo ";
                                oHoja.Cells[InicioLinea, 8].Value = " Comision ";
                                oHoja.Cells[InicioLinea, 9].Value = " Codigo ";
                                oHoja.Cells[InicioLinea, 10].Value = " Linea ";
                                oHoja.Cells[InicioLinea, 11].Value = " Meta ";
                                oHoja.Cells[InicioLinea, 12].Value = " Pago ";
                                oHoja.Cells[InicioLinea, 13].Value = " Codigo ";
                                oHoja.Cells[InicioLinea, 14].Value = " % Inicial ";
                                oHoja.Cells[InicioLinea, 15].Value = " %Fin ";
                                oHoja.Cells[InicioLinea, 16].Value = " Factor ";
                                oHoja.Cells[InicioLinea, 17].Value = " Comision ";


                                for (int i = 1; i <= 17; i++)
                                {
                                    oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                                    oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                    oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                                }


                                // Auto Filtro
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                                #endregion

                                //Aumentando una Fila mas continuar con el detalle
                                InicioLinea++;


                                

                                    oHoja.Cells[InicioLinea, 1].Value = oEntidad.NombreZona;
                                    
                                                                


                                foreach (ComisionesConfiguracionE item in oEntidad.oListaVendedor)
                                {

                                    oHoja.Cells[InicioLinea, 2].Value = item.idVendedor;
                                    oHoja.Cells[InicioLinea, 3].Value = item.desPersona;

                                }

                                foreach (ComisionesConfiguracionE item in oEntidad.oListaCategoria)
                                {

                                    oHoja.Cells[InicioLinea, 4].Value = item.idCategoria;
                                    oHoja.Cells[InicioLinea, 5].Value = item.desCategoria;

                                }

                                foreach (ComisionesConfiguracionE item in oEntidad.oListaCriterio)
                                {

                                    oHoja.Cells[InicioLinea, 6].Value = item.idParTabla;
                                    oHoja.Cells[InicioLinea, 7].Value = item.desParTabla;
                                    oHoja.Cells[InicioLinea, 8].Value = item.Comision;
                                    oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "###,###,##0.00";

                                }

                                foreach (ComisionesConfiguracionE item in oEntidad.oListaLinea)
                                {

                                    oHoja.Cells[InicioLinea, 9].Value = item.idLinea;
                                    oHoja.Cells[InicioLinea, 10].Value = item.desLinea;
                                    oHoja.Cells[InicioLinea, 11].Value = item.Meta;
                                    oHoja.Cells[InicioLinea, 12].Value = item.Pago;
                                    oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 12].Style.Numberformat.Format = "###,###,##0.00";

                                }

                                foreach (ComisionesConfiguracionE item in oEntidad.oListaTarifario)
                                {

                                    oHoja.Cells[InicioLinea, 13].Value = item.idComisionTarifario;
                                    oHoja.Cells[InicioLinea, 14].Value = item.RangoIni;
                                    oHoja.Cells[InicioLinea, 15].Value = item.RangoFin;
                                    oHoja.Cells[InicioLinea, 16].Value = item.Factor;
                                    oHoja.Cells[InicioLinea, 17].Value = item.Comision;
                                    oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 17].Style.Numberformat.Format = "###,###,##0.00";

                                    InicioLinea++;
                                }


                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                                InicioLinea++;

                           



                                //FIN SUMATORIA //


                                //Linea
                                Int32 totFilas = InicioLinea;
                                oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                                //Suma
                                InicioLinea++;

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
                                oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
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

                //base.Exportar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion 

        #region Evento

        private void frmComisionesConfiguracionListado_Load(object sender, EventArgs e)
        {
            Grid = true;

            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            Buscar();
        }
  
        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmComisionesConfiguracion oFrm = sender as frmComisionesConfiguracion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void cboPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

        

    }
}
