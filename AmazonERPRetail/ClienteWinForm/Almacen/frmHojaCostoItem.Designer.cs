namespace ClienteWinForm.Ventas
{
    partial class frmHojaCostoItem
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
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label16;
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.txtidArticulo = new ControlesWinForm.SuperTextBox();
            this.btCredito = new System.Windows.Forms.Button();
            this.txtDesArticulo = new System.Windows.Forms.TextBox();
            this.txtVolumen = new ControlesWinForm.SuperTextBox();
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtPreciounit = new ControlesWinForm.SuperTextBox();
            this.txtPeso = new ControlesWinForm.SuperTextBox();
            this.txtAdValorem = new ControlesWinForm.SuperTextBox();
            this.txtFlete = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtTotalFob = new ControlesWinForm.SuperTextBox();
            this.txtCambio = new ControlesWinForm.SuperTextBox();
            this.txtTotalDol = new ControlesWinForm.SuperTextBox();
            this.txtPartBancel = new ControlesWinForm.SuperTextBox();
            this.label11 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(510, 18);
            this.lblTitPnlBase.Text = "Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(780, 25);
            this.lblTituloPrincipal.Text = "Hoja De Costo Item";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(752, 1);
            this.btCerrar.Visible = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(label10);
            this.pnlBase.Controls.Add(this.txtTotalDol);
            this.pnlBase.Controls.Add(label9);
            this.pnlBase.Controls.Add(this.txtCambio);
            this.pnlBase.Controls.Add(label8);
            this.pnlBase.Controls.Add(this.txtTotalFob);
            this.pnlBase.Controls.Add(this.txtFlete);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Controls.Add(this.txtAdValorem);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(label5);
            this.pnlBase.Controls.Add(this.txtPeso);
            this.pnlBase.Controls.Add(label4);
            this.pnlBase.Controls.Add(this.txtPreciounit);
            this.pnlBase.Controls.Add(label3);
            this.pnlBase.Controls.Add(this.txtCantidad);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.txtVolumen);
            this.pnlBase.Controls.Add(label16);
            this.pnlBase.Controls.Add(this.txtPartBancel);
            this.pnlBase.Controls.Add(this.btCredito);
            this.pnlBase.Controls.Add(this.txtidArticulo);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(label17);
            this.pnlBase.Controls.Add(this.cboNivel);
            this.pnlBase.Size = new System.Drawing.Size(512, 197);
            this.pnlBase.Controls.SetChildIndex(this.cboNivel, 0);
            this.pnlBase.Controls.SetChildIndex(label17, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtidArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.btCredito, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPartBancel, 0);
            this.pnlBase.Controls.SetChildIndex(label16, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtVolumen, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantidad, 0);
            this.pnlBase.Controls.SetChildIndex(label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPreciounit, 0);
            this.pnlBase.Controls.SetChildIndex(label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPeso, 0);
            this.pnlBase.Controls.SetChildIndex(label5, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtAdValorem, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtFlete, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTotalFob, 0);
            this.pnlBase.Controls.SetChildIndex(label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCambio, 0);
            this.pnlBase.Controls.SetChildIndex(label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTotalDol, 0);
            this.pnlBase.Controls.SetChildIndex(label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(395, 233);
            this.btCancelar.Size = new System.Drawing.Size(114, 29);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(271, 233);
            this.btAceptar.Size = new System.Drawing.Size(114, 29);
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label17.Location = new System.Drawing.Point(70, 32);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(30, 13);
            label17.TabIndex = 252;
            label17.Text = "Nivel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(57, 56);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 327;
            label1.Text = "Articulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(328, 103);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 386;
            label2.Text = "Volumen";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(50, 103);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(50, 13);
            label3.TabIndex = 388;
            label3.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(15, 125);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 390;
            label4.Text = "Precio Unit. FOB";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(198, 102);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(30, 13);
            label5.TabIndex = 392;
            label5.Text = "Peso";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(313, 177);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(62, 13);
            label6.TabIndex = 394;
            label6.Text = "Ad-Valorem";
            label6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(344, 154);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(31, 13);
            label7.TabIndex = 396;
            label7.Text = "Flete";
            label7.Visible = false;
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 99);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 76);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(104, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 30);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(86, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 53);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(198, 125);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 13);
            label8.TabIndex = 397;
            label8.Text = "Total Fob.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(50, 149);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(52, 13);
            label9.TabIndex = 399;
            label9.Text = "T.Cambio";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(198, 149);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(53, 13);
            label10.TabIndex = 401;
            label10.Text = "Total Dol.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(7, 79);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(93, 13);
            label16.TabIndex = 384;
            label16.Text = "Partida Bancelaria";
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(106, 29);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(87, 21);
            this.cboNivel.TabIndex = 251;
            // 
            // txtidArticulo
            // 
            this.txtidArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtidArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtidArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtidArticulo.Enabled = false;
            this.txtidArticulo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidArticulo.Location = new System.Drawing.Point(106, 53);
            this.txtidArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidArticulo.Name = "txtidArticulo";
            this.txtidArticulo.Size = new System.Drawing.Size(87, 20);
            this.txtidArticulo.TabIndex = 325;
            this.txtidArticulo.TabStop = false;
            this.txtidArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtidArticulo.TextoVacio = "<Descripcion>";
            // 
            // btCredito
            // 
            this.btCredito.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCredito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCredito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCredito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCredito.Location = new System.Drawing.Point(480, 54);
            this.btCredito.Name = "btCredito";
            this.btCredito.Size = new System.Drawing.Size(22, 18);
            this.btCredito.TabIndex = 328;
            this.btCredito.TabStop = false;
            this.btCredito.UseVisualStyleBackColor = true;
            this.btCredito.Click += new System.EventHandler(this.btCredito_Click);
            // 
            // txtDesArticulo
            // 
            this.txtDesArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesArticulo.Enabled = false;
            this.txtDesArticulo.Location = new System.Drawing.Point(196, 53);
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(283, 20);
            this.txtDesArticulo.TabIndex = 326;
            this.txtDesArticulo.TabStop = false;
            // 
            // txtVolumen
            // 
            this.txtVolumen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtVolumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtVolumen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtVolumen.Location = new System.Drawing.Point(381, 100);
            this.txtVolumen.Name = "txtVolumen";
            this.txtVolumen.ReadOnly = true;
            this.txtVolumen.Size = new System.Drawing.Size(87, 20);
            this.txtVolumen.TabIndex = 385;
            this.txtVolumen.Text = "0";
            this.txtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVolumen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtVolumen.TextoVacio = "<Descripcion>";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Location = new System.Drawing.Point(106, 99);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(87, 20);
            this.txtCantidad.TabIndex = 387;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // txtPreciounit
            // 
            this.txtPreciounit.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPreciounit.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPreciounit.Location = new System.Drawing.Point(106, 122);
            this.txtPreciounit.Name = "txtPreciounit";
            this.txtPreciounit.Size = new System.Drawing.Size(87, 20);
            this.txtPreciounit.TabIndex = 389;
            this.txtPreciounit.Text = "0";
            this.txtPreciounit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPreciounit.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPreciounit.TextoVacio = "<Descripcion>";
            this.txtPreciounit.TextChanged += new System.EventHandler(this.txtPreciounit_TextChanged);
            // 
            // txtPeso
            // 
            this.txtPeso.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPeso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtPeso.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPeso.Location = new System.Drawing.Point(235, 99);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.ReadOnly = true;
            this.txtPeso.Size = new System.Drawing.Size(87, 20);
            this.txtPeso.TabIndex = 391;
            this.txtPeso.Text = "0";
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeso.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPeso.TextoVacio = "<Descripcion>";
            // 
            // txtAdValorem
            // 
            this.txtAdValorem.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAdValorem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtAdValorem.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAdValorem.Enabled = false;
            this.txtAdValorem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdValorem.Location = new System.Drawing.Point(381, 173);
            this.txtAdValorem.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdValorem.Name = "txtAdValorem";
            this.txtAdValorem.Size = new System.Drawing.Size(87, 20);
            this.txtAdValorem.TabIndex = 393;
            this.txtAdValorem.TabStop = false;
            this.txtAdValorem.Text = "0";
            this.txtAdValorem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdValorem.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtAdValorem.TextoVacio = "<Descripcion>";
            this.txtAdValorem.Visible = false;
            // 
            // txtFlete
            // 
            this.txtFlete.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFlete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFlete.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFlete.Enabled = false;
            this.txtFlete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFlete.Location = new System.Drawing.Point(381, 149);
            this.txtFlete.Margin = new System.Windows.Forms.Padding(2);
            this.txtFlete.Name = "txtFlete";
            this.txtFlete.Size = new System.Drawing.Size(87, 20);
            this.txtFlete.TabIndex = 395;
            this.txtFlete.TabStop = false;
            this.txtFlete.Text = "0";
            this.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFlete.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtFlete.TextoVacio = "<Descripcion>";
            this.txtFlete.Visible = false;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label11);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(523, 31);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(252, 124);
            this.pnlAuditoria.TabIndex = 343;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(116, 95);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(123, 21);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(116, 26);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(123, 21);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(116, 72);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(123, 21);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(116, 49);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(123, 21);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // txtTotalFob
            // 
            this.txtTotalFob.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotalFob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTotalFob.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotalFob.Enabled = false;
            this.txtTotalFob.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFob.Location = new System.Drawing.Point(259, 122);
            this.txtTotalFob.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalFob.Name = "txtTotalFob";
            this.txtTotalFob.ReadOnly = true;
            this.txtTotalFob.Size = new System.Drawing.Size(63, 20);
            this.txtTotalFob.TabIndex = 394;
            this.txtTotalFob.TabStop = false;
            this.txtTotalFob.Text = "0";
            this.txtTotalFob.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalFob.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotalFob.TextoVacio = "<Descripcion>";
            // 
            // txtCambio
            // 
            this.txtCambio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCambio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCambio.Location = new System.Drawing.Point(106, 146);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(87, 20);
            this.txtCambio.TabIndex = 398;
            this.txtCambio.Text = "0";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCambio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCambio.TextoVacio = "<Descripcion>";
            this.txtCambio.Validating += new System.ComponentModel.CancelEventHandler(this.txtCambio_Validating);
            // 
            // txtTotalDol
            // 
            this.txtTotalDol.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotalDol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTotalDol.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotalDol.Enabled = false;
            this.txtTotalDol.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDol.Location = new System.Drawing.Point(259, 146);
            this.txtTotalDol.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalDol.Name = "txtTotalDol";
            this.txtTotalDol.ReadOnly = true;
            this.txtTotalDol.Size = new System.Drawing.Size(63, 20);
            this.txtTotalDol.TabIndex = 400;
            this.txtTotalDol.TabStop = false;
            this.txtTotalDol.Text = "0";
            this.txtTotalDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalDol.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotalDol.TextoVacio = "<Descripcion>";
            // 
            // txtPartBancel
            // 
            this.txtPartBancel.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPartBancel.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPartBancel.Location = new System.Drawing.Point(106, 76);
            this.txtPartBancel.Name = "txtPartBancel";
            this.txtPartBancel.Size = new System.Drawing.Size(87, 20);
            this.txtPartBancel.TabIndex = 383;
            this.txtPartBancel.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPartBancel.TextoVacio = "<Descripcion>";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 18);
            this.label11.TabIndex = 1587;
            this.label11.Text = "Auditoria";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHojaCostoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 270);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmHojaCostoItem";
            this.Text = "frmHojaCostoItem";
            this.Load += new System.EventHandler(this.frmHojaCostoItem_Load);
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

        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.Button btCredito;
        private ControlesWinForm.SuperTextBox txtidArticulo;
        private System.Windows.Forms.TextBox txtDesArticulo;
        private ControlesWinForm.SuperTextBox txtPeso;
        private ControlesWinForm.SuperTextBox txtPreciounit;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtVolumen;
        private ControlesWinForm.SuperTextBox txtFlete;
        private ControlesWinForm.SuperTextBox txtAdValorem;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private ControlesWinForm.SuperTextBox txtTotalFob;
        private ControlesWinForm.SuperTextBox txtCambio;
        private ControlesWinForm.SuperTextBox txtTotalDol;
        private ControlesWinForm.SuperTextBox txtPartBancel;
        private System.Windows.Forms.Label label11;
    }
}