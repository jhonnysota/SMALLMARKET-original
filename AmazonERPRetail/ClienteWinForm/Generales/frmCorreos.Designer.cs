namespace ClienteWinForm.Generales
{
    partial class frmCorreos
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaMod = new System.Windows.Forms.TextBox();
            this.txtUsuarioReg = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaReg = new System.Windows.Forms.TextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.chkPorDefecto = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvCorreos = new System.Windows.Forms.DataGridView();
            this.correoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCorreos = new System.Windows.Forms.BindingSource(this.components);
            this.btEliminar = new System.Windows.Forms.Button();
            this.btInsertar = new System.Windows.Forms.Button();
            this.btCorreos = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorreos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 94);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(8, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(8, 50);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(26, 36);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 267;
            label2.Text = "Usuario";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(26, 59);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(63, 13);
            label6.TabIndex = 326;
            label6.Text = "Descripción";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label7);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaMod);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioReg);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaReg);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(474, 3);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(262, 118);
            this.pnlAuditoria.TabIndex = 261;
            // 
            // txtFechaMod
            // 
            this.txtFechaMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaMod.Enabled = false;
            this.txtFechaMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaMod.Location = new System.Drawing.Point(114, 90);
            this.txtFechaMod.Name = "txtFechaMod";
            this.txtFechaMod.Size = new System.Drawing.Size(135, 20);
            this.txtFechaMod.TabIndex = 7;
            this.txtFechaMod.TabStop = false;
            // 
            // txtUsuarioReg
            // 
            this.txtUsuarioReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioReg.Enabled = false;
            this.txtUsuarioReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioReg.Location = new System.Drawing.Point(114, 24);
            this.txtUsuarioReg.Name = "txtUsuarioReg";
            this.txtUsuarioReg.Size = new System.Drawing.Size(135, 20);
            this.txtUsuarioReg.TabIndex = 1;
            this.txtUsuarioReg.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(114, 68);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(135, 20);
            this.txtUsuarioMod.TabIndex = 5;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaReg
            // 
            this.txtFechaReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaReg.Enabled = false;
            this.txtFechaReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaReg.Location = new System.Drawing.Point(114, 46);
            this.txtFechaReg.Name = "txtFechaReg";
            this.txtFechaReg.Size = new System.Drawing.Size(135, 20);
            this.txtFechaReg.TabIndex = 3;
            this.txtFechaReg.TabStop = false;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.chkPorDefecto);
            this.pnlDatos.Controls.Add(this.txtDescripcion);
            this.pnlDatos.Controls.Add(this.txtRazonSocial);
            this.pnlDatos.Controls.Add(label6);
            this.pnlDatos.Controls.Add(label2);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(469, 118);
            this.pnlDatos.TabIndex = 260;
            // 
            // chkPorDefecto
            // 
            this.chkPorDefecto.AutoSize = true;
            this.chkPorDefecto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPorDefecto.Location = new System.Drawing.Point(25, 79);
            this.chkPorDefecto.Name = "chkPorDefecto";
            this.chkPorDefecto.Size = new System.Drawing.Size(114, 17);
            this.chkPorDefecto.TabIndex = 329;
            this.chkPorDefecto.Text = "Grupo por Defecto";
            this.chkPorDefecto.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(125, 55);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(322, 20);
            this.txtDescripcion.TabIndex = 328;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(125, 32);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(322, 21);
            this.txtRazonSocial.TabIndex = 327;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvCorreos);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(3, 123);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(732, 248);
            this.panel5.TabIndex = 265;
            // 
            // dgvCorreos
            // 
            this.dgvCorreos.AllowUserToAddRows = false;
            this.dgvCorreos.AllowUserToDeleteRows = false;
            this.dgvCorreos.AutoGenerateColumns = false;
            this.dgvCorreos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCorreos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorreos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.correoDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvCorreos.DataSource = this.bsCorreos;
            this.dgvCorreos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCorreos.EnableHeadersVisualStyles = false;
            this.dgvCorreos.Location = new System.Drawing.Point(0, 18);
            this.dgvCorreos.Name = "dgvCorreos";
            this.dgvCorreos.ReadOnly = true;
            this.dgvCorreos.Size = new System.Drawing.Size(730, 228);
            this.dgvCorreos.TabIndex = 250;
            this.dgvCorreos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorreos_CellDoubleClick);
            this.dgvCorreos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCorreos_RowPostPaint);
            // 
            // correoDataGridViewTextBoxColumn
            // 
            this.correoDataGridViewTextBoxColumn.DataPropertyName = "Correo";
            this.correoDataGridViewTextBoxColumn.HeaderText = "Correo";
            this.correoDataGridViewTextBoxColumn.Name = "correoDataGridViewTextBoxColumn";
            this.correoDataGridViewTextBoxColumn.ReadOnly = true;
            this.correoDataGridViewTextBoxColumn.Width = 200;
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            this.nombresDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombresDataGridViewTextBoxColumn.Width = 200;
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
            this.fechaRegistroDataGridViewTextBoxColumn.Width = 130;
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
            this.fechaModificacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsCorreos
            // 
            this.bsCorreos.DataSource = typeof(Entidades.Generales.ContactosCorreosE);
            this.bsCorreos.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCorreos_ListChanged);
            // 
            // btEliminar
            // 
            this.btEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEliminar.BackColor = System.Drawing.Color.Azure;
            this.btEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminar.Location = new System.Drawing.Point(638, 377);
            this.btEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(90, 24);
            this.btEliminar.TabIndex = 1600;
            this.btEliminar.Text = "Eliminar Item";
            this.btEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btInsertar
            // 
            this.btInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btInsertar.BackColor = System.Drawing.Color.Azure;
            this.btInsertar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInsertar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsertar.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsertar.Location = new System.Drawing.Point(545, 377);
            this.btInsertar.Name = "btInsertar";
            this.btInsertar.Size = new System.Drawing.Size(90, 24);
            this.btInsertar.TabIndex = 1599;
            this.btInsertar.TabStop = false;
            this.btInsertar.Text = "Insertar";
            this.btInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsertar.UseVisualStyleBackColor = false;
            this.btInsertar.Click += new System.EventHandler(this.btInsertar_Click);
            // 
            // btCorreos
            // 
            this.btCorreos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCorreos.BackColor = System.Drawing.Color.Azure;
            this.btCorreos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCorreos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCorreos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCorreos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCorreos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCorreos.Image = global::ClienteWinForm.Properties.Resources.Row_Insert_16x16;
            this.btCorreos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCorreos.Location = new System.Drawing.Point(396, 377);
            this.btCorreos.Name = "btCorreos";
            this.btCorreos.Size = new System.Drawing.Size(146, 24);
            this.btCorreos.TabIndex = 1598;
            this.btCorreos.TabStop = false;
            this.btCorreos.Text = "Cuentas de Correo";
            this.btCorreos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCorreos.UseVisualStyleBackColor = false;
            this.btCorreos.Click += new System.EventHandler(this.btCorreos_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(467, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 18);
            this.label7.TabIndex = 347;
            this.label7.Text = "Auditoria";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(730, 18);
            this.lblRegistros.TabIndex = 430;
            this.lblRegistros.Text = "Registros 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCorreos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 407);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btInsertar);
            this.Controls.Add(this.btCorreos);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDatos);
            this.Name = "frmCorreos";
            this.Text = "Correo";
            this.Load += new System.EventHandler(this.frmCorreos_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorreos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaMod;
        private System.Windows.Forms.TextBox txtUsuarioReg;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaReg;
        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private System.Windows.Forms.CheckBox chkPorDefecto;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvCorreos;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCorreos;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btInsertar;
        private System.Windows.Forms.Button btCorreos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRegistros;
    }
}