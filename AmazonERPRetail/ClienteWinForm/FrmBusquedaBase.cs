using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm
{
    public partial class FrmBusquedaBase : Form
    {

        public FrmBusquedaBase()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Global.AjustarResolucion(this);
            InitializeComponent();
        }

        #region Procedimientos de Usuario
        
        public void FormatoGrid(DataGridView oDgv, Boolean Multilinea = false)
        {
            oDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SlateGray;
            oDgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightGray;
            oDgv.BorderStyle = BorderStyle.FixedSingle;

            ////Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = Multilinea;

            oDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            oDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            //dgvCuentas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //// establecer ajuste de altura automático para las filas
            //dgvCuentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //// establecer ajuste de anchura automático para las columnas
            //dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = false;

            //Estableciendo el el alto de los titulos
            oDgv.ColumnHeadersHeight = 25;

            //Formato para las filas
            DataGridViewRow lineas = oDgv.RowTemplate; //Establece la plantilla para todas las filas.
            lineas.Height = 20;
            lineas.MinimumHeight = 10;
            oDgv.Refresh();
        }

        public void EstiloCabeceras(DataGridView dgv, DataGridViewCellPaintingEventArgs e, Image img, DGVHeaderImageAlignments Style)
        {
            Graphics gr = e.Graphics;

            gr.FillRectangle(new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);

            if (img != null)
            {
                switch (Style)
                {
                    case DGVHeaderImageAlignments.FillCell:
                        gr.DrawImage(img, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                        break;
                    case DGVHeaderImageAlignments.SingleCentered:
                        gr.DrawImage(img, ((e.CellBounds.Width - img.Width) / 2) + e.CellBounds.X, (e.CellBounds.Height - img.Height) / 2 + e.CellBounds.Y, img.Width, img.Height);
                        break;
                    case DGVHeaderImageAlignments.SingleLeft:
                        gr.DrawImage(img, e.CellBounds.X, ((e.CellBounds.Height - img.Height) / 2) + e.CellBounds.Y, img.Width, img.Height);
                        break;
                    case DGVHeaderImageAlignments.SingleRight:
                        gr.DrawImage(img, (e.CellBounds.Width - img.Width) + e.CellBounds.X, ((e.CellBounds.Height - img.Height) / 2) + e.CellBounds.Y, img.Width, img.Height);
                        break;
                    case DGVHeaderImageAlignments.Tile:
                        TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Tile);
                        gr.FillRectangle(br, e.ClipBounds);
                        break;
                    default:
                        gr.DrawImage(img, e.CellBounds.X, e.CellBounds.Y, e.ClipBounds.Width, e.CellBounds.Height);
                        break;
                }
            }

            if ((e.Value == null))
            {
                e.Handled = true;
                return;
            }

            using (StringFormat sf = new StringFormat())
            {
                switch (dgv.ColumnHeadersDefaultCellStyle.Alignment)
                {
                    case DataGridViewContentAlignment.BottomCenter:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.BottomLeft:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.BottomRight:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.MiddleCenter:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.MiddleLeft:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.MiddleRight:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.NotSet:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.TopCenter:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.TopLeft:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case DataGridViewContentAlignment.TopRight:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    default:
                        break;
                }

                sf.HotkeyPrefix = HotkeyPrefix.None;
                sf.Trimming = StringTrimming.None;

                gr.DrawString(e.Value.ToString(), dgv.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor), e.CellBounds, sf);
            }

            e.Handled = true;
        } 
        
        #endregion

        #region Metodos a Heredar

        protected virtual void Cancelar()
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        protected virtual void Buscar()
        {
            gbResultados.Text = "Registros Encontrados " + bsBase.Count.ToString();
        }

        protected virtual void Aceptar()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void FrmBusquedaBase_Load(object sender, EventArgs e)
        {
            ToolTip ttBusqueda = new ToolTip();
            ttBusqueda.IsBalloon = true;
            ttBusqueda.SetToolTip(btnBuscar, "Empezar la busqueda");
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            Global.EventoEnter(e, btnBuscar);
        }

        private void FrmBusquedaBase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: //Busqueda de Registros
                    Buscar();
                    break;
                case Keys.F5: //Aceptar
                    Aceptar();
                    break;
                case Keys.Escape: //Salir del formulario
                    Cancelar();
                    break;
                default:
                    break;
            }
        }       

        #endregion

    }
}
