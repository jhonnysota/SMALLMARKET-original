namespace ClienteWinForm.Seguridad
{
    partial class frmUsuarioCobranza
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
            System.Windows.Forms.Label idEmpresaLabel;
            System.Windows.Forms.Label idLocalLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlUsuarios = new System.Windows.Forms.Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.credencialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCompletoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsuarios = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.pnlTipos = new System.Windows.Forms.Panel();
            this.dgvTipos = new System.Windows.Forms.DataGridView();
            this.desTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbrirPlanilla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CerrarPlanilla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTipoCobranzas = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btInsertar = new System.Windows.Forms.Button();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.cboLocal = new System.Windows.Forms.ComboBox();
            this.btCopiar = new System.Windows.Forms.Button();
            idEmpresaLabel = new System.Windows.Forms.Label();
            idLocalLabel = new System.Windows.Forms.Label();
            this.pnlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarios)).BeginInit();
            this.pnlTipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoCobranzas)).BeginInit();
            this.SuspendLayout();
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.BackColor = System.Drawing.Color.Transparent;
            idEmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idEmpresaLabel.Location = new System.Drawing.Point(517, 128);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new System.Drawing.Size(48, 13);
            idEmpresaLabel.TabIndex = 604;
            idEmpresaLabel.Text = "Empresa";
            // 
            // idLocalLabel
            // 
            idLocalLabel.AutoSize = true;
            idLocalLabel.BackColor = System.Drawing.Color.Transparent;
            idLocalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idLocalLabel.Location = new System.Drawing.Point(517, 169);
            idLocalLabel.Name = "idLocalLabel";
            idLocalLabel.Size = new System.Drawing.Size(33, 13);
            idLocalLabel.TabIndex = 605;
            idLocalLabel.Text = "Local";
            // 
            // pnlUsuarios
            // 
            this.pnlUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsuarios.Controls.Add(this.dgvUsuarios);
            this.pnlUsuarios.Controls.Add(this.lblRegistros);
            this.pnlUsuarios.Location = new System.Drawing.Point(3, 4);
            this.pnlUsuarios.Name = "pnlUsuarios";
            this.pnlUsuarios.Size = new System.Drawing.Size(507, 392);
            this.pnlUsuarios.TabIndex = 339;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.credencialDataGridViewTextBoxColumn,
            this.nombreCompletoDataGridViewTextBoxColumn,
            this.nroDocumentoDataGridViewTextBoxColumn});
            this.dgvUsuarios.DataSource = this.bsUsuarios;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 18);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(505, 372);
            this.dgvUsuarios.TabIndex = 600;
            this.dgvUsuarios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_ColumnHeaderMouseClick);
            // 
            // credencialDataGridViewTextBoxColumn
            // 
            this.credencialDataGridViewTextBoxColumn.DataPropertyName = "Credencial";
            this.credencialDataGridViewTextBoxColumn.HeaderText = "Credencial";
            this.credencialDataGridViewTextBoxColumn.Name = "credencialDataGridViewTextBoxColumn";
            this.credencialDataGridViewTextBoxColumn.ReadOnly = true;
            this.credencialDataGridViewTextBoxColumn.Width = 90;
            // 
            // nombreCompletoDataGridViewTextBoxColumn
            // 
            this.nombreCompletoDataGridViewTextBoxColumn.DataPropertyName = "NombreCompleto";
            this.nombreCompletoDataGridViewTextBoxColumn.HeaderText = "Nombres y Apellidos";
            this.nombreCompletoDataGridViewTextBoxColumn.Name = "nombreCompletoDataGridViewTextBoxColumn";
            this.nombreCompletoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreCompletoDataGridViewTextBoxColumn.Width = 300;
            // 
            // nroDocumentoDataGridViewTextBoxColumn
            // 
            this.nroDocumentoDataGridViewTextBoxColumn.DataPropertyName = "NroDocumento";
            this.nroDocumentoDataGridViewTextBoxColumn.HeaderText = "Nro.Docum.";
            this.nroDocumentoDataGridViewTextBoxColumn.Name = "nroDocumentoDataGridViewTextBoxColumn";
            this.nroDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroDocumentoDataGridViewTextBoxColumn.Width = 80;
            // 
            // bsUsuarios
            // 
            this.bsUsuarios.DataSource = typeof(Entidades.Seguridad.Usuario);
            this.bsUsuarios.CurrentChanged += new System.EventHandler(this.bsUsuarios_CurrentChanged);
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
            this.lblRegistros.Size = new System.Drawing.Size(505, 18);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Listado de Usuarios";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTipos
            // 
            this.pnlTipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipos.Controls.Add(this.dgvTipos);
            this.pnlTipos.Controls.Add(this.labelDegradado1);
            this.pnlTipos.Location = new System.Drawing.Point(702, 4);
            this.pnlTipos.Name = "pnlTipos";
            this.pnlTipos.Size = new System.Drawing.Size(323, 353);
            this.pnlTipos.TabIndex = 601;
            // 
            // dgvTipos
            // 
            this.dgvTipos.AllowUserToAddRows = false;
            this.dgvTipos.AllowUserToDeleteRows = false;
            this.dgvTipos.AutoGenerateColumns = false;
            this.dgvTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desTipoPlanilla,
            this.AbrirPlanilla,
            this.CerrarPlanilla,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvTipos.DataSource = this.bsTipoCobranzas;
            this.dgvTipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTipos.EnableHeadersVisualStyles = false;
            this.dgvTipos.Location = new System.Drawing.Point(0, 18);
            this.dgvTipos.Name = "dgvTipos";
            this.dgvTipos.ReadOnly = true;
            this.dgvTipos.Size = new System.Drawing.Size(321, 333);
            this.dgvTipos.TabIndex = 600;
            this.dgvTipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipos_CellDoubleClick);
            // 
            // desTipoPlanilla
            // 
            this.desTipoPlanilla.DataPropertyName = "desTipoPlanilla";
            this.desTipoPlanilla.HeaderText = "Tipo Planilla";
            this.desTipoPlanilla.Name = "desTipoPlanilla";
            this.desTipoPlanilla.ReadOnly = true;
            // 
            // AbrirPlanilla
            // 
            this.AbrirPlanilla.DataPropertyName = "AbrirPlanilla";
            this.AbrirPlanilla.HeaderText = "A.P.";
            this.AbrirPlanilla.Name = "AbrirPlanilla";
            this.AbrirPlanilla.ReadOnly = true;
            this.AbrirPlanilla.ToolTipText = "Abrir la planilla de cobranza";
            this.AbrirPlanilla.Width = 30;
            // 
            // CerrarPlanilla
            // 
            this.CerrarPlanilla.DataPropertyName = "CerrarPlanilla";
            this.CerrarPlanilla.HeaderText = "C.P.";
            this.CerrarPlanilla.Name = "CerrarPlanilla";
            this.CerrarPlanilla.ReadOnly = true;
            this.CerrarPlanilla.ToolTipText = "Cerrar la planilla de cobranza";
            this.CerrarPlanilla.Width = 30;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRegistroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha Mod.";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // bsTipoCobranzas
            // 
            this.bsTipoCobranzas.DataSource = typeof(Entidades.Seguridad.AsignarTipoCobranzaE);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(321, 18);
            this.labelDegradado1.TabIndex = 249;
            this.labelDegradado1.Text = "Tipos de Cobranza";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btEliminar
            // 
            this.btEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminar.Location = new System.Drawing.Point(864, 362);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(82, 25);
            this.btEliminar.TabIndex = 603;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btInsertar
            // 
            this.btInsertar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsertar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsertar.Location = new System.Drawing.Point(776, 362);
            this.btInsertar.Name = "btInsertar";
            this.btInsertar.Size = new System.Drawing.Size(82, 25);
            this.btInsertar.TabIndex = 602;
            this.btInsertar.Text = "Agregar";
            this.btInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsertar.UseVisualStyleBackColor = true;
            this.btInsertar.Click += new System.EventHandler(this.btInsertar_Click);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.BackColor = System.Drawing.Color.White;
            this.cboEmpresa.DisplayMember = "NombreComercial";
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(517, 144);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(178, 21);
            this.cboEmpresa.TabIndex = 606;
            this.cboEmpresa.ValueMember = "IdEmpresa";
            this.cboEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cboEmpresa_SelectionChangeCommitted);
            // 
            // cboLocal
            // 
            this.cboLocal.BackColor = System.Drawing.Color.White;
            this.cboLocal.DisplayMember = "Nombre";
            this.cboLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Location = new System.Drawing.Point(517, 186);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(178, 21);
            this.cboLocal.TabIndex = 607;
            this.cboLocal.ValueMember = "IdLocal";
            this.cboLocal.SelectionChangeCommitted += new System.EventHandler(this.cboLocal_SelectionChangeCommitted);
            // 
            // btCopiar
            // 
            this.btCopiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCopiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCopiar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCopiar.Image = global::ClienteWinForm.Properties.Resources.Copiar16x16;
            this.btCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCopiar.Location = new System.Drawing.Point(950, 362);
            this.btCopiar.Name = "btCopiar";
            this.btCopiar.Size = new System.Drawing.Size(83, 25);
            this.btCopiar.TabIndex = 608;
            this.btCopiar.Text = "Copiar de";
            this.btCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCopiar.UseVisualStyleBackColor = true;
            this.btCopiar.Visible = false;
            this.btCopiar.Click += new System.EventHandler(this.btCopiar_Click);
            // 
            // frmUsuarioCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 399);
            this.Controls.Add(this.btCopiar);
            this.Controls.Add(idEmpresaLabel);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(idLocalLabel);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btInsertar);
            this.Controls.Add(this.pnlTipos);
            this.Controls.Add(this.pnlUsuarios);
            this.MaximizeBox = false;
            this.Name = "frmUsuarioCobranza";
            this.Text = "Asignación de Tipos de Cobranza a Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarioCobranza_Load);
            this.pnlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarios)).EndInit();
            this.pnlTipos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTipoCobranzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel pnlTipos;
        private System.Windows.Forms.DataGridView dgvTipos;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btInsertar;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.ComboBox cboLocal;
        private System.Windows.Forms.BindingSource bsUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn credencialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCompletoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btCopiar;
        private System.Windows.Forms.BindingSource bsTipoCobranzas;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoPlanilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AbrirPlanilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CerrarPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    }
}