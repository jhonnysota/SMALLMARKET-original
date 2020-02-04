namespace ClienteWinForm.Almacen
{
    partial class frmOrdenConversionSalida
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
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioModificacionLabel;
            this.txttotrefe = new ControlesWinForm.SuperTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txttotbase = new ControlesWinForm.SuperTextBox();
            this.txtunitbase = new ControlesWinForm.SuperTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtunitrefe = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPesoUnitario = new ControlesWinForm.SuperTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.txtTotal = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUPresentacion = new ControlesWinForm.SuperTextBox();
            this.txtCant = new ControlesWinForm.SuperTextBox();
            this.txtUEnvase = new ControlesWinForm.SuperTextBox();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.txtCantSolicitada = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStock = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLote = new ControlesWinForm.SuperTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesMovSalida = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIdMovSalida = new ControlesWinForm.SuperTextBox();
            this.txtIdDocSalAlmacen = new ControlesWinForm.SuperTextBox();
            this.lblLetras = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(560, 18);
            this.lblTitPnlBase.Text = "Principal";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(860, 25);
            this.lblTituloPrincipal.Text = "Orden de Conversión Salida";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(831, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtDesMovSalida);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.cboAlmacen);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.txttotrefe);
            this.pnlBase.Controls.Add(this.txtIdMovSalida);
            this.pnlBase.Controls.Add(this.txtIdDocSalAlmacen);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txttotbase);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.txtunitbase);
            this.pnlBase.Controls.Add(this.txtLote);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.txtunitrefe);
            this.pnlBase.Controls.Add(this.txtStock);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.txtCantSolicitada);
            this.pnlBase.Controls.Add(this.label15);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(this.txtPesoUnitario);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(this.label14);
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.txtUEnvase);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.txtCant);
            this.pnlBase.Controls.Add(this.txtTotal);
            this.pnlBase.Controls.Add(this.txtUPresentacion);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(562, 173);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUPresentacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTotal, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCant, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtUEnvase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label14, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPesoUnitario, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.label15, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantSolicitada, 0);
            this.pnlBase.Controls.SetChildIndex(this.label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtStock, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtunitrefe, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtLote, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtunitbase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.txttotbase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdDocSalAlmacen, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdMovSalida, 0);
            this.pnlBase.Controls.SetChildIndex(this.txttotrefe, 0);
            this.pnlBase.Controls.SetChildIndex(this.label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboAlmacen, 0);
            this.pnlBase.Controls.SetChildIndex(this.label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesMovSalida, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(716, 168);
            this.btCancelar.Size = new System.Drawing.Size(112, 26);
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(596, 168);
            this.btAceptar.Size = new System.Drawing.Size(112, 26);
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(8, 97);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(8, 32);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(8, 54);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(8, 76);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(106, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // txttotrefe
            // 
            this.txttotrefe.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txttotrefe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txttotrefe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotrefe.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txttotrefe.Enabled = false;
            this.txttotrefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotrefe.Location = new System.Drawing.Point(473, 139);
            this.txttotrefe.Margin = new System.Windows.Forms.Padding(2);
            this.txttotrefe.Name = "txttotrefe";
            this.txttotrefe.Size = new System.Drawing.Size(68, 20);
            this.txttotrefe.TabIndex = 373;
            this.txttotrefe.Text = "0.000";
            this.txttotrefe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotrefe.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txttotrefe.TextoVacio = "<Descripcion>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(417, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 374;
            this.label11.Text = "Tot. Refe";
            // 
            // txttotbase
            // 
            this.txttotbase.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txttotbase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txttotbase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotbase.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txttotbase.Enabled = false;
            this.txttotbase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotbase.Location = new System.Drawing.Point(473, 117);
            this.txttotbase.Margin = new System.Windows.Forms.Padding(2);
            this.txttotbase.Name = "txttotbase";
            this.txttotbase.Size = new System.Drawing.Size(68, 20);
            this.txttotbase.TabIndex = 367;
            this.txttotbase.Text = "0.000";
            this.txttotbase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotbase.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txttotbase.TextoVacio = "<Descripcion>";
            // 
            // txtunitbase
            // 
            this.txtunitbase.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtunitbase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtunitbase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtunitbase.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtunitbase.Enabled = false;
            this.txtunitbase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtunitbase.Location = new System.Drawing.Point(350, 117);
            this.txtunitbase.Margin = new System.Windows.Forms.Padding(2);
            this.txtunitbase.Name = "txtunitbase";
            this.txtunitbase.Size = new System.Drawing.Size(58, 20);
            this.txtunitbase.TabIndex = 371;
            this.txtunitbase.Text = "0.000";
            this.txtunitbase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtunitbase.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtunitbase.TextoVacio = "<Descripcion>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 372;
            this.label10.Text = "Unit. Base";
            // 
            // txtunitrefe
            // 
            this.txtunitrefe.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtunitrefe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtunitrefe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtunitrefe.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtunitrefe.Enabled = false;
            this.txtunitrefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtunitrefe.Location = new System.Drawing.Point(350, 139);
            this.txtunitrefe.Margin = new System.Windows.Forms.Padding(2);
            this.txtunitrefe.Name = "txtunitrefe";
            this.txtunitrefe.Size = new System.Drawing.Size(58, 20);
            this.txtunitrefe.TabIndex = 369;
            this.txtunitrefe.Text = "0.000";
            this.txtunitrefe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtunitrefe.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtunitrefe.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 370;
            this.label8.Text = "Unit. Refe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 368;
            this.label7.Text = "Tot. Base";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(417, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 355;
            this.label15.Text = "Kg.";
            // 
            // txtPesoUnitario
            // 
            this.txtPesoUnitario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPesoUnitario.BackColor = System.Drawing.Color.White;
            this.txtPesoUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesoUnitario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPesoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoUnitario.Location = new System.Drawing.Point(350, 95);
            this.txtPesoUnitario.Margin = new System.Windows.Forms.Padding(2);
            this.txtPesoUnitario.Name = "txtPesoUnitario";
            this.txtPesoUnitario.Size = new System.Drawing.Size(58, 20);
            this.txtPesoUnitario.TabIndex = 8;
            this.txtPesoUnitario.Text = "0.0000";
            this.txtPesoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPesoUnitario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPesoUnitario.TextoVacio = "<Descripcion>";
            this.txtPesoUnitario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPesoUnitario_MouseClick);
            this.txtPesoUnitario.TextChanged += new System.EventHandler(this.txtPesoUnitario_TextChanged);
            this.txtPesoUnitario.Enter += new System.EventHandler(this.txtPesoUnitario_Enter);
            this.txtPesoUnitario.Leave += new System.EventHandler(this.txtPesoUnitario_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(318, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 353;
            this.label14.Text = "Peso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 326;
            this.label1.Text = "Articulo";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.White;
            this.txtIdArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(84, 51);
            this.txtIdArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(9, 20);
            this.txtIdArticulo.TabIndex = 352;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            this.txtIdArticulo.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(473, 95);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(68, 20);
            this.txtTotal.TabIndex = 351;
            this.txtTotal.Text = "0.000";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTotal.TextoVacio = "<Descripcion>";
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            this.txtTotal.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 350;
            this.label3.Text = "Total";
            // 
            // txtUPresentacion
            // 
            this.txtUPresentacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtUPresentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUPresentacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUPresentacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtUPresentacion.Enabled = false;
            this.txtUPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPresentacion.Location = new System.Drawing.Point(380, 73);
            this.txtUPresentacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtUPresentacion.Name = "txtUPresentacion";
            this.txtUPresentacion.Size = new System.Drawing.Size(161, 20);
            this.txtUPresentacion.TabIndex = 346;
            this.txtUPresentacion.TabStop = false;
            this.txtUPresentacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtUPresentacion.TextoVacio = "<Descripcion>";
            // 
            // txtCant
            // 
            this.txtCant.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCant.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCant.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCant.Enabled = false;
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCant.Location = new System.Drawing.Point(314, 73);
            this.txtCant.Margin = new System.Windows.Forms.Padding(2);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(65, 20);
            this.txtCant.TabIndex = 345;
            this.txtCant.TabStop = false;
            this.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCant.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCant.TextoVacio = "<Descripcion>";
            // 
            // txtUEnvase
            // 
            this.txtUEnvase.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtUEnvase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUEnvase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUEnvase.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtUEnvase.Enabled = false;
            this.txtUEnvase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUEnvase.Location = new System.Drawing.Point(174, 73);
            this.txtUEnvase.Margin = new System.Windows.Forms.Padding(2);
            this.txtUEnvase.Name = "txtUEnvase";
            this.txtUEnvase.Size = new System.Drawing.Size(139, 20);
            this.txtUEnvase.TabIndex = 344;
            this.txtUEnvase.TabStop = false;
            this.txtUEnvase.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtUEnvase.TextoVacio = "<Descripcion>";
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.White;
            this.txtCodArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.Location = new System.Drawing.Point(94, 50);
            this.txtCodArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(78, 20);
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
            this.txtDesArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesArticulo.Location = new System.Drawing.Point(173, 50);
            this.txtDesArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(342, 20);
            this.txtDesArticulo.TabIndex = 6;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            this.txtDesArticulo.TextChanged += new System.EventHandler(this.txtDesArticulo_TextChanged);
            this.txtDesArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesArticulo_Validating);
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackgroundImage = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Location = new System.Drawing.Point(518, 51);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(22, 19);
            this.btBuscarArticulo.TabIndex = 337;
            this.btBuscarArticulo.TabStop = false;
            this.btBuscarArticulo.UseVisualStyleBackColor = true;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // txtCantSolicitada
            // 
            this.txtCantSolicitada.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantSolicitada.BackColor = System.Drawing.Color.AliceBlue;
            this.txtCantSolicitada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantSolicitada.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantSolicitada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantSolicitada.Location = new System.Drawing.Point(251, 95);
            this.txtCantSolicitada.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantSolicitada.Name = "txtCantSolicitada";
            this.txtCantSolicitada.Size = new System.Drawing.Size(61, 20);
            this.txtCantSolicitada.TabIndex = 7;
            this.txtCantSolicitada.Text = "0.000";
            this.txtCantSolicitada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantSolicitada.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantSolicitada.TextoVacio = "<Descripcion>";
            this.txtCantSolicitada.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCantSolicitada_MouseClick);
            this.txtCantSolicitada.TextChanged += new System.EventHandler(this.txtCantSolicitada_TextChanged);
            this.txtCantSolicitada.Enter += new System.EventHandler(this.txtCantSolicitada_Enter);
            this.txtCantSolicitada.Leave += new System.EventHandler(this.txtCantSolicitada_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 336;
            this.label6.Text = "Cant.Solicitada";
            // 
            // txtStock
            // 
            this.txtStock.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStock.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtStock.Enabled = false;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(94, 95);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(78, 20);
            this.txtStock.TabIndex = 333;
            this.txtStock.TabStop = false;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStock.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtStock.TextoVacio = "<Descripcion>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 334;
            this.label5.Text = "Stock";
            // 
            // txtLote
            // 
            this.txtLote.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLote.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLote.Enabled = false;
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(94, 73);
            this.txtLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(78, 20);
            this.txtLote.TabIndex = 331;
            this.txtLote.TabStop = false;
            this.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLote.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLote.TextoVacio = "<Descripcion>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 332;
            this.label4.Text = "Lote";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.lblLetras);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Location = new System.Drawing.Point(571, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(281, 131);
            this.pnlAuditoria.TabIndex = 347;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(117, 28);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(149, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(117, 93);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(149, 20);
            this.txtFechaModificacion.TabIndex = 7;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(117, 50);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(149, 20);
            this.txtFechaRegistro.TabIndex = 3;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(117, 72);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(149, 20);
            this.txtUsuarioModificacion.TabIndex = 5;
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(94, 27);
            this.cboAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(225, 21);
            this.cboAlmacen.TabIndex = 365;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 375;
            this.label2.Text = "Almacén";
            // 
            // txtDesMovSalida
            // 
            this.txtDesMovSalida.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesMovSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesMovSalida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesMovSalida.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesMovSalida.Enabled = false;
            this.txtDesMovSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesMovSalida.Location = new System.Drawing.Point(175, 117);
            this.txtDesMovSalida.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesMovSalida.Name = "txtDesMovSalida";
            this.txtDesMovSalida.Size = new System.Drawing.Size(112, 20);
            this.txtDesMovSalida.TabIndex = 355;
            this.txtDesMovSalida.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesMovSalida.TextoVacio = "<Descripcion>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 352;
            this.label9.Text = "Doc. Almacén";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 354;
            this.label12.Text = "Tip.Movimiento";
            // 
            // txtIdMovSalida
            // 
            this.txtIdMovSalida.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdMovSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdMovSalida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdMovSalida.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdMovSalida.Enabled = false;
            this.txtIdMovSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdMovSalida.Location = new System.Drawing.Point(94, 117);
            this.txtIdMovSalida.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdMovSalida.Name = "txtIdMovSalida";
            this.txtIdMovSalida.Size = new System.Drawing.Size(78, 20);
            this.txtIdMovSalida.TabIndex = 353;
            this.txtIdMovSalida.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdMovSalida.TextoVacio = "<Descripcion>";
            // 
            // txtIdDocSalAlmacen
            // 
            this.txtIdDocSalAlmacen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdDocSalAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdDocSalAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdDocSalAlmacen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdDocSalAlmacen.Enabled = false;
            this.txtIdDocSalAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDocSalAlmacen.Location = new System.Drawing.Point(94, 139);
            this.txtIdDocSalAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdDocSalAlmacen.Name = "txtIdDocSalAlmacen";
            this.txtIdDocSalAlmacen.Size = new System.Drawing.Size(78, 20);
            this.txtIdDocSalAlmacen.TabIndex = 351;
            this.txtIdDocSalAlmacen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdDocSalAlmacen.TextoVacio = "<Descripcion>";
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(279, 18);
            this.lblLetras.TabIndex = 1573;
            this.lblLetras.Text = "Auditoria";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOrdenConversionSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 207);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmOrdenConversionSalida";
            this.Text = "Orden Conversion Salida";
            this.Load += new System.EventHandler(this.frmOrdenConversionSalida_Load);
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
        private System.Windows.Forms.Label label15;
        private ControlesWinForm.SuperTextBox txtPesoUnitario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private ControlesWinForm.SuperTextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox txtUPresentacion;
        private ControlesWinForm.SuperTextBox txtCant;
        private ControlesWinForm.SuperTextBox txtUEnvase;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private System.Windows.Forms.Button btBuscarArticulo;
        private ControlesWinForm.SuperTextBox txtCantSolicitada;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtStock;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtLote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private ControlesWinForm.SuperTextBox txttotrefe;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txttotbase;
        private ControlesWinForm.SuperTextBox txtunitbase;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txtunitrefe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtDesMovSalida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private ControlesWinForm.SuperTextBox txtIdMovSalida;
        private ControlesWinForm.SuperTextBox txtIdDocSalAlmacen;
        private System.Windows.Forms.Label lblLetras;
    }
}