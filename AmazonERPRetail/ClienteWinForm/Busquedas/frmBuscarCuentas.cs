using System;
using System.Windows.Forms;

using Presentadora.AgenteServicio;
using Entidades.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace ClienteWinForm.Busquedas
{
    public partial class frmBuscarCuentas : FrmBusquedaBase
    {

        #region Constructores

        public frmBuscarCuentas()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            FormatoGrid(dgvCuentas);
            Nivel();
        }

        public frmBuscarCuentas(String TipoFondo_)
             : this()
        {
            TipoFondo = TipoFondo_;
        } 

        #endregion

        #region Variables

        public ContabilidadServiceAgent AgenteContabilidad { get { return new ContabilidadServiceAgent(); } }
        public PlanCuentasE Cuentas = null;
        String TipoFondo = String.Empty;

        #endregion

        #region Procedimientos de Usuario

        //void pFormatoGrid()
        //{
        //    //Prueba
        //    //dgvCuentas.ColumnHeadersDefaultCellStyle
        //    dgvCuentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        //    dgvCuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.GhostWhite;
        //    dgvCuentas.ColumnHeadersDefaultCellStyle.Font = new Font ("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);

        //    //Inicializar propiedades básicas DataGridView.
        //    dgvCuentas.BackgroundColor = Color.LightSteelBlue;
        //    dgvCuentas.BorderStyle = BorderStyle.None;

        //    //Establecer el estilo de las filas y columnas del encabezado
        //    //dgvActivo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    //dgvCuentas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    //dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        //    dgvCuentas.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

        //    ////Valores de propiedad, conjunto adecuado para la visualización.
        //    dgvCuentas.AllowUserToAddRows = false;
        //    dgvCuentas.AllowUserToDeleteRows = false;
        //    dgvCuentas.AllowUserToOrderColumns = false;
        //    dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvCuentas.MultiSelect = false;

        //    dgvCuentas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

        //    //dgvCuentas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        //    //dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    //// establecer ajuste de altura automático para las filas
        //    //dgvCuentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    //// establecer ajuste de anchura automático para las columnas
        //    //dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    ////Para que la primera columan no aparesca
        //    dgvCuentas.RowHeadersVisible = false;

        //    //Estableciendo el el alto de los titulos
        //    dgvCuentas.ColumnHeadersHeight = 30;

        //    //Formato para las filas
        //    DataGridViewRow lineas = dgvCuentas.RowTemplate; //Establece la plantilla para todas las filas.
        //    lineas.Height = 25;
        //    lineas.MinimumHeight = 10;
        //    dgvCuentas.Refresh();

        //}

        //void EstiloCabeceras(DataGridView dgv, DataGridViewCellPaintingEventArgs e, Image img, DGVHeaderImageAlignments Style) 
        //{
        //    Graphics gr = e.Graphics;

        //    gr.FillRectangle(new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds);
        
        //    if (img != null) 
        //    {
        //        switch (Style) 
        //        {
        //            case DGVHeaderImageAlignments.FillCell:
        //                gr.DrawImage(img, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
        //                break;
        //            case DGVHeaderImageAlignments.SingleCentered:
        //                gr.DrawImage(img, ((e.CellBounds.Width - img.Width) / 2) + e.CellBounds.X, (e.CellBounds.Height - img.Height) / 2 + e.CellBounds.Y, img.Width, img.Height);
        //                break;
        //            case DGVHeaderImageAlignments.SingleLeft:
        //                gr.DrawImage(img, e.CellBounds.X, ((e.CellBounds.Height - img.Height)/ 2) + e.CellBounds.Y, img.Width, img.Height);
        //                break;
        //            case DGVHeaderImageAlignments.SingleRight:
        //                gr.DrawImage(img, (e.CellBounds.Width - img.Width) + e.CellBounds.X, ((e.CellBounds.Height - img.Height) / 2) + e.CellBounds.Y, img.Width, img.Height);
        //                break;
        //            case DGVHeaderImageAlignments.Tile:                       
        //                TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Tile);
        //                gr.FillRectangle(br, e.ClipBounds);
        //                break;
        //            default:
        //                gr.DrawImage(img, e.CellBounds.X, e.CellBounds.Y, e.ClipBounds.Width, e.CellBounds.Height);
        //                break;
        //        }
        //    }

        //    if ((e.Value == null)) 
        //    {
        //        e.Handled = true;
        //        return;
        //    }

        //    using(StringFormat sf = new StringFormat())
        //    {
        //        switch (dgv.ColumnHeadersDefaultCellStyle.Alignment)
        //        {
        //            case DataGridViewContentAlignment.BottomCenter:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.BottomLeft:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.BottomRight:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.MiddleCenter:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.MiddleLeft:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.MiddleRight:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.NotSet:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.TopCenter:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.TopLeft:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            case DataGridViewContentAlignment.TopRight:
        //                sf.Alignment = StringAlignment.Center;
        //                sf.LineAlignment = StringAlignment.Center;
        //                break;
        //            default:
        //                break;
        //        }

        //        sf.HotkeyPrefix = HotkeyPrefix.None;
        //        sf.Trimming = StringTrimming.None;

        //        gr.DrawString(e.Value.ToString(), dgv.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor), e.CellBounds, sf);
        //    }

        //    e.Handled = true;       
        //}

        void Nivel()
        {
            try
            {
                nudNivel.Value = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
                nudNivel.Minimum = 1;
                nudNivel.Maximum = Convert.ToInt32(VariablesLocales.VersionPlanCuentasActual.UltimoNivel);
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }
        }

        #endregion

        #region Procedimientos Heredados

        protected override void Buscar()
        {
            try
            {
                Int32 Opcion = Variables.ValorUno;
                String Cuenta = txtFiltro.Text;

                if (String.IsNullOrEmpty(Cuenta.Trim()))
                {
                    Global.MensajeFault("Debe ingresar el indicio de la cuenta (10, 101, 1011...)");
                    return;
                }

                if (rbPorDescripcion.Checked)
                {
                    Opcion = 2;
                }

                bsBase.DataSource = AgenteContabilidad.Proxy.ListarPlanCuentasPorParametro(VariablesLocales.SesionUsuario.Empresa.IdEmpresa, VariablesLocales.VersionPlanCuentasActual.numVerPlanCuentas, txtFiltro.Text, Convert.ToInt32(nudNivel.Value), Opcion);
                dgvCuentas.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.MensajeError(ex.Message);
            }

            base.Buscar();
        }

        protected override void Aceptar()
        {
            if (bsBase.Count > 0)
            {
                Cuentas = (PlanCuentasE)bsBase.Current;
                base.Aceptar();
            }
            else
            {
                Global.MensajeComunicacion("Presione Cancelar...");
            }
        }

        #endregion

        #region Eventos

        private void frmBuscarCuentas_Load(object sender, EventArgs e)
        {
            txtFiltro.Text = TipoFondo;
            dgvCuentas.AutoResizeColumns();
            txtFiltro.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
        }

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Aceptar();
        }

        private void dgvCuentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1))
            {
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.Button_Gray_Stripe_01_050, DGVHeaderImageAlignments.Stretch)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.Button_Gray_Stripe_01_050, DGVHeaderImageAlignments.FillCell)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.SingleCentered)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.SingleLeft)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.SingleRight)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.AquaBall_Blue, DGVHeaderImageAlignments.Tile)
                // GridDrawCustomHeaderColumns(dgvData, e, My.Resources.Button_Gray_Stripe_01_050, DGVHeaderImageAlignments.Stretch)
                EstiloCabeceras(dgvCuentas, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.FillCell);
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleCentered)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleLeft)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.SingleRight)
                // GridDrawCustomHeaderColumns(dgvData, e, ClienteWinForm.Properties.Resources.CabeceraGrid, DGVHeaderImageAlignments.Tile)
            }
        }

        private void rbPorDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPorDescripcion.Checked == true)
            {
                txtFiltro.MaxLength = 32767;
                txtFiltro.Clear();
            }
            else
            {
                txtFiltro.MaxLength = VariablesLocales.VersionPlanCuentasActual.Longitud;
                txtFiltro.Clear();
            }
        }

        #endregion

    }
}
