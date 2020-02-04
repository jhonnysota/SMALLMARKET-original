namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteCajayBanco
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
            this.btBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCuentaIni = new ControlesWinForm.SuperTextBox();
            this.txtCuentaFin = new ControlesWinForm.SuperTextBox();
            this.btnBusquedaCuentaFin = new System.Windows.Forms.Button();
            this.btnBusquedaCuentaIni = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDesCuentaFin = new System.Windows.Forms.TextBox();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.txtDesCuentaIni = new System.Windows.Forms.TextBox();
            this.rbBancos = new System.Windows.Forms.RadioButton();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFinMes = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboInicioMes = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.btBuscar.Location = new System.Drawing.Point(1087, 16);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 294;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 359;
            this.label6.Text = "De";
            // 
            // txtCuentaIni
            // 
            this.txtCuentaIni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaIni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaIni.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaIni.Location = new System.Drawing.Point(45, 50);
            this.txtCuentaIni.Name = "txtCuentaIni";
            this.txtCuentaIni.Size = new System.Drawing.Size(61, 20);
            this.txtCuentaIni.TabIndex = 352;
            this.txtCuentaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuentaIni.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaIni.TextoVacio = "<Descripcion>";
            this.txtCuentaIni.Validating += new System.ComponentModel.CancelEventHandler(this.txtCuentaIni_Validating);
            // 
            // txtCuentaFin
            // 
            this.txtCuentaFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaFin.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaFin.Location = new System.Drawing.Point(575, 50);
            this.txtCuentaFin.Name = "txtCuentaFin";
            this.txtCuentaFin.Size = new System.Drawing.Size(59, 20);
            this.txtCuentaFin.TabIndex = 353;
            this.txtCuentaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuentaFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaFin.TextoVacio = "<Descripcion>";
            this.txtCuentaFin.Validating += new System.ComponentModel.CancelEventHandler(this.txtCuentaFin_Validating);
            // 
            // btnBusquedaCuentaFin
            // 
            this.btnBusquedaCuentaFin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaFin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaFin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusquedaCuentaFin.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaFin.Location = new System.Drawing.Point(1031, 51);
            this.btnBusquedaCuentaFin.Name = "btnBusquedaCuentaFin";
            this.btnBusquedaCuentaFin.Size = new System.Drawing.Size(25, 19);
            this.btnBusquedaCuentaFin.TabIndex = 358;
            this.btnBusquedaCuentaFin.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaFin.Click += new System.EventHandler(this.btnBusquedaCuentaFin_Click);
            // 
            // btnBusquedaCuentaIni
            // 
            this.btnBusquedaCuentaIni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusquedaCuentaIni.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaIni.Location = new System.Drawing.Point(509, 51);
            this.btnBusquedaCuentaIni.Name = "btnBusquedaCuentaIni";
            this.btnBusquedaCuentaIni.Size = new System.Drawing.Size(25, 19);
            this.btnBusquedaCuentaIni.TabIndex = 357;
            this.btnBusquedaCuentaIni.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaIni.Click += new System.EventHandler(this.btnBusquedaCuentaIni_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(547, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 356;
            this.label7.Text = "Al";
            // 
            // txtDesCuentaFin
            // 
            this.txtDesCuentaFin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuentaFin.Enabled = false;
            this.txtDesCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaFin.ForeColor = System.Drawing.Color.Blue;
            this.txtDesCuentaFin.Location = new System.Drawing.Point(636, 50);
            this.txtDesCuentaFin.Name = "txtDesCuentaFin";
            this.txtDesCuentaFin.Size = new System.Drawing.Size(393, 20);
            this.txtDesCuentaFin.TabIndex = 355;
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
            // txtDesCuentaIni
            // 
            this.txtDesCuentaIni.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuentaIni.Enabled = false;
            this.txtDesCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaIni.ForeColor = System.Drawing.Color.Blue;
            this.txtDesCuentaIni.Location = new System.Drawing.Point(108, 50);
            this.txtDesCuentaIni.Name = "txtDesCuentaIni";
            this.txtDesCuentaIni.Size = new System.Drawing.Size(399, 20);
            this.txtDesCuentaIni.TabIndex = 354;
            // 
            // rbBancos
            // 
            this.rbBancos.AutoSize = true;
            this.rbBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBancos.Location = new System.Drawing.Point(90, 27);
            this.rbBancos.Name = "rbBancos";
            this.rbBancos.Size = new System.Drawing.Size(61, 17);
            this.rbBancos.TabIndex = 318;
            this.rbBancos.Text = "Bancos";
            this.rbBancos.UseVisualStyleBackColor = true;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(950, 26);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(106, 21);
            this.cboMoneda.TabIndex = 316;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(900, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 315;
            this.label5.Text = "Moneda";
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
            this.panel3.Location = new System.Drawing.Point(3, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1143, 477);
            this.panel3.TabIndex = 293;
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1141, 475);
            this.wbNavegador.TabIndex = 268;
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Checked = true;
            this.rbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEfectivo.Location = new System.Drawing.Point(20, 27);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(64, 17);
            this.rbEfectivo.TabIndex = 317;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            this.rbEfectivo.CheckedChanged += new System.EventHandler(this.rbEfectivo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(688, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 314;
            this.label3.Text = "Mes Fin";
            // 
            // cboFinMes
            // 
            this.cboFinMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFinMes.FormattingEnabled = true;
            this.cboFinMes.Location = new System.Drawing.Point(737, 26);
            this.cboFinMes.Name = "cboFinMes";
            this.cboFinMes.Size = new System.Drawing.Size(154, 21);
            this.cboFinMes.TabIndex = 313;
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(409, 26);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(64, 21);
            this.cboAño.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(378, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año";
            // 
            // cboSucursales
            // 
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Location = new System.Drawing.Point(218, 26);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(154, 21);
            this.cboSucursales.TabIndex = 309;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(483, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Mes Ini";
            // 
            // cboInicioMes
            // 
            this.cboInicioMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInicioMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInicioMes.FormattingEnabled = true;
            this.cboInicioMes.Location = new System.Drawing.Point(529, 26);
            this.cboInicioMes.Name = "cboInicioMes";
            this.cboInicioMes.Size = new System.Drawing.Size(154, 21);
            this.cboInicioMes.TabIndex = 271;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(1077, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Sucursal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCuentaIni);
            this.panel1.Controls.Add(this.txtCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaIni);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDesCuentaFin);
            this.panel1.Controls.Add(this.txtDesCuentaIni);
            this.panel1.Controls.Add(this.rbBancos);
            this.panel1.Controls.Add(this.rbEfectivo);
            this.panel1.Controls.Add(this.cboMoneda);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboFinMes);
            this.panel1.Controls.Add(this.cboAño);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSucursales);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboInicioMes);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 78);
            this.panel1.TabIndex = 295;
            // 
            // frmReporteCajayBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 563);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmReporteCajayBanco";
            this.Text = "Reporte de Caja y Banco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteCajayBanco_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteCajayBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtCuentaIni;
        private ControlesWinForm.SuperTextBox txtCuentaFin;
        private System.Windows.Forms.Button btnBusquedaCuentaFin;
        private System.Windows.Forms.Button btnBusquedaCuentaIni;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDesCuentaFin;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.TextBox txtDesCuentaIni;
        private System.Windows.Forms.RadioButton rbBancos;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFinMes;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboInicioMes;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}