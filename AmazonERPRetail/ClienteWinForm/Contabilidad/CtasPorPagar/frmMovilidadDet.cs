using System;
using System.Windows.Forms;

using Entidades.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    public partial class frmMovilidadDet : frmResponseBase
    {

        #region Constructores

        public frmMovilidadDet()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        //Editar
        public frmMovilidadDet(MovilidadDetE oMovTemp_, String Estado)
            : this()
        {
            MovilidadItem = oMovTemp_;

            if (Estado == "C")
            {
                pnlBase.Enabled = false;
                btAceptar.Enabled = false;
            }
        } 

        #endregion

        #region Variables

        public MovilidadDetE MovilidadItem = null;

        #endregion

        #region Procedimientos de Usuario

        void CalcularReparable()
        {
            if (VariablesLocales.oTesParametros != null)
            {
                Decimal MontoRmv = VariablesLocales.oTesParametros.Rmv;
                Decimal PorcentajeRmv = VariablesLocales.oTesParametros.porRmv / 100M;

                if (MontoRmv > 0 && PorcentajeRmv > 0)
                {
                    decimal MontoFinalRmv = MontoRmv * PorcentajeRmv;
                    Decimal Monto = 0;
                    Decimal.TryParse(txtMonto.Text, out Monto);

                    if (Monto > MontoFinalRmv)
                    {
                        txtGastoAceptado.Text = MontoFinalRmv.ToString("N2");
                        txtGastoReparado.Text = (Monto - MontoFinalRmv).ToString("N2");
                        chkReparable.Checked = true;
                    }
                    else
                    {
                        txtGastoAceptado.Text = "0.00";
                        txtGastoReparado.Text = "0.00";
                        chkReparable.Checked = false;
                    }
                }
                else
                {
                    txtGastoAceptado.Text = "0.00";
                    txtGastoReparado.Text = "0.00";
                    chkReparable.Checked = false;
                }
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (MovilidadItem == null)
            {
                MovilidadItem = new MovilidadDetE();

                MovilidadItem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                MovilidadItem.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                MovilidadItem.idLocal = VariablesLocales.SesionLocal.IdLocal;

                txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();
            }
            else
            {
                if (MovilidadItem.Opcion == 0)
                {
                    MovilidadItem.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                dtpFecha.Value = MovilidadItem.Fecha;
                txtCCostos.Text = MovilidadItem.idCCostos;
                txtDesCCostos.Text = MovilidadItem.desCCostos;
                txtDesplazamiento.Text = MovilidadItem.Desplazamiento;
                txtMotivo.Text = MovilidadItem.MotivoDestino;
                txtMonto.Text = MovilidadItem.Monto.ToString("N2");
                
                txtUsuarioRegistro.Text = MovilidadItem.UsuarioRegistro;
                txtFechaRegistro.Text = Convert.ToString(MovilidadItem.FechaRegistro);
                txtUsuarioModificacion.Text = MovilidadItem.UsuarioModificacion;
                txtFechaModificacion.Text = Convert.ToString(MovilidadItem.FechaModificacion);
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (MovilidadItem != null)
                {
                    MovilidadItem.Fecha = dtpFecha.Value.Date;
                    MovilidadItem.idCCostos = txtCCostos.Text.Trim();
                    MovilidadItem.Desplazamiento = Global.DejarSoloUnEspacio(txtDesplazamiento.Text.Trim());
                    MovilidadItem.MotivoDestino = txtMotivo.Text;
                    MovilidadItem.Monto = Convert.ToDecimal(txtMonto.Text);
                    MovilidadItem.indReparado = chkReparable.Checked;
                    MovilidadItem.MontoAceptado = Convert.ToDecimal(txtGastoAceptado.Text);
                    MovilidadItem.MontoReparado = Convert.ToDecimal(txtGastoReparado.Text);

                    MovilidadItem.Opcion = MovilidadItem.Opcion;

                    if (MovilidadItem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        MovilidadItem.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                        MovilidadItem.FechaRegistro = VariablesLocales.FechaHoy;
                        MovilidadItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        MovilidadItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }
                    else
                    {
                        MovilidadItem.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                        MovilidadItem.FechaModificacion = VariablesLocales.FechaHoy;
                    }

                    base.Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmMovilidadDet_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            txtMonto.Text = Global.FormatoDecimal(txtMonto.Text);
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            txtMonto.SeleccinarTodo();
        }

        private void btCentroC_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 Nivel = 1;

                if (VariablesLocales.oConParametros != null)
                {
                    if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                    {
                        Nivel = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                    }
                }

                FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto(Nivel);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
                {
                    txtCCostos.Text = oFrm.CentroCosto.idCCostos;
                    txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularReparable();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
