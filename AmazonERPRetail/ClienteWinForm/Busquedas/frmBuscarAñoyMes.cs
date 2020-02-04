using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Generales;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;
using Infraestructura.Enumerados;
using Presentadora.AgenteServicio;
//using Entidades.Asistencia;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarAñoyMes : FrmBusquedaBase
    {
        public frmBuscarAñoyMes()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvAnioYmes);
        }

        #region Variables

        //public AsistenciaServiceAgent AgenteAsistencia { get { return new AsistenciaServiceAgent(); } }
        //public EstadoPlanillaE oEstadoPlanilla = null;

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {

                //bsEstadoPlanilla.DataSource = AgenteAsistencia.Proxy.ListarEstadoPlanilla(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
                dgvAnioYmes.AutoResizeColumns();

                gbResultados.Text = " Registros Encontrados" + bsEstadoPlanilla.Count.ToString();

                //base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsEstadoPlanilla.Count > 0)
            {
                //oEstadoPlanilla = (EstadoPlanillaE)bsEstadoPlanilla.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("Presione Cancelar.");
            }
        }

        #endregion

        #region Eventos

        private void FrmBuscarAñoyMes_Load(object sender, EventArgs e)
        {
            dgvAnioYmes.AutoResizeColumns();
            Buscar();
        }

        private void dgvAnioYmes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvAnioYmes, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvAnioYmes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsEstadoPlanilla.Count > Variables.Cero)
            {
                Aceptar();
            }
        }


        #endregion

       

       

    }
}
