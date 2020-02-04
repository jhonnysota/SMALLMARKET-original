using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Entidades.Contabilidad;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;

namespace ClienteWinForm.Contabilidad
{
    public partial class frmVoucherItemCCostos : frmResponseBase
    {

        #region Constructores
        
        public frmVoucherItemCCostos()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, true);
        }

        public frmVoucherItemCCostos(Decimal Monto)
            : this()
        {
            txtImporteTotal.Text = Monto.ToString("N2");
            Decimal.TryParse(Monto.ToString(), out ValorTotal);
        }

        public frmVoucherItemCCostos(Decimal Monto, String Tipo)
            : this()
        {
            txtImporteTotal.Text = Monto.ToString("N2");
            Decimal.TryParse(Monto.ToString(), out ValorTotal);
        }

        #endregion

        #region Variables

        public List<VoucherItemCCostosE> oLista = null;
        Decimal ValorTotal = Variables.ValorCeroDecimal;
        Boolean YaEntro = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarComboGrid()
        {
            Int32 Nivel = 1;

            if (VariablesLocales.oConParametros != null)
            {
                if (VariablesLocales.oConParametros.numNivelCCosto > 0)
                {
                    Nivel = Convert.ToInt32(VariablesLocales.oConParametros.numNivelCCosto);
                }
            }

            DataGridViewComboBoxColumn oCombo = dgvListado.Columns["cboDgvIdCostos"] as DataGridViewComboBoxColumn;

            List<CCostosE> oListaCCostos = new List<CCostosE>(VariablesLocales.ListarCCostosPorSistema);
            CCostosE oItemCentro = new CCostosE() { idCCostos = "0", desTemporal = Variables.Seleccione, numNivel = Nivel };
            oListaCCostos.Add(oItemCentro);
            
            ComboHelper.RellenarCombos<CCostosE>(oCombo, (from x in oListaCCostos 
                                                          where x.numNivel == Nivel
                                                          orderby x.idCCostos
                                                          select x).ToList(), "idCCostos", "desTemporal");
        }

        void AnchoColumnas()
        {
            dgvListado.Columns[0].Width = 250;
            dgvListado.Columns[1].Width = 85;
            dgvListado.Columns[2].Width = 85;
        }

        Boolean RevisarPorcentaje()
        {
            if (oLista != null && oLista.Count > Variables.Cero)
            {
                //dgvListado.CommitEdit(DataGridViewDataErrorContexts.Commit);
                Decimal TotalPorcentaje = Decimal.Round((from x in oLista select x.Porcentaje.Value).Sum(), 2);

                if (oLista.Count == 1)
                {
                    if (TotalPorcentaje > 100)
                    {
                        return true;
                    }    
                }
                else
                {
                    if (TotalPorcentaje > 100)
                    {
                        return true;
                    } 
                }                
            }

            return false;
        }

        Decimal SumarPorcentaje()
        {
            Decimal TotalPorcentaje = Variables.Cero;

            if (oLista != null && oLista.Count > Variables.Cero)
            {
                TotalPorcentaje = Decimal.Round((from x in oLista select x.Porcentaje.Value).Sum(), 2);
            }

            return TotalPorcentaje;
        }

        void SumarTotales()
        {
            if (oLista != null && oLista.Count > Variables.Cero)
            {
                Decimal TotalPorcentaje = Decimal.Round((from x in oLista select x.Porcentaje.Value).Sum(), 2);
                Decimal Total = Decimal.Round((from x in oLista select x.ImportePorcentaje.Value).Sum(), 2);

                lblPorcentaje.Text = TotalPorcentaje.ToString("N2");
                lblTotal.Text = Total.ToString("N2");
            }
            else
            {
                lblPorcentaje.Text = "0.00";
                lblTotal.Text = "0.00";
            }
        }

        #endregion Procedimientos de Usuario

        #region Procedimientos Heredados

        public override void Aceptar()
        {
            try
            {
                dgvListado.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bsBase.EndEdit();
                
                if (oLista == null || oLista.Count == 0)
                {
                    Global.MensajeAdvertencia("No ha de ingresado Centro de Costos");
                    return;
                }

                Boolean oValida = true;
                Decimal Porcentaje = SumarPorcentaje();

                if (Porcentaje != 100)
                {
                    oValida = false;
                    Global.MensajeFault("El porcentaje debe ser el 100 %");
                }

                if (oValida)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion Procedimientos Heredados

        #region Override

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //  Si el control DataGridView no tiene el foco...
            if (!dgvListado.Focused && !dgvListado.IsCurrentCellInEditMode)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            ////  Si la tecla presionada es distinta de la tecla Enter
            ////  abandonamos el procedimiento.
            if ((keyData != Keys.Return))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            Int32 iColumnIndex = dgvListado.CurrentCell.ColumnIndex;
            Int32 iRowIndex = dgvListado.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (iColumnIndex == dgvListado.Columns.Count - 1)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                else
                {
                    dgvListado.CurrentCell = dgvListado[iColumnIndex + 1, iRowIndex];
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion

        #region Eventos de Usuario

        private void ColumnaComboSelectionChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            object Valor = sendingCB.SelectedValue;

            if (Valor != null)
            {
                ((VoucherItemCCostosE)bsBase.Current).desCCostos = ((CCostosE)sendingCB.SelectedItem).desCCostos;
                ((VoucherItemCCostosE)bsBase.Current).TipoCC = ((CCostosE)sendingCB.SelectedItem).tipoCCosto;
            }
        }

        #endregion

        #region Eventos

        private void frmVoucherItemCCostos_Load(object sender, EventArgs e)
        {
            oLista = new List<VoucherItemCCostosE>();
            bsBase.DataSource = oLista;
            bsBase.ResetBindings(false);

            AnchoColumnas();
            SumarTotales();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (oLista != null)
            {
                if (bsBase.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oLista.Remove((VoucherItemCCostosE)bsBase.Current);

                        bsBase.DataSource = oLista;
                        bsBase.ResetBindings(false);
                        SumarTotales();
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bsBase.EndEdit();

            if (!RevisarPorcentaje())
            {
                LlenarComboGrid();
                VoucherItemCCostosE ItemNuevo = new VoucherItemCCostosE();

                if (oLista.Count == 0)
                {
                    ItemNuevo.idCCostos = "0";
                    ItemNuevo.Porcentaje = 100;
                    ItemNuevo.ImportePorcentaje = ValorTotal;
                }
                else
                {
                    Decimal Total = SumarPorcentaje();

                    ItemNuevo.idCCostos = Variables.Cero.ToString();
                    ItemNuevo.Porcentaje = 100 - Total;
                    ItemNuevo.ImportePorcentaje = (100 - Total) * ValorTotal / 100;
                }

                dgvListado.CellEnter -= new DataGridViewCellEventHandler(dgvListado_CellEnter);
                oLista.Add(ItemNuevo);
                bsBase.DataSource = oLista;
                bsBase.ResetBindings(false);

                bsBase.MoveLast();
                dgvListado.Focus();

                dgvListado.CellEnter += new DataGridViewCellEventHandler(dgvListado_CellEnter);
                SumarTotales();
            }
            else
            {
                Global.MensajeFault("Porcentaje no puede exceder al 100 %, Verifique...");
            }
        }

        private void dgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void dgvListado_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvListado.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvListado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Rows.Count > Variables.Cero)
            {
                if (!YaEntro)
                {
                    //String MyData1 = dgvListado.CurrentCell.EditedFormattedValue.ToString();
                    if (dgvListado.Columns[e.ColumnIndex].Name == "Porcentaje")
                    //if (e.ColumnIndex == this.Porcentaje.Index)
                    {
                        DataGridViewCell cellPorcentaje = dgvListado.Rows[e.RowIndex].Cells["Porcentaje"];
                        DataGridViewCell cellImporte = dgvListado.Rows[e.RowIndex].Cells["ImportePorcentaje"];
                        Decimal.TryParse(Convert.ToString(cellPorcentaje.Value), out decimal Porcentaje);
                        Decimal Total = (Porcentaje * ValorTotal) / 100;

                        YaEntro = true;
                        cellImporte.Value = Total;   
                    } 
                }

                if (!YaEntro)
                {
                    if (dgvListado.Columns[e.ColumnIndex].Name == "ImportePorcentaje")
                    //if (e.ColumnIndex == this.ImportePorcentaje.Index)
                    {
                        DataGridViewCell cellPorcentaje = dgvListado.Rows[e.RowIndex].Cells["Porcentaje"];
                        DataGridViewCell cellImporte = dgvListado.Rows[e.RowIndex].Cells["ImportePorcentaje"];
                        Decimal.TryParse(Convert.ToString(cellImporte.Value), out decimal Total);
                        Decimal Porcentaje = (Total * 100) / ValorTotal;

                        YaEntro = true;
                        cellPorcentaje.Value = Porcentaje;
                    } 
                }
            }
        }

        private void dgvListado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validando la columna de porcentaje y el total para que acepte solo números
            if (dgvListado.CurrentCell.ColumnIndex == 1 || dgvListado.CurrentCell.ColumnIndex == 2)
            {
                if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvListado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvListado.CurrentCell.ColumnIndex == 1 || dgvListado.CurrentCell.ColumnIndex == 2)
            {
                TextBox txt = e.Control as TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dgvListado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(dgvListado_KeyPress);
                }
            }

            if (dgvListado.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            {
                ComboBox oCombo = e.Control as ComboBox;
                oCombo.SelectedIndexChanged += ColumnaComboSelectionChanged;
            }
        }

        private void dgvListado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Elimina el mensaje de error de la cabecera de la fila
            dgvListado.Rows[e.RowIndex].ErrorText = String.Empty;
            SumarTotales();
            YaEntro = false;

            if (RevisarPorcentaje())
            {
                Global.MensajeFault("Porcentaje no puede exceder al 100 %, Verifique...");

                DataGridViewCell cellPorcentaje = dgvListado.Rows[e.RowIndex].Cells["Porcentaje"];
                DataGridViewCell cellImporte = dgvListado.Rows[e.RowIndex].Cells["ImportePorcentaje"];

                dgvListado.CellValueChanged -= new DataGridViewCellEventHandler(dgvListado_CellValueChanged);
                cellPorcentaje.Value = Variables.ValorCeroDecimal;
                cellImporte.Value = Variables.ValorCeroDecimal;
                dgvListado.CellValueChanged += new DataGridViewCellEventHandler(dgvListado_CellValueChanged);
                SumarTotales();
            }
        }

        #endregion Eventos

    }
}
