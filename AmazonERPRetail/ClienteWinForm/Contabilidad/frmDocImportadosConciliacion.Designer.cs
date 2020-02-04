namespace ClienteWinForm.Contabilidad
{
    partial class frmDocImportadosConciliacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dgvConciliados = new System.Windows.Forms.DataGridView();
            this.bsConciliacion = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistrosV = new MyLabelG.LabelDegradado();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConciliados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConciliacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.dgvConciliados);
            this.pnlDetalle.Controls.Add(this.lblRegistrosV);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(781, 622);
            this.pnlDetalle.TabIndex = 371;
            // 
            // dgvConciliados
            // 
            this.dgvConciliados.AllowUserToAddRows = false;
            this.dgvConciliados.AllowUserToDeleteRows = false;
            this.dgvConciliados.AutoGenerateColumns = false;
            this.dgvConciliados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvConciliados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConciliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConciliados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RazonSocial,
            this.fechaDataGridViewTextBoxColumn,
            this.glosaDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.operacionDataGridViewTextBoxColumn,
            this.CodCuenta});
            this.dgvConciliados.DataSource = this.bsConciliacion;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConciliados.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConciliados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConciliados.EnableHeadersVisualStyles = false;
            this.dgvConciliados.Location = new System.Drawing.Point(0, 17);
            this.dgvConciliados.Name = "dgvConciliados";
            this.dgvConciliados.ReadOnly = true;
            this.dgvConciliados.Size = new System.Drawing.Size(779, 603);
            this.dgvConciliados.TabIndex = 248;
            // 
            // bsConciliacion
            // 
            this.bsConciliacion.DataSource = typeof(Entidades.Contabilidad.BancosConciliarE);
            // 
            // lblRegistrosV
            // 
            this.lblRegistrosV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistrosV.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistrosV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosV.ForeColor = System.Drawing.Color.White;
            this.lblRegistrosV.Location = new System.Drawing.Point(0, 0);
            this.lblRegistrosV.Name = "lblRegistrosV";
            this.lblRegistrosV.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistrosV.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistrosV.Size = new System.Drawing.Size(779, 17);
            this.lblRegistrosV.TabIndex = 258;
            this.lblRegistrosV.Text = "Registros 0";
            this.lblRegistrosV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 250;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 70;
            // 
            // glosaDataGridViewTextBoxColumn
            // 
            this.glosaDataGridViewTextBoxColumn.DataPropertyName = "Glosa";
            this.glosaDataGridViewTextBoxColumn.HeaderText = "Glosa";
            this.glosaDataGridViewTextBoxColumn.Name = "glosaDataGridViewTextBoxColumn";
            this.glosaDataGridViewTextBoxColumn.ReadOnly = true;
            this.glosaDataGridViewTextBoxColumn.Width = 200;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn.Width = 80;
            // 
            // operacionDataGridViewTextBoxColumn
            // 
            this.operacionDataGridViewTextBoxColumn.DataPropertyName = "Operacion";
            this.operacionDataGridViewTextBoxColumn.HeaderText = "Operación";
            this.operacionDataGridViewTextBoxColumn.Name = "operacionDataGridViewTextBoxColumn";
            this.operacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.operacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // CodCuenta
            // 
            this.CodCuenta.DataPropertyName = "CodCuenta";
            this.CodCuenta.HeaderText = "CodCuenta";
            this.CodCuenta.Name = "CodCuenta";
            this.CodCuenta.ReadOnly = true;
            this.CodCuenta.Width = 80;
            // 
            // frmDocImportadosConciliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 629);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "frmDocImportadosConciliacion";
            this.Text = "Documentos Importados";
            this.Load += new System.EventHandler(this.frmDocImportadosConciliacion_Load);
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConciliados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConciliacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvConciliados;
        private MyLabelG.LabelDegradado lblRegistrosV;
        private System.Windows.Forms.BindingSource bsConciliacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCuenta;
    }
}