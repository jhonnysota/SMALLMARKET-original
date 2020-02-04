namespace ClienteWinForm.Busquedas
{
    partial class FrmBuscarDocumentosImpuestos
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
            this.dgvBuscarImpuestos = new System.Windows.Forms.DataGridView();
            this.idImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarImpuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Generales.ImpuestosE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(95, 215);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(201, 215);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(921, 42);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(899, 159);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(863, 109);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(896, 205);
            this.txtFiltro.Size = new System.Drawing.Size(150, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvBuscarImpuestos);
            this.gbResultados.Location = new System.Drawing.Point(6, 3);
            this.gbResultados.Size = new System.Drawing.Size(305, 206);
            this.gbResultados.Text = "Impuestos Encontrados";
            // 
            // dgvBuscarImpuestos
            // 
            this.dgvBuscarImpuestos.AllowUserToAddRows = false;
            this.dgvBuscarImpuestos.AllowUserToDeleteRows = false;
            this.dgvBuscarImpuestos.AutoGenerateColumns = false;
            this.dgvBuscarImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarImpuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idImpuestoDataGridViewTextBoxColumn,
            this.desImpuestoDataGridViewTextBoxColumn});
            this.dgvBuscarImpuestos.DataSource = this.bsBase;
            this.dgvBuscarImpuestos.EnableHeadersVisualStyles = false;
            this.dgvBuscarImpuestos.Location = new System.Drawing.Point(9, 18);
            this.dgvBuscarImpuestos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBuscarImpuestos.Name = "dgvBuscarImpuestos";
            this.dgvBuscarImpuestos.ReadOnly = true;
            this.dgvBuscarImpuestos.RowTemplate.Height = 24;
            this.dgvBuscarImpuestos.Size = new System.Drawing.Size(281, 181);
            this.dgvBuscarImpuestos.TabIndex = 8;
            this.dgvBuscarImpuestos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuscarImpuestos_CellDoubleClick);
            this.dgvBuscarImpuestos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBuscarImpuestos_CellPainting);
            // 
            // idImpuestoDataGridViewTextBoxColumn
            // 
            this.idImpuestoDataGridViewTextBoxColumn.DataPropertyName = "idImpuesto";
            this.idImpuestoDataGridViewTextBoxColumn.HeaderText = "Impuesto";
            this.idImpuestoDataGridViewTextBoxColumn.Name = "idImpuestoDataGridViewTextBoxColumn";
            this.idImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idImpuestoDataGridViewTextBoxColumn.Width = 55;
            // 
            // desImpuestoDataGridViewTextBoxColumn
            // 
            this.desImpuestoDataGridViewTextBoxColumn.DataPropertyName = "desImpuesto";
            this.desImpuestoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desImpuestoDataGridViewTextBoxColumn.Name = "desImpuestoDataGridViewTextBoxColumn";
            this.desImpuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmBuscarDocumentosImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(313, 248);
            this.Name = "FrmBuscarDocumentosImpuestos";
            this.Text = "Buscar Impuestos";
            this.Load += new System.EventHandler(this.FrmBuscarDocumentosImpuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarImpuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuscarImpuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desImpuestoDataGridViewTextBoxColumn;
    }
}