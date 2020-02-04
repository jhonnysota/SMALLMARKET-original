using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Almacen;
using Entidades.Maestros;
using Infraestructura;
using Infraestructura.Recursos;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Almacen
{
    public partial class frmOrdenCompraDistrib : frmResponseBase
    {

        #region Constructores

        public frmOrdenCompraDistrib()
        {
            InitializeComponent();
            FormatoGrid(dgvListado, true);
        }

        public frmOrdenCompraDistrib(Decimal Monto, List<OrdenCompraDistriE> oListaTemp)
            : this()
        {
            txtImporteTotal.Text = Monto.ToString("N2");
            Decimal.TryParse(Monto.ToString(), out ValorTotal);
            oListaDistribucion = oListaTemp;
        } 

        #endregion

        #region Variables

        AlmacenServiceAgent AgenteAlmacen { get { return new AlmacenServiceAgent(); } }
        public List<OrdenCompraDistriE> oListaDistribucion = null;
        Decimal ValorTotal = Variables.ValorCeroDecimal;
        Boolean YaEntro = false;

        #endregion

        #region Procedimientos de Usuario

        void LlenarComboGrid()
        {
            DataGridViewComboBoxColumn oCombo = dgvListado.Columns["cboDgvIdCostos"] as DataGridViewComboBoxColumn;

            List<CCostosE> oListaCCostos = new List<CCostosE>(VariablesLocales.ListarCCostosPorSistema);
            CCostosE oItemCentro = new CCostosE() { idCCostos = "0", desTemporal = Variables.Seleccione, numNivel = 1 };
            oListaCCostos.Add(oItemCentro);

            ComboHelper.RellenarCombos<CCostosE>(oCombo, (from x in oListaCCostos
                                                          where x.numNivel == 1
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
            if (oListaDistribucion != null && oListaDistribucion.Count > Variables.Cero)
            {
                //dgvListado.CommitEdit(DataGridViewDataErrorContexts.Commit);
                Decimal TotalPorcentaje = Decimal.Round((from x in oListaDistribucion select x.Porcentaje.Value).Sum(), 2);

                if (oListaDistribucion.Count == 1)
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

            if (oListaDistribucion != null && oListaDistribucion.Count > Variables.Cero)
            {
                TotalPorcentaje = Decimal.Round((from x in oListaDistribucion select x.Porcentaje.Value).Sum(), 2);
            }

            return TotalPorcentaje;
        }

        void SumarTotales()
        {
            if (oListaDistribucion != null && oListaDistribucion.Count > Variables.Cero)
            {
                Decimal TotalPorcentaje = Decimal.Round((from x in oListaDistribucion select x.Porcentaje.Value).Sum(), 2);
                Decimal Total = Decimal.Round((from x in oListaDistribucion select x.Monto.Value).Sum(), 2);

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

        #region Procedimientos Heredados

        public override void Nuevo()
        {
            if (oListaDistribucion != null)
            {
                LlenarComboGrid();
                bsBase.DataSource = oListaDistribucion;
                bsBase.ResetBindings(false);
            }
            else
            {
                oListaDistribucion = new List<OrdenCompraDistriE>();
                bsBase.DataSource = oListaDistribucion;
                bsBase.ResetBindings(false);
            }
        }

        public override void Aceptar()
        {
            try
            {
                dgvListado.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bsBase.EndEdit();

                if (oListaDistribucion == null || oListaDistribucion.Count == 0)
                {
                    Global.MensajeAdvertencia("No se ha ingresado ningún Centro de Costos. Presione Cancelar");
                    return;
                }

                Boolean oValida = true;
                Decimal Porcentaje = SumarPorcentaje();

                if (Porcentaje != 100)
                {
                    oValida = false;
                    Global.MensajeFault("El porcentaje debe ser el 100 %");
                }

                foreach (OrdenCompraDistriE item in oListaDistribucion)
                {
                    if (item.idCCostos == "0")
                    {
                        oValida = false;
                        Global.MensajeFault("Seleccione Un Costo Para Sus Registros");
                    }
                }


                if (txtImporteTotal.Text != lblTotal.Text)
                {
                    oValida = false;
                    Global.MensajeFault("Los Totales Deben Coincidir");
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

        #region Eventos de Usuario

        private void ColumnaComboSelectionChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            object Valor = sendingCB.SelectedValue;

            if (Valor != null)
            {
                //((OrdenCompraDistriE)bsBase.Current).desCCostos = ((CCostosE)sendingCB.SelectedItem).desCCostos;
            }
        }

        #endregion

        #region Eventos

        private void frmOrdenCompraDistrib_Load(object sender, EventArgs e)
        {
            Nuevo();

            AnchoColumnas();
            SumarTotales();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bsBase.EndEdit();

            if (!RevisarPorcentaje())
            {
                LlenarComboGrid();
                OrdenCompraDistriE ItemNuevo = new OrdenCompraDistriE();

                if (oListaDistribucion.Count == 0)
                {
                    ItemNuevo.idCCostos = "0";
                    ItemNuevo.Porcentaje = 100;
                    ItemNuevo.Monto = ValorTotal;
                }
                else
                {
                    Decimal Total = SumarPorcentaje();

                    ItemNuevo.idCCostos = Variables.Cero.ToString();
                    ItemNuevo.Porcentaje = 100 - Total;
                    ItemNuevo.Monto = (100 - Total) * ValorTotal / 100;
                }

                dgvListado.CellEnter -= new DataGridViewCellEventHandler(dgvListado_CellEnter);
                oListaDistribucion.Add(ItemNuevo);
                bsBase.DataSource = oListaDistribucion;
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (oListaDistribucion != null)
            {
                if (bsBase.Current != null)
                {
                    if (Global.MensajeConfirmacion(Mensajes.AvisoEliminarFila) == DialogResult.Yes)
                    {
                        oListaDistribucion.Remove((OrdenCompraDistriE)bsBase.Current);

                        bsBase.DataSource = oListaDistribucion;
                        bsBase.ResetBindings(false);
                        SumarTotales();
                    }
                }
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
                        DataGridViewCell cellImporte = dgvListado.Rows[e.RowIndex].Cells["Monto"];
                        Decimal Porcentaje = Variables.ValorCeroDecimal;
                        Decimal.TryParse(Convert.ToString(cellPorcentaje.Value), out Porcentaje);
                        Decimal Total = (Porcentaje * ValorTotal) / 100;

                        YaEntro = true;
                        cellImporte.Value = Total;
                    }
                }

                if (!YaEntro)
                {
                    if (dgvListado.Columns[e.ColumnIndex].Name == "Monto")
                    //if (e.ColumnIndex == this.ImportePorcentaje.Index)
                    {
                        DataGridViewCell cellPorcentaje = dgvListado.Rows[e.RowIndex].Cells["Porcentaje"];
                        DataGridViewCell cellImporte = dgvListado.Rows[e.RowIndex].Cells["Monto"];
                        Decimal Total = Variables.ValorCeroDecimal;
                        Decimal.TryParse(Convert.ToString(cellImporte.Value), out Total);
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
                DataGridViewCell cellImporte = dgvListado.Rows[e.RowIndex].Cells["Monto"];

                dgvListado.CellValueChanged -= new DataGridViewCellEventHandler(dgvListado_CellValueChanged);
                cellPorcentaje.Value = Variables.ValorCeroDecimal;
                cellImporte.Value = Variables.ValorCeroDecimal;
                dgvListado.CellValueChanged += new DataGridViewCellEventHandler(dgvListado_CellValueChanged);
                SumarTotales();
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
