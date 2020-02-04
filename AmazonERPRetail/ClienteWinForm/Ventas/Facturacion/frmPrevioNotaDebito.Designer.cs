﻿namespace ClienteWinForm.Ventas.Facturacion
{
    partial class frmPrevioNotaDebito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.lblMotivo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNumDocumento = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFechaRef = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValorVenta = new System.Windows.Forms.Label();
            this.lblDesTotal = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDesValor = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMontoLetras = new System.Windows.Forms.Label();
            this.lblMontoIngles = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSinImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRucComprador = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.lblFecEmision = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNomDocumento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.lblPartida = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoDetE);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(195, 527);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(0, 13);
            this.lblMotivo.TabIndex = 416;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 527);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 12);
            this.label11.TabIndex = 415;
            this.label11.Text = "MOTIVO DE LA MODIFICACION:";
            // 
            // lblNumDocumento
            // 
            this.lblNumDocumento.AutoSize = true;
            this.lblNumDocumento.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumDocumento.Location = new System.Drawing.Point(340, 190);
            this.lblNumDocumento.Name = "lblNumDocumento";
            this.lblNumDocumento.Size = new System.Drawing.Size(0, 13);
            this.lblNumDocumento.TabIndex = 414;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.Location = new System.Drawing.Point(73, 228);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(0, 14);
            this.lblRazonSocial.TabIndex = 413;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(310, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 12);
            this.label7.TabIndex = 412;
            this.label7.Text = "N°";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 12);
            this.label10.TabIndex = 411;
            this.label10.Text = "Por lo siguiente:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 12);
            this.label9.TabIndex = 410;
            this.label9.Text = "Nombre:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 12);
            this.label8.TabIndex = 409;
            this.label8.Text = "DATOS DEL COMPRADOR:";
            // 
            // lblFechaRef
            // 
            this.lblFechaRef.AutoSize = true;
            this.lblFechaRef.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRef.Location = new System.Drawing.Point(582, 190);
            this.lblFechaRef.Name = "lblFechaRef";
            this.lblFechaRef.Size = new System.Drawing.Size(0, 13);
            this.lblFechaRef.TabIndex = 408;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(528, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 407;
            this.label4.Text = "Fecha:";
            // 
            // lblValorVenta
            // 
            this.lblValorVenta.BackColor = System.Drawing.Color.White;
            this.lblValorVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorVenta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVenta.Location = new System.Drawing.Point(668, 518);
            this.lblValorVenta.Name = "lblValorVenta";
            this.lblValorVenta.Size = new System.Drawing.Size(67, 25);
            this.lblValorVenta.TabIndex = 404;
            this.lblValorVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDesTotal
            // 
            this.lblDesTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesTotal.Location = new System.Drawing.Point(576, 570);
            this.lblDesTotal.Name = "lblDesTotal";
            this.lblDesTotal.Size = new System.Drawing.Size(90, 19);
            this.lblDesTotal.TabIndex = 403;
            this.lblDesTotal.Text = "TOTAL";
            this.lblDesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(576, 546);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(89, 19);
            this.lblPrecio.TabIndex = 402;
            this.lblPrecio.Text = "I.G.V.      %";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesValor
            // 
            this.lblDesValor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesValor.Location = new System.Drawing.Point(573, 523);
            this.lblDesValor.Name = "lblDesValor";
            this.lblDesValor.Size = new System.Drawing.Size(87, 19);
            this.lblDesValor.TabIndex = 401;
            this.lblDesValor.Text = "SUB - TOTAL";
            this.lblDesValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblMontoLetras);
            this.panel3.Controls.Add(this.lblMontoIngles);
            this.panel3.Controls.Add(this.dgvDetalle);
            this.panel3.Location = new System.Drawing.Point(13, 265);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 254);
            this.panel3.TabIndex = 400;
            // 
            // lblMontoLetras
            // 
            this.lblMontoLetras.AutoSize = true;
            this.lblMontoLetras.BackColor = System.Drawing.Color.White;
            this.lblMontoLetras.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoLetras.Location = new System.Drawing.Point(101, 204);
            this.lblMontoLetras.Name = "lblMontoLetras";
            this.lblMontoLetras.Size = new System.Drawing.Size(0, 11);
            this.lblMontoLetras.TabIndex = 358;
            this.lblMontoLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMontoIngles
            // 
            this.lblMontoIngles.AutoSize = true;
            this.lblMontoIngles.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoIngles.Location = new System.Drawing.Point(101, 222);
            this.lblMontoIngles.Name = "lblMontoIngles";
            this.lblMontoIngles.Size = new System.Drawing.Size(0, 12);
            this.lblMontoIngles.TabIndex = 12;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidadDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.PrecioSinImpuesto,
            this.Total});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Enabled = false;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.Black;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalle.Size = new System.Drawing.Size(720, 252);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalle_CellFormatting);
            this.dgvDetalle.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalle_CellPainting);
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "CANT.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nomArticuloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PrecioSinImpuesto
            // 
            this.PrecioSinImpuesto.DataPropertyName = "PrecioCad";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.PrecioSinImpuesto.DefaultCellStyle = dataGridViewCellStyle9;
            this.PrecioSinImpuesto.HeaderText = "P.UNITARIO";
            this.PrecioSinImpuesto.Name = "PrecioSinImpuesto";
            this.PrecioSinImpuesto.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TotalCad";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle10;
            this.Total.HeaderText = "IMPORTE";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(668, 566);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(67, 25);
            this.lblTotal.TabIndex = 406;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(537, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 399;
            this.label6.Text = "RUC:";
            // 
            // lblRucComprador
            // 
            this.lblRucComprador.AutoSize = true;
            this.lblRucComprador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucComprador.Location = new System.Drawing.Point(582, 228);
            this.lblRucComprador.Name = "lblRucComprador";
            this.lblRucComprador.Size = new System.Drawing.Size(0, 14);
            this.lblRucComprador.TabIndex = 398;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(470, 171);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(96, 12);
            this.Label12.TabIndex = 397;
            this.Label12.Text = "Fecha de Emisión:";
            // 
            // lblFecEmision
            // 
            this.lblFecEmision.AutoSize = true;
            this.lblFecEmision.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecEmision.Location = new System.Drawing.Point(582, 171);
            this.lblFecEmision.Name = "lblFecEmision";
            this.lblFecEmision.Size = new System.Drawing.Size(0, 13);
            this.lblFecEmision.TabIndex = 396;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 395;
            this.label5.Text = "Sr.(es):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 12);
            this.label3.TabIndex = 394;
            this.label3.Text = "DOCUMENTO QUE MODIFICA:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 392;
            this.pictureBox1.TabStop = false;
            // 
            // lblNomDocumento
            // 
            this.lblNomDocumento.AutoSize = true;
            this.lblNomDocumento.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomDocumento.Location = new System.Drawing.Point(73, 190);
            this.lblNomDocumento.Name = "lblNomDocumento";
            this.lblNomDocumento.Size = new System.Drawing.Size(0, 13);
            this.lblNomDocumento.TabIndex = 393;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 12);
            this.label2.TabIndex = 391;
            this.label2.Text = "Av. Los Libertadores Km. 0.6 San Clemente - Pisco - Ica Telf: (51-1) 2418899";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(465, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 144);
            this.panel1.TabIndex = 390;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Red;
            this.lblNumero.Location = new System.Drawing.Point(141, 109);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(33, 22);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "N°";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(83, 109);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(43, 22);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "000";
            // 
            // lblRuc
            // 
            this.lblRuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRuc.BackColor = System.Drawing.Color.White;
            this.lblRuc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.Location = new System.Drawing.Point(-1, 13);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(270, 23);
            this.lblRuc.TabIndex = 1;
            this.lblRuc.Text = "R.U.C.";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOTA DE DEBITO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIgv
            // 
            this.lblIgv.BackColor = System.Drawing.Color.White;
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.Location = new System.Drawing.Point(668, 542);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(67, 25);
            this.lblIgv.TabIndex = 405;
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartida
            // 
            this.lblPartida.AutoSize = true;
            this.lblPartida.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartida.Location = new System.Drawing.Point(100, 553);
            this.lblPartida.Name = "lblPartida";
            this.lblPartida.Size = new System.Drawing.Size(0, 12);
            this.lblPartida.TabIndex = 417;
            // 
            // pnlBase
            // 
            this.pnlBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.lblPartida);
            this.pnlBase.Controls.Add(this.lblIgv);
            this.pnlBase.Controls.Add(this.lblMotivo);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.lblNumDocumento);
            this.pnlBase.Controls.Add(this.lblNomDocumento);
            this.pnlBase.Controls.Add(this.lblRazonSocial);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.lblFecEmision);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.Label12);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.lblRucComprador);
            this.pnlBase.Controls.Add(this.lblFechaRef);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.lblTotal);
            this.pnlBase.Controls.Add(this.lblValorVenta);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Controls.Add(this.lblDesTotal);
            this.pnlBase.Controls.Add(this.lblDesValor);
            this.pnlBase.Controls.Add(this.lblPrecio);
            this.pnlBase.Location = new System.Drawing.Point(4, 4);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(746, 609);
            this.pnlBase.TabIndex = 418;
            // 
            // frmPrevioNotaDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 617);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.Name = "frmPrevioNotaDebito";
            this.Text = "Vista Previa - Nota de Débito";
            this.Load += new System.EventHandler(this.frmPrevioNotaDebito_Load);
            this.SizeChanged += new System.EventHandler(this.frmPrevioNotaDebito_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNumDocumento;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFechaRef;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValorVenta;
        private System.Windows.Forms.Label lblDesTotal;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDesValor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMontoLetras;
        private System.Windows.Forms.Label lblMontoIngles;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRucComprador;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label lblFecEmision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNomDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.Label lblPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSinImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Panel pnlBase;
    }
}