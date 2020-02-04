namespace ClienteWinForm.Almacen
{
    partial class frmOrdenConversionGastos
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            this.chkItem = new System.Windows.Forms.CheckBox();
            this.txtItemADis = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtNumDoc = new ControlesWinForm.SuperTextBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.txtMontoDolares = new ControlesWinForm.SuperTextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.txtTipCambio = new ControlesWinForm.SuperTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtDescipcion = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(501, 20);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(770, 25);
            this.lblTituloPrincipal.Text = "Gastos de Conversiones";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(741, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlBase.Controls.Add(this.chkItem);
            this.pnlBase.Controls.Add(label4);
            this.pnlBase.Controls.Add(this.txtItemADis);
            this.pnlBase.Controls.Add(this.txtRazonSocial);
            this.pnlBase.Controls.Add(this.txtNumDoc);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Controls.Add(this.label29);
            this.pnlBase.Controls.Add(this.cboDocumento);
            this.pnlBase.Controls.Add(this.label28);
            this.pnlBase.Controls.Add(this.label26);
            this.pnlBase.Controls.Add(this.txtRuc);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.txtMonto);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(this.txtMontoDolares);
            this.pnlBase.Controls.Add(label14);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Controls.Add(label13);
            this.pnlBase.Controls.Add(this.txtTipCambio);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.dtpFecha);
            this.pnlBase.Controls.Add(label16);
            this.pnlBase.Controls.Add(this.txtDescipcion);
            this.pnlBase.Location = new System.Drawing.Point(6, 28);
            this.pnlBase.Size = new System.Drawing.Size(503, 204);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescipcion, 0);
            this.pnlBase.Controls.SetChildIndex(label16, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecha, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTipCambio, 0);
            this.pnlBase.Controls.SetChildIndex(label13, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(label14, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMontoDolares, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMonto, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRuc, 0);
            this.pnlBase.Controls.SetChildIndex(this.label26, 0);
            this.pnlBase.Controls.SetChildIndex(this.label28, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(this.label29, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumDoc, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRazonSocial, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtItemADis, 0);
            this.pnlBase.Controls.SetChildIndex(label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkItem, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(643, 184);
            this.btCancelar.Size = new System.Drawing.Size(112, 27);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(523, 184);
            this.btAceptar.Size = new System.Drawing.Size(112, 27);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(15, 155);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 26);
            label4.TabIndex = 450;
            label4.Text = "Item a \r\nDistribuir";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(359, 98);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 13);
            label2.TabIndex = 440;
            label2.Text = "Monto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(320, 120);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 13);
            label1.TabIndex = 438;
            label1.Text = "Monto Dolares";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.Location = new System.Drawing.Point(167, 98);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(45, 13);
            label14.TabIndex = 436;
            label14.Text = "Moneda";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(285, 98);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(28, 13);
            label13.TabIndex = 434;
            label13.Text = "T.C.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(15, 31);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(61, 13);
            label16.TabIndex = 430;
            label16.Text = "Descripción";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 98);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 75);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 29);
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
            // chkItem
            // 
            this.chkItem.AutoSize = true;
            this.chkItem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkItem.Location = new System.Drawing.Point(79, 120);
            this.chkItem.Name = "chkItem";
            this.chkItem.Size = new System.Drawing.Size(89, 17);
            this.chkItem.TabIndex = 451;
            this.chkItem.TabStop = false;
            this.chkItem.Text = "Distribuir Item";
            this.chkItem.UseVisualStyleBackColor = true;
            this.chkItem.CheckedChanged += new System.EventHandler(this.chkItem_CheckedChanged);
            // 
            // txtItemADis
            // 
            this.txtItemADis.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtItemADis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtItemADis.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtItemADis.Enabled = false;
            this.txtItemADis.Location = new System.Drawing.Point(79, 138);
            this.txtItemADis.MaxLength = 100;
            this.txtItemADis.Multiline = true;
            this.txtItemADis.Name = "txtItemADis";
            this.txtItemADis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemADis.Size = new System.Drawing.Size(407, 57);
            this.txtItemADis.TabIndex = 11;
            this.txtItemADis.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtItemADis.TextoVacio = "<Descripcion>";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(166, 49);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(320, 20);
            this.txtRazonSocial.TabIndex = 2;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumDoc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(389, 71);
            this.txtNumDoc.MaxLength = 20;
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(97, 20);
            this.txtNumDoc.TabIndex = 5;
            this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumDoc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtNumDoc.TextoVacio = "<Descripcion>";
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.SystemColors.Window;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(343, 71);
            this.txtSerie.MaxLength = 20;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(44, 20);
            this.txtSerie.TabIndex = 4;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            this.txtSerie.Leave += new System.EventHandler(this.txtSerie_Leave);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(285, 75);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 13);
            this.label29.TabIndex = 448;
            this.label29.Text = "Nro. Doc.";
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.DropDownWidth = 250;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(79, 71);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(203, 21);
            this.cboDocumento.TabIndex = 3;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(15, 75);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 13);
            this.label28.TabIndex = 447;
            this.label28.Text = "Documento";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(15, 53);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 443;
            this.label26.Text = "RUC";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(79, 49);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(84, 20);
            this.txtRuc.TabIndex = 1;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Location = new System.Drawing.Point(400, 94);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(86, 20);
            this.txtMonto.TabIndex = 9;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // txtMontoDolares
            // 
            this.txtMontoDolares.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoDolares.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoDolares.Location = new System.Drawing.Point(400, 116);
            this.txtMontoDolares.Name = "txtMontoDolares";
            this.txtMontoDolares.ReadOnly = true;
            this.txtMontoDolares.Size = new System.Drawing.Size(86, 20);
            this.txtMontoDolares.TabIndex = 10;
            this.txtMontoDolares.Text = "0.00";
            this.txtMontoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoDolares.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMontoDolares.TextoVacio = "<Descripcion>";
            this.txtMontoDolares.TextChanged += new System.EventHandler(this.txtMontoDolares_TextChanged);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(215, 94);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(67, 21);
            this.cboMoneda.TabIndex = 7;
            this.cboMoneda.SelectionChangeCommitted += new System.EventHandler(this.cboMoneda_SelectionChangeCommitted);
            // 
            // txtTipCambio
            // 
            this.txtTipCambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipCambio.BackColor = System.Drawing.SystemColors.Window;
            this.txtTipCambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipCambio.Location = new System.Drawing.Point(315, 94);
            this.txtTipCambio.Name = "txtTipCambio";
            this.txtTipCambio.Size = new System.Drawing.Size(36, 20);
            this.txtTipCambio.TabIndex = 8;
            this.txtTipCambio.Text = "0.000";
            this.txtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTipCambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTipCambio.TextoVacio = "<Descripcion>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 432;
            this.label11.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(79, 94);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 20);
            this.dtpFecha.TabIndex = 6;
            this.dtpFecha.Value = new System.DateTime(2016, 3, 28, 15, 57, 31, 0);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // txtDescipcion
            // 
            this.txtDescipcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescipcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescipcion.Location = new System.Drawing.Point(79, 27);
            this.txtDescipcion.Name = "txtDescipcion";
            this.txtDescipcion.Size = new System.Drawing.Size(407, 20);
            this.txtDescipcion.TabIndex = 0;
            this.txtDescipcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescipcion.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
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
            this.pnlAuditoria.Location = new System.Drawing.Point(511, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(252, 124);
            this.pnlAuditoria.TabIndex = 345;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(114, 94);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(128, 21);
            this.txtFechaModificacion.TabIndex = 7;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 25);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(128, 21);
            this.txtUsuarioRegistro.TabIndex = 1;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 71);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(128, 21);
            this.txtUsuarioModificacion.TabIndex = 5;
            this.txtUsuarioModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 48);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(128, 21);
            this.txtFechaRegistro.TabIndex = 3;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 18);
            this.label3.TabIndex = 1579;
            this.label3.Text = "Auditoria";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOrdenConversionGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 237);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmOrdenConversionGastos";
            this.Text = "frmOrdenConversionGastos";
            this.Load += new System.EventHandler(this.frmOrdenConversionGastos_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkItem;
        private ControlesWinForm.SuperTextBox txtItemADis;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtNumDoc;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtMonto;
        private ControlesWinForm.SuperTextBox txtMontoDolares;
        private System.Windows.Forms.ComboBox cboMoneda;
        private ControlesWinForm.SuperTextBox txtTipCambio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ControlesWinForm.SuperTextBox txtDescipcion;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label3;
    }
}