namespace ClienteWinForm.Maestros.Busqueda
{
    partial class frmCostosCatOpcionArbol
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
            this.TVCategoria = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(348, 339);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(454, 339);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1378, 160);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(1185, 156);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(886, 159);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(886, 182);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.TVCategoria);
            this.gbResultados.Location = new System.Drawing.Point(12, 12);
            this.gbResultados.Size = new System.Drawing.Size(544, 321);
            this.gbResultados.Text = "Estructura";
            // 
            // TVCategoria
            // 
            this.TVCategoria.Location = new System.Drawing.Point(15, 19);
            this.TVCategoria.Name = "TVCategoria";
            this.TVCategoria.Size = new System.Drawing.Size(521, 296);
            this.TVCategoria.TabIndex = 0;
            this.TVCategoria.DoubleClick += new System.EventHandler(this.TVCategoria_DoubleClick);
            // 
            // frmCostosCatOpcionArbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 380);
            this.Name = "frmCostosCatOpcionArbol";
            this.Text = "Costos Categoria";
            this.Load += new System.EventHandler(this.frmCostosCatOpcionArbol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TVCategoria;
    }
}