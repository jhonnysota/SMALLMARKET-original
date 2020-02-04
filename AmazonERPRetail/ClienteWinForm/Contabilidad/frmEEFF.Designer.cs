namespace ClienteWinForm.Contabilidad
{
    partial class frmEEFF
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
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelDegradado9 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvListadoEEFF = new System.Windows.Forms.DataGridView();
            this.bsEEFFItem = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTipoReporte = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipoSeccion = new System.Windows.Forms.TextBox();
            this.txtdesSeccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbComparativo = new System.Windows.Forms.CheckBox();
            this.chbVerReporte = new System.Windows.Forms.CheckBox();
            this.chbCCostos = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEEFFItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoTablaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCaracteristica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCaracteristicaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnXls = new System.Windows.Forms.DataGridViewButtonColumn();
            this.indPorcentajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indImprimirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEnviaExcelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(18, 160);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(18, 125);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(18, 54);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(18, 89);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labelDegradado9);
            this.panel8.Controls.Add(label24);
            this.panel8.Controls.Add(this.txtFechaModificacion);
            this.panel8.Controls.Add(this.txtUsuRegistro);
            this.panel8.Controls.Add(label25);
            this.panel8.Controls.Add(label29);
            this.panel8.Controls.Add(this.txtUsuModificacion);
            this.panel8.Controls.Add(this.txtFechaRegistro);
            this.panel8.Controls.Add(label31);
            this.panel8.Location = new System.Drawing.Point(597, 3);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(396, 208);
            this.panel8.TabIndex = 262;
            // 
            // labelDegradado9
            // 
            this.labelDegradado9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado9.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado9.ForeColor = System.Drawing.Color.White;
            this.labelDegradado9.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDegradado9.Name = "labelDegradado9";
            this.labelDegradado9.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado9.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado9.Size = new System.Drawing.Size(394, 32);
            this.labelDegradado9.TabIndex = 253;
            this.labelDegradado9.Text = "Auditoria";
            this.labelDegradado9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(180, 152);
            this.txtFechaModificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(192, 21);
            this.txtFechaModificacion.TabIndex = 3;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(180, 46);
            this.txtUsuRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(192, 21);
            this.txtUsuRegistro.TabIndex = 0;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(180, 117);
            this.txtUsuModificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(192, 21);
            this.txtUsuModificacion.TabIndex = 2;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(180, 82);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(192, 21);
            this.txtFechaRegistro.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnQuitar);
            this.panel5.Controls.Add(this.btnAgregar);
            this.panel5.Controls.Add(this.dgvListadoEEFF);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 222);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1224, 364);
            this.panel5.TabIndex = 260;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(898, 0);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(86, 35);
            this.btnQuitar.TabIndex = 251;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(804, 0);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 35);
            this.btnAgregar.TabIndex = 250;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvListadoEEFF
            // 
            this.dgvListadoEEFF.AllowUserToAddRows = false;
            this.dgvListadoEEFF.AllowUserToDeleteRows = false;
            this.dgvListadoEEFF.AutoGenerateColumns = false;
            this.dgvListadoEEFF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEEFF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpresaDataGridViewTextBoxColumn,
            this.secItem,
            this.idEEFFDataGridViewTextBoxColumn,
            this.idEEFFItemDataGridViewTextBoxColumn,
            this.desItemDataGridViewTextBoxColumn,
            this.tipoTablaDataGridViewTextBoxColumn,
            this.codSunat,
            this.desTabla,
            this.desCaracteristica,
            this.tipoCaracteristicaDataGridViewTextBoxColumn,
            this.btnDetalle,
            this.btnXls,
            this.indPorcentajeDataGridViewTextBoxColumn,
            this.indImprimirDataGridViewTextBoxColumn,
            this.indEnviaExcelDataGridViewTextBoxColumn});
            this.dgvListadoEEFF.DataSource = this.bsEEFFItem;
            this.dgvListadoEEFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoEEFF.EnableHeadersVisualStyles = false;
            this.dgvListadoEEFF.Location = new System.Drawing.Point(0, 35);
            this.dgvListadoEEFF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListadoEEFF.Name = "dgvListadoEEFF";
            this.dgvListadoEEFF.ReadOnly = true;
            this.dgvListadoEEFF.Size = new System.Drawing.Size(1222, 327);
            this.dgvListadoEEFF.TabIndex = 0;
            this.dgvListadoEEFF.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoEEFF_CellClick);
            this.dgvListadoEEFF.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoEEFF_CellDoubleClick);
            // 
            // bsEEFFItem
            // 
            this.bsEEFFItem.DataSource = typeof(Entidades.Contabilidad.EEFFItemE);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(1222, 35);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Items - Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboTipoReporte);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTipoSeccion);
            this.panel1.Controls.Add(this.txtdesSeccion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 208);
            this.panel1.TabIndex = 261;
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoReporte.DropDownWidth = 110;
            this.cboTipoReporte.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoReporte.FormattingEnabled = true;
            this.cboTipoReporte.Location = new System.Drawing.Point(136, 118);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Size = new System.Drawing.Size(158, 21);
            this.cboTipoReporte.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblTitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitulo.Size = new System.Drawing.Size(582, 32);
            this.lblTitulo.TabIndex = 253;
            this.lblTitulo.Text = "Datos Principales";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Reporte ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción ";
            // 
            // txtTipoSeccion
            // 
            this.txtTipoSeccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoSeccion.Location = new System.Drawing.Point(136, 52);
            this.txtTipoSeccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTipoSeccion.MaxLength = 4;
            this.txtTipoSeccion.Name = "txtTipoSeccion";
            this.txtTipoSeccion.Size = new System.Drawing.Size(158, 26);
            this.txtTipoSeccion.TabIndex = 0;
            // 
            // txtdesSeccion
            // 
            this.txtdesSeccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdesSeccion.Location = new System.Drawing.Point(136, 85);
            this.txtdesSeccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdesSeccion.Name = "txtdesSeccion";
            this.txtdesSeccion.Size = new System.Drawing.Size(416, 26);
            this.txtdesSeccion.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chbComparativo);
            this.panel2.Controls.Add(this.chbVerReporte);
            this.panel2.Controls.Add(this.chbCCostos);
            this.panel2.Location = new System.Drawing.Point(9, 162);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 36);
            this.panel2.TabIndex = 264;
            // 
            // chbComparativo
            // 
            this.chbComparativo.AutoSize = true;
            this.chbComparativo.Location = new System.Drawing.Point(220, 6);
            this.chbComparativo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbComparativo.Name = "chbComparativo";
            this.chbComparativo.Size = new System.Drawing.Size(58, 24);
            this.chbComparativo.TabIndex = 6;
            this.chbComparativo.Text = "PLE";
            this.chbComparativo.UseVisualStyleBackColor = true;
            // 
            // chbVerReporte
            // 
            this.chbVerReporte.AutoSize = true;
            this.chbVerReporte.Location = new System.Drawing.Point(398, 6);
            this.chbVerReporte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbVerReporte.Name = "chbVerReporte";
            this.chbVerReporte.Size = new System.Drawing.Size(115, 24);
            this.chbVerReporte.TabIndex = 265;
            this.chbVerReporte.Text = "Ver Reporte";
            this.chbVerReporte.UseVisualStyleBackColor = true;
            // 
            // chbCCostos
            // 
            this.chbCCostos.AutoSize = true;
            this.chbCCostos.Location = new System.Drawing.Point(39, 6);
            this.chbCCostos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbCCostos.Name = "chbCCostos";
            this.chbCCostos.Size = new System.Drawing.Size(130, 24);
            this.chbCCostos.TabIndex = 5;
            this.chbCCostos.Text = "Centro Costos";
            this.chbCCostos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "secItem";
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "desTabla";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tabla";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "desCaracteristica";
            this.dataGridViewTextBoxColumn3.HeaderText = "Caracteristica";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // secItem
            // 
            this.secItem.DataPropertyName = "secItem";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.secItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.secItem.HeaderText = "Item";
            this.secItem.Name = "secItem";
            this.secItem.ReadOnly = true;
            this.secItem.Width = 60;
            // 
            // idEEFFDataGridViewTextBoxColumn
            // 
            this.idEEFFDataGridViewTextBoxColumn.DataPropertyName = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.HeaderText = "idEEFF";
            this.idEEFFDataGridViewTextBoxColumn.Name = "idEEFFDataGridViewTextBoxColumn";
            this.idEEFFDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEEFFDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEEFFItemDataGridViewTextBoxColumn
            // 
            this.idEEFFItemDataGridViewTextBoxColumn.DataPropertyName = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.HeaderText = "idItem";
            this.idEEFFItemDataGridViewTextBoxColumn.Name = "idEEFFItemDataGridViewTextBoxColumn";
            this.idEEFFItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEEFFItemDataGridViewTextBoxColumn.Width = 50;
            // 
            // desItemDataGridViewTextBoxColumn
            // 
            this.desItemDataGridViewTextBoxColumn.DataPropertyName = "desItem";
            this.desItemDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desItemDataGridViewTextBoxColumn.Name = "desItemDataGridViewTextBoxColumn";
            this.desItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.desItemDataGridViewTextBoxColumn.Width = 250;
            // 
            // tipoTablaDataGridViewTextBoxColumn
            // 
            this.tipoTablaDataGridViewTextBoxColumn.DataPropertyName = "TipoTabla";
            this.tipoTablaDataGridViewTextBoxColumn.HeaderText = "TipoTabla";
            this.tipoTablaDataGridViewTextBoxColumn.Name = "tipoTablaDataGridViewTextBoxColumn";
            this.tipoTablaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoTablaDataGridViewTextBoxColumn.Visible = false;
            this.tipoTablaDataGridViewTextBoxColumn.Width = 130;
            // 
            // codSunat
            // 
            this.codSunat.DataPropertyName = "codSunat";
            this.codSunat.HeaderText = "codSunat";
            this.codSunat.Name = "codSunat";
            this.codSunat.ReadOnly = true;
            this.codSunat.Width = 80;
            // 
            // desTabla
            // 
            this.desTabla.DataPropertyName = "desTabla";
            this.desTabla.HeaderText = "Tabla";
            this.desTabla.Name = "desTabla";
            this.desTabla.ReadOnly = true;
            this.desTabla.Width = 80;
            // 
            // desCaracteristica
            // 
            this.desCaracteristica.DataPropertyName = "desCaracteristica";
            this.desCaracteristica.HeaderText = "Caracteristica";
            this.desCaracteristica.Name = "desCaracteristica";
            this.desCaracteristica.ReadOnly = true;
            // 
            // tipoCaracteristicaDataGridViewTextBoxColumn
            // 
            this.tipoCaracteristicaDataGridViewTextBoxColumn.DataPropertyName = "TipoCaracteristica";
            this.tipoCaracteristicaDataGridViewTextBoxColumn.HeaderText = "TipoCaracteristica";
            this.tipoCaracteristicaDataGridViewTextBoxColumn.Name = "tipoCaracteristicaDataGridViewTextBoxColumn";
            this.tipoCaracteristicaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCaracteristicaDataGridViewTextBoxColumn.Visible = false;
            this.tipoCaracteristicaDataGridViewTextBoxColumn.Width = 130;
            // 
            // btnDetalle
            // 
            this.btnDetalle.DataPropertyName = "btnDetalle";
            this.btnDetalle.HeaderText = "Cts / For";
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.ReadOnly = true;
            this.btnDetalle.Text = "Ver...";
            this.btnDetalle.UseColumnTextForButtonValue = true;
            this.btnDetalle.Width = 60;
            // 
            // btnXls
            // 
            this.btnXls.DataPropertyName = "btnXls";
            this.btnXls.HeaderText = "Excel";
            this.btnXls.Name = "btnXls";
            this.btnXls.ReadOnly = true;
            this.btnXls.Text = "Xls ...";
            this.btnXls.UseColumnTextForButtonValue = true;
            this.btnXls.Width = 60;
            // 
            // indPorcentajeDataGridViewTextBoxColumn
            // 
            this.indPorcentajeDataGridViewTextBoxColumn.DataPropertyName = "indPorcentaje";
            this.indPorcentajeDataGridViewTextBoxColumn.HeaderText = "Porcentaje";
            this.indPorcentajeDataGridViewTextBoxColumn.Name = "indPorcentajeDataGridViewTextBoxColumn";
            this.indPorcentajeDataGridViewTextBoxColumn.ReadOnly = true;
            this.indPorcentajeDataGridViewTextBoxColumn.Visible = false;
            this.indPorcentajeDataGridViewTextBoxColumn.Width = 70;
            // 
            // indImprimirDataGridViewTextBoxColumn
            // 
            this.indImprimirDataGridViewTextBoxColumn.DataPropertyName = "indImprimir";
            this.indImprimirDataGridViewTextBoxColumn.HeaderText = "Imprimir";
            this.indImprimirDataGridViewTextBoxColumn.Name = "indImprimirDataGridViewTextBoxColumn";
            this.indImprimirDataGridViewTextBoxColumn.ReadOnly = true;
            this.indImprimirDataGridViewTextBoxColumn.Visible = false;
            this.indImprimirDataGridViewTextBoxColumn.Width = 70;
            // 
            // indEnviaExcelDataGridViewTextBoxColumn
            // 
            this.indEnviaExcelDataGridViewTextBoxColumn.DataPropertyName = "indEnviaExcel";
            this.indEnviaExcelDataGridViewTextBoxColumn.HeaderText = "Envia Excel";
            this.indEnviaExcelDataGridViewTextBoxColumn.Name = "indEnviaExcelDataGridViewTextBoxColumn";
            this.indEnviaExcelDataGridViewTextBoxColumn.ReadOnly = true;
            this.indEnviaExcelDataGridViewTextBoxColumn.Visible = false;
            this.indEnviaExcelDataGridViewTextBoxColumn.Width = 90;
            // 
            // frmEEFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 589);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.Name = "frmEEFF";
            this.Text = "Ingresar Estados Financieros";
            this.Load += new System.EventHandler(this.frmEEFF_Load);
            this.Shown += new System.EventHandler(this.frmEEFF_Shown);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEEFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEEFFItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTipoSeccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdesSeccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbComparativo;
        private System.Windows.Forms.CheckBox chbCCostos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoEEFF;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsEEFFItem;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado lblTitulo;
        private System.Windows.Forms.Panel panel8;
        private MyLabelG.LabelDegradado labelDegradado9;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ComboBox cboTipoReporte;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbVerReporte;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoTablaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCaracteristica;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCaracteristicaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn btnXls;
        private System.Windows.Forms.DataGridViewTextBoxColumn indPorcentajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indImprimirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indEnviaExcelDataGridViewTextBoxColumn;
    }
}