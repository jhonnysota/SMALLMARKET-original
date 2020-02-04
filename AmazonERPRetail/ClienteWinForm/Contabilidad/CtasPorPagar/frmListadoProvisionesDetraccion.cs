using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Tesoreria;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmListadoProvisionesDetraccion : FrmMantenimientoBase
    {

        public frmListadoProvisionesDetraccion()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
            FormatoGrid(dgvProvisionDetra, true);
            AnchoColumnas();
        }

        #region Variables

        String RutaGeneral = String.Empty;
        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        List<ProvisionesE> ListaProvisiones = null;
        //Para el check del datagridview
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvProvisionDetra.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Check"]).Value = HCheckBox.Checked;
            }

            dgvProvisionDetra.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox()
            {
                Size = new Size(15, 15)
            };

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvProvisionDetra.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvProvisionDetra.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1;

            //Cambiar la ubicacion del checkbox para que se quede en la cabecera
            CheckBoxCab.Location = oPoint;
        }

        private void FilaCheBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modificando el contador de los check
                if ((bool)RCheckBox.Value && TotalCheckeados < TotalChecks)
                {
                    TotalCheckeados++;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                }

                //Cambiar estado de la casilla de la cabecera si es que se llenan todas las filas o viceversa.
                if (TotalCheckeados < TotalChecks)
                {
                    CheckBoxCab.Checked = false;
                }
                else if (TotalCheckeados == TotalChecks)
                {
                    CheckBoxCab.Checked = true;
                }
            }
        }

        #endregion

        #region Procedimientos de Usuario

        void AnchoColumnas()
        {
            dgvProvisionDetra.ColumnHeadersHeight = 60;
        }

        void BuscarFiltro()
        {
            bsProvisiones.DataSource = (from x in ListaProvisiones
                                        where x.codOrdenPago.ToUpper().Contains(txtOp.Text.ToUpper())
                                        select x).ToList();
        }

        #endregion

        #region Procedimiento Heredados

        public override void Buscar()
        {
            try
            {
                ListaProvisiones = AgenteCtasPorPagar.Proxy.ListarProvisionesDetraccion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpFecIni.Value.Date, dtpFecFin.Value.Date, "", "", "", "");

                bsProvisiones.DataSource = ListaProvisiones;
                bsProvisiones.ResetBindings(false);

                CheckBoxCab.Checked = false;
                HeaderCheckBoxClick(CheckBoxCab);

                TotalChecks = dgvProvisionDetra.RowCount;
                TotalCheckeados = 0;

                base.Buscar();
                lblTitulo.Text = "Registros " + bsProvisiones.Count.ToString();
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
                if (bsProvisiones.Count > 0)
                {

                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvisionesDetraccion);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    ProvisionesE Eprov = (ProvisionesE)bsProvisiones.Current;
                    oFrm = new frmProvisionesDetraccion(Eprov)
                    {
                        MdiParent = this.MdiParent
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

        public override void Exportar()
        {
            try
            {
                if (ListaProvisiones == null || ListaProvisiones.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Detracciones Provisiones", "Archivos Excel (*.xlsx)|*.xlsx");

                ExportarExcel(RutaGeneral);

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Exportar

        void ExportarExcel(String Ruta)
        {

            String TituloGeneral = String.Empty;
            String NombrePestaña = String.Empty;


            TituloGeneral = "Lista De Provisiones Detracciones";
            NombrePestaña = " PROVISIONES DETRACCIONES";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 18;

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
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(149, 240, 245));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 18, FontStyle.Italic));
                        Rango.Style.Font.Color.SetColor(Color.Black);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(174, 216, 220));
                    }

                    #endregion

                    #region Cabeceras del Detalle

                    oHoja.Column(1).Width = 14;
                    oHoja.Cells[InicioLinea, 1].Value = "RUC";

                    oHoja.Column(2).Width = 40;
                    oHoja.Cells[InicioLinea, 2].Value = "Razon Social";

                    oHoja.Column(3).Width = 15;
                    oHoja.Cells[InicioLinea, 3].Value = "Fecha Emision ";

                    oHoja.Column(4).Width = 16;
                    oHoja.Cells[InicioLinea, 4].Value = "Tipo De Comp.";

                    oHoja.Column(5).Width = 8;
                    oHoja.Cells[InicioLinea, 5].Value = "Serie ";

                    oHoja.Column(6).Width = 9;
                    oHoja.Cells[InicioLinea, 6].Value = "N°";

                    oHoja.Column(7).Width = 12;
                    oHoja.Cells[InicioLinea, 7].Value = "N° Detraccion";

                    oHoja.Column(8).Width = 8;
                    oHoja.Cells[InicioLinea, 8].Value = "Mon.";

                    oHoja.Column(9).Width = 6;
                    oHoja.Cells[InicioLinea, 9].Value = " TC ";

                    oHoja.Column(10).Width = 18;
                    oHoja.Cells[InicioLinea, 10].Value = " Importe Dolares ";

                    oHoja.Column(11).Width = 16;
                    oHoja.Cells[InicioLinea, 11].Value = " Importe Soles ";

                    oHoja.Column(12).Width = 17;
                    oHoja.Cells[InicioLinea, 12].Value = "Codigo De Bien ";

                    oHoja.Column(13).Width = 16;
                    oHoja.Cells[InicioLinea, 13].Value = "Tipo Operacion";

                    oHoja.Column(14).Width = 7;
                    oHoja.Cells[InicioLinea, 14].Value = " %";

                    oHoja.Column(15).Width = 15;
                    oHoja.Cells[InicioLinea, 15].Value = " Importe Det.";

                    oHoja.Column(16).Width = 13;
                    oHoja.Cells[InicioLinea, 16].Value = " Redondeo";

                    oHoja.Column(17).Width = 19;
                    oHoja.Cells[InicioLinea, 17].Value = " N° Constancia Ret.";

                    oHoja.Column(18).Width = 22;
                    oHoja.Cells[InicioLinea, 18].Value = " Fecha Constancia Ret.";



                    for (int i = 1; i <= 18; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(148, 145, 140));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                    }
                    //Aumentando una Fila mas continuar con el detalle


                    // Auto Filtro
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].AutoFilter = true;

                    //Aumentando una Fila mas continuar con el detalle
                    InicioLinea++;

                    #endregion

                    #region Formato Excel

                    foreach (ProvisionesE item in ListaProvisiones)
                    {


                        oHoja.Cells[InicioLinea, 1].Value = item.Ruc;
                        oHoja.Cells[InicioLinea, 2].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 3].Value = item.FechaDocumento;
                        oHoja.Cells[InicioLinea, 4].Value = item.idDocumento;
                        oHoja.Cells[InicioLinea, 5].Value = item.NumSerie;
                        oHoja.Cells[InicioLinea, 6].Value = item.NumDocumento;
                        oHoja.Cells[InicioLinea, 7].Value = item.numCuentaDetraccion;
                        oHoja.Cells[InicioLinea, 8].Value = item.desMoneda;
                        oHoja.Cells[InicioLinea, 9].Value = item.TipCambio;
                        oHoja.Cells[InicioLinea, 10].Value = item.impTotalSecun;
                        oHoja.Cells[InicioLinea, 11].Value = item.impTotalBase;
                        oHoja.Cells[InicioLinea, 12].Value = item.TipoDetraccion;
                        oHoja.Cells[InicioLinea, 13].Value = item.TipoOperacion;
                        oHoja.Cells[InicioLinea, 14].Value = item.TasaDetraccion;
                        oHoja.Cells[InicioLinea, 15].Value = item.MontoDetraccion;
                        oHoja.Cells[InicioLinea, 16].Value = item.Redondeo;
                        oHoja.Cells[InicioLinea, 17].Value = item.retNumero;
                        oHoja.Cells[InicioLinea, 18].Value = item.retFecha;

                        oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 10].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 14].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 15].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 16].Style.Numberformat.Format = "###,###,##0.00";
                        oHoja.Cells[InicioLinea, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        oHoja.Cells[InicioLinea, 3].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[InicioLinea, 18].Style.Numberformat.Format = "dd/MM/yyyy";
                        oHoja.Cells[InicioLinea, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[InicioLinea, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[InicioLinea, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        InicioLinea++;
                    }





                    //FIN SUMATORIA //


                    //Linea
                    Int32 totFilas = InicioLinea;
                    oHoja.Cells[InicioLinea, 1, InicioLinea, TotColumnas].Style.Border.Bottom.Style = ExcelBorderStyle.Double;

                    //Suma
                    InicioLinea++;

                    //Ajustando el ancho de las columnas automaticamente
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

        #region Eventos

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmProvisionesDetraccion oFrm = sender as frmProvisionesDetraccion;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void frmListadoProvisionesDetraccion_Load(object sender, EventArgs e)
        {
            Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Editar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);

            AñadirCheckBox();
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void dgvProvisionDetra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void dgvProvisionDetra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvProvisionDetra_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProvisionDetra.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvProvisionDetra.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvProvisionDetra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProvisionDetra.Rows.Count != 0)
            {
                if (!indClickCab && e.ColumnIndex == 0)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvProvisionDetra[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void btGenerarOP_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaProvisiones != null && ListaProvisiones.Count > 0)
                {
                    List<ProvisionesE> oListaDetracciones = new List<ProvisionesE>();
                    bsProvisiones.EndEdit();

                    foreach (ProvisionesE item in ListaProvisiones)
                    {
                        if (item.Check)
                        {
                            item.fecOrdenPago = dtpFecOp.Value.Date;
                            oListaDetracciones.Add(item);
                        }
                    }

                    if (Global.MensajeConfirmacion(String.Format("Desea generar la Orden de Pago con fecha {0}", dtpFecOp.Value.Date.ToString("d"))) == DialogResult.No)
                    {
                        return;
                    }

                    List<ProvisionesE> oListaTemp = (from x in oListaDetracciones
                                                     where x.idOrdenPago > 0
                                                     && x.codOrdenPago != ""
                                                     select x).ToList();

                    if (oListaTemp.Count > 0)
                    {
                        Global.MensajeComunicacion("Hay documentos que ya tienen su O.P., revise por favor...");
                        return;
                    }

                    if (oListaDetracciones.Count > 0)
                    {
                        Int32 resp = AgenteCtasPorPagar.Proxy.GenerarOpProvisionesDetracciones(oListaDetracciones, VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("Orden de pago generada...");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiEliminarOp_Click(object sender, EventArgs e)
        {
            if (bsProvisiones.Count > 0)
            {
                ProvisionesE oDocumento = (ProvisionesE)bsProvisiones.Current;

                if (String.IsNullOrWhiteSpace(oDocumento.codOrdenPago) && oDocumento.idOrdenPago == 0)
                {
                    Global.MensajeComunicacion("No hay ningúna O.P. asociada a este documento.");
                    return;
                }

                OrdenPagoE oOrdenPago = AgenteTesoreria.Proxy.ObtenerOrdenPago(oDocumento.idOrdenPago);

                if (oOrdenPago != null)
                {
                    if (oOrdenPago.indEstado == "C")
                    {
                        Global.MensajeFault("La O.P. no se puede eliminar porque se encuentra cerrada.");
                        return;
                    }
                }

                Int32 resp = AgenteTesoreria.Proxy.EliminarOrdenPago(oDocumento.idOrdenPago);

                if (resp > 0)
                {
                    Global.MensajeComunicacion("Orden de pago eliminada.");
                    AgenteGeneral.Proxy.EliminarControlDetraccionesPorOp(oDocumento.idOrdenPago);
                    Buscar();
                }
            }
        }

        private void txtOp_TextChanged(object sender, EventArgs e)
        {
            if (ListaProvisiones != null && ListaProvisiones.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        private void btnGenerarTXT_Click(object sender, EventArgs e)
        {
            #region Variables

            Int32 Caracteres = txtCorrelativo.Text.Length;
            Int32 Valor = Convert.ToInt32(txtCorrelativo.Text);
            txtCorrelativo.Text = String.Format("{0:0000}", Valor);

            Decimal Totalcab = 0;
            String RedondeoCab = String.Empty;
            String numcuentaDetraccion = String.Empty;
            String Montored = String.Empty;
            String nomLibro = String.Empty;
            String Correlativo = txtCorrelativo.Text;
            String Aniotmp = Convert.ToString(dtpFecIni.Value.Year);
            String Anio = Aniotmp.Substring(2, 2);
            String RutaArchivoTexto = String.Empty;
            String NombreArchivo = String.Empty;

            #endregion Variables

            try
            {
                #region Validaciones

                if (ListaProvisiones == null || ListaProvisiones.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay registros a exportar.");
                    return;
                }

                if (txtCorrelativo.Text == "0" || txtCorrelativo.Text == "0000" || String.IsNullOrWhiteSpace(txtCorrelativo.Text))
                {
                    Global.MensajeFault("Debe colocar un correlativo.");
                    txtCorrelativo.Focus();
                    return;
                }

                List<ProvisionesE> oListaTemp = (from x in ListaProvisiones
                                                 where x.Check == true
                                                 select x).ToList();
                if (oListaTemp.Count == 0)
                {
                    Global.MensajeComunicacion("No hay ningún documento escogido.");
                    return;
                }

                oListaTemp = (from x in ListaProvisiones
                              where x.idOrdenPago == 0
                              && x.codOrdenPago == ""
                              && x.Check == true
                              select x).ToList();

                if (oListaTemp.Count > 0)
                {
                    Global.MensajeComunicacion("Hay documentos que aún no tienen O.P., revise por favor...");
                    return;
                }

                oListaTemp = (from x in ListaProvisiones
                              where x.NombreArchivo != ""
                              && x.Check == true
                              select x).ToList();

                if (oListaTemp.Count > 0)
                {
                    Global.MensajeComunicacion("Hay documentos que ya han sido generados en un archivo de texto, revise por favor...");
                    return;
                }

                #endregion

                NombreArchivo = "D" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio + Correlativo;
                RutaArchivoTexto = CuadrosDialogo.GuardarDocumento("Guardar en", "D" + VariablesLocales.SesionUsuario.Empresa.RUC + Anio + Correlativo, "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaArchivoTexto))
                {
                    //Borrando el archivo...
                    if (File.Exists(RutaArchivoTexto))
                    {
                        File.Delete(RutaArchivoTexto);
                    }

                    StringBuilder Linea = new StringBuilder();

                    using (StreamWriter oSw = new StreamWriter(RutaArchivoTexto, true, Encoding.Default))
                    {
                        Int32 Fila = 0;

                        foreach (ProvisionesE item in ListaProvisiones)
                        {
                            //if (Convert.ToBoolean(dgvProvisionDetra.Rows[Fila].Cells["Check"].Value))
                            if (item.Check)
                            {
                                Totalcab += item.Redondeo;
                            }

                            Fila++;
                        }

                        RedondeoCab = String.Format("{0:0000000000000}", Totalcab);
                        String razonsocialcomp = String.Format("{0,-35}", VariablesLocales.SesionUsuario.Empresa.RazonSocial);

                        Linea.Append("*").Append(VariablesLocales.SesionUsuario.Empresa.RUC).Append(razonsocialcomp).Append(Anio).Append(Correlativo);
                        Linea.Append(RedondeoCab).Append("00").Append("\r\n");

                        String Mesvar = String.Empty;
                        String Tipoope = String.Empty;
                        ProvisionesE oDocumento = null;
                        Fila = 0;

                        foreach (ProvisionesE item in ListaProvisiones)
                        {
                            //if (Convert.ToBoolean(dgvProvisionDetra.Rows[Fila].Cells["Check"].Value))
                            if (item.Check)
                            {
                                Int32 tipoopenum = Convert.ToInt32(item.TipoOperacion);
                                Montored = String.Format("{0:0000000000000}", item.Redondeo);
                                Mesvar = String.Format("{0:00}", item.FechaDocumento.Month);
                                Tipoope = String.Format("{0:0000}", tipoopenum);

                                #region Insertar Linea

                                Linea.Append("6" + item.Ruc).Append("                                   ").Append("000000000").Append(item.TipoDetraccion);
                                Linea.Append(item.numCuentaDetraccion).Append(Montored).Append(Tipoope).Append(item.FechaDocumento.Year + Mesvar).Append(item.CodSunat);
                                Linea.Append(item.NumSerie).Append(item.NumDocumento);
                                oSw.WriteLine(Linea.ToString());
                                Linea.Clear();

                                #endregion

                                if (oDocumento == null)
                                {
                                    oDocumento = new ProvisionesE();
                                    oDocumento = item;
                                }
                            }

                            Fila++;
                        }

                        if (oDocumento != null)
                        {
                            List<ControlDetraccionesE> oListaControl = AgenteGeneral.Proxy.ObtenerControlDetraccionesPorOp(oDocumento.idOrdenPago);

                            if (oListaControl != null && oListaControl.Count > 0)
                            {
                                foreach (ControlDetraccionesE item in oListaControl)
                                {
                                    item.NombreArchivo = NombreArchivo;
                                }

                                AgenteGeneral.Proxy.ActualizarControlDetracciones(oListaControl);
                                Buscar();

                                Global.MensajeComunicacion("Archivo exportado...");
                            }
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

    }
}
