namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmLiquidacionImportacionDetalle
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label numDocumentoLabel;
            this.pnlReparable = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRefRepa = new ControlesWinForm.SuperTextBox();
            this.cboConceptoReparable = new System.Windows.Forms.ComboBox();
            this.cboReparable = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labelDegradado10 = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.cboMonedaRec = new System.Windows.Forms.ComboBox();
            this.txtMontoRec = new ControlesWinForm.SuperTextBox();
            this.txtCodConcepto = new ControlesWinForm.SuperTextBox();
            this.txtDesConcepto = new ControlesWinForm.SuperTextBox();
            this.btConceptos = new System.Windows.Forms.Button();
            this.txtRuc = new ControlesWinForm.SuperTextBox();
            this.txtRazonSocial = new ControlesWinForm.SuperTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTica = new ControlesWinForm.SuperTextBox();
            this.chkIndTicaAuto = new System.Windows.Forms.CheckBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMontoDoc = new ControlesWinForm.SuperTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecDoc = new System.Windows.Forms.DateTimePicker();
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.txtSerie = new ControlesWinForm.SuperTextBox();
            this.txtNumero = new ControlesWinForm.SuperTextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            numDocumentoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlReparable.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(746, 166);
            this.btCancelar.Size = new System.Drawing.Size(108, 29);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(630, 166);
            this.btAceptar.Size = new System.Drawing.Size(108, 29);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(596, 18);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(877, 25);
            this.lblTituloPrincipal.Text = "Detalle de Liquidación de Importación";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(848, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.cboMonedaRec);
            this.pnlBase.Controls.Add(this.txtMontoRec);
            this.pnlBase.Controls.Add(label11);
            this.pnlBase.Controls.Add(this.txtCodConcepto);
            this.pnlBase.Controls.Add(this.txtDesConcepto);
            this.pnlBase.Controls.Add(this.btConceptos);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.txtRuc);
            this.pnlBase.Controls.Add(this.txtRazonSocial);
            this.pnlBase.Controls.Add(this.label22);
            this.pnlBase.Controls.Add(this.txtTica);
            this.pnlBase.Controls.Add(this.chkIndTicaAuto);
            this.pnlBase.Controls.Add(label19);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.txtMontoDoc);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(this.dtpFecDoc);
            this.pnlBase.Controls.Add(label3);
            this.pnlBase.Controls.Add(numDocumentoLabel);
            this.pnlBase.Controls.Add(this.cboDocumento);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Controls.Add(this.txtNumero);
            this.pnlBase.Location = new System.Drawing.Point(8, 28);
            this.pnlBase.Size = new System.Drawing.Size(598, 122);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumero, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(numDocumentoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFecDoc, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMontoDoc, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(label19, 0);
            this.pnlBase.Controls.SetChildIndex(this.chkIndTicaAuto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtTica, 0);
            this.pnlBase.Controls.SetChildIndex(this.label22, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRazonSocial, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtRuc, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.btConceptos, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCodConcepto, 0);
            this.pnlBase.Controls.SetChildIndex(label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMontoRec, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMonedaRec, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(7, 95);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(97, 13);
            label5.TabIndex = 6;
            label5.Text = "Fecha Modificación";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(7, 73);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(104, 13);
            label6.TabIndex = 4;
            label6.Text = "Usuario Modificación";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(7, 29);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(86, 13);
            label8.TabIndex = 0;
            label8.Text = "Usuario Registro";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(7, 51);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(79, 13);
            label9.TabIndex = 2;
            label9.Text = "Fecha Registro";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(9, 97);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(53, 13);
            label11.TabIndex = 1603;
            label11.Text = "Concepto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(249, 74);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 13);
            label2.TabIndex = 1600;
            label2.Text = "Mon. Rec.";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(10, 74);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(56, 13);
            label19.TabIndex = 1597;
            label19.Text = "Mon. Doc.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(249, 51);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 13);
            label1.TabIndex = 1594;
            label1.Text = "Fecha Doc.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(10, 51);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(50, 13);
            label3.TabIndex = 1593;
            label3.Text = "Nro. Doc";
            // 
            // numDocumentoLabel
            // 
            numDocumentoLabel.AutoSize = true;
            numDocumentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numDocumentoLabel.Location = new System.Drawing.Point(10, 28);
            numDocumentoLabel.Name = "numDocumentoLabel";
            numDocumentoLabel.Size = new System.Drawing.Size(62, 13);
            numDocumentoLabel.TabIndex = 1592;
            numDocumentoLabel.Text = "Documento";
            // 
            // pnlReparable
            // 
            this.pnlReparable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReparable.Controls.Add(this.label10);
            this.pnlReparable.Controls.Add(this.txtRefRepa);
            this.pnlReparable.Controls.Add(this.cboConceptoReparable);
            this.pnlReparable.Controls.Add(this.cboReparable);
            this.pnlReparable.Controls.Add(this.label16);
            this.pnlReparable.Controls.Add(this.labelDegradado10);
            this.pnlReparable.Enabled = false;
            this.pnlReparable.Location = new System.Drawing.Point(8, 152);
            this.pnlReparable.Name = "pnlReparable";
            this.pnlReparable.Size = new System.Drawing.Size(598, 77);
            this.pnlReparable.TabIndex = 1104;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 330;
            this.label10.Text = "Tipo";
            // 
            // txtRefRepa
            // 
            this.txtRefRepa.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.TextoAutoexplicativo;
            this.txtRefRepa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRefRepa.ColorTextoVacio = System.Drawing.Color.SlateGray;
            this.txtRefRepa.Enabled = false;
            this.txtRefRepa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefRepa.Location = new System.Drawing.Point(259, 24);
            this.txtRefRepa.Multiline = true;
            this.txtRefRepa.Name = "txtRefRepa";
            this.txtRefRepa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRefRepa.Size = new System.Drawing.Size(323, 44);
            this.txtRefRepa.TabIndex = 1103;
            this.txtRefRepa.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRefRepa.TextoVacio = "INGRESE REFERENCIA";
            // 
            // cboConceptoReparable
            // 
            this.cboConceptoReparable.BackColor = System.Drawing.Color.White;
            this.cboConceptoReparable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoReparable.Enabled = false;
            this.cboConceptoReparable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConceptoReparable.FormattingEnabled = true;
            this.cboConceptoReparable.Location = new System.Drawing.Point(64, 47);
            this.cboConceptoReparable.Name = "cboConceptoReparable";
            this.cboConceptoReparable.Size = new System.Drawing.Size(189, 21);
            this.cboConceptoReparable.TabIndex = 1102;
            // 
            // cboReparable
            // 
            this.cboReparable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReparable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReparable.FormattingEnabled = true;
            this.cboReparable.Location = new System.Drawing.Point(64, 24);
            this.cboReparable.Name = "cboReparable";
            this.cboReparable.Size = new System.Drawing.Size(189, 21);
            this.cboReparable.TabIndex = 1101;
            this.cboReparable.SelectionChangeCommitted += new System.EventHandler(this.cboReparable_SelectionChangeCommitted);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 326;
            this.label16.Text = "Concepto";
            // 
            // labelDegradado10
            // 
            this.labelDegradado10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado10.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado10.ForeColor = System.Drawing.Color.White;
            this.labelDegradado10.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado10.Name = "labelDegradado10";
            this.labelDegradado10.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado10.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado10.Size = new System.Drawing.Size(596, 18);
            this.labelDegradado10.TabIndex = 253;
            this.labelDegradado10.Text = "Reparable/Boleta";
            this.labelDegradado10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(label6);
            this.pnlAuditoria.Controls.Add(label8);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(label9);
            this.pnlAuditoria.Location = new System.Drawing.Point(608, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(261, 122);
            this.pnlAuditoria.TabIndex = 1103;
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
            this.labelDegradado4.Size = new System.Drawing.Size(259, 18);
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
            this.txtFechaModifica.Size = new System.Drawing.Size(136, 21);
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
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(136, 21);
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
            this.txtUsuarioMod.Size = new System.Drawing.Size(136, 21);
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
            this.txtFechaRegistro.Size = new System.Drawing.Size(136, 21);
            this.txtFechaRegistro.TabIndex = 301;
            this.txtFechaRegistro.TabStop = false;
            // 
            // cboMonedaRec
            // 
            this.cboMonedaRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaRec.FormattingEnabled = true;
            this.cboMonedaRec.Location = new System.Drawing.Point(316, 70);
            this.cboMonedaRec.Name = "cboMonedaRec";
            this.cboMonedaRec.Size = new System.Drawing.Size(52, 21);
            this.cboMonedaRec.TabIndex = 1589;
            // 
            // txtMontoRec
            // 
            this.txtMontoRec.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoRec.BackColor = System.Drawing.Color.White;
            this.txtMontoRec.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoRec.Location = new System.Drawing.Point(433, 70);
            this.txtMontoRec.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoRec.Name = "txtMontoRec";
            this.txtMontoRec.Size = new System.Drawing.Size(55, 20);
            this.txtMontoRec.TabIndex = 1590;
            this.txtMontoRec.Text = "0.00";
            this.txtMontoRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoRec.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoRec.TextoVacio = "<Descripcion>";
            this.txtMontoRec.TextChanged += new System.EventHandler(this.txtMontoRec_TextChanged);
            this.txtMontoRec.Leave += new System.EventHandler(this.txtMontoRec_Leave);
            // 
            // txtCodConcepto
            // 
            this.txtCodConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodConcepto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodConcepto.Enabled = false;
            this.txtCodConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodConcepto.Location = new System.Drawing.Point(74, 93);
            this.txtCodConcepto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodConcepto.Name = "txtCodConcepto";
            this.txtCodConcepto.Size = new System.Drawing.Size(64, 20);
            this.txtCodConcepto.TabIndex = 1601;
            this.txtCodConcepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodConcepto.TextoVacio = "<Descripcion>";
            // 
            // txtDesConcepto
            // 
            this.txtDesConcepto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesConcepto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDesConcepto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesConcepto.Enabled = false;
            this.txtDesConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesConcepto.Location = new System.Drawing.Point(140, 93);
            this.txtDesConcepto.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesConcepto.Name = "txtDesConcepto";
            this.txtDesConcepto.Size = new System.Drawing.Size(414, 20);
            this.txtDesConcepto.TabIndex = 1602;
            this.txtDesConcepto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesConcepto.TextoVacio = "<Descripcion>";
            // 
            // btConceptos
            // 
            this.btConceptos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btConceptos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btConceptos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btConceptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConceptos.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btConceptos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConceptos.Location = new System.Drawing.Point(556, 94);
            this.btConceptos.Name = "btConceptos";
            this.btConceptos.Size = new System.Drawing.Size(26, 18);
            this.btConceptos.TabIndex = 1591;
            this.btConceptos.TabStop = false;
            this.btConceptos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConceptos.UseVisualStyleBackColor = true;
            this.btConceptos.Click += new System.EventHandler(this.btConceptos_Click);
            // 
            // txtRuc
            // 
            this.txtRuc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRuc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRuc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(291, 24);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(76, 20);
            this.txtRuc.TabIndex = 1581;
            this.txtRuc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRuc.TextoVacio = "<Descripcion>";
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            this.txtRuc.Validating += new System.ComponentModel.CancelEventHandler(this.txtRuc_Validating);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRazonSocial.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(369, 24);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(213, 20);
            this.txtRazonSocial.TabIndex = 1582;
            this.txtRazonSocial.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtRazonSocial.TextoVacio = "<Descripcion>";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(249, 28);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 1599;
            this.label22.Text = "Auxiliar";
            // 
            // txtTica
            // 
            this.txtTica.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTica.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTica.Enabled = false;
            this.txtTica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTica.Location = new System.Drawing.Point(537, 70);
            this.txtTica.Margin = new System.Windows.Forms.Padding(2);
            this.txtTica.Name = "txtTica";
            this.txtTica.Size = new System.Drawing.Size(45, 20);
            this.txtTica.TabIndex = 1588;
            this.txtTica.TabStop = false;
            this.txtTica.Text = "0.000";
            this.txtTica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTica.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTica.TextoVacio = "<Descripcion>";
            this.txtTica.Leave += new System.EventHandler(this.txtTica_Leave);
            // 
            // chkIndTicaAuto
            // 
            this.chkIndTicaAuto.AutoSize = true;
            this.chkIndTicaAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIndTicaAuto.Checked = true;
            this.chkIndTicaAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndTicaAuto.Location = new System.Drawing.Point(489, 72);
            this.chkIndTicaAuto.Name = "chkIndTicaAuto";
            this.chkIndTicaAuto.Size = new System.Drawing.Size(46, 17);
            this.chkIndTicaAuto.TabIndex = 1598;
            this.chkIndTicaAuto.TabStop = false;
            this.chkIndTicaAuto.Text = "T.C.";
            this.chkIndTicaAuto.UseVisualStyleBackColor = true;
            this.chkIndTicaAuto.CheckedChanged += new System.EventHandler(this.chkIndTicaAuto_CheckedChanged);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(74, 70);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(52, 21);
            this.cboMoneda.TabIndex = 1586;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(369, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1596;
            this.label4.Text = "Monto Rec.";
            // 
            // txtMontoDoc
            // 
            this.txtMontoDoc.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMontoDoc.BackColor = System.Drawing.Color.White;
            this.txtMontoDoc.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMontoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDoc.Location = new System.Drawing.Point(192, 70);
            this.txtMontoDoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoDoc.Name = "txtMontoDoc";
            this.txtMontoDoc.Size = new System.Drawing.Size(55, 20);
            this.txtMontoDoc.TabIndex = 1587;
            this.txtMontoDoc.Text = "0.00";
            this.txtMontoDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoDoc.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtMontoDoc.TextoVacio = "<Descripcion>";
            this.txtMontoDoc.TextChanged += new System.EventHandler(this.txtMontoDoc_TextChanged);
            this.txtMontoDoc.Leave += new System.EventHandler(this.txtMontoDoc_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(127, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1595;
            this.label7.Text = "Monto Doc.";
            // 
            // dtpFecDoc
            // 
            this.dtpFecDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDoc.Location = new System.Drawing.Point(316, 47);
            this.dtpFecDoc.Name = "dtpFecDoc";
            this.dtpFecDoc.Size = new System.Drawing.Size(104, 20);
            this.dtpFecDoc.TabIndex = 1585;
            // 
            // cboDocumento
            // 
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(74, 24);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(173, 21);
            this.cboDocumento.TabIndex = 1580;
            // 
            // txtSerie
            // 
            this.txtSerie.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtSerie.BackColor = System.Drawing.Color.White;
            this.txtSerie.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(74, 47);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(61, 20);
            this.txtSerie.TabIndex = 1583;
            this.txtSerie.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtSerie.TextoVacio = "<Descripcion>";
            // 
            // txtNumero
            // 
            this.txtNumero.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(139, 47);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(108, 20);
            this.txtNumero.TabIndex = 1584;
            this.txtNumero.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNumero.TextoVacio = "<Descripcion>";
            // 
            // frmLiquidacionImportacionDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 234);
            this.Controls.Add(this.pnlReparable);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLiquidacionImportacionDetalle";
            this.Text = "frmLiquidacionImportacionDetalle";
            this.Load += new System.EventHandler(this.frmLiquidacionImportacionDetalle_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.pnlReparable, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlReparable.ResumeLayout(false);
            this.pnlReparable.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReparable;
        private System.Windows.Forms.Label label10;
        private ControlesWinForm.SuperTextBox txtRefRepa;
        private System.Windows.Forms.ComboBox cboConceptoReparable;
        private System.Windows.Forms.ComboBox cboReparable;
        private System.Windows.Forms.Label label16;
        private MyLabelG.LabelDegradado labelDegradado10;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.ComboBox cboMonedaRec;
        private ControlesWinForm.SuperTextBox txtMontoRec;
        private ControlesWinForm.SuperTextBox txtCodConcepto;
        private ControlesWinForm.SuperTextBox txtDesConcepto;
        private System.Windows.Forms.Button btConceptos;
        private ControlesWinForm.SuperTextBox txtRuc;
        private ControlesWinForm.SuperTextBox txtRazonSocial;
        private System.Windows.Forms.Label label22;
        private ControlesWinForm.SuperTextBox txtTica;
        private System.Windows.Forms.CheckBox chkIndTicaAuto;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label4;
        private ControlesWinForm.SuperTextBox txtMontoDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFecDoc;
        private System.Windows.Forms.ComboBox cboDocumento;
        private ControlesWinForm.SuperTextBox txtSerie;
        private ControlesWinForm.SuperTextBox txtNumero;
    }
}