using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ClienteWinForm
{
    public partial class frmResponseBase : Form
    {
        public frmResponseBase()
        {
            InitializeComponent();
        }

        #region Overrides Form

        private const int CS_DROPSHADOW = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_IME_CHAR = 0x286;

            KeyEventArgs e = null;

            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);

                if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                {
                    frmResponseBase_KeyDown(this, e);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        #endregion

        #region Variables Internas

        Int32 Movimiento;
        Int32 valX;
        Int32 valY;

        #endregion

        #region Procedimientos

        public virtual bool ValidarIngresoVentana()
        {
            return true;
        }

        public virtual bool ValidarGrabacion()
        {
            return true;
        }

        public virtual String ValidarEntidad<T>(T entidad) where T : class
        {
            ValidationResults resultado = Validation.Validate(entidad);

            if (!resultado.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Debe validar los atributos siguientes: \n\r");

                foreach (ValidationResult item in resultado)
                {
                    sb.Append(item.Key + " - " + item.Message + "\r\n");
                }

                return sb.ToString();
            }

            return String.Empty;
        }

        public virtual void FormatoGrid(DataGridView oDgv, bool PrimerCol, int AltoCabecera = 25, int AltoFilas = 20, Boolean MostrarColor = true)
        {
            ////Para que la primera columan no aparesca
            oDgv.RowHeadersVisible = PrimerCol;
            oDgv.RowHeadersWidth = 20;

            //Inicializar propiedades básicas DataGridView.
            oDgv.BackgroundColor = Color.LightGray;
            oDgv.BorderStyle = BorderStyle.None;

            //Establecer el estilo de las filas y columnas del encabezado
            oDgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point);
            oDgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;
            oDgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            oDgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            oDgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Alternando colores en las filas
            oDgv.RowsDefaultCellStyle.BackColor = Color.White;
            if (MostrarColor)
            {
                oDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            oDgv.RowsDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

            //Valores de propiedad, conjunto adecuado para la visualización.
            oDgv.AllowUserToAddRows = false;
            oDgv.AllowUserToDeleteRows = false;
            oDgv.AllowUserToOrderColumns = false;
            oDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oDgv.MultiSelect = false;

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

        #endregion

        #region IMantenimiento

        public virtual void Nuevo()
        { 
        
        }

        public virtual void Aceptar()
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        public virtual void Cancelar()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        public virtual void Cerrar()
        {
            this.Dispose();
        }

        public virtual void Exportar()
        {
            throw new NotImplementedException();
        }

        public virtual void Buscar()
        {
            //bFlag = false;
        }        

        #endregion        

        #region Eventos para el movimiento del formulario

        private void lblTituloPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            Movimiento = 1;
            valX = e.X;
            valY = e.Y;
        }

        private void lblTituloPrincipal_MouseUp(object sender, MouseEventArgs e)
        {
            Movimiento = 0;
        }

        private void lblTituloPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movimiento == 1)
            {
                this.SetDesktopLocation(MousePosition.X - valX, MousePosition.Y - valY);
            }
        }

        #endregion

        #region Eventos

        private void frmResponseBase_Load(object sender, EventArgs e)
        {
        
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }        

        private void btCerrar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void frmResponseBase_KeyDown(object sender, KeyEventArgs e)
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
