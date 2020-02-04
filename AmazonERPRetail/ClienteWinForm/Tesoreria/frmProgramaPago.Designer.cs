namespace ClienteWinForm.Tesoreria
{
    partial class frmProgramaPago
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
            System.Windows.Forms.Label numDocumentoLabel;
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.txtCodPartida = new System.Windows.Forms.TextBox();
            this.txtDesPartida = new System.Windows.Forms.TextBox();
            this.btPresupuesto = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFecPago = new System.Windows.Forms.DateTimePicker();
            this.cboConceptos = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.txtIdAuxiliar = new System.Windows.Forms.TextBox();
            this.txtEgreso = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGlosa = new ControlesWinForm.SuperTextBox();
            this.txtGrupo = new ControlesWinForm.SuperTextBox();
            this.txtFecVencimiento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMontoOrigen = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdMoneda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.txtFecEmision = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesBeneficiario = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.cboOperacion = new System.Windows.Forms.ComboBox();
            this.txtTica = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMonedaPago = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNumCheque = new System.Windows.Forms.TextBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cboCuenta = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.pnlEmpresa = new System.Windows.Forms.Panel();
            this.chkComision = new System.Windows.Forms.CheckBox();
            this.cboConceptoGasto = new System.Windows.Forms.ComboBox();
            this.txtGasCom = new ControlesWinForm.SuperTextBox();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.txtSerieBanco = new System.Windows.Forms.TextBox();
            this.txtNumeroBanco = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboDocumentoBanco = new System.Windows.Forms.ComboBox();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.pnlAuxiliar = new System.Windows.Forms.Panel();
            this.cboTipoCuenta = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboBancosProveedor = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboCuentasProveedor = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.pnlContable = new System.Windows.Forms.Panel();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            numDocumentoLabel = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.pnlEmpresa.SuspendLayout();
            this.pnlAuxiliar.SuspendLayout();
            this.pnlContable.SuspendLayout();
            this.SuspendLayout();
            // 
            // numDocumentoLabel
            // 
            numDocumentoLabel.AutoSize = true;
            numDocumentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numDocumentoLabel.Location = new System.Drawing.Point(13, 97);
            numDocumentoLabel.Name = "numDocumentoLabel";
            numDocumentoLabel.Size = new System.Drawing.Size(44, 13);
            numDocumentoLabel.TabIndex = 508;
            numDocumentoLabel.Text = "Docum.";
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label32);
            this.pnlDatos.Controls.Add(this.txtCodPartida);
            this.pnlDatos.Controls.Add(this.txtDesPartida);
            this.pnlDatos.Controls.Add(this.btPresupuesto);
            this.pnlDatos.Controls.Add(this.label22);
            this.pnlDatos.Controls.Add(this.dtpFecPago);
            this.pnlDatos.Controls.Add(this.cboConceptos);
            this.pnlDatos.Controls.Add(this.label21);
            this.pnlDatos.Controls.Add(this.cboDocumento);
            this.pnlDatos.Controls.Add(this.txtIdAuxiliar);
            this.pnlDatos.Controls.Add(this.txtEgreso);
            this.pnlDatos.Controls.Add(this.label14);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.label13);
            this.pnlDatos.Controls.Add(this.cboFormaPago);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.txtGlosa);
            this.pnlDatos.Controls.Add(this.txtGrupo);
            this.pnlDatos.Controls.Add(this.txtFecVencimiento);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.txtMontoOrigen);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtIdMoneda);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.txtRazonSocial);
            this.pnlDatos.Controls.Add(this.txtRuc);
            this.pnlDatos.Controls.Add(this.txtFecEmision);
            this.pnlDatos.Controls.Add(this.txtNumero);
            this.pnlDatos.Controls.Add(this.txtSerie);
            this.pnlDatos.Controls.Add(this.label3);
            this.pnlDatos.Controls.Add(this.txtDesBeneficiario);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Controls.Add(this.cboOperacion);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(499, 263);
            this.pnlDatos.TabIndex = 260;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(12, 238);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(66, 13);
            this.label32.TabIndex = 510;
            this.label32.Text = "Presupuesto";
            // 
            // txtCodPartida
            // 
            this.txtCodPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPartida.Location = new System.Drawing.Point(79, 234);
            this.txtCodPartida.Name = "txtCodPartida";
            this.txtCodPartida.ReadOnly = true;
            this.txtCodPartida.Size = new System.Drawing.Size(87, 20);
            this.txtCodPartida.TabIndex = 511;
            this.txtCodPartida.TabStop = false;
            // 
            // txtDesPartida
            // 
            this.txtDesPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesPartida.Location = new System.Drawing.Point(167, 234);
            this.txtDesPartida.Name = "txtDesPartida";
            this.txtDesPartida.ReadOnly = true;
            this.txtDesPartida.Size = new System.Drawing.Size(293, 20);
            this.txtDesPartida.TabIndex = 512;
            this.txtDesPartida.TabStop = false;
            // 
            // btPresupuesto
            // 
            this.btPresupuesto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPresupuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPresupuesto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btPresupuesto.Location = new System.Drawing.Point(461, 235);
            this.btPresupuesto.Name = "btPresupuesto";
            this.btPresupuesto.Size = new System.Drawing.Size(25, 19);
            this.btPresupuesto.TabIndex = 513;
            this.btPresupuesto.TabStop = false;
            this.btPresupuesto.UseVisualStyleBackColor = true;
            this.btPresupuesto.Click += new System.EventHandler(this.btPresupuesto_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 506;
            this.label22.Text = "Fec.Pago";
            // 
            // dtpFecPago
            // 
            this.dtpFecPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecPago.Location = new System.Drawing.Point(76, 69);
            this.dtpFecPago.Name = "dtpFecPago";
            this.dtpFecPago.Size = new System.Drawing.Size(80, 21);
            this.dtpFecPago.TabIndex = 505;
            // 
            // cboConceptos
            // 
            this.cboConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptos.DropDownWidth = 250;
            this.cboConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptos.FormattingEnabled = true;
            this.cboConceptos.Location = new System.Drawing.Point(308, 152);
            this.cboConceptos.Name = "cboConceptos";
            this.cboConceptos.Size = new System.Drawing.Size(178, 21);
            this.cboConceptos.TabIndex = 503;
            this.cboConceptos.SelectionChangeCommitted += new System.EventHandler(this.cboConceptos_SelectionChangeCommitted);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(252, 156);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 504;
            this.label21.Text = "Concepto";
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.Enabled = false;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(76, 23);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(145, 21);
            this.cboDocumento.TabIndex = 502;
            this.cboDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboDocumento_SelectionChangeCommitted);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdAuxiliar.Enabled = false;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(76, 46);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(61, 21);
            this.txtIdAuxiliar.TabIndex = 501;
            this.txtIdAuxiliar.TabStop = false;
            this.txtIdAuxiliar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEgreso
            // 
            this.txtEgreso.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEgreso.Enabled = false;
            this.txtEgreso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgreso.Location = new System.Drawing.Point(375, 128);
            this.txtEgreso.Name = "txtEgreso";
            this.txtEgreso.Size = new System.Drawing.Size(46, 21);
            this.txtEgreso.TabIndex = 6;
            this.txtEgreso.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(318, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 393;
            this.label14.Text = "N° Egreso";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 383;
            this.label9.Text = "Form.Pago";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 391;
            this.label13.Text = "Glosa";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.DropDownWidth = 132;
            this.cboFormaPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(79, 175);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(171, 21);
            this.cboFormaPago.TabIndex = 7;
            this.cboFormaPago.SelectionChangeCommitted += new System.EventHandler(this.cboFormaPago_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 381;
            this.label8.Text = "Grupo";
            // 
            // txtGlosa
            // 
            this.txtGlosa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGlosa.BackColor = System.Drawing.Color.White;
            this.txtGlosa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGlosa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGlosa.Location = new System.Drawing.Point(79, 198);
            this.txtGlosa.Multiline = true;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGlosa.Size = new System.Drawing.Size(407, 34);
            this.txtGlosa.TabIndex = 9;
            this.txtGlosa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGlosa.TextoVacio = "<Descripcion>";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGrupo.BackColor = System.Drawing.Color.White;
            this.txtGrupo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGrupo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrupo.Location = new System.Drawing.Point(461, 128);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(25, 21);
            this.txtGrupo.TabIndex = 4;
            this.txtGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGrupo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtGrupo.TextoVacio = "<Descripcion>";
            // 
            // txtFecVencimiento
            // 
            this.txtFecVencimiento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFecVencimiento.Enabled = false;
            this.txtFecVencimiento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecVencimiento.Location = new System.Drawing.Point(250, 128);
            this.txtFecVencimiento.Name = "txtFecVencimiento";
            this.txtFecVencimiento.Size = new System.Drawing.Size(66, 21);
            this.txtFecVencimiento.TabIndex = 3;
            this.txtFecVencimiento.TabStop = false;
            this.txtFecVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 378;
            this.label7.Text = "Vencimiento";
            // 
            // txtMontoOrigen
            // 
            this.txtMontoOrigen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoOrigen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoOrigen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoOrigen.Enabled = false;
            this.txtMontoOrigen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoOrigen.Location = new System.Drawing.Point(110, 128);
            this.txtMontoOrigen.Name = "txtMontoOrigen";
            this.txtMontoOrigen.Size = new System.Drawing.Size(72, 21);
            this.txtMontoOrigen.TabIndex = 2;
            this.txtMontoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoOrigen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoOrigen.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 376;
            this.label6.Text = "Monto";
            // 
            // txtIdMoneda
            // 
            this.txtIdMoneda.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdMoneda.Enabled = false;
            this.txtIdMoneda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdMoneda.Location = new System.Drawing.Point(79, 128);
            this.txtIdMoneda.Name = "txtIdMoneda";
            this.txtIdMoneda.Size = new System.Drawing.Size(29, 21);
            this.txtIdMoneda.TabIndex = 1;
            this.txtIdMoneda.TabStop = false;
            this.txtIdMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(209, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 374;
            this.label5.Text = "Beneficiario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 373;
            this.label4.Text = "Proveedor";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(212, 46);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(274, 21);
            this.txtRazonSocial.TabIndex = 372;
            this.txtRazonSocial.TabStop = false;
            // 
            // txtRuc
            // 
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(138, 46);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(73, 21);
            this.txtRuc.TabIndex = 371;
            this.txtRuc.TabStop = false;
            this.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFecEmision
            // 
            this.txtFecEmision.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFecEmision.Enabled = false;
            this.txtFecEmision.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecEmision.Location = new System.Drawing.Point(411, 23);
            this.txtFecEmision.Name = "txtFecEmision";
            this.txtFecEmision.Size = new System.Drawing.Size(75, 21);
            this.txtFecEmision.TabIndex = 369;
            this.txtFecEmision.TabStop = false;
            this.txtFecEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(260, 23);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(97, 21);
            this.txtNumero.TabIndex = 368;
            this.txtNumero.TabStop = false;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSerie
            // 
            this.txtSerie.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSerie.Enabled = false;
            this.txtSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(223, 23);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(35, 21);
            this.txtSerie.TabIndex = 367;
            this.txtSerie.TabStop = false;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 366;
            this.label3.Text = "Documento";
            // 
            // txtDesBeneficiario
            // 
            this.txtDesBeneficiario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesBeneficiario.BackColor = System.Drawing.Color.White;
            this.txtDesBeneficiario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesBeneficiario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesBeneficiario.Location = new System.Drawing.Point(16, 104);
            this.txtDesBeneficiario.Name = "txtDesBeneficiario";
            this.txtDesBeneficiario.Size = new System.Drawing.Size(470, 21);
            this.txtDesBeneficiario.TabIndex = 500;
            this.txtDesBeneficiario.TabStop = false;
            this.txtDesBeneficiario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesBeneficiario.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 363;
            this.label2.Text = "Tipo Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 362;
            this.label1.Text = "Fec.Doc.";
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(497, 17);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Datos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboOperacion
            // 
            this.cboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperacion.DropDownWidth = 132;
            this.cboOperacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperacion.FormattingEnabled = true;
            this.cboOperacion.Items.AddRange(new object[] {
            "Pendiente",
            "Girado"});
            this.cboOperacion.Location = new System.Drawing.Point(79, 152);
            this.cboOperacion.Name = "cboOperacion";
            this.cboOperacion.Size = new System.Drawing.Size(171, 21);
            this.cboOperacion.TabIndex = 5;
            this.cboOperacion.SelectionChangeCommitted += new System.EventHandler(this.cboOperacion_SelectionChangeCommitted);
            // 
            // txtTica
            // 
            this.txtTica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTica.Enabled = false;
            this.txtTica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTica.Location = new System.Drawing.Point(183, 69);
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(50, 21);
            this.txtTica.TabIndex = 370;
            this.txtTica.TabStop = false;
            this.txtTica.Text = "1.000";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(144, 73);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 13);
            this.label25.TabIndex = 361;
            this.label25.Text = "Ti.Ca.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 385;
            this.label10.Text = "Moneda";
            // 
            // cboMonedaPago
            // 
            this.cboMonedaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaPago.DropDownWidth = 132;
            this.cboMonedaPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedaPago.FormattingEnabled = true;
            this.cboMonedaPago.Location = new System.Drawing.Point(61, 46);
            this.cboMonedaPago.Name = "cboMonedaPago";
            this.cboMonedaPago.Size = new System.Drawing.Size(76, 21);
            this.cboMonedaPago.TabIndex = 8;
            this.cboMonedaPago.SelectionChangeCommitted += new System.EventHandler(this.cboMonedaPago_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(322, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 400;
            this.label12.Text = "N° Cheque";
            // 
            // cboLibro
            // 
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.DropDownWidth = 250;
            this.cboLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(79, 24);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(188, 21);
            this.cboLibro.TabIndex = 15;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 395;
            this.label15.Text = "Libro";
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.DropDownWidth = 250;
            this.cboFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(296, 24);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(188, 21);
            this.cboFile.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(270, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 396;
            this.label16.Text = "File";
            // 
            // txtNumCheque
            // 
            this.txtNumCheque.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumCheque.Enabled = false;
            this.txtNumCheque.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCheque.Location = new System.Drawing.Point(383, 46);
            this.txtNumCheque.Name = "txtNumCheque";
            this.txtNumCheque.Size = new System.Drawing.Size(101, 21);
            this.txtNumCheque.TabIndex = 12;
            this.txtNumCheque.TabStop = false;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(139, 50);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(42, 13);
            this.lblCuenta.TabIndex = 389;
            this.lblCuenta.Text = "Cuenta";
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.DropDownWidth = 132;
            this.cboCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Location = new System.Drawing.Point(183, 46);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(138, 21);
            this.cboCuenta.TabIndex = 11;
            this.cboCuenta.SelectionChangeCommitted += new System.EventHandler(this.cboCuenta_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 387;
            this.label11.Text = "Banco";
            // 
            // cboBanco
            // 
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.DropDownWidth = 132;
            this.cboBanco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(61, 23);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(423, 21);
            this.cboBanco.TabIndex = 10;
            this.cboBanco.SelectionChangeCommitted += new System.EventHandler(this.cboBanco_SelectionChangeCommitted);
            // 
            // pnlEmpresa
            // 
            this.pnlEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEmpresa.Controls.Add(this.chkComision);
            this.pnlEmpresa.Controls.Add(this.cboConceptoGasto);
            this.pnlEmpresa.Controls.Add(this.txtGasCom);
            this.pnlEmpresa.Controls.Add(this.txtMonto);
            this.pnlEmpresa.Controls.Add(this.txtSerieBanco);
            this.pnlEmpresa.Controls.Add(this.txtNumeroBanco);
            this.pnlEmpresa.Controls.Add(this.label18);
            this.pnlEmpresa.Controls.Add(numDocumentoLabel);
            this.pnlEmpresa.Controls.Add(this.label12);
            this.pnlEmpresa.Controls.Add(this.cboDocumentoBanco);
            this.pnlEmpresa.Controls.Add(this.labelDegradado5);
            this.pnlEmpresa.Controls.Add(this.cboBanco);
            this.pnlEmpresa.Controls.Add(this.label10);
            this.pnlEmpresa.Controls.Add(this.label11);
            this.pnlEmpresa.Controls.Add(this.cboMonedaPago);
            this.pnlEmpresa.Controls.Add(this.txtNumCheque);
            this.pnlEmpresa.Controls.Add(this.cboCuenta);
            this.pnlEmpresa.Controls.Add(this.lblCuenta);
            this.pnlEmpresa.Controls.Add(this.txtTica);
            this.pnlEmpresa.Controls.Add(this.label25);
            this.pnlEmpresa.Location = new System.Drawing.Point(3, 268);
            this.pnlEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEmpresa.Name = "pnlEmpresa";
            this.pnlEmpresa.Size = new System.Drawing.Size(499, 145);
            this.pnlEmpresa.TabIndex = 502;
            // 
            // chkComision
            // 
            this.chkComision.AutoSize = true;
            this.chkComision.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkComision.Location = new System.Drawing.Point(13, 119);
            this.chkComision.Name = "chkComision";
            this.chkComision.Size = new System.Drawing.Size(98, 17);
            this.chkComision.TabIndex = 513;
            this.chkComision.Text = "Ind. Gas./Com.";
            this.chkComision.UseVisualStyleBackColor = true;
            this.chkComision.CheckedChanged += new System.EventHandler(this.chkComision_CheckedChanged);
            // 
            // cboConceptoGasto
            // 
            this.cboConceptoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoGasto.Enabled = false;
            this.cboConceptoGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptoGasto.ForeColor = System.Drawing.Color.Black;
            this.cboConceptoGasto.FormattingEnabled = true;
            this.cboConceptoGasto.Location = new System.Drawing.Point(121, 116);
            this.cboConceptoGasto.Name = "cboConceptoGasto";
            this.cboConceptoGasto.Size = new System.Drawing.Size(266, 21);
            this.cboConceptoGasto.TabIndex = 511;
            // 
            // txtGasCom
            // 
            this.txtGasCom.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGasCom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGasCom.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGasCom.Enabled = false;
            this.txtGasCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGasCom.Location = new System.Drawing.Point(390, 116);
            this.txtGasCom.Name = "txtGasCom";
            this.txtGasCom.Size = new System.Drawing.Size(94, 20);
            this.txtGasCom.TabIndex = 509;
            this.txtGasCom.Text = "0.00";
            this.txtGasCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGasCom.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtGasCom.TextoVacio = "<Descripcion>";
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(61, 69);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(75, 21);
            this.txtMonto.TabIndex = 401;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtSerieBanco
            // 
            this.txtSerieBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerieBanco.Location = new System.Drawing.Point(324, 93);
            this.txtSerieBanco.MaxLength = 4;
            this.txtSerieBanco.Name = "txtSerieBanco";
            this.txtSerieBanco.Size = new System.Drawing.Size(63, 20);
            this.txtSerieBanco.TabIndex = 506;
            // 
            // txtNumeroBanco
            // 
            this.txtNumeroBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroBanco.Location = new System.Drawing.Point(390, 93);
            this.txtNumeroBanco.MaxLength = 10;
            this.txtNumeroBanco.Name = "txtNumeroBanco";
            this.txtNumeroBanco.Size = new System.Drawing.Size(94, 20);
            this.txtNumeroBanco.TabIndex = 507;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 402;
            this.label18.Text = "Monto";
            // 
            // cboDocumentoBanco
            // 
            this.cboDocumentoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentoBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentoBanco.FormattingEnabled = true;
            this.cboDocumentoBanco.Location = new System.Drawing.Point(61, 93);
            this.cboDocumentoBanco.Name = "cboDocumentoBanco";
            this.cboDocumentoBanco.Size = new System.Drawing.Size(260, 21);
            this.cboDocumentoBanco.TabIndex = 505;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(497, 17);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Datos Bancarios de la Empresa";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuxiliar
            // 
            this.pnlAuxiliar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAuxiliar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuxiliar.Controls.Add(this.cboTipoCuenta);
            this.pnlAuxiliar.Controls.Add(this.label17);
            this.pnlAuxiliar.Controls.Add(this.labelDegradado1);
            this.pnlAuxiliar.Controls.Add(this.cboBancosProveedor);
            this.pnlAuxiliar.Controls.Add(this.label19);
            this.pnlAuxiliar.Controls.Add(this.cboCuentasProveedor);
            this.pnlAuxiliar.Controls.Add(this.label20);
            this.pnlAuxiliar.Controls.Add(this.txtNumCuenta);
            this.pnlAuxiliar.Location = new System.Drawing.Point(3, 415);
            this.pnlAuxiliar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuxiliar.Name = "pnlAuxiliar";
            this.pnlAuxiliar.Size = new System.Drawing.Size(499, 74);
            this.pnlAuxiliar.TabIndex = 503;
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCuenta.DropDownWidth = 132;
            this.cboTipoCuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(78, 45);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(181, 21);
            this.cboTipoCuenta.TabIndex = 390;
            this.cboTipoCuenta.SelectionChangeCommitted += new System.EventHandler(this.cboTipoCuenta_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 391;
            this.label17.Text = "Tip. Cuenta";
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
            this.labelDegradado1.Size = new System.Drawing.Size(497, 17);
            this.labelDegradado1.TabIndex = 274;
            this.labelDegradado1.Text = "Datos Bancarios del Auxiliar";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboBancosProveedor
            // 
            this.cboBancosProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosProveedor.DropDownWidth = 132;
            this.cboBancosProveedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosProveedor.FormattingEnabled = true;
            this.cboBancosProveedor.Location = new System.Drawing.Point(78, 22);
            this.cboBancosProveedor.Name = "cboBancosProveedor";
            this.cboBancosProveedor.Size = new System.Drawing.Size(407, 21);
            this.cboBancosProveedor.TabIndex = 13;
            this.cboBancosProveedor.SelectionChangeCommitted += new System.EventHandler(this.cboBancosProveedor_SelectionChangeCommitted);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(14, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 13);
            this.label19.TabIndex = 387;
            this.label19.Text = "Banco";
            // 
            // cboCuentasProveedor
            // 
            this.cboCuentasProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentasProveedor.DropDownWidth = 132;
            this.cboCuentasProveedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuentasProveedor.FormattingEnabled = true;
            this.cboCuentasProveedor.Location = new System.Drawing.Point(304, 45);
            this.cboCuentasProveedor.Name = "cboCuentasProveedor";
            this.cboCuentasProveedor.Size = new System.Drawing.Size(181, 21);
            this.cboCuentasProveedor.TabIndex = 14;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(260, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 389;
            this.label20.Text = "Cuenta";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumCuenta.Enabled = false;
            this.txtNumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCuenta.Location = new System.Drawing.Point(304, 45);
            this.txtNumCuenta.MaxLength = 4;
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(181, 20);
            this.txtNumCuenta.TabIndex = 454;
            this.txtNumCuenta.Visible = false;
            // 
            // pnlContable
            // 
            this.pnlContable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContable.Controls.Add(this.labelDegradado3);
            this.pnlContable.Controls.Add(this.cboLibro);
            this.pnlContable.Controls.Add(this.label16);
            this.pnlContable.Controls.Add(this.cboFile);
            this.pnlContable.Controls.Add(this.label15);
            this.pnlContable.Location = new System.Drawing.Point(3, 491);
            this.pnlContable.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContable.Name = "pnlContable";
            this.pnlContable.Size = new System.Drawing.Size(498, 53);
            this.pnlContable.TabIndex = 504;
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
            this.labelDegradado3.Size = new System.Drawing.Size(496, 17);
            this.labelDegradado3.TabIndex = 274;
            this.labelDegradado3.Text = "Datos Contables";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProgramaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 547);
            this.Controls.Add(this.pnlContable);
            this.Controls.Add(this.pnlAuxiliar);
            this.Controls.Add(this.pnlEmpresa);
            this.Controls.Add(this.pnlDatos);
            this.MaximizeBox = false;
            this.Name = "frmProgramaPago";
            this.Text = "Programa de Pagos";
            this.Load += new System.EventHandler(this.frmProgramaPago_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlEmpresa.ResumeLayout(false);
            this.pnlEmpresa.PerformLayout();
            this.pnlAuxiliar.ResumeLayout(false);
            this.pnlAuxiliar.PerformLayout();
            this.pnlContable.ResumeLayout(false);
            this.pnlContable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.ComboBox cboOperacion;
        private System.Windows.Forms.TextBox txtTica;
        private System.Windows.Forms.TextBox txtFecEmision;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtDesBeneficiario;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtGrupo;
        private System.Windows.Forms.TextBox txtFecVencimiento;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtMontoOrigen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdMoneda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.TextBox txtEgreso;
        private System.Windows.Forms.Label label14;
        private ControlesWinForm.SuperTextBox txtGlosa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNumCheque;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cboCuenta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMonedaPago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlEmpresa;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Panel pnlAuxiliar;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboBancosProveedor;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboCuentasProveedor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel pnlContable;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.TextBox txtIdAuxiliar;
        private System.Windows.Forms.ComboBox cboTipoCuenta;
        private System.Windows.Forms.Label label17;
        private ControlesWinForm.SuperTextBox txtMonto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboDocumento;
        private System.Windows.Forms.ComboBox cboConceptos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSerieBanco;
        private System.Windows.Forms.TextBox txtNumeroBanco;
        private System.Windows.Forms.ComboBox cboDocumentoBanco;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpFecPago;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.CheckBox chkComision;
        private System.Windows.Forms.ComboBox cboConceptoGasto;
        private ControlesWinForm.SuperTextBox txtGasCom;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtCodPartida;
        private System.Windows.Forms.TextBox txtDesPartida;
        private System.Windows.Forms.Button btPresupuesto;
    }
}