namespace ClienteWinForm.Contabilidad.CtasPorPagar.Reportes
{
    partial class frmReporteRegistroComprasPorProveedor
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cboPeriodoFin = new System.Windows.Forms.ComboBox();
            this.cboPeriodoIni = new System.Windows.Forms.ComboBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.chbProveedor = new System.Windows.Forms.CheckBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblProcesando);
            this.panel3.Controls.Add(this.pbProgress);
            this.panel3.Controls.Add(this.wbNavegador);
            this.panel3.Location = new System.Drawing.Point(3, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1085, 398);
            this.panel3.TabIndex = 290;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.White;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(733, 375);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 19);
            this.lblProcesando.TabIndex = 325;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcesando.Visible = false;
            this.lblProcesando.SizeChanged += new System.EventHandler(this.lblProcesando_SizeChanged);
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.White;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(757, 256);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(113, 105);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 324;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1083, 396);
            this.wbNavegador.TabIndex = 268;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(623, 46);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 288;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cboPeriodoFin
            // 
            this.cboPeriodoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoFin.FormattingEnabled = true;
            this.cboPeriodoFin.Location = new System.Drawing.Point(198, 29);
            this.cboPeriodoFin.Name = "cboPeriodoFin";
            this.cboPeriodoFin.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoFin.TabIndex = 350;
            // 
            // cboPeriodoIni
            // 
            this.cboPeriodoIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoIni.FormattingEnabled = true;
            this.cboPeriodoIni.Location = new System.Drawing.Point(40, 29);
            this.cboPeriodoIni.Name = "cboPeriodoIni";
            this.cboPeriodoIni.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoIni.TabIndex = 288;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(12, 33);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(23, 13);
            this.lblDe.TabIndex = 306;
            this.lblDe.Text = "Del";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 307;
            this.label4.Text = "Al";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtRazonSocial);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboAnio);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboPeriodoFin);
            this.panel2.Controls.Add(this.cboPeriodoIni);
            this.panel2.Controls.Add(this.cboMoneda);
            this.panel2.Controls.Add(this.chbProveedor);
            this.panel2.Controls.Add(this.lblDe);
            this.panel2.Controls.Add(this.txtRuc);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Location = new System.Drawing.Point(3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 88);
            this.panel2.TabIndex = 291;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 355;
            this.label3.Text = "Año";
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(355, 29);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(63, 21);
            this.cboAnio.TabIndex = 354;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(475, 29);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 288;
            // 
            // chbProveedor
            // 
            this.chbProveedor.AutoSize = true;
            this.chbProveedor.Location = new System.Drawing.Point(16, 59);
            this.chbProveedor.Name = "chbProveedor";
            this.chbProveedor.Size = new System.Drawing.Size(86, 17);
            this.chbProveedor.TabIndex = 351;
            this.chbProveedor.Text = "Proveedores";
            this.chbProveedor.UseVisualStyleBackColor = true;
            this.chbProveedor.CheckedChanged += new System.EventHandler(this.chbProveedor_CheckedChanged);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.ForeColor = System.Drawing.Color.Black;
            this.txtRuc.Location = new System.Drawing.Point(109, 57);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(89, 20);
            this.txtRuc.TabIndex = 0;
            this.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(613, 19);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Parámetros de Busqueda";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.ForeColor = System.Drawing.Color.Black;
            this.txtRazonSocial.Location = new System.Drawing.Point(204, 57);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(392, 20);
            this.txtRazonSocial.TabIndex = 356;
            this.txtRazonSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // frmReporteRegistroComprasPorProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btBuscar);
            this.MaximizeBox = false;
            this.Name = "frmReporteRegistroComprasPorProveedor";
            this.Text = "Reporte Registro de Compras Especial";
            this.Load += new System.EventHandler(this.frmReporteRegistroComprasEspecial_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.ComboBox cboPeriodoFin;
        private System.Windows.Forms.ComboBox cboPeriodoIni;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbProveedor;
        private ControlesWinForm.SuperTextBox txtRuc;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAnio;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
    }
}