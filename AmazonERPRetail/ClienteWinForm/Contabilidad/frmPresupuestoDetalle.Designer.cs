namespace ClienteWinForm.Contabilidad
{
    partial class frmPresupuestoDetalle
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label idControlLabel;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label3;
            this.txtEEFF = new System.Windows.Forms.TextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btItem = new System.Windows.Forms.Button();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.txtTEXTO = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            idControlLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(463, 165);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(339, 165);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(607, 25);
            this.lblTituloPrincipal.Text = "Presupuesto Detalle";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(574, 3);
            this.btCerrar.Visible = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtTEXTO);
            this.pnlBase.Controls.Add(this.cboMes);
            this.pnlBase.Controls.Add(this.btItem);
            this.pnlBase.Controls.Add(label3);
            this.pnlBase.Controls.Add(this.txtMonto);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(idControlLabel);
            this.pnlBase.Controls.Add(this.txtEEFF);
            this.pnlBase.Size = new System.Drawing.Size(307, 126);
            this.pnlBase.Controls.SetChildIndex(this.txtEEFF, 0);
            this.pnlBase.Controls.SetChildIndex(idControlLabel, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMonto, 0);
            this.pnlBase.Controls.SetChildIndex(label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.btItem, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMes, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTEXTO, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(13, 63);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(26, 13);
            label1.TabIndex = 297;
            label1.Text = "Mes";
            // 
            // idControlLabel
            // 
            idControlLabel.AutoSize = true;
            idControlLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idControlLabel.Location = new System.Drawing.Point(13, 35);
            idControlLabel.Name = "idControlLabel";
            idControlLabel.Size = new System.Drawing.Size(53, 13);
            idControlLabel.TabIndex = 294;
            idControlLabel.Text = "EEFFItem";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(36, 100);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(97, 13);
            label4.TabIndex = 6;
            label4.Text = "Fecha Modificación";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(36, 77);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 13);
            label5.TabIndex = 4;
            label5.Text = "Usuario Modificación";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(36, 32);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 13);
            label6.TabIndex = 0;
            label6.Text = "Usuario Registro";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(36, 54);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(79, 13);
            label7.TabIndex = 2;
            label7.Text = "Fecha Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(13, 88);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 13);
            label3.TabIndex = 303;
            label3.Text = "Monto";
            // 
            // txtEEFF
            // 
            this.txtEEFF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtEEFF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEEFF.Enabled = false;
            this.txtEEFF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEEFF.Location = new System.Drawing.Point(104, 30);
            this.txtEEFF.Name = "txtEEFF";
            this.txtEEFF.Size = new System.Drawing.Size(133, 21);
            this.txtEEFF.TabIndex = 295;
            this.txtEEFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Controls.Add(label6);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label7);
            this.pnlAuditoria.Location = new System.Drawing.Point(321, 31);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(278, 126);
            this.pnlAuditoria.TabIndex = 258;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(276, 20);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(145, 95);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(125, 21);
            this.txtFechaModificacion.TabIndex = 304;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuarioRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(145, 27);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(125, 21);
            this.txtUsuarioRegistro.TabIndex = 300;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuarioModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(145, 72);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(125, 21);
            this.txtUsuarioModificacion.TabIndex = 303;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(145, 49);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(125, 21);
            this.txtFechaRegistro.TabIndex = 301;
            // 
            // txtMonto
            // 
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(104, 87);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(80, 21);
            this.txtMonto.TabIndex = 302;
            // 
            // btItem
            // 
            this.btItem.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btItem.Location = new System.Drawing.Point(260, 30);
            this.btItem.Name = "btItem";
            this.btItem.Size = new System.Drawing.Size(25, 21);
            this.btItem.TabIndex = 341;
            this.btItem.TabStop = false;
            this.btItem.UseVisualStyleBackColor = true;
            this.btItem.Click += new System.EventHandler(this.btItem_Click);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.DropDownWidth = 79;
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(104, 60);
            this.cboMes.Margin = new System.Windows.Forms.Padding(2);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(80, 21);
            this.cboMes.TabIndex = 343;
            // 
            // txtTEXTO
            // 
            this.txtTEXTO.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTEXTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTEXTO.Enabled = false;
            this.txtTEXTO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTEXTO.Location = new System.Drawing.Point(243, 30);
            this.txtTEXTO.Name = "txtTEXTO";
            this.txtTEXTO.Size = new System.Drawing.Size(11, 21);
            this.txtTEXTO.TabIndex = 344;
            this.txtTEXTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTEXTO.Visible = false;
            // 
            // frmPresupuestoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 206);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmPresupuestoDetalle";
            this.Text = "frmPresupuestoDetalle";
            this.Load += new System.EventHandler(this.frmPresupuestoDetalle_Load);
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
        private System.Windows.Forms.TextBox txtEEFF;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btItem;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.TextBox txtTEXTO;
    }
}