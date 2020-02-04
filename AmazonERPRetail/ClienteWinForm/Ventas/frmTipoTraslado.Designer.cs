namespace ClienteWinForm.Ventas
{
    partial class frmTipoTraslado
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.CODNiv = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAlm = new System.Windows.Forms.CheckBox();
            this.chkVen = new System.Windows.Forms.CheckBox();
            this.chkCuenta = new System.Windows.Forms.CheckBox();
            this.chkFactura = new System.Windows.Forms.CheckBox();
            this.txtIdTraslado = new ControlesWinForm.SuperTextBox();
            this.txtDes = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSunat = new ControlesWinForm.SuperTextBox();
            this.txtCod = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEsta = new System.Windows.Forms.CheckBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSunat = new System.Windows.Forms.Button();
            this.txtCodOperacion = new ControlesWinForm.SuperTextBox();
            this.txtDesOperacion = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CODNiv)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.CODNiv);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.chkAlm);
            this.pnlDatos.Controls.Add(this.chkVen);
            this.pnlDatos.Controls.Add(this.chkCuenta);
            this.pnlDatos.Controls.Add(this.chkFactura);
            this.pnlDatos.Controls.Add(this.txtIdTraslado);
            this.pnlDatos.Controls.Add(this.txtDes);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.txtSunat);
            this.pnlDatos.Controls.Add(this.txtCod);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(301, 141);
            this.pnlDatos.TabIndex = 133;
            // 
            // CODNiv
            // 
            this.CODNiv.Location = new System.Drawing.Point(195, 115);
            this.CODNiv.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.CODNiv.Name = "CODNiv";
            this.CODNiv.Size = new System.Drawing.Size(44, 20);
            this.CODNiv.TabIndex = 294;
            this.CODNiv.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 292;
            this.label1.Text = "Codigo Formato";
            // 
            // chkAlm
            // 
            this.chkAlm.AutoSize = true;
            this.chkAlm.Location = new System.Drawing.Point(13, 117);
            this.chkAlm.Name = "chkAlm";
            this.chkAlm.Size = new System.Drawing.Size(67, 17);
            this.chkAlm.TabIndex = 290;
            this.chkAlm.Text = "Almacen";
            this.chkAlm.UseVisualStyleBackColor = true;
            // 
            // chkVen
            // 
            this.chkVen.AutoSize = true;
            this.chkVen.Location = new System.Drawing.Point(207, 94);
            this.chkVen.Name = "chkVen";
            this.chkVen.Size = new System.Drawing.Size(84, 17);
            this.chkVen.TabIndex = 289;
            this.chkVen.Text = "Cero Ventas";
            this.chkVen.UseVisualStyleBackColor = true;
            // 
            // chkCuenta
            // 
            this.chkCuenta.AutoSize = true;
            this.chkCuenta.Location = new System.Drawing.Point(90, 94);
            this.chkCuenta.Name = "chkCuenta";
            this.chkCuenta.Size = new System.Drawing.Size(105, 17);
            this.chkCuenta.TabIndex = 288;
            this.chkCuenta.Text = "Cuenta Corriente";
            this.chkCuenta.UseVisualStyleBackColor = true;
            // 
            // chkFactura
            // 
            this.chkFactura.AutoSize = true;
            this.chkFactura.Location = new System.Drawing.Point(13, 94);
            this.chkFactura.Name = "chkFactura";
            this.chkFactura.Size = new System.Drawing.Size(62, 17);
            this.chkFactura.TabIndex = 287;
            this.chkFactura.Text = "Factura";
            this.chkFactura.UseVisualStyleBackColor = true;
            // 
            // txtIdTraslado
            // 
            this.txtIdTraslado.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdTraslado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdTraslado.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdTraslado.Enabled = false;
            this.txtIdTraslado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTraslado.Location = new System.Drawing.Point(104, 23);
            this.txtIdTraslado.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdTraslado.Name = "txtIdTraslado";
            this.txtIdTraslado.Size = new System.Drawing.Size(68, 20);
            this.txtIdTraslado.TabIndex = 283;
            this.txtIdTraslado.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdTraslado.TextoVacio = "<Descripcion>";
            // 
            // txtDes
            // 
            this.txtDes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDes.BackColor = System.Drawing.Color.White;
            this.txtDes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.Location = new System.Drawing.Point(104, 45);
            this.txtDes.Margin = new System.Windows.Forms.Padding(2);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(167, 20);
            this.txtDes.TabIndex = 282;
            this.txtDes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDes.TextoVacio = "<Descripcion>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 281;
            this.label7.Text = "Descripción";
            // 
            // txtSunat
            // 
            this.txtSunat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSunat.BackColor = System.Drawing.Color.White;
            this.txtSunat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSunat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSunat.Location = new System.Drawing.Point(104, 67);
            this.txtSunat.Margin = new System.Windows.Forms.Padding(2);
            this.txtSunat.Name = "txtSunat";
            this.txtSunat.Size = new System.Drawing.Size(68, 20);
            this.txtSunat.TabIndex = 273;
            this.txtSunat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSunat.TextoVacio = "<Descripcion>";
            // 
            // txtCod
            // 
            this.txtCod.AutoSize = true;
            this.txtCod.Location = new System.Drawing.Point(15, 70);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(71, 13);
            this.txtCod.TabIndex = 272;
            this.txtCod.Text = "Codigo Sunat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Id Traslado";
            // 
            // chkEsta
            // 
            this.chkEsta.AutoSize = true;
            this.chkEsta.Enabled = false;
            this.chkEsta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsta.Location = new System.Drawing.Point(311, 124);
            this.chkEsta.Name = "chkEsta";
            this.chkEsta.Size = new System.Drawing.Size(71, 17);
            this.chkEsta.TabIndex = 291;
            this.chkEsta.Text = "ACTIVO";
            this.chkEsta.UseVisualStyleBackColor = true;
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
            this.pnlAuditoria.Location = new System.Drawing.Point(306, 3);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(270, 116);
            this.pnlAuditoria.TabIndex = 132;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(12, 91);
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
            this.txtModifica.Location = new System.Drawing.Point(119, 87);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(134, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(119, 45);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(134, 20);
            this.txtRegistro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 28);
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
            this.label3.Location = new System.Drawing.Point(12, 49);
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
            this.label4.Location = new System.Drawing.Point(12, 70);
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
            this.txtUsuRegistra.Location = new System.Drawing.Point(119, 24);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(134, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(119, 66);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(134, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btSunat);
            this.panel1.Controls.Add(this.txtCodOperacion);
            this.panel1.Controls.Add(this.txtDesOperacion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(3, 146);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 52);
            this.panel1.TabIndex = 134;
            // 
            // btSunat
            // 
            this.btSunat.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btSunat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSunat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btSunat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btSunat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btSunat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSunat.Location = new System.Drawing.Point(534, 24);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(22, 19);
            this.btSunat.TabIndex = 351;
            this.btSunat.TabStop = false;
            this.btSunat.UseVisualStyleBackColor = true;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // txtCodOperacion
            // 
            this.txtCodOperacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodOperacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodOperacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodOperacion.Enabled = false;
            this.txtCodOperacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodOperacion.Location = new System.Drawing.Point(131, 23);
            this.txtCodOperacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodOperacion.Name = "txtCodOperacion";
            this.txtCodOperacion.Size = new System.Drawing.Size(31, 21);
            this.txtCodOperacion.TabIndex = 283;
            this.txtCodOperacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodOperacion.TextoVacio = "<Descripcion>";
            // 
            // txtDesOperacion
            // 
            this.txtDesOperacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesOperacion.BackColor = System.Drawing.Color.White;
            this.txtDesOperacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesOperacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesOperacion.Location = new System.Drawing.Point(229, 23);
            this.txtDesOperacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesOperacion.Name = "txtDesOperacion";
            this.txtDesOperacion.Size = new System.Drawing.Size(303, 21);
            this.txtDesOperacion.TabIndex = 282;
            this.txtDesOperacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesOperacion.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 281;
            this.label6.Text = "Descripción";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "Cód. Sunat Operación";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 18);
            this.label5.TabIndex = 295;
            this.label5.Text = "Principales";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 18);
            this.label9.TabIndex = 296;
            this.label9.Text = "Auditoria";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(572, 18);
            this.label11.TabIndex = 352;
            this.label11.Text = "Datos Almacén";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTipoTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(579, 199);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.chkEsta);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmTipoTraslado";
            this.Text = "Tipo de Traslados";
            this.Load += new System.EventHandler(this.frmTipoTraslado_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CODNiv)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtIdTraslado;
        private ControlesWinForm.SuperTextBox txtDes;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtSunat;
        private System.Windows.Forms.Label txtCod;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.CheckBox chkEsta;
        private System.Windows.Forms.CheckBox chkAlm;
        private System.Windows.Forms.CheckBox chkVen;
        private System.Windows.Forms.CheckBox chkCuenta;
        private System.Windows.Forms.CheckBox chkFactura;
        private System.Windows.Forms.NumericUpDown CODNiv;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtCodOperacion;
        private ControlesWinForm.SuperTextBox txtDesOperacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btSunat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}