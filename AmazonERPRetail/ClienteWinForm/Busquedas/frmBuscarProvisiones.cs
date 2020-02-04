using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarProvisiones : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarProvisiones()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            this.label1.BringToFront();
            txtFiltro.BringToFront();
            btnBuscar.BringToFront();
            gbResultados.SendToBack();
            FormatoGrid(dgvProvisiones);
        }

        public frmBuscarProvisiones(String Tipo_)
            :this()
        {
            Tipo = Tipo_;

            if (Tipo == "Rever")
            {
                Text = "Provisiones por Revertir";
            }
            else if (Tipo == "PorRecibir")
            {
                Text = "Provisiones por Recibir";
            }
            else if (Tipo == "NCDevolucion")
            {
                Text = "Nota de Credito Por Devolucion";
            }
            else //if (Tipo == "Normal")
            {
                Text = "Búsqueda de Provisiones";
            }
        } 

        #endregion

        #region Variables

        CtasPorPagarServiceAgent AgenteCtas { get { return new CtasPorPagarServiceAgent(); } }
        List<ProvisionesE> oListaProvisiones = null;
        String Tipo = String.Empty;

        public ProvisionesE oProvision = null;

        #endregion

        #region Procedimientos de Usuario

        void BuscarFiltro()
        {
            if (Tipo == "Rever" || Tipo == "PorRecibir" || Tipo == "ProvLiquiImp") 
            {
                if (!String.IsNullOrWhiteSpace(txtFiltro.Text) && !String.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    bsBase.DataSource = (from x in oListaProvisiones
                                         where x.RazonSocial.ToUpper().Contains(txtFiltro.Text.Trim().ToUpper())
                                         && (x.NumSerie.ToUpper() + "-" + x.NumDocumento.ToUpper()).Contains(txtDocumento.Text.Trim().ToUpper())
                                         select x).ToList();
                }

                if (!String.IsNullOrWhiteSpace(txtFiltro.Text) && String.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    bsBase.DataSource = (from x in oListaProvisiones
                                         where x.RazonSocial.ToUpper().Contains(txtFiltro.Text.Trim().ToUpper())
                                         select x).ToList();
                }

                if (String.IsNullOrWhiteSpace(txtFiltro.Text) && !String.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    bsBase.DataSource = (from x in oListaProvisiones
                                         where (x.NumSerie.ToUpper() + "-" + x.NumDocumento.ToUpper()).Contains(txtDocumento.Text.Trim().ToUpper())
                                         select x).ToList();
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    bsBase.DataSource = (from x in oListaProvisiones
                                         where (x.NumSerie + "-" + x.NumDocumento).Contains(txtDocumento.Text.Trim())
                                         orderby x.NumDocumento ascending
                                         select x).ToList();
                }
            }

            base.Buscar();
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                if (Tipo == "Rever")
                {
                    bsBase.DataSource = oListaProvisiones = AgenteCtas.Proxy.ProvisionesPorRevertir(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                    bsBase.ResetBindings(false);

                    if (!String.IsNullOrEmpty(txtFiltro.Text.Trim()))
                    {
                        BuscarFiltro();
                    }
                }
                else if (Tipo == "PorRecibir")
                {
                    bsBase.DataSource = oListaProvisiones = AgenteCtas.Proxy.ProvisionesPorRecibir(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal);
                    bsBase.ResetBindings(false);

                    if (!String.IsNullOrEmpty(txtFiltro.Text.Trim()))
                    {
                        BuscarFiltro();
                    }
                }
                else if (Tipo == "NCDevolucion")
                {
                    bsBase.DataSource = oListaProvisiones = AgenteCtas.Proxy.ListarProvisionesNC(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, dtpFecIni.Value.Date, dtpFecFin.Value.Date, txtFiltro.Text.Trim(), "PR", "%", "%", "CR", "%", "");
                    bsBase.ResetBindings(false);
                }
                else if (Tipo == "ProvLiquiImp")
                {
                    bsBase.DataSource = oListaProvisiones = AgenteCtas.Proxy.ProvisionesPorEstado(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, dtpFecIni.Value.Date, dtpFecFin.Value.Date, "PR");
                    bsBase.ResetBindings(false);

                    if (!String.IsNullOrEmpty(txtFiltro.Text.Trim()))
                    {
                        BuscarFiltro();
                    }
                }
                else 
                {
                    bsBase.DataSource = oListaProvisiones = AgenteCtas.Proxy.ListarProvisiones(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, dtpFecIni.Value.Date, dtpFecFin.Value.Date, txtFiltro.Text.Trim(), "RE", "%", "%", "%", "%", "");
                    bsBase.ResetBindings(false);
                }

                if (!String.IsNullOrEmpty(txtDocumento.Text.Trim()))
                {
                    BuscarFiltro();
                }

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (oListaProvisiones != null && oListaProvisiones.Count > 0)
            {
                oProvision = (ProvisionesE)bsBase.Current;
                base.Aceptar(); 
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarProvisiones_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
        }

        private void dgvProvisiones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    EstiloCabeceras(dgvProvisiones, e, Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvProvisiones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Aceptar();
            }
        }

        private void dgvProvisiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (oListaProvisiones != null && oListaProvisiones.Count > Variables.Cero && (Tipo == "Rever" || Tipo == "PorRecibir" || Tipo == "ProvLiquiImp"))
            {
                BuscarFiltro();
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (oListaProvisiones != null && oListaProvisiones.Count > Variables.Cero)
            {
                BuscarFiltro();
            }
        }

        #endregion

    }
}
