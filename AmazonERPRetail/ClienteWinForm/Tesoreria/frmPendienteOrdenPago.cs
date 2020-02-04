using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using ClienteWinForm.Busquedas;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmPendienteOrdenPago : frmResponseBase
    {

        #region Constructores

        public frmPendienteOrdenPago()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvOrdenPago, true);
            LlenarCombos();
        }

        public frmPendienteOrdenPago(Int32 idBanco_, String idMoneda_, DateTime fecIni, DateTime fecFin)
            :this()
        {
            cboBancosEmpresa.SelectedValue = idBanco_;
            cboMoneda.SelectedValue = idMoneda_;

            dtpFecIni.Value = fecIni.Date;
            dtpFecFin.Value = fecFin.Date;
        } 

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public List<OrdenPagoE> oListaOrdenPago = null;
        List<OrdenPagoE> oListaDevuelta = new List<OrdenPagoE>();
        OrdenPagoE ordenPag = new OrdenPagoE();
        String idMoneda = String.Empty;
        Boolean Ordenar = false;

        Int32 TotalChecks = Variables.Cero;
        Int32 TotalCheckeados = Variables.Cero;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            Int32 Contador = Variables.Cero;
            oListaOrdenPago = new List<OrdenPagoE>();

            foreach (OrdenPagoE item in (List<OrdenPagoE>)bsBase.List)
            {
                if (item.Seleccionar)
                {
                    Contador++;

                    if (String.IsNullOrWhiteSpace(item.codCuenta))
                    {
                        Global.MensajeFault("El registro no posee una Cuenta Contable. No podrá agregarlo al pago.");
                        return;
                    }

                    oListaOrdenPago.Add(item);
                }
            }

            if (Contador == Variables.Cero)
            {
                Global.MensajeFault("Debe seleccionar al menos un registro o Presione Cancelar.");
                return;
            }

            base.Aceptar();
        }

        public override void Buscar()
        {
            ObtenerOrdenPago(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboSucursal.SelectedValue));

            CheckBoxCab.Checked = false;
            HeaderCheckBoxClick(CheckBoxCab);

            TotalChecks = dgvOrdenPago.RowCount;
            TotalCheckeados = 0;
            lblTotaSol.Text = "0.00";
            lblTotalDol.Text = "0.00";
        }

        #endregion

        #region Procedimientos de Usuario

        void ObtenerOrdenPago(Int32 idEmpresa, Int32 idLocal)
        {
            oListaDevuelta = new List<OrdenPagoE>();
            List<OrdenPagoE> oOrdenesPago = AgenteTesoreria.Proxy.ListarOrdenPagoPorIdPersona(idEmpresa, idLocal, (chkTodos.Checked == true ? 0 : Convert.ToInt32(txtIdAuxiliar.Text)),
                                            dtpFecIni.Value.Date, dtpFecFin.Value.Date);

            if (Convert.ToInt32(cboBancosEmpresa.SelectedValue) > 0)
            {
                //Documentos que tienen datos bancarios
                oListaDevuelta.AddRange((from x in oOrdenesPago
                                         where x.codOrdenPago.Contains(txtNroOp.Text.Trim())
                                         && x.idBanco == Convert.ToInt32(cboBancosEmpresa.SelectedValue)
                                         && x.idMonedaPago == cboMoneda.SelectedValue.ToString()
                                         && x.codTipoPago == (cboTipoPago.SelectedValue.ToString() == "0" ? x.codTipoPago : cboTipoPago.SelectedValue.ToString())
                                         select x).ToList());

                //Documentos que no tienen datos bancarios
                oListaDevuelta.AddRange((from x in oOrdenesPago
                                         where x.codOrdenPago.Contains(txtNroOp.Text.Trim())
                                         && x.idBanco == 0
                                         && x.idMonedaPago == cboMoneda.SelectedValue.ToString()
                                         && x.codTipoPago == (cboTipoPago.SelectedValue.ToString() == "0" ? x.codTipoPago : cboTipoPago.SelectedValue.ToString())
                                         select x).ToList());
            }
            else
            {
                oListaDevuelta = (from x in oOrdenesPago
                                  where x.codOrdenPago.Contains(txtNroOp.Text.Trim())
                                  && x.idMonedaPago == cboMoneda.SelectedValue.ToString()
                                  && x.codTipoPago == (cboTipoPago.SelectedValue.ToString() == "0" ? x.codTipoPago : cboTipoPago.SelectedValue.ToString())
                                  select x).ToList();
            }

            bsBase.DataSource = oListaDevuelta;
            bsBase.ResetBindings(false);
        }

        void LlenarCombos()
        {
            //Tipo de Pago
            List<TipoPagoE> ListaTipoPago = AgenteTesoreria.Proxy.ListarTipoPagoCombo("E");
            TipoPagoE Ini = new TipoPagoE() { codTipoPago = Variables.Cero.ToString(), desTipoPago = Variables.Seleccione };
            ListaTipoPago.Add(Ini);
            ComboHelper.RellenarCombos<TipoPagoE>(cboTipoPago, (from x in ListaTipoPago orderby x.codTipoPago select x).ToList(), "codTipoPago", "desTipoPago");

            //Monedas
            List<MonedasE> oListaMonedas = new List<MonedasE>(VariablesLocales.ListaMonedas);
            ComboHelper.RellenarCombos<MonedasE>(cboMoneda, (from x in oListaMonedas orderby x.idMoneda select x).ToList(), "idMoneda", "desAbreviatura");

            //Locales
            List<LocalE> listaLocales = new List<LocalE>(from x in VariablesLocales.SesionUsuario.UsuarioLocales
                                                         where x.IdEmpresa == VariablesLocales.SesionUsuario.Empresa.IdEmpresa
                                                         select x).ToList();
            ComboHelper.RellenarCombos<LocalE>(cboSucursal, listaLocales, "idLocal", "Nombre", false);
            cboSucursal.SelectedValue = Convert.ToInt32(VariablesLocales.SesionLocal.IdLocal);

            List<BancosE> oListarBancos = AgenteMaestro.Proxy.ListarBancos(VariablesLocales.SesionUsuario.Empresa.IdEmpresa);
            BancosE banIni = new BancosE() { idPersona = Variables.Cero, SiglaComercial = Variables.Seleccione };
            oListarBancos.Add(banIni);
            ComboHelper.RellenarCombos<BancosE>(cboBancosEmpresa, (from x in oListarBancos orderby x.idPersona select x).ToList(), "idPersona", "SiglaComercial");
        }

        void CalcularMontos()
        {
            List<OrdenPagoE> oLista = (List<OrdenPagoE>)bsBase.List;

            if (oLista.Count > 0)
            {
                Decimal totS = Convert.ToDecimal((from x in oLista where x.Seleccionar == true && x.idMonedaPago == "01" select x.MontoPago).Sum());
                Decimal totD = Convert.ToDecimal((from x in oLista where x.Seleccionar == true && x.idMonedaPago == "02" select x.MontoPago).Sum());

                lblTotaSol.Text = totS.ToString("N2");
                lblTotalDol.Text = totD.ToString("N2");
            }

            oLista = null;
        }

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvOrdenPago.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Seleccionar"]).Value = HCheckBox.Checked;

                if (HCheckBox.Checked)
                {
                    ((DataGridViewTextBoxCell)Row.Cells["MontoPago"]).Value = ((DataGridViewTextBoxCell)Row.Cells["MontoPagoDet"]).Value;
                }
                else
                {
                    ((DataGridViewTextBoxCell)Row.Cells["MontoPago"]).Value = 0M;
                }
            }

            dgvOrdenPago.RefreshEdit();
            bsBase.ResetBindings(false);
            TotalCheckeados = HCheckBox.Checked ? TotalChecks : 0;
            indClickCab = false;

            CalcularMontos();
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
            dgvOrdenPago.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvOrdenPago.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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
                    ((OrdenPagoE)bsBase.Current).MontoPago = ((OrdenPagoE)bsBase.Current).MontoPagoDet;
                }
                else if (TotalCheckeados > 0)
                {
                    TotalCheckeados--;
                    ((OrdenPagoE)bsBase.Current).MontoPago = 0;
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

        #region Eventos

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRazonSocial.Text) && !chkTodos.Checked)
                {
                    Global.MensajeFault("Debe escoger un auxiliar antes de buscar. De lo contrario coloque el check de Todos.");
                    return;
                }

                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void btCliente_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                ObtenerOrdenPago(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, Convert.ToInt32(cboSucursal.SelectedValue));
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtIdAuxiliar.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btCliente.Enabled = false;
            }
            else
            {
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btCliente.Enabled = true;
            }
        }

        private void frmPendienteOrdenPago_Load(object sender, EventArgs e)
        {
            try
            {
                AñadirCheckBox();
                CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);

                Buscar();

                if (VariablesLocales.SesionUsuario.Credencial != "SISTEMAS")
                {
                    dgvOrdenPago.Columns[1].Visible = false;
                }
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
                if (!String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RU", txtRuc.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            btBuscar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        btBuscar.Focus();
                    }
                    else
                    {
                        txtIdAuxiliar.Text = String.Empty;
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
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtRuc.Text.Trim()) && !String.IsNullOrEmpty(txtRazonSocial.Text.Trim()))
                {
                    txtRuc.TextChanged -= txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdAuxiliar.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            btBuscar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdAuxiliar.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        btBuscar.Focus();
                    }
                    else
                    {
                        txtIdAuxiliar.Text = String.Empty;
                        txtIdAuxiliar.Text = String.Empty;
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
                Global.MensajeError(ex.Message);
            }
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRazonSocial.Text = string.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdAuxiliar.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void dgvOrdenPago_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvOrdenPago_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvOrdenPago.Rows.Count != 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (!indClickCab)
                        {
                            FilaCheBoxClick((DataGridViewCheckBoxCell)dgvOrdenPago[e.ColumnIndex, e.RowIndex]);
                        }
                    }

                    if (e.ColumnIndex == 15)
                    {
                        CalcularMontos();
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvOrdenPago_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOrdenPago.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvOrdenPago.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvOrdenPago_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((Boolean)dgvOrdenPago.Rows[e.RowIndex].Cells["Seleccionar"].Value == true)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(180, 198, 231);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvOrdenPago_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvOrdenPago.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
        private void bsBase_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblTitPnlBase.Text = "Registros " + bsBase.List.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void cboBancosEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cboMoneda.SelectedValue != null)
            //    {
            //        LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cboMoneda.SelectedValue != null)
            //    {
            //        LlenarCuentasBancarias(Convert.ToInt32(cboBancosEmpresa.SelectedValue), cboMoneda.SelectedValue.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Global.MensajeFault(ex.Message);
            //}
        }

        private void dgvOrdenPago_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (oListaDevuelta != null && oListaDevuelta.Count > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Por Fecha
                    if (e.ColumnIndex == dgvOrdenPago.Columns["Fecha"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.Fecha ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.Fecha descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Orden de Pago
                    if (e.ColumnIndex == dgvOrdenPago.Columns["codOrdenPago"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.codOrdenPago ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.codOrdenPago descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por número de documento
                    if (e.ColumnIndex == dgvOrdenPago.Columns["numDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.numDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.numDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por fecha de documento
                    if (e.ColumnIndex == dgvOrdenPago.Columns["FecDocumento"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.FecDocumento ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.FecDocumento descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por ruc
                    if (e.ColumnIndex == dgvOrdenPago.Columns["RUC"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.RUC ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.RUC descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por Razón Social
                    if (e.ColumnIndex == dgvOrdenPago.Columns["RazonSocial"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.RazonSocial ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.RazonSocial descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por monto
                    if (e.ColumnIndex == dgvOrdenPago.Columns["Monto"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.Monto ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.Monto descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                    // Por monto detalle
                    if (e.ColumnIndex == dgvOrdenPago.Columns["MontoPagoDet"].Index)
                    {
                        if (Ordenar)
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.MontoPagoDet ascending select x).ToList();
                            Ordenar = false;
                        }
                        else
                        {
                            oListaDevuelta = (from x in oListaDevuelta orderby x.MontoPagoDet descending select x).ToList();
                            Ordenar = true;
                        }
                    }

                }

                bsBase.DataSource = oListaDevuelta;
            }
        }

        private void dgvOrdenPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    CalcularMontos();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
