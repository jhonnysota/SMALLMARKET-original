namespace ClienteWinForm.Ventas
{
    partial class frmVehiculos
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
            this.lblComercial = new System.Windows.Forms.Label();
            this.txtInscripcion = new ControlesWinForm.SuperTextBox();
            this.lblRazon = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescripcion = new ControlesWinForm.SuperTextBox();
            this.txtPlaca = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarca = new ControlesWinForm.SuperTextBox();
            this.pnlAuditoria = new System.Windows.Forms.Panel();
            this.fechaModificacionLabel = new System.Windows.Forms.Label();
            this.txtModifica = new System.Windows.Forms.TextBox();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuRegistra = new System.Windows.Forms.TextBox();
            this.txtUsuModifica = new System.Windows.Forms.TextBox();
            this.txtIdVehiculo = new ControlesWinForm.SuperTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCapacidad = new ControlesWinForm.SuperTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.pnlAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(263, 19);
            this.lblTitPnlBase.Text = "Datos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(279, 25);
            this.lblTituloPrincipal.Text = "Vehículo";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(252, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.txtCapacidad);
            this.pnlBase.Controls.Add(this.txtIdVehiculo);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txtMarca);
            this.pnlBase.Controls.Add(this.lblComercial);
            this.pnlBase.Controls.Add(this.txtInscripcion);
            this.pnlBase.Controls.Add(this.lblRazon);
            this.pnlBase.Controls.Add(this.label9);
            this.pnlBase.Controls.Add(this.txtDescripcion);
            this.pnlBase.Controls.Add(this.txtPlaca);
            this.pnlBase.Location = new System.Drawing.Point(7, 30);
            this.pnlBase.Size = new System.Drawing.Size(265, 161);
            this.pnlBase.TabIndex = 1;
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtPlaca, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.pnlBase.Controls.SetChildIndex(this.label9, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblRazon, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtInscripcion, 0);
            this.pnlBase.Controls.SetChildIndex(this.lblComercial, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtMarca, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.label8, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtIdVehiculo, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtCapacidad, 0);
            this.pnlBase.Controls.SetChildIndex(this.label5, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(143, 326);
            this.btCancelar.Size = new System.Drawing.Size(116, 24);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(19, 326);
            this.btAceptar.Size = new System.Drawing.Size(116, 24);
            this.btAceptar.TabIndex = 7;
            // 
            // lblComercial
            // 
            this.lblComercial.AutoSize = true;
            this.lblComercial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComercial.Location = new System.Drawing.Point(11, 76);
            this.lblComercial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComercial.Name = "lblComercial";
            this.lblComercial.Size = new System.Drawing.Size(73, 13);
            this.lblComercial.TabIndex = 275;
            this.lblComercial.Text = "N° Inscripción";
            // 
            // txtInscripcion
            // 
            this.txtInscripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtInscripcion.BackColor = System.Drawing.Color.White;
            this.txtInscripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtInscripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInscripcion.Location = new System.Drawing.Point(104, 72);
            this.txtInscripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtInscripcion.Name = "txtInscripcion";
            this.txtInscripcion.Size = new System.Drawing.Size(146, 20);
            this.txtInscripcion.TabIndex = 3;
            this.txtInscripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtInscripcion.TextoVacio = "<Descripcion>";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.Location = new System.Drawing.Point(11, 54);
            this.lblRazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(32, 13);
            this.lblRazon.TabIndex = 274;
            this.lblRazon.Text = "Placa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 273;
            this.label9.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(104, 93);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.MaxLength = 11;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(146, 20);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDescripcion.TextoVacio = "<Descripcion>";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaca.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPlaca.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(104, 51);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(146, 20);
            this.txtPlaca.TabIndex = 2;
            this.txtPlaca.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtPlaca.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 278;
            this.label1.Text = "Marca";
            // 
            // txtMarca
            // 
            this.txtMarca.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtMarca.BackColor = System.Drawing.Color.White;
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtMarca.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(104, 114);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarca.MaxLength = 11;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(146, 20);
            this.txtMarca.TabIndex = 5;
            this.txtMarca.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtMarca.TextoVacio = "<Descripcion>";
            // 
            // pnlAuditoria
            // 
            this.pnlAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.pnlAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditoria.Controls.Add(this.label6);
            this.pnlAuditoria.Controls.Add(this.fechaModificacionLabel);
            this.pnlAuditoria.Controls.Add(this.txtModifica);
            this.pnlAuditoria.Controls.Add(this.txtRegistro);
            this.pnlAuditoria.Controls.Add(this.label2);
            this.pnlAuditoria.Controls.Add(this.label3);
            this.pnlAuditoria.Controls.Add(this.label4);
            this.pnlAuditoria.Controls.Add(this.txtUsuRegistra);
            this.pnlAuditoria.Controls.Add(this.txtUsuModifica);
            this.pnlAuditoria.Location = new System.Drawing.Point(7, 201);
            this.pnlAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAuditoria.Name = "pnlAuditoria";
            this.pnlAuditoria.Size = new System.Drawing.Size(265, 121);
            this.pnlAuditoria.TabIndex = 123;
            // 
            // fechaModificacionLabel
            // 
            this.fechaModificacionLabel.AutoSize = true;
            this.fechaModificacionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaModificacionLabel.Location = new System.Drawing.Point(12, 96);
            this.fechaModificacionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fechaModificacionLabel.Name = "fechaModificacionLabel";
            this.fechaModificacionLabel.Size = new System.Drawing.Size(97, 13);
            this.fechaModificacionLabel.TabIndex = 6;
            this.fechaModificacionLabel.Text = "Fecha Modificación";
            // 
            // txtModifica
            // 
            this.txtModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtModifica.Enabled = false;
            this.txtModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifica.Location = new System.Drawing.Point(119, 92);
            this.txtModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtModifica.Name = "txtModifica";
            this.txtModifica.Size = new System.Drawing.Size(133, 20);
            this.txtModifica.TabIndex = 0;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRegistro.Enabled = false;
            this.txtRegistro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.Location = new System.Drawing.Point(119, 48);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(133, 20);
            this.txtRegistro.TabIndex = 0;
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
            this.label3.Location = new System.Drawing.Point(12, 52);
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
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuario Modificación";
            // 
            // txtUsuRegistra
            // 
            this.txtUsuRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistra.Enabled = false;
            this.txtUsuRegistra.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistra.Location = new System.Drawing.Point(119, 26);
            this.txtUsuRegistra.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuRegistra.Name = "txtUsuRegistra";
            this.txtUsuRegistra.Size = new System.Drawing.Size(133, 20);
            this.txtUsuRegistra.TabIndex = 0;
            // 
            // txtUsuModifica
            // 
            this.txtUsuModifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModifica.Enabled = false;
            this.txtUsuModifica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModifica.Location = new System.Drawing.Point(119, 70);
            this.txtUsuModifica.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuModifica.Name = "txtUsuModifica";
            this.txtUsuModifica.Size = new System.Drawing.Size(133, 20);
            this.txtUsuModifica.TabIndex = 0;
            // 
            // txtIdVehiculo
            // 
            this.txtIdVehiculo.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtIdVehiculo.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdVehiculo.Enabled = false;
            this.txtIdVehiculo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdVehiculo.Location = new System.Drawing.Point(104, 30);
            this.txtIdVehiculo.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdVehiculo.Name = "txtIdVehiculo";
            this.txtIdVehiculo.Size = new System.Drawing.Size(31, 20);
            this.txtIdVehiculo.TabIndex = 280;
            this.txtIdVehiculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdVehiculo.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdVehiculo.TextoVacio = "<Descripcion>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 279;
            this.label8.Text = "Cód. Vehículo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 282;
            this.label5.Text = "Capacidad";
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCapacidad.BackColor = System.Drawing.Color.White;
            this.txtCapacidad.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCapacidad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidad.Location = new System.Drawing.Point(104, 135);
            this.txtCapacidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(63, 20);
            this.txtCapacidad.TabIndex = 6;
            this.txtCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapacidad.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCapacidad.TextoVacio = "<Descripcion>";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 18);
            this.label6.TabIndex = 280;
            this.label6.Text = "Auditoria";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 356);
            this.Controls.Add(this.pnlAuditoria);
            this.Name = "frmVehiculos";
            this.Text = "frmVehiculos";
            this.Load += new System.EventHandler(this.frmVehiculos_Load);
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

        private System.Windows.Forms.Label lblComercial;
        private ControlesWinForm.SuperTextBox txtInscripcion;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Label label9;
        private ControlesWinForm.SuperTextBox txtDescripcion;
        private ControlesWinForm.SuperTextBox txtPlaca;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtMarca;
        private System.Windows.Forms.Panel pnlAuditoria;
        private System.Windows.Forms.Label fechaModificacionLabel;
        private System.Windows.Forms.TextBox txtModifica;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuRegistra;
        private System.Windows.Forms.TextBox txtUsuModifica;
        private System.Windows.Forms.Label label5;
        private ControlesWinForm.SuperTextBox txtCapacidad;
        private ControlesWinForm.SuperTextBox txtIdVehiculo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}