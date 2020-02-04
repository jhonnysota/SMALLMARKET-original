namespace ClienteWinForm.Busquedas
{
    partial class frmBusquedaAnticipos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAnticipos = new System.Windows.Forms.DataGridView();
            this.idDocAnticipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerieAnticipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocAnticipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSaldoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnticipos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.AnticiposE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(116, 258);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(222, 258);
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(717, 22);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(717, 20);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(515, 21);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(515, 44);
            this.txtFiltro.Size = new System.Drawing.Size(191, 20);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvAnticipos);
            this.gbResultados.Location = new System.Drawing.Point(5, 3);
            this.gbResultados.Size = new System.Drawing.Size(429, 249);
            // 
            // dgvAnticipos
            // 
            this.dgvAnticipos.AllowUserToAddRows = false;
            this.dgvAnticipos.AllowUserToDeleteRows = false;
            this.dgvAnticipos.AutoGenerateColumns = false;
            this.dgvAnticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnticipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocAnticipoDataGridViewTextBoxColumn,
            this.numSerieAnticipoDataGridViewTextBoxColumn,
            this.numDocAnticipoDataGridViewTextBoxColumn,
            this.totalSaldoDataGridViewTextBoxColumn});
            this.dgvAnticipos.DataSource = this.bsBase;
            this.dgvAnticipos.EnableHeadersVisualStyles = false;
            this.dgvAnticipos.Location = new System.Drawing.Point(6, 14);
            this.dgvAnticipos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAnticipos.Name = "dgvAnticipos";
            this.dgvAnticipos.RowTemplate.Height = 24;
            this.dgvAnticipos.Size = new System.Drawing.Size(418, 229);
            this.dgvAnticipos.TabIndex = 1;
            this.dgvAnticipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnticipos_CellDoubleClick);
            this.dgvAnticipos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAnticipos_CellPainting);
            // 
            // idDocAnticipoDataGridViewTextBoxColumn
            // 
            this.idDocAnticipoDataGridViewTextBoxColumn.DataPropertyName = "idDocAnticipo";
            this.idDocAnticipoDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.idDocAnticipoDataGridViewTextBoxColumn.Name = "idDocAnticipoDataGridViewTextBoxColumn";
            this.idDocAnticipoDataGridViewTextBoxColumn.Width = 40;
            // 
            // numSerieAnticipoDataGridViewTextBoxColumn
            // 
            this.numSerieAnticipoDataGridViewTextBoxColumn.DataPropertyName = "numSerieAnticipo";
            this.numSerieAnticipoDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.numSerieAnticipoDataGridViewTextBoxColumn.Name = "numSerieAnticipoDataGridViewTextBoxColumn";
            this.numSerieAnticipoDataGridViewTextBoxColumn.Width = 60;
            // 
            // numDocAnticipoDataGridViewTextBoxColumn
            // 
            this.numDocAnticipoDataGridViewTextBoxColumn.DataPropertyName = "numDocAnticipo";
            this.numDocAnticipoDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numDocAnticipoDataGridViewTextBoxColumn.Name = "numDocAnticipoDataGridViewTextBoxColumn";
            this.numDocAnticipoDataGridViewTextBoxColumn.Width = 90;
            // 
            // totalSaldoDataGridViewTextBoxColumn
            // 
            this.totalSaldoDataGridViewTextBoxColumn.DataPropertyName = "TotalSaldo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Format = "N2";
            this.totalSaldoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalSaldoDataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.totalSaldoDataGridViewTextBoxColumn.Name = "totalSaldoDataGridViewTextBoxColumn";
            this.totalSaldoDataGridViewTextBoxColumn.Width = 80;
            // 
            // frmBusquedaAnticipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 294);
            this.Name = "frmBusquedaAnticipos";
            this.Text = "Anticipos de";
            this.Load += new System.EventHandler(this.frmBusquedaAnticipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnticipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnticipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocAnticipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerieAnticipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocAnticipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSaldoDataGridViewTextBoxColumn;
    }
}