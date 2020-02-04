namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCostosClasificacion
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
            this.dgvCostosClasificacion = new System.Windows.Forms.DataGridView();
            this.codClasificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClasificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indUltimoNivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostosClasificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.CostosClasificacionE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(301, 281);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(407, 281);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(456, 21);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1089, 180);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(817, 182);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(817, 205);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCostosClasificacion);
            this.gbResultados.Location = new System.Drawing.Point(12, 12);
            this.gbResultados.Size = new System.Drawing.Size(438, 263);
            // 
            // dgvCostosClasificacion
            // 
            this.dgvCostosClasificacion.AllowUserToAddRows = false;
            this.dgvCostosClasificacion.AllowUserToDeleteRows = false;
            this.dgvCostosClasificacion.AutoGenerateColumns = false;
            this.dgvCostosClasificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostosClasificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codClasificacionDataGridViewTextBoxColumn,
            this.nombreClasificacionDataGridViewTextBoxColumn,
            this.numNivelDataGridViewTextBoxColumn,
            this.indUltimoNivelDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvCostosClasificacion.DataSource = this.bsBase;
            this.dgvCostosClasificacion.Location = new System.Drawing.Point(7, 20);
            this.dgvCostosClasificacion.Name = "dgvCostosClasificacion";
            this.dgvCostosClasificacion.ReadOnly = true;
            this.dgvCostosClasificacion.Size = new System.Drawing.Size(425, 237);
            this.dgvCostosClasificacion.TabIndex = 0;
            this.dgvCostosClasificacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostosClasificacion_CellDoubleClick);
            // 
            // codClasificacionDataGridViewTextBoxColumn
            // 
            this.codClasificacionDataGridViewTextBoxColumn.DataPropertyName = "CodClasificacion";
            this.codClasificacionDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codClasificacionDataGridViewTextBoxColumn.Name = "codClasificacionDataGridViewTextBoxColumn";
            this.codClasificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.codClasificacionDataGridViewTextBoxColumn.Width = 60;
            // 
            // nombreClasificacionDataGridViewTextBoxColumn
            // 
            this.nombreClasificacionDataGridViewTextBoxColumn.DataPropertyName = "nombreClasificacion";
            this.nombreClasificacionDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreClasificacionDataGridViewTextBoxColumn.Name = "nombreClasificacionDataGridViewTextBoxColumn";
            this.nombreClasificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreClasificacionDataGridViewTextBoxColumn.Width = 230;
            // 
            // numNivelDataGridViewTextBoxColumn
            // 
            this.numNivelDataGridViewTextBoxColumn.DataPropertyName = "numNivel";
            this.numNivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.numNivelDataGridViewTextBoxColumn.Name = "numNivelDataGridViewTextBoxColumn";
            this.numNivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.numNivelDataGridViewTextBoxColumn.Width = 40;
            // 
            // indUltimoNivelDataGridViewTextBoxColumn
            // 
            this.indUltimoNivelDataGridViewTextBoxColumn.DataPropertyName = "indUltimoNivel";
            this.indUltimoNivelDataGridViewTextBoxColumn.HeaderText = "UltimoNivel";
            this.indUltimoNivelDataGridViewTextBoxColumn.Name = "indUltimoNivelDataGridViewTextBoxColumn";
            this.indUltimoNivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarCostosClasificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 328);
            this.Name = "frmBuscarCostosClasificacion";
            this.Text = "Buscar Costos Clasificacion";
            this.Load += new System.EventHandler(this.frmBuscarCostosClasificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostosClasificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCostosClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codClasificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreClasificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indUltimoNivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}