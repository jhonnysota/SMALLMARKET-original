namespace ClienteWinForm.Ventas
{
    partial class frmPuntoVentas
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
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.PnlCliente = new System.Windows.Forms.Panel();
            this.BtAgregarCliente = new System.Windows.Forms.Button();
            this.TxtDireccion = new ControlesWinForm.SuperTextBox();
            this.TxtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.TxtRuc = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblPedido = new System.Windows.Forms.Label();
            this.PnlDetalle = new System.Windows.Forms.Panel();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.idItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desUnidadMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porDscto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioConDscto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.BtAgregar = new System.Windows.Forms.Button();
            this.BtQuitar = new System.Windows.Forms.Button();
            this.BtCobrar = new System.Windows.Forms.Button();
            this.BtGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.lblSubTotal = new MyLabelG.LabelDegradado();
            this.label17 = new System.Windows.Forms.Label();
            this.lblDsct = new MyLabelG.LabelDegradado();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new MyLabelG.LabelDegradado();
            this.lblIgv = new MyLabelG.LabelDegradado();
            this.lblGravado = new MyLabelG.LabelDegradado();
            this.lblNoGravado = new MyLabelG.LabelDegradado();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPorIgv = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.LblTica = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtObtener = new System.Windows.Forms.Button();
            this.BtNuevo = new System.Windows.Forms.Button();
            this.BtImprimir = new System.Windows.Forms.Button();
            this.LblIdPedido = new System.Windows.Forms.Label();
            this.BtAnular = new System.Windows.Forms.Button();
            this.LblRedondeo = new MyLabelG.LabelDegradado();
            this.label4 = new System.Windows.Forms.Label();
            this.PnlCliente.SuspendLayout();
            this.PnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Bookman Old Style", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.labelDegradado1.SegundoColor = System.Drawing.Color.DodgerBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(1055, 33);
            this.labelDegradado1.TabIndex = 1631;
            this.labelDegradado1.Text = " PUNTO DE VENTA";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDegradado1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelDegradado1_MouseDown);
            // 
            // PnlCliente
            // 
            this.PnlCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlCliente.Controls.Add(this.BtAgregarCliente);
            this.PnlCliente.Controls.Add(this.TxtDireccion);
            this.PnlCliente.Controls.Add(this.TxtRazonSocial);
            this.PnlCliente.Controls.Add(this.TxtRuc);
            this.PnlCliente.Controls.Add(this.label1);
            this.PnlCliente.Location = new System.Drawing.Point(7, 65);
            this.PnlCliente.Name = "PnlCliente";
            this.PnlCliente.Size = new System.Drawing.Size(714, 86);
            this.PnlCliente.TabIndex = 1632;
            // 
            // BtAgregarCliente
            // 
            this.BtAgregarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAgregarCliente.BackgroundImage = global::ClienteWinForm.Properties.Resources.AgregarPersonas;
            this.BtAgregarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtAgregarCliente.Enabled = false;
            this.BtAgregarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAgregarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtAgregarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAgregarCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtAgregarCliente.Location = new System.Drawing.Point(668, 31);
            this.BtAgregarCliente.Name = "BtAgregarCliente";
            this.BtAgregarCliente.Size = new System.Drawing.Size(23, 21);
            this.BtAgregarCliente.TabIndex = 2097;
            this.BtAgregarCliente.TabStop = false;
            this.BtAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtAgregarCliente.UseVisualStyleBackColor = true;
            this.BtAgregarCliente.Click += new System.EventHandler(this.BtAgregarCliente_Click);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtDireccion.BackColor = System.Drawing.Color.White;
            this.TxtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtDireccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDireccion.Location = new System.Drawing.Point(21, 54);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(671, 21);
            this.TxtDireccion.TabIndex = 22;
            this.TxtDireccion.TabStop = false;
            this.TxtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtDireccion.TextoVacio = "DIRECCION";
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtRazonSocial.Enabled = false;
            this.TxtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRazonSocial.Location = new System.Drawing.Point(179, 31);
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(486, 21);
            this.TxtRazonSocial.TabIndex = 2;
            this.TxtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtRazonSocial.TextoVacio = "RAZON SOCIAL";
            this.TxtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRazonSocial_Validating);
            // 
            // TxtRuc
            // 
            this.TxtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtRuc.Enabled = false;
            this.TxtRuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRuc.Location = new System.Drawing.Point(21, 31);
            this.TxtRuc.Name = "TxtRuc";
            this.TxtRuc.Size = new System.Drawing.Size(155, 21);
            this.TxtRuc.TabIndex = 1;
            this.TxtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtRuc.TextoVacio = "RUC / DNI / CE";
            this.TxtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRuc_Validating);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(712, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPedido
            // 
            this.LblPedido.AutoSize = true;
            this.LblPedido.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPedido.Location = new System.Drawing.Point(8, 45);
            this.LblPedido.Name = "LblPedido";
            this.LblPedido.Size = new System.Drawing.Size(74, 16);
            this.LblPedido.TabIndex = 1633;
            this.LblPedido.Text = "N° PEDIDO";
            // 
            // PnlDetalle
            // 
            this.PnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDetalle.Controls.Add(this.DgvDetalle);
            this.PnlDetalle.Controls.Add(this.BtAgregar);
            this.PnlDetalle.Controls.Add(this.BtQuitar);
            this.PnlDetalle.Controls.Add(this.BtCobrar);
            this.PnlDetalle.Controls.Add(this.BtGuardar);
            this.PnlDetalle.Controls.Add(this.label2);
            this.PnlDetalle.Location = new System.Drawing.Point(7, 155);
            this.PnlDetalle.Name = "PnlDetalle";
            this.PnlDetalle.Size = new System.Drawing.Size(1042, 297);
            this.PnlDetalle.TabIndex = 1634;
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoGenerateColumns = false;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItem,
            this.codArticulo,
            this.nomArticulo,
            this.Cantidad,
            this.desUnidadMed,
            this.PrecioUnitario,
            this.porDscto1,
            this.PrecioConDscto,
            this.Total});
            this.DgvDetalle.DataSource = this.BsDetalle;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.EnableHeadersVisualStyles = false;
            this.DgvDetalle.Location = new System.Drawing.Point(0, 28);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.Size = new System.Drawing.Size(1040, 267);
            this.DgvDetalle.TabIndex = 1;
            this.DgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellClick);
            this.DgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellEndEdit);
            this.DgvDetalle.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellEnter);
            this.DgvDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvDetalle_DataError);
            this.DgvDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvDetalle_EditingControlShowing);
            this.DgvDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDetalle_KeyDown);
            this.DgvDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvDetalle_KeyPress);
            // 
            // idItem
            // 
            this.idItem.DataPropertyName = "idItem";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.idItem.HeaderText = "Item";
            this.idItem.Name = "idItem";
            this.idItem.ReadOnly = true;
            this.idItem.Width = 30;
            // 
            // codArticulo
            // 
            this.codArticulo.DataPropertyName = "codArticulo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codArticulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.codArticulo.HeaderText = "Cód. Articulo";
            this.codArticulo.Name = "codArticulo";
            this.codArticulo.ReadOnly = true;
            this.codArticulo.Width = 130;
            // 
            // nomArticulo
            // 
            this.nomArticulo.DataPropertyName = "nomArticulo";
            this.nomArticulo.HeaderText = "Descripción";
            this.nomArticulo.Name = "nomArticulo";
            this.nomArticulo.ReadOnly = true;
            this.nomArticulo.Width = 550;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "N2";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cant.";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 80;
            // 
            // desUnidadMed
            // 
            this.desUnidadMed.DataPropertyName = "desUnidadMed";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.desUnidadMed.DefaultCellStyle = dataGridViewCellStyle4;
            this.desUnidadMed.HeaderText = "U.Medida";
            this.desUnidadMed.Name = "desUnidadMed";
            this.desUnidadMed.ReadOnly = true;
            this.desUnidadMed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.desUnidadMed.Width = 120;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.DataPropertyName = "PrecioConImpuesto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle5;
            this.PrecioUnitario.HeaderText = "Precio Base";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Width = 90;
            // 
            // porDscto1
            // 
            this.porDscto1.DataPropertyName = "porDscto1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "N2";
            this.porDscto1.DefaultCellStyle = dataGridViewCellStyle6;
            this.porDscto1.HeaderText = "% Dscto.";
            this.porDscto1.Name = "porDscto1";
            this.porDscto1.Width = 90;
            // 
            // PrecioConDscto
            // 
            this.PrecioConDscto.DataPropertyName = "PrecioConDscto";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.PrecioConDscto.DefaultCellStyle = dataGridViewCellStyle7;
            this.PrecioConDscto.HeaderText = "P. con Dscto.";
            this.PrecioConDscto.Name = "PrecioConDscto";
            this.PrecioConDscto.Width = 90;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 95;
            // 
            // BsDetalle
            // 
            this.BsDetalle.DataSource = typeof(Entidades.Ventas.PedidoDetE);
            // 
            // BtAgregar
            // 
            this.BtAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAgregar.Enabled = false;
            this.BtAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.BtAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.BtAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAgregar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAgregar.ForeColor = System.Drawing.Color.Black;
            this.BtAgregar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.BtAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtAgregar.Location = new System.Drawing.Point(4, 1);
            this.BtAgregar.Name = "BtAgregar";
            this.BtAgregar.Size = new System.Drawing.Size(87, 25);
            this.BtAgregar.TabIndex = 2075;
            this.BtAgregar.TabStop = false;
            this.BtAgregar.Text = "Agregar";
            this.BtAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtAgregar.UseVisualStyleBackColor = false;
            this.BtAgregar.Click += new System.EventHandler(this.BtAgregar_Click);
            // 
            // BtQuitar
            // 
            this.BtQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtQuitar.Enabled = false;
            this.BtQuitar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.BtQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.BtQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtQuitar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtQuitar.ForeColor = System.Drawing.Color.Black;
            this.BtQuitar.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.BtQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtQuitar.Location = new System.Drawing.Point(94, 1);
            this.BtQuitar.Name = "BtQuitar";
            this.BtQuitar.Size = new System.Drawing.Size(87, 25);
            this.BtQuitar.TabIndex = 2076;
            this.BtQuitar.TabStop = false;
            this.BtQuitar.Text = "Quitar";
            this.BtQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtQuitar.UseVisualStyleBackColor = false;
            this.BtQuitar.Click += new System.EventHandler(this.BtQuitar_Click);
            // 
            // BtCobrar
            // 
            this.BtCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtCobrar.Enabled = false;
            this.BtCobrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.BtCobrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtCobrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.BtCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCobrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCobrar.ForeColor = System.Drawing.Color.Black;
            this.BtCobrar.Image = global::ClienteWinForm.Properties.Resources.MoneyCancelacion_16x16;
            this.BtCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtCobrar.Location = new System.Drawing.Point(274, 1);
            this.BtCobrar.Name = "BtCobrar";
            this.BtCobrar.Size = new System.Drawing.Size(87, 25);
            this.BtCobrar.TabIndex = 2095;
            this.BtCobrar.TabStop = false;
            this.BtCobrar.Text = "Cobrar";
            this.BtCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtCobrar.UseVisualStyleBackColor = false;
            this.BtCobrar.Click += new System.EventHandler(this.BtCobrar_Click);
            // 
            // BtGuardar
            // 
            this.BtGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.Enabled = false;
            this.BtGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.BtGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.BtGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGuardar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtGuardar.Image = global::ClienteWinForm.Properties.Resources.guardar_16x16neg;
            this.BtGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtGuardar.Location = new System.Drawing.Point(184, 1);
            this.BtGuardar.Name = "BtGuardar";
            this.BtGuardar.Size = new System.Drawing.Size(87, 25);
            this.BtGuardar.TabIndex = 2077;
            this.BtGuardar.TabStop = false;
            this.BtGuardar.Text = "Guardar";
            this.BtGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtGuardar.UseVisualStyleBackColor = false;
            this.BtGuardar.Click += new System.EventHandler(this.BtGuardar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1040, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "DETALLE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtpFecha.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.CustomFormat = "dd/MM/yyyy";
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFecha.Location = new System.Drawing.Point(881, 66);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(121, 22);
            this.DtpFecha.TabIndex = 1635;
            this.DtpFecha.TabStop = false;
            // 
            // pbMinimizar
            // 
            this.pbMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimizar.Image = global::ClienteWinForm.Properties.Resources.IconoMinimizar;
            this.pbMinimizar.Location = new System.Drawing.Point(995, 3);
            this.pbMinimizar.Name = "pbMinimizar";
            this.pbMinimizar.Size = new System.Drawing.Size(25, 25);
            this.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinimizar.TabIndex = 2074;
            this.pbMinimizar.TabStop = false;
            this.pbMinimizar.Click += new System.EventHandler(this.PbMinimizar_Click);
            // 
            // pbCerrar
            // 
            this.pbCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCerrar.BackColor = System.Drawing.Color.Transparent;
            this.pbCerrar.Image = global::ClienteWinForm.Properties.Resources.IconoCerrar;
            this.pbCerrar.Location = new System.Drawing.Point(1025, 3);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(25, 25);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCerrar.TabIndex = 2073;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.PbCerrar_Click);
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblSubTotal.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubTotal.Location = new System.Drawing.Point(250, 475);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblSubTotal.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblSubTotal.Size = new System.Drawing.Size(111, 24);
            this.lblSubTotal.TabIndex = 2091;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(250, 456);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 2090;
            this.label17.Text = "SubTotal";
            // 
            // lblDsct
            // 
            this.lblDsct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDsct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDsct.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblDsct.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDsct.ForeColor = System.Drawing.Color.Black;
            this.lblDsct.Location = new System.Drawing.Point(364, 475);
            this.lblDsct.Name = "lblDsct";
            this.lblDsct.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblDsct.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblDsct.Size = new System.Drawing.Size(111, 24);
            this.lblDsct.TabIndex = 2089;
            this.lblDsct.Text = "0.00";
            this.lblDsct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(364, 456);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 16);
            this.label14.TabIndex = 2088;
            this.label14.Text = "Dscto.";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(820, 475);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotal.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotal.Size = new System.Drawing.Size(111, 24);
            this.lblTotal.TabIndex = 2087;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgv
            // 
            this.lblIgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblIgv.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.ForeColor = System.Drawing.Color.Black;
            this.lblIgv.Location = new System.Drawing.Point(706, 475);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIgv.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIgv.Size = new System.Drawing.Size(111, 24);
            this.lblIgv.TabIndex = 2085;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGravado
            // 
            this.lblGravado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGravado.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblGravado.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravado.ForeColor = System.Drawing.Color.Black;
            this.lblGravado.Location = new System.Drawing.Point(478, 475);
            this.lblGravado.Name = "lblGravado";
            this.lblGravado.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblGravado.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblGravado.Size = new System.Drawing.Size(111, 24);
            this.lblGravado.TabIndex = 2084;
            this.lblGravado.Text = "0.00";
            this.lblGravado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNoGravado
            // 
            this.lblNoGravado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoGravado.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblNoGravado.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoGravado.ForeColor = System.Drawing.Color.Black;
            this.lblNoGravado.Location = new System.Drawing.Point(592, 475);
            this.lblNoGravado.Name = "lblNoGravado";
            this.lblNoGravado.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblNoGravado.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblNoGravado.Size = new System.Drawing.Size(111, 24);
            this.lblNoGravado.TabIndex = 2083;
            this.lblNoGravado.Text = "0.00";
            this.lblNoGravado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(592, 456);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 16);
            this.label19.TabIndex = 2082;
            this.label19.Text = "No Gravado";
            // 
            // lblPorIgv
            // 
            this.lblPorIgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorIgv.AutoSize = true;
            this.lblPorIgv.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorIgv.ForeColor = System.Drawing.Color.Black;
            this.lblPorIgv.Location = new System.Drawing.Point(706, 456);
            this.lblPorIgv.Name = "lblPorIgv";
            this.lblPorIgv.Size = new System.Drawing.Size(30, 16);
            this.lblPorIgv.TabIndex = 2081;
            this.lblPorIgv.Text = "IGV";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(478, 456);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 16);
            this.label23.TabIndex = 2079;
            this.label23.Text = "Gravado";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(820, 456);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 16);
            this.label24.TabIndex = 2078;
            this.label24.Text = "TOTAL";
            // 
            // LblTica
            // 
            this.LblTica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTica.AutoSize = true;
            this.LblTica.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTica.Location = new System.Drawing.Point(769, 69);
            this.LblTica.Name = "LblTica";
            this.LblTica.Size = new System.Drawing.Size(44, 16);
            this.LblTica.TabIndex = 2092;
            this.LblTica.Text = "0.000";
            this.LblTica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(729, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 2093;
            this.label3.Text = "T.C.";
            // 
            // BtObtener
            // 
            this.BtObtener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtObtener.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtObtener.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtObtener.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtObtener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtObtener.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtObtener.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.BtObtener.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtObtener.Location = new System.Drawing.Point(881, 93);
            this.BtObtener.Name = "BtObtener";
            this.BtObtener.Size = new System.Drawing.Size(149, 26);
            this.BtObtener.TabIndex = 2094;
            this.BtObtener.TabStop = false;
            this.BtObtener.Text = "Pedidos x Facturar";
            this.BtObtener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtObtener.UseVisualStyleBackColor = true;
            this.BtObtener.Click += new System.EventHandler(this.BtObtener_Click);
            // 
            // BtNuevo
            // 
            this.BtNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNuevo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtNuevo.Image = global::ClienteWinForm.Properties.Resources.add;
            this.BtNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtNuevo.Location = new System.Drawing.Point(729, 93);
            this.BtNuevo.Name = "BtNuevo";
            this.BtNuevo.Size = new System.Drawing.Size(149, 26);
            this.BtNuevo.TabIndex = 2096;
            this.BtNuevo.TabStop = false;
            this.BtNuevo.Text = "Nuevo Pedido";
            this.BtNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtNuevo.UseVisualStyleBackColor = true;
            this.BtNuevo.Click += new System.EventHandler(this.BtNuevo_Click);
            // 
            // BtImprimir
            // 
            this.BtImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtImprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtImprimir.Image = global::ClienteWinForm.Properties.Resources.ImpresoraAzul;
            this.BtImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtImprimir.Location = new System.Drawing.Point(881, 121);
            this.BtImprimir.Name = "BtImprimir";
            this.BtImprimir.Size = new System.Drawing.Size(149, 26);
            this.BtImprimir.TabIndex = 2097;
            this.BtImprimir.TabStop = false;
            this.BtImprimir.Text = "Reimprimir";
            this.BtImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtImprimir.UseVisualStyleBackColor = true;
            this.BtImprimir.Click += new System.EventHandler(this.BtImprimir_Click);
            // 
            // LblIdPedido
            // 
            this.LblIdPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblIdPedido.AutoSize = true;
            this.LblIdPedido.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdPedido.Location = new System.Drawing.Point(324, 45);
            this.LblIdPedido.Name = "LblIdPedido";
            this.LblIdPedido.Size = new System.Drawing.Size(27, 16);
            this.LblIdPedido.TabIndex = 2098;
            this.LblIdPedido.Text = "ID:";
            this.LblIdPedido.Visible = false;
            // 
            // BtAnular
            // 
            this.BtAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAnular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAnular.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtAnular.Image = global::ClienteWinForm.Properties.Resources.borrar_registro;
            this.BtAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtAnular.Location = new System.Drawing.Point(729, 121);
            this.BtAnular.Name = "BtAnular";
            this.BtAnular.Size = new System.Drawing.Size(149, 26);
            this.BtAnular.TabIndex = 2099;
            this.BtAnular.TabStop = false;
            this.BtAnular.Text = "Anular Documento";
            this.BtAnular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtAnular.UseVisualStyleBackColor = true;
            this.BtAnular.Click += new System.EventHandler(this.BtAnular_Click);
            // 
            // LblRedondeo
            // 
            this.LblRedondeo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRedondeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblRedondeo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.LblRedondeo.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRedondeo.ForeColor = System.Drawing.Color.Black;
            this.LblRedondeo.Location = new System.Drawing.Point(934, 475);
            this.LblRedondeo.Name = "LblRedondeo";
            this.LblRedondeo.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRedondeo.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRedondeo.Size = new System.Drawing.Size(111, 24);
            this.LblRedondeo.TabIndex = 2101;
            this.LblRedondeo.Text = "0.00";
            this.LblRedondeo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(934, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 2100;
            this.label4.Text = "Redondeo";
            // 
            // frmPuntoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1055, 503);
            this.Controls.Add(this.LblRedondeo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtAnular);
            this.Controls.Add(this.LblIdPedido);
            this.Controls.Add(this.BtImprimir);
            this.Controls.Add(this.BtNuevo);
            this.Controls.Add(this.BtObtener);
            this.Controls.Add(this.LblTica);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblDsct);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIgv);
            this.Controls.Add(this.lblGravado);
            this.Controls.Add(this.lblNoGravado);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblPorIgv);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.pbMinimizar);
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.PnlDetalle);
            this.Controls.Add(this.LblPedido);
            this.Controls.Add(this.PnlCliente);
            this.Controls.Add(this.labelDegradado1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPuntoVentas";
            this.Text = "Punto de Ventas";
            this.Load += new System.EventHandler(this.FrmPuntoVentas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPuntoVentas_KeyDown);
            this.PnlCliente.ResumeLayout(false);
            this.PnlCliente.PerformLayout();
            this.PnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel PnlCliente;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox TxtRuc;
        private ControlesWinForm.SuperTextBox TxtDireccion;
        private ControlesWinForm.SuperTextBox TxtRazonSocial;
        private System.Windows.Forms.Label LblPedido;
        private System.Windows.Forms.Panel PnlDetalle;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.BindingSource BsDetalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.Button BtQuitar;
        private System.Windows.Forms.Button BtAgregar;
        private System.Windows.Forms.Button BtGuardar;
        private MyLabelG.LabelDegradado lblSubTotal;
        private System.Windows.Forms.Label label17;
        private MyLabelG.LabelDegradado lblDsct;
        private System.Windows.Forms.Label label14;
        private MyLabelG.LabelDegradado lblTotal;
        private MyLabelG.LabelDegradado lblIgv;
        private MyLabelG.LabelDegradado lblGravado;
        private MyLabelG.LabelDegradado lblNoGravado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPorIgv;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label LblTica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtObtener;
        private System.Windows.Forms.Button BtCobrar;
        private System.Windows.Forms.Button BtNuevo;
        private System.Windows.Forms.Button BtImprimir;
        private System.Windows.Forms.Label LblIdPedido;
        private System.Windows.Forms.Button BtAnular;
        private MyLabelG.LabelDegradado LblRedondeo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtAgregarCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn desUnidadMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn porDscto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioConDscto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}