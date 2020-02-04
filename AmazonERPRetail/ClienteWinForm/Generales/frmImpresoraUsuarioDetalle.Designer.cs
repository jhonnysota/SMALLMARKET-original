namespace ClienteWinForm.Generales
{
    partial class frmImpresoraUsuarioDetalle
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label9;
            this.txtCantidad = new ControlesWinForm.SuperTextBox();
            this.txtAlto = new ControlesWinForm.SuperTextBox();
            this.txtAncho = new ControlesWinForm.SuperTextBox();
            this.txtEspacios = new ControlesWinForm.SuperTextBox();
            this.txtId = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.txtFechaMod = new System.Windows.Forms.TextBox();
            this.txtUsuarioReg = new System.Windows.Forms.TextBox();
            this.txtUsuarioMod = new System.Windows.Forms.TextBox();
            this.txtFechaReg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPnlBase.Size = new System.Drawing.Size(265, 18);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(548, 25);
            this.lblTituloPrincipal.Text = "Etiquetas de Cód. Barras";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(521, 2);
            this.btCerrar.TabStop = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.txtId);
            this.pnlBase.Controls.Add(label2);
            this.pnlBase.Controls.Add(this.txtEspacios);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Controls.Add(label1);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Controls.Add(this.txtCantidad);
            this.pnlBase.Controls.Add(label8);
            this.pnlBase.Controls.Add(this.txtAlto);
            this.pnlBase.Controls.Add(this.txtAncho);
            this.pnlBase.Location = new System.Drawing.Point(5, 28);
            this.pnlBase.Size = new System.Drawing.Size(267, 141);
            this.pnlBase.Controls.SetChildIndex(this.txtAncho, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtAlto, 0);
            this.pnlBase.Controls.SetChildIndex(label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCantidad, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(label1, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtEspacios, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtId, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(280, 177);
            this.btCancelar.Size = new System.Drawing.Size(112, 26);
            this.btCancelar.TabIndex = 11;
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(156, 177);
            this.btAceptar.Size = new System.Drawing.Size(112, 26);
            this.btAceptar.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(11, 94);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(121, 13);
            label8.TabIndex = 336;
            label8.Text = "Cant. Etiqueta por Linea";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(11, 72);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(107, 13);
            label7.TabIndex = 335;
            label7.Text = "Alto de Etiqueta (mm)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(11, 50);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(120, 13);
            label6.TabIndex = 334;
            label6.Text = "Ancho de Etiqueta (mm)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 116);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(172, 13);
            label1.TabIndex = 340;
            label1.Text = "Espacio entre Etiquetas(Horizontal)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(11, 28);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 13);
            label2.TabIndex = 342;
            label2.Text = "Item";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(8, 104);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 13);
            label3.TabIndex = 6;
            label3.Text = "Fecha Modificación";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(8, 83);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(106, 13);
            label4.TabIndex = 4;
            label4.Text = "Usuario Modificación";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(8, 42);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 13);
            label5.TabIndex = 0;
            label5.Text = "Usuario Registro";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(8, 63);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(79, 13);
            label9.TabIndex = 2;
            label9.Text = "Fecha Registro";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(185, 90);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(67, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtCantidad.TextoVacio = "<Descripcion>";
            // 
            // txtAlto
            // 
            this.txtAlto.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAlto.BackColor = System.Drawing.Color.White;
            this.txtAlto.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAlto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlto.Location = new System.Drawing.Point(185, 68);
            this.txtAlto.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(67, 20);
            this.txtAlto.TabIndex = 2;
            this.txtAlto.Text = "0.00";
            this.txtAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAlto.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtAlto.TextoVacio = "<Descripcion>";
            // 
            // txtAncho
            // 
            this.txtAncho.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtAncho.BackColor = System.Drawing.Color.White;
            this.txtAncho.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAncho.Location = new System.Drawing.Point(185, 46);
            this.txtAncho.Margin = new System.Windows.Forms.Padding(2);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(67, 20);
            this.txtAncho.TabIndex = 1;
            this.txtAncho.Text = "0.00";
            this.txtAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAncho.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtAncho.TextoVacio = "<Descripcion>";
            // 
            // txtEspacios
            // 
            this.txtEspacios.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtEspacios.BackColor = System.Drawing.Color.White;
            this.txtEspacios.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtEspacios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspacios.Location = new System.Drawing.Point(185, 112);
            this.txtEspacios.Margin = new System.Windows.Forms.Padding(2);
            this.txtEspacios.Name = "txtEspacios";
            this.txtEspacios.Size = new System.Drawing.Size(67, 20);
            this.txtEspacios.TabIndex = 4;
            this.txtEspacios.Text = "0";
            this.txtEspacios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEspacios.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtEspacios.TextoVacio = "<Descripcion>";
            // 
            // txtId
            // 
            this.txtId.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtId.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(185, 24);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(67, 20);
            this.txtId.TabIndex = 343;
            this.txtId.TabStop = false;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtId.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label10);
            this.pnlAuditoria.Controls.Add(label3);
            this.pnlAuditoria.Controls.Add(this.txtFechaMod);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioReg);
            this.pnlAuditoria.Controls.Add(label4);
            this.pnlAuditoria.Controls.Add(label5);
            this.pnlAuditoria.Controls.Add(this.txtUsuarioMod);
            this.pnlAuditoria.Controls.Add(this.txtFechaReg);
            this.pnlAuditoria.Controls.Add(label9);
            this.pnlAuditoria.Location = new System.Drawing.Point(275, 28);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(267, 141);
            this.pnlAuditoria.TabIndex = 260;
            // 
            // txtFechaMod
            // 
            this.txtFechaMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaMod.Enabled = false;
            this.txtFechaMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaMod.Location = new System.Drawing.Point(116, 100);
            this.txtFechaMod.Name = "txtFechaMod";
            this.txtFechaMod.Size = new System.Drawing.Size(134, 20);
            this.txtFechaMod.TabIndex = 7;
            this.txtFechaMod.TabStop = false;
            // 
            // txtUsuarioReg
            // 
            this.txtUsuarioReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioReg.Enabled = false;
            this.txtUsuarioReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioReg.Location = new System.Drawing.Point(116, 37);
            this.txtUsuarioReg.Name = "txtUsuarioReg";
            this.txtUsuarioReg.Size = new System.Drawing.Size(134, 20);
            this.txtUsuarioReg.TabIndex = 1;
            this.txtUsuarioReg.TabStop = false;
            // 
            // txtUsuarioMod
            // 
            this.txtUsuarioMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuarioMod.Enabled = false;
            this.txtUsuarioMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioMod.Location = new System.Drawing.Point(116, 79);
            this.txtUsuarioMod.Name = "txtUsuarioMod";
            this.txtUsuarioMod.Size = new System.Drawing.Size(134, 20);
            this.txtUsuarioMod.TabIndex = 5;
            this.txtUsuarioMod.TabStop = false;
            // 
            // txtFechaReg
            // 
            this.txtFechaReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaReg.Enabled = false;
            this.txtFechaReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaReg.Location = new System.Drawing.Point(116, 58);
            this.txtFechaReg.Name = "txtFechaReg";
            this.txtFechaReg.Size = new System.Drawing.Size(134, 20);
            this.txtFechaReg.TabIndex = 3;
            this.txtFechaReg.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 18);
            this.label10.TabIndex = 347;
            this.label10.Text = "Auditoria";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmImpresoraUsuarioDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 210);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmImpresoraUsuarioDetalle";
            this.Text = "frmImpresoraUsuarioDetalle";
            this.Load += new System.EventHandler(this.frmImpresoraUsuarioDetalle_Load);
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

        private ControlesWinForm.SuperTextBox txtId;
        private ControlesWinForm.SuperTextBox txtEspacios;
        private ControlesWinForm.SuperTextBox txtCantidad;
        private ControlesWinForm.SuperTextBox txtAlto;
        private ControlesWinForm.SuperTextBox txtAncho;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.TextBox txtFechaMod;
        private System.Windows.Forms.TextBox txtUsuarioReg;
        private System.Windows.Forms.TextBox txtUsuarioMod;
        private System.Windows.Forms.TextBox txtFechaReg;
        private System.Windows.Forms.Label label10;
    }
}