namespace ClienteWinForm.CtasPorPagar
{
    partial class frmPlantillaItem
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label codCuentaLabel;
            System.Windows.Forms.Label indDebeHaberLabel;
            System.Windows.Forms.Label codColumnaCovenLabel;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.codCuentaTextBox = new System.Windows.Forms.TextBox();
            this.desCuentaTextBox = new System.Windows.Forms.TextBox();
            this.btn_Cuenta = new System.Windows.Forms.Button();
            this.cboDebeHaber = new System.Windows.Forms.ComboBox();
            this.cboColumnaCoVen = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            codCuentaLabel = new System.Windows.Forms.Label();
            indDebeHaberLabel = new System.Windows.Forms.Label();
            codColumnaCovenLabel = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(codColumnaCovenLabel);
            this.pnlBase.Controls.Add(this.cboColumnaCoVen);
            this.pnlBase.Controls.Add(this.cboDebeHaber);
            this.pnlBase.Controls.Add(this.btn_Cuenta);
            this.pnlBase.Controls.Add(indDebeHaberLabel);
            this.pnlBase.Controls.Add(this.desCuentaTextBox);
            this.pnlBase.Controls.Add(codCuentaLabel);
            this.pnlBase.Controls.Add(this.codCuentaTextBox);
            this.pnlBase.Location = new System.Drawing.Point(8, 28);
            this.pnlBase.Size = new System.Drawing.Size(496, 133);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.codCuentaTextBox, 0);
            this.pnlBase.Controls.SetChildIndex(codCuentaLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.desCuentaTextBox, 0);
            this.pnlBase.Controls.SetChildIndex(indDebeHaberLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.btn_Cuenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDebeHaber, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboColumnaCoVen, 0);
            this.pnlBase.Controls.SetChildIndex(codColumnaCovenLabel, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(388, 166);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(264, 166);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(494, 22);
            this.lblTitPnlBase.Text = "Detalle de Plantilla";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(786, 25);
            this.lblTituloPrincipal.Text = "Detalle de Plantilla";
            this.lblTituloPrincipal.Click += new System.EventHandler(this.lblTituloPrincipal_Click);
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.CtasPorPagar.Plantilla_Concepto_itemE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(815, 2);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(14, 102);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(14, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(14, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(14, 56);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Location = new System.Drawing.Point(10, 56);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(44, 13);
            codCuentaLabel.TabIndex = 250;
            codCuentaLabel.Text = "Cuenta:";
            // 
            // indDebeHaberLabel
            // 
            indDebeHaberLabel.AutoSize = true;
            indDebeHaberLabel.Location = new System.Drawing.Point(21, 80);
            indDebeHaberLabel.Name = "indDebeHaberLabel";
            indDebeHaberLabel.Size = new System.Drawing.Size(31, 13);
            indDebeHaberLabel.TabIndex = 252;
            indDebeHaberLabel.Text = "D/H:";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.textBox1);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(this.textBox2);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(509, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(268, 133);
            this.pnlAuditoria.TabIndex = 259;
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
            this.labelDegradado4.Size = new System.Drawing.Size(266, 20);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "FechaModificacion", true));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(123, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 304;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioRegistroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(123, 29);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioRegistroTextBox.TabIndex = 300;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioModificacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(123, 74);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioModificacionTextBox.TabIndex = 303;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "FechaRegistro", true));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(123, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 21);
            this.textBox2.TabIndex = 301;
            // 
            // codCuentaTextBox
            // 
            this.codCuentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "codCuenta", true));
            this.codCuentaTextBox.Location = new System.Drawing.Point(57, 53);
            this.codCuentaTextBox.Name = "codCuentaTextBox";
            this.codCuentaTextBox.ReadOnly = true;
            this.codCuentaTextBox.Size = new System.Drawing.Size(67, 20);
            this.codCuentaTextBox.TabIndex = 251;
            // 
            // desCuentaTextBox
            // 
            this.desCuentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "DesCuenta", true));
            this.desCuentaTextBox.Location = new System.Drawing.Point(127, 53);
            this.desCuentaTextBox.Name = "desCuentaTextBox";
            this.desCuentaTextBox.ReadOnly = true;
            this.desCuentaTextBox.Size = new System.Drawing.Size(328, 20);
            this.desCuentaTextBox.TabIndex = 252;
            // 
            // btn_Cuenta
            // 
            this.btn_Cuenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_Cuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cuenta.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btn_Cuenta.Location = new System.Drawing.Point(458, 53);
            this.btn_Cuenta.Name = "btn_Cuenta";
            this.btn_Cuenta.Size = new System.Drawing.Size(26, 20);
            this.btn_Cuenta.TabIndex = 338;
            this.btn_Cuenta.UseVisualStyleBackColor = true;
            this.btn_Cuenta.Click += new System.EventHandler(this.btn_Cuenta_Click);
            // 
            // cboDebeHaber
            // 
            this.cboDebeHaber.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsBase, "indDebeHaber", true));
            this.cboDebeHaber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDebeHaber.FormattingEnabled = true;
            this.cboDebeHaber.Location = new System.Drawing.Point(57, 76);
            this.cboDebeHaber.Name = "cboDebeHaber";
            this.cboDebeHaber.Size = new System.Drawing.Size(67, 21);
            this.cboDebeHaber.TabIndex = 339;
            // 
            // codColumnaCovenLabel
            // 
            codColumnaCovenLabel.AutoSize = true;
            codColumnaCovenLabel.Location = new System.Drawing.Point(129, 80);
            codColumnaCovenLabel.Name = "codColumnaCovenLabel";
            codColumnaCovenLabel.Size = new System.Drawing.Size(90, 13);
            codColumnaCovenLabel.TabIndex = 339;
            codColumnaCovenLabel.Text = "Tipo de Columna:";
            // 
            // cboColumnaCoVen
            // 
            this.cboColumnaCoVen.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsBase, "codColumnaCoven", true));
            this.cboColumnaCoVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnaCoVen.FormattingEnabled = true;
            this.cboColumnaCoVen.Location = new System.Drawing.Point(226, 77);
            this.cboColumnaCoVen.Name = "cboColumnaCoVen";
            this.cboColumnaCoVen.Size = new System.Drawing.Size(145, 21);
            this.cboColumnaCoVen.TabIndex = 340;
            // 
            // frmPlantillaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 208);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmPlantillaItem";
            this.Text = "frmPlantillaItem";
            this.Load += new System.EventHandler(this.frmPlantillaItem_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox desCuentaTextBox;
        private System.Windows.Forms.TextBox codCuentaTextBox;
        private System.Windows.Forms.Button btn_Cuenta;
        private System.Windows.Forms.ComboBox cboDebeHaber;
        private System.Windows.Forms.ComboBox cboColumnaCoVen;
    }
}