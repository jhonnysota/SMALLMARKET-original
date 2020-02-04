namespace ClienteWinForm.Ventas
{
    partial class frmEditarVendedor
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
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
            this.cboDivision = new System.Windows.Forms.ComboBox();
            this.txtIdVendedor = new ControlesWinForm.SuperTextBox();
            this.cboEstablecimiento = new System.Windows.Forms.ComboBox();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.btBuscarVendedor = new System.Windows.Forms.Button();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(305, 18);
            this.lblTitPnlBase.Text = "Vendedor";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(317, 25);
            this.lblTituloPrincipal.Text = "";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(290, 2);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.cboDivision);
            this.pnlBase.Controls.Add(label23);
            this.pnlBase.Controls.Add(this.txtIdVendedor);
            this.pnlBase.Controls.Add(this.cboEstablecimiento);
            this.pnlBase.Controls.Add(label20);
            this.pnlBase.Controls.Add(this.txtVendedor);
            this.pnlBase.Controls.Add(this.btBuscarVendedor);
            this.pnlBase.Controls.Add(this.cboZona);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(label21);
            this.pnlBase.Location = new System.Drawing.Point(5, 29);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBase.Size = new System.Drawing.Size(307, 128);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(label21, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboZona, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarVendedor, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtVendedor, 0);
            this.pnlBase.Controls.SetChildIndex(label20, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboEstablecimiento, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdVendedor, 0);
            this.pnlBase.Controls.SetChildIndex(label23, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDivision, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(164, 164);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(40, 164);
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label23.Location = new System.Drawing.Point(6, 54);
            label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(43, 13);
            label23.TabIndex = 1618;
            label23.Text = "División";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(6, 76);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(31, 13);
            label20.TabIndex = 1616;
            label20.Text = "Zona";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(6, 103);
            label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(79, 13);
            label21.TabIndex = 1615;
            label21.Text = "Zon. Influencia";
            // 
            // cboDivision
            // 
            this.cboDivision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDivision.DropDownWidth = 128;
            this.cboDivision.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDivision.FormattingEnabled = true;
            this.cboDivision.Location = new System.Drawing.Point(88, 50);
            this.cboDivision.Margin = new System.Windows.Forms.Padding(2);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Size = new System.Drawing.Size(213, 21);
            this.cboDivision.TabIndex = 1617;
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdVendedor.BackColor = System.Drawing.Color.White;
            this.txtIdVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdVendedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdVendedor.Location = new System.Drawing.Point(88, 25);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(37, 21);
            this.txtIdVendedor.TabIndex = 1610;
            this.txtIdVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdVendedor.TextoVacio = "<Descripcion>";
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.DropDownWidth = 128;
            this.cboEstablecimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(88, 74);
            this.cboEstablecimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(213, 21);
            this.cboEstablecimiento.TabIndex = 1613;
            this.cboEstablecimiento.SelectionChangeCommitted += new System.EventHandler(this.cboEstablecimiento_SelectionChangeCommitted);
            this.cboEstablecimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboEstablecimiento_KeyPress);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtVendedor.Enabled = false;
            this.txtVendedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Location = new System.Drawing.Point(126, 25);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(151, 21);
            this.txtVendedor.TabIndex = 1611;
            this.txtVendedor.TabStop = false;
            // 
            // btBuscarVendedor
            // 
            this.btBuscarVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscarVendedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarVendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarVendedor.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarVendedor.Location = new System.Drawing.Point(279, 26);
            this.btBuscarVendedor.Name = "btBuscarVendedor";
            this.btBuscarVendedor.Size = new System.Drawing.Size(22, 19);
            this.btBuscarVendedor.TabIndex = 1609;
            this.btBuscarVendedor.TabStop = false;
            this.btBuscarVendedor.UseVisualStyleBackColor = true;
            this.btBuscarVendedor.Click += new System.EventHandler(this.btBuscarVendedor_Click);
            // 
            // cboZona
            // 
            this.cboZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.DropDownWidth = 128;
            this.cboZona.Enabled = false;
            this.cboZona.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(88, 98);
            this.cboZona.Margin = new System.Windows.Forms.Padding(2);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(213, 21);
            this.cboZona.TabIndex = 1614;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 1612;
            this.label8.Text = "Nombres";
            // 
            // frmEditarVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 192);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEditarVendedor";
            this.Text = "frmEditarVendedor";
            this.Load += new System.EventHandler(this.frmEditarVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDivision;
        private ControlesWinForm.SuperTextBox txtIdVendedor;
        private System.Windows.Forms.ComboBox cboEstablecimiento;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Button btBuscarVendedor;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Label label8;
    }
}