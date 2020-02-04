namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteEEFFRatios
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
            this.pnl01 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboMesFinal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblProcesando = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDetalleGP = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.btReporte = new System.Windows.Forms.Button();
            this.cmsFormatos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRatios = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl01.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleGP)).BeginInit();
            this.cmsFormatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl01
            // 
            this.pnl01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl01.Controls.Add(this.label2);
            this.pnl01.Controls.Add(this.cboMoneda);
            this.pnl01.Controls.Add(this.cboMesFinal);
            this.pnl01.Controls.Add(this.label5);
            this.pnl01.Controls.Add(this.cboAnio);
            this.pnl01.Controls.Add(this.label4);
            this.pnl01.Controls.Add(this.labelDegradado2);
            this.pnl01.Location = new System.Drawing.Point(3, 3);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(459, 52);
            this.pnl01.TabIndex = 352;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 29);
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
            this.cboMoneda.Location = new System.Drawing.Point(348, 25);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(93, 21);
            this.cboMoneda.TabIndex = 363;
            // 
            // cboMesFinal
            // 
            this.cboMesFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesFinal.DropDownWidth = 110;
            this.cboMesFinal.Enabled = false;
            this.cboMesFinal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMesFinal.FormattingEnabled = true;
            this.cboMesFinal.Location = new System.Drawing.Point(200, 25);
            this.cboMesFinal.Margin = new System.Windows.Forms.Padding(2);
            this.cboMesFinal.Name = "cboMesFinal";
            this.cboMesFinal.Size = new System.Drawing.Size(93, 21);
            this.cboMesFinal.TabIndex = 362;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 29);
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
            this.cboAnio.Location = new System.Drawing.Point(45, 25);
            this.cboAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(93, 21);
            this.cboAnio.TabIndex = 360;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 359;
            this.label4.Text = "Mes Final ";
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(457, 19);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Parámetros de Búsqueda";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvDetalle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 414);
            this.panel2.TabIndex = 353;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(626, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 32);
            this.label6.TabIndex = 362;
            this.label6.Text = "ANALISIS HORIZONTAL";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(487, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 32);
            this.label3.TabIndex = 361;
            this.label3.Text = "ANALISIS\r\nVERTICAL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(1, 34);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalle.Size = new System.Drawing.Size(806, 374);
            this.dgvDetalle.TabIndex = 248;
            this.dgvDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalle_CellFormatting);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 32);
            this.label1.TabIndex = 360;
            this.label1.Text = "BALANCE GENERAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(544, 7);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(47, 44);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 354;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 80;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblProcesando.Location = new System.Drawing.Point(599, 22);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 18);
            this.lblProcesando.TabIndex = 355;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcesando.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dgvDetalleGP);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(673, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 414);
            this.panel1.TabIndex = 356;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(646, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 32);
            this.label7.TabIndex = 362;
            this.label7.Text = "ANALISIS HORIZONTAL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(507, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 32);
            this.label8.TabIndex = 361;
            this.label8.Text = "ANALISIS\r\nVERTICAL";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetalleGP
            // 
            this.dgvDetalleGP.AllowUserToAddRows = false;
            this.dgvDetalleGP.AllowUserToDeleteRows = false;
            this.dgvDetalleGP.AllowUserToResizeColumns = false;
            this.dgvDetalleGP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleGP.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvDetalleGP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleGP.EnableHeadersVisualStyles = false;
            this.dgvDetalleGP.Location = new System.Drawing.Point(1, 34);
            this.dgvDetalleGP.Name = "dgvDetalleGP";
            this.dgvDetalleGP.ReadOnly = true;
            this.dgvDetalleGP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleGP.Size = new System.Drawing.Size(1141, 357);
            this.dgvDetalleGP.TabIndex = 248;
            this.dgvDetalleGP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalleGP_CellFormatting);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(1, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(505, 32);
            this.label9.TabIndex = 360;
            this.label9.Text = "ESTADO DE GANANCIAS Y PERDIDAS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btReporte
            // 
            this.btReporte.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btReporte.Enabled = false;
            this.btReporte.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReporte.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReporte.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btReporte.Location = new System.Drawing.Point(467, 6);
            this.btReporte.Margin = new System.Windows.Forms.Padding(2);
            this.btReporte.Name = "btReporte";
            this.btReporte.Size = new System.Drawing.Size(51, 48);
            this.btReporte.TabIndex = 357;
            this.btReporte.UseVisualStyleBackColor = false;
            this.btReporte.Click += new System.EventHandler(this.btReporte_Click);
            // 
            // cmsFormatos
            // 
            this.cmsFormatos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsFormatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVertical,
            this.tsmiHorizontal,
            this.tsmiRatios});
            this.cmsFormatos.Name = "cmsFormatos";
            this.cmsFormatos.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsFormatos.Size = new System.Drawing.Size(173, 92);
            // 
            // tsmiVertical
            // 
            this.tsmiVertical.Name = "tsmiVertical";
            this.tsmiVertical.Size = new System.Drawing.Size(172, 22);
            this.tsmiVertical.Text = "Análisis Vertical";
            this.tsmiVertical.Click += new System.EventHandler(this.tsmiVertical_Click);
            // 
            // tsmiHorizontal
            // 
            this.tsmiHorizontal.Name = "tsmiHorizontal";
            this.tsmiHorizontal.Size = new System.Drawing.Size(172, 22);
            this.tsmiHorizontal.Text = "Análisis Horizontal";
            this.tsmiHorizontal.Click += new System.EventHandler(this.tsmiHorizontal_Click);
            // 
            // tsmiRatios
            // 
            this.tsmiRatios.Name = "tsmiRatios";
            this.tsmiRatios.Size = new System.Drawing.Size(172, 22);
            this.tsmiRatios.Text = "Ratios";
            this.tsmiRatios.Click += new System.EventHandler(this.tsmiRatios_Click);
            // 
            // frmReporteEEFFRatios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 473);
            this.Controls.Add(this.btReporte);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl01);
            this.MaximizeBox = false;
            this.Name = "frmReporteEEFFRatios";
            this.Text = "Estados Financieros -  Ratios";
            this.Load += new System.EventHandler(this.frmReporteEEFFRatios_Load);
            this.pnl01.ResumeLayout(false);
            this.pnl01.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleGP)).EndInit();
            this.cmsFormatos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.ComboBox cboMesFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label label4;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDetalleGP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btReporte;
        private System.Windows.Forms.ContextMenuStrip cmsFormatos;
        private System.Windows.Forms.ToolStripMenuItem tsmiVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmiHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmiRatios;
    }
}