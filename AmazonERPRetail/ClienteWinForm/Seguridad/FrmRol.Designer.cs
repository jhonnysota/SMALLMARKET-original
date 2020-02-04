namespace ClienteWinForm.Seguridad
{
    partial class FrmRol
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
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label idRolLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label descripcionLabel;
            this.bsRol = new System.Windows.Forms.BindingSource(this.components);
            this.fechaModificacionTextBox = new System.Windows.Forms.TextBox();
            this.fechaRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.idRolTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.estadoCheckBox = new System.Windows.Forms.CheckBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            idRolLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsRol)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(9, 102);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(9, 56);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 4;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(9, 79);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 2;
            usuarioModificacionLabel.Text = "Usuario Modificación";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(9, 33);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // idRolLabel
            // 
            idRolLabel.AutoSize = true;
            idRolLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idRolLabel.Location = new System.Drawing.Point(6, 43);
            idRolLabel.Name = "idRolLabel";
            idRolLabel.Size = new System.Drawing.Size(40, 13);
            idRolLabel.TabIndex = 6;
            idRolLabel.Text = "Código";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(6, 67);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(44, 13);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Nombre";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.Location = new System.Drawing.Point(6, 90);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(61, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripcion";
            // 
            // bsRol
            // 
            this.bsRol.DataSource = typeof(Entidades.Seguridad.Rol);
            // 
            // fechaModificacionTextBox
            // 
            this.fechaModificacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaModificacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fechaModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRol, "FechaModificacion", true));
            this.fechaModificacionTextBox.Enabled = false;
            this.fechaModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionTextBox.Location = new System.Drawing.Point(116, 99);
            this.fechaModificacionTextBox.Name = "fechaModificacionTextBox";
            this.fechaModificacionTextBox.Size = new System.Drawing.Size(116, 21);
            this.fechaModificacionTextBox.TabIndex = 9;
            // 
            // fechaRegistroTextBox
            // 
            this.fechaRegistroTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaRegistroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fechaRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRol, "FechaRegistro", true));
            this.fechaRegistroTextBox.Enabled = false;
            this.fechaRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaRegistroTextBox.Location = new System.Drawing.Point(116, 53);
            this.fechaRegistroTextBox.Name = "fechaRegistroTextBox";
            this.fechaRegistroTextBox.Size = new System.Drawing.Size(116, 21);
            this.fechaRegistroTextBox.TabIndex = 7;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioModificacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRol, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(116, 76);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(116, 21);
            this.usuarioModificacionTextBox.TabIndex = 8;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioRegistroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRol, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(116, 30);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(116, 21);
            this.usuarioRegistroTextBox.TabIndex = 6;
            // 
            // idRolTextBox
            // 
            this.idRolTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.idRolTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idRolTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idRolTextBox.Location = new System.Drawing.Point(78, 40);
            this.idRolTextBox.Name = "idRolTextBox";
            this.idRolTextBox.ReadOnly = true;
            this.idRolTextBox.Size = new System.Drawing.Size(100, 21);
            this.idRolTextBox.TabIndex = 1;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRol, "Nombre", true));
            this.nombreTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreTextBox.Location = new System.Drawing.Point(78, 64);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(343, 21);
            this.nombreTextBox.TabIndex = 2;
            // 
            // estadoCheckBox
            // 
            this.estadoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsRol, "Estado", true));
            this.estadoCheckBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoCheckBox.Location = new System.Drawing.Point(338, 40);
            this.estadoCheckBox.Name = "estadoCheckBox";
            this.estadoCheckBox.Size = new System.Drawing.Size(83, 24);
            this.estadoCheckBox.TabIndex = 4;
            this.estadoCheckBox.Text = "De Baja";
            this.estadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRol, "Descripcion", true));
            this.descripcionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionTextBox.Location = new System.Drawing.Point(78, 87);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(343, 21);
            this.descripcionTextBox.TabIndex = 3;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.lblRegistros);
            this.pnlDetalle.Controls.Add(idRolLabel);
            this.pnlDetalle.Controls.Add(this.idRolTextBox);
            this.pnlDetalle.Controls.Add(this.nombreTextBox);
            this.pnlDetalle.Controls.Add(nombreLabel);
            this.pnlDetalle.Controls.Add(this.descripcionTextBox);
            this.pnlDetalle.Controls.Add(descripcionLabel);
            this.pnlDetalle.Controls.Add(this.estadoCheckBox);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 5);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(433, 130);
            this.pnlDetalle.TabIndex = 2;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(431, 23);
            this.lblRegistros.TabIndex = 252;
            this.lblRegistros.Text = "Datos";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionTextBox);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(this.fechaRegistroTextBox);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.labelDegradado1);
            this.pnlAuditoria.Location = new System.Drawing.Point(440, 5);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(246, 130);
            this.pnlAuditoria.TabIndex = 5;
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
            this.labelDegradado1.Size = new System.Drawing.Size(244, 23);
            this.labelDegradado1.TabIndex = 252;
            this.labelDegradado1.Text = "Auditoria";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 140);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDetalle);
            this.MaximizeBox = false;
            this.Name = "FrmRol";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.FrmRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRol)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fechaModificacionTextBox;
        private System.Windows.Forms.BindingSource bsRol;
        private System.Windows.Forms.TextBox fechaRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.TextBox idRolTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.CheckBox estadoCheckBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado lblRegistros;
        private MyLabelG.LabelDegradado labelDegradado1;
    }
}