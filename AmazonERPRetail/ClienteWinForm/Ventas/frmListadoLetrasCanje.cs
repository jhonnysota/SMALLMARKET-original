using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Ventas.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoLetrasCanje : FrmMantenimientoBase
    {

        #region Constructor

        public frmListadoLetrasCanje()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            FormatoGrid(dgvPrecios, true);
        }

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<LetrasE> oListaLetras = null;
        Boolean Ordenar = true;

        #endregion

        #region Procedimientos de Usuario

        //void Editar()

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                //se localiza el formulario buscandolo entre los forms abiertos 
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLetrasCanje);

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
                oFrm = new frmLetrasCanje()
                {
                    MdiParent = MdiParent
                };
                
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
                if (bsLetras.Count > 0)
                {
                    //se localiza el formulario buscandolo entre los forms abiertos 
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLetrasCanje);

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

                    LetrasE current = (LetrasE)bsLetras.Current;
                    String Bloq = "N";

                    if (!String.IsNullOrWhiteSpace(current.EstadoPlanillaBanco))
                    {
                        if (current.EstadoPlanillaBanco == "C")
                        {
                            Bloq = "S";
                            Global.MensajeComunicacion((String.Format("La planilla de banco N° {0} se encuentra cerrada, no podrá hacer modificaciones.", current.codPlanillaBanco)));
                        }
                    }

                    //sino existe la instancia se crea una nueva
                    oFrm = new frmLetrasCanje(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, Bloq)
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

        public override void Buscar()
        {
            try
            {
                String Estado = rbTodos.Checked ? "" : "P";
                String tipCanje = "%%";
                Int32 idPersona = String.IsNullOrEmpty(txtIdCliente.Text.Trim()) ? 0 : Convert.ToInt32(txtIdCliente.Text.Trim());
                String TipoFecha = rbEmision.Checked ? "E" : "V";

                if (rbCanje.Checked)
                {
                    tipCanje = "CJ";
                }

                if (rbRenovacion.Checked)
                {
                    tipCanje = "RV";
                }

                bsLetras.DataSource = oListaLetras = AgenteVentas.Proxy.ListarLetras(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, tipCanje, idPersona, Estado, TipoFecha, dtpFecIni.Value.Date, dtpFecFin.Value.Date);
                bsLetras.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                LetrasE current = (LetrasE)bsLetras.Current;

                if (!String.IsNullOrWhiteSpace(current.EstadoPlanillaBanco))
                {
                    if (current.EstadoPlanillaBanco == "C")
                    {
                        Global.MensajeComunicacion((String.Format("La planilla de banco N° {0} asociada a la Letra se encuentra cerrada, no puede ser ANULADA.", current.codPlanillaBanco)));
                        return;
                    }
                }

                if (current.Estado == "A")
                {
                    Global.MensajeComunicacion("Solo se pueden anular las letras que estan en estado Por Aceptar.");
                    return;
                }

                List<LetrasEstadoE> oEstados = AgenteVentas.Proxy.ListarEstadosLetras(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, current.Numero, current.Corre);

                if (oEstados.Count > 0)
                {
                    Global.MensajeComunicacion("No se puede anular el canje porque las letras ya han sido Aceptadas.");
                    return;
                }

                if (current.Estado != "B")
                {
                    Int32 resp = AgenteVentas.Proxy.ActualizarEstadoDeLetra(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje, "%", "%%", null, null, "B", VariablesLocales.SesionUsuario.Credencial);

                    if (resp > 0)
                    {
                        Buscar();
                        Global.MensajeComunicacion("El canje de letra se anuló.");
                    } 
                }
                else
                {
                    if (Global.MensajeConfirmacion("Se va eliminar el Canje de Letras completamente, desea continuar...") == DialogResult.Yes)
                    {
                        Int32 resp = AgenteVentas.Proxy.EliminarLetrasCanjeUnion(current.idEmpresa, current.idLocal, current.tipCanje, current.codCanje);

                        if (resp > 0)
                        {
                            Buscar();
                            Global.MensajeComunicacion("El canje se eliminó completamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Imprimir()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionCanjeLetra);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                List<LetrasCanjeUnionE> oListaLetras = AgenteVentas.Proxy.ReporteCanjeLetra(((LetrasE)bsLetras.Current).idEmpresa, ((LetrasE)bsLetras.Current).idLocal, ((LetrasE)bsLetras.Current).tipCanje, ((LetrasE)bsLetras.Current).codCanje);

                oFrm = new frmImpresionCanjeLetra(oListaLetras, ((LetrasE)bsLetras.Current).codCanje)
                {
                    MdiParent = this.MdiParent
                };

                oFrm.Show();
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
                List<LetrasCanjeUnionE> oListaLetras = AgenteVentas.Proxy.ReporteCanjeLetra(((LetrasE)bsLetras.Current).idEmpresa, ((LetrasE)bsLetras.Current).idLocal, ((LetrasE)bsLetras.Current).tipCanje, ((LetrasE)bsLetras.Current).codCanje);

                if (oListaLetras.Count > Variables.Cero)
                {
                    String NombreArchivo = String.Empty;
                    String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "Reporte De Canje De Letra", "Archivos Excel (*.xlsx)|*.xlsx");

                    if (!String.IsNullOrEmpty(RutaArchivo))
                    {
                        if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                        FileInfo newFile = new FileInfo(RutaArchivo);

                        using (ExcelPackage oExcel = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("CanjeDeLetra");

                            if (oHoja != null)
                            {
                                Int32 InicioLinea = 4;
                                Int32 TotColumnas = 35;

                                #region Titulos Principales

                                // Creando Encabezado;
                                oHoja.Cells["A1"].Value = " LISTA DE CANJE DE LETRAS ";

                                using (ExcelRange Rango = oHoja.Cells[1, 1, 1, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 20, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(245, 163, 113));
                                }

                                oHoja.Cells["A2"].Value = " N° DE CANJE " +((LetrasE)bsLetras.Current).codCanje;

                                using (ExcelRange Rango = oHoja.Cells[2, 1, 2, TotColumnas])
                                {
                                    Rango.Merge = true;
                                    Rango.Style.Font.SetFromFont(new System.Drawing.Font("Britanic Bold", 13, FontStyle.Italic));
                                    Rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                    Rango.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                                    Rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    Rango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(245, 163, 113));
                                }


                                #endregion

                                #region Cabeceras del Detalle



                                // Primera
                                oHoja.Cells[InicioLinea, 1].Value = " ZONA";
                                //oHoja.Column(1).Width = 10;
                                oHoja.Cells[InicioLinea, 2].Value = " VENDEDOR ";

                                oHoja.Cells[InicioLinea, 3].Value = " RUC";
                                //oHoja.Column(2).Width = 90;
                                oHoja.Cells[InicioLinea, 4].Value = " CLIENTE";

                                oHoja.Cells[InicioLinea, 5].Value = " TIPO DOC.";

                                oHoja.Cells[InicioLinea, 6].Value = " NÚMERO";
                                //oHoja.Column(3).Width = 13;
                                oHoja.Cells[InicioLinea, 7].Value = " EMISIÓN";
                                //oHoja.Column(4).Width = 13;
                                oHoja.Cells[InicioLinea, 8].Value = " VENCIMIENTO ";
                                //oHoja.Column(5).Width = 13;
                                oHoja.Cells[InicioLinea, 9].Value = " MONEDA ";

                                oHoja.Cells[InicioLinea, 10].Value = " IMPORTE ";

                                oHoja.Cells[InicioLinea, 11].Value = " SALDO ";

                                oHoja.Cells[InicioLinea, 12].Value = " STATUS ";


                                for (int i = 1; i <= 12; i++)
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

                                foreach (LetrasCanjeUnionE item in oListaLetras)
                                {

                                    oHoja.Cells[InicioLinea, 1].Value = item.nomZona;
                                    oHoja.Cells[InicioLinea, 2].Value = item.nomVendedor;
                                    oHoja.Cells[InicioLinea, 3].Value = item.ruc;
                                    oHoja.Cells[InicioLinea, 4].Value = item.RazonSocial;
                                    oHoja.Cells[InicioLinea, 5].Value = item.idDocumento;

                                    if (item.idDocumento == "LT")
                                    {
                                        oHoja.Cells[InicioLinea, 6].Value =  item.numDocumento;
                                    }
                                    else
                                    {
                                        oHoja.Cells[InicioLinea, 6].Value = item.numSerie + "-" + item.numDocumento;
                                    }
                                
                                    oHoja.Cells[InicioLinea, 7].Value = item.fecDocumento;
                                    oHoja.Cells[InicioLinea, 8].Value = item.fecVencimiento;
                                    oHoja.Cells[InicioLinea, 9].Value = item.NomMoneda;
                                    oHoja.Cells[InicioLinea, 10].Value = item.Importe;
                                    oHoja.Cells[InicioLinea, 11].Value = item.SaldoDoc;
                                    oHoja.Cells[InicioLinea, 12].Value = item.EstadoDocumento;
                                    
                                    oHoja.Cells[InicioLinea, 10, InicioLinea, 11].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 7, InicioLinea, 8].Style.Numberformat.Format = "dd/MM/yyyy";

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

        private void oFrm_RenovacionClosing(Object sender, FormClosingEventArgs e)
        {
            frmLetrasCanje oFrm = sender as frmLetrasCanje;

            if (oFrm.DialogResult == DialogResult.OK && oFrm.oLetra != null)
            {
                if (oListaLetras != null)
                {
                    if (oFrm.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        for (Int32 i = 0; i < oListaLetras.Count - 1; i++)
                        {
                            if (oListaLetras[i].idEmpresa == oFrm.oLetra.idEmpresa && oListaLetras[i].idLocal == oFrm.oLetra.idLocal
                                && oListaLetras[i].tipCanje == oFrm.oLetra.tipCanje && oListaLetras[i].codCanje == oFrm.oLetra.codCanje
                                && oListaLetras[i].Numero == oFrm.oLetra.Numero && oListaLetras[i].Corre == oFrm.oLetra.Corre)
                            {
                                oListaLetras[i] = oFrm.oLetra;
                                i = oListaLetras.Count;
                            }
                        }
                    }
                    else
                    {
                        oListaLetras.Add(oFrm.oLetra);
                    }

                    oListaLetras = (from x in oListaLetras orderby x.codCanje, x.Corre select x).ToList();

                    bsLetras.DataSource = oListaLetras;
                    bsLetras.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Eventos 

        private void frmListadoLetrasCanje_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
        }

        private void dgvPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Editar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                        return;
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrEmpty(txtRuc.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdCliente.Text = String.Empty;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRuc.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRazonSocial.Text = String.Empty;
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
            {
                txtIdCliente.Text = String.Empty;
                txtRuc.Text = String.Empty;
            }
        }

        #region Eventos de Menu

        private void tsmRenovar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (oListaLetras != null && oListaLetras.Count > Variables.Cero && bsLetras.Current != null)
            //    {
            //        if (((LetrasE)bsLetras.Current).Estado != "P")
            //        {
            //            Global.MensajeComunicacion("Sólo se pueden renovar Letras Aceptadas.");
            //            return;
            //        }

            //        //Para clonar la entidad, EN CASO SEA NECESARIO, si no utilizar lo normal... LetrasE oLetra = (LetrasE)bsLetras.Current;
            //        LetrasE oLetra = Colecciones.CopiarEntidad<LetrasE>((LetrasE)bsLetras.Current);

            //        if (oLetra.tipCanje != "RV")
            //        {
            //            List<LetrasE> oListaRenovacion = (from x in oListaLetras
            //                                              where x.idEmpresa == oLetra.idEmpresa
            //                                              && x.idLocal == oLetra.idLocal
            //                                              && x.codCanje == oLetra.codCanje
            //                                              && x.Numero == oLetra.Numero
            //                                              && x.tipCanje == "RV"
            //                                              select x).ToList();

            //            if (oListaRenovacion.Count > Variables.Cero)
            //            {
            //                Global.MensajeComunicacion("La letra ya tiene Renovación. Escoja la última renovación");
            //                oListaRenovacion = null;
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            String prueba = Convert.ToString((from m in oListaLetras
            //                                             where m.idEmpresa == oLetra.idEmpresa
            //                                             && m.idLocal == oLetra.idLocal
            //                                             && m.codCanje == oLetra.codCanje
            //                                             && m.Numero == oLetra.Numero
            //                                             && m.tipCanje == "RV"
            //                                             select m.Corre).Max());

            //            LetrasE oRenovacion = (from y in (from x in oListaLetras
            //                                              where x.idEmpresa == oLetra.idEmpresa
            //                                              && x.idLocal == oLetra.idLocal
            //                                              && x.codCanje == oLetra.codCanje
            //                                              && x.Numero == oLetra.Numero
            //                                              && x.tipCanje == "RV"
            //                                              && x.Corre == prueba
            //                                              select x).ToList()
            //                                   select y).SingleOrDefault();

            //            if (oRenovacion.Corre != oLetra.Corre)
            //            {
            //                Global.MensajeComunicacion("Debe escoger la última renovación.");
            //                return;
            //            }
            //        }

            //        //se localiza el formulario buscandolo entre los forms abiertos 
            //        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLetrasCanje);

            //        if (oFrm != null)
            //        {
            //            if (oFrm.WindowState == FormWindowState.Minimized)
            //            {
            //                oFrm.WindowState = FormWindowState.Normal;
            //            }

            //            //si la instancia existe la pongo en primer plano
            //            oFrm.BringToFront();
            //            return;
            //        }

            //        //sino existe la instancia se crea una nueva
            //        oFrm = new frmLetrasCanje(oLetra, "RV")
            //        {
            //            MdiParent = MdiParent
            //        };

            //        oFrm.FormClosing += new FormClosingEventHandler(oFrm_RenovacionClosing);
            //        oFrm.Show(); 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void tsmAprobarLetras_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (oListaLetras != null && oListaLetras.Count > Variables.Cero && bsLetras.Current != null)
            //    {
            //        if (((LetrasE)bsLetras.Current).Estado != "E")
            //        {
            //            Global.MensajeComunicacion("Sólo se puede Aceptar Letras con Estado Por Aceptar.");
            //            return;
            //        }

            //        int Acepto = 0;

            //        Acepto = AgenteVentas.Proxy.AprobarLetrasCanjeUnion(((LetrasE)bsLetras.Current).idEmpresa, ((LetrasE)bsLetras.Current).idLocal, 
            //                                                            ((LetrasE)bsLetras.Current).tipCanje, ((LetrasE)bsLetras.Current).codCanje,
            //                                                            ((LetrasE)bsLetras.Current).fecProceso, VariablesLocales.SesionUsuario.Credencial);

            //        if (Acepto == 1)
            //        {
            //            String Mensaje = AgenteVentas.Proxy.GenerarProvisionLetra(((LetrasE)bsLetras.Current).idEmpresa, ((LetrasE)bsLetras.Current).idLocal,
            //                                                                        ((LetrasE)bsLetras.Current).tipCanje, ((LetrasE)bsLetras.Current).codCanje,
            //                                                                        ((LetrasE)bsLetras.Current).idPersona, ((LetrasE)bsLetras.Current).RazonSocial,
            //                                                                        VariablesLocales.SesionUsuario.Credencial);

            //            Buscar();
            //            Global.MensajeComunicacion(Mensaje);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void verVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

            //    if (oFrm != null)
            //    {
            //        if (oFrm.WindowState == FormWindowState.Minimized)
            //        {
            //            oFrm.WindowState = FormWindowState.Normal;
            //        }

            //        oFrm.BringToFront();
            //        return;
            //    }
            //    LetrasE Letras = null;
            //    Letras = (LetrasE)bsLetras.Current;

            //    if (Letras != null)
            //    {
            //        VoucherE VoucherRep = new VoucherE();
            //        VoucherRep.AnioPeriodo = Letras.AnioPeriodo;
            //        VoucherRep.numVoucher = Letras.numVoucher;
            //        VoucherRep.idComprobante = Letras.idComprobante;
            //        VoucherRep.numFile = Letras.numFile;
            //        VoucherRep.MesPeriodo = Letras.MesPeriodo;
            //        VoucherRep.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
            //        VoucherRep.idLocal = Letras.idLocal;

            //        oFrm = new frmImpresionVoucher("N", VoucherRep);
            //        oFrm.MdiParent = MdiParent;
            //        oFrm.Show();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        #endregion Eventos de Menu

        private void dgvPrecios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Si se encuentra anulado
                if ((String)dgvPrecios.Rows[e.RowIndex].Cells["Estado"].Value == "B")
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Valores.ColorAnulado;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPrecios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaLetras != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // POR LETRA
                    if (e.ColumnIndex == dgvPrecios.Columns["Letra"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Letra ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Letra descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA
                    if (e.ColumnIndex == dgvPrecios.Columns["Fecha"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Fecha ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.Fecha descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR FECHA DE VENCIMIENTO
                    if (e.ColumnIndex == dgvPrecios.Columns["FechaVenc"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.FechaVenc ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.FechaVenc descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR RAZON SOCIAL
                    if (e.ColumnIndex == dgvPrecios.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR MONTO ORIGEN
                    if (e.ColumnIndex == dgvPrecios.Columns["MontoOrigen"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.MontoOrigen ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.MontoOrigen descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // POR COD CANJE
                    if (e.ColumnIndex == dgvPrecios.Columns["codCanje"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaLetras = (from x in oListaLetras orderby x.codCanje ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaLetras = (from x in oListaLetras orderby x.codCanje descending select x).ToList();
                            Ordenar = true;
                        }
                    }
                }

                bsLetras.DataSource = oListaLetras;
            }
        }

        private void bsLetras_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                LblTitulo.Text = "Registros " + bsLetras.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

    }
}

/*Maestro Detalle
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    List<LetrasCanjeE> oListaCanje = new VentasServiceAgent().Proxy.ListarLetrasCanje();
        //    List<LetrasE> oListaLetras = new VentasServiceAgent().Proxy.ListarLetras();
        //    DataTable oDt1 = Colecciones.ToDataTable<LetrasCanjeE>(oListaCanje);
        //    DataTable oDt2 = Colecciones.ToDataTable<LetrasE>(oListaLetras);

        //    DataSet oDs = new DataSet(); //ComboHelper.ConvertirDataSet<LetrasCanjeE>(oListaCanje);
        //    oDs.Tables.Add(oDt1);
        //    oDs.Tables.Add(oDt2);

        //    Master master = new Master(oDs);
        //    master.RowPostPaint += new DataGridViewRowPostPaintEventHandler(master.pruebacab_RowPostPaint);
        //    master.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(master.pruebacab_RowHeaderMouseClick);
        //    master.Scroll += new ScrollEventHandler(master.pruebacab_Scroll);
        //    master.SelectionChanged += new EventHandler(master.pruebacab_SelectionChanged);
        //    pnlContenedor.Controls.Add(master);

        //    master.setParentSource("Table1", "codCanje");
        //    master.childView.Add("Table2", "Letras");
        //}

        void Limpiar()
        {
            pnlContenedor.Controls.Clear();
        }*/
