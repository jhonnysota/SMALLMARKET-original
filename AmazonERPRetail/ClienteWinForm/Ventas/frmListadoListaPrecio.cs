using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoListaPrecio : FrmMantenimientoBase
    {

        public frmListadoListaPrecio()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvPrecios, false);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<ListaPrecioE> oListaPrecio = null;       
        public ListaPrecioE ListaPrec = new ListaPrecioE();
        String RutaGeneral = String.Empty;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListaPrecio);

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
                oFrm = new frmListaPrecio(oListaPrecio)
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
            Form oFrm = MdiChildren.FirstOrDefault(x => x is frmListaPrecio);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            oFrm = new frmListaPrecio(oListaPrecio, ((ListaPrecioE)bsListaPrecios.Current).idEmpresa, ((ListaPrecioE)bsListaPrecios.Current).idListaPrecio)
            {
                MdiParent = MdiParent
            };

            oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
            oFrm.Show();
        }

        public override void Buscar()
        {
            try
            {
                oListaPrecio = AgenteVentas.Proxy.ListarListaPrecio(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                bsListaPrecios.DataSource = oListaPrecio;
                LblTitulo.Text = "Registros " + oListaPrecio.Count.ToString();
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
                if (bsListaPrecios.Count > Variables.Cero)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoAnulacion) == DialogResult.Yes)
                    {
                        AgenteVentas.Proxy.EliminarListaPrecio(((ListaPrecioE)bsListaPrecios.Current).idEmpresa, ((ListaPrecioE)bsListaPrecios.Current).idListaPrecio);
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoListaPrecioImprimir);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                ListaPrec = (ListaPrecioE)bsListaPrecios.Current;
                ListaPrec.ListaPreciosItem = AgenteVentas.Proxy.ListarListaPrecioItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ListaPrec.idListaPrecio);

                oFrm = new frmListadoListaPrecioImprimir(ListaPrec);
                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
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
                if ((ListaPrecioE)bsListaPrecios.Current == null)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en ", " Listado de Precios ", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    ListaPrec = (ListaPrecioE)bsListaPrecios.Current;
                    ListaPrec.ListaPreciosItem = AgenteVentas.Proxy.ListarListaPrecioItem(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, ListaPrec.idListaPrecio);

                    if (ListaPrec.ListaPreciosItem.Count > Variables.Cero)
                    {
                        ExportarExcel(RutaGeneral);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos de Usuario

        void ExportarExcel(String Ruta)
        {
            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;

            TituloGeneral = "Listado de Precios " + ListaPrec.Nombre + " - en " + ListaPrec.desMoneda ;
            NombrePestaña = "Listado de Precios";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 16;

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 20, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(64, 64, 64)); //Gris Oscuro
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(89, 89, 89));//Gris
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    // PRIMERA
                    oHoja.Cells[InicioLinea, 1].Value = "Tipo de Articulo";
                    oHoja.Cells[InicioLinea, 2].Value = "Articulo";
                    oHoja.Cells[InicioLinea, 3].Value = "Precio Bruto";
                    oHoja.Cells[InicioLinea, 4].Value = "% 1";
                    oHoja.Cells[InicioLinea, 5].Value = "% 2";
                    oHoja.Cells[InicioLinea, 6].Value = "% 3";
                    oHoja.Cells[InicioLinea, 7].Value = "Dscto 1";
                    oHoja.Cells[InicioLinea, 8].Value = "Dscto 2";
                    oHoja.Cells[InicioLinea, 9].Value = "Dscto 3";
                    oHoja.Cells[InicioLinea, 10].Value = "Valor Venta";
                    oHoja.Cells[InicioLinea, 11].Value = "Tipo Selectivo";
                    oHoja.Cells[InicioLinea, 12].Value = "% ISC";
                    oHoja.Cells[InicioLinea, 13].Value = "ISC ";
                    oHoja.Cells[InicioLinea, 14].Value = "% IGV";
                    oHoja.Cells[InicioLinea, 15].Value = "IGV";
                    oHoja.Cells[InicioLinea, 16].Value = "Precio Venta";

                    for (int i = 1; i <= 16; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new Font("Arial", 9, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 170, 170));//Gris Claro
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    }

                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Llenando el detalle

                    String Nombre = String.Empty;

                    foreach (ListaPrecioItemE item in ListaPrec.ListaPreciosItem)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = item.desTipoArticulo;
                        oHoja.Cells[InicioLinea, 2].Value = item.desArticulo;
                        oHoja.Cells[InicioLinea, 3].Value = item.PrecioBruto;
                        oHoja.Cells[InicioLinea, 4].Value = item.PorDscto1;
                        oHoja.Cells[InicioLinea, 5].Value = item.PorDscto2;
                        oHoja.Cells[InicioLinea, 6].Value = item.PorDscto3;
                        oHoja.Cells[InicioLinea, 7].Value = item.MontoDscto1;
                        oHoja.Cells[InicioLinea, 8].Value = item.MontoDscto2;
                        oHoja.Cells[InicioLinea, 9].Value = item.MontoDscto3;
                        oHoja.Cells[InicioLinea, 10].Value = item.PrecioValorVenta;

                        if (item.TipoImpSelectivo == "P")
                        {
                            Nombre = "Porcentaje";
                        }
                        else if (item.TipoImpSelectivo == "L")
                        {
                            Nombre = "Litro";
                        }
                        else if (item.TipoImpSelectivo == "N" || item.TipoImpSelectivo == "0")
                        {
                            Nombre = "Ninguno";
                        }

                        oHoja.Cells[InicioLinea, 11].Value = Nombre;
                        oHoja.Cells[InicioLinea, 12].Value = item.porisc;
                        oHoja.Cells[InicioLinea, 13].Value = item.isc;
                        oHoja.Cells[InicioLinea, 14].Value = item.porigv;
                        oHoja.Cells[InicioLinea, 15].Value = item.igv;
                        oHoja.Cells[InicioLinea, 16].Value = item.PrecioVenta;
                        oHoja.Cells[InicioLinea, 3, InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 12, InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                        
                        InicioLinea++;
                    }

                    oHoja.Cells[InicioLinea - ListaPrec.ListaPreciosItem.Count, 1, InicioLinea, 16].Style.Font.SetFromFont(new Font("Arial", 9));

                    #endregion

                    #region Parte Final del Excel
                    
                    //Linea
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Ajustando el ancho de las columnas automaticamente
                    oHoja.Cells.AutoFitColumns(0);

                    //Insertando Encabezado
                    oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                    //Pie de Pagina(Derecho) "Número de paginas y el total"
                    oHoja.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pag. {0} de {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                    //Pie de Pagina(centro)
                    oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                    //Otras Propiedades
                    oHoja.Workbook.Properties.Title = TituloGeneral;
                    oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                    oHoja.Workbook.Properties.Subject = "Reportes";
                    //oHoja.Workbook.Properties.Keywords = "";
                    oHoja.Workbook.Properties.Category = "Modulo de Ventas";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    //Guardando el excel
                    oExcel.Save();
                    Global.MensajeComunicacion("Exportación Guardada");    

                    #endregion                 
                }
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmListaPrecio oFrm = sender as frmListaPrecio;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmListadoListaPrecio_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            //if (VariablesLocales.SesionUsuario.IdPersona == 10978 || VariablesLocales.SesionUsuario.IdPersona == 11946 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 12737 || VariablesLocales.SesionUsuario.IdPersona == 12745 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 13039 || VariablesLocales.SesionUsuario.IdPersona == 13130 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 13153 || VariablesLocales.SesionUsuario.IdPersona == 13901 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 13909 || VariablesLocales.SesionUsuario.IdPersona == 13937 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 13956 || VariablesLocales.SesionUsuario.IdPersona == 14511 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 15157 || VariablesLocales.SesionUsuario.IdPersona == 15159 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 15375 || VariablesLocales.SesionUsuario.IdPersona == 15390 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 15489 || VariablesLocales.SesionUsuario.IdPersona == 15608 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 16412 || VariablesLocales.SesionUsuario.IdPersona == 13879 ||
            //    VariablesLocales.SesionUsuario.IdPersona == 20242)
            //{
            //    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            //    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            //    BloquearOpcion(EnumOpcionMenuBarra.Anular, false);

            //    Bloqueo = "S";
            //}
            //else
            //{
            //    BloquearOpcion(EnumOpcionMenuBarra.Nuevo, true);
            //    BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            //    BloquearOpcion(EnumOpcionMenuBarra.Anular, true);
            //    Bloqueo = "N";
            //}

            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            //BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            Buscar();
        }

        private void dgvPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvPrecios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((Boolean)dgvPrecios.Rows[e.RowIndex].Cells["indBaja"].Value == true)
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
        }

        #endregion

    }
}
