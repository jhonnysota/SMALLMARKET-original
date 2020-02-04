namespace ClienteWinForm.Ventas
{
    partial class frmMensajeFecAprobacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.btSi = new System.Windows.Forms.Button();
            this.btNo = new System.Windows.Forms.Button();
            this.lblGlosa = new System.Windows.Forms.Label();
            this.dtpFecAprobacion = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 16);
            this.label1.TabIndex = 275;
            this.label1.Text = "Desea tomar la fecha actual como Fecha de Aprobación";
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFechaActual.Location = new System.Drawing.Point(2, 40);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(413, 16);
            this.lblFechaActual.TabIndex = 276;
            this.lblFechaActual.Text = "29/01/2019";
            this.lblFechaActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSi
            // 
            this.btSi.BackColor = System.Drawing.Color.Azure;
            this.btSi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btSi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSi.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btSi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSi.Location = new System.Drawing.Point(93, 67);
            this.btSi.Name = "btSi";
            this.btSi.Size = new System.Drawing.Size(54, 30);
            this.btSi.TabIndex = 320;
            this.btSi.TabStop = false;
            this.btSi.Text = "SI";
            this.btSi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSi.UseVisualStyleBackColor = false;
            this.btSi.Click += new System.EventHandler(this.btSi_Click);
            // 
            // btNo
            // 
            this.btNo.BackColor = System.Drawing.Color.Azure;
            this.btNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNo.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNo.Location = new System.Drawing.Point(273, 67);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(54, 30);
            this.btNo.TabIndex = 321;
            this.btNo.TabStop = false;
            this.btNo.Text = "NO";
            this.btNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNo.UseVisualStyleBackColor = false;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlosa.Location = new System.Drawing.Point(15, 103);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(373, 13);
            this.lblGlosa.TabIndex = 323;
            this.lblGlosa.Text = "Escoja la fecha de aprobación                                      y vuelva a pre" +
    "sionar SI";
            this.lblGlosa.Visible = false;
            // 
            // dtpFecAprobacion
            // 
            this.dtpFecAprobacion.CustomFormat = "dd/MM/yyyy";
            this.dtpFecAprobacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecAprobacion.Location = new System.Drawing.Point(170, 100);
            this.dtpFecAprobacion.Name = "dtpFecAprobacion";
            this.dtpFecAprobacion.Size = new System.Drawing.Size(99, 20);
            this.dtpFecAprobacion.TabIndex = 324;
            this.dtpFecAprobacion.Visible = false;
            // 
            // frmMensajeFecAprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(417, 126);
            this.Controls.Add(this.dtpFecAprobacion);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btSi);
            this.Controls.Add(this.lblFechaActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGlosa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMensajeFecAprobacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fecha de Aprobacón";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMensajeFecAprobacion_FormClosing);
            this.Load += new System.EventHandler(this.frmMensajeFecAprobacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.Button btSi;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.Label lblGlosa;
        private System.Windows.Forms.DateTimePicker dtpFecAprobacion;
    }
}