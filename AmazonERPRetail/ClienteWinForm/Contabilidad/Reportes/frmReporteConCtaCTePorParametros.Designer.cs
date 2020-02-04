namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteConCtaCTePorParametros
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbDetallado = new System.Windows.Forms.RadioButton();
            this.rbResumido = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.chkCuentas = new System.Windows.Forms.CheckBox();
            this.chkAuxiliares = new System.Windows.Forms.CheckBox();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.btCuenta = new System.Windows.Forms.Button();
            this.txtCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new System.Windows.Forms.TextBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.btAuxiliar = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbDetallado);
            this.panel2.Controls.Add(this.rbResumido);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Location = new System.Drawing.Point(844, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 90);
            this.panel2.TabIndex = 262;
            // 
            // rbDetallado
            // 
            this.rbDetallado.AutoSize = true;
            this.rbDetallado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDetallado.Location = new System.Drawing.Point(16, 55);
            this.rbDetallado.Name = "rbDetallado";
            this.rbDetallado.Size = new System.Drawing.Size(70, 17);
            this.rbDetallado.TabIndex = 260;
            this.rbDetallado.Text = "Detallado";
            this.rbDetallado.UseVisualStyleBackColor = true;
            // 
            // rbResumido
            // 
            this.rbResumido.AutoSize = true;
            this.rbResumido.Checked = true;
            this.rbResumido.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResumido.Location = new System.Drawing.Point(16, 33);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(71, 17);
            this.rbResumido.TabIndex = 259;
            this.rbResumido.TabStop = true;
            this.rbResumido.Text = "Resumido";
            this.rbResumido.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button4.Location = new System.Drawing.Point(1217, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 59);
            this.button4.TabIndex = 154;
            this.button4.Text = "BUSCAR";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(114, 20);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Tipo Reporte";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboEstado);
            this.panel1.Controls.Add(this.chkCuentas);
            this.panel1.Controls.Add(this.chkAuxiliares);
            this.panel1.Controls.Add(this.dtpFecIni);
            this.panel1.Controls.Add(this.lblDe);
            this.panel1.Controls.Add(this.btCuenta);
            this.panel1.Controls.Add(this.txtCuenta);
            this.panel1.Controls.Add(this.txtDesCuenta);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.btAuxiliar);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 90);
            this.panel1.TabIndex = 263;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 332;
            this.label3.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "TODOS",
            "PENDIENTES",
            "CANCELADOS"});
            this.cboEstado.Location = new System.Drawing.Point(50, 52);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(126, 21);
            this.cboEstado.TabIndex = 331;
            // 
            // chkCuentas
            // 
            this.chkCuentas.AutoSize = true;
            this.chkCuentas.Checked = true;
            this.chkCuentas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCuentas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCuentas.Location = new System.Drawing.Point(206, 54);
            this.chkCuentas.Name = "chkCuentas";
            this.chkCuentas.Size = new System.Drawing.Size(114, 17);
            this.chkCuentas.TabIndex = 328;
            this.chkCuentas.Text = "Todas las Cuentas";
            this.chkCuentas.UseVisualStyleBackColor = true;
            this.chkCuentas.CheckedChanged += new System.EventHandler(this.chkCuentas_CheckedChanged);
            // 
            // chkAuxiliares
            // 
            this.chkAuxiliares.AutoSize = true;
            this.chkAuxiliares.Checked = true;
            this.chkAuxiliares.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuxiliares.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAuxiliares.Location = new System.Drawing.Point(206, 31);
            this.chkAuxiliares.Name = "chkAuxiliares";
            this.chkAuxiliares.Size = new System.Drawing.Size(120, 17);
            this.chkAuxiliares.TabIndex = 327;
            this.chkAuxiliares.Text = "Todos los Auxiliares";
            this.chkAuxiliares.UseVisualStyleBackColor = true;
            this.chkAuxiliares.CheckedChanged += new System.EventHandler(this.chkAuxiliares_CheckedChanged);
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(50, 29);
            this.dtpFecIni.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(79, 20);
            this.dtpFecIni.TabIndex = 304;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(3, 33);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(35, 13);
            this.lblDe.TabIndex = 306;
            this.lblDe.Text = "Hasta";
            // 
            // btCuenta
            // 
            this.btCuenta.Enabled = false;
            this.btCuenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCuenta.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCuenta.Location = new System.Drawing.Point(800, 52);
            this.btCuenta.Name = "btCuenta";
            this.btCuenta.Size = new System.Drawing.Size(25, 20);
            this.btCuenta.TabIndex = 324;
            this.btCuenta.UseVisualStyleBackColor = true;
            this.btCuenta.Click += new System.EventHandler(this.btCuenta_Click);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuenta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(329, 52);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(82, 21);
            this.txtCuenta.TabIndex = 321;
            this.txtCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCuenta.TextoVacio = "<Descripcion>";
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesCuenta.Enabled = false;
            this.txtDesCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(414, 52);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(384, 21);
            this.txtDesCuenta.TabIndex = 323;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(329, 29);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(82, 21);
            this.txtRuc.TabIndex = 308;
            this.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // btAuxiliar
            // 
            this.btAuxiliar.Enabled = false;
            this.btAuxiliar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAuxiliar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btAuxiliar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAuxiliar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAuxiliar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btAuxiliar.Location = new System.Drawing.Point(800, 29);
            this.btAuxiliar.Name = "btAuxiliar";
            this.btAuxiliar.Size = new System.Drawing.Size(25, 20);
            this.btAuxiliar.TabIndex = 309;
            this.btAuxiliar.UseVisualStyleBackColor = true;
            this.btAuxiliar.Click += new System.EventHandler(this.btAuxiliar_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(414, 29);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(384, 21);
            this.txtRazonSocial.TabIndex = 310;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(835, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parametros de Busqueda";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(5, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1311, 409);
            this.panel5.TabIndex = 264;
            // 
            // frmReporteConCtaCTePorParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 512);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReporteConCtaCTePorParametros";
            this.Text = "Reporte de Cuenta Corriente - Contabilidad";
            this.Load += new System.EventHandler(this.frmReporteConCtaCTePorParametros_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbDetallado;
        private System.Windows.Forms.RadioButton rbResumido;
        protected internal System.Windows.Forms.Button button4;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.Button btAuxiliar;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.Label lblDe;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.CheckBox chkCuentas;
        private System.Windows.Forms.CheckBox chkAuxiliares;
        private System.Windows.Forms.Button btCuenta;
        private ControlesWinForm.SuperTextBox txtCuenta;
        private System.Windows.Forms.TextBox txtDesCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Panel panel5;
    }
}