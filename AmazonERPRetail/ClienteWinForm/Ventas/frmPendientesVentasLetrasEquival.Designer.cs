namespace ClienteWinForm.Ventas
{
    partial class frmPendientesVentasLetrasEquival
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdCliente = new ControlesWinForm.SuperTextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.btCliente = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblTotaSol = new MyLabelG.LabelDegradado();
            this.lblTotalDol = new MyLabelG.LabelDegradado();
            this.dgvDocumentosPendientes = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desGlosaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoEquivalente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoOperativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaEquivalente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(459, 440);
            this.btCancelar.Size = new System.Drawing.Size(132, 26);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(320, 440);
            this.btAceptar.Size = new System.Drawing.Size(132, 26);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(1077, 19);
            this.lblTitPnlBase.Text = "Pendientes 0";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1097, 25);
            this.lblTituloPrincipal.Text = "Documentos Pendientes";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Tesoreria.CtaCteE);
            this.bsBase.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBase_ListChanged);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(1068, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvDocumentosPendientes);
            this.pnlBase.Location = new System.Drawing.Point(9, 97);
            this.pnlBase.Size = new System.Drawing.Size(1079, 335);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dgvDocumentosPendientes, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(840, 445);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(14, 13);
            label4.TabIndex = 1577;
            label4.Text = "$";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(727, 445);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(25, 13);
            label3.TabIndex = 1576;
            label3.Text = "S/.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(599, 445);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(124, 13);
            label2.TabIndex = 1575;
            label2.Text = "Neto Acumulados =>";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.chkTodos);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.btCliente);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(9, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 65);
            this.panel1.TabIndex = 262;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdCliente.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(106, 30);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(48, 20);
            this.txtIdCliente.TabIndex = 304;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCliente.TextoVacio = "";
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas;
            this.btBuscar.Location = new System.Drawing.Point(731, 18);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(62, 45);
            this.btBuscar.TabIndex = 303;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(48, 32);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 261;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.White;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(156, 29);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(80, 21);
            this.txtRuc.TabIndex = 300;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // btCliente
            // 
            this.btCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliente.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btCliente.Location = new System.Drawing.Point(666, 29);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(25, 21);
            this.btCliente.TabIndex = 301;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(239, 29);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(425, 21);
            this.txtRazonSocial.TabIndex = 302;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonSocial_KeyPress);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // lblTotaSol
            // 
            this.lblTotaSol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotaSol.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotaSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaSol.ForeColor = System.Drawing.Color.Black;
            this.lblTotaSol.Location = new System.Drawing.Point(751, 440);
            this.lblTotaSol.Name = "lblTotaSol";
            this.lblTotaSol.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotaSol.Size = new System.Drawing.Size(84, 22);
            this.lblTotaSol.TabIndex = 1579;
            this.lblTotaSol.Text = "0.00";
            this.lblTotaSol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDol
            // 
            this.lblTotalDol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDol.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblTotalDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDol.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDol.Location = new System.Drawing.Point(857, 440);
            this.lblTotalDol.Name = "lblTotalDol";
            this.lblTotalDol.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblTotalDol.Size = new System.Drawing.Size(84, 22);
            this.lblTotalDol.TabIndex = 1578;
            this.lblTotalDol.Text = "0.00";
            this.lblTotalDol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDocumentosPendientes
            // 
            this.dgvDocumentosPendientes.AllowUserToAddRows = false;
            this.dgvDocumentosPendientes.AllowUserToDeleteRows = false;
            this.dgvDocumentosPendientes.AllowUserToOrderColumns = true;
            this.dgvDocumentosPendientes.AutoGenerateColumns = false;
            this.dgvDocumentosPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentosPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.razonSocialDataGridViewTextBoxColumn,
            this.desGlosaDataGridViewTextBoxColumn,
            this.codCuenta,
            this.idDocumentoDataGridViewTextBoxColumn,
            this.numSerieDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.desMoneda,
            this.Saldo,
            this.SaldoEquivalente,
            this.SaldoOperativo,
            this.CuentaEquivalente});
            this.dgvDocumentosPendientes.DataSource = this.bsBase;
            this.dgvDocumentosPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentosPendientes.EnableHeadersVisualStyles = false;
            this.dgvDocumentosPendientes.Location = new System.Drawing.Point(0, 19);
            this.dgvDocumentosPendientes.Name = "dgvDocumentosPendientes";
            this.dgvDocumentosPendientes.Size = new System.Drawing.Size(1077, 314);
            this.dgvDocumentosPendientes.TabIndex = 253;
            this.dgvDocumentosPendientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosPendientes_CellContentClick);
            this.dgvDocumentosPendientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDocumentosPendientes_CellPainting);
            this.dgvDocumentosPendientes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosPendientes_CellValueChanged);
            this.dgvDocumentosPendientes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDocumentosPendientes_CurrentCellDirtyStateChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.DataPropertyName = "Seleccionar";
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Width = 20;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "Razón Social";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialDataGridViewTextBoxColumn.Width = 250;
            // 
            // desGlosaDataGridViewTextBoxColumn
            // 
            this.desGlosaDataGridViewTextBoxColumn.DataPropertyName = "desGlosa";
            this.desGlosaDataGridViewTextBoxColumn.HeaderText = "Concepto";
            this.desGlosaDataGridViewTextBoxColumn.Name = "desGlosaDataGridViewTextBoxColumn";
            this.desGlosaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desGlosaDataGridViewTextBoxColumn.Width = 200;
            // 
            // codCuenta
            // 
            this.codCuenta.DataPropertyName = "codCuenta";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.codCuenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.codCuenta.HeaderText = "Cuenta";
            this.codCuenta.Name = "codCuenta";
            this.codCuenta.ReadOnly = true;
            this.codCuenta.Width = 50;
            // 
            // idDocumentoDataGridViewTextBoxColumn
            // 
            this.idDocumentoDataGridViewTextBoxColumn.DataPropertyName = "idDocumento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDocumentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idDocumentoDataGridViewTextBoxColumn.HeaderText = "T.D.";
            this.idDocumentoDataGridViewTextBoxColumn.Name = "idDocumentoDataGridViewTextBoxColumn";
            this.idDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDocumentoDataGridViewTextBoxColumn.Width = 30;
            // 
            // numSerieDataGridViewTextBoxColumn
            // 
            this.numSerieDataGridViewTextBoxColumn.DataPropertyName = "numSerie";
            this.numSerieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieDataGridViewTextBoxColumn.Name = "numSerieDataGridViewTextBoxColumn";
            this.numSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.numSerieDataGridViewTextBoxColumn.Width = 40;
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "numDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            this.numDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numDocumentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // desMoneda
            // 
            this.desMoneda.DataPropertyName = "desMoneda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.desMoneda.DefaultCellStyle = dataGridViewCellStyle3;
            this.desMoneda.HeaderText = "Mon.";
            this.desMoneda.Name = "desMoneda";
            this.desMoneda.ReadOnly = true;
            this.desMoneda.Width = 40;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Saldo.HeaderText = "Total";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 90;
            // 
            // SaldoEquivalente
            // 
            this.SaldoEquivalente.DataPropertyName = "SaldoEquivalente";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.SaldoEquivalente.DefaultCellStyle = dataGridViewCellStyle5;
            this.SaldoEquivalente.HeaderText = "Monto Mov.";
            this.SaldoEquivalente.Name = "SaldoEquivalente";
            this.SaldoEquivalente.ReadOnly = true;
            this.SaldoEquivalente.Width = 90;
            // 
            // SaldoOperativo
            // 
            this.SaldoOperativo.DataPropertyName = "SaldoOperativo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.SaldoOperativo.DefaultCellStyle = dataGridViewCellStyle6;
            this.SaldoOperativo.HeaderText = "Neto";
            this.SaldoOperativo.Name = "SaldoOperativo";
            this.SaldoOperativo.ReadOnly = true;
            this.SaldoOperativo.Width = 90;
            // 
            // CuentaEquivalente
            // 
            this.CuentaEquivalente.DataPropertyName = "CuentaEquivalente";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CuentaEquivalente.DefaultCellStyle = dataGridViewCellStyle7;
            this.CuentaEquivalente.HeaderText = "Cta.Equiv.";
            this.CuentaEquivalente.Name = "CuentaEquivalente";
            this.CuentaEquivalente.Width = 65;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(793, 18);
            this.label8.TabIndex = 346;
            this.label8.Text = "Auxiliar";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPendientesVentasLetrasEquival
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 476);
            this.Controls.Add(this.lblTotaSol);
            this.Controls.Add(this.lblTotalDol);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPendientesVentasLetrasEquival";
            this.Text = "frmPendientesVentasLetrasEquival";
            this.Load += new System.EventHandler(this.frmPendientesVentasLetrasEquival_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(label2, 0);
            this.Controls.SetChildIndex(label3, 0);
            this.Controls.SetChildIndex(label4, 0);
            this.Controls.SetChildIndex(this.lblTotalDol, 0);
            this.Controls.SetChildIndex(this.lblTotaSol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtIdCliente;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.CheckBox chkTodos;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private MyLabelG.LabelDegradado lblTotaSol;
        private MyLabelG.LabelDegradado lblTotalDol;
        private System.Windows.Forms.DataGridView dgvDocumentosPendientes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desGlosaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoEquivalente;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoOperativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaEquivalente;
        private System.Windows.Forms.Label label8;
    }
}