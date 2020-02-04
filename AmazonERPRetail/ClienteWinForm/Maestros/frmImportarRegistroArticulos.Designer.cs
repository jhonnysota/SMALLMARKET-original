namespace ClienteWinForm.Maestros
{
    partial class frmImportarRegistroArticulos
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblProcesando = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new MyLabelG.LabelDegradado();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.btProcesar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.bterrores = new System.Windows.Forms.Button();
            this.btIntegrar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.BackColor = System.Drawing.Color.Transparent;
            this.lblProcesando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblProcesando.Location = new System.Drawing.Point(149, 109);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 13);
            this.lblProcesando.TabIndex = 306;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvListado);
            this.panel5.Controls.Add(this.lblRegistros);
            this.panel5.Location = new System.Drawing.Point(5, 125);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(700, 5);
            this.panel5.TabIndex = 305;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EnableHeadersVisualStyles = false;
            this.dgvListado.Location = new System.Drawing.Point(0, 23);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(698, 0);
            this.dgvListado.TabIndex = 0;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistros.EstiloDegradado = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.PrimerColor = System.Drawing.Color.SlateGray;
            this.lblRegistros.SegundoColor = System.Drawing.Color.LightSteelBlue;
            this.lblRegistros.Size = new System.Drawing.Size(698, 23);
            this.lblRegistros.TabIndex = 249;
            this.lblRegistros.Text = "Items - Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            this.pbProgress.Image = global::ClienteWinForm.Properties.Resources.ProgressBar_Procesar;
            this.pbProgress.Location = new System.Drawing.Point(103, 81);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(40, 38);
            this.pbProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProgress.TabIndex = 304;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // btProcesar
            // 
            this.btProcesar.BackColor = System.Drawing.Color.Azure;
            this.btProcesar.Enabled = false;
            this.btProcesar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProcesar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcesar.Image = global::ClienteWinForm.Properties.Resources.Proceso;
            this.btProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btProcesar.Location = new System.Drawing.Point(492, 72);
            this.btProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btProcesar.Name = "btProcesar";
            this.btProcesar.Size = new System.Drawing.Size(65, 47);
            this.btProcesar.TabIndex = 302;
            this.btProcesar.Text = "Procesar";
            this.btProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProcesar.UseVisualStyleBackColor = false;
            this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.Color.Azure;
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Image = global::ClienteWinForm.Properties.Resources.ActualizarExcel;
            this.btActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btActualizar.Location = new System.Drawing.Point(422, 72);
            this.btActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(65, 47);
            this.btActualizar.TabIndex = 301;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btExaminar);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Location = new System.Drawing.Point(103, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 62);
            this.panel1.TabIndex = 300;
            // 
            // btExaminar
            // 
            this.btExaminar.BackColor = System.Drawing.Color.Azure;
            this.btExaminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExaminar.Image = global::ClienteWinForm.Properties.Resources.buscar_reg;
            this.btExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExaminar.Location = new System.Drawing.Point(504, 25);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(81, 24);
            this.btExaminar.TabIndex = 295;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExaminar.UseVisualStyleBackColor = false;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(9, 27);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(492, 21);
            this.txtRuta.TabIndex = 297;
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Image = global::ClienteWinForm.Properties.Resources.HojaExcel;
            this.pbImagen.Location = new System.Drawing.Point(5, 4);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(89, 115);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // bterrores
            // 
            this.bterrores.BackColor = System.Drawing.Color.Azure;
            this.bterrores.Enabled = false;
            this.bterrores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.bterrores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bterrores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.bterrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bterrores.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bterrores.Image = global::ClienteWinForm.Properties.Resources.cerrar;
            this.bterrores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bterrores.Location = new System.Drawing.Point(562, 72);
            this.bterrores.Margin = new System.Windows.Forms.Padding(2);
            this.bterrores.Name = "bterrores";
            this.bterrores.Size = new System.Drawing.Size(65, 47);
            this.bterrores.TabIndex = 307;
            this.bterrores.Text = "Errores";
            this.bterrores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bterrores.UseVisualStyleBackColor = false;
            this.bterrores.Click += new System.EventHandler(this.button1_Click);
            // 
            // btIntegrar
            // 
            this.btIntegrar.BackColor = System.Drawing.Color.Azure;
            this.btIntegrar.Enabled = false;
            this.btIntegrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btIntegrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btIntegrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.btIntegrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIntegrar.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIntegrar.Image = global::ClienteWinForm.Properties.Resources.Generar;
            this.btIntegrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btIntegrar.Location = new System.Drawing.Point(632, 72);
            this.btIntegrar.Margin = new System.Windows.Forms.Padding(2);
            this.btIntegrar.Name = "btIntegrar";
            this.btIntegrar.Size = new System.Drawing.Size(65, 47);
            this.btIntegrar.TabIndex = 308;
            this.btIntegrar.Text = "Integrar";
            this.btIntegrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btIntegrar.UseVisualStyleBackColor = false;
            this.btIntegrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(595, 18);
            this.label8.TabIndex = 429;
            this.label8.Text = "Ruta del Archivo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmImportarRegistroArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 124);
            this.Controls.Add(this.btIntegrar);
            this.Controls.Add(this.bterrores);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btProcesar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbImagen);
            this.Name = "frmImportarRegistroArticulos";
            this.Text = "Importar Registro de Articulos (*.xls, *.xlsx)";
            this.Load += new System.EventHandler(this.frmImportarVentasDiarias_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvListado;
        private MyLabelG.LabelDegradado lblRegistros;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Button bterrores;
        private System.Windows.Forms.Button btIntegrar;
        private System.Windows.Forms.Label label8;
    }
}