namespace ClienteWinForm.Contabilidad
{
    partial class frmConciliacionBancariaManual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.idPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistrosV = new MyLabelG.LabelDegradado();
            this.txtAsociación = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAsociacion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvVoucherItem = new System.Windows.Forms.DataGridView();
            this.chkEscoger = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAsociado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btDesvincular = new System.Windows.Forms.Button();
            this.txtLibro = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherItem)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.BancosConciliarE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(568, 308);
            this.btnAceptar.Size = new System.Drawing.Size(103, 28);
            this.btnAceptar.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(196, 331);
            this.btnCancelar.Size = new System.Drawing.Size(173, 28);
            this.btnCancelar.Text = "Cerrar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(759, 151);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1102, 47);
            this.chkAnulado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(803, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(803, 73);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvVoucherItem);
            this.gbResultados.Location = new System.Drawing.Point(6, 76);
            this.gbResultados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbResultados.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbResultados.Size = new System.Drawing.Size(561, 248);
            // 
            // idPersonaDataGridViewTextBoxColumn
            // 
            this.idPersonaDataGridViewTextBoxColumn.DataPropertyName = "idPersona";
            this.idPersonaDataGridViewTextBoxColumn.HeaderText = "idPersona";
            this.idPersonaDataGridViewTextBoxColumn.Name = "idPersonaDataGridViewTextBoxColumn";
            this.idPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // glosaDataGridViewTextBoxColumn
            // 
            this.glosaDataGridViewTextBoxColumn.DataPropertyName = "Glosa";
            this.glosaDataGridViewTextBoxColumn.HeaderText = "Glosa";
            this.glosaDataGridViewTextBoxColumn.Name = "glosaDataGridViewTextBoxColumn";
            this.glosaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operacionDataGridViewTextBoxColumn
            // 
            this.operacionDataGridViewTextBoxColumn.DataPropertyName = "Operacion";
            this.operacionDataGridViewTextBoxColumn.HeaderText = "Operacion";
            this.operacionDataGridViewTextBoxColumn.Name = "operacionDataGridViewTextBoxColumn";
            this.operacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anioPeriodoDataGridViewTextBoxColumn
            // 
            this.anioPeriodoDataGridViewTextBoxColumn.DataPropertyName = "AnioPeriodo";
            this.anioPeriodoDataGridViewTextBoxColumn.HeaderText = "AnioPeriodo";
            this.anioPeriodoDataGridViewTextBoxColumn.Name = "anioPeriodoDataGridViewTextBoxColumn";
            this.anioPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mesPeriodoDataGridViewTextBoxColumn
            // 
            this.mesPeriodoDataGridViewTextBoxColumn.DataPropertyName = "MesPeriodo";
            this.mesPeriodoDataGridViewTextBoxColumn.HeaderText = "MesPeriodo";
            this.mesPeriodoDataGridViewTextBoxColumn.Name = "mesPeriodoDataGridViewTextBoxColumn";
            this.mesPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numVoucherDataGridViewTextBoxColumn
            // 
            this.numVoucherDataGridViewTextBoxColumn.DataPropertyName = "numVoucher";
            this.numVoucherDataGridViewTextBoxColumn.HeaderText = "numVoucher";
            this.numVoucherDataGridViewTextBoxColumn.Name = "numVoucherDataGridViewTextBoxColumn";
            this.numVoucherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idComprobanteDataGridViewTextBoxColumn
            // 
            this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "idComprobante";
            this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "idComprobante";
            this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
            this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numFileDataGridViewTextBoxColumn
            // 
            this.numFileDataGridViewTextBoxColumn.DataPropertyName = "numFile";
            this.numFileDataGridViewTextBoxColumn.HeaderText = "numFile";
            this.numFileDataGridViewTextBoxColumn.Name = "numFileDataGridViewTextBoxColumn";
            this.numFileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numItemDataGridViewTextBoxColumn
            // 
            this.numItemDataGridViewTextBoxColumn.DataPropertyName = "numItem";
            this.numItemDataGridViewTextBoxColumn.HeaderText = "numItem";
            this.numItemDataGridViewTextBoxColumn.Name = "numItemDataGridViewTextBoxColumn";
            this.numItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lblRegistrosV
            // 
            this.lblRegistrosV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistrosV.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistrosV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosV.ForeColor = System.Drawing.Color.White;
            this.lblRegistrosV.Location = new System.Drawing.Point(0, 0);
            this.lblRegistrosV.Name = "lblRegistrosV";
            this.lblRegistrosV.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistrosV.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistrosV.Size = new System.Drawing.Size(721, 18);
            this.lblRegistrosV.TabIndex = 258;
            this.lblRegistrosV.Text = "Registros 0";
            this.lblRegistrosV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAsociación
            // 
            this.txtAsociación.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAsociación.Location = new System.Drawing.Point(228, 47);
            this.txtAsociación.Name = "txtAsociación";
            this.txtAsociación.ReadOnly = true;
            this.txtAsociación.Size = new System.Drawing.Size(135, 20);
            this.txtAsociación.TabIndex = 377;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(159, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 376;
            this.label6.Text = "Mov. Banco";
            // 
            // lblAsociacion
            // 
            this.lblAsociacion.AutoSize = true;
            this.lblAsociacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsociacion.Location = new System.Drawing.Point(382, 50);
            this.lblAsociacion.Name = "lblAsociacion";
            this.lblAsociacion.Size = new System.Drawing.Size(90, 13);
            this.lblAsociacion.TabIndex = 378;
            this.lblAsociacion.Text = "No esta Asociada";
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.borrar_registro;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(524, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 22);
            this.button1.TabIndex = 379;
            this.button1.Text = "Desasociar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgvVoucherItem
            // 
            this.dgvVoucherItem.AllowUserToAddRows = false;
            this.dgvVoucherItem.AllowUserToDeleteRows = false;
            this.dgvVoucherItem.AutoGenerateColumns = false;
            this.dgvVoucherItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvVoucherItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVoucherItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucherItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkEscoger,
            this.itemDataGridViewTextBoxColumn1,
            this.fechaDataGridViewTextBoxColumn1,
            this.glosaDataGridViewTextBoxColumn1,
            this.montoDataGridViewTextBoxColumn1,
            this.operacionDataGridViewTextBoxColumn1});
            this.dgvVoucherItem.DataSource = this.bsBase;
            this.dgvVoucherItem.EnableHeadersVisualStyles = false;
            this.dgvVoucherItem.Location = new System.Drawing.Point(6, 15);
            this.dgvVoucherItem.Name = "dgvVoucherItem";
            this.dgvVoucherItem.Size = new System.Drawing.Size(548, 227);
            this.dgvVoucherItem.TabIndex = 248;
            this.dgvVoucherItem.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvVoucherItem_CurrentCellDirtyStateChanged);
            // 
            // chkEscoger
            // 
            this.chkEscoger.DataPropertyName = "chkEscoger";
            this.chkEscoger.HeaderText = "X";
            this.chkEscoger.Name = "chkEscoger";
            this.chkEscoger.Width = 20;
            // 
            // itemDataGridViewTextBoxColumn1
            // 
            this.itemDataGridViewTextBoxColumn1.DataPropertyName = "item";
            this.itemDataGridViewTextBoxColumn1.HeaderText = "item";
            this.itemDataGridViewTextBoxColumn1.Name = "itemDataGridViewTextBoxColumn1";
            this.itemDataGridViewTextBoxColumn1.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn1.Width = 40;
            // 
            // fechaDataGridViewTextBoxColumn1
            // 
            this.fechaDataGridViewTextBoxColumn1.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn1.Name = "fechaDataGridViewTextBoxColumn1";
            this.fechaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn1.Width = 70;
            // 
            // glosaDataGridViewTextBoxColumn1
            // 
            this.glosaDataGridViewTextBoxColumn1.DataPropertyName = "Glosa";
            this.glosaDataGridViewTextBoxColumn1.HeaderText = "Glosa";
            this.glosaDataGridViewTextBoxColumn1.Name = "glosaDataGridViewTextBoxColumn1";
            this.glosaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.glosaDataGridViewTextBoxColumn1.Width = 200;
            // 
            // montoDataGridViewTextBoxColumn1
            // 
            this.montoDataGridViewTextBoxColumn1.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.montoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoDataGridViewTextBoxColumn1.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn1.Name = "montoDataGridViewTextBoxColumn1";
            this.montoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn1.Width = 80;
            // 
            // operacionDataGridViewTextBoxColumn1
            // 
            this.operacionDataGridViewTextBoxColumn1.DataPropertyName = "Operacion";
            this.operacionDataGridViewTextBoxColumn1.HeaderText = "Operación";
            this.operacionDataGridViewTextBoxColumn1.Name = "operacionDataGridViewTextBoxColumn1";
            this.operacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.operacionDataGridViewTextBoxColumn1.Width = 110;
            // 
            // txtAsociado
            // 
            this.txtAsociado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAsociado.Location = new System.Drawing.Point(200, 8);
            this.txtAsociado.Name = "txtAsociado";
            this.txtAsociado.ReadOnly = true;
            this.txtAsociado.Size = new System.Drawing.Size(98, 20);
            this.txtAsociado.TabIndex = 377;
            this.txtAsociado.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 376;
            this.label2.Text = "Diario - File - Voucher";
            // 
            // btDesvincular
            // 
            this.btDesvincular.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btDesvincular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btDesvincular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btDesvincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDesvincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDesvincular.Image = global::ClienteWinForm.Properties.Resources.Desvincular24x24;
            this.btDesvincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDesvincular.Location = new System.Drawing.Point(345, 24);
            this.btDesvincular.Name = "btDesvincular";
            this.btDesvincular.Size = new System.Drawing.Size(183, 32);
            this.btDesvincular.TabIndex = 380;
            this.btDesvincular.TabStop = false;
            this.btDesvincular.Text = "Desvincular Documentos";
            this.btDesvincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDesvincular.UseVisualStyleBackColor = true;
            this.btDesvincular.Click += new System.EventHandler(this.btDesvincular_Click);
            // 
            // txtLibro
            // 
            this.txtLibro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLibro.Location = new System.Drawing.Point(126, 8);
            this.txtLibro.Name = "txtLibro";
            this.txtLibro.ReadOnly = true;
            this.txtLibro.Size = new System.Drawing.Size(35, 20);
            this.txtLibro.TabIndex = 381;
            this.txtLibro.TabStop = false;
            this.txtLibro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFile.Location = new System.Drawing.Point(163, 8);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(35, 20);
            this.txtFile.TabIndex = 382;
            this.txtFile.TabStop = false;
            this.txtFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDocumento.Location = new System.Drawing.Point(126, 30);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(172, 20);
            this.txtDocumento.TabIndex = 384;
            this.txtDocumento.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 383;
            this.label3.Text = "Documento";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMonto.Location = new System.Drawing.Point(126, 52);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(72, 20);
            this.txtMonto.TabIndex = 386;
            this.txtMonto.TabStop = false;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 385;
            this.label4.Text = "Monto";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoTotal.Location = new System.Drawing.Point(456, 331);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(104, 20);
            this.txtMontoTotal.TabIndex = 388;
            this.txtMontoTotal.TabStop = false;
            this.txtMontoTotal.Text = "0.00";
            this.txtMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(419, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 387;
            this.label5.Text = "Total";
            // 
            // frmConciliacionBancariaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 367);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtLibro);
            this.Controls.Add(this.btDesvincular);
            this.Controls.Add(this.txtAsociado);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConciliacionBancariaManual";
            this.Text = "Conciliación Bancaria Manual";
            this.Load += new System.EventHandler(this.frmConciliacionBancariaManual_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtAsociado, 0);
            this.Controls.SetChildIndex(this.btDesvincular, 0);
            this.Controls.SetChildIndex(this.txtLibro, 0);
            this.Controls.SetChildIndex(this.txtFile, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDocumento, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtMonto, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtMontoTotal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Panel pnlDetalle;
        //private System.Windows.Forms.DataGridView dgvConciliacion;
        private MyLabelG.LabelDegradado lblRegistrosV;
        private System.Windows.Forms.Label lblAsociacion;
        private System.Windows.Forms.TextBox txtAsociación;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvVoucherItem;
        private System.Windows.Forms.TextBox txtAsociado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDesvincular;
        private System.Windows.Forms.TextBox txtLibro;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkEscoger;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label5;
    }
}