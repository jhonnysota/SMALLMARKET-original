namespace ClienteWinForm.Tesoreria
{
    partial class frmFinanciamiento
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label idLineaLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label codCuentaLabel;
            System.Windows.Forms.Label fecBajaLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label idComprobanteLabel;
            this.lblGlosaBaja = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaModifica = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtBaja = new System.Windows.Forms.TextBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtIdFinan = new System.Windows.Forms.TextBox();
            this.txtImporte = new ControlesWinForm.SuperTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboLineaCredito = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBancosEmpresa = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtGarantia = new ControlesWinForm.SuperTextBox();
            this.txtPlazo = new ControlesWinForm.SuperTextBox();
            this.txtTea = new ControlesWinForm.SuperTextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            label7 = new System.Windows.Forms.Label();
            idLineaLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            codCuentaLabel = new System.Windows.Forms.Label();
            fecBajaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            idComprobanteLabel = new System.Windows.Forms.Label();
            this.pnlAuditoria.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(300, 30);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(29, 13);
            label7.TabIndex = 376;
            label7.Text = "Cód.";
            label7.Visible = false;
            // 
            // idLineaLabel
            // 
            idLineaLabel.AutoSize = true;
            idLineaLabel.Location = new System.Drawing.Point(18, 30);
            idLineaLabel.Name = "idLineaLabel";
            idLineaLabel.Size = new System.Drawing.Size(21, 13);
            idLineaLabel.TabIndex = 374;
            idLineaLabel.Text = "ID.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(18, 99);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(42, 13);
            label6.TabIndex = 373;
            label6.Text = "Importe";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(169, 30);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 13);
            label5.TabIndex = 276;
            label5.Text = "Fecha";
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Location = new System.Drawing.Point(296, 99);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(58, 13);
            codCuentaLabel.TabIndex = 258;
            codCuentaLabel.Text = "Garantia %";
            // 
            // fecBajaLabel
            // 
            fecBajaLabel.AutoSize = true;
            fecBajaLabel.Location = new System.Drawing.Point(176, 122);
            fecBajaLabel.Name = "fecBajaLabel";
            fecBajaLabel.Size = new System.Drawing.Size(48, 13);
            fecBajaLabel.TabIndex = 264;
            fecBajaLabel.Text = "T.E.A. %";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(18, 122);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(33, 13);
            descripcionLabel.TabIndex = 260;
            descripcionLabel.Text = "Plazo";
            // 
            // idComprobanteLabel
            // 
            idComprobanteLabel.AutoSize = true;
            idComprobanteLabel.Location = new System.Drawing.Point(174, 99);
            idComprobanteLabel.Name = "idComprobanteLabel";
            idComprobanteLabel.Size = new System.Drawing.Size(46, 13);
            idComprobanteLabel.TabIndex = 270;
            idComprobanteLabel.Text = "Moneda";
            // 
            // lblGlosaBaja
            // 
            this.lblGlosaBaja.AutoSize = true;
            this.lblGlosaBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlosaBaja.Location = new System.Drawing.Point(454, 135);
            this.lblGlosaBaja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlosaBaja.Name = "lblGlosaBaja";
            this.lblGlosaBaja.Size = new System.Drawing.Size(86, 13);
            this.lblGlosaBaja.TabIndex = 379;
            this.lblGlosaBaja.Text = "Dado de Baja el ";
            this.lblGlosaBaja.Visible = false;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.label1);
            this.pnlAuditoria.Controls.Add(this.txtFechaModifica);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(440, 3);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(263, 123);
            this.pnlAuditoria.TabIndex = 364;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(261, 18);
            this.labelDegradado5.TabIndex = 274;
            this.labelDegradado5.Text = "Auditoria";
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Modificación";
            // 
            // txtFechaModifica
            // 
            this.txtFechaModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModifica.Enabled = false;
            this.txtFechaModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModifica.Location = new System.Drawing.Point(117, 91);
            this.txtFechaModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaModifica.Name = "txtFechaModifica";
            this.txtFechaModifica.Size = new System.Drawing.Size(133, 20);
            this.txtFechaModifica.TabIndex = 0;
            this.txtFechaModifica.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(117, 47);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFechaRegistro.TabIndex = 0;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(117, 25);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            this.txtUsuRegistra.TabStop = false;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(117, 69);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            this.txtUsuModifica.TabStop = false;
            // 
            // txtBaja
            // 
            this.txtBaja.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBaja.Enabled = false;
            this.txtBaja.Location = new System.Drawing.Point(544, 131);
            this.txtBaja.Name = "txtBaja";
            this.txtBaja.Size = new System.Drawing.Size(133, 20);
            this.txtBaja.TabIndex = 377;
            this.txtBaja.TabStop = false;
            this.txtBaja.Visible = false;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(label7);
            this.pnlDatos.Controls.Add(this.txtCodigo);
            this.pnlDatos.Controls.Add(idLineaLabel);
            this.pnlDatos.Controls.Add(this.txtIdFinan);
            this.pnlDatos.Controls.Add(label6);
            this.pnlDatos.Controls.Add(this.txtImporte);
            this.pnlDatos.Controls.Add(this.label16);
            this.pnlDatos.Controls.Add(this.cboLineaCredito);
            this.pnlDatos.Controls.Add(this.label13);
            this.pnlDatos.Controls.Add(this.cboBancosEmpresa);
            this.pnlDatos.Controls.Add(this.dtpFecha);
            this.pnlDatos.Controls.Add(label5);
            this.pnlDatos.Controls.Add(codCuentaLabel);
            this.pnlDatos.Controls.Add(this.txtGarantia);
            this.pnlDatos.Controls.Add(fecBajaLabel);
            this.pnlDatos.Controls.Add(descripcionLabel);
            this.pnlDatos.Controls.Add(this.txtPlazo);
            this.pnlDatos.Controls.Add(this.txtTea);
            this.pnlDatos.Controls.Add(idComprobanteLabel);
            this.pnlDatos.Controls.Add(this.cboMoneda);
            this.pnlDatos.Controls.Add(this.lblRegistros);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(435, 150);
            this.pnlDatos.TabIndex = 363;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(332, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(85, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.Visible = false;
            // 
            // txtIdFinan
            // 
            this.txtIdFinan.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdFinan.Enabled = false;
            this.txtIdFinan.Location = new System.Drawing.Point(100, 26);
            this.txtIdFinan.Name = "txtIdFinan";
            this.txtIdFinan.Size = new System.Drawing.Size(65, 20);
            this.txtIdFinan.TabIndex = 1;
            this.txtIdFinan.TabStop = false;
            // 
            // txtImporte
            // 
            this.txtImporte.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtImporte.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtImporte.Location = new System.Drawing.Point(100, 95);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(67, 20);
            this.txtImporte.TabIndex = 6;
            this.txtImporte.Text = "0.00";
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtImporte.TextoVacio = "<Descripcion>";
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 371;
            this.label16.Text = "Lineas de Créd.";
            // 
            // cboLineaCredito
            // 
            this.cboLineaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineaCredito.DropDownWidth = 132;
            this.cboLineaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLineaCredito.FormattingEnabled = true;
            this.cboLineaCredito.Items.AddRange(new object[] {
            "Pendiente",
            "Cancelados"});
            this.cboLineaCredito.Location = new System.Drawing.Point(100, 72);
            this.cboLineaCredito.Name = "cboLineaCredito";
            this.cboLineaCredito.Size = new System.Drawing.Size(317, 21);
            this.cboLineaCredito.TabIndex = 5;
            this.cboLineaCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLineaCredito_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 369;
            this.label13.Text = "Bancos";
            // 
            // cboBancosEmpresa
            // 
            this.cboBancosEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancosEmpresa.DropDownWidth = 150;
            this.cboBancosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBancosEmpresa.FormattingEnabled = true;
            this.cboBancosEmpresa.Items.AddRange(new object[] {
            "Pendiente",
            "Cancelados"});
            this.cboBancosEmpresa.Location = new System.Drawing.Point(100, 49);
            this.cboBancosEmpresa.Name = "cboBancosEmpresa";
            this.cboBancosEmpresa.Size = new System.Drawing.Size(317, 21);
            this.cboBancosEmpresa.TabIndex = 4;
            this.cboBancosEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBancosEmpresa_KeyPress);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(212, 26);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(83, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // txtGarantia
            // 
            this.txtGarantia.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtGarantia.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtGarantia.Location = new System.Drawing.Point(358, 95);
            this.txtGarantia.Name = "txtGarantia";
            this.txtGarantia.Size = new System.Drawing.Size(59, 20);
            this.txtGarantia.TabIndex = 8;
            this.txtGarantia.Text = "0.00";
            this.txtGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGarantia.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtGarantia.TextoVacio = "<Descripcion>";
            this.txtGarantia.Leave += new System.EventHandler(this.txtGarantia_Leave);
            // 
            // txtPlazo
            // 
            this.txtPlazo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPlazo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPlazo.Location = new System.Drawing.Point(100, 118);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.Size = new System.Drawing.Size(67, 20);
            this.txtPlazo.TabIndex = 9;
            this.txtPlazo.Text = "0";
            this.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlazo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtPlazo.TextoVacio = "<Descripcion>";
            // 
            // txtTea
            // 
            this.txtTea.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTea.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTea.Location = new System.Drawing.Point(225, 118);
            this.txtTea.Name = "txtTea";
            this.txtTea.Size = new System.Drawing.Size(67, 20);
            this.txtTea.TabIndex = 10;
            this.txtTea.Text = "0.00";
            this.txtTea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTea.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTea.TextoVacio = "<Descripcion>";
            this.txtTea.Leave += new System.EventHandler(this.txtTea_Leave);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.DropDownWidth = 200;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(225, 95);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(67, 21);
            this.cboMoneda.TabIndex = 7;
            this.cboMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMoneda_KeyPress);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(433, 18);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Datos";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFinanciamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 156);
            this.Controls.Add(this.lblGlosaBaja);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.txtBaja);
            this.Controls.Add(this.pnlDatos);
            this.MaximizeBox = false;
            this.Name = "frmFinanciamiento";
            this.Text = "Financiamiento (Nuevo)";
            this.Load += new System.EventHandler(this.frmFinanciamiento_Load);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaModifica;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private ControlesWinForm.SuperTextBox txtGarantia;
        private ControlesWinForm.SuperTextBox txtPlazo;
        private ControlesWinForm.SuperTextBox txtTea;
        private System.Windows.Forms.ComboBox cboMoneda;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboBancosEmpresa;
        private ControlesWinForm.SuperTextBox txtImporte;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboLineaCredito;
        private System.Windows.Forms.TextBox txtIdFinan;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtBaja;
        private System.Windows.Forms.Label lblGlosaBaja;
    }
}