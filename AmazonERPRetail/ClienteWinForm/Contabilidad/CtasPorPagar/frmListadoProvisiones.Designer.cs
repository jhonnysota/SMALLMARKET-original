namespace ClienteWinForm.CtasPorPagar
{
    partial class frmListadoProvisiones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsProvision = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenerarMasivo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiVerVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarMasivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActualizarCtaCte = new System.Windows.Forms.ToolStripMenuItem();
            this.bsprovisiones = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.cboDocumentos = new System.Windows.Forms.ComboBox();
            this.txtNumero = new ControlesWinForm.SuperTextBox();
            this.rbTodoDoc = new System.Windows.Forms.RadioButton();
            this.rbUnoDoc = new System.Windows.Forms.RadioButton();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbUno = new System.Windows.Forms.RadioButton();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbRegistrado = new System.Windows.Forms.RadioButton();
            this.rbProvisionada = new System.Windows.Forms.RadioButton();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvprovision = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idProvision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaProvision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codMonedaProvisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impMonedaOrigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagDetraccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MontoDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLiquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codOrdenPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoProvision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EsLiquidacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EsRendicion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.btDetracciones = new System.Windows.Forms.Button();
            this.cmsProvision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsprovisiones)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprovision)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsProvision
            // 
            this.cmsProvision.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsProvision.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerar,
            this.tsmGenerarMasivo,
            this.toolStripSeparator2,
            this.tsmiVerVoucher,
            this.tsmLimpiar,
            this.toolStripSeparator1,
            this.tsmiEliminar,
            this.tsmEliminarMasivo,
            this.tsmiActualizarCtaCte});
            this.cmsProvision.Name = "cmsFactura";
            this.cmsProvision.Size = new System.Drawing.Size(206, 170);
            // 
            // tsmiGenerar
            // 
            this.tsmiGenerar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.tsmiGenerar.Name = "tsmiGenerar";
            this.tsmiGenerar.Size = new System.Drawing.Size(205, 22);
            this.tsmiGenerar.Text = "Generar Voucher";
            this.tsmiGenerar.Click += new System.EventHandler(this.tsmiGenerar_Click);
            // 
            // tsmGenerarMasivo
            // 
            this.tsmGenerarMasivo.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.tsmGenerarMasivo.Name = "tsmGenerarMasivo";
            this.tsmGenerarMasivo.Size = new System.Drawing.Size(205, 22);
            this.tsmGenerarMasivo.Text = "Vouchers Masivos";
            this.tsmGenerarMasivo.Click += new System.EventHandler(this.tsmGenerarMasivo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // tsmiVerVoucher
            // 
            this.tsmiVerVoucher.Enabled = false;
            this.tsmiVerVoucher.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.tsmiVerVoucher.Name = "tsmiVerVoucher";
            this.tsmiVerVoucher.Size = new System.Drawing.Size(205, 22);
            this.tsmiVerVoucher.Text = "Ver Voucher";
            this.tsmiVerVoucher.Click += new System.EventHandler(this.tsmiVerVoucher_Click);
            // 
            // tsmLimpiar
            // 
            this.tsmLimpiar.Image = global::ClienteWinForm.Properties.Resources.Blanco;
            this.tsmLimpiar.Name = "tsmLimpiar";
            this.tsmLimpiar.Size = new System.Drawing.Size(205, 22);
            this.tsmLimpiar.Text = "Limpiar Num.Vouchers";
            this.tsmLimpiar.Click += new System.EventHandler(this.tsmLimpiar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // tsmiEliminar
            // 
            this.tsmiEliminar.Enabled = false;
            this.tsmiEliminar.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.tsmiEliminar.Name = "tsmiEliminar";
            this.tsmiEliminar.Size = new System.Drawing.Size(205, 22);
            this.tsmiEliminar.Text = "Eliminar Voucher";
            this.tsmiEliminar.Click += new System.EventHandler(this.tsmiEliminar_Click);
            // 
            // tsmEliminarMasivo
            // 
            this.tsmEliminarMasivo.Enabled = false;
            this.tsmEliminarMasivo.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmEliminarMasivo.Name = "tsmEliminarMasivo";
            this.tsmEliminarMasivo.Size = new System.Drawing.Size(205, 22);
            this.tsmEliminarMasivo.Text = "Eliminación Masiva";
            this.tsmEliminarMasivo.Click += new System.EventHandler(this.tsmEliminarMasivo_Click);
            // 
            // tsmiActualizarCtaCte
            // 
            this.tsmiActualizarCtaCte.Image = global::ClienteWinForm.Properties.Resources.Regenerar;
            this.tsmiActualizarCtaCte.Name = "tsmiActualizarCtaCte";
            this.tsmiActualizarCtaCte.Size = new System.Drawing.Size(205, 22);
            this.tsmiActualizarCtaCte.Text = "Actualizar Detra. Cta.Cte.";
            this.tsmiActualizarCtaCte.Visible = false;
            this.tsmiActualizarCtaCte.Click += new System.EventHandler(this.tsmiActualizarCtaCte_Click);
            // 
            // bsprovisiones
            // 
            this.bsprovisiones.DataSource = typeof(Entidades.CtasPorPagar.ProvisionesE);
            this.bsprovisiones.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsprovisiones_ListChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtSerie);
            this.panel6.Controls.Add(this.cboDocumentos);
            this.panel6.Controls.Add(this.txtNumero);
            this.panel6.Controls.Add(this.rbTodoDoc);
            this.panel6.Controls.Add(this.rbUnoDoc);
            this.panel6.Controls.Add(this.labelDegradado5);
            this.panel6.Location = new System.Drawing.Point(498, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(554, 50);
            this.panel6.TabIndex = 306;
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Enabled = false;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(262, 22);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(81, 20);
            this.txtSerie.TabIndex = 306;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "";
            // 
            // cboDocumentos
            // 
            this.cboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentos.DropDownWidth = 63;
            this.cboDocumentos.Enabled = false;
            this.cboDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentos.FormattingEnabled = true;
            this.cboDocumentos.Location = new System.Drawing.Point(195, 22);
            this.cboDocumentos.Name = "cboDocumentos";
            this.cboDocumentos.Size = new System.Drawing.Size(63, 21);
            this.cboDocumentos.TabIndex = 250;
            this.cboDocumentos.SelectionChangeCommitted += new System.EventHandler(this.cboDocumentos_SelectionChangeCommitted);
            // 
            // txtNumero
            // 
            this.txtNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumero.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(347, 22);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(120, 20);
            this.txtNumero.TabIndex = 307;
            this.txtNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumero.TextoVacio = "";
            // 
            // rbTodoDoc
            // 
            this.rbTodoDoc.AutoSize = true;
            this.rbTodoDoc.Checked = true;
            this.rbTodoDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodoDoc.Location = new System.Drawing.Point(27, 25);
            this.rbTodoDoc.Name = "rbTodoDoc";
            this.rbTodoDoc.Size = new System.Drawing.Size(54, 17);
            this.rbTodoDoc.TabIndex = 299;
            this.rbTodoDoc.TabStop = true;
            this.rbTodoDoc.Text = "Todos";
            this.rbTodoDoc.UseVisualStyleBackColor = true;
            this.rbTodoDoc.CheckedChanged += new System.EventHandler(this.rbTodoDoc_CheckedChanged);
            // 
            // rbUnoDoc
            // 
            this.rbUnoDoc.AutoSize = true;
            this.rbUnoDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnoDoc.Location = new System.Drawing.Point(99, 25);
            this.rbUnoDoc.Name = "rbUnoDoc";
            this.rbUnoDoc.Size = new System.Drawing.Size(66, 17);
            this.rbUnoDoc.TabIndex = 298;
            this.rbUnoDoc.Text = "Solo uno";
            this.rbUnoDoc.UseVisualStyleBackColor = true;
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
            this.labelDegradado5.Size = new System.Drawing.Size(552, 17);
            this.labelDegradado5.TabIndex = 248;
            this.labelDegradado5.Text = "Documento";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.labelDegradado1);
            this.panel5.Controls.Add(this.cboLibro);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cboFile);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(3, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(493, 50);
            this.panel5.TabIndex = 304;
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
            this.labelDegradado1.Size = new System.Drawing.Size(491, 17);
            this.labelDegradado1.TabIndex = 249;
            this.labelDegradado1.Text = "Diario";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLibro
            // 
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.DropDownWidth = 250;
            this.cboLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(41, 22);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(205, 21);
            this.cboLibro.TabIndex = 11;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Libro";
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.DropDownWidth = 250;
            this.cboFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(274, 22);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(205, 21);
            this.cboFile.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(248, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "File";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtRazonSocial);
            this.panel2.Controls.Add(this.rbTodos);
            this.panel2.Controls.Add(this.rbUno);
            this.panel2.Controls.Add(this.labelDegradado4);
            this.panel2.Location = new System.Drawing.Point(498, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 50);
            this.panel2.TabIndex = 303;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(171, 22);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(343, 20);
            this.txtRazonSocial.TabIndex = 305;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Razón Social";
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(27, 24);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 299;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbUno
            // 
            this.rbUno.AutoSize = true;
            this.rbUno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUno.Location = new System.Drawing.Point(99, 24);
            this.rbUno.Name = "rbUno";
            this.rbUno.Size = new System.Drawing.Size(66, 17);
            this.rbUno.TabIndex = 298;
            this.rbUno.Text = "Solo uno";
            this.rbUno.UseVisualStyleBackColor = true;
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
            this.labelDegradado4.Size = new System.Drawing.Size(552, 17);
            this.labelDegradado4.TabIndex = 248;
            this.labelDegradado4.Text = "Auxiliar";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbRegistrado);
            this.panel3.Controls.Add(this.rbProvisionada);
            this.panel3.Controls.Add(this.labelDegradado2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 50);
            this.panel3.TabIndex = 271;
            // 
            // rbRegistrado
            // 
            this.rbRegistrado.AutoSize = true;
            this.rbRegistrado.Checked = true;
            this.rbRegistrado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRegistrado.Location = new System.Drawing.Point(14, 24);
            this.rbRegistrado.Name = "rbRegistrado";
            this.rbRegistrado.Size = new System.Drawing.Size(77, 17);
            this.rbRegistrado.TabIndex = 259;
            this.rbRegistrado.TabStop = true;
            this.rbRegistrado.Text = "Registrada";
            this.rbRegistrado.UseVisualStyleBackColor = true;
            this.rbRegistrado.CheckedChanged += new System.EventHandler(this.rbRegistrado_CheckedChanged);
            // 
            // rbProvisionada
            // 
            this.rbProvisionada.AutoSize = true;
            this.rbProvisionada.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProvisionada.Location = new System.Drawing.Point(105, 24);
            this.rbProvisionada.Name = "rbProvisionada";
            this.rbProvisionada.Size = new System.Drawing.Size(86, 17);
            this.rbProvisionada.TabIndex = 257;
            this.rbProvisionada.Text = "Provisionada";
            this.rbProvisionada.UseVisualStyleBackColor = true;
            this.rbProvisionada.CheckedChanged += new System.EventHandler(this.rbProvisionada_CheckedChanged);
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
            this.labelDegradado2.Size = new System.Drawing.Size(200, 17);
            this.labelDegradado2.TabIndex = 248;
            this.labelDegradado2.Text = "Estado de Documento";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpInicio);
            this.panel4.Controls.Add(this.dtpFinal);
            this.panel4.Controls.Add(this.labelDegradado3);
            this.panel4.Location = new System.Drawing.Point(207, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 50);
            this.panel4.TabIndex = 270;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 259;
            this.label1.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 258;
            this.label3.Text = "hasta";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(49, 22);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 255;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(180, 22);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 256;
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
            this.labelDegradado3.Size = new System.Drawing.Size(287, 17);
            this.labelDegradado3.TabIndex = 248;
            this.labelDegradado3.Text = "Fechas";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvprovision);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 421);
            this.panel1.TabIndex = 268;
            // 
            // dgvprovision
            // 
            this.dgvprovision.AllowUserToAddRows = false;
            this.dgvprovision.AllowUserToDeleteRows = false;
            this.dgvprovision.AutoGenerateColumns = false;
            this.dgvprovision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprovision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.idProvision,
            this.FechaProvision,
            this.RazonSocial,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.NumDocumento,
            this.codMonedaProvisionDataGridViewTextBoxColumn,
            this.impMonedaOrigenDataGridViewTextBoxColumn,
            this.flagDetraccion,
            this.MontoDetraccion,
            this.DesComprobante,
            this.DesFile,
            this.numVoucher,
            this.numLiquidacion,
            this.codOrdenPago,
            this.dataGridViewTextBoxColumn1,
            this.desEstadoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.FechaRegistro,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.FechaModificacion,
            this.EstadoProvision,
            this.EsLiquidacion,
            this.EsRendicion});
            this.dgvprovision.ContextMenuStrip = this.cmsProvision;
            this.dgvprovision.DataSource = this.bsprovisiones;
            this.dgvprovision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvprovision.EnableHeadersVisualStyles = false;
            this.dgvprovision.Location = new System.Drawing.Point(0, 17);
            this.dgvprovision.Name = "dgvprovision";
            this.dgvprovision.Size = new System.Drawing.Size(1356, 402);
            this.dgvprovision.TabIndex = 250;
            this.dgvprovision.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoProvisiones_CellDoubleClick);
            this.dgvprovision.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvprovision_CellFormatting);
            this.dgvprovision.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvprovision_CellPainting);
            this.dgvprovision.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvprovision_CellValueChanged);
            this.dgvprovision.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvprovision_ColumnHeaderMouseClick);
            this.dgvprovision.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvprovision_CurrentCellDirtyStateChanged);
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.Frozen = true;
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.Width = 25;
            // 
            // idProvision
            // 
            this.idProvision.DataPropertyName = "idProvision";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "0000000";
            dataGridViewCellStyle1.NullValue = null;
            this.idProvision.DefaultCellStyle = dataGridViewCellStyle1;
            this.idProvision.Frozen = true;
            this.idProvision.HeaderText = "Nro.";
            this.idProvision.Name = "idProvision";
            this.idProvision.ReadOnly = true;
            this.idProvision.Width = 70;
            // 
            // FechaProvision
            // 
            this.FechaProvision.DataPropertyName = "FechaProvision";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.FechaProvision.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaProvision.Frozen = true;
            this.FechaProvision.HeaderText = "Fecha Prov.";
            this.FechaProvision.Name = "FechaProvision";
            this.FechaProvision.ReadOnly = true;
            this.FechaProvision.Width = 80;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.Frozen = true;
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 300;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            this.idDocumentoDataGridViewTextBoxColumn.Frozen = true;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 40;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "NumSerie";
            this.numSerieDataGridViewTextBoxColumn.Frozen = true;
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieDataGridViewTextBoxColumn.Width = 50;
            // 
            // NumDocumento
            // 
            this.NumDocumento.DataPropertyName = "NumDocumento";
            this.NumDocumento.Frozen = true;
            this.NumDocumento.HeaderText = "Documento";
            this.NumDocumento.Name = "NumDocumento";
            this.NumDocumento.ReadOnly = true;
            this.NumDocumento.Width = 80;
            // 
            // codMonedaProvisionDataGridViewTextBoxColumn
            // 
            this.codMonedaProvisionDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codMonedaProvisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.codMonedaProvisionDataGridViewTextBoxColumn.Frozen = true;
            this.codMonedaProvisionDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.codMonedaProvisionDataGridViewTextBoxColumn.Name = "codMonedaProvisionDataGridViewTextBoxColumn";
            this.codMonedaProvisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.codMonedaProvisionDataGridViewTextBoxColumn.Width = 40;
            // 
            // impMonedaOrigenDataGridViewTextBoxColumn
            // 
            this.impMonedaOrigenDataGridViewTextBoxColumn.DataPropertyName = "ImpMonedaOrigen";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.impMonedaOrigenDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.impMonedaOrigenDataGridViewTextBoxColumn.Frozen = true;
            this.impMonedaOrigenDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.impMonedaOrigenDataGridViewTextBoxColumn.Name = "impMonedaOrigenDataGridViewTextBoxColumn";
            this.impMonedaOrigenDataGridViewTextBoxColumn.ReadOnly = true;
            this.impMonedaOrigenDataGridViewTextBoxColumn.Width = 80;
            // 
            // flagDetraccion
            // 
            this.flagDetraccion.DataPropertyName = "flagDetraccion";
            this.flagDetraccion.HeaderText = "Det.";
            this.flagDetraccion.Name = "flagDetraccion";
            this.flagDetraccion.ReadOnly = true;
            this.flagDetraccion.ToolTipText = "Indica si tiene detracción";
            this.flagDetraccion.Width = 30;
            // 
            // MontoDetraccion
            // 
            this.MontoDetraccion.DataPropertyName = "MontoDetraccion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.MontoDetraccion.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoDetraccion.HeaderText = "Imp.Detr.";
            this.MontoDetraccion.Name = "MontoDetraccion";
            this.MontoDetraccion.ReadOnly = true;
            this.MontoDetraccion.Width = 70;
            // 
            // DesComprobante
            // 
            this.DesComprobante.DataPropertyName = "DesComprobante";
            this.DesComprobante.HeaderText = "Libro";
            this.DesComprobante.Name = "DesComprobante";
            this.DesComprobante.ReadOnly = true;
            this.DesComprobante.Width = 130;
            // 
            // DesFile
            // 
            this.DesFile.DataPropertyName = "DesFile";
            this.DesFile.HeaderText = "File";
            this.DesFile.Name = "DesFile";
            this.DesFile.ReadOnly = true;
            this.DesFile.Width = 130;
            // 
            // numVoucher
            // 
            this.numVoucher.DataPropertyName = "numVoucher";
            this.numVoucher.HeaderText = "Voucher";
            this.numVoucher.Name = "numVoucher";
            this.numVoucher.ReadOnly = true;
            this.numVoucher.Width = 75;
            // 
            // numLiquidacion
            // 
            this.numLiquidacion.DataPropertyName = "numLiquidacion";
            this.numLiquidacion.HeaderText = "N° Liq.";
            this.numLiquidacion.Name = "numLiquidacion";
            this.numLiquidacion.ReadOnly = true;
            this.numLiquidacion.ToolTipText = "Número de liquidación asociado";
            this.numLiquidacion.Width = 60;
            // 
            // codOrdenPago
            // 
            this.codOrdenPago.DataPropertyName = "codOrdenPago";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codOrdenPago.DefaultCellStyle = dataGridViewCellStyle6;
            this.codOrdenPago.HeaderText = "O.P.";
            this.codOrdenPago.Name = "codOrdenPago";
            this.codOrdenPago.ReadOnly = true;
            this.codOrdenPago.ToolTipText = "Orden de pago asociado";
            this.codOrdenPago.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "numOrdenCompra";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "O.C.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ToolTipText = "Orden de Compra";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // desEstadoDataGridViewTextBoxColumn
            // 
            this.desEstadoDataGridViewTextBoxColumn.DataPropertyName = "DesEstado";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desEstadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.desEstadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.desEstadoDataGridViewTextBoxColumn.Name = "desEstadoDataGridViewTextBoxColumn";
            this.desEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.desEstadoDataGridViewTextBoxColumn.Width = 110;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaRegistro.DefaultCellStyle = dataGridViewCellStyle9;
            this.FechaRegistro.HeaderText = "Fecha Reg.";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaModificacion.DefaultCellStyle = dataGridViewCellStyle10;
            this.FechaModificacion.HeaderText = "Fecha Mod.";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            this.FechaModificacion.Width = 120;
            // 
            // EstadoProvision
            // 
            this.EstadoProvision.DataPropertyName = "EstadoProvision";
            this.EstadoProvision.HeaderText = "EstadoProvision";
            this.EstadoProvision.Name = "EstadoProvision";
            this.EstadoProvision.Visible = false;
            // 
            // EsLiquidacion
            // 
            this.EsLiquidacion.DataPropertyName = "EsLiquidacion";
            this.EsLiquidacion.HeaderText = "EsLiquidacion";
            this.EsLiquidacion.Name = "EsLiquidacion";
            this.EsLiquidacion.Visible = false;
            // 
            // EsRendicion
            // 
            this.EsRendicion.DataPropertyName = "EsRendicion";
            this.EsRendicion.HeaderText = "EsRendicion";
            this.EsRendicion.Name = "EsRendicion";
            this.EsRendicion.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(1356, 17);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btDetracciones
            // 
            this.btDetracciones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btDetracciones.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btDetracciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btDetracciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btDetracciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDetracciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetracciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetracciones.Location = new System.Drawing.Point(1057, 76);
            this.btDetracciones.Margin = new System.Windows.Forms.Padding(2);
            this.btDetracciones.Name = "btDetracciones";
            this.btDetracciones.Size = new System.Drawing.Size(95, 26);
            this.btDetracciones.TabIndex = 360;
            this.btDetracciones.Text = "Detracciones";
            this.btDetracciones.UseVisualStyleBackColor = false;
            this.btDetracciones.Visible = false;
            this.btDetracciones.Click += new System.EventHandler(this.btDetracciones_Click);
            // 
            // frmListadoProvisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 530);
            this.Controls.Add(this.btDetracciones);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoProvisiones";
            this.Text = "Listado de Compras";
            this.Load += new System.EventHandler(this.frmListadoProvisiones_Load);
            this.cmsProvision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsprovisiones)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvprovision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.DataGridView dgvprovision;
        private System.Windows.Forms.BindingSource bsprovisiones;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbRegistrado;
        private System.Windows.Forms.RadioButton rbProvisionada;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.ContextMenuStrip cmsProvision;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerar;
        //private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerVoucher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbUno;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.Panel panel5;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private ControlesWinForm.SuperTextBox txtNumero;
        private System.Windows.Forms.RadioButton rbTodoDoc;
        private System.Windows.Forms.RadioButton rbUnoDoc;
        private MyLabelG.LabelDegradado labelDegradado5;
        private ControlesWinForm.SuperTextBox txtSerie;
        private System.Windows.Forms.ComboBox cboDocumentos;
        private System.Windows.Forms.ToolStripMenuItem tsmGenerarMasivo;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarMasivo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmLimpiar;
        private System.Windows.Forms.Button btDetracciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiActualizarCtaCte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProvision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProvision;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMonedaProvisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impMonedaOrigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codOrdenPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn desEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoProvision;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsLiquidacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsRendicion;
    }
}