namespace ClienteWinForm.CtasPorPagar
{
    partial class frmPlantillaCxp
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
            System.Windows.Forms.Label desPlantillaLabel;
            System.Windows.Forms.Label idComprobanteLabel;
            System.Windows.Forms.Label idPlantillaLabel;
            System.Windows.Forms.Label numFileLabel;
            System.Windows.Forms.Label tipoPlantillaLabel;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label codMonedaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.bsplantillacxp = new System.Windows.Forms.BindingSource(this.components);
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.desPlantillaTextBox = new System.Windows.Forms.TextBox();
            this.idPlantillaTextBox = new System.Windows.Forms.TextBox();
            this.tipoPlantillaTextBox = new System.Windows.Forms.TextBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPlantillaDet = new System.Windows.Forms.DataGridView();
            this.bsplantillacxpitem = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelDegradado9 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.idItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numVerPlanCuentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indDebeHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codColumnaCoven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            desPlantillaLabel = new System.Windows.Forms.Label();
            idComprobanteLabel = new System.Windows.Forms.Label();
            idPlantillaLabel = new System.Windows.Forms.Label();
            numFileLabel = new System.Windows.Forms.Label();
            tipoPlantillaLabel = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            codMonedaLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsplantillacxp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantillaDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplantillacxpitem)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // desPlantillaLabel
            // 
            desPlantillaLabel.AutoSize = true;
            desPlantillaLabel.Location = new System.Drawing.Point(155, 45);
            desPlantillaLabel.Name = "desPlantillaLabel";
            desPlantillaLabel.Size = new System.Drawing.Size(112, 13);
            desPlantillaLabel.TabIndex = 259;
            desPlantillaLabel.Text = "Nombre de la Plantilla:";
            // 
            // idComprobanteLabel
            // 
            idComprobanteLabel.AutoSize = true;
            idComprobanteLabel.Location = new System.Drawing.Point(44, 69);
            idComprobanteLabel.Name = "idComprobanteLabel";
            idComprobanteLabel.Size = new System.Drawing.Size(36, 13);
            idComprobanteLabel.TabIndex = 261;
            idComprobanteLabel.Text = "Libro :";
            // 
            // idPlantillaLabel
            // 
            idPlantillaLabel.AutoSize = true;
            idPlantillaLabel.Location = new System.Drawing.Point(23, 44);
            idPlantillaLabel.Name = "idPlantillaLabel";
            idPlantillaLabel.Size = new System.Drawing.Size(57, 13);
            idPlantillaLabel.TabIndex = 265;
            idPlantillaLabel.Text = "id Plantilla:";
            // 
            // numFileLabel
            // 
            numFileLabel.AutoSize = true;
            numFileLabel.Location = new System.Drawing.Point(51, 93);
            numFileLabel.Name = "numFileLabel";
            numFileLabel.Size = new System.Drawing.Size(29, 13);
            numFileLabel.TabIndex = 267;
            numFileLabel.Text = "File :";
            // 
            // tipoPlantillaLabel
            // 
            tipoPlantillaLabel.AutoSize = true;
            tipoPlantillaLabel.Location = new System.Drawing.Point(7, 117);
            tipoPlantillaLabel.Name = "tipoPlantillaLabel";
            tipoPlantillaLabel.Size = new System.Drawing.Size(73, 13);
            tipoPlantillaLabel.TabIndex = 269;
            tipoPlantillaLabel.Text = "Tipo Plantilla :";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(369, 56);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(369, 31);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(1, 31);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(1, 58);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // codMonedaLabel
            // 
            codMonedaLabel.AutoSize = true;
            codMonedaLabel.Location = new System.Drawing.Point(206, 116);
            codMonedaLabel.Name = "codMonedaLabel";
            codMonedaLabel.Size = new System.Drawing.Size(52, 13);
            codMonedaLabel.TabIndex = 272;
            codMonedaLabel.Text = "Moneda :";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(codMonedaLabel);
            this.panel2.Controls.Add(this.cboMoneda);
            this.panel2.Controls.Add(this.cboFile);
            this.panel2.Controls.Add(this.cboLibro);
            this.panel2.Controls.Add(desPlantillaLabel);
            this.panel2.Controls.Add(this.desPlantillaTextBox);
            this.panel2.Controls.Add(idComprobanteLabel);
            this.panel2.Controls.Add(idPlantillaLabel);
            this.panel2.Controls.Add(this.idPlantillaTextBox);
            this.panel2.Controls.Add(numFileLabel);
            this.panel2.Controls.Add(tipoPlantillaLabel);
            this.panel2.Controls.Add(this.tipoPlantillaTextBox);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Location = new System.Drawing.Point(12, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 145);
            this.panel2.TabIndex = 8;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsplantillacxp, "CodMoneda", true));
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(264, 113);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(140, 21);
            this.cboMoneda.TabIndex = 273;
            // 
            // bsplantillacxp
            // 
            this.bsplantillacxp.DataSource = typeof(Entidades.CtasPorPagar.Plantilla_ConceptoE);
            // 
            // cboFile
            // 
            this.cboFile.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsplantillacxp, "numFile", true));
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(92, 90);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(312, 21);
            this.cboFile.TabIndex = 272;
            // 
            // cboLibro
            // 
            this.cboLibro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsplantillacxp, "idComprobante", true));
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(92, 65);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(312, 21);
            this.cboLibro.TabIndex = 271;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // desPlantillaTextBox
            // 
            this.desPlantillaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "DesPlantilla", true));
            this.desPlantillaTextBox.Location = new System.Drawing.Point(271, 41);
            this.desPlantillaTextBox.Name = "desPlantillaTextBox";
            this.desPlantillaTextBox.Size = new System.Drawing.Size(255, 20);
            this.desPlantillaTextBox.TabIndex = 260;
            // 
            // idPlantillaTextBox
            // 
            this.idPlantillaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "idPlantilla", true));
            this.idPlantillaTextBox.Location = new System.Drawing.Point(92, 41);
            this.idPlantillaTextBox.Name = "idPlantillaTextBox";
            this.idPlantillaTextBox.ReadOnly = true;
            this.idPlantillaTextBox.Size = new System.Drawing.Size(51, 20);
            this.idPlantillaTextBox.TabIndex = 266;
            // 
            // tipoPlantillaTextBox
            // 
            this.tipoPlantillaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "TipoPlantilla", true));
            this.tipoPlantillaTextBox.Location = new System.Drawing.Point(92, 114);
            this.tipoPlantillaTextBox.Name = "tipoPlantillaTextBox";
            this.tipoPlantillaTextBox.Size = new System.Drawing.Size(100, 20);
            this.tipoPlantillaTextBox.TabIndex = 270;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(600, 21);
            this.labelDegradado1.TabIndex = 255;
            this.labelDegradado1.Text = "Datos de la Plantilla";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPlantillaDet);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(12, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 178);
            this.panel1.TabIndex = 9;
            // 
            // dgvPlantillaDet
            // 
            this.dgvPlantillaDet.AllowUserToAddRows = false;
            this.dgvPlantillaDet.AllowUserToDeleteRows = false;
            this.dgvPlantillaDet.AutoGenerateColumns = false;
            this.dgvPlantillaDet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlantillaDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlantillaDet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItem,
            this.numVerPlanCuentas,
            this.codCuenta,
            this.desCuentaDataGridViewTextBoxColumn,
            this.indDebeHaber,
            this.codColumnaCoven,
            this.DesColumna,
            this.UsuarioRegistro,
            this.fechaRegistro,
            this.UsuarioModificacion,
            this.fechaModificacion});
            this.dgvPlantillaDet.DataSource = this.bsplantillacxpitem;
            this.dgvPlantillaDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlantillaDet.EnableHeadersVisualStyles = false;
            this.dgvPlantillaDet.Location = new System.Drawing.Point(0, 21);
            this.dgvPlantillaDet.Name = "dgvPlantillaDet";
            this.dgvPlantillaDet.ReadOnly = true;
            this.dgvPlantillaDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlantillaDet.Size = new System.Drawing.Size(638, 155);
            this.dgvPlantillaDet.TabIndex = 5;
            this.dgvPlantillaDet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlantillaDet_CellDoubleClick);
            // 
            // bsplantillacxpitem
            // 
            this.bsplantillacxpitem.DataMember = "ListaPlantillaItem";
            this.bsplantillacxpitem.DataSource = typeof(Entidades.CtasPorPagar.Plantilla_ConceptoE);
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
            this.lblRegistros.Size = new System.Drawing.Size(638, 21);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Detalle de la Plantilla";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panel8.Location = new System.Drawing.Point(12, 152);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(602, 79);
            this.panel8.TabIndex = 338;
            // 
            // labelDegradado9
            // 
            this.labelDegradado9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado9.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado9.ForeColor = System.Drawing.Color.White;
            this.labelDegradado9.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado9.Name = "labelDegradado9";
            this.labelDegradado9.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado9.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado9.Size = new System.Drawing.Size(600, 21);
            this.labelDegradado9.TabIndex = 253;
            this.labelDegradado9.Text = "Auditoria";
            this.labelDegradado9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaModificacion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "fechaModificacion", true));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(485, 50);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(106, 21);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuRegistro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "UsuarioRegistro", true));
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(90, 26);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(106, 21);
            this.txtUsuRegistro.TabIndex = 1;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuModificacion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "UsuarioModificacion", true));
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(486, 26);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(106, 21);
            this.txtUsuModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFechaRegistro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsplantillacxp, "fechaRegistro", true));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(90, 53);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(106, 21);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // idItem
            // 
            this.idItem.DataPropertyName = "idItem";
            this.idItem.HeaderText = "Item";
            this.idItem.Name = "idItem";
            this.idItem.ReadOnly = true;
            // 
            // numVerPlanCuentas
            // 
            this.numVerPlanCuentas.DataPropertyName = "numVerPlanCuentas";
            this.numVerPlanCuentas.HeaderText = "Ver";
            this.numVerPlanCuentas.Name = "numVerPlanCuentas";
            this.numVerPlanCuentas.ReadOnly = true;
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.ReadOnly = true;
            // 
            // desCuentaDataGridViewTextBoxColumn
            // 
            this.desCuentaDataGridViewTextBoxColumn.DataPropertyName = "DesCuenta";
            this.desCuentaDataGridViewTextBoxColumn.HeaderText = "Nombre ";
            this.desCuentaDataGridViewTextBoxColumn.Name = "desCuentaDataGridViewTextBoxColumn";
            this.desCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indDebeHaber
            // 
            this.indDebeHaber.DataPropertyName = "indDebeHaber";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.indDebeHaber.DefaultCellStyle = dataGridViewCellStyle1;
            this.indDebeHaber.HeaderText = "D/H";
            this.indDebeHaber.Name = "indDebeHaber";
            this.indDebeHaber.ReadOnly = true;
            // 
            // codColumnaCoven
            // 
            this.codColumnaCoven.DataPropertyName = "codColumnaCoven";
            this.codColumnaCoven.HeaderText = "codColumnaCoven";
            this.codColumnaCoven.Name = "codColumnaCoven";
            this.codColumnaCoven.ReadOnly = true;
            // 
            // DesColumna
            // 
            this.DesColumna.DataPropertyName = "DesColumna";
            this.DesColumna.HeaderText = "DesColumna";
            this.DesColumna.Name = "DesColumna";
            this.DesColumna.ReadOnly = true;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.DataPropertyName = "UsuarioRegistro";
            this.UsuarioRegistro.HeaderText = "UsuarioRegistro";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            // 
            // fechaRegistro
            // 
            this.fechaRegistro.DataPropertyName = "fechaRegistro";
            this.fechaRegistro.HeaderText = "fechaRegistro";
            this.fechaRegistro.Name = "fechaRegistro";
            this.fechaRegistro.ReadOnly = true;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.HeaderText = "UsuarioModificacion";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            this.UsuarioModificacion.ReadOnly = true;
            // 
            // fechaModificacion
            // 
            this.fechaModificacion.DataPropertyName = "fechaModificacion";
            this.fechaModificacion.HeaderText = "fechaModificacion";
            this.fechaModificacion.Name = "fechaModificacion";
            this.fechaModificacion.ReadOnly = true;
            // 
            // frmPlantillaCxp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 418);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmPlantillaCxp";
            this.Text = "Plantilla de Cuentas Por Pagar";
            this.Load += new System.EventHandler(this.frmPlantillaCxp_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsplantillacxp)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantillaDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsplantillacxpitem)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPlantillaDet;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsplantillacxpitem;
        private System.Windows.Forms.BindingSource bsplantillacxp;
        private System.Windows.Forms.TextBox desPlantillaTextBox;
        private System.Windows.Forms.TextBox idPlantillaTextBox;
        private System.Windows.Forms.TextBox tipoPlantillaTextBox;
        private System.Windows.Forms.Panel panel8;
        private MyLabelG.LabelDegradado labelDegradado9;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVerPlanCuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indDebeHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColumnaCoven;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesColumna;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacion;
    }
}