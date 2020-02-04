namespace ClienteWinForm.Maestros
{
    partial class frmOperadorLogistico
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
            this.pnlCondicion = new System.Windows.Forms.Panel();
            this.txtFecBaja = new ControlesWinForm.SuperTextBox();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.pnlDireccion = new System.Windows.Forms.Panel();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtWeb = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCorreo = new ControlesWinForm.SuperTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFax = new ControlesWinForm.SuperTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtTelefonos = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdOperador = new ControlesWinForm.SuperTextBox();
            this.btSunat = new System.Windows.Forms.Button();
            this.lblComercial = new System.Windows.Forms.Label();
            this.txtComercial = new ControlesWinForm.SuperTextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new ControlesWinForm.SuperTextBox();
            this.lblApeMat = new System.Windows.Forms.Label();
            this.txtApeMat = new ControlesWinForm.SuperTextBox();
            this.lblApePat = new System.Windows.Forms.Label();
            this.txtApePat = new ControlesWinForm.SuperTextBox();
            this.lblRazon = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazon = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoPersona = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlCondicion.SuspendLayout();
            this.pnlDireccion.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCondicion
            // 
            this.pnlCondicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCondicion.Controls.Add(this.label6);
            this.pnlCondicion.Controls.Add(this.txtFecBaja);
            this.pnlCondicion.Controls.Add(this.chkBaja);
            this.pnlCondicion.Location = new System.Drawing.Point(610, 5);
            this.pnlCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCondicion.Name = "pnlCondicion";
            this.pnlCondicion.Size = new System.Drawing.Size(267, 73);
            this.pnlCondicion.TabIndex = 124;
            // 
            // txtFecBaja
            // 
            this.txtFecBaja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecBaja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecBaja.Enabled = false;
            this.txtFecBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecBaja.Location = new System.Drawing.Point(99, 37);
            this.txtFecBaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecBaja.Name = "txtFecBaja";
            this.txtFecBaja.Size = new System.Drawing.Size(148, 20);
            this.txtFecBaja.TabIndex = 100;
            this.txtFecBaja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecBaja.TextoVacio = "<Descripcion>";
            // 
            // chkBaja
            // 
            this.chkBaja.AutoSize = true;
            this.chkBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaja.Location = new System.Drawing.Point(14, 39);
            this.chkBaja.Margin = new System.Windows.Forms.Padding(2);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(81, 17);
            this.chkBaja.TabIndex = 99;
            this.chkBaja.Text = "De Baja    ";
            this.chkBaja.UseVisualStyleBackColor = true;
            this.chkBaja.Click += new System.EventHandler(this.chkBaja_Click);
            // 
            // pnlDireccion
            // 
            this.pnlDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDireccion.Controls.Add(this.label10);
            this.pnlDireccion.Controls.Add(this.cboDistrito);
            this.pnlDireccion.Controls.Add(this.cboDepartamento);
            this.pnlDireccion.Controls.Add(this.cboProvincia);
            this.pnlDireccion.Controls.Add(this.label21);
            this.pnlDireccion.Controls.Add(this.txtWeb);
            this.pnlDireccion.Controls.Add(this.label22);
            this.pnlDireccion.Controls.Add(this.txtCorreo);
            this.pnlDireccion.Controls.Add(this.label23);
            this.pnlDireccion.Controls.Add(this.txtFax);
            this.pnlDireccion.Controls.Add(this.label26);
            this.pnlDireccion.Controls.Add(this.txtTelefonos);
            this.pnlDireccion.Controls.Add(this.txtDireccion);
            this.pnlDireccion.Location = new System.Drawing.Point(5, 182);
            this.pnlDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDireccion.Name = "pnlDireccion";
            this.pnlDireccion.Size = new System.Drawing.Size(601, 131);
            this.pnlDireccion.TabIndex = 122;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(391, 27);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(199, 21);
            this.cboDistrito.TabIndex = 90;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(11, 27);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(171, 21);
            this.cboDepartamento.TabIndex = 88;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(188, 27);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(199, 21);
            this.cboProvincia.TabIndex = 89;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(307, 102);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 13);
            this.label21.TabIndex = 125;
            this.label21.Text = "Página Web";
            // 
            // txtWeb
            // 
            this.txtWeb.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtWeb.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtWeb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeb.Location = new System.Drawing.Point(373, 99);
            this.txtWeb.Margin = new System.Windows.Forms.Padding(2);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(218, 21);
            this.txtWeb.TabIndex = 95;
            this.txtWeb.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtWeb.TextoVacio = "<Descripcion>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 102);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 123;
            this.label22.Text = "E-mail";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCorreo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCorreo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(80, 99);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(216, 21);
            this.txtCorreo.TabIndex = 94;
            this.txtCorreo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCorreo.TextoVacio = "<Descripcion>";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(489, 79);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(25, 13);
            this.label23.TabIndex = 121;
            this.label23.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFax.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(519, 76);
            this.txtFax.Margin = new System.Windows.Forms.Padding(2);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(72, 21);
            this.txtFax.TabIndex = 93;
            this.txtFax.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFax.TextoVacio = "<Descripcion>";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(7, 79);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 115;
            this.label26.Text = "Telf./Cel.";
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTelefonos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTelefonos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonos.Location = new System.Drawing.Point(80, 76);
            this.txtTelefonos.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(405, 21);
            this.txtTelefonos.TabIndex = 92;
            this.txtTelefonos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtTelefonos.TextoVacio = "<Descripcion>";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(11, 52);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(579, 21);
            this.txtDireccion.TabIndex = 91;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "Ingrese Dirección";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.label14);
            this.pnlDatos.Controls.Add(this.cboTipoDocumento);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.txtIdOperador);
            this.pnlDatos.Controls.Add(this.btSunat);
            this.pnlDatos.Controls.Add(this.lblComercial);
            this.pnlDatos.Controls.Add(this.txtComercial);
            this.pnlDatos.Controls.Add(this.lblNombres);
            this.pnlDatos.Controls.Add(this.txtNombres);
            this.pnlDatos.Controls.Add(this.lblApeMat);
            this.pnlDatos.Controls.Add(this.txtApeMat);
            this.pnlDatos.Controls.Add(this.lblApePat);
            this.pnlDatos.Controls.Add(this.txtApePat);
            this.pnlDatos.Controls.Add(this.lblRazon);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.txtRuc);
            this.pnlDatos.Controls.Add(this.txtRazon);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.cboTipoPersona);
            this.pnlDatos.Location = new System.Drawing.Point(5, 5);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(601, 173);
            this.pnlDatos.TabIndex = 120;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(256, 56);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 273;
            this.label14.Text = "Documento Iden.";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.DropDownWidth = 115;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(347, 52);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(122, 21);
            this.cboTipoDocumento.TabIndex = 272;
            this.cboTipoDocumento.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDocumento_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 271;
            this.label1.Text = "Código";
            // 
            // txtIdOperador
            // 
            this.txtIdOperador.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdOperador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdOperador.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdOperador.Enabled = false;
            this.txtIdOperador.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdOperador.Location = new System.Drawing.Point(103, 31);
            this.txtIdOperador.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdOperador.Name = "txtIdOperador";
            this.txtIdOperador.Size = new System.Drawing.Size(130, 20);
            this.txtIdOperador.TabIndex = 260;
            this.txtIdOperador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdOperador.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdOperador.TextoVacio = "<Descripcion>";
            // 
            // btSunat
            // 
            this.btSunat.BackColor = System.Drawing.Color.Azure;
            this.btSunat.Enabled = false;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Image = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btSunat.Location = new System.Drawing.Point(187, 54);
            this.btSunat.Margin = new System.Windows.Forms.Padding(2);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(59, 18);
            this.btSunat.TabIndex = 50;
            this.btSunat.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btSunat.UseVisualStyleBackColor = false;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // lblComercial
            // 
            this.lblComercial.AutoSize = true;
            this.lblComercial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComercial.Location = new System.Drawing.Point(10, 100);
            this.lblComercial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComercial.Name = "lblComercial";
            this.lblComercial.Size = new System.Drawing.Size(93, 13);
            this.lblComercial.TabIndex = 115;
            this.lblComercial.Text = "Nombre Comercial";
            // 
            // txtComercial
            // 
            this.txtComercial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtComercial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtComercial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtComercial.Enabled = false;
            this.txtComercial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComercial.Location = new System.Drawing.Point(103, 97);
            this.txtComercial.Margin = new System.Windows.Forms.Padding(2);
            this.txtComercial.Name = "txtComercial";
            this.txtComercial.Size = new System.Drawing.Size(490, 20);
            this.txtComercial.TabIndex = 82;
            this.txtComercial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtComercial.TextoVacio = "<Descripcion>";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.Location = new System.Drawing.Point(10, 122);
            this.lblNombres.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(49, 13);
            this.lblNombres.TabIndex = 111;
            this.lblNombres.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombres.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombres.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(103, 119);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(199, 20);
            this.txtNombres.TabIndex = 85;
            this.txtNombres.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloLetras;
            this.txtNombres.TextoVacio = "<Descripcion>";
            // 
            // lblApeMat
            // 
            this.lblApeMat.AutoSize = true;
            this.lblApeMat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApeMat.Location = new System.Drawing.Point(307, 144);
            this.lblApeMat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApeMat.Name = "lblApeMat";
            this.lblApeMat.Size = new System.Drawing.Size(87, 13);
            this.lblApeMat.TabIndex = 109;
            this.lblApeMat.Text = "Apellido Materno";
            // 
            // txtApeMat
            // 
            this.txtApeMat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtApeMat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtApeMat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApeMat.Location = new System.Drawing.Point(394, 141);
            this.txtApeMat.Margin = new System.Windows.Forms.Padding(2);
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.Size = new System.Drawing.Size(199, 20);
            this.txtApeMat.TabIndex = 87;
            this.txtApeMat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloLetras;
            this.txtApeMat.TextoVacio = "<Descripcion>";
            // 
            // lblApePat
            // 
            this.lblApePat.AutoSize = true;
            this.lblApePat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApePat.Location = new System.Drawing.Point(10, 144);
            this.lblApePat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApePat.Name = "lblApePat";
            this.lblApePat.Size = new System.Drawing.Size(85, 13);
            this.lblApePat.TabIndex = 107;
            this.lblApePat.Text = "Apellido Paterno";
            // 
            // txtApePat
            // 
            this.txtApePat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtApePat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtApePat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApePat.Location = new System.Drawing.Point(103, 141);
            this.txtApePat.Margin = new System.Windows.Forms.Padding(2);
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.Size = new System.Drawing.Size(199, 20);
            this.txtApePat.TabIndex = 86;
            this.txtApePat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloLetras;
            this.txtApePat.TextoVacio = "<Descripcion>";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.Location = new System.Drawing.Point(10, 78);
            this.lblRazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(67, 13);
            this.lblRazon.TabIndex = 105;
            this.lblRazon.Text = "Razón Social";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "RUC";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(103, 53);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(80, 20);
            this.txtRuc.TabIndex = 40;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // txtRazon
            // 
            this.txtRazon.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRazon.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazon.Enabled = false;
            this.txtRazon.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazon.Location = new System.Drawing.Point(103, 75);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(490, 20);
            this.txtRazon.TabIndex = 81;
            this.txtRazon.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazon.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(256, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Tipo Persona";
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(347, 29);
            this.cboTipoPersona.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(122, 21);
            this.cboTipoPersona.TabIndex = 30;
            this.cboTipoPersona.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPersona_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label7);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(610, 83);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 133);
            this.pnlAuditoria.TabIndex = 121;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(8, 100);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(122, 96);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(122, 53);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtRegistro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(122, 32);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(122, 75);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(599, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 18);
            this.label6.TabIndex = 429;
            this.label6.Text = "Condición";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 18);
            this.label7.TabIndex = 429;
            this.label7.Text = "Autoria";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(599, 18);
            this.label10.TabIndex = 429;
            this.label10.Text = "Ubicación";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOperadorLogistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 316);
            this.Controls.Add(this.pnlCondicion);
            this.Controls.Add(this.pnlDireccion);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmOperadorLogistico";
            this.Text = "Operador Logistico";
            this.Activated += new System.EventHandler(this.frmOperadorLogistico_Activated);
            this.Load += new System.EventHandler(this.frmOperadorLogistico_Load);
            this.pnlCondicion.ResumeLayout(false);
            this.pnlCondicion.PerformLayout();
            this.pnlDireccion.ResumeLayout(false);
            this.pnlDireccion.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCondicion;
        private ControlesWinForm.SuperTextBox txtFecBaja;
        private System.Windows.Forms.CheckBox chkBaja;
        private System.Windows.Forms.Panel pnlDireccion;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label21;
        private ControlesWinForm.SuperTextBox txtWeb;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtCorreo;
        private System.Windows.Forms.Label label23;
        private ControlesWinForm.SuperTextBox txtFax;
        private System.Windows.Forms.Label label26;
        private ControlesWinForm.SuperTextBox txtTelefonos;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtIdOperador;
        private System.Windows.Forms.Button btSunat;
        private System.Windows.Forms.Label lblComercial;
        private ControlesWinForm.SuperTextBox txtComercial;
        private System.Windows.Forms.Label lblNombres;
        private ControlesWinForm.SuperTextBox txtNombres;
        private System.Windows.Forms.Label lblApeMat;
        private ControlesWinForm.SuperTextBox txtApeMat;
        private System.Windows.Forms.Label lblApePat;
        private ControlesWinForm.SuperTextBox txtApePat;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoPersona;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}