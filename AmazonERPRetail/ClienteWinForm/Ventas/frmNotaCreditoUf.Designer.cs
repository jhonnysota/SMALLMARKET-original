namespace ClienteWinForm.Ventas
{
    partial class frmNotaCreditoUf
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
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
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
            this.bsDetalleDocumento = new System.Windows.Forms.BindingSource(this.components);
            this.cboExoneracion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblPorIgv = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btEliminarItem = new System.Windows.Forms.Button();
            this.btServicios = new System.Windows.Forms.Button();
            this.btArticulos = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioSinImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroOt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroOtItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.btBuscarDireccion = new System.Windows.Forms.Button();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.cboEstablecimiento = new System.Windows.Forms.ComboBox();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdVendedor = new ControlesWinForm.SuperTextBox();
            this.btBuscarVendedor = new System.Windows.Forms.Button();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.pnlReferencia = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDesCondicionRef = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdCondicionRef = new ControlesWinForm.SuperTextBox();
            this.btBuscarComprobante = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesCondicion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btBuscarCondicion = new System.Windows.Forms.Button();
            this.txtIdCondicion = new ControlesWinForm.SuperTextBox();
            this.cboReferencia = new System.Windows.Forms.ComboBox();
            this.dtpFecReferencia = new System.Windows.Forms.DateTimePicker();
            this.txtNumDocumentoRef = new ControlesWinForm.SuperTextBox();
            this.txtSerieRef = new ControlesWinForm.SuperTextBox();
            this.btAgregarNota = new System.Windows.Forms.Button();
            this.txtGlosa = new ControlesWinForm.SuperTextBox();
            this.pnlComprobante = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cboEsGuia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTica = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumDocumento = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.dtFecEmision = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.pnlPedido = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNroAsociado = new ControlesWinForm.SuperTextBox();
            this.btPedidos = new System.Windows.Forms.Button();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalleDocumento)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlCliente.SuspendLayout();
            this.pnlReferencia.SuspendLayout();
            this.pnlComprobante.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(7, 48);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(31, 13);
            label20.TabIndex = 1609;
            label20.Text = "Zona";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(235, 48);
            label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(96, 13);
            label21.TabIndex = 1608;
            label21.Text = "Zona de Influencia";
            // 
            // bsDetalleDocumento
            // 
            this.bsDetalleDocumento.DataSource = typeof(Entidades.Ventas.EmisionDocumentoDetE);
            // 
            // cboExoneracion
            // 
            this.cboExoneracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExoneracion.DropDownWidth = 250;
            this.cboExoneracion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboExoneracion.FormattingEnabled = true;
            this.cboExoneracion.Location = new System.Drawing.Point(380, 129);
            this.cboExoneracion.Name = "cboExoneracion";
            this.cboExoneracion.Size = new System.Drawing.Size(259, 21);
            this.cboExoneracion.TabIndex = 1570;
            this.cboExoneracion.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 1571;
            this.label4.Text = "Raz.Exo.IGV";
            this.label4.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1048, 461);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 21);
            this.lblTotal.TabIndex = 366;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgv
            // 
            this.lblIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.Location = new System.Drawing.Point(967, 461);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(76, 21);
            this.lblIgv.TabIndex = 365;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(886, 461);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(76, 21);
            this.lblSubTotal.TabIndex = 364;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(888, 443);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 363;
            this.label17.Text = "SUBTOTAL";
            // 
            // lblPorIgv
            // 
            this.lblPorIgv.AutoSize = true;
            this.lblPorIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorIgv.Location = new System.Drawing.Point(966, 443);
            this.lblPorIgv.Name = "lblPorIgv";
            this.lblPorIgv.Size = new System.Drawing.Size(77, 13);
            this.lblPorIgv.TabIndex = 361;
            this.lblPorIgv.Text = "IGV 00.00 %";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1062, 443);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 362;
            this.label16.Text = "TOTAL";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.btEliminarItem);
            this.pnlDetalle.Controls.Add(this.btServicios);
            this.pnlDetalle.Controls.Add(this.btArticulos);
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 179);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(1127, 259);
            this.pnlDetalle.TabIndex = 500;
            // 
            // btEliminarItem
            // 
            this.btEliminarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btEliminarItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btEliminarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminarItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarItem.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarItem.Location = new System.Drawing.Point(180, 1);
            this.btEliminarItem.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminarItem.Name = "btEliminarItem";
            this.btEliminarItem.Size = new System.Drawing.Size(90, 21);
            this.btEliminarItem.TabIndex = 1603;
            this.btEliminarItem.Text = "Eliminar Item";
            this.btEliminarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarItem.UseVisualStyleBackColor = false;
            this.btEliminarItem.Click += new System.EventHandler(this.btEliminarItem_Click);
            // 
            // btServicios
            // 
            this.btServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btServicios.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btServicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btServicios.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btServicios.Location = new System.Drawing.Point(87, 1);
            this.btServicios.Name = "btServicios";
            this.btServicios.Size = new System.Drawing.Size(90, 21);
            this.btServicios.TabIndex = 1602;
            this.btServicios.TabStop = false;
            this.btServicios.Text = "Servicios";
            this.btServicios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btServicios.UseVisualStyleBackColor = false;
            this.btServicios.Click += new System.EventHandler(this.btServicios_Click);
            // 
            // btArticulos
            // 
            this.btArticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btArticulos.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btArticulos.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btArticulos.Location = new System.Drawing.Point(1, 1);
            this.btArticulos.Name = "btArticulos";
            this.btArticulos.Size = new System.Drawing.Size(83, 21);
            this.btArticulos.TabIndex = 1601;
            this.btArticulos.TabStop = false;
            this.btArticulos.Text = "Articulos";
            this.btArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btArticulos.UseVisualStyleBackColor = false;
            this.btArticulos.Click += new System.EventHandler(this.btArticulos_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.idArticuloDataGridViewTextBoxColumn,
            this.nomArticuloDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioSinImpuestoDataGridViewTextBoxColumn,
            this.subTotal,
            this.Igv,
            this.totalDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.nroOt,
            this.nroOtItem});
            this.dgvDetalle.DataSource = this.bsDetalleDocumento;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 23);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new System.Drawing.Size(1125, 234);
            this.dgvDetalle.TabIndex = 250;
            this.dgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellDoubleClick);
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 37;
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "codArticulo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idArticuloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "Cód.Art.";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            this.idArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.idArticuloDataGridViewTextBoxColumn.Width = 65;
            // 
            // nomArticuloDataGridViewTextBoxColumn
            // 
            this.nomArticuloDataGridViewTextBoxColumn.DataPropertyName = "nomArticulo";
            this.nomArticuloDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.nomArticuloDataGridViewTextBoxColumn.Name = "nomArticuloDataGridViewTextBoxColumn";
            this.nomArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomArticuloDataGridViewTextBoxColumn.Width = 500;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cant.";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 50;
            // 
            // precioSinImpuestoDataGridViewTextBoxColumn
            // 
            this.precioSinImpuestoDataGridViewTextBoxColumn.DataPropertyName = "PrecioSinImpuesto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.precioSinImpuestoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioSinImpuestoDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioSinImpuestoDataGridViewTextBoxColumn.Name = "precioSinImpuestoDataGridViewTextBoxColumn";
            this.precioSinImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioSinImpuestoDataGridViewTextBoxColumn.Width = 60;
            // 
            // subTotal
            // 
            this.subTotal.DataPropertyName = "subTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.subTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.subTotal.HeaderText = "Sub.Tot.";
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            this.subTotal.Width = 60;
            // 
            // Igv
            // 
            this.Igv.DataPropertyName = "Igv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.Igv.DefaultCellStyle = dataGridViewCellStyle5;
            this.Igv.HeaderText = "Igv";
            this.Igv.Name = "Igv";
            this.Igv.ReadOnly = true;
            this.Igv.Width = 60;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 60;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // nroOt
            // 
            this.nroOt.DataPropertyName = "nroOt";
            this.nroOt.HeaderText = "nroOt";
            this.nroOt.Name = "nroOt";
            this.nroOt.ReadOnly = true;
            this.nroOt.Visible = false;
            this.nroOt.Width = 80;
            // 
            // nroOtItem
            // 
            this.nroOtItem.DataPropertyName = "nroOtItem";
            this.nroOtItem.HeaderText = "nroOtItem";
            this.nroOtItem.Name = "nroOtItem";
            this.nroOtItem.ReadOnly = true;
            this.nroOtItem.Visible = false;
            this.nroOtItem.Width = 80;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1125, 23);
            this.lblRegistros.TabIndex = 1604;
            this.lblRegistros.Text = "Comprobante";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCliente
            // 
            this.pnlCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCliente.Controls.Add(this.label18);
            this.pnlCliente.Controls.Add(this.txtRazonSocial);
            this.pnlCliente.Controls.Add(this.txtDireccion);
            this.pnlCliente.Controls.Add(this.btBuscarDireccion);
            this.pnlCliente.Controls.Add(this.txtRuc);
            this.pnlCliente.Controls.Add(this.btBuscarCliente);
            this.pnlCliente.Location = new System.Drawing.Point(649, 3);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(481, 76);
            this.pnlCliente.TabIndex = 300;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(479, 18);
            this.label18.TabIndex = 347;
            this.label18.Text = "Cliente";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(124, 24);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(322, 20);
            this.txtRazonSocial.TabIndex = 302;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Razón Social";
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(10, 46);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(436, 20);
            this.txtDireccion.TabIndex = 303;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "Dirección";
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // btBuscarDireccion
            // 
            this.btBuscarDireccion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarDireccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarDireccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarDireccion.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarDireccion.Location = new System.Drawing.Point(449, 47);
            this.btBuscarDireccion.Name = "btBuscarDireccion";
            this.btBuscarDireccion.Size = new System.Drawing.Size(25, 19);
            this.btBuscarDireccion.TabIndex = 14;
            this.btBuscarDireccion.TabStop = false;
            this.btBuscarDireccion.UseVisualStyleBackColor = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRuc.BackColor = System.Drawing.Color.White;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(10, 24);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(113, 20);
            this.txtRuc.TabIndex = 301;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "RUC/DNI";
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCliente.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarCliente.Location = new System.Drawing.Point(449, 24);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(25, 19);
            this.btBuscarCliente.TabIndex = 13;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.DropDownWidth = 128;
            this.cboEstablecimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(59, 44);
            this.cboEstablecimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(174, 21);
            this.cboEstablecimiento.TabIndex = 1606;
            this.cboEstablecimiento.SelectionChangeCommitted += new System.EventHandler(this.cboEstablecimiento_SelectionChangeCommitted);
            this.cboEstablecimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboEstablecimiento_KeyPress);
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.DropDownWidth = 128;
            this.cboZona.Enabled = false;
            this.cboZona.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(333, 44);
            this.cboZona.Margin = new System.Windows.Forms.Padding(2);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(136, 21);
            this.cboZona.TabIndex = 1607;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 310;
            this.label8.Text = "Nombres";
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdVendedor.BackColor = System.Drawing.Color.White;
            this.txtIdVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdVendedor.Location = new System.Drawing.Point(59, 21);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(64, 20);
            this.txtIdVendedor.TabIndex = 304;
            this.txtIdVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdVendedor.TextoVacio = "<Descripcion>";
            // 
            // btBuscarVendedor
            // 
            this.btBuscarVendedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarVendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarVendedor.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarVendedor.Location = new System.Drawing.Point(444, 21);
            this.btBuscarVendedor.Name = "btBuscarVendedor";
            this.btBuscarVendedor.Size = new System.Drawing.Size(25, 19);
            this.btBuscarVendedor.TabIndex = 15;
            this.btBuscarVendedor.TabStop = false;
            this.btBuscarVendedor.UseVisualStyleBackColor = true;
            this.btBuscarVendedor.Click += new System.EventHandler(this.btBuscarVendedor_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtVendedor.Enabled = false;
            this.txtVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Location = new System.Drawing.Point(125, 21);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(316, 20);
            this.txtVendedor.TabIndex = 309;
            // 
            // pnlReferencia
            // 
            this.pnlReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReferencia.Controls.Add(this.label15);
            this.pnlReferencia.Controls.Add(this.txtDesCondicionRef);
            this.pnlReferencia.Controls.Add(this.label11);
            this.pnlReferencia.Controls.Add(this.txtIdCondicionRef);
            this.pnlReferencia.Controls.Add(this.btBuscarComprobante);
            this.pnlReferencia.Controls.Add(this.label10);
            this.pnlReferencia.Controls.Add(this.label9);
            this.pnlReferencia.Controls.Add(this.label3);
            this.pnlReferencia.Controls.Add(this.txtDesCondicion);
            this.pnlReferencia.Controls.Add(this.label13);
            this.pnlReferencia.Controls.Add(this.btBuscarCondicion);
            this.pnlReferencia.Controls.Add(this.txtIdCondicion);
            this.pnlReferencia.Controls.Add(this.cboReferencia);
            this.pnlReferencia.Controls.Add(this.dtpFecReferencia);
            this.pnlReferencia.Controls.Add(this.txtNumDocumentoRef);
            this.pnlReferencia.Controls.Add(this.txtSerieRef);
            this.pnlReferencia.Location = new System.Drawing.Point(311, 3);
            this.pnlReferencia.Name = "pnlReferencia";
            this.pnlReferencia.Size = new System.Drawing.Size(336, 122);
            this.pnlReferencia.TabIndex = 200;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(334, 18);
            this.label15.TabIndex = 349;
            this.label15.Text = "Referencia";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesCondicionRef
            // 
            this.txtDesCondicionRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesCondicionRef.Enabled = false;
            this.txtDesCondicionRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCondicionRef.Location = new System.Drawing.Point(94, 93);
            this.txtDesCondicionRef.Name = "txtDesCondicionRef";
            this.txtDesCondicionRef.ReadOnly = true;
            this.txtDesCondicionRef.Size = new System.Drawing.Size(233, 20);
            this.txtDesCondicionRef.TabIndex = 348;
            this.txtDesCondicionRef.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 347;
            this.label11.Text = "Cond. Ref.";
            // 
            // txtIdCondicionRef
            // 
            this.txtIdCondicionRef.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCondicionRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdCondicionRef.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCondicionRef.Enabled = false;
            this.txtIdCondicionRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCondicionRef.Location = new System.Drawing.Point(68, 93);
            this.txtIdCondicionRef.Name = "txtIdCondicionRef";
            this.txtIdCondicionRef.Size = new System.Drawing.Size(24, 20);
            this.txtIdCondicionRef.TabIndex = 346;
            this.txtIdCondicionRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCondicionRef.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdCondicionRef.TextoVacio = "<Descripcion>";
            // 
            // btBuscarComprobante
            // 
            this.btBuscarComprobante.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarComprobante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBuscarComprobante.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarComprobante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarComprobante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarComprobante.Location = new System.Drawing.Point(302, 47);
            this.btBuscarComprobante.Name = "btBuscarComprobante";
            this.btBuscarComprobante.Size = new System.Drawing.Size(25, 20);
            this.btBuscarComprobante.TabIndex = 345;
            this.btBuscarComprobante.TabStop = false;
            this.btBuscarComprobante.UseVisualStyleBackColor = true;
            this.btBuscarComprobante.Click += new System.EventHandler(this.btBuscarComprobante_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(203, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 344;
            this.label10.Text = "Fecha";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 343;
            this.label9.Text = "Número";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 342;
            this.label3.Text = "Tipo Docu.";
            // 
            // txtDesCondicion
            // 
            this.txtDesCondicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesCondicion.Enabled = false;
            this.txtDesCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCondicion.Location = new System.Drawing.Point(94, 24);
            this.txtDesCondicion.Name = "txtDesCondicion";
            this.txtDesCondicion.ReadOnly = true;
            this.txtDesCondicion.Size = new System.Drawing.Size(205, 20);
            this.txtDesCondicion.TabIndex = 317;
            this.txtDesCondicion.TabStop = false;
            this.txtDesCondicion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 314;
            this.label13.Text = "Condición";
            // 
            // btBuscarCondicion
            // 
            this.btBuscarCondicion.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarCondicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBuscarCondicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCondicion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarCondicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCondicion.Location = new System.Drawing.Point(302, 24);
            this.btBuscarCondicion.Name = "btBuscarCondicion";
            this.btBuscarCondicion.Size = new System.Drawing.Size(25, 20);
            this.btBuscarCondicion.TabIndex = 9;
            this.btBuscarCondicion.TabStop = false;
            this.btBuscarCondicion.UseVisualStyleBackColor = true;
            this.btBuscarCondicion.Click += new System.EventHandler(this.btBuscarCondicion_Click);
            // 
            // txtIdCondicion
            // 
            this.txtIdCondicion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCondicion.BackColor = System.Drawing.Color.White;
            this.txtIdCondicion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCondicion.Location = new System.Drawing.Point(68, 24);
            this.txtIdCondicion.Name = "txtIdCondicion";
            this.txtIdCondicion.Size = new System.Drawing.Size(24, 20);
            this.txtIdCondicion.TabIndex = 201;
            this.txtIdCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCondicion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdCondicion.TextoVacio = "<Descripcion>";
            this.txtIdCondicion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // cboReferencia
            // 
            this.cboReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReferencia.DropDownWidth = 200;
            this.cboReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReferencia.FormattingEnabled = true;
            this.cboReferencia.Location = new System.Drawing.Point(68, 47);
            this.cboReferencia.Name = "cboReferencia";
            this.cboReferencia.Size = new System.Drawing.Size(231, 21);
            this.cboReferencia.TabIndex = 202;
            this.cboReferencia.SelectionChangeCommitted += new System.EventHandler(this.cboReferencia_SelectionChangeCommitted);
            // 
            // dtpFecReferencia
            // 
            this.dtpFecReferencia.CustomFormat = "dd/MM/yyyy";
            this.dtpFecReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecReferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecReferencia.Location = new System.Drawing.Point(240, 70);
            this.dtpFecReferencia.Name = "dtpFecReferencia";
            this.dtpFecReferencia.Size = new System.Drawing.Size(87, 20);
            this.dtpFecReferencia.TabIndex = 205;
            this.dtpFecReferencia.ValueChanged += new System.EventHandler(this.dtpFecReferencia_ValueChanged);
            // 
            // txtNumDocumentoRef
            // 
            this.txtNumDocumentoRef.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDocumentoRef.ColorTextoVacio = System.Drawing.Color.Empty;
            this.txtNumDocumentoRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDocumentoRef.ForeColor = System.Drawing.Color.Black;
            this.txtNumDocumentoRef.Location = new System.Drawing.Point(112, 70);
            this.txtNumDocumentoRef.Name = "txtNumDocumentoRef";
            this.txtNumDocumentoRef.Size = new System.Drawing.Size(88, 20);
            this.txtNumDocumentoRef.TabIndex = 204;
            this.txtNumDocumentoRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumDocumentoRef.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumDocumentoRef.TextoVacio = "<Descripcion>";
            this.txtNumDocumentoRef.TextChanged += new System.EventHandler(this.txtNumDocumentoRef_TextChanged);
            this.txtNumDocumentoRef.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // txtSerieRef
            // 
            this.txtSerieRef.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerieRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieRef.ColorTextoVacio = System.Drawing.Color.Empty;
            this.txtSerieRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerieRef.ForeColor = System.Drawing.Color.Black;
            this.txtSerieRef.Location = new System.Drawing.Point(68, 70);
            this.txtSerieRef.Name = "txtSerieRef";
            this.txtSerieRef.Size = new System.Drawing.Size(42, 20);
            this.txtSerieRef.TabIndex = 203;
            this.txtSerieRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerieRef.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerieRef.TextoVacio = "<Descripcion>";
            this.txtSerieRef.TextChanged += new System.EventHandler(this.txtSerieRef_TextChanged);
            this.txtSerieRef.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // btAgregarNota
            // 
            this.btAgregarNota.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarNota.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btAgregarNota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAgregarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarNota.Image = global::ClienteWinForm.Properties.Resources.comment_edit;
            this.btAgregarNota.Location = new System.Drawing.Point(1103, 156);
            this.btAgregarNota.Name = "btAgregarNota";
            this.btAgregarNota.Size = new System.Drawing.Size(26, 19);
            this.btAgregarNota.TabIndex = 401;
            this.btAgregarNota.UseVisualStyleBackColor = true;
            this.btAgregarNota.Click += new System.EventHandler(this.btAgregarNota_Click);
            // 
            // txtGlosa
            // 
            this.txtGlosa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtGlosa.BackColor = System.Drawing.Color.White;
            this.txtGlosa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGlosa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGlosa.Location = new System.Drawing.Point(3, 155);
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(1127, 21);
            this.txtGlosa.TabIndex = 400;
            this.txtGlosa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGlosa.TextoVacio = "Ingrese Glosa  o  Descripción";
            this.txtGlosa.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // pnlComprobante
            // 
            this.pnlComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComprobante.Controls.Add(this.label12);
            this.pnlComprobante.Controls.Add(this.cboEsGuia);
            this.pnlComprobante.Controls.Add(this.label7);
            this.pnlComprobante.Controls.Add(this.cboMonedas);
            this.pnlComprobante.Controls.Add(this.label6);
            this.pnlComprobante.Controls.Add(this.txtTica);
            this.pnlComprobante.Controls.Add(this.label2);
            this.pnlComprobante.Controls.Add(this.txtNumDocumento);
            this.pnlComprobante.Controls.Add(this.label5);
            this.pnlComprobante.Controls.Add(this.cboSeries);
            this.pnlComprobante.Controls.Add(this.dtFecEmision);
            this.pnlComprobante.Controls.Add(this.label1);
            this.pnlComprobante.Controls.Add(this.cboTipoDocumento);
            this.pnlComprobante.Location = new System.Drawing.Point(3, 3);
            this.pnlComprobante.Name = "pnlComprobante";
            this.pnlComprobante.Size = new System.Drawing.Size(306, 96);
            this.pnlComprobante.TabIndex = 100;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(304, 18);
            this.label12.TabIndex = 347;
            this.label12.Text = "Comprobante";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboEsGuia
            // 
            this.cboEsGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEsGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEsGuia.FormattingEnabled = true;
            this.cboEsGuia.Items.AddRange(new object[] {
            "0001"});
            this.cboEsGuia.Location = new System.Drawing.Point(205, 23);
            this.cboEsGuia.Name = "cboEsGuia";
            this.cboEsGuia.Size = new System.Drawing.Size(88, 21);
            this.cboEsGuia.TabIndex = 309;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(203, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 308;
            this.label7.Text = "Moneda";
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.ForeColor = System.Drawing.Color.Black;
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(249, 46);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(44, 21);
            this.cboMonedas.TabIndex = 104;
            this.cboMonedas.SelectionChangeCommitted += new System.EventHandler(this.cboMonedas_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(183, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 307;
            this.label6.Text = "Tipo Cambio";
            // 
            // txtTica
            // 
            this.txtTica.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTica.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTica.Location = new System.Drawing.Point(249, 68);
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(44, 20);
            this.txtTica.TabIndex = 306;
            this.txtTica.TabStop = false;
            this.txtTica.Text = "0.000";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTica.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTica.TextoVacio = "<Descripcion>";
            this.txtTica.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 301;
            this.label2.Text = "N° Doc.";
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDocumento.ForeColor = System.Drawing.Color.Blue;
            this.txtNumDocumento.Location = new System.Drawing.Point(120, 46);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(81, 20);
            this.txtNumDocumento.TabIndex = 103;
            this.txtNumDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtNumDocumento.TextoVacio = "<Descripcion>";
            this.txtNumDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDocumentoRef_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 304;
            this.label5.Text = "Fec.Emis.";
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.ForeColor = System.Drawing.Color.Blue;
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Items.AddRange(new object[] {
            "0001"});
            this.cboSeries.Location = new System.Drawing.Point(60, 46);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(57, 21);
            this.cboSeries.TabIndex = 102;
            this.cboSeries.SelectionChangeCommitted += new System.EventHandler(this.cboSeries_SelectionChangeCommitted);
            // 
            // dtFecEmision
            // 
            this.dtFecEmision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecEmision.Location = new System.Drawing.Point(60, 68);
            this.dtFecEmision.Name = "dtFecEmision";
            this.dtFecEmision.Size = new System.Drawing.Size(101, 20);
            this.dtFecEmision.TabIndex = 105;
            this.dtFecEmision.ValueChanged += new System.EventHandler(this.dtFecEmision_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 298;
            this.label1.Text = "Tipo";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(60, 23);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(141, 21);
            this.cboTipoDocumento.TabIndex = 101;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.cboEstablecimiento);
            this.panel1.Controls.Add(this.txtIdVendedor);
            this.panel1.Controls.Add(this.txtVendedor);
            this.panel1.Controls.Add(label20);
            this.panel1.Controls.Add(this.btBuscarVendedor);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboZona);
            this.panel1.Controls.Add(label21);
            this.panel1.Location = new System.Drawing.Point(649, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 71);
            this.panel1.TabIndex = 1610;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(479, 18);
            this.label19.TabIndex = 1610;
            this.label19.Text = "Vendendor";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPedido
            // 
            this.pnlPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPedido.Controls.Add(this.label14);
            this.pnlPedido.Controls.Add(this.txtNroAsociado);
            this.pnlPedido.Controls.Add(this.btPedidos);
            this.pnlPedido.Location = new System.Drawing.Point(3, 101);
            this.pnlPedido.Name = "pnlPedido";
            this.pnlPedido.Size = new System.Drawing.Size(306, 51);
            this.pnlPedido.TabIndex = 1611;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(304, 18);
            this.label14.TabIndex = 1610;
            this.label14.Text = "Nro. Pedido";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNroAsociado
            // 
            this.txtNroAsociado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNroAsociado.BackColor = System.Drawing.Color.White;
            this.txtNroAsociado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroAsociado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroAsociado.Location = new System.Drawing.Point(69, 22);
            this.txtNroAsociado.MaxLength = 11;
            this.txtNroAsociado.Name = "txtNroAsociado";
            this.txtNroAsociado.Size = new System.Drawing.Size(132, 20);
            this.txtNroAsociado.TabIndex = 1609;
            this.txtNroAsociado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroAsociado.TextoVacio = "";
            // 
            // btPedidos
            // 
            this.btPedidos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPedidos.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btPedidos.Location = new System.Drawing.Point(205, 22);
            this.btPedidos.Name = "btPedidos";
            this.btPedidos.Size = new System.Drawing.Size(26, 19);
            this.btPedidos.TabIndex = 1608;
            this.btPedidos.TabStop = false;
            this.btPedidos.UseVisualStyleBackColor = true;
            this.btPedidos.Click += new System.EventHandler(this.btPedidos_Click);
            // 
            // frmNotaCreditoUf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 486);
            this.Controls.Add(this.pnlPedido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboExoneracion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIgv);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblPorIgv);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlCliente);
            this.Controls.Add(this.pnlReferencia);
            this.Controls.Add(this.btAgregarNota);
            this.Controls.Add(this.txtGlosa);
            this.Controls.Add(this.pnlComprobante);
            this.Name = "frmNotaCreditoUf";
            this.Text = "Nota de Crédito";
            this.Load += new System.EventHandler(this.frmNotaCreditoUf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalleDocumento)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            this.pnlReferencia.ResumeLayout(false);
            this.pnlReferencia.PerformLayout();
            this.pnlComprobante.ResumeLayout(false);
            this.pnlComprobante.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPedido.ResumeLayout(false);
            this.pnlPedido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblPorIgv;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtIdVendedor;
        private System.Windows.Forms.Button btBuscarVendedor;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Button btBuscarDireccion;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.Panel pnlReferencia;
        private System.Windows.Forms.Button btBuscarComprobante;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesCondicion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btBuscarCondicion;
        private ControlesWinForm.SuperTextBox txtIdCondicion;
        private System.Windows.Forms.ComboBox cboReferencia;
        private System.Windows.Forms.DateTimePicker dtpFecReferencia;
        private ControlesWinForm.SuperTextBox txtNumDocumentoRef;
        private ControlesWinForm.SuperTextBox txtSerieRef;
        private System.Windows.Forms.Button btAgregarNota;
        private ControlesWinForm.SuperTextBox txtGlosa;
        private System.Windows.Forms.Panel pnlComprobante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtTica;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtNumDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.DateTimePicker dtFecEmision;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.BindingSource bsDetalleDocumento;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private ControlesWinForm.SuperTextBox txtRuc;
        public System.Windows.Forms.ComboBox cboExoneracion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboEsGuia;
        private System.Windows.Forms.TextBox txtDesCondicionRef;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtIdCondicionRef;
        private System.Windows.Forms.ComboBox cboEstablecimiento;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Button btEliminarItem;
        private System.Windows.Forms.Button btServicios;
        private System.Windows.Forms.Button btArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioSinImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroOt;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroOtItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlPedido;
        private ControlesWinForm.SuperTextBox txtNroAsociado;
        private System.Windows.Forms.Button btPedidos;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
    }
}