using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infraestructura;

namespace ClienteWinForm.Busquedas
{
    public partial class frmCambioPrecio : Form
    {
        public frmCambioPrecio(String MontoTotal_, String Porcentaje_, String Monto_)
        {
            InitializeComponent();

            txtTotal.Text = MontoTotal_;
            txtPorcentaje.Text = Porcentaje_;
            txtMontoDscto.Text = Monto_;

            //Point xy = new Point(Cursor.Position.X, Cursor.Position.Y);
            ////this.Location = new Point(xy.X, xy.Y);
            //this.SetDesktopLocation(xy.X, xy.Y);
        }

        public frmCambioPrecio(String MontoTotal_, string CambioPrecio_)
        {
            InitializeComponent();

            txtTotal.Text = MontoTotal_;
            CambioPrecio = CambioPrecio_;

            labelDegradado1.Text = "Cambio de Precio";
        }

        #region Variables

        public Decimal PrecioFinal = Variables.ValorCeroDecimal;
        public Boolean Todos = false;
        public Decimal Porcentaje = Variables.ValorCeroDecimal;
        public Decimal Monto = Variables.ValorCeroDecimal;
        Int32 Movimiento;
        Int32 valX;
        Int32 valY;
        String CambioPrecio = "N";

        #endregion Variables

        void Calculo(String Tipo)
        {
            Decimal MontoTotal = Variables.ValorCeroDecimal;
            Decimal PorcentajeDscto = Variables.ValorCeroDecimal;
            Decimal MontoDscto = Variables.ValorCeroDecimal;

            Decimal.TryParse(txtTotal.Text, out MontoTotal);
            Decimal.TryParse(txtPorcentaje.Text, out PorcentajeDscto);
            Decimal.TryParse(txtMontoDscto.Text, out MontoDscto);

            if (Tipo == "P")
            {
                Decimal Total = (PorcentajeDscto * MontoTotal) / 100;
                txtMontoDscto.Text = Total.ToString("N2"); 
            }
            else
            {
                Decimal Porcentaje = (MontoDscto * 100) / MontoTotal;
                txtPorcentaje.Text = Porcentaje.ToString("N2");
            }
        }

        #region Eventos

        private void frmCambioPrecio_Load(object sender, EventArgs e)
        {
            if (CambioPrecio == "S")
            {
                txtTotal.Enabled = true;
                chkTodos.Visible = true;
                txtPorcentaje.Visible = false;
                txtMontoDscto.Visible = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CambioPrecio == "N")
            {
                Decimal Total = Variables.ValorCeroDecimal;
                Decimal P = Variables.ValorCeroDecimal;
                Decimal M = Variables.ValorCeroDecimal;

                Decimal.TryParse(txtTotal.Text, out Total);
                Decimal.TryParse(txtPorcentaje.Text, out P);
                Decimal.TryParse(txtMontoDscto.Text, out M);

                if (P == Variables.Cero)
                {
                    Global.MensajeFault("El porcentaje esta en cero. Presione Cancelar.");
                    return;
                }

                if (M == Variables.Cero)
                {
                    Global.MensajeFault("El monto esta en cero. Presione Cancelar.");
                    return;
                }

                Porcentaje = P;
                Monto = M; 
            }
            else
            {
                Decimal.TryParse(txtTotal.Text, out PrecioFinal);
                Todos = chkTodos.Checked;
            }

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMontoDscto.TextChanged -= txtMontoDscto_TextChanged;
                Calculo("P");
                txtMontoDscto.TextChanged += txtMontoDscto_TextChanged;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void txtMontoDscto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPorcentaje.TextChanged -= txtPorcentaje_TextChanged;
                Calculo("M");
                txtPorcentaje.TextChanged += txtPorcentaje_TextChanged;
            }
            catch (Exception ex)
            {
                Global.MensajeFault(ex.Message);
            }
        }

        private void labelDegradado1_MouseDown(object sender, MouseEventArgs e)
        {
            Movimiento = 1;
            valX = e.X;
            valY = e.Y;
        }

        private void labelDegradado1_MouseUp(object sender, MouseEventArgs e)
        {
            Movimiento = 0;
        }

        private void labelDegradado1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movimiento == 1)
            {
                this.SetDesktopLocation(MousePosition.X - valX, MousePosition.Y - valY);
            }
        } 

        #endregion Eventos

    }
}
