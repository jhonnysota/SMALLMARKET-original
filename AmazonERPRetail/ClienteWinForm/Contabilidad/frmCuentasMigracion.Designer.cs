namespace ClienteWinForm.Contabilidad
{
    partial class frmCuentasMigracion
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
            System.Windows.Forms.Label cuentadestinoLabel;
            System.Windows.Forms.Label ccostoLabel;
            System.Windows.Forms.Label tipoLabel;
            System.Windows.Forms.Label cuentaorigenLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCtaIndusoft = new System.Windows.Forms.Button();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.txtNombreCtaIndusoft = new ControlesWinForm.SuperTextBox();
            this.txtCtaIndusoft = new ControlesWinForm.SuperTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCtaDestino = new System.Windows.Forms.Button();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtCCostos = new ControlesWinForm.SuperTextBox();
            this.txtNombreOrigen = new ControlesWinForm.SuperTextBox();
            this.txtNombreDestino = new ControlesWinForm.SuperTextBox();
            this.txtCtaOrigen = new ControlesWinForm.SuperTextBox();
            this.txtCtaDestino = new ControlesWinForm.SuperTextBox();
            codCuentaLabel = new System.Windows.Forms.Label();
            cuentadestinoLabel = new System.Windows.Forms.Label();
            ccostoLabel = new System.Windows.Forms.Label();
            tipoLabel = new System.Windows.Forms.Label();
            cuentaorigenLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // codCuentaLabel
            // 
            codCuentaLabel.AutoSize = true;
            codCuentaLabel.Location = new System.Drawing.Point(33, 35);
            codCuentaLabel.Name = "codCuentaLabel";
            codCuentaLabel.Size = new System.Drawing.Size(41, 13);
            codCuentaLabel.TabIndex = 2;
            codCuentaLabel.Text = "Cuenta";
            // 
            // cuentadestinoLabel
            // 
            cuentadestinoLabel.AutoSize = true;
            cuentadestinoLabel.Location = new System.Drawing.Point(15, 32);
            cuentadestinoLabel.Name = "cuentadestinoLabel";
            cuentadestinoLabel.Size = new System.Drawing.Size(80, 13);
            cuentadestinoLabel.TabIndex = 4;
            cuentadestinoLabel.Text = "Cuenta Destino";
            // 
            // ccostoLabel
            // 
            ccostoLabel.AutoSize = true;
            ccostoLabel.Location = new System.Drawing.Point(15, 75);
            ccostoLabel.Name = "ccostoLabel";
            ccostoLabel.Size = new System.Drawing.Size(49, 13);
            ccostoLabel.TabIndex = 0;
            ccostoLabel.Text = "C.Costos";
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Location = new System.Drawing.Point(15, 97);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(28, 13);
            tipoLabel.TabIndex = 18;
            tipoLabel.Text = "Tipo";
            // 
            // cuentaorigenLabel
            // 
            cuentaorigenLabel.AutoSize = true;
            cuentaorigenLabel.Location = new System.Drawing.Point(15, 53);
            cuentaorigenLabel.Name = "cuentaorigenLabel";
            cuentaorigenLabel.Size = new System.Drawing.Size(75, 13);
            cuentaorigenLabel.TabIndex = 6;
            cuentaorigenLabel.Text = "Cuenta Origen";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btCtaIndusoft);
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Controls.Add(this.txtNombreCtaIndusoft);
            this.panel1.Controls.Add(codCuentaLabel);
            this.panel1.Controls.Add(this.txtCtaIndusoft);
            this.panel1.Location = new System.Drawing.Point(4, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 64);
            this.panel1.TabIndex = 262;
            // 
            // btCtaIndusoft
            // 
            this.btCtaIndusoft.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaIndusoft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCtaIndusoft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCtaIndusoft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaIndusoft.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCtaIndusoft.Location = new System.Drawing.Point(514, 32);
            this.btCtaIndusoft.Name = "btCtaIndusoft";
            this.btCtaIndusoft.Size = new System.Drawing.Size(24, 18);
            this.btCtaIndusoft.TabIndex = 322;
            this.btCtaIndusoft.TabStop = false;
            this.btCtaIndusoft.UseVisualStyleBackColor = true;
            this.btCtaIndusoft.Click += new System.EventHandler(this.btCtaIndusoft_Click);
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(567, 21);
            this.labelDegradado1.TabIndex = 248;
            this.labelDegradado1.Text = "Indusoft";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombreCtaIndusoft
            // 
            this.txtNombreCtaIndusoft.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreCtaIndusoft.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNombreCtaIndusoft.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreCtaIndusoft.Location = new System.Drawing.Point(142, 31);
            this.txtNombreCtaIndusoft.Name = "txtNombreCtaIndusoft";
            this.txtNombreCtaIndusoft.Size = new System.Drawing.Size(371, 20);
            this.txtNombreCtaIndusoft.TabIndex = 9;
            this.txtNombreCtaIndusoft.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreCtaIndusoft.TextoVacio = "<Descripcion>";
            // 
            // txtCtaIndusoft
            // 
            this.txtCtaIndusoft.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaIndusoft.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaIndusoft.Location = new System.Drawing.Point(84, 31);
            this.txtCtaIndusoft.Name = "txtCtaIndusoft";
            this.txtCtaIndusoft.Size = new System.Drawing.Size(56, 20);
            this.txtCtaIndusoft.TabIndex = 3;
            this.txtCtaIndusoft.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaIndusoft.TextoVacio = "<Descripcion>";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btCtaDestino);
            this.panel3.Controls.Add(this.labelDegradado3);
            this.panel3.Controls.Add(this.cboTipo);
            this.panel3.Controls.Add(cuentadestinoLabel);
            this.panel3.Controls.Add(ccostoLabel);
            this.panel3.Controls.Add(tipoLabel);
            this.panel3.Controls.Add(this.txtCCostos);
            this.panel3.Controls.Add(this.txtNombreOrigen);
            this.panel3.Controls.Add(this.txtNombreDestino);
            this.panel3.Controls.Add(this.txtCtaOrigen);
            this.panel3.Controls.Add(cuentaorigenLabel);
            this.panel3.Controls.Add(this.txtCtaDestino);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 123);
            this.panel3.TabIndex = 261;
            // 
            // btCtaDestino
            // 
            this.btCtaDestino.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCtaDestino.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCtaDestino.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCtaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCtaDestino.Image = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btCtaDestino.Location = new System.Drawing.Point(530, 29);
            this.btCtaDestino.Name = "btCtaDestino";
            this.btCtaDestino.Size = new System.Drawing.Size(24, 18);
            this.btCtaDestino.TabIndex = 321;
            this.btCtaDestino.TabStop = false;
            this.btCtaDestino.UseVisualStyleBackColor = true;
            this.btCtaDestino.Click += new System.EventHandler(this.btCtaDestino_Click);
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(567, 21);
            this.labelDegradado3.TabIndex = 248;
            this.labelDegradado3.Text = "Datos ConCar";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "N",
            "A"});
            this.cboTipo.Location = new System.Drawing.Point(100, 93);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(56, 21);
            this.cboTipo.TabIndex = 19;
            // 
            // txtCCostos
            // 
            this.txtCCostos.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCCostos.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCCostos.Location = new System.Drawing.Point(100, 71);
            this.txtCCostos.Name = "txtCCostos";
            this.txtCCostos.Size = new System.Drawing.Size(56, 20);
            this.txtCCostos.TabIndex = 1;
            this.txtCCostos.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCCostos.TextoVacio = "<Descripcion>";
            // 
            // txtNombreOrigen
            // 
            this.txtNombreOrigen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreOrigen.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNombreOrigen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreOrigen.Location = new System.Drawing.Point(158, 49);
            this.txtNombreOrigen.Name = "txtNombreOrigen";
            this.txtNombreOrigen.Size = new System.Drawing.Size(371, 20);
            this.txtNombreOrigen.TabIndex = 15;
            this.txtNombreOrigen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreOrigen.TextoVacio = "<Descripcion>";
            // 
            // txtNombreDestino
            // 
            this.txtNombreDestino.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtNombreDestino.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNombreDestino.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNombreDestino.Location = new System.Drawing.Point(158, 28);
            this.txtNombreDestino.Name = "txtNombreDestino";
            this.txtNombreDestino.Size = new System.Drawing.Size(371, 20);
            this.txtNombreDestino.TabIndex = 13;
            this.txtNombreDestino.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtNombreDestino.TextoVacio = "<Descripcion>";
            // 
            // txtCtaOrigen
            // 
            this.txtCtaOrigen.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaOrigen.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaOrigen.Location = new System.Drawing.Point(100, 49);
            this.txtCtaOrigen.Name = "txtCtaOrigen";
            this.txtCtaOrigen.Size = new System.Drawing.Size(56, 20);
            this.txtCtaOrigen.TabIndex = 7;
            this.txtCtaOrigen.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaOrigen.TextoVacio = "<Descripcion>";
            // 
            // txtCtaDestino
            // 
            this.txtCtaDestino.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCtaDestino.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCtaDestino.Location = new System.Drawing.Point(100, 28);
            this.txtCtaDestino.Name = "txtCtaDestino";
            this.txtCtaDestino.Size = new System.Drawing.Size(56, 20);
            this.txtCtaDestino.TabIndex = 5;
            this.txtCtaDestino.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtCtaDestino.TextoVacio = "<Descripcion>";
            // 
            // frmCuentasMigracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 196);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.Name = "frmCuentasMigracion";
            this.Text = "Cuentas para la Migración";
            this.Load += new System.EventHandler(this.frmCuentasMigracion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesWinForm.SuperTextBox txtCCostos;
        private ControlesWinForm.SuperTextBox txtCtaIndusoft;
        private ControlesWinForm.SuperTextBox txtCtaDestino;
        private ControlesWinForm.SuperTextBox txtCtaOrigen;
        private ControlesWinForm.SuperTextBox txtNombreCtaIndusoft;
        private ControlesWinForm.SuperTextBox txtNombreDestino;
        private ControlesWinForm.SuperTextBox txtNombreOrigen;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Panel panel3;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.Button btCtaIndusoft;
        private System.Windows.Forms.Button btCtaDestino;
    }
}