using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmParametros : FrmMantenimientoBase
    {

        public frmParametros()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            oParametros = AgenteContabilidad.Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        ParametrosContaE oParametros = null;
        Int32 Opcion = 0;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            // Diarios
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes)
            {
                new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Seleccione }
            };

            ComboHelper.RellenarCombos<ComprobantesE>(cboDiaCierre, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioLetra, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioRendicion, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioLiqui, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro2, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboDiarioLiqImp, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            //Ingresos y Egresos
            ComboHelper.RellenarCombos<ComprobantesE>(cboIngresos, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
            ComboHelper.RellenarCombos<ComprobantesE>(cboEgresos, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            Text = "Parámetros de Contabilidad (" + VariablesLocales.SesionUsuario.Empresa.RazonSocial.ToUpper() + ")";

            if (oParametros == null)
            {
                oParametros = new ParametrosContaE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                    desAnulado = string.Empty
                };

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (int)EnumOpcionGrabar.Insertar;
            }
            else
            {
                cboDiaCierre.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioCierre) ? "0" : oParametros.DiarioCierre.ToString();
                cboDiaCierre_SelectionChangeCommitted(new object(), new EventArgs());
                cboFileRes.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileCierreResultado) ? "0" : oParametros.FileCierreResultado;
                cboFileBalan.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileCierreBalance) ? "0" : oParametros.FileCierreBalance;

                cboDiarioLetra.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioLetra) ? "0" : oParametros.DiarioLetra.ToString();
                cboDiarioLetra_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFileLetra.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileLetra) ? "0" : oParametros.FileLetra.ToString();

                cboDiarioRendicion.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioRendicion) ? "0" : oParametros.DiarioRendicion.ToString();
                cboDiarioRendicion_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFileRendicion.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileRendicion) ? "0" : oParametros.FileRendicion.ToString();

                cboDiarioLiqui.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioLiquiOtros) ? "0" : oParametros.DiarioLiquiOtros.ToString();
                cboDiarioLiqui_SelectionChangeCommitted(new Object(), new EventArgs());
                cboFileLiqui.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileLiquiOtros) ? "0" : oParametros.FileLiquiOtros.ToString();

                cboLibro2.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioHonorario) ? "0" : oParametros.DiarioHonorario.ToString();
                cboLibro2_SelectionChangeCommitted(new object(), new EventArgs());
                cboFile2.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileHonorario) ? "0" : oParametros.FileHonorario.ToString();

                cboDiarioLiqImp.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioLiqui) ? "0" : oParametros.DiarioLiqui.ToString();
                cboDiarioLiqImp_SelectionChangeCommitted(new object(), new EventArgs());
                cboFileLiquiImp.SelectedValue = String.IsNullOrWhiteSpace(oParametros.FileLiqui) ? "0" : oParametros.FileLiqui.ToString();

                //Ingresos y Egresos
                cboIngresos.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioIngresos) ? "0" : oParametros.DiarioIngresos.ToString();
                cboEgresos.SelectedValue = String.IsNullOrWhiteSpace(oParametros.DiarioEgresos) ? "0" : oParametros.DiarioEgresos.ToString();

                txtUsuRegistro.Text = oParametros.UsuarioRegistro;
                txtFechaRegistro.Text = oParametros.FechaRegistro.ToString();
                txtUsuModificacion.Text = oParametros.UsuarioModificacion;
                txtFechaModificacion.Text = oParametros.FechaModificacion.ToString();

                Opcion = (int)EnumOpcionGrabar.Actualizar;
            }

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                oParametros.DiarioLetra = cboDiarioLetra.SelectedValue.ToString();
                oParametros.FileLetra = cboFileLetra.SelectedValue != null ? cboFileLetra.SelectedValue.ToString() : String.Empty;
                oParametros.DiarioCierre = cboDiaCierre.SelectedValue.ToString();
                oParametros.FileCierreResultado = cboFileRes.SelectedValue.ToString();
                oParametros.FileCierreBalance = cboFileBalan.SelectedValue.ToString();
                oParametros.DiarioRendicion = cboDiarioRendicion.SelectedValue.ToString();
                oParametros.FileRendicion = cboFileRendicion.SelectedValue != null ? cboFileRendicion.SelectedValue.ToString() : String.Empty;
                oParametros.DiarioLiquiOtros = cboDiarioLiqui.SelectedValue.ToString();
                oParametros.FileLiquiOtros = cboFileLiqui.SelectedValue != null ? cboFileLiqui.SelectedValue.ToString() : String.Empty;
                oParametros.DiarioHonorario = cboLibro2.SelectedValue.ToString();
                oParametros.FileHonorario = cboFile2.SelectedValue.ToString();
                oParametros.DiarioLiqui = cboDiarioLiqImp.SelectedValue.ToString();
                oParametros.FileLiqui = cboFileLiquiImp.SelectedValue.ToString();
                oParametros.DiarioIngresos = cboIngresos.SelectedValue.ToString();
                oParametros.DiarioEgresos = cboEgresos.SelectedValue.ToString();

                if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    oParametros.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
                    oParametros = AgenteContabilidad.Proxy.InsertarParametrosConta(oParametros);

                    Global.MensajeComunicacion(Mensajes.AvisoGrabacion);
                }
                else
                {
                    oParametros.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
                    oParametros = AgenteContabilidad.Proxy.ActualizarParametrosConta(oParametros);

                    Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
                }

                VariablesLocales.oConParametros = oParametros;
                Dispose();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmParametros_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombos();
                Nuevo();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDiarioLetra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<ComprobantesFileE> ListaFilesLetra = new List<ComprobantesFileE>(((ComprobantesE)cboDiarioLetra.SelectedItem).ListaComprobantesFiles)
                {
                    new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Seleccione }
                };

                ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileLetra, (from x in ListaFilesLetra orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                if (cboDiarioLetra.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    cboFileLetra.Enabled = false;
                }
                else
                {
                    cboFileLetra.Enabled = true;
                }

                if (ListaFilesLetra.Count == 2)
                {
                    cboFileLetra.SelectedValue = ListaFilesLetra[0].numFile;
                }
                else
                {
                    cboFileLetra.SelectedValue = Variables.Cero.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDiaCierre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboDiaCierre.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles2 = new List<ComprobantesFileE>(((ComprobantesE)cboDiaCierre.SelectedItem).ListaComprobantesFiles)
                    {
                        new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                    };

                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileRes, (from x in ListaFiles2 orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboDiaCierre.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFileRes.Enabled = false;
                    }
                    else
                    {
                        cboFileRes.Enabled = true;
                    }

                    if (ListaFiles2.Count == 2)
                    {
                        cboFileRes.SelectedValue = ListaFiles2[0].numFile;
                    }
                    else
                    {
                        cboFileRes.SelectedValue = Variables.Cero.ToString();
                    }

                    List<ComprobantesFileE> ListaFiles3 = new List<ComprobantesFileE>(((ComprobantesE)cboDiaCierre.SelectedItem).ListaComprobantesFiles)
                    {
                        new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                    };

                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileBalan, (from x in ListaFiles3 orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                    if (cboDiaCierre.SelectedValue.ToString() == Variables.Cero.ToString())
                    {
                        cboFileBalan.Enabled = false;
                    }
                    else
                    {
                        cboFileBalan.Enabled = true;
                    }

                    if (ListaFiles3.Count == 2)
                    {
                        cboFileBalan.SelectedValue = ListaFiles3[0].numFile;
                    }
                    else
                    {
                        cboFileBalan.SelectedValue = Variables.Cero.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDiarioRendicion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<ComprobantesFileE> ListaFilesRendicion = new List<ComprobantesFileE>(((ComprobantesE)cboDiarioRendicion.SelectedItem).ListaComprobantesFiles)
                {
                    new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Seleccione }
                };

                ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileRendicion, (from x in ListaFilesRendicion orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                if (cboDiarioRendicion.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    cboFileRendicion.Enabled = false;
                }
                else
                {
                    cboFileRendicion.Enabled = true;
                }

                if (ListaFilesRendicion.Count == 2)
                {
                    cboFileRendicion.SelectedValue = ListaFilesRendicion[0].numFile;
                }
                else
                {
                    cboFileRendicion.SelectedValue = Variables.Cero.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboDiarioLiqui_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                List<ComprobantesFileE> ListaFilesLiqui = new List<ComprobantesFileE>(((ComprobantesE)cboDiarioLiqui.SelectedItem).ListaComprobantesFiles)
                {
                    new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Seleccione }
                };

                ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileLiqui, (from x in ListaFilesLiqui orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                if (cboDiarioLiqui.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    cboFileLiqui.Enabled = false;
                }
                else
                {
                    cboFileLiqui.Enabled = true;
                }

                if (ListaFilesLiqui.Count == 2)
                {
                    cboFileLiqui.SelectedValue = ListaFilesLiqui[0].numFile;
                }
                else
                {
                    cboFileLiqui.SelectedValue = Variables.Cero.ToString();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLibro2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboLibro2.SelectedValue != null)
            {
                List<ComprobantesFileE> ListaFiles2 = new List<ComprobantesFileE>(((ComprobantesE)cboLibro2.SelectedItem).ListaComprobantesFiles)
                {
                    new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                };

                ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile2, (from x in ListaFiles2 orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                if (cboLibro2.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    cboFile2.Enabled = false;
                }
                else
                {
                    cboFile2.Enabled = true;
                }

                if (ListaFiles2.Count == 2)
                {
                    cboFile2.SelectedValue = ListaFiles2[0].numFile;
                }
                else
                {
                    cboFile2.SelectedValue = Variables.Cero.ToString();
                }
            }
        }

        private void cboDiarioLiqImp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboDiarioLiqImp.SelectedValue != null)
            {
                List<ComprobantesFileE> ListaFiles2 = new List<ComprobantesFileE>(((ComprobantesE)cboDiarioLiqImp.SelectedItem).ListaComprobantesFiles)
                {
                    new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos }
                };

                ComboHelper.RellenarCombos<ComprobantesFileE>(cboFileLiquiImp, (from x in ListaFiles2 orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                if (cboDiarioLiqImp.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    cboFileLiquiImp.Enabled = false;
                }
                else
                {
                    cboFileLiquiImp.Enabled = true;
                }

                if (ListaFiles2.Count == 2)
                {
                    cboFileLiquiImp.Enabled = false;
                    cboFileLiquiImp.SelectedValue = ListaFiles2[0].numFile;
                }
                else
                {
                    cboFileLiquiImp.SelectedValue = Variables.Cero.ToString();
                }
            }
        }

        #endregion

    }
}
