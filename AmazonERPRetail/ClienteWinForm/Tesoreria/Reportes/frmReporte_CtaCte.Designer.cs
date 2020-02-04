namespace ClienteWinForm.Tesoreria.Reportes
{
    partial class frmReporte_CtaCte
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
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkHistorico = new System.Windows.Forms.CheckBox();
            this.txtidauxiliar2 = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocialVen = new ControlesWinForm.SuperTextBox();
            this.txtRucVen = new ControlesWinForm.SuperTextBox();
            this.chbVen = new System.Windows.Forms.CheckBox();
            this.txtIdAuxiliar = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.chbProveedor = new System.Windows.Forms.CheckBox();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbDetalle = new System.Windows.Forms.RadioButton();
            this.rbPorDocumentos = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbCC = new System.Windows.Forms.RadioButton();
            this.rbCLC = new System.Windows.Forms.RadioButton();
            this.rbCPC = new System.Windows.Forms.RadioButton();
            this.rbCCDet = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(700, 19);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(71, 61);
            this.btBuscar.TabIndex = 263;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkHistorico);
            this.panel1.Controls.Add(this.txtidauxiliar2);
            this.panel1.Controls.Add(this.txtRazonSocialVen);
            this.panel1.Controls.Add(this.txtRucVen);
            this.panel1.Controls.Add(this.chbVen);
            this.panel1.Controls.Add(this.txtIdAuxiliar);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.chbProveedor);
            this.panel1.Controls.Add(this.dtpFecIni);
            this.panel1.Controls.Add(this.dtpFecFin);
            this.panel1.Controls.Add(this.lblDe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(187, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 130);
            this.panel1.TabIndex = 262;
            // 
            // chkHistorico
            // 
            this.chkHistorico.AutoSize = true;
            this.chkHistorico.Location = new System.Drawing.Point(419, 93);
            this.chkHistorico.Name = "chkHistorico";
            this.chkHistorico.Size = new System.Drawing.Size(67, 17);
            this.chkHistorico.TabIndex = 318;
            this.chkHistorico.Text = "Historico";
            this.chkHistorico.UseVisualStyleBackColor = true;
            // 
            // txtidauxiliar2
            // 
            this.txtidauxiliar2.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtidauxiliar2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtidauxiliar2.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtidauxiliar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidauxiliar2.Location = new System.Drawing.Point(131, 53);
            this.txtidauxiliar2.Margin = new System.Windows.Forms.Padding(2);
            this.txtidauxiliar2.Name = "txtidauxiliar2";
            this.txtidauxiliar2.Size = new System.Drawing.Size(21, 20);
            this.txtidauxiliar2.TabIndex = 317;
            this.txtidauxiliar2.TabStop = false;
            this.txtidauxiliar2.Text = "0";
            this.txtidauxiliar2.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtidauxiliar2.TextoVacio = "<Descripcion>";
            this.txtidauxiliar2.Visible = false;
            // 
            // txtRazonSocialVen
            // 
            this.txtRazonSocialVen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocialVen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocialVen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocialVen.Enabled = false;
            this.txtRazonSocialVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocialVen.Location = new System.Drawing.Point(254, 55);
            this.txtRazonSocialVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocialVen.Name = "txtRazonSocialVen";
            this.txtRazonSocialVen.Size = new System.Drawing.Size(236, 20);
            this.txtRazonSocialVen.TabIndex = 316;
            this.txtRazonSocialVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocialVen.TextoVacio = "<Descripcion>";
            this.txtRazonSocialVen.Visible = false;
            this.txtRazonSocialVen.TextChanged += new System.EventHandler(this.txtRazonSocialVen_TextChanged);
            this.txtRazonSocialVen.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocialVen_Validating);
            // 
            // txtRucVen
            // 
            this.txtRucVen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucVen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRucVen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucVen.Enabled = false;
            this.txtRucVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucVen.Location = new System.Drawing.Point(156, 55);
            this.txtRucVen.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucVen.Name = "txtRucVen";
            this.txtRucVen.Size = new System.Drawing.Size(95, 20);
            this.txtRucVen.TabIndex = 314;
            this.txtRucVen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucVen.TextoVacio = "<Descripcion>";
            this.txtRucVen.Visible = false;
            this.txtRucVen.TextChanged += new System.EventHandler(this.txtRucVen_TextChanged);
            this.txtRucVen.Validating += new System.ComponentModel.CancelEventHandler(this.txtRucVen_Validating);
            // 
            // chbVen
            // 
            this.chbVen.AutoSize = true;
            this.chbVen.Checked = true;
            this.chbVen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbVen.Location = new System.Drawing.Point(16, 56);
            this.chbVen.Name = "chbVen";
            this.chbVen.Size = new System.Drawing.Size(132, 17);
            this.chbVen.TabIndex = 315;
            this.chbVen.Text = "Todos los Vendedores";
            this.chbVen.UseVisualStyleBackColor = true;
            this.chbVen.Visible = false;
            this.chbVen.CheckedChanged += new System.EventHandler(this.chbVen_CheckedChanged);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(131, 28);
            this.txtIdAuxiliar.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(21, 20);
            this.txtIdAuxiliar.TabIndex = 313;
            this.txtIdAuxiliar.TabStop = false;
            this.txtIdAuxiliar.Text = "0";
            this.txtIdAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdAuxiliar.TextoVacio = "<Descripcion>";
            this.txtIdAuxiliar.Visible = false;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(254, 30);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(236, 20);
            this.txtRazonSocial.TabIndex = 312;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(156, 30);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(95, 20);
            this.txtRuc.TabIndex = 285;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // chbProveedor
            // 
            this.chbProveedor.AutoSize = true;
            this.chbProveedor.Checked = true;
            this.chbProveedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbProveedor.Location = new System.Drawing.Point(16, 31);
            this.chbProveedor.Name = "chbProveedor";
            this.chbProveedor.Size = new System.Drawing.Size(135, 17);
            this.chbProveedor.TabIndex = 311;
            this.chbProveedor.Text = "Todos los Proveedores";
            this.chbProveedor.UseVisualStyleBackColor = true;
            this.chbProveedor.CheckedChanged += new System.EventHandler(this.chbProveedor_CheckedChanged);
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(38, 88);
            this.dtpFecIni.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(79, 20);
            this.dtpFecIni.TabIndex = 304;
            this.dtpFecIni.ValueChanged += new System.EventHandler(this.dtpFecIni_ValueChanged);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(139, 88);
            this.dtpFecFin.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(79, 20);
            this.dtpFecFin.TabIndex = 305;
            this.dtpFecFin.Visible = false;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(13, 92);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(23, 13);
            this.lblDe.TabIndex = 306;
            this.lblDe.Text = "Del";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 307;
            this.label4.Text = "Al";
            this.label4.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
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
            this.labelDegradado1.Size = new System.Drawing.Size(497, 18);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Cuenta Corriente";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbDetalle);
            this.panel2.Controls.Add(this.rbPorDocumentos);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Location = new System.Drawing.Point(917, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 90);
            this.panel2.TabIndex = 261;
            this.panel2.Visible = false;
            // 
            // rbDetalle
            // 
            this.rbDetalle.AutoSize = true;
            this.rbDetalle.Checked = true;
            this.rbDetalle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDetalle.Location = new System.Drawing.Point(16, 55);
            this.rbDetalle.Name = "rbDetalle";
            this.rbDetalle.Size = new System.Drawing.Size(151, 17);
            this.rbDetalle.TabIndex = 260;
            this.rbDetalle.TabStop = true;
            this.rbDetalle.Text = "Por Documentos Detallado";
            this.rbDetalle.UseVisualStyleBackColor = true;
            this.rbDetalle.CheckedChanged += new System.EventHandler(this.rbDetalle_CheckedChanged);
            // 
            // rbPorDocumentos
            // 
            this.rbPorDocumentos.AutoSize = true;
            this.rbPorDocumentos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorDocumentos.Location = new System.Drawing.Point(16, 33);
            this.rbPorDocumentos.Name = "rbPorDocumentos";
            this.rbPorDocumentos.Size = new System.Drawing.Size(152, 17);
            this.rbPorDocumentos.TabIndex = 259;
            this.rbPorDocumentos.Text = "Por Documentos Resumido";
            this.rbPorDocumentos.UseVisualStyleBackColor = true;
            this.rbPorDocumentos.CheckedChanged += new System.EventHandler(this.rbPorDocumentos_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button4.Location = new System.Drawing.Point(1217, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 59);
            this.button4.TabIndex = 154;
            this.button4.Text = "BUSCAR";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
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
            this.labelDegradado2.Size = new System.Drawing.Size(188, 18);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Tipo";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pbProgress);
            this.panel3.Controls.Add(this.wbNavegador);
            this.panel3.Location = new System.Drawing.Point(3, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1104, 343);
            this.panel3.TabIndex = 267;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbProgress.BackColor = System.Drawing.Color.White;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(496, 118);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(120, 105);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 325;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1102, 341);
            this.wbNavegador.TabIndex = 268;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rbCC);
            this.panel4.Controls.Add(this.rbCLC);
            this.panel4.Controls.Add(this.rbCPC);
            this.panel4.Controls.Add(this.rbCCDet);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.labelDegradado3);
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(177, 130);
            this.panel4.TabIndex = 268;
            // 
            // rbCC
            // 
            this.rbCC.AutoSize = true;
            this.rbCC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCC.Location = new System.Drawing.Point(7, 101);
            this.rbCC.Name = "rbCC";
            this.rbCC.Size = new System.Drawing.Size(108, 17);
            this.rbCC.TabIndex = 262;
            this.rbCC.Text = "Cuenta Corriente";
            this.rbCC.UseVisualStyleBackColor = true;
            this.rbCC.CheckedChanged += new System.EventHandler(this.rbCC_CheckedChanged);
            // 
            // rbCLC
            // 
            this.rbCLC.AutoSize = true;
            this.rbCLC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCLC.Location = new System.Drawing.Point(7, 78);
            this.rbCLC.Name = "rbCLC";
            this.rbCLC.Size = new System.Drawing.Size(108, 17);
            this.rbCLC.TabIndex = 261;
            this.rbCLC.Text = "Control de Letras";
            this.rbCLC.UseVisualStyleBackColor = true;
            this.rbCLC.CheckedChanged += new System.EventHandler(this.rbCLC_CheckedChanged);
            // 
            // rbCPC
            // 
            this.rbCPC.AutoSize = true;
            this.rbCPC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCPC.Location = new System.Drawing.Point(7, 55);
            this.rbCPC.Name = "rbCPC";
            this.rbCPC.Size = new System.Drawing.Size(155, 17);
            this.rbCPC.TabIndex = 260;
            this.rbCPC.Text = "Cuenta Corriente Resumen";
            this.rbCPC.UseVisualStyleBackColor = true;
            this.rbCPC.CheckedChanged += new System.EventHandler(this.rbCPC_CheckedChanged);
            // 
            // rbCCDet
            // 
            this.rbCCDet.AutoSize = true;
            this.rbCCDet.Checked = true;
            this.rbCCDet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCCDet.Location = new System.Drawing.Point(7, 33);
            this.rbCCDet.Name = "rbCCDet";
            this.rbCCDet.Size = new System.Drawing.Size(156, 17);
            this.rbCCDet.TabIndex = 259;
            this.rbCCDet.TabStop = true;
            this.rbCCDet.Text = "Cuenta Corriente Detallada";
            this.rbCCDet.UseVisualStyleBackColor = true;
            this.rbCCDet.CheckedChanged += new System.EventHandler(this.rbCCDet_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button2.Location = new System.Drawing.Point(1217, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 59);
            this.button2.TabIndex = 154;
            this.button2.Text = "BUSCAR";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
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
            this.labelDegradado3.Size = new System.Drawing.Size(175, 18);
            this.labelDegradado3.TabIndex = 258;
            this.labelDegradado3.Text = "Reportes";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReporte_CtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1114, 486);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReporte_CtaCte";
            this.Text = "Estado de Cta. Cte.";
            this.Load += new System.EventHandler(this.frmReporteCtaCte_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbPorDocumentos;
        protected internal System.Windows.Forms.Button button4;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel1;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.RadioButton rbDetalle;
        private System.Windows.Forms.CheckBox chbProveedor;
        private System.Windows.Forms.PictureBox pbProgress;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdAuxiliar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbCPC;
        private System.Windows.Forms.RadioButton rbCCDet;
        protected internal System.Windows.Forms.Button button2;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.RadioButton rbCC;
        private System.Windows.Forms.RadioButton rbCLC;
        private ControlesWinForm.SuperTextBox txtidauxiliar2;
        private ControlesWinForm.SuperTextBox txtRazonSocialVen;
        private ControlesWinForm.SuperTextBox txtRucVen;
        private System.Windows.Forms.CheckBox chbVen;
        private System.Windows.Forms.CheckBox chkHistorico;
    }
}