namespace ClienteWinForm.Almacen
{
    partial class frmOperacion
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
            this.bsOperacion = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btSunat = new System.Windows.Forms.Button();
            this.cboTipoAlmacen = new System.Windows.Forms.ComboBox();
            this.txtOrd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodSunat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesDetalle = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesOperacion = new ControlesWinForm.SuperTextBox();
            this.txtIdOperacion = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCostoVenta = new System.Windows.Forms.CheckBox();
            this.chkReferencia = new System.Windows.Forms.CheckBox();
            this.chkDocumento = new System.Windows.Forms.CheckBox();
            this.chkDevolucion = new System.Windows.Forms.CheckBox();
            this.chkConversion = new System.Windows.Forms.CheckBox();
            this.chkOrden = new System.Windows.Forms.CheckBox();
            this.chkEstadistico = new System.Windows.Forms.CheckBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.chkProveedor = new System.Windows.Forms.CheckBox();
            this.chkDocTrans = new System.Windows.Forms.CheckBox();
            this.chkConsumo = new System.Windows.Forms.CheckBox();
            this.chkTransferencia = new System.Windows.Forms.CheckBox();
            this.chkOT = new System.Windows.Forms.CheckBox();
            this.chkAutomatico = new System.Windows.Forms.CheckBox();
            this.chkServicio = new System.Windows.Forms.CheckBox();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperacion)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsOperacion
            // 
            this.bsOperacion.DataSource = typeof(Entidades.Almacen.OperacionE);
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.lblLetras);
            this.pnlDatos.Controls.Add(this.btSunat);
            this.pnlDatos.Controls.Add(this.cboTipoAlmacen);
            this.pnlDatos.Controls.Add(this.txtOrd);
            this.pnlDatos.Controls.Add(this.label3);
            this.pnlDatos.Controls.Add(this.txtCodSunat);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.txtDesDetalle);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.txtDesOperacion);
            this.pnlDatos.Controls.Add(this.txtIdOperacion);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.cboTipoMovimiento);
            this.pnlDatos.Location = new System.Drawing.Point(4, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(430, 155);
            this.pnlDatos.TabIndex = 121;
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
            this.btSunat.Location = new System.Drawing.Point(290, 72);
            this.btSunat.Name = "btSunat";
            this.btSunat.Size = new System.Drawing.Size(22, 18);
            this.btSunat.TabIndex = 350;
            this.btSunat.TabStop = false;
            this.btSunat.UseVisualStyleBackColor = true;
            this.btSunat.Click += new System.EventHandler(this.btSunat_Click);
            // 
            // cboTipoAlmacen
            // 
            this.cboTipoAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAlmacen.DropDownWidth = 122;
            this.cboTipoAlmacen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoAlmacen.FormattingEnabled = true;
            this.cboTipoAlmacen.Location = new System.Drawing.Point(112, 27);
            this.cboTipoAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAlmacen.Name = "cboTipoAlmacen";
            this.cboTipoAlmacen.Size = new System.Drawing.Size(232, 21);
            this.cboTipoAlmacen.TabIndex = 297;
            // 
            // txtOrd
            // 
            this.txtOrd.Location = new System.Drawing.Point(354, 71);
            this.txtOrd.Name = "txtOrd";
            this.txtOrd.Size = new System.Drawing.Size(58, 20);
            this.txtOrd.TabIndex = 296;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 276;
            this.label3.Text = "Detalle";
            // 
            // txtCodSunat
            // 
            this.txtCodSunat.Location = new System.Drawing.Point(256, 71);
            this.txtCodSunat.Name = "txtCodSunat";
            this.txtCodSunat.Size = new System.Drawing.Size(33, 20);
            this.txtCodSunat.TabIndex = 295;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(320, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 277;
            this.label4.Text = "Orden";
            // 
            // txtDesDetalle
            // 
            this.txtDesDetalle.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesDetalle.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesDetalle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesDetalle.Location = new System.Drawing.Point(112, 113);
            this.txtDesDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesDetalle.Multiline = true;
            this.txtDesDetalle.Name = "txtDesDetalle";
            this.txtDesDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesDetalle.Size = new System.Drawing.Size(300, 32);
            this.txtDesDetalle.TabIndex = 275;
            this.txtDesDetalle.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloLetras;
            this.txtDesDetalle.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 274;
            this.label2.Text = "Código Sunat";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 273;
            this.label10.Text = "Código";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 272;
            this.label1.Text = "Nombre";
            // 
            // txtDesOperacion
            // 
            this.txtDesOperacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesOperacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesOperacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesOperacion.Location = new System.Drawing.Point(112, 92);
            this.txtDesOperacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesOperacion.Name = "txtDesOperacion";
            this.txtDesOperacion.Size = new System.Drawing.Size(300, 20);
            this.txtDesOperacion.TabIndex = 125;
            this.txtDesOperacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloLetras;
            this.txtDesOperacion.TextoVacio = "<Descripcion>";
            // 
            // txtIdOperacion
            // 
            this.txtIdOperacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdOperacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdOperacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdOperacion.Enabled = false;
            this.txtIdOperacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdOperacion.Location = new System.Drawing.Point(112, 71);
            this.txtIdOperacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdOperacion.Name = "txtIdOperacion";
            this.txtIdOperacion.Size = new System.Drawing.Size(65, 20);
            this.txtIdOperacion.TabIndex = 260;
            this.txtIdOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdOperacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdOperacion.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Tipo Articulo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Tipo Movimiento";
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimiento.DropDownWidth = 122;
            this.cboTipoMovimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoMovimiento.FormattingEnabled = true;
            this.cboTipoMovimiento.Location = new System.Drawing.Point(112, 49);
            this.cboTipoMovimiento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(232, 21);
            this.cboTipoMovimiento.TabIndex = 122;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chkCostoVenta);
            this.panel1.Controls.Add(this.chkReferencia);
            this.panel1.Controls.Add(this.chkDocumento);
            this.panel1.Controls.Add(this.chkDevolucion);
            this.panel1.Controls.Add(this.chkConversion);
            this.panel1.Controls.Add(this.chkOrden);
            this.panel1.Controls.Add(this.chkEstadistico);
            this.panel1.Controls.Add(this.chkCliente);
            this.panel1.Controls.Add(this.chkProveedor);
            this.panel1.Controls.Add(this.chkDocTrans);
            this.panel1.Controls.Add(this.chkConsumo);
            this.panel1.Controls.Add(this.chkTransferencia);
            this.panel1.Controls.Add(this.chkOT);
            this.panel1.Controls.Add(this.chkAutomatico);
            this.panel1.Controls.Add(this.chkServicio);
            this.panel1.Controls.Add(this.chkManual);
            this.panel1.Location = new System.Drawing.Point(4, 161);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 159);
            this.panel1.TabIndex = 122;
            // 
            // chkCostoVenta
            // 
            this.chkCostoVenta.AutoSize = true;
            this.chkCostoVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCostoVenta.Location = new System.Drawing.Point(35, 137);
            this.chkCostoVenta.Name = "chkCostoVenta";
            this.chkCostoVenta.Size = new System.Drawing.Size(99, 17);
            this.chkCostoVenta.TabIndex = 299;
            this.chkCostoVenta.Text = "Es Costo Venta";
            this.chkCostoVenta.UseVisualStyleBackColor = true;
            // 
            // chkReferencia
            // 
            this.chkReferencia.AutoSize = true;
            this.chkReferencia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReferencia.Location = new System.Drawing.Point(292, 114);
            this.chkReferencia.Name = "chkReferencia";
            this.chkReferencia.Size = new System.Drawing.Size(99, 17);
            this.chkReferencia.TabIndex = 298;
            this.chkReferencia.Text = "Ind. Referencia";
            this.chkReferencia.UseVisualStyleBackColor = true;
            // 
            // chkDocumento
            // 
            this.chkDocumento.AutoSize = true;
            this.chkDocumento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDocumento.Location = new System.Drawing.Point(165, 114);
            this.chkDocumento.Name = "chkDocumento";
            this.chkDocumento.Size = new System.Drawing.Size(102, 17);
            this.chkDocumento.TabIndex = 297;
            this.chkDocumento.Text = "Ind. Documento";
            this.chkDocumento.UseVisualStyleBackColor = true;
            // 
            // chkDevolucion
            // 
            this.chkDevolucion.AutoSize = true;
            this.chkDevolucion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDevolucion.Location = new System.Drawing.Point(54, 114);
            this.chkDevolucion.Name = "chkDevolucion";
            this.chkDevolucion.Size = new System.Drawing.Size(80, 17);
            this.chkDevolucion.TabIndex = 296;
            this.chkDevolucion.Text = "Devolución";
            this.chkDevolucion.UseVisualStyleBackColor = true;
            // 
            // chkConversion
            // 
            this.chkConversion.AutoSize = true;
            this.chkConversion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConversion.Location = new System.Drawing.Point(291, 91);
            this.chkConversion.Name = "chkConversion";
            this.chkConversion.Size = new System.Drawing.Size(100, 17);
            this.chkConversion.TabIndex = 295;
            this.chkConversion.Text = "Ind. Conversión";
            this.chkConversion.UseVisualStyleBackColor = true;
            // 
            // chkOrden
            // 
            this.chkOrden.AutoSize = true;
            this.chkOrden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOrden.Location = new System.Drawing.Point(297, 49);
            this.chkOrden.Name = "chkOrden";
            this.chkOrden.Size = new System.Drawing.Size(94, 17);
            this.chkOrden.TabIndex = 294;
            this.chkOrden.Text = "Ind.Ord.Comp.";
            this.chkOrden.UseVisualStyleBackColor = true;
            // 
            // chkEstadistico
            // 
            this.chkEstadistico.AutoSize = true;
            this.chkEstadistico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstadistico.Location = new System.Drawing.Point(296, 70);
            this.chkEstadistico.Name = "chkEstadistico";
            this.chkEstadistico.Size = new System.Drawing.Size(95, 17);
            this.chkEstadistico.TabIndex = 293;
            this.chkEstadistico.Text = "Ind.Estadistico";
            this.chkEstadistico.UseVisualStyleBackColor = true;
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCliente.Location = new System.Drawing.Point(315, 28);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(76, 17);
            this.chkCliente.TabIndex = 292;
            this.chkCliente.Text = "Ind.Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            // 
            // chkProveedor
            // 
            this.chkProveedor.AutoSize = true;
            this.chkProveedor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProveedor.Location = new System.Drawing.Point(171, 91);
            this.chkProveedor.Name = "chkProveedor";
            this.chkProveedor.Size = new System.Drawing.Size(96, 17);
            this.chkProveedor.TabIndex = 291;
            this.chkProveedor.Text = "Ind. Proveedor";
            this.chkProveedor.UseVisualStyleBackColor = true;
            // 
            // chkDocTrans
            // 
            this.chkDocTrans.AutoSize = true;
            this.chkDocTrans.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDocTrans.Location = new System.Drawing.Point(158, 70);
            this.chkDocTrans.Name = "chkDocTrans";
            this.chkDocTrans.Size = new System.Drawing.Size(109, 17);
            this.chkDocTrans.TabIndex = 290;
            this.chkDocTrans.Text = "Trans.Automatica";
            this.chkDocTrans.UseVisualStyleBackColor = true;
            // 
            // chkConsumo
            // 
            this.chkConsumo.AutoSize = true;
            this.chkConsumo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConsumo.Location = new System.Drawing.Point(49, 91);
            this.chkConsumo.Name = "chkConsumo";
            this.chkConsumo.Size = new System.Drawing.Size(85, 17);
            this.chkConsumo.TabIndex = 289;
            this.chkConsumo.Text = "Es Consumo";
            this.chkConsumo.UseVisualStyleBackColor = true;
            // 
            // chkTransferencia
            // 
            this.chkTransferencia.AutoSize = true;
            this.chkTransferencia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransferencia.Location = new System.Drawing.Point(161, 49);
            this.chkTransferencia.Name = "chkTransferencia";
            this.chkTransferencia.Size = new System.Drawing.Size(106, 17);
            this.chkTransferencia.TabIndex = 288;
            this.chkTransferencia.Text = "Es Transferencia";
            this.chkTransferencia.UseVisualStyleBackColor = true;
            // 
            // chkOT
            // 
            this.chkOT.AutoSize = true;
            this.chkOT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOT.Location = new System.Drawing.Point(40, 70);
            this.chkOT.Name = "chkOT";
            this.chkOT.Size = new System.Drawing.Size(94, 17);
            this.chkOT.TabIndex = 287;
            this.chkOT.Text = "Indicar Or.Tra.";
            this.chkOT.UseVisualStyleBackColor = true;
            // 
            // chkAutomatico
            // 
            this.chkAutomatico.AutoSize = true;
            this.chkAutomatico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutomatico.Location = new System.Drawing.Point(173, 28);
            this.chkAutomatico.Name = "chkAutomatico";
            this.chkAutomatico.Size = new System.Drawing.Size(94, 17);
            this.chkAutomatico.TabIndex = 286;
            this.chkAutomatico.Text = "Es Automatico";
            this.chkAutomatico.UseVisualStyleBackColor = true;
            // 
            // chkServicio
            // 
            this.chkServicio.AutoSize = true;
            this.chkServicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkServicio.Location = new System.Drawing.Point(38, 49);
            this.chkServicio.Name = "chkServicio";
            this.chkServicio.Size = new System.Drawing.Size(96, 17);
            this.chkServicio.TabIndex = 285;
            this.chkServicio.Text = "Ajuste al Costo";
            this.chkServicio.UseVisualStyleBackColor = true;
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkManual.Location = new System.Drawing.Point(30, 28);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(104, 17);
            this.chkManual.TabIndex = 284;
            this.chkManual.Text = "Valorizar Manual";
            this.chkManual.UseVisualStyleBackColor = true;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(109, 48);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(82, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(109, 26);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(82, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Usuario Modificación";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Usuario Registro";
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(291, 27);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(129, 20);
            this.txtRegistro.TabIndex = 0;
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(291, 49);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(129, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label7);
            this.pnlAuditoria.Controls.Add(this.label17);
            this.pnlAuditoria.Controls.Add(this.label15);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label14);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Controls.Add(this.label16);
            this.pnlAuditoria.Location = new System.Drawing.Point(4, 323);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(430, 79);
            this.pnlAuditoria.TabIndex = 123;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(193, 53);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 276;
            this.label17.Text = "Fecha Modificacion";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(193, 31);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 275;
            this.label15.Text = "Fecha Registro";
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(428, 18);
            this.lblLetras.TabIndex = 1579;
            this.lblLetras.Text = "Datos Principales";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(428, 18);
            this.label6.TabIndex = 1579;
            this.label6.Text = "Indicadores de Control";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(428, 18);
            this.label7.TabIndex = 1579;
            this.label7.Text = "Auditoria";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 403);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDatos);
            this.Name = "frmOperacion";
            this.Text = "Operaciones";
            this.Load += new System.EventHandler(this.frmOperacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsOperacion)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsOperacion;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtDesOperacion;
        private ControlesWinForm.SuperTextBox txtIdOperacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtDesDetalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkOrden;
        private System.Windows.Forms.CheckBox chkEstadistico;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.CheckBox chkProveedor;
        private System.Windows.Forms.CheckBox chkDocTrans;
        private System.Windows.Forms.CheckBox chkConsumo;
        private System.Windows.Forms.CheckBox chkTransferencia;
        private System.Windows.Forms.CheckBox chkOT;
        private System.Windows.Forms.CheckBox chkAutomatico;
        private System.Windows.Forms.CheckBox chkServicio;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrd;
        private System.Windows.Forms.TextBox txtCodSunat;
        private System.Windows.Forms.ComboBox cboTipoAlmacen;
        private System.Windows.Forms.CheckBox chkConversion;
        private System.Windows.Forms.Button btSunat;
        private System.Windows.Forms.CheckBox chkDevolucion;
        private System.Windows.Forms.CheckBox chkReferencia;
        private System.Windows.Forms.CheckBox chkDocumento;
        private System.Windows.Forms.CheckBox chkCostoVenta;
        private System.Windows.Forms.Label lblLetras;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}