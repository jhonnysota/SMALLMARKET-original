using ClienteWinForm.Busquedas;
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
    public partial class frmAsignarCuentas : FrmMantenimientoBase
    {
        public frmAsignarCuentas()
        {
            InitializeComponent();
        }


        public frmAsignarCuentas(PlanCuentasE ocomprasvariasNew)
            :this()
        {
            oPlandecuentas = ocomprasvariasNew;
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }

        PlanCuentasE oPlandecuentas = null;
        Int32 opcion;
        String RazonSocial = String.Empty;
        String Anio = String.Empty;
        String Mes = String.Empty;

        #endregion


        #region Procedimientos de Usuario

        void EsNuevoRegistro()
        {

            txtIdCuentaSunat.Text = oPlandecuentas.codCuentaSunat;
            txtDesCuentaSunat.Text = oPlandecuentas.nomCuentaSunat;


             opcion = (Int32)EnumOpcionGrabar.Actualizar;

        }

        void GuardarDatos()
        {
            oPlandecuentas.codCuentaSunat = txtIdCuentaSunat.Text;
            oPlandecuentas.nomCuentaSunat = txtDesCuentaSunat.Text;
            oPlandecuentas.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
        }


        public override void Nuevo()
        {
            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oPlandecuentas != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Actualizar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oPlandecuentas = AgenteContabilidad.Proxy.ActualizarPlandeCuentasSunat(oPlandecuentas);
                            Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                        }
                    }
                }

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
            base.Cancelar();
        }

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<PlanCuentasE>(oPlandecuentas);

            return base.ValidarGrabacion();
        }

        #endregion

        private void btProveedor_Click(object sender, EventArgs e)
        {
            frmBuscarCuentasSunat oFrm = new frmBuscarCuentasSunat();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPlancuentasSunatEN != null)
            {
                txtIdCuentaSunat.Text = Convert.ToString(oFrm.oPlancuentasSunatEN.codCuentaSunat);
                txtDesCuentaSunat.Text = oFrm.oPlancuentasSunatEN.Descripcion;
            }
        }

        private void frmAsignarCuentas_Load(object sender, EventArgs e)
        {
            EsNuevoRegistro();

            BloquearOpcion(EnumOpcionMenuBarra.Grabar, true);
        }

        private void txtDesCuentaSunat_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtIdCuentaSunat.Text.Trim()) || String.IsNullOrEmpty(txtDesCuentaSunat.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtDesCuentaSunat.Text.Trim()))
                    {
                        List<PlanCuentasSunatE> oListaPersonas = AgenteContabilidad.Proxy.BuscarPlanCuentasSunat("", txtDesCuentaSunat.Text.Trim());

                        List<PlanCuentasSunatE> itemp = new List<PlanCuentasSunatE>();

                        foreach (PlanCuentasSunatE item in oListaPersonas)
                        {

                            if (item.Descripcion == txtDesCuentaSunat.Text.Trim())
                            {
                                itemp.Add(item);
                            }

                        }

                        if (itemp.Count > Variables.Cero)
                        {
                            frmBuscarCuentasSunat oFrm = new frmBuscarCuentasSunat(itemp);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPlancuentasSunatEN != null)
                            {
                                txtIdCuentaSunat.Text = Convert.ToString(oFrm.oPlancuentasSunatEN.codCuentaSunat);
                                txtDesCuentaSunat.Text = oFrm.oPlancuentasSunatEN.Descripcion;
                            }
                        }
                        else
                        {
                            if (oListaPersonas.Count > Variables.Cero)
                            {
                                Global.MensajeComunicacion("Existe Más de un Registro");
                                frmBuscarCuentasSunat oFrm = new frmBuscarCuentasSunat(txtIdCuentaSunat.Text.Trim());

                                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPlancuentasSunatEN != null)
                                {
                                    txtIdCuentaSunat.Text = Convert.ToString(oFrm.oPlancuentasSunatEN.codCuentaSunat);
                                    txtDesCuentaSunat.Text = oFrm.oPlancuentasSunatEN.Descripcion;
                                }

                            }
                            else
                            {
                                Global.MensajeComunicacion("No Existe un registro con esos Datos");
                                txtIdCuentaSunat.Text = string.Empty;
                                txtDesCuentaSunat.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        txtIdCuentaSunat.Text = string.Empty;
                        txtDesCuentaSunat.Text = string.Empty;
                    }
                }

                
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaSunat_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDesCuentaSunat.Text.Trim()))
            {
                txtIdCuentaSunat.Text = String.Empty;
            }
        }

        private void txtIdCuentaSunat_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdCuentaSunat.Text.Trim()))
            {
                txtDesCuentaSunat.Text = String.Empty;
            }
        }

        private void txtIdCuentaSunat_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtIdCuentaSunat.Text.Trim()) || String.IsNullOrEmpty(txtDesCuentaSunat.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtIdCuentaSunat.Text.Trim()))
                    {
                        List<PlanCuentasSunatE> oListaPersonas = AgenteContabilidad.Proxy.BuscarPlanCuentasSunat(txtIdCuentaSunat.Text.Trim(), "");

                        List<PlanCuentasSunatE> itemp = new List<PlanCuentasSunatE>();

                        foreach (PlanCuentasSunatE item in oListaPersonas)
                        {

                            if (item.codCuentaSunat == txtIdCuentaSunat.Text.Trim())
                            {
                                itemp.Add(item);
                            }
                       
                        }

                        if (itemp.Count > Variables.Cero)
                        {
                            frmBuscarCuentasSunat oFrm = new frmBuscarCuentasSunat(itemp);

                            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPlancuentasSunatEN != null)
                            {
                                txtIdCuentaSunat.Text = Convert.ToString(oFrm.oPlancuentasSunatEN.codCuentaSunat);
                                txtDesCuentaSunat.Text = oFrm.oPlancuentasSunatEN.Descripcion;
                            }
                        }
                        else
                        {
                            if (oListaPersonas.Count > Variables.Cero)
                            {
                                Global.MensajeComunicacion("Existe Más de un Registro");
                                frmBuscarCuentasSunat oFrm = new frmBuscarCuentasSunat(txtIdCuentaSunat.Text.Trim());

                                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPlancuentasSunatEN != null)
                                {
                                    txtIdCuentaSunat.Text = Convert.ToString(oFrm.oPlancuentasSunatEN.codCuentaSunat);
                                    txtDesCuentaSunat.Text = oFrm.oPlancuentasSunatEN.Descripcion;
                                }

                            }
                            else
                            {
                                Global.MensajeComunicacion("No Existe un registro con esos Datos");
                                txtIdCuentaSunat.Text = string.Empty;
                                txtDesCuentaSunat.Text = string.Empty;
                            }                   
                        }



                        }
                    else
                    {
                        txtIdCuentaSunat.Text = string.Empty;
                        txtDesCuentaSunat.Text = string.Empty;
                    }

                    }                
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }
    }
}
