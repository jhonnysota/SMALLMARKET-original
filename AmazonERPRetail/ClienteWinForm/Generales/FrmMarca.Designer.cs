namespace ClienteWinForm.Generales
{
    partial class FrmMarca
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
            System.Windows.Forms.Label idMarcaLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label label3;
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.bsMarcasDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.txtIdMarca = new System.Windows.Forms.TextBox();
            this.txtFecModif = new System.Windows.Forms.TextBox();
            this.txtFecRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModif = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtNombreCorto = new System.Windows.Forms.TextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.idMarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMarcasListado = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bsSistemas = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSistemas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSistemas = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            idMarcaLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcasDetalle)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcasListado)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSistemas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSistemas)).BeginInit();
            this.pnlSistemas.SuspendLayout();
            this.SuspendLayout();
            // 
            // idMarcaLabel
            // 
            idMarcaLabel.AutoSize = true;
            idMarcaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idMarcaLabel.Location = new System.Drawing.Point(11, 38);
            idMarcaLabel.Name = "idMarcaLabel";
            idMarcaLabel.Size = new System.Drawing.Size(62, 13);
            idMarcaLabel.TabIndex = 0;
            idMarcaLabel.Text = "Cód. Marca";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(11, 60);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(44, 13);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(18, 37);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(18, 81);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 2;
            usuarioModificacionLabel.Text = "Usuario Modificación";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(18, 59);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 4;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(18, 103);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(11, 82);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 13);
            label3.TabIndex = 99;
            label3.Text = "Nombre Corto";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcasDetalle, "Nombre", true));
            this.txtNombre.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtNombre.Location = new System.Drawing.Point(86, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(198, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // bsMarcasDetalle
            // 
            this.bsMarcasDetalle.DataSource = typeof(Entidades.Generales.Marca);
            // 
            // txtIdMarca
            // 
            this.txtIdMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdMarca.Enabled = false;
            this.txtIdMarca.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtIdMarca.Location = new System.Drawing.Point(86, 35);
            this.txtIdMarca.Name = "txtIdMarca";
            this.txtIdMarca.Size = new System.Drawing.Size(79, 20);
            this.txtIdMarca.TabIndex = 1;
            // 
            // txtFecModif
            // 
            this.txtFecModif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecModif.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcasDetalle, "FechaModificacion", true));
            this.txtFecModif.Enabled = false;
            this.txtFecModif.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecModif.Location = new System.Drawing.Point(124, 99);
            this.txtFecModif.Name = "txtFecModif";
            this.txtFecModif.Size = new System.Drawing.Size(147, 20);
            this.txtFecModif.TabIndex = 7;
            // 
            // txtFecRegistro
            // 
            this.txtFecRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecRegistro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcasDetalle, "FechaRegistro", true));
            this.txtFecRegistro.Enabled = false;
            this.txtFecRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecRegistro.Location = new System.Drawing.Point(124, 55);
            this.txtFecRegistro.Name = "txtFecRegistro";
            this.txtFecRegistro.Size = new System.Drawing.Size(147, 20);
            this.txtFecRegistro.TabIndex = 5;
            // 
            // txtUsuarioModif
            // 
            this.txtUsuarioModif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModif.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcasDetalle, "UsuarioModificacion", true));
            this.txtUsuarioModif.Enabled = false;
            this.txtUsuarioModif.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModif.Location = new System.Drawing.Point(124, 77);
            this.txtUsuarioModif.Name = "txtUsuarioModif";
            this.txtUsuarioModif.Size = new System.Drawing.Size(147, 20);
            this.txtUsuarioModif.TabIndex = 3;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcasDetalle, "UsuarioRegistro", true));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(124, 33);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(147, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(label3);
            this.pnlDetalle.Controls.Add(this.txtNombreCorto);
            this.pnlDetalle.Controls.Add(nombreLabel);
            this.pnlDetalle.Controls.Add(this.txtIdMarca);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(idMarcaLabel);
            this.pnlDetalle.Location = new System.Drawing.Point(524, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(292, 114);
            this.pnlDetalle.TabIndex = 2;
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCorto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcasDetalle, "nombreCorto", true));
            this.txtNombreCorto.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtNombreCorto.Location = new System.Drawing.Point(86, 79);
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(141, 20);
            this.txtNombreCorto.TabIndex = 98;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label6);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFecModif);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(this.txtFecRegistro);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModif);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(524, 122);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(291, 134);
            this.pnlAuditoria.TabIndex = 3;
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AutoGenerateColumns = false;
            this.dgvMarcas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMarcaDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.dgvMarcas.DataSource = this.bsMarcasListado;
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.EnableHeadersVisualStyles = false;
            this.dgvMarcas.Location = new System.Drawing.Point(0, 18);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.RowTemplate.Height = 24;
            this.dgvMarcas.Size = new System.Drawing.Size(281, 232);
            this.dgvMarcas.TabIndex = 4;
            this.dgvMarcas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMarcas_CellFormatting);
            // 
            // idMarcaDataGridViewTextBoxColumn
            // 
            this.idMarcaDataGridViewTextBoxColumn.DataPropertyName = "idMarca";
            this.idMarcaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idMarcaDataGridViewTextBoxColumn.Name = "idMarcaDataGridViewTextBoxColumn";
            this.idMarcaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsMarcasListado
            // 
            this.bsMarcasListado.DataSource = typeof(Entidades.Generales.Marca);
            this.bsMarcasListado.CurrentChanged += new System.EventHandler(this.bsMarcasListado_CurrentChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvMarcas);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(238, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 252);
            this.panel1.TabIndex = 5;
            // 
            // bsSistemas
            // 
            this.bsSistemas.DataSource = typeof(Entidades.Generales.SistemasE);
            this.bsSistemas.CurrentChanged += new System.EventHandler(this.bsSistemas_CurrentChanged);
            // 
            // dgvSistemas
            // 
            this.dgvSistemas.AllowUserToAddRows = false;
            this.dgvSistemas.AllowUserToDeleteRows = false;
            this.dgvSistemas.AutoGenerateColumns = false;
            this.dgvSistemas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSistemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSistemas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSistemas.DataSource = this.bsSistemas;
            this.dgvSistemas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSistemas.EnableHeadersVisualStyles = false;
            this.dgvSistemas.Location = new System.Drawing.Point(0, 18);
            this.dgvSistemas.Name = "dgvSistemas";
            this.dgvSistemas.ReadOnly = true;
            this.dgvSistemas.RowTemplate.Height = 24;
            this.dgvSistemas.Size = new System.Drawing.Size(229, 232);
            this.dgvSistemas.TabIndex = 5;
            this.dgvSistemas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSistemas_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idSistema";
            this.Column1.HeaderText = "Cod.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "descripcion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // pnlSistemas
            // 
            this.pnlSistemas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSistemas.Controls.Add(this.dgvSistemas);
            this.pnlSistemas.Controls.Add(this.label2);
            this.pnlSistemas.Location = new System.Drawing.Point(4, 4);
            this.pnlSistemas.Name = "pnlSistemas";
            this.pnlSistemas.Size = new System.Drawing.Size(231, 252);
            this.pnlSistemas.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 18);
            this.label6.TabIndex = 347;
            this.label6.Text = "Auditoria";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 18);
            this.label1.TabIndex = 347;
            this.label1.Text = "Detalle";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Registros";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 18);
            this.label2.TabIndex = 429;
            this.label2.Text = "Sistemas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 259);
            this.Controls.Add(this.pnlSistemas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDetalle);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMarca";
            this.Text = "MARCAS";
            this.Load += new System.EventHandler(this.FrmMarca_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMarca_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcasDetalle)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcasListado)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsSistemas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSistemas)).EndInit();
            this.pnlSistemas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.BindingSource bsMarcasDetalle;
        private System.Windows.Forms.TextBox txtIdMarca;
        private System.Windows.Forms.TextBox txtFecModif;
        private System.Windows.Forms.TextBox txtFecRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModif;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.BindingSource bsMarcasListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombreCorto;
        private System.Windows.Forms.BindingSource bsSistemas;
        private System.Windows.Forms.DataGridView dgvSistemas;
        private System.Windows.Forms.Panel pnlSistemas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}