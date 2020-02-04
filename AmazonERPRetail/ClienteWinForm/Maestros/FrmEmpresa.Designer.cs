namespace ClienteWinForm.Maestros
{
    partial class FrmEmpresa
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
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label departamentoLabel;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioRegistroLabel1;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label sFaxLabel;
            System.Windows.Forms.Label sTelefonosLabel;
            System.Windows.Forms.Label sWebLabel;
            System.Windows.Forms.Label sNumDocRepresentanteLabel;
            System.Windows.Forms.Label rUCLabel1;
            System.Windows.Forms.Label sEmailFeLabel;
            System.Windows.Forms.Label sEmailLabel;
            System.Windows.Forms.Label idEmpresaLabel;
            System.Windows.Forms.Label nombreComercialLabel;
            System.Windows.Forms.Label razonSocialLabel;
            System.Windows.Forms.Label representanteLegalLabel;
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkVerDatos = new System.Windows.Forms.CheckBox();
            this.txtUsuarioSol = new ControlesWinForm.SuperTextBox();
            this.txtClaveSol = new ControlesWinForm.SuperTextBox();
            this.chkImagen = new System.Windows.Forms.CheckBox();
            this.btQuitar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEmpresas = new System.Windows.Forms.DataGridView();
            this.idImagenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEmpresaImagenes = new System.Windows.Forms.BindingSource(this.components);
            this.btConfigurarCorreo = new System.Windows.Forms.Button();
            this.pnDireccion = new System.Windows.Forms.Panel();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaMod = new System.Windows.Forms.TextBox();
            this.txtUsuarioReg = new System.Windows.Forms.TextBox();
            this.txtFechaReg = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.chkCalzado = new System.Windows.Forms.CheckBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtEmailOtros = new ControlesWinForm.SuperTextBox();
            this.txtEmailFact = new ControlesWinForm.SuperTextBox();
            this.txtEmail = new ControlesWinForm.SuperTextBox();
            this.txtWeb = new ControlesWinForm.SuperTextBox();
            this.txtNumDocRepre = new ControlesWinForm.SuperTextBox();
            this.txtRepresentante = new ControlesWinForm.SuperTextBox();
            this.txtNombreComercial = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.chkContribuyente = new System.Windows.Forms.CheckBox();
            this.txtIdEmpresa = new ControlesWinForm.SuperTextBox();
            this.chkRetencion = new System.Windows.Forms.CheckBox();
            this.btBuscarRuc = new System.Windows.Forms.Button();
            this.txtTelefonos = new ControlesWinForm.SuperTextBox();
            this.txtFax = new ControlesWinForm.SuperTextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            departamentoLabel = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel1 = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            sFaxLabel = new System.Windows.Forms.Label();
            sTelefonosLabel = new System.Windows.Forms.Label();
            sWebLabel = new System.Windows.Forms.Label();
            sNumDocRepresentanteLabel = new System.Windows.Forms.Label();
            rUCLabel1 = new System.Windows.Forms.Label();
            sEmailFeLabel = new System.Windows.Forms.Label();
            sEmailLabel = new System.Windows.Forms.Label();
            idEmpresaLabel = new System.Windows.Forms.Label();
            nombreComercialLabel = new System.Windows.Forms.Label();
            razonSocialLabel = new System.Windows.Forms.Label();
            representanteLegalLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpresaImagenes)).BeginInit();
            this.pnDireccion.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(11, 28);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(67, 13);
            label11.TabIndex = 4;
            label11.Text = "Usuario SOL";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(11, 49);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(58, 13);
            label16.TabIndex = 0;
            label16.Text = "Clave SOL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(504, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 13);
            label4.TabIndex = 107;
            label4.Text = "Distrito";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(236, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 105;
            label1.Text = "Provincia";
            // 
            // departamentoLabel
            // 
            departamentoLabel.AutoSize = true;
            departamentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            departamentoLabel.Location = new System.Drawing.Point(13, 28);
            departamentoLabel.Name = "departamentoLabel";
            departamentoLabel.Size = new System.Drawing.Size(74, 13);
            departamentoLabel.TabIndex = 103;
            departamentoLabel.Text = "Departamento";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(6, 92);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 20;
            fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(6, 50);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 16;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // usuarioRegistroLabel1
            // 
            usuarioRegistroLabel1.AutoSize = true;
            usuarioRegistroLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel1.Location = new System.Drawing.Point(6, 71);
            usuarioRegistroLabel1.Name = "usuarioRegistroLabel1";
            usuarioRegistroLabel1.Size = new System.Drawing.Size(106, 13);
            usuarioRegistroLabel1.TabIndex = 18;
            usuarioRegistroLabel1.Text = "Usuario Modificación";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(6, 29);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 14;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(20, 218);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 13);
            label5.TabIndex = 254;
            label5.Text = "Configurar Correo";
            // 
            // sFaxLabel
            // 
            sFaxLabel.AutoSize = true;
            sFaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sFaxLabel.Location = new System.Drawing.Point(356, 134);
            sFaxLabel.Name = "sFaxLabel";
            sFaxLabel.Size = new System.Drawing.Size(24, 13);
            sFaxLabel.TabIndex = 8;
            sFaxLabel.Text = "Fax";
            // 
            // sTelefonosLabel
            // 
            sTelefonosLabel.AutoSize = true;
            sTelefonosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sTelefonosLabel.Location = new System.Drawing.Point(20, 134);
            sTelefonosLabel.Name = "sTelefonosLabel";
            sTelefonosLabel.Size = new System.Drawing.Size(54, 13);
            sTelefonosLabel.TabIndex = 12;
            sTelefonosLabel.Text = "Teléfonos";
            // 
            // sWebLabel
            // 
            sWebLabel.AutoSize = true;
            sWebLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sWebLabel.Location = new System.Drawing.Point(20, 155);
            sWebLabel.Name = "sWebLabel";
            sWebLabel.Size = new System.Drawing.Size(66, 13);
            sWebLabel.TabIndex = 14;
            sWebLabel.Text = "Página Web";
            // 
            // sNumDocRepresentanteLabel
            // 
            sNumDocRepresentanteLabel.AutoSize = true;
            sNumDocRepresentanteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sNumDocRepresentanteLabel.Location = new System.Drawing.Point(20, 113);
            sNumDocRepresentanteLabel.Name = "sNumDocRepresentanteLabel";
            sNumDocRepresentanteLabel.Size = new System.Drawing.Size(71, 13);
            sNumDocRepresentanteLabel.TabIndex = 10;
            sNumDocRepresentanteLabel.Text = "N° Doc. Rep.";
            // 
            // rUCLabel1
            // 
            rUCLabel1.AutoSize = true;
            rUCLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rUCLabel1.Location = new System.Drawing.Point(151, 29);
            rUCLabel1.Name = "rUCLabel1";
            rUCLabel1.Size = new System.Drawing.Size(30, 13);
            rUCLabel1.TabIndex = 4;
            rUCLabel1.Text = "RUC";
            // 
            // sEmailFeLabel
            // 
            sEmailFeLabel.AutoSize = true;
            sEmailFeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sEmailFeLabel.Location = new System.Drawing.Point(20, 197);
            sEmailFeLabel.Name = "sEmailFeLabel";
            sEmailFeLabel.Size = new System.Drawing.Size(86, 13);
            sEmailFeLabel.TabIndex = 6;
            sEmailFeLabel.Text = "E-mail Fac. Elec.";
            // 
            // sEmailLabel
            // 
            sEmailLabel.AutoSize = true;
            sEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sEmailLabel.Location = new System.Drawing.Point(20, 176);
            sEmailLabel.Name = "sEmailLabel";
            sEmailLabel.Size = new System.Drawing.Size(35, 13);
            sEmailLabel.TabIndex = 4;
            sEmailLabel.Text = "E-mail";
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idEmpresaLabel.Location = new System.Drawing.Point(20, 29);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new System.Drawing.Size(40, 13);
            idEmpresaLabel.TabIndex = 0;
            idEmpresaLabel.Text = "Código";
            // 
            // nombreComercialLabel
            // 
            nombreComercialLabel.AutoSize = true;
            nombreComercialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreComercialLabel.Location = new System.Drawing.Point(20, 71);
            nombreComercialLabel.Name = "nombreComercialLabel";
            nombreComercialLabel.Size = new System.Drawing.Size(93, 13);
            nombreComercialLabel.TabIndex = 0;
            nombreComercialLabel.Text = "Nombre Comercial";
            // 
            // razonSocialLabel
            // 
            razonSocialLabel.AutoSize = true;
            razonSocialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            razonSocialLabel.Location = new System.Drawing.Point(20, 50);
            razonSocialLabel.Name = "razonSocialLabel";
            razonSocialLabel.Size = new System.Drawing.Size(70, 13);
            razonSocialLabel.TabIndex = 0;
            razonSocialLabel.Text = "Razón Social";
            // 
            // representanteLegalLabel
            // 
            representanteLegalLabel.AutoSize = true;
            representanteLegalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            representanteLegalLabel.Location = new System.Drawing.Point(20, 92);
            representanteLegalLabel.Name = "representanteLegalLabel";
            representanteLegalLabel.Size = new System.Drawing.Size(59, 13);
            representanteLegalLabel.TabIndex = 8;
            representanteLegalLabel.Text = "Rep. Legal";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chkVerDatos);
            this.panel2.Controls.Add(this.txtUsuarioSol);
            this.panel2.Controls.Add(this.txtClaveSol);
            this.panel2.Controls.Add(label11);
            this.panel2.Controls.Add(label16);
            this.panel2.Location = new System.Drawing.Point(502, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 74);
            this.panel2.TabIndex = 358;
            // 
            // chkVerDatos
            // 
            this.chkVerDatos.AutoSize = true;
            this.chkVerDatos.BackColor = System.Drawing.Color.Transparent;
            this.chkVerDatos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerDatos.Location = new System.Drawing.Point(206, 47);
            this.chkVerDatos.Name = "chkVerDatos";
            this.chkVerDatos.Size = new System.Drawing.Size(47, 17);
            this.chkVerDatos.TabIndex = 348;
            this.chkVerDatos.TabStop = false;
            this.chkVerDatos.Text = "V.D.";
            this.chkVerDatos.UseVisualStyleBackColor = false;
            this.chkVerDatos.Visible = false;
            this.chkVerDatos.CheckedChanged += new System.EventHandler(this.chkVerDatos_CheckedChanged);
            // 
            // txtUsuarioSol
            // 
            this.txtUsuarioSol.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtUsuarioSol.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtUsuarioSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioSol.Location = new System.Drawing.Point(81, 24);
            this.txtUsuarioSol.MaxLength = 11;
            this.txtUsuarioSol.Name = "txtUsuarioSol";
            this.txtUsuarioSol.Size = new System.Drawing.Size(174, 20);
            this.txtUsuarioSol.TabIndex = 346;
            this.txtUsuarioSol.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtUsuarioSol.TextoVacio = "<Descripcion>";
            this.txtUsuarioSol.UseSystemPasswordChar = true;
            // 
            // txtClaveSol
            // 
            this.txtClaveSol.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtClaveSol.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtClaveSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveSol.Location = new System.Drawing.Point(81, 45);
            this.txtClaveSol.Name = "txtClaveSol";
            this.txtClaveSol.Size = new System.Drawing.Size(174, 20);
            this.txtClaveSol.TabIndex = 347;
            this.txtClaveSol.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtClaveSol.TextoVacio = "<Descripcion>";
            this.txtClaveSol.UseSystemPasswordChar = true;
            // 
            // chkImagen
            // 
            this.chkImagen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkImagen.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImagen.Location = new System.Drawing.Point(603, 239);
            this.chkImagen.Name = "chkImagen";
            this.chkImagen.Size = new System.Drawing.Size(164, 24);
            this.chkImagen.TabIndex = 344;
            this.chkImagen.TabStop = false;
            this.chkImagen.Text = "Establecer Imagenes";
            this.chkImagen.UseVisualStyleBackColor = true;
            this.chkImagen.CheckedChanged += new System.EventHandler(this.chkImagen_CheckedChanged);
            // 
            // btQuitar
            // 
            this.btQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuitar.Image = global::ClienteWinForm.Properties.Resources.quitar_linea;
            this.btQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQuitar.Location = new System.Drawing.Point(895, 315);
            this.btQuitar.Name = "btQuitar";
            this.btQuitar.Size = new System.Drawing.Size(63, 23);
            this.btQuitar.TabIndex = 343;
            this.btQuitar.Text = "Quitar";
            this.btQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btQuitar.UseVisualStyleBackColor = true;
            this.btQuitar.Click += new System.EventHandler(this.btQuitar_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregar.Image = global::ClienteWinForm.Properties.Resources.Add_Reg;
            this.btAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAgregar.Location = new System.Drawing.Point(823, 315);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(69, 24);
            this.btAgregar.TabIndex = 342;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvEmpresas);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(777, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 305);
            this.panel1.TabIndex = 341;
            // 
            // dgvEmpresas
            // 
            this.dgvEmpresas.AllowUserToAddRows = false;
            this.dgvEmpresas.AllowUserToDeleteRows = false;
            this.dgvEmpresas.AutoGenerateColumns = false;
            this.dgvEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idImagenDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.dgvEmpresas.DataSource = this.bsEmpresaImagenes;
            this.dgvEmpresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpresas.EnableHeadersVisualStyles = false;
            this.dgvEmpresas.Location = new System.Drawing.Point(0, 18);
            this.dgvEmpresas.Name = "dgvEmpresas";
            this.dgvEmpresas.ReadOnly = true;
            this.dgvEmpresas.Size = new System.Drawing.Size(224, 285);
            this.dgvEmpresas.TabIndex = 1;
            this.dgvEmpresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresas_CellDoubleClick);
            // 
            // idImagenDataGridViewTextBoxColumn
            // 
            this.idImagenDataGridViewTextBoxColumn.DataPropertyName = "idImagen";
            this.idImagenDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idImagenDataGridViewTextBoxColumn.Name = "idImagenDataGridViewTextBoxColumn";
            this.idImagenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idImagenDataGridViewTextBoxColumn.Width = 40;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsEmpresaImagenes
            // 
            this.bsEmpresaImagenes.DataSource = typeof(Entidades.Maestros.EmpresaImagenesE);
            // 
            // btConfigurarCorreo
            // 
            this.btConfigurarCorreo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConfigurarCorreo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btConfigurarCorreo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btConfigurarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfigurarCorreo.Image = global::ClienteWinForm.Properties.Resources.comment_edit;
            this.btConfigurarCorreo.Location = new System.Drawing.Point(451, 220);
            this.btConfigurarCorreo.Name = "btConfigurarCorreo";
            this.btConfigurarCorreo.Size = new System.Drawing.Size(26, 18);
            this.btConfigurarCorreo.TabIndex = 340;
            this.btConfigurarCorreo.UseVisualStyleBackColor = true;
            this.btConfigurarCorreo.Click += new System.EventHandler(this.btConfigurarCorreo_Click);
            // 
            // pnDireccion
            // 
            this.pnDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDireccion.Controls.Add(this.label6);
            this.pnDireccion.Controls.Add(this.txtDireccion);
            this.pnDireccion.Controls.Add(label4);
            this.pnDireccion.Controls.Add(label1);
            this.pnDireccion.Controls.Add(this.cboDistrito);
            this.pnDireccion.Controls.Add(this.cboDepartamento);
            this.pnDireccion.Controls.Add(departamentoLabel);
            this.pnDireccion.Controls.Add(this.cboProvincia);
            this.pnDireccion.Location = new System.Drawing.Point(4, 271);
            this.pnDireccion.Name = "pnDireccion";
            this.pnDireccion.Size = new System.Drawing.Size(766, 76);
            this.pnDireccion.TabIndex = 13;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(9, 47);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(745, 20);
            this.txtDireccion.TabIndex = 17;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "Ingrese Direccion Completa";
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(547, 24);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(207, 21);
            this.cboDistrito.TabIndex = 16;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(92, 24);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(141, 21);
            this.cboDepartamento.TabIndex = 14;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(289, 24);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(213, 21);
            this.cboProvincia.TabIndex = 15;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaMod);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioReg);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel1);
            this.pnlAuditoria.Controls.Add(this.txtFechaReg);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Location = new System.Drawing.Point(502, 4);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(270, 117);
            this.pnlAuditoria.TabIndex = 21;
            // 
            // txtFechaMod
            // 
            this.txtFechaMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaMod.Enabled = false;
            this.txtFechaMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaMod.Location = new System.Drawing.Point(115, 88);
            this.txtFechaMod.Name = "txtFechaMod";
            this.txtFechaMod.Size = new System.Drawing.Size(143, 20);
            this.txtFechaMod.TabIndex = 21;
            this.txtFechaMod.TabStop = false;
            // 
            // txtUsuarioReg
            // 
            this.txtUsuarioReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioReg.Enabled = false;
            this.txtUsuarioReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioReg.Location = new System.Drawing.Point(115, 25);
            this.txtUsuarioReg.Name = "txtUsuarioReg";
            this.txtUsuarioReg.Size = new System.Drawing.Size(143, 20);
            this.txtUsuarioReg.TabIndex = 15;
            this.txtUsuarioReg.TabStop = false;
            // 
            // txtFechaReg
            // 
            this.txtFechaReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaReg.Enabled = false;
            this.txtFechaReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaReg.Location = new System.Drawing.Point(115, 46);
            this.txtFechaReg.Name = "txtFechaReg";
            this.txtFechaReg.Size = new System.Drawing.Size(143, 20);
            this.txtFechaReg.TabIndex = 17;
            this.txtFechaReg.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(115, 67);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(143, 20);
            this.txtUsuarioMod.TabIndex = 19;
            this.txtUsuarioMod.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.chkCalzado);
            this.pnlDetalle.Controls.Add(this.txtRuc);
            this.pnlDetalle.Controls.Add(this.txtEmailOtros);
            this.pnlDetalle.Controls.Add(this.txtEmailFact);
            this.pnlDetalle.Controls.Add(this.txtEmail);
            this.pnlDetalle.Controls.Add(this.txtWeb);
            this.pnlDetalle.Controls.Add(this.txtNumDocRepre);
            this.pnlDetalle.Controls.Add(this.txtRepresentante);
            this.pnlDetalle.Controls.Add(this.txtNombreComercial);
            this.pnlDetalle.Controls.Add(this.txtRazonSocial);
            this.pnlDetalle.Controls.Add(this.chkContribuyente);
            this.pnlDetalle.Controls.Add(label5);
            this.pnlDetalle.Controls.Add(this.txtIdEmpresa);
            this.pnlDetalle.Controls.Add(this.chkRetencion);
            this.pnlDetalle.Controls.Add(this.btBuscarRuc);
            this.pnlDetalle.Controls.Add(sFaxLabel);
            this.pnlDetalle.Controls.Add(sTelefonosLabel);
            this.pnlDetalle.Controls.Add(sWebLabel);
            this.pnlDetalle.Controls.Add(sNumDocRepresentanteLabel);
            this.pnlDetalle.Controls.Add(rUCLabel1);
            this.pnlDetalle.Controls.Add(sEmailFeLabel);
            this.pnlDetalle.Controls.Add(sEmailLabel);
            this.pnlDetalle.Controls.Add(idEmpresaLabel);
            this.pnlDetalle.Controls.Add(nombreComercialLabel);
            this.pnlDetalle.Controls.Add(razonSocialLabel);
            this.pnlDetalle.Controls.Add(representanteLegalLabel);
            this.pnlDetalle.Controls.Add(this.txtTelefonos);
            this.pnlDetalle.Controls.Add(this.txtFax);
            this.pnlDetalle.Location = new System.Drawing.Point(4, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(496, 265);
            this.pnlDetalle.TabIndex = 1;
            // 
            // chkCalzado
            // 
            this.chkCalzado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalzado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalzado.Location = new System.Drawing.Point(347, 27);
            this.chkCalzado.Name = "chkCalzado";
            this.chkCalzado.Size = new System.Drawing.Size(127, 17);
            this.chkCalzado.TabIndex = 358;
            this.chkCalzado.TabStop = false;
            this.chkCalzado.Text = "Empresa de Calzado";
            this.chkCalzado.UseVisualStyleBackColor = true;
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(182, 25);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(100, 20);
            this.txtRuc.TabIndex = 346;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            // 
            // txtEmailOtros
            // 
            this.txtEmailOtros.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmailOtros.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmailOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailOtros.Location = new System.Drawing.Point(115, 214);
            this.txtEmailOtros.Name = "txtEmailOtros";
            this.txtEmailOtros.Size = new System.Drawing.Size(358, 20);
            this.txtEmailOtros.TabIndex = 356;
            this.txtEmailOtros.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmailOtros.TextoVacio = "<Descripcion>";
            // 
            // txtEmailFact
            // 
            this.txtEmailFact.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmailFact.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmailFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailFact.Location = new System.Drawing.Point(115, 193);
            this.txtEmailFact.Name = "txtEmailFact";
            this.txtEmailFact.Size = new System.Drawing.Size(358, 20);
            this.txtEmailFact.TabIndex = 355;
            this.txtEmailFact.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmailFact.TextoVacio = "<Descripcion>";
            // 
            // txtEmail
            // 
            this.txtEmail.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmail.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(115, 172);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(358, 20);
            this.txtEmail.TabIndex = 354;
            this.txtEmail.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmail.TextoVacio = "<Descripcion>";
            // 
            // txtWeb
            // 
            this.txtWeb.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtWeb.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeb.Location = new System.Drawing.Point(115, 151);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(358, 20);
            this.txtWeb.TabIndex = 353;
            this.txtWeb.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtWeb.TextoVacio = "<Descripcion>";
            // 
            // txtNumDocRepre
            // 
            this.txtNumDocRepre.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumDocRepre.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumDocRepre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDocRepre.Location = new System.Drawing.Point(115, 109);
            this.txtNumDocRepre.Name = "txtNumDocRepre";
            this.txtNumDocRepre.Size = new System.Drawing.Size(100, 20);
            this.txtNumDocRepre.TabIndex = 350;
            this.txtNumDocRepre.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumDocRepre.TextoVacio = "<Descripcion>";
            // 
            // txtRepresentante
            // 
            this.txtRepresentante.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRepresentante.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRepresentante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepresentante.Location = new System.Drawing.Point(115, 88);
            this.txtRepresentante.Name = "txtRepresentante";
            this.txtRepresentante.Size = new System.Drawing.Size(358, 20);
            this.txtRepresentante.TabIndex = 349;
            this.txtRepresentante.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRepresentante.TextoVacio = "<Descripcion>";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreComercial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreComercial.Location = new System.Drawing.Point(115, 67);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(358, 20);
            this.txtNombreComercial.TabIndex = 348;
            this.txtNombreComercial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreComercial.TextoVacio = "<Descripcion>";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(115, 46);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(358, 20);
            this.txtRazonSocial.TabIndex = 347;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            // 
            // chkContribuyente
            // 
            this.chkContribuyente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkContribuyente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContribuyente.Location = new System.Drawing.Point(336, 237);
            this.chkContribuyente.Name = "chkContribuyente";
            this.chkContribuyente.Size = new System.Drawing.Size(135, 17);
            this.chkContribuyente.TabIndex = 346;
            this.chkContribuyente.TabStop = false;
            this.chkContribuyente.Text = "Principal Contribuyente";
            this.chkContribuyente.UseVisualStyleBackColor = true;
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdEmpresa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdEmpresa.Enabled = false;
            this.txtIdEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEmpresa.Location = new System.Drawing.Point(115, 25);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(35, 20);
            this.txtIdEmpresa.TabIndex = 345;
            this.txtIdEmpresa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdEmpresa.TextoVacio = "<Descripcion>";
            // 
            // chkRetencion
            // 
            this.chkRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencion.Location = new System.Drawing.Point(190, 237);
            this.chkRetencion.Name = "chkRetencion";
            this.chkRetencion.Size = new System.Drawing.Size(135, 17);
            this.chkRetencion.TabIndex = 345;
            this.chkRetencion.TabStop = false;
            this.chkRetencion.Text = "Agente de Retención";
            this.chkRetencion.UseVisualStyleBackColor = true;
            // 
            // btBuscarRuc
            // 
            this.btBuscarRuc.BackColor = System.Drawing.Color.Azure;
            this.btBuscarRuc.BackgroundImage = global::ClienteWinForm.Properties.Resources.SUNAT;
            this.btBuscarRuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarRuc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarRuc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarRuc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarRuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarRuc.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btBuscarRuc.Location = new System.Drawing.Point(285, 25);
            this.btBuscarRuc.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscarRuc.Name = "btBuscarRuc";
            this.btBuscarRuc.Size = new System.Drawing.Size(58, 20);
            this.btBuscarRuc.TabIndex = 112;
            this.btBuscarRuc.TabStop = false;
            this.btBuscarRuc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btBuscarRuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscarRuc.UseVisualStyleBackColor = false;
            this.btBuscarRuc.Click += new System.EventHandler(this.btBuscarRuc_Click);
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTelefonos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonos.Location = new System.Drawing.Point(115, 130);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(237, 20);
            this.txtTelefonos.TabIndex = 351;
            this.txtTelefonos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTelefonos.TextoVacio = "<Descripcion>";
            // 
            // txtFax
            // 
            this.txtFax.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFax.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(388, 130);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(85, 20);
            this.txtFax.TabIndex = 352;
            this.txtFax.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFax.TextoVacio = "<Descripcion>";
            // 
            // chkEstado
            // 
            this.chkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstado.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstado.Location = new System.Drawing.Point(512, 203);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(119, 24);
            this.chkEstado.TabIndex = 20;
            this.chkEstado.TabStop = false;
            this.chkEstado.Text = "De Baja";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(494, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 18);
            this.label2.TabIndex = 429;
            this.label2.Text = "Auditoria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 18);
            this.label3.TabIndex = 429;
            this.label3.Text = "Datos Sunat";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(764, 18);
            this.label6.TabIndex = 429;
            this.label6.Text = "Dirección";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 18);
            this.label7.TabIndex = 429;
            this.label7.Text = "Imagenes";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 350);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkImagen);
            this.Controls.Add(this.btQuitar);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btConfigurarCorreo);
            this.Controls.Add(this.pnDireccion);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.chkEstado);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmEmpresa";
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.FrmEmpresa_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpresaImagenes)).EndInit();
            this.pnDireccion.ResumeLayout(false);
            this.pnDireccion.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtUsuarioReg;
        private System.Windows.Forms.TextBox txtFechaMod;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaReg;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.Panel pnDireccion;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.Button btBuscarRuc;
        private System.Windows.Forms.Button btConfigurarCorreo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEmpresas;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Button btQuitar;
        private System.Windows.Forms.CheckBox chkImagen;
        private System.Windows.Forms.BindingSource bsEmpresaImagenes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idImagenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkContribuyente;
        private System.Windows.Forms.CheckBox chkRetencion;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtEmailOtros;
        private ControlesWinForm.SuperTextBox txtEmailFact;
        private ControlesWinForm.SuperTextBox txtEmail;
        private ControlesWinForm.SuperTextBox txtWeb;
        private ControlesWinForm.SuperTextBox txtNumDocRepre;
        private ControlesWinForm.SuperTextBox txtRepresentante;
        private ControlesWinForm.SuperTextBox txtNombreComercial;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private ControlesWinForm.SuperTextBox txtIdEmpresa;
        private ControlesWinForm.SuperTextBox txtTelefonos;
        private ControlesWinForm.SuperTextBox txtFax;
        private System.Windows.Forms.Panel panel2;
        private ControlesWinForm.SuperTextBox txtUsuarioSol;
        private ControlesWinForm.SuperTextBox txtClaveSol;
        private System.Windows.Forms.CheckBox chkVerDatos;
        private System.Windows.Forms.CheckBox chkCalzado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
    }
}