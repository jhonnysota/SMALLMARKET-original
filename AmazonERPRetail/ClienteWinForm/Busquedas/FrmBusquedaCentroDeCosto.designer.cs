namespace ClienteWinForm.Busquedas
{
    partial class FrmBusquedaCentroDeCosto
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
            this.dgvCentroDeCosto = new System.Windows.Forms.DataGridView();
            this.idEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCCostosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroDeCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.CCostosE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(156, 328);
            this.btnAceptar.Size = new System.Drawing.Size(100, 27);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(262, 328);
            this.btnCancelar.Size = new System.Drawing.Size(100, 27);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(95, 14);
            this.btnBuscar.Size = new System.Drawing.Size(84, 43);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(261, 27);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.Text = "Nivel C.Costos";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(253, 37);
            this.txtFiltro.Size = new System.Drawing.Size(110, 20);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCentroDeCosto);
            this.gbResultados.Location = new System.Drawing.Point(8, 69);
            this.gbResultados.Size = new System.Drawing.Size(355, 255);
            // 
            // dgvCentroDeCosto
            // 
            this.dgvCentroDeCosto.AllowUserToAddRows = false;
            this.dgvCentroDeCosto.AllowUserToDeleteRows = false;
            this.dgvCentroDeCosto.AllowUserToResizeColumns = false;
            this.dgvCentroDeCosto.AllowUserToResizeRows = false;
            this.dgvCentroDeCosto.AutoGenerateColumns = false;
            this.dgvCentroDeCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCentroDeCosto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpresaDataGridViewTextBoxColumn,
            this.idCCostosDataGridViewTextBoxColumn,
            this.desCCostosDataGridViewTextBoxColumn});
            this.dgvCentroDeCosto.DataSource = this.bsBase;
            this.dgvCentroDeCosto.Location = new System.Drawing.Point(10, 19);
            this.dgvCentroDeCosto.MultiSelect = false;
            this.dgvCentroDeCosto.Name = "dgvCentroDeCosto";
            this.dgvCentroDeCosto.ReadOnly = true;
            this.dgvCentroDeCosto.RowHeadersVisible = false;
            this.dgvCentroDeCosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCentroDeCosto.Size = new System.Drawing.Size(336, 227);
            this.dgvCentroDeCosto.TabIndex = 0;
            this.dgvCentroDeCosto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCentroDeCosto_CellDoubleClick);
            this.dgvCentroDeCosto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCentroDeCosto_CellEndEdit);
            this.dgvCentroDeCosto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCentroDeCosto_CellPainting);
            this.dgvCentroDeCosto.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCentroDeCosto_CellValidating);
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            this.idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.HeaderText = "idEmpresa";
            this.idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            this.idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmpresaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idCCostosDataGridViewTextBoxColumn
            // 
            this.idCCostosDataGridViewTextBoxColumn.DataPropertyName = "idCCostos";
            this.idCCostosDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idCCostosDataGridViewTextBoxColumn.Name = "idCCostosDataGridViewTextBoxColumn";
            this.idCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCCostosDataGridViewTextBoxColumn
            // 
            this.desCCostosDataGridViewTextBoxColumn.DataPropertyName = "desCCostos";
            this.desCCostosDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desCCostosDataGridViewTextBoxColumn.Name = "desCCostosDataGridViewTextBoxColumn";
            this.desCCostosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nudNivel
            // 
            this.nudNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNivel.Location = new System.Drawing.Point(15, 35);
            this.nudNivel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(36, 21);
            this.nudNivel.TabIndex = 8;
            this.nudNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmBusquedaCentroDeCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 359);
            this.Controls.Add(this.nudNivel);
            this.Name = "FrmBusquedaCentroDeCosto";
            this.Text = "Busqueda de Centro de Costos";
            this.Load += new System.EventHandler(this.FrmBusquedaCentroDeCosto_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.nudNivel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroDeCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCentroDeCosto;
        private System.Windows.Forms.NumericUpDown nudNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCCostosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCCostosDataGridViewTextBoxColumn;
    }
}
