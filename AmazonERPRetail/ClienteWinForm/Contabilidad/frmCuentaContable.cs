using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Generales;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Winform;
using Infraestructura.Recursos;
using Infraestructura.Extensores;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmCuentaContable : FrmMantenimientoBase
    {

        #region Constructores

        public frmCuentaContable()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        //Edición
        public frmCuentaContable(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta)
            : this()
        {
            oCuentaContable = AgenteContabilidad.Proxy.ObtenerPlanCuentasPorCodigo(idEmpresa, VersionPlanCuentas, Cuenta, "S");
            oCuentaContable.Opcion = (Int32)EnumOpcionGrabar.Actualizar;
        }

        //Nuevo
        public frmCuentaContable(PlanCuentasE pc)
            : this()
        {
            oCuentaContable = pc;
        }

        #endregion

        #region Variables

        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public PlanCuentasE oCuentaContable = null;
        Int16 NivelGeneral = 0;

        Boolean ConAuxiliar = false;
        Boolean ConDocumento = false;
        Boolean ConCCostos = false;
        List<VoucherItemE> ListaVocher = null;
        String RevAuxiliar = "S";
        String RevDocumento = "S";
        String RevCCostos = "S";

        #endregion

        #region Procedimientos de Usuario

        void LlenarCombos()
        {
            cboIndNaturaleza.DataSource = Global.CargarDH();
            cboIndNaturaleza.ValueMember = "id";
            cboIndNaturaleza.DisplayMember = "Nombre";

            cboTipoNodo.DataSource = Global.CargarTitDet();
            cboTipoNodo.ValueMember = "id";
            cboTipoNodo.DisplayMember = "Nombre";

            cboCambioCompra.DataSource = Global.CargarVentaCompra();
            cboCambioCompra.ValueMember = "id";
            cboCambioCompra.DisplayMember = "Nombre";

            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            cboMoneda.DataSource = (from x in ListaMoneda
                                    where (x.idMoneda == Variables.Soles || x.idMoneda == Variables.Dolares)
                                    orderby x.idMoneda
                                    select x).ToList();
            cboMoneda.ValueMember = "idMoneda";
            cboMoneda.DisplayMember = "desMoneda";

            List<EnumParTabla> ListaParTabla = new List<EnumParTabla>
            {
                EnumParTabla.TipoBalanceContable,
                EnumParTabla.ConceptosCoVen,
                EnumParTabla.TipoCajaChica,
                EnumParTabla.TipoAjusteDiferencia
            };

            Dictionary<EnumParTabla, List<ParTabla>> ListaParametros = AgenteGeneral.Proxy.ListarParTablaPorListaGrupo(ListaParTabla);
            ParTabla addNew = new ParTabla
            {
                IdParTabla = 0,
                Nombre = Variables.Seleccione
            };

            ListaParametros[EnumParTabla.TipoBalanceContable].Add(addNew);
            ListaParametros[EnumParTabla.ConceptosCoVen].Add(addNew);
            ListaParametros[EnumParTabla.TipoCajaChica].Add(addNew);
            ListaParametros[EnumParTabla.TipoAjusteDiferencia].Add(addNew);

            ComboHelper.RellenarCombos<List<ParTabla>>(cboBalance, (from x in ListaParametros[EnumParTabla.TipoBalanceContable] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboColumnaCoVen, (from x in ListaParametros[EnumParTabla.ConceptosCoVen] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoCajaChica, (from x in ListaParametros[EnumParTabla.TipoCajaChica] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");
            ComboHelper.RellenarCombos<List<ParTabla>>(cboTipoAjuste, (from x in ListaParametros[EnumParTabla.TipoAjusteDiferencia] orderby x.IdParTabla select x).ToList(), "IdParTabla", "Nombre");

            List<TasaIRentaE> ListaTasas = AgenteContabilidad.Proxy.ListarTasaIRenta();
            ListaTasas.Add(new TasaIRentaE() { idTasaIRenta = Variables.Cero.ToString(), DesTasaIRenta = Variables.Seleccione });
            ComboHelper.RellenarCombos<TasaIRentaE>(cboTasa, (from x in ListaTasas orderby x.idTasaIRenta select x).ToList(), "idTasaIRenta", "DesTasaIRenta", false);

            if (oCuentaContable.oListaTasaRenta != null)
            {
                if (oCuentaContable.oListaTasaRenta.Count > 0)
                {
                    ComboHelper.RellenarCombos<CuentaTasaRentaE>(cboTasaCuenta, (from x in oCuentaContable.oListaTasaRenta orderby x.idTasaRenta select x).ToList(), "idTasaRenta", "desTasaRenta", false);
                }
            }

            ListaMoneda = null;
            ListaParametros = null;
            ListaTasas = null;
        }

        void Datos()
        {
            if (oCuentaContable.numNivel > 1)
            {
                oCuentaContable.codCuenta = txtCtaSuperior.Text + txtUltimoDigito.Text.Trim();
            }
            else
            {
                oCuentaContable.codCuentaSup = "0";
                oCuentaContable.codCuenta = txtUltimoDigito.Text.Trim();
            }

            oCuentaContable.indNaturalezaCta = cboIndNaturaleza.SelectedValue.ToString();
            oCuentaContable.Descripcion = txtDesCuenta.Text;
            oCuentaContable.tipPartidaPresu = txtTipPartidaPre.Text.Trim();
            oCuentaContable.codPartidaPresu = txtCodPartidaPre.Text.Trim();

            //Ajuste de Cambio
            if (chkIndAjusteCambio.Checked)
            {
                oCuentaContable.indAjuste_X_Cambio = Variables.SI;
                oCuentaContable.tipAjuste = Convert.ToInt32(cboTipoAjuste.SelectedValue);
                oCuentaContable.indCambio_X_Compra = cboCambioCompra.SelectedValue.ToString();
                oCuentaContable.codCuentaGanancia = txtCtaGanancia.Text.Trim();
                oCuentaContable.codCuentaPerdida = txtCtaPerdida.Text.Trim();
            }
            else
            {
                oCuentaContable.indAjuste_X_Cambio = Variables.NO;
                oCuentaContable.tipAjuste = Variables.Cero;
                oCuentaContable.indCambio_X_Compra = "A";
                oCuentaContable.codCuentaGanancia = String.Empty;
                oCuentaContable.codCuentaPerdida = String.Empty;
            }

            //Cuenta de Gasto
            if (chkIndGasto.Checked)
            {
                oCuentaContable.indCuentaGastos = Variables.SI;
                oCuentaContable.codCuentaTransferencia = txtCtaTransferencia.Text.Trim();
                oCuentaContable.codCuentaDestino = txtCtaDestino.Text.Trim();
            }
            else
            {
                oCuentaContable.indCuentaGastos = Variables.NO;
                oCuentaContable.codCuentaTransferencia = String.Empty;
                oCuentaContable.codCuentaDestino = String.Empty;
            }

            //Cuenta de Cierre
            if (chkIndCtaCierre.Checked)
            {
                oCuentaContable.indCuentaCierre = Variables.SI;
                oCuentaContable.codCuentaCieDeb = txtCtaCierre.Text.Trim();
            }
            else
            {
                oCuentaContable.indCuentaCierre = Variables.NO;
                oCuentaContable.codCuentaCieDeb = String.Empty;
            }

            //Renta
            oCuentaContable.indTasaRenta = chkTasa.Checked;
            oCuentaContable.idTasaRenta = chkTasa.Checked ? cboTasa.SelectedValue.ToString() : "0";
            //Balance
            oCuentaContable.indBalance = Convert.ToInt32(cboBalance.SelectedValue);
            oCuentaContable.tipTituloNodo = cboTipoNodo.SelectedValue.ToString();
            oCuentaContable.indUltNodo = oCuentaContable.tipTituloNodo == "TI" ? Variables.NO : Variables.SI;

            if (oCuentaContable.tipTituloNodo == "DE")
            {
                //Moneda
                oCuentaContable.idMoneda = cboMoneda.SelectedValue.ToString();
                //Para compras y ventas
                oCuentaContable.codColumnaCoven = Convert.ToInt32(cboColumnaCoVen.SelectedValue);
            }
            else
            {
                //Moneda
                oCuentaContable.idMoneda = String.Empty;
                //Para compras y ventas
                oCuentaContable.codColumnaCoven = 0;
            }

            //Si maneja Cta. Cte.
            oCuentaContable.indCtaCte = chkCtaCte.Checked == true ? Variables.SI : Variables.NO;
            //Si maneja Auxiliar
            oCuentaContable.indSolicitaAnexo = chkIndSolicitaAnexo.Checked == true ? Variables.SI : Variables.NO;
            //Si maneja documentos
            oCuentaContable.indSolicitaDcto = chkIndSolicitaDcto.Checked == true ? Variables.SI : Variables.NO;
            //Si maneja C.costos
            oCuentaContable.indSolicitaCentroCosto = chkIndSolicitaCc.Checked == true ? Variables.SI : Variables.NO;
            //Si maneja nota de ingreso
            oCuentaContable.indNotaIngreso = chkIndNotaIngreso.Checked == true ? Variables.SI : Variables.NO;
            //Si maneja anexo referencial
            oCuentaContable.indAnexoReferencial = chkIndAnexoReferencial.Checked == true ? Variables.SI : Variables.NO;

            //Fondos - Caja CHica
            if (chkIndCajaChica.Checked)
            {
                oCuentaContable.indCajaChica = Variables.SI;
                oCuentaContable.tipoCajaChica = Convert.ToInt32(cboTipoCajaChica.SelectedValue);
            }
            else
            {
                oCuentaContable.indCajaChica = Variables.NO;
                oCuentaContable.tipoCajaChica = (Nullable<Int32>)null;
            }

            //Para el módulo de cobranzas - no se usa
            oCuentaContable.indCtaIngreso = chkIndCtaIngreso.Checked == true ? Variables.SI : Variables.NO;

            //Para el reporte libro diario simplificado
            oCuentaContable.indReporteDs = chkIndReporte.Checked;

            if (chkIndReporte.Checked)
            {
                oCuentaContable.Titulo = txtTitulo.Text.Trim();
            }
            else
            {
                oCuentaContable.Titulo = String.Empty;
            }

            //Para sacar el auxiliar en Planillas, etc
            oCuentaContable.idAuxiliar = Convert.ToInt32(txtAuxiliar.Tag) != 0 ? Convert.ToInt32(txtAuxiliar.Tag) : (Int32?)null;

            if (oCuentaContable.Opcion == Convert.ToInt16(EnumOpcionGrabar.Insertar))
            {
                oCuentaContable.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oCuentaContable.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void BloquearPaneles(Boolean bFlag)
        {
            pnlCuenta.Enabled = bFlag;
            pnlCambios.Enabled = bFlag;
            pnlGastos.Enabled = bFlag;
            pblCierre.Enabled = bFlag;
            pnlConfiguracion.Enabled = bFlag;
            pnlChecks.Enabled = bFlag;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            try
            {
                if (oCuentaContable.numNivel == NivelGeneral)
                {
                    Int32 LongitudReal = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                    Int32 Longitud = oCuentaContable.codCuentaSup.Length;
                    txtUltimoDigito.MaxLength = LongitudReal - Longitud;            
                }

                if (oCuentaContable.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                {
                    txtCtaSuperior.Text = oCuentaContable.codCuentaSup;
                    txtDesCtaSuperior.Text = oCuentaContable.desCuentaSup;
                    txtCuenta.Text = oCuentaContable.codCuentaSup;
                    txtAuxiliar.Tag = 0;

                    if (oCuentaContable.numNivel == NivelGeneral)
                    {
                        cboTipoNodo.SelectedValue = "DE";
                        cboTipoNodo_SelectionChangeCommitted(new Object(), new EventArgs());
                    }

                    txtUsuarioRegistro.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaRegistro.Text = VariablesLocales.FechaHoy.ToString();
                    txtUsuarioModificacion.Text = VariablesLocales.SesionUsuario.Credencial;
                    txtFechaModificacion.Text = VariablesLocales.FechaHoy.ToString();

                    txtUltimoDigito.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    BloquearPaneles(true);
                }
                else
                {
                    txtCtaGanancia.TextChanged -= txtCtaGanancia_TextChanged;
                    txtDesCtaGanancia.TextChanged -= txtDesCtaGanancia_TextChanged;
                    txtCtaPerdida.TextChanged -= txtCtaPerdida_TextChanged;
                    txtDesCtaPerdida.TextChanged -= txtDesCtaPerdida_TextChanged;
                    txtCtaTransferencia.TextChanged -= txtCtaTransferencia_TextChanged;
                    txtDesCtaTransferencia.TextChanged -= txtDesCtaTransferencia_TextChanged;
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
                    txtCtaCierre.TextChanged -= txtCtaCierre_TextChanged;
                    txtDesCtaCierre.TextChanged -= txtDesCtaCierre_TextChanged;
                    txtAuxiliar.TextChanged -= txtAuxiliar_TextChanged;

                    txtCtaSuperior.Text = oCuentaContable.codCuentaSup;
                    txtDesCtaSuperior.Text = oCuentaContable.desCuentaSup;

                    txtCuenta.Text = oCuentaContable.codCuentaSup;
                    txtUltimoDigito.Text = oCuentaContable.Digitos;
                    cboIndNaturaleza.SelectedValue = oCuentaContable.indNaturalezaCta.ToString();
                    txtCodPartidaPre.Text = oCuentaContable.codPartidaPresu;
                    txtDesCuenta.Text = oCuentaContable.Descripcion;

                    chkIndAjusteCambio.Checked = oCuentaContable.indAjuste_X_Cambio.ToString() == Variables.SI ? true : false;
                    chkIndAjusteCambio_CheckedChanged(new object(), new EventArgs());
                    cboTipoAjuste.SelectedValue = Convert.ToInt32(oCuentaContable.tipAjuste);
                    cboCambioCompra.SelectedValue = oCuentaContable.indCambio_X_Compra.ToString();
                    txtCtaGanancia.Text = oCuentaContable.codCuentaGanancia;
                    txtDesCtaGanancia.Text = oCuentaContable.desCuentaGanancia;
                    txtCtaPerdida.Text = oCuentaContable.codCuentaPerdida;
                    txtDesCtaPerdida.Text = oCuentaContable.desCuentaPerdida;

                    chkIndGasto.Checked = oCuentaContable.indCuentaGastos.ToString() == Variables.SI ? true : false;
                    chkIndGasto_CheckedChanged(new object(), new EventArgs());
                    txtCtaTransferencia.Text = oCuentaContable.codCuentaTransferencia;
                    txtDesCtaTransferencia.Text = oCuentaContable.desCuentaTransfe;
                    txtCtaDestino.Text = oCuentaContable.codCuentaDestino;
                    txtDesCtaDestino.Text = oCuentaContable.desCuentaDestino;

                    chkIndCtaCierre.Checked = oCuentaContable.indCuentaCierre.ToString() == Variables.SI ? true : false;
                    chkIndCtaCierre_CheckedChanged(new object(), new EventArgs());
                    txtCtaCierre.Text = oCuentaContable.codCuentaCieDeb;
                    txtDesCtaCierre.Text = oCuentaContable.desCuentaCieDeb;

                    chkTasa.Checked = oCuentaContable.indTasaRenta;
                    chkTasa_CheckedChanged(new object(), new EventArgs());

                    if (oCuentaContable.idTasaRenta != "0" && !string.IsNullOrEmpty(oCuentaContable.idTasaRenta.Trim()))
                    {
                        cboTasa.SelectedValue = oCuentaContable.idTasaRenta.ToString();
                    }
                    else
                    {
                        cboTasa.SelectedValue = "0";
                    }

                    cboBalance.SelectedValue = Convert.ToInt32(oCuentaContable.indBalance);

                    cboTipoNodo.SelectedValue = oCuentaContable.tipTituloNodo.ToString();
                    cboTipoNodo_SelectionChangeCommitted(new Object(), new EventArgs());

                    cboMoneda.SelectedValue = oCuentaContable.idMoneda.ToString();
                    cboColumnaCoVen.SelectedValue = Convert.ToInt32(oCuentaContable.codColumnaCoven);

                    //Si maneja Cta. Cte.
                    chkCtaCte.Checked = oCuentaContable.indCtaCte == Variables.SI ? true : false;
                    //Si maneja Auxiliar
                    chkIndSolicitaAnexo.Checked = oCuentaContable.indSolicitaAnexo == Variables.SI ? true : false;
                    ConAuxiliar = chkIndSolicitaAnexo.Checked;
                    //Si maneja documentos
                    chkIndSolicitaDcto.Checked = oCuentaContable.indSolicitaDcto == Variables.SI ? true : false;
                    ConDocumento = chkIndSolicitaDcto.Checked;
                    //Si maneja C.costos
                    chkIndSolicitaCc.Checked = oCuentaContable.indSolicitaCentroCosto == Variables.SI ? true : false;
                    ConCCostos = chkIndSolicitaCc.Checked;
                    if (chkIndSolicitaCc.Checked == true)
                    {
                        txtCCostos.Text = oCuentaContable.idCCostos;
                        btCentroC.Enabled = true;
                    }

                    //Si maneja nota de ingreso
                    chkIndNotaIngreso.Checked = oCuentaContable.indNotaIngreso == Variables.SI ? true : false;
                    //Si maneja anexo referencial
                    chkIndAnexoReferencial.Checked = oCuentaContable.indAnexoReferencial == Variables.SI ? true : false;
                    chkIndCajaChica.Checked = oCuentaContable.indCajaChica == Variables.SI ? true : false;
                    cboTipoCajaChica.SelectedValue = Convert.ToInt32(oCuentaContable.tipoCajaChica);
                    chkIndCtaIngreso.Checked = oCuentaContable.indCtaIngreso == Variables.SI ? true : false;

                    chkIndReporte.Checked = oCuentaContable.indReporteDs;
                    txtTitulo.Text = oCuentaContable.Titulo.Trim();
                    txtAuxiliar.Tag = oCuentaContable.idAuxiliar;
                    txtAuxiliar.Text = oCuentaContable.RazonSocial;


                    txtUsuarioRegistro.Text = oCuentaContable.UsuarioRegistro;
                    txtFechaRegistro.Text = oCuentaContable.FechaRegistro.ToString();
                    txtUsuarioModificacion.Text = oCuentaContable.UsuarioModificacion;
                    txtFechaModificacion.Text = oCuentaContable.FechaModificacion.ToString();

                    BloquearPaneles(true);

                    txtCtaGanancia.TextChanged += txtCtaGanancia_TextChanged;
                    txtDesCtaGanancia.TextChanged += txtDesCtaGanancia_TextChanged;
                    txtCtaPerdida.TextChanged += txtCtaPerdida_TextChanged;
                    txtDesCtaPerdida.TextChanged += txtDesCtaPerdida_TextChanged;
                    txtCtaTransferencia.TextChanged += txtCtaTransferencia_TextChanged;
                    txtDesCtaTransferencia.TextChanged += txtDesCtaTransferencia_TextChanged;
                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                    txtCtaCierre.TextChanged += txtCtaCierre_TextChanged;
                    txtDesCtaCierre.TextChanged += txtDesCtaCierre_TextChanged;
                    txtAuxiliar.TextChanged += txtAuxiliar_TextChanged;
                }

                base.Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);

            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        public override void Grabar()
        {
            try
            {
                Datos();

                if (!ValidarGrabacion())
                {
                    return;
                }

                if (oCuentaContable.Opcion == Convert.ToInt16(EnumOpcionGrabar.Insertar))
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoGrabacion) == DialogResult.Yes)
                    {
                        oCuentaContable = AgenteContabilidad.Proxy.InsertarPlanCuentas(oCuentaContable);
                        Global.MensajeComunicacion(Mensajes.GrabacionExitosa);
                    }
                }
                else
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoActualizacion) == DialogResult.Yes)
                    {
                        oCuentaContable = AgenteContabilidad.Proxy.ActualizarPlanCuentas(oCuentaContable);
                        Global.MensajeComunicacion(Mensajes.ActualizacionCorrecta);
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

        public override Boolean ValidarGrabacion()
        {
            String Respuesta = ValidarEntidad<PlanCuentasE>(oCuentaContable);

            if (!String.IsNullOrEmpty(Respuesta))
            {
                Global.MensajeComunicacion(Respuesta);
                return false;
            }

            if (oCuentaContable.numNivel == NivelGeneral && cboTipoNodo.SelectedValue.ToString() != "DE")
            {
                Global.MensajeComunicacion("Este Nivel debe ser de Detalle..");
                cboTipoNodo.Focus();
                return false;
            }

            if (oCuentaContable.numNivel < NivelGeneral && cboTipoNodo.SelectedValue.ToString() != "TI")
            {
                Global.MensajeComunicacion("Este Nivel debe ser de Titulo..");
                cboTipoNodo.Focus();
                return false;
            }

            //VALIDANDO LA CUENTA, SOLO SI ES NUEVO
            if (oCuentaContable.Opcion == Convert.ToInt16(EnumOpcionGrabar.Insertar))
            {
                Respuesta = AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(oCuentaContable.idEmpresa, oCuentaContable.numVerPlanCuentas, oCuentaContable.codCuenta);

                if (!String.IsNullOrEmpty(Respuesta))
                {
                    Global.MensajeComunicacion("La cuenta " + oCuentaContable.codCuenta + " esta asignado a " + Respuesta + ".\r\nDigite nuevamente por favor.");
                    txtUltimoDigito.Focus();
                    return false;
                }
            }

            //VALIDANDO LA CUENTAS DE AJUSTE DE DIFERENCIA DE CAMBIO
            if (chkIndAjusteCambio.Checked)
            {
                if (Convert.ToInt32(cboTipoAjuste.SelectedValue) == Variables.Cero)
                {
                    Global.MensajeComunicacion("Ha habilitado la opcion de Ajuste de Cambio, tiene que escoger un Tipo de Ajuste.");
                    cboTipoAjuste.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtDesCtaGanancia.Text))
                {
                    Global.MensajeComunicacion("Ha habilitado la opcion de Ajuste de Cambio, tiene que colocar la Cta. de Ganancia.");
                    txtCtaGanancia.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtDesCtaPerdida.Text))
                {
                    Global.MensajeComunicacion("Ha habilitado la opcion de Ajuste de Cambio, tiene que colocar la Cta. de Perdida.");
                    txtCtaPerdida.Focus();
                    return false;
                }
            }

            //VALIDANDO LA CUENTA DE GASTO
            if (chkIndGasto.Checked)
            {
                if (String.IsNullOrEmpty(txtDesCtaTransferencia.Text))
                {
                    Global.MensajeComunicacion("Ha habilitado la opcion de Cta. de Gasto, tiene que colocar la Cta. de Transferencia.");
                    txtCtaTransferencia.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(txtDesCtaDestino.Text) || String.IsNullOrEmpty(txtCtaDestino.Text))
                {
                    Global.MensajeComunicacion("Ha habilitado la opcion de Cta. de Gasto, tiene que colocar la Cta. de Destino.");
                    txtCtaDestino.Focus();
                    return false;
                }
            }

            //VALIDANDO LA CUENTA DE CIERRE
            if (chkIndCtaCierre.Checked)
            {
                if (String.IsNullOrEmpty(txtDesCtaCierre.Text))
                {
                    Global.MensajeComunicacion("Tiene habilitado la opcion de Cta. de Cierre, tiene que colocar su cuenta respectiva.");
                    txtCtaCierre.Focus();
                    return false;
                }
            }

            //VALIDANDO EL INDICADOR DE BALANCE
            if (txtCuenta.Text != Variables.Cero.ToString())
            {
                if (Convert.ToInt32(cboBalance.SelectedValue) == 0)
                {
                    Global.MensajeComunicacion("Tiene que seleccionar el indicador de balance.");
                    cboBalance.Focus();
                    return false;
                }
            }

            //VALIDANDO POR EL TIPO DE AJUSTE (AJUSTE DE CAMBIO)
            if (chkIndAjusteCambio.Checked)
            {
                //CUENTA + ANEXO + DOCUMENTO
                if (Convert.ToInt32(cboTipoAjuste.SelectedValue) == Convert.ToInt32(EnumAjustesDiferencia.CDTO))
                {
                    if (!chkIndSolicitaDcto.Checked)
                    {
                        Global.MensajeComunicacion("Para realizar el Ajuste por Cuenta + Anexo + Documento\n\rTiene que Marcar el tipo de Cta.Cte Con Documento.");
                        return false;
                    }

                    if (!chkIndSolicitaAnexo.Checked)
                    {
                        Global.MensajeComunicacion("Para realizar el Ajuste por Cuenta + Anexo + Documento\n\rTiene que Marcar el tipo de Cta.Cte Con Auxiliar.");
                        return false;
                    }

                    if (!chkCtaCte.Checked)
                    {
                        Global.MensajeComunicacion("Para el ajuste por Cuenta + Anexo + Documento\n\rTiene que Marcar Cuenta Corriente.");
                        return false;
                    }
                }

                //CUENTA + ANEXO
                if (Convert.ToInt32(cboTipoAjuste.SelectedValue) == Convert.ToInt32(EnumAjustesDiferencia.CCTA))
                {
                    if (!chkIndSolicitaAnexo.Checked)
                    {
                        Global.MensajeComunicacion("Para realizar el Ajuste por Cuenta + Anexo\n\rTiene que Marcar el tipo de Cta.Cte por Anexo.");
                        return false;
                    }

                    if (chkIndSolicitaDcto.Checked)
                    {
                        Global.MensajeComunicacion("Para realizar el Ajuste por Cuenta + Anexo\n\rNo Tiene que Marcar el tipo de Cta.Cte por Documento.");
                        return false;
                    }

                    if (!chkCtaCte.Checked)
                    {
                        Global.MensajeComunicacion("Para el ajuste por Cuenta + Anexo\n\rTiene que Marcar Cuenta Corriente.");
                        return false;
                    }
                }

                //POR CUENTA...
                if (Convert.ToInt32(cboTipoAjuste.SelectedValue) == Convert.ToInt32(EnumAjustesDiferencia.CTA))
                {
                    if (chkCtaCte.Checked)
                    {
                        Global.MensajeComunicacion("Para el ajuste por Cuenta no tiene que marcar Cuenta Corriente.");
                        return false;
                    }
                }
            }

            //VALIDANDO LA CUENTA SI MANEJA CUENTA CORRIENTE
            if (chkCtaCte.Checked)
            {
                if (!chkIndSolicitaAnexo.Checked && !chkIndSolicitaDcto.Checked)
                {
                    Global.MensajeComunicacion("Tiene habilitado la opcion de Cta. Cte.\n\rSeleccione Cta. Cte. por codigo Auxiliar ó por documento.");
                    return false;
                }
            }

            if (chkIndCajaChica.Checked)
            {
                if (Convert.ToInt32(cboTipoCajaChica.SelectedValue) == Variables.Cero)
                {
                    Global.MensajeComunicacion("Tiene habilitado la opcion Fondos Fijos\n\rTiene que escoger un tipo de fondo.");
                    cboTipoCajaChica.Focus();
                    return false;
                }
            }

            if (oCuentaContable.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
            {
                if (chkIndSolicitaAnexo.Checked)
                {
                    if (ConAuxiliar != chkIndSolicitaAnexo.Checked)
                    {
                        if (RevAuxiliar == "S")
                        {
                            if (ListaVocher == null)
                            {
                                ListaVocher = AgenteContabilidad.Proxy.BuscarVoucherPorCtaContableTipo(oCuentaContable.idEmpresa, VariablesLocales.SesionLocal.IdLocal, oCuentaContable.numVerPlanCuentas, oCuentaContable.codCuenta, "A"); 
                            }

                            if (ListaVocher != null && ListaVocher.Count > 0)
                            {
                                Global.MensajeAdvertencia("Existen asientos contables que no cuentan con un auxiliar, debera ingresar uno para poder actualizar a todos.");
                                btAuxiliar.Enabled = true;
                                return false;
                            }
                        }
                    }
                }

                if (chkIndSolicitaDcto.Checked)
                {
                    if (ConDocumento != chkIndSolicitaDcto.Checked)
                    {
                        if (RevDocumento == "S")
                        {
                            if (ListaVocher == null)
                            {
                                ListaVocher = AgenteContabilidad.Proxy.BuscarVoucherPorCtaContableTipo(oCuentaContable.idEmpresa, VariablesLocales.SesionLocal.IdLocal, oCuentaContable.numVerPlanCuentas, oCuentaContable.codCuenta, "D"); 
                            }

                            if (ListaVocher != null && ListaVocher.Count > 0)
                            {
                                Global.MensajeAdvertencia("Existen asientos contables que no cuentan con datos del Documento, debera ingresar uno para poder actualizar a todos.");
                                btDocumento.Enabled = true;
                                return false;
                            }
                        }
                    }
                }

                if (chkIndSolicitaCc.Checked)
                {
                    if (ConCCostos != chkIndSolicitaCc.Checked)
                    {
                        if (RevCCostos == "S" && ListaVocher == null)
                        {
                            if (ListaVocher == null)
                            {
                                ListaVocher = AgenteContabilidad.Proxy.BuscarVoucherPorCtaContableTipo(oCuentaContable.idEmpresa, VariablesLocales.SesionLocal.IdLocal, oCuentaContable.numVerPlanCuentas, oCuentaContable.codCuenta, "C"); 
                            }

                            if (ListaVocher != null && ListaVocher.Count > 0)
                            {
                                Global.MensajeAdvertencia("Existen asientos contables que no cuentan con Centros de Costos, debera ingresar uno para poder actualizar a todos.");
                                btCcostos.Enabled = true;
                                return false;
                            }
                        }
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCuentaContable_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                NivelGeneral = Convert.ToInt16(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
                LlenarCombos();
                Nuevo();

                txtCtaGanancia.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaPerdida.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaTransferencia.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaDestino.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
                txtCtaCierre.MaxLength = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.Longitud);
            }
            catch (Exception ex)
            {
                Global.MensajeComunicacion(ex.Message);
            }
        }

        private void chkIndAjusteCambio_CheckedChanged(object sender, EventArgs e)
        {
            cboTipoAjuste.Enabled = chkIndAjusteCambio.Checked;
            cboCambioCompra.Enabled = chkIndAjusteCambio.Checked;
            txtCtaGanancia.Enabled = chkIndAjusteCambio.Checked;
            btCtaGanancia.Enabled = chkIndAjusteCambio.Checked;
            txtCtaPerdida.Enabled = chkIndAjusteCambio.Checked;
            btCtaPerdida.Enabled = chkIndAjusteCambio.Checked;
        }

        private void chkIndGasto_CheckedChanged(object sender, EventArgs e)
        {
            //txtCtaTransferencia.Enabled = chkIndGasto.Checked;
            //btCtaTransferencia.Enabled = chkIndGasto.Checked;
            //txtCtaDestino.Enabled = chkIndGasto.Checked;
            //btCtaDestino.Enabled = chkIndGasto.Checked;
            if (chkIndGasto.Checked)
            {
                txtCtaTransferencia.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCtaTransferencia.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtCtaTransferencia.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCtaTransferencia.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCtaDestino.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void chkIndCtaCierre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndCtaCierre.Checked)
            {
                txtCtaCierre.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtDesCtaCierre.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtCtaCierre.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                txtDesCtaCierre.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
            //txtCtaCierre.Enabled = chkIndCtaCierre.Checked;
            //btCtaCierre.Enabled = chkIndCtaCierre.Checked;
        }

        private void btCtaGanancia_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oCuentaContable.codCuentaGanancia = txtCtaGanancia.Text = oFrm.Cuentas.codCuenta;
                    txtDesCtaGanancia.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCtaPerdida_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oCuentaContable.codCuentaPerdida = txtCtaPerdida.Text = oFrm.Cuentas.codCuenta;
                    txtDesCtaPerdida.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkIndCajaChica_CheckedChanged(object sender, EventArgs e)
        {
            cboTipoCajaChica.Enabled = chkIndCajaChica.Checked;
        }

        private void txtCtaCierre_Leave(object sender, EventArgs e)
        {
            //if (chkIndCtaCierre.Checked)
            //{
            //    if (txtCtaCierre.TextLength > 0)
            //    {
            //        desCuenta = Convert.ToString(AgenteContabilidad.Proxy.ObtenerDescripcionCuenta(oCuentaContable.idEmpresa, oCuentaContable.numVerPlanCuentas, txtCtaCierre.Text));

            //        if (desCuenta != Variables.Cero.ToString())
            //        {
            //            txtDesCtaCierre.Text = desCuenta;
            //        }
            //        else
            //        {
            //            Global.MensajeComunicacion("La cuenta ingresada no existe, vuelva a digitar.");
            //            txtCtaCierre.Text = String.Empty;
            //            txtDesCtaCierre.Text = String.Empty;
            //            txtCtaCierre.Focus();
            //        }
            //    }
            //}
        }

        private void btPresupuesto_Click(object sender, EventArgs e)
        {
            frmBuscarPartida oFrm = new frmBuscarPartida();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPartidaPresupuestal != null)
            {
                txtCodPartidaPre.TextChanged -= txtCodPartidaPre_TextChanged;
                txtTipPartidaPre.Text = oFrm.oPartidaPresupuestal.tipPartidaPresu;
                txtCodPartidaPre.Text = oFrm.oPartidaPresupuestal.codPartidaPresu;
                txtCodPartidaPre.TextChanged += txtCodPartidaPre_TextChanged;
            }
        }

        private void btCtaDestino_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oCuentaContable.codCuentaDestino = txtCtaDestino.Text = oFrm.Cuentas.codCuenta;
                    txtDesCtaDestino.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCtaTransferencia_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oCuentaContable.codCuentaTransferencia = txtCtaTransferencia.Text = oFrm.Cuentas.codCuenta;
                    txtDesCtaTransferencia.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCtaCierre_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCuentas oFrm = new frmBuscarCuentas();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.Cuentas != null)
                {
                    oCuentaContable.codCuentaCieDeb = txtCtaCierre.Text = oFrm.Cuentas.codCuenta;
                    txtDesCtaCierre.Text = oFrm.Cuentas.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void chkTasa_CheckedChanged(object sender, EventArgs e)
        {
            cboTasaCuenta.Enabled = chkTasa.Checked;
            cboTasa.Enabled = chkTasa.Checked;
            btInsertarTasa.Enabled = chkTasa.Checked;
            btQuitarTasa.Enabled = chkTasa.Checked;

            if (!chkTasa.Checked)
            {
                oCuentaContable.oListaTasaRenta = new List<CuentaTasaRentaE>();
                cboTasaCuenta.DataSource = oCuentaContable.oListaTasaRenta;
                cboTasa.SelectedValue = "0";
            }
        }

        private void txtCodPartidaPre_TextChanged(object sender, EventArgs e)
        {
            txtTipPartidaPre.Text = string.Empty;
        }

        #region Ajuste por Cambio

        private void txtCtaGanancia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaGanancia.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaGanancia.Text.Trim()))
                {
                    txtCtaGanancia.TextChanged -= txtCtaGanancia_TextChanged;
                    txtDesCtaGanancia.TextChanged -= txtDesCtaGanancia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaGanancia.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaGanancia.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaGanancia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaGanancia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaGanancia.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaGanancia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaGanancia.Text = string.Empty;
                        txtDesCtaGanancia.Text = string.Empty;
                    }

                    txtCtaGanancia.TextChanged += txtCtaGanancia_TextChanged;
                    txtDesCtaGanancia.TextChanged += txtDesCtaGanancia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaPerdida_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaPerdida.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaPerdida.Text.Trim()))
                {
                    txtCtaPerdida.TextChanged -= txtCtaPerdida_TextChanged;
                    txtDesCtaPerdida.TextChanged -= txtDesCtaPerdida_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaPerdida.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaPerdida.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaPerdida.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaPerdida.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaPerdida.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaPerdida.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaPerdida.Text = string.Empty;
                        txtDesCtaPerdida.Text = string.Empty;
                    }

                    txtCtaPerdida.TextChanged += txtCtaPerdida_TextChanged;
                    txtDesCtaPerdida.TextChanged += txtDesCtaPerdida_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaGanancia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaGanancia.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaGanancia.Text.Trim()))
                {
                    txtCtaGanancia.TextChanged -= txtCtaGanancia_TextChanged;
                    txtDesCtaGanancia.TextChanged -= txtDesCtaGanancia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaGanancia.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaGanancia.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaGanancia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaGanancia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaGanancia.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaGanancia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaGanancia.Text = string.Empty;
                        txtDesCtaGanancia.Text = string.Empty;
                    }

                    txtCtaGanancia.TextChanged += txtCtaGanancia_TextChanged;
                    txtDesCtaGanancia.TextChanged += txtDesCtaGanancia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaPerdida_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaPerdida.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaPerdida.Text.Trim()))
                {
                    txtCtaPerdida.TextChanged -= txtCtaPerdida_TextChanged;
                    txtDesCtaPerdida.TextChanged -= txtDesCtaPerdida_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaPerdida.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaPerdida.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaPerdida.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaPerdida.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaPerdida.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaPerdida.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaPerdida.Text = string.Empty;
                        txtDesCtaPerdida.Text = string.Empty;
                    }

                    txtCtaPerdida.TextChanged += txtCtaPerdida_TextChanged;
                    txtDesCtaPerdida.TextChanged += txtDesCtaPerdida_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaGanancia_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaGanancia.Text = String.Empty;
        }

        private void txtDesCtaGanancia_TextChanged(object sender, EventArgs e)
        {
            txtCtaGanancia.Text = String.Empty;
        }

        private void txtCtaPerdida_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaPerdida.Text = String.Empty;
        }

        private void txtDesCtaPerdida_TextChanged(object sender, EventArgs e)
        {
            txtCtaPerdida.Text = String.Empty;
        }

        #endregion

        #region Gastos

        private void txtCtaTransferencia_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaTransferencia.Text = String.Empty;
        }

        private void txtDesCtaTransferencia_TextChanged(object sender, EventArgs e)
        {
            txtCtaTransferencia.Text = String.Empty;
        }

        private void txtCtaDestino_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaDestino.Text = String.Empty;
        }

        private void txtDesCtaDestino_TextChanged(object sender, EventArgs e)
        {
            txtCtaDestino.Text = String.Empty;
        }

        private void txtCtaTransferencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaTransferencia.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaTransferencia.Text.Trim()))
                {
                    txtCtaTransferencia.TextChanged -= txtCtaTransferencia_TextChanged;
                    txtDesCtaTransferencia.TextChanged -= txtDesCtaTransferencia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaTransferencia.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaTransferencia.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaTransferencia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaTransferencia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaTransferencia.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaTransferencia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaTransferencia.Text = string.Empty;
                        txtDesCtaTransferencia.Text = string.Empty;
                    }

                    txtCtaTransferencia.TextChanged += txtCtaTransferencia_TextChanged;
                    txtDesCtaTransferencia.TextChanged += txtDesCtaTransferencia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaTransferencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaTransferencia.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaTransferencia.Text.Trim()))
                {
                    txtCtaTransferencia.TextChanged -= txtCtaTransferencia_TextChanged;
                    txtDesCtaTransferencia.TextChanged -= txtDesCtaTransferencia_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaTransferencia.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaTransferencia.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaTransferencia.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaTransferencia.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaTransferencia.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaTransferencia.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaTransferencia.Text = string.Empty;
                        txtDesCtaTransferencia.Text = string.Empty;
                    }

                    txtCtaTransferencia.TextChanged += txtCtaTransferencia_TextChanged;
                    txtDesCtaTransferencia.TextChanged += txtDesCtaTransferencia_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtCtaDestino_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaDestino.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaDestino.Text.Trim()))
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaDestino.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDestino.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDestino.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaDestino.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDestino.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDestino.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDestino.Text = string.Empty;
                        txtDesCtaDestino.Text = string.Empty;
                    }

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaDestino_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaDestino.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaDestino.Text.Trim()))
                {
                    txtCtaDestino.TextChanged -= txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged -= txtDesCtaDestino_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaDestino.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaDestino.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaDestino.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaDestino.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaDestino.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaDestino.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaDestino.Text = string.Empty;
                        txtDesCtaDestino.Text = string.Empty;
                    }

                    txtCtaDestino.TextChanged += txtCtaDestino_TextChanged;
                    txtDesCtaDestino.TextChanged += txtDesCtaDestino_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Cierre

        private void txtCtaCierre_TextChanged(object sender, EventArgs e)
        {
            txtDesCtaCierre.Text = String.Empty;
        }

        private void txtDesCtaCierre_TextChanged(object sender, EventArgs e)
        {
            txtCtaCierre.Text = String.Empty;
        }

        private void txtCtaCierre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtaCierre.Text.Trim()) && string.IsNullOrEmpty(txtDesCtaCierre.Text.Trim()))
                {
                    txtCtaCierre.TextChanged -= txtCtaCierre_TextChanged;
                    txtDesCtaCierre.TextChanged -= txtDesCtaCierre_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtCtaCierre.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 1);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaCierre.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaCierre.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaCierre.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaCierre.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaCierre.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La Cuenta ingresada no existe");
                        txtCtaDestino.Text = string.Empty;
                        txtDesCtaCierre.Text = string.Empty;
                    }

                    txtCtaCierre.TextChanged += txtCtaCierre_TextChanged;
                    txtDesCtaCierre.TextChanged += txtDesCtaCierre_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesCtaCierre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCtaCierre.Text.Trim()) && !string.IsNullOrEmpty(txtDesCtaCierre.Text.Trim()))
                {
                    txtCtaCierre.TextChanged -= txtCtaCierre_TextChanged;
                    txtDesCtaCierre.TextChanged -= txtDesCtaDestino_TextChanged;
                    List<PlanCuentasE> oListaCuentas = new ContabilidadServiceAgent().Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                                            VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                                                                                                            txtDesCtaCierre.Text,
                                                                                                                            Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel), 2);
                    if (oListaCuentas.Count > Variables.ValorUno)
                    {
                        frmBusquedaCuentasPorFiltro oFrm = new frmBusquedaCuentasPorFiltro(oListaCuentas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oCuenta != null)
                        {
                            txtCtaCierre.Text = oFrm.oCuenta.codCuenta;
                            txtDesCtaCierre.Text = oFrm.oCuenta.Descripcion;
                        }
                        else
                        {
                            txtDesCtaCierre.Focus();
                        }
                    }
                    else if (oListaCuentas.Count == 1)
                    {
                        txtCtaCierre.Text = oListaCuentas[0].codCuenta;
                        txtDesCtaCierre.Text = oListaCuentas[0].Descripcion;
                    }
                    else
                    {
                        Global.MensajeFault("La descripción de la cuenta ingresada no existe");
                        txtCtaCierre.Text = string.Empty;
                        txtDesCtaCierre.Text = string.Empty;
                    }

                    txtCtaCierre.TextChanged += txtCtaCierre_TextChanged;
                    txtDesCtaCierre.TextChanged += txtDesCtaCierre_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        private void btInsertarTasa_Click(object sender, EventArgs e)
        {
            try
            {
                TasaIRentaE oTasaRenta = ((TasaIRentaE)cboTasa.SelectedItem);

                if (oTasaRenta != null)
                {
                    CuentaTasaRentaE Item = new CuentaTasaRentaE()
                    {
                        idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                        codCuenta = txtCtaSuperior.Text.Trim() + txtUltimoDigito.Text.Trim(),
                        numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                        idTasaRenta = oTasaRenta.idTasaIRenta,
                        desTasaRenta = oTasaRenta.DesTasaIRenta
                    };

                    if (oCuentaContable.oListaTasaRenta != null)
                    {
                        if (oTasaRenta.idTasaIRenta == "0")
                        {
                            return;
                        }

                        CuentaTasaRentaE CuentaTasa = oCuentaContable.oListaTasaRenta.Find
                        (
                            delegate (CuentaTasaRentaE tr) { return tr.idTasaRenta == Item.idTasaRenta; }
                        );

                        if (CuentaTasa != null)
                        {
                            Global.MensajeComunicacion("La tasa ya ha sido ingresada.");
                            return;
                        }

                        oCuentaContable.oListaTasaRenta.Add(Item);
                        ComboHelper.RellenarCombos<CuentaTasaRentaE>(cboTasaCuenta, (from x in oCuentaContable.oListaTasaRenta orderby x.idTasaRenta select x).ToList(), "idTasaRenta", "desTasaRenta", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btQuitarTasa_Click(object sender, EventArgs e)
        {
            try
            {
                CuentaTasaRentaE oCuentaTasa = ((CuentaTasaRentaE)cboTasaCuenta.SelectedItem);
                cboTasaCuenta.DataSource = null;
                oCuentaContable.oListaTasaRenta.Remove(oCuentaTasa);
                ComboHelper.RellenarCombos<CuentaTasaRentaE>(cboTasaCuenta, (from x in oCuentaContable.oListaTasaRenta orderby x.idTasaRenta select x).ToList(), "idTasaRenta", "desTasaRenta", false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboTipoNodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoNodo.SelectedValue.ToString() == "DE")
            {
                cboMoneda.Enabled = true;
                cboMoneda.SelectedValue = Variables.Soles;
                cboColumnaCoVen.Enabled = true;
            }
            else
            {
                cboMoneda.Enabled = false;
                cboMoneda.SelectedValue = -1;
                cboColumnaCoVen.Enabled = false;
                cboColumnaCoVen.SelectedValue = 0;
            }
        }

        private void chkIndReporte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndReporte.Checked)
            {
                txtTitulo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
            }
            else
            {
                txtTitulo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
            }
        }

        private void txtAuxiliar_TextChanged(object sender, EventArgs e)
        {
            txtAuxiliar.Tag = 0;
        }

        private void txtAuxiliar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAuxiliar.Text.Trim()) && Convert.ToInt32(txtAuxiliar.Tag) == 0)
                {
                    txtAuxiliar.TextChanged -= txtAuxiliar_TextChanged;

                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtAuxiliar.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtAuxiliar.Tag = oFrm.oPersona.IdPersona;
                            txtAuxiliar.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtAuxiliar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtAuxiliar.Tag = oListaPersonas[0].IdPersona;
                        txtAuxiliar.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtAuxiliar.Tag = 0;
                        txtAuxiliar.Text = String.Empty;
                    }

                    txtAuxiliar.TextChanged += txtAuxiliar_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btAuxiliar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaVocher != null && ListaVocher.Count > 0)
                {
                    frmDatosAuxiDocCC oFrm = new frmDatosAuxiDocCC("A", ListaVocher);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        RevAuxiliar = "N";
                        btAuxiliar.Enabled = false;
                        ListaVocher = null;
                        Grabar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaVocher != null && ListaVocher.Count > 0)
                {
                    frmDatosAuxiDocCC oFrm = new frmDatosAuxiDocCC("D", ListaVocher);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        RevDocumento = "N";
                        btDocumento.Enabled = false;
                        ListaVocher = null;
                        Grabar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btCcostos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaVocher != null && ListaVocher.Count > 0)
                {
                    frmDatosAuxiDocCC oFrm = new frmDatosAuxiDocCC("C", ListaVocher);

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        RevCCostos = "N";
                        btCcostos.Enabled = false;
                        ListaVocher = null;
                        Grabar();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
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
                txtCCostos.Text = oCuentaContable.idCCostos = oFrm.CentroCosto.idCCostos;
            }
        }

        private void chkIndSolicitaCc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndSolicitaCc.Checked == true)
            {
                btCentroC.Enabled = true;
            }
            else
            {
                btCentroC.Enabled = false;
                txtCCostos.Text = String.Empty;
                oCuentaContable.idCCostos = String.Empty;
            }
        }

        #endregion


    }
}
