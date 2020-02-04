namespace ClienteWinForm.Ventas
{
    partial class frmPresupuestoVenta
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsPresupuestoVentaDet = new System.Windows.Forms.BindingSource(this.components);
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtfechamod = new System.Windows.Forms.TextBox();
            this.txtusuRegistro = new System.Windows.Forms.TextBox();
            this.txtusumod = new System.Windows.Forms.TextBox();
            this.txtFechareg = new System.Windows.Forms.TextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.cboTipoArticulo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.btProveedor = new System.Windows.Forms.Button();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.dgvPresuDetalle = new System.Windows.Forms.DataGridView();
            this.idArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesTipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label31 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblRegistros = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsPresupuestoVentaDet)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresuDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(10, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(10, 74);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(10, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(10, 51);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(18, 62);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(53, 13);
            descripcionLabel.TabIndex = 250;
            descripcionLabel.Text = "Vendedor";
            // 
            // bsPresupuestoVentaDet
            // 
            this.bsPresupuestoVentaDet.DataSource = typeof(Entidades.Ventas.PresupuestoVentaDetE);
            this.bsPresupuestoVentaDet.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPresupuestoVentaDet_ListChanged);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label31);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtfechamod);
            this.pnlAuditoria.Controls.Add(this.txtusuRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtusumod);
            this.pnlAuditoria.Controls.Add(this.txtFechareg);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(538, 3);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(264, 121);
            this.pnlAuditoria.TabIndex = 260;
            // 
            // txtfechamod
            // 
            this.txtfechamod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtfechamod.Enabled = false;
            this.txtfechamod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfechamod.Location = new System.Drawing.Point(119, 92);
            this.txtfechamod.Name = "txtfechamod";
            this.txtfechamod.Size = new System.Drawing.Size(132, 21);
            this.txtfechamod.TabIndex = 7;
            // 
            // txtusuRegistro
            // 
            this.txtusuRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtusuRegistro.Enabled = false;
            this.txtusuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuRegistro.Location = new System.Drawing.Point(119, 23);
            this.txtusuRegistro.Name = "txtusuRegistro";
            this.txtusuRegistro.Size = new System.Drawing.Size(132, 21);
            this.txtusuRegistro.TabIndex = 1;
            // 
            // txtusumod
            // 
            this.txtusumod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtusumod.Enabled = false;
            this.txtusumod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusumod.Location = new System.Drawing.Point(119, 69);
            this.txtusumod.Name = "txtusumod";
            this.txtusumod.Size = new System.Drawing.Size(132, 21);
            this.txtusumod.TabIndex = 5;
            // 
            // txtFechareg
            // 
            this.txtFechareg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechareg.Enabled = false;
            this.txtFechareg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechareg.Location = new System.Drawing.Point(119, 46);
            this.txtFechareg.Name = "txtFechareg";
            this.txtFechareg.Size = new System.Drawing.Size(132, 21);
            this.txtFechareg.TabIndex = 3;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.cboTipoArticulo);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.cboMoneda);
            this.pnlDatos.Controls.Add(this.btProveedor);
            this.pnlDatos.Controls.Add(this.cboAño);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Controls.Add(descripcionLabel);
            this.pnlDatos.Controls.Add(this.txtVendedor);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(532, 121);
            this.pnlDatos.TabIndex = 258;
            // 
            // cboTipoArticulo
            // 
            this.cboTipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoArticulo.FormattingEnabled = true;
            this.cboTipoArticulo.Location = new System.Drawing.Point(327, 82);
            this.cboTipoArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoArticulo.Name = "cboTipoArticulo";
            this.cboTipoArticulo.Size = new System.Drawing.Size(181, 21);
            this.cboTipoArticulo.TabIndex = 344;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 344;
            this.label7.Text = "Tipo Articulo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 343;
            this.label6.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(75, 82);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(181, 21);
            this.cboMoneda.TabIndex = 342;
            // 
            // btProveedor
            // 
            this.btProveedor.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btProveedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProveedor.Location = new System.Drawing.Point(482, 59);
            this.btProveedor.Name = "btProveedor";
            this.btProveedor.Size = new System.Drawing.Size(25, 19);
            this.btProveedor.TabIndex = 341;
            this.btProveedor.TabStop = false;
            this.btProveedor.UseVisualStyleBackColor = true;
            this.btProveedor.Click += new System.EventHandler(this.btProveedor_Click);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(75, 34);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(86, 21);
            this.cboAño.TabIndex = 313;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 314;
            this.label2.Text = "Año";
            // 
            // txtVendedor
            // 
            this.txtVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtVendedor.Enabled = false;
            this.txtVendedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Location = new System.Drawing.Point(75, 58);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(403, 21);
            this.txtVendedor.TabIndex = 2;
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalles.Controls.Add(this.dgvPresuDetalle);
            this.pnlDetalles.Controls.Add(this.LblRegistros);
            this.pnlDetalles.Location = new System.Drawing.Point(3, 128);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(799, 289);
            this.pnlDetalles.TabIndex = 259;
            // 
            // dgvPresuDetalle
            // 
            this.dgvPresuDetalle.AllowUserToAddRows = false;
            this.dgvPresuDetalle.AllowUserToDeleteRows = false;
            this.dgvPresuDetalle.AutoGenerateColumns = false;
            this.dgvPresuDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresuDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresuDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idArticulo,
            this.DesTipoArticulo,
            this.DesEstablecimiento,
            this.cantidadDataGridViewTextBoxColumn,
            this.NombreMes,
            this.precioUnitDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvPresuDetalle.DataSource = this.bsPresupuestoVentaDet;
            this.dgvPresuDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresuDetalle.EnableHeadersVisualStyles = false;
            this.dgvPresuDetalle.Location = new System.Drawing.Point(0, 18);
            this.dgvPresuDetalle.Name = "dgvPresuDetalle";
            this.dgvPresuDetalle.ReadOnly = true;
            this.dgvPresuDetalle.Size = new System.Drawing.Size(797, 269);
            this.dgvPresuDetalle.TabIndex = 5;
            this.dgvPresuDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresuDetalle_CellDoubleClick);
            // 
            // idArticulo
            // 
            this.idArticulo.DataPropertyName = "codArticulo";
            this.idArticulo.HeaderText = "Cód.";
            this.idArticulo.Name = "idArticulo";
            this.idArticulo.ReadOnly = true;
            this.idArticulo.Width = 70;
            // 
            // DesTipoArticulo
            // 
            this.DesTipoArticulo.DataPropertyName = "DesTipoArticulo";
            this.DesTipoArticulo.HeaderText = "Descripción";
            this.DesTipoArticulo.Name = "DesTipoArticulo";
            this.DesTipoArticulo.ReadOnly = true;
            this.DesTipoArticulo.Width = 250;
            // 
            // DesEstablecimiento
            // 
            this.DesEstablecimiento.DataPropertyName = "DesEstablecimiento";
            this.DesEstablecimiento.HeaderText = "Establecimiento";
            this.DesEstablecimiento.Name = "DesEstablecimiento";
            this.DesEstablecimiento.ReadOnly = true;
            this.DesEstablecimiento.Width = 150;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cant.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 70;
            // 
            // NombreMes
            // 
            this.NombreMes.DataPropertyName = "NombreMes";
            this.NombreMes.HeaderText = "Mes";
            this.NombreMes.Name = "NombreMes";
            this.NombreMes.ReadOnly = true;
            this.NombreMes.Width = 70;
            // 
            // precioUnitDataGridViewTextBoxColumn
            // 
            this.precioUnitDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.precioUnitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.precioUnitDataGridViewTextBoxColumn.HeaderText = "Precio Unit.";
            this.precioUnitDataGridViewTextBoxColumn.Name = "precioUnitDataGridViewTextBoxColumn";
            this.precioUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioUnitDataGridViewTextBoxColumn.Width = 90;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 90;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label31.Dock = System.Windows.Forms.DockStyle.Top;
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(0, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(262, 18);
            this.label31.TabIndex = 325;
            this.label31.Text = "Auditoria";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(530, 18);
            this.label8.TabIndex = 345;
            this.label8.Text = "Datos";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblRegistros
            // 
            this.LblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(0, 0);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(797, 18);
            this.LblRegistros.TabIndex = 325;
            this.LblRegistros.Text = "Articulos 0";
            this.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPresupuestoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 419);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlDetalles);
            this.Name = "frmPresupuestoVenta";
            this.Text = "Presupuesto de Venta (Nuevo)";
            this.Load += new System.EventHandler(this.frmPresupuestoVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPresupuestoVentaDet)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresuDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtfechamod;
        private System.Windows.Forms.TextBox txtusuRegistro;
        private System.Windows.Forms.TextBox txtusumod;
        private System.Windows.Forms.TextBox txtFechareg;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.DataGridView dgvPresuDetalle;
        private System.Windows.Forms.BindingSource bsPresupuestoVentaDet;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btProveedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.ComboBox cboTipoArticulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesTipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblRegistros;
    }
}