namespace ClienteWinForm.Seguridad
{
    partial class frmDetalleUsuarioCobranza
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
            System.Windows.Forms.Label idEmpresaLabel;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.cboTipoCobranza = new System.Windows.Forms.ComboBox();
            this.txtIdUsuario = new ControlesWinForm.SuperTextBox();
            this.txtNomUsuario = new ControlesWinForm.SuperTextBox();
            this.chkAbrir = new System.Windows.Forms.CheckBox();
            this.chkCerrar = new System.Windows.Forms.CheckBox();
            this.txtIdLocal = new ControlesWinForm.SuperTextBox();
            this.txtNombreLocal = new ControlesWinForm.SuperTextBox();
            this.txtIdEmpresa = new ControlesWinForm.SuperTextBox();
            this.txtDesEmpresa = new ControlesWinForm.SuperTextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            idEmpresaLabel = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
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
            this.btCancelar.Location = new System.Drawing.Point(387, 159);
            this.btCancelar.Size = new System.Drawing.Size(119, 25);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(263, 159);
            this.btAceptar.Size = new System.Drawing.Size(119, 25);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(493, 22);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(766, 25);
            this.lblTituloPrincipal.Text = "Detalle Tipo Planilla de Cobranza";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(739, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtIdEmpresa);
            this.pnlBase.Controls.Add(this.txtDesEmpresa);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(this.txtIdLocal);
            this.pnlBase.Controls.Add(this.txtNombreLocal);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.chkCerrar);
            this.pnlBase.Controls.Add(this.chkAbrir);
            this.pnlBase.Controls.Add(this.cboTipoCobranza);
            this.pnlBase.Controls.Add(idEmpresaLabel);
            this.pnlBase.Controls.Add(this.txtIdUsuario);
            this.pnlBase.Controls.Add(this.txtNomUsuario);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(495, 125);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNomUsuario, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdUsuario, 0);
            this.pnlBase.Controls.SetChildIndex(idEmpresaLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoCobranza, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkAbrir, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkCerrar, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNombreLocal, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdLocal, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesEmpresa, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdEmpresa, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(8, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(8, 55);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.BackColor = System.Drawing.Color.Transparent;
            idEmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idEmpresaLabel.Location = new System.Drawing.Point(12, 98);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new System.Drawing.Size(100, 13);
            idEmpresaLabel.TabIndex = 607;
            idEmpresaLabel.Text = "Tip. Plan. Cobranza";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(12, 78);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(43, 13);
            idArticuloLabel.TabIndex = 273;
            idArticuloLabel.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(12, 56);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 13);
            label2.TabIndex = 611;
            label2.Text = "Sucursal / Local";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(12, 34);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(48, 13);
            label6.TabIndex = 614;
            label6.Text = "Empresa";
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
            this.pnlAuditoria.Location = new System.Drawing.Point(504, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(255, 125);
            this.pnlAuditoria.TabIndex = 258;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(253, 20);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(114, 93);
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
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 30);
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
            this.txtUsuarioMod.Location = new System.Drawing.Point(114, 72);
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
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 51);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(128, 20);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // cboTipoCobranza
            // 
            this.cboTipoCobranza.BackColor = System.Drawing.Color.White;
            this.cboTipoCobranza.DisplayMember = "NombreComercial";
            this.cboTipoCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCobranza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCobranza.FormattingEnabled = true;
            this.cboTipoCobranza.Location = new System.Drawing.Point(118, 94);
            this.cboTipoCobranza.Name = "cboTipoCobranza";
            this.cboTipoCobranza.Size = new System.Drawing.Size(178, 21);
            this.cboTipoCobranza.TabIndex = 608;
            this.cboTipoCobranza.ValueMember = "IdEmpresa";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdUsuario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdUsuario.Enabled = false;
            this.txtIdUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(118, 72);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(54, 21);
            this.txtIdUsuario.TabIndex = 274;
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
            this.txtNomUsuario.Location = new System.Drawing.Point(172, 72);
            this.txtNomUsuario.Name = "txtNomUsuario";
            this.txtNomUsuario.Size = new System.Drawing.Size(308, 21);
            this.txtNomUsuario.TabIndex = 272;
            this.txtNomUsuario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNomUsuario.TextoVacio = "<Descripcion>";
            // 
            // chkAbrir
            // 
            this.chkAbrir.AutoSize = true;
            this.chkAbrir.Location = new System.Drawing.Point(304, 97);
            this.chkAbrir.Name = "chkAbrir";
            this.chkAbrir.Size = new System.Drawing.Size(83, 17);
            this.chkAbrir.TabIndex = 275;
            this.chkAbrir.Text = "Abrir Planilla";
            this.chkAbrir.UseVisualStyleBackColor = true;
            // 
            // chkCerrar
            // 
            this.chkCerrar.AutoSize = true;
            this.chkCerrar.Location = new System.Drawing.Point(393, 97);
            this.chkCerrar.Name = "chkCerrar";
            this.chkCerrar.Size = new System.Drawing.Size(90, 17);
            this.chkCerrar.TabIndex = 609;
            this.chkCerrar.Text = "Cerrar Planilla";
            this.chkCerrar.UseVisualStyleBackColor = true;
            // 
            // txtIdLocal
            // 
            this.txtIdLocal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdLocal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdLocal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdLocal.Enabled = false;
            this.txtIdLocal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdLocal.Location = new System.Drawing.Point(118, 51);
            this.txtIdLocal.Name = "txtIdLocal";
            this.txtIdLocal.Size = new System.Drawing.Size(54, 21);
            this.txtIdLocal.TabIndex = 612;
            this.txtIdLocal.TabStop = false;
            this.txtIdLocal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdLocal.TextoVacio = "<Descripcion>";
            // 
            // txtNombreLocal
            // 
            this.txtNombreLocal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreLocal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNombreLocal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreLocal.Enabled = false;
            this.txtNombreLocal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreLocal.Location = new System.Drawing.Point(172, 51);
            this.txtNombreLocal.Name = "txtNombreLocal";
            this.txtNombreLocal.Size = new System.Drawing.Size(308, 21);
            this.txtNombreLocal.TabIndex = 610;
            this.txtNombreLocal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreLocal.TextoVacio = "<Descripcion>";
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdEmpresa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdEmpresa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdEmpresa.Enabled = false;
            this.txtIdEmpresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEmpresa.Location = new System.Drawing.Point(118, 30);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(54, 21);
            this.txtIdEmpresa.TabIndex = 615;
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
            this.txtDesEmpresa.Location = new System.Drawing.Point(172, 30);
            this.txtDesEmpresa.Name = "txtDesEmpresa";
            this.txtDesEmpresa.Size = new System.Drawing.Size(308, 21);
            this.txtDesEmpresa.TabIndex = 613;
            this.txtDesEmpresa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesEmpresa.TextoVacio = "<Descripcion>";
            // 
            // frmDetalleUsuarioCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 192);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleUsuarioCobranza";
            this.Text = "frmDetalleUsuarioCobranza";
            this.Load += new System.EventHandler(this.frmDetalleUsuarioCobranza_Load);
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
        private System.Windows.Forms.ComboBox cboTipoCobranza;
        private ControlesWinForm.SuperTextBox txtIdEmpresa;
        private ControlesWinForm.SuperTextBox txtDesEmpresa;
        private ControlesWinForm.SuperTextBox txtIdLocal;
        private ControlesWinForm.SuperTextBox txtNombreLocal;
        private System.Windows.Forms.CheckBox chkCerrar;
        private System.Windows.Forms.CheckBox chkAbrir;
        private ControlesWinForm.SuperTextBox txtIdUsuario;
        private ControlesWinForm.SuperTextBox txtNomUsuario;
    }
}