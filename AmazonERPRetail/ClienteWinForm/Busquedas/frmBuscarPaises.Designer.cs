namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarPaises
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
            this.dgvPais = new System.Windows.Forms.DataGridView();
            this.idPaisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gentilicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoSunatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPais = new ControlesWinForm.SuperTextBox();
            this.lblLetras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPais)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.AllowNew = true;
            this.bsBase.DataSource = typeof(Entidades.Generales.PaisesE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(136, 245);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(242, 245);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(39, 330);
            this.btnBuscar.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(335, 386);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 389);
            this.label1.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(36, 412);
            this.txtFiltro.Visible = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvPais);
            this.gbResultados.Location = new System.Drawing.Point(0, 63);
            this.gbResultados.Size = new System.Drawing.Size(343, 178);
            // 
            // dgvPais
            // 
            this.dgvPais.AllowUserToAddRows = false;
            this.dgvPais.AllowUserToDeleteRows = false;
            this.dgvPais.AutoGenerateColumns = false;
            this.dgvPais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPaisDataGridViewTextBoxColumn,
            this.Gentilicio,
            this.nombreDataGridViewTextBoxColumn,
            this.codigoSunatDataGridViewTextBoxColumn});
            this.dgvPais.DataSource = this.bsBase;
            this.dgvPais.EnableHeadersVisualStyles = false;
            this.dgvPais.Location = new System.Drawing.Point(6, 15);
            this.dgvPais.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPais.Name = "dgvPais";
            this.dgvPais.ReadOnly = true;
            this.dgvPais.RowTemplate.Height = 24;
            this.dgvPais.Size = new System.Drawing.Size(331, 158);
            this.dgvPais.TabIndex = 1;
            this.dgvPais.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPais_CellDoubleClick);
            this.dgvPais.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPais_CellPainting);
            // 
            // idPaisDataGridViewTextBoxColumn
            // 
            this.idPaisDataGridViewTextBoxColumn.DataPropertyName = "idPais";
            this.idPaisDataGridViewTextBoxColumn.HeaderText = "Pais";
            this.idPaisDataGridViewTextBoxColumn.Name = "idPaisDataGridViewTextBoxColumn";
            this.idPaisDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPaisDataGridViewTextBoxColumn.Width = 30;
            // 
            // Gentilicio
            // 
            this.Gentilicio.DataPropertyName = "Gentilicio";
            this.Gentilicio.HeaderText = "Gentilicio";
            this.Gentilicio.Name = "Gentilicio";
            this.Gentilicio.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoSunatDataGridViewTextBoxColumn
            // 
            this.codigoSunatDataGridViewTextBoxColumn.DataPropertyName = "CodigoSunat";
            this.codigoSunatDataGridViewTextBoxColumn.HeaderText = "CodigoSunat";
            this.codigoSunatDataGridViewTextBoxColumn.Name = "codigoSunatDataGridViewTextBoxColumn";
            this.codigoSunatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblLetras);
            this.panel2.Controls.Add(this.txtPais);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 58);
            this.panel2.TabIndex = 77;
            // 
            // txtPais
            // 
            this.txtPais.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtPais.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPais.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Location = new System.Drawing.Point(10, 27);
            this.txtPais.Margin = new System.Windows.Forms.Padding(2);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(316, 20);
            this.txtPais.TabIndex = 20;
            this.txtPais.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPais.TextoVacio = "Ingrese Nombre Pais";
            this.txtPais.TextChanged += new System.EventHandler(this.txtPais_TextChanged);
            this.txtPais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPais_KeyDown);
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(341, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBuscarPaises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 285);
            this.Controls.Add(this.panel2);
            this.Name = "frmBuscarPaises";
            this.Text = "Buscar Pais";
            this.Load += new System.EventHandler(this.frmBuscarPaises_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPais)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPais;
        private System.Windows.Forms.Panel panel2;
        private ControlesWinForm.SuperTextBox txtPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPaisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gentilicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoSunatDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblLetras;
    }
}