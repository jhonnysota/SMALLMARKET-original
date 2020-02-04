namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteLibroDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteLibroDiario));
            this.btPle = new System.Windows.Forms.Button();
            this.pnlParametros = new System.Windows.Forms.Panel();
            this.cboPeriodoFin = new System.Windows.Forms.ComboBox();
            this.cboPeriodoIni = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.cboDiarioInicial = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDiarioFinal = new System.Windows.Forms.ComboBox();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cmsFormatos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmFormato1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFormato2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFormatoPle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDiario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSimplificado = new System.Windows.Forms.ToolStripMenuItem();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlParametros.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.cmsFormatos.SuspendLayout();
            this.cmsFormatoPle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btPle
            // 
            this.btPle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPle.Enabled = false;
            this.btPle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btPle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPle.Image = ((System.Drawing.Image)(resources.GetObject("btPle.Image")));
            this.btPle.Location = new System.Drawing.Point(1036, 22);
            this.btPle.Margin = new System.Windows.Forms.Padding(2);
            this.btPle.Name = "btPle";
            this.btPle.Size = new System.Drawing.Size(51, 48);
            this.btPle.TabIndex = 282;
            this.btPle.UseVisualStyleBackColor = false;
            this.btPle.Click += new System.EventHandler(this.btPle_Click);
            // 
            // pnlParametros
            // 
            this.pnlParametros.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlParametros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParametros.Controls.Add(this.cboAño);
            this.pnlParametros.Controls.Add(this.label7);
            this.pnlParametros.Controls.Add(this.cboPeriodoFin);
            this.pnlParametros.Controls.Add(this.cboPeriodoIni);
            this.pnlParametros.Controls.Add(this.label3);
            this.pnlParametros.Controls.Add(this.label2);
            this.pnlParametros.Controls.Add(this.cboSucursales);
            this.pnlParametros.Controls.Add(this.cboDiarioInicial);
            this.pnlParametros.Controls.Add(this.label5);
            this.pnlParametros.Controls.Add(this.label1);
            this.pnlParametros.Controls.Add(this.cboDiarioFinal);
            this.pnlParametros.Controls.Add(this.cboMonedas);
            this.pnlParametros.Controls.Add(this.lblDe);
            this.pnlParametros.Controls.Add(this.label4);
            this.pnlParametros.Controls.Add(this.labelDegradado1);
            this.pnlParametros.Location = new System.Drawing.Point(3, 3);
            this.pnlParametros.Name = "pnlParametros";
            this.pnlParametros.Size = new System.Drawing.Size(966, 76);
            this.pnlParametros.TabIndex = 281;
            // 
            // cboPeriodoFin
            // 
            this.cboPeriodoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoFin.FormattingEnabled = true;
            this.cboPeriodoFin.Location = new System.Drawing.Point(231, 45);
            this.cboPeriodoFin.Name = "cboPeriodoFin";
            this.cboPeriodoFin.Size = new System.Drawing.Size(119, 21);
            this.cboPeriodoFin.TabIndex = 316;
            // 
            // cboPeriodoIni
            // 
            this.cboPeriodoIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoIni.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoIni.FormattingEnabled = true;
            this.cboPeriodoIni.Location = new System.Drawing.Point(108, 45);
            this.cboPeriodoIni.Name = "cboPeriodoIni";
            this.cboPeriodoIni.Size = new System.Drawing.Size(119, 21);
            this.cboPeriodoIni.TabIndex = 315;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(646, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 314;
            this.label3.Text = "Diario Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Sucursal";
            // 
            // cboSucursales
            // 
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Location = new System.Drawing.Point(357, 45);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(154, 21);
            this.cboSucursales.TabIndex = 309;
            // 
            // cboDiarioInicial
            // 
            this.cboDiarioInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiarioInicial.DropDownWidth = 200;
            this.cboDiarioInicial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDiarioInicial.FormattingEnabled = true;
            this.cboDiarioInicial.Location = new System.Drawing.Point(642, 45);
            this.cboDiarioInicial.Name = "cboDiarioInicial";
            this.cboDiarioInicial.Size = new System.Drawing.Size(154, 21);
            this.cboDiarioInicial.TabIndex = 313;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(806, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 312;
            this.label5.Text = "Diario Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Moneda";
            // 
            // cboDiarioFinal
            // 
            this.cboDiarioFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiarioFinal.DropDownWidth = 200;
            this.cboDiarioFinal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDiarioFinal.FormattingEnabled = true;
            this.cboDiarioFinal.Location = new System.Drawing.Point(802, 45);
            this.cboDiarioFinal.Name = "cboDiarioFinal";
            this.cboDiarioFinal.Size = new System.Drawing.Size(154, 21);
            this.cboDiarioFinal.TabIndex = 311;
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(515, 45);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(119, 21);
            this.cboMonedas.TabIndex = 271;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(109, 30);
            this.lblDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(71, 13);
            this.lblDe.TabIndex = 306;
            this.lblDe.Text = "Periodo Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 307;
            this.label4.Text = "Periodo Fin";
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
            this.labelDegradado1.Size = new System.Drawing.Size(964, 20);
            this.labelDegradado1.TabIndex = 258;
            this.labelDegradado1.Text = "Parámetros";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(974, 22);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 48);
            this.btBuscar.TabIndex = 280;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblProcesando);
            this.panel3.Controls.Add(this.pbProgress);
            this.panel3.Controls.Add(this.wbNavegador);
            this.panel3.Location = new System.Drawing.Point(3, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1269, 374);
            this.panel3.TabIndex = 283;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.White;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(733, 375);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 19);
            this.lblProcesando.TabIndex = 325;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcesando.Visible = false;
            this.lblProcesando.SizeChanged += new System.EventHandler(this.lblProcesando_SizeChanged);
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.White;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(757, 256);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(113, 105);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 324;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1267, 372);
            this.wbNavegador.TabIndex = 268;
            // 
            // timer
            // 
            this.timer.Interval = 70;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cmsFormatos
            // 
            this.cmsFormatos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFormatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFormato1,
            this.tsmFormato2});
            this.cmsFormatos.Name = "cmsFormatos";
            this.cmsFormatos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsFormatos.Size = new System.Drawing.Size(205, 48);
            // 
            // tsmFormato1
            // 
            this.tsmFormato1.Image = global::ClienteWinForm.Properties.Resources.ver_documentos_16x16;
            this.tsmFormato1.Name = "tsmFormato1";
            this.tsmFormato1.Size = new System.Drawing.Size(204, 22);
            this.tsmFormato1.Text = "Libro Diario";
            this.tsmFormato1.Click += new System.EventHandler(this.tsmFormato1_Click);
            // 
            // tsmFormato2
            // 
            this.tsmFormato2.Image = global::ClienteWinForm.Properties.Resources.ver_documentos_16x16;
            this.tsmFormato2.Name = "tsmFormato2";
            this.tsmFormato2.Size = new System.Drawing.Size(204, 22);
            this.tsmFormato2.Text = "Libro Diario Simplificado";
            this.tsmFormato2.Click += new System.EventHandler(this.tsmFormato2_Click);
            // 
            // cmsFormatoPle
            // 
            this.cmsFormatoPle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFormatoPle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDiario,
            this.tsmiSimplificado});
            this.cmsFormatoPle.Name = "cmsFormatos";
            this.cmsFormatoPle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsFormatoPle.Size = new System.Drawing.Size(205, 48);
            // 
            // tsmiDiario
            // 
            this.tsmiDiario.Image = global::ClienteWinForm.Properties.Resources.ver_documentos_16x16;
            this.tsmiDiario.Name = "tsmiDiario";
            this.tsmiDiario.Size = new System.Drawing.Size(204, 22);
            this.tsmiDiario.Text = "Libro Diario";
            this.tsmiDiario.Click += new System.EventHandler(this.tsmiDiario_Click);
            // 
            // tsmiSimplificado
            // 
            this.tsmiSimplificado.Image = global::ClienteWinForm.Properties.Resources.ver_documentos_16x16;
            this.tsmiSimplificado.Name = "tsmiSimplificado";
            this.tsmiSimplificado.Size = new System.Drawing.Size(204, 22);
            this.tsmiSimplificado.Text = "Libro Diario Simplificado";
            this.tsmiSimplificado.Click += new System.EventHandler(this.tsmiSimplificado_Click);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(9, 45);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(93, 21);
            this.cboAño.TabIndex = 354;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 355;
            this.label7.Text = "Año";
            // 
            // frmReporteLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 459);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btPle);
            this.Controls.Add(this.pnlParametros);
            this.Controls.Add(this.btBuscar);
            this.MaximizeBox = false;
            this.Name = "frmReporteLibroDiario";
            this.Text = "Reporte Diario Auxiliar por Sucursal";
            this.Load += new System.EventHandler(this.frmReporteLibroDiario_Load);
            this.pnlParametros.ResumeLayout(false);
            this.pnlParametros.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.cmsFormatos.ResumeLayout(false);
            this.cmsFormatoPle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPle;
        private System.Windows.Forms.Panel pnlParametros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label label4;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDiarioInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDiarioFinal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cboPeriodoFin;
        private System.Windows.Forms.ComboBox cboPeriodoIni;
        private System.Windows.Forms.ContextMenuStrip cmsFormatos;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato1;
        private System.Windows.Forms.ToolStripMenuItem tsmFormato2;
        private System.Windows.Forms.ContextMenuStrip cmsFormatoPle;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiario;
        private System.Windows.Forms.ToolStripMenuItem tsmiSimplificado;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label7;
    }
}