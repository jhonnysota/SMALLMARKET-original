namespace ClienteWinForm.Ventas
{
    partial class frmListadoCotizaciones
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
            this.btDesvincular = new System.Windows.Forms.Button();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.txtNombresVendedor = new ControlesWinForm.SuperTextBox();
            this.txtNroDocumentoVen = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.txtPedido = new ControlesWinForm.SuperTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCotizaciones = new System.Windows.Forms.DataGridView();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desFacturarDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendedorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsCotizacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCrear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMandar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsCotizacion = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlOpciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).BeginInit();
            this.cmsCotizacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btDesvincular
            // 
            this.btDesvincular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btDesvincular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btDesvincular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btDesvincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDesvincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDesvincular.Image = global::ClienteWinForm.Properties.Resources.Desvincular_16x16;
            this.btDesvincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDesvincular.Location = new System.Drawing.Point(847, 58);
            this.btDesvincular.Name = "btDesvincular";
            this.btDesvincular.Size = new System.Drawing.Size(237, 27);
            this.btDesvincular.TabIndex = 310;
            this.btDesvincular.TabStop = false;
            this.btDesvincular.Text = "Desvincular Documentos de Ventas";
            this.btDesvincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDesvincular.UseVisualStyleBackColor = true;
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpciones.Controls.Add(this.label4);
            this.pnlOpciones.Controls.Add(this.txtNombresVendedor);
            this.pnlOpciones.Controls.Add(this.txtNroDocumentoVen);
            this.pnlOpciones.Controls.Add(this.label3);
            this.pnlOpciones.Controls.Add(this.label1);
            this.pnlOpciones.Controls.Add(this.label2);
            this.pnlOpciones.Controls.Add(this.cboTipo);
            this.pnlOpciones.Controls.Add(this.dtpInicio);
            this.pnlOpciones.Controls.Add(this.dtpFin);
            this.pnlOpciones.Controls.Add(this.txtPedido);
            this.pnlOpciones.Controls.Add(this.btnBuscar);
            this.pnlOpciones.Controls.Add(this.txtDescripcion);
            this.pnlOpciones.Location = new System.Drawing.Point(3, 2);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(839, 85);
            this.pnlOpciones.TabIndex = 309;
            // 
            // txtNombresVendedor
            // 
            this.txtNombresVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNombresVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNombresVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombresVendedor.Enabled = false;
            this.txtNombresVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombresVendedor.Location = new System.Drawing.Point(441, 53);
            this.txtNombresVendedor.Name = "txtNombresVendedor";
            this.txtNombresVendedor.Size = new System.Drawing.Size(377, 20);
            this.txtNombresVendedor.TabIndex = 319;
            this.txtNombresVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombresVendedor.TextoVacio = "Nombre Vendedor";
            this.txtNombresVendedor.TextChanged += new System.EventHandler(this.txtNombresVendedor_TextChanged);
            this.txtNombresVendedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombresVendedor_Validating);
            // 
            // txtNroDocumentoVen
            // 
            this.txtNroDocumentoVen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNroDocumentoVen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNroDocumentoVen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroDocumentoVen.Enabled = false;
            this.txtNroDocumentoVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumentoVen.Location = new System.Drawing.Point(366, 53);
            this.txtNroDocumentoVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroDocumentoVen.Name = "txtNroDocumentoVen";
            this.txtNroDocumentoVen.Size = new System.Drawing.Size(72, 20);
            this.txtNroDocumentoVen.TabIndex = 316;
            this.txtNroDocumentoVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroDocumentoVen.TextoVacio = "Doc.Ident.";
            this.txtNroDocumentoVen.TextChanged += new System.EventHandler(this.txtNroDocumentoVen_TextChanged);
            this.txtNroDocumentoVen.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroDocumentoVen_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(496, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 255;
            this.label3.Text = "Al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 264;
            this.label1.Text = "Tipo Pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 254;
            this.label2.Text = "Del";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(204, 30);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(150, 21);
            this.cboTipo.TabIndex = 262;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(394, 30);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(92, 20);
            this.dtpInicio.TabIndex = 252;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(523, 30);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(92, 20);
            this.dtpFin.TabIndex = 253;
            // 
            // txtPedido
            // 
            this.txtPedido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtPedido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(18, 30);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(116, 20);
            this.txtPedido.TabIndex = 260;
            this.txtPedido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPedido.TextoVacio = "Cód.Pedido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.btnBuscar.Location = new System.Drawing.Point(1217, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(83, 59);
            this.btnBuscar.TabIndex = 154;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(18, 53);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(336, 20);
            this.txtDescripcion.TabIndex = 263;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "Razón Social";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCotizaciones);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 328);
            this.panel1.TabIndex = 308;
            // 
            // dgvCotizaciones
            // 
            this.dgvCotizaciones.AllowUserToAddRows = false;
            this.dgvCotizaciones.AllowUserToDeleteRows = false;
            this.dgvCotizaciones.AutoGenerateColumns = false;
            this.dgvCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCotizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedido,
            this.codPedidoDataGridViewTextBoxColumn,
            this.desFacturarDataGridViewTextBoxColumn1,
            this.vendedorDataGridViewTextBoxColumn1,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.Estado});
            this.dgvCotizaciones.ContextMenuStrip = this.cmsCotizacion;
            this.dgvCotizaciones.DataSource = this.bsCotizacion;
            this.dgvCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCotizaciones.EnableHeadersVisualStyles = false;
            this.dgvCotizaciones.Location = new System.Drawing.Point(0, 18);
            this.dgvCotizaciones.Name = "dgvCotizaciones";
            this.dgvCotizaciones.ReadOnly = true;
            this.dgvCotizaciones.Size = new System.Drawing.Size(1118, 308);
            this.dgvCotizaciones.TabIndex = 303;
            this.dgvCotizaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCotizaciones_CellDoubleClick);
            this.dgvCotizaciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCotizaciones_CellFormatting);
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "ID.";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Width = 50;
            // 
            // codPedidoDataGridViewTextBoxColumn
            // 
            this.codPedidoDataGridViewTextBoxColumn.DataPropertyName = "codPedidoCad";
            this.codPedidoDataGridViewTextBoxColumn.HeaderText = "Cód.Cotiz.";
            this.codPedidoDataGridViewTextBoxColumn.Name = "codPedidoDataGridViewTextBoxColumn";
            this.codPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPedidoDataGridViewTextBoxColumn.Width = 80;
            // 
            // desFacturarDataGridViewTextBoxColumn1
            // 
            this.desFacturarDataGridViewTextBoxColumn1.DataPropertyName = "desFacturar";
            this.desFacturarDataGridViewTextBoxColumn1.HeaderText = "Razón Social";
            this.desFacturarDataGridViewTextBoxColumn1.Name = "desFacturarDataGridViewTextBoxColumn1";
            this.desFacturarDataGridViewTextBoxColumn1.ReadOnly = true;
            this.desFacturarDataGridViewTextBoxColumn1.Width = 250;
            // 
            // vendedorDataGridViewTextBoxColumn1
            // 
            this.vendedorDataGridViewTextBoxColumn1.DataPropertyName = "Vendedor";
            this.vendedorDataGridViewTextBoxColumn1.HeaderText = "Vendedor";
            this.vendedorDataGridViewTextBoxColumn1.Name = "vendedorDataGridViewTextBoxColumn1";
            this.vendedorDataGridViewTextBoxColumn1.ReadOnly = true;
            this.vendedorDataGridViewTextBoxColumn1.Width = 200;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn1
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn1.Name = "usuarioRegistroDataGridViewTextBoxColumn1";
            this.usuarioRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn1
            // 
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "fechaRegistro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaRegistroDataGridViewTextBoxColumn1.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn1.Name = "fechaRegistroDataGridViewTextBoxColumn1";
            this.fechaRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn1.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn1
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn1.Name = "usuarioModificacionDataGridViewTextBoxColumn1";
            this.usuarioModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "fechaModificacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // cmsCotizacion
            // 
            this.cmsCotizacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsCotizacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCrear,
            this.tsmiMandar,
            this.toolStripSeparator1,
            this.tsmiCopiar});
            this.cmsCotizacion.Name = "cmsFactura";
            this.cmsCotizacion.Size = new System.Drawing.Size(176, 76);
            // 
            // tsmiCrear
            // 
            this.tsmiCrear.Image = global::ClienteWinForm.Properties.Resources.CrearDocumentos;
            this.tsmiCrear.Name = "tsmiCrear";
            this.tsmiCrear.Size = new System.Drawing.Size(175, 22);
            this.tsmiCrear.Text = "Crear Pedido";
            this.tsmiCrear.Click += new System.EventHandler(this.tsmiCrear_Click);
            // 
            // tsmiMandar
            // 
            this.tsmiMandar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiMandar.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.tsmiMandar.Name = "tsmiMandar";
            this.tsmiMandar.Size = new System.Drawing.Size(175, 22);
            this.tsmiMandar.Text = "Mandar por Correo";
            this.tsmiMandar.Click += new System.EventHandler(this.tsmiMandar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiCopiar
            // 
            this.tsmiCopiar.Image = global::ClienteWinForm.Properties.Resources.Copiar32x32;
            this.tsmiCopiar.Name = "tsmiCopiar";
            this.tsmiCopiar.Size = new System.Drawing.Size(175, 22);
            this.tsmiCopiar.Text = "Copiar Cotización";
            this.tsmiCopiar.Click += new System.EventHandler(this.tsmiCopiar_Click);
            // 
            // bsCotizacion
            // 
            this.bsCotizacion.DataSource = typeof(Entidades.Ventas.PedidoCabE);
            this.bsCotizacion.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCotizacion_ListChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1118, 18);
            this.lblRegistros.TabIndex = 373;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(837, 18);
            this.label4.TabIndex = 373;
            this.label4.Text = "Opciones de Búsqueda";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 421);
            this.Controls.Add(this.btDesvincular);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoCotizaciones";
            this.Text = "Listado de Cotizaciones";
            this.Load += new System.EventHandler(this.frmListadoCotizaciones_Load);
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).EndInit();
            this.cmsCotizacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCotizacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDesvincular;
        private System.Windows.Forms.Panel pnlOpciones;
        private ControlesWinForm.SuperTextBox txtNombresVendedor;
        private ControlesWinForm.SuperTextBox txtNroDocumentoVen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private ControlesWinForm.SuperTextBox txtPedido;
        protected internal System.Windows.Forms.Button btnBuscar;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bsCotizacion;
        private System.Windows.Forms.ContextMenuStrip cmsCotizacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiCrear;
        private System.Windows.Forms.ToolStripMenuItem tsmiMandar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopiar;
        private System.Windows.Forms.DataGridView dgvCotizaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desFacturarDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendedorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRegistros;
    }
}