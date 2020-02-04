using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Almacen
{
    public partial class frmGenerarAperturaAlmacen : FrmMantenimientoBase
    {

        public frmGenerarAperturaAlmacen()
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
        private List<MovimientoAlmacenE> oValorizacion = null;
        BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation = true };
        String Marquee = String.Empty;
        Int32 Letra = 0;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");

        #endregion

        #region Procedimientos de Usuario

        private void LlenarCombos()
        {
            List<AlmacenE> oListaAlmacen = AgenteAlmacen.Proxy.ListarAlmacenCombo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, 0);
            oListaAlmacen.Add(new AlmacenE() { idAlmacen = Variables.Cero, desAlmacen = Variables.Seleccione });
            ComboHelper.LlenarCombos<AlmacenE>(cboAlmacen, (from x in oListaAlmacen orderby x.idAlmacen select x).ToList(), "idAlmacen", "desAlmacen");
                        
            cboMesIni.DataSource = FechasHelper.CargarMesesContable("MA"); 
            cboMesIni.ValueMember = "MesId";
            cboMesIni.DisplayMember = "MesDes";
            cboMesIni.SelectedValue = VariablesLocales.FechaHoy.ToString("MM");

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
        }

        private void CambioFecha()
        {
            cboAnioini.SelectedValue = Convert.ToInt32(Anio);
            cboMesIni.SelectedValue = Convert.ToInt32(12);
            Int32 Anioact = Convert.ToInt32(cboAnioini.SelectedValue);
            Int32 Mesact = DateTime.Now.Month;
            String MesDato = Mesact.ToString("00");

            //if (Mesact >= 10)
            //{
            //    MesDato = Convert.ToString(Mesact);
            //}
            //else if (Mesact <= 9)
            //{
            //    MesDato = Convert.ToString("0" + Mesact);
            //}

            Anioact++;

            String Aniodat = Convert.ToString(Anioact);

            String fechaIngPrim = FechasHelper.ObtenerPrimerdia(MesDato, Aniodat);
            DateTime Fecha = Convert.ToDateTime(fechaIngPrim);

            dtpFechaIngreso.Value = Fecha;
        }

        private void CambioAnio()
        {
            Int32 Anioact = Convert.ToInt32(cboAnioini.SelectedValue);
            Int32 Mesact = DateTime.Now.Month;
            //String MesDato = String.Empty;
            String MesDato = Mesact.ToString("00");

            //if (Mesact >= 10)
            //{
            //    MesDato = Convert.ToString(Mesact);
            //}
            //else if (Mesact <= 9)
            //{
            //    MesDato = Convert.ToString("0" + Mesact);
            //}

            Anioact++;
            String Aniodat = Convert.ToString(Anioact);
            String fechaIngPrim = FechasHelper.ObtenerPrimerdia(MesDato, Aniodat);
            DateTime Fecha = Convert.ToDateTime(fechaIngPrim);

            dtpFechaIngreso.Value = Fecha;
        }

        #endregion

        #region Procedimientos de Heredados

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

        #region Eventos de Usuario

        void _bw_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Int32 Almacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                String Anio = Convert.ToString(cboAnioini.SelectedValue);
                String Mes = Convert.ToString(cboMesIni.SelectedValue);
                string FechaIngreso = dtpFechaIngreso.Value.ToString("yyyyMMdd");
                String Usuario = VariablesLocales.SesionUsuario.Credencial;

                oValorizacion = AgenteAlmacen.Proxy.GenerarAperturaAlmacen(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Almacen, Anio, Mes, FechaIngreso, Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAceptar.Enabled = true;
            pbProgress.Visible = false;
            lblProcesando.Visible = false;
            lblProcesando.Text = String.Empty;
            Marquee = String.Empty;
            Letra = 0;
            timer1.Enabled = false;
            Cursor = Cursors.Arrow;
            
            _bw.CancelAsync();
            _bw.Dispose();

            if (e.Error != null)
            {
                Global.MensajeFault(String.Format("Mensaje de Error: {0}", (e.Error.Message).ToString()));
            }
            else if (e.Cancelled == true)
            {
                Global.MensajeComunicacion("La operación ha sido cancelada.");
            }
            else
            {
                Global.MensajeComunicacion("Proceso Terminado...!!!");
            }
        }

        #endregion

        #region Eventos

        private void frmProcesoValorizaciondeAlmacen_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            CambioFecha();         
            CheckForIllegalCrossThreadCalls = false;
            _bw.DoWork += new DoWorkEventHandler(_bw_Dowork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
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
                _bw.CancelAsync();
                _bw.Dispose();   
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
        
        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {  
                    
        }

        private void cboAnioini_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CambioAnio();
        }

        #endregion

    }
}
