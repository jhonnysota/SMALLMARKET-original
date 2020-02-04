using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Infraestructura;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmDetalleSolicitudProv : frmResponseBase
    {

        #region Constructores

        public frmDetalleSolicitudProv()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmDetalleSolicitudProv(SolicitudProveedorDetE oSolicitudDetalle, String Bloqueo)
            :this()
        {
            oSolDetalle = oSolicitudDetalle;
            BloquearTodo = Bloqueo;
        } 

        #endregion

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public SolicitudProveedorDetE oSolDetalle = null;
        String BloquearTodo = "N";

        #endregion

        #region Procedimientos de Usuario

        void Calcular()
        {
            Decimal Importe = 0;
            Decimal Cantidad = 0;
            Decimal Igv = 0;
            Decimal porIgv = 0;
            Decimal Total = 0;

            Decimal.TryParse(txtCantidad.Text, out Cantidad);
            Decimal.TryParse(txtImporte.Text, out Importe);
            Decimal.TryParse(txtPorIgv.Text, out porIgv);

            Igv = (Cantidad * Importe) * (porIgv / 100);
            Total = (Cantidad * Importe) + Igv;
            txtIgv.Text = Igv.ToString("N2");
            txtTotalImporte.Text = Total.ToString("N2");

            Decimal porImpuesto = 0;
            Decimal.TryParse(txtPorImpuesto.Text, out porImpuesto);
            txtImpuesto.Text = (Total * (porImpuesto / 100)).ToString("N2");
        }

        #endregion

        #region Procedimiento Heredados

        public override void Nuevo()
        {
            try
            {
                if (oSolDetalle == null)
                {
                    oSolDetalle = new SolicitudProveedorDetE();

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioMod.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModifica.Text = VariablesLocales.FechaHoy.ToString();

                    oSolDetalle.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    chkIgv.CheckedChanged -= chkIgv_CheckedChanged;
                    txtCantidad.TextChanged -= txtCantidad_TextChanged;
                    txtImporte.TextChanged -= txtImporte_TextChanged;
                    txtPorIgv.TextChanged -= txtPorIgv_TextChanged;
                    txtPorImpuesto.TextChanged -= txtPorImpuesto_TextChanged;

                    txtIdConcepto.Text = oSolDetalle.idConcepto.ToString();
                    txtCodConcepto.Text = oSolDetalle.codConcepto;
                    txtDesConcepto.Text = oSolDetalle.desConcepto;
                    txtCantidad.Text = oSolDetalle.Cantidad.ToString("N2");
                    txtImporte.Text = (oSolDetalle.Importe - oSolDetalle.Igv).ToString("N2");
                    chkIgv.Checked = oSolDetalle.indIgv;
                    txtPorIgv.Text = oSolDetalle.porIgv.ToString("N2");
                    txtIgv.Text = oSolDetalle.Igv.ToString("N2");
                    txtTotalImporte.Text = oSolDetalle.Importe.ToString("N2");
                    chkDetraccion.Checked = oSolDetalle.indDetraccion;
                    chkRetencion.Checked = oSolDetalle.indRetencion;
                    txtPorImpuesto.Text = oSolDetalle.Tasa.ToString("N2");
                    txtImpuesto.Text = oSolDetalle.impImpuesto.ToString("N2");

                    txtUsuarioRegistro.Text = oSolDetalle.UsuarioRegistro;
                    txtFechaRegistro.Text = oSolDetalle.FechaRegistro.ToString();
                    txtUsuarioMod.Text = oSolDetalle.UsuarioModificacion;
                    txtFechaModifica.Text = oSolDetalle.FechaModificacion.ToString();

                    chkIgv.CheckedChanged += chkIgv_CheckedChanged;
                    txtCantidad.TextChanged += txtCantidad_TextChanged;
                    txtImporte.TextChanged += txtImporte_TextChanged;
                    txtPorIgv.TextChanged += txtPorIgv_TextChanged;
                    txtPorImpuesto.TextChanged += txtPorImpuesto_TextChanged;

                    if (oSolDetalle.Opcion == 0)
                    {
                        oSolDetalle.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                    }

                    if (BloquearTodo == "S")
                    {
                        pnlBase.Enabled = false;
                        pnlMontos.Enabled = false;
                        btAceptar.Enabled = false;
                    }
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Aceptar()
        {
            try
            {
                if (ValidarGrabacion())
                {
                    if (oSolDetalle != null)
                    {
                        oSolDetalle.idConcepto = Convert.ToInt32(txtIdConcepto.Text);
                        oSolDetalle.codConcepto = txtCodConcepto.Text;
                        oSolDetalle.desConcepto = txtDesConcepto.Text;
                        oSolDetalle.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                        oSolDetalle.indIgv = chkIgv.Checked;
                        oSolDetalle.porIgv = Convert.ToDecimal(txtPorIgv.Text);
                        oSolDetalle.Igv = Convert.ToDecimal(txtIgv.Text);
                        oSolDetalle.Importe = Convert.ToDecimal(txtTotalImporte.Text);
                        oSolDetalle.indDetraccion = chkDetraccion.Checked;
                        oSolDetalle.indRetencion = chkRetencion.Checked;
                        oSolDetalle.Tasa = Convert.ToDecimal(txtPorImpuesto.Text);
                        oSolDetalle.impImpuesto = Convert.ToDecimal(txtImpuesto.Text);

                        if (oSolDetalle.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                        {
                            oSolDetalle.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                            oSolDetalle.FechaRegistro = VariablesLocales.FechaHoy;
                            oSolDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oSolDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                        }
                        else
                        {
                            oSolDetalle.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                            oSolDetalle.FechaModificacion = VariablesLocales.FechaHoy;
                        }

                        base.Aceptar(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (String.IsNullOrWhiteSpace(txtIdConcepto.Text.Trim()))
            {
                Global.MensajeFault("Debe ingresar un concepto.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmDetalleSolicitudProv_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btConceptos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarConceptosTesoreria oFrm = new frmBuscarConceptosTesoreria(0);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oConcepto != null)
                {
                    txtIdConcepto.Text = oFrm.oConcepto.idConcepto.ToString();
                    txtCodConcepto.Text = oFrm.oConcepto.codConcepto;
                    txtDesConcepto.Text = oFrm.oConcepto.Descripcion;

                    if (oFrm.oConcepto.porImpuesto != 0)
                    {
                        chkDetraccion.Checked = oFrm.oConcepto.indDetraccion;
                        chkRetencion.Checked = oFrm.oConcepto.indRetencion;
                        txtPorImpuesto.Text = oFrm.oConcepto.porImpuesto.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIgv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIgv.Checked)
                {
                    decimal Porcentaje = VariablesLocales.oListaImpuestos[0].Porcentaje;
                    txtPorIgv.Text = Porcentaje.ToString();
                }
                else
                {
                    txtPorIgv.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPorIgv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPorImpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            txtCantidad.Text = Global.FormatoDecimal(txtCantidad.Text);
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = Global.FormatoDecimal(txtImporte.Text);
        } 

        #endregion

    }
}
