namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmDetalleConceptoProvision
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label precioUnitarioLabel;
            System.Windows.Forms.Label cantidadLabel;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label idMonedaLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label codColumnaCovenLabel;
            System.Windows.Forms.Label codMonedaProvisionLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleConceptoProvision));
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.chkCalculos = new System.Windows.Forms.CheckBox();
            this.cboCoVen = new System.Windows.Forms.ComboBox();
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
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.txtTica = new ControlesWinForm.SuperTextBox();
            this.chkTica = new System.Windows.Forms.CheckBox();
            this.txtIdConcepto = new ControlesWinForm.SuperTextBox();
            this.btBuscarArticulo = new System.Windows.Forms.Button();
            this.txtCodConcepto = new ControlesWinForm.SuperTextBox();
            this.txtDesConcepto = new ControlesWinForm.SuperTextBox();
            this.txtIdCostos = new ControlesWinForm.SuperTextBox();
            this.txtDesCostos = new ControlesWinForm.SuperTextBox();
            this.btCostos = new System.Windows.Forms.Button();
            this.cboCuentas = new System.Windows.Forms.ComboBox();
            this.btDistribuir = new System.Windows.Forms.Button();
            this.chkHojaCosto = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            precioUnitarioLabel = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            idMonedaLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            codColumnaCovenLabel = new System.Windows.Forms.Label();
            codMonedaProvisionLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.pnlMontos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(1050, 335);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancelar.Size = new System.Drawing.Size(168, 42);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(868, 335);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAceptar.Size = new System.Drawing.Size(168, 42);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitPnlBase.Size = new System.Drawing.Size(836, 29);
            this.lblTitPnlBase.Text = "Datos Principales";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1245, 38);
            this.lblTituloPrincipal.Text = "Detalle Compras - Gastos y Servicios";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(1203, 3);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(codMonedaProvisionLabel1);
            this.pnlBase.Controls.Add(this.btCostos);
            this.pnlBase.Controls.Add(this.cboCuentas);
            this.pnlBase.Controls.Add(this.txtIdCostos);
            this.pnlBase.Controls.Add(this.txtDesCostos);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(label10);
            this.pnlBase.Controls.Add(this.txtIdConcepto);
            this.pnlBase.Controls.Add(this.btBuscarArticulo);
            this.pnlBase.Controls.Add(this.txtCodConcepto);
            this.pnlBase.Controls.Add(this.txtDesConcepto);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Location = new System.Drawing.Point(10, 43);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlBase.Size = new System.Drawing.Size(838, 187);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarArticulo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(label10, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesCostos, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdCostos, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboCuentas, 0);
            this.pnlBase.Controls.SetChildIndex(this.btCostos, 0);
            this.pnlBase.Controls.SetChildIndex(codMonedaProvisionLabel1, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(10, 148);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(150, 21);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(10, 114);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(162, 21);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(10, 46);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(133, 21);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(10, 80);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(121, 21);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.AutoSize = true;
            precioUnitarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            precioUnitarioLabel.Location = new System.Drawing.Point(54, 78);
            precioUnitarioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(90, 20);
            precioUnitarioLabel.TabIndex = 267;
            precioUnitarioLabel.Text = "Precio Unit.";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantidadLabel.Location = new System.Drawing.Point(273, 78);
            cantidadLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(73, 20);
            cantidadLabel.TabIndex = 261;
            cantidadLabel.Text = "Cantidad";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(16, 78);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(99, 20);
            label10.TabIndex = 286;
            label10.Text = "Descripción";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(16, 45);
            idArticuloLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(61, 20);
            idArticuloLabel.TabIndex = 283;
            idArticuloLabel.Text = "Código";
            // 
            // idMonedaLabel
            // 
            idMonedaLabel.AutoSize = true;
            idMonedaLabel.Location = new System.Drawing.Point(54, 45);
            idMonedaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            idMonedaLabel.Name = "idMonedaLabel";
            idMonedaLabel.Size = new System.Drawing.Size(67, 20);
            idMonedaLabel.TabIndex = 347;
            idMonedaLabel.Text = "Moneda";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(16, 151);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(78, 20);
            label6.TabIndex = 291;
            label6.Text = "C.Costos";
            // 
            // codColumnaCovenLabel
            // 
            codColumnaCovenLabel.AutoSize = true;
            codColumnaCovenLabel.Location = new System.Drawing.Point(362, 45);
            codColumnaCovenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codColumnaCovenLabel.Name = "codColumnaCovenLabel";
            codColumnaCovenLabel.Size = new System.Drawing.Size(114, 20);
            codColumnaCovenLabel.TabIndex = 353;
            codColumnaCovenLabel.Text = "Colum.Compra";
            // 
            // codMonedaProvisionLabel1
            // 
            codMonedaProvisionLabel1.AutoSize = true;
            codMonedaProvisionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codMonedaProvisionLabel1.Location = new System.Drawing.Point(16, 115);
            codMonedaProvisionLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codMonedaProvisionLabel1.Name = "codMonedaProvisionLabel1";
            codMonedaProvisionLabel1.Size = new System.Drawing.Size(99, 20);
            codMonedaProvisionLabel1.TabIndex = 376;
            codMonedaProvisionLabel1.Text = "Tipo Cuenta";
            // 
            // pnlAuditoria
            // 
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
            this.pnlAuditoria.Location = new System.Drawing.Point(852, 43);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(382, 187);
            this.pnlAuditoria.TabIndex = 258;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(380, 31);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(168, 142);
            this.txtFechaModifica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(196, 27);
            this.txtFechaModifica.TabIndex = 304;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(168, 40);
            this.txtUsuarioRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(196, 27);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(168, 108);
            this.txtUsuarioMod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(196, 27);
            this.txtUsuarioMod.TabIndex = 303;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(168, 74);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(196, 27);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // pnlMontos
            // 
            this.pnlMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMontos.Controls.Add(this.chkCalculos);
            this.pnlMontos.Controls.Add(this.cboCoVen);
            this.pnlMontos.Controls.Add(codColumnaCovenLabel);
            this.pnlMontos.Controls.Add(idMonedaLabel);
            this.pnlMontos.Controls.Add(this.chkIgv);
            this.pnlMontos.Controls.Add(this.txtPorIgv);
            this.pnlMontos.Controls.Add(this.txtIgv);
            this.pnlMontos.Controls.Add(this.label19);
            this.pnlMontos.Controls.Add(this.label21);
            this.pnlMontos.Controls.Add(this.txtCantidad);
            this.pnlMontos.Controls.Add(this.txtPrecio);
            this.pnlMontos.Controls.Add(this.txtTotal);
            this.pnlMontos.Controls.Add(this.txtSubTotal);
            this.pnlMontos.Controls.Add(this.label25);
            this.pnlMontos.Controls.Add(this.labelDegradado2);
            this.pnlMontos.Controls.Add(precioUnitarioLabel);
            this.pnlMontos.Controls.Add(cantidadLabel);
            this.pnlMontos.Controls.Add(this.cboMoneda);
            this.pnlMontos.Location = new System.Drawing.Point(10, 234);
            this.pnlMontos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(838, 150);
            this.pnlMontos.TabIndex = 374;
            // 
            // chkCalculos
            // 
            this.chkCalculos.Checked = true;
            this.chkCalculos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalculos.Location = new System.Drawing.Point(638, 117);
            this.chkCalculos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCalculos.Name = "chkCalculos";
            this.chkCalculos.Size = new System.Drawing.Size(194, 26);
            this.chkCalculos.TabIndex = 1569;
            this.chkCalculos.TabStop = false;
            this.chkCalculos.Text = "Cálculos Automáticos";
            this.chkCalculos.UseVisualStyleBackColor = true;
            this.chkCalculos.CheckedChanged += new System.EventHandler(this.chkCalculos_CheckedChanged);
            // 
            // cboCoVen
            // 
            this.cboCoVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoVen.DropDownWidth = 180;
            this.cboCoVen.FormattingEnabled = true;
            this.cboCoVen.Location = new System.Drawing.Point(476, 38);
            this.cboCoVen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCoVen.Name = "cboCoVen";
            this.cboCoVen.Size = new System.Drawing.Size(295, 28);
            this.cboCoVen.TabIndex = 7;
            this.cboCoVen.SelectionChangeCommitted += new System.EventHandler(this.cboCoVen_SelectionChangeCommitted);
            // 
            // chkIgv
            // 
            this.chkIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgv.Location = new System.Drawing.Point(692, 77);
            this.chkIgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(81, 26);
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
            this.txtPorIgv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPorIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorIgv.Enabled = false;
            this.txtPorIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorIgv.Location = new System.Drawing.Point(546, 72);
            this.txtPorIgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPorIgv.Name = "txtPorIgv";
            this.txtPorIgv.Size = new System.Drawing.Size(54, 26);
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
            this.txtIgv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIgv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIgv.Enabled = false;
            this.txtIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIgv.Location = new System.Drawing.Point(603, 72);
            this.txtIgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(79, 26);
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
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(476, 78);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 20);
            this.label19.TabIndex = 340;
            this.label19.Text = "% I.G.V.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(273, 111);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 20);
            this.label21.TabIndex = 332;
            this.label21.Text = "Total";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(354, 72);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(112, 26);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.Text = "1.00";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPrecio.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(152, 72);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(112, 26);
            this.txtPrecio.TabIndex = 8;
            this.txtPrecio.Text = "0.00000";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPrecio.TextoVacio = "<Descripcion>";
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // txtTotal
            // 
            this.txtTotal.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(354, 105);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(112, 26);
            this.txtTotal.TabIndex = 10;
            this.txtTotal.TabStop = false;
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
            this.txtSubTotal.Location = new System.Drawing.Point(152, 105);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(112, 26);
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
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(54, 111);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 20);
            this.label25.TabIndex = 314;
            this.label25.Text = "Valor Venta";
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(836, 29);
            this.labelDegradado2.TabIndex = 248;
            this.labelDegradado2.Text = "Montos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(152, 38);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(200, 28);
            this.cboMoneda.TabIndex = 6;
            // 
            // txtTica
            // 
            this.txtTica.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTica.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTica.Enabled = false;
            this.txtTica.Location = new System.Drawing.Point(1146, 248);
            this.txtTica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(85, 26);
            this.txtTica.TabIndex = 351;
            this.txtTica.Text = "0.000";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTica.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTica.TextoVacio = "<Descripcion>";
            this.txtTica.Visible = false;
            // 
            // chkTica
            // 
            this.chkTica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTica.Checked = true;
            this.chkTica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTica.Location = new System.Drawing.Point(1268, 278);
            this.chkTica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTica.Name = "chkTica";
            this.chkTica.Size = new System.Drawing.Size(130, 26);
            this.chkTica.TabIndex = 350;
            this.chkTica.Text = "Tipo Cam.";
            this.chkTica.UseVisualStyleBackColor = true;
            this.chkTica.Visible = false;
            this.chkTica.CheckedChanged += new System.EventHandler(this.chkTica_CheckedChanged);
            // 
            // txtIdConcepto
            // 
            this.txtIdConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdConcepto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdConcepto.Enabled = false;
            this.txtIdConcepto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdConcepto.Location = new System.Drawing.Point(117, 38);
            this.txtIdConcepto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdConcepto.Name = "txtIdConcepto";
            this.txtIdConcepto.Size = new System.Drawing.Size(79, 27);
            this.txtIdConcepto.TabIndex = 285;
            this.txtIdConcepto.TabStop = false;
            this.txtIdConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdConcepto.TextoVacio = "<Descripcion>";
            // 
            // btBuscarArticulo
            // 
            this.btBuscarArticulo.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btBuscarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarArticulo.Location = new System.Drawing.Point(381, 40);
            this.btBuscarArticulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBuscarArticulo.Name = "btBuscarArticulo";
            this.btBuscarArticulo.Size = new System.Drawing.Size(33, 29);
            this.btBuscarArticulo.TabIndex = 284;
            this.btBuscarArticulo.UseVisualStyleBackColor = true;
            this.btBuscarArticulo.Click += new System.EventHandler(this.btBuscarArticulo_Click);
            // 
            // txtCodConcepto
            // 
            this.txtCodConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodConcepto.BackColor = System.Drawing.Color.White;
            this.txtCodConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodConcepto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodConcepto.Location = new System.Drawing.Point(200, 38);
            this.txtCodConcepto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodConcepto.Name = "txtCodConcepto";
            this.txtCodConcepto.Size = new System.Drawing.Size(175, 27);
            this.txtCodConcepto.TabIndex = 1;
            this.txtCodConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodConcepto.TextoVacio = "<Descripcion>";
            this.txtCodConcepto.TextChanged += new System.EventHandler(this.txtCodConcepto_TextChanged);
            // 
            // txtDesConcepto
            // 
            this.txtDesConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesConcepto.BackColor = System.Drawing.Color.White;
            this.txtDesConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesConcepto.Location = new System.Drawing.Point(117, 74);
            this.txtDesConcepto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesConcepto.Name = "txtDesConcepto";
            this.txtDesConcepto.Size = new System.Drawing.Size(694, 26);
            this.txtDesConcepto.TabIndex = 2;
            this.txtDesConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesConcepto.TextoVacio = "<Descripcion>";
            this.txtDesConcepto.TextChanged += new System.EventHandler(this.txtDesConcepto_TextChanged);
            this.txtDesConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesConcepto_Validating);
            // 
            // txtIdCostos
            // 
            this.txtIdCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCostos.Enabled = false;
            this.txtIdCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCostos.Location = new System.Drawing.Point(117, 145);
            this.txtIdCostos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdCostos.Name = "txtIdCostos";
            this.txtIdCostos.Size = new System.Drawing.Size(84, 26);
            this.txtIdCostos.TabIndex = 4;
            this.txtIdCostos.TabStop = false;
            this.txtIdCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdCostos.TextoVacio = "<Descripcion>";
            this.txtIdCostos.TextChanged += new System.EventHandler(this.txtIdCostos_TextChanged);
            // 
            // txtDesCostos
            // 
            this.txtDesCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCostos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCostos.Enabled = false;
            this.txtDesCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCostos.Location = new System.Drawing.Point(204, 145);
            this.txtDesCostos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesCostos.Name = "txtDesCostos";
            this.txtDesCostos.Size = new System.Drawing.Size(571, 26);
            this.txtDesCostos.TabIndex = 5;
            this.txtDesCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCostos.TextoVacio = "<Descripcion>";
            // 
            // btCostos
            // 
            this.btCostos.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCostos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCostos.Enabled = false;
            this.btCostos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCostos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCostos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCostos.Location = new System.Drawing.Point(780, 146);
            this.btCostos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCostos.Name = "btCostos";
            this.btCostos.Size = new System.Drawing.Size(33, 28);
            this.btCostos.TabIndex = 293;
            this.btCostos.UseVisualStyleBackColor = true;
            this.btCostos.Click += new System.EventHandler(this.btCostos_Click);
            // 
            // cboCuentas
            // 
            this.cboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuentas.FormattingEnabled = true;
            this.cboCuentas.Location = new System.Drawing.Point(117, 109);
            this.cboCuentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCuentas.Name = "cboCuentas";
            this.cboCuentas.Size = new System.Drawing.Size(258, 28);
            this.cboCuentas.TabIndex = 3;
            this.cboCuentas.SelectionChangeCommitted += new System.EventHandler(this.cboCuentas_SelectionChangeCommitted);
            // 
            // btDistribuir
            // 
            this.btDistribuir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btDistribuir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btDistribuir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btDistribuir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDistribuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDistribuir.Image = ((System.Drawing.Image)(resources.GetObject("btDistribuir.Image")));
            this.btDistribuir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDistribuir.Location = new System.Drawing.Point(972, 289);
            this.btDistribuir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btDistribuir.Name = "btDistribuir";
            this.btDistribuir.Size = new System.Drawing.Size(152, 38);
            this.btDistribuir.TabIndex = 1568;
            this.btDistribuir.TabStop = false;
            this.btDistribuir.Text = "Distribuir";
            this.btDistribuir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDistribuir.UseVisualStyleBackColor = true;
            this.btDistribuir.Visible = false;
            this.btDistribuir.Click += new System.EventHandler(this.btDistribuir_Click);
            // 
            // chkHojaCosto
            // 
            this.chkHojaCosto.Checked = true;
            this.chkHojaCosto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHojaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHojaCosto.Location = new System.Drawing.Point(856, 242);
            this.chkHojaCosto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHojaCosto.Name = "chkHojaCosto";
            this.chkHojaCosto.Size = new System.Drawing.Size(250, 26);
            this.chkHojaCosto.TabIndex = 1569;
            this.chkHojaCosto.TabStop = false;
            this.chkHojaCosto.Text = "Usar en Hoja de Costo";
            this.chkHojaCosto.UseVisualStyleBackColor = true;
            // 
            // frmDetalleConceptoProvision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 391);
            this.Controls.Add(this.chkHojaCosto);
            this.Controls.Add(this.btDistribuir);
            this.Controls.Add(this.pnlMontos);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.txtTica);
            this.Controls.Add(this.chkTica);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmDetalleConceptoProvision";
            this.Text = "frmDetalleConceptoProvision";
            this.Load += new System.EventHandler(this.frmDetalleConceptoProvision_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.chkTica, 0);
            this.Controls.SetChildIndex(this.txtTica, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.pnlMontos, 0);
            this.Controls.SetChildIndex(this.btDistribuir, 0);
            this.Controls.SetChildIndex(this.chkHojaCosto, 0);
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
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel pnlMontos;
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
        private MyLabelG.LabelDegradado labelDegradado2;
        private ControlesWinForm.SuperTextBox txtIdConcepto;
        private System.Windows.Forms.Button btBuscarArticulo;
        private ControlesWinForm.SuperTextBox txtCodConcepto;
        private ControlesWinForm.SuperTextBox txtDesConcepto;
        private System.Windows.Forms.ComboBox cboMoneda;
        private ControlesWinForm.SuperTextBox txtTica;
        private System.Windows.Forms.CheckBox chkTica;
        private System.Windows.Forms.Button btCostos;
        private ControlesWinForm.SuperTextBox txtIdCostos;
        private ControlesWinForm.SuperTextBox txtDesCostos;
        private System.Windows.Forms.ComboBox cboCoVen;
        private System.Windows.Forms.ComboBox cboCuentas;
        private System.Windows.Forms.Button btDistribuir;
        private System.Windows.Forms.CheckBox chkCalculos;
        private System.Windows.Forms.CheckBox chkHojaCosto;
    }
}