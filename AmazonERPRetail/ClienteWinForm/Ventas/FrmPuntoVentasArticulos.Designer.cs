namespace ClienteWinForm.Ventas
{
    partial class FrmPuntoVentasArticulos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.BsArticulos = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtArticulo = new ControlesWinForm.SuperTextBox();
            this.TxtBarras = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DgvPrincipios = new System.Windows.Forms.DataGridView();
            this.BsPrincipio = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.codArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloLargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVentaD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsArticulos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrincipios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsPrincipio)).BeginInit();
            this.SuspendLayout();
            // 
            // BtGuardar
            // 
            this.BtGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGuardar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.BtGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtGuardar.Location = new System.Drawing.Point(1067, 4);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(91, 59);
            this.BtGuardar.TabIndex = 2084;
            this.BtGuardar.TabStop = false;
            this.BtGuardar.Text = "Agregar";
            this.BtGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtGuardar.UseVisualStyleBackColor = true;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DgvDetalle);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 248);
            this.panel2.TabIndex = 2080;
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoGenerateColumns = false;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codArticuloDataGridViewTextBoxColumn,
            this.nomArticulo,
            this.nomArticuloLargo,
            this.stockDataGridViewTextBoxColumn,
            this.PrecioVenta,
            this.StockDetalle,
            this.PrecioVentaD,
            this.desMarca});
            this.DgvDetalle.DataSource = this.BsArticulos;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.EnableHeadersVisualStyles = false;
            this.DgvDetalle.Location = new System.Drawing.Point(0, 23);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.Size = new System.Drawing.Size(1151, 223);
            this.DgvDetalle.TabIndex = 100;
            this.DgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellContentClick);
            this.DgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellDoubleClick);
            this.DgvDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDetalle_KeyDown);
            // 
            // BsArticulos
            // 
            this.BsArticulos.DataSource = typeof(Entidades.Maestros.ArticuloServE);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1151, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "ARTICULOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TxtArticulo);
            this.panel1.Controls.Add(this.TxtBarras);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 59);
            this.panel1.TabIndex = 2078;
            // 
            // TxtArticulo
            // 
            this.TxtArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.TxtArticulo.Location = new System.Drawing.Point(202, 29);
            this.TxtArticulo.Name = "TxtArticulo";
            this.TxtArticulo.Size = new System.Drawing.Size(832, 21);
            this.TxtArticulo.TabIndex = 1;
            this.TxtArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtArticulo.TextoVacio = "DESCRIPCION DEL ARTICULO";
            this.TxtArticulo.TextChanged += new System.EventHandler(this.TxtArticulo_TextChanged);
            this.TxtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtArticulo_KeyDown);
            // 
            // TxtBarras
            // 
            this.TxtBarras.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtBarras.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtBarras.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.TxtBarras.Location = new System.Drawing.Point(21, 29);
            this.TxtBarras.Name = "TxtBarras";
            this.TxtBarras.Size = new System.Drawing.Size(178, 21);
            this.TxtBarras.TabIndex = 2;
            this.TxtBarras.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtBarras.TextoVacio = "COD. BARRAS";
            this.TxtBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBarras_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1054, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSQUEDA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtBuscar
            // 
            this.BtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtBuscar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.BtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtBuscar.Location = new System.Drawing.Point(1163, 27);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(18, 29);
            this.BtBuscar.TabIndex = 2085;
            this.BtBuscar.TabStop = false;
            this.BtBuscar.Text = "Agregar";
            this.BtBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtBuscar.UseVisualStyleBackColor = true;
            this.BtBuscar.Visible = false;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.DgvPrincipios);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(5, 317);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1153, 248);
            this.panel3.TabIndex = 2081;
            // 
            // DgvPrincipios
            // 
            this.DgvPrincipios.AllowUserToAddRows = false;
            this.DgvPrincipios.AllowUserToDeleteRows = false;
            this.DgvPrincipios.AutoGenerateColumns = false;
            this.DgvPrincipios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPrincipios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewLinkColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.DgvPrincipios.DataSource = this.BsPrincipio;
            this.DgvPrincipios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPrincipios.EnableHeadersVisualStyles = false;
            this.DgvPrincipios.Location = new System.Drawing.Point(0, 23);
            this.DgvPrincipios.Name = "DgvPrincipios";
            this.DgvPrincipios.ReadOnly = true;
            this.DgvPrincipios.Size = new System.Drawing.Size(1151, 223);
            this.DgvPrincipios.TabIndex = 100;
            this.DgvPrincipios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPrincipios_CellDoubleClick);
            this.DgvPrincipios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvPrincipios_KeyDown);
            // 
            // BsPrincipio
            // 
            this.BsPrincipio.DataSource = typeof(Entidades.Maestros.ArticuloServE);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1151, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "ARTICULOS POR PRINCIPIO ACTIVO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // codArticuloDataGridViewTextBoxColumn
            // 
            this.codArticuloDataGridViewTextBoxColumn.DataPropertyName = "codArticulo";
            this.codArticuloDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.codArticuloDataGridViewTextBoxColumn.Name = "codArticuloDataGridViewTextBoxColumn";
            this.codArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.codArticuloDataGridViewTextBoxColumn.Width = 90;
            // 
            // nomArticulo
            // 
            this.nomArticulo.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nomArticulo.DefaultCellStyle = dataGridViewCellStyle1;
            this.nomArticulo.HeaderText = "Descripción";
            this.nomArticulo.Name = "nomArticulo";
            this.nomArticulo.ReadOnly = true;
            this.nomArticulo.Width = 400;
            // 
            // nomArticuloLargo
            // 
            this.nomArticuloLargo.DataPropertyName = "nomArticuloLargo";
            this.nomArticuloLargo.HeaderText = "Principio Activo";
            this.nomArticuloLargo.Name = "nomArticuloLargo";
            this.nomArticuloLargo.ReadOnly = true;
            this.nomArticuloLargo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nomArticuloLargo.Width = 200;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Format = "N2";
            this.stockDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock U.A.";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.Width = 60;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "PrecioVenta";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(254)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle3.Format = "N2";
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioVenta.HeaderText = "Precio U.A.";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Width = 70;
            // 
            // StockDetalle
            // 
            this.StockDetalle.DataPropertyName = "StockDetalle";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle4.Format = "N2";
            this.StockDetalle.DefaultCellStyle = dataGridViewCellStyle4;
            this.StockDetalle.HeaderText = "Stock U.D.";
            this.StockDetalle.Name = "StockDetalle";
            this.StockDetalle.ReadOnly = true;
            this.StockDetalle.Width = 60;
            // 
            // PrecioVentaD
            // 
            this.PrecioVentaD.DataPropertyName = "PrecioVentaD";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(254)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle5.Format = "N2";
            this.PrecioVentaD.DefaultCellStyle = dataGridViewCellStyle5;
            this.PrecioVentaD.HeaderText = "Precio U.D.";
            this.PrecioVentaD.Name = "PrecioVentaD";
            this.PrecioVentaD.ReadOnly = true;
            this.PrecioVentaD.Width = 60;
            // 
            // desMarca
            // 
            this.desMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.desMarca.DataPropertyName = "desMarca";
            this.desMarca.HeaderText = "Laboratorio";
            this.desMarca.Name = "desMarca";
            this.desMarca.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codArticulo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cód.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nomArticulo";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "nomArticuloLargo";
            this.dataGridViewLinkColumn1.HeaderText = "Principio Activo";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Stock";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle7.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Stock U.A.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PrecioVenta";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(254)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle8.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio U.A.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StockDetalle";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle9.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn5.HeaderText = "Stock U.D.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PrecioVentaD";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(254)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle10.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn6.HeaderText = "Precio U.D.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "desMarca";
            this.dataGridViewTextBoxColumn7.HeaderText = "Laboratorio";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // FrmPuntoVentasArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1162, 569);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.BtBuscar);
            this.Controls.Add(this.BtGuardar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPuntoVentasArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Articulos";
            this.Load += new System.EventHandler(this.FrmPuntoVentasArticulos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPuntoVentasArticulos_KeyDown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsArticulos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrincipios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsPrincipio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtGuardar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox TxtArticulo;
        private ControlesWinForm.SuperTextBox TxtBarras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource BsArticulos;
        private System.Windows.Forms.Button BtBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DgvPrincipios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource BsPrincipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloLargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVentaD;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}