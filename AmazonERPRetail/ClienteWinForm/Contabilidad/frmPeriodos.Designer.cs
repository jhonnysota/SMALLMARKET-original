namespace ClienteWinForm.Contabilidad
{
    partial class frmPeriodos
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
            System.Windows.Forms.Label mesPeriodoLabel;
            System.Windows.Forms.Label fecInicioLabel;
            System.Windows.Forms.Label fecFinalLabel;
            System.Windows.Forms.Label anioPeriodoLabel;
            System.Windows.Forms.Label desPeriodoLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTCVenta = new ControlesWinForm.SuperTextBox();
            this.bsPeriodos = new System.Windows.Forms.BindingSource(this.components);
            this.txtTCCompra = new ControlesWinForm.SuperTextBox();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.dtpFecInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFecFin = new System.Windows.Forms.DateTimePicker();
            this.txtDesMes = new ControlesWinForm.SuperTextBox();
            this.txtMes = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usuarioRegistroTextBox = new System.Windows.Forms.TextBox();
            this.usuarioModificacionTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            mesPeriodoLabel = new System.Windows.Forms.Label();
            fecInicioLabel = new System.Windows.Forms.Label();
            fecFinalLabel = new System.Windows.Forms.Label();
            anioPeriodoLabel = new System.Windows.Forms.Label();
            desPeriodoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodos)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // mesPeriodoLabel
            // 
            mesPeriodoLabel.AutoSize = true;
            mesPeriodoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mesPeriodoLabel.Location = new System.Drawing.Point(11, 37);
            mesPeriodoLabel.Name = "mesPeriodoLabel";
            mesPeriodoLabel.Size = new System.Drawing.Size(26, 13);
            mesPeriodoLabel.TabIndex = 8;
            mesPeriodoLabel.Text = "Mes";
            // 
            // fecInicioLabel
            // 
            fecInicioLabel.AutoSize = true;
            fecInicioLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fecInicioLabel.Location = new System.Drawing.Point(11, 83);
            fecInicioLabel.Name = "fecInicioLabel";
            fecInicioLabel.Size = new System.Drawing.Size(64, 13);
            fecInicioLabel.TabIndex = 4;
            fecInicioLabel.Text = "Fecha Inicio";
            // 
            // fecFinalLabel
            // 
            fecFinalLabel.AutoSize = true;
            fecFinalLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fecFinalLabel.Location = new System.Drawing.Point(11, 106);
            fecFinalLabel.Name = "fecFinalLabel";
            fecFinalLabel.Size = new System.Drawing.Size(61, 13);
            fecFinalLabel.TabIndex = 2;
            fecFinalLabel.Text = "Fecha Final";
            // 
            // anioPeriodoLabel
            // 
            anioPeriodoLabel.AutoSize = true;
            anioPeriodoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            anioPeriodoLabel.Location = new System.Drawing.Point(141, 37);
            anioPeriodoLabel.Name = "anioPeriodoLabel";
            anioPeriodoLabel.Size = new System.Drawing.Size(26, 13);
            anioPeriodoLabel.TabIndex = 6;
            anioPeriodoLabel.Text = "Año";
            // 
            // desPeriodoLabel
            // 
            desPeriodoLabel.AutoSize = true;
            desPeriodoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desPeriodoLabel.Location = new System.Drawing.Point(11, 60);
            desPeriodoLabel.Name = "desPeriodoLabel";
            desPeriodoLabel.Size = new System.Drawing.Size(61, 13);
            desPeriodoLabel.TabIndex = 1;
            desPeriodoLabel.Text = "Descripción";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 106);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 13);
            label1.TabIndex = 6;
            label1.Text = "Fecha Modificación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(11, 83);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 13);
            label3.TabIndex = 4;
            label3.Text = "Usuario Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(11, 38);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(86, 13);
            label4.TabIndex = 0;
            label4.Text = "Usuario Registro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(11, 60);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 2;
            label5.Text = "Fecha Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(11, 130);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 13);
            label2.TabIndex = 251;
            label2.Text = "TC Compra";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(11, 154);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 13);
            label6.TabIndex = 253;
            label6.Text = "TC Venta";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTCVenta);
            this.panel1.Controls.Add(label6);
            this.panel1.Controls.Add(this.txtTCCompra);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.labelDegradado3);
            this.panel1.Controls.Add(mesPeriodoLabel);
            this.panel1.Controls.Add(fecInicioLabel);
            this.panel1.Controls.Add(this.txtAnio);
            this.panel1.Controls.Add(this.dtpFecInicio);
            this.panel1.Controls.Add(fecFinalLabel);
            this.panel1.Controls.Add(this.dtpFecFin);
            this.panel1.Controls.Add(anioPeriodoLabel);
            this.panel1.Controls.Add(this.txtDesMes);
            this.panel1.Controls.Add(desPeriodoLabel);
            this.panel1.Controls.Add(this.txtMes);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 180);
            this.panel1.TabIndex = 0;
            // 
            // txtTCVenta
            // 
            this.txtTCVenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTCVenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTCVenta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "TCVenta", true));
            this.txtTCVenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCVenta.Location = new System.Drawing.Point(78, 150);
            this.txtTCVenta.Name = "txtTCVenta";
            this.txtTCVenta.Size = new System.Drawing.Size(97, 21);
            this.txtTCVenta.TabIndex = 254;
            this.txtTCVenta.Text = "0.000";
            this.txtTCVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTCVenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTCVenta.TextoVacio = "<Descripcion>";
            // 
            // bsPeriodos
            // 
            this.bsPeriodos.DataSource = typeof(Entidades.Contabilidad.PeriodosE);
            // 
            // txtTCCompra
            // 
            this.txtTCCompra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtTCCompra.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtTCCompra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "TCCompra", true));
            this.txtTCCompra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCCompra.Location = new System.Drawing.Point(78, 126);
            this.txtTCCompra.Name = "txtTCCompra";
            this.txtTCCompra.Size = new System.Drawing.Size(97, 21);
            this.txtTCCompra.TabIndex = 252;
            this.txtTCCompra.Text = "0.000";
            this.txtTCCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTCCompra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtTCCompra.TextoVacio = "<Descripcion>";
            // 
            // labelDegradado3
            // 
            this.labelDegradado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado3.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado3.ForeColor = System.Drawing.Color.White;
            this.labelDegradado3.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado3.Name = "labelDegradado3";
            this.labelDegradado3.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado3.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado3.Size = new System.Drawing.Size(239, 21);
            this.labelDegradado3.TabIndex = 250;
            this.labelDegradado3.Text = "Datos";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAnio
            // 
            this.txtAnio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAnio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "AnioPeriodo", true));
            this.txtAnio.Enabled = false;
            this.txtAnio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAnio.Location = new System.Drawing.Point(178, 33);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(47, 21);
            this.txtAnio.TabIndex = 2;
            this.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFecInicio.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPeriodos, "fecInicio", true));
            this.dtpFecInicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecInicio.Location = new System.Drawing.Point(78, 79);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(97, 21);
            this.dtpFecInicio.TabIndex = 4;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPeriodos, "fecFinal", true));
            this.dtpFecFin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFin.Location = new System.Drawing.Point(78, 102);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(97, 21);
            this.dtpFecFin.TabIndex = 5;
            // 
            // txtDesMes
            // 
            this.txtDesMes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesMes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesMes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "desPeriodo", true));
            this.txtDesMes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesMes.Location = new System.Drawing.Point(78, 56);
            this.txtDesMes.Name = "txtDesMes";
            this.txtDesMes.Size = new System.Drawing.Size(147, 21);
            this.txtDesMes.TabIndex = 3;
            this.txtDesMes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesMes.TextoVacio = "<Descripcion>";
            // 
            // txtMes
            // 
            this.txtMes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "MesPeriodo", true));
            this.txtMes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(78, 33);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(32, 21);
            this.txtMes.TabIndex = 1;
            this.txtMes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMes.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado1);
            this.pnlAuditoria.Controls.Add(label1);
            this.pnlAuditoria.Controls.Add(this.textBox1);
            this.pnlAuditoria.Controls.Add(this.usuarioRegistroTextBox);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(this.usuarioModificacionTextBox);
            this.pnlAuditoria.Controls.Add(this.textBox2);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Location = new System.Drawing.Point(246, 3);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(259, 180);
            this.pnlAuditoria.TabIndex = 100;
            // 
            // labelDegradado1
            // 
            this.labelDegradado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado1.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado1.ForeColor = System.Drawing.Color.White;
            this.labelDegradado1.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado1.Name = "labelDegradado1";
            this.labelDegradado1.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado1.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado1.Size = new System.Drawing.Size(257, 21);
            this.labelDegradado1.TabIndex = 251;
            this.labelDegradado1.Text = "Auditoria";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "FechaModificacion", true));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(120, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 7;
            // 
            // usuarioRegistroTextBox
            // 
            this.usuarioRegistroTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioRegistroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "UsuarioRegistro", true));
            this.usuarioRegistroTextBox.Enabled = false;
            this.usuarioRegistroTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioRegistroTextBox.Location = new System.Drawing.Point(120, 33);
            this.usuarioRegistroTextBox.Name = "usuarioRegistroTextBox";
            this.usuarioRegistroTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioRegistroTextBox.TabIndex = 1;
            // 
            // usuarioModificacionTextBox
            // 
            this.usuarioModificacionTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.usuarioModificacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "UsuarioModificacion", true));
            this.usuarioModificacionTextBox.Enabled = false;
            this.usuarioModificacionTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioModificacionTextBox.Location = new System.Drawing.Point(120, 78);
            this.usuarioModificacionTextBox.Name = "usuarioModificacionTextBox";
            this.usuarioModificacionTextBox.Size = new System.Drawing.Size(125, 21);
            this.usuarioModificacionTextBox.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPeriodos, "FechaRegistro", true));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(120, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 21);
            this.textBox2.TabIndex = 3;
            // 
            // frmPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 186);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "frmPeriodos";
            this.Text = "Periodos";
            this.Load += new System.EventHandler(this.frmPeriodos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeriodos)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsPeriodos;
        private ControlesWinForm.SuperTextBox txtDesMes;
        private System.Windows.Forms.DateTimePicker dtpFecFin;
        private System.Windows.Forms.DateTimePicker dtpFecInicio;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox usuarioRegistroTextBox;
        private System.Windows.Forms.TextBox usuarioModificacionTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private ControlesWinForm.SuperTextBox txtMes;
        private MyLabelG.LabelDegradado labelDegradado3;
        private MyLabelG.LabelDegradado labelDegradado1;
        private ControlesWinForm.SuperTextBox txtTCVenta;
        private ControlesWinForm.SuperTextBox txtTCCompra;
    }
}