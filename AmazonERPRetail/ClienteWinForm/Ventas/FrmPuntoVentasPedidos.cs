using System;
using System.Drawing;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Ventas;
using Infraestructura;

namespace ClienteWinForm.Ventas
{
    public partial class FrmPuntoVentasPedidos : Form
    {

        public FrmPuntoVentasPedidos()
        {
            InitializeComponent();
            Formato(DgvDetalle);
            Global.CrearToolTip(BtBuscar, "Presionar Tecla F1");
            Global.CrearToolTip(BtGuardar, "Presionar Tecla F5");
        }

        #region Variables

        VentasServiceAgent AgenteVentas { get { return new VentasServiceAgent(); } }
        public PedidoCabE Pedido = null; 

        #endregion

        #region Procedimientos de Usuario

        private void Formato(DataGridView oDgv)
        {
            oDgv.SuspendLayout();
            //Barra de titulos
            oDgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.Black,
                WrapMode = DataGridViewTriState.True
            };

            //La primera columna
            oDgv.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(126, 212, 255),
                Font = new Font("Tahoma", 8.25F),
                ForeColor = Color.Black
            };

            //Sin bordes
            oDgv.BorderStyle = BorderStyle.None;
            //Color de fondo
            oDgv.BackgroundColor = Color.Azure;
            //Deshabilitando el ajuste de columnas de la cabecera y la primera columna
            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //Alto de la la fila de titutlos
            oDgv.ColumnHeadersHeight = 30;
            //Ancho de la primera columna
            oDgv.RowHeadersWidth = 20;
            //Deshabilitando el ajuste de columnas y filas en el detalle
            oDgv.AllowUserToResizeColumns = false;
            oDgv.AllowUserToResizeRows = false;
            //Color de lineas
            oDgv.GridColor = Color.Black;
            //Tipo de bordes en la cabecera
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //Seleccion multuiple
            oDgv.MultiSelect = false;
            //Quitando los bordes en el detalle
            oDgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //Tipo de selección de las celdas
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Tipo de letra del detalle
            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //Alternando colores en las filas
            //oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            //oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //Color al seleccionar
            oDgv.DefaultCellStyle.SelectionForeColor = Color.White;
            oDgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 28;
            lineas.MinimumHeight = 10;

            //Formato por columnas
            oDgv.Columns["RazonSocial"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            oDgv.Columns["totTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            oDgv.Refresh();

            oDgv.ResumeLayout();
        }

        private void Buscar()
        {
            string RazonSocial = "%" + TxtRazonSocial.Text.Trim() + "%";

            BsPedidos.DataSource = AgenteVentas.Proxy.ListarPedidosPtoVta(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.SesionLocal.IdLocal, RazonSocial);
            BsPedidos.ResetBindings(false);
            DgvDetalle.Focus();
        }

        private void Aceptar()
        {
            if (BsPedidos.Current is PedidoCabE current)
            {
                Pedido = current;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region Eventos

        private void FrmPuntoVentasPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                if (VariablesLocales.SesionUsuario.Credencial == "SISTEMAS")
                {
                    DgvDetalle.Columns["idPedido"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void TxtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Global.EventoEnter(e, BtBuscar);
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    Aceptar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void FrmPuntoVentasPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Dispose();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    Aceptar();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void DgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Aceptar();
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        #endregion

    }
}
