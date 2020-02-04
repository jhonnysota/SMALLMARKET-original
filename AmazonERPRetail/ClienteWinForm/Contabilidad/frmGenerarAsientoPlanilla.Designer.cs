namespace ClienteWinForm.Contabilidad
{
    partial class frmGenerarAsientoPlanilla
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
            this.cboPlantilla = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvPlantilla = new System.Windows.Forms.DataGridView();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indDebeHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.serieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codColumnaCovenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPlantilla = new System.Windows.Forms.BindingSource(this.components);
            this.txtRuta = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscarArchivo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilaIni = new ControlesWinForm.SuperTextBox();
            this.txtColIni = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilaFin = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtColFin = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotCol = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotFilas = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHoja = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGlosa = new ControlesWinForm.SuperTextBox();
            this.txtAnio = new ControlesWinForm.SuperTextBox();
            this.txtMes = new ControlesWinForm.SuperTextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btObtenerDatos = new System.Windows.Forms.Button();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlantilla)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPlantilla
            // 
            this.cboPlantilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlantilla.Enabled = false;
            this.cboPlantilla.FormattingEnabled = true;
            this.cboPlantilla.Location = new System.Drawing.Point(100, 49);
            this.cboPlantilla.Name = "cboPlantilla";
            this.cboPlantilla.Size = new System.Drawing.Size(187, 21);
            this.cboPlantilla.TabIndex = 0;
            this.cboPlantilla.SelectionChangeCommitted += new System.EventHandler(this.cboPlantilla_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escoger Plantilla";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvPlantilla);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 134);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(1168, 287);
            this.pnlDetalle.TabIndex = 257;
            // 
            // dgvPlantilla
            // 
            this.dgvPlantilla.AllowUserToAddRows = false;
            this.dgvPlantilla.AllowUserToDeleteRows = false;
            this.dgvPlantilla.AutoGenerateColumns = false;
            this.dgvPlantilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlantilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuenta,
            this.desCuenta,
            this.indDebeHaberDataGridViewTextBoxColumn,
            this.idCCostosDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.nroDocumentoDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.idDocumento,
            this.serieDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.codColumnaCovenDataGridViewTextBoxColumn,
            this.UsuarioRegistro});
            this.dgvPlantilla.DataSource = this.bsPlantilla;
            this.dgvPlantilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlantilla.EnableHeadersVisualStyles = false;
            this.dgvPlantilla.Location = new System.Drawing.Point(0, 0);
            this.dgvPlantilla.Name = "dgvPlantilla";
            this.dgvPlantilla.Size = new System.Drawing.Size(1166, 285);
            this.dgvPlantilla.TabIndex = 259;
            this.dgvPlantilla.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlantilla_CellEnter);
            this.dgvPlantilla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPlantilla_CellMouseClick);
            this.dgvPlantilla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPlantilla_DataError);
            this.dgvPlantilla.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPlantilla_RowPostPaint);
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.ReadOnly = true;
            // 
            // desCuenta
            // 
            this.desCuenta.DataPropertyName = "desCuenta";
            this.desCuenta.HeaderText = "Descripción";
            this.desCuenta.Name = "desCuenta";
            this.desCuenta.ReadOnly = true;
            // 
            // indDebeHaberDataGridViewTextBoxColumn
            // 
            this.indDebeHaberDataGridViewTextBoxColumn.DataPropertyName = "indDebeHaber";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.indDebeHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.indDebeHaberDataGridViewTextBoxColumn.HeaderText = "D/H";
            this.indDebeHaberDataGridViewTextBoxColumn.Name = "indDebeHaberDataGridViewTextBoxColumn";
            this.indDebeHaberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCCostosDataGridViewTextBoxColumn
            // 
            this.idCCostosDataGridViewTextBoxColumn.DataPropertyName = "idCCostos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idCCostosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idCCostosDataGridViewTextBoxColumn.HeaderText = "C.Costos";
            this.idCCostosDataGridViewTextBoxColumn.Name = "idCCostosDataGridViewTextBoxColumn";
            this.idCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nroDocumentoDataGridViewTextBoxColumn
            // 
            this.nroDocumentoDataGridViewTextBoxColumn.DataPropertyName = "nroDocumento";
            this.nroDocumentoDataGridViewTextBoxColumn.HeaderText = "RUC/Nro.Doc.";
            this.nroDocumentoDataGridViewTextBoxColumn.Name = "nroDocumentoDataGridViewTextBoxColumn";
            this.nroDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Raz.Social/Nombres";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumento.DefaultCellStyle = dataGridViewCellStyle4;
            this.idDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // serieDataGridViewTextBoxColumn
            // 
            this.serieDataGridViewTextBoxColumn.DataPropertyName = "Serie";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.serieDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.serieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.serieDataGridViewTextBoxColumn.Name = "serieDataGridViewTextBoxColumn";
            this.serieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codColumnaCovenDataGridViewTextBoxColumn
            // 
            this.codColumnaCovenDataGridViewTextBoxColumn.DataPropertyName = "codColumnaCoven";
            this.codColumnaCovenDataGridViewTextBoxColumn.HeaderText = "Co/Ve";
            this.codColumnaCovenDataGridViewTextBoxColumn.Name = "codColumnaCovenDataGridViewTextBoxColumn";
            this.codColumnaCovenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UsuarioRegistro.DefaultCellStyle = dataGridViewCellStyle6;
            this.UsuarioRegistro.HeaderText = "Usuario Reg.";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            // 
            // bsPlantilla
            // 
            this.bsPlantilla.DataSource = typeof(Entidades.Contabilidad.PlantillaAsientoDetE);
            // 
            // txtRuta
            // 
            this.txtRuta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRuta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(100, 28);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(514, 20);
            this.txtRuta.TabIndex = 258;
            this.txtRuta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuta.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 259;
            this.label2.Text = "Ruta del Archivo";
            // 
            // btBuscarArchivo
            // 
            this.btBuscarArchivo.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArchivo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarArchivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArchivo.Location = new System.Drawing.Point(615, 28);
            this.btBuscarArchivo.Name = "btBuscarArchivo";
            this.btBuscarArchivo.Size = new System.Drawing.Size(23, 19);
            this.btBuscarArchivo.TabIndex = 320;
            this.btBuscarArchivo.TabStop = false;
            this.btBuscarArchivo.UseVisualStyleBackColor = true;
            this.btBuscarArchivo.Click += new System.EventHandler(this.btBuscarArchivo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 321;
            this.label3.Text = "Fila Inicio";
            // 
            // txtFilaIni
            // 
            this.txtFilaIni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFilaIni.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFilaIni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFilaIni.Enabled = false;
            this.txtFilaIni.Location = new System.Drawing.Point(427, 49);
            this.txtFilaIni.Name = "txtFilaIni";
            this.txtFilaIni.Size = new System.Drawing.Size(43, 20);
            this.txtFilaIni.TabIndex = 322;
            this.txtFilaIni.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtFilaIni.TextoVacio = "<Descripcion>";
            // 
            // txtColIni
            // 
            this.txtColIni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtColIni.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtColIni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtColIni.Enabled = false;
            this.txtColIni.Location = new System.Drawing.Point(551, 49);
            this.txtColIni.Name = "txtColIni";
            this.txtColIni.Size = new System.Drawing.Size(43, 20);
            this.txtColIni.TabIndex = 324;
            this.txtColIni.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtColIni.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 323;
            this.label4.Text = "Columna Inicio";
            // 
            // txtFilaFin
            // 
            this.txtFilaFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFilaFin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFilaFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFilaFin.Enabled = false;
            this.txtFilaFin.Location = new System.Drawing.Point(638, 49);
            this.txtFilaFin.Name = "txtFilaFin";
            this.txtFilaFin.Size = new System.Drawing.Size(43, 20);
            this.txtFilaFin.TabIndex = 326;
            this.txtFilaFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtFilaFin.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(596, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 325;
            this.label5.Text = "Fila Fin";
            // 
            // txtColFin
            // 
            this.txtColFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtColFin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtColFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtColFin.Enabled = false;
            this.txtColFin.Location = new System.Drawing.Point(750, 49);
            this.txtColFin.Name = "txtColFin";
            this.txtColFin.Size = new System.Drawing.Size(43, 20);
            this.txtColFin.TabIndex = 328;
            this.txtColFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtColFin.TextoVacio = "<Descripcion>";
            this.txtColFin.TextChanged += new System.EventHandler(this.txtColFin_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(683, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 327;
            this.label6.Text = "Columna Fin";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGenerar.Enabled = false;
            this.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Location = new System.Drawing.Point(812, 51);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(93, 38);
            this.btnGenerar.TabIndex = 344;
            this.btnGenerar.Text = "Generar\r\nVoucher";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTotCol);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTotFilas);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtHoja);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtGlosa);
            this.panel1.Controls.Add(this.txtAnio);
            this.panel1.Controls.Add(this.txtMes);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Controls.Add(this.cboPlantilla);
            this.panel1.Controls.Add(this.txtColFin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.txtFilaFin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btBuscarArchivo);
            this.panel1.Controls.Add(this.txtColIni);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFilaIni);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 127);
            this.panel1.TabIndex = 259;
            // 
            // txtTotCol
            // 
            this.txtTotCol.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotCol.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTotCol.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotCol.Enabled = false;
            this.txtTotCol.Location = new System.Drawing.Point(750, 98);
            this.txtTotCol.Name = "txtTotCol";
            this.txtTotCol.Size = new System.Drawing.Size(43, 20);
            this.txtTotCol.TabIndex = 338;
            this.txtTotCol.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtTotCol.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(683, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 337;
            this.label9.Text = "Total Colum.";
            // 
            // txtTotFilas
            // 
            this.txtTotFilas.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotFilas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTotFilas.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotFilas.Enabled = false;
            this.txtTotFilas.Location = new System.Drawing.Point(750, 73);
            this.txtTotFilas.Name = "txtTotFilas";
            this.txtTotFilas.Size = new System.Drawing.Size(43, 20);
            this.txtTotFilas.TabIndex = 336;
            this.txtTotFilas.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtTotFilas.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(683, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 335;
            this.label8.Text = "Total Filas";
            // 
            // txtHoja
            // 
            this.txtHoja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtHoja.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtHoja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtHoja.Enabled = false;
            this.txtHoja.Location = new System.Drawing.Point(325, 49);
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(43, 20);
            this.txtHoja.TabIndex = 334;
            this.txtHoja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtHoja.TextoVacio = "<Descripcion>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 333;
            this.label7.Text = "Hoja";
            // 
            // txtGlosa
            // 
            this.txtGlosa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtGlosa.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtGlosa.ColorTextoVacio = System.Drawing.Color.DimGray;
            this.txtGlosa.Enabled = false;
            this.txtGlosa.Location = new System.Drawing.Point(11, 73);
            this.txtGlosa.Multiline = true;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGlosa.Size = new System.Drawing.Size(670, 45);
            this.txtGlosa.TabIndex = 332;
            this.txtGlosa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGlosa.TextoVacio = "Ingrese una glosa...";
            // 
            // txtAnio
            // 
            this.txtAnio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAnio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtAnio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAnio.Enabled = false;
            this.txtAnio.Location = new System.Drawing.Point(750, 28);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(43, 20);
            this.txtAnio.TabIndex = 331;
            this.txtAnio.TabStop = false;
            this.txtAnio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtAnio.TextoVacio = "<Descripcion>";
            // 
            // txtMes
            // 
            this.txtMes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMes.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtMes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMes.Enabled = false;
            this.txtMes.Location = new System.Drawing.Point(723, 28);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(27, 20);
            this.txtMes.TabIndex = 330;
            this.txtMes.TabStop = false;
            this.txtMes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtMes.TextoVacio = "<Descripcion>";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(639, 28);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(83, 20);
            this.dtpFecha.TabIndex = 329;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(801, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btObtenerDatos
            // 
            this.btObtenerDatos.BackColor = System.Drawing.Color.Transparent;
            this.btObtenerDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btObtenerDatos.Enabled = false;
            this.btObtenerDatos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btObtenerDatos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btObtenerDatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btObtenerDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btObtenerDatos.Image = global::ClienteWinForm.Properties.Resources.Importar;
            this.btObtenerDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btObtenerDatos.Location = new System.Drawing.Point(812, 4);
            this.btObtenerDatos.Name = "btObtenerDatos";
            this.btObtenerDatos.Size = new System.Drawing.Size(93, 38);
            this.btObtenerDatos.TabIndex = 345;
            this.btObtenerDatos.Text = "Importar\r\nArchivo";
            this.btObtenerDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btObtenerDatos.UseVisualStyleBackColor = false;
            this.btObtenerDatos.Click += new System.EventHandler(this.btObtenerDatos_Click);
            // 
            // frmGenerarAsientoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 425);
            this.Controls.Add(this.btObtenerDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmGenerarAsientoPlanilla";
            this.Text = "Generar Asientos Automáticos";
            this.Load += new System.EventHandler(this.frmGenerarAsientoPlanilla_Load);
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlantilla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPlantilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDetalle;
        private ControlesWinForm.SuperTextBox txtRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btBuscarArchivo;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtFilaIni;
        private ControlesWinForm.SuperTextBox txtColIni;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtFilaFin;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtColFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btObtenerDatos;
        private ControlesWinForm.SuperTextBox txtAnio;
        private ControlesWinForm.SuperTextBox txtMes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ControlesWinForm.SuperTextBox txtGlosa;
        private System.Windows.Forms.BindingSource bsPlantilla;
        private ControlesWinForm.SuperTextBox txtHoja;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtTotCol;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtTotFilas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvPlantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn indDebeHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColumnaCovenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
    }
}