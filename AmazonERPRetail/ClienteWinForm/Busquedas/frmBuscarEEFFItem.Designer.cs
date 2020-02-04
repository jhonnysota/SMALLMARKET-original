namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarEEFFItem
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
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.idEEFFItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoTablaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.EEFFItemE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(263, 265);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(369, 265);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1179, 160);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(986, 156);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(687, 159);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(687, 182);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvItem);
            this.gbResultados.Location = new System.Drawing.Point(12, 7);
            this.gbResultados.Size = new System.Drawing.Size(458, 252);
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.AutoGenerateColumns = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEEFFItemDataGridViewTextBoxColumn,
            this.desItemDataGridViewTextBoxColumn,
            this.tipoTablaDataGridViewTextBoxColumn});
            this.dgvItem.DataSource = this.bsBase;
            this.dgvItem.Location = new System.Drawing.Point(6, 19);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.Size = new System.Drawing.Size(444, 227);
            this.dgvItem.TabIndex = 0;
            this.dgvItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellDoubleClick);
            // 
            // idEEFFItemDataGridViewTextBoxColumn
            // 
            this.idEEFFItemDataGridViewTextBoxColumn.DataPropertyName = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.HeaderText = "idEEFFItem";
            this.idEEFFItemDataGridViewTextBoxColumn.Name = "idEEFFItemDataGridViewTextBoxColumn";
            this.idEEFFItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desItemDataGridViewTextBoxColumn
            // 
            this.desItemDataGridViewTextBoxColumn.DataPropertyName = "desItem";
            this.desItemDataGridViewTextBoxColumn.HeaderText = "desItem";
            this.desItemDataGridViewTextBoxColumn.Name = "desItemDataGridViewTextBoxColumn";
            this.desItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.desItemDataGridViewTextBoxColumn.Width = 200;
            // 
            // tipoTablaDataGridViewTextBoxColumn
            // 
            this.tipoTablaDataGridViewTextBoxColumn.DataPropertyName = "TipoTabla";
            this.tipoTablaDataGridViewTextBoxColumn.HeaderText = "TipoTabla";
            this.tipoTablaDataGridViewTextBoxColumn.Name = "tipoTablaDataGridViewTextBoxColumn";
            this.tipoTablaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarEEFFItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 302);
            this.Name = "frmBuscarEEFFItem";
            this.Text = "Buscar EEFFItem";
            this.Load += new System.EventHandler(this.frmBuscarEEFFItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEEFFItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoTablaDataGridViewTextBoxColumn;
    }
}