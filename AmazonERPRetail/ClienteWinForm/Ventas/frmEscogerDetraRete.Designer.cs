namespace ClienteWinForm.Ventas
{
    partial class frmEscogerDetraRete
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
            this.chkDetraccion = new System.Windows.Forms.CheckBox();
            this.chkRetencion = new System.Windows.Forms.CheckBox();
            this.lblDetraccion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblRetencion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkDetraccion
            // 
            this.chkDetraccion.AutoSize = true;
            this.chkDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDetraccion.Location = new System.Drawing.Point(26, 24);
            this.chkDetraccion.Name = "chkDetraccion";
            this.chkDetraccion.Size = new System.Drawing.Size(124, 17);
            this.chkDetraccion.TabIndex = 0;
            this.chkDetraccion.Text = "Tiene Detracción";
            this.chkDetraccion.UseVisualStyleBackColor = true;
            this.chkDetraccion.CheckedChanged += new System.EventHandler(this.chkDetraccion_CheckedChanged);
            // 
            // chkRetencion
            // 
            this.chkRetencion.AutoSize = true;
            this.chkRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencion.Location = new System.Drawing.Point(177, 24);
            this.chkRetencion.Name = "chkRetencion";
            this.chkRetencion.Size = new System.Drawing.Size(147, 17);
            this.chkRetencion.TabIndex = 1;
            this.chkRetencion.Text = "Es Agente Retenedor";
            this.chkRetencion.UseVisualStyleBackColor = true;
            this.chkRetencion.CheckedChanged += new System.EventHandler(this.chkRetencion_CheckedChanged);
            // 
            // lblDetraccion
            // 
            this.lblDetraccion.AutoSize = true;
            this.lblDetraccion.ForeColor = System.Drawing.Color.Blue;
            this.lblDetraccion.Location = new System.Drawing.Point(50, 57);
            this.lblDetraccion.Name = "lblDetraccion";
            this.lblDetraccion.Size = new System.Drawing.Size(35, 13);
            this.lblDetraccion.TabIndex = 2;
            this.lblDetraccion.Text = "label1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::ClienteWinForm.Properties.Resources.ok;
            this.btnAceptar.Location = new System.Drawing.Point(134, 112);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblRetencion
            // 
            this.lblRetencion.AutoSize = true;
            this.lblRetencion.ForeColor = System.Drawing.Color.Blue;
            this.lblRetencion.Location = new System.Drawing.Point(207, 57);
            this.lblRetencion.Name = "lblRetencion";
            this.lblRetencion.Size = new System.Drawing.Size(35, 13);
            this.lblRetencion.TabIndex = 4;
            this.lblRetencion.Text = "label1";
            // 
            // frmEscogerDetraRete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 149);
            this.Controls.Add(this.lblRetencion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblDetraccion);
            this.Controls.Add(this.chkRetencion);
            this.Controls.Add(this.chkDetraccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEscogerDetraRete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escoger Detracción o Retención";
            this.Load += new System.EventHandler(this.frmEscogerDetraRete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDetraccion;
        private System.Windows.Forms.CheckBox chkRetencion;
        private System.Windows.Forms.Label lblDetraccion;
        protected internal System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblRetencion;
    }
}