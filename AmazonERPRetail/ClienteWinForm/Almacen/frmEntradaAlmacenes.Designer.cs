namespace ClienteWinForm.Almacen
{
    partial class frmEntradaAlmacenes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLetras = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoAlmacen = new System.Windows.Forms.ComboBox();
            this.chkAnulados = new System.Windows.Forms.CheckBox();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboconcepto = new System.Windows.Forms.ComboBox();
            this.cboalmacen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRegistrosEntrada = new System.Windows.Forms.DataGridView();
            this.idDocumentoAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCorrelativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numOrdenCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumRequisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmIngresoAlmacen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenerarExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.bsMovimientoAlmacen = new System.Windows.Forms.BindingSource(this.components);
            this.lblregistros = new System.Windows.Forms.Label();
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
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosEntrada)).BeginInit();
            this.ctmIngresoAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientoAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblLetras);
            this.panel2.Controls.Add(this.dtpFin);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpInicio);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 65);
            this.panel2.TabIndex = 274;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(271, 18);
            this.lblLetras.TabIndex = 1580;
            this.lblLetras.Text = "Fechas";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(174, 32);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(82, 21);
            this.dtpFin.TabIndex = 283;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 280;
            this.label5.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 279;
            this.label4.Text = "De";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(43, 32);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(81, 21);
            this.dtpInicio.TabIndex = 282;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cboTipoAlmacen);
            this.panel3.Controls.Add(this.chkAnulados);
            this.panel3.Controls.Add(this.cboTipoMovimiento);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cboconcepto);
            this.panel3.Controls.Add(this.cboalmacen);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(278, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(950, 65);
            this.panel3.TabIndex = 275;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(948, 18);
            this.label2.TabIndex = 1580;
            this.label2.Text = "Buscar por";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 350;
            this.label6.Text = "Tipo de Articulo";
            // 
            // cboTipoAlmacen
            // 
            this.cboTipoAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAlmacen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAlmacen.FormattingEnabled = true;
            this.cboTipoAlmacen.Location = new System.Drawing.Point(86, 33);
            this.cboTipoAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAlmacen.Name = "cboTipoAlmacen";
            this.cboTipoAlmacen.Size = new System.Drawing.Size(156, 21);
            this.cboTipoAlmacen.TabIndex = 349;
            this.cboTipoAlmacen.SelectionChangeCommitted += new System.EventHandler(this.cboTipoAlmacen_SelectionChangeCommitted);
            // 
            // chkAnulados
            // 
            this.chkAnulados.AutoSize = true;
            this.chkAnulados.Location = new System.Drawing.Point(871, 36);
            this.chkAnulados.Name = "chkAnulados";
            this.chkAnulados.Size = new System.Drawing.Size(70, 17);
            this.chkAnulados.TabIndex = 276;
            this.chkAnulados.Text = "Anulados";
            this.chkAnulados.UseVisualStyleBackColor = true;
            this.chkAnulados.CheckedChanged += new System.EventHandler(this.chkAnulados_CheckedChanged);
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimiento.DropDownWidth = 122;
            this.cboTipoMovimiento.Enabled = false;
            this.cboTipoMovimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovimiento.FormattingEnabled = true;
            this.cboTipoMovimiento.Location = new System.Drawing.Point(492, 32);
            this.cboTipoMovimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(101, 21);
            this.cboTipoMovimiento.TabIndex = 345;
            this.cboTipoMovimiento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoMovimiento_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(604, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 343;
            this.label1.Text = "Operación";
            // 
            // cboconcepto
            // 
            this.cboconcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboconcepto.Enabled = false;
            this.cboconcepto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboconcepto.FormattingEnabled = true;
            this.cboconcepto.Location = new System.Drawing.Point(662, 32);
            this.cboconcepto.Name = "cboconcepto";
            this.cboconcepto.Size = new System.Drawing.Size(203, 21);
            this.cboconcepto.TabIndex = 342;
            this.cboconcepto.SelectionChangeCommitted += new System.EventHandler(this.cboconcepto_SelectionChangeCommitted);
            // 
            // cboalmacen
            // 
            this.cboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboalmacen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboalmacen.FormattingEnabled = true;
            this.cboalmacen.Location = new System.Drawing.Point(298, 32);
            this.cboalmacen.Name = "cboalmacen";
            this.cboalmacen.Size = new System.Drawing.Size(192, 21);
            this.cboalmacen.TabIndex = 340;
            this.cboalmacen.SelectionChangeCommitted += new System.EventHandler(this.cboAlmacen_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 278;
            this.label3.Text = "Almacen";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvRegistrosEntrada);
            this.panel1.Controls.Add(this.lblregistros);
            this.panel1.Location = new System.Drawing.Point(3, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 359);
            this.panel1.TabIndex = 272;
            // 
            // dgvRegistrosEntrada
            // 
            this.dgvRegistrosEntrada.AllowUserToAddRows = false;
            this.dgvRegistrosEntrada.AllowUserToDeleteRows = false;
            this.dgvRegistrosEntrada.AutoGenerateColumns = false;
            this.dgvRegistrosEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistrosEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrosEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocumentoAlmacen,
            this.numCorrelativo,
            this.fecProceso,
            this.desOperacion,
            this.Cantidad,
            this.RazonSocial,
            this.numOrdenCompra,
            this.idDocumento,
            this.desMoneda,
            this.NumRequisicion,
            this.Glosa,
            this.UsuarioRegistro,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.indEstado});
            this.dgvRegistrosEntrada.ContextMenuStrip = this.ctmIngresoAlmacen;
            this.dgvRegistrosEntrada.DataSource = this.bsMovimientoAlmacen;
            this.dgvRegistrosEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistrosEntrada.EnableHeadersVisualStyles = false;
            this.dgvRegistrosEntrada.Location = new System.Drawing.Point(0, 18);
            this.dgvRegistrosEntrada.Name = "dgvRegistrosEntrada";
            this.dgvRegistrosEntrada.ReadOnly = true;
            this.dgvRegistrosEntrada.Size = new System.Drawing.Size(1223, 339);
            this.dgvRegistrosEntrada.TabIndex = 1;
            this.dgvRegistrosEntrada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistrosEntrada_CellDoubleClick);
            this.dgvRegistrosEntrada.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRegistrosEntrada_CellFormatting);
            this.dgvRegistrosEntrada.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegistrosEntrada_ColumnHeaderMouseClick);
            // 
            // idDocumentoAlmacen
            // 
            this.idDocumentoAlmacen.DataPropertyName = "idDocumentoAlmacen";
            this.idDocumentoAlmacen.Frozen = true;
            this.idDocumentoAlmacen.HeaderText = "ID.";
            this.idDocumentoAlmacen.Name = "idDocumentoAlmacen";
            this.idDocumentoAlmacen.ReadOnly = true;
            this.idDocumentoAlmacen.Visible = false;
            this.idDocumentoAlmacen.Width = 40;
            // 
            // numCorrelativo
            // 
            this.numCorrelativo.DataPropertyName = "Correlativo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numCorrelativo.DefaultCellStyle = dataGridViewCellStyle1;
            this.numCorrelativo.Frozen = true;
            this.numCorrelativo.HeaderText = "Número";
            this.numCorrelativo.Name = "numCorrelativo";
            this.numCorrelativo.ReadOnly = true;
            this.numCorrelativo.Width = 90;
            // 
            // fecProceso
            // 
            this.fecProceso.DataPropertyName = "fecProceso";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fecProceso.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecProceso.Frozen = true;
            this.fecProceso.HeaderText = "Fec.Proc.";
            this.fecProceso.Name = "fecProceso";
            this.fecProceso.ReadOnly = true;
            this.fecProceso.Width = 72;
            // 
            // desOperacion
            // 
            this.desOperacion.DataPropertyName = "desOperacion";
            this.desOperacion.Frozen = true;
            this.desOperacion.HeaderText = "Operación";
            this.desOperacion.Name = "desOperacion";
            this.desOperacion.ReadOnly = true;
            this.desOperacion.Width = 160;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 70;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.Frozen = true;
            this.RazonSocial.HeaderText = "Proveedor";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 140;
            // 
            // numOrdenCompra
            // 
            this.numOrdenCompra.DataPropertyName = "numOrdenCompra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numOrdenCompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.numOrdenCompra.HeaderText = "No.O.Compra";
            this.numOrdenCompra.Name = "numOrdenCompra";
            this.numOrdenCompra.ReadOnly = true;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "TD";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 30;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            this.desMoneda.HeaderText = "Moneda";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 90;
            // 
            // NumRequisicion
            // 
            this.NumRequisicion.DataPropertyName = "NumRequisicion";
            this.NumRequisicion.HeaderText = "Nº Requisicion";
            this.NumRequisicion.Name = "NumRequisicion";
            this.NumRequisicion.ReadOnly = true;
            this.NumRequisicion.Width = 120;
            // 
            // Glosa
            // 
            this.Glosa.DataPropertyName = "Glosa";
            this.Glosa.HeaderText = "Glosa";
            this.Glosa.Name = "Glosa";
            this.Glosa.ReadOnly = true;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            this.UsuarioRegistro.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle5.Format = "d";
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Format = "d";
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // indEstado
            // 
            this.indEstado.DataPropertyName = "indEstado";
            this.indEstado.HeaderText = "indEstado";
            this.indEstado.Name = "indEstado";
            this.indEstado.ReadOnly = true;
            this.indEstado.Visible = false;
            // 
            // ctmIngresoAlmacen
            // 
            this.ctmIngresoAlmacen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ctmIngresoAlmacen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerar,
            this.tsmiGenerarExcel});
            this.ctmIngresoAlmacen.Name = "contextMenuStrip1";
            this.ctmIngresoAlmacen.Size = new System.Drawing.Size(235, 48);
            // 
            // tsmiGenerar
            // 
            this.tsmiGenerar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsmiGenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsmiGenerar.Image = global::ClienteWinForm.Properties.Resources.Regenerar;
            this.tsmiGenerar.Name = "tsmiGenerar";
            this.tsmiGenerar.Size = new System.Drawing.Size(234, 22);
            this.tsmiGenerar.Text = "Generar Hoja de Costos";
            this.tsmiGenerar.Click += new System.EventHandler(this.tsmiGenerar_Click);
            // 
            // tsmiGenerarExcel
            // 
            this.tsmiGenerarExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiGenerarExcel.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.tsmiGenerarExcel.Name = "tsmiGenerarExcel";
            this.tsmiGenerarExcel.Size = new System.Drawing.Size(234, 22);
            this.tsmiGenerarExcel.Text = "Exportar a Excel Detalle Lote";
            this.tsmiGenerarExcel.Click += new System.EventHandler(this.tsmiGenerarExcel_Click);
            // 
            // bsMovimientoAlmacen
            // 
            this.bsMovimientoAlmacen.DataSource = typeof(Entidades.Almacen.OperacionE);
            this.bsMovimientoAlmacen.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsMovimientoAlmacen_ListChanged);
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(1223, 18);
            this.lblregistros.TabIndex = 1580;
            this.lblregistros.Text = "Registros 0";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desOperacion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "desAlmacen";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "Almacen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RazonSocial";
            this.dataGridViewTextBoxColumn3.HeaderText = "Razon Social";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "desMoneda";
            this.dataGridViewTextBoxColumn4.HeaderText = "Moneda";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumRequisicion";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nº Requisicion";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NumeroGuiaRemision";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nº Guia Remision";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "idOrdenCompra";
            this.dataGridViewTextBoxColumn7.HeaderText = "idOrdenCompra";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 30;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn8.HeaderText = "Usuario Reg.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NumRequisicion";
            this.dataGridViewTextBoxColumn9.HeaderText = "Nº Requisicion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Guia";
            this.dataGridViewTextBoxColumn10.HeaderText = "Nº Guia Remision";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "idOrdenCompra";
            this.dataGridViewTextBoxColumn11.HeaderText = "idOrdenCompra";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn12.HeaderText = "Usuario Reg.";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // frmEntradaAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1234, 432);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmEntradaAlmacenes";
            this.Text = "Entrada a Almacén    ";
            this.Load += new System.EventHandler(this.frmEntradaAlmacenes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosEntrada)).EndInit();
            this.ctmIngresoAlmacen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimientoAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRegistrosEntrada;
        private System.Windows.Forms.BindingSource bsMovimientoAlmacen;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        public System.Windows.Forms.ComboBox cboalmacen;
        public System.Windows.Forms.ComboBox cboconcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.CheckBox chkAnulados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.ContextMenuStrip ctmIngresoAlmacen;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCorrelativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn desOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn numOrdenCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocumentoReferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumRequisicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Glosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioAnulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAnulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indEstado;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenerarExcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoAlmacen;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblregistros;
    }
}