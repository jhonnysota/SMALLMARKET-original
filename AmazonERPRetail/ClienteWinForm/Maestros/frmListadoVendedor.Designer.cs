namespace ClienteWinForm.Maestros
{
    partial class frmListadoVendedor
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIndBaja = new System.Windows.Forms.CheckBox();
            this.txtcodigo = new ControlesWinForm.SuperTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvVendedor = new System.Windows.Forms.DataGridView();
            this.codVendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApePaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApeMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indEstadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fecBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsClientes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verCarteraVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bsVendedor = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedor)).BeginInit();
            this.cmsClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chkIndBaja);
            this.panel2.Controls.Add(this.txtcodigo);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 60);
            this.panel2.TabIndex = 71;
            // 
            // chkIndBaja
            // 
            this.chkIndBaja.AutoSize = true;
            this.chkIndBaja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndBaja.Location = new System.Drawing.Point(660, 32);
            this.chkIndBaja.Name = "chkIndBaja";
            this.chkIndBaja.Size = new System.Drawing.Size(139, 17);
            this.chkIndBaja.TabIndex = 270;
            this.chkIndBaja.Text = "Vendedores De Baja";
            this.chkIndBaja.UseVisualStyleBackColor = true;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtcodigo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtcodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(39, 29);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(601, 20);
            this.txtcodigo.TabIndex = 20;
            this.txtcodigo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtcodigo.TextoVacio = " Ingrese Código Vendedor";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvVendedor);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Location = new System.Drawing.Point(4, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 364);
            this.panel1.TabIndex = 72;
            // 
            // dgvVendedor
            // 
            this.dgvVendedor.AllowUserToAddRows = false;
            this.dgvVendedor.AllowUserToDeleteRows = false;
            this.dgvVendedor.AutoGenerateColumns = false;
            this.dgvVendedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codVendedorDataGridViewTextBoxColumn,
            this.NroDocumento,
            this.Nombres,
            this.ApePaterno,
            this.ApeMaterno,
            this.indEstadoDataGridViewCheckBoxColumn,
            this.fecBajaDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvVendedor.ContextMenuStrip = this.cmsClientes;
            this.dgvVendedor.DataSource = this.bsVendedor;
            this.dgvVendedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedor.EnableHeadersVisualStyles = false;
            this.dgvVendedor.Location = new System.Drawing.Point(0, 18);
            this.dgvVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVendedor.Name = "dgvVendedor";
            this.dgvVendedor.ReadOnly = true;
            this.dgvVendedor.RowTemplate.Height = 24;
            this.dgvVendedor.Size = new System.Drawing.Size(896, 344);
            this.dgvVendedor.TabIndex = 80;
            this.dgvVendedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedor_CellDoubleClick);
            this.dgvVendedor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVendedor_CellFormatting);
            // 
            // codVendedorDataGridViewTextBoxColumn
            // 
            this.codVendedorDataGridViewTextBoxColumn.DataPropertyName = "codVendedor";
            this.codVendedorDataGridViewTextBoxColumn.HeaderText = "Codigo Ven.";
            this.codVendedorDataGridViewTextBoxColumn.Name = "codVendedorDataGridViewTextBoxColumn";
            this.codVendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.codVendedorDataGridViewTextBoxColumn.Width = 90;
            // 
            // NroDocumento
            // 
            this.NroDocumento.DataPropertyName = "NroDocumento";
            this.NroDocumento.HeaderText = "DNI";
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.ReadOnly = true;
            this.NroDocumento.Width = 80;
            // 
            // Nombres
            // 
            this.Nombres.DataPropertyName = "Nombres";
            this.Nombres.HeaderText = "Nombres";
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            this.Nombres.Width = 120;
            // 
            // ApePaterno
            // 
            this.ApePaterno.DataPropertyName = "ApePaterno";
            this.ApePaterno.HeaderText = "Ape. Paterno";
            this.ApePaterno.Name = "ApePaterno";
            this.ApePaterno.ReadOnly = true;
            this.ApePaterno.Width = 90;
            // 
            // ApeMaterno
            // 
            this.ApeMaterno.DataPropertyName = "ApeMaterno";
            this.ApeMaterno.HeaderText = "Ape. Materno";
            this.ApeMaterno.Name = "ApeMaterno";
            this.ApeMaterno.ReadOnly = true;
            this.ApeMaterno.Width = 90;
            // 
            // indEstadoDataGridViewCheckBoxColumn
            // 
            this.indEstadoDataGridViewCheckBoxColumn.DataPropertyName = "indEstado";
            this.indEstadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            this.indEstadoDataGridViewCheckBoxColumn.Name = "indEstadoDataGridViewCheckBoxColumn";
            this.indEstadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indEstadoDataGridViewCheckBoxColumn.Width = 50;
            // 
            // fecBajaDataGridViewTextBoxColumn
            // 
            this.fecBajaDataGridViewTextBoxColumn.DataPropertyName = "fecBaja";
            this.fecBajaDataGridViewTextBoxColumn.HeaderText = "Fec. Baja";
            this.fecBajaDataGridViewTextBoxColumn.Name = "fecBajaDataGridViewTextBoxColumn";
            this.fecBajaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fecBajaDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "Usuario Reg.";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioRegistroDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Reg.";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 120;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "Usuario Mod.";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioModificacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // cmsClientes
            // 
            this.cmsClientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCarteraVendedorToolStripMenuItem});
            this.cmsClientes.Name = "cmsClientes";
            this.cmsClientes.Size = new System.Drawing.Size(185, 26);
            // 
            // verCarteraVendedorToolStripMenuItem
            // 
            this.verCarteraVendedorToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.report6;
            this.verCarteraVendedorToolStripMenuItem.Name = "verCarteraVendedorToolStripMenuItem";
            this.verCarteraVendedorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.verCarteraVendedorToolStripMenuItem.Text = "Ver Cartera Vendedor";
            this.verCarteraVendedorToolStripMenuItem.Click += new System.EventHandler(this.verCarteraVendedorToolStripMenuItem_Click);
            // 
            // bsVendedor
            // 
            this.bsVendedor.DataSource = typeof(Entidades.Maestros.VendedoresE);
            this.bsVendedor.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsVendedor_ListChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(896, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Parámetros de Búsqueda";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(896, 18);
            this.LblTitulo.TabIndex = 429;
            this.LblTitulo.Text = "Registros 0";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 433);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListadoVendedor";
            this.Text = "Listado de Vendedores";
            this.Load += new System.EventHandler(this.frmListadoClientes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedor)).EndInit();
            this.cmsClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsVendedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private ControlesWinForm.SuperTextBox txtcodigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvVendedor;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkIndBaja;
        private System.Windows.Forms.BindingSource bsVendedor;
        private System.Windows.Forms.ContextMenuStrip cmsClientes;
        private System.Windows.Forms.ToolStripMenuItem verCarteraVendedorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn codVendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApePaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApeMaterno;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indEstadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblTitulo;
    }
}