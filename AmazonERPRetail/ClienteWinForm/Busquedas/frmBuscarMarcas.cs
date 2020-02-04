using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.Generales;
using Presentadora.AgenteServicio;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarMarcas : FrmBusquedaBase
    {

        public frmBuscarMarcas(Int32 idMarca_)
        {
            InitializeComponent();
            FormatoGrid(dgvMarcas);
            idMarca = idMarca_;
        }

        #region Variables

        GeneralesServiceAgent AgenteGeneral { get { return new GeneralesServiceAgent(); } }
        public Marca Marcas = null;
        Int32 idMarca;

        #endregion

        #region Procedimientos Usuario

        //void pFormatoGrid()
        //{
        //    //Inicializar propiedades básicas DataGridView.
        //    dgvMarcas.BackgroundColor = Color.LightSteelBlue;
        //    dgvMarcas.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    //dgvActivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgvMarcas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    dgvMarcas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvMarcas.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    //Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvMarcas.AllowUserToOrderColumns = false;
        //    dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvMarcas.MultiSelect = false;

        //    dgvMarcas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    // establecer ajuste de altura automático para las filas
        //    dgvMarcas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    // establecer ajuste de anchura automático para las columnas
        //    dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    ////dgvdetalle.RowHeadersVisible = false;
        //    dgvMarcas.RowHeadersWidth = 20;

        //    //Color de fondo cuando la celda no este seleccionada
        //    //dgvActivo.RowHeadersDefaultCellStyle.SelectionBackColor = Color.YellowGreen;

        //    //Establecer el color para todas las filas y las filas alternas
        //    //El valor para las filas alternas anula el valor de todas las filas
        //    dgvMarcas.RowsDefaultCellStyle.BackColor = Color.White;
        //    dgvMarcas.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

        //    //// Attach a handler to the CellFormatting event.
        //    dgvMarcas.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvMarcas_CellFormatting);

        //}

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                StringBuilder cadBusqueda = new StringBuilder();
                String cad = string.Empty;

                cadBusqueda.Append(txtFiltro.Text);
                cadBusqueda.Append("%");
                cad = cadBusqueda.ToString();

                bsBase.DataSource = AgenteGeneral.Proxy.BuscarMarcaPorDescripcion(idMarca, cad);

                base.Buscar();

                if (dgvMarcas.Rows.Count >= 1)
                {
                    dgvMarcas.Focus();

                }
                else
                {
                    txtFiltro.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            try
            {
                if (bsBase.Count > 0)
                {
                    Marcas = (Marca)bsBase.Current;
                    base.Aceptar();
                }
                else
                {
                    Global.MensajeComunicacion("No hay datos, presione el botón Cancelar.");
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarMarcas_Load(object sender, EventArgs e)
        {
            //pFormatoGrid();
            Buscar();
         
        }

        private void dgvMarcas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvMarcas.Columns[0].DefaultCellStyle.Format = "000";
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Aceptar();
            }
        }

        private void dgvMarcas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                EstiloCabeceras(dgvMarcas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
            }
        }

        private void dgvMarcas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtFiltro.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }
        }
        
        #endregion






    }
}
