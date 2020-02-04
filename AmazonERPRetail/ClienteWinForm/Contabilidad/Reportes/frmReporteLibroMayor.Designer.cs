namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteLibroMayor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteLibroMayor));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbProveedor = new System.Windows.Forms.CheckBox();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.chbVerNiveles = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPeriodoFin = new System.Windows.Forms.ComboBox();
            this.cboPeriodoIni = new System.Windows.Forms.ComboBox();
            this.txtCuentaIni = new ControlesWinForm.SuperTextBox();
            this.txtCuentaFin = new ControlesWinForm.SuperTextBox();
            this.btnBusquedaCuentaFin = new System.Windows.Forms.Button();
            this.btnBusquedaCuentaIni = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesCuentaFin = new System.Windows.Forms.TextBox();
            this.txtDesCuentaIni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btExportar = new System.Windows.Forms.Button();
            this.btPle = new System.Windows.Forms.Button();
            this.cmsFormatos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmFormato1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFormato2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblProceso = new System.Windows.Forms.Label();
            this.lblDebe = new System.Windows.Forms.Label();
            this.lblHaber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel1.SuspendLayout();
            this.cmsFormatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chbProveedor);
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Controls.Add(this.chbVerNiveles);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 104);
            this.panel2.TabIndex = 288;
            // 
            // chbProveedor
            // 
            this.chbProveedor.AutoSize = true;
            this.chbProveedor.Location = new System.Drawing.Point(21, 61);
            this.chbProveedor.Name = "chbProveedor";
            this.chbProveedor.Size = new System.Drawing.Size(86, 17);
            this.chbProveedor.TabIndex = 353;
            this.chbProveedor.Text = "Proveedores";
            this.chbProveedor.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(121, 20);
            this.lblTitulo.TabIndex = 258;
            this.lblTitulo.Text = "Agrupaciones";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbVerNiveles
            // 
            this.chbVerNiveles.AutoSize = true;
            this.chbVerNiveles.Checked = true;
            this.chbVerNiveles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVerNiveles.Location = new System.Drawing.Point(21, 29);
            this.chbVerNiveles.Name = "chbVerNiveles";
            this.chbVerNiveles.Size = new System.Drawing.Size(61, 17);
            this.chbVerNiveles.TabIndex = 352;
            this.chbVerNiveles.Text = "Niveles";
            this.chbVerNiveles.UseVisualStyleBackColor = true;
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
            this.panel3.Location = new System.Drawing.Point(3, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1469, 350);
            this.panel3.TabIndex = 287;
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
            this.pbProgress.Location = new System.Drawing.Point(533, 138);
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
            this.wbNavegador.Size = new System.Drawing.Size(1467, 348);
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
            this.btBuscar.Location = new System.Drawing.Point(843, 23);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 48);
            this.btBuscar.TabIndex = 0;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboAño);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboPeriodoFin);
            this.panel1.Controls.Add(this.cboPeriodoIni);
            this.panel1.Controls.Add(this.txtCuentaIni);
            this.panel1.Controls.Add(this.txtCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaFin);
            this.panel1.Controls.Add(this.btnBusquedaCuentaIni);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDesCuentaFin);
            this.panel1.Controls.Add(this.txtDesCuentaIni);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSucursales);
            this.panel1.Controls.Add(this.lblDe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(128, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 104);
            this.panel1.TabIndex = 285;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 351;
            this.label1.Text = "De";
            // 
            // cboPeriodoFin
            // 
            this.cboPeriodoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoFin.FormattingEnabled = true;
            this.cboPeriodoFin.Location = new System.Drawing.Point(344, 27);
            this.cboPeriodoFin.Name = "cboPeriodoFin";
            this.cboPeriodoFin.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoFin.TabIndex = 2;
            // 
            // cboPeriodoIni
            // 
            this.cboPeriodoIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoIni.FormattingEnabled = true;
            this.cboPeriodoIni.Location = new System.Drawing.Point(191, 27);
            this.cboPeriodoIni.Name = "cboPeriodoIni";
            this.cboPeriodoIni.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoIni.TabIndex = 1;
            // 
            // txtCuentaIni
            // 
            this.txtCuentaIni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaIni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaIni.ForeColor = System.Drawing.Color.Black;
            this.txtCuentaIni.Location = new System.Drawing.Point(39, 74);
            this.txtCuentaIni.Name = "txtCuentaIni";
            this.txtCuentaIni.Size = new System.Drawing.Size(49, 20);
            this.txtCuentaIni.TabIndex = 4;
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
            this.txtCuentaFin.Location = new System.Drawing.Point(374, 74);
            this.txtCuentaFin.Name = "txtCuentaFin";
            this.txtCuentaFin.Size = new System.Drawing.Size(50, 20);
            this.txtCuentaFin.TabIndex = 6;
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
            this.btnBusquedaCuentaFin.Location = new System.Drawing.Point(665, 75);
            this.btnBusquedaCuentaFin.Name = "btnBusquedaCuentaFin";
            this.btnBusquedaCuentaFin.Size = new System.Drawing.Size(25, 18);
            this.btnBusquedaCuentaFin.TabIndex = 8;
            this.btnBusquedaCuentaFin.TabStop = false;
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
            this.btnBusquedaCuentaIni.Location = new System.Drawing.Point(325, 75);
            this.btnBusquedaCuentaIni.Name = "btnBusquedaCuentaIni";
            this.btnBusquedaCuentaIni.Size = new System.Drawing.Size(25, 18);
            this.btnBusquedaCuentaIni.TabIndex = 346;
            this.btnBusquedaCuentaIni.TabStop = false;
            this.btnBusquedaCuentaIni.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaIni.Click += new System.EventHandler(this.btnBusquedaCuentaIni_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(355, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 321;
            this.label5.Text = "Al";
            // 
            // txtDesCuentaFin
            // 
            this.txtDesCuentaFin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuentaFin.Enabled = false;
            this.txtDesCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaFin.Location = new System.Drawing.Point(425, 74);
            this.txtDesCuentaFin.Name = "txtDesCuentaFin";
            this.txtDesCuentaFin.Size = new System.Drawing.Size(238, 20);
            this.txtDesCuentaFin.TabIndex = 7;
            this.txtDesCuentaFin.TabStop = false;
            // 
            // txtDesCuentaIni
            // 
            this.txtDesCuentaIni.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuentaIni.Enabled = false;
            this.txtDesCuentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaIni.Location = new System.Drawing.Point(89, 74);
            this.txtDesCuentaIni.Name = "txtDesCuentaIni";
            this.txtDesCuentaIni.Size = new System.Drawing.Size(233, 20);
            this.txtDesCuentaIni.TabIndex = 5;
            this.txtDesCuentaIni.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Sucursal";
            // 
            // cboSucursales
            // 
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Location = new System.Drawing.Point(67, 51);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(398, 21);
            this.cboSucursales.TabIndex = 3;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(166, 31);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(23, 13);
            this.lblDe.TabIndex = 306;
            this.lblDe.Text = "Del";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(323, 31);
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
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(698, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExportar
            // 
            this.btExportar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btExportar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExportar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportar.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.btExportar.Location = new System.Drawing.Point(952, 23);
            this.btExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(51, 48);
            this.btExportar.TabIndex = 289;
            this.btExportar.UseVisualStyleBackColor = false;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
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
            this.btPle.Location = new System.Drawing.Point(897, 23);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 48);
            this.btPle.TabIndex = 312;
            this.btPle.UseVisualStyleBackColor = false;
            this.btPle.Click += new System.EventHandler(this.btPle_Click);
            // 
            // cmsFormatos
            // 
            this.cmsFormatos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFormatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFormato1,
            this.tsmFormato2});
            this.cmsFormatos.Name = "cmsFormatos";
            this.cmsFormatos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsFormatos.Size = new System.Drawing.Size(129, 48);
            // 
            // tsmFormato1
            // 
            this.tsmFormato1.Name = "tsmFormato1";
            this.tsmFormato1.Size = new System.Drawing.Size(128, 22);
            this.tsmFormato1.Text = "Formato 1";
            this.tsmFormato1.Click += new System.EventHandler(this.tsmFormato1_Click);
            // 
            // tsmFormato2
            // 
            this.tsmFormato2.Name = "tsmFormato2";
            this.tsmFormato2.Size = new System.Drawing.Size(128, 22);
            this.tsmFormato2.Text = "Formato 2";
            this.tsmFormato2.Click += new System.EventHandler(this.tsmFormato2_Click);
            // 
            // lblProceso
            // 
            this.lblProceso.AutoSize = true;
            this.lblProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProceso.Location = new System.Drawing.Point(1013, 26);
            this.lblProceso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProceso.Name = "lblProceso";
            this.lblProceso.Size = new System.Drawing.Size(0, 16);
            this.lblProceso.TabIndex = 314;
            // 
            // lblDebe
            // 
            this.lblDebe.AutoSize = true;
            this.lblDebe.Location = new System.Drawing.Point(1091, 65);
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(28, 13);
            this.lblDebe.TabIndex = 315;
            this.lblDebe.Text = "0.00";
            // 
            // lblHaber
            // 
            this.lblHaber.AutoSize = true;
            this.lblHaber.Location = new System.Drawing.Point(1237, 64);
            this.lblHaber.Name = "lblHaber";
            this.lblHaber.Size = new System.Drawing.Size(28, 13);
            this.lblHaber.TabIndex = 316;
            this.lblHaber.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1015, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 317;
            this.label3.Text = "Total Debe :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1166, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 318;
            this.label6.Text = "Total Haber :";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(67, 27);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(93, 21);
            this.cboAño.TabIndex = 352;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 353;
            this.label7.Text = "Del Año";
            // 
            // frmReporteLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 466);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHaber);
            this.Controls.Add(this.lblDebe);
            this.Controls.Add(this.lblProceso);
            this.Controls.Add(this.btPle);
            this.Controls.Add(this.btExportar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmReporteLibroMayor";
            this.Text = "Reporte Libro Mayor";
            this.Load += new System.EventHandler(this.frmReporteLibroMayor_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsFormatos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBusquedaCuentaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesCuentaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label label4;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private ControlesWinForm.SuperTextBox txtCuentaFin;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cboPeriodoFin;
        private System.Windows.Forms.ComboBox cboPeriodoIni;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado lblTitulo;
        private ControlesWinForm.SuperTextBox txtCuentaIni;
        private System.Windows.Forms.Button btnBusquedaCuentaIni;
        private System.Windows.Forms.TextBox txtDesCuentaIni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbVerNiveles;
        private System.Windows.Forms.CheckBox chbProveedor;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.ContextMenuStrip cmsFormatos;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato1;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato2;
        private System.Windows.Forms.Label lblProceso;
        private System.Windows.Forms.Label lblDebe;
        private System.Windows.Forms.Label lblHaber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label7;
    }
}