namespace ClienteWinForm.Tesoreria
{
    partial class frmFormaPago
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
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label codArticuloLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsFormaTipoPago = new System.Windows.Forms.BindingSource(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvFormaTipoPago = new System.Windows.Forms.DataGridView();
            this.codTipoPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDegradado12 = new MyLabelG.LabelDegradado();
            this.txtTotalSolSeg = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.chkDatosAuxiliares = new System.Windows.Forms.CheckBox();
            this.txtCodigo = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboIndicador = new System.Windows.Forms.ComboBox();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.txtDesFormaPago = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.txtNomCorto = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            codArticuloLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsFormaTipoPago)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormaTipoPago)).BeginInit();
            this.txtTotalSolSeg.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 97);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 75);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(106, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 31);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 53);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(250, 74);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(37, 13);
            label13.TabIndex = 376;
            label13.Text = "Monto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(18, 52);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 253;
            label1.Text = "Descripción";
            // 
            // codArticuloLabel
            // 
            codArticuloLabel.AutoSize = true;
            codArticuloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codArticuloLabel.Location = new System.Drawing.Point(18, 75);
            codArticuloLabel.Name = "codArticuloLabel";
            codArticuloLabel.Size = new System.Drawing.Size(96, 13);
            codArticuloLabel.TabIndex = 333;
            codArticuloLabel.Text = "Nom.Corto/Nemot.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(18, 31);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(40, 13);
            label3.TabIndex = 380;
            label3.Text = "Código";
            // 
            // bsFormaTipoPago
            // 
            this.bsFormaTipoPago.DataSource = typeof(Entidades.Tesoreria.FormaTipoPagoE);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dgvFormaTipoPago);
            this.panel7.Controls.Add(this.labelDegradado12);
            this.panel7.Location = new System.Drawing.Point(4, 158);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(717, 171);
            this.panel7.TabIndex = 386;
            // 
            // dgvFormaTipoPago
            // 
            this.dgvFormaTipoPago.AllowUserToAddRows = false;
            this.dgvFormaTipoPago.AllowUserToDeleteRows = false;
            this.dgvFormaTipoPago.AutoGenerateColumns = false;
            this.dgvFormaTipoPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFormaTipoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormaTipoPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codTipoPagoDataGridViewTextBoxColumn,
            this.desTipoPago,
            this.desConcepto,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvFormaTipoPago.DataSource = this.bsFormaTipoPago;
            this.dgvFormaTipoPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFormaTipoPago.EnableHeadersVisualStyles = false;
            this.dgvFormaTipoPago.Location = new System.Drawing.Point(0, 20);
            this.dgvFormaTipoPago.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFormaTipoPago.Name = "dgvFormaTipoPago";
            this.dgvFormaTipoPago.ReadOnly = true;
            this.dgvFormaTipoPago.RowTemplate.Height = 24;
            this.dgvFormaTipoPago.Size = new System.Drawing.Size(715, 149);
            this.dgvFormaTipoPago.TabIndex = 98;
            this.dgvFormaTipoPago.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormaTipoPago_CellDoubleClick);
            this.dgvFormaTipoPago.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvFormaTipoPago_RowPostPaint);
            // 
            // codTipoPagoDataGridViewTextBoxColumn
            // 
            this.codTipoPagoDataGridViewTextBoxColumn.DataPropertyName = "codTipoPago";
            this.codTipoPagoDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.codTipoPagoDataGridViewTextBoxColumn.Name = "codTipoPagoDataGridViewTextBoxColumn";
            this.codTipoPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codTipoPagoDataGridViewTextBoxColumn.Width = 60;
            // 
            // desTipoPago
            // 
            this.desTipoPago.DataPropertyName = "desTipoPago";
            this.desTipoPago.HeaderText = "Descripción";
            this.desTipoPago.Name = "desTipoPago";
            this.desTipoPago.ReadOnly = true;
            this.desTipoPago.Width = 200;
            // 
            // desConcepto
            // 
            this.desConcepto.DataPropertyName = "desConcepto";
            this.desConcepto.HeaderText = "Concepto";
            this.desConcepto.Name = "desConcepto";
            this.desConcepto.ReadOnly = true;
            this.desConcepto.Width = 200;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // labelDegradado12
            // 
            this.labelDegradado12.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado12.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado12.ForeColor = System.Drawing.Color.White;
            this.labelDegradado12.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado12.Name = "labelDegradado12";
            this.labelDegradado12.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado12.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado12.Size = new System.Drawing.Size(715, 20);
            this.labelDegradado12.TabIndex = 272;
            this.labelDegradado12.Text = "Item Tipo Pago";
            this.labelDegradado12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalSolSeg
            // 
            this.txtTotalSolSeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSolSeg.Controls.Add(this.labelDegradado2);
            this.txtTotalSolSeg.Controls.Add(fechaModificacionLabel);
            this.txtTotalSolSeg.Controls.Add(this.txtFechaModificacion);
            this.txtTotalSolSeg.Controls.Add(this.txtUsuarioRegistro);
            this.txtTotalSolSeg.Controls.Add(usuarioModificacionLabel);
            this.txtTotalSolSeg.Controls.Add(usuarioRegistroLabel);
            this.txtTotalSolSeg.Controls.Add(this.txtUsuarioModificacion);
            this.txtTotalSolSeg.Controls.Add(this.txtFechaRegistro);
            this.txtTotalSolSeg.Controls.Add(fechaRegistroLabel);
            this.txtTotalSolSeg.Location = new System.Drawing.Point(469, 4);
            this.txtTotalSolSeg.Name = "txtTotalSolSeg";
            this.txtTotalSolSeg.Size = new System.Drawing.Size(252, 133);
            this.txtTotalSolSeg.TabIndex = 384;
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
            this.labelDegradado2.Size = new System.Drawing.Size(250, 21);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Auditoria";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(115, 93);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(128, 20);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(115, 27);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(128, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(115, 71);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(128, 20);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(115, 49);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(128, 20);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.cboMedioPago);
            this.pnlDetalle.Controls.Add(this.chkDatosAuxiliares);
            this.pnlDetalle.Controls.Add(label3);
            this.pnlDetalle.Controls.Add(this.txtCodigo);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.cboIndicador);
            this.pnlDetalle.Controls.Add(label13);
            this.pnlDetalle.Controls.Add(this.txtMonto);
            this.pnlDetalle.Controls.Add(label1);
            this.pnlDetalle.Controls.Add(codArticuloLabel);
            this.pnlDetalle.Controls.Add(this.txtDesFormaPago);
            this.pnlDetalle.Controls.Add(this.labelDegradado1);
            this.pnlDetalle.Controls.Add(this.txtNomCorto);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(463, 148);
            this.pnlDetalle.TabIndex = 385;
            // 
            // chkDatosAuxiliares
            // 
            this.chkDatosAuxiliares.AutoSize = true;
            this.chkDatosAuxiliares.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDatosAuxiliares.Location = new System.Drawing.Point(249, 97);
            this.chkDatosAuxiliares.Name = "chkDatosAuxiliares";
            this.chkDatosAuxiliares.Size = new System.Drawing.Size(138, 17);
            this.chkDatosAuxiliares.TabIndex = 381;
            this.chkDatosAuxiliares.Text = "Solicita Datos Auxiliares";
            this.chkDatosAuxiliares.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodigo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(116, 27);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(69, 20);
            this.txtCodigo.TabIndex = 379;
            this.txtCodigo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodigo.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 378;
            this.label2.Text = "Indicador E/I";
            // 
            // cboIndicador
            // 
            this.cboIndicador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIndicador.FormattingEnabled = true;
            this.cboIndicador.Location = new System.Drawing.Point(116, 94);
            this.cboIndicador.Name = "cboIndicador";
            this.cboIndicador.Size = new System.Drawing.Size(127, 21);
            this.cboIndicador.TabIndex = 377;
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(293, 71);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(65, 20);
            this.txtMonto.TabIndex = 375;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtDesFormaPago
            // 
            this.txtDesFormaPago.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDesFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesFormaPago.Location = new System.Drawing.Point(116, 49);
            this.txtDesFormaPago.Name = "txtDesFormaPago";
            this.txtDesFormaPago.Size = new System.Drawing.Size(330, 20);
            this.txtDesFormaPago.TabIndex = 104;
            this.txtDesFormaPago.TabStop = false;
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
            this.labelDegradado1.Size = new System.Drawing.Size(461, 21);
            this.labelDegradado1.TabIndex = 252;
            this.labelDegradado1.Text = "Datos Principales";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomCorto
            // 
            this.txtNomCorto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNomCorto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNomCorto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNomCorto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomCorto.Location = new System.Drawing.Point(116, 71);
            this.txtNomCorto.MaxLength = 4;
            this.txtNomCorto.Name = "txtNomCorto";
            this.txtNomCorto.Size = new System.Drawing.Size(127, 20);
            this.txtNomCorto.TabIndex = 105;
            this.txtNomCorto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNomCorto.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 402;
            this.label9.Text = "Medio Pago";
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedioPago.DropDownWidth = 280;
            this.cboMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedioPago.FormattingEnabled = true;
            this.cboMedioPago.Location = new System.Drawing.Point(116, 116);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(271, 21);
            this.cboMedioPago.TabIndex = 403;
            // 
            // frmFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 330);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.txtTotalSolSeg);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmFormaPago";
            this.Text = "Forma Pago (Nuevo)";
            this.Load += new System.EventHandler(this.frmFormaPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsFormaTipoPago)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormaTipoPago)).EndInit();
            this.txtTotalSolSeg.ResumeLayout(false);
            this.txtTotalSolSeg.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvFormaTipoPago;
        private MyLabelG.LabelDegradado labelDegradado12;
        private System.Windows.Forms.Panel txtTotalSolSeg;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.TextBox txtDesFormaPago;
        private MyLabelG.LabelDegradado labelDegradado1;
        private ControlesWinForm.SuperTextBox txtNomCorto;
        private ControlesWinForm.SuperTextBox txtMonto;
        private System.Windows.Forms.BindingSource bsFormaTipoPago;
        private System.Windows.Forms.ComboBox cboIndicador;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTipoPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn desConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkDatosAuxiliares;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMedioPago;
    }
}