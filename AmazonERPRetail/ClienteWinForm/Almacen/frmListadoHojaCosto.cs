using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Almacen
{
    public partial class frmListadoHojaCosto : FrmMantenimientoBase
    {

        #region Constructores

        public frmListadoHojaCosto()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvHojaCosto, false);
        }

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        List<HojaCostoE> oListaHojaCosto = null;
        HojaCostoE oHojaCosto = new HojaCostoE();
        String RutaGeneral = String.Empty;
        Boolean Ordenar = false;

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                Form oFrm = MdiChildren.FirstOrDefault(x => x is frmHojaCosto);

                if (oFrm != null)
                {
                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmHojaCosto()
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
            Form oFrm = MdiChildren.FirstOrDefault(x => x is frmHojaCosto);

            if (oFrm != null)
            {
                if (oFrm.WindowState == FormWindowState.Minimized)
                {
                    oFrm.WindowState = FormWindowState.Normal;
                }

                oFrm.BringToFront();
                return;
            }

            HojaCostoE EHojaCosto = AgenteAlmacen.Proxy.RecuperarHojaCosto(((HojaCostoE)bsHojaCosto.Current).idEmpresa, ((HojaCostoE)bsHojaCosto.Current).idLocal, ((HojaCostoE)bsHojaCosto.Current).idHojaCosto);

            if (EHojaCosto != null)
            {
                oFrm = new frmHojaCosto(EHojaCosto)
                {
                    MdiParent = MdiParent
                };

                oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                oFrm.Show();
            }
        }

        public override void Buscar()
        {
            try
            {
                bsHojaCosto.DataSource = oListaHojaCosto = AgenteAlmacen.Proxy.ListarHojaCosto(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, dtpDesde.Value.Date, dtpHasta.Value.Date);
                lblTitulo.Text = "Registros " + bsHojaCosto.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Anular()
        {
            Int32 resp = Variables.Cero;

            try
            {
                if (bsHojaCosto.Count > Variables.Cero)
                {
                    //T = Cerrado   F = Abierto
                    if (((HojaCostoE)bsHojaCosto.Current).Estado != "T") //Si esta Abierto... elimina!!!
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                        {
                            resp = AgenteAlmacen.Proxy.EliminarHojaCosto(((HojaCostoE)bsHojaCosto.Current).idEmpresa, ((HojaCostoE)bsHojaCosto.Current).idLocal, ((HojaCostoE)bsHojaCosto.Current).idHojaCosto);
                            Buscar();
                            Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                            base.Anular();
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Este Registro se encuentra cerrado. Tiene que abrirlo para poder eliminarlo.");
                    }
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
                if ((HojaCostoE)bsHojaCosto.Current == null)
                {
                    Global.MensajeFault("No hay datos para exportar a Excel.");
                    return;
                }

                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "Listado de Hoja Costos", "Archivos Excel (*.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    oHojaCosto = AgenteAlmacen.Proxy.RecuperarHojaCosto(((HojaCostoE)bsHojaCosto.Current).idEmpresa, ((HojaCostoE)bsHojaCosto.Current).idLocal, ((HojaCostoE)bsHojaCosto.Current).idHojaCosto);

                    if (oHojaCosto.ListaHojaCostoItem.Count > Variables.Cero)
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

            TituloGeneral = "LIQ.IMPORTACION";
            NombrePestaña = "Hoja de Costo";

            if (File.Exists(Ruta)) File.Delete(Ruta);

            FileInfo newFile = new FileInfo(Ruta);
            
            using (ExcelPackage oExcel = new ExcelPackage(newFile))
            {
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add(NombrePestaña);
                List<MovimientoAlmacenE> oListaMovimientos = AgenteAlmacen.Proxy.ListarMovimientosPorOrdenCompra(((HojaCostoE)bsHojaCosto.Current).idEmpresa, ((HojaCostoE)bsHojaCosto.Current).idOrdenCompra);

                if (oHoja != null)
                {
                    Int32 InicioLinea = 4;
                    Int32 TotColumnas = 35;
                    Int32 Columna = 0;
                    StringBuilder sbGuias = new StringBuilder();
                    StringBuilder sbFecGuias = new StringBuilder();

                    if (oListaMovimientos != null && oListaMovimientos.Count > 0)
                    {
                        foreach (MovimientoAlmacenE item in oListaMovimientos)
                        {
                            //Documentos
                            if (item.idDocumentoRef == "GV")
                            {
                                sbGuias.Append(item.SerieDocumentoRef).Append("-").Append(item.NumeroDocumentoRef).Append(", ");
                            }

                            //Fecha de ingreso a almacén
                            //Por revisar//sbFecGuias.Append(item.fecProceso.ToString("dd/MM/yyyy")).Append(", ");
                        }
                    }

                    #region Titulos Principales

                    // Creando Encabezado;
                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 15, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 51, 102));
                    }

                    oHoja.Cells["A2"].Value = TituloGeneral;

                    using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                    {
                        Rango.Merge = true;
                        Rango.Style.Font.SetFromFont(new Font("Arial", 13, FontStyle.Bold));
                        Rango.Style.Font.Color.SetColor(Color.White);
                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        Rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 51, 102));
                    }

                    #endregion

                    #region Subtitulos

                    oHoja.Cells[InicioLinea, 3].Value = "N° Orden de compra";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.numOrdenCompra;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "DESCRIPCION";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.Descripcion;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.DesPersona;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "RUC/EXTERIOR";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.RUC;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "INVOICE";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.FactComercial;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "F.INVOICE";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.fecFacturaComer;
                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "N° DUA";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.DUA;
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "F. DUA";
                    oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.fecDua;
                    oHoja.Cells[InicioLinea, 4].Style.Numberformat.Format = "dd/MM/yyyy";
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "G.REMISION";
                    oHoja.Cells[InicioLinea, 4].Value = sbGuias.ToString();
                    InicioLinea++;
                    oHoja.Cells[InicioLinea, 3].Value = "F.ALMACEN";
                    oHoja.Cells[InicioLinea, 4].Value = sbFecGuias.ToString();
                    InicioLinea++;

                    for (int i = 4; i <= 13; i++)
                    {
                        oHoja.Cells[i, 3].Style.Font.SetFromFont(new Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[i, 4].Style.Font.SetFromFont(new Font("Arial", 8));
                    }

                    sbGuias.Clear();
                    sbFecGuias.Clear();
                    InicioLinea++;                   
                    InicioLinea++;

                    #endregion

                    #region Cabeceras del Detalle

                    oHoja.Column(1).Width = 3;
                    oHoja.Cells[InicioLinea, 1].Value = "N°";
                    oHoja.Column(2).Width = 10;
                    oHoja.Cells[InicioLinea, 2].Value = "RUC";
                    oHoja.Column(3).Width = 28;
                    oHoja.Cells[InicioLinea, 3].Value = "PROVEEDOR";
                    oHoja.Cells[InicioLinea, 4].Value = "FECHA";
                    oHoja.Column(5).Width = 6;
                    oHoja.Cells[InicioLinea, 5].Value = "TIP.\nCOMP.";
                    oHoja.Column(6).Width = 15;
                    oHoja.Cells[InicioLinea, 6].Value = "N°\nCOMP.";
                    oHoja.Column(7).Width = 6;
                    oHoja.Cells[InicioLinea, 7].Value = "MONE.";
                    oHoja.Column(8).Width = 10;
                    oHoja.Cells[InicioLinea, 8].Value = "COD.\nPRODUCTO";

                    oHoja.Column(9).Width = 45;
                    oHoja.Cells[InicioLinea, 9].Value = "PRODUCTO";

                    oHoja.Column(10).Width = 30;
                    oHoja.Cells[InicioLinea, 10].Value = "NOMBRE\nEXTERNO";

                    oHoja.Column(11).Width = 14;
                    oHoja.Cells[InicioLinea, 11].Value = "LOTE";

                    oHoja.Column(12).Width = 9.25;
                    oHoja.Cells[InicioLinea, 12].Value = "CANTIDAD";

                    oHoja.Column(13).Width = 9;
                    oHoja.Cells[InicioLinea, 13].Value = "UNIDAD";

                    oHoja.Column(14).Width = 9.25;
                    oHoja.Cells[InicioLinea, 14].Value = "PESO TOTAL";

                    Columna = 15;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C.U.\nFOB\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "VALOR\nFOB\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "FLETE " + Environment.NewLine + "\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "SEGURO " + Environment.NewLine + "\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "OTROS\n\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "VALOR\nCIF\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C.U.\nCIF\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "COSTOS LOGIST.\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C. TOTAL ALMACEN\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C.U. ALMACEN\n$";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "TIPO\nCAMBIO";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C.U.\nFOB\nS/. ";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "VALOR\nFOB\nS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "FLETE\n\rS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "SEGURO\n\rS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "OTROS\n\rS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "VALOR\nCIF\nS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C.U.\nCIF\nS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "COSTOS LOGIST.\nS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C. TOTAL ALMACEN\nS/.";
                    Columna++;
                    oHoja.Column(Columna).Width = 9.25;
                    oHoja.Cells[InicioLinea, Columna].Value = "C.U. ALMACEN\nS/.";
                    Columna++;


                    for (int i = 1; i <= 35; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.White);
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 51, 102));
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Distributed;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);
                    }

                    oHoja.Row(InicioLinea).Height = 45.75; 

                    #endregion

                    #region Llenando el Primer detalle

                    InicioLinea++;
                    Int32 numItem = 1;
                    Int32 ini = InicioLinea;
                    Decimal ValorFleteD = (from x in oHojaCosto.ListaHojaCostoItem
                                           where x.NomArticulo.ToUpper().Contains("FLETE")
                                           && x.Nivel == "S"
                                           select x.ValorFob).Sum();

                    Decimal ValorSeguroD = (from x in oHojaCosto.ListaHojaCostoItem
                                           where x.NomArticulo.ToUpper().Contains("SEGURO")
                                           && x.Nivel == "S"
                                            select x.ValorFob).Sum();

                    Decimal ValorOtrosD = (from x in oHojaCosto.ListaHojaCostoItem
                                           where x.NomArticulo.ToUpper().Contains("OTROS COSTO")
                                           && x.Nivel == "S"
                                           select x.ValorFob).Sum();

                    Decimal TotalValorFobD = (from x in oHojaCosto.ListaHojaCostoItem
                                              where x.Nivel == "D"
                                              select x.ValorFob).Sum();

                    foreach (HojaCostoItemE item in oHojaCosto.ListaHojaCostoItem)
                    {
                        if (item.Nivel == "D")
                        {
                            oHoja.Cells[InicioLinea, 1].Value = numItem;
                            oHoja.Cells[InicioLinea, 2].Value = oHojaCosto.RUC;
                            oHoja.Cells[InicioLinea, 3].Value = oHojaCosto.DesPersona;
                            oHoja.Cells[InicioLinea, 4].Value = oHojaCosto.fecFacturaComer;
                            oHoja.Cells[InicioLinea, 5].Value = oHojaCosto.idDocumentoFact;
                            oHoja.Cells[InicioLinea, 6].Value = oHojaCosto.FactComercial;
                            oHoja.Cells[InicioLinea, 7].Value = oHojaCosto.desMoneda;
                            oHoja.Cells[InicioLinea, 8].Value = item.codArticulo;
                            oHoja.Cells[InicioLinea, 9].Value = item.NomArticulo;
                            oHoja.Cells[InicioLinea, 10].Value = item.nomCorto;
                            oHoja.Cells[InicioLinea, 11].Value = item.Lote;
                            oHoja.Cells[InicioLinea, 12].Value = item.Cantidad;
                            oHoja.Cells[InicioLinea, 13].Value = item.desUmedida;
                            oHoja.Cells[InicioLinea, 14].Value = item.Peso;

                            oHoja.Cells[InicioLinea, 15].Value = item.FobUnitario; //Valor Fob Unitario $
                            oHoja.Cells[InicioLinea, 16].Value = item.ValorFob; //Valor Fob  $
                           
                            //oHoja.Cells[InicioLinea, 17].Value = item.ValorFob * (ValorFleteD / TotalValorFobD); //flete $
                            //oHoja.Cells[InicioLinea, 18].Value = item.ValorFob * (ValorSeguroD / TotalValorFobD); //Seguro $
                            //oHoja.Cells[InicioLinea, 19].Value = item.ValorFob * (ValorOtrosD / TotalValorFobD); //Otros $
                            oHoja.Cells[InicioLinea, 17].Value = item.Flete; //flete $
                            oHoja.Cells[InicioLinea, 18].Value = item.Seguro; //Seguro $
                            oHoja.Cells[InicioLinea, 19].Value = item.OtrosCostos; //Otros $
                           
                            oHoja.Cells[InicioLinea, 20].Value = (item.ValorFob + item.Flete + item.Seguro + item.OtrosCostos); //Valor Cif $
                            oHoja.Cells[InicioLinea, 21].Value = (item.ValorFob + item.Flete + item.Seguro + item.OtrosCostos) / item.Cantidad; //Cif Unitario $
                          
                            oHoja.Cells[InicioLinea, 22].Value = (item.GstoOtros); //Costos $
                            oHoja.Cells[InicioLinea, 23].Value = (item.CostoTotalME); //Total Almacen $
                            oHoja.Cells[InicioLinea, 24].Value = (item.CostoUnitarioME); //Valor Cif $

                            oHoja.Cells[InicioLinea, 25].Value = oHojaCosto.TipoCambio; //Tipo de Cambio

                            oHoja.Cells[InicioLinea, 26].Value = (item.ValorFob * oHojaCosto.TipoCambio) / item.Cantidad; //Valor Fob Unitario S/.
                            oHoja.Cells[InicioLinea, 27].Value = (item.ValorFob * oHojaCosto.TipoCambio); //Valor Fob  S/.  
                                   
                            oHoja.Cells[InicioLinea, 28].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 17].Value) * oHojaCosto.TipoCambio; //flete S/.
                            oHoja.Cells[InicioLinea, 29].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 18].Value) * oHojaCosto.TipoCambio; //Seguro S/.
                            oHoja.Cells[InicioLinea, 30].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 19].Value) * oHojaCosto.TipoCambio; //Otros S/.


                            oHoja.Cells[InicioLinea, 31].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 20].Value) * oHojaCosto.TipoCambio; //Valor Cif S/.
                            oHoja.Cells[InicioLinea, 32].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 21].Value) * oHojaCosto.TipoCambio; //Cif Unitario S/.

                            oHoja.Cells[InicioLinea, 33].Value = (item.GstoOtrosMN); //Costos S/.
                            oHoja.Cells[InicioLinea, 34].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 31].Value) + item.GstoOtrosMN; //Total Almacen S/.
                            oHoja.Cells[InicioLinea, 35].Value = Convert.ToDecimal(oHoja.Cells[InicioLinea, 34].Value) / item.Cantidad; //Valor Cif S/.

                            InicioLinea++;
                            numItem++; 
                        }
                    }

                    //Formateo del primer Detalle
                    for (int f = ini; f <= InicioLinea - 1; f++)
                    {
                        for (int c = 1; c <= TotColumnas; c++)
                        {
                            oHoja.Cells[f, c].Style.Font.SetFromFont(new Font("Arial", 8));
                            oHoja.Cells[f, c].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);

                            if (c == 4)
                            {
                                oHoja.Cells[f, c].Style.Numberformat.Format = "dd/MM/yyyy";
                            }

                            if (c >= 12 && c <= 24)
                            {   if (c == 24)
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "###,###,##0.000000";
                                }
                                else
                                if (c == 14)
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "#,###,##0.00000";
                                }
                                else if( c == 19)
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "###,###,##0.000";
                                }
                            }

                            if (c >= 25 && c <= 35)
                            {
                                if (c == 35)
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "###,###,##0.000000";
                                }
                                else
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "###,###,##0.000";
                                }
                            }
                        }
                    }

                    //Totales
                    oHoja.Cells["J" + Convert.ToString(InicioLinea) + ":K" + Convert.ToString(InicioLinea)].Merge = true;
                    oHoja.Cells[InicioLinea, 10].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new Font("Arial", 8.25f));

                    oHoja.Cells[InicioLinea, 12].Formula = "SUBTOTAL(9,L" + ini + ":L" + Convert.ToString(InicioLinea - 1) + ")"; //Cantidad

                    oHoja.Cells[InicioLinea, 14].Formula = "SUBTOTAL(9,N" + ini + ":N" + Convert.ToString(InicioLinea - 1) + ")"; //Peso Total

                    oHoja.Cells[InicioLinea, 16].Formula = "SUBTOTAL(9,P" + ini + ":P" + Convert.ToString(InicioLinea - 1) + ")"; //Total Valor FOB $

                    oHoja.Cells[InicioLinea, 17].Formula = "SUBTOTAL(9,Q" + ini + ":Q" + Convert.ToString(InicioLinea - 1) + ")"; //Total Flete $

                    oHoja.Cells[InicioLinea, 18].Formula = "SUBTOTAL(9,R" + ini + ":R" + Convert.ToString(InicioLinea - 1) + ")"; //Total Seguro $

                    oHoja.Cells[InicioLinea, 19].Formula = "SUBTOTAL(9,S" + ini + ":S" + Convert.ToString(InicioLinea - 1) + ")"; //Total Otros $

                    oHoja.Cells[InicioLinea, 20].Formula = "SUBTOTAL(9,T" + ini + ":T" + Convert.ToString(InicioLinea - 1) + ")"; //Total Valor CIF $


                    oHoja.Cells[InicioLinea, 22].Formula = "SUBTOTAL(9,V" + ini + ":V" + Convert.ToString(InicioLinea - 1) + ")"; //Costos Logisticos $

                    oHoja.Cells[InicioLinea, 23].Formula = "SUBTOTAL(9,W" + ini + ":W" + Convert.ToString(InicioLinea - 1) + ")"; //Costo total Almacen $



                    oHoja.Cells[InicioLinea, 27].Formula = "SUBTOTAL(9,AA" + ini + ":AA" + Convert.ToString(InicioLinea - 1) + ")"; //Total Valor FOB S/.

                    oHoja.Cells[InicioLinea, 28].Formula = "SUBTOTAL(9,AB" + ini + ":AB" + Convert.ToString(InicioLinea - 1) + ")"; //Total Flete S/.



                    oHoja.Cells[InicioLinea, 29].Formula = "SUBTOTAL(9,AC" + ini + ":AC" + Convert.ToString(InicioLinea - 1) + ")"; //Total Seguro S/.

                    oHoja.Cells[InicioLinea, 30].Formula = "SUBTOTAL(9,AD" + ini + ":AD" + Convert.ToString(InicioLinea - 1) + ")"; //Total Otros S/.

                    oHoja.Cells[InicioLinea, 31].Formula = "SUBTOTAL(9,AE" + ini + ":AE" + Convert.ToString(InicioLinea - 1) + ")"; //Total Valor CIF S/.

                    oHoja.Cells[InicioLinea, 33].Formula = "SUBTOTAL(9,AG" + ini + ":AG" + Convert.ToString(InicioLinea - 1) + ")"; //Costos Logisticos S/.

                    oHoja.Cells[InicioLinea, 34].Formula = "SUBTOTAL(9,AH" + ini + ":AH" + Convert.ToString(InicioLinea - 1) + ")"; //Costo total Almacen S/.

                    //Formateo de Totales
                    for (int i = 10; i <= 35; i++)
                    {
                        if (i >= 12)
                         {
                            if (i == 14)
                            {
                                oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00000";
                            }
                            else
                            {
                                oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                            }
                         }

                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new Font("Arial", 8));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);
                    }

                    #endregion

                    InicioLinea++;
                    InicioLinea++;
                    InicioLinea++;
                    numItem = 1;

                    #region Segundo Detalle

                    //Cabecera del Segundo Detalle
                    oHoja.Cells[InicioLinea, 1].Value = "N°";
                    oHoja.Cells[InicioLinea, 2].Value = "RUC";
                    oHoja.Cells[InicioLinea, 3].Value = "PROVEEDOR";
                    oHoja.Cells[InicioLinea, 4].Value = "FECHA";
                    oHoja.Cells[InicioLinea, 5].Value = "TIP.\nCOMP.";
                    oHoja.Cells[InicioLinea, 6].Value = "COMPROBANTE";
                    oHoja.Cells[InicioLinea, 7].Value = "MON.";
                    oHoja.Cells[InicioLinea, 8].Value = "CODIGO";
                    oHoja.Cells[InicioLinea, 9].Value = "CONCEPTO";
                    oHoja.Cells[InicioLinea, 10].Value = "CANTIDAD";
                    oHoja.Cells[InicioLinea, 11].Value = "C.U.\n$";
                    oHoja.Cells[InicioLinea, 12].Value = "IMPORTE\n$";
                    oHoja.Cells[InicioLinea, 13].Value = "TIPO\nCAMBIO";
                    oHoja.Cells[InicioLinea, 14].Value = "C.U.\nS/.";
                    oHoja.Cells[InicioLinea, 15].Value = "IMPORTE\nS/.";

                    //Formateo del segundo detalle
                    for (int i = 1; i <= 15; i++)
                    {
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new Font("Arial", 8, FontStyle.Bold));
                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Font.Color.SetColor(Color.White);
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 51, 102));
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        oHoja.Cells[InicioLinea, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        oHoja.Cells[InicioLinea, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Distributed;
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);
                    }

                    //Alto de la cabecera del segundo detalle
                    oHoja.Row(InicioLinea).Height = 45.75;
                    InicioLinea++;
                    ini = InicioLinea;

                    foreach (GastosImportacionE item in oHojaCosto.ListaGastosImportacion)
                    {
                        oHoja.Cells[InicioLinea, 1].Value = numItem;
                        oHoja.Cells[InicioLinea, 2].Value = item.Ruc;
                        oHoja.Cells[InicioLinea, 3].Value = item.RazonSocial;
                        oHoja.Cells[InicioLinea, 4].Value = item.Fecha;
                        oHoja.Cells[InicioLinea, 5].Value = item.idDocumento;

                        if (String.IsNullOrWhiteSpace(item.serDocumento))
                        {
                            oHoja.Cells[InicioLinea, 6].Value = item.numDocumento;
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, 6].Value = item.serDocumento + "-" + item.numDocumento;
                        }
                        
                        oHoja.Cells[InicioLinea, 7].Value = item.DesMoneda;
                        oHoja.Cells[InicioLinea, 8].Value = item.codConcepto == "0" ? item.codArticulo : item.codConcepto;
                        oHoja.Cells[InicioLinea, 9].Value = item.desArticulo;
                        oHoja.Cells[InicioLinea, 10].Value = item.Cantidad;
                        oHoja.Cells[InicioLinea, 11].Value = item.MontoDolares;
                        oHoja.Cells[InicioLinea, 12].Value = item.MontoDolares;
                        oHoja.Cells[InicioLinea, 13].Value = item.TipoCambio;

                         if (item.idMoneda == Variables.Soles)
                          {
                            oHoja.Cells[InicioLinea, 14].Value = item.Monto;
                            oHoja.Cells[InicioLinea, 15].Value = item.Monto;
                          }
                         else
                          {
                            oHoja.Cells[InicioLinea, 14].Value = item.Monto * item.TipoCambio;
                            oHoja.Cells[InicioLinea, 15].Value = item.Monto * item.TipoCambio;
                          }

                        InicioLinea++;
                        numItem++;
                    }

                    //Formateo del segundo Detalle
                    for (int f = ini; f <= InicioLinea - 1; f++)
                    {
                        for (int c = 1; c <= 15; c++)
                        {
                            oHoja.Cells[f, c].Style.Font.SetFromFont(new Font("Arial", 8));
                            oHoja.Cells[f, c].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);

                            if (c == 4)
                            {
                                oHoja.Cells[f, c].Style.Numberformat.Format = "dd/MM/yyyy";
                            }

                            if (c >= 10)
                            {
                                if (c == 13)
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "###,###,##0.000";
                                }
                                else
                                {
                                    oHoja.Cells[f, c].Style.Numberformat.Format = "###,###,##0.00";
                                }
                            }
                        }
                    }

                    /// Totales
                    oHoja.Cells[InicioLinea, 10].Value = "TOTALES";
                    oHoja.Cells[InicioLinea, 10].Style.Font.SetFromFont(new Font("Arial", 8.25f));
                    oHoja.Cells[InicioLinea, 10].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);
                  
                    oHoja.Cells[InicioLinea, 11].Formula = "SUBTOTAL(9,K" + ini + ":K" + Convert.ToString(InicioLinea - 1) + ")"; //CUO $
                    oHoja.Cells[InicioLinea, 11].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);

                    oHoja.Cells[InicioLinea, 12].Formula = "SUBTOTAL(9,L" + ini + ":L" + Convert.ToString(InicioLinea - 1) + ")"; //Importe $
                    oHoja.Cells[InicioLinea, 12].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);

                    oHoja.Cells[InicioLinea, 14].Formula = "SUBTOTAL(9,N" + ini + ":N" + Convert.ToString(InicioLinea - 1) + ")"; //CUO S/.
                    oHoja.Cells[InicioLinea, 14].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);
                
                    oHoja.Cells[InicioLinea, 15].Formula = "SUBTOTAL(9,O" + ini + ":O" + Convert.ToString(InicioLinea - 1) + ")"; //Importe S/.
                    oHoja.Cells[InicioLinea, 15].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);

                    //Formateo de Totales
                    for (int i = 10; i <= 15; i++)
                    {
                        if (i == 13)
                        {
                            oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.000";
                        }
                        else
                        {
                            oHoja.Cells[InicioLinea, i].Style.Numberformat.Format = "###,###,##0.00";
                        }
                        
                        oHoja.Cells[InicioLinea, i].Style.Font.SetFromFont(new Font("Arial", 8));
                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;

                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Dotted, Color.Black);

                    }

                    #endregion

                    #region Parte Final del Excel

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
                    oHoja.Workbook.Properties.Category = "Modulo de Almacén";
                    oHoja.Workbook.Properties.Comments = NombrePestaña;

                    // Establecer algunos valores de las propiedades extendidas
                    oHoja.Workbook.Properties.Company = "AMAZONTIC SAC";

                    //Propiedades para imprimir
                    oHoja.PrinterSettings.Orientation = eOrientation.Landscape;
                    oHoja.PrinterSettings.PaperSize = ePaperSize.A4;

                    //Guardando el excel
                    oExcel.Save();
                    oHoja.Dispose();

                    Global.MensajeComunicacion("Exportación Guardada");

                    #endregion
                }
            }
        }

        #endregion Procedimientos de Usuario

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmHojaCosto oFrm = sender as frmHojaCosto;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoHojaCosto_Load(object sender, EventArgs e)
        {
            Grid = true;
            Buscar();

            // Periodo Mensual
            Int32 Dia = FechasHelper.ObtenerUltimoDia(Convert.ToDateTime("01/" + VariablesLocales.FechaHoy.Month.ToString("00") + "/" + VariablesLocales.FechaHoy.Year.ToString("00"))).Day;
            DateTime fechaUltDiaMes = Convert.ToDateTime(Dia + "/" + VariablesLocales.FechaHoy.Month.ToString("00") + "/" + VariablesLocales.FechaHoy.Year.ToString("00"));
            dtpDesde.Value = Convert.ToDateTime("01" + "/" + VariablesLocales.FechaHoy.Month.ToString("00") + "/" + VariablesLocales.FechaHoy.Year.ToString("00"));
            dtpHasta.Value = fechaUltDiaMes;

            // Los Ultimos 10 Dias
            dtpDesde.Value = VariablesLocales.FechaHoy.AddDays(-10);
            dtpHasta.Value = VariablesLocales.FechaHoy;

            base.Grabar();
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }
   
        private void dgvHojaCosto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cerrarHojaCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //T = Cerrado   F = Abierto
                if (((HojaCostoE)bsHojaCosto.Current).Estado != "T")
                {
                    Int32 Resp = AgenteAlmacen.Proxy.ActualizarEstadoHojaCosto(((HojaCostoE)bsHojaCosto.Current).idEmpresa, ((HojaCostoE)bsHojaCosto.Current).idLocal, ((HojaCostoE)bsHojaCosto.Current).idHojaCosto,
                                                                                ((HojaCostoE)bsHojaCosto.Current).idOrdenCompra, "T", VariablesLocales.SesionUsuario.Credencial);
                    if (Resp > 0)
                    {
                        Global.MensajeComunicacion("Registro Cerrado");
                        ((HojaCostoE)bsHojaCosto.Current).Estado = "T";
                        bsHojaCosto.ResetBindings(false);
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Este Registro se encuentra cerrado");
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void abrirHojaCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //T = Cerrado   F = Abierto
                if (((HojaCostoE)bsHojaCosto.Current).Estado != "F")
                {
                    Int32 Resp = AgenteAlmacen.Proxy.ActualizarEstadoHojaCosto(((HojaCostoE)bsHojaCosto.Current).idEmpresa, ((HojaCostoE)bsHojaCosto.Current).idLocal, ((HojaCostoE)bsHojaCosto.Current).idHojaCosto,
                                                                                ((HojaCostoE)bsHojaCosto.Current).idOrdenCompra, "F", VariablesLocales.SesionUsuario.Credencial);
                    if (Resp > 0)
                    {
                        Global.MensajeComunicacion("Registro Abierto");
                        ((HojaCostoE)bsHojaCosto.Current).Estado = "F";
                        bsHojaCosto.ResetBindings(false);
                    }
                }
                else
                {
                    Global.MensajeComunicacion("Este Registro se encuentra abierto");
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvHojaCosto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if ((String)dgvHojaCosto.Rows[e.RowIndex].Cells["Estado"].Value == "T")
            {
                if (e.Value != null)
                {
                    e.CellStyle.BackColor = Valores.ColorCerrado;
                }
            }
        }

        private void dgvHojaCosto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (oListaHojaCosto != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR Razon Social
                    if (e.ColumnIndex == dgvHojaCosto.Columns["DesPersona"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaHojaCosto = (from x in oListaHojaCosto orderby x.DesPersona ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaHojaCosto = (from x in oListaHojaCosto orderby x.DesPersona descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR ORDEN DE COMPRA
                    if (e.ColumnIndex == dgvHojaCosto.Columns["numOrdenCompra"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaHojaCosto = (from x in oListaHojaCosto orderby x.numOrdenCompra ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaHojaCosto = (from x in oListaHojaCosto orderby x.numOrdenCompra descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                   bsHojaCosto.DataSource = oListaHojaCosto;

                }
            }
        }

        #endregion

    }
}
