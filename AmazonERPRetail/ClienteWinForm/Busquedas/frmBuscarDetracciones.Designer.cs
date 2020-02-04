namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarDetracciones
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idTipoDetraccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTempDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Generales.TasasDetraccionesE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(163, 270);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(269, 270);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1194, 160);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1001, 156);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(702, 159);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(702, 182);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dataGridView1);
            this.gbResultados.Location = new System.Drawing.Point(12, 12);
            this.gbResultados.Size = new System.Drawing.Size(358, 252);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoDetraccionDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.nombreTempDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bsBase;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(344, 227);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // idTipoDetraccionDataGridViewTextBoxColumn
            // 
            this.idTipoDetraccionDataGridViewTextBoxColumn.DataPropertyName = "idTipoDetraccion";
            this.idTipoDetraccionDataGridViewTextBoxColumn.HeaderText = "idTipoDetraccion";
            this.idTipoDetraccionDataGridViewTextBoxColumn.Name = "idTipoDetraccionDataGridViewTextBoxColumn";
            this.idTipoDetraccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreTempDataGridViewTextBoxColumn
            // 
            this.nombreTempDataGridViewTextBoxColumn.DataPropertyName = "NombreTemp";
            this.nombreTempDataGridViewTextBoxColumn.HeaderText = "NombreTemp";
            this.nombreTempDataGridViewTextBoxColumn.Name = "nombreTempDataGridViewTextBoxColumn";
            this.nombreTempDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarDetracciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 310);
            this.Name = "frmBuscarDetracciones";
            this.Text = "Buscar Detracciones";
            this.Load += new System.EventHandler(this.frmBuscarDetracciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDetraccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTempDataGridViewTextBoxColumn;
    }
}