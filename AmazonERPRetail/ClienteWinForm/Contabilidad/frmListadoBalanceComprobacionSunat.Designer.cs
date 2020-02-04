namespace ClienteWinForm.Contabilidad
{
    partial class frmListadoBalanceComprobacionSunat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoBalanceComprobacionSunat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.bsBalanceComprobacionSunat = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btPle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.codCuentaSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoInicialDebeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoInicialHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movimientoDebeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movimientoHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumasMayorDebeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumasMayorHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoDebeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transCancDebeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transCancHaberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceActivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balancePasivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adicionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deduccionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalanceComprobacionSunat)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDocumentos);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 318);
            this.panel1.TabIndex = 258;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AutoGenerateColumns = false;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuentaSunat,
            this.Descripcion,
            this.saldoInicialDebeDataGridViewTextBoxColumn,
            this.saldoInicialHaberDataGridViewTextBoxColumn,
            this.movimientoDebeDataGridViewTextBoxColumn,
            this.movimientoHaberDataGridViewTextBoxColumn,
            this.sumasMayorDebeDataGridViewTextBoxColumn,
            this.sumasMayorHaberDataGridViewTextBoxColumn,
            this.saldoDebeDataGridViewTextBoxColumn,
            this.saldoHaberDataGridViewTextBoxColumn,
            this.transCancDebeDataGridViewTextBoxColumn,
            this.transCancHaberDataGridViewTextBoxColumn,
            this.balanceActivoDataGridViewTextBoxColumn,
            this.balancePasivoDataGridViewTextBoxColumn,
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn,
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn,
            this.adicionesDataGridViewTextBoxColumn,
            this.deduccionesDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvDocumentos.DataSource = this.bsBalanceComprobacionSunat;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 23);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.Size = new System.Drawing.Size(1020, 293);
            this.dgvDocumentos.TabIndex = 248;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocumentos_CellFormatting);
            // 
            // bsBalanceComprobacionSunat
            // 
            this.bsBalanceComprobacionSunat.DataSource = typeof(Entidades.Contabilidad.BalanceComprobacionSunatE);
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
            this.lblRegistros.Size = new System.Drawing.Size(1020, 23);
            this.lblRegistros.TabIndex = 250;
            this.lblRegistros.Text = "Balance Comprobacion - Registro";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btPle);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.cboAño);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelDegradado4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboMes);
            this.panel2.Location = new System.Drawing.Point(4, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 87);
            this.panel2.TabIndex = 318;
            // 
            // btPle
            // 
            this.btPle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btPle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPle.Image = ((System.Drawing.Image)(resources.GetObject("btPle.Image")));
            this.btPle.Location = new System.Drawing.Point(395, 23);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 59);
            this.btPle.TabIndex = 332;
            this.btPle.TabStop = false;
            this.btPle.UseVisualStyleBackColor = false;
            this.btPle.Click += new System.EventHandler(this.btPle_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(212, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 59);
            this.button3.TabIndex = 154;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(49, 27);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(64, 21);
            this.cboAño.TabIndex = 315;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 316;
            this.label4.Text = "Año";
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(464, 20);
            this.labelDegradado4.TabIndex = 258;
            this.labelDegradado4.Text = "Parametros";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 314;
            this.label1.Text = "Mes";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Enabled = false;
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(49, 55);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(148, 21);
            this.cboMes.TabIndex = 313;
            // 
            // codCuentaSunat
            // 
            this.codCuentaSunat.DataPropertyName = "codCuentaSunat";
            this.codCuentaSunat.Frozen = true;
            this.codCuentaSunat.HeaderText = "Cuenta";
            this.codCuentaSunat.Name = "codCuentaSunat";
            this.codCuentaSunat.ReadOnly = true;
            this.codCuentaSunat.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.Frozen = true;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // saldoInicialDebeDataGridViewTextBoxColumn
            // 
            this.saldoInicialDebeDataGridViewTextBoxColumn.DataPropertyName = "SaldoInicialDebe";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.saldoInicialDebeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.saldoInicialDebeDataGridViewTextBoxColumn.HeaderText = "Saldo Inicial Debe";
            this.saldoInicialDebeDataGridViewTextBoxColumn.Name = "saldoInicialDebeDataGridViewTextBoxColumn";
            this.saldoInicialDebeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoInicialHaberDataGridViewTextBoxColumn
            // 
            this.saldoInicialHaberDataGridViewTextBoxColumn.DataPropertyName = "SaldoInicialHaber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.saldoInicialHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.saldoInicialHaberDataGridViewTextBoxColumn.HeaderText = "Saldo Inicial Haber";
            this.saldoInicialHaberDataGridViewTextBoxColumn.Name = "saldoInicialHaberDataGridViewTextBoxColumn";
            this.saldoInicialHaberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // movimientoDebeDataGridViewTextBoxColumn
            // 
            this.movimientoDebeDataGridViewTextBoxColumn.DataPropertyName = "MovimientoDebe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.movimientoDebeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.movimientoDebeDataGridViewTextBoxColumn.HeaderText = "Movimiento Debe";
            this.movimientoDebeDataGridViewTextBoxColumn.Name = "movimientoDebeDataGridViewTextBoxColumn";
            this.movimientoDebeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // movimientoHaberDataGridViewTextBoxColumn
            // 
            this.movimientoHaberDataGridViewTextBoxColumn.DataPropertyName = "MovimientoHaber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.movimientoHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.movimientoHaberDataGridViewTextBoxColumn.HeaderText = "Movimiento Haber";
            this.movimientoHaberDataGridViewTextBoxColumn.Name = "movimientoHaberDataGridViewTextBoxColumn";
            this.movimientoHaberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumasMayorDebeDataGridViewTextBoxColumn
            // 
            this.sumasMayorDebeDataGridViewTextBoxColumn.DataPropertyName = "SumasMayorDebe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.sumasMayorDebeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.sumasMayorDebeDataGridViewTextBoxColumn.HeaderText = "Sumas Mayor Debe";
            this.sumasMayorDebeDataGridViewTextBoxColumn.Name = "sumasMayorDebeDataGridViewTextBoxColumn";
            this.sumasMayorDebeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumasMayorHaberDataGridViewTextBoxColumn
            // 
            this.sumasMayorHaberDataGridViewTextBoxColumn.DataPropertyName = "SumasMayorHaber";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.sumasMayorHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.sumasMayorHaberDataGridViewTextBoxColumn.HeaderText = "Sumas Mayor Haber";
            this.sumasMayorHaberDataGridViewTextBoxColumn.Name = "sumasMayorHaberDataGridViewTextBoxColumn";
            this.sumasMayorHaberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoDebeDataGridViewTextBoxColumn
            // 
            this.saldoDebeDataGridViewTextBoxColumn.DataPropertyName = "SaldoDebe";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.saldoDebeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.saldoDebeDataGridViewTextBoxColumn.HeaderText = "Saldo Debe";
            this.saldoDebeDataGridViewTextBoxColumn.Name = "saldoDebeDataGridViewTextBoxColumn";
            this.saldoDebeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoHaberDataGridViewTextBoxColumn
            // 
            this.saldoHaberDataGridViewTextBoxColumn.DataPropertyName = "SaldoHaber";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.saldoHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.saldoHaberDataGridViewTextBoxColumn.HeaderText = "Saldo Haber";
            this.saldoHaberDataGridViewTextBoxColumn.Name = "saldoHaberDataGridViewTextBoxColumn";
            this.saldoHaberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transCancDebeDataGridViewTextBoxColumn
            // 
            this.transCancDebeDataGridViewTextBoxColumn.DataPropertyName = "TransCancDebe";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.transCancDebeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.transCancDebeDataGridViewTextBoxColumn.HeaderText = "Transferencia y Cancelacion Debe";
            this.transCancDebeDataGridViewTextBoxColumn.Name = "transCancDebeDataGridViewTextBoxColumn";
            this.transCancDebeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transCancHaberDataGridViewTextBoxColumn
            // 
            this.transCancHaberDataGridViewTextBoxColumn.DataPropertyName = "TransCancHaber";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.transCancHaberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.transCancHaberDataGridViewTextBoxColumn.HeaderText = "Transferencia y Cancelacion Haber";
            this.transCancHaberDataGridViewTextBoxColumn.Name = "transCancHaberDataGridViewTextBoxColumn";
            this.transCancHaberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // balanceActivoDataGridViewTextBoxColumn
            // 
            this.balanceActivoDataGridViewTextBoxColumn.DataPropertyName = "BalanceActivo";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.balanceActivoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.balanceActivoDataGridViewTextBoxColumn.HeaderText = "Cuenta de Balance Activo";
            this.balanceActivoDataGridViewTextBoxColumn.Name = "balanceActivoDataGridViewTextBoxColumn";
            this.balanceActivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // balancePasivoDataGridViewTextBoxColumn
            // 
            this.balancePasivoDataGridViewTextBoxColumn.DataPropertyName = "BalancePasivo";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.balancePasivoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.balancePasivoDataGridViewTextBoxColumn.HeaderText = "Cuenta de Balance Pasivo";
            this.balancePasivoDataGridViewTextBoxColumn.Name = "balancePasivoDataGridViewTextBoxColumn";
            this.balancePasivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rPNaturalezaPerdidaDataGridViewTextBoxColumn
            // 
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn.DataPropertyName = "RPNaturalezaPerdida";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn.HeaderText = "Resultado x Naturaleza Perdida";
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn.Name = "rPNaturalezaPerdidaDataGridViewTextBoxColumn";
            this.rPNaturalezaPerdidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rPNaturalezaGananciaDataGridViewTextBoxColumn
            // 
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn.DataPropertyName = "RPNaturalezaGanancia";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn.HeaderText = "Resultado x Naturaleza Ganancia";
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn.Name = "rPNaturalezaGananciaDataGridViewTextBoxColumn";
            this.rPNaturalezaGananciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adicionesDataGridViewTextBoxColumn
            // 
            this.adicionesDataGridViewTextBoxColumn.DataPropertyName = "Adiciones";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.adicionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.adicionesDataGridViewTextBoxColumn.HeaderText = "Adiciones";
            this.adicionesDataGridViewTextBoxColumn.Name = "adicionesDataGridViewTextBoxColumn";
            this.adicionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deduccionesDataGridViewTextBoxColumn
            // 
            this.deduccionesDataGridViewTextBoxColumn.DataPropertyName = "Deducciones";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            this.deduccionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.deduccionesDataGridViewTextBoxColumn.HeaderText = "Deducciones";
            this.deduccionesDataGridViewTextBoxColumn.Name = "deduccionesDataGridViewTextBoxColumn";
            this.deduccionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 30;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Registro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Registro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 150;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Modificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Modificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 150;
            // 
            // frmListadoBalanceComprobacionSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 409);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoBalanceComprobacionSunat";
            this.Text = "Listado Balance Comprobacion Sunat";
            this.Load += new System.EventHandler(this.frmListadoBalanceComprobacionSunat_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalanceComprobacionSunat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.BindingSource bsBalanceComprobacionSunat;
        private System.Windows.Forms.Panel panel2;
        protected internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoInicialDebeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoInicialHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movimientoDebeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movimientoHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumasMayorDebeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumasMayorHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoDebeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transCancDebeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transCancHaberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceActivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balancePasivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPNaturalezaPerdidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPNaturalezaGananciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adicionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deduccionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}