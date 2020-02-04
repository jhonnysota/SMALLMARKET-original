using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Tesoreria;
using Entidades.Maestros;
using ClienteWinForm.Busquedas;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace ClienteWinForm.Tesoreria
{
    public partial class frmPendientesAuxiliares : frmResponseBase
    {

        #region Constructores

        public frmPendientesAuxiliares()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvDocumentosPendientes, true);
        }

        //Orden de Pago - Programa de Pago
        public frmPendientesAuxiliares(Boolean EsDetraccion_)
            :this()
        {
            VieneDe = "PP"; //Programa de Pago
            EsDetraccion = EsDetraccion_;
        }

        //Con datos del cliente o proveedor (Letras Compras)
        public frmPendientesAuxiliares(Int32 idCliente, String Ruc, String RazonSocial, String Bloq = "S")
            :this()
        {
            if (Bloq == "S")
            {
                txtIdCliente.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                chkTodos.Enabled = false;
                btCliente.Enabled = false;
            }

            txtIdCliente.Text = idCliente.ToString();

            txtRuc.TextChanged -= txtRuc_TextChanged;
            txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

            txtRuc.Text = Ruc;
            txtRazonSocial.Text = RazonSocial;

            txtRuc.TextChanged += txtRuc_TextChanged;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
        }

        //Movimientos de Bancos y OP
        public frmPendientesAuxiliares(String Opcion_, Boolean EsDetraccion_)
            :this()
        {
            EsDetraccion = EsDetraccion_;
            Opcion = Opcion_;

            if (Opcion != "RCTA" && Opcion != "P")
            {
                txtIdCliente.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear);
                chkTodos.Enabled = false;
                btCliente.Enabled = false; 
            }
        }

        #endregion

        #region Variables

        TesoreriaServiceAgent AgenteTesoreria { get { return new TesoreriaServiceAgent(); } }
        MaestrosServiceAgent AgenteMaestro { get { return new MaestrosServiceAgent(); } }
        public List<CtaCteE> oListaCtaCte = null;

        Int32 TotalChecks = Variables.Cero;
        Int32 TotalCheckeados = Variables.Cero;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;
        String VieneDe = String.Empty;
        Boolean EsDetraccion = false;
        String Opcion = "N"; //Para saber que cuenta va a traer

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvDocumentosPendientes.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Seleccionar"]).Value = HCheckBox.Checked;
            }

            dgvDocumentosPendientes.RefreshEdit();
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
            dgvDocumentosPendientes.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvDocumentosPendientes.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

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

        void ObtenerCtaCte(Int32 idEmpresa, Int32 idPersona)
        {
            if (rbTodos.Checked)
            {
                Opcion = "T";
            }

            List<CtaCteE> olista = AgenteTesoreria.Proxy.ConsultaMaeCtaCteDet(Convert.ToInt32(idEmpresa), idPersona, VariablesLocales.FechaHoy.Date, Opcion, EsDetraccion);
            bsBase.DataSource = olista;

            CheckBoxCab.Checked = false;
            HeaderCheckBoxClick(CheckBoxCab);
            TotalChecks = dgvDocumentosPendientes.RowCount;
            TotalCheckeados = 0;

            if (EsDetraccion)
            {
                dgvDocumentosPendientes.Columns["Saldo"].HeaderText = "Detra.";
                dgvDocumentosPendientes.Columns["Detraccion"].Visible = false;
                dgvDocumentosPendientes.Columns["indPagoDetra"].Visible = false;
                dgvDocumentosPendientes.Columns["ProgPagoDetra"].Visible = false;
            }
            else
            {
                dgvDocumentosPendientes.Columns["Saldo"].HeaderText = "Neto";
                dgvDocumentosPendientes.Columns["Detraccion"].Visible = true;
                dgvDocumentosPendientes.Columns["indPagoDetra"].Visible = true;
                dgvDocumentosPendientes.Columns["ProgPagoDetra"].Visible = true;
            }
        }

        #endregion

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            if (!ValidarGrabacion())
            {
                return;
            }

            Int32 Contador = Variables.Cero;
            oListaCtaCte = new List<CtaCteE>();

            foreach (CtaCteE item in (List<CtaCteE>)bsBase.List)
            {
                if (item.Seleccionar)
                {
                    Contador++;

                    if (item.indPagoDetra)
                    {
                        item.Saldo = item.Saldo + item.Detraccion;
                    }

                    oListaCtaCte.Add(item);
                }
            }

            if (Contador == Variables.Cero)
            {
                Global.MensajeFault("Debe seleccionar al menos un registro o Presione Cancelar.");
                return;
            }

            base.Aceptar();
        }

        public override bool ValidarGrabacion()
        {
            foreach (CtaCteE item in (List<CtaCteE>)bsBase.List)
            {
                if (item.Seleccionar)
                {
                    if (item.indPagoDetra && item.ProgPagoDetra > 0)
                    {
                        Global.MensajeComunicacion(String.Format("El documento {0} {1}-{2} ya tiene pagado su detracción en el Programa de Pago. Tiene que quitar el Check de detracción.", item.idDocumento, item.numSerie, item.numDocumento));
                        return false;
                    }
                }
            }

            return base.ValidarGrabacion();
        }

        #endregion

        #region Eventos

        private void frmCtaCtePendientes_Load(object sender, EventArgs e)
        {
            AñadirCheckBox();

            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);

            if (VieneDe != "PP") //Es diferente de programa de pago
            {
                Int32.TryParse(txtIdCliente.Text, out Int32 idCliente);
                ObtenerCtaCte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, idCliente); 
            }
        }

        private void btCliente_Click(object sender, EventArgs e)
        {
            FrmBusquedaPersona oFrm = new FrmBusquedaPersona();

            if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
            {
                txtRuc.TextChanged -= txtRuc_TextChanged;
                txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;

                txtRuc.Text = oFrm.oPersona.RUC;
                txtRazonSocial.Text = oFrm.oPersona.RazonSocial;
                txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();

                txtRuc.TextChanged += txtRuc_TextChanged;
                txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            }
        }

        private void dgvDocumentosPendientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvDocumentosPendientes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentosPendientes.Rows.Count != 0)
            {
                if (!indClickCab && e.ColumnIndex == 0)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvDocumentosPendientes[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvDocumentosPendientes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDocumentosPendientes.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDocumentosPendientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        } 

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Bloquear, Variables.SI);
                btCliente.Enabled = false;
            }
            else
            {
                txtRazonSocial.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                txtRuc.CambiaColorFondo(EnumTipoEdicionCuadros.Desbloquear);
                btCliente.Enabled = true;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRazonSocial.Text) && !chkTodos.Checked)
                {
                    Global.MensajeFault("Debe escoger un auxiliar antes de buscar. De lo contrario coloque el check de Todos.");
                    return;
                }

                ObtenerCtaCte(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, (String.IsNullOrWhiteSpace(txtIdCliente.Text) ? 0 : Convert.ToInt32(txtIdCliente.Text)));
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
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
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            btBuscar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        btBuscar.Focus();
                    }
                    else
                    {
                        txtIdCliente.Text = String.Empty;
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
                    txtRuc.TextChanged -=  txtRuc_TextChanged;
                    txtRazonSocial.TextChanged -= txtRazonSocial_TextChanged;
                    List<Persona> oListaPersonas = AgenteMaestro.Proxy.ListarPersonaPorFiltro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, "RA", txtRazonSocial.Text);

                    if (oListaPersonas.Count > Variables.ValorUno)
                    {
                        frmListarPersonasPorFiltro oFrm = new frmListarPersonasPorFiltro(oListaPersonas);

                        if (oFrm.ShowDialog() == DialogResult.OK && oFrm.oPersona != null)
                        {
                            txtIdCliente.Text = oFrm.oPersona.IdPersona.ToString();
                            txtRuc.Text = oFrm.oPersona.RUC;
                            txtRazonSocial.Text = oFrm.oPersona.RazonSocial;

                            btBuscar.Focus();
                        }
                    }
                    else if (oListaPersonas.Count == 1)
                    {
                        txtIdCliente.Text = oListaPersonas[0].IdPersona.ToString();
                        txtRuc.Text = oListaPersonas[0].RUC;
                        txtRazonSocial.Text = oListaPersonas[0].RazonSocial;

                        btBuscar.Focus();
                    }
                    else
                    {
                        txtIdCliente.Text = String.Empty;
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
            txtIdCliente.Text = String.Empty;
            txtRazonSocial.Text = string.Empty;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtIdCliente.Text = String.Empty;
            txtRuc.Text = String.Empty;
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.Pasar(e);
        }

        private void bsBase_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                lblTitPnlBase.Text = "Pendientes " + bsBase.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
