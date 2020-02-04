namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCuentasExac
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
            this.dgvCuentasExac = new System.Windows.Forms.DataGridView();
            this.codCuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasExac)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.PlanCuentasE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(351, 339);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(457, 339);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(681, 105);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1039, 250);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(740, 253);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(740, 276);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCuentasExac);
            this.gbResultados.Location = new System.Drawing.Point(12, 4);
            this.gbResultados.Size = new System.Drawing.Size(544, 329);
            // 
            // dgvCuentasExac
            // 
            this.dgvCuentasExac.AllowUserToAddRows = false;
            this.dgvCuentasExac.AllowUserToDeleteRows = false;
            this.dgvCuentasExac.AutoGenerateColumns = false;
            this.dgvCuentasExac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasExac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCuentaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.numNivelDataGridViewTextBoxColumn});
            this.dgvCuentasExac.DataSource = this.bsBase;
            this.dgvCuentasExac.Location = new System.Drawing.Point(11, 24);
            this.dgvCuentasExac.Name = "dgvCuentasExac";
            this.dgvCuentasExac.ReadOnly = true;
            this.dgvCuentasExac.Size = new System.Drawing.Size(521, 299);
            this.dgvCuentasExac.TabIndex = 0;
            this.dgvCuentasExac.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentasExac_CellDoubleClick);
            // 
            // codCuentaDataGridViewTextBoxColumn
            // 
            this.codCuentaDataGridViewTextBoxColumn.DataPropertyName = "codCuenta";
            this.codCuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.codCuentaDataGridViewTextBoxColumn.Name = "codCuentaDataGridViewTextBoxColumn";
            this.codCuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 160;
            // 
            // numNivelDataGridViewTextBoxColumn
            // 
            this.numNivelDataGridViewTextBoxColumn.DataPropertyName = "numNivel";
            this.numNivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.numNivelDataGridViewTextBoxColumn.Name = "numNivelDataGridViewTextBoxColumn";
            this.numNivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarCuentasExac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 379);
            this.Name = "frmBuscarCuentasExac";
            this.Text = "Buscar Cuentas Exactas";
            this.Load += new System.EventHandler(this.frmBuscarCuentasExac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasExac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCuentasExac;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivelDataGridViewTextBoxColumn;
    }
}