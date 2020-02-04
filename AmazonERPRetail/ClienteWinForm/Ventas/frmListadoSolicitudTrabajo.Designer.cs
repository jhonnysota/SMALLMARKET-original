namespace ClienteWinForm.Ventas
{
    partial class frmListadoSolicitudTrabajo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoSolicitudTrabajo));
            this.label2 = new System.Windows.Forms.Label();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoGuias = new System.Windows.Forms.DataGridView();
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
            this.tipCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esGuiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsFactura = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEnviarCorreo = new System.Windows.Forms.ToolStripMenuItem();
            this.bsEmisionGuias = new System.Windows.Forms.BindingSource(this.components);
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.rbDesde = new System.Windows.Forms.RadioButton();
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
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoGuias)).BeginInit();
            this.cmsFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmisionGuias)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "hasta";
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoGuias);
            this.panel5.Controls.Add(this.LblRegistros);
            this.panel5.Location = new System.Drawing.Point(4, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1236, 406);
            this.panel5.TabIndex = 312;
            // 
            // dgvListadoGuias
            // 
            this.dgvListadoGuias.AllowUserToAddRows = false;
            this.dgvListadoGuias.AllowUserToDeleteRows = false;
            this.dgvListadoGuias.AutoGenerateColumns = false;
            this.dgvListadoGuias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListadoGuias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoGuias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.tipCambioDataGridViewTextBoxColumn,
            this.esGuiaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListadoGuias.ContextMenuStrip = this.cmsFactura;
            this.dgvListadoGuias.DataSource = this.bsEmisionGuias;
            this.dgvListadoGuias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoGuias.EnableHeadersVisualStyles = false;
            this.dgvListadoGuias.Location = new System.Drawing.Point(0, 18);
            this.dgvListadoGuias.Name = "dgvListadoGuias";
            this.dgvListadoGuias.ReadOnly = true;
            this.dgvListadoGuias.Size = new System.Drawing.Size(1234, 386);
            this.dgvListadoGuias.TabIndex = 250;
            this.dgvListadoGuias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoGuias_CellDoubleClick);
            this.dgvListadoGuias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoGuias_CellFormatting);
            this.dgvListadoGuias.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListadoGuias_ColumnHeaderMouseClick);
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.indEstado.DefaultCellStyle = dataGridViewCellStyle2;
            this.indEstado.Frozen = true;
            this.indEstado.HeaderText = "Est.";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.ToolTipText = "Estado del documento";
            // 
            // EnviadoSunat
            // 
            this.EnviadoSunat.DataPropertyName = "EnviadoSunat";
            this.EnviadoSunat.Frozen = true;
            this.EnviadoSunat.HeaderText = "E.S.";
            this.EnviadoSunat.Name = "EnviadoSunat";
            this.EnviadoSunat.ReadOnly = true;
            this.EnviadoSunat.ToolTipText = "Si el documento ha sido enviado a Sunat.";
            // 
            // anuladoSunatDataGridViewCheckBoxColumn
            // 
            this.anuladoSunatDataGridViewCheckBoxColumn.DataPropertyName = "AnuladoSunat";
            this.anuladoSunatDataGridViewCheckBoxColumn.Frozen = true;
            this.anuladoSunatDataGridViewCheckBoxColumn.HeaderText = "A.S.";
            this.anuladoSunatDataGridViewCheckBoxColumn.Name = "anuladoSunatDataGridViewCheckBoxColumn";
            this.anuladoSunatDataGridViewCheckBoxColumn.ReadOnly = true;
            this.anuladoSunatDataGridViewCheckBoxColumn.ToolTipText = "Si el documento ha sido anulado en Sunat.";
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idDocumentoDataGridViewTextBoxColumn.Frozen = true;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "TD";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numSerie
            // 
            this.numSerie.DataPropertyName = "numSerie";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numSerie.DefaultCellStyle = dataGridViewCellStyle4;
            this.numSerie.Frozen = true;
            this.numSerie.HeaderText = "Serie";
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numDocumento.DefaultCellStyle = dataGridViewCellStyle5;
            this.numDocumento.Frozen = true;
            this.numDocumento.HeaderText = "Num.Doc.";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            // 
            // fecEmision
            // 
            this.fecEmision.DataPropertyName = "fecEmision";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecEmision.DefaultCellStyle = dataGridViewCellStyle6;
            this.fecEmision.Frozen = true;
            this.fecEmision.HeaderText = "Fec.Emis.";
            this.fecEmision.Name = "fecEmision";
            this.fecEmision.ReadOnly = true;
            // 
            // numRuc
            // 
            this.numRuc.DataPropertyName = "numRuc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numRuc.DefaultCellStyle = dataGridViewCellStyle7;
            this.numRuc.Frozen = true;
            this.numRuc.HeaderText = "Ruc";
            this.numRuc.Name = "numRuc";
            this.numRuc.ReadOnly = true;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "RazonSocial";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle8;
            this.desMoneda.HeaderText = "M.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            // 
            // totsubTotal
            // 
            this.totsubTotal.DataPropertyName = "totsubTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "###,###,##0.00";
            dataGridViewCellStyle9.NullValue = null;
            this.totsubTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.totsubTotal.HeaderText = "SubTotal";
            this.totsubTotal.Name = "totsubTotal";
            this.totsubTotal.ReadOnly = true;
            // 
            // totIgv
            // 
            this.totIgv.DataPropertyName = "totIgv";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "###,###,##0.00";
            dataGridViewCellStyle10.NullValue = null;
            this.totIgv.DefaultCellStyle = dataGridViewCellStyle10;
            this.totIgv.HeaderText = "IGV";
            this.totIgv.Name = "totIgv";
            this.totIgv.ReadOnly = true;
            // 
            // totTotal
            // 
            this.totTotal.DataPropertyName = "totTotal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "###,###,##0.00";
            dataGridViewCellStyle11.NullValue = null;
            this.totTotal.DefaultCellStyle = dataGridViewCellStyle11;
            this.totTotal.HeaderText = "Total";
            this.totTotal.Name = "totTotal";
            this.totTotal.ReadOnly = true;
            // 
            // desTipAfectoIgv
            // 
            this.desTipAfectoIgv.DataPropertyName = "desTipAfectoIgv";
            this.desTipAfectoIgv.HeaderText = "Tipo Afecto Igv";
            this.desTipAfectoIgv.Name = "desTipAfectoIgv";
            this.desTipAfectoIgv.ReadOnly = true;
            // 
            // tipCambioDataGridViewTextBoxColumn
            // 
            this.tipCambioDataGridViewTextBoxColumn.DataPropertyName = "tipCambio";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "##0.000";
            dataGridViewCellStyle12.NullValue = null;
            this.tipCambioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.tipCambioDataGridViewTextBoxColumn.HeaderText = "T.C.";
            this.tipCambioDataGridViewTextBoxColumn.Name = "tipCambioDataGridViewTextBoxColumn";
            this.tipCambioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // esGuiaDataGridViewTextBoxColumn
            // 
            this.esGuiaDataGridViewTextBoxColumn.DataPropertyName = "EsGuia";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.esGuiaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.esGuiaDataGridViewTextBoxColumn.HeaderText = "T.F.";
            this.esGuiaDataGridViewTextBoxColumn.Name = "esGuiaDataGridViewTextBoxColumn";
            this.esGuiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.esGuiaDataGridViewTextBoxColumn.ToolTipText = "Tipo de Factura";
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cmsFactura
            // 
            this.cmsFactura.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFactura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnviarCorreo});
            this.cmsFactura.Name = "cmsFactura";
            this.cmsFactura.Size = new System.Drawing.Size(146, 26);
            // 
            // tsmiEnviarCorreo
            // 
            this.tsmiEnviarCorreo.Image = global::ClienteWinForm.Properties.Resources.Enviar_Correo;
            this.tsmiEnviarCorreo.Name = "tsmiEnviarCorreo";
            this.tsmiEnviarCorreo.Size = new System.Drawing.Size(145, 22);
            this.tsmiEnviarCorreo.Text = "Enviar Correo";
            this.tsmiEnviarCorreo.Click += new System.EventHandler(this.tsmiEnviarCorreo_Click);
            // 
            // bsEmisionGuias
            // 
            this.bsEmisionGuias.DataSource = typeof(Entidades.Ventas.EmisionDocumentoE);
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodas.Location = new System.Drawing.Point(10, 24);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(54, 17);
            this.rbTodas.TabIndex = 259;
            this.rbTodas.Text = "Todas";
            this.rbTodas.UseVisualStyleBackColor = true;
            // 
            // rbDesde
            // 
            this.rbDesde.AutoSize = true;
            this.rbDesde.Checked = true;
            this.rbDesde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesde.Location = new System.Drawing.Point(10, 45);
            this.rbDesde.Name = "rbDesde";
            this.rbDesde.Size = new System.Drawing.Size(55, 17);
            this.rbDesde.TabIndex = 257;
            this.rbDesde.TabStop = true;
            this.rbDesde.Text = "Desde";
            this.rbDesde.UseVisualStyleBackColor = true;
            this.rbDesde.CheckedChanged += new System.EventHandler(this.rbDesde_CheckedChanged);
            // 
            // btEmitir
            // 
            this.btEmitir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btEmitir.BackgroundImage")));
            this.btEmitir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btEmitir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEmitir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btEmitir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEmitir.Location = new System.Drawing.Point(964, 7);
            this.btEmitir.Name = "btEmitir";
            this.btEmitir.Size = new System.Drawing.Size(39, 30);
            this.btEmitir.TabIndex = 315;
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
            this.panel6.Location = new System.Drawing.Point(317, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 74);
            this.panel6.TabIndex = 311;
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.Enabled = false;
            this.cboSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.ForeColor = System.Drawing.Color.Blue;
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(75, 41);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(88, 21);
            this.cboSeries.TabIndex = 262;
            // 
            // rbTodasSeries
            // 
            this.rbTodasSeries.AutoSize = true;
            this.rbTodasSeries.Checked = true;
            this.rbTodasSeries.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodasSeries.Location = new System.Drawing.Point(11, 23);
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
            this.rbSeries.Location = new System.Drawing.Point(12, 44);
            this.rbSeries.Name = "rbSeries";
            this.rbSeries.Size = new System.Drawing.Size(44, 17);
            this.rbSeries.TabIndex = 260;
            this.rbSeries.Text = "Uno";
            this.rbSeries.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtRazonSocial);
            this.panel4.Controls.Add(this.txtIdAuxiliar);
            this.panel4.Controls.Add(this.rbTodosCLientes);
            this.panel4.Controls.Add(this.rbUnCliente);
            this.panel4.Controls.Add(this.txtRuc);
            this.panel4.Location = new System.Drawing.Point(499, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 74);
            this.panel4.TabIndex = 314;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(196, 43);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(260, 20);
            this.txtRazonSocial.TabIndex = 305;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Razón Social";
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtIdAuxiliar
            // 
            this.txtIdAuxiliar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtIdAuxiliar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdAuxiliar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAuxiliar.Enabled = false;
            this.txtIdAuxiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAuxiliar.Location = new System.Drawing.Point(79, 43);
            this.txtIdAuxiliar.Name = "txtIdAuxiliar";
            this.txtIdAuxiliar.Size = new System.Drawing.Size(41, 20);
            this.txtIdAuxiliar.TabIndex = 303;
            this.txtIdAuxiliar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdAuxiliar.TextoVacio = "Id";
            this.txtIdAuxiliar.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdAuxiliar_Validating);
            // 
            // rbTodosCLientes
            // 
            this.rbTodosCLientes.AutoSize = true;
            this.rbTodosCLientes.Checked = true;
            this.rbTodosCLientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodosCLientes.Location = new System.Drawing.Point(12, 27);
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
            this.rbUnCliente.Location = new System.Drawing.Point(12, 46);
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
            this.txtRuc.Location = new System.Drawing.Point(121, 43);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(74, 20);
            this.txtRuc.TabIndex = 304;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "RUC";
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(202, 43);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(94, 21);
            this.dtpFinal.TabIndex = 102;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.rbTodas);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rbDesde);
            this.panel3.Controls.Add(this.dtpInicio);
            this.panel3.Controls.Add(this.dtpFinal);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 74);
            this.panel3.TabIndex = 310;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(69, 43);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(94, 21);
            this.dtpInicio.TabIndex = 101;
            this.dtpInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpInicio_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 18);
            this.label3.TabIndex = 367;
            this.label3.Text = "Fechas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 367;
            this.label1.Text = "Series";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 18);
            this.label4.TabIndex = 367;
            this.label4.Text = "Auxiliar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblRegistros
            // 
            this.LblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(0, 0);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(1234, 18);
            this.LblRegistros.TabIndex = 367;
            this.LblRegistros.Text = "Registros 0";
            this.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoSolicitudTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 490);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btEmitir);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "frmListadoSolicitudTrabajo";
            this.Text = "Listado de Solicitudes de Factura";
            this.Load += new System.EventHandler(this.frmListadoSolicitudTrabajo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListadoSolicitudTrabajo_KeyDown);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoGuias)).EndInit();
            this.cmsFactura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsEmisionGuias)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoGuias;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn esGuiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip cmsFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnviarCorreo;
        private System.Windows.Forms.BindingSource bsEmisionGuias;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.RadioButton rbDesde;
        private System.Windows.Forms.Button btEmitir;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.RadioButton rbTodasSeries;
        private System.Windows.Forms.RadioButton rbSeries;
        private System.Windows.Forms.Panel panel4;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdAuxiliar;
        private System.Windows.Forms.RadioButton rbTodosCLientes;
        private System.Windows.Forms.RadioButton rbUnCliente;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}