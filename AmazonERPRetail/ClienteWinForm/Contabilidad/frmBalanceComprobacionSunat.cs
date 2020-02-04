using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Presentadora.AgenteServicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmBalanceComprobacionSunat : FrmMantenimientoBase
    {
        public frmBalanceComprobacionSunat()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LlenarCombos();
        }

        public frmBalanceComprobacionSunat(BalanceComprobacionSunatE BalanceCompSunat_)
            :this()
        {
            oBalanceCompSunat = BalanceCompSunat_;
        }


        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        BalanceComprobacionSunatE oBalanceCompSunat = null;
        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {

            ////FlagGrabado////
            cboEstado.DataSource = Global.CargarPeriodo();
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "Nombre";
        }

        void GuardarDatos()
        {
            oBalanceCompSunat.SaldoInicialDebe = Convert.ToDecimal(txtSAldoIniDebe.Text);
            oBalanceCompSunat.SaldoInicialHaber = Convert.ToDecimal(txtSaldoIniHaber.Text);
            oBalanceCompSunat.MovimientoDebe = Convert.ToDecimal(txtMovimientoDebe.Text);
            oBalanceCompSunat.MovimientoHaber = Convert.ToDecimal(txtMovimientoHaber.Text);
            oBalanceCompSunat.SumasMayorDebe = Convert.ToDecimal(txtSumasDebe.Text);
            oBalanceCompSunat.SumasMayorHaber = Convert.ToDecimal(txtSumasHaber.Text);
            oBalanceCompSunat.SaldoDebe = Convert.ToDecimal(txtSaldoDebe.Text);
            oBalanceCompSunat.SaldoHaber = Convert.ToDecimal(txtSaldoHaber.Text);
            oBalanceCompSunat.TransCancDebe = Convert.ToDecimal(txtTransDebe.Text);
            oBalanceCompSunat.TransCancHaber = Convert.ToDecimal(txtTransHaber.Text);
            oBalanceCompSunat.Adiciones = Convert.ToDecimal(txtadi.Text);
            oBalanceCompSunat.Deducciones = Convert.ToDecimal(txtDedu.Text);
            oBalanceCompSunat.RPNaturalezaGanancia = Convert.ToDecimal(txtRpGanan.Text);
            oBalanceCompSunat.RPNaturalezaPerdida = Convert.ToDecimal(txtRpPerdida.Text);
            oBalanceCompSunat.BalanceActivo = Convert.ToDecimal(txtBalanceActivo.Text);
            oBalanceCompSunat.BalancePasivo = Convert.ToDecimal(txtBalancePasivo.Text);
            oBalanceCompSunat.Estado = Convert.ToString(cboEstado.SelectedValue);
        }



        #endregion 



        #region Procedimientos Heredados

        public override void Nuevo()
        {
            txtSAldoIniDebe.Text = Convert.ToString(oBalanceCompSunat.SaldoInicialDebe);
            txtSaldoIniHaber.Text = Convert.ToString(oBalanceCompSunat.SaldoInicialHaber);
            txtMovimientoDebe.Text = Convert.ToString(oBalanceCompSunat.MovimientoDebe);
            txtMovimientoHaber.Text = Convert.ToString(oBalanceCompSunat.MovimientoHaber);
            txtSumasDebe.Text = Convert.ToString(oBalanceCompSunat.SumasMayorDebe);
            txtSumasHaber.Text = Convert.ToString(oBalanceCompSunat.SumasMayorHaber);
            txtSaldoDebe.Text = Convert.ToString(oBalanceCompSunat.SaldoDebe);
            txtSaldoHaber.Text = Convert.ToString(oBalanceCompSunat.SaldoHaber);
            txtTransDebe.Text = Convert.ToString(oBalanceCompSunat.TransCancDebe);
            txtTransHaber.Text = Convert.ToString(oBalanceCompSunat.TransCancHaber);
            txtadi.Text = Convert.ToString(oBalanceCompSunat.Adiciones);
            txtDedu.Text = Convert.ToString(oBalanceCompSunat.Deducciones);
            txtRpGanan.Text = Convert.ToString(oBalanceCompSunat.RPNaturalezaGanancia);
            txtRpPerdida.Text = Convert.ToString(oBalanceCompSunat.RPNaturalezaPerdida);
            txtBalanceActivo.Text = Convert.ToString(oBalanceCompSunat.BalanceActivo);
            txtBalancePasivo.Text = Convert.ToString(oBalanceCompSunat.BalancePasivo);

            cboEstado.SelectedValue = oBalanceCompSunat.Estado;
            txtUsuRegistra.Text = oBalanceCompSunat.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            txtRegistro.Text = oBalanceCompSunat.FechaRegistro.ToString();
            txtUsuModifica.Text = oBalanceCompSunat.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            oBalanceCompSunat.FechaModificacion = VariablesLocales.FechaHoy;
                txtModifica.Text = oBalanceCompSunat.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
        }

        public override void Grabar()
        {
            try
            {
                if (oBalanceCompSunat != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oBalanceCompSunat = AgenteContabilidad.Proxy.ActualizarBalanceComprobacionSunat(oBalanceCompSunat);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

                base.Grabar();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Cancelar()
        {
            pnlAuditoria.Focus();
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<BalanceComprobacionSunatE>(oBalanceCompSunat);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            return base.ValidarGrabacion();
        }


        #endregion

        #region Eventos
         
        private void frmBalanceComprobacionSunat_Load(object sender, EventArgs e)
        {
            Grid = false;
            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
            Nuevo();
        }

        #endregion 

    }
}
