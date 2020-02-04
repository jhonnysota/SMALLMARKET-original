namespace ClienteWinForm.Contabilidad
{
    partial class frmTipoComprobantes
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label tpoComprobanteLabel;
            System.Windows.Forms.Label idComprobanteLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsComprobantesFile = new System.Windows.Forms.BindingSource(this.components);
            this.bsComprobantes = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.indTCVenta = new System.Windows.Forms.CheckBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.cboTipoDiario = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new ControlesWinForm.SuperTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesLarga = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboDgvIdMoneda = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.flagAutomaticoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flagIndFlujo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndForma = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LLevaCuenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaSoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indPorExtornar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flagIndPartidaPres = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            descripcionLabel = new System.Windows.Forms.Label();
            tpoComprobanteLabel = new System.Windows.Forms.Label();
            idComprobanteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsComprobantesFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsComprobantes)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(103, 30);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(61, 13);
            descripcionLabel.TabIndex = 1;
            descripcionLabel.Text = "Descripción";
            // 
            // tpoComprobanteLabel
            // 
            tpoComprobanteLabel.AutoSize = true;
            tpoComprobanteLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tpoComprobanteLabel.Location = new System.Drawing.Point(10, 56);
            tpoComprobanteLabel.Name = "tpoComprobanteLabel";
            tpoComprobanteLabel.Size = new System.Drawing.Size(77, 13);
            tpoComprobanteLabel.TabIndex = 11;
            tpoComprobanteLabel.Text = "Tipos de Diario";
            // 
            // idComprobanteLabel
            // 
            idComprobanteLabel.AutoSize = true;
            idComprobanteLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idComprobanteLabel.Location = new System.Drawing.Point(10, 30);
            idComprobanteLabel.Name = "idComprobanteLabel";
            idComprobanteLabel.Size = new System.Drawing.Size(40, 13);
            idComprobanteLabel.TabIndex = 7;
            idComprobanteLabel.Text = "Código";
            // 
            // bsComprobantesFile
            // 
            this.bsComprobantesFile.DataMember = "ListaComprobantesFiles";
            this.bsComprobantesFile.DataSource = this.bsComprobantes;
            this.bsComprobantesFile.CurrentChanged += new System.EventHandler(this.bsComprobantesFile_CurrentChanged);
            // 
            // bsComprobantes
            // 
            this.bsComprobantes.DataSource = typeof(Entidades.Contabilidad.ComprobantesE);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idEmpresa";
            this.dataGridViewTextBoxColumn1.HeaderText = "idEmpresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "idComprobante";
            this.dataGridViewTextBoxColumn2.HeaderText = "idComprobante";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "numFile";
            this.dataGridViewTextBoxColumn3.HeaderText = "File";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn4.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn5.HeaderText = "Usuario Registro";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FechaRegistro";
            this.dataGridViewTextBoxColumn6.HeaderText = "Fecha Registro";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn7.HeaderText = "Usuario Modificación";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn8.HeaderText = "Fecha Modificación";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.indTCVenta);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(descripcionLabel);
            this.panel2.Controls.Add(this.cboTipoDiario);
            this.panel2.Controls.Add(tpoComprobanteLabel);
            this.panel2.Controls.Add(idComprobanteLabel);
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(986, 84);
            this.panel2.TabIndex = 251;
            // 
            // indTCVenta
            // 
            this.indTCVenta.AutoSize = true;
            this.indTCVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.indTCVenta.Checked = true;
            this.indTCVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.indTCVenta.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsComprobantes, "indTCVenta", true));
            this.indTCVenta.Location = new System.Drawing.Point(259, 56);
            this.indTCVenta.Name = "indTCVenta";
            this.indTCVenta.Size = new System.Drawing.Size(158, 17);
            this.indTCVenta.TabIndex = 252;
            this.indTCVenta.Text = "Usar Tipo De Cambio Venta";
            this.indTCVenta.UseVisualStyleBackColor = true;
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
            this.labelDegradado1.Size = new System.Drawing.Size(984, 19);
            this.labelDegradado1.TabIndex = 250;
            this.labelDegradado1.Text = "Datos";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComprobantes, "Descripcion", true));
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(167, 26);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(322, 21);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // cboTipoDiario
            // 
            this.cboTipoDiario.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsComprobantes, "tpoComprobante", true));
            this.cboTipoDiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDiario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDiario.FormattingEnabled = true;
            this.cboTipoDiario.Location = new System.Drawing.Point(99, 52);
            this.cboTipoDiario.Name = "cboTipoDiario";
            this.cboTipoDiario.Size = new System.Drawing.Size(154, 21);
            this.cboTipoDiario.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodigo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodigo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComprobantes, "idComprobante", true));
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(56, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(44, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodigo.TextoVacio = "<Descripcion>";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvFiles);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 302);
            this.panel1.TabIndex = 4;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idComprobanteDataGridViewTextBoxColumn,
            this.numFile,
            this.descripcionDataGridViewTextBoxColumn,
            this.DesLarga,
            this.cboDgvIdMoneda,
            this.flagAutomaticoDataGridViewCheckBoxColumn,
            this.flagIndFlujo,
            this.IndForma,
            this.LLevaCuenta,
            this.codCuenta,
            this.desCuenta,
            this.codCuentaSoles,
            this.codCuentaDolar,
            this.indPorExtornar,
            this.flagIndPartidaPres,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvFiles.DataSource = this.bsComprobantesFile;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.EnableHeadersVisualStyles = false;
            this.dgvFiles.Location = new System.Drawing.Point(0, 19);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(984, 281);
            this.dgvFiles.TabIndex = 5;
            this.dgvFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellClick);
            this.dgvFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellDoubleClick);
            this.dgvFiles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellEndEdit);
            this.dgvFiles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellEnter);
            this.dgvFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellValueChanged);
            this.dgvFiles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFiles_DataError);
            this.dgvFiles.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFiles_EditingControlShowing);
            this.dgvFiles.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvFiles_RowsAdded);
            this.dgvFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFiles_KeyPress);
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idComprobanteDataGridViewTextBoxColumn
            // 
            this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "idComprobante";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idComprobanteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "idComprobante";
            this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
            this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idComprobanteDataGridViewTextBoxColumn.Visible = false;
            // 
            // numFile
            // 
            this.numFile.DataPropertyName = "numFile";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numFile.DefaultCellStyle = dataGridViewCellStyle2;
            this.numFile.HeaderText = "File";
            this.numFile.Name = "numFile";
            this.numFile.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // DesLarga
            // 
            this.DesLarga.DataPropertyName = "DesLarga";
            this.DesLarga.HeaderText = "Des.Larga";
            this.DesLarga.Name = "DesLarga";
            this.DesLarga.Text = "Editar";
            this.DesLarga.UseColumnTextForButtonValue = true;
            this.DesLarga.Width = 90;
            // 
            // cboDgvIdMoneda
            // 
            this.cboDgvIdMoneda.DataPropertyName = "idMoneda";
            this.cboDgvIdMoneda.HeaderText = "Moneda";
            this.cboDgvIdMoneda.Name = "cboDgvIdMoneda";
            this.cboDgvIdMoneda.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboDgvIdMoneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // flagAutomaticoDataGridViewCheckBoxColumn
            // 
            this.flagAutomaticoDataGridViewCheckBoxColumn.DataPropertyName = "flagAutomatico";
            this.flagAutomaticoDataGridViewCheckBoxColumn.HeaderText = "Ind.Autom.";
            this.flagAutomaticoDataGridViewCheckBoxColumn.Name = "flagAutomaticoDataGridViewCheckBoxColumn";
            // 
            // flagIndFlujo
            // 
            this.flagIndFlujo.DataPropertyName = "flagIndFlujo";
            this.flagIndFlujo.HeaderText = "Ind. Flujo";
            this.flagIndFlujo.Name = "flagIndFlujo";
            // 
            // IndForma
            // 
            this.IndForma.DataPropertyName = "IndForma";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IndForma.DefaultCellStyle = dataGridViewCellStyle3;
            this.IndForma.HeaderText = "Ind. Forma";
            this.IndForma.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.IndForma.Name = "IndForma";
            this.IndForma.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IndForma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LLevaCuenta
            // 
            this.LLevaCuenta.DataPropertyName = "LLevaCuenta";
            this.LLevaCuenta.HeaderText = "Lleva Cta.";
            this.LLevaCuenta.Name = "LLevaCuenta";
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuenta.DefaultCellStyle = dataGridViewCellStyle4;
            this.codCuenta.HeaderText = "Cód.Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.Width = 80;
            // 
            // desCuenta
            // 
            this.desCuenta.DataPropertyName = "desCuenta";
            this.desCuenta.HeaderText = "Descripcion Cuenta";
            this.desCuenta.Name = "desCuenta";
            this.desCuenta.ReadOnly = true;
            this.desCuenta.Width = 150;
            // 
            // codCuentaSoles
            // 
            this.codCuentaSoles.DataPropertyName = "codCuentaSoles";
            this.codCuentaSoles.HeaderText = "Cod.CuentaSoles";
            this.codCuentaSoles.Name = "codCuentaSoles";
            // 
            // codCuentaDolar
            // 
            this.codCuentaDolar.DataPropertyName = "codCuentaDolar";
            this.codCuentaDolar.HeaderText = "Cod.CuentaDolar";
            this.codCuentaDolar.Name = "codCuentaDolar";
            // 
            // indPorExtornar
            // 
            this.indPorExtornar.DataPropertyName = "indPorExtornar";
            this.indPorExtornar.HeaderText = "Ind. Extornar";
            this.indPorExtornar.Name = "indPorExtornar";
            // 
            // flagIndPartidaPres
            // 
            this.flagIndPartidaPres.DataPropertyName = "flagIndPartidaPres";
            this.flagIndPartidaPres.HeaderText = "Ind. PartidaPres";
            this.flagIndPartidaPres.Name = "flagIndPartidaPres";
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Registro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Registro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.usuarioModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Modificación";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Modificación";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(984, 19);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Files";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTipoComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.Name = "frmTipoComprobantes";
            this.Text = "Diarios";
            this.Load += new System.EventHandler(this.frmTipoComprobantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsComprobantesFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsComprobantes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsComprobantes;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private ControlesWinForm.SuperTextBox txtCodigo;
        private System.Windows.Forms.ComboBox cboTipoDiario;
        private System.Windows.Forms.BindingSource bsComprobantesFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.CheckBox indTCVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DesLarga;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboDgvIdMoneda;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagAutomaticoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagIndFlujo;
        private System.Windows.Forms.DataGridViewComboBoxColumn IndForma;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LLevaCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaSoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDolar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indPorExtornar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagIndPartidaPres;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}