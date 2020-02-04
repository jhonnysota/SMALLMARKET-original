namespace ClienteWinForm.Contabilidad
{
    partial class frmActivacion
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
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label fecDocumentoLabel;
            System.Windows.Forms.Label fecOperacionLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBasico = new System.Windows.Forms.Panel();
            this.txtTipoCambio = new ControlesWinForm.SuperTextBox();
            this.chkTicaAuto = new System.Windows.Forms.CheckBox();
            this.txtCodActivacion = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecDocumento = new System.Windows.Forms.DateTimePicker();
            this.dtpFecOperacion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.txtCodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboInicio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFin = new System.Windows.Forms.ComboBox();
            this.btObternerVoucher = new System.Windows.Forms.Button();
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.btCentroC = new System.Windows.Forms.Button();
            this.txtDesCCostos = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.bsActivacionDet = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtFecModifica = new System.Windows.Forms.TextBox();
            this.txtFecRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDebeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDebeDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoHaberDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            fecDocumentoLabel = new System.Windows.Forms.Label();
            fecOperacionLabel = new System.Windows.Forms.Label();
            this.pnlBasico.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsActivacionDet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(8, 110);
            label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(97, 13);
            label25.TabIndex = 6;
            label25.Text = "Fecha Modificación";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label26.Location = new System.Drawing.Point(8, 44);
            label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(86, 13);
            label26.TabIndex = 0;
            label26.Text = "Usuario Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 66);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 13);
            label3.TabIndex = 4;
            label3.Text = "Fecha Registro";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label28.Location = new System.Drawing.Point(8, 88);
            label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(104, 13);
            label28.TabIndex = 2;
            label28.Text = "Usuario Modificación";
            // 
            // fecDocumentoLabel
            // 
            fecDocumentoLabel.AutoSize = true;
            fecDocumentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fecDocumentoLabel.Location = new System.Drawing.Point(257, 32);
            fecDocumentoLabel.Name = "fecDocumentoLabel";
            fecDocumentoLabel.Size = new System.Drawing.Size(54, 13);
            fecDocumentoLabel.TabIndex = 1519;
            fecDocumentoLabel.Text = "Fec. Doc.";
            // 
            // fecOperacionLabel
            // 
            fecOperacionLabel.AutoSize = true;
            fecOperacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fecOperacionLabel.Location = new System.Drawing.Point(15, 32);
            fecOperacionLabel.Name = "fecOperacionLabel";
            fecOperacionLabel.Size = new System.Drawing.Size(54, 13);
            fecOperacionLabel.TabIndex = 1518;
            fecOperacionLabel.Text = "Fec. Ope.";
            // 
            // pnlBasico
            // 
            this.pnlBasico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBasico.Controls.Add(this.txtTipoCambio);
            this.pnlBasico.Controls.Add(this.chkTicaAuto);
            this.pnlBasico.Controls.Add(this.txtCodActivacion);
            this.pnlBasico.Controls.Add(this.label6);
            this.pnlBasico.Controls.Add(this.dtpFecDocumento);
            this.pnlBasico.Controls.Add(this.dtpFecOperacion);
            this.pnlBasico.Controls.Add(fecDocumentoLabel);
            this.pnlBasico.Controls.Add(fecOperacionLabel);
            this.pnlBasico.Controls.Add(this.label1);
            this.pnlBasico.Controls.Add(this.cboLibro);
            this.pnlBasico.Controls.Add(this.label2);
            this.pnlBasico.Controls.Add(this.cboFile);
            this.pnlBasico.Controls.Add(this.txtCodCuenta);
            this.pnlBasico.Controls.Add(this.txtDesCuenta);
            this.pnlBasico.Controls.Add(this.label5);
            this.pnlBasico.Controls.Add(this.cboInicio);
            this.pnlBasico.Controls.Add(this.label4);
            this.pnlBasico.Controls.Add(this.cboFin);
            this.pnlBasico.Controls.Add(this.btObternerVoucher);
            this.pnlBasico.Controls.Add(this.txtCCostos);
            this.pnlBasico.Controls.Add(this.btCentroC);
            this.pnlBasico.Controls.Add(this.txtDesCCostos);
            this.pnlBasico.Controls.Add(this.label27);
            this.pnlBasico.Controls.Add(this.label21);
            this.pnlBasico.Controls.Add(this.labelDegradado1);
            this.pnlBasico.Location = new System.Drawing.Point(4, 4);
            this.pnlBasico.Name = "pnlBasico";
            this.pnlBasico.Size = new System.Drawing.Size(526, 151);
            this.pnlBasico.TabIndex = 101;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipoCambio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTipoCambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio.Location = new System.Drawing.Point(463, 28);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(42, 20);
            this.txtTipoCambio.TabIndex = 1522;
            this.txtTipoCambio.TabStop = false;
            this.txtTipoCambio.Text = "0.000";
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTipoCambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTipoCambio.TextoVacio = "<Descripcion>";
            // 
            // chkTicaAuto
            // 
            this.chkTicaAuto.AutoSize = true;
            this.chkTicaAuto.Checked = true;
            this.chkTicaAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTicaAuto.Location = new System.Drawing.Point(398, 31);
            this.chkTicaAuto.Name = "chkTicaAuto";
            this.chkTicaAuto.Size = new System.Drawing.Size(65, 17);
            this.chkTicaAuto.TabIndex = 1523;
            this.chkTicaAuto.TabStop = false;
            this.chkTicaAuto.Text = "T.C.Aut.";
            this.chkTicaAuto.UseVisualStyleBackColor = true;
            this.chkTicaAuto.CheckedChanged += new System.EventHandler(this.chkTicaAuto_CheckedChanged);
            // 
            // txtCodActivacion
            // 
            this.txtCodActivacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodActivacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodActivacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodActivacion.Enabled = false;
            this.txtCodActivacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodActivacion.Location = new System.Drawing.Point(182, 28);
            this.txtCodActivacion.Name = "txtCodActivacion";
            this.txtCodActivacion.Size = new System.Drawing.Size(74, 20);
            this.txtCodActivacion.TabIndex = 2;
            this.txtCodActivacion.TabStop = false;
            this.txtCodActivacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodActivacion.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(161, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 1521;
            this.label6.Text = "N°";
            // 
            // dtpFecDocumento
            // 
            this.dtpFecDocumento.CustomFormat = "dd/MM/yyyy";
            this.dtpFecDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecDocumento.Location = new System.Drawing.Point(313, 28);
            this.dtpFecDocumento.Name = "dtpFecDocumento";
            this.dtpFecDocumento.Size = new System.Drawing.Size(82, 20);
            this.dtpFecDocumento.TabIndex = 3;
            this.dtpFecDocumento.ValueChanged += new System.EventHandler(this.dtpFecDocumento_ValueChanged);
            // 
            // dtpFecOperacion
            // 
            this.dtpFecOperacion.CustomFormat = "dd/MM/yyyy";
            this.dtpFecOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecOperacion.Location = new System.Drawing.Point(76, 28);
            this.dtpFecOperacion.Name = "dtpFecOperacion";
            this.dtpFecOperacion.Size = new System.Drawing.Size(82, 20);
            this.dtpFecOperacion.TabIndex = 1;
            this.dtpFecOperacion.ValueChanged += new System.EventHandler(this.dtpFecOperacion_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1515;
            this.label1.Text = "Libro Diario";
            // 
            // cboLibro
            // 
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(76, 119);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(162, 21);
            this.cboLibro.TabIndex = 1514;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1513;
            this.label2.Text = "File Capitalizacion";
            // 
            // cboFile
            // 
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(345, 119);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(160, 21);
            this.cboFile.TabIndex = 1512;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodCuenta.BackColor = System.Drawing.Color.White;
            this.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCuenta.Location = new System.Drawing.Point(76, 73);
            this.txtCodCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(64, 20);
            this.txtCodCuenta.TabIndex = 1510;
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
            this.txtDesCuenta.Location = new System.Drawing.Point(143, 73);
            this.txtDesCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(362, 20);
            this.txtDesCuenta.TabIndex = 1511;
            this.txtDesCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCuenta.TextoVacio = "<Descripcion>";
            this.txtDesCuenta.TextChanged += new System.EventHandler(this.txtDesCuenta_TextChanged);
            this.txtDesCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCuenta_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1509;
            this.label5.Text = "Mes Inicio";
            // 
            // cboInicio
            // 
            this.cboInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInicio.FormattingEnabled = true;
            this.cboInicio.Location = new System.Drawing.Point(76, 96);
            this.cboInicio.Name = "cboInicio";
            this.cboInicio.Size = new System.Drawing.Size(142, 21);
            this.cboInicio.TabIndex = 1508;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 1507;
            this.label4.Text = "Mes Final";
            // 
            // cboFin
            // 
            this.cboFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFin.FormattingEnabled = true;
            this.cboFin.Location = new System.Drawing.Point(278, 96);
            this.cboFin.Name = "cboFin";
            this.cboFin.Size = new System.Drawing.Size(140, 21);
            this.cboFin.TabIndex = 1506;
            // 
            // btObternerVoucher
            // 
            this.btObternerVoucher.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btObternerVoucher.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btObternerVoucher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btObternerVoucher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btObternerVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btObternerVoucher.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btObternerVoucher.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btObternerVoucher.Location = new System.Drawing.Point(423, 96);
            this.btObternerVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btObternerVoucher.Name = "btObternerVoucher";
            this.btObternerVoucher.Size = new System.Drawing.Size(82, 19);
            this.btObternerVoucher.TabIndex = 1505;
            this.btObternerVoucher.TabStop = false;
            this.btObternerVoucher.UseVisualStyleBackColor = false;
            this.btObternerVoucher.Click += new System.EventHandler(this.btObternerVoucher_Click);
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Enabled = false;
            this.txtCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCostos.Location = new System.Drawing.Point(76, 51);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(82, 20);
            this.txtCCostos.TabIndex = 104;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            // 
            // btCentroC
            // 
            this.btCentroC.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCentroC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCentroC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCentroC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCentroC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCentroC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCentroC.Location = new System.Drawing.Point(483, 52);
            this.btCentroC.Name = "btCentroC";
            this.btCentroC.Size = new System.Drawing.Size(22, 18);
            this.btCentroC.TabIndex = 1500;
            this.btCentroC.TabStop = false;
            this.btCentroC.UseVisualStyleBackColor = true;
            this.btCentroC.Click += new System.EventHandler(this.btCentroC_Click);
            // 
            // txtDesCCostos
            // 
            this.txtDesCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCCostos.Enabled = false;
            this.txtDesCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCCostos.Location = new System.Drawing.Point(160, 51);
            this.txtDesCCostos.Name = "txtDesCCostos";
            this.txtDesCCostos.ReadOnly = true;
            this.txtDesCCostos.Size = new System.Drawing.Size(320, 20);
            this.txtDesCCostos.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(15, 55);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 330;
            this.label27.Text = "C. Costos";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(15, 77);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 322;
            this.label21.Text = "Cuenta";
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
            this.labelDegradado1.Size = new System.Drawing.Size(524, 18);
            this.labelDegradado1.TabIndex = 253;
            this.labelDegradado1.Text = "Datos Principales";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.labelDegradado2);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 158);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(788, 242);
            this.pnlDetalle.TabIndex = 358;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuentaDataGridViewTextBoxColumn,
            this.desCuenta,
            this.montoDebeDataGridViewTextBoxColumn,
            this.montoHaberDataGridViewTextBoxColumn,
            this.MontoDebeDolares,
            this.MontoHaberDolares,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.bsActivacionDet;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 18);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(786, 222);
            this.dgvDetalle.TabIndex = 104;
            // 
            // bsActivacionDet
            // 
            this.bsActivacionDet.DataSource = typeof(Entidades.Contabilidad.ActivacionDetE);
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
            this.labelDegradado2.Size = new System.Drawing.Size(786, 18);
            this.labelDegradado2.TabIndex = 251;
            this.labelDegradado2.Text = "Detalle";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDegradado3);
            this.panel1.Controls.Add(label25);
            this.panel1.Controls.Add(this.txtFecModifica);
            this.panel1.Controls.Add(this.txtFecRegistro);
            this.panel1.Controls.Add(label26);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(label28);
            this.panel1.Controls.Add(this.txtUsuRegistra);
            this.panel1.Controls.Add(this.txtUsuModifica);
            this.panel1.Location = new System.Drawing.Point(534, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 151);
            this.panel1.TabIndex = 359;
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
            this.labelDegradado3.Size = new System.Drawing.Size(256, 18);
            this.labelDegradado3.TabIndex = 251;
            this.labelDegradado3.Text = "Auditoria";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFecModifica
            // 
            this.txtFecModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFecModifica.Enabled = false;
            this.txtFecModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecModifica.Location = new System.Drawing.Point(117, 106);
            this.txtFecModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecModifica.Name = "txtFecModifica";
            this.txtFecModifica.Size = new System.Drawing.Size(133, 20);
            this.txtFecModifica.TabIndex = 0;
            this.txtFecModifica.TabStop = false;
            // 
            // txtFecRegistro
            // 
            this.txtFecRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFecRegistro.Enabled = false;
            this.txtFecRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecRegistro.Location = new System.Drawing.Point(117, 62);
            this.txtFecRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecRegistro.Name = "txtFecRegistro";
            this.txtFecRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFecRegistro.TabIndex = 0;
            this.txtFecRegistro.TabStop = false;
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 40);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 84);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desCuenta";
            this.dataGridViewTextBoxColumn1.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MontoDebeDolares";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "Debe US$";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MontoHaberDolares";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Haber US$";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCuentaDataGridViewTextBoxColumn.Width = 60;
            // 
            // desCuenta
            // 
            this.desCuenta.DataPropertyName = "desCuenta";
            this.desCuenta.HeaderText = "Descripción";
            this.desCuenta.Name = "desCuenta";
            this.desCuenta.ReadOnly = true;
            this.desCuenta.Width = 250;
            // 
            // montoDebeDataGridViewTextBoxColumn
            // 
            this.montoDebeDataGridViewTextBoxColumn.DataPropertyName = "MontoDebe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.montoDebeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoDebeDataGridViewTextBoxColumn.HeaderText = "Debe S/.";
            this.montoDebeDataGridViewTextBoxColumn.Name = "montoDebeDataGridViewTextBoxColumn";
            this.montoDebeDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDebeDataGridViewTextBoxColumn.Width = 80;
            // 
            // montoHaberDataGridViewTextBoxColumn
            // 
            this.montoHaberDataGridViewTextBoxColumn.DataPropertyName = "MontoHaber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.montoHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.montoHaberDataGridViewTextBoxColumn.HeaderText = "Haber S/.";
            this.montoHaberDataGridViewTextBoxColumn.Name = "montoHaberDataGridViewTextBoxColumn";
            this.montoHaberDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoHaberDataGridViewTextBoxColumn.Width = 80;
            // 
            // MontoDebeDolares
            // 
            this.MontoDebeDolares.DataPropertyName = "MontoDebeDolares";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.MontoDebeDolares.DefaultCellStyle = dataGridViewCellStyle4;
            this.MontoDebeDolares.HeaderText = "Debe US$";
            this.MontoDebeDolares.Name = "MontoDebeDolares";
            this.MontoDebeDolares.ReadOnly = true;
            this.MontoDebeDolares.Width = 80;
            // 
            // MontoHaberDolares
            // 
            this.MontoHaberDolares.DataPropertyName = "MontoHaberDolares";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.MontoHaberDolares.DefaultCellStyle = dataGridViewCellStyle5;
            this.MontoHaberDolares.HeaderText = "Haber US$";
            this.MontoHaberDolares.Name = "MontoHaberDolares";
            this.MontoHaberDolares.ReadOnly = true;
            this.MontoHaberDolares.Width = 80;
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
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmActivacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(796, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlBasico);
            this.MaximizeBox = false;
            this.Name = "frmActivacion";
            this.Text = "Capitalización de Gasto (Nuevo)";
            this.Load += new System.EventHandler(this.frmActivacion_Load);
            this.pnlBasico.ResumeLayout(false);
            this.pnlBasico.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsActivacionDet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBasico;
        private ControlesWinForm.SuperTextBox txtCCostos;
        private System.Windows.Forms.Button btCentroC;
        private System.Windows.Forms.TextBox txtDesCCostos;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label21;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.TextBox txtFecModifica;
        private System.Windows.Forms.TextBox txtFecRegistro;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Button btObternerVoucher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFin;
        private System.Windows.Forms.BindingSource bsActivacionDet;
        private ControlesWinForm.SuperTextBox txtCodCuenta;
        private ControlesWinForm.SuperTextBox txtDesCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFile;
        private ControlesWinForm.SuperTextBox txtCodActivacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFecDocumento;
        private System.Windows.Forms.DateTimePicker dtpFecOperacion;
        private ControlesWinForm.SuperTextBox txtTipoCambio;
        private System.Windows.Forms.CheckBox chkTicaAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDebeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDebeDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoHaberDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}