namespace ClienteWinForm.Ventas
{
    partial class frmListadoLetrasAprobacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbPendientes = new System.Windows.Forms.RadioButton();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dgvLetras = new System.Windows.Forms.DataGridView();
            this.tipCanjeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVenc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVoucherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMenuLetras = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAprobarLetras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDesaprobarLetra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmRenovar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefinanciar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiVerVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLimpiarVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEstados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCobranzas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCorregir = new System.Windows.Forms.ToolStripMenuItem();
            this.bsLetras = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btActualizarCtaCte = new System.Windows.Forms.Button();
            this.txtIdCliente = new ControlesWinForm.SuperTextBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbRenovacion = new System.Windows.Forms.RadioButton();
            this.rbTodosCanje = new System.Windows.Forms.RadioButton();
            this.rbCanje = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.rbVencimiento = new System.Windows.Forms.RadioButton();
            this.rbEmision = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetras)).BeginInit();
            this.cmsMenuLetras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLetras)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rbTodos);
            this.panel2.Controls.Add(this.rbPendientes);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(96, 81);
            this.panel2.TabIndex = 307;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(11, 53);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 302;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbPendientes
            // 
            this.rbPendientes.AutoSize = true;
            this.rbPendientes.Location = new System.Drawing.Point(11, 30);
            this.rbPendientes.Name = "rbPendientes";
            this.rbPendientes.Size = new System.Drawing.Size(78, 17);
            this.rbPendientes.TabIndex = 301;
            this.rbPendientes.Text = "Pendientes";
            this.rbPendientes.UseVisualStyleBackColor = true;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Controls.Add(this.dgvLetras);
            this.pnlContenedor.Controls.Add(this.LblTitulo);
            this.pnlContenedor.Location = new System.Drawing.Point(3, 86);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1040, 339);
            this.pnlContenedor.TabIndex = 306;
            // 
            // dgvLetras
            // 
            this.dgvLetras.AllowUserToAddRows = false;
            this.dgvLetras.AllowUserToDeleteRows = false;
            this.dgvLetras.AutoGenerateColumns = false;
            this.dgvLetras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLetras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLetras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipCanjeDataGridViewTextBoxColumn,
            this.codCanje,
            this.Letra,
            this.Fecha,
            this.FechaVenc,
            this.RazonSocial,
            this.desMoneda,
            this.MontoOrigen,
            this.estadoDataGridViewTextBoxColumn,
            this.idComprobanteDataGridViewTextBoxColumn,
            this.numFileDataGridViewTextBoxColumn,
            this.numVoucherDataGridViewTextBoxColumn,
            this.anioPeriodoDataGridViewTextBoxColumn,
            this.mesPeriodoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.Estado});
            this.dgvLetras.ContextMenuStrip = this.cmsMenuLetras;
            this.dgvLetras.DataSource = this.bsLetras;
            this.dgvLetras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLetras.EnableHeadersVisualStyles = false;
            this.dgvLetras.Location = new System.Drawing.Point(0, 18);
            this.dgvLetras.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLetras.Name = "dgvLetras";
            this.dgvLetras.ReadOnly = true;
            this.dgvLetras.RowTemplate.Height = 24;
            this.dgvLetras.Size = new System.Drawing.Size(1038, 319);
            this.dgvLetras.TabIndex = 271;
            this.dgvLetras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLetras_CellDoubleClick);
            this.dgvLetras.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLetras_CellFormatting);
            this.dgvLetras.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLetras_ColumnHeaderMouseClick);
            // 
            // tipCanjeDataGridViewTextBoxColumn
            // 
            this.tipCanjeDataGridViewTextBoxColumn.DataPropertyName = "tipCanje";
            this.tipCanjeDataGridViewTextBoxColumn.Frozen = true;
            this.tipCanjeDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipCanjeDataGridViewTextBoxColumn.Name = "tipCanjeDataGridViewTextBoxColumn";
            this.tipCanjeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipCanjeDataGridViewTextBoxColumn.Width = 35;
            // 
            // codCanje
            // 
            this.codCanje.DataPropertyName = "codCanje";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCanje.DefaultCellStyle = dataGridViewCellStyle1;
            this.codCanje.HeaderText = "Canj./Ren.";
            this.codCanje.Name = "codCanje";
            this.codCanje.ReadOnly = true;
            this.codCanje.Width = 85;
            // 
            // Letra
            // 
            this.Letra.DataPropertyName = "Letra";
            this.Letra.HeaderText = "Letra";
            this.Letra.Name = "Letra";
            this.Letra.ReadOnly = true;
            this.Letra.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 70;
            // 
            // FechaVenc
            // 
            this.FechaVenc.DataPropertyName = "FechaVenc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.FechaVenc.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaVenc.HeaderText = "F.Venc.";
            this.FechaVenc.Name = "FechaVenc";
            this.FechaVenc.ReadOnly = true;
            this.FechaVenc.Width = 70;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Cliente";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 200;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 40;
            // 
            // MontoOrigen
            // 
            this.MontoOrigen.DataPropertyName = "MontoOrigen";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.MontoOrigen.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoOrigen.HeaderText = "Monto";
            this.MontoOrigen.Name = "MontoOrigen";
            this.MontoOrigen.ReadOnly = true;
            this.MontoOrigen.Width = 65;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "desEstado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Est.";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idComprobanteDataGridViewTextBoxColumn
            // 
            this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "idComprobante";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idComprobanteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "Lib.";
            this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
            this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idComprobanteDataGridViewTextBoxColumn.Width = 30;
            // 
            // numFileDataGridViewTextBoxColumn
            // 
            this.numFileDataGridViewTextBoxColumn.DataPropertyName = "numFile";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numFileDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.numFileDataGridViewTextBoxColumn.HeaderText = "Fil.";
            this.numFileDataGridViewTextBoxColumn.Name = "numFileDataGridViewTextBoxColumn";
            this.numFileDataGridViewTextBoxColumn.ReadOnly = true;
            this.numFileDataGridViewTextBoxColumn.Width = 30;
            // 
            // numVoucherDataGridViewTextBoxColumn
            // 
            this.numVoucherDataGridViewTextBoxColumn.DataPropertyName = "numVoucher";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numVoucherDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.numVoucherDataGridViewTextBoxColumn.HeaderText = "Voucher";
            this.numVoucherDataGridViewTextBoxColumn.Name = "numVoucherDataGridViewTextBoxColumn";
            this.numVoucherDataGridViewTextBoxColumn.ReadOnly = true;
            this.numVoucherDataGridViewTextBoxColumn.Width = 65;
            // 
            // anioPeriodoDataGridViewTextBoxColumn
            // 
            this.anioPeriodoDataGridViewTextBoxColumn.DataPropertyName = "AnioPeriodo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.anioPeriodoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.anioPeriodoDataGridViewTextBoxColumn.HeaderText = "Año";
            this.anioPeriodoDataGridViewTextBoxColumn.Name = "anioPeriodoDataGridViewTextBoxColumn";
            this.anioPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.anioPeriodoDataGridViewTextBoxColumn.Width = 35;
            // 
            // mesPeriodoDataGridViewTextBoxColumn
            // 
            this.mesPeriodoDataGridViewTextBoxColumn.DataPropertyName = "MesPeriodo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mesPeriodoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.mesPeriodoDataGridViewTextBoxColumn.HeaderText = "Mes";
            this.mesPeriodoDataGridViewTextBoxColumn.Name = "mesPeriodoDataGridViewTextBoxColumn";
            this.mesPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.mesPeriodoDataGridViewTextBoxColumn.Width = 35;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // cmsMenuLetras
            // 
            this.cmsMenuLetras.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsMenuLetras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAprobarLetras,
            this.tsmiDesaprobarLetra,
            this.toolStripSeparator1,
            this.tsmRenovar,
            this.tsmRefinanciar,
            this.toolStripSeparator2,
            this.tsmiVerVoucher,
            this.tsmiLimpiarVoucher,
            this.tsmEstados,
            this.tsmiCobranzas,
            this.tsmiRegenerar,
            this.tsmiCorregir});
            this.cmsMenuLetras.Name = "cmsMenuLetras";
            this.cmsMenuLetras.Size = new System.Drawing.Size(211, 236);
            // 
            // tsmAprobarLetras
            // 
            this.tsmAprobarLetras.Image = global::ClienteWinForm.Properties.Resources.Aprobar;
            this.tsmAprobarLetras.Name = "tsmAprobarLetras";
            this.tsmAprobarLetras.Size = new System.Drawing.Size(210, 22);
            this.tsmAprobarLetras.Text = "Aprobar Letras";
            this.tsmAprobarLetras.Click += new System.EventHandler(this.tsmAprobarLetras_Click);
            // 
            // tsmiDesaprobarLetra
            // 
            this.tsmiDesaprobarLetra.Image = global::ClienteWinForm.Properties.Resources.Desaprobar;
            this.tsmiDesaprobarLetra.Name = "tsmiDesaprobarLetra";
            this.tsmiDesaprobarLetra.Size = new System.Drawing.Size(210, 22);
            this.tsmiDesaprobarLetra.Text = "Desaprobar Letras";
            this.tsmiDesaprobarLetra.Click += new System.EventHandler(this.tsmiDesaprobarLetra_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmRenovar
            // 
            this.tsmRenovar.Image = global::ClienteWinForm.Properties.Resources.Regenerar;
            this.tsmRenovar.Name = "tsmRenovar";
            this.tsmRenovar.Size = new System.Drawing.Size(210, 22);
            this.tsmRenovar.Text = "Renovar Letra";
            this.tsmRenovar.Click += new System.EventHandler(this.tsmRenovar_Click);
            // 
            // tsmRefinanciar
            // 
            this.tsmRefinanciar.Name = "tsmRefinanciar";
            this.tsmRefinanciar.Size = new System.Drawing.Size(210, 22);
            this.tsmRefinanciar.Text = "Refinanciar";
            this.tsmRefinanciar.Visible = false;
            this.tsmRefinanciar.Click += new System.EventHandler(this.tsmRefinanciar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiVerVoucher
            // 
            this.tsmiVerVoucher.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.tsmiVerVoucher.Name = "tsmiVerVoucher";
            this.tsmiVerVoucher.Size = new System.Drawing.Size(210, 22);
            this.tsmiVerVoucher.Text = "Ver Voucher";
            this.tsmiVerVoucher.Click += new System.EventHandler(this.tsmiVerVoucher_Click);
            // 
            // tsmiLimpiarVoucher
            // 
            this.tsmiLimpiarVoucher.Image = global::ClienteWinForm.Properties.Resources.VentanaLimpia24_x_24;
            this.tsmiLimpiarVoucher.Name = "tsmiLimpiarVoucher";
            this.tsmiLimpiarVoucher.Size = new System.Drawing.Size(210, 22);
            this.tsmiLimpiarVoucher.Text = "Limpiar Datos Conta.";
            this.tsmiLimpiarVoucher.Click += new System.EventHandler(this.tsmiLimpiarVoucher_Click);
            // 
            // tsmEstados
            // 
            this.tsmEstados.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmEstados.Image = global::ClienteWinForm.Properties.Resources.buscar_16x16neg;
            this.tsmEstados.Name = "tsmEstados";
            this.tsmEstados.Size = new System.Drawing.Size(210, 22);
            this.tsmEstados.Text = "Estados(Planilla de Letras)";
            this.tsmEstados.Click += new System.EventHandler(this.tsmEstados_Click);
            // 
            // tsmiCobranzas
            // 
            this.tsmiCobranzas.Image = global::ClienteWinForm.Properties.Resources.Buscar;
            this.tsmiCobranzas.Name = "tsmiCobranzas";
            this.tsmiCobranzas.Size = new System.Drawing.Size(210, 22);
            this.tsmiCobranzas.Text = "Revisar Cobranzas";
            this.tsmiCobranzas.Click += new System.EventHandler(this.tsmiCobranzas_Click);
            // 
            // tsmiRegenerar
            // 
            this.tsmiRegenerar.Name = "tsmiRegenerar";
            this.tsmiRegenerar.Size = new System.Drawing.Size(210, 22);
            this.tsmiRegenerar.Text = "Regenera Voucher";
            this.tsmiRegenerar.Visible = false;
            this.tsmiRegenerar.Click += new System.EventHandler(this.tsmiRegenerar_Click);
            // 
            // tsmiCorregir
            // 
            this.tsmiCorregir.Image = global::ClienteWinForm.Properties.Resources.GenerarAzul_24x24;
            this.tsmiCorregir.Name = "tsmiCorregir";
            this.tsmiCorregir.Size = new System.Drawing.Size(210, 22);
            this.tsmiCorregir.Text = "Corregir T.C. en Letras";
            this.tsmiCorregir.Click += new System.EventHandler(this.tsmiCorregir_Click);
            // 
            // bsLetras
            // 
            this.bsLetras.DataSource = typeof(Entidades.Ventas.LetrasE);
            this.bsLetras.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsLetras_ListChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btActualizarCtaCte);
            this.panel4.Controls.Add(this.txtIdCliente);
            this.panel4.Controls.Add(this.txtRuc);
            this.panel4.Controls.Add(this.txtRazonSocial);
            this.panel4.Location = new System.Drawing.Point(589, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(454, 81);
            this.panel4.TabIndex = 310;
            // 
            // btActualizarCtaCte
            // 
            this.btActualizarCtaCte.Location = new System.Drawing.Point(455, 29);
            this.btActualizarCtaCte.Name = "btActualizarCtaCte";
            this.btActualizarCtaCte.Size = new System.Drawing.Size(23, 21);
            this.btActualizarCtaCte.TabIndex = 271;
            this.btActualizarCtaCte.Text = "...";
            this.btActualizarCtaCte.UseVisualStyleBackColor = true;
            this.btActualizarCtaCte.Visible = false;
            this.btActualizarCtaCte.Click += new System.EventHandler(this.btActualizarCtaCte_Click);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(166, 28);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(23, 20);
            this.txtIdCliente.TabIndex = 270;
            this.txtIdCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCliente.TextoVacio = "";
            this.txtIdCliente.Visible = false;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(12, 28);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(151, 20);
            this.txtRuc.TabIndex = 30;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "Ingrese Ruc";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(12, 51);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(426, 20);
            this.txtRazonSocial.TabIndex = 20;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Ingrese Razon Social";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.rbRenovacion);
            this.panel3.Controls.Add(this.rbTodosCanje);
            this.panel3.Controls.Add(this.rbCanje);
            this.panel3.Location = new System.Drawing.Point(418, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 81);
            this.panel3.TabIndex = 309;
            // 
            // rbRenovacion
            // 
            this.rbRenovacion.AutoSize = true;
            this.rbRenovacion.Location = new System.Drawing.Point(78, 31);
            this.rbRenovacion.Name = "rbRenovacion";
            this.rbRenovacion.Size = new System.Drawing.Size(83, 17);
            this.rbRenovacion.TabIndex = 303;
            this.rbRenovacion.Text = "Renovación";
            this.rbRenovacion.UseVisualStyleBackColor = true;
            // 
            // rbTodosCanje
            // 
            this.rbTodosCanje.AutoSize = true;
            this.rbTodosCanje.Checked = true;
            this.rbTodosCanje.Location = new System.Drawing.Point(11, 53);
            this.rbTodosCanje.Name = "rbTodosCanje";
            this.rbTodosCanje.Size = new System.Drawing.Size(55, 17);
            this.rbTodosCanje.TabIndex = 302;
            this.rbTodosCanje.TabStop = true;
            this.rbTodosCanje.Text = "Todos";
            this.rbTodosCanje.UseVisualStyleBackColor = true;
            // 
            // rbCanje
            // 
            this.rbCanje.AutoSize = true;
            this.rbCanje.Location = new System.Drawing.Point(11, 30);
            this.rbCanje.Name = "rbCanje";
            this.rbCanje.Size = new System.Drawing.Size(52, 17);
            this.rbCanje.TabIndex = 301;
            this.rbCanje.Text = "Canje";
            this.rbCanje.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFecFin);
            this.panel1.Controls.Add(this.dtpFecIni);
            this.panel1.Controls.Add(this.rbVencimiento);
            this.panel1.Controls.Add(this.rbEmision);
            this.panel1.Location = new System.Drawing.Point(101, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 81);
            this.panel1.TabIndex = 308;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 305;
            this.label1.Text = "al";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFin.Location = new System.Drawing.Point(218, 40);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(84, 20);
            this.dtpFecFin.TabIndex = 304;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.CustomFormat = "dd/MM/yyyy";
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecIni.Location = new System.Drawing.Point(110, 40);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(84, 20);
            this.dtpFecIni.TabIndex = 303;
            // 
            // rbVencimiento
            // 
            this.rbVencimiento.AutoSize = true;
            this.rbVencimiento.Location = new System.Drawing.Point(11, 53);
            this.rbVencimiento.Name = "rbVencimiento";
            this.rbVencimiento.Size = new System.Drawing.Size(83, 17);
            this.rbVencimiento.TabIndex = 302;
            this.rbVencimiento.Text = "Vencimiento";
            this.rbVencimiento.UseVisualStyleBackColor = true;
            // 
            // rbEmision
            // 
            this.rbEmision.AutoSize = true;
            this.rbEmision.Checked = true;
            this.rbEmision.Location = new System.Drawing.Point(11, 30);
            this.rbEmision.Name = "rbEmision";
            this.rbEmision.Size = new System.Drawing.Size(61, 17);
            this.rbEmision.TabIndex = 301;
            this.rbEmision.TabStop = true;
            this.rbEmision.Text = "Emisión";
            this.rbEmision.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 374;
            this.label2.Text = "Letras";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 18);
            this.label3.TabIndex = 374;
            this.label3.Text = "Fechas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 18);
            this.label4.TabIndex = 374;
            this.label4.Text = "Tipo Canje";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(452, 18);
            this.label5.TabIndex = 374;
            this.label5.Text = "Cliente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1038, 18);
            this.LblTitulo.TabIndex = 374;
            this.LblTitulo.Text = "Registros 0";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoLetrasAprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoLetrasAprobacion";
            this.Text = "Aprobación de Letras";
            this.Load += new System.EventHandler(this.frmListadoLetrasAprobacion_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetras)).EndInit();
            this.cmsMenuLetras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsLetras)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbPendientes;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.DataGridView dgvLetras;
        private System.Windows.Forms.ContextMenuStrip cmsMenuLetras;
        private System.Windows.Forms.ToolStripMenuItem tsmAprobarLetras;
        private System.Windows.Forms.ToolStripMenuItem tsmRenovar;
        private System.Windows.Forms.ToolStripMenuItem tsmRefinanciar;
        private System.Windows.Forms.ToolStripMenuItem tsmEstados;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerVoucher;
        private System.Windows.Forms.BindingSource bsLetras;
        private System.Windows.Forms.Panel panel4;
        private ControlesWinForm.SuperTextBox txtIdCliente;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbRenovacion;
        private System.Windows.Forms.RadioButton rbTodosCanje;
        private System.Windows.Forms.RadioButton rbCanje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.RadioButton rbVencimiento;
        private System.Windows.Forms.RadioButton rbEmision;
        private System.Windows.Forms.ToolStripMenuItem tsmiDesaprobarLetra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLimpiarVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmiCobranzas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCanjeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVoucherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button btActualizarCtaCte;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegenerar;
        private System.Windows.Forms.ToolStripMenuItem tsmiCorregir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}