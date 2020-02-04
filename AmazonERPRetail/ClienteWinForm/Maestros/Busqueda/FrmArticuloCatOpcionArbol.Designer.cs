namespace ClienteWinForm.Maestros.Busqueda
{
    partial class FrmArticuloCatOpcionArbol
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
            this.tvCategoria = new System.Windows.Forms.TreeView();
            this.txtFiltros = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).BeginInit();
            this.gbResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(225, 304);
            this.btnAceptar.Size = new System.Drawing.Size(100, 23);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(331, 304);
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(782, 81);
            // 
            // chkAnulado
            // 
            this.chkAnulado.Location = new System.Drawing.Point(901, 46);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(880, 96);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(843, 130);
            this.txtFiltro.Size = new System.Drawing.Size(337, 20);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.txtFiltros);
            this.gbResultados.Controls.Add(this.tvCategoria);
            this.gbResultados.Location = new System.Drawing.Point(4, 1);
            this.gbResultados.Size = new System.Drawing.Size(427, 298);
            this.gbResultados.Text = "";
            // 
            // tvCategoria
            // 
            this.tvCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvCategoria.Location = new System.Drawing.Point(4, 57);
            this.tvCategoria.Name = "tvCategoria";
            this.tvCategoria.Size = new System.Drawing.Size(417, 227);
            this.tvCategoria.TabIndex = 8;
            this.tvCategoria.DoubleClick += new System.EventHandler(this.tvCategoria_DoubleClick);
            // 
            // txtFiltros
            // 
            this.txtFiltros.Location = new System.Drawing.Point(8, 19);
            this.txtFiltros.Name = "txtFiltros";
            this.txtFiltros.Size = new System.Drawing.Size(411, 20);
            this.txtFiltros.TabIndex = 9;
            // 
            // FrmArticuloCatOpcionArbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 334);
            this.Name = "FrmArticuloCatOpcionArbol";
            this.Text = "Categorias de Articulos";
            this.Load += new System.EventHandler(this.FrmArticuloCatOpcionArbol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBase)).EndInit();
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvCategoria;
        private System.Windows.Forms.TextBox txtFiltros;
    }
}