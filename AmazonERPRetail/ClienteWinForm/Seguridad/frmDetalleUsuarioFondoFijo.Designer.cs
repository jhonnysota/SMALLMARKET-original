namespace ClienteWinForm.Seguridad
{
    partial class frmDetalleUsuarioFondoFijo
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label idLocalLabel;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtIdEmpresa = new ControlesWinForm.SuperTextBox();
            this.txtDesEmpresa = new ControlesWinForm.SuperTextBox();
            this.chkVisualizar = new System.Windows.Forms.CheckBox();
            this.chkEditar = new System.Windows.Forms.CheckBox();
            this.txtIdUsuario = new ControlesWinForm.SuperTextBox();
            this.txtNomUsuario = new ControlesWinForm.SuperTextBox();
            this.cboTipoFondo = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            idLocalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(373, 146);
            this.btCancelar.Size = new System.Drawing.Size(119, 25);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(249, 146);
            this.btAceptar.Size = new System.Drawing.Size(119, 25);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(455, 16);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(728, 25);
            this.lblTituloPrincipal.Text = "Detalle Tipo Fondo Fijo";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(699, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.cboTipoFondo);
            this.pnlBase.Controls.Add(idLocalLabel);
            this.pnlBase.Controls.Add(this.txtIdEmpresa);
            this.pnlBase.Controls.Add(this.txtDesEmpresa);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(this.chkVisualizar);
            this.pnlBase.Controls.Add(this.chkEditar);
            this.pnlBase.Controls.Add(this.txtIdUsuario);
            this.pnlBase.Controls.Add(this.txtNomUsuario);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(457, 113);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNomUsuario, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdUsuario, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkEditar, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkVisualizar, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesEmpresa, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdEmpresa, 0);
            this.pnlBase.Controls.SetChildIndex(idLocalLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoFondo, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 89);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 68);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(8, 26);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(8, 47);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(11, 31);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(48, 13);
            label6.TabIndex = 622;
            label6.Text = "Empresa";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(11, 54);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(43, 13);
            idArticuloLabel.TabIndex = 617;
            idArticuloLabel.Text = "Usuario";
            // 
            // idLocalLabel
            // 
            idLocalLabel.AutoSize = true;
            idLocalLabel.BackColor = System.Drawing.Color.Transparent;
            idLocalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idLocalLabel.Location = new System.Drawing.Point(11, 77);
            idLocalLabel.Name = "idLocalLabel";
            idLocalLabel.Size = new System.Drawing.Size(61, 13);
            idLocalLabel.TabIndex = 624;
            idLocalLabel.Text = "Tipo Fondo";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(466, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(255, 113);
            this.pnlAuditoria.TabIndex = 259;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(253, 16);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(114, 85);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(128, 20);
            this.txtFechaModifica.TabIndex = 304;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 22);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(128, 20);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(114, 64);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(128, 20);
            this.txtUsuarioMod.TabIndex = 303;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 43);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(128, 20);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdEmpresa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdEmpresa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdEmpresa.Enabled = false;
            this.txtIdEmpresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEmpresa.Location = new System.Drawing.Point(76, 27);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(54, 21);
            this.txtIdEmpresa.TabIndex = 623;
            this.txtIdEmpresa.TabStop = false;
            this.txtIdEmpresa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdEmpresa.TextoVacio = "<Descripcion>";
            // 
            // txtDesEmpresa
            // 
            this.txtDesEmpresa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesEmpresa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesEmpresa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesEmpresa.Enabled = false;
            this.txtDesEmpresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesEmpresa.Location = new System.Drawing.Point(132, 27);
            this.txtDesEmpresa.Name = "txtDesEmpresa";
            this.txtDesEmpresa.Size = new System.Drawing.Size(308, 21);
            this.txtDesEmpresa.TabIndex = 621;
            this.txtDesEmpresa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesEmpresa.TextoVacio = "<Descripcion>";
            // 
            // chkVisualizar
            // 
            this.chkVisualizar.AutoSize = true;
            this.chkVisualizar.Location = new System.Drawing.Point(367, 76);
            this.chkVisualizar.Name = "chkVisualizar";
            this.chkVisualizar.Size = new System.Drawing.Size(70, 17);
            this.chkVisualizar.TabIndex = 620;
            this.chkVisualizar.Text = "Visualizar";
            this.chkVisualizar.UseVisualStyleBackColor = true;
            // 
            // chkEditar
            // 
            this.chkEditar.AutoSize = true;
            this.chkEditar.Location = new System.Drawing.Point(304, 76);
            this.chkEditar.Name = "chkEditar";
            this.chkEditar.Size = new System.Drawing.Size(53, 17);
            this.chkEditar.TabIndex = 619;
            this.chkEditar.Text = "Editar";
            this.chkEditar.UseVisualStyleBackColor = true;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdUsuario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdUsuario.Enabled = false;
            this.txtIdUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(76, 50);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(54, 21);
            this.txtIdUsuario.TabIndex = 618;
            this.txtIdUsuario.TabStop = false;
            this.txtIdUsuario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdUsuario.TextoVacio = "<Descripcion>";
            // 
            // txtNomUsuario
            // 
            this.txtNomUsuario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNomUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNomUsuario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNomUsuario.Enabled = false;
            this.txtNomUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomUsuario.Location = new System.Drawing.Point(132, 50);
            this.txtNomUsuario.Name = "txtNomUsuario";
            this.txtNomUsuario.Size = new System.Drawing.Size(308, 21);
            this.txtNomUsuario.TabIndex = 616;
            this.txtNomUsuario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNomUsuario.TextoVacio = "<Descripcion>";
            // 
            // cboTipoFondo
            // 
            this.cboTipoFondo.BackColor = System.Drawing.Color.White;
            this.cboTipoFondo.DisplayMember = "Nombre";
            this.cboTipoFondo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFondo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoFondo.FormattingEnabled = true;
            this.cboTipoFondo.Location = new System.Drawing.Point(76, 73);
            this.cboTipoFondo.Name = "cboTipoFondo";
            this.cboTipoFondo.Size = new System.Drawing.Size(178, 21);
            this.cboTipoFondo.TabIndex = 625;
            this.cboTipoFondo.ValueMember = "IdLocal";
            // 
            // frmDetalleUsuarioFondoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 177);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleUsuarioFondoFijo";
            this.Text = "frmDetalleUsuarioFondoFijo";
            this.Load += new System.EventHandler(this.frmDetalleUsuarioFondoFijo_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private ControlesWinForm.SuperTextBox txtIdEmpresa;
        private ControlesWinForm.SuperTextBox txtDesEmpresa;
        private System.Windows.Forms.CheckBox chkVisualizar;
        private System.Windows.Forms.CheckBox chkEditar;
        private ControlesWinForm.SuperTextBox txtIdUsuario;
        private ControlesWinForm.SuperTextBox txtNomUsuario;
        private System.Windows.Forms.ComboBox cboTipoFondo;
    }
}