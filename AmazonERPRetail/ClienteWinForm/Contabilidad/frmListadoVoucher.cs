using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using ClienteWinForm.Contabilidad.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoVoucher : FrmMantenimientoBase
    {

        #region Constructores

        public frmListadoVoucher()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            //pnlOpciones.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //cboLibro.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            //cboFile.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            if (VariablesLocales.PeriodoContable == null)
            {
                Global.MensajeComunicacion("El año vigente no se encuentra aperturado.");
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
                panel4.Enabled = false;
                panel5.Enabled = false;
            }
            else
            {
                LlenarCombos();
                this.Text = " Listado de Vouchers - Periodo Contable :" + VariablesLocales.PeriodoContable.AnioPeriodo;
            }

            FormatoGrid(dgvVouchers, true, false, 30);
            

             //if (OpcionSeguridad.Total || OpcionSeguridad.Eliminar)
             // {
             //   btEliminarRapido.Visible = true;
             // }
             //else
             // {
             //   btEliminarRapido.Visible = false;
             // }
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<VoucherE> ListarVouchers = null;
        //VoucherE oentidadvoucherexportar = null;
        List<VoucherItemE> olistaVoucherDetsolExportar = new List<VoucherItemE>();
        Boolean Ordenar = false;
        Int16 PrimerIngreso = Variables.Cero;
        String RutaExcel = String.Empty;
        String NombreAchivo = String.Empty;
        PeriodosE oPeriodoContable = null;

        //Para el check del datagridview
        Int32 TotalChecks = 0;
        Int32 TotalCheckeados = 0;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            ///Locales////
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                             where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                             select x).ToList();//AgenteMaestros.Proxy.ListarLocalPorEmpresa(VariablesLocales.SesionLocal.IdEmpresa, true, false);
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);

            cboSucursal.SelectedValue = Convert.ToInt32(VariablesLocales.SesionLocal.IdLocal);

            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);//AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp", false);
            cboLibro.SelectedValue = Variables.Cero.ToString();

            /////PERIODO////
            DataTable oDt = FechasHelper.CargarMesesContable("MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboPeriodo.DataSource = oDt;
            cboPeriodo.ValueMember = "MesId";
            cboPeriodo.DisplayMember = "MesDes";
            cboPeriodo.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            //////////////////////CAMPOS A FILTRAR ////////////
            List<ParTabla> ListaTmp = new List<ParTabla>();
            ListaTmp.Add(new ParTabla { IdParTabla = 1, Nombre = "Razón Social" });
            ListaTmp.Add(new ParTabla { IdParTabla = 2, Nombre = "Nro. Documento" });
            ListaTmp.Add(new ParTabla { IdParTabla = 3, Nombre = "Glosa General" });
            ListaTmp.Add(new ParTabla { IdParTabla = 4, Nombre = "Importes" });
            ListaTmp.Add(new ParTabla { IdParTabla = 5, Nombre = "Estado" });

            ComboHelper.RellenarCombos<List<ParTabla>>(cboFiltro, ListaTmp);

            List<ParTabla> ListaEstados = new List<ParTabla>();
            ListaEstados.Add(new ParTabla { IdParTabla = 1, Nombre = "Cuadrados" });
            ListaEstados.Add(new ParTabla { IdParTabla = 2, Nombre = "Descuadrados" });
            ListaEstados.Add(new ParTabla { IdParTabla = 3, Nombre = "Anulados" });
            ComboHelper.RellenarCombos<List<ParTabla>>(cboEstado, ListaEstados);

            cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
            ListaTipoComprobante = null;
        }

        void Limpiar(Boolean Habilita)
        {
            if (Habilita)
            {
                panel4.Enabled = Habilita;
            }
            else
            {
                bsListadoVouchers.DataSource = null;
                txtBuscar.Text = String.Empty;
                txtImporteMenor.Text = Variables.ValorCeroDecimal.ToString();
                txtImporteMayor.Text = Variables.ValorCeroDecimal.ToString();
                panel4.Enabled = Habilita;
            }
        }

        void FiltrarNumeros(TextBox txt1, TextBox txt2)
        {
            if (ListarVouchers != null)
            {
                Decimal MontoMayor = Variables.Cero;
                Decimal MontoMenor = Variables.Cero;
                Decimal.TryParse(txt1.Text, out MontoMenor);
                Decimal.TryParse(txt2.Text, out MontoMayor);

                if (MontoMenor > MontoMayor)
                {
                    Global.MensajeFault("El importe menor no puede ser mayor.");
                }
                else
                {
                    Buscar();
                    if (Ordenar)
                    {
                        ListarVouchers = (from x in ListarVouchers
                                          where x.impMonOrigDeb >= MontoMenor && x.impMonOrigDeb <= MontoMayor
                                          orderby x.impMonOrigDeb ascending
                                          select x).ToList();
                        Ordenar = false;
                    }
                    else
                    {
                        ListarVouchers = (from x in ListarVouchers
                                          where x.impMonOrigDeb >= MontoMenor && x.impMonOrigDeb <= MontoMayor
                                          orderby x.impMonOrigDeb descending
                                          select x).ToList();
                        Ordenar = true;
                    }

                    bsListadoVouchers.DataSource = ListarVouchers;
                    lblRegistros.Text = "Vouchers - " + bsListadoVouchers.Count.ToString() + " Registros";
                }
            }
        }

        void ExportarExcel(String Ruta)
        {
            try
            {
                String TituloGeneral = String.Empty;
                String NombrePestaña = String.Empty;

                TituloGeneral = NombreAchivo;
                NombrePestaña = "Voucher ";

                if (File.Exists(Ruta)) File.Delete(Ruta);
                FileInfo newFile = new FileInfo(Ruta);

                using (ExcelPackage oExcel = new ExcelPackage(newFile))
                {
                    ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);

                    if (oHoja != null)
                    {
                        Int32 InicioLinea = 9;

                        #region Cabecera

                        oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                        using (ExcelRange Rango = oHoja.Cells[1, 1, 1, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }

                        oHoja.Cells["A2"].Value = VariablesLocales.SesionUsuario.Empresa.DireccionCompleta;

                        using (ExcelRange Rango = oHoja.Cells[2, 1, 2, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }

                        oHoja.Cells["A3"].Value = "RUC: " + VariablesLocales.SesionUsuario.Empresa.RUC;

                        using (ExcelRange Rango = oHoja.Cells[3, 1, 3, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }

                        oHoja.Cells["A5"].Value = "Moneda: " + olistaVoucherDetsolExportar[0].desMoneda;

                        using (ExcelRange Rango = oHoja.Cells[5, 1, 5, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }

                        oHoja.Cells["A6"].Value = "Fecha Doc:  " + Convert.ToDateTime(olistaVoucherDetsolExportar[0].fecOperacion).ToString("dd/MM/yyyy") + "       " + "   Glosa:  " + olistaVoucherDetsolExportar[0].GlosaGeneral;

                        using (ExcelRange Rango = oHoja.Cells[6, 1, 6, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }

                        oHoja.Cells["A7"].Value = "Glosa:  " + olistaVoucherDetsolExportar[0].GlosaGeneral;

                        using (ExcelRange Rango = oHoja.Cells[7, 1, 7, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }

                        oHoja.Cells["E1"].Value = "LIBRO " + olistaVoucherDetsolExportar[0].idComprobante + " " + olistaVoucherDetsolExportar[0].desComprobante;

                        using (ExcelRange Rango = oHoja.Cells[1, 5, 1, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells["E2"].Value = "FILE " + olistaVoucherDetsolExportar[0].numFile + " " + olistaVoucherDetsolExportar[0].desFile;

                        using (ExcelRange Rango = oHoja.Cells[2, 5, 2, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells["E3"].Value = "Del año: " + olistaVoucherDetsolExportar[0].AnioPeriodo + "-Periodo " + olistaVoucherDetsolExportar[0].MesPeriodo + "-Voucher " + olistaVoucherDetsolExportar[0].numVoucher;

                        using (ExcelRange Rango = oHoja.Cells[3, 5, 3, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells["L1"].Value = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

                        using (ExcelRange Rango = oHoja.Cells[1, 12, 1, 13])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        oHoja.Cells["L2"].Value = "Hora: " + DateTime.Now.ToString("hh:mm:ss");

                        using (ExcelRange Rango = oHoja.Cells[2, 12, 2, 13])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        }

                        #region Primera Cabecera

                        oHoja.Cells[InicioLinea, 1].Value = "ITEM";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 1, InicioLinea + 1, 1])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 2].Value = "COD.";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea + 1, 2])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 3].Value = "CUENTA";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 3, InicioLinea + 1, 3])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 4].Value = "R";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 4, InicioLinea + 1, 4])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 5].Value = "AUXILIAR";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 5, InicioLinea + 1, 5])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 6].Value = "C.C.";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 6, InicioLinea + 1, 6])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 7].Value = "DOCUMENTO";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 7, InicioLinea + 1, 7])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 8].Value = "FEC. EMIS.";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 8, InicioLinea + 1, 8])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 9].Value = "T.C.";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 9, InicioLinea + 1, 9])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 10].Value = "SOLES S/.";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 10, InicioLinea, 11])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        oHoja.Cells[InicioLinea, 12].Value = "DOLARES US$";

                        using (ExcelRange Rango = oHoja.Cells[InicioLinea, 12, InicioLinea, 13])
                        {
                            Rango.Merge = true;
                            Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            Rango.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            Rango.Style.Font.Bold = true;
                        }

                        for (Int32 i = 1; i <= 13; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        #endregion

                        InicioLinea++;

                        #region 2da linea

                        oHoja.Cells[InicioLinea, 10].Value = "DEBE";
                        oHoja.Cells[InicioLinea, 11].Value = "HABER";
                        oHoja.Cells[InicioLinea, 12].Value = "DEBE";
                        oHoja.Cells[InicioLinea, 13].Value = "HABER";

                        for (Int32 i = 1; i <= 13; i++)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                            oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                            oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        }

                        //InicioLinea++;

                        #endregion

                        #endregion Cabecera

                        #region Detalle

                        //Aumentando una Fila mas continuar con el detalle
                        InicioLinea++;

                        String fecVencimiento = String.Empty;
                        DateTime? fecDocumento;
                        String numDocumento = String.Empty;
                        Decimal DebeSoles = Variables.Cero;
                        Decimal DebeDolares = Variables.Cero;
                        Decimal HaberSoles = Variables.Cero;
                        Decimal HaberDolares = Variables.Cero;

                        foreach (VoucherItemE item in (from x in olistaVoucherDetsolExportar orderby x.numItem select x).ToList())
                        {
                            oHoja.Cells[InicioLinea, 1].Value = item.numItem;
                            oHoja.Cells[InicioLinea, 2].Value = item.codCuenta;
                            oHoja.Cells[InicioLinea, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            oHoja.Cells[InicioLinea, 3].Value = item.desCuenta;
                            oHoja.Cells[InicioLinea, 4].Value = item.indReparable;
                            oHoja.Cells[InicioLinea, 5].Value = item.RazonSocial;
                            oHoja.Cells[InicioLinea, 6].Value = item.idCCostos;

                            if (!String.IsNullOrEmpty(item.idDocumento))
                            {
                                numDocumento = item.idDocumento + " ";
                            }

                            if (!String.IsNullOrEmpty(item.serDocumento))
                            {
                                if (item.serDocumento != "0000")
                                    numDocumento += item.serDocumento + "-";
                            }

                            if (!String.IsNullOrEmpty(item.numDocumento))
                            {
                                numDocumento += item.numDocumento;
                            }

                            oHoja.Cells[InicioLinea, 7].Value = numDocumento;

                            if (item.fecDocumento != null)
                            {
                                fecDocumento = item.fecDocumento;
                                oHoja.Cells[InicioLinea, 8].Value = fecDocumento;
                                oHoja.Cells[InicioLinea, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                                oHoja.Cells[InicioLinea, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                            }

                            oHoja.Cells[InicioLinea, 9].Value = item.tipCambio;
                            oHoja.Cells[InicioLinea, 9].Style.Numberformat.Format = "##0.000";

                            if (item.indDebeHaber == Variables.Haber)
                            {
                                oHoja.Cells[InicioLinea, 10].Value = 0.00;
                                oHoja.Cells[InicioLinea, 11].Value = item.impSoles;
                                oHoja.Cells[InicioLinea, 12].Value = 0.00;
                                oHoja.Cells[InicioLinea, 13].Value = item.impDolares;

                                HaberSoles += item.impSoles;
                                HaberDolares += item.impDolares;
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, 10].Value = item.impSoles;
                                oHoja.Cells[InicioLinea, 11].Value = 0.00;
                                oHoja.Cells[InicioLinea, 12].Value = item.impDolares;
                                oHoja.Cells[InicioLinea, 13].Value = 0.00;

                                DebeSoles += item.impSoles;
                                DebeDolares += item.impDolares;
                            }

                            oHoja.Cells[InicioLinea, 10, InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";

                            InicioLinea++;
                        }

                        oHoja.Cells[InicioLinea, 10].Value = "_______";
                        oHoja.Cells[InicioLinea, 11].Value = "_______";
                        oHoja.Cells[InicioLinea, 12].Value = "_______";
                        oHoja.Cells[InicioLinea, 13].Value = "_______";

                        InicioLinea++;

                        oHoja.Cells[InicioLinea, 10].Value = DebeSoles;
                        oHoja.Cells[InicioLinea, 11].Value = HaberSoles;
                        oHoja.Cells[InicioLinea, 12].Value = DebeDolares;
                        oHoja.Cells[InicioLinea, 13].Value = HaberDolares;
                        oHoja.Cells[InicioLinea, 10, InicioLinea, 13].Style.Numberformat.Format = "###,###,##0.00";

                        InicioLinea++;

                        #endregion

                        //Ajustando el ancho de las columnas automaticamente
                        oHoja.Cells.AutoFitColumns();

                        //Insertando Encabezado
                        oHoja.HeaderFooter.OddHeader.CenteredText = VariablesLocales.SesionUsuario.Empresa.RazonSocial + " - " + TituloGeneral;
                        //Pie de Pagina(Derecho) "Número de paginas y el total"
                        oHoja.HeaderFooter.OddFooter.RightAlignedText = String.Format("Pag. {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                        //Pie de Pagina(centro)
                        oHoja.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                        //Otras Propiedades
                        oHoja.Workbook.Properties.Title = TituloGeneral;
                        oHoja.Workbook.Properties.Author = "AMAZONTIC SAC";
                        oHoja.Workbook.Properties.Subject = "Reportes";
                        oHoja.Workbook.Properties.Category = "Modulo de Contabilidad";
                        oHoja.Workbook.Properties.Comments = "Voucher";

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
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
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

            foreach (DataGridViewRow Row in dgvVouchers.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Check"]).Value = HCheckBox.Checked;
            }

            dgvVouchers.RefreshEdit();
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
            dgvVouchers.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvVouchers.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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
                if (!ValidarIngresoVentana())
                {
                    return;
                }
                
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmVoucher(Convert.ToInt32(cboSucursal.SelectedValue), cboPeriodo.SelectedValue.ToString(), cboLibro.SelectedValue.ToString(), cboFile.SelectedValue.ToString())
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
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                VoucherE Voucher = (VoucherE)bsListadoVouchers.Current;

                if (Voucher != null)
                {
                    oFrm = new frmVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile)
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

        public override void Anular()
        {
            try
            {
                VoucherE current = (VoucherE)bsListadoVouchers.Current;

                if (current != null)
                {
                    oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, current.AnioPeriodo, current.MesPeriodo);

                    if (oPeriodoContable.indCierre)
                    {
                        Global.MensajeComunicacion("El mes se encuentra cerrado. No puede Eliminar registros.");
                        return;
                    }

                    List<VoucherE> oListaVouchers = null;
                    ComprobantesE com = null;
                    ComprobantesFileE file = null;
                    Int32 cantItems = 0;

                    if (TotalCheckeados > 0)
                    {
                        oListaVouchers = new List<VoucherE>();

                        foreach (VoucherE item in bsListadoVouchers.List)
                        {
                            if (item.Check)
                            {
                                oListaVouchers.Add(item);
                            }
                        }
                    }

                    if (oListaVouchers == null || oListaVouchers.Count == 0)
                    {
                        if (current.numItems != null || current.numItems > 0)
                        {


                            cantItems = current.numItems.Value;

                            com = (from x in VariablesLocales.oListaComprobantes
                                   where x.idComprobante == current.idComprobante
                                   select x).FirstOrDefault();

                            file = (from x in com.ListaComprobantesFiles
                                    where x.numFile == current.numFile
                                    select x).FirstOrDefault();

                            if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                            {
                                if (file.flagAutomatico)
                                {
                                    if (VariablesLocales.oConParametros.indEliminarVoucher)
                                    {
                                        Global.MensajeComunicacion("Este File es Automático no puede eliminar...!!!");
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("Este File es Automático no puede Anular...!!!");
                                    }

                                    return;
                                }
                            }

                            if (cantItems > 50)
                            {
                                Global.MensajeAdvertencia("Por la cantidad de Items que tiene el voucher, tiene que mayorizar manualmente.");
                            }
                        }

                        if (!current.EsAutomatico)
                        {
                            if (VariablesLocales.oConParametros.indEliminarVoucher)
                            {
                                if (Global.MensajeConfirmacion(String.Format("Desea eliminar el Voucher {0}", current.numVoucher)) == DialogResult.Yes)
                                {
                                    AgenteContabilidad.Proxy.AnularVoucher(current, VariablesLocales.SesionUsuario.Credencial, "E");
                                    bsListadoVouchers.Remove(current);
                                    ListarVouchers.Remove(current);
                                    Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                                    base.Anular();
                                }
                            }
                            else
                            {
                                if (Global.MensajeConfirmacion(String.Format("Desea anular el Voucher {0}", current.numVoucher)) == DialogResult.Yes)
                                {
                                    AgenteContabilidad.Proxy.AnularVoucher(current, VariablesLocales.SesionUsuario.Credencial, "A");
                                    Buscar();
                                    Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                                    base.Anular();
                                }
                            }
                        }
                        else
                        {
                            if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                            {
                                AgenteContabilidad.Proxy.AnularVoucher(current, VariablesLocales.SesionUsuario.Credencial, "E");
                                bsListadoVouchers.Remove(current);
                                ListarVouchers.Remove(current);
                                Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                                base.Anular();
                            }
                            else
                            {
                                Global.MensajeComunicacion("No se puede eliminar porque este asiento se generó desde otro módulo.");
                            }
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(String.Format("Eliminar masivamente {0} los voucher(s) escogidos", oListaVouchers.Count())) == DialogResult.Yes)
                        {
                            String Auto = "ok";

                            foreach (VoucherE item in oListaVouchers)
                            {
                                com = (from x in VariablesLocales.oListaComprobantes
                                       where x.idComprobante == item.idComprobante
                                       select x).FirstOrDefault();

                                file = (from x in com.ListaComprobantesFiles
                                        where x.numFile == item.numFile
                                        select x).FirstOrDefault();

                                if (file.flagAutomatico)
                                {
                                    Auto = "rev";

                                    if (VariablesLocales.oConParametros.indEliminarVoucher)
                                    {
                                        Global.MensajeComunicacion("Este File es Automático no puede Eliminar...!!!");
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("Este File es Automático no puede Anular...!!!");
                                    }

                                    return;
                                }
                                else
                                {
                                    if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                                    {
                                        if (item.EsAutomatico)
                                        {
                                            Auto = "rev";

                                            if (VariablesLocales.oConParametros.indEliminarVoucher)
                                            {
                                                Global.MensajeComunicacion("No se puede eliminar porque este asiento se generó desde otro módulo.");
                                            }
                                            else
                                            {
                                                Global.MensajeComunicacion("No se puede Anular porque este asiento se generó desde otro módulo.");
                                            }

                                            return;
                                        }
                                    }
                                }
                            }

                            if (Auto == "ok")
                            {
                                Int32 resp = 0;
                                cantItems = Convert.ToInt32(ListarVouchers.Sum(x => x.numItems));

                                if (cantItems > 50)
                                {
                                    Global.MensajeAdvertencia("Por la cantidad de Items que tiene los vouchers, tiene que mayorizar manualmente.");
                                }

                                if (VariablesLocales.oConParametros.indEliminarVoucher)
                                {
                                    resp = AgenteContabilidad.Proxy.EliminarVoucherMasivo(oListaVouchers, String.Empty, "S");
                                }
                                else
                                {
                                    resp = AgenteContabilidad.Proxy.EliminarVoucherMasivo(oListaVouchers, VariablesLocales.SesionUsuario.Credencial, "N");
                                }

                                if (resp > 0)
                                {
                                    Buscar();

                                    if (VariablesLocales.oConParametros.indEliminarVoucher)
                                    {
                                        Global.MensajeComunicacion("Los vouchers se eliminaron correctamente.");
                                    }
                                    else
                                    {
                                        Global.MensajeComunicacion("Los vouchers se anularon correctamente.");
                                    }
                                }
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

        public override void Buscar()
        {
            try
            {
                if (PrimerIngreso > Variables.Cero)
                {
                    String Periodo = cboPeriodo.SelectedValue.ToString();
                    String Libro = cboLibro.SelectedValue.ToString();
                    String File = cboFile.SelectedValue.ToString();

                    if (Periodo == Variables.Cero.ToString())
                    {
                        Periodo = "%%";
                    }

                    if (Libro == Variables.Cero.ToString())
                    {
                        Libro = "%%";
                    }

                    if (File == Variables.Cero.ToString())
                    {
                        File = "%%";
                    }

                    ListarVouchers = AgenteContabilidad.Proxy.ListarVoucher(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboSucursal.SelectedValue), VariablesLocales.PeriodoContable.AnioPeriodo,
                                                                            Periodo, Libro, File);
                    bsListadoVouchers.DataSource = ListarVouchers;
                    bsListadoVouchers.ResetBindings(false);

                    Limpiar(true);
                    txtBuscar_KeyDown(null, null);

                    CheckBoxCab.Checked = false;
                    HeaderCheckBoxClick(CheckBoxCab);

                    TotalChecks = dgvVouchers.RowCount;
                    TotalCheckeados = 0;
                }

                PrimerIngreso++;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override Boolean ValidarIngresoVentana()
        {
            // henry 
            ParametrosContaE oParametros = AgenteContabilidad.Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);

            if (oParametros == null || oParametros.Ganancia.Length == 0 || oParametros.Perdida.Length == 0 )
            {
                Global.MensajeComunicacion("No puede registrar Voucher, configure los parametros de contabilidad");

                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmParametrosConta);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    
                }

                oFrm = new frmParametrosConta
                {
                    MdiParent = this.MdiParent
                };

                oFrm.Show();

                return false;
            }

            if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeComunicacion("Debe escoger un Libro.");
                return false;
            }

            if (cboFile.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeComunicacion("Debe escoger un File.");
                return false;
            }

            if (cboPeriodo.SelectedValue.ToString() == Variables.Cero.ToString())
            {
                Global.MensajeComunicacion("Debe escoger un Periodo.");
                return false;
            }

            return base.ValidarIngresoVentana();
        }

        public override void Imprimir()
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

                List<VoucherE> oListaVouchers = null;

                if (TotalCheckeados > 0)
                {
                    oListaVouchers = new List<VoucherE>();

                    foreach (VoucherE item in bsListadoVouchers.List)
                    {
                        if (item.Check)
                        {
                            oListaVouchers.Add(item);
                        }
                    }
                }

                if (oListaVouchers != null)
                {
                    oFrm = new frmImpresionVoucher("N", oListaVouchers)
                    {
                        MdiParent = this.MdiParent
                    };
                    oFrm.Show();
                }
                else
	            {
                    oFrm = new frmImpresionVoucher("N", (VoucherE)bsListadoVouchers.Current)
                    {
                        MdiParent = this.MdiParent
                    };
                    oFrm.Show();
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
                olistaVoucherDetsolExportar = AgenteContabilidad.Proxy.VoucherDetalle(((VoucherE)bsListadoVouchers.Current).idEmpresa, ((VoucherE)bsListadoVouchers.Current).idLocal, ((VoucherE)bsListadoVouchers.Current).AnioPeriodo, ((VoucherE)bsListadoVouchers.Current).MesPeriodo, ((VoucherE)bsListadoVouchers.Current).numVoucher, ((VoucherE)bsListadoVouchers.Current).idComprobante, ((VoucherE)bsListadoVouchers.Current).numFile);

                if (olistaVoucherDetsolExportar == null || olistaVoucherDetsolExportar.Count == Variables.Cero)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                NombreAchivo = "Voucher " + ((VoucherE)bsListadoVouchers.Current).idComprobante + " " + ((VoucherE)bsListadoVouchers.Current).numFile + " " + ((VoucherE)bsListadoVouchers.Current).numVoucher;
                RutaExcel = CuadrosDialogo.GuardarDocumento("Guardar en", NombreAchivo, "Archivos Excel (*.xlsx)|*.xlsx");

                if (RutaExcel != "")
                {
                    ExportarExcel(RutaExcel);
                    Global.MensajeComunicacion("Voucher Exportado!!!");
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
            frmVoucher oFrm = sender as frmVoucher;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                if (ListarVouchers != null)
                {
                    if (oFrm.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        for (Int32 i = 0; i < ListarVouchers.Count - 1; i++)
                        {
                            if (ListarVouchers[i].idEmpresa == oFrm.oVoucher.idEmpresa && ListarVouchers[i].idLocal == oFrm.oVoucher.idLocal
                                && ListarVouchers[i].AnioPeriodo == oFrm.oVoucher.AnioPeriodo && ListarVouchers[i].MesPeriodo == oFrm.oVoucher.MesPeriodo
                                && ListarVouchers[i].numVoucher == oFrm.oVoucher.numVoucher && ListarVouchers[i].idComprobante == oFrm.oVoucher.idComprobante
                                && ListarVouchers[i].numFile == oFrm.oVoucher.numFile)
                            {
                                ListarVouchers[i] = oFrm.oVoucher;
                                i = ListarVouchers.Count;
                            }
                        }
                    }
                    else
                    {
                        ListarVouchers.Add(oFrm.oVoucher);
                        bsListadoVouchers.MovePrevious();
                    }

                    bsListadoVouchers.DataSource = ListarVouchers;
                    bsListadoVouchers.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Eventos

        private void ListadoVoucher_Load(object sender, EventArgs e)
        {
            Grid = true;
            Global.CrearToolTip(btImprimirEgreso, "Imprimir Voucher Egreso...");
            //Global.CrearToolTip(btEliminarRapido, "Eliminar Rapido Voucher de Volumenes Grandes (Despues debe Mayorizar) ...");

            if (VariablesLocales.PeriodoContable != null)
            {
                base.Grabar();
                BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
                BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            }
            else
            {
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }

            AñadirCheckBox();
            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles)
                    {
                        new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                    };//AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

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

                    Limpiar(false);
                    ListaFiles = null;
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   

        private void dgvVouchers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((String)dgvVouchers.Rows[e.RowIndex].Cells["indEstado"].Value == "A")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorAnulado;
                }
            }
            else if ((String)dgvVouchers.Rows[e.RowIndex].Cells["indEstado"].Value == "D")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorDescuadrado;
                }
            }
        }

        private void dgvVouchers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != - 1)
            {
                if (e.ColumnIndex != 0)
                {
                    Editar(); 
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            //if (ListarVouchers != null)
            //{
            //    if (txtBuscar.Text.Length > 0)
            //    {
            //        if (Convert.ToInt32(cboFiltro.SelectedValue) == 1)
            //        {
            //            ListarVouchers = (from x in ListarVouchers where x.RazonSocial.ToUpper().Contains(txtBuscar.Text.ToUpper()) select x).ToList();
            //            //ListarVouchers.Find(x => x.RazonSocial.Contains(txtBuscar.Text.ToUpper()));
            //        }
            //        else if (Convert.ToInt32(cboFiltro.SelectedValue) == 2)
            //        {
            //            ListarVouchers = (from x in ListarVouchers where x.numDocumentoPresu.Contains(txtBuscar.Text.ToUpper()) orderby x.numDocumentoPresu ascending select x).ToList();
            //        }
            //        else if (Convert.ToInt32(cboFiltro.SelectedValue) == 3)
            //        {
            //            ListarVouchers = (from x in ListarVouchers where x.GlosaGeneral.Contains(txtBuscar.Text.ToUpper()) orderby x.GlosaGeneral ascending select x).ToList();
            //        }

            //        bsListadoVouchers.DataSource = ListarVouchers;
            //        bsListadoVouchers.ResetBindings(false);
            //        lblRegistros.Text = "Vouchers - " + bsListadoVouchers.Count.ToString() + " Registros";
            //    }
            //    else
            //    {
            //        Buscar();
            //    }
            //}
        }

        private void btFiltrarNumeros_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboFiltro.SelectedValue) == 4)
            {
                if (txtImporteMayor.Text.Length > 0)
                {
                    FiltrarNumeros(txtImporteMenor, txtImporteMayor);
                }
                else
                {
                    Buscar();
                }
            }
        }

        private void txtImporteMenor_TextChanged(object sender, EventArgs e)
        {
            if (txtImporteMenor.Text.Length == Variables.Cero)
            {
                Buscar();
            }
        }

        private void txtImporteMayor_TextChanged(object sender, EventArgs e)
        {
            if (txtImporteMayor.Text.Length == Variables.Cero)
            {
                Buscar();
            }
        }

        private void cboFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboFiltro.SelectedValue) == 4)
            {
                txtImporteMenor.Visible = true;
                txtImporteMayor.Visible = true;
                lblDe.Text = "De ";
                lblDe.Visible = true;
                label10.Visible = true;
                txtBuscar.Text = String.Empty;
                txtBuscar.Visible = false;
                btFiltrarNumeros.Visible = true;
                cboEstado.Visible = false;

                txtImporteMenor.Focus();
                txtImporteMenor.SelectAll();
            }
            else if (Convert.ToInt32(cboFiltro.SelectedValue) == 5)
            {
                txtImporteMenor.Text = String.Empty;
                txtImporteMenor.Visible = false;
                txtImporteMayor.Text = String.Empty;
                txtImporteMayor.Visible = false;
                lblDe.Text = "Estado ";
                lblDe.Visible = true;
                label10.Visible = false;
                btFiltrarNumeros.Visible = false;
                txtBuscar.Visible = false;
                cboEstado.Visible = true;
                cboEstado_SelectionChangeCommitted(new Object(), new EventArgs());

                cboEstado.Focus();
            }
            else
            {
                txtImporteMenor.Text = String.Empty;
                txtImporteMenor.Visible = false;
                txtImporteMayor.Text = String.Empty;
                txtImporteMayor.Visible = false;
                lblDe.Visible = false;
                label10.Visible = false;
                txtBuscar.Visible = true;
                btFiltrarNumeros.Visible = false;
                cboEstado.Visible = false;

                txtBuscar.Focus();
                txtBuscar.SelectAll();
            }            
        }

        private void dgvVouchers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ListarVouchers != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR FILE
                    if (e.ColumnIndex == dgvVouchers.Columns["numFileDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.numFile ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.numFile descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR DECRIPCION FILE
                    if (e.ColumnIndex == dgvVouchers.Columns["desFile"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.desFile ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.desFile descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA OPE.
                    if (e.ColumnIndex == dgvVouchers.Columns["fecOperacion"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.fecOperacion ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.fecOperacion descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA DE DOCUMENTO
                    if (e.ColumnIndex == dgvVouchers.Columns["fecDocumentoDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.fecDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.fecDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                    
                    // POR VOUCHER
                    if (e.ColumnIndex == dgvVouchers.Columns["numVoucherDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.numVoucher ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.numVoucher descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR RAZON SOCIAL
                    if (e.ColumnIndex == dgvVouchers.Columns["razonSocialDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR DOCUMENTO
                    if (e.ColumnIndex == dgvVouchers.Columns["numDocumentoPresuDataGridViewTextBoxColumn"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.numDocumentoPresu ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.numDocumentoPresu descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR MONEDA
                    if (e.ColumnIndex == dgvVouchers.Columns["desMoneda"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.desMoneda ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.desMoneda descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR IMPORTE
                    if (e.ColumnIndex == dgvVouchers.Columns["impMonOrigHab"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.impMonOrigHab ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.impMonOrigHab descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                    if (e.ColumnIndex == dgvVouchers.Columns["UsuarioRegistro"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.UsuarioRegistro ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.UsuarioRegistro descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                    if (e.ColumnIndex == dgvVouchers.Columns["FechaRegistro"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.FechaRegistro ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.FechaRegistro descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvVouchers.Columns["UsuarioModificacion"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.UsuarioModificacion ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.UsuarioModificacion descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    if (e.ColumnIndex == dgvVouchers.Columns["FechaModificacion"].Index)
                    {
                        if (Ordenar)
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.FechaModificacion ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            ListarVouchers = (from x in ListarVouchers orderby x.FechaModificacion descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                }

                bsListadoVouchers.DataSource = ListarVouchers;
            }
        }

        private void cboFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpiar(false);
            Buscar();
        }

        private void cboPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpiar(false);
            Buscar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (ListarVouchers != null && ListarVouchers.Count > Variables.Cero)
            {
                if (Convert.ToInt32(cboFiltro.SelectedValue) == 1)
                {
                    List<VoucherE> res = (from x in ListarVouchers 
                                            where x.RazonSocial.ToUpper().Contains(txtBuscar.Text.ToUpper()) 
                                            select x).ToList();

                    bsListadoVouchers.DataSource = res;
                }
                else if (Convert.ToInt32(cboFiltro.SelectedValue) == 2)
                {
                    List<VoucherE> res = (from x in ListarVouchers 
                                            where x.numDocumentoPresu.ToUpper().Contains(txtBuscar.Text.ToUpper()) 
                                            select x).ToList();

                    bsListadoVouchers.DataSource = res;
                }
                else if (Convert.ToInt32(cboFiltro.SelectedValue) == 3)
                {
                    List<VoucherE> res = (from x in ListarVouchers 
                                            where x.GlosaGeneral.ToUpper().Contains(txtBuscar.Text.ToUpper()) 
                                            select x).ToList();

                    bsListadoVouchers.DataSource = res;
                }

                //bsListadoVouchers.ResetBindings(false);
                lblRegistros.Text = "Vouchers - " + bsListadoVouchers.Count.ToString() + " Registros";
            }
        }

        private void btImprimirEgreso_Click(object sender, EventArgs e)
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

                //Caja Egresos e ingresos
                if (cboLibro.SelectedValue.ToString() == "04" || cboLibro.SelectedValue.ToString()=="05")
	            {
		            oFrm = new frmImpresionVoucher("E", (VoucherE)bsListadoVouchers.Current);
	            }
                else
                {
                    oFrm = new frmImpresionVoucher("N", (VoucherE)bsListadoVouchers.Current);
                }

                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ListarVouchers != null && ListarVouchers.Count > Variables.Cero)
            {
                if (Convert.ToInt32(cboEstado.SelectedValue) == 1) //Vouchers Cuadrados
                {
                    List<VoucherE> res = (from x in ListarVouchers
                                          where x.indEstado.ToUpper().Contains("C")
                                          select x).ToList();

                    bsListadoVouchers.DataSource = res;
                }
                else if (Convert.ToInt32(cboEstado.SelectedValue) == 2) //Vouchers Descuadrados
                {
                    List<VoucherE> res = (from x in ListarVouchers
                                          where x.indEstado.ToUpper().Contains("D")
                                          select x).ToList();

                    bsListadoVouchers.DataSource = res;
                }
                else if (Convert.ToInt32(cboEstado.SelectedValue) == 3) //Vouchers Anulados
                {
                    List<VoucherE> res = (from x in ListarVouchers
                                          where x.indEstado.ToUpper().Contains("A")
                                          select x).ToList();

                    bsListadoVouchers.DataSource = res;
                }

                //bsListadoVouchers.ResetBindings(false);
                lblRegistros.Text = "Vouchers - " + bsListadoVouchers.Count.ToString() + " Registros";
            }
        }

        private void cboLibro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            SendKeys.Send("{F4}");
        }

        private void cboFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
            SendKeys.Send("{F4}");
        }

        private void dgvVouchers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvVouchers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVouchers.Rows.Count != 0)
            {
                if (!indClickCab && e.ColumnIndex == 0)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvVouchers[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvVouchers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVouchers.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvVouchers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void bsListadoVouchers_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblRegistros.Text = "Registros " + bsListadoVouchers.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cancelaAutomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListarVouchers.Count != 0)
                {
                    VoucherE Voucher = (VoucherE)bsListadoVouchers.Current;

                    frmCancelacionVoucherCompras oFrm = new frmCancelacionVoucherCompras(Voucher);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVoucherItem != null)
                    {
                        VoucherE oVoucherRes = AgenteContabilidad.Proxy.GenerarVoucherCancelacionCompra(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile, oFrm.oVoucherItem);
                        Global.MensajeComunicacion("Los vouchers de cancelación se generaron correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void copiarVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListarVouchers.Count != 0)
                {
                    VoucherE Voucher = (VoucherE)bsListadoVouchers.Current;

                    frmCopiarVoucherCompras oFrm = new frmCopiarVoucherCompras(Voucher);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oVoucherItem != null)
                    {
                        VoucherE oVoucherRes = AgenteContabilidad.Proxy.GenerarVoucherCopia(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile, oFrm.oVoucherItem);
                        Global.MensajeComunicacion("El vouhcer se copió correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarRapido_Click(object sender, EventArgs e)
        {
            try
            {
                //VoucherE VoucherTmp = (VoucherE)bsListadoVouchers.Current;

                //if (VoucherTmp != null)
                //{
                //    oPeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VoucherTmp.AnioPeriodo, VoucherTmp.MesPeriodo);

                //    if (oPeriodoContable.indCierre)
                //    {
                //        Global.MensajeComunicacion("El mes se encuentra cerrado. No puede Eliminar registros.");
                //        return;
                //    }

                //    List<VoucherE> oListaVouchers = null;
                //    ComprobantesE com = null;
                //    ComprobantesFileE file = null;

                //    if (TotalCheckeados > 0)
                //    {
                //        oListaVouchers = new List<VoucherE>();

                //        foreach (VoucherE item in bsListadoVouchers.List)
                //        {
                //            if (item.Check)
                //            {
                //                oListaVouchers.Add(item);
                //            }
                //        }
                //    }

                //    if (oListaVouchers == null || oListaVouchers.Count == 0)
                //    {
                //        VoucherE Voucher = (VoucherE)bsListadoVouchers.Current;

                //        com = (from x in VariablesLocales.oListaComprobantes
                //               where x.idComprobante == ((VoucherE)bsListadoVouchers.Current).idComprobante
                //               select x).FirstOrDefault();

                //        file = (from x in com.ListaComprobantesFiles
                //                where x.numFile == ((VoucherE)bsListadoVouchers.Current).numFile
                //                select x).FirstOrDefault();

                //        if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                //        {
                //            if (file.flagAutomatico)
                //            {
                //                if (VariablesLocales.oConParametros.indEliminarVoucher)
                //                {
                //                    Global.MensajeComunicacion("Este File es Automático no puede eliminar...!!!");
                //                }
                //                else
                //                {
                //                    Global.MensajeComunicacion("Este File es Automático no puede Anular...!!!");
                //                }

                //                return;
                //            }
                //        }

                //        if (Voucher != null)
                //        {
                //            if (!Voucher.EsAutomatico)
                //            {
                //                if (VariablesLocales.oConParametros.indEliminarVoucher)
                //                {
                //                    if (Global.MensajeConfirmacion(String.Format("Desea eliminar el Voucher {0}", Voucher.numVoucher)) == DialogResult.Yes)
                //                    {
                //                        AgenteContabilidad.Proxy.AnularVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile, VariablesLocales.SesionUsuario.Credencial, "E");
                //                        bsListadoVouchers.Remove(Voucher);
                //                        ListarVouchers.Remove(Voucher);
                //                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                //                        base.Anular();
                //                    }
                //                }
                //                else
                //                {
                //                    if (Global.MensajeConfirmacion(String.Format("Desea anular el Voucher {0}", Voucher.numVoucher)) == DialogResult.Yes)
                //                    {
                //                        AgenteContabilidad.Proxy.AnularVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile, VariablesLocales.SesionUsuario.Credencial, "A");
                //                        Buscar();
                //                        Global.MensajeComunicacion(Mensajes.AnulacionCorrecta);
                //                        base.Anular();
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                //                {
                //                    if (Global.MensajeConfirmacion(String.Format("Desea eliminar el Voucher {0}", Voucher.numVoucher)) == DialogResult.Yes)
                //                    {
                //                        AgenteContabilidad.Proxy.AnularVoucher(Voucher.idEmpresa, Voucher.idLocal, Voucher.AnioPeriodo, Voucher.MesPeriodo, Voucher.numVoucher, Voucher.idComprobante, Voucher.numFile, VariablesLocales.SesionUsuario.Credencial, "E");
                //                        bsListadoVouchers.Remove(Voucher);
                //                        ListarVouchers.Remove(Voucher);
                //                        Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                //                        base.Anular();
                //                    }
                //                }
                //                else
                //                {
                //                    Global.MensajeComunicacion("No se puede eliminar porque este asiento se generó desde otro módulo.");
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (Global.MensajeConfirmacion(String.Format("Eliminar masivamente {0} los voucher(s) escogidos", oListaVouchers.Count())) == DialogResult.Yes)
                //        {
                //            String Auto = "ok";

                //            foreach (VoucherE item in oListaVouchers)
                //            {
                //                com = (from x in VariablesLocales.oListaComprobantes
                //                       where x.idComprobante == item.idComprobante
                //                       select x).FirstOrDefault();

                //                file = (from x in com.ListaComprobantesFiles
                //                        where x.numFile == item.numFile
                //                        select x).FirstOrDefault();

                //                if (file.flagAutomatico)
                //                {
                //                    Auto = "rev";

                //                    if (VariablesLocales.oConParametros.indEliminarVoucher)
                //                    {
                //                        Global.MensajeComunicacion("Este File es Automático no puede Eliminar...!!!");
                //                    }
                //                    else
                //                    {
                //                        Global.MensajeComunicacion("Este File es Automático no puede Anular...!!!");
                //                    }

                //                    return;
                //                }
                //                else
                //                {
                //                    if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                //                    {
                //                        if (item.EsAutomatico)
                //                        {
                //                            Auto = "rev";

                //                            if (VariablesLocales.oConParametros.indEliminarVoucher)
                //                            {
                //                                Global.MensajeComunicacion("No se puede eliminar porque este asiento se generó desde otro módulo.");
                //                            }
                //                            else
                //                            {
                //                                Global.MensajeComunicacion("No se puede Anular porque este asiento se generó desde otro módulo.");
                //                            }

                //                            return;
                //                        }
                //                    }
                //                }
                //            }

                //            if (Auto == "ok")
                //            {
                //                Int32 resp = 0;

                //                resp = AgenteContabilidad.Proxy.EliminarVoucherMasivoRapido(oListaVouchers, VariablesLocales.SesionUsuario.Credencial);

                //                if (resp > 0)
                //                {
                //                    Buscar();

                //                    Global.MensajeComunicacion("Los vouchers se eliminaron correctamente. Ahora Debe Mayorizar Su Contabilidad !!");

                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Eventos

    }
}
