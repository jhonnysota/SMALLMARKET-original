using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Entidades.Almacen;

namespace ClienteWinForm.Almacen
{
    public partial class frmEntradaDetalleSalidasLote : Form
    {

        public frmEntradaDetalleSalidasLote()
        {
            InitializeComponent();
            FormatoGrid(dgvitems, true);
        }

        public frmEntradaDetalleSalidasLote(List<MovimientoAlmacenE> ListaSalidas)
            :this()
        {
            bsDetalle.DataSource = ListaSalidas;
            bsDetalle.ResetBindings(false);
        }

        public void FormatoGrid(DataGridView oDgv, bool PrimerCol, Boolean EscogerVariasFilas = false, Int32 AltoCabecera = 25, Int32 AltoFilas = 20, Boolean MostrarColorAlterno = true, float tamLetraCabecera = 8.25f, float tamLetraDetalle = 8)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightSteelBlue;

            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            //oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", tamLetraCabecera * 96f / CreateGraphics().DpiX, FontStyle.Bold, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;

            if (MostrarColorAlterno)
            {
                oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            //oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", tamLetraDetalle * 96f / CreateGraphics().DpiX, FontStyle.Regular, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = EscogerVariasFilas;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = AltoCabecera;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = AltoFilas;
            lineas.MinimumHeight = 10;

            oDgv.Refresh();
        }

    }
}
