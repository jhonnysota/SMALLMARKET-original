namespace ClienteWinForm.Ventas
{
    partial class frmListadoPlanillaBancos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerarVR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenerarVI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImprimeVR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImprimeVI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEliminarVR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminarVI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDescuento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCobranza = new System.Windows.Forms.ToolStripMenuItem();
            this.bsPlanilla = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbL = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbBancos = new System.Windows.Forms.RadioButton();
            this.cboBancos = new System.Windows.Forms.ComboBox();
            this.rbTodosBancos = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbProductos = new System.Windows.Forms.RadioButton();
            this.cboProductos = new System.Windows.Forms.ComboBox();
            this.rbTodosProd = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.rbFechaAbono = new System.Windows.Forms.RadioButton();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvPlanillas = new System.Windows.Forms.DataGridView();
            this.idPlanillaBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecAbonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAbono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoLetras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.cmsPopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanilla)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsPopup
            // 
            this.cmsPopup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerarVR,
            this.tsmiGenerarVI,
            this.toolStripSeparator1,
            this.tsmiImprimeVR,
            this.tsmiImprimeVI,
            this.toolStripSeparator2,
            this.tsmiEliminarVR,
            this.tsmiEliminarVI,
            this.toolStripSeparator3,
            this.tsmiDescuento,
            this.tsmiCobranza});
            this.cmsPopup.Name = "cmsPopup";
            this.cmsPopup.Size = new System.Drawing.Size(248, 198);
            // 
            // tsmiGenerarVR
            // 
            this.tsmiGenerarVR.Image = global::ClienteWinForm.Properties.Resources.GenerarNegro_24x24;
            this.tsmiGenerarVR.Name = "tsmiGenerarVR";
            this.tsmiGenerarVR.Size = new System.Drawing.Size(247, 22);
            this.tsmiGenerarVR.Text = "Generar Voucher Reclasificación";
            this.tsmiGenerarVR.Click += new System.EventHandler(this.tsmiGenerarVR_Click);
            // 
            // tsmiGenerarVI
            // 
            this.tsmiGenerarVI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiGenerarVI.Image = global::ClienteWinForm.Properties.Resources.GenerarAzul_24x24;
            this.tsmiGenerarVI.Name = "tsmiGenerarVI";
            this.tsmiGenerarVI.Size = new System.Drawing.Size(247, 22);
            this.tsmiGenerarVI.Text = "Generar Voucher Ingreso";
            this.tsmiGenerarVI.Visible = false;
            this.tsmiGenerarVI.Click += new System.EventHandler(this.tsmiGenerarVI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // tsmiImprimeVR
            // 
            this.tsmiImprimeVR.Enabled = false;
            this.tsmiImprimeVR.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.tsmiImprimeVR.Name = "tsmiImprimeVR";
            this.tsmiImprimeVR.Size = new System.Drawing.Size(247, 22);
            this.tsmiImprimeVR.Text = "Imprimir Voucher Reclasificación";
            this.tsmiImprimeVR.Click += new System.EventHandler(this.tsmiImprimeVR_Click);
            // 
            // tsmiImprimeVI
            // 
            this.tsmiImprimeVI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiImprimeVI.Enabled = false;
            this.tsmiImprimeVI.Image = global::ClienteWinForm.Properties.Resources.ImpresoraAzul;
            this.tsmiImprimeVI.Name = "tsmiImprimeVI";
            this.tsmiImprimeVI.Size = new System.Drawing.Size(247, 22);
            this.tsmiImprimeVI.Text = "Imprimir Voucher Ingreso";
            this.tsmiImprimeVI.Click += new System.EventHandler(this.tsmiImprimeVI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(244, 6);
            // 
            // tsmiEliminarVR
            // 
            this.tsmiEliminarVR.Enabled = false;
            this.tsmiEliminarVR.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmiEliminarVR.Name = "tsmiEliminarVR";
            this.tsmiEliminarVR.Size = new System.Drawing.Size(247, 22);
            this.tsmiEliminarVR.Text = "Eliminar Voucher Reclasificación";
            this.tsmiEliminarVR.Click += new System.EventHandler(this.tsmiEliminarVR_Click);
            // 
            // tsmiEliminarVI
            // 
            this.tsmiEliminarVI.Enabled = false;
            this.tsmiEliminarVI.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmiEliminarVI.Name = "tsmiEliminarVI";
            this.tsmiEliminarVI.Size = new System.Drawing.Size(247, 22);
            this.tsmiEliminarVI.Text = "Eliminar Voucher Ingreso";
            this.tsmiEliminarVI.Click += new System.EventHandler(this.tsmiEliminarVI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(244, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // tsmiDescuento
            // 
            this.tsmiDescuento.Enabled = false;
            this.tsmiDescuento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tsmiDescuento.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.tsmiDescuento.Name = "tsmiDescuento";
            this.tsmiDescuento.Size = new System.Drawing.Size(247, 22);
            this.tsmiDescuento.Text = "Exportar Descuento";
            this.tsmiDescuento.Visible = false;
            this.tsmiDescuento.Click += new System.EventHandler(this.tsmiDescuento_Click);
            // 
            // tsmiCobranza
            // 
            this.tsmiCobranza.Enabled = false;
            this.tsmiCobranza.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.tsmiCobranza.Name = "tsmiCobranza";
            this.tsmiCobranza.Size = new System.Drawing.Size(247, 22);
            this.tsmiCobranza.Text = "Exportar Cobranza";
            this.tsmiCobranza.Visible = false;
            this.tsmiCobranza.Click += new System.EventHandler(this.tsmiCobranza_Click);
            // 
            // bsPlanilla
            // 
            this.bsPlanilla.DataSource = typeof(Entidades.Ventas.PlanillaBancosE);
            this.bsPlanilla.CurrentItemChanged += new System.EventHandler(this.bsPlanilla_CurrentItemChanged);
            this.bsPlanilla.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPlanilla_ListChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rbL);
            this.panel1.Controls.Add(this.rbB);
            this.panel1.Location = new System.Drawing.Point(639, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 71);
            this.panel1.TabIndex = 309;
            // 
            // rbL
            // 
            this.rbL.AutoSize = true;
            this.rbL.Location = new System.Drawing.Point(12, 45);
            this.rbL.Name = "rbL";
            this.rbL.Size = new System.Drawing.Size(73, 17);
            this.rbL.TabIndex = 304;
            this.rbL.Text = "Por Letras";
            this.rbL.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Checked = true;
            this.rbB.Location = new System.Drawing.Point(12, 25);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(75, 17);
            this.rbB.TabIndex = 302;
            this.rbB.TabStop = true;
            this.rbB.Text = "Por Banco";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.rbBancos);
            this.panel4.Controls.Add(this.cboBancos);
            this.panel4.Controls.Add(this.rbTodosBancos);
            this.panel4.Location = new System.Drawing.Point(743, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(368, 71);
            this.panel4.TabIndex = 309;
            // 
            // rbBancos
            // 
            this.rbBancos.AutoSize = true;
            this.rbBancos.Location = new System.Drawing.Point(19, 45);
            this.rbBancos.Name = "rbBancos";
            this.rbBancos.Size = new System.Drawing.Size(41, 17);
            this.rbBancos.TabIndex = 307;
            this.rbBancos.Text = "Por";
            this.rbBancos.UseVisualStyleBackColor = true;
            // 
            // cboBancos
            // 
            this.cboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancos.Enabled = false;
            this.cboBancos.FormattingEnabled = true;
            this.cboBancos.Location = new System.Drawing.Point(81, 43);
            this.cboBancos.Name = "cboBancos";
            this.cboBancos.Size = new System.Drawing.Size(265, 21);
            this.cboBancos.TabIndex = 306;
            // 
            // rbTodosBancos
            // 
            this.rbTodosBancos.AutoSize = true;
            this.rbTodosBancos.Checked = true;
            this.rbTodosBancos.Location = new System.Drawing.Point(19, 25);
            this.rbTodosBancos.Name = "rbTodosBancos";
            this.rbTodosBancos.Size = new System.Drawing.Size(55, 17);
            this.rbTodosBancos.TabIndex = 305;
            this.rbTodosBancos.TabStop = true;
            this.rbTodosBancos.Text = "Todos";
            this.rbTodosBancos.UseVisualStyleBackColor = true;
            this.rbTodosBancos.CheckedChanged += new System.EventHandler(this.rbTodosBancos_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rbProductos);
            this.panel3.Controls.Add(this.cboProductos);
            this.panel3.Controls.Add(this.rbTodosProd);
            this.panel3.Location = new System.Drawing.Point(341, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 71);
            this.panel3.TabIndex = 308;
            // 
            // rbProductos
            // 
            this.rbProductos.AutoSize = true;
            this.rbProductos.Location = new System.Drawing.Point(14, 45);
            this.rbProductos.Name = "rbProductos";
            this.rbProductos.Size = new System.Drawing.Size(41, 17);
            this.rbProductos.TabIndex = 304;
            this.rbProductos.Text = "Por";
            this.rbProductos.UseVisualStyleBackColor = true;
            // 
            // cboProductos
            // 
            this.cboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductos.Enabled = false;
            this.cboProductos.FormattingEnabled = true;
            this.cboProductos.Location = new System.Drawing.Point(75, 43);
            this.cboProductos.Name = "cboProductos";
            this.cboProductos.Size = new System.Drawing.Size(194, 21);
            this.cboProductos.TabIndex = 303;
            // 
            // rbTodosProd
            // 
            this.rbTodosProd.AutoSize = true;
            this.rbTodosProd.Checked = true;
            this.rbTodosProd.Location = new System.Drawing.Point(14, 25);
            this.rbTodosProd.Name = "rbTodosProd";
            this.rbTodosProd.Size = new System.Drawing.Size(55, 17);
            this.rbTodosProd.TabIndex = 302;
            this.rbTodosProd.TabStop = true;
            this.rbTodosProd.Text = "Todos";
            this.rbTodosProd.UseVisualStyleBackColor = true;
            this.rbTodosProd.CheckedChanged += new System.EventHandler(this.rbTodosProd_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtpFecFin);
            this.panel2.Controls.Add(this.dtpFecIni);
            this.panel2.Controls.Add(this.rbFechaAbono);
            this.panel2.Controls.Add(this.rbFecha);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 71);
            this.panel2.TabIndex = 306;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFin.Location = new System.Drawing.Point(231, 33);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(84, 20);
            this.dtpFecFin.TabIndex = 307;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.CustomFormat = "dd/MM/yyyy";
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecIni.Location = new System.Drawing.Point(124, 33);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(84, 20);
            this.dtpFecIni.TabIndex = 306;
            // 
            // rbFechaAbono
            // 
            this.rbFechaAbono.AutoSize = true;
            this.rbFechaAbono.Location = new System.Drawing.Point(15, 46);
            this.rbFechaAbono.Name = "rbFechaAbono";
            this.rbFechaAbono.Size = new System.Drawing.Size(89, 17);
            this.rbFechaAbono.TabIndex = 302;
            this.rbFechaAbono.Text = "Fecha Abono";
            this.rbFechaAbono.UseVisualStyleBackColor = true;
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Checked = true;
            this.rbFecha.Location = new System.Drawing.Point(15, 24);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(55, 17);
            this.rbFecha.TabIndex = 301;
            this.rbFecha.TabStop = true;
            this.rbFecha.Text = "Fecha";
            this.rbFecha.UseVisualStyleBackColor = true;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Controls.Add(this.dgvPlanillas);
            this.pnlContenedor.Controls.Add(this.LblTitulo);
            this.pnlContenedor.Location = new System.Drawing.Point(3, 76);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1108, 317);
            this.pnlContenedor.TabIndex = 300;
            // 
            // dgvPlanillas
            // 
            this.dgvPlanillas.AllowUserToAddRows = false;
            this.dgvPlanillas.AllowUserToDeleteRows = false;
            this.dgvPlanillas.AutoGenerateColumns = false;
            this.dgvPlanillas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanillas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPlanillaBancoDataGridViewTextBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.desBanco,
            this.numCuenta,
            this.desMoneda,
            this.fechaDataGridViewTextBoxColumn,
            this.fecAbonoDataGridViewTextBoxColumn,
            this.MontoAbono,
            this.MontoLetras,
            this.Estado,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvPlanillas.ContextMenuStrip = this.cmsPopup;
            this.dgvPlanillas.DataSource = this.bsPlanilla;
            this.dgvPlanillas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanillas.EnableHeadersVisualStyles = false;
            this.dgvPlanillas.Location = new System.Drawing.Point(0, 18);
            this.dgvPlanillas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPlanillas.Name = "dgvPlanillas";
            this.dgvPlanillas.ReadOnly = true;
            this.dgvPlanillas.RowTemplate.Height = 24;
            this.dgvPlanillas.Size = new System.Drawing.Size(1106, 297);
            this.dgvPlanillas.TabIndex = 271;
            this.dgvPlanillas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanillas_CellDoubleClick);
            this.dgvPlanillas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPlanillas_CellFormatting);
            // 
            // idPlanillaBancoDataGridViewTextBoxColumn
            // 
            this.idPlanillaBancoDataGridViewTextBoxColumn.DataPropertyName = "idPlanillaBanco";
            this.idPlanillaBancoDataGridViewTextBoxColumn.HeaderText = "Id.";
            this.idPlanillaBancoDataGridViewTextBoxColumn.Name = "idPlanillaBancoDataGridViewTextBoxColumn";
            this.idPlanillaBancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPlanillaBancoDataGridViewTextBoxColumn.Visible = false;
            this.idPlanillaBancoDataGridViewTextBoxColumn.Width = 40;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "desProducto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoDataGridViewTextBoxColumn.Width = 150;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numeroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroDataGridViewTextBoxColumn.Width = 90;
            // 
            // desBanco
            // 
            this.desBanco.DataPropertyName = "desBanco";
            this.desBanco.HeaderText = "Razón Social";
            this.desBanco.Name = "desBanco";
            this.desBanco.ReadOnly = true;
            this.desBanco.Width = 250;
            // 
            // numCuenta
            // 
            this.numCuenta.DataPropertyName = "numCuenta";
            this.numCuenta.HeaderText = "N° Cuenta";
            this.numCuenta.Name = "numCuenta";
            this.numCuenta.ReadOnly = true;
            this.numCuenta.Width = 95;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 35;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 70;
            // 
            // fecAbonoDataGridViewTextBoxColumn
            // 
            this.fecAbonoDataGridViewTextBoxColumn.DataPropertyName = "fecAbono";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.fecAbonoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecAbonoDataGridViewTextBoxColumn.HeaderText = "Fec.Abon.";
            this.fecAbonoDataGridViewTextBoxColumn.Name = "fecAbonoDataGridViewTextBoxColumn";
            this.fecAbonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecAbonoDataGridViewTextBoxColumn.Width = 70;
            // 
            // MontoAbono
            // 
            this.MontoAbono.DataPropertyName = "MontoAbono";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.MontoAbono.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoAbono.HeaderText = "Monto Abono";
            this.MontoAbono.Name = "MontoAbono";
            this.MontoAbono.ReadOnly = true;
            this.MontoAbono.Width = 90;
            // 
            // MontoLetras
            // 
            this.MontoLetras.DataPropertyName = "MontoLetras";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.MontoLetras.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoLetras.HeaderText = "Monto Letras";
            this.MontoLetras.Name = "MontoLetras";
            this.MontoLetras.ReadOnly = true;
            this.MontoLetras.Width = 90;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 18);
            this.label3.TabIndex = 367;
            this.label3.Text = "Por";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 18);
            this.label2.TabIndex = 367;
            this.label2.Text = "Producto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 367;
            this.label4.Text = "Tipo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 18);
            this.label5.TabIndex = 367;
            this.label5.Text = "Bancos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1106, 18);
            this.LblTitulo.TabIndex = 367;
            this.LblTitulo.Text = "Registros 0";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoPlanillaBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 396);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlContenedor);
            this.Name = "frmListadoPlanillaBancos";
            this.Text = "Listado de Planillas de Letras";
            this.Load += new System.EventHandler(this.frmListadoPlanillaBancos_Load);
            this.cmsPopup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanilla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanillas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.DataGridView dgvPlanillas;
        private System.Windows.Forms.BindingSource bsPlanilla;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbBancos;
        private System.Windows.Forms.ComboBox cboBancos;
        private System.Windows.Forms.RadioButton rbTodosBancos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbProductos;
        private System.Windows.Forms.ComboBox cboProductos;
        private System.Windows.Forms.RadioButton rbTodosProd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbFechaAbono;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.ContextMenuStrip cmsPopup;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerarVI;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerarVR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImprimeVI;
        private System.Windows.Forms.ToolStripMenuItem tsmiImprimeVR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiDescuento;
        private System.Windows.Forms.ToolStripMenuItem tsmiCobranza;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarVR;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarVI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbL;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlanillaBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecAbonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAbono;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoLetras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTitulo;
    }
}