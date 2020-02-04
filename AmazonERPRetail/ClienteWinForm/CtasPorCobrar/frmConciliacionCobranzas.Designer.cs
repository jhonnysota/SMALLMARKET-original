namespace ClienteWinForm.CtasPorCobrar
{
    partial class frmConciliacionCobranzas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMontoImportados = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvCobranzas = new System.Windows.Forms.DataGridView();
            this.bsCobranzas = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btConciliado = new System.Windows.Forms.Button();
            this.btProcesar = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.btExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.txtNomCuenta = new System.Windows.Forms.TextBox();
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBancosEmpresa = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboCuentas = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvImportados = new System.Windows.Forms.DataGridView();
            this.numItemConci2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsConciliacion = new System.Windows.Forms.BindingSource(this.components);
            this.lbRegistrosC = new MyLabelG.LabelDegradado();
            this.indConciliado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.desLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipoCobranzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecCobranzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numChequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numItemConci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobranzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCobranzas)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConciliacion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMontoImportados
            // 
            this.txtMontoImportados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoImportados.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoImportados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoImportados.Location = new System.Drawing.Point(1274, 525);
            this.txtMontoImportados.Name = "txtMontoImportados";
            this.txtMontoImportados.ReadOnly = true;
            this.txtMontoImportados.Size = new System.Drawing.Size(98, 21);
            this.txtMontoImportados.TabIndex = 396;
            this.txtMontoImportados.TabStop = false;
            this.txtMontoImportados.Text = "0.00";
            this.txtMontoImportados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1231, 529);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 395;
            this.label8.Text = "Total";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoTotal.Location = new System.Drawing.Point(604, 525);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(98, 21);
            this.txtMontoTotal.TabIndex = 394;
            this.txtMontoTotal.TabStop = false;
            this.txtMontoTotal.Text = "0.00";
            this.txtMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(526, 529);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 393;
            this.label7.Text = "Monto Total";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvCobranzas);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 166);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(801, 354);
            this.pnlDetalle.TabIndex = 386;
            // 
            // dgvCobranzas
            // 
            this.dgvCobranzas.AllowUserToAddRows = false;
            this.dgvCobranzas.AllowUserToDeleteRows = false;
            this.dgvCobranzas.AutoGenerateColumns = false;
            this.dgvCobranzas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvCobranzas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobranzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indConciliado,
            this.desLocalDataGridViewTextBoxColumn,
            this.codPlanilla,
            this.desTipoCobranzaDataGridViewTextBoxColumn,
            this.fecCobranzaDataGridViewTextBoxColumn,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numChequeDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.numItemConci});
            this.dgvCobranzas.DataSource = this.bsCobranzas;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCobranzas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCobranzas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCobranzas.EnableHeadersVisualStyles = false;
            this.dgvCobranzas.Location = new System.Drawing.Point(0, 17);
            this.dgvCobranzas.Name = "dgvCobranzas";
            this.dgvCobranzas.Size = new System.Drawing.Size(799, 335);
            this.dgvCobranzas.TabIndex = 248;
            this.dgvCobranzas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellValueChanged);
            this.dgvCobranzas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCobranzas_CurrentCellDirtyStateChanged);
            this.dgvCobranzas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCobranzas_DataError);
            // 
            // bsCobranzas
            // 
            this.bsCobranzas.DataSource = typeof(Entidades.CtasPorCobrar.CobranzasItemE);
            this.bsCobranzas.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCobranzas_ListChanged);
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
            this.lblRegistros.Size = new System.Drawing.Size(799, 17);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpFinal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpInicial);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.pbProgress);
            this.panel2.Controls.Add(this.lblProcesando);
            this.panel2.Controls.Add(this.btExaminar);
            this.panel2.Controls.Add(this.txtRuta);
            this.panel2.Controls.Add(this.txtNomCuenta);
            this.panel2.Controls.Add(this.txtCodCuenta);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboMoneda);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cboBancosEmpresa);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.cboCuentas);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 160);
            this.panel2.TabIndex = 385;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(187, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 393;
            this.label3.Text = "Fec.Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.CustomFormat = "dd/MM/yyyy";
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinal.Location = new System.Drawing.Point(240, 130);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(96, 20);
            this.dtpFinal.TabIndex = 392;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 391;
            this.label2.Text = "Fec.Inicio";
            // 
            // dtpInicial
            // 
            this.dtpInicial.CustomFormat = "dd/MM/yyyy";
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicial.Location = new System.Drawing.Point(85, 130);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(96, 20);
            this.dtpInicial.TabIndex = 390;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Location = new System.Drawing.Point(7, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 2);
            this.panel1.TabIndex = 388;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btLimpiar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btActualizar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btConciliado, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btProcesar, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(650, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 126);
            this.tableLayoutPanel1.TabIndex = 387;
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btLimpiar.Enabled = false;
            this.btLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Image = global::ClienteWinForm.Properties.Resources.Intrucciones;
            this.btLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLimpiar.Location = new System.Drawing.Point(2, 65);
            this.btLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(64, 49);
            this.btLimpiar.TabIndex = 386;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btActualizar.Enabled = false;
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Image = global::ClienteWinForm.Properties.Resources.ActualizarExcel;
            this.btActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btActualizar.Location = new System.Drawing.Point(2, 2);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(64, 49);
            this.btActualizar.TabIndex = 383;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btConciliado
            // 
            this.btConciliado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btConciliado.Enabled = false;
            this.btConciliado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConciliado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btConciliado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btConciliado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConciliado.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConciliado.Image = global::ClienteWinForm.Properties.Resources.Intrucciones;
            this.btConciliado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConciliado.Location = new System.Drawing.Point(74, 65);
            this.btConciliado.Margin = new System.Windows.Forms.Padding(2);
            this.btConciliado.Name = "btConciliado";
            this.btConciliado.Size = new System.Drawing.Size(64, 49);
            this.btConciliado.TabIndex = 385;
            this.btConciliado.Text = "Conciliado";
            this.btConciliado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConciliado.UseVisualStyleBackColor = false;
            this.btConciliado.Click += new System.EventHandler(this.btConciliado_Click);
            // 
            // btProcesar
            // 
            this.btProcesar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btProcesar.Enabled = false;
            this.btProcesar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProcesar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcesar.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.btProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btProcesar.Location = new System.Drawing.Point(74, 2);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(64, 49);
            this.btProcesar.TabIndex = 384;
            this.btProcesar.Text = "Procesar";
            this.btProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProcesar.UseVisualStyleBackColor = false;
            this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(557, 24);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(40, 36);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 381;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.Transparent;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProcesando.Location = new System.Drawing.Point(21, 53);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 14);
            this.lblProcesando.TabIndex = 380;
            // 
            // btExaminar
            // 
            this.btExaminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExaminar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExaminar.Location = new System.Drawing.Point(471, 29);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(81, 21);
            this.btExaminar.TabIndex = 378;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRuta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(95, 29);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(373, 21);
            this.txtRuta.TabIndex = 379;
            // 
            // txtNomCuenta
            // 
            this.txtNomCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNomCuenta.Location = new System.Drawing.Point(184, 108);
            this.txtNomCuenta.Name = "txtNomCuenta";
            this.txtNomCuenta.ReadOnly = true;
            this.txtNomCuenta.Size = new System.Drawing.Size(464, 20);
            this.txtNomCuenta.TabIndex = 377;
            this.txtNomCuenta.TabStop = false;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodCuenta.Location = new System.Drawing.Point(85, 108);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.ReadOnly = true;
            this.txtCodCuenta.Size = new System.Drawing.Size(96, 20);
            this.txtCodCuenta.TabIndex = 375;
            this.txtCodCuenta.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 374;
            this.label6.Text = "Cod. Cuenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 372;
            this.label5.Text = "Importar Excel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 371;
            this.label1.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.DropDownWidth = 132;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Items.AddRange(new object[] {
            "Pendiente",
            "Cancelados"});
            this.cboMoneda.Location = new System.Drawing.Point(336, 85);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(48, 21);
            this.cboMoneda.TabIndex = 370;
            this.cboMoneda.SelectionChangeCommitted += new System.EventHandler(this.cboMoneda_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 367;
            this.label13.Text = "Bancos";
            // 
            // cboBancosEmpresa
            // 
            this.cboBancosEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosEmpresa.DropDownWidth = 150;
            this.cboBancosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosEmpresa.FormattingEnabled = true;
            this.cboBancosEmpresa.Items.AddRange(new object[] {
            "Pendiente",
            "Cancelados"});
            this.cboBancosEmpresa.Location = new System.Drawing.Point(85, 85);
            this.cboBancosEmpresa.Name = "cboBancosEmpresa";
            this.cboBancosEmpresa.Size = new System.Drawing.Size(195, 21);
            this.cboBancosEmpresa.TabIndex = 366;
            this.cboBancosEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cboBancosEmpresa_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(391, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 365;
            this.label14.Text = "Nro. Cuenta";
            // 
            // cboCuentas
            // 
            this.cboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentas.DropDownWidth = 140;
            this.cboCuentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuentas.FormattingEnabled = true;
            this.cboCuentas.Location = new System.Drawing.Point(460, 85);
            this.cboCuentas.Name = "cboCuentas";
            this.cboCuentas.Size = new System.Drawing.Size(187, 21);
            this.cboCuentas.TabIndex = 364;
            this.cboCuentas.SelectionChangeCommitted += new System.EventHandler(this.cboCuentas_SelectionChangeCommitted);
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
            this.labelDegradado1.Size = new System.Drawing.Size(799, 17);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvImportados);
            this.panel3.Controls.Add(this.lbRegistrosC);
            this.panel3.Location = new System.Drawing.Point(807, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 517);
            this.panel3.TabIndex = 387;
            // 
            // dgvImportados
            // 
            this.dgvImportados.AllowUserToAddRows = false;
            this.dgvImportados.AllowUserToDeleteRows = false;
            this.dgvImportados.AutoGenerateColumns = false;
            this.dgvImportados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvImportados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvImportados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numItemConci2,
            this.RazonSocial,
            this.fechaDataGridViewTextBoxColumn1,
            this.glosaDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn1,
            this.operacionDataGridViewTextBoxColumn});
            this.dgvImportados.DataSource = this.bsConciliacion;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImportados.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvImportados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImportados.EnableHeadersVisualStyles = false;
            this.dgvImportados.Location = new System.Drawing.Point(0, 17);
            this.dgvImportados.Name = "dgvImportados";
            this.dgvImportados.ReadOnly = true;
            this.dgvImportados.Size = new System.Drawing.Size(648, 498);
            this.dgvImportados.TabIndex = 248;
            this.dgvImportados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvImportados_CellFormatting);
            // 
            // numItemConci2
            // 
            this.numItemConci2.DataPropertyName = "numItemConci";
            this.numItemConci2.HeaderText = "N°";
            this.numItemConci2.Name = "numItemConci2";
            this.numItemConci2.ReadOnly = true;
            this.numItemConci2.Width = 30;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Banco";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 200;
            // 
            // fechaDataGridViewTextBoxColumn1
            // 
            this.fechaDataGridViewTextBoxColumn1.DataPropertyName = "Fecha";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            this.fechaDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaDataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn1.Name = "fechaDataGridViewTextBoxColumn1";
            this.fechaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn1.Width = 70;
            // 
            // glosaDataGridViewTextBoxColumn
            // 
            this.glosaDataGridViewTextBoxColumn.DataPropertyName = "Glosa";
            this.glosaDataGridViewTextBoxColumn.HeaderText = "Glosa";
            this.glosaDataGridViewTextBoxColumn.Name = "glosaDataGridViewTextBoxColumn";
            this.glosaDataGridViewTextBoxColumn.ReadOnly = true;
            this.glosaDataGridViewTextBoxColumn.Width = 150;
            // 
            // montoDataGridViewTextBoxColumn1
            // 
            this.montoDataGridViewTextBoxColumn1.DataPropertyName = "Monto";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.montoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.montoDataGridViewTextBoxColumn1.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn1.Name = "montoDataGridViewTextBoxColumn1";
            this.montoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn1.Width = 80;
            // 
            // operacionDataGridViewTextBoxColumn
            // 
            this.operacionDataGridViewTextBoxColumn.DataPropertyName = "Operacion";
            this.operacionDataGridViewTextBoxColumn.HeaderText = "Operación";
            this.operacionDataGridViewTextBoxColumn.Name = "operacionDataGridViewTextBoxColumn";
            this.operacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.operacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsConciliacion
            // 
            this.bsConciliacion.DataSource = typeof(Entidades.CtasPorCobrar.CobranzasConciliacionE);
            this.bsConciliacion.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsConciliacion_ListChanged);
            // 
            // lbRegistrosC
            // 
            this.lbRegistrosC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbRegistrosC.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lbRegistrosC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistrosC.ForeColor = System.Drawing.Color.White;
            this.lbRegistrosC.Location = new System.Drawing.Point(0, 0);
            this.lbRegistrosC.Name = "lbRegistrosC";
            this.lbRegistrosC.PrimerColor = System.Drawing.Color.SlateGray;
            this.lbRegistrosC.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lbRegistrosC.Size = new System.Drawing.Size(648, 17);
            this.lbRegistrosC.TabIndex = 258;
            this.lbRegistrosC.Text = "Registros Importados 0";
            this.lbRegistrosC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // indConciliado
            // 
            this.indConciliado.DataPropertyName = "indConciliado";
            this.indConciliado.HeaderText = "Conc.";
            this.indConciliado.Name = "indConciliado";
            this.indConciliado.ReadOnly = true;
            this.indConciliado.ToolTipText = "Indica si está conciliado";
            this.indConciliado.Width = 40;
            // 
            // desLocalDataGridViewTextBoxColumn
            // 
            this.desLocalDataGridViewTextBoxColumn.DataPropertyName = "desLocal";
            this.desLocalDataGridViewTextBoxColumn.HeaderText = "Local";
            this.desLocalDataGridViewTextBoxColumn.Name = "desLocalDataGridViewTextBoxColumn";
            this.desLocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codPlanilla
            // 
            this.codPlanilla.DataPropertyName = "codPlanilla";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codPlanilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.codPlanilla.HeaderText = "Cód.Planilla";
            this.codPlanilla.Name = "codPlanilla";
            this.codPlanilla.ReadOnly = true;
            this.codPlanilla.Width = 90;
            // 
            // desTipoCobranzaDataGridViewTextBoxColumn
            // 
            this.desTipoCobranzaDataGridViewTextBoxColumn.DataPropertyName = "desTipoCobranza";
            this.desTipoCobranzaDataGridViewTextBoxColumn.HeaderText = "Tipo Cobranza";
            this.desTipoCobranzaDataGridViewTextBoxColumn.Name = "desTipoCobranzaDataGridViewTextBoxColumn";
            this.desTipoCobranzaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desTipoCobranzaDataGridViewTextBoxColumn.Width = 200;
            // 
            // fecCobranzaDataGridViewTextBoxColumn
            // 
            this.fecCobranzaDataGridViewTextBoxColumn.DataPropertyName = "fecCobranza";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.fecCobranzaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecCobranzaDataGridViewTextBoxColumn.HeaderText = "Fec.Cob.";
            this.fecCobranzaDataGridViewTextBoxColumn.Name = "fecCobranzaDataGridViewTextBoxColumn";
            this.fecCobranzaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecCobranzaDataGridViewTextBoxColumn.ToolTipText = "Fecha de cobranza";
            this.fecCobranzaDataGridViewTextBoxColumn.Width = 70;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "T.D.";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 40;
            // 
            // numChequeDataGridViewTextBoxColumn
            // 
            this.numChequeDataGridViewTextBoxColumn.DataPropertyName = "numCheque";
            this.numChequeDataGridViewTextBoxColumn.HeaderText = "N° Documento";
            this.numChequeDataGridViewTextBoxColumn.Name = "numChequeDataGridViewTextBoxColumn";
            this.numChequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.numChequeDataGridViewTextBoxColumn.Width = 95;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn.Width = 90;
            // 
            // numItemConci
            // 
            this.numItemConci.DataPropertyName = "numItemConci";
            this.numItemConci.HeaderText = "N°";
            this.numItemConci.Name = "numItemConci";
            this.numItemConci.ReadOnly = true;
            this.numItemConci.Width = 30;
            // 
            // frmConciliacionCobranzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 548);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtMontoImportados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmConciliacionCobranzas";
            this.Text = "Conciliación de Cobranzas";
            this.Load += new System.EventHandler(this.frmConciliacionCobranzas_Load);
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobranzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCobranzas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConciliacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMontoImportados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvCobranzas;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.Button btConciliado;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.TextBox txtNomCuenta;
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBancosEmpresa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCuentas;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvImportados;
        private MyLabelG.LabelDegradado lbRegistrosC;
        private System.Windows.Forms.BindingSource bsCobranzas;
        private System.Windows.Forms.BindingSource bsConciliacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numItemConci2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indConciliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn desLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoCobranzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecCobranzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numChequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numItemConci;
    }
}