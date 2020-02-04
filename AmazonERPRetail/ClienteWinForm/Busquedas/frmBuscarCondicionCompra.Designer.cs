namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCondicionCompra
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
            this.dgvCondiciones = new System.Windows.Forms.DataGridView();
            this.idParTablaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Generales.ParTabla);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(288, 314);
            this.btnAceptar.Size = new System.Drawing.Size(100, 29);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(394, 314);
            this.btnCancelar.Size = new System.Drawing.Size(100, 29);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(441, 12);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(306, 8);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 11);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(7, 31);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCondiciones);
            this.gbResultados.Location = new System.Drawing.Point(7, 58);
            this.gbResultados.Size = new System.Drawing.Size(487, 252);
            // 
            // dgvCondiciones
            // 
            this.dgvCondiciones.AllowUserToAddRows = false;
            this.dgvCondiciones.AllowUserToDeleteRows = false;
            this.dgvCondiciones.AutoGenerateColumns = false;
            this.dgvCondiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idParTablaDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.dgvCondiciones.DataSource = this.bsBase;
            this.dgvCondiciones.EnableHeadersVisualStyles = false;
            this.dgvCondiciones.Location = new System.Drawing.Point(7, 16);
            this.dgvCondiciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCondiciones.Name = "dgvCondiciones";
            this.dgvCondiciones.ReadOnly = true;
            this.dgvCondiciones.RowTemplate.Height = 24;
            this.dgvCondiciones.Size = new System.Drawing.Size(473, 229);
            this.dgvCondiciones.TabIndex = 6;
            this.dgvCondiciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCondiciones_CellDoubleClick);
            this.dgvCondiciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCondiciones_CellPainting);
            // 
            // idParTablaDataGridViewTextBoxColumn
            // 
            this.idParTablaDataGridViewTextBoxColumn.DataPropertyName = "IdParTabla";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idParTablaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idParTablaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idParTablaDataGridViewTextBoxColumn.Name = "idParTablaDataGridViewTextBoxColumn";
            this.idParTablaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarCondicionCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 347);
            this.Name = "frmBuscarCondicionCompra";
            this.Text = "Condiciones de Compra";
            this.Load += new System.EventHandler(this.frmBuscarCondicionCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCondiciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idParTablaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
    }
}