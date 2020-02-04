namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmListadoLiquidacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFondosFijosRend = new System.Windows.Forms.DataGridView();
            this.desEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLiquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLiqui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codOrdenPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsLiquidacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCorreo = new System.Windows.Forms.ToolStripMenuItem();
            this.bsLiquidacion = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbRendir = new System.Windows.Forms.RadioButton();
            this.rbFijos = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.cboDocumentos = new System.Windows.Forms.ComboBox();
            this.txtNumero = new ControlesWinForm.SuperTextBox();
            this.rbTodoDoc = new System.Windows.Forms.RadioButton();
            this.rbUnoDoc = new System.Windows.Forms.RadioButton();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondosFijosRend)).BeginInit();
            this.cmsLiquidacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLiquidacion)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvFondosFijosRend);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 326);
            this.panel1.TabIndex = 77;
            // 
            // dgvFondosFijosRend
            // 
            this.dgvFondosFijosRend.AllowUserToAddRows = false;
            this.dgvFondosFijosRend.AllowUserToDeleteRows = false;
            this.dgvFondosFijosRend.AutoGenerateColumns = false;
            this.dgvFondosFijosRend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFondosFijosRend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFondosFijosRend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desEstado,
            this.idLiquidacionDataGridViewTextBoxColumn,
            this.RazonSocial,
            this.fechaDataGridViewTextBoxColumn,
            this.TotalLiqui,
            this.codOrdenPago,
            this.idComprobante,
            this.numFile,
            this.numVoucher,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.Estado});
            this.dgvFondosFijosRend.ContextMenuStrip = this.cmsLiquidacion;
            this.dgvFondosFijosRend.DataSource = this.bsLiquidacion;
            this.dgvFondosFijosRend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFondosFijosRend.EnableHeadersVisualStyles = false;
            this.dgvFondosFijosRend.Location = new System.Drawing.Point(0, 18);
            this.dgvFondosFijosRend.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFondosFijosRend.Name = "dgvFondosFijosRend";
            this.dgvFondosFijosRend.ReadOnly = true;
            this.dgvFondosFijosRend.RowTemplate.Height = 24;
            this.dgvFondosFijosRend.Size = new System.Drawing.Size(1095, 306);
            this.dgvFondosFijosRend.TabIndex = 80;
            this.dgvFondosFijosRend.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFondosFijosRend_CellDoubleClick);
            this.dgvFondosFijosRend.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFondosFijosRend_CellFormatting);
            // 
            // desEstado
            // 
            this.desEstado.DataPropertyName = "desEstado";
            this.desEstado.HeaderText = "Estado";
            this.desEstado.Name = "desEstado";
            this.desEstado.ReadOnly = true;
            this.desEstado.Width = 80;
            // 
            // idLiquidacionDataGridViewTextBoxColumn
            // 
            this.idLiquidacionDataGridViewTextBoxColumn.DataPropertyName = "idLiquidacion";
            this.idLiquidacionDataGridViewTextBoxColumn.HeaderText = "Id. Liq.";
            this.idLiquidacionDataGridViewTextBoxColumn.Name = "idLiquidacionDataGridViewTextBoxColumn";
            this.idLiquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLiquidacionDataGridViewTextBoxColumn.Width = 50;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 250;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // TotalLiqui
            // 
            this.TotalLiqui.DataPropertyName = "TotalLiqui";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.TotalLiqui.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalLiqui.HeaderText = "Total";
            this.TotalLiqui.Name = "TotalLiqui";
            this.TotalLiqui.ReadOnly = true;
            this.TotalLiqui.Width = 70;
            // 
            // codOrdenPago
            // 
            this.codOrdenPago.DataPropertyName = "codOrdenPago";
            this.codOrdenPago.HeaderText = "O.P.";
            this.codOrdenPago.Name = "codOrdenPago";
            this.codOrdenPago.ReadOnly = true;
            this.codOrdenPago.Width = 75;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            this.idComprobante.HeaderText = "Diario";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Width = 43;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.ReadOnly = true;
            this.numFile.Width = 35;
            // 
            // numVoucher
            // 
            this.numVoucher.DataPropertyName = "numVoucher";
            this.numVoucher.HeaderText = "Voucher";
            this.numVoucher.Name = "numVoucher";
            this.numVoucher.ReadOnly = true;
            this.numVoucher.Width = 70;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // cmsLiquidacion
            // 
            this.cmsLiquidacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsLiquidacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerar,
            this.tsmiAbrir,
            this.toolStripSeparator2,
            this.tsmVoucher,
            this.tsmiLimpiar,
            this.toolStripSeparator1,
            this.tsmiCorreo});
            this.cmsLiquidacion.Name = "cmsFactura";
            this.cmsLiquidacion.Size = new System.Drawing.Size(176, 126);
            // 
            // tsmiGenerar
            // 
            this.tsmiGenerar.Image = global::ClienteWinForm.Properties.Resources.Cerrar_Grande;
            this.tsmiGenerar.Name = "tsmiGenerar";
            this.tsmiGenerar.Size = new System.Drawing.Size(175, 22);
            this.tsmiGenerar.Text = "Cerrar Liquidacion";
            this.tsmiGenerar.Click += new System.EventHandler(this.tsmiGenerar_Click);
            // 
            // tsmiAbrir
            // 
            this.tsmiAbrir.Image = global::ClienteWinForm.Properties.Resources.ActualizarExcel;
            this.tsmiAbrir.Name = "tsmiAbrir";
            this.tsmiAbrir.Size = new System.Drawing.Size(175, 22);
            this.tsmiAbrir.Text = "Abrir Liquidación";
            this.tsmiAbrir.Click += new System.EventHandler(this.tsmiAbrir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmVoucher
            // 
            this.tsmVoucher.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.tsmVoucher.Name = "tsmVoucher";
            this.tsmVoucher.Size = new System.Drawing.Size(175, 22);
            this.tsmVoucher.Text = "Ver Voucher";
            this.tsmVoucher.Click += new System.EventHandler(this.tsmVoucher_Click);
            // 
            // tsmiLimpiar
            // 
            this.tsmiLimpiar.Image = global::ClienteWinForm.Properties.Resources.VentanaLimpia24_x_24;
            this.tsmiLimpiar.Name = "tsmiLimpiar";
            this.tsmiLimpiar.Size = new System.Drawing.Size(175, 22);
            this.tsmiLimpiar.Text = "Limpiar Voucher";
            this.tsmiLimpiar.Click += new System.EventHandler(this.tsmiLimpiar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiCorreo
            // 
            this.tsmiCorreo.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.tsmiCorreo.Name = "tsmiCorreo";
            this.tsmiCorreo.Size = new System.Drawing.Size(175, 22);
            this.tsmiCorreo.Text = "Mandar por Correo";
            this.tsmiCorreo.Click += new System.EventHandler(this.tsmiCorreo_Click);
            // 
            // bsLiquidacion
            // 
            this.bsLiquidacion.DataSource = typeof(Entidades.CtasPorPagar.LiquidacionE);
            this.bsLiquidacion.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsLiquidacion_ListChanged);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(1095, 18);
            this.lblTitulo.TabIndex = 270;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbRendir);
            this.panel2.Controls.Add(this.rbFijos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboEstados);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(this.dtpFecFin);
            this.panel2.Controls.Add(this.dtpFecIni);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 64);
            this.panel2.TabIndex = 362;
            // 
            // rbRendir
            // 
            this.rbRendir.AutoSize = true;
            this.rbRendir.Location = new System.Drawing.Point(104, 30);
            this.rbRendir.Name = "rbRendir";
            this.rbRendir.Size = new System.Drawing.Size(110, 17);
            this.rbRendir.TabIndex = 370;
            this.rbRendir.Text = "Entregas a Rendir";
            this.rbRendir.UseVisualStyleBackColor = true;
            // 
            // rbFijos
            // 
            this.rbFijos.AutoSize = true;
            this.rbFijos.Checked = true;
            this.rbFijos.Location = new System.Drawing.Point(10, 30);
            this.rbFijos.Name = "rbFijos";
            this.rbFijos.Size = new System.Drawing.Size(84, 17);
            this.rbFijos.TabIndex = 369;
            this.rbFijos.TabStop = true;
            this.rbFijos.Text = "Fondos Fijos";
            this.rbFijos.UseVisualStyleBackColor = true;
            this.rbFijos.CheckedChanged += new System.EventHandler(this.rbFijos_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 368;
            this.label3.Text = "Estado";
            // 
            // cboEstados
            // 
            this.cboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstados.DropDownWidth = 132;
            this.cboEstados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Items.AddRange(new object[] {
            "Pendiente",
            "Girado"});
            this.cboEstados.Location = new System.Drawing.Point(518, 30);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(132, 21);
            this.cboEstados.TabIndex = 367;
            this.cboEstados.SelectionChangeCommitted += new System.EventHandler(this.cboEstados_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 362;
            this.label1.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(351, 34);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 361;
            this.label25.Text = "Al";
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
            this.labelDegradado2.Size = new System.Drawing.Size(661, 18);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Opciones";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(370, 30);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(94, 20);
            this.dtpFecFin.TabIndex = 359;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(254, 30);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(94, 20);
            this.dtpFecIni.TabIndex = 358;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtSerie);
            this.panel6.Controls.Add(this.cboDocumentos);
            this.panel6.Controls.Add(this.txtNumero);
            this.panel6.Controls.Add(this.rbTodoDoc);
            this.panel6.Controls.Add(this.rbUnoDoc);
            this.panel6.Controls.Add(this.labelDegradado5);
            this.panel6.Location = new System.Drawing.Point(668, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(432, 64);
            this.panel6.TabIndex = 363;
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Enabled = false;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(216, 27);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(81, 20);
            this.txtSerie.TabIndex = 306;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "";
            // 
            // cboDocumentos
            // 
            this.cboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentos.DropDownWidth = 63;
            this.cboDocumentos.Enabled = false;
            this.cboDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentos.FormattingEnabled = true;
            this.cboDocumentos.Location = new System.Drawing.Point(149, 27);
            this.cboDocumentos.Name = "cboDocumentos";
            this.cboDocumentos.Size = new System.Drawing.Size(63, 21);
            this.cboDocumentos.TabIndex = 250;
            // 
            // txtNumero
            // 
            this.txtNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumero.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(301, 27);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(120, 20);
            this.txtNumero.TabIndex = 307;
            this.txtNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumero.TextoVacio = "";
            // 
            // rbTodoDoc
            // 
            this.rbTodoDoc.AutoSize = true;
            this.rbTodoDoc.Checked = true;
            this.rbTodoDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodoDoc.Location = new System.Drawing.Point(9, 30);
            this.rbTodoDoc.Name = "rbTodoDoc";
            this.rbTodoDoc.Size = new System.Drawing.Size(54, 17);
            this.rbTodoDoc.TabIndex = 299;
            this.rbTodoDoc.TabStop = true;
            this.rbTodoDoc.Text = "Todos";
            this.rbTodoDoc.UseVisualStyleBackColor = true;
            this.rbTodoDoc.CheckedChanged += new System.EventHandler(this.rbTodoDoc_CheckedChanged);
            // 
            // rbUnoDoc
            // 
            this.rbUnoDoc.AutoSize = true;
            this.rbUnoDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnoDoc.Location = new System.Drawing.Point(74, 30);
            this.rbUnoDoc.Name = "rbUnoDoc";
            this.rbUnoDoc.Size = new System.Drawing.Size(66, 17);
            this.rbUnoDoc.TabIndex = 298;
            this.rbUnoDoc.Text = "Solo uno";
            this.rbUnoDoc.UseVisualStyleBackColor = true;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(430, 17);
            this.labelDegradado5.TabIndex = 248;
            this.labelDegradado5.Text = "Documento";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 398);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmListadoLiquidacion";
            this.Text = "Liquidacion de Fondo Fijo y Rendiciones";
            this.Load += new System.EventHandler(this.frmListadoLiquidacion_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondosFijosRend)).EndInit();
            this.cmsLiquidacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsLiquidacion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFondosFijosRend;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.BindingSource bsLiquidacion;
        private System.Windows.Forms.ContextMenuStrip cmsLiquidacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.ToolStripMenuItem tsmiCorreo;
        private System.Windows.Forms.ToolStripMenuItem tsmVoucher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiar;
        private System.Windows.Forms.RadioButton rbRendir;
        private System.Windows.Forms.RadioButton rbFijos;
        private System.Windows.Forms.DataGridViewTextBoxColumn desEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLiquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLiqui;
        private System.Windows.Forms.DataGridViewTextBoxColumn codOrdenPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.Panel panel6;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.ComboBox cboDocumentos;
        private ControlesWinForm.SuperTextBox txtNumero;
        private System.Windows.Forms.RadioButton rbTodoDoc;
        private System.Windows.Forms.RadioButton rbUnoDoc;
        private MyLabelG.LabelDegradado labelDegradado5;
    }
}