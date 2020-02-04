namespace ClienteWinForm.Ventas
{
    partial class frmDetalleCrearDocumentos
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
            this.cboDocVentas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSerieVenta = new System.Windows.Forms.ComboBox();
            this.labelDegradado4 = new MyLabelG.LabelDegradado();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.labelDegradado5 = new MyLabelG.LabelDegradado();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGuias = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSerieGuias = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.PrimerColor = System.Drawing.Color.White;
            this.lblTitPnlBase.Size = new System.Drawing.Size(426, 3);
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(436, 25);
            this.lblTituloPrincipal.Text = "Crear Documentos para el Nro. Ped.";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btCerrar.Location = new System.Drawing.Point(409, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.cboSerieGuias);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.cboGuias);
            this.pnlBase.Controls.Add(this.labelDegradado5);
            this.pnlBase.Controls.Add(this.labelDegradado2);
            this.pnlBase.Controls.Add(this.labelDegradado4);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.cboSerieVenta);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.cboDocVentas);
            this.pnlBase.Location = new System.Drawing.Point(5, 29);
            this.pnlBase.Size = new System.Drawing.Size(426, 69);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboDocVentas, 0);
            this.pnlBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboSerieVenta, 0);
            this.pnlBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlBase.Controls.SetChildIndex(this.labelDegradado4, 0);
            this.pnlBase.Controls.SetChildIndex(this.labelDegradado2, 0);
            this.pnlBase.Controls.SetChildIndex(this.labelDegradado5, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboGuias, 0);
            this.pnlBase.Controls.SetChildIndex(this.label3, 0);
            this.pnlBase.Controls.SetChildIndex(this.cboSerieGuias, 0);
            this.pnlBase.Controls.SetChildIndex(this.label4, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(225, 106);
            this.btCancelar.Size = new System.Drawing.Size(116, 24);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(101, 106);
            this.btAceptar.Size = new System.Drawing.Size(116, 24);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 266;
            this.label1.Text = "Factura - Boleta";
            // 
            // cboDocVentas
            // 
            this.cboDocVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocVentas.FormattingEnabled = true;
            this.cboDocVentas.Location = new System.Drawing.Point(109, 12);
            this.cboDocVentas.Name = "cboDocVentas";
            this.cboDocVentas.Size = new System.Drawing.Size(150, 21);
            this.cboDocVentas.TabIndex = 265;
            this.cboDocVentas.SelectionChangeCommitted += new System.EventHandler(this.cboDocVentas_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 268;
            this.label2.Text = "Serie";
            // 
            // cboSerieVenta
            // 
            this.cboSerieVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSerieVenta.FormattingEnabled = true;
            this.cboSerieVenta.Location = new System.Drawing.Point(306, 12);
            this.cboSerieVenta.Name = "cboSerieVenta";
            this.cboSerieVenta.Size = new System.Drawing.Size(90, 21);
            this.cboSerieVenta.TabIndex = 267;
            // 
            // labelDegradado4
            // 
            this.labelDegradado4.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelDegradado4.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado4.ForeColor = System.Drawing.Color.White;
            this.labelDegradado4.Location = new System.Drawing.Point(423, 3);
            this.labelDegradado4.Name = "labelDegradado4";
            this.labelDegradado4.PrimerColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado4.SegundoColor = System.Drawing.Color.White;
            this.labelDegradado4.Size = new System.Drawing.Size(3, 66);
            this.labelDegradado4.TabIndex = 327;
            this.labelDegradado4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 66);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.White;
            this.labelDegradado2.Size = new System.Drawing.Size(423, 3);
            this.labelDegradado2.TabIndex = 328;
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDegradado5
            // 
            this.labelDegradado5.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelDegradado5.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelDegradado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado5.ForeColor = System.Drawing.Color.White;
            this.labelDegradado5.Location = new System.Drawing.Point(0, 3);
            this.labelDegradado5.Name = "labelDegradado5";
            this.labelDegradado5.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado5.Size = new System.Drawing.Size(3, 63);
            this.labelDegradado5.TabIndex = 329;
            this.labelDegradado5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 331;
            this.label3.Text = "Guia";
            // 
            // cboGuias
            // 
            this.cboGuias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGuias.FormattingEnabled = true;
            this.cboGuias.Location = new System.Drawing.Point(109, 37);
            this.cboGuias.Name = "cboGuias";
            this.cboGuias.Size = new System.Drawing.Size(150, 21);
            this.cboGuias.TabIndex = 330;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 333;
            this.label4.Text = "Serie";
            // 
            // cboSerieGuias
            // 
            this.cboSerieGuias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSerieGuias.FormattingEnabled = true;
            this.cboSerieGuias.Location = new System.Drawing.Point(306, 37);
            this.cboSerieGuias.Name = "cboSerieGuias";
            this.cboSerieGuias.Size = new System.Drawing.Size(90, 21);
            this.cboSerieGuias.TabIndex = 332;
            // 
            // frmDetalleCrearDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 137);
            this.Name = "frmDetalleCrearDocumentos";
            this.Text = "frmDetalleCrearDocumentos";
            this.Load += new System.EventHandler(this.frmDetalleCrearDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSerieVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDocVentas;
        private MyLabelG.LabelDegradado labelDegradado4;
        private MyLabelG.LabelDegradado labelDegradado2;
        private MyLabelG.LabelDegradado labelDegradado5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSerieGuias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGuias;
    }
}