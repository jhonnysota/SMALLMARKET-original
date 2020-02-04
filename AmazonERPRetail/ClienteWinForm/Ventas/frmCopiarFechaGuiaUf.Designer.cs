namespace ClienteWinForm.Contabilidad
{
    partial class frmCopiarFechaGuiaUf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDespacho = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(249, 17);
            this.lblTitPnlBase.Text = "Parámetros";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(261, 25);
            this.lblTituloPrincipal.Text = "";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(233, 2);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dtpDespacho);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Location = new System.Drawing.Point(5, 28);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBase.Size = new System.Drawing.Size(251, 57);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpDespacho, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(135, 90);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(1);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(11, 90);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(1);
            // 
            // dtpDespacho
            // 
            this.dtpDespacho.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDespacho.Location = new System.Drawing.Point(112, 26);
            this.dtpDespacho.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDespacho.Name = "dtpDespacho";
            this.dtpDespacho.Size = new System.Drawing.Size(97, 20);
            this.dtpDespacho.TabIndex = 262;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 261;
            this.label4.Text = "F. Despacho:";
            // 
            // frmCopiarFechaGuiaUf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 121);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCopiarFechaGuiaUf";
            this.Text = "Cancelación Voucher Compras";
            this.Load += new System.EventHandler(this.frmCancelacionVoucherCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpDespacho;
        private System.Windows.Forms.Label label4;
    }
}