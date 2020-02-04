namespace ClienteWinForm.Ventas
{
    partial class frmCategoriaVendedorListado
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.indRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCatagoriaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codVendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desVendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCategoriaVendedor = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.chbVerDetalle = new System.Windows.Forms.CheckBox();
            this.txtBuscar = new ControlesWinForm.SuperTextBox();
            this.lblLetras = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategoriaVendedor)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListado);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(4, 68);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(769, 332);
            this.panel5.TabIndex = 10;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indRegistroDataGridViewTextBoxColumn,
            this.codCategoriaDataGridViewTextBoxColumn,
            this.desCategoriaDataGridViewTextBoxColumn,
            this.indCatagoriaDataGridViewCheckBoxColumn,
            this.codVendedorDataGridViewTextBoxColumn,
            this.desVendedorDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.bsCategoriaVendedor;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 18);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(767, 312);
            this.dgvListado.TabIndex = 250;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellDoubleClick);
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            // 
            // indRegistroDataGridViewTextBoxColumn
            // 
            this.indRegistroDataGridViewTextBoxColumn.DataPropertyName = "indRegistro";
            this.indRegistroDataGridViewTextBoxColumn.HeaderText = "indRegistro";
            this.indRegistroDataGridViewTextBoxColumn.Name = "indRegistroDataGridViewTextBoxColumn";
            this.indRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.indRegistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // codCategoriaDataGridViewTextBoxColumn
            // 
            this.codCategoriaDataGridViewTextBoxColumn.DataPropertyName = "codCategoria";
            this.codCategoriaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codCategoriaDataGridViewTextBoxColumn.Name = "codCategoriaDataGridViewTextBoxColumn";
            this.codCategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCategoriaDataGridViewTextBoxColumn.Width = 60;
            // 
            // desCategoriaDataGridViewTextBoxColumn
            // 
            this.desCategoriaDataGridViewTextBoxColumn.DataPropertyName = "desCategoria";
            this.desCategoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.desCategoriaDataGridViewTextBoxColumn.Name = "desCategoriaDataGridViewTextBoxColumn";
            this.desCategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.desCategoriaDataGridViewTextBoxColumn.Width = 180;
            // 
            // indCatagoriaDataGridViewCheckBoxColumn
            // 
            this.indCatagoriaDataGridViewCheckBoxColumn.DataPropertyName = "indCatagoria";
            this.indCatagoriaDataGridViewCheckBoxColumn.HeaderText = "Todos";
            this.indCatagoriaDataGridViewCheckBoxColumn.Name = "indCatagoriaDataGridViewCheckBoxColumn";
            this.indCatagoriaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indCatagoriaDataGridViewCheckBoxColumn.Width = 45;
            // 
            // codVendedorDataGridViewTextBoxColumn
            // 
            this.codVendedorDataGridViewTextBoxColumn.DataPropertyName = "codVendedor";
            this.codVendedorDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codVendedorDataGridViewTextBoxColumn.Name = "codVendedorDataGridViewTextBoxColumn";
            this.codVendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.codVendedorDataGridViewTextBoxColumn.Width = 70;
            // 
            // desVendedorDataGridViewTextBoxColumn
            // 
            this.desVendedorDataGridViewTextBoxColumn.DataPropertyName = "desVendedor";
            this.desVendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor";
            this.desVendedorDataGridViewTextBoxColumn.Name = "desVendedorDataGridViewTextBoxColumn";
            this.desVendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.desVendedorDataGridViewTextBoxColumn.Width = 250;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "F. Registro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "F. Modificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsCategoriaVendedor
            // 
            this.bsCategoriaVendedor.DataSource = typeof(Entidades.Ventas.CategoriaVendedorE);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblLetras);
            this.panel4.Controls.Add(this.chbVerDetalle);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(769, 62);
            this.panel4.TabIndex = 6;
            // 
            // chbVerDetalle
            // 
            this.chbVerDetalle.AutoSize = true;
            this.chbVerDetalle.Location = new System.Drawing.Point(609, 29);
            this.chbVerDetalle.Name = "chbVerDetalle";
            this.chbVerDetalle.Size = new System.Drawing.Size(137, 17);
            this.chbVerDetalle.TabIndex = 250;
            this.chbVerDetalle.Text = "Ver Categorias y Lineas";
            this.chbVerDetalle.UseVisualStyleBackColor = true;
            this.chbVerDetalle.CheckedChanged += new System.EventHandler(this.chbVerDetalle_CheckedChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtBuscar.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(9, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(579, 21);
            this.txtBuscar.TabIndex = 249;
            this.txtBuscar.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtBuscar.TextoVacio = "Ingrese texto a buscar";
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(767, 18);
            this.lblLetras.TabIndex = 1572;
            this.lblLetras.Text = "Parámetros de Búsqueda";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(767, 18);
            this.lblRegistros.TabIndex = 1572;
            this.lblRegistros.Text = "Categorias";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCategoriaVendedorListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 403);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Name = "frmCategoriaVendedorListado";
            this.Text = "Categoria Vendedor";
            this.Load += new System.EventHandler(this.frmCategoriaVendedorListado_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategoriaVendedor)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private ControlesWinForm.SuperTextBox txtBuscar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.BindingSource bsCategoriaVendedor;
        private System.Windows.Forms.CheckBox chbVerDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn indRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCatagoriaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codVendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desVendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblLetras;
    }
}