namespace ClienteWinForm.Tesoreria
{
    partial class frmDetalleSolicitudProv
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label idArticuloLabel;
            System.Windows.Forms.Label cantidadLabel;
            System.Windows.Forms.Label label7;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtIdConcepto = new ControlesWinForm.SuperTextBox();
            this.btConceptos = new System.Windows.Forms.Button();
            this.txtCodConcepto = new ControlesWinForm.SuperTextBox();
            this.txtDesConcepto = new ControlesWinForm.SuperTextBox();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.txtImporte = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImpuesto = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPorImpuesto = new ControlesWinForm.SuperTextBox();
            this.chkRetencion = new System.Windows.Forms.CheckBox();
            this.chkDetraccion = new System.Windows.Forms.CheckBox();
            this.chkIgv = new System.Windows.Forms.CheckBox();
            this.txtPorIgv = new ControlesWinForm.SuperTextBox();
            this.txtIgv = new ControlesWinForm.SuperTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtTotalImporte = new ControlesWinForm.SuperTextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            idArticuloLabel = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
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
            this.btCancelar.Location = new System.Drawing.Point(625, 168);
            this.btCancelar.Size = new System.Drawing.Size(114, 28);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(501, 168);
            this.btAceptar.Size = new System.Drawing.Size(114, 28);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(482, 18);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(756, 24);
            this.lblTituloPrincipal.Text = "Solicitud - Detalle";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(727, 2);
            this.btCerrar.Size = new System.Drawing.Size(25, 20);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(label10);
            this.pnlBase.Controls.Add(this.txtIdConcepto);
            this.pnlBase.Controls.Add(this.btConceptos);
            this.pnlBase.Controls.Add(this.txtCodConcepto);
            this.pnlBase.Controls.Add(this.txtDesConcepto);
            this.pnlBase.Controls.Add(idArticuloLabel);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(484, 82);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(idArticuloLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.btConceptos, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(label10, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(7, 95);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(7, 73);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(7, 29);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(7, 51);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(12, 55);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(63, 13);
            label10.TabIndex = 292;
            label10.Text = "Descripción";
            // 
            // idArticuloLabel
            // 
            idArticuloLabel.AutoSize = true;
            idArticuloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idArticuloLabel.Location = new System.Drawing.Point(12, 34);
            idArticuloLabel.Name = "idArticuloLabel";
            idArticuloLabel.Size = new System.Drawing.Size(40, 13);
            idArticuloLabel.TabIndex = 289;
            idArticuloLabel.Text = "Código";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cantidadLabel.Location = new System.Drawing.Point(25, 31);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(49, 13);
            cantidadLabel.TabIndex = 261;
            cantidadLabel.Text = "Cantidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(136, 31);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(42, 13);
            label7.TabIndex = 354;
            label7.Text = "Importe";
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
            this.pnlAuditoria.Location = new System.Drawing.Point(494, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(255, 122);
            this.pnlAuditoria.TabIndex = 259;
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
            this.labelDegradado4.Size = new System.Drawing.Size(253, 18);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(112, 91);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(132, 21);
            this.txtFechaModifica.TabIndex = 304;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(112, 25);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(132, 21);
            this.txtUsuarioRegistro.TabIndex = 300;
            this.txtUsuarioRegistro.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(112, 69);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(132, 21);
            this.txtUsuarioMod.TabIndex = 303;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(112, 47);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(132, 21);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtIdConcepto
            // 
            this.txtIdConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdConcepto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdConcepto.Enabled = false;
            this.txtIdConcepto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdConcepto.Location = new System.Drawing.Point(79, 30);
            this.txtIdConcepto.Name = "txtIdConcepto";
            this.txtIdConcepto.Size = new System.Drawing.Size(54, 21);
            this.txtIdConcepto.TabIndex = 291;
            this.txtIdConcepto.TabStop = false;
            this.txtIdConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtIdConcepto.TextoVacio = "<Descripcion>";
            // 
            // btConceptos
            // 
            this.btConceptos.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btConceptos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btConceptos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConceptos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btConceptos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btConceptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConceptos.Location = new System.Drawing.Point(231, 31);
            this.btConceptos.Name = "btConceptos";
            this.btConceptos.Size = new System.Drawing.Size(22, 19);
            this.btConceptos.TabIndex = 290;
            this.btConceptos.UseVisualStyleBackColor = true;
            this.btConceptos.Click += new System.EventHandler(this.btConceptos_Click);
            // 
            // txtCodConcepto
            // 
            this.txtCodConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodConcepto.BackColor = System.Drawing.Color.White;
            this.txtCodConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodConcepto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodConcepto.Location = new System.Drawing.Point(134, 30);
            this.txtCodConcepto.Name = "txtCodConcepto";
            this.txtCodConcepto.Size = new System.Drawing.Size(95, 21);
            this.txtCodConcepto.TabIndex = 287;
            this.txtCodConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodConcepto.TextoVacio = "<Descripcion>";
            // 
            // txtDesConcepto
            // 
            this.txtDesConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesConcepto.BackColor = System.Drawing.Color.White;
            this.txtDesConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesConcepto.Location = new System.Drawing.Point(79, 52);
            this.txtDesConcepto.Name = "txtDesConcepto";
            this.txtDesConcepto.Size = new System.Drawing.Size(384, 20);
            this.txtDesConcepto.TabIndex = 288;
            this.txtDesConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesConcepto.TextoVacio = "<Descripcion>";
            // 
            // pnlMontos
            // 
            this.pnlMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMontos.Controls.Add(this.txtImporte);
            this.pnlMontos.Controls.Add(label7);
            this.pnlMontos.Controls.Add(this.label6);
            this.pnlMontos.Controls.Add(this.txtImpuesto);
            this.pnlMontos.Controls.Add(this.label2);
            this.pnlMontos.Controls.Add(this.txtPorImpuesto);
            this.pnlMontos.Controls.Add(this.chkRetencion);
            this.pnlMontos.Controls.Add(this.chkDetraccion);
            this.pnlMontos.Controls.Add(this.chkIgv);
            this.pnlMontos.Controls.Add(this.txtPorIgv);
            this.pnlMontos.Controls.Add(this.txtIgv);
            this.pnlMontos.Controls.Add(this.label19);
            this.pnlMontos.Controls.Add(this.label21);
            this.pnlMontos.Controls.Add(this.txtCantidad);
            this.pnlMontos.Controls.Add(this.txtTotalImporte);
            this.pnlMontos.Controls.Add(this.labelDegradado2);
            this.pnlMontos.Controls.Add(cantidadLabel);
            this.pnlMontos.Location = new System.Drawing.Point(7, 113);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(484, 101);
            this.pnlMontos.TabIndex = 375;
            // 
            // txtImporte
            // 
            this.txtImporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(184, 27);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(78, 20);
            this.txtImporte.TabIndex = 353;
            this.txtImporte.Text = "0.00";
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporte.TextoVacio = "<Descripcion>";
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(329, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 352;
            this.label6.Text = "Importe";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImpuesto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtImpuesto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImpuesto.Enabled = false;
            this.txtImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpuesto.Location = new System.Drawing.Point(374, 72);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(76, 20);
            this.txtImpuesto.TabIndex = 351;
            this.txtImpuesto.TabStop = false;
            this.txtImpuesto.Text = "0.00";
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImpuesto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImpuesto.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 350;
            this.label2.Text = "% Impuesto";
            // 
            // txtPorImpuesto
            // 
            this.txtPorImpuesto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorImpuesto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPorImpuesto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorImpuesto.Enabled = false;
            this.txtPorImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorImpuesto.Location = new System.Drawing.Point(261, 72);
            this.txtPorImpuesto.Name = "txtPorImpuesto";
            this.txtPorImpuesto.Size = new System.Drawing.Size(64, 20);
            this.txtPorImpuesto.TabIndex = 349;
            this.txtPorImpuesto.TabStop = false;
            this.txtPorImpuesto.Text = "0.00";
            this.txtPorImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorImpuesto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtPorImpuesto.TextoVacio = "<Descripcion>";
            this.txtPorImpuesto.TextChanged += new System.EventHandler(this.txtPorImpuesto_TextChanged);
            // 
            // chkRetencion
            // 
            this.chkRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRetencion.Enabled = false;
            this.chkRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencion.Location = new System.Drawing.Point(113, 74);
            this.chkRetencion.Name = "chkRetencion";
            this.chkRetencion.Size = new System.Drawing.Size(78, 17);
            this.chkRetencion.TabIndex = 348;
            this.chkRetencion.TabStop = false;
            this.chkRetencion.Text = "Retención";
            this.chkRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRetencion.UseVisualStyleBackColor = true;
            // 
            // chkDetraccion
            // 
            this.chkDetraccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDetraccion.Enabled = false;
            this.chkDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetraccion.Location = new System.Drawing.Point(16, 74);
            this.chkDetraccion.Name = "chkDetraccion";
            this.chkDetraccion.Size = new System.Drawing.Size(84, 17);
            this.chkDetraccion.TabIndex = 347;
            this.chkDetraccion.TabStop = false;
            this.chkDetraccion.Text = "Detracción";
            this.chkDetraccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDetraccion.UseVisualStyleBackColor = true;
            // 
            // chkIgv
            // 
            this.chkIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgv.Location = new System.Drawing.Point(177, 52);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(54, 17);
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
            this.txtPorIgv.Location = new System.Drawing.Point(86, 50);
            this.txtPorIgv.Name = "txtPorIgv";
            this.txtPorIgv.Size = new System.Drawing.Size(37, 20);
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
            this.txtIgv.Location = new System.Drawing.Point(126, 50);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(46, 20);
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
            this.label19.Location = new System.Drawing.Point(25, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 340;
            this.label19.Text = "% I.G.V.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(276, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 332;
            this.label21.Text = "Importe Total";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(86, 27);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(42, 20);
            this.txtCantidad.TabIndex = 10;
            this.txtCantidad.Text = "1.00";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtTotalImporte
            // 
            this.txtTotalImporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTotalImporte.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalImporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTotalImporte.Enabled = false;
            this.txtTotalImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalImporte.Location = new System.Drawing.Point(348, 50);
            this.txtTotalImporte.Name = "txtTotalImporte";
            this.txtTotalImporte.Size = new System.Drawing.Size(102, 20);
            this.txtTotalImporte.TabIndex = 322;
            this.txtTotalImporte.TabStop = false;
            this.txtTotalImporte.Text = "0.00";
            this.txtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalImporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTotalImporte.TextoVacio = "<Descripcion>";
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
            this.labelDegradado2.Size = new System.Drawing.Size(482, 18);
            this.labelDegradado2.TabIndex = 248;
            this.labelDegradado2.Text = "Montos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDetalleSolicitudProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 219);
            this.Controls.Add(this.pnlMontos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleSolicitudProv";
            this.Text = "frmDetalleSolicitudProv";
            this.Load += new System.EventHandler(this.frmDetalleSolicitudProv_Load);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private ControlesWinForm.SuperTextBox txtIdConcepto;
        private System.Windows.Forms.Button btConceptos;
        private ControlesWinForm.SuperTextBox txtCodConcepto;
        private ControlesWinForm.SuperTextBox txtDesConcepto;
        private System.Windows.Forms.Panel pnlMontos;
        private System.Windows.Forms.CheckBox chkIgv;
        private ControlesWinForm.SuperTextBox txtPorIgv;
        private ControlesWinForm.SuperTextBox txtIgv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtTotalImporte;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtImpuesto;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtPorImpuesto;
        private System.Windows.Forms.CheckBox chkRetencion;
        private System.Windows.Forms.CheckBox chkDetraccion;
        private ControlesWinForm.SuperTextBox txtImporte;
    }
}