namespace ClienteWinForm.Contabilidad
{
    partial class frmCierre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvSistema = new System.Windows.Forms.DataGridView();
            this.bsCierreSistema = new System.Windows.Forms.BindingSource(this.components);
            this.lblReg2 = new MyLabelG.LabelDegradado();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAlm = new System.Windows.Forms.DataGridView();
            this.bsCierreAlmacen = new System.Windows.Forms.BindingSource(this.components);
            this.lblReg1 = new MyLabelG.LabelDegradado();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregarAlm = new System.Windows.Forms.Button();
            this.btnAgreSis = new System.Windows.Forms.Button();
            this.btnEliSis = new System.Windows.Forms.Button();
            this.anioPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesPeriodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCierreDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioPeriodoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesPeriodoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesSistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indCierreDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaCierreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCierreSistema)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCierreAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvSistema);
            this.panel5.Controls.Add(this.lblReg2);
            this.panel5.Location = new System.Drawing.Point(481, 13);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(361, 308);
            this.panel5.TabIndex = 201;
            // 
            // dgvSistema
            // 
            this.dgvSistema.AllowUserToAddRows = false;
            this.dgvSistema.AllowUserToDeleteRows = false;
            this.dgvSistema.AutoGenerateColumns = false;
            this.dgvSistema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSistema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anioPeriodoDataGridViewTextBoxColumn1,
            this.mesPeriodoDataGridViewTextBoxColumn1,
            this.DesSistema,
            this.indCierreDataGridViewCheckBoxColumn1,
            this.fechaCierreDataGridViewTextBoxColumn1,
            this.usuarioRegistroDataGridViewTextBoxColumn1,
            this.fechaRegistroDataGridViewTextBoxColumn1,
            this.usuarioModificacionDataGridViewTextBoxColumn1,
            this.fechaModificacionDataGridViewTextBoxColumn1});
            this.dgvSistema.DataSource = this.bsCierreSistema;
            this.dgvSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSistema.EnableHeadersVisualStyles = false;
            this.dgvSistema.Location = new System.Drawing.Point(0, 18);
            this.dgvSistema.Name = "dgvSistema";
            this.dgvSistema.ReadOnly = true;
            this.dgvSistema.Size = new System.Drawing.Size(359, 288);
            this.dgvSistema.TabIndex = 201;
            this.dgvSistema.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSistema_CellDoubleClick);
            // 
            // bsCierreSistema
            // 
            this.bsCierreSistema.DataSource = typeof(Entidades.Contabilidad.CierreSistemaE);
            // 
            // lblReg2
            // 
            this.lblReg2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReg2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblReg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReg2.ForeColor = System.Drawing.Color.White;
            this.lblReg2.Location = new System.Drawing.Point(0, 0);
            this.lblReg2.Name = "lblReg2";
            this.lblReg2.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblReg2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblReg2.Size = new System.Drawing.Size(359, 18);
            this.lblReg2.TabIndex = 202;
            this.lblReg2.Text = "Cierre Sistema";
            this.lblReg2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvAlm);
            this.panel1.Controls.Add(this.lblReg1);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 308);
            this.panel1.TabIndex = 203;
            // 
            // dgvAlm
            // 
            this.dgvAlm.AllowUserToAddRows = false;
            this.dgvAlm.AllowUserToDeleteRows = false;
            this.dgvAlm.AutoGenerateColumns = false;
            this.dgvAlm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anioPeriodoDataGridViewTextBoxColumn,
            this.mesPeriodoDataGridViewTextBoxColumn,
            this.DesAlmacen,
            this.indCierreDataGridViewCheckBoxColumn,
            this.fechaCierreDataGridViewTextBoxColumn,
            this.usuarioRegistroDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvAlm.DataSource = this.bsCierreAlmacen;
            this.dgvAlm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlm.EnableHeadersVisualStyles = false;
            this.dgvAlm.Location = new System.Drawing.Point(0, 18);
            this.dgvAlm.Name = "dgvAlm";
            this.dgvAlm.ReadOnly = true;
            this.dgvAlm.Size = new System.Drawing.Size(453, 288);
            this.dgvAlm.TabIndex = 201;
            this.dgvAlm.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlm_CellDoubleClick);
            // 
            // bsCierreAlmacen
            // 
            this.bsCierreAlmacen.DataSource = typeof(Entidades.Contabilidad.CierreAlmacenE);
            // 
            // lblReg1
            // 
            this.lblReg1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReg1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblReg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReg1.ForeColor = System.Drawing.Color.White;
            this.lblReg1.Location = new System.Drawing.Point(0, 0);
            this.lblReg1.Name = "lblReg1";
            this.lblReg1.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblReg1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblReg1.Size = new System.Drawing.Size(453, 18);
            this.lblReg1.TabIndex = 202;
            this.lblReg1.Text = "Cierre Almacen";
            this.lblReg1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(224, 325);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(131, 33);
            this.btnEliminar.TabIndex = 2005;
            this.btnEliminar.Text = "Eliminar Almacen";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregarAlm
            // 
            this.btnAgregarAlm.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgregarAlm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregarAlm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAgregarAlm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgregarAlm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAlm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlm.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.btnAgregarAlm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarAlm.Location = new System.Drawing.Point(86, 325);
            this.btnAgregarAlm.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarAlm.Name = "btnAgregarAlm";
            this.btnAgregarAlm.Size = new System.Drawing.Size(134, 33);
            this.btnAgregarAlm.TabIndex = 2006;
            this.btnAgregarAlm.Text = "Agregar Almacen";
            this.btnAgregarAlm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarAlm.UseVisualStyleBackColor = false;
            this.btnAgregarAlm.Click += new System.EventHandler(this.btnAgregarAlm_Click);
            // 
            // btnAgreSis
            // 
            this.btnAgreSis.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAgreSis.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgreSis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAgreSis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgreSis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgreSis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgreSis.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.btnAgreSis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgreSis.Location = new System.Drawing.Point(514, 325);
            this.btnAgreSis.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgreSis.Name = "btnAgreSis";
            this.btnAgreSis.Size = new System.Drawing.Size(134, 33);
            this.btnAgreSis.TabIndex = 2008;
            this.btnAgreSis.Text = "Agregar Sistema";
            this.btnAgreSis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgreSis.UseVisualStyleBackColor = false;
            this.btnAgreSis.Click += new System.EventHandler(this.btnAgreSis_Click);
            // 
            // btnEliSis
            // 
            this.btnEliSis.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEliSis.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliSis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnEliSis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliSis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliSis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliSis.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btnEliSis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliSis.Location = new System.Drawing.Point(652, 325);
            this.btnEliSis.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliSis.Name = "btnEliSis";
            this.btnEliSis.Size = new System.Drawing.Size(131, 33);
            this.btnEliSis.TabIndex = 2007;
            this.btnEliSis.Text = "Eliminar Sistema";
            this.btnEliSis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliSis.UseVisualStyleBackColor = false;
            this.btnEliSis.Click += new System.EventHandler(this.btnEliSis_Click);
            // 
            // anioPeriodoDataGridViewTextBoxColumn
            // 
            this.anioPeriodoDataGridViewTextBoxColumn.DataPropertyName = "AnioPeriodo";
            this.anioPeriodoDataGridViewTextBoxColumn.HeaderText = "Año";
            this.anioPeriodoDataGridViewTextBoxColumn.Name = "anioPeriodoDataGridViewTextBoxColumn";
            this.anioPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.anioPeriodoDataGridViewTextBoxColumn.Width = 40;
            // 
            // mesPeriodoDataGridViewTextBoxColumn
            // 
            this.mesPeriodoDataGridViewTextBoxColumn.DataPropertyName = "MesPeriodo";
            this.mesPeriodoDataGridViewTextBoxColumn.HeaderText = "Mes";
            this.mesPeriodoDataGridViewTextBoxColumn.Name = "mesPeriodoDataGridViewTextBoxColumn";
            this.mesPeriodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.mesPeriodoDataGridViewTextBoxColumn.Width = 35;
            // 
            // DesAlmacen
            // 
            this.DesAlmacen.DataPropertyName = "DesAlmacen";
            this.DesAlmacen.HeaderText = "Almacen";
            this.DesAlmacen.Name = "DesAlmacen";
            this.DesAlmacen.ReadOnly = true;
            this.DesAlmacen.Width = 140;
            // 
            // indCierreDataGridViewCheckBoxColumn
            // 
            this.indCierreDataGridViewCheckBoxColumn.DataPropertyName = "indCierre";
            this.indCierreDataGridViewCheckBoxColumn.HeaderText = "I.C";
            this.indCierreDataGridViewCheckBoxColumn.Name = "indCierreDataGridViewCheckBoxColumn";
            this.indCierreDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indCierreDataGridViewCheckBoxColumn.Width = 25;
            // 
            // fechaCierreDataGridViewTextBoxColumn
            // 
            this.fechaCierreDataGridViewTextBoxColumn.DataPropertyName = "FechaCierre";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaCierreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaCierreDataGridViewTextBoxColumn.HeaderText = "Fecha Cierre";
            this.fechaCierreDataGridViewTextBoxColumn.Name = "fechaCierreDataGridViewTextBoxColumn";
            this.fechaCierreDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCierreDataGridViewTextBoxColumn.Width = 97;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn.Name = "usuarioRegistroDataGridViewTextBoxColumn";
            this.usuarioRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            this.fechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anioPeriodoDataGridViewTextBoxColumn1
            // 
            this.anioPeriodoDataGridViewTextBoxColumn1.DataPropertyName = "AnioPeriodo";
            this.anioPeriodoDataGridViewTextBoxColumn1.HeaderText = "Año";
            this.anioPeriodoDataGridViewTextBoxColumn1.Name = "anioPeriodoDataGridViewTextBoxColumn1";
            this.anioPeriodoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.anioPeriodoDataGridViewTextBoxColumn1.Width = 40;
            // 
            // mesPeriodoDataGridViewTextBoxColumn1
            // 
            this.mesPeriodoDataGridViewTextBoxColumn1.DataPropertyName = "MesPeriodo";
            this.mesPeriodoDataGridViewTextBoxColumn1.HeaderText = "Mes";
            this.mesPeriodoDataGridViewTextBoxColumn1.Name = "mesPeriodoDataGridViewTextBoxColumn1";
            this.mesPeriodoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.mesPeriodoDataGridViewTextBoxColumn1.Width = 35;
            // 
            // DesSistema
            // 
            this.DesSistema.DataPropertyName = "DesSistema";
            this.DesSistema.HeaderText = "Sistema";
            this.DesSistema.Name = "DesSistema";
            this.DesSistema.ReadOnly = true;
            this.DesSistema.Width = 120;
            // 
            // indCierreDataGridViewCheckBoxColumn1
            // 
            this.indCierreDataGridViewCheckBoxColumn1.DataPropertyName = "indCierre";
            this.indCierreDataGridViewCheckBoxColumn1.HeaderText = "I.C.";
            this.indCierreDataGridViewCheckBoxColumn1.Name = "indCierreDataGridViewCheckBoxColumn1";
            this.indCierreDataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // fechaCierreDataGridViewTextBoxColumn1
            // 
            this.fechaCierreDataGridViewTextBoxColumn1.DataPropertyName = "FechaCierre";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaCierreDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaCierreDataGridViewTextBoxColumn1.HeaderText = "FechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn1.Name = "fechaCierreDataGridViewTextBoxColumn1";
            this.fechaCierreDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaCierreDataGridViewTextBoxColumn1.Width = 85;
            // 
            // usuarioRegistroDataGridViewTextBoxColumn1
            // 
            this.usuarioRegistroDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.HeaderText = "UsuarioRegistro";
            this.usuarioRegistroDataGridViewTextBoxColumn1.Name = "usuarioRegistroDataGridViewTextBoxColumn1";
            this.usuarioRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fechaRegistroDataGridViewTextBoxColumn1
            // 
            this.fechaRegistroDataGridViewTextBoxColumn1.DataPropertyName = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn1.HeaderText = "FechaRegistro";
            this.fechaRegistroDataGridViewTextBoxColumn1.Name = "fechaRegistroDataGridViewTextBoxColumn1";
            this.fechaRegistroDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn1
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn1.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn1.Name = "usuarioModificacionDataGridViewTextBoxColumn1";
            this.usuarioModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn1
            // 
            this.fechaModificacionDataGridViewTextBoxColumn1.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn1.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn1.Name = "fechaModificacionDataGridViewTextBoxColumn1";
            this.fechaModificacionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // frmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 384);
            this.Controls.Add(this.btnAgreSis);
            this.Controls.Add(this.btnEliSis);
            this.Controls.Add(this.btnAgregarAlm);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "frmCierre";
            this.Text = "Cierre";
            this.Load += new System.EventHandler(this.frmCierre_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCierreSistema)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCierreAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvSistema;
        private MyLabelG.LabelDegradado lblReg2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAlm;
        private MyLabelG.LabelDegradado lblReg1;
        private System.Windows.Forms.BindingSource bsCierreAlmacen;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregarAlm;
        private System.Windows.Forms.Button btnAgreSis;
        private System.Windows.Forms.Button btnEliSis;
        private System.Windows.Forms.BindingSource bsCierreSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesPeriodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesAlmacen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCierreDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioPeriodoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesPeriodoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesSistema;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indCierreDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCierreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn1;
    }
}