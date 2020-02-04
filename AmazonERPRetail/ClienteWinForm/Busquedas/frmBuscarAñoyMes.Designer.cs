namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarAñoyMes
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
            this.components = new System.ComponentModel.Container();
            this.bsEstadoPlanilla = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAnioYmes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEstadoPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnioYmes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.Location = new System.Drawing.Point(123, 210);
            this.btnAceptar.Size = new System.Drawing.Size(104, 24);
            this.btnAceptar.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(231, 210);
            this.btnCancelar.Size = new System.Drawing.Size(104, 24);
            this.btnCancelar.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnBuscar.Location = new System.Drawing.Point(340, 29);
            this.btnBuscar.Size = new System.Drawing.Size(94, 48);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Font = new System.Drawing.Font("Calibri", 11F);
            this.chkAnulado.Location = new System.Drawing.Point(709, 83);
            this.chkAnulado.Size = new System.Drawing.Size(127, 22);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.Location = new System.Drawing.Point(688, 84);
            this.label1.Size = new System.Drawing.Size(232, 18);
            this.label1.TabIndex = 0;
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Calibri", 11F);
            this.txtFiltro.Location = new System.Drawing.Point(696, 81);
            this.txtFiltro.Size = new System.Drawing.Size(185, 25);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvAnioYmes);
            this.gbResultados.Location = new System.Drawing.Point(12, 12);
            this.gbResultados.Size = new System.Drawing.Size(322, 192);
            this.gbResultados.TabIndex = 3;
            // 
            // dgvAnioYmes
            // 
            this.dgvAnioYmes.AllowUserToAddRows = false;
            this.dgvAnioYmes.AllowUserToDeleteRows = false;
            this.dgvAnioYmes.AutoGenerateColumns = false;
            this.dgvAnioYmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnioYmes.DataSource = this.bsEstadoPlanilla;
            this.dgvAnioYmes.Location = new System.Drawing.Point(15, 19);
            this.dgvAnioYmes.Name = "dgvAnioYmes";
            this.dgvAnioYmes.ReadOnly = true;
            this.dgvAnioYmes.Size = new System.Drawing.Size(287, 167);
            this.dgvAnioYmes.TabIndex = 0;
            this.dgvAnioYmes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnioYmes_CellDoubleClick);
            this.dgvAnioYmes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAnioYmes_CellPainting);
            // 
            // frmBuscarAñoyMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 253);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBuscarAñoyMes";
            this.Text = "Busqueda Año y Mes";
            this.Load += new System.EventHandler(this.FrmBuscarAñoyMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsEstadoPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnioYmes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsEstadoPlanilla;
        private System.Windows.Forms.DataGridView dgvAnioYmes;
        private System.Windows.Forms.DataGridViewTextBoxColumn codAnnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn declaradoDataGridViewCheckBoxColumn;
    }
}