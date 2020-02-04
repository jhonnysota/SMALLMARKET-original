namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarConceptosGasto
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
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.idConceptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codConceptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desConceptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Contabilidad.ConceptoGastoE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(266, 311);
            this.btnAceptar.Size = new System.Drawing.Size(100, 27);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(372, 311);
            this.btnCancelar.Size = new System.Drawing.Size(100, 27);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(421, 6);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(310, -14);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 11);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(9, 28);
            this.txtFiltro.Size = new System.Drawing.Size(350, 20);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvConceptos);
            this.gbResultados.Location = new System.Drawing.Point(9, 55);
            this.gbResultados.Size = new System.Drawing.Size(463, 250);
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AccessibleDescription = "";
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AutoGenerateColumns = false;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConceptoDataGridViewTextBoxColumn,
            this.codConceptoDataGridViewTextBoxColumn,
            this.desConceptoDataGridViewTextBoxColumn});
            this.dgvConceptos.DataSource = this.bsBase;
            this.dgvConceptos.EnableHeadersVisualStyles = false;
            this.dgvConceptos.Location = new System.Drawing.Point(9, 14);
            this.dgvConceptos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.RowTemplate.Height = 24;
            this.dgvConceptos.Size = new System.Drawing.Size(445, 229);
            this.dgvConceptos.TabIndex = 8;
            this.dgvConceptos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConceptos_CellDoubleClick);
            this.dgvConceptos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvConceptos_CellPainting);
            // 
            // idConceptoDataGridViewTextBoxColumn
            // 
            this.idConceptoDataGridViewTextBoxColumn.DataPropertyName = "idConcepto";
            this.idConceptoDataGridViewTextBoxColumn.HeaderText = "ID.";
            this.idConceptoDataGridViewTextBoxColumn.Name = "idConceptoDataGridViewTextBoxColumn";
            this.idConceptoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codConceptoDataGridViewTextBoxColumn
            // 
            this.codConceptoDataGridViewTextBoxColumn.DataPropertyName = "codConcepto";
            this.codConceptoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codConceptoDataGridViewTextBoxColumn.Name = "codConceptoDataGridViewTextBoxColumn";
            this.codConceptoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desConceptoDataGridViewTextBoxColumn
            // 
            this.desConceptoDataGridViewTextBoxColumn.DataPropertyName = "desConcepto";
            this.desConceptoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desConceptoDataGridViewTextBoxColumn.Name = "desConceptoDataGridViewTextBoxColumn";
            this.desConceptoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscarConceptosGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 347);
            this.Name = "frmBuscarConceptosGasto";
            this.Text = "Buscar Conceptos de Gasto";
            this.Load += new System.EventHandler(this.frmBuscarConceptosGasto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codConceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desConceptoDataGridViewTextBoxColumn;
    }
}