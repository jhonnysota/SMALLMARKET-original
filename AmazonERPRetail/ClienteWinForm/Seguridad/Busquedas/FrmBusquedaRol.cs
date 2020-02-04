using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Seguridad;
using Presentadora.AgenteServicio;

namespace ClienteWinForm.Seguridad.Busquedas
{
    public partial class FrmBusquedaRol : FrmBusquedaBase
    {
        public FrmBusquedaRol()
        {
            InitializeComponent();
        }

        #region variables

        public Rol rol = null;
        List<Rol> listaroles = null;

        #endregion

        #region Procedimientos de Usuario

        void pFormatoGrid()
        {
            //Inicializar propiedades básicas DataGridView.
            dgvRol.BackgroundColor = Color.LightSteelBlue;
            dgvRol.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            //dgvActivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRol.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            dgvRol.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvRol.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

            //Valores de propiedad, conjunto adecuado para la visualización.
            dgvRol.AllowUserToAddRows = false;
            dgvRol.AllowUserToDeleteRows = false;
            dgvRol.AllowUserToOrderColumns = false;
            dgvRol.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRol.MultiSelect = false;

            dgvRol.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgvRol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            ////Para que la primera columan no aparesca
            dgvRol.RowHeadersWidth = 20;

            //Establecer el color para todas las filas y las filas alternas
            //El valor para las filas alternas anula el valor de todas las filas
            dgvRol.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRol.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;
            dgvRol.AutoResizeColumns();

            //// Attach a handler to the CellFormatting event.
            dgvRol.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvRol_CellFormatting);
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            base.Buscar();

            if (chkAnulado.Checked)
                listaroles = new SeguridadServiceAgent().Proxy.ListarRol(txtFiltro.Text, true, false);
            else
                listaroles = new SeguridadServiceAgent().Proxy.ListarRol(txtFiltro.Text, false, false);

            bsBase.DataSource = listaroles;
            dgvRol.AutoResizeColumns();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                rol = (Rol)bsBase.Current;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("NO EXITEN DATOS", "MENSAJE");
            }
            base.Aceptar();
        }

        #endregion

        #region Eventos

        private void FrmBusquedaRol_Load(object sender, EventArgs e)
        {
            pFormatoGrid();
        }
        
        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listaroles != null && listaroles.Count > 0)
            {
                List<Rol> res = (from x in listaroles where x.Nombre.Contains(txtFiltro.Text) select x).ToList();
                bsBase.DataSource = res;
            }
        }

        private void rolDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dgvRol_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvRol.Columns[0].DefaultCellStyle.Format = "000";
        }

        #endregion
    }
}
