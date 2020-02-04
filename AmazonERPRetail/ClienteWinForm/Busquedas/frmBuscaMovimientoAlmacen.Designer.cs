namespace ClienteWinForm.Busquedas
{
    partial class frmBuscaMovimientoAlmacen
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
            this.dgvMovAlm = new System.Windows.Forms.DataGridView();
            this.idDocumentoAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Guia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correlativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovAlm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(236, 256);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(342, 256);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(410, 367);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(302, 363);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 366);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(3, 389);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvMovAlm);
            this.gbResultados.Location = new System.Drawing.Point(3, -2);
            this.gbResultados.Size = new System.Drawing.Size(463, 252);
            // 
            // dgvMovAlm
            // 
            this.dgvMovAlm.AllowUserToAddRows = false;
            this.dgvMovAlm.AllowUserToDeleteRows = false;
            this.dgvMovAlm.AutoGenerateColumns = false;
            this.dgvMovAlm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovAlm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocumentoAlmacen,
            this.Guia,
            this.RazonSocial,
            this.Correlativo});
            this.dgvMovAlm.DataSource = this.bsBase;
            this.dgvMovAlm.EnableHeadersVisualStyles = false;
            this.dgvMovAlm.Location = new System.Drawing.Point(5, 14);
            this.dgvMovAlm.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMovAlm.Name = "dgvMovAlm";
            this.dgvMovAlm.ReadOnly = true;
            this.dgvMovAlm.RowTemplate.Height = 24;
            this.dgvMovAlm.Size = new System.Drawing.Size(453, 232);
            this.dgvMovAlm.TabIndex = 2;
            this.dgvMovAlm.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovAlm_CellDoubleClick);
            this.dgvMovAlm.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMovAlm_CellPainting);
            // 
            // idDocumentoAlmacen
            // 
            this.idDocumentoAlmacen.DataPropertyName = "idDocumentoAlmacen";
            this.idDocumentoAlmacen.HeaderText = "Nro.";
            this.idDocumentoAlmacen.Name = "idDocumentoAlmacen";
            this.idDocumentoAlmacen.ReadOnly = true;
            this.idDocumentoAlmacen.Width = 60;
            // 
            // Guia
            // 
            this.Guia.DataPropertyName = "Guia";
            this.Guia.HeaderText = "Guia";
            this.Guia.Name = "Guia";
            this.Guia.ReadOnly = true;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razon Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            // 
            // Correlativo
            // 
            this.Correlativo.DataPropertyName = "Correlativo";
            this.Correlativo.HeaderText = "Correlativo";
            this.Correlativo.Name = "Correlativo";
            this.Correlativo.ReadOnly = true;
            // 
            // frmBuscaMovimientoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 295);
            this.Name = "frmBuscaMovimientoAlmacen";
            this.Text = "Movimientos de Almacen";
            this.Load += new System.EventHandler(this.frmBuscaMovimientoAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovAlm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovAlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumentoAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guia;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correlativo;
    }
}