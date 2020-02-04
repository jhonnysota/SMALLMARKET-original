namespace ClienteWinForm.Ventas.Facturacion
{
    partial class frmFacturaNevados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBase = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblPedOc = new System.Windows.Forms.Label();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFecEmision = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGlosa = new System.Windows.Forms.Label();
            this.lblMontoIngles = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblDesTotal = new System.Windows.Forms.Label();
            this.lblPorIgv = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDesValor = new System.Windows.Forms.Label();
            this.lblMontoLetras = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.lblRucCliente = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSenior = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSinImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porDcto1Cad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoDetE);
            // 
            // pnlBase
            // 
            this.pnlBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBase.Controls.Add(this.panel2);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.panel8);
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.lblTotal);
            this.pnlBase.Controls.Add(this.lblSubTotal);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Controls.Add(this.lblDesTotal);
            this.pnlBase.Controls.Add(this.lblPorIgv);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(this.lblDesValor);
            this.pnlBase.Controls.Add(this.panel7);
            this.pnlBase.Controls.Add(this.lblIgv);
            this.pnlBase.Controls.Add(this.label14);
            this.pnlBase.Controls.Add(this.label13);
            this.pnlBase.Controls.Add(this.lblImporte);
            this.pnlBase.Controls.Add(this.lblDescuento);
            this.pnlBase.Location = new System.Drawing.Point(6, 6);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(811, 687);
            this.pnlBase.TabIndex = 426;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 24);
            this.label2.TabIndex = 428;
            this.label2.Text = "Av. Santa Ana Lote 60 A - 2 Urb. Chacracerro Lima 07 Comas - Lima\r\nTelf.: 713-107" +
    "3 Entel: (94) 621 * 1936";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblPedOc);
            this.panel8.Controls.Add(this.lblIdCliente);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.lblFecEmision);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.label17);
            this.panel8.Controls.Add(this.lblVendedor);
            this.panel8.Controls.Add(this.lblVencimiento);
            this.panel8.Location = new System.Drawing.Point(453, 153);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(351, 70);
            this.panel8.TabIndex = 416;
            // 
            // lblPedOc
            // 
            this.lblPedOc.AutoSize = true;
            this.lblPedOc.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedOc.Location = new System.Drawing.Point(100, 51);
            this.lblPedOc.Name = "lblPedOc";
            this.lblPedOc.Size = new System.Drawing.Size(0, 10);
            this.lblPedOc.TabIndex = 421;
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCliente.Location = new System.Drawing.Point(100, 32);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(0, 10);
            this.lblIdCliente.TabIndex = 420;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 417;
            this.label4.Text = "FECHA DE EMISION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 418;
            this.label6.Text = "CODIGO CLIENTE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 12);
            this.label7.TabIndex = 419;
            this.label7.Text = "PEDIDO O/C";
            // 
            // lblFecEmision
            // 
            this.lblFecEmision.AutoSize = true;
            this.lblFecEmision.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecEmision.Location = new System.Drawing.Point(105, 15);
            this.lblFecEmision.Name = "lblFecEmision";
            this.lblFecEmision.Size = new System.Drawing.Size(23, 10);
            this.lblFecEmision.TabIndex = 401;
            this.lblFecEmision.Text = "Lima,";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(154, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 16);
            this.label16.TabIndex = 409;
            this.label16.Text = "VENDEDOR";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(265, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 16);
            this.label17.TabIndex = 410;
            this.label17.Text = "ZONA";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendedor
            // 
            this.lblVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVendedor.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(154, 50);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(112, 16);
            this.lblVendedor.TabIndex = 414;
            this.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVencimiento.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimiento.Location = new System.Drawing.Point(265, 50);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(81, 16);
            this.lblVencimiento.TabIndex = 415;
            this.lblVencimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(60, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 409;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(641, 576);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(163, 20);
            this.lblTotal.TabIndex = 424;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.White;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(323, 576);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(160, 20);
            this.lblSubTotal.TabIndex = 422;
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblGlosa);
            this.panel3.Controls.Add(this.lblMontoIngles);
            this.panel3.Controls.Add(this.dgvDetalle);
            this.panel3.Location = new System.Drawing.Point(5, 228);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 330);
            this.panel3.TabIndex = 410;
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlosa.Location = new System.Drawing.Point(285, 309);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(29, 12);
            this.lblGlosa.TabIndex = 11;
            this.lblGlosa.Text = "Glosa";
            this.lblGlosa.Visible = false;
            // 
            // lblMontoIngles
            // 
            this.lblMontoIngles.AutoSize = true;
            this.lblMontoIngles.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoIngles.Location = new System.Drawing.Point(67, 352);
            this.lblMontoIngles.Name = "lblMontoIngles";
            this.lblMontoIngles.Size = new System.Drawing.Size(0, 13);
            this.lblMontoIngles.TabIndex = 12;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.codArticulo,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.PrecioSinImpuesto,
            this.Total,
            this.porDcto1Cad,
            this.TotalCad});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Enabled = false;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalle.Size = new System.Drawing.Size(797, 328);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalle_CellPainting);
            // 
            // lblDesTotal
            // 
            this.lblDesTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.lblDesTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesTotal.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesTotal.ForeColor = System.Drawing.Color.Black;
            this.lblDesTotal.Location = new System.Drawing.Point(641, 557);
            this.lblDesTotal.Name = "lblDesTotal";
            this.lblDesTotal.Size = new System.Drawing.Size(163, 20);
            this.lblDesTotal.TabIndex = 421;
            this.lblDesTotal.Text = "PRECIO VENTA";
            this.lblDesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPorIgv
            // 
            this.lblPorIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.lblPorIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPorIgv.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorIgv.ForeColor = System.Drawing.Color.Black;
            this.lblPorIgv.Location = new System.Drawing.Point(482, 557);
            this.lblPorIgv.Name = "lblPorIgv";
            this.lblPorIgv.Size = new System.Drawing.Size(161, 20);
            this.lblPorIgv.TabIndex = 420;
            this.lblPorIgv.Text = "IGV        %";
            this.lblPorIgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(492, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 140);
            this.panel1.TabIndex = 408;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Red;
            this.lblNumero.Location = new System.Drawing.Point(149, 104);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(32, 24);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "N°";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(54, 104);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(73, 24);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "0000 - ";
            // 
            // lblRuc
            // 
            this.lblRuc.BackColor = System.Drawing.Color.White;
            this.lblRuc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.Location = new System.Drawing.Point(0, 11);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(310, 23);
            this.lblRuc.TabIndex = 1;
            this.lblRuc.Text = "R.U.C. N° ";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACTURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesValor
            // 
            this.lblDesValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.lblDesValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesValor.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesValor.ForeColor = System.Drawing.Color.Black;
            this.lblDesValor.Location = new System.Drawing.Point(323, 557);
            this.lblDesValor.Name = "lblDesValor";
            this.lblDesValor.Size = new System.Drawing.Size(160, 20);
            this.lblDesValor.TabIndex = 419;
            this.lblDesValor.Text = "VALOR DE VENTA";
            this.lblDesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMontoLetras
            // 
            this.lblMontoLetras.BackColor = System.Drawing.Color.White;
            this.lblMontoLetras.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoLetras.Location = new System.Drawing.Point(8, 4);
            this.lblMontoLetras.Name = "lblMontoLetras";
            this.lblMontoLetras.Size = new System.Drawing.Size(706, 23);
            this.lblMontoLetras.TabIndex = 418;
            this.lblMontoLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.Label12);
            this.panel7.Controls.Add(this.lblRucCliente);
            this.panel7.Controls.Add(this.lblDireccion);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.lblSenior);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.lblTelefono);
            this.panel7.Location = new System.Drawing.Point(5, 153);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(433, 70);
            this.panel7.TabIndex = 415;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 390;
            this.label3.Text = "SEÑOR(ES)";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(300, 51);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(49, 12);
            this.Label12.TabIndex = 393;
            this.Label12.Text = "R.U.C. N°";
            // 
            // lblRucCliente
            // 
            this.lblRucCliente.AutoSize = true;
            this.lblRucCliente.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucCliente.Location = new System.Drawing.Point(356, 51);
            this.lblRucCliente.Name = "lblRucCliente";
            this.lblRucCliente.Size = new System.Drawing.Size(0, 10);
            this.lblRucCliente.TabIndex = 397;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(69, 33);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(0, 10);
            this.lblDireccion.TabIndex = 391;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 392;
            this.label5.Text = "DIRECCION";
            // 
            // lblSenior
            // 
            this.lblSenior.AutoSize = true;
            this.lblSenior.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenior.Location = new System.Drawing.Point(65, 15);
            this.lblSenior.Name = "lblSenior";
            this.lblSenior.Size = new System.Drawing.Size(0, 10);
            this.lblSenior.TabIndex = 389;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 12);
            this.label8.TabIndex = 416;
            this.label8.Text = "TELEFONO";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(69, 52);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(0, 10);
            this.lblTelefono.TabIndex = 417;
            // 
            // lblIgv
            // 
            this.lblIgv.BackColor = System.Drawing.Color.White;
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.Location = new System.Drawing.Point(482, 576);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(161, 20);
            this.lblIgv.TabIndex = 423;
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(164, 557);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(160, 20);
            this.label14.TabIndex = 407;
            this.label14.Text = "DESCUENTO";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(198)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(5, 557);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 20);
            this.label13.TabIndex = 406;
            this.label13.Text = "IMPORTE TOTAL";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImporte
            // 
            this.lblImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImporte.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(5, 576);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(160, 20);
            this.lblImporte.TabIndex = 411;
            this.lblImporte.Text = "0.00";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescuento
            // 
            this.lblDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescuento.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(164, 576);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(160, 20);
            this.lblDescuento.TabIndex = 412;
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "Item";
            this.Item.HeaderText = "ITEM";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // codArticulo
            // 
            this.codArticulo.DataPropertyName = "codArticulo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codArticulo.DefaultCellStyle = dataGridViewCellStyle10;
            this.codArticulo.HeaderText = "CODIGO";
            this.codArticulo.Name = "codArticulo";
            this.codArticulo.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nomArticuloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "DETALLE";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomArticuloDataGridViewTextBoxColumn.Width = 105;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "CAN.UNID.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PrecioSinImpuesto
            // 
            this.PrecioSinImpuesto.DataPropertyName = "PrecioCad";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.PrecioSinImpuesto.DefaultCellStyle = dataGridViewCellStyle13;
            this.PrecioSinImpuesto.HeaderText = "P.UNIT.";
            this.PrecioSinImpuesto.Name = "PrecioSinImpuesto";
            this.PrecioSinImpuesto.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "SubTotalCad";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle14;
            this.Total.HeaderText = "IMPORTE";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // porDcto1Cad
            // 
            this.porDcto1Cad.DataPropertyName = "porDcto1Cad";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.porDcto1Cad.DefaultCellStyle = dataGridViewCellStyle15;
            this.porDcto1Cad.HeaderText = "% DSCTO.";
            this.porDcto1Cad.Name = "porDcto1Cad";
            this.porDcto1Cad.ReadOnly = true;
            // 
            // TotalCad
            // 
            this.TotalCad.DataPropertyName = "TotalCad";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            this.TotalCad.DefaultCellStyle = dataGridViewCellStyle16;
            this.TotalCad.HeaderText = "VALOR VENTA";
            this.TotalCad.Name = "TotalCad";
            this.TotalCad.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(5, 595);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 40);
            this.panel2.TabIndex = 429;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 12);
            this.label9.TabIndex = 391;
            this.label9.Text = "SON:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblMontoLetras);
            this.panel4.Location = new System.Drawing.Point(54, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(731, 32);
            this.panel4.TabIndex = 430;
            // 
            // frmFacturaNevados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 699);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.Name = "frmFacturaNevados";
            this.Text = "Vista Previa";
            this.Load += new System.EventHandler(this.frmFacturaNevados_Load);
            this.Resize += new System.EventHandler(this.frmFacturaNevados_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblDesValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMontoLetras;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblRucCliente;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFecEmision;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblGlosa;
        private System.Windows.Forms.Label lblMontoIngles;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblDesTotal;
        private System.Windows.Forms.Label lblSenior;
        private System.Windows.Forms.Label lblPorIgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPedOc;
        private System.Windows.Forms.Label lblIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSinImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn porDcto1Cad;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
    }
}