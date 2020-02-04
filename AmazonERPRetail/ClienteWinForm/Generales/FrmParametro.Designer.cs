namespace ClienteWinForm.Generales
{
    partial class FrmParametro
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
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label fechaModificacionLabel;
            System.Windows.Forms.Label usuarioRegistroLabel1;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            System.Windows.Forms.Label valorCadenaLabel;
            System.Windows.Forms.Label valorDecimalLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label idParametroLabel;
            this.parametroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estadoCheckBox = new System.Windows.Forms.CheckBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.valorCadenaTextBox = new System.Windows.Forms.TextBox();
            this.valorDecimalTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.idParametroTextBox = new System.Windows.Forms.TextBox();
            this.fechaModificacionTextBox = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox1 = new System.Windows.Forms.TextBox();
            this.fechaRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            fechaModificacionLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel1 = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            valorCadenaLabel = new System.Windows.Forms.Label();
            valorDecimalLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            idParametroLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.parametroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Font = new System.Drawing.Font("Calibri", 11F);
            estadoLabel.Location = new System.Drawing.Point(383, 29);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(59, 23);
            estadoLabel.TabIndex = 106;
            estadoLabel.Text = "Activo";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Calibri", 11F);
            descripcionLabel.Location = new System.Drawing.Point(5, 83);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(122, 23);
            descripcionLabel.TabIndex = 105;
            descripcionLabel.Text = "DESCRIPCION:";
            // 
            // fechaModificacionLabel
            // 
            fechaModificacionLabel.AutoSize = true;
            fechaModificacionLabel.Font = new System.Drawing.Font("Calibri", 10F);
            fechaModificacionLabel.Location = new System.Drawing.Point(5, 109);
            fechaModificacionLabel.Name = "fechaModificacionLabel";
            fechaModificacionLabel.Size = new System.Drawing.Size(149, 21);
            fechaModificacionLabel.TabIndex = 28;
            fechaModificacionLabel.Text = "Fecha Modificacion:";
            // 
            // usuarioRegistroLabel1
            // 
            usuarioRegistroLabel1.AutoSize = true;
            usuarioRegistroLabel1.Font = new System.Drawing.Font("Calibri", 10F);
            usuarioRegistroLabel1.Location = new System.Drawing.Point(5, 83);
            usuarioRegistroLabel1.Name = "usuarioRegistroLabel1";
            usuarioRegistroLabel1.Size = new System.Drawing.Size(158, 21);
            usuarioRegistroLabel1.TabIndex = 26;
            usuarioRegistroLabel1.Text = "Usuario Modificacion";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Font = new System.Drawing.Font("Calibri", 10F);
            fechaRegistroLabel.Location = new System.Drawing.Point(5, 57);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(116, 21);
            fechaRegistroLabel.TabIndex = 24;
            fechaRegistroLabel.Text = "Fecha Registro:";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Font = new System.Drawing.Font("Calibri", 10F);
            usuarioRegistroLabel.Location = new System.Drawing.Point(5, 31);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(130, 21);
            usuarioRegistroLabel.TabIndex = 22;
            usuarioRegistroLabel.Text = "Usuario Registro:";
            // 
            // valorCadenaLabel
            // 
            valorCadenaLabel.AutoSize = true;
            valorCadenaLabel.Font = new System.Drawing.Font("Calibri", 11F);
            valorCadenaLabel.Location = new System.Drawing.Point(5, 109);
            valorCadenaLabel.Name = "valorCadenaLabel";
            valorCadenaLabel.Size = new System.Drawing.Size(136, 23);
            valorCadenaLabel.TabIndex = 103;
            valorCadenaLabel.Text = "VALOR CADENA:";
            // 
            // valorDecimalLabel
            // 
            valorDecimalLabel.AutoSize = true;
            valorDecimalLabel.Font = new System.Drawing.Font("Calibri", 11F);
            valorDecimalLabel.Location = new System.Drawing.Point(5, 135);
            valorDecimalLabel.Name = "valorDecimalLabel";
            valorDecimalLabel.Size = new System.Drawing.Size(143, 23);
            valorDecimalLabel.TabIndex = 102;
            valorDecimalLabel.Text = "VALOR DECIMAL:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Calibri", 11F);
            nombreLabel.Location = new System.Drawing.Point(5, 57);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(85, 23);
            nombreLabel.TabIndex = 101;
            nombreLabel.Text = "NOMBRE:";
            // 
            // idParametroLabel
            // 
            idParametroLabel.AutoSize = true;
            idParametroLabel.Font = new System.Drawing.Font("Calibri", 11F);
            idParametroLabel.Location = new System.Drawing.Point(5, 31);
            idParametroLabel.Name = "idParametroLabel";
            idParametroLabel.Size = new System.Drawing.Size(81, 23);
            idParametroLabel.TabIndex = 0;
            idParametroLabel.Text = "CODIGO:";
            // 
            // parametroBindingSource
            // 
            this.parametroBindingSource.DataSource = typeof(Entidades.Generales.ParametroE);
            // 
            // estadoCheckBox
            // 
            this.estadoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.parametroBindingSource, "Estado", true));
            this.estadoCheckBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.estadoCheckBox.Location = new System.Drawing.Point(435, 26);
            this.estadoCheckBox.Name = "estadoCheckBox";
            this.estadoCheckBox.Size = new System.Drawing.Size(17, 24);
            this.estadoCheckBox.TabIndex = 107;
            this.estadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "Descripcion", true));
            this.descripcionTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.descripcionTextBox.Location = new System.Drawing.Point(115, 81);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(360, 30);
            this.descripcionTextBox.TabIndex = 1;
            // 
            // valorCadenaTextBox
            // 
            this.valorCadenaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valorCadenaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "ValorCadena", true));
            this.valorCadenaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.valorCadenaTextBox.Location = new System.Drawing.Point(115, 107);
            this.valorCadenaTextBox.Name = "valorCadenaTextBox";
            this.valorCadenaTextBox.Size = new System.Drawing.Size(360, 30);
            this.valorCadenaTextBox.TabIndex = 2;
            // 
            // valorDecimalTextBox
            // 
            this.valorDecimalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "ValorDecimal", true));
            this.valorDecimalTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.valorDecimalTextBox.Location = new System.Drawing.Point(115, 133);
            this.valorDecimalTextBox.Name = "valorDecimalTextBox";
            this.valorDecimalTextBox.Size = new System.Drawing.Size(100, 30);
            this.valorDecimalTextBox.TabIndex = 3;
            this.valorDecimalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valorDecimalTextBox_KeyPress);
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "Nombre", true));
            this.nombreTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.nombreTextBox.Location = new System.Drawing.Point(115, 55);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(360, 30);
            this.nombreTextBox.TabIndex = 0;
            // 
            // idParametroTextBox
            // 
            this.idParametroTextBox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.idParametroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "IdParametro", true));
            this.idParametroTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.idParametroTextBox.Location = new System.Drawing.Point(115, 29);
            this.idParametroTextBox.Name = "idParametroTextBox";
            this.idParametroTextBox.ReadOnly = true;
            this.idParametroTextBox.Size = new System.Drawing.Size(100, 30);
            this.idParametroTextBox.TabIndex = 101;
            // 
            // fechaModificacionTextBox
            // 
            this.fechaModificacionTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.fechaModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "FechaModificacion", true));
            this.fechaModificacionTextBox.Enabled = false;
            this.fechaModificacionTextBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.fechaModificacionTextBox.Location = new System.Drawing.Point(133, 106);
            this.fechaModificacionTextBox.Name = "fechaModificacionTextBox";
            this.fechaModificacionTextBox.Size = new System.Drawing.Size(135, 28);
            this.fechaModificacionTextBox.TabIndex = 29;
            // 
            // usuarioRegistroTextBox1
            // 
            this.usuarioRegistroTextBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioRegistroTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "UsuarioModificacion", true));
            this.usuarioRegistroTextBox1.Enabled = false;
            this.usuarioRegistroTextBox1.Font = new System.Drawing.Font("Calibri", 10F);
            this.usuarioRegistroTextBox1.Location = new System.Drawing.Point(133, 80);
            this.usuarioRegistroTextBox1.Name = "usuarioRegistroTextBox1";
            this.usuarioRegistroTextBox1.Size = new System.Drawing.Size(135, 28);
            this.usuarioRegistroTextBox1.TabIndex = 27;
            // 
            // fechaRegistroTextBox
            // 
            this.fechaRegistroTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.fechaRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "FechaRegistro", true));
            this.fechaRegistroTextBox.Enabled = false;
            this.fechaRegistroTextBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.fechaRegistroTextBox.Location = new System.Drawing.Point(133, 54);
            this.fechaRegistroTextBox.Name = "fechaRegistroTextBox";
            this.fechaRegistroTextBox.Size = new System.Drawing.Size(135, 28);
            this.fechaRegistroTextBox.TabIndex = 25;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parametroBindingSource, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(133, 28);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(135, 28);
            this.usuarioRegistroTextBox.TabIndex = 23;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(estadoLabel);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.estadoCheckBox);
            this.pnlDetalle.Controls.Add(this.nombreTextBox);
            this.pnlDetalle.Controls.Add(descripcionLabel);
            this.pnlDetalle.Controls.Add(idParametroLabel);
            this.pnlDetalle.Controls.Add(this.descripcionTextBox);
            this.pnlDetalle.Controls.Add(this.idParametroTextBox);
            this.pnlDetalle.Controls.Add(valorCadenaLabel);
            this.pnlDetalle.Controls.Add(nombreLabel);
            this.pnlDetalle.Controls.Add(this.valorCadenaTextBox);
            this.pnlDetalle.Controls.Add(this.valorDecimalTextBox);
            this.pnlDetalle.Controls.Add(valorDecimalLabel);
            this.pnlDetalle.Location = new System.Drawing.Point(8, 12);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(484, 168);
            this.pnlDetalle.TabIndex = 106;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 23);
            this.label1.TabIndex = 98;
            this.label1.Text = "Detalle";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionTextBox);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel1);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox1);
            this.pnlAuditoria.Controls.Add(this.fechaRegistroTextBox);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Location = new System.Drawing.Point(496, 12);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(276, 168);
            this.pnlAuditoria.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 23);
            this.label2.TabIndex = 98;
            this.label2.Text = "Auditoria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmParametro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 221);
            this.Controls.Add(this.pnlAuditoria);
            this.Controls.Add(this.pnlDetalle);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmParametro";
            this.Text = "MANTENIMIENTO PARAMETRO ";
            this.Load += new System.EventHandler(this.FrmParametro_Load);
            this.Controls.SetChildIndex(this.pnlDetalle, 0);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.parametroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource parametroBindingSource;
        private System.Windows.Forms.TextBox idParametroTextBox;
        private System.Windows.Forms.TextBox valorCadenaTextBox;
        private System.Windows.Forms.TextBox valorDecimalTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.CheckBox estadoCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox fechaModificacionTextBox;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox1;
        private System.Windows.Forms.TextBox fechaRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}