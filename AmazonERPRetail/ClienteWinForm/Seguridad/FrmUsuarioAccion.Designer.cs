namespace ClienteWinForm.Seguridad
{
    partial class FrmUsuarioAccion
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label fechaRegistroLabel;
            System.Windows.Forms.Label usuarioRegistroLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDegradado1 = new MyLabelG.LabelDegradado();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.txtOpcion = new System.Windows.Forms.TextBox();
            this.chklbListaCrud = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDegradado3 = new MyLabelG.LabelDegradado();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            fechaRegistroLabel = new System.Windows.Forms.Label();
            usuarioRegistroLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 13);
            label1.TabIndex = 6;
            label1.Text = "Empresa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 4;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 13);
            label3.TabIndex = 0;
            label3.Text = "Grupo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(13, 98);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(41, 13);
            label4.TabIndex = 2;
            label4.Text = "Opción";
            // 
            // fechaRegistroLabel
            // 
            fechaRegistroLabel.AutoSize = true;
            fechaRegistroLabel.Location = new System.Drawing.Point(325, 27);
            fechaRegistroLabel.Name = "fechaRegistroLabel";
            fechaRegistroLabel.Size = new System.Drawing.Size(79, 13);
            fechaRegistroLabel.TabIndex = 2;
            fechaRegistroLabel.Text = "Fecha Registro";
            // 
            // usuarioRegistroLabel
            // 
            usuarioRegistroLabel.AutoSize = true;
            usuarioRegistroLabel.Location = new System.Drawing.Point(26, 27);
            usuarioRegistroLabel.Name = "usuarioRegistroLabel";
            usuarioRegistroLabel.Size = new System.Drawing.Size(85, 13);
            usuarioRegistroLabel.TabIndex = 0;
            usuarioRegistroLabel.Text = "Usuario Registro";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDegradado1);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.txtEmpresa);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.txtGrupo);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(this.txtOpcion);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 127);
            this.panel1.TabIndex = 253;
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
            this.labelDegradado1.Size = new System.Drawing.Size(602, 18);
            this.labelDegradado1.TabIndex = 252;
            this.labelDegradado1.Text = "Datos";
            this.labelDegradado1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Location = new System.Drawing.Point(64, 28);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(523, 20);
            this.txtEmpresa.TabIndex = 7;
            this.txtEmpresa.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Info;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(64, 50);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(523, 20);
            this.txtUsuario.TabIndex = 5;
            this.txtUsuario.TabStop = false;
            // 
            // txtGrupo
            // 
            this.txtGrupo.BackColor = System.Drawing.SystemColors.Info;
            this.txtGrupo.Enabled = false;
            this.txtGrupo.Location = new System.Drawing.Point(64, 72);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(523, 20);
            this.txtGrupo.TabIndex = 1;
            this.txtGrupo.TabStop = false;
            // 
            // txtOpcion
            // 
            this.txtOpcion.BackColor = System.Drawing.SystemColors.Info;
            this.txtOpcion.Enabled = false;
            this.txtOpcion.Location = new System.Drawing.Point(64, 94);
            this.txtOpcion.Name = "txtOpcion";
            this.txtOpcion.Size = new System.Drawing.Size(523, 20);
            this.txtOpcion.TabIndex = 3;
            this.txtOpcion.TabStop = false;
            // 
            // chklbListaCrud
            // 
            this.chklbListaCrud.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chklbListaCrud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklbListaCrud.CheckOnClick = true;
            this.chklbListaCrud.ColumnWidth = 350;
            this.chklbListaCrud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklbListaCrud.FormattingEnabled = true;
            this.chklbListaCrud.Items.AddRange(new object[] {
            ""});
            this.chklbListaCrud.Location = new System.Drawing.Point(9, 23);
            this.chklbListaCrud.Name = "chklbListaCrud";
            this.chklbListaCrud.Size = new System.Drawing.Size(422, 150);
            this.chklbListaCrud.TabIndex = 261;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelDegradado3);
            this.panel2.Controls.Add(this.chklbListaCrud);
            this.panel2.Location = new System.Drawing.Point(609, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 180);
            this.panel2.TabIndex = 254;
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
            this.labelDegradado3.Size = new System.Drawing.Size(443, 18);
            this.labelDegradado3.TabIndex = 252;
            this.labelDegradado3.Text = "Opciones";
            this.labelDegradado3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.Info;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Location = new System.Drawing.Point(413, 23);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(147, 20);
            this.txtFechaRegistro.TabIndex = 3;
            this.txtFechaRegistro.TabStop = false;
            // 
            // txtUsuarioRegistro
            // 
            this.txtUsuarioRegistro.BackColor = System.Drawing.SystemColors.Info;
            this.txtUsuarioRegistro.Enabled = false;
            this.txtUsuarioRegistro.Location = new System.Drawing.Point(121, 23);
            this.txtUsuarioRegistro.Name = "txtUsuarioRegistro";
            this.txtUsuarioRegistro.Size = new System.Drawing.Size(147, 20);
            this.txtUsuarioRegistro.TabIndex = 1;
            this.txtUsuarioRegistro.TabStop = false;
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
            this.labelDegradado2.Size = new System.Drawing.Size(602, 18);
            this.labelDegradado2.TabIndex = 252;
            this.labelDegradado2.Text = "Auditoria";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.labelDegradado2);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioRegistro);
            this.pnlAuditoria.Controls.Add(usuarioRegistroLabel);
            this.pnlAuditoria.Controls.Add(fechaRegistroLabel);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Location = new System.Drawing.Point(3, 132);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(604, 51);
            this.pnlAuditoria.TabIndex = 4;
            // 
            // FrmUsuarioAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 185);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAuditoria);
            this.MaximizeBox = false;
            this.Name = "FrmUsuarioAccion";
            this.Text = "Restricción de Acciones en las Opciones del Menú";
            this.Load += new System.EventHandler(this.FrmUsuarioAccion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private MyLabelG.LabelDegradado labelDegradado1;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.TextBox txtOpcion;
        private System.Windows.Forms.CheckedListBox chklbListaCrud;
        private System.Windows.Forms.Panel panel2;
        private MyLabelG.LabelDegradado labelDegradado3;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.TextBox txtUsuarioRegistro;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel pnlAuditoria;
    }
}