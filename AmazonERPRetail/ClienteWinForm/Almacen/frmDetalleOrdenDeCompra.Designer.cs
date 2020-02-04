namespace ClienteWinForm.Almacen
{
    partial class frmDetalleOrdenDeCompra
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantOrdenada = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.txtNroCompra = new System.Windows.Forms.TextBox();
            this.txtNumItem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEspecificacion = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPorDscto = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUltimaCompra = new ControlesWinForm.SuperTextBox();
            this.btArticulo = new System.Windows.Forms.Button();
            this.txtLote = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.chkIgv = new System.Windows.Forms.CheckBox();
            this.txtPorIgv = new ControlesWinForm.SuperTextBox();
            this.txtIgv = new ControlesWinForm.SuperTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSubTotal = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDscto = new ControlesWinForm.SuperTextBox();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlMontos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(639, 19);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(922, 25);
            this.lblTituloPrincipal.TabIndex = 500;
            this.lblTituloPrincipal.Text = "Detalle de Orden de Compra";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(892, 2);
            this.btCerrar.TabIndex = 501;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.txtLote);
            this.pnlBase.Controls.Add(this.btArticulo);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.txtUltimaCompra);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.txtPrecioUnitario);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.cboUnidadMedida);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.txtEspecificacion);
            this.pnlBase.Controls.Add(this.txtNumItem);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.txtCantOrdenada);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.txtNroCompra);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Location = new System.Drawing.Point(8, 29);
            this.pnlBase.Size = new System.Drawing.Size(641, 159);
            this.pnlBase.TabIndex = 100;
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNroCompra, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantOrdenada, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumItem, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtEspecificacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboUnidadMedida, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPrecioUnitario, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUltimaCompra, 0);
            this.pnlBase.Controls.SetChildIndex(this.label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.btArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtLote, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(789, 156);
            this.btCancelar.Size = new System.Drawing.Size(116, 26);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(665, 156);
            this.btAceptar.Size = new System.Drawing.Size(116, 26);
            this.btAceptar.TabIndex = 110;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(11, 95);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificación";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(11, 73);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificación";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label26.Location = new System.Drawing.Point(11, 29);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(86, 13);
            label26.TabIndex = 0;
            label26.Text = "Usuario Registro";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.Location = new System.Drawing.Point(11, 51);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(79, 13);
            label27.TabIndex = 2;
            label27.Text = "Fecha Registro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(398, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 316;
            this.label8.Text = "Cant. Ordenada";
            // 
            // txtCantOrdenada
            // 
            this.txtCantOrdenada.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantOrdenada.BackColor = System.Drawing.Color.White;
            this.txtCantOrdenada.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantOrdenada.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantOrdenada.Location = new System.Drawing.Point(485, 100);
            this.txtCantOrdenada.Name = "txtCantOrdenada";
            this.txtCantOrdenada.Size = new System.Drawing.Size(83, 21);
            this.txtCantOrdenada.TabIndex = 12;
            this.txtCantOrdenada.Text = "0.0000";
            this.txtCantOrdenada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantOrdenada.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantOrdenada.TextoVacio = "<Descripcion>";
            this.txtCantOrdenada.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCantOrdenada_MouseClick);
            this.txtCantOrdenada.TextChanged += new System.EventHandler(this.txtCantOrdenada_TextChanged);
            this.txtCantOrdenada.Enter += new System.EventHandler(this.txtCantOrdenada_Enter);
            this.txtCantOrdenada.Leave += new System.EventHandler(this.txtCantOrdenada_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 314;
            this.label4.Text = "Articulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 313;
            this.label3.Text = "N° Orden Compra";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(100, 52);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(42, 21);
            this.txtIdArticulo.TabIndex = 4;
            this.txtIdArticulo.TabStop = false;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            // 
            // txtNroCompra
            // 
            this.txtNroCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNroCompra.Enabled = false;
            this.txtNroCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCompra.Location = new System.Drawing.Point(100, 29);
            this.txtNroCompra.Name = "txtNroCompra";
            this.txtNroCompra.ReadOnly = true;
            this.txtNroCompra.Size = new System.Drawing.Size(73, 21);
            this.txtNroCompra.TabIndex = 1;
            this.txtNroCompra.TabStop = false;
            // 
            // txtNumItem
            // 
            this.txtNumItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtNumItem.Enabled = false;
            this.txtNumItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumItem.Location = new System.Drawing.Point(174, 29);
            this.txtNumItem.Name = "txtNumItem";
            this.txtNumItem.ReadOnly = true;
            this.txtNumItem.Size = new System.Drawing.Size(55, 21);
            this.txtNumItem.TabIndex = 2;
            this.txtNumItem.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 336;
            this.label12.Text = "Especificación";
            // 
            // txtEspecificacion
            // 
            this.txtEspecificacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEspecificacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEspecificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecificacion.Location = new System.Drawing.Point(100, 75);
            this.txtEspecificacion.Multiline = true;
            this.txtEspecificacion.Name = "txtEspecificacion";
            this.txtEspecificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEspecificacion.Size = new System.Drawing.Size(292, 69);
            this.txtEspecificacion.TabIndex = 9;
            this.txtEspecificacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtEspecificacion.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(398, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 340;
            this.label2.Text = "U. Medida";
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadMedida.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(485, 76);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(146, 21);
            this.cboUnidadMedida.TabIndex = 11;
            this.cboUnidadMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUnidadMedida_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(398, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 342;
            this.label5.Text = "Precio Unitario";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioUnitario.Location = new System.Drawing.Point(485, 123);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(84, 21);
            this.txtPrecioUnitario.TabIndex = 13;
            this.txtPrecioUnitario.Text = "0.000000";
            this.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioUnitario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecioUnitario.TextoVacio = "<Descripcion>";
            this.txtPrecioUnitario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPrecioUnitario_MouseClick);
            this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
            this.txtPrecioUnitario.Enter += new System.EventHandler(this.txtPrecioUnitario_Enter);
            this.txtPrecioUnitario.Leave += new System.EventHandler(this.txtPrecioUnitario_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 344;
            this.label6.Text = "Dscto(%)";
            // 
            // txtPorDscto
            // 
            this.txtPorDscto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorDscto.BackColor = System.Drawing.Color.White;
            this.txtPorDscto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorDscto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorDscto.Location = new System.Drawing.Point(99, 28);
            this.txtPorDscto.Name = "txtPorDscto";
            this.txtPorDscto.Size = new System.Drawing.Size(56, 21);
            this.txtPorDscto.TabIndex = 14;
            this.txtPorDscto.Text = "0.00";
            this.txtPorDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorDscto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorDscto.TextoVacio = "<Descripcion>";
            this.txtPorDscto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPorDscto_MouseClick);
            this.txtPorDscto.TextChanged += new System.EventHandler(this.txtPorDscto_TextChanged);
            this.txtPorDscto.Enter += new System.EventHandler(this.txtPorDscto_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(576, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 346;
            this.label7.Text = "Precio Total";
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecioTotal.BackColor = System.Drawing.Color.White;
            this.txtPrecioTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecioTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioTotal.Location = new System.Drawing.Point(639, 28);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.Size = new System.Drawing.Size(75, 21);
            this.txtPrecioTotal.TabIndex = 16;
            this.txtPrecioTotal.Text = "0.00";
            this.txtPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecioTotal.TextoVacio = "<Descripcion>";
            this.txtPrecioTotal.TextChanged += new System.EventHandler(this.txtPrecioTotal_TextChanged);
            this.txtPrecioTotal.Leave += new System.EventHandler(this.txtPrecioTotal_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(486, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 348;
            this.label9.Text = "Ultima Compra";
            // 
            // txtUltimaCompra
            // 
            this.txtUltimaCompra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtUltimaCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUltimaCompra.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtUltimaCompra.Enabled = false;
            this.txtUltimaCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimaCompra.Location = new System.Drawing.Point(563, 29);
            this.txtUltimaCompra.Name = "txtUltimaCompra";
            this.txtUltimaCompra.Size = new System.Drawing.Size(68, 21);
            this.txtUltimaCompra.TabIndex = 3;
            this.txtUltimaCompra.TabStop = false;
            this.txtUltimaCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUltimaCompra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtUltimaCompra.TextoVacio = "<Descripcion>";
            this.txtUltimaCompra.Leave += new System.EventHandler(this.txtUltimaCompra_Leave);
            // 
            // btArticulo
            // 
            this.btArticulo.BackColor = System.Drawing.Color.Azure;
            this.btArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btArticulo.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btArticulo.Location = new System.Drawing.Point(606, 52);
            this.btArticulo.Name = "btArticulo";
            this.btArticulo.Size = new System.Drawing.Size(24, 20);
            this.btArticulo.TabIndex = 8;
            this.btArticulo.TabStop = false;
            this.btArticulo.UseVisualStyleBackColor = false;
            this.btArticulo.Click += new System.EventHandler(this.btArticulo_Click);
            // 
            // txtLote
            // 
            this.txtLote.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtLote.BackColor = System.Drawing.Color.White;
            this.txtLote.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(543, 52);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(61, 21);
            this.txtLote.TabIndex = 7;
            this.txtLote.TabStop = false;
            this.txtLote.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLote.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label14);
            this.pnlAuditoria.Controls.Add(label24);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label25);
            this.pnlAuditoria.Controls.Add(label26);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label27);
            this.pnlAuditoria.Location = new System.Drawing.Point(651, 29);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(262, 120);
            this.pnlAuditoria.TabIndex = 375;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(260, 18);
            this.label14.TabIndex = 1580;
            this.label14.Text = "Auditoria";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(117, 91);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(130, 21);
            this.txtFechaModificacion.TabIndex = 304;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(117, 25);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(130, 21);
            this.txtUsuarioRegistro.TabIndex = 300;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(117, 69);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(130, 21);
            this.txtUsuarioModificacion.TabIndex = 303;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(117, 47);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(130, 21);
            this.txtFechaRegistro.TabIndex = 301;
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.White;
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.Location = new System.Drawing.Point(142, 52);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(87, 21);
            this.txtCodArticulo.TabIndex = 5;
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
            this.txtDesArticulo.Location = new System.Drawing.Point(230, 52);
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(312, 21);
            this.txtDesArticulo.TabIndex = 6;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            this.txtDesArticulo.TextChanged += new System.EventHandler(this.txtDesArticulo_TextChanged);
            this.txtDesArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesArticulo_Validating);
            // 
            // chkIgv
            // 
            this.chkIgv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIgv.Location = new System.Drawing.Point(395, 30);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(52, 17);
            this.chkIgv.TabIndex = 15;
            this.chkIgv.TabStop = false;
            this.chkIgv.Text = "I.G.V.";
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
            this.txtPorIgv.Location = new System.Drawing.Point(512, 28);
            this.txtPorIgv.Name = "txtPorIgv";
            this.txtPorIgv.Size = new System.Drawing.Size(39, 21);
            this.txtPorIgv.TabIndex = 377;
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
            this.txtIgv.Location = new System.Drawing.Point(450, 28);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(62, 21);
            this.txtIgv.TabIndex = 378;
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
            this.label19.Location = new System.Drawing.Point(551, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 379;
            this.label19.Text = "%";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtSubTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(315, 28);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(75, 21);
            this.txtSubTotal.TabIndex = 381;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.Text = "0.00";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtSubTotal.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(263, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 380;
            this.label10.Text = "SubTotal";
            // 
            // pnlMontos
            // 
            this.pnlMontos.BackColor = System.Drawing.Color.Transparent;
            this.pnlMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMontos.Controls.Add(this.label13);
            this.pnlMontos.Controls.Add(this.pictureBox1);
            this.pnlMontos.Controls.Add(this.label11);
            this.pnlMontos.Controls.Add(this.txtDscto);
            this.pnlMontos.Controls.Add(this.txtSubTotal);
            this.pnlMontos.Controls.Add(this.txtPorDscto);
            this.pnlMontos.Controls.Add(this.label10);
            this.pnlMontos.Controls.Add(this.label6);
            this.pnlMontos.Controls.Add(this.chkIgv);
            this.pnlMontos.Controls.Add(this.txtPrecioTotal);
            this.pnlMontos.Controls.Add(this.txtPorIgv);
            this.pnlMontos.Controls.Add(this.label7);
            this.pnlMontos.Controls.Add(this.txtIgv);
            this.pnlMontos.Controls.Add(this.label19);
            this.pnlMontos.Location = new System.Drawing.Point(8, 190);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(904, 60);
            this.pnlMontos.TabIndex = 376;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(902, 18);
            this.label13.TabIndex = 1580;
            this.label13.Text = "Montos";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.Billetes_Moneda;
            this.pictureBox1.Location = new System.Drawing.Point(760, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 384;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(162, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 383;
            this.label11.Text = "Dscto.";
            // 
            // txtDscto
            // 
            this.txtDscto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDscto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDscto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDscto.Enabled = false;
            this.txtDscto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDscto.Location = new System.Drawing.Point(203, 28);
            this.txtDscto.Name = "txtDscto";
            this.txtDscto.Size = new System.Drawing.Size(56, 21);
            this.txtDscto.TabIndex = 382;
            this.txtDscto.TabStop = false;
            this.txtDscto.Text = "0.00";
            this.txtDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDscto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtDscto.TextoVacio = "<Descripcion>";
            // 
            // frmDetalleOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 255);
            this.Controls.Add(this.pnlMontos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleOrdenDeCompra";
            this.Text = "frmDetalleOrdenDeCompra";
            this.Load += new System.EventHandler(this.frmDetalleOrdenDeCompra_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.pnlMontos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlMontos.ResumeLayout(false);
            this.pnlMontos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumItem;
        private System.Windows.Forms.Label label8;
        private ControlesWinForm.SuperTextBox txtCantOrdenada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private System.Windows.Forms.TextBox txtNroCompra;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtEspecificacion;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtPorDscto;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboUnidadMedida;
        private System.Windows.Forms.Label label7;
        private ControlesWinForm.SuperTextBox txtPrecioTotal;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtUltimaCompra;
        private System.Windows.Forms.Button btArticulo;
        private ControlesWinForm.SuperTextBox txtLote;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private System.Windows.Forms.CheckBox chkIgv;
        private ControlesWinForm.SuperTextBox txtPorIgv;
        private ControlesWinForm.SuperTextBox txtIgv;
        private System.Windows.Forms.Label label19;
        private ControlesWinForm.SuperTextBox txtSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlMontos;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtDscto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}