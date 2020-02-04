namespace ClienteWinForm.Tesoreria
{
    partial class frmOrdenPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenPago));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlOtros = new System.Windows.Forms.Panel();
            this.txtIdProveedor = new ControlesWinForm.SuperTextBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtRucBeneficiario = new ControlesWinForm.SuperTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btBeneficiario = new System.Windows.Forms.Button();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtdesBeneficiario = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtidBeneficiario = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGlosa = new ControlesWinForm.SuperTextBox();
            this.btAgregarOtros = new System.Windows.Forms.Button();
            this.btAgregarPendiente = new System.Windows.Forms.Button();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvOrdenPagoDet = new System.Windows.Forms.DataGridView();
            this.bsOrdenPagoDet = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnlPrincipales = new System.Windows.Forms.Panel();
            this.cboConceptos = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodOrden = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
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
            this.lblTotalDolares = new MyLabelG.LabelDegradado();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalSoles = new MyLabelG.LabelDegradado();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoSecu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMonedaBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPartidaPresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOtros.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPagoDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenPagoDet)).BeginInit();
            this.pnlPrincipales.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOtros
            // 
            this.pnlOtros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtros.Controls.Add(this.txtIdProveedor);
            this.pnlOtros.Controls.Add(this.labelDegradado3);
            this.pnlOtros.Controls.Add(this.txtRucBeneficiario);
            this.pnlOtros.Controls.Add(this.label26);
            this.pnlOtros.Controls.Add(this.label1);
            this.pnlOtros.Controls.Add(this.btBeneficiario);
            this.pnlOtros.Controls.Add(this.txtRuc);
            this.pnlOtros.Controls.Add(this.txtdesBeneficiario);
            this.pnlOtros.Controls.Add(this.txtRazonSocial);
            this.pnlOtros.Controls.Add(this.txtidBeneficiario);
            this.pnlOtros.Controls.Add(this.label9);
            this.pnlOtros.Controls.Add(this.txtMonto);
            this.pnlOtros.Controls.Add(this.cboMoneda);
            this.pnlOtros.Controls.Add(this.label7);
            this.pnlOtros.Controls.Add(this.label5);
            this.pnlOtros.Controls.Add(this.txtGlosa);
            this.pnlOtros.Location = new System.Drawing.Point(4, 79);
            this.pnlOtros.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOtros.Name = "pnlOtros";
            this.pnlOtros.Size = new System.Drawing.Size(607, 116);
            this.pnlOtros.TabIndex = 275;
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdProveedor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdProveedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdProveedor.Enabled = false;
            this.txtIdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProveedor.Location = new System.Drawing.Point(75, 23);
            this.txtIdProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(62, 20);
            this.txtIdProveedor.TabIndex = 355;
            this.txtIdProveedor.TabStop = false;
            this.txtIdProveedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdProveedor.TextoVacio = "Digite ID";
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
            this.labelDegradado3.Size = new System.Drawing.Size(605, 18);
            this.labelDegradado3.TabIndex = 274;
            this.labelDegradado3.Text = "Datos Auxiliares";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRucBeneficiario
            // 
            this.txtRucBeneficiario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRucBeneficiario.BackColor = System.Drawing.Color.White;
            this.txtRucBeneficiario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRucBeneficiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRucBeneficiario.Location = new System.Drawing.Point(139, 45);
            this.txtRucBeneficiario.Margin = new System.Windows.Forms.Padding(2);
            this.txtRucBeneficiario.Name = "txtRucBeneficiario";
            this.txtRucBeneficiario.Size = new System.Drawing.Size(76, 20);
            this.txtRucBeneficiario.TabIndex = 356;
            this.txtRucBeneficiario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRucBeneficiario.TextoVacio = "<Descripcion>";
            this.txtRucBeneficiario.TextChanged += new System.EventHandler(this.txtRucBeneficiario_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 27);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 13);
            this.label26.TabIndex = 352;
            this.label26.Text = "Auxiliar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 286;
            this.label1.Text = "Beneficiario";
            // 
            // btBeneficiario
            // 
            this.btBeneficiario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBeneficiario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBeneficiario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBeneficiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBeneficiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBeneficiario.Image = ((System.Drawing.Image)(resources.GetObject("btBeneficiario.Image")));
            this.btBeneficiario.Location = new System.Drawing.Point(569, 46);
            this.btBeneficiario.Name = "btBeneficiario";
            this.btBeneficiario.Size = new System.Drawing.Size(24, 18);
            this.btBeneficiario.TabIndex = 332;
            this.btBeneficiario.TabStop = false;
            this.btBeneficiario.UseVisualStyleBackColor = true;
            this.btBeneficiario.Click += new System.EventHandler(this.btBeneficiario_Click);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(139, 23);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(76, 20);
            this.txtRuc.TabIndex = 4;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "Digite ID";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtdesBeneficiario
            // 
            this.txtdesBeneficiario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtdesBeneficiario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdesBeneficiario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtdesBeneficiario.Enabled = false;
            this.txtdesBeneficiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesBeneficiario.Location = new System.Drawing.Point(217, 45);
            this.txtdesBeneficiario.Margin = new System.Windows.Forms.Padding(2);
            this.txtdesBeneficiario.Name = "txtdesBeneficiario";
            this.txtdesBeneficiario.Size = new System.Drawing.Size(351, 20);
            this.txtdesBeneficiario.TabIndex = 7;
            this.txtdesBeneficiario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtdesBeneficiario.TextoVacio = "<Descripcion>";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(217, 23);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(377, 20);
            this.txtRazonSocial.TabIndex = 5;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "Digite Razon Social";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // txtidBeneficiario
            // 
            this.txtidBeneficiario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtidBeneficiario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtidBeneficiario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtidBeneficiario.Enabled = false;
            this.txtidBeneficiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidBeneficiario.Location = new System.Drawing.Point(75, 45);
            this.txtidBeneficiario.Margin = new System.Windows.Forms.Padding(2);
            this.txtidBeneficiario.Name = "txtidBeneficiario";
            this.txtidBeneficiario.Size = new System.Drawing.Size(62, 20);
            this.txtidBeneficiario.TabIndex = 6;
            this.txtidBeneficiario.TabStop = false;
            this.txtidBeneficiario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtidBeneficiario.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 343;
            this.label9.Text = "Moneda";
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.BackColor = System.Drawing.Color.White;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(75, 90);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(67, 20);
            this.txtMonto.TabIndex = 9;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMonto_MouseClick);
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(75, 67);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(140, 21);
            this.cboMoneda.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 346;
            this.label7.Text = "Monto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(181, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 346;
            this.label5.Text = "Glosa";
            // 
            // txtGlosa
            // 
            this.txtGlosa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGlosa.BackColor = System.Drawing.Color.White;
            this.txtGlosa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGlosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGlosa.Location = new System.Drawing.Point(217, 67);
            this.txtGlosa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGlosa.Multiline = true;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(377, 43);
            this.txtGlosa.TabIndex = 10;
            this.txtGlosa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtGlosa.TextoVacio = "<Descripcion>";
            // 
            // btAgregarOtros
            // 
            this.btAgregarOtros.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAgregarOtros.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarOtros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAgregarOtros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAgregarOtros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarOtros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregarOtros.Image = global::ClienteWinForm.Properties.Resources.plus;
            this.btAgregarOtros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAgregarOtros.Location = new System.Drawing.Point(614, 163);
            this.btAgregarOtros.Margin = new System.Windows.Forms.Padding(2);
            this.btAgregarOtros.Name = "btAgregarOtros";
            this.btAgregarOtros.Size = new System.Drawing.Size(111, 26);
            this.btAgregarOtros.TabIndex = 359;
            this.btAgregarOtros.Text = "Añadir Otros";
            this.btAgregarOtros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAgregarOtros.UseVisualStyleBackColor = false;
            this.btAgregarOtros.Visible = false;
            this.btAgregarOtros.Click += new System.EventHandler(this.btAgregarOtros_Click);
            // 
            // btAgregarPendiente
            // 
            this.btAgregarPendiente.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAgregarPendiente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAgregarPendiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAgregarPendiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAgregarPendiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarPendiente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregarPendiente.Image = global::ClienteWinForm.Properties.Resources.plus;
            this.btAgregarPendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAgregarPendiente.Location = new System.Drawing.Point(730, 163);
            this.btAgregarPendiente.Margin = new System.Windows.Forms.Padding(2);
            this.btAgregarPendiente.Name = "btAgregarPendiente";
            this.btAgregarPendiente.Size = new System.Drawing.Size(147, 26);
            this.btAgregarPendiente.TabIndex = 358;
            this.btAgregarPendiente.Text = "Añadir Doc. x Pagar";
            this.btAgregarPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAgregarPendiente.UseVisualStyleBackColor = false;
            this.btAgregarPendiente.Visible = false;
            this.btAgregarPendiente.Click += new System.EventHandler(this.btAgregarPendiente_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvOrdenPagoDet);
            this.pnlDetalle.Controls.Add(this.labelDegradado1);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 198);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(873, 212);
            this.pnlDetalle.TabIndex = 138;
            // 
            // dgvOrdenPagoDet
            // 
            this.dgvOrdenPagoDet.AllowUserToAddRows = false;
            this.dgvOrdenPagoDet.AllowUserToDeleteRows = false;
            this.dgvOrdenPagoDet.AutoGenerateColumns = false;
            this.dgvOrdenPagoDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenPagoDet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDataGridViewTextBoxColumn,
            this.desProveedor,
            this.idDocumento,
            this.serDocumento,
            this.numDocumento,
            this.idMonedaDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.MontoSecu,
            this.desMonedaBanco,
            this.TipPartidaPresu,
            this.CodPartidaPresu,
            this.DesPartida,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvOrdenPagoDet.DataSource = this.bsOrdenPagoDet;
            this.dgvOrdenPagoDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenPagoDet.EnableHeadersVisualStyles = false;
            this.dgvOrdenPagoDet.Location = new System.Drawing.Point(0, 18);
            this.dgvOrdenPagoDet.Name = "dgvOrdenPagoDet";
            this.dgvOrdenPagoDet.ReadOnly = true;
            this.dgvOrdenPagoDet.Size = new System.Drawing.Size(871, 192);
            this.dgvOrdenPagoDet.TabIndex = 271;
            this.dgvOrdenPagoDet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenPagoDet_CellDoubleClick);
            this.dgvOrdenPagoDet.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrdenPagoDet_RowPostPaint);
            // 
            // bsOrdenPagoDet
            // 
            this.bsOrdenPagoDet.DataSource = typeof(Entidades.Tesoreria.OrdenPagoDetE);
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
            this.labelDegradado1.Size = new System.Drawing.Size(871, 18);
            this.labelDegradado1.TabIndex = 270;
            this.labelDegradado1.Text = "Detalle";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPrincipales
            // 
            this.pnlPrincipales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipales.Controls.Add(this.cboConceptos);
            this.pnlPrincipales.Controls.Add(this.label11);
            this.pnlPrincipales.Controls.Add(this.txtCodOrden);
            this.pnlPrincipales.Controls.Add(this.label10);
            this.pnlPrincipales.Controls.Add(this.label8);
            this.pnlPrincipales.Controls.Add(this.dtpFecha);
            this.pnlPrincipales.Controls.Add(this.cboTipoPago);
            this.pnlPrincipales.Controls.Add(this.cboFormaPago);
            this.pnlPrincipales.Controls.Add(this.label13);
            this.pnlPrincipales.Controls.Add(this.label6);
            this.pnlPrincipales.Controls.Add(this.labelDegradado2);
            this.pnlPrincipales.Location = new System.Drawing.Point(4, 4);
            this.pnlPrincipales.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipales.Name = "pnlPrincipales";
            this.pnlPrincipales.Size = new System.Drawing.Size(607, 73);
            this.pnlPrincipales.TabIndex = 137;
            // 
            // cboConceptos
            // 
            this.cboConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptos.DropDownWidth = 250;
            this.cboConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptos.FormattingEnabled = true;
            this.cboConceptos.Location = new System.Drawing.Point(264, 46);
            this.cboConceptos.Name = "cboConceptos";
            this.cboConceptos.Size = new System.Drawing.Size(134, 21);
            this.cboConceptos.TabIndex = 355;
            this.cboConceptos.SelectionChangeCommitted += new System.EventHandler(this.cboConceptos_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(208, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 356;
            this.label11.Text = "Concepto";
            // 
            // txtCodOrden
            // 
            this.txtCodOrden.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodOrden.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodOrden.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodOrden.Enabled = false;
            this.txtCodOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodOrden.Location = new System.Drawing.Point(72, 23);
            this.txtCodOrden.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodOrden.Name = "txtCodOrden";
            this.txtCodOrden.Size = new System.Drawing.Size(96, 20);
            this.txtCodOrden.TabIndex = 353;
            this.txtCodOrden.TabStop = false;
            this.txtCodOrden.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodOrden.TextoVacio = "Digite ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 354;
            this.label10.Text = "Cód. Orden";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(170, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 348;
            this.label8.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(212, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(106, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.DropDownWidth = 250;
            this.cboTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(72, 46);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(134, 21);
            this.cboTipoPago.TabIndex = 2;
            this.cboTipoPago.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPago_SelectionChangeCommitted);
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(459, 46);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(134, 21);
            this.cboFormaPago.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(399, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 300;
            this.label13.Text = "Form.Pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 290;
            this.label6.Text = "Tip.Pago";
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
            this.labelDegradado2.Size = new System.Drawing.Size(605, 18);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.pnlAuditoria.Location = new System.Drawing.Point(614, 4);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(263, 123);
            this.pnlAuditoria.TabIndex = 136;
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
            this.labelDegradado5.Size = new System.Drawing.Size(261, 18);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(10, 95);
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
            this.txtModifica.Location = new System.Drawing.Point(117, 91);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
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
            this.txtRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtRegistro.TabIndex = 0;
            this.txtRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 29);
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
            this.label3.Location = new System.Drawing.Point(10, 51);
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
            this.label4.Location = new System.Drawing.Point(10, 73);
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
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 25);
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
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 69);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // lblTotalDolares
            // 
            this.lblTotalDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDolares.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotalDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDolares.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDolares.Location = new System.Drawing.Point(792, 413);
            this.lblTotalDolares.Name = "lblTotalDolares";
            this.lblTotalDolares.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTotalDolares.Size = new System.Drawing.Size(84, 22);
            this.lblTotalDolares.TabIndex = 1567;
            this.lblTotalDolares.Text = "0.00";
            this.lblTotalDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(725, 418);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 1566;
            this.label17.Text = "Total US$";
            // 
            // lblTotalSoles
            // 
            this.lblTotalSoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSoles.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotalSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSoles.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSoles.Location = new System.Drawing.Point(633, 413);
            this.lblTotalSoles.Name = "lblTotalSoles";
            this.lblTotalSoles.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblTotalSoles.Size = new System.Drawing.Size(84, 22);
            this.lblTotalSoles.TabIndex = 1565;
            this.lblTotalSoles.Text = "0.00";
            this.lblTotalSoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(575, 418);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 1564;
            this.label12.Text = "Total S/";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desProveedor";
            this.dataGridViewTextBoxColumn1.HeaderText = "Razón Social";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "idDocumento";
            this.dataGridViewTextBoxColumn2.HeaderText = "T.D.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "serDocumento";
            this.dataGridViewTextBoxColumn3.HeaderText = "Serie";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "numDocumento";
            this.dataGridViewTextBoxColumn4.HeaderText = "Número";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MontoSecu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "Monto Sec.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "desMonedaBanco";
            this.dataGridViewTextBoxColumn6.HeaderText = "Mon.Ban.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 68;
            // 
            // desProveedor
            // 
            this.desProveedor.DataPropertyName = "desProveedor";
            this.desProveedor.HeaderText = "Razón Social";
            this.desProveedor.Name = "desProveedor";
            this.desProveedor.ReadOnly = true;
            this.desProveedor.Width = 150;
            // 
            // idDocumento
            // 
            this.idDocumento.DataPropertyName = "idDocumento";
            this.idDocumento.HeaderText = "T.D.";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Width = 30;
            // 
            // serDocumento
            // 
            this.serDocumento.DataPropertyName = "serDocumento";
            this.serDocumento.HeaderText = "Serie";
            this.serDocumento.Name = "serDocumento";
            this.serDocumento.ReadOnly = true;
            this.serDocumento.Width = 50;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numDocumento";
            this.numDocumento.HeaderText = "Número";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            this.numDocumento.Width = 110;
            // 
            // idMonedaDataGridViewTextBoxColumn
            // 
            this.idMonedaDataGridViewTextBoxColumn.DataPropertyName = "desMoneda";
            this.idMonedaDataGridViewTextBoxColumn.HeaderText = "Mon.";
            this.idMonedaDataGridViewTextBoxColumn.Name = "idMonedaDataGridViewTextBoxColumn";
            this.idMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idMonedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn.Width = 70;
            // 
            // MontoSecu
            // 
            this.MontoSecu.DataPropertyName = "MontoSecu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.MontoSecu.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoSecu.HeaderText = "Monto Sec.";
            this.MontoSecu.Name = "MontoSecu";
            this.MontoSecu.ReadOnly = true;
            this.MontoSecu.Width = 80;
            // 
            // desMonedaBanco
            // 
            this.desMonedaBanco.DataPropertyName = "desMonedaBanco";
            this.desMonedaBanco.HeaderText = "Mon.Ban.";
            this.desMonedaBanco.Name = "desMonedaBanco";
            this.desMonedaBanco.ReadOnly = true;
            this.desMonedaBanco.Width = 60;
            // 
            // TipPartidaPresu
            // 
            this.TipPartidaPresu.DataPropertyName = "TipPartidaPresu";
            this.TipPartidaPresu.HeaderText = "Tp.";
            this.TipPartidaPresu.Name = "TipPartidaPresu";
            this.TipPartidaPresu.ReadOnly = true;
            this.TipPartidaPresu.Width = 30;
            // 
            // CodPartidaPresu
            // 
            this.CodPartidaPresu.DataPropertyName = "CodPartidaPresu";
            this.CodPartidaPresu.HeaderText = "Cod.Partida";
            this.CodPartidaPresu.Name = "CodPartidaPresu";
            this.CodPartidaPresu.ReadOnly = true;
            this.CodPartidaPresu.Width = 65;
            // 
            // DesPartida
            // 
            this.DesPartida.DataPropertyName = "DesPartida";
            this.DesPartida.HeaderText = "Des.Partida";
            this.DesPartida.Name = "DesPartida";
            this.DesPartida.ReadOnly = true;
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
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 140;
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
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 140;
            // 
            // frmOrdenPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 440);
            this.Controls.Add(this.lblTotalDolares);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblTotalSoles);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pnlOtros);
            this.Controls.Add(this.btAgregarOtros);
            this.Controls.Add(this.btAgregarPendiente);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlPrincipales);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "frmOrdenPago";
            this.Text = "Orden Pago (Nuevo)";
            this.Load += new System.EventHandler(this.frmOrdenPago_Load);
            this.pnlOtros.ResumeLayout(false);
            this.pnlOtros.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPagoDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdenPagoDet)).EndInit();
            this.pnlPrincipales.ResumeLayout(false);
            this.pnlPrincipales.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipales;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtidBeneficiario;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private MyLabelG.LabelDegradado labelDegradado2;
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
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboMoneda;
        private ControlesWinForm.SuperTextBox txtdesBeneficiario;
        private System.Windows.Forms.Button btBeneficiario;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtMonto;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtGlosa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlDetalle;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.DataGridView dgvOrdenPagoDet;
        private System.Windows.Forms.BindingSource bsOrdenPagoDet;
        private System.Windows.Forms.Label label26;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtCodOrden;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btAgregarPendiente;
        private System.Windows.Forms.Button btAgregarOtros;
        private ControlesWinForm.SuperTextBox txtIdProveedor;
        private ControlesWinForm.SuperTextBox txtRucBeneficiario;
        private System.Windows.Forms.Panel pnlOtros;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.ComboBox cboConceptos;
        private System.Windows.Forms.Label label11;
        private MyLabelG.LabelDegradado lblTotalDolares;
        private System.Windows.Forms.Label label17;
        private MyLabelG.LabelDegradado lblTotalSoles;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn serDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoSecu;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMonedaBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPartidaPresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}