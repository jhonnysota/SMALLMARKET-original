namespace ClienteWinForm.Maestros
{
    partial class frmDetalleClienteAval
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
            System.Windows.Forms.Label direccionLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label idAvalLabel;
            System.Windows.Forms.Label nroDocumentoLabel;
            System.Windows.Forms.Label razonSocialLabel;
            System.Windows.Forms.Label telefonosLabel;
            System.Windows.Forms.Label tipoDocumentoLabel;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.txtEmail = new ControlesWinForm.SuperTextBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.txtIdAval = new ControlesWinForm.SuperTextBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.txtTelefonos = new ControlesWinForm.SuperTextBox();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.btSunat = new System.Windows.Forms.Button();
            this.btReniec = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            direccionLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            idAvalLabel = new System.Windows.Forms.Label();
            nroDocumentoLabel = new System.Windows.Forms.Label();
            razonSocialLabel = new System.Windows.Forms.Label();
            telefonosLabel = new System.Windows.Forms.Label();
            tipoDocumentoLabel = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(622, 18);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(900, 25);
            this.lblTituloPrincipal.Text = "Avales de Clientes";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(871, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btSunat);
            this.pnlBase.Controls.Add(direccionLabel);
            this.pnlBase.Controls.Add(this.txtDireccion);
            this.pnlBase.Controls.Add(emailLabel);
            this.pnlBase.Controls.Add(this.txtEmail);
            this.pnlBase.Controls.Add(this.chkPrincipal);
            this.pnlBase.Controls.Add(idAvalLabel);
            this.pnlBase.Controls.Add(this.txtIdAval);
            this.pnlBase.Controls.Add(nroDocumentoLabel);
            this.pnlBase.Controls.Add(this.txtRuc);
            this.pnlBase.Controls.Add(razonSocialLabel);
            this.pnlBase.Controls.Add(this.txtRazonSocial);
            this.pnlBase.Controls.Add(telefonosLabel);
            this.pnlBase.Controls.Add(this.txtTelefonos);
            this.pnlBase.Controls.Add(tipoDocumentoLabel);
            this.pnlBase.Controls.Add(this.cboTipoDocumento);
            this.pnlBase.Controls.Add(this.btReniec);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(624, 127);
            this.pnlBase.Controls.SetChildIndex(this.btReniec, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipoDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(tipoDocumentoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTelefonos, 0);
            this.pnlBase.Controls.SetChildIndex(telefonosLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRazonSocial, 0);
            this.pnlBase.Controls.SetChildIndex(razonSocialLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRuc, 0);
            this.pnlBase.Controls.SetChildIndex(nroDocumentoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdAval, 0);
            this.pnlBase.Controls.SetChildIndex(idAvalLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkPrincipal, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtEmail, 0);
            this.pnlBase.Controls.SetChildIndex(emailLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDireccion, 0);
            this.pnlBase.Controls.SetChildIndex(direccionLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.btSunat, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(454, 160);
            this.btCancelar.Size = new System.Drawing.Size(116, 25);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(330, 160);
            this.btAceptar.Size = new System.Drawing.Size(116, 25);
            this.btAceptar.TabIndex = 258;
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Location = new System.Drawing.Point(11, 74);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new System.Drawing.Size(52, 13);
            direccionLabel.TabIndex = 250;
            direccionLabel.Text = "Dirección";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(231, 95);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(32, 13);
            emailLabel.TabIndex = 252;
            emailLabel.Text = "Email";
            // 
            // idAvalLabel
            // 
            idAvalLabel.AutoSize = true;
            idAvalLabel.Location = new System.Drawing.Point(11, 32);
            idAvalLabel.Name = "idAvalLabel";
            idAvalLabel.Size = new System.Drawing.Size(29, 13);
            idAvalLabel.TabIndex = 256;
            idAvalLabel.Text = "Cód.";
            // 
            // nroDocumentoLabel
            // 
            nroDocumentoLabel.AutoSize = true;
            nroDocumentoLabel.Location = new System.Drawing.Point(363, 32);
            nroDocumentoLabel.Name = "nroDocumentoLabel";
            nroDocumentoLabel.Size = new System.Drawing.Size(85, 13);
            nroDocumentoLabel.TabIndex = 262;
            nroDocumentoLabel.Text = "Nro. Documento";
            // 
            // razonSocialLabel
            // 
            razonSocialLabel.AutoSize = true;
            razonSocialLabel.Location = new System.Drawing.Point(11, 53);
            razonSocialLabel.Name = "razonSocialLabel";
            razonSocialLabel.Size = new System.Drawing.Size(70, 13);
            razonSocialLabel.TabIndex = 264;
            razonSocialLabel.Text = "Razón Social";
            // 
            // telefonosLabel
            // 
            telefonosLabel.AutoSize = true;
            telefonosLabel.Location = new System.Drawing.Point(11, 95);
            telefonosLabel.Name = "telefonosLabel";
            telefonosLabel.Size = new System.Drawing.Size(54, 13);
            telefonosLabel.TabIndex = 266;
            telefonosLabel.Text = "Teléfonos";
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.AutoSize = true;
            tipoDocumentoLabel.Location = new System.Drawing.Point(152, 32);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new System.Drawing.Size(86, 13);
            tipoDocumentoLabel.TabIndex = 268;
            tipoDocumentoLabel.Text = "Tipo Documento";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 96);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 75);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(106, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 33);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 54);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Location = new System.Drawing.Point(86, 71);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(526, 20);
            this.txtDireccion.TabIndex = 254;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "<Descripcion>";
            // 
            // txtEmail
            // 
            this.txtEmail.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmail.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmail.Location = new System.Drawing.Point(269, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 20);
            this.txtEmail.TabIndex = 256;
            this.txtEmail.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmail.TextoVacio = "<Descripcion>";
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.Location = new System.Drawing.Point(453, 93);
            this.chkPrincipal.Name = "chkPrincipal";
            this.chkPrincipal.Size = new System.Drawing.Size(107, 21);
            this.chkPrincipal.TabIndex = 257;
            this.chkPrincipal.TabStop = false;
            this.chkPrincipal.Text = "Es Principal";
            this.chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // txtIdAval
            // 
            this.txtIdAval.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdAval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdAval.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdAval.Enabled = false;
            this.txtIdAval.Location = new System.Drawing.Point(86, 28);
            this.txtIdAval.Name = "txtIdAval";
            this.txtIdAval.Size = new System.Drawing.Size(64, 20);
            this.txtIdAval.TabIndex = 250;
            this.txtIdAval.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdAval.TextoVacio = "<Descripcion>";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Location = new System.Drawing.Point(449, 28);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(102, 20);
            this.txtRuc.TabIndex = 252;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Location = new System.Drawing.Point(86, 50);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(526, 20);
            this.txtRazonSocial.TabIndex = 253;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTelefonos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTelefonos.Location = new System.Drawing.Point(86, 92);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(139, 20);
            this.txtTelefonos.TabIndex = 255;
            this.txtTelefonos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTelefonos.TextoVacio = "<Descripcion>";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(240, 28);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDocumento.TabIndex = 251;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label6);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(633, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(258, 127);
            this.pnlAuditoria.TabIndex = 291;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(114, 92);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(132, 20);
            this.txtFechaModificacion.TabIndex = 103;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 29);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(132, 20);
            this.txtUsuarioRegistro.TabIndex = 100;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 71);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(132, 20);
            this.txtUsuarioModificacion.TabIndex = 102;
            this.txtUsuarioModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 50);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(132, 20);
            this.txtFechaRegistro.TabIndex = 101;
            this.txtFechaRegistro.TabStop = false;
            // 
            // btSunat
            // 
            this.btSunat.BackColor = System.Drawing.Color.White;
            this.btSunat.Enabled = false;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Image = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btSunat.Location = new System.Drawing.Point(554, 29);
            this.btSunat.Margin = new System.Windows.Forms.Padding(2);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(57, 18);
            this.btSunat.TabIndex = 298;
            this.btSunat.TabStop = false;
            this.btSunat.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSunat.UseVisualStyleBackColor = false;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // btReniec
            // 
            this.btReniec.BackColor = System.Drawing.Color.White;
            this.btReniec.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btReniec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btReniec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btReniec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReniec.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReniec.Image = global::ClienteWinForm.Properties.Resources.reniec;
            this.btReniec.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btReniec.Location = new System.Drawing.Point(554, 29);
            this.btReniec.Margin = new System.Windows.Forms.Padding(2);
            this.btReniec.Name = "btReniec";
            this.btReniec.Size = new System.Drawing.Size(57, 18);
            this.btReniec.TabIndex = 292;
            this.btReniec.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReniec.UseVisualStyleBackColor = false;
            this.btReniec.Visible = false;
            this.btReniec.Click += new System.EventHandler(this.btReniec_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 18);
            this.label6.TabIndex = 347;
            this.label6.Text = "Auditoria";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDetalleClienteAval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 190);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleClienteAval";
            this.Text = "frmDetalleClienteAval";
            this.Load += new System.EventHandler(this.frmDetalleClienteAval_Load);
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

        private ControlesWinForm.SuperTextBox txtDireccion;
        private ControlesWinForm.SuperTextBox txtEmail;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private ControlesWinForm.SuperTextBox txtIdAval;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtTelefonos;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Button btSunat;
        private System.Windows.Forms.Button btReniec;
        private System.Windows.Forms.Label label6;
    }
}