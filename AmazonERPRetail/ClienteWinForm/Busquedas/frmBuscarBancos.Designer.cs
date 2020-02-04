namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarBancos
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
            this.dgvBancos = new System.Windows.Forms.DataGridView();
            this.idPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaComercialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancos)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.BancosE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(90, 256);
            this.btnAceptar.Size = new System.Drawing.Size(111, 27);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(207, 256);
            this.btnCancelar.Size = new System.Drawing.Size(111, 27);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(570, 12);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(765, 12);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(765, 41);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(765, 64);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvBancos);
            this.gbResultados.Location = new System.Drawing.Point(5, 3);
            this.gbResultados.Size = new System.Drawing.Size(383, 248);
            // 
            // dgvBancos
            // 
            this.dgvBancos.AccessibleDescription = "";
            this.dgvBancos.AllowUserToAddRows = false;
            this.dgvBancos.AllowUserToDeleteRows = false;
            this.dgvBancos.AutoGenerateColumns = false;
            this.dgvBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBancos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPersona,
            this.siglaComercialDataGridViewTextBoxColumn});
            this.dgvBancos.DataSource = this.bsBase;
            this.dgvBancos.EnableHeadersVisualStyles = false;
            this.dgvBancos.Location = new System.Drawing.Point(5, 14);
            this.dgvBancos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBancos.Name = "dgvBancos";
            this.dgvBancos.ReadOnly = true;
            this.dgvBancos.RowTemplate.Height = 24;
            this.dgvBancos.Size = new System.Drawing.Size(373, 229);
            this.dgvBancos.TabIndex = 9;
            this.dgvBancos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBancos_CellDoubleClick);
            this.dgvBancos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBancos_CellPainting);
            // 
            // idPersona
            // 
            this.idPersona.DataPropertyName = "idPersona";
            this.idPersona.HeaderText = "ID.";
            this.idPersona.Name = "idPersona";
            this.idPersona.ReadOnly = true;
            this.idPersona.Width = 40;
            // 
            // siglaComercialDataGridViewTextBoxColumn
            // 
            this.siglaComercialDataGridViewTextBoxColumn.DataPropertyName = "SiglaComercial";
            this.siglaComercialDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.siglaComercialDataGridViewTextBoxColumn.Name = "siglaComercialDataGridViewTextBoxColumn";
            this.siglaComercialDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaComercialDataGridViewTextBoxColumn.Width = 300;
            // 
            // frmBuscarBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 288);
            this.Name = "frmBuscarBancos";
            this.Text = "Busqueda de Bancos";
            this.Load += new System.EventHandler(this.frmBuscarBancos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBancos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaComercialDataGridViewTextBoxColumn;
    }
}