using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad.Procesos
{
    public partial class frmExportarRegistroDiario : FrmMantenimientoBase
    {

        public frmExportarRegistroDiario()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvTipoComprobantes, true);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<VoucherItemE> oListaRegistroDiario = new List<VoucherItemE>();
        List<VoucherItemE> oListaRegistroDiarioTmp = null;
        List<ComprobantesE> oListaComprobantesTmp = null;
        List<ComprobantesE> oListaComprobantes = new List<ComprobantesE>();
        String ComTmp = String.Empty;
        String RutaGeneral = String.Empty;
        String Marque = String.Empty;
        String UNO = String.Empty;
        readonly BackgroundWorker _bw = new BackgroundWorker();
        String Marquee = String.Empty;
        Int32 letra = 0;
        #endregion

        #region Procedimientos de Usuario

        void ExportarTXT(String Ruta)
        {
            try
            {
                if (!String.IsNullOrEmpty(Ruta))
                {
                    //Borrando el archivo...
                    if (File.Exists(Ruta))
                    {
                        File.Delete(Ruta);
                    }

                    using (StreamWriter oSw = new StreamWriter(Ruta, true, Encoding.Default))
                    {
                        StringBuilder Linea = new StringBuilder();

                        foreach (VoucherItemE item in oListaRegistroDiario)
                        {
                            #region Insertar Linea

                            String fecOperacion = String.Empty;
                            String fecDocumento = String.Empty;
                            String fecVencimiento = String.Empty;

                            if (item.fecOperacion != null)
                            {
                                fecOperacion = item.fecOperacion.Value.ToString("dd/MM/yyyy");
                            }

                            if (item.fecDocumento != null)
                            {
                                fecDocumento = item.fecDocumento.Value.ToString("dd/MM/yyyy");
                            }

                            if (item.fecVencimiento != null)
                            {
                                fecVencimiento = item.fecVencimiento.Value.ToString("d");
                            }

                            Linea.Append(item.idEmpresa).Append("|").Append(item.idLocal).Append("|").Append(item.AnioPeriodo).Append("|");
                            Linea.Append(item.MesPeriodo).Append("|").Append(item.idComprobante).Append("|").Append(item.desComprobante).Append("|");
                            Linea.Append(item.numFile).Append("|").Append(item.desFile).Append("|").Append(item.numVoucher).Append("|").Append(item.Campo3).Append("|");
                            Linea.Append(fecOperacion).Append("|").Append(item.GlosaGeneral).Append("|").Append(item.numItem).Append("|").Append(item.CodPlanCuenta).Append("|");
                            Linea.Append(item.numVerPlanCuentas).Append("|").Append(item.codCuenta).Append("|").Append(item.desCuenta).Append("|").Append(item.TD).Append("|");
                            Linea.Append(item.Ruc).Append("|").Append(item.RazonSocial).Append("|").Append(item.idMoneda).Append("|").Append(item.desMoneda).Append("|");
                            Linea.Append(item.desMoneda).Append("|").Append(item.tipCambio).Append("|").Append(item.codSunat).Append("|").Append(item.idDocumento).Append("|");
                            Linea.Append(item.serDocumento).Append("|").Append(item.numDocumento).Append("|").Append(fecDocumento).Append("|").Append(fecVencimiento).Append("|");
                            Linea.Append(item.idCCostos).Append("|").Append(item.desCCostos).Append("|").Append(item.indDebeHaber).Append("|").Append(item.DebeSoles).Append("|");
                            Linea.Append(item.HaberSoles).Append("|").Append(item.DebeDolares).Append("|").Append(item.HaberDolares).Append("|");

                            oSw.WriteLine(Linea.ToString());
                            Linea.Clear();

                            #endregion Insertar Linea
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

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                bsComprobantes.DataSource = AgenteContabilidad.Proxy.ListarComprobantes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                lblRegistros.Text = "Registros " + bsComprobantes.Count.ToString();
                dgvTipoComprobantes.AutoResizeColumns();
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
                RutaGeneral = CuadrosDialogo.GuardarDocumento("Guardar en", "LIBRO_REGISTRO_DIARIO", "Documentos de Texto (*.txt)|*.txt");

                if (!String.IsNullOrEmpty(RutaGeneral))
                {
                    Marque = "Importando los registros a Excel...";
                    Cursor = Cursors.WaitCursor;
                    pbProgress.Visible = true;
                    timer1.Enabled = true;
                    lblProcesando.Visible = true;
                    _bw.RunWorkerAsync();
                }
                else
                {
                    if (_bw.IsBusy)
                    {
                        _bw.CancelAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                oListaComprobantesTmp = (List<ComprobantesE>)bsComprobantes.List;

                if (oListaComprobantesTmp.Count > 0)
                {
                    DateTime FechaIni = dtpIngreso.Value.Date;
                    DateTime FechaFin = dtpFinal.Value.Date;
                    Int32 idLocal = VariablesLocales.SesionLocal.IdLocal;

                    foreach (ComprobantesE item in oListaComprobantesTmp)
                    {
                        String idComprobanteIni = item.idComprobante;
                        String idComprobanteFin = item.idComprobante;

                        if (item.Check == true)
                        {
                            oListaRegistroDiarioTmp = AgenteContabilidad.Proxy.RegistroDeDiarioTxt(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                  idLocal, FechaIni, FechaFin, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                  idComprobanteIni, idComprobanteFin);
                            foreach (VoucherItemE item2 in oListaRegistroDiarioTmp)
                            {
                                oListaRegistroDiario.Add(item2);
                            }
                        }
                    }

                    ExportarTXT(RutaGeneral);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Arrow;
            panel3.Cursor = Cursors.Arrow;
            btExportar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            letra = 0;
            timer1.Enabled = false;
            Cursor = System.Windows.Forms.Cursors.Arrow;

            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else
            {
                Global.MensajeComunicacion("Proceso Terminado...!!!");
            }
        }

        #endregion

        #region Eventos

        private void frmExportarRegistroDiario_Load(object sender, EventArgs e)
        {
            Grid = true;
            dtpIngreso.Value = Convert.ToDateTime(1 + "/" + "01" + "/" + dtpIngreso.Value.Year.ToString());
            BloquearOpcion(EnumOpcionMenuBarra.Buscar, true);
            Buscar();
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                oListaRegistroDiario = new List<VoucherItemE>();
                Cursor = Cursors.WaitCursor;
                panel3.Cursor = Cursors.WaitCursor;
                btExportar.Enabled = false;
                Marquee = "Procesando...";
                Imprimir();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            oListaComprobantesTmp = (List<ComprobantesE>)bsComprobantes.List;

            if (oListaComprobantesTmp.Count > 0)
            {
                foreach (ComprobantesE item in oListaComprobantesTmp)
                {
                    if (chkTodos.Checked == true)
                    {
                        item.Check = true;
                    }
                    else
                    {
                        item.Check = false;
                    }
                }

                bsComprobantes.DataSource = oListaComprobantesTmp;
                bsComprobantes.ResetBindings(false);
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

        #endregion

    }
}
