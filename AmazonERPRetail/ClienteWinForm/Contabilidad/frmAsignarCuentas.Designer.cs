namespace ClienteWinForm.Contabilidad
{
    partial class frmAsignarCuentas
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btProveedor = new System.Windows.Forms.Button();
            this.txtDesCuentaSunat = new ControlesWinForm.SuperTextBox();
            this.txtIdCuentaSunat = new ControlesWinForm.SuperTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDegradado2 = new MyLabelG.LabelDegradado();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.btProveedor);
            this.pnlDatos.Controls.Add(this.txtDesCuentaSunat);
            this.pnlDatos.Controls.Add(this.txtIdCuentaSunat);
            this.pnlDatos.Controls.Add(this.label1);
            this.pnlDatos.Controls.Add(this.labelDegradado2);
            this.pnlDatos.Location = new System.Drawing.Point(11, 11);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(606, 92);
            this.pnlDatos.TabIndex = 2;
            // 
            // btProveedor
            // 
            this.btProveedor.BackgroundImage = global::ClienteWinForm.Properties.Resources.Buscar_16x16;
            this.btProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btProveedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProveedor.Location = new System.Drawing.Point(540, 38);
            this.btProveedor.Name = "btProveedor";
            this.btProveedor.Size = new System.Drawing.Size(25, 19);
            this.btProveedor.TabIndex = 340;
            this.btProveedor.TabStop = false;
            this.btProveedor.UseVisualStyleBackColor = true;
            this.btProveedor.Click += new System.EventHandler(this.btProveedor_Click);
            // 
            // txtDesCuentaSunat
            // 
            this.txtDesCuentaSunat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtDesCuentaSunat.BackColor = System.Drawing.Color.White;
            this.txtDesCuentaSunat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesCuentaSunat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtDesCuentaSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesCuentaSunat.Location = new System.Drawing.Point(182, 38);
            this.txtDesCuentaSunat.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesCuentaSunat.Name = "txtDesCuentaSunat";
            this.txtDesCuentaSunat.Size = new System.Drawing.Size(353, 20);
            this.txtDesCuentaSunat.TabIndex = 5;
            this.txtDesCuentaSunat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtDesCuentaSunat.TextoVacio = "<Descripcion>";
            this.txtDesCuentaSunat.TextChanged += new System.EventHandler(this.txtDesCuentaSunat_TextChanged);
            this.txtDesCuentaSunat.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesCuentaSunat_Validating);
            // 
            // txtIdCuentaSunat
            // 
            this.txtIdCuentaSunat.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtIdCuentaSunat.BackColor = System.Drawing.Color.AliceBlue;
            this.txtIdCuentaSunat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCuentaSunat.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtIdCuentaSunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCuentaSunat.Location = new System.Drawing.Point(125, 38);
            this.txtIdCuentaSunat.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCuentaSunat.Name = "txtIdCuentaSunat";
            this.txtIdCuentaSunat.Size = new System.Drawing.Size(56, 20);
            this.txtIdCuentaSunat.TabIndex = 4;
            this.txtIdCuentaSunat.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.Defecto;
            this.txtIdCuentaSunat.TextoVacio = "<Descripcion>";
            this.txtIdCuentaSunat.TextChanged += new System.EventHandler(this.txtIdCuentaSunat_TextChanged);
            this.txtIdCuentaSunat.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCuentaSunat_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 307;
            this.label1.Text = "Cuenta Sunat";
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
            this.labelDegradado2.Size = new System.Drawing.Size(604, 20);
            this.labelDegradado2.TabIndex = 500;
            this.labelDegradado2.Text = "Principales";
            this.labelDegradado2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAsignarCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 111);
            this.Controls.Add(this.pnlDatos);
            this.Name = "frmAsignarCuentas";
            this.Text = "Asignar Cuentas";
            this.Load += new System.EventHandler(this.frmAsignarCuentas_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Button btProveedor;
        private ControlesWinForm.SuperTextBox txtDesCuentaSunat;
        private ControlesWinForm.SuperTextBox txtIdCuentaSunat;
        private System.Windows.Forms.Label label1;
        private MyLabelG.LabelDegradado labelDegradado2;
    }
}