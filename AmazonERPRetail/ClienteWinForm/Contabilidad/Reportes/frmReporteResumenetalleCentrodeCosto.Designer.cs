namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteResumenetalleCentrodeCosto
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.txtCuentaIni = new ControlesWinForm.SuperTextBox();
            this.txtCuentaFin = new ControlesWinForm.SuperTextBox();
            this.btnBusquedaCuentaFin = new System.Windows.Forms.Button();
            this.btnBusquedaCuentaIni = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesCuentaFin = new System.Windows.Forms.TextBox();
            this.txtDesCuentaIni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboNivel);
            this.panel1.Controls.Add(this.cboMoneda);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSucursales);
            this.panel1.Controls.Add(this.txtCuentaIni);
            this.panel1.Controls.Add(this.txtCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaIni);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDesCuentaFin);
            this.panel1.Controls.Add(this.txtDesCuentaIni);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpFecIni);
            this.panel1.Controls.Add(this.dtpFecFin);
            this.panel1.Controls.Add(this.lblDe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 83);
            this.panel1.TabIndex = 287;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 355;
            this.label1.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(690, 26);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(93, 21);
            this.cboMoneda.TabIndex = 354;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "Sucursal";
            // 
            // cboSucursales
            // 
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Location = new System.Drawing.Point(62, 53);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(216, 21);
            this.cboSucursales.TabIndex = 352;
            // 
            // txtCuentaIni
            // 
            this.txtCuentaIni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuentaIni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaIni.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaIni.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaIni.Location = new System.Drawing.Point(367, 28);
            this.txtCuentaIni.Name = "txtCuentaIni";
            this.txtCuentaIni.Size = new System.Drawing.Size(47, 21);
            this.txtCuentaIni.TabIndex = 2;
            this.txtCuentaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuentaIni.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaIni.TextoVacio = "<Descripcion>";
            this.txtCuentaIni.Leave += new System.EventHandler(this.txtCuentaIni_Leave);
            // 
            // txtCuentaFin
            // 
            this.txtCuentaFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuentaFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaFin.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaFin.Location = new System.Drawing.Point(366, 54);
            this.txtCuentaFin.Name = "txtCuentaFin";
            this.txtCuentaFin.Size = new System.Drawing.Size(48, 21);
            this.txtCuentaFin.TabIndex = 3;
            this.txtCuentaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuentaFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaFin.TextoVacio = "<Descripcion>";
            this.txtCuentaFin.Leave += new System.EventHandler(this.txtCuentaFin_Leave);
            // 
            // btnBusquedaCuentaFin
            // 
            this.btnBusquedaCuentaFin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaFin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaFin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaFin.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaFin.Location = new System.Drawing.Point(602, 54);
            this.btnBusquedaCuentaFin.Name = "btnBusquedaCuentaFin";
            this.btnBusquedaCuentaFin.Size = new System.Drawing.Size(25, 20);
            this.btnBusquedaCuentaFin.TabIndex = 347;
            this.btnBusquedaCuentaFin.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaFin.Click += new System.EventHandler(this.btnBusquedaCuentaFin_Click);
            // 
            // btnBusquedaCuentaIni
            // 
            this.btnBusquedaCuentaIni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaIni.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaIni.Location = new System.Drawing.Point(602, 28);
            this.btnBusquedaCuentaIni.Name = "btnBusquedaCuentaIni";
            this.btnBusquedaCuentaIni.Size = new System.Drawing.Size(25, 21);
            this.btnBusquedaCuentaIni.TabIndex = 346;
            this.btnBusquedaCuentaIni.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaIni.Click += new System.EventHandler(this.btnBusquedaCuentaIni_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 321;
            this.label5.Text = "Fin Cuenta";
            // 
            // txtDesCuentaFin
            // 
            this.txtDesCuentaFin.Enabled = false;
            this.txtDesCuentaFin.Location = new System.Drawing.Point(417, 54);
            this.txtDesCuentaFin.Name = "txtDesCuentaFin";
            this.txtDesCuentaFin.Size = new System.Drawing.Size(179, 20);
            this.txtDesCuentaFin.TabIndex = 318;
            // 
            // txtDesCuentaIni
            // 
            this.txtDesCuentaIni.Enabled = false;
            this.txtDesCuentaIni.Location = new System.Drawing.Point(418, 28);
            this.txtDesCuentaIni.Name = "txtDesCuentaIni";
            this.txtDesCuentaIni.Size = new System.Drawing.Size(178, 20);
            this.txtDesCuentaIni.TabIndex = 316;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 314;
            this.label3.Text = "Inicio Cuenta";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(48, 28);
            this.dtpFecIni.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(95, 20);
            this.dtpFecIni.TabIndex = 0;
            this.dtpFecIni.Value = new System.DateTime(2016, 1, 1, 14, 17, 0, 0);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(177, 28);
            this.dtpFecFin.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(101, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(21, 32);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(23, 13);
            this.lblDe.TabIndex = 306;
            this.lblDe.Text = "Del";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 307;
            this.label4.Text = "Al";
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
            this.labelDegradado1.Size = new System.Drawing.Size(792, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panel3.Location = new System.Drawing.Point(2, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1162, 440);
            this.panel3.TabIndex = 289;
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
            this.wbNavegador.Size = new System.Drawing.Size(1160, 438);
            this.wbNavegador.TabIndex = 268;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.btBuscar.Location = new System.Drawing.Point(847, 26);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 0;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(633, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 370;
            this.label6.Text = "Nivel C.C.";
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.DropDownWidth = 110;
            this.cboNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(690, 52);
            this.cboNivel.Margin = new System.Windows.Forms.Padding(2);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(93, 21);
            this.cboNivel.TabIndex = 369;
            // 
            // frmReporteResumenetalleCentrodeCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 535);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmReporteResumenetalleCentrodeCosto";
            this.Text = "Resumen Centro de Costos";
            this.Load += new System.EventHandler(this.frmReporteResumenetalleCentrodeCosto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtCuentaIni;
        private ControlesWinForm.SuperTextBox txtCuentaFin;
        private System.Windows.Forms.Button btnBusquedaCuentaFin;
        private System.Windows.Forms.Button btnBusquedaCuentaIni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesCuentaFin;
        private System.Windows.Forms.TextBox txtDesCuentaIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label label4;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNivel;
    }
}