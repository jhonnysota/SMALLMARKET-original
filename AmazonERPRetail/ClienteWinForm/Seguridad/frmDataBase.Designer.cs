namespace ClienteWinForm.Seguridad
{
    partial class frmDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataBase));
            this.txtServidor = new ControlesWinForm.SuperTextBox();
            this.txtUsuario = new ControlesWinForm.SuperTextBox();
            this.txtClave = new ControlesWinForm.SuperTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.cboInstancias = new System.Windows.Forms.ComboBox();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSql = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btActualizarBd = new System.Windows.Forms.Button();
            this.btProbar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtServicio = new ControlesWinForm.SuperTextBox();
            this.btServicio = new System.Windows.Forms.Button();
            this.btCadConexion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtConexion = new ControlesWinForm.SuperTextBox();
            this.btBaseDato = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(641, 197);
            this.btCancelar.Size = new System.Drawing.Size(90, 28);
            this.btCancelar.TabStop = false;
            this.btCancelar.Visible = false;
            // 
            // btAceptar
            // 
            this.btAceptar.Enabled = false;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Location = new System.Drawing.Point(549, 197);
            this.btAceptar.Size = new System.Drawing.Size(90, 28);
            this.btAceptar.TabStop = false;
            this.btAceptar.Visible = false;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(446, 18);
            this.lblTitPnlBase.Text = "Cambiar Configuración";
            this.lblTitPnlBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipal.Size = new System.Drawing.Size(461, 25);
            this.lblTituloPrincipal.Text = "SQL Server - Conexión";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(434, 2);
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btActualizar);
            this.pnlBase.Controls.Add(this.groupBox2);
            this.pnlBase.Controls.Add(this.groupBox1);
            this.pnlBase.Controls.Add(this.cboInstancias);
            this.pnlBase.Controls.Add(this.btProbar);
            this.pnlBase.Controls.Add(this.txtServidor);
            this.pnlBase.Location = new System.Drawing.Point(7, 209);
            this.pnlBase.Size = new System.Drawing.Size(448, 278);
            this.pnlBase.Controls.SetChildIndex(this.txtServidor, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.btProbar, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboInstancias, 0);
            this.pnlBase.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlBase.Controls.SetChildIndex(this.groupBox2, 0);
            this.pnlBase.Controls.SetChildIndex(this.btActualizar, 0);
            // 
            // txtServidor
            // 
            this.txtServidor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtServidor.ColorTextoVacio = System.Drawing.Color.DimGray;
            this.txtServidor.Enabled = false;
            this.txtServidor.Location = new System.Drawing.Point(29, 48);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(375, 20);
            this.txtServidor.TabIndex = 101;
            this.txtServidor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtServidor.TextoVacio = "Nombre del Servidor";
            this.txtServidor.TextChanged += new System.EventHandler(this.txtServidor_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtUsuario.ColorTextoVacio = System.Drawing.Color.DimGray;
            this.txtUsuario.Location = new System.Drawing.Point(17, 47);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(311, 20);
            this.txtUsuario.TabIndex = 102;
            this.txtUsuario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtUsuario.TextoVacio = "Nombre de Usuario";
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtClave
            // 
            this.txtClave.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtClave.ColorTextoVacio = System.Drawing.Color.DimGray;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(17, 69);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '•';
            this.txtClave.Size = new System.Drawing.Size(311, 20);
            this.txtClave.TabIndex = 103;
            this.txtClave.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtClave.TextoVacio = "Contraseña";
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            this.txtClave.Validating += new System.ComponentModel.CancelEventHandler(this.txtClave_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.Imagen_Procesar;
            this.pictureBox1.Location = new System.Drawing.Point(6, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.labelDegradado1.Location = new System.Drawing.Point(7, 147);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(448, 59);
            this.labelDegradado1.TabIndex = 116;
            this.labelDegradado1.Text = "Cambiar la configuración de conexión del servidor SQL\r\n¡Advertencia! cambiar la c" +
    "onfiguración de SQL Server puede causar que la aplicación no funcione correctame" +
    "nte. Utilice con cuidado.";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboInstancias
            // 
            this.cboInstancias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstancias.Enabled = false;
            this.cboInstancias.FormattingEnabled = true;
            this.cboInstancias.Location = new System.Drawing.Point(29, 25);
            this.cboInstancias.Name = "cboInstancias";
            this.cboInstancias.Size = new System.Drawing.Size(375, 21);
            this.cboInstancias.TabIndex = 100;
            this.cboInstancias.SelectionChangeCommitted += new System.EventHandler(this.cboInstancias_SelectionChangeCommitted);
            // 
            // cboDataBase
            // 
            this.cboDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBase.Enabled = false;
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Location = new System.Drawing.Point(16, 19);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(376, 21);
            this.cboDataBase.TabIndex = 104;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSql);
            this.groupBox1.Controls.Add(this.rbWindows);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.txtClave);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 101);
            this.groupBox1.TabIndex = 370;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexión con el Servidor";
            // 
            // rbSql
            // 
            this.rbSql.AutoSize = true;
            this.rbSql.Checked = true;
            this.rbSql.Location = new System.Drawing.Point(17, 21);
            this.rbSql.Name = "rbSql";
            this.rbSql.Size = new System.Drawing.Size(188, 17);
            this.rbSql.TabIndex = 368;
            this.rbSql.TabStop = true;
            this.rbSql.Text = "Usar Autenticación de SQL Server";
            this.rbSql.UseVisualStyleBackColor = true;
            // 
            // rbWindows
            // 
            this.rbWindows.AutoSize = true;
            this.rbWindows.Location = new System.Drawing.Point(220, 19);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(177, 17);
            this.rbWindows.TabIndex = 367;
            this.rbWindows.Text = "Usar Autenticación de Windows";
            this.rbWindows.UseVisualStyleBackColor = true;
            this.rbWindows.Visible = false;
            this.rbWindows.CheckedChanged += new System.EventHandler(this.rbWindows_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btActualizarBd);
            this.groupBox2.Controls.Add(this.cboDataBase);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 50);
            this.groupBox2.TabIndex = 371;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Establecer Conexión a";
            // 
            // btActualizarBd
            // 
            this.btActualizarBd.BackgroundImage = global::ClienteWinForm.Properties.Resources.Refrescar48x48;
            this.btActualizarBd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btActualizarBd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizarBd.FlatAppearance.BorderSize = 0;
            this.btActualizarBd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btActualizarBd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btActualizarBd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizarBd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizarBd.Location = new System.Drawing.Point(398, 18);
            this.btActualizarBd.Name = "btActualizarBd";
            this.btActualizarBd.Size = new System.Drawing.Size(21, 20);
            this.btActualizarBd.TabIndex = 374;
            this.btActualizarBd.UseVisualStyleBackColor = true;
            this.btActualizarBd.Click += new System.EventHandler(this.btActualizarBd_Click);
            // 
            // btProbar
            // 
            this.btProbar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btProbar.Enabled = false;
            this.btProbar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btProbar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btProbar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btProbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProbar.Image = global::ClienteWinForm.Properties.Resources.Conexion;
            this.btProbar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btProbar.Location = new System.Drawing.Point(12, 238);
            this.btProbar.Name = "btProbar";
            this.btProbar.Size = new System.Drawing.Size(169, 32);
            this.btProbar.TabIndex = 372;
            this.btProbar.TabStop = false;
            this.btProbar.Text = "Prueba de Conexión";
            this.btProbar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btProbar.UseVisualStyleBackColor = false;
            this.btProbar.Click += new System.EventHandler(this.btProbar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackgroundImage = global::ClienteWinForm.Properties.Resources.Refrescar48x48;
            this.btActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizar.FlatAppearance.BorderSize = 0;
            this.btActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Location = new System.Drawing.Point(414, 26);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(21, 20);
            this.btActualizar.TabIndex = 373;
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDegradado2);
            this.panel1.Controls.Add(this.txtServicio);
            this.panel1.Controls.Add(this.btServicio);
            this.panel1.Location = new System.Drawing.Point(84, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 54);
            this.panel1.TabIndex = 373;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(369, 18);
            this.labelDegradado2.TabIndex = 370;
            this.labelDegradado2.Text = "Servicios";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServicio
            // 
            this.txtServicio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtServicio.ColorTextoVacio = System.Drawing.Color.DimGray;
            this.txtServicio.Location = new System.Drawing.Point(8, 25);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(322, 20);
            this.txtServicio.TabIndex = 366;
            this.txtServicio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtServicio.TextoVacio = "Dirección del Servicio";
            // 
            // btServicio
            // 
            this.btServicio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btServicio.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btServicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btServicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btServicio.Image = global::ClienteWinForm.Properties.Resources.guardar_16x16neg;
            this.btServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btServicio.Location = new System.Drawing.Point(335, 21);
            this.btServicio.Name = "btServicio";
            this.btServicio.Size = new System.Drawing.Size(28, 24);
            this.btServicio.TabIndex = 377;
            this.btServicio.TabStop = false;
            this.btServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btServicio.UseVisualStyleBackColor = false;
            this.btServicio.Click += new System.EventHandler(this.btServicio_Click);
            // 
            // btCadConexion
            // 
            this.btCadConexion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCadConexion.Enabled = false;
            this.btCadConexion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCadConexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCadConexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCadConexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCadConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCadConexion.Image = global::ClienteWinForm.Properties.Resources.guardar_16x16neg;
            this.btCadConexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCadConexion.Location = new System.Drawing.Point(412, 22);
            this.btCadConexion.Name = "btCadConexion";
            this.btCadConexion.Size = new System.Drawing.Size(28, 24);
            this.btCadConexion.TabIndex = 378;
            this.btCadConexion.TabStop = false;
            this.btCadConexion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCadConexion.UseVisualStyleBackColor = false;
            this.btCadConexion.Click += new System.EventHandler(this.btCadConexion_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado3);
            this.panel2.Controls.Add(this.btCadConexion);
            this.panel2.Controls.Add(this.txtConexion);
            this.panel2.Location = new System.Drawing.Point(7, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 54);
            this.panel2.TabIndex = 374;
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(446, 18);
            this.labelDegradado3.TabIndex = 370;
            this.labelDegradado3.Text = "Cadena de Conexión";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConexion
            // 
            this.txtConexion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtConexion.BackColor = System.Drawing.Color.Silver;
            this.txtConexion.ColorTextoVacio = System.Drawing.Color.DimGray;
            this.txtConexion.ForeColor = System.Drawing.Color.Navy;
            this.txtConexion.Location = new System.Drawing.Point(8, 24);
            this.txtConexion.Name = "txtConexion";
            this.txtConexion.ReadOnly = true;
            this.txtConexion.Size = new System.Drawing.Size(398, 20);
            this.txtConexion.TabIndex = 366;
            this.txtConexion.TabStop = false;
            this.txtConexion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtConexion.TextoVacio = "Ruta";
            // 
            // btBaseDato
            // 
            this.btBaseDato.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btBaseDato.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBaseDato.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBaseDato.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBaseDato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBaseDato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBaseDato.Image = global::ClienteWinForm.Properties.Resources.DB_settings;
            this.btBaseDato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBaseDato.Location = new System.Drawing.Point(417, 108);
            this.btBaseDato.Name = "btBaseDato";
            this.btBaseDato.Size = new System.Drawing.Size(36, 32);
            this.btBaseDato.TabIndex = 378;
            this.btBaseDato.TabStop = false;
            this.btBaseDato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBaseDato.UseVisualStyleBackColor = false;
            this.btBaseDato.Click += new System.EventHandler(this.btBaseDato_Click);
            // 
            // frmDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(461, 145);
            this.Controls.Add(this.btBaseDato);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelDegradado1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDataBase";
            this.Load += new System.EventHandler(this.frmDataBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDataBase_KeyDown);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.labelDegradado1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btBaseDato, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtServidor;
        private ControlesWinForm.SuperTextBox txtClave;
        private ControlesWinForm.SuperTextBox txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.ComboBox cboInstancias;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSql;
        private System.Windows.Forms.RadioButton rbWindows;
        private System.Windows.Forms.Button btProbar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btActualizarBd;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado2;
        private ControlesWinForm.SuperTextBox txtServicio;
        private System.Windows.Forms.Button btServicio;
        private System.Windows.Forms.Button btCadConexion;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado3;
        private ControlesWinForm.SuperTextBox txtConexion;
        private System.Windows.Forms.Button btBaseDato;
    }
}