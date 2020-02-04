namespace ClienteWinForm.Maestros
{
    partial class frmVendedor
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
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendedor));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlCondicion = new System.Windows.Forms.Panel();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.txtFecBaja = new ControlesWinForm.SuperTextBox();
            this.pnlDireccion = new System.Windows.Forms.Panel();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCorreo = new ControlesWinForm.SuperTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtTelefonos = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.indSup = new System.Windows.Forms.CheckBox();
            this.txtIdVendedor = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btReniec = new System.Windows.Forms.Button();
            this.txtNroDocumento = new ControlesWinForm.SuperTextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new ControlesWinForm.SuperTextBox();
            this.lblApeMat = new System.Windows.Forms.Label();
            this.txtApeMat = new ControlesWinForm.SuperTextBox();
            this.lblApePat = new System.Windows.Forms.Label();
            this.txtApePat = new ControlesWinForm.SuperTextBox();
            this.txtCodVendedor = new ControlesWinForm.SuperTextBox();
            this.d = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.chkCarteraClientes = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboEstablecimiento = new System.Windows.Forms.ComboBox();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDivision = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            this.pnlCondicion.SuspendLayout();
            this.pnlDireccion.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.Location = new System.Drawing.Point(46, 51);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(31, 13);
            label20.TabIndex = 1609;
            label20.Text = "Zona";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(7, 75);
            label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(79, 13);
            label21.TabIndex = 1608;
            label21.Text = "Zon. Influencia";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "User-Files-icon.png");
            this.imageList1.Images.SetKeyName(1, "sucursal.png");
            // 
            // pnlCondicion
            // 
            this.pnlCondicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCondicion.Controls.Add(this.label7);
            this.pnlCondicion.Controls.Add(this.chkBaja);
            this.pnlCondicion.Controls.Add(this.txtFecBaja);
            this.pnlCondicion.Location = new System.Drawing.Point(607, 127);
            this.pnlCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCondicion.Name = "pnlCondicion";
            this.pnlCondicion.Size = new System.Drawing.Size(267, 51);
            this.pnlCondicion.TabIndex = 123;
            // 
            // chkBaja
            // 
            this.chkBaja.AutoSize = true;
            this.chkBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBaja.Enabled = false;
            this.chkBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaja.Location = new System.Drawing.Point(9, 26);
            this.chkBaja.Margin = new System.Windows.Forms.Padding(2);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(86, 17);
            this.chkBaja.TabIndex = 274;
            this.chkBaja.TabStop = false;
            this.chkBaja.Text = "Ind Estado";
            this.chkBaja.UseVisualStyleBackColor = true;
            this.chkBaja.CheckedChanged += new System.EventHandler(this.chkBaja_Click);
            // 
            // txtFecBaja
            // 
            this.txtFecBaja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFecBaja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecBaja.Enabled = false;
            this.txtFecBaja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecBaja.Location = new System.Drawing.Point(99, 24);
            this.txtFecBaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecBaja.Name = "txtFecBaja";
            this.txtFecBaja.Size = new System.Drawing.Size(154, 20);
            this.txtFecBaja.TabIndex = 100;
            this.txtFecBaja.TabStop = false;
            this.txtFecBaja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecBaja.TextoVacio = "<Descripcion>";
            // 
            // pnlDireccion
            // 
            this.pnlDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDireccion.Controls.Add(this.label6);
            this.pnlDireccion.Controls.Add(this.cboDistrito);
            this.pnlDireccion.Controls.Add(this.cboDepartamento);
            this.pnlDireccion.Controls.Add(this.cboProvincia);
            this.pnlDireccion.Controls.Add(this.label22);
            this.pnlDireccion.Controls.Add(this.txtCorreo);
            this.pnlDireccion.Controls.Add(this.label26);
            this.pnlDireccion.Controls.Add(this.txtTelefonos);
            this.pnlDireccion.Controls.Add(this.txtDireccion);
            this.pnlDireccion.Location = new System.Drawing.Point(3, 103);
            this.pnlDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDireccion.Name = "pnlDireccion";
            this.pnlDireccion.Size = new System.Drawing.Size(602, 124);
            this.pnlDireccion.TabIndex = 121;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(391, 24);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(199, 21);
            this.cboDistrito.TabIndex = 9;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(11, 24);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(174, 21);
            this.cboDepartamento.TabIndex = 7;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(188, 24);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(200, 21);
            this.cboProvincia.TabIndex = 8;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 94);
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
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(80, 91);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(405, 20);
            this.txtCorreo.TabIndex = 12;
            this.txtCorreo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCorreo.TextoVacio = "<Descripcion>";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(11, 72);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 115;
            this.label26.Text = "Telf./Cel.";
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTelefonos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonos.Location = new System.Drawing.Point(80, 69);
            this.txtTelefonos.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(405, 20);
            this.txtTelefonos.TabIndex = 11;
            this.txtTelefonos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTelefonos.TextoVacio = "<Descripcion>";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtDireccion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(11, 47);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(579, 20);
            this.txtDireccion.TabIndex = 10;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "Ingrese Dirección";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.indSup);
            this.pnlDatos.Controls.Add(this.txtIdVendedor);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.btReniec);
            this.pnlDatos.Controls.Add(this.txtNroDocumento);
            this.pnlDatos.Controls.Add(this.lblNombres);
            this.pnlDatos.Controls.Add(this.txtNombres);
            this.pnlDatos.Controls.Add(this.lblApeMat);
            this.pnlDatos.Controls.Add(this.txtApeMat);
            this.pnlDatos.Controls.Add(this.lblApePat);
            this.pnlDatos.Controls.Add(this.txtApePat);
            this.pnlDatos.Controls.Add(this.txtCodVendedor);
            this.pnlDatos.Controls.Add(this.d);
            this.pnlDatos.Controls.Add(this.label14);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(602, 97);
            this.pnlDatos.TabIndex = 120;
            // 
            // indSup
            // 
            this.indSup.AutoSize = true;
            this.indSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indSup.Location = new System.Drawing.Point(145, 27);
            this.indSup.Name = "indSup";
            this.indSup.Size = new System.Drawing.Size(76, 17);
            this.indSup.TabIndex = 277;
            this.indSup.TabStop = false;
            this.indSup.Text = "Supervisor";
            this.indSup.UseVisualStyleBackColor = true;
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdVendedor.Enabled = false;
            this.txtIdVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdVendedor.Location = new System.Drawing.Point(101, 24);
            this.txtIdVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(39, 20);
            this.txtIdVendedor.TabIndex = 1;
            this.txtIdVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdVendedor.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 276;
            this.label1.Text = "Id. Vendedor";
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
            this.btReniec.Location = new System.Drawing.Point(181, 47);
            this.btReniec.Margin = new System.Windows.Forms.Padding(2);
            this.btReniec.Name = "btReniec";
            this.btReniec.Size = new System.Drawing.Size(59, 18);
            this.btReniec.TabIndex = 81;
            this.btReniec.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btReniec.UseVisualStyleBackColor = false;
            this.btReniec.Click += new System.EventHandler(this.btReniec_Click_1);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNroDocumento.BackColor = System.Drawing.Color.White;
            this.txtNroDocumento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumento.Location = new System.Drawing.Point(101, 46);
            this.txtNroDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroDocumento.MaxLength = 8;
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(76, 20);
            this.txtNroDocumento.TabIndex = 2;
            this.txtNroDocumento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtNroDocumento.TextoVacio = "<Descripcion>";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.Location = new System.Drawing.Point(246, 28);
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
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(334, 24);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(256, 20);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombres.TextoVacio = "<Descripcion>";
            // 
            // lblApeMat
            // 
            this.lblApeMat.AutoSize = true;
            this.lblApeMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApeMat.Location = new System.Drawing.Point(246, 72);
            this.lblApeMat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApeMat.Name = "lblApeMat";
            this.lblApeMat.Size = new System.Drawing.Size(86, 13);
            this.lblApeMat.TabIndex = 109;
            this.lblApeMat.Text = "Apellido Materno";
            // 
            // txtApeMat
            // 
            this.txtApeMat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtApeMat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtApeMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApeMat.Location = new System.Drawing.Point(334, 68);
            this.txtApeMat.Margin = new System.Windows.Forms.Padding(2);
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.Size = new System.Drawing.Size(256, 20);
            this.txtApeMat.TabIndex = 6;
            this.txtApeMat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtApeMat.TextoVacio = "<Descripcion>";
            // 
            // lblApePat
            // 
            this.lblApePat.AutoSize = true;
            this.lblApePat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApePat.Location = new System.Drawing.Point(246, 50);
            this.lblApePat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApePat.Name = "lblApePat";
            this.lblApePat.Size = new System.Drawing.Size(84, 13);
            this.lblApePat.TabIndex = 107;
            this.lblApePat.Text = "Apellido Paterno";
            // 
            // txtApePat
            // 
            this.txtApePat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtApePat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtApePat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApePat.Location = new System.Drawing.Point(334, 46);
            this.txtApePat.Margin = new System.Windows.Forms.Padding(2);
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.Size = new System.Drawing.Size(256, 20);
            this.txtApePat.TabIndex = 5;
            this.txtApePat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtApePat.TextoVacio = "<Descripcion>";
            // 
            // txtCodVendedor
            // 
            this.txtCodVendedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodVendedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVendedor.Location = new System.Drawing.Point(101, 68);
            this.txtCodVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodVendedor.Name = "txtCodVendedor";
            this.txtCodVendedor.Size = new System.Drawing.Size(76, 20);
            this.txtCodVendedor.TabIndex = 3;
            this.txtCodVendedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodVendedor.TextoVacio = "<Descripcion>";
            // 
            // d
            // 
            this.d.AutoSize = true;
            this.d.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d.Location = new System.Drawing.Point(8, 72);
            this.d.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(89, 13);
            this.d.TabIndex = 274;
            this.d.Text = "Código Vendedor";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 50);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 113;
            this.label14.Text = "Documento Iden.";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label9);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(607, 3);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 122);
            this.pnlAuditoria.TabIndex = 122;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(9, 93);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(117, 89);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(137, 20);
            this.txtModifica.TabIndex = 0;
            this.txtModifica.TabStop = false;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(117, 47);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(137, 20);
            this.txtRegistro.TabIndex = 0;
            this.txtRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 26);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(137, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 68);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(137, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // chkCarteraClientes
            // 
            this.chkCarteraClientes.AutoSize = true;
            this.chkCarteraClientes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCarteraClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCarteraClientes.Location = new System.Drawing.Point(391, 24);
            this.chkCarteraClientes.Margin = new System.Windows.Forms.Padding(2);
            this.chkCarteraClientes.Name = "chkCarteraClientes";
            this.chkCarteraClientes.Size = new System.Drawing.Size(179, 17);
            this.chkCarteraClientes.TabIndex = 275;
            this.chkCarteraClientes.TabStop = false;
            this.chkCarteraClientes.Text = "Maneja Cartera de Clientes";
            this.chkCarteraClientes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cboEstablecimiento);
            this.panel1.Controls.Add(label20);
            this.panel1.Controls.Add(this.cboZona);
            this.panel1.Controls.Add(label21);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboDivision);
            this.panel1.Controls.Add(this.chkCarteraClientes);
            this.panel1.Location = new System.Drawing.Point(3, 230);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 101);
            this.panel1.TabIndex = 275;
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.DropDownWidth = 128;
            this.cboEstablecimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(94, 48);
            this.cboEstablecimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(202, 21);
            this.cboEstablecimiento.TabIndex = 1606;
            this.cboEstablecimiento.SelectionChangeCommitted += new System.EventHandler(this.cboEstablecimiento_SelectionChangeCommitted);
            // 
            // cboZona
            // 
            this.cboZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.DropDownWidth = 128;
            this.cboZona.Enabled = false;
            this.cboZona.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(94, 72);
            this.cboZona.Margin = new System.Windows.Forms.Padding(2);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(202, 21);
            this.cboZona.TabIndex = 1607;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 272;
            this.label5.Text = "División";
            // 
            // cboDivision
            // 
            this.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDivision.FormattingEnabled = true;
            this.cboDivision.Location = new System.Drawing.Point(94, 22);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Size = new System.Drawing.Size(202, 21);
            this.cboDivision.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(600, 18);
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
            this.label6.Size = new System.Drawing.Size(600, 18);
            this.label6.TabIndex = 429;
            this.label6.Text = "Ubicación";
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
            this.label7.Text = "Condición";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 18);
            this.label9.TabIndex = 429;
            this.label9.Text = "Auditoria";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(600, 18);
            this.label10.TabIndex = 1610;
            this.label10.Text = "Otros Datos";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 335);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlCondicion);
            this.Controls.Add(this.pnlDireccion);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmVendedor";
            this.Text = "Vendedores (Nuevo)";
            this.Load += new System.EventHandler(this.frmVendedor_Load);
            this.pnlCondicion.ResumeLayout(false);
            this.pnlCondicion.PerformLayout();
            this.pnlDireccion.ResumeLayout(false);
            this.pnlDireccion.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlCondicion;
        private System.Windows.Forms.CheckBox chkBaja;
        private ControlesWinForm.SuperTextBox txtFecBaja;
        private System.Windows.Forms.Panel pnlDireccion;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtCorreo;
        private System.Windows.Forms.Label label26;
        private ControlesWinForm.SuperTextBox txtTelefonos;
        private ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtIdVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btReniec;
        private ControlesWinForm.SuperTextBox txtNroDocumento;
        private System.Windows.Forms.Label lblNombres;
        private ControlesWinForm.SuperTextBox txtNombres;
        private System.Windows.Forms.Label lblApeMat;
        private ControlesWinForm.SuperTextBox txtApeMat;
        private System.Windows.Forms.Label lblApePat;
        private ControlesWinForm.SuperTextBox txtApePat;
        private ControlesWinForm.SuperTextBox txtCodVendedor;
        private System.Windows.Forms.Label d;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.CheckBox indSup;
        private System.Windows.Forms.CheckBox chkCarteraClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDivision;
        private System.Windows.Forms.ComboBox cboEstablecimiento;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}