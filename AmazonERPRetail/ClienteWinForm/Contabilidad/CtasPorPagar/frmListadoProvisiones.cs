using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Contabilidad.Reportes;
using ClienteWinForm.Busquedas;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.CtasPorPagar
{
    public partial class frmListadoProvisiones : FrmMantenimientoBase
    {

        public frmListadoProvisiones()
        {
            try
            {
                SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                InitializeComponent();

                Global.AjustarResolucion(this);
                FormatoGrid(dgvprovision, true);
                LlenarCombos();
                
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #region Variables

        CtasPorPagarServiceAgent AgenteCtasPorPagar { get { return new CtasPorPagarServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        List<ProvisionesE> oListaProvisiones = null;
        Boolean Ordenar = false;

        //Para el check del datagridview
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            //Diarios
            List<ComprasFileE> oLista = AgenteContabilidad.Proxy.ListarComprasDiarios(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComprasFileE oItem = new ComprasFileE() { idComprobante = "0", desComprobante = Variables.Todos };
            oLista.Add(oItem);
            ComboHelper.LlenarCombos<ComprasFileE>(cboLibro, (from x in oLista orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobante");

            //Documentos
            List<DocumentosE> oListaDocumentos = new List<DocumentosE>(VariablesLocales.ListarDocumentoGeneral);
            ComboHelper.LlenarCombos<DocumentosE>(cboDocumentos, oListaDocumentos, "idDocumento", "idDocumento");
            cboDocumentos.SelectedIndex = -1;

            oLista = null;
            oListaDocumentos = null;
        }

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvprovision.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Check"]).Value = HCheckBox.Checked;
            }

            dgvprovision.RefreshEdit();
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
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvprovision.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvprovision.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvisiones);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmProvisiones()
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvisiones);

                if (bsprovisiones.Count > Variables.Cero)
                {
                    if (oFrm != null)
                    {
                        oFrm.BringToFront();
                        return;
                    }

                    ProvisionesE current = (ProvisionesE)bsprovisiones.Current;

                    if (current != null)
                    {
                        oFrm = new frmProvisiones(current.idEmpresa, current.idLocal, current.idProvision)
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
                DateTime fecIni = dtpInicio.Value.Date; DateTime fecFin = dtpFinal.Value.Date;
                String lsEstado = "RE";
                String RazonSocial = String.Empty; String idComprobante = "%"; String numFile = "%"; String idDocumento = "%"; String numSerie = "%"; String numDoc = "%";

                if (rbRegistrado.Checked)
                {
                    lsEstado = "RE";
                }

                if (rbProvisionada.Checked)
                {
                    lsEstado = "PR";
                }

                if (rbUno.Checked)
                {
                    RazonSocial = txtRazonSocial.Text.Trim();
                }

                if (cboLibro.SelectedValue.ToString() != "0")
                {
                    idComprobante = cboLibro.SelectedValue.ToString();
                }

                if (cboFile.SelectedValue != null)
                {
                    if (cboFile.SelectedValue.ToString() != "0")
                    {
                        numFile = cboFile.SelectedValue.ToString();
                    } 
                }

                if (rbUnoDoc.Checked)
                {
                    if (cboDocumentos.SelectedIndex != -1)
                    {
                        idDocumento = cboDocumentos.SelectedValue.ToString();
                    }

                    if (!String.IsNullOrWhiteSpace(txtSerie.Text.Trim()))
                    {
                        numSerie = txtSerie.Text.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(txtNumero.Text.Trim()))
                    {
                        numDoc = txtNumero.Text.Trim();
                    }
                }

                bsprovisiones.DataSource = oListaProvisiones = AgenteCtasPorPagar.Proxy.ListarProvisiones(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, 
                                                                                                        fecIni, fecFin, RazonSocial, lsEstado, idComprobante, numFile, idDocumento, numSerie, numDoc);
                //Inicializando el checkbox del datagridview
                CheckBoxCab.Checked = false;
                HeaderCheckBoxClick(CheckBoxCab);

                TotalChecks = oListaProvisiones.Count;
                TotalCheckeados = 0;
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
                ProvisionesE current = (ProvisionesE)bsprovisiones.Current;

                if (current != null)
                {
                    String Anio = current.FechaProvision.ToString("yyyy");
                    String Mes = current.FechaProvision.ToString("MM");
                    PeriodosE oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes);

                    if (oPeriodoContable.indCierre)
                    {
                        Global.MensajeComunicacion("El mes se encuentra cerrado. No puede Eliminar registros de este Periodo.");
                        return;
                    }

                    CierreSistemaE oCierreSistema = AgenteContabilidad.Proxy.ObtenerCierreSistema(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes, 5);

                    if (oCierreSistema != null)
                    {
                        if (oCierreSistema.indCierre)
                        {
                            if (current.FechaProvision <= oCierreSistema.FechaCierre)
                            {
                                Global.MensajeComunicacion("El sistema de Compras a esa fecha se encuentra cerrado");
                                return;
                            }
                        }
                    }

                    //Revisando si se trata de una Liquidación
                    if (current.EsLiquidacion)
                    {
                        //Para saber si existe o no en Liquidaciones...
                        LiquidacionDetE oLiquiDet = AgenteCtasPorPagar.Proxy.LiquidacionDetPorDocumento(current.idEmpresa, current.idLocal, current.idDocumento, current.NumSerie, current.NumDocumento);

                        //Si existe tiene que salir el mensaje, caso contrario lo elimina...
                        if (oLiquiDet != null)
                        {
                            Global.MensajeComunicacion("Este registro no se puede eliminar porque se trata de una Liquidación, eliminelo desde el Módulo de Tesoreria.");
                            return;
                        }
                    }

                    //Revisando si ya esta provisionado
                    if (((ProvisionesE)bsprovisiones.Current).EstadoProvision == "PR")
                    {
                        Global.MensajeComunicacion("Este documento ya fue provisionado, elimine el voucher primero.");
                        return;
                    }

                    if (((ProvisionesE)bsprovisiones.Current).EstadoProvision == "RE")
                    {
                        OrdenPagoDetE oDetalle = AgenteTesoreria.Proxy.ObtenerOrdenPagoDetPorDocumento(current.idEmpresa, current.idLocal, current.idPersona.Value, current.idDocumento, current.NumSerie, current.NumDocumento);

                        if (oDetalle != null)
                        {
                            Global.MensajeComunicacion("El documento se encuentra en Orden de Pago. No puede eliminar el registro aún.");
                            return;
                        }
                    }

                    if (Global.MensajeConfirmacion("Desea eliminar la fila escogida.") == DialogResult.Yes)
                    {
                        ProvisionesE oProv = AgenteCtasPorPagar.Proxy.ObtenerProvisionPorNumReve(current.idEmpresa, current.idLocal, current.idProvision);

                        if (oProv == null)
                        {
                            //Liberando la provision para vuelva a salir en el listado de provisiones por revertir...
                            if (((ProvisionesE)bsprovisiones.Current).idProvisionRev != null)
                            {
                                AgenteCtasPorPagar.Proxy.ActualizarNumReversion(current.idEmpresa, current.idLocal, (Int32?)null, Convert.ToInt32(current.idProvisionRev), VariablesLocales.SesionUsuario.Credencial);
                            }

                            int Resp = AgenteCtasPorPagar.Proxy.EliminarProvisiones(current.idEmpresa, current.idLocal, current.idProvision);

                            if (Resp > 0)
                            {
                                Global.MensajeComunicacion("Se eliminó correctamente.");
                                bsprovisiones.RemoveCurrent();
                                base.Anular();
                            }
                        }
                        else
                        {
                            Global.MensajeComunicacion(String.Format("No se puede eliminar por se encuentra enlazado a la provisión {0}", oProv.idProvision.ToString("0000000")));
                        }
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
                if (oListaProvisiones.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Listado De Provisiones", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("Provisiones");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 35;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = " COMPRAS DE " + dtpInicio.Value.ToString("d") + " AL " + dtpFinal.Value.ToString("d");

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(Color.White);
                                    Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(245, 163, 113));
                                }

                                #endregion

                                #region Cabeceras del Detalle

                                // Primera
                                oHoja.Cells[InicioLinea, 1].Value = " Nro.";
                                oHoja.Cells[InicioLinea, 2].Value = " Fecha Prov.";
                                oHoja.Cells[InicioLinea, 3].Value = " RUC";
                                oHoja.Cells[InicioLinea, 4].Value = " Razon Social";
                                oHoja.Cells[InicioLinea, 5].Value = " Fecha Doc.";
                                oHoja.Cells[InicioLinea, 6].Value = " Fecha Ven.";
                                oHoja.Cells[InicioLinea, 7].Value = " T. D.";
                                oHoja.Cells[InicioLinea, 8].Value = " Serie ";
                                oHoja.Cells[InicioLinea, 9].Value = " Documento ";
                                oHoja.Cells[InicioLinea, 10].Value = " Tip. Ref. ";
                                oHoja.Cells[InicioLinea, 11].Value = " Ser. Ref. ";
                                oHoja.Cells[InicioLinea, 12].Value = " Docu. Ref. ";
                                oHoja.Cells[InicioLinea, 13].Value = " Mon. ";
                                oHoja.Cells[InicioLinea, 14].Value = " Base. Imp. S/. ";
                                oHoja.Cells[InicioLinea, 15].Value = " IGV S/. ";
                                oHoja.Cells[InicioLinea, 16].Value = " Importe S/. ";
                                oHoja.Cells[InicioLinea, 17].Value = " TC. ";
                                oHoja.Cells[InicioLinea, 18].Value = " Base Impo $ ";
                                oHoja.Cells[InicioLinea, 19].Value = " IGV $ ";
                                oHoja.Cells[InicioLinea, 20].Value = " Importe $ ";
                                oHoja.Cells[InicioLinea, 21].Value = " N° Detra ";
                                oHoja.Cells[InicioLinea, 22].Value = " Fecha Detraccion";
                                oHoja.Cells[InicioLinea, 23].Value = " Tipo Detraccion";
                                oHoja.Cells[InicioLinea, 24].Value = " Tasa % Detraccion";
                                oHoja.Cells[InicioLinea, 25].Value = " Monto Detraccion";
                                oHoja.Cells[InicioLinea, 26].Value = " Empre Paga";
                                oHoja.Cells[InicioLinea, 27].Value = " Por Revertir";
                                oHoja.Cells[InicioLinea, 28].Value = " Libro ";
                                oHoja.Cells[InicioLinea, 29].Value = " File ";
                                oHoja.Cells[InicioLinea, 30].Value = " Voucher ";
                                oHoja.Cells[InicioLinea, 31].Value = " Estado ";
                                oHoja.Cells[InicioLinea, 32].Value = " Usu. Registro ";
                                oHoja.Cells[InicioLinea, 33].Value = " Fecha Registro";
                                oHoja.Cells[InicioLinea, 34].Value = " Usuario Mod. ";
                                oHoja.Cells[InicioLinea, 35].Value = " Fecha Mod. ";

                                for (int i = 1; i <= 35; i++)
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

                                foreach (ProvisionesE item in oListaProvisiones)
                                {
                                    oHoja.Cells[InicioLinea, 1].Value = item.idProvision;
                                    oHoja.Cells[InicioLinea, 2].Value = item.FechaProvision;
                                    oHoja.Cells[InicioLinea, 3].Value = item.Ruc;
                                    oHoja.Cells[InicioLinea, 4].Value = item.RazonSocial;
                                    oHoja.Cells[InicioLinea, 5].Value = item.FechaDocumento;
                                    oHoja.Cells[InicioLinea, 6].Value = item.FechaVencimiento;
                                    oHoja.Cells[InicioLinea, 7].Value = item.idDocumento;
                                    oHoja.Cells[InicioLinea, 8].Value = item.NumSerie;
                                    oHoja.Cells[InicioLinea, 9].Value = item.NumDocumento;
                                    oHoja.Cells[InicioLinea, 10].Value = item.DesidDocumentoRef;
                                    oHoja.Cells[InicioLinea, 11].Value = item.numSerieRef;
                                    oHoja.Cells[InicioLinea, 12].Value = item.numDocumentoRef;
                                    oHoja.Cells[InicioLinea, 13].Value = item.desMoneda;
                                    oHoja.Cells[InicioLinea, 14].Value = item.impImponBase + item.impExonBase;
                                    oHoja.Cells[InicioLinea, 15].Value = item.impImpuestoBase;
                                    oHoja.Cells[InicioLinea, 16].Value = item.impTotalBase;
                                    oHoja.Cells[InicioLinea, 17].Value = item.TipCambio;
                                    oHoja.Cells[InicioLinea, 18].Value = item.impImponSecun + item.impExonSecun;
                                    oHoja.Cells[InicioLinea, 19].Value = item.impImpuestoSecun;
                                    oHoja.Cells[InicioLinea, 20].Value = item.impTotalSecun;
                                    oHoja.Cells[InicioLinea, 21].Value = item.retNumero;
                                    oHoja.Cells[InicioLinea, 22].Value = item.retFecha;
                                    oHoja.Cells[InicioLinea, 23].Value = item.TipoDetraccion;
                                    oHoja.Cells[InicioLinea, 24].Value = item.TasaDetraccion;
                                    oHoja.Cells[InicioLinea, 25].Value = item.MontoDetraccion;
                                    oHoja.Cells[InicioLinea, 26].Value = item.indPagoDetra;
                                    oHoja.Cells[InicioLinea, 27].Value = item.indReversion;
                                    oHoja.Cells[InicioLinea, 28].Value = item.DesComprobante;
                                    oHoja.Cells[InicioLinea, 29].Value = item.DesFile;
                                    oHoja.Cells[InicioLinea, 30].Value = item.numVoucher;
                                    oHoja.Cells[InicioLinea, 31].Value = item.DesEstado;
                                    oHoja.Cells[InicioLinea, 32].Value = item.UsuarioRegistro;
                                    oHoja.Cells[InicioLinea, 33].Value = item.FechaRegistro;
                                    oHoja.Cells[InicioLinea, 34].Value = item.UsuarioModificacion;
                                    oHoja.Cells[InicioLinea, 35].Value = item.FechaModificacion;

                                    oHoja.Cells[InicioLinea, 14, InicioLinea, 20].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 24, InicioLinea, 25].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 5, InicioLinea, 6].Style.Numberformat.Format = "dd/MM/yyyy";
                                    oHoja.Cells[InicioLinea, 22].Style.Numberformat.Format = "dd/MM/yyyy";
                                    oHoja.Cells[InicioLinea, 33].Style.Numberformat.Format = "dd/MM/yyyy";
                                    oHoja.Cells[InicioLinea, 35].Style.Numberformat.Format = "dd/MM/yyyy";
                                    oHoja.Cells[InicioLinea, 2].Style.Numberformat.Format = "dd/MM/yyyy";

                                    InicioLinea++;
                                }

                                #endregion

                                //Ajustando el ancho de las columnas automaticamente
                                oHoja.Cells.AutoFitColumns(0);

                                //Insertando Encabezado
                                //oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                                //Pie de Pagina(Derecho) "Número de paginas y el total"
                                oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                                //Pie de Pagina(centro)
                                oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                                //Otras Propiedades
                                //oHoja.Workbook.Properties.Title = TituloGeneral;
                                oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                                oHoja.Workbook.Properties.Subject = "Reportes";
                                //oHoja.Workbook.Properties.Keywords = "";
                                oHoja.Workbook.Properties.Category = "Módulo de Compras";
                                //oHoja.Workbook.Properties.Comments = NombrePestaña;

                                // Establecer algunos valores de las propiedades extendidas
                                oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                                //Propiedades para imprimir
                                oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                                oHoja.PrinterSettings.PaperSize = ePaperSize.A3;

                                Global.MensajeComunicacion("Se ha Exportado Correctamente");

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

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmProvisiones oFrm = sender as frmProvisiones;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoProvisiones_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpInicio.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            base.Grabar();
           
            AñadirCheckBox();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void dgvListadoProvisiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void tsmiGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsprovisiones.List.Count > 0)
                {
                    ProvisionesE current = (ProvisionesE)bsprovisiones.Current;

                    if (current != null)
                    {
                        current = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(current.idEmpresa, current.idLocal, current.idProvision, false, "N");

                        if (current.EstadoProvision == "PR")
                        {
                            Global.MensajeAdvertencia("Este documento ya ha sido provisionado.");
                            return;
                        }

                        String Mes = current.MesPeriodo;
                        String Anio = current.AnioPeriodo;
                        String idComprobante = current.idComprobante;
                        String numFile = current.numFile;
                        String codCuenta = current.codCuenta;
                        String numVoucher = current.numVoucher;
                        DateTime FechaProvision = current.FechaProvision;

                        if (!String.IsNullOrEmpty(Mes) && !String.IsNullOrEmpty(Anio) && !String.IsNullOrEmpty(idComprobante) && !String.IsNullOrEmpty(numFile) && !String.IsNullOrEmpty(codCuenta))
                        {
                            PeriodosE oPeriodoContable = new ContabilidadServiceAgent().Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes);

                            if (oPeriodoContable != null)
                            {
                                if (oPeriodoContable.indCierre)
                                {
                                    Global.MensajeComunicacion("El mes se encuentra cerrado. No puede enviar Asientos");
                                }
                                else
                                {
                                    Boolean Permitido = true;
                                    CierreSistemaE oCierreSistema = AgenteContabilidad.Proxy.ObtenerCierreSistema(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes, 5);

                                    if (oCierreSistema != null)
                                    {
                                        if (oCierreSistema.indCierre)
                                        {
                                            if (FechaProvision <= oCierreSistema.FechaCierre)
                                            {
                                                Global.MensajeComunicacion("El sistema de Compras a esa fecha se encuentra cerrado");
                                                Permitido = false;
                                            }
                                        }
                                    }

                                    if (Permitido)
                                    {
                                        if (current.EsLiquidacion)
                                        {
                                            Global.MensajeComunicacion("No puede generar el asiento contable porque se trata de una Liquidación. Tiene que cerrarla desde Tesoreria");
                                            return;
                                        }

                                        if (current.EsRendicion)
                                        {
                                            Global.MensajeComunicacion("No puede generar el asiento contable porque se trata de una Rendición. Tiene que cerrarla desde Tesoreria");
                                            return;
                                        }

                                        #region Proceso de Envio

                                        //Revisando si existe el vouchre
                                        if (!String.IsNullOrEmpty(numVoucher))
                                        {
                                            VoucherE oVoucherExiste = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(current.idEmpresa, current.idLocal, Anio, Mes, numVoucher, idComprobante, numFile);

                                            if (oVoucherExiste != null)
                                            {
                                                Global.MensajeAdvertencia(String.Format("El Nro. de Voucher {0} {1}-{2} ya ha sido asignado a {3}, limpie el número de voucher.", oVoucherExiste.idComprobante, oVoucherExiste.numFile, numVoucher, oVoucherExiste.numDocumentoPresu));
                                                return;
                                            }
                                        }

                                        if (Global.MensajeConfirmacion("Seguro de Generar Asiento S/N") == DialogResult.Yes)
                                        {
                                            String TipoGeneracion = "N";

                                            //Por lo pronto Intermetal y FFS
                                            if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179")
                                            {
                                                TipoGeneracion = "G";
                                            }

                                            ProvisionesE oProvision = AgenteCtasPorPagar.Proxy.GenerarAsientoProvisiones((ProvisionesE)bsprovisiones.Current, VariablesLocales.SesionUsuario.Credencial, TipoGeneracion);

                                            if (oProvision != null)
                                            {
                                                Global.MensajeComunicacion(String.Format("Se generó el Asiento Contable {0} {1}-{2}", oProvision.idComprobante, oProvision.numFile, oProvision.numVoucher));
                                                bsprovisiones.RemoveCurrent();
                                            }
                                            else
                                            {
                                                Global.MensajeFault("Hubo algunos inconvenientes al generar el Asiento Contable.");
                                            }
                                        }

                                        #endregion
                                    }
                                }
                            }
                            else
                            {
                                Global.MensajeComunicacion("No se encuentran los Periodos.");
                            }
                        }
                        else
                        {
                            Global.MensajeComunicacion("Faltan algunos datos antes de generar el asiento contable. Verifique por favor...");
                        }  
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void rbRegistrado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRegistrado.Checked)
            {
                tsmiGenerar.Enabled = true;
                tsmiEliminar.Enabled = false;
                tsmEliminarMasivo.Enabled = false;
                tsmiVerVoucher.Enabled = false;
                tsmLimpiar.Enabled = true;
                Buscar();
            }
        }

        private void rbProvisionada_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProvisionada.Checked)
            {
                tsmiGenerar.Enabled = false;
                tsmiEliminar.Enabled = true;
                tsmEliminarMasivo.Enabled = true;
                tsmiVerVoucher.Enabled = true;
                tsmLimpiar.Enabled = false;
                Buscar();
            }
        }

        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProvisionesE current = (ProvisionesE)bsprovisiones.Current;

                if (current != null)
                {
                    String AnioElim = current.FechaProvision.ToString("yyyy");
                    String MesElim = current.FechaProvision.ToString("MM");
                    PeriodosE oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(current.idEmpresa, AnioElim, MesElim);

                    if (oPeriodoContable.indCierre)
                    {
                        Global.MensajeComunicacion("El mes se encuentra cerrado. No puede Eliminar registros de este Periodo.");
                        return;
                    }

                    CierreSistemaE oCierreSistema = AgenteContabilidad.Proxy.ObtenerCierreSistema(current.idEmpresa, AnioElim, MesElim, 5);

                    if (oCierreSistema != null)
                    {
                        if (oCierreSistema.indCierre)
                        {
                            if (current.FechaProvision <= oCierreSistema.FechaCierre)
                            {
                                Global.MensajeComunicacion("El sistema de Compras a esa fecha se encuentra cerrado");
                                return;
                            }
                        }
                    }

                    if (current.EsLiquidacion)
                    {
                        Global.MensajeComunicacion("No puede eliminar el asiento contable porque se trata de una Liquidación. Tiene que Abrir su Liquidación en Tesoreria");
                        return;
                    }

                    if (current.EsRendicion)
                    {
                        Global.MensajeComunicacion("No puede eliminar el asiento contable porque se trata de una Rendición. Tiene que Abrir su Rendición en Tesoreria");
                        return;
                    }

                    Int32 idEmpresa = current.idEmpresa;
                    Int32 idLocal = current.idLocal;
                    Int32 idProvision = current.idProvision;
                    String Anio = current.AnioPeriodo;
                    String Mes = current.MesPeriodo;
                    String numVoucher = current.numVoucher;
                    String idComprobante = current.idComprobante;
                    String File = current.numFile;
                    String Usuario = VariablesLocales.SesionUsuario.Credencial;
                    String EstadoTmp = "RE";
                    Int32 Resp = AgenteCtasPorPagar.Proxy.EliminarVoucherProvision(idEmpresa, idLocal, idProvision, Anio, Mes, numVoucher, idComprobante, File, Usuario, EstadoTmp);

                    if (Resp > 0)
                    {
                        bsprovisiones.RemoveCurrent();
                        Global.MensajeComunicacion("El Voucher fue eliminado");
                    } 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmiVerVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }
                ProvisionesE Provisiones = (ProvisionesE)bsprovisiones.Current;

                if (Provisiones != null)
                {
                    VoucherE VoucherRep = new VoucherE();
                    VoucherRep.AnioPeriodo = Provisiones.AnioPeriodo;
                    VoucherRep.numVoucher = Provisiones.numVoucher;
                    VoucherRep.idComprobante = Provisiones.idComprobante;
                    VoucherRep.numFile = Provisiones.numFile;
                    VoucherRep.MesPeriodo = Provisiones.MesPeriodo;
                    VoucherRep.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    VoucherRep.idLocal = Provisiones.idLocal;

                    oFrm = new frmImpresionVoucher("N", VoucherRep);
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
            {
                txtRazonSocial.Validating -= txtRazonSocial_Validating;
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
            }
            else
            {
                txtRazonSocial.Validating += txtRazonSocial_Validating;
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.Focus();
            }
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && rbUno.Checked)
                {
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Prov");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Text = String.Empty;
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRazonSocial.Text = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    if (cboLibro.SelectedValue.ToString() != "0")
                    {
                        List<ComprasFileE> ListaFiles = new List<ComprasFileE>(((ComprasFileE)cboLibro.SelectedItem).oListaFiles);//AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                        ComprasFileE File = new ComprasFileE() { numFile = Variables.Cero.ToString(), desFile = Variables.Todos };
                        ListaFiles.Add(File);
                        ComboHelper.LlenarCombos<ComprasFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFile");

                        if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                        {
                            cboFile.Enabled = false;
                        }
                        else
                        {
                            cboFile.Enabled = true;
                        }

                        if (ListaFiles.Count == 2)
                        {
                            cboFile.SelectedValue = ListaFiles[0].numFile;
                        }
                        else
                        {
                            cboFile.SelectedValue = Variables.Cero.ToString();
                        }

                        ListaFiles = null;
                        Buscar(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbTodoDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodoDoc.Checked)
            {
                cboDocumentos.SelectedIndex = -1;
                cboDocumentos.Enabled = false;
                txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtNumero.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            else
            {
                cboDocumentos.Enabled = true;
                txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
                txtNumero.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
            }
        }

        private void cboDocumentos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSerie.Focus();
        }

        private void tsmGenerarMasivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    List<ProvisionesE> oListaProvision = new List<ProvisionesE>();

                    foreach (ProvisionesE item in bsprovisiones.List)
                    {
                        if (item.Check)
                        {
                            if (!String.IsNullOrWhiteSpace(item.numVoucher))
                            {
                                VoucherE oVoucherExiste = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);

                                if (oVoucherExiste != null)
                                {
                                    Global.MensajeAdvertencia(String.Format("El Nro. de Voucher {0} existe. Limpie el número en la provisión {1} antes de mandar el masivo", item.numVoucher, item.idProvision.ToString()));
                                    return;
                                }
                            }

                            ProvisionesE current = AgenteCtasPorPagar.Proxy.RecuperarProvisionesPorId(item.idEmpresa, item.idLocal, item.idProvision, false, "N");

                            if (current.EstadoProvision == "PR")
                            {
                                Global.MensajeAdvertencia("Este documento ya ha sido provisionado.");
                                return;
                            }

                            if (item.EsLiquidacion)
                            {
                                Global.MensajeComunicacion("No puede generar el asiento contable porque se trata de una liquidación. Tiene que cerrar su Liquidación en Tesoreria");
                                return;
                            }

                            oListaProvision.Add(item);
                        }
                    }

                    if (oListaProvision.Count > Variables.Cero)
                    {
                        String TipoGeneracion = "N";

                        //Por lo pronto Intermetal y FFS
                        if (VariablesLocales.SesionUsuario.Empresa.RUC == "20523201868" || VariablesLocales.SesionUsuario.Empresa.RUC == "20601328179")
                        {
                            TipoGeneracion = "G";
                        }

                        Int32 resp = AgenteCtasPorPagar.Proxy.GenerarVoucherProvisionMasivo(oListaProvision, VariablesLocales.SesionUsuario.Credencial, TipoGeneracion);

                        if (resp > 0)
                        {
                            foreach (ProvisionesE item in oListaProvision)
                            {
                                bsprovisiones.Remove(item);
                            }

                            TotalChecks = bsprovisiones.Count;
                            TotalCheckeados = 0;
                            CheckBoxCab.Checked = false;

                            Global.MensajeComunicacion("Se generaron todos los vouchers...");
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item antes de generar los vouchers.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmEliminarMasivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    List<ProvisionesE> oListaProvision = new List<ProvisionesE>();

                    foreach (ProvisionesE item in bsprovisiones.List)
                    {
                        if (item.Check)
                        {
                            String Anio = item.FechaProvision.ToString("yyyy");
                            String Mes = item.FechaProvision.ToString("MM");
                            PeriodosE oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes);

                            if (oPeriodoContable.indCierre)
                            {
                                Global.MensajeComunicacion("El mes se encuentra cerrado. No puede Eliminar registros de este Periodo.");
                                return;
                            }

                            CierreSistemaE oCierreSistema = AgenteContabilidad.Proxy.ObtenerCierreSistema(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Anio, Mes, 5);

                            if (oCierreSistema != null)
                            {
                                if (oCierreSistema.indCierre)
                                {
                                    if (item.FechaProvision <= oCierreSistema.FechaCierre)
                                    {
                                        Global.MensajeComunicacion("El sistema de Compras a esa fecha se encuentra cerrado");
                                        return;
                                    }
                                }
                            }

                            if (item.EsLiquidacion)
                            {
                                Global.MensajeComunicacion("No puede eliminar el asiento contable porque se trata de una Liquidación. Tiene que abrir su Liquidación en Tesoreria");
                                return;
                            }

                            if (item.EsRendicion)
                            {
                                Global.MensajeComunicacion("No puede eliminar el asiento contable porque se trata de una Rendición. Tiene que abrir su Rendición en Tesoreria");
                                return;
                            }

                            oListaProvision.Add(item);
                        }
                    }
                    
                    if (oListaProvision.Count > Variables.Cero)
                    {
                        Int32 resp = AgenteCtasPorPagar.Proxy.EliminarVoucherProvisionMasivo(oListaProvision, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            foreach (ProvisionesE item in oListaProvision)
                            {
                                bsprovisiones.Remove(item);
                            }

                            TotalChecks = bsprovisiones.Count;
                            TotalCheckeados = 0;
                            CheckBoxCab.Checked = false;
                            
                            Global.MensajeComunicacion("Se eliminaron todos los vouchers...");
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item antes de eliminar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TotalCheckeados > Variables.Cero)
                {
                    List<ProvisionesE> oListaProvision = new List<ProvisionesE>();

                    foreach (ProvisionesE item in bsprovisiones.List)
                    {
                        if (item.Check)
                        {
                            item.numVoucher = String.Empty;
                            oListaProvision.Add(item);
                        }
                    }

                    bsprovisiones.ResetBindings(false);

                    if (oListaProvision.Count > Variables.Cero)
                    {
                        Int32 resp = AgenteCtasPorPagar.Proxy.LimpiezaNrosVouchers(oListaProvision, VariablesLocales.SesionUsuario.Credencial);

                        if (resp > 0)
                        {
                            Global.MensajeComunicacion(String.Format("Se limpiaron los Nros de Vouchers de {0} registros.", resp.ToString()));
                        }
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que seleccionar algún item antes de limpiar los Nros de Vouchers.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvprovision_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvprovision_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvprovision.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvprovision[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvprovision_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvprovision.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvprovision.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvprovision_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaProvisiones.Count > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Por Id Provisión
                    if (e.ColumnIndex == dgvprovision.Columns["idProvision"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.idProvision ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.idProvision descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Fecha de provisión
                    if (e.ColumnIndex == dgvprovision.Columns["FechaProvision"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.FechaProvision ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.FechaProvision descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Razón Social
                    if (e.ColumnIndex == dgvprovision.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Número de Documentos
                    if (e.ColumnIndex == dgvprovision.Columns["NumDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.NumDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaProvisiones = (from x in oListaProvisiones orderby x.NumDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsprovisiones.DataSource = oListaProvisiones;
                bsprovisiones.ResetBindings(false);
            }
        }

        private void dgvprovision_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvprovision.Rows[e.RowIndex].Cells["EsLiquidacion"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(130, 171, 254);
                    }
                }

                if ((Boolean)dgvprovision.Rows[e.RowIndex].Cells["EsRendicion"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(146, 208, 80);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsprovisiones_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsprovisiones.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btDetracciones_Click(object sender, EventArgs e)
        {
            try
            {
                oListaProvisiones = (from x in oListaProvisiones
                                     where x.flagDetraccion == true 
                                     && x.indReversion == false
                                     select x).ToList();
                bsprovisiones.DataSource = oListaProvisiones;
                bsprovisiones.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiActualizarCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsprovisiones.Count > Variables.Cero)
                {
                    frmProvisiones oFrm = new frmProvisiones(((ProvisionesE)bsprovisiones.Current).idEmpresa, ((ProvisionesE)bsprovisiones.Current).idLocal, ((ProvisionesE)bsprovisiones.Current).idProvision, true)
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

    }
}
