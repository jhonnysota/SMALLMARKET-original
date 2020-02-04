namespace ClienteWinForm.Maestros
{
    partial class frmBancoCuenta
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
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.chbBaja = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtforCheque = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtnumCheque = new ControlesWinForm.SuperTextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnumCuenta = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtcodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtInicio = new ControlesWinForm.SuperTextBox();
            this.txtFin = new ControlesWinForm.SuperTextBox();
            this.btProveedor = new System.Windows.Forms.Button();
            this.chkDocumentos = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCtaInter = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(402, 18);
            this.lblTitPnlBase.Text = "Datos Cuenta Banco";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(690, 25);
            this.lblTituloPrincipal.Text = "Cuenta Banco";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(662, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.txtCtaInter);
            this.pnlBase.Controls.Add(this.chkDocumentos);
            this.pnlBase.Controls.Add(this.btProveedor);
            this.pnlBase.Controls.Add(this.txtFin);
            this.pnlBase.Controls.Add(this.txtInicio);
            this.pnlBase.Controls.Add(this.chbBaja);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.txtforCheque);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.txtnumCheque);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txtnumCuenta);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.cboTipo);
            this.pnlBase.Controls.Add(this.txtcodCuenta);
            this.pnlBase.Controls.Add(this.txtDesCuenta);
            this.pnlBase.Controls.Add(this.label21);
            this.pnlBase.Location = new System.Drawing.Point(8, 29);
            this.pnlBase.Size = new System.Drawing.Size(404, 212);
            this.pnlBase.Controls.SetChildIndex(this.label21, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesCuenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtcodCuenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboTipo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtnumCuenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtnumCheque, 0);
            this.pnlBase.Controls.SetChildIndex(this.label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtforCheque, 0);
            this.pnlBase.Controls.SetChildIndex(this.label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.chbBaja, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtInicio, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFin, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.btProveedor, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkDocumentos, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCtaInter, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(553, 187);
            this.btCancelar.Size = new System.Drawing.Size(116, 26);
            this.btCancelar.TabIndex = 1;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(429, 187);
            this.btAceptar.Size = new System.Drawing.Size(116, 26);
            this.btAceptar.TabIndex = 0;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label9);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistro);
            this.pnlAuditoria.Controls.Add(this.txtUsuModificacion);
            this.pnlAuditoria.Location = new System.Drawing.Point(415, 29);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 133);
            this.pnlAuditoria.TabIndex = 105;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(11, 100);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(118, 96);
            this.txtFechaModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(135, 20);
            this.txtFechaModificacion.TabIndex = 0;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(118, 53);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(135, 20);
            this.txtFechaRegistro.TabIndex = 0;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(118, 32);
            this.txtUsuRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(135, 20);
            this.txtUsuRegistro.TabIndex = 0;
            this.txtUsuRegistro.TabStop = false;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(118, 75);
            this.txtUsuModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(135, 20);
            this.txtUsuModificacion.TabIndex = 0;
            this.txtUsuModificacion.TabStop = false;
            // 
            // chbBaja
            // 
            this.chbBaja.AutoSize = true;
            this.chbBaja.Enabled = false;
            this.chbBaja.Location = new System.Drawing.Point(338, 187);
            this.chbBaja.Name = "chbBaja";
            this.chbBaja.Size = new System.Drawing.Size(47, 17);
            this.chbBaja.TabIndex = 6;
            this.chbBaja.TabStop = false;
            this.chbBaja.Text = "Baja";
            this.chbBaja.UseVisualStyleBackColor = true;
            this.chbBaja.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 144);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 370;
            this.label10.Text = "Formato";
            // 
            // txtforCheque
            // 
            this.txtforCheque.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtforCheque.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtforCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtforCheque.Location = new System.Drawing.Point(81, 140);
            this.txtforCheque.Margin = new System.Windows.Forms.Padding(2);
            this.txtforCheque.Name = "txtforCheque";
            this.txtforCheque.Size = new System.Drawing.Size(307, 20);
            this.txtforCheque.TabIndex = 8;
            this.txtforCheque.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtforCheque.TextoVacio = "<Descripcion>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 364;
            this.label7.Text = "Nº Cheque";
            // 
            // txtnumCheque
            // 
            this.txtnumCheque.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtnumCheque.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtnumCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumCheque.Location = new System.Drawing.Point(81, 96);
            this.txtnumCheque.Margin = new System.Windows.Forms.Padding(2);
            this.txtnumCheque.Name = "txtnumCheque";
            this.txtnumCheque.Size = new System.Drawing.Size(307, 20);
            this.txtnumCheque.TabIndex = 5;
            this.txtnumCheque.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtnumCheque.TextoVacio = "<Descripcion>";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(265, 29);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(122, 21);
            this.cboMoneda.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(216, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 361;
            this.label6.Text = "Moneda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 360;
            this.label1.Text = "Nº Cuenta";
            // 
            // txtnumCuenta
            // 
            this.txtnumCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtnumCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtnumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumCuenta.Location = new System.Drawing.Point(81, 52);
            this.txtnumCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtnumCuenta.Name = "txtnumCuenta";
            this.txtnumCuenta.Size = new System.Drawing.Size(307, 20);
            this.txtnumCuenta.TabIndex = 3;
            this.txtnumCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtnumCuenta.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 358;
            this.label5.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "AHORROS DOLARES",
            "CTA CTE DOLARES",
            "CTA CTE SOLES",
            "AHORRO SOLES"});
            this.cboTipo.Location = new System.Drawing.Point(81, 29);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(131, 21);
            this.cboTipo.TabIndex = 1;
            // 
            // txtcodCuenta
            // 
            this.txtcodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtcodCuenta.BackColor = System.Drawing.Color.White;
            this.txtcodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtcodCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodCuenta.Location = new System.Drawing.Point(81, 162);
            this.txtcodCuenta.Name = "txtcodCuenta";
            this.txtcodCuenta.Size = new System.Drawing.Size(69, 20);
            this.txtcodCuenta.TabIndex = 9;
            this.txtcodCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtcodCuenta.TextoVacio = "<Descripcion>";
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesCuenta.Enabled = false;
            this.txtDesCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuenta.Location = new System.Drawing.Point(152, 162);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(208, 20);
            this.txtDesCuenta.TabIndex = 355;
            this.txtDesCuenta.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 166);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 354;
            this.label21.Text = "Cuenta";
            // 
            // txtInicio
            // 
            this.txtInicio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtInicio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Location = new System.Drawing.Point(81, 118);
            this.txtInicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(153, 20);
            this.txtInicio.TabIndex = 6;
            this.txtInicio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtInicio.TextoVacio = "N° Cheque Inicial";
            // 
            // txtFin
            // 
            this.txtFin.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtFin.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFin.Location = new System.Drawing.Point(236, 118);
            this.txtFin.Margin = new System.Windows.Forms.Padding(2);
            this.txtFin.Name = "txtFin";
            this.txtFin.Size = new System.Drawing.Size(151, 20);
            this.txtFin.TabIndex = 7;
            this.txtFin.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtFin.TextoVacio = "N° Cheque Final";
            // 
            // btProveedor
            // 
            this.btProveedor.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btProveedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedor.Location = new System.Drawing.Point(363, 162);
            this.btProveedor.Name = "btProveedor";
            this.btProveedor.Size = new System.Drawing.Size(24, 20);
            this.btProveedor.TabIndex = 373;
            this.btProveedor.TabStop = false;
            this.btProveedor.UseVisualStyleBackColor = true;
            this.btProveedor.Click += new System.EventHandler(this.btCuenta_Click);
            // 
            // chkDocumentos
            // 
            this.chkDocumentos.AutoSize = true;
            this.chkDocumentos.Location = new System.Drawing.Point(82, 187);
            this.chkDocumentos.Name = "chkDocumentos";
            this.chkDocumentos.Size = new System.Drawing.Size(123, 17);
            this.chkDocumentos.TabIndex = 10;
            this.chkDocumentos.Text = "Uso en Documentos";
            this.chkDocumentos.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 375;
            this.label8.Text = "Nº Cta. Inter.";
            // 
            // txtCtaInter
            // 
            this.txtCtaInter.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaInter.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaInter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaInter.Location = new System.Drawing.Point(81, 74);
            this.txtCtaInter.Margin = new System.Windows.Forms.Padding(2);
            this.txtCtaInter.Name = "txtCtaInter";
            this.txtCtaInter.Size = new System.Drawing.Size(307, 20);
            this.txtCtaInter.TabIndex = 4;
            this.txtCtaInter.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaInter.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 18);
            this.label9.TabIndex = 347;
            this.label9.Text = "Auditoria";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBancoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 246);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmBancoCuenta";
            this.Text = "Cuenta Banco";
            this.Load += new System.EventHandler(this.frmBancoCuenta_Load);
            this.Shown += new System.EventHandler(this.frmBancoCuenta_Shown);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.CheckBox chbBaja;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txtforCheque;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtnumCheque;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtnumCuenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipo;
        private ControlesWinForm.SuperTextBox txtcodCuenta;
        private System.Windows.Forms.TextBox txtDesCuenta;
        private System.Windows.Forms.Label label21;
        private ControlesWinForm.SuperTextBox txtFin;
        private ControlesWinForm.SuperTextBox txtInicio;
        private System.Windows.Forms.Button btProveedor;
        private System.Windows.Forms.CheckBox chkDocumentos;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtCtaInter;
        private System.Windows.Forms.Label label9;
    }
}