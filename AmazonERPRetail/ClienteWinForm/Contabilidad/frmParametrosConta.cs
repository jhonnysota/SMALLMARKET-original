using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmParametrosConta : FrmMantenimientoBase
    {

        public frmParametrosConta()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            if (VariablesLocales.oConParametros == null)
            {
                oParametros = AgenteContabilidad.Proxy.ObtenerParametrosConta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            }
            else
            {
                oParametros = VariablesLocales.oConParametros;
            }
        }

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
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

            ComboHelper.RellenarCombos(cboLibro, (from x in ListaTipoComprobante orderby x.idComprobante select x).ToList(), "idComprobante", "desComprobanteComp");

            List<ParametrosContaE> Listaparcontacombo = AgenteContabilidad.Proxy.ListarParametroContaNivel(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            ComboHelper.RellenarCombos(cboNumNivel, (from x in Listaparcontacombo orderby x.numNivel select x).ToList(), "numNivel", "numNivel");
            cboNumNivel.SelectedValue = 1;

            List<ParTabla> TipoReporte = AgenteGeneral.Proxy.ListarParTablaPorNemo("TIPREPCON");
            TipoReporte.Add(new ParTabla() { IdParTabla = 0, Nombre = Variables.Seleccione });
            ComboHelper.RellenarCombos(cboReporteConci, (from x in TipoReporte orderby x.IdParTabla select x).ToList());
        }

        List<PlanCuentasE> ListarCuentasPorCuenta(String codCuenta)
        {
            return AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, codCuenta,
                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
        }

        List<PlanCuentasE> ListarCuentasPorDesCuenta(String Descripcion)
        {
            return AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, Descripcion,
                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
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
                    desAnulado = String.Empty
                };

                txtUsuRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (int)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtGanancia.TextChanged -= txtGanancia_TextChanged;
                txtdesGanancia.TextChanged -= txtdesGanancia_TextChanged;
                txtPerdida.TextChanged -= txtPerdida_TextChanged;
                txtdesPerdida.TextChanged -= txtdesPerdida_TextChanged;
                txtCompraS.TextChanged -= txtCompraS_TextChanged;
                txtdesCompraS.TextChanged -= txtdesCompraS_TextChanged;
                txtCompraD.TextChanged -= txtCompraD_TextChanged;
                txtdesCompraD.TextChanged -= txtdesCompraD_TextChanged;
                txtVentaS.TextChanged -= txtVentaS_TextChanged;
                txtdesVentaS.TextChanged -= txtdesVentaS_TextChanged;
                txtVentaD.TextChanged -= txtVentaD_TextChanged;
                txtdesVentaD.TextChanged -= txtdesVentaD_TextChanged;
                txtCtaDetraccion.TextChanged -= txtCtaDetraccion_TextChanged;
                txtDesCtaDetraccion.TextChanged -= txtDesCtaDetraccion_TextChanged;
                txtCtaDetraccion2.TextChanged -= txtCtaDetraccion2_TextChanged;
                txtDesCtaDetraccion2.TextChanged -= txtDesCtaDetraccion2_TextChanged;
                txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
                txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
                txtCtaRenta.TextChanged -= txtCtaRenta_TextChanged;
                txtCtaDesRenta.TextChanged -= txtCtaDesRenta_TextChanged;
                txtAnticipoS.TextChanged -= txtAnticipoS_TextChanged;
                txtDesAnticipoS.TextChanged -= txtDesAnticipoS_TextChanged;
                txtAnticipoD.TextChanged -= txtAnticipoD_TextChanged;
                txtDesAnticipoD.TextChanged -= txtDesAnticipoD_TextChanged;
                txtTransferencia.TextChanged -= txtTransferencia_TextChanged;
                txtDesTransferencia.TextChanged -= txtDesTransferencia_TextChanged;
                txtIdAnulado.TextChanged -= txtIdAnulado_TextChanged;
                txtDesAnulado.TextChanged -= txtDesAnulado_TextChanged;
                txtCodCuentaLetraS.TextChanged -= txtCodCuentaLetraS_TextChanged;
                txtDesCuentaLetraS.TextChanged -= txtDesCuentaLetraS_TextChanged;
                txtCodCuentaLetraD.TextChanged -= txtCodCuentaLetraD_TextChanged;
                txtDesCuentaLetraD.TextChanged -= txtDesCuentaLetraD_TextChanged;
                txtCtaLetraRespS.TextChanged -= txtCtaLetraRespS_TextChanged;
                txtDesCtaLetraRespS.TextChanged -= txtDesCtaLetraRespS_TextChanged;
                txtCtaLetraRespD.TextChanged -= txtCtaLetraRespD_TextChanged;
                txtDesCtaLetraRespD.TextChanged -= txtDesCtaLetraRespD_TextChanged;
                txtVinculadaS.TextChanged -= txtVinculadaS_TextChanged;
                txtDesVinculadaS.TextChanged -= txtDesVinculadaS_TextChanged;
                txtVinculadaD.TextChanged -= txtVinculadaD_TextChanged;
                txtDesVinculadaD.TextChanged -= txtDesVinculadaD_TextChanged;
                txtIdVarios.TextChanged -= txtIdVarios_TextChanged;
                txtDesVarios.TextChanged -= txtDesVarios_TextChanged;
                txtCtaLiquiSol.TextChanged -= txtCtaLiquiSol_TextChanged;
                txtDesCtaLiquiSol.TextChanged -= txtDesCtaLiquiSol_TextChanged;
                txtCtaLiquiDol.TextChanged -= txtCtaLiquiDol_TextChanged;
                txtDesCtaLiquiDol.TextChanged -= txtDesCtaLiquiDol_TextChanged;

                txtGanancia.Text = oParametros.Ganancia;
                txtPerdida.Text = oParametros.Perdida;
                txtCosto.Text = oParametros.Costo;
                txtCompraS.Text = oParametros.CompraS;
                txtCompraD.Text = oParametros.CompraD;
                txtVentaS.Text = oParametros.VentaS;
                txtVentaD.Text = oParametros.VentaD;
                txtCtaSoles.Text = oParametros.HonorarioCtaSoles;
                txtCtaDolares.Text = oParametros.HonorarioCtaDolar;
                txtAnticipoS.Text = oParametros.AnticipoS;
                txtAnticipoD.Text = oParametros.AnticipoD;
                txtTransferencia.Text = oParametros.Transferencia;

                txtDesCtaSoles.Text = oParametros.desCtaHonorarioSoles;
                txtDesCtaDolares.Text = oParametros.desCtaHonorarioDolar;
                txtdesGanancia.Text = oParametros.desGanancia;
                txtdesPerdida.Text = oParametros.desPerdida;
                txtdesCompraS.Text = oParametros.desCompraS;
                txtdesCompraD.Text = oParametros.desCompraD;
                txtdesVentaS.Text = oParametros.desVentaS;
                txtdesVentaD.Text = oParametros.desVentaD;
                txtdesCosto.Text = oParametros.desCCostos;
                txtDesAnticipoS.Text = oParametros.desAnticipoS;
                txtDesAnticipoD.Text = oParametros.desAnticipoD;
                txtDesTransferencia.Text = oParametros.desTransferencia;
                txtIdAnulado.Text = oParametros.idAnulado == 0 ? String.Empty : oParametros.idAnulado.ToString();
                txtDesAnulado.Text = oParametros.desAnulado.ToString();
                txtIdVarios.Text = oParametros.idAuxiliarVarios == 0 ? String.Empty : oParametros.idAuxiliarVarios.ToString();
                txtDesVarios.Text = oParametros.desVarios.ToString();

                cboNumNivel.SelectedValue = oParametros.numNivelCCosto;
                chkDetraccion.Checked = oParametros.indDetraccion;
                chkLibro.Checked = oParametros.indDiarioDetra;
                chkMostrar.Checked = oParametros.MostrarFechaPrint;

                if (chkDetraccion.Checked)
                {
                    txtCtaDetraccion.Text = oParametros.ctaDetraccion;
                    txtDesCtaDetraccion.Text = oParametros.desCtaDetraccion;
                    txtCtaDetraccion2.Text = oParametros.ctaDetraccionDol;
                    txtDesCtaDetraccion2.Text = oParametros.desCtaDetraccionDol;

                    if (chkLibro.Checked)
                    {
                        cboLibro.SelectedValue = oParametros.DiarioDetraccion.ToString();
                        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                        cboFile.SelectedValue = oParametros.FileDetraccion.ToString();
                    }
                    else
                    {
                        cboLibro.SelectedValue = "0";
                        cboLibro_SelectionChangeCommitted(new object(), new EventArgs());
                        cboFile.SelectedValue = oParametros.FileDetraccion.ToString();
                    }
                }
                else
                {
                    txtCtaDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                    txtCtaDetraccion2.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }

                txtCtaRenta.Text = oParametros.ctaRenta;
                txtCtaDesRenta.Text = oParametros.desCtaRenta;
                txtCodCuentaLetraS.Text = oParametros.codCtaLetraS.Trim();
                txtDesCuentaLetraS.Text = oParametros.desCtaLetraS.Trim();
                txtCodCuentaLetraD.Text = oParametros.codCtaLetraD.Trim();
                txtDesCuentaLetraD.Text = oParametros.desCtaLetraD.Trim();
                txtCtaLetraRespS.Text = oParametros.codCtaLetraRespS.Trim();
                txtDesCtaLetraRespS.Text = oParametros.desCtaLetraRespS.Trim();
                txtCtaLetraRespD.Text = oParametros.codCtaLetraRespD.Trim();
                txtDesCtaLetraRespD.Text = oParametros.desCtaLetraRespD.Trim();
                cboReporteConci.SelectedValue = Convert.ToInt32(oParametros.ReporteConci);
                txtVinculadaS.Text = oParametros.ctaVinculadaSol.Trim();
                txtDesVinculadaS.Text = oParametros.desCtaVinculadaSol.Trim();
                txtVinculadaD.Text = oParametros.ctaVinculadaDol.Trim();
                txtDesVinculadaD.Text = oParametros.desCtaVinculadaDol.Trim();
                chkEliminaVoucher.Checked = oParametros.indEliminarVoucher;

                //Cuentas de liquidación de importación
                txtCtaLiquiSol.Text = oParametros.codCtaLiquiSol;
                txtDesCtaLiquiSol.Text = oParametros.desCtaLiquiSol;
                txtCtaLiquiDol.Text = oParametros.codCtaLiquiDol;
                txtDesCtaLiquiDol.Text = oParametros.desCtaLiquiDol;

                txtUsuRegistro.Text = oParametros.UsuarioRegistro;
                txtFechaRegistro.Text = oParametros.FechaRegistro.ToString();
                txtUsuModificacion.Text = oParametros.UsuarioModificacion;
                txtFechaModificacion.Text = oParametros.FechaModificacion.ToString();

                Opcion = (int)EnumOpcionGrabar.Actualizar;

                txtGanancia.TextChanged += txtGanancia_TextChanged;
                txtdesGanancia.TextChanged += txtdesGanancia_TextChanged;
                txtPerdida.TextChanged += txtPerdida_TextChanged;
                txtdesPerdida.TextChanged += txtdesPerdida_TextChanged;
                txtCompraS.TextChanged += txtCompraS_TextChanged;
                txtdesCompraS.TextChanged += txtdesCompraS_TextChanged;
                txtCompraD.TextChanged += txtCompraD_TextChanged;
                txtdesCompraD.TextChanged += txtdesCompraD_TextChanged;
                txtVentaS.TextChanged += txtVentaS_TextChanged;
                txtdesVentaS.TextChanged += txtdesVentaS_TextChanged;
                txtVentaD.TextChanged += txtVentaD_TextChanged;
                txtdesVentaD.TextChanged += txtdesVentaD_TextChanged;
                txtCtaDetraccion.TextChanged += txtCtaDetraccion_TextChanged;
                txtDesCtaDetraccion.TextChanged += txtDesCtaDetraccion_TextChanged;
                txtCtaDetraccion2.TextChanged += txtCtaDetraccion2_TextChanged;
                txtDesCtaDetraccion2.TextChanged += txtDesCtaDetraccion2_TextChanged;
                txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                txtCtaRenta.TextChanged += txtCtaRenta_TextChanged;
                txtCtaDesRenta.TextChanged += txtCtaDesRenta_TextChanged;
                txtAnticipoS.TextChanged += txtAnticipoS_TextChanged;
                txtDesAnticipoS.TextChanged += txtDesAnticipoS_TextChanged;
                txtAnticipoD.TextChanged += txtAnticipoD_TextChanged;
                txtDesAnticipoD.TextChanged += txtDesAnticipoD_TextChanged;
                txtTransferencia.TextChanged += txtTransferencia_TextChanged;
                txtDesTransferencia.TextChanged += txtDesTransferencia_TextChanged;
                txtIdAnulado.TextChanged += txtIdAnulado_TextChanged;
                txtDesAnulado.TextChanged -= txtDesAnulado_TextChanged;
                txtCodCuentaLetraS.TextChanged += txtCodCuentaLetraS_TextChanged;
                txtDesCuentaLetraS.TextChanged += txtDesCuentaLetraS_TextChanged;
                txtCodCuentaLetraD.TextChanged += txtCodCuentaLetraD_TextChanged;
                txtDesCuentaLetraD.TextChanged += txtDesCuentaLetraD_TextChanged;
                txtCtaLetraRespS.TextChanged += txtCtaLetraRespS_TextChanged;
                txtDesCtaLetraRespS.TextChanged += txtDesCtaLetraRespS_TextChanged;
                txtCtaLetraRespD.TextChanged += txtCtaLetraRespD_TextChanged;
                txtDesCtaLetraRespD.TextChanged += txtDesCtaLetraRespD_TextChanged;
                txtVinculadaS.TextChanged += txtVinculadaS_TextChanged;
                txtDesVinculadaS.TextChanged += txtDesVinculadaS_TextChanged;
                txtVinculadaD.TextChanged += txtVinculadaD_TextChanged;
                txtDesVinculadaD.TextChanged += txtDesVinculadaD_TextChanged;
                txtIdVarios.TextChanged += txtIdVarios_TextChanged;
                txtDesVarios.TextChanged += txtDesVarios_TextChanged;
                txtCtaLiquiSol.TextChanged += txtCtaLiquiSol_TextChanged;
                txtDesCtaLiquiSol.TextChanged += txtDesCtaLiquiSol_TextChanged;
                txtCtaLiquiDol.TextChanged += txtCtaLiquiDol_TextChanged;
                txtDesCtaLiquiDol.TextChanged += txtDesCtaLiquiDol_TextChanged;
            }
            
            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                oParametros.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                oParametros.Ganancia = txtGanancia.Text;
                oParametros.Perdida = txtPerdida.Text;
                oParametros.Costo = txtCosto.Text;
                oParametros.CompraS = txtCompraS.Text;
                oParametros.CompraD = txtCompraD.Text;
                oParametros.VentaS = txtVentaS.Text;
                oParametros.VentaD = txtVentaD.Text;
                oParametros.HonorarioCtaSoles = txtCtaSoles.Text;
                oParametros.HonorarioCtaDolar = txtCtaDolares.Text;
                
                oParametros.FlagClave = false;
                oParametros.indFlag104 = false;
                oParametros.indFechaVoucher = false;
                
                oParametros.numNivelCCosto = Convert.ToInt32(cboNumNivel.SelectedValue);

                oParametros.indDetraccion = chkDetraccion.Checked;
                oParametros.ctaDetraccion = txtCtaDetraccion.Text;
                oParametros.ctaDetraccionDol = txtCtaDetraccion2.Text;

                oParametros.indDiarioDetra = chkLibro.Checked;
                oParametros.DiarioDetraccion = cboLibro.SelectedValue.ToString();
                oParametros.FileDetraccion = cboFile.SelectedValue != null ? cboFile.SelectedValue.ToString() : String.Empty;
                oParametros.idAnulado = Convert.ToInt32(txtIdAnulado.Text);
                oParametros.desAnulado = txtDesAnulado.Text.Trim();
                oParametros.indCuadrar = false;
                oParametros.ctaRenta = txtCtaRenta.Text.Trim();
                oParametros.AnticipoS = txtAnticipoS.Text.Trim();
                oParametros.AnticipoD = txtAnticipoD.Text.Trim();
                oParametros.Transferencia = txtTransferencia.Text.Trim();
                oParametros.codCtaLetraS = txtCodCuentaLetraS.Text.Trim();
                oParametros.codCtaLetraD = txtCodCuentaLetraD.Text.Trim();

                Int32.TryParse(txtIdVarios.Text, out Int32 id);
                oParametros.idAuxiliarVarios = id;

                //Letras por Cobrar
                oParametros.codCtaLetraRespS = txtCtaLetraRespS.Text.Trim();
                oParametros.codCtaLetraRespD = txtCtaLetraRespD.Text.Trim();

                oParametros.MostrarFechaPrint = chkMostrar.Checked;
                oParametros.ReporteConci = Convert.ToInt32(cboReporteConci.SelectedValue) == 0 ? (Int32?)null : Convert.ToInt32(cboReporteConci.SelectedValue);
                oParametros.ctaVinculadaSol = txtVinculadaS.Text.Trim();
                oParametros.ctaVinculadaDol = txtVinculadaD.Text.Trim();
                oParametros.indEliminarVoucher = chkEliminaVoucher.Checked;

                //Cuentas de liquidación de importación
                oParametros.codCtaLiquiSol = txtCtaLiquiSol.Text.Trim();
                oParametros.codCtaLiquiDol = txtCtaLiquiDol.Text.Trim();

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

        private void frmParametrosConta_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                LlenarCombos();
                Nuevo();

                txtGanancia.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtPerdida.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCompraS.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCompraD.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtVentaS.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtVentaD.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaDetraccion.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaDetraccion2.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaSoles.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaDolares.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaRenta.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtAnticipoS.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtAnticipoD.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtTransferencia.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCodCuentaLetraS.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCodCuentaLetraD.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtVinculadaS.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtVinculadaD.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaLiquiSol.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaLiquiDol.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCuenta03_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBusquedaCentroDeCosto oFrm = new FrmBusquedaCentroDeCosto();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.CentroCosto != null)
                {
                    txtCosto.Text = oFrm.CentroCosto.idCCostos;
                    txtdesCosto.Text = oFrm.CentroCosto.desCCostos;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDetraccion.Checked)
                {
                    txtCtaDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtCtaDetraccion2.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDesCtaDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtDesCtaDetraccion2.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    chkLibro.Enabled = true;
                }
                else
                {
                    txtCtaDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtCtaDetraccion2.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesCtaDetraccion.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtDesCtaDetraccion2.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    cboLibro.SelectedValue = "0";
                    cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
                    chkLibro.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboLibro.SelectedValue != null)
            {
                List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);//AgenteContabilidad.Proxy.ObtenerFilesPorIdComprobante(VariablesLocales.SesionLocal.IdEmpresa, cboLibro.SelectedValue.ToString());
                ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                ListaFiles.Add(File);
                ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp", false);

                if (cboLibro.SelectedValue.ToString() == Variables.Cero.ToString())
                {
                    cboFile.Enabled = false;
                }
                else
                {
                    cboFile.Enabled = true;
                }

                if (ListaFiles.Count == 2)
                {
                    cboFile.SelectedValue = ListaFiles[0].numFile;
                }
                else
                {
                    cboFile.SelectedValue = Variables.Cero.ToString();
                }
            }
        }

        private void txtCtaDetraccion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDetraccion.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDetraccion.Text.Trim()))
                {
                    txtCtaDetraccion.TextChanged -= txtCtaDetraccion_TextChanged;
                    txtDesCtaDetraccion.TextChanged -= txtDesCtaDetraccion_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCtaDetraccion.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDetraccion.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDetraccion.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDetraccion.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDetraccion.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDetraccion.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDetraccion.Text = String.Empty;
                        txtDesCtaDetraccion.Text = String.Empty;
                    }

                    txtCtaDetraccion.TextChanged += txtCtaDetraccion_TextChanged;
                    txtDesCtaDetraccion.TextChanged += txtDesCtaDetraccion_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtGanancia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtGanancia.Text.Trim()) && String.IsNullOrEmpty(txtdesGanancia.Text.Trim()))
                {
                    txtGanancia.TextChanged -= txtGanancia_TextChanged;
                    txtdesGanancia.TextChanged -= txtdesGanancia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtGanancia.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtGanancia.Text = oFrm.oCuenta.codCuenta;
                            txtdesGanancia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtGanancia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtGanancia.Text = oListaCuentas[0].codCuenta;
                        txtdesGanancia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtGanancia.Text = String.Empty;
                        txtdesGanancia.Text = String.Empty;
                    }

                    txtGanancia.TextChanged += txtGanancia_TextChanged;
                    txtdesGanancia.TextChanged += txtdesGanancia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtGanancia_TextChanged(object sender, EventArgs e)
        {
            txtdesGanancia.TextChanged -= txtdesGanancia_TextChanged;
            txtdesGanancia.Text = String.Empty;
            txtdesGanancia.TextChanged += txtdesGanancia_TextChanged;
        }

        private void txtdesGanancia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtGanancia.Text.Trim()) && !String.IsNullOrEmpty(txtdesGanancia.Text.Trim()))
                {
                    txtGanancia.TextChanged -= txtGanancia_TextChanged;
                    txtdesGanancia.TextChanged -= txtdesGanancia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtdesGanancia.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtGanancia.Text = oFrm.oCuenta.codCuenta;
                            txtdesGanancia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtdesGanancia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtGanancia.Text = oListaCuentas[0].codCuenta;
                        txtdesGanancia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtGanancia.Text = String.Empty;
                        txtdesGanancia.Text = String.Empty;
                    }

                    txtGanancia.TextChanged += txtGanancia_TextChanged;
                    txtdesGanancia.TextChanged += txtdesGanancia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtdesGanancia_TextChanged(object sender, EventArgs e)
        {
            txtGanancia.TextChanged -= txtGanancia_TextChanged;
            txtGanancia.Text = String.Empty;
            txtGanancia.TextChanged += txtGanancia_TextChanged;
        }

        private void txtPerdida_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtPerdida.Text.Trim()) && String.IsNullOrEmpty(txtdesPerdida.Text.Trim()))
                {
                    txtPerdida.TextChanged -= txtPerdida_TextChanged;
                    txtdesPerdida.TextChanged -= txtdesPerdida_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtPerdida.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtPerdida.Text = oFrm.oCuenta.codCuenta;
                            txtdesPerdida.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtPerdida.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtPerdida.Text = oListaCuentas[0].codCuenta;
                        txtdesPerdida.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtPerdida.Text = String.Empty;
                        txtdesPerdida.Text = String.Empty;
                    }

                    txtPerdida.TextChanged += txtPerdida_TextChanged;
                    txtdesPerdida.TextChanged += txtdesPerdida_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtPerdida_TextChanged(object sender, EventArgs e)
        {
            txtdesPerdida.TextChanged -= txtdesPerdida_TextChanged;
            txtdesPerdida.Text = String.Empty;
            txtdesPerdida.TextChanged += txtdesPerdida_TextChanged;
        }

        private void txtdesPerdida_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtPerdida.Text.Trim()) && !String.IsNullOrEmpty(txtdesPerdida.Text.Trim()))
                {
                    txtPerdida.TextChanged -= txtPerdida_TextChanged;
                    txtdesPerdida.TextChanged -= txtdesPerdida_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtdesPerdida.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtPerdida.Text = oFrm.oCuenta.codCuenta;
                            txtdesPerdida.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtdesPerdida.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtPerdida.Text = oListaCuentas[0].codCuenta;
                        txtdesPerdida.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtPerdida.Text = String.Empty;
                        txtdesPerdida.Text = String.Empty;
                    }

                    txtPerdida.TextChanged += txtPerdida_TextChanged;
                    txtdesPerdida.TextChanged += txtdesPerdida_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtdesPerdida_TextChanged(object sender, EventArgs e)
        {
            txtPerdida.TextChanged -= txtPerdida_TextChanged;
            txtPerdida.Text = String.Empty;
            txtPerdida.TextChanged += txtPerdida_TextChanged;
        }

        private void txtCompraS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCompraS.Text.Trim()) && String.IsNullOrEmpty(txtdesCompraS.Text.Trim()))
                {
                    txtCompraS.TextChanged -= txtCompraS_TextChanged;
                    txtdesCompraS.TextChanged -= txtdesCompraS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCompraS.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCompraS.Text = oFrm.oCuenta.codCuenta;
                            txtdesCompraS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCompraS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCompraS.Text = oListaCuentas[0].codCuenta;
                        txtdesCompraS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCompraS.Text = String.Empty;
                        txtdesCompraS.Text = String.Empty;
                    }

                    txtCompraS.TextChanged += txtCompraS_TextChanged;
                    txtdesCompraS.TextChanged += txtdesCompraS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCompraS_TextChanged(object sender, EventArgs e)
        {
            txtdesCompraS.TextChanged -= txtdesCompraS_TextChanged;
            txtdesCompraS.Text = String.Empty;
            txtdesCompraS.TextChanged += txtdesCompraS_TextChanged;
        }

        private void txtdesCompraS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCompraS.Text.Trim()) && !String.IsNullOrEmpty(txtdesCompraS.Text.Trim()))
                {
                    txtCompraS.TextChanged -= txtCompraS_TextChanged;
                    txtdesCompraS.TextChanged -= txtdesCompraS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtdesCompraS.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCompraS.Text = oFrm.oCuenta.codCuenta;
                            txtdesCompraS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtdesCompraS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCompraS.Text = oListaCuentas[0].codCuenta;
                        txtdesCompraS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCompraS.Text = String.Empty;
                        txtdesCompraS.Text = String.Empty;
                    }

                    txtCompraS.TextChanged += txtCompraS_TextChanged;
                    txtdesCompraS.TextChanged += txtdesCompraS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtdesCompraS_TextChanged(object sender, EventArgs e)
        {
            txtCompraS.TextChanged -= txtCompraS_TextChanged;
            txtCompraS.Text = String.Empty;
            txtCompraS.TextChanged += txtCompraS_TextChanged;
        }

        private void txtCompraD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCompraD.Text.Trim()) && String.IsNullOrEmpty(txtdesCompraD.Text.Trim()))
                {
                    txtCompraD.TextChanged -= txtCompraD_TextChanged;
                    txtdesCompraD.TextChanged -= txtdesCompraD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCompraD.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCompraD.Text = oFrm.oCuenta.codCuenta;
                            txtdesCompraD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCompraD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCompraD.Text = oListaCuentas[0].codCuenta;
                        txtdesCompraD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCompraD.Text = String.Empty;
                        txtdesCompraD.Text = String.Empty;
                    }

                    txtCompraD.TextChanged += txtCompraD_TextChanged;
                    txtdesCompraD.TextChanged += txtdesCompraD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCompraD_TextChanged(object sender, EventArgs e)
        {
            txtdesCompraD.TextChanged -= txtdesCompraD_TextChanged;
            txtdesCompraD.Text = String.Empty;
            txtdesCompraD.TextChanged += txtdesCompraD_TextChanged;
        }

        private void txtdesCompraD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCompraD.Text.Trim()) && !String.IsNullOrEmpty(txtdesCompraD.Text.Trim()))
                {
                    txtCompraD.TextChanged -= txtCompraD_TextChanged;
                    txtdesCompraD.TextChanged -= txtdesCompraD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtdesCompraD.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCompraD.Text = oFrm.oCuenta.codCuenta;
                            txtdesCompraD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtdesCompraD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCompraD.Text = oListaCuentas[0].codCuenta;
                        txtdesCompraD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCompraD.Text = String.Empty;
                        txtdesCompraD.Text = String.Empty;
                    }

                    txtCompraD.TextChanged += txtCompraD_TextChanged;
                    txtdesCompraD.TextChanged += txtdesCompraD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtdesCompraD_TextChanged(object sender, EventArgs e)
        {
            txtCompraD.TextChanged -= txtCompraD_TextChanged;
            txtCompraD.Text = String.Empty;
            txtCompraD.TextChanged += txtCompraD_TextChanged;
        }

        private void txtVentaS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtVentaS.Text.Trim()) && String.IsNullOrEmpty(txtdesVentaS.Text.Trim()))
                {
                    txtVentaS.TextChanged -= txtVentaS_TextChanged;
                    txtdesVentaS.TextChanged -= txtdesVentaS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtVentaS.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVentaS.Text = oFrm.oCuenta.codCuenta;
                            txtdesVentaS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtVentaS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVentaS.Text = oListaCuentas[0].codCuenta;
                        txtdesVentaS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtVentaS.Text = String.Empty;
                        txtdesVentaS.Text = String.Empty;
                    }

                    txtVentaS.TextChanged += txtVentaS_TextChanged;
                    txtdesVentaS.TextChanged += txtdesVentaS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtVentaS_TextChanged(object sender, EventArgs e)
        {
            txtdesVentaS.TextChanged -= txtdesVentaS_TextChanged;
            txtdesVentaS.Text = String.Empty;
            txtdesVentaS.TextChanged += txtdesVentaS_TextChanged;
        }

        private void txtdesVentaS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVentaS.Text.Trim()) && !String.IsNullOrEmpty(txtdesVentaS.Text.Trim()))
                {
                    txtVentaS.TextChanged -= txtVentaS_TextChanged;
                    txtdesVentaS.TextChanged -= txtdesVentaS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtdesVentaS.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVentaS.Text = oFrm.oCuenta.codCuenta;
                            txtdesVentaS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtdesVentaS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVentaS.Text = oListaCuentas[0].codCuenta;
                        txtdesVentaS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtVentaS.Text = String.Empty;
                        txtdesVentaS.Text = String.Empty;
                    }

                    txtVentaS.TextChanged += txtVentaS_TextChanged;
                    txtdesVentaS.TextChanged += txtdesVentaS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtdesVentaS_TextChanged(object sender, EventArgs e)
        {
            txtVentaS.TextChanged -= txtVentaS_TextChanged;
            txtVentaS.Text = String.Empty;
            txtVentaS.TextChanged += txtVentaS_TextChanged;
        }

        private void txtVentaD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtVentaD.Text.Trim()) && String.IsNullOrEmpty(txtdesVentaD.Text.Trim()))
                {
                    txtVentaD.TextChanged -= txtVentaD_TextChanged;
                    txtdesVentaD.TextChanged -= txtdesVentaD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtVentaD.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVentaD.Text = oFrm.oCuenta.codCuenta;
                            txtdesVentaD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtVentaD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVentaD.Text = oListaCuentas[0].codCuenta;
                        txtdesVentaD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtVentaD.Text = String.Empty;
                        txtdesVentaD.Text = String.Empty;
                    }

                    txtVentaD.TextChanged += txtVentaD_TextChanged;
                    txtdesVentaD.TextChanged += txtdesVentaD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtVentaD_TextChanged(object sender, EventArgs e)
        {
            txtdesVentaD.TextChanged -= txtdesVentaD_TextChanged;
            txtdesVentaD.Text = String.Empty;
            txtdesVentaD.TextChanged += txtdesVentaD_TextChanged;
        }

        private void txtdesVentaD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVentaD.Text.Trim()) && !String.IsNullOrEmpty(txtdesVentaD.Text.Trim()))
                {
                    txtVentaD.TextChanged -= txtVentaD_TextChanged;
                    txtdesVentaD.TextChanged -= txtdesVentaD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtdesVentaD.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVentaD.Text = oFrm.oCuenta.codCuenta;
                            txtdesVentaD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtdesVentaD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVentaD.Text = oListaCuentas[0].codCuenta;
                        txtdesVentaD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtVentaD.Text = String.Empty;
                        txtdesVentaD.Text = String.Empty;
                    }

                    txtVentaD.TextChanged += txtVentaD_TextChanged;
                    txtdesVentaD.TextChanged += txtdesVentaD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtdesVentaD_TextChanged(object sender, EventArgs e)
        {
            txtVentaD.TextChanged -= txtVentaD_TextChanged;
            txtVentaD.Text = String.Empty;
            txtVentaD.TextChanged += txtVentaD_TextChanged;
        }

        private void txtCtaDetraccion_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDetraccion.TextChanged -= txtDesCtaDetraccion_TextChanged;
            txtDesCtaDetraccion.Text = String.Empty;
            txtDesCtaDetraccion.TextChanged += txtDesCtaDetraccion_TextChanged;
        }

        private void txtDesCtaDetraccion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDetraccion.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDetraccion.Text.Trim()))
                {
                    txtCtaDetraccion.TextChanged -= txtCtaDetraccion_TextChanged;
                    txtDesCtaDetraccion.TextChanged -= txtDesCtaDetraccion_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesCtaDetraccion.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDetraccion.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDetraccion.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaDetraccion.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDetraccion.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDetraccion.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDetraccion.Text = String.Empty;
                        txtDesCtaDetraccion.Text = String.Empty;
                    }

                    txtCtaDetraccion.TextChanged += txtCtaDetraccion_TextChanged;
                    txtDesCtaDetraccion.TextChanged += txtDesCtaDetraccion_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDetraccion_TextChanged(object sender, EventArgs e)
        {
            txtCtaDetraccion.TextChanged -= txtCtaDetraccion_TextChanged;
            txtCtaDetraccion.Text = String.Empty;
            txtCtaDetraccion.TextChanged += txtCtaDetraccion_TextChanged;
        }

        private void txtCtaSoles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaSoles.Text.Trim()))
                {
                    txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCtaSoles.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaSoles.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaSoles.Text = String.Empty;
                        txtDesCtaSoles.Text = String.Empty;
                    }

                    txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
            txtDesCtaSoles.Text = String.Empty;
            txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
        }

        private void txtDesCtaSoles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaSoles.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaSoles.Text.Trim()))
                {
                    txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged -= txtDesCtaSoles_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesCtaSoles.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaSoles.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaSoles.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaSoles.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaSoles.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaSoles.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaSoles.Text = String.Empty;
                        txtDesCtaSoles.Text = String.Empty;
                    }

                    txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
                    txtDesCtaSoles.TextChanged += txtDesCtaSoles_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaSoles_TextChanged(object sender, EventArgs e)
        {
            txtCtaSoles.TextChanged -= txtCtaSoles_TextChanged;
            txtCtaSoles.Text = String.Empty;
            txtCtaSoles.TextChanged += txtCtaSoles_TextChanged;
        }

        private void txtCtaDolares_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDolares.Text.Trim()))
                {
                    txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCtaDolares.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDolares.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDolares.Text = String.Empty;
                        txtDesCtaDolares.Text = String.Empty;
                    }

                    txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
            txtDesCtaDolares.Text = String.Empty;
            txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
        }

        private void txtDesCtaDolares_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDolares.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDolares.Text.Trim()))
                {
                    txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged -= txtDesCtaDolares_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesCtaDolares.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDolares.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDolares.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaDolares.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDolares.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDolares.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDolares.Text = String.Empty;
                        txtDesCtaDolares.Text = String.Empty;
                    }

                    txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
                    txtDesCtaDolares.TextChanged += txtDesCtaDolares_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDolares_TextChanged(object sender, EventArgs e)
        {
            txtCtaDolares.TextChanged -= txtCtaDolares_TextChanged;
            txtCtaDolares.Text = String.Empty;
            txtCtaDolares.TextChanged += txtCtaDolares_TextChanged;
        }

        private void txtCtaRenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaRenta.Text.Trim()) && String.IsNullOrEmpty(txtCtaDesRenta.Text.Trim()))
                {
                    txtCtaRenta.TextChanged -= txtCtaRenta_TextChanged;
                    txtCtaDesRenta.TextChanged -= txtCtaDesRenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCtaRenta.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaRenta.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesRenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaRenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaRenta.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesRenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaRenta.Text = String.Empty;
                        txtCtaDesRenta.Text = String.Empty;
                    }

                    txtCtaRenta.TextChanged += txtCtaRenta_TextChanged;
                    txtCtaDesRenta.TextChanged += txtCtaDesRenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaRenta_TextChanged(object sender, EventArgs e)
        {
            txtCtaDesRenta.TextChanged -= txtCtaDesRenta_TextChanged;
            txtCtaDesRenta.Text = String.Empty;
            txtCtaDesRenta.TextChanged += txtCtaDesRenta_TextChanged;
        }

        private void txtCtaDesRenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaRenta.Text.Trim()) && !String.IsNullOrEmpty(txtCtaDesRenta.Text.Trim()))
                {
                    txtCtaRenta.TextChanged -= txtCtaRenta_TextChanged;
                    txtCtaDesRenta.TextChanged -= txtCtaDesRenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtCtaDesRenta.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaRenta.Text = oFrm.oCuenta.codCuenta;
                            txtCtaDesRenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDesRenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaRenta.Text = oListaCuentas[0].codCuenta;
                        txtCtaDesRenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaRenta.Text = String.Empty;
                        txtCtaDesRenta.Text = String.Empty;
                    }

                    txtCtaRenta.TextChanged += txtCtaRenta_TextChanged;
                    txtCtaDesRenta.TextChanged += txtCtaDesRenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDesRenta_TextChanged(object sender, EventArgs e)
        {
            txtCtaRenta.TextChanged -= txtCtaRenta_TextChanged;
            txtCtaRenta.Text = String.Empty;
            txtCtaRenta.TextChanged += txtCtaRenta_TextChanged;
        }

        private void txtAnticipoS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAnticipoS.Text.Trim()) && String.IsNullOrEmpty(txtDesAnticipoS.Text.Trim()))
                {
                    txtAnticipoS.TextChanged -= txtAnticipoS_TextChanged;
                    txtDesAnticipoS.TextChanged -= txtDesAnticipoS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtAnticipoS.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtAnticipoS.Text = oFrm.oCuenta.codCuenta;
                            txtDesAnticipoS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtAnticipoS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtAnticipoS.Text = oListaCuentas[0].codCuenta;
                        txtDesAnticipoS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtAnticipoS.Text = String.Empty;
                        txtDesAnticipoS.Text = String.Empty;
                    }

                    txtAnticipoS.TextChanged += txtAnticipoS_TextChanged;
                    txtDesAnticipoS.TextChanged += txtDesAnticipoS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtAnticipoS_TextChanged(object sender, EventArgs e)
        {
            txtDesAnticipoS.TextChanged -= txtDesAnticipoS_TextChanged; 
            txtDesAnticipoS.Text = String.Empty;
            txtDesAnticipoS.TextChanged += txtDesAnticipoS_TextChanged;
        }

        private void txtDesAnticipoS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtAnticipoS.Text.Trim()) && !String.IsNullOrEmpty(txtDesAnticipoS.Text.Trim()))
                {
                    txtAnticipoS.TextChanged -= txtAnticipoS_TextChanged;
                    txtDesAnticipoS.TextChanged -= txtDesAnticipoS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesAnticipoS.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtAnticipoS.Text = oFrm.oCuenta.codCuenta;
                            txtDesAnticipoS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesAnticipoS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtAnticipoS.Text = oListaCuentas[0].codCuenta;
                        txtDesAnticipoS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtAnticipoS.Text = String.Empty;
                        txtDesAnticipoS.Text = String.Empty;
                    }

                    txtAnticipoS.TextChanged += txtAnticipoS_TextChanged;
                    txtDesAnticipoS.TextChanged += txtDesAnticipoS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesAnticipoS_TextChanged(object sender, EventArgs e)
        {
            txtAnticipoS.TextChanged -= txtAnticipoS_TextChanged;
            txtAnticipoS.Text = String.Empty;
            txtAnticipoS.TextChanged += txtAnticipoS_TextChanged;
        }

        private void txtAnticipoD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAnticipoD.Text.Trim()) && String.IsNullOrEmpty(txtDesAnticipoD.Text.Trim()))
                {
                    txtAnticipoD.TextChanged -= txtAnticipoD_TextChanged;
                    txtDesAnticipoD.TextChanged -= txtDesAnticipoD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtAnticipoD.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtAnticipoD.Text = oFrm.oCuenta.codCuenta;
                            txtDesAnticipoD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtAnticipoD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtAnticipoD.Text = oListaCuentas[0].codCuenta;
                        txtDesAnticipoD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtAnticipoD.Text = String.Empty;
                        txtDesAnticipoD.Text = String.Empty;
                    }

                    txtAnticipoD.TextChanged += txtAnticipoD_TextChanged;
                    txtDesAnticipoD.TextChanged += txtDesAnticipoD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtAnticipoD_TextChanged(object sender, EventArgs e)
        {
            txtDesAnticipoD.TextChanged -= txtDesAnticipoD_TextChanged;
            txtDesAnticipoD.Text = String.Empty;
            txtDesAnticipoD.TextChanged += txtDesAnticipoD_TextChanged;
        }

        private void txtDesAnticipoD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtAnticipoD.Text.Trim()) && !String.IsNullOrEmpty(txtDesAnticipoD.Text.Trim()))
                {
                    txtAnticipoD.TextChanged -= txtAnticipoD_TextChanged;
                    txtDesAnticipoD.TextChanged -= txtDesAnticipoD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesAnticipoD.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtAnticipoD.Text = oFrm.oCuenta.codCuenta;
                            txtDesAnticipoD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesAnticipoD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtAnticipoD.Text = oListaCuentas[0].codCuenta;
                        txtDesAnticipoD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtAnticipoD.Text = String.Empty;
                        txtDesAnticipoD.Text = String.Empty;
                    }

                    txtAnticipoD.TextChanged += txtAnticipoD_TextChanged;
                    txtDesAnticipoD.TextChanged += txtDesAnticipoD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesAnticipoD_TextChanged(object sender, EventArgs e)
        {
            txtAnticipoD.TextChanged -= txtAnticipoD_TextChanged;
            txtAnticipoD.Text = String.Empty;
            txtAnticipoD.TextChanged += txtAnticipoD_TextChanged;
        }

        private void txtTransferencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtTransferencia.Text.Trim()) && String.IsNullOrEmpty(txtDesTransferencia.Text.Trim()))
                {
                    txtTransferencia.TextChanged -= txtTransferencia_TextChanged;
                    txtDesTransferencia.TextChanged -= txtDesTransferencia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtTransferencia.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtTransferencia.Text = oFrm.oCuenta.codCuenta;
                            txtDesTransferencia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtTransferencia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtTransferencia.Text = oListaCuentas[0].codCuenta;
                        txtDesTransferencia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtTransferencia.Text = String.Empty;
                        txtDesTransferencia.Text = String.Empty;
                    }

                    txtTransferencia.TextChanged += txtTransferencia_TextChanged;
                    txtDesTransferencia.TextChanged += txtDesTransferencia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtTransferencia_TextChanged(object sender, EventArgs e)
        {
            txtDesTransferencia.TextChanged -= txtDesTransferencia_TextChanged;
            txtDesTransferencia.Text = String.Empty;
            txtDesTransferencia.TextChanged += txtDesTransferencia_TextChanged;
        }

        private void txtDesTransferencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtTransferencia.Text.Trim()) && !String.IsNullOrEmpty(txtDesTransferencia.Text.Trim()))
                {
                    txtTransferencia.TextChanged -= txtTransferencia_TextChanged;
                    txtDesTransferencia.TextChanged -= txtDesTransferencia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesTransferencia.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtTransferencia.Text = oFrm.oCuenta.codCuenta;
                            txtDesTransferencia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesTransferencia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtTransferencia.Text = oListaCuentas[0].codCuenta;
                        txtDesTransferencia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtTransferencia.Text = String.Empty;
                        txtDesTransferencia.Text = String.Empty;
                    }

                    txtTransferencia.TextChanged += txtTransferencia_TextChanged;
                    txtDesTransferencia.TextChanged += txtDesTransferencia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesTransferencia_TextChanged(object sender, EventArgs e)
        {
            txtTransferencia.TextChanged -= txtTransferencia_TextChanged;
            txtTransferencia.Text = String.Empty;
            txtTransferencia.TextChanged += txtTransferencia_TextChanged;
        }

        private void txtIdAnulado_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAnulado.Text.Trim()) && String.IsNullOrEmpty(txtDesAnulado.Text.Trim()))
                {
                    txtIdAnulado.TextChanged -= txtIdAnulado_TextChanged;
                    txtDesAnulado.TextChanged -= txtDesAnulado_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdAnulado.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAnulado.Text = oFrm.oPersona.IdPersona.ToString();
                            txtDesAnulado.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtIdAnulado.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAnulado.Text = oListaPersonas[0].IdPersona.ToString();
                        txtDesAnulado.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El ID del Auxiliar ingresado no existe");
                        txtIdAnulado.Text = String.Empty;
                        txtDesAnulado.Text = String.Empty;
                        txtIdAnulado.Focus();
                        return;
                    }

                    txtIdAnulado.TextChanged += txtIdAnulado_TextChanged;
                    txtDesAnulado.TextChanged += txtDesAnulado_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtIdAnulado_TextChanged(object sender, EventArgs e)
        {
            txtDesAnulado.TextChanged -= txtDesAnulado_TextChanged;
            txtDesAnulado.Text = String.Empty;
            txtDesAnulado.TextChanged += txtDesAnulado_TextChanged;
        }

        private void txtDesAnulado_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtDesAnulado.Text.Trim()) && String.IsNullOrEmpty(txtIdAnulado.Text.Trim()))
                {
                    txtIdAnulado.TextChanged -= txtIdAnulado_TextChanged;
                    txtDesAnulado.TextChanged -= txtDesAnulado_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtDesAnulado.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAnulado.Text = oFrm.oPersona.IdPersona.ToString();
                            txtDesAnulado.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtDesAnulado.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAnulado.Text = oListaPersonas[0].IdPersona.ToString();
                        txtDesAnulado.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdAnulado.Text = String.Empty;
                        txtDesAnulado.Text = String.Empty;
                    }

                    txtIdAnulado.TextChanged += txtIdAnulado_TextChanged;
                    txtDesAnulado.TextChanged += txtDesAnulado_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtDesAnulado_TextChanged(object sender, EventArgs e)
        {
            txtIdAnulado.TextChanged -= txtIdAnulado_TextChanged;
            txtIdAnulado.Text = String.Empty;
            txtIdAnulado.TextChanged += txtIdAnulado_TextChanged;
        }

        private void txtCosto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCosto.Text.Trim()) && String.IsNullOrEmpty(txtdesCosto.Text.Trim()))
                {
                    CCostosE oCCosto = AgenteMaestro.Proxy.ObtenerCCostos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, txtCosto.Text.Trim());

                    if (oCCosto != null)
                    {
                        txtCosto.Text = oCCosto.idCCostos;
                        txtdesCosto.Text = oCCosto.desCCostos;
                    }
                    else
                    {
                        txtdesCosto.Text = String.Empty;
                        Global.MensajeFault("EL código ingresado no existe");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkLibro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLibro.Checked)
            {
                cboLibro.Enabled = true;
                cboFile.Enabled = true;
            }
            else
            {
                cboLibro.Enabled = false;
                cboFile.Enabled = false;
                cboLibro.SelectedValue = "0";
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());
            }
        }

        private void txtCtaDetraccion2_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDetraccion2.TextChanged -= txtDesCtaDetraccion2_TextChanged;
            txtDesCtaDetraccion2.Text = String.Empty;
            txtDesCtaDetraccion2.TextChanged += txtDesCtaDetraccion2_TextChanged;
        }

        private void txtDesCtaDetraccion2_TextChanged(object sender, EventArgs e)
        {
            txtCtaDetraccion2.TextChanged -= txtCtaDetraccion2_TextChanged;
            txtCtaDetraccion2.Text = String.Empty;
            txtCtaDetraccion2.TextChanged += txtCtaDetraccion2_TextChanged;
        }

        private void txtCtaDetraccion2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaDetraccion2.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaDetraccion2.Text.Trim()))
                {
                    txtCtaDetraccion2.TextChanged -= txtCtaDetraccion2_TextChanged;
                    txtDesCtaDetraccion2.TextChanged -= txtDesCtaDetraccion2_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDetraccion2.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDetraccion2.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDetraccion2.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaDetraccion2.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDetraccion2.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDetraccion2.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDetraccion2.Text = String.Empty;
                        txtDesCtaDetraccion2.Text = String.Empty;
                    }

                    txtCtaDetraccion2.TextChanged += txtCtaDetraccion2_TextChanged;
                    txtDesCtaDetraccion2.TextChanged += txtDesCtaDetraccion2_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDetraccion2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaDetraccion2.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaDetraccion2.Text.Trim()))
                {
                    txtCtaDetraccion2.TextChanged -= txtCtaDetraccion2_TextChanged;
                    txtDesCtaDetraccion2.TextChanged -= txtDesCtaDetraccion2_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDetraccion2.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDetraccion2.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDetraccion2.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaDetraccion2.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDetraccion2.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDetraccion2.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDetraccion2.Text = String.Empty;
                        txtDesCtaDetraccion2.Text = String.Empty;
                    }

                    txtCtaDetraccion2.TextChanged += txtCtaDetraccion2_TextChanged;
                    txtDesCtaDetraccion2.TextChanged += txtDesCtaDetraccion2_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuentaLetraS_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaLetraS.TextChanged -= txtDesCuentaLetraS_TextChanged;
            txtDesCuentaLetraS.Text = String.Empty;
            txtDesCuentaLetraS.TextChanged += txtDesCuentaLetraS_TextChanged;
        }

        private void txtDesCuentaLetraS_TextChanged(object sender, EventArgs e)
        {
            txtCodCuentaLetraS.TextChanged -= txtCodCuentaLetraS_TextChanged;
            txtCodCuentaLetraS.Text = String.Empty;
            txtCodCuentaLetraS.TextChanged += txtCodCuentaLetraS_TextChanged;
        }

        private void txtCodCuentaLetraD_TextChanged(object sender, EventArgs e)
        {
            txtDesCuentaLetraD.TextChanged -= txtDesCuentaLetraD_TextChanged;
            txtDesCuentaLetraD.Text = String.Empty;
            txtDesCuentaLetraD.TextChanged += txtDesCuentaLetraD_TextChanged;
        }

        private void txtDesCuentaLetraD_TextChanged(object sender, EventArgs e)
        {

            txtCodCuentaLetraD.TextChanged -= txtCodCuentaLetraD_TextChanged;
            txtCodCuentaLetraD.Text = String.Empty;
            txtCodCuentaLetraD.TextChanged += txtCodCuentaLetraD_TextChanged;
        }

        private void txtCodCuentaLetraS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuentaLetraS.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaLetraS.Text.Trim()))
                {
                    txtCodCuentaLetraS.TextChanged -= txtCodCuentaLetraS_TextChanged;
                    txtDesCuentaLetraS.TextChanged -= txtDesCuentaLetraS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuentaLetraS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaLetraS.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaLetraS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuentaLetraS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaLetraS.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaLetraS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuentaLetraS.Text = String.Empty;
                        txtDesCuentaLetraS.Text = String.Empty;
                    }

                    txtCodCuentaLetraS.TextChanged += txtCodCuentaLetraS_TextChanged;
                    txtDesCuentaLetraS.TextChanged += txtDesCuentaLetraS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuentaLetraS.TextChanged += txtCodCuentaLetraS_TextChanged;
                txtDesCuentaLetraS.TextChanged += txtDesCuentaLetraS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaLetraS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuentaLetraS.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaLetraS.Text.Trim()))
                {
                    txtCodCuentaLetraS.TextChanged -= txtCodCuentaLetraS_TextChanged;
                    txtDesCuentaLetraS.TextChanged -= txtDesCuentaLetraS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaLetraS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaLetraS.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaLetraS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaLetraS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaLetraS.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaLetraS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuentaLetraS.Text = String.Empty;
                        txtDesCuentaLetraS.Text = String.Empty;
                    }

                    txtCodCuentaLetraS.TextChanged += txtCodCuentaLetraS_TextChanged;
                    txtDesCuentaLetraS.TextChanged += txtDesCuentaLetraS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuentaLetraS.TextChanged += txtCodCuentaLetraS_TextChanged;
                txtDesCuentaLetraS.TextChanged += txtDesCuentaLetraS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuentaLetraD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodCuentaLetraD.Text.Trim()) && String.IsNullOrEmpty(txtDesCuentaLetraD.Text.Trim()))
                {
                    txtCodCuentaLetraD.TextChanged -= txtCodCuentaLetraD_TextChanged;
                    txtDesCuentaLetraD.TextChanged -= txtDesCuentaLetraD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuentaLetraD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaLetraD.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaLetraD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuentaLetraD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaLetraD.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaLetraD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuentaLetraD.Text = String.Empty;
                        txtDesCuentaLetraD.Text = String.Empty;
                    }

                    txtCodCuentaLetraD.TextChanged += txtCodCuentaLetraD_TextChanged;
                    txtDesCuentaLetraD.TextChanged += txtDesCuentaLetraD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuentaLetraD.TextChanged += txtCodCuentaLetraD_TextChanged;
                txtDesCuentaLetraD.TextChanged += txtDesCuentaLetraD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuentaLetraD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodCuentaLetraD.Text.Trim()) && !String.IsNullOrEmpty(txtDesCuentaLetraD.Text.Trim()))
                {
                    txtCodCuentaLetraD.TextChanged -= txtCodCuentaLetraD_TextChanged;
                    txtDesCuentaLetraD.TextChanged -= txtDesCuentaLetraD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuentaLetraD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuentaLetraD.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuentaLetraD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuentaLetraD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuentaLetraD.Text = oListaCuentas[0].codCuenta;
                        txtDesCuentaLetraD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuentaLetraD.Text = String.Empty;
                        txtDesCuentaLetraD.Text = String.Empty;
                    }

                    txtCodCuentaLetraD.TextChanged += txtCodCuentaLetraD_TextChanged;
                    txtDesCuentaLetraD.TextChanged += txtDesCuentaLetraD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCodCuentaLetraD.TextChanged += txtCodCuentaLetraD_TextChanged;
                txtDesCuentaLetraD.TextChanged += txtDesCuentaLetraD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void frmParametrosConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtDesCuentaLetraD.Validating -= txtDesCuentaLetraD_Validating;
            txtCodCuentaLetraD.Validating -= txtCodCuentaLetraD_Validating;
            txtDesCuentaLetraS.Validating -= txtDesCuentaLetraS_Validating;
            txtCodCuentaLetraS.Validating -= txtCodCuentaLetraS_Validating;
            txtDesCtaDetraccion2.Validating -= txtDesCtaDetraccion2_Validating;
            txtCtaDetraccion2.Validating -= txtCtaDetraccion2_Validating;
            txtVentaS.Validating -= txtVentaS_Validating;
            txtdesVentaS.Validating -= txtdesVentaS_Validating;
            txtVinculadaS.Validating -= txtVinculadaS_Validating;
            txtDesVinculadaS.Validating -= txtDesVinculadaS_Validating;
            txtVinculadaD.Validating -= txtVinculadaD_Validating;
            txtDesVinculadaD.Validating -= txtDesVinculadaD_Validating;
            txtCtaLiquiSol.Validating -= txtCtaLiquiSol_Validating;
            txtDesCtaLiquiSol.Validating -= txtDesCtaLiquiSol_Validating;
            txtCtaLiquiDol.Validating -= txtCtaLiquiDol_Validating;
            txtDesCtaLiquiDol.Validating -= txtDesCtaLiquiDol_Validating;
        }

        private void txtCtaLetraRespS_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaLetraRespS.TextChanged -= txtDesCtaLetraRespS_TextChanged;
            txtDesCtaLetraRespS.Text = String.Empty;
            txtDesCtaLetraRespS.TextChanged += txtDesCtaLetraRespS_TextChanged;
        }

        private void txtDesCtaLetraRespS_TextChanged(object sender, EventArgs e)
        {
            txtCtaLetraRespS.TextChanged -= txtCtaLetraRespS_TextChanged;
            txtCtaLetraRespS.Text = String.Empty;
            txtCtaLetraRespS.TextChanged += txtCtaLetraRespS_TextChanged;
        }

        private void txtCtaLetraRespS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaLetraRespS.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaLetraRespS.Text.Trim()))
                {
                    txtCtaLetraRespS.TextChanged -= txtCtaLetraRespS_TextChanged;
                    txtDesCtaLetraRespS.TextChanged -= txtDesCtaLetraRespS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaLetraRespS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLetraRespS.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLetraRespS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaLetraRespS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLetraRespS.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLetraRespS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaLetraRespS.Text = String.Empty;
                        txtDesCtaLetraRespS.Text = String.Empty;
                    }

                    txtCtaLetraRespS.TextChanged += txtCtaLetraRespS_TextChanged;
                    txtDesCtaLetraRespS.TextChanged += txtDesCtaLetraRespS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLetraRespS.TextChanged += txtCtaLetraRespS_TextChanged;
                txtDesCtaLetraRespS.TextChanged += txtDesCtaLetraRespS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaLetraRespS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaLetraRespS.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaLetraRespS.Text.Trim()))
                {
                    txtCtaLetraRespS.TextChanged -= txtCtaLetraRespS_TextChanged;
                    txtDesCtaLetraRespS.TextChanged -= txtDesCtaLetraRespS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaLetraRespS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLetraRespS.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLetraRespS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaLetraRespS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLetraRespS.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLetraRespS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaLetraRespS.Text = String.Empty;
                        txtDesCtaLetraRespS.Text = String.Empty;
                    }

                    txtCtaLetraRespS.TextChanged += txtCtaLetraRespS_TextChanged;
                    txtDesCtaLetraRespS.TextChanged += txtDesCtaLetraRespS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLetraRespS.TextChanged += txtCtaLetraRespS_TextChanged;
                txtDesCtaLetraRespS.TextChanged += txtDesCtaLetraRespS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaLetraRespD_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaLetraRespD.TextChanged -= txtDesCtaLetraRespD_TextChanged;
            txtDesCtaLetraRespD.Text = String.Empty;
            txtDesCtaLetraRespD.TextChanged += txtDesCtaLetraRespD_TextChanged;
        }

        private void txtDesCtaLetraRespD_TextChanged(object sender, EventArgs e)
        {
            txtCtaLetraRespD.TextChanged -= txtCtaLetraRespD_TextChanged;
            txtCtaLetraRespD.Text = String.Empty;
            txtCtaLetraRespD.TextChanged += txtCtaLetraRespD_TextChanged;
        }

        private void txtCtaLetraRespD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaLetraRespD.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaLetraRespD.Text.Trim()))
                {
                    txtCtaLetraRespD.TextChanged -= txtCtaLetraRespD_TextChanged;
                    txtDesCtaLetraRespD.TextChanged -= txtDesCtaLetraRespD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaLetraRespD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLetraRespD.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLetraRespD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaLetraRespD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLetraRespD.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLetraRespD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaLetraRespD.Text = String.Empty;
                        txtDesCtaLetraRespD.Text = String.Empty;
                    }

                    txtCtaLetraRespD.TextChanged += txtCtaLetraRespD_TextChanged;
                    txtDesCtaLetraRespD.TextChanged += txtDesCtaLetraRespD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLetraRespD.TextChanged += txtCtaLetraRespD_TextChanged;
                txtDesCtaLetraRespD.TextChanged += txtDesCtaLetraRespD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaLetraRespD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaLetraRespD.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaLetraRespD.Text.Trim()))
                {
                    txtCtaLetraRespD.TextChanged -= txtCtaLetraRespD_TextChanged;
                    txtDesCtaLetraRespD.TextChanged -= txtDesCtaLetraRespD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaLetraRespD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLetraRespD.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLetraRespD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaLetraRespD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLetraRespD.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLetraRespD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaLetraRespD.Text = String.Empty;
                        txtDesCtaLetraRespD.Text = String.Empty;
                    }

                    txtCtaLetraRespD.TextChanged += txtCtaLetraRespD_TextChanged;
                    txtDesCtaLetraRespD.TextChanged += txtDesCtaLetraRespD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLetraRespD.TextChanged += txtCtaLetraRespD_TextChanged;
                txtDesCtaLetraRespD.TextChanged += txtDesCtaLetraRespD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtVinculadaS_TextChanged(object sender, EventArgs e)
        {
            txtDesVinculadaS.Text = String.Empty;
        }

        private void txtVinculadaD_TextChanged(object sender, EventArgs e)
        {
            txtDesVinculadaD.Text = String.Empty;
        }

        private void txtDesVinculadaS_TextChanged(object sender, EventArgs e)
        {
            txtVinculadaS.Text = String.Empty;
        }

        private void txtDesVinculadaD_TextChanged(object sender, EventArgs e)
        {
            txtVinculadaD.Text = String.Empty;
        }

        private void txtVinculadaS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtVinculadaS.Text.Trim()) && String.IsNullOrEmpty(txtDesVinculadaS.Text.Trim()))
                {
                    txtVinculadaS.TextChanged -= txtVinculadaS_TextChanged;
                    txtDesVinculadaS.TextChanged -= txtDesVinculadaS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtVinculadaS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVinculadaS.Text = oFrm.oCuenta.codCuenta;
                            txtDesVinculadaS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtVinculadaS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVinculadaS.Text = oListaCuentas[0].codCuenta;
                        txtDesVinculadaS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtVinculadaS.Text = String.Empty;
                        txtDesVinculadaS.Text = String.Empty;
                    }

                    txtVinculadaS.TextChanged += txtVinculadaS_TextChanged;
                    txtDesVinculadaS.TextChanged += txtDesVinculadaS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtVinculadaS.TextChanged += txtVinculadaS_TextChanged;
                txtDesVinculadaS.TextChanged += txtDesVinculadaS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesVinculadaS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVinculadaS.Text.Trim()) && !String.IsNullOrEmpty(txtDesVinculadaS.Text.Trim()))
                {
                    txtVinculadaS.TextChanged -= txtVinculadaS_TextChanged;
                    txtDesVinculadaS.TextChanged -= txtDesVinculadaS_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesVinculadaS.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVinculadaS.Text = oFrm.oCuenta.codCuenta;
                            txtDesVinculadaS.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesVinculadaS.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVinculadaS.Text = oListaCuentas[0].codCuenta;
                        txtDesVinculadaS.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtVinculadaS.Text = String.Empty;
                        txtDesVinculadaS.Text = String.Empty;
                    }

                    txtVinculadaS.TextChanged += txtVinculadaS_TextChanged;
                    txtDesVinculadaS.TextChanged += txtDesVinculadaS_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtVinculadaS.TextChanged += txtVinculadaS_TextChanged;
                txtDesVinculadaS.TextChanged += txtDesVinculadaS_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtVinculadaD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtVinculadaD.Text.Trim()) && String.IsNullOrEmpty(txtDesVinculadaD.Text.Trim()))
                {
                    txtVinculadaD.TextChanged -= txtVinculadaD_TextChanged;
                    txtDesVinculadaD.TextChanged -= txtDesVinculadaD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtVinculadaD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVinculadaD.Text = oFrm.oCuenta.codCuenta;
                            txtDesVinculadaD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtVinculadaD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVinculadaD.Text = oListaCuentas[0].codCuenta;
                        txtDesVinculadaD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtVinculadaD.Text = String.Empty;
                        txtDesVinculadaD.Text = String.Empty;
                    }

                    txtVinculadaD.TextChanged += txtVinculadaD_TextChanged;
                    txtDesVinculadaD.TextChanged += txtDesVinculadaD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtVinculadaD.TextChanged += txtVinculadaD_TextChanged;
                txtDesVinculadaD.TextChanged += txtDesVinculadaD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesVinculadaD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVinculadaD.Text.Trim()) && !String.IsNullOrEmpty(txtDesVinculadaD.Text.Trim()))
                {
                    txtVinculadaD.TextChanged -= txtVinculadaD_TextChanged;
                    txtDesVinculadaD.TextChanged -= txtDesVinculadaD_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesVinculadaD.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtVinculadaD.Text = oFrm.oCuenta.codCuenta;
                            txtDesVinculadaD.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesVinculadaD.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtVinculadaD.Text = oListaCuentas[0].codCuenta;
                        txtDesVinculadaD.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtVinculadaD.Text = String.Empty;
                        txtDesVinculadaD.Text = String.Empty;
                    }

                    txtVinculadaD.TextChanged += txtVinculadaD_TextChanged;
                    txtDesVinculadaD.TextChanged += txtDesVinculadaD_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtVinculadaD.TextChanged += txtVinculadaD_TextChanged;
                txtDesVinculadaD.TextChanged += txtDesVinculadaD_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesVarios_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtDesVarios.Text.Trim()) && String.IsNullOrEmpty(txtIdVarios.Text.Trim()))
                {
                    txtIdVarios.TextChanged -= txtIdVarios_TextChanged;
                    txtDesVarios.TextChanged -= txtDesVarios_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtDesVarios.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdVarios.Text = oFrm.oPersona.IdPersona.ToString();
                            txtDesVarios.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtDesVarios.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdVarios.Text = oListaPersonas[0].IdPersona.ToString();
                        txtDesVarios.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtIdVarios.Text = String.Empty;
                        txtDesVarios.Text = String.Empty;
                    }

                    txtIdVarios.TextChanged += txtIdVarios_TextChanged;
                    txtDesVarios.TextChanged += txtDesVarios_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtDesVarios_TextChanged(object sender, EventArgs e)
        {
            txtIdVarios.Text = String.Empty;
        }

        private void txtIdVarios_TextChanged(object sender, EventArgs e)
        {
            txtDesVarios.Text = String.Empty;
        }

        private void txtIdVarios_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdVarios.Text.Trim()) && String.IsNullOrEmpty(txtDesVarios.Text.Trim()))
                {
                    txtIdVarios.TextChanged -= txtIdVarios_TextChanged;
                    txtDesVarios.TextChanged -= txtDesVarios_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "ID", txtIdVarios.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas, "Clientes");

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdVarios.Text = oFrm.oPersona.IdPersona.ToString();
                            txtDesVarios.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtIdVarios.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdVarios.Text = oListaPersonas[0].IdPersona.ToString();
                        txtDesVarios.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El ID del Auxiliar ingresado no existe");
                        txtIdVarios.Text = String.Empty;
                        txtDesVarios.Text = String.Empty;
                        txtIdVarios.Focus();
                    }

                    txtIdVarios.TextChanged += txtIdVarios_TextChanged;
                    txtDesVarios.TextChanged += txtDesVarios_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void txtCtaLiquiSol_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaLiquiSol.Text = String.Empty;
        }

        private void txtDesCtaLiquiSol_TextChanged(object sender, EventArgs e)
        {
            txtCtaLiquiSol.Text = String.Empty;
        }

        private void txtCtaLiquiDol_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaLiquiDol.Text = String.Empty;
        }

        private void txtDesCtaLiquiDol_TextChanged(object sender, EventArgs e)
        {
            txtCtaLiquiDol.Text = String.Empty;
        }

        private void txtCtaLiquiSol_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaLiquiSol.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaLiquiSol.Text.Trim()))
                {
                    txtCtaLiquiSol.TextChanged -= txtCtaLiquiSol_TextChanged;
                    txtDesCtaLiquiSol.TextChanged -= txtDesCtaLiquiSol_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCtaLiquiSol.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLiquiSol.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLiquiSol.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaLiquiSol.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLiquiSol.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLiquiSol.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaLiquiSol.Text = String.Empty;
                        txtDesCtaLiquiSol.Text = String.Empty;
                    }

                    txtCtaLiquiSol.TextChanged += txtCtaLiquiSol_TextChanged;
                    txtDesCtaLiquiSol.TextChanged += txtDesCtaLiquiSol_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLiquiSol.TextChanged += txtCtaLiquiSol_TextChanged;
                txtDesCtaLiquiSol.TextChanged += txtDesCtaLiquiSol_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaLiquiSol_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaLiquiSol.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaLiquiSol.Text.Trim()))
                {
                    txtCtaLiquiSol.TextChanged -= txtCtaLiquiSol_TextChanged;
                    txtDesCtaLiquiSol.TextChanged -= txtDesCtaLiquiSol_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesCtaLiquiSol.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLiquiSol.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLiquiSol.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaLiquiSol.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLiquiSol.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLiquiSol.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaLiquiSol.Text = String.Empty;
                        txtDesCtaLiquiSol.Text = String.Empty;
                    }

                    txtCtaLiquiSol.TextChanged += txtCtaLiquiSol_TextChanged;
                    txtDesCtaLiquiSol.TextChanged += txtDesCtaLiquiSol_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLiquiSol.TextChanged += txtCtaLiquiSol_TextChanged;
                txtDesCtaLiquiSol.TextChanged += txtDesCtaLiquiSol_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaLiquiDol_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCtaLiquiDol.Text.Trim()) && String.IsNullOrEmpty(txtDesCtaLiquiDol.Text.Trim()))
                {
                    txtCtaLiquiDol.TextChanged -= txtCtaLiquiDol_TextChanged;
                    txtDesCtaLiquiDol.TextChanged -= txtDesCtaLiquiDol_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorCuenta(txtCtaLiquiDol.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLiquiDol.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLiquiDol.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCtaLiquiDol.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLiquiDol.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLiquiDol.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaLiquiDol.Text = String.Empty;
                        txtDesCtaLiquiDol.Text = String.Empty;
                    }

                    txtCtaLiquiDol.TextChanged += txtCtaLiquiDol_TextChanged;
                    txtDesCtaLiquiDol.TextChanged += txtDesCtaLiquiDol_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLiquiDol.TextChanged += txtCtaLiquiDol_TextChanged;
                txtDesCtaLiquiDol.TextChanged += txtDesCtaLiquiDol_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaLiquiDol_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCtaLiquiDol.Text.Trim()) && !String.IsNullOrEmpty(txtDesCtaLiquiDol.Text.Trim()))
                {
                    txtCtaLiquiDol.TextChanged -= txtCtaLiquiDol_TextChanged;
                    txtDesCtaLiquiDol.TextChanged -= txtDesCtaLiquiDol_TextChanged;
                    List<PlanCuentasE> oListaCuentas = ListarCuentasPorDesCuenta(txtDesCtaLiquiDol.Text.Trim());

                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaLiquiDol.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaLiquiDol.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaLiquiDol.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaLiquiDol.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaLiquiDol.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaLiquiDol.Text = String.Empty;
                        txtDesCtaLiquiDol.Text = String.Empty;
                    }

                    txtCtaLiquiDol.TextChanged += txtCtaLiquiDol_TextChanged;
                    txtDesCtaLiquiDol.TextChanged += txtDesCtaLiquiDol_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtCtaLiquiDol.TextChanged += txtCtaLiquiDol_TextChanged;
                txtDesCtaLiquiDol.TextChanged += txtDesCtaLiquiDol_TextChanged;
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
