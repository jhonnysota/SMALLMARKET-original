namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarHojaDeCostoOC
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
            System.Windows.Forms.Label fecOperacionLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOC = new System.Windows.Forms.DataGridView();
            this.idHojaCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFecIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            fecOperacionLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Almacen.HojaCostoE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(66, 304);
            this.btnAceptar.Size = new System.Drawing.Size(100, 24);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(172, 304);
            this.btnCancelar.Size = new System.Drawing.Size(100, 24);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(281, 8);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1111, 164);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(812, 167);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(812, 190);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvOC);
            this.gbResultados.Location = new System.Drawing.Point(5, 58);
            this.gbResultados.Size = new System.Drawing.Size(327, 241);
            // 
            // fecOperacionLabel
            // 
            fecOperacionLabel.AutoSize = true;
            fecOperacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fecOperacionLabel.Location = new System.Drawing.Point(11, 24);
            fecOperacionLabel.Name = "fecOperacionLabel";
            fecOperacionLabel.Size = new System.Drawing.Size(38, 13);
            fecOperacionLabel.TabIndex = 104;
            fecOperacionLabel.Text = "Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(144, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 13);
            label2.TabIndex = 106;
            label2.Text = "Hasta";
            // 
            // dgvOC
            // 
            this.dgvOC.AllowUserToAddRows = false;
            this.dgvOC.AllowUserToDeleteRows = false;
            this.dgvOC.AutoGenerateColumns = false;
            this.dgvOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idHojaCostoDataGridViewTextBoxColumn,
            this.idOrdenCompraDataGridViewTextBoxColumn,
            this.Fecha});
            this.dgvOC.DataSource = this.bsBase;
            this.dgvOC.Location = new System.Drawing.Point(6, 15);
            this.dgvOC.Name = "dgvOC";
            this.dgvOC.ReadOnly = true;
            this.dgvOC.Size = new System.Drawing.Size(314, 220);
            this.dgvOC.TabIndex = 0;
            this.dgvOC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOC_CellDoubleClick);
            this.dgvOC.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvOC_CellPainting);
            // 
            // idHojaCostoDataGridViewTextBoxColumn
            // 
            this.idHojaCostoDataGridViewTextBoxColumn.DataPropertyName = "idHojaCosto";
            this.idHojaCostoDataGridViewTextBoxColumn.HeaderText = "Nro. H.C.";
            this.idHojaCostoDataGridViewTextBoxColumn.Name = "idHojaCostoDataGridViewTextBoxColumn";
            this.idHojaCostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idHojaCostoDataGridViewTextBoxColumn.ToolTipText = "Número de Hoja de Costos";
            this.idHojaCostoDataGridViewTextBoxColumn.Width = 85;
            // 
            // idOrdenCompraDataGridViewTextBoxColumn
            // 
            this.idOrdenCompraDataGridViewTextBoxColumn.DataPropertyName = "idOrdenCompra";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idOrdenCompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idOrdenCompraDataGridViewTextBoxColumn.HeaderText = "Nro. O.C.";
            this.idOrdenCompraDataGridViewTextBoxColumn.Name = "idOrdenCompraDataGridViewTextBoxColumn";
            this.idOrdenCompraDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOrdenCompraDataGridViewTextBoxColumn.ToolTipText = "Número de Orden de Compra";
            this.idOrdenCompraDataGridViewTextBoxColumn.Width = 85;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 90;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.CustomFormat = "dd/MM/yyyy";
            this.dtpFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecIni.Location = new System.Drawing.Point(50, 20);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(92, 20);
            this.dtpFecIni.TabIndex = 103;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFin.Location = new System.Drawing.Point(181, 20);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(92, 20);
            this.dtpFecFin.TabIndex = 105;
            // 
            // frmBuscarHojaDeCostoOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 333);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(label2);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(fecOperacionLabel);
            this.Name = "frmBuscarHojaDeCostoOC";
            this.Text = "Busquedas de Hojas de Costo";
            this.Load += new System.EventHandler(this.frmBuscarHojaDeCostoOC_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(fecOperacionLabel, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(label2, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOC;
        private System.Windows.Forms.DateTimePicker dtpFecIni;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHojaCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}