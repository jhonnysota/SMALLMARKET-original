using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class frmListadoSelListaPrecio : FrmBusquedaBase
    {

        public frmListadoSelListaPrecio()
        {
            Global.AjustarResolucion(this);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            pFormatoGrid(dgvPrecios, false);
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        List<ListaPrecioE> oListaPrecio = null;
        public ListaPrecioE ListaPrec = new ListaPrecioE();

        #endregion

        #region Procedimientos de Usuario

        void pFormatoGrid(DataGridView oDgv, bool PrimerCol)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.FromArgb(89, 89, 89); //Fondo gris oscuro
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9.25f * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            oDgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(213, 244, 204);

            //oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            oDgv.RowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //oDgv.MultiSelect = EscogerVariasFilas;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = 35;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 30;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                oListaPrecio = AgenteVentas.Proxy.ListarPrecioPorTipo(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, true);
                bsListaPrecio.DataSource = oListaPrecio;
                lblRegistros.Text = "Registros " + oListaPrecio.Count.ToString();

                base.Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        protected override void Aceptar()
        {
            if (bsListaPrecio.Count > 0)
            {
                ListaPrec = (ListaPrecioE)bsListaPrecio.Current;
                base.Aceptar();
            }
        }

        #endregion

        #region Eventos

        private void frmListadoSelListaPrecio_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (oListaPrecio != null && oListaPrecio.Count > 0)
                {
                    Aceptar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }

}
