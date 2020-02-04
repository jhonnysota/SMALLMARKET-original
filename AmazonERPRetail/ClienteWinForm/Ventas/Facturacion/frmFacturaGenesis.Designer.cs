namespace ClienteWinForm.Ventas.Facturacion
{
    partial class frmFacturaGenesis
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
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblFlete = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblValorVenta = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.lblMontoLetras = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDesValor = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDesTotal = new System.Windows.Forms.Label();
            this.lblFecEmision = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRucCliente = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGuia = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSenior = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblRuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGlosa = new System.Windows.Forms.Label();
            this.lblMontoIngles = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSinImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoDetE);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblSubTotal);
            this.panel4.Controls.Add(this.lblFlete);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.lblValorVenta);
            this.panel4.Controls.Add(this.lblIgv);
            this.panel4.Controls.Add(this.lblMontoLetras);
            this.panel4.Location = new System.Drawing.Point(6, 618);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(722, 77);
            this.panel4.TabIndex = 384;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(319, 9);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(29, 13);
            this.lblSubTotal.TabIndex = 376;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFlete
            // 
            this.lblFlete.AutoSize = true;
            this.lblFlete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlete.Location = new System.Drawing.Point(186, 9);
            this.lblFlete.Name = "lblFlete";
            this.lblFlete.Size = new System.Drawing.Size(29, 13);
            this.lblFlete.TabIndex = 375;
            this.lblFlete.Text = "0.00";
            this.lblFlete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(634, 9);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(29, 13);
            this.lblTotal.TabIndex = 377;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValorVenta
            // 
            this.lblValorVenta.AutoSize = true;
            this.lblValorVenta.BackColor = System.Drawing.Color.White;
            this.lblValorVenta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVenta.Location = new System.Drawing.Point(32, 9);
            this.lblValorVenta.Name = "lblValorVenta";
            this.lblValorVenta.Size = new System.Drawing.Size(29, 13);
            this.lblValorVenta.TabIndex = 375;
            this.lblValorVenta.Text = "0.00";
            this.lblValorVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgv
            // 
            this.lblIgv.AutoSize = true;
            this.lblIgv.BackColor = System.Drawing.Color.White;
            this.lblIgv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.Location = new System.Drawing.Point(486, 9);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(29, 13);
            this.lblIgv.TabIndex = 376;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMontoLetras
            // 
            this.lblMontoLetras.AutoSize = true;
            this.lblMontoLetras.BackColor = System.Drawing.Color.White;
            this.lblMontoLetras.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoLetras.Location = new System.Drawing.Point(12, 59);
            this.lblMontoLetras.Name = "lblMontoLetras";
            this.lblMontoLetras.Size = new System.Drawing.Size(32, 14);
            this.lblMontoLetras.TabIndex = 358;
            this.lblMontoLetras.Text = "SON:";
            this.lblMontoLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblDesValor);
            this.panel2.Controls.Add(this.lblPrecio);
            this.panel2.Controls.Add(this.lblDesTotal);
            this.panel2.Location = new System.Drawing.Point(6, 597);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 22);
            this.panel2.TabIndex = 383;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(316, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 376;
            this.label10.Text = "SUBTOTAL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(185, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 375;
            this.label9.Text = "FLETE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesValor
            // 
            this.lblDesValor.AutoSize = true;
            this.lblDesValor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesValor.Location = new System.Drawing.Point(24, 5);
            this.lblDesValor.Name = "lblDesValor";
            this.lblDesValor.Size = new System.Drawing.Size(91, 13);
            this.lblDesValor.TabIndex = 372;
            this.lblDesValor.Text = "VALOR DE VENTA";
            this.lblDesValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(483, 5);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(24, 13);
            this.lblPrecio.TabIndex = 373;
            this.lblPrecio.Text = "IGV";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesTotal
            // 
            this.lblDesTotal.AutoSize = true;
            this.lblDesTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesTotal.Location = new System.Drawing.Point(607, 5);
            this.lblDesTotal.Name = "lblDesTotal";
            this.lblDesTotal.Size = new System.Drawing.Size(96, 13);
            this.lblDesTotal.TabIndex = 374;
            this.lblDesTotal.Text = "PRECIO DE VENTA";
            this.lblDesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFecEmision
            // 
            this.lblFecEmision.AutoSize = true;
            this.lblFecEmision.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecEmision.Location = new System.Drawing.Point(528, 185);
            this.lblFecEmision.Name = "lblFecEmision";
            this.lblFecEmision.Size = new System.Drawing.Size(0, 13);
            this.lblFecEmision.TabIndex = 382;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(412, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 12);
            this.label4.TabIndex = 381;
            this.label4.Text = "Condiciones de Pago:";
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicion.Location = new System.Drawing.Point(528, 211);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(0, 14);
            this.lblCondicion.TabIndex = 380;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(412, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 12);
            this.label8.TabIndex = 379;
            this.label8.Text = "Fecha de Emisión:";
            // 
            // lblRucCliente
            // 
            this.lblRucCliente.AutoSize = true;
            this.lblRucCliente.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRucCliente.Location = new System.Drawing.Point(71, 186);
            this.lblRucCliente.Name = "lblRucCliente";
            this.lblRucCliente.Size = new System.Drawing.Size(0, 13);
            this.lblRucCliente.TabIndex = 378;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 370;
            this.label6.Text = "Guía de Remisión:";
            // 
            // lblGuia
            // 
            this.lblGuia.AutoSize = true;
            this.lblGuia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuia.Location = new System.Drawing.Point(117, 211);
            this.lblGuia.Name = "lblGuia";
            this.lblGuia.Size = new System.Drawing.Size(0, 14);
            this.lblGuia.TabIndex = 369;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(12, 186);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(38, 12);
            this.Label12.TabIndex = 368;
            this.Label12.Text = "R.U.C.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 365;
            this.label5.Text = "Dirección:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(71, 161);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(0, 13);
            this.lblDireccion.TabIndex = 364;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 363;
            this.label3.Text = "Señor(es):";
            // 
            // lblSenior
            // 
            this.lblSenior.AutoSize = true;
            this.lblSenior.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenior.Location = new System.Drawing.Point(71, 136);
            this.lblSenior.Name = "lblSenior";
            this.lblSenior.Size = new System.Drawing.Size(0, 13);
            this.lblSenior.TabIndex = 362;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(464, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 114);
            this.panel1.TabIndex = 359;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Red;
            this.lblNumero.Location = new System.Drawing.Point(122, 80);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(33, 22);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "N°";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(24, 80);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(72, 22);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "0000 - ";
            // 
            // lblRuc
            // 
            this.lblRuc.BackColor = System.Drawing.Color.White;
            this.lblRuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRuc.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.Location = new System.Drawing.Point(0, 0);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(261, 23);
            this.lblRuc.TabIndex = 1;
            this.lblRuc.Text = "R.U.C.";
            this.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACTURA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 361;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblGlosa);
            this.panel3.Controls.Add(this.lblMontoIngles);
            this.panel3.Controls.Add(this.dgvDetalle);
            this.panel3.Location = new System.Drawing.Point(6, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 362);
            this.panel3.TabIndex = 371;
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlosa.Location = new System.Drawing.Point(290, 320);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(29, 12);
            this.lblGlosa.TabIndex = 11;
            this.lblGlosa.Text = "Glosa";
            this.lblGlosa.Visible = false;
            this.lblGlosa.SizeChanged += new System.EventHandler(this.lblGlosa_SizeChanged);
            // 
            // lblMontoIngles
            // 
            this.lblMontoIngles.AutoSize = true;
            this.lblMontoIngles.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoIngles.Location = new System.Drawing.Point(72, 348);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalle.Size = new System.Drawing.Size(720, 360);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalle_CellPainting);
            // 
            // pnlBase
            // 
            this.pnlBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Controls.Add(this.panel1);
            this.pnlBase.Controls.Add(this.panel4);
            this.pnlBase.Controls.Add(this.lblSenior);
            this.pnlBase.Controls.Add(this.panel2);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.lblFecEmision);
            this.pnlBase.Controls.Add(this.lblDireccion);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.lblCondicion);
            this.pnlBase.Controls.Add(this.Label12);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.lblGuia);
            this.pnlBase.Controls.Add(this.lblRucCliente);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Location = new System.Drawing.Point(6, 5);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(737, 702);
            this.pnlBase.TabIndex = 387;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nomArticuloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PrecioSinImpuesto
            // 
            this.PrecioSinImpuesto.DataPropertyName = "PrecioCad";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.PrecioSinImpuesto.DefaultCellStyle = dataGridViewCellStyle4;
            this.PrecioSinImpuesto.HeaderText = "VALOR UNIT.";
            this.PrecioSinImpuesto.Name = "PrecioSinImpuesto";
            this.PrecioSinImpuesto.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "SubTotalCad";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "VALOR VENTA";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // frmFacturaGenesis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 712);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.Name = "frmFacturaGenesis";
            this.Text = "Vista Previa";
            this.Load += new System.EventHandler(this.frmFacturaGenesis_Load);
            this.Resize += new System.EventHandler(this.frmFacturaGenesis_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGuia;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSenior;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblRuc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblValorVenta;
        private System.Windows.Forms.Label lblDesTotal;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDesValor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMontoIngles;
        private System.Windows.Forms.Label lblGlosa;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblMontoLetras;
        private System.Windows.Forms.Label lblRucCliente;
        private System.Windows.Forms.Label lblFecEmision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblFlete;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSinImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}