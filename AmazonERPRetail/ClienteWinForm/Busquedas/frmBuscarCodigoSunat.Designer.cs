namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarCodigoSunat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.equivalenciaSunatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nemoTecnicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.btnAceptar.Location = new System.Drawing.Point(301, 279);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(407, 279);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(244, 264);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1134, 88);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(835, 91);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(835, 114);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dataGridView1);
            this.gbResultados.Location = new System.Drawing.Point(5, 4);
            this.gbResultados.Size = new System.Drawing.Size(510, 254);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equivalenciaSunatDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.nemoTecnicoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bsBase;
            this.dataGridView1.Location = new System.Drawing.Point(6, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(497, 233);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // equivalenciaSunatDataGridViewTextBoxColumn
            // 
            this.equivalenciaSunatDataGridViewTextBoxColumn.DataPropertyName = "EquivalenciaSunat";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.equivalenciaSunatDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.equivalenciaSunatDataGridViewTextBoxColumn.HeaderText = "Cod.Sunat";
            this.equivalenciaSunatDataGridViewTextBoxColumn.Name = "equivalenciaSunatDataGridViewTextBoxColumn";
            this.equivalenciaSunatDataGridViewTextBoxColumn.ReadOnly = true;
            this.equivalenciaSunatDataGridViewTextBoxColumn.Width = 80;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nombreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 350;
            // 
            // nemoTecnicoDataGridViewTextBoxColumn
            // 
            this.nemoTecnicoDataGridViewTextBoxColumn.DataPropertyName = "NemoTecnico";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nemoTecnicoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nemoTecnicoDataGridViewTextBoxColumn.HeaderText = "NemoTecnico";
            this.nemoTecnicoDataGridViewTextBoxColumn.Name = "nemoTecnicoDataGridViewTextBoxColumn";
            this.nemoTecnicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nemoTecnicoDataGridViewTextBoxColumn.Width = 90;
            // 
            // frmBuscarCodigoSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 315);
            this.Name = "frmBuscarCodigoSunat";
            this.Text = "Buscar Código Sunat de Operaciónes";
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn equivalenciaSunatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nemoTecnicoDataGridViewTextBoxColumn;
    }
}