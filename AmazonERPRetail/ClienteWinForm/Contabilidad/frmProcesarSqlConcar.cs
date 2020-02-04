using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmProcesarSqlConcar : FrmMantenimientoBase
    {
        public frmProcesarSqlConcar()
        {
            InitializeComponent();

            LlenarCombo();
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        readonly BackgroundWorker _bw = new BackgroundWorker();
        Int32 Registros = Variables.Cero;
        String Marquee = String.Empty;
        Int32 letra = 0;
        String Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;

        #endregion Variables

        #region Procedimientos de Usuario

        void LlenarCombo()
        {
            List<Empresa> oListaEmpresas = new List<Empresa>(VariablesLocales.SesionUsuario.UsuarioEmpresas);
            Empresa oItem = new Empresa() { IdEmpresa = Variables.Cero, RazonSocial = Variables.Seleccione };
            oListaEmpresas.Add(oItem);

            ComboHelper.LlenarCombos<Empresa>(cboEmpresas, (from x in oListaEmpresas orderby x.IdEmpresa select x).ToList(), "IdEmpresa", "RazonSocial");



            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;

            cboAño.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboAño.ValueMember = "AnioId";
            cboAño.DisplayMember = "AnioDes";
            cboAño.SelectedValue = anioFin ;


        }

        #endregion Procedimientos de Usuario

        #region Eventos de Usuario

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Registros = AgenteContabilidad.Proxy.MigrarConcarSQL(txtCodEmpresa.Text.Trim(), Convert.ToString(cboAño.SelectedValue), Convert.ToInt32(cboEmpresas.SelectedValue));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Registros > Variables.Cero)
            {
                lblProcesando.Visible = false;
                lblProcesando.Text = String.Empty;
                Marquee = String.Empty;
                letra = 0;
                timer1.Enabled = false;
                
                Cursor = System.Windows.Forms.Cursors.Arrow;
                _bw.CancelAsync();
                _bw.Dispose();

                Global.MensajeComunicacion("El proceso ha concluido...");
            }
        }

        #endregion Eventos de Usuario

        #region Eventos

        private void frmProcesarSqlConcar_Load(object sender, EventArgs e)
        {
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.WorkerSupportsCancellation = true;

            BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
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

        private void btProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodEmpresa.Text.Trim()))
                {
                    Global.MensajeFault("Debe ingresar un código de empresa.");
                    txtCodEmpresa.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(Convert.ToString(cboAño.SelectedValue)))
                {
                    Global.MensajeFault("Debe ingresar un ejercicio.");
                    cboAño.Focus();
                    return;
                }

                if (Convert.ToInt32(cboEmpresas.SelectedValue) == Variables.Cero)
                {
                    Global.MensajeFault("Debe escoger una Empresa Local.");
                    cboEmpresas.Focus();
                    return;
                }

                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                }

                lblProcesando.Visible = true;
                timer1.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Marquee = "Migración en Proceso...";
                pbProgress.Visible = true;
                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion Eventos

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmBusquedaEmpresaConcar oFrm = new frmBusquedaEmpresaConcar();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.empresa != null)
            {
                txtCodEmpresa.Text = oFrm.empresa.CodEmpresa;
                cboEmpresas.SelectedValue = oFrm.empresa.idEmpresa;
            }
        }

    }
}
