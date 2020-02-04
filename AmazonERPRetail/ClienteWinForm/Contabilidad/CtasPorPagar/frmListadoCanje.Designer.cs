namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmListadoCanje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoCanje));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCanje = new System.Windows.Forms.DataGridView();
            this.fechaCanjeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCanjeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoCanjeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLetras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCerrarCanje = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbrirCanje = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImprimeVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsCanje = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtIdAuxiliar = new ControlesWinForm.SuperTextBox();
            this.rbTodosCLientes = new System.Windows.Forms.RadioButton();
            this.rbUnCliente = new System.Windows.Forms.RadioButton();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanje)).BeginInit();
            this.cmsPopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCanje)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCanje);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 367);
            this.panel1.TabIndex = 76;
            // 
            // dgvCanje
            // 
            this.dgvCanje.AllowUserToAddRows = false;
            this.dgvCanje.AllowUserToDeleteRows = false;
            this.dgvCanje.AutoGenerateColumns = false;
            this.dgvCanje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaCanjeDataGridViewTextBoxColumn,
            this.numCanjeDataGridViewTextBoxColumn,
            this.RazonSocial,
            this.desMoneda,
            this.tipoCambioDataGridViewTextBoxColumn,
            this.montoCanjeDataGridViewTextBoxColumn,
            this.numLetras,
            this.desEstado,
            this.idComprobante,
            this.numFile,
            this.numVoucher,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.Estado});
            this.dgvCanje.ContextMenuStrip = this.cmsPopup;
            this.dgvCanje.DataSource = this.bsCanje;
            this.dgvCanje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCanje.EnableHeadersVisualStyles = false;
            this.dgvCanje.Location = new System.Drawing.Point(0, 16);
            this.dgvCanje.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCanje.Name = "dgvCanje";
            this.dgvCanje.ReadOnly = true;
            this.dgvCanje.RowTemplate.Height = 24;
            this.dgvCanje.Size = new System.Drawing.Size(962, 349);
            this.dgvCanje.TabIndex = 80;
            this.dgvCanje.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCanje_CellDoubleClick);
            this.dgvCanje.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCanje_CellFormatting);
            // 
            // fechaCanjeDataGridViewTextBoxColumn
            // 
            this.fechaCanjeDataGridViewTextBoxColumn.DataPropertyName = "FechaCanje";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.fechaCanjeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaCanjeDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaCanjeDataGridViewTextBoxColumn.Name = "fechaCanjeDataGridViewTextBoxColumn";
            this.fechaCanjeDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCanjeDataGridViewTextBoxColumn.Width = 70;
            // 
            // numCanjeDataGridViewTextBoxColumn
            // 
            this.numCanjeDataGridViewTextBoxColumn.DataPropertyName = "numCanje";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numCanjeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.numCanjeDataGridViewTextBoxColumn.HeaderText = "N° Canje";
            this.numCanjeDataGridViewTextBoxColumn.Name = "numCanjeDataGridViewTextBoxColumn";
            this.numCanjeDataGridViewTextBoxColumn.ReadOnly = true;
            this.numCanjeDataGridViewTextBoxColumn.Width = 80;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Proveedor";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 250;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 40;
            // 
            // tipoCambioDataGridViewTextBoxColumn
            // 
            this.tipoCambioDataGridViewTextBoxColumn.DataPropertyName = "TipoCambio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.tipoCambioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tipoCambioDataGridViewTextBoxColumn.HeaderText = "Tip.Cam.";
            this.tipoCambioDataGridViewTextBoxColumn.Name = "tipoCambioDataGridViewTextBoxColumn";
            this.tipoCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCambioDataGridViewTextBoxColumn.Width = 50;
            // 
            // montoCanjeDataGridViewTextBoxColumn
            // 
            this.montoCanjeDataGridViewTextBoxColumn.DataPropertyName = "MontoCanje";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.montoCanjeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.montoCanjeDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoCanjeDataGridViewTextBoxColumn.Name = "montoCanjeDataGridViewTextBoxColumn";
            this.montoCanjeDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoCanjeDataGridViewTextBoxColumn.Width = 80;
            // 
            // numLetras
            // 
            this.numLetras.DataPropertyName = "numLetras";
            this.numLetras.HeaderText = "Letras";
            this.numLetras.Name = "numLetras";
            this.numLetras.ReadOnly = true;
            this.numLetras.Width = 50;
            // 
            // desEstado
            // 
            this.desEstado.DataPropertyName = "desEstado";
            this.desEstado.HeaderText = "Estado";
            this.desEstado.Name = "desEstado";
            this.desEstado.ReadOnly = true;
            this.desEstado.Width = 90;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idComprobante.DefaultCellStyle = dataGridViewCellStyle5;
            this.idComprobante.HeaderText = "Libro";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Width = 50;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numFile.DefaultCellStyle = dataGridViewCellStyle6;
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.ReadOnly = true;
            this.numFile.Width = 50;
            // 
            // numVoucher
            // 
            this.numVoucher.DataPropertyName = "numVoucher";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numVoucher.DefaultCellStyle = dataGridViewCellStyle7;
            this.numVoucher.HeaderText = "Voucher";
            this.numVoucher.Name = "numVoucher";
            this.numVoucher.ReadOnly = true;
            this.numVoucher.Width = 90;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
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
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // cmsPopup
            // 
            this.cmsPopup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCerrarCanje,
            this.tsmiAbrirCanje,
            this.toolStripSeparator1,
            this.tsmiImprimeVoucher,
            this.tsmiLimpiar});
            this.cmsPopup.Name = "cmsPopup";
            this.cmsPopup.Size = new System.Drawing.Size(168, 98);
            // 
            // tsmiCerrarCanje
            // 
            this.tsmiCerrarCanje.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiCerrarCanje.Image = global::ClienteWinForm.Properties.Resources.Cerrar_Grande;
            this.tsmiCerrarCanje.Name = "tsmiCerrarCanje";
            this.tsmiCerrarCanje.Size = new System.Drawing.Size(167, 22);
            this.tsmiCerrarCanje.Text = "Cerrar Canje";
            this.tsmiCerrarCanje.Click += new System.EventHandler(this.tsmiCerrarCanje_Click);
            // 
            // tsmiAbrirCanje
            // 
            this.tsmiAbrirCanje.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.tsmiAbrirCanje.Name = "tsmiAbrirCanje";
            this.tsmiAbrirCanje.Size = new System.Drawing.Size(167, 22);
            this.tsmiAbrirCanje.Text = "Abrir Canje";
            this.tsmiAbrirCanje.Click += new System.EventHandler(this.tsmiAbrirCanje_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmiImprimeVoucher
            // 
            this.tsmiImprimeVoucher.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiImprimeVoucher.Image = ((System.Drawing.Image)(resources.GetObject("tsmiImprimeVoucher.Image")));
            this.tsmiImprimeVoucher.Name = "tsmiImprimeVoucher";
            this.tsmiImprimeVoucher.Size = new System.Drawing.Size(167, 22);
            this.tsmiImprimeVoucher.Text = "Imprimir Voucher";
            this.tsmiImprimeVoucher.Click += new System.EventHandler(this.tsmiImprimeVoucher_Click);
            // 
            // tsmiLimpiar
            // 
            //this.tsmiLimpiar.Image = global::ClienteWinForm.Properties.Resources.Borrar_128x128;
            this.tsmiLimpiar.Name = "tsmiLimpiar";
            this.tsmiLimpiar.Size = new System.Drawing.Size(167, 22);
            this.tsmiLimpiar.Text = "Limpiar Voucher";
            this.tsmiLimpiar.Click += new System.EventHandler(this.tsmiLimpiar_Click);
            // 
            // bsCanje
            // 
            this.bsCanje.DataSource = typeof(Entidades.CtasPorPagar.CanjeE);
            this.bsCanje.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCanje_ListChanged);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(962, 16);
            this.lblTitulo.TabIndex = 270;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(this.dtpFecFin);
            this.panel2.Controls.Add(this.dtpFecIni);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 66);
            this.panel2.TabIndex = 363;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 362;
            this.label1.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(138, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 361;
            this.label25.Text = "Al";
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
            this.labelDegradado2.Size = new System.Drawing.Size(266, 16);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Fechas";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(157, 31);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(94, 20);
            this.dtpFecFin.TabIndex = 301;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(41, 31);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(94, 20);
            this.dtpFecIni.TabIndex = 300;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtRazonSocial);
            this.panel4.Controls.Add(this.txtIdAuxiliar);
            this.panel4.Controls.Add(this.rbTodosCLientes);
            this.panel4.Controls.Add(this.rbUnCliente);
            this.panel4.Controls.Add(this.txtRuc);
            this.panel4.Controls.Add(this.labelDegradado4);
            this.panel4.Location = new System.Drawing.Point(273, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(694, 66);
            this.panel4.TabIndex = 364;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(229, 37);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(398, 20);
            this.txtRazonSocial.TabIndex = 305;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Razón Social";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtIdAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAuxiliar.Enabled = false;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(97, 37);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(41, 20);
            this.txtIdAuxiliar.TabIndex = 303;
            this.txtIdAuxiliar.TabStop = false;
            this.txtIdAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdAuxiliar.TextoVacio = "Id";
            // 
            // rbTodosCLientes
            // 
            this.rbTodosCLientes.AutoSize = true;
            this.rbTodosCLientes.Checked = true;
            this.rbTodosCLientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodosCLientes.Location = new System.Drawing.Point(30, 21);
            this.rbTodosCLientes.Name = "rbTodosCLientes";
            this.rbTodosCLientes.Size = new System.Drawing.Size(54, 17);
            this.rbTodosCLientes.TabIndex = 299;
            this.rbTodosCLientes.TabStop = true;
            this.rbTodosCLientes.Text = "Todos";
            this.rbTodosCLientes.UseVisualStyleBackColor = true;
            this.rbTodosCLientes.CheckedChanged += new System.EventHandler(this.rbTodosCLientes_CheckedChanged);
            // 
            // rbUnCliente
            // 
            this.rbUnCliente.AutoSize = true;
            this.rbUnCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnCliente.Location = new System.Drawing.Point(30, 39);
            this.rbUnCliente.Name = "rbUnCliente";
            this.rbUnCliente.Size = new System.Drawing.Size(66, 17);
            this.rbUnCliente.TabIndex = 298;
            this.rbUnCliente.Text = "Solo uno";
            this.rbUnCliente.UseVisualStyleBackColor = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(139, 37);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(88, 20);
            this.txtRuc.TabIndex = 304;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "RUC";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
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
            this.labelDegradado4.Size = new System.Drawing.Size(692, 16);
            this.labelDegradado4.TabIndex = 248;
            this.labelDegradado4.Text = "Auxiliar";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoCanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 441);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmListadoCanje";
            this.Text = "Listado de Canjes de Letras";
            this.Load += new System.EventHandler(this.frmListadoCanje_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanje)).EndInit();
            this.cmsPopup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCanje)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCanje;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.BindingSource bsCanje;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.Panel panel4;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdAuxiliar;
        private System.Windows.Forms.RadioButton rbTodosCLientes;
        private System.Windows.Forms.RadioButton rbUnCliente;
        private ControlesWinForm.SuperTextBox txtRuc;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.ContextMenuStrip cmsPopup;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarCanje;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImprimeVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbrirCanje;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCanjeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCanjeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoCanjeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLetras;
        private System.Windows.Forms.DataGridViewTextBoxColumn desEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}