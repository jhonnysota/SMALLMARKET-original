namespace ClienteWinForm.Ventas
{
    partial class FrmPuntoVentasPagos
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
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMedioPagos = new System.Windows.Forms.Panel();
            this.PbTipoPago = new System.Windows.Forms.PictureBox();
            this.TxtDolares = new ControlesWinForm.SuperTextBox();
            this.TxtSoles = new ControlesWinForm.SuperTextBox();
            this.BtQuitar = new System.Windows.Forms.Button();
            this.CboMoneda = new System.Windows.Forms.ComboBox();
            this.BtAgregar = new System.Windows.Forms.Button();
            this.CboMedioPago = new System.Windows.Forms.ComboBox();
            this.LblTica = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMedioPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaRecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoRecibido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblVuelto = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblDesMoneda = new System.Windows.Forms.Label();
            this.BtAceptar = new System.Windows.Forms.Button();
            this.BtCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LblRedondeo = new System.Windows.Forms.Label();
            this.PnlMedioPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbTipoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medios de Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlMedioPagos
            // 
            this.PnlMedioPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlMedioPagos.Controls.Add(this.PbTipoPago);
            this.PnlMedioPagos.Controls.Add(this.TxtDolares);
            this.PnlMedioPagos.Controls.Add(this.TxtSoles);
            this.PnlMedioPagos.Controls.Add(this.BtQuitar);
            this.PnlMedioPagos.Controls.Add(this.CboMoneda);
            this.PnlMedioPagos.Controls.Add(this.BtAgregar);
            this.PnlMedioPagos.Controls.Add(this.CboMedioPago);
            this.PnlMedioPagos.Controls.Add(this.label1);
            this.PnlMedioPagos.Location = new System.Drawing.Point(5, 4);
            this.PnlMedioPagos.Name = "PnlMedioPagos";
            this.PnlMedioPagos.Size = new System.Drawing.Size(221, 188);
            this.PnlMedioPagos.TabIndex = 2085;
            // 
            // PbTipoPago
            // 
            this.PbTipoPago.Image = global::ClienteWinForm.Properties.Resources.Tarjetas_128x128;
            this.PbTipoPago.Location = new System.Drawing.Point(17, 115);
            this.PbTipoPago.Name = "PbTipoPago";
            this.PbTipoPago.Size = new System.Drawing.Size(88, 63);
            this.PbTipoPago.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbTipoPago.TabIndex = 2100;
            this.PbTipoPago.TabStop = false;
            // 
            // TxtDolares
            // 
            this.TxtDolares.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtDolares.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtDolares.Enabled = false;
            this.TxtDolares.Font = new System.Drawing.Font("Tahoma", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDolares.Location = new System.Drawing.Point(111, 84);
            this.TxtDolares.Name = "TxtDolares";
            this.TxtDolares.Size = new System.Drawing.Size(96, 25);
            this.TxtDolares.TabIndex = 1;
            this.TxtDolares.Text = "0.00";
            this.TxtDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtDolares.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.TxtDolares.TextoVacio = "";
            this.TxtDolares.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDolares_KeyDown);
            this.TxtDolares.Leave += new System.EventHandler(this.TxtDolares_Leave);
            // 
            // TxtSoles
            // 
            this.TxtSoles.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtSoles.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtSoles.Enabled = false;
            this.TxtSoles.Font = new System.Drawing.Font("Tahoma", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSoles.Location = new System.Drawing.Point(11, 84);
            this.TxtSoles.Name = "TxtSoles";
            this.TxtSoles.Size = new System.Drawing.Size(96, 25);
            this.TxtSoles.TabIndex = 0;
            this.TxtSoles.Text = "0.00";
            this.TxtSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtSoles.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.TxtSoles.TextoVacio = "";
            this.TxtSoles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSoles_KeyDown);
            this.TxtSoles.Leave += new System.EventHandler(this.TxtSoles_Leave);
            // 
            // BtQuitar
            // 
            this.BtQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtQuitar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtQuitar.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.BtQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtQuitar.Location = new System.Drawing.Point(116, 149);
            this.BtQuitar.Name = "BtQuitar";
            this.BtQuitar.Size = new System.Drawing.Size(91, 29);
            this.BtQuitar.TabIndex = 3;
            this.BtQuitar.TabStop = false;
            this.BtQuitar.Text = "Quitar";
            this.BtQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtQuitar.UseVisualStyleBackColor = true;
            this.BtQuitar.Click += new System.EventHandler(this.BtQuitar_Click);
            // 
            // CboMoneda
            // 
            this.CboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboMoneda.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboMoneda.FormattingEnabled = true;
            this.CboMoneda.Location = new System.Drawing.Point(10, 55);
            this.CboMoneda.Name = "CboMoneda";
            this.CboMoneda.Size = new System.Drawing.Size(197, 25);
            this.CboMoneda.TabIndex = 201;
            this.CboMoneda.TabStop = false;
            this.CboMoneda.SelectionChangeCommitted += new System.EventHandler(this.CboMoneda_SelectionChangeCommitted);
            this.CboMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboMoneda_KeyPress);
            // 
            // BtAgregar
            // 
            this.BtAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAgregar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAgregar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.BtAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtAgregar.Location = new System.Drawing.Point(116, 115);
            this.BtAgregar.Name = "BtAgregar";
            this.BtAgregar.Size = new System.Drawing.Size(91, 29);
            this.BtAgregar.TabIndex = 2;
            this.BtAgregar.TabStop = false;
            this.BtAgregar.Text = "Agregar";
            this.BtAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtAgregar.UseVisualStyleBackColor = true;
            this.BtAgregar.Click += new System.EventHandler(this.BtAgregar_Click);
            // 
            // CboMedioPago
            // 
            this.CboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboMedioPago.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboMedioPago.FormattingEnabled = true;
            this.CboMedioPago.Location = new System.Drawing.Point(10, 27);
            this.CboMedioPago.Name = "CboMedioPago";
            this.CboMedioPago.Size = new System.Drawing.Size(197, 25);
            this.CboMedioPago.TabIndex = 200;
            this.CboMedioPago.TabStop = false;
            this.CboMedioPago.SelectionChangeCommitted += new System.EventHandler(this.CboMedioPago_SelectionChangeCommitted);
            this.CboMedioPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboMedioPago_KeyPress);
            // 
            // LblTica
            // 
            this.LblTica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTica.AutoSize = true;
            this.LblTica.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTica.Location = new System.Drawing.Point(221, 26);
            this.LblTica.Name = "LblTica";
            this.LblTica.Size = new System.Drawing.Size(53, 18);
            this.LblTica.TabIndex = 2094;
            this.LblTica.Text = "0.000";
            this.LblTica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 2095;
            this.label3.Text = "T.C.";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(562, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "DETALLE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoGenerateColumns = false;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.desMedioPago,
            this.desMonedaRecDataGridViewTextBoxColumn,
            this.MontoRecibido});
            this.DgvDetalle.DataSource = this.BsDetalle;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.EnableHeadersVisualStyles = false;
            this.DgvDetalle.Location = new System.Drawing.Point(0, 21);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.Size = new System.Drawing.Size(562, 165);
            this.DgvDetalle.TabIndex = 100;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 50;
            // 
            // desMedioPago
            // 
            this.desMedioPago.DataPropertyName = "desMedioPago";
            this.desMedioPago.HeaderText = "Medio Pago";
            this.desMedioPago.Name = "desMedioPago";
            this.desMedioPago.ReadOnly = true;
            this.desMedioPago.Width = 320;
            // 
            // desMonedaRecDataGridViewTextBoxColumn
            // 
            this.desMonedaRecDataGridViewTextBoxColumn.DataPropertyName = "desMonedaRec";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMonedaRecDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.desMonedaRecDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.desMonedaRecDataGridViewTextBoxColumn.Name = "desMonedaRecDataGridViewTextBoxColumn";
            this.desMonedaRecDataGridViewTextBoxColumn.ReadOnly = true;
            this.desMonedaRecDataGridViewTextBoxColumn.Width = 60;
            // 
            // MontoRecibido
            // 
            this.MontoRecibido.DataPropertyName = "MontoRecibido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.MontoRecibido.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoRecibido.HeaderText = "Monto";
            this.MontoRecibido.Name = "MontoRecibido";
            this.MontoRecibido.ReadOnly = true;
            this.MontoRecibido.Width = 80;
            // 
            // BsDetalle
            // 
            this.BsDetalle.DataSource = typeof(Entidades.Ventas.EmisionDocumentoCancelacionE);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DgvDetalle);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(229, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 188);
            this.panel2.TabIndex = 2086;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.CajaReg_128x128;
            this.pictureBox1.Location = new System.Drawing.Point(142, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2088;
            this.pictureBox1.TabStop = false;
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.LblTotal.Location = new System.Drawing.Point(231, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(43, 18);
            this.LblTotal.TabIndex = 2096;
            this.LblTotal.Text = "0.00";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 2097;
            this.label5.Text = "Total a Cobrar";
            // 
            // LblVuelto
            // 
            this.LblVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblVuelto.AutoSize = true;
            this.LblVuelto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVuelto.ForeColor = System.Drawing.Color.Green;
            this.LblVuelto.Location = new System.Drawing.Point(231, 52);
            this.LblVuelto.Name = "LblVuelto";
            this.LblVuelto.Size = new System.Drawing.Size(43, 18);
            this.LblVuelto.TabIndex = 2100;
            this.LblVuelto.Text = "0.00";
            this.LblVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 2101;
            this.label6.Text = "Vuelto";
            // 
            // LblDesMoneda
            // 
            this.LblDesMoneda.AutoSize = true;
            this.LblDesMoneda.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDesMoneda.ForeColor = System.Drawing.Color.MediumBlue;
            this.LblDesMoneda.Location = new System.Drawing.Point(129, 0);
            this.LblDesMoneda.Name = "LblDesMoneda";
            this.LblDesMoneda.Size = new System.Drawing.Size(13, 18);
            this.LblDesMoneda.TabIndex = 2102;
            this.LblDesMoneda.Text = ".";
            // 
            // BtAceptar
            // 
            this.BtAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAceptar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.BtAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtAceptar.Location = new System.Drawing.Point(543, 238);
            this.BtAceptar.Name = "BtAceptar";
            this.BtAceptar.Size = new System.Drawing.Size(109, 30);
            this.BtAceptar.TabIndex = 2109;
            this.BtAceptar.TabStop = false;
            this.BtAceptar.Text = "Facturar";
            this.BtAceptar.UseVisualStyleBackColor = true;
            this.BtAceptar.Click += new System.EventHandler(this.BtAceptar_Click);
            // 
            // BtCancelar
            // 
            this.BtCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.BtCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtCancelar.Location = new System.Drawing.Point(658, 238);
            this.BtCancelar.Name = "BtCancelar";
            this.BtCancelar.Size = new System.Drawing.Size(112, 30);
            this.BtCancelar.TabIndex = 2110;
            this.BtCancelar.TabStop = false;
            this.BtCancelar.Text = "Cancelar";
            this.BtCancelar.UseVisualStyleBackColor = true;
            this.BtCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.54795F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.32852F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.18412F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblDesMoneda, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblTotal, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblTica, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblVuelto, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(235, 198);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 78);
            this.tableLayoutPanel1.TabIndex = 2111;
            // 
            // LblRedondeo
            // 
            this.LblRedondeo.AutoSize = true;
            this.LblRedondeo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRedondeo.ForeColor = System.Drawing.Color.MediumBlue;
            this.LblRedondeo.Location = new System.Drawing.Point(538, 198);
            this.LblRedondeo.Name = "LblRedondeo";
            this.LblRedondeo.Size = new System.Drawing.Size(82, 18);
            this.LblRedondeo.TabIndex = 2112;
            this.LblRedondeo.Text = "Redondeo";
            // 
            // FrmPuntoVentasPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(797, 282);
            this.Controls.Add(this.LblRedondeo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BtCancelar);
            this.Controls.Add(this.BtAceptar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PnlMedioPagos);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmPuntoVentasPagos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.FrmPuntoVentasPagos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPuntoVentasPagos_KeyDown);
            this.PnlMedioPagos.ResumeLayout(false);
            this.PnlMedioPagos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbTipoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlMedioPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource BsDetalle;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox CboMoneda;
        public System.Windows.Forms.ComboBox CboMedioPago;
        private ControlesWinForm.SuperTextBox TxtDolares;
        private ControlesWinForm.SuperTextBox TxtSoles;
        private System.Windows.Forms.Label LblTica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtQuitar;
        private System.Windows.Forms.Button BtAgregar;
        private System.Windows.Forms.Label LblVuelto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMedioPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaRecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoRecibido;
        private System.Windows.Forms.Label LblDesMoneda;
        private System.Windows.Forms.PictureBox PbTipoPago;
        private System.Windows.Forms.Button BtAceptar;
        private System.Windows.Forms.Button BtCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LblRedondeo;
    }
}