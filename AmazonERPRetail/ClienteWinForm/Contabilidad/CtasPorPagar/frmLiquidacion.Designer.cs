namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiquidacion));
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvLiq = new System.Windows.Forms.DataGridView();
            this.desTipoDocumentoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCambioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoLiquidarDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesCCostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLiquidacionDet = new System.Windows.Forms.BindingSource(this.components);
            this.lblDetalle = new MyLabelG.LabelDegradado();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btEncargado = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new ControlesWinForm.SuperTextBox();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEstado = new ControlesWinForm.SuperTextBox();
            this.txtIdLiqui = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblSaldoActual = new MyLabelG.LabelDegradado();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotal = new MyLabelG.LabelDegradado();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSaldo = new MyLabelG.LabelDegradado();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlTipo = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpPeriodoFin = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpPeriodoIni = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.label25 = new System.Windows.Forms.Label();
            this.btBuscarTexto = new System.Windows.Forms.Button();
            this.txtBuscar = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLiquidacionDet)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.pnlTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(493, 4);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(265, 122);
            this.pnlAuditoria.TabIndex = 140;
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
            this.labelDegradado5.Size = new System.Drawing.Size(263, 17);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(9, 97);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(117, 93);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(134, 20);
            this.txtModifica.TabIndex = 0;
            this.txtModifica.TabStop = false;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(117, 47);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(134, 20);
            this.txtRegistro.TabIndex = 0;
            this.txtRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 28);
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
            this.label3.Location = new System.Drawing.Point(9, 51);
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
            this.label4.Location = new System.Drawing.Point(9, 74);
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
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 24);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(134, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 70);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(134, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvLiq);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 206);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(754, 287);
            this.pnlDetalle.TabIndex = 387;
            // 
            // dgvLiq
            // 
            this.dgvLiq.AllowUserToAddRows = false;
            this.dgvLiq.AllowUserToDeleteRows = false;
            this.dgvLiq.AutoGenerateColumns = false;
            this.dgvLiq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLiq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desTipoDocumentoDataGridViewTextBoxColumn1,
            this.RazonSocial1,
            this.idDocumento,
            this.numSerie,
            this.numDocumento,
            this.FechaDocumento,
            this.desMonedaDataGridViewTextBoxColumn1,
            this.montoDataGridViewTextBoxColumn1,
            this.tipoCambioDataGridViewTextBoxColumn1,
            this.montoLiquidarDataGridViewTextBoxColumn1,
            this.DesCCostos,
            this.codCuentaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn1});
            this.dgvLiq.DataSource = this.bsLiquidacionDet;
            this.dgvLiq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiq.EnableHeadersVisualStyles = false;
            this.dgvLiq.Location = new System.Drawing.Point(0, 17);
            this.dgvLiq.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLiq.Name = "dgvLiq";
            this.dgvLiq.ReadOnly = true;
            this.dgvLiq.RowTemplate.Height = 24;
            this.dgvLiq.Size = new System.Drawing.Size(752, 268);
            this.dgvLiq.TabIndex = 501;
            this.dgvLiq.TabStop = false;
            this.dgvLiq.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiq_CellDoubleClick);
            this.dgvLiq.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLiq_ColumnHeaderMouseClick);
            // 
            // desTipoDocumentoDataGridViewTextBoxColumn1
            // 
            this.desTipoDocumentoDataGridViewTextBoxColumn1.DataPropertyName = "desTipoDocumento";
            this.desTipoDocumentoDataGridViewTextBoxColumn1.HeaderText = "Tip.Liq.";
            this.desTipoDocumentoDataGridViewTextBoxColumn1.Name = "desTipoDocumentoDataGridViewTextBoxColumn1";
            this.desTipoDocumentoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.desTipoDocumentoDataGridViewTextBoxColumn1.Width = 80;
            // 
            // RazonSocial1
            // 
            this.RazonSocial1.DataPropertyName = "RazonSocial";
            this.RazonSocial1.HeaderText = "Razón Social";
            this.RazonSocial1.Name = "RazonSocial1";
            this.RazonSocial1.ReadOnly = true;
            this.RazonSocial1.Width = 150;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 30;
            // 
            // numSerie
            // 
            this.numSerie.DataPropertyName = "numSerie";
            this.numSerie.HeaderText = "Serie";
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            this.numSerie.Width = 40;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "Número";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            this.numDocumento.Width = 60;
            // 
            // FechaDocumento
            // 
            this.FechaDocumento.DataPropertyName = "FechaDocumento";
            this.FechaDocumento.HeaderText = "Fec.Doc.";
            this.FechaDocumento.Name = "FechaDocumento";
            this.FechaDocumento.ReadOnly = true;
            this.FechaDocumento.Width = 70;
            // 
            // desMonedaDataGridViewTextBoxColumn1
            // 
            this.desMonedaDataGridViewTextBoxColumn1.DataPropertyName = "desMoneda";
            this.desMonedaDataGridViewTextBoxColumn1.HeaderText = "Mon.";
            this.desMonedaDataGridViewTextBoxColumn1.Name = "desMonedaDataGridViewTextBoxColumn1";
            this.desMonedaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.desMonedaDataGridViewTextBoxColumn1.Width = 35;
            // 
            // montoDataGridViewTextBoxColumn1
            // 
            this.montoDataGridViewTextBoxColumn1.DataPropertyName = "Monto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.montoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.montoDataGridViewTextBoxColumn1.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn1.Name = "montoDataGridViewTextBoxColumn1";
            this.montoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn1.Width = 70;
            // 
            // tipoCambioDataGridViewTextBoxColumn1
            // 
            this.tipoCambioDataGridViewTextBoxColumn1.DataPropertyName = "TipoCambio";
            this.tipoCambioDataGridViewTextBoxColumn1.HeaderText = "T.C.";
            this.tipoCambioDataGridViewTextBoxColumn1.Name = "tipoCambioDataGridViewTextBoxColumn1";
            this.tipoCambioDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tipoCambioDataGridViewTextBoxColumn1.Width = 40;
            // 
            // montoLiquidarDataGridViewTextBoxColumn1
            // 
            this.montoLiquidarDataGridViewTextBoxColumn1.DataPropertyName = "MontoLiquidar";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.montoLiquidarDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoLiquidarDataGridViewTextBoxColumn1.HeaderText = "Monto Liq.";
            this.montoLiquidarDataGridViewTextBoxColumn1.Name = "montoLiquidarDataGridViewTextBoxColumn1";
            this.montoLiquidarDataGridViewTextBoxColumn1.ReadOnly = true;
            this.montoLiquidarDataGridViewTextBoxColumn1.Width = 70;
            // 
            // DesCCostos
            // 
            this.DesCCostos.DataPropertyName = "DesCCostos";
            this.DesCCostos.HeaderText = "Des. Costos";
            this.DesCCostos.Name = "DesCCostos";
            this.DesCCostos.ReadOnly = true;
            this.DesCCostos.Width = 150;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 80;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn1
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn1.Name = "usuarioRegistroDataGridViewTextBoxColumn1";
            this.usuarioRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn1
            // 
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn1.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn1.Name = "fechaRegistroDataGridViewTextBoxColumn1";
            this.fechaRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn1.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn1
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn1.Name = "usuarioModificacionDataGridViewTextBoxColumn1";
            this.usuarioModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn1
            // 
            this.fechaModificacionDataGridViewTextBoxColumn1.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn1.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn1.Name = "fechaModificacionDataGridViewTextBoxColumn1";
            this.fechaModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn1.Width = 130;
            // 
            // bsLiquidacionDet
            // 
            this.bsLiquidacionDet.DataSource = typeof(Entidades.CtasPorPagar.LiquidacionDetE);
            this.bsLiquidacionDet.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsLiquidacionDet_ListChanged);
            // 
            // lblDetalle
            // 
            this.lblDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalle.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.White;
            this.lblDetalle.Location = new System.Drawing.Point(0, 0);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblDetalle.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblDetalle.Size = new System.Drawing.Size(752, 17);
            this.lblDetalle.TabIndex = 500;
            this.lblDetalle.Text = "Detalle 0 Registros";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelDegradado2.Size = new System.Drawing.Size(484, 17);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.btEncargado);
            this.pnlDatos.Controls.Add(this.label12);
            this.pnlDatos.Controls.Add(this.txtCodCuenta);
            this.pnlDatos.Controls.Add(this.txtDesCuenta);
            this.pnlDatos.Controls.Add(this.cboLibro);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.cboFile);
            this.pnlDatos.Controls.Add(this.label16);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.txtEstado);
            this.pnlDatos.Controls.Add(this.txtIdLiqui);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtRuc);
            this.pnlDatos.Controls.Add(this.txtRazonSocial);
            this.pnlDatos.Controls.Add(this.label26);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.dtpFecha);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Location = new System.Drawing.Point(4, 4);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(486, 122);
            this.pnlDatos.TabIndex = 1;
            // 
            // btEncargado
            // 
            this.btEncargado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEncargado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btEncargado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btEncargado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEncargado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEncargado.Image = ((System.Drawing.Image)(resources.GetObject("btEncargado.Image")));
            this.btEncargado.Location = new System.Drawing.Point(451, 47);
            this.btEncargado.Name = "btEncargado";
            this.btEncargado.Size = new System.Drawing.Size(23, 18);
            this.btEncargado.TabIndex = 406;
            this.btEncargado.TabStop = false;
            this.btEncargado.UseVisualStyleBackColor = true;
            this.btEncargado.Click += new System.EventHandler(this.btEncargado_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 96);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 405;
            this.label12.Text = "Cuenta";
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodCuenta.BackColor = System.Drawing.Color.White;
            this.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCuenta.Location = new System.Drawing.Point(101, 92);
            this.txtCodCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(64, 20);
            this.txtCodCuenta.TabIndex = 10;
            this.txtCodCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodCuenta.TextoVacio = "<Descripcion>";
            this.txtCodCuenta.TextChanged += new System.EventHandler(this.txtCodCuenta_TextChanged);
            this.txtCodCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCuenta_Validating);
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCuenta.BackColor = System.Drawing.Color.White;
            this.txtDesCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(168, 92);
            this.txtDesCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(306, 20);
            this.txtDesCuenta.TabIndex = 10;
            this.txtDesCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCuenta.TextoVacio = "<Descripcion>";
            this.txtDesCuenta.TextChanged += new System.EventHandler(this.txtDesCuenta_TextChanged);
            this.txtDesCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCuenta_Validating);
            // 
            // cboLibro
            // 
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.DropDownWidth = 250;
            this.cboLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(101, 69);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(172, 21);
            this.cboLibro.TabIndex = 8;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 399;
            this.label9.Text = "Libro";
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.DropDownWidth = 250;
            this.cboFile.Enabled = false;
            this.cboFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(302, 69);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(172, 21);
            this.cboFile.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(276, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 400;
            this.label16.Text = "File";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(286, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 364;
            this.label8.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEstado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEstado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(332, 24);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(142, 20);
            this.txtEstado.TabIndex = 4;
            this.txtEstado.TabStop = false;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEstado.TextoVacio = "";
            // 
            // txtIdLiqui
            // 
            this.txtIdLiqui.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdLiqui.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdLiqui.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdLiqui.Enabled = false;
            this.txtIdLiqui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdLiqui.Location = new System.Drawing.Point(101, 24);
            this.txtIdLiqui.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdLiqui.Name = "txtIdLiqui";
            this.txtIdLiqui.Size = new System.Drawing.Size(56, 20);
            this.txtIdLiqui.TabIndex = 2;
            this.txtIdLiqui.TabStop = false;
            this.txtIdLiqui.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdLiqui.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdLiqui.TextoVacio = "Digite ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 359;
            this.label6.Text = "ID. Liquidación";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.White;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(101, 46);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(81, 20);
            this.txtRuc.TabIndex = 6;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "Digite ID";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(185, 46);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(264, 20);
            this.txtRazonSocial.TabIndex = 7;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Digite Razon Social";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(11, 49);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 13);
            this.label26.TabIndex = 355;
            this.label26.Text = "RUC/Nro. Ident.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 306;
            this.label1.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(201, 24);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldoActual.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoActual.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoActual.Location = new System.Drawing.Point(672, 521);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblSaldoActual.Size = new System.Drawing.Size(84, 22);
            this.lblSaldoActual.TabIndex = 1590;
            this.lblSaldoActual.Text = "0.00";
            this.lblSaldoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(592, 526);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 1589;
            this.label10.Text = "Saldo Actual";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(672, 497);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTotal.Size = new System.Drawing.Size(84, 22);
            this.lblTotal.TabIndex = 1585;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(592, 502);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 1583;
            this.label11.Text = "Total Monto";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.Black;
            this.lblSaldo.Location = new System.Drawing.Point(503, 497);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblSaldo.Size = new System.Drawing.Size(84, 22);
            this.lblSaldo.TabIndex = 1592;
            this.lblSaldo.Text = "0.00";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(460, 502);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 1591;
            this.label13.Text = "Saldo";
            // 
            // pnlTipo
            // 
            this.pnlTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipo.Controls.Add(this.label15);
            this.pnlTipo.Controls.Add(this.dtpPeriodoFin);
            this.pnlTipo.Controls.Add(this.label14);
            this.pnlTipo.Controls.Add(this.dtpPeriodoIni);
            this.pnlTipo.Controls.Add(this.labelDegradado1);
            this.pnlTipo.Location = new System.Drawing.Point(4, 128);
            this.pnlTipo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTipo.Name = "pnlTipo";
            this.pnlTipo.Size = new System.Drawing.Size(754, 47);
            this.pnlTipo.TabIndex = 1593;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(359, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 13);
            this.label15.TabIndex = 310;
            this.label15.Text = "Al";
            // 
            // dtpPeriodoFin
            // 
            this.dtpPeriodoFin.CustomFormat = "dd/MM/yyyy";
            this.dtpPeriodoFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodoFin.Location = new System.Drawing.Point(391, 21);
            this.dtpPeriodoFin.Name = "dtpPeriodoFin";
            this.dtpPeriodoFin.Size = new System.Drawing.Size(218, 20);
            this.dtpPeriodoFin.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(86, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 308;
            this.label14.Text = "Del";
            // 
            // dtpPeriodoIni
            // 
            this.dtpPeriodoIni.CustomFormat = "dd/MM/yyyy";
            this.dtpPeriodoIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodoIni.Location = new System.Drawing.Point(125, 21);
            this.dtpPeriodoIni.Name = "dtpPeriodoIni";
            this.dtpPeriodoIni.Size = new System.Drawing.Size(218, 20);
            this.dtpPeriodoIni.TabIndex = 12;
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
            this.labelDegradado1.Size = new System.Drawing.Size(752, 17);
            this.labelDegradado1.TabIndex = 270;
            this.labelDegradado1.Text = "Periodo";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(5, 185);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(131, 13);
            this.label25.TabIndex = 1596;
            this.label25.Text = "Búsqueda por Documento";
            // 
            // btBuscarTexto
            // 
            this.btBuscarTexto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarTexto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarTexto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarTexto.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarTexto.Location = new System.Drawing.Point(434, 182);
            this.btBuscarTexto.Name = "btBuscarTexto";
            this.btBuscarTexto.Size = new System.Drawing.Size(23, 18);
            this.btBuscarTexto.TabIndex = 1595;
            this.btBuscarTexto.UseVisualStyleBackColor = true;
            this.btBuscarTexto.Click += new System.EventHandler(this.btBuscarTexto_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtBuscar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(140, 181);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.MaxLength = 80;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(292, 20);
            this.txtBuscar.TabIndex = 1594;
            this.txtBuscar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtBuscar.TextoVacio = "Ingrese Texto a Buscar";
            // 
            // frmLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 546);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btBuscarTexto);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pnlTipo);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblSaldoActual);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "frmLiquidacion";
            this.Text = "Liquidación de Fondo Fijo y Rendiciones (Nuevo)";
            this.Load += new System.EventHandler(this.frmLiquidacion_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLiquidacionDet)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlTipo.ResumeLayout(false);
            this.pnlTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.BindingSource bsLiquidacionDet;
        private MyLabelG.LabelDegradado lblDetalle;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private System.Windows.Forms.Label label26;
        private ControlesWinForm.SuperTextBox txtIdLiqui;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtEstado;
        private System.Windows.Forms.Label label8;
        
        private MyLabelG.LabelDegradado lblSaldoActual;
        private System.Windows.Forms.Label label10;
        private MyLabelG.LabelDegradado lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtCodCuenta;
        private ControlesWinForm.SuperTextBox txtDesCuenta;
        private MyLabelG.LabelDegradado lblSaldo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlTipo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpPeriodoFin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpPeriodoIni;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btEncargado;
        private System.Windows.Forms.DataGridView dgvLiq;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoDocumentoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCambioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoLiquidarDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesCCostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btBuscarTexto;
        private ControlesWinForm.SuperTextBox txtBuscar;
    }
}