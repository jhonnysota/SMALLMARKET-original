﻿namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteConciliacionPrevia
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
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(872, 454);
            this.wbNavegador.TabIndex = 331;
            // 
            // frmReporteConciliacionPrevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 454);
            this.Controls.Add(this.wbNavegador);
            this.MaximizeBox = false;
            this.Name = "frmReporteConciliacionPrevia";
            this.Text = "frmReporteConciliacionPrevia";
            this.Load += new System.EventHandler(this.frmReporteConciliacionPrevia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbNavegador;
    }
}