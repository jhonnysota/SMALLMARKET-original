namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteConceptoGasto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboInicio = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFin = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPivot = new System.Windows.Forms.DataGridView();
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboMon);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboInicio);
            this.panel1.Controls.Add(this.cboAño);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboFin);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 61);
            this.panel1.TabIndex = 290;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 322;
            this.label3.Text = "Moneda";
            // 
            // cboMon
            // 
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(169, 29);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(125, 21);
            this.cboMon.TabIndex = 321;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "Mes Inicio";
            // 
            // cboInicio
            // 
            this.cboInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInicio.FormattingEnabled = true;
            this.cboInicio.Location = new System.Drawing.Point(359, 29);
            this.cboInicio.Name = "cboInicio";
            this.cboInicio.Size = new System.Drawing.Size(88, 21);
            this.cboInicio.TabIndex = 318;
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(49, 28);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(64, 21);
            this.cboAño.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Mes Final";
            // 
            // cboFin
            // 
            this.cboFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFin.FormattingEnabled = true;
            this.cboFin.Location = new System.Drawing.Point(527, 27);
            this.cboFin.Name = "cboFin";
            this.cboFin.Size = new System.Drawing.Size(86, 21);
            this.cboFin.TabIndex = 271;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
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
            this.labelDegradado1.Size = new System.Drawing.Size(632, 20);
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
            this.btBuscar.Location = new System.Drawing.Point(693, 11);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(59, 47);
            this.btBuscar.TabIndex = 289;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvPivot);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(2, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 454);
            this.panel2.TabIndex = 298;
            // 
            // dgvPivot
            // 
            this.dgvPivot.AllowUserToAddRows = false;
            this.dgvPivot.AllowUserToDeleteRows = false;
            this.dgvPivot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPivot.EnableHeadersVisualStyles = false;
            this.dgvPivot.Location = new System.Drawing.Point(0, 23);
            this.dgvPivot.Name = "dgvPivot";
            this.dgvPivot.ReadOnly = true;
            this.dgvPivot.Size = new System.Drawing.Size(1020, 429);
            this.dgvPivot.TabIndex = 248;
            this.dgvPivot.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPivot_CellContentClick);
            this.dgvPivot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPivot_CellDoubleClick);
            this.dgvPivot.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPivot_CellFormatting);
            // 
            // lblregistros
            // 
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.ForeColor = System.Drawing.Color.White;
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblregistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblregistros.Size = new System.Drawing.Size(1020, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "registros";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(770, 18);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(43, 36);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 347;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // frmReporteConceptoGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 525);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btBuscar);
            this.Name = "frmReporteConceptoGasto";
            this.Text = "Reporte Concepto Gasto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteConceptoGasto_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteConceptoGasto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboInicio;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFin;
        protected internal System.Windows.Forms.Button button1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPivot;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.PictureBox pbProgress;
    }
}