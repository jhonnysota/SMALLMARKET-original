namespace ClienteWinForm.Almacen
{
    partial class frmListadoAprobarOrdenDeCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsOrdenesCompras = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbototal = new System.Windows.Forms.RadioButton();
            this.RAmbos = new System.Windows.Forms.RadioButton();
            this.RPorAprobar = new System.Windows.Forms.RadioButton();
            this.RAprobados = new System.Windows.Forms.RadioButton();
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
            this.numOrdenCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipOrdenCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipModalCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecRequerida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipEstadoAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.CMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenesCompras)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoOC)).BeginInit();
            this.SuspendLayout();
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activar});
            this.CMS.Name = "contextMenuStrip1";
            this.CMS.Size = new System.Drawing.Size(217, 26);
            // 
            // activar
            // 
            this.activar.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.activar.Name = "activar";
            this.activar.Size = new System.Drawing.Size(216, 22);
            this.activar.Text = "Aprobar Orden De Compra";
            this.activar.Click += new System.EventHandler(this.activarOrdenDeCompraToolStripMenuItem_Click);
            // 
            // bsOrdenesCompras
            // 
            this.bsOrdenesCompras.DataSource = typeof(Entidades.Almacen.OrdenCompraE);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.rbototal);
            this.panel3.Controls.Add(this.RAmbos);
            this.panel3.Controls.Add(this.RPorAprobar);
            this.panel3.Controls.Add(this.RAprobados);
            this.panel3.Location = new System.Drawing.Point(805, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(408, 62);
            this.panel3.TabIndex = 273;
            // 
            // rbototal
            // 
            this.rbototal.AutoSize = true;
            this.rbototal.Location = new System.Drawing.Point(218, 29);
            this.rbototal.Name = "rbototal";
            this.rbototal.Size = new System.Drawing.Size(98, 17);
            this.rbototal.TabIndex = 272;
            this.rbototal.Text = "Aprobado Total";
            this.rbototal.UseVisualStyleBackColor = true;
            // 
            // RAmbos
            // 
            this.RAmbos.AutoSize = true;
            this.RAmbos.Location = new System.Drawing.Point(322, 28);
            this.RAmbos.Name = "RAmbos";
            this.RAmbos.Size = new System.Drawing.Size(55, 17);
            this.RAmbos.TabIndex = 271;
            this.RAmbos.Text = "Todos";
            this.RAmbos.UseVisualStyleBackColor = true;
            // 
            // RPorAprobar
            // 
            this.RPorAprobar.AutoSize = true;
            this.RPorAprobar.Checked = true;
            this.RPorAprobar.Location = new System.Drawing.Point(27, 30);
            this.RPorAprobar.Name = "RPorAprobar";
            this.RPorAprobar.Size = new System.Drawing.Size(73, 17);
            this.RPorAprobar.TabIndex = 269;
            this.RPorAprobar.TabStop = true;
            this.RPorAprobar.Text = "Pendiente";
            this.RPorAprobar.UseVisualStyleBackColor = true;
            // 
            // RAprobados
            // 
            this.RAprobados.AutoSize = true;
            this.RAprobados.Location = new System.Drawing.Point(106, 30);
            this.RAprobados.Name = "RAprobados";
            this.RAprobados.Size = new System.Drawing.Size(106, 17);
            this.RAprobados.TabIndex = 270;
            this.RAprobados.Text = "Aprobado Parcial";
            this.RAprobados.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFinal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpInicio);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 62);
            this.panel1.TabIndex = 266;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 262;
            this.label1.Text = "De";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(161, 28);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 260;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 261;
            this.label2.Text = "hasta";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(29, 28);
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
            this.panel4.Location = new System.Drawing.Point(273, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(531, 62);
            this.panel4.TabIndex = 265;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(12, 29);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 299;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbUno
            // 
            this.rbUno.AutoSize = true;
            this.rbUno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUno.Location = new System.Drawing.Point(70, 29);
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
            this.txtRuc.Location = new System.Drawing.Point(138, 27);
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
            this.btProveedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedor.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btProveedor.Location = new System.Drawing.Point(492, 27);
            this.btProveedor.Name = "btProveedor";
            this.btProveedor.Size = new System.Drawing.Size(25, 21);
            this.btProveedor.TabIndex = 295;
            this.btProveedor.UseVisualStyleBackColor = true;
            this.btProveedor.Click += new System.EventHandler(this.btProveedor_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(214, 27);
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
            this.panel5.Location = new System.Drawing.Point(5, 68);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1208, 384);
            this.panel5.TabIndex = 264;
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
            this.numOrdenCompraDataGridViewTextBoxColumn,
            this.desTipOrdenCompraDataGridViewTextBoxColumn,
            this.desTipModalCompra,
            this.desTipCompra,
            this.fecEmision,
            this.fecRequerida,
            this.RazonSocial,
            this.desTipEstado,
            this.desTipEstadoAtencion,
            this.desMoneda,
            this.impVenta,
            this.impIgv,
            this.impTotal,
            this.UsuarioAprobacion,
            this.fecAprobacion,
            this.UsuarioRegistro,
            this.FechaRegistro,
            this.UsuarioModificacion,
            this.FechaModificacion});
            this.dgvListadoOC.ContextMenuStrip = this.CMS;
            this.dgvListadoOC.DataSource = this.bsOrdenesCompras;
            this.dgvListadoOC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoOC.EnableHeadersVisualStyles = false;
            this.dgvListadoOC.Location = new System.Drawing.Point(0, 18);
            this.dgvListadoOC.Name = "dgvListadoOC";
            this.dgvListadoOC.ReadOnly = true;
            this.dgvListadoOC.Size = new System.Drawing.Size(1206, 364);
            this.dgvListadoOC.TabIndex = 250;
            this.dgvListadoOC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoOC_CellDoubleClick);
            // 
            // idOrdenCompraDataGridViewTextBoxColumn
            // 
            this.idOrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "idOrdenCompra";
            this.idOrdenCompraDataGridViewTextBoxColumn.Frozen = true;
            this.idOrdenCompraDataGridViewTextBoxColumn.HeaderText = "ID.";
            this.idOrdenCompraDataGridViewTextBoxColumn.Name = "idOrdenCompraDataGridViewTextBoxColumn";
            this.idOrdenCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numOrdenCompraDataGridViewTextBoxColumn
            // 
            this.numOrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "numOrdenCompra";
            this.numOrdenCompraDataGridViewTextBoxColumn.Frozen = true;
            this.numOrdenCompraDataGridViewTextBoxColumn.HeaderText = "Nro OC.";
            this.numOrdenCompraDataGridViewTextBoxColumn.Name = "numOrdenCompraDataGridViewTextBoxColumn";
            this.numOrdenCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTipOrdenCompraDataGridViewTextBoxColumn
            // 
            this.desTipOrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "desTipOrdenCompra";
            this.desTipOrdenCompraDataGridViewTextBoxColumn.Frozen = true;
            this.desTipOrdenCompraDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.desTipOrdenCompraDataGridViewTextBoxColumn.Name = "desTipOrdenCompraDataGridViewTextBoxColumn";
            this.desTipOrdenCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTipModalCompra
            // 
            this.desTipModalCompra.DataPropertyName = "desTipModalCompra";
            this.desTipModalCompra.Frozen = true;
            this.desTipModalCompra.HeaderText = "Modalidad";
            this.desTipModalCompra.Name = "desTipModalCompra";
            this.desTipModalCompra.ReadOnly = true;
            // 
            // desTipCompra
            // 
            this.desTipCompra.DataPropertyName = "desTipCompra";
            this.desTipCompra.Frozen = true;
            this.desTipCompra.HeaderText = "Tip. Compra";
            this.desTipCompra.Name = "desTipCompra";
            this.desTipCompra.ReadOnly = true;
            // 
            // fecEmision
            // 
            this.fecEmision.DataPropertyName = "fecEmision";
            this.fecEmision.Frozen = true;
            this.fecEmision.HeaderText = "Fec. Emis.";
            this.fecEmision.Name = "fecEmision";
            this.fecEmision.ReadOnly = true;
            // 
            // fecRequerida
            // 
            this.fecRequerida.DataPropertyName = "fecRequerida";
            this.fecRequerida.Frozen = true;
            this.fecRequerida.HeaderText = "Fec. Req.";
            this.fecRequerida.Name = "fecRequerida";
            this.fecRequerida.ReadOnly = true;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.Frozen = true;
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
            this.desTipEstadoAtencion.HeaderText = "Est. Alm.";
            this.desTipEstadoAtencion.Name = "desTipEstadoAtencion";
            this.desTipEstadoAtencion.ReadOnly = true;
            this.desTipEstadoAtencion.ToolTipText = "Estado en el almacén";
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            // 
            // impVenta
            // 
            this.impVenta.DataPropertyName = "impVenta";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.impVenta.DefaultCellStyle = dataGridViewCellStyle7;
            this.impVenta.HeaderText = "Venta";
            this.impVenta.Name = "impVenta";
            this.impVenta.ReadOnly = true;
            // 
            // impIgv
            // 
            this.impIgv.DataPropertyName = "impIgv";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.impIgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.impIgv.HeaderText = "IGV";
            this.impIgv.Name = "impIgv";
            this.impIgv.ReadOnly = true;
            // 
            // impTotal
            // 
            this.impTotal.DataPropertyName = "impTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.impTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.impTotal.HeaderText = "Total";
            this.impTotal.Name = "impTotal";
            this.impTotal.ReadOnly = true;
            // 
            // UsuarioAprobacion
            // 
            this.UsuarioAprobacion.DataPropertyName = "UsuarioAprobacion";
            this.UsuarioAprobacion.HeaderText = "Usu. Aprob.";
            this.UsuarioAprobacion.Name = "UsuarioAprobacion";
            this.UsuarioAprobacion.ReadOnly = true;
            // 
            // fecAprobacion
            // 
            this.fecAprobacion.DataPropertyName = "fecAprobacion";
            this.fecAprobacion.HeaderText = "Fec. Aprob.";
            this.fecAprobacion.Name = "fecAprobacion";
            this.fecAprobacion.ReadOnly = true;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaRegistro.DefaultCellStyle = dataGridViewCellStyle10;
            this.FechaRegistro.HeaderText = "Fecha Reg.";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UsuarioModificacion.DefaultCellStyle = dataGridViewCellStyle11;
            this.UsuarioModificacion.HeaderText = "Usuario Mod.";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            this.UsuarioModificacion.ReadOnly = true;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaModificacion.DefaultCellStyle = dataGridViewCellStyle12;
            this.FechaModificacion.HeaderText = "Fecha Mod.";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 18);
            this.label4.TabIndex = 1585;
            this.label4.Text = "Fechas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(529, 18);
            this.label3.TabIndex = 1585;
            this.label3.Text = "Provedor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(406, 18);
            this.label5.TabIndex = 1585;
            this.label5.Text = "Opciones";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1206, 18);
            this.lblRegistros.TabIndex = 1585;
            this.lblRegistros.Text = "O.C.";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoAprobarOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 453);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Name = "frmListadoAprobarOrdenDeCompra";
            this.Text = "Ordenes de Compra por Aprobar";
            this.Load += new System.EventHandler(this.frmListadoActivarOdenDeCompra_Load);
            this.CMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenesCompras)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbUno;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.Button btProveedor;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoOC;
        private System.Windows.Forms.BindingSource bsOrdenesCompras;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem activar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton RAmbos;
        private System.Windows.Forms.RadioButton RPorAprobar;
        private System.Windows.Forms.RadioButton RAprobados;
        private System.Windows.Forms.RadioButton rbototal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numOrdenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipOrdenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipModalCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecRequerida;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipEstadoAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn impVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn impIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRegistros;
    }
}