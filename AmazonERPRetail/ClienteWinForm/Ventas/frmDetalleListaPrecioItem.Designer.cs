namespace ClienteWinForm.Ventas
{
    partial class frmDetalleListaPrecioItem
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
            System.Windows.Forms.Label usuarioModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label17;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPorDscto = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.txtIdTipoArticulo = new ControlesWinForm.SuperTextBox();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCapacidad = new ControlesWinForm.SuperTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContenido = new ControlesWinForm.SuperTextBox();
            this.txtTipoArticulo = new ControlesWinForm.SuperTextBox();
            this.PnlUma = new System.Windows.Forms.Panel();
            this.lblLetras = new System.Windows.Forms.Label();
            this.txtPrecio = new ControlesWinForm.SuperTextBox();
            this.txtPrecVta = new ControlesWinForm.SuperTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPorIgv = new ControlesWinForm.SuperTextBox();
            this.chImpuesto = new System.Windows.Forms.CheckBox();
            this.PnlUmd = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtPrecioD = new ControlesWinForm.SuperTextBox();
            this.TxtPrecVtaD = new ControlesWinForm.SuperTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPorcIgvD = new ControlesWinForm.SuperTextBox();
            this.TxtPorDctoD = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChkImpuestoD = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtMedida = new System.Windows.Forms.TextBox();
            this.TxtMedidaD = new System.Windows.Forms.TextBox();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.PnlUma.SuspendLayout();
            this.PnlUmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(692, 18);
            this.lblTitPnlBase.Text = "Principal";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(967, 25);
            this.lblTituloPrincipal.Text = "Detalle Lista Precio Item";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(930, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(label17);
            this.pnlBase.Controls.Add(label15);
            this.pnlBase.Controls.Add(this.txtTipoArticulo);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.txtContenido);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.txtCapacidad);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(this.txtIdTipoArticulo);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.TxtMedida);
            this.pnlBase.Controls.Add(this.TxtMedidaD);
            this.pnlBase.Location = new System.Drawing.Point(8, 29);
            this.pnlBase.Size = new System.Drawing.Size(694, 125);
            this.pnlBase.TabIndex = 1000;
            this.pnlBase.Controls.SetChildIndex(this.TxtMedidaD, 0);
            this.pnlBase.Controls.SetChildIndex(this.TxtMedida, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdTipoArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCapacidad, 0);
            this.pnlBase.Controls.SetChildIndex(this.label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtContenido, 0);
            this.pnlBase.Controls.SetChildIndex(this.label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTipoArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(label15, 0);
            this.pnlBase.Controls.SetChildIndex(label17, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(487, 231);
            this.btCancelar.Size = new System.Drawing.Size(116, 28);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(363, 231);
            this.btAceptar.Size = new System.Drawing.Size(116, 28);
            this.btAceptar.TabIndex = 9;
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaModificacionLabel.Location = new System.Drawing.Point(7, 97);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(100, 13);
            fechaModificacionLabel.TabIndex = 6;
            fechaModificacionLabel.Text = "Fecha Modificacion";
            // 
            // usuarioModificacionLabel
            // 
            usuarioModificacionLabel.AutoSize = true;
            usuarioModificacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioModificacionLabel.Location = new System.Drawing.Point(7, 75);
            usuarioModificacionLabel.Name = "usuarioModificacionLabel";
            usuarioModificacionLabel.Size = new System.Drawing.Size(106, 13);
            usuarioModificacionLabel.TabIndex = 4;
            usuarioModificacionLabel.Text = "Usuario Modificacion";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usuarioRegistroLabel.Location = new System.Drawing.Point(7, 31);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaRegistroLabel.Location = new System.Drawing.Point(7, 53);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.Location = new System.Drawing.Point(3, 75);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(88, 13);
            label15.TabIndex = 388;
            label15.Text = "U.M.Almacenam.";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label17.Location = new System.Drawing.Point(25, 98);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(66, 13);
            label17.TabIndex = 392;
            label17.Text = "U.M. Detalle";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label20);
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaModificacion);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioModificacionLabel);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioModificacion);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(705, 29);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(254, 125);
            this.pnlAuditoria.TabIndex = 290;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(252, 18);
            this.label20.TabIndex = 1571;
            this.label20.Text = "Auditoria";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(114, 93);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(132, 20);
            this.txtFechaModificacion.TabIndex = 103;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(114, 27);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(132, 20);
            this.txtUsuarioRegistro.TabIndex = 100;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(114, 71);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(132, 20);
            this.txtUsuarioModificacion.TabIndex = 102;
            this.txtUsuarioModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(114, 49);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(132, 20);
            this.txtFechaRegistro.TabIndex = 101;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.ForeColor = System.Drawing.Color.Black;
            this.txtIdArticulo.Location = new System.Drawing.Point(95, 27);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(59, 20);
            this.txtIdArticulo.TabIndex = 372;
            this.txtIdArticulo.TabStop = false;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Enabled = false;
            this.txtCodArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.ForeColor = System.Drawing.Color.Black;
            this.txtCodArticulo.Location = new System.Drawing.Point(155, 27);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(91, 20);
            this.txtCodArticulo.TabIndex = 352;
            this.txtCodArticulo.TabStop = false;
            this.txtCodArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodArticulo.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 360;
            this.label2.Text = "% Dsct";
            // 
            // txtPorDscto
            // 
            this.txtPorDscto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorDscto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorDscto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorDscto.Location = new System.Drawing.Point(410, 31);
            this.txtPorDscto.Name = "txtPorDscto";
            this.txtPorDscto.Size = new System.Drawing.Size(43, 20);
            this.txtPorDscto.TabIndex = 5;
            this.txtPorDscto.Text = "0.00";
            this.txtPorDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorDscto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorDscto.TextoVacio = "<Descripcion>";
            this.txtPorDscto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPorcDsct1_MouseClick);
            this.txtPorDscto.Enter += new System.EventHandler(this.txtPorcDsct1_Enter);
            this.txtPorDscto.Leave += new System.EventHandler(this.txtPorcDsct1_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 356;
            this.label5.Text = "Precio";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(41, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 355;
            this.label12.Text = "Producto";
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackColor = System.Drawing.Color.Azure;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarArticulo.Location = new System.Drawing.Point(664, 27);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(23, 20);
            this.btBuscarArticulo.TabIndex = 1;
            this.btBuscarArticulo.UseVisualStyleBackColor = false;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // txtIdTipoArticulo
            // 
            this.txtIdTipoArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdTipoArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdTipoArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdTipoArticulo.Enabled = false;
            this.txtIdTipoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTipoArticulo.ForeColor = System.Drawing.Color.Black;
            this.txtIdTipoArticulo.Location = new System.Drawing.Point(95, 49);
            this.txtIdTipoArticulo.Name = "txtIdTipoArticulo";
            this.txtIdTipoArticulo.Size = new System.Drawing.Size(59, 20);
            this.txtIdTipoArticulo.TabIndex = 377;
            this.txtIdTipoArticulo.TabStop = false;
            this.txtIdTipoArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdTipoArticulo.TextoVacio = "<Descripcion>";
            // 
            // txtDesArticulo
            // 
            this.txtDesArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesArticulo.Enabled = false;
            this.txtDesArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesArticulo.ForeColor = System.Drawing.Color.Black;
            this.txtDesArticulo.Location = new System.Drawing.Point(247, 27);
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(415, 20);
            this.txtDesArticulo.TabIndex = 378;
            this.txtDesArticulo.TabStop = false;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 379;
            this.label1.Text = "Tipo Prod.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(419, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 381;
            this.label10.Text = "Capacidad";
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCapacidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCapacidad.Enabled = false;
            this.txtCapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidad.ForeColor = System.Drawing.Color.Black;
            this.txtCapacidad.Location = new System.Drawing.Point(485, 49);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(65, 20);
            this.txtCapacidad.TabIndex = 380;
            this.txtCapacidad.TabStop = false;
            this.txtCapacidad.Text = "0.00";
            this.txtCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapacidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCapacidad.TextoVacio = "<Descripcion>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(559, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 383;
            this.label11.Text = "Fraccion";
            // 
            // txtContenido
            // 
            this.txtContenido.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtContenido.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtContenido.Enabled = false;
            this.txtContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContenido.ForeColor = System.Drawing.Color.Black;
            this.txtContenido.Location = new System.Drawing.Point(621, 49);
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(65, 20);
            this.txtContenido.TabIndex = 382;
            this.txtContenido.TabStop = false;
            this.txtContenido.Text = "0.00";
            this.txtContenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContenido.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtContenido.TextoVacio = "<Descripcion>";
            // 
            // txtTipoArticulo
            // 
            this.txtTipoArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTipoArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtTipoArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTipoArticulo.Enabled = false;
            this.txtTipoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoArticulo.ForeColor = System.Drawing.Color.Black;
            this.txtTipoArticulo.Location = new System.Drawing.Point(155, 49);
            this.txtTipoArticulo.Name = "txtTipoArticulo";
            this.txtTipoArticulo.Size = new System.Drawing.Size(257, 20);
            this.txtTipoArticulo.TabIndex = 384;
            this.txtTipoArticulo.TabStop = false;
            this.txtTipoArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtTipoArticulo.TextoVacio = "<Descripcion>";
            // 
            // PnlUma
            // 
            this.PnlUma.BackColor = System.Drawing.Color.Transparent;
            this.PnlUma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlUma.Controls.Add(this.lblLetras);
            this.PnlUma.Controls.Add(this.txtPrecio);
            this.PnlUma.Controls.Add(this.txtPrecVta);
            this.PnlUma.Controls.Add(this.label9);
            this.PnlUma.Controls.Add(this.txtPorIgv);
            this.PnlUma.Controls.Add(this.txtPorDscto);
            this.PnlUma.Controls.Add(this.label5);
            this.PnlUma.Controls.Add(this.chImpuesto);
            this.PnlUma.Controls.Add(this.label2);
            this.PnlUma.Enabled = false;
            this.PnlUma.Location = new System.Drawing.Point(8, 156);
            this.PnlUma.Name = "PnlUma";
            this.PnlUma.Size = new System.Drawing.Size(474, 65);
            this.PnlUma.TabIndex = 250;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(472, 18);
            this.lblLetras.TabIndex = 1571;
            this.lblLetras.Text = "Precio Unidad de Medida Empaque ";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(52, 31);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(56, 20);
            this.txtPrecio.TabIndex = 2;
            this.txtPrecio.Text = "0.00";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecio.TextoVacio = "<Descripcion>";
            this.txtPrecio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPrecio_MouseClick);
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.Enter += new System.EventHandler(this.txtPrecio_Enter);
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // txtPrecVta
            // 
            this.txtPrecVta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecVta.BackColor = System.Drawing.Color.White;
            this.txtPrecVta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecVta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecVta.Location = new System.Drawing.Point(290, 31);
            this.txtPrecVta.Name = "txtPrecVta";
            this.txtPrecVta.Size = new System.Drawing.Size(72, 20);
            this.txtPrecVta.TabIndex = 4;
            this.txtPrecVta.Text = "0.00";
            this.txtPrecVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecVta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecVta.TextoVacio = "<Descripcion>";
            this.txtPrecVta.TextChanged += new System.EventHandler(this.txtPrecVta_TextChanged);
            this.txtPrecVta.Leave += new System.EventHandler(this.txtPrecVta_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(225, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 370;
            this.label9.Text = "P. Incl. IGV";
            // 
            // txtPorIgv
            // 
            this.txtPorIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtPorIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorIgv.Enabled = false;
            this.txtPorIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorIgv.Location = new System.Drawing.Point(177, 31);
            this.txtPorIgv.Name = "txtPorIgv";
            this.txtPorIgv.Size = new System.Drawing.Size(43, 20);
            this.txtPorIgv.TabIndex = 349;
            this.txtPorIgv.TabStop = false;
            this.txtPorIgv.Text = "0.00";
            this.txtPorIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorIgv.TextoVacio = "<Descripcion>";
            this.txtPorIgv.TextChanged += new System.EventHandler(this.txtPorcIgv_TextChanged);
            // 
            // chImpuesto
            // 
            this.chImpuesto.AutoSize = true;
            this.chImpuesto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chImpuesto.Location = new System.Drawing.Point(113, 33);
            this.chImpuesto.Name = "chImpuesto";
            this.chImpuesto.Size = new System.Drawing.Size(59, 17);
            this.chImpuesto.TabIndex = 3;
            this.chImpuesto.Text = "I.G.V.  ";
            this.chImpuesto.UseVisualStyleBackColor = true;
            this.chImpuesto.CheckedChanged += new System.EventHandler(this.chImpuesto_CheckedChanged);
            // 
            // PnlUmd
            // 
            this.PnlUmd.BackColor = System.Drawing.Color.Transparent;
            this.PnlUmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlUmd.Controls.Add(this.label19);
            this.PnlUmd.Controls.Add(this.TxtPrecioD);
            this.PnlUmd.Controls.Add(this.TxtPrecVtaD);
            this.PnlUmd.Controls.Add(this.label3);
            this.PnlUmd.Controls.Add(this.TxtPorcIgvD);
            this.PnlUmd.Controls.Add(this.TxtPorDctoD);
            this.PnlUmd.Controls.Add(this.label7);
            this.PnlUmd.Controls.Add(this.ChkImpuestoD);
            this.PnlUmd.Controls.Add(this.label13);
            this.PnlUmd.Enabled = false;
            this.PnlUmd.Location = new System.Drawing.Point(485, 156);
            this.PnlUmd.Name = "PnlUmd";
            this.PnlUmd.Size = new System.Drawing.Size(474, 65);
            this.PnlUmd.TabIndex = 388;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(472, 18);
            this.label19.TabIndex = 1571;
            this.label19.Text = "Precio por Unidad Medida Fracción";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtPrecioD
            // 
            this.TxtPrecioD.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.TxtPrecioD.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtPrecioD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioD.Location = new System.Drawing.Point(52, 31);
            this.TxtPrecioD.Name = "TxtPrecioD";
            this.TxtPrecioD.Size = new System.Drawing.Size(56, 20);
            this.TxtPrecioD.TabIndex = 6;
            this.TxtPrecioD.Text = "0.00";
            this.TxtPrecioD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPrecioD.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.TxtPrecioD.TextoVacio = "<Descripcion>";
            this.TxtPrecioD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtPrecioD_MouseClick);
            this.TxtPrecioD.TextChanged += new System.EventHandler(this.TxtPrecioD_TextChanged);
            this.TxtPrecioD.Enter += new System.EventHandler(this.TxtPrecioD_Enter);
            this.TxtPrecioD.Leave += new System.EventHandler(this.TxtPrecioD_Leave);
            // 
            // TxtPrecVtaD
            // 
            this.TxtPrecVtaD.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.TxtPrecVtaD.BackColor = System.Drawing.Color.White;
            this.TxtPrecVtaD.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtPrecVtaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecVtaD.Location = new System.Drawing.Point(289, 31);
            this.TxtPrecVtaD.Name = "TxtPrecVtaD";
            this.TxtPrecVtaD.Size = new System.Drawing.Size(72, 20);
            this.TxtPrecVtaD.TabIndex = 7;
            this.TxtPrecVtaD.Text = "0.00";
            this.TxtPrecVtaD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPrecVtaD.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.TxtPrecVtaD.TextoVacio = "<Descripcion>";
            this.TxtPrecVtaD.TextChanged += new System.EventHandler(this.TxtPrecVtaD_TextChanged);
            this.TxtPrecVtaD.Leave += new System.EventHandler(this.TxtPrecVtaD_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(224, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 370;
            this.label3.Text = "P. Incl. IGV";
            // 
            // TxtPorcIgvD
            // 
            this.TxtPorcIgvD.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.TxtPorcIgvD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.TxtPorcIgvD.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtPorcIgvD.Enabled = false;
            this.TxtPorcIgvD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPorcIgvD.Location = new System.Drawing.Point(176, 31);
            this.TxtPorcIgvD.Name = "TxtPorcIgvD";
            this.TxtPorcIgvD.Size = new System.Drawing.Size(43, 20);
            this.TxtPorcIgvD.TabIndex = 349;
            this.TxtPorcIgvD.TabStop = false;
            this.TxtPorcIgvD.Text = "0.00";
            this.TxtPorcIgvD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPorcIgvD.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.TxtPorcIgvD.TextoVacio = "<Descripcion>";
            this.TxtPorcIgvD.TextChanged += new System.EventHandler(this.TxtPorcIgvD_TextChanged);
            // 
            // TxtPorDctoD
            // 
            this.TxtPorDctoD.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.TxtPorDctoD.ColorTextoVacio = System.Drawing.Color.Gray;
            this.TxtPorDctoD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPorDctoD.Location = new System.Drawing.Point(407, 31);
            this.TxtPorDctoD.Name = "TxtPorDctoD";
            this.TxtPorDctoD.Size = new System.Drawing.Size(43, 20);
            this.TxtPorDctoD.TabIndex = 8;
            this.TxtPorDctoD.Text = "0.00";
            this.TxtPorDctoD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPorDctoD.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.TxtPorDctoD.TextoVacio = "<Descripcion>";
            this.TxtPorDctoD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtPorDctoD_MouseClick);
            this.TxtPorDctoD.TextChanged += new System.EventHandler(this.TxtPorDctoD_TextChanged);
            this.TxtPorDctoD.Enter += new System.EventHandler(this.TxtPorDctoD_Enter);
            this.TxtPorDctoD.Leave += new System.EventHandler(this.TxtPorDctoD_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 356;
            this.label7.Text = "Precio";
            // 
            // ChkImpuestoD
            // 
            this.ChkImpuestoD.AutoSize = true;
            this.ChkImpuestoD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkImpuestoD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkImpuestoD.Location = new System.Drawing.Point(113, 33);
            this.ChkImpuestoD.Name = "ChkImpuestoD";
            this.ChkImpuestoD.Size = new System.Drawing.Size(59, 17);
            this.ChkImpuestoD.TabIndex = 7;
            this.ChkImpuestoD.TabStop = false;
            this.ChkImpuestoD.Text = "I.G.V.  ";
            this.ChkImpuestoD.UseVisualStyleBackColor = true;
            this.ChkImpuestoD.CheckedChanged += new System.EventHandler(this.ChkImpuestoD_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(366, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 360;
            this.label13.Text = "% Dsct";
            // 
            // TxtMedida
            // 
            this.TxtMedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.TxtMedida.Enabled = false;
            this.TxtMedida.Location = new System.Drawing.Point(95, 71);
            this.TxtMedida.Name = "TxtMedida";
            this.TxtMedida.Size = new System.Drawing.Size(213, 20);
            this.TxtMedida.TabIndex = 394;
            // 
            // TxtMedidaD
            // 
            this.TxtMedidaD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.TxtMedidaD.Enabled = false;
            this.TxtMedidaD.Location = new System.Drawing.Point(95, 94);
            this.TxtMedidaD.Name = "TxtMedidaD";
            this.TxtMedidaD.Size = new System.Drawing.Size(213, 20);
            this.TxtMedidaD.TabIndex = 396;
            // 
            // frmDetalleListaPrecioItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(967, 272);
            this.Controls.Add(this.PnlUmd);
            this.Controls.Add(this.PnlUma);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleListaPrecioItem";
            this.Text = "frmDetalleListaPrecioItem";
            this.Load += new System.EventHandler(this.frmDetalleListaPrecioItem_Load);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.PnlUma, 0);
            this.Controls.SetChildIndex(this.PnlUmd, 0);
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
            this.PnlUma.ResumeLayout(false);
            this.PnlUma.PerformLayout();
            this.PnlUmd.ResumeLayout(false);
            this.PnlUmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtPorDscto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btBuscarArticulo;
        private ControlesWinForm.SuperTextBox txtIdTipoArticulo;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private System.Windows.Forms.Label label11;
        private ControlesWinForm.SuperTextBox txtContenido;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txtCapacidad;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtTipoArticulo;
        private System.Windows.Forms.Panel PnlUma;
        private System.Windows.Forms.Panel PnlUmd;
        private ControlesWinForm.SuperTextBox TxtPrecioD;
        private ControlesWinForm.SuperTextBox TxtPrecVtaD;
        private System.Windows.Forms.Label label3;
        private ControlesWinForm.SuperTextBox TxtPorcIgvD;
        private ControlesWinForm.SuperTextBox TxtPorDctoD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ChkImpuestoD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtMedidaD;
        private System.Windows.Forms.TextBox TxtMedida;
        private System.Windows.Forms.Label lblLetras;
        private ControlesWinForm.SuperTextBox txtPrecio;
        private ControlesWinForm.SuperTextBox txtPrecVta;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtPorIgv;
        private System.Windows.Forms.CheckBox chImpuesto;
    }
}