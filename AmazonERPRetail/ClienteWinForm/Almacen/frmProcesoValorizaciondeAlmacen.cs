using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Generales;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Almacen
{
    public partial class frmProcesoValorizaciondeAlmacen : FrmMantenimientoBase
    {
        public frmProcesoValorizaciondeAlmacen()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            LlenarCombos();
        }

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }

        readonly BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation = true };

        //private Thread _backgroundWorkerThread;
        private int cantReg = 0;
        Int32 idArticulo;
        String Marquee = String.Empty;
        Int32 Letra = 0;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            cboTipoAlmacen.DataSource = null;
            List<ParTabla> ListaOperacion = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPART");
            ListaOperacion.Add(new ParTabla() { IdParTabla = Variables.Cero, Nombre = Variables.Todos });
            ComboHelper.RellenarCombos<ParTabla>(cboTipoAlmacen, (from x in ListaOperacion orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre", false);

            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
                        
            cboMesIni.DataSource = FechasHelper.CargarMesesContable("MA"); 
            cboMesIni.ValueMember = "MesId";
            cboMesIni.DisplayMember = "MesDes";

            cboMesFin.DataSource = FechasHelper.CargarMesesContable("MA"); 
            cboMesFin.ValueMember = "MesId";
            cboMesFin.DisplayMember = "MesDes";

            Int32 anioInicio = 0;
            Int32 anioFin = 0;
            Int32 anioInicio1 = 0;
            Int32 anioFin1 = 0;

            anioFin = Convert.ToInt32(Anio);
            anioFin1 = anioFin - 10;
            anioInicio = Convert.ToInt32(Anio);
            anioInicio1 = anioInicio - 10;

            cboAnioini.DataSource = FechasHelper.CargarAnios(anioInicio1, anioInicio);
            cboAnioini.ValueMember = "AnioId";
            cboAnioini.DisplayMember = "AnioDes";

            cboAnioFin.DataSource = FechasHelper.CargarAnios(anioFin1, anioFin);
            cboAnioFin.ValueMember = "AnioId";
            cboAnioFin.DisplayMember = "AnioDes";
        }

        #endregion

        #region Eventos de Usuario

        private void Bw_Dowork(object sender, DoWorkEventArgs e)
        {
            if (rbTodos.Checked)
            {
                idArticulo = Variables.Cero;
            }

            try
            {
                String Valor = "N";
                //_backgroundWorkerThread = Thread.CurrentThread;

                //if (_bw.CancellationPending)
                //{
                //    e.Cancel = true;
                //    return;
                //}
                //else
                //{
                if (chkConversion.Checked)
                {
                    Valor = "S";
                }
                else
                {
                    Valor = "N";
                }

                cantReg = AgenteAlmacen.Proxy.ValorizaciondeAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboAlmacen.SelectedValue),
                                                                    Convert.ToInt32(idArticulo), Convert.ToString(cboAnioini.SelectedValue),
                                                                    Convert.ToString(cboMesIni.SelectedValue), Convert.ToString(cboAnioFin.SelectedValue),
                                                                    Convert.ToString(cboMesFin.SelectedValue), Valor);
                //}
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAceptar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            Letra = 0;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;

            if (e.Error != null)
            {
                Global.MensajeError(String.Format("Ha ocurrido la excepción: {0}", e.Error.Message));
            }
            else if (e.Cancelled)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                if (cantReg > 0)
                {
                    Global.MensajeComunicacion("Proceso Terminado...!!!"); 
                }
                else
                {
                    Global.MensajeComunicacion("No se ha procesado ningún almacén...!!!");
                }
            }

            _bw.CancelAsync();
            _bw.Dispose();
        }

        public override bool ValidarGrabacion()
        {
            if (cboAlmacen.SelectedIndex == 0)
            {
                Global.MensajeComunicacion("Debe Seleccionar un Tipo de Almacen");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmProcesoValorizaciondeAlmacen_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            cboAnioini.SelectedValue = Convert.ToInt32(Anio);
            cboAnioFin.SelectedValue = Convert.ToInt32(Anio);
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(Bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGrabacion())
                {
                    return;
                }

                btnAceptar.Enabled = false;
                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                Marquee = "Procesando...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_bw.IsBusy)
            {
                //if (_backgroundWorkerThread != null)
                //{
                //    _backgroundWorkerThread.Abort();
                    _bw.CancelAsync();
                    _bw.Dispose();
                    //GC.Collect();
                //} 
            }

            timer1.Enabled = false;
            btnAceptar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            Letra = 0;

            Cursor = Cursors.Arrow;
            Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Letra += 1;

            if (Letra == Marquee.Length)
            {
                lblProcesando.Text = String.Empty;
                Letra = 0;
            }
            else
            {
                lblProcesando.Text += Marquee.Substring(Letra - 1, 1);
            }
        }

        private void btArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                AlmacenE oAlmacen = (AlmacenE)cboAlmacen.SelectedItem;
                frmBuscarArticulo oFrm = new frmBuscarArticulo(oAlmacen);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Articulo != null)
                {
                    idArticulo = oFrm.Articulo.idArticulo;
                    txtArt.Text = oFrm.Articulo.codArticulo;
                    txtNomArt.Text = oFrm.Articulo.nomArticulo;
                }
            }
           catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            btArticulo.Enabled = !rbTodos.Checked;
        }

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {          
            if(Convert.ToInt32(cboAlmacen.SelectedValue) == Variables.Cero)
            {
                
            }
            else
	        {
                btArticulo.PerformClick();
            }
        }

        private void cboTipoAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (chkConversion.Checked == true)
            {
                cboAlmacen.Enabled = false;
            }
            else
            {
                cboAlmacen.Enabled = true;
            }

            cboAlmacen.DataSource = null;
            Int32 tipalm = Convert.ToInt32(cboTipoAlmacen.SelectedValue);
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, tipalm);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransferencia.Checked == true)
            {
                cboAlmacen.Enabled = false;
            }
            else
            {
                cboAlmacen.Enabled = true;
            }
        }

        #endregion

    }
}
