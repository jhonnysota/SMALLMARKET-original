namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteEstadisticoCuenta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.cboInicio = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFin = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInicioCuenta = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFinCuenta = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wbNavegadorFin = new System.Windows.Forms.Button();
            this.txtDesCuentaFin = new System.Windows.Forms.TextBox();
            this.btnBusquedaCuentaIni = new System.Windows.Forms.Button();
            this.txtDesCuentaIni = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDiarioInicial = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboDiarioInicial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSucursal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboMoneda);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 92);
            this.panel1.TabIndex = 290;
            // 
            // nudNivel
            // 
            this.nudNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNivel.Location = new System.Drawing.Point(181, 60);
            this.nudNivel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(36, 21);
            this.nudNivel.TabIndex = 319;
            this.nudNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 313;
            this.label3.Text = "Nivel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Sucursal";
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(60, 24);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(154, 21);
            this.cboSucursal.TabIndex = 309;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(60, 45);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(154, 21);
            this.cboMoneda.TabIndex = 271;
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
            this.labelDegradado1.Size = new System.Drawing.Size(220, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parametros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(50, 58);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(88, 21);
            this.cboAnio.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año :";
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
            this.btBuscar.Location = new System.Drawing.Point(930, 22);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(57, 52);
            this.btBuscar.TabIndex = 289;
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
            this.panel3.Location = new System.Drawing.Point(2, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1274, 506);
            this.panel3.TabIndex = 288;
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
            this.pbProgress.Location = new System.Drawing.Point(430, 188);
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
            this.wbNavegador.Size = new System.Drawing.Size(1272, 504);
            this.wbNavegador.TabIndex = 268;
            // 
            // cboInicio
            // 
            this.cboInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInicio.FormattingEnabled = true;
            this.cboInicio.Location = new System.Drawing.Point(50, 31);
            this.cboInicio.Name = "cboInicio";
            this.cboInicio.Size = new System.Drawing.Size(88, 21);
            this.cboInicio.TabIndex = 321;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 322;
            this.label7.Text = "De :";
            // 
            // cboFin
            // 
            this.cboFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFin.FormattingEnabled = true;
            this.cboFin.Location = new System.Drawing.Point(170, 31);
            this.cboFin.Name = "cboFin";
            this.cboFin.Size = new System.Drawing.Size(88, 21);
            this.cboFin.TabIndex = 323;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 324;
            this.label8.Text = "Al :";
            // 
            // txtInicioCuenta
            // 
            this.txtInicioCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInicioCuenta.BackColor = System.Drawing.Color.White;
            this.txtInicioCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInicioCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInicioCuenta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicioCuenta.Location = new System.Drawing.Point(95, 32);
            this.txtInicioCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtInicioCuenta.Name = "txtInicioCuenta";
            this.txtInicioCuenta.Size = new System.Drawing.Size(54, 20);
            this.txtInicioCuenta.TabIndex = 317;
            this.txtInicioCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtInicioCuenta.TextoVacio = "<Descripcion>";
            this.txtInicioCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtInicioCuenta_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 316;
            this.label6.Text = "Fin Cuenta :";
            // 
            // txtFinCuenta
            // 
            this.txtFinCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFinCuenta.BackColor = System.Drawing.Color.White;
            this.txtFinCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFinCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFinCuenta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinCuenta.Location = new System.Drawing.Point(94, 59);
            this.txtFinCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtFinCuenta.Name = "txtFinCuenta";
            this.txtFinCuenta.Size = new System.Drawing.Size(55, 20);
            this.txtFinCuenta.TabIndex = 318;
            this.txtFinCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFinCuenta.TextoVacio = "<Descripcion>";
            this.txtFinCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtFinCuenta_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 315;
            this.label5.Text = "Inicio Cuenta :";
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
            this.labelDegradado2.Size = new System.Drawing.Size(422, 20);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Por Cuentas";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button2.Location = new System.Drawing.Point(1217, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 59);
            this.button2.TabIndex = 154;
            this.button2.Text = "BUSCAR";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.wbNavegadorFin);
            this.panel2.Controls.Add(this.txtDesCuentaFin);
            this.panel2.Controls.Add(this.btnBusquedaCuentaIni);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDesCuentaIni);
            this.panel2.Controls.Add(this.txtFinCuenta);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtInicioCuenta);
            this.panel2.Location = new System.Drawing.Point(227, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 91);
            this.panel2.TabIndex = 320;
            // 
            // wbNavegadorFin
            // 
            this.wbNavegadorFin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.wbNavegadorFin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.wbNavegadorFin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.wbNavegadorFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wbNavegadorFin.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.wbNavegadorFin.Location = new System.Drawing.Point(385, 59);
            this.wbNavegadorFin.Name = "wbNavegadorFin";
            this.wbNavegadorFin.Size = new System.Drawing.Size(25, 20);
            this.wbNavegadorFin.TabIndex = 350;
            this.wbNavegadorFin.UseVisualStyleBackColor = true;
            this.wbNavegadorFin.Click += new System.EventHandler(this.wbNavegadorFin_Click);
            // 
            // txtDesCuentaFin
            // 
            this.txtDesCuentaFin.Enabled = false;
            this.txtDesCuentaFin.Location = new System.Drawing.Point(154, 59);
            this.txtDesCuentaFin.Name = "txtDesCuentaFin";
            this.txtDesCuentaFin.Size = new System.Drawing.Size(225, 20);
            this.txtDesCuentaFin.TabIndex = 349;
            // 
            // btnBusquedaCuentaIni
            // 
            this.btnBusquedaCuentaIni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBusquedaCuentaIni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusquedaCuentaIni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusquedaCuentaIni.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btnBusquedaCuentaIni.Location = new System.Drawing.Point(385, 31);
            this.btnBusquedaCuentaIni.Name = "btnBusquedaCuentaIni";
            this.btnBusquedaCuentaIni.Size = new System.Drawing.Size(25, 20);
            this.btnBusquedaCuentaIni.TabIndex = 348;
            this.btnBusquedaCuentaIni.UseVisualStyleBackColor = true;
            this.btnBusquedaCuentaIni.Click += new System.EventHandler(this.btnBusquedaCuentaIni_Click);
            // 
            // txtDesCuentaIni
            // 
            this.txtDesCuentaIni.Enabled = false;
            this.txtDesCuentaIni.Location = new System.Drawing.Point(154, 31);
            this.txtDesCuentaIni.Name = "txtDesCuentaIni";
            this.txtDesCuentaIni.Size = new System.Drawing.Size(225, 20);
            this.txtDesCuentaIni.TabIndex = 347;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.nudNivel);
            this.panel4.Controls.Add(this.cboFin);
            this.panel4.Controls.Add(this.labelDegradado3);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cboInicio);
            this.panel4.Controls.Add(this.cboAnio);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(652, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 91);
            this.panel4.TabIndex = 321;
            // 
            // button3
            // 
            this.button3.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button3.Location = new System.Drawing.Point(1217, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 59);
            this.button3.TabIndex = 154;
            this.button3.Text = "BUSCAR";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(270, 20);
            this.labelDegradado3.TabIndex = 258;
            this.labelDegradado3.Text = "Por Fecha";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 316;
            this.label9.Text = "Diario";
            // 
            // cboDiarioInicial
            // 
            this.cboDiarioInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiarioInicial.DropDownWidth = 200;
            this.cboDiarioInicial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDiarioInicial.FormattingEnabled = true;
            this.cboDiarioInicial.Location = new System.Drawing.Point(60, 66);
            this.cboDiarioInicial.Name = "cboDiarioInicial";
            this.cboDiarioInicial.Size = new System.Drawing.Size(154, 21);
            this.cboDiarioInicial.TabIndex = 315;
            // 
            // frmReporteEstadisticoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 618);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Name = "frmReporteEstadisticoCuenta";
            this.Text = " Saldo Mensual por Cuenta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteSaldos_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteSaldos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMoneda;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.NumericUpDown nudNivel;
        private System.Windows.Forms.ComboBox cboInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFin;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtInicioCuenta;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtFinCuenta;
        private System.Windows.Forms.Label label5;
        private MyLabelG.LabelDegradado labelDegradado2;
        protected internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        protected internal System.Windows.Forms.Button button3;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.Button btnBusquedaCuentaIni;
        private System.Windows.Forms.TextBox txtDesCuentaIni;
        private System.Windows.Forms.Button wbNavegadorFin;
        private System.Windows.Forms.TextBox txtDesCuentaFin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboDiarioInicial;
    }
}