﻿namespace ClienteWinForm.Ventas
{
    partial class frmDetallePorFacturaXEmision
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
            System.Windows.Forms.Label cantidadLabel;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label precioUnitarioLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label9;
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.txtPrecio = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.pnlComprobante = new System.Windows.Forms.Panel();
            this.chkCalculo = new System.Windows.Forms.CheckBox();
            this.chkIgv = new System.Windows.Forms.CheckBox();
            this.txtPorIgv = new ControlesWinForm.SuperTextBox();
            this.txtIgv = new ControlesWinForm.SuperTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new ControlesWinForm.SuperTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDscto3 = new ControlesWinForm.SuperTextBox();
            this.txtPor3 = new ControlesWinForm.SuperTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtValorVenta = new ControlesWinForm.SuperTextBox();
            this.txtDscto2 = new ControlesWinForm.SuperTextBox();
            this.txtPor2 = new ControlesWinForm.SuperTextBox();
            this.txtDscto1 = new ControlesWinForm.SuperTextBox();
            this.txtPor1 = new ControlesWinForm.SuperTextBox();
            this.txtSubTotal = new ControlesWinForm.SuperTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cboListaPrecio = new System.Windows.Forms.ComboBox();
            this.chkDetra = new System.Windows.Forms.CheckBox();
            this.txtTasa = new ControlesWinForm.SuperTextBox();
            this.txtTipDetra = new ControlesWinForm.SuperTextBox();
            this.txtCapacidad = new ControlesWinForm.SuperTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContenido = new ControlesWinForm.SuperTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlTallas = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            precioUnitarioLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlComprobante.SuspendLayout();
            this.pnlTallas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(496, 19);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(770, 25);
            this.lblTituloPrincipal.Text = "Linea Documento de Venta";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(741, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.txtContenido);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.txtCapacidad);
            this.pnlBase.Controls.Add(label8);
            this.pnlBase.Controls.Add(label10);
            this.pnlBase.Controls.Add(this.cboListaPrecio);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.cboAlmacen);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Location = new System.Drawing.Point(7, 29);
            this.pnlBase.Size = new System.Drawing.Size(498, 126);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboAlmacen, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboListaPrecio, 0);
            this.pnlBase.Controls.SetChildIndex(label10, 0);
            this.pnlBase.Controls.SetChildIndex(label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCapacidad, 0);
            this.pnlBase.Controls.SetChildIndex(this.label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtContenido, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(384, 378);
            this.btCancelar.Size = new System.Drawing.Size(116, 27);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(260, 378);
            this.btAceptar.Size = new System.Drawing.Size(116, 27);
            this.btAceptar.TabIndex = 15;
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantidadLabel.Location = new System.Drawing.Point(176, 33);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(50, 13);
            cantidadLabel.TabIndex = 261;
            cantidadLabel.Text = "Cantidad";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(11, 52);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(62, 13);
            idArticuloLabel.TabIndex = 262;
            idArticuloLabel.Text = "Código Art.";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.AutoSize = true;
            precioUnitarioLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            precioUnitarioLabel.Location = new System.Drawing.Point(32, 32);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(62, 13);
            precioUnitarioLabel.TabIndex = 267;
            precioUnitarioLabel.Text = "Precio Unit.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(7, 98);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(7, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(7, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(7, 54);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(244, 29);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(61, 13);
            label8.TabIndex = 350;
            label8.Text = "Lista Precio";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(11, 74);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(50, 13);
            label10.TabIndex = 280;
            label10.Text = "Producto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(12, 76);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(46, 13);
            label6.TabIndex = 283;
            label6.Text = "Pedido";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(12, 53);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(40, 13);
            label9.TabIndex = 281;
            label9.Text = "Stock";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(239, 28);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(77, 21);
            this.txtCantidad.TabIndex = 71;
            this.txtCantidad.Text = "0.0000";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCantidad_MouseClick);
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.Enter += new System.EventHandler(this.txtCantidad_Enter);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.White;
            this.txtCodArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.Location = new System.Drawing.Point(148, 48);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(95, 20);
            this.txtCodArticulo.TabIndex = 1;
            this.txtCodArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodArticulo.TextoVacio = "<Descripcion>";
            this.txtCodArticulo.TextChanged += new System.EventHandler(this.txtCodArticulo_TextChanged);
            this.txtCodArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodArticulo_Validating);
            // 
            // txtDesArticulo
            // 
            this.txtDesArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesArticulo.BackColor = System.Drawing.Color.White;
            this.txtDesArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesArticulo.Location = new System.Drawing.Point(93, 71);
            this.txtDesArticulo.Multiline = true;
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(392, 47);
            this.txtDesArticulo.TabIndex = 3;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            this.txtDesArticulo.TextChanged += new System.EventHandler(this.txtDesArticulo_TextChanged);
            this.txtDesArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesArticulo_Validating);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(95, 28);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(77, 21);
            this.txtPrecio.TabIndex = 70;
            this.txtPrecio.Text = "0.00000";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecio.TextoVacio = "<Descripcion>";
            this.txtPrecio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPrecio_MouseClick);
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.Enter += new System.EventHandler(this.txtPrecio_Enter);
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label13);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(507, 29);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(255, 126);
            this.pnlAuditoria.TabIndex = 257;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(112, 94);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(131, 21);
            this.txtFechaModifica.TabIndex = 304;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(112, 28);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(131, 21);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(112, 72);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(131, 21);
            this.txtUsuarioMod.TabIndex = 303;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(112, 50);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(131, 21);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Location = new System.Drawing.Point(245, 49);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(22, 19);
            this.btBuscarArticulo.TabIndex = 270;
            this.btBuscarArticulo.TabStop = false;
            this.btBuscarArticulo.UseVisualStyleBackColor = true;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(93, 48);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(54, 20);
            this.txtIdArticulo.TabIndex = 271;
            this.txtIdArticulo.TabStop = false;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 273;
            this.label2.Text = "Almacén";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(93, 25);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(150, 21);
            this.cboAlmacen.TabIndex = 1000;
            this.cboAlmacen.TabStop = false;
            // 
            // pnlComprobante
            // 
            this.pnlComprobante.BackColor = System.Drawing.Color.Transparent;
            this.pnlComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComprobante.Controls.Add(this.label15);
            this.pnlComprobante.Controls.Add(this.chkCalculo);
            this.pnlComprobante.Controls.Add(this.chkIgv);
            this.pnlComprobante.Controls.Add(this.txtPorIgv);
            this.pnlComprobante.Controls.Add(this.txtIgv);
            this.pnlComprobante.Controls.Add(this.label19);
            this.pnlComprobante.Controls.Add(this.label18);
            this.pnlComprobante.Controls.Add(this.txtPrecioVenta);
            this.pnlComprobante.Controls.Add(this.label21);
            this.pnlComprobante.Controls.Add(this.label22);
            this.pnlComprobante.Controls.Add(this.txtDscto3);
            this.pnlComprobante.Controls.Add(this.txtPor3);
            this.pnlComprobante.Controls.Add(this.txtCantidad);
            this.pnlComprobante.Controls.Add(this.label23);
            this.pnlComprobante.Controls.Add(this.label24);
            this.pnlComprobante.Controls.Add(this.txtPrecio);
            this.pnlComprobante.Controls.Add(this.txtValorVenta);
            this.pnlComprobante.Controls.Add(this.txtDscto2);
            this.pnlComprobante.Controls.Add(this.txtPor2);
            this.pnlComprobante.Controls.Add(this.txtDscto1);
            this.pnlComprobante.Controls.Add(this.txtPor1);
            this.pnlComprobante.Controls.Add(this.txtSubTotal);
            this.pnlComprobante.Controls.Add(this.label25);
            this.pnlComprobante.Controls.Add(precioUnitarioLabel);
            this.pnlComprobante.Controls.Add(cantidadLabel);
            this.pnlComprobante.Location = new System.Drawing.Point(7, 266);
            this.pnlComprobante.Name = "pnlComprobante";
            this.pnlComprobante.Size = new System.Drawing.Size(755, 107);
            this.pnlComprobante.TabIndex = 373;
            // 
            // chkCalculo
            // 
            this.chkCalculo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalculo.Checked = true;
            this.chkCalculo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalculo.Location = new System.Drawing.Point(321, 31);
            this.chkCalculo.Name = "chkCalculo";
            this.chkCalculo.Size = new System.Drawing.Size(114, 17);
            this.chkCalculo.TabIndex = 351;
            this.chkCalculo.TabStop = false;
            this.chkCalculo.Text = "Ingresa en Calculo";
            this.chkCalculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalculo.UseVisualStyleBackColor = true;
            // 
            // chkIgv
            // 
            this.chkIgv.Location = new System.Drawing.Point(607, 77);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(65, 17);
            this.chkIgv.TabIndex = 346;
            this.chkIgv.TabStop = false;
            this.chkIgv.Text = "I.G.V.";
            this.chkIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIgv.UseVisualStyleBackColor = true;
            this.chkIgv.CheckedChanged += new System.EventHandler(this.chkIgv_CheckedChanged);
            // 
            // txtPorIgv
            // 
            this.txtPorIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtPorIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorIgv.Enabled = false;
            this.txtPorIgv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorIgv.Location = new System.Drawing.Point(508, 74);
            this.txtPorIgv.Name = "txtPorIgv";
            this.txtPorIgv.Size = new System.Drawing.Size(37, 21);
            this.txtPorIgv.TabIndex = 11;
            this.txtPorIgv.TabStop = false;
            this.txtPorIgv.Text = "0.00";
            this.txtPorIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorIgv.TextoVacio = "<Descripcion>";
            this.txtPorIgv.TextChanged += new System.EventHandler(this.txtPorIgv_TextChanged);
            // 
            // txtIgv
            // 
            this.txtIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIgv.Enabled = false;
            this.txtIgv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIgv.Location = new System.Drawing.Point(547, 74);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(54, 21);
            this.txtIgv.TabIndex = 339;
            this.txtIgv.TabStop = false;
            this.txtIgv.Text = "0.00";
            this.txtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtIgv.TextoVacio = "<Descripcion>";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(460, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 340;
            this.label19.Text = "IGV    %";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(320, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 342;
            this.label18.Text = "Precio Vta.";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecioVenta.BackColor = System.Drawing.Color.White;
            this.txtPrecioVenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecioVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(380, 74);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(76, 21);
            this.txtPrecioVenta.TabIndex = 341;
            this.txtPrecioVenta.TabStop = false;
            this.txtPrecioVenta.Text = "0.00";
            this.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioVenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecioVenta.TextoVacio = "<Descripcion>";
            this.txtPrecioVenta.TextChanged += new System.EventHandler(this.txtPrecioVenta_TextChanged);
            this.txtPrecioVenta.Leave += new System.EventHandler(this.txtPrecioVenta_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(176, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 332;
            this.label21.Text = "Val. Venta";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(320, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 13);
            this.label22.TabIndex = 331;
            this.label22.Text = "% Dsct  3";
            // 
            // txtDscto3
            // 
            this.txtDscto3.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDscto3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDscto3.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDscto3.Enabled = false;
            this.txtDscto3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDscto3.Location = new System.Drawing.Point(419, 51);
            this.txtDscto3.Name = "txtDscto3";
            this.txtDscto3.Size = new System.Drawing.Size(38, 21);
            this.txtDscto3.TabIndex = 330;
            this.txtDscto3.TabStop = false;
            this.txtDscto3.Text = "0.00";
            this.txtDscto3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDscto3.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDscto3.TextoVacio = "<Descripcion>";
            // 
            // txtPor3
            // 
            this.txtPor3.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPor3.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPor3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPor3.Location = new System.Drawing.Point(380, 51);
            this.txtPor3.Name = "txtPor3";
            this.txtPor3.Size = new System.Drawing.Size(37, 21);
            this.txtPor3.TabIndex = 74;
            this.txtPor3.Text = "0.00";
            this.txtPor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPor3.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPor3.TextoVacio = "<Descripcion>";
            this.txtPor3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPor3_MouseClick);
            this.txtPor3.TextChanged += new System.EventHandler(this.txtPor3_TextChanged);
            this.txtPor3.Enter += new System.EventHandler(this.txtPor3_Enter);
            this.txtPor3.Leave += new System.EventHandler(this.txtPor3_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(176, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 328;
            this.label23.Text = "% Dsct  2";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(31, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 13);
            this.label24.TabIndex = 327;
            this.label24.Text = "% Dsct  1";
            // 
            // txtValorVenta
            // 
            this.txtValorVenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtValorVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtValorVenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtValorVenta.Enabled = false;
            this.txtValorVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorVenta.Location = new System.Drawing.Point(239, 74);
            this.txtValorVenta.Name = "txtValorVenta";
            this.txtValorVenta.Size = new System.Drawing.Size(76, 21);
            this.txtValorVenta.TabIndex = 322;
            this.txtValorVenta.TabStop = false;
            this.txtValorVenta.Text = "0.00";
            this.txtValorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorVenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtValorVenta.TextoVacio = "<Descripcion>";
            // 
            // txtDscto2
            // 
            this.txtDscto2.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDscto2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDscto2.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDscto2.Enabled = false;
            this.txtDscto2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDscto2.Location = new System.Drawing.Point(278, 51);
            this.txtDscto2.Name = "txtDscto2";
            this.txtDscto2.Size = new System.Drawing.Size(38, 21);
            this.txtDscto2.TabIndex = 319;
            this.txtDscto2.TabStop = false;
            this.txtDscto2.Text = "0.00";
            this.txtDscto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDscto2.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDscto2.TextoVacio = "<Descripcion>";
            // 
            // txtPor2
            // 
            this.txtPor2.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPor2.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPor2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPor2.Location = new System.Drawing.Point(239, 51);
            this.txtPor2.Name = "txtPor2";
            this.txtPor2.Size = new System.Drawing.Size(37, 21);
            this.txtPor2.TabIndex = 73;
            this.txtPor2.Text = "0.00";
            this.txtPor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPor2.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPor2.TextoVacio = "<Descripcion>";
            this.txtPor2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPor2_MouseClick);
            this.txtPor2.TextChanged += new System.EventHandler(this.txtPor2_TextChanged);
            this.txtPor2.Enter += new System.EventHandler(this.txtPor2_Enter);
            this.txtPor2.Leave += new System.EventHandler(this.txtPor2_Leave);
            // 
            // txtDscto1
            // 
            this.txtDscto1.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDscto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDscto1.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDscto1.Enabled = false;
            this.txtDscto1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDscto1.Location = new System.Drawing.Point(134, 51);
            this.txtDscto1.Name = "txtDscto1";
            this.txtDscto1.Size = new System.Drawing.Size(38, 21);
            this.txtDscto1.TabIndex = 317;
            this.txtDscto1.TabStop = false;
            this.txtDscto1.Text = "0.00";
            this.txtDscto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDscto1.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDscto1.TextoVacio = "<Descripcion>";
            // 
            // txtPor1
            // 
            this.txtPor1.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPor1.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPor1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPor1.Location = new System.Drawing.Point(95, 51);
            this.txtPor1.Name = "txtPor1";
            this.txtPor1.Size = new System.Drawing.Size(37, 21);
            this.txtPor1.TabIndex = 72;
            this.txtPor1.Text = "0.00";
            this.txtPor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPor1.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPor1.TextoVacio = "<Descripcion>";
            this.txtPor1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPor1_MouseClick);
            this.txtPor1.TextChanged += new System.EventHandler(this.txtPor1_TextChanged);
            this.txtPor1.Enter += new System.EventHandler(this.txtPor1_Enter);
            this.txtPor1.Leave += new System.EventHandler(this.txtPor1_Leave);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtSubTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(95, 74);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(76, 21);
            this.txtSubTotal.TabIndex = 315;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.Text = "0.00";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtSubTotal.TextoVacio = "<Descripcion>";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(31, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 13);
            this.label25.TabIndex = 314;
            this.label25.Text = "SubTotal";
            // 
            // cboListaPrecio
            // 
            this.cboListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPrecio.DropDownWidth = 260;
            this.cboListaPrecio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListaPrecio.FormattingEnabled = true;
            this.cboListaPrecio.Location = new System.Drawing.Point(306, 25);
            this.cboListaPrecio.Name = "cboListaPrecio";
            this.cboListaPrecio.Size = new System.Drawing.Size(179, 21);
            this.cboListaPrecio.TabIndex = 10001;
            this.cboListaPrecio.SelectionChangeCommitted += new System.EventHandler(this.cboListaPrecio_SelectionChangeCommitted);
            // 
            // chkDetra
            // 
            this.chkDetra.AutoSize = true;
            this.chkDetra.BackColor = System.Drawing.Color.Azure;
            this.chkDetra.Enabled = false;
            this.chkDetra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetra.Location = new System.Drawing.Point(14, 381);
            this.chkDetra.Name = "chkDetra";
            this.chkDetra.Size = new System.Drawing.Size(77, 17);
            this.chkDetra.TabIndex = 354;
            this.chkDetra.TabStop = false;
            this.chkDetra.Text = "Detracción";
            this.chkDetra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDetra.UseVisualStyleBackColor = false;
            // 
            // txtTasa
            // 
            this.txtTasa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTasa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTasa.Enabled = false;
            this.txtTasa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTasa.ForeColor = System.Drawing.Color.Black;
            this.txtTasa.Location = new System.Drawing.Point(146, 379);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(48, 21);
            this.txtTasa.TabIndex = 1001;
            this.txtTasa.TabStop = false;
            this.txtTasa.Text = "0.00";
            this.txtTasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTasa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTasa.TextoVacio = "<Descripcion>";
            // 
            // txtTipDetra
            // 
            this.txtTipDetra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipDetra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTipDetra.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipDetra.Enabled = false;
            this.txtTipDetra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipDetra.Location = new System.Drawing.Point(95, 379);
            this.txtTipDetra.Name = "txtTipDetra";
            this.txtTipDetra.Size = new System.Drawing.Size(48, 21);
            this.txtTipDetra.TabIndex = 1002;
            this.txtTipDetra.TabStop = false;
            this.txtTipDetra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtTipDetra.TextoVacio = "<Descripcion>";
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCapacidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCapacidad.Enabled = false;
            this.txtCapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidad.ForeColor = System.Drawing.Color.Black;
            this.txtCapacidad.Location = new System.Drawing.Point(329, 48);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(48, 20);
            this.txtCapacidad.TabIndex = 384;
            this.txtCapacidad.TabStop = false;
            this.txtCapacidad.Text = "0.00";
            this.txtCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapacidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCapacidad.TextoVacio = "<Descripcion>";
            this.txtCapacidad.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(270, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 385;
            this.label12.Text = "Capacidad";
            this.label12.Visible = false;
            // 
            // txtContenido
            // 
            this.txtContenido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtContenido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtContenido.Enabled = false;
            this.txtContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContenido.ForeColor = System.Drawing.Color.Black;
            this.txtContenido.Location = new System.Drawing.Point(437, 48);
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(48, 20);
            this.txtContenido.TabIndex = 386;
            this.txtContenido.TabStop = false;
            this.txtContenido.Text = "0.00";
            this.txtContenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContenido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtContenido.TextoVacio = "<Descripcion>";
            this.txtContenido.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(380, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 387;
            this.label11.Text = "Contenido";
            this.label11.Visible = false;
            // 
            // pnlTallas
            // 
            this.pnlTallas.BackColor = System.Drawing.Color.Transparent;
            this.pnlTallas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTallas.Controls.Add(this.label14);
            this.pnlTallas.Controls.Add(label6);
            this.pnlTallas.Controls.Add(this.label7);
            this.pnlTallas.Controls.Add(label9);
            this.pnlTallas.Location = new System.Drawing.Point(7, 157);
            this.pnlTallas.Name = "pnlTallas";
            this.pnlTallas.Size = new System.Drawing.Size(755, 107);
            this.pnlTallas.TabIndex = 1003;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 282;
            this.label7.Text = "Talla";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(253, 18);
            this.label13.TabIndex = 1571;
            this.label13.Text = "Auditoria";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(753, 18);
            this.label14.TabIndex = 1571;
            this.label14.Text = "Lista Registros";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(753, 18);
            this.label15.TabIndex = 1571;
            this.label15.Text = "Montos";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDetallePorFacturaXEmision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 419);
            this.Controls.Add(this.pnlTallas);
            this.Controls.Add(this.txtTipDetra);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.chkDetra);
            this.Controls.Add(this.pnlComprobante);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetallePorFacturaXEmision";
            this.Text = "frmDetallePedidoNacional";
            this.Load += new System.EventHandler(this.frmDetallePedidoNacional_Load);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.pnlComprobante, 0);
            this.Controls.SetChildIndex(this.chkDetra, 0);
            this.Controls.SetChildIndex(this.txtTasa, 0);
            this.Controls.SetChildIndex(this.txtTipDetra, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlTallas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlComprobante.ResumeLayout(false);
            this.pnlComprobante.PerformLayout();
            this.pnlTallas.ResumeLayout(false);
            this.pnlTallas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private ControlesWinForm.SuperTextBox txtPrecio;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Button btBuscarArticulo;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Panel pnlComprobante;
        private System.Windows.Forms.CheckBox chkIgv;
        private System.Windows.Forms.Label label18;
        private ControlesWinForm.SuperTextBox txtPrecioVenta;
        private System.Windows.Forms.Label label19;
        private ControlesWinForm.SuperTextBox txtIgv;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtDscto3;
        private ControlesWinForm.SuperTextBox txtPor3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private ControlesWinForm.SuperTextBox txtPorIgv;
        private ControlesWinForm.SuperTextBox txtValorVenta;
        private ControlesWinForm.SuperTextBox txtDscto2;
        private ControlesWinForm.SuperTextBox txtPor2;
        private ControlesWinForm.SuperTextBox txtDscto1;
        private ControlesWinForm.SuperTextBox txtPor1;
        private ControlesWinForm.SuperTextBox txtSubTotal;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboListaPrecio;
        private System.Windows.Forms.CheckBox chkCalculo;
        private System.Windows.Forms.CheckBox chkDetra;
        private ControlesWinForm.SuperTextBox txtTasa;
        private ControlesWinForm.SuperTextBox txtTipDetra;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtContenido;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtCapacidad;
        private System.Windows.Forms.Panel pnlTallas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}