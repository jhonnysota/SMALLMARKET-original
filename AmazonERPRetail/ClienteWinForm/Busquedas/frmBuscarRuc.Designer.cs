namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarRuc
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbPat = new System.Windows.Forms.RadioButton();
            this.rbNom = new System.Windows.Forms.RadioButton();
            this.rbMat = new System.Windows.Forms.RadioButton();
            this.chkListDatos = new System.Windows.Forms.CheckedListBox();
            this.txtNombres = new ControlesWinForm.SuperTextBox();
            this.txtApeMat = new ControlesWinForm.SuperTextBox();
            this.txtApePat = new ControlesWinForm.SuperTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtCapcha = new ControlesWinForm.SuperTextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pbCapcha = new System.Windows.Forms.PictureBox();
            this.lblMarquee = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDistrito = new ControlesWinForm.SuperTextBox();
            this.txtProvincia = new ControlesWinForm.SuperTextBox();
            this.txtDepartamento = new ControlesWinForm.SuperTextBox();
            this.txtFecBaja = new ControlesWinForm.SuperTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btSeparar = new System.Windows.Forms.Button();
            this.txtProfesion = new ControlesWinForm.SuperTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTelefonos = new ControlesWinForm.SuperTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cboEmisionElectronica = new System.Windows.Forms.ComboBox();
            this.cboPadrones = new System.Windows.Forms.ComboBox();
            this.txtComprobantesElec = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboComprobantes = new System.Windows.Forms.ComboBox();
            this.txtActividad = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboActividad = new System.Windows.Forms.ComboBox();
            this.txtPle = new ControlesWinForm.SuperTextBox();
            this.txtEmisorElec = new ControlesWinForm.SuperTextBox();
            this.txtSistema = new ControlesWinForm.SuperTextBox();
            this.txtEmision = new ControlesWinForm.SuperTextBox();
            this.txtInicio = new ControlesWinForm.SuperTextBox();
            this.txtEmisElec = new ControlesWinForm.SuperTextBox();
            this.txtEstado = new ControlesWinForm.SuperTextBox();
            this.txtCondicion = new ControlesWinForm.SuperTextBox();
            this.txtInscripcion = new ControlesWinForm.SuperTextBox();
            this.txtTipo = new ControlesWinForm.SuperTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreComercial = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazon = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDni = new ControlesWinForm.SuperTextBox();
            this.txtRus = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btProveedores = new System.Windows.Forms.Button();
            this.btClientes = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.chkListDatos);
            this.panel2.Controls.Add(this.txtNombres);
            this.panel2.Controls.Add(this.txtApeMat);
            this.panel2.Controls.Add(this.txtApePat);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(1016, 149);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 424);
            this.panel2.TabIndex = 122;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbPat);
            this.panel3.Controls.Add(this.rbNom);
            this.panel3.Controls.Add(this.rbMat);
            this.panel3.Location = new System.Drawing.Point(6, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 82);
            this.panel3.TabIndex = 122;
            // 
            // rbPat
            // 
            this.rbPat.AutoSize = true;
            this.rbPat.Checked = true;
            this.rbPat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPat.Location = new System.Drawing.Point(12, 11);
            this.rbPat.Name = "rbPat";
            this.rbPat.Size = new System.Drawing.Size(113, 17);
            this.rbPat.TabIndex = 106;
            this.rbPat.TabStop = true;
            this.rbPat.Text = "Apellidos Paternos";
            this.rbPat.UseVisualStyleBackColor = true;
            this.rbPat.CheckedChanged += new System.EventHandler(this.rbPat_CheckedChanged);
            // 
            // rbNom
            // 
            this.rbNom.AutoSize = true;
            this.rbNom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNom.Location = new System.Drawing.Point(12, 57);
            this.rbNom.Name = "rbNom";
            this.rbNom.Size = new System.Drawing.Size(67, 17);
            this.rbNom.TabIndex = 108;
            this.rbNom.Text = "Nombres";
            this.rbNom.UseVisualStyleBackColor = true;
            this.rbNom.CheckedChanged += new System.EventHandler(this.rbNom_CheckedChanged);
            // 
            // rbMat
            // 
            this.rbMat.AutoSize = true;
            this.rbMat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMat.Location = new System.Drawing.Point(12, 34);
            this.rbMat.Name = "rbMat";
            this.rbMat.Size = new System.Drawing.Size(115, 17);
            this.rbMat.TabIndex = 107;
            this.rbMat.Text = "Apellidos Maternos";
            this.rbMat.UseVisualStyleBackColor = true;
            this.rbMat.CheckedChanged += new System.EventHandler(this.rbMat_CheckedChanged);
            // 
            // chkListDatos
            // 
            this.chkListDatos.CheckOnClick = true;
            this.chkListDatos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListDatos.FormattingEnabled = true;
            this.chkListDatos.Location = new System.Drawing.Point(6, 123);
            this.chkListDatos.Name = "chkListDatos";
            this.chkListDatos.Size = new System.Drawing.Size(259, 196);
            this.chkListDatos.TabIndex = 105;
            this.chkListDatos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListDatos_ItemCheck);
            // 
            // txtNombres
            // 
            this.txtNombres.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtNombres.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombres.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombres.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(4, 391);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombres.MaxLength = 11;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(263, 22);
            this.txtNombres.TabIndex = 103;
            this.txtNombres.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombres.TextoVacio = "Nombres";
            // 
            // txtApeMat
            // 
            this.txtApeMat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtApeMat.BackColor = System.Drawing.SystemColors.Window;
            this.txtApeMat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtApeMat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApeMat.Location = new System.Drawing.Point(4, 364);
            this.txtApeMat.Margin = new System.Windows.Forms.Padding(2);
            this.txtApeMat.MaxLength = 11;
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.ReadOnly = true;
            this.txtApeMat.Size = new System.Drawing.Size(263, 22);
            this.txtApeMat.TabIndex = 102;
            this.txtApeMat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtApeMat.TextoVacio = "Apellidos Maternos";
            // 
            // txtApePat
            // 
            this.txtApePat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtApePat.BackColor = System.Drawing.SystemColors.Window;
            this.txtApePat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtApePat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApePat.Location = new System.Drawing.Point(4, 335);
            this.txtApePat.Margin = new System.Windows.Forms.Padding(2);
            this.txtApePat.MaxLength = 11;
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.ReadOnly = true;
            this.txtApePat.Size = new System.Drawing.Size(263, 22);
            this.txtApePat.TabIndex = 101;
            this.txtApePat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtApePat.TextoVacio = "Apellidos Paternos";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(6, 6);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(259, 22);
            this.label25.TabIndex = 97;
            this.label25.Text = "Descomposición de Apellidos y Nombres";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.SUNAT2;
            this.pictureBox1.InitialImage = global::ClienteWinForm.Properties.Resources.SUNAT2;
            this.pictureBox1.Location = new System.Drawing.Point(856, 557);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 122;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.txtCapcha);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.pbCapcha);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 107);
            this.panel1.TabIndex = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(247, 70);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(98, 14);
            this.linkLabel1.TabIndex = 121;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refrescar Código";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(985, 22);
            this.label8.TabIndex = 97;
            this.label8.Text = "Criterios de Busqueda";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número de RUC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 14);
            this.label7.TabIndex = 119;
            this.label7.Text = "Ingrese el código que se muestra en la imagen";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(97, 41);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(116, 22);
            this.txtRuc.TabIndex = 20;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Leave += new System.EventHandler(this.txtRuc_Leave);
            // 
            // txtCapcha
            // 
            this.txtCapcha.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCapcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCapcha.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCapcha.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapcha.Location = new System.Drawing.Point(710, 41);
            this.txtCapcha.Margin = new System.Windows.Forms.Padding(2);
            this.txtCapcha.MaxLength = 11;
            this.txtCapcha.Name = "txtCapcha";
            this.txtCapcha.Size = new System.Drawing.Size(80, 24);
            this.txtCapcha.TabIndex = 30;
            this.txtCapcha.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCapcha.TextoVacio = "<Descripcion>";
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.consulta_web;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(833, 41);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(128, 38);
            this.btBuscar.TabIndex = 40;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // pbCapcha
            // 
            this.pbCapcha.Location = new System.Drawing.Point(534, 41);
            this.pbCapcha.Margin = new System.Windows.Forms.Padding(2);
            this.pbCapcha.Name = "pbCapcha";
            this.pbCapcha.Size = new System.Drawing.Size(152, 53);
            this.pbCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCapcha.TabIndex = 118;
            this.pbCapcha.TabStop = false;
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarquee.Location = new System.Drawing.Point(58, 124);
            this.lblMarquee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(0, 14);
            this.lblMarquee.TabIndex = 116;
            this.lblMarquee.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(10, 115);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(32, 32);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 115;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::ClienteWinForm.Properties.Resources.cancel;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(506, 563);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(133, 24);
            this.btCancelar.TabIndex = 114;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Visible = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(366, 563);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(133, 24);
            this.btAceptar.TabIndex = 113;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Visible = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label28);
            this.pnlAuditoria.Controls.Add(this.txtDistrito);
            this.pnlAuditoria.Controls.Add(this.txtProvincia);
            this.pnlAuditoria.Controls.Add(this.txtDepartamento);
            this.pnlAuditoria.Controls.Add(this.txtFecBaja);
            this.pnlAuditoria.Controls.Add(this.label27);
            this.pnlAuditoria.Controls.Add(this.btSeparar);
            this.pnlAuditoria.Controls.Add(this.txtProfesion);
            this.pnlAuditoria.Controls.Add(this.label24);
            this.pnlAuditoria.Controls.Add(this.txtTelefonos);
            this.pnlAuditoria.Controls.Add(this.label23);
            this.pnlAuditoria.Controls.Add(this.cboEmisionElectronica);
            this.pnlAuditoria.Controls.Add(this.cboPadrones);
            this.pnlAuditoria.Controls.Add(this.txtComprobantesElec);
            this.pnlAuditoria.Controls.Add(this.label9);
            this.pnlAuditoria.Controls.Add(this.cboComprobantes);
            this.pnlAuditoria.Controls.Add(this.txtActividad);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.cboActividad);
            this.pnlAuditoria.Controls.Add(this.txtPle);
            this.pnlAuditoria.Controls.Add(this.txtEmisorElec);
            this.pnlAuditoria.Controls.Add(this.txtSistema);
            this.pnlAuditoria.Controls.Add(this.txtEmision);
            this.pnlAuditoria.Controls.Add(this.txtInicio);
            this.pnlAuditoria.Controls.Add(this.txtEmisElec);
            this.pnlAuditoria.Controls.Add(this.txtEstado);
            this.pnlAuditoria.Controls.Add(this.txtCondicion);
            this.pnlAuditoria.Controls.Add(this.txtInscripcion);
            this.pnlAuditoria.Controls.Add(this.txtTipo);
            this.pnlAuditoria.Controls.Add(this.label21);
            this.pnlAuditoria.Controls.Add(this.label20);
            this.pnlAuditoria.Controls.Add(this.label19);
            this.pnlAuditoria.Controls.Add(this.label18);
            this.pnlAuditoria.Controls.Add(this.label17);
            this.pnlAuditoria.Controls.Add(this.label16);
            this.pnlAuditoria.Controls.Add(this.label15);
            this.pnlAuditoria.Controls.Add(this.label14);
            this.pnlAuditoria.Controls.Add(this.label13);
            this.pnlAuditoria.Controls.Add(this.label12);
            this.pnlAuditoria.Controls.Add(this.label11);
            this.pnlAuditoria.Controls.Add(this.label10);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.lblEstado);
            this.pnlAuditoria.Controls.Add(this.label6);
            this.pnlAuditoria.Controls.Add(this.label5);
            this.pnlAuditoria.Controls.Add(this.txtNombreComercial);
            this.pnlAuditoria.Controls.Add(this.txtDireccion);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtRazon);
            this.pnlAuditoria.Controls.Add(this.label22);
            this.pnlAuditoria.Controls.Add(this.txtDni);
            this.pnlAuditoria.Controls.Add(this.txtRus);
            this.pnlAuditoria.Controls.Add(this.label26);
            this.pnlAuditoria.Location = new System.Drawing.Point(8, 149);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(1000, 405);
            this.pnlAuditoria.TabIndex = 50;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(18, 172);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(203, 13);
            this.label28.TabIndex = 143;
            this.label28.Text = "Departamento - Provincia - Distrito";
            // 
            // txtDistrito
            // 
            this.txtDistrito.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDistrito.BackColor = System.Drawing.SystemColors.Window;
            this.txtDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDistrito.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistrito.Location = new System.Drawing.Point(749, 167);
            this.txtDistrito.Margin = new System.Windows.Forms.Padding(2);
            this.txtDistrito.MaxLength = 150;
            this.txtDistrito.Name = "txtDistrito";
            this.txtDistrito.Size = new System.Drawing.Size(237, 20);
            this.txtDistrito.TabIndex = 142;
            this.txtDistrito.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDistrito.TextoVacio = "Distrito";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtProvincia.BackColor = System.Drawing.SystemColors.Window;
            this.txtProvincia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProvincia.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvincia.Location = new System.Drawing.Point(511, 167);
            this.txtProvincia.Margin = new System.Windows.Forms.Padding(2);
            this.txtProvincia.MaxLength = 150;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(236, 20);
            this.txtProvincia.TabIndex = 141;
            this.txtProvincia.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtProvincia.TextoVacio = "Provincia";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDepartamento.BackColor = System.Drawing.SystemColors.Window;
            this.txtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepartamento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartamento.Location = new System.Drawing.Point(272, 167);
            this.txtDepartamento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepartamento.MaxLength = 150;
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(237, 20);
            this.txtDepartamento.TabIndex = 140;
            this.txtDepartamento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDepartamento.TextoVacio = "Departamento";
            // 
            // txtFecBaja
            // 
            this.txtFecBaja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecBaja.BackColor = System.Drawing.SystemColors.Window;
            this.txtFecBaja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecBaja.Location = new System.Drawing.Point(710, 101);
            this.txtFecBaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecBaja.MaxLength = 11;
            this.txtFecBaja.Name = "txtFecBaja";
            this.txtFecBaja.ReadOnly = true;
            this.txtFecBaja.Size = new System.Drawing.Size(276, 20);
            this.txtFecBaja.TabIndex = 139;
            this.txtFecBaja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecBaja.TextoVacio = "<Descripcion>";
            this.txtFecBaja.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(524, 106);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 13);
            this.label27.TabIndex = 138;
            this.label27.Text = "Fecha Baja";
            this.label27.Visible = false;
            // 
            // btSeparar
            // 
            this.btSeparar.BackColor = System.Drawing.Color.White;
            this.btSeparar.Enabled = false;
            this.btSeparar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btSeparar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btSeparar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btSeparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSeparar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSeparar.Location = new System.Drawing.Point(239, 13);
            this.btSeparar.Margin = new System.Windows.Forms.Padding(2);
            this.btSeparar.Name = "btSeparar";
            this.btSeparar.Size = new System.Drawing.Size(31, 20);
            this.btSeparar.TabIndex = 123;
            this.btSeparar.Text = ">>";
            this.btSeparar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSeparar.UseVisualStyleBackColor = false;
            this.btSeparar.Click += new System.EventHandler(this.btSeparar_Click);
            // 
            // txtProfesion
            // 
            this.txtProfesion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtProfesion.BackColor = System.Drawing.SystemColors.Window;
            this.txtProfesion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtProfesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfesion.Location = new System.Drawing.Point(710, 211);
            this.txtProfesion.Margin = new System.Windows.Forms.Padding(2);
            this.txtProfesion.MaxLength = 11;
            this.txtProfesion.Name = "txtProfesion";
            this.txtProfesion.ReadOnly = true;
            this.txtProfesion.Size = new System.Drawing.Size(276, 20);
            this.txtProfesion.TabIndex = 135;
            this.txtProfesion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtProfesion.TextoVacio = "<Descripcion>";
            this.txtProfesion.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(524, 216);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(108, 13);
            this.label24.TabIndex = 134;
            this.label24.Text = "Profesión u Oficio";
            this.label24.Visible = false;
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTelefonos.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelefonos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonos.Location = new System.Drawing.Point(710, 347);
            this.txtTelefonos.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonos.MaxLength = 11;
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.ReadOnly = true;
            this.txtTelefonos.Size = new System.Drawing.Size(276, 20);
            this.txtTelefonos.TabIndex = 133;
            this.txtTelefonos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTelefonos.TextoVacio = "<Descripcion>";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(524, 352);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 132;
            this.label23.Text = "Teléfonos";
            // 
            // cboEmisionElectronica
            // 
            this.cboEmisionElectronica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmisionElectronica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmisionElectronica.FormattingEnabled = true;
            this.cboEmisionElectronica.Location = new System.Drawing.Point(271, 280);
            this.cboEmisionElectronica.Margin = new System.Windows.Forms.Padding(2);
            this.cboEmisionElectronica.Name = "cboEmisionElectronica";
            this.cboEmisionElectronica.Size = new System.Drawing.Size(468, 21);
            this.cboEmisionElectronica.TabIndex = 129;
            this.cboEmisionElectronica.Visible = false;
            // 
            // cboPadrones
            // 
            this.cboPadrones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPadrones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPadrones.FormattingEnabled = true;
            this.cboPadrones.Location = new System.Drawing.Point(272, 369);
            this.cboPadrones.Margin = new System.Windows.Forms.Padding(2);
            this.cboPadrones.Name = "cboPadrones";
            this.cboPadrones.Size = new System.Drawing.Size(714, 21);
            this.cboPadrones.TabIndex = 128;
            // 
            // txtComprobantesElec
            // 
            this.txtComprobantesElec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtComprobantesElec.BackColor = System.Drawing.SystemColors.Window;
            this.txtComprobantesElec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtComprobantesElec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComprobantesElec.Location = new System.Drawing.Point(272, 325);
            this.txtComprobantesElec.Margin = new System.Windows.Forms.Padding(2);
            this.txtComprobantesElec.MaxLength = 11;
            this.txtComprobantesElec.Name = "txtComprobantesElec";
            this.txtComprobantesElec.ReadOnly = true;
            this.txtComprobantesElec.Size = new System.Drawing.Size(714, 20);
            this.txtComprobantesElec.TabIndex = 127;
            this.txtComprobantesElec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtComprobantesElec.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 330);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 13);
            this.label9.TabIndex = 126;
            this.label9.Text = "Comprobantes Electrónicos";
            // 
            // cboComprobantes
            // 
            this.cboComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboComprobantes.FormattingEnabled = true;
            this.cboComprobantes.Location = new System.Drawing.Point(272, 257);
            this.cboComprobantes.Margin = new System.Windows.Forms.Padding(2);
            this.cboComprobantes.Name = "cboComprobantes";
            this.cboComprobantes.Size = new System.Drawing.Size(214, 21);
            this.cboComprobantes.TabIndex = 125;
            // 
            // txtActividad
            // 
            this.txtActividad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtActividad.BackColor = System.Drawing.SystemColors.Window;
            this.txtActividad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActividad.Location = new System.Drawing.Point(710, 189);
            this.txtActividad.Margin = new System.Windows.Forms.Padding(2);
            this.txtActividad.MaxLength = 11;
            this.txtActividad.Name = "txtActividad";
            this.txtActividad.ReadOnly = true;
            this.txtActividad.Size = new System.Drawing.Size(276, 20);
            this.txtActividad.TabIndex = 128;
            this.txtActividad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtActividad.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(524, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Actividad de Comercio Exterior";
            // 
            // cboActividad
            // 
            this.cboActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboActividad.FormattingEnabled = true;
            this.cboActividad.Location = new System.Drawing.Point(272, 234);
            this.cboActividad.Margin = new System.Windows.Forms.Padding(2);
            this.cboActividad.Name = "cboActividad";
            this.cboActividad.Size = new System.Drawing.Size(414, 21);
            this.cboActividad.TabIndex = 130;
            // 
            // txtPle
            // 
            this.txtPle.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPle.BackColor = System.Drawing.SystemColors.Window;
            this.txtPle.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPle.Location = new System.Drawing.Point(272, 347);
            this.txtPle.Margin = new System.Windows.Forms.Padding(2);
            this.txtPle.MaxLength = 11;
            this.txtPle.Name = "txtPle";
            this.txtPle.ReadOnly = true;
            this.txtPle.Size = new System.Drawing.Size(121, 20);
            this.txtPle.TabIndex = 120;
            this.txtPle.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPle.TextoVacio = "<Descripcion>";
            // 
            // txtEmisorElec
            // 
            this.txtEmisorElec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmisorElec.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmisorElec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmisorElec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmisorElec.Location = new System.Drawing.Point(272, 303);
            this.txtEmisorElec.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmisorElec.MaxLength = 11;
            this.txtEmisorElec.Name = "txtEmisorElec";
            this.txtEmisorElec.ReadOnly = true;
            this.txtEmisorElec.Size = new System.Drawing.Size(121, 20);
            this.txtEmisorElec.TabIndex = 119;
            this.txtEmisorElec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmisorElec.TextoVacio = "<Descripcion>";
            // 
            // txtSistema
            // 
            this.txtSistema.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSistema.BackColor = System.Drawing.SystemColors.Window;
            this.txtSistema.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSistema.Location = new System.Drawing.Point(272, 211);
            this.txtSistema.Margin = new System.Windows.Forms.Padding(2);
            this.txtSistema.MaxLength = 11;
            this.txtSistema.Name = "txtSistema";
            this.txtSistema.ReadOnly = true;
            this.txtSistema.Size = new System.Drawing.Size(213, 20);
            this.txtSistema.TabIndex = 129;
            this.txtSistema.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSistema.TextoVacio = "<Descripcion>";
            // 
            // txtEmision
            // 
            this.txtEmision.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmision.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmision.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmision.Location = new System.Drawing.Point(272, 189);
            this.txtEmision.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmision.MaxLength = 11;
            this.txtEmision.Name = "txtEmision";
            this.txtEmision.ReadOnly = true;
            this.txtEmision.Size = new System.Drawing.Size(213, 20);
            this.txtEmision.TabIndex = 127;
            this.txtEmision.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmision.TextoVacio = "<Descripcion>";
            // 
            // txtInicio
            // 
            this.txtInicio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInicio.BackColor = System.Drawing.SystemColors.Window;
            this.txtInicio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Location = new System.Drawing.Point(710, 79);
            this.txtInicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtInicio.MaxLength = 11;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.ReadOnly = true;
            this.txtInicio.Size = new System.Drawing.Size(276, 20);
            this.txtInicio.TabIndex = 123;
            this.txtInicio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtInicio.TextoVacio = "<Descripcion>";
            // 
            // txtEmisElec
            // 
            this.txtEmisElec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmisElec.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmisElec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmisElec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmisElec.Location = new System.Drawing.Point(272, 280);
            this.txtEmisElec.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmisElec.MaxLength = 11;
            this.txtEmisElec.Name = "txtEmisElec";
            this.txtEmisElec.ReadOnly = true;
            this.txtEmisElec.Size = new System.Drawing.Size(414, 20);
            this.txtEmisElec.TabIndex = 115;
            this.txtEmisElec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmisElec.TextoVacio = "<Descripcion>";
            // 
            // txtEstado
            // 
            this.txtEstado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEstado.BackColor = System.Drawing.SystemColors.Window;
            this.txtEstado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(272, 101);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEstado.MaxLength = 11;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(213, 20);
            this.txtEstado.TabIndex = 124;
            this.txtEstado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEstado.TextoVacio = "<Descripcion>";
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // txtCondicion
            // 
            this.txtCondicion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCondicion.BackColor = System.Drawing.SystemColors.Window;
            this.txtCondicion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicion.Location = new System.Drawing.Point(272, 123);
            this.txtCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.txtCondicion.MaxLength = 11;
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.ReadOnly = true;
            this.txtCondicion.Size = new System.Drawing.Size(213, 20);
            this.txtCondicion.TabIndex = 125;
            this.txtCondicion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCondicion.TextoVacio = "<Descripcion>";
            this.txtCondicion.TextChanged += new System.EventHandler(this.txtCondicion_TextChanged);
            // 
            // txtInscripcion
            // 
            this.txtInscripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInscripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txtInscripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInscripcion.Location = new System.Drawing.Point(272, 79);
            this.txtInscripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtInscripcion.MaxLength = 11;
            this.txtInscripcion.Name = "txtInscripcion";
            this.txtInscripcion.ReadOnly = true;
            this.txtInscripcion.Size = new System.Drawing.Size(121, 20);
            this.txtInscripcion.TabIndex = 122;
            this.txtInscripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtInscripcion.TextoVacio = "<Descripcion>";
            // 
            // txtTipo
            // 
            this.txtTipo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipo.BackColor = System.Drawing.SystemColors.Window;
            this.txtTipo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(272, 35);
            this.txtTipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipo.MaxLength = 11;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(232, 20);
            this.txtTipo.TabIndex = 120;
            this.txtTipo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTipo.TextoVacio = "<Descripcion>";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(18, 238);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(161, 13);
            this.label21.TabIndex = 110;
            this.label21.Text = "Actividad(es) Económica(s)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(18, 216);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 13);
            this.label20.TabIndex = 109;
            this.label20.Text = "Sistema de Contabilidad";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 285);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(184, 13);
            this.label19.TabIndex = 108;
            this.label19.Text = "Sistema de Emision Electronica";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 308);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 13);
            this.label18.TabIndex = 107;
            this.label18.Text = "Emisor electrónico desde";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(18, 352);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 13);
            this.label17.TabIndex = 106;
            this.label17.Text = "Afiliado al PLE desde";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 373);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 105;
            this.label16.Text = "Padrones";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 194);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(212, 13);
            this.label15.TabIndex = 104;
            this.label15.Text = "Sistema de Emisión de Comprobante";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(524, 84);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 13);
            this.label14.TabIndex = 103;
            this.label14.Text = "Fecha de Inicio de Actividades";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 128);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 13);
            this.label13.TabIndex = 102;
            this.label13.Text = "Condición del Contribuyente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 106);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 13);
            this.label12.TabIndex = 101;
            this.label12.Text = "Estado del Contribuyente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "Fecha de Inscripción";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 40);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Tipo Contribuyente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razón Social";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(213, 214);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 17);
            this.lblEstado.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Comprobantes de Pago c/aut. de impresión (F. 806 u 816)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dirección del Domicilio Fiscal";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreComercial.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombreComercial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreComercial.Location = new System.Drawing.Point(272, 57);
            this.txtNombreComercial.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreComercial.MaxLength = 11;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.ReadOnly = true;
            this.txtNombreComercial.Size = new System.Drawing.Size(714, 20);
            this.txtNombreComercial.TabIndex = 121;
            this.txtNombreComercial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreComercial.TextoVacio = "<Descripcion>";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(272, 145);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.MaxLength = 11;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(714, 20);
            this.txtDireccion.TabIndex = 126;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre Comercial";
            // 
            // txtRazon
            // 
            this.txtRazon.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazon.BackColor = System.Drawing.SystemColors.Window;
            this.txtRazon.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazon.Location = new System.Drawing.Point(272, 13);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazon.MaxLength = 11;
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.ReadOnly = true;
            this.txtRazon.Size = new System.Drawing.Size(714, 20);
            this.txtRazon.TabIndex = 100;
            this.txtRazon.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazon.TextoVacio = "<Descripcion>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(880, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 13);
            this.label22.TabIndex = 131;
            this.label22.Text = "DNI";
            this.label22.Visible = false;
            // 
            // txtDni
            // 
            this.txtDni.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDni.BackColor = System.Drawing.SystemColors.Window;
            this.txtDni.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(911, 13);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtDni.MaxLength = 11;
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(75, 20);
            this.txtDni.TabIndex = 110;
            this.txtDni.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDni.TextoVacio = "<Descripcion>";
            this.txtDni.Visible = false;
            // 
            // txtRus
            // 
            this.txtRus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRus.Location = new System.Drawing.Point(948, 57);
            this.txtRus.Name = "txtRus";
            this.txtRus.Size = new System.Drawing.Size(38, 20);
            this.txtRus.TabIndex = 137;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(824, 62);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(129, 13);
            this.label26.TabIndex = 136;
            this.label26.Text = "Afecto al Nuevo RUS";
            // 
            // btProveedores
            // 
            this.btProveedores.BackColor = System.Drawing.Color.White;
            this.btProveedores.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedores.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProveedores.Image = global::ClienteWinForm.Properties.Resources.ico_persona;
            this.btProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btProveedores.Location = new System.Drawing.Point(506, 563);
            this.btProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.btProveedores.Name = "btProveedores";
            this.btProveedores.Size = new System.Drawing.Size(133, 24);
            this.btProveedores.TabIndex = 124;
            this.btProveedores.Text = "Proveedores";
            this.btProveedores.UseVisualStyleBackColor = false;
            this.btProveedores.Visible = false;
            // 
            // btClientes
            // 
            this.btClientes.BackColor = System.Drawing.Color.White;
            this.btClientes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClientes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClientes.Image = global::ClienteWinForm.Properties.Resources.ico_persona;
            this.btClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClientes.Location = new System.Drawing.Point(366, 563);
            this.btClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btClientes.Name = "btClientes";
            this.btClientes.Size = new System.Drawing.Size(133, 24);
            this.btClientes.TabIndex = 123;
            this.btClientes.Text = "Clientes";
            this.btClientes.UseVisualStyleBackColor = false;
            this.btClientes.Visible = false;
            this.btClientes.Click += new System.EventHandler(this.btClientes_Click);
            // 
            // frmBuscarRuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 605);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMarquee);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.btProveedores);
            this.Controls.Add(this.btClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmBuscarRuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Sunat";
            this.Load += new System.EventHandler(this.frmBuscarRuc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuscarRuc_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        public ControlesWinForm.SuperTextBox txtRuc;
        public ControlesWinForm.SuperTextBox txtRazon;
        public ControlesWinForm.SuperTextBox txtNombreComercial;
        public ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        public ControlesWinForm.SuperTextBox txtCapcha;
        private System.Windows.Forms.PictureBox pbCapcha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        public ControlesWinForm.SuperTextBox txtEmisElec;
        public ControlesWinForm.SuperTextBox txtEstado;
        public ControlesWinForm.SuperTextBox txtCondicion;
        public ControlesWinForm.SuperTextBox txtInscripcion;
        public ControlesWinForm.SuperTextBox txtTipo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public ControlesWinForm.SuperTextBox txtPle;
        public ControlesWinForm.SuperTextBox txtEmisorElec;
        public ControlesWinForm.SuperTextBox txtSistema;
        public ControlesWinForm.SuperTextBox txtEmision;
        public ControlesWinForm.SuperTextBox txtInicio;
        private System.Windows.Forms.ComboBox cboComprobantes;
        public ControlesWinForm.SuperTextBox txtActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboActividad;
        public ControlesWinForm.SuperTextBox txtComprobantesElec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPadrones;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboEmisionElectronica;
        private System.Windows.Forms.Label label22;
        public ControlesWinForm.SuperTextBox txtDni;
        public ControlesWinForm.SuperTextBox txtTelefonos;
        private System.Windows.Forms.Label label23;
        public ControlesWinForm.SuperTextBox txtProfesion;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btSeparar;
        private System.Windows.Forms.Panel panel2;
        public ControlesWinForm.SuperTextBox txtNombres;
        public ControlesWinForm.SuperTextBox txtApeMat;
        public ControlesWinForm.SuperTextBox txtApePat;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckedListBox chkListDatos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbPat;
        private System.Windows.Forms.RadioButton rbNom;
        private System.Windows.Forms.RadioButton rbMat;
        private System.Windows.Forms.TextBox txtRus;
        private System.Windows.Forms.Label label26;
        public ControlesWinForm.SuperTextBox txtFecBaja;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        public ControlesWinForm.SuperTextBox txtDistrito;
        public ControlesWinForm.SuperTextBox txtProvincia;
        public ControlesWinForm.SuperTextBox txtDepartamento;
        private System.Windows.Forms.Button btProveedores;
        private System.Windows.Forms.Button btClientes;
    }
}