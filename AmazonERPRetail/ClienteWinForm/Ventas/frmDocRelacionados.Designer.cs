namespace ClienteWinForm.Ventas
{
    partial class frmDocRelacionados
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
            this.pnlConductor = new System.Windows.Forms.Panel();
            this.lbDocumentos = new System.Windows.Forms.ListBox();
            this.pnlConductor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConductor
            // 
            this.pnlConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConductor.Controls.Add(this.lbDocumentos);
            this.pnlConductor.Location = new System.Drawing.Point(5, 5);
            this.pnlConductor.Name = "pnlConductor";
            this.pnlConductor.Size = new System.Drawing.Size(157, 184);
            this.pnlConductor.TabIndex = 337;
            // 
            // lbDocumentos
            // 
            this.lbDocumentos.BackColor = System.Drawing.Color.Azure;
            this.lbDocumentos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDocumentos.FormattingEnabled = true;
            this.lbDocumentos.Location = new System.Drawing.Point(4, 5);
            this.lbDocumentos.Name = "lbDocumentos";
            this.lbDocumentos.Size = new System.Drawing.Size(146, 173);
            this.lbDocumentos.TabIndex = 249;
            // 
            // frmDocRelacionados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(167, 193);
            this.Controls.Add(this.pnlConductor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocRelacionados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos";
            this.Load += new System.EventHandler(this.frmDocRelacionados_Load);
            this.pnlConductor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConductor;
        private System.Windows.Forms.ListBox lbDocumentos;
    }
}