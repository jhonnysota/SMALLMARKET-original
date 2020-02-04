namespace ClienteWinForm.Maestros
{
    partial class FrmLocal
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label departamentoLabel;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label idCondicionLabel;
            System.Windows.Forms.Label idLocalLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label nombreCortoLabel;
            System.Windows.Forms.Label telefonosLabel;
            this.bsLocal = new System.Windows.Forms.BindingSource(this.components);
            this.pnDireccion = new System.Windows.Forms.Panel();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionTextBox = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.fechaRegistroTextBox = new System.Windows.Forms.TextBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtSiglas = new ControlesWinForm.SuperTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.esPrincipalCheckBox = new System.Windows.Forms.CheckBox();
            this.esAlmacenCheckBox = new System.Windows.Forms.CheckBox();
            this.esTiendaCheckBox = new System.Windows.Forms.CheckBox();
            this.cboCondicion = new System.Windows.Forms.ComboBox();
            this.txtEmail = new ControlesWinForm.SuperTextBox();
            this.txtIdLocal = new ControlesWinForm.SuperTextBox();
            this.txtNombres = new ControlesWinForm.SuperTextBox();
            this.txtNombreCorto = new ControlesWinForm.SuperTextBox();
            this.telefonosSuperTextBox = new ControlesWinForm.SuperTextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            departamentoLabel = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            idCondicionLabel = new System.Windows.Forms.Label();
            idLocalLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            nombreCortoLabel = new System.Windows.Forms.Label();
            telefonosLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocal)).BeginInit();
            this.pnDireccion.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(507, 35);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(41, 13);
            label4.TabIndex = 107;
            label4.Text = "Distrito";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(243, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 13);
            label2.TabIndex = 105;
            label2.Text = "Provincia";
            // 
            // departamentoLabel
            // 
            departamentoLabel.AutoSize = true;
            departamentoLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            departamentoLabel.Location = new System.Drawing.Point(14, 35);
            departamentoLabel.Name = "departamentoLabel";
            departamentoLabel.Size = new System.Drawing.Size(76, 13);
            departamentoLabel.TabIndex = 103;
            departamentoLabel.Text = "Departamento";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(6, 96);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(6, 52);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(5, 74);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(6, 30);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(332, 180);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 13);
            label1.TabIndex = 254;
            label1.Text = "Siglas";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.Location = new System.Drawing.Point(15, 155);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 106;
            emailLabel.Text = "E-mail";
            // 
            // idCondicionLabel
            // 
            idCondicionLabel.AutoSize = true;
            idCondicionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idCondicionLabel.Location = new System.Drawing.Point(15, 180);
            idCondicionLabel.Name = "idCondicionLabel";
            idCondicionLabel.Size = new System.Drawing.Size(53, 13);
            idCondicionLabel.TabIndex = 120;
            idCondicionLabel.Text = "Condición";
            // 
            // idLocalLabel
            // 
            idLocalLabel.AutoSize = true;
            idLocalLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idLocalLabel.Location = new System.Drawing.Point(15, 69);
            idLocalLabel.Name = "idLocalLabel";
            idLocalLabel.Size = new System.Drawing.Size(57, 13);
            idLocalLabel.TabIndex = 124;
            idLocalLabel.Text = "Cód. Local";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(15, 91);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(44, 13);
            nombreLabel.TabIndex = 128;
            nombreLabel.Text = "Nombre";
            // 
            // nombreCortoLabel
            // 
            nombreCortoLabel.AutoSize = true;
            nombreCortoLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreCortoLabel.Location = new System.Drawing.Point(15, 113);
            nombreCortoLabel.Name = "nombreCortoLabel";
            nombreCortoLabel.Size = new System.Drawing.Size(74, 13);
            nombreCortoLabel.TabIndex = 130;
            nombreCortoLabel.Text = "Nombre Corto";
            // 
            // telefonosLabel
            // 
            telefonosLabel.AutoSize = true;
            telefonosLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            telefonosLabel.Location = new System.Drawing.Point(15, 135);
            telefonosLabel.Name = "telefonosLabel";
            telefonosLabel.Size = new System.Drawing.Size(54, 13);
            telefonosLabel.TabIndex = 134;
            telefonosLabel.Text = "Teléfonos";
            // 
            // bsLocal
            // 
            this.bsLocal.DataSource = typeof(Entidades.Maestros.LocalE);
            // 
            // pnDireccion
            // 
            this.pnDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDireccion.Controls.Add(this.label5);
            this.pnDireccion.Controls.Add(this.txtDireccion);
            this.pnDireccion.Controls.Add(label4);
            this.pnDireccion.Controls.Add(label2);
            this.pnDireccion.Controls.Add(this.cboDistrito);
            this.pnDireccion.Controls.Add(this.cboDepartamento);
            this.pnDireccion.Controls.Add(departamentoLabel);
            this.pnDireccion.Controls.Add(this.cboProvincia);
            this.pnDireccion.Location = new System.Drawing.Point(3, 213);
            this.pnDireccion.Name = "pnDireccion";
            this.pnDireccion.Size = new System.Drawing.Size(767, 89);
            this.pnDireccion.TabIndex = 114;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "Direccion", true));
            this.txtDireccion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(15, 57);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(732, 20);
            this.txtDireccion.TabIndex = 112;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "Ingrese Direccion Completa";
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(548, 31);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(199, 21);
            this.cboDistrito.TabIndex = 108;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(93, 31);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(141, 21);
            this.cboDepartamento.TabIndex = 104;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(296, 31);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(199, 21);
            this.cboProvincia.TabIndex = 106;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionTextBox);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.fechaRegistroTextBox);
            this.pnlAuditoria.Location = new System.Drawing.Point(509, 3);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(261, 126);
            this.pnlAuditoria.TabIndex = 3;
            // 
            // fechaModificacionTextBox
            // 
            this.fechaModificacionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.fechaModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "FechaModificacion", true));
            this.fechaModificacionTextBox.Enabled = false;
            this.fechaModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionTextBox.Location = new System.Drawing.Point(114, 93);
            this.fechaModificacionTextBox.Name = "fechaModificacionTextBox";
            this.fechaModificacionTextBox.Size = new System.Drawing.Size(136, 20);
            this.fechaModificacionTextBox.TabIndex = 7;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(114, 27);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(136, 20);
            this.usuarioRegistroTextBox.TabIndex = 1;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(114, 71);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(136, 20);
            this.usuarioModificacionTextBox.TabIndex = 5;
            // 
            // fechaRegistroTextBox
            // 
            this.fechaRegistroTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.fechaRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "FechaRegistro", true));
            this.fechaRegistroTextBox.Enabled = false;
            this.fechaRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaRegistroTextBox.Location = new System.Drawing.Point(114, 49);
            this.fechaRegistroTextBox.Name = "fechaRegistroTextBox";
            this.fechaRegistroTextBox.Size = new System.Drawing.Size(136, 20);
            this.fechaRegistroTextBox.TabIndex = 3;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(label1);
            this.pnlDetalle.Controls.Add(this.txtSiglas);
            this.pnlDetalle.Controls.Add(this.panel1);
            this.pnlDetalle.Controls.Add(this.cboCondicion);
            this.pnlDetalle.Controls.Add(emailLabel);
            this.pnlDetalle.Controls.Add(this.txtEmail);
            this.pnlDetalle.Controls.Add(idCondicionLabel);
            this.pnlDetalle.Controls.Add(idLocalLabel);
            this.pnlDetalle.Controls.Add(this.txtIdLocal);
            this.pnlDetalle.Controls.Add(nombreLabel);
            this.pnlDetalle.Controls.Add(this.txtNombres);
            this.pnlDetalle.Controls.Add(nombreCortoLabel);
            this.pnlDetalle.Controls.Add(this.txtNombreCorto);
            this.pnlDetalle.Controls.Add(telefonosLabel);
            this.pnlDetalle.Controls.Add(this.telefonosSuperTextBox);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(504, 208);
            this.pnlDetalle.TabIndex = 2;
            // 
            // txtSiglas
            // 
            this.txtSiglas.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSiglas.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSiglas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiglas.Location = new System.Drawing.Point(370, 176);
            this.txtSiglas.Name = "txtSiglas";
            this.txtSiglas.Size = new System.Drawing.Size(117, 20);
            this.txtSiglas.TabIndex = 253;
            this.txtSiglas.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSiglas.TextoVacio = "<Descripcion>";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.esPrincipalCheckBox);
            this.panel1.Controls.Add(this.esAlmacenCheckBox);
            this.panel1.Controls.Add(this.esTiendaCheckBox);
            this.panel1.Location = new System.Drawing.Point(16, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 33);
            this.panel1.TabIndex = 105;
            // 
            // esPrincipalCheckBox
            // 
            this.esPrincipalCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.esPrincipalCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsLocal, "EsPrincipal", true));
            this.esPrincipalCheckBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esPrincipalCheckBox.Location = new System.Drawing.Point(65, 3);
            this.esPrincipalCheckBox.Name = "esPrincipalCheckBox";
            this.esPrincipalCheckBox.Size = new System.Drawing.Size(108, 24);
            this.esPrincipalCheckBox.TabIndex = 111;
            this.esPrincipalCheckBox.Text = "Es Principal";
            this.esPrincipalCheckBox.UseVisualStyleBackColor = false;
            // 
            // esAlmacenCheckBox
            // 
            this.esAlmacenCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.esAlmacenCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsLocal, "EsAlmacen", true));
            this.esAlmacenCheckBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esAlmacenCheckBox.Location = new System.Drawing.Point(188, 3);
            this.esAlmacenCheckBox.Name = "esAlmacenCheckBox";
            this.esAlmacenCheckBox.Size = new System.Drawing.Size(107, 24);
            this.esAlmacenCheckBox.TabIndex = 109;
            this.esAlmacenCheckBox.Text = "Es Almacen";
            this.esAlmacenCheckBox.UseVisualStyleBackColor = false;
            // 
            // esTiendaCheckBox
            // 
            this.esTiendaCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.esTiendaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsLocal, "EsTienda", true));
            this.esTiendaCheckBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esTiendaCheckBox.Location = new System.Drawing.Point(324, 3);
            this.esTiendaCheckBox.Name = "esTiendaCheckBox";
            this.esTiendaCheckBox.Size = new System.Drawing.Size(101, 24);
            this.esTiendaCheckBox.TabIndex = 115;
            this.esTiendaCheckBox.Text = "Es Tienda";
            this.esTiendaCheckBox.UseVisualStyleBackColor = false;
            // 
            // cboCondicion
            // 
            this.cboCondicion.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLocal, "idCondicion", true));
            this.cboCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicion.FormattingEnabled = true;
            this.cboCondicion.Location = new System.Drawing.Point(101, 176);
            this.cboCondicion.Name = "cboCondicion";
            this.cboCondicion.Size = new System.Drawing.Size(200, 21);
            this.cboCondicion.TabIndex = 113;
            // 
            // txtEmail
            // 
            this.txtEmail.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEmail.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "email", true));
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(101, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(271, 20);
            this.txtEmail.TabIndex = 107;
            this.txtEmail.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEmail.TextoVacio = "<Descripcion>";
            // 
            // txtIdLocal
            // 
            this.txtIdLocal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdLocal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdLocal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "IdLocal", true));
            this.txtIdLocal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdLocal.Location = new System.Drawing.Point(101, 65);
            this.txtIdLocal.Name = "txtIdLocal";
            this.txtIdLocal.ReadOnly = true;
            this.txtIdLocal.Size = new System.Drawing.Size(41, 20);
            this.txtIdLocal.TabIndex = 125;
            this.txtIdLocal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdLocal.TextoVacio = "<Descripcion>";
            // 
            // txtNombres
            // 
            this.txtNombres.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombres.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombres.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "Nombre", true));
            this.txtNombres.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(101, 87);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(386, 20);
            this.txtNombres.TabIndex = 129;
            this.txtNombres.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombres.TextoVacio = "<Descripcion>";
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreCorto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreCorto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "NombreCorto", true));
            this.txtNombreCorto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCorto.Location = new System.Drawing.Point(101, 109);
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(386, 20);
            this.txtNombreCorto.TabIndex = 131;
            this.txtNombreCorto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreCorto.TextoVacio = "<Descripcion>";
            // 
            // telefonosSuperTextBox
            // 
            this.telefonosSuperTextBox.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.telefonosSuperTextBox.ColorTextoVacio = System.Drawing.Color.Gray;
            this.telefonosSuperTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocal, "Telefonos", true));
            this.telefonosSuperTextBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonosSuperTextBox.Location = new System.Drawing.Point(101, 131);
            this.telefonosSuperTextBox.Name = "telefonosSuperTextBox";
            this.telefonosSuperTextBox.Size = new System.Drawing.Size(271, 20);
            this.telefonosSuperTextBox.TabIndex = 135;
            this.telefonosSuperTextBox.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.telefonosSuperTextBox.TextoVacio = "<Descripcion>";
            // 
            // chkEstado
            // 
            this.chkEstado.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsLocal, "Estado", true));
            this.chkEstado.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstado.Location = new System.Drawing.Point(516, 158);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(115, 24);
            this.chkEstado.TabIndex = 113;
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
            this.label8.Size = new System.Drawing.Size(502, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 18);
            this.label3.TabIndex = 429;
            this.label3.Text = "Auditoria";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(765, 18);
            this.label5.TabIndex = 429;
            this.label5.Text = "Dirección";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 305);
            this.Controls.Add(this.pnDireccion);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.chkEstado);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmLocal";
            this.Text = "Locales";
            this.Load += new System.EventHandler(this.FrmLocal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLocal)).EndInit();
            this.pnDireccion.ResumeLayout(false);
            this.pnDireccion.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fechaModificacionTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox fechaRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.BindingSource bsLocal;
        private ControlesWinForm.SuperTextBox txtEmail;
        private System.Windows.Forms.CheckBox esAlmacenCheckBox;
        private System.Windows.Forms.CheckBox esPrincipalCheckBox;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.CheckBox esTiendaCheckBox;
        private ControlesWinForm.SuperTextBox txtIdLocal;
        private ControlesWinForm.SuperTextBox txtNombres;
        private ControlesWinForm.SuperTextBox txtNombreCorto;
        private ControlesWinForm.SuperTextBox telefonosSuperTextBox;
        private System.Windows.Forms.Panel pnDireccion;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboCondicion;
        private ControlesWinForm.SuperTextBox txtSiglas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}