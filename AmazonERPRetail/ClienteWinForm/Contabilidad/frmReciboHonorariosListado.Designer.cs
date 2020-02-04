namespace ClienteWinForm.Contabilidad
{
    partial class frmReciboHonorariosListado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.idReciboHonorarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impReciboDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impCuartaCatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EsCancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsRRHH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsRecibohonorarios = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbR = new System.Windows.Forms.RadioButton();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.cmsRRHH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRecibohonorarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cboMes);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cboAnio);
            this.panel4.Controls.Add(this.labelDegradado4);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 61);
            this.panel4.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 270;
            this.label3.Text = "Mes";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.DropDownWidth = 110;
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(174, 28);
            this.cboMes.Margin = new System.Windows.Forms.Padding(2);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(114, 21);
            this.cboMes.TabIndex = 269;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 268;
            this.label2.Text = "Año";
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.DropDownWidth = 110;
            this.cboAnio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(48, 28);
            this.cboAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(77, 21);
            this.cboAnio.TabIndex = 267;
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
            this.labelDegradado4.Size = new System.Drawing.Size(303, 18);
            this.labelDegradado4.TabIndex = 248;
            this.labelDegradado4.Text = "Periodo";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListado);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1078, 336);
            this.panel5.TabIndex = 308;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReciboHonorarios,
            this.RUC,
            this.idDocumento,
            this.serDocumento,
            this.numDocumento,
            this.NomPersona,
            this.impReciboDataGridViewTextBoxColumn,
            this.impCuartaCatDataGridViewTextBoxColumn,
            this.desEstado,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.indEstado,
            this.EsCancelado});
            this.dgvListado.ContextMenuStrip = this.cmsRRHH;
            this.dgvListado.DataSource = this.bsRecibohonorarios;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 18);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1076, 316);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            // 
            // idReciboHonorarios
            // 
            this.idReciboHonorarios.DataPropertyName = "idReciboHonorarios";
            this.idReciboHonorarios.HeaderText = "ID.";
            this.idReciboHonorarios.Name = "idReciboHonorarios";
            this.idReciboHonorarios.ReadOnly = true;
            this.idReciboHonorarios.Visible = false;
            this.idReciboHonorarios.Width = 40;
            // 
            // RUC
            // 
            this.RUC.DataPropertyName = "RUC";
            this.RUC.HeaderText = "RUC";
            this.RUC.Name = "RUC";
            this.RUC.ReadOnly = true;
            this.RUC.Width = 90;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumento.DefaultCellStyle = dataGridViewCellStyle6;
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Visible = false;
            this.idDocumento.Width = 35;
            // 
            // serDocumento
            // 
            this.serDocumento.DataPropertyName = "serDocumento";
            this.serDocumento.HeaderText = "Serie";
            this.serDocumento.Name = "serDocumento";
            this.serDocumento.ReadOnly = true;
            this.serDocumento.Visible = false;
            this.serDocumento.Width = 40;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "N°";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            this.numDocumento.Visible = false;
            this.numDocumento.Width = 90;
            // 
            // NomPersona
            // 
            this.NomPersona.DataPropertyName = "NomPersona";
            this.NomPersona.HeaderText = "Nombres y Apellidos";
            this.NomPersona.Name = "NomPersona";
            this.NomPersona.ReadOnly = true;
            this.NomPersona.Width = 250;
            // 
            // impReciboDataGridViewTextBoxColumn
            // 
            this.impReciboDataGridViewTextBoxColumn.DataPropertyName = "impRecibo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.impReciboDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.impReciboDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.impReciboDataGridViewTextBoxColumn.Name = "impReciboDataGridViewTextBoxColumn";
            this.impReciboDataGridViewTextBoxColumn.ReadOnly = true;
            this.impReciboDataGridViewTextBoxColumn.Width = 80;
            // 
            // impCuartaCatDataGridViewTextBoxColumn
            // 
            this.impCuartaCatDataGridViewTextBoxColumn.DataPropertyName = "impCuartaCat";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.impCuartaCatDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.impCuartaCatDataGridViewTextBoxColumn.HeaderText = "Cuarta Cat.";
            this.impCuartaCatDataGridViewTextBoxColumn.Name = "impCuartaCatDataGridViewTextBoxColumn";
            this.impCuartaCatDataGridViewTextBoxColumn.ReadOnly = true;
            this.impCuartaCatDataGridViewTextBoxColumn.Width = 80;
            // 
            // desEstado
            // 
            this.desEstado.DataPropertyName = "desEstado";
            this.desEstado.HeaderText = "Estado";
            this.desEstado.Name = "desEstado";
            this.desEstado.ReadOnly = true;
            this.desEstado.Width = 90;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            this.indEstado.HeaderText = "indEstado";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.Visible = false;
            // 
            // EsCancelado
            // 
            this.EsCancelado.DataPropertyName = "EsCancelado";
            this.EsCancelado.HeaderText = "EsCancelado";
            this.EsCancelado.Name = "EsCancelado";
            this.EsCancelado.ReadOnly = true;
            this.EsCancelado.Visible = false;
            // 
            // cmsRRHH
            // 
            this.cmsRRHH.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsRRHH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerar,
            this.tsmiAbrir,
            this.toolStripSeparator2,
            this.tsmVoucher,
            this.tsmiLimpiar});
            this.cmsRRHH.Name = "cmsFactura";
            this.cmsRRHH.Size = new System.Drawing.Size(162, 98);
            // 
            // tsmiGenerar
            // 
            this.tsmiGenerar.Image = global::ClienteWinForm.Properties.Resources.Cerrar_Grande;
            this.tsmiGenerar.Name = "tsmiGenerar";
            this.tsmiGenerar.Size = new System.Drawing.Size(161, 22);
            this.tsmiGenerar.Text = "Cerrar RRHH";
            this.tsmiGenerar.Click += new System.EventHandler(this.tsmiGenerar_Click);
            // 
            // tsmiAbrir
            // 
            this.tsmiAbrir.Image = global::ClienteWinForm.Properties.Resources.ActualizarExcel;
            this.tsmiAbrir.Name = "tsmiAbrir";
            this.tsmiAbrir.Size = new System.Drawing.Size(161, 22);
            this.tsmiAbrir.Text = "Abrir RRHH";
            this.tsmiAbrir.Click += new System.EventHandler(this.tsmiAbrir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // tsmVoucher
            // 
            this.tsmVoucher.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.tsmVoucher.Name = "tsmVoucher";
            this.tsmVoucher.Size = new System.Drawing.Size(161, 22);
            this.tsmVoucher.Text = "Ver Voucher";
            this.tsmVoucher.Click += new System.EventHandler(this.tsmVoucher_Click);
            // 
            // tsmiLimpiar
            // 
            this.tsmiLimpiar.Image = global::ClienteWinForm.Properties.Resources.VentanaLimpia24_x_24;
            this.tsmiLimpiar.Name = "tsmiLimpiar";
            this.tsmiLimpiar.Size = new System.Drawing.Size(161, 22);
            this.tsmiLimpiar.Text = "Limpiar Voucher";
            this.tsmiLimpiar.Visible = false;
            this.tsmiLimpiar.Click += new System.EventHandler(this.tsmiLimpiar_Click);
            // 
            // bsRecibohonorarios
            // 
            this.bsRecibohonorarios.DataSource = typeof(Entidades.Contabilidad.ReciboHonorariosE);
            this.bsRecibohonorarios.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsRecibohonorarios_ListChanged);
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
            this.lblRegistros.Size = new System.Drawing.Size(1076, 18);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(310, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 61);
            this.panel1.TabIndex = 309;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(90, 28);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(415, 20);
            this.txtFiltro.TabIndex = 269;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 268;
            this.label4.Text = "Razón Social";
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
            this.labelDegradado1.Size = new System.Drawing.Size(543, 18);
            this.labelDegradado1.TabIndex = 248;
            this.labelDegradado1.Text = "Buscar por...";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.rbR);
            this.panel2.Controls.Add(this.rbA);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Location = new System.Drawing.Point(857, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 61);
            this.panel2.TabIndex = 310;
            // 
            // rbR
            // 
            this.rbR.AutoSize = true;
            this.rbR.Location = new System.Drawing.Point(126, 30);
            this.rbR.Name = "rbR";
            this.rbR.Size = new System.Drawing.Size(78, 17);
            this.rbR.TabIndex = 304;
            this.rbR.Text = "Por Recibo";
            this.rbR.UseVisualStyleBackColor = true;
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Checked = true;
            this.rbA.Location = new System.Drawing.Point(24, 30);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(77, 17);
            this.rbA.TabIndex = 302;
            this.rbA.TabStop = true;
            this.rbA.Text = "Por Auxiliar";
            this.rbA.UseVisualStyleBackColor = true;
            this.rbA.CheckedChanged += new System.EventHandler(this.rbA_CheckedChanged);
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
            this.labelDegradado2.Size = new System.Drawing.Size(222, 18);
            this.labelDegradado2.TabIndex = 269;
            this.labelDegradado2.Text = "Tipo";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(7, 10);
            this.button1.TabIndex = 305;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReciboHonorariosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.Name = "frmReciboHonorariosListado";
            this.Text = "Listado de Trabajadores Independientes";
            this.Load += new System.EventHandler(this.frmReciboHonorariosListado_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.cmsRRHH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsRecibohonorarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAnio;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label4;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.BindingSource bsRecibohonorarios;
        private System.Windows.Forms.ContextMenuStrip cmsRRHH;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerar;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbR;
        private System.Windows.Forms.RadioButton rbA;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReciboHonorarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn impReciboDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impCuartaCatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsCancelado;
        private System.Windows.Forms.Button button1;
    }
}