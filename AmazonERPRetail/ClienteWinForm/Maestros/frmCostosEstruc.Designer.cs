namespace ClienteWinForm.Maestros
{
    partial class frmCostosEstruc
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.NumNivel = new System.Windows.Forms.NumericUpDown();
            this.cboIndNivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLong = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDes = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblComercial = new System.Windows.Forms.Label();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumNivel)).BeginInit();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.NumNivel);
            this.pnlDatos.Controls.Add(this.cboIndNivel);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.txtLong);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtDes);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.lblComercial);
            this.pnlDatos.Location = new System.Drawing.Point(4, 4);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(275, 101);
            this.pnlDatos.TabIndex = 127;
            // 
            // NumNivel
            // 
            this.NumNivel.Location = new System.Drawing.Point(80, 26);
            this.NumNivel.Name = "NumNivel";
            this.NumNivel.Size = new System.Drawing.Size(41, 20);
            this.NumNivel.TabIndex = 285;
            // 
            // cboIndNivel
            // 
            this.cboIndNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndNivel.FormattingEnabled = true;
            this.cboIndNivel.Location = new System.Drawing.Point(205, 26);
            this.cboIndNivel.Name = "cboIndNivel";
            this.cboIndNivel.Size = new System.Drawing.Size(59, 21);
            this.cboIndNivel.TabIndex = 283;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 282;
            this.label5.Text = "Ind. Ultimo Nivel";
            // 
            // txtLong
            // 
            this.txtLong.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtLong.BackColor = System.Drawing.Color.White;
            this.txtLong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLong.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtLong.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLong.Location = new System.Drawing.Point(80, 71);
            this.txtLong.Margin = new System.Windows.Forms.Padding(2);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(64, 20);
            this.txtLong.TabIndex = 281;
            this.txtLong.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtLong.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 280;
            this.label6.Text = "Longitud";
            // 
            // txtDes
            // 
            this.txtDes.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDes.BackColor = System.Drawing.Color.White;
            this.txtDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDes.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.Location = new System.Drawing.Point(80, 49);
            this.txtDes.Margin = new System.Windows.Forms.Padding(2);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(184, 20);
            this.txtDes.TabIndex = 279;
            this.txtDes.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDes.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 278;
            this.label1.Text = "Descripcion";
            // 
            // lblComercial
            // 
            this.lblComercial.AutoSize = true;
            this.lblComercial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComercial.Location = new System.Drawing.Point(9, 30);
            this.lblComercial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComercial.Name = "lblComercial";
            this.lblComercial.Size = new System.Drawing.Size(30, 13);
            this.lblComercial.TabIndex = 115;
            this.lblComercial.Text = "Nivel";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label7);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtFechaRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(282, 4);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(265, 121);
            this.pnlAuditoria.TabIndex = 126;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(12, 95);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(119, 91);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(119, 47);
            this.txtFechaRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtFechaRegistro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(119, 25);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(119, 69);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(273, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 18);
            this.label7.TabIndex = 347;
            this.label7.Text = "Auditoria";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCostosEstruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 129);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmCostosEstruc";
            this.Text = "Costos Estructura";
            this.Load += new System.EventHandler(this.frmCostosEstruc_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumNivel)).EndInit();
            this.pnlAuditoria.ResumeLayout(false);
            this.pnlAuditoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.NumericUpDown NumNivel;
        private System.Windows.Forms.ComboBox cboIndNivel;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtLong;
        private System.Windows.Forms.Label label6;
        private ControlesWinForm.SuperTextBox txtDes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComercial;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}