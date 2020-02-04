namespace ClienteWinForm.Maestros
{
    partial class frmArticuloDetalle
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
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label label1;
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.cboCarac = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(592, 25);
            this.lblTituloPrincipal.Text = " Articulo Detalle ";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(621, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Location = new System.Drawing.Point(554, 324);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(456, 173);
            this.btCancelar.Size = new System.Drawing.Size(116, 27);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(336, 173);
            this.btAceptar.Size = new System.Drawing.Size(116, 27);
            this.btAceptar.TabIndex = 20;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(12, 104);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(12, 81);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(12, 35);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(12, 58);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(9, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 13);
            label1.TabIndex = 254;
            label1.Text = "Característica ";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(label24);
            this.panel8.Controls.Add(this.txtFechaModificacion);
            this.panel8.Controls.Add(this.txtUsuRegistro);
            this.panel8.Controls.Add(label25);
            this.panel8.Controls.Add(label29);
            this.panel8.Controls.Add(this.txtUsuModificacion);
            this.panel8.Controls.Add(this.txtFechaRegistro);
            this.panel8.Controls.Add(label31);
            this.panel8.Location = new System.Drawing.Point(317, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(265, 133);
            this.panel8.TabIndex = 264;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(120, 99);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(129, 21);
            this.txtFechaModificacion.TabIndex = 7;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(120, 30);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(129, 21);
            this.txtUsuRegistro.TabIndex = 1;
            this.txtUsuRegistro.TabStop = false;
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtUsuModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(120, 76);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(129, 21);
            this.txtUsuModificacion.TabIndex = 5;
            this.txtUsuModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(120, 53);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(129, 21);
            this.txtFechaRegistro.TabIndex = 3;
            this.txtFechaRegistro.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDes);
            this.panel1.Controls.Add(this.cboCarac);
            this.panel1.Controls.Add(label1);
            this.panel1.Location = new System.Drawing.Point(9, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 177);
            this.panel1.TabIndex = 1;
            // 
            // txtDes
            // 
            this.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDes.Location = new System.Drawing.Point(12, 58);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(278, 108);
            this.txtDes.TabIndex = 12;
            // 
            // cboCarac
            // 
            this.cboCarac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarac.FormattingEnabled = true;
            this.cboCarac.Location = new System.Drawing.Point(95, 31);
            this.cboCarac.Name = "cboCarac";
            this.cboCarac.Size = new System.Drawing.Size(195, 21);
            this.cboCarac.TabIndex = 10;
            this.cboCarac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCarac_KeyPress);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(302, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Datos Principales";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 18);
            this.label6.TabIndex = 347;
            this.label6.Text = "Auditoria";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmArticuloDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(592, 213);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel8);
            this.Name = "frmArticuloDetalle";
            this.Text = "frmArticuloDetalle";
            this.Load += new System.EventHandler(this.frmArticuloDetalle_Load);
            this.Controls.SetChildIndex(this.lblTituloPrincipal, 0);
            this.Controls.SetChildIndex(this.btCerrar, 0);
            this.Controls.SetChildIndex(this.pnlBase, 0);
            this.Controls.SetChildIndex(this.btAceptar, 0);
            this.Controls.SetChildIndex(this.btCancelar, 0);
            this.Controls.SetChildIndex(this.panel8, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.ComboBox cboCarac;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}