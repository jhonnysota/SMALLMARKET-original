using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using ClienteWinForm.Contabilidad.Reportes;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmListarProgramaPago : FrmMantenimientoBase
    {

        public frmListarProgramaPago()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            Location = new Point(0, 0);
            Size = new Size(VariablesLocales.AnchoMdi - 25, VariablesLocales.AltoMdi - 135);
            FormatoGrid(dgvPagos, true, false, 35);
            FormatoGrid(dgvEgresos, true, false, 35);
            LlenarCombos();
        }

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestros { get { return new MaestrosServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        List<VoucherItemE> oListaVoucherDetalle = new List<VoucherItemE>();
        Int32 TotalChecks = Variables.Cero;
        Int32 TotalCheckeados = Variables.Cero;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;
        String VieneDe = String.Empty;
        ProgramaPagoE oPrograma = new ProgramaPagoE();
        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvPagos.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["FlagEscoger"]).Value = HCheckBox.Checked;
            }

            dgvPagos.RefreshEdit();
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void AñadirCheckBox()
        {
            CheckBoxCab = new CheckBox();
            CheckBoxCab.Size = new Size(15, 15);

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvPagos.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvPagos.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1;

            //Cambiar la ubicacion del checkbox para que se quede en la cabecera
            CheckBoxCab.Location = oPoint;
        }

        private void FilaCheBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modificando el contador de los check
                if ((bool)RCheckBox.Value && TotalCheckeados < TotalChecks)
                {
                    TotalCheckeados++;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                }

                //Cambiar estado de la casilla de la cabecera si es que se llenan todas las filas o viceversa.
                if (TotalCheckeados < TotalChecks)
                {
                    CheckBoxCab.Checked = false;
                }
                else if (TotalCheckeados == TotalChecks)
                {
                    CheckBoxCab.Checked = true;
                }
            }
        }

        #endregion

        #region Procedimientos de Usuario

        void CalcularTotales(List<ProgramaPagoE> ListaPagos)
        {
            Decimal TotalCargoS = ListaPagos.Sum(x => x.CargoSoles);
            Decimal TotalAbonoS = ListaPagos.Sum(x => x.AbonoSoles);
            Decimal TotalCargoD = ListaPagos.Sum(x => x.CargoDolares);
            Decimal TotalAbonoD = ListaPagos.Sum(x => x.AbonoDolares);
            Decimal SaldoSoles = TotalCargoS - TotalAbonoS;
            Decimal SaldoDolares = TotalCargoD - TotalAbonoD;

            lblCargoS.Text = TotalCargoS.ToString("N2");
            lblAbonoS.Text = TotalAbonoS.ToString("N2");
            lblCargoD.Text = TotalCargoD.ToString("N2");
            lblAbonoD.Text = TotalAbonoD.ToString("N2");
            lblSaldoS.Text = SaldoSoles.ToString("N2");
            lblSaldoD.Text = SaldoDolares.ToString("N2");
        }

        void LlenarCombos()
        {
            List<FormaPagoE> ListaFormaPago = AgenteTesoreria.Proxy.ListarFormaPago();
            ListaFormaPago.Add(new FormaPagoE() { codFormaPago = Variables.Cero.ToString(), desFormaPago = Variables.Seleccione });
            ComboHelper.RellenarCombos<FormaPagoE>(cboFormas, (from x in ListaFormaPago orderby x.codFormaPago select x).ToList(), "codFormaPago", "desFormaPago");

            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            oListarBancos.Add(new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Seleccione });
            ComboHelper.RellenarCombos(cboBancos, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");
            ComboHelper.RellenarCombos(cboBancosEmpresa, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");

            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");

            ListaFormaPago = null;
            oListarBancos = null;
            oListaMonedas = null;
        }

        List<ProgramaPagoE> oListaPagosEscogidos()
        {
            List<ProgramaPagoE> oLista = new List<ProgramaPagoE>();

            foreach (ProgramaPagoE item in bsProgramaPago.List)
            {
                if (item.FlagEscoger)
                {
                    oLista.Add(item);
                }
            }

            return oLista;
        }

        void LlenarCuentasBancarias(Int32 idBanco, String idMoneda)
        {
            List<BancosCuentasE> oListaCuentas = AgenteMaestro.Proxy.ListarCuentasPorBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa,
                                                                                                    VariablesLocales.SesionLocal.IdLocal, idBanco, idMoneda);
            BancosCuentasE Ini = new BancosCuentasE() { idPersona = Variables.Cero, numCuenta = Variables.Seleccione };
            oListaCuentas.Add(Ini);
            ComboHelper.RellenarCombos<BancosCuentasE>(cboCuentas, (from x in oListaCuentas orderby x.idPersona select x).ToList(), "numCuenta", "numCuenta");

            if (oListaCuentas.Count == 2)
            {
                cboCuentas.SelectedIndex = 1;
            }

            oListaCuentas = null;
        }

        #endregion

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                if (cboEstados.SelectedIndex == 0 || cboEstados.SelectedIndex == 1)
                {
                    bsEgresos.DataSource = null;
                    String Estado = String.Empty;
                    String codFormaPago = cboFormas.SelectedValue.ToString();
                    Int32 idPer = Convert.ToInt32(txtRuc.Tag);

                    if (cboEstados.SelectedIndex == Variables.Cero)
                    {
                        Estado = "P";
                    }
                    else
                    {
                        Estado = "C";
                    }

                    if (codFormaPago == "0")
                    {
                        codFormaPago = "%";
                    }

                    List<ProgramaPagoE> oListaProgramaPago = new List<ProgramaPagoE>();
                    List<ProgramaPagoE> oListaDevuelta = AgenteTesoreria.Proxy.ListarProgramaPagos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, dtpFecIni.Value.Date, dtpFecFin.Value.Date, Estado, codFormaPago, Convert.ToInt32(cboBancos.SelectedValue), idPer);
                   
                    oListaProgramaPago.AddRange((from x in oListaDevuelta
                                                where x.codOrdenPago.Contains(txtNroOp.Text.Trim())
                                                select x).ToList());

                    bsProgramaPago.DataSource = oListaProgramaPago;

                    if (bsProgramaPago.Count > Variables.Cero)
                    {
                        dgvPagos.ContextMenuStrip = cmsPopup;
                    }
                    else
                    {
                        dgvPagos.ContextMenuStrip = null;
                    }

                    CalcularTotales((List<ProgramaPagoE>)bsProgramaPago.List);

                    CheckBoxCab.Checked = false;
                    HeaderCheckBoxClick(CheckBoxCab);

                    TotalChecks = dgvPagos.RowCount;
                    TotalCheckeados = 0; 
                }
                else
                {
                    bsProgramaPago.DataSource = null;
                    bsEgresos.DataSource = AgenteTesoreria.Proxy.ListarEgresosProgramaPago(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboBancos.SelectedValue), dtpFecIni.Value.Date, dtpFecFin.Value.Date);
                    dgvEgresos.GrupoColumnas = new String[] { "razonSocialDataGridViewTextBoxColumn" };

                    lblCargoS.Text = "0.00";
                    lblAbonoS.Text = "0.00";
                    lblCargoD.Text = "0.00";
                    lblAbonoD.Text = "0.00";
                    lblSaldoS.Text = "0.00";
                    lblSaldoD.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        public override void Editar()
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProgramaPago);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }

                ProgramaPagoE oItem = (ProgramaPagoE)bsProgramaPago.Current;

                if (oItem != null)
                {
                    oFrm = new frmProgramaPago(oItem)
                    {
                        MdiParent = MdiParent
                    };

                    oFrm.FormClosing += new FormClosingEventHandler(oFrm_FormClosing);
                    oFrm.Show();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Anular()
        {
            try
            {
                // Verificando si ahi varios Seleccionados para borrar
                List<ProgramaPagoE> oListaProgramaPago = null;
 
                if (TotalCheckeados > 0)
                {
                    oListaProgramaPago = new List<ProgramaPagoE>();

                    foreach (ProgramaPagoE item in bsProgramaPago.List)
                    {
                        if (item.FlagEscoger)
                        {
                            oListaProgramaPago.Add(item);
                        }
                    }
                }

                if (bsProgramaPago.Count > Variables.Cero)
                {
                    if (((ProgramaPagoE)bsProgramaPago.Current).Estado == "C")
                    {
                        Global.MensajeComunicacion("Este documento ya se encuentra cancelado. No puede ser eliminado.");
                        return;
                    }

                    if (oListaProgramaPago == null || oListaProgramaPago.Count == 0)
                    {
                        if (Global.MensajeConfirmacion(Mensajes.AvisoEliminacion) == DialogResult.Yes)
                        {
                            AgenteTesoreria.Proxy.EliminarProgramaPago(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, ((ProgramaPagoE)bsProgramaPago.Current).idLocal,
                                                         ((ProgramaPagoE)bsProgramaPago.Current).idProgramaPago, VariablesLocales.SesionUsuario.Credencial);

                            Buscar();
                            Global.MensajeComunicacion(Mensajes.EliminacionCorrecta);
                            base.Anular();
                        }
                    }
                    else
                    {
                        if (Global.MensajeConfirmacion(String.Format("Eliminar masivamente los {0} registros del Programa de Pagos escogidos", oListaProgramaPago.Count())) == DialogResult.Yes)
                        {
                            String Auto = "ok";

                            if (Auto == "ok")
                            {
                                Int32 resp = AgenteTesoreria.Proxy.EliminarProgramaPagoMasivo(oListaProgramaPago, VariablesLocales.SesionUsuario.Credencial);

                                if (resp > 0)
                                {
                                    Buscar();
                                    Global.MensajeComunicacion("Los Programa(s) Pago(s) se eliminaron correctamente.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void oFrm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            frmProgramaPago oFrm = sender as frmProgramaPago;

            if (oFrm.DialogResult == DialogResult.OK)
            {
                Buscar();
            }
        }

        #endregion

        #region Eventos

        private void frmListarProgramaPago_Load(object sender, EventArgs e)
        {
            Grid = true;
            base.Grabar();
            dtpFecIni.Value = Convert.ToDateTime(FechasHelper.ObtenerPrimerdia());
            txtRuc.Tag = 0;

            BloquearOpcion(EnumOpcionMenuBarra.Nuevo, false);
            
            AñadirCheckBox();

            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);

            cboEstados.SelectedIndex = 0;
            cboEstados_SelectionChangeCommitted(new Object(), new EventArgs());
        }

        private void btAgregarPendiente_Click(object sender, EventArgs e)
        {
            try
            {
                frmPendientesAuxiliares oFrm = new frmPendientesAuxiliares();

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaCtaCte.Count > Variables.Cero)
                {
                    ProgramaPagoE oItemPago = null;
                    List<ProgramaPagoE> oListaPagos = new List<ProgramaPagoE>();
                    List<CtaCteE> oListaTemp = new List<CtaCteE>(oFrm.oListaCtaCte);
                    DateTime Fecha = dtpFecIni.Value.Date;

                    if (bsProgramaPago.List.Count > Variables.Cero)
                    {
                        List<CtaCteE> oListaEliminacion = new List<CtaCteE>();

                        foreach (CtaCteE item1 in oListaTemp)
                        {
                            foreach (ProgramaPagoE item2 in bsProgramaPago.List)
                            {
                                if (item1.idDocumento == item2.idDocumento && item1.numSerie == item2.serDocumento && item1.numDocumento == item2.numDocumento)
                                {
                                    Global.MensajeFault(String.Format("Este documento {0} {1}-{2} ya ha sido ingresado, intente ingresar otro o elimine el registro anterior para ingresarlo nuevamente.", item1.idDocumento, item1.numSerie, item1.numDocumento));
                                    oListaEliminacion.Add(item1);
                                }
                            }
                        }

                        if (oListaEliminacion.Count > Variables.Cero)
                        {
                            foreach (CtaCteE item in oListaEliminacion)
                            {
                                oListaTemp.Remove(item);
                            }
                        }
                    }

                    if (oListaTemp.Count > Variables.Cero)
                    {
                        String DebeHaber = Variables.Debe;
                        //Int32 MaximoGrupo = AgenteTesoreria.Proxy.MaxGrupoProgramaPagos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPersona, Fecha);
                        //MaximoGrupo++;

                        foreach (CtaCteE item in oListaTemp)
                        {
                            oItemPago = new ProgramaPagoE();

                            if (item.idDocumento == "NC" || item.idDocumento.ToString() == "ND" || item.idDocumento == "CR" || item.idDocumento == "DR")
                            {
                                DebeHaber = Variables.Haber;
                            }

                            oItemPago.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                            oItemPago.idLocal = VariablesLocales.SesionLocal.IdLocal;
                            oItemPago.Fecha = dtpFecPago.Value.Date;
                            oItemPago.numVerPlanCuentas = VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas;
                            oItemPago.codCuenta = item.codCuenta;
                            oItemPago.idPersona = Convert.ToInt32(item.idPersona);
                            oItemPago.idDocumento = item.idDocumento;
                            oItemPago.serDocumento = item.numSerie;
                            oItemPago.numDocumento = item.numDocumento;
                            oItemPago.idMoneda = item.idMoneda;
                            oItemPago.fecDocumento = item.FechaDocumento;
                            oItemPago.fecVencimiento = item.FechaVencimiento;

                            oItemPago.codTipoPago = "001";
                            oItemPago.idConcepto = 0;
                            oItemPago.codFormaPago = "0";                            

                            oItemPago.idPersonaBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);
                            oItemPago.idMonedaPago = cboMoneda.SelectedValue.ToString();
                            oItemPago.idMonedaAuxiliar = cboMoneda.SelectedValue.ToString();
                            oItemPago.numCuenta = cboCuentas.SelectedValue.ToString();
                            oItemPago.numCheque = String.Empty;
                            oItemPago.numCtaAuxiliar = String.Empty;

                            oItemPago.Grupo = "0"; // MaximoGrupo.ToString();
                            oItemPago.Glosa = String.Empty;
                            
                            oItemPago.TipoCambio = 1;
                            
                            oItemPago.indDebeHaber = DebeHaber;
                            oItemPago.Monto = item.Saldo;
                            oItemPago.MontoOrigen = item.Saldo;
                            oItemPago.idNumEgreso = Variables.Cero;
                            oItemPago.desBeneficiario = item.RazonSocial;
                            oItemPago.idComprobante = "05";
                            oItemPago.numFile = "01";
                            oItemPago.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                            if (item.idDocumento == "LC")
                            {
                                //MaximoGrupo++;
                            }

                            oListaPagos.Add(oItemPago);
                        }

                        if (oListaPagos.Count > 0)
                        {
                            AgenteTesoreria.Proxy.GrabarListaPagos(oListaPagos);
                        }
                    }

                    Buscar();
                }

            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Editar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void cboEstados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboEstados.SelectedIndex == 0) //Pendientes
            {
                tsmiPagos.Enabled = false;
                tsmiDeshacer.Enabled = false;
                tsmiLimpiar.Enabled = false;

                tsmiImprimeVoucher.Enabled = false;
                tsmiVerVoucherEgresos.Enabled = false;

                cboFormas.Enabled = false;
                cboBancos.Enabled = false;
                cboFormas.SelectedValue = "0";
                cboBancos.SelectedValue = 0;
                cboBancos_SelectionChangeCommitted(new Object(), new EventArgs());
                dgvPagos.Visible = true;
                dgvEgresos.Visible = false;
            }
            else if (cboEstados.SelectedIndex == 1) //Cancelados
            {
                tsmiPagos.Enabled = false;
                tsmiDeshacer.Enabled = false;
                tsmiLimpiar.Enabled = false;

                tsmiImprimeVoucher.Enabled = true;
                tsmiVerVoucherEgresos.Enabled = true;

                cboFormas.Enabled = true;
                cboBancos.Enabled = true;
                dgvPagos.Visible = true;
                dgvEgresos.Visible = false;
            }
            else //Resumido
            {
                tsmiPagos.Enabled = false;
                tsmiDeshacer.Enabled = false;
                tsmiImprimeVoucher.Enabled = false;
                tsmiVerVoucherEgresos.Enabled = false;
                tsmiLimpiar.Enabled = false;

                dgvEgresos.Visible = true;
                dgvPagos.Visible = false;
                cboBancos.Enabled = true;
            }

            Buscar();
        }

        private void tsmiGenera_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (((ProgramaPagoE)bsProgramaPago.Current).Estado == "C")
            //    {
            //        Global.MensajeComunicacion("Este registro ya fue girado.");
            //    }
            //    else
            //    {
            //        if (((ProgramaPagoE)bsProgramaPago.Current).Estado == "P" && ((ProgramaPagoE)bsProgramaPago.Current).Aprobado == "S") //Solo si esta aprobado el documento
            //        {
            //            if (((ProgramaPagoE)bsProgramaPago.Current).NemoFormaPago != "ETCC") //Si es diferente a Transferencia
            //            {
            //                frmGenerarCheque oFrm = new frmGenerarCheque();

            //                if (oFrm.ShowDialog() == DialogResult.OK)
            //                {
            //                    //String Verifica = oFrm.ValorSN;

            //                    if (Global.MensajeConfirmacion("Esta seguro de generar el cheque...?") == DialogResult.Yes)
            //                    {
            //                        if (Verifica == Variables.SI) // Si son todos los del grupo
            //                        {
            //                            ProgramaPagoE oTmp = new ProgramaPagoE();
            //                            oTmp = (ProgramaPagoE)bsProgramaPago.Current;

            //                            List<ProgramaPagoE> oTodosRegistrosEnGrupo = new List<ProgramaPagoE>((List<ProgramaPagoE>)bsProgramaPago.List);
            //                            oTodosRegistrosEnGrupo = (from x in oTodosRegistrosEnGrupo
            //                                                      where x.idEmpresa == oTmp.idEmpresa
            //                                                      && x.idLocal == oTmp.idLocal
            //                                                      && x.Fecha == oTmp.Fecha
            //                                                      && x.idPersona == oTmp.idPersona
            //                                                      && x.Grupo == oTmp.Grupo
            //                                                      && x.Estado == oTmp.Estado
            //                                                      select x).ToList();

            //                            if (oTodosRegistrosEnGrupo.Count > Variables.Cero)
            //                            {
            //                                foreach (ProgramaPagoE item in oTodosRegistrosEnGrupo)
            //                                {
            //                                    if (item.idPersonaBanco == 0)
            //                                    {
            //                                        Global.MensajeFault("Para poder Generar el cheque.... Debe asignar bancos en todos los documentos que pertenecen a este egreso...");
            //                                        return;
            //                                    }
            //                                }

            //                                AgenteTesoreria.Proxy.GenerarCheque(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, ((ProgramaPagoE)bsProgramaPago.Current).idLocal,
            //                                                                    ((ProgramaPagoE)bsProgramaPago.Current).idProgramaPago, ((ProgramaPagoE)bsProgramaPago.Current).Fecha,
            //                                                                    ((ProgramaPagoE)bsProgramaPago.Current).idPersona, ((ProgramaPagoE)bsProgramaPago.Current).idDocumento,
            //                                                                    ((ProgramaPagoE)bsProgramaPago.Current).UsuarioRegistro, ((ProgramaPagoE)bsProgramaPago.Current).Estado,
            //                                                                    ((ProgramaPagoE)bsProgramaPago.Current).Grupo, VariablesLocales.SesionUsuario.Credencial);
            //                                Global.MensajeComunicacion("Proceso terminado...");
            //                            }
            //                        }
            //                        else // Si es uno solo...
            //                        {
            //                            //ProgramaPagoE oUnRegistro = new ProgramaPagoE();
            //                            //oUnRegistro = (ProgramaPagoE)bsProgramaPago.Current;

            //                            //if (String.IsNullOrEmpty(oUnRegistro.nomBanco) || String.IsNullOrEmpty(oUnRegistro.numCuenta))
            //                            //{
            //                            //    Global.MensajeFault("Para poder Generar el cheque.... Debe asignar bancos en todos los documentos que pertenecen a este egreso...");
            //                            //    return;
            //                            //}
            //                            Global.MensajeComunicacion("En construccion...");
            //                        }
            //                    } 
            //                }
            //            }

            //            Buscar();
            //        }
            //        else if (((ProgramaPagoE)bsProgramaPago.Current).Aprobado == "N")
            //        {
            //            Global.MensajeComunicacion("El documento ya ha sido desaprobado.");
            //        }
            //        else
            //        {
            //            Global.MensajeComunicacion("El documento debe estar aprobado antes de generar el cheque.");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeError(ex.Message);
            //}
        }

        private void tsmiPagos_Click(object sender, EventArgs e)
        {
            try
            {
                //Obteniendo todas las lineas con el check
                List<ProgramaPagoE> oListaPP = oListaPagosEscogidos();

                if (oListaPP.Count == 0)
                {
                    Global.MensajeComunicacion("Debe escoger registro antes de generar.");
                    return;
                }

                //Verificando datos bancarios...
                if (oListaPP.Count == 1)
                {
                    if (String.IsNullOrWhiteSpace(oListaPP[0].idDocumentoBanco) || oListaPP[0].idDocumentoBanco == "0")
                    {
                        Global.MensajeComunicacion("Todos los items tienen que tener el tipo de documento del Banco.");
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(oListaPP[0].NumeroBanco) || oListaPP[0].NumeroBanco == "0")
                    {
                        Global.MensajeComunicacion("Todos los items tienen que tener el Número del documento del Banco.");
                        return;
                    }
                }
                else
                {
                    ProgramaPagoE ppRevisionDoc = oListaPP.Find
                    (
                        delegate(ProgramaPagoE p) { return p.idDocumentoBanco != "" && p.NumeroBanco != ""; }
                    );

                    if (ppRevisionDoc != null)
                    {
                        foreach (ProgramaPagoE item in oListaPP)
                        {
                            item.idDocumentoBanco = ppRevisionDoc.idDocumentoBanco;
                            item.SerieBanco = ppRevisionDoc.SerieBanco;
                            item.NumeroBanco = ppRevisionDoc.NumeroBanco;
                            item.Glosa = ppRevisionDoc.Glosa;
                        }
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(oListaPP[0].idDocumentoBanco) || oListaPP[0].idDocumentoBanco == "0")
                        {
                            Global.MensajeComunicacion("Todos los items tienen que tener el tipo de documento del Banco.");
                            return;
                        }

                        if (String.IsNullOrWhiteSpace(oListaPP[0].NumeroBanco) || oListaPP[0].NumeroBanco == "0")
                        {
                            Global.MensajeComunicacion("Todos los items tienen que tener el Número del documento del Banco.");
                            return;
                        }
                    }
                }

                Int32 idPer = oListaPP[0].idPersona;
                DateTime FechaPago = oListaPP[0].Fecha.Date;

                foreach (ProgramaPagoE item in oListaPP)
                {
                    if (String.IsNullOrWhiteSpace(item.nomBanco))
                    {
                        Global.MensajeComunicacion(String.Format("Este item {0} {1} no se le ha asignado ningún Banco. Todos deberian tener Banco antes de realizar el pago.", item.idProgramaPago.ToString(), item.RazonSocial));
                        return;
                    }

                    //Saber si el pago esta aprobado
                    if (String.IsNullOrWhiteSpace(item.Aprobado.Trim()) || item.Aprobado == "N")
                    {
                        Global.MensajeComunicacion("Todos los items escogidos deben estar Aprobados previamente.");
                        return;
                    }

                    if (item.NemoTipoPago != "PL") // Si no es pago de planilla.
                    {
                        if (item.NemoFormaPago == "ECHE") // Solo cuando sea Pago de Cheques.
                        {
                            if (item.idPersona != idPer)
                            {
                                Global.MensajeComunicacion("Todos los items tienen que tener el mismo auxiliar.");
                                return;
                            }
                        }
                    }
                    else
                    {
                        item.idPersona = 0;
                    }

                    //Verificando que todos los item tengan la misma fecha de pago
                    if (FechaPago != item.Fecha)
                    {
                        Global.MensajeComunicacion("Todos los items tienen que tener la misma Fecha de Pago.");
                        return;
                    }

                    if (item.Estado != "P")
                    {
                        Global.MensajeComunicacion("Todos los items tienen que estar como pendientes.");
                        return;
                    }
                }

                /*
                    Efectivo = EEFE
                    Cheque = ECHE
                    Dep. Cta. Bancaria = EDBA
                    Transf. Cta. a Cta. = ETCC
                    Abono cta. cte cliente = EACC
                    Efectivo = IEFE
                    Cta. Bancaria = ICBA
                    Cheque = ICHE
                */

                if (oListaPP.Count > 0)
                {
                    if (oListaPP[0].idPersona == 0)
                    {
                        idPer = 0;
                    }

                    Int32 MaximoGrupo = AgenteTesoreria.Proxy.MaxGrupoProgramaPagos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, idPer, oListaPP[0].Fecha.Date);
                    MaximoGrupo++;

                    //Si es Depósito bancario o Transferencia
                    //if (((ProgramaPagoE)bsProgramaPago.Current).NemoFormaPago != "ECHE")// || ((ProgramaPagoE)bsProgramaPago.Current).NemoFormaPago == "ETCC")
                    //{
                    if (Global.MensajeConfirmacion("Esta seguro de generar el Pago...?") == DialogResult.Yes)
                    {
                        String resp = AgenteTesoreria.Proxy.GenerarVoucherTesTransferencia(oListaPP, VariablesLocales.SesionUsuario.Credencial, "P", MaximoGrupo.ToString());

                        if (!String.IsNullOrWhiteSpace(resp))
                        {
                            Global.MensajeComunicacion(resp); 
                        }
                    }
                    //}
                    //else if (((ProgramaPagoE)bsProgramaPago.Current).NemoFormaPago == "ECHE")
                    //{
                    //    ProgramaPagoE oTmp = new ProgramaPagoE();
                    //    oTmp = (ProgramaPagoE)bsProgramaPago.Current;

                    //    List<ProgramaPagoE> oTodosRegistrosEnGrupo = new List<ProgramaPagoE>((List<ProgramaPagoE>)bsProgramaPago.List);
                    //    oTodosRegistrosEnGrupo = (from x in oTodosRegistrosEnGrupo
                    //                              where x.idEmpresa == oTmp.idEmpresa
                    //                              && x.idLocal == oTmp.idLocal
                    //                              && x.Fecha == oTmp.Fecha
                    //                              && x.idPersona == oTmp.idPersona
                    //                              && x.Grupo == oTmp.Grupo
                    //                              && x.Estado == oTmp.Estado
                    //                              select x).ToList();

                    //    if (oTodosRegistrosEnGrupo.Count > Variables.Cero)
                    //    {
                    //        foreach (ProgramaPagoE item in oTodosRegistrosEnGrupo)
                    //        {
                    //            if (item.idPersonaBanco == 0)
                    //            {
                    //                Global.MensajeFault("Para poder Generar el cheque.... Debe asignar bancos en todos los documentos que pertenecen a este egreso...");
                    //                return;
                    //            }
                    //        }

                    //        AgenteTesoreria.Proxy.GenerarCheque(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, ((ProgramaPagoE)bsProgramaPago.Current).idLocal,
                    //                                            ((ProgramaPagoE)bsProgramaPago.Current).idProgramaPago, ((ProgramaPagoE)bsProgramaPago.Current).Fecha,
                    //                                            ((ProgramaPagoE)bsProgramaPago.Current).idPersona, ((ProgramaPagoE)bsProgramaPago.Current).idDocumento,
                    //                                            ((ProgramaPagoE)bsProgramaPago.Current).UsuarioRegistro, ((ProgramaPagoE)bsProgramaPago.Current).Estado,
                    //                                            ((ProgramaPagoE)bsProgramaPago.Current).Grupo, VariablesLocales.SesionUsuario.Credencial);
                    //        Global.MensajeComunicacion("Proceso terminado...");
                    //    }
                    //}

                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiDeshacer_Click(object sender, EventArgs e)
        {
            try
            {
                List<ProgramaPagoE> oListaPP = oListaPagosEscogidos();

                if (oListaPP.Count == 0)
                {
                    Global.MensajeComunicacion("Debe escoger registro antes de deshacer los pagos.");
                    return;
                }

                String resp = AgenteTesoreria.Proxy.CancelarPagos(oListaPP, VariablesLocales.SesionUsuario.Credencial);

                if (resp == "ok")
                {
                    Buscar();
                    Global.MensajeComunicacion("Los pagos fueron cancelados.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiImprimeVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherE oVoucher = AgenteContabilidad.Proxy.ObtenerVoucherPorCodigo(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, ((ProgramaPagoE)bsProgramaPago.Current).idLocal,
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).AnioPeriodo, ((ProgramaPagoE)bsProgramaPago.Current).MesPeriodo,
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).numVoucher, ((ProgramaPagoE)bsProgramaPago.Current).idComprobante,
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).numFile, "N");
                if (oVoucher != null)
                {
                    Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                    if (oFrm != null)
                    {
                        if (oFrm.WindowState == FormWindowState.Minimized)
                        {
                            oFrm.WindowState = FormWindowState.Normal;
                        }

                        oFrm.BringToFront();
                        return;
                    }

                    oFrm = new frmImpresionVoucher("N", oVoucher);
                    oFrm.MdiParent = MdiParent;
                    oFrm.Show(); 
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void tsmiLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (((ProgramaPagoE)bsProgramaPago.Current).Estado == "P")
                {
                    AgenteTesoreria.Proxy.LimpiarVoucherPP(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, ((ProgramaPagoE)bsProgramaPago.Current).idLocal,
                                                            ((ProgramaPagoE)bsProgramaPago.Current).idPersona, ((ProgramaPagoE)bsProgramaPago.Current).Grupo,
                                                            Convert.ToInt32(((ProgramaPagoE)bsProgramaPago.Current).idNumEgreso), VariablesLocales.SesionUsuario.Credencial);
                    Buscar();
                    Global.MensajeComunicacion("Número Borrado.");
                }
                else
                {
                    Global.MensajeComunicacion("Antes de limpiar el N° de voucher, tiene que deshacer el pago.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btAgregarOrdenPago_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 idBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);

                if (idBanco == 0)
                {
                    Global.MensajeComunicacion("Debe escoger un banco para el pago.");
                    cboBancos.Focus();
                    return;
                }

                String CuentaContaBanco = ((BancosCuentasE)cboCuentas.SelectedItem).codCuenta;

                if (String.IsNullOrWhiteSpace(CuentaContaBanco.Trim()))
                {
                    Global.MensajeComunicacion("La cuenta bancaria del banco no posee su cuenta contable asociada. Debe ingresarlo en el Maestros/Auxiliares/Bancos");
                    cboBancos.Focus();
                    return;
                }

                ComprobantesE oComprobante = VariablesLocales.oListaComprobantes.Find
                (
                    delegate (ComprobantesE c) { return c.idComprobante == "05"; }
                );

                ComprobantesFileE oFile = oComprobante.ListaComprobantesFiles.Find
                (
                    delegate (ComprobantesFileE f) { return f.codCuenta == CuentaContaBanco; }
                );

                if (oFile == null)
                {
                    Global.MensajeComunicacion("No hay ningún File asociado con el código contable de la Cuenta Bancaria escogida. Revisarlo en Contabilidad/Maestros/Diarios");
                    cboBancos.Focus();
                    return;
                }

                frmPendienteOrdenPago oFrm = new frmPendienteOrdenPago(idBanco, cboMoneda.SelectedValue.ToString(), dtpFecIni.Value.Date, dtpFecFin.Value.Date);

                if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oListaOrdenPago.Count > Variables.Cero)
                {
                    ProgramaPagoE oItemPago = null;
                    List<ProgramaPagoE> oListaPagos = new List<ProgramaPagoE>();
                    List<OrdenPagoE> oListaTemp = new List<OrdenPagoE>(oFrm.oListaOrdenPago);
                    DateTime Fecha = dtpFecIni.Value.Date;

                    if (bsProgramaPago.List.Count > Variables.Cero)
                    {
                        //List<OrdenPagoE> oListaEliminacion = new List<OrdenPagoE>();

                        //foreach (OrdenPagoE item1 in oListaTemp)
                        //{
                        //    foreach (ProgramaPagoE item2 in bsProgramaPago.List)
                        //    {
                        //        if (item1.idPersona == item2.idPersona && item1.RUC == item2.RUC && item1.RazonSocial == item2.RazonSocial)
                        //        {
                        //            Global.MensajeFault(String.Format("Este documento {0} {1}-{2} ya ha sido ingresado, intente ingresar otro o elimine el registro anterior para ingresarlo nuevamente.", item1.idPersona, item1.RUC, item1.RazonSocial));
                        //            oListaEliminacion.Add(item1);
                        //        }
                        //    }
                        //}

                        //if (oListaEliminacion.Count > Variables.Cero)
                        //{
                        //    foreach (OrdenPagoE item in oListaEliminacion)
                        //    {
                        //        oListaTemp.Remove(item);
                        //    }
                        //}
                    }

                    if (oListaTemp.Count > Variables.Cero)
                    {
                        String DebeHaber = Variables.Debe;

                        foreach (OrdenPagoE item in oListaTemp)
                        {
                            oItemPago = new ProgramaPagoE();

                            if (item.idDocumento == "NC" || item.idDocumento.ToString() == "ND" || item.idDocumento == "CR" || item.idDocumento == "DR")
                            {
                                DebeHaber = Variables.Haber;
                            }

                            oItemPago.idEmpresa = VariablesLocales.SesionUsuario.Empresa.IdEmpresa;
                            oItemPago.idLocal = VariablesLocales.SesionLocal.IdLocal;
                            oItemPago.Fecha = dtpFecPago.Value.Date;
                            
                            oItemPago.idPersona = Convert.ToInt32(item.idPersonaBeneficiario);
                            oItemPago.idDocumento = item.idDocumento;
                            oItemPago.serDocumento = item.serDocumento;                          
                            oItemPago.fecDocumento = item.FecDocumento.Date;

                            oItemPago.numDocumento = item.numDocumento;
                            oItemPago.codFormaPago = item.codFormaPago;
                            oItemPago.idConcepto = item.idConcepto;
                            oItemPago.codTipoPago = item.codTipoPago;

                            //Empresa
                            oItemPago.idPersonaBanco = Convert.ToInt32(cboBancosEmpresa.SelectedValue);                        
                            oItemPago.numCuenta = cboCuentas.SelectedValue.ToString();

                            //Auxiliar
                            oItemPago.numCheque = String.Empty;
                            oItemPago.idBancoAuxliar = item.idBanco;
                            oItemPago.tipCtaAuxiliar = item.tipCuenta;
                            oItemPago.idMonedaAuxiliar = item.idMonedaBanco;
                            oItemPago.numCtaAuxiliar = item.numCtaBancaria;

                            oItemPago.Grupo = "0";// MaximoGrupo.ToString();
                            oItemPago.Glosa = item.Glosa;
                            
                            oItemPago.fecVencimiento = (DateTime?)null;
                            oItemPago.TipoCambio = 1;

                            oItemPago.indDebeHaber = DebeHaber;
                            oItemPago.idMoneda = item.idMoneda;

                            if (item.idMoneda == item.idMonedaPago)
                            {
                                oItemPago.MontoOrigen = item.MontoPago;
                            }
                            else
                            {// Para el caso de detracciones en dolares y se paga en soles
                                oItemPago.MontoOrigen = item.Monto;
                            }

                            oItemPago.idMonedaPago = cboMoneda.SelectedValue.ToString();
                            oItemPago.Monto = item.MontoPago;

                            oItemPago.tipPartidaPresu = item.TipPartidaPresu;
                            oItemPago.codPartidaPresu = item.CodPartidaPresu;
                            oItemPago.desPartida = item.DesPartida;

                            oItemPago.idNumEgreso = Variables.Cero;
                            oItemPago.desBeneficiario = item.NombreBen;

                            oItemPago.numVerPlanCuentas = item.numVerPlanCuentas;
                            oItemPago.codCuenta = item.codCuenta;
                            oItemPago.idComprobante = oComprobante.idComprobante;
                            oItemPago.numFile = oFile.numFile;

                            oItemPago.idDocumentoBanco = String.Empty;
                            oItemPago.SerieBanco = String.Empty;
                            oItemPago.NumeroBanco = String.Empty;

                            oItemPago.idOrdenPago = item.idOrdenPago;

                            oItemPago.UsuarioRegistro = VariablesLocales.SesionUsuario.Credencial;

                            if (oItemPago.idDocumento == "LC")
                            {
                                //MaximoGrupo++;
                            }

                            oListaPagos.Add(oItemPago);
                        }

                        AgenteTesoreria.Proxy.GrabarListaPagos(oListaPagos, oListaTemp, VariablesLocales.SesionUsuario.Credencial);
                    }

                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void bsProgramaPago_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (bsProgramaPago.Current != null)
            {
                lblRegistros.Text = String.Format("Registros {0}", bsProgramaPago.List.Count.ToString());
            }
        }

        private void btBcp_Click(object sender, EventArgs e)
        {
            Global.MensajeComunicacion("Banco de Crédito");
        }

        private void btScotiank_Click(object sender, EventArgs e)
        {
            Global.MensajeComunicacion("Banco ScotianBank");
        }

        private void btBbva_Click(object sender, EventArgs e)
        {
            Global.MensajeComunicacion("Banco BBVA");
        }

        private void cboBancos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboBancos.SelectedValue) != 0)
                {
                    btBcp.Enabled = true;
                    btBbva.Enabled = true;
                    btScotiank.Enabled = true;
                    btInterBank.Enabled = true;
                }
                else
                {
                    btBcp.Enabled = false;
                    btBbva.Enabled = false;
                    btScotiank.Enabled = false;
                    btInterBank.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void btInterBank_Click(object sender, EventArgs e)
        {
            Global.MensajeComunicacion("Banco Interbank");
        }

        private void tsmGenerarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (((ProgramaPagoE)bsProgramaPago.Current).Estado == "C")
                {
                    Global.MensajeComunicacion("Este registro ya fue cancelado.");
                }
                else
                {
                    if (((ProgramaPagoE)bsProgramaPago.Current).Estado == "P" && ((ProgramaPagoE)bsProgramaPago.Current).Aprobado == "S") //Solo si esta aprobado el documento
                    {
                        if (((ProgramaPagoE)bsProgramaPago.Current).NemoFormaPago == "ETCC") //Si es diferente a Transferencia
                        {
                            if (Global.MensajeConfirmacion("Esta seguro de generar la Transferencia...?") == DialogResult.Yes)
                            {
                                //AgenteTesoreria.Proxy.GenerarVoucherTesTransferencia(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, ((ProgramaPagoE)bsProgramaPago.Current).idLocal,
                                //                                                ((ProgramaPagoE)bsProgramaPago.Current).idProgramaPago, ((ProgramaPagoE)bsProgramaPago.Current).Fecha.Date,
                                //                                                VariablesLocales.SesionUsuario.Credencial, ((ProgramaPagoE)bsProgramaPago.Current).Estado);
                                Global.MensajeComunicacion("Proceso terminado...");
                            }
                        }

                        Buscar();
                    }
                    else if (((ProgramaPagoE)bsProgramaPago.Current).Aprobado == "N")
                    {
                        Global.MensajeComunicacion("El documento ya ha sido desaprobado.");
                    }
                    else
                    {
                        Global.MensajeComunicacion("El documento debe estar aprobado antes de generar la transferencia.");
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvPagos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvPagos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Rows.Count != 0)
            {
                if (!indClickCab)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvPagos[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvPagos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvPagos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        bool BuscarCadena(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();

            if (Columna == string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if ((String)cell.Value == TextoABuscar)
                        {
                            row.Selected = true;
                            return true;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if ((String)row.Cells[Columna].Value == TextoABuscar)
                    {
                        row.Selected = true;
                        return true;
                    }
                }
            }

            return encontrado;
        }

        bool BuscarLINQ(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();

            if (String.IsNullOrEmpty(Columna))
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    from DataGridViewCell cells in row.Cells
                                                    where cells.OwningRow.Equals(row) 
                                                    && cells.Value.ToString() == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }
            }
            else
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    where row.Cells[Columna].Value.ToString() == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }
            }

            return encontrado;
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMoneda.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboBancosEmpresa.SelectedValue != null)
                {
                    LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dtpFecPago_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime Fecha = dtpFecPago.Value.Date;//.AddDays(-1);
            //    TipoCambioE oTica = VariablesLocales.RetornaTipoCambio(Variables.Dolares, Fecha);

            //    if (oTica == null)
            //    {
            //        Global.MensajeComunicacion("No existe tipo de cambio, seleccione otra fecha...");
            //    }
            //    else
            //    {
            //        txtTica.Text = oTica.valVenta.ToString("N3");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void bsEgresos_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (bsEgresos.Count > 0)
            {
                lblRegistros.Text = String.Format("Registros {0}", bsEgresos.List.Count.ToString());
            }
        }

        private void verVoucherEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form oFrm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmImpresionVoucher);

                if (oFrm != null)
                {
                    if (oFrm.WindowState == FormWindowState.Minimized)
                    {
                        oFrm.WindowState = FormWindowState.Normal;
                    }

                    oFrm.BringToFront();
                    return;
                }


                oListaVoucherDetalle = AgenteContabilidad.Proxy.VoucherDetalleEgreso(((ProgramaPagoE)bsProgramaPago.Current).idEmpresa, 
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).idLocal, 
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).AnioPeriodo, 
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).MesPeriodo, 
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).numVoucher, 
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).idComprobante, 
                                                                                    ((ProgramaPagoE)bsProgramaPago.Current).numFile);
                oPrograma = (ProgramaPagoE)bsProgramaPago.Current;

                oFrm = new frmImpresionVoucher("E" , oListaVoucherDetalle, "PP", oPrograma);

                oFrm.MdiParent = this.MdiParent;
                oFrm.Show();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtRuc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            txtRazonSocial.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("El Ruc ingresado no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRuc.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRazonSocial.Text.Trim()) && String.IsNullOrWhiteSpace(txtRuc.Text.Trim()))
                {
                    List<Persona> oListaPersonas = AgenteMaestros.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtRuc.Tag = oFrm.oPersona.IdPersona;
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                        }
                        else
                        {
                            dgvEgresos.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtRuc.Tag = oListaPersonas[0].IdPersona;
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;
                    }
                    else
                    {
                        Global.MensajeFault("La Razón Social ingresada no existe");
                        txtRuc.Tag = 0;
                        txtRuc.Text = String.Empty;
                        txtRazonSocial.Text = String.Empty;
                        txtRazonSocial.Focus();
                    }

                    txtRuc.TextChanged += txtRuc_TextChanged;
                    txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                }
            }
            catch (Exception ex)
            {
                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRazonSocial.Text = String.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRuc.Tag = 0;
            txtRuc.Text = String.Empty;
        }

        #endregion

    }
}
