namespace ClienteWinForm.Contabilidad
{
    partial class frmReciboHonorariosComprobante
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
            System.Windows.Forms.Label glosaGeneralLabel;
            System.Windows.Forms.Label codMonedaProvisionLabel1;
            System.Windows.Forms.Label idArticuloLabel;
            this.txtGlosa = new ControlesWinForm.SuperTextBox();
            this.txtGasto = new ControlesWinForm.SuperTextBox();
            this.txtdesGasto = new System.Windows.Forms.TextBox();
            this.txtCosto = new ControlesWinForm.SuperTextBox();
            this.btnCosto = new System.Windows.Forms.Button();
            this.txtdesCosto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecRecibo = new System.Windows.Forms.DateTimePicker();
            this.txtImporte = new ControlesWinForm.SuperTextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.pnlRetenciones = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCuartaCat = new ControlesWinForm.SuperTextBox();
            this.chbCuarta = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPorRetencion = new ControlesWinForm.SuperTextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFecPago = new System.Windows.Forms.DateTimePicker();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txttipocambio = new ControlesWinForm.SuperTextBox();
            this.dtpOperacion = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.btCosto = new System.Windows.Forms.Button();
            this.txtNumHojaCosto = new ControlesWinForm.SuperTextBox();
            this.chkIndCosto = new System.Windows.Forms.CheckBox();
            this.cboCuentas = new System.Windows.Forms.ComboBox();
            this.txtIdConcepto = new ControlesWinForm.SuperTextBox();
            this.btBuscarConcepto = new System.Windows.Forms.Button();
            this.txtCodConcepto = new ControlesWinForm.SuperTextBox();
            this.txtDesConcepto = new ControlesWinForm.SuperTextBox();
            glosaGeneralLabel = new System.Windows.Forms.Label();
            codMonedaProvisionLabel1 = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlRetenciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(574, 284);
            this.btCancelar.Size = new System.Drawing.Size(112, 28);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(450, 284);
            this.btAceptar.Size = new System.Drawing.Size(112, 28);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(693, 19);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(709, 25);
            this.lblTituloPrincipal.Text = "Recibo Honorario Comp.";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(681, 2);
            this.btCerrar.Visible = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(codMonedaProvisionLabel1);
            this.pnlBase.Controls.Add(this.cboCuentas);
            this.pnlBase.Controls.Add(this.txtIdConcepto);
            this.pnlBase.Controls.Add(this.btBuscarConcepto);
            this.pnlBase.Controls.Add(this.label14);
            this.pnlBase.Controls.Add(this.txtCodConcepto);
            this.pnlBase.Controls.Add(this.txtFecPago);
            this.pnlBase.Controls.Add(this.txtDesConcepto);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Controls.Add(this.btCosto);
            this.pnlBase.Controls.Add(this.txtFormula);
            this.pnlBase.Controls.Add(this.label15);
            this.pnlBase.Controls.Add(this.dtpOperacion);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.txtNumHojaCosto);
            this.pnlBase.Controls.Add(this.chkIndCosto);
            this.pnlBase.Controls.Add(this.txttipocambio);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(glosaGeneralLabel);
            this.pnlBase.Controls.Add(this.txtGlosa);
            this.pnlBase.Controls.Add(this.txtGasto);
            this.pnlBase.Controls.Add(this.cboTipoDocumento);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.txtdesGasto);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.txtCosto);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Controls.Add(this.btnCosto);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txtdesCosto);
            this.pnlBase.Controls.Add(this.txtNumero);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.txtImporte);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.txtFecRecibo);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(695, 233);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFecRecibo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtImporte, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumero, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtdesCosto, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.btnCosto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCosto, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtdesGasto, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtGasto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtGlosa, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(glosaGeneralLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.txttipocambio, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkIndCosto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumHojaCosto, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpOperacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label15, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFormula, 0);
            this.pnlBase.Controls.SetChildIndex(this.btCosto, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFecPago, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.label14, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboCuentas, 0);
            this.pnlBase.Controls.SetChildIndex(codMonedaProvisionLabel1, 0);
            // 
            // glosaGeneralLabel
            // 
            glosaGeneralLabel.AutoSize = true;
            glosaGeneralLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            glosaGeneralLabel.Location = new System.Drawing.Point(18, 185);
            glosaGeneralLabel.Name = "glosaGeneralLabel";
            glosaGeneralLabel.Size = new System.Drawing.Size(34, 13);
            glosaGeneralLabel.TabIndex = 339;
            glosaGeneralLabel.Text = "Glosa";
            // 
            // codMonedaProvisionLabel1
            // 
            codMonedaProvisionLabel1.AutoSize = true;
            codMonedaProvisionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codMonedaProvisionLabel1.Location = new System.Drawing.Point(18, 97);
            codMonedaProvisionLabel1.Name = "codMonedaProvisionLabel1";
            codMonedaProvisionLabel1.Size = new System.Drawing.Size(65, 13);
            codMonedaProvisionLabel1.TabIndex = 396;
            codMonedaProvisionLabel1.Text = "Tipo Cuenta";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(18, 74);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(53, 13);
            idArticuloLabel.TabIndex = 392;
            idArticuloLabel.Text = "Concepto";
            // 
            // txtGlosa
            // 
            this.txtGlosa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGlosa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGlosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGlosa.Location = new System.Drawing.Point(101, 161);
            this.txtGlosa.Multiline = true;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGlosa.Size = new System.Drawing.Size(576, 61);
            this.txtGlosa.TabIndex = 13;
            this.txtGlosa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGlosa.TextoVacio = "<Descripcion>";
            // 
            // txtGasto
            // 
            this.txtGasto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGasto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGasto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGasto.Enabled = false;
            this.txtGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGasto.Location = new System.Drawing.Point(101, 116);
            this.txtGasto.Name = "txtGasto";
            this.txtGasto.Size = new System.Drawing.Size(84, 20);
            this.txtGasto.TabIndex = 335;
            this.txtGasto.TabStop = false;
            this.txtGasto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGasto.TextoVacio = "<Descripcion>";
            // 
            // txtdesGasto
            // 
            this.txtdesGasto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdesGasto.Enabled = false;
            this.txtdesGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesGasto.Location = new System.Drawing.Point(185, 116);
            this.txtdesGasto.Name = "txtdesGasto";
            this.txtdesGasto.Size = new System.Drawing.Size(492, 20);
            this.txtdesGasto.TabIndex = 336;
            this.txtdesGasto.TabStop = false;
            // 
            // txtCosto
            // 
            this.txtCosto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCosto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCosto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCosto.Enabled = false;
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(101, 138);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(84, 20);
            this.txtCosto.TabIndex = 332;
            this.txtCosto.TabStop = false;
            this.txtCosto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCosto.TextoVacio = "<Descripcion>";
            // 
            // btnCosto
            // 
            this.btnCosto.Enabled = false;
            this.btnCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCosto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btnCosto.Location = new System.Drawing.Point(653, 139);
            this.btnCosto.Name = "btnCosto";
            this.btnCosto.Size = new System.Drawing.Size(24, 18);
            this.btnCosto.TabIndex = 334;
            this.btnCosto.UseVisualStyleBackColor = true;
            this.btnCosto.Click += new System.EventHandler(this.btnCosto_Click);
            // 
            // txtdesCosto
            // 
            this.txtdesCosto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdesCosto.Enabled = false;
            this.txtdesCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesCosto.Location = new System.Drawing.Point(186, 138);
            this.txtdesCosto.Name = "txtdesCosto";
            this.txtdesCosto.Size = new System.Drawing.Size(465, 20);
            this.txtdesCosto.TabIndex = 333;
            this.txtdesCosto.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 331;
            this.label8.Text = "Centro Costo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 330;
            this.label7.Text = "Cta. Gasto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 329;
            this.label6.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.DropDownWidth = 110;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(313, 47);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(57, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(372, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 327;
            this.label5.Text = "Importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 326;
            this.label3.Text = "Fecha Recibo";
            // 
            // txtFecRecibo
            // 
            this.txtFecRecibo.CustomFormat = "dd/MM/yyyy";
            this.txtFecRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecRecibo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFecRecibo.Location = new System.Drawing.Point(101, 47);
            this.txtFecRecibo.Name = "txtFecRecibo";
            this.txtFecRecibo.Size = new System.Drawing.Size(83, 20);
            this.txtFecRecibo.TabIndex = 5;
            this.txtFecRecibo.ValueChanged += new System.EventHandler(this.txtFecRecibo_ValueChanged);
            // 
            // txtImporte
            // 
            this.txtImporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(417, 47);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(60, 20);
            this.txtImporte.TabIndex = 7;
            this.txtImporte.Text = "0.00";
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporte.TextoVacio = "";
            this.txtImporte.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtImporte_MouseClick);
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.Enter += new System.EventHandler(this.txtImporte_Enter);
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(561, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(116, 20);
            this.txtNumero.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 272;
            this.label1.Text = "Número";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(449, 24);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(60, 20);
            this.txtSerie.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 270;
            this.label4.Text = "Serie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 268;
            this.label2.Text = "Documento";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.DropDownWidth = 110;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(270, 24);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(140, 21);
            this.cboTipoDocumento.TabIndex = 2;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // pnlRetenciones
            // 
            this.pnlRetenciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRetenciones.Controls.Add(this.label9);
            this.pnlRetenciones.Controls.Add(this.txtCuartaCat);
            this.pnlRetenciones.Controls.Add(this.chbCuarta);
            this.pnlRetenciones.Controls.Add(this.label13);
            this.pnlRetenciones.Controls.Add(this.button2);
            this.pnlRetenciones.Controls.Add(this.txtPorRetencion);
            this.pnlRetenciones.Controls.Add(this.labelDegradado1);
            this.pnlRetenciones.Location = new System.Drawing.Point(7, 264);
            this.pnlRetenciones.Name = "pnlRetenciones";
            this.pnlRetenciones.Size = new System.Drawing.Size(411, 65);
            this.pnlRetenciones.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(233, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 332;
            this.label9.Text = "4º Categoria";
            // 
            // txtCuartaCat
            // 
            this.txtCuartaCat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuartaCat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuartaCat.Enabled = false;
            this.txtCuartaCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuartaCat.Location = new System.Drawing.Point(301, 30);
            this.txtCuartaCat.Name = "txtCuartaCat";
            this.txtCuartaCat.Size = new System.Drawing.Size(70, 20);
            this.txtCuartaCat.TabIndex = 331;
            this.txtCuartaCat.Text = "0.00";
            this.txtCuartaCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCuartaCat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCuartaCat.TextoVacio = "<Descripcion>";
            // 
            // chbCuarta
            // 
            this.chbCuarta.AutoSize = true;
            this.chbCuarta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbCuarta.Enabled = false;
            this.chbCuarta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCuarta.Location = new System.Drawing.Point(7, 32);
            this.chbCuarta.Name = "chbCuarta";
            this.chbCuarta.Size = new System.Drawing.Size(105, 17);
            this.chbCuarta.TabIndex = 330;
            this.chbCuarta.Text = "Cuarta Categoria";
            this.chbCuarta.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(116, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 327;
            this.label13.Text = "% Retención";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, -37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 333;
            // 
            // txtPorRetencion
            // 
            this.txtPorRetencion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorRetencion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorRetencion.Enabled = false;
            this.txtPorRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorRetencion.Location = new System.Drawing.Point(186, 30);
            this.txtPorRetencion.Name = "txtPorRetencion";
            this.txtPorRetencion.Size = new System.Drawing.Size(43, 20);
            this.txtPorRetencion.TabIndex = 324;
            this.txtPorRetencion.Text = "0.00";
            this.txtPorRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorRetencion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorRetencion.TextoVacio = "<Descripcion>";
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
            this.labelDegradado1.Size = new System.Drawing.Size(409, 19);
            this.labelDegradado1.TabIndex = 248;
            this.labelDegradado1.Text = "Retenciones";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(374, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 326;
            this.label14.Text = "Fecha Pago";
            // 
            // txtFecPago
            // 
            this.txtFecPago.CustomFormat = "dd/MM/yyyy";
            this.txtFecPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFecPago.Location = new System.Drawing.Point(442, 93);
            this.txtFecPago.Name = "txtFecPago";
            this.txtFecPago.Size = new System.Drawing.Size(79, 20);
            this.txtFecPago.TabIndex = 11;
            // 
            // txtFormula
            // 
            this.txtFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormula.Location = new System.Drawing.Point(582, 93);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(95, 20);
            this.txtFormula.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(524, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 272;
            this.label15.Text = "Formulario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(188, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 330;
            this.label10.Text = "T.C.";
            // 
            // txttipocambio
            // 
            this.txttipocambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txttipocambio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txttipocambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txttipocambio.Enabled = false;
            this.txttipocambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttipocambio.Location = new System.Drawing.Point(219, 47);
            this.txttipocambio.Margin = new System.Windows.Forms.Padding(2);
            this.txttipocambio.MaxLength = 5;
            this.txttipocambio.Name = "txttipocambio";
            this.txttipocambio.Size = new System.Drawing.Size(42, 20);
            this.txttipocambio.TabIndex = 115;
            this.txttipocambio.TabStop = false;
            this.txttipocambio.Text = "0.000";
            this.txttipocambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttipocambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txttipocambio.TextoVacio = "<Descripcion>";
            // 
            // dtpOperacion
            // 
            this.dtpOperacion.CustomFormat = "dd/MM/yyyy";
            this.dtpOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOperacion.Location = new System.Drawing.Point(101, 24);
            this.dtpOperacion.Name = "dtpOperacion";
            this.dtpOperacion.Size = new System.Drawing.Size(99, 20);
            this.dtpOperacion.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 341;
            this.label11.Text = "Fec. Operación";
            // 
            // btCosto
            // 
            this.btCosto.Enabled = false;
            this.btCosto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCosto.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCosto.Location = new System.Drawing.Point(653, 48);
            this.btCosto.Name = "btCosto";
            this.btCosto.Size = new System.Drawing.Size(24, 18);
            this.btCosto.TabIndex = 386;
            this.btCosto.TabStop = false;
            this.btCosto.UseVisualStyleBackColor = true;
            this.btCosto.Click += new System.EventHandler(this.btCosto_Click);
            // 
            // txtNumHojaCosto
            // 
            this.txtNumHojaCosto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumHojaCosto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumHojaCosto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumHojaCosto.Enabled = false;
            this.txtNumHojaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumHojaCosto.Location = new System.Drawing.Point(561, 47);
            this.txtNumHojaCosto.Name = "txtNumHojaCosto";
            this.txtNumHojaCosto.Size = new System.Drawing.Size(90, 20);
            this.txtNumHojaCosto.TabIndex = 385;
            this.txtNumHojaCosto.TabStop = false;
            this.txtNumHojaCosto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumHojaCosto.TextoVacio = "<Descripcion>";
            // 
            // chkIndCosto
            // 
            this.chkIndCosto.AutoSize = true;
            this.chkIndCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndCosto.Location = new System.Drawing.Point(480, 49);
            this.chkIndCosto.Name = "chkIndCosto";
            this.chkIndCosto.Size = new System.Drawing.Size(78, 17);
            this.chkIndCosto.TabIndex = 384;
            this.chkIndCosto.TabStop = false;
            this.chkIndCosto.Text = "Hoja Costo";
            this.chkIndCosto.UseVisualStyleBackColor = true;
            this.chkIndCosto.CheckedChanged += new System.EventHandler(this.chkIndCosto_CheckedChanged);
            // 
            // cboCuentas
            // 
            this.cboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentas.Enabled = false;
            this.cboCuentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuentas.FormattingEnabled = true;
            this.cboCuentas.Location = new System.Drawing.Point(101, 93);
            this.cboCuentas.Name = "cboCuentas";
            this.cboCuentas.Size = new System.Drawing.Size(173, 21);
            this.cboCuentas.TabIndex = 10;
            this.cboCuentas.SelectionChangeCommitted += new System.EventHandler(this.cboCuentas_SelectionChangeCommitted);
            // 
            // txtIdConcepto
            // 
            this.txtIdConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdConcepto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdConcepto.Enabled = false;
            this.txtIdConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdConcepto.Location = new System.Drawing.Point(101, 70);
            this.txtIdConcepto.Name = "txtIdConcepto";
            this.txtIdConcepto.Size = new System.Drawing.Size(54, 20);
            this.txtIdConcepto.TabIndex = 394;
            this.txtIdConcepto.TabStop = false;
            this.txtIdConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdConcepto.TextoVacio = "<Descripcion>";
            // 
            // btBuscarConcepto
            // 
            this.btBuscarConcepto.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarConcepto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarConcepto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarConcepto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarConcepto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarConcepto.Location = new System.Drawing.Point(653, 71);
            this.btBuscarConcepto.Name = "btBuscarConcepto";
            this.btBuscarConcepto.Size = new System.Drawing.Size(24, 18);
            this.btBuscarConcepto.TabIndex = 393;
            this.btBuscarConcepto.UseVisualStyleBackColor = true;
            this.btBuscarConcepto.Click += new System.EventHandler(this.btBuscarConcepto_Click);
            // 
            // txtCodConcepto
            // 
            this.txtCodConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodConcepto.BackColor = System.Drawing.Color.White;
            this.txtCodConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodConcepto.Location = new System.Drawing.Point(157, 70);
            this.txtCodConcepto.Name = "txtCodConcepto";
            this.txtCodConcepto.Size = new System.Drawing.Size(79, 20);
            this.txtCodConcepto.TabIndex = 8;
            this.txtCodConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodConcepto.TextoVacio = "<Descripcion>";
            this.txtCodConcepto.TextChanged += new System.EventHandler(this.txtCodConcepto_TextChanged);
            // 
            // txtDesConcepto
            // 
            this.txtDesConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesConcepto.BackColor = System.Drawing.Color.White;
            this.txtDesConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesConcepto.Location = new System.Drawing.Point(238, 70);
            this.txtDesConcepto.Name = "txtDesConcepto";
            this.txtDesConcepto.Size = new System.Drawing.Size(413, 20);
            this.txtDesConcepto.TabIndex = 9;
            this.txtDesConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesConcepto.TextoVacio = "<Descripcion>";
            this.txtDesConcepto.TextChanged += new System.EventHandler(this.txtDesConcepto_TextChanged);
            this.txtDesConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesConcepto_Validating);
            // 
            // frmReciboHonorariosComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 334);
            this.Controls.Add(this.pnlRetenciones);
            this.Name = "frmReciboHonorariosComprobante";
            this.Text = "Trabajador Independiente - Recibo por Honorario";
            this.Load += new System.EventHandler(this.frmReciboHonorariosComprobante_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlRetenciones, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlRetenciones.ResumeLayout(false);
            this.pnlRetenciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtImporte;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtFecRecibo;
        private ControlesWinForm.SuperTextBox txtCosto;
        private System.Windows.Forms.Button btnCosto;
        private System.Windows.Forms.TextBox txtdesCosto;
        private ControlesWinForm.SuperTextBox txtGasto;
        private System.Windows.Forms.TextBox txtdesGasto;
        private ControlesWinForm.SuperTextBox txtGlosa;
        private System.Windows.Forms.Panel pnlRetenciones;
        private System.Windows.Forms.CheckBox chbCuarta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker txtFecPago;
        private ControlesWinForm.SuperTextBox txtPorRetencion;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label label15;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtCuartaCat;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txttipocambio;
        private System.Windows.Forms.DateTimePicker dtpOperacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btCosto;
        private ControlesWinForm.SuperTextBox txtNumHojaCosto;
        private System.Windows.Forms.CheckBox chkIndCosto;
        private System.Windows.Forms.ComboBox cboCuentas;
        private ControlesWinForm.SuperTextBox txtIdConcepto;
        private System.Windows.Forms.Button btBuscarConcepto;
        private ControlesWinForm.SuperTextBox txtCodConcepto;
        private ControlesWinForm.SuperTextBox txtDesConcepto;
    }
}