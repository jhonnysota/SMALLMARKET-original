namespace ClienteWinForm.Ventas
{
    partial class frmPuntoVentasPrintPrevio
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
            this.TxtPrevio = new System.Windows.Forms.TextBox();
            this.BtImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPrevio
            // 
            this.TxtPrevio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPrevio.Dock = System.Windows.Forms.DockStyle.Left;
            this.TxtPrevio.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrevio.Location = new System.Drawing.Point(0, 0);
            this.TxtPrevio.Multiline = true;
            this.TxtPrevio.Name = "TxtPrevio";
            this.TxtPrevio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtPrevio.Size = new System.Drawing.Size(424, 518);
            this.TxtPrevio.TabIndex = 500;
            this.TxtPrevio.TabStop = false;
            // 
            // BtImprimir
            // 
            this.BtImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.BtImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtImprimir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtImprimir.Image = global::ClienteWinForm.Properties.Resources.ImpresoraAzul;
            this.BtImprimir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtImprimir.Location = new System.Drawing.Point(436, 11);
            this.BtImprimir.Name = "BtImprimir";
            this.BtImprimir.Size = new System.Drawing.Size(76, 51);
            this.BtImprimir.TabIndex = 0;
            this.BtImprimir.Text = "Imprimir";
            this.BtImprimir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtImprimir.UseVisualStyleBackColor = true;
            this.BtImprimir.Click += new System.EventHandler(this.BtImprimir_Click);
            // 
            // frmPuntoVentasPrintPrevio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(522, 518);
            this.Controls.Add(this.BtImprimir);
            this.Controls.Add(this.TxtPrevio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPuntoVentasPrintPrevio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Previa del Documento";
            this.Load += new System.EventHandler(this.FrmPuntoVentasPrintPrevio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPrevio;
        private System.Windows.Forms.Button BtImprimir;
    }
}