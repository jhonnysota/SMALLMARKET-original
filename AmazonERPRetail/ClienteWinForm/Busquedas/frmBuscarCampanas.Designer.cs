namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCampanas
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
            this.dgvCampanas = new System.Windows.Forms.DataGridView();
            this.idCampanaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampanas)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.CampanaE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(264, 312);
            this.btnAceptar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(370, 312);
            this.btnCancelar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(419, 9);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(289, 6);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 9);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(7, 28);
            this.txtFiltro.Size = new System.Drawing.Size(384, 20);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCampanas);
            this.gbResultados.Location = new System.Drawing.Point(7, 55);
            this.gbResultados.Size = new System.Drawing.Size(463, 252);
            // 
            // dgvCampanas
            // 
            this.dgvCampanas.AccessibleDescription = "";
            this.dgvCampanas.AllowUserToAddRows = false;
            this.dgvCampanas.AllowUserToDeleteRows = false;
            this.dgvCampanas.AutoGenerateColumns = false;
            this.dgvCampanas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampanas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCampanaDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.dgvCampanas.DataSource = this.bsBase;
            this.dgvCampanas.EnableHeadersVisualStyles = false;
            this.dgvCampanas.Location = new System.Drawing.Point(8, 15);
            this.dgvCampanas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCampanas.Name = "dgvCampanas";
            this.dgvCampanas.ReadOnly = true;
            this.dgvCampanas.RowTemplate.Height = 24;
            this.dgvCampanas.Size = new System.Drawing.Size(445, 229);
            this.dgvCampanas.TabIndex = 1;
            this.dgvCampanas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCampanas_CellDoubleClick);
            this.dgvCampanas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCampanas_CellPainting);
            // 
            // idCampanaDataGridViewTextBoxColumn
            // 
            this.idCampanaDataGridViewTextBoxColumn.DataPropertyName = "idCampana";
            this.idCampanaDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.idCampanaDataGridViewTextBoxColumn.Name = "idCampanaDataGridViewTextBoxColumn";
            this.idCampanaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarCampanas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 343);
            this.Name = "frmBuscarCampanas";
            this.Text = "Buscar Campañas";
            this.Load += new System.EventHandler(this.frmBuscarCampanas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampanas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCampanas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCampanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
    }
}