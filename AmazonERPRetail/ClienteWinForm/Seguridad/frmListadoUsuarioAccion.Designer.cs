namespace ClienteWinForm.Seguridad
{
    partial class frmListadoUsuarioAccion
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListadoUsuarioAcciones = new System.Windows.Forms.DataGridView();
            this.NombreGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreOpcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlTotalDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cRDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uPDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemFaltante = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GrupoOpcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TomarOpcion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsUsuarioAccion = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btFaltantes = new System.Windows.Forms.Button();
            this.cboEmpresas = new System.Windows.Forms.ComboBox();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoUsuarioAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarioAccion)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(414, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 611;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(20, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 13);
            label2.TabIndex = 613;
            label2.Text = "Empresa";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListadoUsuarioAcciones);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 69);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 422);
            this.panel5.TabIndex = 299;
            // 
            // dgvListadoUsuarioAcciones
            // 
            this.dgvListadoUsuarioAcciones.AllowUserToAddRows = false;
            this.dgvListadoUsuarioAcciones.AllowUserToDeleteRows = false;
            this.dgvListadoUsuarioAcciones.AutoGenerateColumns = false;
            this.dgvListadoUsuarioAcciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListadoUsuarioAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoUsuarioAcciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreGrupo,
            this.NombreOpcion,
            this.controlTotalDataGridViewCheckBoxColumn,
            this.cRDataGridViewCheckBoxColumn,
            this.rEDataGridViewCheckBoxColumn,
            this.uPDataGridViewCheckBoxColumn,
            this.dEDataGridViewCheckBoxColumn,
            this.ItemFaltante,
            this.GrupoOpcion,
            this.TomarOpcion});
            this.dgvListadoUsuarioAcciones.DataSource = this.bsUsuarioAccion;
            this.dgvListadoUsuarioAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListadoUsuarioAcciones.EnableHeadersVisualStyles = false;
            this.dgvListadoUsuarioAcciones.Location = new System.Drawing.Point(0, 18);
            this.dgvListadoUsuarioAcciones.Name = "dgvListadoUsuarioAcciones";
            this.dgvListadoUsuarioAcciones.ReadOnly = true;
            this.dgvListadoUsuarioAcciones.Size = new System.Drawing.Size(971, 402);
            this.dgvListadoUsuarioAcciones.TabIndex = 250;
            this.dgvListadoUsuarioAcciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoUsuarioAcciones_CellDoubleClick);
            this.dgvListadoUsuarioAcciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoUsuarioAcciones_CellFormatting);
            // 
            // NombreGrupo
            // 
            this.NombreGrupo.DataPropertyName = "NombreGrupo";
            this.NombreGrupo.HeaderText = "Grupo";
            this.NombreGrupo.Name = "NombreGrupo";
            this.NombreGrupo.ReadOnly = true;
            this.NombreGrupo.ToolTipText = "Nombre del grupo";
            this.NombreGrupo.Width = 300;
            // 
            // NombreOpcion
            // 
            this.NombreOpcion.DataPropertyName = "NombreOpcion";
            this.NombreOpcion.HeaderText = "Opción";
            this.NombreOpcion.Name = "NombreOpcion";
            this.NombreOpcion.ReadOnly = true;
            this.NombreOpcion.ToolTipText = "Nombre de la opción";
            this.NombreOpcion.Width = 300;
            // 
            // controlTotalDataGridViewCheckBoxColumn
            // 
            this.controlTotalDataGridViewCheckBoxColumn.DataPropertyName = "ControlTotal";
            this.controlTotalDataGridViewCheckBoxColumn.HeaderText = "C.T.";
            this.controlTotalDataGridViewCheckBoxColumn.Name = "controlTotalDataGridViewCheckBoxColumn";
            this.controlTotalDataGridViewCheckBoxColumn.ReadOnly = true;
            this.controlTotalDataGridViewCheckBoxColumn.ToolTipText = "Control Total";
            this.controlTotalDataGridViewCheckBoxColumn.Width = 50;
            // 
            // cRDataGridViewCheckBoxColumn
            // 
            this.cRDataGridViewCheckBoxColumn.DataPropertyName = "CR";
            this.cRDataGridViewCheckBoxColumn.HeaderText = "CRE";
            this.cRDataGridViewCheckBoxColumn.Name = "cRDataGridViewCheckBoxColumn";
            this.cRDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cRDataGridViewCheckBoxColumn.ToolTipText = "Crear Registro";
            this.cRDataGridViewCheckBoxColumn.Width = 50;
            // 
            // rEDataGridViewCheckBoxColumn
            // 
            this.rEDataGridViewCheckBoxColumn.DataPropertyName = "RE";
            this.rEDataGridViewCheckBoxColumn.HeaderText = "REA";
            this.rEDataGridViewCheckBoxColumn.Name = "rEDataGridViewCheckBoxColumn";
            this.rEDataGridViewCheckBoxColumn.ReadOnly = true;
            this.rEDataGridViewCheckBoxColumn.ToolTipText = "Consultar registros";
            this.rEDataGridViewCheckBoxColumn.Width = 50;
            // 
            // uPDataGridViewCheckBoxColumn
            // 
            this.uPDataGridViewCheckBoxColumn.DataPropertyName = "UP";
            this.uPDataGridViewCheckBoxColumn.HeaderText = "UPD";
            this.uPDataGridViewCheckBoxColumn.Name = "uPDataGridViewCheckBoxColumn";
            this.uPDataGridViewCheckBoxColumn.ReadOnly = true;
            this.uPDataGridViewCheckBoxColumn.ToolTipText = "Actualizar Registros";
            this.uPDataGridViewCheckBoxColumn.Width = 50;
            // 
            // dEDataGridViewCheckBoxColumn
            // 
            this.dEDataGridViewCheckBoxColumn.DataPropertyName = "DE";
            this.dEDataGridViewCheckBoxColumn.HeaderText = "DEL";
            this.dEDataGridViewCheckBoxColumn.Name = "dEDataGridViewCheckBoxColumn";
            this.dEDataGridViewCheckBoxColumn.ReadOnly = true;
            this.dEDataGridViewCheckBoxColumn.ToolTipText = "Eliminar, Anular Registros";
            this.dEDataGridViewCheckBoxColumn.Width = 50;
            // 
            // ItemFaltante
            // 
            this.ItemFaltante.DataPropertyName = "ItemFaltante";
            this.ItemFaltante.HeaderText = "X";
            this.ItemFaltante.Name = "ItemFaltante";
            this.ItemFaltante.ReadOnly = true;
            this.ItemFaltante.ToolTipText = "Falta Ingresar una Acción";
            this.ItemFaltante.Width = 30;
            // 
            // GrupoOpcion
            // 
            this.GrupoOpcion.DataPropertyName = "GrupoOpcion";
            this.GrupoOpcion.HeaderText = "GrupoOpcion";
            this.GrupoOpcion.Name = "GrupoOpcion";
            this.GrupoOpcion.ReadOnly = true;
            this.GrupoOpcion.Visible = false;
            // 
            // TomarOpcion
            // 
            this.TomarOpcion.DataPropertyName = "TomarOpcion";
            this.TomarOpcion.HeaderText = "TomarOpcion";
            this.TomarOpcion.Name = "TomarOpcion";
            this.TomarOpcion.ReadOnly = true;
            this.TomarOpcion.Visible = false;
            // 
            // bsUsuarioAccion
            // 
            this.bsUsuarioAccion.DataSource = typeof(Entidades.Seguridad.UsuarioAccionE);
            this.bsUsuarioAccion.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsUsuarioAccion_ListChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(971, 18);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btFaltantes);
            this.panel3.Controls.Add(label2);
            this.panel3.Controls.Add(this.cboEmpresas);
            this.panel3.Controls.Add(label1);
            this.panel3.Controls.Add(this.cboUsuarios);
            this.panel3.Controls.Add(this.labelDegradado3);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 64);
            this.panel3.TabIndex = 609;
            // 
            // btFaltantes
            // 
            this.btFaltantes.Enabled = false;
            this.btFaltantes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btFaltantes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btFaltantes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btFaltantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFaltantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFaltantes.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btFaltantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFaltantes.Location = new System.Drawing.Point(822, 27);
            this.btFaltantes.Name = "btFaltantes";
            this.btFaltantes.Size = new System.Drawing.Size(127, 26);
            this.btFaltantes.TabIndex = 1596;
            this.btFaltantes.TabStop = false;
            this.btFaltantes.Text = "Ingresar Items";
            this.btFaltantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFaltantes.UseVisualStyleBackColor = true;
            this.btFaltantes.Click += new System.EventHandler(this.btFaltantes_Click);
            // 
            // cboEmpresas
            // 
            this.cboEmpresas.BackColor = System.Drawing.Color.White;
            this.cboEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresas.FormattingEnabled = true;
            this.cboEmpresas.Location = new System.Drawing.Point(71, 29);
            this.cboEmpresas.Name = "cboEmpresas";
            this.cboEmpresas.Size = new System.Drawing.Size(337, 21);
            this.cboEmpresas.TabIndex = 612;
            this.cboEmpresas.SelectionChangeCommitted += new System.EventHandler(this.cboEmpresas_SelectionChangeCommitted);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.BackColor = System.Drawing.Color.White;
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.DropDownWidth = 350;
            this.cboUsuarios.Enabled = false;
            this.cboUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(460, 30);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(337, 21);
            this.cboUsuarios.TabIndex = 610;
            this.cboUsuarios.SelectionChangeCommitted += new System.EventHandler(this.cboUsuarios_SelectionChangeCommitted);
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(971, 17);
            this.labelDegradado3.TabIndex = 248;
            this.labelDegradado3.Text = "Parámetros de Búsqueda";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmListadoUsuarioAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 494);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.Name = "frmListadoUsuarioAccion";
            this.Text = "Listado Usuario - Acciones";
            this.Load += new System.EventHandler(this.frmListadoUsuarioAccion_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoUsuarioAcciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarioAccion)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListadoUsuarioAcciones;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel panel3;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.ComboBox cboEmpresas;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.BindingSource bsUsuarioAccion;
        private System.Windows.Forms.Button btFaltantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreOpcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn controlTotalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cRDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uPDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemFaltante;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoOpcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TomarOpcion;
    }
}