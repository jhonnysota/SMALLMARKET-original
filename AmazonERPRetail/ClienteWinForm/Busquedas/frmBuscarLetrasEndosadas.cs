using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarLetrasEndosadas : frmResponseBase
    {

        #region Eventos

        public frmBuscarLetrasEndosadas()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            FormatoGrid(dgvLetras, true);
        }

        public frmBuscarLetrasEndosadas(Int32 Auxiliar)
            :this()
        {
            idAuxiliarEndosada = Auxiliar;
            Text = "Búsqueda de Letras Endosadas hacia " + VariablesLocales.SesionUsuario.Empresa.RazonSocial;
        } 

        #endregion

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public List<PlanillaBancosE> oListaLetras = null;
        List<PlanillaBancosE> oListaLetrasBusqueda = null;
        Int32 idAuxiliarEndosada = 0;

        Int32 TotalChecks = Variables.Cero;
        Int32 TotalCheckeados = Variables.Cero;
        CheckBox CheckBoxCab = null;
        Boolean indClickCab = false;

        #endregion

        #region Eventos y procedimientos checkBox

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            indClickCab = true;

            foreach (DataGridViewRow Row in dgvLetras.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["Escoger"]).Value = HCheckBox.Checked;
            }

            dgvLetras.RefreshEdit();
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
            CheckBoxCab = new CheckBox
            {
                Size = new Size(15, 15)
            };

            // Añadiendo el CheckBox dentro de la cabecera del datagridview
            dgvLetras.Controls.Add(CheckBoxCab);
        }

        private void CambiarUbicacionCheckBox(Int32 ColumnIndex, Int32 RowIndex)
        {
            //Obtener limites de la celda de la cabecera que va a contener el checkbox
            Rectangle oRectangle = dgvLetras.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point
            {
                X = oRectangle.Location.X + (oRectangle.Width - CheckBoxCab.Width) / 2 + 1,
                Y = oRectangle.Location.Y + (oRectangle.Height - CheckBoxCab.Height) / 2 + 1
            };

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

        #region Procedimientos Heredados

        public override void Buscar()
        {
            try
            {
                bsBase.DataSource = oListaLetrasBusqueda = AgenteVentas.Proxy.ListarPlaBanLetrasEndosadas(idAuxiliarEndosada);

                CheckBoxCab.Checked = false;
                HeaderCheckBoxClick(CheckBoxCab);
                TotalChecks = bsBase.Count;
                TotalCheckeados = 0;

                if (!String.IsNullOrWhiteSpace(txtEmpresa.Text) || !String.IsNullOrWhiteSpace(txtAuxiliar.Text))
                {
                    BuscarFiltro();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void BuscarFiltro()
        {
            bsBase.DataSource = (from x in oListaLetrasBusqueda
                                 where x.RazonSocialEmpresa.ToUpper().Contains(txtEmpresa.Text.ToUpper())
                                 && x.RazonSocialAuxiliar.ToUpper().Contains(txtAuxiliar.Text.ToUpper())
                                 select x).ToList();

            lblTitPnlBase.Text = "Registros " + bsBase.Count.ToString();
        }

        public override void Aceptar()
        {
            Int32 Contador = Variables.Cero;
            oListaLetras = new List<PlanillaBancosE>();

            foreach (PlanillaBancosE item in (List<PlanillaBancosE>)bsBase.List)
            {
                if (item.Escoger)
                {
                    Contador++;
                    oListaLetras.Add(item);
                }
            }

            if (Contador == Variables.Cero)
            {
                Global.MensajeFault("Debe seleccionar al menos un registro o Presione Cancelar.");
                return;
            }

            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void frmBuscarLetrasEndosadas_Load(object sender, EventArgs e)
        {
            AñadirCheckBox();

            CheckBoxCab.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            CheckBoxCab.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
        }

        private void dgvLetras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                CambiarUbicacionCheckBox(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dgvLetras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLetras.Rows.Count != 0)
            {
                if (!indClickCab && e.ColumnIndex == 0)
                {
                    FilaCheBoxClick((DataGridViewCheckBoxCell)dgvLetras[e.ColumnIndex, e.RowIndex]);
                }
            }
        }

        private void dgvLetras_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLetras.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvLetras.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        private void bsBase_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                lblTitPnlBase.Text = "Letras " + bsBase.List.Count;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (oListaLetrasBusqueda != null && oListaLetrasBusqueda.Count > 0)
            {
                BuscarFiltro();
            }
        }

        private void txtAuxiliar_TextChanged(object sender, EventArgs e)
        {
            if (oListaLetrasBusqueda != null && oListaLetrasBusqueda.Count > 0)
            {
                BuscarFiltro();
            }
        } 

        #endregion

    }
}
