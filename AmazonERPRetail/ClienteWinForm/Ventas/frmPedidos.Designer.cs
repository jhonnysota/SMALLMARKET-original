namespace ClienteWinForm.Ventas
{
    partial class frmPedidos
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
            System.Windows.Forms.Label label43;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label tipo_detraccionLabel;
            System.Windows.Forms.Label tasa_detraccionLabel;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSubTotal = new MyLabelG.LabelDegradado();
            this.label17 = new System.Windows.Forms.Label();
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
            this.label26 = new System.Windows.Forms.Label();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.txtNumGuia = new System.Windows.Forms.TextBox();
            this.txtDesCondicion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btBuscarCondicion = new System.Windows.Forms.Button();
            this.txtIdCondicion = new ControlesWinForm.SuperTextBox();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.pnlPrincipales = new System.Windows.Forms.Panel();
            this.cboListaPrecio = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DtpFecEntrega = new System.Windows.Forms.DateTimePicker();
            this.TxtEstado = new ControlesWinForm.SuperTextBox();
            this.btSunat = new System.Windows.Forms.Button();
            this.txtNombresVendedor = new System.Windows.Forms.TextBox();
            this.btBuscarVendedor = new System.Windows.Forms.Button();
            this.txtNroDocumentoVen = new ControlesWinForm.SuperTextBox();
            this.txtPuntoLlegada = new ControlesWinForm.SuperTextBox();
            this.btBuscarDireccion = new System.Windows.Forms.Button();
            this.TxtObservacion = new ControlesWinForm.SuperTextBox();
            this.txtCodPedido = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.dtFecEmision = new System.Windows.Forms.DateTimePicker();
            this.txtRucCLiente = new ControlesWinForm.SuperTextBox();
            this.txtRazonCliente = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.idItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dscto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPedido = new System.Windows.Forms.BindingSource(this.components);
            this.label28 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFecModifica = new System.Windows.Forms.TextBox();
            this.txtFecRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.pnlDetraccion = new System.Windows.Forms.Panel();
            this.txtTipoCalculo = new ControlesWinForm.SuperTextBox();
            this.lblCaptionDetra = new System.Windows.Forms.Label();
            this.chkDetraccion = new System.Windows.Forms.CheckBox();
            this.txtMontoDetraS = new ControlesWinForm.SuperTextBox();
            this.cboTipoDetraccion = new System.Windows.Forms.ComboBox();
            this.txtTasaDetra = new ControlesWinForm.SuperTextBox();
            this.label25 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            tipo_detraccionLabel = new System.Windows.Forms.Label();
            tasa_detraccionLabel = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            this.pnlExportacion.SuspendLayout();
            this.pnlPrincipales.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPedido)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDetraccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(322, 50);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 252;
            label1.Text = "Nro. Guia";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label43.Location = new System.Drawing.Point(322, 28);
            label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(68, 13);
            label43.TabIndex = 0;
            label43.Text = "Nro. Factura";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(15, 97);
            label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(77, 13);
            label18.TabIndex = 329;
            label18.Text = "Dirección Entr.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.Location = new System.Drawing.Point(11, 50);
            label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(76, 13);
            label15.TabIndex = 323;
            label15.Text = "Tipo Comprob.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(15, 30);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(63, 13);
            label10.TabIndex = 316;
            label10.Text = "Nro. Pedido";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(15, 119);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(53, 13);
            label8.TabIndex = 269;
            label8.Text = "Vendedor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(15, 75);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(82, 13);
            label6.TabIndex = 256;
            label6.Text = "Dirección Fiscal";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(470, 30);
            label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(46, 13);
            label21.TabIndex = 258;
            label21.Text = "Moneda";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(191, 30);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(37, 13);
            label20.TabIndex = 263;
            label20.Text = "Fecha";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(15, 54);
            label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(39, 13);
            label13.TabIndex = 20;
            label13.Text = "Cliente";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(8, 99);
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
            label2.Location = new System.Drawing.Point(8, 33);
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
            label3.Location = new System.Drawing.Point(8, 55);
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
            label4.Location = new System.Drawing.Point(8, 77);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 13);
            label4.TabIndex = 2;
            label4.Text = "Usuario Modificación";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(327, 30);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(40, 13);
            label5.TabIndex = 1583;
            label5.Text = "Estado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(627, 97);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 13);
            label7.TabIndex = 1586;
            label7.Text = "Fec.Entrega";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.Location = new System.Drawing.Point(463, 37);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(31, 13);
            label27.TabIndex = 310;
            label27.Text = "Calc.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(325, 37);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(16, 13);
            label9.TabIndex = 307;
            label9.Text = "%";
            // 
            // tipo_detraccionLabel
            // 
            tipo_detraccionLabel.AutoSize = true;
            tipo_detraccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipo_detraccionLabel.Location = new System.Drawing.Point(7, 37);
            tipo_detraccionLabel.Name = "tipo_detraccionLabel";
            tipo_detraccionLabel.Size = new System.Drawing.Size(28, 13);
            tipo_detraccionLabel.TabIndex = 83;
            tipo_detraccionLabel.Text = "Tipo";
            // 
            // tasa_detraccionLabel
            // 
            tasa_detraccionLabel.AutoSize = true;
            tasa_detraccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tasa_detraccionLabel.Location = new System.Drawing.Point(258, 37);
            tasa_detraccionLabel.Name = "tasa_detraccionLabel";
            tasa_detraccionLabel.Size = new System.Drawing.Size(31, 13);
            tasa_detraccionLabel.TabIndex = 79;
            tasa_detraccionLabel.Text = "Tasa";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(615, 30);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(61, 13);
            label29.TabIndex = 1601;
            label29.Text = "Lista Precio";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubTotal.Location = new System.Drawing.Point(662, 487);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblSubTotal.Size = new System.Drawing.Size(84, 22);
            this.lblSubTotal.TabIndex = 1592;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(602, 492);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 1591;
            this.label17.Text = "SubTotal";
            // 
            // lblDsct
            // 
            this.lblDsct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDsct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDsct.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblDsct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDsct.ForeColor = System.Drawing.Color.Black;
            this.lblDsct.Location = new System.Drawing.Point(662, 510);
            this.lblDsct.Name = "lblDsct";
            this.lblDsct.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblDsct.Size = new System.Drawing.Size(84, 22);
            this.lblDsct.TabIndex = 1588;
            this.lblDsct.Text = "0.00";
            this.lblDsct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(602, 515);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 1587;
            this.label14.Text = "Dscto.";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(998, 533);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotal.Size = new System.Drawing.Size(84, 22);
            this.lblTotal.TabIndex = 1584;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIsc
            // 
            this.lblIsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIsc.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblIsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsc.ForeColor = System.Drawing.Color.Black;
            this.lblIsc.Location = new System.Drawing.Point(998, 487);
            this.lblIsc.Name = "lblIsc";
            this.lblIsc.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIsc.Size = new System.Drawing.Size(84, 22);
            this.lblIsc.TabIndex = 1583;
            this.lblIsc.Text = "0.00";
            this.lblIsc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgv
            // 
            this.lblIgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgv.ForeColor = System.Drawing.Color.Black;
            this.lblIgv.Location = new System.Drawing.Point(998, 510);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblIgv.Size = new System.Drawing.Size(84, 22);
            this.lblIgv.TabIndex = 1582;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGravado
            // 
            this.lblGravado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGravado.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravado.ForeColor = System.Drawing.Color.Black;
            this.lblGravado.Location = new System.Drawing.Point(860, 487);
            this.lblGravado.Name = "lblGravado";
            this.lblGravado.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblGravado.Size = new System.Drawing.Size(84, 22);
            this.lblGravado.TabIndex = 1581;
            this.lblGravado.Text = "0.00";
            this.lblGravado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNoGravado
            // 
            this.lblNoGravado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoGravado.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblNoGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoGravado.ForeColor = System.Drawing.Color.Black;
            this.lblNoGravado.Location = new System.Drawing.Point(860, 510);
            this.lblNoGravado.Name = "lblNoGravado";
            this.lblNoGravado.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblNoGravado.Size = new System.Drawing.Size(84, 22);
            this.lblNoGravado.TabIndex = 1580;
            this.lblNoGravado.Text = "0.00";
            this.lblNoGravado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(752, 515);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 1579;
            this.label19.Text = "Valor No Gravado";
            // 
            // lblPorIgv
            // 
            this.lblPorIgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorIgv.AutoSize = true;
            this.lblPorIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorIgv.Location = new System.Drawing.Point(949, 515);
            this.lblPorIgv.Name = "lblPorIgv";
            this.lblPorIgv.Size = new System.Drawing.Size(25, 13);
            this.lblPorIgv.TabIndex = 1578;
            this.lblPorIgv.Text = "Igv";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(949, 492);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 13);
            this.label22.TabIndex = 1577;
            this.label22.Text = "Isc";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(752, 492);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 13);
            this.label23.TabIndex = 1576;
            this.label23.Text = "Valor Gravado";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(949, 538);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 13);
            this.label24.TabIndex = 1575;
            this.label24.Text = "TOTAL";
            // 
            // btEliminarItem
            // 
            this.btEliminarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEliminarItem.BackColor = System.Drawing.Color.Azure;
            this.btEliminarItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEliminarItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminarItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarItem.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarItem.Location = new System.Drawing.Point(122, 489);
            this.btEliminarItem.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminarItem.Name = "btEliminarItem";
            this.btEliminarItem.Size = new System.Drawing.Size(113, 26);
            this.btEliminarItem.TabIndex = 357;
            this.btEliminarItem.TabStop = false;
            this.btEliminarItem.Text = "Eliminar Item";
            this.btEliminarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarItem.UseVisualStyleBackColor = false;
            this.btEliminarItem.Click += new System.EventHandler(this.btEliminarItem_Click);
            // 
            // btNuevoItem
            // 
            this.btNuevoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNuevoItem.BackColor = System.Drawing.Color.Azure;
            this.btNuevoItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNuevoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btNuevoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNuevoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNuevoItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevoItem.Image = global::ClienteWinForm.Properties.Resources.plus;
            this.btNuevoItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevoItem.Location = new System.Drawing.Point(7, 489);
            this.btNuevoItem.Margin = new System.Windows.Forms.Padding(2);
            this.btNuevoItem.Name = "btNuevoItem";
            this.btNuevoItem.Size = new System.Drawing.Size(113, 26);
            this.btNuevoItem.TabIndex = 358;
            this.btNuevoItem.TabStop = false;
            this.btNuevoItem.Text = "Nuevo Item";
            this.btNuevoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNuevoItem.UseVisualStyleBackColor = false;
            this.btNuevoItem.Click += new System.EventHandler(this.btNuevoItem_Click);
            // 
            // pnlExportacion
            // 
            this.pnlExportacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExportacion.Controls.Add(this.label26);
            this.pnlExportacion.Controls.Add(label1);
            this.pnlExportacion.Controls.Add(this.txtNumFactura);
            this.pnlExportacion.Controls.Add(label43);
            this.pnlExportacion.Controls.Add(this.txtNumGuia);
            this.pnlExportacion.Controls.Add(this.txtDesCondicion);
            this.pnlExportacion.Controls.Add(this.label11);
            this.pnlExportacion.Controls.Add(this.btBuscarCondicion);
            this.pnlExportacion.Controls.Add(this.txtIdCondicion);
            this.pnlExportacion.Controls.Add(this.cboTipoComprobante);
            this.pnlExportacion.Controls.Add(label15);
            this.pnlExportacion.Location = new System.Drawing.Point(3, 187);
            this.pnlExportacion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlExportacion.Name = "pnlExportacion";
            this.pnlExportacion.Size = new System.Drawing.Size(538, 75);
            this.pnlExportacion.TabIndex = 259;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label26.Dock = System.Windows.Forms.DockStyle.Top;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(536, 18);
            this.label26.TabIndex = 346;
            this.label26.Text = "Facturación";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNumFactura.Enabled = false;
            this.txtNumFactura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFactura.Location = new System.Drawing.Point(393, 24);
            this.txtNumFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(126, 20);
            this.txtNumFactura.TabIndex = 0;
            this.txtNumFactura.TabStop = false;
            // 
            // txtNumGuia
            // 
            this.txtNumGuia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNumGuia.Enabled = false;
            this.txtNumGuia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumGuia.Location = new System.Drawing.Point(393, 46);
            this.txtNumGuia.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumGuia.Name = "txtNumGuia";
            this.txtNumGuia.Size = new System.Drawing.Size(126, 20);
            this.txtNumGuia.TabIndex = 0;
            this.txtNumGuia.TabStop = false;
            // 
            // txtDesCondicion
            // 
            this.txtDesCondicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesCondicion.Enabled = false;
            this.txtDesCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCondicion.Location = new System.Drawing.Point(118, 24);
            this.txtDesCondicion.Name = "txtDesCondicion";
            this.txtDesCondicion.ReadOnly = true;
            this.txtDesCondicion.Size = new System.Drawing.Size(173, 20);
            this.txtDesCondicion.TabIndex = 321;
            this.txtDesCondicion.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 320;
            this.label11.Text = "Condición";
            // 
            // btBuscarCondicion
            // 
            this.btBuscarCondicion.BackColor = System.Drawing.Color.Azure;
            this.btBuscarCondicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCondicion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarCondicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCondicion.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarCondicion.Location = new System.Drawing.Point(295, 25);
            this.btBuscarCondicion.Name = "btBuscarCondicion";
            this.btBuscarCondicion.Size = new System.Drawing.Size(22, 19);
            this.btBuscarCondicion.TabIndex = 319;
            this.btBuscarCondicion.TabStop = false;
            this.btBuscarCondicion.UseVisualStyleBackColor = false;
            this.btBuscarCondicion.Click += new System.EventHandler(this.btBuscarCondicion_Click);
            // 
            // txtIdCondicion
            // 
            this.txtIdCondicion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCondicion.BackColor = System.Drawing.Color.White;
            this.txtIdCondicion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCondicion.Location = new System.Drawing.Point(91, 24);
            this.txtIdCondicion.Name = "txtIdCondicion";
            this.txtIdCondicion.Size = new System.Drawing.Size(24, 20);
            this.txtIdCondicion.TabIndex = 17;
            this.txtIdCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCondicion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdCondicion.TextoVacio = "<Descripcion>";
            this.txtIdCondicion.TextChanged += new System.EventHandler(this.txtIdCondicion_TextChanged);
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.DropDownWidth = 128;
            this.cboTipoComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(91, 46);
            this.cboTipoComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(200, 21);
            this.cboTipoComprobante.TabIndex = 22;
            this.cboTipoComprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipoComprobante_KeyPress);
            // 
            // pnlPrincipales
            // 
            this.pnlPrincipales.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrincipales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipales.Controls.Add(this.cboListaPrecio);
            this.pnlPrincipales.Controls.Add(label29);
            this.pnlPrincipales.Controls.Add(this.label12);
            this.pnlPrincipales.Controls.Add(this.DtpFecEntrega);
            this.pnlPrincipales.Controls.Add(label7);
            this.pnlPrincipales.Controls.Add(this.TxtEstado);
            this.pnlPrincipales.Controls.Add(label5);
            this.pnlPrincipales.Controls.Add(this.btSunat);
            this.pnlPrincipales.Controls.Add(this.txtNombresVendedor);
            this.pnlPrincipales.Controls.Add(this.btBuscarVendedor);
            this.pnlPrincipales.Controls.Add(label8);
            this.pnlPrincipales.Controls.Add(label18);
            this.pnlPrincipales.Controls.Add(this.txtNroDocumentoVen);
            this.pnlPrincipales.Controls.Add(this.txtPuntoLlegada);
            this.pnlPrincipales.Controls.Add(this.btBuscarDireccion);
            this.pnlPrincipales.Controls.Add(this.TxtObservacion);
            this.pnlPrincipales.Controls.Add(this.txtCodPedido);
            this.pnlPrincipales.Controls.Add(label10);
            this.pnlPrincipales.Controls.Add(this.txtDireccion);
            this.pnlPrincipales.Controls.Add(label6);
            this.pnlPrincipales.Controls.Add(this.cboMonedas);
            this.pnlPrincipales.Controls.Add(label21);
            this.pnlPrincipales.Controls.Add(this.dtFecEmision);
            this.pnlPrincipales.Controls.Add(label20);
            this.pnlPrincipales.Controls.Add(this.txtRucCLiente);
            this.pnlPrincipales.Controls.Add(this.txtRazonCliente);
            this.pnlPrincipales.Controls.Add(label13);
            this.pnlPrincipales.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipales.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipales.Name = "pnlPrincipales";
            this.pnlPrincipales.Size = new System.Drawing.Size(818, 181);
            this.pnlPrincipales.TabIndex = 260;
            // 
            // cboListaPrecio
            // 
            this.cboListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPrecio.DropDownWidth = 260;
            this.cboListaPrecio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListaPrecio.FormattingEnabled = true;
            this.cboListaPrecio.Location = new System.Drawing.Point(682, 26);
            this.cboListaPrecio.Name = "cboListaPrecio";
            this.cboListaPrecio.Size = new System.Drawing.Size(115, 21);
            this.cboListaPrecio.TabIndex = 1600;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(816, 18);
            this.label12.TabIndex = 1587;
            this.label12.Text = "Datos Principales";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DtpFecEntrega
            // 
            this.DtpFecEntrega.CustomFormat = "dd/MM/yyyy";
            this.DtpFecEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFecEntrega.Location = new System.Drawing.Point(697, 93);
            this.DtpFecEntrega.Name = "DtpFecEntrega";
            this.DtpFecEntrega.Size = new System.Drawing.Size(100, 20);
            this.DtpFecEntrega.TabIndex = 1585;
            // 
            // TxtEstado
            // 
            this.TxtEstado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.TxtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.TxtEstado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtEstado.Enabled = false;
            this.TxtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEstado.Location = new System.Drawing.Point(371, 26);
            this.TxtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.TxtEstado.Name = "TxtEstado";
            this.TxtEstado.Size = new System.Drawing.Size(94, 20);
            this.TxtEstado.TabIndex = 1584;
            this.TxtEstado.TabStop = false;
            this.TxtEstado.Text = "En Cotizacion";
            this.TxtEstado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtEstado.TextoVacio = "<Descripcion>";
            // 
            // btSunat
            // 
            this.btSunat.BackColor = System.Drawing.Color.Azure;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Image = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btSunat.Location = new System.Drawing.Point(740, 50);
            this.btSunat.Margin = new System.Windows.Forms.Padding(2);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(57, 18);
            this.btSunat.TabIndex = 1582;
            this.btSunat.TabStop = false;
            this.btSunat.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSunat.UseVisualStyleBackColor = false;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // txtNombresVendedor
            // 
            this.txtNombresVendedor.BackColor = System.Drawing.Color.White;
            this.txtNombresVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombresVendedor.Location = new System.Drawing.Point(176, 115);
            this.txtNombresVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombresVendedor.Name = "txtNombresVendedor";
            this.txtNombresVendedor.Size = new System.Drawing.Size(595, 20);
            this.txtNombresVendedor.TabIndex = 5;
            this.txtNombresVendedor.TextChanged += new System.EventHandler(this.txtNombresVendedor_TextChanged);
            this.txtNombresVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombresVendedor_KeyPress);
            this.txtNombresVendedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombresVendedor_Validating);
            // 
            // btBuscarVendedor
            // 
            this.btBuscarVendedor.BackColor = System.Drawing.Color.Azure;
            this.btBuscarVendedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarVendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarVendedor.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarVendedor.Location = new System.Drawing.Point(775, 115);
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
            this.txtNroDocumentoVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumentoVen.Location = new System.Drawing.Point(101, 115);
            this.txtNroDocumentoVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroDocumentoVen.Name = "txtNroDocumentoVen";
            this.txtNroDocumentoVen.Size = new System.Drawing.Size(72, 20);
            this.txtNroDocumentoVen.TabIndex = 4;
            this.txtNroDocumentoVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNroDocumentoVen.TextoVacio = "<Descripcion>";
            this.txtNroDocumentoVen.TextChanged += new System.EventHandler(this.txtNroDocumentoVen_TextChanged);
            this.txtNroDocumentoVen.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroDocumentoVen_Validating);
            // 
            // txtPuntoLlegada
            // 
            this.txtPuntoLlegada.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPuntoLlegada.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPuntoLlegada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntoLlegada.Location = new System.Drawing.Point(101, 93);
            this.txtPuntoLlegada.Name = "txtPuntoLlegada";
            this.txtPuntoLlegada.Size = new System.Drawing.Size(493, 20);
            this.txtPuntoLlegada.TabIndex = 16;
            this.txtPuntoLlegada.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPuntoLlegada.TextoVacio = "";
            // 
            // btBuscarDireccion
            // 
            this.btBuscarDireccion.BackColor = System.Drawing.Color.Azure;
            this.btBuscarDireccion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarDireccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarDireccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarDireccion.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarDireccion.Location = new System.Drawing.Point(600, 93);
            this.btBuscarDireccion.Name = "btBuscarDireccion";
            this.btBuscarDireccion.Size = new System.Drawing.Size(22, 20);
            this.btBuscarDireccion.TabIndex = 326;
            this.btBuscarDireccion.TabStop = false;
            this.btBuscarDireccion.UseVisualStyleBackColor = false;
            this.btBuscarDireccion.Click += new System.EventHandler(this.btBuscarDireccion_Click);
            // 
            // TxtObservacion
            // 
            this.TxtObservacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.TxtObservacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservacion.Location = new System.Drawing.Point(101, 137);
            this.TxtObservacion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtObservacion.Multiline = true;
            this.TxtObservacion.Name = "TxtObservacion";
            this.TxtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtObservacion.Size = new System.Drawing.Size(696, 32);
            this.TxtObservacion.TabIndex = 20;
            this.TxtObservacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.TxtObservacion.TextoVacio = "Ingrese Observación";
            // 
            // txtCodPedido
            // 
            this.txtCodPedido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCodPedido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodPedido.Enabled = false;
            this.txtCodPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPedido.Location = new System.Drawing.Point(101, 26);
            this.txtCodPedido.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodPedido.Name = "txtCodPedido";
            this.txtCodPedido.Size = new System.Drawing.Size(84, 20);
            this.txtCodPedido.TabIndex = 317;
            this.txtCodPedido.TabStop = false;
            this.txtCodPedido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodPedido.TextoVacio = "<Descripcion>";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(101, 71);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(696, 20);
            this.txtDireccion.TabIndex = 257;
            this.txtDireccion.TabStop = false;
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(518, 26);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(87, 21);
            this.cboMonedas.TabIndex = 11;
            this.cboMonedas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMonedas_KeyPress);
            // 
            // dtFecEmision
            // 
            this.dtFecEmision.CustomFormat = "dd/MM/yyyy";
            this.dtFecEmision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFecEmision.Location = new System.Drawing.Point(229, 26);
            this.dtFecEmision.Name = "dtFecEmision";
            this.dtFecEmision.Size = new System.Drawing.Size(94, 20);
            this.dtFecEmision.TabIndex = 9;
            this.dtFecEmision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFecEmision_KeyPress);
            // 
            // txtRucCLiente
            // 
            this.txtRucCLiente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucCLiente.BackColor = System.Drawing.Color.White;
            this.txtRucCLiente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucCLiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucCLiente.Location = new System.Drawing.Point(101, 49);
            this.txtRucCLiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucCLiente.Name = "txtRucCLiente";
            this.txtRucCLiente.Size = new System.Drawing.Size(84, 20);
            this.txtRucCLiente.TabIndex = 14;
            this.txtRucCLiente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucCLiente.TextoVacio = "<Descripcion>";
            this.txtRucCLiente.TextChanged += new System.EventHandler(this.txtRucCLiente_TextChanged);
            this.txtRucCLiente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucCLiente_Validating);
            // 
            // txtRazonCliente
            // 
            this.txtRazonCliente.BackColor = System.Drawing.Color.White;
            this.txtRazonCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonCliente.Location = new System.Drawing.Point(188, 49);
            this.txtRazonCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonCliente.Name = "txtRazonCliente";
            this.txtRazonCliente.Size = new System.Drawing.Size(547, 20);
            this.txtRazonCliente.TabIndex = 15;
            this.txtRazonCliente.TextChanged += new System.EventHandler(this.txtRazonCliente_TextChanged);
            this.txtRazonCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonCliente_KeyPress);
            this.txtRazonCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonCliente_Validating);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.label28);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 265);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(1080, 220);
            this.pnlDetalle.TabIndex = 257;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItem,
            this.codArticulo,
            this.nomArticulo,
            this.Cantidad,
            this.PrecioUnitario,
            this.subTotal,
            this.Igv,
            this.Dscto1,
            this.Total,
            this.Stock,
            this.LoteProveedor,
            this.Lote});
            this.dgvDetalle.DataSource = this.bsPedido;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 18);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(1078, 200);
            this.dgvDetalle.TabIndex = 104;
            this.dgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellDoubleClick);
            // 
            // idItem
            // 
            this.idItem.DataPropertyName = "idItem";
            this.idItem.HeaderText = "Item";
            this.idItem.Name = "idItem";
            this.idItem.ReadOnly = true;
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
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N4";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle20;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N5";
            this.PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle21;
            this.PrecioUnitario.HeaderText = "Precio";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            // 
            // subTotal
            // 
            this.subTotal.DataPropertyName = "subTotal";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            this.subTotal.DefaultCellStyle = dataGridViewCellStyle22;
            this.subTotal.HeaderText = "SubTotal";
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            // 
            // Igv
            // 
            this.Igv.DataPropertyName = "Igv";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            this.Igv.DefaultCellStyle = dataGridViewCellStyle23;
            this.Igv.HeaderText = "IGV";
            this.Igv.Name = "Igv";
            this.Igv.ReadOnly = true;
            // 
            // Dscto1
            // 
            this.Dscto1.DataPropertyName = "Dscto1";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N2";
            this.Dscto1.DefaultCellStyle = dataGridViewCellStyle24;
            this.Dscto1.HeaderText = "Dscto.";
            this.Dscto1.Name = "Dscto1";
            this.Dscto1.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle25;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "N4";
            this.Stock.DefaultCellStyle = dataGridViewCellStyle26;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // LoteProveedor
            // 
            this.LoteProveedor.DataPropertyName = "LoteProveedor";
            this.LoteProveedor.HeaderText = "Lote Prov.";
            this.LoteProveedor.Name = "LoteProveedor";
            this.LoteProveedor.ReadOnly = true;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            // 
            // bsPedido
            // 
            this.bsPedido.DataSource = typeof(Entidades.Ventas.PedidoDetE);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label28.Dock = System.Windows.Forms.DockStyle.Top;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(1078, 18);
            this.label28.TabIndex = 346;
            this.label28.Text = "Detalle del Pedido";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label16);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFecModifica);
            this.pnlAuditoria.Controls.Add(this.txtFecRegistro);
            this.pnlAuditoria.Controls.Add(label2);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(825, 54);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(258, 130);
            this.pnlAuditoria.TabIndex = 256;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(256, 18);
            this.label16.TabIndex = 346;
            this.label16.Text = "Auditoria";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFecModifica
            // 
            this.txtFecModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecModifica.Enabled = false;
            this.txtFecModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecModifica.Location = new System.Drawing.Point(115, 95);
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
            this.txtFecRegistro.Location = new System.Drawing.Point(115, 51);
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
            this.txtUsuRegistra.Location = new System.Drawing.Point(115, 29);
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
            this.txtUsuModifica.Location = new System.Drawing.Point(115, 73);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCliente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCliente.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarCliente.Location = new System.Drawing.Point(423, 516);
            this.btBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(22, 20);
            this.btBuscarCliente.TabIndex = 17;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = false;
            this.btBuscarCliente.Visible = false;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // pnlDetraccion
            // 
            this.pnlDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetraccion.Controls.Add(label27);
            this.pnlDetraccion.Controls.Add(this.txtTipoCalculo);
            this.pnlDetraccion.Controls.Add(this.lblCaptionDetra);
            this.pnlDetraccion.Controls.Add(label9);
            this.pnlDetraccion.Controls.Add(this.chkDetraccion);
            this.pnlDetraccion.Controls.Add(this.txtMontoDetraS);
            this.pnlDetraccion.Controls.Add(this.cboTipoDetraccion);
            this.pnlDetraccion.Controls.Add(tipo_detraccionLabel);
            this.pnlDetraccion.Controls.Add(this.txtTasaDetra);
            this.pnlDetraccion.Controls.Add(tasa_detraccionLabel);
            this.pnlDetraccion.Controls.Add(this.label25);
            this.pnlDetraccion.Location = new System.Drawing.Point(545, 187);
            this.pnlDetraccion.Name = "pnlDetraccion";
            this.pnlDetraccion.Size = new System.Drawing.Size(538, 75);
            this.pnlDetraccion.TabIndex = 1599;
            // 
            // txtTipoCalculo
            // 
            this.txtTipoCalculo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipoCalculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTipoCalculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCalculo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipoCalculo.Enabled = false;
            this.txtTipoCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCalculo.Location = new System.Drawing.Point(497, 33);
            this.txtTipoCalculo.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipoCalculo.Name = "txtTipoCalculo";
            this.txtTipoCalculo.Size = new System.Drawing.Size(26, 20);
            this.txtTipoCalculo.TabIndex = 309;
            this.txtTipoCalculo.TabStop = false;
            this.txtTipoCalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTipoCalculo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTipoCalculo.TextoVacio = "<Descripcion>";
            // 
            // lblCaptionDetra
            // 
            this.lblCaptionDetra.AutoSize = true;
            this.lblCaptionDetra.Location = new System.Drawing.Point(345, 37);
            this.lblCaptionDetra.Name = "lblCaptionDetra";
            this.lblCaptionDetra.Size = new System.Drawing.Size(52, 13);
            this.lblCaptionDetra.TabIndex = 308;
            this.lblCaptionDetra.Text = "Monto S/";
            // 
            // chkDetraccion
            // 
            this.chkDetraccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.chkDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetraccion.ForeColor = System.Drawing.Color.Black;
            this.chkDetraccion.Location = new System.Drawing.Point(0, 1);
            this.chkDetraccion.Name = "chkDetraccion";
            this.chkDetraccion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDetraccion.Size = new System.Drawing.Size(96, 15);
            this.chkDetraccion.TabIndex = 301;
            this.chkDetraccion.Text = "Detracción";
            this.chkDetraccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDetraccion.UseVisualStyleBackColor = false;
            // 
            // txtMontoDetraS
            // 
            this.txtMontoDetraS.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoDetraS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtMontoDetraS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoDetraS.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoDetraS.Enabled = false;
            this.txtMontoDetraS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDetraS.Location = new System.Drawing.Point(406, 33);
            this.txtMontoDetraS.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoDetraS.Name = "txtMontoDetraS";
            this.txtMontoDetraS.Size = new System.Drawing.Size(54, 20);
            this.txtMontoDetraS.TabIndex = 306;
            this.txtMontoDetraS.TabStop = false;
            this.txtMontoDetraS.Text = "0.00";
            this.txtMontoDetraS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoDetraS.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoDetraS.TextoVacio = "<Descripcion>";
            // 
            // cboTipoDetraccion
            // 
            this.cboTipoDetraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDetraccion.DropDownWidth = 200;
            this.cboTipoDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDetraccion.FormattingEnabled = true;
            this.cboTipoDetraccion.Location = new System.Drawing.Point(38, 33);
            this.cboTipoDetraccion.Name = "cboTipoDetraccion";
            this.cboTipoDetraccion.Size = new System.Drawing.Size(217, 21);
            this.cboTipoDetraccion.TabIndex = 304;
            // 
            // txtTasaDetra
            // 
            this.txtTasaDetra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTasaDetra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTasaDetra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTasaDetra.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTasaDetra.Enabled = false;
            this.txtTasaDetra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTasaDetra.Location = new System.Drawing.Point(291, 33);
            this.txtTasaDetra.Margin = new System.Windows.Forms.Padding(2);
            this.txtTasaDetra.Name = "txtTasaDetra";
            this.txtTasaDetra.Size = new System.Drawing.Size(33, 20);
            this.txtTasaDetra.TabIndex = 305;
            this.txtTasaDetra.TabStop = false;
            this.txtTasaDetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTasaDetra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTasaDetra.TextoVacio = "<Descripcion>";
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(536, 18);
            this.label25.TabIndex = 346;
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1088, 559);
            this.Controls.Add(this.pnlDetraccion);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label17);
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
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.btBuscarCliente);
            this.Name = "frmPedidos";
            this.Text = "Cotización - Pedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.pnlExportacion.ResumeLayout(false);
            this.pnlExportacion.PerformLayout();
            this.pnlPrincipales.ResumeLayout(false);
            this.pnlPrincipales.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPedido)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDetraccion.ResumeLayout(false);
            this.pnlDetraccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlExportacion;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.TextBox txtNumGuia;
        private System.Windows.Forms.Panel pnlPrincipales;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.DateTimePicker dtFecEmision;
        public ControlesWinForm.SuperTextBox txtRucCLiente;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtRazonCliente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFecModifica;
        private System.Windows.Forms.TextBox txtFecRegistro;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Button btBuscarVendedor;
        private System.Windows.Forms.BindingSource bsPedido;
        private System.Windows.Forms.Button btNuevoItem;
        private System.Windows.Forms.Button btEliminarItem;
        public ControlesWinForm.SuperTextBox txtCodPedido;
        private ControlesWinForm.SuperTextBox TxtObservacion;
        private MyLabelG.LabelDegradado lblSubTotal;
        private System.Windows.Forms.Label label17;
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
        private ControlesWinForm.SuperTextBox txtIdCondicion;
        private System.Windows.Forms.Button btBuscarCondicion;
        private System.Windows.Forms.TextBox txtDesCondicion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private ControlesWinForm.SuperTextBox txtPuntoLlegada;
        private System.Windows.Forms.Button btBuscarDireccion;
        private System.Windows.Forms.Button btSunat;
        private ControlesWinForm.SuperTextBox txtNroDocumentoVen;
        private System.Windows.Forms.TextBox txtNombresVendedor;
        private System.Windows.Forms.DateTimePicker DtpFecEntrega;
        public ControlesWinForm.SuperTextBox TxtEstado;
        private System.Windows.Forms.Panel pnlDetraccion;
        private ControlesWinForm.SuperTextBox txtTipoCalculo;
        private System.Windows.Forms.Label lblCaptionDetra;
        private System.Windows.Forms.CheckBox chkDetraccion;
        private ControlesWinForm.SuperTextBox txtMontoDetraS;
        private System.Windows.Forms.ComboBox cboTipoDetraccion;
        private ControlesWinForm.SuperTextBox txtTasaDetra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dscto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboListaPrecio;
    }
}