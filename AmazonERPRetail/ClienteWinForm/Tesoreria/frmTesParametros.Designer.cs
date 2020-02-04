namespace ClienteWinForm.Tesoreria
{
    partial class frmTesParametros
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtPorcentajeRmv = new ControlesWinForm.SuperTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRmv = new ControlesWinForm.SuperTextBox();
            this.lblCodCat = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelDegradado9 = new MyLabelG.LabelDegradado();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtUsuRegistro = new System.Windows.Forms.TextBox();
            this.txtUsuModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.txtPorcentajeRmv);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Controls.Add(this.txtRmv);
            this.pnlDatos.Controls.Add(this.lblCodCat);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Location = new System.Drawing.Point(3, 3);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(474, 75);
            this.pnlDatos.TabIndex = 130;
            // 
            // txtPorcentajeRmv
            // 
            this.txtPorcentajeRmv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtPorcentajeRmv.BackColor = System.Drawing.Color.White;
            this.txtPorcentajeRmv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtPorcentajeRmv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeRmv.Location = new System.Drawing.Point(240, 36);
            this.txtPorcentajeRmv.Margin = new System.Windows.Forms.Padding(2);
            this.txtPorcentajeRmv.Name = "txtPorcentajeRmv";
            this.txtPorcentajeRmv.Size = new System.Drawing.Size(66, 20);
            this.txtPorcentajeRmv.TabIndex = 6;
            this.txtPorcentajeRmv.Text = "0.00";
            this.txtPorcentajeRmv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcentajeRmv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtPorcentajeRmv.TextoVacio = "<Descripcion>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 294;
            this.label2.Text = "Porcentaje";
            // 
            // txtRmv
            // 
            this.txtRmv.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtRmv.BackColor = System.Drawing.Color.White;
            this.txtRmv.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtRmv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRmv.Location = new System.Drawing.Point(83, 36);
            this.txtRmv.Margin = new System.Windows.Forms.Padding(2);
            this.txtRmv.Name = "txtRmv";
            this.txtRmv.Size = new System.Drawing.Size(56, 20);
            this.txtRmv.TabIndex = 5;
            this.txtRmv.Text = "0.00";
            this.txtRmv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRmv.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtRmv.TextoVacio = "<Descripcion>";
            // 
            // lblCodCat
            // 
            this.lblCodCat.AutoSize = true;
            this.lblCodCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCat.Location = new System.Drawing.Point(24, 40);
            this.lblCodCat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodCat.Name = "lblCodCat";
            this.lblCodCat.Size = new System.Drawing.Size(40, 13);
            this.lblCodCat.TabIndex = 115;
            this.lblCodCat.Text = "R.M.V.";
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
            this.labelDegradado2.Size = new System.Drawing.Size(472, 19);
            this.labelDegradado2.TabIndex = 270;
            this.labelDegradado2.Text = "Datos";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labelDegradado9);
            this.panel8.Controls.Add(label24);
            this.panel8.Controls.Add(this.txtFechaModificacion);
            this.panel8.Controls.Add(this.txtUsuRegistro);
            this.panel8.Controls.Add(label25);
            this.panel8.Controls.Add(label29);
            this.panel8.Controls.Add(this.txtUsuModificacion);
            this.panel8.Controls.Add(this.txtFechaRegistro);
            this.panel8.Controls.Add(label31);
            this.panel8.Location = new System.Drawing.Point(3, 81);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(474, 74);
            this.panel8.TabIndex = 342;
            // 
            // labelDegradado9
            // 
            this.labelDegradado9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado9.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado9.ForeColor = System.Drawing.Color.White;
            this.labelDegradado9.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado9.Name = "labelDegradado9";
            this.labelDegradado9.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado9.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado9.Size = new System.Drawing.Size(472, 16);
            this.labelDegradado9.TabIndex = 253;
            this.labelDegradado9.Text = "Auditoria";
            this.labelDegradado9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label24.Location = new System.Drawing.Point(228, 48);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(97, 13);
            label24.TabIndex = 6;
            label24.Text = "Fecha Modificacion";
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaModificacion.Enabled = false;
            this.txtFechaModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaModificacion.Location = new System.Drawing.Point(335, 45);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.Size = new System.Drawing.Size(130, 21);
            this.txtFechaModificacion.TabIndex = 3;
            this.txtFechaModificacion.TabStop = false;
            // 
            // txtUsuRegistro
            // 
            this.txtUsuRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuRegistro.Enabled = false;
            this.txtUsuRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuRegistro.Location = new System.Drawing.Point(94, 21);
            this.txtUsuRegistro.Name = "txtUsuRegistro";
            this.txtUsuRegistro.Size = new System.Drawing.Size(129, 21);
            this.txtUsuRegistro.TabIndex = 0;
            this.txtUsuRegistro.TabStop = false;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.Location = new System.Drawing.Point(228, 25);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(104, 13);
            label25.TabIndex = 4;
            label25.Text = "Usuario Modificacion";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.Location = new System.Drawing.Point(7, 25);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(86, 13);
            label29.TabIndex = 0;
            label29.Text = "Usuario Registro";
            // 
            // txtUsuModificacion
            // 
            this.txtUsuModificacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuModificacion.Enabled = false;
            this.txtUsuModificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuModificacion.Location = new System.Drawing.Point(335, 21);
            this.txtUsuModificacion.Name = "txtUsuModificacion";
            this.txtUsuModificacion.Size = new System.Drawing.Size(129, 21);
            this.txtUsuModificacion.TabIndex = 2;
            this.txtUsuModificacion.TabStop = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaRegistro.Location = new System.Drawing.Point(94, 45);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(129, 21);
            this.txtFechaRegistro.TabIndex = 1;
            this.txtFechaRegistro.TabStop = false;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label31.Location = new System.Drawing.Point(7, 48);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(79, 13);
            label31.TabIndex = 2;
            label31.Text = "Fecha Registro";
            // 
            // frmTesParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 159);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.pnlDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTesParametros";
            this.Text = "Parámetros de Tesoreria";
            this.Load += new System.EventHandler(this.frmTesParametros_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private ControlesWinForm.SuperTextBox txtPorcentajeRmv;
        private System.Windows.Forms.Label label2;
        private ControlesWinForm.SuperTextBox txtRmv;
        private System.Windows.Forms.Label lblCodCat;
        private MyLabelG.LabelDegradado labelDegradado2;
        private System.Windows.Forms.Panel panel8;
        private MyLabelG.LabelDegradado labelDegradado9;
        private System.Windows.Forms.TextBox txtFechaModificacion;
        private System.Windows.Forms.TextBox txtUsuRegistro;
        private System.Windows.Forms.TextBox txtUsuModificacion;
        private System.Windows.Forms.TextBox txtFechaRegistro;
    }
}