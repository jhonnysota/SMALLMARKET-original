namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarConceptosVarios
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
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Almacen.ConceptosVariosE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(321, 250);
            this.btnAceptar.Size = new System.Drawing.Size(100, 33);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(427, 250);
            this.btnCancelar.Size = new System.Drawing.Size(100, 33);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(265, 250);
            this.btnBuscar.Size = new System.Drawing.Size(51, 33);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(569, 65);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(570, 185);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(570, 203);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.label2);
            this.gbResultados.Controls.Add(this.txtDes);
            this.gbResultados.Controls.Add(this.dgvConceptos);
            this.gbResultados.Location = new System.Drawing.Point(5, 3);
            this.gbResultados.Size = new System.Drawing.Size(523, 241);
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
            this.descripcionDataGridViewTextBoxColumn});
            this.dgvConceptos.DataSource = this.bsBase;
            this.dgvConceptos.EnableHeadersVisualStyles = false;
            this.dgvConceptos.Location = new System.Drawing.Point(5, 58);
            this.dgvConceptos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.RowTemplate.Height = 24;
            this.dgvConceptos.Size = new System.Drawing.Size(512, 178);
            this.dgvConceptos.TabIndex = 9;
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
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(84, 24);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(416, 20);
            this.txtDes.TabIndex = 10;
            this.txtDes.Validating += new System.ComponentModel.CancelEventHandler(this.txtDes_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Descripcion";
            // 
            // frmBuscarConceptosVarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 288);
            this.Name = "frmBuscarConceptosVarios";
            this.Text = "Buscar Gastos y Servicios";
            this.Load += new System.EventHandler(this.frmBuscarConceptosVarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codConceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDes;
    }
}