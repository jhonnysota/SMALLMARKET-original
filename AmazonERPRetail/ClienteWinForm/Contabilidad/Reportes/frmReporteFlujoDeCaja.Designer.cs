namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteFlujoDeCaja
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
            this.dgvPivot = new MyDataGridViewAgrupado.DataGridViewAgrupado();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.lblregistros = new MyLabelG.LabelDegradado();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnl01 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.pnl01.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvPivot);
            this.panel2.Controls.Add(this.pbProgress);
            this.panel2.Controls.Add(this.lblregistros);
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1212, 402);
            this.panel2.TabIndex = 297;
            // 
            // dgvPivot
            // 
            this.dgvPivot.AllowUserToAddRows = false;
            this.dgvPivot.AllowUserToDeleteRows = false;
            this.dgvPivot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPivot.EnableHeadersVisualStyles = false;
            this.dgvPivot.GrupoColumnas = null;
            this.dgvPivot.Location = new System.Drawing.Point(0, 23);
            this.dgvPivot.Name = "dgvPivot";
            this.dgvPivot.ReadOnly = true;
            this.dgvPivot.Size = new System.Drawing.Size(1210, 377);
            this.dgvPivot.TabIndex = 348;
            this.dgvPivot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPivot_CellDoubleClick_1);
            this.dgvPivot.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPivot_CellFormatting);
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.BackColor = System.Drawing.Color.SlateGray;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(1021, 2);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(22, 19);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 347;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
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
            this.lblregistros.Size = new System.Drawing.Size(1210, 23);
            this.lblregistros.TabIndex = 249;
            this.lblregistros.Text = "registros";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmsMenu
            // 
            this.cmsMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExcel});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(156, 26);
            // 
            // tsmiExcel
            // 
            this.tsmiExcel.Image = global::ClienteWinForm.Properties.Resources.Excel_Chico;
            this.tsmiExcel.Name = "tsmiExcel";
            this.tsmiExcel.Size = new System.Drawing.Size(155, 22);
            this.tsmiExcel.Text = "Exportar a Excel";
            this.tsmiExcel.Click += new System.EventHandler(this.tsmiExcel_Click);
            // 
            // pnl01
            // 
            this.pnl01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl01.Controls.Add(this.label3);
            this.pnl01.Controls.Add(this.label2);
            this.pnl01.Controls.Add(this.label1);
            this.pnl01.Controls.Add(this.dtpFechaFin);
            this.pnl01.Controls.Add(this.dtpFechaInicio);
            this.pnl01.Controls.Add(this.cboSucursal);
            this.pnl01.Controls.Add(this.labelDegradado2);
            this.pnl01.Location = new System.Drawing.Point(0, 4);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(547, 52);
            this.pnl01.TabIndex = 351;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 259;
            this.label3.Text = "Fecha Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 257;
            this.label1.Text = "Sucursal";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(426, 24);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaFin.TabIndex = 256;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(257, 25);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaInicio.TabIndex = 255;
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(57, 24);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(125, 21);
            this.cboSucursal.TabIndex = 254;
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
            this.labelDegradado2.Size = new System.Drawing.Size(545, 21);
            this.labelDegradado2.TabIndex = 253;
            this.labelDegradado2.Text = "Parametros";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReporteFlujoDeCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 469);
            this.Controls.Add(this.pnl01);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmReporteFlujoDeCaja";
            this.Text = "Flujo De Caja";
            this.Load += new System.EventHandler(this.frmReporteEEFFGananciasPerdidasMeses_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.pnl01.ResumeLayout(false);
            this.pnl01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado lblregistros;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.Panel pnl01;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcel;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MyDataGridViewAgrupado.DataGridViewAgrupado dgvPivot;
    }
}