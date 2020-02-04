namespace ClienteWinForm.Busquedas
{
    partial class frmTipoCambioDiario
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
            this.btAceptar = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblFechaLarga = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompra = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVenta = new ControlesWinForm.SuperTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.Azure;
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btAceptar.Location = new System.Drawing.Point(56, 182);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(187, 29);
            this.btAceptar.TabIndex = 362;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblFechaLarga);
            this.panel7.Controls.Add(this.dtpFecha);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.txtCompra);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.txtVenta);
            this.panel7.Location = new System.Drawing.Point(5, 107);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(293, 71);
            this.panel7.TabIndex = 361;
            // 
            // lblFechaLarga
            // 
            this.lblFechaLarga.AutoSize = true;
            this.lblFechaLarga.Location = new System.Drawing.Point(127, 11);
            this.lblFechaLarga.Name = "lblFechaLarga";
            this.lblFechaLarga.Size = new System.Drawing.Size(0, 13);
            this.lblFechaLarga.TabIndex = 361;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(25, 7);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha.TabIndex = 360;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 359;
            this.label2.Text = "Al";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 355;
            this.label4.Text = "Compra";
            // 
            // txtCompra
            // 
            this.txtCompra.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtCompra.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtCompra.Enabled = false;
            this.txtCompra.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompra.Location = new System.Drawing.Point(70, 38);
            this.txtCompra.MaxLength = 6;
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(64, 22);
            this.txtCompra.TabIndex = 356;
            this.txtCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCompra.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtCompra.TextoVacio = "<Descripcion>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 357;
            this.label1.Text = "Venta";
            // 
            // txtVenta
            // 
            this.txtVenta.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtVenta.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtVenta.Enabled = false;
            this.txtVenta.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Location = new System.Drawing.Point(204, 38);
            this.txtVenta.MaxLength = 6;
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(64, 22);
            this.txtVenta.TabIndex = 358;
            this.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVenta.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Decimales;
            this.txtVenta.TextoVacio = "<Descripcion>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClienteWinForm.Properties.Resources.TicaSunatLogo;
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // frmTipoCambioDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 216);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.pictureBox1);
            this.MinimizeBox = false;
            this.Name = "frmTipoCambioDiario";
            this.Text = "Tipo de Cambio";
            this.Load += new System.EventHandler(this.frmTipoCambioDiario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmTipoCambioDiario_KeyUp);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ControlesWinForm.SuperTextBox txtVenta;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel panel7;
        protected internal System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label lblFechaLarga;
    }
}