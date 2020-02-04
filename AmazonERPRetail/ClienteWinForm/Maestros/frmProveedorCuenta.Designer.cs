namespace ClienteWinForm.Maestros
{
    partial class frmProveedorCuenta
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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtInter = new System.Windows.Forms.TextBox();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboCuenta = new System.Windows.Forms.ComboBox();
            this.txtDesBanco = new System.Windows.Forms.TextBox();
            this.btCuenta = new System.Windows.Forms.Button();
            this.rbCta = new System.Windows.Forms.RadioButton();
            this.rbCtaInter = new System.Windows.Forms.RadioButton();
            this.chkBancoDefecto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(369, 18);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(658, 25);
            this.lblTituloPrincipal.Text = "Proveedor Cuenta";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(631, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.chkBancoDefecto);
            this.pnlBase.Controls.Add(this.rbCtaInter);
            this.pnlBase.Controls.Add(this.rbCta);
            this.pnlBase.Controls.Add(this.btCuenta);
            this.pnlBase.Controls.Add(this.txtDesBanco);
            this.pnlBase.Controls.Add(label8);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(this.cboCuenta);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Controls.Add(this.txtInter);
            this.pnlBase.Controls.Add(this.txtNumCuenta);
            this.pnlBase.Location = new System.Drawing.Point(7, 29);
            this.pnlBase.Size = new System.Drawing.Size(371, 171);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumCuenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtInter, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboCuenta, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesBanco, 0);
            this.pnlBase.Controls.SetChildIndex(this.btCuenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.rbCta, 0);
            this.pnlBase.Controls.SetChildIndex(this.rbCtaInter, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkBancoDefecto, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(525, 164);
            this.btCancelar.Size = new System.Drawing.Size(112, 27);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(401, 164);
            this.btAceptar.Size = new System.Drawing.Size(112, 27);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(10, 98);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 13);
            label6.TabIndex = 439;
            label6.Text = "Moneda";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(10, 75);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 13);
            label7.TabIndex = 440;
            label7.Text = "Tipo Cuenta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(10, 52);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(36, 13);
            label8.TabIndex = 441;
            label8.Text = "Banco";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label1);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(381, 29);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(268, 122);
            this.pnlAuditoria.TabIndex = 502;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(8, 95);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(118, 91);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(137, 20);
            this.txtModifica.TabIndex = 0;
            this.txtModifica.TabStop = false;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(118, 47);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(137, 20);
            this.txtRegistro.TabIndex = 0;
            this.txtRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(118, 25);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(137, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(118, 69);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(137, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // txtInter
            // 
            this.txtInter.Location = new System.Drawing.Point(123, 139);
            this.txtInter.Name = "txtInter";
            this.txtInter.Size = new System.Drawing.Size(195, 20);
            this.txtInter.TabIndex = 6;
            this.txtInter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInter_KeyPress);
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(123, 117);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(195, 20);
            this.txtNumCuenta.TabIndex = 5;
            this.txtNumCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCuenta_KeyPress);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(123, 94);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(138, 21);
            this.cboMoneda.TabIndex = 4;
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Location = new System.Drawing.Point(123, 71);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(138, 21);
            this.cboCuenta.TabIndex = 3;
            this.cboCuenta.SelectionChangeCommitted += new System.EventHandler(this.cboCuenta_SelectionChangeCommitted);
            // 
            // txtDesBanco
            // 
            this.txtDesBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesBanco.Enabled = false;
            this.txtDesBanco.Location = new System.Drawing.Point(123, 48);
            this.txtDesBanco.Name = "txtDesBanco";
            this.txtDesBanco.Size = new System.Drawing.Size(214, 20);
            this.txtDesBanco.TabIndex = 2;
            this.txtDesBanco.TabStop = false;
            // 
            // btCuenta
            // 
            this.btCuenta.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCuenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCuenta.Location = new System.Drawing.Point(339, 48);
            this.btCuenta.Name = "btCuenta";
            this.btCuenta.Size = new System.Drawing.Size(24, 20);
            this.btCuenta.TabIndex = 443;
            this.btCuenta.TabStop = false;
            this.btCuenta.UseVisualStyleBackColor = true;
            this.btCuenta.Click += new System.EventHandler(this.btCuenta_Click);
            // 
            // rbCta
            // 
            this.rbCta.AutoSize = true;
            this.rbCta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbCta.Checked = true;
            this.rbCta.Location = new System.Drawing.Point(9, 119);
            this.rbCta.Name = "rbCta";
            this.rbCta.Size = new System.Drawing.Size(110, 17);
            this.rbCta.TabIndex = 444;
            this.rbCta.TabStop = true;
            this.rbCta.Text = "Cuenta.                ";
            this.rbCta.UseVisualStyleBackColor = true;
            // 
            // rbCtaInter
            // 
            this.rbCtaInter.AutoSize = true;
            this.rbCtaInter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbCtaInter.Location = new System.Drawing.Point(9, 141);
            this.rbCtaInter.Name = "rbCtaInter";
            this.rbCtaInter.Size = new System.Drawing.Size(109, 17);
            this.rbCtaInter.TabIndex = 445;
            this.rbCtaInter.Text = "Cta. Interbancaria";
            this.rbCtaInter.UseVisualStyleBackColor = true;
            // 
            // chkBancoDefecto
            // 
            this.chkBancoDefecto.AutoSize = true;
            this.chkBancoDefecto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBancoDefecto.Location = new System.Drawing.Point(9, 30);
            this.chkBancoDefecto.Name = "chkBancoDefecto";
            this.chkBancoDefecto.Size = new System.Drawing.Size(128, 17);
            this.chkBancoDefecto.TabIndex = 1;
            this.chkBancoDefecto.Text = "Banco por Defecto    ";
            this.chkBancoDefecto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 18);
            this.label1.TabIndex = 429;
            this.label1.Text = "Auditoria";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProveedorCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 205);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmProveedorCuenta";
            this.Text = "frmProveedorCuenta";
            this.Load += new System.EventHandler(this.frmProveedorCuenta_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.TextBox txtInter;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.ComboBox cboCuenta;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.TextBox txtDesBanco;
        private System.Windows.Forms.Button btCuenta;
        private System.Windows.Forms.CheckBox chkBancoDefecto;
        private System.Windows.Forms.RadioButton rbCtaInter;
        private System.Windows.Forms.RadioButton rbCta;
        private System.Windows.Forms.Label label1;
    }
}