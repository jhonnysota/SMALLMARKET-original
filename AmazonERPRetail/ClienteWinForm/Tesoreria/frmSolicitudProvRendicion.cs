using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Seguridad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;
using ClienteWinForm.Contabilidad.CtasPorPagar;
using Entidades.Generales;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmSolicitudProvRendicion : FrmMantenimientoBase
    {

        #region Constructores

        //Nuevo
        public frmSolicitudProvRendicion()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Global.AjustarResolucion(this);

            FormatoGrid(dgvDetalle, true);
            LlenarCombos();
        }

        //Edición
        public frmSolicitudProvRendicion(Int32 idRendicion)
            : this()
        {
            oRendicion = AgenteTesoreria.Proxy.RecuperarSolicitudProveedorRendicion(idRendicion);
            Text = "Rendición de Adelanto Proveedor (" + oRendicion.codRendicion + ")";
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        SolicitudProveedorRendicionE oRendicion = null;
        List<ComprobantesE> comprobantes = null;
        List<ComprobantesFileE> files = null;
        String Bloqueo = "N";
        Int32 Opcion = 0;
        //ListBox lblListaFile = null;
        //ListBox lblListaTmp = null;

        #endregion

        #region Procedimientos de Usuario

        void Calcular()
        {
            if (oRendicion.oListaRendiciones != null && oRendicion.oListaRendiciones.Count > 0)
            {
                Decimal Dolares = oRendicion.oListaRendiciones.Sum(x => x.DolaresRecibidos);
                Decimal Soles = oRendicion.oListaRendiciones.Sum(x => x.SolesRecibidos);

                lblMontoDolares.Text = Dolares.ToString("N2");
                lblMontoSoles.Text = Soles.ToString("N2");

                CalcularDiferencia();                
            }
            else
            {
                lblMontoSoles.Text = "0.00";
                lblMontoDolares.Text = "0.00";
            }
        }

        void CalcularDiferencia()
        {
            Decimal.TryParse(lblMontoSoles.Text, out Decimal Soles);
            Decimal.TryParse(lblMontoDolares.Text, out Decimal Dolares);
            Decimal.TryParse(txtMontoAplicado.Text, out Decimal Aplicacion);

            if (txtMoneda.Tag.ToString() == "01")
            {
                if (Soles >= Aplicacion)
                {
                    if (Aplicacion > 0)
                    {
                        txtDiferencia.Text = (Soles - Aplicacion).ToString("N2"); 
                    }
                }
            }
            else
            {
                if (Dolares >= Aplicacion)
                {
                    if (Aplicacion > 0)
                    {
                        txtDiferencia.Text = (Dolares - Aplicacion).ToString("N2");
                    }
                }
            }
        }

        void EditarDetalle(DataGridViewCellEventArgs e, SolicitudProveedorRendicionDetE oDetalle)
        {
            try
            {
                if (!oDetalle.EsAutomatico)
                {
                    frmSolProvRendicionDetalle oFrm = new frmSolProvRendicionDetalle(oDetalle, Bloqueo, txtMoneda.Tag.ToString());

                    if (oFrm.ShowDialog() == DialogResult.OK)
                    {
                        SolicitudProveedorRendicionDetE oItemRendicion = Colecciones.CopiarEntidad<SolicitudProveedorRendicionDetE>(oFrm.oRendicionDetalle);
                        oItemRendicion.idProvision = null;
                        oItemRendicion.indProvBusqueda = false;
                        oItemRendicion.indLiquiImpor = false;
                        oItemRendicion.idLiquiImpor = null;

                        oRendicion.oListaRendiciones[e.RowIndex] = oItemRendicion;
                        bsDetalle.DataSource = oRendicion.oListaRendiciones;
                        bsDetalle.ResetBindings(false);
                        base.AgregarDetalle();
                        Calcular();
                    }
                }
                else
                {
                    frmProvisionLiquidacion oFrm = new frmProvisionLiquidacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, oDetalle.idProvision.Value, oDetalle.oProvision, Bloqueo, dtpFechaOpe.Value);

                    if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvisiones != null)
                    {
                        Int32 OpcionGrabar = 0;

                        if (oDetalle.Opcion != (Int32)EnumOpcionGrabar.Insertar)
                        {
                            OpcionGrabar = (Int32)EnumOpcionGrabar.Actualizar;
                        }
                        else
                        {
                            OpcionGrabar = (Int32)EnumOpcionGrabar.Insertar;
                        }

                        SolicitudProveedorRendicionDetE oRendicionDet = new SolicitudProveedorRendicionDetE()
                        {
                            idDocumento = oFrm.oProvisiones.idDocumento,
                            numSerie = oFrm.oProvisiones.NumSerie,
                            numDocumento = oFrm.oProvisiones.NumDocumento,
                            fecDocumento = oFrm.oProvisiones.FechaDocumento.Date,
                            idMoneda = oFrm.oProvisiones.CodMonedaProvision,
                            desMoneda = oFrm.oProvisiones.desMoneda,
                            MontoDoc = oFrm.oProvisiones.ImpMonedaOrigen,
                            idMonedaRec = oFrm.oProvisiones.CodMonedaProvision,
                            desMonedaRec = oFrm.oProvisiones.desMoneda,
                            MontoRec = oFrm.oProvisiones.ImpMonedaOrigen,
                            indTicaAuto = true,
                            tipCambio = oFrm.oProvisiones.TipCambio,
                            numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                            codCuenta = oFrm.oProvisiones.codCuenta,
                            idAuxiliar = oFrm.oProvisiones.idPersona,
                            idConcepto = null,
                            indReparable = oFrm.oProvisiones.indReparable,
                            idConceptoRep = oFrm.oProvisiones.idConceptoRep,
                            desReferenciaRep = oFrm.oProvisiones.desReferenciaRep,
                            EsAutomatico = true,
                            idProvision = oFrm.oProvisiones.idProvision,
                            indProvBusqueda = false,
                            indLiquiImpor = false,
                            idLiquiImpor = null,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy,
                            Opcion = OpcionGrabar,
                            OpcionGrabarProv = OpcionGrabar,
                            RazonSocial = oFrm.oProvisiones.RazonSocial,

                            oProvision = oFrm.oProvisiones
                        };

                        if (oRendicionDet.idMonedaRec == "01")
                        {
                            oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec;
                            oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec / oRendicionDet.tipCambio;
                        }
                        else
                        {
                            oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec;
                            oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec * oRendicionDet.tipCambio;
                        }

                        oRendicion.oListaRendiciones[e.RowIndex] = oRendicionDet;
                        bsDetalle.DataSource = oRendicion.oListaRendiciones;
                        bsDetalle.ResetBindings(false);
                        base.AgregarDetalle();
                        Calcular();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void DatosPorGrabar()
        {
            oRendicion.idSolicitud = Convert.ToInt32(txtCodSol.Tag);
            oRendicion.idDocumento = cboDocumento.SelectedValue.ToString();
            oRendicion.numDocumento = txtNumero.Text.Trim();
            oRendicion.fecOperacion = dtpFechaOpe.Value.Date;
            oRendicion.totSoles = Convert.ToDecimal(lblMontoSoles.Text);
            oRendicion.totDolares = Convert.ToDecimal(lblMontoDolares.Text);
            oRendicion.Glosa = txtGlosa.Text.Trim();
            oRendicion.indDeposito = chkDeposito.Checked;

            if (oRendicion.indDeposito)
            {
                oRendicion.idBancoDepo = (Int32)cboBancosEmpresa.SelectedValue == 0 ? (Int32?)null : (Int32)cboBancosEmpresa.SelectedValue;
                oRendicion.idDocumentoDepo = cboDocumDepositos.SelectedValue.ToString() == "0" ? String.Empty : cboDocumDepositos.SelectedValue.ToString();
                oRendicion.numSerieDepo = txtSerie.Text;
                oRendicion.numDocumentoDepo = txtNumDoc.Text;
                oRendicion.idMonedaDepo = cboMonedas.SelectedValue.ToString();
                oRendicion.ImporteDepo = Convert.ToDecimal(txtImporteDep.Text);
                oRendicion.fecDepo = dtpFechaDepo.Value.Date;
                oRendicion.GlosaDepo = txtGlosaDepo.Text.Trim();
            }
            else
            {
                oRendicion.idBancoDepo = (Int32?)null;
                oRendicion.idDocumentoDepo = String.Empty;
                oRendicion.numSerieDepo = String.Empty;
                oRendicion.numDocumentoDepo = String.Empty;
                oRendicion.idMonedaDepo = String.Empty;
                oRendicion.ImporteDepo = 0;
                oRendicion.fecDepo = null;
                oRendicion.GlosaDepo = String.Empty;
            }

            Decimal.TryParse(txtMontoAplicado.Text, out Decimal ImporteAplicado);
            oRendicion.MontoAplicado = ImporteAplicado;
            Decimal.TryParse(txtDiferencia.Text, out Decimal Diferencia);
            oRendicion.Diferencia = Diferencia;

            if (chkDeposito.Checked)
            {
                oRendicion.idComprobante = txtLibro.Text;
                oRendicion.numFile = txtFile.Text;
            }

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                oRendicion.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;
            }
            else
            {
                oRendicion.UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial;
            }
        }

        void LlenarCombos()
        {
            // Documentos
            List<DocumentosE> ListaDocumentos = new List<DocumentosE>(from x in VariablesLocales.ListarDocumentoGeneral
                                                                      where x.indBaja == false &&
                                                                      x.indTesoreria == true
                                                                      select x).ToList();
            ListaDocumentos.Add(new DocumentosE() { idDocumento = Variables.Cero.ToString(), desDocumento = Variables.Seleccione });
            ComboHelper.RellenarCombos<DocumentosE>(cboDocumento, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");

            // Bancos
            List<BancosE> oListaBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListaBancos.Add(new BancosE() { idPersona = Variables.Cero, RazonSocial = Variables.Todos });
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListaBancos orderby x.idPersona select x).ToList(), "idPersona", "RazonSocial");

            // Monedas
            List<MonedasE> ListaMoneda = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMonedas, (from x in ListaMoneda
                                                              where x.idMoneda == "01" || x.idMoneda == "02"
                                                              orderby x.idMoneda
                                                              select x).ToList(), "idMoneda", "desAbreviatura", false);

            ComboHelper.RellenarCombos<DocumentosE>(cboDocumDepositos, (from x in ListaDocumentos orderby x.idDocumento select x).ToList(), "idDocumento", "desDocumento");
        }

        void LlenarLibros()
        {
            comprobantes = new List<ComprobantesE>(VariablesLocales.oListaComprobantes);

            if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
            {
                ComprobantesE com = comprobantes.Find
                (
                    delegate (ComprobantesE c) { return c.Descripcion.ToUpper().Contains("INGRESOS"); }
                );

                if (com != null)
                {
                    txtLibro.Text = com.idComprobante;
                    txtDesLibro.Text = com.Descripcion;
                    LlenarFiles(com);
                    txtDesFile.Focus();
                }
            }
        }

        void LlenarFiles(ComprobantesE Libro)
        {
            if (Libro != null)
            {
                files = new List<ComprobantesFileE>(Libro.ListaComprobantesFiles);
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oRendicion != null)
            {
                txtMontoAplicado.TextChanged -= txtMontoAplicado_TextChanged;

                txtRuc.Tag = oRendicion.idProveedor;
                txtRuc.Text = oRendicion.RUC;
                txtRazonSocial.Text = oRendicion.RazonSocial;
                txtMoneda.Tag = oRendicion.idMonedaSol;
                txtMoneda.Text = oRendicion.desMoneda;
                txtMontoSol.Text = oRendicion.impSolicitud.ToString("N2");
                txtUtilizado.Text = oRendicion.MontoAplicado.ToString("N2");
                txtCodSol.Tag = oRendicion.idSolicitud;
                txtCodSol.Text = oRendicion.codSolicitud;

                txtCodRendicion.Tag = oRendicion.idRendicion;
                txtCodRendicion.Text = oRendicion.codRendicion;
                dtpFechaOpe.Value = oRendicion.fecOperacion.Date;
                txtMontoAplicado.Text = oRendicion.MontoAplicado.ToString("N2");
                txtDiferencia.Text = oRendicion.Diferencia.ToString("N2");
                cboDocumento.SelectedValue = !String.IsNullOrWhiteSpace(oRendicion.idDocumento) ? oRendicion.idDocumento.ToString() : "0";
                txtNumero.Text = oRendicion.numDocumento;
                txtLibro.Text = oRendicion.idComprobante;
                txtDesLibro.Text = oRendicion.desComprobante;
                txtFile.Text = oRendicion.numFile;
                txtDesFile.Text = oRendicion.desFile;
                txtVoucher.Text = oRendicion.numVoucher;
                txtGlosa.Text = oRendicion.Glosa;
                chkDeposito.Checked = oRendicion.indDeposito;

                if (chkDeposito.Checked)
                {
                    if (oRendicion.idBancoDepo > 0)
                    {
                        cboBancosEmpresa.SelectedValue = oRendicion.idBancoDepo.Value;
                    }

                    cboDocumDepositos.SelectedValue = !String.IsNullOrWhiteSpace(oRendicion.idDocumentoDepo) ? oRendicion.idDocumentoDepo.ToString() : "0";
                    txtSerie.Text = oRendicion.numSerieDepo;
                    txtNumDoc.Text = oRendicion.numDocumentoDepo;
                    cboMonedas.SelectedValue = !String.IsNullOrWhiteSpace(oRendicion.idMonedaDepo) ? oRendicion.idMonedaDepo.ToString() : "01";
                    txtImporteDep.Text = oRendicion.ImporteDepo.ToString();
                    dtpFechaDepo.Value = oRendicion.fecDepo.Value.Date;
                    txtGlosaDepo.Text = oRendicion.GlosaDepo;
                }

                txtUsuRegistra.Text = oRendicion.UsuarioRegistro;
                txtRegistro.Text = oRendicion.FechaRegistro.ToString();
                txtUsuModifica.Text = oRendicion.UsuarioModificacion;
                txtModifica.Text = oRendicion.FechaModificacion.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Actualizar;

                txtMontoAplicado.TextChanged += txtMontoAplicado_TextChanged;
            }
            else
            {
                oRendicion = new SolicitudProveedorRendicionE
                {
                    idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                    idLocal = VariablesLocales.SesionLocal.IdLocal
                };

                txtCodSol.Tag = 0;
                txtCodRendicion.Tag = 0;
                txtUsuRegistra.Text = VariablesLocales.SesionUsuario.Credencial;
                txtRegistro.Text = VariablesLocales.FechaHoy.ToString();
                txtUsuModifica.Text = VariablesLocales.SesionUsuario.Credencial;
                txtModifica.Text = VariablesLocales.FechaHoy.ToString();

                Opcion = (Int32)EnumOpcionGrabar.Insertar;
            }

            bsDetalle.DataSource = oRendicion.oListaRendiciones;
            bsDetalle.ResetBindings(false);
            Calcular();

            if (oRendicion.Estado)
            {
                Bloqueo = "S";
                btAgregarOtros.Enabled = false;
                btDocumentos.Enabled = false;
                btEliminarItem.Enabled = false;
                btBuscarSol.Enabled = false;
                pnlRendicion.Enabled = false;
                pnlDeposito.Enabled = false;
                txtGlosa.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                Global.MensajeComunicacion("No podrá hacer modificaciones ya se generó el asiento contable.");
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);
            }
            else
            {
                Bloqueo = "N";
                btAgregarOtros.Enabled = false;
                btDocumentos.Enabled = false;
                btEliminarItem.Enabled = false;
                btBuscarSol.Enabled = false;
                pnlRendicion.Enabled = false;
                pnlDeposito.Enabled = false;
                BloquearOpcion(EnumOpcionMenuBarra.Cerrar, true);

                base.Nuevo();
            }
        }

        public override void Grabar()
        {
            try
            {
                bsDetalle.EndEdit();
                DatosPorGrabar();

                if (oRendicion != null)
                {
                    if (Opcion == (Int32)EnumOpcionGrabar.Insertar)
                    {
                        if (Global.MensajeConfirmacion("Desea grabar las rendiciones?") == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.GrabarRendicion(oRendicion, EnumOpcionGrabar.Insertar);
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion("Desea actualizar las rendiciones?") == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.GrabarRendicion(oRendicion, EnumOpcionGrabar.Actualizar);
                        }
                    }

                    base.Grabar();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos para grabar o actualizar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void AgregarDetalle()
        {
            try
            {
                frmPendientesAuxiliares oFrm = new frmPendientesAuxiliares(Convert.ToInt32(txtRuc.Tag), txtRuc.Text.Trim(), txtRazonSocial.Text.Trim(), "N");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    SolicitudProveedorRendicionDetE oItemRendicion = null;
                    List<CtaCteE> oListaCtaCteTemp = new List<CtaCteE>(oFrm.oListaCtaCte);

                    if (bsDetalle.List.Count > Variables.Cero)
                    {
                        List<CtaCteE> oListaEliminacion = new List<CtaCteE>();

                        foreach (CtaCteE itemTemp in oListaCtaCteTemp)
                        {
                            foreach (SolicitudProveedorRendicionDetE itemReal in oRendicion.oListaRendiciones)
                            {
                                if (itemTemp.idDocumento == itemReal.idDocumento && itemTemp.numSerie == itemReal.numSerie && itemTemp.numDocumento == itemReal.numDocumento)
                                {
                                    Global.MensajeFault(String.Format("Este documento {0} {1}-{2} ya ha sido ingresado, intente ingresar otro o elimine el registro anterior para ingresarlo nuevamente.", itemTemp.idDocumento, itemTemp.numSerie, itemTemp.numDocumento));
                                    oListaEliminacion.Add(itemTemp);
                                }
                            }
                        }

                        if (oListaEliminacion.Count > Variables.Cero)
                        {
                            foreach (CtaCteE item in oListaEliminacion)
                            {
                                oListaCtaCteTemp.Remove(item);
                            }
                        }
                    }

                    if (oListaCtaCteTemp.Count > 0)
                    {
                        foreach (CtaCteE item in oListaCtaCteTemp)
                        {
                            oItemRendicion = new SolicitudProveedorRendicionDetE()
                            {
                                idDocumento = item.idDocumento,
                                numSerie = item.numSerie,
                                numDocumento = item.numDocumento,
                                fecDocumento = item.FechaDocumento.Date,
                                idMoneda = item.idMoneda,
                                desMoneda = item.desMoneda,
                                MontoDoc = item.Saldo,
                                idMonedaRec = item.idMoneda,
                                desMonedaRec = item.desMoneda,
                                MontoRec = item.Saldo,
                                indTicaAuto = true,
                                tipCambio = VariablesLocales.MontoTicaConta(item.FechaDocumento, item.idMoneda),
                                numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                                codCuenta = item.codCuenta,
                                idAuxiliar = item.idPersona,
                                idConcepto = null,
                                EsAutomatico = true,
                                UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                                FechaRegistro = VariablesLocales.FechaHoy,
                                UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                                FechaModificacion = VariablesLocales.FechaHoy,
                                Opcion = (Int32)EnumOpcionGrabar.Insertar,
                                RazonSocial = item.RazonSocial
                            };

                            if (oItemRendicion.idMonedaRec == "01")
                            {
                                oItemRendicion.SolesRecibidos = oItemRendicion.MontoRec;
                                oItemRendicion.DolaresRecibidos = oItemRendicion.MontoRec / oItemRendicion.tipCambio;
                            }
                            else
                            {
                                oItemRendicion.DolaresRecibidos = oItemRendicion.MontoRec;
                                oItemRendicion.SolesRecibidos = oItemRendicion.MontoRec * oItemRendicion.tipCambio;

                            }

                            oRendicion.oListaRendiciones.Add(oItemRendicion);
                        }

                        bsDetalle.DataSource = oRendicion.oListaRendiciones;
                        bsDetalle.ResetBindings(false);
                    }

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void QuitarDetalle()
        {
            try
            {
                if (Global.MensajeConfirmacion("Desea eliminar la fila") == DialogResult.Yes)
                {
                    if (oRendicion.oListaRendicionesDel == null)
                    {
                        oRendicion.oListaRendicionesDel = new List<SolicitudProveedorRendicionDetE>();
                    }

                    //Lista de Eliminados
                    oRendicion.oListaRendicionesDel.Add((SolicitudProveedorRendicionDetE)bsDetalle.Current);
                    //Actualizando la lista
                    oRendicion.oListaRendiciones.Remove((SolicitudProveedorRendicionDetE)bsDetalle.Current);
                    bsDetalle.DataSource = oRendicion.oListaRendiciones;
                    bsDetalle.ResetBindings(false);

                    base.QuitarDetalle();
                    Calcular();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override bool ValidarGrabacion()
        {
            if (Convert.ToInt32(txtCodSol.Tag) == 0)
            {
                Global.MensajeAdvertencia("Debe escoger una solicitud");
                return false;
            }

            Decimal.TryParse(txtMontoAplicado.Text, out Decimal Aplicacion);

            if (Aplicacion > Convert.ToDecimal(txtUtilizado.Text))
            {
                Global.MensajeAdvertencia("El monto por aplicar no puede ser mayor al monto del anticipo.");
                return false;
            }

            if (oRendicion.idDocumento == "0")
            {
                Global.MensajeAdvertencia("Debe escoger un tipo de documento de depósito.");
                return false;
            }

            if (oRendicion.ImporteDepo == 0)
            {
                Global.MensajeAdvertencia("Debe ingresar un monto de depósito.");
                return false;
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos de Usuario

        private void lblListaTmp_DoubleClick(object sender, EventArgs e)
        {
            //txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
            //txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
            //txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

            ListBox lb1 = (ListBox)sender;

            txtLibro.Text = lb1.SelectedValue.ToString();
            txtDesLibro.Text = ((ComprobantesE)lb1.SelectedItem).Descripcion;
            LlenarFiles((ComprobantesE)lb1.SelectedItem);
            lb1.Visible = false;
            lb1.Dispose();
            txtDesFile.Focus();

            //txtIdCostos.TextChanged += txtIdCostos_TextChanged;
            //txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
            //txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
        }

        private void lblListaTmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                //txtCodConcepto.TextChanged -= txtCodConcepto_TextChanged;
                //txtIdCostos.TextChanged -= txtIdCostos_TextChanged;
                //txtDesConcepto.TextChanged -= txtDesConcepto_TextChanged;

                ListBox lb1 = (ListBox)sender;

                txtLibro.Text = lb1.SelectedValue.ToString();
                txtDesLibro.Text = ((ComprobantesE)lb1.SelectedItem).Descripcion;
                LlenarFiles((ComprobantesE)lb1.SelectedItem);
                lb1.Visible = false;
                lb1.Dispose();
                txtDesFile.Focus();

                //txtIdCostos.TextChanged += txtIdCostos_TextChanged;
                //txtCodConcepto.TextChanged += txtCodConcepto_TextChanged;
                //txtDesConcepto.TextChanged += txtDesConcepto_TextChanged;
            }
        }

        private void lblListaFile_DoubleClick(object sender, EventArgs e)
        {
            ListBox lb2 = (ListBox)sender;

            txtFile.Text = lb2.SelectedValue.ToString();
            txtDesFile.Text = ((ComprobantesFileE)lb2.SelectedItem).Descripcion;
            lb2.Visible = false;
            lb2.Dispose();
            txtMontoAplicado.Focus();
        }

        private void lblListaFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ListBox lb2 = (ListBox)sender;

                txtFile.Text = lb2.SelectedValue.ToString();
                txtDesFile.Text = ((ComprobantesFileE)lb2.SelectedItem).Descripcion;
                lb2.Visible = false;
                lb2.Dispose();
                txtMontoAplicado.Focus();
            }
        }

        #endregion

        #region Eventos

        private void frmSolicitudProvRendicion_Load(object sender, EventArgs e)
        {
            try
            {
                Grid = false;
                Nuevo();
                BloquearOpcion(EnumOpcionMenuBarra.AgregarDetalle, false);
                BloquearOpcion(EnumOpcionMenuBarra.QuitarDetalle, false);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bsDetalle.Count > 0)
                {
                    if (bsDetalle.Current is SolicitudProveedorRendicionDetE current)
                    {
                        if (!current.indProvBusqueda && !current.indLiquiImpor)
                        {
                            EditarDetalle(e, Colecciones.CopiarEntidad<SolicitudProveedorRendicionDetE>((SolicitudProveedorRendicionDetE)bsDetalle.Current)); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvDetalle_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // Captura el numero de filas del datagridview
                String numFila = (e.RowIndex + 1).ToString();

                Font oFont = new Font("Tahoma", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Italic, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                SizeF size = e.Graphics.MeasureString(numFila, oFont);

                if (dgvDetalle.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                {
                    dgvDetalle.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                }

                Brush ob = Brushes.Navy;
                e.Graphics.DrawString(numFila, oFont, ob, (e.RowBounds.Location.X + 15), (e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsDetalle_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblDetalle.Text = String.Format("Registros {0}", bsDetalle.Count.ToString());
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAgregarOtros_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtCodSol.Text.Trim()))
                {
                    Global.MensajeAdvertencia("Tiene que ingresar una Solicitud de Anticipo.");
                    btBuscarSol.Focus();
                    return;
                }

                frmSolProvRendicionDetalle oFrm = new frmSolProvRendicionDetalle(txtMoneda.Tag.ToString());

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oRendicionDetalle != null)
                {
                    SolicitudProveedorRendicionDetE oItemRendicion = Colecciones.CopiarEntidad<SolicitudProveedorRendicionDetE>(oFrm.oRendicionDetalle);
                    oItemRendicion.idProvision = null;
                    oItemRendicion.indProvBusqueda = false;
                    oItemRendicion.indLiquiImpor = false;
                    oItemRendicion.idLiquiImpor = null;
                    oRendicion.oListaRendiciones.Add(oItemRendicion);
                    bsDetalle.DataSource = oRendicion.oListaRendiciones;
                    bsDetalle.ResetBindings(false);

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btDocumentos_Click(object sender, EventArgs e)
        {
            try
            {
                cmsOpciones.Show(btDocumentos, new Point(0, btDocumentos.Height));
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarDetalle();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btBuscarSol_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarSolicitudAnticipos oFrm = new frmBuscarSolicitudAnticipos();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oSolicitudAnticipo != null)
                {
                    txtRuc.Tag = oFrm.oSolicitudAnticipo.idProveedor;
                    txtRuc.Text = oFrm.oSolicitudAnticipo.RUC;
                    txtRazonSocial.Text = oFrm.oSolicitudAnticipo.RazonSocial;
                    txtMoneda.Tag = oFrm.oSolicitudAnticipo.idMoneda;
                    txtMoneda.Text = oFrm.oSolicitudAnticipo.desMoneda;
                    txtMontoSol.Text = oFrm.oSolicitudAnticipo.impTotal.ToString("N2");
                    txtUtilizado.Text = oFrm.oSolicitudAnticipo.Saldo.ToString("N2");
                    txtMontoAplicado.Text = oFrm.oSolicitudAnticipo.Saldo.ToString("N2");
                    txtCodSol.Tag = oFrm.oSolicitudAnticipo.idSolicitud;
                    txtCodSol.Text = oFrm.oSolicitudAnticipo.codSolicitud;
                    txtGlosa.Text = oFrm.oSolicitudAnticipo.Descripcion;

                    oRendicion.impSolicitud = oFrm.oSolicitudAnticipo.impTotal;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMontoAplicado_TextChanged(object sender, EventArgs e)
        {
            CalcularDiferencia();
        }

        private void txtMontoAplicado_Leave(object sender, EventArgs e)
        {
            txtMontoAplicado.Text = Global.FormatoDecimal(txtMontoAplicado.Text);
        }

        private void chkDeposito_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboBancosEmpresa.Enabled = chkDeposito.Checked;
                cboDocumDepositos.Enabled = chkDeposito.Checked;
                cboMonedas.Enabled = chkDeposito.Checked;
                dtpFechaDepo.Enabled = chkDeposito.Checked;

                if (chkDeposito.Checked)
                {
                    //txtDesLibro.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    //txtDesFile.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    //LlenarLibros();
                    //btDocumentos.Enabled = false;
                    //btAgregarOtros.Enabled = false;
                    //btEliminarItem.Enabled = false;
                    txtImporteDep.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtNumDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                    txtGlosaDepo.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                }
                else
                {
                    txtImporteDep.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtImporteDep.Text = "0.00";
                    txtSerie.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    txtNumDoc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    cboBancosEmpresa.SelectedValue = 0;
                    cboDocumDepositos.SelectedValue = "0";
                    txtGlosaDepo.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    //comprobantes = null;
                    //files = null;
                    //txtLibro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    //txtDesLibro.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    //txtFile.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    //txtDesFile.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, "S");
                    //btDocumentos.Enabled = true;
                    //btAgregarOtros.Enabled = true;
                    //btEliminarItem.Enabled = true;

                    //if (lblListaTmp != null)
                    //{
                    //    lblListaTmp.Visible = false;
                    //    lblListaTmp.Dispose();
                    //}

                    //if (lblListaFile != null)
                    //{
                    //    lblListaFile.Visible = false;
                    //    lblListaFile.Dispose(); 
                    //}
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtDesLibro_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (String.IsNullOrWhiteSpace(txtDesLibro.Text) && chkDeposito.Checked)
            //    {
            //        if (comprobantes != null && comprobantes.Count > 0)
            //        {
            //            lblListaTmp = new ListBox()
            //            {
            //                FormattingEnabled = true,
            //                Location = new Point(txtDesLibro.Location.X, txtDesLibro.Location.Y + txtDesLibro.Height + 1),
            //                Size = new Size(181, 45),
            //                TabIndex = 0
            //            };

            //            lblListaTmp.Focus();
            //            scContenedor.Panel2.Controls.Add(lblListaTmp);
            //            lblListaTmp.BringToFront();

            //            lblListaTmp.DataSource = comprobantes;
            //            lblListaTmp.DisplayMember = "Descripcion";
            //            lblListaTmp.ValueMember = "idComprobante";

            //            lblListaTmp.Focus();
            //            lblListaTmp.DoubleClick += new EventHandler(lblListaTmp_DoubleClick);
            //            lblListaTmp.KeyDown += new KeyEventHandler(lblListaTmp_KeyDown);

            //            txtFile.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
            //            txtDesFile.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear, "S");
            //        } 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void txtDesFile_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (!String.IsNullOrWhiteSpace(txtDesLibro.Text) && String.IsNullOrWhiteSpace(txtDesFile.Text) && chkDeposito.Checked)
            //    {
            //        if (files != null && files.Count > 0)
            //        {
            //            lblListaFile = new ListBox()
            //            {
            //                FormattingEnabled = true,
            //                Location = new Point(txtDesFile.Location.X, txtDesFile.Location.Y + txtDesFile.Height + 1),
            //                Size = new Size(181, 45),
            //                TabIndex = 0
            //            };

            //            lblListaFile.Focus();
            //            scContenedor.Panel2.Controls.Add(lblListaFile);
            //            lblListaFile.BringToFront();

            //            lblListaFile.DataSource = files;
            //            lblListaFile.DisplayMember = "Descripcion";
            //            lblListaFile.ValueMember = "numFile";

            //            lblListaFile.Focus();
            //            lblListaFile.DoubleClick += new EventHandler(lblListaFile_DoubleClick);
            //            lblListaFile.KeyDown += new KeyEventHandler(lblListaFile_KeyDown);
            //        } 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void tsmCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtCodSol.Text.Trim()))
                {
                    Global.MensajeAdvertencia("Tiene que ingresar una Solicitud de Anticipo.");
                    btBuscarSol.Focus();
                    return;
                }

                Int32 idProvision = 0;
                frmProvisionLiquidacion oFrm = new frmProvisionLiquidacion(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idProvision, null, Bloqueo, dtpFechaOpe.Value.Date);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvisiones != null)
                {
                    SolicitudProveedorRendicionDetE oRendicionDet = new SolicitudProveedorRendicionDetE()
                    {
                        idDocumento = oFrm.oProvisiones.idDocumento,
                        numSerie = oFrm.oProvisiones.NumSerie,
                        numDocumento = oFrm.oProvisiones.NumDocumento,
                        fecDocumento = oFrm.oProvisiones.FechaDocumento.Date,
                        idMoneda = oFrm.oProvisiones.CodMonedaProvision,
                        desMoneda = oFrm.oProvisiones.desMoneda,
                        MontoDoc = oFrm.oProvisiones.ImpMonedaOrigen,
                        idMonedaRec = oFrm.oProvisiones.CodMonedaProvision,
                        desMonedaRec = oFrm.oProvisiones.desMoneda,
                        MontoRec = oFrm.oProvisiones.ImpMonedaOrigen,
                        indTicaAuto = true,
                        tipCambio = oFrm.oProvisiones.TipCambio,
                        numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                        codCuenta = oFrm.oProvisiones.codCuenta,
                        idAuxiliar = oFrm.oProvisiones.idPersona,
                        idConcepto = null,
                        indReparable = oFrm.oProvisiones.indReparable,
                        idConceptoRep = oFrm.oProvisiones.idConceptoRep,
                        desReferenciaRep = oFrm.oProvisiones.desReferenciaRep,
                        EsAutomatico = true,
                        idProvision = oFrm.oProvisiones.idProvision,
                        indProvBusqueda = false,
                        indLiquiImpor = false,
                        idLiquiImpor = null,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy,

                        Opcion = (Int32)EnumOpcionGrabar.Insertar,
                        OpcionGrabarProv = (Int32)EnumOpcionGrabar.Insertar,
                        RazonSocial = oFrm.oProvisiones.RazonSocial,
                        oProvision = oFrm.oProvisiones
                    };

                    if (oRendicionDet.idMonedaRec == "01")
                    {
                        oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec;
                        oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec / oRendicionDet.tipCambio;
                    }
                    else
                    {
                        oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec;
                        oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec * oRendicionDet.tipCambio;
                    }

                    oRendicion.oListaRendiciones.Add(oRendicionDet);
                    bsDetalle.DataSource = oRendicion.oListaRendiciones;
                    bsDetalle.ResetBindings(false);

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void tsmBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarProvisiones oFrm = new frmBuscarProvisiones("Normal");

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oProvision != null)
                {
                    if (oRendicion.oListaRendiciones.Count > 0)
                    {
                        foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                        {
                            if (item.indProvBusqueda && item.idProvision == oFrm.oProvision.idProvision)
                            {
                                Global.MensajeAdvertencia("La provisión ya se encuentra, elimine primero o escoja otro.");
                                return;
                            }
                        }
                    }

                    SolicitudProveedorRendicionDetE oRendicionDet = new SolicitudProveedorRendicionDetE()
                    {
                        idDocumento = oFrm.oProvision.idDocumento,
                        numSerie = oFrm.oProvision.NumSerie,
                        numDocumento = oFrm.oProvision.NumDocumento,
                        fecDocumento = oFrm.oProvision.FechaDocumento.Date,
                        idMoneda = oFrm.oProvision.CodMonedaProvision,
                        desMoneda = oFrm.oProvision.desMoneda,
                        MontoDoc = oFrm.oProvision.ImpMonedaOrigen,
                        idMonedaRec = oFrm.oProvision.CodMonedaProvision,
                        desMonedaRec = oFrm.oProvision.desMoneda,
                        MontoRec = oFrm.oProvision.ImpMonedaOrigen,
                        indTicaAuto = true,
                        tipCambio = oFrm.oProvision.TipCambio,
                        numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                        codCuenta = oFrm.oProvision.codCuenta,
                        idAuxiliar = oFrm.oProvision.idPersona,
                        idConcepto = null,
                        indReparable = oFrm.oProvision.indReparable,
                        idConceptoRep = oFrm.oProvision.idConceptoRep,
                        desReferenciaRep = oFrm.oProvision.desReferenciaRep,
                        EsAutomatico = true,
                        idProvision = oFrm.oProvision.idProvision,
                        indProvBusqueda = true,
                        indLiquiImpor = false,
                        idLiquiImpor = null,
                        UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                        FechaRegistro = VariablesLocales.FechaHoy,
                        UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                        FechaModificacion = VariablesLocales.FechaHoy,
                        Opcion = (Int32)EnumOpcionGrabar.Insertar,
                        RazonSocial = oFrm.oProvision.RazonSocial,

                        oProvision = null
                    };

                    if (oRendicionDet.idMonedaRec == "01")
                    {
                        oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec;
                        oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec / oRendicionDet.tipCambio;
                    }
                    else
                    {
                        oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec;
                        oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec * oRendicionDet.tipCambio;
                    }

                    oRendicion.oListaRendiciones.Add(oRendicionDet);
                    bsDetalle.DataSource = oRendicion.oListaRendiciones;
                    bsDetalle.ResetBindings(false);

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImportacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtCodSol.Text.Trim()))
                {
                    Global.MensajeAdvertencia("Tiene que ingresar una Solicitud de Anticipo.");
                    btBuscarSol.Focus();
                    return;
                }

                frmPendientesLiquidacionImportacion oFrm = new frmPendientesLiquidacionImportacion(Convert.ToInt32(txtRuc.Tag), txtRuc.Text.Trim(), txtRazonSocial.Text.Trim());

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte != null && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    foreach (CtaCteE item in oFrm.oListaCtaCte)
                    {
                        SolicitudProveedorRendicionDetE oRendicionDet = new SolicitudProveedorRendicionDetE()
                        {
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            fecDocumento = item.FechaDocumento.Date,
                            idMoneda = item.idMoneda,
                            desMoneda = item.desMoneda,
                            MontoDoc = item.Saldo,
                            idMonedaRec = item.idMoneda,
                            desMonedaRec = item.desMoneda,
                            MontoRec = item.Saldo,
                            indTicaAuto = true,
                            tipCambio = item.TipoCambio,
                            numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            idAuxiliar = item.idPersona,
                            idConcepto = null,
                            indReparable = "N",
                            idConceptoRep = 0,
                            desReferenciaRep = String.Empty,
                            EsAutomatico = true,
                            idProvision = null,
                            indProvBusqueda = false,
                            indLiquiImpor = true,
                            idLiquiImpor = item.idLiquidacionImportacion,
                            UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial,
                            FechaRegistro = VariablesLocales.FechaHoy,
                            UsuarioModificacion = VariablesLocales.SesionUsuario.Credencial,
                            FechaModificacion = VariablesLocales.FechaHoy,

                            Opcion = (Int32)EnumOpcionGrabar.Insertar,
                            OpcionGrabarProv = (Int32)EnumOpcionGrabar.Insertar,
                            RazonSocial = item.RazonSocial
                        };

                        if (oRendicionDet.idMonedaRec == "01")
                        {
                            oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec;
                            oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec / oRendicionDet.tipCambio;
                        }
                        else
                        {
                            oRendicionDet.DolaresRecibidos = oRendicionDet.MontoRec;
                            oRendicionDet.SolesRecibidos = oRendicionDet.MontoRec * oRendicionDet.tipCambio;
                        }

                        oRendicion.oListaRendiciones.Add(oRendicionDet); 
                    }

                    bsDetalle.DataSource = oRendicion.oListaRendiciones;
                    bsDetalle.ResetBindings(false);

                    Calcular();
                    base.AgregarDetalle();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        private void txtDesLibro_Leave(object sender, EventArgs e)
        {
            //if (lblListaTmp != null)
            //{
            //    lblListaTmp.Visible = false;
            //    lblListaTmp.Dispose();
            //}
        }

        private void txtDesFile_Leave(object sender, EventArgs e)
        {
            //if (lblListaFile != null)
            //{
            //    lblListaFile.Visible = false;
            //    lblListaFile.Dispose();
            //}
        }

    }
}
