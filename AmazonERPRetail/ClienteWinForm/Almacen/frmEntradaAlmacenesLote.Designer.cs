namespace ClienteWinForm.Almacen
{
    partial class frmEntradaAlmacenesLote
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
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label31;
            this.cboPaisProcedencia = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoteProveedor = new ControlesWinForm.SuperTextBox();
            this.LblDesFecha = new System.Windows.Forms.Label();
            this.cboPaisOrigen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblLetras = new System.Windows.Forms.Label();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtPesoUnitario = new ControlesWinForm.SuperTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLote = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFecProceso = new System.Windows.Forms.DateTimePicker();
            this.txtIdProveedor = new ControlesWinForm.SuperTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtproveedor = new ControlesWinForm.SuperTextBox();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.chbindPersona = new System.Windows.Forms.CheckBox();
            this.chbindfecProceso = new System.Windows.Forms.CheckBox();
            this.txtObservacion = new ControlesWinForm.SuperTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFecPrueba = new System.Windows.Forms.DateTimePicker();
            this.txtLoteAlmacen = new ControlesWinForm.SuperTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSiglaEmpresa = new ControlesWinForm.SuperTextBox();
            this.label19 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(681, 19);
            this.lblTitPnlBase.Text = "Datos del Lote";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(699, 25);
            this.lblTituloPrincipal.TabIndex = 500;
            this.lblTituloPrincipal.Text = "Ingreso de Almacen Lotes";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(671, 2);
            this.btCerrar.TabStop = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.label19);
            this.pnlBase.Controls.Add(this.txtSiglaEmpresa);
            this.pnlBase.Controls.Add(this.txtLoteAlmacen);
            this.pnlBase.Controls.Add(this.label18);
            this.pnlBase.Controls.Add(this.dtpFecPrueba);
            this.pnlBase.Controls.Add(this.label14);
            this.pnlBase.Controls.Add(this.txtObservacion);
            this.pnlBase.Controls.Add(this.panel8);
            this.pnlBase.Controls.Add(this.chbindfecProceso);
            this.pnlBase.Controls.Add(this.chbindPersona);
            this.pnlBase.Controls.Add(this.txtIdProveedor);
            this.pnlBase.Controls.Add(this.label16);
            this.pnlBase.Controls.Add(this.txtproveedor);
            this.pnlBase.Controls.Add(this.txtRuc);
            this.pnlBase.Controls.Add(this.label22);
            this.pnlBase.Controls.Add(this.dtpFecProceso);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.txtLote);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.txtPesoUnitario);
            this.pnlBase.Controls.Add(this.cboPaisOrigen);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.LblDesFecha);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txtLoteProveedor);
            this.pnlBase.Controls.Add(this.cboPaisProcedencia);
            this.pnlBase.Controls.Add(this.label17);
            this.pnlBase.Location = new System.Drawing.Point(7, 29);
            this.pnlBase.Size = new System.Drawing.Size(683, 250);
            this.pnlBase.TabIndex = 1;
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.label17, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboPaisProcedencia, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtLoteProveedor, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.LblDesFecha, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboPaisOrigen, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPesoUnitario, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtLote, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecProceso, 0);
            this.pnlBase.Controls.SetChildIndex(this.label22, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRuc, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtproveedor, 0);
            this.pnlBase.Controls.SetChildIndex(this.label16, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdProveedor, 0);
            this.pnlBase.Controls.SetChildIndex(this.chbindPersona, 0);
            this.pnlBase.Controls.SetChildIndex(this.chbindfecProceso, 0);
            this.pnlBase.Controls.SetChildIndex(this.panel8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtObservacion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label14, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecPrueba, 0);
            this.pnlBase.Controls.SetChildIndex(this.label18, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtLoteAlmacen, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSiglaEmpresa, 0);
            this.pnlBase.Controls.SetChildIndex(this.label19, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(351, 287);
            this.btCancelar.Size = new System.Drawing.Size(130, 29);
            this.btCancelar.TabIndex = 101;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(218, 287);
            this.btAceptar.Size = new System.Drawing.Size(130, 29);
            this.btAceptar.TabIndex = 100;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(9, 96);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(9, 74);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(9, 30);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(9, 52);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // cboPaisProcedencia
            // 
            this.cboPaisProcedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaisProcedencia.DropDownWidth = 120;
            this.cboPaisProcedencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaisProcedencia.FormattingEnabled = true;
            this.cboPaisProcedencia.Location = new System.Drawing.Point(495, 73);
            this.cboPaisProcedencia.Name = "cboPaisProcedencia";
            this.cboPaisProcedencia.Size = new System.Drawing.Size(105, 21);
            this.cboPaisProcedencia.TabIndex = 6;
            this.cboPaisProcedencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPaisProcedencia_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(400, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 13);
            this.label17.TabIndex = 314;
            this.label17.Text = "Pais Procedencia ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 345;
            this.label1.Text = "Lote Proveedor ";
            // 
            // txtLoteProveedor
            // 
            this.txtLoteProveedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtLoteProveedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLoteProveedor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteProveedor.Location = new System.Drawing.Point(99, 73);
            this.txtLoteProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoteProveedor.Name = "txtLoteProveedor";
            this.txtLoteProveedor.Size = new System.Drawing.Size(105, 20);
            this.txtLoteProveedor.TabIndex = 4;
            this.txtLoteProveedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLoteProveedor.TextoVacio = "<Descripcion>";
            // 
            // LblDesFecha
            // 
            this.LblDesFecha.AutoSize = true;
            this.LblDesFecha.Location = new System.Drawing.Point(11, 99);
            this.LblDesFecha.Name = "LblDesFecha";
            this.LblDesFecha.Size = new System.Drawing.Size(77, 13);
            this.LblDesFecha.TabIndex = 347;
            this.LblDesFecha.Text = "F. Vencimiento";
            // 
            // cboPaisOrigen
            // 
            this.cboPaisOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaisOrigen.DropDownWidth = 120;
            this.cboPaisOrigen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaisOrigen.FormattingEnabled = true;
            this.cboPaisOrigen.Location = new System.Drawing.Point(293, 73);
            this.cboPaisOrigen.Name = "cboPaisOrigen";
            this.cboPaisOrigen.Size = new System.Drawing.Size(105, 21);
            this.cboPaisOrigen.TabIndex = 5;
            this.cboPaisOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPaisOrigen_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 349;
            this.label2.Text = "Pais Origen ";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblLetras);
            this.panel8.Controls.Add(label24);
            this.panel8.Controls.Add(this.txtFechaModificacion);
            this.panel8.Controls.Add(this.txtUsuRegistro);
            this.panel8.Controls.Add(label25);
            this.panel8.Controls.Add(label29);
            this.panel8.Controls.Add(this.txtUsuModificacion);
            this.panel8.Controls.Add(this.txtFechaRegistro);
            this.panel8.Controls.Add(label31);
            this.panel8.Location = new System.Drawing.Point(403, 119);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(268, 121);
            this.panel8.TabIndex = 264;
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblLetras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLetras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.Location = new System.Drawing.Point(0, 0);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(266, 18);
            this.lblLetras.TabIndex = 1572;
            this.lblLetras.Text = "Auditoria";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(116, 91);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(139, 21);
            this.txtFechaModificacion.TabIndex = 7;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(116, 25);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(139, 21);
            this.txtUsuRegistro.TabIndex = 1;
            this.txtUsuRegistro.TabStop = false;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(116, 69);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(139, 21);
            this.txtUsuModificacion.TabIndex = 5;
            this.txtUsuModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(116, 47);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(139, 21);
            this.txtFechaRegistro.TabIndex = 3;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtPesoUnitario
            // 
            this.txtPesoUnitario.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPesoUnitario.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPesoUnitario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoUnitario.Location = new System.Drawing.Point(495, 96);
            this.txtPesoUnitario.Margin = new System.Windows.Forms.Padding(2);
            this.txtPesoUnitario.Name = "txtPesoUnitario";
            this.txtPesoUnitario.Size = new System.Drawing.Size(105, 20);
            this.txtPesoUnitario.TabIndex = 9;
            this.txtPesoUnitario.Text = "0.00000";
            this.txtPesoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPesoUnitario.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPesoUnitario.TextoVacio = "<Descripcion>";
            this.txtPesoUnitario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPesoUnitario_MouseClick);
            this.txtPesoUnitario.Leave += new System.EventHandler(this.txtPesoUnitario_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 353;
            this.label5.Text = "Peso Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 355;
            this.label6.Text = "Lote";
            // 
            // txtLote
            // 
            this.txtLote.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtLote.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLote.Enabled = false;
            this.txtLote.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(99, 29);
            this.txtLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(105, 20);
            this.txtLote.TabIndex = 354;
            this.txtLote.TabStop = false;
            this.txtLote.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLote.TextoVacio = "<Descripcion>";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(416, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 391;
            this.label22.Text = "Fecha Ingreso";
            // 
            // dtpFecProceso
            // 
            this.dtpFecProceso.CustomFormat = "dd/MM/yyyy";
            this.dtpFecProceso.Enabled = false;
            this.dtpFecProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecProceso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecProceso.Location = new System.Drawing.Point(495, 29);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(94, 20);
            this.dtpFecProceso.TabIndex = 1;
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdProveedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdProveedor.Enabled = false;
            this.txtIdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProveedor.Location = new System.Drawing.Point(99, 51);
            this.txtIdProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.ReadOnly = true;
            this.txtIdProveedor.Size = new System.Drawing.Size(52, 20);
            this.txtIdProveedor.TabIndex = 398;
            this.txtIdProveedor.TabStop = false;
            this.txtIdProveedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdProveedor.TextoVacio = "<Descripcion>";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 396;
            this.label16.Text = "Proveedor";
            // 
            // txtproveedor
            // 
            this.txtproveedor.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtproveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtproveedor.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtproveedor.Enabled = false;
            this.txtproveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproveedor.Location = new System.Drawing.Point(228, 51);
            this.txtproveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtproveedor.Name = "txtproveedor";
            this.txtproveedor.Size = new System.Drawing.Size(372, 20);
            this.txtproveedor.TabIndex = 3;
            this.txtproveedor.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtproveedor.TextoVacio = "<Descripcion>";
            this.txtproveedor.TextChanged += new System.EventHandler(this.txtproveedor_TextChanged);
            this.txtproveedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtproveedor_Validating);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(153, 51);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(73, 20);
            this.txtRuc.TabIndex = 2;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // chbindPersona
            // 
            this.chbindPersona.AutoSize = true;
            this.chbindPersona.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbindPersona.Location = new System.Drawing.Point(602, 53);
            this.chbindPersona.Name = "chbindPersona";
            this.chbindPersona.Size = new System.Drawing.Size(69, 17);
            this.chbindPersona.TabIndex = 399;
            this.chbindPersona.TabStop = false;
            this.chbindPersona.Text = "Ind.Prov.";
            this.chbindPersona.UseVisualStyleBackColor = true;
            this.chbindPersona.CheckedChanged += new System.EventHandler(this.chbindPersona_CheckedChanged);
            // 
            // chbindfecProceso
            // 
            this.chbindfecProceso.AutoSize = true;
            this.chbindfecProceso.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbindfecProceso.Location = new System.Drawing.Point(592, 30);
            this.chbindfecProceso.Name = "chbindfecProceso";
            this.chbindfecProceso.Size = new System.Drawing.Size(79, 17);
            this.chbindfecProceso.TabIndex = 400;
            this.chbindfecProceso.TabStop = false;
            this.chbindfecProceso.Text = "Ind.Ingreso";
            this.chbindfecProceso.UseVisualStyleBackColor = true;
            this.chbindfecProceso.CheckedChanged += new System.EventHandler(this.chbindfecProceso_CheckedChanged);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtObservacion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtObservacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(99, 119);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservacion.MaxLength = 100;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(299, 121);
            this.txtObservacion.TabIndex = 17;
            this.txtObservacion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtObservacion.TextoVacio = "<Descripcion>";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 506;
            this.label14.Text = "Observaciones";
            // 
            // dtpFecPrueba
            // 
            this.dtpFecPrueba.Checked = false;
            this.dtpFecPrueba.CustomFormat = "dd/MM/yyyy";
            this.dtpFecPrueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecPrueba.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecPrueba.Location = new System.Drawing.Point(99, 96);
            this.dtpFecPrueba.Name = "dtpFecPrueba";
            this.dtpFecPrueba.ShowCheckBox = true;
            this.dtpFecPrueba.Size = new System.Drawing.Size(105, 20);
            this.dtpFecPrueba.TabIndex = 509;
            this.dtpFecPrueba.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfecPrueba_KeyPress);
            // 
            // txtLoteAlmacen
            // 
            this.txtLoteAlmacen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtLoteAlmacen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLoteAlmacen.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteAlmacen.Location = new System.Drawing.Point(334, 29);
            this.txtLoteAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoteAlmacen.MaxLength = 6;
            this.txtLoteAlmacen.Name = "txtLoteAlmacen";
            this.txtLoteAlmacen.Size = new System.Drawing.Size(73, 20);
            this.txtLoteAlmacen.TabIndex = 6;
            this.txtLoteAlmacen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtLoteAlmacen.TextoVacio = "<Descripcion>";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(212, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 511;
            this.label18.Text = "Lote Almacen";
            // 
            // txtSiglaEmpresa
            // 
            this.txtSiglaEmpresa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSiglaEmpresa.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSiglaEmpresa.Enabled = false;
            this.txtSiglaEmpresa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiglaEmpresa.Location = new System.Drawing.Point(292, 29);
            this.txtSiglaEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.txtSiglaEmpresa.MaxLength = 6;
            this.txtSiglaEmpresa.Name = "txtSiglaEmpresa";
            this.txtSiglaEmpresa.Size = new System.Drawing.Size(24, 20);
            this.txtSiglaEmpresa.TabIndex = 512;
            this.txtSiglaEmpresa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSiglaEmpresa.TextoVacio = "<Descripcion>";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(320, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(10, 13);
            this.label19.TabIndex = 513;
            this.label19.Text = "-";
            // 
            // frmEntradaAlmacenesLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 325);
            this.Name = "frmEntradaAlmacenesLote";
            this.Text = "Ingreso de Almacen Lotes";
            this.Load += new System.EventHandler(this.frmEntradaAlmacenesLote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboPaisProcedencia;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtLoteProveedor;
        public System.Windows.Forms.ComboBox cboPaisOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblDesFecha;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtPesoUnitario;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtLote;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpFecProceso;
        private ControlesWinForm.SuperTextBox txtIdProveedor;
        private System.Windows.Forms.Label label16;
        private ControlesWinForm.SuperTextBox txtproveedor;
        private ControlesWinForm.SuperTextBox txtRuc;
        private System.Windows.Forms.CheckBox chbindPersona;
        private System.Windows.Forms.CheckBox chbindfecProceso;
        private System.Windows.Forms.Label label14;
        private ControlesWinForm.SuperTextBox txtObservacion;
        private System.Windows.Forms.DateTimePicker dtpFecPrueba;
        private ControlesWinForm.SuperTextBox txtLoteAlmacen;
        private System.Windows.Forms.Label label18;
        private ControlesWinForm.SuperTextBox txtSiglaEmpresa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblLetras;
    }
}