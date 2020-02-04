namespace ClienteWinForm.Ventas
{
    partial class frmListadoCancelacionesPorCobrar
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
            this.bsCancelaciones = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvCobranzas = new System.Windows.Forms.DataGridView();
            this.Marcar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoReciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieReciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoReciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecAbonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaRecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoRecibidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDocuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAplicarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlanillaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlComprobante = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.chkCobranza = new System.Windows.Forms.CheckBox();
            this.dtpFecInicio = new System.Windows.Forms.DateTimePicker();
            this.txtNumRec = new ControlesWinForm.SuperTextBox();
            this.txtSerieRec = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDocumentoRec = new System.Windows.Forms.ComboBox();
            this.btGenerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsCancelaciones)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobranzas)).BeginInit();
            this.pnlComprobante.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsCancelaciones
            // 
            this.bsCancelaciones.DataSource = typeof(Entidades.Ventas.EmisionDocumentoCancelacionE);
            this.bsCancelaciones.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCancelaciones_ListChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvCobranzas);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 84);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(780, 288);
            this.panel5.TabIndex = 1673;
            // 
            // dgvCobranzas
            // 
            this.dgvCobranzas.AllowUserToAddRows = false;
            this.dgvCobranzas.AllowUserToDeleteRows = false;
            this.dgvCobranzas.AutoGenerateColumns = false;
            this.dgvCobranzas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobranzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Marcar,
            this.itemDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.idDocumentoReciDataGridViewTextBoxColumn,
            this.numSerieReciDataGridViewTextBoxColumn,
            this.numDocumentoReciDataGridViewTextBoxColumn,
            this.fecAbonoDataGridViewTextBoxColumn,
            this.desMonedaRecDataGridViewTextBoxColumn,
            this.montoRecibidoDataGridViewTextBoxColumn,
            this.tipCambioDataGridViewTextBoxColumn,
            this.desMonedaDocuDataGridViewTextBoxColumn,
            this.montoAplicarDataGridViewTextBoxColumn,
            this.desBancoDataGridViewTextBoxColumn,
            this.codPlanillaDataGridViewTextBoxColumn});
            this.dgvCobranzas.DataSource = this.bsCancelaciones;
            this.dgvCobranzas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCobranzas.EnableHeadersVisualStyles = false;
            this.dgvCobranzas.Location = new System.Drawing.Point(0, 18);
            this.dgvCobranzas.Name = "dgvCobranzas";
            this.dgvCobranzas.Size = new System.Drawing.Size(778, 268);
            this.dgvCobranzas.TabIndex = 250;
            this.dgvCobranzas.TabStop = false;
            this.dgvCobranzas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCobranzas_CellPainting);
            this.dgvCobranzas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellValueChanged);
            this.dgvCobranzas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCobranzas_CurrentCellDirtyStateChanged);
            // 
            // Marcar
            // 
            this.Marcar.DataPropertyName = "Marcar";
            this.Marcar.HeaderText = "";
            this.Marcar.Name = "Marcar";
            this.Marcar.ToolTipText = "Escoger Todos";
            this.Marcar.Width = 20;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 30;
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
            this.fechaDataGridViewTextBoxColumn.Width = 70;
            // 
            // idDocumentoReciDataGridViewTextBoxColumn
            // 
            this.idDocumentoReciDataGridViewTextBoxColumn.DataPropertyName = "idDocumentoReci";
            this.idDocumentoReciDataGridViewTextBoxColumn.HeaderText = "T.Doc.";
            this.idDocumentoReciDataGridViewTextBoxColumn.Name = "idDocumentoReciDataGridViewTextBoxColumn";
            this.idDocumentoReciDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoReciDataGridViewTextBoxColumn.Width = 40;
            // 
            // numSerieReciDataGridViewTextBoxColumn
            // 
            this.numSerieReciDataGridViewTextBoxColumn.DataPropertyName = "numSerieReci";
            this.numSerieReciDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieReciDataGridViewTextBoxColumn.Name = "numSerieReciDataGridViewTextBoxColumn";
            this.numSerieReciDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieReciDataGridViewTextBoxColumn.Width = 50;
            // 
            // numDocumentoReciDataGridViewTextBoxColumn
            // 
            this.numDocumentoReciDataGridViewTextBoxColumn.DataPropertyName = "numDocumentoReci";
            this.numDocumentoReciDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoReciDataGridViewTextBoxColumn.Name = "numDocumentoReciDataGridViewTextBoxColumn";
            this.numDocumentoReciDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoReciDataGridViewTextBoxColumn.Width = 70;
            // 
            // fecAbonoDataGridViewTextBoxColumn
            // 
            this.fecAbonoDataGridViewTextBoxColumn.DataPropertyName = "fecAbono";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.fecAbonoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecAbonoDataGridViewTextBoxColumn.HeaderText = "Fec.Abono";
            this.fecAbonoDataGridViewTextBoxColumn.Name = "fecAbonoDataGridViewTextBoxColumn";
            this.fecAbonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecAbonoDataGridViewTextBoxColumn.Width = 70;
            // 
            // desMonedaRecDataGridViewTextBoxColumn
            // 
            this.desMonedaRecDataGridViewTextBoxColumn.DataPropertyName = "desMonedaRec";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMonedaRecDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.desMonedaRecDataGridViewTextBoxColumn.HeaderText = "Mon.Rec.";
            this.desMonedaRecDataGridViewTextBoxColumn.Name = "desMonedaRecDataGridViewTextBoxColumn";
            this.desMonedaRecDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaRecDataGridViewTextBoxColumn.ToolTipText = "Moneda recibida";
            this.desMonedaRecDataGridViewTextBoxColumn.Width = 60;
            // 
            // montoRecibidoDataGridViewTextBoxColumn
            // 
            this.montoRecibidoDataGridViewTextBoxColumn.DataPropertyName = "MontoRecibido";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.montoRecibidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.montoRecibidoDataGridViewTextBoxColumn.HeaderText = "Imp. Rec.";
            this.montoRecibidoDataGridViewTextBoxColumn.Name = "montoRecibidoDataGridViewTextBoxColumn";
            this.montoRecibidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoRecibidoDataGridViewTextBoxColumn.Width = 80;
            // 
            // tipCambioDataGridViewTextBoxColumn
            // 
            this.tipCambioDataGridViewTextBoxColumn.DataPropertyName = "tipCambio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            this.tipCambioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.tipCambioDataGridViewTextBoxColumn.HeaderText = "T.C.";
            this.tipCambioDataGridViewTextBoxColumn.Name = "tipCambioDataGridViewTextBoxColumn";
            this.tipCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipCambioDataGridViewTextBoxColumn.Width = 45;
            // 
            // desMonedaDocuDataGridViewTextBoxColumn
            // 
            this.desMonedaDocuDataGridViewTextBoxColumn.DataPropertyName = "desMonedaDocu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMonedaDocuDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.desMonedaDocuDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaDocuDataGridViewTextBoxColumn.Name = "desMonedaDocuDataGridViewTextBoxColumn";
            this.desMonedaDocuDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaDocuDataGridViewTextBoxColumn.Width = 50;
            // 
            // montoAplicarDataGridViewTextBoxColumn
            // 
            this.montoAplicarDataGridViewTextBoxColumn.DataPropertyName = "MontoAplicar";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.montoAplicarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.montoAplicarDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoAplicarDataGridViewTextBoxColumn.Name = "montoAplicarDataGridViewTextBoxColumn";
            this.montoAplicarDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAplicarDataGridViewTextBoxColumn.Width = 80;
            // 
            // desBancoDataGridViewTextBoxColumn
            // 
            this.desBancoDataGridViewTextBoxColumn.DataPropertyName = "desBanco";
            this.desBancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.desBancoDataGridViewTextBoxColumn.Name = "desBancoDataGridViewTextBoxColumn";
            this.desBancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.desBancoDataGridViewTextBoxColumn.Width = 150;
            // 
            // codPlanillaDataGridViewTextBoxColumn
            // 
            this.codPlanillaDataGridViewTextBoxColumn.DataPropertyName = "codPlanilla";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codPlanillaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.codPlanillaDataGridViewTextBoxColumn.HeaderText = "Cód.Planilla";
            this.codPlanillaDataGridViewTextBoxColumn.Name = "codPlanillaDataGridViewTextBoxColumn";
            this.codPlanillaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPlanillaDataGridViewTextBoxColumn.Width = 80;
            // 
            // pnlComprobante
            // 
            this.pnlComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComprobante.Controls.Add(this.label2);
            this.pnlComprobante.Controls.Add(this.label1);
            this.pnlComprobante.Controls.Add(this.dtpFecFin);
            this.pnlComprobante.Controls.Add(this.chkCobranza);
            this.pnlComprobante.Controls.Add(this.dtpFecInicio);
            this.pnlComprobante.Controls.Add(this.txtNumRec);
            this.pnlComprobante.Controls.Add(this.txtSerieRec);
            this.pnlComprobante.Controls.Add(this.label8);
            this.pnlComprobante.Controls.Add(this.cboDocumentoRec);
            this.pnlComprobante.Location = new System.Drawing.Point(3, 3);
            this.pnlComprobante.Name = "pnlComprobante";
            this.pnlComprobante.Size = new System.Drawing.Size(503, 78);
            this.pnlComprobante.TabIndex = 1674;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1711;
            this.label1.Text = "Al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFin.Location = new System.Drawing.Point(346, 50);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(112, 20);
            this.dtpFecFin.TabIndex = 1710;
            // 
            // chkCobranza
            // 
            this.chkCobranza.AutoSize = true;
            this.chkCobranza.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCobranza.Location = new System.Drawing.Point(19, 53);
            this.chkCobranza.Name = "chkCobranza";
            this.chkCobranza.Size = new System.Drawing.Size(138, 17);
            this.chkCobranza.TabIndex = 1709;
            this.chkCobranza.Text = "Con fecha de abono de";
            this.chkCobranza.UseVisualStyleBackColor = true;
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecInicio.Location = new System.Drawing.Point(163, 50);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(112, 20);
            this.dtpFecInicio.TabIndex = 1707;
            // 
            // txtNumRec
            // 
            this.txtNumRec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumRec.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNumRec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRec.Location = new System.Drawing.Point(360, 26);
            this.txtNumRec.Name = "txtNumRec";
            this.txtNumRec.Size = new System.Drawing.Size(98, 20);
            this.txtNumRec.TabIndex = 1701;
            this.txtNumRec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumRec.TextoVacio = "<Descripcion>";
            // 
            // txtSerieRec
            // 
            this.txtSerieRec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerieRec.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSerieRec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerieRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerieRec.Location = new System.Drawing.Point(264, 26);
            this.txtSerieRec.Name = "txtSerieRec";
            this.txtSerieRec.Size = new System.Drawing.Size(90, 20);
            this.txtSerieRec.TabIndex = 1700;
            this.txtSerieRec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerieRec.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 1702;
            this.label8.Text = "Documento";
            // 
            // cboDocumentoRec
            // 
            this.cboDocumentoRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentoRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentoRec.ForeColor = System.Drawing.Color.Black;
            this.cboDocumentoRec.FormattingEnabled = true;
            this.cboDocumentoRec.Location = new System.Drawing.Point(94, 26);
            this.cboDocumentoRec.Name = "cboDocumentoRec";
            this.cboDocumentoRec.Size = new System.Drawing.Size(165, 21);
            this.cboDocumentoRec.TabIndex = 1699;
            // 
            // btGenerar
            // 
            this.btGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenerar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenerar.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.btGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGenerar.Location = new System.Drawing.Point(512, 3);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(88, 78);
            this.btGenerar.TabIndex = 1675;
            this.btGenerar.TabStop = false;
            this.btGenerar.Text = "Generar Cobranza";
            this.btGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(501, 18);
            this.label2.TabIndex = 1712;
            this.label2.Text = "Parámetros de Búsqueda";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(778, 18);
            this.lblRegistros.TabIndex = 370;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoCancelacionesPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 375);
            this.Controls.Add(this.btGenerar);
            this.Controls.Add(this.pnlComprobante);
            this.Controls.Add(this.panel5);
            this.Name = "frmListadoCancelacionesPorCobrar";
            this.Text = "Cancelaciones por Cobrar";
            this.Load += new System.EventHandler(this.frmListadoCancelacionesPorCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCancelaciones)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobranzas)).EndInit();
            this.pnlComprobante.ResumeLayout(false);
            this.pnlComprobante.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCancelaciones;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvCobranzas;
        private System.Windows.Forms.Panel pnlComprobante;
        private ControlesWinForm.SuperTextBox txtNumRec;
        private ControlesWinForm.SuperTextBox txtSerieRec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDocumentoRec;
        private System.Windows.Forms.DateTimePicker dtpFecInicio;
        private System.Windows.Forms.Button btGenerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.CheckBox chkCobranza;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Marcar;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoReciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieReciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoReciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecAbonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaRecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoRecibidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDocuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAplicarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlanillaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label2;
    }
}