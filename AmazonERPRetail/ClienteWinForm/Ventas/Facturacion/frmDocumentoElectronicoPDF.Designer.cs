﻿namespace ClienteWinForm.Contabilidad.CtasPorPagar
{
    partial class frmDocumentoElectronicoPDF
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
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbNavegador
            // 
            this.wbNavegador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbNavegador.Location = new System.Drawing.Point(0, -1);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(976, 474);
            this.wbNavegador.TabIndex = 327;
            // 
            // frmDocumentoElectronicoPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 476);
            this.Controls.Add(this.wbNavegador);
            this.MaximizeBox = false;
            this.Name = "frmDocumentoElectronicoPDF";
            this.Text = "Vista Previa del Documento PDF";
            this.Load += new System.EventHandler(this.frmRetencionImprimir_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbNavegador;
    }
}