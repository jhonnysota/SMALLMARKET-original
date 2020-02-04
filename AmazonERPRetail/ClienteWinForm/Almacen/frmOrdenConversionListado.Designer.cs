namespace ClienteWinForm.Almacen
{
    partial class frmOrdenConversionListado
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
            this.bsOrdenConversion = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblLetras = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.txtNomArt = new ControlesWinForm.SuperTextBox();
            this.txtArt = new ControlesWinForm.SuperTextBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.rbUno = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOperacion = new System.Windows.Forms.RadioButton();
            this.rbMovimiento = new System.Windows.Forms.RadioButton();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTransformacion = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb0 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvConversion = new System.Windows.Forms.DataGridView();
            this.idOrdenConversionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indGenerada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indIngreso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsConversiones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmGenerarSalida = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarSalida = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGeneraIngreso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminarIngreso = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.LblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenConversion)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversion)).BeginInit();
            this.cmsConversiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsOrdenConversion
            // 
            this.bsOrdenConversion.DataSource = typeof(Entidades.Almacen.OrdenConversionE);
            this.bsOrdenConversion.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsOrdenConversion_ListChanged);
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BackColor = System.Drawing.Color.Transparent;
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.lblLetras);
            this.pnlDatos.Controls.Add(this.groupBox3);
            this.pnlDatos.Controls.Add(this.groupBox2);
            this.pnlDatos.Controls.Add(this.groupBox1);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1177, 97);
            this.pnlDatos.TabIndex = 328;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(1175, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Parámetros Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbTodos);
            this.groupBox3.Controls.Add(this.txtNomArt);
            this.groupBox3.Controls.Add(this.txtArt);
            this.groupBox3.Controls.Add(this.cboAlmacen);
            this.groupBox3.Controls.Add(this.rbUno);
            this.groupBox3.Location = new System.Drawing.Point(566, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 67);
            this.groupBox3.TabIndex = 367;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Articulos";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(12, 19);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 362;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // txtNomArt
            // 
            this.txtNomArt.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNomArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNomArt.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNomArt.Enabled = false;
            this.txtNomArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomArt.Location = new System.Drawing.Point(74, 39);
            this.txtNomArt.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomArt.Name = "txtNomArt";
            this.txtNomArt.Size = new System.Drawing.Size(395, 20);
            this.txtNomArt.TabIndex = 363;
            this.txtNomArt.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNomArt.TextoVacio = "Producto";
            this.txtNomArt.Validating += new System.ComponentModel.CancelEventHandler(this.txtNomArt_Validating);
            // 
            // txtArt
            // 
            this.txtArt.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtArt.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtArt.Enabled = false;
            this.txtArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArt.Location = new System.Drawing.Point(11, 39);
            this.txtArt.Margin = new System.Windows.Forms.Padding(2);
            this.txtArt.Name = "txtArt";
            this.txtArt.Size = new System.Drawing.Size(61, 20);
            this.txtArt.TabIndex = 361;
            this.txtArt.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtArt.TextoVacio = "Código";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(198, 16);
            this.cboAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(271, 21);
            this.cboAlmacen.TabIndex = 364;
            // 
            // rbUno
            // 
            this.rbUno.AutoSize = true;
            this.rbUno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUno.Location = new System.Drawing.Point(73, 19);
            this.rbUno.Name = "rbUno";
            this.rbUno.Size = new System.Drawing.Size(66, 17);
            this.rbUno.TabIndex = 360;
            this.rbUno.Text = "Solo uno";
            this.rbUno.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOperacion);
            this.groupBox2.Controls.Add(this.rbMovimiento);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Location = new System.Drawing.Point(290, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 67);
            this.groupBox2.TabIndex = 366;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechas";
            // 
            // rbOperacion
            // 
            this.rbOperacion.AutoSize = true;
            this.rbOperacion.Checked = true;
            this.rbOperacion.Location = new System.Drawing.Point(17, 17);
            this.rbOperacion.Name = "rbOperacion";
            this.rbOperacion.Size = new System.Drawing.Size(69, 17);
            this.rbOperacion.TabIndex = 332;
            this.rbOperacion.TabStop = true;
            this.rbOperacion.Text = "Fec.Ope.";
            this.rbOperacion.UseVisualStyleBackColor = true;
            // 
            // rbMovimiento
            // 
            this.rbMovimiento.AutoSize = true;
            this.rbMovimiento.Location = new System.Drawing.Point(92, 17);
            this.rbMovimiento.Name = "rbMovimiento";
            this.rbMovimiento.Size = new System.Drawing.Size(70, 17);
            this.rbMovimiento.TabIndex = 333;
            this.rbMovimiento.Text = "Fec.Mov.";
            this.rbMovimiento.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(37, 39);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(96, 20);
            this.dtpDesde.TabIndex = 327;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 326;
            this.label12.Text = "De";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 328;
            this.label1.Text = "a";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(151, 39);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(96, 20);
            this.dtpHasta.TabIndex = 329;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTransformacion);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Controls.Add(this.rb0);
            this.groupBox1.Location = new System.Drawing.Point(11, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 67);
            this.groupBox1.TabIndex = 365;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Concepto";
            // 
            // rbTransformacion
            // 
            this.rbTransformacion.AutoSize = true;
            this.rbTransformacion.Location = new System.Drawing.Point(151, 17);
            this.rbTransformacion.Name = "rbTransformacion";
            this.rbTransformacion.Size = new System.Drawing.Size(98, 17);
            this.rbTransformacion.TabIndex = 332;
            this.rbTransformacion.Text = "Transformación";
            this.rbTransformacion.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(27, 39);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(111, 17);
            this.rb1.TabIndex = 331;
            this.rb1.Text = "Cambio de Código";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb0
            // 
            this.rb0.AutoSize = true;
            this.rb0.Checked = true;
            this.rb0.Location = new System.Drawing.Point(27, 17);
            this.rb0.Name = "rb0";
            this.rb0.Size = new System.Drawing.Size(79, 17);
            this.rb0.TabIndex = 330;
            this.rb0.TabStop = true;
            this.rb0.Text = "Producción";
            this.rb0.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvConversion);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.LblRegistros);
            this.panel1.Location = new System.Drawing.Point(3, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 394);
            this.panel1.TabIndex = 78;
            // 
            // dgvConversion
            // 
            this.dgvConversion.AllowUserToAddRows = false;
            this.dgvConversion.AllowUserToDeleteRows = false;
            this.dgvConversion.AutoGenerateColumns = false;
            this.dgvConversion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConversion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConversion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOrdenConversionDataGridViewTextBoxColumn,
            this.Numero,
            this.FechaOperacion,
            this.Fecha,
            this.nomAlmacen,
            this.TotalPeso,
            this.indGenerada,
            this.indIngreso,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvConversion.ContextMenuStrip = this.cmsConversiones;
            this.dgvConversion.DataSource = this.bsOrdenConversion;
            this.dgvConversion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConversion.EnableHeadersVisualStyles = false;
            this.dgvConversion.Location = new System.Drawing.Point(0, 18);
            this.dgvConversion.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConversion.Name = "dgvConversion";
            this.dgvConversion.ReadOnly = true;
            this.dgvConversion.RowTemplate.Height = 24;
            this.dgvConversion.Size = new System.Drawing.Size(1175, 374);
            this.dgvConversion.TabIndex = 80;
            this.dgvConversion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConversion_CellDoubleClick);
            // 
            // idOrdenConversionDataGridViewTextBoxColumn
            // 
            this.idOrdenConversionDataGridViewTextBoxColumn.DataPropertyName = "idOrdenConversion";
            this.idOrdenConversionDataGridViewTextBoxColumn.Frozen = true;
            this.idOrdenConversionDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idOrdenConversionDataGridViewTextBoxColumn.Name = "idOrdenConversionDataGridViewTextBoxColumn";
            this.idOrdenConversionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOrdenConversionDataGridViewTextBoxColumn.Width = 40;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.Frozen = true;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 80;
            // 
            // FechaOperacion
            // 
            this.FechaOperacion.DataPropertyName = "FechaOperacion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.FechaOperacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaOperacion.Frozen = true;
            this.FechaOperacion.HeaderText = "Fec.Ope.";
            this.FechaOperacion.Name = "FechaOperacion";
            this.FechaOperacion.ReadOnly = true;
            this.FechaOperacion.Width = 65;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "F.Mov.Alm";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 65;
            // 
            // nomAlmacen
            // 
            this.nomAlmacen.DataPropertyName = "nomAlmacen";
            this.nomAlmacen.HeaderText = "Almacén";
            this.nomAlmacen.Name = "nomAlmacen";
            this.nomAlmacen.ReadOnly = true;
            this.nomAlmacen.Width = 250;
            // 
            // TotalPeso
            // 
            this.TotalPeso.DataPropertyName = "TotalPeso";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N6";
            this.TotalPeso.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalPeso.HeaderText = "Total Peso";
            this.TotalPeso.Name = "TotalPeso";
            this.TotalPeso.ReadOnly = true;
            this.TotalPeso.Width = 90;
            // 
            // indGenerada
            // 
            this.indGenerada.DataPropertyName = "indGenerada";
            this.indGenerada.HeaderText = "Sal.";
            this.indGenerada.Name = "indGenerada";
            this.indGenerada.ReadOnly = true;
            this.indGenerada.Width = 30;
            // 
            // indIngreso
            // 
            this.indIngreso.DataPropertyName = "indIngreso";
            this.indIngreso.HeaderText = "Ing.";
            this.indIngreso.Name = "indIngreso";
            this.indIngreso.ReadOnly = true;
            this.indIngreso.Width = 30;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // cmsConversiones
            // 
            this.cmsConversiones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsConversiones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGenerarSalida,
            this.tsmEliminarSalida,
            this.toolStripSeparator1,
            this.tsmGeneraIngreso,
            this.tsmEliminarIngreso});
            this.cmsConversiones.Name = "cmsConversiones";
            this.cmsConversiones.Size = new System.Drawing.Size(169, 98);
            // 
            // tsmGenerarSalida
            // 
            this.tsmGenerarSalida.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.tsmGenerarSalida.Name = "tsmGenerarSalida";
            this.tsmGenerarSalida.Size = new System.Drawing.Size(168, 22);
            this.tsmGenerarSalida.Text = "Generar SALIDA";
            this.tsmGenerarSalida.Click += new System.EventHandler(this.tsmGenerarSalida_Click);
            // 
            // tsmEliminarSalida
            // 
            this.tsmEliminarSalida.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmEliminarSalida.Name = "tsmEliminarSalida";
            this.tsmEliminarSalida.Size = new System.Drawing.Size(168, 22);
            this.tsmEliminarSalida.Text = "Eliminar SALIDA";
            this.tsmEliminarSalida.Click += new System.EventHandler(this.tsmEliminarSalida_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // tsmGeneraIngreso
            // 
            this.tsmGeneraIngreso.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.tsmGeneraIngreso.Name = "tsmGeneraIngreso";
            this.tsmGeneraIngreso.Size = new System.Drawing.Size(168, 22);
            this.tsmGeneraIngreso.Text = "Generar INGRESO";
            this.tsmGeneraIngreso.Click += new System.EventHandler(this.tsmGeneraIngreso_Click);
            // 
            // tsmEliminarIngreso
            // 
            this.tsmEliminarIngreso.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.tsmEliminarIngreso.Name = "tsmEliminarIngreso";
            this.tsmEliminarIngreso.Size = new System.Drawing.Size(168, 22);
            this.tsmEliminarIngreso.Text = "Eliminar INGRESO";
            this.tsmEliminarIngreso.Click += new System.EventHandler(this.tsmEliminarIngreso_Click);
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // LblRegistros
            // 
            this.LblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(0, 0);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(1175, 18);
            this.LblRegistros.TabIndex = 1573;
            this.LblRegistros.Text = "Registros 0";
            this.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOrdenConversionListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 498);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.panel1);
            this.Name = "frmOrdenConversionListado";
            this.Text = "Listado de Ordenes de Conversión";
            this.Load += new System.EventHandler(this.frmOrdenConversionListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenConversion)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversion)).EndInit();
            this.cmsConversiones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvConversion;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bsOrdenConversion;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsConversiones;
        private System.Windows.Forms.ToolStripMenuItem tsmGenerarSalida;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarSalida;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmGeneraIngreso;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminarIngreso;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb0;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbUno;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private ControlesWinForm.SuperTextBox txtArt;
        private ControlesWinForm.SuperTextBox txtNomArt;
        private System.Windows.Forms.RadioButton rbMovimiento;
        private System.Windows.Forms.RadioButton rbOperacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTransformacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenConversionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPeso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indGenerada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label LblRegistros;
    }
}