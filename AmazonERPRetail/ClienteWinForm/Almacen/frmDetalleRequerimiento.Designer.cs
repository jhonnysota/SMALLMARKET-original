namespace ClienteWinForm.Almacen
{
    partial class frmDetalleRequerimiento
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label idCategoriaLabel;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label cantidadLabel;
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.txtStock = new ControlesWinForm.SuperTextBox();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtObservación = new ControlesWinForm.SuperTextBox();
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            label10 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            idCategoriaLabel = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(493, 19);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(769, 25);
            this.lblTituloPrincipal.Text = "Detalle del Requerimiento";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(739, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtCantidad);
            this.pnlBase.Controls.Add(cantidadLabel);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Controls.Add(this.txtObservación);
            this.pnlBase.Controls.Add(label10);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(idCategoriaLabel);
            this.pnlBase.Controls.Add(this.cboUnidadMedida);
            this.pnlBase.Controls.Add(this.txtStock);
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Location = new System.Drawing.Point(8, 28);
            this.pnlBase.Size = new System.Drawing.Size(495, 165);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtStock, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboUnidadMedida, 0);
            this.pnlBase.Controls.SetChildIndex(idCategoriaLabel, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtObservación, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(cantidadLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantidad, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(639, 161);
            this.btCancelar.Size = new System.Drawing.Size(114, 26);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(515, 161);
            this.btAceptar.Size = new System.Drawing.Size(114, 26);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(18, 52);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(50, 13);
            label10.TabIndex = 1019;
            label10.Text = "Producto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(269, 30);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(58, 13);
            label6.TabIndex = 1013;
            label6.Text = "Stock Alm.";
            // 
            // idCategoriaLabel
            // 
            idCategoriaLabel.AutoSize = true;
            idCategoriaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idCategoriaLabel.Location = new System.Drawing.Point(18, 74);
            idCategoriaLabel.Name = "idCategoriaLabel";
            idCategoriaLabel.Size = new System.Drawing.Size(53, 13);
            idCategoriaLabel.TabIndex = 1009;
            idCategoriaLabel.Text = "U.Medida";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(18, 30);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(59, 13);
            idArticuloLabel.TabIndex = 1007;
            idArticuloLabel.Text = "Código Art.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(5, 98);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(5, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(5, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(5, 54);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(18, 96);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(67, 13);
            label7.TabIndex = 1026;
            label7.Text = "Observación";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantidadLabel.Location = new System.Drawing.Point(18, 139);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(50, 13);
            cantidadLabel.TabIndex = 1028;
            cantidadLabel.Text = "Cantidad";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(89, 26);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(54, 20);
            this.txtIdArticulo.TabIndex = 1011;
            this.txtIdArticulo.TabStop = false;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackColor = System.Drawing.Color.Azure;
            this.btBuscarArticulo.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarArticulo.Location = new System.Drawing.Point(242, 27);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(22, 18);
            this.btBuscarArticulo.TabIndex = 1010;
            this.btBuscarArticulo.TabStop = false;
            this.btBuscarArticulo.UseVisualStyleBackColor = false;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadMedida.Enabled = false;
            this.cboUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(89, 70);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(167, 21);
            this.cboUnidadMedida.TabIndex = 1006;
            // 
            // txtStock
            // 
            this.txtStock.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtStock.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtStock.Enabled = false;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(331, 26);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(76, 20);
            this.txtStock.TabIndex = 1004;
            this.txtStock.TabStop = false;
            this.txtStock.Text = "0.00";
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStock.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtStock.TextoVacio = "<Descripcion>";
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.White;
            this.txtCodArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.Location = new System.Drawing.Point(144, 26);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(95, 20);
            this.txtCodArticulo.TabIndex = 1001;
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
            this.txtDesArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesArticulo.Location = new System.Drawing.Point(89, 48);
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(392, 20);
            this.txtDesArticulo.TabIndex = 1002;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            this.txtDesArticulo.TextChanged += new System.EventHandler(this.txtDesArticulo_TextChanged);
            this.txtDesArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesArticulo_Validating);
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(506, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(255, 126);
            this.pnlAuditoria.TabIndex = 258;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 18);
            this.label2.TabIndex = 1580;
            this.label2.Text = "Auditoria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(112, 94);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(131, 20);
            this.txtFechaModifica.TabIndex = 304;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(112, 28);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(131, 20);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(112, 72);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(131, 20);
            this.txtUsuarioMod.TabIndex = 303;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(112, 50);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(131, 20);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtObservación
            // 
            this.txtObservación.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtObservación.BackColor = System.Drawing.Color.White;
            this.txtObservación.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtObservación.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservación.Location = new System.Drawing.Point(89, 93);
            this.txtObservación.Multiline = true;
            this.txtObservación.Name = "txtObservación";
            this.txtObservación.Size = new System.Drawing.Size(392, 40);
            this.txtObservación.TabIndex = 1025;
            this.txtObservación.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtObservación.TextoVacio = "<Descripcion>";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(89, 135);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(92, 20);
            this.txtCantidad.TabIndex = 1027;
            this.txtCantidad.Text = "0.00";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // frmDetalleRequerimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 197);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "frmDetalleRequerimiento";
            this.Text = "frmDetalleRequerimiento";
            this.Load += new System.EventHandler(this.frmDetalleRequerimiento_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private System.Windows.Forms.Button btBuscarArticulo;
        private System.Windows.Forms.ComboBox cboUnidadMedida;
        private ControlesWinForm.SuperTextBox txtStock;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private ControlesWinForm.SuperTextBox txtObservación;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private System.Windows.Forms.Label label2;
    }
}