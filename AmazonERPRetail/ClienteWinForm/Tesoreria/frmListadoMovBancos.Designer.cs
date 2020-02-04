namespace ClienteWinForm.Tesoreria
{
    partial class frmListadoMovBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoMovBancos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVoucherMasivos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImprimeVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLimpiarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminarMasivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCtaCte = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkDevolucion = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmpresas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoMov = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBancosEmpresa = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvMovimiento = new System.Windows.Forms.DataGridView();
            this.CampoCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idMovBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecMovimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codMovBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaBancariaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalImporteDol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codMoviTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpresaTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MesPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMovimientos = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbRegistrado = new System.Windows.Forms.RadioButton();
            this.rbProvisionada = new System.Windows.Forms.RadioButton();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.cmsPopup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientos)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsPopup
            // 
            this.cmsPopup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerarVoucher,
            this.tsmiVoucherMasivos,
            this.toolStripSeparator1,
            this.tsmiImprimeVoucher,
            this.toolStripSeparator2,
            this.tsmiLimpiarVoucher,
            this.tsmiEliminarVoucher,
            this.tsmiEliminarMasivo,
            this.tsmiCtaCte});
            this.cmsPopup.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.cmsPopup.Name = "cmsPopup";
            this.cmsPopup.Size = new System.Drawing.Size(211, 170);
            // 
            // tsmiGenerarVoucher
            // 
            this.tsmiGenerarVoucher.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiGenerarVoucher.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.tsmiGenerarVoucher.Name = "tsmiGenerarVoucher";
            this.tsmiGenerarVoucher.Size = new System.Drawing.Size(210, 22);
            this.tsmiGenerarVoucher.Text = "Generar Voucher";
            this.tsmiGenerarVoucher.Click += new System.EventHandler(this.tsmiGenerarVoucher_Click);
            // 
            // tsmiVoucherMasivos
            // 
            this.tsmiVoucherMasivos.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.tsmiVoucherMasivos.Name = "tsmiVoucherMasivos";
            this.tsmiVoucherMasivos.Size = new System.Drawing.Size(210, 22);
            this.tsmiVoucherMasivos.Text = "Generar Vouchers Masivo";
            this.tsmiVoucherMasivos.Click += new System.EventHandler(this.tsmiVoucherMasivos_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiImprimeVoucher
            // 
            this.tsmiImprimeVoucher.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiImprimeVoucher.Enabled = false;
            this.tsmiImprimeVoucher.Image = ((System.Drawing.Image)(resources.GetObject("tsmiImprimeVoucher.Image")));
            this.tsmiImprimeVoucher.Name = "tsmiImprimeVoucher";
            this.tsmiImprimeVoucher.Size = new System.Drawing.Size(210, 22);
            this.tsmiImprimeVoucher.Text = "Imprimir Voucher";
            this.tsmiImprimeVoucher.Click += new System.EventHandler(this.tsmiImprimeVoucher_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiLimpiarVoucher
            // 
            this.tsmiLimpiarVoucher.Enabled = false;
            this.tsmiLimpiarVoucher.Image = global::ClienteWinForm.Properties.Resources.LimpiarVentana;
            this.tsmiLimpiarVoucher.Name = "tsmiLimpiarVoucher";
            this.tsmiLimpiarVoucher.Size = new System.Drawing.Size(210, 22);
            this.tsmiLimpiarVoucher.Text = "Limpiar N° de Voucher";
            this.tsmiLimpiarVoucher.Click += new System.EventHandler(this.tsmiLimpiarVoucher_Click);
            // 
            // tsmiEliminarVoucher
            // 
            this.tsmiEliminarVoucher.Enabled = false;
            this.tsmiEliminarVoucher.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.tsmiEliminarVoucher.Name = "tsmiEliminarVoucher";
            this.tsmiEliminarVoucher.Size = new System.Drawing.Size(210, 22);
            this.tsmiEliminarVoucher.Text = "Eliminar Voucher";
            this.tsmiEliminarVoucher.Click += new System.EventHandler(this.tsmiEliminarVoucher_Click);
            // 
            // tsmiEliminarMasivo
            // 
            this.tsmiEliminarMasivo.Enabled = false;
            this.tsmiEliminarMasivo.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmiEliminarMasivo.Name = "tsmiEliminarMasivo";
            this.tsmiEliminarMasivo.Size = new System.Drawing.Size(210, 22);
            this.tsmiEliminarMasivo.Text = "Eliminar Vouchers Masivo";
            this.tsmiEliminarMasivo.Click += new System.EventHandler(this.tsmiEliminarMasivo_Click);
            // 
            // tsmiCtaCte
            // 
            this.tsmiCtaCte.Name = "tsmiCtaCte";
            this.tsmiCtaCte.Size = new System.Drawing.Size(210, 22);
            this.tsmiCtaCte.Text = "Actualizar Cta.Cte.";
            this.tsmiCtaCte.Visible = false;
            this.tsmiCtaCte.Click += new System.EventHandler(this.tsmiCtaCte_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkDevolucion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboEmpresas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboTipoMov);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.dtpFecFin);
            this.panel2.Controls.Add(this.dtpFecIni);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cboBancosEmpresa);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1071, 56);
            this.panel2.TabIndex = 372;
            // 
            // chkDevolucion
            // 
            this.chkDevolucion.AutoSize = true;
            this.chkDevolucion.Location = new System.Drawing.Point(943, 29);
            this.chkDevolucion.Name = "chkDevolucion";
            this.chkDevolucion.Size = new System.Drawing.Size(101, 17);
            this.chkDevolucion.TabIndex = 376;
            this.chkDevolucion.Text = "Ind. Devolución";
            this.chkDevolucion.UseVisualStyleBackColor = true;
            this.chkDevolucion.CheckedChanged += new System.EventHandler(this.chkDevolucion_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(659, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 375;
            this.label3.Text = "Empresas Tr.";
            // 
            // cboEmpresas
            // 
            this.cboEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresas.DropDownWidth = 150;
            this.cboEmpresas.Enabled = false;
            this.cboEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresas.FormattingEnabled = true;
            this.cboEmpresas.Location = new System.Drawing.Point(731, 27);
            this.cboEmpresas.Name = "cboEmpresas";
            this.cboEmpresas.Size = new System.Drawing.Size(185, 21);
            this.cboEmpresas.TabIndex = 374;
            this.cboEmpresas.SelectionChangeCommitted += new System.EventHandler(this.cboEmpresas_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 373;
            this.label2.Text = "Tipo";
            // 
            // cboTipoMov
            // 
            this.cboTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMov.DropDownWidth = 150;
            this.cboTipoMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMov.FormattingEnabled = true;
            this.cboTipoMov.Location = new System.Drawing.Point(499, 27);
            this.cboTipoMov.Name = "cboTipoMov";
            this.cboTipoMov.Size = new System.Drawing.Size(153, 21);
            this.cboTipoMov.TabIndex = 372;
            this.cboTipoMov.SelectionChangeCommitted += new System.EventHandler(this.cboTipoMov_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 371;
            this.label1.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(134, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 370;
            this.label25.Text = "Al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(152, 27);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(87, 20);
            this.dtpFecFin.TabIndex = 369;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(44, 27);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(87, 20);
            this.dtpFecIni.TabIndex = 368;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(242, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 367;
            this.label13.Text = "Bancos";
            // 
            // cboBancosEmpresa
            // 
            this.cboBancosEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosEmpresa.DropDownWidth = 150;
            this.cboBancosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosEmpresa.FormattingEnabled = true;
            this.cboBancosEmpresa.Location = new System.Drawing.Point(287, 27);
            this.cboBancosEmpresa.Name = "cboBancosEmpresa";
            this.cboBancosEmpresa.Size = new System.Drawing.Size(177, 21);
            this.cboBancosEmpresa.TabIndex = 366;
            this.cboBancosEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cboBancosEmpresa_SelectionChangeCommitted);
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
            this.labelDegradado1.Size = new System.Drawing.Size(1069, 18);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Opciones de Búsqueda";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvMovimiento);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 61);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(1275, 359);
            this.pnlDetalle.TabIndex = 371;
            // 
            // dgvMovimiento
            // 
            this.dgvMovimiento.AllowUserToAddRows = false;
            this.dgvMovimiento.AllowUserToDeleteRows = false;
            this.dgvMovimiento.AutoGenerateColumns = false;
            this.dgvMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMovimiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CampoCheck,
            this.idMovBancoDataGridViewTextBoxColumn,
            this.desTipoMovimiento,
            this.fecMovimientoDataGridViewTextBoxColumn,
            this.codMovBancoDataGridViewTextBoxColumn,
            this.desBanco,
            this.desMoneda,
            this.ctaBancariaDataGridViewTextBoxColumn,
            this.TotalImporte,
            this.TotalImporteDol,
            this.codMoviTrans,
            this.EmpresaTrans,
            this.AnioPeriodo,
            this.MesPeriodo,
            this.idComprobante,
            this.numFile,
            this.numVoucher,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.indEstado});
            this.dgvMovimiento.ContextMenuStrip = this.cmsPopup;
            this.dgvMovimiento.DataSource = this.bsMovimientos;
            this.dgvMovimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimiento.EnableHeadersVisualStyles = false;
            this.dgvMovimiento.Location = new System.Drawing.Point(0, 18);
            this.dgvMovimiento.Name = "dgvMovimiento";
            this.dgvMovimiento.Size = new System.Drawing.Size(1273, 339);
            this.dgvMovimiento.TabIndex = 248;
            this.dgvMovimiento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimiento_CellDoubleClick);
            this.dgvMovimiento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovimiento_CellFormatting);
            this.dgvMovimiento.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMovimiento_CellPainting);
            this.dgvMovimiento.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimiento_CellValueChanged);
            this.dgvMovimiento.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvMovimiento_CurrentCellDirtyStateChanged);
            // 
            // CampoCheck
            // 
            this.CampoCheck.DataPropertyName = "CampoCheck";
            this.CampoCheck.Frozen = true;
            this.CampoCheck.HeaderText = "";
            this.CampoCheck.Name = "CampoCheck";
            this.CampoCheck.Width = 20;
            // 
            // idMovBancoDataGridViewTextBoxColumn
            // 
            this.idMovBancoDataGridViewTextBoxColumn.DataPropertyName = "idMovBanco";
            this.idMovBancoDataGridViewTextBoxColumn.Frozen = true;
            this.idMovBancoDataGridViewTextBoxColumn.HeaderText = "ID.";
            this.idMovBancoDataGridViewTextBoxColumn.Name = "idMovBancoDataGridViewTextBoxColumn";
            this.idMovBancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idMovBancoDataGridViewTextBoxColumn.Visible = false;
            this.idMovBancoDataGridViewTextBoxColumn.Width = 40;
            // 
            // desTipoMovimiento
            // 
            this.desTipoMovimiento.DataPropertyName = "desTipoMovimiento";
            this.desTipoMovimiento.Frozen = true;
            this.desTipoMovimiento.HeaderText = "Tip.Mov.";
            this.desTipoMovimiento.Name = "desTipoMovimiento";
            this.desTipoMovimiento.ReadOnly = true;
            this.desTipoMovimiento.Width = 90;
            // 
            // fecMovimientoDataGridViewTextBoxColumn
            // 
            this.fecMovimientoDataGridViewTextBoxColumn.DataPropertyName = "fecMovimiento";
            this.fecMovimientoDataGridViewTextBoxColumn.Frozen = true;
            this.fecMovimientoDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fecMovimientoDataGridViewTextBoxColumn.Name = "fecMovimientoDataGridViewTextBoxColumn";
            this.fecMovimientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecMovimientoDataGridViewTextBoxColumn.Width = 70;
            // 
            // codMovBancoDataGridViewTextBoxColumn
            // 
            this.codMovBancoDataGridViewTextBoxColumn.DataPropertyName = "codMovBanco";
            this.codMovBancoDataGridViewTextBoxColumn.Frozen = true;
            this.codMovBancoDataGridViewTextBoxColumn.HeaderText = "Cód.Mov.";
            this.codMovBancoDataGridViewTextBoxColumn.Name = "codMovBancoDataGridViewTextBoxColumn";
            this.codMovBancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codMovBancoDataGridViewTextBoxColumn.Width = 70;
            // 
            // desBanco
            // 
            this.desBanco.DataPropertyName = "desBanco";
            this.desBanco.Frozen = true;
            this.desBanco.HeaderText = "Banco";
            this.desBanco.Name = "desBanco";
            this.desBanco.ReadOnly = true;
            this.desBanco.Width = 240;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 40;
            // 
            // ctaBancariaDataGridViewTextBoxColumn
            // 
            this.ctaBancariaDataGridViewTextBoxColumn.DataPropertyName = "ctaBancaria";
            this.ctaBancariaDataGridViewTextBoxColumn.HeaderText = "Cta.Bancaria";
            this.ctaBancariaDataGridViewTextBoxColumn.Name = "ctaBancariaDataGridViewTextBoxColumn";
            this.ctaBancariaDataGridViewTextBoxColumn.ReadOnly = true;
            this.ctaBancariaDataGridViewTextBoxColumn.Width = 125;
            // 
            // TotalImporte
            // 
            this.TotalImporte.DataPropertyName = "TotalImporte";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.TotalImporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalImporte.HeaderText = "S/";
            this.TotalImporte.Name = "TotalImporte";
            this.TotalImporte.ReadOnly = true;
            this.TotalImporte.Width = 75;
            // 
            // TotalImporteDol
            // 
            this.TotalImporteDol.DataPropertyName = "TotalImporteDol";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.TotalImporteDol.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalImporteDol.HeaderText = "US$";
            this.TotalImporteDol.Name = "TotalImporteDol";
            this.TotalImporteDol.ReadOnly = true;
            this.TotalImporteDol.Width = 75;
            // 
            // codMoviTrans
            // 
            this.codMoviTrans.DataPropertyName = "codMoviTrans";
            this.codMoviTrans.HeaderText = "Mov.Trans.";
            this.codMoviTrans.Name = "codMoviTrans";
            this.codMoviTrans.ReadOnly = true;
            this.codMoviTrans.Width = 75;
            // 
            // EmpresaTrans
            // 
            this.EmpresaTrans.DataPropertyName = "EmpresaTrans";
            this.EmpresaTrans.HeaderText = "Empresa Trans.";
            this.EmpresaTrans.Name = "EmpresaTrans";
            this.EmpresaTrans.ReadOnly = true;
            this.EmpresaTrans.Width = 150;
            // 
            // AnioPeriodo
            // 
            this.AnioPeriodo.DataPropertyName = "AnioPeriodo";
            this.AnioPeriodo.HeaderText = "Año C.";
            this.AnioPeriodo.Name = "AnioPeriodo";
            this.AnioPeriodo.ReadOnly = true;
            this.AnioPeriodo.ToolTipText = "Año en contabilidad";
            this.AnioPeriodo.Width = 50;
            // 
            // MesPeriodo
            // 
            this.MesPeriodo.DataPropertyName = "MesPeriodo";
            this.MesPeriodo.HeaderText = "Mes C.";
            this.MesPeriodo.Name = "MesPeriodo";
            this.MesPeriodo.ReadOnly = true;
            this.MesPeriodo.ToolTipText = "Mes de Contabilidad";
            this.MesPeriodo.Width = 50;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            this.idComprobante.HeaderText = "Lib.";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Width = 40;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.ReadOnly = true;
            this.numFile.Width = 40;
            // 
            // numVoucher
            // 
            this.numVoucher.DataPropertyName = "numVoucher";
            this.numVoucher.HeaderText = "Voucher";
            this.numVoucher.Name = "numVoucher";
            this.numVoucher.ReadOnly = true;
            this.numVoucher.Width = 80;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            this.indEstado.HeaderText = "indEstado";
            this.indEstado.Name = "indEstado";
            this.indEstado.Visible = false;
            // 
            // bsMovimientos
            // 
            this.bsMovimientos.DataSource = typeof(Entidades.Tesoreria.MovimientoBancosE);
            this.bsMovimientos.CurrentChanged += new System.EventHandler(this.bsMovimientos_CurrentChanged);
            this.bsMovimientos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsMovimientos_ListChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(1273, 18);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbRegistrado);
            this.panel3.Controls.Add(this.rbProvisionada);
            this.panel3.Controls.Add(this.labelDegradado2);
            this.panel3.Location = new System.Drawing.Point(1076, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 56);
            this.panel3.TabIndex = 373;
            // 
            // rbRegistrado
            // 
            this.rbRegistrado.AutoSize = true;
            this.rbRegistrado.Checked = true;
            this.rbRegistrado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRegistrado.Location = new System.Drawing.Point(14, 26);
            this.rbRegistrado.Name = "rbRegistrado";
            this.rbRegistrado.Size = new System.Drawing.Size(77, 17);
            this.rbRegistrado.TabIndex = 259;
            this.rbRegistrado.TabStop = true;
            this.rbRegistrado.Text = "Registrada";
            this.rbRegistrado.UseVisualStyleBackColor = true;
            this.rbRegistrado.CheckedChanged += new System.EventHandler(this.rbRegistrado_CheckedChanged);
            // 
            // rbProvisionada
            // 
            this.rbProvisionada.AutoSize = true;
            this.rbProvisionada.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProvisionada.Location = new System.Drawing.Point(97, 26);
            this.rbProvisionada.Name = "rbProvisionada";
            this.rbProvisionada.Size = new System.Drawing.Size(91, 17);
            this.rbProvisionada.TabIndex = 257;
            this.rbProvisionada.Text = "Provisionados";
            this.rbProvisionada.UseVisualStyleBackColor = true;
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
            this.labelDegradado2.Size = new System.Drawing.Size(200, 17);
            this.labelDegradado2.TabIndex = 248;
            this.labelDegradado2.Text = "Estado";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoMovBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 422);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmListadoMovBancos";
            this.Text = "Listado Movimientos de Bancos";
            this.Load += new System.EventHandler(this.frmListadoMovBancos_Load);
            this.cmsPopup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBancosEmpresa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoMov;
        private MyLabelG.LabelDegradado labelDegradado1;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsMovimientos;
        private System.Windows.Forms.DataGridView dgvMovimiento;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.ContextMenuStrip cmsPopup;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerarVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmiImprimeVoucher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarVoucher;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbRegistrado;
        private System.Windows.Forms.RadioButton rbProvisionada;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.ToolStripMenuItem tsmiVoucherMasivos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiarVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarMasivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCtaCte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmpresas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CampoCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMovBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecMovimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMovBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaBancariaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalImporteDol;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMoviTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpresaTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MesPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indEstado;
        private System.Windows.Forms.CheckBox chkDevolucion;
    }
}