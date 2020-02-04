namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarTipoCondicionTraslado
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
            this.dgvCondiciones = new System.Windows.Forms.DataGridView();
            this.idTrasladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTrasladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagFactDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flagCtaCteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ponerCeroVentaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.indAlmacenDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Ventas.TipoTrasladoE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(260, 238);
            this.btnAceptar.Size = new System.Drawing.Size(100, 27);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(366, 238);
            this.btnCancelar.Size = new System.Drawing.Size(100, 27);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1005, 62);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(870, 58);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(571, 61);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(571, 84);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvCondiciones);
            this.gbResultados.Location = new System.Drawing.Point(6, 3);
            this.gbResultados.Size = new System.Drawing.Size(461, 229);
            // 
            // dgvCondiciones
            // 
            this.dgvCondiciones.AllowUserToAddRows = false;
            this.dgvCondiciones.AllowUserToDeleteRows = false;
            this.dgvCondiciones.AutoGenerateColumns = false;
            this.dgvCondiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTrasladoDataGridViewTextBoxColumn,
            this.desTrasladoDataGridViewTextBoxColumn,
            this.flagFactDataGridViewCheckBoxColumn,
            this.flagCtaCteDataGridViewCheckBoxColumn,
            this.ponerCeroVentaDataGridViewCheckBoxColumn,
            this.indAlmacenDataGridViewCheckBoxColumn});
            this.dgvCondiciones.DataSource = this.bsBase;
            this.dgvCondiciones.EnableHeadersVisualStyles = false;
            this.dgvCondiciones.Location = new System.Drawing.Point(9, 17);
            this.dgvCondiciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCondiciones.Name = "dgvCondiciones";
            this.dgvCondiciones.ReadOnly = true;
            this.dgvCondiciones.RowTemplate.Height = 24;
            this.dgvCondiciones.Size = new System.Drawing.Size(444, 204);
            this.dgvCondiciones.TabIndex = 2;
            this.dgvCondiciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCondiciones_CellDoubleClick);
            this.dgvCondiciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCondiciones_CellFormatting);
            this.dgvCondiciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCondiciones_CellPainting);
            // 
            // idTrasladoDataGridViewTextBoxColumn
            // 
            this.idTrasladoDataGridViewTextBoxColumn.DataPropertyName = "idTraslado";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idTrasladoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idTrasladoDataGridViewTextBoxColumn.HeaderText = "Cód.";
            this.idTrasladoDataGridViewTextBoxColumn.Name = "idTrasladoDataGridViewTextBoxColumn";
            this.idTrasladoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desTrasladoDataGridViewTextBoxColumn
            // 
            this.desTrasladoDataGridViewTextBoxColumn.DataPropertyName = "desTraslado";
            this.desTrasladoDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.desTrasladoDataGridViewTextBoxColumn.Name = "desTrasladoDataGridViewTextBoxColumn";
            this.desTrasladoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flagFactDataGridViewCheckBoxColumn
            // 
            this.flagFactDataGridViewCheckBoxColumn.DataPropertyName = "flagFact";
            this.flagFactDataGridViewCheckBoxColumn.HeaderText = "flagFact";
            this.flagFactDataGridViewCheckBoxColumn.Name = "flagFactDataGridViewCheckBoxColumn";
            this.flagFactDataGridViewCheckBoxColumn.ReadOnly = true;
            this.flagFactDataGridViewCheckBoxColumn.Visible = false;
            // 
            // flagCtaCteDataGridViewCheckBoxColumn
            // 
            this.flagCtaCteDataGridViewCheckBoxColumn.DataPropertyName = "flagCtaCte";
            this.flagCtaCteDataGridViewCheckBoxColumn.HeaderText = "flagCtaCte";
            this.flagCtaCteDataGridViewCheckBoxColumn.Name = "flagCtaCteDataGridViewCheckBoxColumn";
            this.flagCtaCteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.flagCtaCteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // ponerCeroVentaDataGridViewCheckBoxColumn
            // 
            this.ponerCeroVentaDataGridViewCheckBoxColumn.DataPropertyName = "PonerCeroVenta";
            this.ponerCeroVentaDataGridViewCheckBoxColumn.HeaderText = "PonerCeroVenta";
            this.ponerCeroVentaDataGridViewCheckBoxColumn.Name = "ponerCeroVentaDataGridViewCheckBoxColumn";
            this.ponerCeroVentaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.ponerCeroVentaDataGridViewCheckBoxColumn.Visible = false;
            // 
            // indAlmacenDataGridViewCheckBoxColumn
            // 
            this.indAlmacenDataGridViewCheckBoxColumn.DataPropertyName = "indAlmacen";
            this.indAlmacenDataGridViewCheckBoxColumn.HeaderText = "indAlmacen";
            this.indAlmacenDataGridViewCheckBoxColumn.Name = "indAlmacenDataGridViewCheckBoxColumn";
            this.indAlmacenDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indAlmacenDataGridViewCheckBoxColumn.Visible = false;
            // 
            // frmBuscarTipoCondicionTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 269);
            this.Name = "frmBuscarTipoCondicionTraslado";
            this.Text = "Condiciones de Traslado";
            this.Load += new System.EventHandler(this.frmBuscarTipoCondicionTraslado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCondiciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTrasladoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTrasladoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagFactDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagCtaCteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ponerCeroVentaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indAlmacenDataGridViewCheckBoxColumn;
    }
}