namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmImpresionVoucher
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
            this.wbPdf = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbPdf
            // 
            this.wbPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPdf.Location = new System.Drawing.Point(0, 0);
            this.wbPdf.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPdf.Name = "wbPdf";
            this.wbPdf.Size = new System.Drawing.Size(814, 400);
            this.wbPdf.TabIndex = 0;
            // 
            // frmImpresionVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Controls.Add(this.wbPdf);
            this.Name = "frmImpresionVoucher";
            this.Text = "Impresion del Voucher";
            this.Load += new System.EventHandler(this.frmImpresionVoucher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPdf;
    }
}