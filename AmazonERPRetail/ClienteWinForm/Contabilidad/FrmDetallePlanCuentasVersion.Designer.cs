namespace ClienteWinForm.Contabilidad
{
    partial class FrmDetallePlanCuentasVersion
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label idControlLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNEstr = new System.Windows.Forms.TextBox();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.cboIFF = new System.Windows.Forms.ComboBox();
            this.cboIMoneda = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFModificacion = new System.Windows.Forms.TextBox();
            this.txtURegistro = new System.Windows.Forms.TextBox();
            this.txtUModificacion = new System.Windows.Forms.TextBox();
            this.txtFRegistro = new System.Windows.Forms.TextBox();
            descripcionLabel = new System.Windows.Forms.Label();
            idControlLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
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
            this.btCancelar.Location = new System.Drawing.Point(465, 160);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(341, 160);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(304, 22);
            this.lblTitPnlBase.Text = "Estructura de Plan de Cuentas";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(605, 25);
            this.lblTituloPrincipal.Text = "Detalle de Plan de Cuentas";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(578, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.cboIMoneda);
            this.pnlBase.Controls.Add(this.cboIFF);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(label3);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(this.txtLongitud);
            this.pnlBase.Controls.Add(descripcionLabel);
            this.pnlBase.Controls.Add(this.txtDescripcion);
            this.pnlBase.Controls.Add(idControlLabel);
            this.pnlBase.Controls.Add(this.txtNEstr);
            this.pnlBase.Location = new System.Drawing.Point(12, 31);
            this.pnlBase.Size = new System.Drawing.Size(306, 159);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNEstr, 0);
            this.pnlBase.Controls.SetChildIndex(idControlLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(descripcionLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtLongitud, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(label3, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboIFF, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboIMoneda, 0);
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(12, 58);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(61, 13);
            descripcionLabel.TabIndex = 282;
            descripcionLabel.Text = "Descripción";
            // 
            // idControlLabel
            // 
            idControlLabel.AutoSize = true;
            idControlLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idControlLabel.Location = new System.Drawing.Point(12, 35);
            idControlLabel.Name = "idControlLabel";
            idControlLabel.Size = new System.Drawing.Size(79, 13);
            idControlLabel.TabIndex = 283;
            idControlLabel.Text = "Niv. Estructura";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 83);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 13);
            label1.TabIndex = 286;
            label1.Text = "Num. Longitud";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(12, 131);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 13);
            label2.TabIndex = 288;
            label2.Text = "Ind Moneda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(12, 107);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 13);
            label3.TabIndex = 289;
            label3.Text = "Ind F.F.";
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
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(103, 56);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(184, 21);
            this.txtDescripcion.TabIndex = 281;
            // 
            // txtNEstr
            // 
            this.txtNEstr.BackColor = System.Drawing.Color.White;
            this.txtNEstr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNEstr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNEstr.Location = new System.Drawing.Point(103, 31);
            this.txtNEstr.Name = "txtNEstr";
            this.txtNEstr.Size = new System.Drawing.Size(35, 21);
            this.txtNEstr.TabIndex = 284;
            this.txtNEstr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLongitud
            // 
            this.txtLongitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLongitud.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongitud.Location = new System.Drawing.Point(103, 79);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(35, 21);
            this.txtLongitud.TabIndex = 285;
            // 
            // cboIFF
            // 
            this.cboIFF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIFF.DropDownWidth = 79;
            this.cboIFF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIFF.FormattingEnabled = true;
            this.cboIFF.Location = new System.Drawing.Point(103, 103);
            this.cboIFF.Margin = new System.Windows.Forms.Padding(2);
            this.cboIFF.Name = "cboIFF";
            this.cboIFF.Size = new System.Drawing.Size(164, 21);
            this.cboIFF.TabIndex = 290;
            // 
            // cboIMoneda
            // 
            this.cboIMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIMoneda.DropDownWidth = 79;
            this.cboIMoneda.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIMoneda.FormattingEnabled = true;
            this.cboIMoneda.Location = new System.Drawing.Point(103, 127);
            this.cboIMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cboIMoneda.Name = "cboIMoneda";
            this.cboIMoneda.Size = new System.Drawing.Size(164, 21);
            this.cboIMoneda.TabIndex = 291;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtFModificacion);
            this.pnlAuditoria.Controls.Add(this.txtURegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Controls.Add(label6);
            this.pnlAuditoria.Controls.Add(this.txtUModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFRegistro);
            this.pnlAuditoria.Controls.Add(label7);
            this.pnlAuditoria.Location = new System.Drawing.Point(320, 31);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(278, 126);
            this.pnlAuditoria.TabIndex = 257;
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
            // txtFModificacion
            // 
            this.txtFModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFModificacion.Enabled = false;
            this.txtFModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFModificacion.Location = new System.Drawing.Point(145, 95);
            this.txtFModificacion.Name = "txtFModificacion";
            this.txtFModificacion.Size = new System.Drawing.Size(125, 21);
            this.txtFModificacion.TabIndex = 304;
            // 
            // txtURegistro
            // 
            this.txtURegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtURegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtURegistro.Enabled = false;
            this.txtURegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURegistro.Location = new System.Drawing.Point(145, 27);
            this.txtURegistro.Name = "txtURegistro";
            this.txtURegistro.Size = new System.Drawing.Size(125, 21);
            this.txtURegistro.TabIndex = 300;
            // 
            // txtUModificacion
            // 
            this.txtUModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUModificacion.Enabled = false;
            this.txtUModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUModificacion.Location = new System.Drawing.Point(145, 72);
            this.txtUModificacion.Name = "txtUModificacion";
            this.txtUModificacion.Size = new System.Drawing.Size(125, 21);
            this.txtUModificacion.TabIndex = 303;
            // 
            // txtFRegistro
            // 
            this.txtFRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFRegistro.Enabled = false;
            this.txtFRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFRegistro.Location = new System.Drawing.Point(145, 49);
            this.txtFRegistro.Name = "txtFRegistro";
            this.txtFRegistro.Size = new System.Drawing.Size(125, 21);
            this.txtFRegistro.TabIndex = 301;
            // 
            // FrmDetallePlanCuentasVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 194);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "FrmDetallePlanCuentasVersion";
            this.Text = "FrmDetallePlanCuentasVersion";
            this.Load += new System.EventHandler(this.FrmDetallePlanCuentasVersion_Load);
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

        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNEstr;
        private System.Windows.Forms.ComboBox cboIMoneda;
        private System.Windows.Forms.ComboBox cboIFF;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFModificacion;
        private System.Windows.Forms.TextBox txtURegistro;
        private System.Windows.Forms.TextBox txtUModificacion;
        private System.Windows.Forms.TextBox txtFRegistro;
    }
}