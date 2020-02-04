namespace ClienteWinForm.Ventas
{
    partial class frmCotizacion
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label43;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsCotizacion = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.idItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dscto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dscto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dscto3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFecModifica = new System.Windows.Forms.TextBox();
            this.txtFecRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSubTotal = new MyLabelG.LabelDegradado();
            this.lblDsct = new MyLabelG.LabelDegradado();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new MyLabelG.LabelDegradado();
            this.lblIsc = new MyLabelG.LabelDegradado();
            this.lblIgv = new MyLabelG.LabelDegradado();
            this.lblGravado = new MyLabelG.LabelDegradado();
            this.lblNoGravado = new MyLabelG.LabelDegradado();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPorIgv = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btEliminarItem = new System.Windows.Forms.Button();
            this.btNuevoItem = new System.Windows.Forms.Button();
            this.pnlExportacion = new System.Windows.Forms.Panel();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.pnlPrincipales = new System.Windows.Forms.Panel();
            this.txtIndicaciones = new ControlesWinForm.SuperTextBox();
            this.btSunat = new System.Windows.Forms.Button();
            this.txtIdAsociado = new ControlesWinForm.SuperTextBox();
            this.txtIdTransporte = new ControlesWinForm.SuperTextBox();
            this.btBuscarTransporte = new System.Windows.Forms.Button();
            this.txtIdTipCondicion = new ControlesWinForm.SuperTextBox();
            this.txtPuntoLlegada = new ControlesWinForm.SuperTextBox();
            this.txtIdSucursal = new System.Windows.Forms.TextBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.txtIdCondicion = new ControlesWinForm.SuperTextBox();
            this.btBuscarCondicion = new System.Windows.Forms.Button();
            this.txtDesCondicion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservacion = new ControlesWinForm.SuperTextBox();
            this.txtCodPedido = new ControlesWinForm.SuperTextBox();
            this.txtIdVendedor = new ControlesWinForm.SuperTextBox();
            this.txtIdCliente = new ControlesWinForm.SuperTextBox();
            this.cboEstablecimiento = new System.Windows.Forms.ComboBox();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.btBuscarVendedor = new System.Windows.Forms.Button();
            this.txtNroDocumentoVen = new ControlesWinForm.SuperTextBox();
            this.txtNombresVendedor = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.dtFecEmision = new System.Windows.Forms.DateTimePicker();
            this.txtRucCLiente = new ControlesWinForm.SuperTextBox();
            this.txtRazonCliente = new System.Windows.Forms.TextBox();
            this.txtRazonTransporte = new ControlesWinForm.SuperTextBox();
            this.txtRazonReferente = new System.Windows.Forms.TextBox();
            this.txtIdReferente = new ControlesWinForm.SuperTextBox();
            this.txtRucReferente = new ControlesWinForm.SuperTextBox();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotizacion)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.pnlExportacion.SuspendLayout();
            this.pnlPrincipales.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(8, 97);
            fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(8, 31);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(86, 13);
            label2.TabIndex = 0;
            label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 53);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 13);
            label3.TabIndex = 4;
            label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(8, 75);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 13);
            label4.TabIndex = 2;
            label4.Text = "Usuario Modificación";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label43.Location = new System.Drawing.Point(25, 30);
            label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(78, 13);
            label43.TabIndex = 0;
            label43.Text = "Nro. de Pedido";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(10, 157);
            label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(73, 13);
            label18.TabIndex = 329;
            label18.Text = "Plazo Entrega";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(595, 156);
            label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(79, 13);
            label16.TabIndex = 325;
            label16.Text = "Forma de Pago";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.Location = new System.Drawing.Point(596, 193);
            label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(80, 13);
            label15.TabIndex = 323;
            label15.Text = "Tipo de Compr.";
            label15.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(10, 29);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(80, 13);
            label10.TabIndex = 316;
            label10.Text = "Nro. Cotización";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(10, 72);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(31, 13);
            label9.TabIndex = 312;
            label9.Text = "Zona";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(295, 72);
            label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(96, 13);
            label12.TabIndex = 311;
            label12.Text = "Zona de Influencia";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(10, 51);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(53, 13);
            label8.TabIndex = 269;
            label8.Text = "Vendedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(299, 29);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(27, 13);
            label7.TabIndex = 265;
            label7.Text = "Tipo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(10, 136);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(79, 13);
            label6.TabIndex = 256;
            label6.Text = "Dirección Fiscal";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(435, 29);
            label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(45, 13);
            label21.TabIndex = 258;
            label21.Text = "Moneda";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(164, 29);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(36, 13);
            label20.TabIndex = 263;
            label20.Text = "Fecha";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(10, 115);
            label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(40, 13);
            label13.TabIndex = 20;
            label13.Text = "Cliente";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(10, 94);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 13);
            label5.TabIndex = 254;
            label5.Text = "Referente";
            // 
            // bsCotizacion
            // 
            this.bsCotizacion.DataSource = typeof(Entidades.Ventas.PedidoDetE);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.label26);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 192);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(1151, 211);
            this.pnlDetalle.TabIndex = 1596;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemDataGridViewTextBoxColumn,
            this.codArticulo,
            this.nomArticulo,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.subTotal,
            this.Isc,
            this.Igv,
            this.Dscto1,
            this.Dscto2,
            this.Dscto3,
            this.Total,
            this.Stock,
            this.Lote,
            this.dataGridViewTextBoxColumn1,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.FechaRegistro,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.FechaModificacion});
            this.dgvDetalle.DataSource = this.bsCotizacion;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 18);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(1149, 191);
            this.dgvDetalle.TabIndex = 104;
            this.dgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellDoubleClick);
            // 
            // idItemDataGridViewTextBoxColumn
            // 
            this.idItemDataGridViewTextBoxColumn.DataPropertyName = "idItem";
            this.idItemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.idItemDataGridViewTextBoxColumn.Name = "idItemDataGridViewTextBoxColumn";
            this.idItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codArticulo
            // 
            this.codArticulo.DataPropertyName = "codArticulo";
            this.codArticulo.HeaderText = "Cód.Articulo";
            this.codArticulo.Name = "codArticulo";
            this.codArticulo.ReadOnly = true;
            // 
            // nomArticulo
            // 
            this.nomArticulo.DataPropertyName = "nomArticulo";
            this.nomArticulo.HeaderText = "Articulo";
            this.nomArticulo.Name = "nomArticulo";
            this.nomArticulo.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precioUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotal
            // 
            this.subTotal.DataPropertyName = "subTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.subTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.subTotal.HeaderText = "SubTotal";
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            // 
            // Isc
            // 
            this.Isc.DataPropertyName = "Isc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Isc.DefaultCellStyle = dataGridViewCellStyle5;
            this.Isc.HeaderText = "ISC";
            this.Isc.Name = "Isc";
            this.Isc.ReadOnly = true;
            // 
            // Igv
            // 
            this.Igv.DataPropertyName = "Igv";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Igv.DefaultCellStyle = dataGridViewCellStyle6;
            this.Igv.HeaderText = "IGV";
            this.Igv.Name = "Igv";
            this.Igv.ReadOnly = true;
            // 
            // Dscto1
            // 
            this.Dscto1.DataPropertyName = "Dscto1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.Dscto1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dscto1.HeaderText = "Dscto.1";
            this.Dscto1.Name = "Dscto1";
            this.Dscto1.ReadOnly = true;
            // 
            // Dscto2
            // 
            this.Dscto2.DataPropertyName = "Dscto2";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Dscto2.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dscto2.HeaderText = "Dscto.2";
            this.Dscto2.Name = "Dscto2";
            this.Dscto2.ReadOnly = true;
            // 
            // Dscto3
            // 
            this.Dscto3.DataPropertyName = "Dscto3";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.Dscto3.DefaultCellStyle = dataGridViewCellStyle9;
            this.Dscto3.HeaderText = "Dscto.3";
            this.Dscto3.Name = "Dscto3";
            this.Dscto3.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle10;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.Stock.DefaultCellStyle = dataGridViewCellStyle11;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "LoteProveedor";
            this.Lote.HeaderText = "Lote Prov.";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Lote";
            this.dataGridViewTextBoxColumn1.HeaderText = "Lote";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaRegistro.DefaultCellStyle = dataGridViewCellStyle12;
            this.FechaRegistro.HeaderText = "Fecha Reg.";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaModificacion.DefaultCellStyle = dataGridViewCellStyle13;
            this.FechaModificacion.HeaderText = "Fecha Mod.";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label25);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFecModifica);
            this.pnlAuditoria.Controls.Add(this.txtFecRegistro);
            this.pnlAuditoria.Controls.Add(label2);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(897, 64);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(258, 125);
            this.pnlAuditoria.TabIndex = 1595;
            // 
            // txtFecModifica
            // 
            this.txtFecModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecModifica.Enabled = false;
            this.txtFecModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecModifica.Location = new System.Drawing.Point(117, 93);
            this.txtFecModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecModifica.Name = "txtFecModifica";
            this.txtFecModifica.Size = new System.Drawing.Size(133, 20);
            this.txtFecModifica.TabIndex = 0;
            this.txtFecModifica.TabStop = false;
            // 
            // txtFecRegistro
            // 
            this.txtFecRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecRegistro.Enabled = false;
            this.txtFecRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecRegistro.Location = new System.Drawing.Point(117, 49);
            this.txtFecRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecRegistro.Name = "txtFecRegistro";
            this.txtFecRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFecRegistro.TabIndex = 0;
            this.txtFecRegistro.TabStop = false;
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 27);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 71);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(675, 412);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 1613;
            this.label17.Text = "SubTotal";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubTotal.Location = new System.Drawing.Point(735, 407);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblSubTotal.Size = new System.Drawing.Size(84, 22);
            this.lblSubTotal.TabIndex = 1614;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDsct
            // 
            this.lblDsct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDsct.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblDsct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDsct.ForeColor = System.Drawing.Color.Black;
            this.lblDsct.Location = new System.Drawing.Point(735, 430);
            this.lblDsct.Name = "lblDsct";
            this.lblDsct.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblDsct.Size = new System.Drawing.Size(84, 22);
            this.lblDsct.TabIndex = 1612;
            this.lblDsct.Text = "0.00";
            this.lblDsct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(675, 435);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 1611;
            this.label14.Text = "Dscto.";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(1071, 453);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotal.Size = new System.Drawing.Size(84, 22);
            this.lblTotal.TabIndex = 1610;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIsc
            // 
            this.lblIsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIsc.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblIsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsc.ForeColor = System.Drawing.Color.Black;
            this.lblIsc.Location = new System.Drawing.Point(1071, 407);
            this.lblIsc.Name = "lblIsc";
            this.lblIsc.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIsc.Size = new System.Drawing.Size(84, 22);
            this.lblIsc.TabIndex = 1609;
            this.lblIsc.Text = "0.00";
            this.lblIsc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgv
            // 
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.ForeColor = System.Drawing.Color.Black;
            this.lblIgv.Location = new System.Drawing.Point(1071, 430);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIgv.Size = new System.Drawing.Size(84, 22);
            this.lblIgv.TabIndex = 1608;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGravado
            // 
            this.lblGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGravado.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravado.ForeColor = System.Drawing.Color.Black;
            this.lblGravado.Location = new System.Drawing.Point(933, 407);
            this.lblGravado.Name = "lblGravado";
            this.lblGravado.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblGravado.Size = new System.Drawing.Size(84, 22);
            this.lblGravado.TabIndex = 1607;
            this.lblGravado.Text = "0.00";
            this.lblGravado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNoGravado
            // 
            this.lblNoGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoGravado.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblNoGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoGravado.ForeColor = System.Drawing.Color.Black;
            this.lblNoGravado.Location = new System.Drawing.Point(933, 430);
            this.lblNoGravado.Name = "lblNoGravado";
            this.lblNoGravado.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblNoGravado.Size = new System.Drawing.Size(84, 22);
            this.lblNoGravado.TabIndex = 1606;
            this.lblNoGravado.Text = "0.00";
            this.lblNoGravado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(825, 435);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 1605;
            this.label19.Text = "Valor No Gravado";
            // 
            // lblPorIgv
            // 
            this.lblPorIgv.AutoSize = true;
            this.lblPorIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorIgv.Location = new System.Drawing.Point(1022, 435);
            this.lblPorIgv.Name = "lblPorIgv";
            this.lblPorIgv.Size = new System.Drawing.Size(25, 13);
            this.lblPorIgv.TabIndex = 1604;
            this.lblPorIgv.Text = "Igv";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(1022, 412);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 13);
            this.label22.TabIndex = 1603;
            this.label22.Text = "Isc";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(825, 412);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 13);
            this.label23.TabIndex = 1602;
            this.label23.Text = "Valor Gravado";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(1022, 458);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 13);
            this.label24.TabIndex = 1601;
            this.label24.Text = "TOTAL";
            // 
            // btEliminarItem
            // 
            this.btEliminarItem.BackColor = System.Drawing.Color.Azure;
            this.btEliminarItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEliminarItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminarItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarItem.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarItem.Location = new System.Drawing.Point(122, 409);
            this.btEliminarItem.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminarItem.Name = "btEliminarItem";
            this.btEliminarItem.Size = new System.Drawing.Size(113, 24);
            this.btEliminarItem.TabIndex = 1599;
            this.btEliminarItem.Text = "Eliminar Item";
            this.btEliminarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarItem.UseVisualStyleBackColor = false;
            this.btEliminarItem.Click += new System.EventHandler(this.btEliminarItem_Click);
            // 
            // btNuevoItem
            // 
            this.btNuevoItem.BackColor = System.Drawing.Color.Azure;
            this.btNuevoItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNuevoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btNuevoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNuevoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNuevoItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevoItem.Image = global::ClienteWinForm.Properties.Resources.plus;
            this.btNuevoItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevoItem.Location = new System.Drawing.Point(7, 409);
            this.btNuevoItem.Margin = new System.Windows.Forms.Padding(2);
            this.btNuevoItem.Name = "btNuevoItem";
            this.btNuevoItem.Size = new System.Drawing.Size(113, 24);
            this.btNuevoItem.TabIndex = 1600;
            this.btNuevoItem.Text = "Nuevo Item";
            this.btNuevoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNuevoItem.UseVisualStyleBackColor = false;
            this.btNuevoItem.Click += new System.EventHandler(this.btNuevoItem_Click);
            // 
            // pnlExportacion
            // 
            this.pnlExportacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExportacion.Controls.Add(this.label1);
            this.pnlExportacion.Controls.Add(this.txtNumFactura);
            this.pnlExportacion.Controls.Add(label43);
            this.pnlExportacion.Location = new System.Drawing.Point(897, 3);
            this.pnlExportacion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlExportacion.Name = "pnlExportacion";
            this.pnlExportacion.Size = new System.Drawing.Size(258, 57);
            this.pnlExportacion.TabIndex = 1597;
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNumFactura.Enabled = false;
            this.txtNumFactura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFactura.Location = new System.Drawing.Point(105, 26);
            this.txtNumFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(126, 20);
            this.txtNumFactura.TabIndex = 0;
            this.txtNumFactura.TabStop = false;
            // 
            // pnlPrincipales
            // 
            this.pnlPrincipales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipales.Controls.Add(this.lblLetras);
            this.pnlPrincipales.Controls.Add(this.txtIndicaciones);
            this.pnlPrincipales.Controls.Add(this.btSunat);
            this.pnlPrincipales.Controls.Add(this.txtIdAsociado);
            this.pnlPrincipales.Controls.Add(this.txtIdTransporte);
            this.pnlPrincipales.Controls.Add(this.btBuscarTransporte);
            this.pnlPrincipales.Controls.Add(this.txtIdTipCondicion);
            this.pnlPrincipales.Controls.Add(label18);
            this.pnlPrincipales.Controls.Add(this.txtPuntoLlegada);
            this.pnlPrincipales.Controls.Add(this.txtIdSucursal);
            this.pnlPrincipales.Controls.Add(this.cboFormaPago);
            this.pnlPrincipales.Controls.Add(label16);
            this.pnlPrincipales.Controls.Add(this.cboTipoComprobante);
            this.pnlPrincipales.Controls.Add(label15);
            this.pnlPrincipales.Controls.Add(this.txtIdCondicion);
            this.pnlPrincipales.Controls.Add(this.btBuscarCondicion);
            this.pnlPrincipales.Controls.Add(this.txtDesCondicion);
            this.pnlPrincipales.Controls.Add(this.label11);
            this.pnlPrincipales.Controls.Add(this.txtObservacion);
            this.pnlPrincipales.Controls.Add(this.txtCodPedido);
            this.pnlPrincipales.Controls.Add(label10);
            this.pnlPrincipales.Controls.Add(this.txtIdVendedor);
            this.pnlPrincipales.Controls.Add(this.txtIdCliente);
            this.pnlPrincipales.Controls.Add(this.cboEstablecimiento);
            this.pnlPrincipales.Controls.Add(label9);
            this.pnlPrincipales.Controls.Add(this.cboZona);
            this.pnlPrincipales.Controls.Add(label12);
            this.pnlPrincipales.Controls.Add(this.btBuscarVendedor);
            this.pnlPrincipales.Controls.Add(label8);
            this.pnlPrincipales.Controls.Add(this.txtNroDocumentoVen);
            this.pnlPrincipales.Controls.Add(this.txtNombresVendedor);
            this.pnlPrincipales.Controls.Add(this.cboTipo);
            this.pnlPrincipales.Controls.Add(label7);
            this.pnlPrincipales.Controls.Add(this.txtDireccion);
            this.pnlPrincipales.Controls.Add(label6);
            this.pnlPrincipales.Controls.Add(this.cboMonedas);
            this.pnlPrincipales.Controls.Add(label21);
            this.pnlPrincipales.Controls.Add(this.dtFecEmision);
            this.pnlPrincipales.Controls.Add(label20);
            this.pnlPrincipales.Controls.Add(this.txtRucCLiente);
            this.pnlPrincipales.Controls.Add(this.txtRazonCliente);
            this.pnlPrincipales.Controls.Add(label13);
            this.pnlPrincipales.Controls.Add(this.txtRazonTransporte);
            this.pnlPrincipales.Controls.Add(this.txtRazonReferente);
            this.pnlPrincipales.Controls.Add(this.txtIdReferente);
            this.pnlPrincipales.Controls.Add(this.txtRucReferente);
            this.pnlPrincipales.Controls.Add(label5);
            this.pnlPrincipales.Location = new System.Drawing.Point(4, 3);
            this.pnlPrincipales.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipales.Name = "pnlPrincipales";
            this.pnlPrincipales.Size = new System.Drawing.Size(890, 186);
            this.pnlPrincipales.TabIndex = 1598;
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtIndicaciones.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIndicaciones.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicaciones.Location = new System.Drawing.Point(594, 89);
            this.txtIndicaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtIndicaciones.Multiline = true;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(284, 39);
            this.txtIndicaciones.TabIndex = 15;
            this.txtIndicaciones.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIndicaciones.TextoVacio = "Email";
            // 
            // btSunat
            // 
            this.btSunat.BackColor = System.Drawing.Color.Azure;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Image = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btSunat.Location = new System.Drawing.Point(536, 112);
            this.btSunat.Margin = new System.Windows.Forms.Padding(2);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(51, 18);
            this.btSunat.TabIndex = 1582;
            this.btSunat.TabStop = false;
            this.btSunat.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSunat.UseVisualStyleBackColor = false;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // txtIdAsociado
            // 
            this.txtIdAsociado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdAsociado.BackColor = System.Drawing.Color.White;
            this.txtIdAsociado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdAsociado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAsociado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAsociado.Location = new System.Drawing.Point(69, 111);
            this.txtIdAsociado.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdAsociado.Name = "txtIdAsociado";
            this.txtIdAsociado.Size = new System.Drawing.Size(10, 20);
            this.txtIdAsociado.TabIndex = 1581;
            this.txtIdAsociado.TabStop = false;
            this.txtIdAsociado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdAsociado.TextoVacio = "<Descripcion>";
            this.txtIdAsociado.Visible = false;
            // 
            // txtIdTransporte
            // 
            this.txtIdTransporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdTransporte.BackColor = System.Drawing.Color.White;
            this.txtIdTransporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdTransporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdTransporte.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTransporte.Location = new System.Drawing.Point(589, 25);
            this.txtIdTransporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdTransporte.Name = "txtIdTransporte";
            this.txtIdTransporte.Size = new System.Drawing.Size(5, 20);
            this.txtIdTransporte.TabIndex = 1579;
            this.txtIdTransporte.TabStop = false;
            this.txtIdTransporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdTransporte.TextoVacio = "<Descripcion>";
            this.txtIdTransporte.Visible = false;
            // 
            // btBuscarTransporte
            // 
            this.btBuscarTransporte.BackColor = System.Drawing.Color.Azure;
            this.btBuscarTransporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarTransporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarTransporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarTransporte.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarTransporte.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarTransporte.Location = new System.Drawing.Point(855, 25);
            this.btBuscarTransporte.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscarTransporte.Name = "btBuscarTransporte";
            this.btBuscarTransporte.Size = new System.Drawing.Size(21, 20);
            this.btBuscarTransporte.TabIndex = 1578;
            this.btBuscarTransporte.TabStop = false;
            this.btBuscarTransporte.UseVisualStyleBackColor = false;
            this.btBuscarTransporte.Click += new System.EventHandler(this.btBuscarTransporte_Click);
            // 
            // txtIdTipCondicion
            // 
            this.txtIdTipCondicion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdTipCondicion.BackColor = System.Drawing.Color.White;
            this.txtIdTipCondicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdTipCondicion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdTipCondicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTipCondicion.Location = new System.Drawing.Point(647, 130);
            this.txtIdTipCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdTipCondicion.Name = "txtIdTipCondicion";
            this.txtIdTipCondicion.Size = new System.Drawing.Size(5, 20);
            this.txtIdTipCondicion.TabIndex = 330;
            this.txtIdTipCondicion.TabStop = false;
            this.txtIdTipCondicion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdTipCondicion.TextoVacio = "<Descripcion>";
            this.txtIdTipCondicion.Visible = false;
            // 
            // txtPuntoLlegada
            // 
            this.txtPuntoLlegada.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPuntoLlegada.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPuntoLlegada.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntoLlegada.Location = new System.Drawing.Point(92, 153);
            this.txtPuntoLlegada.Name = "txtPuntoLlegada";
            this.txtPuntoLlegada.Size = new System.Drawing.Size(495, 21);
            this.txtPuntoLlegada.TabIndex = 12;
            this.txtPuntoLlegada.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPuntoLlegada.TextoVacio = "";
            // 
            // txtIdSucursal
            // 
            this.txtIdSucursal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtIdSucursal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSucursal.Location = new System.Drawing.Point(85, 152);
            this.txtIdSucursal.Name = "txtIdSucursal";
            this.txtIdSucursal.ReadOnly = true;
            this.txtIdSucursal.Size = new System.Drawing.Size(5, 21);
            this.txtIdSucursal.TabIndex = 328;
            this.txtIdSucursal.TabStop = false;
            this.txtIdSucursal.Text = "00";
            this.txtIdSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdSucursal.Visible = false;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.DropDownWidth = 128;
            this.cboFormaPago.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(677, 152);
            this.cboFormaPago.Margin = new System.Windows.Forms.Padding(2);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(200, 21);
            this.cboFormaPago.TabIndex = 17;
            this.cboFormaPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboFormaPago_KeyPress);
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.DropDownWidth = 128;
            this.cboTipoComprobante.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(678, 189);
            this.cboTipoComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(200, 21);
            this.cboTipoComprobante.TabIndex = 18;
            this.cboTipoComprobante.Visible = false;
            this.cboTipoComprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipoComprobante_KeyPress);
            // 
            // txtIdCondicion
            // 
            this.txtIdCondicion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCondicion.BackColor = System.Drawing.Color.White;
            this.txtIdCondicion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCondicion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCondicion.Location = new System.Drawing.Point(652, 130);
            this.txtIdCondicion.Name = "txtIdCondicion";
            this.txtIdCondicion.Size = new System.Drawing.Size(24, 21);
            this.txtIdCondicion.TabIndex = 16;
            this.txtIdCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCondicion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdCondicion.TextoVacio = "<Descripcion>";
            this.txtIdCondicion.TextChanged += new System.EventHandler(this.txtIdCondicion_TextChanged);
            // 
            // btBuscarCondicion
            // 
            this.btBuscarCondicion.BackColor = System.Drawing.Color.Azure;
            this.btBuscarCondicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCondicion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarCondicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCondicion.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarCondicion.Location = new System.Drawing.Point(855, 131);
            this.btBuscarCondicion.Name = "btBuscarCondicion";
            this.btBuscarCondicion.Size = new System.Drawing.Size(22, 19);
            this.btBuscarCondicion.TabIndex = 319;
            this.btBuscarCondicion.TabStop = false;
            this.btBuscarCondicion.UseVisualStyleBackColor = false;
            this.btBuscarCondicion.Click += new System.EventHandler(this.btBuscarCondicion_Click);
            // 
            // txtDesCondicion
            // 
            this.txtDesCondicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesCondicion.Enabled = false;
            this.txtDesCondicion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCondicion.Location = new System.Drawing.Point(677, 130);
            this.txtDesCondicion.Name = "txtDesCondicion";
            this.txtDesCondicion.ReadOnly = true;
            this.txtDesCondicion.Size = new System.Drawing.Size(177, 21);
            this.txtDesCondicion.TabIndex = 321;
            this.txtDesCondicion.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(595, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 320;
            this.label11.Text = "Condición";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtObservacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtObservacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(593, 48);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(284, 39);
            this.txtObservacion.TabIndex = 14;
            this.txtObservacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtObservacion.TextoVacio = "Atención";
            // 
            // txtCodPedido
            // 
            this.txtCodPedido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCodPedido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodPedido.Enabled = false;
            this.txtCodPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPedido.Location = new System.Drawing.Point(92, 25);
            this.txtCodPedido.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodPedido.Name = "txtCodPedido";
            this.txtCodPedido.Size = new System.Drawing.Size(72, 20);
            this.txtCodPedido.TabIndex = 317;
            this.txtCodPedido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodPedido.TextoVacio = "<Descripcion>";
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdVendedor.BackColor = System.Drawing.Color.White;
            this.txtIdVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdVendedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdVendedor.Location = new System.Drawing.Point(81, 48);
            this.txtIdVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(10, 20);
            this.txtIdVendedor.TabIndex = 315;
            this.txtIdVendedor.TabStop = false;
            this.txtIdVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdVendedor.TextoVacio = "<Descripcion>";
            this.txtIdVendedor.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCliente.BackColor = System.Drawing.Color.White;
            this.txtIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(81, 111);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(10, 20);
            this.txtIdCliente.TabIndex = 313;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCliente.TextoVacio = "<Descripcion>";
            this.txtIdCliente.Visible = false;
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.DropDownWidth = 128;
            this.cboEstablecimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(92, 68);
            this.cboEstablecimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(193, 21);
            this.cboEstablecimiento.TabIndex = 6;
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
            this.cboZona.Location = new System.Drawing.Point(396, 68);
            this.cboZona.Margin = new System.Windows.Forms.Padding(2);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(193, 21);
            this.cboZona.TabIndex = 7;
            this.cboZona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboZona_KeyPress);
            // 
            // btBuscarVendedor
            // 
            this.btBuscarVendedor.BackColor = System.Drawing.Color.Azure;
            this.btBuscarVendedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarVendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarVendedor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarVendedor.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarVendedor.Location = new System.Drawing.Point(566, 47);
            this.btBuscarVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscarVendedor.Name = "btBuscarVendedor";
            this.btBuscarVendedor.Size = new System.Drawing.Size(22, 19);
            this.btBuscarVendedor.TabIndex = 266;
            this.btBuscarVendedor.TabStop = false;
            this.btBuscarVendedor.UseVisualStyleBackColor = false;
            this.btBuscarVendedor.Click += new System.EventHandler(this.btBuscarVendedor_Click);
            // 
            // txtNroDocumentoVen
            // 
            this.txtNroDocumentoVen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNroDocumentoVen.BackColor = System.Drawing.Color.White;
            this.txtNroDocumentoVen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroDocumentoVen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumentoVen.Location = new System.Drawing.Point(92, 47);
            this.txtNroDocumentoVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroDocumentoVen.Name = "txtNroDocumentoVen";
            this.txtNroDocumentoVen.Size = new System.Drawing.Size(72, 20);
            this.txtNroDocumentoVen.TabIndex = 4;
            this.txtNroDocumentoVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroDocumentoVen.TextoVacio = "<Descripcion>";
            this.txtNroDocumentoVen.TextChanged += new System.EventHandler(this.txtNroDocumentoVen_TextChanged);
            this.txtNroDocumentoVen.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroDocumentoVen_Validating);
            // 
            // txtNombresVendedor
            // 
            this.txtNombresVendedor.BackColor = System.Drawing.Color.White;
            this.txtNombresVendedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombresVendedor.Location = new System.Drawing.Point(165, 47);
            this.txtNombresVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombresVendedor.Name = "txtNombresVendedor";
            this.txtNombresVendedor.Size = new System.Drawing.Size(399, 20);
            this.txtNombresVendedor.TabIndex = 5;
            this.txtNombresVendedor.TextChanged += new System.EventHandler(this.txtNombresVendedor_TextChanged);
            this.txtNombresVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombresVendedor_KeyPress);
            this.txtNombresVendedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombresVendedor_Validating);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(328, 25);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(104, 21);
            this.cboTipo.TabIndex = 2;
            this.cboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipo_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDireccion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(92, 132);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(496, 20);
            this.txtDireccion.TabIndex = 257;
            this.txtDireccion.TabStop = false;
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(483, 25);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(105, 21);
            this.cboMonedas.TabIndex = 3;
            this.cboMonedas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMonedas_KeyPress);
            // 
            // dtFecEmision
            // 
            this.dtFecEmision.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecEmision.Location = new System.Drawing.Point(202, 25);
            this.dtFecEmision.Name = "dtFecEmision";
            this.dtFecEmision.Size = new System.Drawing.Size(94, 21);
            this.dtFecEmision.TabIndex = 1;
            this.dtFecEmision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFecEmision_KeyPress);
            // 
            // txtRucCLiente
            // 
            this.txtRucCLiente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucCLiente.BackColor = System.Drawing.Color.White;
            this.txtRucCLiente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucCLiente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucCLiente.Location = new System.Drawing.Point(92, 111);
            this.txtRucCLiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucCLiente.Name = "txtRucCLiente";
            this.txtRucCLiente.Size = new System.Drawing.Size(72, 20);
            this.txtRucCLiente.TabIndex = 10;
            this.txtRucCLiente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucCLiente.TextoVacio = "<Descripcion>";
            this.txtRucCLiente.TextChanged += new System.EventHandler(this.txtRucCLiente_TextChanged);
            this.txtRucCLiente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucCLiente_Validating);
            // 
            // txtRazonCliente
            // 
            this.txtRazonCliente.BackColor = System.Drawing.Color.White;
            this.txtRazonCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonCliente.Location = new System.Drawing.Point(165, 111);
            this.txtRazonCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonCliente.Name = "txtRazonCliente";
            this.txtRazonCliente.Size = new System.Drawing.Size(370, 20);
            this.txtRazonCliente.TabIndex = 11;
            this.txtRazonCliente.TextChanged += new System.EventHandler(this.txtRazonCliente_TextChanged);
            this.txtRazonCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonCliente_KeyPress);
            this.txtRazonCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonCliente_Validating);
            // 
            // txtRazonTransporte
            // 
            this.txtRazonTransporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonTransporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonTransporte.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonTransporte.Location = new System.Drawing.Point(594, 25);
            this.txtRazonTransporte.Name = "txtRazonTransporte";
            this.txtRazonTransporte.Size = new System.Drawing.Size(260, 21);
            this.txtRazonTransporte.TabIndex = 13;
            this.txtRazonTransporte.TabStop = false;
            this.txtRazonTransporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonTransporte.TextoVacio = "Empresa de Transporte";
            this.txtRazonTransporte.TextChanged += new System.EventHandler(this.txtRazonTransporte_TextChanged);
            // 
            // txtRazonReferente
            // 
            this.txtRazonReferente.BackColor = System.Drawing.Color.White;
            this.txtRazonReferente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonReferente.Location = new System.Drawing.Point(165, 90);
            this.txtRazonReferente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonReferente.Name = "txtRazonReferente";
            this.txtRazonReferente.Size = new System.Drawing.Size(423, 20);
            this.txtRazonReferente.TabIndex = 9;
            this.txtRazonReferente.TextChanged += new System.EventHandler(this.txtRazonReferente_TextChanged);
            this.txtRazonReferente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonReferente_KeyPress);
            this.txtRazonReferente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonReferente_Validating);
            // 
            // txtIdReferente
            // 
            this.txtIdReferente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdReferente.BackColor = System.Drawing.Color.White;
            this.txtIdReferente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdReferente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdReferente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdReferente.Location = new System.Drawing.Point(70, 90);
            this.txtIdReferente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdReferente.Name = "txtIdReferente";
            this.txtIdReferente.Size = new System.Drawing.Size(10, 20);
            this.txtIdReferente.TabIndex = 314;
            this.txtIdReferente.TabStop = false;
            this.txtIdReferente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdReferente.TextoVacio = "<Descripcion>";
            this.txtIdReferente.Visible = false;
            // 
            // txtRucReferente
            // 
            this.txtRucReferente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucReferente.BackColor = System.Drawing.Color.White;
            this.txtRucReferente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucReferente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucReferente.Location = new System.Drawing.Point(92, 90);
            this.txtRucReferente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucReferente.Name = "txtRucReferente";
            this.txtRucReferente.Size = new System.Drawing.Size(72, 20);
            this.txtRucReferente.TabIndex = 8;
            this.txtRucReferente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucReferente.TextoVacio = "<Descripcion>";
            this.txtRucReferente.TextChanged += new System.EventHandler(this.txtRucReferente_TextChanged);
            this.txtRucReferente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucReferente_Validating);
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(888, 18);
            this.lblLetras.TabIndex = 1583;
            this.lblLetras.Text = "Datos Principales";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 18);
            this.label1.TabIndex = 1572;
            this.label1.Text = "Documento Asociado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(256, 18);
            this.label25.TabIndex = 1572;
            this.label25.Text = "Auditoria";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label26.Dock = System.Windows.Forms.DockStyle.Top;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(1149, 18);
            this.label26.TabIndex = 1572;
            this.label26.Text = "Detalle de la Cotización";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 479);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblDsct);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIsc);
            this.Controls.Add(this.lblIgv);
            this.Controls.Add(this.lblGravado);
            this.Controls.Add(this.lblNoGravado);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblPorIgv);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btEliminarItem);
            this.Controls.Add(this.btNuevoItem);
            this.Controls.Add(this.pnlExportacion);
            this.Controls.Add(this.pnlPrincipales);
            this.Name = "frmCotizacion";
            this.Text = "Cotización (Nuevo)";
            this.Load += new System.EventHandler(this.frmCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCotizacion)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlExportacion.ResumeLayout(false);
            this.pnlExportacion.PerformLayout();
            this.pnlPrincipales.ResumeLayout(false);
            this.pnlPrincipales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dscto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dscto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dscto3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.BindingSource bsCotizacion;
        private System.Windows.Forms.Panel pnlDetalle;
        private ControlesWinForm.SuperTextBox txtIndicaciones;
        public ControlesWinForm.SuperTextBox txtIdAsociado;
        public ControlesWinForm.SuperTextBox txtIdTransporte;
        private System.Windows.Forms.Button btBuscarTransporte;
        public ControlesWinForm.SuperTextBox txtIdTipCondicion;
        private ControlesWinForm.SuperTextBox txtPuntoLlegada;
        private System.Windows.Forms.TextBox txtIdSucursal;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.TextBox txtFecModifica;
        private System.Windows.Forms.TextBox txtFecRegistro;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Button btSunat;
        private ControlesWinForm.SuperTextBox txtIdCondicion;
        private System.Windows.Forms.Button btBuscarCondicion;
        private System.Windows.Forms.TextBox txtDesCondicion;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtObservacion;
        public ControlesWinForm.SuperTextBox txtCodPedido;
        public ControlesWinForm.SuperTextBox txtIdVendedor;
        public ControlesWinForm.SuperTextBox txtIdCliente;
        private System.Windows.Forms.ComboBox cboEstablecimiento;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Button btBuscarVendedor;
        private ControlesWinForm.SuperTextBox txtNroDocumentoVen;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNombresVendedor;
        private MyLabelG.LabelDegradado lblSubTotal;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.DateTimePicker dtFecEmision;
        public ControlesWinForm.SuperTextBox txtRucCLiente;
        private System.Windows.Forms.TextBox txtRazonCliente;
        private ControlesWinForm.SuperTextBox txtRazonTransporte;
        private System.Windows.Forms.TextBox txtRazonReferente;
        public ControlesWinForm.SuperTextBox txtIdReferente;
        private ControlesWinForm.SuperTextBox txtRucReferente;
        private System.Windows.Forms.TextBox txtNumFactura;
        private MyLabelG.LabelDegradado lblDsct;
        private System.Windows.Forms.Label label14;
        private MyLabelG.LabelDegradado lblTotal;
        private MyLabelG.LabelDegradado lblIsc;
        private MyLabelG.LabelDegradado lblIgv;
        private MyLabelG.LabelDegradado lblGravado;
        private MyLabelG.LabelDegradado lblNoGravado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPorIgv;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btEliminarItem;
        private System.Windows.Forms.Button btNuevoItem;
        private System.Windows.Forms.Panel pnlExportacion;
        private System.Windows.Forms.Panel pnlPrincipales;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLetras;
    }
}