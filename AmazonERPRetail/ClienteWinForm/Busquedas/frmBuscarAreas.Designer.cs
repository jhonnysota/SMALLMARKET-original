namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarAreas
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
            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.idAreaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.Area);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(109, 300);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Size = new System.Drawing.Size(91, 29);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(208, 300);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Size = new System.Drawing.Size(91, 29);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Image = global::ClienteWinForm.Properties.Resources.busquedas;
            this.btnBuscar.Location = new System.Drawing.Point(249, 11);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(534, 8);
            this.chkAnulado.Margin = new System.Windows.Forms.Padding(2);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.Text = "Descripción Area";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(9, 32);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltro.Size = new System.Drawing.Size(217, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvAreas);
            this.gbResultados.Location = new System.Drawing.Point(9, 60);
            this.gbResultados.Margin = new System.Windows.Forms.Padding(2);
            this.gbResultados.Padding = new System.Windows.Forms.Padding(2);
            this.gbResultados.Size = new System.Drawing.Size(291, 232);
            // 
            // dgvAreas
            // 
            this.dgvAreas.AccessibleDescription = "";
            this.dgvAreas.AllowUserToAddRows = false;
            this.dgvAreas.AllowUserToDeleteRows = false;
            this.dgvAreas.AutoGenerateColumns = false;
            this.dgvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAreaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.DesEstado});
            this.dgvAreas.DataSource = this.bsBase;
            this.dgvAreas.EnableHeadersVisualStyles = false;
            this.dgvAreas.Location = new System.Drawing.Point(5, 18);
            this.dgvAreas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAreas.Name = "dgvAreas";
            this.dgvAreas.ReadOnly = true;
            this.dgvAreas.RowTemplate.Height = 24;
            this.dgvAreas.Size = new System.Drawing.Size(280, 208);
            this.dgvAreas.TabIndex = 0;
            this.dgvAreas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAreas_CellDoubleClick);
            this.dgvAreas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAreas_CellFormatting);
            this.dgvAreas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAreas_CellPainting);
            // 
            // idAreaDataGridViewTextBoxColumn
            // 
            this.idAreaDataGridViewTextBoxColumn.DataPropertyName = "idArea";
            this.idAreaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idAreaDataGridViewTextBoxColumn.Name = "idAreaDataGridViewTextBoxColumn";
            this.idAreaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DesEstado
            // 
            this.DesEstado.DataPropertyName = "DesEstado";
            this.DesEstado.HeaderText = "Estado";
            this.DesEstado.Name = "DesEstado";
            this.DesEstado.ReadOnly = true;
            // 
            // frmBuscarAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 338);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBuscarAreas";
            this.Text = "Buscar Areas";
            this.Load += new System.EventHandler(this.frmBuscarAreas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAreaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesEstado;
    }
}