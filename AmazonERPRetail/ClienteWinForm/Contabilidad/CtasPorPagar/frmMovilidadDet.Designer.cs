namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmMovilidadDet
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
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMotivo = new ControlesWinForm.SuperTextBox();
            this.txtMonto = new ControlesWinForm.SuperTextBox();
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.btCentroC = new System.Windows.Forms.Button();
            this.txtDesCCostos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesplazamiento = new ControlesWinForm.SuperTextBox();
            this.txtGastoAceptado = new ControlesWinForm.SuperTextBox();
            this.txtGastoReparado = new ControlesWinForm.SuperTextBox();
            this.chkReparable = new System.Windows.Forms.CheckBox();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
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
            this.btCancelar.Location = new System.Drawing.Point(576, 167);
            this.btCancelar.Size = new System.Drawing.Size(112, 26);
            this.btCancelar.TabIndex = 6;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(452, 167);
            this.btAceptar.Size = new System.Drawing.Size(112, 26);
            this.btAceptar.TabIndex = 5;
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(427, 22);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(705, 25);
            this.lblTituloPrincipal.Text = "Movilidad Detalle";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(676, 2);
            this.btCerrar.TabStop = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Controls.Add(this.txtGastoReparado);
            this.pnlBase.Controls.Add(label5);
            this.pnlBase.Controls.Add(this.txtGastoAceptado);
            this.pnlBase.Controls.Add(this.txtMotivo);
            this.pnlBase.Controls.Add(label3);
            this.pnlBase.Controls.Add(this.txtDesplazamiento);
            this.pnlBase.Controls.Add(this.txtCCostos);
            this.pnlBase.Controls.Add(this.btCentroC);
            this.pnlBase.Controls.Add(this.txtDesCCostos);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(label4);
            this.pnlBase.Controls.Add(this.txtMonto);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.dtpFecha);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(429, 176);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecha, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMonto, 0);
            this.pnlBase.Controls.SetChildIndex(label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesCCostos, 0);
            this.pnlBase.Controls.SetChildIndex(this.btCentroC, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCCostos, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesplazamiento, 0);
            this.pnlBase.Controls.SetChildIndex(label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMotivo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtGastoAceptado, 0);
            this.pnlBase.Controls.SetChildIndex(label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtGastoReparado, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(9, 93);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(100, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificación";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(9, 73);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(106, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificación";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label26.Location = new System.Drawing.Point(9, 33);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(85, 13);
            label26.TabIndex = 0;
            label26.Text = "Usuario Registro";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.Location = new System.Drawing.Point(9, 53);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(79, 13);
            label27.TabIndex = 2;
            label27.Text = "Fecha Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(7, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 13);
            label2.TabIndex = 429;
            label2.Text = "Fecha";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(7, 120);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(63, 13);
            label6.TabIndex = 437;
            label6.Text = "Descripción";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(7, 150);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 13);
            label4.TabIndex = 439;
            label4.Text = "Monto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(7, 84);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 13);
            label3.TabIndex = 1506;
            label3.Text = "Desplazam.";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label24);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label25);
            this.pnlAuditoria.Controls.Add(label26);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label27);
            this.pnlAuditoria.Location = new System.Drawing.Point(439, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(260, 120);
            this.pnlAuditoria.TabIndex = 362;
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
            this.labelDegradado4.Size = new System.Drawing.Size(258, 20);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(114, 88);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(134, 20);
            this.txtFechaModificacion.TabIndex = 304;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 28);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(134, 20);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 68);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(134, 20);
            this.txtUsuarioModificacion.TabIndex = 303;
            this.txtUsuarioModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 48);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(134, 20);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(69, 29);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(82, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMotivo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(69, 110);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(350, 33);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMotivo.TextoVacio = "<Descripcion>";
            // 
            // txtMonto
            // 
            this.txtMonto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMonto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(69, 146);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(82, 20);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMonto.TextoVacio = "<Descripcion>";
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Enabled = false;
            this.txtCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCostos.Location = new System.Drawing.Point(69, 52);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(82, 20);
            this.txtCCostos.TabIndex = 1502;
            this.txtCCostos.TabStop = false;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            // 
            // btCentroC
            // 
            this.btCentroC.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCentroC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCentroC.Enabled = false;
            this.btCentroC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCentroC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCentroC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCentroC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCentroC.Location = new System.Drawing.Point(397, 53);
            this.btCentroC.Name = "btCentroC";
            this.btCentroC.Size = new System.Drawing.Size(22, 18);
            this.btCentroC.TabIndex = 1504;
            this.btCentroC.TabStop = false;
            this.btCentroC.UseVisualStyleBackColor = true;
            this.btCentroC.Click += new System.EventHandler(this.btCentroC_Click);
            // 
            // txtDesCCostos
            // 
            this.txtDesCCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCCostos.Enabled = false;
            this.txtDesCCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCCostos.Location = new System.Drawing.Point(153, 52);
            this.txtDesCCostos.Name = "txtDesCCostos";
            this.txtDesCCostos.ReadOnly = true;
            this.txtDesCCostos.Size = new System.Drawing.Size(242, 20);
            this.txtDesCCostos.TabIndex = 1501;
            this.txtDesCCostos.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1503;
            this.label1.Text = "C. Costos";
            // 
            // txtDesplazamiento
            // 
            this.txtDesplazamiento.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesplazamiento.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesplazamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesplazamiento.Location = new System.Drawing.Point(69, 74);
            this.txtDesplazamiento.Multiline = true;
            this.txtDesplazamiento.Name = "txtDesplazamiento";
            this.txtDesplazamiento.Size = new System.Drawing.Size(350, 33);
            this.txtDesplazamiento.TabIndex = 2;
            this.txtDesplazamiento.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesplazamiento.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(156, 150);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 13);
            label5.TabIndex = 1508;
            label5.Text = "Aceptado";
            // 
            // txtGastoAceptado
            // 
            this.txtGastoAceptado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGastoAceptado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGastoAceptado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGastoAceptado.Enabled = false;
            this.txtGastoAceptado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastoAceptado.Location = new System.Drawing.Point(212, 146);
            this.txtGastoAceptado.Name = "txtGastoAceptado";
            this.txtGastoAceptado.Size = new System.Drawing.Size(71, 20);
            this.txtGastoAceptado.TabIndex = 1507;
            this.txtGastoAceptado.Text = "0.00";
            this.txtGastoAceptado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastoAceptado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtGastoAceptado.TextoVacio = "<Descripcion>";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(290, 150);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 13);
            label7.TabIndex = 1510;
            label7.Text = "Reparado";
            // 
            // txtGastoReparado
            // 
            this.txtGastoReparado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGastoReparado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGastoReparado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGastoReparado.Enabled = false;
            this.txtGastoReparado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastoReparado.Location = new System.Drawing.Point(348, 146);
            this.txtGastoReparado.Name = "txtGastoReparado";
            this.txtGastoReparado.Size = new System.Drawing.Size(71, 20);
            this.txtGastoReparado.TabIndex = 1509;
            this.txtGastoReparado.Text = "0.00";
            this.txtGastoReparado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastoReparado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtGastoReparado.TextoVacio = "<Descripcion>";
            // 
            // chkReparable
            // 
            this.chkReparable.AutoSize = true;
            this.chkReparable.Location = new System.Drawing.Point(439, 149);
            this.chkReparable.Name = "chkReparable";
            this.chkReparable.Size = new System.Drawing.Size(90, 17);
            this.chkReparable.TabIndex = 363;
            this.chkReparable.Text = "Es Reparable";
            this.chkReparable.UseVisualStyleBackColor = true;
            this.chkReparable.Visible = false;
            // 
            // frmMovilidadDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 209);
            this.Controls.Add(this.chkReparable);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmMovilidadDet";
            this.Text = "frmMovilidadDet";
            this.Load += new System.EventHandler(this.frmMovilidadDet_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.chkReparable, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ControlesWinForm.SuperTextBox txtMotivo;
        private ControlesWinForm.SuperTextBox txtMonto;
        private ControlesWinForm.SuperTextBox txtDesplazamiento;
        private ControlesWinForm.SuperTextBox txtCCostos;
        private System.Windows.Forms.Button btCentroC;
        private System.Windows.Forms.TextBox txtDesCCostos;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtGastoReparado;
        private ControlesWinForm.SuperTextBox txtGastoAceptado;
        private System.Windows.Forms.CheckBox chkReparable;
    }
}