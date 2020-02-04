namespace ClienteWinForm.Maestros.Busqueda
{
    partial class FrmArticuloCatOpcionArbol2
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
            this.dgvArticuloArbol = new System.Windows.Forms.DataGridView();
            this.desCategoria1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCategoria2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloArbol)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.ArticuloCatE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(239, 320);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(345, 320);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(486, 23);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(502, 113);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 26);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(12, 46);
            this.txtFiltro.Size = new System.Drawing.Size(448, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvArticuloArbol);
            this.gbResultados.Location = new System.Drawing.Point(12, 75);
            this.gbResultados.Size = new System.Drawing.Size(417, 239);
            // 
            // dgvArticuloArbol
            // 
            this.dgvArticuloArbol.AllowUserToAddRows = false;
            this.dgvArticuloArbol.AllowUserToDeleteRows = false;
            this.dgvArticuloArbol.AutoGenerateColumns = false;
            this.dgvArticuloArbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticuloArbol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desCategoria1DataGridViewTextBoxColumn,
            this.desCategoria2DataGridViewTextBoxColumn});
            this.dgvArticuloArbol.DataSource = this.bsBase;
            this.dgvArticuloArbol.EnableHeadersVisualStyles = false;
            this.dgvArticuloArbol.Location = new System.Drawing.Point(6, 19);
            this.dgvArticuloArbol.Name = "dgvArticuloArbol";
            this.dgvArticuloArbol.ReadOnly = true;
            this.dgvArticuloArbol.Size = new System.Drawing.Size(403, 214);
            this.dgvArticuloArbol.TabIndex = 0;
            this.dgvArticuloArbol.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticuloArbol_CellDoubleClick);
            this.dgvArticuloArbol.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvArticuloArbol_CellPainting);
            this.dgvArticuloArbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvArticuloArbol_KeyDown);
            // 
            // desCategoria1DataGridViewTextBoxColumn
            // 
            this.desCategoria1DataGridViewTextBoxColumn.DataPropertyName = "desCategoria1";
            this.desCategoria1DataGridViewTextBoxColumn.HeaderText = "Categoria 1";
            this.desCategoria1DataGridViewTextBoxColumn.Name = "desCategoria1DataGridViewTextBoxColumn";
            this.desCategoria1DataGridViewTextBoxColumn.ReadOnly = true;
            this.desCategoria1DataGridViewTextBoxColumn.Width = 150;
            // 
            // desCategoria2DataGridViewTextBoxColumn
            // 
            this.desCategoria2DataGridViewTextBoxColumn.DataPropertyName = "desCategoria2";
            this.desCategoria2DataGridViewTextBoxColumn.HeaderText = "Categoria 2";
            this.desCategoria2DataGridViewTextBoxColumn.Name = "desCategoria2DataGridViewTextBoxColumn";
            this.desCategoria2DataGridViewTextBoxColumn.ReadOnly = true;
            this.desCategoria2DataGridViewTextBoxColumn.Width = 230;
            // 
            // FrmArticuloCatOpcionArbol2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 371);
            this.Name = "FrmArticuloCatOpcionArbol2";
            this.Text = "FrmArticuloCatOpcionArbol2";
            this.Load += new System.EventHandler(this.FrmArticuloCatOpcionArbol2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloArbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticuloArbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCategoria1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCategoria2DataGridViewTextBoxColumn;
    }
}