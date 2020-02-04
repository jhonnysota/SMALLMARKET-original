namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCondicionVentas
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
            this.dgvCondiciones = new System.Windows.Forms.DataGridView();
            this.idCondicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCondicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipCondicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.CondicionE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(251, 301);
            this.btnAceptar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(357, 301);
            this.btnCancelar.Size = new System.Drawing.Size(100, 26);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(812, 26);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(707, 22);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.Text = "Ingrese descripción";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(12, 25);
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCondiciones);
            this.gbResultados.Location = new System.Drawing.Point(7, 50);
            this.gbResultados.Size = new System.Drawing.Size(455, 246);
            // 
            // dgvCondiciones
            // 
            this.dgvCondiciones.AllowUserToAddRows = false;
            this.dgvCondiciones.AllowUserToDeleteRows = false;
            this.dgvCondiciones.AutoGenerateColumns = false;
            this.dgvCondiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCondicionDataGridViewTextBoxColumn,
            this.desCondicionDataGridViewTextBoxColumn,
            this.idTipCondicionDataGridViewTextBoxColumn});
            this.dgvCondiciones.DataSource = this.bsBase;
            this.dgvCondiciones.EnableHeadersVisualStyles = false;
            this.dgvCondiciones.Location = new System.Drawing.Point(5, 15);
            this.dgvCondiciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCondiciones.Name = "dgvCondiciones";
            this.dgvCondiciones.ReadOnly = true;
            this.dgvCondiciones.RowTemplate.Height = 24;
            this.dgvCondiciones.Size = new System.Drawing.Size(444, 227);
            this.dgvCondiciones.TabIndex = 4;
            this.dgvCondiciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCondiciones_CellDoubleClick);
            this.dgvCondiciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCondiciones_CellFormatting);
            this.dgvCondiciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCondiciones_CellPainting);
            // 
            // idCondicionDataGridViewTextBoxColumn
            // 
            this.idCondicionDataGridViewTextBoxColumn.DataPropertyName = "idCondicion";
            this.idCondicionDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idCondicionDataGridViewTextBoxColumn.Name = "idCondicionDataGridViewTextBoxColumn";
            this.idCondicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desCondicionDataGridViewTextBoxColumn
            // 
            this.desCondicionDataGridViewTextBoxColumn.DataPropertyName = "desCondicion";
            this.desCondicionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desCondicionDataGridViewTextBoxColumn.Name = "desCondicionDataGridViewTextBoxColumn";
            this.desCondicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idTipCondicionDataGridViewTextBoxColumn
            // 
            this.idTipCondicionDataGridViewTextBoxColumn.DataPropertyName = "idTipCondicion";
            this.idTipCondicionDataGridViewTextBoxColumn.HeaderText = "idTipCondicion";
            this.idTipCondicionDataGridViewTextBoxColumn.Name = "idTipCondicionDataGridViewTextBoxColumn";
            this.idTipCondicionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipCondicionDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmBuscarCondicionVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 333);
            this.Name = "frmBuscarCondicionVentas";
            this.Text = "Busqueda de Condiciones de Ventas";
            this.Load += new System.EventHandler(this.frmBuscarCondicionVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCondiciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCondicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCondicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipCondicionDataGridViewTextBoxColumn;

    }
}