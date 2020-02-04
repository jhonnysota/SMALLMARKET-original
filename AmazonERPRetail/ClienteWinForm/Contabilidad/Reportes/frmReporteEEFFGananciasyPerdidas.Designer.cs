namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteEEFFGananciasyPerdidas
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbTipoReporteCCostos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTipoReporteMes = new System.Windows.Forms.RadioButton();
            this.cboEEFF = new System.Windows.Forms.ComboBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnl01 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.chbtipo_cambio = new System.Windows.Forms.CheckBox();
            this.txttipocambio = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboMesFinal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbAcumulado = new System.Windows.Forms.CheckBox();
            this.pnlCCostos = new System.Windows.Forms.Panel();
            this.lnkTodos = new System.Windows.Forms.LinkLabel();
            this.chbListaCCostos = new System.Windows.Forms.CheckedListBox();
            this.chbindCCostos = new System.Windows.Forms.CheckBox();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.lblprogress = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.pnl01.SuspendLayout();
            this.pnlCCostos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdbTipoReporteCCostos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rdbTipoReporteMes);
            this.panel2.Controls.Add(this.cboEEFF);
            this.panel2.Controls.Add(this.labelDegradado1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 94);
            this.panel2.TabIndex = 349;
            // 
            // rdbTipoReporteCCostos
            // 
            this.rdbTipoReporteCCostos.AutoSize = true;
            this.rdbTipoReporteCCostos.Location = new System.Drawing.Point(212, 63);
            this.rdbTipoReporteCCostos.Name = "rdbTipoReporteCCostos";
            this.rdbTipoReporteCCostos.Size = new System.Drawing.Size(125, 17);
            this.rdbTipoReporteCCostos.TabIndex = 350;
            this.rdbTipoReporteCCostos.Text = "Por Centro de Costos";
            this.rdbTipoReporteCCostos.UseVisualStyleBackColor = true;
            this.rdbTipoReporteCCostos.CheckedChanged += new System.EventHandler(this.rdbTipoReporteCCostos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 267;
            this.label1.Text = "Reporte";
            // 
            // rdbTipoReporteMes
            // 
            this.rdbTipoReporteMes.AutoSize = true;
            this.rdbTipoReporteMes.Checked = true;
            this.rdbTipoReporteMes.Location = new System.Drawing.Point(105, 63);
            this.rdbTipoReporteMes.Name = "rdbTipoReporteMes";
            this.rdbTipoReporteMes.Size = new System.Drawing.Size(75, 17);
            this.rdbTipoReporteMes.TabIndex = 254;
            this.rdbTipoReporteMes.TabStop = true;
            this.rdbTipoReporteMes.Text = "Por Meses";
            this.rdbTipoReporteMes.UseVisualStyleBackColor = true;
            // 
            // cboEEFF
            // 
            this.cboEEFF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEEFF.DropDownWidth = 110;
            this.cboEEFF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEEFF.FormattingEnabled = true;
            this.cboEEFF.Location = new System.Drawing.Point(60, 29);
            this.cboEEFF.Margin = new System.Windows.Forms.Padding(2);
            this.cboEEFF.Name = "cboEEFF";
            this.cboEEFF.Size = new System.Drawing.Size(345, 21);
            this.cboEEFF.TabIndex = 2;
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
            this.labelDegradado1.Size = new System.Drawing.Size(420, 21);
            this.labelDegradado1.TabIndex = 253;
            this.labelDegradado1.Text = "Informe";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl01
            // 
            this.pnl01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl01.Controls.Add(this.label3);
            this.pnl01.Controls.Add(this.cboNivel);
            this.pnl01.Controls.Add(this.chbtipo_cambio);
            this.pnl01.Controls.Add(this.txttipocambio);
            this.pnl01.Controls.Add(this.label2);
            this.pnl01.Controls.Add(this.cboMoneda);
            this.pnl01.Controls.Add(this.cboMesFinal);
            this.pnl01.Controls.Add(this.label5);
            this.pnl01.Controls.Add(this.cboAnio);
            this.pnl01.Controls.Add(this.label4);
            this.pnl01.Controls.Add(this.chbAcumulado);
            this.pnl01.Controls.Add(this.pnlCCostos);
            this.pnl01.Controls.Add(this.labelDegradado2);
            this.pnl01.Location = new System.Drawing.Point(4, 101);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(422, 199);
            this.pnl01.TabIndex = 350;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 368;
            this.label3.Text = "Nivel C.C.";
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.DropDownWidth = 110;
            this.cboNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(243, 27);
            this.cboNivel.Margin = new System.Windows.Forms.Padding(2);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(93, 21);
            this.cboNivel.TabIndex = 367;
            this.cboNivel.SelectionChangeCommitted += new System.EventHandler(this.cboNivel_SelectionChangeCommitted);
            // 
            // chbtipo_cambio
            // 
            this.chbtipo_cambio.AutoSize = true;
            this.chbtipo_cambio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbtipo_cambio.Location = new System.Drawing.Point(47, 98);
            this.chbtipo_cambio.Name = "chbtipo_cambio";
            this.chbtipo_cambio.Size = new System.Drawing.Size(46, 17);
            this.chbtipo_cambio.TabIndex = 366;
            this.chbtipo_cambio.Text = "T.C.";
            this.chbtipo_cambio.UseVisualStyleBackColor = true;
            this.chbtipo_cambio.CheckedChanged += new System.EventHandler(this.chbtipo_cambio_CheckedChanged);
            // 
            // txttipocambio
            // 
            this.txttipocambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txttipocambio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txttipocambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txttipocambio.Enabled = false;
            this.txttipocambio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttipocambio.Location = new System.Drawing.Point(99, 95);
            this.txttipocambio.Margin = new System.Windows.Forms.Padding(2);
            this.txttipocambio.MaxLength = 6;
            this.txttipocambio.Name = "txttipocambio";
            this.txttipocambio.Size = new System.Drawing.Size(72, 20);
            this.txttipocambio.TabIndex = 365;
            this.txttipocambio.Text = "0.000";
            this.txttipocambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttipocambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txttipocambio.TextoVacio = "<Descripcion>";
            this.txttipocambio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txttipocambio_MouseClick);
            this.txttipocambio.Enter += new System.EventHandler(this.txttipocambio_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 364;
            this.label2.Text = "Moneda ";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.DropDownWidth = 110;
            this.cboMoneda.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(78, 73);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(93, 21);
            this.cboMoneda.TabIndex = 363;
            // 
            // cboMesFinal
            // 
            this.cboMesFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesFinal.DropDownWidth = 110;
            this.cboMesFinal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMesFinal.FormattingEnabled = true;
            this.cboMesFinal.Location = new System.Drawing.Point(78, 50);
            this.cboMesFinal.Margin = new System.Windows.Forms.Padding(2);
            this.cboMesFinal.Name = "cboMesFinal";
            this.cboMesFinal.Size = new System.Drawing.Size(93, 21);
            this.cboMesFinal.TabIndex = 362;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 361;
            this.label5.Text = "Año ";
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.DropDownWidth = 110;
            this.cboAnio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(78, 27);
            this.cboAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(93, 21);
            this.cboAnio.TabIndex = 360;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 359;
            this.label4.Text = "Mes Final ";
            // 
            // chbAcumulado
            // 
            this.chbAcumulado.AutoSize = true;
            this.chbAcumulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbAcumulado.Checked = true;
            this.chbAcumulado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAcumulado.Location = new System.Drawing.Point(14, 117);
            this.chbAcumulado.Name = "chbAcumulado";
            this.chbAcumulado.Size = new System.Drawing.Size(79, 17);
            this.chbAcumulado.TabIndex = 356;
            this.chbAcumulado.Text = "Acumulado";
            this.chbAcumulado.UseVisualStyleBackColor = true;
            this.chbAcumulado.Visible = false;
            // 
            // pnlCCostos
            // 
            this.pnlCCostos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCCostos.Controls.Add(this.lnkTodos);
            this.pnlCCostos.Controls.Add(this.chbListaCCostos);
            this.pnlCCostos.Controls.Add(this.chbindCCostos);
            this.pnlCCostos.Controls.Add(this.labelDegradado4);
            this.pnlCCostos.Location = new System.Drawing.Point(187, 51);
            this.pnlCCostos.Name = "pnlCCostos";
            this.pnlCCostos.Size = new System.Drawing.Size(226, 141);
            this.pnlCCostos.TabIndex = 355;
            // 
            // lnkTodos
            // 
            this.lnkTodos.AutoSize = true;
            this.lnkTodos.Enabled = false;
            this.lnkTodos.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lnkTodos.Location = new System.Drawing.Point(179, 3);
            this.lnkTodos.Name = "lnkTodos";
            this.lnkTodos.Size = new System.Drawing.Size(37, 13);
            this.lnkTodos.TabIndex = 262;
            this.lnkTodos.TabStop = true;
            this.lnkTodos.Text = "Todos";
            this.lnkTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTodos_LinkClicked);
            // 
            // chbListaCCostos
            // 
            this.chbListaCCostos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chbListaCCostos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chbListaCCostos.CheckOnClick = true;
            this.chbListaCCostos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbListaCCostos.Enabled = false;
            this.chbListaCCostos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbListaCCostos.FormattingEnabled = true;
            this.chbListaCCostos.Items.AddRange(new object[] {
            ""});
            this.chbListaCCostos.Location = new System.Drawing.Point(0, 21);
            this.chbListaCCostos.Name = "chbListaCCostos";
            this.chbListaCCostos.Size = new System.Drawing.Size(224, 118);
            this.chbListaCCostos.TabIndex = 261;
            // 
            // chbindCCostos
            // 
            this.chbindCCostos.AutoSize = true;
            this.chbindCCostos.BackColor = System.Drawing.Color.SlateGray;
            this.chbindCCostos.Location = new System.Drawing.Point(120, 3);
            this.chbindCCostos.Name = "chbindCCostos";
            this.chbindCCostos.Size = new System.Drawing.Size(15, 14);
            this.chbindCCostos.TabIndex = 254;
            this.chbindCCostos.UseVisualStyleBackColor = false;
            this.chbindCCostos.CheckedChanged += new System.EventHandler(this.chbindCCostos_CheckedChanged);
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
            this.labelDegradado4.Size = new System.Drawing.Size(224, 21);
            this.labelDegradado4.TabIndex = 253;
            this.labelDegradado4.Text = "Centro de Costos";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(420, 21);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Parametros";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(4, 303);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(30, 29);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 353;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(37, 311);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(0, 13);
            this.lblprogress.TabIndex = 354;
            // 
            // timer
            // 
            this.timer.Interval = 80;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.btCancelar.Location = new System.Drawing.Point(329, 307);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(93, 23);
            this.btCancelar.TabIndex = 356;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btAceptar.Location = new System.Drawing.Point(232, 307);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(93, 23);
            this.btAceptar.TabIndex = 355;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // frmReporteEEFFGananciasyPerdidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 335);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.lblprogress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl01);
            this.MaximizeBox = false;
            this.Name = "frmReporteEEFFGananciasyPerdidas";
            this.Text = "Estados Financieros - Ganancias y Perdidas";
            this.Load += new System.EventHandler(this.frmReporteEEFFGanaciasPerdidas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl01.ResumeLayout(false);
            this.pnl01.PerformLayout();
            this.pnlCCostos.ResumeLayout(false);
            this.pnlCCostos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl01;
        private System.Windows.Forms.RadioButton rdbTipoReporteCCostos;
        private System.Windows.Forms.RadioButton rdbTipoReporteMes;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEEFF;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCCostos;
        private System.Windows.Forms.CheckBox chbindCCostos;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.CheckedListBox chbListaCCostos;
        private System.Windows.Forms.CheckBox chbAcumulado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.ComboBox cboMesFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.LinkLabel lnkTodos;
        private System.Windows.Forms.CheckBox chbtipo_cambio;
        private ControlesWinForm.SuperTextBox txttipocambio;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.Timer timer;
        protected internal System.Windows.Forms.Button btCancelar;
        protected internal System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNivel;
    }
}