namespace ClienteWinForm.Ventas
{
    partial class frmListadoFacturasUf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoFacturasUf));
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsEmisionFacturas = new System.Windows.Forms.BindingSource(this.components);
            this.cmsFactura = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerarLetras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopiarFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDarBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenerarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.editarDatosVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btEmitir = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.rbTodasSeries = new System.Windows.Forms.RadioButton();
            this.rbSeries = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtIdAuxiliar = new ControlesWinForm.SuperTextBox();
            this.rbTodosCLientes = new System.Windows.Forms.RadioButton();
            this.rbUnCliente = new System.Windows.Forms.RadioButton();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.btCliente = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDesde = new System.Windows.Forms.RadioButton();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.btRevisarEstados = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoFacturas = new System.Windows.Forms.DataGridView();
            this.indEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnviadoSunat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.anuladoSunatDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numRuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totsubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipAfectoIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EsAnticipo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indAnticipo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indVoucher = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.esGuiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCondicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btInsertaCtaCte = new System.Windows.Forms.Button();
            this.chkAnticipos = new System.Windows.Forms.CheckBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmisionFacturas)).BeginInit();
            this.cmsFactura.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEmisionFacturas
            // 
            this.bsEmisionFacturas.DataSource = typeof(Entidades.Ventas.EmisionDocumentoE);
            // 
            // cmsFactura
            // 
            this.cmsFactura.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFactura.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFactura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerarLetras,
            this.tsmiCopiarFactura,
            this.toolStripSeparator2,
            this.tsmiFactura,
            this.tsmiVer,
            this.tsmiPdf,
            this.toolStripSeparator1,
            this.tsmiDarBaja,
            this.tsmiGenerarVoucher,
            this.tsmiEliminarVoucher,
            this.editarDatosVendedorToolStripMenuItem});
            this.cmsFactura.Name = "cmsFactura";
            this.cmsFactura.Size = new System.Drawing.Size(246, 250);
            // 
            // tsmiGenerarLetras
            // 
            this.tsmiGenerarLetras.Image = global::ClienteWinForm.Properties.Resources.Calcular_Letras_32x32;
            this.tsmiGenerarLetras.Name = "tsmiGenerarLetras";
            this.tsmiGenerarLetras.Size = new System.Drawing.Size(245, 26);
            this.tsmiGenerarLetras.Text = "Generar Letras";
            this.tsmiGenerarLetras.Click += new System.EventHandler(this.tsmiGenerarLetras_Click);
            // 
            // tsmiCopiarFactura
            // 
            this.tsmiCopiarFactura.Image = global::ClienteWinForm.Properties.Resources.Copiar32x32;
            this.tsmiCopiarFactura.Name = "tsmiCopiarFactura";
            this.tsmiCopiarFactura.Size = new System.Drawing.Size(245, 26);
            this.tsmiCopiarFactura.Text = "Copiar Factura";
            this.tsmiCopiarFactura.Click += new System.EventHandler(this.tsmiCopiarFactura_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiFactura
            // 
            this.tsmiFactura.Image = global::ClienteWinForm.Properties.Resources.plus;
            this.tsmiFactura.Name = "tsmiFactura";
            this.tsmiFactura.Size = new System.Drawing.Size(245, 26);
            this.tsmiFactura.Text = "Enviar a Facturación Electrónica";
            this.tsmiFactura.Click += new System.EventHandler(this.tsmiFactura_Click);
            // 
            // tsmiVer
            // 
            this.tsmiVer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiVer.Image = global::ClienteWinForm.Properties.Resources.Buscar;
            this.tsmiVer.Name = "tsmiVer";
            this.tsmiVer.Size = new System.Drawing.Size(245, 26);
            this.tsmiVer.Text = "Ver Estados";
            this.tsmiVer.Click += new System.EventHandler(this.tsmiVer_Click);
            // 
            // tsmiPdf
            // 
            this.tsmiPdf.Image = global::ClienteWinForm.Properties.Resources.pdf_chico;
            this.tsmiPdf.Name = "tsmiPdf";
            this.tsmiPdf.Size = new System.Drawing.Size(245, 26);
            this.tsmiPdf.Text = "Ver Factura PDF";
            this.tsmiPdf.Visible = false;
            this.tsmiPdf.Click += new System.EventHandler(this.tsmiPdf_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Red;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiDarBaja
            // 
            this.tsmiDarBaja.Image = global::ClienteWinForm.Properties.Resources.action_remove;
            this.tsmiDarBaja.Name = "tsmiDarBaja";
            this.tsmiDarBaja.Size = new System.Drawing.Size(245, 26);
            this.tsmiDarBaja.Text = "Dar de Baja Documentos";
            this.tsmiDarBaja.Click += new System.EventHandler(this.tsmiDarBaja_Click);
            // 
            // tsmiGenerarVoucher
            // 
            this.tsmiGenerarVoucher.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.tsmiGenerarVoucher.Name = "tsmiGenerarVoucher";
            this.tsmiGenerarVoucher.Size = new System.Drawing.Size(245, 26);
            this.tsmiGenerarVoucher.Text = "Generar Voucher";
            this.tsmiGenerarVoucher.Click += new System.EventHandler(this.tsmiGenerarVoucher_Click);
            // 
            // tsmiEliminarVoucher
            // 
            this.tsmiEliminarVoucher.Image = global::ClienteWinForm.Properties.Resources.Row_Delete_16x16;
            this.tsmiEliminarVoucher.Name = "tsmiEliminarVoucher";
            this.tsmiEliminarVoucher.Size = new System.Drawing.Size(245, 26);
            this.tsmiEliminarVoucher.Text = "Eliminar Voucher";
            this.tsmiEliminarVoucher.Click += new System.EventHandler(this.tsmiEliminarVoucher_Click);
            // 
            // editarDatosVendedorToolStripMenuItem
            // 
            this.editarDatosVendedorToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.ico_persona;
            this.editarDatosVendedorToolStripMenuItem.Name = "editarDatosVendedorToolStripMenuItem";
            this.editarDatosVendedorToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.editarDatosVendedorToolStripMenuItem.Text = "Editar Datos Vendedor";
            this.editarDatosVendedorToolStripMenuItem.Click += new System.EventHandler(this.editarDatosVendedorToolStripMenuItem_Click);
            // 
            // btEmitir
            // 
            this.btEmitir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btEmitir.BackgroundImage")));
            this.btEmitir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btEmitir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEmitir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEmitir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEmitir.Location = new System.Drawing.Point(932, 9);
            this.btEmitir.Name = "btEmitir";
            this.btEmitir.Size = new System.Drawing.Size(39, 26);
            this.btEmitir.TabIndex = 303;
            this.btEmitir.UseVisualStyleBackColor = true;
            this.btEmitir.Click += new System.EventHandler(this.btEmitir_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.cboSeries);
            this.panel6.Controls.Add(this.rbTodasSeries);
            this.panel6.Controls.Add(this.rbSeries);
            this.panel6.Location = new System.Drawing.Point(300, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(152, 74);
            this.panel6.TabIndex = 200;
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.Enabled = false;
            this.cboSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.ForeColor = System.Drawing.Color.Blue;
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(55, 43);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(88, 21);
            this.cboSeries.TabIndex = 262;
            // 
            // rbTodasSeries
            // 
            this.rbTodasSeries.AutoSize = true;
            this.rbTodasSeries.Checked = true;
            this.rbTodasSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodasSeries.Location = new System.Drawing.Point(7, 25);
            this.rbTodasSeries.Name = "rbTodasSeries";
            this.rbTodasSeries.Size = new System.Drawing.Size(54, 17);
            this.rbTodasSeries.TabIndex = 261;
            this.rbTodasSeries.TabStop = true;
            this.rbTodasSeries.Text = "Todas";
            this.rbTodasSeries.UseVisualStyleBackColor = true;
            this.rbTodasSeries.CheckedChanged += new System.EventHandler(this.rbTodasSeries_CheckedChanged);
            // 
            // rbSeries
            // 
            this.rbSeries.AutoSize = true;
            this.rbSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSeries.Location = new System.Drawing.Point(8, 46);
            this.rbSeries.Name = "rbSeries";
            this.rbSeries.Size = new System.Drawing.Size(44, 17);
            this.rbSeries.TabIndex = 260;
            this.rbSeries.Text = "Uno";
            this.rbSeries.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtRazonSocial);
            this.panel4.Controls.Add(this.txtIdAuxiliar);
            this.panel4.Controls.Add(this.rbTodosCLientes);
            this.panel4.Controls.Add(this.rbUnCliente);
            this.panel4.Controls.Add(this.txtRuc);
            this.panel4.Controls.Add(this.btCliente);
            this.panel4.Location = new System.Drawing.Point(454, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(467, 74);
            this.panel4.TabIndex = 302;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(192, 42);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(235, 20);
            this.txtRazonSocial.TabIndex = 305;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Razón Social";
            this.txtRazonSocial.Leave += new System.EventHandler(this.txtRazonSocial_Leave);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtIdAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAuxiliar.Enabled = false;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(75, 42);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(41, 20);
            this.txtIdAuxiliar.TabIndex = 303;
            this.txtIdAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdAuxiliar.TextoVacio = "Id";
            this.txtIdAuxiliar.Leave += new System.EventHandler(this.txtIdAuxiliar_Leave);
            // 
            // rbTodosCLientes
            // 
            this.rbTodosCLientes.AutoSize = true;
            this.rbTodosCLientes.Checked = true;
            this.rbTodosCLientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodosCLientes.Location = new System.Drawing.Point(11, 25);
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
            this.rbUnCliente.Location = new System.Drawing.Point(11, 44);
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
            this.txtRuc.Location = new System.Drawing.Point(116, 42);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(74, 20);
            this.txtRuc.TabIndex = 304;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "RUC";
            this.txtRuc.Leave += new System.EventHandler(this.txtRuc_Leave);
            // 
            // btCliente
            // 
            this.btCliente.Enabled = false;
            this.btCliente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliente.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCliente.Location = new System.Drawing.Point(429, 43);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(24, 18);
            this.btCliente.TabIndex = 295;
            this.btCliente.TabStop = false;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.LblTitulo);
            this.panel3.Controls.Add(this.rbTodas);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rbDesde);
            this.panel3.Controls.Add(this.dtpInicio);
            this.panel3.Controls.Add(this.dtpFinal);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 74);
            this.panel3.TabIndex = 100;
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodas.Location = new System.Drawing.Point(17, 24);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(54, 17);
            this.rbTodas.TabIndex = 259;
            this.rbTodas.Text = "Todas";
            this.rbTodas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "hasta";
            // 
            // rbDesde
            // 
            this.rbDesde.AutoSize = true;
            this.rbDesde.Checked = true;
            this.rbDesde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesde.Location = new System.Drawing.Point(17, 45);
            this.rbDesde.Name = "rbDesde";
            this.rbDesde.Size = new System.Drawing.Size(55, 17);
            this.rbDesde.TabIndex = 257;
            this.rbDesde.TabStop = true;
            this.rbDesde.Text = "Desde";
            this.rbDesde.UseVisualStyleBackColor = true;
            this.rbDesde.CheckedChanged += new System.EventHandler(this.rbDesde_CheckedChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(73, 43);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(80, 21);
            this.dtpInicio.TabIndex = 101;
            this.dtpInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpInicio_KeyPress);
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(193, 43);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(80, 21);
            this.dtpFinal.TabIndex = 102;
            // 
            // btRevisarEstados
            // 
            this.btRevisarEstados.BackgroundImage = global::ClienteWinForm.Properties.Resources.RevisarNegro;
            this.btRevisarEstados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btRevisarEstados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btRevisarEstados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btRevisarEstados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btRevisarEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRevisarEstados.Location = new System.Drawing.Point(932, 42);
            this.btRevisarEstados.Name = "btRevisarEstados";
            this.btRevisarEstados.Size = new System.Drawing.Size(39, 26);
            this.btRevisarEstados.TabIndex = 299;
            this.btRevisarEstados.UseVisualStyleBackColor = true;
            this.btRevisarEstados.Click += new System.EventHandler(this.btRevisarEstados_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoFacturas);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 79);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1122, 402);
            this.panel5.TabIndex = 298;
            // 
            // dgvListadoFacturas
            // 
            this.dgvListadoFacturas.AllowUserToAddRows = false;
            this.dgvListadoFacturas.AllowUserToDeleteRows = false;
            this.dgvListadoFacturas.AutoGenerateColumns = false;
            this.dgvListadoFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListadoFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indEstado,
            this.EnviadoSunat,
            this.anuladoSunatDataGridViewCheckBoxColumn,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerie,
            this.numDocumento,
            this.fecEmision,
            this.numRuc,
            this.RazonSocial,
            this.desMoneda,
            this.totsubTotal,
            this.totIgv,
            this.totTotal,
            this.desTipAfectoIgv,
            this.EsAnticipo,
            this.indAnticipo,
            this.indVoucher,
            this.esGuiaDataGridViewTextBoxColumn,
            this.desCondicion,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListadoFacturas.ContextMenuStrip = this.cmsFactura;
            this.dgvListadoFacturas.DataSource = this.bsEmisionFacturas;
            this.dgvListadoFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoFacturas.EnableHeadersVisualStyles = false;
            this.dgvListadoFacturas.Location = new System.Drawing.Point(0, 18);
            this.dgvListadoFacturas.Name = "dgvListadoFacturas";
            this.dgvListadoFacturas.ReadOnly = true;
            this.dgvListadoFacturas.Size = new System.Drawing.Size(1120, 382);
            this.dgvListadoFacturas.TabIndex = 250;
            this.dgvListadoFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellDoubleClick);
            this.dgvListadoFacturas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoFacturas_CellFormatting);
            this.dgvListadoFacturas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListadoFacturas_ColumnHeaderMouseClick);
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.indEstado.DefaultCellStyle = dataGridViewCellStyle1;
            this.indEstado.Frozen = true;
            this.indEstado.HeaderText = "Est.";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.ToolTipText = "Estado del documento";
            this.indEstado.Width = 26;
            // 
            // EnviadoSunat
            // 
            this.EnviadoSunat.DataPropertyName = "EnviadoSunat";
            this.EnviadoSunat.Frozen = true;
            this.EnviadoSunat.HeaderText = "E.S.";
            this.EnviadoSunat.Name = "EnviadoSunat";
            this.EnviadoSunat.ReadOnly = true;
            this.EnviadoSunat.ToolTipText = "Si el documento ha sido enviado a Sunat.";
            this.EnviadoSunat.Width = 26;
            // 
            // anuladoSunatDataGridViewCheckBoxColumn
            // 
            this.anuladoSunatDataGridViewCheckBoxColumn.DataPropertyName = "AnuladoSunat";
            this.anuladoSunatDataGridViewCheckBoxColumn.Frozen = true;
            this.anuladoSunatDataGridViewCheckBoxColumn.HeaderText = "A.S.";
            this.anuladoSunatDataGridViewCheckBoxColumn.Name = "anuladoSunatDataGridViewCheckBoxColumn";
            this.anuladoSunatDataGridViewCheckBoxColumn.ReadOnly = true;
            this.anuladoSunatDataGridViewCheckBoxColumn.ToolTipText = "Si el documento ha sido anulado en Sunat.";
            this.anuladoSunatDataGridViewCheckBoxColumn.Width = 26;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idDocumentoDataGridViewTextBoxColumn.Frozen = true;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 25;
            // 
            // numSerie
            // 
            this.numSerie.DataPropertyName = "numSerie";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numSerie.DefaultCellStyle = dataGridViewCellStyle3;
            this.numSerie.Frozen = true;
            this.numSerie.HeaderText = "Serie";
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            this.numSerie.Width = 40;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numDocumento.DefaultCellStyle = dataGridViewCellStyle4;
            this.numDocumento.Frozen = true;
            this.numDocumento.HeaderText = "Num.Doc.";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            this.numDocumento.Width = 75;
            // 
            // fecEmision
            // 
            this.fecEmision.DataPropertyName = "fecEmision";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecEmision.DefaultCellStyle = dataGridViewCellStyle5;
            this.fecEmision.Frozen = true;
            this.fecEmision.HeaderText = "Fec.Emis.";
            this.fecEmision.Name = "fecEmision";
            this.fecEmision.ReadOnly = true;
            this.fecEmision.Width = 70;
            // 
            // numRuc
            // 
            this.numRuc.DataPropertyName = "numRuc";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numRuc.DefaultCellStyle = dataGridViewCellStyle6;
            this.numRuc.Frozen = true;
            this.numRuc.HeaderText = "Ruc";
            this.numRuc.Name = "numRuc";
            this.numRuc.ReadOnly = true;
            this.numRuc.Width = 90;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 300;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle7;
            this.desMoneda.HeaderText = "M.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 30;
            // 
            // totsubTotal
            // 
            this.totsubTotal.DataPropertyName = "totsubTotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "###,###,##0.00";
            dataGridViewCellStyle8.NullValue = null;
            this.totsubTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.totsubTotal.HeaderText = "SubTotal";
            this.totsubTotal.Name = "totsubTotal";
            this.totsubTotal.ReadOnly = true;
            this.totsubTotal.Width = 70;
            // 
            // totIgv
            // 
            this.totIgv.DataPropertyName = "totIgv";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "###,###,##0.00";
            dataGridViewCellStyle9.NullValue = null;
            this.totIgv.DefaultCellStyle = dataGridViewCellStyle9;
            this.totIgv.HeaderText = "IGV";
            this.totIgv.Name = "totIgv";
            this.totIgv.ReadOnly = true;
            this.totIgv.Width = 70;
            // 
            // totTotal
            // 
            this.totTotal.DataPropertyName = "totTotal";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "###,###,##0.00";
            dataGridViewCellStyle10.NullValue = null;
            this.totTotal.DefaultCellStyle = dataGridViewCellStyle10;
            this.totTotal.HeaderText = "Total";
            this.totTotal.Name = "totTotal";
            this.totTotal.ReadOnly = true;
            this.totTotal.Width = 70;
            // 
            // desTipAfectoIgv
            // 
            this.desTipAfectoIgv.DataPropertyName = "desTipAfectoIgv";
            this.desTipAfectoIgv.HeaderText = "Tipo Afecto Igv";
            this.desTipAfectoIgv.Name = "desTipAfectoIgv";
            this.desTipAfectoIgv.ReadOnly = true;
            this.desTipAfectoIgv.Visible = false;
            this.desTipAfectoIgv.Width = 150;
            // 
            // EsAnticipo
            // 
            this.EsAnticipo.DataPropertyName = "EsAnticipo";
            this.EsAnticipo.HeaderText = "E.A.";
            this.EsAnticipo.Name = "EsAnticipo";
            this.EsAnticipo.ReadOnly = true;
            this.EsAnticipo.ToolTipText = "Es un Documento de Anticipo";
            this.EsAnticipo.Width = 25;
            // 
            // indAnticipo
            // 
            this.indAnticipo.DataPropertyName = "indAnticipo";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.indAnticipo.DefaultCellStyle = dataGridViewCellStyle11;
            this.indAnticipo.HeaderText = "I.A.";
            this.indAnticipo.Name = "indAnticipo";
            this.indAnticipo.ReadOnly = true;
            this.indAnticipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.indAnticipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.indAnticipo.ToolTipText = "Si el documento tiene Anticipos";
            this.indAnticipo.Width = 25;
            // 
            // indVoucher
            // 
            this.indVoucher.DataPropertyName = "indVoucher";
            this.indVoucher.HeaderText = "I.V.";
            this.indVoucher.Name = "indVoucher";
            this.indVoucher.ReadOnly = true;
            this.indVoucher.ToolTipText = "Indica Voucher";
            this.indVoucher.Width = 25;
            // 
            // esGuiaDataGridViewTextBoxColumn
            // 
            this.esGuiaDataGridViewTextBoxColumn.DataPropertyName = "EsGuia";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.esGuiaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.esGuiaDataGridViewTextBoxColumn.HeaderText = "T.F.";
            this.esGuiaDataGridViewTextBoxColumn.Name = "esGuiaDataGridViewTextBoxColumn";
            this.esGuiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.esGuiaDataGridViewTextBoxColumn.ToolTipText = "Tipo de Factura";
            this.esGuiaDataGridViewTextBoxColumn.Width = 24;
            // 
            // desCondicion
            // 
            this.desCondicion.DataPropertyName = "desCondicion";
            this.desCondicion.HeaderText = "Condicion";
            this.desCondicion.Name = "desCondicion";
            this.desCondicion.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // btInsertaCtaCte
            // 
            this.btInsertaCtaCte.BackgroundImage = global::ClienteWinForm.Properties.Resources.InsertCtaCte_24x24;
            this.btInsertaCtaCte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btInsertaCtaCte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertaCtaCte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btInsertaCtaCte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertaCtaCte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertaCtaCte.Location = new System.Drawing.Point(977, 9);
            this.btInsertaCtaCte.Name = "btInsertaCtaCte";
            this.btInsertaCtaCte.Size = new System.Drawing.Size(39, 26);
            this.btInsertaCtaCte.TabIndex = 304;
            this.btInsertaCtaCte.UseVisualStyleBackColor = true;
            this.btInsertaCtaCte.Visible = false;
            this.btInsertaCtaCte.Click += new System.EventHandler(this.btInsertaCtaCte_Click);
            // 
            // chkAnticipos
            // 
            this.chkAnticipos.AutoSize = true;
            this.chkAnticipos.Location = new System.Drawing.Point(976, 50);
            this.chkAnticipos.Name = "chkAnticipos";
            this.chkAnticipos.Size = new System.Drawing.Size(116, 17);
            this.chkAnticipos.TabIndex = 305;
            this.chkAnticipos.Text = "Anticipos Anulados";
            this.chkAnticipos.UseVisualStyleBackColor = true;
            this.chkAnticipos.Visible = false;
            this.chkAnticipos.CheckedChanged += new System.EventHandler(this.chkAnticipos_CheckedChanged);
            // 
            // btEliminar
            // 
            this.btEliminar.BackgroundImage = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.Location = new System.Drawing.Point(1090, 49);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(25, 19);
            this.btEliminar.TabIndex = 306;
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Visible = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(293, 18);
            this.LblTitulo.TabIndex = 371;
            this.LblTitulo.Text = "Fechas";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 371;
            this.label1.Text = "Series";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(465, 18);
            this.label3.TabIndex = 371;
            this.label3.Text = "Auxiliar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(1120, 18);
            this.lblRegistros.TabIndex = 371;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoFacturasUf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 484);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.chkAnticipos);
            this.Controls.Add(this.btInsertaCtaCte);
            this.Controls.Add(this.btEmitir);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btRevisarEstados);
            this.Controls.Add(this.panel5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListadoFacturasUf";
            this.Text = "Listado de Facturas";
            this.Load += new System.EventHandler(this.frmListadoFacturasUf_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListadoFacturasUf_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsEmisionFacturas)).EndInit();
            this.cmsFactura.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsEmisionFacturas;
        private System.Windows.Forms.ContextMenuStrip cmsFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmiFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmiVer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDarBaja;
        private System.Windows.Forms.Button btRevisarEstados;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoFacturas;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rbTodasSeries;
        private System.Windows.Forms.RadioButton rbSeries;
        private System.Windows.Forms.Panel panel4;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdAuxiliar;
        private System.Windows.Forms.RadioButton rbTodosCLientes;
        private System.Windows.Forms.RadioButton rbUnCliente;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDesde;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Button btEmitir;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.ToolStripMenuItem tsmiPdf;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerarLetras;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerarVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarVoucher;
        private System.Windows.Forms.Button btInsertaCtaCte;
        private System.Windows.Forms.CheckBox chkAnticipos;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopiarFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editarDatosVendedorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn indEstado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnviadoSunat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn anuladoSunatDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn totsubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn totIgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn totTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipAfectoIgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsAnticipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAnticipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn esGuiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label lblRegistros;
    }
}