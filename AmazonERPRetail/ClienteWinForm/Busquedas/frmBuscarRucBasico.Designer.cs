namespace ClienteWinForm.Busquedas
{
    partial class frmBuscarRucBasico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMarquee = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtCapcha = new ControlesWinForm.SuperTextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pbCapcha = new System.Windows.Forms.PictureBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.cboPadrones = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFecBaja = new ControlesWinForm.SuperTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRazon = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDni = new ControlesWinForm.SuperTextBox();
            this.txtInicio = new ControlesWinForm.SuperTextBox();
            this.txtEstado = new ControlesWinForm.SuperTextBox();
            this.txtCondicion = new ControlesWinForm.SuperTextBox();
            this.txtInscripcion = new ControlesWinForm.SuperTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreComercial = new ControlesWinForm.SuperTextBox();
            this.txtDireccion = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapcha)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(389, 308);
            this.btCancelar.Size = new System.Drawing.Size(146, 28);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(238, 308);
            this.btAceptar.Size = new System.Drawing.Size(146, 28);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(41, 22);
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(794, 25);
            this.lblTituloPrincipal.Text = "Consulta Ruc";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(765, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Location = new System.Drawing.Point(797, 325);
            this.pnlBase.Size = new System.Drawing.Size(43, 34);
            this.pnlBase.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMarquee);
            this.panel1.Controls.Add(this.pbProgress);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.txtCapcha);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.pbCapcha);
            this.panel1.Location = new System.Drawing.Point(6, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 99);
            this.panel1.TabIndex = 11;
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarquee.Location = new System.Drawing.Point(45, 77);
            this.lblMarquee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(0, 14);
            this.lblMarquee.TabIndex = 123;
            this.lblMarquee.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(9, 63);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(32, 31);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 122;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(196, 64);
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
            this.label8.Size = new System.Drawing.Size(767, 22);
            this.label8.TabIndex = 97;
            this.label8.Text = "Criterios de Busqueda";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número de RUC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(195, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "Ingrese el código que se muestra en la imagen";
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(97, 36);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(92, 20);
            this.txtRuc.TabIndex = 20;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.Leave += new System.EventHandler(this.txtRuc_Leave);
            // 
            // txtCapcha
            // 
            this.txtCapcha.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCapcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCapcha.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCapcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapcha.Location = new System.Drawing.Point(563, 36);
            this.txtCapcha.Margin = new System.Windows.Forms.Padding(2);
            this.txtCapcha.MaxLength = 11;
            this.txtCapcha.Name = "txtCapcha";
            this.txtCapcha.Size = new System.Drawing.Size(86, 20);
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
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.consulta_web;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(659, 36);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(99, 38);
            this.btBuscar.TabIndex = 40;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // pbCapcha
            // 
            this.pbCapcha.Location = new System.Drawing.Point(423, 36);
            this.pbCapcha.Margin = new System.Windows.Forms.Padding(2);
            this.pbCapcha.Name = "pbCapcha";
            this.pbCapcha.Size = new System.Drawing.Size(137, 48);
            this.pbCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCapcha.TabIndex = 118;
            this.pbCapcha.TabStop = false;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.cboPadrones);
            this.pnlAuditoria.Controls.Add(this.label16);
            this.pnlAuditoria.Controls.Add(this.txtFecBaja);
            this.pnlAuditoria.Controls.Add(this.label27);
            this.pnlAuditoria.Controls.Add(this.txtRazon);
            this.pnlAuditoria.Controls.Add(this.label22);
            this.pnlAuditoria.Controls.Add(this.txtDni);
            this.pnlAuditoria.Controls.Add(this.txtInicio);
            this.pnlAuditoria.Controls.Add(this.txtEstado);
            this.pnlAuditoria.Controls.Add(this.txtCondicion);
            this.pnlAuditoria.Controls.Add(this.txtInscripcion);
            this.pnlAuditoria.Controls.Add(this.label14);
            this.pnlAuditoria.Controls.Add(this.label13);
            this.pnlAuditoria.Controls.Add(this.label12);
            this.pnlAuditoria.Controls.Add(this.label11);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label5);
            this.pnlAuditoria.Controls.Add(this.txtNombreComercial);
            this.pnlAuditoria.Controls.Add(this.txtDireccion);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Location = new System.Drawing.Point(6, 129);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(782, 175);
            this.pnlAuditoria.TabIndex = 51;
            // 
            // cboPadrones
            // 
            this.cboPadrones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPadrones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPadrones.FormattingEnabled = true;
            this.cboPadrones.Location = new System.Drawing.Point(172, 138);
            this.cboPadrones.Margin = new System.Windows.Forms.Padding(2);
            this.cboPadrones.Name = "cboPadrones";
            this.cboPadrones.Size = new System.Drawing.Size(587, 21);
            this.cboPadrones.TabIndex = 141;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 142);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 140;
            this.label16.Text = "Padrones";
            // 
            // txtFecBaja
            // 
            this.txtFecBaja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecBaja.BackColor = System.Drawing.SystemColors.Window;
            this.txtFecBaja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecBaja.Location = new System.Drawing.Point(572, 75);
            this.txtFecBaja.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecBaja.MaxLength = 11;
            this.txtFecBaja.Name = "txtFecBaja";
            this.txtFecBaja.ReadOnly = true;
            this.txtFecBaja.Size = new System.Drawing.Size(186, 20);
            this.txtFecBaja.TabIndex = 139;
            this.txtFecBaja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecBaja.TextoVacio = "<Descripcion>";
            this.txtFecBaja.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(386, 80);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 13);
            this.label27.TabIndex = 138;
            this.label27.Text = "Fecha Baja";
            this.label27.Visible = false;
            // 
            // txtRazon
            // 
            this.txtRazon.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazon.BackColor = System.Drawing.SystemColors.Window;
            this.txtRazon.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazon.Location = new System.Drawing.Point(172, 12);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazon.MaxLength = 11;
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.ReadOnly = true;
            this.txtRazon.Size = new System.Drawing.Size(586, 20);
            this.txtRazon.TabIndex = 100;
            this.txtRazon.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazon.TextoVacio = "<Descripcion>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(653, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
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
            this.txtDni.Location = new System.Drawing.Point(684, 12);
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
            // txtInicio
            // 
            this.txtInicio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInicio.BackColor = System.Drawing.SystemColors.Window;
            this.txtInicio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Location = new System.Drawing.Point(572, 54);
            this.txtInicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtInicio.MaxLength = 11;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.ReadOnly = true;
            this.txtInicio.Size = new System.Drawing.Size(186, 20);
            this.txtInicio.TabIndex = 123;
            this.txtInicio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtInicio.TextoVacio = "<Descripcion>";
            // 
            // txtEstado
            // 
            this.txtEstado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEstado.BackColor = System.Drawing.SystemColors.Window;
            this.txtEstado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(172, 75);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEstado.MaxLength = 11;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(186, 20);
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
            this.txtCondicion.Location = new System.Drawing.Point(172, 96);
            this.txtCondicion.Margin = new System.Windows.Forms.Padding(2);
            this.txtCondicion.MaxLength = 11;
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.ReadOnly = true;
            this.txtCondicion.Size = new System.Drawing.Size(186, 20);
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
            this.txtInscripcion.Location = new System.Drawing.Point(172, 54);
            this.txtInscripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtInscripcion.MaxLength = 11;
            this.txtInscripcion.Name = "txtInscripcion";
            this.txtInscripcion.ReadOnly = true;
            this.txtInscripcion.Size = new System.Drawing.Size(186, 20);
            this.txtInscripcion.TabIndex = 122;
            this.txtInscripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtInscripcion.TextoVacio = "<Descripcion>";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(386, 59);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 13);
            this.label14.TabIndex = 103;
            this.label14.Text = "Fecha de Inicio de Actividades";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 101);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 102;
            this.label13.Text = "Condición del Contribuyente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 80);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 101;
            this.label12.Text = "Estado del Contribuyente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 59);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "Fecha de Inscripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razón Social";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dirección del Domicilio Fiscal";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreComercial.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombreComercial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreComercial.Location = new System.Drawing.Point(172, 33);
            this.txtNombreComercial.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreComercial.MaxLength = 11;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.ReadOnly = true;
            this.txtNombreComercial.Size = new System.Drawing.Size(587, 20);
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
            this.txtDireccion.Location = new System.Drawing.Point(172, 117);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.MaxLength = 11;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(587, 20);
            this.txtDireccion.TabIndex = 126;
            this.txtDireccion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDireccion.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre Comercial";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBuscarRucBasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 345);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmBuscarRucBasico";
            this.Text = "Consulta Sunat";
            this.Load += new System.EventHandler(this.frmBuscarRucBasico_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapcha)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        public ControlesWinForm.SuperTextBox txtRuc;
        public ControlesWinForm.SuperTextBox txtCapcha;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.PictureBox pbCapcha;
        private System.Windows.Forms.Panel pnlAuditoria;
        public ControlesWinForm.SuperTextBox txtFecBaja;
        private System.Windows.Forms.Label label27;
        public ControlesWinForm.SuperTextBox txtRazon;
        private System.Windows.Forms.Label label22;
        public ControlesWinForm.SuperTextBox txtDni;
        public ControlesWinForm.SuperTextBox txtInicio;
        public ControlesWinForm.SuperTextBox txtEstado;
        public ControlesWinForm.SuperTextBox txtCondicion;
        public ControlesWinForm.SuperTextBox txtInscripcion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public ControlesWinForm.SuperTextBox txtNombreComercial;
        public ControlesWinForm.SuperTextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cboPadrones;
        private System.Windows.Forms.Label label16;
    }
}