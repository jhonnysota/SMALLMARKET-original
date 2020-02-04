namespace ClienteWinForm.Generales.Busqueda
{
    partial class FrmBusquedaParametro
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
            this.parametroDataGridView = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDecimalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorCadenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametroDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceBase
            // 
            this.bsBase.DataSource = typeof(Entidades.Generales.ParametroE);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuBar;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnAceptar.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnAceptar.Location = new System.Drawing.Point(443, 347);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            // 
            // btnCanceñar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuBar;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnCancelar.Location = new System.Drawing.Point(571, 347);
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnBuscar.Location = new System.Drawing.Point(596, 16);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Font = new System.Drawing.Font("Calibri", 11F);
            this.chkAnulado.Location = new System.Drawing.Point(463, 16);
            this.chkAnulado.Size = new System.Drawing.Size(127, 22);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Size = new System.Drawing.Size(232, 18);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(12, 39);
            this.txtFiltro.Size = new System.Drawing.Size(463, 21);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.parametroDataGridView);
            this.gbResultados.Font = new System.Drawing.Font("Calibri", 10F);
            this.gbResultados.Location = new System.Drawing.Point(12, 70);
            this.gbResultados.Size = new System.Drawing.Size(665, 269);
            // 
            // parametroDataGridView
            // 
            this.parametroDataGridView.AllowUserToAddRows = false;
            this.parametroDataGridView.AllowUserToDeleteRows = false;
            this.parametroDataGridView.AllowUserToResizeColumns = false;
            this.parametroDataGridView.AllowUserToResizeRows = false;
            this.parametroDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parametroDataGridView.AutoGenerateColumns = false;
            this.parametroDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametroDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.Descripcion,
            this.valorDecimalDataGridViewTextBoxColumn,
            this.valorCadenaDataGridViewTextBoxColumn,
            this.estadoDataGridViewCheckBoxColumn});
            this.parametroDataGridView.DataSource = this.bsBase;
            this.parametroDataGridView.Location = new System.Drawing.Point(1, 18);
            this.parametroDataGridView.MultiSelect = false;
            this.parametroDataGridView.Name = "parametroDataGridView";
            this.parametroDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parametroDataGridView.Size = new System.Drawing.Size(660, 251);
            this.parametroDataGridView.TabIndex = 0;
            this.parametroDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.parametroDataGridView_CellContentDoubleClick);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 140;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 180;
            // 
            // valorDecimalDataGridViewTextBoxColumn
            // 
            this.valorDecimalDataGridViewTextBoxColumn.DataPropertyName = "ValorDecimal";
            this.valorDecimalDataGridViewTextBoxColumn.HeaderText = "Valor Dec.";
            this.valorDecimalDataGridViewTextBoxColumn.Name = "valorDecimalDataGridViewTextBoxColumn";
            // 
            // valorCadenaDataGridViewTextBoxColumn
            // 
            this.valorCadenaDataGridViewTextBoxColumn.DataPropertyName = "ValorCadena";
            this.valorCadenaDataGridViewTextBoxColumn.HeaderText = "Valor Cad.";
            this.valorCadenaDataGridViewTextBoxColumn.Name = "valorCadenaDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewCheckBoxColumn
            // 
            this.estadoDataGridViewCheckBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            this.estadoDataGridViewCheckBoxColumn.Width = 80;
            // 
            // FrmBusquedaParametro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 385);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBusquedaParametro";
            this.Text = "BUSQUEDA DE PARAMETRO";
            this.Load += new System.EventHandler(this.FrmBusquedaParametro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parametroDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView parametroDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDecimalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCadenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn;
    }
}