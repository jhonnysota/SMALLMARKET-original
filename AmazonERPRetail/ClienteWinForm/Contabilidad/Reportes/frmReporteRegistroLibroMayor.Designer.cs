namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteRegistroLibroMayor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteRegistroLibroMayor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboPeriodoFin = new System.Windows.Forms.ComboBox();
            this.cboPeriodoIni = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCuentaIni = new ControlesWinForm.SuperTextBox();
            this.txtCuentaFin = new ControlesWinForm.SuperTextBox();
            this.btnBusquedaCuentaFin = new System.Windows.Forms.Button();
            this.btnBusquedaCuentaIni = new System.Windows.Forms.Button();
            this.txtDesCuentaFin = new System.Windows.Forms.TextBox();
            this.txtDesCuentaIni = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btPle = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboPeriodoFin);
            this.panel1.Controls.Add(this.cboPeriodoIni);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSucursales);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboMonedas);
            this.panel1.Controls.Add(this.lblDe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCuentaIni);
            this.panel1.Controls.Add(this.txtCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaIni);
            this.panel1.Controls.Add(this.txtDesCuentaFin);
            this.panel1.Controls.Add(this.txtDesCuentaIni);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 99);
            this.panel1.TabIndex = 286;
            // 
            // cboPeriodoFin
            // 
            this.cboPeriodoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoFin.FormattingEnabled = true;
            this.cboPeriodoFin.Location = new System.Drawing.Point(133, 43);
            this.cboPeriodoFin.Name = "cboPeriodoFin";
            this.cboPeriodoFin.Size = new System.Drawing.Size(119, 21);
            this.cboPeriodoFin.TabIndex = 2;
            // 
            // cboPeriodoIni
            // 
            this.cboPeriodoIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoIni.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoIni.FormattingEnabled = true;
            this.cboPeriodoIni.Location = new System.Drawing.Point(10, 43);
            this.cboPeriodoIni.Name = "cboPeriodoIni";
            this.cboPeriodoIni.Size = new System.Drawing.Size(119, 21);
            this.cboPeriodoIni.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 357;
            this.label2.Text = "Sucursal";
            // 
            // cboSucursales
            // 
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Location = new System.Drawing.Point(256, 43);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(236, 21);
            this.cboSucursales.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 355;
            this.label3.Text = "Moneda";
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(494, 43);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(119, 21);
            this.cboMonedas.TabIndex = 4;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(11, 28);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(71, 13);
            this.lblDe.TabIndex = 353;
            this.lblDe.Text = "Periodo Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 354;
            this.label4.Text = "Periodo Fin";
            // 
            // txtCuentaIni
            // 
            this.txtCuentaIni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtCuentaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuentaIni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaIni.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaIni.Location = new System.Drawing.Point(14, 68);
            this.txtCuentaIni.Name = "txtCuentaIni";
            this.txtCuentaIni.Size = new System.Drawing.Size(53, 20);
            this.txtCuentaIni.TabIndex = 5;
            this.txtCuentaIni.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaIni.TextoVacio = "Cta.Inicio";
            this.txtCuentaIni.Validating += new System.ComponentModel.CancelEventHandler(this.txtCuentaIni_Validating);
            // 
            // txtCuentaFin
            // 
            this.txtCuentaFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtCuentaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuentaFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaFin.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaFin.Location = new System.Drawing.Point(331, 68);
            this.txtCuentaFin.Name = "txtCuentaFin";
            this.txtCuentaFin.Size = new System.Drawing.Size(53, 20);
            this.txtCuentaFin.TabIndex = 6;
            this.txtCuentaFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaFin.TextoVacio = "Cta.Final";
            this.txtCuentaFin.Validating += new System.ComponentModel.CancelEventHandler(this.txtCuentaFin_Validating);
            // 
            // btnBusquedaCuentaFin
            // 
            this.btnBusquedaCuentaFin.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaFin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusquedaCuentaFin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaFin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaFin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaFin.Location = new System.Drawing.Point(616, 67);
            this.btnBusquedaCuentaFin.Name = "btnBusquedaCuentaFin";
            this.btnBusquedaCuentaFin.Size = new System.Drawing.Size(24, 21);
            this.btnBusquedaCuentaFin.TabIndex = 347;
            this.btnBusquedaCuentaFin.TabStop = false;
            this.btnBusquedaCuentaFin.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaFin.Click += new System.EventHandler(this.btnBusquedaCuentaFin_Click);
            // 
            // btnBusquedaCuentaIni
            // 
            this.btnBusquedaCuentaIni.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaIni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusquedaCuentaIni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaIni.Location = new System.Drawing.Point(300, 67);
            this.btnBusquedaCuentaIni.Name = "btnBusquedaCuentaIni";
            this.btnBusquedaCuentaIni.Size = new System.Drawing.Size(24, 21);
            this.btnBusquedaCuentaIni.TabIndex = 346;
            this.btnBusquedaCuentaIni.TabStop = false;
            this.btnBusquedaCuentaIni.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaIni.Click += new System.EventHandler(this.btnBusquedaCuentaIni_Click);
            // 
            // txtDesCuentaFin
            // 
            this.txtDesCuentaFin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDesCuentaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesCuentaFin.Enabled = false;
            this.txtDesCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaFin.Location = new System.Drawing.Point(386, 68);
            this.txtDesCuentaFin.Name = "txtDesCuentaFin";
            this.txtDesCuentaFin.Size = new System.Drawing.Size(228, 20);
            this.txtDesCuentaFin.TabIndex = 318;
            this.txtDesCuentaFin.TabStop = false;
            // 
            // txtDesCuentaIni
            // 
            this.txtDesCuentaIni.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDesCuentaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesCuentaIni.Enabled = false;
            this.txtDesCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaIni.Location = new System.Drawing.Point(69, 68);
            this.txtDesCuentaIni.Name = "txtDesCuentaIni";
            this.txtDesCuentaIni.Size = new System.Drawing.Size(229, 20);
            this.txtDesCuentaIni.TabIndex = 316;
            this.txtDesCuentaIni.TabStop = false;
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
            this.labelDegradado1.Size = new System.Drawing.Size(650, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPle
            // 
            this.btPle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPle.Enabled = false;
            this.btPle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btPle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPle.Image = ((System.Drawing.Image)(resources.GetObject("btPle.Image")));
            this.btPle.Location = new System.Drawing.Point(753, 45);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 48);
            this.btPle.TabIndex = 288;
            this.btPle.UseVisualStyleBackColor = false;
            this.btPle.Click += new System.EventHandler(this.btPle_Click);
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
            this.btBuscar.Location = new System.Drawing.Point(695, 45);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 48);
            this.btBuscar.TabIndex = 287;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
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
            this.panel3.Location = new System.Drawing.Point(3, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 339);
            this.panel3.TabIndex = 289;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.White;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(687, 290);
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
            this.pbProgress.Location = new System.Drawing.Point(629, 160);
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
            this.wbNavegador.Size = new System.Drawing.Size(970, 337);
            this.wbNavegador.TabIndex = 268;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmReporteRegistroLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 448);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btPle);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmReporteRegistroLibroMayor";
            this.Text = "Reporte Libro Mayor";
            this.Load += new System.EventHandler(this.frmReporteRegistroLibroMayor_Load);
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
        private System.Windows.Forms.TextBox txtDesCuentaFin;
        private System.Windows.Forms.TextBox txtDesCuentaIni;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboPeriodoFin;
        private System.Windows.Forms.ComboBox cboPeriodoIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Timer timer;
    }
}