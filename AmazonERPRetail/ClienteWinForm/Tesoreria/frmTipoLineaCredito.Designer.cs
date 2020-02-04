namespace ClienteWinForm.Tesoreria
{
    partial class frmTipoLineaCredito
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codCuentaLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label fecBajaLabel;
            System.Windows.Forms.Label idComprobanteLabel;
            System.Windows.Forms.Label idLineaLabel;
            System.Windows.Forms.Label numFileLabel;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtDesCorta = new ControlesWinForm.SuperTextBox();
            this.tipoLineaCreditoEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboDocumento = new System.Windows.Forms.ComboBox();
            this.txtVersionPlan = new System.Windows.Forms.TextBox();
            this.txtCodCuenta = new ControlesWinForm.SuperTextBox();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.txtDesCuenta = new ControlesWinForm.SuperTextBox();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.txtIdLinea = new System.Windows.Forms.TextBox();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.txtFecBaja = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            codCuentaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            fecBajaLabel = new System.Windows.Forms.Label();
            idComprobanteLabel = new System.Windows.Forms.Label();
            idLineaLabel = new System.Windows.Forms.Label();
            numFileLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoLineaCreditoEBindingSource)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Location = new System.Drawing.Point(14, 75);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(41, 13);
            codCuentaLabel.TabIndex = 258;
            codCuentaLabel.Text = "Cuenta";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(141, 29);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(63, 13);
            descripcionLabel.TabIndex = 260;
            descripcionLabel.Text = "Descripción";
            // 
            // fecBajaLabel
            // 
            fecBajaLabel.AutoSize = true;
            fecBajaLabel.Location = new System.Drawing.Point(496, 138);
            fecBajaLabel.Name = "fecBajaLabel";
            fecBajaLabel.Size = new System.Drawing.Size(86, 13);
            fecBajaLabel.TabIndex = 264;
            fecBajaLabel.Text = "Dado de Baja el ";
            fecBajaLabel.Visible = false;
            // 
            // idComprobanteLabel
            // 
            idComprobanteLabel.AutoSize = true;
            idComprobanteLabel.Location = new System.Drawing.Point(14, 99);
            idComprobanteLabel.Name = "idComprobanteLabel";
            idComprobanteLabel.Size = new System.Drawing.Size(30, 13);
            idComprobanteLabel.TabIndex = 270;
            idComprobanteLabel.Text = "Libro";
            // 
            // idLineaLabel
            // 
            idLineaLabel.AutoSize = true;
            idLineaLabel.Location = new System.Drawing.Point(14, 29);
            idLineaLabel.Name = "idLineaLabel";
            idLineaLabel.Size = new System.Drawing.Size(21, 13);
            idLineaLabel.TabIndex = 272;
            idLineaLabel.Text = "ID.";
            // 
            // numFileLabel
            // 
            numFileLabel.AutoSize = true;
            numFileLabel.Location = new System.Drawing.Point(254, 99);
            numFileLabel.Name = "numFileLabel";
            numFileLabel.Size = new System.Drawing.Size(23, 13);
            numFileLabel.TabIndex = 274;
            numFileLabel.Text = "File";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(14, 52);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 13);
            label5.TabIndex = 277;
            label5.Text = "Des. Corta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(141, 53);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(54, 13);
            label6.TabIndex = 279;
            label6.Text = "Tipo Doc.";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(label6);
            this.pnlDatos.Controls.Add(label5);
            this.pnlDatos.Controls.Add(this.txtDesCorta);
            this.pnlDatos.Controls.Add(this.cboDocumento);
            this.pnlDatos.Controls.Add(this.txtVersionPlan);
            this.pnlDatos.Controls.Add(codCuentaLabel);
            this.pnlDatos.Controls.Add(this.txtCodCuenta);
            this.pnlDatos.Controls.Add(descripcionLabel);
            this.pnlDatos.Controls.Add(this.txtDescripcion);
            this.pnlDatos.Controls.Add(this.txtDesCuenta);
            this.pnlDatos.Controls.Add(idComprobanteLabel);
            this.pnlDatos.Controls.Add(this.cboLibro);
            this.pnlDatos.Controls.Add(idLineaLabel);
            this.pnlDatos.Controls.Add(this.txtIdLinea);
            this.pnlDatos.Controls.Add(numFileLabel);
            this.pnlDatos.Controls.Add(this.cboFile);
            this.pnlDatos.Controls.Add(this.lblRegistros);
            this.pnlDatos.Location = new System.Drawing.Point(3, 4);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(474, 126);
            this.pnlDatos.TabIndex = 361;
            // 
            // txtDesCorta
            // 
            this.txtDesCorta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCorta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesCorta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCorta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "Descripcion", true));
            this.txtDesCorta.Location = new System.Drawing.Point(72, 48);
            this.txtDesCorta.MaxLength = 5;
            this.txtDesCorta.Name = "txtDesCorta";
            this.txtDesCorta.Size = new System.Drawing.Size(67, 20);
            this.txtDesCorta.TabIndex = 3;
            this.txtDesCorta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCorta.TextoVacio = "<Descripcion>";
            // 
            // tipoLineaCreditoEBindingSource
            // 
            this.tipoLineaCreditoEBindingSource.DataSource = typeof(Entidades.Tesoreria.TipoLineaCreditoE);
            // 
            // cboDocumento
            // 
            this.cboDocumento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "idComprobante", true));
            this.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocumento.DropDownWidth = 200;
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(207, 48);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(248, 21);
            this.cboDocumento.TabIndex = 4;
            // 
            // txtVersionPlan
            // 
            this.txtVersionPlan.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtVersionPlan.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "idLinea", true));
            this.txtVersionPlan.Enabled = false;
            this.txtVersionPlan.Location = new System.Drawing.Point(55, 71);
            this.txtVersionPlan.Name = "txtVersionPlan";
            this.txtVersionPlan.Size = new System.Drawing.Size(16, 20);
            this.txtVersionPlan.TabIndex = 275;
            this.txtVersionPlan.TabStop = false;
            this.txtVersionPlan.Visible = false;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCodCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCodCuenta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "codCuenta", true));
            this.txtCodCuenta.Location = new System.Drawing.Point(72, 71);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(67, 20);
            this.txtCodCuenta.TabIndex = 5;
            this.txtCodCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCodCuenta.TextoVacio = "<Descripcion>";
            this.txtCodCuenta.TextChanged += new System.EventHandler(this.txtCodCuenta_TextChanged);
            this.txtCodCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCuenta_Validating);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "Descripcion", true));
            this.txtDescripcion.Location = new System.Drawing.Point(207, 25);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(248, 20);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // txtDesCuenta
            // 
            this.txtDesCuenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCuenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCuenta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "desCuenta", true));
            this.txtDesCuenta.Location = new System.Drawing.Point(143, 71);
            this.txtDesCuenta.Name = "txtDesCuenta";
            this.txtDesCuenta.Size = new System.Drawing.Size(312, 20);
            this.txtDesCuenta.TabIndex = 6;
            this.txtDesCuenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCuenta.TextoVacio = "<Descripcion>";
            this.txtDesCuenta.TextChanged += new System.EventHandler(this.txtDesCuenta_TextChanged);
            this.txtDesCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCuenta_Validating);
            // 
            // cboLibro
            // 
            this.cboLibro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "idComprobante", true));
            this.cboLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibro.DropDownWidth = 200;
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Location = new System.Drawing.Point(72, 95);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(177, 21);
            this.cboLibro.TabIndex = 7;
            this.cboLibro.SelectionChangeCommitted += new System.EventHandler(this.cboLibro_SelectionChangeCommitted);
            // 
            // txtIdLinea
            // 
            this.txtIdLinea.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdLinea.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "idLinea", true));
            this.txtIdLinea.Enabled = false;
            this.txtIdLinea.Location = new System.Drawing.Point(72, 25);
            this.txtIdLinea.Name = "txtIdLinea";
            this.txtIdLinea.Size = new System.Drawing.Size(67, 20);
            this.txtIdLinea.TabIndex = 1;
            this.txtIdLinea.TabStop = false;
            // 
            // cboFile
            // 
            this.cboFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "numFile", true));
            this.cboFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFile.DropDownWidth = 200;
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(278, 95);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(177, 21);
            this.cboFile.TabIndex = 8;
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
            this.lblRegistros.Size = new System.Drawing.Size(472, 18);
            this.lblRegistros.TabIndex = 258;
            this.lblRegistros.Text = "Datos";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFecBaja
            // 
            this.txtFecBaja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtFecBaja.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFecBaja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtFecBaja.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoLineaCreditoEBindingSource, "fecBaja", true));
            this.txtFecBaja.Enabled = false;
            this.txtFecBaja.Location = new System.Drawing.Point(585, 134);
            this.txtFecBaja.Name = "txtFecBaja";
            this.txtFecBaja.Size = new System.Drawing.Size(157, 20);
            this.txtFecBaja.TabIndex = 265;
            this.txtFecBaja.TabStop = false;
            this.txtFecBaja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtFecBaja.TextoVacio = "<Descripcion>";
            this.txtFecBaja.Visible = false;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado5);
            this.pnlAuditoria.Controls.Add(this.label1);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(479, 4);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(263, 126);
            this.pnlAuditoria.TabIndex = 362;
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
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(117, 91);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
            this.txtModifica.TabIndex = 0;
            this.txtModifica.TabStop = false;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(117, 47);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtRegistro.TabIndex = 0;
            this.txtRegistro.TabStop = false;
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
            // frmTipoLineaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 133);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.txtFecBaja);
            this.Controls.Add(fecBajaLabel);
            this.MaximizeBox = false;
            this.Name = "frmTipoLineaCredito";
            this.Text = "Tipo Linea Crédito(Nuevo)";
            this.Load += new System.EventHandler(this.frmTipoLineaCredito_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoLineaCreditoEBindingSource)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtCodCuenta;
        private System.Windows.Forms.BindingSource tipoLineaCreditoEBindingSource;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private ControlesWinForm.SuperTextBox txtDesCuenta;
        private ControlesWinForm.SuperTextBox txtFecBaja;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.TextBox txtIdLinea;
        private System.Windows.Forms.ComboBox cboFile;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.TextBox txtVersionPlan;
        private ControlesWinForm.SuperTextBox txtDesCorta;
        private System.Windows.Forms.ComboBox cboDocumento;
    }
}