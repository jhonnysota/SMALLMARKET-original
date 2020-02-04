namespace ClienteWinForm.Generales
{
    partial class frmDocumentosImpuestos
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtDesDocumento = new System.Windows.Forms.TextBox();
            this.txtDesImpuesto = new System.Windows.Forms.TextBox();
            this.btBuscarImpuesto = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitPnlBase
            // 
            this.lblTitPnlBase.Size = new System.Drawing.Size(342, 22);
            this.lblTitPnlBase.Text = "Impuestos";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Size = new System.Drawing.Size(364, 25);
            this.lblTituloPrincipal.Text = "Impuestos de Documentos";
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCerrar.Location = new System.Drawing.Point(393, 2);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btBuscarImpuesto);
            this.pnlBase.Controls.Add(this.txtDesDocumento);
            this.pnlBase.Controls.Add(this.txtDesImpuesto);
            this.pnlBase.Controls.Add(this.txtDocumento);
            this.pnlBase.Controls.Add(this.txtImpuesto);
            this.pnlBase.Controls.Add(label7);
            this.pnlBase.Controls.Add(label6);
            this.pnlBase.Location = new System.Drawing.Point(7, 29);
            this.pnlBase.Size = new System.Drawing.Size(344, 87);
            this.pnlBase.Controls.SetChildIndex(this.lblTitPnlBase, 0);
            this.pnlBase.Controls.SetChildIndex(label6, 0);
            this.pnlBase.Controls.SetChildIndex(label7, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtImpuesto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesImpuesto, 0);
            this.pnlBase.Controls.SetChildIndex(this.txtDesDocumento, 0);
            this.pnlBase.Controls.SetChildIndex(this.btBuscarImpuesto, 0);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btCancelar.Location = new System.Drawing.Point(193, 126);
            this.btCancelar.Size = new System.Drawing.Size(113, 25);
            // 
            // btAceptar
            // 
            this.btAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btAceptar.Location = new System.Drawing.Point(58, 126);
            this.btAceptar.Size = new System.Drawing.Size(113, 25);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(11, 35);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(61, 13);
            label7.TabIndex = 253;
            label7.Text = "Documento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(11, 57);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 13);
            label6.TabIndex = 254;
            label6.Text = "Impuesto";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(80, 54);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(36, 20);
            this.txtImpuesto.TabIndex = 258;
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Location = new System.Drawing.Point(80, 32);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(36, 20);
            this.txtDocumento.TabIndex = 259;
            // 
            // txtDesDocumento
            // 
            this.txtDesDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesDocumento.Enabled = false;
            this.txtDesDocumento.Location = new System.Drawing.Point(118, 32);
            this.txtDesDocumento.Name = "txtDesDocumento";
            this.txtDesDocumento.Size = new System.Drawing.Size(208, 20);
            this.txtDesDocumento.TabIndex = 261;
            // 
            // txtDesImpuesto
            // 
            this.txtDesImpuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtDesImpuesto.Enabled = false;
            this.txtDesImpuesto.Location = new System.Drawing.Point(118, 54);
            this.txtDesImpuesto.Name = "txtDesImpuesto";
            this.txtDesImpuesto.Size = new System.Drawing.Size(183, 20);
            this.txtDesImpuesto.TabIndex = 260;
            // 
            // btBuscarImpuesto
            // 
            this.btBuscarImpuesto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarImpuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscarImpuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscarImpuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarImpuesto.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btBuscarImpuesto.Location = new System.Drawing.Point(304, 54);
            this.btBuscarImpuesto.Name = "btBuscarImpuesto";
            this.btBuscarImpuesto.Size = new System.Drawing.Size(22, 20);
            this.btBuscarImpuesto.TabIndex = 262;
            this.btBuscarImpuesto.UseVisualStyleBackColor = true;
            this.btBuscarImpuesto.Click += new System.EventHandler(this.btBuscarImpuesto_Click);
            // 
            // frmDocumentosImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 160);
            this.Name = "frmDocumentosImpuestos";
            this.Text = "DocumentosImpuestos";
            this.Load += new System.EventHandler(this.DocumentosImpuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtDesDocumento;
        private System.Windows.Forms.TextBox txtDesImpuesto;
        private System.Windows.Forms.Button btBuscarImpuesto;
    }
}