namespace ClienteWinForm.Almacen.Reportes
{
    partial class frmReporteStockMensualvsListaPrecio
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCero = new System.Windows.Forms.CheckBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboalmacen = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cmsImprimir = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stockMensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockMensualPorArticuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockMensualPorArticuloConCostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.wbNavegador = new System.Windows.Forms.WebBrowser();
            this.lblregistros = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.cmsImprimir.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblregistros);
            this.panel1.Controls.Add(this.chkCero);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.chkFecha);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboalmacen);
            this.panel1.Controls.Add(this.cboAño);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboMes);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 61);
            this.panel1.TabIndex = 290;
            // 
            // chkCero
            // 
            this.chkCero.AutoSize = true;
            this.chkCero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCero.Location = new System.Drawing.Point(607, 30);
            this.chkCero.Name = "chkCero";
            this.chkCero.Size = new System.Drawing.Size(79, 17);
            this.chkCero.TabIndex = 322;
            this.chkCero.Text = "Incluir Cero";
            this.chkCero.UseVisualStyleBackColor = true;
            this.chkCero.CheckedChanged += new System.EventHandler(this.chkCero_CheckedChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(520, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 21);
            this.dtpFecha.TabIndex = 321;
            // 
            // chkFecha
            // 
            this.chkFecha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFecha.Location = new System.Drawing.Point(437, 31);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(68, 17);
            this.chkFecha.TabIndex = 291;
            this.chkFecha.TabStop = false;
            this.chkFecha.Text = "a Fecha:";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "Almacen";
            // 
            // cboalmacen
            // 
            this.cboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboalmacen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboalmacen.FormattingEnabled = true;
            this.cboalmacen.Location = new System.Drawing.Point(58, 28);
            this.cboalmacen.Name = "cboalmacen";
            this.cboalmacen.Size = new System.Drawing.Size(158, 21);
            this.cboalmacen.TabIndex = 318;
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(254, 28);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(64, 21);
            this.cboAño.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 312;
            this.label4.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Mes";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(352, 28);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(78, 21);
            this.cboMes.TabIndex = 271;
            // 
            // button1
            // 
            this.button1.Image = global::ClienteWinForm.Properties.Resources.busquedas_grande;
            this.button1.Location = new System.Drawing.Point(1217, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 59);
            this.button1.TabIndex = 154;
            this.button1.Text = "BUSCAR";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.Azure;
            this.btBuscar.ContextMenuStrip = this.cmsImprimir;
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::ClienteWinForm.Properties.Resources.Mostrar_Reporte;
            this.btBuscar.Location = new System.Drawing.Point(704, 13);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(51, 47);
            this.btBuscar.TabIndex = 289;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cmsImprimir
            // 
            this.cmsImprimir.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmsImprimir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockMensualToolStripMenuItem,
            this.stockMensualPorArticuloToolStripMenuItem,
            this.stockMensualPorArticuloConCostoToolStripMenuItem});
            this.cmsImprimir.Name = "cmsImprimir";
            this.cmsImprimir.Size = new System.Drawing.Size(277, 70);
            // 
            // stockMensualToolStripMenuItem
            // 
            this.stockMensualToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.stockMensualToolStripMenuItem.Name = "stockMensualToolStripMenuItem";
            this.stockMensualToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.stockMensualToolStripMenuItem.Text = "Stock Mensual";
            this.stockMensualToolStripMenuItem.Click += new System.EventHandler(this.stockMensualToolStripMenuItem_Click);
            // 
            // stockMensualPorArticuloToolStripMenuItem
            // 
            this.stockMensualPorArticuloToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.stockMensualPorArticuloToolStripMenuItem.Name = "stockMensualPorArticuloToolStripMenuItem";
            this.stockMensualPorArticuloToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.stockMensualPorArticuloToolStripMenuItem.Text = "Stock Mensual por Articulo";
            this.stockMensualPorArticuloToolStripMenuItem.Click += new System.EventHandler(this.stockMensualPorArticuloToolStripMenuItem_Click);
            // 
            // stockMensualPorArticuloConCostoToolStripMenuItem
            // 
            this.stockMensualPorArticuloConCostoToolStripMenuItem.Image = global::ClienteWinForm.Properties.Resources.Impresion;
            this.stockMensualPorArticuloConCostoToolStripMenuItem.Name = "stockMensualPorArticuloConCostoToolStripMenuItem";
            this.stockMensualPorArticuloConCostoToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.stockMensualPorArticuloConCostoToolStripMenuItem.Text = "Stock Mensual por Articulo Con Costo";
            this.stockMensualPorArticuloConCostoToolStripMenuItem.Click += new System.EventHandler(this.stockMensualPorArticuloConCostoToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblProcesando);
            this.panel3.Controls.Add(this.pbProgress);
            this.panel3.Controls.Add(this.wbNavegador);
            this.panel3.Location = new System.Drawing.Point(3, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 322);
            this.panel3.TabIndex = 288;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.White;
            this.lblProcesando.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(614, 285);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 19);
            this.lblProcesando.TabIndex = 325;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcesando.Visible = false;
            this.lblProcesando.SizeChanged += new System.EventHandler(this.lblProcesando_SizeChanged);
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.White;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(638, 166);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(113, 105);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 324;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // wbNavegador
            // 
            this.wbNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNavegador.Location = new System.Drawing.Point(0, 0);
            this.wbNavegador.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNavegador.Name = "wbNavegador";
            this.wbNavegador.Size = new System.Drawing.Size(1064, 320);
            this.wbNavegador.TabIndex = 268;
            // 
            // lblregistros
            // 
            this.lblregistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.lblregistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblregistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistros.Location = new System.Drawing.Point(0, 0);
            this.lblregistros.Name = "lblregistros";
            this.lblregistros.Size = new System.Drawing.Size(693, 18);
            this.lblregistros.TabIndex = 1590;
            this.lblregistros.Text = "Parámetros de Búsqueda";
            this.lblregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReporteStockMensualvsListaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 392);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.panel3);
            this.Name = "frmReporteStockMensualvsListaPrecio";
            this.Text = "Stock de Articulos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteStockMensual_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteStockMensual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsImprimir.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.WebBrowser wbNavegador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboalmacen;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ContextMenuStrip cmsImprimir;
        private System.Windows.Forms.ToolStripMenuItem stockMensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockMensualPorArticuloToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkCero;
        private System.Windows.Forms.ToolStripMenuItem stockMensualPorArticuloConCostoToolStripMenuItem;
        private System.Windows.Forms.Label lblregistros;
    }
}