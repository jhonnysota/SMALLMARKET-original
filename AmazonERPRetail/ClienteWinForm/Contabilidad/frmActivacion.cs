using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmActivacion : FrmMantenimientoBase
    {

        #region Constructores

        public frmActivacion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDetalle, true);
            LlenarCombos();
        }

        //Nuevo
        public frmActivacion(String idComprobante_, String numFile_)
            : this()
        {
            idComprobante = idComprobante_;
            numFile = numFile_;
        }

        //Actualización
        public frmActivacion(Int32 idActivacion, Int32 idEmpresa, String idComprobante_, String numFile_)
            : this()
        {
            oActivacion = AgenteContabilidad.Proxy.RecuperarActivacionCompleta(idActivacion, idEmpresa);
            idComprobante = idComprobante_;
            numFile = numFile_;
        } 

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        ActivacionE oActivacion = null;
        String idComprobante = String.Empty;
        String numFile = String.Empty;

        Int32 opcion;

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            /////MESINICIO////
            DataTable oDt = FechasHelper.CargarMeses(1, true, "MA");
            DataRow Fila = oDt.NewRow();
            Fila["MesId"] = "0";
            Fila["MesDes"] = Variables.Todos;
            oDt.Rows.Add(Fila);

            oDt.DefaultView.Sort = "MesId";
            cboInicio.DataSource = oDt;
            cboInicio.ValueMember = "MesId";
            cboInicio.DisplayMember = "MesDes";
            cboInicio.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            /////MESFINAL////
            DataTable oMC = FechasHelper.CargarMeses(1, true, "MA");
            DataRow File = oMC.NewRow();
            File["MesId"] = "0";
            File["MesDes"] = Variables.Todos;
            oMC.Rows.Add(File);

            oMC.DefaultView.Sort = "MesId";
            cboFin.DataSource = oMC;
            cboFin.ValueMember = "MesId";
            cboFin.DisplayMember = "MesDes";
            cboFin.SelectedValue = VariablesLocales.PeriodoContable.MesPeriodo;

            ///LIBROS///
            List<ComprobantesE> ListaTipoComprobante = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);
            ComprobantesE p = new ComprobantesE() { idComprobante = Variables.Cero.ToString(), desComprobanteComp = Variables.Todos };
            ListaTipoComprobante.Add(p);
            ComboHelper.RellenarCombos<ComprobantesE>(cboLibro, (from x in ListaTipoComprobante
                                                                 orderby x.idComprobante
                                                                 select x).ToList(), "idComprobante", "desComprobanteComp");
        }

        void GuardarDatos()
        {
            oActivacion.codActivacion = txtCodActivacion.Text;
            oActivacion.fecOperacion = dtpFecOperacion.Value.Date;
            oActivacion.fecDocumento = dtpFecDocumento.Value.Date;
            oActivacion.idCCostos = txtCCostos.Text;
            oActivacion.indTicaAuto = chkTicaAuto.Checked;
            oActivacion.tipCambio = Convert.ToDecimal(txtTipoCambio.Text);
            oActivacion.MesIni = cboInicio.SelectedValue.ToString();
            oActivacion.MesFinal = cboFin.SelectedValue.ToString();
            oActivacion.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
            oActivacion.codCuenta = txtCodCuenta.Text.Trim();
            oActivacion.idComprobante = cboLibro.SelectedValue.ToString();
            oActivacion.numFile = cboFile.SelectedValue.ToString();

            if (opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oActivacion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oActivacion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oActivacion == null)
            {
                oActivacion = new ActivacionE();
                oActivacion.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                oActivacion.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;

                cboInicio.SelectedValue = "0";
                cboFin.SelectedValue = "0";

                if (!String.IsNullOrWhiteSpace(idComprobante))
                {
                    cboLibro.SelectedValue = idComprobante;
                }
                else
                {
                    cboLibro.SelectedValue = "08";
                }
                
                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());

                if (!String.IsNullOrWhiteSpace(numFile))
                {
                    cboFile.SelectedValue = numFile;
                }
                else
                {
                    cboFile.SelectedValue = "04";
                }

                dtpFecOperacion_ValueChanged(null, null);
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtFecModifica.Text = VariablesLocales.FechaHoy.ToString();

                opcion = (Int32)EnumOpcionGrabar.Insertar;
            }
            else
            {
                txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                dtpFecOperacion.ValueChanged -= dtpFecOperacion_ValueChanged;
                dtpFecDocumento.ValueChanged -= dtpFecDocumento_ValueChanged;

                dtpFecOperacion.Value = oActivacion.fecOperacion.Date;
                txtCodActivacion.Text = oActivacion.codActivacion;
                dtpFecDocumento.Value = oActivacion.fecDocumento.Date;
                chkTicaAuto.Checked = oActivacion.indTicaAuto;
                txtTipoCambio.Text = oActivacion.tipCambio.ToString("N3");
                txtCCostos.Text = oActivacion.idCCostos;
                txtDesCCostos.Text = oActivacion.desCCostos;
                cboInicio.SelectedValue = oActivacion.MesIni;
                cboFin.SelectedValue = oActivacion.MesFinal;
                txtCodCuenta.Text = oActivacion.codCuenta;
                txtDesCuenta.Text = oActivacion.desCuenta;

                if (!String.IsNullOrWhiteSpace(oActivacion.idComprobante))
                {
                    cboLibro.SelectedValue = oActivacion.idComprobante.ToString();
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(idComprobante))
                    {
                        cboLibro.SelectedValue = idComprobante;
                    }
                    else
                    {
                        cboLibro.SelectedValue = "08";
                    }
                }

                cboLibro_SelectionChangeCommitted(new Object(), new EventArgs());

                if (!String.IsNullOrWhiteSpace(oActivacion.numFile))
                {
                    cboFile.SelectedValue = oActivacion.numFile.ToString();
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(numFile))
                    {
                        cboFile.SelectedValue = numFile;
                    }
                    else
                    {
                        cboFile.SelectedValue = "04";
                    }
                }

                txtUsuRegistra.Text = oActivacion.UsuarioRegistro;
                txtFecRegistro.Text = oActivacion.FechaRegistro.ToString();
                txtUsuModifica.Text = oActivacion.UsuarioModificacion;
                txtFecModifica.Text = oActivacion.FechaModificacion.ToString();

                opcion = (Int32)EnumOpcionGrabar.Actualizar;
                txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                dtpFecOperacion.ValueChanged += dtpFecOperacion_ValueChanged;
                dtpFecDocumento.ValueChanged += dtpFecDocumento_ValueChanged;

                Text = "Capitalización de Gasto (N° " + oActivacion.codActivacion + ")";
            }

            bsActivacionDet.DataSource = oActivacion.ListaActivacionDet;
            bsActivacionDet.ResetBindings(false);

            base.Nuevo();
        }

        public override void Grabar()
        {
            try
            {
                if (oActivacion != null)
                {
                    GuardarDatos();

                    if (!ValidarGrabacion())
                    {
                        return;
                    }

                    if (opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                        {
                            oActivacion = AgenteContabilidad.Proxy.GrabarActivacion(oActivacion, EnumOpcionGrabar.Insertar);
                            Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                        {
                            oActivacion = AgenteContabilidad.Proxy.GrabarActivacion(oActivacion, EnumOpcionGrabar.Actualizar);
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

        public override bool ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<ActivacionE>(oActivacion);

            if (String.IsNullOrWhiteSpace(txtCCostos.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar un Centro de Costo.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()) && String.IsNullOrWhiteSpace(txtDesCuenta.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar un Cuenta Contable válida.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtCodCuenta.Text.Trim()))
            {
                Global.MensajeComunicacion("Debe ingresar una cuenta contable.");
                return false;
            }
            else
            {
                PlanCuentasE oCuenta = VariablesLocales.ObtenerPlanCuenta(txtCodCuenta.Text.Trim());

                if (oCuenta.indSolicitaCentroCosto.Substring(0, 1) == "N")
                {
                    Global.MensajeComunicacion("Debe colocar una cuenta que solicite Centro de Costo.");
                    return false;
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmActivacion_Load(object sender, EventArgs e)
        {
            Grid = false;
            Nuevo();
            BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
            BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
        }

        private void btCentroC_Click(object sender, EventArgs e)
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
                txtCCostos.Text = oActivacion.idCCostos = oFrm.CentroCosto.idCCostos;
                txtDesCCostos.Text = oFrm.CentroCosto.desCCostos;
            }
        }

        private void btObternerVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                String anio = VariablesLocales.PeriodoContable.AnioPeriodo;
                int emp = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                String mesI = cboInicio.SelectedValue.ToString();
                String mesF = cboFin.SelectedValue.ToString();

                if (Convert.ToInt32(mesF) < Convert.ToInt32(mesI))
                {
                    Global.MensajeComunicacion("El mes final no puede ser menor al mes inicio.");
                    return;
                }

                List<VoucherItemE> oLista = AgenteContabilidad.Proxy.ListaVoucherItemActivacion(emp, anio, mesI, mesF);

                if (oLista.Count > 0)
                {
                    oActivacion.ListaActivacionDet = new List<ActivacionDetE>();
                    ActivacionDetE activaciondet = null;

                    foreach (VoucherItemE item in oLista)
                    {
                        activaciondet = new ActivacionDetE()
                        {
                            codCuenta = item.codCuenta,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            desCuenta = item.desCuenta,
                            MontoDebe = item.impDebe,
                            MontoHaber = item.impHaber,
                            MontoDebeDolares = item.impDebeDolares,
                            MontoHaberDolares = item.impHaberDolares,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy
                        };

                        oActivacion.ListaActivacionDet.Add(activaciondet);
                        bsActivacionDet.DataSource = oActivacion.ListaActivacionDet;
                        bsActivacionDet.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCodCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCuenta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodCuenta.Text.Trim()) && !string.IsNullOrEmpty(txtDesCuenta.Text.Trim()))
                {
                    txtCodCuenta.TextChanged -= txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged -= txtDesCuenta_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCuenta.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCodCuenta.Text = oFrm.oCuenta.codCuenta;
                            txtDesCuenta.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtCodCuenta.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCodCuenta.Text = oListaCuentas[0].codCuenta;
                        txtDesCuenta.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCodCuenta.Text = string.Empty;
                        txtDesCuenta.Text = string.Empty;
                    }

                    txtCodCuenta.TextChanged += txtCodCuenta_TextChanged;
                    txtDesCuenta.TextChanged += txtDesCuenta_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCodCuenta_TextChanged(object sender, EventArgs e)
        {
            txtDesCuenta.Text = String.Empty;
        }

        private void txtDesCuenta_TextChanged(object sender, EventArgs e)
        {
            txtCodCuenta.Text = String.Empty;
        }

        private void cboLibro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboLibro.SelectedValue != null)
                {
                    List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>(((ComprobantesE)cboLibro.SelectedItem).ListaComprobantesFiles);
                    ComprobantesFileE File = new ComprobantesFileE() { numFile = Variables.Cero.ToString(), desFileComp = Variables.Todos };
                    ListaFiles.Add(File);
                    ComboHelper.RellenarCombos<ComprobantesFileE>(cboFile, (from x in ListaFiles orderby x.numFile select x).ToList(), "numFile", "desFileComp");

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

                    ListaFiles = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkTicaAuto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTicaAuto.Checked)
                {
                    txtTipoCambio.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                }
                else
                {
                    txtTipoCambio.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecOperacion_ValueChanged(object sender, EventArgs e)
        {
            dtpFecDocumento.Value = dtpFecOperacion.Value;
        }

        private void dtpFecDocumento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha = dtpFecDocumento.Value;
                Decimal Monto = VariablesLocales.MontoTicaConta(Fecha.Date, Variables.Dolares);
                
                if (Monto == 0)
                {
                    Global.MensajeFault("No hay Tipo de Cambio para este dia.\n\r\n\rColoque un dia que tenga o ingrese el tipo de cambio del dia.");
                }

                txtTipoCambio.Text = Monto.ToString("N3");
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

    }
}
