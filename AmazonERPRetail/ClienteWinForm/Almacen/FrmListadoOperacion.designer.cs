namespace ClienteWinForm.Almacen
{
    partial class FrmListadoOperacion
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
            this.bsOperacion = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoAlmacen = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOperacion = new System.Windows.Forms.DataGridView();
            this.desMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desOperacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desDetalleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indValorizarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indServicioDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.automaticoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indTransferenciaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indConsumoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indOrdentrabajoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indCostoVenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indProveedorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indClienteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indOrdenCompraDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indDevolucion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscar = new ControlesWinForm.SuperTextBox();
            this.btCopiar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperacion)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperacion)).BeginInit();
            this.SuspendLayout();
            // 
            // bsOperacion
            // 
            this.bsOperacion.DataSource = typeof(Entidades.Almacen.OperacionE);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 274;
            this.label5.Text = "Tipo Movimiento";
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimiento.DropDownWidth = 122;
            this.cboTipoMovimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovimiento.FormattingEnabled = true;
            this.cboTipoMovimiento.Location = new System.Drawing.Point(338, 6);
            this.cboTipoMovimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(167, 21);
            this.cboTipoMovimiento.TabIndex = 275;
            this.cboTipoMovimiento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoMovimiento_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 273;
            this.label3.Text = "Tipo de Articulo";
            // 
            // cboTipoAlmacen
            // 
            this.cboTipoAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAlmacen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAlmacen.FormattingEnabled = true;
            this.cboTipoAlmacen.Location = new System.Drawing.Point(94, 6);
            this.cboTipoAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAlmacen.Name = "cboTipoAlmacen";
            this.cboTipoAlmacen.Size = new System.Drawing.Size(156, 21);
            this.cboTipoAlmacen.TabIndex = 272;
            this.cboTipoAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cboTipoAlmacen_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvOperacion);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 338);
            this.panel1.TabIndex = 250;
            // 
            // dgvOperacion
            // 
            this.dgvOperacion.AllowUserToAddRows = false;
            this.dgvOperacion.AllowUserToDeleteRows = false;
            this.dgvOperacion.AutoGenerateColumns = false;
            this.dgvOperacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desMovimiento,
            this.idOperacion,
            this.desOperacionDataGridViewTextBoxColumn,
            this.desDetalleDataGridViewTextBoxColumn,
            this.orden,
            this.codSunat,
            this.nomSunat,
            this.indValorizarDataGridViewCheckBoxColumn,
            this.indServicioDataGridViewCheckBoxColumn,
            this.automaticoDataGridViewCheckBoxColumn,
            this.indTransferenciaDataGridViewCheckBoxColumn,
            this.indConsumoDataGridViewCheckBoxColumn,
            this.indOrdentrabajoDataGridViewCheckBoxColumn,
            this.indCostoVenta,
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn,
            this.indProveedorDataGridViewCheckBoxColumn,
            this.indClienteDataGridViewCheckBoxColumn,
            this.indOrdenCompraDataGridViewCheckBoxColumn,
            this.indDevolucion,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvOperacion.DataSource = this.bsOperacion;
            this.dgvOperacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperacion.EnableHeadersVisualStyles = false;
            this.dgvOperacion.Location = new System.Drawing.Point(0, 18);
            this.dgvOperacion.Name = "dgvOperacion";
            this.dgvOperacion.ReadOnly = true;
            this.dgvOperacion.Size = new System.Drawing.Size(1114, 318);
            this.dgvOperacion.TabIndex = 1;
            this.dgvOperacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperacion_CellDoubleClick);
            // 
            // desMovimiento
            // 
            this.desMovimiento.DataPropertyName = "desMovimiento";
            this.desMovimiento.Frozen = true;
            this.desMovimiento.HeaderText = "Tipo Mov.";
            this.desMovimiento.Name = "desMovimiento";
            this.desMovimiento.ReadOnly = true;
            this.desMovimiento.Width = 80;
            // 
            // idOperacion
            // 
            this.idOperacion.DataPropertyName = "idOperacion";
            this.idOperacion.Frozen = true;
            this.idOperacion.HeaderText = "Cód.";
            this.idOperacion.Name = "idOperacion";
            this.idOperacion.ReadOnly = true;
            this.idOperacion.Width = 40;
            // 
            // desOperacionDataGridViewTextBoxColumn
            // 
            this.desOperacionDataGridViewTextBoxColumn.DataPropertyName = "desOperacion";
            this.desOperacionDataGridViewTextBoxColumn.Frozen = true;
            this.desOperacionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desOperacionDataGridViewTextBoxColumn.Name = "desOperacionDataGridViewTextBoxColumn";
            this.desOperacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.desOperacionDataGridViewTextBoxColumn.Width = 200;
            // 
            // desDetalleDataGridViewTextBoxColumn
            // 
            this.desDetalleDataGridViewTextBoxColumn.DataPropertyName = "desDetalle";
            this.desDetalleDataGridViewTextBoxColumn.Frozen = true;
            this.desDetalleDataGridViewTextBoxColumn.HeaderText = "Detalle";
            this.desDetalleDataGridViewTextBoxColumn.Name = "desDetalleDataGridViewTextBoxColumn";
            this.desDetalleDataGridViewTextBoxColumn.ReadOnly = true;
            this.desDetalleDataGridViewTextBoxColumn.Width = 80;
            // 
            // orden
            // 
            this.orden.DataPropertyName = "orden";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.orden.DefaultCellStyle = dataGridViewCellStyle1;
            this.orden.Frozen = true;
            this.orden.HeaderText = "orden";
            this.orden.Name = "orden";
            this.orden.ReadOnly = true;
            this.orden.ToolTipText = "Orden de Calculo";
            this.orden.Width = 30;
            // 
            // codSunat
            // 
            this.codSunat.DataPropertyName = "codSunat";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codSunat.DefaultCellStyle = dataGridViewCellStyle2;
            this.codSunat.Frozen = true;
            this.codSunat.HeaderText = "C.Sunat";
            this.codSunat.Name = "codSunat";
            this.codSunat.ReadOnly = true;
            this.codSunat.ToolTipText = "Codigo Sunat";
            this.codSunat.Width = 30;
            // 
            // nomSunat
            // 
            this.nomSunat.DataPropertyName = "nomSunat";
            this.nomSunat.Frozen = true;
            this.nomSunat.HeaderText = "nomSunat";
            this.nomSunat.Name = "nomSunat";
            this.nomSunat.ReadOnly = true;
            this.nomSunat.ToolTipText = "Descripcion Sunat";
            this.nomSunat.Width = 180;
            // 
            // indValorizarDataGridViewCheckBoxColumn
            // 
            this.indValorizarDataGridViewCheckBoxColumn.DataPropertyName = "indValorizar";
            this.indValorizarDataGridViewCheckBoxColumn.HeaderText = "Ind.Val.";
            this.indValorizarDataGridViewCheckBoxColumn.Name = "indValorizarDataGridViewCheckBoxColumn";
            this.indValorizarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indValorizarDataGridViewCheckBoxColumn.ToolTipText = "Indica Valorizar";
            this.indValorizarDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indServicioDataGridViewCheckBoxColumn
            // 
            this.indServicioDataGridViewCheckBoxColumn.DataPropertyName = "indServicio";
            this.indServicioDataGridViewCheckBoxColumn.HeaderText = "Ind.Aju.";
            this.indServicioDataGridViewCheckBoxColumn.Name = "indServicioDataGridViewCheckBoxColumn";
            this.indServicioDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indServicioDataGridViewCheckBoxColumn.ToolTipText = "Indica Ajuste al Costo";
            this.indServicioDataGridViewCheckBoxColumn.Width = 55;
            // 
            // automaticoDataGridViewCheckBoxColumn
            // 
            this.automaticoDataGridViewCheckBoxColumn.DataPropertyName = "automatico";
            this.automaticoDataGridViewCheckBoxColumn.HeaderText = "Autom.";
            this.automaticoDataGridViewCheckBoxColumn.Name = "automaticoDataGridViewCheckBoxColumn";
            this.automaticoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.automaticoDataGridViewCheckBoxColumn.ToolTipText = "Automático";
            this.automaticoDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indTransferenciaDataGridViewCheckBoxColumn
            // 
            this.indTransferenciaDataGridViewCheckBoxColumn.DataPropertyName = "indTransferencia";
            this.indTransferenciaDataGridViewCheckBoxColumn.HeaderText = "Ind.Trans.";
            this.indTransferenciaDataGridViewCheckBoxColumn.Name = "indTransferenciaDataGridViewCheckBoxColumn";
            this.indTransferenciaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indTransferenciaDataGridViewCheckBoxColumn.ToolTipText = "Indica Transferencia";
            this.indTransferenciaDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indConsumoDataGridViewCheckBoxColumn
            // 
            this.indConsumoDataGridViewCheckBoxColumn.DataPropertyName = "indConsumo";
            this.indConsumoDataGridViewCheckBoxColumn.HeaderText = "Ind.Con.";
            this.indConsumoDataGridViewCheckBoxColumn.Name = "indConsumoDataGridViewCheckBoxColumn";
            this.indConsumoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indConsumoDataGridViewCheckBoxColumn.ToolTipText = "Indica Consumo";
            this.indConsumoDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indOrdentrabajoDataGridViewCheckBoxColumn
            // 
            this.indOrdentrabajoDataGridViewCheckBoxColumn.DataPropertyName = "indOrdentrabajo";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.HeaderText = "Ind.O.T.";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.Name = "indOrdentrabajoDataGridViewCheckBoxColumn";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indOrdentrabajoDataGridViewCheckBoxColumn.ToolTipText = "Indica Orde de Trabajo";
            this.indOrdentrabajoDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indCostoVenta
            // 
            this.indCostoVenta.DataPropertyName = "indCostoVenta";
            this.indCostoVenta.HeaderText = "Ind.C.V.";
            this.indCostoVenta.Name = "indCostoVenta";
            this.indCostoVenta.ReadOnly = true;
            this.indCostoVenta.ToolTipText = "Indica Costo de Venta";
            this.indCostoVenta.Width = 55;
            // 
            // indDocumentoAutomaticoDataGridViewCheckBoxColumn
            // 
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.DataPropertyName = "indDocumentoAutomatico";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.HeaderText = "Ind.Doc.Auto.";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.Name = "indDocumentoAutomaticoDataGridViewCheckBoxColumn";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.ToolTipText = "Indica Documento Automático";
            this.indDocumentoAutomaticoDataGridViewCheckBoxColumn.Width = 65;
            // 
            // indProveedorDataGridViewCheckBoxColumn
            // 
            this.indProveedorDataGridViewCheckBoxColumn.DataPropertyName = "indProveedor";
            this.indProveedorDataGridViewCheckBoxColumn.HeaderText = "Ind.Prov.";
            this.indProveedorDataGridViewCheckBoxColumn.Name = "indProveedorDataGridViewCheckBoxColumn";
            this.indProveedorDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indProveedorDataGridViewCheckBoxColumn.ToolTipText = "Indica Proveedor";
            this.indProveedorDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indClienteDataGridViewCheckBoxColumn
            // 
            this.indClienteDataGridViewCheckBoxColumn.DataPropertyName = "indCliente";
            this.indClienteDataGridViewCheckBoxColumn.HeaderText = "Ind.Cli.";
            this.indClienteDataGridViewCheckBoxColumn.Name = "indClienteDataGridViewCheckBoxColumn";
            this.indClienteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indClienteDataGridViewCheckBoxColumn.ToolTipText = "Indica Cliente";
            this.indClienteDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indOrdenCompraDataGridViewCheckBoxColumn
            // 
            this.indOrdenCompraDataGridViewCheckBoxColumn.DataPropertyName = "indOrdenCompra";
            this.indOrdenCompraDataGridViewCheckBoxColumn.HeaderText = "Ind.O.C.";
            this.indOrdenCompraDataGridViewCheckBoxColumn.Name = "indOrdenCompraDataGridViewCheckBoxColumn";
            this.indOrdenCompraDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indOrdenCompraDataGridViewCheckBoxColumn.Width = 55;
            // 
            // indDevolucion
            // 
            this.indDevolucion.DataPropertyName = "indDevolucion";
            this.indDevolucion.HeaderText = "Ind.Dev.";
            this.indDevolucion.Name = "indDevolucion";
            this.indDevolucion.ReadOnly = true;
            this.indDevolucion.Width = 55;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtBuscar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(508, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(290, 21);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtBuscar.TextoVacio = "Ingrese  Descripción";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btCopiar
            // 
            this.btCopiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCopiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.btCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCopiar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCopiar.Image = global::ClienteWinForm.Properties.Resources.Copiar16x16;
            this.btCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCopiar.Location = new System.Drawing.Point(804, 4);
            this.btCopiar.Name = "btCopiar";
            this.btCopiar.Size = new System.Drawing.Size(83, 25);
            this.btCopiar.TabIndex = 611;
            this.btCopiar.Text = "Copiar de";
            this.btCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCopiar.UseVisualStyleBackColor = true;
            this.btCopiar.Click += new System.EventHandler(this.btCopiar_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1114, 18);
            this.lblRegistros.TabIndex = 1580;
            this.lblRegistros.Text = "Datos Principales";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmListadoOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 375);
            this.Controls.Add(this.btCopiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboTipoMovimiento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoAlmacen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBuscar);
            this.Name = "FrmListadoOperacion";
            this.Text = "Listado de Operaciones";
            this.Load += new System.EventHandler(this.FrmListadoOperacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsOperacion)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvOperacion;
        private System.Windows.Forms.BindingSource bsOperacion;
        private System.Windows.Forms.ComboBox cboTipoAlmacen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.Button btCopiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desOperacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desDetalleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomSunat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indValorizarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indServicioDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn automaticoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indTransferenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indConsumoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indOrdentrabajoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCostoVenta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indDocumentoAutomaticoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indProveedorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indClienteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indOrdenCompraDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
    }
}