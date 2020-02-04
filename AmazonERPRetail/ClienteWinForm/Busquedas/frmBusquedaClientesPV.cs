using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Entidades.Maestros;
using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBusquedaClientesPV : Form
    {

        #region Constructores

        public frmBusquedaClientesPV()
        {
            Global.AjustarResolucion(this);
            InitializeComponent();

            pFormatoGrid(dgvListadoClientes, false);
        }

        public frmBusquedaClientesPV(List<Persona> ListaClientes)
            : this()
        {
            if (ListaClientes != null && ListaClientes.Count > 0)
            {
                oListaReal = ListaClientes;
            }
            else
            {
                Global.MensajeComunicacion("No existe ningún articulo para la busqueda.");
            }
        } 

        #endregion

        #region Variables

        List<Persona> oListaReal = null;
        String Foco = String.Empty;
        public Persona oCliente = null;

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

        void RetornaCliente()
        {
            oCliente = (Persona)bsClientes.Current;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Eventos

        private void frmBusquedaClientesPV_Load(object sender, EventArgs e)
        {
            try
            {
                bsClientes.DataSource = oListaReal;
                bsClientes.ResetBindings(false);

                lblRegistros.Text = "Registros " + oListaReal.Count.ToString();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void dgvListadoClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (oListaReal.Count > 0)
                    {
                        RetornaCliente();
                    }
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
