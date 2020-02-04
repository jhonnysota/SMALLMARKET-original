using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCambioPeriodo : FrmMantenimientoBase
    {
        public frmCambioPeriodo()
        {
            InitializeComponent();
            LlenarCombos();
        }

        #region Variables

        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        string AnioContable = VariablesLocales.FechaHoy.ToString("yyyy");

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            
            Int32 AnioFin = 0;
            Int32 AnioInicio = 0;
            
            //Cargando Meses Contables
            cboMeses.DataSource = FechasHelper.CargarMesesContable("PM");
            cboMeses.ValueMember = "MesId";
            cboMeses.DisplayMember = "MesDes";

            //Cargando Años
            AnioFin = Convert.ToInt32(AnioContable);
            AnioInicio = AnioFin - 10;
            cboAnios.DataSource = FechasHelper.CargarAnios(AnioInicio, AnioFin + 2);
            cboAnios.ValueMember = "AnioId";
            cboAnios.DisplayMember = "AnioDes";

            List<LocalE> listaLocales = AgenteMaestros.Proxy.ListarLocalPorEmpresa(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, true, false);

            if (listaLocales.Count != 0)
            {
                ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "IdLocal", "Nombre", false);    
            }
            else
            {
                Global.MensajeFault("No se han creado Sucursales...");
                panel1.Enabled = false;
                btAceptar.Enabled = false;
                btnCancelar.Enabled = false;
            }            
        }

        void CrearAñoFiscal()
        {
            if (Global.MensajeConfirmacion("Desea aperturar el año " + cboAnios.SelectedText + " con el mes inicial de " + cboMeses.SelectedText) == DialogResult.Yes)
            {
                VariablesLocales.PeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, cboAnios.SelectedValue.ToString(), cboMeses.SelectedValue.ToString());

                if (VariablesLocales.PeriodoContable != null)
                {
                    Global.MensajeComunicacion("Este año ya ha sido aperturado.");
                    return;
                }

                int AperturarAnios = AgenteContabilidad.Proxy.AperturaAnioContable(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, cboAnios.SelectedValue.ToString(), cboMeses.SelectedValue.ToString(), VariablesLocales.SesionUsuario.Credencial);

                if (AperturarAnios > 0)
                {
                    Global.MensajeComunicacion("Año " + cboAnios.SelectedValue.ToString() + " aperturado con éxito...");
                }
                else
                {
                    Global.MensajeFault("Error al aperturar el año " + cboAnios.SelectedValue.ToString());
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Cerrar()
        {
            this.Dispose();
        }

        #endregion

        #region Eventos

        private void frmCambioPeriodo_Load(object sender, EventArgs e)
        {
            txtEmpresa.Text = VariablesLocales.SesionUsuario.Empresa.NombreComercial;
            cboAnios.SelectedIndexChanged -= cboAnios_SelectedIndexChanged;
            cboAnios.SelectedValue = Convert.ToInt32(AnioContable);
            cboAnios.SelectedIndexChanged += cboAnios_SelectedIndexChanged;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                VariablesLocales.PeriodoContable = AgenteContabilidad.Proxy.ObtenerPeriodoPorMes(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, cboAnios.SelectedValue.ToString(), cboMeses.SelectedValue.ToString());

                if (VariablesLocales.PeriodoContable == null)
                {
                    Global.MensajeComunicacion("Aun no se ha aperturado el año seleccionado.");
                    btnCrearAñoFiscal.Enabled = true;
                    btnCrearAñoFiscal.Focus();
                    return;
                }

                StatusStrip control = (StatusStrip)this.MdiParent.Controls["statusStrip1"];
                control.Items["tsslUsuario"].Text = "Usuario: " + VariablesLocales.SesionUsuario.Credencial + "      Empresa: " + VariablesLocales.SesionUsuario.Empresa.NombreComercial + " - Local: " + VariablesLocales.SesionLocal.Nombre + "      Periodo: " + VariablesLocales.PeriodoContable.AnioPeriodo + " - " + VariablesLocales.PeriodoContable.MesPeriodo;

                Cerrar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void btnCrearAñoFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                CrearAñoFiscal();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

        }

        private void cboAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboMeses.SelectedValue = "13";
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion

    }
}
