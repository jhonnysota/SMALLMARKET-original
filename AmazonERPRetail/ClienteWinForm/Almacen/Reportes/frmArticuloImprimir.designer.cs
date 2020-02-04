namespace ClienteWinForm.Almacen.Reportes
{
    partial class frmArticuloImprimir
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbProveedor = new System.Windows.Forms.RadioButton();
            this.rdbAgrup_Cuenta = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.wbNavegador);
            this.panel3.Controls.Add(this.lblProcesando);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(895, 493);
            this.panel3.TabIndex = 290;
            // 
            // wbNavegador
            // 
            this.wbNavegador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbNavegador.Location = new System.Drawing.Point(0, -3);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(893, 497);
            this.wbNavegador.TabIndex = 326;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.White;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(733, 375);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 19);
            this.lblProcesando.TabIndex = 325;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcesando.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdbProveedor);
            this.panel2.Controls.Add(this.rdbAgrup_Cuenta);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.labelDegradado2);
            this.panel2.Location = new System.Drawing.Point(1074, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(84, 98);
            this.panel2.TabIndex = 264;
            // 
            // rdbProveedor
            // 
            this.rdbProveedor.AutoSize = true;
            this.rdbProveedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProveedor.Location = new System.Drawing.Point(8, 64);
            this.rdbProveedor.Name = "rdbProveedor";
            this.rdbProveedor.Size = new System.Drawing.Size(75, 17);
            this.rdbProveedor.TabIndex = 260;
            this.rdbProveedor.Text = "Proveedor";
            this.rdbProveedor.UseVisualStyleBackColor = true;
            // 
            // rdbAgrup_Cuenta
            // 
            this.rdbAgrup_Cuenta.AutoSize = true;
            this.rdbAgrup_Cuenta.Checked = true;
            this.rdbAgrup_Cuenta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAgrup_Cuenta.Location = new System.Drawing.Point(8, 37);
            this.rdbAgrup_Cuenta.Name = "rdbAgrup_Cuenta";
            this.rdbAgrup_Cuenta.Size = new System.Drawing.Size(60, 17);
            this.rdbAgrup_Cuenta.TabIndex = 259;
            this.rdbAgrup_Cuenta.TabStop = true;
            this.rdbAgrup_Cuenta.Text = "Cuenta";
            this.rdbAgrup_Cuenta.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button4.Location = new System.Drawing.Point(1217, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 59);
            this.button4.TabIndex = 154;
            this.button4.Text = "BUSCAR";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // labelDegradado2
            // 
            this.labelDegradado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDegradado2.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.labelDegradado2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegradado2.ForeColor = System.Drawing.Color.White;
            this.labelDegradado2.Location = new System.Drawing.Point(0, 0);
            this.labelDegradado2.Name = "labelDegradado2";
            this.labelDegradado2.PrimerColor = System.Drawing.Color.SlateGray;
            this.labelDegradado2.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.labelDegradado2.Size = new System.Drawing.Size(82, 20);
            this.labelDegradado2.TabIndex = 258;
            this.labelDegradado2.Text = "Agrupado por";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmArticuloImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 499);
            this.Controls.Add(this.panel3);
            this.Name = "frmArticuloImprimir";
            this.Text = "Impresión de Articulos";
            this.Load += new System.EventHandler(this.frmCronogramaImprimir_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbProveedor;
        private System.Windows.Forms.RadioButton rdbAgrup_Cuenta;
        protected internal System.Windows.Forms.Button button4;
        private MyLabelG.LabelDegradado labelDegradado2;
    }
}