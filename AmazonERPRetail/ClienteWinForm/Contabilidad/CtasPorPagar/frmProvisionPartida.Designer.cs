namespace ClienteWinForm.CtasPorPagar
{
    partial class frmProvisionPartida
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
            System.Windows.Forms.Label codMonedaProvisionLabel;
            System.Windows.Forms.Label montoLabel;
            System.Windows.Forms.Label codPartidaPresuLabel;
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.codPartidaPresuTextBox = new System.Windows.Forms.TextBox();
            this.desPartidaPresuTextBox = new System.Windows.Forms.TextBox();
            this.btPartida = new System.Windows.Forms.Button();
            this.Montotextbox = new ControlesWinForm.SuperTextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            codMonedaProvisionLabel = new System.Windows.Forms.Label();
            montoLabel = new System.Windows.Forms.Label();
            codPartidaPresuLabel = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.Montotextbox);
            this.pnlBase.Controls.Add(this.btPartida);
            this.pnlBase.Controls.Add(this.desPartidaPresuTextBox);
            this.pnlBase.Controls.Add(codPartidaPresuLabel);
            this.pnlBase.Controls.Add(this.codPartidaPresuTextBox);
            this.pnlBase.Controls.Add(montoLabel);
            this.pnlBase.Controls.Add(codMonedaProvisionLabel);
            this.pnlBase.Controls.Add(this.cboMoneda);
            this.pnlBase.Size = new System.Drawing.Size(435, 139);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboMoneda, 0);
            this.pnlBase.Controls.SetChildIndex(codMonedaProvisionLabel, 0);
            this.pnlBase.Controls.SetChildIndex(montoLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.codPartidaPresuTextBox, 0);
            this.pnlBase.Controls.SetChildIndex(codPartidaPresuLabel, 0);
            this.pnlBase.Controls.SetChildIndex(this.desPartidaPresuTextBox, 0);
            this.pnlBase.Controls.SetChildIndex(this.btPartida, 0);
            this.pnlBase.Controls.SetChildIndex(this.Montotextbox, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(222, 172);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.Location = new System.Drawing.Point(98, 172);
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(433, 22);
            this.lblTitPnlBase.Text = "Datos de Partida";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(723, 25);
            this.lblTituloPrincipal.Text = "Detalle Por Partida";
            this.lblTituloPrincipal.Click += new System.EventHandler(this.lblTituloPrincipal_Click);
            // 
            // bsBase
            // 
            this.bsBase.DataSource = typeof(Entidades.CtasPorPagar.Provisiones_PorPartidaE);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(752, 2);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(14, 102);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(14, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(14, 34);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(14, 56);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // codMonedaProvisionLabel
            // 
            codMonedaProvisionLabel.AutoSize = true;
            codMonedaProvisionLabel.Location = new System.Drawing.Point(-1, 65);
            codMonedaProvisionLabel.Name = "codMonedaProvisionLabel";
            codMonedaProvisionLabel.Size = new System.Drawing.Size(49, 13);
            codMonedaProvisionLabel.TabIndex = 250;
            codMonedaProvisionLabel.Text = "Moneda:";
            // 
            // montoLabel
            // 
            montoLabel.AutoSize = true;
            montoLabel.Location = new System.Drawing.Point(8, 94);
            montoLabel.Name = "montoLabel";
            montoLabel.Size = new System.Drawing.Size(40, 13);
            montoLabel.TabIndex = 251;
            montoLabel.Text = "Monto:";
            // 
            // codPartidaPresuLabel
            // 
            codPartidaPresuLabel.AutoSize = true;
            codPartidaPresuLabel.Location = new System.Drawing.Point(5, 36);
            codPartidaPresuLabel.Name = "codPartidaPresuLabel";
            codPartidaPresuLabel.Size = new System.Drawing.Size(43, 13);
            codPartidaPresuLabel.TabIndex = 252;
            codPartidaPresuLabel.Text = "Partida:";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado4);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.textBox1);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(this.textBox2);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(448, 31);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(268, 139);
            this.pnlAuditoria.TabIndex = 257;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.Size = new System.Drawing.Size(266, 20);
            this.labelDegradado4.TabIndex = 251;
            this.labelDegradado4.Text = "Auditoria";
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "FechaModificacion", true));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(123, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 304;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioRegistroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(123, 29);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioRegistroTextBox.TabIndex = 300;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.usuarioModificacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(123, 74);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioModificacionTextBox.TabIndex = 303;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "FechaRegistro", true));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(123, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 21);
            this.textBox2.TabIndex = 301;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsBase, "CodMonedaProvision", true));
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(54, 61);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(128, 21);
            this.cboMoneda.TabIndex = 251;
            // 
            // codPartidaPresuTextBox
            // 
            this.codPartidaPresuTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "CodPartidaPresu", true));
            this.codPartidaPresuTextBox.Location = new System.Drawing.Point(54, 34);
            this.codPartidaPresuTextBox.Name = "codPartidaPresuTextBox";
            this.codPartidaPresuTextBox.ReadOnly = true;
            this.codPartidaPresuTextBox.Size = new System.Drawing.Size(70, 20);
            this.codPartidaPresuTextBox.TabIndex = 253;
            // 
            // desPartidaPresuTextBox
            // 
            this.desPartidaPresuTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "DesPartidaPresu", true));
            this.desPartidaPresuTextBox.Location = new System.Drawing.Point(127, 34);
            this.desPartidaPresuTextBox.Name = "desPartidaPresuTextBox";
            this.desPartidaPresuTextBox.ReadOnly = true;
            this.desPartidaPresuTextBox.Size = new System.Drawing.Size(270, 20);
            this.desPartidaPresuTextBox.TabIndex = 256;
            // 
            // btPartida
            // 
            this.btPartida.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPartida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btPartida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPartida.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btPartida.Location = new System.Drawing.Point(403, 35);
            this.btPartida.Name = "btPartida";
            this.btPartida.Size = new System.Drawing.Size(26, 20);
            this.btPartida.TabIndex = 334;
            this.btPartida.UseVisualStyleBackColor = true;
            this.btPartida.Click += new System.EventHandler(this.btPartida_Click);
            // 
            // Montotextbox
            // 
            this.Montotextbox.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.Montotextbox.BackColor = System.Drawing.SystemColors.Window;
            this.Montotextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Montotextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Montotextbox.ColorTextoVacio = System.Drawing.Color.Gray;
            this.Montotextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBase, "Monto", true));
            this.Montotextbox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Montotextbox.Location = new System.Drawing.Point(54, 89);
            this.Montotextbox.Margin = new System.Windows.Forms.Padding(2);
            this.Montotextbox.Name = "Montotextbox";
            this.Montotextbox.Size = new System.Drawing.Size(88, 20);
            this.Montotextbox.TabIndex = 364;
            this.Montotextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Montotextbox.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.Montotextbox.TextoVacio = "<Descripcion>";
            // 
            // frmProvisionPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 212);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmProvisionPartida";
            this.Text = "frmProvisionPartida";
            this.Load += new System.EventHandler(this.frmProvisionPartida_Load);
            this.Controls.SetChildIndex(this.pnlAuditoria, 0);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAuditoria;
        private MyLabelG.LabelDegradado labelDegradado4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox codPartidaPresuTextBox;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.TextBox desPartidaPresuTextBox;
        private System.Windows.Forms.Button btPartida;
        private ControlesWinForm.SuperTextBox Montotextbox;

    }
}