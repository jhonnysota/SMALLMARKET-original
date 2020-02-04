namespace ClienteWinForm.Seguridad
{
    partial class FrmUsuarioRol
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
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvRol = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.fechaModificacionTextBox = new System.Windows.Forms.TextBox();
            this.fechaRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblRoles = new MyLabelG.LabelDegradado();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Location = new System.Drawing.Point(8, 94);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Location = new System.Drawing.Point(8, 73);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(106, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Location = new System.Drawing.Point(8, 31);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Location = new System.Drawing.Point(8, 52);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.button2.Location = new System.Drawing.Point(653, 500);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "Eliminar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.button1.Location = new System.Drawing.Point(537, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Agregar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvRol);
            this.panel3.Controls.Add(this.labelDegradado1);
            this.panel3.Location = new System.Drawing.Point(5, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 246);
            this.panel3.TabIndex = 5;
            // 
            // dgvRol
            // 
            this.dgvRol.AllowUserToAddRows = false;
            this.dgvRol.AllowUserToDeleteRows = false;
            this.dgvRol.AutoGenerateColumns = false;
            this.dgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvRol.DataSource = this.rolBindingSource;
            this.dgvRol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRol.EnableHeadersVisualStyles = false;
            this.dgvRol.Location = new System.Drawing.Point(0, 19);
            this.dgvRol.MultiSelect = false;
            this.dgvRol.Name = "dgvRol";
            this.dgvRol.ReadOnly = true;
            this.dgvRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRol.Size = new System.Drawing.Size(513, 225);
            this.dgvRol.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdRol";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 192;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(Entidades.Seguridad.Rol);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(513, 19);
            this.labelDegradado1.TabIndex = 251;
            this.labelDegradado1.Text = "Roles";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Controls.Add(fechaModificacionLabel);
            this.panel2.Controls.Add(this.fechaModificacionTextBox);
            this.panel2.Controls.Add(this.fechaRegistroTextBox);
            this.panel2.Controls.Add(usuarioModificacionLabel);
            this.panel2.Controls.Add(this.usuarioRegistroTextBox);
            this.panel2.Controls.Add(this.usuarioModificacionTextBox);
            this.panel2.Controls.Add(usuarioRegistroLabel);
            this.panel2.Controls.Add(fechaRegistroLabel);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(525, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 121);
            this.panel2.TabIndex = 4;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(265, 19);
            this.labelDegradado2.TabIndex = 251;
            this.labelDegradado2.Text = "Auditoria";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fechaModificacionTextBox
            // 
            this.fechaModificacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rolBindingSource, "FechaModificacion", true));
            this.fechaModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionTextBox.Location = new System.Drawing.Point(118, 90);
            this.fechaModificacionTextBox.Name = "fechaModificacionTextBox";
            this.fechaModificacionTextBox.Size = new System.Drawing.Size(135, 21);
            this.fechaModificacionTextBox.TabIndex = 7;
            // 
            // fechaRegistroTextBox
            // 
            this.fechaRegistroTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rolBindingSource, "FechaRegistro", true));
            this.fechaRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaRegistroTextBox.Location = new System.Drawing.Point(118, 48);
            this.fechaRegistroTextBox.Name = "fechaRegistroTextBox";
            this.fechaRegistroTextBox.Size = new System.Drawing.Size(135, 21);
            this.fechaRegistroTextBox.TabIndex = 3;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rolBindingSource, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(118, 27);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(135, 21);
            this.usuarioRegistroTextBox.TabIndex = 1;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rolBindingSource, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(118, 69);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(135, 21);
            this.usuarioModificacionTextBox.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvUsuario);
            this.panel1.Controls.Add(this.lblRoles);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 214);
            this.panel1.TabIndex = 3;
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AutoGenerateColumns = false;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            this.dgvUsuario.DataSource = this.usuarioBindingSource;
            this.dgvUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuario.EnableHeadersVisualStyles = false;
            this.dgvUsuario.Location = new System.Drawing.Point(0, 19);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(513, 193);
            this.dgvUsuario.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Credencial";
            this.dataGridViewTextBoxColumn9.HeaderText = "Credencial";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "NombreCompleto";
            this.dataGridViewTextBoxColumn18.HeaderText = "NombreCompleto";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 253;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "NroDocumento";
            this.dataGridViewTextBoxColumn19.HeaderText = "NroDocumento";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataSource = typeof(Entidades.Seguridad.Usuario);
            this.usuarioBindingSource.CurrentChanged += new System.EventHandler(this.usuarioBindingSource_CurrentChanged);
            // 
            // lblRoles
            // 
            this.lblRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoles.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRoles.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoles.ForeColor = System.Drawing.Color.White;
            this.lblRoles.Location = new System.Drawing.Point(0, 0);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRoles.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRoles.Size = new System.Drawing.Size(513, 19);
            this.lblRoles.TabIndex = 250;
            this.lblRoles.Text = "Usuarios";
            this.lblRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.cboEmpresa);
            this.pnlDetalle.Controls.Add(this.labelDegradado3);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 225);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(185, 52);
            this.pnlDetalle.TabIndex = 7;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.DropDownWidth = 79;
            this.cboEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(5, 27);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(176, 21);
            this.cboEmpresa.TabIndex = 305;
            this.cboEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cboEmpresa_SelectionChangeCommitted);
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(183, 23);
            this.labelDegradado3.TabIndex = 252;
            this.labelDegradado3.Text = "Buscador";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmUsuarioRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 529);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmUsuarioRol";
            this.Text = "MANTENIMIENTO USUARIO ROL";
            this.Load += new System.EventHandler(this.FrmUsuarioRol_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRol;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fechaModificacionTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox fechaRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private MyLabelG.LabelDegradado labelDegradado1;
        private MyLabelG.LabelDegradado labelDegradado2;
        private MyLabelG.LabelDegradado lblRoles;
        private System.Windows.Forms.Panel pnlDetalle;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.ComboBox cboEmpresa;
    }
}