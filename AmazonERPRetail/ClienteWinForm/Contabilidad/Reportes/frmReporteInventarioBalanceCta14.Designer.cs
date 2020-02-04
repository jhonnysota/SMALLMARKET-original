namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteInventarioBalanceCta14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteInventarioBalanceCta14));
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.chkProveedor = new System.Windows.Forms.CheckBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.chkTodasCtas = new System.Windows.Forms.CheckBox();
            this.btnCuentaFin = new System.Windows.Forms.Button();
            this.cboFin = new System.Windows.Forms.ComboBox();
            this.txtDesCuentaFin = new System.Windows.Forms.TextBox();
            this.txtCuentaInicial = new ControlesWinForm.SuperTextBox();
            this.btnCuentaInicio = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboInicio = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCuentaFin = new ControlesWinForm.SuperTextBox();
            this.txtdesCuentaInicial = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btPle = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(182, 64);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(240, 20);
            this.txtRazonSocial.TabIndex = 325;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            // 
            // chkProveedor
            // 
            this.chkProveedor.AutoSize = true;
            this.chkProveedor.Checked = true;
            this.chkProveedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProveedor.Location = new System.Drawing.Point(10, 66);
            this.chkProveedor.Name = "chkProveedor";
            this.chkProveedor.Size = new System.Drawing.Size(75, 17);
            this.chkProveedor.TabIndex = 36;
            this.chkProveedor.TabStop = false;
            this.chkProveedor.Text = "Proveedor";
            this.chkProveedor.UseVisualStyleBackColor = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(106, 64);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(76, 20);
            this.txtRuc.TabIndex = 37;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // chkTodasCtas
            // 
            this.chkTodasCtas.AutoSize = true;
            this.chkTodasCtas.Checked = true;
            this.chkTodasCtas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasCtas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodasCtas.Location = new System.Drawing.Point(10, 26);
            this.chkTodasCtas.Name = "chkTodasCtas";
            this.chkTodasCtas.Size = new System.Drawing.Size(96, 17);
            this.chkTodasCtas.TabIndex = 31;
            this.chkTodasCtas.TabStop = false;
            this.chkTodasCtas.Text = "Todas las Ctas";
            this.chkTodasCtas.UseVisualStyleBackColor = true;
            // 
            // btnCuentaFin
            // 
            this.btnCuentaFin.Enabled = false;
            this.btnCuentaFin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCuentaFin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCuentaFin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCuentaFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentaFin.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentaFin.Image")));
            this.btnCuentaFin.Location = new System.Drawing.Point(401, 45);
            this.btnCuentaFin.Name = "btnCuentaFin";
            this.btnCuentaFin.Size = new System.Drawing.Size(20, 18);
            this.btnCuentaFin.TabIndex = 324;
            this.btnCuentaFin.TabStop = false;
            this.btnCuentaFin.UseVisualStyleBackColor = true;
            // 
            // cboFin
            // 
            this.cboFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFin.Enabled = false;
            this.cboFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFin.FormattingEnabled = true;
            this.cboFin.Location = new System.Drawing.Point(181, 55);
            this.cboFin.Name = "cboFin";
            this.cboFin.Size = new System.Drawing.Size(80, 21);
            this.cboFin.TabIndex = 23;
            // 
            // txtDesCuentaFin
            // 
            this.txtDesCuentaFin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuentaFin.Enabled = false;
            this.txtDesCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaFin.Location = new System.Drawing.Point(151, 44);
            this.txtDesCuentaFin.Name = "txtDesCuentaFin";
            this.txtDesCuentaFin.Size = new System.Drawing.Size(249, 20);
            this.txtDesCuentaFin.TabIndex = 35;
            // 
            // txtCuentaInicial
            // 
            this.txtCuentaInicial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaInicial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCuentaInicial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaInicial.Enabled = false;
            this.txtCuentaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaInicial.Location = new System.Drawing.Point(106, 24);
            this.txtCuentaInicial.Name = "txtCuentaInicial";
            this.txtCuentaInicial.Size = new System.Drawing.Size(45, 20);
            this.txtCuentaInicial.TabIndex = 32;
            this.txtCuentaInicial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuentaInicial.TextoVacio = "<Descripcion>";
            // 
            // btnCuentaInicio
            // 
            this.btnCuentaInicio.Enabled = false;
            this.btnCuentaInicio.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCuentaInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCuentaInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCuentaInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentaInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentaInicio.Image")));
            this.btnCuentaInicio.Location = new System.Drawing.Point(401, 25);
            this.btnCuentaInicio.Name = "btnCuentaInicio";
            this.btnCuentaInicio.Size = new System.Drawing.Size(20, 18);
            this.btnCuentaInicio.TabIndex = 309;
            this.btnCuentaInicio.TabStop = false;
            this.btnCuentaInicio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "Mes Ini.";
            // 
            // cboInicio
            // 
            this.cboInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInicio.Enabled = false;
            this.cboInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInicio.FormattingEnabled = true;
            this.cboInicio.Location = new System.Drawing.Point(53, 55);
            this.cboInicio.Name = "cboInicio";
            this.cboInicio.Size = new System.Drawing.Size(80, 21);
            this.cboInicio.TabIndex = 22;
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(53, 32);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(79, 21);
            this.cboAño.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Mes Fin.";
            // 
            // txtCuentaFin
            // 
            this.txtCuentaFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuentaFin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCuentaFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuentaFin.Enabled = false;
            this.txtCuentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaFin.Location = new System.Drawing.Point(106, 44);
            this.txtCuentaFin.Name = "txtCuentaFin";
            this.txtCuentaFin.Size = new System.Drawing.Size(45, 20);
            this.txtCuentaFin.TabIndex = 34;
            this.txtCuentaFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCuentaFin.TextoVacio = "<Descripcion>";
            // 
            // txtdesCuentaInicial
            // 
            this.txtdesCuentaInicial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdesCuentaInicial.Enabled = false;
            this.txtdesCuentaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesCuentaInicial.Location = new System.Drawing.Point(151, 24);
            this.txtdesCuentaInicial.Name = "txtdesCuentaInicial";
            this.txtdesCuentaInicial.ReadOnly = true;
            this.txtdesCuentaInicial.Size = new System.Drawing.Size(249, 20);
            this.txtdesCuentaInicial.TabIndex = 33;
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
            this.labelDegradado1.Size = new System.Drawing.Size(430, 19);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Cuenta Corriente / Proveedor";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(267, 19);
            this.labelDegradado3.TabIndex = 258;
            this.labelDegradado3.Text = "Buscar Año / Mes";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cboFin);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cboInicio);
            this.panel4.Controls.Add(this.cboAño);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.labelDegradado3);
            this.panel4.Location = new System.Drawing.Point(7, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 90);
            this.panel4.TabIndex = 305;
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
            this.wbNavegador.Size = new System.Drawing.Size(1128, 488);
            this.wbNavegador.TabIndex = 268;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.chkProveedor);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.chkTodasCtas);
            this.panel1.Controls.Add(this.btnCuentaFin);
            this.panel1.Controls.Add(this.txtCuentaFin);
            this.panel1.Controls.Add(this.txtDesCuentaFin);
            this.panel1.Controls.Add(this.txtCuentaInicial);
            this.panel1.Controls.Add(this.btnCuentaInicio);
            this.panel1.Controls.Add(this.txtdesCuentaInicial);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(277, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 90);
            this.panel1.TabIndex = 306;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(824, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 47);
            this.button2.TabIndex = 304;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btPle
            // 
            this.btPle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btPle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPle.Image = ((System.Drawing.Image)(resources.GetObject("btPle.Image")));
            this.btPle.Location = new System.Drawing.Point(769, 30);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 47);
            this.btPle.TabIndex = 303;
            this.btPle.TabStop = false;
            this.btPle.UseVisualStyleBackColor = false;
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
            this.btBuscar.Location = new System.Drawing.Point(714, 30);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 302;
            this.btBuscar.UseVisualStyleBackColor = false;
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
            this.panel3.Location = new System.Drawing.Point(7, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1130, 490);
            this.panel3.TabIndex = 301;
            // 
            // frmReporteInventarioBalanceCta14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 599);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btPle);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Name = "frmReporteInventarioBalanceCta14";
            this.Text = "Reporte Inventario Balance Cta. 14";
            this.Load += new System.EventHandler(this.frmReporteInventarioBalance14_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private System.Windows.Forms.CheckBox chkProveedor;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.CheckBox chkTodasCtas;
        private System.Windows.Forms.Button btnCuentaFin;
        private System.Windows.Forms.ComboBox cboFin;
        private System.Windows.Forms.TextBox txtDesCuentaFin;
        private ControlesWinForm.SuperTextBox txtCuentaInicial;
        private System.Windows.Forms.Button btnCuentaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboInicio;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtCuentaFin;
        private System.Windows.Forms.TextBox txtdesCuentaInicial;
        private MyLabelG.LabelDegradado labelDegradado1;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado labelDegradado3;
        protected internal System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
    }
}