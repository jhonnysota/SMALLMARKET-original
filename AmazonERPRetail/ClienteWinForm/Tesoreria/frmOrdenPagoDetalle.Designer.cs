namespace ClienteWinForm.Tesoreria
{
    partial class frmOrdenPagoDetalle
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label numDocumentoLabel;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label7;
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.txtConcepto = new ControlesWinForm.SuperTextBox();
            this.txtDes = new ControlesWinForm.SuperTextBox();
            this.btProveedor = new System.Windows.Forms.Button();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtIdAuxiliar = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.pnlDatosBancarios = new System.Windows.Forms.Panel();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.cboCuentasBancarias = new System.Windows.Forms.ComboBox();
            this.cboBancos = new System.Windows.Forms.ComboBox();
            this.cboTipoCuenta = new System.Windows.Forms.ComboBox();
            this.cboMonedaBanco = new System.Windows.Forms.ComboBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.chkIndPago = new System.Windows.Forms.CheckBox();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboConceptos = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMonedasPago = new System.Windows.Forms.ComboBox();
            this.txtMontoPago = new ControlesWinForm.SuperTextBox();
            this.btPresupuesto = new System.Windows.Forms.Button();
            this.txtDesPartida = new System.Windows.Forms.TextBox();
            this.txtCodPartida = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            label2 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            numDocumentoLabel = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDatosBancarios.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(715, 160);
            this.btCancelar.Size = new System.Drawing.Size(118, 29);
            this.btCancelar.TabStop = false;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(591, 160);
            this.btAceptar.Size = new System.Drawing.Size(118, 29);
            this.btAceptar.TabStop = false;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(557, 18);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(856, 25);
            this.lblTituloPrincipal.TabIndex = 500;
            this.lblTituloPrincipal.Text = "Detalle de la Orden de Pago";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(827, 2);
            this.btCerrar.TabStop = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.cboConceptos);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.cboTipoPago);
            this.pnlBase.Controls.Add(this.cboFormaPago);
            this.pnlBase.Controls.Add(this.label13);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.chkIndPago);
            this.pnlBase.Controls.Add(this.txtRuc);
            this.pnlBase.Controls.Add(label3);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Controls.Add(this.txtNumero);
            this.pnlBase.Controls.Add(numDocumentoLabel);
            this.pnlBase.Controls.Add(this.cboDocumento);
            this.pnlBase.Controls.Add(this.btProveedor);
            this.pnlBase.Controls.Add(this.txtRazonSocial);
            this.pnlBase.Controls.Add(this.txtIdAuxiliar);
            this.pnlBase.Controls.Add(this.label22);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(this.txtDes);
            this.pnlBase.Controls.Add(label5);
            this.pnlBase.Controls.Add(this.txtConcepto);
            this.pnlBase.Controls.Add(this.txtMonto);
            this.pnlBase.Controls.Add(label17);
            this.pnlBase.Controls.Add(this.cboMonedas);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.dtpFecha);
            this.pnlBase.Location = new System.Drawing.Point(8, 30);
            this.pnlBase.Size = new System.Drawing.Size(559, 192);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecha, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMonedas, 0);
            this.pnlBase.Controls.SetChildIndex(label17, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMonto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDes, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.label22, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdAuxiliar, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRazonSocial, 0);
            this.pnlBase.Controls.SetChildIndex(this.btProveedor, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(numDocumentoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumero, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRuc, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkIndPago, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label13, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboFormaPago, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoPago, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboConceptos, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(4, 123);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 13);
            label2.TabIndex = 427;
            label2.Text = "Fecha";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label17.Location = new System.Drawing.Point(4, 146);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(74, 13);
            label17.TabIndex = 403;
            label17.Text = "Monto Dcmto.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(13, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 431;
            label4.Text = "Monto Pago";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(263, 123);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 13);
            label5.TabIndex = 433;
            label5.Text = "Concepto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(260, 146);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(61, 13);
            label6.TabIndex = 435;
            label6.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(291, 100);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(27, 13);
            label3.TabIndex = 444;
            label3.Text = "Nro.";
            // 
            // numDocumentoLabel
            // 
            numDocumentoLabel.AutoSize = true;
            numDocumentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numDocumentoLabel.Location = new System.Drawing.Point(4, 100);
            numDocumentoLabel.Name = "numDocumentoLabel";
            numDocumentoLabel.Size = new System.Drawing.Size(62, 13);
            numDocumentoLabel.TabIndex = 443;
            numDocumentoLabel.Text = "Documento";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(8, 98);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificación";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(8, 75);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificación";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label26.Location = new System.Drawing.Point(8, 29);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(86, 13);
            label26.TabIndex = 0;
            label26.Text = "Usuario Registro";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.Location = new System.Drawing.Point(8, 52);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(79, 13);
            label27.TabIndex = 2;
            label27.Text = "Fecha Registro";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(220, 28);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(65, 13);
            label18.TabIndex = 454;
            label18.Text = "Tipo Cuenta";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(451, 28);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(45, 13);
            label19.TabIndex = 453;
            label19.Text = "Moneda";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(552, 28);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(70, 13);
            label21.TabIndex = 447;
            label21.Text = "Num. Cuenta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(3, 28);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(41, 13);
            label7.TabIndex = 457;
            label7.Text = "Bancos";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(83, 119);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(87, 20);
            this.dtpFecha.TabIndex = 9;
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(83, 142);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(87, 21);
            this.cboMonedas.TabIndex = 11;
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Location = new System.Drawing.Point(172, 143);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(87, 20);
            this.txtMonto.TabIndex = 12;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtConcepto
            // 
            this.txtConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtConcepto.Location = new System.Drawing.Point(323, 119);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(201, 20);
            this.txtConcepto.TabIndex = 10;
            this.txtConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtConcepto.TextoVacio = "<Descripcion>";
            // 
            // txtDes
            // 
            this.txtDes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDes.Location = new System.Drawing.Point(323, 142);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(201, 42);
            this.txtDes.TabIndex = 13;
            this.txtDes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDes.TextoVacio = "<Descripcion>";
            // 
            // btProveedor
            // 
            this.btProveedor.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btProveedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedor.Location = new System.Drawing.Point(527, 28);
            this.btProveedor.Name = "btProveedor";
            this.btProveedor.Size = new System.Drawing.Size(24, 18);
            this.btProveedor.TabIndex = 439;
            this.btProveedor.TabStop = false;
            this.btProveedor.UseVisualStyleBackColor = true;
            this.btProveedor.Visible = false;
            this.btProveedor.Click += new System.EventHandler(this.btProveedor_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(219, 27);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(305, 20);
            this.txtRazonSocial.TabIndex = 2;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAuxiliar.Enabled = false;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(83, 27);
            this.txtIdAuxiliar.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(56, 20);
            this.txtIdAuxiliar.TabIndex = 436;
            this.txtIdAuxiliar.TabStop = false;
            this.txtIdAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdAuxiliar.TextoVacio = "<Descripcion>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 30);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 438;
            this.label22.Text = "Auxiliar";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(323, 96);
            this.txtSerie.MaxLength = 4;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(82, 20);
            this.txtSerie.TabIndex = 7;
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(408, 96);
            this.txtNumero.MaxLength = 20;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(116, 20);
            this.txtNumero.TabIndex = 8;
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(83, 96);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(204, 21);
            this.cboDocumento.TabIndex = 6;
            this.cboDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboDocumento_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label24);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label25);
            this.pnlAuditoria.Controls.Add(label26);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label27);
            this.pnlAuditoria.Location = new System.Drawing.Point(570, 30);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(272, 124);
            this.pnlAuditoria.TabIndex = 361;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(270, 18);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(114, 94);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(130, 21);
            this.txtFechaModificacion.TabIndex = 304;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 25);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(130, 21);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 71);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(130, 21);
            this.txtUsuarioModificacion.TabIndex = 303;
            this.txtUsuarioModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 48);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(130, 21);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // pnlDatosBancarios
            // 
            this.pnlDatosBancarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatosBancarios.Controls.Add(this.txtNumCuenta);
            this.pnlDatosBancarios.Controls.Add(this.cboCuentasBancarias);
            this.pnlDatosBancarios.Controls.Add(label7);
            this.pnlDatosBancarios.Controls.Add(label18);
            this.pnlDatosBancarios.Controls.Add(label19);
            this.pnlDatosBancarios.Controls.Add(this.cboBancos);
            this.pnlDatosBancarios.Controls.Add(this.cboTipoCuenta);
            this.pnlDatosBancarios.Controls.Add(this.cboMonedaBanco);
            this.pnlDatosBancarios.Controls.Add(label21);
            this.pnlDatosBancarios.Controls.Add(this.labelDegradado3);
            this.pnlDatosBancarios.Location = new System.Drawing.Point(8, 302);
            this.pnlDatosBancarios.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatosBancarios.Name = "pnlDatosBancarios";
            this.pnlDatosBancarios.Size = new System.Drawing.Size(835, 53);
            this.pnlDatosBancarios.TabIndex = 362;
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumCuenta.Enabled = false;
            this.txtNumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCuenta.Location = new System.Drawing.Point(622, 24);
            this.txtNumCuenta.MaxLength = 4;
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(179, 20);
            this.txtNumCuenta.TabIndex = 453;
            this.txtNumCuenta.Visible = false;
            // 
            // cboCuentasBancarias
            // 
            this.cboCuentasBancarias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentasBancarias.FormattingEnabled = true;
            this.cboCuentasBancarias.Location = new System.Drawing.Point(628, 24);
            this.cboCuentasBancarias.Name = "cboCuentasBancarias";
            this.cboCuentasBancarias.Size = new System.Drawing.Size(144, 21);
            this.cboCuentasBancarias.TabIndex = 17;
            // 
            // cboBancos
            // 
            this.cboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancos.FormattingEnabled = true;
            this.cboBancos.Location = new System.Drawing.Point(46, 24);
            this.cboBancos.Name = "cboBancos";
            this.cboBancos.Size = new System.Drawing.Size(171, 21);
            this.cboBancos.TabIndex = 14;
            this.cboBancos.SelectionChangeCommitted += new System.EventHandler(this.cboBancos_SelectionChangeCommitted);
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(286, 24);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(162, 21);
            this.cboTipoCuenta.TabIndex = 15;
            this.cboTipoCuenta.SelectionChangeCommitted += new System.EventHandler(this.cboTipoCuenta_SelectionChangeCommitted);
            // 
            // cboMonedaBanco
            // 
            this.cboMonedaBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaBanco.Enabled = false;
            this.cboMonedaBanco.FormattingEnabled = true;
            this.cboMonedaBanco.Location = new System.Drawing.Point(498, 24);
            this.cboMonedaBanco.Name = "cboMonedaBanco";
            this.cboMonedaBanco.Size = new System.Drawing.Size(51, 21);
            this.cboMonedaBanco.TabIndex = 16;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(833, 18);
            this.labelDegradado3.TabIndex = 600;
            this.labelDegradado3.Text = "Datos Bancarios";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.White;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(141, 27);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(76, 20);
            this.txtRuc.TabIndex = 1;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // chkIndPago
            // 
            this.chkIndPago.AutoSize = true;
            this.chkIndPago.Checked = true;
            this.chkIndPago.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndPago.Enabled = false;
            this.chkIndPago.Location = new System.Drawing.Point(433, 75);
            this.chkIndPago.Name = "chkIndPago";
            this.chkIndPago.Size = new System.Drawing.Size(87, 17);
            this.chkIndPago.TabIndex = 446;
            this.chkIndPago.TabStop = false;
            this.chkIndPago.Text = "Esta Pagado";
            this.chkIndPago.UseVisualStyleBackColor = true;
            this.chkIndPago.CheckedChanged += new System.EventHandler(this.chkIndPago_CheckedChanged);
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.DropDownWidth = 250;
            this.cboTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(83, 50);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(204, 21);
            this.cboTipoPago.TabIndex = 3;
            this.cboTipoPago.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPago_SelectionChangeCommitted);
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(83, 73);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(204, 21);
            this.cboFormaPago.TabIndex = 5;
            this.cboFormaPago.SelectionChangeCommitted += new System.EventHandler(this.cboFormaPago_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 450;
            this.label13.Text = "Form. Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 449;
            this.label1.Text = "Tipo de Pago";
            // 
            // cboConceptos
            // 
            this.cboConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptos.DropDownWidth = 250;
            this.cboConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptos.FormattingEnabled = true;
            this.cboConceptos.Location = new System.Drawing.Point(345, 50);
            this.cboConceptos.Name = "cboConceptos";
            this.cboConceptos.Size = new System.Drawing.Size(179, 21);
            this.cboConceptos.TabIndex = 4;
            this.cboConceptos.SelectionChangeCommitted += new System.EventHandler(this.cboConceptos_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(290, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 452;
            this.label11.Text = "Concepto";
            // 
            // cboMonedasPago
            // 
            this.cboMonedasPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedasPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedasPago.FormattingEnabled = true;
            this.cboMonedasPago.Location = new System.Drawing.Point(82, 24);
            this.cboMonedasPago.Name = "cboMonedasPago";
            this.cboMonedasPago.Size = new System.Drawing.Size(87, 21);
            this.cboMonedasPago.TabIndex = 453;
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoPago.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoPago.Location = new System.Drawing.Point(172, 24);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(87, 20);
            this.txtMontoPago.TabIndex = 454;
            this.txtMontoPago.Text = "0.00";
            this.txtMontoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoPago.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoPago.TextoVacio = "<Descripcion>";
            // 
            // btPresupuesto
            // 
            this.btPresupuesto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPresupuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPresupuesto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btPresupuesto.Location = new System.Drawing.Point(525, 48);
            this.btPresupuesto.Name = "btPresupuesto";
            this.btPresupuesto.Size = new System.Drawing.Size(25, 19);
            this.btPresupuesto.TabIndex = 504;
            this.btPresupuesto.TabStop = false;
            this.btPresupuesto.UseVisualStyleBackColor = true;
            this.btPresupuesto.Click += new System.EventHandler(this.btPresupuesto_Click);
            // 
            // txtDesPartida
            // 
            this.txtDesPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesPartida.Location = new System.Drawing.Point(170, 47);
            this.txtDesPartida.Name = "txtDesPartida";
            this.txtDesPartida.ReadOnly = true;
            this.txtDesPartida.Size = new System.Drawing.Size(353, 20);
            this.txtDesPartida.TabIndex = 503;
            this.txtDesPartida.TabStop = false;
            // 
            // txtCodPartida
            // 
            this.txtCodPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPartida.Location = new System.Drawing.Point(82, 47);
            this.txtCodPartida.Name = "txtCodPartida";
            this.txtCodPartida.ReadOnly = true;
            this.txtCodPartida.Size = new System.Drawing.Size(87, 20);
            this.txtCodPartida.TabIndex = 502;
            this.txtCodPartida.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(13, 51);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(66, 13);
            this.label32.TabIndex = 501;
            this.label32.Text = "Presupuesto";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.cboMonedasPago);
            this.panel1.Controls.Add(this.txtCodPartida);
            this.panel1.Controls.Add(this.txtDesPartida);
            this.panel1.Controls.Add(this.btPresupuesto);
            this.panel1.Controls.Add(this.txtMontoPago);
            this.panel1.Location = new System.Drawing.Point(8, 225);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 74);
            this.panel1.TabIndex = 505;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(557, 18);
            this.labelDegradado1.TabIndex = 600;
            this.labelDegradado1.Text = "Monto y Presupuesto";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOrdenPagoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDatosBancarios);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmOrdenPagoDetalle";
            this.Text = "frmOrdenPagoDetalle";
            this.Load += new System.EventHandler(this.frmOrdenPagoDetalle_Load);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.pnlDatosBancarios, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDatosBancarios.ResumeLayout(false);
            this.pnlDatosBancarios.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ControlesWinForm.SuperTextBox txtDes;
        private ControlesWinForm.SuperTextBox txtConcepto;
        private ControlesWinForm.SuperTextBox txtMonto;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.Button btProveedor;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdAuxiliar;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel pnlDatosBancarios;
        private System.Windows.Forms.ComboBox cboTipoCuenta;
        private System.Windows.Forms.ComboBox cboMonedaBanco;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.ComboBox cboCuentasBancarias;
        private System.Windows.Forms.ComboBox cboBancos;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.CheckBox chkIndPago;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboConceptos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private ControlesWinForm.SuperTextBox txtMontoPago;
        private System.Windows.Forms.ComboBox cboMonedasPago;
        private System.Windows.Forms.Button btPresupuesto;
        private System.Windows.Forms.TextBox txtDesPartida;
        private System.Windows.Forms.TextBox txtCodPartida;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado1;
    }
}