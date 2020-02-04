using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmListadoDcmtoPendientexVoucherItem : FrmMantenimientoBase
    {

        public frmListadoDcmtoPendientexVoucherItem()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            //Size = new Size(1288, 678);

            //this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new Size(850, 500);

            //Global.AjustarResolucion(this);
            FormatoGrid(dgvConciliadoDcmtoPen, true, false);
            FormatoGrid(dgvVoucherItem, true, false);
            LlenarCombos();
            
        }

        #region Variables
        
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<VoucherItemE> ListaVoucherPrincipal = null;
        List<ConciliadoDcmtoPendienteE> ListaPendientesPrincipal = null;
        SaldoSegunBancoE oSaldoBanco = null;
        Con_SaldosE saldos = null;
        Boolean OrdenarV = false; //Voucher Items
        Boolean OrdenarP = false; //Documentos Pendientes
        String Ruta = String.Empty;
        Int32 LineaError = Variables.Cero;
        List<BancosConciliarE> oBancosConciliarLista = null;
        Int32 letra = 0;
        Int32 Registros = Variables.Cero;
        String Tipo = String.Empty;
        String Marquee = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Boolean LeerVoucher = true;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListarBancos.Add(new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Seleccione });
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");
            oListarBancos = null;

            //Periodos
            cboPeriodo.DataSource = FechasHelper.CargarMesesContable("PM");
            cboPeriodo.ValueMember = "MesId";
            cboPeriodo.DisplayMember = "MesDes";
            cboPeriodo.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");

            oListaMonedas = null;
            oListarBancos = null;
        }

        void LlenarCuentasBancarias(Int32 idBanco, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasPorBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idBanco, idMoneda);
            oListaCuentas.Add(new BancosCuentasE() { idPersona = Variables.Cero, numCuenta = Variables.Seleccione });
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentas, (from x in oListaCuentas orderby x.idPersona select x).ToList(), "codCuenta", "numCuenta");

            if (oListaCuentas.Count == 2)
            {
                cboCuentas.SelectedIndex = 1;
            }

            if (cboCuentas.SelectedValue != null)
            {
                txtCodCuenta.Text = cboCuentas.SelectedValue.ToString();
                BancosCuentasE Obancotmp = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodCuenta.Text);
                txtNomCuenta.Text = Obancotmp.DescripcionCuenta;
            }
            else
            {
                txtCodCuenta.Text = "";
                txtNomCuenta.Text = "";
            }

            oListaCuentas = null;
        }

        void ImportarExcel(String Ruta)
        {
            FileInfo oFi_ = new FileInfo(Ruta);

            using (ExcelPackage oExcel = new ExcelPackage(oFi_))
            {
                //Entidad
                BancosConciliarE oBancosConciliar = null;
                //Excel
                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets[1];
                //Para el recorrido del excel
                Int32 totFilasExcel = oHoja.Dimension.Rows;//oHoja.Dimension.End.Row;
                //Detectando Banco para recuperar persona 
                BancosCuentasE BancoPersona = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(Convert.ToInt32(oHoja.Cells[2, 1].Value), oHoja.Cells[3, 4].Value.ToString());

                //Recorriendo la hoja excel hasta el total de fila obtenido...
                for (int f = 6; f <= totFilasExcel; f++)
                {
                    if (oHoja.Cells[f, 1].Value != null)
                    {
                        LineaError = f;
                        oBancosConciliar = new BancosConciliarE()
                        {
                            idEmpresa = Convert.ToInt32(oHoja.Cells[2, 1].Value),
                            idPersona = BancoPersona.idPersona,
                            CodCuenta = oHoja.Cells[3, 4].Value.ToString(),
                            Fecha = Convert.ToDateTime(oHoja.Cells[f, 1].Value),
                            Glosa = oHoja.Cells[f, 2].Value.ToString(),
                            Monto = Convert.ToDecimal(oHoja.Cells[f, 3].Value),
                            Operacion = oHoja.Cells[f, 4].Value.ToString()
                        };
                        
                        oBancosConciliarLista.Add(oBancosConciliar);
                    }
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                Decimal MontoTotal = 0;
                Decimal MontoHaber = 0;
                Decimal MontoDebe = 0;

                if (cboCuentas.SelectedValue != null)
                {
                    saldos = AgenteContabilidad.Proxy.Obtenercon_saldos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, cboCuentas.SelectedValue.ToString());

                    if (saldos != null)
                    {
                        if (cboMoneda.SelectedValue.ToString() == Variables.Soles)
                        {
                            txtSaldo.Text = saldos.SAL_ACTUAL_SOLES.ToString("N2");
                            txtSaldoAnterior.Text = saldos.SAL_ANTERIOR_SOLES.ToString("N2");
                        }
                        else
                        {
                            txtSaldo.Text = saldos.SAL_ACTUAL_DOLARES.ToString("N2");
                            txtSaldoAnterior.Text = saldos.SAL_ANTERIOR_DOLARES.ToString("N2");
                        } 
                    }
                    else
                    {
                        txtSaldo.Text = "0.00";
                        txtSaldoAnterior.Text = "0.00";
                    }

                    bsVoucherItem.DataSource = ListaVoucherPrincipal = AgenteContabilidad.Proxy.ListarVoucherItemPorCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, cboCuentas.SelectedValue.ToString());
                    bsVoucherItem.ResetBindings(false);

                    bsConciliadoDcmto.DataSource = ListaPendientesPrincipal = AgenteContabilidad.Proxy.ListarConciliadoDcmtoPendiente(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, cboCuentas.SelectedValue.ToString());
                    bsConciliadoDcmto.ResetBindings(false);

                    txtSaldoBanco.Enabled = true;
                    txtSaldoBanco.Text = "0.00";

                    oSaldoBanco = AgenteContabilidad.Proxy.ObtenerSaldoSegunBanco(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, cboCuentas.SelectedValue.ToString());

                    if (oSaldoBanco != null)
                    {
                        txtSaldoBanco.Text = oSaldoBanco.Saldo.Value.ToString("N2");
                    }

                    if (ListaVoucherPrincipal.Count > 0)
                    {
                        btConciliado.Enabled = true;
                        btLimpiar.Enabled = true;

                        foreach (VoucherItemE item in ListaVoucherPrincipal)
                        {
                            MontoTotal += item.monto;

                            if (item.indDebeHaber == "D")
                            {
                                MontoDebe += item.monto;
                            }
                            else
                            {
                                MontoHaber += item.monto;
                            }
                        }

                        txtMontoTotal.Text = MontoTotal.ToString("N2");
                        txtMontoDebe.Text = MontoDebe.ToString("N2");
                        txtMontoHaber.Text = MontoHaber.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                if (dgvConciliadoDcmtoPen.IsCurrentCellDirty)
                {
                    dgvConciliadoDcmtoPen.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                if (dgvVoucherItem.IsCurrentCellDirty)
                {
                    dgvVoucherItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                bsVoucherItem.EndEdit();

                foreach (VoucherItemE item in ListaVoucherPrincipal)
                {
                    if (item.indConciliadoBool)
                    {
                        item.indConciliado = "S";
                    }
                    else
                    {
                        item.indConciliado = "N";
                    }
                }

                if (!ValidarGrabacion()) { return; }

                List<VoucherItemE> oListaVoucherItemTmp = new List<VoucherItemE>(from x in ListaVoucherPrincipal where x.Opcion == (Int32)EnumOpcionGrabar.Actualizar select x).ToList();
                List<ConciliadoDcmtoPendienteE> oListaPendientesTmp = new List<ConciliadoDcmtoPendienteE>(from x in ListaPendientesPrincipal where x.Opcion == (Int32)EnumOpcionGrabar.Actualizar select x).ToList();

                //Vouchers
                if (oListaVoucherItemTmp.Count > 0)
                {
                    AgenteContabilidad.Proxy.GrabarVoucherItem(oListaVoucherItemTmp);
                    ListaVoucherPrincipal.ToList().ForEach(x => x.Opcion = 0);
                }

                //Documento pendientes
                if (oListaPendientesTmp.Count > 0)
                {
                    ListaPendientesPrincipal = AgenteContabilidad.Proxy.GrabarConciliado(oListaPendientesTmp);
                    ListaPendientesPrincipal.ToList().ForEach(x => x.Opcion = 0);
                }

                if (oSaldoBanco == null)
                {
                    oSaldoBanco = new SaldoSegunBancoE
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        AnioPeriodo = VariablesLocales.PeriodoContable.AnioPeriodo,
                        MesPeriodo = cboPeriodo.SelectedValue.ToString(),
                        numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                        codCuenta = cboCuentas.SelectedValue.ToString(),
                        Saldo = Convert.ToDecimal(txtSaldoBanco.Text),
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy
                    };

                    oSaldoBanco = AgenteContabilidad.Proxy.InsertarSaldoSegunBanco(oSaldoBanco);
                }
                else
                {
                    oSaldoBanco.Saldo = Convert.ToDecimal(txtSaldoBanco.Text);
                    oSaldoBanco = AgenteContabilidad.Proxy.ActualizarSaldoSegunBanco(oSaldoBanco);
                }

                LeerVoucher = true;
                Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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
                if (cboCuentas.SelectedValue != null || txtSaldo.Text != "0.00")
                {
                    List<ConciliadoDcmtoPendienteE> ConciliacionTMP = null;// AgenteContabilidad.Proxy.ReporteConciliadoBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), cboCuentas.SelectedValue.ToString());
                    Form oFrm = null;

                    if (VariablesLocales.oConParametros != null && VariablesLocales.oConParametros.ValorReporteConci > 0)
                    {
                        if (VariablesLocales.oConParametros.ValorReporteConci == 1)
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteConciliadoBancos);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            ConciliacionTMP = AgenteContabilidad.Proxy.ReporteConciliadoBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), cboCuentas.SelectedValue.ToString());
                            oFrm = new frmReporteConciliadoBancos(ConciliacionTMP, txtSaldo.Text, cboBancosEmpresa.Text, cboCuentas.Text, cboPeriodo.SelectedValue.ToString(), cboMoneda.Text)
                            {
                                MdiParent = MdiParent
                            };

                            oFrm.Show();
                        }
                        else if (VariablesLocales.oConParametros.ValorReporteConci == 2)
                        {
                            oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteConciliacionPrevia);

                            if (oFrm != null)
                            {
                                if (oFrm.WindowState == FormWindowState.Minimized)
                                {
                                    oFrm.WindowState = FormWindowState.Normal;
                                }

                                oFrm.BringToFront();
                                return;
                            }

                            Int32 Dia = FechasHelper.ObtenerDiasMes(Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo), Convert.ToInt32(cboPeriodo.SelectedValue));
                            DateTime FechaPeriodo = Convert.ToDateTime(Dia.ToString("00") + "/" + cboPeriodo.SelectedValue.ToString() + "/" + VariablesLocales.PeriodoContable.AnioPeriodo);

                            ConciliacionTMP = AgenteContabilidad.Proxy.ConciliacionPreliminar(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, cboCuentas.SelectedValue.ToString(), cboMoneda.SelectedValue.ToString());

                            if (ConciliacionTMP.Count > 0)
                            {
                                oFrm = new frmReporteConciliacionPrevia(ConciliacionTMP, ((BancosE)cboBancosEmpresa.SelectedItem).SiglaComercial, ((BancosCuentasE)cboCuentas.SelectedItem).numCuenta, FechaPeriodo, ((MonedasE)cboMoneda.SelectedItem).desMoneda)
                                {
                                    MdiParent = MdiParent
                                };

                                oFrm.Show(); 
                            }
                            else
                            {
                                Global.MensajeComunicacion("No existe conciliación en este Periodo");
                            }
                        }
                        else if (VariablesLocales.oConParametros.ValorReporteConci == 3)
                        {
                            Global.MensajeComunicacion("Este formato esta en construcción aún... !!!!");
                        }
                        else
                        {
                            Global.MensajeComunicacion("Falta configurar en Parámetros Contables el tipo de Reporte de Conciliación... !!!!");
                        }
                    }
                    else
                    {
                        Global.MensajeComunicacion("Falta configurar en Parámetros Contables el tipo de Reporte de Conciliación... !!!!");
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
                if (cboCuentas.SelectedValue != null || txtSaldo.Text != "0.00")
                {
                    List<ConciliadoDcmtoPendienteE> ConciliacionTMP = AgenteContabilidad.Proxy.ReporteConciliadoBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.PeriodoContable.AnioPeriodo, cboPeriodo.SelectedValue.ToString(), cboCuentas.SelectedValue.ToString());

                    if (ConciliacionTMP.Count > Variables.Cero)
                    {
                        String NombreArchivo = String.Empty;
                        String RutaArchivo = CuadrosDialogo.GuardarDocumento("Guardar Archivo", "CONCILIACION_BANCARIA", "Archivos Excel (*.xlsx)|*.xlsx");

                        if (!String.IsNullOrEmpty(RutaArchivo))
                        {
                            if (File.Exists(RutaArchivo)) File.Delete(RutaArchivo);

                            FileInfo newFile = new FileInfo(RutaArchivo);

                            using (ExcelPackage oExcel = new ExcelPackage(newFile))
                            {
                                ExcelWorksheet oHoja = oExcel.Workbook.Worksheets.Add("CONCILIACION_BANCARIA");

                                if (oHoja != null)
                                {
                                    Int32 InicioLinea = 6;

                                    #region Titulos Principales

                                    // Creando Encabezado;
                                    oHoja.Cells["A1"].Value = VariablesLocales.SesionUsuario.Empresa.RazonSocial;

                                    using (ExcelRange Rango = oHoja.Cells[1, 1, 1, 5])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 10, FontStyle.Italic));
                                        Rango.Style.Font.Color.SetColor(Color.Black);
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    }

                                    oHoja.Cells["D2"].Value = " CONCILIACION BANCARIA";

                                    using (ExcelRange Rango = oHoja.Cells[2, 4, 2, 6])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 12, FontStyle.Italic));
                                        Rango.Style.Font.Color.SetColor(Color.Black);
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    }

                                    oHoja.Cells["D3"].Value = cboBancosEmpresa.Text + " " + cboMoneda.Text + " " + cboCuentas.Text;

                                    using (ExcelRange Rango = oHoja.Cells[3, 4, 3, 6])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 12, FontStyle.Italic));
                                        Rango.Style.Font.Color.SetColor(Color.Black);
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    }

                                    oHoja.Cells["D4"].Value = VariablesLocales.PeriodoContable.AnioPeriodo + "-" + cboPeriodo.SelectedValue.ToString();

                                    using (ExcelRange Rango = oHoja.Cells[4, 4, 4, 6])
                                    {
                                        Rango.Merge = true;
                                        Rango.Style.Font.SetFromFont(new Font("Britanic Bold", 7, FontStyle.Italic));
                                        Rango.Style.Font.Color.SetColor(Color.Black);
                                        Rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                                    }

                                    #endregion

                                    #region Cabeceras del Detalle

                                    // PRIMERA
                                    oHoja.Cells[InicioLinea, 1].Value = " FECHA ";
                                    oHoja.Cells[InicioLinea, 2].Value = " DOCUMENTO ";

                                    using (ExcelRange Rango = oHoja.Cells[InicioLinea, 2, InicioLinea, 4])
                                    {
                                        Rango.Merge = true;
                                    }

                                    oHoja.Cells[InicioLinea, 5].Value = " DESCRIPCION ";
                                    oHoja.Cells[InicioLinea, 6].Value = " DEPOSITOS NO REALIZADOS ";
                                    oHoja.Cells[InicioLinea, 7].Value = " CHQUES NO COBRADOS ";

                                    for (int i = 1; i <= 7; i++)
                                    {
                                        oHoja.Cells[InicioLinea, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        oHoja.Cells[InicioLinea, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(148, 145, 140));
                                        oHoja.Cells[InicioLinea, i].Style.Font.Bold = true;
                                        oHoja.Cells[InicioLinea, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                    }

                                    //Aumentando una Fila mas continuar con el detalle
                                    InicioLinea++;

                                    Decimal Debetotal = 0;
                                    Decimal Habertotal = 0;

                                    foreach (ConciliadoDcmtoPendienteE item in ConciliacionTMP)
                                    {
                                        if (item.Orden != "1")
                                        {
                                            oHoja.Cells[InicioLinea, 1].Value = item.fecDocumento;
                                            oHoja.Cells[InicioLinea, 2].Value = item.idDocumento;
                                            oHoja.Cells[InicioLinea, 3].Value = item.serDocumento;
                                            oHoja.Cells[InicioLinea, 4].Value = item.numDocumento;
                                            oHoja.Cells[InicioLinea, 5].Value = item.desGlosa;
                                            oHoja.Cells[InicioLinea, 6].Value = item.Debe;
                                            oHoja.Cells[InicioLinea, 7].Value = item.Haber;
                                            oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                            oHoja.Cells[InicioLinea, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                                            InicioLinea++;
                                        }
                                        else
                                        {
                                            oHoja.Cells[InicioLinea, 1].Value = " ";
                                            oHoja.Cells[InicioLinea, 2].Value = " ";
                                            oHoja.Cells[InicioLinea, 3].Value = " ";
                                            oHoja.Cells[InicioLinea, 4].Value = " ";
                                            oHoja.Cells[InicioLinea, 5].Value = item.desGlosa;
                                            oHoja.Cells[InicioLinea, 6].Value = item.Debe;
                                            oHoja.Cells[InicioLinea, 7].Value = item.Haber;
                                            oHoja.Cells[InicioLinea, 5, InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                            oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                            oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                            InicioLinea++;
                                        }

                                        Debetotal += item.Debe;
                                        Habertotal += item.Haber;
                                    }

                                    oHoja.Cells[InicioLinea, 1].Value = " ";
                                    oHoja.Cells[InicioLinea, 2].Value = " ";
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                    oHoja.Cells[InicioLinea, 4].Value = " ";
                                    oHoja.Cells[InicioLinea, 5].Value = " ";
                                    oHoja.Cells[InicioLinea, 6].Value = Debetotal;
                                    oHoja.Cells[InicioLinea, 7].Value = Habertotal;
                                    oHoja.Cells[InicioLinea, 6, InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                    InicioLinea++;

                                    oHoja.Cells[InicioLinea, 1].Value = " ";
                                    oHoja.Cells[InicioLinea, 2].Value = " ";
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                    oHoja.Cells[InicioLinea, 4].Value = " ";
                                    oHoja.Cells[InicioLinea, 5].Value = "SALDO SEGÚN CONCILIACION ==>";
                                    Decimal SegunCon = Debetotal - Habertotal;
                                    oHoja.Cells[InicioLinea, 6].Value = SegunCon;
                                    Decimal Montosub = Convert.ToDecimal(txtSaldo.Text);
                                    Decimal NegCon = SegunCon - Montosub;
                                    oHoja.Cells[InicioLinea, 7].Value = NegCon;
                                    oHoja.Cells[InicioLinea, 5, InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                    oHoja.Cells[InicioLinea, 7].Style.Numberformat.Format = "###,###,##0.00";
                                    InicioLinea++;


                                    oHoja.Cells[InicioLinea, 1].Value = " ";
                                    oHoja.Cells[InicioLinea, 2].Value = " ";
                                    oHoja.Cells[InicioLinea, 3].Value = " ";
                                    oHoja.Cells[InicioLinea, 4].Value = " ";
                                    oHoja.Cells[InicioLinea, 5].Value = "SALDO SEGÚN LIBRO ==>";

                                    oHoja.Cells[InicioLinea, 6].Value = Montosub;
                                    oHoja.Cells[InicioLinea, 7].Value = " ";
                                    oHoja.Cells[InicioLinea, 5, InicioLinea, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    oHoja.Cells[InicioLinea, 6].Style.Numberformat.Format = "###,###,##0.00";
                                    InicioLinea++;

                                    #endregion

                                    //Ajustando el ancho de las columnas automaticamente
                                    oHoja.Cells.AutoFitColumns(0);
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
                                    Global.MensajeComunicacion("Datos Exportados...");
                                }
                            }
                        }
                    }
                    else
                    {
                        Global.MensajeFault("No hay datos para la exportación...");
                    }
                }
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
                if (LeerVoucher)
                {
                    if (bsVoucherItem.Count > 0)
                    {
                        //se localiza el formulario buscandolo entre los forms abiertos 
                        Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmConciliacionBancariaManual);

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

                        VoucherItemE voucherTMP = (VoucherItemE)bsVoucherItem.Current;

                        oFrm = new frmConciliacionBancariaManual(Convert.ToInt32(cboPeriodo.SelectedValue), voucherTMP, Convert.ToInt32(cboBancosEmpresa.SelectedValue))
                        {
                            MdiParent = this.MdiParent
                        };

                        oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                        oFrm.Show();
                    } 
                }
                else
                {
                    Global.MensajeComunicacion("Tiene que guardar porque ha vuelto a conciliar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (oBancosConciliarLista != null && oBancosConciliarLista.Count > 0)
            {
                foreach (BancosConciliarE item in oBancosConciliarLista)
                {
                    if (txtCodCuenta.Text.Trim() != item.CodCuenta.Trim())
                    {
                        Global.MensajeComunicacion("El Codigo de Cuenta es Diferente.");
                        return false;
                    }
                } 
            }

            return base.ValidarGrabacion();
        }

        #endregion

        public Form GetForm(string Nombre)
        {

            if ((String.IsNullOrEmpty(Nombre))) return null;

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly(); // referencia al ensamblado actual

            foreach (Type Tipo in asm.GetTypes())
            {
                if ((Tipo.Name.ToUpperInvariant() == Nombre.ToUpperInvariant()))
                {
                    // Añado el espacio de nombres de la raiz
                    Nombre = Tipo.Namespace + "." + Tipo.Name;
                    break;
                }
            }

            object Objeto = asm.CreateInstance(Nombre);

            return ((Form)Objeto);
        }

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Tipo == "I")
                {
                    ImportarExcel(txtRuta.Text);
                }
                else if (Tipo == "P")
                {
                    if (!ValidarGrabacion()) { return; }

                    if (oBancosConciliarLista.Count > Variables.Cero)
                    {
                        Int32 TotalReg = oBancosConciliarLista.Count;
                        Int32 cantReg = TotalReg / 10;
                        Int32 Residuo = TotalReg % 10;
                        DateTime fecInicial = Convert.ToDateTime((from mx in oBancosConciliarLista
                                                                  select (DateTime?)mx.Fecha).Min());
                        DateTime fecFinal = Convert.ToDateTime((from mx in oBancosConciliarLista
                                                                select (DateTime?)mx.Fecha).Max());

                        Registros = AgenteContabilidad.Proxy.EliminarBancosConciliar(oBancosConciliarLista[0].idPersona, oBancosConciliarLista[0].idEmpresa, fecInicial, fecFinal,oBancosConciliarLista[0].CodCuenta);

                        for (int conta = 0; conta <= 10; conta++)
                        {
                            List<BancosConciliarE> oListaTemporal = new List<BancosConciliarE>();

                            if (Residuo == oBancosConciliarLista.Count)
                            {
                                for (int i = 0; i < Residuo; i++)
                                {
                                    oListaTemporal.Add(oBancosConciliarLista[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantReg; i++)
                                {
                                    oListaTemporal.Add(oBancosConciliarLista[i]);
                                }
                            }

                            foreach (BancosConciliarE item in oListaTemporal)
                            {
                                oBancosConciliarLista.Remove(item);
                            }

                            foreach (BancosConciliarE item in oListaTemporal)
                            {                               
                                AgenteContabilidad.Proxy.InsertarBancosConciliar(item);
                                Registros++;
                            }

                            oListaTemporal = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oBancosConciliarLista = null;
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgress.Visible = false;
            Cursor = Cursors.Arrow;
            lblProcesando.Text = String.Empty;
            lblProcesando.Visible = false;
            btExaminar.Enabled = true;
            btVerImportados.Visible = true;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                if (Tipo == "I")
                {
                    if (oBancosConciliarLista != null)
                    {
                        btProcesar.Enabled = true;
                        btActualizar.Enabled = false;
                        
                        Global.MensajeComunicacion(String.Format("Se importaron {0} registros", oBancosConciliarLista.Count));
                    }
                    else
                    {
                        btActualizar.Enabled = true;
                        lblProcesando.Text = String.Format("Ha ocurrido un error en la Hoja Excel en la linea {0}. Revise por favor.", LineaError);
                    }
                }
                else if (Tipo == "P")
                {
                    if (Registros > Variables.Cero)
                    {
                        btProcesar.Enabled = false;
                        txtRuta.Text = String.Empty;
                        timer1.Enabled = false;
                        letra = Variables.Cero;
                        Buscar();
                        Global.MensajeComunicacion("Los registros se ingresaron correctamente");
                    }
                    else
                    {
                        btProcesar.Enabled = true;
                        txtRuta.Text = String.Empty;
                        timer1.Enabled = false;
                        letra = Variables.Cero;
                    }
                }
            }
        }

        void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmConciliacionBancariaManual oFrm = sender as frmConciliacionBancariaManual;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoDcmtoPendientexVoucherItem_Load(object sender, EventArgs e)
        {
            //Grid = true;
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Imprimir, true);
            BloquearOpcion(EnumOpcionMenuBarra.Exportar, true);
            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

            Grid = false;
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMoneda.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsVoucherItem_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (ListaVoucherPrincipal != null)
                {
                    lblRegistrosV.Text = "Mov.Banco Registros " + ListaVoucherPrincipal.Count.ToString() + " - Banco: " + ((BancosE)cboBancosEmpresa.SelectedItem).RazonSocial + " Moneda: " + ((MonedasE)cboMoneda.SelectedItem).desAbreviatura;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsConciliadoDcmto_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                if (ListaPendientesPrincipal != null)
                {
                    lblRegistrosC.Text = "Dcmtos.Pendientes Registros " + ListaPendientesPrincipal.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvVoucherItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVoucherItem.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvVoucherItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvVoucherItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvVoucherItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvVoucherItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bsVoucherItem.EndEdit();

                if (e.RowIndex != -1 && dgvVoucherItem.Columns[e.ColumnIndex].Name == "indConciliadoBool")
                {
                    DataGridViewCell cellConciliado = dgvVoucherItem.Rows[e.RowIndex].Cells["indConciliadoBool"];

                    if (cellConciliado != null)
                    {
                        ((VoucherItemE)bsVoucherItem.Current).Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                        ((VoucherItemE)bsVoucherItem.Current).indConciliado = Convert.ToBoolean(cellConciliado.Value) == true ? "S" : "N"; 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvConciliadoDcmtoPen_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvConciliadoDcmtoPen.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvConciliadoDcmtoPen.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvConciliadoDcmtoPen_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvConciliadoDcmtoPen.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvConciliadoDcmtoPen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bsConciliadoDcmto.EndEdit();

                if (e.RowIndex != -1 && dgvConciliadoDcmtoPen.Columns[e.ColumnIndex].Name == "indConciliadoBool2")
                {
                    DataGridViewCell cellConciliado = dgvConciliadoDcmtoPen.Rows[e.RowIndex].Cells["indConciliadoBool2"];

                    if (cellConciliado != null)
                    {
                        ((ConciliadoDcmtoPendienteE)bsConciliadoDcmto.Current).Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                        ((ConciliadoDcmtoPendienteE)bsConciliadoDcmto.Current).indConciliado = Convert.ToBoolean(cellConciliado.Value) == true ? "S" : "N";
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvVoucherItem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (ListaVoucherPrincipal != null && ListaVoucherPrincipal.Count > 0)
                {
                    // Por Razón Social
                    if (e.ColumnIndex == dgvVoucherItem.Columns["RazonSocial"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.RazonSocial ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.RazonSocial descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    // Por tipo de documento
                    if (e.ColumnIndex == dgvVoucherItem.Columns["idDocumento"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.idDocumento ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.idDocumento descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    // Por serie
                    if (e.ColumnIndex == dgvVoucherItem.Columns["serDocumento"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.serDocumento ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.serDocumento descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    // Por número
                    if (e.ColumnIndex == dgvVoucherItem.Columns["numDocumento"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.numDocumento ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.numDocumento descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    // Por fecha
                    if (e.ColumnIndex == dgvVoucherItem.Columns["fecDocumento"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.fecDocumento ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.fecDocumento descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    // Por monto
                    if (e.ColumnIndex == dgvVoucherItem.Columns["monto"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.monto ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.monto descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    // Por IndConciliado
                    if (e.ColumnIndex == dgvVoucherItem.Columns["indConciliadoBool"].Index)
                    {
                        if (OrdenarV)
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.indConciliadoBool ascending select x).ToList();
                            OrdenarV = false;
                        }
                        else
                        {
                            ListaVoucherPrincipal = (from x in ListaVoucherPrincipal orderby x.indConciliadoBool descending select x).ToList();
                            OrdenarV = true;
                        }
                    }

                    bsVoucherItem.DataSource = ListaVoucherPrincipal;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvConciliadoDcmtoPen_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (ListaPendientesPrincipal != null && ListaPendientesPrincipal.Count > 0)
                {
                    // Por Razón Social
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["RazonSocial2"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.RazonSocial ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.RazonSocial descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    // Por tipo de documento
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["idDocumento2"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.idDocumento ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.idDocumento descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    // Por serie
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["serDocumento2"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.serDocumento ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.serDocumento descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    // Por número
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["numDocumento2"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.numDocumento ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.numDocumento descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    // Por fecha
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["fecDocumento2"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.fecDocumento ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.fecDocumento descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    // Por monto
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["impMonto"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.impMonto ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.impMonto descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    // Por indConciliado
                    if (e.ColumnIndex == dgvConciliadoDcmtoPen.Columns["indConciliadoBool2"].Index)
                    {
                        if (OrdenarP)
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.indConciliadoBool ascending select x).ToList();
                            OrdenarP = false;
                        }
                        else
                        {
                            ListaPendientesPrincipal = (from x in ListaPendientesPrincipal orderby x.indConciliadoBool descending select x).ToList();
                            OrdenarP = true;
                        }
                    }

                    bsConciliadoDcmto.DataSource = ListaPendientesPrincipal;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboCuentas.SelectedValue != null)
            {
                txtCodCuenta.Text = cboCuentas.SelectedValue.ToString();
                BancosCuentasE Obancotmp = AgenteMaestro.Proxy.ObtenerBancosPorCodCuenta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCodCuenta.Text);
                txtNomCuenta.Text = Obancotmp.DescripcionCuenta;
            }
            else
            {
                txtCodCuenta.Text = "";
                txtNomCuenta.Text = "";
            }

            Buscar();
        }   

        private void btExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = CuadrosDialogo.BuscarArchivo("Buscar Archivo Excel", "Archivos Excel (.xlsx)|*.xlsx");

                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    btActualizar.Enabled = true;
                }
                else
                {
                    btActualizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRuta.Text))
                {
                    oBancosConciliarLista = new List<BancosConciliarE>();
                    btActualizar.Enabled = false;
                    btProcesar.Enabled = false;
                    btExaminar.Enabled = false;
                    lblProcesando.Visible = true;
                    btVerImportados.Visible = false;
                    Cursor = Cursors.WaitCursor;
                    pbProgress.Visible = true;
                    lblProcesando.Text = "Preparando el archivo excel para su importación...";
                    Tipo = "I";

                    _bw.RunWorkerAsync();
                }
                else
                {
                    Global.MensajeFault("Tiene que buscar un archivo");
                }
            }
            catch (Exception ex)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }

                Global.MensajeError(ex.Message);
            }
        }

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                lblProcesando.Text = String.Empty;
                Marquee = "Ingresando la información a la Base de Datos...";
                Cursor = Cursors.WaitCursor;
                btActualizar.Enabled = false;
                btProcesar.Enabled = false;
                btExaminar.Enabled = true;
                timer1.Enabled = true;
                lblProcesando.Visible = true;
                pbProgress.Visible = true;
                btVerImportados.Visible = false;
                Tipo = "P";

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _bw.Dispose();
                }

                Global.MensajeError(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            letra += 1;

            if (letra == Marquee.Length)
            {
                lblProcesando.Text = String.Empty;
                letra = 0;
            }
            else
            {
                lblProcesando.Text += Marquee.Substring(letra - 1, 1);
            }
        }

        private void btConciliado_Click(object sender, EventArgs e)
        {
            try
            {
                LeerVoucher = false;
                List<BancosConciliarE> ListaBancoConciliado = AgenteContabilidad.Proxy.ListarBancosConciliar(Convert.ToInt32(cboBancosEmpresa.SelectedValue), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo), Convert.ToInt32(cboPeriodo.SelectedValue), txtCodCuenta.Text);
                String NumeroV = String.Empty;
                String NumeroC = String.Empty;
                Boolean Encontro = true;

                foreach (VoucherItemE item in ListaVoucherPrincipal)
                {
                    NumeroV = item.numDocumento.Trim().PadLeft(10, '0');
                    NumeroV = Global.Derecha(NumeroV, 10);
                    Encontro = false;

                    // Validar Con Numero de Documento
                    foreach (BancosConciliarE item2 in ListaBancoConciliado)
                    {
                        NumeroC = item2.Operacion.Trim().PadLeft(10, '0');
                        NumeroC = Global.Derecha(NumeroC, 10);

                        if (!item.indConciliadoBool)
                        {
                            if (item2.Fecha.Date == item.fecDocumento.Value.Date && item2.Monto == item.monto && NumeroV == NumeroC)
                            {
                                if (!item2.Conciliado)
                                {
                                    item2.idLocal = item.idLocal;
                                    item2.AnioPeriodo = item.AnioPeriodo;
                                    item2.MesPeriodo = item.MesPeriodo;
                                    item2.numVoucher = item.numVoucher;
                                    item2.idComprobante = item.idComprobante;
                                    item2.numFile = item.numFile;
                                    item2.numItem = item.numItem;
                                    item2.Conciliado = true;
                                    item.indConciliadoBool = true;
                                    item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                    Encontro = true;

                                    AgenteContabilidad.Proxy.ActualizarBancosConciliar(item2);
                                    break; 
                                }
                            }
                        }
                    }

                    // Validar Si no Encuentra por Fecha y Monto
                    if (!Encontro)
                    {
                        foreach (BancosConciliarE item2 in ListaBancoConciliado)
                        {
                            if (!item.indConciliadoBool)
                            {
                                if (item2.Fecha.Date == item.fecDocumento.Value.Date && item2.Monto == item.monto)
                                {
                                    if (!item2.Conciliado)
                                    {
                                        item2.idLocal = item.idLocal;
                                        item2.AnioPeriodo = item.AnioPeriodo;
                                        item2.MesPeriodo = item.MesPeriodo;
                                        item2.numVoucher = item.numVoucher;
                                        item2.idComprobante = item.idComprobante;
                                        item2.numFile = item.numFile;
                                        item2.numItem = item.numItem;
                                        item2.Conciliado = true;
                                        item.indConciliadoBool = true;
                                        item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                                        Encontro = true;

                                        AgenteContabilidad.Proxy.ActualizarBancosConciliar(item2);
                                        break; 
                                    }
                                }
                            }
                        }
                    }
                }

                bsVoucherItem.DataSource = ListaVoucherPrincipal;
                bsVoucherItem.ResetBindings(false);

                Global.MensajeComunicacion("Conciliación terminada...!!!");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void dgvVoucherItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Editar();
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            foreach (VoucherItemE item in ListaVoucherPrincipal)
            {
                item.indConciliadoBool = false;
                item.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
            }

            bsVoucherItem.DataSource = ListaVoucherPrincipal;
            bsVoucherItem.ResetBindings(false);
        }

        private void btVerImportados_Click(object sender, EventArgs e)
        {
            try
            {

                List<BancosConciliarE> ListaBancoConciliado = AgenteContabilidad.Proxy.ListarBancosConciliar(Convert.ToInt32(cboBancosEmpresa.SelectedValue), VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(VariablesLocales.PeriodoContable.AnioPeriodo), Convert.ToInt32(cboPeriodo.SelectedValue), txtCodCuenta.Text);
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDocImportadosConciliacion);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                oFrm = new frmDocImportadosConciliacion(ListaBancoConciliado)
                {
                    MdiParent = MdiParent
                };

                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}