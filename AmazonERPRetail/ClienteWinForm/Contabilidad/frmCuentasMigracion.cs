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
using Infraestructura;
using ClienteWinForm.Busquedas;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCuentasMigracion : FrmMantenimientoBase
    {
        #region Constructores
        
        public frmCuentasMigracion()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        public frmCuentasMigracion(CuentasMigracionE CtaTemporal)
            : this()
        {
            oCuentaMigracionAnterior = CtaTemporal;
        }

        #endregion Constructores

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        CuentasMigracionE oCuentaMigracion = null;
        CuentasMigracionE oCuentaMigracionAnterior = null;
        Int32 Opcion = Variables.Cero;

        #endregion

        #region Procedimientos de Usuario

        void GuardarDatos()
        {
            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oCuentaMigracion.cuentadestino = txtCtaDestino.Text.Trim();
                oCuentaMigracion.cuentaorigen = txtCtaOrigen.Text.Trim();
                oCuentaMigracion.ccosto = txtCCostos.Text.Trim();
                oCuentaMigracion.codCuenta = txtCtaIndusoft.Text.Trim();
                oCuentaMigracion.tipo = cboTipo.SelectedIndex == 1 ? "A" : "N";
            }
            else
            {
                oCuentaMigracion = new CuentasMigracionE()
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                    tipo = cboTipo.SelectedIndex == 1 ? "A" : "N",
                    cuentadestino = txtCtaDestino.Text.Trim(),
                    cuentaorigen = txtCtaOrigen.Text.Trim(),
                    ccosto = txtCCostos.Text.Trim(),
                    codCuenta = txtCtaIndusoft.Text.Trim()
                };
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oCuentaMigracionAnterior == null)
                {
                    oCuentaMigracion = new CuentasMigracionE();

                    oCuentaMigracion.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                    oCuentaMigracion.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                    Opcion = (Int32)EnumOpcionGrabar.Insertar;
                }
                else
                {
                    txtCtaDestino.Text = oCuentaMigracionAnterior.cuentadestino;
                    txtNombreDestino.Text = oCuentaMigracionAnterior.nombredestino;
                    txtCtaOrigen.Text = oCuentaMigracionAnterior.cuentaorigen;
                    txtNombreOrigen.Text = oCuentaMigracionAnterior.nombreorigen;
                    txtCCostos.Text = oCuentaMigracionAnterior.ccosto.Trim();
                    txtCtaIndusoft.Text = oCuentaMigracionAnterior.codCuenta;
                    txtNombreCtaIndusoft.Text = oCuentaMigracionAnterior.desCuenta;

                    if (oCuentaMigracionAnterior.tipo == "A")
                    {
                        cboTipo.SelectedIndex = 1;
                    }
                    else
                    {
                        cboTipo.SelectedIndex = 0;
                    }

                    Opcion = (Int32)EnumOpcionGrabar.Actualizar;
                }

                base.Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                GuardarDatos();

                if (ValidarGrabacion())
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion("Desea guardar las cuentas ingresadas.") == DialogResult.Yes) 
                        {
                            AgenteContabilidad.Proxy.InsertarCuentasMigracion(oCuentaMigracion);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Desea actualizar los datos.") == DialogResult.Yes)
                        {
                            AgenteContabilidad.Proxy.InsertarCuentasMigracion(oCuentaMigracion, oCuentaMigracionAnterior);
                        }
                    }

                    oCuentaMigracion = null;
                    oCuentaMigracionAnterior = null;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (String.IsNullOrEmpty(txtCtaDestino.Text.Trim()))
            {
                Global.MensajeFault("Tiene que haber una cuenta de destino.");
                return false;
            }

            if (String.IsNullOrEmpty(txtCtaIndusoft.Text.Trim()))
            {
                Global.MensajeFault("Tiene que haber una cuenta por parte de Indusoft.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion Procedimientos Heredados

        #region Eventos

        private void frmCuentasMigracion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
        }

        private void btCtaDestino_Click(object sender, EventArgs e)
        {
            //frmBuscarCuentasMigraciones oFrm = new frmBuscarCuentasMigraciones();

            //if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuentaMigracion != null)
            //{
            //    cboTipo.SelectedIndex = oFrm.oCuentaMigracion.tipo == "A" ? 1 : 0;
            //    txtCtaDestino.Text = oFrm.oCuentaMigracion.cuentadestino;
            //    txtNombreDestino.Text = oFrm.oCuentaMigracion.nombredestino;
            //    txtCtaOrigen.Text = oFrm.oCuentaMigracion.cuentaorigen;
            //    txtNombreOrigen.Text = oFrm.oCuentaMigracion.nombreorigen;
            //    txtCCostos.Text = oFrm.oCuentaMigracion.ccosto;
            //}
        }

        private void btCtaOrigen_Click(object sender, EventArgs e)
        {

        }

        private void btCtaIndusoft_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    txtCtaIndusoft.Text = oFrm.Cuentas.codCuenta;
                    txtNombreCtaIndusoft.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        } 

        #endregion Eventos

    }
}
