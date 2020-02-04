namespace ClienteWinForm.Seguridad.Busquedas
{
    partial class FrmBusquedaUsuarioEmpresaLocalPerfil
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
            this.dgvVendedor = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCompletoPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Seguridad.UsuarioEmpresaLocalPerfil);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(348, 31);
            this.chkAnulado.Size = new System.Drawing.Size(127, 17);
            this.chkAnulado.Text = "Incluir Todos Locales";
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvVendedor);
            // 
            // dgvVendedor
            // 
            this.dgvVendedor.AllowUserToAddRows = false;
            this.dgvVendedor.AllowUserToDeleteRows = false;
            this.dgvVendedor.AllowUserToResizeColumns = false;
            this.dgvVendedor.AllowUserToResizeRows = false;
            this.dgvVendedor.AutoGenerateColumns = false;
            this.dgvVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPersonaDataGridViewTextBoxColumn,
            this.nombreCompletoPersonaDataGridViewTextBoxColumn,
            this.estadoDataGridViewCheckBoxColumn});
            this.dgvVendedor.DataSource = this.bsBase;
            this.dgvVendedor.Location = new System.Drawing.Point(6, 19);
            this.dgvVendedor.MultiSelect = false;
            this.dgvVendedor.Name = "dgvVendedor";
            this.dgvVendedor.RowHeadersVisible = false;
            this.dgvVendedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedor.Size = new System.Drawing.Size(532, 227);
            this.dgvVendedor.TabIndex = 0;
            this.dgvVendedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedor_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdPersona";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdPersona";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreCompletoPersona";
            this.dataGridViewTextBoxColumn2.HeaderText = "NombreCompletoPersona";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // idPersonaDataGridViewTextBoxColumn
            // 
            this.idPersonaDataGridViewTextBoxColumn.DataPropertyName = "IdPersona";
            this.idPersonaDataGridViewTextBoxColumn.HeaderText = "CODIGO";
            this.idPersonaDataGridViewTextBoxColumn.Name = "idPersonaDataGridViewTextBoxColumn";
            this.idPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreCompletoPersonaDataGridViewTextBoxColumn
            // 
            this.nombreCompletoPersonaDataGridViewTextBoxColumn.DataPropertyName = "NombreCompletoPersona";
            this.nombreCompletoPersonaDataGridViewTextBoxColumn.HeaderText = "NOMBRE VENDEDOR";
            this.nombreCompletoPersonaDataGridViewTextBoxColumn.Name = "nombreCompletoPersonaDataGridViewTextBoxColumn";
            this.nombreCompletoPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreCompletoPersonaDataGridViewTextBoxColumn.Width = 250;
            // 
            // estadoDataGridViewCheckBoxColumn
            // 
            this.estadoDataGridViewCheckBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewCheckBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            this.estadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // FrmBusquedaUsuarioEmpresaLocalPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 369);
            this.Name = "FrmBusquedaUsuarioEmpresaLocalPerfil";
            this.Text = "FrmBusquedaVendedores";
            this.Load += new System.EventHandler(this.FrmBusquedaUsuarioEmpresaLocalPerfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCompletoPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn;
    }
}