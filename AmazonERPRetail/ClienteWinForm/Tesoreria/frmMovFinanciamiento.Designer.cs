namespace ClienteWinForm.Tesoreria
{
    partial class frmMovFinanciamiento
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
            this.btCronograma = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtImporteCred = new ControlesWinForm.SuperTextBox();
            this.txtComisionVarios = new ControlesWinForm.SuperTextBox();
            this.cboPeriodicidad = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCuotaPago = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtImporDesem = new ControlesWinForm.SuperTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCuotas = new ControlesWinForm.SuperTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPlazo = new ControlesWinForm.SuperTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTea = new ControlesWinForm.SuperTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDesgravamen = new ControlesWinForm.SuperTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPortes = new ControlesWinForm.SuperTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtComision = new ControlesWinForm.SuperTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImporSol = new ControlesWinForm.SuperTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.pnlPrincipales = new System.Windows.Forms.Panel();
            this.lblFin = new System.Windows.Forms.Label();
            this.txtIdFinanciamiento = new ControlesWinForm.SuperTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBancosEmpresa = new System.Windows.Forms.ComboBox();
            this.txtNumDocumento = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodMov = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboLineaCredito = new System.Windows.Forms.ComboBox();
            this.cboCuentasBancarias = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel1.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlPrincipales.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCronograma
            // 
            this.btCronograma.BackgroundImage = global::ClienteWinForm.Properties.Resources.Periodo_Contable;
            this.btCronograma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCronograma.Enabled = false;
            this.btCronograma.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCronograma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCronograma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCronograma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCronograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCronograma.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCronograma.Location = new System.Drawing.Point(676, 154);
            this.btCronograma.Name = "btCronograma";
            this.btCronograma.Size = new System.Drawing.Size(114, 62);
            this.btCronograma.TabIndex = 20;
            this.btCronograma.TabStop = false;
            this.btCronograma.Text = "Ver Cronograma";
            this.btCronograma.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCronograma.UseVisualStyleBackColor = true;
            this.btCronograma.Click += new System.EventHandler(this.btCronograma_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtImporteCred);
            this.panel1.Controls.Add(this.txtComisionVarios);
            this.panel1.Controls.Add(this.cboPeriodicidad);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtCuotaPago);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtImporDesem);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.txtCuotas);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtPlazo);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtTea);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtDesgravamen);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtPortes);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtComision);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtImporSol);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(4, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 100);
            this.panel1.TabIndex = 376;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(488, 74);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 13);
            this.label24.TabIndex = 379;
            this.label24.Text = "Importe Créd.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(477, 28);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 379;
            this.label23.Text = "Periocidad";
            // 
            // txtImporteCred
            // 
            this.txtImporteCred.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporteCred.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtImporteCred.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporteCred.Enabled = false;
            this.txtImporteCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteCred.Location = new System.Drawing.Point(562, 70);
            this.txtImporteCred.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporteCred.Name = "txtImporteCred";
            this.txtImporteCred.Size = new System.Drawing.Size(89, 20);
            this.txtImporteCred.TabIndex = 378;
            this.txtImporteCred.TabStop = false;
            this.txtImporteCred.Text = "0.00";
            this.txtImporteCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteCred.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporteCred.TextoVacio = "Digite ID";
            // 
            // txtComisionVarios
            // 
            this.txtComisionVarios.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtComisionVarios.BackColor = System.Drawing.Color.White;
            this.txtComisionVarios.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtComisionVarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComisionVarios.Location = new System.Drawing.Point(416, 24);
            this.txtComisionVarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtComisionVarios.Name = "txtComisionVarios";
            this.txtComisionVarios.Size = new System.Drawing.Size(56, 20);
            this.txtComisionVarios.TabIndex = 11;
            this.txtComisionVarios.Text = "0.00";
            this.txtComisionVarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComisionVarios.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtComisionVarios.TextoVacio = "<Descripcion>";
            this.txtComisionVarios.TextChanged += new System.EventHandler(this.txtComisionVarios_TextChanged);
            this.txtComisionVarios.Leave += new System.EventHandler(this.txtComisionVarios_Leave);
            // 
            // cboPeriodicidad
            // 
            this.cboPeriodicidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodicidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodicidad.FormattingEnabled = true;
            this.cboPeriodicidad.Location = new System.Drawing.Point(539, 24);
            this.cboPeriodicidad.Name = "cboPeriodicidad";
            this.cboPeriodicidad.Size = new System.Drawing.Size(112, 21);
            this.cboPeriodicidad.TabIndex = 12;
            this.cboPeriodicidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPeriodicidad_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(332, 28);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 377;
            this.label18.Text = "Comisión Varios";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(429, 51);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 375;
            this.label13.Text = "%";
            // 
            // txtCuotaPago
            // 
            this.txtCuotaPago.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuotaPago.BackColor = System.Drawing.Color.White;
            this.txtCuotaPago.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuotaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotaPago.Location = new System.Drawing.Point(272, 70);
            this.txtCuotaPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuotaPago.Name = "txtCuotaPago";
            this.txtCuotaPago.Size = new System.Drawing.Size(86, 20);
            this.txtCuotaPago.TabIndex = 19;
            this.txtCuotaPago.Text = "0.00";
            this.txtCuotaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCuotaPago.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCuotaPago.TextoVacio = "<Descripcion>";
            this.txtCuotaPago.Leave += new System.EventHandler(this.txtCuotaPago_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(196, 74);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 13);
            this.label22.TabIndex = 373;
            this.label22.Text = "Cuota a pagar";
            // 
            // txtImporDesem
            // 
            this.txtImporDesem.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporDesem.BackColor = System.Drawing.Color.White;
            this.txtImporDesem.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporDesem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporDesem.Location = new System.Drawing.Point(103, 70);
            this.txtImporDesem.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporDesem.Name = "txtImporDesem";
            this.txtImporDesem.Size = new System.Drawing.Size(86, 20);
            this.txtImporDesem.TabIndex = 18;
            this.txtImporDesem.Text = "0.00";
            this.txtImporDesem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporDesem.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporDesem.TextoVacio = "<Descripcion>";
            this.txtImporDesem.Leave += new System.EventHandler(this.txtImporDesem_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 74);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 13);
            this.label21.TabIndex = 371;
            this.label21.Text = "Importe Desemb.";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCuotas.BackColor = System.Drawing.Color.White;
            this.txtCuotas.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotas.Location = new System.Drawing.Point(596, 47);
            this.txtCuotas.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(55, 20);
            this.txtCuotas.TabIndex = 17;
            this.txtCuotas.Text = "0";
            this.txtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCuotas.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCuotas.TextoVacio = "<Descripcion>";
            this.txtCuotas.TextChanged += new System.EventHandler(this.txtCuotas_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(552, 51);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 369;
            this.label20.Text = "Cuotas";
            // 
            // txtPlazo
            // 
            this.txtPlazo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPlazo.BackColor = System.Drawing.Color.White;
            this.txtPlazo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPlazo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlazo.Location = new System.Drawing.Point(491, 47);
            this.txtPlazo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.Size = new System.Drawing.Size(55, 20);
            this.txtPlazo.TabIndex = 16;
            this.txtPlazo.Text = "0";
            this.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlazo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtPlazo.TextoVacio = "<Descripcion>";
            this.txtPlazo.TextChanged += new System.EventHandler(this.txtPlazo_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(455, 51);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 13);
            this.label19.TabIndex = 367;
            this.label19.Text = "Plazo";
            // 
            // txtTea
            // 
            this.txtTea.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTea.BackColor = System.Drawing.Color.White;
            this.txtTea.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTea.Location = new System.Drawing.Point(372, 47);
            this.txtTea.Margin = new System.Windows.Forms.Padding(2);
            this.txtTea.Name = "txtTea";
            this.txtTea.Size = new System.Drawing.Size(55, 20);
            this.txtTea.TabIndex = 15;
            this.txtTea.Text = "0.00";
            this.txtTea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTea.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTea.TextoVacio = "<Descripcion>";
            this.txtTea.TextChanged += new System.EventHandler(this.txtTea_TextChanged);
            this.txtTea.Leave += new System.EventHandler(this.txtTea_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(332, 51);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 365;
            this.label16.Text = "T.E.A.";
            // 
            // txtDesgravamen
            // 
            this.txtDesgravamen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesgravamen.BackColor = System.Drawing.Color.White;
            this.txtDesgravamen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesgravamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesgravamen.Location = new System.Drawing.Point(272, 47);
            this.txtDesgravamen.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesgravamen.Name = "txtDesgravamen";
            this.txtDesgravamen.Size = new System.Drawing.Size(56, 20);
            this.txtDesgravamen.TabIndex = 14;
            this.txtDesgravamen.Text = "0.00";
            this.txtDesgravamen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesgravamen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDesgravamen.TextoVacio = "<Descripcion>";
            this.txtDesgravamen.Leave += new System.EventHandler(this.txtDesgravamen_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(172, 51);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 363;
            this.label15.Text = "Seg. Desgravamen";
            // 
            // txtPortes
            // 
            this.txtPortes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPortes.BackColor = System.Drawing.Color.White;
            this.txtPortes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPortes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortes.Location = new System.Drawing.Point(104, 47);
            this.txtPortes.Margin = new System.Windows.Forms.Padding(2);
            this.txtPortes.Name = "txtPortes";
            this.txtPortes.Size = new System.Drawing.Size(67, 20);
            this.txtPortes.TabIndex = 13;
            this.txtPortes.Text = "0.00";
            this.txtPortes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPortes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPortes.TextoVacio = "<Descripcion>";
            this.txtPortes.TextChanged += new System.EventHandler(this.txtPortes_TextChanged);
            this.txtPortes.Leave += new System.EventHandler(this.txtPortes_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 51);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 361;
            this.label14.Text = "Portes";
            // 
            // txtComision
            // 
            this.txtComision.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtComision.BackColor = System.Drawing.Color.White;
            this.txtComision.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComision.Location = new System.Drawing.Point(272, 24);
            this.txtComision.Margin = new System.Windows.Forms.Padding(2);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(56, 20);
            this.txtComision.TabIndex = 10;
            this.txtComision.Text = "0.00";
            this.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComision.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtComision.TextoVacio = "<Descripcion>";
            this.txtComision.TextChanged += new System.EventHandler(this.txtComision_TextChanged);
            this.txtComision.Leave += new System.EventHandler(this.txtComision_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(176, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 359;
            this.label12.Text = "Comisión Desemb.";
            // 
            // txtImporSol
            // 
            this.txtImporSol.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporSol.BackColor = System.Drawing.Color.White;
            this.txtImporSol.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporSol.Location = new System.Drawing.Point(104, 24);
            this.txtImporSol.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporSol.Name = "txtImporSol";
            this.txtImporSol.Size = new System.Drawing.Size(67, 20);
            this.txtImporSol.TabIndex = 9;
            this.txtImporSol.Text = "0.00";
            this.txtImporSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporSol.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporSol.TextoVacio = "<Descripcion>";
            this.txtImporSol.TextChanged += new System.EventHandler(this.txtImporSol_TextChanged);
            this.txtImporSol.Leave += new System.EventHandler(this.txtImporSol_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 28);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 13);
            this.label17.TabIndex = 357;
            this.label17.Text = "Importe Solicitado";
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
            this.labelDegradado1.Size = new System.Drawing.Size(665, 18);
            this.labelDegradado1.TabIndex = 270;
            this.labelDegradado1.Text = "Montos";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(528, 4);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(263, 123);
            this.pnlAuditoria.TabIndex = 139;
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
            this.labelDegradado5.Size = new System.Drawing.Size(261, 18);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(10, 95);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(117, 91);
            this.txtFechaModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(133, 20);
            this.txtFechaModifica.TabIndex = 0;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(117, 47);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFechaRegistro.TabIndex = 0;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 25);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 69);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // pnlPrincipales
            // 
            this.pnlPrincipales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipales.Controls.Add(this.lblFin);
            this.pnlPrincipales.Controls.Add(this.txtIdFinanciamiento);
            this.pnlPrincipales.Controls.Add(this.label11);
            this.pnlPrincipales.Controls.Add(this.dtpVencimiento);
            this.pnlPrincipales.Controls.Add(this.label9);
            this.pnlPrincipales.Controls.Add(this.cboMonedas);
            this.pnlPrincipales.Controls.Add(this.label7);
            this.pnlPrincipales.Controls.Add(this.label5);
            this.pnlPrincipales.Controls.Add(this.cboBancosEmpresa);
            this.pnlPrincipales.Controls.Add(this.txtNumDocumento);
            this.pnlPrincipales.Controls.Add(this.label1);
            this.pnlPrincipales.Controls.Add(this.txtCodMov);
            this.pnlPrincipales.Controls.Add(this.label10);
            this.pnlPrincipales.Controls.Add(this.label8);
            this.pnlPrincipales.Controls.Add(this.dtpFecha);
            this.pnlPrincipales.Controls.Add(this.cboLineaCredito);
            this.pnlPrincipales.Controls.Add(this.cboCuentasBancarias);
            this.pnlPrincipales.Controls.Add(this.label6);
            this.pnlPrincipales.Controls.Add(this.labelDegradado2);
            this.pnlPrincipales.Location = new System.Drawing.Point(4, 4);
            this.pnlPrincipales.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipales.Name = "pnlPrincipales";
            this.pnlPrincipales.Size = new System.Drawing.Size(521, 123);
            this.pnlPrincipales.TabIndex = 138;
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFin.Location = new System.Drawing.Point(428, 97);
            this.lblFin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(30, 13);
            this.lblFin.TabIndex = 377;
            this.lblFin.Text = "ID.F.";
            this.lblFin.Visible = false;
            // 
            // txtIdFinanciamiento
            // 
            this.txtIdFinanciamiento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdFinanciamiento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdFinanciamiento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdFinanciamiento.Enabled = false;
            this.txtIdFinanciamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdFinanciamiento.Location = new System.Drawing.Point(461, 93);
            this.txtIdFinanciamiento.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdFinanciamiento.Name = "txtIdFinanciamiento";
            this.txtIdFinanciamiento.Size = new System.Drawing.Size(42, 20);
            this.txtIdFinanciamiento.TabIndex = 376;
            this.txtIdFinanciamiento.TabStop = false;
            this.txtIdFinanciamiento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdFinanciamiento.TextoVacio = "Digite ID";
            this.txtIdFinanciamiento.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(213, 97);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 375;
            this.label11.Text = "Fecha de Venc.";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(299, 93);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(96, 20);
            this.dtpVencimiento.TabIndex = 8;
            this.dtpVencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpVencimiento_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 74);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 373;
            this.label9.Text = "Moneda";
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Enabled = false;
            this.cboMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(113, 70);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(66, 21);
            this.cboMonedas.TabIndex = 5;
            this.cboMonedas.SelectionChangeCommitted += new System.EventHandler(this.cboMonedas_SelectionChangeCommitted);
            this.cboMonedas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMonedas_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(185, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 370;
            this.label7.Text = "N° de cuenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 369;
            this.label5.Text = "Entidad Financiera";
            // 
            // cboBancosEmpresa
            // 
            this.cboBancosEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosEmpresa.DropDownWidth = 150;
            this.cboBancosEmpresa.Enabled = false;
            this.cboBancosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosEmpresa.FormattingEnabled = true;
            this.cboBancosEmpresa.Location = new System.Drawing.Point(113, 47);
            this.cboBancosEmpresa.Name = "cboBancosEmpresa";
            this.cboBancosEmpresa.Size = new System.Drawing.Size(390, 21);
            this.cboBancosEmpresa.TabIndex = 4;
            this.cboBancosEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cboBancosEmpresa_SelectionChangeCommitted);
            this.cboBancosEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBancosEmpresa_KeyPress);
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDocumento.BackColor = System.Drawing.Color.White;
            this.txtNumDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDocumento.Location = new System.Drawing.Point(241, 24);
            this.txtNumDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(129, 20);
            this.txtNumDocumento.TabIndex = 2;
            this.txtNumDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumDocumento.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 357;
            this.label1.Text = "Docu. N°";
            // 
            // txtCodMov
            // 
            this.txtCodMov.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodMov.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodMov.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodMov.Enabled = false;
            this.txtCodMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMov.Location = new System.Drawing.Point(428, 24);
            this.txtCodMov.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodMov.Name = "txtCodMov";
            this.txtCodMov.Size = new System.Drawing.Size(75, 20);
            this.txtCodMov.TabIndex = 3;
            this.txtCodMov.TabStop = false;
            this.txtCodMov.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodMov.TextoVacio = "Digite ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(372, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 354;
            this.label10.Text = "Cód. Mov.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 348;
            this.label8.Text = "Fecha de Emisión";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(114, 93);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha.TabIndex = 7;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // cboLineaCredito
            // 
            this.cboLineaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineaCredito.DropDownWidth = 85;
            this.cboLineaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLineaCredito.FormattingEnabled = true;
            this.cboLineaCredito.Location = new System.Drawing.Point(113, 24);
            this.cboLineaCredito.Name = "cboLineaCredito";
            this.cboLineaCredito.Size = new System.Drawing.Size(76, 21);
            this.cboLineaCredito.TabIndex = 1;
            this.cboLineaCredito.SelectionChangeCommitted += new System.EventHandler(this.cboLineaCredito_SelectionChangeCommitted);
            this.cboLineaCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLineaCredito_KeyPress);
            // 
            // cboCuentasBancarias
            // 
            this.cboCuentasBancarias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentasBancarias.Enabled = false;
            this.cboCuentasBancarias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuentasBancarias.FormattingEnabled = true;
            this.cboCuentasBancarias.Location = new System.Drawing.Point(259, 70);
            this.cboCuentasBancarias.Name = "cboCuentasBancarias";
            this.cboCuentasBancarias.Size = new System.Drawing.Size(244, 21);
            this.cboCuentasBancarias.TabIndex = 6;
            this.cboCuentasBancarias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCuentasBancarias_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 290;
            this.label6.Text = "Tipo Linea Créd.";
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
            this.labelDegradado2.Size = new System.Drawing.Size(519, 18);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMovFinanciamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 233);
            this.Controls.Add(this.btCronograma);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlPrincipales);
            this.MaximizeBox = false;
            this.Name = "frmMovFinanciamiento";
            this.Text = "Movimiento Financiero(Nuevo)";
            this.Load += new System.EventHandler(this.frmMovFinanciamiento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlPrincipales.ResumeLayout(false);
            this.pnlPrincipales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipales;
        private ControlesWinForm.SuperTextBox txtCodMov;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboLineaCredito;
        private System.Windows.Forms.ComboBox cboCuentasBancarias;
        private System.Windows.Forms.Label label6;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private ControlesWinForm.SuperTextBox txtNumDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBancosEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private ControlesWinForm.SuperTextBox txtCuotaPago;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtImporDesem;
        private System.Windows.Forms.Label label21;
        private ControlesWinForm.SuperTextBox txtCuotas;
        private System.Windows.Forms.Label label20;
        private ControlesWinForm.SuperTextBox txtPlazo;
        private System.Windows.Forms.Label label19;
        private ControlesWinForm.SuperTextBox txtTea;
        private System.Windows.Forms.Label label16;
        private ControlesWinForm.SuperTextBox txtDesgravamen;
        private System.Windows.Forms.Label label15;
        private ControlesWinForm.SuperTextBox txtPortes;
        private System.Windows.Forms.Label label14;
        private ControlesWinForm.SuperTextBox txtComision;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtImporSol;
        private System.Windows.Forms.Label label17;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btCronograma;
        private ControlesWinForm.SuperTextBox txtIdFinanciamiento;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label label23;
        private ControlesWinForm.SuperTextBox txtComisionVarios;
        private System.Windows.Forms.ComboBox cboPeriodicidad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private ControlesWinForm.SuperTextBox txtImporteCred;
    }
}