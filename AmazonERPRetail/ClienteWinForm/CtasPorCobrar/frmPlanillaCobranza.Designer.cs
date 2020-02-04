namespace ClienteWinForm.CtasPorCobrar
{
    partial class frmPlanillaCobranza
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
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.fecCobranzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipCambioReci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCobranzaItems = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.lblDolares = new MyLabelG.LabelDegradado();
            this.lblSoles = new MyLabelG.LabelDegradado();
            this.pnlCobranza = new System.Windows.Forms.Panel();
            this.txtCodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtMes = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVoucher = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAnioPeriodo = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEstado = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboComprobantes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservación = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodPlanilla = new ControlesWinForm.SuperTextBox();
            this.cboTipoCobranza = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboBancos = new System.Windows.Forms.ComboBox();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            this.pnlAuditoria.SuspendLayout();
            this.pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCobranzaItems)).BeginInit();
            this.pnlCobranza.SuspendLayout();
            this.SuspendLayout();
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(8, 95);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificación";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(8, 73);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificación";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label26.Location = new System.Drawing.Point(8, 28);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(86, 13);
            label26.TabIndex = 0;
            label26.Text = "Usuario Registro";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.Location = new System.Drawing.Point(8, 50);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(79, 13);
            label27.TabIndex = 2;
            label27.Text = "Fecha Registro";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(792, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 287;
            this.label11.Text = "Total US$";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label24);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label25);
            this.pnlAuditoria.Controls.Add(label26);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label27);
            this.pnlAuditoria.Location = new System.Drawing.Point(672, 3);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 121);
            this.pnlAuditoria.TabIndex = 363;
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
            this.labelDegradado4.Size = new System.Drawing.Size(265, 18);
            this.labelDegradado4.TabIndex = 800;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(114, 91);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(137, 21);
            this.txtFechaModificacion.TabIndex = 304;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 24);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(137, 21);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 69);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(137, 21);
            this.txtUsuarioModificacion.TabIndex = 303;
            this.txtUsuarioModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 46);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(137, 21);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(668, 385);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 286;
            this.label10.Text = "Total S/.";
            // 
            // pnlListado
            // 
            this.pnlListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListado.Controls.Add(this.dgvDetalle);
            this.pnlListado.Controls.Add(this.lblRegistros);
            this.pnlListado.Location = new System.Drawing.Point(3, 127);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(936, 251);
            this.pnlListado.TabIndex = 300;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecCobranzaDataGridViewTextBoxColumn,
            this.idDocumento,
            this.numSerie,
            this.numCheque,
            this.idMoneda,
            this.Monto,
            this.tipCambioReci,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.bsCobranzaItems;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 17);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new System.Drawing.Size(934, 232);
            this.dgvDetalle.TabIndex = 250;
            this.dgvDetalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellDoubleClick);
            // 
            // fecCobranzaDataGridViewTextBoxColumn
            // 
            this.fecCobranzaDataGridViewTextBoxColumn.DataPropertyName = "fecCobranza";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fecCobranzaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecCobranzaDataGridViewTextBoxColumn.HeaderText = "Fec.Cobro";
            this.fecCobranzaDataGridViewTextBoxColumn.Name = "fecCobranzaDataGridViewTextBoxColumn";
            this.fecCobranzaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecCobranzaDataGridViewTextBoxColumn.Width = 70;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 40;
            // 
            // numSerie
            // 
            this.numSerie.DataPropertyName = "numSerie";
            this.numSerie.HeaderText = "Serie";
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            this.numSerie.Width = 50;
            // 
            // numCheque
            // 
            this.numCheque.DataPropertyName = "numCheque";
            this.numCheque.HeaderText = "Número";
            this.numCheque.Name = "numCheque";
            this.numCheque.ReadOnly = true;
            this.numCheque.Width = 80;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idMoneda.DefaultCellStyle = dataGridViewCellStyle2;
            this.idMoneda.HeaderText = "Mon.";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.ReadOnly = true;
            this.idMoneda.Width = 40;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle3;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 80;
            // 
            // tipCambioReci
            // 
            this.tipCambioReci.DataPropertyName = "tipCambioReci";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.tipCambioReci.DefaultCellStyle = dataGridViewCellStyle4;
            this.tipCambioReci.HeaderText = "T.Cambio";
            this.tipCambioReci.Name = "tipCambioReci";
            this.tipCambioReci.ReadOnly = true;
            this.tipCambioReci.Width = 60;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsCobranzaItems
            // 
            this.bsCobranzaItems.DataSource = typeof(Entidades.CtasPorCobrar.CobranzasItemE);
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
            this.lblRegistros.Size = new System.Drawing.Size(934, 17);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Detalle";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDolares
            // 
            this.lblDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDolares.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDolares.ForeColor = System.Drawing.Color.Black;
            this.lblDolares.Location = new System.Drawing.Point(853, 381);
            this.lblDolares.Name = "lblDolares";
            this.lblDolares.PrimerColor = System.Drawing.Color.AliceBlue;
            this.lblDolares.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblDolares.Size = new System.Drawing.Size(68, 20);
            this.lblDolares.TabIndex = 285;
            this.lblDolares.Text = "0.00";
            this.lblDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoles
            // 
            this.lblSoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoles.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoles.ForeColor = System.Drawing.Color.Black;
            this.lblSoles.Location = new System.Drawing.Point(723, 381);
            this.lblSoles.Name = "lblSoles";
            this.lblSoles.PrimerColor = System.Drawing.Color.AliceBlue;
            this.lblSoles.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblSoles.Size = new System.Drawing.Size(68, 20);
            this.lblSoles.TabIndex = 284;
            this.lblSoles.Text = "0.00";
            this.lblSoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCobranza
            // 
            this.pnlCobranza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCobranza.Controls.Add(this.cboBancos);
            this.pnlCobranza.Controls.Add(this.txtCodCuenta);
            this.pnlCobranza.Controls.Add(this.txtMes);
            this.pnlCobranza.Controls.Add(this.label9);
            this.pnlCobranza.Controls.Add(this.txtVoucher);
            this.pnlCobranza.Controls.Add(this.label8);
            this.pnlCobranza.Controls.Add(this.txtAnioPeriodo);
            this.pnlCobranza.Controls.Add(this.label7);
            this.pnlCobranza.Controls.Add(this.txtEstado);
            this.pnlCobranza.Controls.Add(this.label6);
            this.pnlCobranza.Controls.Add(this.cboFile);
            this.pnlCobranza.Controls.Add(this.label5);
            this.pnlCobranza.Controls.Add(this.cboComprobantes);
            this.pnlCobranza.Controls.Add(this.label4);
            this.pnlCobranza.Controls.Add(this.label3);
            this.pnlCobranza.Controls.Add(this.txtObservación);
            this.pnlCobranza.Controls.Add(this.label2);
            this.pnlCobranza.Controls.Add(this.dtpFecha);
            this.pnlCobranza.Controls.Add(this.label1);
            this.pnlCobranza.Controls.Add(this.txtCodPlanilla);
            this.pnlCobranza.Controls.Add(this.cboTipoCobranza);
            this.pnlCobranza.Controls.Add(this.labelDegradado1);
            this.pnlCobranza.Location = new System.Drawing.Point(3, 3);
            this.pnlCobranza.Name = "pnlCobranza";
            this.pnlCobranza.Size = new System.Drawing.Size(666, 121);
            this.pnlCobranza.TabIndex = 103;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodCuenta.Enabled = false;
            this.txtCodCuenta.Location = new System.Drawing.Point(674, 46);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(23, 20);
            this.txtCodCuenta.TabIndex = 283;
            this.txtCodCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodCuenta.TextoVacio = "<Descripcion>";
            this.txtCodCuenta.Visible = false;
            // 
            // txtMes
            // 
            this.txtMes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMes.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMes.Enabled = false;
            this.txtMes.Location = new System.Drawing.Point(127, 91);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(27, 20);
            this.txtMes.TabIndex = 282;
            this.txtMes.TabStop = false;
            this.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMes.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 281;
            this.label9.Text = "Asiento";
            // 
            // txtVoucher
            // 
            this.txtVoucher.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtVoucher.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtVoucher.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtVoucher.Enabled = false;
            this.txtVoucher.Location = new System.Drawing.Point(199, 91);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(73, 20);
            this.txtVoucher.TabIndex = 280;
            this.txtVoucher.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtVoucher.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 279;
            this.label8.Text = "Año Periodo";
            // 
            // txtAnioPeriodo
            // 
            this.txtAnioPeriodo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAnioPeriodo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAnioPeriodo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAnioPeriodo.Enabled = false;
            this.txtAnioPeriodo.Location = new System.Drawing.Point(89, 91);
            this.txtAnioPeriodo.Name = "txtAnioPeriodo";
            this.txtAnioPeriodo.Size = new System.Drawing.Size(37, 20);
            this.txtAnioPeriodo.TabIndex = 278;
            this.txtAnioPeriodo.TabStop = false;
            this.txtAnioPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnioPeriodo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtAnioPeriodo.TextoVacio = "<Descripcion>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(510, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 277;
            this.label7.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEstado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEstado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(554, 45);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(96, 20);
            this.txtEstado.TabIndex = 276;
            this.txtEstado.TabStop = false;
            this.txtEstado.Text = "CERRADO";
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEstado.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 275;
            this.label6.Text = "File";
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.DropDownWidth = 200;
            this.cboFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFile.ForeColor = System.Drawing.Color.Black;
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(89, 68);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(183, 21);
            this.cboFile.TabIndex = 2;
            this.cboFile.SelectionChangeCommitted += new System.EventHandler(this.cboFile_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 273;
            this.label5.Text = "Libro Contable";
            // 
            // cboComprobantes
            // 
            this.cboComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComprobantes.DropDownWidth = 200;
            this.cboComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboComprobantes.ForeColor = System.Drawing.Color.Black;
            this.cboComprobantes.FormattingEnabled = true;
            this.cboComprobantes.Location = new System.Drawing.Point(89, 45);
            this.cboComprobantes.Name = "cboComprobantes";
            this.cboComprobantes.Size = new System.Drawing.Size(183, 21);
            this.cboComprobantes.TabIndex = 1;
            this.cboComprobantes.SelectionChangeCommitted += new System.EventHandler(this.cboComprobantes_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 271;
            this.label4.Text = "Tipo Planilla";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 270;
            this.label3.Text = "Banco";
            // 
            // txtObservación
            // 
            this.txtObservación.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtObservación.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtObservación.Location = new System.Drawing.Point(278, 68);
            this.txtObservación.Multiline = true;
            this.txtObservación.Name = "txtObservación";
            this.txtObservación.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservación.Size = new System.Drawing.Size(372, 44);
            this.txtObservación.TabIndex = 3;
            this.txtObservación.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtObservación.TextoVacio = "OBSERVACION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 268;
            this.label2.Text = "Fecha de Planilla";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.CustomFormat = "dd/MM/yyyyy";
            this.dtpFecha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(554, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 21);
            this.dtpFecha.TabIndex = 267;
            this.dtpFecha.TabStop = false;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 265;
            this.label1.Text = "Planilla N°";
            // 
            // txtCodPlanilla
            // 
            this.txtCodPlanilla.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodPlanilla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodPlanilla.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodPlanilla.Enabled = false;
            this.txtCodPlanilla.Location = new System.Drawing.Point(336, 22);
            this.txtCodPlanilla.Name = "txtCodPlanilla";
            this.txtCodPlanilla.Size = new System.Drawing.Size(114, 20);
            this.txtCodPlanilla.TabIndex = 264;
            this.txtCodPlanilla.TabStop = false;
            this.txtCodPlanilla.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodPlanilla.TextoVacio = "<Descripcion>";
            // 
            // cboTipoCobranza
            // 
            this.cboTipoCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCobranza.Enabled = false;
            this.cboTipoCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCobranza.ForeColor = System.Drawing.Color.Black;
            this.cboTipoCobranza.FormattingEnabled = true;
            this.cboTipoCobranza.Location = new System.Drawing.Point(89, 22);
            this.cboTipoCobranza.Name = "cboTipoCobranza";
            this.cboTipoCobranza.Size = new System.Drawing.Size(183, 21);
            this.cboTipoCobranza.TabIndex = 1500;
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
            this.labelDegradado1.Size = new System.Drawing.Size(664, 17);
            this.labelDegradado1.TabIndex = 248;
            this.labelDegradado1.Text = "Datos";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboBancos
            // 
            this.cboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancos.DropDownWidth = 200;
            this.cboBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancos.ForeColor = System.Drawing.Color.Black;
            this.cboBancos.FormattingEnabled = true;
            this.cboBancos.Location = new System.Drawing.Point(336, 44);
            this.cboBancos.Name = "cboBancos";
            this.cboBancos.Size = new System.Drawing.Size(171, 21);
            this.cboBancos.TabIndex = 1501;
            // 
            // frmPlanillaCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 405);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pnlListado);
            this.Controls.Add(this.lblDolares);
            this.Controls.Add(this.lblSoles);
            this.Controls.Add(this.pnlCobranza);
            this.MaximizeBox = false;
            this.Name = "frmPlanillaCobranza";
            this.Text = "Planilla de Cobranza (Nuevo)";
            this.Load += new System.EventHandler(this.frmPlanillaCobranza_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCobranzaItems)).EndInit();
            this.pnlCobranza.ResumeLayout(false);
            this.pnlCobranza.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCobranza;
        private System.Windows.Forms.ComboBox cboTipoCobranza;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtCodPlanilla;
        private MyLabelG.LabelDegradado lblSoles;
        private ControlesWinForm.SuperTextBox txtMes;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtVoucher;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtAnioPeriodo;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboComprobantes;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtObservación;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private MyLabelG.LabelDegradado lblDolares;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsCobranzaItems;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtCodCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecCobranzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipCambioReci;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cboBancos;
    }
}