namespace ClienteWinForm.Ventas
{
    partial class frmListaPrecio
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
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.desTipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porDscto1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porigvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsListaPrecioItem = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.NumUPDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCorto = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkTicket = new System.Windows.Forms.CheckBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.txtNombre = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btBuscarTexto = new System.Windows.Forms.Button();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaPrecioItem)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUPDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 96);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 74);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 30);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 52);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dgvPrecios);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(4, 181);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1026, 233);
            this.panel7.TabIndex = 344;
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            this.dgvPrecios.AutoGenerateColumns = false;
            this.dgvPrecios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desTipoArticulo,
            this.idArticulo,
            this.codArticulo,
            this.desArticulo,
            this.PrecioBruto,
            this.porDscto1DataGridViewTextBoxColumn,
            this.porigvDataGridViewTextBoxColumn,
            this.precioVentaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.Estado});
            this.dgvPrecios.DataSource = this.bsListaPrecioItem;
            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.EnableHeadersVisualStyles = false;
            this.dgvPrecios.Location = new System.Drawing.Point(0, 18);
            this.dgvPrecios.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.ReadOnly = true;
            this.dgvPrecios.RowTemplate.Height = 24;
            this.dgvPrecios.Size = new System.Drawing.Size(1024, 213);
            this.dgvPrecios.TabIndex = 98;
            this.dgvPrecios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrecios_CellDoubleClick);
            this.dgvPrecios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPrecios_CellFormatting);
            this.dgvPrecios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrecios_ColumnHeaderMouseClick);
            // 
            // desTipoArticulo
            // 
            this.desTipoArticulo.DataPropertyName = "desTipoArticulo";
            this.desTipoArticulo.Frozen = true;
            this.desTipoArticulo.HeaderText = "Tip. Art.";
            this.desTipoArticulo.Name = "desTipoArticulo";
            this.desTipoArticulo.ReadOnly = true;
            this.desTipoArticulo.Width = 130;
            // 
            // idArticulo
            // 
            this.idArticulo.DataPropertyName = "idArticulo";
            this.idArticulo.Frozen = true;
            this.idArticulo.HeaderText = "ID.";
            this.idArticulo.Name = "idArticulo";
            this.idArticulo.ReadOnly = true;
            this.idArticulo.Width = 40;
            // 
            // codArticulo
            // 
            this.codArticulo.DataPropertyName = "codArticulo";
            this.codArticulo.Frozen = true;
            this.codArticulo.HeaderText = "Cód.Articulo";
            this.codArticulo.Name = "codArticulo";
            this.codArticulo.ReadOnly = true;
            this.codArticulo.Width = 95;
            // 
            // desArticulo
            // 
            this.desArticulo.DataPropertyName = "desArticulo";
            this.desArticulo.HeaderText = "Descripción";
            this.desArticulo.Name = "desArticulo";
            this.desArticulo.ReadOnly = true;
            this.desArticulo.Width = 350;
            // 
            // PrecioBruto
            // 
            this.PrecioBruto.DataPropertyName = "PrecioBruto";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            this.PrecioBruto.DefaultCellStyle = dataGridViewCellStyle19;
            this.PrecioBruto.HeaderText = "Precio";
            this.PrecioBruto.Name = "PrecioBruto";
            this.PrecioBruto.ReadOnly = true;
            this.PrecioBruto.Width = 80;
            // 
            // porDscto1DataGridViewTextBoxColumn
            // 
            this.porDscto1DataGridViewTextBoxColumn.DataPropertyName = "PorDscto1";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.porDscto1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.porDscto1DataGridViewTextBoxColumn.HeaderText = "% Dscto";
            this.porDscto1DataGridViewTextBoxColumn.Name = "porDscto1DataGridViewTextBoxColumn";
            this.porDscto1DataGridViewTextBoxColumn.ReadOnly = true;
            this.porDscto1DataGridViewTextBoxColumn.Width = 60;
            // 
            // porigvDataGridViewTextBoxColumn
            // 
            this.porigvDataGridViewTextBoxColumn.DataPropertyName = "porigv";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N2";
            this.porigvDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
            this.porigvDataGridViewTextBoxColumn.HeaderText = "% Igv";
            this.porigvDataGridViewTextBoxColumn.Name = "porigvDataGridViewTextBoxColumn";
            this.porigvDataGridViewTextBoxColumn.ReadOnly = true;
            this.porigvDataGridViewTextBoxColumn.Width = 60;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            this.precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            this.precioVentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
            this.precioVentaDataGridViewTextBoxColumn.HeaderText = "Prec.Inc.IGV";
            this.precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            this.precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioVentaDataGridViewTextBoxColumn.Width = 90;
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
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 140;
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
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle24;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 140;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // bsListaPrecioItem
            // 
            this.bsListaPrecioItem.DataSource = typeof(Entidades.Ventas.ListaPrecioItemE);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1024, 18);
            this.label6.TabIndex = 346;
            this.label6.Text = "Precio Item";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(776, 4);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(254, 124);
            this.pnlAuditoria.TabIndex = 342;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 18);
            this.label3.TabIndex = 346;
            this.label3.Text = "Auditoria";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(111, 92);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(134, 21);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(111, 26);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(134, 21);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(111, 70);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(134, 21);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(111, 48);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(134, 21);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.NumUPDown);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtNombreCorto);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.chkTicket);
            this.pnlDetalle.Controls.Add(this.chkPrincipal);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.cboMoneda);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(769, 124);
            this.pnlDetalle.TabIndex = 343;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(767, 18);
            this.label8.TabIndex = 346;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumUPDown
            // 
            this.NumUPDown.Location = new System.Drawing.Point(273, 38);
            this.NumUPDown.Name = "NumUPDown";
            this.NumUPDown.Size = new System.Drawing.Size(48, 20);
            this.NumUPDown.TabIndex = 330;
            this.NumUPDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumUPDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 329;
            this.label2.Text = "Nro. Lista";
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreCorto.BackColor = System.Drawing.Color.White;
            this.txtNombreCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCorto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreCorto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCorto.Location = new System.Drawing.Point(84, 83);
            this.txtNombreCorto.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(124, 20);
            this.txtNombreCorto.TabIndex = 326;
            this.txtNombreCorto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreCorto.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 327;
            this.label1.Text = "Nombre Corto";
            // 
            // chkTicket
            // 
            this.chkTicket.AutoSize = true;
            this.chkTicket.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTicket.Location = new System.Drawing.Point(218, 87);
            this.chkTicket.Name = "chkTicket";
            this.chkTicket.Size = new System.Drawing.Size(123, 17);
            this.chkTicket.TabIndex = 325;
            this.chkTicket.Text = "Para punto de venta";
            this.chkTicket.UseVisualStyleBackColor = true;
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.AutoSize = true;
            this.chkPrincipal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPrincipal.Location = new System.Drawing.Point(349, 87);
            this.chkPrincipal.Name = "chkPrincipal";
            this.chkPrincipal.Size = new System.Drawing.Size(100, 17);
            this.chkPrincipal.TabIndex = 324;
            this.chkPrincipal.Text = "Predeterminado";
            this.chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(84, 61);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(659, 20);
            this.txtNombre.TabIndex = 322;
            this.txtNombre.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombre.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 323;
            this.label9.Text = "Nombre";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(84, 38);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(124, 21);
            this.cboMoneda.TabIndex = 320;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 321;
            this.label12.Text = "Moneda";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btBuscarTexto);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(4, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 49);
            this.panel1.TabIndex = 345;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(382, 18);
            this.label5.TabIndex = 1581;
            this.label5.Text = "Búsqueda";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscarTexto
            // 
            this.btBuscarTexto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarTexto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarTexto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarTexto.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarTexto.Location = new System.Drawing.Point(327, 22);
            this.btBuscarTexto.Name = "btBuscarTexto";
            this.btBuscarTexto.Size = new System.Drawing.Size(23, 20);
            this.btBuscarTexto.TabIndex = 1580;
            this.btBuscarTexto.UseVisualStyleBackColor = true;
            this.btBuscarTexto.Click += new System.EventHandler(this.btBuscarTexto_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(85, 22);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(239, 20);
            this.txtDescripcion.TabIndex = 326;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescripcion_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 327;
            this.label4.Text = "Nombre Prod.";
            // 
            // frmListaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = true;
            this.Name = "frmListaPrecio";
            this.Text = "Lista de Precio (Nuevo)";
            this.Load += new System.EventHandler(this.frmListaPrecio_Load);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaPrecioItem)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUPDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtNombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bsListaPrecioItem;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.CheckBox chkTicket;
        private ControlesWinForm.SuperTextBox txtNombreCorto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumUPDown;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btBuscarTexto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn desArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn porDscto1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porigvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
    }
}