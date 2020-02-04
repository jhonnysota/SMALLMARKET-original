namespace ClienteWinForm.Contabilidad
{
    partial class frmCopiarVoucherCompras
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
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpProceso = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(246, 135);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(1);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(122, 135);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(1);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(437, 22);
            this.lblTitPnlBase.Text = "Parámetros";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(457, 25);
            this.lblTituloPrincipal.Text = "";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(428, 3);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dtpProceso);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.cboPeriodo);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.cboFile);
            this.pnlBase.Controls.Add(this.cboLibro);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBase.Size = new System.Drawing.Size(439, 101);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboLibro, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboFile, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboPeriodo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpProceso, 0);
            // 
            // cboLibro
            // 
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(53, 31);
            this.cboLibro.Margin = new System.Windows.Forms.Padding(2);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(252, 21);
            this.cboLibro.TabIndex = 252;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(53, 53);
            this.cboFile.Margin = new System.Windows.Forms.Padding(2);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(252, 21);
            this.cboFile.TabIndex = 254;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 255;
            this.label1.Text = "Libro :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 256;
            this.label2.Text = "File :";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(53, 75);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(142, 21);
            this.cboPeriodo.TabIndex = 257;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 258;
            this.label3.Text = "Periodo :";
            // 
            // dtpProceso
            // 
            this.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProceso.Location = new System.Drawing.Point(260, 76);
            this.dtpProceso.Margin = new System.Windows.Forms.Padding(2);
            this.dtpProceso.Name = "dtpProceso";
            this.dtpProceso.Size = new System.Drawing.Size(89, 20);
            this.dtpProceso.TabIndex = 262;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 261;
            this.label4.Text = "F. Proceso:";
            // 
            // frmCopiarVoucherCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 164);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCopiarVoucherCompras";
            this.Text = "Cancelación Voucher Compras";
            this.Load += new System.EventHandler(this.frmCancelacionVoucherCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpProceso;
        private System.Windows.Forms.Label label4;
    }
}