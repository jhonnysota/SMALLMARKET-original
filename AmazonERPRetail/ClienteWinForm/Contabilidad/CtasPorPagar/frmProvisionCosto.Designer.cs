namespace ClienteWinForm.CtasPorPagar
{
    partial class frmProvisionCosto
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
            System.Windows.Forms.Label codCuentaLabel;
            System.Windows.Forms.Label codColumnaCovenLabel;
            System.Windows.Forms.Label idCCostosLabel;
            System.Windows.Forms.Label idMonedaLabel;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label precioUnitarioLabel;
            System.Windows.Forms.Label cantidadLabel;
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.txtIdCostos = new System.Windows.Forms.TextBox();
            this.txtDesCuenta = new System.Windows.Forms.TextBox();
            this.txtDesCostos = new System.Windows.Forms.TextBox();
            this.btn_Costo = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.cboCoVen = new System.Windows.Forms.ComboBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtIdArticulo = new ControlesWinForm.SuperTextBox();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.txtCodArticulo = new ControlesWinForm.SuperTextBox();
            this.txtDesArticulo = new ControlesWinForm.SuperTextBox();
            this.chkIgv = new System.Windows.Forms.CheckBox();
            this.txtPorIgv = new ControlesWinForm.SuperTextBox();
            this.txtIgv = new ControlesWinForm.SuperTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtPrecio = new ControlesWinForm.SuperTextBox();
            this.txtTotal = new ControlesWinForm.SuperTextBox();
            this.txtSubTotal = new ControlesWinForm.SuperTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.chkCalculos = new System.Windows.Forms.CheckBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.txtTica = new ControlesWinForm.SuperTextBox();
            this.chkPorRecibir = new System.Windows.Forms.CheckBox();
            this.chkIndAlmacen = new System.Windows.Forms.CheckBox();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.txtNotaIngreso = new ControlesWinForm.SuperTextBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.chkHojaCosto = new System.Windows.Forms.CheckBox();
            codCuentaLabel = new System.Windows.Forms.Label();
            codColumnaCovenLabel = new System.Windows.Forms.Label();
            idCCostosLabel = new System.Windows.Forms.Label();
            idMonedaLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            precioUnitarioLabel = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlMontos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(757, 18);
            this.lblTitPnlBase.Text = "Detalle";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(776, 25);
            this.lblTituloPrincipal.Text = "Detalle Compras";
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.CtasPorPagar.Provisiones_PorCCostoE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Image = global::ClienteWinForm.Properties.Resources.cerrar;
            this.btCerrar.Location = new System.Drawing.Point(747, 2);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.chkHojaCosto);
            this.pnlBase.Controls.Add(this.btnValidar);
            this.pnlBase.Controls.Add(this.txtNotaIngreso);
            this.pnlBase.Controls.Add(this.cboAlmacen);
            this.pnlBase.Controls.Add(this.chkIndAlmacen);
            this.pnlBase.Controls.Add(this.chkPorRecibir);
            this.pnlBase.Controls.Add(label10);
            this.pnlBase.Controls.Add(this.txtIdArticulo);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(this.txtCodArticulo);
            this.pnlBase.Controls.Add(this.txtDesArticulo);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Controls.Add(this.btn_Costo);
            this.pnlBase.Controls.Add(this.txtDesCostos);
            this.pnlBase.Controls.Add(idCCostosLabel);
            this.pnlBase.Controls.Add(this.txtIdCostos);
            this.pnlBase.Location = new System.Drawing.Point(8, 29);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBase.Size = new System.Drawing.Size(759, 136);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdCostos, 0);
            this.pnlBase.Controls.SetChildIndex(idCCostosLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesCostos, 0);
            this.pnlBase.Controls.SetChildIndex(this.btn_Costo, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(label10, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkPorRecibir, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkIndAlmacen, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboAlmacen, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNotaIngreso, 0);
            this.pnlBase.Controls.SetChildIndex(this.btnValidar, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkHojaCosto, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(398, 292);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btCancelar.Size = new System.Drawing.Size(124, 29);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(259, 292);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btAceptar.Size = new System.Drawing.Size(124, 29);
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Location = new System.Drawing.Point(524, 317);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(41, 13);
            codCuentaLabel.TabIndex = 250;
            codCuentaLabel.Text = "Cuenta";
            codCuentaLabel.Visible = false;
            // 
            // codColumnaCovenLabel
            // 
            codColumnaCovenLabel.AutoSize = true;
            codColumnaCovenLabel.Location = new System.Drawing.Point(201, 36);
            codColumnaCovenLabel.Name = "codColumnaCovenLabel";
            codColumnaCovenLabel.Size = new System.Drawing.Size(75, 13);
            codColumnaCovenLabel.TabIndex = 252;
            codColumnaCovenLabel.Text = "Colum.Compra";
            // 
            // idCCostosLabel
            // 
            idCCostosLabel.AutoSize = true;
            idCCostosLabel.Location = new System.Drawing.Point(13, 90);
            idCCostosLabel.Name = "idCCostosLabel";
            idCCostosLabel.Size = new System.Drawing.Size(44, 13);
            idCCostosLabel.TabIndex = 253;
            idCCostosLabel.Text = "C.Costo";
            // 
            // idMonedaLabel
            // 
            idMonedaLabel.AutoSize = true;
            idMonedaLabel.Location = new System.Drawing.Point(8, 37);
            idMonedaLabel.Name = "idMonedaLabel";
            idMonedaLabel.Size = new System.Drawing.Size(46, 13);
            idMonedaLabel.TabIndex = 254;
            idMonedaLabel.Text = "Moneda";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(11, 48);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(11, 27);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(11, 69);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 90);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(13, 61);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(63, 13);
            label10.TabIndex = 349;
            label10.Text = "Descripción";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(13, 32);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(40, 13);
            idArticuloLabel.TabIndex = 346;
            idArticuloLabel.Text = "Código";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.AutoSize = true;
            precioUnitarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            precioUnitarioLabel.Location = new System.Drawing.Point(9, 59);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(62, 13);
            precioUnitarioLabel.TabIndex = 354;
            precioUnitarioLabel.Text = "Precio Unit.";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantidadLabel.Location = new System.Drawing.Point(154, 59);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(49, 13);
            cantidadLabel.TabIndex = 353;
            cantidadLabel.Text = "Cantidad";
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodCuenta.Enabled = false;
            this.txtCodCuenta.Location = new System.Drawing.Point(571, 314);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.ReadOnly = true;
            this.txtCodCuenta.Size = new System.Drawing.Size(82, 20);
            this.txtCodCuenta.TabIndex = 251;
            this.txtCodCuenta.TabStop = false;
            this.txtCodCuenta.Visible = false;
            // 
            // txtIdCostos
            // 
            this.txtIdCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCostos.Enabled = false;
            this.txtIdCostos.Location = new System.Drawing.Point(79, 86);
            this.txtIdCostos.Name = "txtIdCostos";
            this.txtIdCostos.ReadOnly = true;
            this.txtIdCostos.Size = new System.Drawing.Size(82, 20);
            this.txtIdCostos.TabIndex = 4;
            this.txtIdCostos.TextChanged += new System.EventHandler(this.txtIdCostos_TextChanged);
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCuenta.Enabled = false;
            this.txtDesCuenta.Location = new System.Drawing.Point(654, 314);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.ReadOnly = true;
            this.txtDesCuenta.Size = new System.Drawing.Size(102, 20);
            this.txtDesCuenta.TabIndex = 262;
            this.txtDesCuenta.TabStop = false;
            this.txtDesCuenta.Visible = false;
            // 
            // txtDesCostos
            // 
            this.txtDesCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCostos.Enabled = false;
            this.txtDesCostos.Location = new System.Drawing.Point(162, 86);
            this.txtDesCostos.Name = "txtDesCostos";
            this.txtDesCostos.ReadOnly = true;
            this.txtDesCostos.Size = new System.Drawing.Size(361, 20);
            this.txtDesCostos.TabIndex = 5;
            // 
            // btn_Costo
            // 
            this.btn_Costo.Enabled = false;
            this.btn_Costo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Costo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_Costo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Costo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Costo.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btn_Costo.Location = new System.Drawing.Point(526, 87);
            this.btn_Costo.Name = "btn_Costo";
            this.btn_Costo.Size = new System.Drawing.Size(25, 18);
            this.btn_Costo.TabIndex = 337;
            this.btn_Costo.TabStop = false;
            this.btn_Costo.UseVisualStyleBackColor = true;
            this.btn_Costo.Click += new System.EventHandler(this.btn_Costo_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(76, 32);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // cboCoVen
            // 
            this.cboCoVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoVen.FormattingEnabled = true;
            this.cboCoVen.Location = new System.Drawing.Point(280, 32);
            this.cboCoVen.Name = "cboCoVen";
            this.cboCoVen.Size = new System.Drawing.Size(147, 21);
            this.cboCoVen.TabIndex = 7;
            this.cboCoVen.SelectionChangeCommitted += new System.EventHandler(this.cboCoVen_SelectionChangeCommitted);
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(119, 44);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(135, 20);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(119, 65);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(135, 20);
            this.txtUsuarioMod.TabIndex = 303;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(119, 23);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(135, 20);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(119, 86);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(135, 20);
            this.txtFechaModifica.TabIndex = 304;
            this.txtFechaModifica.TabStop = false;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(266, 18);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(499, 167);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(268, 115);
            this.pnlAuditoria.TabIndex = 258;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdArticulo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(79, 28);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(54, 21);
            this.txtIdArticulo.TabIndex = 348;
            this.txtIdArticulo.TabStop = false;
            this.txtIdArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdArticulo.TextoVacio = "<Descripcion>";
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Location = new System.Drawing.Point(232, 29);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(22, 19);
            this.btBuscarArticulo.TabIndex = 347;
            this.btBuscarArticulo.TabStop = false;
            this.btBuscarArticulo.UseVisualStyleBackColor = true;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodArticulo.BackColor = System.Drawing.Color.White;
            this.txtCodArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodArticulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodArticulo.Location = new System.Drawing.Point(135, 28);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(95, 21);
            this.txtCodArticulo.TabIndex = 1;
            this.txtCodArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodArticulo.TextoVacio = "<Descripcion>";
            this.txtCodArticulo.TextChanged += new System.EventHandler(this.txtCodArticulo_TextChanged);
            // 
            // txtDesArticulo
            // 
            this.txtDesArticulo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesArticulo.BackColor = System.Drawing.Color.White;
            this.txtDesArticulo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesArticulo.Location = new System.Drawing.Point(79, 51);
            this.txtDesArticulo.Multiline = true;
            this.txtDesArticulo.Name = "txtDesArticulo";
            this.txtDesArticulo.Size = new System.Drawing.Size(472, 33);
            this.txtDesArticulo.TabIndex = 2;
            this.txtDesArticulo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesArticulo.TextoVacio = "<Descripcion>";
            this.txtDesArticulo.TextChanged += new System.EventHandler(this.txtDesArticulo_TextChanged);
            // 
            // chkIgv
            // 
            this.chkIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgv.Location = new System.Drawing.Point(432, 57);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(54, 17);
            this.chkIgv.TabIndex = 361;
            this.chkIgv.TabStop = false;
            this.chkIgv.Text = "I.G.V.";
            this.chkIgv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIgv.UseVisualStyleBackColor = true;
            this.chkIgv.CheckedChanged += new System.EventHandler(this.chkIgv_CheckedChanged);
            // 
            // txtPorIgv
            // 
            this.txtPorIgv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorIgv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPorIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorIgv.Enabled = false;
            this.txtPorIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorIgv.Location = new System.Drawing.Point(336, 55);
            this.txtPorIgv.Name = "txtPorIgv";
            this.txtPorIgv.Size = new System.Drawing.Size(37, 20);
            this.txtPorIgv.TabIndex = 10;
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
            this.txtIgv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIgv.Enabled = false;
            this.txtIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIgv.Location = new System.Drawing.Point(373, 55);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(54, 20);
            this.txtIgv.TabIndex = 11;
            this.txtIgv.Text = "0.00";
            this.txtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIgv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtIgv.TextoVacio = "<Descripcion>";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(289, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 360;
            this.label19.Text = "% I.G.V.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(154, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 358;
            this.label21.Text = "Total";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(211, 55);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(76, 20);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.Text = "1.00";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecio.BackColor = System.Drawing.Color.White;
            this.txtPrecio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(76, 55);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(76, 20);
            this.txtPrecio.TabIndex = 8;
            this.txtPrecio.Text = "0.00000";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecio.TextoVacio = "<Descripcion>";
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(211, 77);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(76, 20);
            this.txtTotal.TabIndex = 13;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotal.TextoVacio = "<Descripcion>";
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSubTotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSubTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(76, 77);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(76, 20);
            this.txtSubTotal.TabIndex = 12;
            this.txtSubTotal.Text = "0.00";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtSubTotal.TextoVacio = "<Descripcion>";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 81);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 13);
            this.label25.TabIndex = 355;
            this.label25.Text = "Valor Venta";
            // 
            // pnlMontos
            // 
            this.pnlMontos.BackColor = System.Drawing.Color.Transparent;
            this.pnlMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMontos.Controls.Add(this.chkCalculos);
            this.pnlMontos.Controls.Add(this.chkIgv);
            this.pnlMontos.Controls.Add(this.labelDegradado2);
            this.pnlMontos.Controls.Add(this.txtPorIgv);
            this.pnlMontos.Controls.Add(this.cboMoneda);
            this.pnlMontos.Controls.Add(this.txtIgv);
            this.pnlMontos.Controls.Add(codColumnaCovenLabel);
            this.pnlMontos.Controls.Add(this.label19);
            this.pnlMontos.Controls.Add(idMonedaLabel);
            this.pnlMontos.Controls.Add(this.label21);
            this.pnlMontos.Controls.Add(this.cboCoVen);
            this.pnlMontos.Controls.Add(this.txtCantidad);
            this.pnlMontos.Controls.Add(cantidadLabel);
            this.pnlMontos.Controls.Add(this.txtPrecio);
            this.pnlMontos.Controls.Add(precioUnitarioLabel);
            this.pnlMontos.Controls.Add(this.txtTotal);
            this.pnlMontos.Controls.Add(this.label25);
            this.pnlMontos.Controls.Add(this.txtSubTotal);
            this.pnlMontos.Location = new System.Drawing.Point(8, 167);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(488, 115);
            this.pnlMontos.TabIndex = 375;
            // 
            // chkCalculos
            // 
            this.chkCalculos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCalculos.Checked = true;
            this.chkCalculos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalculos.Location = new System.Drawing.Point(298, 80);
            this.chkCalculos.Name = "chkCalculos";
            this.chkCalculos.Size = new System.Drawing.Size(129, 17);
            this.chkCalculos.TabIndex = 362;
            this.chkCalculos.TabStop = false;
            this.chkCalculos.Text = "Cálculos Automáticos";
            this.chkCalculos.UseVisualStyleBackColor = true;
            this.chkCalculos.CheckedChanged += new System.EventHandler(this.chkCalculos_CheckedChanged);
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(486, 18);
            this.labelDegradado2.TabIndex = 248;
            this.labelDegradado2.Text = "Montos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTica
            // 
            this.txtTica.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTica.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTica.Enabled = false;
            this.txtTica.Location = new System.Drawing.Point(697, 292);
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(58, 20);
            this.txtTica.TabIndex = 376;
            this.txtTica.TabStop = false;
            this.txtTica.Text = "0.000";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTica.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTica.TextoVacio = "<Descripcion>";
            this.txtTica.Visible = false;
            // 
            // chkPorRecibir
            // 
            this.chkPorRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPorRecibir.Location = new System.Drawing.Point(262, 32);
            this.chkPorRecibir.Name = "chkPorRecibir";
            this.chkPorRecibir.Size = new System.Drawing.Size(129, 17);
            this.chkPorRecibir.TabIndex = 363;
            this.chkPorRecibir.TabStop = false;
            this.chkPorRecibir.Text = "Existencia Por Recibir";
            this.chkPorRecibir.UseVisualStyleBackColor = true;
            // 
            // chkIndAlmacen
            // 
            this.chkIndAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndAlmacen.Location = new System.Drawing.Point(444, 32);
            this.chkIndAlmacen.Name = "chkIndAlmacen";
            this.chkIndAlmacen.Size = new System.Drawing.Size(106, 17);
            this.chkIndAlmacen.TabIndex = 364;
            this.chkIndAlmacen.TabStop = false;
            this.chkIndAlmacen.Text = "Costo Al Articulo";
            this.chkIndAlmacen.UseVisualStyleBackColor = true;
            this.chkIndAlmacen.CheckedChanged += new System.EventHandler(this.chkIndAlmacen_CheckedChanged);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(555, 28);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(182, 21);
            this.cboAlmacen.TabIndex = 365;
            // 
            // txtNotaIngreso
            // 
            this.txtNotaIngreso.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNotaIngreso.BackColor = System.Drawing.Color.White;
            this.txtNotaIngreso.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNotaIngreso.Enabled = false;
            this.txtNotaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotaIngreso.Location = new System.Drawing.Point(555, 51);
            this.txtNotaIngreso.MaxLength = 200;
            this.txtNotaIngreso.Multiline = true;
            this.txtNotaIngreso.Name = "txtNotaIngreso";
            this.txtNotaIngreso.Size = new System.Drawing.Size(182, 33);
            this.txtNotaIngreso.TabIndex = 200;
            this.txtNotaIngreso.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNotaIngreso.TextoVacio = "<Descripcion>";
            // 
            // btnValidar
            // 
            this.btnValidar.Enabled = false;
            this.btnValidar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnValidar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnValidar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btnValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValidar.Location = new System.Drawing.Point(614, 88);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(70, 21);
            this.btnValidar.TabIndex = 377;
            this.btnValidar.Text = "Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // chkHojaCosto
            // 
            this.chkHojaCosto.Checked = true;
            this.chkHojaCosto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHojaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHojaCosto.Location = new System.Drawing.Point(79, 112);
            this.chkHojaCosto.Name = "chkHojaCosto";
            this.chkHojaCosto.Size = new System.Drawing.Size(167, 17);
            this.chkHojaCosto.TabIndex = 378;
            this.chkHojaCosto.TabStop = false;
            this.chkHojaCosto.Text = "Usar en Hoja de Costo";
            this.chkHojaCosto.UseVisualStyleBackColor = true;
            // 
            // frmProvisionCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 333);
            this.Controls.Add(this.txtTica);
            this.Controls.Add(this.pnlMontos);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.txtDesCuenta);
            this.Controls.Add(this.txtCodCuenta);
            this.Controls.Add(codCuentaLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProvisionCosto";
            this.Text = "frmProvisionCosto";
            this.Load += new System.EventHandler(this.frmProvisionCosto_Load);
            this.Controls.SetChildIndex(codCuentaLabel, 0);
            this.Controls.SetChildIndex(this.txtCodCuenta, 0);
            this.Controls.SetChildIndex(this.txtDesCuenta, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlMontos, 0);
            this.Controls.SetChildIndex(this.txtTica, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlMontos.ResumeLayout(false);
            this.pnlMontos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.TextBox txtIdCostos;
        private System.Windows.Forms.TextBox txtDesCostos;
        private System.Windows.Forms.TextBox txtDesCuenta;
        private System.Windows.Forms.Button btn_Costo;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.ComboBox cboCoVen;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.Panel pnlAuditoria;
        private ControlesWinForm.SuperTextBox txtIdArticulo;
        private System.Windows.Forms.Button btBuscarArticulo;
        private ControlesWinForm.SuperTextBox txtCodArticulo;
        private ControlesWinForm.SuperTextBox txtDesArticulo;
        private System.Windows.Forms.CheckBox chkIgv;
        private ControlesWinForm.SuperTextBox txtPorIgv;
        private ControlesWinForm.SuperTextBox txtIgv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtPrecio;
        private ControlesWinForm.SuperTextBox txtTotal;
        private ControlesWinForm.SuperTextBox txtSubTotal;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel pnlMontos;
        private MyLabelG.LabelDegradado labelDegradado2;
        private ControlesWinForm.SuperTextBox txtTica;
        private System.Windows.Forms.CheckBox chkCalculos;
        private System.Windows.Forms.CheckBox chkPorRecibir;
        private System.Windows.Forms.CheckBox chkIndAlmacen;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private ControlesWinForm.SuperTextBox txtNotaIngreso;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.CheckBox chkHojaCosto;
    }
}