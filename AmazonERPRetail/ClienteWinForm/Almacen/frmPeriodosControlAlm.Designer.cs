namespace ClienteWinForm.Almacen
{
    partial class frmPeriodosControlAlm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPeriodo = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.BtGenerar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlGeneracion = new System.Windows.Forms.Panel();
            this.cboAnios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLetras = new System.Windows.Forms.Label();
            this.bsPeriodo = new System.Windows.Forms.BindingSource(this.components);
            this.desPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indAperturaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indCierre = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodo)).BeginInit();
            this.PnlGeneracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPeriodo);
            this.panel1.Controls.Add(this.lblRegistros);
            this.panel1.Location = new System.Drawing.Point(4, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 370);
            this.panel1.TabIndex = 258;
            // 
            // dgvPeriodo
            // 
            this.dgvPeriodo.AllowUserToAddRows = false;
            this.dgvPeriodo.AllowUserToDeleteRows = false;
            this.dgvPeriodo.AutoGenerateColumns = false;
            this.dgvPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desPeriodo,
            this.fecInicio,
            this.fecFinal,
            this.indAperturaDataGridViewCheckBoxColumn,
            this.indCierre});
            this.dgvPeriodo.DataSource = this.bsPeriodo;
            this.dgvPeriodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeriodo.EnableHeadersVisualStyles = false;
            this.dgvPeriodo.Location = new System.Drawing.Point(0, 18);
            this.dgvPeriodo.Name = "dgvPeriodo";
            this.dgvPeriodo.Size = new System.Drawing.Size(595, 350);
            this.dgvPeriodo.TabIndex = 248;
            this.dgvPeriodo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPeriodo_CellFormatting);
            this.dgvPeriodo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodo_CellValueChanged);
            this.dgvPeriodo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPeriodo_CurrentCellDirtyStateChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(595, 18);
            this.lblRegistros.TabIndex = 1580;
            this.lblRegistros.Text = "Registro 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtGenerar
            // 
            this.BtGenerar.Enabled = false;
            this.BtGenerar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGenerar.Location = new System.Drawing.Point(125, 21);
            this.BtGenerar.Name = "BtGenerar";
            this.BtGenerar.Size = new System.Drawing.Size(149, 23);
            this.BtGenerar.TabIndex = 259;
            this.BtGenerar.Text = "Generar Periodo Almacén";
            this.BtGenerar.UseVisualStyleBackColor = true;
            this.BtGenerar.Click += new System.EventHandler(this.BtGenerar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "desPeriodo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Periodo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // PnlGeneracion
            // 
            this.PnlGeneracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlGeneracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlGeneracion.Controls.Add(this.cboAnios);
            this.PnlGeneracion.Controls.Add(this.label4);
            this.PnlGeneracion.Controls.Add(this.lblLetras);
            this.PnlGeneracion.Controls.Add(this.BtGenerar);
            this.PnlGeneracion.Location = new System.Drawing.Point(4, 4);
            this.PnlGeneracion.Name = "PnlGeneracion";
            this.PnlGeneracion.Size = new System.Drawing.Size(597, 49);
            this.PnlGeneracion.TabIndex = 356;
            // 
            // cboAnios
            // 
            this.cboAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnios.FormattingEnabled = true;
            this.cboAnios.Location = new System.Drawing.Point(50, 22);
            this.cboAnios.Name = "cboAnios";
            this.cboAnios.Size = new System.Drawing.Size(65, 21);
            this.cboAnios.TabIndex = 1582;
            this.cboAnios.SelectionChangeCommitted += new System.EventHandler(this.cboAnios_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 1581;
            this.label4.Text = "Año";
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(595, 18);
            this.lblLetras.TabIndex = 1580;
            this.lblLetras.Text = "Generar";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bsPeriodo
            // 
            this.bsPeriodo.DataSource = typeof(Entidades.Contabilidad.PeriodosE);
            this.bsPeriodo.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPeriodo_ListChanged);
            // 
            // desPeriodo
            // 
            this.desPeriodo.DataPropertyName = "desPeriodo";
            this.desPeriodo.HeaderText = "Periodo";
            this.desPeriodo.Name = "desPeriodo";
            this.desPeriodo.ReadOnly = true;
            // 
            // fecInicio
            // 
            this.fecInicio.DataPropertyName = "fecInicio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecInicio.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecInicio.HeaderText = "Inicio";
            this.fecInicio.Name = "fecInicio";
            // 
            // fecFinal
            // 
            this.fecFinal.DataPropertyName = "fecFinal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecFinal.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecFinal.HeaderText = "Final";
            this.fecFinal.Name = "fecFinal";
            // 
            // indAperturaDataGridViewCheckBoxColumn
            // 
            this.indAperturaDataGridViewCheckBoxColumn.DataPropertyName = "indApertura";
            this.indAperturaDataGridViewCheckBoxColumn.HeaderText = "Apertura";
            this.indAperturaDataGridViewCheckBoxColumn.Name = "indAperturaDataGridViewCheckBoxColumn";
            this.indAperturaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // indCierre
            // 
            this.indCierre.DataPropertyName = "indCierre";
            this.indCierre.HeaderText = "Cierre";
            this.indCierre.Name = "indCierre";
            // 
            // frmPeriodosControlAlm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 430);
            this.Controls.Add(this.PnlGeneracion);
            this.Controls.Add(this.panel1);
            this.Name = "frmPeriodosControlAlm";
            this.Text = "Control de Periodo de Almacen";
            this.Load += new System.EventHandler(this.frmPeriodoControlAlm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodo)).EndInit();
            this.PnlGeneracion.ResumeLayout(false);
            this.PnlGeneracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPeriodo;
        private System.Windows.Forms.BindingSource bsPeriodo;
        private System.Windows.Forms.Button BtGenerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Panel PnlGeneracion;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.ComboBox cboAnios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecFinal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAperturaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCierre;
    }
}