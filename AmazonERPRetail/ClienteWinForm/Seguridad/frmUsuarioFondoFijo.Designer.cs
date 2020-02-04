namespace ClienteWinForm.Seguridad
{
    partial class frmUsuarioFondoFijo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btInsertar = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.pnlTipos = new System.Windows.Forms.Panel();
            this.dgvFondoFijo = new System.Windows.Forms.DataGridView();
            this.desTipoFondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFondoFijo = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.pnlUsuarios = new System.Windows.Forms.Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.NombreCompuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsuarios = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtBusqueda = new ControlesWinForm.SuperTextBox();
            idEmpresaLabel = new System.Windows.Forms.Label();
            this.pnlTipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondoFijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFondoFijo)).BeginInit();
            this.pnlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.BackColor = System.Drawing.Color.Transparent;
            idEmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idEmpresaLabel.Location = new System.Drawing.Point(520, 8);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new System.Drawing.Size(48, 13);
            idEmpresaLabel.TabIndex = 613;
            idEmpresaLabel.Text = "Empresa";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.BackColor = System.Drawing.Color.White;
            this.cboEmpresa.DisplayMember = "NombreComercial";
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(587, 5);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(178, 21);
            this.cboEmpresa.TabIndex = 3;
            this.cboEmpresa.TabStop = false;
            this.cboEmpresa.ValueMember = "IdEmpresa";
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
            this.btEliminar.Location = new System.Drawing.Point(680, 31);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(82, 24);
            this.btEliminar.TabIndex = 612;
            this.btEliminar.TabStop = false;
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
            this.btInsertar.Location = new System.Drawing.Point(592, 31);
            this.btInsertar.Name = "btInsertar";
            this.btInsertar.Size = new System.Drawing.Size(82, 24);
            this.btInsertar.TabIndex = 611;
            this.btInsertar.TabStop = false;
            this.btInsertar.Text = "Agregar";
            this.btInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsertar.UseVisualStyleBackColor = true;
            this.btInsertar.Click += new System.EventHandler(this.btInsertar_Click);
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
            this.labelDegradado1.Size = new System.Drawing.Size(370, 17);
            this.labelDegradado1.TabIndex = 249;
            this.labelDegradado1.Text = "Tipos de Fondo Fijo";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTipos
            // 
            this.pnlTipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipos.Controls.Add(this.dgvFondoFijo);
            this.pnlTipos.Controls.Add(this.labelDegradado1);
            this.pnlTipos.Location = new System.Drawing.Point(512, 61);
            this.pnlTipos.Name = "pnlTipos";
            this.pnlTipos.Size = new System.Drawing.Size(372, 311);
            this.pnlTipos.TabIndex = 610;
            // 
            // dgvFondoFijo
            // 
            this.dgvFondoFijo.AllowUserToAddRows = false;
            this.dgvFondoFijo.AllowUserToDeleteRows = false;
            this.dgvFondoFijo.AutoGenerateColumns = false;
            this.dgvFondoFijo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFondoFijo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desTipoFondo,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvFondoFijo.DataSource = this.bsFondoFijo;
            this.dgvFondoFijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFondoFijo.EnableHeadersVisualStyles = false;
            this.dgvFondoFijo.Location = new System.Drawing.Point(0, 17);
            this.dgvFondoFijo.Name = "dgvFondoFijo";
            this.dgvFondoFijo.ReadOnly = true;
            this.dgvFondoFijo.Size = new System.Drawing.Size(370, 292);
            this.dgvFondoFijo.TabIndex = 10;
            this.dgvFondoFijo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFondoFijo_CellDoubleClick);
            // 
            // desTipoFondo
            // 
            this.desTipoFondo.DataPropertyName = "desTipoFondo";
            this.desTipoFondo.HeaderText = "Tip.Fondo";
            this.desTipoFondo.Name = "desTipoFondo";
            this.desTipoFondo.ReadOnly = true;
            this.desTipoFondo.Width = 110;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Edicion";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Edición";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 80;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Visualizar";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Visualizar";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UsuarioRegistro";
            this.dataGridViewTextBoxColumn6.HeaderText = "Usuario Reg.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaRegistro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha Reg.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 130;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn8.HeaderText = "Usuario Mod.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FechaModificacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn9.HeaderText = "Fecha Mod.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 130;
            // 
            // bsFondoFijo
            // 
            this.bsFondoFijo.DataSource = typeof(Entidades.Seguridad.UsuarioFondoFijoE);
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
            this.lblRegistros.Size = new System.Drawing.Size(505, 17);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Listado de Usuarios";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUsuarios
            // 
            this.pnlUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsuarios.Controls.Add(this.dgvUsuarios);
            this.pnlUsuarios.Controls.Add(this.lblRegistros);
            this.pnlUsuarios.Location = new System.Drawing.Point(3, 34);
            this.pnlUsuarios.Name = "pnlUsuarios";
            this.pnlUsuarios.Size = new System.Drawing.Size(507, 338);
            this.pnlUsuarios.TabIndex = 609;
            this.pnlUsuarios.TabStop = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCompuesto,
            this.NroDocumento});
            this.dgvUsuarios.DataSource = this.bsUsuarios;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 17);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(505, 319);
            this.dgvUsuarios.TabIndex = 2;
            this.dgvUsuarios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_ColumnHeaderMouseClick);
            // 
            // NombreCompuesto
            // 
            this.NombreCompuesto.DataPropertyName = "NombreCompuesto";
            this.NombreCompuesto.HeaderText = "Credencial - Nombres";
            this.NombreCompuesto.Name = "NombreCompuesto";
            this.NombreCompuesto.ReadOnly = true;
            this.NombreCompuesto.Width = 300;
            // 
            // NroDocumento
            // 
            this.NroDocumento.DataPropertyName = "NroDocumento";
            this.NroDocumento.HeaderText = "N° Documento";
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.ReadOnly = true;
            this.NroDocumento.Width = 98;
            // 
            // bsUsuarios
            // 
            this.bsUsuarios.DataSource = typeof(Entidades.Seguridad.Usuario);
            this.bsUsuarios.CurrentChanged += new System.EventHandler(this.bsUsuarios_CurrentChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 12);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 13);
            this.label12.TabIndex = 617;
            this.label12.Text = "Parámetro de Búsqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(129, 9);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(374, 20);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtBusqueda.TextoVacio = "<Descripcion>";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // frmUsuarioFondoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 374);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btInsertar);
            this.Controls.Add(this.pnlTipos);
            this.Controls.Add(idEmpresaLabel);
            this.Controls.Add(this.pnlUsuarios);
            this.MaximizeBox = false;
            this.Name = "frmUsuarioFondoFijo";
            this.Text = "Usuario - Fondos Fijos";
            this.Load += new System.EventHandler(this.frmUsuarioFondoFijo_Load);
            this.pnlTipos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFondoFijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFondoFijo)).EndInit();
            this.pnlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btInsertar;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Panel pnlTipos;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel pnlUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.BindingSource bsUsuarios;
        private System.Windows.Forms.DataGridView dgvFondoFijo;
        private System.Windows.Forms.BindingSource bsFondoFijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTipoFondo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtBusqueda;
    }
}