namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteEEFFGananciasyPerdidasListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteEEFFGananciasyPerdidasListado));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.btnVerCuentas = new System.Windows.Forms.Button();
            this.btnArchivoXls = new System.Windows.Forms.Button();
            this.dgvPivot = new System.Windows.Forms.DataGridView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbTipoReporteCCostos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTipoReporteMes = new System.Windows.Forms.RadioButton();
            this.cboEEFF = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnl01 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chbtipo_cambio = new System.Windows.Forms.CheckBox();
            this.txttipocambio = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboMesFinal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbAcumulado = new System.Windows.Forms.CheckBox();
            this.pnlCCostos = new System.Windows.Forms.Panel();
            this.chbListaCCostos = new System.Windows.Forms.CheckedListBox();
            this.lnkTodos = new System.Windows.Forms.LinkLabel();
            this.chbindCCostos = new System.Windows.Forms.CheckBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.btPle = new System.Windows.Forms.Button();
            this.chkMostrar = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl01.SuspendLayout();
            this.pnlCCostos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbProgress);
            this.panel2.Controls.Add(this.btnVerCuentas);
            this.panel2.Controls.Add(this.btnArchivoXls);
            this.panel2.Controls.Add(this.dgvPivot);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(192, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 499);
            this.panel2.TabIndex = 297;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.BackColor = System.Drawing.Color.SlateGray;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(451, 2);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(22, 19);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 347;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // btnVerCuentas
            // 
            this.btnVerCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerCuentas.Location = new System.Drawing.Point(479, 2);
            this.btnVerCuentas.Name = "btnVerCuentas";
            this.btnVerCuentas.Size = new System.Drawing.Size(158, 19);
            this.btnVerCuentas.TabIndex = 251;
            this.btnVerCuentas.Text = "Ver Cuentas / Fórmula";
            this.btnVerCuentas.UseVisualStyleBackColor = true;
            this.btnVerCuentas.Visible = false;
            this.btnVerCuentas.Click += new System.EventHandler(this.btnVerCuentas_Click);
            // 
            // btnArchivoXls
            // 
            this.btnArchivoXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchivoXls.Location = new System.Drawing.Point(640, 2);
            this.btnArchivoXls.Name = "btnArchivoXls";
            this.btnArchivoXls.Size = new System.Drawing.Size(158, 19);
            this.btnArchivoXls.TabIndex = 250;
            this.btnArchivoXls.Text = "Exportar Datos a Excel";
            this.btnArchivoXls.UseVisualStyleBackColor = true;
            this.btnArchivoXls.Visible = false;
            this.btnArchivoXls.Click += new System.EventHandler(this.btnArchivoXls_Click);
            // 
            // dgvPivot
            // 
            this.dgvPivot.AllowUserToAddRows = false;
            this.dgvPivot.AllowUserToDeleteRows = false;
            this.dgvPivot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPivot.ContextMenuStrip = this.cmsMenu;
            this.dgvPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPivot.EnableHeadersVisualStyles = false;
            this.dgvPivot.Location = new System.Drawing.Point(0, 23);
            this.dgvPivot.Name = "dgvPivot";
            this.dgvPivot.ReadOnly = true;
            this.dgvPivot.Size = new System.Drawing.Size(801, 474);
            this.dgvPivot.TabIndex = 248;
            this.dgvPivot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPivot_CellDoubleClick);
            this.dgvPivot.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPivot_CellFormatting);
            // 
            // cmsMenu
            // 
            this.cmsMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCuentas,
            this.tsmiExcel});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(192, 48);
            // 
            // tsmiCuentas
            // 
            this.tsmiCuentas.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.tsmiCuentas.Name = "tsmiCuentas";
            this.tsmiCuentas.Size = new System.Drawing.Size(191, 22);
            this.tsmiCuentas.Text = "Ver Cuentas/Fórmulas";
            this.tsmiCuentas.Click += new System.EventHandler(this.tsmiCuentas_Click);
            // 
            // tsmiExcel
            // 
            this.tsmiExcel.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.tsmiExcel.Name = "tsmiExcel";
            this.tsmiExcel.Size = new System.Drawing.Size(191, 22);
            this.tsmiExcel.Text = "Exportar a Excel";
            this.tsmiExcel.Click += new System.EventHandler(this.tsmiExcel_Click);
            // 
            // lblregistros
            // 
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.ForeColor = System.Drawing.Color.White;
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblregistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblregistros.Size = new System.Drawing.Size(801, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "Registros 0";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdbTipoReporteCCostos);
            this.panel1.Controls.Add(this.chkMostrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdbTipoReporteMes);
            this.panel1.Controls.Add(this.cboEEFF);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 122);
            this.panel1.TabIndex = 350;
            // 
            // rdbTipoReporteCCostos
            // 
            this.rdbTipoReporteCCostos.AutoSize = true;
            this.rdbTipoReporteCCostos.Location = new System.Drawing.Point(91, 93);
            this.rdbTipoReporteCCostos.Name = "rdbTipoReporteCCostos";
            this.rdbTipoReporteCCostos.Size = new System.Drawing.Size(89, 17);
            this.rdbTipoReporteCCostos.TabIndex = 350;
            this.rdbTipoReporteCCostos.Text = "Por C. Costos";
            this.rdbTipoReporteCCostos.UseVisualStyleBackColor = true;
            this.rdbTipoReporteCCostos.CheckedChanged += new System.EventHandler(this.rdbTipoReporteCCostos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 267;
            this.label1.Text = "Reporte";
            // 
            // rdbTipoReporteMes
            // 
            this.rdbTipoReporteMes.AutoSize = true;
            this.rdbTipoReporteMes.Checked = true;
            this.rdbTipoReporteMes.Location = new System.Drawing.Point(8, 93);
            this.rdbTipoReporteMes.Name = "rdbTipoReporteMes";
            this.rdbTipoReporteMes.Size = new System.Drawing.Size(75, 17);
            this.rdbTipoReporteMes.TabIndex = 254;
            this.rdbTipoReporteMes.TabStop = true;
            this.rdbTipoReporteMes.Text = "Por Meses";
            this.rdbTipoReporteMes.UseVisualStyleBackColor = true;
            // 
            // cboEEFF
            // 
            this.cboEEFF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEEFF.DropDownWidth = 300;
            this.cboEEFF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEEFF.FormattingEnabled = true;
            this.cboEEFF.Location = new System.Drawing.Point(2, 40);
            this.cboEEFF.Margin = new System.Windows.Forms.Padding(2);
            this.cboEEFF.Name = "cboEEFF";
            this.cboEEFF.Size = new System.Drawing.Size(180, 21);
            this.cboEEFF.TabIndex = 2;
            this.cboEEFF.SelectionChangeCommitted += new System.EventHandler(this.cboEEFF_SelectionChangeCommitted);
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
            this.labelDegradado1.Size = new System.Drawing.Size(185, 18);
            this.labelDegradado1.TabIndex = 253;
            this.labelDegradado1.Text = "Informe";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl01
            // 
            this.pnl01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl01.Controls.Add(this.label3);
            this.pnl01.Controls.Add(this.chbtipo_cambio);
            this.pnl01.Controls.Add(this.txttipocambio);
            this.pnl01.Controls.Add(this.label2);
            this.pnl01.Controls.Add(this.cboNivel);
            this.pnl01.Controls.Add(this.cboMoneda);
            this.pnl01.Controls.Add(this.cboMesFinal);
            this.pnl01.Controls.Add(this.label5);
            this.pnl01.Controls.Add(this.cboAnio);
            this.pnl01.Controls.Add(this.label4);
            this.pnl01.Controls.Add(this.chbAcumulado);
            this.pnl01.Controls.Add(this.pnlCCostos);
            this.pnl01.Controls.Add(this.labelDegradado2);
            this.pnl01.Location = new System.Drawing.Point(3, 128);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(187, 298);
            this.pnl01.TabIndex = 351;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 368;
            this.label3.Text = "Nivel C.C.";
            // 
            // chbtipo_cambio
            // 
            this.chbtipo_cambio.AutoSize = true;
            this.chbtipo_cambio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbtipo_cambio.Location = new System.Drawing.Point(47, 98);
            this.chbtipo_cambio.Name = "chbtipo_cambio";
            this.chbtipo_cambio.Size = new System.Drawing.Size(46, 17);
            this.chbtipo_cambio.TabIndex = 366;
            this.chbtipo_cambio.Text = "T.C.";
            this.chbtipo_cambio.UseVisualStyleBackColor = true;
            this.chbtipo_cambio.CheckedChanged += new System.EventHandler(this.chbtipo_cambio_CheckedChanged);
            // 
            // txttipocambio
            // 
            this.txttipocambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txttipocambio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txttipocambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txttipocambio.Enabled = false;
            this.txttipocambio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttipocambio.Location = new System.Drawing.Point(99, 95);
            this.txttipocambio.Margin = new System.Windows.Forms.Padding(2);
            this.txttipocambio.MaxLength = 6;
            this.txttipocambio.Name = "txttipocambio";
            this.txttipocambio.Size = new System.Drawing.Size(72, 20);
            this.txttipocambio.TabIndex = 365;
            this.txttipocambio.Text = "0.000";
            this.txttipocambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttipocambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txttipocambio.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 364;
            this.label2.Text = "Moneda ";
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.DropDownWidth = 120;
            this.cboNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(78, 135);
            this.cboNivel.Margin = new System.Windows.Forms.Padding(2);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(93, 21);
            this.cboNivel.TabIndex = 367;
            this.cboNivel.SelectionChangeCommitted += new System.EventHandler(this.cboNivel_SelectionChangeCommitted);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.DropDownWidth = 110;
            this.cboMoneda.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(78, 73);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(93, 21);
            this.cboMoneda.TabIndex = 363;
            // 
            // cboMesFinal
            // 
            this.cboMesFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesFinal.DropDownWidth = 110;
            this.cboMesFinal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMesFinal.FormattingEnabled = true;
            this.cboMesFinal.Location = new System.Drawing.Point(78, 50);
            this.cboMesFinal.Margin = new System.Windows.Forms.Padding(2);
            this.cboMesFinal.Name = "cboMesFinal";
            this.cboMesFinal.Size = new System.Drawing.Size(93, 21);
            this.cboMesFinal.TabIndex = 362;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 361;
            this.label5.Text = "Año ";
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.DropDownWidth = 110;
            this.cboAnio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(78, 27);
            this.cboAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(93, 21);
            this.cboAnio.TabIndex = 360;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 359;
            this.label4.Text = "Mes Final ";
            // 
            // chbAcumulado
            // 
            this.chbAcumulado.AutoSize = true;
            this.chbAcumulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbAcumulado.Location = new System.Drawing.Point(47, 117);
            this.chbAcumulado.Name = "chbAcumulado";
            this.chbAcumulado.Size = new System.Drawing.Size(121, 17);
            this.chbAcumulado.TabIndex = 356;
            this.chbAcumulado.Text = "Meses Acumulados:";
            this.chbAcumulado.UseVisualStyleBackColor = true;
            // 
            // pnlCCostos
            // 
            this.pnlCCostos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCCostos.Controls.Add(this.chbListaCCostos);
            this.pnlCCostos.Controls.Add(this.lnkTodos);
            this.pnlCCostos.Controls.Add(this.chbindCCostos);
            this.pnlCCostos.Controls.Add(this.labelDegradado3);
            this.pnlCCostos.Location = new System.Drawing.Point(3, 161);
            this.pnlCCostos.Name = "pnlCCostos";
            this.pnlCCostos.Size = new System.Drawing.Size(179, 132);
            this.pnlCCostos.TabIndex = 355;
            // 
            // chbListaCCostos
            // 
            this.chbListaCCostos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chbListaCCostos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chbListaCCostos.CheckOnClick = true;
            this.chbListaCCostos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbListaCCostos.Enabled = false;
            this.chbListaCCostos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbListaCCostos.FormattingEnabled = true;
            this.chbListaCCostos.Items.AddRange(new object[] {
            ""});
            this.chbListaCCostos.Location = new System.Drawing.Point(0, 18);
            this.chbListaCCostos.Name = "chbListaCCostos";
            this.chbListaCCostos.Size = new System.Drawing.Size(177, 112);
            this.chbListaCCostos.TabIndex = 261;
            // 
            // lnkTodos
            // 
            this.lnkTodos.AutoSize = true;
            this.lnkTodos.Enabled = false;
            this.lnkTodos.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lnkTodos.Location = new System.Drawing.Point(138, 3);
            this.lnkTodos.Name = "lnkTodos";
            this.lnkTodos.Size = new System.Drawing.Size(37, 13);
            this.lnkTodos.TabIndex = 262;
            this.lnkTodos.TabStop = true;
            this.lnkTodos.Text = "Todos";
            this.lnkTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTodos_LinkClicked);
            // 
            // chbindCCostos
            // 
            this.chbindCCostos.AutoSize = true;
            this.chbindCCostos.BackColor = System.Drawing.Color.LightSlateGray;
            this.chbindCCostos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbindCCostos.ForeColor = System.Drawing.Color.White;
            this.chbindCCostos.Location = new System.Drawing.Point(0, 1);
            this.chbindCCostos.Name = "chbindCCostos";
            this.chbindCCostos.Size = new System.Drawing.Size(90, 17);
            this.chbindCCostos.TabIndex = 254;
            this.chbindCCostos.Text = "Con C.Costos";
            this.chbindCCostos.UseVisualStyleBackColor = false;
            this.chbindCCostos.CheckedChanged += new System.EventHandler(this.chbindCCostos_CheckedChanged);
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
            this.labelDegradado3.Size = new System.Drawing.Size(177, 18);
            this.labelDegradado3.TabIndex = 368;
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelDegradado2.Size = new System.Drawing.Size(185, 18);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Parámetros";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btPle.Location = new System.Drawing.Point(63, 433);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 48);
            this.btPle.TabIndex = 352;
            this.btPle.UseVisualStyleBackColor = false;
            this.btPle.Click += new System.EventHandler(this.btPle_Click);
            // 
            // chkMostrar
            // 
            this.chkMostrar.AutoSize = true;
            this.chkMostrar.Location = new System.Drawing.Point(5, 63);
            this.chkMostrar.Name = "chkMostrar";
            this.chkMostrar.Size = new System.Drawing.Size(134, 17);
            this.chkMostrar.TabIndex = 348;
            this.chkMostrar.Text = "Mostrar todos los Items";
            this.chkMostrar.UseVisualStyleBackColor = true;
            // 
            // frmReporteEEFFGananciasyPerdidasListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 507);
            this.Controls.Add(this.btPle);
            this.Controls.Add(this.pnl01);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReporteEEFFGananciasyPerdidasListado";
            this.Text = "Estados Financieros -  GananciasPerdidas ";
            this.Load += new System.EventHandler(this.frmReporteEEFFGananciasPerdidasMeses_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl01.ResumeLayout(false);
            this.pnl01.PerformLayout();
            this.pnlCCostos.ResumeLayout(false);
            this.pnlCCostos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPivot;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.Button btnArchivoXls;
        private System.Windows.Forms.Button btnVerCuentas;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiCuentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbTipoReporteCCostos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbTipoReporteMes;
        private System.Windows.Forms.ComboBox cboEEFF;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel pnl01;
        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.CheckBox chbtipo_cambio;
        private ControlesWinForm.SuperTextBox txttipocambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.ComboBox cboMesFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbAcumulado;
        private System.Windows.Forms.Panel pnlCCostos;
        private System.Windows.Forms.LinkLabel lnkTodos;
        private System.Windows.Forms.CheckedListBox chbListaCCostos;
        private System.Windows.Forms.CheckBox chbindCCostos;
        private MyLabelG.LabelDegradado labelDegradado2;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcel;
        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.CheckBox chkMostrar;
    }
}