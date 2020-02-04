using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
//using Entidades.Asistencia;
using Infraestructura;
//using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmMayorizarSaldosCostos : FrmMantenimientoBase
    {

        #region Constructores
        public frmMayorizarSaldosCostos()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            LlenarCombos();
        }
        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        List<Con_SaldosCostosE> oSaldos = null;

        string sParametro = string.Empty;
        string Anio = VariablesLocales.FechaHoy.ToString("yyyy");
        int anioInicio = 0;
        int anioFin = 0;
        #endregion

        #region Procedimiento de Usuario

        void LlenarCombos()
        {
            //Sucursales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            LocalE ItemLocal = new LocalE { IdLocal = Variables.Cero, Nombre = Variables.Todos };
            listaLocales.Add(ItemLocal);
            listaLocales = (from x in listaLocales orderby x.IdLocal select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursales, listaLocales, "idLocal", "Nombre", false);


            /////ANIOS/////
            anioFin = Convert.ToInt32(Anio);
            anioInicio = anioFin - 10;


            cboPeriodo.DataSource = FechasHelper.CargarAnios(anioInicio, anioFin + 2);
            cboPeriodo.ValueMember = "AnioId";
            cboPeriodo.DisplayMember = "AnioDes";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pbProgress.Visible = true;
            Cursor = Cursors.WaitCursor;
            System.Threading.Thread.Sleep(500);
            try
            {
                String as_anno = Convert.ToString(cboPeriodo.SelectedValue);
                oSaldos = AgenteContabilidad.Proxy.MayorizarCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, as_anno, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas);
                Global.MensajeComunicacion("Mayorizacion de Saldos Exitosa");

                pbProgress.Visible = false;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Eventos



        private void frmMayorizarSaldosCostos_Load(object sender, EventArgs e)
        {
            cboPeriodo.SelectedValue = Convert.ToInt32(Anio);
        }

        #endregion

    }
}
