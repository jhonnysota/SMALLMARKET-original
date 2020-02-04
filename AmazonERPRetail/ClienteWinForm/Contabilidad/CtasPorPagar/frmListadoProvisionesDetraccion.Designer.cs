namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmListadoProvisionesDetraccion
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
            System.Windows.Forms.Label numDiasVenLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle77 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle91 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle92 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle93 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle94 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle95 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle96 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle97 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle98 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle99 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle100 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtOp = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProvisionDetra = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codOrdenPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCuentaDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalSecun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impTotalBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasaDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDetraccionSoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Redondeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOrdenPago = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEliminarOp = new System.Windows.Forms.ToolStripMenuItem();
            this.bsProvisiones = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGenerarTXT = new System.Windows.Forms.Button();
            this.txtCorrelativo = new ControlesWinForm.SuperTextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btGenerarOP = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpFecOp = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            numDiasVenLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvisionDetra)).BeginInit();
            this.cmsOrdenPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisiones)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // numDiasVenLabel
            // 
            numDiasVenLabel.AutoSize = true;
            numDiasVenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numDiasVenLabel.Location = new System.Drawing.Point(8, 43);
            numDiasVenLabel.Name = "numDiasVenLabel";
            numDiasVenLabel.Size = new System.Drawing.Size(57, 13);
            numDiasVenLabel.TabIndex = 260;
            numDiasVenLabel.Text = "Correlativo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(8, 43);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 13);
            label2.TabIndex = 260;
            label2.Text = "Fecha de O.P.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(259, 43);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(28, 13);
            label3.TabIndex = 366;
            label3.Text = "O.P.";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtOp);
            this.panel2.Controls.Add(label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(this.dtpFecFin);
            this.panel2.Controls.Add(this.dtpFecIni);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 81);
            this.panel2.TabIndex = 363;
            // 
            // txtOp
            // 
            this.txtOp.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtOp.BackColor = System.Drawing.SystemColors.Window;
            this.txtOp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOp.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOp.Location = new System.Drawing.Point(293, 39);
            this.txtOp.Margin = new System.Windows.Forms.Padding(2);
            this.txtOp.MaxLength = 4;
            this.txtOp.Name = "txtOp";
            this.txtOp.Size = new System.Drawing.Size(113, 20);
            this.txtOp.TabIndex = 365;
            this.txtOp.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtOp.TextoVacio = "<Descripcion>";
            this.txtOp.TextChanged += new System.EventHandler(this.txtOp_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 362;
            this.label1.Text = "Del";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(135, 43);
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
            this.labelDegradado2.Size = new System.Drawing.Size(420, 18);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Opciones";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(154, 39);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(94, 20);
            this.dtpFecFin.TabIndex = 359;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(38, 39);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(94, 20);
            this.dtpFecIni.TabIndex = 358;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvProvisionDetra);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(3, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 305);
            this.panel1.TabIndex = 77;
            // 
            // dgvProvisionDetra
            // 
            this.dgvProvisionDetra.AllowUserToAddRows = false;
            this.dgvProvisionDetra.AllowUserToDeleteRows = false;
            this.dgvProvisionDetra.AutoGenerateColumns = false;
            this.dgvProvisionDetra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProvisionDetra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvisionDetra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.codOrdenPago,
            this.NombreArchivo,
            this.rucDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.numCuentaDetraccion,
            this.fechaDocumentoDataGridViewTextBoxColumn,
            this.idDocumento,
            this.NumSerie,
            this.NumDocumento,
            this.desMoneda,
            this.TipCambio,
            this.impTotalSecun,
            this.impTotalBase,
            this.TipoDetraccion,
            this.TipoOperacion,
            this.TasaDetraccion,
            this.MontoDetraccionSoles,
            this.Redondeo,
            this.retNumero,
            this.retFecha,
            this.CodPartidaPresu,
            this.desPartidaPresu});
            this.dgvProvisionDetra.ContextMenuStrip = this.cmsOrdenPago;
            this.dgvProvisionDetra.DataSource = this.bsProvisiones;
            this.dgvProvisionDetra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProvisionDetra.EnableHeadersVisualStyles = false;
            this.dgvProvisionDetra.Location = new System.Drawing.Point(0, 18);
            this.dgvProvisionDetra.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProvisionDetra.Name = "dgvProvisionDetra";
            this.dgvProvisionDetra.RowTemplate.Height = 24;
            this.dgvProvisionDetra.Size = new System.Drawing.Size(1228, 285);
            this.dgvProvisionDetra.TabIndex = 80;
            this.dgvProvisionDetra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProvisionDetra_CellDoubleClick);
            this.dgvProvisionDetra.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProvisionDetra_CellPainting);
            this.dgvProvisionDetra.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProvisionDetra_CellValueChanged);
            this.dgvProvisionDetra.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvProvisionDetra_CurrentCellDirtyStateChanged);
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.Frozen = true;
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.Width = 30;
            // 
            // codOrdenPago
            // 
            this.codOrdenPago.DataPropertyName = "codOrdenPago";
            this.codOrdenPago.Frozen = true;
            this.codOrdenPago.HeaderText = "O.P.";
            this.codOrdenPago.Name = "codOrdenPago";
            this.codOrdenPago.Width = 80;
            // 
            // NombreArchivo
            // 
            this.NombreArchivo.DataPropertyName = "NombreArchivo";
            this.NombreArchivo.Frozen = true;
            this.NombreArchivo.HeaderText = "Archivo";
            this.NombreArchivo.Name = "NombreArchivo";
            this.NombreArchivo.Width = 120;
            // 
            // rucDataGridViewTextBoxColumn
            // 
            this.rucDataGridViewTextBoxColumn.DataPropertyName = "Ruc";
            this.rucDataGridViewTextBoxColumn.Frozen = true;
            this.rucDataGridViewTextBoxColumn.HeaderText = "RUC";
            this.rucDataGridViewTextBoxColumn.Name = "rucDataGridViewTextBoxColumn";
            this.rucDataGridViewTextBoxColumn.ReadOnly = true;
            this.rucDataGridViewTextBoxColumn.Width = 80;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Frozen = true;
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // numCuentaDetraccion
            // 
            this.numCuentaDetraccion.DataPropertyName = "numCuentaDetraccion";
            this.numCuentaDetraccion.Frozen = true;
            this.numCuentaDetraccion.HeaderText = "Cuenta Detraccion";
            this.numCuentaDetraccion.Name = "numCuentaDetraccion";
            this.numCuentaDetraccion.ReadOnly = true;
            // 
            // fechaDocumentoDataGridViewTextBoxColumn
            // 
            this.fechaDocumentoDataGridViewTextBoxColumn.DataPropertyName = "FechaDocumento";
            dataGridViewCellStyle76.Format = "d";
            dataGridViewCellStyle76.NullValue = null;
            this.fechaDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle76;
            this.fechaDocumentoDataGridViewTextBoxColumn.Frozen = true;
            this.fechaDocumentoDataGridViewTextBoxColumn.HeaderText = "Fecha Emision";
            this.fechaDocumentoDataGridViewTextBoxColumn.Name = "fechaDocumentoDataGridViewTextBoxColumn";
            this.fechaDocumentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.Frozen = true;
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 40;
            // 
            // NumSerie
            // 
            this.NumSerie.DataPropertyName = "NumSerie";
            this.NumSerie.Frozen = true;
            this.NumSerie.HeaderText = "Serie";
            this.NumSerie.Name = "NumSerie";
            this.NumSerie.ReadOnly = true;
            this.NumSerie.Width = 40;
            // 
            // NumDocumento
            // 
            this.NumDocumento.DataPropertyName = "NumDocumento";
            this.NumDocumento.Frozen = true;
            this.NumDocumento.HeaderText = "N°";
            this.NumDocumento.Name = "NumDocumento";
            this.NumDocumento.ReadOnly = true;
            this.NumDocumento.Width = 60;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle77;
            this.desMoneda.Frozen = true;
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 30;
            // 
            // TipCambio
            // 
            this.TipCambio.DataPropertyName = "TipCambio";
            dataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TipCambio.DefaultCellStyle = dataGridViewCellStyle78;
            this.TipCambio.Frozen = true;
            this.TipCambio.HeaderText = "T.C.";
            this.TipCambio.Name = "TipCambio";
            this.TipCambio.Width = 50;
            // 
            // impTotalSecun
            // 
            this.impTotalSecun.DataPropertyName = "impTotalSecun";
            dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle79.Format = "N2";
            dataGridViewCellStyle79.NullValue = null;
            this.impTotalSecun.DefaultCellStyle = dataGridViewCellStyle79;
            this.impTotalSecun.Frozen = true;
            this.impTotalSecun.HeaderText = "Importe US$";
            this.impTotalSecun.Name = "impTotalSecun";
            this.impTotalSecun.Width = 80;
            // 
            // impTotalBase
            // 
            this.impTotalBase.DataPropertyName = "impTotalBase";
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle80.Format = "N2";
            dataGridViewCellStyle80.NullValue = null;
            this.impTotalBase.DefaultCellStyle = dataGridViewCellStyle80;
            this.impTotalBase.Frozen = true;
            this.impTotalBase.HeaderText = "Importe S/";
            this.impTotalBase.Name = "impTotalBase";
            this.impTotalBase.Width = 80;
            // 
            // TipoDetraccion
            // 
            this.TipoDetraccion.DataPropertyName = "TipoDetraccion";
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TipoDetraccion.DefaultCellStyle = dataGridViewCellStyle81;
            this.TipoDetraccion.HeaderText = "Cód.Bien";
            this.TipoDetraccion.Name = "TipoDetraccion";
            this.TipoDetraccion.Width = 30;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.DataPropertyName = "TipoOperacion";
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TipoOperacion.DefaultCellStyle = dataGridViewCellStyle82;
            this.TipoOperacion.HeaderText = "Cód. Tipo Ope.";
            this.TipoOperacion.Name = "TipoOperacion";
            this.TipoOperacion.Width = 30;
            // 
            // TasaDetraccion
            // 
            this.TasaDetraccion.DataPropertyName = "TasaDetraccion";
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TasaDetraccion.DefaultCellStyle = dataGridViewCellStyle83;
            this.TasaDetraccion.HeaderText = "%";
            this.TasaDetraccion.Name = "TasaDetraccion";
            this.TasaDetraccion.Width = 40;
            // 
            // MontoDetraccionSoles
            // 
            this.MontoDetraccionSoles.DataPropertyName = "MontoDetraccionSoles";
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle84.Format = "N2";
            dataGridViewCellStyle84.NullValue = null;
            this.MontoDetraccionSoles.DefaultCellStyle = dataGridViewCellStyle84;
            this.MontoDetraccionSoles.HeaderText = "Monto Detra. S/";
            this.MontoDetraccionSoles.Name = "MontoDetraccionSoles";
            this.MontoDetraccionSoles.Width = 80;
            // 
            // Redondeo
            // 
            this.Redondeo.DataPropertyName = "Redondeo";
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle85.Format = "N2";
            dataGridViewCellStyle85.NullValue = null;
            this.Redondeo.DefaultCellStyle = dataGridViewCellStyle85;
            this.Redondeo.HeaderText = "Redondeo";
            this.Redondeo.Name = "Redondeo";
            this.Redondeo.Width = 70;
            // 
            // retNumero
            // 
            this.retNumero.DataPropertyName = "retNumero";
            this.retNumero.HeaderText = "N° Constan. Det.";
            this.retNumero.Name = "retNumero";
            this.retNumero.ReadOnly = true;
            this.retNumero.Width = 75;
            // 
            // retFecha
            // 
            this.retFecha.DataPropertyName = "retFecha";
            dataGridViewCellStyle86.Format = "d";
            dataGridViewCellStyle86.NullValue = null;
            this.retFecha.DefaultCellStyle = dataGridViewCellStyle86;
            this.retFecha.HeaderText = "Fec.Núm.Constan.Det.";
            this.retFecha.Name = "retFecha";
            this.retFecha.ReadOnly = true;
            this.retFecha.Width = 80;
            // 
            // CodPartidaPresu
            // 
            this.CodPartidaPresu.DataPropertyName = "CodPartidaPresu";
            this.CodPartidaPresu.HeaderText = "Cód.P.P.";
            this.CodPartidaPresu.Name = "CodPartidaPresu";
            this.CodPartidaPresu.ToolTipText = "Código de Partida Presupuestal";
            this.CodPartidaPresu.Width = 80;
            // 
            // desPartidaPresu
            // 
            this.desPartidaPresu.DataPropertyName = "desPartidaPresu";
            this.desPartidaPresu.HeaderText = "Des.P.P.";
            this.desPartidaPresu.Name = "desPartidaPresu";
            this.desPartidaPresu.ToolTipText = "Descripción de Partida Presupuestal";
            this.desPartidaPresu.Width = 150;
            // 
            // cmsOrdenPago
            // 
            this.cmsOrdenPago.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEliminarOp});
            this.cmsOrdenPago.Name = "cmsOrdenPago";
            this.cmsOrdenPago.Size = new System.Drawing.Size(143, 26);
            // 
            // tsmiEliminarOp
            // 
            this.tsmiEliminarOp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsmiEliminarOp.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmiEliminarOp.Name = "tsmiEliminarOp";
            this.tsmiEliminarOp.Size = new System.Drawing.Size(142, 22);
            this.tsmiEliminarOp.Text = "Eliminar O.P.";
            this.tsmiEliminarOp.Click += new System.EventHandler(this.tsmiEliminarOp_Click);
            // 
            // bsProvisiones
            // 
            this.bsProvisiones.DataSource = typeof(Entidades.CtasPorPagar.ProvisionesE);
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
            this.lblTitulo.Size = new System.Drawing.Size(1228, 18);
            this.lblTitulo.TabIndex = 270;
            this.lblTitulo.Text = "Registros 0";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnGenerarTXT);
            this.panel3.Controls.Add(this.txtCorrelativo);
            this.panel3.Controls.Add(numDiasVenLabel);
            this.panel3.Controls.Add(this.labelDegradado1);
            this.panel3.Location = new System.Drawing.Point(706, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 81);
            this.panel3.TabIndex = 364;
            // 
            // btnGenerarTXT
            // 
            this.btnGenerarTXT.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenerarTXT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnGenerarTXT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnGenerarTXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarTXT.Image = global::ClienteWinForm.Properties.Resources.Generar;
            this.btnGenerarTXT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarTXT.Location = new System.Drawing.Point(128, 24);
            this.btnGenerarTXT.Name = "btnGenerarTXT";
            this.btnGenerarTXT.Size = new System.Drawing.Size(118, 49);
            this.btnGenerarTXT.TabIndex = 261;
            this.btnGenerarTXT.Text = "Generar TXT";
            this.btnGenerarTXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarTXT.UseVisualStyleBackColor = true;
            this.btnGenerarTXT.Click += new System.EventHandler(this.btnGenerarTXT_Click);
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCorrelativo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCorrelativo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorrelativo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCorrelativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrelativo.Location = new System.Drawing.Point(70, 39);
            this.txtCorrelativo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorrelativo.MaxLength = 4;
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(36, 20);
            this.txtCorrelativo.TabIndex = 259;
            this.txtCorrelativo.Text = "0";
            this.txtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCorrelativo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCorrelativo.TextoVacio = "<Descripcion>";
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
            this.labelDegradado1.Size = new System.Drawing.Size(274, 18);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parametros Tabla Detraccion";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btGenerarOP
            // 
            this.btGenerarOP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btGenerarOP.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btGenerarOP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btGenerarOP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btGenerarOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenerarOP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerarOP.Image = global::ClienteWinForm.Properties.Resources.Generar;
            this.btGenerarOP.Location = new System.Drawing.Point(197, 24);
            this.btGenerarOP.Margin = new System.Windows.Forms.Padding(2);
            this.btGenerarOP.Name = "btGenerarOP";
            this.btGenerarOP.Size = new System.Drawing.Size(67, 49);
            this.btGenerarOP.TabIndex = 365;
            this.btGenerarOP.TabStop = false;
            this.btGenerarOP.UseVisualStyleBackColor = false;
            this.btGenerarOP.Click += new System.EventHandler(this.btGenerarOP_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idDocumento";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo De Comprobante";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NumSerie";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Serie Del Comprobante";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NumDocumento";
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "N° del Comprobante";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "desMoneda";
            dataGridViewCellStyle87.Format = "d";
            dataGridViewCellStyle87.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle87;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Moneda";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TipCambio";
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle88;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "T.C.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "impTotalSecun";
            dataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle89.Format = "N2";
            dataGridViewCellStyle89.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle89;
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Importe Dolares";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "impTotalBase";
            dataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle90.Format = "N2";
            dataGridViewCellStyle90.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle90;
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "Importe Soles";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TipoDetraccion";
            dataGridViewCellStyle91.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle91.Format = "N2";
            dataGridViewCellStyle91.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle91;
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "Codigo de Bien o Servicio";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TipoOperacion";
            dataGridViewCellStyle92.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle92;
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "Codigo de Tipo Operacion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 30;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TasaDetraccion";
            dataGridViewCellStyle93.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle93;
            this.dataGridViewTextBoxColumn10.Frozen = true;
            this.dataGridViewTextBoxColumn10.HeaderText = "%";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 30;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MontoDetraccion";
            dataGridViewCellStyle94.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle94.Format = "N2";
            dataGridViewCellStyle94.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle94;
            this.dataGridViewTextBoxColumn11.Frozen = true;
            this.dataGridViewTextBoxColumn11.HeaderText = "Importe Detraccion";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 40;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Redondeo";
            dataGridViewCellStyle95.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle95.Format = "N2";
            dataGridViewCellStyle95.NullValue = null;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle95;
            this.dataGridViewTextBoxColumn12.HeaderText = "Redondeo";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 70;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "retNumero";
            dataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle96.Format = "N2";
            dataGridViewCellStyle96.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle96;
            this.dataGridViewTextBoxColumn13.HeaderText = "Numero Constancia Ret.";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 75;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "retFecha";
            dataGridViewCellStyle97.Format = "d";
            dataGridViewCellStyle97.NullValue = null;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle97;
            this.dataGridViewTextBoxColumn14.HeaderText = "Fecha Numero Constancia Ret.";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 150;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "retFecha";
            dataGridViewCellStyle98.Format = "d";
            dataGridViewCellStyle98.NullValue = null;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle98;
            this.dataGridViewTextBoxColumn15.HeaderText = "Fecha Numero Constancia Ret.";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 80;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Redondeo";
            dataGridViewCellStyle99.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle99.Format = "N2";
            dataGridViewCellStyle99.NullValue = null;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle99;
            this.dataGridViewTextBoxColumn16.HeaderText = "Redondeo";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 70;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "retNumero";
            this.dataGridViewTextBoxColumn17.HeaderText = "Numero Constancia Ret.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 75;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "retFecha";
            dataGridViewCellStyle100.Format = "d";
            dataGridViewCellStyle100.NullValue = null;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle100;
            this.dataGridViewTextBoxColumn18.HeaderText = "Fecha Numero Constancia Ret.";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btGenerarOP);
            this.panel4.Controls.Add(this.dtpFecOp);
            this.panel4.Controls.Add(label2);
            this.panel4.Controls.Add(this.labelDegradado3);
            this.panel4.Location = new System.Drawing.Point(428, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 81);
            this.panel4.TabIndex = 366;
            // 
            // dtpFecOp
            // 
            this.dtpFecOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecOp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecOp.Location = new System.Drawing.Point(95, 39);
            this.dtpFecOp.Name = "dtpFecOp";
            this.dtpFecOp.Size = new System.Drawing.Size(94, 20);
            this.dtpFecOp.TabIndex = 367;
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
            this.labelDegradado3.Size = new System.Drawing.Size(274, 18);
            this.labelDegradado3.TabIndex = 258;
            this.labelDegradado3.Text = "Generar Orden de Pago";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoProvisionesDetraccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 394);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.Name = "frmListadoProvisionesDetraccion";
            this.Text = "Declaración de Detracciones";
            this.Load += new System.EventHandler(this.frmListadoProvisionesDetraccion_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvisionDetra)).EndInit();
            this.cmsOrdenPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisiones)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProvisionDetra;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.BindingSource bsProvisiones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.Panel panel3;
        private MyLabelG.LabelDegradado labelDegradado1;
        private ControlesWinForm.SuperTextBox txtCorrelativo;
        private System.Windows.Forms.Button btnGenerarTXT;
        private System.Windows.Forms.Button btGenerarOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.Panel panel4;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.DateTimePicker dtpFecOp;
        private System.Windows.Forms.ContextMenuStrip cmsOrdenPago;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarOp;
        private ControlesWinForm.SuperTextBox txtOp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn codOrdenPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCuentaDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalSecun;
        private System.Windows.Forms.DataGridViewTextBoxColumn impTotalBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TasaDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDetraccionSoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Redondeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn retNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn retFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPartidaPresu;
    }
}