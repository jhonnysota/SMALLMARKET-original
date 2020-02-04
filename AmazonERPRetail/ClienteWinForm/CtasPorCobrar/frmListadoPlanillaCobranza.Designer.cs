namespace ClienteWinForm.CtasPorCobrar
{
    partial class frmListadoPlanillaCobranza
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFechas = new System.Windows.Forms.Panel();
            this.pnlCobranza = new System.Windows.Forms.Panel();
            this.cboTipoCobranza = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.idPlanillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlanillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCtaDetino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoSolesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDolaresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VieneFact = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsTipoCobranza = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimpiarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFusion = new System.Windows.Forms.ToolStripMenuItem();
            this.bsCobranzas = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.lblRazon = new System.Windows.Forms.Label();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmiDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFechas.SuspendLayout();
            this.pnlCobranza.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.cmsTipoCobranza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCobranzas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.labelDegradado3.Size = new System.Drawing.Size(297, 17);
            this.labelDegradado3.TabIndex = 248;
            this.labelDegradado3.Text = "Fechas";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(185, 27);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 102;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(52, 27);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 259;
            this.label1.Text = "Desde";
            // 
            // pnlFechas
            // 
            this.pnlFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFechas.Controls.Add(this.label1);
            this.pnlFechas.Controls.Add(this.label2);
            this.pnlFechas.Controls.Add(this.dtpInicio);
            this.pnlFechas.Controls.Add(this.dtpFinal);
            this.pnlFechas.Controls.Add(this.labelDegradado3);
            this.pnlFechas.Location = new System.Drawing.Point(296, 3);
            this.pnlFechas.Name = "pnlFechas";
            this.pnlFechas.Size = new System.Drawing.Size(299, 63);
            this.pnlFechas.TabIndex = 101;
            // 
            // pnlCobranza
            // 
            this.pnlCobranza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCobranza.Controls.Add(this.cboTipoCobranza);
            this.pnlCobranza.Controls.Add(this.labelDegradado1);
            this.pnlCobranza.Location = new System.Drawing.Point(3, 3);
            this.pnlCobranza.Name = "pnlCobranza";
            this.pnlCobranza.Size = new System.Drawing.Size(291, 63);
            this.pnlCobranza.TabIndex = 102;
            // 
            // cboTipoCobranza
            // 
            this.cboTipoCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCobranza.ForeColor = System.Drawing.Color.Black;
            this.cboTipoCobranza.FormattingEnabled = true;
            this.cboTipoCobranza.Location = new System.Drawing.Point(13, 27);
            this.cboTipoCobranza.Name = "cboTipoCobranza";
            this.cboTipoCobranza.Size = new System.Drawing.Size(265, 21);
            this.cboTipoCobranza.TabIndex = 263;
            this.cboTipoCobranza.SelectionChangeCommitted += new System.EventHandler(this.cboTipoCobranza_SelectionChangeCommitted);
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
            this.labelDegradado1.Size = new System.Drawing.Size(289, 17);
            this.labelDegradado1.TabIndex = 248;
            this.labelDegradado1.Text = "Tipo Planilla";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlListado
            // 
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListado.Controls.Add(this.dgvListado);
            this.pnlListado.Controls.Add(this.lblRegistros);
            this.pnlListado.Location = new System.Drawing.Point(3, 68);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(1111, 355);
            this.pnlListado.TabIndex = 299;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPlanillaDataGridViewTextBoxColumn,
            this.codPlanillaDataGridViewTextBoxColumn,
            this.Fecha,
            this.idDocumento,
            this.numCheque,
            this.TipCambio,
            this.desCtaDetino,
            this.montoSolesDataGridViewTextBoxColumn,
            this.montoDolaresDataGridViewTextBoxColumn,
            this.desEstado,
            this.idComprobante,
            this.numFile,
            this.numVoucher,
            this.VieneFact,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListado.ContextMenuStrip = this.cmsTipoCobranza;
            this.dgvListado.DataSource = this.bsCobranzas;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 19);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1109, 334);
            this.dgvListado.TabIndex = 250;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            this.dgvListado.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListado_ColumnHeaderMouseClick);
            // 
            // idPlanillaDataGridViewTextBoxColumn
            // 
            this.idPlanillaDataGridViewTextBoxColumn.DataPropertyName = "idPlanilla";
            this.idPlanillaDataGridViewTextBoxColumn.HeaderText = "ID.";
            this.idPlanillaDataGridViewTextBoxColumn.Name = "idPlanillaDataGridViewTextBoxColumn";
            this.idPlanillaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPlanillaDataGridViewTextBoxColumn.Width = 50;
            // 
            // codPlanillaDataGridViewTextBoxColumn
            // 
            this.codPlanillaDataGridViewTextBoxColumn.DataPropertyName = "codPlanilla";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codPlanillaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.codPlanillaDataGridViewTextBoxColumn.HeaderText = "Cód.Planilla";
            this.codPlanillaDataGridViewTextBoxColumn.Name = "codPlanillaDataGridViewTextBoxColumn";
            this.codPlanillaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPlanillaDataGridViewTextBoxColumn.Width = 90;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 90;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 40;
            // 
            // numCheque
            // 
            this.numCheque.DataPropertyName = "numCheque";
            this.numCheque.HeaderText = "Número";
            this.numCheque.Name = "numCheque";
            this.numCheque.ReadOnly = true;
            this.numCheque.Width = 80;
            // 
            // TipCambio
            // 
            this.TipCambio.DataPropertyName = "TipCambio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.TipCambio.DefaultCellStyle = dataGridViewCellStyle3;
            this.TipCambio.HeaderText = "T.C.";
            this.TipCambio.Name = "TipCambio";
            this.TipCambio.ReadOnly = true;
            this.TipCambio.Width = 40;
            // 
            // desCtaDetino
            // 
            this.desCtaDetino.DataPropertyName = "desCtaDetino";
            this.desCtaDetino.HeaderText = "Descripción Cuenta";
            this.desCtaDetino.Name = "desCtaDetino";
            this.desCtaDetino.ReadOnly = true;
            this.desCtaDetino.Width = 140;
            // 
            // montoSolesDataGridViewTextBoxColumn
            // 
            this.montoSolesDataGridViewTextBoxColumn.DataPropertyName = "MontoSoles";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.montoSolesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.montoSolesDataGridViewTextBoxColumn.HeaderText = "Monto S/.";
            this.montoSolesDataGridViewTextBoxColumn.Name = "montoSolesDataGridViewTextBoxColumn";
            this.montoSolesDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoSolesDataGridViewTextBoxColumn.Width = 80;
            // 
            // montoDolaresDataGridViewTextBoxColumn
            // 
            this.montoDolaresDataGridViewTextBoxColumn.DataPropertyName = "MontoDolares";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.montoDolaresDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.montoDolaresDataGridViewTextBoxColumn.HeaderText = "Monto US$";
            this.montoDolaresDataGridViewTextBoxColumn.Name = "montoDolaresDataGridViewTextBoxColumn";
            this.montoDolaresDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDolaresDataGridViewTextBoxColumn.Width = 80;
            // 
            // desEstado
            // 
            this.desEstado.DataPropertyName = "desEstado";
            this.desEstado.HeaderText = "Estado";
            this.desEstado.Name = "desEstado";
            this.desEstado.ReadOnly = true;
            this.desEstado.Width = 80;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            this.idComprobante.HeaderText = "Diario";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Width = 42;
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
            // VieneFact
            // 
            this.VieneFact.DataPropertyName = "VieneFact";
            this.VieneFact.HeaderText = "M.F.";
            this.VieneFact.Name = "VieneFact";
            this.VieneFact.ReadOnly = true;
            this.VieneFact.ToolTipText = "Viene del módulo de facturación";
            this.VieneFact.Width = 30;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // cmsTipoCobranza
            // 
            this.cmsTipoCobranza.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsTipoCobranza.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbrir,
            this.tsmiCerrar,
            this.toolStripSeparator1,
            this.tsmiImprimir,
            this.tsmiLimpiarVoucher,
            this.toolStripSeparator2,
            this.tsmiFusion,
            this.tsmiDocumentos});
            this.cmsTipoCobranza.Name = "cmsFactura";
            this.cmsTipoCobranza.Size = new System.Drawing.Size(181, 170);
            // 
            // tsmiAbrir
            // 
            this.tsmiAbrir.Image = global::ClienteWinForm.Properties.Resources.ver_documentos_16x16;
            this.tsmiAbrir.Name = "tsmiAbrir";
            this.tsmiAbrir.Size = new System.Drawing.Size(180, 22);
            this.tsmiAbrir.Text = "Abrir Planilla";
            this.tsmiAbrir.Click += new System.EventHandler(this.tsmiAbrir_Click);
            // 
            // tsmiCerrar
            // 
            this.tsmiCerrar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiCerrar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.tsmiCerrar.Name = "tsmiCerrar";
            this.tsmiCerrar.Size = new System.Drawing.Size(180, 22);
            this.tsmiCerrar.Text = "Cerrar Planilla";
            this.tsmiCerrar.Click += new System.EventHandler(this.tsmiCerrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Red;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiImprimir
            // 
            this.tsmiImprimir.Image = global::ClienteWinForm.Properties.Resources.ImpresoraVerde;
            this.tsmiImprimir.Name = "tsmiImprimir";
            this.tsmiImprimir.Size = new System.Drawing.Size(180, 22);
            this.tsmiImprimir.Text = "Imprimir Voucher";
            this.tsmiImprimir.Click += new System.EventHandler(this.tsmiImprimir_Click);
            // 
            // tsmiLimpiarVoucher
            // 
            this.tsmiLimpiarVoucher.Image = global::ClienteWinForm.Properties.Resources.RevisarGris;
            this.tsmiLimpiarVoucher.Name = "tsmiLimpiarVoucher";
            this.tsmiLimpiarVoucher.Size = new System.Drawing.Size(180, 22);
            this.tsmiLimpiarVoucher.Text = "Limpiar Voucher";
            this.tsmiLimpiarVoucher.Click += new System.EventHandler(this.tsmiLimpiarVoucher_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiFusion
            // 
            this.tsmiFusion.Image = global::ClienteWinForm.Properties.Resources.Fusion_16x16;
            this.tsmiFusion.Name = "tsmiFusion";
            this.tsmiFusion.Size = new System.Drawing.Size(180, 22);
            this.tsmiFusion.Text = "Combinar";
            this.tsmiFusion.Click += new System.EventHandler(this.tsmiFusion_Click);
            // 
            // bsCobranzas
            // 
            this.bsCobranzas.DataSource = typeof(Entidades.CtasPorCobrar.CobranzasE);
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
            this.lblRegistros.Size = new System.Drawing.Size(1109, 19);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.Location = new System.Drawing.Point(10, 32);
            this.lblRazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(56, 13);
            this.lblRazon.TabIndex = 301;
            this.lblRazon.Text = "Operación";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(70, 28);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(134, 20);
            this.txtDescripcion.TabIndex = 300;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.lblRazon);
            this.panel2.Location = new System.Drawing.Point(597, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 63);
            this.panel2.TabIndex = 302;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(216, 18);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "N°";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idDocumento";
            this.dataGridViewTextBoxColumn1.HeaderText = "T.D.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "numCheque";
            this.dataGridViewTextBoxColumn2.HeaderText = "Número";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "idComprobante";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Diario";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 42;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "numFile";
            this.dataGridViewTextBoxColumn4.HeaderText = "File";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "numVoucher";
            this.dataGridViewTextBoxColumn5.HeaderText = "Voucher";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "numFile";
            this.dataGridViewTextBoxColumn6.HeaderText = "File";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "numVoucher";
            this.dataGridViewTextBoxColumn7.HeaderText = "Voucher";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // tsmiDocumentos
            // 
            this.tsmiDocumentos.Image = global::ClienteWinForm.Properties.Resources.busquedas;
            this.tsmiDocumentos.Name = "tsmiDocumentos";
            this.tsmiDocumentos.Size = new System.Drawing.Size(180, 22);
            this.tsmiDocumentos.Text = "Ver Documentos";
            this.tsmiDocumentos.Click += new System.EventHandler(this.tsmiDocumentos_Click);
            // 
            // frmListadoPlanillaCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 426);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.pnlCobranza);
            this.Controls.Add(this.pnlFechas);
            this.MaximizeBox = false;
            this.Name = "frmListadoPlanillaCobranza";
            this.Text = "Listado de Planilla de Cobranzas";
            this.Load += new System.EventHandler(this.frmListadoPlanillaCobranza_Load);
            this.pnlFechas.ResumeLayout(false);
            this.pnlFechas.PerformLayout();
            this.pnlCobranza.ResumeLayout(false);
            this.pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.cmsTipoCobranza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCobranzas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFechas;
        private System.Windows.Forms.Panel pnlCobranza;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboTipoCobranza;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.ContextMenuStrip cmsTipoCobranza;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbrir;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImprimir;
        private System.Windows.Forms.BindingSource bsCobranzas;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiarVoucher;
        private System.Windows.Forms.Label lblRazon;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlanillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlanillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCtaDetino;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoSolesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDolaresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VieneFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFusion;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocumentos;
    }
}