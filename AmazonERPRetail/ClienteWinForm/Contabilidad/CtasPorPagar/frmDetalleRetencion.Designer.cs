namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmDetalleRetencion
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
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label idDocumentoLabel;
            System.Windows.Forms.Label idMonedaLabel;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.txtFModifica = new System.Windows.Forms.TextBox();
            this.txtURegistro = new System.Windows.Forms.TextBox();
            this.txtUModifica = new System.Windows.Forms.TextBox();
            this.txtFRegistro = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.dtpFechaDoc = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmRetSoles = new System.Windows.Forms.TextBox();
            this.txtMontoSoles = new System.Windows.Forms.TextBox();
            this.txtmRetOrigen = new System.Windows.Forms.TextBox();
            this.txtMontoOrigen = new System.Windows.Forms.TextBox();
            this.cboDocumentos = new System.Windows.Forms.ComboBox();
            this.cboMonedas = new System.Windows.Forms.ComboBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            idDocumentoLabel = new System.Windows.Forms.Label();
            idMonedaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(330, 182);
            this.btCancelar.Size = new System.Drawing.Size(119, 25);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(206, 182);
            this.btAceptar.Size = new System.Drawing.Size(119, 25);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(361, 19);
            this.lblTitPnlBase.Text = "Comprobante";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(639, 25);
            this.lblTituloPrincipal.Text = "Detalle de Retención";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(611, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtmRetOrigen);
            this.pnlBase.Controls.Add(this.txtItem);
            this.pnlBase.Controls.Add(this.cboMonedas);
            this.pnlBase.Controls.Add(idMonedaLabel);
            this.pnlBase.Controls.Add(this.cboDocumentos);
            this.pnlBase.Controls.Add(idDocumentoLabel);
            this.pnlBase.Controls.Add(label13);
            this.pnlBase.Controls.Add(this.txtmRetSoles);
            this.pnlBase.Controls.Add(label14);
            this.pnlBase.Controls.Add(this.txtMontoSoles);
            this.pnlBase.Controls.Add(label8);
            this.pnlBase.Controls.Add(this.txtMontoOrigen);
            this.pnlBase.Controls.Add(this.dtpFechaDoc);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(label11);
            this.pnlBase.Controls.Add(this.txtNumero);
            this.pnlBase.Controls.Add(label12);
            this.pnlBase.Controls.Add(this.txtSerie);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Location = new System.Drawing.Point(7, 28);
            this.pnlBase.Size = new System.Drawing.Size(363, 145);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtSerie, 0);
            this.pnlBase.Controls.SetChildIndex(label12, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtNumero, 0);
            this.pnlBase.Controls.SetChildIndex(label11, 0);
            this.pnlBase.Controls.SetChildIndex(this.label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.dtpFechaDoc, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMontoOrigen, 0);
            this.pnlBase.Controls.SetChildIndex(label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMontoSoles, 0);
            this.pnlBase.Controls.SetChildIndex(label14, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtmRetSoles, 0);
            this.pnlBase.Controls.SetChildIndex(label13, 0);
            this.pnlBase.Controls.SetChildIndex(idDocumentoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocumentos, 0);
            this.pnlBase.Controls.SetChildIndex(idMonedaLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMonedas, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtItem, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtmRetOrigen, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 107);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(11, 86);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(11, 44);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(11, 65);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(10, 75);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(44, 13);
            label11.TabIndex = 362;
            label11.Text = "Número";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(10, 54);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(31, 13);
            label12.TabIndex = 360;
            label12.Text = "Serie";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(171, 117);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(74, 13);
            label13.TabIndex = 377;
            label13.Text = "Retencion S/.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.Location = new System.Drawing.Point(171, 75);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(55, 13);
            label14.TabIndex = 375;
            label14.Text = "Monto S/.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(171, 96);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(94, 13);
            label7.TabIndex = 373;
            label7.Text = "Retención Original";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(171, 54);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(75, 13);
            label8.TabIndex = 371;
            label8.Text = "Monto Original";
            // 
            // idDocumentoLabel
            // 
            idDocumentoLabel.AutoSize = true;
            idDocumentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idDocumentoLabel.Location = new System.Drawing.Point(10, 32);
            idDocumentoLabel.Name = "idDocumentoLabel";
            idDocumentoLabel.Size = new System.Drawing.Size(54, 13);
            idDocumentoLabel.TabIndex = 385;
            idDocumentoLabel.Text = "Tipo Doc.";
            // 
            // idMonedaLabel
            // 
            idMonedaLabel.AutoSize = true;
            idMonedaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idMonedaLabel.Location = new System.Drawing.Point(10, 117);
            idMonedaLabel.Name = "idMonedaLabel";
            idMonedaLabel.Size = new System.Drawing.Size(46, 13);
            idMonedaLabel.TabIndex = 386;
            idMonedaLabel.Text = "Moneda";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.txtFModifica);
            this.pnlAuditoria.Controls.Add(this.txtURegistro);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.txtUModifica);
            this.pnlAuditoria.Controls.Add(this.txtFRegistro);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(372, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(260, 145);
            this.pnlAuditoria.TabIndex = 256;
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
            this.labelDegradado4.Size = new System.Drawing.Size(258, 19);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFModifica
            // 
            this.txtFModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFModifica.Enabled = false;
            this.txtFModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFModifica.Location = new System.Drawing.Point(117, 103);
            this.txtFModifica.Name = "txtFModifica";
            this.txtFModifica.Size = new System.Drawing.Size(129, 20);
            this.txtFModifica.TabIndex = 304;
            // 
            // txtURegistro
            // 
            this.txtURegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtURegistro.Enabled = false;
            this.txtURegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURegistro.Location = new System.Drawing.Point(117, 40);
            this.txtURegistro.Name = "txtURegistro";
            this.txtURegistro.Size = new System.Drawing.Size(129, 20);
            this.txtURegistro.TabIndex = 300;
            // 
            // txtUModifica
            // 
            this.txtUModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUModifica.Enabled = false;
            this.txtUModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUModifica.Location = new System.Drawing.Point(117, 82);
            this.txtUModifica.Name = "txtUModifica";
            this.txtUModifica.Size = new System.Drawing.Size(129, 20);
            this.txtUModifica.TabIndex = 303;
            // 
            // txtFRegistro
            // 
            this.txtFRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFRegistro.Enabled = false;
            this.txtFRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFRegistro.Location = new System.Drawing.Point(117, 61);
            this.txtFRegistro.Name = "txtFRegistro";
            this.txtFRegistro.Size = new System.Drawing.Size(129, 20);
            this.txtFRegistro.TabIndex = 301;
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(73, 71);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(94, 20);
            this.txtNumero.TabIndex = 361;
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(73, 50);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(94, 20);
            this.txtSerie.TabIndex = 359;
            // 
            // dtpFechaDoc
            // 
            this.dtpFechaDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDoc.Location = new System.Drawing.Point(73, 92);
            this.dtpFechaDoc.Name = "dtpFechaDoc";
            this.dtpFechaDoc.Size = new System.Drawing.Size(94, 20);
            this.dtpFechaDoc.TabIndex = 363;
            this.dtpFechaDoc.Value = new System.DateTime(2016, 12, 31, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 364;
            this.label6.Text = "Fecha Doc.";
            // 
            // txtmRetSoles
            // 
            this.txtmRetSoles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtmRetSoles.Enabled = false;
            this.txtmRetSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmRetSoles.Location = new System.Drawing.Point(268, 92);
            this.txtmRetSoles.Name = "txtmRetSoles";
            this.txtmRetSoles.Size = new System.Drawing.Size(77, 20);
            this.txtmRetSoles.TabIndex = 376;
            this.txtmRetSoles.Text = "0.00";
            this.txtmRetSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoSoles
            // 
            this.txtMontoSoles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMontoSoles.Enabled = false;
            this.txtMontoSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoSoles.Location = new System.Drawing.Point(268, 71);
            this.txtMontoSoles.Name = "txtMontoSoles";
            this.txtMontoSoles.Size = new System.Drawing.Size(77, 20);
            this.txtMontoSoles.TabIndex = 374;
            this.txtMontoSoles.Text = "0.00";
            this.txtMontoSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmRetOrigen
            // 
            this.txtmRetOrigen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtmRetOrigen.Enabled = false;
            this.txtmRetOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmRetOrigen.Location = new System.Drawing.Point(268, 113);
            this.txtmRetOrigen.Name = "txtmRetOrigen";
            this.txtmRetOrigen.Size = new System.Drawing.Size(77, 20);
            this.txtmRetOrigen.TabIndex = 372;
            this.txtmRetOrigen.Text = "0.00";
            this.txtmRetOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoOrigen
            // 
            this.txtMontoOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoOrigen.Location = new System.Drawing.Point(268, 50);
            this.txtMontoOrigen.Name = "txtMontoOrigen";
            this.txtMontoOrigen.Size = new System.Drawing.Size(77, 20);
            this.txtMontoOrigen.TabIndex = 370;
            this.txtMontoOrigen.Text = "0.00";
            this.txtMontoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoOrigen.TextChanged += new System.EventHandler(this.txtMontoOrigen_TextChanged);
            // 
            // cboDocumentos
            // 
            this.cboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumentos.DropDownWidth = 200;
            this.cboDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocumentos.FormattingEnabled = true;
            this.cboDocumentos.Location = new System.Drawing.Point(73, 28);
            this.cboDocumentos.Name = "cboDocumentos";
            this.cboDocumentos.Size = new System.Drawing.Size(193, 21);
            this.cboDocumentos.TabIndex = 384;
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(73, 113);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(94, 21);
            this.cboMonedas.TabIndex = 387;
            this.cboMonedas.SelectionChangeCommitted += new System.EventHandler(this.cboMonedas_SelectionChangeCommitted);
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtItem.Enabled = false;
            this.txtItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(268, 29);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(77, 20);
            this.txtItem.TabIndex = 388;
            this.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmDetalleRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 217);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmDetalleRetencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetalleRetencion";
            this.Load += new System.EventHandler(this.frmDetalleRetencion_Load);
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

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox txtFModifica;
        private System.Windows.Forms.TextBox txtURegistro;
        private System.Windows.Forms.TextBox txtUModifica;
        private System.Windows.Forms.TextBox txtFRegistro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.DateTimePicker dtpFechaDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmRetSoles;
        private System.Windows.Forms.TextBox txtMontoSoles;
        private System.Windows.Forms.TextBox txtmRetOrigen;
        private System.Windows.Forms.TextBox txtMontoOrigen;
        private System.Windows.Forms.ComboBox cboDocumentos;
        private System.Windows.Forms.ComboBox cboMonedas;
        private System.Windows.Forms.TextBox txtItem;
    }
}