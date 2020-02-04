namespace ClienteWinForm.Almacen
{
    partial class frmListadoOrdenDeCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsOrdenesCompras = new System.Windows.Forms.BindingSource(this.components);
            this.cmsPedido = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarPorCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rboBienes = new System.Windows.Forms.RadioButton();
            this.rboServ = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbUno = new System.Windows.Forms.RadioButton();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.btProveedor = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoOC = new System.Windows.Forms.DataGridView();
            this.idOrdenCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecRequeridaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipEstadoAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impIgvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioAprobacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecAprobacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenesCompras)).BeginInit();
            this.cmsPedido.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoOC)).BeginInit();
            this.SuspendLayout();
            // 
            // bsOrdenesCompras
            // 
            this.bsOrdenesCompras.DataSource = typeof(Entidades.Almacen.OrdenCompraE);
            // 
            // cmsPedido
            // 
            this.cmsPedido.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarPorCorreoToolStripMenuItem});
            this.cmsPedido.Name = "cmsPedido";
            this.cmsPedido.Size = new System.Drawing.Size(184, 34);
            // 
            // enviarPorCorreoToolStripMenuItem
            // 
            this.enviarPorCorreoToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.enviarPorCorreoToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.enviarPorCorreoToolStripMenuItem.Name = "enviarPorCorreoToolStripMenuItem";
            this.enviarPorCorreoToolStripMenuItem.Size = new System.Drawing.Size(183, 30);
            this.enviarPorCorreoToolStripMenuItem.Text = "Mandar Por Correo";
            this.enviarPorCorreoToolStripMenuItem.Click += new System.EventHandler(this.enviarPorCorreoToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rboBienes);
            this.panel2.Controls.Add(this.rboServ);
            this.panel2.Location = new System.Drawing.Point(795, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 62);
            this.panel2.TabIndex = 264;
            // 
            // rboBienes
            // 
            this.rboBienes.AutoSize = true;
            this.rboBienes.Checked = true;
            this.rboBienes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboBienes.Location = new System.Drawing.Point(14, 30);
            this.rboBienes.Name = "rboBienes";
            this.rboBienes.Size = new System.Drawing.Size(56, 17);
            this.rboBienes.TabIndex = 301;
            this.rboBienes.TabStop = true;
            this.rboBienes.Text = "Bienes";
            this.rboBienes.UseVisualStyleBackColor = true;
            // 
            // rboServ
            // 
            this.rboServ.AutoSize = true;
            this.rboServ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboServ.Location = new System.Drawing.Point(74, 30);
            this.rboServ.Name = "rboServ";
            this.rboServ.Size = new System.Drawing.Size(67, 17);
            this.rboServ.TabIndex = 300;
            this.rboServ.Text = "Servicios";
            this.rboServ.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLetras);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFinal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpInicio);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 62);
            this.panel1.TabIndex = 263;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "De";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(160, 28);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 260;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 261;
            this.label2.Text = "hasta";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(28, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 259;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.rbTodos);
            this.panel4.Controls.Add(this.rbUno);
            this.panel4.Controls.Add(this.txtRuc);
            this.panel4.Controls.Add(this.btProveedor);
            this.panel4.Controls.Add(this.txtRazonSocial);
            this.panel4.Location = new System.Drawing.Point(269, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(524, 62);
            this.panel4.TabIndex = 8;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(6, 29);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 299;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbUno
            // 
            this.rbUno.AutoSize = true;
            this.rbUno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUno.Location = new System.Drawing.Point(62, 29);
            this.rbUno.Name = "rbUno";
            this.rbUno.Size = new System.Drawing.Size(66, 17);
            this.rbUno.TabIndex = 298;
            this.rbUno.Text = "Solo uno";
            this.rbUno.UseVisualStyleBackColor = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(136, 27);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(74, 21);
            this.txtRuc.TabIndex = 294;
            this.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // btProveedor
            // 
            this.btProveedor.Enabled = false;
            this.btProveedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedor.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btProveedor.Location = new System.Drawing.Point(491, 28);
            this.btProveedor.Name = "btProveedor";
            this.btProveedor.Size = new System.Drawing.Size(25, 19);
            this.btProveedor.TabIndex = 295;
            this.btProveedor.UseVisualStyleBackColor = true;
            this.btProveedor.Click += new System.EventHandler(this.btProveedor_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(212, 27);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(276, 21);
            this.txtRazonSocial.TabIndex = 297;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoOC);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1076, 386);
            this.panel5.TabIndex = 7;
            // 
            // dgvListadoOC
            // 
            this.dgvListadoOC.AllowUserToAddRows = false;
            this.dgvListadoOC.AllowUserToDeleteRows = false;
            this.dgvListadoOC.AutoGenerateColumns = false;
            this.dgvListadoOC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListadoOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOrdenCompraDataGridViewTextBoxColumn,
            this.numOrdenCompra,
            this.desTipOrdenCompra,
            this.desTipCompra,
            this.fecEmision,
            this.fecRequeridaDataGridViewTextBoxColumn,
            this.RazonSocial,
            this.desTipEstado,
            this.desTipEstadoAtencion,
            this.dataGridViewTextBoxColumn1,
            this.desMoneda,
            this.impTotalDataGridViewTextBoxColumn,
            this.impVenta,
            this.impIgvDataGridViewTextBoxColumn,
            this.usuarioAprobacionDataGridViewTextBoxColumn,
            this.fecAprobacionDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idLocalDataGridViewTextBoxColumn});
            this.dgvListadoOC.ContextMenuStrip = this.cmsPedido;
            this.dgvListadoOC.DataSource = this.bsOrdenesCompras;
            this.dgvListadoOC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoOC.EnableHeadersVisualStyles = false;
            this.dgvListadoOC.Location = new System.Drawing.Point(0, 18);
            this.dgvListadoOC.Name = "dgvListadoOC";
            this.dgvListadoOC.ReadOnly = true;
            this.dgvListadoOC.Size = new System.Drawing.Size(1074, 366);
            this.dgvListadoOC.TabIndex = 250;
            this.dgvListadoOC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellDoubleClick);
            this.dgvListadoOC.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoOC_CellFormatting);
            this.dgvListadoOC.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListadoOC_ColumnHeaderMouseClick);
            // 
            // idOrdenCompraDataGridViewTextBoxColumn
            // 
            this.idOrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "idOrdenCompra";
            this.idOrdenCompraDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idOrdenCompraDataGridViewTextBoxColumn.Name = "idOrdenCompraDataGridViewTextBoxColumn";
            this.idOrdenCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numOrdenCompra
            // 
            this.numOrdenCompra.DataPropertyName = "numOrdenCompra";
            this.numOrdenCompra.HeaderText = "Nro. OC";
            this.numOrdenCompra.Name = "numOrdenCompra";
            this.numOrdenCompra.ReadOnly = true;
            // 
            // desTipOrdenCompra
            // 
            this.desTipOrdenCompra.DataPropertyName = "desTipOrdenCompra";
            this.desTipOrdenCompra.HeaderText = "Tipo";
            this.desTipOrdenCompra.Name = "desTipOrdenCompra";
            this.desTipOrdenCompra.ReadOnly = true;
            // 
            // desTipCompra
            // 
            this.desTipCompra.DataPropertyName = "desTipCompra";
            this.desTipCompra.HeaderText = "Tip.Compra";
            this.desTipCompra.Name = "desTipCompra";
            this.desTipCompra.ReadOnly = true;
            // 
            // fecEmision
            // 
            this.fecEmision.DataPropertyName = "fecEmision";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecEmision.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecEmision.HeaderText = "Fec.Emis.";
            this.fecEmision.Name = "fecEmision";
            this.fecEmision.ReadOnly = true;
            // 
            // fecRequeridaDataGridViewTextBoxColumn
            // 
            this.fecRequeridaDataGridViewTextBoxColumn.DataPropertyName = "fecRequerida";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecRequeridaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecRequeridaDataGridViewTextBoxColumn.HeaderText = "Fec.Requ.";
            this.fecRequeridaDataGridViewTextBoxColumn.Name = "fecRequeridaDataGridViewTextBoxColumn";
            this.fecRequeridaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            // 
            // desTipEstado
            // 
            this.desTipEstado.DataPropertyName = "desTipEstado";
            this.desTipEstado.HeaderText = "Estado";
            this.desTipEstado.Name = "desTipEstado";
            this.desTipEstado.ReadOnly = true;
            // 
            // desTipEstadoAtencion
            // 
            this.desTipEstadoAtencion.DataPropertyName = "desTipEstadoAtencion";
            this.desTipEstadoAtencion.HeaderText = "Est.Almacen";
            this.desTipEstadoAtencion.Name = "desTipEstadoAtencion";
            this.desTipEstadoAtencion.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desTipEstadoFacturar";
            this.dataGridViewTextBoxColumn1.HeaderText = "Est.Facturar";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle3;
            this.desMoneda.HeaderText = "M.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.ToolTipText = "Moneda";
            // 
            // impTotalDataGridViewTextBoxColumn
            // 
            this.impTotalDataGridViewTextBoxColumn.DataPropertyName = "impTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.impTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.impTotalDataGridViewTextBoxColumn.HeaderText = "Imp. Total";
            this.impTotalDataGridViewTextBoxColumn.Name = "impTotalDataGridViewTextBoxColumn";
            this.impTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impVenta
            // 
            this.impVenta.DataPropertyName = "impVenta";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.impVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.impVenta.HeaderText = "Imp. Venta";
            this.impVenta.Name = "impVenta";
            this.impVenta.ReadOnly = true;
            // 
            // impIgvDataGridViewTextBoxColumn
            // 
            this.impIgvDataGridViewTextBoxColumn.DataPropertyName = "impIgv";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.impIgvDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.impIgvDataGridViewTextBoxColumn.HeaderText = "Imp. IGV";
            this.impIgvDataGridViewTextBoxColumn.Name = "impIgvDataGridViewTextBoxColumn";
            this.impIgvDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioAprobacionDataGridViewTextBoxColumn
            // 
            this.usuarioAprobacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioAprobacion";
            this.usuarioAprobacionDataGridViewTextBoxColumn.HeaderText = "Usuario Apr.";
            this.usuarioAprobacionDataGridViewTextBoxColumn.Name = "usuarioAprobacionDataGridViewTextBoxColumn";
            this.usuarioAprobacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecAprobacionDataGridViewTextBoxColumn
            // 
            this.fecAprobacionDataGridViewTextBoxColumn.DataPropertyName = "fecAprobacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecAprobacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fecAprobacionDataGridViewTextBoxColumn.HeaderText = "Fec.Aprob.";
            this.fecAprobacionDataGridViewTextBoxColumn.Name = "fecAprobacionDataGridViewTextBoxColumn";
            this.fecAprobacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idLocalDataGridViewTextBoxColumn
            // 
            this.idLocalDataGridViewTextBoxColumn.DataPropertyName = "idLocal";
            this.idLocalDataGridViewTextBoxColumn.HeaderText = "idLocal";
            this.idLocalDataGridViewTextBoxColumn.Name = "idLocalDataGridViewTextBoxColumn";
            this.idLocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLocalDataGridViewTextBoxColumn.Visible = false;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(262, 18);
            this.lblLetras.TabIndex = 1580;
            this.lblLetras.Text = "Fechas";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(522, 18);
            this.label3.TabIndex = 1580;
            this.label3.Text = "Datos Principales";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 18);
            this.label4.TabIndex = 1580;
            this.label4.Text = "Tipo Orden";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1074, 18);
            this.lblRegistros.TabIndex = 1580;
            this.lblRegistros.Text = "Datos Principales";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 456);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListadoOrdenDeCompra";
            this.Text = "Listado de Ordenes de Compra";
            this.Load += new System.EventHandler(this.frmListadoOrdenDeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenesCompras)).EndInit();
            this.cmsPedido.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoOC;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbUno;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.Button btProveedor;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bsOrdenesCompras;
        private System.Windows.Forms.ContextMenuStrip cmsPedido;
        private System.Windows.Forms.ToolStripMenuItem enviarPorCorreoToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rboBienes;
        private System.Windows.Forms.RadioButton rboServ;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecRequeridaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipEstadoAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn impIgvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioAprobacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecAprobacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRegistros;
    }
}