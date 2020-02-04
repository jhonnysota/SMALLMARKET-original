namespace ClienteWinForm.Contabilidad.Reportes
{
    partial class frmReporteEEFFGananciasyPerdidasArchivo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.lbltitulo = new MyLabelG.LabelDegradado();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoja = new ControlesWinForm.SuperTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtHoja);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.lblRuta);
            this.panel1.Controls.Add(this.btnAbrir);
            this.panel1.Controls.Add(this.lbltitulo);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 74);
            this.panel1.TabIndex = 270;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(652, 33);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(72, 21);
            this.btnExportar.TabIndex = 345;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(95, 37);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(48, 13);
            this.lblRuta.TabIndex = 346;
            this.lblRuta.Text = "Ruta : ...";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(574, 33);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(72, 21);
            this.btnAbrir.TabIndex = 344;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // lbltitulo
            // 
            this.lbltitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitulo.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lbltitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.White;
            this.lbltitulo.Location = new System.Drawing.Point(0, 0);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.PrimerColor = System.Drawing.Color.SlateGray;
            this.lbltitulo.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lbltitulo.Size = new System.Drawing.Size(734, 21);
            this.lbltitulo.TabIndex = 253;
            this.lbltitulo.Text = "Item : ";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 347;
            this.label1.Text = "Nº Hoja :";
            // 
            // txtHoja
            // 
            this.txtHoja.Autoexplicativo = ControlesWinForm.SuperTextBox.EstadoTexto.PorDefecto;
            this.txtHoja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoja.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtHoja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoja.Location = new System.Drawing.Point(65, 33);
            this.txtHoja.MaxLength = 2;
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(24, 21);
            this.txtHoja.TabIndex = 348;
            this.txtHoja.Text = "5";
            this.txtHoja.TextBoxEstados = ControlesWinForm.SuperTextBox.EstadoValidacion.SoloNumeros;
            this.txtHoja.TextoVacio = "<Descripcion>";
            // 
            // frmReporteEEFFGananciasyPerdidasArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 78);
            this.Controls.Add(this.panel1);
            this.Name = "frmReporteEEFFGananciasyPerdidasArchivo";
            this.Text = "Exportar Datos";
            this.Load += new System.EventHandler(this.frmReporteEEFFGananciasyPerdidasArchivo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnAbrir;
        private MyLabelG.LabelDegradado lbltitulo;
        private System.Windows.Forms.Label label1;
        private ControlesWinForm.SuperTextBox txtHoja;
    }
}