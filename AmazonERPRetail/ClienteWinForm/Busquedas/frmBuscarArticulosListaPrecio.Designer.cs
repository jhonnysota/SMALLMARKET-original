namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarArticulosListaPrecio
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
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.idArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomUMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomUMedidaEnv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoArticulo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Maestros.ArticuloServE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnAceptar.Location = new System.Drawing.Point(286, 318);
            this.btnAceptar.Size = new System.Drawing.Size(124, 26);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnCancelar.Location = new System.Drawing.Point(420, 318);
            this.btnCancelar.Size = new System.Drawing.Size(124, 26);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(366, 9);
            this.btnBuscar.Size = new System.Drawing.Size(60, 43);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(664, 96);
            this.chkAnulado.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.Text = "Descripción";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(80, 32);
            this.txtFiltro.Size = new System.Drawing.Size(280, 20);
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.Controls.Add(this.dgvArticulo);
            this.gbResultados.Location = new System.Drawing.Point(5, 60);
            this.gbResultados.Size = new System.Drawing.Size(895, 252);
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.AllowUserToAddRows = false;
            this.dgvArticulo.AllowUserToDeleteRows = false;
            this.dgvArticulo.AllowUserToResizeColumns = false;
            this.dgvArticulo.AllowUserToResizeRows = false;
            this.dgvArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulo.AutoGenerateColumns = false;
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idArticulo,
            this.codArticulo,
            this.nomArticulo,
            this.Stock,
            this.Lote,
            this.PrecioBruto,
            this.nomUMedida,
            this.nomUMedidaEnv,
            this.Contenido});
            this.dgvArticulo.DataSource = this.bsBase;
            this.dgvArticulo.Location = new System.Drawing.Point(7, 15);
            this.dgvArticulo.MultiSelect = false;
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.ReadOnly = true;
            this.dgvArticulo.RowHeadersVisible = false;
            this.dgvArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulo.Size = new System.Drawing.Size(881, 230);
            this.dgvArticulo.TabIndex = 2;
            this.dgvArticulo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulo_CellDoubleClick);
            this.dgvArticulo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvArticulo_CellPainting);
            // 
            // idArticulo
            // 
            this.idArticulo.DataPropertyName = "idArticulo";
            this.idArticulo.HeaderText = "ID";
            this.idArticulo.Name = "idArticulo";
            this.idArticulo.ReadOnly = true;
            this.idArticulo.Width = 40;
            // 
            // codArticulo
            // 
            this.codArticulo.DataPropertyName = "codArticulo";
            this.codArticulo.HeaderText = "Cód.Arti.";
            this.codArticulo.Name = "codArticulo";
            this.codArticulo.ReadOnly = true;
            this.codArticulo.Width = 90;
            // 
            // nomArticulo
            // 
            this.nomArticulo.DataPropertyName = "nomArticulo";
            this.nomArticulo.HeaderText = "Descripción";
            this.nomArticulo.Name = "nomArticulo";
            this.nomArticulo.ReadOnly = true;
            this.nomArticulo.Width = 400;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.Stock.DefaultCellStyle = dataGridViewCellStyle1;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 80;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            // 
            // PrecioBruto
            // 
            this.PrecioBruto.DataPropertyName = "PrecioBruto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.PrecioBruto.DefaultCellStyle = dataGridViewCellStyle2;
            this.PrecioBruto.HeaderText = "Precio B.";
            this.PrecioBruto.Name = "PrecioBruto";
            this.PrecioBruto.ReadOnly = true;
            this.PrecioBruto.Width = 80;
            // 
            // nomUMedida
            // 
            this.nomUMedida.DataPropertyName = "nomUMedida";
            this.nomUMedida.HeaderText = "Nom.U.M.A.";
            this.nomUMedida.Name = "nomUMedida";
            this.nomUMedida.ReadOnly = true;
            // 
            // nomUMedidaEnv
            // 
            this.nomUMedidaEnv.DataPropertyName = "nomUMedidaEnv";
            this.nomUMedidaEnv.HeaderText = "Nom.U.M.D.";
            this.nomUMedidaEnv.Name = "nomUMedidaEnv";
            this.nomUMedidaEnv.ReadOnly = true;
            // 
            // Contenido
            // 
            this.Contenido.DataPropertyName = "Contenido";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Contenido.DefaultCellStyle = dataGridViewCellStyle3;
            this.Contenido.HeaderText = "Contenido";
            this.Contenido.Name = "Contenido";
            this.Contenido.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 262;
            this.label2.Text = "Tipo Articulo";
            // 
            // cboTipoArticulo
            // 
            this.cboTipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoArticulo.FormattingEnabled = true;
            this.cboTipoArticulo.Location = new System.Drawing.Point(80, 9);
            this.cboTipoArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoArticulo.Name = "cboTipoArticulo";
            this.cboTipoArticulo.Size = new System.Drawing.Size(280, 21);
            this.cboTipoArticulo.TabIndex = 261;
            this.cboTipoArticulo.SelectionChangeCommitted += new System.EventHandler(this.cboTipoArticulo_SelectionChangeCommitted);
            // 
            // frmBuscarArticulosListaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipoArticulo);
            this.Location = new System.Drawing.Point(14, 12);
            this.Name = "frmBuscarArticulosListaPrecio";
            this.Text = "Búsqueda de Articulos por Lista de Precio";
            this.Load += new System.EventHandler(this.frmBuscarArticulosListaPrecio_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkAnulado, 0);
            this.Controls.SetChildIndex(this.gbResultados, 0);
            this.Controls.SetChildIndex(this.cboTipoArticulo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomUMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomUMedidaEnv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contenido;
    }
}